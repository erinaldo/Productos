
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go




ALTER PROCEDURE [dbo].[up_FacturasImpresion] 
@Filtro as varchar(5000),
@FolioImpresion as varchar(20),
@Opc as int

AS

if @Opc = 1
begin
	exec( ' delete 
		from VentasFacturadas as Ventas
		where ' + @Filtro + ' ')

	exec ( ' insert into VentasFacturadas
		select IdCedis, IdSurtido, IdTipoVenta, Folio, Serie, ''' + @FolioImpresion + ''', ''S'', getdate()
		from Ventas
		where ' + @Filtro + ' ') 

end

