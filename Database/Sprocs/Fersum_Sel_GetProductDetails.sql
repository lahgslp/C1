IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[dbo].[Fersum_Sel_GetProductDetails]') AND type in ('P'))
BEGIN
	DROP PROCEDURE [dbo].[Fersum_Sel_GetProductDetails]
END

GO

CREATE PROCEDURE [dbo].[Fersum_Sel_GetProductDetails]
AS
BEGIN

SELECT PipeDiameterTypeID, ShortName, ExternalDiameterInches, Active, COALESCE(Modified, Created) AS LastUpdated FROM PipeDiameterType;

SELECT PS.PipeSpecificationID, PDT.PipeDiameterTypeID, PDT.ShortName, CAST (PS.WallThicknessInches AS varchar(10)) AS WallThicknessInches, PipeSchedule, PipeClass,
	PS.Active, COALESCE(PS.Modified, PS.Created) AS LastUpdated FROM PipeDiameterType PDT INNER JOIN PipeSpecification PS ON PDT.PipeDiameterTypeID = PS.PipeDiameterTypeID

END

GO
