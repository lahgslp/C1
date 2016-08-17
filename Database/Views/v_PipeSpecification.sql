IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[dbo].[v_PipeSpecification]') AND type in ('V'))
BEGIN
	DROP VIEW [dbo].[v_PipeSpecification]
END

GO

CREATE VIEW v_PipeSpecification AS
SELECT
	PS.PipeSpecificationID
	, PDT.PipeDiameterTypeID
	, PDT.ShortName
	, PDT.ExternalDiameterInches
	, ROUND(PDT.ExternalDiameterInches * 25.4, 1) AS ExternalDiameterMillimeters
	, PS.WallThicknessInches
	, ROUND(PS.WallThicknessInches * 25.4, 2) AS WallThicknessMillimeters
	, PS.PipeSchedule
	, PS.PipeClass
	, ROUND((((PDT.ExternalDiameterInches * 25.4) - (PS.WallThicknessInches * 25.4)) * (PS.WallThicknessInches * 25.4) * 0.02466) * 0.67733, 2) AS PoundsPerFeet
	, ROUND(((PDT.ExternalDiameterInches * 25.4) - (PS.WallThicknessInches * 25.4)) * (PS.WallThicknessInches * 25.4) * 0.02466, 2) AS KilogramsPerMeter
	FROM PipeSpecification PS INNER JOIN PipeDiameterType PDT ON PS.PipeDiameterTypeID = PDT.PipeDiameterTypeID;

GO
