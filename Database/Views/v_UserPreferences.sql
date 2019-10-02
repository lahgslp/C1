IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[dbo].[v_UserPreferences]') AND type in ('V'))
BEGIN
	DROP VIEW [dbo].[v_UserPreferences]
END

GO

CREATE VIEW v_UserPreferences AS
SELECT
	U.UserID
	, U.ShortName
	, U.FullName
	, U.Active
	, UP.GreetingsMessage
	, UP.DefaultNotes
	, UP.DefaultFootNotes
	, C.CompanyID
	, C.CompanyName
	, C.CompanyFullName
	, C.CompanyCity
	, C.LogoFilePath
	, C.LogoSize
	, C.FontName
	, UCP.CC
	, UCP.Signature
	, UCP.EmailAddress
FROM [dbo].[User] U
	INNER JOIN UserPreferences UP ON U.UserID = UP.UserID
	INNER JOIN UserCompanyPreferences UCP ON UP.UserID = UCP.UserID
	INNER JOIN Company C ON UCP.CompanyID = C.CompanyID

GO
