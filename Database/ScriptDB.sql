USE [FersumDev01]
GO
/****** Object:  Table [dbo].[PipeDiameterType]    Script Date: 12/21/2010 12:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PipeDiameterType](
	[PipeDiameterTypeID] [int] IDENTITY(1,1) NOT NULL,
	[ShortName] [varchar](20) NOT NULL,
	[Description] [varchar](100) NOT NULL,
	[ExternalDiameterInches] [numeric](18, 3) NOT NULL,
	[Active] [char](1) NOT NULL,
	[Creator] [varchar](20) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](20) NULL,
	[Modified] [datetime] NULL,
 CONSTRAINT [PK_ProductDiameterType] PRIMARY KEY CLUSTERED 
(
	[PipeDiameterTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[QuotationStatusType]    Script Date: 12/21/2010 12:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[QuotationStatusType](
	[QuotationStatustypeID] [int] IDENTITY(1,1) NOT NULL,
	[ShortName] [varchar](20) NOT NULL,
	[Description] [varchar](100) NOT NULL,
	[Active] [char](1) NOT NULL,
	[Creator] [varchar](20) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](20) NULL,
	[Modified] [datetime] NULL,
 CONSTRAINT [PK_QuotationStatusType] PRIMARY KEY CLUSTERED 
(
	[QuotationStatustypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SectionType]    Script Date: 12/21/2010 12:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SectionType](
	[SectionTypeID] [int] IDENTITY(1,1) NOT NULL,
	[ShortName] [varchar](20) NOT NULL,
	[Description] [varchar](1024) NOT NULL,
	[Active] [char](1) NOT NULL,
	[Creator] [varchar](20) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](20) NULL,
	[Modified] [datetime] NULL,
 CONSTRAINT [PK_TemplateSectionType] PRIMARY KEY CLUSTERED 
(
	[SectionTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UnitType]    Script Date: 12/21/2010 12:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UnitType](
	[UnitTypeID] [int] IDENTITY(1,1) NOT NULL,
	[ShortName] [varchar](20) NOT NULL,
	[Description] [varchar](100) NULL,
	[Active] [char](1) NOT NULL,
	[Creator] [varchar](20) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](20) NULL,
	[Modified] [datetime] NULL,
 CONSTRAINT [PK_UnitType] PRIMARY KEY CLUSTERED 
(
	[UnitTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User]    Script Date: 12/21/2010 12:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[ShortName] [varchar](20) NOT NULL,
	[Password] [varchar](20) NOT NULL,
	[FullName] [varchar](100) NOT NULL,
	[Active] [char](1) NOT NULL,
	[Creator] [varchar](20) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](20) NULL,
	[Modified] [datetime] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DeliveryTimeType]    Script Date: 12/21/2010 12:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DeliveryTimeType](
	[DeliveryTimeTypeID] [int] IDENTITY(1,1) NOT NULL,
	[ShortName] [varchar](20) NOT NULL,
	[Description] [varchar](256) NOT NULL,
	[Active] [char](1) NOT NULL,
	[Creator] [varchar](20) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](20) NULL,
	[Modified] [datetime] NULL,
 CONSTRAINT [PK_DeliveryTimeType] PRIMARY KEY CLUSTERED 
(
	[DeliveryTimeTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[InvoiceMethodType]    Script Date: 12/21/2010 12:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[InvoiceMethodType](
	[InvoiceMethodTypeID] [int] IDENTITY(1,1) NOT NULL,
	[ShortName] [varchar](20) NOT NULL,
	[Description] [varchar](256) NOT NULL,
	[Active] [char](1) NOT NULL,
	[Creator] [varchar](20) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](20) NULL,
	[Modified] [datetime] NULL,
 CONSTRAINT [PK_InvoiceMethodType] PRIMARY KEY CLUSTERED 
(
	[InvoiceMethodTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 12/21/2010 12:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[ShortName] [varchar](20) NULL,
	[Description] [varchar](100) NOT NULL,
	[Active] [char](1) NOT NULL,
	[Creator] [varchar](20) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](20) NULL,
	[Modified] [datetime] NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ValidPeriodType]    Script Date: 12/21/2010 12:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ValidPeriodType](
	[ValidPeriodTypeID] [int] IDENTITY(1,1) NOT NULL,
	[ShortName] [varchar](20) NOT NULL,
	[Description] [varchar](256) NOT NULL,
	[Active] [char](1) NOT NULL,
	[Creator] [varchar](20) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](20) NULL,
	[Modified] [datetime] NULL,
 CONSTRAINT [PK_ValidPeriodType] PRIMARY KEY CLUSTERED 
(
	[ValidPeriodTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Company]    Script Date: 12/21/2010 12:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Company](
	[CompanyID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [varchar](20) NOT NULL,
	[CompanyFullName] [varchar](100) NOT NULL,
	[CompanyCity] [varchar](100) NOT NULL,
	[LogoFilePath] [varchar](100) NOT NULL,
	[Active] [char](1) NOT NULL,
	[Creator] [varchar](20) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](20) NULL,
	[Modified] [datetime] NULL,
	[LogoSize] [varchar](20) NULL,
 CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED 
(
	[CompanyID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[Fersum_Del_RemoveQuotationSectionDetailByQuotationSectionDetailID]    Script Date: 12/21/2010 12:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Fersum_Del_RemoveQuotationSectionDetailByQuotationSectionDetailID]
	@QuotationID int,
	@QuotationSectionDetailID int
AS
BEGIN

--This is to remove the QuotationSectionDetail
DELETE FROM QuotationSectionDetail
	WHERE QuotationSectionDetailID = @QuotationSectionDetailID;
/*
IF NOT EXISTS( SELECT 1 FROM QuotationSection QS INNER JOIN QuotationSectionDetail QSD ON QS.QuotationSectionID = QSD.QuotationSectionID WHERE QS.QuotationSectionID = @QuotationSectionID)
BEGIN
	--This is to remove the QuotationSection if no more details exist
	DELETE FROM QuotationSection
		WHERE QuotationSectionID = @QuotationSectionID
END
*/
END
GO
/****** Object:  Table [dbo].[ConfigurationKey]    Script Date: 12/21/2010 12:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ConfigurationKey](
	[ConfigurationKeyID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Value] [varchar](256) NOT NULL,
	[Active] [char](1) NOT NULL,
	[Creator] [varchar](20) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](20) NULL,
	[Modified] [datetime] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CurrencyType]    Script Date: 12/21/2010 12:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CurrencyType](
	[CurrencyTypeID] [int] NOT NULL,
	[ShortName] [varchar](20) NOT NULL,
	[Description] [varchar](100) NOT NULL,
	[Active] [char](1) NOT NULL,
	[Creator] [varchar](20) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](20) NULL,
	[Modified] [datetime] NULL,
 CONSTRAINT [PK_CurrencyType] PRIMARY KEY CLUSTERED 
(
	[CurrencyTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DeliveryType]    Script Date: 12/21/2010 12:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DeliveryType](
	[DeliveryTypeID] [int] IDENTITY(1,1) NOT NULL,
	[ShortName] [varchar](20) NOT NULL,
	[Description] [varchar](256) NOT NULL,
	[Active] [char](1) NOT NULL,
	[Creator] [varchar](20) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](20) NULL,
	[Modified] [datetime] NULL,
 CONSTRAINT [PK_DeliveryType] PRIMARY KEY CLUSTERED 
(
	[DeliveryTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PaymentType]    Script Date: 12/21/2010 12:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PaymentType](
	[PaymentTypeID] [int] IDENTITY(1,1) NOT NULL,
	[ShortName] [varchar](20) NOT NULL,
	[Description] [varchar](256) NOT NULL,
	[Active] [char](1) NOT NULL,
	[Creator] [varchar](20) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](20) NULL,
	[Modified] [datetime] NULL,
 CONSTRAINT [PK_PaymentType] PRIMARY KEY CLUSTERED 
(
	[PaymentTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PipeSpecification]    Script Date: 12/21/2010 12:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PipeSpecification](
	[PipeSpecificationID] [int] IDENTITY(1,1) NOT NULL,
	[WallThicknessInches] [numeric](18, 3) NOT NULL,
	[PipeSchedule] [varchar](10) NOT NULL,
	[PipeClass] [varchar](10) NOT NULL,
	[PipeDiameterTypeID] [int] NOT NULL,
	[Active] [char](1) NOT NULL,
	[Creator] [varchar](20) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](20) NULL,
	[Modified] [datetime] NULL,
 CONSTRAINT [PK_ProductSpecification] PRIMARY KEY CLUSTERED 
(
	[PipeSpecificationID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Quotation]    Script Date: 12/21/2010 12:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Quotation](
	[QuotationID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NULL,
	[CustomerContactID] [int] NULL,
	[EmailTo] [varchar](50) NULL,
	[ClonedFromQuotationID] [int] NULL,
	[ValidPeriodDescription] [varchar](50) NULL,
	[PaymentDescription] [varchar](256) NULL,
	[Notes] [varchar](1024) NULL,
	[QuotationStatusTypeID] [int] NOT NULL CONSTRAINT [DF_Quotation_QuotationStatusTypeID]  DEFAULT ((1)),
	[Active] [char](1) NOT NULL,
	[Creator] [varchar](20) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](20) NULL,
	[Modified] [datetime] NULL,
	[InvoiceMethodDescription] [varchar](256) NULL CONSTRAINT [DF__Quotation__Invoi__1DE57479]  DEFAULT (''),
	[CompanyID] [int] NULL,
	[FootNoteDescription] [varchar](1024) NULL,
 CONSTRAINT [PK_Quotation] PRIMARY KEY CLUSTERED 
(
	[QuotationID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[QuotationSection]    Script Date: 12/21/2010 12:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[QuotationSection](
	[QuotationSectionID] [int] IDENTITY(1,1) NOT NULL,
	[QuotationID] [int] NOT NULL,
	[SectionTypeID] [int] NOT NULL,
	[Active] [char](1) NOT NULL,
	[Creator] [varchar](20) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](20) NULL,
	[Modified] [datetime] NULL,
	[SectionDescription] [varchar](512) NOT NULL DEFAULT (''),
 CONSTRAINT [PK_QuotationSection_1] PRIMARY KEY CLUSTERED 
(
	[QuotationSectionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[QuotationSectionDetail]    Script Date: 12/21/2010 12:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[QuotationSectionDetail](
	[QuotationSectionDetailID] [int] IDENTITY(1,1) NOT NULL,
	[QuotationSectionID] [int] NOT NULL,
	[Quantity] [numeric](18, 2) NOT NULL,
	[Price] [numeric](18, 2) NOT NULL CONSTRAINT [DF_QuotationSectionDetail_Price]  DEFAULT ((0)),
	[DeliveryDescription] [varchar](256) NOT NULL CONSTRAINT [DF_QuotationSectionDetail_DeliveryDescription]  DEFAULT (''),
	[DeliveryTimeDescription] [varchar](256) NOT NULL,
	[CurrencyDescription] [varchar](50) NOT NULL CONSTRAINT [DF_QuotationSectionDetail_CurrencyDescription]  DEFAULT (''),
	[UnitTypeID] [int] NOT NULL,
	[Active] [char](1) NOT NULL,
	[Creator] [varchar](20) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](20) NULL,
	[Modified] [datetime] NULL,
	[PipeSpecificationID] [int] NOT NULL,
	[Weight] [varchar](20) NOT NULL,
 CONSTRAINT [PK_QuotationSectionDetail] PRIMARY KEY CLUSTERED 
(
	[QuotationSectionDetailID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserPreferences]    Script Date: 12/21/2010 12:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserPreferences](
	[UserID] [int] NOT NULL,
	[GreetingsMessage] [varchar](1024) NULL,
	[DefaultNotes] [varchar](1024) NULL,
	[Active] [char](1) NOT NULL,
	[Creator] [varchar](20) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](20) NULL,
	[Modified] [datetime] NULL,
	[DefaultFootNotes] [varchar](1024) NULL,
	[DefaultCompanyID] [int] NULL,
 CONSTRAINT [PK_UserPreferences] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserCompanyPreferences]    Script Date: 12/21/2010 12:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserCompanyPreferences](
	[UserID] [int] NOT NULL,
	[CompanyID] [int] NOT NULL,
	[CC] [varchar](100) NULL,
	[Signature] [varchar](1024) NULL,
	[EmailAddress] [varchar](100) NULL,
	[Active] [char](1) NOT NULL,
	[Creator] [varchar](20) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](20) NULL,
	[Modified] [datetime] NULL,
 CONSTRAINT [PK_UserCompanyPreferences] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC,
	[CompanyID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CustomerContact]    Script Date: 12/21/2010 12:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CustomerContact](
	[CustomerContactID] [int] IDENTITY(1,1) NOT NULL,
	[ContactName] [varchar](100) NOT NULL,
	[Email] [varchar](50) NULL,
	[CustomerID] [int] NOT NULL,
	[Active] [char](1) NOT NULL,
	[Creator] [varchar](20) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](20) NULL,
	[Modified] [datetime] NULL,
 CONSTRAINT [PK_CustomerContact] PRIMARY KEY CLUSTERED 
(
	[CustomerContactID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[QuotationAttachment]    Script Date: 12/21/2010 12:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[QuotationAttachment](
	[QuotationAttachmentID] [int] IDENTITY(1,1) NOT NULL,
	[QuotationID] [int] NOT NULL,
	[ExternalFileName] [varchar](256) NOT NULL,
	[Active] [char](1) NOT NULL,
	[Creator] [varchar](20) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](20) NULL,
	[Modified] [datetime] NULL,
	[QuotationFileIndicator] [char](1) NULL,
 CONSTRAINT [PK_QuotationAttachment] PRIMARY KEY CLUSTERED 
(
	[QuotationAttachmentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[Fersum_Sel_GetMyQuotationsReferenceData]    Script Date: 12/21/2010 12:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Fersum_Sel_GetMyQuotationsReferenceData]
AS
BEGIN

SELECT '_a_a_a_' AS ShortName, 'Todos' AS FullName
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
/****** Object:  View [dbo].[v_PipeSpecification]    Script Date: 12/21/2010 12:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[v_PipeSpecification] AS
SELECT
	PS.PipeSpecificationID
	, PDT.PipeDiameterTypeID
	, PDT.ShortName
	, PDT.ExternalDiameterInches
	, ROUND(PDT.ExternalDiameterInches * 25.4, 1) AS ExternalDiameterMillimeters
	, PS.WallThicknessInches
	, ROUND(PS.WallThicknessInches * 25.4, 2) AS WallThicknessMillimeters
	, PS.PipeSchedule
	, PS.PipeClass
	, ROUND((((PDT.ExternalDiameterInches * 25.4) - (PS.WallThicknessInches * 25.4)) * (PS.WallThicknessInches * 25.4) * 0.02466) * 0.67733, 2) AS PoundsPerFeet
	, ROUND(((PDT.ExternalDiameterInches * 25.4) - (PS.WallThicknessInches * 25.4)) * (PS.WallThicknessInches * 25.4) * 0.02466, 2) AS KilogramsPerMeter
	FROM PipeSpecification PS INNER JOIN PipeDiameterType PDT ON PS.PipeDiameterTypeID = PDT.PipeDiameterTypeID;
GO
/****** Object:  UserDefinedFunction [dbo].[Fersum_fn_IsPipeDiameterIncludedInQuotationID]    Script Date: 12/21/2010 12:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[Fersum_fn_IsPipeDiameterIncludedInQuotationID]
(
	@QuotationID int,
	@PipeDiameterTypeID int
)
RETURNS int
AS 
BEGIN
	DECLARE @ReturnValue int;

	SET @ReturnValue = 0;

	IF EXISTS (
		SELECT 1
		FROM Quotation Q
			INNER JOIN QuotationSection QS ON Q.QuotationID = QS.QuotationID AND Q.QuotationID = @QuotationID
			INNER JOIN QuotationSectionDetail QSD ON QS.QuotationSectionID = QSD.QuotationSectionID
			INNER JOIN PipeSpecification PS ON QSD.PipeSpecificationID = PS.PipeSpecificationID AND PS.PipeDiameterTypeID = @PipeDiameterTypeID
		)
	BEGIN
		SET @ReturnValue = 1;
	END

	RETURN @ReturnValue;
END;
GO
/****** Object:  UserDefinedFunction [dbo].[Fersum_fn_GetSectionNameByQuotationID]    Script Date: 12/21/2010 12:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[Fersum_fn_GetSectionNameByQuotationID]
(
	@QuotationID int
)
RETURNS varchar(20)
AS 
BEGIN
	DECLARE @SectionName varchar(20);
	DECLARE @SectionCount int;

	SET @SectionName = '';
	SELECT @SectionCount = COUNT(*) FROM QuotationSection QS WHERE QS.QuotationID = @QuotationID;

	IF @SectionCount = 1
	BEGIN
		SELECT @SectionName = ST.ShortName
		FROM Quotation Q
			INNER JOIN QuotationSection QS ON Q.QuotationID = QS.QuotationID
			INNER JOIN SectionType ST ON QS.SectionTypeID = ST.SectionTypeID
		WHERE Q.QuotationID = @QuotationID;
	END
	ELSE IF @SectionCount > 1
	BEGIN
		SET @SectionName = 'Varias';
	END

	RETURN @SectionName;
END;
GO
/****** Object:  View [dbo].[v_UserPreferences]    Script Date: 12/21/2010 12:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[v_UserPreferences] AS
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
	, UCP.CC
	, UCP.Signature
	, UCP.EmailAddress
FROM [dbo].[User] U
	INNER JOIN UserPreferences UP ON U.UserID = UP.UserID
	INNER JOIN UserCompanyPreferences UCP ON UP.UserID = UCP.UserID
	INNER JOIN Company C ON UCP.CompanyID = C.CompanyID
GO
/****** Object:  StoredProcedure [dbo].[Fersum_Upd_UserCompanyPreferences]    Script Date: 12/21/2010 12:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  StoredProcedure [dbo].[Fersum_Sel_GetQuotationFinishReferenceData]    Script Date: 12/21/2010 12:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Fersum_Sel_GetQuotationFinishReferenceData]
AS
BEGIN
	SELECT Description FROM ValidPeriodType;
	SELECT Description FROM PaymentType;
	SELECT Description FROM InvoiceMethodType;
END
GO
/****** Object:  StoredProcedure [dbo].[Fersum_Sel_GetQuotationConditionsReferenceData]    Script Date: 12/21/2010 12:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Fersum_Sel_GetQuotationConditionsReferenceData]
AS
BEGIN
	SELECT Description FROM DeliveryType;
	SELECT Description FROM DeliveryTimeType;
	SELECT Description FROM CurrencyType;
	--SELECT Description FROM ValidPeriodType;
END
GO
/****** Object:  StoredProcedure [dbo].[Fersum_Sel_GetCustomerInfo]    Script Date: 12/21/2010 12:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Fersum_Sel_GetCustomerInfo]
AS
BEGIN

SELECT CustomerID, ShortName, Description, Active
FROM Customer;

SELECT CustomerContactID, CustomerID, ContactName, Email, Active
FROM CustomerContact;

END
GO
/****** Object:  StoredProcedure [dbo].[Fersum_Sel_GetQuotationSectionID]    Script Date: 12/21/2010 12:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Fersum_Sel_GetQuotationSectionID]
	@QuotationID int,
	@SectionTypeID int
AS
BEGIN

DECLARE @QuotationSectionID int;

SELECT @QuotationSectionID = QS.QuotationSectionID FROM QuotationSection QS WHERE QS.QuotationID = @QuotationID AND QS.SectionTypeID = @SectionTypeID;

IF @QuotationSectionID IS NULL
BEGIN
	SET @QuotationSectionID = 0
END

SELECT @QuotationSectionID;

END
GO
/****** Object:  StoredProcedure [dbo].[Fersum_Del_RemoveFloatingQuotationSectionsByQuotationID]    Script Date: 12/21/2010 12:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Fersum_Del_RemoveFloatingQuotationSectionsByQuotationID]
	@QuotationID int
AS
BEGIN

--This is to remove the QuotationSection if no more details exist
DELETE FROM QuotationSection
	WHERE QuotationID = @QuotationID AND QuotationSectionID NOT IN (
		SELECT QS.QuotationSectionID
		FROM QuotationSection QS
			INNER JOIN QuotationSectionDetail QSD ON QS.QuotationSectionID = QSD.QuotationSectionID
		WHERE QS.QuotationID = @QuotationID
		)

END
GO
/****** Object:  UserDefinedFunction [dbo].[Fersum_fn_IsSectionIncludedInQuotationID]    Script Date: 12/21/2010 12:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[Fersum_fn_IsSectionIncludedInQuotationID]
(
	@QuotationID int,
	@SectionTypeID int
)
RETURNS int
AS 
BEGIN
	DECLARE @ReturnValue int;

	SET @ReturnValue = 0;

	IF EXISTS (
		SELECT 1
		FROM Quotation Q
			INNER JOIN QuotationSection QS ON Q.QuotationID = QS.QuotationID
		WHERE Q.QuotationID = @QuotationID AND QS.SectionTypeID = @SectionTypeID
		)
	BEGIN
		SET @ReturnValue = 1;
	END

	RETURN @ReturnValue;
END;
GO
/****** Object:  StoredProcedure [dbo].[Fersum_Del_RemoveQuotationSectionDetailByQuotationID]    Script Date: 12/21/2010 12:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Fersum_Del_RemoveQuotationSectionDetailByQuotationID]
	@QuotationID int,
	@QuotationSectionDetailID int
AS
BEGIN

--This is to remove the QuotationSectionDetail
DELETE FROM QuotationSectionDetail
	WHERE QuotationSectionDetailID = @QuotationSectionDetailID;

--This is to remove the QuotationSection if no details exist
DELETE FROM QuotationSection
	WHERE QuotationSectionID NOT IN (
			SELECT QS.QuotationSectionID
			FROM QuotationSection QS INNER JOIN Quotation Q ON QS.QuotationID = Q.QuotationID
				INNER JOIN QuotationSectionDetail QSD ON QS.QuotationSectionID = QSD.QuotationSectionID
			WHERE Q.QuotationID = @QuotationID
		)
		AND QuotationID = @QuotationID;
END
GO
/****** Object:  StoredProcedure [dbo].[Fersum_Ins_CloneQuotation]    Script Date: 12/21/2010 12:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Fersum_Ins_CloneQuotation]
(
	@QuotationID int,
	@User varchar(20)
)
AS 
BEGIN

	/*DECLARE @User varchar(20);
	DECLARE @QuotationID int;
	SET @QuotationID = 309;
	SET @User = 'cdelapaz';*/

