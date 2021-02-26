USE [Route]
GO

/****** Object:  StoredProcedure [dbo].[sp_importVentasCPC]    Script Date: 06/30/2011 20:12:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_importVentasCPC]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_importVentasCPC]
GO

USE [Route]
GO

/****** Object:  StoredProcedure [dbo].[sp_importVentasCPC]    Script Date: 06/30/2011 20:12:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO











-- =============================================
-- Author:		ABRAHAM MEDINA
-- Create date: 15/05/2011
-- Description:	INTERFAZ DE ENTRADA DEL MODULO ADMINISTRATIVO A ROUTE
-- =============================================
CREATE PROCEDURE [dbo].[sp_importVentasCPC] 
	@idCedis int, @idTipoVenta int, @Folio int, @Serie as varchar(10), 
	@TransprodId as varchar(16), @TransprodIdFactura as varchar(16), @VendedorId as varchar(16), @TipoNotaCredito as smallint
AS
BEGIN
	SET NOCOUNT ON;

--declare @idCedis int, @idTipoVenta int, @Folio int, @Serie as varchar(10), @TransprodId as varchar(16), @TransprodIdFactura as varchar(16), @VendedorId as varchar(16), @TipoNotaCredito as smallint
--set @idCedis = 1
--set @idTipoVenta = 2
--set @Folio = 1100
--set @Serie = 'FGG'
--set @TransprodId = '8BFA0D9ED54B1978'
--set @TransprodIdFactura = 'A0B3761F9EFD567F'
--set @VendedorId = 'CFDCed1'
--set @TipoNotaCredito = 0

	
	--DECLARE @Serie AS VARCHAR(5)
	DECLARE @Fecha AS DATETIME
	DECLARE @SubTotal AS MONEY
	DECLARE @Iva AS MONEY
	DECLARE @idSucursal AS VARCHAR(16)
	DECLARE @DiaClave as VARCHAR(10)
	DECLARE @idRuta AS INT
	DECLARE @RUTClave as VARCHAR(10)
	--DECLARE @VendedorId as VARCHAR(16)
	DECLARE @USUID AS VARCHAR(16)
	DECLARE @ClienteClave AS VARCHAR(16)
	--DECLARE @TransProdId AS VARCHAR(16)
	DECLARE @VisitaClave AS VARCHAR(16)
	DECLARE @ModuloClave AS VARCHAR(16)
	DECLARE @ModuloMovDetalleClave AS VARCHAR(16)
	DECLARE @FolioRoute AS VARCHAR(16)
	DECLARE @TipoPedido AS SMALLINT
	DECLARE @TipoMovimiento AS SMALLINT
	DECLARE @TipoFase AS SMALLINT
	DECLARE @DctoImp AS MONEY
	DECLARE @DiasCredito as INT
	DECLARE @PrestamoCliente AS BIT	
	DECLARE @SaldoVenta AS MONEY
	DECLARE @Formato as int
	DECLARE @Tipo as int
		
	declare @CedId as bigint

	DECLARE @ImporteSinDesc AS FLOAT
	DECLARE @DescVendPor AS FLOAT
	DECLARE @Descuento AS BIT
	DECLARE @FechaCobranza AS DATETIME
		
	declare @LetraCte as varchar(2)
	declare @idCedis2 int, @idTipoVenta2 int, @Folio2 int, @Serie2 as varchar(10), @fecha2 as datetime
	declare @Remision as varchar(20), @PedidoAdicional as varchar(20)
		
	SELECT @Serie = Serie, @Fecha = Fecha,  @SubTotal = Subtotal, @Iva = Iva, @idSucursal = IdSucursal, @DctoImp = DctoImp, @DiasCredito = isnull(DiasVencimiento,0) 
	FROM RouteCPC.dbo.Ventas 
	WHERE IdCedis = @idCedis AND IdTipoVenta = @idTipoVenta AND Folio = @Folio and Serie = @Serie 

	select @Formato = LEN(Formato)
	from Route.dbo.Folio Fol
	inner join Route.dbo.FolioDetalle FolD on Fol.FolioID = FolD.FolioID 
	where Fol.ModuloMovDetalleClave = '2TP631GUGIO1WSB' and FolD.TipoContenido = 2
	
	declare @SFact as varchar(10), @FFact as bigint
	
	select @SFact = SerieFactura, @FFact = FolioFactura 
	from RouteCPC.dbo.VentasFacturaCFD 
	where IdCedis = @IdCedis and IdTipoVenta = @IdTipoVenta and 
		Serie = @Serie and Folio = @Folio
		
	if @SFact is null
		select @SFact = SerieFactura, @FFact = FolioFactura 
		from RouteCPC.dbo.VentasFacturaCFD 
		where IdCedis = @IdCedis and IdTipoVenta = @IdTipoVenta and 
			SerieFactura = @Serie and FolioFactura = @Folio

	if @Formato is null set @Formato = 6

	if LEN(@FFact) <= @Formato 
		SET @FolioRoute = @SFact + REPLICATE('0',@Formato - LEN(@FFact)) + cast(@FFact as varchar(20))
	else
		SET @FolioRoute = @SFact + cast(@FFact as varchar(20))
	
	declare @FechaFacturacion as varchar(30)
	
	set @FechaFacturacion = cast(YEAR(GETDATE()) as varchar(4)) + '-'
		+ replicate('0', 2-LEN(MONTH(GETDATE()))) + cast(MONTH(GETDATE()) as varchar(2)) + '-'
		+ replicate('0', 2-LEN(day(GETDATE()))) + cast(day(GETDATE()) as varchar(2)) + ' '
		+ replicate('0', 2-LEN(DATEPART(hh,getdate()))) + cast(DATEPART(hh,getdate()) as varchar(2)) + ':'
		+ replicate('0', 2-LEN(DATEPART(mm,getdate()))) + cast(DATEPART(mm,getdate()) as varchar(2)) + ':'
		+ replicate('0', 2-LEN(DATEPART(ss,getdate()))) + cast(DATEPART(ss,getdate()) as varchar(2))

	select @idCedis2 = @idCedis, @idTipoVenta2 = @idTipoVenta, @Serie2 = @Serie, @Folio2 = @Folio, @fecha2 = @Fecha  

	IF not exists(select TransProdId from TransProd where TransProdID = @TransprodId )
	BEGIN
		declare PedidosFactura cursor for
			select Vtas.IdCedis, Vtas.IdTipoVenta, Vtas.Serie, Vtas.Folio, Vtas.IdSucursal, Vtas.IdCedis, 1  
			from RouteCPC.dbo.FacturasOxxo as FacturasOxxo 
			inner join RouteCPC.dbo.Ventas as Vtas on FacturasOxxo.IdCedis = Vtas.IdCedis and FacturasOxxo.IdTipoVenta = Vtas.IdTipoVenta  
				and FacturasOxxo.Serie = Vtas.Serie and FacturasOxxo.Folio = Vtas.Folio  
			inner join RouteCPC.dbo.ClienteSucursal as ClienteSucursal on ClienteSucursal.IdCedis = Vtas.IdCedis and Vtas.IdSucursal = ClienteSucursal.IdSucursal 
			where FacturasOxxo.IdCedisOX = @idcedis and FacturasOxxo.IdTipoVentaOX = @idtipoventa and FacturasOxxo.SerieOX = @serie and FacturasOxxo.FolioOX = @folio

			union
			
			select Vtas.IdCedis, Vtas.IdTipoVenta, Vtas.Serie, Vtas.Folio, Vtas.IdSucursal, Vtas.IdCedis, 0  
			from RouteCPC.dbo.Ventas as Vtas 
			left outer join RouteCPC.dbo.FacturasOxxo as FacturasOxxo on FacturasOxxo.IdCedisOX = Vtas.IdCedis and FacturasOxxo.IdTipoVentaOX = Vtas.IdTipoVenta  
				and FacturasOxxo.SerieOX = Vtas.Serie and FacturasOxxo.FolioOX = Vtas.Folio  
			where Vtas.IdCedis = @idcedis and Vtas.IdTipoVenta = @idtipoventa and Vtas.Serie = @serie and Vtas.Folio = @folio and FacturasOxxo.IdCedisOX is null
			order by Vtas.IdCedis, Vtas.IdTipoVenta, Vtas.Serie, Vtas.Folio 

		open PedidosFactura
		
		fetch next from PedidosFactura into @idcedis, @IdTipoVenta, @Serie, @Folio, @idsucursal, @CedId, @Tipo
		while (@@fetch_status = 0)
		begin

			SET @TipoFase = 2
			SELECT @Serie = Serie, @Fecha = Fecha,  @SubTotal = Subtotal, @Iva = Iva, @idSucursal = IdSucursal, @DctoImp = DctoImp, @DiasCredito = isnull(DiasVencimiento,0) 
			FROM RouteCPC.dbo.Ventas 
			WHERE IdCedis = @idCedis AND IdTipoVenta = @idTipoVenta AND Folio = @Folio and Serie = @Serie 

			SELECT top 1 @idRuta = IdRuta  FROM RouteADM.dbo.Rutas WHERE IdCedis = @idCedis AND Status = 'A'
			SET @RUTClave = 'R'+ RIGHT('000' + CONVERT(VARCHAR(3),@idRuta), 3)
			
			SET @DiaClave = RIGHT('00' + CONVERT(VARCHAR,DAY(@Fecha)),2) + '/' + RIGHT('00' + CONVERT(VARCHAR,MONTH(@Fecha)),2) + '/' + RIGHT('0000' + CONVERT(VARCHAR,YEAR(@Fecha)),4)
			
			if @VendedorId = ''	
				SELECT TOP 1 @VendedorId= VendedorID FROM VenRut WHERE RUTClave = @RUTClave AND TipoEstado = 1
			
			SELECT @USUID = USUId, @ModuloClave = ModuloClave 
			FROM Vendedor 
			WHERE VendedorID = @VendedorId 

			SET @ImporteSinDesc = @SubTotal + @DctoImp 		
			IF @ImporteSinDesc <> 0
				SET @DescVendPor = (@DctoImp * 100) / @ImporteSinDesc 
			ELSE
				SET @DescVendPor = 0
				
			SET @Descuento = (CASE WHEN @DctoImp = 0 THEN 0 ELSE 1 END)
			SET @FechaCobranza = DATEADD(DAY, @DiasCredito, @Fecha)	

				if @CedId <> 0
					select @LetraCte = case @CedId 
					when 1 then 'A' when 2 then 'B' 
					when 3 then 'C' when 4 then 'D' 
					when 5 then 'E' when 6 then 'F' 
					when 7 then 'G' end
				else
					select @LetraCte = case @idCedis 
					when 1 then 'A' when 2 then 'B' 
					when 3 then 'C' when 4 then 'D' 
					when 5 then 'E' when 6 then 'F' 
					when 7 then 'G' end
					
				SET @ClienteClave = CONVERT(VARCHAR(16),@LetraCte + @idSucursal)
				SELECT @PrestamoCliente = Prestamo FROM Cliente WHERE ClienteClave = @ClienteClave
				
				if @TransprodId is null	
					select @TransprodId = RIGHT(REPLACE(CONVERT(VARCHAR(36),NEWID()),'-',''),16)
				
				IF not exists(select TransProdId from TransProd where TransProdID = @TransprodId )
				BEGIN
					IF(SELECT COUNT(*) FROM Dia WHERE DiaClave = @DiaClave )=0
						INSERT INTO Dia(DiaClave,Referencia,Estado,FechaCaptura,MFechaHora,MUsuarioID) VALUES(@DiaClave,'','1',@Fecha,GETDATE(),@USUID)		
				      
					SET @VisitaClave = RIGHT(REPLACE(CONVERT(VARCHAR(36),NEWID()),'-',''),16)
						    
					INSERT INTO [Route].[dbo].[Visita]
						   ([VisitaClave],[DiaClave],[ClienteClave],[VendedorID],[RUTClave]
						   ,[Numero],[FechaHoraInicial],[FechaHoraFinal],[TipoEstado],[FueraFrecuencia],[CodigoLeido],[GPSLeido],[DistanciaGPS]
						   ,[MFechaHora],[MUsuarioID])
					 VALUES(
							@VisitaClave,@DiaClave,@ClienteClave,@VendedorId,@RUTClave
						   ,1,@Fecha,@Fecha,1,0,0,0,NULL
						   ,GETDATE(),@USUID)

					SELECT @ModuloMovDetalleClave = ModuloMovDetalleClave, @TipoPedido = TipoPedido, @TipoMovimiento = TipoMovimiento  
					FROM ModuloMovDetalle 
					WHERE TipoIndice = 9 AND TipoTransProd = 1 AND TipoEstado = 1 AND Baja = 0 AND ModuloClave = @ModuloClave

					DECLARE @FechaPrimera AS DATETIME	

					select @Remision = '', @PedidoAdicional = ''
					
					if exists(select Addenda.ADDID 
						from Route.dbo.AddendaCliente AdCte 
						inner join Route.dbo.Addenda Addenda on AdCte.ADDId = Addenda.ADDID and Addenda.Tipo = 2
						where AdCte.ClienteClave  = @ClienteClave )
					begin
						select @Remision = Remision, @PedidoAdicional = FolioCliente 
						FROM RouteCPC.dbo.VentasAcredita  
						WHERE IdCedis = @idCedis AND IdTipoVenta = @idTipoVenta AND Folio = @Folio and Serie = @Serie 
					end
 						
					INSERT INTO [Route].[dbo].[TransProd]
						   ([TransProdID],[VisitaClave],[DiaClave],[PCEModuloMovDetClave],[ClienteClave],[ClientePagoID]
						   ,[CFVTipo],[Folio],[Tipo],[TipoPedido],[TipoFase],[TipoMovimiento]
							,[FechaHoraAlta],[FechaCaptura],[FechaEntrega],[FechaFacturacion],[FechaSurtido],[FechaCancelacion]
						   ,[TipoMotivo]
						   ,[SubTDetalle],[DescVendPor],[DescuentoVendedor],[DescuentoImp],[Subtotal],[Impuesto],[Total],[Saldo]
						   ,[Promocion],[Descuento]
						   ,[TipoTurno],[FechaCobranza],[DiasCredito]
						   ,[TipoFaseIntSal],[MFechaHora],[MUsuarioID], [SubEmpresaID])
					VALUES(
						   @TransProdId,@VisitaClave,@DiaClave,@ModuloMovDetalleClave,@ClienteClave,'1'
						   ,@idTipoVenta,case @Remision when '' then @FolioRoute else @Remision end,1,@TipoPedido,@TipoFase,@TipoMovimiento
						   ,@Fecha,@Fecha,@Fecha,@FechaPrimera,@Fecha,@FechaPrimera
						   ,0
						   ,@ImporteSinDesc,0,0,@DctoImp,@SubTotal,@Iva,@SubTotal + @Iva,@SubTotal + @Iva
						   ,0,@Descuento
						   ,0,@FechaCobranza,@DiasCredito 
						   ,1,GETDATE(),@USUID, 1)	

					SET @SaldoVenta = @SubTotal + @Iva

					if @Tipo = 1
					begin
						insert into [RouteCPC].[dbo].[VentasFacturaCFD] 
						select @idCedis, 0, @idTipoVenta, @Serie, @Folio, @Serie2, @Folio2, @TransprodId, '', GETDATE(), ''
					end

					insert into [Route].[dbo].[TRPVtaAcreditada]
					SELECT @TransprodId, FolioEntrega, FolioCliente, Remision, @PedidoAdicional, GETDATE(), @USUID 
					FROM RouteCPC.dbo.VentasAcredita  
					WHERE IdCedis = @idCedis AND IdTipoVenta = @idTipoVenta AND Folio = @Folio and Serie = @Serie 
					
					IF(SELECT COUNT(*) FROM RouteCPC.dbo.VentasDetalle WHERE IdCedis = @idCedis AND Serie = @Serie AND IdTipoVenta = @idTipoVenta AND Folio = @Folio AND Serie = @Serie )>0
					BEGIN
						DELETE FROM TPDImpuesto WHERE TransProdID = @TransProdId 
						DELETE FROM TransProdDetalle WHERE TransProdID = @TransProdId 
						
						DECLARE @IdProducto as BIGINT
						DECLARE @Cantidad AS DECIMAL(19,2)
						DECLARE @Precio AS MONEY
						DECLARE @IvaPor AS FLOAT
						DECLARE @IvaImp AS FLOAT
						DECLARE @ProductoClave AS VARCHAR(10)
						DECLARE @ImpuestoClave AS VARCHAR(16)
						DECLARE @ProductoEnvase AS VARCHAR(10)
						DECLARE @PrestamoProducto AS BIT
						DECLARE @EsEnvase as BIT
						DECLARE @TipoUnidad as SMALLINT
						
						DECLARE @CursorVar1 AS CURSOR 
						SET @CursorVar1 = CURSOR SCROLL STATIC  
						FOR
						SELECT IdProducto, Cantidad, Precio, Iva, DctoImp
						FROM RouteCPC.dbo.VentasDetalle 
						WHERE IdCedis = @idCedis AND Serie = @Serie AND IdTipoVenta = @idTipoVenta AND Folio = @Folio AND Serie = @Serie
						
						OPEN @CursorVar1
						
						FETCH NEXT FROM @CursorVar1 INTO @IdProducto, @Cantidad, @Precio, @IvaPor, @DctoImp

						WHILE @@FETCH_STATUS = 0      
						BEGIN
							SET @ProductoClave = CONVERT(VARCHAR(10),@IdProducto)
							SET @IvaImp = ROUND(((@Cantidad * @Precio) - @DctoImp) * @IvaPor ,2)
							SET @PrestamoProducto = 0
							SET @ProductoEnvase = NULL 
							
							SELECT @EsEnvase = Contenido FROM Producto where ProductoClave = @ProductoClave 
							SELECT @TipoUnidad = PRUTipoUnidad FROM ProductoDetalle WHERE ProductoClave = @ProductoClave AND ProductoClave = ProductoDetClave AND Factor = 1								
							
							INSERT INTO TransProdDetalle(
								TransProdID, TransProdDetalleID, ProductoClave,TipoUnidad,Partida,
								Cantidad,Precio,DescuentoPor,DescuentoImp,Subtotal,Impuesto,Total,
								Promocion,TipoFaseIntSal, MFechaHora,MUsuarioID)
							VALUES(
								@TransProdId,@ProductoClave, @ProductoClave,@TipoUnidad,1,
								@Cantidad,@Precio,0,@DctoImp,((@Cantidad * @Precio)-@DctoImp), @IvaImp,((@Cantidad * @Precio)-@DctoImp)+@IvaImp,
								0,1,GETDATE(),@USUID)

							declare @Total as decimal (20,9), @SubTotalImp as decimal (20,9), @ImpIniciales as decimal (20,9), @ImpFinales as decimal (20,9)
							declare @IdTipoImpuesto as int, @TipoAplicacion as int, @Jerarquia as int, @Impuestos as float

							set @SubTotalImp = (@Cantidad * @Precio) - @DctoImp 
							set @ImpIniciales = 0 
							set @ImpFinales = 0
							declare  ActImpuestos cursor for
								select IdTipoImpuesto, TipoAplicacion, Jerarquia, Tasa
								from RouteCPC.dbo.VentasImpuestos as VtasImp
								where VtasImp.IdCedis = @IdCedis and VtasImp.Serie = @Serie and VtasImp.IdTipoVenta = @IdTipoVenta and VtasImp.Folio = @Folio and VtasImp.IdProducto = @IdProducto 
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

							IF @EsEnvase = 0 						
								SELECT @ProductoEnvase = PRD.ProductoDetClave 
								FROM ProductoDetalle PRD
								INNER JOIN Producto PRO ON PRD.ProductoDetClave = PRO.ProductoClave 
								WHERE PRD.ProductoClave <> PRD.ProductoDetClave AND PRO.Contenido = 1
								AND PRD.ProductoClave = @ProductoClave AND PRD.PRUTipoUnidad = @TipoUnidad 
							ELSE
								SET @ProductoEnvase = @ProductoClave 
							
							SELECT @PrestamoProducto = PRD.Prestamo 
							FROM Producto PRO
							INNER JOIN ProductoDetalle PRD ON PRO.ProductoClave = PRD.ProductoClave AND PRD.ProductoClave = PRD.ProductoDetClave AND PRD.PRUTipoUnidad = @TipoUnidad 
							WHERE PRO.ProductoClave = @ProductoEnvase
							
							IF (@PrestamoCliente = 1 AND @PrestamoProducto = 1)
							BEGIN
								IF (SELECT COUNT(*) FROM ProductoPrestamoCli WHERE ClienteClave = @ClienteClave AND ProductoClave = @ProductoEnvase) = 0
									INSERT INTO ProductoPrestamoCli (ClienteClave, ProductoClave, Saldo, MFechaHora, MUsuarioID) 
									VALUES	(@ClienteClave, @ProductoEnvase, CASE WHEN @EsEnvase = 0 THEN @Cantidad ELSE @Cantidad * -1 END, GETDATE(), @USUID)
								ELSE
									UPDATE ProductoPrestamoCli SET Saldo = Saldo + CASE WHEN @EsEnvase = 0 THEN @Cantidad ELSE @Cantidad * -1 END, MFechaHora = GETDATE(), MUsuarioID = @USUID WHERE ClienteClave = @ClienteClave AND ProductoClave = @ProductoEnvase 								
							END
							
							FETCH NEXT FROM @CursorVar1 INTO @IdProducto, @Cantidad, @Precio, @IvaPor, @DctoImp
						END 
						CLOSE @CursorVar1  
						DEALLOCATE @CursorVar1
					
					END
					
					--Cobranza (PagoAutomatico, CobrarVentas y Venta a Contado)
					IF (SELECT TOP 1 CASE WHEN CobrarVentas = 1 AND PagoAutomatico = 1 THEN 1 ELSE 0 END FROM CONHist ORDER BY MFechaHora DESC) = 1 AND @idTipoVenta = 1
					BEGIN
						DECLARE @ABNID AS VARCHAR(16)
						DECLARE @MonedaID AS VARCHAR(20)	
				
						SELECT @MonedaID = MonedaID FROM CONHist ORDER BY CONHistFechaInicio DESC
				
						SET @ABNID =  RIGHT(REPLACE(CONVERT(VARCHAR(36),NEWID()),'-',''),16)				
						INSERT INTO Abono (ABNId, Folio, FechaCreacion, VisitaClave, DiaClave, FechaAbono, Total, Saldo, MFechaHora, MUsuarioID)
							VALUES(@ABNID, @FolioRoute, @FechaCobranza, @VisitaClave, @DiaClave, @FechaCobranza, @SaldoVenta, 0, GETDATE(), @USUID)
						
						INSERT INTO AbnTrp (ABNId, TransProdID, FechaHora, Importe, Serie, Corecibo, TipoFaseIntSal, MFechaHora, MUsuarioID)
							VALUES(@ABNID, @TransProdID, @FechaCobranza, @SaldoVenta, '','',1,GETDATE(), @USUID)
						
						INSERT INTO ABNDetalle (ABNId, ABDId, TipoPago, Importe, SaldoDeposito, MonedaId, Referencia, MFechaHora, MUsuarioID)
							VALUES(@ABNID, RIGHT(REPLACE(CONVERT(VARCHAR(36),NEWID()),'-',''),16), 1, @SaldoVenta, 0, @MonedaID, '', GETDATE(), @USUID)
							
						UPDATE TransProd SET Saldo = 0 WHERE TransProdID = @TransProdID 								
					END
					ELSE
						UPDATE Cliente SET SaldoEfectivo = SaldoEfectivo + @SaldoVenta WHERE ClienteClave = @ClienteClave
					
				END	

				update [Route].[dbo].[TransProd] 
					set FacturaID = @TransprodIdFactura, TipoFase = 3, FechaFacturacion = @FechaFacturacion,
						MFechaHora = GETDATE(), MUsuarioID = @USUID 
				where TransProdID = @TransprodId 
			
			set @TransprodId = null

			fetch next from PedidosFactura into @idcedis, @IdTipoVenta, @Serie, @Folio, @idsucursal, @CedId, @Tipo
			
		end
		close PedidosFactura
		deallocate PedidosFactura		

	END
	
	select @idCedis = @idCedis2, @idTipoVenta = @idTipoVenta2, @Serie = @Serie2, @Folio = @Folio2, @Fecha = @fecha2    

	SELECT @Serie = Serie, @Fecha = Fecha,  @SubTotal = Subtotal, @Iva = Iva, @idSucursal = IdSucursal, @DctoImp = DctoImp, @DiasCredito = isnull(DiasVencimiento,0) 
	FROM RouteCPC.dbo.Ventas 
	WHERE IdCedis = @idCedis AND IdTipoVenta = @idTipoVenta AND Folio = @Folio and Serie = @Serie 
	
	IF @TransprodIdFactura is not null and not exists(select TransProdId from TransProd where TransProdID = @TransprodIdFactura )
	BEGIN
		IF(SELECT COUNT(*) FROM Dia WHERE DiaClave = @DiaClave )=0
			INSERT INTO Dia(DiaClave,Referencia,Estado,FechaCaptura,MFechaHora,MUsuarioID) VALUES(@DiaClave,'','1',@Fecha,GETDATE(),@USUID)		
	      
		SET @VisitaClave = RIGHT(REPLACE(CONVERT(VARCHAR(36),NEWID()),'-',''),16)
			    
		INSERT INTO [Route].[dbo].[Visita]
			   ([VisitaClave],[DiaClave],[ClienteClave],[VendedorID],[RUTClave]
			   ,[Numero],[FechaHoraInicial],[FechaHoraFinal],[TipoEstado],[FueraFrecuencia],[CodigoLeido],[GPSLeido],[DistanciaGPS]
			   ,[MFechaHora],[MUsuarioID])
		 VALUES(
				@VisitaClave,@DiaClave,@ClienteClave,@VendedorId,@RUTClave
			   ,1,@Fecha,@Fecha,1,0,0,0,NULL
			   ,GETDATE(),@USUID)

	set @FechaFacturacion = cast(YEAR(GETDATE()) as varchar(4)) + '-'
		+ replicate('0', 2-LEN(MONTH(GETDATE()))) + cast(MONTH(GETDATE()) as varchar(2)) + '-'
		+ replicate('0', 2-LEN(day(GETDATE()))) + cast(day(GETDATE()) as varchar(2)) + ' '
		+ replicate('0', 2-LEN(DATEPART(hh,getdate()))) + cast(DATEPART(hh,getdate()) as varchar(2)) + ':'
		+ replicate('0', 2-LEN(DATEPART(mm,getdate()))) + cast(DATEPART(mm,getdate()) as varchar(2)) + ':'
		+ replicate('0', 2-LEN(DATEPART(ss,getdate()))) + cast(DATEPART(ss,getdate()) as varchar(2))
		
		SELECT @ModuloMovDetalleClave = ModuloMovDetalleClave, @TipoPedido = TipoPedido, @TipoMovimiento = TipoMovimiento  
		FROM ModuloMovDetalle 
		WHERE TipoIndice = 9 AND TipoTransProd = 1 AND TipoEstado = 1 AND Baja = 0 AND ModuloClave = @ModuloClave

		INSERT INTO [Route].[dbo].[TransProd]
			   ([TransProdID],[VisitaClave],[DiaClave],[PCEModuloMovDetClave],[ClienteClave],[ClientePagoID]
			   ,[CFVTipo],[Folio],[Tipo],[TipoPedido],[TipoFase],[TipoMovimiento]
				,[FechaHoraAlta],[FechaCaptura],[FechaEntrega],[FechaFacturacion],[FechaSurtido],[FechaCancelacion]
			   ,[TipoMotivo]
			   ,[SubTDetalle],[DescVendPor],[DescuentoVendedor],[DescuentoImp],[Subtotal],[Impuesto],[Total],[Saldo]
			   ,[Promocion],[Descuento]
			   ,[TipoTurno],[FechaCobranza],[DiasCredito]
			   ,[TipoFaseIntSal],[MFechaHora],[MUsuarioID], [SubEmpresaID])
		VALUES(
			   @TransprodIdFactura,@VisitaClave,@DiaClave,@ModuloMovDetalleClave,null,null
			   ,@idTipoVenta,@FolioRoute,8,null,@TipoFase,null
			   ,@FechaFacturacion,@Fecha,null, @FechaFacturacion,@FechaPrimera,@FechaPrimera
			   ,0
			   ,null,null,null,0,@SubTotal,@Iva,@SubTotal + @Iva,@SubTotal + @Iva
			   ,0,null
			   ,0,@FechaCobranza,null 
			   ,1,GETDATE(),@USUID, 1)		
			   
		declare @FolioID as varchar (500), @FosID as varchar (500), @TipoVersion as varchar (500), @NumCertificado as varchar (500), 
			@RazonSocial as varchar (500), @RFC as varchar (500), @TelefonoContacto as varchar (500), @Calle as varchar (500), @NumExt as varchar (500), @NumInt as varchar (500), @Colonia as varchar (500), 
			@Localidad as varchar (500), @Municipio as varchar (500), @Entidad as varchar (500), @Pais as varchar (500), @CodigoPostal as varchar (500), @ReferenciaDom as varchar (500), 
			@TelefonoEm as varchar (500), @RFCEm as varchar (500), @NombreEm as varchar (500), @CalleEm as varchar (500), @NumExtEm as varchar (500), @NumIntEm as varchar (500), @ColoniaEm as varchar (500), 
			@LocalidadEm as varchar (500), @ReferenciaDomEm as varchar (500), @MunicipioEm as varchar (500), @RegionEM as varchar (500), @PaisEm as varchar (500), @CodigoPostalEm as varchar (500),
			@CalleEx as varchar (500), @NumExtEx as varchar (500), @NumIntEx as varchar (500), @ColoniaEx as varchar (500), @CodigoPostalEx as varchar (500), @ReferenciaDomEx as varchar (500), 
			@LocalidadEx as varchar (500), @MunicipioEx as varchar (500), @EntidadEx as varchar (500), @PaisEx varchar (500),
			@Aprobacion as varchar (500), @AnioAprobacion as varchar (500) 
		DECLARE @Lenguaje AS VARCHAR(20)
		SET @Lenguaje = dbo.FNObtenerLenguaje()

		if exists(select FolioOX from RouteCPC.dbo.FacturasOxxo where IdCedisOX = @idCedis and IdTipoVentaOX = @idTipoVenta 
			and SerieOX = @Serie and FolioOX = @Folio )
		begin			
			select top 1 @idSucursal = ClienteSucursal.IdSucursal, @RFC = RFC, @RazonSocial = RazonSocial, @Calle = isnull(CalleF,''), @NumExt = isnull(NumExteriorF,''), @NumInt = isnull(NumInteriorF,''), @Colonia = isnull(ColoniaF,''),
				@Localidad = isnull(LocalidadF,''), @Municipio = isnull(PoblacionF,''), @Entidad = isnull(EntidadF,''), @Pais = isnull(PaisF,''), @CodigoPostal = isnull(CPF,''), 
				@ReferenciaDom = '', @TelefonoContacto = isnull(TelefonosF,'')
			from RouteCPC.dbo.FacturasOxxo as FacturasOxxo
			inner join RouteCPC.dbo.Ventas as Vtas on FacturasOxxo.IdCedis = Vtas.IdCedis and FacturasOxxo.IdTipoVenta = Vtas.IdTipoVenta  
				and FacturasOxxo.Serie = Vtas.Serie and FacturasOxxo.Folio = Vtas.Folio  
			inner join RouteCPC.dbo.ClienteSucursal as ClienteSucursal on ClienteSucursal.IdCedis = Vtas.IdCedis and Vtas.IdSucursal = ClienteSucursal.IdSucursal 
			where FacturasOxxo.IdCedisOX = @IdCedis and FacturasOxxo.IdTipoVentaOX = @idTipoVenta 
				and FacturasOxxo.SerieOX = @Serie and FacturasOxxo.FolioOX = @Folio 
		end
		else
		begin
			select top 1 @RFC = RFC, @RazonSocial = RazonSocial, @Calle = isnull(CalleF,''), @NumExt = isnull(NumExteriorF,''), @NumInt = isnull(NumInteriorF,''), @Colonia = isnull(ColoniaF,''),
				@Localidad = isnull(LocalidadF,''), @Municipio = isnull(PoblacionF,''), @Entidad = isnull(EntidadF,''), @Pais = isnull(PaisF,''), @CodigoPostal = isnull(CPF,''), 
				@ReferenciaDom = '', @TelefonoContacto = isnull(TelefonosF,'')
			from RouteCPC.dbo.Ventas as Ventas
			inner join RouteCPC.dbo.ClienteSucursal as ClienteSucursal on Ventas.IdCedis = ClienteSucursal.IdCedis and Ventas.IdSucursal = ClienteSucursal.IdSucursal 
			where Ventas.IdCedis = @IdCedis and Ventas.Serie = @Serie and Ventas.IdTipoVenta = @IdTipoVenta and Ventas.Folio = @Folio 
		end
					
		select top 1 @FolioID = Folio.FolioID, @FosID = FosH.FOSId, @TipoVersion = dbo.FNObtenerDescVR('VERFACTE',@Lenguaje,SemHist.VersionCFD), @Aprobacion = Aprobacion, @AnioAprobacion = AnioAprobacion 
		from Route.dbo.SEMHist SemHist
		inner join Route.dbo.SubEmpresa SubE on SubE.SubEmpresaId = SemHist.SubEmpresaId 
		inner join Route.dbo.Folio Folio on SubE.SubEmpresaId = Folio.SubEmpresaId
		inner join Route.dbo.FolioSolicitado FolS on Folio.FolioID = FolS.FolioID 
		inner join Route.dbo.FOSHist FosH on FosH.FolioID = FolS.FolioID and FosH.FOSId = FolS.FOSId 
		where SubE.TipoEstado = 1 and FosH.VendedorID = @USUID and SemHist.DirArchivosFacElec <> ''
		order by SEMHistFechaInicio desc

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

		delete from [Route].[dbo].[TRPDatoFiscal] where TransProdID = @TransprodId 

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
			'', '', @NumCertificado, @Aprobacion, @AnioAprobacion, @SFact, @TipoNotaCredito, 
			@TelefonoEm, @RFCEm, @NombreEm, @CalleEm, @NumExtEm, @NumIntEm, @ColoniaEm, 
			@LocalidadEm, @ReferenciaDomEm, @MunicipioEm, @RegionEM, @PaisEm, @CodigoPostalEm, 
			@CalleEx, @NumExtEx, @NumIntEx, @ColoniaEx, @CodigoPostalEx, @ReferenciaDomEx, @LocalidadEx, @MunicipioEx, @EntidadEx, @PaisEx,
		GETDATE(), @USUID)

	END	
END









GO


