
SELECT *
-- DELETE
FROM StatusDia 
WHERE Fecha < '20100501' 

-- VENTAS, VENTASDETALLE, VENTASCONTADO

SELECT *
-- DELETE 
FROM VentasDetalle 
WHERE IdCedis IN (
	SELECT IdCedis 
	FROM Ventas 
	WHERE IdCedis = VentasDetalle.IdCedis AND IdSurtido = VentasDetalle.IdSurtido AND Fecha < '20100501' 
)

SELECT *
-- DELETE
FROM Ventas 
WHERE Fecha < '20100501' 

SELECT *
-- DELETE
FROM VentasContado 
WHERE Fecha < '20100501' 

-- MOVIMIENTOS, MOVIMIENTOSDETALLE

SELECT *
-- DELETE 
FROM MovimientosDetalle  
WHERE IdCedis IN (
	SELECT IdCedis 
	FROM Movimientos  
	WHERE IdCedis = MovimientosDetalle.IdCedis AND IdMovimiento = MovimientosDetalle.IdMovimiento AND Fecha < '20100501' 
)

SELECT *
-- DELETE
FROM Movimientos  
WHERE Fecha < '20100501' 

-- SURTIDOS, SURTIDOSDETALLE, SURTIDOSVENDEDOR, SURTIDOSMERMA, CARGAS, SURTIDOSCARGAS, VendedoresSaldos

SELECT *
-- DELETE 
FROM SurtidosDetalle 
WHERE IdCedis IN (
	SELECT IdCedis 
	FROM Surtidos 
	WHERE IdCedis = SurtidosDetalle.IdCedis AND IdSurtido = SurtidosDetalle.IdSurtido AND Fecha < '20100501' 
)

SELECT *
-- DELETE 
FROM SurtidosVendedor 
WHERE IdCedis IN (
	SELECT IdCedis 
	FROM Surtidos 
	WHERE IdCedis = SurtidosVendedor.IdCedis AND IdSurtido = SurtidosVendedor.IdSurtido AND Fecha < '20100501' 
)

SELECT *
-- DELETE 
FROM SurtidosMerma 
WHERE IdCedis IN (
	SELECT IdCedis 
	FROM Surtidos 
	WHERE IdCedis = SurtidosMerma.IdCedis AND IdSurtido = SurtidosMerma.IdSurtido AND Fecha < '20100501' 
)

SELECT *
-- DELETE 
FROM SurtidosDenominacion 
WHERE IdCedis IN (
	SELECT IdCedis 
	FROM Surtidos 
	WHERE IdCedis = SurtidosDenominacion.IdCedis AND IdSurtido = SurtidosDenominacion.IdSurtido AND Fecha < '20100501' 
)

SELECT *
-- DELETE 
FROM SurtidosCheque 
WHERE IdCedis IN (
	SELECT IdCedis 
	FROM Surtidos 
	WHERE IdCedis = SurtidosCheque.IdCedis AND IdSurtido = SurtidosCheque.IdSurtido AND Fecha < '20100501' 
)

SELECT *
-- DELETE 
FROM SurtidosCargas 
WHERE IdCedis IN (
	SELECT IdCedis 
	FROM Surtidos 
	WHERE IdCedis = SurtidosCargas.IdCedis AND IdSurtido = SurtidosCargas.IdSurtido AND Fecha < '20100501' 
)

SELECT *
-- DELETE 
FROM Cargas 
WHERE IdCedis IN (
	SELECT IdCedis 
	FROM Surtidos 
	WHERE IdCedis = Cargas.IdCedis AND IdSurtido = Cargas.IdSurtido AND Fecha < '20100501' 
)

SELECT *
-- DELETE 
FROM VendedoresSaldos
WHERE IdCedis IN (
	SELECT IdCedis 
	FROM Surtidos 
	WHERE IdCedis = VendedoresSaldos.IdCedis AND IdSurtido = VendedoresSaldos.IdSurtido AND Fecha < '20100501' 
)

SELECT *
-- DELETE
FROM Surtidos 
WHERE Fecha < '20100501' 

-- ***** CARGASSUGERIDAS, statusrutas *****

SELECT *
-- DELETE
FROM CargasSugeridasDetalle 
WHERE FechaCarga < '20100501' 

SELECT *
-- DELETE
FROM StatusRutas 
WHERE Fecha < '20100501' 

-- ***** INVENTARIOS *****

SELECT *
-- DELETE
FROM InventarioInicial 
WHERE Mes <= 4 AND Agno = 2010

SELECT *
-- DELETE
FROM InventarioFisico 
WHERE Fecha < '20100501' 

SELECT *
-- DELETE
FROM InventarioKardex 
WHERE Fecha < '20100501' 
