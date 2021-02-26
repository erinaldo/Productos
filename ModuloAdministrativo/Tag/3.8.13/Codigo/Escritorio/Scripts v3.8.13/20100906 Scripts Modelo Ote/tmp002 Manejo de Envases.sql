
select *
from ProductoPrestamoCli as ENV
where ENV.ClienteClave = '030015'

SELECT PRO.ProductoClave, Nombre 
FROM Producto PRO
INNER JOIN ProductoDetalle PRD ON PRO.ProductoClave = PRD.ProductoClave AND PRD.ProductoClave = PRD.ProductoDetClave 
	AND PRD.Factor = 1 and PRO.Contenido = 1
-- WHERE PRO.ProductoClave = @ProductoClave
