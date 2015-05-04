USE [333_MakerLab]
GO

/****** Object:  Table [dbo].[Project_MLTool]    Script Date: 5/4/2015 11:56:10 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Project_MLTool](
	[MLTool_ID] [int] NULL,
	[Project_ID] [int] NULL
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Project_MLTool]  WITH CHECK ADD FOREIGN KEY([MLTool_ID])
REFERENCES [dbo].[Maker_Lab_Tool] ([ID])
GO

ALTER TABLE [dbo].[Project_MLTool]  WITH CHECK ADD FOREIGN KEY([Project_ID])
REFERENCES [dbo].[Project] ([ID])
GO

