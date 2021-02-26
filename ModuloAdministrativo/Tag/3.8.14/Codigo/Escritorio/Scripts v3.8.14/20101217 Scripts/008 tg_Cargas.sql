USE [RouteADM]
GO

/****** Object:  Trigger [tgg_Cargas]    Script Date: 12/28/2010 12:11:12 ******/
IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[tgg_Cargas]'))
DROP TRIGGER [dbo].[tgg_Cargas]
GO

USE [RouteADM]
GO

/****** Object:  Trigger [dbo].[tgg_Cargas]    Script Date: 12/28/2010 12:11:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE TRIGGER [dbo].[tgg_Cargas] ON [dbo].[Cargas] 
FOR INSERT, UPDATE 
AS

declare @Route as int, @IdCedis as bigint
set @IdCedis = 0

set @Route = isnull( ( select Route from Configuracion where IdCedis in ( select IdCedis from Inserted ) ), 0 )
set @IdCedis = ( select IdCedis from Configuracion )

--if @Route = 1
--begin

--	if not exists(select Cargas.IdCedis from Inserted Cargas 
--		inner join RouteSurtidos on RouteSurtidos.IdCedis = Cargas.IdCedis and RouteSurtidos.IdSurtido = Cargas.IdSurtido and RouteSurtidos.IdCarga = Cargas.IdCarga )
--	begin
--		insert into RouteSurtidos
--		select IdCedis, IdSurtido, IdCarga, ISNULL((select MAX(FolioRoute)+1 from RouteSurtidos), 1)
--		from Inserted Cargas 
--	end
	
--	insert into Route.dbo.tmp_Carga
--	select Cargas.IdCedis, RouteSurtidos.FolioRoute, replicate('0', 2 - len( DAY(Fecha) ) ) + cast( DAY(Fecha) as varchar(2)) + '/' + 
--	replicate('0', 2 - len( month(Fecha) ) ) + cast( month(Fecha) as varchar(2)) + '/' + cast( year(Fecha) as varchar(4)), 10, Cargas.IdCarga, 2, case Status when 'A' then 5 else 0 end, 1, GETDATE(), cast( Cargas.IdCedis as varchar(10) ) + replicate('0', 4 - len( IdRuta ) ) + cast( IdRuta as varchar(10))
--	from Inserted Cargas 
--	inner join RouteSurtidos on RouteSurtidos.IdCedis = Cargas.IdCedis and RouteSurtidos.IdSurtido = Cargas.IdSurtido and RouteSurtidos.IdCarga = Cargas.IdCarga 

--end
GO