BEGIN TRANSACTION

DECLARE @NewQuotationID int;

DECLARE @QuotationSection TABLE
(
	OldQuotationSectionID int,
	NewQuotationSectionID int,
	SectionTypeID int
);

	INSERT INTO [dbo].[Quotation]
		([CompanyID], [CustomerID], [CustomerContactID], [EmailTo], [ClonedFromQuotationID], [QuotationStatusTypeID], [ValidPeriodDescription], [PaymentDescription], [Notes], [Active], [Creator], [Created], [InvoiceMethodDescription], [FootNoteDescription])
	SELECT Q.CompanyID, Q.CustomerID , Q.CustomerContactID, Q.EmailTo,@QuotationID, 1, Q.ValidPeriodDescription, Q.PaymentDescription, Q.Notes, 'A', @User, GETDATE(), InvoiceMethodDescription, FootNoteDescription
	FROM Quotation Q WHERE Q.QuotationID = @QuotationID;

	SET @NewQuotationID = @@IDENTITY;

	INSERT INTO @QuotationSection
		(OldQuotationSectionID, SectionTypeID)
	SELECT QS.QuotationSectionID, QS.SectionTypeID FROM QuotationSection QS WHERE QS.QuotationID = @QuotationID;


	INSERT INTO [dbo].[QuotationSection]
		([QuotationID] ,[SectionTypeID] ,[Active] ,[Creator] ,[Created], [SectionDescription])
	SELECT @NewQuotationID, QS.SectionTypeID, 'A', @User, GETDATE(), QS.SectionDescription
	FROM QuotationSection QS WHERE QS.QuotationID = @QuotationID;

	UPDATE @QuotationSection
	SET NewQuotationSectionID = QS.QuotationSectionID
	FROM @QuotationSection QST INNER JOIN QuotationSection QS ON QST.SectionTypeID = QS.SectionTypeID
	WHERE QS.QuotationID = @NewQuotationID;

	INSERT INTO .[dbo].[QuotationSectionDetail]
		([QuotationSectionID], [PipeSpecificationID], [Quantity], [Price], [DeliveryDescription],
			[DeliveryTimeDescription],
			--[PaymentDescription],
			[CurrencyDescription],
			--[ValidPeriodDescription],
			[UnitTypeID], [Weight], [Active], [Creator], [Created])
	SELECT
		QST.NewQuotationSectionID
		, QSD.PipeSpecificationID
		, QSD.Quantity
		, QSD.Price
		, QSD.DeliveryDescription
		, QSD.DeliveryTimeDescription
		--, QSD.PaymentDescription
		, QSD.CurrencyDescription
		--, QSD.ValidPeriodDescription
		, QSD.UnitTypeID
		, QSD.Weight
		,'A'
		,@User
		,GETDATE()
	FROM QuotationSection QS
		INNER JOIN QuotationSectionDetail QSD ON QS.QuotationSectionID = QSD.QuotationSectionID
		INNER JOIN @QuotationSection QST ON QS.QuotationSectionID = QST.OldQuotationSectionID
	WHERE QS.QuotationID = @QuotationID;

	--TEST QUERIES:
	--SELECT @NewQuotationID;
	--SELECT * FROM Quotation WHERE QuotationID = @NewQuotationID;
	--SELECT * FROM QuotationSection WHERE QuotationID = @NewQuotationID;
	--SELECT * FROM QuotationSectionDetail WHERE QuotationSectionID IN (SELECT QuotationSectionID FROM QuotationSection WHERE QuotationID = @NewQuotationID)
	--SELECT * FROM @QuotationSection;
	--ROLLBACK TRANSACTION;
	
