USE [master]


CREATE DATABASE [BD7]
GO

USE [BD7]
GO


/*
IDENTITY: es como un contador, se asegura de q cada vez q se cree algo le sume uno al anterio, ej: cuando creo un cliente 
no hace falta cargar el id, porq lo genera solo sumandole 1 al ultimo creado
no puede haber 2 IDENTITY en una misma tabla.

*/
CREATE TABLE [dbo].[Clientes](
	[idCliente] [int] IDENTITY(1,1) NOT NULL,
	[apellido] [varchar](100) NULL,
	[nombre] [varchar](100) NOT NULL,
	[telefono] [int] NULL,
	[telefonoEmerg] [int] NOT NULL,
	[puntos] [int] NULL,
	[peso] [int] NULL,
	[altura] [int] NULL,
	[borrado] [bit] default 0
	primary key (idCliente))
	

CREATE TABLE [dbo].[Perfiles](
	[idPerfil] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[borrado] [bit] default 0
	primary key (idPerfil))


CREATE TABLE [dbo].[Articulos](
	[idArticulo] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NULL,
	[idMarca] [int] not null,
	[descripcion] [varchar](250) NULL,
	[stock] [int] NOT NULL,
	[precio] [int] NOT NULL,
	[puntaje] [int] not NULL,
	[fechaAlta] [date] NULL,
	fechaHasta [date],
	[borrado] [bit] default 0
	primary key (idArticulo))



CREATE TABLE [dbo].[Facturas](
	[numero] [int] IDENTITY(1,1) NOT NULL,
	[tipo] [varchar](50) NOT NULL,
	[idCliente] [int] NOT NULL,
	[fecha] [date] NOT NULL,
	[subTotal] [int] ,
	descuento [varchar] (20),
	[borrado] [bit] default 0
	primary key (numero,tipo))


CREATE TABLE [dbo].[DetalleF](
	[idDetalle] [int] IDENTITY(1,1) NOT NULL,
	[numeroFactura] [int] NOT NULL,
	[idArticulo] [int]  NOT NULL,
	[precioUnitario][decimal](18,2)NOT NULL,
	[cantidad] [int] NOT NULL,
	[borrado] [bit] default 0
	primary key (idDetalle))



CREATE TABLE [dbo].[Promociones](
	[porcentaje] [int] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[borrado] [bit] default 0
	primary key (nombre, porcentaje))



CREATE TABLE [dbo].[Ejercicios](
	[idEjercicio] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[descripcion] [varchar] (100),
	[musculoAfectado] [varchar](100),
	[dificultad] [int] not null,
	[borrado] [bit] default 0
	primary key (idEjercicio))




CREATE TABLE [dbo].[FormaPago](
	[forma] [varchar] (20) not null,
	[descripcion] [varchar](50) NOT NULL,
	[borrado] [bit] default 0
	primary key (forma))	
	


CREATE TABLE [dbo].[Rutina](
	[objetivo] [varchar](50) NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
	[cantDias] [int] NOT NULL,
	[borrado] [bit] default 0
	primary key (objetivo))



CREATE TABLE [dbo].[Planes](
	[idPlan] [int] IDENTITY(1,1) NOT NULL,
	[objetivo] [varchar](50) NOT NULL,
	[idCliente] [int]  NOT NULL,
	[fechaDesde] [date] NOT NULL,
	[fechaHasta] [date] NOT NULL,
	[borrado] [bit] default 0
	primary key (idPlan, idCliente))


	
CREATE TABLE [dbo].[EjercicioXDia](
	[idEjercicio] [int] IDENTITY(1,1) NOT NULL,
	[series] [int] not null,
	[repeticiones] [int] not null,
	[borrado] [bit] default 0
	primary key (idEjercicio, series, repeticiones))



CREATE TABLE [dbo].[PlanDia](
	[nroDia] [int] IDENTITY(1,1) NOT NULL,
	[fechaDesde] [date] not null,
	[musculos] [varchar](50) NOT NULL,
	[borrado] [bit] default 0
	primary key (nroDia, fechaDesde))
	






CREATE TABLE [dbo].[Enfermedades](
	[nombre] [varchar] (50) not null,
	[descripcion] [varchar](250) NOT NULL,
	[borrado] [bit] default 0
	primary key (nombre))	



CREATE TABLE [dbo].[Asociacion](
	[idCliente] [int] IDENTITY(1,1) NOT NULL,
	[fechaDesde] [date] NOT NULL,
	[fechaHasta] [date] NOT NULL,
	[puntaje] [int],
	[borrado] [bit] default 0
	primary key (fechaDesde, fechaHasta, idCliente))



CREATE TABLE [dbo].[Usuarios](
	[idUsuario] [int] IDENTITY(1,1) NOT NULL,
	[idPerfil] [int] NOT NULL,
	[usuario] [varchar](50) NOT NULL,
	[contraseña] [varchar](10) NOT NULL,
	[borrado] [bit] default 0
	primary key (idUsuario))



CREATE TABLE [dbo].[Marcas](
	[idMarca] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) not NULL,
	[borrado] [bit] default 0
	primary key (idMarca))



CREATE TABLE [dbo].[Profesores](
	[idProfe] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) not NULL,
	[apellido] [varchar](250) NOT NULL,
	[telefono] [int] NULL,
	[fechaIngreso][date] NOT NULL,
	[fechaFin][date] NULL,
	[borrado] [bit] default 0
	primary key (idProfe))



CREATE TABLE [dbo].[TipoFactura](
	[id_tipoFactura] [int] IDENTITY(1,1),
	descripcion [varchar](5) NOT NULL,
	[borrado] [bit] default 0
	primary key (id_tipoFactura))


