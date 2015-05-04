USE [333_MakerLab]
GO

/****** Object:  Table [dbo].[Project_Ext_Resource]    Script Date: 5/4/2015 11:55:37 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Project_Ext_Resource](
	[Resource_ID] [int] NULL,
	[Project_ID] [int] NULL
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Project_Ext_Resource]  WITH CHECK ADD FOREIGN KEY([Project_ID])
REFERENCES [dbo].[Project] ([ID])
GO

ALTER TABLE [dbo].[Project_Ext_Resource]  WITH CHECK ADD FOREIGN KEY([Resource_ID])
REFERENCES [dbo].[External_Resource] ([ID])
GO

