USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_FacturasImpresion]    Script Date: 12/10/2010 09:48:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_FacturasImpresion]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_FacturasImpresion]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_FacturasImpresion]    Script Date: 12/10/2010 09:48:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO






CREATE PROCEDURE [dbo].[up_FacturasImpresion] 
@Filtro as varchar(5000),
@FolioImpresion as varchar(20),
@Opc as int

AS

--if SUBSTRING(@Filtro,1,4)=' ( V'
--	set @Opc = 1
--else
--	set @Opc = 2

if @Opc = 1
begin
	exec( ' delete 
			from VentasFacturadas
			where VentasFacturadas.Folio in ( select Folio from Ventas as Ventas where Ventas.IdCedis = VentasFacturadas.IdCedis and  Ventas.IdSurtido = VentasFacturadas.IdSurtido 
				and Ventas.IdTipoVenta = VentasFacturadas.IdTipoVenta and Ventas.Folio = VentasFacturadas.Folio and  ' + @Filtro + ' )')

	exec ( ' insert into VentasFacturadas
		select IdCedis, IdSurtido, IdTipoVenta, Folio, Serie, ''' + @FolioImpresion + ''', ''S'', getdate()
		from Ventas as Ventas
		where ' + @Filtro + ' ') 

end

if @Opc = 2
begin
	exec( ' delete 
		from PedidosFacturados 
		where TransProdId in ( select t.TransProdId from PedidosFacturados t where ' + @Filtro + ' )')

	exec ( ' insert into PedidosFacturados
		select t.TransProdId, ''' + @FolioImpresion + ''', ''S'', getdate()
		from Route.dbo.TransProd as t
		where ' + @Filtro + ' ') 
end

if @Opc = 5
begin
	exec( ' delete 
		from PedidosFacturados 
		where TransProdId in ( ' + @Filtro + ' )')

	exec ( ' insert into PedidosFacturados
		select ' + @Filtro + ', ''' + @FolioImpresion + ''', ''S'', getdate() ') 

end
	
GO


