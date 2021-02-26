USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_ComisionesHistorico]    Script Date: 12/07/2010 09:53:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_ComisionesHistorico]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_ComisionesHistorico]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_ComisionesHistorico]    Script Date: 12/07/2010 09:53:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[up_ComisionesHistorico]
@IdCedis as bigint,
@FechaInicial as datetime,
@FechaFinal as datetime,
@Usuario as varchar(50),
@Opc as int

AS

if @Opc = 1
begin 

	delete from ComisionesHistorico 
	where Usuario = @Usuario and Fecha between @FechaInicial and @FechaFinal 

	insert into ComisionesHistorico 
	select RIGHT(newid(),20), @Usuario, GETDATE(), IdCedis, IdSurtido, Fecha, IdComEsquema, Esquema, IdConceptoPago, ConceptoPago, 
	TipoRuta, IdRuta, IdTipoVendedor, TipoVendedor, IdFamilia, Familia, IdProducto, Producto, Venta, Inicial, Final, 
	Factor, Pago, AbonoMerma, AbonoVolumen 
	from FN_ComisionesEsquemaFecha(@IdCedis, @FechaInicial, @FechaFinal )

end

if @Opc = 2
begin 

	select RIGHT(newid(),20), @Usuario, GETDATE(), IdCedis, IdSurtido, Fecha, IdComEsquema, Esquema, IdConceptoPago, ConceptoPago, 
	TipoRuta, IdRuta, IdTipoVendedor, TipoVendedor, IdFamilia, Familia, IdProducto, Producto, Venta, Inicial, Final, 
	Factor, Pago, AbonoMerma, AbonoVolumen 
	from FN_ComisionesEsquemaFecha(@IdCedis, @FechaInicial, @FechaFinal )

end

GO


