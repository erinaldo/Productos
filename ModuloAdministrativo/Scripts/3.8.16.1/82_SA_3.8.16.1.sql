USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_ComEsquemaRangos]    Script Date: 08/20/2011 14:08:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_ComEsquemaRangos]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_ComEsquemaRangos]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_ComEsquemaRangos]    Script Date: 08/20/2011 14:08:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[up_ComEsquemaRangos]
@IdComEsquema as bigint,
@IdMarca as bigint,
@IdProducto as bigint,
@IdConceptoPago as bigint,
@Inicial as money,
@Final as money,
@Status as char(1),
@Usuario as varchar(50),
@Opc as int

AS

if @Opc = 1
begin
	if @IdMarca <> 0 and not exists(select IdComEsquema from ComEsquemaFamilia where IdComEsquema = @IdComEsquema and IdFamilia = @IdMarca )
	begin
		delete from ComEsquemaMarca where IdComEsquema = @IdComEsquema and IdMarca = @IdMarca
		insert into ComEsquemaMarca values (@IdComEsquema, @IdMarca, 'A', getdate(), @Usuario)
	end

	if @IdProducto <> 0 and not exists(select IdComEsquema from ComEsquemaProducto where IdComEsquema = @IdComEsquema and IdProducto = @IdProducto )
	begin
		delete from ComEsquemaProducto where IdComEsquema = @IdComEsquema and IdProducto = @IdProducto
		insert into ComEsquemaProducto values (@IdComEsquema, @IdProducto, 'A', getdate(), @Usuario)
	end

	delete from ComEsquemaRangos 
	where IdComEsquema = @IdComEsquema and IdMarca = @IdMarca and IdProducto = @IdProducto
		and IdConceptoPago = @IdConceptoPago and Inicial = @Inicial and Final = @Final
	insert into ComEsquemaRangos values (@IdComEsquema, 0,@IdMarca, @IdProducto, @IdConceptoPago, @Inicial, @Final, @Status, getdate(), @Usuario)
end

if @Opc = 2
begin
	update ComEsquemaRangos set Status = 'B', Fecha = getdate(), Usuario = @Usuario
	where IdComEsquema = @IdComEsquema and IdMarca = @IdMarca and IdProducto = @IdProducto
		and IdConceptoPago = @IdConceptoPago and Inicial = @Inicial and Final = @Final

	update ComEsquemaPagos set Status = 'B', Fecha = getdate(), Usuario = @Usuario
	where IdComEsquema = @IdComEsquema and IdMarca = @IdMarca and IdProducto = @IdProducto
		and IdConceptoPago = @IdConceptoPago and Inicial = @Inicial and Final = @Final

	if @IdMarca <> 0
	BEGIN
		if (Select COUNT(*) from ComEsquemaRangos where Status ='A' and IdComEsquema = @IdComEsquema and IdMarca = @IdMarca) = 0
			delete from ComEsquemaMarca where IdComEsquema = @IdComEsquema and IdMarca = @IdMarca 
	END
	
	if @IdProducto <> 0
	BEGIN
		if (Select COUNT(*) from ComEsquemaRangos where Status ='A' and IdComEsquema = @IdComEsquema and IdProducto = @IdProducto) = 0
			delete from ComEsquemaProducto where IdComEsquema = @IdComEsquema and IdProducto = @IdProducto
	END
end

if @Opc = 3
begin
	declare @Resultado as varchar(5000), 
		@InicialAnt as money,
		@FinalAnt as money

	set @Resultado = 'Rangos de Pago configurados correctamente.'
	set @InicialAnt = -1
	set @FinalAnt = -1

	declare  ValidaRangos cursor for
		select Inicial, Final
		from ComEsquemaRangos
		where IdComEsquema = @IdComEsquema and IdMarca = @IdMarca and IdProducto = @IdProducto
		and IdConceptoPago = @IdConceptoPago and Status = 'A'
		order by Inicial
	open ValidaRangos
	
	fetch next from ValidaRangos into @Inicial, @Final
	while (@@fetch_status = 0)
	begin
		if @FinalAnt > 0
		begin
			if @Inicial <> @FinalAnt + 1
			set @Resultado = 'Error en los Rangos de Pago. Error entre el Rango Final: ' + cast(@FinalAnt as varchar(30)) + ' y el Inicial: ' + cast(@Inicial as varchar(30)) 
		end
		set @InicialAnt = @Inicial
		set @FinalAnt = @Final
	
		fetch next from ValidaRangos into @Inicial, @Final
	end
	close ValidaRangos
	deallocate ValidaRangos	

	select @Resultado
end





GO


USE [Route] 
GO

if (Select COUNT(*) from VersionBD where Tipo = 'SA' and Version ='3.8.16.1') = 0
BEGIN
	INSERT INTO VersionBD (Tipo, FechaHora, Version, MaximoConsecutivo, VersionSql ) 
	VALUES('SA', GETDATE(), '3.8.16.1', 82, (SELECT  cast(SERVERPROPERTY('productversion') as varchar(50))))
END
ELSE
BEGIN 
	Update VersionBD  set MaximoConsecutivo = 82 where  Tipo = 'SA' and Version ='3.8.16.1'
END
GO
