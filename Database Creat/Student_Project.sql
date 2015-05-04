USE [333_MakerLab]
GO

/****** Object:  Table [dbo].[Student_Project]    Script Date: 5/4/2015 11:56:43 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Student_Project](
	[Student_ID] [int] NULL,
	[Project_ID] [int] NULL,
	[Last_update] [smalldatetime] NULL
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Student_Project]  WITH CHECK ADD FOREIGN KEY([Project_ID])
REFERENCES [dbo].[Project] ([ID])
GO

ALTER TABLE [dbo].[Student_Project]  WITH CHECK ADD FOREIGN KEY([Student_ID])
REFERENCES [dbo].[Student] ([StudentID])
GO

