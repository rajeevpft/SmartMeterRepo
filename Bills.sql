USE [SmartMeterDB]
GO

ALTER TABLE [dbo].[Bills] DROP CONSTRAINT [Fk_Bill_emailId]
GO

/****** Object:  Table [dbo].[Bills]    Script Date: 04-07-2022 10:06:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Bills]') AND type in (N'U'))
DROP TABLE [dbo].[Bills]
GO

/****** Object:  Table [dbo].[Bills]    Script Date: 04-07-2022 10:06:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Bills](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ConsumerEmailId] [nvarchar](100) NULL,
	[Date] [datetime] NULL,
	[SmartMeterId] [int] NOT NULL,
	[BillUnits] [float] NULL,
	[BillingAmount] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Bills]  WITH CHECK ADD  CONSTRAINT [Fk_Bill_emailId] FOREIGN KEY([ConsumerEmailId])
REFERENCES [dbo].[Users] ([EmailAddress])
GO

ALTER TABLE [dbo].[Bills] CHECK CONSTRAINT [Fk_Bill_emailId]
GO


