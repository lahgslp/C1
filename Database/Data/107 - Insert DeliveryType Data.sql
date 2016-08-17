DELETE FROM [DeliveryType];

DBCC CHECKIDENT ([DeliveryType], RESEED, 0);

INSERT INTO [dbo].[DeliveryType] ([ShortName],[Description],[Active],[Creator],[Created]) VALUES('LABAlmacen','LAB Monterrey, nuestro almacén + IVA','A','admin',GETDATE());
INSERT INTO [dbo].[DeliveryType] ([ShortName],[Description],[Active],[Creator],[Created]) VALUES('LABTransportista','LAB Monterrey, transportista ocurre + IVA','A','admin',GETDATE());
INSERT INTO [dbo].[DeliveryType] ([ShortName],[Description],[Active],[Creator],[Created]) VALUES('LABDestino','LAB Destino final + IVA','A','admin',GETDATE());
INSERT INTO [dbo].[DeliveryType] ([ShortName],[Description],[Active],[Creator],[Created]) VALUES('ESPECIAL','(Ciudad) + IVA','A','admin',GETDATE());
INSERT INTO [dbo].[DeliveryType] ([ShortName],[Description],[Active],[Creator],[Created]) VALUES('LABManzanillo','LAB Manzanillo + IVA','A','admin',GETDATE());

SELECT * FROM [DeliveryType];