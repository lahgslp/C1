DELETE FROM [dbo].[CurrencyType];

INSERT INTO [dbo].[CurrencyType]([CurrencyTypeID],[ShortName],[Description],[Active],[Creator],[Created])
     VALUES (1,'MXN','MN/Metro','A','admin',GETDATE());
INSERT INTO [dbo].[CurrencyType]([CurrencyTypeID],[ShortName],[Description],[Active],[Creator],[Created])
     VALUES (2,'USD','USD/Metro','A','admin',GETDATE());
INSERT INTO [dbo].[CurrencyType]([CurrencyTypeID],[ShortName],[Description],[Active],[Creator],[Created])
     VALUES (3,'MXNIVA','MN/Metro + IVA','A','admin',GETDATE());
INSERT INTO [dbo].[CurrencyType]([CurrencyTypeID],[ShortName],[Description],[Active],[Creator],[Created])
     VALUES (4,'USDIVA','USD/Metro + IVA','A','admin',GETDATE());
INSERT INTO [dbo].[CurrencyType]([CurrencyTypeID],[ShortName],[Description],[Active],[Creator],[Created])
     VALUES (5,'USDTONIVA','USD/Tonelada + IVA','A','admin',GETDATE());
INSERT INTO [dbo].[CurrencyType]([CurrencyTypeID],[ShortName],[Description],[Active],[Creator],[Created])
     VALUES (6,'USDTON','USD/Tonelada','A','admin',GETDATE());
INSERT INTO [dbo].[CurrencyType]([CurrencyTypeID],[ShortName],[Description],[Active],[Creator],[Created])
     VALUES (7,'MXNTONIVA','MN/Tonelada + IVA','A','admin',GETDATE());
INSERT INTO [dbo].[CurrencyType]([CurrencyTypeID],[ShortName],[Description],[Active],[Creator],[Created])
     VALUES (8,'MXNTON','MN/Tonelada','A','admin',GETDATE());
INSERT INTO [dbo].[CurrencyType]([CurrencyTypeID],[ShortName],[Description],[Active],[Creator],[Created])
     VALUES (9,'USDTRAIVA','USD/Tramo + IVA','A','admin',GETDATE());
INSERT INTO [dbo].[CurrencyType]([CurrencyTypeID],[ShortName],[Description],[Active],[Creator],[Created])
     VALUES (10,'USDTRA','USD/Tramo','A','admin',GETDATE());
INSERT INTO [dbo].[CurrencyType]([CurrencyTypeID],[ShortName],[Description],[Active],[Creator],[Created])
     VALUES (11,'MXNTRAIVA','MN/Tramo + IVA','A','admin',GETDATE());
INSERT INTO [dbo].[CurrencyType]([CurrencyTypeID],[ShortName],[Description],[Active],[Creator],[Created])
     VALUES (12,'MXNTRA','MN/Tramo','A','admin',GETDATE());

SELECT * FROM [dbo].[CurrencyType];
