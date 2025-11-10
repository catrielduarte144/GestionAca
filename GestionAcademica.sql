USE [GestionAcademica]
GO
/****** Object:  Table [dbo].[alumno_documentacion]    Script Date: 27/10/2025 05:13:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[alumno_documentacion](
	[id_alumno] [int] NOT NULL,
	[partida_nacimiento] [bit] NULL,
	[certificado_vacunas] [bit] NULL,
	[fotocopia_dni] [bit] NULL,
	[otros_documentos] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_alumno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[alumnos]    Script Date: 27/10/2025 05:13:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[alumnos](
	[id_alumno] [int] IDENTITY(1,1) NOT NULL,
	[apellido] [varchar](255) NULL,
	[nombre] [varchar](255) NULL,
	[dni] [varchar](10) NULL,
	[estado] [varchar](50) NULL,
	[Id_usuario] [int] NULL,
	[legajo] [varchar](8) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_alumno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[alumnos_materias]    Script Date: 27/10/2025 05:13:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[alumnos_materias](
	[id_registro] [int] IDENTITY(1,1) NOT NULL,
	[id_alumno] [int] NOT NULL,
	[id_materia] [int] NOT NULL,
 CONSTRAINT [PK_alumnos_materias] PRIMARY KEY CLUSTERED 
(
	[id_alumno] ASC,
	[id_materia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[carreras]    Script Date: 27/10/2025 05:13:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[carreras](
	[id_carrera] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](255) NULL,
	[sede] [varchar](255) NULL,
	[estado] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_carrera] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[materias]    Script Date: 27/10/2025 05:13:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[materias](
	[id_materia] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](255) NULL,
	[id_profesor] [int] NULL,
	[id_carrera] [int] NULL,
	[estado] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_materia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Profesores]    Script Date: 27/10/2025 05:13:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profesores](
	[id_profesor] [int] IDENTITY(100000,1) NOT NULL,
	[apellido] [varchar](50) NOT NULL,
	[nombre] [varchar](50) NULL,
	[email] [varchar](100) NULL,
	[telefono] [varchar](20) NULL,
	[estado] [bit] NULL,
	[Id_usuario] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_profesor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuarios]    Script Date: 27/10/2025 05:13:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuarios](
	[id_usuario] [int] IDENTITY(1,1) NOT NULL,
	[usuario] [varchar](255) NULL,
	[clave] [varchar](255) NULL,
	[tipo] [varchar](50) NULL,
	[estado] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[alumnos] ON 

INSERT [dbo].[alumnos] ([id_alumno], [apellido], [nombre], [dni], [estado], [Id_usuario], [legajo]) VALUES (1, N'Maradona', N'Diego Armando', N'21.345.378', N'1', NULL, N'00000001')
INSERT [dbo].[alumnos] ([id_alumno], [apellido], [nombre], [dni], [estado], [Id_usuario], [legajo]) VALUES (2, N'Messi', N'Lionel', N'21.345.451', N'1', NULL, N'00000002')
INSERT [dbo].[alumnos] ([id_alumno], [apellido], [nombre], [dni], [estado], [Id_usuario], [legajo]) VALUES (3, N'Pele', N'Pelé', N'21.345.407', N'1', NULL, N'00000003')
INSERT [dbo].[alumnos] ([id_alumno], [apellido], [nombre], [dni], [estado], [Id_usuario], [legajo]) VALUES (4, N'Ronaldo', N'Cristiano', N'21.345.356', N'1', NULL, N'00000004')
INSERT [dbo].[alumnos] ([id_alumno], [apellido], [nombre], [dni], [estado], [Id_usuario], [legajo]) VALUES (5, N'Cruyff', N'Johan ', N'21.345.443', N'1', NULL, N'00000005')
INSERT [dbo].[alumnos] ([id_alumno], [apellido], [nombre], [dni], [estado], [Id_usuario], [legajo]) VALUES (6, N'Beckenbauer', N'Franz', N'21.345.860', N'1', NULL, N'00000006')
INSERT [dbo].[alumnos] ([id_alumno], [apellido], [nombre], [dni], [estado], [Id_usuario], [legajo]) VALUES (7, N'Di Stéfano', N'Alfredo', N'21.345.715', N'1', NULL, N'00000007')
INSERT [dbo].[alumnos] ([id_alumno], [apellido], [nombre], [dni], [estado], [Id_usuario], [legajo]) VALUES (8, N'Zidane', N'Zinedine', N'21.345.422', N'1', NULL, N'00000008')
INSERT [dbo].[alumnos] ([id_alumno], [apellido], [nombre], [dni], [estado], [Id_usuario], [legajo]) VALUES (9, N'Puskás', N'Ferenc', N'21.345.717', N'1', NULL, N'00000009')
INSERT [dbo].[alumnos] ([id_alumno], [apellido], [nombre], [dni], [estado], [Id_usuario], [legajo]) VALUES (10, N'Nazário', N'Ronaldo', N'21.345.071', N'1', NULL, N'00000010')
INSERT [dbo].[alumnos] ([id_alumno], [apellido], [nombre], [dni], [estado], [Id_usuario], [legajo]) VALUES (11, N'van Basten', N'Marco', N'21.345.035', N'1', NULL, N'00000011')
INSERT [dbo].[alumnos] ([id_alumno], [apellido], [nombre], [dni], [estado], [Id_usuario], [legajo]) VALUES (12, N'Platini', N'Michel', N'21.345.631', N'1', NULL, N'00000012')
INSERT [dbo].[alumnos] ([id_alumno], [apellido], [nombre], [dni], [estado], [Id_usuario], [legajo]) VALUES (13, N'Guerrero', N'Walter', N'25.521.521', N'1', NULL, N'00000013')
INSERT [dbo].[alumnos] ([id_alumno], [apellido], [nombre], [dni], [estado], [Id_usuario], [legajo]) VALUES (14, N'Charlton', N'Bobby', N'21.345.317', N'1', NULL, N'00000014')
INSERT [dbo].[alumnos] ([id_alumno], [apellido], [nombre], [dni], [estado], [Id_usuario], [legajo]) VALUES (15, N'Müller', N'Gerd', N'21.345.747', N'1', NULL, N'00000015')
INSERT [dbo].[alumnos] ([id_alumno], [apellido], [nombre], [dni], [estado], [Id_usuario], [legajo]) VALUES (16, N'Baresi', N'Franco', N'21.345.980', N'1', NULL, N'00000016')
INSERT [dbo].[alumnos] ([id_alumno], [apellido], [nombre], [dni], [estado], [Id_usuario], [legajo]) VALUES (17, N'Best', N'George', N'21.345.851', N'1', NULL, N'00000017')
INSERT [dbo].[alumnos] ([id_alumno], [apellido], [nombre], [dni], [estado], [Id_usuario], [legajo]) VALUES (18, N'Eusebio', N'Eusébio', N'21.345.547', N'1', NULL, N'00000018')
INSERT [dbo].[alumnos] ([id_alumno], [apellido], [nombre], [dni], [estado], [Id_usuario], [legajo]) VALUES (19, N'Baggio', N'Roberto', N'21.345.488', N'1', NULL, N'00000019')
INSERT [dbo].[alumnos] ([id_alumno], [apellido], [nombre], [dni], [estado], [Id_usuario], [legajo]) VALUES (20, N'Romario', N'Romário', N'21.345.409', N'1', NULL, N'00000020')
INSERT [dbo].[alumnos] ([id_alumno], [apellido], [nombre], [dni], [estado], [Id_usuario], [legajo]) VALUES (21, N'Maldini', N'Paolo', N'21.345.490', N'1', NULL, N'00000021')
INSERT [dbo].[alumnos] ([id_alumno], [apellido], [nombre], [dni], [estado], [Id_usuario], [legajo]) VALUES (22, N'Yashin', N'Lev', N'21.345.467', N'1', NULL, N'00000022')
INSERT [dbo].[alumnos] ([id_alumno], [apellido], [nombre], [dni], [estado], [Id_usuario], [legajo]) VALUES (23, N'Hernández', N'Xavi', N'21.345.796', N'1', NULL, N'00000023')
INSERT [dbo].[alumnos] ([id_alumno], [apellido], [nombre], [dni], [estado], [Id_usuario], [legajo]) VALUES (24, N'Iniesta', N'Andrés', N'21.345.263', N'1', NULL, N'00000024')
INSERT [dbo].[alumnos] ([id_alumno], [apellido], [nombre], [dni], [estado], [Id_usuario], [legajo]) VALUES (25, N'Matthäus', N'Lothar', N'21.345.911', N'1', NULL, N'00000025')
INSERT [dbo].[alumnos] ([id_alumno], [apellido], [nombre], [dni], [estado], [Id_usuario], [legajo]) VALUES (26, N'Gullit', N'Ruud', N'21.345.895', N'1', NULL, N'00000026')
INSERT [dbo].[alumnos] ([id_alumno], [apellido], [nombre], [dni], [estado], [Id_usuario], [legajo]) VALUES (27, N'Dalglish', N'Kenny', N'21.345.521', N'1', NULL, N'00000027')
INSERT [dbo].[alumnos] ([id_alumno], [apellido], [nombre], [dni], [estado], [Id_usuario], [legajo]) VALUES (28, N'Matthews', N'Stanley', N'21.345.476', N'1', NULL, N'00000028')
INSERT [dbo].[alumnos] ([id_alumno], [apellido], [nombre], [dni], [estado], [Id_usuario], [legajo]) VALUES (29, N'Meazza', N'Giuseppe', N'21.345.961', N'1', NULL, N'00000029')
INSERT [dbo].[alumnos] ([id_alumno], [apellido], [nombre], [dni], [estado], [Id_usuario], [legajo]) VALUES (30, N'Kopa', N'Raymond', N'21.345.345', N'1', NULL, N'00000030')
INSERT [dbo].[alumnos] ([id_alumno], [apellido], [nombre], [dni], [estado], [Id_usuario], [legajo]) VALUES (31, N'Moore', N'Bobby', N'21.345.846', N'1', NULL, N'00000031')
INSERT [dbo].[alumnos] ([id_alumno], [apellido], [nombre], [dni], [estado], [Id_usuario], [legajo]) VALUES (32, N'Sánchez', N'Hugo', N'21.345.963', N'1', NULL, N'00000032')
INSERT [dbo].[alumnos] ([id_alumno], [apellido], [nombre], [dni], [estado], [Id_usuario], [legajo]) VALUES (33, N'Weah', N'George', N'21.345.856', N'1', NULL, N'00000033')
INSERT [dbo].[alumnos] ([id_alumno], [apellido], [nombre], [dni], [estado], [Id_usuario], [legajo]) VALUES (34, N'Stoichkov', N'Hristo', N'21.345.820', N'1', NULL, N'00000034')
INSERT [dbo].[alumnos] ([id_alumno], [apellido], [nombre], [dni], [estado], [Id_usuario], [legajo]) VALUES (35, N'Bergkamp', N'Dennis', N'21.345.350', N'1', NULL, N'00000035')
INSERT [dbo].[alumnos] ([id_alumno], [apellido], [nombre], [dni], [estado], [Id_usuario], [legajo]) VALUES (36, N'Cantona', N'Eric', N'21.345.110', N'1', NULL, N'00000036')
INSERT [dbo].[alumnos] ([id_alumno], [apellido], [nombre], [dni], [estado], [Id_usuario], [legajo]) VALUES (37, N'Beckenbauer', N'Franz', N'21.345.548', N'1', NULL, N'00000037')
INSERT [dbo].[alumnos] ([id_alumno], [apellido], [nombre], [dni], [estado], [Id_usuario], [legajo]) VALUES (38, N'Rossi', N'Paolo', N'21.345.252', N'1', NULL, N'00000038')
INSERT [dbo].[alumnos] ([id_alumno], [apellido], [nombre], [dni], [estado], [Id_usuario], [legajo]) VALUES (39, N'Dalglish', N'Kenny', N'21.345.240', N'1', NULL, N'00000039')
INSERT [dbo].[alumnos] ([id_alumno], [apellido], [nombre], [dni], [estado], [Id_usuario], [legajo]) VALUES (40, N'Schmeichel', N'Peter', N'21.345.917', N'1', NULL, N'00000040')
INSERT [dbo].[alumnos] ([id_alumno], [apellido], [nombre], [dni], [estado], [Id_usuario], [legajo]) VALUES (41, N'Buffon', N'Gianluigi', N'21.345.390', N'1', NULL, N'00000041')
INSERT [dbo].[alumnos] ([id_alumno], [apellido], [nombre], [dni], [estado], [Id_usuario], [legajo]) VALUES (42, N'Modric', N'Luka', N'21.345.773', N'1', NULL, N'00000042')
INSERT [dbo].[alumnos] ([id_alumno], [apellido], [nombre], [dni], [estado], [Id_usuario], [legajo]) VALUES (43, N'Mbappé', N'Kylian', N'21.345.402', N'1', NULL, N'00000043')
INSERT [dbo].[alumnos] ([id_alumno], [apellido], [nombre], [dni], [estado], [Id_usuario], [legajo]) VALUES (44, N'Neeskens', N'Johan', N'21.345.157', N'1', NULL, N'00000044')
SET IDENTITY_INSERT [dbo].[alumnos] OFF
GO
SET IDENTITY_INSERT [dbo].[alumnos_materias] ON 

INSERT [dbo].[alumnos_materias] ([id_registro], [id_alumno], [id_materia]) VALUES (1, 1, 5)
INSERT [dbo].[alumnos_materias] ([id_registro], [id_alumno], [id_materia]) VALUES (2, 2, 12)
INSERT [dbo].[alumnos_materias] ([id_registro], [id_alumno], [id_materia]) VALUES (3, 3, 28)
INSERT [dbo].[alumnos_materias] ([id_registro], [id_alumno], [id_materia]) VALUES (4, 4, 41)
INSERT [dbo].[alumnos_materias] ([id_registro], [id_alumno], [id_materia]) VALUES (5, 5, 1)
INSERT [dbo].[alumnos_materias] ([id_registro], [id_alumno], [id_materia]) VALUES (6, 6, 18)
INSERT [dbo].[alumnos_materias] ([id_registro], [id_alumno], [id_materia]) VALUES (7, 7, 33)
INSERT [dbo].[alumnos_materias] ([id_registro], [id_alumno], [id_materia]) VALUES (8, 8, 48)
INSERT [dbo].[alumnos_materias] ([id_registro], [id_alumno], [id_materia]) VALUES (9, 9, 10)
INSERT [dbo].[alumnos_materias] ([id_registro], [id_alumno], [id_materia]) VALUES (10, 10, 25)
INSERT [dbo].[alumnos_materias] ([id_registro], [id_alumno], [id_materia]) VALUES (11, 11, 39)
INSERT [dbo].[alumnos_materias] ([id_registro], [id_alumno], [id_materia]) VALUES (12, 12, 45)
INSERT [dbo].[alumnos_materias] ([id_registro], [id_alumno], [id_materia]) VALUES (13, 13, 15)
INSERT [dbo].[alumnos_materias] ([id_registro], [id_alumno], [id_materia]) VALUES (14, 14, 30)
INSERT [dbo].[alumnos_materias] ([id_registro], [id_alumno], [id_materia]) VALUES (15, 15, 43)
INSERT [dbo].[alumnos_materias] ([id_registro], [id_alumno], [id_materia]) VALUES (16, 16, 2)
INSERT [dbo].[alumnos_materias] ([id_registro], [id_alumno], [id_materia]) VALUES (17, 17, 20)
INSERT [dbo].[alumnos_materias] ([id_registro], [id_alumno], [id_materia]) VALUES (18, 18, 37)
INSERT [dbo].[alumnos_materias] ([id_registro], [id_alumno], [id_materia]) VALUES (19, 19, 49)
INSERT [dbo].[alumnos_materias] ([id_registro], [id_alumno], [id_materia]) VALUES (20, 20, 8)
INSERT [dbo].[alumnos_materias] ([id_registro], [id_alumno], [id_materia]) VALUES (21, 21, 22)
INSERT [dbo].[alumnos_materias] ([id_registro], [id_alumno], [id_materia]) VALUES (22, 22, 35)
INSERT [dbo].[alumnos_materias] ([id_registro], [id_alumno], [id_materia]) VALUES (23, 23, 47)
INSERT [dbo].[alumnos_materias] ([id_registro], [id_alumno], [id_materia]) VALUES (24, 24, 13)
INSERT [dbo].[alumnos_materias] ([id_registro], [id_alumno], [id_materia]) VALUES (25, 25, 27)
INSERT [dbo].[alumnos_materias] ([id_registro], [id_alumno], [id_materia]) VALUES (26, 26, 40)
INSERT [dbo].[alumnos_materias] ([id_registro], [id_alumno], [id_materia]) VALUES (27, 27, 4)
INSERT [dbo].[alumnos_materias] ([id_registro], [id_alumno], [id_materia]) VALUES (28, 28, 17)
INSERT [dbo].[alumnos_materias] ([id_registro], [id_alumno], [id_materia]) VALUES (29, 29, 31)
INSERT [dbo].[alumnos_materias] ([id_registro], [id_alumno], [id_materia]) VALUES (30, 30, 46)
INSERT [dbo].[alumnos_materias] ([id_registro], [id_alumno], [id_materia]) VALUES (31, 31, 9)
INSERT [dbo].[alumnos_materias] ([id_registro], [id_alumno], [id_materia]) VALUES (32, 32, 24)
INSERT [dbo].[alumnos_materias] ([id_registro], [id_alumno], [id_materia]) VALUES (33, 33, 38)
INSERT [dbo].[alumnos_materias] ([id_registro], [id_alumno], [id_materia]) VALUES (34, 34, 50)
INSERT [dbo].[alumnos_materias] ([id_registro], [id_alumno], [id_materia]) VALUES (35, 35, 11)
INSERT [dbo].[alumnos_materias] ([id_registro], [id_alumno], [id_materia]) VALUES (36, 36, 29)
INSERT [dbo].[alumnos_materias] ([id_registro], [id_alumno], [id_materia]) VALUES (37, 37, 42)
INSERT [dbo].[alumnos_materias] ([id_registro], [id_alumno], [id_materia]) VALUES (38, 38, 3)
INSERT [dbo].[alumnos_materias] ([id_registro], [id_alumno], [id_materia]) VALUES (39, 39, 19)
INSERT [dbo].[alumnos_materias] ([id_registro], [id_alumno], [id_materia]) VALUES (40, 40, 34)
INSERT [dbo].[alumnos_materias] ([id_registro], [id_alumno], [id_materia]) VALUES (41, 41, 44)
INSERT [dbo].[alumnos_materias] ([id_registro], [id_alumno], [id_materia]) VALUES (42, 42, 16)
INSERT [dbo].[alumnos_materias] ([id_registro], [id_alumno], [id_materia]) VALUES (43, 43, 32)
INSERT [dbo].[alumnos_materias] ([id_registro], [id_alumno], [id_materia]) VALUES (44, 1, 21)
INSERT [dbo].[alumnos_materias] ([id_registro], [id_alumno], [id_materia]) VALUES (45, 5, 36)
INSERT [dbo].[alumnos_materias] ([id_registro], [id_alumno], [id_materia]) VALUES (46, 10, 49)
INSERT [dbo].[alumnos_materias] ([id_registro], [id_alumno], [id_materia]) VALUES (47, 15, 7)
INSERT [dbo].[alumnos_materias] ([id_registro], [id_alumno], [id_materia]) VALUES (48, 20, 26)
INSERT [dbo].[alumnos_materias] ([id_registro], [id_alumno], [id_materia]) VALUES (49, 25, 41)
INSERT [dbo].[alumnos_materias] ([id_registro], [id_alumno], [id_materia]) VALUES (50, 30, 14)
INSERT [dbo].[alumnos_materias] ([id_registro], [id_alumno], [id_materia]) VALUES (51, 35, 30)
INSERT [dbo].[alumnos_materias] ([id_registro], [id_alumno], [id_materia]) VALUES (52, 40, 45)
INSERT [dbo].[alumnos_materias] ([id_registro], [id_alumno], [id_materia]) VALUES (53, 2, 7)
INSERT [dbo].[alumnos_materias] ([id_registro], [id_alumno], [id_materia]) VALUES (54, 2, 6)
INSERT [dbo].[alumnos_materias] ([id_registro], [id_alumno], [id_materia]) VALUES (55, 6, 20)
INSERT [dbo].[alumnos_materias] ([id_registro], [id_alumno], [id_materia]) VALUES (57, 8, 20)
INSERT [dbo].[alumnos_materias] ([id_registro], [id_alumno], [id_materia]) VALUES (58, 2, 3)
INSERT [dbo].[alumnos_materias] ([id_registro], [id_alumno], [id_materia]) VALUES (59, 2, 4)
INSERT [dbo].[alumnos_materias] ([id_registro], [id_alumno], [id_materia]) VALUES (60, 4, 50)
INSERT [dbo].[alumnos_materias] ([id_registro], [id_alumno], [id_materia]) VALUES (61, 36, 33)
SET IDENTITY_INSERT [dbo].[alumnos_materias] OFF
GO
SET IDENTITY_INSERT [dbo].[carreras] ON 

INSERT [dbo].[carreras] ([id_carrera], [nombre], [sede], [estado]) VALUES (1, N'Tecnico Superior en Programación', N'Escobar', N'1')
INSERT [dbo].[carreras] ([id_carrera], [nombre], [sede], [estado]) VALUES (2, N'Tecnico Superior en Logistica', N'Pilar', N'1')
INSERT [dbo].[carreras] ([id_carrera], [nombre], [sede], [estado]) VALUES (3, N'Tecnico Superior en Mantenimiento', N'Pilar', N'1')
SET IDENTITY_INSERT [dbo].[carreras] OFF
GO
SET IDENTITY_INSERT [dbo].[materias] ON 

INSERT [dbo].[materias] ([id_materia], [nombre], [id_profesor], [id_carrera], [estado]) VALUES (1, N'Algoritmos y Estructuras de Datos I', 100000, 1, N'1')
INSERT [dbo].[materias] ([id_materia], [nombre], [id_profesor], [id_carrera], [estado]) VALUES (2, N'Matemática Discreta', 100001, 1, N'1')
INSERT [dbo].[materias] ([id_materia], [nombre], [id_profesor], [id_carrera], [estado]) VALUES (3, N'Introducción a la Programación', 100002, 1, N'1')
INSERT [dbo].[materias] ([id_materia], [nombre], [id_profesor], [id_carrera], [estado]) VALUES (4, N'Arquitectura de Computadoras', 100003, 1, N'1')
INSERT [dbo].[materias] ([id_materia], [nombre], [id_profesor], [id_carrera], [estado]) VALUES (5, N'Lógica', 100004, 1, N'1')
INSERT [dbo].[materias] ([id_materia], [nombre], [id_profesor], [id_carrera], [estado]) VALUES (6, N'Algoritmos y Estructuras de Datos II', 100005, 1, N'1')
INSERT [dbo].[materias] ([id_materia], [nombre], [id_profesor], [id_carrera], [estado]) VALUES (7, N'Programación Orientada a Objetos I', 100006, 1, N'1')
INSERT [dbo].[materias] ([id_materia], [nombre], [id_profesor], [id_carrera], [estado]) VALUES (8, N'Sistemas Operativos', 100007, 1, N'1')
INSERT [dbo].[materias] ([id_materia], [nombre], [id_profesor], [id_carrera], [estado]) VALUES (9, N'Probabilidad y Estadística', 100008, 1, N'1')
INSERT [dbo].[materias] ([id_materia], [nombre], [id_profesor], [id_carrera], [estado]) VALUES (10, N'Base de Datos I', 100009, 1, N'1')
INSERT [dbo].[materias] ([id_materia], [nombre], [id_profesor], [id_carrera], [estado]) VALUES (11, N'Programación Orientada a Objetos II', 100010, 1, N'1')
INSERT [dbo].[materias] ([id_materia], [nombre], [id_profesor], [id_carrera], [estado]) VALUES (12, N'Redes de Computadoras', 100011, 1, N'1')
INSERT [dbo].[materias] ([id_materia], [nombre], [id_profesor], [id_carrera], [estado]) VALUES (13, N'Ingeniería de Software I', 100012, 1, N'1')
INSERT [dbo].[materias] ([id_materia], [nombre], [id_profesor], [id_carrera], [estado]) VALUES (14, N'Base de Datos II', 100013, 1, N'1')
INSERT [dbo].[materias] ([id_materia], [nombre], [id_profesor], [id_carrera], [estado]) VALUES (15, N'Programación Web I', 100014, 1, N'1')
INSERT [dbo].[materias] ([id_materia], [nombre], [id_profesor], [id_carrera], [estado]) VALUES (16, N'Seguridad Informática', 100000, 1, N'1')
INSERT [dbo].[materias] ([id_materia], [nombre], [id_profesor], [id_carrera], [estado]) VALUES (17, N'Ingeniería de Software II', 100001, 1, N'1')
INSERT [dbo].[materias] ([id_materia], [nombre], [id_profesor], [id_carrera], [estado]) VALUES (18, N'Programación Web II', 100002, 1, N'1')
INSERT [dbo].[materias] ([id_materia], [nombre], [id_profesor], [id_carrera], [estado]) VALUES (19, N'Optativa I', 100003, 1, N'1')
INSERT [dbo].[materias] ([id_materia], [nombre], [id_profesor], [id_carrera], [estado]) VALUES (20, N'Optativa II', 100004, 1, N'1')
INSERT [dbo].[materias] ([id_materia], [nombre], [id_profesor], [id_carrera], [estado]) VALUES (21, N'Introducción a la Logística', 100005, 2, N'1')
INSERT [dbo].[materias] ([id_materia], [nombre], [id_profesor], [id_carrera], [estado]) VALUES (22, N'Matemática Aplicada', 100006, 2, N'1')
INSERT [dbo].[materias] ([id_materia], [nombre], [id_profesor], [id_carrera], [estado]) VALUES (23, N'Administración General', 100007, 2, N'1')
INSERT [dbo].[materias] ([id_materia], [nombre], [id_profesor], [id_carrera], [estado]) VALUES (24, N'Economía General', 100008, 2, N'1')
INSERT [dbo].[materias] ([id_materia], [nombre], [id_profesor], [id_carrera], [estado]) VALUES (25, N'Estadística', 100009, 2, N'1')
INSERT [dbo].[materias] ([id_materia], [nombre], [id_profesor], [id_carrera], [estado]) VALUES (26, N'Gestión de Stocks e Inventarios', 100010, 2, N'1')
INSERT [dbo].[materias] ([id_materia], [nombre], [id_profesor], [id_carrera], [estado]) VALUES (27, N'Costos Logísticos', 100011, 2, N'1')
INSERT [dbo].[materias] ([id_materia], [nombre], [id_profesor], [id_carrera], [estado]) VALUES (28, N'Transporte y Distribución', 100012, 2, N'1')
INSERT [dbo].[materias] ([id_materia], [nombre], [id_profesor], [id_carrera], [estado]) VALUES (29, N'Comercio Internacional', 100013, 2, N'1')
INSERT [dbo].[materias] ([id_materia], [nombre], [id_profesor], [id_carrera], [estado]) VALUES (30, N'Legislación y Normativa del Transporte', 100014, 2, N'1')
INSERT [dbo].[materias] ([id_materia], [nombre], [id_profesor], [id_carrera], [estado]) VALUES (31, N'Tecnologías de la Información en Logística', 100000, 2, N'1')
INSERT [dbo].[materias] ([id_materia], [nombre], [id_profesor], [id_carrera], [estado]) VALUES (32, N'Almacenamiento y Centros de Distribución', 100001, 2, N'1')
INSERT [dbo].[materias] ([id_materia], [nombre], [id_profesor], [id_carrera], [estado]) VALUES (33, N'Planificación de la Cadena de Suministro', 100002, 2, N'1')
INSERT [dbo].[materias] ([id_materia], [nombre], [id_profesor], [id_carrera], [estado]) VALUES (34, N'Calidad y Mejora Continua en Logística', 100003, 2, N'1')
INSERT [dbo].[materias] ([id_materia], [nombre], [id_profesor], [id_carrera], [estado]) VALUES (35, N'Logística Inversa', 100004, 2, N'1')
INSERT [dbo].[materias] ([id_materia], [nombre], [id_profesor], [id_carrera], [estado]) VALUES (36, N'Introducción al Mantenimiento', 100005, 3, N'1')
INSERT [dbo].[materias] ([id_materia], [nombre], [id_profesor], [id_carrera], [estado]) VALUES (37, N'Dibujo Técnico', 100006, 3, N'1')
INSERT [dbo].[materias] ([id_materia], [nombre], [id_profesor], [id_carrera], [estado]) VALUES (38, N'Física Aplicada', 100007, 3, N'1')
INSERT [dbo].[materias] ([id_materia], [nombre], [id_profesor], [id_carrera], [estado]) VALUES (39, N'Química General', 100008, 3, N'1')
INSERT [dbo].[materias] ([id_materia], [nombre], [id_profesor], [id_carrera], [estado]) VALUES (40, N'Electricidad y Magnetismo', 100009, 3, N'1')
INSERT [dbo].[materias] ([id_materia], [nombre], [id_profesor], [id_carrera], [estado]) VALUES (41, N'Mecánica de Fluidos', 100010, 3, N'1')
INSERT [dbo].[materias] ([id_materia], [nombre], [id_profesor], [id_carrera], [estado]) VALUES (42, N'Termodinámica', 100011, 3, N'1')
INSERT [dbo].[materias] ([id_materia], [nombre], [id_profesor], [id_carrera], [estado]) VALUES (43, N'Resistencia de Materiales', 100012, 3, N'1')
INSERT [dbo].[materias] ([id_materia], [nombre], [id_profesor], [id_carrera], [estado]) VALUES (44, N'Elementos de Máquinas', 100013, 3, N'1')
INSERT [dbo].[materias] ([id_materia], [nombre], [id_profesor], [id_carrera], [estado]) VALUES (45, N'Mantenimiento Mecánico', 100014, 3, N'1')
INSERT [dbo].[materias] ([id_materia], [nombre], [id_profesor], [id_carrera], [estado]) VALUES (46, N'Mantenimiento Eléctrico', 100000, 3, N'1')
INSERT [dbo].[materias] ([id_materia], [nombre], [id_profesor], [id_carrera], [estado]) VALUES (47, N'Instrumentación y Control', 100001, 3, N'1')
INSERT [dbo].[materias] ([id_materia], [nombre], [id_profesor], [id_carrera], [estado]) VALUES (48, N'Gestión del Mantenimiento', 100002, 3, N'1')
INSERT [dbo].[materias] ([id_materia], [nombre], [id_profesor], [id_carrera], [estado]) VALUES (49, N'Seguridad e Higiene Industrial', 100003, 3, N'1')
INSERT [dbo].[materias] ([id_materia], [nombre], [id_profesor], [id_carrera], [estado]) VALUES (50, N'Mantenimiento Predictivo', 100004, 3, N'1')
SET IDENTITY_INSERT [dbo].[materias] OFF
GO
SET IDENTITY_INSERT [dbo].[Profesores] ON 

INSERT [dbo].[Profesores] ([id_profesor], [apellido], [nombre], [email], [telefono], [estado], [Id_usuario]) VALUES (100000, N'Einstein', N'Albert', N'albert.e@example.com', N'11-1234-5678', 1, NULL)
INSERT [dbo].[Profesores] ([id_profesor], [apellido], [nombre], [email], [telefono], [estado], [Id_usuario]) VALUES (100001, N'Curie', N'Marie', N'marie.c@example.org', N'11-9876-5432', 1, NULL)
INSERT [dbo].[Profesores] ([id_profesor], [apellido], [nombre], [email], [telefono], [estado], [Id_usuario]) VALUES (100002, N'Hawking', N'Stephen', N'stephen.h@sample.net', N'11-5555-1212', 1, NULL)
INSERT [dbo].[Profesores] ([id_profesor], [apellido], [nombre], [email], [telefono], [estado], [Id_usuario]) VALUES (100003, N'Newton', N'Isaac', N'isaac.n@domain.info', N'11-3333-9999', 1, NULL)
INSERT [dbo].[Profesores] ([id_profesor], [apellido], [nombre], [email], [telefono], [estado], [Id_usuario]) VALUES (100004, N'Galilei', N'Galileo', N'galileo.g@mymail.com', N'11-7777-8888', 1, NULL)
INSERT [dbo].[Profesores] ([id_profesor], [apellido], [nombre], [email], [telefono], [estado], [Id_usuario]) VALUES (100005, N'Darwin', N'Charles', N'charles.d@email.co', N'11-2222-6666', 1, NULL)
INSERT [dbo].[Profesores] ([id_profesor], [apellido], [nombre], [email], [telefono], [estado], [Id_usuario]) VALUES (100006, N'Platón', NULL, N'platon@academy.edu', N'11-4444-0000', 1, NULL)
INSERT [dbo].[Profesores] ([id_profesor], [apellido], [nombre], [email], [telefono], [estado], [Id_usuario]) VALUES (100007, N'Sócrates', NULL, N'socrates@athens.gov', N'11-6666-3333', 1, NULL)
INSERT [dbo].[Profesores] ([id_profesor], [apellido], [nombre], [email], [telefono], [estado], [Id_usuario]) VALUES (100008, N'Aristóteles', NULL, N'aristoteles@lyceum.net', N'11-8888-1111', 1, NULL)
INSERT [dbo].[Profesores] ([id_profesor], [apellido], [nombre], [email], [telefono], [estado], [Id_usuario]) VALUES (100009, N'Da Vinci', N'Leonardo', N'leonardo.v@art.com', N'11-0101-2323', 1, NULL)
INSERT [dbo].[Profesores] ([id_profesor], [apellido], [nombre], [email], [telefono], [estado], [Id_usuario]) VALUES (100010, N'Shakespeare', N'William', N'william.s@globe.theatre', N'11-4545-6767', 1, NULL)
INSERT [dbo].[Profesores] ([id_profesor], [apellido], [nombre], [email], [telefono], [estado], [Id_usuario]) VALUES (100011, N'Bach', N'Johann Sebastian', N'johann.b@music.org', N'11-2121-8989', 1, NULL)
INSERT [dbo].[Profesores] ([id_profesor], [apellido], [nombre], [email], [telefono], [estado], [Id_usuario]) VALUES (100012, N'Beethoven', N'Ludwig van', N'ludwig.b@classic.net', N'11-7878-5656', 1, NULL)
INSERT [dbo].[Profesores] ([id_profesor], [apellido], [nombre], [email], [telefono], [estado], [Id_usuario]) VALUES (100013, N'Van Gogh', N'Vincent', N'vincent.g@artistic.info', N'11-3434-9090', 1, NULL)
INSERT [dbo].[Profesores] ([id_profesor], [apellido], [nombre], [email], [telefono], [estado], [Id_usuario]) VALUES (100014, N'Mozart', N'Wolfgang Amadeus', N'wolfgang.m@musical.co', N'11-9191-2323', 1, NULL)
SET IDENTITY_INSERT [dbo].[Profesores] OFF
GO
/****** Object:  Index [UQ_id_registro]    Script Date: 27/10/2025 05:13:46 ******/
ALTER TABLE [dbo].[alumnos_materias] ADD  CONSTRAINT [UQ_id_registro] UNIQUE NONCLUSTERED 
(
	[id_registro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[alumno_documentacion]  WITH CHECK ADD FOREIGN KEY([id_alumno])
REFERENCES [dbo].[alumnos] ([id_alumno])
GO
ALTER TABLE [dbo].[alumnos]  WITH CHECK ADD FOREIGN KEY([Id_usuario])
REFERENCES [dbo].[usuarios] ([id_usuario])
GO
ALTER TABLE [dbo].[alumnos_materias]  WITH CHECK ADD  CONSTRAINT [FK_alumnos_materia_mat] FOREIGN KEY([id_alumno])
REFERENCES [dbo].[alumnos] ([id_alumno])
GO
ALTER TABLE [dbo].[alumnos_materias] CHECK CONSTRAINT [FK_alumnos_materia_mat]
GO
ALTER TABLE [dbo].[alumnos_materias]  WITH CHECK ADD  CONSTRAINT [FK_alumnos_materia_materias] FOREIGN KEY([id_materia])
REFERENCES [dbo].[materias] ([id_materia])
GO
ALTER TABLE [dbo].[alumnos_materias] CHECK CONSTRAINT [FK_alumnos_materia_materias]
GO
ALTER TABLE [dbo].[materias]  WITH CHECK ADD FOREIGN KEY([id_carrera])
REFERENCES [dbo].[carreras] ([id_carrera])
GO
ALTER TABLE [dbo].[materias]  WITH CHECK ADD  CONSTRAINT [FK__materias__id_pro__48CFD27E] FOREIGN KEY([id_profesor])
REFERENCES [dbo].[Profesores] ([id_profesor])
GO
ALTER TABLE [dbo].[materias] CHECK CONSTRAINT [FK__materias__id_pro__48CFD27E]
GO
ALTER TABLE [dbo].[Profesores]  WITH CHECK ADD  CONSTRAINT [FK__profesore__Id_us__49C3F6B7] FOREIGN KEY([Id_usuario])
REFERENCES [dbo].[usuarios] ([id_usuario])
GO
ALTER TABLE [dbo].[Profesores] CHECK CONSTRAINT [FK__profesore__Id_us__49C3F6B7]
GO 