USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[sel_Folios]    Script Date: 03/01/2011 10:02:01 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_Folios]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_Folios]
GO

USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[sel_Folios]    Script Date: 03/01/2011 10:02:01 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sel_Folios] 
@Mes as Int,
@Login as varchar(20),
@Opc as int
AS

if @Opc = 1
begin
	select 0, cast(replicate(0, 6-len(Folio.Folio) ) + cast(Folio.Folio as varchar(6)) as varchar(10)) as Folio, 
	Folio.Fecha, Folio.Monto, Folio.Observaciones as 'Descripción', 
	case Folio.Status
		when 'A' then 'Aplicado'
		when 'B' then 'Baja'
		else 'Pendiente'
	end as Status, Folio.Login, Folio.FechaEdicion 
	from Folio 
	where month(Folio.Fecha) = @Mes and ( Folio.Login = @Login or Folio.Login in (select LoginD from UsuariosLogin where Login = @Login ))
	order by Folio.Folio desc
end

if @Opc = 2
begin
	select isnull(MAX(Folio)+1, 1) from Folio 
end

GO


