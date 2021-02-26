
select VEN.LimiteDescuento 
from Route.dbo.Vendedor as VEN
inner join Route.dbo.Usuario as USU on USU.USUId = VEN.USUId 
where Route.dbo.FNObtenerRutaADMInter( USU.Clave ) = 3 -- and Route.dbo.FNObtenerCEDIADMInter( VEN.AlmacenID ) = 3
