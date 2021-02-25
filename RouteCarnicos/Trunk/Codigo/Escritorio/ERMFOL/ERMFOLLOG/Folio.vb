
Imports ERMFOLLOG.Amesol
Imports System.Text

Public Class cFolio
    Private vcTbFolio As LbDatos.cTabla
    Public Tabla As cFOLTabla
    'Public dsDatos As cFOLDataSet
    Private vcFODArray As New ArrayList
    Private vcFOSArrayOriginal As New ArrayList
    Private vcFSHArrayOriginal As New ArrayList
    Public vbHistorico As Boolean = False
    Dim bFoliosTerminal, bComprobanteDig As Boolean

    Private vcConexion As LbConexion.cConexion = LbConexion.cConexion.Instancia
    Private vcEstado As eEstado

#Region "Propiedades"
    Public Property FolioID() As String
        Get
            Return vcTbFolio.Campos("FolioID").Valor
        End Get
        Set(ByVal Value As String)
            If vcEstado = eEstado.Vacio Or vcEstado = eEstado.Nuevo Then
                vcTbFolio.Campos("FolioID").Valor = Value
            End If
        End Set
    End Property

    Public Property ModuloMovDetalleClave() As String
        Get
            Return vcTbFolio.Campos("ModuloMovDetalleClave").Valor
        End Get
        Set(ByVal Value As String)
            vcTbFolio.Campos("ModuloMovDetalleClave").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property Descripcion() As String
        Get
            Return vcTbFolio.Campos("Descripcion").Valor
        End Get
        Set(ByVal Value As String)
            vcTbFolio.Campos("Descripcion").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property ValorInicial() As String
        Get
            Return vcTbFolio.Campos("ValorInicial").Valor
        End Get
        Set(ByVal Value As String)
            vcTbFolio.Campos("ValorInicial").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property TipoEstado() As Integer
        Get
            Return vcTbFolio.Campos("TipoEstado").Valor
        End Get
        Set(ByVal Value As Integer)
            vcTbFolio.Campos("TipoEstado").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property MUsuarioId() As String
        Get
            Return vcTbFolio.Campos("MUsuarioId").Valor
        End Get
        Set(ByVal Value As String)
            vcTbFolio.Campos("MUsuarioId").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public ReadOnly Property MFechaHora() As Date
        Get
            Return vcTbFolio.Campos("MFechaHora").Valor
        End Get
    End Property

    Public ReadOnly Property Conexion() As LbConexion.cConexion
        Get
            Return vcConexion
        End Get
    End Property

    Friend ReadOnly Property cTabla() As LbDatos.cTabla
        Get
            Return vcTbFolio
        End Get
    End Property

    Public ReadOnly Property cEstado() As eEstado
        Get
            Return vcEstado
        End Get
    End Property

    Public Property Fiscal() As Boolean
        Get
            Return vcTbFolio.Campos("Fiscal").Valor
        End Get
        Set(ByVal Value As Boolean)
            vcTbFolio.Campos("Fiscal").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property SubEmpresaId() As String
        Get
            Return vcTbFolio.Campos("SubEmpresaId").Valor
        End Get
        Set(ByVal Value As String)
            vcTbFolio.Campos("SubEmpresaId").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            ElseIf vcEstado = eEstado.Nuevo Or vcEstado = eEstado.Vacio Then
                FSHFoliosTerminal()
            End If

        End Set
    End Property

