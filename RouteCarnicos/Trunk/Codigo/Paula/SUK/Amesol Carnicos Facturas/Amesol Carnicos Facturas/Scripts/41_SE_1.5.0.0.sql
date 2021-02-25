/****** Object:  Trigger [tg_transfer_Cliente]    Script Date: 05/14/2012 14:43:16 ******/
IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[tg_transfer_Cliente]'))
DROP TRIGGER [dbo].[tg_transfer_Cliente]
/*go*/go

Create TRIGGER [dbo].[tg_transfer_Cliente] ON [dbo].[tmp_Cliente]
FOR INSERT, UPDATE
AS
Declare @LineNumer int            
Declare @ErrDesc varchar(8000)            
Declare @Err int

Declare @TipoLenguaje as Varchar(8)
set @TipoLenguaje = (Select Top 1 TipoLenguaje from Conhist order by CONHistFechaInicio desc)

Declare @ClienteClave varchar(255), @CNPId varchar(255), @Clave varchar(255), @IdElectronico varchar(255), @IdFiscal varchar(255), 
@RazonSocial varchar(255), @TipoFiscal varchar(255), @TipoImpuesto varchar(255), @NombreContacto varchar(255), @TelefonoContacto varchar(255), 
@FechaRegistroSistema varchar(255), @FechaNacimiento varchar(255), @NombreCorto varchar(255), 
@TipoEstado varchar(255),  @SaldoEfectivo varchar(255),@CriterioCredito varchar(255), @Prestamo varchar(255),
@Exclusividad varchar(255), @VigExclusividad varchar(255), @ActualizaSaldoCheque varchar(255), @VencimientoVenta varchar(255), 
@DiasVencimiento varchar(255), @FechaFactura varchar(255), @DesgloseImpuesto varchar(255), @CorreoElectronico varchar(255), @MFechaHora varchar(255), @MUsuarioID varchar(255)

DECLARE @CursorVar1 CURSOR 
SET @CursorVar1 = CURSOR SCROLL DYNAMIC  FOR 
	select ClienteClave, CNPId, Clave, IdElectronico, IdFiscal, RazonSocial, TipoFiscal, TipoImpuesto, NombreContacto, TelefonoContacto, FechaRegistroSistema, 
	FechaNacimiento,  NombreCorto, TipoEstado, 	SaldoEfectivo,CriterioCredito ,Prestamo, Exclusividad, VigExclusividad, ActualizaSaldoCheque, VencimientoVenta, DiasVencimiento, FechaFactura, 
	DesgloseImpuesto, CorreoElectronico, MUsuarioID 
	FROM inserted 

OPEN @CursorVar1
FETCH NEXT FROM @CursorVar1 INTO @ClienteClave, @CNPId, @Clave, @IdElectronico, @IdFiscal, @RazonSocial,@TipoFiscal, @TipoImpuesto, @NombreContacto, @TelefonoContacto, @FechaRegistroSistema, 
@FechaNacimiento,  @NombreCorto, @TipoEstado,@SaldoEfectivo,@CriterioCredito, @Prestamo, @Exclusividad, @VigExclusividad, @ActualizaSaldoCheque, @VencimientoVenta, @DiasVencimiento, @FechaFactura,@DesgloseImpuesto, @CorreoElectronico, @MUsuarioID

WHILE @@FETCH_STATUS = 0 
BEGIN  
          
set @Err = 0
set @LineNumer=1        

--valida ClienteClave
IF @Err=0
begin
	if(@ClienteClave is null or @ClienteClave='')
	BEGIN
		set @ErrDesc = replace(dbo.FNObtenerMensaje('BE0001',@TipoLenguaje),'$0$','ClienteClave')
		RAISERROR (@ErrDesc,16, 1)
		set @Err=@@ERROR                   
	END
end

--valida Clave
IF @Err=0
begin
	if(@Clave is null or @Clave='')
	BEGIN
		set @ErrDesc = replace(dbo.FNObtenerMensaje('BE0001',@TipoLenguaje),'$0$','Clave')
		RAISERROR (@ErrDesc,16, 1)
		set @Err=@@ERROR                   
	END
