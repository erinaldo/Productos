SET NOCOUNT ON
DECLARE @NombreCodigoReporte [varchar](34), @NombreReporte [varchar](34), @IdReporte [int], @Asignar [varchar](8)
/* NOTA IMPORTANTE: Es necesario escribir el nombre del perfil al cual se desea asignar el reporte, esto en la variable @Asignar */
SET @Asignar = 'ESCRIBA AQUI EL NOMBRE DEL PERFIL AL QUE DESEA ASIGNAR EL REPORTE'
SET @NombreCodigoReporte = 'CorteCaja_25'
SET @NombreReporte = 'Corte De Caja'

IF EXISTS (SELECT TOP 1 [RepDinID] FROM [dbo].[ReporteDinamico] WHERE [Nombre] = @NombreCodigoReporte)
	BEGIN
		UPDATE [dbo].[ReporteDinamico] SET [Consulta] = 'EXEC [dbo].[stpr_CorteCaja_25] @filterStartDate = {0}, @filterEndDate = {1}' WHERE [Nombre] = @NombreCodigoReporte
	END
ELSE
	BEGIN
		INSERT INTO [dbo].[ReporteDinamico]([Nombre], [Consulta]) VALUES
		(@NombreCodigoReporte, 'EXEC [dbo].[stpr_CorteCaja_25] @filterStartDate = {0}, @filterEndDate = {1}')
	END

SET @IdReporte = (SELECT TOP 1 [RepDinID] FROM [dbo].[ReporteDinamico] WHERE [Nombre] = @NombreCodigoReporte)

IF EXISTS (SELECT TOP 1 [RepDinID] FROM [dbo].[FiltrosDinamicos] (NOLOCK) WHERE [RepDinID] = @IdReporte)
	BEGIN
		DELETE [dbo].[FiltrosDinamicos] WHERE [RepDinID] = @IdReporte
	END

IF NOT EXISTS (SELECT TOP 1 [RepDinID] FROM [dbo].[FiltrosDinamicos] (NOLOCK) WHERE [RepDinID] = @IdReporte)
	BEGIN
		INSERT INTO [dbo].[FiltrosDinamicos]([RepDinID], [TipoFiltro], [Opciones])
		SELECT TOP 1 [RepDinID], 4, 'REAI' FROM [dbo].[ReporteDinamico] WHERE [RepDinID] = @IdReporte
	END

DECLARE @ModuloR AS [varchar](16)
SET @ModuloR = (SELECT TOP 1 [MODId] FROM [dbo].[Modulo] (NOLOCK) WHERE [MENNombreClave] = 'XMReportesDinamicos')

DECLARE @VAVClave [varchar](3)
SET @VAVClave = (SELECT TOP 1 [RepDinID] FROM [dbo].[ReporteDinamico] (NOLOCK) WHERE [RepDinID] = @IdReporte)

IF NOT EXISTS (SELECT TOP 1 [VAVClave] FROM [dbo].[VARValor] (NOLOCK) WHERE [VARCodigo] = 'REPORTED' AND [VAVClave] = @VAVClave)
	BEGIN
		INSERT INTO [dbo].[VARValor]([VARCodigo], [VAVClave], [ClaveSAT], [Grupo], [Estado], [MFechaHora], [MUsuarioID]) VALUES ('REPORTED', @VAVClave, NULL, '', 1, GETDATE(), 'AdminDux')
	END

IF NOT EXISTS (SELECT TOP 1 [VAVClave] FROM [dbo].[VAVDescripcion] (NOLOCK) WHERE [VARCodigo] = 'REPORTED' AND [VAVClave] = @VAVClave)
	BEGIN
		INSERT INTO [dbo].[VAVDescripcion]([VARCodigo], [VAVClave], [VADTipoLenguaje], [Descripcion], [DescripcionSAT], [MFechaHora], [MUsuarioID]) VALUES ('REPORTED', @VAVClave, 'EM', @VAVClave + ' - ' + @NombreReporte, NULL, GETDATE(), 'AdminDux')
	END
ELSE
	BEGIN
		UPDATE [dbo].[VAVDescripcion] SET [Descripcion] = @VAVClave + ' - ' + @NombreReporte  WHERE [VARCodigo] = 'REPORTED' AND [VAVClave] = @VAVClave
	END

IF NOT EXISTS (SELECT TOP 1 [ACTId] FROM [dbo].[Actividad] (NOLOCK) WHERE [ACTId] = 'REPORTED' + @VAVClave)
	BEGIN
		INSERT INTO [dbo].[Actividad]([ACTId], [MENNombreClave], [MENDescripcionClave], [Imagen], [TipoActividad], [MUsuarioId], [MFechaHora])
		VALUES ('REPORTED' + @VAVClave, 'XAReportesDinamicos', 'XAReportesDinamicos', 0x, 21, 'AdminDux', GETDATE())
	END

IF NOT EXISTS (SELECT TOP 1 [ACTId] FROM [dbo].[Interfaz] (NOLOCK) WHERE [ACTId] = 'REPORTED' + @VAVClave)
	BEGIN
		INSERT INTO [dbo].[Interfaz]([ACTId], [INTTipoInterfaz], [MODId], [Tipo], [Componente], [Clase], [Procedimiento], [Permiso], [Secuencia], [FolioID], [ModuloMovDetalleClave], [MFechaHora], [MUsuarioId])
		VALUES ('REPORTED' + @VAVClave, 3, @ModuloR, 1, 'Filtros.aspx', LEFT(@VAVClave + ' - ' + @NombreReporte, 30), 'Load', 'E', @VAVClave, NULL, NULL, GETDATE(), 'AdminDux')
	END
ELSE
	BEGIN
		UPDATE [dbo].[Interfaz] SET [Clase] = LEFT(@VAVClave + ' - ' + @NombreReporte, 30) WHERE [ACTId] = 'REPORTED' + @VAVClave
	END

IF NOT EXISTS (SELECT TOP 1 [ACTId] FROM [dbo].[IntPer] (NOLOCK) WHERE [ACTId] = 'REPORTED' + @VAVClave AND [PERClave] = @Asignar)
	BEGIN
		INSERT INTO [dbo].[IntPer]([ACTId], [INTTipoInterfaz], [PERClave], [MODId], [Permiso], [Secuencia], [MFechaHora] ,[MUsuarioID])
		SELECT [ACTId], [INTTipoInterfaz], @Asignar, [MODId], [Permiso], [Secuencia], GETDATE() ,'AdminDux' FROM [dbo].[Interfaz] (NOLOCK) WHERE [ACTId] = 'REPORTED' + @VAVClave
	END
SET NOCOUNT OFF