USE [SmartMeterDB]
GO

ALTER TABLE [dbo].[Complaints] DROP CONSTRAINT [Fk_Complaints_emailId]
GO

/****** Object:  Table [dbo].[Complaints]    Script Date: 04-07-2022 10:07:27 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Complaints]') AND type in (N'U'))
DROP TABLE [dbo].[Complaints]
GO

/****** Object:  Table [dbo].[Complaints]    Script Date: 04-07-2022 10:07:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Complaints](
	[ConsumerEmailId] [nvarchar](100) NOT NULL,
	[Date] [datetime] NULL,
	[Type] [varchar](50) NULL,
	[Status] [varchar](20) NULL,
	[Message] [varchar](500) NULL,
	[Id] [uniqueidentifier] NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Complaints]  WITH CHECK ADD  CONSTRAINT [Fk_Complaints_emailId] FOREIGN KEY([ConsumerEmailId])
REFERENCES [dbo].[Users] ([EmailAddress])
GO

ALTER TABLE [dbo].[Complaints] CHECK CONSTRAINT [Fk_Complaints_emailId]
GO


