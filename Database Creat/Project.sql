USE [333_MakerLab]
GO

/****** Object:  Table [dbo].[Project]    Script Date: 5/4/2015 11:54:57 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Project](
	[ID] [int] NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Image_Gallery] [nvarchar](max) NULL,
	[DateAdded] [date] NULL,
	[LastModified] [datetime] NULL,
	[STATUS] [smallint] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

