SET ANSI_NULLS ON
/*go*/go

SET QUOTED_IDENTIFIER ON
/*go*/go



ALTER PROCEDURE [dbo].[sp_Importar_ORT]
@FolioOrden varchar(20),
@ClaveSuscriptor varchar(20),
@ClaveCuadrilla varchar(20),
@ClaveCiudad varchar(20),
@ClaveTrabajo varchar(20),
@TipoTrabajo varchar(20),
@ClaveServicio varchar(20),
@TipoServicio varchar(20),
@Prioridad smallint,
@Estado varchar(20),
@Motivo varchar(20),
@Observacion varchar(250),
@FechaHoraProgramada datetime

AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @Err int
	set @Err = 0
	IF (@FolioOrden IS NULL) OR (RTrim(LTrim(@FolioOrden)) = '')
	BEGIN
		RAISERROR ('FolioOrden .Atributo Requerido.', 16, 2)
		SET @Err = @@ERROR
	END	

	IF (@ClaveSuscriptor IS NULL) OR (RTrim(LTrim(@ClaveSuscriptor)) = '')
	BEGIN
		RAISERROR ('ClaveSuscriptor.Atributo Requerido.', 16, 2)
		SET @Err = @@ERROR
	END	
	else if(not exists(select * from Suscriptor where ClaveSuscriptor=@ClaveSuscriptor))
	begin
		RAISERROR ('ClaveSuscriptor.No Existe en Suscriptor.', 16, 2)
		SET @Err = @@ERROR
	end
	
	declare @ClaveRegion as varchar(20)
