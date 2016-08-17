/****** Object:  Table [dbo].[ValidPeriodType]    Script Date: 11/14/2010 10:01:21 ******/
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
