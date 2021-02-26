
select Marcas.Marca, NombreSucursal, Ventas.Serie, Ventas.Folio, sum(VentasDetalle.Total) as Total
from Ventas 
inner join VentasDetalle on Ventas.IdCedis = VentasDetalle.IdCedis and Ventas.IdSurtido = VentasDetalle.IdSurtido 
	and Ventas.IdTipoVenta = VentasDetalle.IdTipoVenta and Ventas.Folio = VentasDetalle.Folio 
inner join Productos on Productos.IdProducto = VentasDetalle.IdProducto 
inner join Marcas on Marcas.IdMarca = Productos.IdMarca  
inner join ClienteSucursal on ClienteSucursal.IdSucursal = Ventas.IdSucursal 
where Ventas.IdCedis = 1 and Ventas.IdSurtido = 6 and Ventas.IdTipoVenta = 2
group by Marcas.Marca, Ventas.IdSucursal, NombreSucursal, Ventas.Serie, Ventas.Folio
order by Marcas.Marca, NombreSucursal, Ventas.Serie, Ventas.Folio

select  M.Marca, NombreSucursal, FAC.Folio, ABN.Total 
from Route.dbo.AbnTrp ABT
inner join Route.dbo.TransProd FAC on ABT.TransProdID = FAC.TransProdID 
left join Route.dbo.TransProd TRP on FAC.TransProdID = TRP.FacturaID 
inner join Route.dbo.Abono ABN on ABT.ABNId = ABN.ABNId 
inner join Route.dbo.Dia Dia on ABN.DiaClave = Dia.DiaClave
inner join Route.dbo.Visita VIS on ABN.VisitaClave = VIS.VisitaClave
inner join Route.dbo.Vendedor VEN on VEN.VendedorID = VIS.VendedorID
inner join Route.dbo.Usuario USU on USU.USUId = VEN.USUId
inner join Marcas M on M.IdMarca = TRP.SubEmpresaID 
inner join ClienteSucursal CS on CS.IdSucursal = TRP.ClienteClave 
where Dia.FechaCaptura= '20100528' and USU.Clave = cast( 1 as varchar(10) ) + replicate('0', 4 - len( 6 ) ) + cast( 6 as varchar(10) ) and 
FAC.Tipo = 8 and FAC.TipoFase <> 0 and (TRP.CFVTipo = 2 or TRP.CFVTipo is null) 
