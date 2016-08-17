IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[dbo].[Fersum_Sel_GetMyQuotationsReferenceData]') AND type in ('P'))
BEGIN
	DROP PROCEDURE [dbo].[Fersum_Sel_GetMyQuotationsReferenceData]
END

GO

CREATE PROCEDURE [dbo].[Fersum_Sel_GetMyQuotationsReferenceData]
AS
BEGIN

SELECT (SELECT Value FROM ConfigurationKey WHERE Name = 'FakeUser') AS ShortName, 'Todos' AS FullName
UNION
SELECT
	--UserID,
	ShortName,
	FullName
FROM [dbo].[User]
WHERE ShortName <> (SELECT Value FROM ConfigurationKey WHERE Name = 'AdminUser');

SELECT
	SectionTypeID,
	ShortName
FROM SectionType;

SELECT
	CustomerID, Description
FROM Customer;

SELECT CustomerContactID, CustomerID, ContactName
FROM CustomerContact;

SELECT
	PipeDiameterTypeID,
	ShortName
FROM PipeDiameterType;

SELECT
	QuotationStatusTypeID,
	ShortName
FROM QuotationStatusType;

SELECT 0 AS CompanyID, 'Todas' AS CompanyName
UNION
SELECT CompanyID,
	CompanyName
FROM Company

END

GO
