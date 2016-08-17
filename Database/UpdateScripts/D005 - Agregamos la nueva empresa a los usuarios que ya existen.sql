INSERT INTO [dbo].[UserCompanyPreferences] (UserID, CompanyID, CC, Signature, EmailAddress, Active, Creator, Created) 
SELECT U.UserID, 3 AS CompanyID, '' AS CC, '' AS Signature, '' AS EmailAddress, 'A' AS Active, 'admin' AS Creator, GETDATE() AS Created
FROM [dbo].[User] U WHERE UserID > 1 