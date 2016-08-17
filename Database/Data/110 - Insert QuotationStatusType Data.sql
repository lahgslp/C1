DELETE FROM [QuotationStatusType];

DBCC CHECKIDENT ([QuotationStatusType], RESEED, 0);

INSERT INTO [dbo].[QuotationStatusType] ([ShortName],[Description],[Active],[Creator],[Created]) VALUES('Incompleta','Incompleta','A','admin',GETDATE());
INSERT INTO [dbo].[QuotationStatusType] ([ShortName],[Description],[Active],[Creator],[Created]) VALUES('Completa','Completa','A','admin',GETDATE());
INSERT INTO [dbo].[QuotationStatusType] ([ShortName],[Description],[Active],[Creator],[Created]) VALUES('Finalizada','Finalizada','A','admin',GETDATE());
INSERT INTO [dbo].[QuotationStatusType] ([ShortName],[Description],[Active],[Creator],[Created]) VALUES('Vendida','Vendida','A','admin',GETDATE());
INSERT INTO [dbo].[QuotationStatusType] ([ShortName],[Description],[Active],[Creator],[Created]) VALUES('FinalizadaExterna','Finalizada Externa','A','admin',GETDATE());
INSERT INTO [dbo].[QuotationStatusType] ([ShortName],[Description],[Active],[Creator],[Created]) VALUES('FinalizadaEnviada','Finalizada y Enviada','A','admin',GETDATE());

SELECT * FROM [QuotationStatusType];