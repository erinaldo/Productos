USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_Sucursales]    Script Date: 06/22/2011 10:06:41 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_Sucursales]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_Sucursales]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_Sucursales]    Script Date: 06/22/2011 10:06:41 ******/
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
@CRTienda as varchar(5),
@Opc as int
AS

if @Opc = 1
begin
	insert into ClienteSucursal values (@IdCedis, @IdCliente, @IdSucursal, @TDA_GLN, @NombreSucursal, 
	@Calle, @NumExterior, @NumInterior, @Colonia, @Localidad, @Poblacion, @Entidad, @Pais, @Telefonos, @CP, 
	@RFC, @RazonSocial, 
	@CalleF, @NumExteriorF, @NumInteriorF, @ColoniaF, @LocalidadF, @PoblacionF, @EntidadF, @PaisF, @TelefonosF, @CPF, 
	@CodigoBarras, @FormaVenta, @Status, @Contacto, @DiasCredito, @LimiteCredito, @CRTienda)
end

if @Opc = 2
begin
	update 	ClienteSucursal 
	set TDA_GLN = @TDA_GLN, NombreSucursal = @NombreSucursal, 
		Calle = @Calle, NumExterior = @NumExterior, numInterior = @NumInterior, Colonia = @Colonia, Localidad = @Localidad, Poblacion = @Poblacion, Entidad = @Entidad, Pais = @Pais, Telefonos = @Telefonos, CP = @CP, 
		CalleF = @CalleF, NumExteriorF = @NumExteriorF, numInteriorF = @NumInteriorF, ColoniaF = @ColoniaF, LocalidadF = @LocalidadF, PoblacionF = @PoblacionF, EntidadF = @EntidadF, PaisF = @PaisF, TelefonosF = @TelefonosF, CPF = @CPF, 
		RFC = @RFC, RazonSocial = @RazonSocial, CodigoBarras = @codigoBarras, FormaVenta = @FormaVenta, Status = @Status, Contacto = @Contacto,
		DiasCredito = @DiasCredito, LimiteCredito = @LimiteCredito, CRTienda = @CRTienda
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


