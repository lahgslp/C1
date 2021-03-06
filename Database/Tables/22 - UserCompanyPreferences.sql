/****** Object:  Table [dbo].[UserCompanyPreferences]    Script Date: 11/14/2010 15:34:29 ******/
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
