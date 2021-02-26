USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_VentasAcredita]    Script Date: 02/26/2011 12:32:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_VentasAcredita]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_VentasAcredita]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_VentasAcredita]    Script Date: 02/26/2011 12:32:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO






CREATE PROCEDURE [dbo].[up_VentasAcredita] 
@IdCedis as bigint,
@IdSurtido as bigint,
@IdTipoVenta as int,
@Folio as bigint,
@Serie as varchar(5),
@FechaAcredita as datetime,
@Login as varchar(16),
@FechaEntrega as datetime,
@FolioEntrega as varchar(16),
@Observaciones as varchar(2000),
@FolioCliente as varchar(16),
@Remision as varchar(16),
@Factura as varchar(16),
@Status as varchar(1),
@Vencimiento as int,
@Opc as int

AS

if @Opc = 1 -- Inserta Factura Nueva
begin

	if not exists(select IdSurtido from VentasAcredita where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio and Serie = @Serie )
		insert into VentasAcredita values (@IdCedis, @IdSurtido, @IdTipoVenta, @Folio, @Serie, GETDATE(), @FechaAcredita, 
			@Login, @FechaEntrega, @FolioEntrega, @Observaciones, @FolioCliente, @Remision, @Factura, @Status, 7, 'N')	
	else
		update VentasAcredita set 
			FechaEntrega = @FechaEntrega, 
			FolioEntrega = @FolioEntrega, 
			Observaciones = @Observaciones, 
			FolioCliente = @FolioCliente, 
			Remision = @Remision, 
			Factura = @Factura, 
			Status = @Status, 			
			Vencimiento = 7,
			StatusTransferido = 'N'
		where IdCedis = @IdCedis and IdSurtido = @IdSurtido and IdTipoVenta = @IdTipoVenta and Folio = @Folio and Serie = @Serie 
end




GO


