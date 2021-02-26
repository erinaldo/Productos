
use RouteADM 

update ClienteSucursal set RFC = replace(replace(REPLACE(RFC,'-',''),' ',''),'/','')

select RFC, * from ClienteSucursal 