end
if @Err =0
begin
	if exists(select * from Cliente where Clave=@Clave and clienteclave <>@ClienteClave)
	BEGIN
		set @ErrDesc = replace(replace(dbo.FNObtenerMensaje('E0685',@TipoLenguaje),'$0$',@Clave),'$1$',(select top 1 RazonSocial from Cliente where Clave=@Clave and clienteclave <>@ClienteClave))
		RAISERROR (@ErrDesc,16, 1)
		set @Err=@@ERROR                   
	END
end
--Valida IdElectronico
IF @Err=0
begin
	set @IdElectronico = LTRIM(RTRIM(@IdElectronico))
	IF(@IdElectronico is not null) AND (@IdElectronico <> '') 
	BEGIN
		if exists(select * from Cliente where IdElectronico=@IdElectronico AND ClienteClave <> @ClienteClave  AND TipoEstado<>0)
		BEGIN
			set @ErrDesc = dbo.FNObtenerMensaje('E0617',@TipoLenguaje)
			RAISERROR (@ErrDesc,16, 1)
			set @Err=@@ERROR                   
		END
	END
end
--valida idFiscal
IF @Err=0
begin
	
		if(@IdFiscal is null or @IdFiscal='')	
		BEGIN
			set @ErrDesc = replace(dbo.FNObtenerMensaje('BE0001',@TipoLenguaje),'$0$','IdFiscal')
			RAISERROR (@ErrDesc,16, 1)
			set @Err=@@ERROR                   
		END

--Valida la longitud del IdFiscal
		if @Err = 0
		begin
			set @IdFiscal = replace(@IdFiscal,'-','')
			if len(@IdFiscal) > 14
			begin
				set @ErrDesc = replace(replace(dbo.FNObtenerMensaje('E0718',@TipoLenguaje),'$0$','IdFiscal'),'$1$','14')
				RAISERROR (@ErrDesc,16, 1)
				set @Err=@@ERROR                   
			end
		end
	
end

--valida RazonSocial
IF @Err=0
begin
	if(@RazonSocial is null or @RazonSocial='')	
	BEGIN
		set @ErrDesc = replace(dbo.FNObtenerMensaje('BE0001',@TipoLenguaje),'$0$','RazonSocial')
		RAISERROR (@ErrDesc,16, 1)
		set @Err=@@ERROR                   
	END
end
--Valida Tipo Fiscal
IF @Err=0
begin
	IF not exists(SELECT * FROM VAVDescripcion WHERE VarCodigo='DOCFISC' AND VAVClave=@TipoFiscal AND VADTipoLenguaje=@TipoLenguaje)
	BEGIN
		set @ErrDesc = REPLACE(REPLACE(replace(dbo.FNObtenerMensaje('E0610',@TipoLenguaje),'$0$','TipoFiscal'),'$1$',@TipoFiscal),'$2$','DOCFISCAL')
		RAISERROR (@ErrDesc,16, 1)
		set @Err=@@ERROR                   
	END 
end
--Valida Tipo Impuesto
IF @TipoImpuesto is NULL or @TipoImpuesto=''
   SET @TipoImpuesto=1
IF @Err=0
begin
	IF not exists(SELECT * FROM VAVDescripcion WHERE VarCodigo='IMPCTE' AND VAVClave=@TipoImpuesto AND VADTipoLenguaje=@TipoLenguaje)
	BEGIN
		set @ErrDesc = REPLACE(REPLACE(replace(dbo.FNObtenerMensaje('E0610',@TipoLenguaje),'$0$','TipoImpuesto'),'$1$',@TipoImpuesto),'$2$','IMPCTE')
		RAISERROR (@ErrDesc,16, 1)
		set @Err=@@ERROR                   
	END 
end
--Valida Fecha Registro Sistema
IF @FechaRegistroSistema is NULL or @FechaRegistroSistema=''
   SET @FechaRegistroSistema=Convert(varchar(19),GetDate(),126)

--Valida Tipo Estado
IF @TipoEstado is NULL or @TipoEstado=''
   SET @TipoEstado='1'

