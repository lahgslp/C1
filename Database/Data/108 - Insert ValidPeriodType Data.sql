DELETE FROM [ValidPeriodType];

DBCC CHECKIDENT ([ValidPeriodType], RESEED, 0);

INSERT INTO [dbo].[ValidPeriodType] ([ShortName],[Description],[Active],[Creator],[Created]) VALUES('DEFAULT','5 d�as h�biles a partir de esta fecha','A','admin',GETDATE());
INSERT INTO [dbo].[ValidPeriodType] ([ShortName],[Description],[Active],[Creator],[Created]) VALUES('3DIASH','3 d�as h�biles','A','admin',GETDATE());
INSERT INTO [dbo].[ValidPeriodType] ([ShortName],[Description],[Active],[Creator],[Created]) VALUES('7DIASH','5 d�as h�biles','A','admin',GETDATE());
INSERT INTO [dbo].[ValidPeriodType] ([ShortName],[Description],[Active],[Creator],[Created]) VALUES('7DIAS','7 d�as','A','admin',GETDATE());
INSERT INTO [dbo].[ValidPeriodType] ([ShortName],[Description],[Active],[Creator],[Created]) VALUES('20DIAS','20 d�as','A','admin',GETDATE());

SELECT * FROM [ValidPeriodType];