#End Region

    Public Sub New()
        vcTbFolio = New LbDatos.cTabla("Folio")
        Tabla = New cFOLTabla(Me)
        'dsDatos = New cFOLDataSet(Me)
        With vcTbFolio
            .AgregarCampo(New LbDatos.cCampo("FolioID", LbDatos.ETipo.Cadena, "", True, True))
            .AgregarCampo(New LbDatos.cCampo("Descripcion", LbDatos.ETipo.Cadena, True))
            .AgregarCampo(New LbDatos.cCampo("ValorInicial", LbDatos.ETipo.Cadena, True))
            .AgregarCampo(New LbDatos.cCampo("TipoEstado", LbDatos.ETipo.Numerico, True))
            .AgregarCampo(New LbDatos.cCampo("ModuloMovDetalleClave", LbDatos.ETipo.Cadena, "", False, False, True, True))
            .AgregarCampo(New LbDatos.cCampo("Fiscal", LbDatos.ETipo.Bit, True))
            .AgregarCampo(New LbDatos.cCampo("SubEmpresaId", LbDatos.ETipo.Cadena, False))
            .AgregarCampo(New LbDatos.cCampo("MUsuarioId", LbDatos.ETipo.Cadena, False))
            .AgregarCampo(New LbDatos.cCampo("MFechaHora", LbDatos.ETipo.MFechaHora, False))
        End With
        Fiscal = False
        SubEmpresaId = Nothing
        vcEstado = eEstado.Vacio
    End Sub

    Public Sub Insertar(ByVal pvFolioID As String, ByVal pvTipo As Integer, ByVal pvModuloMovDetalle As String, ByVal pvDescripcion As String, ByVal pvValorInicial As String, ByVal pvTipoEstado As Integer, ByVal pvMUsuarioId As String)
        Limpiar()
        FolioID = pvFolioID
        ModuloMovDetalleClave = pvModuloMovDetalle
        Descripcion = pvDescripcion
        ValorInicial = pvValorInicial
        TipoEstado = pvTipoEstado

        MUsuarioId = pvMUsuarioId
        Insertar()
    End Sub

    Public Sub ValidarActivos()
        If Me.TipoEstado = 1 Then
            If vcFODArray.Count <= 0 Then
                Throw New LbControlError.cError("E0067", , "Detalle")
            End If
            If Not ExistenDetallesRequeridos() Then
                Throw New LbControlError.cError("E0067", , "Detalle")
            End If

            If Me.Fiscal Then
                'If ModuloMovDetalleClave = "" Then
                '    Throw New LbControlError.cError("E0651", , "ModuloMovDetalleClave")
                'End If
                If Me.vcFOSArrayOriginal.Count <= 0 Then
                    Throw New LbControlError.cError("E0655", , "FolioSolicitado")
                End If
                For Each vlFolioSolicitado As CFolioSolicitado In Me.vcFOSArrayOriginal
                    If vlFolioSolicitado.Estado <> eEstado.Eliminado Then
                        Exit Sub
                    End If
                Next
                Throw New LbControlError.cError("E0655", , "FolioSolicitado")

            End If

        End If
    End Sub

    Public Sub Insertar()
        If Not Existe(Me.FolioID) Then
            If Not ValidarCampos() Then
                Exit Sub
            End If
        Else
            Throw New LbControlError.cError("BE0002", , "FolioID")
        End If
        vcEstado = eEstado.Nuevo
    End Sub

    Public Function ExistenDetallesRequeridos() As Boolean
        Dim i As Integer = 0
        For Each FOD As cFolioDetalle In FODArray()
            If (FOD.TipoContenido = 2 Or FOD.TipoContenido = 3) And FOD.TipoEstado = 1 Then
                i += 1
            End If
        Next

        Return i >= 1
    End Function

    Public Function Existe(ByVal pvFolioID As String) As Boolean
        Dim vlDtFOL As DataTable
        vlDtFOL = vcTbFolio.Seleccionar("FolioID='" & pvFolioID.Replace("'", "''") & "'")
        If vlDtFOL.Rows.Count > 0 Then
            Return True
        End If
        Return False
    End Function

    Public Sub ValidarLongitudFolio(ByVal pvLongitudMax As Integer, Optional ByVal pvFolio As String = "")
        Dim folio As String = pvFolio

        For Each vlFOD As cFolioDetalle In vcFODArray
            If vlFOD.TipoEstado = 1 Then
                folio &= vlFOD.Formato
            End If
        Next
        If folio.Length > pvLongitudMax Then
            Throw New LbControlError.cError("E0723", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("16", False)}, "TipoFormato")
        End If
    End Sub

    Public Function ValidarCampos(Optional ByVal pvCampo As String = Nothing) As Boolean
        Dim i As Integer
        ValidarLongitudFolio(16)

        With vcTbFolio
            If pvCampo Is Nothing Then
                For i = 0 To .Campos.Count - 1
                    ValidarCampo(.Campos(i).Nombre)
                Next
            Else
                ValidarCampo(pvCampo)
            End If
        End With

        For Each vlFolioSolicitado As CFolioSolicitado In vcFOSArrayOriginal
            For i = 0 To vlFolioSolicitado.Tabla.Campos.Count - 1
                vlFolioSolicitado.ValidarCampos(New String() {vlFolioSolicitado.Tabla.Campos(i).Nombre})
            Next
        Next

        For Each vlFSH As CFOSHist In vcFSHArrayOriginal
            For i = 0 To vlFSH.Tabla.Campos.Count - 1
                vlFSH.ValidarCampos(New String() {vlFSH.Tabla.Campos(i).Nombre})
            Next
        Next

        ValidarActivos()

        Return True
    End Function

    Private Sub ValidarCampo(ByVal pvCampo As String)
        Dim vlCampo As LbDatos.cCampo
        With vcTbFolio
            vlCampo = .Campos(pvCampo)
            If vlCampo.Requerido Then
                If vlCampo.Valor Is Nothing Then
                    Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("FOL" + vlCampo.Nombre, True)}, vlCampo.Nombre)
                End If
                If vlCampo.Tipo = LbDatos.ETipo.Cadena Then
                    If vlCampo.Valor = "" Then
                        Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("FOL" + vlCampo.Nombre, True)}, vlCampo.Nombre)
                    End If
                End If
                Select Case vlCampo.Tipo
                    Case LbDatos.ETipo.Numerico
                        If vlCampo.Valor < 0 Then
                            Throw New LbControlError.cError("E0007", , vlCampo.Nombre)
                        End If
                End Select
            End If
        End With
    End Sub

    Public Sub Limpiar()
        Dim i As Integer
        For i = 0 To vcTbFolio.Campos.Count - 1
            vcTbFolio.Campos(i).ADefault()
        Next
        vcFODArray.Clear()
        vcFOSArrayOriginal = New ArrayList
        vcFSHArrayOriginal = New ArrayList
        vcEstado = eEstado.Vacio
        'FSHFoliosTerminal()
    End Sub

    Public Sub Recuperar(ByVal pvFolioID As String)
        Dim vlDtFOL As New DataTable
        Dim vlDrFOL As DataRow

        Call Limpiar()
        vlDtFOL = vcTbFolio.Seleccionar("FolioID='" + pvFolioID.Replace("'", "''") + "'")
        If vlDtFOL.Rows.Count = 0 Then
            Throw New LbControlError.cError("BE0003", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("CFolio", True)})
        End If
        vlDrFOL = vlDtFOL.Rows(0)
        vcTbFolio.Campos("FolioID").Valor = vlDrFOL("FolioID")
        ModuloMovDetalleClave = IIf(IsDBNull(vlDrFOL("ModuloMovDetalleClave")), "", vlDrFOL("ModuloMovDetalleClave"))
        Descripcion = vlDrFOL("Descripcion")
        ValorInicial = vlDrFOL("ValorInicial")
        TipoEstado = vlDrFOL("TipoEstado")
        Fiscal = vlDrFOL("Fiscal")

        If Fiscal Then
            SubEmpresaId = vlDrFOL("SubEmpresaId")
        End If

        MUsuarioId = vlDrFOL("MUsuarioId")
        vcTbFolio.Campos("MFechaHora").Valor = vlDrFOL("MFechaHora")

        FSHFoliosTerminal()

        vcFODArray.Clear()
        For Each vlFODDataRow As DataRow In FODDataTable.Rows
            Dim vlFOD1 As New cFolioDetalle(Me)
            vlFOD1.Recuperar(vlFODDataRow("FolioDetClave"))
            vcFODArray.Add(vlFOD1)
        Next

        vcFOSArrayOriginal = New ArrayList
        For Each vlFOSDataRow As DataRow In recuperarFOSDatatable().Rows
            Dim vlFOS As New CFolioSolicitado
            vlFOS.Recuperar(pvFolioID, vlFOSDataRow("FOSID"), Me.SubEmpresaId)
            vcFOSArrayOriginal.Add(vlFOS)
        Next

        vcFSHArrayOriginal = New ArrayList
        For Each vlFshDataRow As DataRow In recuperarFSHDatatable().Rows
            Dim vlFSH As New CFOSHist
            vlFSH.Recuperar(pvFolioID, vlFshDataRow("FOSID"), vlFshDataRow("FSHFechaInicio"))
            vcFSHArrayOriginal.Add(vlFSH)
        Next

        vcEstado = eEstado.Recuperado
    End Sub

    Public Function Bloquear(ByVal pvMUsuarioId As String) As String
        Dim vlMUsuarioId As String

        vlMUsuarioId = MUsuarioId
        MUsuarioId = pvMUsuarioId
        Try
            Grabar()
        Catch ex As LbControlError.cError
            Throw New LbControlError.cError("BI0001", vlMUsuarioId)
            Exit Function
        End Try
        Return vlMUsuarioId
    End Function

    Public Sub Grabar()
        Try

            Select Case vcEstado
                Case eEstado.Nuevo
                    vcTbFolio.Insertar()

                    For Each vlFolioDetalle As cFolioDetalle In vcFODArray
                        vlFolioDetalle.Grabar()
                    Next

                    For Each vlFolioSolicitado As CFolioSolicitado In vcFOSArrayOriginal
                        vlFolioSolicitado.Grabar()
                    Next

                    For Each vlFH As CFOSHist In vcFSHArrayOriginal
                        vlFH.Grabar()
                    Next

                    vcEstado = eEstado.Recuperado
                Case eEstado.Modificado
                    vcTbFolio.Modificar()

                    For Each vlFolioDetalle As cFolioDetalle In vcFODArray
                        vlFolioDetalle.Grabar()
                    Next

                    For Each vlFOS As CFolioSolicitado In vcFOSArrayOriginal
                        vlFOS.Grabar()
                    Next

                    For Each vlFSH As CFOSHist In vcFSHArrayOriginal
                        If vlFSH.estado = eEstado.Modificado Then
                            Dim vcFSH As New ERMFOLLOG.Amesol.CFOSHist
                            With vcFSH
                                .VendedorID = vlFSH.VendedorID
                                .Vendedor = vlFSH.Vendedor
                                .TerminalClave = vlFSH.TerminalClave
                                .NumCertificado = vlFSH.NumCertificado
                                .CentroExpID = vlFSH.CentroExpID
                                .Inicio = vlFSH.Inicio
                                .Fin = vlFSH.Fin
                                .Descripcion = vlFSH.Descripcion
                                .FolioID = Me.FolioID
                                .FOSId = vlFSH.FOSId
                                .FSHFechaInicio = LbConexion.cConexion.Instancia.ObtenerFecha.AddSeconds(-1)

                            End With
                            vcFSH.Insertar()
                            vcFSH.Grabar()
                        ElseIf vlFSH.estado = eEstado.Nuevo Then
                            vlFSH.FSHFechaInicio = LbConexion.cConexion.Instancia.ObtenerFecha
                            vlFSH.Grabar()
                        End If


                    Next

                    vcEstado = eEstado.Recuperado
                Case eEstado.Recuperado

                    For Each vlFolioDetalle As cFolioDetalle In vcFODArray
                        vlFolioDetalle.Grabar()
                    Next

                    For Each vlFOS As CFolioSolicitado In vcFOSArrayOriginal
                        vlFOS.Grabar()
                    Next

                    For Each vlFSH As CFOSHist In vcFSHArrayOriginal
                        vlFSH.Grabar()
                    Next
            End Select
        Catch ex As LbControlError.cError
            Throw ex
        End Try
    End Sub

    Public Sub Eliminar()
        vcEstado = eEstado.Eliminado
    End Sub

    Public Sub InsertarEn(ByRef prDataTable As DataTable)
        vcTbFolio.Insertar(prDataTable)
    End Sub

    Public Sub ModificarEn(ByRef prDataTable As DataTable)
        vcTbFolio.Modificar(prDataTable)
    End Sub

