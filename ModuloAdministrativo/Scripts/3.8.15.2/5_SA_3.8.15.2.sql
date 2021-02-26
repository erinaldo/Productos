USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_VentasDevoluciones]    Script Date: 08/13/2011 14:07:24 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_VentasDevoluciones]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_VentasDevoluciones]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_VentasDevoluciones]    Script Date: 08/13/2011 14:07:24 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO






CREATE PROCEDURE [dbo].[up_VentasDevoluciones] 
 @IdCedis as bigint,
@IdSurtido as bigint,
@IdTipoVenta as bigint,
@Folio as bigint,
@IdSurtidoD as bigint,
@IdTipoVentaD as bigint,
@FolioD as bigint,
@Opc as int

AS

--set @IdCedis = 1 
--set @IdSurtido = 10360
--set @IdTipoVenta = 1
--set @Folio = 42177
--set @IdSurtidoD = 10432
--set @IdTipoVentaD = 2
--set @FolioD = 0
--set @Opc = 1

declare @SerieD as varchar(6), @Serie as varchar(6), @SerieRem as varchar(6) 
declare @IdCliente as bigint, @IdSucursal as varchar(10)

if @Opc = 1
begin 

	select @SerieD = SerieDevoluciones from Configuracion where IdCedis = @IdCedis
	select @SerieRem = SerieRemisiones from Configuracion where IdCedis = @IdCedis
	
	select @FolioD = isnull(Ultimo + 1, 1) from FoliosRemision where IdCedis = @IdCedis and Serie in (@SerieD, @SerieRem)		

	insert into Ventas 	
	select SURD.IdCedis, SURD.IdSurtido, @IdTipoVenta, @FolioD, @SerieD, SURD.Fecha, 0,0,0, '', 0, 0
	from Surtidos SURD 
	where SURD.IdCedis = @IdCedis and SURD.IdSurtido = @IdSurtidoD  
	
	select @IdCliente = IdCliente, @IdSucursal = IdSucursal, @Serie = Serie 
	from Ventas
	where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio 

	update Ventas set IdCliente = @IdCliente, IdSucursal = @IdSucursal 
	where IdCedis = @IdCedis and IdSurtido = @IdSurtidoD and IdTipoVenta = @IdTipoVenta and Folio = @FolioD 
	
	insert into VentasDevolucion values (@IdCedis, @IdSurtidoD, @IdTipoVenta, @FolioD, @SerieD, @IdSurtido, @IdTipoVenta, @Folio, @Serie, @IdCliente, @IdSucursal, 'V') 

	if exists (select * from FoliosRemision where IdCedis = @IdCedis and Serie in (@SerieRem, @SerieD))
		update FoliosRemision set Ultimo = @FolioD where IdCedis = @IdCedis and Serie in (@SerieRem, @SerieD)
	else
		insert into FoliosRemision values (@IdCedis, @SerieRem, @FolioD)	
end





GO




