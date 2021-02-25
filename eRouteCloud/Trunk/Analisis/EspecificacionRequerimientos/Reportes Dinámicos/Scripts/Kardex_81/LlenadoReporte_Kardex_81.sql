SET NOCOUNT ON
DECLARE @NombreReporte [varchar](34), @IdReporte [int], @VARCodigoR [varchar](35), @Perfil [varchar](16), @Asignar [varchar](8)
/*Es necesario escribir el perfil al cual se desea asignar el reporte, esto en la variable @Asignar*/
SET @Asignar = 'ESCRIBA AQUI EL NOMBRE DEL PERFIL AL QUE DESEA ASIGNAR EL REPORTE'
SET @NombreReporte = 'Kardex_81'
SET @VARCodigoR = 'REPORTED'
SET @Perfil = 'AdminDux'

IF EXISTS (SELECT TOP 1 [RepDinID] FROM [dbo].[ReporteDinamico] WHERE [Nombre] = @NombreReporte)
	BEGIN
		UPDATE [dbo].[ReporteDinamico] SET [Consulta] = 'EXEC [dbo].[stpr_Kardex_81] @filtroCedis = {0}, @filtroFechaInicio = {1}, @filtroFechaFin = {2}, @filtroEsquemasProd = {3}'  WHERE [Nombre] = @NombreReporte
	END
ELSE
	BEGIN
		INSERT INTO [dbo].[ReporteDinamico]([Nombre], [Consulta]) VALUES
		(@NombreReporte, 'EXEC [dbo].[stpr_Kardex_81] @filtroCedis = {0}, @filtroFechaInicio = {1}, @filtroFechaFin = {2}, @filtroEsquemasProd = {3}')
	END

SET @IdReporte = (SELECT TOP 1 [RepDinID] FROM [dbo].[ReporteDinamico] WHERE [Nombre] = @NombreReporte)
IF NOT EXISTS (SELECT TOP 1 [RepDinID] FROM [dbo].[FiltrosDinamicos] (NOLOCK) WHERE [RepDinID] = @IdReporte)
BEGIN
	INSERT INTO [dbo].[FiltrosDinamicos]([RepDinID], [TipoFiltro], [Opciones])
	SELECT TOP 1 [RepDinID], 1, 'RMAA' FROM [dbo].[ReporteDinamico] WHERE [RepDinID] = @IdReporte
	INSERT INTO [dbo].[FiltrosDinamicos]([RepDinID], [TipoFiltro], [Opciones])
	SELECT TOP 1 [RepDinID], 4, 'REAA' FROM [dbo].[ReporteDinamico] WHERE [RepDinID] = @IdReporte
	INSERT INTO [dbo].[FiltrosDinamicos]([RepDinID], [TipoFiltro], [Opciones])
	SELECT TOP 1 [RepDinID], 8, 'RMAA' FROM [dbo].[ReporteDinamico] WHERE [RepDinID] = @IdReporte
END

DECLARE @ModuloR AS [varchar](16)
SET @ModuloR = (SELECT TOP 1 [MODId] FROM [dbo].[Modulo] (NOLOCK) WHERE [MENNombreClave] = 'XMReportesDinamicos')
DECLARE @VAVClave [varchar](3)
SET @VAVClave = (SELECT TOP 1 [RepDinID] FROM [dbo].[ReporteDinamico] (NOLOCK) WHERE [RepDinID] = @IdReporte)

IF NOT EXISTS (SELECT TOP 1 [VAVClave] FROM [dbo].[VARValor] (NOLOCK) WHERE [VARCodigo] = @VARCodigoR AND [VAVClave] = @VAVClave)
	BEGIN
		INSERT INTO [dbo].[VARValor]([VARCodigo], [VAVClave], [ClaveSAT], [Grupo], [Estado], [MFechaHora], [MUsuarioID]) VALUES (@VARCodigoR, @VAVClave, NULL, '', 1, GETDATE(), @Perfil)
	END

IF NOT EXISTS (SELECT TOP 1 [VAVClave] FROM [dbo].[VAVDescripcion] (NOLOCK) WHERE [VARCodigo] = @VARCodigoR AND [VAVClave] = @VAVClave)
	BEGIN
		INSERT INTO [dbo].[VAVDescripcion]([VARCodigo], [VAVClave], [VADTipoLenguaje], [Descripcion], [DescripcionSAT], [MFechaHora], [MUsuarioID]) VALUES (@VARCodigoR, @VAVClave, 'EM', @VAVClave + ' - ' + @NombreReporte, NULL, GETDATE(), @Perfil)
	END

IF NOT EXISTS (SELECT TOP 1 [ACTId] FROM [dbo].[Actividad] (NOLOCK) WHERE [ACTId] = @VARCodigoR + @VAVClave)
	BEGIN
		INSERT INTO [dbo].[Actividad]([ACTId], [MENNombreClave], [MENDescripcionClave], [Imagen], [TipoActividad], [MUsuarioId], [MFechaHora])
		VALUES (@VARCodigoR + @VAVClave, 'XAReportesDinamicos', 'XAReportesDinamicos', 0x, 21, @Perfil, GETDATE())
	END

IF NOT EXISTS (SELECT TOP 1 [ACTId] FROM [dbo].[Interfaz] (NOLOCK) WHERE [ACTId] = @VARCodigoR + @VAVClave)
	BEGIN
		INSERT INTO [dbo].[Interfaz]([ACTId], [INTTipoInterfaz], [MODId], [Tipo], [Componente], [Clase], [Procedimiento], [Permiso], [Secuencia], [FolioID], [ModuloMovDetalleClave], [MFechaHora], [MUsuarioId])
		VALUES (@VARCodigoR + @VAVClave, 3, @ModuloR, 1, 'Filtros.aspx', LEFT(@VAVClave + ' - ' + @NombreReporte, 30), 'Load', 'E', @VAVClave, NULL, NULL, GETDATE(), @Perfil)
	END

IF NOT EXISTS (SELECT TOP 1 [ACTId] FROM [dbo].[IntPer] (NOLOCK) WHERE [ACTId] = @VARCodigoR + @VAVClave AND [PERClave] = @Asignar)
	BEGIN
		INSERT INTO [dbo].[IntPer]([ACTId], [INTTipoInterfaz], [PERClave], [MODId], [Permiso], [Secuencia], [MFechaHora] ,[MUsuarioID])
		SELECT [ACTId], [INTTipoInterfaz], @Asignar, [MODId], [Permiso], [Secuencia], GETDATE() ,'AdminDux' FROM [dbo].[Interfaz] (NOLOCK) WHERE [ACTId] = @VARCodigoR + @VAVClave
	END
SET NOCOUNT OFF