USE [RouteADM]
GO
/****** Object:  StoredProcedure [dbo].[up_StatusDia]    Script Date: 07/29/2010 18:12:23 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO




ALTER PROCEDURE [dbo].[up_StatusDia] 
@IdCedis as bigint,
@Fecha as datetime,
@Status as varchar(1),
@StatusDesc as varchar(100),
@FechaOrigen as datetime,
@Opc as int

AS

declare @InvInicial as bigint, @FechaInv as datetime, @year as int, @month as integer

if @Opc = 1 -- inserta satatus de A: Día Abierto para la Captura
begin
	insert into StatusDia values (@IdCedis, @Fecha, 'A', 'Día Abierto para la Captura')
	set @InvInicial = isnull(  ( select top 1 IdProducto
		from InventarioInicial
		where IdCedis = @IdCedis and Agno = year(@Fecha) and Mes = month(@Fecha))  , 0) 

	if @InvInicial = 0  -- INSERTA INVENTARIO INICIAL DE MES DEL ULTIMO DIA
	begin 
		set @FechaInv = (select top 1 Fecha
			from InventarioKardex
			where IdCedis = @IdCedis and Fecha in ( 
				select Fecha from StatusDia where Status = 'C')
			order by Fecha desc )
		if @FechaInv is not null
			insert into InventarioInicial
			select IdCedis, year(@Fecha), month(@Fecha), IdProducto, Fisico, 'A', 'N'
			from InventarioKardex
			where IdCedis = @IdCedis and Fecha = @FechaInv
		set @year = year(@Fecha)
		set @month = month(@Fecha)
		exec up_InvInicial @IdCedis, @year, @month, 0, 0

		delete from InventarioKardex where IdCedis = @IdCedis and month(Fecha) = @month and year(Fecha) = @Year
		insert into InventarioKardex
		select IdCedis, @Fecha, IdProducto, Fisico, 0, 0, 0, 0, 0, 0, 0, 0, 0
		from InventarioKardex
		where IdCedis = @IdCedis and Fecha = @FechaOrigen
	end
	else
	begin
		-- inserta el inicial del día seleccionado
		insert into InventarioKardex
		select IdCedis, @Fecha, IdProducto, Fisico, 0, 0, 0, 0, 0, 0, 0, 0, 0
		from InventarioKardex
		where IdCedis = @IdCedis and Fecha = @FechaOrigen
	end
end 

if @Opc = 2 -- C: Día Cerrado
begin
	update StatusDia set Status = 'C',  StatusDesc = 'Día Cerrado' where IdCedis = @IdCedis and Fecha = @Fecha
	exec RouteCPC.dbo.GeneraSaldos @Fecha, @Fecha
end

if @Opc = 3 
	insert into StatusDia values (@IdCedis, @Fecha, @Status, @StatusDesc)
