DELETE FROM [UnitType];

DBCC CHECKIDENT ([UnitType], RESEED, 0);

INSERT INTO [dbo].[UnitType] ([ShortName],[Description],[Active],[Creator],[Created]) VALUES('Metros','Metros en Sistema Internacional de medidas','A','admin',GETDATE());
INSERT INTO [dbo].[UnitType] ([ShortName],[Description],[Active],[Creator],[Created]) VALUES('Toneladas','Toneladas en sistema internacional de medidas','A','admin',GETDATE());
INSERT INTO [dbo].[UnitType] ([ShortName],[Description],[Active],[Creator],[Created]) VALUES('Tramos','Tramos de tubo','A','admin',GETDATE());

SELECT * FROM [UnitType];