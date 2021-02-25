/****** Object:  Trigger [tg_transfer_VentaFacturadaDet]    Script Date: 05/16/2012 19:09:37 ******/
IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[tg_transfer_VentaFacturadaDet]'))
DROP TRIGGER [dbo].[tg_transfer_VentaFacturadaDet]
/*go*/go

CREATE trigger [dbo].[tg_transfer_VentaFacturadaDet] on [dbo].[tmp_VentaFacturadaDet]
for insert, update
as
declare @TransProdID varchar(255),@TransProdDetalleID varchar(255),@ProductoClave varchar(255),@CodigoSKU varchar(255), @UnidadCobranza varchar(255),
			@Partida varchar(255),@Cantidad varchar(255),@Cantidad1 varchar(255),@Precio varchar(255),@Subtotal varchar(255),@Impuesto varchar(255),@Total varchar(255)
	declare @LineNumer int    
	declare @ErrDesc varchar(8000) 
	declare @Err int  
	Declare @TipoLenguaje as Varchar(8)
	Declare @MUsuarioID as Varchar(16)
	Declare @MFechaHora as datetime
			
	set @TipoLenguaje = dbo.FNObtenerLenguaje()	
	set @MFechaHora = getdate()
	
	DECLARE @CursorVar1 CURSOR 
	SET @CursorVar1 = CURSOR SCROLL DYNAMIC  FOR 
		select TransProdID, TransProdDetalleID, ProductoClave,  CodigoSKU,UnidadCobranza, Partida, Cantidad, Cantidad1, Precio,
		Subtotal, Impuesto, Total FROM inserted

	OPEN @CursorVar1
	FETCH NEXT FROM @CursorVar1 INTO @TransProdID, @TransProdDetalleID, @ProductoClave,  @CodigoSKU, @UnidadCobranza,
		@Partida, @Cantidad,@Cantidad1, @Precio, @Subtotal, @Impuesto, @Total

	WHILE @@FETCH_STATUS = 0 
	BEGIN 

		set @LineNumer = 1
		set @Err = 0
		
		--Valida TransProdID
		if not exists(SELECT Transprodid FROM Transprod WHERE Transprodid=@TransprodID)
		begin
			set @ErrDesc =  dbo.FNObtenerMensaje('E0738',@TipoLenguaje)
			RAISERROR (@ErrDesc,16, 1)
			set @Err=@@ERROR                   
		end
		
		--Inicializar Valores
		if @Partida is null or @Partida=''
			set @Partida=1		
		if @SubTotal is null or @SubTotal =''
			set @SubTotal=0
		if @Precio is null or @Precio =''
			set @Precio=0
		if @Impuesto is null or @Impuesto =''
			set @Impuesto=0
		if @Total is null or @Total =''
			set @Total=0
		if @Cantidad1 is null or @Cantidad1=''
			set @Cantidad1=1	
			

			
		declare @DescuentoImp as int
			set @DescuentoImp =0
		
		--Valida UnidadCobranza
		IF not exists(SELECT * FROM VAVDescripcion WHERE VarCodigo='UCOBRA' AND VAVClave=@UnidadCobranza AND VADTipoLenguaje=@TipoLenguaje)
		BEGIN
			set @ErrDesc = (replace(dbo.FNObtenerMensaje('BE0003',@TipoLenguaje),'$0$','unidad Cobranza'))
			RAISERROR (@ErrDesc,16, 1)
			set @Err=@@ERROR                   
		END 
		
		

		if @CodigoSKU is null
			set @CodigoSKU=''		
			

		IF (not @Cantidad is null) and (isnumeric(@Cantidad)=1)
		BEGIN 
			IF cast(@Cantidad as float)<=0
			BEGIN
				IF @Err=0
				BEGIN
					set @ErrDesc = (REPLACE(dbo.FNObtenerMensaje('E0334',@TipoLenguaje), '$0$', 'Cantidad'))
					RAISERROR (@ErrDesc,16, 1)
					set @Err=@@ERROR      			
				END
			END 									
		END
		
		IF isnumeric(@Cantidad1)=1
		BEGIN 
			IF cast(@Cantidad1 as float)<=0
			BEGIN
				IF @Err=0
				BEGIN
					set @ErrDesc = (REPLACE(dbo.FNObtenerMensaje('E0334',@TipoLenguaje), '$0$', 'Cantidad1'))
					RAISERROR (@ErrDesc,16, 1)
					set @Err=@@ERROR      			
				END
			END 									
		END
		
		DECLARE @Ubase AS SMALLINT
		DECLARE @Contenido AS FLOAT
		DECLARE @Factor AS FLOAT
		DECLARE @Factor1 AS FLOAT
		-- 1 Piezas Cantidad1 Factor1
		-- 2 Kilos Cantidad Factor
		
		IF (SELECT count(*) FROM UnidadCobranza WHERE (ProductoClave = @ProductoClave OR ProductoClave is null) AND UnidadCobranza = @UnidadCobranza and TipoEstado = 1 ) >= 1
		BEGIN
			SELECT TOP 1 @Contenido = Contenido,@Ubase = UnidadBase   FROM UnidadCobranza WHERE ProductoClave = @ProductoClave AND UnidadCobranza = @UnidadCobranza			
			IF (@Contenido IS NULL) OR (@Ubase IS NULL)
				SELECT TOP 1 @Contenido = Contenido,@Ubase = UnidadBase   FROM UnidadCobranza WHERE ProductoClave is null AND UnidadCobranza = @UnidadCobranza
			IF @Ubase = 1
			BEGIN
				SET @Factor = 0
				SET @Factor1 = @Contenido
			END
			ELSE IF @Ubase = 2
			BEGIN
				SET @Factor = @Contenido
				SET @Factor1 = 0
			END
		END
		ELSE
		BEGIN
			set @ErrDesc = (replace(replace(replace(dbo.FNObtenerMensaje('E0778',@TipoLenguaje),'$0$',@ProductoClave),'$1$',@UnidadCobranza),'$2$','Unidad'))
			RAISERROR (@ErrDesc,16, 1)
			set @Err=@@ERROR
		END
		
		
		if @Err=0
		begin
		
			set @MUsuarioID = (select MUsuarioId from Transprod where TransProdID=@TransProdID)
			IF not exists(select * from TransProdDetalle where TransProdId=@TransProdID AND ((@CodigoSKU <> '' and CodigoSKU=@CodigoSKU) or (@CodigoSKU = '' and CodigoSKU = @CodigoSKU and ProductoClave = @ProductoClave)))
			begin
