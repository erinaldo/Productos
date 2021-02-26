USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[sel_VentasAcredita]    Script Date: 04/05/2011 20:05:03 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_VentasAcredita]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_VentasAcredita]
GO

/****** Object:  StoredProcedure [dbo].[up_VentasAcredita]    Script Date: 04/05/2011 20:05:03 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_VentasAcredita]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_VentasAcredita]
GO

USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[sel_VentasAcredita]    Script Date: 04/05/2011 20:05:03 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO





CREATE PROCEDURE [dbo].[sel_VentasAcredita] 
@IdCedis as bigint,
@IdTipoVenta as bigint,
@Serie as varchar(5),
@Folio as bigint,
@Opc as int

AS

if @Opc = 1
	select IdCedis, 0 as IdSurtido, FechaAcredita, Login, FechaEntrega, FolioEntrega, Observaciones, FolioCliente, Remision, Factura, Status  
	from VentasAcredita 
	where VentasAcredita.IdCedis = @IdCedis and VentasAcredita.IdTipoVenta = @IdTipoVenta 
		and VentasAcredita.Serie = @Serie and VentasAcredita.Folio = @Folio 



GO

/****** Object:  StoredProcedure [dbo].[up_VentasAcredita]    Script Date: 04/05/2011 20:05:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[up_VentasAcredita] 
@IdCedis as bigint,
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

	if not exists(select Folio from VentasAcredita where IdCedis = @IdCedis and IdTipoVenta = @IdTipoVenta and Folio = @Folio and Serie = @Serie )
		insert into VentasAcredita values (@IdCedis, @IdTipoVenta, @Folio, @Serie, GETDATE(), @FechaAcredita, 
			@Login, @FechaEntrega, @FolioEntrega, @Observaciones, @FolioCliente, @Remision, @Factura, @Status, 7)	
	else
		update VentasAcredita set 
			FechaEntrega = @FechaEntrega, 
			FolioEntrega = @FolioEntrega, 
			Observaciones = @Observaciones, 
			FolioCliente = @FolioCliente, 
			Remision = @Remision, 
			Factura = @Factura, 
			Status = @Status, 
			Vencimiento = 7
		where IdCedis = @IdCedis and IdTipoVenta = @IdTipoVenta and Folio = @Folio and Serie = @Serie 
end



GO


