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

GO

IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'FontName'
          AND Object_ID = Object_ID(N'dbo.Company'))
BEGIN
	ALTER TABLE [dbo].[Company] ADD [FontName] varchar(50);
END
GO

BEGIN TRANSACTION

/*OPTIONS, from https://websitesetup.org/web-safe-fonts-html-css/
Arial
Roboto
Times New Roman
Times
Courier New
Courier
Verdana
Georgia**
Palatino-
Garamond
Bookman
Comic Sans MS
Trebuchet MS**
Arial Black
Impact
*/

	UPDATE [dbo].[Company] SET [FontName] = 'Verdana' WHERE [CompanyID] = 1;
	UPDATE [dbo].[Company] SET [FontName] = 'Verdana' WHERE [CompanyID] = 2;
	UPDATE [dbo].[Company] SET [FontName] = 'Verdana' WHERE [CompanyID] = 3;

	DELETE [dbo].[ConfigurationKey] WHERE [ConfigurationKeyID] = 1;

COMMIT TRANSACTION
GO


/*

1){t}Cotizacion sujeta a confirmación de disponibilidad por previa venta y aceptación por parte del productor
{t}en caso de ser fabricación programada o entrega diferida.

2){t}En caso de recolección en nuestro Almacén, el transportista deberá comunicar el número/s de Orden de
{t}Carga otorgada por el ejecutivo de ventas para poder ingresar a patio. Caso contrario no se permitirá el
{t}acceso.

3){t}El Transporte deberá presentarse con suficientes barrotes de madera y eslingas de amarre para la segura
{t}estiba del material, caso contrario se repercutirá el costo de cada Polín a razón de 90 MN + IVA y
{t}Eslingas 500 MN + IVA.

*/