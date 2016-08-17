USE [Fersum]
GO
/****** Object:  Table [dbo].[InvoiceMethodType]    Script Date: 10/13/2009 00:02:53 ******/
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