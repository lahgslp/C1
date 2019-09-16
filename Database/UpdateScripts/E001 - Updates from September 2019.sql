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
