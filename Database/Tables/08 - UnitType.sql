/****** Object:  Table [dbo].[UnitType]    Script Date: 12/06/2010 23:13:25 ******/
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
