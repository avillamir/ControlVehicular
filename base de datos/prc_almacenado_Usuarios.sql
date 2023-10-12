

use  ControlVehiculos_dbVisual

/*USUARIOS*/

create proc sp_ListaUsuario
as
select*from Usuarios

exec sp_ListaUsuario

/*ingresar una nuevo NIVEL a la base de datos*/

create procedure sp_InsertaUsuario

@Nivel varchar(15),
@Nombre varchar(15),
@Apellidos varchar (30),
@Cedula varchar (10),
@NombreUsuario varchar (10),
@ClaveUsuario varchar (10)
as
insert into Usuarios(Nivel,Nombre,Apellidos,Cedula,NombreUsuario,ClaveUsuario)
values (@Nivel,@Nombre,@Apellidos,@Cedula,@NombreUsuario,@ClaveUsuario)

exec sp_InsertaUsuario 20,'Ramon','Perez',741258,'rppr',9654


/*actualizar un USUARIO a la base de datos*/

create procedure sp_EditaUsuario

@Nivel varchar(15),
@Nombre varchar(15),
@Apellidos varchar (30),
@Cedula varchar (10),
@NombreUsuario varchar (10),
@ClaveUsuario varchar (10)
as

update Usuarios set  Nivel=@Nivel,
                     Nombre=@Nombre,
					 Apellidos=@Apellidos,
					 NombreUsuario=@NombreUsuario,
					 ClaveUsuario=@ClaveUsuario
            where Cedula=@Cedula

exec sp_EditaUsuario 20,'Ramon','Perez Perez',741258,'RRppr',9654


/*Elimina un USUARIO a la base de datos*/

create proc sp_EliminaUsuario

@Cedula varchar (10)
as
delete from Usuarios where Cedula=@Cedula

exec sp_EliminaUsuario 741258

/*SProcedure*/
exec sp_ListaUsuario
exec sp_InsertaUsuario 20,'Ramon','Perez',741258,'rppr',9654
exec sp_EditaUsuario 20,'Ramon','Perez Perez',741258,'RRppr',9654
create proc sp_EliminaUsuario 741258
