USE [RouteADM]
GO

/****** Object:  Trigger [tgRouteU_ClienteSucursal]    Script Date: 05/31/2011 17:03:43 ******/
IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[tgRouteU_ClienteSucursal]'))
DROP TRIGGER [dbo].[tgRouteU_ClienteSucursal]
GO

USE [RouteADM]
GO

/****** Object:  Trigger [dbo].[tgRouteU_ClienteSucursal]    Script Date: 05/31/2011 17:03:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO






CREATE TRIGGER [dbo].[tgRouteU_ClienteSucursal] ON [dbo].[ClienteSucursal] 
FOR INSERT, UPDATE
AS
declare @Route as int, @IdCedis as bigint
set @IdCedis = 0

set @Route = isnull( ( select Route from Configuracion where IdCedis in ( select IdCedis from Inserted ) ), 0 )
set @IdCedis = ( select IdCedis from Configuracion )

if @Route = 1
begin

-- inserta cliente
	insert into ROUTE.dbo.Cliente ( ClienteClave, CNPId, Clave, IdElectronico, IdFiscal, RazonSocial, TipoFiscal, TipoImpuesto, NombreContacto, TelefonoContacto, FechaRegistroSistema, FechaNacimiento, LimiteCreditoDinero, NombreCorto, TipoEstado, LimiteDescuento, SaldoEfectivo, Prestamo, Exclusividad, VigExclusividad, ActualizaSaldoCheque, VencimientoVenta, DiasVencimiento, FechaFactura, DesgloseImpuesto, CorreoElectronico, MFechaHora, MUsuarioID ) 
		select cast (case IdCedis when 1 then 'A' 
			when 2 then 'B' 
			when 3 then 'C' 
			when 4 then 'D' 
			when 5 then 'E'
			when 6 then 'F'
			when 7 then 'G'
			when 8 then 'H'
			when 9 then 'I'
			when 10 then 'J'
			else '' end as varchar(5))+IdSucursal, null, cast (case IdCedis when 1 then 'A' 
			when 2 then 'B' 
			when 3 then 'C' 
			when 4 then 'D' 
			when 5 then 'E'
			when 6 then 'F'
			when 7 then 'G'
			when 8 then 'H'
			when 9 then 'I'
			when 10 then 'J'
			else '' end as varchar(5))+IdSucursal, left(CodigoBarras, 64), left( RFC, 64), left( RazonSocial, 128), 1, 1, left(Contacto, 64), left( Telefonos, 64), getdate(), '20000101', 0, left( NombreSucursal, 32), 1, 0, 0, 0, 0, '20991231', 1, 0, 0, '20991231', 0, '', getdate(), 'Interfaz' 
	from Inserted where cast(cast (case IdCedis when 1 then 'A' 
			when 2 then 'B' 
			when 3 then 'C' 
			when 4 then 'D' 
			when 5 then 'E'
			when 6 then 'F'
			when 7 then 'G'
			when 8 then 'H'
			when 9 then 'I'
			when 10 then 'J'
			else '' end as varchar(5))+IdSucursal as varchar(16))  not in ( select ClienteClave from ROUTE.dbo.Cliente where  ClienteClave = cast(cast (case IdCedis when 1 then 'A' 
			when 2 then 'B' 
			when 3 then 'C' 
			when 4 then 'D' 
			when 5 then 'E'
			when 6 then 'F'
			when 7 then 'G'
			when 8 then 'H'
			when 9 then 'I'
			when 10 then 'J'
			else '' end as varchar(5))+IdSucursal as varchar(16)) )
	
	update ROUTE.dbo.Cliente 
		set IdElectronico = left(CodigoBarras, 64), IdFiscal = left( Inserted.RFC, 64), RazonSocial = left( Inserted.RazonSocial, 128), 
		NombreContacto = left(Contacto, 64), 
		TelefonoContacto = left( Telefonos, 64), NombreCorto = left( NombreSucursal, 32)
	from ROUTE.dbo.Cliente, Inserted
	where ClienteClave = cast (case IdCedis when 1 then 'A' 
			when 2 then 'B' 
			when 3 then 'C' 
			when 4 then 'D' 
			when 5 then 'E'
			when 6 then 'F'
			when 7 then 'G'
			when 8 then 'H'
			when 9 then 'I'
			when 10 then 'J'
			else '' end as varchar(5))+IdSucursal 

-- inserta domicilio de entrega
	insert into ROUTE.dbo.ClienteDomicilio ( ClienteClave, ClienteDomicilioID, Tipo, Calle, Numero, NumInt, CodigoPostal, ReferenciaDom, Colonia, Localidad, Poblacion, Entidad, Pais, GLN, MFechaHora, MUsuarioID )
		select cast (case IdCedis when 1 then 'A' 
			when 2 then 'B' 
			when 3 then 'C' 
			when 4 then 'D' 
			when 5 then 'E'
			when 6 then 'F'
			when 7 then 'G'
			when 8 then 'H'
			when 9 then 'I'
			when 10 then 'J'
			else '' end as varchar(5))+IdSucursal, 'D-02', 2, left( Calle, 64), left(NumExterior, 16), left( NumInterior, 16), left( CP, 16), '', left(Colonia, 64), left(Localidad, 40), left( Poblacion, 64), left(Entidad, 32), left(Pais, 32), left(TDA_GLN,13), getdate(), 'Interfaz' from Inserted where cast(cast (case IdCedis when 1 then 'A' 
			when 2 then 'B' 
			when 3 then 'C' 
			when 4 then 'D' 
			when 5 then 'E'
			when 6 then 'F'
			when 7 then 'G'
			when 8 then 'H'
			when 9 then 'I'
			when 10 then 'J'
			else '' end as varchar(5))+IdSucursal as varchar(16))  not in ( select ClienteClave 
	from ROUTE.dbo.ClienteDomicilio where  ClienteClave = cast(cast (case IdCedis when 1 then 'A' 
			when 2 then 'B' 
			when 3 then 'C' 
			when 4 then 'D' 
			when 5 then 'E'
			when 6 then 'F'
			when 7 then 'G'
			when 8 then 'H'
			when 9 then 'I'
			when 10 then 'J'
			else '' end as varchar(5))+IdSucursal as varchar(16)) and ClienteDomicilioId = 'D-02' )
	update ROUTE.dbo.ClienteDomicilio 
		set Calle = left(I.Calle,64), Numero = I.NumExterior, NumInt = I.NumInterior, CodigoPostal = I.CP, 
		Colonia = I.Colonia, Localidad = I.Localidad, Poblacion = I.Poblacion, Entidad = I.Entidad, Pais = I.Pais, GLN = left(I.TDA_GLN,13)
	from ROUTE.dbo.ClienteDomicilio as CD, Inserted as I
	where ClienteClave = cast (case IdCedis when 1 then 'A' 
			when 2 then 'B' 
			when 3 then 'C' 
			when 4 then 'D' 
			when 5 then 'E'
			when 6 then 'F'
			when 7 then 'G'
			when 8 then 'H'
			when 9 then 'I'
			when 10 then 'J'
			else '' end as varchar(5))+IdSucursal and Tipo = 2

-- inserta domicilio fiscal
	insert into ROUTE.dbo.ClienteDomicilio ( ClienteClave, ClienteDomicilioID, Tipo, Calle, Numero, NumInt, CodigoPostal, ReferenciaDom, Colonia, Localidad, Poblacion, Entidad, Pais, GLN, MFechaHora, MUsuarioID )
		select cast (case IdCedis when 1 then 'A' 
			when 2 then 'B' 
			when 3 then 'C' 
			when 4 then 'D' 
			when 5 then 'E'
			when 6 then 'F'
			when 7 then 'G'
			when 8 then 'H'
			when 9 then 'I'
			when 10 then 'J'
			else '' end as varchar(5))+IdSucursal, 'D-01', 1, left( CalleF, 64), left(NumExteriorF, 16), left( NumInteriorF, 16), left( CPF, 16), '', left(ColoniaF, 64), left(LocalidadF, 40), left( PoblacionF, 64), left(EntidadF, 32), left(PaisF, 32), left(TDA_GLN,13), getdate(), 'Interfaz' from Inserted where cast(cast (case IdCedis when 1 then 'A' 
			when 2 then 'B' 
			when 3 then 'C' 
			when 4 then 'D' 
			when 5 then 'E'
			when 6 then 'F'
			when 7 then 'G'
			when 8 then 'H'
			when 9 then 'I'
			when 10 then 'J'
			else '' end as varchar(5))+IdSucursal as varchar(16))  not in ( select ClienteClave from ROUTE.dbo.ClienteDomicilio where  ClienteClave = cast(cast (case IdCedis when 1 then 'A' 
			when 2 then 'B' 
			when 3 then 'C' 
			when 4 then 'D' 
			when 5 then 'E'
			when 6 then 'F'
			when 7 then 'G'
			when 8 then 'H'
			when 9 then 'I'
			when 10 then 'J'
			else '' end as varchar(5))+IdSucursal as varchar(16)) and ClienteDomicilioId = 'D-01' )
	update ROUTE.dbo.ClienteDomicilio 
		set Calle = left(I.CalleF,64), Numero = I.NumExteriorF, NumInt = I.NumInteriorF, CodigoPostal = I.CPF, 
		Colonia = I.ColoniaF, Localidad = I.LocalidadF, Poblacion = I.PoblacionF, Entidad = I.EntidadF, Pais = I.PaisF, GLN = left(I.TDA_GLN,13)
	from ROUTE.dbo.ClienteDomicilio as CD, Inserted as I
	where ClienteClave = cast (case IdCedis when 1 then 'A' 
			when 2 then 'B' 
			when 3 then 'C' 
			when 4 then 'D' 
			when 5 then 'E'
			when 6 then 'F'
			when 7 then 'G'
			when 8 then 'H'
			when 9 then 'I'
			when 10 then 'J'
			else '' end as varchar(5))+IdSucursal  and Tipo = 1

-- inserta forma de venta
	insert into ROUTE.dbo.CliFormaVenta ( ClienteClave, CFVTipo, LimiteCredito, DiasCredito,Inicial, CapturaDias, ValidaLimite, ValidaPago, Estado, MFechaHora, MUsuarioID )
		select cast (case IdCedis when 1 then 'A' 
			when 2 then 'B' 
			when 3 then 'C' 
			when 4 then 'D' 
			when 5 then 'E'
			when 6 then 'F'
			when 7 then 'G'
			when 8 then 'H'
			when 9 then 'I'
			when 10 then 'J'
			else '' end as varchar(5))+IdSucursal, '1', 0, 0, 0, 0, 0, 0, 1, getdate(), 'Interfaz' from Inserted where cast(cast (case IdCedis when 1 then 'A' 
			when 2 then 'B' 
			when 3 then 'C' 
			when 4 then 'D' 
			when 5 then 'E'
			when 6 then 'F'
			when 7 then 'G'
			when 8 then 'H'
			when 9 then 'I'
			when 10 then 'J'
			else '' end as varchar(5))+IdSucursal as varchar(16))  not in ( select ClienteClave from ROUTE.dbo.CliFormaVenta where ClienteClave = cast(cast (case IdCedis when 1 then 'A' 
			when 2 then 'B' 
			when 3 then 'C' 
			when 4 then 'D' 
			when 5 then 'E'
			when 6 then 'F'
			when 7 then 'G'
			when 8 then 'H'
			when 9 then 'I'
			when 10 then 'J'
			else '' end as varchar(5))+IdSucursal as varchar(16)) and CFVTipo = '1' )
	insert into ROUTE.dbo.CliFormaVenta ( ClienteClave, CFVTipo, LimiteCredito, DiasCredito,Inicial, CapturaDias, ValidaLimite, ValidaPago, Estado, MFechaHora, MUsuarioID )
		select cast (case IdCedis when 1 then 'A' 
			when 2 then 'B' 
			when 3 then 'C' 
			when 4 then 'D' 
			when 5 then 'E'
			when 6 then 'F'
			when 7 then 'G'
			when 8 then 'H'
			when 9 then 'I'
			when 10 then 'J'
			else '' end as varchar(5))+IdSucursal, '2', 99999, 30, 1, 0, 0, 0, 1, getdate(), 'Interfaz' from Inserted where FormaVenta in (2) and cast(cast (case IdCedis when 1 then 'A' 
			when 2 then 'B' 
			when 3 then 'C' 
			when 4 then 'D' 
			when 5 then 'E'
			when 6 then 'F'
			when 7 then 'G'
			when 8 then 'H'
			when 9 then 'I'
			when 10 then 'J'
			else '' end as varchar(5))+IdSucursal as varchar(16))  not in ( select ClienteClave from ROUTE.dbo.CliFormaVenta where  ClienteClave = cast(cast (case IdCedis when 1 then 'A' 
			when 2 then 'B' 
			when 3 then 'C' 
			when 4 then 'D' 
			when 5 then 'E'
			when 6 then 'F'
			when 7 then 'G'
			when 8 then 'H'
			when 9 then 'I'
			when 10 then 'J'
			else '' end as varchar(5))+IdSucursal as varchar(16)) and CFVTipo = '2' )
	
	update ROUTE.dbo.CliFormaVenta set Estado = 1, Inicial = 0 where CFVTipo = '1' and ClienteClave in ( select cast (case IdCedis when 1 then 'A' 
			when 2 then 'B' 
			when 3 then 'C' 
			when 4 then 'D' 
			when 5 then 'E'
			when 6 then 'F'
			when 7 then 'G'
			when 8 then 'H'
			when 9 then 'I'
			when 10 then 'J'
			else '' end as varchar(5))+IdSucursal from Inserted )
	update ROUTE.dbo.CliFormaVenta set Inicial = 1 where CFVTipo = '1' and ClienteClave in ( select cast (case IdCedis when 1 then 'A' 
			when 2 then 'B' 
			when 3 then 'C' 
			when 4 then 'D' 
			when 5 then 'E'
			when 6 then 'F'
			when 7 then 'G'
			when 8 then 'H'
			when 9 then 'I'
			when 10 then 'J'
			else '' end as varchar(5))+IdSucursal from Inserted where FormaVenta = 1 )
	update ROUTE.dbo.CliFormaVenta set Estado = 1, Inicial = 1 where CFVTipo = '2' and ClienteClave in ( select cast (case IdCedis when 1 then 'A' 
			when 2 then 'B' 
			when 3 then 'C' 
			when 4 then 'D' 
			when 5 then 'E'
			when 6 then 'F'
			when 7 then 'G'
			when 8 then 'H'
			when 9 then 'I'
			when 10 then 'J'
			else '' end as varchar(5))+IdSucursal from Inserted where FormaVenta = 2 )

	---- ACTUALIZA PRECIO DE ACUERDO AL CLIENTE
	--delete from ROUTE.dbo.ClienteEsquema where ClienteClave in ( select IdSucursal from Inserted where EsquemaId in ( select EsquemaId from ROUTE.dbo.PrecioClienteEsquema ) ) 	
	--insert into ROUTE.dbo.ClienteEsquema 
	--Select IdSucursal, isnull( PreciosListaCliente.IdLista, ( select IdLista from PreciosLista where TipoLista = 'BA' and IdLista in ( select IdLista from PreciosListaCedis where IdCedis = @IdCedis ) ) ), 1, getdate(), 'Interfaz' 
	--from Inserted
	--inner join Clientes on Inserted.IdCedis = Clientes.IdCedis and Inserted.IdCliente = Clientes.IdCliente 
	--left outer join PreciosListaCliente on Clientes.IdCedis = PreciosListaCliente.IdCedis and Clientes.IdCliente = PreciosListaCliente.IdCliente 
	--where Inserted.IdCedis = @IdCedis 

	---- ACTUALIZA PRECIO DE ACUERDO A LA RUTA
	--delete from ROUTE.dbo.ClienteEsquema where ClienteClave in ( select IdSucursal from Inserted where EsquemaId in ( select EsquemaId from ROUTE.dbo.PrecioClienteEsquema ) and IdSucursal in ( select ClienteClave from ROUTE.dbo.Secuencia where RutClave in ( select replicate('0', 2 - len( IdCedis ) ) + cast( IdCedis as varchar(10) ) + '-' + cast( IdRuta as varchar(10) ) from PreciosListaRuta where IdCedis = @IdCedis ) ) ) 
	--insert into ROUTE.dbo.ClienteEsquema 
	--Select distinct IdSucursal, PreciosListaRuta.IdLista, 1, getdate(), 'Interfaz' 
	--from Inserted
	--inner join ROUTE.dbo.Secuencia on Inserted.IdSucursal = ClienteClave
	--inner join PreciosListaRuta on Inserted.IdCedis = PreciosListaRuta.IdCedis and replicate('0', 2 - len( PreciosListaRuta.IdCedis ) ) + cast( PreciosListaRuta.IdCedis as varchar(10) ) + '-' + cast( PreciosListaRuta.IdRuta as varchar(10)) = RutClave
	--where Inserted.IdCedis = @IdCedis 
	
end







GO


