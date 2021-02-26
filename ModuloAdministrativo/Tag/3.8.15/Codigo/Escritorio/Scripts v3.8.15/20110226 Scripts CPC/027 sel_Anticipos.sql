USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[sel_Anticipos]    Script Date: 03/01/2011 10:02:01 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_Anticipos]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_Anticipos]
GO

USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[sel_Anticipos]    Script Date: 03/01/2011 10:02:01 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sel_Anticipos] 
@Mes as bigint,
@Login as varchar(20),
@Opc as int
AS

if @Opc = 1
begin
	select 0, cast(replicate(0, 6-len(Anticipos.FolioAnticipo) ) + cast(Anticipos.FolioAnticipo as varchar(6)) as varchar(10)) as Folio, 
	Anticipos.Fecha, Anticipos.Importe, Anticipos.Saldo, 
	Anticipos.IdCliente, isnull(Clientes.RazonSocial,'-Cliente No Econtrado-') as RazonSocial,
	Anticipos.IdSucursal, isnull(ClienteSucursal.NombreSucursal,'-Sucursal No Econtrada-') as NombreSucursal,
	Anticipos.Observaciones,
	case Anticipos.Status
		when 'A' then 'Aplicado'
		when 'B' then 'Baja'
		else 'Pendiente'
	end as Status, Anticipos.Login, Anticipos.FechaEdicion, Anticipos.IdCedis 
	from Anticipos  
	left outer join Clientes on Clientes.IdCedis = Anticipos.IdCedis and Clientes.IdCliente = Anticipos.IdCliente 
	left outer join ClienteSucursal on ClienteSucursal.IdCedis = Anticipos.IdCedis and ClienteSucursal.IdSucursal = Anticipos.IdSucursal 
	where month(Anticipos.Fecha) = @Mes and ( Anticipos.Login = @Login or Anticipos.Login in (select LoginD from UsuariosLogin where Login = @Login ))
	order by Anticipos.FolioAnticipo desc
end

if @Opc = 2
begin
	select isnull(MAX(FolioAnticipo)+1, 1) from Anticipos 
end

if @Opc = 3
begin
	select 0, cast(replicate(0, 6-len(Anticipos.FolioAnticipo) ) + cast(Anticipos.FolioAnticipo as varchar(6)) as varchar(10)) as Folio, 
	Anticipos.Fecha, Anticipos.Importe, Anticipos.Saldo, 
	Anticipos.IdCliente, isnull(Clientes.RazonSocial,'-Cliente No Econtrado-') as RazonSocial,
	Anticipos.IdSucursal, isnull(ClienteSucursal.NombreSucursal,'-Sucursal No Econtrada-') as NombreSucursal,
	Anticipos.Observaciones,
	case Anticipos.Status
		when 'A' then 'Aplicado'
		when 'B' then 'Baja'
		else 'Pendiente'
	end as Status, Anticipos.Login, Anticipos.FechaEdicion, Anticipos.IdCedis 
	from Anticipos  
	left outer join Clientes on Clientes.IdCedis = Anticipos.IdCedis and Clientes.IdCliente = Anticipos.IdCliente 
	left outer join ClienteSucursal on ClienteSucursal.IdCedis = Anticipos.IdCedis and ClienteSucursal.IdSucursal = Anticipos.IdSucursal 
	where FolioAnticipo = @Mes 
	order by Anticipos.FolioAnticipo desc
end

GO


