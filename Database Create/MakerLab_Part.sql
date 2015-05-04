USE [333_MakerLab]
GO

/****** Object:  Table [dbo].[Maker_Lab_Part]    Script Date: 5/4/2015 11:54:15 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Maker_Lab_Part](
	[ID] [int] NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Buy_More_at] [int] NOT NULL,
	[Purchase_Loc] [nvarchar](max) NOT NULL,
	[Last_Price] [decimal](7, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

