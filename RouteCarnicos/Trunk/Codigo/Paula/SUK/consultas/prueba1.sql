/****** Object:  Trigger [tg_transfer_tmp_CargaDetalle]    Script Date: 05/14/2012 12:40:49 ******/
IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[tg_transfer_tmp_CargaDetalle]'))
DROP TRIGGER [dbo].[tg_transfer_tmp_CargaDetalle]
/*go*/go
CREATE Trigger [dbo].[tg_transfer_tmp_CargaDetalle]
on [dbo].[tmp_CargaDetalle] for INSERT,UPDATE
AS
Declare  @CargaId varchar(255) , @CargaDetalleId varchar(255) , @ProductoClave varchar(255) , @CodigoSKU varchar(255), 
	@TipoUnidad varchar(255) , @Partida varchar(255) , @Cantidad varchar(255) , @Cantidad1 varchar(255) , @MFechaHora varchar(255), 
	@MUsuarioId varchar(255) 

	DECLARE @CursorVar1 CURSOR 
	SET @CursorVar1 = CURSOR SCROLL DYNAMIC  FOR 
			select CargaId,CargaDetalleId,ProductoClave,CodigoSKU,TipoUnidad,Partida,Cantidad,Cantidad1  FROM inserted

	OPEN @CursorVar1
	FETCH NEXT FROM @CursorVar1 INTO @CargaId,@CargaDetalleId,@ProductoClave,@CodigoSKU,@TipoUnidad,@Partida,@Cantidad,@Cantidad1 

	WHILE @@FETCH_STATUS = 0 
	BEGIN  

		Declare @LineNumer int    
		Declare @ErrDesc varchar(8000)    
		Declare @Err int    

		Set @LineNumer=1
		set @Err = 0

		declare @TipoLenguaje as varchar(8), @ModuloClave varchar(255)
		set @TipoLenguaje = (select top 1 TipoLenguaje from Conhist order by CONHistFechaInicio)

		IF @CodigoSKU is null
			set @CodigoSKU=''
		
		IF (not @Cantidad is null) and (isnumeric(@Cantidad)=1)
		BEGIN 
			IF cast(@Cantidad as float)<=0
			BEGIN
				IF @Err=0
				BEGIN
					set @ErrDesc = (select TOP 1 REPLACE(Descripcion, '$0$', 'Cantidad') from Mendetalle where MENClave='E0334' and MEDTipoLenguaje=@TipoLenguaje)
					RAISERROR (@ErrDesc,16, 1)
					set @Err=@@ERROR      			
				END
			END 									
		END
		
		IF @Cantidad1 is null or @Cantidad1=''
			set @Cantidad1='1'

		IF isnumeric(@Cantidad1)=1
		BEGIN 
			IF cast(@Cantidad1 as float)<=0
			BEGIN
				IF @Err=0
				BEGIN
					set @ErrDesc = (select TOP 1 REPLACE(Descripcion, '$0$', 'Cantidad1') from Mendetalle where MENClave='E0334' and MEDTipoLenguaje=@TipoLenguaje)
					RAISERROR (@ErrDesc,16, 1)
					set @Err=@@ERROR      			
				END
			END 									
		END
		
		--Verificar que si tenga Datos en MFechaHora
		IF @MFechaHora is NULL or @MFechaHora=''
		   SET @MFechaHora=Convert(varchar(28),GetDate(),126)

		IF (Select count(*) from TransProd where TransProdID=@CargaId) = 0
		BEGIN
			IF @Err=0
			BEGIN
				set @ErrDesc = (select TOP 1 REPLACE(Descripcion, '$0$', dbo.FNObtenerMensaje('XCarga','EM')) from Mendetalle where MENClave='E0739' and MEDTipoLenguaje=@TipoLenguaje)
				RAISERROR (@ErrDesc,16, 1)
				set @Err=@@ERROR      
			END			
		END

		--Valida MUsuarioId
		SET @MUsuarioId=(select MUsuarioID from TransProd where TransProdid=@CargaId)
		if @MUsuarioId is NULL or @MUsuarioId=''
			IF @Err=0
			BEGIN
				set @ErrDesc = (select TOP 1 Descripcion from Mendetalle where MENClave='E0612' and MEDTipoLenguaje=@TipoLenguaje)
				RAISERROR (@ErrDesc,16, 1)
				set @Err=@@ERROR      
			END

		IF(SELECT Count(*) FROM VARValor WheRE VARCodigo = 'UNIDADV' AND VAVClave = @TipoUnidad)= 0 
		BEGIN
			IF @Err=0
			BEGIN
				set @ErrDesc = (REPLACE(REPLACE(REPLACE(dbo.FNObtenerMensaje('E0610',@TipoLenguaje),
									'$0$','TipoUnidad'),
									'$1$',@TipoUnidad),
									'$2$','UNIDADV'))
				RAISERROR (@ErrDesc,16, 1)
				set @Err=@@ERROR           
			END
		END
		--Verificar que si exista el registro
		IF @Err=0
		BEGIN
			IF exists(select * from TransProdDetalle where TransProdId=@CargaId AND TransProdDetalleId=@CargaDetalleId)
			Begin
				UPDATE [dbo].[TransProdDetalle] Set ProductoClave=@ProductoClave, CodigoSKU=@CodigoSKU,TipoUnidad=@TipoUnidad, Partida=@Partida, Cantidad=@Cantidad, Cantidad1=CASE WHEN @CodigoSKU = '' THEN @Cantidad1 ELSE 1 END, Precio=0, Subtotal=0, Total=0, MFechaHora=@MFechaHora, MUsuarioId=@MUsuarioId where TransProdId=@CargaId AND TransProdDetalleId=@CargaDetalleId
			End 
			Else 
			Begin
				INSERT INTO [dbo].[TransProdDetalle](TransProdId,TransProdDetalleId,ProductoClave,CodigoSKU,TipoUnidad,Partida,Cantidad,Cantidad1,Precio,Subtotal,Total,MFechaHora,MUsuarioId)
				VALUES(@CargaId, @CargaDetalleId, @ProductoClave, @CodigoSKU, @TipoUnidad, @Partida, @Cantidad,CASE WHEN @CodigoSKU = '' THEN @Cantidad1 ELSE 1 END,0,0,0,@MFechaHora,@MUsuarioId)  
			End
			set @Err=@@ERROR    
		END

		IF @Err<>0     
		BEGIN    
			If @Err=2627   
				set @ErrDesc='Error de restricción, llave primaria duplicada'  
			Else  
				select distinct top 1 @ErrDesc=description from master.dbo.sysmessages where error=@Err    
			    
			INSERT INTO ErrorLog(LineNumber,DTSName,SQLErrNumber,Descripcion,MFechaHora,MUsuarioID)    
			values (@LineNumer,'tmp_CargaDetalle',@Err, @ErrDesc, getDate(),'Admin')    
		END    

	FETCH NEXT FROM @CursorVar1 INTO @CargaId,@CargaDetalleId,@ProductoClave,@CodigoSKU,@TipoUnidad,@Partida,@Cantidad,@Cantidad1
	END

	CLOSE @CursorVar1
	DEALLOCATE @CursorVar1
/*go*/go


