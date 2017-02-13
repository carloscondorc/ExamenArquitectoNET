use master
go

create database BancoDB
GO

USE BancoDB
GO

CREATE TABLE Banco
(
Banco_ID 			int identity(1,1) not null,
Banco_Nombre 		varchar(50) not null,
Banco_Direccion 	varchar(100) not null,
Banco_FechaRegistro datetime not null
CONSTRAINT pk_Banco_id PRIMARY KEY (Banco_ID asc)
)

GO

CREATE TABLE Sucursal
(
Sucursal_ID 		    int identity(1,1) not null,
Banco_ID 			    int not null,
Sucursal_Nombre 		varchar(50),
Sucursal_Direccion 	    varchar(100) not null,
Sucursal_FechaRegistro  datetime not null
CONSTRAINT [Sucursal_pk_] PRIMARY KEY (Sucursal_ID)
CONSTRAINT [Sucursal_Banco_fk] FOREIGN KEY (Banco_ID) REFERENCES Banco(Banco_ID)
);
GO

CREATE TABLE Moneda
(
Moneda_ID 			int identity(1,1) not null,
Moneda_Nombre 		varchar(50) not null,
Moneda_Abreviatura  varchar(5) not null
CONSTRAINT Moneda_pk PRIMARY KEY (Moneda_ID)
);
GO

CREATE TABLE EstadoOrden
(
EstadoOrden_ID 		int identity(1,1) not null,
EstadoOrden_Nombre  varchar(20) not null
CONSTRAINT EstadoOrden_pk PRIMARY KEY (EstadoOrden_ID)
);
GO

CREATE TABLE OrdenPago
(
OrdenPago_ID 			int not null identity(1,1),
Sucursal_ID 			int not null,
Moneda_ID 				int not null,
EstadoOrden_ID 			int not null,
OrdenPago_Monto 		decimal not null,
OrdenPago_FechaPago 	datetime not null,
CONSTRAINT OrdenPago_pk PRIMARY KEY (OrdenPago_ID),
CONSTRAINT OrdenPago_Sucursal_fk FOREIGN KEY (Sucursal_ID) REFERENCES Sucursal(Sucursal_ID),
CONSTRAINT OrdenPago_Moneda_fk FOREIGN KEY (Moneda_ID) REFERENCES Moneda(Moneda_ID),
CONSTRAINT OrdenPago_Estado_fk FOREIGN KEY (EstadoOrden_ID) REFERENCES EstadoOrden(EstadoOrden_ID)
);
GO

INSERT INTO Banco(Banco_Nombre, Banco_Direccion,Banco_FechaRegistro)
values
('BCP','Av. Huaylays 320 Chorrillos',getdate()),
('BBVA','Av. Panama 763 San Isidro',getdate()),
('INTERBANK','Jr. Canal y Moreira 896 Jesus Maria',getdate()),
('BANCO DE LA NACION','Av. Canda 720 La Victoria',getdate())

GO

insert into Sucursal(Banco_ID,Sucursal_Nombre,Sucursal_Direccion,Sucursal_FechaRegistro)
values (1,'BCP Sede San Isidro','Av. Javier Prado 896',getdate()),
       (1,'BCP Sede Pueblo Libre','Jr. Sucre 916',getdate()),
       (2,'BBVA Sede Lima','Jr. Carabaya 568',getdate()),
	   (2,'BBVA Sede Chosica','Jr. Jose Olaya 1568',getdate()),
       (3,'INTERBANK Sede Miraflores','Av. Larco 653',getdate()),
	   (3,'BANCO DE LA NACION Sede Jesus Maria','Av. Salaverry  352',getdate())
GO

Insert into Moneda(Moneda_Nombre,Moneda_Abreviatura)
values ('Soles','PEN'),('Dolares','USD')
GO

Insert into EstadoOrden(EstadoOrden_Nombre)
values ('Pagada'),
       ('Declinada'),
       ('Fallida'),
       ('Anulada')
GO

Insert into OrdenPago
(Sucursal_ID,
 Moneda_ID,
 EstadoOrden_ID,
 OrdenPago_Monto,
 OrdenPago_FechaPago)
values (1,1,1,1000,getdate()),
       (2,1,1,2000,getdate()),
	   (2,1,1,3000,getdate()),
	   (3,2,2,4500,getdate()),
	   (4,2,3,5000,getdate()),
	   (4,2,2,7500,getdate())

GO


CREATE PROCEDURE USP_ConsultarBanco
(
@pi_Banco_ID int,
@pi_Banco_Nombre varchar(50)
)
as
begin

