IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[dbo].[Fersum_Upd_UserCompanyPreferences]') AND type in ('P'))
BEGIN
	DROP PROCEDURE [dbo].[Fersum_Upd_UserCompanyPreferences]
END

GO

CREATE PROCEDURE [dbo].[Fersum_Upd_UserCompanyPreferences]
(
	@UserID int,
	@CompanyID int,
	@CC varchar(100),
	@Signature varchar(1024),
	@EmailAddress varchar(100),
	@Modifier varchar(20)
)
AS
BEGIN
	UPDATE UserCompanyPreferences
	SET	CC = @CC
		, Signature = @Signature
		, EmailAddress = @EmailAddress
		, Modifier = @Modifier
		, Modified = GETDATE()
	WHERE  UserID = @UserID
		AND CompanyID = @CompanyID;
END

GO