#Region "FOS"
    Public Function recuperarFOSArray() As ArrayList
        'Dim vlfFOS As New CFolioSolicitado

        'vcFOSArray = New ArrayList
        'Dim vlDT As DataTable = vlfFOS.Tabla.Seleccionar("FolioID='" + Me.FolioID + "' order by serie , anioaprobacion , aprobacion ")
        'For i As Integer = 0 To vlDT.Rows.Count - 1
        '    Dim vlFSHDataRow As DataRow = vlDT.Rows(i)
        '    vlfFOS = New CFolioSolicitado
        '    vlfFOS.Recuperar(Me.FolioID, vlFSHDataRow("FOSID"))
        '    If Not vlfFOS Is Nothing Then
        '        vcFOSArray.Add(vlfFOS)
        '    End If
        'Next

        'For Each vlfFOS In Me.vcFOSArrayOriginal
        '    Select Case vlfFOS.Estado
        '        Case eEstado.Nuevo
        '            vcFOSArray.Add(vlfFOS)

        '        Case eEstado.Eliminado
        '        Case Else
        '            Dim vbInsertar As Boolean = True

        '            For Each vlFSH2 As CFolioSolicitado In Me.vcFOSArray
        '                If vlfFOS.FOSId = vlFSH2.FOSId Then
        '                    vcFOSArray.Add(vlfFOS)
        '                End If
        '            Next
        '    End Select
        'Next

        Dim vlFOSArray As New ArrayList
        For Each vlfFOS As CFolioSolicitado In Me.vcFOSArrayOriginal
            If (vlfFOS.Estado = eEstado.Nuevo Or vlfFOS.Estado = eEstado.Modificado Or vlfFOS.Estado = eEstado.Recuperado) Then
                vlFOSArray.Add(vlfFOS)
            End If
        Next

        Return vlFOSArray
    End Function

    Public Function recuperarFOSDatatable() As DataTable
        Dim fos As New CFolioSolicitado
        If Me.vbHistorico Then
            Return fos.Tabla.Seleccionar("FolioID='" + Me.FolioID.Replace("'", "''") + "'")
        End If

        Return fos.Tabla.Seleccionar("FolioID='" + Me.FolioID.Replace("'", "''") + "' and cantSolicitada > usados order by aprobacion, anioaprobacion, serie ")
    End Function

    Public Sub InsertarFOS(ByVal pvFOS As ERMFOLLOG.Amesol.CFolioSolicitado)
        vcFOSArrayOriginal.Add(pvFOS)
    End Sub

    Public Function FOS(ByVal pvFOSID As String) As CFolioSolicitado
        Dim i As Integer = 0
        If vcFOSArrayOriginal.Count <= 0 Then Return Nothing
        For i = 0 To vcFOSArrayOriginal.Count - 1
            Dim vcfoliosolicitado As CFolioSolicitado
            vcfoliosolicitado = CType(vcFOSArrayOriginal(i), CFolioSolicitado)
            If vcfoliosolicitado.FOSId = pvFOSID Then
                Return vcfoliosolicitado
            End If
        Next
        Return Nothing
    End Function

    Public Function FOSPrimerRegistroSerie(ByVal pvSerie As String) As Boolean
        Dim dt As DataTable = vcConexion.EjecutarConsulta("select count (folioid) from foshist where fosid in (select fosid from foliosolicitado where serie = '" & pvSerie.Replace("'", "''") & "')")
        If dt Is Nothing Or dt.Rows(0).Item(0) <= 0 Then Return True

        Return False
    End Function

    Public Function FOSPrimerRegistroFolio(ByVal pvAnioAprobacion As Integer, ByVal pvSerie As String, ByVal pvNumAprobacion As Integer) As Boolean
        Dim s As String = "select count (folioid) from foshist where fosid = (select fosid from foliosolicitado where serie = '" & pvSerie.Replace("'", "''") & "' and Aprobacion = " & pvNumAprobacion & " and anioAprobacion = " & pvAnioAprobacion & ")"
        Dim dt As DataTable = vcConexion.EjecutarConsulta(s)
        If dt Is Nothing Or dt.Rows(0).Item(0) <= 0 Then Return True

        Return False
    End Function

    Public Function FOSUltimoRegistroAsociado(ByVal pvSerie As String) As Integer
        Dim s As String = "select top 1 fin from foshist where fosid in ( select fosid from foliosolicitado where serie ='" & pvSerie.Replace("'", "''") & "' and folioid ='" & Me.FolioID.Replace("'", "''") & "')"
        Dim dt As DataTable = vcConexion.EjecutarConsulta(s)

        If dt Is Nothing OrElse dt.Rows(0).Item(0) <= 0 Then Return 1
        Return (dt.Rows(0).Item(0) + 1)
    End Function

    Public Function validarRegistroExistente(ByVal pvNumeroAprobacion As Integer, ByVal pvAnioAprobacion As Integer, ByVal pvSerie As String) As Boolean

        For Each vlFSH2 As CFolioSolicitado In Me.vcFOSArrayOriginal
            If pvNumeroAprobacion = vlFSH2.Aprobacion And pvAnioAprobacion = vlFSH2.AnioAprobacion And pvSerie = vlFSH2.Serie And vlFSH2.Estado <> eEstado.Eliminado Then
                Return True
            End If

        Next

        Dim dt As DataTable = vcConexion.EjecutarConsulta("select * from folioSolicitado where Aprobacion =" & pvNumeroAprobacion & " and serie = '" & pvSerie.Replace("'", "''") & "' and anioAprobacion =" & pvAnioAprobacion & " ")
        If dt Is Nothing Or dt.Rows.Count > 0 Then Return True

        Return False
    End Function

    Public Function validarRegistroExistente(ByVal pvNumeroAprobacion As Integer, ByVal pvAnioAprobacion As Integer, ByVal pvSerie As String, ByVal pvFOSId As String) As Boolean

        For Each vlFSH2 As CFolioSolicitado In Me.vcFOSArrayOriginal
            If pvNumeroAprobacion = vlFSH2.Aprobacion And pvAnioAprobacion = vlFSH2.AnioAprobacion And pvSerie = vlFSH2.Serie And pvFOSId <> vlFSH2.FOSId And vlFSH2.Estado <> eEstado.Eliminado Then
                Return True
            End If

        Next

        Dim dt As DataTable = vcConexion.EjecutarConsulta("select * from folioSolicitado where Aprobacion =" & pvNumeroAprobacion & " and serie = '" & pvSerie.Replace("'", "''") & "' and anioAprobacion =" & pvAnioAprobacion)
        If dt Is Nothing Or dt.Rows.Count > 0 Then Return True

        Return False
    End Function

    Public Function SerieEnOtroFolio(ByVal pvSerie As String) As Boolean
        Dim vlConsulta As String = "select count(*) as serie from folio inner join foliosolicitado on folio.folioid = foliosolicitado.folioid " & _
        "where folio.folioid <> '" & Me.FolioID.Replace("'", "''") & "' and foliosolicitado.serie ='" & pvSerie.Replace("'", "''") & "' "
        Dim dt As DataTable = vcConexion.EjecutarConsulta(vlConsulta)
        If dt.Rows(0).Item(0) > 0 Then Return True

        Return False
    End Function

