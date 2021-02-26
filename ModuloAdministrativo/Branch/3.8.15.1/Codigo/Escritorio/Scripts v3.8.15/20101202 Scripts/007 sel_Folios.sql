USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_Folios]    Script Date: 12/02/2010 19:12:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_Folios]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_Folios]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_Folios]    Script Date: 12/02/2010 19:12:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[sel_Folios] 
@IdCedis as bigint,
@IdTipoVenta as bigint,
@Folio as bigint,
@Opc as int

AS
declare @IdTipo as bigint, @Serie as varchar(10), @FolioExiste as bigint, @FolioInicial as bigint, @FactCredito as varchar(6), @FactContado as varchar(6)

set @IdTipo = (select Tipo from VentasTipo where IdTipoVenta = @IdTipoVenta)
set @FolioInicial = isnull( (select case @IdTipo 
		when 1 then FolioInicialCredito 
		when 2 then FolioInicialContadoRutas end 
		from Configuracion where IdCedis = @IdCedis ), 0)
		
select @FactCredito = SerieFacturasCredito, @FactContado = SerieFacturasContado  from Configuracion where IdCedis = @IdCedis 

if @Opc = 1
begin
--	set @Serie = isnull( (select case @IdTipo 
--		when 1 then SerieFacturasCredito 
--		when 2 then SerieFacturasContado end 
--		from Configuracion where IdCedis = @IdCedis ), '')
	set @Serie = isnull( (select SerieFacturasCredito from Configuracion where IdCedis = @IdCedis ), '')
	set @Folio = ( select isnull( max(Ventas.Folio)+1, 1) from Ventas 
		where Ventas.IdCedis = @IdCedis and Ventas.Serie not in (@FactContado, @FactCredito) ) --and Ventas.Serie = @Serie 
	
	if @Folio > @FolioInicial
		select @Serie, @Folio
	else
		select @Serie, @FolioInicial
end

if @Opc = 2
begin
--	set @FolioExiste = isnull( (select Folio from Ventas where Ventas.IdCedis = @IdCedis and Ventas.Folio = @Folio and Ventas.IdTipoVenta in ( select VentasTipo.IdTipoVenta from VentasTipo where VentasTipo.Tipo = @IdTipo )), 0)
	-- if @Folio < @FolioInicial set @FolioExiste = 10000
	set @Serie = isnull( (select SerieRemisiones from Configuracion where IdCedis = @IdCedis ), '')
	set @FolioExiste = isnull( (select Folio from Ventas where Ventas.IdCedis = @IdCedis and Ventas.Folio = @Folio and Ventas.Serie not in (@FactContado, @FactCredito) ), 0) --and Ventas.Serie = @Serie 
	select @FolioInicial, @FolioExiste	
end

if @Opc = 3
begin
	set @FolioInicial = isnull( (select case @IdTipo 
		when 1 then FolioInicialCredito 
		when 2 then FolioInicialContado end 
		from Configuracion where IdCedis = @IdCedis ), 0)

	set @Serie = isnull( (select case @IdTipo 
		when 1 then SerieFacturasCredito 
		when 2 then SerieFacturasContado end 
		from Configuracion where IdCedis = @IdCedis ), '')
	set @Folio = ( select isnull( max(VentasContado.Folio)+1, 1) from VentasContado
		where VentasContado.IdCedis = @IdCedis )-- and Ventas.IdTipoVenta in ( select VentasTipo.IdTipoVenta from VentasTipo where VentasTipo.Tipo = @IdTipo )  )
	
	if @Folio > @FolioInicial
		select @Serie, @Folio
	else
		select @Serie, @FolioInicial
end

if @Opc = 4
begin
	set @FolioInicial = isnull( (select case @IdTipo 
		when 1 then FolioInicialCredito 
		when 2 then FolioInicialContado end 
		from Configuracion where IdCedis = @IdCedis ), 0)

	set @FolioExiste = isnull( (select Folio from VentasContado where VentasContado.IdCedis = @IdCedis and VentasContado.Folio = @Folio), 0)
	-- if @Folio < @FolioInicial set @FolioExiste = 10000
	select @FolioInicial, @FolioExiste	
end

if @Opc = 5
begin
	set @Serie = isnull( (select SerieRemisiones from Configuracion where IdCedis = @IdCedis ), '')
	set @Folio = ( select isnull( max(Ventas.Folio)+1, 1) from Ventas 
		where Ventas.IdCedis = @IdCedis and Serie not in (@FactContado, @FactCredito) ) --and Serie = @Serie 
	
	select @Serie, @Folio
end

if @Opc = 6
begin
	select '' as Id, SerieFacturasCredito as Serie, 1 as Orden
	from Configuracion
--	union
--	select '' as Id, SerieFacturasContado as Serie, 2 as Orden
--	from Configuracion
	order by Orden
end

if @Opc = 7
begin
--	set @FolioExiste = isnull( (select Folio from Ventas where Ventas.IdCedis = @IdCedis and Ventas.Folio = @Folio and Ventas.IdTipoVenta in ( select VentasTipo.IdTipoVenta from VentasTipo where VentasTipo.Tipo = @IdTipo )), 0)
	-- if @Folio < @FolioInicial set @FolioExiste = 10000
	set @Serie = isnull( (select SerieFacturasCredito from Configuracion where IdCedis = @IdCedis ), '')
	set @FolioExiste = isnull( (select Folio from Ventas where Ventas.IdCedis = @IdCedis and Ventas.Folio = @Folio and Ventas.Serie not in (@FactContado, @FactCredito)  ), 0) --and Ventas.Serie = @Serie 
	select @FolioInicial, @FolioExiste	
end

GO


