Create database SistemaViajes
go

use SistemaViajes
go

create table Usuario
(
id_area varchar(5),
id_empleado varchar(5),
nombre varchar(50),
usuario varchar(10),
contraseña varchar(10)
);

insert into Usuario values('A0001','E0001','Recepcionista','Rec','Rec');
insert into  Usuario values('A0002','E0002','Recepcionista','BrayanM','BrayanM');



create proc sp_logueo_ez
@usuario varchar(10),
@clave varchar(10)
as
select id_area,nombre,usuario,contraseña from Usuario 
where usuario=@usuario and contraseña=@clave
go








create table DestinoTuristico
(
codigo varchar(5),
origen varchar(100),
destino varchar(100),
precio decimal(10,2)
);
go

-----
create proc sp_ingreso_destino_turistico
@codigo varchar(5),
@origen varchar(100),
@destino varchar(100),
@precio decimal(10,2),
@accion varchar(50)output
as
if (@accion='1')
begin
	declare @codnuevo varchar(5), @codmax varchar(5)
	set @codmax = (select max(codigo) from destinoturistico)
	set @codmax = isnull(@codmax,'A0000')
	set @codnuevo = 'A'+RIGHT(RIGHT(@codmax,4)+10001,4)
	insert into destinoturistico(codigo,origen,destino,precio)
	values(@codnuevo,@origen,@destino,@precio)
	set @accion='Se generó el código: ' +@codnuevo
end
else if (@accion='2')
begin
	update destinoturistico set origen=@origen, destino=@destino, precio=@precio where codigo=@codigo
	set @accion='Se modificó el código: ' +@codigo
end
else if (@accion='3')
begin
	delete from destinoturistico where codigo=@codigo
	set @accion='Se borró el código: ' +@codigo
end


create proc sp_listar_destino_turistico
as 
select * from DestinoTuristico order by codigo
go

---------

alter proc sp_buscar_DestinoTuristico
@destino varchar(50),
@origen varchar (50),
@tipoBusqueda VARCHAR(50)
as
(select codigo,origen,destino,precio from DestinoTuristico where( @tipoBusqueda = 'Destino' AND destino  like @destino  + '%')
																	OR (@tipoBusqueda = 'Origen' AND origen  like @origen  + '%'))
go





drop table Aerolineas;
create table Aerolineas
(
codigo varchar(5),
nombre varchar(50),
siglas varchar(10),
capacidad INt
);
go
------
alter proc sp_ingreso_Aerolineas
@codigo varchar(5),
@nombre varchar(50),
@siglas varchar(10),
@capacidad int,
@accion varchar(50)output
as
if (@accion='1')
begin
	declare @codnuevo varchar(5), @codmax varchar(5)
	set @codmax = (select max(codigo) from Aerolineas)
	set @codmax = isnull(@codmax,'A0000')
	set @codnuevo = 'A'+RIGHT(RIGHT(@codmax,4)+10001,4)
	insert into Aerolineas(codigo,nombre,siglas,capacidad)
	values(@codnuevo,@nombre,@siglas,@capacidad)
	set @accion='Se generó el código: ' +@codnuevo
end
else if (@accion='2')
begin
	update Aerolineas set nombre=@nombre, siglas=@siglas, capacidad=@capacidad where codigo=@codigo
	set @accion='Se modificó el código: ' +@codigo
end
else if (@accion='3')
begin
	delete from Aerolineas where codigo=@codigo
	set @accion='Se borró el código: ' +@codigo
end
---------
create proc sp_listar_Aerolineas
as
select * from Aerolineas order by codigo
go

--------
alter proc sp_buscar_Aerolineas
@nombre varchar(50),
@siglas varchar(50),
@tipoBusqueda VARCHAR(50)
as
(select codigo,nombre,siglas,capacidad from Aerolineas where( @tipoBusqueda = 'Nombre'  AND  nombre like @nombre  + '%')
														OR( @tipoBusqueda = 'Siglas'  AND  siglas like @siglas  + '%'))
go


create table Cliente
(
codigo int,
apellido varchar(50),
nombre varchar(50),
cedula varchar(10),
numero_telefono int,
correo_electronico varchar(50),
direccion varchar(150)
);


alter proc sp_buscar_cliente_
@apellido varchar(50),
@nombre varchar (50),
@tipoBusqueda VARCHAR(50)
as
(select codigo,apellido,nombre,cedula, numero_telefono, correo_electronico, direccion from Cliente where( @tipoBusqueda = 'apellido' AND apellido  like @apellido  + '%')
																	OR (@tipoBusqueda = 'nombre' AND nombre  like @nombre  + '%'))
go



create table Reservas
(
Nombre varchar (50),
Apellido varchar (50),
Cedula varchar (10),
Celular varchar (10),
Numeropasajeros int,
Fechaviaje varchar (50),
Tipopago varchar(50),
Destino varchar(100),
);