#End Region

#Region "FSH"
    Public Function recuperarFSHArrayHistorico(ByVal pvFOSID As String) As ArrayList
        Dim vlFSHA As New ArrayList

        For Each vlFshDataRow As DataRow In Me.recuperrarFSHDatatableHistorico(pvFOSID).Rows
            Dim vlFSH As New CFOSHist
            vlFSH.Recuperar(Me.FolioID, vlFshDataRow("FOSID"), vlFshDataRow("FSHFechaInicio"))

            vlFSHA.Add(vlFSH)
        Next
        Return vlFSHA
    End Function

    Public Function recuperarFSHArray(ByVal pvFOSId As String) As ArrayList
        Dim vlFSHArray As New ArrayList
        For Each vlfsh As CFOSHist In Me.vcFSHArrayOriginal
            If vlfsh.FOSId = pvFOSId And (vlfsh.estado = eEstado.Nuevo Or vlfsh.estado = eEstado.Modificado Or vlfsh.estado = eEstado.Recuperado) Then
                vlFSHArray.Add(vlfsh)
            End If
        Next

        Return vlFSHArray
    End Function

    Public Function recuperarFSHDatatable() As DataTable
        Dim vlConsulta As String = "select folioid, fosid, max(fshfechainicio) as FSHFechaInicio from foshist where folioid='" & Me.FolioID.Replace("'", "''") & "' group by folioid, fosid "

        Dim dt As DataTable = vcConexion.EjecutarConsulta(vlConsulta)
        Return dt

    End Function

    Public Function recuperrarFSHDatatableHistorico(ByVal pvFOSId As String) As DataTable
        Dim FSH As New CFOSHist
        Return FSH.Tabla.Seleccionar("FolioID='" & FolioID.Replace("'", "''") & "' and fosid ='" & pvFOSId.Replace("'", "''") & "' order by Inicio ")
    End Function

    Public Sub InsertarFSH(ByVal pvFOS As CFOSHist)
        vcFSHArrayOriginal.Add(pvFOS)
    End Sub

    Public Function FSH(ByVal pvFOSID As String, ByVal pvFechaCreacion As DateTime) As CFOSHist
        Dim i As Integer = 0
        If vcFSHArrayOriginal.Count <= 0 Then Return Nothing
        For i = 0 To vcFSHArrayOriginal.Count - 1
            Dim vcFSH As CFOSHist
            vcFSH = CType(vcFSHArrayOriginal(i), CFOSHist)
            If vcFSH.FOSId = pvFOSID And vcFSH.FSHFechaInicio = pvFechaCreacion Then
                Return vcFSH
            End If
        Next
        Return Nothing
    End Function

    Public Sub FSHFinEliminando(ByVal pvFOSID As String, ByVal pvFechaCreacion As DateTime, ByVal pvFin As Integer)
        Dim i As Integer = 0
        If vcFSHArrayOriginal.Count <= 0 Then Exit Sub
        For i = 0 To vcFSHArrayOriginal.Count - 1
            Dim vcFSH As CFOSHist
            vcFSH = CType(vcFSHArrayOriginal(i), CFOSHist)
            If vcFSH.FOSId = pvFOSID And vcFSH.FSHFechaInicio <> pvFechaCreacion Then
                vcFSH.Fin = pvFin
                Exit Sub
            End If
        Next

    End Sub

    Public Sub FSHValidarCertificado(ByVal pvCertificado As String)

        'Dim consulta As String = "select numCertificado from CertificadoFolio Where numCertificado = '" & pvCertificado & "' and  getdate() between FechaInicial and fechafinal "
        ''Dim dt As DataTable = vcConexion.EjecutarConsulta(consulta)
        ''If dt Is Nothing Or dt.Rows.Count <= 0 Then

        ''End If



        If pvCertificado Is Nothing Or IsDBNull(pvCertificado) Then 'Or vcFolio.FSHCertificadoVigente(pvValor) = False Then
            Throw New LbControlError.cError("E0647", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("FSH" & "Certificado", True)}, "Certificado")
        End If
        Dim dt As DataTable = vcConexion.EjecutarConsulta("select Top 1 FechaFinal from CertificadoFolio Where numCertificado = '" & pvCertificado.Replace("'", "''") & "' and " & LbConexion.cConexion.Instancia.UniFechaSQL(LbConexion.cConexion.Instancia.ObtenerFecha.Date) & " between FechaInicial and fechafinal")
        If dt Is Nothing Or dt.Rows.Count <= 0 Then
            Throw New LbControlError.cError("E0647", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("FSH" & "Certificado", True)}, "Certificado")
        End If

        Dim vlVencimiento As Integer = CType(dt.Rows(0).Item(0), Date).Subtract(Date.Today).Days
        If FSHNumCertCentroExp(pvCertificado).Rows.Count = 0 Then
            Throw New LbControlError.cError("E0674", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(vlVencimiento, False)}, "Certificado")
        End If





        'Dim vlVencimiento As Integer = vcFolio.FSHCertificadoVencimiento(pvCertificado)

        'If vcFolio.FSHNumCertCentroExp(pvValor).Rows.Count = 0 Then
        '    Throw New LbControlError.cError("E0674", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(vlVencimiento, False)}, pvColumna)
        'End If

        'If pvValor Is Nothing Or IsDBNull(pvValor) Or vcFolio.FSHCertificadoVigente(pvValor) = False Then
        '    Throw New LbControlError.cError("E0647", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("FSH" & pvColumna, True)}, pvColumna)
        'End If
        'Dim vlVencimiento As Integer = vcFolio.FSHCertificadoVencimiento(pvValor)
        'If vcFolio.FSHNumCertCentroExp(pvValor).Rows.Count = 0 Then
        '    Throw New LbControlError.cError("E0674", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(vlVencimiento, False)}, pvColumna)
        'End If


    End Sub

    'Public Function FSHCertificadoVigente(ByVal pvCertificado As String) As Boolean
    '    Dim consulta As String = "select numCertificado from CertificadoFolio Where numCertificado = '" & pvCertificado & "' and  getdate() between FechaInicial and fechafinal "
    '    Dim dt As DataTable = vcConexion.EjecutarConsulta(consulta)
    '    If dt Is Nothing Or dt.Rows.Count <= 0 Then
    '        Return False
    '    End If

    '    Return True
    'End Function

    Public Function FSHCertificadoVencimiento(ByVal pvCertificado As String) As Integer
        Dim dt As DataTable = vcConexion.EjecutarConsulta("select Top 1 FechaFinal from CertificadoFolio Where numCertificado = '" & pvCertificado.Replace("'", "''") & "' ")

        If Not dt Is Nothing AndAlso dt.Rows.Count >= 1 Then
            Return CType(dt.Rows(0).Item(0), Date).Subtract(Date.Today).Days
        End If

        Return 0
    End Function
    Public Function FSHNumCertCentroExp(ByVal pvCertificado As String) As DataTable
        Dim dt As DataTable = vcConexion.EjecutarConsulta("select centroExpid,NumCertificado, Nombre, tipo from centroexpedicion Where numCertificado = '" & pvCertificado.Replace("'", "''") & "' and tipoestado =1 ")
        dt.TableName = "centroexpedicion"
        Return dt
    End Function

    Public Function FSHVendedor(ByVal pvCondicion As String) As DataTable   'True habilita Terminal False habilita Vendedor
        Dim sCondicion As String = ""
        If pvCondicion <> "" Then sCondicion = "where " & pvCondicion

        Return vcConexion.EjecutarConsulta("Select * from vendedor " & sCondicion)
    End Function

    Public Function FSHTerminal(ByVal pvCondicion As String) As DataTable
        Dim sCondicion As String = ""
        If pvCondicion <> "" Then sCondicion = "where " & pvCondicion

        Return vcConexion.EjecutarConsulta("Select * from Terminal " & sCondicion)
    End Function

    Public Function FSHTerminalVigente(ByVal pvTerminalClave As String) As Boolean
        Dim dt As DataTable = Nothing

        Try
            dt = vcConexion.EjecutarConsulta("Select * from Terminal where TipoFase <> 2 and tipoFase <> 0 and TerminalClave = '" & pvTerminalClave.Replace("'", "''") & "'")
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try

        If dt Is Nothing OrElse dt.Rows.Count = 0 Then
            Return False
        End If

        Return True
    End Function

    Public Function FSHFinalDeSerie(ByVal pvSerie As String) As Integer
        Dim dt As DataTable = vcConexion.EjecutarConsulta("select Top 1 Fin from FOSHist where Folioid = '" & Me.FolioID.Replace("'", "''") & "' and fosid in (select fosid from foliosolicitado where serie = '" & pvSerie.Replace("'", "''") & "') order by FSHFechaInicio desc ")

        If dt Is Nothing Or dt.Rows.Count <= 0 Then
            Return 0
        End If
        Return dt.Rows(0).Item("Fin")
    End Function

    Public Function FSHMaxDeSerie(ByVal pvSerie As String) As Integer
        Dim dt As DataTable = vcConexion.EjecutarConsulta("select isnull(Max(Fin),0) as Fin from FOSHist where Folioid = '" & Me.FolioID.Replace("'", "''") & "' and fosid in (select fosid from foliosolicitado where serie = '" & pvSerie.Replace("'", "''") & "') ")

        If dt Is Nothing Or dt.Rows.Count <= 0 Then
            Return 0
        End If
        Return dt.Rows(0).Item("Fin") + 1
    End Function

    Public Function FSHCampoDeSerie(ByVal pvCampo As String, ByVal pvSerie As String) As String
        Dim dt As DataTable = vcConexion.EjecutarConsulta("select top 1 " & pvCampo & " from foshist where fosid in (select fosid from foliosolicitado where serie = '" & pvSerie.Replace("'", "''") & "' and cantsolicitada > usados) order by fshfechainicio desc ")

        If dt Is Nothing Or dt.Rows.Count <= 0 Then
            Return ""
        End If

        Return dt.Rows(0).Item(0).ToString
    End Function

    'Public Function FSHCampoDeSerie(ByVal pvCampo As String, ByVal pvSerie As String, ByVal pvCampoId As String) As Boolean
    '    Dim vlConsulta As String = "select top 1 " & pvCampo & " from foshist where fosid in (select fosid from foliosolicitado where serie = '" & pvSerie & "' and cantsolicitada > usados) and '" & pvCampo & "' = '" & pvCampoId & "' "
    '    Dim dt As DataTable = vcConexion.EjecutarConsulta(vlConsulta)

    '    If dt Is Nothing Or dt.Rows.Count <= 0 Then
    '        Return False
    '    End If

    '    Return True
    'End Function

    Public Function FSHVendedorEnSerie(ByVal pvFOSid As String, ByVal pvSerie As String, ByVal pvVendedorId As String, ByVal pvFSHFechaInicio As DateTime) As Boolean
        Dim vlConsulta As String

        vlConsulta = "select count(*) from(select f.folioid, f.fosid, max(h.fshfechainicio) as FSHFechaInicio from foliosolicitado F  " & _
        "inner join foshist h on f.folioid = h.folioid and f.fosid = h.fosid " & _
        "inner join vendedor v on h.vendedorid = h.vendedorid " & _
        "where f.serie='" & pvSerie.Replace("'", "''") & "' " & _
        "and v.tipoEstado=1 and v.baja = 0  and f.Usados < f.CantSolicitada group by f.folioid, f.fosid)t " & _
        "inner join foshist h on t.folioid = h.folioid and t.fosid = h.fosid and t.FSHFechaInicio = h.FSHFechaInicio " & _
        "where convert(datetime,convert(varchar(20), h.fshfechainicio, 120),102) <> " & vcConexion.UniFechaSQL(pvFSHFechaInicio) & "  and h.vendedorid = '" & pvVendedorId.Replace("'", "''") & "' "

        Dim dt As DataTable = vcConexion.EjecutarConsulta(vlConsulta)

        If dt.Rows(0).Item(0) < 1 Then
            Return False
        End If

        Return True
    End Function

    Public Function FSHTerminalEnSerie(ByVal pvFosid As String, ByVal pvSerie As String, ByVal pvTerminalClave As String, ByVal pvFSHFechaInicio As DateTime) As Boolean
        Dim vlConsulta As String
        vlConsulta = "select count(*) from(select f.folioid, f.fosid, max(h.fshfechainicio) as FSHFechaInicio from foliosolicitado F  " & _
        "inner join foshist h on f.folioid = h.folioid and f.fosid = h.fosid " & _
        "inner join terminal t on  t.terminalclave=h.terminalclave " & _
        "where f.serie='" & pvSerie & "' " & _
        "and t.tipofase <> 0 group by f.folioid, f.fosid)t " & _
        "inner join foshist h on t.folioid = h.folioid and t.fosid = h.fosid and t.FSHFechaInicio = h.FSHFechaInicio " & _
        "where convert(datetime,convert(varchar(20), h.fshfechainicio, 120),102) <> " & vcConexion.UniFechaSQL(pvFSHFechaInicio) & " and h.TerminalClave = '" & pvTerminalClave.Replace("'", "''") & "' "
        Dim dt As DataTable = vcConexion.EjecutarConsulta(vlConsulta)

        If dt.Rows(0).Item(0) < 1 Then
            Return False
        End If

        Return True
    End Function

    Public Function FSHPrimerRegistroSerie(ByVal pvSerie As String) As Boolean
        Dim vlDt As DataTable = vcConexion.EjecutarConsulta("select count(*) from foliosolicitado inner join foshist on foliosolicitado.fosid = foshist.fosid where serie='" & pvSerie.Replace("'", "''") & "' and usados <> 0")

        If vlDt.Rows(0).Item(0) = 0 Then Return True

        Return False
    End Function

    Public Function FSHInicioPrimerRegistroSerie(ByVal pvSerie As String, ByVal pvAnioAprobacion As Integer, ByVal pvNumAprobacion As Integer) As Integer
        Dim vlDt As DataTable = vcConexion.EjecutarConsulta("select top 1 inicio from foshist where fosid in (select fosid from foliosolicitado where serie='" & pvSerie.Replace("'", "''") & "' and anioaprobacion =" & pvAnioAprobacion & " and aprobacion = " & pvNumAprobacion & ") order by fshfechainicio")

        If vlDt Is Nothing Then Return 0
        If vlDt.Rows.Count <= 0 Then Return 0
        Return vlDt.Rows(0).Item(0)

    End Function

