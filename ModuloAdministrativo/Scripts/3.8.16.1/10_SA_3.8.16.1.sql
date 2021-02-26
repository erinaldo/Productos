USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_ExisteRuta]    Script Date: 07/27/2011 08:28:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_ExisteRuta]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_ExisteRuta]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_ExisteRuta]    Script Date: 07/27/2011 08:28:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[sel_ExisteRuta]
@IdCedis as bigint,
@IdRuta as bigint/*,
@Fecha as datetime,
@Inserta as char(1)*/
AS

/*declare 
@IdSurtido as bigint

set @IdSurtido = isnull(( select IdSurtido from surtidos where IdCedis = @IdCedis and Fecha = @Fecha and IdRuta = @IdRuta ), 0 )

if @IdSurtido = 0 --and @Inserta='1'
begin
	set @IdSurtido = isnull (( select max(IdSurtido) from surtidos where IdCedis = @IdCedis )+1,1)
	insert into Surtidos values (@IdCedis, @IdSurtido, @Fecha, @IdRuta, 'P')
	insert into SurtidosVendedor 
	select @IdCedis, @IdSurtido, @Fecha, IdVendedor, IdTipoVendedor from VendedoresRutas where IdCedis = @IdCedis and IdRuta = @IdRuta
end

*/
select IdCedis, IdRuta, Ruta, TipoRuta, TipoVenta
from Rutas 
where IdCedis = @IdCedis and IdRuta = @IdRuta




GO



USE [Route]
GO

if (Select COUNT(*) from VersionBD where Tipo = 'SA' and Version ='3.8.16.1') = 0
BEGIN
	INSERT INTO VersionBD (Tipo, FechaHora, Version, MaximoConsecutivo, VersionSql ) 
	VALUES('SA', GETDATE(), '3.8.16.1', 10,(SELECT  cast(SERVERPROPERTY('productversion') as varchar(50))))
END
ELSE
BEGIN 
	Update VersionBD  set MaximoConsecutivo = 10 where  Tipo = 'SA' and Version ='3.8.16.1'
END
GO