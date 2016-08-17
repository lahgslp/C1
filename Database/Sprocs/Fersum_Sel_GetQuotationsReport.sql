IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[dbo].[Fersum_Sel_GetQuotationsReport]') AND type in ('P'))
BEGIN
	DROP PROCEDURE [dbo].[Fersum_Sel_GetQuotationsReport]
END

GO

CREATE PROCEDURE [dbo].[Fersum_Sel_GetQuotationsReport]
(
	@DateFrom varchar(10),
	@DateTo varchar(10)
)
AS
BEGIN

SELECT
	Q.QuotationID
	, Q.Created
	, Comp.CompanyName
	, COALESCE(C.Description,'') AS CustomerName
	, COALESCE(CC.ContactName,'') AS ContactName
	, U.FullName AS Creator
	, COALESCE(QST.Description, '''') AS Status
	, ST.ShortName AS SectionType
	, QS.SectionDescription
	, PS.ShortName + '"' AS Diameter
	, CAST (PS.WallThicknessInches AS varchar(10)) +
		CASE WHEN (PS.PipeSchedule <> '') THEN ' (Cédula ' + PS.PipeSchedule +
			CASE WHEN (PS.PipeClass <> '') THEN ' ' + PS.PipeClass ELSE '' END
		+ ')' ELSE '' END
	AS Width
	, QSD.Weight
	, '' AS OpenField1
	, QSD.Quantity
	, UT.ShortName AS UnitType
	, QSD.Price
	, QSD.CurrencyDescription
	, QSD.DeliveryDescription
	, Q.PaymentDescription
	, QSD.DeliveryTimeDescription
	, Q.Notes
FROM Quotation Q
	INNER JOIN [dbo].[User] U ON Q.Creator = U.ShortName
	INNER JOIN Company Comp ON Q.CompanyID = Comp.CompanyID
	LEFT JOIN Customer C ON Q.CustomerID = C.CustomerID
	LEFT JOIN CustomerContact CC ON Q.CustomerContactID = CC.CustomerContactID
	LEFT JOIN QuotationStatusType QST ON Q.QuotationStatusTypeID = QST.QuotationStatusTypeID
	LEFT JOIN QuotationSection QS ON Q.QuotationID = QS.QuotationID
	LEFT JOIN SectionType ST ON QS.SectionTypeID = ST.SectionTypeID
	LEFT JOIN QuotationSectionDetail QSD ON QS.QuotationSectionID = QSD.QuotationSectionID
	LEFT JOIN v_PipeSpecification PS ON QSD.PipeSpecificationID = PS.PipeSpecificationID
	LEFT JOIN UnitType UT ON UT.UnitTypeID = QSD.UnitTypeID
WHERE Q.Active = 'A'
	AND Q.QuotationStatusTypeID IN (3,4,5,6)
	AND CONVERT(varchar(8), Q.Created, 112) >= @DateFrom
	AND CONVERT(varchar(8), Q.Created, 112) <= @DateTo
ORDER BY Q.QuotationID ASC;

END

GO
