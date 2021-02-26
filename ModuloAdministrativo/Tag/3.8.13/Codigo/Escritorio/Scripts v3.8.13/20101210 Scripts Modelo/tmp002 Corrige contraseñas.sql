use RouteADM 

update RouteCPC.dbo.Usuarios set Password = USUADM.Password, IdCedis = USUADM.IdCedis 
from RouteADM.dbo.Usuarios USUADM, RouteCPC.dbo.Usuarios USUCPC
where USUADM.Login = USUCPC.Login collate SQL_Latin1_General_CP1_CI_AS

select usuadm.Login, USUADM.Password, USUCPC.Password
from RouteADM.dbo.Usuarios USUADM, RouteCPC.dbo.Usuarios USUCPC
where USUADM.Login = USUCPC.Login collate SQL_Latin1_General_CP1_CI_AS

