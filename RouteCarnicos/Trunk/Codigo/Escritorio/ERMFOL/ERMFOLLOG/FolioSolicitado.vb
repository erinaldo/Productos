Imports BASLOG
Imports LbDatos

Namespace Amesol
    Public Class CFolioSolicitado
        Inherits cClaseNodo

        Public Sub New()
            MyBase.New()
        End Sub

#Region "Variables"
        Private vlUsuario As String = ""
        Private vgCambioFoliosTerminal As Boolean
        Private vgTerminalClave As String
        Private vgNombreVendedor As String
        Private vTipoDocumento As String
#End Region

#Region "Propiedades"
        Public ReadOnly Property FechaHora() As DateTime
            Get
                Return MFechaHora
            End Get
        End Property

        Public ReadOnly Property Usuario() As String
            Get
                Return vlUsuario
            End Get
        End Property

        Public Property Estado() As eEstado
            Get
                Return Status
            End Get
            Set(ByVal Value As eEstado)
                Me.tEstado = Value
            End Set
        End Property

        Public Property FolioID() As String
            Get
                Return Me.Tabla.Campos("FolioID").Valor
            End Get
            Set(ByVal Value As String)
                If Me.Status = eEstado.Vacio Or Me.Status = eEstado.Nuevo Then
                    Me.Tabla.Campos("FolioID").Valor = Value
                End If
                Verificar_Estatus()
            End Set
        End Property

        Public Property TipoComprobante() As String
            Get
                Return Me.Tabla.Campos("TipoComprobante").Valor
            End Get
            Set(ByVal value As String)
                Me.Tabla.Campos("TipoComprobante").Valor = value
            End Set
        End Property

        Public Property FOSId() As String
            Get
                Return Me.Tabla.Campos("FOSId").Valor
            End Get
            Set(ByVal Value As String)
                If Me.Status = eEstado.Vacio Or Me.Status = eEstado.Nuevo Then
                    Me.Tabla.Campos("FOSId").Valor = Value
                End If
                Verificar_Estatus()
            End Set
        End Property

        Public Property Serie() As String
            Get
                Return Me.Tabla.Campos("Serie").Valor
            End Get
            Set(ByVal Value As String)
                Me.Tabla.Campos("Serie").Valor = Value

                Verificar_Estatus()
            End Set
        End Property

        Public Property FechaCreacion() As Date
            Get
                Return Me.Tabla.Campos("FechaCreacion").Valor
            End Get
            Set(ByVal Value As Date)
                Me.Tabla.Campos("FechaCreacion").Valor = Value

                Verificar_Estatus()
            End Set
        End Property

        Public Property Aprobacion() As Integer
            Get
                Return Me.Tabla.Campos("Aprobacion").Valor
            End Get
            Set(ByVal Value As Integer)
                Me.Tabla.Campos("Aprobacion").Valor = Value

                Verificar_Estatus()
            End Set
        End Property

        Public Property AnioAprobacion() As Integer
            Get
                Return Me.Tabla.Campos("AnioAprobacion").Valor
            End Get
            Set(ByVal Value As Integer)
                Me.Tabla.Campos("AnioAprobacion").Valor = Value

                Verificar_Estatus()
            End Set
        End Property

        Public Property CantSolicitada() As Integer
            Get
                Return Me.Tabla.Campos("CantSolicitada").Valor
            End Get
            Set(ByVal Value As Integer)
                Me.Tabla.Campos("CantSolicitada").Valor = Value

                Verificar_Estatus()
            End Set
        End Property

        Public Property Usados() As Integer
            Get
                Return Me.Tabla.Campos("Usados").Valor
            End Get
            Set(ByVal Value As Integer)
                Me.Tabla.Campos("Usados").Valor = Value

                Verificar_Estatus()
            End Set
        End Property

        Public ReadOnly Property CambioFoliosTerminal() As Boolean
            Get
                Return Me.vgCambioFoliosTerminal
            End Get
        End Property

        Public ReadOnly Property TerminalClave() As String
            Get
                Return Me.vgTerminalClave
            End Get
        End Property

        Public ReadOnly Property NombreVendedor() As String
            Get
                Return Me.vgNombreVendedor
            End Get
        End Property

