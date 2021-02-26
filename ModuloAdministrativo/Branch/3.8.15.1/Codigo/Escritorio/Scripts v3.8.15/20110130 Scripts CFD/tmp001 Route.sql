
select Matriz.NumCertificado, Matriz.RFC, Matriz.Calle, Matriz.NumExt, Matriz.NumInt, Matriz.Colonia, Matriz.CodigoPostal,
Matriz.ReferenciaDom, Matriz.Localidad, Matriz.Municipio, Matriz.Entidad, Matriz.Pais,
Sucursal.NumCertificado, Sucursal.RFC, Sucursal.Calle, Sucursal.NumExt, Sucursal.NumInt, Sucursal.Colonia, Sucursal.CodigoPostal,
Sucursal.ReferenciaDom, Sucursal.Localidad, Sucursal.Municipio, Sucursal.Entidad, Sucursal.Pais
from Route.dbo.CentroExpedicion as Matriz 
inner join Route.dbo.CentroExpedicion as Sucursal on Sucursal.CentroExpPadreID = Matriz.CentroExpID and Sucursal.TipoEstado = 1
	and Sucursal.Tipo = 1 and Matriz.SubEmpresaId = Sucursal.SubEmpresaId 
where Matriz.CentroExpPadreID is null and Matriz.TipoEstado = 1 and Matriz.Tipo = 0

execute sel_DatosCFD 2, 5132, 2, 15261, 2
execute sel_DatosCFD 2, 5132, 2, 1, 4

select *
from Ventas where IdSurtido = 5132

select *
from VentasDetalle  where IdSurtido = 5132

/*
update Route.dbo.FolioSolicitado set Usados = 0
update ventas set serie = 'REM', folio = 15261 where idsurtido = 5132 and serie = 'TJ' and folio = 1
update ventasdetalle set serie = 'REM', folio = 15261 where idsurtido = 5132 and serie = 'TJ' and folio = 1
*/

select *
from Route.dbo.FolioSolicitado   FolS, Route.dbo.FOSHist FosH 
where FosH.FolioID = FolS.FolioID and FosH.FOSId = FosH.FOSId 
and FosH.VendedorID = CAST(2 as varchar(10)) + REPLICATE('0', 4-len(82)) + CAST(82 as varchar(4))

--execute sel_DatosCFD 2, 5132, 2, 15261, 2

select * from Route.dbo.SEMHist    

--execute up_VentasFactura 2, 5132, 2, 15261, 'REM', 1, 'TJ', 1

--select *
--from Route.dbo.Vendedor 
  
  
--execute up_VentasFactura 2, 5132, 2, 15261, 'REM', 1, 'TJ', 1


declare @IdCedis as bigint,
@IdSurtido as bigint,
@IdTipoVenta as int,
@Folio as bigint,
@Opc as int,
@IdRuta as bigint

set @IdCedis = 2
set @IdSurtido = 5132
set @IdTipoVenta = 2
set @Folio = 15261
set @Opc = 2
set @IdRuta = 82

	select @IdRuta = isnull(Surtidos.IdRuta,0) 
	from Surtidos 
	inner join Rutas on Rutas.IdCedis = Surtidos.IdCedis and Rutas.IdRuta = Surtidos.IdRuta and CFD = 1
	where Surtidos.IdCedis = @IdCedis and Surtidos.IdSurtido = @IdSurtido 

	select DirRepMensual, DirDocXML, DirArchivosFacElec, ContrasenaClave 
	from Route.dbo.SEMHist SemHist
	inner join Route.dbo.SubEmpresa SubE on SubE.SubEmpresaId = SemHist.SubEmpresaId 
	inner join Route.dbo.Folio Folio on SubE.SubEmpresaId = Folio.SubEmpresaId
	inner join Route.dbo.FolioSolicitado FolS on Folio.FolioID = FolS.FolioID 
	inner join Route.dbo.FOSHist FosH on FosH.FolioID = FolS.FolioID and FosH.FOSId = FosH.FOSId 
	where SubE.TipoEstado = 1 and FosH.VendedorID = CAST(@IdCedis as varchar(10)) + REPLICATE('0', 4-len(@IdRuta)) + CAST(@IdRuta as varchar(4))
		and SemHist.DirArchivosFacElec <> ''


--update ClienteSucursal set CPF = '0' where CPF = ''

--update ClienteSucursal set CPF = '' where CPF = '0'
