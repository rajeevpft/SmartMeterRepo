USE [SmartMeterDB]
GO

/****** Object:  Table [dbo].[UserLocations]    Script Date: 04-07-2022 10:08:21 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserLocations]') AND type in (N'U'))
DROP TABLE [dbo].[UserLocations]
GO

/****** Object:  Table [dbo].[UserLocations]    Script Date: 04-07-2022 10:08:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UserLocations](
	[AreaCode] [bigint] NOT NULL,
	[Street] [nvarchar](200) NULL,
	[City] [nvarchar](100) NULL,
	[State] [nvarchar](100) NULL,
	[Pincode] [nvarchar](20) NOT NULL
) ON [PRIMARY]
GO