#End Region

#Region "FOD"
    Private Function RecuperarFODDataTable() As DataTable
        Dim vcFOD As New cFolioDetalle(Me)
        Dim vlDt As DataTable = vcFOD.Tabla.RecuperarTabla("FolioID='" & Me.FolioID & "'")
        Return vlDt
    End Function

    Public Sub InsertarFOD(ByVal pvFolioDetClave As String, ByVal pvTipoContenido As Integer, ByVal pvFormato As String, ByVal pvTipoEstado As Integer)
        'If Me.CUOClave <> "" Then
        Dim vlFOD As New cFolioDetalle(Me)
        'Si existe en la BD
        If Not vlFOD.Existe(pvFolioDetClave) Then
            'Si existe en el Arreglo
            If FOD(pvFolioDetClave) Is Nothing Then
                vlFOD.Insertar(pvFolioDetClave, pvTipoContenido, pvFormato, pvTipoEstado, Me.MUsuarioId)
                vcFODArray.Add(vlFOD)
            Else
                Throw New LbControlError.cError("BE0002", , "FolioDetClave")
            End If
        Else
            Throw New LbControlError.cError("BE0002", , "FolioDetClave")
        End If
        'Else
        'Marcar Error de que el producto no existe
        'Throw New LbControlError.cError("BE0002", , "EsquemaId")
        'Return False
        'End If
    End Sub

    Public Function EliminarFOD(ByVal pvFolioDetClave As String) As Boolean
        Try
            If Not FOD(pvFolioDetClave) Is Nothing Then
                If FOD(pvFolioDetClave).Estado = eEstado.Nuevo Then
                    vcFODArray.Remove(FOD(pvFolioDetClave))
                End If
            End If
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Function FODArray() As ArrayList
        Return vcFODArray
    End Function

    Public Function FODDataTable() As DataTable
        Return RecuperarFODDataTable()
    End Function

    Public Function FOD(ByVal pvFolioDetClave As String) As cFolioDetalle
        Dim i As Integer = 0
        If vcFODArray.Count <= 0 Then Return Nothing
        For i = 0 To vcFODArray.Count - 1
            Dim vcFolioDetalle As cFolioDetalle
            vcFolioDetalle = CType(vcFODArray(i), cFolioDetalle)
            If vcFolioDetalle.FolioDetClave = pvFolioDetClave Then
                Return vcFolioDetalle
            End If
        Next
        Return Nothing
    End Function