IF @Err=0
BEGIN
	IF not exists(SELECT * FROM VAVDescripcion WHERE VarCodigo='EDOREG' AND VAVClave=@TipoEstado AND VADTipoLenguaje=@TipoLenguaje)
	BEGIN
		set @ErrDesc = REPLACE(REPLACE(replace(dbo.FNObtenerMensaje('E0610',@TipoLenguaje),'$0$','TipoEstado'),'$1$',@TipoEstado),'$2$','EDOREG')
		RAISERROR (@ErrDesc,16, 1)
		set @Err=@@ERROR                   
	END
end


--Valida Saldo Efectivo
IF @SaldoEfectivo is NULL or @SaldoEfectivo=''
   SET @SaldoEfectivo=0

---CriterioCredito
IF @CriterioCredito is NULL or @CriterioCredito='' OR isnumeric(@CriterioCredito)<> 1
   SET @CriterioCredito=0
else if cast(@CriterioCredito as float) < 1 AND cast(@CriterioCredito as float) >= 0
   SET @CriterioCredito=0


IF ISNUMERIC(@CriterioCredito)<> 1
BEGIN
	set @ErrDesc = replace(dbo.FNObtenerMensaje('E0313',@TipoLenguaje),'$0$','CriterioCredito')
	RAISERROR (@ErrDesc,16, 1)
	set @Err=@@ERROR 
	
END
ELSE
BEGIN
	IF(CAST(@CriterioCredito AS float) <0.00  OR CAST(@CriterioCredito AS float) > 1.00)
	BEGIN
		set @ErrDesc = REPLACE(REPLACE(replace(dbo.FNObtenerMensaje('E0604',@TipoLenguaje),'$0$','CriterioCredito'),'$1$','0'),'$2$','1')
		RAISERROR (@ErrDesc,16, 1)
		set @Err=@@ERROR 
	END
END

--Valida Prestamo
IF @Prestamo is NULL or @Prestamo=''
   SET @Prestamo=0

--Valida Exclusividad
IF @Exclusividad is NULL or @Exclusividad=''
   SET @Exclusividad=0

--Valida Vigencia Exclusividad
IF @VigExclusividad is NULL or ltrim(rtrim(@VigExclusividad))=''
   SET @VigExclusividad='9998-01-01T00:00:00'

--Valida ActualizaSaldoCheque
IF @ActualizaSaldoCheque is NULL or ltrim(rtrim(@ActualizaSaldoCheque))=''
   SET @ActualizaSaldoCheque=1

--Valida VencimientoVenta
IF @VencimientoVenta is NULL or ltrim(rtrim(@VencimientoVenta))=''
   SET @VencimientoVenta=0

--Valida DiasVencimiento
IF @DiasVencimiento is NULL or ltrim(rtrim(@DiasVencimiento))=''
   SET @DiasVencimiento=0

--Valida FechaFactura
IF @FechaFactura is NULL or ltrim(rtrim(@FechaFactura))='' OR (isdate(@FechaFactura)= 0)
	SET @FechaFactura ='9998-01-01T00:00:00'
	
--Valida DesgloseImpuesto
IF @DesgloseImpuesto is NULL or @DesgloseImpuesto=''
   SET @DesgloseImpuesto=0

 --Verificar que si tenga Datos en MFechaHora
IF @MFechaHora is NULL
   SET @MFechaHora=Convert(varchar(19),GetDate(),126)

--Valida MUsuarioId
IF @MUsuarioID IS NULL or @MUsuarioID=''
	SET @MUsuarioID='Interfaz'
ELSE
BEGIN
	IF exists(SELECT USUId FROM Usuario WHERE Clave=@MUsuarioID)
		SET @MUsuarioID=(SELECT USUId FROM Usuario WHERE Clave=@MUsuarioID)
	ELSE
	BEGIN
		IF @Err=0
		BEGIN
			set @ErrDesc = dbo.FNObtenerMensaje('E0612',@TipoLenguaje)
			RAISERROR (@ErrDesc,16, 1)
			set @Err=@@ERROR                   
		END
	END  
END

