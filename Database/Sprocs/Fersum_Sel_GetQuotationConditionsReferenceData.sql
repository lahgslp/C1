IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[dbo].[Fersum_Sel_GetQuotationConditionsReferenceData]') AND type in ('P'))
BEGIN
	DROP PROCEDURE [dbo].[Fersum_Sel_GetQuotationConditionsReferenceData]
END

GO

CREATE PROCEDURE [dbo].[Fersum_Sel_GetQuotationConditionsReferenceData]
AS
BEGIN
	SELECT Description FROM DeliveryType;
	SELECT Description FROM DeliveryTimeType;
	SELECT Description FROM CurrencyType ORDER BY(Description);
	--SELECT Description FROM ValidPeriodType;
END

GO
