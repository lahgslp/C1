DELETE FROM [ValidPeriodType];

DBCC CHECKIDENT ([ValidPeriodType], RESEED, 0);

INSERT INTO [dbo].[ValidPeriodType] ([ShortName],[Description],[Active],[Creator],[Created]) VALUES('DEFAULT','5 días hábiles a partir de esta fecha','A','admin',GETDATE());
INSERT INTO [dbo].[ValidPeriodType] ([ShortName],[Description],[Active],[Creator],[Created]) VALUES('3DIASH','3 días hábiles','A','admin',GETDATE());
INSERT INTO [dbo].[ValidPeriodType] ([ShortName],[Description],[Active],[Creator],[Created]) VALUES('7DIASH','5 días hábiles','A','admin',GETDATE());
INSERT INTO [dbo].[ValidPeriodType] ([ShortName],[Description],[Active],[Creator],[Created]) VALUES('7DIAS','7 días','A','admin',GETDATE());
INSERT INTO [dbo].[ValidPeriodType] ([ShortName],[Description],[Active],[Creator],[Created]) VALUES('20DIAS','20 días','A','admin',GETDATE());

SELECT * FROM [ValidPeriodType];