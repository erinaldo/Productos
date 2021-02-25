/****** Object:  Trigger [tg_transfer_VentaFacturada]    Script Date: 05/14/2012 11:13:46 ******/
IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[tg_transfer_VentaFacturada]'))
DROP TRIGGER [dbo].[tg_transfer_VentaFacturada]
/*go*/go

create trigger [dbo].[tg_transfer_VentaFacturada] on [dbo].[tmp_VentaFacturada]
for insert, update
as
declare  @TransProdID varchar(255),@DiaClave varchar(255),@Modulo varchar(255), @FacturaID varchar(255) ,@ClienteClave varchar(255), @ClientePagoID varchar(255) ,@CFVTipo varchar(255) , @Folio varchar(255) ,
	@TipoFase varchar(255) ,@FechaHoraAlta varchar(255), @FechaEntrega varchar(255), @FechaFacturacion varchar(255), @FechaCancelacion varchar(255) , @Subtdetalle varchar(255), 
	@DescVendPor varchar(255), @DescuentoImp varchar(255), @Subtotal varchar(255), @Impuesto varchar(255), @Total varchar(255), @Saldo varchar(255),
	@MonedaId varchar(255),@TipoCambio varchar(255),@FechaCobranza varchar(255), @DiasCredito varchar(255), @ClaveUsuario varchar(255)
 
declare @LineNumer int    
declare @ErrDesc varchar(8000)    
declare @Err int    
declare @Moneda varchar(255) 
declare @MUsuarioID varchar(16)
declare @VendedorID varchar(16)
declare @VisitaClave varchar(16)
declare @DiaClaveFormFecha datetime
declare @MFechaHora datetime

declare @CodigoMon varchar(255) 
declare @MonedaDesc  varchar(255)

declare @SubEmpresaID varchar(16)

set @SubEmpresaID = (Select Top 1 SubEmpresaID from SubEmpresa where TipoEstado = 1)

set @FacturaID=null
set @TipoFase=1
set @FechaEntrega=null
set @FechaFacturacion=null
set @FechaCancelacion=null
set @DescVendPor=0
set @DescuentoImp=0

Declare @TipoLenguaje as Varchar(8)
set @TipoLenguaje = dbo.FNObtenerLenguaje()

	SET @MonedaDesc=dbo.FNObtenerMensaje('CMoneda',@TipoLenguaje)
	

DECLARE @CursorVar1 CURSOR 
SET @CursorVar1 = CURSOR SCROLL DYNAMIC  FOR 
	select TransProdID,  DiaClave, Modulo, ClienteClave, ClientePagoID, CFVTipo, Folio, FechaHoraAlta,
  Subtdetalle, Subtotal, Impuesto, Total, Saldo, CodigoMon,TipoCambio,FechaCobranza, DiasCredito, ClaveUsuario  FROM inserted

OPEN @CursorVar1
FETCH NEXT FROM @CursorVar1 INTO @TransProdID ,  @DiaClave, @Modulo, @ClienteClave, @ClientePagoID, @CFVTipo, @Folio, @FechaHoraAlta,
@Subtdetalle, @Subtotal, @Impuesto, @Total, @Saldo,@CodigoMon,@TipoCambio, @FechaCobranza, @DiasCredito, @ClaveUsuario

WHILE @@FETCH_STATUS = 0 
BEGIN 

set @LineNumer = 1
set @Err = 0

set @DiaClaveFormFecha = convert (datetime, @DiaClave ,103)
set @MFechaHora = getdate()

set @Saldo = 0

--Valida Clave Usuario
IF exists(SELECT USUId FROM Usuario WHERE Clave=@ClaveUsuario)
BEGIN
	SET @MUsuarioID=(SELECT USUId FROM Usuario WHERE Clave=@ClaveUsuario)
	if not exists(SELECT TOP 1 VendedorId FROM Vendedor WHERE USUId=@MUsuarioID)
	begin
		set @ErrDesc =  replace(dbo.FNObtenerMensaje('E0211',@TipoLenguaje),'$0$',@ClaveUsuario)
		RAISERROR (@ErrDesc,16, 1)
		set @Err=@@ERROR                   
	end
	else
		SET @VendedorID=(SELECT TOP 1 VendedorId FROM Vendedor WHERE USUId=@MUsuarioID)
