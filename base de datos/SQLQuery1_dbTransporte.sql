
CREATE DATABASE ControlVehiculos_dbVisual

USE ControlVehiculos_dbVisual

CREATE TABLE Usuarios (

Nivel              varchar (15)   NOT NULL,
Nombre             varchar (30)   NOT NULL,
Apellidos          varchar (30)   NOT NULL,
Cedula             varchar (10)   NOT NULL,
NombreUsuario      varchar (10)   NOT NULL,
ClaveUsuario       varchar (10)   NOT NULL,

Primary key(Cedula)
)


CREATE TABLE GestionDeVehiculos (

NumeroIngreso      varchar (15)     NOT NULL,
Placa              varchar (30)     NOT NULL,
Marca              varchar (30)     NOT NULL,
Modelo             varchar (10)     NOT NULL,
Motor              varchar (10)     NOT NULL,
Chasis             varchar (15)     NOT NULL,
NumeroPasajeros    varchar (30)     NOT NULL,
Soat               varchar (30)     NOT NULL,
RevAmbiental       varchar (10)     NOT NULL,
TarjetaOperacion   varchar (10)     NOT NULL,
Propietario        varchar (15)     NOT NULL,
Cedula             varchar (30)     NOT NULL,
Direccion          varchar (30)     NOT NULL,
TelefonoFijo       varchar (10)     NOT NULL,
TelefonoMovil      varchar (10)     NOT NULL,

Primary key(Placa)
)
INSERT INTO GestionDeVehiculos (NumeroIngreso,Placa,Marca,Modelo,Motor,Chasis,NumeroPasajeros,Soat,RevAmbiental,TarjetaOperacion,Propietario,Cedula,Direccion,TelefonoFijo,TelefonoMovil)
values (11,'741AQQ','Toyota','A3020','AZ92','Si','6 PASAJEROS','La Positiva','Si','Si','Juan Perez',95874523,'Lima',9875324,412578)
select * from GestionDeVehiculos