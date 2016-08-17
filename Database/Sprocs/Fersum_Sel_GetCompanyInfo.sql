IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[dbo].[Fersum_Sel_GetCompanyInfo]') AND type in ('P'))
BEGIN
	DROP PROCEDURE [dbo].[Fersum_Sel_GetCompanyInfo]
END

GO

CREATE PROCEDURE [dbo].[Fersum_Sel_GetCompanyInfo]
AS
BEGIN

SELECT CompanyID, CompanyName, CompanyFullName, Active
FROM Company;

END

GO