END
ELSE
BEGIN
	IF @Err=0
	BEGIN
		set @ErrDesc = dbo.FNObtenerMensaje('E0612',@TipoLenguaje)
		RAISERROR (@ErrDesc,16, 1)
		set @Err=@@ERROR                   
	END
END 

--Valida ClienteClave
IF not exists(SELECT * FROM Cliente WHERE ClienteClave=@ClienteClave )
BEGIN
	set @ErrDesc = dbo.FNObtenerMensaje('E0027',@TipoLenguaje)
	RAISERROR (@ErrDesc,16, 1)
	set @Err=@@ERROR                   
END 

--Valida ClientePagoID
IF not exists(SELECT * FROM VAVDescripcion WHERE VarCodigo='PAGO' AND VAVClave=@ClientePagoID AND VADTipoLenguaje=@TipoLenguaje)
BEGIN
	set @ErrDesc = replace(replace(replace(dbo.FNObtenerMensaje('E0610',@TipoLenguaje),'$0$','ClientePagoID'),'$1$',@ClientePagoID),'$2$','PAGO')
	RAISERROR (@ErrDesc,16, 1)
	set @Err=@@ERROR                   
END 

DECLARE @GrupoPago Varchar(20), @EstadoPago as Smallint
SELECT @GrupoPago = isnull(Grupo,''), @EstadoPago = Estado FROM VARValor WHERE VarCodigo='PAGO' AND VAVClave=@ClientePagoID

IF @Err=0
BEGIN
	IF @EstadoPago = 0
	BEGIN
		set @ErrDesc = replace(replace(replace(dbo.FNObtenerMensaje('E0760',@TipoLenguaje),'$0$','Tipo'),'$1$',@ClientePagoID),'$2$','PAGO')
		RAISERROR (@ErrDesc,16, 1)
		set @Err=@@ERROR   						
	END
END

IF @Err=0
BEGIN
	IF @GrupoPago = ''
	BEGIN
		set @ErrDesc = replace(replace(dbo.FNObtenerMensaje('E0758',@TipoLenguaje),'$0$','Tipo'),'$1$',@ClientePagoID)
		RAISERROR (@ErrDesc,16, 1)
		set @Err=@@ERROR   						
	END
END

--Valida CFVTipo
IF not exists(SELECT * FROM VAVDescripcion WHERE VarCodigo='FVENTA' AND VAVClave=@CFVTipo AND VADTipoLenguaje=@TipoLenguaje)
BEGIN
	set @ErrDesc = replace(replace(replace(dbo.FNObtenerMensaje('E0610',@TipoLenguaje),'$0$','CFVTipo'),'$1$',@CFVTipo),'$2$','FVENTA')
	RAISERROR (@ErrDesc,16, 1)
	set @Err=@@ERROR                   
END 

--Valida TipoFase
IF not exists(SELECT * FROM VAVDescripcion WHERE VarCodigo='TRPFASE' AND VAVClave=@TipoFase AND VADTipoLenguaje=@TipoLenguaje)
BEGIN	
	set @ErrDesc = replace(replace(replace(dbo.FNObtenerMensaje('E0610',@TipoLenguaje),'$0$','TipoFase'),'$1$',@TipoFase),'$2$','TRPFASE')
	RAISERROR (@ErrDesc,16, 1)
	set @Err=@@ERROR                   
END 

