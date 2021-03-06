/****** Object:  Table [dbo].[QuotationSectionDetail]    Script Date: 12/06/2010 23:13:25 ******/
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
