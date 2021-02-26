USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[sel_Movimientos]    Script Date: 03/01/2011 10:02:01 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_Movimientos]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_Movimientos]
GO

USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[sel_Movimientos]    Script Date: 03/01/2011 10:02:01 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sel_Movimientos] 
@Mes as Int,
@Folio as bigint,
@Login as varchar(20),
@Opc as int
AS

if @Opc = 1
	select Movimientos.IdCedis, cast(isnull(Cedis, '-Cedis No Encontrado-') as varchar(30)) as Cedis, cast(replicate(0, 6-len(Movimientos.IdMovimiento) ) + cast(Movimientos.IdMovimiento as varchar(6)) as varchar(10)) as Folio, 
	Movimientos.Fecha, Movimientos.IdDocumento as Id, Documento, 
	case Movimientos.CargoAbono
		when 'C' then 'Cargo'
		when 'A' then 'Abono' 
	end as CargoAbono, Movimientos.Monto, 
	case Movimientos.Status
		when 'A' then 'Aplicado'
		when 'B' then 'Baja'
		else 'Pendiente'
	end as Status
	from Folio 
	inner join FolioDetalle on Folio.Folio = FolioDetalle.Folio 
	inner join Movimientos on FolioDetalle.IdCedis = Movimientos.IdCedis and FolioDetalle.IdMovimiento = Movimientos.IdMovimiento 
	inner join Documentos on Documentos.IdDocumento = Movimientos.IdDocumento 
	left outer join Cedis on Cedis.IdCedis = Movimientos.IdCedis 
	where month(Folio.Fecha) = @Mes and Folio.Folio = @Folio and ( Folio.Login = @Login or Folio.Login in (select LoginD from UsuariosLogin where Login = @Login ))
	order by Movimientos.IdCedis, Movimientos.IdDocumento 

GO


