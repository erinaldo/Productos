Public Class cTerminal
    Dim vcConexion As LbConexion.cConexion
    Private vcTbTerminal As LbDatos.cTabla
    Public Tabla As cTERTabla

#Region "Propiedades"

    Public Property TerminalClave() As String
        Get
            Return vcTbTerminal.Campos("TerminalClave").Valor
        End Get
        Set(ByVal Value As String)
            If vcTbTerminal.Campos("TerminalClave").Valor = "" Then
                vcTbTerminal.Campos("TerminalClave").Valor = Value
            End If
        End Set
    End Property

    Public Property TipoFase() As Integer
        Get
            Return vcTbTerminal.Campos("TipoFase").Valor
        End Get
        Set(ByVal Value As Integer)
            vcTbTerminal.Campos("TipoFase").Valor = Value
        End Set
    End Property

    Public Property Descripcion() As String
        Get
            Return vcTbTerminal.Campos("Descripcion").Valor
        End Get
        Set(ByVal Value As String)
            vcTbTerminal.Campos("Descripcion").Valor = Value
        End Set
    End Property

    Public Property NumeroSerie() As String
        Get
            Return vcTbTerminal.Campos("NumeroSerie").Valor
        End Get
        Set(ByVal Value As String)
            vcTbTerminal.Campos("NumeroSerie").Valor = Value
        End Set
    End Property

    Public Property Comentario() As String
        Get
            Return vcTbTerminal.Campos("Comentario").Valor
        End Get
        Set(ByVal Value As String)
            vcTbTerminal.Campos("Comentario").Valor = Value
        End Set
    End Property

    Public Property GPS() As Boolean
        Get
            Return vcTbTerminal.Campos("GPS").Valor
        End Get
        Set(ByVal value As Boolean)
            vcTbTerminal.Campos("GPS").Valor = value
        End Set
    End Property

    Public ReadOnly Property MFechaHora() As DateTime
        Get
            Return vcTbTerminal.Campos("MFechaHora").Valor
        End Get
    End Property

    Public Property MUsuarioID() As String
        Get
            Return vcTbTerminal.Campos("MUsuarioID").Valor
        End Get
        Set(ByVal Value As String)
            vcTbTerminal.Campos("MUsuarioID").Valor = Value
        End Set
    End Property

    Public ReadOnly Property Conexion() As LbConexion.cConexion
        Get
            Return vcConexion
        End Get
    End Property

