USE [SmartMeterDB]
GO

ALTER TABLE [dbo].[SmartMeter] DROP CONSTRAINT [Fk_VendorID]
GO

/****** Object:  Table [dbo].[SmartMeter]    Script Date: 04-07-2022 10:07:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SmartMeter]') AND type in (N'U'))
DROP TABLE [dbo].[SmartMeter]
GO

/****** Object:  Table [dbo].[SmartMeter]    Script Date: 04-07-2022 10:07:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SmartMeter](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Status] [nvarchar](20) NULL,
	[VendorId] [int] NULL,
	[PurchaseDate] [datetime] NULL,
	[MeterPrice] [bigint] NULL,
	[MeterState] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[SmartMeter]  WITH CHECK ADD  CONSTRAINT [Fk_VendorID] FOREIGN KEY([VendorId])
REFERENCES [dbo].[Vendors] ([Id])
GO

ALTER TABLE [dbo].[SmartMeter] CHECK CONSTRAINT [Fk_VendorID]
GO


