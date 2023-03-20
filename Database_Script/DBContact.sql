------------------------create database :Customer---------------------------------------------------------------------
create database [Customer]
---------------------------------------------------------------------------------------------
USE [Customer]
GO 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblContact](
	[ContactId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](100) NULL,
	[LastName] [varchar](100) NULL,
	[Email] [varchar](100) NULL,
	[PhoneNumber] [varchar](50) NULL,
	[Address] [varchar](250) NULL,
	[City] [varchar](100) NULL,
	[State] [varchar](100) NULL,
	[Country] [varchar](100) NULL,
	[PostalCode] [varchar](10) NULL,
 CONSTRAINT [PK_tblContact] PRIMARY KEY CLUSTERED 
(
	[ContactId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[tblContact] ON 

GO
INSERT [dbo].[tblContact] ([ContactId], [FirstName], [LastName], [Email], [PhoneNumber], [Address], [City], [State], [Country], [PostalCode]) VALUES (1, N'Prem', N'Bind', N'premkumar.anshu@gmail.com', N'7738455729', N'Mumbai,Maharastra', N'Mumbai', N'Maharastra', N'India', N'400060')
GO
SET IDENTITY_INSERT [dbo].[tblContact] OFF
GO
