USE [SmartMeterDB]
GO

/****** Object:  Table [dbo].[Vendors]    Script Date: 04-07-2022 10:09:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Vendors]') AND type in (N'U'))
DROP TABLE [dbo].[Vendors]
GO

/****** Object:  Table [dbo].[Vendors]    Script Date: 04-07-2022 10:09:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Vendors](
	[Id] [int] NOT NULL,
	[Address] [nvarchar](200) NULL,
	[ContactNumber] [varchar](20) NULL,
	[Name] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


