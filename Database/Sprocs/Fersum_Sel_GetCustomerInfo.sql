IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[dbo].[Fersum_Sel_GetCustomerInfo]') AND type in ('P'))
BEGIN
	DROP PROCEDURE [dbo].[Fersum_Sel_GetCustomerInfo]
END

GO

CREATE PROCEDURE [dbo].[Fersum_Sel_GetCustomerInfo]
AS
BEGIN

SELECT CustomerID, ShortName, Description, Creator, Created, Modifier, Modified, Active
FROM Customer;

SELECT CustomerContactID, CustomerID, ContactName, Email, Creator, Created, Modifier, Modified, Active
FROM CustomerContact;

END

GO
