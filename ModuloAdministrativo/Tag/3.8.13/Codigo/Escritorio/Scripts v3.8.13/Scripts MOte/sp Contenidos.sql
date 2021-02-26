select *
from producto p
inner join productodetalle pd
on p.productoclave=pd.productoclave AND p.productoclave<>pd.productodetclave

select *
from producto p

select *
from productodetalle pd


select t.folio as FolioCarga,P.PRODUCTOCLAVE as Liquido, td.cantidad * (select factor from productodetalle where productoclave=p.productoclave and productodetclave=p.productoclave and prutipounidad=pd.prutipounidad) as CantidadLiquido, 
pd.productodetclave as Contenido, td.cantidad * pd.factor as CantidadContenido, (select DBO.FNObtenerValorReferencia ('UNIDADV',pd.prutipounidad)) as Unidad, p.venta as PermiteVenta, pd.prestamo as PermitePrestamo 
from transprod t
inner join transproddetalle td 
on t.transprodid=td.transprodid
inner join producto p
on td.productoclave=p.productoclave 
inner join productodetalle pd
on p.productoclave=pd.productoclave AND p.productoclave<>pd.productodetclave AND td.tipounidad=pd.prutipounidad
where t.tipo=2 and t.tipofase<>0
