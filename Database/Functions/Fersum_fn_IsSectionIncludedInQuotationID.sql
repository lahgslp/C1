IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[dbo].[Fersum_fn_IsSectionIncludedInQuotationID]') AND type in ('FN'))
BEGIN
	DROP FUNCTION [dbo].[Fersum_fn_IsSectionIncludedInQuotationID]
END

GO

CREATE FUNCTION [dbo].[Fersum_fn_IsSectionIncludedInQuotationID]
(
	@QuotationID int,
	@SectionTypeID int
)
RETURNS int
AS 
BEGIN
	DECLARE @ReturnValue int;

	SET @ReturnValue = 0;

	IF EXISTS (
		SELECT 1
		FROM Quotation Q
			INNER JOIN QuotationSection QS ON Q.QuotationID = QS.QuotationID
		WHERE Q.QuotationID = @QuotationID AND QS.SectionTypeID = @SectionTypeID
		)
	BEGIN
		SET @ReturnValue = 1;
	END

	RETURN @ReturnValue;
END;

GO