--Verificar que si exista el registro        
IF @Err=0
BEGIN 
	IF exists(select * from Cliente where ClienteClave=@ClienteClave )        
	Begin            
		UPDATE [dbo].[Cliente] Set Clave=@Clave,IdElectronico=@IdElectronico,IdFiscal=@IdFiscal,RazonSocial=@RazonSocial,TipoFiscal=@TipoFiscal,TipoImpuesto=@TipoImpuesto,NombreContacto=@NombreContacto,TelefonoContacto=@TelefonoContacto,FechaRegistroSistema=@FechaRegistroSistema,FechaNacimiento=@FechaNacimiento,NombreCorto=@NombreCorto,TipoEstado=@TipoEstado,LimiteDescuento=0,SaldoEfectivo=@SaldoEfectivo,CriterioCredito=@CriterioCredito,Prestamo=@Prestamo,Exclusividad=@Exclusividad,VigExclusividad=@VigExclusividad,ActualizaSaldoCheque=@ActualizaSaldoCheque,VencimientoVenta=@VencimientoVenta,DiasVencimiento=@DiasVencimiento,FechaFactura= @FechaFactura, DesgloseImpuesto = @DesgloseImpuesto, CorreoElectronico=@CorreoElectronico, MFechaHora=@MFechaHora,MUsuarioID=@MUsuarioID where (ClienteClave=@ClienteClave)
	End         
	Else         
	Begin
		INSERT INTO [dbo].[Cliente](ClienteClave,CNPId,Clave,IdElectronico,IdFiscal,RazonSocial,TipoFiscal,TipoImpuesto,NombreContacto,TelefonoContacto,FechaRegistroSistema,FechaNacimiento,NombreCorto,TipoEstado,LimiteDescuento,SaldoEfectivo,CriterioCredito,Prestamo,Exclusividad,VigExclusividad,ActualizaSaldoCheque,VencimientoVenta,DiasVencimiento,FechaFactura,DesgloseImpuesto,CorreoElectronico,ExigirOrdenCompra, MFechaHora,MUsuarioID) VALUES( @ClienteClave, NULL, @Clave, @IdElectronico, @IdFiscal, @RazonSocial, @TipoFiscal, @TipoImpuesto, @NombreContacto, @TelefonoContacto, @FechaRegistroSistema, @FechaNacimiento, @NombreCorto, @TipoEstado, 0, @SaldoEfectivo, @CriterioCredito ,@Prestamo, @Exclusividad, @VigExclusividad, @ActualizaSaldoCheque, @VencimientoVenta, @DiasVencimiento,@FechaFactura, @DesgloseImpuesto, @CorreoElectronico, 0,@MFechaHora, @MUsuarioID)          
	end

--Crear o modifica el Registro de Auditoría
	IF exists(select * from AuditoriaObjeto where AOBTipoObjeto=6)
	Begin
		 UPDATE [dbo].AuditoriaObjeto Set Correcto=0,MFechaHora=GetDate(),MUsuarioID=@MUsuarioID where (AOBTipoObjeto=6)
	End 
	Else 
	Begin
		INSERT INTO [dbo].AuditoriaObjeto(AOBTipoObjeto,Correcto,MFechaHora,MUsuarioID)	VALUES(6, 0, GetDate(), @MUsuarioID)  
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
		values (@LineNumer,'Cliente',@Err, @ErrDesc, getDate(),'Admin')            
END

	FETCH NEXT FROM @CursorVar1 INTO @ClienteClave, @CNPId, @Clave, @IdElectronico, @IdFiscal, @RazonSocial,@TipoFiscal, @TipoImpuesto, @NombreContacto, @TelefonoContacto, @FechaRegistroSistema, 
	@FechaNacimiento,  @NombreCorto, @TipoEstado,@SaldoEfectivo, @CriterioCredito,@Prestamo, @Exclusividad, @VigExclusividad, @ActualizaSaldoCheque, @VencimientoVenta, @DiasVencimiento, @FechaFactura,@DesgloseImpuesto, @CorreoElectronico, @MUsuarioID
END

CLOSE @CursorVar1
DEALLOCATE @CursorVar1

/*go*/go


