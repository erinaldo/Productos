USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_Rutas]    Script Date: 03/28/2011 01:30:57 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_Rutas]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_Rutas]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_Rutas]    Script Date: 03/28/2011 01:30:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER OFF
GO


CREATE PROCEDURE [dbo].[up_Rutas]
@IdCedis as bigint,
@IdRuta as bigint,
@Ruta as varchar(100),
@TipoRutas bigint,
@TipoVenta as varchar(20),
@CFD as bit,
@Fecha  as datetime,
@Opc as int
AS

if @Opc = 1
begin
        --set @IdRuta = isnull((Select max(IdRuta) from Rutas where IdCedis = @IdCedis)+1,1)        
        insert into Rutas values (@IdCedis, @IdRuta, @Ruta, @TipoRutas, @TipoVenta, @Fecha, 'A', @CFD)
end

if @Opc = 2
        update Rutas set Ruta=@Ruta, TipoRuta=@TipoRutas, TipoVenta = @TipoVenta, Status = 'A', CFD = @CFD 
        where IdRuta = @IdRuta and IdCedis = @IdCedis


if @Opc = 3
        update Rutas set Status = 'B' where IdRuta = @IdRuta and IdCedis = @IdCedis


GO


