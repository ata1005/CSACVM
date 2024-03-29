USE [master]
GO
/****** Object:  Database [CSA_CVM]    Script Date: 08/06/2023 12:45:21 ******/
CREATE DATABASE [CSA_CVM]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CSA_CVM', FILENAME = N'C:\Users\alext\CSA_CVM.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CSA_CVM_log', FILENAME = N'C:\Users\alext\CSA_CVM_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [CSA_CVM] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CSA_CVM].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CSA_CVM] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CSA_CVM] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CSA_CVM] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CSA_CVM] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CSA_CVM] SET ARITHABORT OFF 
GO
ALTER DATABASE [CSA_CVM] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [CSA_CVM] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CSA_CVM] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CSA_CVM] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CSA_CVM] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CSA_CVM] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CSA_CVM] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CSA_CVM] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CSA_CVM] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CSA_CVM] SET  ENABLE_BROKER 
GO
ALTER DATABASE [CSA_CVM] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CSA_CVM] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CSA_CVM] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CSA_CVM] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CSA_CVM] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CSA_CVM] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [CSA_CVM] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CSA_CVM] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CSA_CVM] SET  MULTI_USER 
GO
ALTER DATABASE [CSA_CVM] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CSA_CVM] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CSA_CVM] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CSA_CVM] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CSA_CVM] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CSA_CVM] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [CSA_CVM] SET QUERY_STORE = OFF
GO
USE [CSA_CVM]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 08/06/2023 12:45:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AptitudCV]    Script Date: 08/06/2023 12:45:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AptitudCV](
	[IdAptitudCV] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](max) NOT NULL,
	[IdCurriculum] [int] NULL,
	[UsuarioCreacion] [int] NULL,
	[FechaCreacion] [datetime2](7) NULL,
	[ProcesoCreacion] [nvarchar](255) NULL,
	[UsuarioActualizacion] [int] NULL,
	[FechaActualizacion] [datetime2](7) NULL,
	[ProcesoActualizacion] [nvarchar](255) NULL,
 CONSTRAINT [PK_AptitudCV] PRIMARY KEY CLUSTERED 
