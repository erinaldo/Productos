IF NOT EXISTS(SELECT * FROM ValorReferencia WHERE Valor = 1)
INSERT INTO ValorReferencia (Valor,Clave, Descripcion, Grupo, ValorCliente, Estado) VALUES(1,'TIPMEN','WEB',NULL,NULL,1);
IF NOT EXISTS(SELECT * FROM ValorReferencia WHERE Valor = 2)
INSERT INTO ValorReferencia (Valor,Clave, Descripcion, Grupo, ValorCliente, Estado) VALUES(2,'TIPMEN','MOVIL',NULL,NULL,1);
IF NOT EXISTS(SELECT * FROM ValorReferencia WHERE Valor = 3)
INSERT INTO ValorReferencia (Valor,Clave, Descripcion, Grupo, ValorCliente, Estado) VALUES(3,'TIPMEN','AMBOS',NULL,NULL,1);

IF NOT EXISTS(SELECT * FROM ValorReferencia WHERE Valor = 4)
INSERT INTO ValorReferencia (Valor,Clave, Descripcion, Grupo, ValorCliente, Estado) VALUES(4,'TIPUSU','PYC',NULL,NULL,1);
IF NOT EXISTS(SELECT * FROM ValorReferencia WHERE Valor = 5)
INSERT INTO ValorReferencia (Valor,Clave, Descripcion, Grupo, ValorCliente, Estado) VALUES(5,'TIPUSU','Almacenista',NULL,NULL,1);
IF NOT EXISTS(SELECT * FROM ValorReferencia WHERE Valor = 6)
INSERT INTO ValorReferencia (Valor,Clave, Descripcion, Grupo, ValorCliente, Estado) VALUES(6,'TIPUSU','Supervisor',NULL,NULL,1);
IF NOT EXISTS(SELECT * FROM ValorReferencia WHERE Valor = 7)
INSERT INTO ValorReferencia (Valor,Clave, Descripcion, Grupo, ValorCliente, Estado) VALUES(7,'TIPUSU','Técnico',1,NULL,1);

IF NOT EXISTS(SELECT * FROM ValorReferencia WHERE Valor = 8)
INSERT INTO ValorReferencia (Valor,Clave, Descripcion, Grupo, ValorCliente, Estado) VALUES(8,'ACTWEB','Perfiles',NULL,NULL,1);
IF NOT EXISTS(SELECT * FROM ValorReferencia WHERE Valor = 9)
INSERT INTO ValorReferencia (Valor,Clave, Descripcion, Grupo, ValorCliente, Estado) VALUES(9,'ACTWEB','Usuarios',NULL,NULL,1);
IF NOT EXISTS(SELECT * FROM ValorReferencia WHERE Valor = 10)
INSERT INTO ValorReferencia (Valor,Clave, Descripcion, Grupo, ValorCliente, Estado) VALUES(10,'ACTWEB','Sucursales',NULL,NULL,1);
IF NOT EXISTS(SELECT * FROM ValorReferencia WHERE Valor = 11)
INSERT INTO ValorReferencia (Valor,Clave, Descripcion, Grupo, ValorCliente, Estado) VALUES(11,'ACTWEB','Terminales',NULL,NULL,1);
IF NOT EXISTS(SELECT * FROM ValorReferencia WHERE Valor = 12)
INSERT INTO ValorReferencia (Valor,Clave, Descripcion, Grupo, ValorCliente, Estado) VALUES(12,'ACTWEB','Vehículos',NULL,NULL,1);
IF NOT EXISTS(SELECT * FROM ValorReferencia WHERE Valor = 13)
INSERT INTO ValorReferencia (Valor,Clave, Descripcion, Grupo, ValorCliente, Estado) VALUES(13,'ACTWEB','Herramienta y Equipo',NULL,NULL,1);
IF NOT EXISTS(SELECT * FROM ValorReferencia WHERE Valor = 14)
INSERT INTO ValorReferencia (Valor,Clave, Descripcion, Grupo, ValorCliente, Estado) VALUES(14,'ACTWEB','Configuraciones',NULL,NULL,1);
IF NOT EXISTS(SELECT * FROM ValorReferencia WHERE Valor = 15)
INSERT INTO ValorReferencia (Valor,Clave, Descripcion, Grupo, ValorCliente, Estado) VALUES(15,'ACTWEB','Auditoria de Recepción de Información',NULL,NULL,1);
IF NOT EXISTS(SELECT * FROM ValorReferencia WHERE Valor = 16)
INSERT INTO ValorReferencia (Valor,Clave, Descripcion, Grupo, ValorCliente, Estado) VALUES(16,'ACTWEB','Configurar Encuesta',NULL,NULL,1);
IF NOT EXISTS(SELECT * FROM ValorReferencia WHERE Valor = 17)
INSERT INTO ValorReferencia (Valor,Clave, Descripcion, Grupo, ValorCliente, Estado) VALUES(17,'ACTWEB','Generar Reportes',NULL,NULL,1);

