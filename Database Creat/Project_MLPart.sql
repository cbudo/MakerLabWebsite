USE [333_MakerLab]
GO

/****** Object:  Table [dbo].[Project_MLPart]    Script Date: 5/4/2015 11:55:55 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Project_MLPart](
	[MLPart_ID] [int] NULL,
	[Project_ID] [int] NULL
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Project_MLPart]  WITH CHECK ADD FOREIGN KEY([MLPart_ID])
REFERENCES [dbo].[Maker_Lab_Part] ([ID])
GO

ALTER TABLE [dbo].[Project_MLPart]  WITH CHECK ADD FOREIGN KEY([Project_ID])
REFERENCES [dbo].[Project] ([ID])
GO

