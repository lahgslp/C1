DELETE FROM [PaymentType];

DBCC CHECKIDENT ([PaymentType], RESEED, 0);

INSERT INTO [dbo].[PaymentType] ([ShortName],[Description],[Active],[Creator],[Created]) VALUES('PREPAGO','Prepago contado','A','admin',GETDATE());
INSERT INTO [dbo].[PaymentType] ([ShortName],[Description],[Active],[Creator],[Created]) VALUES('7DIAS','7 días','A','admin',GETDATE());
INSERT INTO [dbo].[PaymentType] ([ShortName],[Description],[Active],[Creator],[Created]) VALUES('30DIAS','30 días','A','admin',GETDATE());
INSERT INTO [dbo].[PaymentType] ([ShortName],[Description],[Active],[Creator],[Created]) VALUES('45DIAS','45 días','A','admin',GETDATE());
INSERT INTO [dbo].[PaymentType] ([ShortName],[Description],[Active],[Creator],[Created]) VALUES('50X7','50% Anticipo. Resto a 7 días','A','admin',GETDATE());
INSERT INTO [dbo].[PaymentType] ([ShortName],[Description],[Active],[Creator],[Created]) VALUES('50X50','50% Anticipo, 50% Contra entrega','A','admin',GETDATE());
INSERT INTO [dbo].[PaymentType] ([ShortName],[Description],[Active],[Creator],[Created]) VALUES('CONVENIR','Pagos Progresivos a Convenir','A','admin',GETDATE());
INSERT INTO [dbo].[PaymentType] ([ShortName],[Description],[Active],[Creator],[Created]) VALUES('PLANEADO','Pagos Progresivos 20% Anticipo / 40% Contra aviso de embarque marítimo / 30% Contra llegada a Puerto Mexicano / 10% Contra entrega','A','admin',GETDATE());

SELECT * FROM [PaymentType];