IF NOT EXISTS(SELECT * FROM ValorReferencia WHERE Valor = 19)
INSERT INTO ValorReferencia (Valor,Clave, Descripcion, Grupo, ValorCliente, Estado) VALUES(19,'TIPOENC','Vehículo',NULL,NULL,1);
IF NOT EXISTS(SELECT * FROM ValorReferencia WHERE Valor = 20)
INSERT INTO ValorReferencia (Valor,Clave, Descripcion, Grupo, ValorCliente, Estado) VALUES(20,'TIPOENC','Equipo de seguridad',NULL,NULL,1);
IF NOT EXISTS(SELECT * FROM ValorReferencia WHERE Valor = 21)
INSERT INTO ValorReferencia (Valor,Clave, Descripcion, Grupo, ValorCliente, Estado) VALUES(21,'TIPOENC','Calidad',NULL,NULL,1);

IF NOT EXISTS(SELECT * FROM ValorReferencia WHERE Valor = 22)
INSERT INTO ValorReferencia (Valor,Clave, Descripcion, Grupo, ValorCliente, Estado) VALUES(22,'TIPOPRE','Opcional',NULL,NULL,1);
IF NOT EXISTS(SELECT * FROM ValorReferencia WHERE Valor = 23)
INSERT INTO ValorReferencia (Valor,Clave, Descripcion, Grupo, ValorCliente, Estado) VALUES(23,'TIPOPRE','Texto',NULL,NULL,1);
IF NOT EXISTS(SELECT * FROM ValorReferencia WHERE Valor = 24)
INSERT INTO ValorReferencia (Valor,Clave, Descripcion, Grupo, ValorCliente, Estado) VALUES(24,'TIPOPRE','Sí/No',NULL,NULL,1);
IF NOT EXISTS(SELECT * FROM ValorReferencia WHERE Valor = 25)
INSERT INTO ValorReferencia (Valor,Clave, Descripcion, Grupo, ValorCliente, Estado) VALUES(25,'TIPOPRE','Imagen',NULL,NULL,1);
IF NOT EXISTS(SELECT * FROM ValorReferencia WHERE Valor = 26)
INSERT INTO ValorReferencia (Valor,Clave, Descripcion, Grupo, ValorCliente, Estado) VALUES(26,'TIPOPRE','Porcentaje',NULL,NULL,1);