#End Region

    Public Function ExisteRelacion() As Boolean
        Dim FOU As New ERMFOULOG.cFolioUsuario
        Dim dt As DataTable = FOU.Tabla.Recuperar("FolioID='" & Me.FolioID.Replace("'", "''") & "'")
        If Not dt Is Nothing Then
            If dt.Rows.Count > 0 Then
                Return True
            End If
        End If
        Return False
    End Function

    Private Sub FSHFoliosTerminal() 'True habilita Terminal False habilita Vendedor

        If Me.Fiscal Then


            Dim consulta As String = "select Top 1 FoliosTerminal, ComprobanteDig from SemHist where Subempresaid='" + Me.SubEmpresaId + "' order by semhistfechainicio desc "
            Dim dt As DataTable = vcConexion.EjecutarConsulta(consulta)
            If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                bFoliosTerminal = False
                bComprobanteDig = False
            Else
                bFoliosTerminal = dt.Rows(0).Item("FoliosTerminal")
                bComprobanteDig = dt.Rows(0).Item("ComprobanteDig")
            End If
        Else
            bFoliosTerminal = False
            bComprobanteDig = False
        End If

    End Sub

    Public ReadOnly Property FSHFolioTerminal() As Boolean
        Get
            Return bFoliosTerminal
        End Get
    End Property

    Public Function ComprobanteDig() As Boolean
        Return bComprobanteDig
    End Function

    Public Function ObtenerFolioFiscal(ByVal pvTerminalClave As String, ByVal pvVendedorId As String, ByVal SubEmpresaID As String, ByVal pvTipoComprobante As Short) As DataTable
        Dim strSQL As StringBuilder
        Dim dtTabla As DataTable
        Dim oSubEmpresa As New ERMSEMLOG.cSubEmpresa
        Dim dtFolioDetalle As DataTable
        Dim dtFolioFiscal As New DataTable("FolioFiscal")
        Dim sFolio As String

        'validar vigencia del certificado y asignacion de folios
        strSQL = New StringBuilder
        strSQL.AppendLine("select top 1 FechaFinal from FOSHist FSH inner join CertificadoFolio CEF on CEF.NumCertificado = FSH.NumCertificado")
        oSubEmpresa.Recuperar(SubEmpresaID)
        If oSubEmpresa.FoliosTerminal Then
            strSQL.Append("where FSH.TerminalClave='" & pvTerminalClave.Replace("'", "''") & "' ")
        Else
            strSQL.Append("where FSH.VendedorId='" & pvVendedorId.Replace("'", "''") & "' ")
        End If
        strSQL.AppendLine("order by FSH.FSHFechaInicio desc")
        dtTabla = vcConexion.EjecutarConsulta(strSQL.ToString)

        If dtTabla.Rows.Count = 0 Then
            'no hay folios asignados
            Throw New LbControlError.cError("E0659")
        Else
            'validar fecha de vigencia e0647
            If Not CType(dtTabla.Rows(0)("FechaFinal"), Date) >= LbConexion.cConexion.Instancia.ObtenerFecha() Then
                Throw New LbControlError.cError("E0647")
            End If
        End If

        strSQL = New StringBuilder
        strSQL.Append("select FOL.FolioId, FOS.FOSId, FOS.Serie, FOS.Aprobacion, FOS.AnioAprobacion, FOS.Usados, ")
        strSQL.Append("(SELECT MIN(Inicio) FROM FOSHist FSH3 WHERE FSH3.FolioId=FSH.FolioId and FSH3.FOSId=FSH.FOSID) as Inicio, ")
        strSQL.Append("FSH.NumCertificado, FSH.CentroExpID, FSH.Fin ")
        strSQL.Append("from Folio FOL ")
        strSQL.Append("inner join FolioSolicitado FOS ON FOS.FolioId=FOL.FolioId and FOS.CantSolicitada>FOS.Usados ")
        strSQL.Append("inner join ( ")
        strSQL.Append("select FolioId, Serie, min(FechaCreacion) as FechaCreacion from FolioSolicitado ")
        strSQL.Append("where CantSolicitada > Usados group by FolioId, Serie")
        strSQL.Append(") FOS1 ON FOS1.FolioId=FOS.FolioId and FOS1.Serie=FOS.Serie and FOS1.FechaCreacion=FOS.FechaCreacion ")
        strSQL.Append("inner join FOSHist FSH ON FSH.FolioId=FOS.FolioID and FSH.FOSId=FOS.FOSId ")
        strSQL.Append("inner join (select FolioId, FOSId,CentroExpID,NUMCERTIFICADO, max(FSHFechaInicio) as FSHFechaInicio from FOSHist   ")
        strSQL.Append("group by FolioId, FOSId,NUMCERTIFICADO,CentroExpID) FSH2 ON FSH2.FolioId=FSH.FolioId and FSH2.FOSId=FSH.FOSID and FSH2.FSHFechaInicio=FSH.FSHFechaInicio   ")
        strSQL.Append("inner join centroexpedicion CEN on CEN.CentroExpID=FSH2.CentroExpID and FSH2.NUMCERTIFICADO=CEN.NUMCERTIFICADO and CEN.TipoESTADO=1 ")
        strSQL.Append("inner join CertificadoFolio CEF on CEF.NumCertificado = FSH2.NumCertificado AND CEF.FechaFinal >=   CONVERT(DATETIME,CONVERT(VARCHAR,GETDATE(),112),112) ")
        strSQL.Append("where FOL.TipoEstado = 1 And FOL.Fiscal = 1 ")
        strSQL.Append("AND FSH.Fin>=(FOS.Usados + (SELECT MIN(Inicio) FROM FOSHist FSH3 WHERE FSH3.FolioId=FSH.FolioId and FSH3.FOSId=FSH.FOSID AND Fol.SubEmpresaId='" + SubEmpresaID + "')) ")
        strSQL.Append("and FOS.TipoComprobante = " & pvTipoComprobante & " ")

        oSubEmpresa.Recuperar(SubEmpresaID)
        If oSubEmpresa.FoliosTerminal Then
            strSQL.Append("and FSH.TerminalClave='" & pvTerminalClave.Replace("'", "''") & "' ")
        Else
            strSQL.Append("and FSH.VendedorId='" & pvVendedorId.Replace("'", "''") & "' ")
        End If
        strSQL.Append("order by FOS.Serie ")

        dtTabla = vcConexion.EjecutarConsulta(strSQL.ToString)

        If dtTabla.Rows.Count = 0 Then
            Throw New LbControlError.cError("E0659")
        End If

        dtFolioFiscal.Columns.Add("FolioId", GetType(String))
        dtFolioFiscal.Columns.Add("FOSId", GetType(String))
        dtFolioFiscal.Columns.Add("FolioIdFOSId", GetType(String))
        dtFolioFiscal.Columns.Add("Folio", GetType(String))
        dtFolioFiscal.Columns.Add("NumCertificado", GetType(String))
        dtFolioFiscal.Columns.Add("Serie", GetType(String))
        dtFolioFiscal.Columns.Add("Aprobacion", GetType(Integer))
        dtFolioFiscal.Columns.Add("AnioAprobacion", GetType(Integer))
        dtFolioFiscal.Columns.Add("CentroExpID", GetType(String))

        For Each lrRow As DataRow In dtTabla.Rows
            dtFolioDetalle = vcConexion.EjecutarConsulta("select * from FolioDetalle FOD where FOD.FolioId='" & lrRow!FolioId.Replace("'", "''") & "' and FOD.TipoEstado=1 order by FOD.TipoContenido")

            Dim drFolio As DataRow = dtFolioFiscal.NewRow
            drFolio!FolioId = lrRow!FolioId
            drFolio!FOSId = lrRow!FOSId
            drFolio!FolioIdFOSId = lrRow!FolioId & lrRow!FOSId
            sFolio = Format(lrRow!Usados + lrRow!Inicio, dtFolioDetalle.Rows(0)!Formato)
            sFolio = lrRow!Serie & sFolio
            drFolio!Folio = sFolio
            drFolio!NumCertificado = lrRow!NumCertificado
            drFolio!Serie = lrRow!Serie
            drFolio!Aprobacion = lrRow!Aprobacion
            drFolio!AnioAprobacion = lrRow!AnioAprobacion
            drFolio!CentroExpID = lrRow!CentroExpID
            dtFolioFiscal.Rows.Add(drFolio)
        Next

        Return dtFolioFiscal
    End Function

    Public Shared Function ObtenerFolioEscritorio(ByVal pvFolioID As String, ByVal pvVendedorID As String) As String
        Dim sFolio As String = ""

        Dim DataTableFolioRes As New DataTable()
        If ObtenerPropiedadesFolio(DataTableFolioRes, True, pvFolioID, pvVendedorID) Then
            Dim refDataRow As DataRow = DataTableFolioRes.Rows(0)
            Dim sFolioId As String = refDataRow("FolioId").ToString()
            Dim iInicio As Integer = Convert.ToInt32(refDataRow("Inicio"))
            Dim iFin As Integer = Convert.ToInt32(refDataRow("Fin"))
            Dim iUsados As Integer = Convert.ToInt32(refDataRow("Usados"))

            Dim DataTableFoliosDet As DataTable = LbConexion.cConexion.Instancia().EjecutarConsulta("SELECT TipoContenido,Formato FROM FolioDetalle WHERE FolioId='" & sFolioId & "' ORDER BY FolioDetClave")
            If DataTableFoliosDet.Rows.Count = 0 Then
                DataTableFoliosDet.Dispose()
                Throw New LbControlError.cError("E0207", "", LbConexion.cConexion.Instancia())
            End If
            ' Conformar el nuevo folio
            For Each row As DataRow In DataTableFoliosDet.Rows
                Dim iConsecutivo As Integer = 1
                Dim eTipoContenido As Integer = -1
                Dim sContenido As String = Nothing

                iConsecutivo = iInicio + iUsados

                eTipoContenido = Convert.ToInt16(row("TipoContenido"))
                sContenido = row("Formato").ToString()
                Select Case eTipoContenido
                    Case 1
                        'Rótulo Fijo
                        sFolio += sContenido
                        Exit Select
                    Case 2
                        'Autoincremental Numérico
                        sFolio += iConsecutivo.ToString(sContenido)
                        ' Strings.Format(iConsecutivo, sContenido);
                        Exit Select
                End Select
            Next
            DataTableFoliosDet.Dispose()
            If String.IsNullOrEmpty(sFolio) Then
                ' Usar un folio provisional
                Dim oMensaje As New BASMENLOG.CMensaje()
                System.Windows.Forms.MessageBox.Show(oMensaje.RecuperarDescripcion("E0770", New String(-1) {}))
                sFolio = System.DateTime.Now.ToString("hhmmss")
            End If
        End If
        DataTableFolioRes.Dispose()

        Return sFolio
    End Function

    Public Shared Function ObtenerFolioID(ByVal pvACTId As String) As String
        Dim cmd As String = "Select FolioID from Interfaz where ACTId = '" + pvACTId + "' "

        Dim dtFolio As DataTable = LbConexion.cConexion.Instancia().EjecutarConsulta(cmd)
        If dtFolio.Rows.Count <= 0 Then
            dtFolio.Dispose()
            Throw New LbControlError.cError("E0771", "", LbConexion.cConexion.Instancia())
        End If

        Return dtFolio.Rows(0).Item(0).ToString()
    End Function

    Public Shared Function ObtenerFolioID(ByVal pvModuloMovDetalleTipoIndice As Integer, ByVal pvVendedorID As String) As String
        Dim cmd As String = "select distinct Folio.FolioID " & _
        "FROM FolioReservacion FR " & _
        "inner join Folio on Folio.FolioID = fr.FolioID " & _
        "inner join ModuloMovDetalle MMD on MMD.ModuloMovDetalleClave = Folio.ModuloMovDetalleClave " & _
        "where VendedorID ='" + pvVendedorID + "' and Folio.ModuloMovDetalleClave in(select ModuloMovDetalleClave from ModuloMovDetalle where TipoIndice = '" + pvModuloMovDetalleTipoIndice.ToString() + "')"

        Dim dtFolio As DataTable = LbConexion.cConexion.Instancia().EjecutarConsulta(cmd)
        If dtFolio.Rows.Count <= 0 Then
            dtFolio.Dispose()
            Throw New LbControlError.cError("E0208", "", LbConexion.cConexion.Instancia())
        End If

        Return dtFolio.Rows(0).Item(0).ToString()
    End Function

    Private Shared Function ObtenerPropiedadesFolio(ByRef refDataTable As DataTable, ByVal parbMostrarMensajeError As Boolean, ByVal pvFolioID As String, ByVal pvVendedorID As String) As Boolean
        Dim sConsultaSQL As String = "SELECT Folio.FolioId, FolioReservacion.Inicio, FolioReservacion.Fin, FolioReservacion.Usados FROM FolioReservacion "
        sConsultaSQL += "INNER JOIN Folio ON FolioReservacion.FolioID = Folio.FolioID "
        sConsultaSQL += "WHERE Folio.FolioID = '" & pvFolioID & "' and FolioReservacion.VendedorID='" & pvVendedorID & "'"
        sConsultaSQL += "AND Usados < ((Fin - Inicio) + 1) "
        sConsultaSQL += "ORDER BY Inicio "
        refDataTable = LbConexion.cConexion.Instancia().EjecutarConsulta(sConsultaSQL)

        If refDataTable.Rows.Count = 0 Then
            Throw New LbControlError.cError("E0208", "", LbConexion.cConexion.Instancia())
        End If
        Return True
    End Function

    Public Shared Sub Confirmar(ByVal pvFolioID As String, ByVal pvMUsuarioID As String, ByVal pvVendedorId As String)
        Try
            Dim DataTableFolioRes As DataTable
            DataTableFolioRes = New DataTable()
            If ObtenerPropiedadesFolio(DataTableFolioRes, False, pvFolioID, pvVendedorId) Then
                ' Considerar solo el primer registro del folio
                Dim refDataRow As DataRow = DataTableFolioRes.Rows(0)
                ' Indicar que se ha obtenido el folio, reducir el número de disponibles
                Dim iUsados As Integer = refDataRow("Usados")
                Dim dtRangos As DataTable = LbConexion.cConexion.Instancia().EjecutarConsulta("SELECT RangoId FROM FolioReservacion WHERE FolioId='" & refDataRow("FolioId") & "' and VendedorID ='" & pvVendedorId & "' AND TipoEstado=1 AND Usados < ((Fin - Inicio) + 1) ORDER BY Inicio", False)
                Dim sRangoId As String = dtRangos.Rows(0)("RangoId")
                iUsados += 1
                Dim sConsultaSQL As String = "UPDATE FolioReservacion SET Usados=" & iUsados & " "
                If refDataRow("Fin") - refDataRow("Inicio") + 1 = iUsados Then
                    sConsultaSQL &= ",TipoEstado= 0 "
                End If
                sConsultaSQL &= ",MFechaHora=" & LbConexion.cConexion.Instancia().UniFechaSQL(Now) & ",MUsuarioID='" & pvMUsuarioID & "' WHERE FolioId='" & refDataRow("FolioId") & "' and VendedorID ='" & pvVendedorId & "' AND RangoId='" & sRangoId & "'"
                LbConexion.cConexion.Instancia().EjecutarComando(sConsultaSQL)
            End If
            DataTableFolioRes.Dispose()
        Catch ExcB As Exception
            MsgBox(ExcB.Message, MsgBoxStyle.Critical, "ConfirmarFolio")
        End Try
    End Sub

