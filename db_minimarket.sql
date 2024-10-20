USE [master]
GO
/****** Object:  Database [db_minimarketIntec]    Script Date: 18/10/2024 12:41:29 ******/
CREATE DATABASE [db_minimarketIntec]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'db_minimarketIntec', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\db_minimarketIntec.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'db_minimarketIntec_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\db_minimarketIntec_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [db_minimarketIntec] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [db_minimarketIntec].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [db_minimarketIntec] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [db_minimarketIntec] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [db_minimarketIntec] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [db_minimarketIntec] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [db_minimarketIntec] SET ARITHABORT OFF 
GO
ALTER DATABASE [db_minimarketIntec] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [db_minimarketIntec] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [db_minimarketIntec] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [db_minimarketIntec] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [db_minimarketIntec] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [db_minimarketIntec] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [db_minimarketIntec] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [db_minimarketIntec] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [db_minimarketIntec] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [db_minimarketIntec] SET  ENABLE_BROKER 
GO
ALTER DATABASE [db_minimarketIntec] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [db_minimarketIntec] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [db_minimarketIntec] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [db_minimarketIntec] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [db_minimarketIntec] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [db_minimarketIntec] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [db_minimarketIntec] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [db_minimarketIntec] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [db_minimarketIntec] SET  MULTI_USER 
GO
ALTER DATABASE [db_minimarketIntec] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [db_minimarketIntec] SET DB_CHAINING OFF 
GO
ALTER DATABASE [db_minimarketIntec] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [db_minimarketIntec] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [db_minimarketIntec] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [db_minimarketIntec] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'db_minimarketIntec', N'ON'
GO
ALTER DATABASE [db_minimarketIntec] SET QUERY_STORE = ON
GO
ALTER DATABASE [db_minimarketIntec] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [db_minimarketIntec]
GO
/****** Object:  Table [dbo].[almacenes]    Script Date: 18/10/2024 12:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[almacenes](
	[codigo_alm] [int] IDENTITY(1,1) NOT NULL,
	[descripcion_alm] [varchar](50) NULL,
	[estado] [bit] NULL,
 CONSTRAINT [PK_almacenes] PRIMARY KEY CLUSTERED 
(
	[codigo_alm] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[categorias]    Script Date: 18/10/2024 12:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[categorias](
	[codigo_cat] [int] IDENTITY(1,1) NOT NULL,
	[descripcion_cat] [varchar](50) NOT NULL,
	[estado] [bit] NOT NULL,
 CONSTRAINT [PK_categorias] PRIMARY KEY CLUSTERED 
(
	[codigo_cat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[detalle_entrada_productos]    Script Date: 18/10/2024 12:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[detalle_entrada_productos](
	[codigo_enc_prod] [int] NULL,
	[codigo_prod] [int] NULL,
	[cantidad] [decimal](18, 2) NULL,
	[precio_unitario_compra] [decimal](18, 2) NULL,
	[total] [decimal](18, 2) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[encabezado_entrada_productos]    Script Date: 18/10/2024 12:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[encabezado_entrada_productos](
	[codigo_enc_prod] [int] IDENTITY(1,1) NOT NULL,
	[codigo_tipo_doc_emitir] [int] NULL,
	[numero_doc_ent_prod] [varchar](50) NULL,
	[codigo_proveedor] [int] NULL,
	[fecha_entrada_prod] [date] NULL,
	[codigo_alm] [int] NULL,
	[comentarios] [text] NULL,
	[subtotal] [decimal](18, 2) NULL,
	[itbis] [decimal](18, 2) NULL,
	[total_importe] [decimal](18, 2) NULL,
	[fecha_creacion] [datetime] NULL,
	[estado] [bit] NULL,
 CONSTRAINT [PK_encabezado_entrada_productos] PRIMARY KEY CLUSTERED 
(
	[codigo_enc_prod] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[marcas]    Script Date: 18/10/2024 12:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[marcas](
	[codigo_marca] [int] IDENTITY(1,1) NOT NULL,
	[descripcion_marca] [varchar](50) NOT NULL,
	[estado] [bit] NOT NULL,
 CONSTRAINT [PK_marcas] PRIMARY KEY CLUSTERED 
(
	[codigo_marca] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[municipios]    Script Date: 18/10/2024 12:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[municipios](
	[codigo_municipio] [int] IDENTITY(1,1) NOT NULL,
	[descripcion_municipio] [varchar](100) NULL,
	[codigo_provincia] [int] NULL,
	[estado] [bit] NULL,
 CONSTRAINT [PK_municipios] PRIMARY KEY CLUSTERED 
(
	[codigo_municipio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pais]    Script Date: 18/10/2024 12:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pais](
	[codigo_pais] [int] IDENTITY(1,1) NOT NULL,
	[descripcion_pais] [varchar](50) NULL,
	[estado] [bit] NULL,
 CONSTRAINT [PK_pais] PRIMARY KEY CLUSTERED 
(
	[codigo_pais] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[productos]    Script Date: 18/10/2024 12:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[productos](
	[codigo_prod] [int] IDENTITY(1,1) NOT NULL,
	[descripcion_prod] [varchar](100) NULL,
	[codigo_marca] [int] NOT NULL,
	[codigo_um] [int] NOT NULL,
	[codigo_cat] [int] NOT NULL,
	[stock_min] [decimal](18, 2) NOT NULL,
	[fecha_creacion] [datetime] NULL,
	[fecha_modificacion] [datetime] NULL,
	[stock_max] [decimal](18, 2) NOT NULL,
	[estado] [bit] NOT NULL,
 CONSTRAINT [PK_productos] PRIMARY KEY CLUSTERED 
(
	[codigo_prod] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[proveedores]    Script Date: 18/10/2024 12:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[proveedores](
	[codigo_proveedor] [int] IDENTITY(1,1) NOT NULL,
	[codigo_tipo_doc_pc] [int] NULL,
	[numero_doc_proveedor] [varchar](50) NULL,
	[razon_social_proveedor] [varchar](150) NULL,
	[nombres] [varchar](100) NULL,
	[apellidos] [varchar](100) NULL,
	[codigo_sexo] [int] NULL,
	[codigo_ru] [int] NULL,
	[email_proveedor] [varchar](150) NULL,
	[telefono_proveedor] [varchar](20) NULL,
	[movil_proveedor] [varchar](20) NULL,
	[direccion_proveedor] [text] NULL,
	[codigo_municipio] [int] NULL,
	[comentarios] [text] NULL,
	[fecha_proveedor] [datetime] NULL,
	[fecha_modificacion] [datetime] NULL,
	[estado] [bit] NULL,
 CONSTRAINT [PK_proveedores] PRIMARY KEY CLUSTERED 
(
	[codigo_proveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[provincias]    Script Date: 18/10/2024 12:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[provincias](
	[codigo_provincia] [int] IDENTITY(1,1) NOT NULL,
	[descripcion_provincia] [varchar](100) NULL,
	[codigo_pais] [int] NULL,
	[estado] [bit] NULL,
 CONSTRAINT [PK_provincias] PRIMARY KEY CLUSTERED 
(
	[codigo_provincia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[rubros]    Script Date: 18/10/2024 12:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rubros](
	[codigo_ru] [int] IDENTITY(1,1) NOT NULL,
	[descripcion_ru] [varchar](50) NULL,
	[estado] [bit] NULL,
 CONSTRAINT [PK_rubros] PRIMARY KEY CLUSTERED 
(
	[codigo_ru] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sexos]    Script Date: 18/10/2024 12:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sexos](
	[codigo_sexo] [int] IDENTITY(0,1) NOT NULL,
	[descripcion_sexo] [varchar](50) NULL,
	[estado] [bit] NULL,
 CONSTRAINT [PK_sexos] PRIMARY KEY CLUSTERED 
(
	[codigo_sexo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[stockproductos]    Script Date: 18/10/2024 12:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stockproductos](
	[codigo_prod] [int] NULL,
	[codigo_alm] [int] NULL,
	[stock_actual] [decimal](18, 2) NULL,
	[precio_compra_unitario] [decimal](18, 2) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tipos_doc_emitir]    Script Date: 18/10/2024 12:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tipos_doc_emitir](
	[codigo_tipo_doc_emitir] [int] IDENTITY(0,1) NOT NULL,
	[descripcion_tipo_doc_emitir] [varchar](50) NULL,
	[estado] [bit] NULL,
 CONSTRAINT [PK_tipos_doc_emitir] PRIMARY KEY CLUSTERED 
(
	[codigo_tipo_doc_emitir] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tipos_doc_prov_cl]    Script Date: 18/10/2024 12:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tipos_doc_prov_cl](
	[codigo_tipo_doc_pc] [int] IDENTITY(0,1) NOT NULL,
	[descripcion_tipo_doc_pc] [varchar](50) NULL,
	[estado] [bit] NULL,
 CONSTRAINT [PK_tipos_doc_prov_cl] PRIMARY KEY CLUSTERED 
(
	[codigo_tipo_doc_pc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[unidades_medida]    Script Date: 18/10/2024 12:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[unidades_medida](
	[codigo_um] [int] IDENTITY(1,1) NOT NULL,
	[abreviatura_um] [varchar](5) NULL,
	[descripcion_um] [varchar](20) NULL,
	[estado] [bit] NULL,
 CONSTRAINT [PK_unidades_medida] PRIMARY KEY CLUSTERED 
(
	[codigo_um] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[detalle_entrada_productos]  WITH CHECK ADD  CONSTRAINT [FK_detalle_entrada_productos_encabezado_entrada_productos] FOREIGN KEY([codigo_enc_prod])
REFERENCES [dbo].[encabezado_entrada_productos] ([codigo_enc_prod])
GO
ALTER TABLE [dbo].[detalle_entrada_productos] CHECK CONSTRAINT [FK_detalle_entrada_productos_encabezado_entrada_productos]
GO
ALTER TABLE [dbo].[detalle_entrada_productos]  WITH CHECK ADD  CONSTRAINT [FK_detalle_entrada_productos_productos] FOREIGN KEY([codigo_prod])
REFERENCES [dbo].[productos] ([codigo_prod])
GO
ALTER TABLE [dbo].[detalle_entrada_productos] CHECK CONSTRAINT [FK_detalle_entrada_productos_productos]
GO
ALTER TABLE [dbo].[encabezado_entrada_productos]  WITH CHECK ADD  CONSTRAINT [FK_encabezado_entrada_productos_almacenes] FOREIGN KEY([codigo_alm])
REFERENCES [dbo].[almacenes] ([codigo_alm])
GO
ALTER TABLE [dbo].[encabezado_entrada_productos] CHECK CONSTRAINT [FK_encabezado_entrada_productos_almacenes]
GO
ALTER TABLE [dbo].[encabezado_entrada_productos]  WITH CHECK ADD  CONSTRAINT [FK_encabezado_entrada_productos_proveedores] FOREIGN KEY([codigo_proveedor])
REFERENCES [dbo].[proveedores] ([codigo_proveedor])
GO
ALTER TABLE [dbo].[encabezado_entrada_productos] CHECK CONSTRAINT [FK_encabezado_entrada_productos_proveedores]
GO
ALTER TABLE [dbo].[encabezado_entrada_productos]  WITH CHECK ADD  CONSTRAINT [FK_encabezado_entrada_productos_tipos_doc_emitir] FOREIGN KEY([codigo_tipo_doc_emitir])
REFERENCES [dbo].[tipos_doc_emitir] ([codigo_tipo_doc_emitir])
GO
ALTER TABLE [dbo].[encabezado_entrada_productos] CHECK CONSTRAINT [FK_encabezado_entrada_productos_tipos_doc_emitir]
GO
ALTER TABLE [dbo].[municipios]  WITH CHECK ADD  CONSTRAINT [FK_municipios_provincias] FOREIGN KEY([codigo_provincia])
REFERENCES [dbo].[provincias] ([codigo_provincia])
GO
ALTER TABLE [dbo].[municipios] CHECK CONSTRAINT [FK_municipios_provincias]
GO
ALTER TABLE [dbo].[productos]  WITH CHECK ADD  CONSTRAINT [FK_productos_categorias] FOREIGN KEY([codigo_cat])
REFERENCES [dbo].[categorias] ([codigo_cat])
GO
ALTER TABLE [dbo].[productos] CHECK CONSTRAINT [FK_productos_categorias]
GO
ALTER TABLE [dbo].[productos]  WITH CHECK ADD  CONSTRAINT [FK_productos_marcas] FOREIGN KEY([codigo_marca])
REFERENCES [dbo].[marcas] ([codigo_marca])
GO
ALTER TABLE [dbo].[productos] CHECK CONSTRAINT [FK_productos_marcas]
GO
ALTER TABLE [dbo].[productos]  WITH CHECK ADD  CONSTRAINT [FK_productos_unidades_medida] FOREIGN KEY([codigo_um])
REFERENCES [dbo].[unidades_medida] ([codigo_um])
GO
ALTER TABLE [dbo].[productos] CHECK CONSTRAINT [FK_productos_unidades_medida]
GO
ALTER TABLE [dbo].[proveedores]  WITH CHECK ADD  CONSTRAINT [FK_proveedores_municipios] FOREIGN KEY([codigo_municipio])
REFERENCES [dbo].[municipios] ([codigo_municipio])
GO
ALTER TABLE [dbo].[proveedores] CHECK CONSTRAINT [FK_proveedores_municipios]
GO
ALTER TABLE [dbo].[proveedores]  WITH CHECK ADD  CONSTRAINT [FK_proveedores_rubros] FOREIGN KEY([codigo_ru])
REFERENCES [dbo].[rubros] ([codigo_ru])
GO
ALTER TABLE [dbo].[proveedores] CHECK CONSTRAINT [FK_proveedores_rubros]
GO
ALTER TABLE [dbo].[proveedores]  WITH CHECK ADD  CONSTRAINT [FK_proveedores_sexos] FOREIGN KEY([codigo_sexo])
REFERENCES [dbo].[sexos] ([codigo_sexo])
GO
ALTER TABLE [dbo].[proveedores] CHECK CONSTRAINT [FK_proveedores_sexos]
GO
ALTER TABLE [dbo].[proveedores]  WITH CHECK ADD  CONSTRAINT [FK_proveedores_tipos_doc_prov_cl] FOREIGN KEY([codigo_tipo_doc_pc])
REFERENCES [dbo].[tipos_doc_prov_cl] ([codigo_tipo_doc_pc])
GO
ALTER TABLE [dbo].[proveedores] CHECK CONSTRAINT [FK_proveedores_tipos_doc_prov_cl]
GO
ALTER TABLE [dbo].[provincias]  WITH CHECK ADD  CONSTRAINT [FK_provincias_pais] FOREIGN KEY([codigo_pais])
REFERENCES [dbo].[pais] ([codigo_pais])
GO
ALTER TABLE [dbo].[provincias] CHECK CONSTRAINT [FK_provincias_pais]
GO
ALTER TABLE [dbo].[stockproductos]  WITH CHECK ADD  CONSTRAINT [FK_stockproductos_almacenes1] FOREIGN KEY([codigo_alm])
REFERENCES [dbo].[almacenes] ([codigo_alm])
GO
ALTER TABLE [dbo].[stockproductos] CHECK CONSTRAINT [FK_stockproductos_almacenes1]
GO
ALTER TABLE [dbo].[stockproductos]  WITH CHECK ADD  CONSTRAINT [FK_stockproductos_productos1] FOREIGN KEY([codigo_prod])
REFERENCES [dbo].[productos] ([codigo_prod])
GO
ALTER TABLE [dbo].[stockproductos] CHECK CONSTRAINT [FK_stockproductos_productos1]
GO
/****** Object:  StoredProcedure [dbo].[SP_Categoria_Seleccionar]    Script Date: 18/10/2024 12:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[SP_Categoria_Seleccionar]
as
select codigo_cat, descripcion_cat from categorias
where estado=1
GO
/****** Object:  StoredProcedure [dbo].[SP_Desactivar_Almacen]    Script Date: 18/10/2024 12:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--descativar categorias
CREATE PROCEDURE [dbo].[SP_Desactivar_Almacen]
	-- Add the parameters for the stored procedure here
	@codigo_alm int
AS

    -- Insert statements for procedure here
	UPDATE almacenes SET estado=0
	WHERE codigo_alm=@codigo_alm
GO
/****** Object:  StoredProcedure [dbo].[SP_Desactivar_Categoria]    Script Date: 18/10/2024 12:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--descativar categorias
CREATE PROCEDURE [dbo].[SP_Desactivar_Categoria] 
	-- Add the parameters for the stored procedure here
	@codigo_cat int
AS

    -- Insert statements for procedure here
	UPDATE categorias SET estado=0
	WHERE codigo_cat=@codigo_cat
GO
/****** Object:  StoredProcedure [dbo].[SP_Desactivar_Marca]    Script Date: 18/10/2024 12:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--desactivar marca
CREATE PROCEDURE [dbo].[SP_Desactivar_Marca] 
	-- Add the parameters for the stored procedure here
	@codigo_marca int
AS

    -- Insert statements for procedure here
	UPDATE marcas SET estado=0
	WHERE codigo_marca=@codigo_marca
GO
/****** Object:  StoredProcedure [dbo].[SP_Desactivar_Municipio]    Script Date: 18/10/2024 12:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--desactivar distrito
CREATE PROCEDURE [dbo].[SP_Desactivar_Municipio]
	-- Add the parameters for the stored procedure here
	@codigo_municipio int
AS

    -- Insert statements for procedure here
	UPDATE municipios SET estado=0
	WHERE codigo_municipio=@codigo_municipio
GO
/****** Object:  StoredProcedure [dbo].[SP_Desactivar_Pais]    Script Date: 18/10/2024 12:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--desactivar pais
CREATE PROCEDURE [dbo].[SP_Desactivar_Pais]
	-- Add the parameters for the stored procedure here
	@codigo_pais int
AS

    -- Insert statements for procedure here
	UPDATE pais SET estado=0
	WHERE codigo_pais=@codigo_pais
GO
/****** Object:  StoredProcedure [dbo].[SP_Desactivar_Producto]    Script Date: 18/10/2024 12:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--desactivar producto
CREATE PROCEDURE [dbo].[SP_Desactivar_Producto]
	-- Add the parameters for the stored procedure here
	@codigo_producto int
AS

    -- Insert statements for procedure here
	UPDATE productos SET estado=0
	WHERE codigo_prod=@codigo_producto
GO
/****** Object:  StoredProcedure [dbo].[SP_Desactivar_Proveedor]    Script Date: 18/10/2024 12:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--desactivar proveedor
CREATE PROCEDURE [dbo].[SP_Desactivar_Proveedor]
	-- Add the parameters for the stored procedure here
	@codigo_proveedor int
AS

    -- Insert statements for procedure here
	UPDATE proveedores SET estado=0
	WHERE codigo_proveedor=@codigo_proveedor
GO
/****** Object:  StoredProcedure [dbo].[SP_Desactivar_Provincia]    Script Date: 18/10/2024 12:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--desactivar provincia
CREATE PROCEDURE [dbo].[SP_Desactivar_Provincia]
	-- Add the parameters for the stored procedure here
	@codigo_provincia int
AS

    -- Insert statements for procedure here
	UPDATE provincias SET estado=0
	WHERE codigo_provincia=@codigo_provincia
GO
/****** Object:  StoredProcedure [dbo].[SP_Desactivar_Rubro]    Script Date: 18/10/2024 12:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--desactivar rubro
CREATE PROCEDURE [dbo].[SP_Desactivar_Rubro]
	-- Add the parameters for the stored procedure here
	@codigo_ru int
AS

    -- Insert statements for procedure here
	UPDATE rubros SET estado=0
	WHERE codigo_ru=@codigo_ru
GO
/****** Object:  StoredProcedure [dbo].[SP_Desactivar_UM]    Script Date: 18/10/2024 12:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--desactivar UM
CREATE PROCEDURE [dbo].[SP_Desactivar_UM] 
	-- Add the parameters for the stored procedure here
	@codigo_um int
AS

    -- Insert statements for procedure here
	UPDATE unidades_medida SET estado=0
	WHERE codigo_um=@codigo_um
GO
/****** Object:  StoredProcedure [dbo].[SP_Existe_Almacen]    Script Date: 18/10/2024 12:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Determinar si una categoría existe
create proc [dbo].[SP_Existe_Almacen]
@valor varchar(100),
@existe bit output
as
	if exists (select descripcion_alm from almacenes where descripcion_alm = ltrim(rtrim(@valor)))
		begin
		 set @existe=1
		end
	else
		begin
		 set @existe=0
		end
GO
/****** Object:  StoredProcedure [dbo].[SP_Existe_Categoria]    Script Date: 18/10/2024 12:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Determinar si una categoría existe
create proc [dbo].[SP_Existe_Categoria]
@valor varchar(100),
@existe bit output
as
	if exists (select descripcion_cat from categorias where descripcion_cat = ltrim(rtrim(@valor)))
		begin
		 set @existe=1
		end
	else
		begin
		 set @existe=0
		end
GO
/****** Object:  StoredProcedure [dbo].[SP_Existe_Marca]    Script Date: 18/10/2024 12:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Determinar si una categoría existe
create proc [dbo].[SP_Existe_Marca]
@valor varchar(100),
@existe bit output
as
	if exists (select descripcion_marca from marcas where descripcion_marca = ltrim(rtrim(@valor)))
		begin
		 set @existe=1
		end
	else
		begin
		 set @existe=0
		end
GO
/****** Object:  StoredProcedure [dbo].[SP_Existe_Municipio]    Script Date: 18/10/2024 12:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--Determinar si un distrito existe
CREATE proc [dbo].[SP_Existe_Municipio]
@valor varchar(100),
@existe bit output
as
	if exists (select descripcion_municipio from municipios where descripcion_municipio = ltrim(rtrim(@valor)))
		begin
		 set @existe=1
		end
	else
		begin
		 set @existe=0
		end
GO
/****** Object:  StoredProcedure [dbo].[SP_Existe_Pais]    Script Date: 18/10/2024 12:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Determinar si un pais existe
create proc [dbo].[SP_Existe_Pais]
@valor varchar(100),
@existe bit output
as
	if exists (select descripcion_pais from pais where descripcion_pais = ltrim(rtrim(@valor)))
		begin
		 set @existe=1
		end
	else
		begin
		 set @existe=0
		end
GO
/****** Object:  StoredProcedure [dbo].[SP_Existe_Producto]    Script Date: 18/10/2024 12:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Determinar si un producto existe
create proc [dbo].[SP_Existe_Producto]
@valor varchar(100),
@existe bit output
as
	if exists (select descripcion_prod from productos where descripcion_prod = ltrim(rtrim(@valor)))
		begin
		 set @existe=1
		end
	else
		begin
		 set @existe=0
		end
GO
/****** Object:  StoredProcedure [dbo].[SP_Existe_Proveedor]    Script Date: 18/10/2024 12:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Determinar si un distrito existe
create proc [dbo].[SP_Existe_Proveedor]
@valor varchar(100),
@existe bit output
as
	if exists (select razon_social_proveedor from proveedores where razon_social_proveedor = ltrim(rtrim(@valor))
	OR numero_doc_proveedor = ltrim(rtrim(@valor))
	)
		begin
		 set @existe=1
		end
	else
		begin
		 set @existe=0
		end
GO
/****** Object:  StoredProcedure [dbo].[SP_Existe_Provincia]    Script Date: 18/10/2024 12:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Determinar si una provincia existe
create proc [dbo].[SP_Existe_Provincia]
@valor varchar(100),
@existe bit output
as
	if exists (select descripcion_provincia from provincias where descripcion_provincia = ltrim(rtrim(@valor)))
		begin
		 set @existe=1
		end
	else
		begin
		 set @existe=0
		end
GO
/****** Object:  StoredProcedure [dbo].[SP_Existe_Rubro]    Script Date: 18/10/2024 12:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Determinar si un rubro existe
create proc [dbo].[SP_Existe_Rubro]
@valor varchar(100),
@existe bit output
as
	if exists (select descripcion_ru from rubros where descripcion_ru = ltrim(rtrim(@valor)))
		begin
		 set @existe=1
		end
	else
		begin
		 set @existe=0
		end
GO
/****** Object:  StoredProcedure [dbo].[SP_Existe_UM]    Script Date: 18/10/2024 12:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Determinar si una categoría existe
create proc [dbo].[SP_Existe_UM]
@valor varchar(100),
@existe bit output
as
	if exists (select descripcion_um from unidades_medida where descripcion_um = ltrim(rtrim(@valor)))
		begin
		 set @existe=1
		end
	else
		begin
		 set @existe=0
		end
GO
/****** Object:  StoredProcedure [dbo].[SP_Listado_Rubros]    Script Date: 18/10/2024 12:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--Listar rubros para cargar en el combobox
create proc [dbo].[SP_Listado_Rubros]
as
select codigo_ru, descripcion_ru from rubros
where estado=1
GO
/****** Object:  StoredProcedure [dbo].[SP_Listado_Sexo]    Script Date: 18/10/2024 12:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Listar sexos para cargar en el combobox
create proc [dbo].[SP_Listado_Sexo]
as
select codigo_sexo, descripcion_sexo from sexos
where estado=1
GO
/****** Object:  StoredProcedure [dbo].[SP_Listado_Tipo_Doc_PC]    Script Date: 18/10/2024 12:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--Listar tipos de documentos Proveedor Cliente para cargar en el combobox
create proc [dbo].[SP_Listado_Tipo_Doc_PC]
as
select codigo_tipo_doc_pc, descripcion_tipo_doc_pc from tipos_doc_prov_cl
where estado=1
GO
/****** Object:  StoredProcedure [dbo].[SP_Listar_Almacenes]    Script Date: 18/10/2024 12:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--listar categorias con estado activo

CREATE PROCEDURE [dbo].[SP_Listar_Almacenes] 
	-- Add the parameters for the stored procedure here
	@valor varchar(100) = ''

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM almacenes WHERE estado=1
	AND (UPPER(TRIM(CAST(codigo_alm AS char))) LIKE '%' + @valor + '%' OR  UPPER(TRIM(descripcion_alm)) LIKE '%' + UPPER(TRIM(@valor)) + '%')
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Listar_Categorias]    Script Date: 18/10/2024 12:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--listar categorias con estado activo

CREATE PROCEDURE [dbo].[SP_Listar_Categorias] 
	-- Add the parameters for the stored procedure here
	@valor varchar(100) = ''

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM categorias WHERE estado=1
	AND (UPPER(TRIM(CAST(codigo_cat AS char))) LIKE '%' + @valor + '%' OR  UPPER(TRIM(descripcion_cat)) LIKE '%' + UPPER(TRIM(@valor)) + '%')
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Listar_Marcas]    Script Date: 18/10/2024 12:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--listar categorias con estado activo

CREATE PROCEDURE [dbo].[SP_Listar_Marcas] 
	-- Add the parameters for the stored procedure here
	@valor varchar(100) = ''

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM marcas WHERE estado=1
	AND (UPPER(TRIM(CAST(codigo_marca AS char))) LIKE '%' + @valor + '%' OR  UPPER(TRIM(descripcion_marca)) LIKE '%' + UPPER(TRIM(@valor)) + '%')
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Listar_Municipios]    Script Date: 18/10/2024 12:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--listar distritos con estado activo

CREATE PROCEDURE [dbo].[SP_Listar_Municipios]
	-- Add the parameters for the stored procedure here
	@valor varchar(100) = ''

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT d.codigo_municipio, d.descripcion_municipio, po.descripcion_provincia, pa.descripcion_pais, po.codigo_provincia
    FROM municipios d 
	INNER JOIN provincias po on d.codigo_provincia = po.codigo_provincia
	INNER JOIN pais pa on po.codigo_pais  = pa.codigo_pais
    WHERE d.estado=1 AND 
	(
	UPPER(TRIM(CAST(d.codigo_municipio AS char))) LIKE '%' + @valor + '%' 
	OR  UPPER(TRIM(po.descripcion_provincia)) LIKE '%' + UPPER(TRIM(@valor)) + '%' 
	OR  UPPER(TRIM(pa.descripcion_pais)) LIKE '%' + UPPER(TRIM(@valor)) + '%'
	
	)
	ORDER BY d.codigo_municipio ASC
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Listar_Paises]    Script Date: 18/10/2024 12:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--listar paises con estado activo

CREATE PROCEDURE [dbo].[SP_Listar_Paises]
	-- Add the parameters for the stored procedure here
	@valor varchar(60) = ''

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM pais WHERE estado=1
	AND (UPPER(TRIM(CAST(codigo_pais AS char))) LIKE '%' + @valor + '%' OR  UPPER(TRIM(descripcion_pais)) LIKE '%' + UPPER(TRIM(@valor)) + '%')
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Listar_Productos]    Script Date: 18/10/2024 12:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--listar productos con estado activo

CREATE PROCEDURE [dbo].[SP_Listar_Productos]
	-- Add the parameters for the stored procedure here
	@valor varchar(100) = ''

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT p.codigo_prod, p.descripcion_prod, m.descripcion_marca, u.descripcion_um, c.descripcion_cat, p.stock_min, p.stock_max, p.codigo_marca, p.codigo_um, p.codigo_cat  
    FROM productos p 
	INNER JOIN marcas m on p.codigo_marca = m.codigo_marca
	INNER JOIN unidades_medida u on p.codigo_um = u.codigo_um
	INNER JOIN categorias c on p.codigo_cat = c.codigo_cat
    WHERE p.estado=1 AND 
	(
	UPPER(TRIM(CAST(p.codigo_prod AS char))) LIKE '%' + @valor + '%' 
	OR  UPPER(TRIM(p.descripcion_prod)) LIKE '%' + UPPER(TRIM(@valor)) + '%' 
	OR  UPPER(TRIM(m.descripcion_marca)) LIKE '%' + UPPER(TRIM(@valor)) + '%'
	OR  UPPER(TRIM(c.descripcion_cat)) LIKE '%' + UPPER(TRIM(@valor)) + '%'
	)
	ORDER BY p.codigo_prod ASC
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Listar_Proveedores]    Script Date: 18/10/2024 12:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--listar proveedores con estado activo

CREATE PROCEDURE [dbo].[SP_Listar_Proveedores]
	-- Add the parameters for the stored procedure here
	@valor varchar(100) = ''

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT a.codigo_proveedor, b.descripcion_tipo_doc_pc, a.numero_doc_proveedor, a.razon_social_proveedor, a.nombres, a.apellidos,
	d.descripcion_ru, a.email_proveedor, a.telefono_proveedor, a.movil_proveedor, a.codigo_sexo, c.descripcion_sexo, a.direccion_proveedor,
	a.codigo_municipio, e.descripcion_municipio, f.descripcion_provincia, a.comentarios, a.codigo_tipo_doc_pc, a.codigo_ru
	FROM proveedores a
	INNER JOIN tipos_doc_prov_cl b on a.codigo_tipo_doc_pc = b.codigo_tipo_doc_pc
	INNER JOIN sexos c on a.codigo_sexo = c.codigo_sexo
	INNER JOIN rubros d on a.codigo_ru = d.codigo_ru
	INNER JOIN municipios e on a.codigo_municipio = e.codigo_municipio
	INNER JOIN provincias f on e.codigo_provincia = f.codigo_provincia
	INNER JOIN pais g on f.codigo_pais = g.codigo_pais
	WHERE a.estado = 1 AND  UPPER(TRIM(CAST(a.codigo_proveedor as char)) +
		  TRIM(b.descripcion_tipo_doc_pc) +
		  TRIM(a.numero_doc_proveedor) +
		  TRIM(a.razon_social_proveedor) +
		  TRIM(a.nombres) +
		  TRIM(a.apellidos) +
		  TRIM(d.descripcion_ru) +
		  TRIM(a.email_proveedor) +
		  TRIM(a.telefono_proveedor) +
		  TRIM(a.movil_proveedor)) LIKE + '%' + UPPER(TRIM(@valor)) + '%'
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Listar_Provincias]    Script Date: 18/10/2024 12:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--listar provincias con estado activo

CREATE PROCEDURE [dbo].[SP_Listar_Provincias]
	-- Add the parameters for the stored procedure here
	@valor varchar(100) = ''

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT po.codigo_provincia, po.descripcion_provincia, pa.descripcion_pais, pa.codigo_pais
    FROM provincias po 
	INNER JOIN pais pa on po.codigo_pais = pa.codigo_pais
    WHERE po.estado=1 AND 
	(
	UPPER(TRIM(CAST(po.codigo_provincia AS char))) LIKE '%' + @valor + '%' 
	OR  UPPER(TRIM(po.descripcion_provincia)) LIKE '%' + UPPER(TRIM(@valor)) + '%' 
	OR  UPPER(TRIM(pa.descripcion_pais)) LIKE '%' + UPPER(TRIM(@valor)) + '%'
	
	)
	ORDER BY po.codigo_provincia ASC
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Listar_Rubros]    Script Date: 18/10/2024 12:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--listar rubros con estado activo

CREATE PROCEDURE [dbo].[SP_Listar_Rubros] 
	-- Add the parameters for the stored procedure here
	@valor varchar(60) = ''

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM rubros WHERE estado=1
	AND (UPPER(TRIM(CAST(codigo_ru AS char))) LIKE '%' + @valor + '%' OR  UPPER(TRIM(descripcion_ru)) LIKE '%' + UPPER(TRIM(@valor)) + '%')
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Listar_UM]    Script Date: 18/10/2024 12:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--listar unidades de medida con estado activo

CREATE PROCEDURE [dbo].[SP_Listar_UM] 
	-- Add the parameters for the stored procedure here
	@valor varchar(100) = ''

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM unidades_medida WHERE estado=1
	AND (UPPER(TRIM(CAST(codigo_um AS char))) LIKE '%' + @valor + '%' OR  UPPER(TRIM(descripcion_um)) LIKE '%' + UPPER(TRIM(@valor)) + '%' OR  UPPER(TRIM(abreviatura_um)) LIKE '%' + UPPER(TRIM(@valor)) + '%')
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Marca_Seleccionar]    Script Date: 18/10/2024 12:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[SP_Marca_Seleccionar]
@valor varchar(100) = ''
as
select codigo_marca, descripcion_marca from marcas
where estado=1 AND (UPPER(TRIM(descripcion_marca)) LIKE '%' + UPPER(TRIM(@valor)) + '%')
GO
/****** Object:  StoredProcedure [dbo].[SP_Paises_Provincias_Distritos]    Script Date: 18/10/2024 12:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--Listar las los distritos, provincias y los paises
CREATE proc [dbo].[SP_Paises_Provincias_Distritos]
@valor varchar(100)
as
select a.descripcion_municipio, b.codigo_provincia, c.descripcion_pais, a.codigo_municipio
from municipios a
inner join provincias b on a.codigo_provincia = b.codigo_provincia
inner join pais c on b.codigo_pais = c.codigo_pais
where a.estado = 1 and
UPPER(TRIM(a.descripcion_municipio) + TRIM(b.descripcion_provincia) + TRIM(c.descripcion_pais)) LIKE '%' + UPPER(TRIM(@valor)) + '%'
GO
/****** Object:  StoredProcedure [dbo].[SP_Paises_Seleccionar]    Script Date: 18/10/2024 12:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--Listar paises para cargar en el mto de paises
create proc [dbo].[SP_Paises_Seleccionar]
as
select codigo_pais, descripcion_pais from pais
where estado=1
GO
/****** Object:  StoredProcedure [dbo].[SP_Provincias_Paises]    Script Date: 18/10/2024 12:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--Listar las provincias y los paises
create proc [dbo].[SP_Provincias_Paises]
@valor varchar(100)
as
select po.descripcion_provincia, pa.descripcion_pais, po.codigo_provincia
from provincias po
inner join pais pa on po.codigo_pais = pa.codigo_pais
where po.estado = 1 and
UPPER(TRIM(po.descripcion_provincia) + TRIM(pa.descripcion_pais)) LIKE '%' + UPPER(TRIM(@valor)) + '%'
GO
/****** Object:  StoredProcedure [dbo].[SP_Registrar_Almacenes]    Script Date: 18/10/2024 12:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Registrar_Almacenes] 
	-- Add the parameters for the stored procedure here
	@opcion int = 0,
	@codigo_alm int = 0,
	@descripcion varchar(50) = ''

AS

    -- Insert statements for procedure here
	IF @opcion = 1 --nuevo registro
	BEGIN
		INSERT INTO almacenes(descripcion_alm, estado)
		VALUES(@descripcion, 1)
	END;
	ELSE --actualizar registro
	BEGIN
		UPDATE almacenes SET descripcion_alm = @descripcion 
		WHERE codigo_alm = @codigo_alm
	END;
GO
/****** Object:  StoredProcedure [dbo].[SP_Registrar_Categorias]    Script Date: 18/10/2024 12:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--resistra/Actualizar una categoria

CREATE PROCEDURE [dbo].[SP_Registrar_Categorias] 
	-- Add the parameters for the stored procedure here
	@opcion int = 0,
	@codigo_cat int = 0,
	@descripcion varchar(50) = ''

AS

    -- Insert statements for procedure here
	IF @opcion = 1 --nuevo registro
	BEGIN
		INSERT INTO categorias(descripcion_cat, estado)
		VALUES(@descripcion, 1)
	END;
	ELSE --actualizar registro
	BEGIN
		UPDATE categorias SET descripcion_cat = @descripcion 
		WHERE codigo_cat = @codigo_cat
	END;
GO
/****** Object:  StoredProcedure [dbo].[SP_Registrar_Marcas]    Script Date: 18/10/2024 12:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--resistra/Actualizar una categoria

CREATE PROCEDURE [dbo].[SP_Registrar_Marcas] 
	-- Add the parameters for the stored procedure here
	@opcion int = 0,
	@codigo_marca int = 0,
	@descripcion varchar(50) = ''

AS

    -- Insert statements for procedure here
	IF @opcion = 1 --nuevo registro
	BEGIN
		INSERT INTO marcas(descripcion_marca, estado)
		VALUES(@descripcion, 1)
	END;
	ELSE --actualizar registro
	BEGIN
		UPDATE marcas SET descripcion_marca = @descripcion 
		WHERE codigo_marca = @codigo_marca
	END;
GO
/****** Object:  StoredProcedure [dbo].[SP_Registrar_Municipio]    Script Date: 18/10/2024 12:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--resistra/Actualizar un distrito

CREATE PROCEDURE [dbo].[SP_Registrar_Municipio]
	-- Add the parameters for the stored procedure here
	@opcion int = 0,
	@codigo_municipio int = 0,
	@descripcion varchar(50) = '',
	@codigo_provincia int = 0

AS

    -- Insert statements for procedure here
	IF @opcion = 1 --nuevo registro
	BEGIN
		INSERT INTO municipios(descripcion_municipio, codigo_provincia, estado)
		VALUES(@descripcion, @codigo_provincia, 1)
	END;
	ELSE --actualizar registro
	BEGIN
		UPDATE municipios SET descripcion_municipio = @descripcion, codigo_provincia = @codigo_provincia 
		WHERE codigo_municipio = @codigo_municipio
	END;
GO
/****** Object:  StoredProcedure [dbo].[SP_Registrar_Pais]    Script Date: 18/10/2024 12:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--resistra/Actualizar un pais

CREATE PROCEDURE [dbo].[SP_Registrar_Pais]
	-- Add the parameters for the stored procedure here
	@opcion int = 0,
	@codigo_pais int = 0,
	@descripcion varchar(50) = ''

AS

    -- Insert statements for procedure here
	IF @opcion = 1 --nuevo registro
	BEGIN
		INSERT INTO pais(descripcion_pais, estado)
		VALUES(@descripcion, 1)
	END;
	ELSE --actualizar registro
	BEGIN
		UPDATE pais SET descripcion_pais = @descripcion 
		WHERE codigo_pais = @codigo_pais
	END;
GO
/****** Object:  StoredProcedure [dbo].[SP_Registrar_Producto]    Script Date: 18/10/2024 12:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_Registrar_Producto] 
	-- Add the parameters for the stored procedure here
	@opcion int = 0,
	@codigo_producto int = 0,
	@descripcion_producto varchar(100) = '',
	@codigo_marca int = 0,
	@codigo_um int = 0,
	@codigo_cat int = 0,
	@stock_min decimal(18,2),
	@stock_max decimal(18,2)
AS
declare @xCodigo int = 0
declare @fFecha as datetime
set @fFecha = CONVERT(datetime, GETDATE())
    -- Insert statements for procedure here
	IF @opcion = 1 --nuevo registro
	BEGIN
		INSERT INTO productos(descripcion_prod, codigo_marca, codigo_um, codigo_cat, stock_min, stock_max, fecha_creacion, fecha_modificacion, estado)
		VALUES(@descripcion_producto, @codigo_marca, @codigo_um, @codigo_cat, @stock_min, @stock_max, @fFecha, @fFecha,  1)
	
	SET @xCodigo = @@IDENTITY -- obtiene el codigo_producto generado

	INSERT INTO stockproductos(codigo_prod, codigo_alm, stock_actual, precio_compra_unitario) 
	SELECT @xCodigo, codigo_alm, 0.00, 0.00 FROM almacenes

	END;
	ELSE IF @opcion = 2 --actualizar registro
	BEGIN
		UPDATE productos SET 
		descripcion_prod = @descripcion_producto,
		codigo_marca = @codigo_marca,
		codigo_um = @codigo_um,
		codigo_cat = @codigo_um,
		stock_min = @stock_min,
		stock_max = @stock_max,
		fecha_modificacion = @fFecha
		WHERE codigo_prod = @codigo_producto

	INSERT INTO stockproductos(codigo_prod, codigo_alm, stock_actual, precio_compra_unitario) 
	SELECT @codigo_producto, codigo_alm, 0.00, 0.00 FROM almacenes 
	WHERE codigo_alm not in (SELECT codigo_alm FROM stockproductos WHERE codigo_prod = @codigo_producto)

	END;
GO
/****** Object:  StoredProcedure [dbo].[SP_Registrar_Proveedor]    Script Date: 18/10/2024 12:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_Registrar_Proveedor]
	-- Add the parameters for the stored procedure here
	@opcion int = 0,
	@codigo_proveedor int = 0,
	@codido_tipo_doc_pc int = 0,
	@numero_doc_proveedor varchar(50) = '',
	@razon_social varchar(150) = '',
	@nombres varchar(100) = '',
	@apellidos varchar(100) = '',
	@codigo_sexo int = 0,
	@codigo_ru int = 0,
	@email_proveedor varchar(150) = '',
	@telefono_proveedor varchar(20) = '',
	@movil_proveedor varchar(20) = '',
	@direccion text = '',
	@codigo_municipio int = 0,
	@comentarios text = ''
AS
declare @xCodigo int = 0
declare @fFecha as datetime
set @fFecha = CONVERT(datetime, GETDATE())

    -- Insert statements for procedure here
	IF @opcion = 1 --nuevo registro
	BEGIN
		INSERT INTO proveedores(codigo_tipo_doc_pc, numero_doc_proveedor, razon_social_proveedor, nombres, apellidos, codigo_sexo, codigo_ru, 
		email_proveedor, telefono_proveedor, movil_proveedor, direccion_proveedor, codigo_municipio, comentarios, fecha_proveedor, 
		fecha_modificacion, estado)
		VALUES(@codido_tipo_doc_pc, @numero_doc_proveedor, @razon_social, @nombres, @apellidos, @codigo_sexo, @codigo_ru, @email_proveedor,
		@telefono_proveedor, @movil_proveedor, @direccion, @codigo_municipio, @comentarios, @fFecha, @fFecha, 1)
	END;
	ELSE --actualizar registro
	BEGIN
		UPDATE proveedores SET codigo_tipo_doc_pc = @codido_tipo_doc_pc, numero_doc_proveedor = @numero_doc_proveedor, razon_social_proveedor = @razon_social,
		nombres = @nombres, apellidos = @apellidos, codigo_sexo = @codigo_sexo, codigo_ru = @codigo_ru, 
		email_proveedor = @email_proveedor, telefono_proveedor = @telefono_proveedor, movil_proveedor = @movil_proveedor,
		direccion_proveedor = @direccion, codigo_municipio = @codigo_municipio, comentarios = @comentarios, fecha_modificacion = @fFecha
		WHERE codigo_proveedor = @codigo_proveedor
	END;
GO
/****** Object:  StoredProcedure [dbo].[SP_Registrar_Provincia]    Script Date: 18/10/2024 12:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--resistra/Actualizar una provincia

CREATE PROCEDURE [dbo].[SP_Registrar_Provincia]
	-- Add the parameters for the stored procedure here
	@opcion int = 0,
	@codigo_provincia int = 0,
	@descripcion varchar(50) = '',
	@codigo_pais int = 0

AS

    -- Insert statements for procedure here
	IF @opcion = 1 --nuevo registro
	BEGIN
		INSERT INTO provincias(descripcion_provincia, codigo_pais, estado)
		VALUES(@descripcion, @codigo_pais, 1)
	END;
	ELSE --actualizar registro
	BEGIN
		UPDATE provincias SET descripcion_provincia = @descripcion, codigo_pais = @codigo_pais 
		WHERE codigo_provincia = @codigo_provincia
	END;
GO
/****** Object:  StoredProcedure [dbo].[SP_Registrar_Rubros]    Script Date: 18/10/2024 12:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--resistra/Actualizar un rubro

CREATE PROCEDURE [dbo].[SP_Registrar_Rubros]
	-- Add the parameters for the stored procedure here
	@opcion int = 0,
	@codigo_ru int = 0,
	@descripcion varchar(50) = ''

AS

    -- Insert statements for procedure here
	IF @opcion = 1 --nuevo registro
	BEGIN
		INSERT INTO rubros(descripcion_ru, estado)
		VALUES(@descripcion, 1)
	END;
	ELSE --actualizar registro
	BEGIN
		UPDATE rubros SET descripcion_ru = @descripcion 
		WHERE codigo_ru = @codigo_ru
	END;
GO
/****** Object:  StoredProcedure [dbo].[SP_Registrar_UM]    Script Date: 18/10/2024 12:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--resistra/Actualizar una unidades de medida

CREATE PROCEDURE [dbo].[SP_Registrar_UM]
	-- Add the parameters for the stored procedure here
	@opcion int = 0,
	@codigo_um int = 0,
	@abreviatura_um varchar(3) = '',
	@descripcion varchar(50) = ''

AS

    -- Insert statements for procedure here
	IF @opcion = 1 --nuevo registro
	BEGIN
		INSERT INTO unidades_medida(abreviatura_um, descripcion_um, estado)
		VALUES( @abreviatura_um, @descripcion, 1)
	END;
	ELSE --actualizar registro
	BEGIN
		UPDATE unidades_medida SET abreviatura_um = @abreviatura_um, descripcion_um = @descripcion 
		WHERE codigo_um = @codigo_um
	END;
GO
/****** Object:  StoredProcedure [dbo].[SP_UM_Seleccionar]    Script Date: 18/10/2024 12:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[SP_UM_Seleccionar]
@valor varchar(100) = ''
as
select codigo_um, descripcion_um from unidades_medida
where estado=1 AND (UPPER(TRIM(descripcion_um)) LIKE '%' + UPPER(TRIM(@valor)) + '%')
GO
/****** Object:  StoredProcedure [dbo].[SP_Ver_Stock_Productos_Almacenes]    Script Date: 18/10/2024 12:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--Procedimiento almacenado para ver el stock de productos por almacenes
CREATE PROCEDURE [dbo].[SP_Ver_Stock_Productos_Almacenes]
@codigo_producto int = 0
AS
SELECT a.descripcion_alm, s.stock_actual, s.precio_compra_unitario
from stockproductos s 
INNER JOIN almacenes a on s.codigo_alm=a.codigo_alm
where s.codigo_prod = @codigo_producto
order by a.codigo_alm
GO
USE [master]
GO
ALTER DATABASE [db_minimarketIntec] SET  READ_WRITE 
GO
