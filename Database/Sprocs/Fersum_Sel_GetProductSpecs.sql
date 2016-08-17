IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[dbo].[Fersum_Sel_GetProductSpecs]') AND type in ('P'))
BEGIN
	DROP PROCEDURE [dbo].[Fersum_Sel_GetProductSpecs]
END

GO

CREATE PROCEDURE [dbo].[Fersum_Sel_GetProductSpecs]
AS
BEGIN

SELECT DISTINCT PDT.ShortName, PDT.PipeDiameterTypeID
FROM PipeDiameterType PDT INNER JOIN PipeSpecification PS
	ON PDT.PipeDiameterTypeID = PS.PipeDiameterTypeID AND PDT.Active = 'A' 
ORDER BY PDT.PipeDiameterTypeID

SELECT PDT.ShortName, CAST (PS.WallThicknessInches AS varchar(10)) +
	CASE WHEN (PipeSchedule <> '' AND PipeClass <> '') THEN ' (Cédula ' + PipeSchedule + ' ' + PipeClass + ')'
		WHEN (PipeSchedule <> '') THEN ' (Cédula ' + PipeSchedule + ')'
		WHEN (PipeClass <> '') THEN ' (' + PipeClass + ')'
		ELSE ''
	END
	AS Description FROM PipeDiameterType PDT INNER JOIN PipeSpecification PS ON PDT.PipeDiameterTypeID = PS.PipeDiameterTypeID
		AND PDT.Active = 'A' AND PS.Active = 'A'

SELECT *, CAST (WallThicknessInches AS varchar(10)) +
	CASE WHEN (PipeSchedule <> '' AND PipeClass <> '') THEN ' (Cédula ' + PipeSchedule + ' ' + PipeClass + ')'
		WHEN (PipeSchedule <> '') THEN ' (Cédula ' + PipeSchedule + ')'
		WHEN (PipeClass <> '') THEN ' (' + PipeClass + ')'
		ELSE ''
	END
	AS Description
FROM v_PipeSpecification;

SELECT UnitTypeID, ShortName, Description, Active FROM UnitType;

END

GO