select Banco_ID,Banco_Nombre,Banco_Direccion,Banco_FechaRegistro
from Banco
where Banco_ID= isnull(@pi_Banco_ID,Banco_ID) and
                 Banco_Nombre like '%'+isnull(@pi_Banco_Nombre,'')+'%';

end
GO

CREATE PROCEDURE USP_ConsultarSucursal
(
@pi_Sucursal_ID int,
@pi_Banco_ID int,
@pi_Sucursal_Nombre varchar(50)
)
as
begin

select a.Sucursal_ID, a.Banco_ID, b.Banco_Nombre,
	   a.Sucursal_Nombre,a.Sucursal_Direccion, a.Sucursal_FechaRegistro
from Sucursal a  inner join Banco b
                     on a.Banco_ID=b.Banco_ID
where a.Sucursal_ID= isnull(@pi_Sucursal_ID,a.Sucursal_ID) and
      a.Banco_ID= isnull(@pi_Banco_ID,a.Banco_ID)  and
      a.Sucursal_Nombre like '%'+isnull(@pi_Sucursal_Nombre,'')+'%';

end
GO

CREATE PROCEDURE USP_ConsultarMoneda
(
@pi_Moneda_ID int,
@pi_Moneda_Nombre varchar(50)
)
as
begin

select Moneda_ID,Moneda_Nombre,Moneda_Abreviatura
from Moneda
where Moneda_ID= isnull(@pi_Moneda_ID,Moneda_ID) and
       Moneda_Nombre like '%'+isnull(@pi_Moneda_Nombre,'')+'%';

end
GO

CREATE PROCEDURE USP_ConsultarEstadoOrden
(
@pi_EstadoOrden_ID int,
@pi_EstadoOrden_nombre varchar(20)
)
as
begin

select EstadoOrden_ID,EstadoOrden_Nombre
from EstadoOrden
where EstadoOrden_ID= isnull(@pi_EstadoOrden_ID,EstadoOrden_ID) and
      EstadoOrden_Nombre like '%'+isnull(@pi_EstadoOrden_nombre,'')+'%';

end
GO

CREATE PROCEDURE USP_ConsultarOrdenPago
(
@pi_OrdenPago_ID   int,
@pi_Sucursal_ID   int,
@pi_Moneda_ID      int,
@pi_EstadoOrden_ID int
)
as
begin

select a.OrdenPago_ID,a.Sucursal_ID ,b.Sucursal_Nombre,a.Moneda_ID,d.Moneda_Nombre,d.Moneda_Abreviatura,
       a.EstadoOrden_ID,e.EstadoOrden_Nombre, a.OrdenPago_Monto,a.OrdenPago_FechaPago
  from  [dbo].[OrdenPago] a inner join Sucursal b
                                  on a.Sucursal_ID=b.Sucursal_ID
						    inner join  Banco c
							      on b.Banco_ID=c.Banco_ID
							inner join  Moneda d
							      on a.Moneda_ID=d.Moneda_ID
							inner join  EstadoOrden e
      							  on a.EstadoOrden_ID=e.EstadoOrden_ID
 where  a.OrdenPago_ID = isnull(@pi_OrdenPago_ID,a.OrdenPago_ID) and
		a.Sucursal_ID= isnull(@pi_Sucursal_ID,a.Sucursal_ID) and
        a.Moneda_ID= isnull(@pi_Moneda_ID,a.Moneda_ID) and
        a.EstadoOrden_ID= isnull(@pi_EstadoOrden_ID,a.EstadoOrden_ID);

end
GO

CREATE PROCEDURE USP_InsertarBanco
(@pi_Banco_Nombre varchar(50),
@pi_Banco_Direccion varchar(100))
as
begin
     insert into Banco(Banco_Nombre,Banco_Direccion,Banco_FechaRegistro)
     values(@pi_Banco_Nombre,@pi_Banco_Direccion,getdate())
end
GO

CREATE PROCEDURE USP_ActualizarBanco
(
@pi_Banco_ID int,
@pi_Banco_Nombre varchar(50),
@pi_Banco_Direccion varchar(100)
)
as
begin
   update Banco
   set Banco_Nombre =@pi_Banco_Nombre,
       Banco_Direccion= @pi_Banco_Direccion
    where Banco_ID=@pi_Banco_ID;
 end
GO

CREATE PROCEDURE USP_EliminarBanco(@pi_Banco_ID int)
as
begin
  delete from Banco where Banco_ID=@pi_Banco_ID;
end
GO


CREATE PROCEDURE USP_InsertarSucursal
(@pi_Banco_ID 			int,
 @pi_Sucursal_Nombre    varchar(50),
 @pi_Sucursal_Direccion varchar(100)
 )
