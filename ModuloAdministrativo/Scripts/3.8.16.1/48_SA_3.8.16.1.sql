USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_VentasDevoluciones]    Script Date: 08/02/2011 14:53:27 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_VentasDevoluciones]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_VentasDevoluciones]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_VentasDevoluciones]    Script Date: 08/02/2011 14:53:27 ******/
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

declare @SerieD as varchar(6), @Serie as varchar(6), @SerieRem as varchar(6) 
declare @IdCliente as bigint, @IdSucursal as varchar(10)

if @Opc = 1
begin 

	select @SerieD = SerieDevoluciones from Configuracion where IdCedis = @IdCedis
	select @SerieRem = SerieRemisiones from Configuracion where IdCedis = @IdCedis
	
	select @FolioD = ISNULL(MAX(Folio) + 1, 1)
	from Ventas 
	where IdCedis = @IdCedis and Serie in (@SerieRem, @SerieD)

	insert into Ventas
	select SURD.IdCedis, SURD.IdSurtido, @IdTipoVenta, @FolioD, @SerieD, SURD.Fecha,0,0,0, '', 0, 0,null
	from Surtidos SURD 
	where SURD.IdCedis = @IdCedis and SURD.IdSurtido = @IdSurtidoD  
	
	select @IdCliente = IdCliente, @IdSucursal = IdSucursal, @Serie = Serie 
	from Ventas
	where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio 

	update Ventas set IdCliente = @IdCliente, IdSucursal = @IdSucursal 
	where IdCedis = @IdCedis and IdSurtido = @IdSurtidoD and IdTipoVenta = @IdTipoVenta and Folio = @FolioD 
	
	insert into VentasDevolucion values (@IdCedis, @IdSurtidoD, @IdTipoVenta, @FolioD, @SerieD, @IdSurtido, @IdTipoVenta, @Folio, @Serie, @IdCliente, @IdSucursal, 'V') 

end


GO

USE [Route]
GO

if (Select COUNT(*) from VersionBD where Tipo = 'SA' and Version ='3.8.16.1') = 0
BEGIN
	INSERT INTO VersionBD (Tipo, FechaHora, Version, MaximoConsecutivo, VersionSql ) 
	VALUES('SA', GETDATE(), '3.8.16.1', 48, (SELECT  cast(SERVERPROPERTY('productversion') as varchar(50))))
END
ELSE
BEGIN 
	Update VersionBD  set MaximoConsecutivo = 48 where  Tipo = 'SA' and Version ='3.8.16.1'
END
GO