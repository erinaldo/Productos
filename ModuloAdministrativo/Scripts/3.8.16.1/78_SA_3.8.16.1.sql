USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_ComEsquemaPagos]    Script Date: 08/21/2011 21:54:41 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[up_ComEsquemaPagos]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[up_ComEsquemaPagos]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[up_ComEsquemaPagos]    Script Date: 08/21/2011 21:54:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[up_ComEsquemaPagos]
@IdComEsquema as bigint,
@IdFamilia as bigint,
@IdMarca as bigint,
@IdProducto as bigint,
@IdConceptoPago as bigint,
@Inicial as money,
@Final as money,
@IdTipoVendedor as bigint,
@Pago as money,
@Status as char(1),
@Usuario as varchar(50),
@Opc as int

AS

if @Opc = 1
begin
	delete from ComEsquemaPagos 
	where IdComEsquema = @IdComEsquema and IdMarca = @IdMarca and IdProducto = @IdProducto
		and IdConceptoPago = @IdConceptoPago and Inicial = @Inicial and Final = @Final and IdTipoVendedor = @IdTipoVendedor

	if @Pago > 0 insert into ComEsquemaPagos values (@IdComEsquema, 0,@IdMarca, @IdProducto, @IdConceptoPago, @Inicial, @Final, @IdTipoVendedor, @Pago, @Status, getdate(), @Usuario)
end


GO



USE [Route] 
GO

if (Select COUNT(*) from VersionBD where Tipo = 'SA' and Version ='3.8.16.1') = 0
BEGIN
	INSERT INTO VersionBD (Tipo, FechaHora, Version, MaximoConsecutivo, VersionSql ) 
	VALUES('SA', GETDATE(), '3.8.16.1', 78, (SELECT  cast(SERVERPROPERTY('productversion') as varchar(50))))
END
ELSE
BEGIN 
	Update VersionBD  set MaximoConsecutivo = 78 where  Tipo = 'SA' and Version ='3.8.16.1'
END
GO
