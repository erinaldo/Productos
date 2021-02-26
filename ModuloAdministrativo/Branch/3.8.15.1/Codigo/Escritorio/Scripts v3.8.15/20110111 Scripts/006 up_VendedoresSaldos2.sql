USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_VendedoresSaldos2]    Script Date: 01/17/2011 15:15:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_VendedoresSaldos2]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_VendedoresSaldos2]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_VendedoresSaldos2]    Script Date: 01/17/2011 15:15:46 ******/
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

declare 
@Dias as bigint,
@FechaTrabajo as datetime,
@UltimaFecha as datetime,
@SaldoAnterior as money,
@Otros as money

if @Opc = 1
begin

	set @IdCargoAbono = (select isnull(max(IdCargoAbono)+1,1) from VendedoresCargosAbonos where IdCedis = @IdCedis  )
	insert into VendedoresCargosAbonos values (@IdCedis, @IdCargoAbono, @IdTipoSaldos, @IdVendedor, @Fecha, @Importe, @Observaciones, @IdSurtido)

	 exec up_VendedoresSaldos @IdCedis, 0, @IdVendedor, @Fecha, 1
	
end

if @Opc = 2
begin
	delete from VendedoresCargosAbonos where IdCedis = @IdCedis and IdCargoAbono = @IdCargoAbono and IdVendedor = @IdVendedor and Fecha = @Fecha and IdTipoSaldo = @IdTipoSaldos

	exec up_VendedoresSaldos @IdCedis, 0, @IdVendedor, @Fecha, 1
	
end








GO


