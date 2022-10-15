USE [master]
GO
/****** Object:  Database [DetailTEC_DB]    Script Date: 10/15/2022 12:10:10 AM ******/
CREATE DATABASE [DetailTEC_DB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DetailTEC_DB', FILENAME = N'H:\Programming\SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\DetailTEC_DB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DetailTEC_DB_log', FILENAME = N'H:\Programming\SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\DetailTEC_DB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DetailTEC_DB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DetailTEC_DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DetailTEC_DB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DetailTEC_DB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DetailTEC_DB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DetailTEC_DB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DetailTEC_DB] SET ARITHABORT OFF 
GO
ALTER DATABASE [DetailTEC_DB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DetailTEC_DB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DetailTEC_DB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DetailTEC_DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DetailTEC_DB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DetailTEC_DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DetailTEC_DB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DetailTEC_DB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DetailTEC_DB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DetailTEC_DB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DetailTEC_DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DetailTEC_DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DetailTEC_DB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DetailTEC_DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DetailTEC_DB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DetailTEC_DB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DetailTEC_DB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DetailTEC_DB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DetailTEC_DB] SET  MULTI_USER 
GO
ALTER DATABASE [DetailTEC_DB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DetailTEC_DB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DetailTEC_DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DetailTEC_DB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DetailTEC_DB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DetailTEC_DB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [DetailTEC_DB] SET QUERY_STORE = OFF
GO
USE [DetailTEC_DB]
GO
/****** Object:  Table [dbo].[Cita]    Script Date: 10/15/2022 12:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cita](
	[cliente] [int] NOT NULL,
	[placaVehiculo] [varchar](50) NOT NULL,
	[sucursal] [varchar](50) NOT NULL,
	[tipoLavado] [varchar](50) NOT NULL,
	[responsable] [int] NOT NULL,
	[factura] [int] NOT NULL,
	[numeroCita] [int] NOT NULL,
 CONSTRAINT [PK_Cita] PRIMARY KEY CLUSTERED 
(
	[numeroCita] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 10/15/2022 12:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[cedula] [int] NOT NULL,
	[nombreCompleto] [varchar](50) NULL,
	[puntos] [int] NULL,
	[contrasena] [varchar](50) NULL,
	[correo] [varchar](50) NULL,
	[usuario] [varchar](50) NULL,
	[direccion] [varchar](100) NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[cedula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Factura]    Script Date: 10/15/2022 12:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Factura](
	[ID_Factura] [int] NOT NULL,
	[servicio] [varchar](50) NULL,
	[monto] [int] NULL,
	[iva] [int] NULL,
	[cliente] [int] NULL,
 CONSTRAINT [PK_Factura] PRIMARY KEY CLUSTERED 
(
	[ID_Factura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lavado]    Script Date: 10/15/2022 12:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lavado](
	[personalRequerido] [int] NULL,
	[precio] [int] NULL,
	[costo] [int] NULL,
	[nombre] [varchar](50) NOT NULL,
	[duracion] [int] NULL,
	[puntuacionLealtad] [int] NULL,
 CONSTRAINT [PK_Lavado] PRIMARY KEY CLUSTERED 
(
	[nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 10/15/2022 12:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[nombre] [varchar](50) NOT NULL,
	[marca] [varchar](50) NULL,
	[costo] [int] NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto_por_Factura]    Script Date: 10/15/2022 12:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto_por_Factura](
	[ID_Factura] [int] NOT NULL,
	[nombre_producto] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto_por_Proveedor]    Script Date: 10/15/2022 12:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto_por_Proveedor](
	[cedula_proveedor] [int] NOT NULL,
	[nombre_producto] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Productos_por_Lavado]    Script Date: 10/15/2022 12:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos_por_Lavado](
	[nombre_producto] [varchar](50) NOT NULL,
	[nombre_lavado] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proveedor]    Script Date: 10/15/2022 12:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proveedor](
	[nombre] [varchar](50) NULL,
	[cedulaJuridica] [int] NOT NULL,
	[direccion] [varchar](50) NULL,
	[correo] [varchar](50) NULL,
	[contacto] [varchar](50) NULL,
 CONSTRAINT [PK_Proveedor] PRIMARY KEY CLUSTERED 
(
	[cedulaJuridica] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Snack]    Script Date: 10/15/2022 12:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Snack](
	[ID_Snack] [int] NOT NULL,
	[nombre] [varchar](50) NULL,
	[inventario] [int] NULL,
	[precio] [int] NULL,
 CONSTRAINT [PK_Snack] PRIMARY KEY CLUSTERED 
(
	[ID_Snack] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sucursal]    Script Date: 10/15/2022 12:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sucursal](
	[nombre] [varchar](50) NOT NULL,
	[fechaInicioGerente] [date] NULL,
	[fechaApertura] [date] NULL,
	[ubicacion] [varchar](50) NULL,
	[gerente] [int] NULL,
	[telefono] [int] NULL,
 CONSTRAINT [PK_Sucursal] PRIMARY KEY CLUSTERED 
(
	[nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Telefonos_por_Cliente]    Script Date: 10/15/2022 12:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Telefonos_por_Cliente](
	[cliente] [int] NOT NULL,
	[telefono] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Trabajador]    Script Date: 10/15/2022 12:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Trabajador](
	[cedula] [int] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellidos] [varchar](50) NOT NULL,
	[contrasena] [varchar](50) NOT NULL,
	[edad] [int] NOT NULL,
	[fechaNacimiento] [date] NOT NULL,
	[fechaIngreso] [date] NOT NULL,
	[tipoPago] [varchar](50) NOT NULL,
	[rol] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Trabajador] PRIMARY KEY CLUSTERED 
(
	[cedula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [DetailTEC_DB] SET  READ_WRITE 
GO
