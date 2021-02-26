USE [RouteADM]
GO

/****** Object:  Trigger [tgRouteU_Rutas]    Script Date: 02/17/2011 15:43:18 ******/
IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[tgRouteU_Rutas]'))
DROP TRIGGER [dbo].[tgRouteU_Rutas]
GO

USE [RouteADM]
GO

/****** Object:  Trigger [dbo].[tgRouteU_Rutas]    Script Date: 02/17/2011 15:43:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[tgRouteU_Rutas] ON [dbo].[Rutas] 
FOR INSERT, UPDATE
AS
declare @Route as int, @IdUsuario as varchar(5), @IdRuta as varchar(5), @Ruta as varchar(5), @Terminal as varchar(25), @IdCedis as varchar(2)
set @Route = isnull( ( select Route from Configuracion where IdCedis in ( select IdCedis from Inserted ) ), 0 )

if @Route = 1
begin

	insert into ROUTE.dbo.Ruta select cast( IdCedis as varchar(10) ) + replicate('0', 4 - len( IdRuta ) ) + cast( IdRuta as varchar(10) ), Ruta, 
		case TipoVenta
			when 'Venta' then 1
			when 'Preventa' then 2
			when 'Reparto' then 3
		end, 
		0, 0, getdate(), 'Interfaz' from Inserted where cast( IdCedis as varchar(10) ) + replicate('0', 4 - len( IdRuta ) ) + cast( IdRuta as varchar(10) ) not in ( select RUTClave from ROUTE.dbo.Ruta  )

	update 	ROUTE.dbo.Ruta set TipoEstado = 0 where RUTClave in ( select cast( IdCedis as varchar(10) ) + replicate('0', 4 - len( IdRuta ) ) + cast( IdRuta as varchar(10) ) from Inserted where Status <> 'A' )
	update 	ROUTE.dbo.Ruta set TipoEstado = 1 where RUTClave in ( select cast( IdCedis as varchar(10) ) + replicate('0', 4 - len( IdRuta ) ) + cast( IdRuta as varchar(10) ) from Inserted where Status = 'A' )

	update ROUTE.dbo.Ruta set Descripcion = ( select Ruta from Inserted where RUTClave = cast( IdCedis as varchar(10) ) + replicate('0', 4 - len( IdRuta ) ) + cast( IdRuta as varchar(10) )  ),
		Tipo = ( select 		case TipoVenta
			when 'Venta' then 1
			when 'Preventa' then 2
			when 'Reparto' then 3
		end from Inserted where RUTClave = cast( IdCedis as varchar(10) ) + replicate('0', 4 - len( IdRuta ) ) + cast( IdRuta as varchar(10) )  )
	where RUTClave = ( select cast( IdCedis as varchar(10) ) + replicate('0', 4 - len( IdRuta ) ) + cast( IdRuta as varchar(10) ) from Inserted where cast( IdCedis as varchar(10) ) + replicate('0', 4 - len( IdRuta ) ) + cast( IdRuta as varchar(10) ) = RUTClave  )

	insert into ROUTE.dbo.Usuario 
	select cast( IdCedis as varchar(10) ) + replicate('0', 4 - len( IdRuta ) ) + cast( IdRuta as varchar(10) ), 'Ven', 
	cast( IdCedis as varchar(10) ) + replicate('0', 4 - len( IdRuta ) ) + cast( IdRuta as varchar(10) ),
	'Usuario Ruta ' + cast( IdCedis as varchar(10) ) + replicate('0', 4 - len( IdRuta ) ) + cast( IdRuta as varchar(10) ), 
	Route.dbo.FNCrypt('123'), 0, getdate(), 1, 1, getdate(), 'Interfaz'
	from Inserted where cast( IdCedis as varchar(10) ) + replicate('0', 4 - len( IdRuta ) ) + cast( IdRuta as varchar(10) ) not in (select UsuId from ROUTE.dbo.Usuario)

	insert into Route.dbo.Terminal select cast( IdCedis as varchar(10) ) + replicate('0', 4 - len( IdRuta ) ) + cast( IdRuta as varchar(10) ), 3, 'Terminal ' + cast( IdCedis as varchar(10) ) + replicate('0', 4 - len( IdRuta ) ) + cast( IdRuta as varchar(10) ),
		'', '', 0, getdate(), 'Interfaz'
	from Inserted where cast( IdCedis as varchar(10) ) + replicate('0', 4 - len( IdRuta ) ) + cast( IdRuta as varchar(10) ) not in (select TerminalClave from Route.dbo.Terminal)

	insert into ROUTE.dbo.Vendedor 
	select cast( IdCedis as varchar(10) ) + replicate('0', 4 - len( IdRuta ) ) + cast( IdRuta as varchar(10) ), MCNClave,
		cast( IdCedis as varchar(10) ) + replicate('0', 4 - len( IdRuta ) ) + cast( IdRuta as varchar(10) ),'1', ModuloClave,
		(select top 1 AlmacenId
		from ROUTE.dbo.Almacen
		where Tipo = 2 and TipoEstado = 1), 
		1,3,0,1,
		cast( IdCedis as varchar(10) ) + replicate('0', 4 - len( IdRuta ) ) + cast( IdRuta as varchar(10) ), 
		cast( IdCedis as varchar(10) ) + replicate('0', 4 - len( IdRuta ) ) + cast( IdRuta as varchar(10) ), 
		0,0,0, '', 1,1,1, -- jornada de trabajo
		1,0,7, 0,1,1, getdate(), 'Interfaz'
	from Inserted 
	inner join ROUTE.dbo.motconfiguracion MC on Inserted.TipoVenta = MC.MCNClave
	where cast( IdCedis as varchar(10) ) + replicate('0', 4 - len( IdRuta ) ) + cast( IdRuta as varchar(10) ) not in (select VendedorId from ROUTE.dbo.Vendedor)
	
	update ROUTE.dbo.Vendedor set MCNClave = MC.MCNClave, ModuloClave = MC.ModuloClave 
	from ROUTE.dbo.motconfiguracion MC, Inserted 
	where Inserted.TipoVenta = MC.MCNClave 
		and cast( Inserted.IdCedis as varchar(10) ) + replicate('0', 4 - len( Inserted.IdRuta ) ) + cast( Inserted.IdRuta as varchar(10) ) =
		Route.dbo.Vendedor.VendedorId 

	insert into Route.dbo.VENCentroDistHist
	select cast( IdCedis as varchar(10) ) + replicate('0', 4 - len( IdRuta ) ) + cast( IdRuta as varchar(10) ), 
		(select Top 1 AlmacenId from Route.dbo.Almacen where TipoEstado = 1 and Tipo = 1), 
	getdate(), '99990101', getdate(), 'Interfaz'
	from Inserted where cast( IdCedis as varchar(10) ) + replicate('0', 4 - len( IdRuta ) ) + cast( IdRuta as varchar(10) ) not in (select VendedorId from ROUTE.dbo.VENCentroDistHist)

	delete from Route.dbo.VendedorEsquema
	where VendedorId in ( select cast( IdCedis as varchar(10) ) + replicate('0', 4 - len( IdRuta ) ) + cast( IdRuta as varchar(10) ) from Inserted)

	declare @EsquemaId as varchar(50), @FolioId as varchar(50)
	
	declare InsEsquemas cursor for
		select distinct EsquemaId
		from Route.dbo.Esquema
		where EsquemaId in ('CLI', 'LP', 'NVO', 'PRO')
	open InsEsquemas
	
	fetch next from InsEsquemas into @EsquemaId
	while (@@fetch_status = 0)
	begin
		insert into Route.dbo.VendedorEsquema
		select cast( IdCedis as varchar(10) ) + replicate('0', 4 - len( IdRuta ) ) + cast( IdRuta as varchar(10) ),
		@EsquemaId, 1, getdate(), 'Interfaz'
		from Inserted 

		fetch next from InsEsquemas into @EsquemaId
	end
	close InsEsquemas
	deallocate InsEsquemas		
	
	
	--Crea Folios de todos los movimientos a todos los vendedores
begin tran sp_Contador
	declare @RutaF as varchar(16)
	declare @ModuloF as varchar(16)
	declare @DescripF as varchar(50)


	declare  sp_contador cursor for
		select R.RUTClave,M.ModuloMovDetalleClave,M.Nombre+' '+R.RUTClave 
		from Route.dbo.modulomovdetalle as M, 
		Route.dbo.Ruta as r
		where 
		R.TipoEstado=1 and					   
		M.ModuloMovDetalleClave in (/*Ventas*/'26AX3H5ZVGQUA19',/*Devolución al Almacen*/'26BBHBV1EBVKJLH',
		/*Cargas*/'26BBHBV1EBVWVQF',/*Descargas*/'26BBHBV1EBVIDTG',/*Pago Automatico*/'2H+WEES399+5T29',
		/*Control de Cambios*/'26B6WLI+YQQMKPQ', /*Movimientos sin Inventario Sin Visita*/'2O72Z1LTEB47HPO',
		/*Cuentas por Cobrar*/'2TP631GUGIMEZYA') and R.RutClave not in (
			select FU.vendedorId
			from Route.dbo.Folio F
			inner join Route.dbo.FolioUsuario FU on FU.FolioId = F.FolioId
			where R.RutClave = FU.vendedorId and F.ModuloMovDetalleClave = M.ModuloMovDetalleClave)

	open sp_Contador
	fetch next from sp_contador into @RutaF,@ModuloF,@DescripF
	while (@@fetch_status = 0)
	begin

	declare @FolioIdF as varchar(16)
	select @FolioIdF=right(newid(),16)
	--Folio	
	insert into Route.dbo.Folio values(@FolioIdF,@ModuloF,@DescripF,0,1,0,'',getdate(),'Admin')
	--FolioDetalle
	insert into Route.dbo.FolioDetalle values(@FolioIdF,1,1,@RutaF+'-',1,getdate(),'Admin')
	insert into Route.dbo.FolioDetalle values(@FolioIdF,2,2,'00000',1,getdate(),'Admin')

	--FolioUsuario
	insert into Route.dbo.FolioUsuario values (@FolioIdF,@RutaF,10000,2,getdate(),'Admin')

	--FolioReservacion
	insert into Route.dbo.FolioReservacion values(@FolioIdF,@RutaF,right(newid(),16),getdate(),1,100000,0,1,getdate(),'Admin')

	fetch next from sp_Contador into @RutaF,@ModuloF,@DescripF
end
close sp_Contador
deallocate sp_Contador
commit tran sp_Contador

	insert into Route.dbo.VenRut	
	select cast( IdCedis as varchar(10) ) + replicate('0', 4 - len( IdRuta ) ) + cast( IdRuta as varchar(10) ), 
	cast( IdCedis as varchar(10) ) + replicate('0', 4 - len( IdRuta ) ) + cast( IdRuta as varchar(10) ),
	1, getdate(), 'Interfaz'
	from Inserted where cast( IdCedis as varchar(10) ) + replicate('0', 4 - len( IdRuta ) ) + cast( IdRuta as varchar(10) ) not in (select VendedorId from ROUTE.dbo.VenRut)

end


GO


