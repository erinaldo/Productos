USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_Productos]    Script Date: 08/04/2011 11:14:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_Productos]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_Productos]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_Productos]    Script Date: 08/04/2011 11:14:12 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO




CREATE PROCEDURE [dbo].[up_Productos]
@Cve bigint,
@CodBarr as varchar(30),
@Producto as varchar(200),
@IVA  as float,--(20),
@Conv as float,--(20),
@Marca int,
@Grupo as int,
@Familia as int,
@SubFamilia as int,
@Presentacion as int,
@Fecha  as datetime,
@Decimales as int,
@Opc as int
AS

if @Opc = 1
begin
	declare @IdCedis as bigint, @FechaMov as datetime
	select @IdCedis = IdCedis from Configuracion 
	select @FechaMov = Fecha from StatusDia where Status = 'C' and IdCedis = @IdCedis order by Fecha desc
	
		if not exists(select * from InventarioInicial where IdCedis = @IdCedis and IdProducto = @Cve and Mes = MONTH(@FechaMov) and Agno = YEAR(@FechaMov) )
			insert into InventarioInicial values (@IdCedis, YEAR(@FechaMov), MONTH(@FechaMov), @Cve, 0, 'A', 'N')

		if not exists(select * from InventarioKardex where IdCedis = @IdCedis and IdProducto = @Cve and Fecha = @FechaMov )
			insert into InventarioKardex values (@IdCedis, @FechaMov, @Cve, 0, 0,0,0, 0,0,0, 0,0,0)

	select @FechaMov = Fecha from StatusDia where Status = 'A' and IdCedis = @IdCedis order by Fecha desc
		if not exists(select * from InventarioKardex where IdCedis = @IdCedis and IdProducto = @Cve and Fecha = @FechaMov )
			insert into InventarioKardex values (@IdCedis, @FechaMov, @Cve, 0, 0,0,0, 0,0,0, 0,0,0)

        insert into Productos values (@Cve, @CodBarr, @Producto, @IVA, @Conv, @Marca, @Grupo, @Familia, @SubFamilia,  @Presentacion, @Fecha, 'A', @Decimales)
end

if @Opc = 2
        update Productos set Producto = @Producto, codbarras =@CodBarr , Iva=@IVA, Conversion=@Conv, IdMarca=@Marca, IdGrupo=@Grupo, IdFamilia=@Familia, IdSubFamilia=@SubFamilia,  idpresentacion=@Presentacion, decimales = @Decimales,  Status = 'A' where IdProducto = @Cve


if @Opc = 3
        update Productos set Status = 'B' where IdProducto = @Cve


GO


