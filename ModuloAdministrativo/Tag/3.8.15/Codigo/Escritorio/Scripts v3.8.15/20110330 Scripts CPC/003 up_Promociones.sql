USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[up_Promociones]    Script Date: 03/30/2011 15:39:27 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_Promociones]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_Promociones]
GO

USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[up_Promociones]    Script Date: 03/30/2011 15:39:27 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO


CREATE PROCEDURE [dbo].[up_Promociones] 
@IdPromocion as bigint,
@Nombre as varchar(500),
@Observaciones as varchar(500),
@FechaInicial as datetime,
@FechaFinal as datetime,
@IdDocumento as varchar(10),
@IdTipoDocumento as varchar(10),
@Cascada as bit,
@Otras as bit,
@Ventas as bit,
@Status as char(1),
@Login as varchar(20),
@Opc as int
AS

if @Opc = 1 
begin
	insert into promociones values (@IdPromocion, @Nombre, @Observaciones, @FechaInicial, @FechaFinal, 
		@IdDocumento, @IdTipoDocumento, @Cascada, @Otras, @Ventas, 'A', @Login, GETDATE())
end

if @Opc = 2
begin
	update promociones set Nombre = @Nombre, Observaciones = @Observaciones, FechaFinal = @FechaFinal, Login = @Login, FechaEdicion = GETDATE() 		
	where IdPromocion = @IdPromocion
end

if @Opc = 3
begin
	update promociones set Status = @Status, Login = @Login, FechaEdicion = GETDATE() 
	where IdPromocion = @IdPromocion
end


GO


