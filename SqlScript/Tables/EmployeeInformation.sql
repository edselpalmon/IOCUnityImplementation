USE [HRMSDB]
GO

/****** Object:  Table [dbo].[EmployeeInformation]    Script Date: 3/14/2016 1:02:43 PM ******/
DROP TABLE [dbo].[EmployeeInformation]
GO

/****** Object:  Table [dbo].[EmployeeInformation]    Script Date: 3/14/2016 1:02:43 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[EmployeeInformation](
	[EmployeeId] [bigint] IDENTITY(1,1) NOT NULL,
	[EmployeeNumber] AS  
		(
		substring([FirstName],1,1) 
		+ substring([MiddleName],1,1) 
		+ substring([LastName],1,1) 
		+ CONVERT(nvarchar(20),[EmployeeId])
		) PERSISTED NOT NULL,
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