#End Region

        Private Sub verificaCambiosFoliosTerminal(ByVal sSubEmpresaId As String)
            Dim vcConexion As LbConexion.cConexion = LbConexion.cConexion.Instancia
            Dim dt As DataTable
            Dim dtFoliosTerminal As DataTable

            dtFoliosTerminal = vcConexion.EjecutarConsulta("select Top 1 FoliosTerminal  from SemHist where Subempresaid='" + sSubEmpresaId + "' order by semhistfechainicio desc ")
            If dtFoliosTerminal Is Nothing OrElse dtFoliosTerminal.Rows.Count <= 0 Then
                vgTerminalClave = ""
                vgNombreVendedor = ""
                vgCambioFoliosTerminal = False
                Exit Sub
            End If

            dt = vcConexion.EjecutarConsulta("select top 1 VendedorId, TerminalClave from foshist where fosid in ( " & _
            " select fosid from foliosolicitado where folioid = '" & Me.FolioID.Replace("'", "''") & "' and fosid = '" & Me.FOSId.Replace("'", "''") & "' " & _
            ") order by fshfechainicio desc ")
            If dt.Rows.Count > 0 Then
                If dtFoliosTerminal.Rows(0).Item(0) = True Then 'Terminal
                    If dt.Rows(0).Item("TerminalClave").ToString = "" Then
                        dt = vcConexion.EjecutarConsulta("select nombre from vendedor where vendedorid ='" & dt.Rows(0).Item("VendedorId").ToString().Replace("'", "''") & "'")
                        vgNombreVendedor = dt.Rows(0).Item(0).ToString
                        vgTerminalClave = ""
                        vgCambioFoliosTerminal = True
                        Exit Sub
                    End If

                Else 'Vendedor
                    If dt.Rows(0).Item("VendedorId").ToString = "" Then
                        vgTerminalClave = dt.Rows(0).Item(1).ToString
                        vgNombreVendedor = ""
                        vgCambioFoliosTerminal = True
                        Exit Sub
                    End If

                End If
            End If

            vgTerminalClave = ""
            vgNombreVendedor = ""
            vgCambioFoliosTerminal = False
        End Sub

        Protected Overrides Sub CrearEstructuraTabla()
            With Me.Tabla
                .AgregarCampo(New LbDatos.cCampo("FolioID", LbDatos.ETipo.Cadena, "", True, True))
                .AgregarCampo(New LbDatos.cCampo("FOSId", LbDatos.ETipo.Cadena, "", True, True))
                .AgregarCampo(New LbDatos.cCampo("Serie", LbDatos.ETipo.Cadena, "", False, False))
                .AgregarCampo(New LbDatos.cCampo("FechaCreacion", LbDatos.ETipo.FechaHora, "", False, True))
                .AgregarCampo(New LbDatos.cCampo("TipoComprobante", LbDatos.ETipo.Numerico, "", False, True))
                .AgregarCampo(New LbDatos.cCampo("Aprobacion", LbDatos.ETipo.Numerico, "", False, True))
                .AgregarCampo(New LbDatos.cCampo("AnioAprobacion", LbDatos.ETipo.Numerico, "", False, True))
                .AgregarCampo(New LbDatos.cCampo("CantSolicitada", LbDatos.ETipo.Numerico, "", False, True))
                .AgregarCampo(New LbDatos.cCampo("Usados", LbDatos.ETipo.Numerico, "", False, True))

            End With

        End Sub

        Public Overridable Sub Verificar_Estatus()

            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Sub

        Public Overridable Overloads Function Existe(ByVal pvFolioID As String, ByVal pvFOSId As String) As Boolean
            Return (Me.Tabla.Seleccionar("FolioID='" & pvFolioID.Replace("'", "''") & "',FOSId='" & pvFOSId.Replace("'", "''") & "'").Rows.Count > 0)
        End Function

        Public Overridable Overloads Sub Recuperar(ByVal pvFolioID As String, ByVal pvFOSId As String, ByVal pvSubEmpresaID As String)
            Me.Limpiar()
            Me.FolioID = pvFolioID
            Me.FOSId = pvFOSId
            Me.Recuperar()

            Dim vcConexion As LbConexion.cConexion = LbConexion.cConexion.Instancia
            Dim dt As DataTable = vcConexion.EjecutarConsulta("Select Nombre from usuario where USUId = '" & MUsuarioID.Replace("'", "''") & "'")
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                vlUsuario = dt.Rows(0).Item("Nombre")
            End If


            verificaCambiosFoliosTerminal(pvSubEmpresaID)

        End Sub

        Public Overloads Sub Insertar(ByVal pvFolioID As String, ByVal pvFOSId As String, ByVal pvSerie As String, ByVal pvFechaCreacion As Date, ByVal pvAprobacion As Integer, ByVal pvAnioAprobacion As Integer, ByVal pvCantSolicitada As Integer, ByVal pvUsados As Integer, ByVal pvTipoComprobante As Integer)

            Me.FolioID = pvFolioID
            Me.FOSId = pvFOSId
            Me.Serie = pvSerie
            Me.FechaCreacion = pvFechaCreacion
            Me.Aprobacion = pvAprobacion
            Me.AnioAprobacion = pvAnioAprobacion
            Me.CantSolicitada = pvCantSolicitada
            Me.Usados = pvUsados
            Me.TipoComprobante = pvTipoComprobante
            Me.Insertar()
        End Sub

        Public Overloads Sub Actualizar(ByVal pvFolioID As String, ByVal pvFOSId As String, ByVal pvSerie As String, ByVal pvFechaCreacion As Date, ByVal pvAprobacion As Integer, ByVal pvAnioAprobacion As Integer, ByVal pvCantSolicitada As Integer, ByVal pvUsados As Integer, ByVal pvTipoComprobante As Integer)

            Me.FolioID = pvFolioID
            Me.FOSId = pvFOSId
            Me.Serie = pvSerie
            Me.FechaCreacion = pvFechaCreacion
            Me.Aprobacion = pvAprobacion
            Me.AnioAprobacion = pvAnioAprobacion
            Me.CantSolicitada = pvCantSolicitada
            Me.Usados = pvUsados
            Me.TipoComprobante = pvTipoComprobante
            Me.tEstado = eEstado.Modificado
        End Sub

        Protected Overrides Function RegresaEnsamblado() As System.Reflection.Assembly
            Return System.Reflection.Assembly.GetExecutingAssembly()
        End Function

        Protected Overrides Function RegresaMnemonico() As String
            'TODO:Cambiar al nemonico correcto 
            Return "FOS"
        End Function

        Protected Overrides Function RegresaNombreTabla() As String
            Return "FolioSolicitado"
        End Function

        Protected Overrides Sub CrearHijos()
            'TODO: Crear los hijos si es necesario
        End Sub

    End Class
End Namespace
