IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[dbo].[Fersum_fn_IsPipeDiameterIncludedInQuotationID]') AND type in ('FN'))
BEGIN
	DROP FUNCTION [dbo].[Fersum_fn_IsPipeDiameterIncludedInQuotationID]
END

GO

CREATE FUNCTION [dbo].[Fersum_fn_IsPipeDiameterIncludedInQuotationID]
(
	@QuotationID int,
	@PipeDiameterTypeID int
)
RETURNS int
AS 
BEGIN
	DECLARE @ReturnValue int;

	SET @ReturnValue = 0;

	IF EXISTS (
		SELECT 1
		FROM Quotation Q
			INNER JOIN QuotationSection QS ON Q.QuotationID = QS.QuotationID AND Q.QuotationID = @QuotationID
			INNER JOIN QuotationSectionDetail QSD ON QS.QuotationSectionID = QSD.QuotationSectionID
			INNER JOIN PipeSpecification PS ON QSD.PipeSpecificationID = PS.PipeSpecificationID AND PS.PipeDiameterTypeID = @PipeDiameterTypeID
		)
	BEGIN
		SET @ReturnValue = 1;
	END

	RETURN @ReturnValue;
END;

GO
