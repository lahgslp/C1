IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[dbo].[Fersum_Sel_GetQuotationSectionID]') AND type in ('P'))
BEGIN
	DROP PROCEDURE [dbo].[Fersum_Sel_GetQuotationSectionID]
END

GO

CREATE PROCEDURE [dbo].[Fersum_Sel_GetQuotationSectionID]
	@QuotationID int,
	@SectionTypeID int
AS
BEGIN

DECLARE @QuotationSectionID int;

SELECT @QuotationSectionID = QS.QuotationSectionID FROM QuotationSection QS WHERE QS.QuotationID = @QuotationID AND QS.SectionTypeID = @SectionTypeID;

IF @QuotationSectionID IS NULL
BEGIN
	SET @QuotationSectionID = 0
END

SELECT @QuotationSectionID;

END

GO