as
begin

	  insert into Sucursal(Banco_ID,Sucursal_Nombre, Sucursal_Direccion, Sucursal_FechaRegistro)
       values(@pi_Banco_ID,@pi_Sucursal_Nombre,	@pi_Sucursal_Direccion,	getdate());

end
go

CREATE PROCEDURE USP_ActualizarSucursal
(@pi_Sucursal_ID int,
 @pi_Banco_ID int,
 @pi_Sucursal_Nombre varchar(50),
 @pi_Sucursal_Direccion varchar(100))
as
begin

   update Sucursal
   set Banco_ID=@pi_Banco_ID
      ,Sucursal_Nombre = @pi_Sucursal_Nombre
      ,Sucursal_Direccion = @pi_Sucursal_Direccion
    where Sucursal_ID=@pi_Sucursal_ID;

end
GO

CREATE PROCEDURE usp_EliminarSucursal(@pi_Sucursal_ID int)
as
begin

   delete from Sucursal  where Sucursal_ID=@pi_Sucursal_ID;

end
GO

CREATE PROCEDURE USP_InsertarOrdenPago
(
@pi_Sucursal_ID int,
@pi_Moneda_ID int,
@pi_EstadoOrden_ID int,
@pi_OrdenPago_Monto decimal(18,2),
@pi_Ordenpago_FechaPago datetime
)
as
begin

   insert into OrdenPago(Sucursal_ID,Moneda_ID,EstadoOrden_ID,OrdenPago_Monto,OrdenPago_FechaPago)
     values (@pi_Sucursal_ID,@pi_Moneda_ID,@pi_EstadoOrden_ID,@pi_OrdenPago_Monto,@pi_Ordenpago_FechaPago);
end
GO

CREATE PROCEDURE USP_ActualizarOrdenPago
(@pi_OrdenPago_ID int,
 @pi_Sucursal_ID   int,
 @pi_Moneda_ID     int,
 @pi_EstadoOrden_ID   int,
 @pi_OrdenPago_Monto decimal(18,2),
 @pi_OrdenPago_FechaPago datetime)
as
begin

update OrdenPago
   set  Sucursal_ID = @pi_OrdenPago_ID,
        Moneda_ID = @pi_Moneda_ID,
        EstadoOrden_ID = @pi_EstadoOrden_ID,
	    OrdenPago_Monto = @pi_OrdenPago_Monto,
        OrdenPago_FechaPago = @pi_OrdenPago_FechaPago
 where OrdenPago_ID=@pi_OrdenPago_ID;
end
GO

CREATE PROCEDURE USP_EliminarOrdenPago
(@pi_OrdenPago_ID int
)
as
begin
   delete from OrdenPago
    where  OrdenPago_ID=@pi_OrdenPago_ID
end
GO

CREATE PROCEDURE USP_InsertarEstadoOrden
(@pi_EstadoOrden varchar(20))

as
begin
		insert into Estado(Nombre)
        values (@pi_EstadoOrden)
end
GO

CREATE PROCEDURE USP_ActualizarEstadoOrden
(@pi_EstadoOrden_ID int,
@pi_EstadoOrden_Nombre varchar(20))
 as
 begin

     update  EstadoOrden
      set EsatdoOrden_Nombre = @pi_EstadoOrden_Nombre
     where EstadoOrden_ID=@pi_EstadoOrden_ID;
 end
GO

CREATE PROCEDURE USP_EliminarEstadoOrden(@pi_EstadoOrden_ID int)
as
begin
    delete from EstadoOrden where EstadoOrden_ID=@pi_EstadoOrden_ID;
end
GO

CREATE PROCEDURE USP_InsertarMoneda
(@pi_Moneda_Nombre varchar(50),
 @pi_Moneda_Abreviatura varchar(5))
as
begin
  insert into Moneda(Moneda_Nombre,Moneda_Abreviatura)
     values   (@pi_Moneda_Nombre,
           @pi_Moneda_Abreviatura)
end
GO

CREATE PROCEDURE USP_ActualizarMoneda
(@pi_Moneda_ID int,
 @pi_Moneda_Nombre varchar(50),
 @pi_Moneda_Abreviatura varchar(5))
 as
 begin
    update Moneda
     set Moneda_Nombre= @pi_Moneda_Nombre
      ,Moneda_Abreviatura = @pi_Moneda_Abreviatura
    where Moneda_ID=@pi_Moneda_ID;
 end
GO

CREATE PROCEDURE USP_EliminarMoneda (@pi_Moneda_ID int)
as
begin
delete from Moneda where Moneda_ID=@pi_Moneda_ID;
end
GO




