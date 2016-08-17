IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[dbo].[Fersum_Sel_GetMyQuotations]') AND type in ('P'))
BEGIN
	DROP PROCEDURE [dbo].[Fersum_Sel_GetMyQuotations]
END

GO

CREATE PROCEDURE [dbo].[Fersum_Sel_GetMyQuotations]
(
	@Creator varchar(20),
	@DateFrom varchar(10),
	@DateTo varchar(10),
	@SectionTypeID int,
	@PipeDiameterTypeID int,
	@QuotationID int,
	@CustomerID int,
	@CustomerContactID int,
	@QuotationStatusTypeID int,
	@CompanyID int
)
AS
BEGIN
DECLARE @SQLSelect varchar(2000);
DECLARE @SQLFrom varchar(2000);
DECLARE @SQLWhere varchar(2000);
DECLARE @SQLOrderBy varchar(2000);
DECLARE @SQLStatement varchar(8000);

SET @SQLSelect =
'
SELECT
	TOP 300
	Q.QuotationID,
	Comp.CompanyName,
	COALESCE(C.Description,'''') AS CustomerName,
	COALESCE(CC.ContactName,'''') AS ContactName,
	COALESCE(Q.EmailTo,'''') AS Email,
	dbo.Fersum_fn_GetSectionNameByQuotationID(Q.QuotationID) AS Sections,
	Q.Created,
	U.FullName AS Creator,
	Q.QuotationStatusTypeID,
	COALESCE(QST.Description, '''') AS Status
	--, COALESCE(PDFFileName,'''') AS QuotationFileName
';

SET @SQLFrom =
'
	FROM Quotation Q
	INNER JOIN [dbo].[User] U ON Q.Creator = U.ShortName
	INNER JOIN Company Comp ON Q.CompanyID = Comp.CompanyID
	LEFT JOIN Customer C ON Q.CustomerID = C.CustomerID
	LEFT JOIN CustomerContact CC ON Q.CustomerContactID = CC.CustomerContactID
	LEFT JOIN QuotationStatusType QST ON Q.QuotationStatusTypeID = QST.QuotationStatusTypeID
';

SET @SQLWhere = 'WHERE Q.Active = ''A'' ';

SET @SQLOrderBy = 'ORDER BY Q.QuotationID DESC ';

--Check if any parameters are not null
IF	@Creator <> '' OR
	@DateFrom <> '' OR
	@DateTo <> '' OR
	@SectionTypeID <> 0 OR
	@PipeDiameterTypeID <> 0 OR
	@QuotationID <> 0 OR
	@CustomerID <> 0 OR
	@CustomerContactID <> 0 OR
	@QuotationStatusTypeID <> 0
BEGIN

	SET @SQLWhere = @SQLWhere + ' AND ';

	IF @Creator <> (SELECT Value FROM ConfigurationKey WHERE Name = 'FakeUser')
	BEGIN
		SET @SQLWhere = @SQLWhere + ' Q.Creator = ''' + @Creator + ''' AND ';
	END

	IF @DateFrom <> ''
	BEGIN
		SET @SQLWhere = @SQLWhere + ' CONVERT(varchar(8), Q.Created, 112) >= ''' + @DateFrom + ''' AND ';
	END

	IF @DateTo <> ''
	BEGIN
		SET @SQLWhere = @SQLWhere + ' CONVERT(varchar(8), Q.Created, 112) <= ''' + @DateTo + ''' AND ';
	END

	--TO CHECK
	IF @SectionTypeID <> 0
	BEGIN
		SET @SQLWhere = @SQLWhere + ' dbo.Fersum_fn_IsSectionIncludedInQuotationID(Q.QuotationID, ' + CAST(@SectionTypeID AS varchar(5)) + ') = 1 AND ';
	END

	--TO CHECK
	IF @PipeDiameterTypeID <> 0
	BEGIN
		SET @SQLWhere = @SQLWhere + ' dbo.Fersum_fn_IsPipeDiameterIncludedInQuotationID(Q.QuotationID, ' + CAST(@PipeDiameterTypeID AS varchar(5)) + ') = 1 AND ';
	END

	IF @QuotationID <> 0
	BEGIN
		SET @SQLWhere = @SQLWhere + ' Q.QuotationID = ' + CAST(@QuotationID AS varchar(10)) + ' AND ';
	END

	IF @CustomerID <> 0
	BEGIN
		SET @SQLWhere = @SQLWhere + ' Q.CustomerID = ' + CAST(@CustomerID AS varchar(10)) + ' AND ';
	END

	IF @CustomerContactID <> 0
	BEGIN
		SET @SQLWhere = @SQLWhere + ' Q.CustomerContactID = ' + CAST(@CustomerContactID AS varchar(10)) + ' AND ';
	END

	IF @QuotationStatusTypeID <> 0
	BEGIN
		SET @SQLWhere = @SQLWhere + ' Q.QuotationStatusTypeID = ' + CAST(@QuotationStatusTypeID AS varchar(10)) + ' AND ';
	END

	IF @CompanyID <> 0
	BEGIN
		SET @SQLWhere = @SQLWhere + ' Comp.CompanyID = ' + CAST(@CompanyID AS varchar(10)) + ' AND ';
	END

	SET @SQLWhere = SUBSTRING(@SQLWhere, 1, LEN(@SQLWhere) - 4);
END

SET @SQLStatement = @SQLSelect + @SQLFrom + @SQLWhere + @SQLOrderBy;


EXECUTE(@SQLStatement);

--SELECT @SQLStatement;	--REMOVE

END

GO
