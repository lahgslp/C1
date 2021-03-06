/****** Object:  Table [dbo].[Quotation]    Script Date: 11/15/2010 16:15:45 ******/
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
