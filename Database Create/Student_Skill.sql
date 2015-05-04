USE [333_MakerLab]
GO

/****** Object:  Table [dbo].[Student_Skill]    Script Date: 5/4/2015 11:56:58 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Student_Skill](
	[Student_ID] [int] NULL,
	[Student_Skill] [int] NULL
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Student_Skill]  WITH CHECK ADD FOREIGN KEY([Student_ID])
REFERENCES [dbo].[Student] ([StudentID])
GO

ALTER TABLE [dbo].[Student_Skill]  WITH CHECK ADD FOREIGN KEY([Student_Skill])
REFERENCES [dbo].[Skill] ([ID])
GO

