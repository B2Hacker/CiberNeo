USE [master]
GO
/****** Object:  Database [Inventario]    Script Date: 12/8/2019 5:54:16 PM ******/
CREATE DATABASE [Inventario]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Database1', FILENAME = N'D:\Program Files (x86)\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Inventario.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Database1_log', FILENAME = N'D:\Program Files (x86)\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Inventario_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Inventario] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Inventario].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Inventario] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Inventario] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Inventario] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Inventario] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Inventario] SET ARITHABORT OFF 
GO
ALTER DATABASE [Inventario] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Inventario] SET AUTO_SHRINK ON 
GO
ALTER DATABASE [Inventario] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Inventario] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Inventario] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Inventario] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Inventario] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Inventario] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Inventario] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Inventario] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Inventario] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Inventario] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Inventario] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Inventario] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Inventario] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Inventario] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Inventario] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Inventario] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Inventario] SET  MULTI_USER 
GO
ALTER DATABASE [Inventario] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Inventario] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Inventario] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Inventario] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Inventario] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Inventario', N'ON'
GO
ALTER DATABASE [Inventario] SET QUERY_STORE = OFF
GO
USE [Inventario]
GO
/****** Object:  Table [dbo].[Categorias]    Script Date: 12/8/2019 5:54:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorias](
	[IdCategoria] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 12/8/2019 5:54:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[IdCliente] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Correo] [nvarchar](40) NOT NULL,
	[Username] [nvarchar](40) NOT NULL,
	[Password] [nvarchar](20) NOT NULL,
	[Telefono] [nvarchar](20) NOT NULL,
	[Direccion] [nvarchar](100) NOT NULL,
	[Ciudad] [nvarchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cotizaciones]    Script Date: 12/8/2019 5:54:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cotizaciones](
	[IdCotizacion] [int] IDENTITY(1,1) NOT NULL,
	[IdCliente] [int] NULL,
	[NumeroCotizacion] [int] NOT NULL,
	[FechaRegistro] [datetime] NOT NULL,
	[IdProducto] [int] NULL,
	[Cantidad] [int] NOT NULL,
	[Precio] [int] NOT NULL,
	[Subtotal] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCotizacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inventarios]    Script Date: 12/8/2019 5:54:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventarios](
	[IdInventario] [int] IDENTITY(1,1) NOT NULL,
	[IdProducto] [int] NULL,
	[IdProveedor] [int] NULL,
	[Precio] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[FechaRegistro] [datetime] NOT NULL,
	[IdUsuario] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdInventario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Perfiles]    Script Date: 12/8/2019 5:54:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Perfiles](
	[IdPerfil] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Descripcion] [nvarchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdPerfil] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 12/8/2019 5:54:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[IdProducto] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NULL,
	[Precio] [int] NULL,
	[IdCategoria] [int] NULL,
	[Marca] [nvarchar](50) NULL,
	[Cantidad] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proveedores]    Script Date: 12/8/2019 5:54:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proveedores](
	[IdProveedor] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Direccion] [nvarchar](100) NOT NULL,
	[CorreoElectronico] [nvarchar](50) NOT NULL,
	[Telefono] [nvarchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdProveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 12/8/2019 5:54:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Paterno] [nvarchar](50) NOT NULL,
	[Materno] [nvarchar](50) NOT NULL,
	[CorreoElectronico] [nvarchar](50) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[IdPerfil] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categorias] ON 

INSERT [dbo].[Categorias] ([IdCategoria], [Nombre]) VALUES (1, N'Papas Fritas')
INSERT [dbo].[Categorias] ([IdCategoria], [Nombre]) VALUES (2, N'Refrescos')
INSERT [dbo].[Categorias] ([IdCategoria], [Nombre]) VALUES (3, N'Pan')
INSERT [dbo].[Categorias] ([IdCategoria], [Nombre]) VALUES (4, N'Frutas')
INSERT [dbo].[Categorias] ([IdCategoria], [Nombre]) VALUES (5, N'Verduras')
INSERT [dbo].[Categorias] ([IdCategoria], [Nombre]) VALUES (6, N'Lacteos')
INSERT [dbo].[Categorias] ([IdCategoria], [Nombre]) VALUES (7, N'Productos de Oficina')
INSERT [dbo].[Categorias] ([IdCategoria], [Nombre]) VALUES (8, N'Electronicos')
SET IDENTITY_INSERT [dbo].[Categorias] OFF
SET IDENTITY_INSERT [dbo].[Clientes] ON 

INSERT [dbo].[Clientes] ([IdCliente], [Nombre], [Correo], [Username], [Password], [Telefono], [Direccion], [Ciudad]) VALUES (1, N'Gilberto Sanchez', N'Gil@live.com', N'Gil', N'1', N'8991093210', N'Enrique Segoviano', N'Reynosa')
SET IDENTITY_INSERT [dbo].[Clientes] OFF
SET IDENTITY_INSERT [dbo].[Perfiles] ON 

INSERT [dbo].[Perfiles] ([IdPerfil], [Nombre], [Descripcion]) VALUES (1, N'Administrador', N'Acceso general
')
INSERT [dbo].[Perfiles] ([IdPerfil], [Nombre], [Descripcion]) VALUES (5, N'Cliente', N'Sin acceso a la base de datos')
SET IDENTITY_INSERT [dbo].[Perfiles] OFF
SET IDENTITY_INSERT [dbo].[Productos] ON 

INSERT [dbo].[Productos] ([IdProducto], [Nombre], [Precio], [IdCategoria], [Marca], [Cantidad]) VALUES (4, N'AGUA PURIFICADA', 8, 1, N'AWA', 3)
INSERT [dbo].[Productos] ([IdProducto], [Nombre], [Precio], [IdCategoria], [Marca], [Cantidad]) VALUES (7, N'Airpods', 1000, 1, N'Pirata', 2)
INSERT [dbo].[Productos] ([IdProducto], [Nombre], [Precio], [IdCategoria], [Marca], [Cantidad]) VALUES (9, N'David Alejandro', 100000000, 1, N'GUAPO', 3)
INSERT [dbo].[Productos] ([IdProducto], [Nombre], [Precio], [IdCategoria], [Marca], [Cantidad]) VALUES (10, N'COCA', 120, 1, N'AWA', 2)
SET IDENTITY_INSERT [dbo].[Productos] OFF
SET IDENTITY_INSERT [dbo].[Proveedores] ON 

INSERT [dbo].[Proveedores] ([IdProveedor], [Nombre], [Direccion], [CorreoElectronico], [Telefono]) VALUES (1, N'Coca Cola', N'Mexico DF', N'CocaCola@Company.mx', N'800 1234 123')
SET IDENTITY_INSERT [dbo].[Proveedores] OFF
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([IdUsuario], [Nombre], [Paterno], [Materno], [CorreoElectronico], [Username], [Password], [IdPerfil]) VALUES (2, N'David Alejandro', N'Morales', N'Sosa', N'davidsosa00@live.com', N'thedarkzoza', N'1234', 1)
INSERT [dbo].[Usuarios] ([IdUsuario], [Nombre], [Paterno], [Materno], [CorreoElectronico], [Username], [Password], [IdPerfil]) VALUES (4, N'Brandon Eduardo', N'Cortes', N'Correa', N'B2ORIGINAL@Hotmail.com', N'B2', N'b2', 5)
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
ALTER TABLE [dbo].[Cotizaciones]  WITH CHECK ADD FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Clientes] ([IdCliente])
GO
ALTER TABLE [dbo].[Cotizaciones]  WITH CHECK ADD FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Productos] ([IdProducto])
GO
ALTER TABLE [dbo].[Inventarios]  WITH CHECK ADD FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Productos] ([IdProducto])
GO
ALTER TABLE [dbo].[Inventarios]  WITH CHECK ADD FOREIGN KEY([IdProveedor])
REFERENCES [dbo].[Proveedores] ([IdProveedor])
GO
ALTER TABLE [dbo].[Inventarios]  WITH CHECK ADD FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [dbo].[Productos]  WITH CHECK ADD FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Categorias] ([IdCategoria])
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD FOREIGN KEY([IdPerfil])
REFERENCES [dbo].[Perfiles] ([IdPerfil])
GO
/****** Object:  StoredProcedure [dbo].[GetCategorias]    Script Date: 12/8/2019 5:54:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[GetCategorias]
AS
Begin
	SELECT * FROM Categorias
End
GO
/****** Object:  StoredProcedure [dbo].[GetClientes]    Script Date: 12/8/2019 5:54:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[GetClientes]
AS
Begin
	SELECT * FROM Clientes
End
GO
/****** Object:  StoredProcedure [dbo].[GetPerfiles]    Script Date: 12/8/2019 5:54:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetPerfiles]
AS
Begin
	SELECT * FROM Perfiles 
End
GO
/****** Object:  StoredProcedure [dbo].[GetProductos]    Script Date: 12/8/2019 5:54:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[GetProductos]
AS
Begin
	SELECT * FROM Productos
End
GO
/****** Object:  StoredProcedure [dbo].[GetProveedores]    Script Date: 12/8/2019 5:54:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[GetProveedores]
AS
Begin
	SELECT * FROM Proveedores
End
GO
/****** Object:  StoredProcedure [dbo].[GetUsuarios]    Script Date: 12/8/2019 5:54:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUsuarios]
AS
Begin
	SELECT * FROM Usuarios ORDER BY Nombre, Paterno, Materno
End
GO
/****** Object:  StoredProcedure [dbo].[SetCategoria]    Script Date: 12/8/2019 5:54:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SetCategoria]
	@idc int,
	@nom nvarchar(MAX) = '',
	@op int
AS
begin
IF @op = 1
		INSERT INTO Categorias Values (@nom)
	ELSE IF @op = 2
		UPDATE Categorias SET Nombre=@nom 
		WHERE (IdCategoria=@idc)
	ELSE IF @op=3
		DELETE FROM Categorias WHERE (IdCategoria=@idc)
end
GO
/****** Object:  StoredProcedure [dbo].[SetCliente]    Script Date: 12/8/2019 5:54:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SetCliente]
	@idcl int, 
	@nom nvarchar(50) = '', 
	@cor nvarchar(40) = '',
	@user nvarchar(40) = '', 
	@pass nvarchar = '', 
	@tel nvarchar(20) = '',
	@dir nvarchar(50) = '', 
	@cd nvarchar(50) = '', 
	@op int 
AS
begin
IF @op = 1
		INSERT INTO Clientes Values (@nom, @cor, @user,
		@pass, @tel, @dir, @cd)
	ELSE IF @op = 2
		UPDATE Clientes SET Nombre=@nom, Correo=@cor, 
		Username=@user, Password=@pass, Telefono=@tel, Direccion=@dir,
		Ciudad=@cd WHERE (IdCliente = @idcl)
	ELSE IF @op=3
		DELETE FROM Clientes WHERE (IdCliente=@idcl)
end
GO
/****** Object:  StoredProcedure [dbo].[SetPerfil]    Script Date: 12/8/2019 5:54:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[SetPerfil]
	@idper int,
	@nom nvarchar(50) = '',
	@des nvarchar(100) = '',
	@op int = 0
AS
Begin
	IF @op = 1
		INSERT INTO Perfiles Values (@nom, @des)
	ELSE IF @op = 2
		UPDATE Perfiles SET Nombre=@nom, Descripcion=@des
		WHERE (IdPerfil=@idper)
	ELSE IF @op=3
		DELETE FROM Perfiles WHERE (IdPerfil=@idper)
End
GO
/****** Object:  StoredProcedure [dbo].[SetProductos]    Script Date: 12/8/2019 5:54:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SetProductos]
	@idpro int, 
	@nom nvarchar(50) = '', 
	@pre int = 0,
	@idc int = 0,
	@mar nvarchar(50) = '', 
	@can int = 0,
	@op int 
AS
begin
IF @op = 1
		INSERT INTO  Productos VALUES (@nom, @pre, @idc, @mar, @can)
	ELSE IF @op = 2
		UPDATE Productos SET Nombre=@nom,Precio=@pre, 
		IdCategoria=@idc, Marca=@mar, Cantidad=@can WHERE (IdProducto=@idpro)
	ELSE IF @op=3
		DELETE FROM Productos WHERE (IdProducto = @idpro)
end
GO
/****** Object:  StoredProcedure [dbo].[SetProveedores]    Script Date: 12/8/2019 5:54:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SetProveedores]
	@idprov int, 
	@nom nvarchar(50) = '', 
	@dir nvarchar(100) = '',
	@cor nvarchar(50) = '' ,
	@tel nvarchar(20) = '', 
	@op int 
AS
begin
IF @op = 1
		INSERT INTO  Proveedores VALUES (@nom, @dir, @cor, @tel)
	ELSE IF @op = 2
		UPDATE Proveedores SET Nombre=@nom,Direccion=@dir, 
		CorreoElectronico=@cor, Telefono=@tel WHERE (IdProveedor=@idprov)
	ELSE IF @op=3
		DELETE FROM Proveedores WHERE (IdProveedor=@idprov)
end
GO
/****** Object:  StoredProcedure [dbo].[SetUsuario]    Script Date: 12/8/2019 5:54:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[SetUsuario]
	@idu int,
	@nom nvarchar(50) = '',
	@pat nvarchar(50) = '',
	@mat nvarchar(50) = '',
	@cor nvarchar(50) = '',
	@user nvarchar(50) = '',
	@pass nvarchar(50) = '',
	@idp int = 0,
	@op int = 0
AS
Begin
	IF @op = 1
		INSERT INTO Usuarios Values (@nom, @pat, @mat, @cor, @user, @pass, @idp)
	ELSE IF @op = 2
		UPDATE Usuarios SET Nombre=@nom, Paterno=@pat, Materno=@mat, CorreoElectronico=@cor, 
			Username=@user, Password=@pass, IdPerfil=@idp
		WHERE (IdUsuario=@idu)
	ELSE IF @op=3
		DELETE FROM Usuarios WHERE (IdUsuario=@idu)
End
GO
USE [master]
GO
ALTER DATABASE [Inventario] SET  READ_WRITE 
GO
