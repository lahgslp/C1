IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[dbo].[Fersum_Sel_GetQuotationData]') AND type in ('P'))
BEGIN
	DROP PROCEDURE [dbo].[Fersum_Sel_GetQuotationData]
END

GO

CREATE PROCEDURE [dbo].[Fersum_Sel_GetQuotationData]
	@QuotationID int
AS
BEGIN

	SELECT Q.QuotationID,
		Q.CustomerID, COALESCE(C.Description,'') AS CustomerName,
		Q.CustomerContactID, COALESCE(CC.ContactName,'') AS ContactName,
		Q.EmailTo,
		Q.Notes,
		Q.ValidPeriodDescription,
		Q.PaymentDescription,
		U.FullName AS Creator,
		U.EmailAddress AS CreatorEmail,
		Q.Created,
		U.CC AS NotifyToEmail,
		Q.InvoiceMethodDescription,
		Q.CompanyID,
		Q.FootNoteDescription,
		U.CompanyName,
		U.CompanyFullName,
		U.CompanyCity,
		U.LogoFilePath,
		U.LogoSize,
		U.GreetingsMessage,
		U.Signature
		--,Q.*
	FROM Quotation Q
	INNER JOIN v_UserPreferences U ON Q.Creator = U.ShortName AND U.CompanyID = Q.CompanyID
	LEFT JOIN Customer C ON Q.CustomerID = C.CustomerID
	LEFT JOIN CustomerContact CC ON Q.CustomerContactID = CC.CustomerContactID
	WHERE QuotationID = @QuotationID;

	SELECT Q.QuotationID, QS.QuotationSectionID, QS.SectionTypeID, ST.ShortName,
		CASE WHEN QS.SectionDescription = '' THEN ST.Description
			ELSE QS.SectionDescription END AS Description
	FROM Quotation Q
		INNER JOIN QuotationSection QS ON Q.QuotationID = QS.QuotationID
		INNER JOIN SectionType ST ON QS.SectionTypeID = ST.SectionTypeID
	WHERE Q.QuotationID = @QuotationID
	ORDER BY ST.SectionTypeID;

	SELECT Q.QuotationID, QS.QuotationSectionID, QS.SectionTypeID,
		CONVERT(varchar(20),CONVERT(money, QSD.Quantity), 1) AS Quantity,
		UT.ShortName AS QuantityUnit,
		QSD.Weight,
		QSD.QuotationSectionDetailID, QSD.PipeSpecificationID, PS.ShortName + '"' AS ShortName,
		CAST(PS.ExternalDiameterInches AS varchar(10)) + '"' AS ExternalDiameterInches,
		CAST (PS.WallThicknessInches AS varchar(10)) +
			CASE WHEN (PS.PipeSchedule <> '') THEN ' (Cédula ' + PS.PipeSchedule +
				CASE WHEN (PS.PipeClass <> '') THEN ' ' + PS.PipeClass ELSE '' END
			+ ')' ELSE '' END
		AS Description,
		CAST (PS.KilogramsPerMeter AS numeric(38,3)) AS LinearWeight,
		'$ ' + CONVERT(varchar(20),CONVERT(money, Price), 1) AS Price,
		CASE WHEN (UT.ShortName = 'Tramos') THEN QSD.Weight
			ELSE CONVERT(varchar(20),Price * QSD.Quantity) END AS TotalPerConcept,
		QSD.CurrencyDescription,
		--PaymentDescription,
		DeliveryDescription
		,DeliveryTimeDescription
		--,ValidPeriodDescription
	FROM Quotation Q
		INNER JOIN QuotationSection QS ON Q.QuotationID = QS.QuotationID
		INNER JOIN QuotationSectionDetail QSD ON QS.QuotationSectionID = QSD.QuotationSectionID
		INNER JOIN dbo.v_PipeSpecification PS ON QSD.PipeSpecificationID = PS.PipeSpecificationID
		INNER JOIN UnitType UT ON QSD.UnitTypeID = UT.UnitTypeID
	WHERE Q.QuotationID = @QuotationID
	ORDER BY QS.SectionTypeID;

END

GO