IF NOT EXISTS(SELECT * FROM ValorReferencia WHERE Valor = 30)
INSERT INTO ValorReferencia (Valor,Clave, Descripcion, Grupo, ValorCliente, Estado) VALUES(30,'REPWEB','Reporte de Contratos No Instalados',NULL,NULL,1);
IF NOT EXISTS(SELECT * FROM ValorReferencia WHERE Valor = 31)
INSERT INTO ValorReferencia (Valor,Clave, Descripcion, Grupo, ValorCliente, Estado) VALUES(31,'REPWEB','Reporte de Tiempos y Movimientos',NULL,NULL,1);
IF NOT EXISTS(SELECT * FROM ValorReferencia WHERE Valor = 32)
INSERT INTO ValorReferencia (Valor,Clave, Descripcion, Grupo, ValorCliente, Estado) VALUES(32,'REPWEB','Reporte de Auditoria de Cableado',NULL,NULL,1);
IF NOT EXISTS(SELECT * FROM ValorReferencia WHERE Valor = 33)
INSERT INTO ValorReferencia (Valor,Clave, Descripcion, Grupo, ValorCliente, Estado) VALUES(33,'REPWEB','Reporte de Auditoria de Visitas',NULL,NULL,1);
IF NOT EXISTS(SELECT * FROM ValorReferencia WHERE Valor = 34)
INSERT INTO ValorReferencia (Valor,Clave, Descripcion, Grupo, ValorCliente, Estado) VALUES(34,'REPWEB','Reporte de Ruta de Cuadrillas',NULL,NULL,1);
IF NOT EXISTS(SELECT * FROM ValorReferencia WHERE Valor = 35)
INSERT INTO ValorReferencia (Valor,Clave, Descripcion, Grupo, ValorCliente, Estado) VALUES(35,'REPWEB','Reporte de Ubicacion en Tiempo Real',NULL,NULL,1);




IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'TituloLoginWeb')
INSERT INTO Mensaje(ClaveMensaje,Descripcion,Ambiente) VALUES('TituloLoginWeb','Megacable Login',1);

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'NombreAplicacion')
INSERT INTO Mensaje(ClaveMensaje,Descripcion,Ambiente) VALUES('NombreAplicacion','Proyecto Megacable',1);

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'Login')
INSERT INTO Mensaje(ClaveMensaje,Descripcion,Ambiente) VALUES('Login','Login',1);

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'Usuario')
INSERT INTO Mensaje(ClaveMensaje,Descripcion,Ambiente) VALUES('Usuario','Usuario',3);

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'Contrasenia')
INSERT INTO Mensaje(ClaveMensaje,Descripcion,Ambiente) VALUES('Contrasenia','Contraseña',3);

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'Aceptar')
INSERT INTO Mensaje(ClaveMensaje,Descripcion,Ambiente) VALUES('Aceptar','Aceptar',3);

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'AcercaDe')
INSERT INTO Mensaje(ClaveMensaje,Descripcion,Ambiente) VALUES('AcercaDe','Acerca de',1);

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'Salir')
INSERT INTO Mensaje(ClaveMensaje,Descripcion,Ambiente) VALUES('Salir','Salir',3);



IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'Ciudad')
INSERT INTO Mensaje(ClaveMensaje,Descripcion,Ambiente) VALUES('Ciudad','Ciudad',1);

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'CodigoBarras')
INSERT INTO Mensaje(ClaveMensaje,Descripcion,Ambiente) VALUES('CodigoBarras','Codigo de Barras',1);

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'SalidaBase')
INSERT INTO Mensaje(ClaveMensaje,Descripcion,Ambiente) VALUES('SalidaBase','Salida de Base',1);

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'LlegadaBase')
INSERT INTO Mensaje(ClaveMensaje,Descripcion,Ambiente) VALUES('LlegadaBase','Llegada de Base',1);

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'Region')
INSERT INTO Mensaje(ClaveMensaje,Descripcion,Ambiente) VALUES('Region','Región',1);

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'NumeroSerie')
INSERT INTO Mensaje(ClaveMensaje,Descripcion,Ambiente) VALUES('NumeroSerie','Numero de Serie',1);

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'Fase')
INSERT INTO Mensaje(ClaveMensaje,Descripcion,Ambiente) VALUES('Fase','Fase',1);

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'Gps')
INSERT INTO Mensaje(ClaveMensaje,Descripcion,Ambiente) VALUES('Gps','GPS',1);

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'Sucursal')
INSERT INTO Mensaje(ClaveMensaje,Descripcion,Ambiente) VALUES('Sucursal','Sucursal',1);

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'Comentario')
INSERT INTO Mensaje(ClaveMensaje,Descripcion,Ambiente) VALUES('Comentario','Comentario',1);

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'Tecnico')
INSERT INTO Mensaje(ClaveMensaje,Descripcion,Ambiente) VALUES('Tecnico','Tecnico',1);






IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'MI0001')
INSERT INTO Mensaje(ClaveMensaje,Descripcion,Ambiente) VALUES('MI0001','El campo {0} es requerido',1);

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'MI0002')
INSERT INTO Mensaje(ClaveMensaje,Descripcion,Ambiente) VALUES('MI0002','La clave de usuario proporcionada no se encuentra registrada en el sistema',1);

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'MI0003')
INSERT INTO Mensaje(ClaveMensaje,Descripcion,Ambiente) VALUES('MI0003','La contraseña proporcionada es incorrecta',1);

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'MI0008')
INSERT INTO Mensaje(ClaveMensaje,Descripcion,Ambiente) VALUES('MI0008','Registro existente',1);


IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'ME0001')
INSERT INTO Mensaje(ClaveMensaje,Descripcion,Ambiente) VALUES('ME0001','El usuario proporcionado no tiene el permiso de acceso a este sistema',1);

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'ME0002')
INSERT INTO Mensaje(ClaveMensaje,Descripcion,Ambiente) VALUES('ME0002','El usuario proporcionado no se encuentra activo, póngase en contacto con el administrador del sistema',1);

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'ME0003')
INSERT INTO Mensaje(ClaveMensaje,Descripcion,Ambiente) VALUES('ME0003','El perfil del usuario proporcionado no se encuentra activo, póngase en contacto con el administrador del sistema',1);

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'Usuarios')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('Usuarios', 'Usuarios', 3)
IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'Clave')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('Clave', 'Clave', 3)
IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'Nombre')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('Nombre', 'Nombre', 3)
IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'Perfil')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('Perfil', 'Perfil', 3)
IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'Tipo')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('Tipo', 'Tipo', 3)
IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'Cuadrilla')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('Cuadrilla', 'Tipo', 3)
IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'Activo')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('Activo', 'Activo', 3)
IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'Actividad')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('Actividad', 'Actividad', 1)
IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'Todos')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('Todos', 'Todos', 1)
IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'Activos')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('Activos', 'Activos', 1)
IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'Inactivos')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('Inactivos', 'Inactivos', 1)
IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'ConfirmarContrasenia')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('ConfirmarContrasenia', 'Confirmar Contraseña', 1)
IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'MI0004')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('MI0004', 'La contraseña proporcionada no coincide con la confirmación', 1)

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'NumeroEconomico')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('NumeroEconomico', 'Número Economico', 1)
	
IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'Placas')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('Placas', 'Placas', 1)

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'Marca')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('Marca', 'Marca', 1)
	
IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'Submarca')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('Submarca', 'SubMarca', 1)

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'Modelo')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('Modelo', 'Modelo', 1)
	
IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'Vehiculos')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('Vehiculos', 'Vehículos', 1)

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'KmInicial')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('KmInicial', 'Km Inicial', 1)
	
IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'KmFinal')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('KmFinal', 'Km Final', 1)

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'CodigoBarras')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('CodigoBarras', 'Codigo de Barras', 1)

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'NuevoRegistro')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('NuevoRegistro', 'Nuevo Registro', 1)

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'Editar')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('Editar', 'Editar', 1)

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'BorrarFiltros')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('BorrarFiltros', 'Borrar Filtros', 1)

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'Filtrar')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('Filtrar', 'Filtrar', 1)

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'Guardar')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('Guardar', 'Guardar', 1)

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'Cancelar')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('Cancelar', 'Cancelar', 1)
	
IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'Insertar')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('Insertar', 'Insertar', 1)

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'Descripcion')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('Descripcion', 'Descripción', 1)
ELSE
	UPDATE Mensaje SET Descripcion = 'Descripción' WHERE ClaveMensaje = 'Descripcion'

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'Perfiles')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('Perfiles', 'Perfiles', 1)

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'ModificarPerfil')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('ModificarPerfil', 'Modificar Perfil', 1)

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'Actividades')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('Actividades', 'Actividades', 1)

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'ActividadesAsign')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('ActividadesAsign', 'Actividades Asignadas', 1)

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'SeleccionarTodos')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('SeleccionarTodos', 'Seleccionar Todos', 1)

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'CrearPerfil')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('CrearPerfil', 'Crear Perfil', 1)

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'AudRecepInfo')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('AudRecepInfo', 'Auditoria de Recepción de Información', 1)

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'Fecha')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('Fecha', 'Fecha', 1)

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'NoCuadrillas')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('NoCuadrillas', 'No. de Cuadrillas', 1)

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'CuadrillasSinSync')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('CuadrillasSinSync', 'Cuadrillas sin Sincronizar', 1)

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'Generar')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('Generar', 'Generar', 1)

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'Estado')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('Estado', 'Estado', 1)

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'HoraAgenda')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('HoraAgenda', 'Hora Agenda', 1)

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'HoraSincronizacion')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('HoraSincronizacion', 'Hora Sincronización', 1)

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'Encuestas')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('Encuestas', 'Encuestas', 1)

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'NombreEncuesta')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('NombreEncuesta', 'Nombre Encuesta', 1)

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'Pregunta')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('Pregunta', 'Pregunta', 1)

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'CrearEncuesta')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('CrearEncuesta', 'Crear Encuesta', 1)

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'ModificarEncuesta')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('ModificarEncuesta', 'Modificar Encuesta', 1)

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'Sucursales')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('Sucursales', 'Sucursales', 1)

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'Terminales')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('Terminales', 'Terminales', 1)

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'HerramientaEquipo')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('HerramientaEquipo', 'Herramienta y Equipo', 1)

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'Opciones')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('Opciones', 'Opciones', 1)

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'ConfGenerales')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('ConfGenerales', 'Configuraciones Generales', 1)

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'Parametro')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('Parametro', 'Parámetro', 1)

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'Valor')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('Valor', 'Valor', 1)

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'NombreAplicacion')
	INSERT INTO Mensaje(ClaveMensaje,Descripcion,Ambiente) VALUES('NombreAplicacion','Field Services',1);
ELSE
	UPDATE Mensaje SET Descripcion = 'Field Services' WHERE ClaveMensaje = 'NombreAplicacion'

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'Actualizar')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('Actualizar', 'Actualizar', 1)

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'Reporte')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('Reporte', 'Reporte', 1)

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'Consultar')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('Consultar', 'Consultar', 1)

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'GruposSupervision')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('GruposSupervision', 'Grupos de Supervisión', 1)

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'NoContrato')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('NoContrato', 'No. Contrato', 1)

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'Hora')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('Hora', 'Hora', 1)

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'Trabajo')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('Trabajo', 'Trabajo', 1)

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'MI0040')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('MI0040', 'No existe información que coincida con los filtros de fecha seleccionados', 1)



IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'Imprimir')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('Imprimir', 'Imprimir', 1)

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'TotalProblemas')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('TotalProblemas', 'Total Problemas', 1)

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'No.Suscriptor')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('No.Suscriptor', 'No. Suscriptor', 1)

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'NoTrabajosExcedente')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('NoTrabajosExcedente', 'No. de trabajos con excedente', 1)

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = '%Excedente')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('%Excedente', '% Excedente', 1)

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'Fotografias')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('Fotografias', 'Fotografias', 1)

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'DiferenciaMts')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('DiferenciaMts', 'Diferencia mts.', 1)





IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'ContratosAsignados')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('ContratosAsignados', 'Contratos Asignados', 1)
IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'Confirmados')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('Confirmados', 'Confirmados', 1)
IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'Atendidos')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('Atendidos', 'Atendidos', 1)
IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'ConProblema')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('ConProblema', 'Con Problema', 1)
IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'Visitados')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('Visitados', 'Visitados', 1)
IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'EficienciaServicio')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('EficienciaServicio', '%Eficiencia Servicio', 1)
IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'EficienciaTecnico')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('EficienciaTecnico', '%Eficiencia Tecnico', 1)
IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'Estatus')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('Estatus', 'Estatus', 1)



IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'TotalVisitados')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('TotalVisitados', 'Total Visitados', 1)

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'TotalAtendidos')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('TotalAtendidos', 'Total Atendidos', 1)

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'TiempoProVisita')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('TiempoProVisita', 'Tiempo Promedio Visita', 1)

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'TiempoProAtendidos')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('TiempoProAtendidos', 'Tiempo Promedio Atendidos', 1)

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'TiempoProTraslado')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('TiempoProTraslado', 'Tiempo Promedio Traslado', 1)
               
IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'InicioJornada')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('InicioJornada', 'Inicio Jornada', 1)

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'CargaGasInicial')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('CargaGasInicial', 'Carga Gas Inicial', 1)

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'No.Visita')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('No.Visita', 'No.Visita', 1)

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'No.Contrato')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('No.Contrato', 'No.Contrato', 1)

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'TiempoTraslado')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('TiempoTraslado', 'Tiempo Traslado', 1)

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'InicioVisita')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('InicioVisita', 'Inicio Visita', 1)

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'FinVisita')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('FinVisita', 'Fin Visita', 1)

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'TiempoVisita')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('TiempoVisita', 'Tiempo Visita', 1)

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'Estado')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('Estado', 'Estado', 1)

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'PuntosAcomulados')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('PuntosAcomulados', 'Puntos Acomulados', 1)

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'CargaGasFinal')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('CargaGasFinal', 'Carga Gas Final', 1)

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'FinJornada')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('FinJornada', 'Fin Jornada', 1)

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'Kolometraje')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('Kolometraje', 'Kilometraje', 1)
        
IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = '%EficienciaServicio')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('%EficienciaServicio', '% Eficiencia Servicio', 1)

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = '%EficienciaTecnico')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('%EficienciaTecnico', '% Eficiencia Técnico', 1)

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'FachadaDomicilio')
	INSERT INTO Mensaje(ClaveMensaje, Descripcion, Ambiente) VALUES('FachadaDomicilio', 'Fachada Domicilio', 1)

UPDATE Mensaje SET Descripcion = 'Estatus' WHERE ClaveMensaje = 'Estatus'

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'ME0025')
	INSERT INTO Mensaje (ClaveMensaje,Descripcion,Ambiente) VALUES ('ME0025','No se puede inactivar o dar de baja el registro ya que tiene información relacionada',1)

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'Igual')
	INSERT INTO Mensaje (ClaveMensaje,Descripcion,Ambiente) VALUES ('Igual','Igual',1)

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'Entre')
	INSERT INTO Mensaje (ClaveMensaje,Descripcion,Ambiente) VALUES ('Entre','Entre',1)

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'Reportes')
	INSERT INTO Mensaje (ClaveMensaje,Descripcion,Ambiente) VALUES ('Reportes','Reportes',1)

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'TipoActividadWEB')
	INSERT INTO Mensaje (ClaveMensaje,Descripcion,Ambiente) VALUES ('TipoActividadWEB','(WEB)',1)
	
IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'TipoActividadMobile')
	INSERT INTO Mensaje (ClaveMensaje,Descripcion,Ambiente) VALUES ('TipoActividadMobile','(Mobile)',1)

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'ModSucursalEquipo')
	INSERT INTO Mensaje (ClaveMensaje,Descripcion,Ambiente) VALUES ('ModSucursalEquipo','Modificar Sucursal / Equipo',1)

IF NOT EXISTS(SELECT * FROM Mensaje WHERE ClaveMensaje = 'Eliminar')
	INSERT INTO Mensaje (ClaveMensaje,Descripcion,Ambiente) VALUES ('Eliminar','Eliminar',1)


IF NOT EXISTS(SELECT * FROM Perfil WHERE ClavePerfil = 'Admin')
INSERT INTO Perfil (ClavePerfil,Nombre,Estado) VALUES('Admin','Administradores',1)

IF NOT EXISTS(SELECT * FROM Modulo WHERE ClaveModulo = 'Actividades')
INSERT INTO Modulo(ClaveModulo,Nombre,Estado) VALUES ('Actividades','Actividades',1);

IF NOT EXISTS(SELECT * FROM Modulo WHERE ClaveModulo = 'Reportes')
INSERT INTO Modulo(ClaveModulo,Nombre,Estado) VALUES ('Reportes','Reportes',1);

