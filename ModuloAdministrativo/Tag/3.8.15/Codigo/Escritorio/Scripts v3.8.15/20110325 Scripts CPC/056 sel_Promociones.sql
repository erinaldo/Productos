USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[sel_Promociones]    Script Date: 03/27/2011 22:45:02 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_Promociones]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_Promociones]
GO

USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[sel_Promociones]    Script Date: 03/27/2011 22:45:02 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[sel_Promociones] 
@FechaInicial as datetime,
@FechaFinal as datetime,
@Opc as int
AS

if @Opc = 1
	select '', IdPromocion as IdAcuerdo, Nombre, FechaInicial, FechaFinal, 
	case Status when 'A' then 'Activo' when 'B' then 'Baja' when 'G' then 'Generado' end as Status, Observaciones, IdDocumento, IdTipoDocumento,
	Login, FechaEdicion 
	from Promociones
	-- where FechaFinal > getdate() or FechaFinal = '01/01/1900'
	order by FechaInicial desc

if @Opc = 2
	select '', IdPromocion as IdAcuerdo, Nombre, FechaInicial, FechaFinal, 
	case Status when 'A' then 'Activo' when 'B' then 'Baja' when 'G' then 'Generado' end as Status, Observaciones, IdDocumento, IdTipoDocumento,
	Login, FechaEdicion 
	from Promociones
	where FechaFinal > getdate() or FechaFinal = '01/01/1900'
	order by FechaInicial desc

if @Opc = 3
	select '', IdPromocion as IdAcuerdo, Nombre, FechaInicial, FechaFinal, 
	case Status when 'A' then 'Activo' when 'B' then 'Baja' when 'G' then 'Generado' end as Status, Observaciones, IdDocumento, IdTipoDocumento,
	Login, FechaEdicion 
	from Promociones
	where ( FechaInicial <= @FechaFinal and ( FechaFinal between @FechaInicial and @FechaFinal or FechaFinal = '01/01/1900' ) ) or 
	( FechaFinal >= @FechaInicial and FechaInicial between @FechaInicial and @FechaFinal  )
	order by FechaInicial desc

if @Opc = 4
	select '', IdPromocion as IdAcuerdo, Nombre, FechaInicial, FechaFinal, 
	case Status when 'A' then 'Activo' when 'B' then 'Baja' when 'G' then 'Generado' end as Status, Observaciones, IdDocumento, IdTipoDocumento,
	Login, FechaEdicion 
	from Promociones
	where Status = 'G' -- ( FechaFinal > getdate() or FechaFinal = '01/01/1900' ) and 
	order by FechaInicial desc

GO


