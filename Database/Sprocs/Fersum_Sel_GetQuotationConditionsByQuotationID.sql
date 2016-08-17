IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[dbo].[Fersum_Sel_GetQuotationConditionsByQuotationID]') AND type in ('P'))
BEGIN
	DROP PROCEDURE [dbo].[Fersum_Sel_GetQuotationConditionsByQuotationID]
END

GO

CREATE PROCEDURE [dbo].[Fersum_Sel_GetQuotationConditionsByQuotationID]
(
	@QuotationID int
)
AS
BEGIN
	SELECT Q.QuotationID, QS.QuotationSectionID, QS.SectionTypeID, ST.ShortName,
		CASE WHEN QS.SectionDescription = '' THEN ST.Description
			ELSE QS.SectionDescription END AS Description
	FROM Quotation Q
		INNER JOIN QuotationSection QS ON Q.QuotationID = QS.QuotationID
		INNER JOIN SectionType ST ON QS.SectionTypeID = ST.SectionTypeID
	WHERE Q.QuotationID = @QuotationID
	ORDER BY ST.SectionTypeID;

	SELECT Q.QuotationID, QS.QuotationSectionID, QS.SectionTypeID, QSD.QuotationSectionDetailID, QSD.PipeSpecificationID, PS.ShortName,
		CAST (PS.WallThicknessInches AS varchar(10)) +
			CASE WHEN (PS.PipeSchedule <> '') THEN ' (Cédula ' + PS.PipeSchedule +
				CASE WHEN (PS.PipeClass <> '') THEN ' ' + PS.PipeClass ELSE '' END
			+ ')' ELSE '' END
		AS Description,
		QSD.Quantity,		
		PS.KilogramsPerMeter AS LinearWeight,
		Price,
		CASE WHEN QSD.CurrencyDescription = '' THEN
			(CASE WHEN QS.SectionTypeID IN (1,2) THEN RTRIM((SELECT TOP 1 Description FROM CurrencyType WHERE CurrencyTypeID = 2))
				ELSE RTRIM((SELECT TOP 1 Description FROM CurrencyType WHERE CurrencyTypeID = 1)) END)
			ELSE QSD.CurrencyDescription END AS CurrencyDescription,
		QSD.Weight,
		CASE WHEN (UT.ShortName = 'Tramos') THEN QSD.Weight
			ELSE '$ ' + CONVERT(varchar(20),CONVERT(money, Price * QSD.Quantity), 1) END AS TotalPerConcept,
		--PaymentDescription,
		DeliveryDescription,
		DeliveryTimeDescription
		--,ValidPeriodDescription
	FROM Quotation Q
		INNER JOIN QuotationSection QS ON Q.QuotationID = QS.QuotationID
		INNER JOIN QuotationSectionDetail QSD ON QS.QuotationSectionID = QSD.QuotationSectionID
		LEFT JOIN dbo.v_PipeSpecification PS ON QSD.PipeSpecificationID = PS.PipeSpecificationID
		INNER JOIN UnitType UT ON QSD.UnitTypeID = UT.UnitTypeID
	WHERE Q.QuotationID = @QuotationID
	ORDER BY QS.SectionTypeID;
END

GO
