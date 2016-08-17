use Fersum;

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[dbo].[Fersum_Sel_GetQuotationFinishReferenceData]') AND type in ('P'))
BEGIN
	DROP PROCEDURE [dbo].[Fersum_Sel_GetQuotationFinishReferenceData]
END

GO

CREATE PROCEDURE [dbo].[Fersum_Sel_GetQuotationFinishReferenceData]
AS
BEGIN
	SELECT Description FROM ValidPeriodType;
	SELECT Description FROM PaymentType;
	SELECT Description FROM InvoiceMethodType;
END

GO
