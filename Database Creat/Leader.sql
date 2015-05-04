USE [333_MakerLab]
GO

/****** Object:  Table [dbo].[Leader]    Script Date: 5/4/2015 11:53:58 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Leader](
	[Student_ID] [int] NULL,
	[Position_Held] [char](20) NULL,
	[Position_Year] [int] NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Leader]  WITH CHECK ADD FOREIGN KEY([Student_ID])
REFERENCES [dbo].[Student] ([StudentID])
GO

