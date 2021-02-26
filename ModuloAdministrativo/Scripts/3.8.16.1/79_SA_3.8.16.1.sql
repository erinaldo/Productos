USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_ComEsquemaPagos]    Script Date: 08/21/2011 22:30:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_ComEsquemaPagos]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_ComEsquemaPagos]
GO

USE [RouteADM]
GO

/****** Object:  StoredProcedure [dbo].[sel_ComEsquemaPagos]    Script Date: 08/21/2011 22:30:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sel_ComEsquemaPagos]
@IdComEsquema as bigint,
@IdFamilia as bigint,
@IdMarca as bigint,
@IdProducto as bigint,
@IdConceptoPago as bigint,
@Inicial as money,
@Final as money,
@Opc as int

AS

if @Opc = 1
begin
	if @IdMarca <> '0'
		select TipoVendedor as 'Perfil', Inicial, Final, Pago, Fecha, 
		case ComEsquemaPagos.Status
			when 'A' then 'Activo'
			when 'B' then 'Baja' 
		end as 'Status', ComEsquemaPagos.Usuario
		from ComEsquemaPagos 
		inner join TipoVendedor on ComEsquemaPagos.IdTipoVendedor = TipoVendedor.IdTipoVendedor
		where IdComEsquema = @IdComEsquema and IdMarca = @IdMarca and IdConceptoPago = @IdConceptoPago and Inicial = @Inicial and Final = @Final and ComEsquemaPagos.Status = 'A'
	else
		select TipoVendedor as 'Perfil', Inicial, Final, Pago, Fecha, 
		case ComEsquemaPagos.Status
			when 'A' then 'Activo'
			when 'B' then 'Baja' 
		end as 'Status', ComEsquemaPagos.Usuario
		from ComEsquemaPagos 
		inner join TipoVendedor on ComEsquemaPagos.IdTipoVendedor = TipoVendedor.IdTipoVendedor
		where IdComEsquema = @IdComEsquema and IdProducto = @IdProducto and IdConceptoPago = @IdConceptoPago and Inicial = @Inicial and Final = @Final and ComEsquemaPagos.Status = 'A'
end



GO


USE [Route] 
GO

if (Select COUNT(*) from VersionBD where Tipo = 'SA' and Version ='3.8.16.1') = 0
BEGIN
	INSERT INTO VersionBD (Tipo, FechaHora, Version, MaximoConsecutivo, VersionSql ) 
	VALUES('SA', GETDATE(), '3.8.16.1', 79, (SELECT  cast(SERVERPROPERTY('productversion') as varchar(50))))
END
ELSE
BEGIN 
	Update VersionBD  set MaximoConsecutivo = 79 where  Tipo = 'SA' and Version ='3.8.16.1'
END
GO