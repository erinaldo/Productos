USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[up_Anticipos]    Script Date: 03/01/2011 09:31:03 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_Anticipos]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_Anticipos]
GO

USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[up_Anticipos]    Script Date: 03/01/2011 09:31:03 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[up_Anticipos]
@IdCedis as bigint,
@FolioAnticipo as bigint,
@Fecha as datetime,
@IdCliente as bigint,
@IdSucursal as varchar(30),
@Monto as money,
@Observaciones as varchar(2000),
@Status as varchar(1),
@Login as varchar(20),
@Opc as int
AS

declare @Folio as bigint, @IdDocumento as varchar(10), @IdTipoDocumento as varchar(10)--, @IdMovimiento as bigint

if @Opc = 1 -- inserta Anticipos
begin
	select @IdDocumento = IdDocumentoAnticipo from Configuracion 
	insert into Anticipos values (@IdCedis, 2, @IdDocumento, @FolioAnticipo, @Fecha, @IdCliente, @IdSucursal, @Monto, @Monto, @Observaciones, @Status, @Login, getdate())
end

if @Opc = 3  --baja Anticipos
begin
	update Anticipos set Status = 'B', Login = @Login, FechaEdicion = getdate()  where FolioAnticipo = @FolioAnticipo
	update AnticiposDetalle set Status = 'B', Login = @Login, FechaEdicion = getdate() where FolioAnticipo = @FolioAnticipo
end

if @Opc = 4 -- elimina anticipo
begin
	update Anticipos set Status = 'B', FechaEdicion = getdate(), Login = @Login where FolioAnticipo = @FolioAnticipo 
	update AnticiposDetalle set Status = 'B', Login = @Login, FechaEdicion = getdate()  where FolioAnticipo = @FolioAnticipo
end

if @Opc = 5  -- Aplica
begin

	select @Folio = isnull(max(Folio)+1,1) from Folio 
	set @Observaciones = 'ABONO POR CREACIÓN DE ANTICIPO FOLIO ' + cast(replicate('0', 6-len(@FolioAnticipo) ) + cast(@FolioAnticipo as varchar(6)) as varchar(10))
	select @IdDocumento = IdDocumentoAnticipo, @IdTipoDocumento = IdTipoDocumentoAnticipo from Configuracion 

	insert into Ventas values (@IdCedis, 2, @FolioAnticipo, @IdDocumento, @Fecha, @IdCliente, 0, 0, 0, 0, 0, @IdSucursal, 1, '', 0, '', @Login, GETDATE())

	execute up_Folio @Folio, @Fecha, 0, @Observaciones, 'A', @Login, 1

	execute up_MovimientosFacturas @Folio, @IdCedis, 2, @IdDocumento, @FolioAnticipo, 0, @Fecha, 1,  @IdDocumento, @IdTipoDocumento, 'A', '', '', @Monto, 0, 'A', @Login, 1
	execute up_Folio @Folio, @Fecha, 0, @Observaciones, 'A', @Login, 5

	update Anticipos set Status = 'A', Login = @Login, FechaEdicion = getdate() where FolioAnticipo = @FolioAnticipo 
end
GO