select @ClaveRegion=ClaveRegion  from Ciudad  where   ClaveCiudad=@ClaveCiudad
	
	
	
	IF (@ClaveCuadrilla IS NULL) OR (RTrim(LTrim(@ClaveCuadrilla)) = '')
	BEGIN
		RAISERROR ('ClaveCuadrilla.Atributo Requerido.', 16, 2)
		SET @Err = @@ERROR
	END	
	
	IF not((@ClaveCuadrilla IS NULL) OR (RTrim(LTrim(@ClaveCuadrilla)) = ''))
	IF not ((@ClaveCiudad IS NULL) OR (RTrim(LTrim(@ClaveCiudad)) = ''))
	if(not exists(select * from Cuadrilla where ClaveCuadrilla=@ClaveRegion+'_'+@ClaveCuadrilla))
	begin
		RAISERROR ('ClaveCuadrilla.No Existe Cuadrilla o esta Inactiva.', 16, 2)
		SET @Err = @@ERROR
	end
	
	IF (@ClaveCiudad IS NULL) OR (RTrim(LTrim(@ClaveCiudad)) = '')
	BEGIN
		RAISERROR ('ClaveCiudad.Atributo Requerido.', 16, 2)
		SET @Err = @@ERROR
	END	
	else if(not exists(select * from Ciudad where Ciudad.Estado=1))
	begin
			RAISERROR ('ClaveCiudad.No Existe Ciudad o está Inactiva.', 16, 2)
		SET @Err = @@ERROR
	end
	
	IF (@ClaveTrabajo IS NULL) OR (RTrim(LTrim(@ClaveTrabajo)) = '')
	BEGIN
		RAISERROR ('ClaveTrabajo.Atributo Requerido.', 16, 2)
		SET @Err = @@ERROR
	END	
	else if (not exists(select * from Trabajo where ClaveTrabajo=@ClaveTrabajo and Trabajo.Estado=1))
	begin
			RAISERROR ('ClaveTrabajo.No Existe Trabajo o está Inactivo.', 16, 2)
		SET @Err = @@ERROR
	end
	
	IF (@TipoTrabajo IS NULL) OR (RTrim(LTrim(@TipoTrabajo)) = '')
	BEGIN
		RAISERROR ('TipoTrabajo.Atributo Requerido.', 16, 2)
		SET @Err = @@ERROR
	END	
	else if (not exists (select * from ValorReferencia where ValorCliente=@TipoTrabajo and Clave ='TIPTRA'))
	begin 
		RAISERROR ('TipoTrabajo.No Existe en ValorReferencia o está Inactivo.', 16, 2)
		SET @Err = @@ERROR
	end
	else
	begin
		set @FolioOrden= @TipoTrabajo+ '-' +@FolioOrden 
		select top 1 @TipoTrabajo=Valor  from ValorReferencia where ValorCliente=@TipoTrabajo and Clave ='TIPTRA'
	end
	
		IF (@ClaveServicio is null) or (RTrim(LTrim(@ClaveServicio)) = '')
	BEGIN
		RAISERROR ('ClaveServicio.Atributo Requerido.', 16, 2)
		set @Err = @@ERROR
	END		

	
	IF (@TipoServicio IS NULL) OR (RTrim(LTrim(@TipoServicio)) = '')
	BEGIN
		RAISERROR ('TipoServicio.Atributo Requerido.', 16, 2)
		SET @Err = @@ERROR
	END	
	else if (not exists (select * from ValorReferencia where ValorCliente=@TipoServicio and Clave ='TIPSRV'))
	begin 
		RAISERROR ('TipoServicio.No Existe en ValorReferencia o está Inactivo.', 16, 2)
		SET @Err = @@ERROR
	end
			else IF (not exists(select * from Servicio where ClaveServicio=@ClaveServicio  and TipoServicio=(select top 1 Valor  from ValorReferencia where ValorCliente=@TipoServicio and Clave ='TIPSRV')))
	BEGIN
		RAISERROR ('Servicio.No existe en Servicio', 16, 2)
		set @Err = @@ERROR
	END		
	else
	begin
		select top 1 @TipoServicio=Valor  from ValorReferencia where ValorCliente=@TipoServicio and Clave ='TIPSRV'
	end
	
	IF (@Prioridad IS NULL) 
	BEGIN
		RAISERROR ('Prioridad.Atributo Requerido.', 16, 2)
		SET @Err = @@ERROR
	END	
	else if (@Prioridad<0)
	begin
		RAISERROR ('Prioridad.Numero Negativo.', 16, 2)
		SET @Err = @@ERROR
	end
	
	
	IF (@Estado IS NULL) OR (RTrim(LTrim(@Estado)) = '')
	BEGIN
		RAISERROR ('Estado.Atributo Requerido.', 16, 2)
		SET @Err = @@ERROR
	END	
	else if (not exists (select * from ValorReferencia where ValorCliente=@Estado and Clave ='EDOORD'))
	begin 
		RAISERROR ('Estado.No Existe en ValorReferencia o está Inactivo.', 16, 2)
		SET @Err = @@ERROR
	end
	else
	begin
		select top 1 @Estado=Valor  from ValorReferencia where ValorCliente=@Estado and Clave ='EDOORD'
	end
	
	
	IF NOT((@Motivo IS NULL) OR (RTrim(LTrim(@Motivo)) = ''))
	BEGIN
		RAISERROR ('Motivo.No Es Nulo.', 16, 2)
		SET @Err = @@ERROR
	END	
	
	
	
	IF not( (@Observacion IS NULL) OR (RTrim(LTrim(@Observacion)) = ''))
	BEGIN
		RAISERROR ('Observacion.No Es Nulo.', 16, 2)
		SET @Err = @@ERROR
	END	
	
	IF (@FechaHoraProgramada IS NULL)
	BEGIN
	RAISERROR ('FechaHoraProgramada.Atributo Requerido.', 16, 2)
	SET @Err = @@ERROR
	END	
	else if(@FechaHoraProgramada< cast(convert(date, getdate()) as datetime))
	begin
		RAISERROR ('FechaHoraProgramada.Fecha-Hora Menor a la Actual.', 16, 2)
		SET @Err = @@ERROR
	end
	
	IF (@Err  <> 0)
	BEGIN
		RETURN
	END	


	
	set @ClaveCuadrilla = @ClaveRegion+'_'+@ClaveCuadrilla



if(exists(select * from OrdenTrabajo where FolioOrden =@FolioOrden))
begin
update OrdenTrabajo set Prioridad = @Prioridad , FechaHoraProgramada = @FechaHoraProgramada, Estado =@Estado ,ClaveCuadrilla=@ClaveCuadrilla, IdVisita=null,Observacion=null,Motivo=null
where FolioOrden=@FolioOrden
end
else
begin 
insert OrdenTrabajo (FolioOrden,ClaveSuscriptor,ClaveCuadrilla,ClaveTrabajo,TipoTrabajo,ClaveServicio,TipoServicio,Prioridad,Estado,FechaHoraProgramada)
values(@FolioOrden,@ClaveSuscriptor,@ClaveCuadrilla,@ClaveTrabajo,@TipoTrabajo,@ClaveServicio,@TipoServicio,@Prioridad,@Estado,@FechaHoraProgramada)
end


end


/*go*/go


