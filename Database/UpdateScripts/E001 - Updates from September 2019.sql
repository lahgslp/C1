--Req #03 - Making notes bigger
IF COL_LENGTH('Quotation', 'Notes') = 1024
BEGIN
	ALTER TABLE [Quotation] ALTER COLUMN [Notes] VARCHAR (MAX) NULL;
	ALTER TABLE [Quotation] ALTER COLUMN [FootNoteDescription] VARCHAR (MAX) NULL;
END

IF COL_LENGTH('UserPreferences', 'DefaultNotes') = 1024
BEGIN
	ALTER TABLE [UserPreferences] ALTER COLUMN [DefaultNotes] VARCHAR (MAX) NULL;
	ALTER TABLE [UserPreferences] ALTER COLUMN [DefaultFootNotes] VARCHAR (MAX) NULL;
	ALTER TABLE [UserPreferences] ALTER COLUMN [GreetingsMessage] VARCHAR (MAX) NULL;
END

--Multiple emails
IF COL_LENGTH('CustomerContact', 'Email') = 50
BEGIN
	ALTER TABLE [CustomerContact] ALTER COLUMN [Email] VARCHAR (500) NULL;
END

IF COL_LENGTH('Quotation', 'EmailTo') = 50
BEGIN
	ALTER TABLE [Quotation] ALTER COLUMN [EmailTo] VARCHAR (500) NULL;
END
IF COL_LENGTH('UserCompanyPreferences', 'CC') = 100
BEGIN
	ALTER TABLE [UserCompanyPreferences] ALTER COLUMN [CC] VARCHAR (500) NULL;
END

--Update Logo for AYANTE
BEGIN TRANSACTION
	UPDATE Company
	SET LogoFilePath = 'AYANTE logo.png'
	WHERE CompanyID = 2;
COMMIT TRANSACTION
