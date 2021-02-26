USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[up_PromocionesAplicadas]    Script Date: 03/28/2011 00:42:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_PromocionesAplicadas]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_PromocionesAplicadas]
GO

USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[up_PromocionesAplicadas]    Script Date: 03/28/2011 00:42:12 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[up_PromocionesAplicadas] 
@IdAplicacion as bigint,
@IdPromocion as bigint,
@Login as varchar(20), 
@FechaInicial as datetime, 
@FechaFinal as datetime, 
@Opc as int
AS
declare @FPInicial as datetime, @FPFinal as datetime, @IdDocumento as varchar(5), @IdTipoDocumento as varchar(5), @IdCedis as bigint, @Cont as bigint, @Status as char(1)

if @Opc = 1
	insert into PromocionesAplicadas values (@IdAplicacion, @IdPromocion, @Login, getdate(), @FechaInicial, @FechaFinal, 'P' )

if @Opc =2  -- Inserta detalles de la Promocion
begin
	set @FPInicial = (select FechaInicial from Promociones where IdPromocion = @IdPromocion) 
	set @FPFinal = (select case FechaFinal when '01/01/1900' then '01/01/2100' else FechaFinal end as FechaFinal from Promociones where IdPromocion = @IdPromocion)
	set @IdDocumento = ( select IdDocumento from Promociones where IdPromocion =  @IdPromocion)
	set @IdTipoDocumento = ( select IdTipoDocumento from Promociones where IdPromocion =  @IdPromocion)

 	insert into PromocionesAplicadasDetalle
	select @IdAplicacion, @IdPromocion, Ventas.IdCedis, Ventas.IdTipoVenta, Ventas.Serie, Ventas.Folio, Ventas.Fecha, Ventas.IdCliente, Saldo, 0, @IdDocumento, @IdTipoDocumento, 0, 0, 0, ''
	from Ventas 
	inner join FN_PromocionesClientes (@IdPromocion) as FNCtes on FNCtes.IdCedis = Ventas.IdCedis and FNCtes.IdCliente = Ventas.IdCliente
	where Ventas.Fecha between @FechaInicial and @FechaFinal and Ventas.Fecha between @FPInicial and @FPFinal and Ventas.Saldo > 0
	order by Ventas.IdCedis, Ventas.IdTipoVenta, Ventas.Serie, Ventas.Folio, Ventas.IdCliente
end

if @Opc = 3 -- Actualiza Saldo y Monto
begin
	/*update PromocionesAplicadasDetalle
	set Saldo = isnull( ( select Saldo 
			from FN_PromocionesSaldoMonto (@IdAplicacion, @IdPromocion) as FNSaldoMonto 
			where FNSaldoMonto.IdCedis = PromocionesAplicadasDetalle.IdCedis and FNSaldoMonto.IdTipoVenta = PromocionesAplicadasDetalle.IdTipoVenta
				and FNSaldoMonto.Folio = PromocionesAplicadasDetalle.Folio ), 0)
	where IdAplicacion = @IdAplicacion and IdPromocion = @IdPromocion*/
	
	update PromocionesAplicadasDetalle
	set Monto = isnull( ( select Monto 
			from FN_PromocionesSaldoMonto (@IdAplicacion, @IdPromocion) as FNSaldoMonto 
			where FNSaldoMonto.IdCedis = PromocionesAplicadasDetalle.IdCedis and FNSaldoMonto.IdTipoVenta = PromocionesAplicadasDetalle.IdTipoVenta
				and FNSaldoMonto.Folio = PromocionesAplicadasDetalle.Folio ), 0)
	where IdAplicacion = @IdAplicacion and IdPromocion = @IdPromocion
end

if @Opc = 4 -- Valida Saldo > Monto promocion
begin
	update PromocionesAplicadasDetalle 
	set Aplicado = '2 | El Monto del Acuerdo: ' + cast(Monto as varchar(10)) + ' excede el saldo: ' + cast(Saldo as varchar(10)), 
	Monto = 0
	where IdAplicacion = @IdAplicacion and IdPromocion = @IdPromocion and Monto > Saldo
end

if @Opc = 5 -- Cambia status
begin

	update PromocionesAplicadas
	set Status = 'A'
	where IdAplicacion = @IdAplicacion and IdPromocion = @IdPromocion

	delete from PromocionesAplicadasDetalle where ( IdMovimiento = 0 or Monto = 0 ) and IdAplicacion = @IdAplicacion and IdPromocion = @IdPromocion 

	update PromocionesAplicadasDetalle
	set Aplicado = 'A|Acuerdo Aplicado'
	where IdAplicacion = @IdAplicacion and IdPromocion = @IdPromocion and Aplicado = '' and Monto > 0

end

if @Opc > 100  -- Cancela Promoción
begin
	set @IdCedis = @Opc - 100

	update PromocionesAplicadasDetalle
	set Aplicado = 'C|Movimientos Cancealdos'
	where IdAplicacion = @IdAplicacion and IdPromocion = @IdPromocion --and IdCedis = @IdCedis

	--set @Cont = isnull( ( select count(Folio) from PromocionesAplicadasDetalle where IdAplicacion = @IdAplicacion and IdPromocion = @IdPromocion and Aplicado = 'A' ), 0)
	--if @Cont > 0
	--	set @Status = 'E'
	--else
	set @Status = 'C'
	
	update PromocionesAplicadas
	set Status = @Status
	where IdAplicacion = @IdAplicacion and IdPromocion = @IdPromocion 

end

GO


