USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[sel_Periodo]    Script Date: 03/25/2011 23:50:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sel_Periodo]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sel_Periodo]
GO

USE [RouteCPC]
GO

/****** Object:  StoredProcedure [dbo].[sel_Periodo]    Script Date: 03/25/2011 23:50:19 ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[sel_Periodo] 
@IdCedis as bigint,
@Agno as int,
@Periodo as bigint,
@Tipo as char(1),
@Status as char(1),
@Opc as int

AS 

if @Opc = 1
	select isnull(Status, '') from Periodos where IdCedis = @IdCedis and Agno = @Agno and Periodo = @Periodo and Tipo = @Tipo

if @Opc = 2
	select IdCedis, Agno, 
	case Periodo
		when 1 then 'Enero'
		when 2 then 'Febrero'
		when 3 then 'Marzo'
		when 4 then 'Abril'
		when 5 then 'Mayo'
		when 6 then 'Junio'
		when 7 then 'Julio'
		when 8 then 'Agosto'
		when 9 then 'Septiembre'
		when 10 then 'Octubre'
		when 11 then 'Noviembre'
		when 12 then 'Diciembre'
	end as Mes, 
	case Status
		when 'A' then 'Abierto'
		when 'C' then 'Cerrado'
	end as Status, Periodo
	from periodos
	where IdCedis = @IdCedis and Agno = @Agno

if @Opc = 3
	select IdCedis
	from periodos
	where IdCedis = @IdCedis and Agno = @Agno and Status = 'A'
	
if @Opc = 4
	select Periodos.IdCedis, Cedis, Periodos.Status 
	from Periodos 
	inner join Cedis on Cedis.IdCedis = Periodos.IdCedis 
	where Agno = @Agno and Periodo = @Periodo and Periodos.Status <> 'C'

GO