COMMIT TRANSACTION;

SELECT @NewQuotationID;

END;
GO
/****** Object:  StoredProcedure [dbo].[Fersum_Sel_GetCompanyInfo]    Script Date: 12/21/2010 12:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Fersum_Sel_GetCompanyInfo]
AS
BEGIN

SELECT CompanyID, CompanyName, CompanyFullName, Active
FROM Company;

END
GO
/****** Object:  StoredProcedure [dbo].[Fersum_Sel_GetMyQuotations]    Script Date: 12/21/2010 12:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Fersum_Sel_GetMyQuotations]
(
	@Creator varchar(20),
	@DateFrom varchar(10),
	@DateTo varchar(10),
	@SectionTypeID int,
	@PipeDiameterTypeID int,
	@QuotationID int,
	@CustomerID int,
	@CustomerContactID int,
	@QuotationStatusTypeID int,
	@CompanyID int
)
AS
BEGIN
DECLARE @SQLSelect varchar(2000);
DECLARE @SQLFrom varchar(2000);
DECLARE @SQLWhere varchar(2000);
DECLARE @SQLOrderBy varchar(2000);
DECLARE @SQLStatement varchar(8000);

SET @SQLSelect =
'
SELECT
	TOP 300
	Q.QuotationID,
	Comp.CompanyName,
	COALESCE(C.Description,'''') AS CustomerName,
	COALESCE(CC.ContactName,'''') AS ContactName,
	COALESCE(Q.EmailTo,'''') AS Email,
	dbo.Fersum_fn_GetSectionNameByQuotationID(Q.QuotationID) AS Sections,
	Q.Created,
	U.FullName AS Creator,
	Q.QuotationStatusTypeID,
	COALESCE(QST.Description, '''') AS Status
	--, COALESCE(PDFFileName,'''') AS QuotationFileName
';

SET @SQLFrom =
'
	FROM Quotation Q
	INNER JOIN [dbo].[User] U ON Q.Creator = U.ShortName
	INNER JOIN Company Comp ON Q.CompanyID = Comp.CompanyID
	LEFT JOIN Customer C ON Q.CustomerID = C.CustomerID
	LEFT JOIN CustomerContact CC ON Q.CustomerContactID = CC.CustomerContactID
	LEFT JOIN QuotationStatusType QST ON Q.QuotationStatusTypeID = QST.QuotationStatusTypeID
';

SET @SQLWhere = 'WHERE Q.Active = ''A'' ';

SET @SQLOrderBy = 'ORDER BY Q.QuotationID DESC ';

--Check if any parameters are not null
IF	@Creator <> '' OR
	@DateFrom <> '' OR
	@DateTo <> '' OR
	@SectionTypeID <> 0 OR
	@PipeDiameterTypeID <> 0 OR
	@QuotationID <> 0 OR
	@CustomerID <> 0 OR
	@CustomerContactID <> 0 OR
	@QuotationStatusTypeID <> 0
BEGIN

	SET @SQLWhere = @SQLWhere + ' AND ';

	IF @Creator <> (SELECT Value FROM ConfigurationKey WHERE Name = 'FakeUser')
	BEGIN
		SET @SQLWhere = @SQLWhere + ' Q.Creator = ''' + @Creator + ''' AND ';
	END

	IF @DateFrom <> ''
	BEGIN
		SET @SQLWhere = @SQLWhere + ' CONVERT(varchar(8), Q.Created, 112) >= ''' + @DateFrom + ''' AND ';
	END

	IF @DateTo <> ''
	BEGIN
		SET @SQLWhere = @SQLWhere + ' CONVERT(varchar(8), Q.Created, 112) <= ''' + @DateTo + ''' AND ';
	END

	--TO CHECK
	IF @SectionTypeID <> 0
	BEGIN
		SET @SQLWhere = @SQLWhere + ' dbo.Fersum_fn_IsSectionIncludedInQuotationID(Q.QuotationID, ' + CAST(@SectionTypeID AS varchar(5)) + ') = 1 AND ';
	END

	--TO CHECK
	IF @PipeDiameterTypeID <> 0
	BEGIN
		SET @SQLWhere = @SQLWhere + ' dbo.Fersum_fn_IsPipeDiameterIncludedInQuotationID(Q.QuotationID, ' + CAST(@PipeDiameterTypeID AS varchar(5)) + ') = 1 AND ';
	END

	IF @QuotationID <> 0
	BEGIN
		SET @SQLWhere = @SQLWhere + ' Q.QuotationID = ' + CAST(@QuotationID AS varchar(10)) + ' AND ';
	END

	IF @CustomerID <> 0
	BEGIN
		SET @SQLWhere = @SQLWhere + ' Q.CustomerID = ' + CAST(@CustomerID AS varchar(10)) + ' AND ';
	END

	IF @CustomerContactID <> 0
	BEGIN
		SET @SQLWhere = @SQLWhere + ' Q.CustomerContactID = ' + CAST(@CustomerContactID AS varchar(10)) + ' AND ';
	END

	IF @QuotationStatusTypeID <> 0
	BEGIN
		SET @SQLWhere = @SQLWhere + ' Q.QuotationStatusTypeID = ' + CAST(@QuotationStatusTypeID AS varchar(10)) + ' AND ';
	END

	IF @CompanyID <> 0
	BEGIN
		SET @SQLWhere = @SQLWhere + ' Comp.CompanyID = ' + CAST(@CompanyID AS varchar(10)) + ' AND ';
	END

	SET @SQLWhere = SUBSTRING(@SQLWhere, 1, LEN(@SQLWhere) - 4);
END

SET @SQLStatement = @SQLSelect + @SQLFrom + @SQLWhere + @SQLOrderBy;


EXECUTE(@SQLStatement);

--SELECT @SQLStatement;	--REMOVE

END
GO
/****** Object:  StoredProcedure [dbo].[Fersum_Sel_GetProductSpecs]    Script Date: 12/21/2010 12:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Fersum_Sel_GetProductSpecs]
AS
BEGIN

/*SELECT DISTINCT PipeDiameterTypeID, ShortName, ExternalDiameterInches, ExternalDiameterMillimeters
FROM v_PipeSpecification
ORDER BY PipeDiameterTypeID;*/
SELECT ShortName FROM PipeDiameterType;