(
	[IdAptitudCV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contacto]    Script Date: 08/06/2023 12:45:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contacto](
	[IdContacto] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[IdUsuarioAgregado] [int] NOT NULL,
	[UsuarioCreacion] [int] NULL,
	[FechaCreacion] [datetime2](7) NULL,
	[ProcesoCreacion] [nvarchar](255) NULL,
	[UsuarioActualizacion] [int] NULL,
	[FechaActualizacion] [datetime2](7) NULL,
	[ProcesoActualizacion] [nvarchar](255) NULL,
 CONSTRAINT [PK_Contacto] PRIMARY KEY CLUSTERED 
(
	[IdContacto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Curriculum]    Script Date: 08/06/2023 12:45:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Curriculum](
	[IdCurriculum] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[FechaCurriculum] [datetime2](7) NULL,
	[UsuarioCreacion] [int] NULL,
	[FechaCreacion] [datetime2](7) NULL,
	[ProcesoCreacion] [nvarchar](255) NULL,
	[UsuarioActualizacion] [int] NULL,
	[FechaActualizacion] [datetime2](7) NULL,
	[ProcesoActualizacion] [nvarchar](255) NULL,
	[Titulo] [nvarchar](max) NULL,
 CONSTRAINT [PK_Curriculum] PRIMARY KEY CLUSTERED 
(
	[IdCurriculum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Departamento]    Script Date: 08/06/2023 12:45:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departamento](
	[Descripcion] [nvarchar](50) NOT NULL,
	[Codigo] [nvarchar](max) NULL,
	[IdDepartamento] [int] IDENTITY(1,1) NOT NULL,
	[FechaActualizacion] [datetime2](7) NULL,
	[FechaCreacion] [datetime2](7) NULL,
	[ProcesoActualizacion] [nvarchar](255) NULL,
	[ProcesoCreacion] [nvarchar](255) NULL,
	[UsuarioActualizacion] [int] NULL,
	[UsuarioCreacion] [int] NULL,
 CONSTRAINT [PK_Departamento] PRIMARY KEY CLUSTERED 
(
	[IdDepartamento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Entrada]    Script Date: 08/06/2023 12:45:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Entrada](
	[IdEntrada] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[IdProyecto] [int] NULL,
	[Lenguaje] [nvarchar](10) NULL,
	[TituloIssue] [nvarchar](50) NULL,
	[Descripcion] [nvarchar](150) NOT NULL,
	[Editada] [bit] NOT NULL,
	[Resuelta] [bit] NOT NULL,
	[NumRespuestas] [int] NOT NULL,
	[FechaCreacion] [datetime2](7) NULL,
	[FechaActualizacion] [datetime2](7) NULL,
	[ProcesoActualizacion] [nvarchar](255) NULL,
	[ProcesoCreacion] [nvarchar](255) NULL,
	[UsuarioActualizacion] [int] NULL,
	[UsuarioCreacion] [int] NULL,
 CONSTRAINT [PK_Entrada] PRIMARY KEY CLUSTERED 
(
	[IdEntrada] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EntradaCV]    Script Date: 08/06/2023 12:45:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EntradaCV](
	[IdEntradaCV] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[PuestoTrabajo] [nvarchar](50) NULL,
	[EmpresaAsociada] [nvarchar](50) NULL,
	[Ubicacion] [nvarchar](max) NULL,
	[FechaDesde] [datetime2](7) NOT NULL,
	[FechaHasta] [datetime2](7) NOT NULL,
	[FechaActualizacion] [datetime2](7) NULL,
	[FechaCreacion] [datetime2](7) NULL,
	[ProcesoActualizacion] [nvarchar](255) NULL,
	[ProcesoCreacion] [nvarchar](255) NULL,
	[UsuarioActualizacion] [int] NULL,
	[UsuarioCreacion] [int] NULL,
	[IdCurriculum] [int] NULL,
	[Observaciones] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_EntradaCV] PRIMARY KEY CLUSTERED 
(
	[IdEntradaCV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EventosUsuario]    Script Date: 08/06/2023 12:45:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventosUsuario](
	[IdEventoUsuario] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[Descripcion] [nvarchar](50) NOT NULL,
	[FechaCreacion] [datetime2](7) NULL,
	[FechaActualizacion] [datetime2](7) NULL,
	[ProcesoActualizacion] [nvarchar](255) NULL,
	[ProcesoCreacion] [nvarchar](255) NULL,
	[UsuarioActualizacion] [int] NULL,
	[UsuarioCreacion] [int] NULL,
 CONSTRAINT [PK_EventosUsuario] PRIMARY KEY CLUSTERED 
(
	[IdEventoUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FormacionCV]    Script Date: 08/06/2023 12:45:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FormacionCV](
	[IdFormacionCV] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[Grado] [nvarchar](max) NOT NULL,
	[Ubicacion] [nvarchar](max) NOT NULL,
	[Descripcion] [nvarchar](max) NULL,
	[FechaDesde] [datetime2](7) NULL,
	[FechaHasta] [datetime2](7) NULL,
	[FechaActualizacion] [datetime2](7) NULL,
	[FechaCreacion] [datetime2](7) NULL,
	[ProcesoActualizacion] [nvarchar](255) NULL,
	[ProcesoCreacion] [nvarchar](255) NULL,
	[UsuarioActualizacion] [int] NULL,
	[UsuarioCreacion] [int] NULL,
	[IdCurriculum] [int] NULL,
	[IdTipoFormacion] [int] NULL,
 CONSTRAINT [PK_FormacionCV] PRIMARY KEY CLUSTERED 
(
	[IdFormacionCV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FotoUsuarioCV]    Script Date: 08/06/2023 12:45:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FotoUsuarioCV](
	[IdFotoUsuarioCV] [int] IDENTITY(1,1) NOT NULL,
	[Ruta] [nvarchar](max) NULL,
	[Guid] [nvarchar](36) NULL,
	[UsuarioCreacion] [int] NULL,
	[FechaCreacion] [datetime2](7) NULL,
	[ProcesoCreacion] [nvarchar](255) NULL,
	[UsuarioActualizacion] [int] NULL,
	[FechaActualizacion] [datetime2](7) NULL,
	[ProcesoActualizacion] [nvarchar](255) NULL,
	[IdCurriculum] [int] NULL,
	[Ext] [nvarchar](max) NULL,
 CONSTRAINT [PK_FotoUsuarioCV] PRIMARY KEY CLUSTERED 
(
	[IdFotoUsuarioCV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Grupo]    Script Date: 08/06/2023 12:45:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Grupo](
	[Descripcion] [nvarchar](50) NOT NULL,
	[IdGrupo] [int] IDENTITY(1,1) NOT NULL,
	[FechaActualizacion] [datetime2](7) NULL,
	[FechaCreacion] [datetime2](7) NULL,
	[ProcesoActualizacion] [nvarchar](255) NULL,
	[ProcesoCreacion] [nvarchar](255) NULL,
	[UsuarioActualizacion] [int] NULL,
	[UsuarioCreacion] [int] NULL,
 CONSTRAINT [PK_Grupo] PRIMARY KEY CLUSTERED 
(
	[IdGrupo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Idioma]    Script Date: 08/06/2023 12:45:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Idioma](
	[IdIdioma] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [nvarchar](5) NOT NULL,
	[Descripcion] [nvarchar](50) NOT NULL,
	[FechaActualizacion] [datetime2](7) NULL,
	[FechaCreacion] [datetime2](7) NULL,
	[ProcesoActualizacion] [nvarchar](255) NULL,
	[ProcesoCreacion] [nvarchar](255) NULL,
	[UsuarioActualizacion] [int] NULL,
	[UsuarioCreacion] [int] NULL,
 CONSTRAINT [PK_Idioma] PRIMARY KEY CLUSTERED 
(
	[IdIdioma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IdiomaCV]    Script Date: 08/06/2023 12:45:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IdiomaCV](
	[IdIdiomaCV] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[Centro] [nvarchar](50) NOT NULL,
	[Descripcion] [nvarchar](max) NOT NULL,
	[FechaDesde] [datetime2](7) NULL,
	[FechaHasta] [datetime2](7) NULL,
	[FechaActualizacion] [datetime2](7) NULL,
	[FechaCreacion] [datetime2](7) NULL,
	[ProcesoActualizacion] [nvarchar](255) NULL,
	[ProcesoCreacion] [nvarchar](255) NULL,
	[UsuarioActualizacion] [int] NULL,
	[UsuarioCreacion] [int] NULL,
	[IdCurriculum] [int] NULL,
	[IdIdioma] [int] NULL,
	[IdNivelIdioma] [int] NULL,
 CONSTRAINT [PK_IdiomaCV] PRIMARY KEY CLUSTERED 
(
	[IdIdiomaCV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LogroCV]    Script Date: 08/06/2023 12:45:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LogroCV](
	[IdLogroCV] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](max) NOT NULL,
	[IdCurriculum] [int] NULL,
	[UsuarioCreacion] [int] NULL,
	[FechaCreacion] [datetime2](7) NULL,
	[ProcesoCreacion] [nvarchar](255) NULL,
	[UsuarioActualizacion] [int] NULL,
	[FechaActualizacion] [datetime2](7) NULL,
	[ProcesoActualizacion] [nvarchar](255) NULL,
 CONSTRAINT [PK_LogroCV] PRIMARY KEY CLUSTERED 
(
	[IdLogroCV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NivelIdioma]    Script Date: 08/06/2023 12:45:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NivelIdioma](
	[idNivelIdioma] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](50) NOT NULL,
	[UsuarioCreacion] [int] NULL,
	[FechaCreacion] [datetime2](7) NULL,
	[ProcesoCreacion] [nvarchar](255) NULL,
	[UsuarioActualizacion] [int] NULL,
	[FechaActualizacion] [datetime2](7) NULL,
	[ProcesoActualizacion] [nvarchar](255) NULL,
 CONSTRAINT [PK_NivelIdioma] PRIMARY KEY CLUSTERED 
(
	[idNivelIdioma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NotasUsuario]    Script Date: 08/06/2023 12:45:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NotasUsuario](
	[IdNotaUsuario] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[Descripcion] [nvarchar](100) NULL,
	[Titulo] [nvarchar](40) NOT NULL,
	[FechaActualizacion] [datetime2](7) NULL,
	[FechaCreacion] [datetime2](7) NULL,
	[ProcesoActualizacion] [nvarchar](255) NULL,
	[ProcesoCreacion] [nvarchar](255) NULL,
	[UsuarioActualizacion] [int] NULL,
	[UsuarioCreacion] [int] NULL,
 CONSTRAINT [PK_NotasUsuario] PRIMARY KEY CLUSTERED 
(
	[IdNotaUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Notificacion]    Script Date: 08/06/2023 12:45:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notificacion](
	[IdNotificacion] [int] IDENTITY(1,1) NOT NULL,
	[IdTipoNotificacion] [int] NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[Descripcion] [nvarchar](50) NOT NULL,
	[Leido] [bit] NOT NULL,
	[FechaCreacion] [datetime2](7) NULL,
	[FechaActualizacion] [datetime2](7) NULL,
	[ProcesoActualizacion] [nvarchar](255) NULL,
	[ProcesoCreacion] [nvarchar](255) NULL,
	[UsuarioActualizacion] [int] NULL,
	[UsuarioCreacion] [int] NULL,
 CONSTRAINT [PK_Notificacion] PRIMARY KEY CLUSTERED 
(
	[IdNotificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proyecto]    Script Date: 08/06/2023 12:45:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proyecto](
	[IdProyecto] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](50) NOT NULL,
	[FechaActualizacion] [datetime2](7) NULL,
	[FechaCreacion] [datetime2](7) NULL,
	[ProcesoActualizacion] [nvarchar](255) NULL,
	[ProcesoCreacion] [nvarchar](255) NULL,
	[UsuarioActualizacion] [int] NULL,
	[UsuarioCreacion] [int] NULL,
 CONSTRAINT [PK_Proyecto] PRIMARY KEY CLUSTERED 
(
	[IdProyecto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Respuesta]    Script Date: 08/06/2023 12:45:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Respuesta](
	[IdRespuesta] [int] IDENTITY(1,1) NOT NULL,
	[IdEntrada] [int] NOT NULL,
	[IdUsuario] [int] NULL,
	[Descripcion] [nvarchar](50) NOT NULL,
	[UpVotes] [int] NOT NULL,
	[FechaCreacion] [datetime2](7) NULL,
	[FechaActualizacion] [datetime2](7) NULL,
	[ProcesoActualizacion] [nvarchar](255) NULL,
	[ProcesoCreacion] [nvarchar](255) NULL,
	[UsuarioActualizacion] [int] NULL,
	[UsuarioCreacion] [int] NULL,
 CONSTRAINT [PK_Respuesta] PRIMARY KEY CLUSTERED 
(
	[IdRespuesta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rol]    Script Date: 08/06/2023 12:45:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol](
	[IdRol] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](50) NOT NULL,
	[FechaActualizacion] [datetime2](7) NULL,
	[FechaCreacion] [datetime2](7) NULL,
	[ProcesoActualizacion] [nvarchar](255) NULL,
	[ProcesoCreacion] [nvarchar](255) NULL,
	[UsuarioActualizacion] [int] NULL,
	[UsuarioCreacion] [int] NULL,
 CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED 
(
	[IdRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoEntrada]    Script Date: 08/06/2023 12:45:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoEntrada](
	[IdTipoEntrada] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](50) NOT NULL,
	[FechaActualizacion] [datetime2](7) NULL,
	[FechaCreacion] [datetime2](7) NULL,
	[ProcesoActualizacion] [nvarchar](255) NULL,
	[ProcesoCreacion] [nvarchar](255) NULL,
	[UsuarioActualizacion] [int] NULL,
	[UsuarioCreacion] [int] NULL,
 CONSTRAINT [PK_TipoEntrada] PRIMARY KEY CLUSTERED 
(
	[IdTipoEntrada] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoFormacion]    Script Date: 08/06/2023 12:45:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoFormacion](
	[IdTipoFormacion] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](50) NOT NULL,
	[UsuarioCreacion] [int] NULL,
	[FechaCreacion] [datetime2](7) NULL,
	[ProcesoCreacion] [nvarchar](255) NULL,
	[UsuarioActualizacion] [int] NULL,
	[FechaActualizacion] [datetime2](7) NULL,
	[ProcesoActualizacion] [nvarchar](255) NULL,
 CONSTRAINT [PK_TipoFormacion] PRIMARY KEY CLUSTERED 
(
	[IdTipoFormacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoNotificacion]    Script Date: 08/06/2023 12:45:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoNotificacion](
	[IdTipoNotificacion] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](50) NOT NULL,
	[FechaActualizacion] [datetime2](7) NULL,
	[FechaCreacion] [datetime2](7) NULL,
	[ProcesoActualizacion] [nvarchar](255) NULL,
	[ProcesoCreacion] [nvarchar](255) NULL,
	[UsuarioActualizacion] [int] NULL,
	[UsuarioCreacion] [int] NULL,
 CONSTRAINT [PK_TipoNotificacion] PRIMARY KEY CLUSTERED 
(
	[IdTipoNotificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 08/06/2023 12:45:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[NombreUser] [nvarchar](max) NOT NULL,
	[Nombre] [nvarchar](max) NULL,
	[Apellido] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NOT NULL,
	[IdRol] [int] NULL,
	[IdDepartamento] [int] NOT NULL,
	[IdGrupo] [int] NULL,
	[Foto] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Activo] [bit] NOT NULL,
	[EsAdmin] [bit] NOT NULL,
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Biografia] [nvarchar](max) NULL,
	[FechaActualizacion] [datetime2](7) NULL,
	[FechaCreacion] [datetime2](7) NULL,
	[ProcesoActualizacion] [nvarchar](255) NULL,
	[ProcesoCreacion] [nvarchar](255) NULL,
	[UsuarioActualizacion] [int] NULL,
	[UsuarioCreacion] [int] NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsuarioCV]    Script Date: 08/06/2023 12:45:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuarioCV](
	[IdUsuarioCV] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[Nombre] [nvarchar](max) NULL,
	[Apellido1] [nvarchar](max) NULL,
	[Apellido2] [nvarchar](max) NULL,
	[Profesion] [nvarchar](max) NULL,
	[Nacionalidad] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Telefono] [int] NULL,
	[EnlaceContacto] [nvarchar](max) NULL,
	[FechaActualizacion] [datetime2](7) NULL,
	[FechaCreacion] [datetime2](7) NULL,
	[ProcesoActualizacion] [nvarchar](255) NULL,
	[ProcesoCreacion] [nvarchar](255) NULL,
	[UsuarioActualizacion] [int] NULL,
	[UsuarioCreacion] [int] NULL,
	[FechaNacimiento] [datetime2](7) NULL,
	[IdFotoUsuarioCV] [int] NULL,
	[IdCurriculum] [int] NULL,
	[AcercaDe] [nvarchar](max) NULL,
 CONSTRAINT [PK_UsuarioCV] PRIMARY KEY CLUSTERED 
(
	[IdUsuarioCV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221104100320_1_CreacionTablas', N'7.0.0-rc.2.22472.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221226114913_AnadirEsAdminAUsuario', N'7.0.0-rc.2.22472.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230107160420_AnadirCodigoDepartamento', N'6.0.9')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230110164017_QuitarDptoGrupo', N'6.0.9')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230124114517_AnadirBiografiaUsuario', N'6.0.9')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230201171343_AnadirDatosAuditoria', N'6.0.9')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230203104547_AnadirAuditoriaNotasUsuario', N'6.0.9')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230207134853_AnadirFotoUsuarioCV', N'6.0.9')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230208165628_AnadirTablaCurriculum', N'6.0.9')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230208170807_AnadirTituloCurriculum', N'6.0.9')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230227203348_AnadirForeignKeysCV', N'6.0.9')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230228171410_CambiarForeignKeyCurriculumExtraCV', N'6.0.9')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230228172705_QuitarFotoEnFotoUsuarioCV', N'6.0.9')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230228173925_AnadirExtAFotoUsuarioCV', N'6.0.9')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230228175232_CambiarGuidFotoUsuarioCV', N'6.0.9')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230228175459_CambiarForeignKeyFotoUsuarioCVUsuarioCV', N'6.0.9')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230307170554_QuitarFKIdiomaCVIdioma', N'6.0.9')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230307173620_CambiarCamposEntradaCV', N'6.0.9')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230308173054_CambiarTablasExtraCVPorAptitudYLogroCV', N'6.0.9')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230309180510_QuitarFKUsuarioALogroYAptitud', N'6.0.9')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230315173057_AnadirAcercaDeUsuarioCV', N'6.0.9')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230318173019_AnadirFKEntrada', N'6.0.9')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230324133755_AnadirTipoFormacionEIdioma', N'6.0.9')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230330123943_AnadirNivelIdioma', N'6.0.9')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230330151910_QutiarNivelIdiomaCV', N'6.0.9')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230419105129_QuitarReferenciasEntradas', N'6.0.9')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230525095733_AnadirContacto', N'6.0.9')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230526111128_QuitarReferenciaUsuarioCVEnFotoUsuarioCV', N'6.0.9')
