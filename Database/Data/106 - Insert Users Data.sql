DELETE FROM [User];

DBCC CHECKIDENT ([User], RESEED, 0);

INSERT INTO [dbo].[User] ([ShortName],[Password],[FullName],[Active],[Creator],[Created]) VALUES('admin','admin','Administrador de Sistema de Cotizaciones','A','admin',GETUTCDATE());

SELECT * FROM [User];