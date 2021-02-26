
select *
from SEMHist 
where ClienteClave is not null
--D:\Amesol\RouteADM\RouteADM v3.8.15\CFD\SAT Mensual
--D:\Amesol\RouteADM\RouteADM v3.8.15\CFD\XML CFD
--D:\Amesol\RouteADM\RouteADM v3.8.15\CFD\Certificado
update SEMHist set 
	DirRepMensual = replace(DirRepMensual,'D:\Amesol\RouteADM\RouteADM v3.8.15\','C:\'),
	DirDocXML = replace(DirDocXML,'D:\Amesol\RouteADM\RouteADM v3.8.15\','C:\'),
	DirArchivosFacElec = replace(DirArchivosFacElec,'D:\Amesol\RouteADM\RouteADM v3.8.15\','C:\')
where ClienteClave is not null

select *
from SEMHist 
where ClienteClave is not null
