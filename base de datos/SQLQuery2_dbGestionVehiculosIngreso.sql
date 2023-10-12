
create database ControlVehiculos_GestionDeVehiculos
use ControlVehiculos_GestionDeVehiculos


CREATE TABLE GestionDeVehiculosIngreso (

NumeroIngreso      varchar (15)     NOT NULL,
Placa              varchar (30)     NOT NULL,
Marca              varchar (30)     NOT NULL,
Modelo             varchar (10)     NOT NULL,
Motor              varchar (10)     NOT NULL,
Chasis             varchar (15)     NOT NULL,
NumeroPasajeros    varchar (30)     NOT NULL,
Soat               varchar (30)     NOT NULL,
Fecha1             datetime NOT NULL,
RevAmbiental       varchar (10)     NOT NULL,
Fecha2             datetime NOT NULL,
TarjetaOperacion   varchar (10)     NOT NULL,
Fecha3             datetime NOT NULL,
Propietario        varchar (15)     NOT NULL,
Cedula             varchar (30)     NOT NULL,
Direccion          varchar (30)     NOT NULL,
TelefonoFijo       varchar (10)     NOT NULL,
TelefonoMovil      varchar (10)     NOT NULL,

Primary key(Placa)
)

INSERT INTO GestionDeVehiculosIngreso (NumeroIngreso,Placa,Marca,Modelo,Motor,Chasis,NumeroPasajeros,
Soat,Fecha1,RevAmbiental,Fecha2,TarjetaOperacion,Fecha3,Propietario,Cedula,Direccion,TelefonoFijo,TelefonoMovil)
values (11,'741AQQ','Toyota','A3020','AZ92','Si','6 PASAJEROS','La Positiva',
'10-01-2020','Si','11-01-2020','Si','12-01-2020','Juan Perez',95874523,'Lima',9875324,412578)

select * from GestionDeVehiculosIngreso