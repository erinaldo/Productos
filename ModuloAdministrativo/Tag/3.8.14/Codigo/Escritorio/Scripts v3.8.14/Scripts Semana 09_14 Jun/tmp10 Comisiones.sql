--select distinct IdVendedor, Nomina, Vendedor
--from FN_ComisionesDetalleFecha(1, '20100602', '20100608')
--order by IdVendedor, Nomina, Vendedor 

select IdVendedor, Nomina, Vendedor, SUM(Pago) as Pago, Fecha, IdSurtido
from FN_ComisionesDetalleFecha(1, '20100602', '20100608')
group by IdVendedor, Nomina, Vendedor, Fecha, IdSurtido
order by Fecha, Vendedor -- , Fecha 

--select Vendedores.IdVendedor, Vendedores.Nomina, ApPaterno + ' ' + ApMaterno + ' ' + Nombre as Vendedor,
--FN_ComisionesEsquemaFecha.IdSurtido, FN_ComisionesEsquemaFecha.IdTipoVendedor, 
--FN_ComisionesEsquemaFecha.TipoVendedor, SUM(FN_ComisionesEsquemaFecha.Pago) as Pago
--from FN_ComisionesEsquemaFecha(1, '20100601', '20100601') 
--inner join FN_ComisionesEsquema(1) on FN_ComisionesEsquema.IdComEsquema = FN_ComisionesEsquemaFecha.IdComEsquema and FN_ComisionesEsquema.IdConceptoPago = FN_ComisionesEsquemaFecha.IdConceptoPago
--	and FN_ComisionesEsquema.IdTipoRuta = FN_ComisionesEsquemaFecha.TipoRuta and FN_ComisionesEsquema.IdTipoVendedor = FN_ComisionesEsquemaFecha.IdTipoVendedor
--	and FN_ComisionesEsquema.IdProducto = FN_ComisionesEsquemaFecha.IdProducto 
--	-- and FN_ComisionesEsquemaFecha.IdSurtido = 56
--inner join SurtidosVendedor on FN_ComisionesEsquemaFecha.IdCedis = SurtidosVendedor.IdCedis and FN_ComisionesEsquemaFecha.IdSurtido = SurtidosVendedor.IdSurtido 
--	and FN_ComisionesEsquemaFecha.IdTipoVendedor = SurtidosVendedor.IdTipoVendedor
--inner join Vendedores on Vendedores.IdCedis = SurtidosVendedor.IdCedis and Vendedores.IdVendedor = SurtidosVendedor.IdVendedor 
--group by Vendedores.IdVendedor, Vendedores.Nomina, ApPaterno, ApMaterno, Nombre, 
--FN_ComisionesEsquemaFecha.TipoVendedor, FN_ComisionesEsquemaFecha.IdSurtido, FN_ComisionesEsquemaFecha.IdTipoVendedor
--order by FN_ComisionesEsquemaFecha.IdSurtido, Vendedores.IdVendedor

--select FN_ComisionesEsquemaFecha.IdSurtido, FN_ComisionesEsquemaFecha.IdTipoVendedor, SUM(FN_ComisionesEsquemaFecha.Pago) as Pago
--from FN_ComisionesEsquema(1)
--inner join FN_ComisionesEsquemaFecha(1, '20100601', '20100601') on FN_ComisionesEsquema.IdComEsquema = FN_ComisionesEsquemaFecha.IdComEsquema and FN_ComisionesEsquema.IdConceptoPago = FN_ComisionesEsquemaFecha.IdConceptoPago
--	and FN_ComisionesEsquema.IdTipoRuta = FN_ComisionesEsquemaFecha.TipoRuta and FN_ComisionesEsquema.IdTipoVendedor = FN_ComisionesEsquemaFecha.IdTipoVendedor
--	and FN_ComisionesEsquema.IdProducto = FN_ComisionesEsquemaFecha.IdProducto 
--	and FN_ComisionesEsquemaFecha.IdSurtido = 56
--group by FN_ComisionesEsquemaFecha.IdSurtido, FN_ComisionesEsquemaFecha.IdTipoVendedor

--select FN_ComisionesEsquemaFecha.IdSurtido, FN_ComisionesEsquemaFecha.IdTipoVendedor, SUM(FN_ComisionesEsquemaFecha.Pago) as Pago
--from FN_ComisionesEsquemaFecha(1, '20100601', '20100601') 
--inner join FN_ComisionesEsquema(1) on FN_ComisionesEsquema.IdComEsquema = FN_ComisionesEsquemaFecha.IdComEsquema and FN_ComisionesEsquema.IdConceptoPago = FN_ComisionesEsquemaFecha.IdConceptoPago
--	and FN_ComisionesEsquema.IdTipoRuta = FN_ComisionesEsquemaFecha.TipoRuta and FN_ComisionesEsquema.IdTipoVendedor = FN_ComisionesEsquemaFecha.IdTipoVendedor
--	and FN_ComisionesEsquema.IdProducto = FN_ComisionesEsquemaFecha.IdProducto 
--	and FN_ComisionesEsquemaFecha.IdSurtido = 56
--group by FN_ComisionesEsquemaFecha.IdSurtido, FN_ComisionesEsquemaFecha.IdTipoVendedor

--select FN_ComisionesEsquemaSurtido.IdSurtido, FN_ComisionesEsquemaSurtido.IdTipoVendedor, SUM(FN_ComisionesEsquemaSurtido.Pago) as Pago
--from FN_ComisionesEsquema(1)
--inner join FN_ComisionesEsquemaSurtido(1, 56) on FN_ComisionesEsquema.IdComEsquema = FN_ComisionesEsquemaSurtido.IdComEsquema and FN_ComisionesEsquema.IdConceptoPago = FN_ComisionesEsquemaSurtido.IdConceptoPago
--	and FN_ComisionesEsquema.IdTipoRuta = FN_ComisionesEsquemaSurtido.TipoRuta and FN_ComisionesEsquema.IdTipoVendedor = FN_ComisionesEsquemaSurtido.IdTipoVendedor
--	and FN_ComisionesEsquema.IdProducto = FN_ComisionesEsquemaSurtido.IdProducto 
--group by FN_ComisionesEsquemaSurtido.IdSurtido, FN_ComisionesEsquemaSurtido.IdTipoVendedor

--select * 
--from FN_ComisionesEsquema(1)

--select * from FN_ComisionesEsquemaSurtido(1, 56)

-- select * from FN_ComisionesEsquemaFecha(1, '20100601', '20100601')

-- execute sel_ComisionesLiquidacion 1, 56, '20100601', '20100601'