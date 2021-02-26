
SELECT     SUR.IdCedis, SUR.IdRuta, SUR.Fecha, SUR.IdSurtido AS Surtido, RUT.Ruta, ISNULL( VVTACONT.Total, 0) AS [Venta Contado], 
		ISNULL(( select SUM(SD.Cantidad * SD.IdDenominacion * isnull(TC1.TipoCambio, 1))
		from SurtidosDenominacion SD LEFT OUTER JOIN 
		TipoDeCambio TC1 on TC1.IdMoneda = SD.IdMoneda and TC1.Fecha = SUR.Fecha 
		where SD.IdCedis = SUR.IdCedis AND SD.IdSurtido = SUR.IdSurtido ), 0)
		+ ISNULL(( select SUM(SCH.Importe * isnull(TC2.TipoCambio, 1))
		from SurtidosCheque SCH LEFT OUTER JOIN
		TipoDeCambio TC2 on TC2.IdMoneda = SCH.IdMoneda and TC2.Fecha = SUR.Fecha
		where SCH.IdCedis = SUR.IdCedis and SCH.IdSurtido = SUR.IdSurtido ), 0) AS [Efectivo], 		
		ISNULL(( select SUM(SD.Cantidad * SD.IdDenominacion * isnull(TC1.TipoCambio, 1))
		from SurtidosDenominacion SD LEFT OUTER JOIN 
		TipoDeCambio TC1 on TC1.IdMoneda = SD.IdMoneda and TC1.Fecha = SUR.Fecha 
		where SD.IdCedis = SUR.IdCedis AND SD.IdSurtido = SUR.IdSurtido ), 0)
		+ ISNULL(( select SUM(SCH.Importe * isnull(TC2.TipoCambio, 1))
		from SurtidosCheque SCH LEFT OUTER JOIN
		TipoDeCambio TC2 on TC2.IdMoneda = SCH.IdMoneda and TC2.Fecha = SUR.Fecha
		where SCH.IdCedis = SUR.IdCedis and SCH.IdSurtido = SUR.IdSurtido ), 0)  
		- ISNULL( VVTACONT.Total, 0) AS [Diferencia], 
			ISNULL(VVTACRED.Subtotal, 0) AS [Venta Crédito], ISNULL(VVTACRED.IVA, 0) 
					  AS [Iva Crédito], ISNULL(VVTACRED.Total, 0) AS [Total Crédito],
						  isnull((SELECT     TOP 1  VEN.ApPaterno + ' ' + VEN.ApMaterno + ' ' + VEN.Nombre
							FROM          SurtidosVendedor SURVEN INNER JOIN
												   Vendedores VEN ON SURVEN.IdCedis = VEN.IdCedis AND SURVEN.IdVendedor = VEN.IdVendedor
							WHERE      SUR.IdCedis = SURVEN.idcedis AND SUR.IdSurtido = SURVEN.IdSurtido
							ORDER BY SURVEN.idtipovendedor), 'Vendedor no asignado') AS [Nombre del Vendedor]
FROM         Surtidos SUR INNER JOIN
					  Rutas RUT ON SUR.IdCedis = RUT.IdCedis AND SUR.IdRuta = RUT.IdRuta LEFT OUTER JOIN
					  VWSurtidoVentaCredito VVTACRED ON SUR.IdCedis = VVTACRED.IdCedis AND SUR.IdSurtido = VVTACRED.IdSurtido LEFT OUTER JOIN
					  VWSurtidoVentaContado VVTACONT ON SUR.IdCedis = VVTACONT.IdCedis AND SUR.IdSurtido = VVTACONT.IdSurtido 
WHERE     (SUR.IdCedis = 2) AND (SUR.Fecha BETWEEN '20101122' AND '20101122' )  
GROUP BY SUR.IdCedis, SUR.IdRuta, SUR.Fecha, SUR.IdSurtido, RUT.Ruta, VVTACRED.Subtotal, VVTACRED.Iva, VVTACRED.Total, VVTACONT.Total
ORDER BY SUR.IdCedis, SUR.Fecha, SUR.IdRuta

