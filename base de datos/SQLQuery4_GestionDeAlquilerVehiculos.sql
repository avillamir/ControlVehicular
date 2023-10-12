

create table GestionDeAlquilerVehiculos (

NumeroAlquiler          varchar (30)     NOT NULL,
FechaInicio             datetime         NOT NULL,
FechaFin                datetime         NOT NULL,
NombreCliente           varchar (30)     NOT NULL,
CedulA                  varchar (30)     NOT NULL,
Telefono                varchar (30)     NOT NULL,
Valor                   varchar (30)     NOT NULL,
Pago                    varchar (30)     NOT NULL,
HoraSalida              varchar (30)     NOT NULL,
HoraLlegada             varchar (30)     NOT NULL,
PlacaVehiculo           varchar (30)     NOT NULL,
Origen                  varchar (30)     NOT NULL,
Destino                 varchar (30)     NOT NULL,
Codigo                  varchar (30)     NOT NULL,
 PRIMARY KEY (NumeroAlquiler)
)

insert into
GestionDeAlquilerVehiculos (NumeroAlquiler,FechaInicio,FechaFin,NombreCliente,CedulA,Telefono,Valor,Pago,HoraSalida,HoraLlegada,
PlacaVehiculo,Origen,Destino,Codigo)
values (1,'2023-10-05','2023-10-06','Juan Perez','A9587F',987456321,2,40,'18:00','15:00','ABC896','Lima','Barranca',1358)

select * from GestionDeAlquilerVehiculos