End Class

Public Class cFOLTabla
    Private vcFolio As cFolio

    Public Sub New(ByRef prFolio As cFolio)
        vcFolio = prFolio
    End Sub

    Public Function Recuperar(Optional ByVal pvFiltro As String = "", Optional ByVal pvCampos As String = "*") As DataTable
        Dim vlFOLDataTable As New DataTable
        vlFOLDataTable = vcFolio.cTabla.Seleccionar(pvFiltro, pvCampos)
        Return vlFOLDataTable
    End Function

    Public Sub Grabar(ByRef prDataTable As DataTable)
        vcFolio.cTabla.GrabarTabla(prDataTable, vcFolio.cTabla.Campos)
    End Sub
End Class

'Public Class cCUODataSet
'    Private vcCuota As cCuota

'    Public Sub New(ByRef prCuota As cCuota)
'        vcCuota = prCuota
'    End Sub

'    Public Function Recuperar(Optional ByVal pvFiltro As String = "", Optional ByVal pvCampos As String = "*") As DataSet
'        Dim vlCUODataSet As New DataSet
'        Dim vlCUODataTable As New DataTable

'        Dim vlFiltro As String

'        vlCUODataTable = vcCuota.Tabla.Recuperar(pvFiltro)
'        vlCUODataSet.Tables.Add(vlCUODataTable)

'        If vlCUODataTable.Rows.Count <= 0 Then
'            Return vlCUODataSet
'        End If

'        vlFiltro = "CUOClave in ("
'        For Each vlCUODataRow As DataRow In vlCUODataTable.Rows
'            vlFiltro = vlFiltro + "'" + vlCUODataRow("CUOClave") + "',"
'        Next
'        vlFiltro = vlFiltro.Substring(0, vlFiltro.Length - 1) + ")"

'        Return vlCUODataSet

'    End Function

'End Class

Public Enum eEstado
    Vacio = 0
    Nuevo
    Modificado
    Recuperado
    Eliminado
End Enum