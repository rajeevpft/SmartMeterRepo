USE [SmartMeterDB]
GO

/****** Object:  Table [dbo].[Users]    Script Date: 04-07-2022 10:08:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
DROP TABLE [dbo].[Users]
GO

/****** Object:  Table [dbo].[Users]    Script Date: 04-07-2022 10:08:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Role] [nvarchar](20) NOT NULL,
	[EmailAddress] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[AreaCode] [bigint] NOT NULL,
	[MobileNumber] [nvarchar](11) NULL,
	[LanguageSelected] [nvarchar](30) NOT NULL,
	[SmartMeterId] [int] NULL,
	[Status] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[EmailAddress] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


