USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[sel_PromocionesAplicadasDetalle]    Script Date: 03/28/2011 00:31:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_PromocionesAplicadasDetalle]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_PromocionesAplicadasDetalle]
GO

USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[sel_PromocionesAplicadasDetalle]    Script Date: 03/28/2011 00:31:14 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[sel_PromocionesAplicadasDetalle] 
@IdAplicacion as bigint,
@IdPromocion as bigint,
@Opc as int
AS

if @Opc = 1
	Select PMD.IdCedis, Cedis, PMD.IdMovimiento as Folio, Folio.Fecha as Fecha, PMD.IdCliente, isnull(Tipo, '-') as CTipo, RazonSocial, Serie, PMD.Folio, PMD.Fecha as FechaFactura, Saldo, PMD.Monto, Aplicado, PMD.IdDocumento, Documento, PMD.IdTipoDocumento, TipoDocumento
	from PromocionesAplicadasDetalle as PMD
	inner join Cedis on Cedis.IdCedis = PMD.IdCedis
	inner join Clientes on Clientes.IdCedis = PMD.IdCedis and PMD.IdCliente = Clientes.IdCliente
	left outer join ClientesTipo on Clientes.IdCedis = ClientesTipo.IdCedis and ClientesTipo.IdCliente = Clientes.IdCliente
	inner join Documentos on Documentos.IdDocumento = PMD.IdDocumento
	inner join DocumentosTipo on DocumentosTipo.IdTipoDocumento = PMD.IdTipoDocumento
	inner join Folio on Folio.Folio = PMD.IdMovimiento 
	where PMD.IdAplicacion = @IdAplicacion and PMD.IdPromocion = @IdPromocion and PMD.Saldo > 0 and PMD.Monto > 0
	order by PMD.IdCedis, PMD.IdCliente, FechaFactura

if @Opc = 2
	Select isnull( sum(Monto), 0)  as Monto, count(Folio) as NumFacturas
	from PromocionesAplicadasDetalle as PMD
	where PMD.IdAplicacion = @IdAplicacion and PMD.IdPromocion = @IdPromocion and PMD.Saldo > 0 and PMD.Monto > 0 and substring(Aplicado, 1, 1) = 'A'

GO


