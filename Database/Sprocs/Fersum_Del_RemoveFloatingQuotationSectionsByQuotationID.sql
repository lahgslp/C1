IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[dbo].[Fersum_Del_RemoveFloatingQuotationSectionsByQuotationID]') AND type in ('P'))
BEGIN
	DROP PROCEDURE [dbo].[Fersum_Del_RemoveFloatingQuotationSectionsByQuotationID]
END

GO

CREATE PROCEDURE [dbo].[Fersum_Del_RemoveFloatingQuotationSectionsByQuotationID]
	@QuotationID int
AS
BEGIN

--This is to remove the QuotationSection if no more details exist
DELETE FROM QuotationSection
	WHERE QuotationID = @QuotationID AND QuotationSectionID NOT IN (
		SELECT QS.QuotationSectionID
		FROM QuotationSection QS
			INNER JOIN QuotationSectionDetail QSD ON QS.QuotationSectionID = QSD.QuotationSectionID
		WHERE QS.QuotationID = @QuotationID
		)

END

GO
