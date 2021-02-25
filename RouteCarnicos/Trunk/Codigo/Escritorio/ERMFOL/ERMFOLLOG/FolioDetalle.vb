Imports LbDatos
Public Class cFolioDetalle

    Private vcFolio As cFolio
    Private vcTbFolioDetalle As LbDatos.cTabla
    Public Tabla As cFODTabla
    Private vcConexion As LbConexion.cConexion = LbConexion.cConexion.Instancia
    Private vcEstado As eEstado

#Region "Propiedades"
    Friend ReadOnly Property FolioID() As String
        Get
            Return vcFolio.FolioID
        End Get
    End Property

    Public Property FolioDetClave() As String
        Get
            Return vcTbFolioDetalle.Campos("FolioDetClave").Valor
        End Get
        Set(ByVal Value As String)
            If vcEstado = eEstado.Vacio Or vcEstado = eEstado.Nuevo Then
                vcTbFolioDetalle.Campos("FolioDetClave").Valor = Value
            End If
        End Set
    End Property

    Public Property TipoContenido() As Integer
        Get
            Return vcTbFolioDetalle.Campos("TipoContenido").Valor
        End Get
        Set(ByVal Value As Integer)
            If (vcEstado <> eEstado.Vacio And vcEstado <> eEstado.Nuevo) Then ValidarRelacion()
            vcTbFolioDetalle.Campos("TipoContenido").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property Formato() As String
        Get
            Return vcTbFolioDetalle.Campos("Formato").Valor
        End Get
        Set(ByVal Value As String)
            If (vcEstado <> eEstado.Vacio And vcEstado <> eEstado.Nuevo) Then ValidarRelacion()
            vcTbFolioDetalle.Campos("Formato").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property TipoEstado() As Integer
        Get
            Return vcTbFolioDetalle.Campos("TipoEstado").Valor
        End Get
        Set(ByVal Value As Integer)
            vcTbFolioDetalle.Campos("TipoEstado").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property MUsuarioId() As String
        Get
            Return vcTbFolioDetalle.Campos("MUsuarioID").Valor
        End Get
        Set(ByVal Value As String)
            vcTbFolioDetalle.Campos("MUsuarioID").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public ReadOnly Property MFechaHora() As Date
        Get
            Return vcTbFolioDetalle.Campos("MFechaHora").Valor
        End Get
    End Property


    Public ReadOnly Property Conexion() As LbConexion.cConexion
        Get
            Return vcTbFolioDetalle.Conexion
        End Get
    End Property

    Public ReadOnly Property Estado() As eEstado
        Get
            Return vcEstado
        End Get
    End Property