--valida @CodigoMon

	if exists(select MonedaId from moneda m WHERE MonedaId = @CodigoMon)
	begin
		if (select TipoEstado from moneda m inner join vavdescripcion v on descripcion = @CodigoMon and v.vavclave=m.tipocodigo and vadtipolenguaje='EM' and varcodigo='CDGOMON' )=0
		begin
			set @ErrDesc = (replace(dbo.FNObtenerMensaje('E0264',@TipoLenguaje),'$0$',@MonedaDesc))
			RAISERROR (@ErrDesc,16, 1)
			set @Err=@@ERROR  
		end
		else
			set @MonedaId=@CodigoMon
			
			if @MonedaId=(select top 1 monedaid from conhist order by conhistfechainicio desc)
				set @TipoCambio=1
	end
	else
	begin
			set @ErrDesc = (Replace(dbo.FNObtenerMensaje('BE0003',@TipoLenguaje),'$0$',@MonedaDesc))
			RAISERROR (@ErrDesc,16, 1)
			set @Err=@@ERROR  
	end
	
--valida @TipoCambio

	if @TipoCambio is null  or @TipoCambio =''
	begin
		set @ErrDesc = (Replace(dbo.FNObtenerMensaje('E0334',@TipoLenguaje),'$0$','Tipo Cambio'))
		RAISERROR (@ErrDesc,16, 1)
		set @Err=@@ERROR  
	end	
	else if CAST(@TipoCambio as FLOAT) <= 0.00	
	begin	
		set @ErrDesc = (Replace(dbo.FNObtenerMensaje('E0334',@TipoLenguaje),'$0$','Tipo Cambio'))
		RAISERROR (@ErrDesc,16, 1)
		set @Err=@@ERROR 
	end
--Validaciones
if @Err=0
	if (select count(*) from Ruta where RUTClave ='RUT001')<=0
		insert into Ruta(RUTClave,Descripcion,Tipo,TipoEstado,Inventario,MFechaHora,MUsuarioID) values('RUT001','Ruta de importación de pedidos',2,1,0,@MFechaHora,@MUsuarioID)

if @Err=0
	if (Select count(*) from Dia where DiaClave =@DiaClave)<=0
		insert into Dia(DiaClave,Referencia,Estado,FechaCaptura,MFechaHora,MUsuarioID) values(@DiaClave,'',1,@DiaClaveFormFecha,@MFechaHora,@MUsuarioID)
if @Err=0
	if (select count(*) from Visita where DiaClave = @DiaClave and ClienteClave = @ClienteClave and RUTClave ='RUT001')<=0
	begin
		insert into visita(VisitaClave, DiaClave,ClienteClave,VendedorID,RUTClave,Numero,FechaHoraInicial,FechaHoraFinal,TipoEstado,FueraFrecuencia,CodigoLeido,MFechaHora,MUsuarioID) values(@ClienteClave, @DiaClave,@ClienteClave, @VendedorID, 'RUT001', 1,getdate(),getdate(),1,0,0,@MFechaHora,@MUsuarioID)
		set @VisitaClave = @ClienteClave

	end	
	else
	begin 
		set @VisitaClave = (select top 1 VisitaClave from Visita where DiaClave = @DiaClave and ClienteClave = @ClienteClave and RUTClave ='RUT001' )
	end	

if @Modulo <> '9'
	IF @Err=0
	begin
		set @ErrDesc = replace(dbo.FNObtenerMensaje('BE0003',@TipoLenguaje),'$0$',dbo.FNObtenerMensaje('CModuloTerm',@TipoLenguaje))
		raiserror (@ErrDesc, 16, 1)		
		set @Err=@@ERROR	
	end
	
if @Err=0
begin
	if @FechaHoraAlta is null or @FechaHoraAlta=''
		set @FechaHoraAlta	= getdate()		
	
	SET @FechaEntrega=Cast(@FechaHoraAlta as datetime)
end

