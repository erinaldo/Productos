USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_Preventa]    Script Date: 08/17/2011 22:49:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_Preventa]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_Preventa]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_Preventa]    Script Date: 08/17/2011 22:49:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[up_Preventa] 
@IdCedis as bigint,
@IdSurtido as bigint,
@TransprodID varchar(30),
@IdCliente as bigint,
@Opc as int

AS

if @Opc = 1 -- Inserta Venta por Pedido Route
begin

declare @Fecha as datetime

	select top 1 @Fecha=Fecha from Surtidos where idcedis=@idcedis and IdSurtido=@IdSurtido 

	select top 1 @IdCliente = IdCliente 
	from ClienteSucursal 
	where IdCedis = @IdCedis and IdSucursal in ( select ClienteClave from Route.dbo.TransProd where TransProdID = @TransprodID )
	order by IdSucursal
	
	insert into Ventas
	SELECT @IdCedis, @IdSurtido, TRP.CFVTipo, replace(replace(Route.dbo.FNObtenerSoloNumeros(right(TRP.Folio,11)),'-',''),'+',''), 
	'R' + cast(cast(right(TRP.MUsuarioID,4) as bigint) as varchar(4)), @Fecha , @IdCliente, TRP.Subtotal, TRP.Impuesto,
	TRP.ClienteClave, TRP.DescuentoImp, TRP.DiasCredito, null, DIA.FechaCaptura, RIGHT(Route.dbo.FNObtenerRutaADMINTer(VIS.RUTClave),4)  
	FROM Route.dbo.TransProd TRP
	INNER JOIN Route.dbo.Dia DIA ON DIA.DiaClave = TRP.DiaClave
	INNER JOIN Route.dbo.Visita VIS ON VIS.DiaClave = TRP.DiaClave AND VIS.VisitaClave = TRP.VisitaClave 
	WHERE TRP.TransProdID = @TransprodID

	insert into VentasDetalle
	SELECT @IdCedis, @IdSurtido, TRP.CFVTipo, replace(replace(Route.dbo.FNObtenerSoloNumeros(right(TRP.Folio,11)),'-',''),'+',''), 
	TRPD.ProductoClave, 'R' + cast(cast(right(TRP.MUsuarioID,4) as bigint) as varchar(4)), TRPD.Cantidad, TRPD.Precio, 
	TRPD.Impuesto, TRPD.DescuentoImp/TRPD.Total, TRPD.DescuentoImp, TRPD.Cantidad
	FROM Route.dbo.TransProd TRP
	INNER JOIN Route.dbo.Dia DIA ON DIA.DiaClave = TRP.DiaClave
	INNER JOIN Route.dbo.Visita VIS ON VIS.DiaClave = TRP.DiaClave AND VIS.VisitaClave = TRP.VisitaClave 
	INNER JOIN Route.dbo.TransProdDetalle TRPD ON TRP.TransProdId = TRPD.TransProdId
	inner join Route.dbo.Producto PRO on PRO.ProductoClave = TRPD.ProductoClave 
	inner join Route.dbo.ProductoDetalle PRD on TRPD.ProductoClave = PRD.ProductoClave and TRPD.TipoUnidad = PRD.PRUTipoUnidad and PRD.ProductoClave = PRD.ProductoDetClave 
	WHERE TRP.TransProdID = @TransprodID

end



GO



USE [Route] 
GO

if (Select COUNT(*) from VersionBD where Tipo = 'SA' and Version ='3.8.16.1') = 0
BEGIN
	INSERT INTO VersionBD (Tipo, FechaHora, Version, MaximoConsecutivo, VersionSql ) 
	VALUES('SA', GETDATE(), '3.8.16.1', 61, (SELECT  cast(SERVERPROPERTY('productversion') as varchar(50))))
END
ELSE
BEGIN 
	Update VersionBD  set MaximoConsecutivo = 61 where  Tipo = 'SA' and Version ='3.8.16.1'
END
GO