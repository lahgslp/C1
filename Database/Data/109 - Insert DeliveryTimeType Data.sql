DELETE FROM [DeliveryTimeType];

DBCC CHECKIDENT ([DeliveryTimeType], RESEED, 0);

INSERT INTO [dbo].[DeliveryTimeType] ([ShortName],[Description],[Active],[Creator],[Created]) VALUES('','Inmediato','A','admin',GETDATE());
INSERT INTO [dbo].[DeliveryTimeType] ([ShortName],[Description],[Active],[Creator],[Created]) VALUES('','2-3 d�as','A','admin',GETDATE());
INSERT INTO [dbo].[DeliveryTimeType] ([ShortName],[Description],[Active],[Creator],[Created]) VALUES('','7 d�as','A','admin',GETDATE());
INSERT INTO [dbo].[DeliveryTimeType] ([ShortName],[Description],[Active],[Creator],[Created]) VALUES('','15 d�as','A','admin',GETDATE());
INSERT INTO [dbo].[DeliveryTimeType] ([ShortName],[Description],[Active],[Creator],[Created]) VALUES('','45-60 d�as','A','admin',GETDATE());
INSERT INTO [dbo].[DeliveryTimeType] ([ShortName],[Description],[Active],[Creator],[Created]) VALUES('','60-70 d�as','A','admin',GETDATE());
INSERT INTO [dbo].[DeliveryTimeType] ([ShortName],[Description],[Active],[Creator],[Created]) VALUES('','70-90 d�as','A','admin',GETDATE());

SELECT * FROM [DeliveryTimeType];