GO
SET IDENTITY_INSERT [dbo].[AptitudCV] ON 

INSERT [dbo].[AptitudCV] ([IdAptitudCV], [Descripcion], [IdCurriculum], [UsuarioCreacion], [FechaCreacion], [ProcesoCreacion], [UsuarioActualizacion], [FechaActualizacion], [ProcesoActualizacion]) VALUES (4, N'Proactivo y con ganas de trabajar.', 1, 1, CAST(N'2023-03-09T19:06:32.9062994' AS DateTime2), N'GuardarAptitud', NULL, NULL, NULL)
INSERT [dbo].[AptitudCV] ([IdAptitudCV], [Descripcion], [IdCurriculum], [UsuarioCreacion], [FechaCreacion], [ProcesoCreacion], [UsuarioActualizacion], [FechaActualizacion], [ProcesoActualizacion]) VALUES (5, N'Trabajo en equipo.', 1, 1, CAST(N'2023-03-09T19:06:33.1681984' AS DateTime2), N'GuardarAptitud', NULL, NULL, NULL)
INSERT [dbo].[AptitudCV] ([IdAptitudCV], [Descripcion], [IdCurriculum], [UsuarioCreacion], [FechaCreacion], [ProcesoCreacion], [UsuarioActualizacion], [FechaActualizacion], [ProcesoActualizacion]) VALUES (6, N'Proactivo y con ganas de trabajar.', 5, NULL, CAST(N'2023-03-27T22:02:29.0674974' AS DateTime2), N'ClonadoAptitudCV', NULL, NULL, NULL)
INSERT [dbo].[AptitudCV] ([IdAptitudCV], [Descripcion], [IdCurriculum], [UsuarioCreacion], [FechaCreacion], [ProcesoCreacion], [UsuarioActualizacion], [FechaActualizacion], [ProcesoActualizacion]) VALUES (7, N'Trabajo en equipo.', 5, NULL, CAST(N'2023-03-27T22:02:29.0744470' AS DateTime2), N'ClonadoAptitudCV', NULL, NULL, NULL)
INSERT [dbo].[AptitudCV] ([IdAptitudCV], [Descripcion], [IdCurriculum], [UsuarioCreacion], [FechaCreacion], [ProcesoCreacion], [UsuarioActualizacion], [FechaActualizacion], [ProcesoActualizacion]) VALUES (8, N'Soy muy fiel a mi trabajo.', 10, 4, CAST(N'2023-05-25T14:29:04.0605224' AS DateTime2), N'GuardarAptitud', NULL, NULL, NULL)
INSERT [dbo].[AptitudCV] ([IdAptitudCV], [Descripcion], [IdCurriculum], [UsuarioCreacion], [FechaCreacion], [ProcesoCreacion], [UsuarioActualizacion], [FechaActualizacion], [ProcesoActualizacion]) VALUES (9, N'Cada día intento ser mejor y aprender más.', 10, 4, CAST(N'2023-05-25T14:29:04.0845314' AS DateTime2), N'GuardarAptitud', NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[AptitudCV] OFF
GO
SET IDENTITY_INSERT [dbo].[Contacto] ON 

INSERT [dbo].[Contacto] ([IdContacto], [IdUsuario], [IdUsuarioAgregado], [UsuarioCreacion], [FechaCreacion], [ProcesoCreacion], [UsuarioActualizacion], [FechaActualizacion], [ProcesoActualizacion]) VALUES (1, 1, 4, 1, CAST(N'2023-05-25T13:28:24.3153081' AS DateTime2), N'GuardarContacto', NULL, NULL, NULL)
INSERT [dbo].[Contacto] ([IdContacto], [IdUsuario], [IdUsuarioAgregado], [UsuarioCreacion], [FechaCreacion], [ProcesoCreacion], [UsuarioActualizacion], [FechaActualizacion], [ProcesoActualizacion]) VALUES (2, 1, 4, 1, CAST(N'2023-05-25T13:28:26.7083624' AS DateTime2), N'GuardarContacto', NULL, NULL, NULL)
INSERT [dbo].[Contacto] ([IdContacto], [IdUsuario], [IdUsuarioAgregado], [UsuarioCreacion], [FechaCreacion], [ProcesoCreacion], [UsuarioActualizacion], [FechaActualizacion], [ProcesoActualizacion]) VALUES (6, 1, 5, 1, CAST(N'2023-05-25T13:38:19.7187941' AS DateTime2), N'GuardarContacto', NULL, NULL, NULL)
INSERT [dbo].[Contacto] ([IdContacto], [IdUsuario], [IdUsuarioAgregado], [UsuarioCreacion], [FechaCreacion], [ProcesoCreacion], [UsuarioActualizacion], [FechaActualizacion], [ProcesoActualizacion]) VALUES (7, 5, 4, 5, CAST(N'2023-05-25T13:55:43.5653861' AS DateTime2), N'GuardarContacto', NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Contacto] OFF
GO
SET IDENTITY_INSERT [dbo].[Curriculum] ON 

INSERT [dbo].[Curriculum] ([IdCurriculum], [IdUsuario], [FechaCurriculum], [UsuarioCreacion], [FechaCreacion], [ProcesoCreacion], [UsuarioActualizacion], [FechaActualizacion], [ProcesoActualizacion], [Titulo]) VALUES (1, 1, CAST(N'2023-02-12T15:04:44.7636930' AS DateTime2), NULL, CAST(N'2023-02-12T15:04:44.7431500' AS DateTime2), N'GuardarNuevoCurriculum', NULL, CAST(N'2023-03-31T12:58:51.2520842' AS DateTime2), N'ActualizarNombre', N'Primer Currículum Editado')
INSERT [dbo].[Curriculum] ([IdCurriculum], [IdUsuario], [FechaCurriculum], [UsuarioCreacion], [FechaCreacion], [ProcesoCreacion], [UsuarioActualizacion], [FechaActualizacion], [ProcesoActualizacion], [Titulo]) VALUES (5, 1, CAST(N'2023-03-27T22:02:25.3453158' AS DateTime2), NULL, CAST(N'2023-03-27T22:02:25.3454245' AS DateTime2), N'MoveNext', NULL, NULL, NULL, N'Primer Currículum_CPY')
INSERT [dbo].[Curriculum] ([IdCurriculum], [IdUsuario], [FechaCurriculum], [UsuarioCreacion], [FechaCreacion], [ProcesoCreacion], [UsuarioActualizacion], [FechaActualizacion], [ProcesoActualizacion], [Titulo]) VALUES (10, 4, CAST(N'2023-05-25T14:21:38.4277336' AS DateTime2), NULL, CAST(N'2023-05-25T14:21:38.4277134' AS DateTime2), N'GuardarNuevoCurriculum', NULL, CAST(N'2023-05-25T14:30:27.8794369' AS DateTime2), N'ActualizarNombre', N'Currículum de Leo')
SET IDENTITY_INSERT [dbo].[Curriculum] OFF
GO
SET IDENTITY_INSERT [dbo].[Departamento] ON 

INSERT [dbo].[Departamento] ([Descripcion], [Codigo], [IdDepartamento], [FechaActualizacion], [FechaCreacion], [ProcesoActualizacion], [ProcesoCreacion], [UsuarioActualizacion], [UsuarioCreacion]) VALUES (N'Sin Departamento', N'SD', 1, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Departamento] ([Descripcion], [Codigo], [IdDepartamento], [FechaActualizacion], [FechaCreacion], [ProcesoActualizacion], [ProcesoCreacion], [UsuarioActualizacion], [UsuarioCreacion]) VALUES (N'Recursos Humanos', N'RRHH', 2, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Departamento] ([Descripcion], [Codigo], [IdDepartamento], [FechaActualizacion], [FechaCreacion], [ProcesoActualizacion], [ProcesoCreacion], [UsuarioActualizacion], [UsuarioCreacion]) VALUES (N'Desarrollo Aplicaciones', N'DESAPP', 3, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Departamento] OFF
GO
SET IDENTITY_INSERT [dbo].[Entrada] ON 

INSERT [dbo].[Entrada] ([IdEntrada], [IdUsuario], [IdProyecto], [Lenguaje], [TituloIssue], [Descripcion], [Editada], [Resuelta], [NumRespuestas], [FechaCreacion], [FechaActualizacion], [ProcesoActualizacion], [ProcesoCreacion], [UsuarioActualizacion], [UsuarioCreacion]) VALUES (1, 1, NULL, NULL, NULL, N'Primera publicación de este proyecto!', 0, 0, 0, CAST(N'2023-04-19T12:55:56.5733631' AS DateTime2), NULL, NULL, N'NuevaEntrada', NULL, 1)
INSERT [dbo].[Entrada] ([IdEntrada], [IdUsuario], [IdProyecto], [Lenguaje], [TituloIssue], [Descripcion], [Editada], [Resuelta], [NumRespuestas], [FechaCreacion], [FechaActualizacion], [ProcesoActualizacion], [ProcesoCreacion], [UsuarioActualizacion], [UsuarioCreacion]) VALUES (2, 2, NULL, NULL, NULL, N'¡Segunda publicación antes del despliegue!', 0, 0, 0, CAST(N'2023-05-24T17:41:36.7541304' AS DateTime2), NULL, NULL, N'NuevaEntrada', NULL, 2)
SET IDENTITY_INSERT [dbo].[Entrada] OFF
GO
SET IDENTITY_INSERT [dbo].[EntradaCV] ON 

INSERT [dbo].[EntradaCV] ([IdEntradaCV], [IdUsuario], [PuestoTrabajo], [EmpresaAsociada], [Ubicacion], [FechaDesde], [FechaHasta], [FechaActualizacion], [FechaCreacion], [ProcesoActualizacion], [ProcesoCreacion], [UsuarioActualizacion], [UsuarioCreacion], [IdCurriculum], [Observaciones]) VALUES (2, 1, N'Desarrollador Web/Analista', N'CSA', N'C/ Santo Domingo de Guzmán', CAST(N'2022-11-01T00:00:00.0000000' AS DateTime2), CAST(N'2023-03-01T00:00:00.0000000' AS DateTime2), CAST(N'2023-03-31T12:58:51.7880401' AS DateTime2), CAST(N'2023-03-08T18:09:37.1229874' AS DateTime2), N'GuardarEntrada', N'GuardarEntrada', 1, 1, 1, N'Desarrollador Web de aplicaciones de lógistica.')
INSERT [dbo].[EntradaCV] ([IdEntradaCV], [IdUsuario], [PuestoTrabajo], [EmpresaAsociada], [Ubicacion], [FechaDesde], [FechaHasta], [FechaActualizacion], [FechaCreacion], [ProcesoActualizacion], [ProcesoCreacion], [UsuarioActualizacion], [UsuarioCreacion], [IdCurriculum], [Observaciones]) VALUES (4, 1, N'Desarrollador Web/Analista', N'CSA', N'C/ Santo Domingo de Guzmán', CAST(N'2022-11-01T00:00:00.0000000' AS DateTime2), CAST(N'2023-03-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'2023-03-27T22:02:29.0290977' AS DateTime2), NULL, N'ClonadoEntradaCV', NULL, NULL, 5, N'Desarrollador Web de aplicaciones de lógistica.')
INSERT [dbo].[EntradaCV] ([IdEntradaCV], [IdUsuario], [PuestoTrabajo], [EmpresaAsociada], [Ubicacion], [FechaDesde], [FechaHasta], [FechaActualizacion], [FechaCreacion], [ProcesoActualizacion], [ProcesoCreacion], [UsuarioActualizacion], [UsuarioCreacion], [IdCurriculum], [Observaciones]) VALUES (5, 4, N'Desarrollador de Videojuegos', N'EA SPORTS', N'Zurich', CAST(N'2016-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2022-06-01T00:00:00.0000000' AS DateTime2), CAST(N'2023-05-25T14:30:27.9370377' AS DateTime2), CAST(N'2023-05-25T14:29:04.0189326' AS DateTime2), N'GuardarEntrada', N'GuardarEntrada', 4, 4, 10, N'Hacía juegos de fútbol en Unity')
SET IDENTITY_INSERT [dbo].[EntradaCV] OFF
GO
SET IDENTITY_INSERT [dbo].[FormacionCV] ON 

INSERT [dbo].[FormacionCV] ([IdFormacionCV], [IdUsuario], [Grado], [Ubicacion], [Descripcion], [FechaDesde], [FechaHasta], [FechaActualizacion], [FechaCreacion], [ProcesoActualizacion], [ProcesoCreacion], [UsuarioActualizacion], [UsuarioCreacion], [IdCurriculum], [IdTipoFormacion]) VALUES (1, 1, N'Educación Secundaria ', N'Diego de Siloé', N'', CAST(N'2012-09-01T00:00:00.0000000' AS DateTime2), CAST(N'2016-06-01T00:00:00.0000000' AS DateTime2), CAST(N'2023-03-31T12:58:51.7795663' AS DateTime2), CAST(N'2023-03-05T13:29:08.6958883' AS DateTime2), N'GuardarFormacion', N'GuardarFormacion', 1, 1, 1, 1)
INSERT [dbo].[FormacionCV] ([IdFormacionCV], [IdUsuario], [Grado], [Ubicacion], [Descripcion], [FechaDesde], [FechaHasta], [FechaActualizacion], [FechaCreacion], [ProcesoActualizacion], [ProcesoCreacion], [UsuarioActualizacion], [UsuarioCreacion], [IdCurriculum], [IdTipoFormacion]) VALUES (3, 1, N'Ingeniería Informática', N'Rio Vena', N'Matrícula de honor en Gestión de Empresas', CAST(N'2018-09-01T00:00:00.0000000' AS DateTime2), CAST(N'2023-07-01T00:00:00.0000000' AS DateTime2), CAST(N'2023-03-31T12:58:51.7809437' AS DateTime2), CAST(N'2023-03-05T13:29:09.2215348' AS DateTime2), N'GuardarFormacion', N'GuardarFormacion', 1, 1, 1, 5)
INSERT [dbo].[FormacionCV] ([IdFormacionCV], [IdUsuario], [Grado], [Ubicacion], [Descripcion], [FechaDesde], [FechaHasta], [FechaActualizacion], [FechaCreacion], [ProcesoActualizacion], [ProcesoCreacion], [UsuarioActualizacion], [UsuarioCreacion], [IdCurriculum], [IdTipoFormacion]) VALUES (9, 1, N'Bachillerato de Ciencias', N'Diego de Siloé', N'', CAST(N'2016-09-01T00:00:00.0000000' AS DateTime2), CAST(N'2018-06-01T00:00:00.0000000' AS DateTime2), CAST(N'2023-03-31T12:58:51.7820455' AS DateTime2), CAST(N'2023-03-24T18:32:05.3716041' AS DateTime2), N'GuardarFormacion', N'GuardarFormacion', 1, 1, 1, 2)
INSERT [dbo].[FormacionCV] ([IdFormacionCV], [IdUsuario], [Grado], [Ubicacion], [Descripcion], [FechaDesde], [FechaHasta], [FechaActualizacion], [FechaCreacion], [ProcesoActualizacion], [ProcesoCreacion], [UsuarioActualizacion], [UsuarioCreacion], [IdCurriculum], [IdTipoFormacion]) VALUES (10, 1, N'Educación Secundaria ', N'Diego de Siloé', N'', CAST(N'2012-09-01T00:00:00.0000000' AS DateTime2), CAST(N'2016-06-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'2023-03-27T22:02:28.9992180' AS DateTime2), NULL, N'ClonadoFormacionCV', NULL, NULL, 5, 1)
INSERT [dbo].[FormacionCV] ([IdFormacionCV], [IdUsuario], [Grado], [Ubicacion], [Descripcion], [FechaDesde], [FechaHasta], [FechaActualizacion], [FechaCreacion], [ProcesoActualizacion], [ProcesoCreacion], [UsuarioActualizacion], [UsuarioCreacion], [IdCurriculum], [IdTipoFormacion]) VALUES (11, 1, N'Ingeniería Informática', N'Rio Vena', N'Matrícula de honor en Gestión de Empresas', CAST(N'2018-09-01T00:00:00.0000000' AS DateTime2), CAST(N'2023-07-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'2023-03-27T22:02:29.0243345' AS DateTime2), NULL, N'ClonadoFormacionCV', NULL, NULL, 5, 5)
INSERT [dbo].[FormacionCV] ([IdFormacionCV], [IdUsuario], [Grado], [Ubicacion], [Descripcion], [FechaDesde], [FechaHasta], [FechaActualizacion], [FechaCreacion], [ProcesoActualizacion], [ProcesoCreacion], [UsuarioActualizacion], [UsuarioCreacion], [IdCurriculum], [IdTipoFormacion]) VALUES (12, 1, N'Bachillerato de Ciencias', N'Diego de Siloé', N'', CAST(N'2016-09-01T00:00:00.0000000' AS DateTime2), CAST(N'2018-06-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'2023-03-27T22:02:29.0260902' AS DateTime2), NULL, N'ClonadoFormacionCV', NULL, NULL, 5, 2)
INSERT [dbo].[FormacionCV] ([IdFormacionCV], [IdUsuario], [Grado], [Ubicacion], [Descripcion], [FechaDesde], [FechaHasta], [FechaActualizacion], [FechaCreacion], [ProcesoActualizacion], [ProcesoCreacion], [UsuarioActualizacion], [UsuarioCreacion], [IdCurriculum], [IdTipoFormacion]) VALUES (13, 4, N'Secundaria', N'Argentina', N'', CAST(N'1999-09-01T00:00:00.0000000' AS DateTime2), CAST(N'2004-06-01T00:00:00.0000000' AS DateTime2), CAST(N'2023-05-25T14:30:27.9306587' AS DateTime2), CAST(N'2023-05-25T14:29:03.9301904' AS DateTime2), N'GuardarFormacion', N'GuardarFormacion', 4, 4, 10, 1)
SET IDENTITY_INSERT [dbo].[FormacionCV] OFF
GO
SET IDENTITY_INSERT [dbo].[FotoUsuarioCV] ON 

INSERT [dbo].[FotoUsuarioCV] ([IdFotoUsuarioCV], [Ruta], [Guid], [UsuarioCreacion], [FechaCreacion], [ProcesoCreacion], [UsuarioActualizacion], [FechaActualizacion], [ProcesoActualizacion], [IdCurriculum], [Ext]) VALUES (5, N'wwwroot/ImagenPerfilCV/profilePhoto_1_1', N'7c189c52-1a39-46b3-b57b-4f3642649ca5', 1, CAST(N'2023-02-28T18:55:50.8224072' AS DateTime2), N'AddPhoto', 1, CAST(N'2023-03-14T19:36:59.6825294' AS DateTime2), N'ChangePhoto', 1, N'jpg')
SET IDENTITY_INSERT [dbo].[FotoUsuarioCV] OFF
GO
SET IDENTITY_INSERT [dbo].[Grupo] ON 

INSERT [dbo].[Grupo] ([Descripcion], [IdGrupo], [FechaActualizacion], [FechaCreacion], [ProcesoActualizacion], [ProcesoCreacion], [UsuarioActualizacion], [UsuarioCreacion]) VALUES (N'Sin Grupo', 1, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Grupo] OFF
GO
SET IDENTITY_INSERT [dbo].[Idioma] ON 

INSERT [dbo].[Idioma] ([IdIdioma], [Codigo], [Descripcion], [FechaActualizacion], [FechaCreacion], [ProcesoActualizacion], [ProcesoCreacion], [UsuarioActualizacion], [UsuarioCreacion]) VALUES (1, N'OTRO', N'Otro Idioma', NULL, CAST(N'2023-03-06T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[Idioma] ([IdIdioma], [Codigo], [Descripcion], [FechaActualizacion], [FechaCreacion], [ProcesoActualizacion], [ProcesoCreacion], [UsuarioActualizacion], [UsuarioCreacion]) VALUES (2, N'EN', N'Inglés', NULL, CAST(N'2023-03-06T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[Idioma] ([IdIdioma], [Codigo], [Descripcion], [FechaActualizacion], [FechaCreacion], [ProcesoActualizacion], [ProcesoCreacion], [UsuarioActualizacion], [UsuarioCreacion]) VALUES (4, N'FR', N'Francés', NULL, CAST(N'2023-03-06T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[Idioma] ([IdIdioma], [Codigo], [Descripcion], [FechaActualizacion], [FechaCreacion], [ProcesoActualizacion], [ProcesoCreacion], [UsuarioActualizacion], [UsuarioCreacion]) VALUES (5, N'GER', N'Alemán', NULL, CAST(N'2023-03-06T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[Idioma] ([IdIdioma], [Codigo], [Descripcion], [FechaActualizacion], [FechaCreacion], [ProcesoActualizacion], [ProcesoCreacion], [UsuarioActualizacion], [UsuarioCreacion]) VALUES (6, N'PT', N'Portugués', NULL, CAST(N'2023-03-06T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[Idioma] ([IdIdioma], [Codigo], [Descripcion], [FechaActualizacion], [FechaCreacion], [ProcesoActualizacion], [ProcesoCreacion], [UsuarioActualizacion], [UsuarioCreacion]) VALUES (7, N'JAP', N'Japonés', NULL, CAST(N'2023-03-06T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[Idioma] ([IdIdioma], [Codigo], [Descripcion], [FechaActualizacion], [FechaCreacion], [ProcesoActualizacion], [ProcesoCreacion], [UsuarioActualizacion], [UsuarioCreacion]) VALUES (8, N'CH', N'Chino', NULL, CAST(N'2023-03-06T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Idioma] OFF
GO
SET IDENTITY_INSERT [dbo].[IdiomaCV] ON 

INSERT [dbo].[IdiomaCV] ([IdIdiomaCV], [IdUsuario], [Centro], [Descripcion], [FechaDesde], [FechaHasta], [FechaActualizacion], [FechaCreacion], [ProcesoActualizacion], [ProcesoCreacion], [UsuarioActualizacion], [UsuarioCreacion], [IdCurriculum], [IdIdioma], [IdNivelIdioma]) VALUES (3, 1, N'Cambridge School', N'First Certificate in English', CAST(N'2017-07-01T00:00:00.0000000' AS DateTime2), CAST(N'2017-07-01T00:00:00.0000000' AS DateTime2), CAST(N'2023-03-31T12:58:51.7841652' AS DateTime2), CAST(N'2023-03-07T18:08:56.4635946' AS DateTime2), N'GuardarIdioma', N'GuardarIdioma', 1, 1, 1, 2, 3)
INSERT [dbo].[IdiomaCV] ([IdIdiomaCV], [IdUsuario], [Centro], [Descripcion], [FechaDesde], [FechaHasta], [FechaActualizacion], [FechaCreacion], [ProcesoActualizacion], [ProcesoCreacion], [UsuarioActualizacion], [UsuarioCreacion], [IdCurriculum], [IdIdioma], [IdNivelIdioma]) VALUES (4, 1, N'Cambridge School', N'First Certificate in English', CAST(N'2017-07-01T00:00:00.0000000' AS DateTime2), CAST(N'2017-07-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'2023-03-27T22:02:29.0397349' AS DateTime2), NULL, N'ClonadoIdiomaCV', NULL, NULL, 5, 2, 3)
INSERT [dbo].[IdiomaCV] ([IdIdiomaCV], [IdUsuario], [Centro], [Descripcion], [FechaDesde], [FechaHasta], [FechaActualizacion], [FechaCreacion], [ProcesoActualizacion], [ProcesoCreacion], [UsuarioActualizacion], [UsuarioCreacion], [IdCurriculum], [IdIdioma], [IdNivelIdioma]) VALUES (5, 4, N'Cambridge', N'Pet', CAST(N'2016-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2016-02-01T00:00:00.0000000' AS DateTime2), CAST(N'2023-05-25T14:30:27.9347804' AS DateTime2), CAST(N'2023-05-25T14:29:03.9720622' AS DateTime2), N'GuardarIdioma', N'GuardarIdioma', 4, 4, 10, 2, 1)
SET IDENTITY_INSERT [dbo].[IdiomaCV] OFF
GO
SET IDENTITY_INSERT [dbo].[LogroCV] ON 

INSERT [dbo].[LogroCV] ([IdLogroCV], [Descripcion], [IdCurriculum], [UsuarioCreacion], [FechaCreacion], [ProcesoCreacion], [UsuarioActualizacion], [FechaActualizacion], [ProcesoActualizacion]) VALUES (1, N'TFG de gestión de CV''s para CSA.', 1, 1, CAST(N'2023-03-09T19:06:34.6887738' AS DateTime2), N'GuardarLogro', NULL, NULL, NULL)
INSERT [dbo].[LogroCV] ([IdLogroCV], [Descripcion], [IdCurriculum], [UsuarioCreacion], [FechaCreacion], [ProcesoCreacion], [UsuarioActualizacion], [FechaActualizacion], [ProcesoActualizacion]) VALUES (3, N'TFG de gestión de CV''s para CSA.', 5, NULL, CAST(N'2023-03-27T22:02:29.0557886' AS DateTime2), N'ClonadoLogroCV', NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[LogroCV] OFF
GO
SET IDENTITY_INSERT [dbo].[NivelIdioma] ON 

INSERT [dbo].[NivelIdioma] ([idNivelIdioma], [Descripcion], [UsuarioCreacion], [FechaCreacion], [ProcesoCreacion], [UsuarioActualizacion], [FechaActualizacion], [ProcesoActualizacion]) VALUES (1, N'Básico', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[NivelIdioma] ([idNivelIdioma], [Descripcion], [UsuarioCreacion], [FechaCreacion], [ProcesoCreacion], [UsuarioActualizacion], [FechaActualizacion], [ProcesoActualizacion]) VALUES (2, N'Intermedio', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[NivelIdioma] ([idNivelIdioma], [Descripcion], [UsuarioCreacion], [FechaCreacion], [ProcesoCreacion], [UsuarioActualizacion], [FechaActualizacion], [ProcesoActualizacion]) VALUES (3, N'Intermedio-Alto', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[NivelIdioma] ([idNivelIdioma], [Descripcion], [UsuarioCreacion], [FechaCreacion], [ProcesoCreacion], [UsuarioActualizacion], [FechaActualizacion], [ProcesoActualizacion]) VALUES (4, N'Avanzado', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[NivelIdioma] ([idNivelIdioma], [Descripcion], [UsuarioCreacion], [FechaCreacion], [ProcesoCreacion], [UsuarioActualizacion], [FechaActualizacion], [ProcesoActualizacion]) VALUES (5, N'Nativo', NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[NivelIdioma] OFF
GO
SET IDENTITY_INSERT [dbo].[NotasUsuario] ON 

INSERT [dbo].[NotasUsuario] ([IdNotaUsuario], [IdUsuario], [Descripcion], [Titulo], [FechaActualizacion], [FechaCreacion], [ProcesoActualizacion], [ProcesoCreacion], [UsuarioActualizacion], [UsuarioCreacion]) VALUES (4, 1, N'Descripción de la nota de prueba', N'Nota de prueba', NULL, CAST(N'2023-02-03T17:47:00.5014694' AS DateTime2), NULL, N'GuardarNuevaNota', NULL, 1)
INSERT [dbo].[NotasUsuario] ([IdNotaUsuario], [IdUsuario], [Descripcion], [Titulo], [FechaActualizacion], [FechaCreacion], [ProcesoActualizacion], [ProcesoCreacion], [UsuarioActualizacion], [UsuarioCreacion]) VALUES (6, 1, N'Nota a editar pero esta vez editada correctamente.', N'Una nota a editar que está editada.', CAST(N'2023-02-07T17:50:49.3457172' AS DateTime2), CAST(N'2023-02-03T17:53:45.4847999' AS DateTime2), N'EditarNota', N'GuardarNuevaNota', NULL, 1)
SET IDENTITY_INSERT [dbo].[NotasUsuario] OFF
GO
SET IDENTITY_INSERT [dbo].[Rol] ON 

INSERT [dbo].[Rol] ([IdRol], [Descripcion], [FechaActualizacion], [FechaCreacion], [ProcesoActualizacion], [ProcesoCreacion], [UsuarioActualizacion], [UsuarioCreacion]) VALUES (1, N'Sin Rol', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Rol] ([IdRol], [Descripcion], [FechaActualizacion], [FechaCreacion], [ProcesoActualizacion], [ProcesoCreacion], [UsuarioActualizacion], [UsuarioCreacion]) VALUES (2, N'Desarrollador', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Rol] ([IdRol], [Descripcion], [FechaActualizacion], [FechaCreacion], [ProcesoActualizacion], [ProcesoCreacion], [UsuarioActualizacion], [UsuarioCreacion]) VALUES (3, N'Analista', NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Rol] OFF
GO
SET IDENTITY_INSERT [dbo].[TipoFormacion] ON 

INSERT [dbo].[TipoFormacion] ([IdTipoFormacion], [Descripcion], [UsuarioCreacion], [FechaCreacion], [ProcesoCreacion], [UsuarioActualizacion], [FechaActualizacion], [ProcesoActualizacion]) VALUES (1, N'Educación Secundaria', NULL, CAST(N'2023-03-24T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[TipoFormacion] ([IdTipoFormacion], [Descripcion], [UsuarioCreacion], [FechaCreacion], [ProcesoCreacion], [UsuarioActualizacion], [FechaActualizacion], [ProcesoActualizacion]) VALUES (2, N'Bachillerato', NULL, CAST(N'2023-03-24T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[TipoFormacion] ([IdTipoFormacion], [Descripcion], [UsuarioCreacion], [FechaCreacion], [ProcesoCreacion], [UsuarioActualizacion], [FechaActualizacion], [ProcesoActualizacion]) VALUES (3, N'Grado Medio', NULL, CAST(N'2023-03-24T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[TipoFormacion] ([IdTipoFormacion], [Descripcion], [UsuarioCreacion], [FechaCreacion], [ProcesoCreacion], [UsuarioActualizacion], [FechaActualizacion], [ProcesoActualizacion]) VALUES (4, N'Grado Superior', NULL, CAST(N'2023-03-24T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[TipoFormacion] ([IdTipoFormacion], [Descripcion], [UsuarioCreacion], [FechaCreacion], [ProcesoCreacion], [UsuarioActualizacion], [FechaActualizacion], [ProcesoActualizacion]) VALUES (5, N'Grado Universitario', NULL, CAST(N'2023-03-24T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[TipoFormacion] ([IdTipoFormacion], [Descripcion], [UsuarioCreacion], [FechaCreacion], [ProcesoCreacion], [UsuarioActualizacion], [FechaActualizacion], [ProcesoActualizacion]) VALUES (6, N'Máster Universitario', NULL, CAST(N'2023-03-24T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[TipoFormacion] ([IdTipoFormacion], [Descripcion], [UsuarioCreacion], [FechaCreacion], [ProcesoCreacion], [UsuarioActualizacion], [FechaActualizacion], [ProcesoActualizacion]) VALUES (7, N'Doctorado', NULL, CAST(N'2023-03-24T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[TipoFormacion] ([IdTipoFormacion], [Descripcion], [UsuarioCreacion], [FechaCreacion], [ProcesoCreacion], [UsuarioActualizacion], [FechaActualizacion], [ProcesoActualizacion]) VALUES (8, N'Estudios No Oficiales', NULL, CAST(N'2023-03-24T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[TipoFormacion] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([NombreUser], [Nombre], [Apellido], [Password], [IdRol], [IdDepartamento], [IdGrupo], [Foto], [Email], [Activo], [EsAdmin], [IdUsuario], [Biografia], [FechaActualizacion], [FechaCreacion], [ProcesoActualizacion], [ProcesoCreacion], [UsuarioActualizacion], [UsuarioCreacion]) VALUES (N'alex.tome', N'Alex', N'Tomé', N'3/HmOiG9uu/RMJ2pQNyUBWLIZi5NL1LypedZCQw500g=', 1, 3, 1, N'CSACVM/wwwroot/ImagenPerfil/profilePhoto_1.jpg', N'alex.tome@csa.es', 1, 0, 1, N'Esto es una biografía cambiada', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Usuario] ([NombreUser], [Nombre], [Apellido], [Password], [IdRol], [IdDepartamento], [IdGrupo], [Foto], [Email], [Activo], [EsAdmin], [IdUsuario], [Biografia], [FechaActualizacion], [FechaCreacion], [ProcesoActualizacion], [ProcesoCreacion], [UsuarioActualizacion], [UsuarioCreacion]) VALUES (N'CSA', N'CSA', NULL, N'jVo+zK01qPN1B6jjgWaNBVZdWGXRBWfBK6SrH8r8E6A=', 1, 1, 1, NULL, NULL, 1, 1, 2, N'', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Usuario] ([NombreUser], [Nombre], [Apellido], [Password], [IdRol], [IdDepartamento], [IdGrupo], [Foto], [Email], [Activo], [EsAdmin], [IdUsuario], [Biografia], [FechaActualizacion], [FechaCreacion], [ProcesoActualizacion], [ProcesoCreacion], [UsuarioActualizacion], [UsuarioCreacion]) VALUES (N'admin.admin', N'admin', N'admin', N'jVo+zK01qPN1B6jjgWaNBVZdWGXRBWfBK6SrH8r8E6A=', 1, 2, 1, NULL, NULL, 1, 1, 3, N'', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Usuario] ([NombreUser], [Nombre], [Apellido], [Password], [IdRol], [IdDepartamento], [IdGrupo], [Foto], [Email], [Activo], [EsAdmin], [IdUsuario], [Biografia], [FechaActualizacion], [FechaCreacion], [ProcesoActualizacion], [ProcesoCreacion], [UsuarioActualizacion], [UsuarioCreacion]) VALUES (N'lionel.messi', N'Lionel', N'Messi', N'3/HmOiG9uu/RMJ2pQNyUBWLIZi5NL1LypedZCQw500g=', 1, 3, 1, N'CSACVM/wwwroot/ImagenPerfil/profilePhoto_4.jpg', N'lionelmessi@gmail.com', 1, 0, 4, N'Soy el mejor jugador del mundo', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Usuario] ([NombreUser], [Nombre], [Apellido], [Password], [IdRol], [IdDepartamento], [IdGrupo], [Foto], [Email], [Activo], [EsAdmin], [IdUsuario], [Biografia], [FechaActualizacion], [FechaCreacion], [ProcesoActualizacion], [ProcesoCreacion], [UsuarioActualizacion], [UsuarioCreacion]) VALUES (N'cristiano.ronaldo', N'Cristiano', N'Ronaldo', N'3/HmOiG9uu/RMJ2pQNyUBWLIZi5NL1LypedZCQw500g=', 1, 3, 1, N'CSACVM/wwwroot/ImagenPerfil/profilePhoto_5.jpg', N'elbicho@gmail.com', 1, 0, 5, N'', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Usuario] ([NombreUser], [Nombre], [Apellido], [Password], [IdRol], [IdDepartamento], [IdGrupo], [Foto], [Email], [Activo], [EsAdmin], [IdUsuario], [Biografia], [FechaActualizacion], [FechaCreacion], [ProcesoActualizacion], [ProcesoCreacion], [UsuarioActualizacion], [UsuarioCreacion]) VALUES (N'jovani.vazquez', N'Jovani', N'Vázquez', N'3/HmOiG9uu/RMJ2pQNyUBWLIZi5NL1LypedZCQw500g=', 1, 3, 1, NULL, N'jovaniJV@gmail.com', 1, 0, 6, N'', NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
SET IDENTITY_INSERT [dbo].[UsuarioCV] ON 

INSERT [dbo].[UsuarioCV] ([IdUsuarioCV], [IdUsuario], [Nombre], [Apellido1], [Apellido2], [Profesion], [Nacionalidad], [Email], [Telefono], [EnlaceContacto], [FechaActualizacion], [FechaCreacion], [ProcesoActualizacion], [ProcesoCreacion], [UsuarioActualizacion], [UsuarioCreacion], [FechaNacimiento], [IdFotoUsuarioCV], [IdCurriculum], [AcercaDe]) VALUES (1, 1, N'Alex', N'Tomé', N'Aguiar', N'Desarrollador Web', N'Española', N'alextome32@gmail.com', 111222333, NULL, CAST(N'2023-03-31T12:58:51.2642604' AS DateTime2), CAST(N'2023-02-28T18:45:52.3153021' AS DateTime2), N'GuardarUsuarioCV', N'NuevoUsuarioCV', 1, 1, CAST(N'2000-05-18T00:00:00.0000000' AS DateTime2), 5, 1, N'Soy un desarrollador web especializado en trabajar con el entorno de trabajo de Core. Valoro mucho el trabajo en equipo y ansío desarrollarme profesional y personalmente.')
INSERT [dbo].[UsuarioCV] ([IdUsuarioCV], [IdUsuario], [Nombre], [Apellido1], [Apellido2], [Profesion], [Nacionalidad], [Email], [Telefono], [EnlaceContacto], [FechaActualizacion], [FechaCreacion], [ProcesoActualizacion], [ProcesoCreacion], [UsuarioActualizacion], [UsuarioCreacion], [FechaNacimiento], [IdFotoUsuarioCV], [IdCurriculum], [AcercaDe]) VALUES (3, 1, N'Alex', N'Tomé', N'Aguiar', N'Desarrollador Web', N'Española', N'alextome32@gmail.com', 111222333, NULL, NULL, CAST(N'2023-03-27T22:02:28.8836262' AS DateTime2), NULL, N'ClonadoUsuarioCV', NULL, NULL, CAST(N'2000-05-18T00:00:00.0000000' AS DateTime2), NULL, 5, NULL)
INSERT [dbo].[UsuarioCV] ([IdUsuarioCV], [IdUsuario], [Nombre], [Apellido1], [Apellido2], [Profesion], [Nacionalidad], [Email], [Telefono], [EnlaceContacto], [FechaActualizacion], [FechaCreacion], [ProcesoActualizacion], [ProcesoCreacion], [UsuarioActualizacion], [UsuarioCreacion], [FechaNacimiento], [IdFotoUsuarioCV], [IdCurriculum], [AcercaDe]) VALUES (4, 4, N'Lionel', N'Messi', N'Cuccitini', N'Futbolista', N'Argentina', N'lionelmessi@gmail.com', 655392677, NULL, CAST(N'2023-05-25T14:30:27.8878977' AS DateTime2), CAST(N'2023-05-25T14:24:22.7001682' AS DateTime2), N'GuardarUsuarioCV', N'NuevoUsuarioCV', 4, 4, CAST(N'1987-06-24T00:00:00.0000000' AS DateTime2), NULL, 10, N'Hola, soy Leo Messi, el mejor jugador del mundo.')
SET IDENTITY_INSERT [dbo].[UsuarioCV] OFF
GO
/****** Object:  Index [IX_AptitudCV_IdCurriculum]    Script Date: 08/06/2023 12:45:21 ******/
CREATE NONCLUSTERED INDEX [IX_AptitudCV_IdCurriculum] ON [dbo].[AptitudCV]
(
	[IdCurriculum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Contacto_IdUsuario]    Script Date: 08/06/2023 12:45:21 ******/
CREATE NONCLUSTERED INDEX [IX_Contacto_IdUsuario] ON [dbo].[Contacto]
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Entrada_IdProyecto]    Script Date: 08/06/2023 12:45:21 ******/
CREATE NONCLUSTERED INDEX [IX_Entrada_IdProyecto] ON [dbo].[Entrada]
(
	[IdProyecto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Entrada_IdUsuario]    Script Date: 08/06/2023 12:45:21 ******/
CREATE NONCLUSTERED INDEX [IX_Entrada_IdUsuario] ON [dbo].[Entrada]
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EntradaCV_IdCurriculum]    Script Date: 08/06/2023 12:45:21 ******/
CREATE NONCLUSTERED INDEX [IX_EntradaCV_IdCurriculum] ON [dbo].[EntradaCV]
(
	[IdCurriculum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EntradaCV_IdUsuario]    Script Date: 08/06/2023 12:45:21 ******/
CREATE NONCLUSTERED INDEX [IX_EntradaCV_IdUsuario] ON [dbo].[EntradaCV]
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EventosUsuario_IdUsuario]    Script Date: 08/06/2023 12:45:21 ******/
CREATE NONCLUSTERED INDEX [IX_EventosUsuario_IdUsuario] ON [dbo].[EventosUsuario]
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FormacionCV_IdCurriculum]    Script Date: 08/06/2023 12:45:21 ******/
CREATE NONCLUSTERED INDEX [IX_FormacionCV_IdCurriculum] ON [dbo].[FormacionCV]
(
	[IdCurriculum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FormacionCV_IdTipoFormacion]    Script Date: 08/06/2023 12:45:21 ******/
CREATE NONCLUSTERED INDEX [IX_FormacionCV_IdTipoFormacion] ON [dbo].[FormacionCV]
(
	[IdTipoFormacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FormacionCV_IdUsuario]    Script Date: 08/06/2023 12:45:21 ******/
CREATE NONCLUSTERED INDEX [IX_FormacionCV_IdUsuario] ON [dbo].[FormacionCV]
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FotoUsuarioCV_IdCurriculum]    Script Date: 08/06/2023 12:45:21 ******/
CREATE NONCLUSTERED INDEX [IX_FotoUsuarioCV_IdCurriculum] ON [dbo].[FotoUsuarioCV]
(
	[IdCurriculum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_IdiomaCV_IdCurriculum]    Script Date: 08/06/2023 12:45:21 ******/
CREATE NONCLUSTERED INDEX [IX_IdiomaCV_IdCurriculum] ON [dbo].[IdiomaCV]
(
	[IdCurriculum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_IdiomaCV_IdIdioma]    Script Date: 08/06/2023 12:45:21 ******/
CREATE NONCLUSTERED INDEX [IX_IdiomaCV_IdIdioma] ON [dbo].[IdiomaCV]
(
	[IdIdioma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_IdiomaCV_IdNivelIdioma]    Script Date: 08/06/2023 12:45:21 ******/
CREATE NONCLUSTERED INDEX [IX_IdiomaCV_IdNivelIdioma] ON [dbo].[IdiomaCV]
(
	[IdNivelIdioma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_IdiomaCV_IdUsuario]    Script Date: 08/06/2023 12:45:21 ******/
CREATE NONCLUSTERED INDEX [IX_IdiomaCV_IdUsuario] ON [dbo].[IdiomaCV]
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_LogroCV_IdCurriculum]    Script Date: 08/06/2023 12:45:21 ******/
CREATE NONCLUSTERED INDEX [IX_LogroCV_IdCurriculum] ON [dbo].[LogroCV]
(
	[IdCurriculum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_NotasUsuario_IdUsuario]    Script Date: 08/06/2023 12:45:21 ******/
CREATE NONCLUSTERED INDEX [IX_NotasUsuario_IdUsuario] ON [dbo].[NotasUsuario]
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Notificacion_IdTipoNotificacion]    Script Date: 08/06/2023 12:45:21 ******/
CREATE NONCLUSTERED INDEX [IX_Notificacion_IdTipoNotificacion] ON [dbo].[Notificacion]
(
	[IdTipoNotificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Notificacion_IdUsuario]    Script Date: 08/06/2023 12:45:21 ******/
CREATE NONCLUSTERED INDEX [IX_Notificacion_IdUsuario] ON [dbo].[Notificacion]
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Respuesta_IdEntrada]    Script Date: 08/06/2023 12:45:21 ******/
CREATE NONCLUSTERED INDEX [IX_Respuesta_IdEntrada] ON [dbo].[Respuesta]
(
	[IdEntrada] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Respuesta_IdUsuario]    Script Date: 08/06/2023 12:45:21 ******/
CREATE NONCLUSTERED INDEX [IX_Respuesta_IdUsuario] ON [dbo].[Respuesta]
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Usuario_IdDepartamento]    Script Date: 08/06/2023 12:45:21 ******/
CREATE NONCLUSTERED INDEX [IX_Usuario_IdDepartamento] ON [dbo].[Usuario]
(
	[IdDepartamento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Usuario_IdGrupo]    Script Date: 08/06/2023 12:45:21 ******/
CREATE NONCLUSTERED INDEX [IX_Usuario_IdGrupo] ON [dbo].[Usuario]
(
	[IdGrupo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Usuario_IdRol]    Script Date: 08/06/2023 12:45:21 ******/
CREATE NONCLUSTERED INDEX [IX_Usuario_IdRol] ON [dbo].[Usuario]
(
	[IdRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UsuarioCV_IdCurriculum]    Script Date: 08/06/2023 12:45:21 ******/
CREATE NONCLUSTERED INDEX [IX_UsuarioCV_IdCurriculum] ON [dbo].[UsuarioCV]
(
	[IdCurriculum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UsuarioCV_IdFotoUsuarioCV]    Script Date: 08/06/2023 12:45:21 ******/
CREATE NONCLUSTERED INDEX [IX_UsuarioCV_IdFotoUsuarioCV] ON [dbo].[UsuarioCV]
(
	[IdFotoUsuarioCV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UsuarioCV_IdUsuario]    Script Date: 08/06/2023 12:45:21 ******/
CREATE NONCLUSTERED INDEX [IX_UsuarioCV_IdUsuario] ON [dbo].[UsuarioCV]
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[EntradaCV] ADD  DEFAULT (N'') FOR [Observaciones]
GO
ALTER TABLE [dbo].[Usuario] ADD  DEFAULT (CONVERT([bit],(0))) FOR [EsAdmin]
GO
ALTER TABLE [dbo].[AptitudCV]  WITH CHECK ADD  CONSTRAINT [FK_AptitudCV_Curriculum_IdCurriculum] FOREIGN KEY([IdCurriculum])
REFERENCES [dbo].[Curriculum] ([IdCurriculum])
GO
ALTER TABLE [dbo].[AptitudCV] CHECK CONSTRAINT [FK_AptitudCV_Curriculum_IdCurriculum]
GO
ALTER TABLE [dbo].[Contacto]  WITH CHECK ADD  CONSTRAINT [FK_Contacto_Usuario_IdUsuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Contacto] CHECK CONSTRAINT [FK_Contacto_Usuario_IdUsuario]
GO
ALTER TABLE [dbo].[Entrada]  WITH CHECK ADD  CONSTRAINT [FK_Entrada_Proyecto_IdProyecto] FOREIGN KEY([IdProyecto])
REFERENCES [dbo].[Proyecto] ([IdProyecto])
GO
ALTER TABLE [dbo].[Entrada] CHECK CONSTRAINT [FK_Entrada_Proyecto_IdProyecto]
GO
ALTER TABLE [dbo].[Entrada]  WITH CHECK ADD  CONSTRAINT [FK_Entrada_Usuario_IdUsuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Entrada] CHECK CONSTRAINT [FK_Entrada_Usuario_IdUsuario]
GO
ALTER TABLE [dbo].[EntradaCV]  WITH CHECK ADD  CONSTRAINT [FK_EntradaCV_Curriculum_IdCurriculum] FOREIGN KEY([IdCurriculum])
REFERENCES [dbo].[Curriculum] ([IdCurriculum])
GO
ALTER TABLE [dbo].[EntradaCV] CHECK CONSTRAINT [FK_EntradaCV_Curriculum_IdCurriculum]
GO
ALTER TABLE [dbo].[FormacionCV]  WITH CHECK ADD  CONSTRAINT [FK_FormacionCV_Curriculum_IdCurriculum] FOREIGN KEY([IdCurriculum])
REFERENCES [dbo].[Curriculum] ([IdCurriculum])
GO
ALTER TABLE [dbo].[FormacionCV] CHECK CONSTRAINT [FK_FormacionCV_Curriculum_IdCurriculum]
GO
ALTER TABLE [dbo].[FormacionCV]  WITH CHECK ADD  CONSTRAINT [FK_FormacionCV_TipoFormacion_IdTipoFormacion] FOREIGN KEY([IdTipoFormacion])
REFERENCES [dbo].[TipoFormacion] ([IdTipoFormacion])
GO
ALTER TABLE [dbo].[FormacionCV] CHECK CONSTRAINT [FK_FormacionCV_TipoFormacion_IdTipoFormacion]
GO
ALTER TABLE [dbo].[FotoUsuarioCV]  WITH CHECK ADD  CONSTRAINT [FK_FotoUsuarioCV_Curriculum_IdCurriculum] FOREIGN KEY([IdCurriculum])
REFERENCES [dbo].[Curriculum] ([IdCurriculum])
GO
ALTER TABLE [dbo].[FotoUsuarioCV] CHECK CONSTRAINT [FK_FotoUsuarioCV_Curriculum_IdCurriculum]
GO
ALTER TABLE [dbo].[IdiomaCV]  WITH CHECK ADD  CONSTRAINT [FK_IdiomaCV_Curriculum_IdCurriculum] FOREIGN KEY([IdCurriculum])
REFERENCES [dbo].[Curriculum] ([IdCurriculum])
GO
ALTER TABLE [dbo].[IdiomaCV] CHECK CONSTRAINT [FK_IdiomaCV_Curriculum_IdCurriculum]
GO
ALTER TABLE [dbo].[IdiomaCV]  WITH CHECK ADD  CONSTRAINT [FK_IdiomaCV_Idioma_IdIdioma] FOREIGN KEY([IdIdioma])
REFERENCES [dbo].[Idioma] ([IdIdioma])
GO
ALTER TABLE [dbo].[IdiomaCV] CHECK CONSTRAINT [FK_IdiomaCV_Idioma_IdIdioma]
GO
ALTER TABLE [dbo].[IdiomaCV]  WITH CHECK ADD  CONSTRAINT [FK_IdiomaCV_NivelIdioma_IdNivelIdioma] FOREIGN KEY([IdNivelIdioma])
REFERENCES [dbo].[NivelIdioma] ([idNivelIdioma])
GO
ALTER TABLE [dbo].[IdiomaCV] CHECK CONSTRAINT [FK_IdiomaCV_NivelIdioma_IdNivelIdioma]
GO
ALTER TABLE [dbo].[LogroCV]  WITH CHECK ADD  CONSTRAINT [FK_LogroCV_Curriculum_IdCurriculum] FOREIGN KEY([IdCurriculum])
REFERENCES [dbo].[Curriculum] ([IdCurriculum])
GO
ALTER TABLE [dbo].[LogroCV] CHECK CONSTRAINT [FK_LogroCV_Curriculum_IdCurriculum]
GO
ALTER TABLE [dbo].[NotasUsuario]  WITH CHECK ADD  CONSTRAINT [FK_NotasUsuario_Usuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[NotasUsuario] CHECK CONSTRAINT [FK_NotasUsuario_Usuario]
GO
ALTER TABLE [dbo].[Notificacion]  WITH CHECK ADD  CONSTRAINT [FK_Notificacion_TipoNotificacion_IdTipoNotificacion] FOREIGN KEY([IdTipoNotificacion])
REFERENCES [dbo].[TipoNotificacion] ([IdTipoNotificacion])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Notificacion] CHECK CONSTRAINT [FK_Notificacion_TipoNotificacion_IdTipoNotificacion]
GO
ALTER TABLE [dbo].[Respuesta]  WITH CHECK ADD  CONSTRAINT [FK_Respuesta_Entrada_IdEntrada] FOREIGN KEY([IdEntrada])
REFERENCES [dbo].[Entrada] ([IdEntrada])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Respuesta] CHECK CONSTRAINT [FK_Respuesta_Entrada_IdEntrada]
GO
ALTER TABLE [dbo].[Respuesta]  WITH CHECK ADD  CONSTRAINT [FK_Respuesta_Usuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Respuesta] CHECK CONSTRAINT [FK_Respuesta_Usuario]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Departamento] FOREIGN KEY([IdDepartamento])
REFERENCES [dbo].[Departamento] ([IdDepartamento])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Departamento]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Grupo] FOREIGN KEY([IdGrupo])
REFERENCES [dbo].[Grupo] ([IdGrupo])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Grupo]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Rol_IdRol] FOREIGN KEY([IdRol])
REFERENCES [dbo].[Rol] ([IdRol])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Rol_IdRol]
GO
ALTER TABLE [dbo].[UsuarioCV]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioCV_Curriculum_IdCurriculum] FOREIGN KEY([IdCurriculum])
REFERENCES [dbo].[Curriculum] ([IdCurriculum])
GO
ALTER TABLE [dbo].[UsuarioCV] CHECK CONSTRAINT [FK_UsuarioCV_Curriculum_IdCurriculum]
GO
ALTER TABLE [dbo].[UsuarioCV]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioCV_FotoUsuarioCV_IdFotoUsuarioCV] FOREIGN KEY([IdFotoUsuarioCV])
REFERENCES [dbo].[FotoUsuarioCV] ([IdFotoUsuarioCV])
GO
ALTER TABLE [dbo].[UsuarioCV] CHECK CONSTRAINT [FK_UsuarioCV_FotoUsuarioCV_IdFotoUsuarioCV]
GO
ALTER TABLE [dbo].[UsuarioCV]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioCV_Usuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[UsuarioCV] CHECK CONSTRAINT [FK_UsuarioCV_Usuario]
GO
USE [master]
GO
ALTER DATABASE [CSA_CVM] SET  READ_WRITE 
GO
