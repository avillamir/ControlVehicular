
create table GestionDeConductores (

Nombre                       varchar (15)     NOT NULL,
ApellidoPaterno              varchar (30)     NOT NULL,
ApellidoMaterno              varchar (30)     NOT NULL,
TelefonoFijo                 varchar (10)     NOT NULL,
TelefonoMovil                varchar (10)     NOT NULL,
CedulaConductor              varchar (15)     NOT NULL,
NumeroLicencia               varchar (30)     NOT NULL,
CategoriaLicencia            varchar (30)     NOT NULL,
PlacaVehiculo                varchar (30)     NOT NULL,
NumeroIngreso                varchar (10)     NOT NULL,
FechaVencimiento                         datetime NOT NULL,

Primary key(NumeroLicencia)
)

insert into GestionDeConductores(Nombre,ApellidoPaterno,ApellidoMaterno,TelefonoFijo,TelefonoMovil,CedulaConductor,
NumeroLicencia,CategoriaLicencia,PlacaVehiculo,NumeroIngreso,FechaVencimiento)
values ('Armando','Paredes','Loza',9874563210,7859641,95123,'985AQDF','AIII','ADC985',15,'2020-01-12')

select * from GestionDeConductores