#End Region

    Public Sub New(ByRef prFolio As cFolio)
        vcFolio = prFolio
        vcTbFolioDetalle = New LbDatos.cTabla("FolioDetalle")
        With vcTbFolioDetalle.Campos
            .Add(New cCampo("FolioID", ETipo.Cadena, "", True, True))
            .Add(New cCampo("FolioDetClave", ETipo.Cadena, "", True, True))
            .Add(New cCampo("TipoContenido", ETipo.Numerico, True))
            .Add(New cCampo("Formato", ETipo.Cadena, True))
            .Add(New cCampo("TipoEstado", ETipo.Numerico, True))
            .Add(New cCampo("MusuarioID", ETipo.Cadena, True))
            .Add(New cCampo("MFechaHora", ETipo.MFechaHora, False))
        End With
        Tabla = New cFODTabla(vcTbFolioDetalle)
        vcEstado = eEstado.Vacio
    End Sub

    Public Sub Insertar(ByVal pvFolioDetClave As String, ByVal pvTipoContenido As Integer, ByVal pvFormato As String, ByVal pvTipoEstado As Integer, ByVal pvMUsuarioID As String)
        Me.FolioDetClave = pvFolioDetClave
        Me.TipoContenido = pvTipoContenido
        Me.Formato = pvFormato
        Me.TipoEstado = pvTipoEstado
        Me.MUsuarioId = pvMUsuarioID
        Insertar()
        vcEstado = eEstado.Nuevo
    End Sub

    Public Sub Insertar()
        vcTbFolioDetalle.Campos("FolioID").Valor = Me.FolioID
        vcEstado = eEstado.Nuevo
        Validar(True)
    End Sub

    Public Sub Modificar()
        ValidarRelacion()
        vcTbFolioDetalle.Campos("FolioID").Valor = Me.FolioID
        vcEstado = eEstado.Modificado
        Validar(True)
    End Sub

    Private Sub ValidarRelacion()
        Dim vlTemp As New cFolioDetalle(Me.vcFolio)

        Dim FOU As New ERMFOULOG.cFolioUsuario
        Dim dt As DataTable = FOU.Tabla.Recuperar("FolioID='" & Me.FolioID.Replace("'", "''") & "'")
        If Not dt Is Nothing Then
            If dt.Rows.Count > 0 Then
                Throw New LbControlError.cError("E0068", , "FolioID")
            End If
        End If

    End Sub

    Public Sub Grabar()
        vcTbFolioDetalle.Campos("FolioID").Valor = Me.FolioID

        If Not Existe(Me.FolioDetClave) Then
            vcEstado = eEstado.Nuevo
        End If

        Select Case vcEstado
            Case eEstado.Nuevo
                If Not Validar() Then Exit Sub
                vcTbFolioDetalle.Insertar()

                'Case eEstado.Eliminado
                '    For Each vlProductoDetalle As cProductoDetalle In vcPRDArray
                '        vlProductoDetalle.Grabar()
                '    Next

                '    vcTbFolioDetalle.Eliminar()

            Case eEstado.Modificado
                If Not Validar() Then Exit Sub
                vcTbFolioDetalle.Modificar()

                'Case eEstado.Recuperado
                '    For Each vlProductoDetalle As cProductoDetalle In vcPRDArray
                '        vlProductoDetalle.Grabar()
                '    Next
        End Select
    End Sub

    'Public Function Eliminar() As Boolean
    '    vcEstado = eEstado.Eliminado
    '    For Each vlProductoDetalle As cProductoDetalle In vcPRDArray
    '        vlProductoDetalle.Eliminar()
    '    Next
    '    Return True
    'End Function

    Public Function Existe(ByVal pvFolioDetClave As String) As Boolean
        Dim vlDtFolioDetalle As DataTable
        vlDtFolioDetalle = vcTbFolioDetalle.Seleccionar("FolioID='" & Me.FolioID.Replace("'", "''") & "' AND FolioDetClave='" & pvFolioDetClave.Replace("'", "''") & "' ")
        If vlDtFolioDetalle.Rows.Count > 0 Then
            Return True
        End If
        Return False
    End Function
    Public Function Validar(Optional ByVal pvSoloEnMemoria As Boolean = False) As Boolean
        Dim i As Integer

        With vcTbFolioDetalle
            For i = 0 To .Campos.Count - 1
                Dim vlCampo As LbDatos.cCampo
                vlCampo = .Campos(i)
                If Not (vlCampo.Nombre = "FolioID" And pvSoloEnMemoria) Then
                    If vlCampo.Requerido Then
                        If vlCampo.Valor Is Nothing Then
                            Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("FOD" & vlCampo.Nombre, True)}, vlCampo.Nombre)
                            Return False
                        End If
                        If vlCampo.Tipo = LbDatos.ETipo.Cadena Then
                            If vlCampo.Valor = "" Then
                                Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("FOD" & vlCampo.Nombre, True)}, vlCampo.Nombre)
                            End If
                        End If
                    End If
                End If
            Next
        End With

        Return True
    End Function

    Private Sub Limpiar()
        Dim i As Integer
        For i = 0 To vcTbFolioDetalle.Campos.Count - 1
            vcTbFolioDetalle.Campos(i).ADefault()
        Next
        vcEstado = eEstado.Vacio
    End Sub
    Public Sub Recuperar(ByVal pvFolioDetClave As String)
        vcTbFolioDetalle.Campos("FolioID").Valor = Me.FolioID
        vcTbFolioDetalle.Campos("FolioDetClave").Valor = pvFolioDetClave
        Recuperar()
        vcEstado = eEstado.Recuperado
    End Sub

    Public Sub Recuperar()
        Dim vlDt As DataTable = vcTbFolioDetalle.Seleccionar(" FolioID = '" & Me.FolioID.Replace("'", "''") & "' AND FolioDetClave='" & Me.FolioDetClave.Replace("'", "''") & "' ")
        If vlDt.Rows.Count > 0 Then
            Me.TipoContenido = vlDt.Rows(0)("TipoContenido")
            Me.Formato = vlDt.Rows(0)("Formato")
            Me.TipoEstado = vlDt.Rows(0)("TipoEstado")
            vcTbFolioDetalle.Campos("MFechaHora").Valor = vlDt.Rows(0)("MFechaHora")
            vcTbFolioDetalle.Campos("MUsuarioID").Valor = vlDt.Rows(0)("MUsuarioID")
        Else
            Limpiar()
        End If
        vcEstado = eEstado.Recuperado
    End Sub

End Class

Public Class cFODTabla
    Dim vlTbFOD As cTabla

    Public Sub New(ByRef prTbFOD As cTabla)
        vlTbFOD = prTbFOD
    End Sub

    Public Function Recuperar(Optional ByVal pvSelect As String = " * ", Optional ByRef prFiltro As String = "") As DataTable
        Return vlTbFOD.Seleccionar(prFiltro, pvSelect)
    End Function

    Public Sub GrabarTabla(ByRef prTabla As DataTable)
        vlTbFOD.GrabarTabla(prTabla, vlTbFOD.Campos)
    End Sub

    Public Function RecuperarTabla(ByVal pvFiltro As String) As DataTable
        Return vlTbFOD.Seleccionar(pvFiltro)
    End Function

End Class
