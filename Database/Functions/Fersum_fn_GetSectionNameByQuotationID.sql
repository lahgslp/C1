IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[dbo].[Fersum_fn_GetSectionNameByQuotationID]') AND type in ('FN'))
BEGIN
	DROP FUNCTION [dbo].[Fersum_fn_GetSectionNameByQuotationID]
END

GO

CREATE FUNCTION [dbo].[Fersum_fn_GetSectionNameByQuotationID]
(
	@QuotationID int
)
RETURNS varchar(20)
AS 
BEGIN
	DECLARE @SectionName varchar(20);
	DECLARE @SectionCount int;

	SET @SectionName = '';
	SELECT @SectionCount = COUNT(*) FROM QuotationSection QS WHERE QS.QuotationID = @QuotationID;

	IF @SectionCount = 1
	BEGIN
		SELECT @SectionName = ST.ShortName
		FROM Quotation Q
			INNER JOIN QuotationSection QS ON Q.QuotationID = QS.QuotationID
			INNER JOIN SectionType ST ON QS.SectionTypeID = ST.SectionTypeID
		WHERE Q.QuotationID = @QuotationID;
	END
	ELSE IF @SectionCount > 1
	BEGIN
		SET @SectionName = 'Varias';
	END

	RETURN @SectionName;
END;

GO
