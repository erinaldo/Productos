
select se.NombreEmpresa as EMPRESA,
left(v.Serie,3) + REPLICATE('0',7-len(v.folio)) + CAST(v.folio as varchar(10)) as FOLIO,
v.IdSucursal AS CLAVECLIENTE,
cs.RazonSocial AS RAZONSOCIAL,
case v.IdTipoVenta when 1 then 'Contado' else 'Crédito' end AS CONDICION,
cs.RFC AS RFC,
v.Fecha AS FECHA,
s.IdRuta as VENDEDOR,
p.Producto AS DESCRIPCION,
vd.Cantidad AS CANTIDAD,
vd.precio AS PRECIO,
cs.calleF+' '+cs.numexteriorF+' '+cs.numinteriorF+' '+coloniaF+' '+cs.cpf AS DOMICILIO,
cs.localidadF+' '+cs.poblacionF+' '+cs.entidadF AS CIUDAD,
VD.Subtotal AS IMPORTE,
vd.iva*vd.subtotal AS IMPUESTO,
cl.DiasCredito as 'DIAS CREDITO'
/*, v.*, vd.*, SE.* */
from Ventas v
inner join VentasDetalle vd on v.IdCedis = vd.idcedis and v.IdSurtido = vd.IdSurtido and v.IdTipoVenta = vd.IdTipoVenta and v.Folio = vd.Folio and v.Serie = vd.serie
inner join Productos p on vd.IdProducto = p.IdProducto 
inner join ClienteSucursal cs on v.IdSucursal = cs.IdSucursal
inner join Route.dbo.CLIFormaVenta cl on v.IdSucursal = cl.ClienteClave and cl.CFVTipo = '1'
inner join Surtidos S on s.IdCedis = vd.IdCedis and vd.IdSurtido = s.IdSurtido
inner join Route.dbo.FolioSolicitado fs on v.serie =  fs.Serie COLLATE SQL_Latin1_General_CP1_CI_AS
inner join Route.dbo.FOSHist fh on fh.FolioID = fs.FolioID and fh.FOSId = fs.FOSId 
inner join Route.dbo.SubEmpresa SE on SE.SubEmpresaId = fh.CentroExpID 
where v.Serie not like 'R%'
--order by v.Fecha, fh.CentroExpID, left(v.Serie,3) + REPLICATE('0',7-len(v.folio)) + CAST(v.folio as varchar(10)), vd.Folio

