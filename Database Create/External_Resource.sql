USE [333_MakerLab]
GO

/****** Object:  Table [dbo].[External_Resource]    Script Date: 5/4/2015 11:53:34 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[External_Resource](
	[ID] [int] NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Location] [nvarchar](30) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Total] [int] NOT NULL,
	[Access_Level] [tinyint] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

