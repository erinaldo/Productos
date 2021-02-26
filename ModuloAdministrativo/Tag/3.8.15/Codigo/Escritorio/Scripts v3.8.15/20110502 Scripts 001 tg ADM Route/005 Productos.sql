USE [RouteADM]
GO

/****** Object:  Trigger [tgRouteU_Productos]    Script Date: 05/02/2011 12:47:03 ******/
IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[tgRouteU_Productos]'))
DROP TRIGGER [dbo].[tgRouteU_Productos]
GO

USE [RouteADM]
GO

/****** Object:  Trigger [dbo].[tgRouteU_Productos]    Script Date: 05/02/2011 12:47:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE TRIGGER [dbo].[tgRouteU_Productos] ON [dbo].[Productos] 
FOR INSERT, UPDATE
AS
declare @Route as int
set @Route = 0

set @Route = isnull( ( select Route from Configuracion where IdCedis in ( select IdCedis from Inserted ) ), 0 )

if @Route = 1
begin

	insert into ROUTE.dbo.Producto (ProductoClave, Nombre, NombreLargo, Id, Tipo, SubEmpresaID, CodigoBarras, LimiteDescuento, TipoFase, Contenido, Venta, DecimalProducto, CantidadProduccion, UnidadProduccion, MFechaHora, MUsuarioID) 
		select IdProducto, left( Producto, 32 ), left( Producto, 64 ), IdProducto, 1, 1, CodBarras, 0, 1, 0, 0, case Decimales when 1 then 2 else 0 end, 0, 0, getdate(), 'Interfaz' 
		from Inserted where IdProducto not in ( select ProductoClave from ROUTE.dbo.Producto )

	
	update ROUTE.dbo.Producto set Nombre = left( (select Producto from Inserted where ProductoClave = IdProducto ), 32 ), NombreLargo = left( ( select Producto from Inserted where ProductoClave = IdProducto), 64 ), 
		CodigoBarras = left( (select CodBarras from Inserted where ProductoClave = IdProducto ), 32 ),
		DecimalProducto = (select case Decimales when 1 then 2 else 0 end from Inserted where ProductoClave = IdProducto ),
		SubEmpresaID = '1', MFechaHora = getdate()
	where ProductoClave in ( select IdProducto from Inserted where ProductoClave = IdProducto )

	update ROUTE.dbo.Producto set TipoFase = 0 where ProductoClave in ( select IdProducto from Inserted where Status <> 'A' )
	update ROUTE.dbo.Producto set TipoFase = 1 where ProductoClave in ( select IdProducto from Inserted where Status = 'A' )

	insert into ROUTE.dbo.ProductoUnidad select IdProducto, 1, Conversion, 1, getdate(), 'Interfaz' from Inserted where IdProducto not in ( select ProductoClave from ROUTE.dbo.ProductoUnidad where PruTipoUnidad = 1 ) 
	--insert into ROUTE.dbo.ProductoUnidad select IdProducto, 5, 1, 1, getdate(), 'Interfaz' from Inserted where Decimales = 1 and IdProducto not in ( select ProductoClave from ROUTE.dbo.ProductoUnidad where PruTipoUnidad = 5 )
	--insert into ROUTE.dbo.ProductoUnidad select IdProducto, 7, .001, 1, getdate(), 'Interfaz' from Inserted where Decimales = 1 and IdProducto not in ( select ProductoClave from ROUTE.dbo.ProductoUnidad where PruTipoUnidad = 7 )
	
	delete from  ROUTE.dbo.ProductoDetalle where ltrim( rtrim( ProductoClave )) in ( select IdProducto from Inserted )
	insert into ROUTE.dbo.ProductoDetalle select IdProducto, 1, IdProducto, 0, 1, getdate(), 'Interfaz' from Inserted --where Decimales = 0
	--insert into ROUTE.dbo.ProductoDetalle select IdProducto, 5, IdProducto, 0, 1000, getdate(), 'Interfaz' from Inserted where Decimales = 1
	--insert into ROUTE.dbo.ProductoDetalle select IdProducto, 7, IdProducto, 0, 1, getdate(), 'Interfaz' from Inserted where Decimales = 1
	
	--delete from ROUTE.dbo.ProductoImpuesto where ProductoClave in ( select IdProducto from Inserted where ProductoClave = IdProducto ) 
	--insert into ROUTE.dbo.ProductoImpuesto select IdProducto, 'IVA', 1, getdate(), 'Interfaz' from Inserted where Iva > 0
	--insert into ROUTE.dbo.ProductoImpuesto select IdProducto, 'IVA0', 1, getdate(), 'Interfaz' from Inserted where Iva = 0
	
	delete from ROUTE.dbo.ProductoEsquema where ProductoClave in ( select IdProducto from Inserted where ProductoClave = IdProducto )
	insert into ROUTE.dbo.Esquema select 'M' + cast(IdMarca as varchar(10)), 'PRO', left(Marca, 32), left( Marca, 16), 0, 'M' + cast(IdMarca as varchar(10)), 2, 1, 0, 1, getdate(), 'Interfaz' 
		from Marcas where IdMarca in ( select distinct IdMarca from Inserted ) and 'M' + cast(IdMarca as varchar(10)) not in ( select EsquemaId from ROUTE.dbo.Esquema )
	insert into ROUTE.dbo.ProductoEsquema select IdProducto, 'M' + cast(IdMarca as varchar(10)), getdate(), 'Interfaz' from Inserted

	insert into ROUTE.dbo.Esquema select 'G' + cast(IdGrupo as varchar(10)), 'M' + cast(IdMarca as varchar(10)), left(Grupo, 32), left( Grupo, 16), 0, 'G' + cast(IdGrupo as varchar(10)), 2, 1, 0, 2, getdate(), 'Interfaz' 
		from Grupos where IdGrupo in ( select distinct IdGrupo from Inserted ) and 'G' + cast(IdGrupo as varchar(10)) not in ( select EsquemaId from ROUTE.dbo.Esquema )
	insert into ROUTE.dbo.ProductoEsquema select IdProducto, 'G' + cast(IdGrupo as varchar(10)), getdate(), 'Interfaz' from Inserted

	insert into ROUTE.dbo.Esquema select 'F' + cast(IdFamilia as varchar(10)), 'G' + cast(IdGrupo as varchar(10)), left(Familia, 32), left( Familia, 16), 0, 'F' + cast(IdFamilia as varchar(10)), 2, 1, 0, 3, getdate(), 'Interfaz' 
		from Familias where IdFamilia in ( select distinct IdFamilia from Inserted ) and 'F' + cast(IdFamilia as varchar(10)) not in ( select EsquemaId from ROUTE.dbo.Esquema )
	insert into ROUTE.dbo.ProductoEsquema select IdProducto, 'F' + cast(IdFamilia as varchar(10)), getdate(), 'Interfaz' from Inserted

	insert into ROUTE.dbo.Esquema select 'S' + cast(IdSubFamilia as varchar(10)), 'F' + cast(Familia as varchar(10)), left(SubFamilia, 32), left( SubFamilia, 16), 0, 'S' + cast(IdSubFamilia as varchar(10)), 2, 1, 0, 4, getdate(), 'Interfaz' 
		from SubFamilias where IdSubFamilia in ( select distinct IdSubFamilia from Inserted ) and 'S' + cast(IdSubFamilia as varchar(10)) not in ( select EsquemaId from ROUTE.dbo.Esquema )
	insert into ROUTE.dbo.ProductoEsquema select IdProducto, 'S' + cast(IdSubFamilia as varchar(10)), getdate(), 'Interfaz' from Inserted where IdSubFamilia in (select IdSubFamilia from SubFamilias )

	insert into ROUTE.dbo.Esquema select 'P' + cast(IdPresentacion as varchar(10)), 'PRO', left(Presentacion, 32), left( Presentacion, 16), 0,  'P' + cast(IdPresentacion as varchar(10)),  2, 1, 0, 1, getdate(), 'Interfaz' 
		from Presentacion where IdPresentacion in ( select distinct IdPresentacion from Inserted ) and 'P' + cast(IdPresentacion as varchar(10)) not in ( select EsquemaId from ROUTE.dbo.Esquema )
	insert into ROUTE.dbo.ProductoEsquema select IdProducto, 'P' + cast(IdPresentacion as varchar(10)), getdate(), 'Interfaz' from Inserted where IdPresentacion in (select IdPresentacion from Presentacion )

end


GO