--ESTA PARTE ESTA COMENTADA PORQ LO QUE HACE ES AGREGAR LA CLAVES FORANEAS, LA PROFE DIJO Q SE LA AGREGUEMOS AL FINAL PARA NO HACERNOS LIO



/*    
ALTER TABLE Clientes
ADD FOREIGN KEY (enfermedades) REFERENCES Enfermedades(nombre);

ALTER TABLE Facturas
ADD FOREIGN KEY (forma) REFERENCES FormaPago(forma);

ALTER TABLE Planes
ADD FOREIGN KEY (idCliente) REFERENCES Clientes(idCliente);

ALTER TABLE Planes
ADD FOREIGN KEY (objetivo) REFERENCES Rutina(objetivo);

ALTER TABLE EjercicioXDia
ADD FOREIGN KEY (idEjercicio) REFERENCES Ejercicios(idEjercicio);

ALTER TABLE DetalleF
ADD FOREIGN KEY (idArticulo) REFERENCES Articulos(idArticulo);

--ALTER TABLE DetalleF
--ADD FOREIGN KEY (porcentaje) REFERENCES Promociones(porcentaje);

ALTER TABLE Asociacion
ADD FOREIGN KEY (idCliente) REFERENCES Clientes(idCliente);

*/




-- ACA LO Q SE HACE ES CREAR UN PAR DE USUARIOS Y ALGUNOS CLIENTES

INSERT [dbo].[TipoFactura] ( descripcion) VALUES ('A');
INSERT [dbo].[TipoFactura] ( descripcion) VALUES ('B');
INSERT [dbo].[TipoFactura] ( descripcion) VALUES ('C');

INSERT [dbo].[Usuarios] ( [usuario], [contraseña], [idPerfil]) VALUES ('admin', '123', 1);

INSERT [dbo].[Usuarios] ( [usuario], [contraseña], [idPerfil]) VALUES ('juanma', '123456', 2);

INSERT [dbo].[Usuarios] ( [usuario], [contraseña], [idPerfil]) VALUES ('elKevi', 'hesoyam', 2);

INSERT [dbo].[Usuarios] ( [usuario], [contraseña], [idPerfil]) VALUES ('tuGaBienpio', 'hesoyam', 3);

INSERT [dbo].[Usuarios] ( [usuario], [contraseña], [idPerfil]) VALUES ('elMatuh', 'hesoyam', 3);



INSERT [dbo].[Clientes] ([nombre], [apellido], [telefono], [telefonoEmerg], [peso] ) VALUES ('Alonso', 'Javier', 103,1855,75);

INSERT [dbo].[Clientes] ([nombre], [apellido], [telefono], [telefonoEmerg]) VALUES ('Ramirez', 'Oscar', 123,123555)


insert [dbo].[Marcas] (nombre) values ('marca1')

insert [dbo].[Marcas] (nombre) values ('marca2')

insert [dbo].[Marcas] (nombre) values ('marca3')

insert [dbo].[Marcas] (nombre) values ('marca4')


insert [dbo].[Perfiles] (nombre) values ('Administrador')
insert [dbo].[Perfiles] (nombre) values ('Cliente')
insert [dbo].[Perfiles] (nombre) values ('Profesor')
insert [dbo].[Perfiles] (nombre) values ('Ayudante')


insert [dbo].[Articulos] ([nombre],[idMarca],[descripcion],[stock],[precio],[puntaje]) values ( 'Atr1', 1,  'Frasco de 1 kg suplemento proteico...',5,1500,10000)

insert [dbo].[Articulos] ([nombre],[idMarca],[descripcion],[stock],[precio],[puntaje]) values ( 'Atr2', 2,  'Frasco de 1 kg suplemento proteico...',5,150,1000)

insert [dbo].[Articulos] ([nombre],[idMarca],[descripcion],[stock],[precio],[puntaje]) values ( 'Atr3', 3,  'Frasco de 1 kg suplemento proteico...',5,100,2000)

insert [dbo].[Articulos] ([nombre],[idMarca],[descripcion],[stock],[precio],[puntaje]) values ( 'Atr4', 4,  'Frasco de 1 kg suplemento proteico...',5,1200,9995)

insert [dbo].[Articulos] ([nombre],[idMarca],[descripcion],[stock],[precio],[puntaje]) values ( 'Atr5', 1,  'Frasco de 1 kg suplemento proteico...',5,500,3333)

insert [dbo].[Articulos] ([nombre],[idMarca],[descripcion],[stock],[precio],[puntaje]) values ( 'Atr6', 2,  'Frasco de 1 kg suplemento proteico...',5,1500,10000)

insert [dbo].[Articulos] ([nombre],[idMarca],[descripcion],[stock],[precio],[puntaje]) values ( 'Atr7', 3,  'Frasco de 1 kg suplemento proteico...',5,1500,10000)

insert [dbo].[Articulos] ([nombre],[idMarca],[descripcion],[stock],[precio],[puntaje]) values ( 'Atr8', 4,  'Frasco de 1 kg suplemento proteico...',5,1500,10000)

insert [dbo].[Articulos] ([nombre],[idMarca],[descripcion],[stock],[precio],[puntaje]) values ( 'Atr9', 4,  'Frasco de 1 kg suplemento proteico...',5,1500,10000)

insert [dbo].[Articulos] ([nombre],[idMarca],[descripcion],[stock],[precio],[puntaje]) values ( 'Atr10', 2,  'Frasco de 1 kg suplemento proteico...',5,1500,10000)