IF NOT EXISTS(SELECT * FROM Actividad WHERE ClaveActividad = 'NavegacionPerfil')
INSERT INTO Actividad(ClaveActividad,ClaveModulo,TipoIndice, Nombre, Estado) VALUES ('NavegacionPerfil','Actividades',8,'Perfiles',1);

IF NOT EXISTS(SELECT * FROM Actividad WHERE ClaveActividad = 'AdministracionUsuarios')
INSERT INTO Actividad(ClaveActividad,ClaveModulo,TipoIndice,  Nombre, Estado) VALUES ('AdministracionUsuarios','Actividades',9,'Usuarios',1);

IF NOT EXISTS(SELECT * FROM Actividad WHERE ClaveActividad = 'AdministracionSucursales')
INSERT INTO Actividad(ClaveActividad,ClaveModulo,TipoIndice,  Nombre, Estado) VALUES ('AdministracionSucursales','Actividades',10,'Sucursales',1);

IF NOT EXISTS(SELECT * FROM Actividad WHERE ClaveActividad = 'AdministracionTerminales')
INSERT INTO Actividad(ClaveActividad,ClaveModulo,TipoIndice,  Nombre, Estado) VALUES ('AdministracionTerminales','Actividades',11,'Terminales',1);

IF NOT EXISTS(SELECT * FROM Actividad WHERE ClaveActividad = 'AdministracionVehiculos')
INSERT INTO Actividad(ClaveActividad,ClaveModulo,TipoIndice,  Nombre, Estado) VALUES ('AdministracionVehiculos','Actividades',12,'Vehículos',1);

IF NOT EXISTS(SELECT * FROM Actividad WHERE ClaveActividad = 'AdministracionHerramientaEquipo')
INSERT INTO Actividad(ClaveActividad,ClaveModulo,TipoIndice,  Nombre, Estado) VALUES ('AdministracionHerramientaEquipo','Actividades',13,'Herramienta y Equipo',1);

IF NOT EXISTS(SELECT * FROM Actividad WHERE ClaveActividad = 'AdministracionConfiguracionesGenerales')
INSERT INTO Actividad(ClaveActividad,ClaveModulo,TipoIndice,  Nombre, Estado) VALUES ('AdministracionConfiguracionesGenerales','Actividades',14,'Configuraciones',1);

IF NOT EXISTS(SELECT * FROM Actividad WHERE ClaveActividad = 'AuditoriaRecepcionInformacion')
INSERT INTO Actividad(ClaveActividad,ClaveModulo,TipoIndice,  Nombre, Estado) VALUES ('AuditoriaRecepcionInformacion','Actividades',15,'Auditoria de Recepción de Información',1);

IF NOT EXISTS(SELECT * FROM Actividad WHERE ClaveActividad = 'NavegacionEncuesta')
INSERT INTO Actividad(ClaveActividad,ClaveModulo,TipoIndice,  Nombre, Estado) VALUES ('NavegacionEncuesta','Actividades',16,'Configurar Encuesta',1);

IF NOT EXISTS(SELECT * FROM Actividad WHERE ClaveActividad = 'GenerarReportes')
INSERT INTO Actividad(ClaveActividad,ClaveModulo,TipoIndice,  Nombre, Estado) VALUES ('GenerarReportes','Reportes',17,'Generar Reportes',1);

IF NOT EXISTS(SELECT * FROM Actividad WHERE ClaveActividad = 'AdministracionSucursalEquipo')
INSERT INTO Actividad(ClaveActividad,ClaveModulo,TipoIndice,  Nombre, Estado) VALUES ('AdministracionSucursalEquipo','Actividades',17,'Administración de Sucursal / Equipo',1);


IF NOT EXISTS(SELECT * FROM ActividadPerfil WHERE ClaveActividad = 'NavegacionPerfil' and ClavePerfil = 'Admin')
INSERT INTO ActividadPerfil(ClaveActividad,ClavePerfil) VALUES ('NavegacionPerfil','Admin');

IF NOT EXISTS(SELECT * FROM ActividadPerfil WHERE ClaveActividad = 'AdministracionUsuarios' and ClavePerfil = 'Admin')
INSERT INTO ActividadPerfil(ClaveActividad,ClavePerfil) VALUES ('AdministracionUsuarios','Admin');