if @Err = 0
begin
	declare @DescuentoVendedor float
	set @DescuentoVendedor = (cast(@SubtDetalle as float)-cast(@DescuentoImp as float)) * (cast(@DescVendPor as float)/100)
	declare @PCEModuloMovDetClave as varchar(16)
	set @PCEModuloMovDetClave = (select top 1 ModuloMovDetalleClave from ModuloMovDetalle where TipoIndice = @Modulo and TipoEstado = 1)

	if exists(select * from TransProd where TransProdID=@TransProdID )
	begin
  		update [dbo].[TransProd] set VisitaClave=@VisitaClave,DiaClave = @DiaClave, PCEModuloMovDetClave = @PCEModuloMovDetClave,
		FacturaID =@FacturaID, ClienteClave = @ClienteClave,  ClientePagoID = @ClientePagoID, CFVTipo = @CFVTipo, Folio = @Folio,
		TipoFase = @TipoFase, FechaHoraAlta = @FechaHoraAlta, FechaCaptura= @FechaEntrega,FechaEntrega = @FechaEntrega, 
		FechaFacturacion = @FechaFacturacion, FechaSurtido = null,FechaCancelacion =@FechaCancelacion, Subtdetalle =@Subtdetalle,
		DescVendPor = @DescVendPor, DescuentoVendedor=  @DescuentoVendedor,DescuentoImp=@DescuentoImp,  
		Subtotal=@Subtotal, Impuesto=@Impuesto, Total=@Total, Saldo=@Saldo,MonedaID=@MonedaId,TipoCambio=@TipoCambio,
		Descuento =case when (cast(@DescuentoImp as float)<>0 or cast(@DescVendPor as float)<>0  or cast(@DescuentoVendedor as float)<>0) then 1 else 0 end, FechaCobranza = @FechaCobranza, 
		DiasCredito=@DiasCredito, MFechaHora = @MFechaHora, MUsuarioID = @MUsuarioID where (TransProdID=@TransProdID )	   
	end 
	else 
	begin
		insert into [dbo].[TransProd](TransProdID, VisitaClave, DiaClave,PCEModuloMovDetClave, SubEmpresaID, FacturaID, ClienteClave, ClientePagoID,CFVTipo, Folio, Tipo, TipoPedido, TipoFase,TipoMovimiento,FechaHoraAlta,FechaCaptura, FechaEntrega, FechaFacturacion, FechaSurtido,FechaCancelacion, SubTDetalle, DescVendPor, DescuentoVendedor, DescuentoImp,
			Subtotal, Impuesto, Total,Saldo,MonedaID,TipoCambio, Promocion, Descuento, FechaCobranza,DiasCredito,MFechaHora,MUsuarioID )
		values( @TransProdID, @VisitaClave, @DiaClave,@PCEModuloMovDetClave, @SubEmpresaID, @FacturaID, @ClienteClave, @ClientePagoID, @CFVTipo, @Folio, 1, 1, @TipoFase,2,@FechaHoraAlta,@FechaEntrega, @FechaEntrega, @FechaFacturacion, null,@FechaCancelacion, @SubTDetalle, @DescVendPor, @DescuentoVendedor, @DescuentoImp,
			@Subtotal, @Impuesto, @Total, @Saldo,@MonedaId,@TipoCambio, 0,case when (cast(@DescuentoImp as float)<>0 or cast(@DescVendPor as float)<>0  or cast(@DescuentoVendedor as float)<>0) then 1 else 0 end, @FechaCobranza,@DiasCredito,@MFechaHora,@MUsuarioID)  
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
END

if @Err<>0     
begin    
	if @Err=2627   
		set @ErrDesc='Error de restricción, llave primaria duplicada'  
	else  
		select distinct top 1 @ErrDesc=description from master.dbo.sysmessages where error=@Err    
	    
	insert into ErrorLog(LineNumber,DTSName,SQLErrNumber,Descripcion,MFechaHora,MUsuarioID)    
	values (@LineNumer,'TransProd(Pedido)',@Err, @ErrDesc, getDate(),'Admin')    
end
	FETCH NEXT FROM @CursorVar1 INTO @TransProdID ,  @DiaClave, @Modulo, @ClienteClave, @ClientePagoID, @CFVTipo, @Folio, @FechaHoraAlta,
@Subtdetalle, @Subtotal, @Impuesto, @Total, @Saldo,@CodigoMon,@TipoCambio, @FechaCobranza, @DiasCredito, @ClaveUsuario
END

CLOSE @CursorVar1
DEALLOCATE @CursorVar1 


/*go*/go


