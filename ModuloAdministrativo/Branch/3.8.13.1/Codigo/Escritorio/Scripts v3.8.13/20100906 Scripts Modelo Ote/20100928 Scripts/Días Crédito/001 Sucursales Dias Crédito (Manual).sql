use RouteADM 

alter table ClienteSucursal
add DiasCredito int null
GO

alter table ClienteSucursal
add LimiteCredito money null
GO

--- DESHABILITAR TG DE CLIENTESUCURSAL ----

update ClienteSucursal set DiasCredito = Cliente.DiasVencimiento, LimiteCredito = Cliente.LimiteCreditoDinero 
from Route.dbo.Cliente Cliente 
where ClienteSucursal.IdSucursal = Cliente.ClienteClave and ClienteSucursal.IdCedis = cast(substring(Cliente.ClienteClave,1,2) as int) and isnumeric(substring(Cliente.ClienteClave,1,2))=1

update ClienteSucursal set DiasCredito = 0 where DiasCredito is null
update ClienteSucursal set LimiteCredito = 0 where LimiteCredito is null

--- HABILITAR TG DE CLIENTESUCURSAL ----

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_Sucursales]    Script Date: 09/20/2010 10:37:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_Sucursales]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_Sucursales]
GO

/****** Object:  StoredProcedure [dbo].[up_Sucursales]    Script Date: 09/20/2010 10:37:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_Sucursales]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_Sucursales]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_Sucursales]    Script Date: 09/20/2010 10:37:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sel_Sucursales]

@IdCedis as bigint,
@IdCliente as bigint,
@IdSucursal as varchar(16),
@IdRuta as bigint,
@Opc as int

AS

if @Opc = 1 		-- sucursales para un solo cliente
Begin
	SELECT     SUC.IdCedis, CTE.RazonSocial AS cliente, SUC.IdCliente, SUC.IdSucursal, isnull(SUC.TDA_GLN,'') AS [TDA/GLN], 
		isnull(SUC.NombreSucursal,'') AS Sucursal, isnull(SUC.Status,'B') as Status,
--		case SUC.Status
--			when 'A' then 'Activo'
--			when 'B' then 'Baja'
--			when 'S' then 'Suspendido'
--			when null then 'Baja'
--		end as Status, 
		isnull(SUC.FormaVenta,'') as [Forma de Venta],
		isnull(SUC.CodigoBarras,'') as [Código de Barras], isnull(SUC.Calle,'') as Calle, isnull(SUC.NumExterior,'') AS [No. Ext],
            		isnull(SUC.NumInterior,'') AS [No. Int], isnull(SUC.Colonia,'') as Colonia, isnull(SUC.Localidad,'') as [Localidad], isnull(SUC.Poblacion,'') as Poblacion, 
		isnull(SUC.Entidad,'') as Entidad, isnull(SUC.Pais,'') as [País], isnull(SUC.Telefonos,'') AS Teléfonos, isnull(SUC.CP,'') AS 'C.P.', 
		isnull(SUC.RFC,'') AS [RFC], isnull(SUC.RazonSocial,'') AS [Razón Social],
		isnull(SUC.CalleF,'') as CalleF, isnull(SUC.NumExteriorF,'') AS [No. ExtF],
            		isnull(SUC.NumInteriorF,'') AS [No. IntF], isnull(SUC.ColoniaF,'') as ColoniaF, isnull(SUC.LocalidadF,'') as [LocalidadF], isnull(SUC.PoblacionF,'') as PoblacionF, 
		isnull(SUC.EntidadF,'') as EntidadF, isnull(SUC.PaisF,'') as [PaísF], isnull(SUC.TelefonosF,'') AS TeléfonosF, isnull(SUC.CPF,'') AS 'C.P.F', SUC.Contacto,
		ISNULL(SUC.DiasCredito, 0) as 'Dias Crédito', ISNULL(SUC.LimiteCredito, 0) as 'Crédito'
	FROM         Clientes CTE INNER JOIN
	                      ClienteSucursal SUC ON CTE.IdCedis = SUC.IdCedis AND CTE.IdCliente = SUC.IdCliente
	WHERE     (CTE.IdCliente = @IdCliente) AND CTE.IdCedis = @IdCedis
	ORDER BY SUC.NombreSucursal
End

if @Opc = 2 		-- sucursales para un solo cliente
Begin
	SELECT     SUC.IdCedis, CTE.RazonSocial AS cliente, SUC.IdCliente, SUC.IdSucursal, isnull(SUC.TDA_GLN,'') AS [TDA/GLN], 
		isnull(SUC.NombreSucursal,'') AS Sucursal,
		case SUC.Status
			when 'A' then 'Activo'
			when 'B' then 'Baja'
			when 'S' then 'Suspendido'
			when null then 'Baja'
		end as Status, 
		case SUC.FormaVenta
			when 1 then 'Contado'
			when 2 then 'Crédito' 
		end as [Forma de Venta],
		isnull(SUC.CodigoBarras,'') as [Código de Barras], isnull(SUC.Calle,'') as Calle, isnull(SUC.NumExterior,'') AS [No. Ext],
            		isnull(SUC.NumInterior,'') AS [No. Int], isnull(SUC.Colonia,'') as Colonia, isnull(SUC.Localidad,'') as [Localidad], isnull(SUC.Poblacion,'') as Poblacion, 
		isnull(SUC.Entidad,'') as Entidad, isnull(SUC.Pais,'') as [País], isnull(SUC.Telefonos,'') AS Teléfonos, isnull(SUC.CP,'') AS 'C.P.', 
		isnull(SUC.RFC,'') AS [RFC], isnull(SUC.RazonSocial,'') AS [Razón Social],
		isnull(SUC.CalleF,'') as CalleF, isnull(SUC.NumExteriorF,'') AS [No. ExtF],
            		isnull(SUC.NumInteriorF,'') AS [No. IntF], isnull(SUC.ColoniaF,'') as ColoniaF, isnull(SUC.LocalidadF,'') as [LocalidadF], isnull(SUC.PoblacionF,'') as PoblacionF, 
		isnull(SUC.EntidadF,'') as EntidadF, isnull(SUC.PaisF,'') as [PaísF], isnull(SUC.TelefonosF,'') AS TeléfonosF, isnull(SUC.CPF,'') AS 'C.P.F', SUC.Contacto,
		ISNULL(SUC.DiasCredito, 0) as 'Dias Crédito', ISNULL(SUC.LimiteCredito, 0) as 'Crédito'
	FROM         Clientes CTE INNER JOIN
	                      ClienteSucursal SUC ON CTE.IdCedis = SUC.IdCedis AND CTE.IdCliente = SUC.IdCliente
	WHERE     (CTE.IdCliente = @IdCliente) AND CTE.IdCedis = @IdCedis
	ORDER BY SUC.NombreSucursal
End

IF @Opc = 3
begin
	select replicate ('0', 2-len(@IdCedis)) + cast(@IdCedis as varchar(2)) 
		+ replicate ('0', 3-len(@IdRuta)) + cast(@IdRuta as varchar(3)) 
		+ replicate ('0', 4-len(isnull(max(cast(right(IdSucursal,4) as int)) + 1, 1) )) + cast( isnull(max(cast(right(IdSucursal,4) as int)) + 1, 1) as varchar(10))
	from ClienteSucursal
	where IdCedis = @IdCedis and cast( substring(IdSucursal,3,3) as int) = @IdRuta
end 



GO

/****** Object:  StoredProcedure [dbo].[up_Sucursales]    Script Date: 09/20/2010 10:37:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[up_Sucursales]
@IdCedis as bigint,
@IdRuta as int,
@IdCliente as bigint,
@IdSucursal as varchar(16),
@TDA_GLN as varchar(20),
@NombreSucursal as varchar(75),
@Calle as varchar(250),
@NumExterior as varchar(20),
@NumInterior as varchar(20),
@Colonia as varchar(100),
@Localidad as varchar(100),
@Poblacion as varchar(100),
@Entidad as varchar(100),
@Pais as varchar(100),
@Telefonos as varchar(100),
@CP as varchar(7),
@RFC as varchar(20),
@RazonSocial as varchar(200),
@CalleF as varchar(250),
@NumExteriorF as varchar(20),
@NumInteriorF as varchar(20),
@ColoniaF as varchar(100),
@LocalidadF as varchar(100),
@PoblacionF as varchar(100),
@EntidadF as varchar(100),
@PaisF as varchar(100),
@TelefonosF as varchar(100),
@CPF as varchar(7),
@CodigoBarras as varchar(50),
@FormaVenta as varchar(1),
@Status as varchar(1),
@IdClienteNuevo as bigint,
@Contacto as varchar(64),
@DiasCredito as int,
@LimiteCredito as money,
@Opc as int
AS

if @Opc = 1
begin
	
	--set @IdSucursal = (select isnull(max(IdSucursal),0)+1 as MaxIdsucursal from ClienteSucursal where IdCedis = @IdCedis and IdCliente = @IdCliente and IdCliente <> IdSucursal )
	
	--declare @SiguienteSucursal as int

	--set @SiguienteSucursal = (	SELECT     isnull(max(CAST(SUBSTRING(IdSucursal, 6, 4) AS int)),0) +1 AS Secuencia
	--				FROM         ClienteSucursal
	--				WHERE      (IdCedis = @IdCedis) AND (LEN(IdSucursal) = 9) AND 
	--					(CAST(SUBSTRING(IdSucursal, 3, 3) AS int) = @IdRuta) and 
	--					(CAST(SUBSTRING(IdSucursal, 6, 4) AS int) <> '999'))
	--set @IdSucursal = 	replicate('0', 2 - len(cast(@IdCedis as varchar(2)))) + cast(@IdCedis as varchar(2)) + 
	--			replicate('0', 3 - len(cast(@IdRuta as varchar(3)))) + cast(@IdRuta as varchar(3)) + 
	--			replicate('0', 4 - len(cast(@SiguienteSucursal as varchar(4)))) + cast(@SiguienteSucursal as varchar(3))

        	--Select @IdCedis, @IdCliente, @IdSucursal, @TDA_GLN, @NombreSucursal, @Calle, 
	--	@NumExterior, @NumInterior, @Colonia, @CP, @Ciudad, @Estado, @Telefonos, @RFCSucursal, @RazonSocial, @CodigoBarras, @FormaVenta, @Status

        	insert into ClienteSucursal values (@IdCedis, @IdCliente, @IdSucursal, @TDA_GLN, @NombreSucursal, 
		@Calle, @NumExterior, @NumInterior, @Colonia, @Localidad, @Poblacion, @Entidad, @Pais, @Telefonos, @CP, 
		@RFC, @RazonSocial, 
		@CalleF, @NumExteriorF, @NumInteriorF, @ColoniaF, @LocalidadF, @PoblacionF, @EntidadF, @PaisF, @TelefonosF, @CPF, 
		@CodigoBarras, @FormaVenta, @Status, @Contacto, @DiasCredito, @LimiteCredito)
end

if @Opc = 2
begin
	update 	ClienteSucursal 
	set 	TDA_GLN = @TDA_GLN, NombreSucursal = @NombreSucursal, 
		Calle = @Calle, NumExterior = @NumExterior, numInterior = @NumInterior, Colonia = @Colonia, Localidad = @Localidad, Poblacion = @Poblacion, Entidad = @Entidad, Pais = @Pais, Telefonos = @Telefonos, CP = @CP, 
		CalleF = @CalleF, NumExteriorF = @NumExteriorF, numInteriorF = @NumInteriorF, ColoniaF = @ColoniaF, LocalidadF = @LocalidadF, PoblacionF = @PoblacionF, EntidadF = @EntidadF, PaisF = @PaisF, TelefonosF = @TelefonosF, CPF = @CPF, 
		RFC = @RFC, RazonSocial = @RazonSocial, CodigoBarras = @codigoBarras, FormaVenta = @FormaVenta, Status = @Status, Contacto = @Contacto,
		DiasCredito = @DiasCredito, LimiteCredito = @LimiteCredito
    where 	IdCedis = @IdCedis and IdCliente = @IdCliente and IdSucursal = @IdSucursal
end

if @Opc = 3
begin
    update 	ClienteSucursal 
	set 	Status = 'B' 
	where 	IdCedis = @IdCedis and IdCliente = @IdCliente and IdSucursal = @IdSucursal
end

if @Opc = 4
begin
    update 	ClienteSucursal 
	set 	IdCliente = @IdClienteNuevo
	where 	IdCedis = @IdCedis and IdCliente = @IdCliente and IdSucursal = @IdSucursal
end


GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_Sucursales]    Script Date: 09/20/2010 10:37:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_Sucursales]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_Sucursales]
GO

/****** Object:  StoredProcedure [dbo].[up_Sucursales]    Script Date: 09/20/2010 10:37:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_Sucursales]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_Sucursales]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_Sucursales]    Script Date: 09/20/2010 10:37:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sel_Sucursales]

@IdCedis as bigint,
@IdCliente as bigint,
@IdSucursal as varchar(16),
@IdRuta as bigint,
@Opc as int

AS

if @Opc = 1 		-- sucursales para un solo cliente
Begin
	SELECT     SUC.IdCedis, CTE.RazonSocial AS cliente, SUC.IdCliente, SUC.IdSucursal, isnull(SUC.TDA_GLN,'') AS [TDA/GLN], 
		isnull(SUC.NombreSucursal,'') AS Sucursal, isnull(SUC.Status,'B') as Status,
--		case SUC.Status
--			when 'A' then 'Activo'
--			when 'B' then 'Baja'
--			when 'S' then 'Suspendido'
--			when null then 'Baja'
--		end as Status, 
		isnull(SUC.FormaVenta,'') as [Forma de Venta],
		isnull(SUC.CodigoBarras,'') as [Código de Barras], isnull(SUC.Calle,'') as Calle, isnull(SUC.NumExterior,'') AS [No. Ext],
            		isnull(SUC.NumInterior,'') AS [No. Int], isnull(SUC.Colonia,'') as Colonia, isnull(SUC.Localidad,'') as [Localidad], isnull(SUC.Poblacion,'') as Poblacion, 
		isnull(SUC.Entidad,'') as Entidad, isnull(SUC.Pais,'') as [País], isnull(SUC.Telefonos,'') AS Teléfonos, isnull(SUC.CP,'') AS 'C.P.', 
		isnull(SUC.RFC,'') AS [RFC], isnull(SUC.RazonSocial,'') AS [Razón Social],
		isnull(SUC.CalleF,'') as CalleF, isnull(SUC.NumExteriorF,'') AS [No. ExtF],
            		isnull(SUC.NumInteriorF,'') AS [No. IntF], isnull(SUC.ColoniaF,'') as ColoniaF, isnull(SUC.LocalidadF,'') as [LocalidadF], isnull(SUC.PoblacionF,'') as PoblacionF, 
		isnull(SUC.EntidadF,'') as EntidadF, isnull(SUC.PaisF,'') as [PaísF], isnull(SUC.TelefonosF,'') AS TeléfonosF, isnull(SUC.CPF,'') AS 'C.P.F', SUC.Contacto,
		ISNULL(SUC.DiasCredito, 0) as 'Dias Crédito', ISNULL(SUC.LimiteCredito, 0) as 'Crédito'
	FROM         Clientes CTE INNER JOIN
	                      ClienteSucursal SUC ON CTE.IdCedis = SUC.IdCedis AND CTE.IdCliente = SUC.IdCliente
	WHERE     (CTE.IdCliente = @IdCliente) AND CTE.IdCedis = @IdCedis
	ORDER BY SUC.NombreSucursal
End

if @Opc = 2 		-- sucursales para un solo cliente
Begin
	SELECT     SUC.IdCedis, CTE.RazonSocial AS cliente, SUC.IdCliente, SUC.IdSucursal, isnull(SUC.TDA_GLN,'') AS [TDA/GLN], 
		isnull(SUC.NombreSucursal,'') AS Sucursal,
		case SUC.Status
			when 'A' then 'Activo'
			when 'B' then 'Baja'
			when 'S' then 'Suspendido'
			when null then 'Baja'
		end as Status, 
		case SUC.FormaVenta
			when 1 then 'Contado'
			when 2 then 'Crédito' 
		end as [Forma de Venta],
		isnull(SUC.CodigoBarras,'') as [Código de Barras], isnull(SUC.Calle,'') as Calle, isnull(SUC.NumExterior,'') AS [No. Ext],
            		isnull(SUC.NumInterior,'') AS [No. Int], isnull(SUC.Colonia,'') as Colonia, isnull(SUC.Localidad,'') as [Localidad], isnull(SUC.Poblacion,'') as Poblacion, 
		isnull(SUC.Entidad,'') as Entidad, isnull(SUC.Pais,'') as [País], isnull(SUC.Telefonos,'') AS Teléfonos, isnull(SUC.CP,'') AS 'C.P.', 
		isnull(SUC.RFC,'') AS [RFC], isnull(SUC.RazonSocial,'') AS [Razón Social],
		isnull(SUC.CalleF,'') as CalleF, isnull(SUC.NumExteriorF,'') AS [No. ExtF],
            		isnull(SUC.NumInteriorF,'') AS [No. IntF], isnull(SUC.ColoniaF,'') as ColoniaF, isnull(SUC.LocalidadF,'') as [LocalidadF], isnull(SUC.PoblacionF,'') as PoblacionF, 
		isnull(SUC.EntidadF,'') as EntidadF, isnull(SUC.PaisF,'') as [PaísF], isnull(SUC.TelefonosF,'') AS TeléfonosF, isnull(SUC.CPF,'') AS 'C.P.F', SUC.Contacto,
		ISNULL(SUC.DiasCredito, 0) as 'Dias Crédito', ISNULL(SUC.LimiteCredito, 0) as 'Crédito'
	FROM         Clientes CTE INNER JOIN
	                      ClienteSucursal SUC ON CTE.IdCedis = SUC.IdCedis AND CTE.IdCliente = SUC.IdCliente
	WHERE     (CTE.IdCliente = @IdCliente) AND CTE.IdCedis = @IdCedis
	ORDER BY SUC.NombreSucursal
End

IF @Opc = 3
begin
	select replicate ('0', 2-len(@IdCedis)) + cast(@IdCedis as varchar(2)) 
		+ replicate ('0', 3-len(@IdRuta)) + cast(@IdRuta as varchar(3)) 
		+ replicate ('0', 4-len(isnull(max(cast(right(IdSucursal,4) as int)) + 1, 1) )) + cast( isnull(max(cast(right(IdSucursal,4) as int)) + 1, 1) as varchar(10))
	from ClienteSucursal
	where IdCedis = @IdCedis and cast( substring(IdSucursal,3,3) as int) = @IdRuta
end 



GO

/****** Object:  StoredProcedure [dbo].[up_Sucursales]    Script Date: 09/20/2010 10:37:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[up_Sucursales]
@IdCedis as bigint,
@IdRuta as int,
@IdCliente as bigint,
@IdSucursal as varchar(16),
@TDA_GLN as varchar(20),
@NombreSucursal as varchar(75),
@Calle as varchar(250),
@NumExterior as varchar(20),
@NumInterior as varchar(20),
@Colonia as varchar(100),
@Localidad as varchar(100),
@Poblacion as varchar(100),
@Entidad as varchar(100),
@Pais as varchar(100),
@Telefonos as varchar(100),
@CP as varchar(7),
@RFC as varchar(20),
@RazonSocial as varchar(200),
@CalleF as varchar(250),
@NumExteriorF as varchar(20),
@NumInteriorF as varchar(20),
@ColoniaF as varchar(100),
@LocalidadF as varchar(100),
@PoblacionF as varchar(100),
@EntidadF as varchar(100),
@PaisF as varchar(100),
@TelefonosF as varchar(100),
@CPF as varchar(7),
@CodigoBarras as varchar(50),
@FormaVenta as varchar(1),
@Status as varchar(1),
@IdClienteNuevo as bigint,
@Contacto as varchar(64),
@DiasCredito as int,
@LimiteCredito as money,
@Opc as int
AS

if @Opc = 1
begin
	
	--set @IdSucursal = (select isnull(max(IdSucursal),0)+1 as MaxIdsucursal from ClienteSucursal where IdCedis = @IdCedis and IdCliente = @IdCliente and IdCliente <> IdSucursal )
	
	--declare @SiguienteSucursal as int

	--set @SiguienteSucursal = (	SELECT     isnull(max(CAST(SUBSTRING(IdSucursal, 6, 4) AS int)),0) +1 AS Secuencia
	--				FROM         ClienteSucursal
	--				WHERE      (IdCedis = @IdCedis) AND (LEN(IdSucursal) = 9) AND 
	--					(CAST(SUBSTRING(IdSucursal, 3, 3) AS int) = @IdRuta) and 
	--					(CAST(SUBSTRING(IdSucursal, 6, 4) AS int) <> '999'))
	--set @IdSucursal = 	replicate('0', 2 - len(cast(@IdCedis as varchar(2)))) + cast(@IdCedis as varchar(2)) + 
	--			replicate('0', 3 - len(cast(@IdRuta as varchar(3)))) + cast(@IdRuta as varchar(3)) + 
	--			replicate('0', 4 - len(cast(@SiguienteSucursal as varchar(4)))) + cast(@SiguienteSucursal as varchar(3))

        	--Select @IdCedis, @IdCliente, @IdSucursal, @TDA_GLN, @NombreSucursal, @Calle, 
	--	@NumExterior, @NumInterior, @Colonia, @CP, @Ciudad, @Estado, @Telefonos, @RFCSucursal, @RazonSocial, @CodigoBarras, @FormaVenta, @Status

        	insert into ClienteSucursal values (@IdCedis, @IdCliente, @IdSucursal, @TDA_GLN, @NombreSucursal, 
		@Calle, @NumExterior, @NumInterior, @Colonia, @Localidad, @Poblacion, @Entidad, @Pais, @Telefonos, @CP, 
		@RFC, @RazonSocial, 
		@CalleF, @NumExteriorF, @NumInteriorF, @ColoniaF, @LocalidadF, @PoblacionF, @EntidadF, @PaisF, @TelefonosF, @CPF, 
		@CodigoBarras, @FormaVenta, @Status, @Contacto, @DiasCredito, @LimiteCredito)
end

if @Opc = 2
begin
	update 	ClienteSucursal 
	set 	TDA_GLN = @TDA_GLN, NombreSucursal = @NombreSucursal, 
		Calle = @Calle, NumExterior = @NumExterior, numInterior = @NumInterior, Colonia = @Colonia, Localidad = @Localidad, Poblacion = @Poblacion, Entidad = @Entidad, Pais = @Pais, Telefonos = @Telefonos, CP = @CP, 
		CalleF = @CalleF, NumExteriorF = @NumExteriorF, numInteriorF = @NumInteriorF, ColoniaF = @ColoniaF, LocalidadF = @LocalidadF, PoblacionF = @PoblacionF, EntidadF = @EntidadF, PaisF = @PaisF, TelefonosF = @TelefonosF, CPF = @CPF, 
		RFC = @RFC, RazonSocial = @RazonSocial, CodigoBarras = @codigoBarras, FormaVenta = @FormaVenta, Status = @Status, Contacto = @Contacto,
		DiasCredito = @DiasCredito, LimiteCredito = @LimiteCredito
    where 	IdCedis = @IdCedis and IdCliente = @IdCliente and IdSucursal = @IdSucursal
end

if @Opc = 3
begin
    update 	ClienteSucursal 
	set 	Status = 'B' 
	where 	IdCedis = @IdCedis and IdCliente = @IdCliente and IdSucursal = @IdSucursal
end

if @Opc = 4
begin
    update 	ClienteSucursal 
	set 	IdCliente = @IdClienteNuevo
	where 	IdCedis = @IdCedis and IdCliente = @IdCliente and IdSucursal = @IdSucursal
end


GO

