/****** Object:  Table [dbo].[UserPreferences]    Script Date: 11/15/2010 16:33:10 ******/
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
