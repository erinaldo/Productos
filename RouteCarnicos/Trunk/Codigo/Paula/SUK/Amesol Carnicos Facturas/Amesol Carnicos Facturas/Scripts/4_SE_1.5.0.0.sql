if not exists(Select * from Mensaje where MENClave ='ERMSEMESC_NGENERAL')
begin
INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('ERMSEMESC_NGENERAL','A',3,3,'Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('ERMSEMESC_NGENERAL','EC','Sub-Empresa','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('ERMSEMESC_NGENERAL','ECR','Sub-Empresa','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('ERMSEMESC_NGENERAL','EM','Sub-Empresa','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('ERMSEMESC_NGENERAL','EP','Sub-Empresa','Admin',getdate())
end

if not exists(Select * from Mensaje where MENClave ='ERMSEMESC_MGENERALC')
begin
INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('ERMSEMESC_MGENERALC','A',3,3,'Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('ERMSEMESC_MGENERALC','EC','Crear Sub-Empresa','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('ERMSEMESC_MGENERALC','ECR','Crear Sub-Empresa','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('ERMSEMESC_MGENERALC','EM','Crear Sub-Empresa','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('ERMSEMESC_MGENERALC','EP','Crear Sub-Empresa','Admin',getdate())
end

if not exists(Select * from Mensaje where MENClave ='ERMSEMESC_MGENERALM')
begin
INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('ERMSEMESC_MGENERALM','A',3,3,'Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('ERMSEMESC_MGENERALM','EC','Modificar Sub-Empresa','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('ERMSEMESC_MGENERALM','ECR','Modificar Sub-Empresa ','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('ERMSEMESC_MGENERALM','EM','Modificar Sub-Empresa ','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('ERMSEMESC_MGENERALM','EP','Modificar Sub-Empresa','Admin',getdate())
end

if not exists(Select * from Mensaje where MENClave ='SEMTipoEstado')
begin
INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('SEMTipoEstado','T',3,3,'Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMTipoEstado','EC','Estado','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMTipoEstado','ECR','Estado','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMTipoEstado','EM','Estado','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMTipoEstado','EP','Estado','Admin',getdate())
end

if not exists(Select * from Mensaje where MENClave ='SEMTipoEstadoT')
begin
INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('SEMTipoEstadoT','T',3,3,'Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMTipoEstadoT','EC','Estado en el que se encuentra la Sub-Empresa. ','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMTipoEstadoT','ECR','Estado en el que se encuentra la Sub-Empresa. ','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMTipoEstadoT','EM','Estado en el que se encuentra la Sub-Empresa. ','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMTipoEstadoT','EP','Estado en el que se encuentra la Sub-Empresa. ','Admin',getdate())
end

--************************************
if not exists(Select * from Mensaje where MENClave ='SEMNombreEmpresa')
begin
INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('SEMNombreEmpresa','T',3,3,'Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMNombreEmpresa','EC','Sub-Empresa','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMNombreEmpresa','ECR','Sub-Empresa','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMNombreEmpresa','EM','Sub-Empresa','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMNombreEmpresa','EP','Sub-Empresa','Admin',getdate())
end

if not exists(Select * from Mensaje where MENClave ='SEMNombreEmpresaT')
begin
INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('SEMNombreEmpresaT','T',3,3,'Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMNombreEmpresaT','EC','Nombre de la Sub-Empresa. ','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMNombreEmpresaT','ECR','Nombre de la Sub-Empresa. ','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMNombreEmpresaT','EM','Nombre de la Sub-Empresa. ','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMNombreEmpresaT','EP','Nombre de la Sub-Empresa. ','Admin',getdate())
end





if not exists(Select * from Mensaje where MENClave ='SEMRFC')
begin
INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('SEMRFC','T',3,3,'Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMRFC','EC','R.F.C.','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMRFC','ECR','R.F.C. ','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMRFC','EM','R.F.C.','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMRFC','EP','R.F.C.','Admin',getdate())
end

if not exists(Select * from Mensaje where MENClave ='SEMRFCT')
begin
INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('SEMRFCT','T',3,3,'Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMRFCT','EC','Registro Federal de Contribuyentes de la Sub-Empresa. ','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMRFCT','ECR','Registro Federal de Contribuyentes de la Sub-Empresa.','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMRFCT','EM','Registro Federal de Contribuyentes de la Sub-Empresa.','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMRFCT','EP','Registro Federal de Contribuyentes de la Sub-Empresa.','Admin',getdate())
end


if not exists(Select * from Mensaje where MENClave ='SEMPais')
begin
INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('SEMPais','T',3,3,'Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMPais','EC','País','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMPais','ECR','País','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMPais','EM','País','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMPais','EP','País','Admin',getdate())
end

if not exists(Select * from Mensaje where MENClave ='SEMPaisT')
begin
INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('SEMPaisT','T',3,3,'Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMPaisT','EC','País donde se ubica la Sub-Empresa. ','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMPaisT','ECR','País donde se ubica la Sub-Empresa. ','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMPaisT','EM','País donde se ubica la Sub-Empresa. ','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMPaisT','EP','País donde se ubica la Sub-Empresa. ','Admin',getdate())
end





if not exists(Select * from Mensaje where MENClave ='SEMRegion')
begin
INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('SEMRegion','T',3,3,'Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMRegion','EC','Región','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMRegion','ECR','Región','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMRegion','EM','Región','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMRegion','EP','Región','Admin',getdate())
end

if not exists(Select * from Mensaje where MENClave ='SEMRegionT')
begin
INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('SEMRegionT','T',3,3,'Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMRegionT','EC','Región donde se ubica la Sub-Empresa.','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMRegionT','ECR','Región donde se ubica la Sub-Empresa.','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMRegionT','EM','Región donde se ubica la Sub-Empresa.','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMRegionT','EP','Región donde se ubica la Sub-Empresa.','Admin',getdate())
end



if not exists(Select * from Mensaje where MENClave ='SEMLocalidad')
begin
INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('SEMLocalidad','T',3,3,'Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMLocalidad','EC','Localidad','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMLocalidad','ECR','Localidad','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMLocalidad','EM','Localidad','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMLocalidad','EP','Localidad','Admin',getdate())
end

if not exists(Select * from Mensaje where MENClave ='SEMLocalidadT')
begin
INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('SEMLocalidadT','T',3,3,'Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMLocalidadT','EC','Nombre de la localidad en donde se localiza la Sub-Empresa.','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMLocalidadT','ECR','Nombre de la localidad en donde se localiza la Sub-Empresa.','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMLocalidadT','EM','Nombre de la localidad en donde se localiza la Sub-Empresa.','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMLocalidadT','EP','Nombre de la localidad en donde se localiza la Sub-Empresa.','Admin',getdate())
end



if not exists(Select * from Mensaje where MENClave ='SEMReferenciaDom')
begin
INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('SEMReferenciaDom','T',3,3,'Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMReferenciaDom','EC','Referencia','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMReferenciaDom','ECR','Referencia','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMReferenciaDom','EM','Referencia','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMReferenciaDom','EP','Referencia','Admin',getdate())
end

if not exists(Select * from Mensaje where MENClave ='SEMReferenciaDomT')
begin
INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('SEMReferenciaDomT','T',3,3,'Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMReferenciaDomT','EC','Cruce de calles en donde se localiza el domicilio de la Sub-Empresa.','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMReferenciaDomT','ECR','Cruce de calles en donde se localiza el domicilio de la Sub-Empresa.','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMReferenciaDomT','EM','Cruce de calles en donde se localiza el domicilio de la Sub-Empresa.','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMReferenciaDomT','EP','Cruce de calles en donde se localiza el domicilio de la Sub-Empresa.','Admin',getdate())
end




if not exists(Select * from Mensaje where MENClave ='SEMCiudad')
begin
INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('SEMCiudad','T',3,3,'Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMCiudad','EC','Municipio ','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMCiudad','ECR','Municipio ','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMCiudad','EM','Municipio ','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMCiudad','EP','Municipio ','Admin',getdate())
end

if not exists(Select * from Mensaje where MENClave ='SEMCiudadT')
begin
INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('SEMCiudadT','T',3,3,'Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMCiudadT','EC','Municipio donde se localiza la Sub-Empresa.','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMCiudadT','ECR','Municipio donde se localiza la Sub-Empresa.','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMCiudadT','EM','Municipio donde se localiza la Sub-Empresa.','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMCiudadT','EP','Municipio donde se localiza la Sub-Empresa.','Admin',getdate())
end





if not exists(Select * from Mensaje where MENClave ='SEMColonia')
begin
INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('SEMColonia','T',3,3,'Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMColonia','EC','Colonia ','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMColonia','ECR','Colonia ','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMColonia','EM','Colonia ','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMColonia','EP','Colonia ','Admin',getdate())
end

if not exists(Select * from Mensaje where MENClave ='SEMColoniaT')
begin
INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('SEMColoniaT','T',3,3,'Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMColoniaT','EC','Colonia donde se ubica la Sub-Empresa.','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMColoniaT','ECR','Colonia donde se ubica la Sub-Empresa.','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMColoniaT','EM','Colonia donde se ubica la Sub-Empresa.','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMColoniaT','EP','Colonia donde se ubica la Sub-Empresa.','Admin',getdate())
end




if not exists(Select * from Mensaje where MENClave ='SEMCalle')
begin
INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('SEMCalle','T',3,3,'Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMCalle','EC','Calle ','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMCalle','ECR','Calle ','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMCalle','EM','Calle ','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMCalle','EP','Calle ','Admin',getdate())
end

if not exists(Select * from Mensaje where MENClave ='SEMCalleT')
begin
INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('SEMCalleT','T',3,3,'Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMCalleT','EC','Calle donde se ubica la Sub-Empresa. ','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMCalleT','ECR','Calle donde se ubica la Sub-Empresa. ','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMCalleT','EM','Calle donde se ubica la Sub-Empresa. ','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMCalleT','EP','Colonia donde se ubica la Sub-Empresa.','Admin',getdate())
end




if not exists(Select * from Mensaje where MENClave ='SEMNumero')
begin
INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('SEMNumero','T',3,3,'Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMNumero','EC','Exterior  ','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMNumero','ECR','Exterior  ','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMNumero','EM','Exterior  ','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMNumero','EP','Exterior  ','Admin',getdate())
end

if not exists(Select * from Mensaje where MENClave ='SEMNumeroT')
begin
INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('SEMNumeroT','T',3,3,'Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMNumeroT','EC','Número Exterior donde se ubica la Sub-Empresa.','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMNumeroT','ECR','Número Exterior donde se ubica la Sub-Empresa.','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMNumeroT','EM','Número Exterior donde se ubica la Sub-Empresa.','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMNumeroT','EP','Número Exterior donde se ubica la Sub-Empresa.','Admin',getdate())
end



if not exists(Select * from Mensaje where MENClave ='SEMNumeroInterior')
begin
INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('SEMNumeroInterior','T',3,3,'Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMNumeroInterior','EC','Interior  ','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMNumeroInterior','ECR','Interior  ','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMNumeroInterior','EM','Interior  ','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMNumeroInterior','EP','Interior  ','Admin',getdate())
end

if not exists(Select * from Mensaje where MENClave ='SEMNumeroInteriorT')
begin
INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('SEMNumeroInteriorT','T',3,3,'Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMNumeroInteriorT','EC','Número Interior donde se ubica la Sub-Empresa.','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMNumeroInteriorT','ECR','Número Interior donde se ubica la Sub-Empresa.','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMNumeroInteriorT','EM','Número Interior donde se ubica la Sub-Empresa.','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMNumeroInteriorT','EP','Número Interior donde se ubica la Sub-Empresa.','Admin',getdate())
end




if not exists(Select * from Mensaje where MENClave ='SEMCodigoPostal')
begin
INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('SEMCodigoPostal','T',3,3,'Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMCodigoPostal','EC','C.P.','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMCodigoPostal','ECR','C.P.','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMCodigoPostal','EM','C.P.','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMCodigoPostal','EP','C.P.','Admin',getdate())
end

if not exists(Select * from Mensaje where MENClave ='SEMCodigoPostalT')
begin
INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('SEMCodigoPostalT','T',3,3,'Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMCodigoPostalT','EC','Código Postal del Domicilio de la Sub-Empresa.','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMCodigoPostalT','ECR','Código Postal del Domicilio de la Sub-Empresa.','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMCodigoPostalT','EM','Código Postal del Domicilio de la Sub-Empresa.','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMCodigoPostalT','EP','Código Postal del Domicilio de la Sub-Empresa.','Admin',getdate())
end




if not exists(Select * from Mensaje where MENClave ='SEMLogotipo')
begin
INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('SEMLogotipo','T',3,3,'Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMLogotipo','EC','Logotipo','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMLogotipo','ECR','Logotipo','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMLogotipo','EM','Logotipo','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMLogotipo','EP','Logotipo','Admin',getdate())
end

if not exists(Select * from Mensaje where MENClave ='SEMLogotipoT')
begin
INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('SEMLogotipoT','T',3,3,'Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMLogotipoT','EC','Logotipo de la Sub-Empresa.','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMLogotipoT','ECR','Logotipo de la Sub-Empresa.','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMLogotipoT','EM','Logotipo de la Sub-Empresa.','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMLogotipoT','EP','Logotipo de la Sub-Empresa.','Admin',getdate())
end



if not exists(Select * from Mensaje where MENClave ='SEMTelefono')
begin
INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('SEMTelefono','T',3,3,'Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMTelefono','EC','Teléfono','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMTelefono','ECR','Teléfono','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMTelefono','EM','Teléfono','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMTelefono','EP','Teléfono','Admin',getdate())
end

if not exists(Select * from Mensaje where MENClave ='SEMTelefonoT')
begin
INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('SEMTelefonoT','T',3,3,'Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMTelefonoT','EC','Número de Teléfono de la Sub-Empresa.','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMTelefonoT','ECR','Número de Teléfono de la Sub-Empresa.','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMTelefonoT','EM','Número de Teléfono de la Sub-Empresa.','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMTelefonoT','EP','Número de Teléfono de la Sub-Empresa.','Admin',getdate())
end


if not exists(Select * from Mensaje where MENClave ='SEMDomicilio')
begin
INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('SEMDomicilio','T',3,3,'Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMDomicilio','EC','Domicilio','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMDomicilio','ECR','Domicilio','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMDomicilio','EM','Domicilio','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMDomicilio','EP','Domicilio','Admin',getdate())
end




if not exists(Select * from Mensaje where MENClave ='SEMDatosG')
begin
INSERT INTO Mensaje(MENClave,TipoMensaje,TipoAplicacion,TipoProyecto,MUsuarioId,MFechaHora) VALUES('SEMDatosG','T',3,3,'Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMDatosG','EC','Datos Generales','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMDatosG','ECR','Datos Generales','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMDatosG','EM','Datos Generales','Admin',getdate())
INSERT INTO MENDetalle(MENClave,MEDTipoLenguaje,Descripcion,MUsuarioId,MFechaHora) VALUES('SEMDatosG','EP','Datos Generales','Admin',getdate())
end



