USE [HRMSDB]
GO
/****** Object:  Table [dbo].[EducationalBackground]    Script Date: 3/17/2016 4:40:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EducationalBackground](
	[EmployeeId] [bigint] NOT NULL,
	[SchoolCode] [nchar](10) NULL,
	[SchoolName] [nchar](10) NULL,
	[SchoolAddress] [nchar](10) NULL,
	[DateAttended] [nchar](10) NULL,
	[DateGraduated] [nchar](10) NULL,
	[Degree] [nchar](10) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmployeeAddress]    Script Date: 3/17/2016 4:40:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeAddress](
	[AddressId] [bigint] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [bigint] NOT NULL,
	[AddressLine1] [nvarchar](100) NOT NULL,
	[Addressline2] [nvarchar](100) NULL,
	[City] [nvarchar](50) NOT NULL,
	[Province] [nvarchar](50) NULL,
	[State] [nvarchar](50) NULL,
	[Country] [nvarchar](50) NOT NULL,
	[PostalCode] [nvarchar](20) NULL,
 CONSTRAINT [PK_EmployeeAddress] PRIMARY KEY CLUSTERED 
(
	[AddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmployeeInformation]    Script Date: 3/17/2016 4:40:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EmployeeInformation](
	[EmployeeId] [bigint] IDENTITY(1,1) NOT NULL,
	[EmployeeNumber]  AS (((substring([FirstName],(1),(1))+substring([MiddleName],(1),(1)))+substring([LastName],(1),(1)))+CONVERT([nvarchar](20),[EmployeeId])) PERSISTED NOT NULL,
	[Salutation] [nvarchar](5) NULL,
	[FirstName] [nvarchar](100) NOT NULL,
	[MiddleName] [nvarchar](100) NOT NULL,
	[LastName] [nvarchar](100) NOT NULL,
	[Suffix] [nvarchar](5) NULL,
	[BirthDate] [datetime] NOT NULL,
	[Gender] [char](1) NOT NULL,
	[CivilStatus] [char](1) NOT NULL,
	[EducationalAttainment] [char](1) NULL,
 CONSTRAINT [PK_EmployeeInformation] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_EmployeeNumber] UNIQUE NONCLUSTERED 
(
	[FirstName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EmployementHistory]    Script Date: 3/17/2016 4:40:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployementHistory](
	[EmployeeId] [bigint] NOT NULL,
	[CompanyName] [nchar](10) NULL,
	[CompanyAddress] [nchar](10) NULL,
	[StartDate] [nchar](10) NULL,
	[EndDate] [nchar](10) NULL,
	[LastPositionHeld] [nchar](10) NULL,
	[Industry] [nchar](10) NULL
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[EducationalBackground]  WITH CHECK ADD  CONSTRAINT [FK_EducationalBackground_EmployeeId] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[EmployeeInformation] ([EmployeeId])
GO
ALTER TABLE [dbo].[EducationalBackground] CHECK CONSTRAINT [FK_EducationalBackground_EmployeeId]
GO
ALTER TABLE [dbo].[EmployeeAddress]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeAddress_EmployeeId] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[EmployeeInformation] ([EmployeeId])
GO
ALTER TABLE [dbo].[EmployeeAddress] CHECK CONSTRAINT [FK_EmployeeAddress_EmployeeId]
GO
ALTER TABLE [dbo].[EmployementHistory]  WITH CHECK ADD  CONSTRAINT [FK_EmployementHistory_EmployeeId] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[EmployeeInformation] ([EmployeeId])
GO
ALTER TABLE [dbo].[EmployementHistory] CHECK CONSTRAINT [FK_EmployementHistory_EmployeeId]
GO
