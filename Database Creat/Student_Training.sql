USE [333_MakerLab]
GO

/****** Object:  Table [dbo].[Student_Training]    Script Date: 5/4/2015 11:57:22 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Student_Training](
	[Student_ID] [int] NULL,
	[MakerLab_Tool_ID] [int] NULL,
	[Student_Training] [char](30) NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Student_Training]  WITH CHECK ADD FOREIGN KEY([MakerLab_Tool_ID])
REFERENCES [dbo].[Maker_Lab_Tool] ([ID])
GO

ALTER TABLE [dbo].[Student_Training]  WITH CHECK ADD FOREIGN KEY([Student_ID])
REFERENCES [dbo].[Student] ([StudentID])
GO

