USE [Route]
GO

/****** Object:  Trigger [tg_TRPDatoFiscalUp]    Script Date: 06/30/2011 11:18:50 ******/
IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[tg_TRPDatoFiscalUp]'))
DROP TRIGGER [dbo].[tg_TRPDatoFiscalUp]
GO

USE [Route]
GO

/****** Object:  Trigger [dbo].[tg_TRPDatoFiscalUp]    Script Date: 06/30/2011 11:18:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER OFF
GO



	create trigger [dbo].[tg_TRPDatoFiscalUp]
	on [dbo].[TRPDatoFiscal] for update
	as

		DECLARE @CursorVar1 CURSOR
		DECLARE @TransProdId VARCHAR(16), @UUID VARCHAR(36)
		SET @CursorVar1 = CURSOR SCROLL DYNAMIC  FOR 		
		SELECT TransProdId, UUID FROM inserted		
		
		OPEN @CursorVar1
		FETCH NEXT FROM @CursorVar1 INTO @TransProdID, @UUID

		WHILE @@FETCH_STATUS = 0 
		BEGIN 
			UPDATE RouteADM.dbo.VentasFacturaCFD SET UUID = @UUID WHERE TransprodIdFactura = @TransProdId
			UPDATE RouteCPC.dbo.VentasFacturaCFD SET UUID = @UUID WHERE TransprodIdFactura = @TransProdId			
			
			FETCH NEXT FROM @CursorVar1 INTO @TransProdID, @UUID
		END

		CLOSE @CursorVar1
		DEALLOCATE @CursorVar1 


GO