--  				update [dbo].[TransProdDetalle] set ProductoClave=@ProductoClave,TipoUnidad=4,TransProdDetalleID=@TransProdDetalleID,UnidadCobranza=@UnidadCobranza,
--  				Partida=@Partida, Cantidad=@Cantidad,Cantidad1=CASE WHEN @CodigoSKU = '' THEN @Cantidad1 ELSE 1 END, 
--  				Factor = @Factor, Factor1 = @Factor1,
--  				Precio=@Precio, Subtotal=@Subtotal, Impuesto=@Impuesto, Total=@Total,
--  				MFechaHora=@MFechaHora,MUsuarioID=@MUsuarioID
--  				where (TransProdID=@TransProdID and TransProdDetalleID=@TransProdDetalleID)
--			end 
--			else 
--			begin
				insert into [dbo].[TransProdDetalle] 
					(	TransProdID,TransProdDetalleID,ProductoClave,TipoUnidad,CodigoSKU,
						UnidadCobranza,Partida,Cantidad,Cantidad1, Factor, Factor1, 
						Precio,DescuentoPor,Promocion,TipoFaseIntSal,Subtotal,Impuesto,DescuentoImp, Total,MFechaHora,MUsuarioID)
  				values
  					(	@TransProdID,@TransProdDetalleID,@ProductoClave,4,@CodigoSKU,
  						@UnidadCobranza,@Partida, @Cantidad,CASE WHEN @CodigoSKU = '' THEN @Cantidad1 ELSE 1 END,@Factor, @Factor1, 
  						@Precio, 0,0,0,@Subtotal, @Impuesto,@DescuentoImp, @Total,@MFechaHora,@MUsuarioID)			
  						

				DECLARE @ImpuestoClave varchar(10), @ImpuestoPor float, @ImpuestoImp float, @TipoAplicacion smallint,@TotalImp float,
				@ImpuestoPU float, @TotalImpPU float

				DECLARE @CursorImpuestos CURSOR 
				SET @CursorImpuestos  = CURSOR SCROLL DYNAMIC  FOR 
					select IMV.ImpuestoClave, IMV.Valor, IMP.TipoAplicacion  from ImpuestoVig IMV
					inner join ProductoImpuesto PRI on IMV.ImpuestoClave = PRI.ImpuestoClave
					inner join Impuesto IMP on IMV.ImpuestoClave = IMP.ImpuestoClave
					where getdate() between FechaInicial and FechaFinal and IMP.TipoEstado = 1
					and PRI.ProductoClave = @ProductoClave and PRI.TipoEstado = 1
					order by IMP.Jerarquia
					
				OPEN @CursorImpuestos  
				FETCH NEXT FROM @CursorImpuestos INTO @ImpuestoClave, @ImpuestoPor, @TipoAplicacion


				set @TotalImp = 0
				set @TotalImpPU = 0
				WHILE @@FETCH_STATUS = 0 
				BEGIN 
					
					If (@TipoAplicacion = 1)
					Begin
						set @ImpuestoImp = (@Subtotal * (@ImpuestoPor/100))	
						set @ImpuestoPU = (@Precio * (@ImpuestoPor/100)) 
					End
					Else
					Begin
						set @ImpuestoImp = ((@Subtotal + @TotalImp) * (@ImpuestoPor/100))	
						set @ImpuestoPU = ((@Precio + @TotalImpPU) * (@ImpuestoPor/100)) 
					End
					
					set @TotalImp = @TotalImp + @ImpuestoImp
					set @TotalImpPU = @TotalImpPU + @ImpuestoPU 
					
					If(Select count(*) from TPDImpuesto where TransProdID = @TransProdId and TransProdDetalleID = @TransProdDetalleID and ImpuestoClave = @ImpuestoClave) = 0
					BEGIN
						INSERT INTO TPDImpuesto(TransProdId, TransProdDetalleID, TPDImpuestoID, ImpuestoClave, ImpuestoPor, ImpuestoImp, ImpuestoPU,ImpDesGlb, MFechaHora, MUsuarioID)
						VALUES(@TransProdId, @TransProdDetalleID,  (cast(replace(cast(NEWID() as varchar(36)),'-','') as varchar(16))),@ImpuestoClave, @ImpuestoPor, @ImpuestoImp,@ImpuestoPU ,0 , getdate(), 'Interfaz')
					END
					Else
					BEGIN
						UPDATE TPDImpuesto set ImpuestoPor = @ImpuestoPor, ImpuestoImp = @ImpuestoImp, ImpuestoPU = @ImpuestoPU, ImpDesGlb = 0, MFechaHora = getdate(), MUsuarioID = 'Interfaz'
						WHERE TransProdID = @TransProdId and TransProdDetalleID = @TransProdDetalleID and ImpuestoClave = @ImpuestoClave
					END 
				FETCH NEXT FROM @CursorImpuestos INTO @ImpuestoClave, @ImpuestoPor, @TipoAplicacion
				END

				CLOSE @CursorImpuestos
				DEALLOCATE @CursorImpuestos  						
			end
		  		  
  			--Crear o modifica el Registro de Auditoría
			IF exists(select * from AuditoriaObjeto where AOBTipoObjeto=16)
			Begin
				 UPDATE [dbo].AuditoriaObjeto Set Correcto=0,MFechaHora=GetDate(),MUsuarioID=@MUsuarioID where (AOBTipoObjeto=16)
			End 
			Else 
			Begin
				INSERT INTO [dbo].AuditoriaObjeto(AOBTipoObjeto,Correcto,MFechaHora,MUsuarioID)
				VALUES(16, 0, GetDate(), @MUsuarioID)  
			End
			set @Err=@@ERROR  
			
		end
		else
		begin    
			if @Err=2627   
				set @ErrDesc='Error de restricción, llave primaria duplicada'  
			else  
				select distinct top 1 @ErrDesc=description from master.dbo.sysmessages where error=@Err    
	    
			insert into ErrorLog(LineNumber,DTSName,SQLErrNumber,Descripcion,MFechaHora,MUsuarioID)    
			values (@LineNumer,'TransProd(Pedido)',@Err, @ErrDesc, getDate(),'Admin')    
		end
			
		
	FETCH NEXT FROM @CursorVar1 INTO @TransProdID, @TransProdDetalleID, @ProductoClave,  @CodigoSKU, @UnidadCobranza,
		@Partida, @Cantidad,@Cantidad1, @Precio, @Subtotal, @Impuesto, @Total

	END

CLOSE @CursorVar1
DEALLOCATE @CursorVar1

/*go*/go


