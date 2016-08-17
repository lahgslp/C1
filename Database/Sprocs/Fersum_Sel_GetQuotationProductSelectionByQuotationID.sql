IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[dbo].[Fersum_Sel_GetQuotationProductSelectionByQuotationID]') AND type in ('P'))
BEGIN
	DROP PROCEDURE [dbo].[Fersum_Sel_GetQuotationProductSelectionByQuotationID]
END

GO

CREATE PROCEDURE [dbo].[Fersum_Sel_GetQuotationProductSelectionByQuotationID]
	@QuotationID int
AS
BEGIN

SELECT QS.QuotationID, QS.QuotationSectionID, QSD.QuotationSectionDetailID, QSD.PipeSpecificationID,
	PS.PipeDiameterTypeID, QSD.Quantity, UT.UnitTypeID, QS.SectionTypeID,
	PS.KilogramsPerMeter,
	PDT.ShortName
	AS PDTDescription,
	CAST (PS.WallThicknessInches AS varchar(10)) +
	CASE WHEN (PS.PipeSchedule <> '' AND PS.PipeClass <> '') THEN ' (Cédula ' + PS.PipeSchedule + ' ' + PS.PipeClass + ')'
		WHEN (PS.PipeSchedule <> '') THEN ' (Cédula ' + PS.PipeSchedule + ')'
		WHEN (PS.PipeClass <> '') THEN ' (' + PS.PipeClass + ')'
		ELSE ''
	END
	AS PSDescription
	FROM QuotationSection QS
	INNER JOIN QuotationSectionDetail QSD ON QS.QuotationSectionID = QSD.QuotationSectionID
	INNER JOIN v_PipeSpecification PS ON QSD.PipeSpecificationID = PS.PipeSpecificationID
	INNER JOIN PipeDiameterType PDT ON PS.PipeDiameterTypeID = PDT.PipeDiameterTypeID
	INNER JOIN UnitType UT ON QSD.UnitTypeID = UT.UnitTypeID
WHERE QuotationID = @QuotationID
ORDER BY QuotationSectionDetailID ASC;
END

GO
