IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[dbo].[Fersum_Del_RemoveQuotationSectionDetailByQuotationSectionDetailID]') AND type in ('P'))
BEGIN
	DROP PROCEDURE [dbo].[Fersum_Del_RemoveQuotationSectionDetailByQuotationSectionDetailID]
END

GO

CREATE PROCEDURE [dbo].[Fersum_Del_RemoveQuotationSectionDetailByQuotationSectionDetailID]
	@QuotationID int,
	@QuotationSectionDetailID int
AS
BEGIN

--This is to remove the QuotationSectionDetail
DELETE FROM QuotationSectionDetail
	WHERE QuotationSectionDetailID = @QuotationSectionDetailID;
/*
IF NOT EXISTS( SELECT 1 FROM QuotationSection QS INNER JOIN QuotationSectionDetail QSD ON QS.QuotationSectionID = QSD.QuotationSectionID WHERE QS.QuotationSectionID = @QuotationSectionID)
BEGIN
	--This is to remove the QuotationSection if no more details exist
	DELETE FROM QuotationSection
		WHERE QuotationSectionID = @QuotationSectionID
END
*/
END

GO