/*SELECT PipeDiameterTypeID, PipeSpecificationID,
	CAST (WallThicknessInches AS varchar(10)) +
	CASE WHEN (PipeSchedule <> '') THEN ' (Cédula ' + PipeSchedule +
			CASE WHEN (PipeClass <> '') THEN ' ' + PipeClass ELSE '' END
		+ ')' ELSE '' END
	AS Description
FROM PipeSpecification
WHERE Active = 'A'
ORDER BY PipeDiameterTypeID;*/
SELECT PDT.ShortName, CAST (PS.WallThicknessInches AS varchar(10)) +
	CASE WHEN (PipeSchedule <> '' AND PipeClass <> '') THEN ' (Cédula ' + PipeSchedule + ' ' + PipeClass + ')'
		WHEN (PipeSchedule <> '') THEN ' (Cédula ' + PipeSchedule + ')'
		WHEN (PipeClass <> '') THEN ' (' + PipeClass + ')'
		ELSE ''
	END
	AS Description FROM PipeDiameterType PDT INNER JOIN PipeSpecification PS ON PDT.PipeDiameterTypeID = PS.PipeDiameterTypeID

SELECT *, CAST (WallThicknessInches AS varchar(10)) +
	CASE WHEN (PipeSchedule <> '' AND PipeClass <> '') THEN ' (Cédula ' + PipeSchedule + ' ' + PipeClass + ')'
		WHEN (PipeSchedule <> '') THEN ' (Cédula ' + PipeSchedule + ')'
		WHEN (PipeClass <> '') THEN ' (' + PipeClass + ')'
		ELSE ''
	END
	AS Description