#End Region

    Public Sub New()
        vcConexion = LbConexion.cConexion.Instancia

        vcTbTerminal = New LbDatos.cTabla("Terminal")

        With vcTbTerminal
            .AgregarCampo(New LbDatos.cCampo("TerminalClave", LbDatos.ETipo.Cadena, "", True, True))
            .AgregarCampo(New LbDatos.cCampo("TipoFase", LbDatos.ETipo.Numerico, True))
            .AgregarCampo(New LbDatos.cCampo("Descripcion", LbDatos.ETipo.Cadena, False))
            .AgregarCampo(New LbDatos.cCampo("NumeroSerie", LbDatos.ETipo.Cadena, False))
            .AgregarCampo(New LbDatos.cCampo("Comentario", LbDatos.ETipo.Cadena, False))
            .AgregarCampo(New LbDatos.cCampo("GPS", LbDatos.ETipo.Bit, False))
            .AgregarCampo(New LbDatos.cCampo("MFechaHora", LbDatos.ETipo.Fecha, True))
            .AgregarCampo(New LbDatos.cCampo("MUsuarioID", LbDatos.ETipo.Cadena, True))
        End With

        Tabla = New cTERTabla(vcTbTerminal)
    End Sub

    Public Function Insertar(ByVal pvTerminalClave As String, ByVal pvTipoFase As Integer, ByVal pvDescripcion As String, ByVal pvNumeroSerie As String, ByVal pvComentario As String, ByVal pvGPS As Boolean, ByVal pvMUsuarioId As String) As Boolean
        Limpiar()
        Me.TerminalClave = pvTerminalClave
        Me.TipoFase = pvTipoFase
        Me.Descripcion = pvDescripcion
        Me.NumeroSerie = pvNumeroSerie
        Me.Comentario = pvComentario
        Me.GPS = pvGPS
        Me.MUsuarioID = pvMUsuarioId
        Return Insertar()
    End Function

    Public Function Insertar() As Boolean
        vcTbTerminal.Campos("MFechaHora").Valor = vcConexion.ObtenerFecha
        If Not Existe(Me.TerminalClave) Then
            If ValidarCampos() Then
                Return vcTbTerminal.Insertar()
            End If
        Else
            Throw New LbControlError.cError("BE0002", , "TerminalClave")
            Return False
        End If
        Return True
    End Function

    Public Function Existe(ByVal pvTerminalClave As String) As Boolean
        Dim vlDtTerminal As DataTable

        vlDtTerminal = vcTbTerminal.Seleccionar("TerminalClave='" & lbGeneral.ValidaFormatoSQLString(pvTerminalClave) & "'")
        If vlDtTerminal.Rows.Count > 0 Then
            Return True
        End If

        Return False
    End Function

    Public Function FoliosAsignados(ByVal parsSubempresaid As String) As Boolean

        Dim sConsulta As String
        sConsulta = "select count(*) as Pendientes from FosHist FOH "
        sConsulta &= "inner join FolioSolicitado FOS on FOH.FolioId = FOS.FolioId and FOH.FOSId = FOS.FOSId "
        sConsulta &= "inner join Folio FOL on FOL.FolioId = FOS.FolioId  and FOL.SubEmpresaID = '" + parsSubempresaid + "'"
        sConsulta &= "where TerminalClave = '" & lbGeneral.ValidaFormatoSQLString(Me.TerminalClave) & "' and  FOS.Usados < FOS.CantSolicitada "
        Return (vcConexion.EjecutarComandoScalar(sConsulta) > 0)

    End Function

    Public Function ValidarCampos() As Boolean
        Dim i As Integer

        With vcTbTerminal
            For i = 0 To .Campos.Count - 1
                Dim vlCampo As LbDatos.cCampo
                vlCampo = .Campos(i)
                If vlCampo.Requerido Then
                    If vlCampo.Valor Is Nothing Then
                        Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("TER" & vlCampo.Nombre, True)}, vlCampo.Nombre)
                        Return False
                    End If
                    If vlCampo.Tipo = LbDatos.ETipo.Cadena Then
                        If vlCampo.Valor = "" Then
                            Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("TER" & vlCampo.Nombre, True)}, vlCampo.Nombre)
                        End If
                    End If
                End If
                Select Case vlCampo.Tipo
                    Case LbDatos.ETipo.Numerico
                        If vlCampo.Valor < 0 Then
                            Throw New LbControlError.cError("E0007", , vlCampo.Nombre)
                        End If
                End Select
            Next
        End With

        Return True
    End Function

    Public Sub Limpiar()
        Dim i As Integer
        For i = 0 To vcTbTerminal.Campos.Count - 1
            vcTbTerminal.Campos(i).ADefault()
        Next
    End Sub

    Public Function Recuperar(ByVal pvTerminalClave As String) As Boolean
        Dim vlDtTerminal As DataTable = vcTbTerminal.Seleccionar("TerminalClave='" + lbGeneral.ValidaFormatoSQLString(pvTerminalClave) + "'")
        If vlDtTerminal.Rows.Count > 0 Then
            Dim vlDrTerminal As DataRow = vlDtTerminal.Rows(0)
            Me.TerminalClave = vlDrTerminal("TerminalClave")
            Me.TipoFase = vlDrTerminal("TipoFase")
            Me.Descripcion = IIf(IsDBNull(vlDrTerminal("Descripcion")), Nothing, vlDrTerminal("Descripcion"))
            Me.NumeroSerie = IIf(IsDBNull(vlDrTerminal("NumeroSerie")), Nothing, vlDrTerminal("NumeroSerie"))
            Me.Comentario = IIf(IsDBNull(vlDrTerminal("Comentario")), Nothing, vlDrTerminal("Comentario"))
            Me.GPS = vlDrTerminal("GPS")
            Me.MUsuarioID = vlDrTerminal("MUsuarioID")
            vcTbTerminal.Campos("MFechaHora").Valor = vlDrTerminal("MFechaHora")
            Return True
        Else
            Return False
        End If

    End Function

    Public Function Grabar() As Boolean
        vcTbTerminal.Campos("MFechaHora").Valor = vcConexion.ObtenerFecha
        If ValidarCampos() Then
            Return vcTbTerminal.Modificar()
        End If
        Return True
    End Function

    Public Class cTERTabla
        Private vcTbTerminal As LbDatos.cTabla
        Public Sub New(ByRef prTbMensaje As LbDatos.cTabla)
            vcTbTerminal = prTbMensaje
        End Sub

        Public Function Recuperar(ByVal pvFiltro As String) As DataTable
            Dim vldtCamion As New DataTable
            vldtCamion = vcTbTerminal.Seleccionar(pvFiltro)
            Return vldtCamion
        End Function

        Public Sub InsertarEn(ByRef prDtTerminal As DataTable)
            vcTbTerminal.Insertar(prDtTerminal)
        End Sub

        Public Sub ModificarEn(ByRef prDtTerminal As DataTable)
            vcTbTerminal.Modificar(prDtTerminal)
        End Sub
    End Class

End Class
