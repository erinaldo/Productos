USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_ComEsquemaMarcas]    Script Date: 08/18/2011 20:33:11 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_ComEsquemaMarcas]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_ComEsquemaMarcas]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_ComEsquemaMarcas]    Script Date: 08/18/2011 20:33:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[sel_ComEsquemaMarcas]
@IdCedis as bigint,
@IdComEsquema as bigint,
@IdMarca as bigint,
@IdTipoVendedor bigint,
@IdConceptoPago smallint,
@Opc as int

AS
--Opcion para obtener la información que llena el tab de Definición de pagos de las comisiones 
if @Opc = 1
begin 
	
	DECLARE @sMarca varchar(5000)
	if @IdMarca <> 0 set @sMarca = ' and ComEsquemaMarca.IdMarca = ' + + CAST( @IdMarca as varchar(10)) 
	else set @sMarca = ''

	DECLARE @sTipoVendedor varchar(5000)
	if @IdTipoVendedor <> 0 set @sTipoVendedor = ' and TipoVendedor.IdTipoVendedor = ' + @IdTipoVendedor 
	else set @sTipoVendedor = ''

	DECLARE @sConceptoPago varchar(5000)
	if @IdConceptoPago <> 0 set @sConceptoPago = ' and ComEsquemaRangos.IdConceptoPago = ' + cast(@IdConceptoPago as varchar(10)) 
	else set @sConceptoPago = ''

		exec(  'select Marcas.IdMarca, Marcas.Marca as ''Marca de producto'', 
		case IdConceptoPago
			when ''1'' then ( select Etiqueta01 from Configuracion where IdCedis = ' + @IdCedis + ')
			when ''2'' then ( select Etiqueta02 from Configuracion where IdCedis = ' + @IdCedis + ')
			when ''3'' then ''Importe de Venta''
		end as ''Concepto Pago'', ComEsquemaRangos.Inicial, ComEsquemaRangos.Final,
		case ComEsquemaMarca.Status 
			when ''A'' then ''Activo''
			when ''B'' then ''Baja''
		end as ''Status'', ComEsquemaMarca.Fecha as ''Fecha de Modificación'', ComEsquemaMarca.Usuario, ComEsquemaRangos.IdComEsquema, ComEsquemaRangos.IdConceptoPago
		from ComEsquemaMarca
		inner join Marcas on Marcas.IdMarca = ComEsquemaMarca.IdMarca
		inner join ComEsquemaRangos on ComEsquemaRangos.IdComEsquema = ComEsquemaMarca.IdComEsquema and ComEsquemaRangos.IdMarca = ComEsquemaMarca.IdMarca and ComEsquemaRangos.Status = ''A'' ' + @sConceptoPago + ' 
		where ComEsquemaMarca.IdComEsquema = ' + @IdComEsquema + ' ' + @sMarca + '   
		order by Marcas.Marca, ComEsquemaRangos.Inicial')
end
--Opcion para llenar el combo de Marcas en comisiones.
if @Opc = 2
	select Marcas.IdMarca, Marcas.Marca 
	from Marcas
	order by Marcas.Marca 

if @Opc = 3
	select top 1 IdConceptoPago
	from ComEsquemaRangos 
	where ComEsquemaRangos.IdComEsquema = @IdComEsquema and Status = 'A'
	order by IdConceptoPago

if @Opc = 4
	select top 1 IdCedis as 'IdCedis'
	from ComEsquemaCedis 
	where ComEsquemaCedis.IdComEsquema = @IdComEsquema and Status = 'A'

GO

USE [Route] 
GO

if (Select COUNT(*) from VersionBD where Tipo = 'SA' and Version ='3.8.16.1') = 0
BEGIN
	INSERT INTO VersionBD (Tipo, FechaHora, Version, MaximoConsecutivo, VersionSql ) 
	VALUES('SA', GETDATE(), '3.8.16.1', 80, (SELECT  cast(SERVERPROPERTY('productversion') as varchar(50))))
END
ELSE
BEGIN 
	Update VersionBD  set MaximoConsecutivo = 80 where  Tipo = 'SA' and Version ='3.8.16.1'
END
GO