IF NOT EXISTS(SELECT * FROM ActividadPerfil WHERE ClaveActividad = 'AdministracionSucursales' and ClavePerfil = 'Admin')
INSERT INTO ActividadPerfil(ClaveActividad,ClavePerfil) VALUES ('AdministracionSucursales','Admin');

IF NOT EXISTS(SELECT * FROM ActividadPerfil WHERE ClaveActividad = 'AdministracionTerminales' and ClavePerfil = 'Admin')
INSERT INTO ActividadPerfil(ClaveActividad,ClavePerfil) VALUES ('AdministracionTerminales','Admin');

IF NOT EXISTS(SELECT * FROM ActividadPerfil WHERE ClaveActividad = 'AdministracionVehiculos' and ClavePerfil = 'Admin')
INSERT INTO ActividadPerfil(ClaveActividad,ClavePerfil) VALUES ('AdministracionVehiculos','Admin');

IF NOT EXISTS(SELECT * FROM ActividadPerfil WHERE ClaveActividad = 'AdministracionHerramientaEquipo' and ClavePerfil = 'Admin')
INSERT INTO ActividadPerfil(ClaveActividad,ClavePerfil) VALUES ('AdministracionHerramientaEquipo','Admin');

IF NOT EXISTS(SELECT * FROM ActividadPerfil WHERE ClaveActividad = 'AdministracionConfiguracionesGenerales' and ClavePerfil = 'Admin')
INSERT INTO ActividadPerfil(ClaveActividad,ClavePerfil) VALUES ('AdministracionConfiguracionesGenerales','Admin');

IF NOT EXISTS(SELECT * FROM ActividadPerfil WHERE ClaveActividad = 'AuditoriaRecepcionInformacion' and ClavePerfil = 'Admin')
INSERT INTO ActividadPerfil(ClaveActividad,ClavePerfil) VALUES ('AuditoriaRecepcionInformacion','Admin');

IF NOT EXISTS(SELECT * FROM ActividadPerfil WHERE ClaveActividad = 'NavegacionEncuesta' and ClavePerfil = 'Admin')
INSERT INTO ActividadPerfil(ClaveActividad,ClavePerfil) VALUES ('NavegacionEncuesta','Admin');

IF NOT EXISTS(SELECT * FROM ActividadPerfil WHERE ClaveActividad = 'GenerarReportes' and ClavePerfil = 'Admin')
INSERT INTO ActividadPerfil(ClaveActividad,ClavePerfil) VALUES ('GenerarReportes','Admin');

IF NOT EXISTS(SELECT * FROM ActividadPerfil WHERE ClaveActividad = 'AdministracionSucursalEquipo' and ClavePerfil = 'Admin')
INSERT INTO ActividadPerfil(ClaveActividad,ClavePerfil) VALUES ('AdministracionSucursalEquipo','Admin');

IF NOT EXISTS(SELECT * FROM Region WHERE ClaveRegion = 'OCCI')
INSERT INTO Region(ClaveRegion,Nombre, Estado) VALUES ('OCCI','Occidente',1);

IF NOT EXISTS(SELECT * FROM Ciudad WHERE ClaveCiudad = 'GDL')
INSERT INTO Ciudad(ClaveCiudad,ClaveRegion,Nombre,Estado) VALUES ('GDL','OCCI','Guadalajara',1);

IF NOT EXISTS(SELECT * FROM Sucursal WHERE ClaveSucursal= 'GDL')
INSERT INTO Sucursal(ClaveSucursal,ClaveCiudad,ClaveRegion,Nombre,CodigoBarrasSalida,CodigoBarrasLlegada,Estado) VALUES ('GDL','GDL','OCCI','Guadalajara','','',1);

IF NOT EXISTS(SELECT * FROM Usuario WHERE ClaveUsuario = 'super')
INSERT INTO Usuario (ClaveUsuario,ClavePerfil, ClaveCuadrilla, ClaveSucursal, Tipo, Contrasenia, Nombre, Estado) VALUES ('super','Admin', NULL,'GDL',4,'123','Administrador del Sistema',1)