FROM v_PipeSpecification;

SELECT UnitTypeID, ShortName, Description, Active FROM UnitType;

END
GO
/****** Object:  StoredProcedure [dbo].[Fersum_Sel_GetQuotationProductSelectionByQuotationID]    Script Date: 12/21/2010 12:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Fersum_Sel_GetQuotationProductSelectionByQuotationID]
	@QuotationID int
AS
BEGIN

SELECT QS.QuotationID, QS.QuotationSectionID, QSD.QuotationSectionDetailID, QSD.PipeSpecificationID,
	PS.PipeDiameterTypeID, QSD.Quantity, UT.UnitTypeID, QS.SectionTypeID,
	PS.KilogramsPerMeter,
	PDT.ShortName
	AS PDTDescription,
	CAST (PS.WallThicknessInches AS varchar(10)) +
	CASE WHEN (PS.PipeSchedule <> '' AND PS.PipeClass <> '') THEN ' (Cédula ' + PS.PipeSchedule + ' ' + PS.PipeClass + ')'
		WHEN (PS.PipeSchedule <> '') THEN ' (Cédula ' + PS.PipeSchedule + ')'
		WHEN (PS.PipeClass <> '') THEN ' (' + PS.PipeClass + ')'
		ELSE ''
	END
	AS PSDescription
	FROM QuotationSection QS
	INNER JOIN QuotationSectionDetail QSD ON QS.QuotationSectionID = QSD.QuotationSectionID
	INNER JOIN v_PipeSpecification PS ON QSD.PipeSpecificationID = PS.PipeSpecificationID
	INNER JOIN PipeDiameterType PDT ON PS.PipeDiameterTypeID = PDT.PipeDiameterTypeID
	INNER JOIN UnitType UT ON QSD.UnitTypeID = UT.UnitTypeID
WHERE QuotationID = @QuotationID
ORDER BY QuotationSectionDetailID ASC;
END
GO
/****** Object:  StoredProcedure [dbo].[Fersum_Sel_GetQuotationsReport]    Script Date: 12/21/2010 12:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  StoredProcedure [dbo].[Fersum_Sel_GetQuotationConditionsByQuotationID]    Script Date: 12/21/2010 12:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Fersum_Sel_GetQuotationConditionsByQuotationID]
(
	@QuotationID int
)
AS
BEGIN
	SELECT Q.QuotationID, QS.QuotationSectionID, QS.SectionTypeID, ST.ShortName,
		CASE WHEN QS.SectionDescription = '' THEN ST.Description
			ELSE QS.SectionDescription END AS Description
	FROM Quotation Q
		INNER JOIN QuotationSection QS ON Q.QuotationID = QS.QuotationID
		INNER JOIN SectionType ST ON QS.SectionTypeID = ST.SectionTypeID
	WHERE Q.QuotationID = @QuotationID
	ORDER BY ST.SectionTypeID;

	SELECT Q.QuotationID, QS.QuotationSectionID, QS.SectionTypeID, QSD.QuotationSectionDetailID, QSD.PipeSpecificationID, PS.ShortName,
		CAST (PS.WallThicknessInches AS varchar(10)) +
			CASE WHEN (PS.PipeSchedule <> '') THEN ' (Cédula ' + PS.PipeSchedule +
				CASE WHEN (PS.PipeClass <> '') THEN ' ' + PS.PipeClass ELSE '' END
			+ ')' ELSE '' END
		AS Description,
		Price,
		CASE WHEN QSD.CurrencyDescription = '' THEN
			(CASE WHEN QS.SectionTypeID IN (1,2) THEN RTRIM((SELECT TOP 1 Description FROM CurrencyType WHERE CurrencyTypeID = 2))
				ELSE RTRIM((SELECT TOP 1 Description FROM CurrencyType WHERE CurrencyTypeID = 1)) END)
			ELSE QSD.CurrencyDescription END AS CurrencyDescription,
		PS.KilogramsPerMeter AS LinearWeight,
		QSD.Weight,
		--PaymentDescription,
		DeliveryDescription,
		DeliveryTimeDescription
		--,ValidPeriodDescription
	FROM Quotation Q
		INNER JOIN QuotationSection QS ON Q.QuotationID = QS.QuotationID
		INNER JOIN QuotationSectionDetail QSD ON QS.QuotationSectionID = QSD.QuotationSectionID
		LEFT JOIN dbo.v_PipeSpecification PS ON QSD.PipeSpecificationID = PS.PipeSpecificationID
	WHERE Q.QuotationID = @QuotationID
	ORDER BY QS.SectionTypeID;
END
GO
/****** Object:  StoredProcedure [dbo].[Fersum_Sel_GetQuotationData]    Script Date: 12/21/2010 12:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
		CONVERT(varchar(20),CONVERT(money, QSD.Quantity), 1) + ' ' + UT.ShortName AS Quantity,
		QSD.Weight,
		QSD.QuotationSectionDetailID, QSD.PipeSpecificationID, PS.ShortName + '"' AS ShortName,
		CAST (PS.WallThicknessInches AS varchar(10)) +
			CASE WHEN (PS.PipeSchedule <> '') THEN ' (Cédula ' + PS.PipeSchedule +
				CASE WHEN (PS.PipeClass <> '') THEN ' ' + PS.PipeClass ELSE '' END
			+ ')' ELSE '' END
		AS Description,
		'$ ' + CONVERT(varchar(20),CONVERT(money, Price), 1) + ' ' +
		CASE WHEN QSD.CurrencyDescription = '' THEN
			(CASE WHEN QS.SectionTypeID IN (1,2) THEN RTRIM((SELECT TOP 1 Description FROM CurrencyType WHERE CurrencyTypeID = 2))
				ELSE RTRIM((SELECT TOP 1 Description FROM CurrencyType WHERE CurrencyTypeID = 1)) END)
			ELSE QSD.CurrencyDescription END AS Price,
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
/****** Object:  ForeignKey [FK_CustomerContact_Customer]    Script Date: 12/21/2010 12:48:59 ******/
ALTER TABLE [dbo].[CustomerContact]  WITH CHECK ADD  CONSTRAINT [FK_CustomerContact_Customer] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([CustomerID])
GO
ALTER TABLE [dbo].[CustomerContact] CHECK CONSTRAINT [FK_CustomerContact_Customer]
GO
/****** Object:  ForeignKey [FK_PipeSpecification_PipeDiameterType]    Script Date: 12/21/2010 12:48:59 ******/
ALTER TABLE [dbo].[PipeSpecification]  WITH CHECK ADD  CONSTRAINT [FK_PipeSpecification_PipeDiameterType] FOREIGN KEY([PipeDiameterTypeID])
REFERENCES [dbo].[PipeDiameterType] ([PipeDiameterTypeID])
GO
ALTER TABLE [dbo].[PipeSpecification] CHECK CONSTRAINT [FK_PipeSpecification_PipeDiameterType]
GO
/****** Object:  ForeignKey [FK_Quotation_Customer]    Script Date: 12/21/2010 12:48:59 ******/
ALTER TABLE [dbo].[Quotation]  WITH CHECK ADD  CONSTRAINT [FK_Quotation_Customer] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([CustomerID])
GO
ALTER TABLE [dbo].[Quotation] CHECK CONSTRAINT [FK_Quotation_Customer]
GO
/****** Object:  ForeignKey [FK_Quotation_CustomerContact]    Script Date: 12/21/2010 12:48:59 ******/
ALTER TABLE [dbo].[Quotation]  WITH CHECK ADD  CONSTRAINT [FK_Quotation_CustomerContact] FOREIGN KEY([CustomerContactID])
REFERENCES [dbo].[CustomerContact] ([CustomerContactID])
GO
ALTER TABLE [dbo].[Quotation] CHECK CONSTRAINT [FK_Quotation_CustomerContact]
GO
/****** Object:  ForeignKey [FK_Quotation_QuotationStatusType]    Script Date: 12/21/2010 12:48:59 ******/
ALTER TABLE [dbo].[Quotation]  WITH CHECK ADD  CONSTRAINT [FK_Quotation_QuotationStatusType] FOREIGN KEY([QuotationStatusTypeID])
REFERENCES [dbo].[QuotationStatusType] ([QuotationStatustypeID])
GO
ALTER TABLE [dbo].[Quotation] CHECK CONSTRAINT [FK_Quotation_QuotationStatusType]
GO
/****** Object:  ForeignKey [FK_QuotationAttachment_Quotation]    Script Date: 12/21/2010 12:48:59 ******/
ALTER TABLE [dbo].[QuotationAttachment]  WITH CHECK ADD  CONSTRAINT [FK_QuotationAttachment_Quotation] FOREIGN KEY([QuotationID])
REFERENCES [dbo].[Quotation] ([QuotationID])
GO
ALTER TABLE [dbo].[QuotationAttachment] CHECK CONSTRAINT [FK_QuotationAttachment_Quotation]
GO
/****** Object:  ForeignKey [FK_QuotationSection_Quotation]    Script Date: 12/21/2010 12:48:59 ******/
ALTER TABLE [dbo].[QuotationSection]  WITH CHECK ADD  CONSTRAINT [FK_QuotationSection_Quotation] FOREIGN KEY([QuotationID])
REFERENCES [dbo].[Quotation] ([QuotationID])
GO
ALTER TABLE [dbo].[QuotationSection] CHECK CONSTRAINT [FK_QuotationSection_Quotation]
GO
/****** Object:  ForeignKey [FK_QuotationSection_SectionType]    Script Date: 12/21/2010 12:48:59 ******/
ALTER TABLE [dbo].[QuotationSection]  WITH CHECK ADD  CONSTRAINT [FK_QuotationSection_SectionType] FOREIGN KEY([SectionTypeID])
REFERENCES [dbo].[SectionType] ([SectionTypeID])
GO
ALTER TABLE [dbo].[QuotationSection] CHECK CONSTRAINT [FK_QuotationSection_SectionType]
GO
/****** Object:  ForeignKey [FK_QuotationSectionDetail_QuotationSection]    Script Date: 12/21/2010 12:48:59 ******/
ALTER TABLE [dbo].[QuotationSectionDetail]  WITH CHECK ADD  CONSTRAINT [FK_QuotationSectionDetail_QuotationSection] FOREIGN KEY([QuotationSectionID])
REFERENCES [dbo].[QuotationSection] ([QuotationSectionID])
GO
ALTER TABLE [dbo].[QuotationSectionDetail] CHECK CONSTRAINT [FK_QuotationSectionDetail_QuotationSection]
GO
/****** Object:  ForeignKey [FK_QuotationSectionDetail_UnitType]    Script Date: 12/21/2010 12:48:59 ******/
ALTER TABLE [dbo].[QuotationSectionDetail]  WITH CHECK ADD  CONSTRAINT [FK_QuotationSectionDetail_UnitType] FOREIGN KEY([UnitTypeID])
REFERENCES [dbo].[UnitType] ([UnitTypeID])
GO
ALTER TABLE [dbo].[QuotationSectionDetail] CHECK CONSTRAINT [FK_QuotationSectionDetail_UnitType]
GO
/****** Object:  ForeignKey [FK_UserCompanyPreferences_Company]    Script Date: 12/21/2010 12:48:59 ******/
ALTER TABLE [dbo].[UserCompanyPreferences]  WITH CHECK ADD  CONSTRAINT [FK_UserCompanyPreferences_Company] FOREIGN KEY([CompanyID])
REFERENCES [dbo].[Company] ([CompanyID])
GO
ALTER TABLE [dbo].[UserCompanyPreferences] CHECK CONSTRAINT [FK_UserCompanyPreferences_Company]
GO
/****** Object:  ForeignKey [FK_UserCompanyPreferences_Users]    Script Date: 12/21/2010 12:48:59 ******/
ALTER TABLE [dbo].[UserCompanyPreferences]  WITH CHECK ADD  CONSTRAINT [FK_UserCompanyPreferences_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[UserCompanyPreferences] CHECK CONSTRAINT [FK_UserCompanyPreferences_Users]
GO
/****** Object:  ForeignKey [FK_UserPreferences_Users]    Script Date: 12/21/2010 12:48:59 ******/
ALTER TABLE [dbo].[UserPreferences]  WITH CHECK ADD  CONSTRAINT [FK_UserPreferences_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[UserPreferences] CHECK CONSTRAINT [FK_UserPreferences_Users]
GO
