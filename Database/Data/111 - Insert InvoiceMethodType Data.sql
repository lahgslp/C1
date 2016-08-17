DELETE FROM [InvoiceMethodType];

DBCC CHECKIDENT ([InvoiceMethodType], RESEED, 0);

INSERT INTO [dbo].[InvoiceMethodType] ([ShortName],[Description],[Active],[Creator],[Created]) VALUES('INV01','Por metro lineal más IVA','A','admin',GETDATE());
INSERT INTO [dbo].[InvoiceMethodType] ([ShortName],[Description],[Active],[Creator],[Created]) VALUES('INV02','En Peso Teórico Más IVA','A','admin',GETDATE());
INSERT INTO [dbo].[InvoiceMethodType] ([ShortName],[Description],[Active],[Creator],[Created]) VALUES('INV03','En Peso Neto Más IVA','A','admin',GETDATE());

SELECT * FROM [InvoiceMethodType];