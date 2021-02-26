USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_VentasContado]    Script Date: 12/09/2010 13:16:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_VentasContado]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_VentasContado]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_VentasContado]    Script Date: 12/09/2010 13:16:12 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO



CREATE PROCEDURE [dbo].[up_VentasContado]
@IdCedis as bigint,
@Fecha as datetime,
@Folio as bigint,
@Serie as varchar(5),
@Status as varchar(50),
@Opc as int

AS

if @Opc = 1 -- Inserta Factura Nueva
begin
	if not exists( select Folio from VentasContado where IdCedis = @IdCedis and Fecha = @Fecha )
		insert into VentasContado values (@IdCedis, @Fecha, @Folio, @Serie, @Status)	
end

if @Opc = 2
begin
	
	update VentasContado set Folio = @Status where IdCedis = @IdCedis and Fecha = @Fecha and Folio = @Folio 
	
--	--insert into VentasFacturadas 
--	--select distinct Ventas.IdCedis, Ventas.IdSurtido, Ventas.IdTipoVenta, Ventas.Folio, Ventas.Serie, rtrim(@Status), 'S', GETDATE() 
--	--from Surtidos 
--	--inner join Ventas on Ventas.IdCedis = Surtidos.IdCedis and Ventas.IdSurtido = Surtidos.IdSurtido 
--	--	and Ventas.IdTipoVenta in ( select IdTipoVenta from VentasTipo where Tipo = 2 )
--	--left outer join VentasFacturadas on Ventas.IdCedis = VentasFacturadas.IdCedis and Ventas.IdSurtido = VentasFacturadas.IdSurtido 
--	--	and Ventas.IdTipoVenta = VentasFacturadas.IdTipoVenta and Ventas.Folio = VentasFacturadas.Folio 
--	--where Surtidos.IdCedis = @IdCedis and Surtidos.Fecha = @Fecha and VentasFacturadas.Serie is null
--	--order by Ventas.IdCedis, Ventas.IdSurtido, Ventas.IdTipoVenta, Ventas.Folio 
		
end


GO


