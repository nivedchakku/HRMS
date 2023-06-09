
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 2/15/2023 11:48:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 2/15/2023 11:48:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[attandance]    Script Date: 2/15/2023 11:48:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[attandance](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[employeeid] [nvarchar](450) NULL,
	[timein] [date] NULL,
	[timeout] [date] NULL,
	[remarks] [varchar](50) NULL,
 CONSTRAINT [PK_attandance] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[department]    Script Date: 2/15/2023 11:48:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[department](
	[deptid] [int] IDENTITY(1,1) NOT NULL,
	[deptname] [varchar](50) NULL,
 CONSTRAINT [PK_department] PRIMARY KEY CLUSTERED 
(
	[deptid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[employee]    Script Date: 2/15/2023 11:48:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[employee](
	[employeeid] [nvarchar](450) NOT NULL,
	[firstname] [varchar](50) NULL,
	[lastname] [varchar](50) NULL,
	[mobile] [int] NULL,
	[email] [varchar](50) NULL,
	[dob] [date] NULL,
	[address] [varchar](50) NULL,
	[departmentid] [int] NULL,
	[positionid] [int] NULL,
	[salaryid] [int] NULL,
 CONSTRAINT [PK_employee] PRIMARY KEY CLUSTERED 
(
	[employeeid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[leave]    Script Date: 2/15/2023 11:48:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[leave](
	[leaveid] [int] IDENTITY(1,1) NOT NULL,
	[leavename] [varchar](50) NULL,
	[days] [int] NULL,
 CONSTRAINT [PK_leave] PRIMARY KEY CLUSTERED 
(
	[leaveid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[leave_application]    Script Date: 2/15/2023 11:48:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[leave_application](
	[leaveid] [int] NULL,
	[employeeid] [nvarchar](450) NULL,
	[startdate] [date] NULL,
	[enddate] [date] NULL,
	[days] [float] NULL,
	[description] [varchar](50) NULL,
	[status] [int] NULL,
	[dateapplied] [date] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[position]    Script Date: 2/15/2023 11:48:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[position](
	[positionid] [int] IDENTITY(1,1) NOT NULL,
	[positionname] [varchar](50) NULL,
 CONSTRAINT [PK_position] PRIMARY KEY CLUSTERED 
(
	[positionid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[project]    Script Date: 2/15/2023 11:48:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[project](
	[projectid] [int] IDENTITY(1,1) NOT NULL,
	[projectname] [varchar](50) NULL,
	[projectLead] [varchar](50) NULL,
	[datestarted] [date] NULL,
	[status] [int] NULL,
 CONSTRAINT [PK_project] PRIMARY KEY CLUSTERED 
(
	[projectid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[project_allocation]    Script Date: 2/15/2023 11:48:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[project_allocation](
	[projectid] [int] NULL,
	[employeeid] [nvarchar](450) NULL,
	[status] [int] NULL,
	[allocationdate] [date] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[salary]    Script Date: 2/15/2023 11:48:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[salary](
	[salaryid] [int] IDENTITY(1,1) NOT NULL,
	[salaryrange] [float] NULL,
 CONSTRAINT [PK_salary] PRIMARY KEY CLUSTERED 
(
	[salaryid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[training]    Script Date: 2/15/2023 11:48:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[training](
	[tariningid] [int] IDENTITY(1,1) NOT NULL,
	[trainingname] [varchar](50) NULL,
	[description] [text] NULL,
	[date] [date] NULL,
 CONSTRAINT [PK_training] PRIMARY KEY CLUSTERED 
(
	[tariningid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[training_allocation]    Script Date: 2/15/2023 11:48:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[training_allocation](
	[trainingid] [int] NOT NULL,
	[employeeid] [nvarchar](450) NULL,
	[status] [int] NULL,
	[date] [int] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[attandance]  WITH CHECK ADD  CONSTRAINT [FK_attandance_attandance] FOREIGN KEY([employeeid])
REFERENCES [dbo].[employee] ([employeeid])
GO
ALTER TABLE [dbo].[attandance] CHECK CONSTRAINT [FK_attandance_attandance]
GO
ALTER TABLE [dbo].[employee]  WITH CHECK ADD  CONSTRAINT [FK_employee_department] FOREIGN KEY([departmentid])
REFERENCES [dbo].[department] ([deptid])
GO
ALTER TABLE [dbo].[employee] CHECK CONSTRAINT [FK_employee_department]
GO
ALTER TABLE [dbo].[employee]  WITH CHECK ADD  CONSTRAINT [FK_employee_employee] FOREIGN KEY([employeeid])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[employee] CHECK CONSTRAINT [FK_employee_employee]
GO
ALTER TABLE [dbo].[employee]  WITH CHECK ADD  CONSTRAINT [FK_employee_position] FOREIGN KEY([positionid])
REFERENCES [dbo].[position] ([positionid])
GO
ALTER TABLE [dbo].[employee] CHECK CONSTRAINT [FK_employee_position]
GO
ALTER TABLE [dbo].[employee]  WITH CHECK ADD  CONSTRAINT [FK_employee_salary] FOREIGN KEY([salaryid])
REFERENCES [dbo].[salary] ([salaryid])
GO
ALTER TABLE [dbo].[employee] CHECK CONSTRAINT [FK_employee_salary]
GO
ALTER TABLE [dbo].[leave_application]  WITH CHECK ADD  CONSTRAINT [FK_leave_application_employee] FOREIGN KEY([employeeid])
REFERENCES [dbo].[employee] ([employeeid])
GO
ALTER TABLE [dbo].[leave_application] CHECK CONSTRAINT [FK_leave_application_employee]
GO
ALTER TABLE [dbo].[leave_application]  WITH CHECK ADD  CONSTRAINT [FK_leave_application_leave] FOREIGN KEY([leaveid])
REFERENCES [dbo].[leave] ([leaveid])
GO
ALTER TABLE [dbo].[leave_application] CHECK CONSTRAINT [FK_leave_application_leave]
GO
ALTER TABLE [dbo].[project_allocation]  WITH CHECK ADD  CONSTRAINT [FK_project_allocation_employee] FOREIGN KEY([employeeid])
REFERENCES [dbo].[employee] ([employeeid])
GO
ALTER TABLE [dbo].[project_allocation] CHECK CONSTRAINT [FK_project_allocation_employee]
GO
ALTER TABLE [dbo].[project_allocation]  WITH CHECK ADD  CONSTRAINT [FK_project_allocation_project] FOREIGN KEY([projectid])
REFERENCES [dbo].[project] ([projectid])
GO
ALTER TABLE [dbo].[project_allocation] CHECK CONSTRAINT [FK_project_allocation_project]
GO
ALTER TABLE [dbo].[training_allocation]  WITH CHECK ADD  CONSTRAINT [FK_training_allocation_employee] FOREIGN KEY([employeeid])
REFERENCES [dbo].[employee] ([employeeid])
GO
ALTER TABLE [dbo].[training_allocation] CHECK CONSTRAINT [FK_training_allocation_employee]
GO
ALTER TABLE [dbo].[training_allocation]  WITH CHECK ADD  CONSTRAINT [FK_training_allocation_training] FOREIGN KEY([trainingid])
REFERENCES [dbo].[training] ([tariningid])
GO
ALTER TABLE [dbo].[training_allocation] CHECK CONSTRAINT [FK_training_allocation_training]
GO
