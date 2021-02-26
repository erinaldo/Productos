USE [RouteADM]
GO

/****** Object:  Trigger [tgRouteU_PreciosLista]    Script Date: 05/02/2011 12:44:09 ******/
IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[tgRouteU_PreciosLista]'))
DROP TRIGGER [dbo].[tgRouteU_PreciosLista]
GO

USE [RouteADM]
GO

/****** Object:  Trigger [dbo].[tgRouteU_PreciosLista]    Script Date: 05/02/2011 12:44:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





CREATE TRIGGER [dbo].[tgRouteU_PreciosLista] ON [dbo].[PreciosLista] 
FOR INSERT, UPDATE
AS
declare @Route as int
set @Route = isnull( ( select top 1 Route from Configuracion where IdCedis in ( select IdCedis from Inserted ) ), 0 )

if @Route = 1
begin

	insert into ROUTE.dbo.Precio select IdLista, 0, left( 'LP - ' + Descripcion + ' - ' + TipoLista, 64 ),  1, getdate(), 'Interfaz' from Inserted where cast(IdLista as varchar(10))  not in ( select PrecioClave from ROUTE.dbo.Precio  )
	insert into ROUTE.dbo.Esquema select IdLista, 'LP', left( 'LP - ' + Descripcion + ' - ' + TipoLista, 32 ),  left( 'LP - ' + Descripcion + ' - ' + TipoLista, 16 ),  0, IdLista, 1, 1, 0, 1, getdate(), 'Interfaz' from Inserted where cast(IdLista as varchar(10))  not in ( select EsquemaId from ROUTE.dbo.Esquema  )

--	Crea PrecioClienteEsquema para todos los Módulos
--begin tran sp_Contador
--	declare @RutaF as varchar(16)
--	declare @ModuloF as varchar(16)
--	declare @DescripF as varchar(50)


--	declare  sp_contador cursor for
--		select M.ModuloMovDetalleClave
--		from Route.dbo.modulomovdetalle as M
--		where M.ModuloMovDetalleClave in (/*Ventas*/'26AX3H5ZVGQUA19',/*Devolución al Almacen*/'26BBHBV1EBVKJLH',
--		/*Cargas*/'26BBHBV1EBVWVQF',/*Descargas*/'26BBHBV1EBVIDTG',/*Pago Automatico*/'2H+WEES399+5T29',
--		/*Control de Cambios*/'26B6WLI+YQQMKPQ', /*Movimientos sin Inventario Sin Visita*/'2O72Z1LTEB47HPO',
--		/*Cuentas por Cobrar*/'2TP631GUGIMEZYA') 

--	open sp_Contador
--	fetch next from sp_contador into @ModuloF
--	while (@@fetch_status = 0)
--	begin
	
--		insert into ROUTE.dbo.PrecioClienteEsquema select IdLista, @ModuloF, IdLista, getdate(), 'Interfaz' from Inserted where cast(IdLista as varchar(10))  not in ( select EsquemaId from ROUTE.dbo.PrecioClienteEsquema where PrecioClave = cast(IdLista as varchar(10)) and EsquemaId = cast(IdLista as varchar(10)) and ModuloMovDetalleClave=@ModuloF ) 

--	fetch next from sp_Contador into @ModuloF
--end
--close sp_Contador
--deallocate sp_Contador
--commit tran sp_Contador

	insert into ROUTE.dbo.VendedorEsquema 
	select Vend.VendedorId, cast(IdLista as varchar(10)), 1, getdate(), 'Interfaz'
	from ROUTE.dbo.Vendedor Vend
	inner join PreciosLista on cast(IdLista as varchar(10)) not in (
		select EsquemaId from ROUTE.dbo.VendedorEsquema 
		where EsquemaId = cast(IdLista as varchar(10)) and VendedorId = Vend.VendedorId)

	update ROUTE.dbo.Precio set Nombre = ( select left( 'LP - ' + Descripcion + ' - ' + TipoLista, 64 ) from Inserted where PrecioClave = IdLista  ) where PrecioClave in ( Select IdLista from Inserted where PrecioClave =  cast( IdLista as varchar(10) )  ) 
	update ROUTE.dbo.Esquema set Nombre = ( select left( 'LP - ' + Descripcion + ' - ' + TipoLista, 16 ) from Inserted where EsquemaId = IdLista ), Abreviatura =  ( select left( 'LP - ' + Descripcion + ' - ' + TipoLista, 16 ) from Inserted where EsquemaId = IdLista )
		where EsquemaId in ( Select IdLista from Inserted where EsquemaId =  cast( IdLista as varchar(10) )  ) 

end




GO


