USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_VendedoresSaldos2]    Script Date: 12/06/2010 09:42:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_VendedoresSaldos2]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_VendedoresSaldos2]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_VendedoresSaldos2]    Script Date: 12/06/2010 09:42:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[up_VendedoresSaldos2] 
@IdCedis as bigint,
@IdCargoAbono as bigint,
@IdVendedor as varchar(10),
@Fecha as datetime,
@IdTipoSaldos as varchar(5),
@Importe as money,
@Observaciones as varchar(200),
@IdSurtido as bigint,
@Opc as int
AS

if @Opc = 1
begin
	
	set @IdCargoAbono = (select isnull(max(IdCargoAbono)+1,1) from VendedoresCargosAbonos where IdCedis = @IdCedis  )
	insert into VendedoresCargosAbonos values (@IdCedis, @IdCargoAbono, @IdTipoSaldos, @IdVendedor, @Fecha, @Importe, @Observaciones, @IdSurtido)

	set @Importe = (select isnull(sum(Importe),0) from VendedoresCargosAbonos where IdCedis = @IdCedis and IdVendedor = @IdVendedor and Fecha = @Fecha and IdTipoSaldo = @IdTipoSaldos and IdSurtido = @IdSurtido)

	if exists(select IdVendedor from VendedoresSaldos where IdCedis = @IdCedis and IdVendedor = @IdVendedor and Fecha = @Fecha and IdTipoSaldo = @IdTipoSaldos and IdSurtido = @IdSurtido)
	begin
		update VendedoresSaldos set Otros = @Importe, SaldoActual = SaldoAnterior + Saldo + @Importe
		where IdCedis = @IdCedis and IdVendedor = @IdVendedor and Fecha = @Fecha and IdTipoSaldo = @IdTipoSaldos and IdSurtido = @IdSurtido 
	end
	else
	begin
		insert into VendedoresSaldos	
		select @IdCedis, @IdSurtido, 0, @IdTipoSaldos, @IdVendedor, @Fecha, 
		isnull((select top 1 SaldoActual
			from  VendedoresSaldos 
			where IdCedis = @IdCedis and IdVendedor = @IdVendedor and IdTipoSaldo = 'EF' 
			order by Fecha desc), 0), 0, @Importe, 
		isnull((select top 1 SaldoActual
		from  VendedoresSaldos 
		where IdCedis = @IdCedis and IdVendedor = @IdVendedor and IdTipoSaldo = 'EF' 
		order by Fecha desc), 0) + @Importe
	end
end

if @Opc = 2
begin
	delete from VendedoresCargosAbonos where IdCedis = @IdCedis and IdCargoAbono = @IdCargoAbono and IdVendedor = @IdVendedor and Fecha = @Fecha and IdTipoSaldo = @IdTipoSaldos

	set @Importe = (select isnull(sum(Importe),0) from VendedoresCargosAbonos where IdCedis = @IdCedis and IdVendedor = @IdVendedor and Fecha = @Fecha and IdTipoSaldo = @IdTipoSaldos and IdSurtido = @IdSurtido)

	update VendedoresSaldos set Otros = @Importe, SaldoActual = SaldoAnterior + Saldo + @Importe
	where IdCedis = @IdCedis and IdVendedor = @IdVendedor and Fecha = @Fecha and IdTipoSaldo = @IdTipoSaldos and IdSurtido = @IdSurtido 
end





GO

