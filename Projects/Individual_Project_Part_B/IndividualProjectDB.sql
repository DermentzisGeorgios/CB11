USE [IndividualProject-Dermentzis_George]
GO
/****** Object:  Table [dbo].[Assignments]    Script Date: 20/2/2021 6:55:35 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Assignments](
	[assignmentID] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](40) NOT NULL,
	[description] [nvarchar](400) NULL,
	[subDateTime] [datetime] NOT NULL,
	[oralMark] [int] NULL,
	[totalMark] [int] NULL,
 CONSTRAINT [PK_Assignments] PRIMARY KEY CLUSTERED 
(
	[assignmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AssignmentsPerCourse]    Script Date: 20/2/2021 6:55:35 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssignmentsPerCourse](
	[ApC_ID] [int] IDENTITY(1,1) NOT NULL,
	[course_ID] [int] NOT NULL,
	[assignment_ID] [int] NOT NULL,
 CONSTRAINT [PK_AssignmentsPerCourse] PRIMARY KEY CLUSTERED 
(
	[ApC_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 20/2/2021 6:55:35 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[courseID] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](40) NOT NULL,
	[stream] [nvarchar](40) NOT NULL,
	[type] [nvarchar](40) NOT NULL,
	[start_date] [datetime] NOT NULL,
	[end_date] [datetime] NOT NULL,
 CONSTRAINT [PK_Courses] PRIMARY KEY CLUSTERED 
(
	[courseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 20/2/2021 6:55:35 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[studentID] [int] IDENTITY(1,1) NOT NULL,
	[firstName] [nvarchar](40) NOT NULL,
	[lastName] [nvarchar](40) NOT NULL,
	[dateOfBirth] [datetime] NOT NULL,
	[tuitionFees] [decimal](8, 2) NOT NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[studentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentsPerCourse]    Script Date: 20/2/2021 6:55:35 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentsPerCourse](
	[SpC_ID] [int] IDENTITY(1,1) NOT NULL,
	[course_ID] [int] NOT NULL,
	[student_ID] [int] NOT NULL,
 CONSTRAINT [PK_StudentsPerCourse] PRIMARY KEY CLUSTERED 
(
	[SpC_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Trainers]    Script Date: 20/2/2021 6:55:35 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Trainers](
	[trainerID] [int] IDENTITY(1,1) NOT NULL,
	[firstName] [nvarchar](40) NOT NULL,
	[lastName] [nvarchar](40) NOT NULL,
	[subject] [nvarchar](40) NOT NULL,
 CONSTRAINT [PK_Trainers] PRIMARY KEY CLUSTERED 
(
	[trainerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TrainersPerCourse]    Script Date: 20/2/2021 6:55:35 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TrainersPerCourse](
	[TpC_ID] [int] IDENTITY(1,1) NOT NULL,
	[course_ID] [int] NOT NULL,
	[trainer_ID] [int] NOT NULL,
 CONSTRAINT [PK_TrainersPerCourse] PRIMARY KEY CLUSTERED 
(
	[TpC_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Assignments] ON 

INSERT [dbo].[Assignments] ([assignmentID], [title], [description], [subDateTime], [oralMark], [totalMark]) VALUES (1, N'Individual Project 1', N'Ask from the user the following questions and store the answers to appropriate variables', CAST(N'2020-06-28T00:00:00.000' AS DateTime), 30, 70)
INSERT [dbo].[Assignments] ([assignmentID], [title], [description], [subDateTime], [oralMark], [totalMark]) VALUES (2, N'School Project', N'During the development of this project you need to do the implementation of a private school structure', CAST(N'2020-09-18T00:00:00.000' AS DateTime), 40, 80)
INSERT [dbo].[Assignments] ([assignmentID], [title], [description], [subDateTime], [oralMark], [totalMark]) VALUES (3, N'Individual Project 2', N'The application that you will build needs to hold in a database multiple courses along with the enrolled students, the trainers that teach the subjects and the assignments that the students need to submit during the course duration', CAST(N'2020-07-27T00:00:00.000' AS DateTime), 35, 75)
INSERT [dbo].[Assignments] ([assignmentID], [title], [description], [subDateTime], [oralMark], [totalMark]) VALUES (4, N'Odd-Even', N'In Odd-Even you bet if most of the KINO lottery numbers are ODD or EVEN or if it will be a DRAW', CAST(N'2020-08-01T00:00:00.000' AS DateTime), 50, 90)
SET IDENTITY_INSERT [dbo].[Assignments] OFF
GO
SET IDENTITY_INSERT [dbo].[AssignmentsPerCourse] ON 

INSERT [dbo].[AssignmentsPerCourse] ([ApC_ID], [course_ID], [assignment_ID]) VALUES (1, 1, 1)
INSERT [dbo].[AssignmentsPerCourse] ([ApC_ID], [course_ID], [assignment_ID]) VALUES (2, 1, 3)
INSERT [dbo].[AssignmentsPerCourse] ([ApC_ID], [course_ID], [assignment_ID]) VALUES (3, 1, 4)
INSERT [dbo].[AssignmentsPerCourse] ([ApC_ID], [course_ID], [assignment_ID]) VALUES (4, 2, 1)
INSERT [dbo].[AssignmentsPerCourse] ([ApC_ID], [course_ID], [assignment_ID]) VALUES (5, 2, 3)
INSERT [dbo].[AssignmentsPerCourse] ([ApC_ID], [course_ID], [assignment_ID]) VALUES (6, 3, 2)
INSERT [dbo].[AssignmentsPerCourse] ([ApC_ID], [course_ID], [assignment_ID]) VALUES (7, 3, 4)
INSERT [dbo].[AssignmentsPerCourse] ([ApC_ID], [course_ID], [assignment_ID]) VALUES (8, 4, 4)
SET IDENTITY_INSERT [dbo].[AssignmentsPerCourse] OFF
GO
SET IDENTITY_INSERT [dbo].[Courses] ON 

INSERT [dbo].[Courses] ([courseID], [title], [stream], [type], [start_date], [end_date]) VALUES (1, N'CB11', N'C#', N'Part Time', CAST(N'2020-06-15T00:00:00.000' AS DateTime), CAST(N'2021-01-15T00:00:00.000' AS DateTime))
INSERT [dbo].[Courses] ([courseID], [title], [stream], [type], [start_date], [end_date]) VALUES (2, N'CB11', N'Java', N'Full Time', CAST(N'2020-06-15T00:00:00.000' AS DateTime), CAST(N'2020-10-15T00:00:00.000' AS DateTime))
INSERT [dbo].[Courses] ([courseID], [title], [stream], [type], [start_date], [end_date]) VALUES (3, N'CB12', N'Python', N'Part Time', CAST(N'2020-10-05T00:00:00.000' AS DateTime), CAST(N'2021-04-05T00:00:00.000' AS DateTime))
INSERT [dbo].[Courses] ([courseID], [title], [stream], [type], [start_date], [end_date]) VALUES (4, N'CB12', N'JavaScript', N'Full Time', CAST(N'2020-10-05T00:00:00.000' AS DateTime), CAST(N'2021-01-05T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Courses] OFF
GO
SET IDENTITY_INSERT [dbo].[Students] ON 

INSERT [dbo].[Students] ([studentID], [firstName], [lastName], [dateOfBirth], [tuitionFees]) VALUES (1, N'George', N'Dermentzis', CAST(N'1995-11-06T00:00:00.000' AS DateTime), CAST(1800.00 AS Decimal(8, 2)))
INSERT [dbo].[Students] ([studentID], [firstName], [lastName], [dateOfBirth], [tuitionFees]) VALUES (2, N'Afroditi', N'Vlachou', CAST(N'1995-08-18T00:00:00.000' AS DateTime), CAST(2200.00 AS Decimal(8, 2)))
INSERT [dbo].[Students] ([studentID], [firstName], [lastName], [dateOfBirth], [tuitionFees]) VALUES (3, N'Giannis', N'Grigoriou', CAST(N'1995-05-08T00:00:00.000' AS DateTime), CAST(2500.00 AS Decimal(8, 2)))
INSERT [dbo].[Students] ([studentID], [firstName], [lastName], [dateOfBirth], [tuitionFees]) VALUES (4, N'Vasilis', N'Papadopoulos', CAST(N'1994-03-08T00:00:00.000' AS DateTime), CAST(2250.00 AS Decimal(8, 2)))
SET IDENTITY_INSERT [dbo].[Students] OFF
GO
SET IDENTITY_INSERT [dbo].[StudentsPerCourse] ON 

INSERT [dbo].[StudentsPerCourse] ([SpC_ID], [course_ID], [student_ID]) VALUES (1, 1, 1)
INSERT [dbo].[StudentsPerCourse] ([SpC_ID], [course_ID], [student_ID]) VALUES (2, 1, 4)
INSERT [dbo].[StudentsPerCourse] ([SpC_ID], [course_ID], [student_ID]) VALUES (3, 2, 2)
INSERT [dbo].[StudentsPerCourse] ([SpC_ID], [course_ID], [student_ID]) VALUES (4, 2, 3)
INSERT [dbo].[StudentsPerCourse] ([SpC_ID], [course_ID], [student_ID]) VALUES (5, 3, 3)
INSERT [dbo].[StudentsPerCourse] ([SpC_ID], [course_ID], [student_ID]) VALUES (6, 4, 1)
INSERT [dbo].[StudentsPerCourse] ([SpC_ID], [course_ID], [student_ID]) VALUES (7, 4, 2)
INSERT [dbo].[StudentsPerCourse] ([SpC_ID], [course_ID], [student_ID]) VALUES (8, 4, 3)
SET IDENTITY_INSERT [dbo].[StudentsPerCourse] OFF
GO
SET IDENTITY_INSERT [dbo].[Trainers] ON 

INSERT [dbo].[Trainers] ([trainerID], [firstName], [lastName], [subject]) VALUES (1, N'Aggelos', N'Vegkos', N'Python')
INSERT [dbo].[Trainers] ([trainerID], [firstName], [lastName], [subject]) VALUES (2, N'Mixalis', N'Xamilos', N'C#')
INSERT [dbo].[Trainers] ([trainerID], [firstName], [lastName], [subject]) VALUES (3, N'George', N'Pasparakis', N'Java')
INSERT [dbo].[Trainers] ([trainerID], [firstName], [lastName], [subject]) VALUES (4, N'Ektoras', N'Gkatsos', N'JavaScript')
SET IDENTITY_INSERT [dbo].[Trainers] OFF
GO
SET IDENTITY_INSERT [dbo].[TrainersPerCourse] ON 

INSERT [dbo].[TrainersPerCourse] ([TpC_ID], [course_ID], [trainer_ID]) VALUES (1, 1, 2)
INSERT [dbo].[TrainersPerCourse] ([TpC_ID], [course_ID], [trainer_ID]) VALUES (2, 1, 3)
INSERT [dbo].[TrainersPerCourse] ([TpC_ID], [course_ID], [trainer_ID]) VALUES (3, 2, 3)
INSERT [dbo].[TrainersPerCourse] ([TpC_ID], [course_ID], [trainer_ID]) VALUES (4, 2, 4)
INSERT [dbo].[TrainersPerCourse] ([TpC_ID], [course_ID], [trainer_ID]) VALUES (5, 3, 1)
INSERT [dbo].[TrainersPerCourse] ([TpC_ID], [course_ID], [trainer_ID]) VALUES (6, 3, 4)
INSERT [dbo].[TrainersPerCourse] ([TpC_ID], [course_ID], [trainer_ID]) VALUES (7, 4, 2)
INSERT [dbo].[TrainersPerCourse] ([TpC_ID], [course_ID], [trainer_ID]) VALUES (8, 4, 3)
INSERT [dbo].[TrainersPerCourse] ([TpC_ID], [course_ID], [trainer_ID]) VALUES (9, 4, 4)
SET IDENTITY_INSERT [dbo].[TrainersPerCourse] OFF
GO
ALTER TABLE [dbo].[AssignmentsPerCourse]  WITH CHECK ADD  CONSTRAINT [FK_AssignmentsPerCourse_Assignments] FOREIGN KEY([assignment_ID])
REFERENCES [dbo].[Assignments] ([assignmentID])
GO
ALTER TABLE [dbo].[AssignmentsPerCourse] CHECK CONSTRAINT [FK_AssignmentsPerCourse_Assignments]
GO
ALTER TABLE [dbo].[AssignmentsPerCourse]  WITH CHECK ADD  CONSTRAINT [FK_AssignmentsPerCourse_Courses] FOREIGN KEY([course_ID])
REFERENCES [dbo].[Courses] ([courseID])
GO
ALTER TABLE [dbo].[AssignmentsPerCourse] CHECK CONSTRAINT [FK_AssignmentsPerCourse_Courses]
GO
ALTER TABLE [dbo].[StudentsPerCourse]  WITH CHECK ADD  CONSTRAINT [FK_StudentsPerCourse_Courses] FOREIGN KEY([course_ID])
REFERENCES [dbo].[Courses] ([courseID])
GO
ALTER TABLE [dbo].[StudentsPerCourse] CHECK CONSTRAINT [FK_StudentsPerCourse_Courses]
GO
ALTER TABLE [dbo].[StudentsPerCourse]  WITH CHECK ADD  CONSTRAINT [FK_StudentsPerCourse_Students] FOREIGN KEY([student_ID])
REFERENCES [dbo].[Students] ([studentID])
GO
ALTER TABLE [dbo].[StudentsPerCourse] CHECK CONSTRAINT [FK_StudentsPerCourse_Students]
GO
ALTER TABLE [dbo].[TrainersPerCourse]  WITH CHECK ADD  CONSTRAINT [FK_TrainersPerCourse_Courses] FOREIGN KEY([course_ID])
REFERENCES [dbo].[Courses] ([courseID])
GO
ALTER TABLE [dbo].[TrainersPerCourse] CHECK CONSTRAINT [FK_TrainersPerCourse_Courses]
GO
ALTER TABLE [dbo].[TrainersPerCourse]  WITH CHECK ADD  CONSTRAINT [FK_TrainersPerCourse_Trainers] FOREIGN KEY([trainer_ID])
REFERENCES [dbo].[Trainers] ([trainerID])
GO
ALTER TABLE [dbo].[TrainersPerCourse] CHECK CONSTRAINT [FK_TrainersPerCourse_Trainers]
GO
