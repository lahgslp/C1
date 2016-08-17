IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[dbo].[Fersum_Del_RemoveQuotationSectionDetailByQuotationID]') AND type in ('P'))
BEGIN
	DROP PROCEDURE [dbo].[Fersum_Del_RemoveQuotationSectionDetailByQuotationID]
END

GO

CREATE PROCEDURE [dbo].[Fersum_Del_RemoveQuotationSectionDetailByQuotationID]
	@QuotationID int,
	@QuotationSectionDetailID int
AS
BEGIN

--This is to remove the QuotationSectionDetail
DELETE FROM QuotationSectionDetail
	WHERE QuotationSectionDetailID = @QuotationSectionDetailID;

--This is to remove the QuotationSection if no details exist
DELETE FROM QuotationSection
	WHERE QuotationSectionID NOT IN (
			SELECT QS.QuotationSectionID
			FROM QuotationSection QS INNER JOIN Quotation Q ON QS.QuotationID = Q.QuotationID
				INNER JOIN QuotationSectionDetail QSD ON QS.QuotationSectionID = QSD.QuotationSectionID
			WHERE Q.QuotationID = @QuotationID
		)
		AND QuotationID = @QuotationID;
END

GO
