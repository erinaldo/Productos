USE [Route]
GO

/****** Object:  StoredProcedure [dbo].[sp_importDatoFiscalADM]    Script Date: 06/09/2011 11:21:09 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_importDatoFiscalADM]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_importDatoFiscalADM]
GO

USE [Route]
GO

/****** Object:  StoredProcedure [dbo].[sp_importDatoFiscalADM]    Script Date: 06/09/2011 11:21:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO






-- =============================================
-- Author:		ABRAHAM MEDINA
-- Create date: 06/05/2011
-- Description:	INTERFAZ DE ENTRADA DEL MODULO ADMINISTRATIVO A ROUTE
-- =============================================
CREATE PROCEDURE [dbo].[sp_importDatoFiscalADM] 
	@idCedis int, @idSurtido int, @idTipoVenta int, @Folio int, @Serie as varchar(10), 
	@TransprodId as varchar(16), @TransprodIdFactura as varchar(16), @VendedorId as varchar(16), @TipoNotaCredito as smallint
AS
BEGIN
	SET NOCOUNT ON;

--declare @idCedis int, @idSurtido int, @idTipoVenta int, @Folio int, @Serie as varchar(10), @TransprodId as varchar(16), @TransprodIdFactura as varchar(16), @VendedorId as varchar(16)
--declare @TipoNotaCredito as smallint
--set @idCedis = 1
--set @idSurtido = 2988
--set @idTipoVenta = 2
--set @Folio = 4
--set @Serie = 'TJC'
--set @TransprodId = 'A91EF6B37352603F'
--set @TransprodIdFactura = 'A5E9DB46642442F2'
--set @VendedorId = 'CFDCed1'
--set @TipoNotaCredito = 0

declare @USUID as varchar(20)
declare @OrdenCompra as varchar(20), @ClienteClave as varchar(20)

	
			set @USUID = @VendedorId 

			delete from Route.dbo.TPDImpuesto where TransProdID = @TransprodId  

			DECLARE @IdProducto as BIGINT
			DECLARE @Cantidad AS DECIMAL(19,2)
			DECLARE @Precio AS MONEY
			DECLARE @IvaPor AS FLOAT
			DECLARE @IvaImp AS FLOAT

			DECLARE @CursorVar1 AS CURSOR 
			SET @CursorVar1 = CURSOR SCROLL STATIC  
			FOR
			SELECT IdProducto, Cantidad, Precio, Iva
			FROM RouteADM.dbo.VentasDetalle 
			WHERE IdCedis = @idCedis AND IdSurtido = @idSurtido AND IdTipoVenta = @idTipoVenta AND Folio = @Folio AND Serie = @Serie
			
			OPEN @CursorVar1
			
			FETCH NEXT FROM @CursorVar1 INTO @IdProducto, @Cantidad, @Precio, @IvaPor

			WHILE @@FETCH_STATUS = 0      
			BEGIN

				declare @Total as decimal (20,9), @SubTotalImp as decimal (20,9), @ImpIniciales as decimal (20,9), @ImpFinales as decimal (20,9)
				declare @IdTipoImpuesto as int, @TipoAplicacion as int, @Jerarquia as int, @Impuestos as float

				set @SubTotalImp = @Cantidad * @Precio 
				set @ImpIniciales = 0 
				set @ImpFinales = 0
				declare  ActImpuestos cursor for
					select IdTipoImpuesto, TipoAplicacion, Jerarquia, Tasa
					from RouteADM.dbo.VentasImpuestos as VtasImp
					where VtasImp.IdCedis = @IdCedis and VtasImp.IdSurtido = @IdSurtido and VtasImp.IdTipoVenta = @IdTipoVenta and VtasImp.Folio = @Folio and VtasImp.IdProducto = @IdProducto 
					order by TipoAplicacion, Jerarquia
				open ActImpuestos
				
				fetch next from ActImpuestos into @IdTipoImpuesto, @TipoAplicacion, @Jerarquia, @Impuestos 
				while (@@fetch_status = 0)
				begin
					
					if @TipoAplicacion = 1
					begin
						set @ImpIniciales = @ImpIniciales + (@SubTotalImp * @Impuestos)
						set @IvaImp = @SubTotalImp * @Impuestos
					end
					else
					begin
						set @ImpFinales = @ImpFinales + ((@SubTotalImp + @ImpIniciales) * @Impuestos)
						set @IvaImp = (@SubTotalImp + @ImpIniciales) * @Impuestos
					end
										
					INSERT INTO TPDImpuesto
					select @TransProdId, @IdProducto, RIGHT(REPLACE(CONVERT(VARCHAR(36),NEWID()),'-',''),16), @IdTipoImpuesto, round((@Impuestos*100),2), @IvaImp, GETDATE(),@USUID
					
					fetch next from ActImpuestos into @IdTipoImpuesto, @TipoAplicacion, @Jerarquia, @Impuestos 
				end
				close ActImpuestos
				deallocate ActImpuestos		
				
				FETCH NEXT FROM @CursorVar1 INTO @IdProducto, @Cantidad, @Precio, @IvaPor
			END 
			CLOSE @CursorVar1  
			DEALLOCATE @CursorVar1
		
		delete from [Route].[dbo].[TRPVtaAcreditada] where TransProdID = @TransprodId
		
		select @OrdenCompra = ''
		
		select @ClienteClave = ClienteClave from Route.dbo.TransProd where TransProdID = @TransprodId 
		
		if exists(select Addenda.ADDID 
			from Route.dbo.AddendaCliente AdCte 
			inner join Route.dbo.Addenda Addenda on AdCte.ADDId = Addenda.ADDID and Addenda.Tipo = 1
			where AdCte.ClienteClave  = @ClienteClave )
		begin
			select @OrdenCompra = FolioEntrega  
			FROM RouteADM.dbo.VentasAcredita  
			WHERE IdCedis = @idCedis AND IdTipoVenta = @idTipoVenta AND Folio = @Folio and IdSurtido = @idSurtido 
			
			update Route.dbo.TransProd set Notas = @OrdenCompra where TransProdID = @TransprodId 
		end

		insert into [Route].[dbo].[TRPVtaAcreditada]
		SELECT @TransprodId, FolioEntrega, FolioCliente, Remision, '', GETDATE(), @USUID 
		FROM RouteADM.dbo.VentasAcredita  
		WHERE IdCedis = @idCedis AND IdSurtido=@idSurtido AND IdTipoVenta = @idTipoVenta AND Folio = @Folio and Serie = @Serie 

		delete from Route.dbo.TRPDatoFiscal where TransProdID = @TransprodIdFactura 

		declare @FolioID as varchar (500), @FosID as varchar (500), @TipoVersion as varchar (500), @NumCertificado as varchar (500), 
			@RazonSocial as varchar (500), @RFC as varchar (500), @TelefonoContacto as varchar (500), @Calle as varchar (500), @NumExt as varchar (500), @NumInt as varchar (500), @Colonia as varchar (500), 
			@Localidad as varchar (500), @Municipio as varchar (500), @Entidad as varchar (500), @Pais as varchar (500), @CodigoPostal as varchar (500), @ReferenciaDom as varchar (500), 
			@TelefonoEm as varchar (500), @RFCEm as varchar (500), @NombreEm as varchar (500), @CalleEm as varchar (500), @NumExtEm as varchar (500), @NumIntEm as varchar (500), @ColoniaEm as varchar (500), 
			@LocalidadEm as varchar (500), @ReferenciaDomEm as varchar (500), @MunicipioEm as varchar (500), @RegionEM as varchar (500), @PaisEm as varchar (500), @CodigoPostalEm as varchar (500),
			@CalleEx as varchar (500), @NumExtEx as varchar (500), @NumIntEx as varchar (500), @ColoniaEx as varchar (500), @CodigoPostalEx as varchar (500), @ReferenciaDomEx as varchar (500), 
			@LocalidadEx as varchar (500), @MunicipioEx as varchar (500), @EntidadEx as varchar (500), @PaisEx varchar (500),
			@Aprobacion as varchar (500), @AnioAprobacion as varchar (500) 

		select top 1 @RFC = RFC, @RazonSocial = RazonSocial, @Calle = isnull(CalleF,''), @NumExt = isnull(NumExteriorF,''), @NumInt = isnull(NumInteriorF,''), @Colonia = isnull(ColoniaF,''),
			@Localidad = isnull(LocalidadF,''), @Municipio = isnull(PoblacionF,''), @Entidad = isnull(EntidadF,''), @Pais = isnull(PaisF,''), @CodigoPostal = isnull(CPF,''), 
			@ReferenciaDom = '', @TelefonoContacto = isnull(TelefonosF,'')
		from RouteADM.dbo.Ventas as Ventas
		inner join RouteADM.dbo.ClienteSucursal as ClienteSucursal on Ventas.IdCedis = ClienteSucursal.IdCedis and Ventas.IdSucursal = ClienteSucursal.IdSucursal 
		where Ventas.IdCedis = @IdCedis and Ventas.IdSurtido = @IdSurtido and Ventas.IdTipoVenta = @IdTipoVenta and Ventas.Folio = @Folio 
			
		select @FolioID = Folio.FolioID, @FosID = FosH.FOSId, @TipoVersion = '2.0', @Aprobacion = Aprobacion, @AnioAprobacion = AnioAprobacion 
		from Route.dbo.SEMHist SemHist
		inner join Route.dbo.SubEmpresa SubE on SubE.SubEmpresaId = SemHist.SubEmpresaId 
		inner join Route.dbo.Folio Folio on SubE.SubEmpresaId = Folio.SubEmpresaId
		inner join Route.dbo.FolioSolicitado FolS on Folio.FolioID = FolS.FolioID 
		inner join Route.dbo.FOSHist FosH on FosH.FolioID = FolS.FolioID and FosH.FOSId = FosH.FOSId 
		where SubE.TipoEstado = 1 and FosH.VendedorID = @USUID and SemHist.DirArchivosFacElec <> ''

		select @NumCertificado = Matriz.NumCertificado, @RFCEm = Matriz.RFC, @CalleEm = isnull(Matriz.Calle,''), @NumExtEm = isnull(Matriz.NumExt,''), @NumIntEm = isnull(Matriz.NumInt,''), @ColoniaEm = isnull(Matriz.Colonia,''), @CodigoPostalEm = isnull(Matriz.CodigoPostal,''),
		@ReferenciaDomEm = isnull(Matriz.ReferenciaDom,''), @LocalidadEm = isnull(Matriz.Localidad,''), @MunicipioEm = isnull(Matriz.Municipio,''), @RegionEM = isnull(Matriz.Entidad,''), @PaisEm = isnull(Matriz.Pais,''),
		@TelefonoEm = '', @NombreEm = Matriz.Nombre, 
		@CalleEx = isnull(Sucursal.Calle,''), @NumExtEx = isnull(Sucursal.NumExt,''), @NumIntEx = isnull(Sucursal.NumInt,''), @ColoniaEx = isnull(Sucursal.Colonia,''), @CodigoPostalEx = isnull(Sucursal.CodigoPostal,''),
		@ReferenciaDomEx = isnull(Sucursal.ReferenciaDom,''), @LocalidadEx = isnull(Sucursal.Localidad,''), @MunicipioEx = isnull(Sucursal.Municipio,''), @EntidadEx = isnull(Sucursal.Entidad,''), @PaisEx = isnull(Sucursal.Pais,'')
		from Route.dbo.CentroExpedicion as Matriz 
		inner join Route.dbo.SubEmpresa SubE on SubE.SubEmpresaId = Matriz.SubEmpresaId 
		inner join Route.dbo.CentroExpedicion as Sucursal on Sucursal.CentroExpPadreID = Matriz.CentroExpID and Sucursal.TipoEstado = 1
			and Sucursal.Tipo = 1 and Matriz.SubEmpresaId = Sucursal.SubEmpresaId 
		where Matriz.CentroExpPadreID is null and Matriz.TipoEstado = 1 and Matriz.Tipo = 0

		Insert Into [Route].[dbo].[TRPDatoFiscal] (TransProdID, FolioID, FosID, TipoVersion, 
			RazonSocial, RFC, TelefonoContacto, Calle, NumExt, NumInt, Colonia, 
			Localidad, Municipio, Entidad, Pais, CodigoPostal, ReferenciaDom, 
			CadenaOriginal, SelloDigital, NumCertificado, Aprobacion, AnioAprobacion, Serie, TipoNotaCredito,
			TelefonoEm, RFCEm, NombreEm, CalleEm, NumExtEm, NumIntEm, ColoniaEm, 
			LocalidadEm, ReferenciaDomEm, MunicipioEm, RegionEM, PaisEm, CodigoPostalEm, 
			CalleEx, NumExtEx, NumIntEx, ColoniaEx, CodigoPostalEx, ReferenciaDomEx, LocalidadEx, MunicipioEx, EntidadEx, PaisEx, 
			mfechahora, musuarioid) values
		(@TransprodIdFactura, @FolioID, @FosID, @TipoVersion, 
			@RazonSocial, @RFC, @TelefonoContacto, @Calle, @NumExt, @NumInt, @Colonia, 
			@Localidad, @Municipio, @Entidad, @Pais, @CodigoPostal, @ReferenciaDom, 
			'', '', @NumCertificado, @Aprobacion, @AnioAprobacion, @Serie, @TipoNotaCredito, 
			@TelefonoEm, @RFCEm, @NombreEm, @CalleEm, @NumExtEm, @NumIntEm, @ColoniaEm, 
			@LocalidadEm, @ReferenciaDomEm, @MunicipioEm, @RegionEM, @PaisEm, @CodigoPostalEm, 
			@CalleEx, @NumExtEx, @NumIntEx, @ColoniaEx, @CodigoPostalEx, @ReferenciaDomEx, @LocalidadEx, @MunicipioEx, @EntidadEx, @PaisEx,
		GETDATE(), @USUID)
END



GO


