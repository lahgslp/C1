use Fersum;

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[dbo].[Fersum_Ins_CloneQuotation]') AND type in ('P'))
BEGIN
	DROP PROCEDURE [dbo].[Fersum_Ins_CloneQuotation]
END

GO

CREATE PROCEDURE [dbo].[Fersum_Ins_CloneQuotation]
(
	@QuotationID int,
	@User varchar(20)
)
AS 
BEGIN

	/*DECLARE @User varchar(20);
	DECLARE @QuotationID int;
	SET @QuotationID = 309;
	SET @User = 'cdelapaz';*/

BEGIN TRANSACTION

DECLARE @NewQuotationID int;

DECLARE @QuotationSection TABLE
(
	OldQuotationSectionID int,
	NewQuotationSectionID int,
	SectionTypeID int
);

	INSERT INTO [dbo].[Quotation]
		([CustomerID], [CustomerContactID], [EmailTo], [ClonedFromQuotationID], [QuotationStatusTypeID], [ValidPeriodDescription], [PaymentDescription], [Notes], [Active], [Creator], [Created], [InvoiceMethodDescription])
	SELECT Q.CustomerID , Q.CustomerContactID, Q.EmailTo,@QuotationID, 1, Q.ValidPeriodDescription, Q.PaymentDescription, Q.Notes, 'A', @User, GETDATE(), InvoiceMethodDescription
	FROM Quotation Q WHERE Q.QuotationID = @QuotationID;

	SET @NewQuotationID = @@IDENTITY;

	INSERT INTO @QuotationSection
		(OldQuotationSectionID, SectionTypeID)
	SELECT QS.QuotationSectionID, QS.SectionTypeID FROM QuotationSection QS WHERE QS.QuotationID = @QuotationID;


	INSERT INTO [dbo].[QuotationSection]
		([QuotationID] ,[SectionTypeID] ,[Active] ,[Creator] ,[Created], [SectionDescription])
	SELECT @NewQuotationID, QS.SectionTypeID, 'A', @User, GETDATE(), QS.SectionDescription
	FROM QuotationSection QS WHERE QS.QuotationID = @QuotationID;

	UPDATE @QuotationSection
	SET NewQuotationSectionID = QS.QuotationSectionID
	FROM @QuotationSection QST INNER JOIN QuotationSection QS ON QST.SectionTypeID = QS.SectionTypeID
	WHERE QS.QuotationID = @NewQuotationID;

	INSERT INTO .[dbo].[QuotationSectionDetail]
		([QuotationSectionID], [PipeSpecificationID], [Quantity], [Price], [DeliveryDescription],
			[DeliveryTimeDescription],
			--[PaymentDescription],
			[CurrencyDescription],
			--[ValidPeriodDescription],
			[UnitTypeID], [Active], [Creator], [Created])
	SELECT
		QST.NewQuotationSectionID
		, QSD.PipeSpecificationID
		, QSD.Quantity
		, QSD.Price
		, QSD.DeliveryDescription
		, QSD.DeliveryTimeDescription
		--, QSD.PaymentDescription
		, QSD.CurrencyDescription
		--, QSD.ValidPeriodDescription
		, QSD.UnitTypeID
		,'A'
		,@User
		,GETDATE()
	FROM QuotationSection QS
		INNER JOIN QuotationSectionDetail QSD ON QS.QuotationSectionID = QSD.QuotationSectionID
		INNER JOIN @QuotationSection QST ON QS.QuotationSectionID = QST.OldQuotationSectionID
	WHERE QS.QuotationID = @QuotationID;

	--TEST QUERIES:
	--SELECT @NewQuotationID;
	--SELECT * FROM Quotation WHERE QuotationID = @NewQuotationID;
	--SELECT * FROM QuotationSection WHERE QuotationID = @NewQuotationID;
	--SELECT * FROM QuotationSectionDetail WHERE QuotationSectionID IN (SELECT QuotationSectionID FROM QuotationSection WHERE QuotationID = @NewQuotationID)
	--SELECT * FROM @QuotationSection;
	--ROLLBACK TRANSACTION;
	
COMMIT TRANSACTION;

SELECT @NewQuotationID;

END;

GO
