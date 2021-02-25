Imports System.Data.SqlServerCe

Public Class Vendedor
    Inherits ServicesCentral.Vendedor
    Implements ERM.Vendedor

    Protected sNombreModulo As String
    Protected bMostrarEsquema As Boolean
    Protected bActualizaEsquema As Boolean
    Protected dFecha As Date
    Protected sCodigoBarras As String
    Protected sClaveCEDI As String
    Protected tOpcionSeleccionada As ServicesCentral.TiposOpcionesMenuVendedor
    Protected bJornadaTrabajo As Boolean
    Protected bMostrarCuota As Boolean
    Protected tTipoModulo As ServicesCentral.TiposModulos
    Protected bMantenerPrm As Boolean
    Protected tTipoModImp As Integer
    Protected sNombreVendedor As String
    Protected bEditarDatosFiscal As Boolean
    Protected cMOTConfiguracion As MOTConfiguracion
    Protected sClaveModulo As String
    Protected bGPS As Boolean
    Protected bKilometraje As Boolean


    Public ReadOnly Property motconfiguracion() As MOTConfiguracion
        Get
            Return Me.cMOTConfiguracion
        End Get
    End Property

    Public Property OpcionSeleccionada() As ServicesCentral.TiposOpcionesMenuVendedor Implements ERM.Vendedor.OpcionSeleccionada
        Get
            Return tOpcionSeleccionada
        End Get
        Set(ByVal Value As ServicesCentral.TiposOpcionesMenuVendedor)
            tOpcionSeleccionada = Value
        End Set
    End Property

    Public Property NombreModulo() As String Implements ERM.Vendedor.NombreModulo
        Get
            Return sNombreModulo
        End Get
        Set(ByVal Value As String)
            sNombreModulo = Value
        End Set
    End Property
    'Public Property MostrarEsquema() As Boolean
    '    Get
    '        Return bMostrarEsquema
    '    End Get
    '    Set(ByVal Value As Boolean)
    '        bMostrarEsquema = Value
    '    End Set
    'End Property

    Public Property ActualizaEsquema() As Boolean
        Get
            Return bActualizaEsquema
        End Get
        Set(ByVal Value As Boolean)
            bActualizaEsquema = Value
        End Set
    End Property

    Public Property Fecha() As Date
        Get
            Return IIf(IsDBNull(dFecha), Nothing, dFecha)
        End Get
        Set(ByVal Value As Date)
            dFecha = Value
        End Set
    End Property

    Public Property CodigoBarras() As String
        Get
            Return IIf(IsDBNull(sCodigoBarras), String.Empty, sCodigoBarras)
        End Get
        Set(ByVal Value As String)
            sCodigoBarras = Value
        End Set
    End Property

    Public Property ClaveCEDI() As String
        Get
            Return IIf(IsDBNull(sClaveCEDI), String.Empty, sClaveCEDI)
        End Get
        Set(ByVal Value As String)
            sClaveCEDI = Value
        End Set
    End Property
    Public Property JornadaTrabajo() As Boolean
        Get
            Return bJornadaTrabajo
        End Get
        Set(ByVal Value As Boolean)
            bJornadaTrabajo = Value
        End Set
    End Property
    Public Property MostrarCuota() As Boolean
        Get
            Return bMostrarCuota
        End Get
        Set(ByVal Value As Boolean)
            bMostrarCuota = Value
        End Set
    End Property
    Public Property TipoModulo() As ServicesCentral.TiposModulos
        Get
            Return tTipoModulo
        End Get
        Set(ByVal Value As ServicesCentral.TiposModulos)
            tTipoModulo = Value
        End Set
    End Property
    Public Property MantenerPrm() As Boolean
        Get
            Return bMantenerPrm
        End Get
        Set(ByVal value As Boolean)
            bMantenerPrm = value
        End Set
    End Property

    Public Property TipoModImp() As Integer
        Get
            Return tTipoModImp
        End Get
        Set(ByVal value As Integer)
            tTipoModImp = value
        End Set
    End Property

    Public Property NombreVendedor() As String
        Get
            Return sNombreVendedor
        End Get
        Set(ByVal value As String)
            sNombreVendedor = value
        End Set
    End Property
    Public Property EditarDatosFiscal() As Boolean
        Get
            Return bEditarDatosFiscal
        End Get
        Set(ByVal value As Boolean)
            bEditarDatosFiscal = value
        End Set
    End Property
    Public Property ClaveModulo() As String
        Get
            Return sClaveModulo
        End Get
        Set(ByVal value As String)
            sClaveModulo = value
        End Set
    End Property
    Public Property GPS() As Boolean
        Get
            Return bGPS
        End Get
        Set(ByVal value As Boolean)
            bGPS = value
        End Set
    End Property
    Public Property Kilometraje() As Boolean
        Get
            Return bKilometraje
        End Get
        Set(ByVal value As Boolean)
            bKilometraje = value
        End Set
    End Property


    Public Sub New(ByRef refparoUsuario As Usuario)
        Me.UsuarioId = refparoUsuario.UsuarioId
        Me.Clave = refparoUsuario.Clave
        Me.Nombre = refparoUsuario.Nombre
    End Sub


    Public Function RecuperarParametros(ByVal pvInicio As Boolean) As Boolean Implements ERM.Vendedor.RecuperarParametros
        ' Recuperar los datos del vendedor
        Dim DataTableVarios As DataTable
        Dim sConsultaSQL As String
        sConsultaSQL = "SELECT ModuloTerm.ModuloClave AS ModuloClave, ModuloTerm.Nombre AS ModuloNombre,ModuloTerm.TipoIndice, Vendedor.*, MOT.ModuloClave, MOT.Secuencia, MOT.SecuenciaObligatoria,MOT.TerminarSecuencia,MOT.ResumenMovimientos,MOT.MensajeImpresion " & _
        "FROM Vendedor inner join MOTConfiguracion mot on mot.mcnclave = vendedor.mcnclave "
        sConsultaSQL &= "LEFT JOIN ModuloTerm ON Vendedor.ModuloClave = ModuloTerm.ModuloClave "
        If pvInicio Then
            sConsultaSQL &= "WHERE (Vendedor.USUId = '" & Me.UsuarioId & "' and Vendedor.Baja<>1 and Vendedor.TipoEstado=1)"
        Else
            sConsultaSQL &= "WHERE (Vendedor.USUId = '" & oApp.Usuario.UsuarioId & "' and Vendedor.Baja<>1 and Vendedor.TipoEstado=1)"
        End If
        Try
            DataTableVarios = oDBVen.RealizarConsultaSQL(sConsultaSQL, "Vendedor")
            If DataTableVarios.Rows.Count = 0 Then
                MsgBox(gVista.BuscarMensaje("MsgBoxConexion", "E0211"), MsgBoxStyle.Critical)
                Return False
            ElseIf IsDBNull(DataTableVarios.Rows(0)("ModuloClave")) Then
                MsgBox(gVista.BuscarMensaje("MsgBoxConexion", "E0484"), MsgBoxStyle.Critical)
                Return False
            End If
            With DataTableVarios.Rows(0)
                Me.NombreModulo = .Item("ModuloNombre")
                Me.ClaveModulo = .Item("ModuloClave")
                Me.TipoModulo = .Item("TipoIndice")
                Me.Nivel = .Item("Nivel")
                Me.VendedorId = .Item("VendedorId")
                Me.AlmacenId = .Item("AlmacenID")
                Me.LimiteDescuento = .Item("LimiteDescuento")
                'Me.MostrarEsquema = .Item("MostrarEsquema")
                Me.ActualizaEsquema = .Item("ActualizaEsquema")
                Me.CapturaFolioFac = .Item("CapturaFolioFac")
                Me.Fecha = IIf(IsDBNull(.Item("Fecha")), Nothing, .Item("Fecha"))
                Me.CodigoBarras = IIf(IsDBNull(.Item("CodigoBarras")), String.Empty, .Item("CodigoBarras"))
                Me.ClaveCEDI = IIf(IsDBNull(.Item("ClaveCEDI")), String.Empty, .Item("ClaveCEDI"))
                Me.JornadaTrabajo = .Item("JornadaTrabajo")
                Me.MostrarCuota = .Item("MostrarCuota")
                Me.MantenerPrm = .Item("MantenerPrm")
                Me.TipoModImp = .Item("TipoModImp")
                Me.NombreVendedor = .Item("Nombre")
                Me.EditarDatosFiscal = .Item("EditarDatosFiscal")
                Me.MCNClave = .Item("MCNClave")
                Me.GPS = .Item("GPS")
                Me.Kilometraje = .Item("Kilometraje")

                Me.cMOTConfiguracion = New MOTConfiguracion
                Me.cMOTConfiguracion.MCNClave = .Item("MCNClave")
                Me.cMOTConfiguracion.ModuloClave = .Item("ModuloClave")
                Me.cMOTConfiguracion.Secuencia = .Item("Secuencia")
                Me.cMOTConfiguracion.SecuenciaObligatoria = .Item("SecuenciaObligatoria")
                Me.cMOTConfiguracion.TerminarSecuencia = .Item("TerminarSecuencia")
                Me.cMOTConfiguracion.ResumenMovimientos = .Item("ResumenMovimientos")
                Me.cMOTConfiguracion.MensajeImpresion = .Item("MensajeImpresion")
            End With
            Select Case oVendedor.Nivel
                Case ServicesCentral.TiposNivelesVendedores.Principiante
                    oApp.TipoSeleccion = ItemActivation.TwoClick
                Case ServicesCentral.TiposNivelesVendedores.Intermedio
                    oApp.TipoSeleccion = ItemActivation.OneClick
                Case ServicesCentral.TiposNivelesVendedores.Avanzado
                    oApp.TipoSeleccion = ItemActivation.OneClick
            End Select
            oConHist = New CONHist

            SubEmpresa.Llenar()

            Return True
        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message, MsgBoxStyle.Critical, "RecuperarParametros")
        Catch ExcB As Exception
            MsgBox(ExcB.Message, MsgBoxStyle.Critical, "RecuperarParametros")
        End Try
        Return False
    End Function

    Public Sub ActualizarFecha()
        oDBVen.EjecutarComandoSQL("Update Vendedor set Fecha = getdate()")
        Me.Fecha = Now
    End Sub

    Public Function AbrirDB() As Boolean Implements ERM.Vendedor.AbrirDB
        Try
            ' Crear la conexion a la base de datos del vendedor
            oDBVen = New Conexion(oVendedor.UsuarioId & ".sdf", ServicesCentral.TiposBase.Vendedor)
            'oDBVen.Grupo = 0
            ' Abrir la conexión
            If Not oDBVen.Abrir(False) Then
                Return False
            End If
            oVendedor.RecuperarParametros(True)
            g_dtProductos = oDBVen.RealizarConsultaSQL("Select ProductoClave, Nombre, Id from Producto order by Nombre ", "Productos")
            Return True
        Catch ex As System.Net.Sockets.SocketException
            MsgBox(gVista.BuscarMensaje("MsgBoxConexion", "F0008"), MsgBoxStyle.Information, "AbrirBD")
            Return False
        Catch ex As System.InvalidCastException
            MsgBox("[I0167] Se perdió la conexión con el servidor. Intentelo nuevamente", MsgBoxStyle.Information, "AbrirBD")
            Return False
        Catch ex As Exception
            MsgBox(ex.GetBaseException.GetType.ToString() & " '" & ex.GetBaseException.Message & "'", MsgBoxStyle.Exclamation, "AbrirBD")
            Return False
        End Try
    End Function

    Public Function CerrarDB() As Boolean Implements ERM.Vendedor.CerrarDB
        ' Cerrar la conexion
        oDBVen.Cerrar()
    End Function

    Public Function MostrarMenu() As Boolean Implements ERM.Vendedor.MostrarMenu
        Dim FormMenuVendedor As New FormMenuVendedor
        FormMenuVendedor.OpcionSeleccionada = Me.OpcionSeleccionada
        FormMenuVendedor.ShowDialog()
        Me.OpcionSeleccionada = FormMenuVendedor.OpcionSeleccionada
        FormMenuVendedor.MenuItemRegresar.Dispose()
        FormMenuVendedor.MainMenuVendedor.Dispose()
        FormMenuVendedor.CtrlMenuVendedor.Dispose()
        FormMenuVendedor.OpcionSeleccionada = Nothing
        FormMenuVendedor.Dispose()
        FormMenuVendedor = Nothing

        Return (Me.OpcionSeleccionada <> ServicesCentral.TiposOpcionesMenuVendedor.NoDefinido)
    End Function

    Public Function OpcionConfigurarTerminal() As Boolean Implements ERM.Vendedor.OpcionConfigurarTerminal

    End Function

    Public Function OpcionDiasDeTrabajo() As Boolean Implements ERM.Vendedor.OpcionDiasDeTrabajo
        oDia = New Dia
        Dim bObligarCargarInformacion As Boolean = True
        While oDia.Elegir(bObligarCargarInformacion)
            'If oDia.AbrirDB(bObligarCargarInformacion) Then
            While oDia.MostrarMenu()
                Select Case oDia.OpcionSeleccionada
                    Case ServicesCentral.TiposOpcionesMenuDia.VisitarClientes
                        oDia.OpcionVisitarClientes()
                    Case ServicesCentral.TiposOpcionesMenuDia.Cargas
                        oDia.OpcionCargas()
                    Case ServicesCentral.TiposOpcionesMenuDia.Descargas
                        oDia.OpcionDescargas()
                    Case ServicesCentral.TiposOpcionesMenuDia.RegistrarGastos
                        oDia.OpcionRegistrarGastos()
                    Case ServicesCentral.TiposOpcionesMenuDia.CierreDiario
                        oDia.OpcionCierreDiario()
                    Case ServicesCentral.TiposOpcionesMenuDia.Devoluciones
                        oDia.OpcionDevoluciones()
                    Case ServicesCentral.TiposOpcionesMenuDia.Depositos
                        oDia.OpcionDepositos()
                    Case ServicesCentral.TiposOpcionesMenuDia.Kardex
                        oDia.OpcionKardex()
                    Case ServicesCentral.TiposOpcionesMenuDia.Ajustes
                        oDia.OpcionAjustes()
                    Case ServicesCentral.TiposOpcionesMenuDia.ImpresionTickets
                        oDia.OpcionImprimir()
                    Case ServicesCentral.TiposOpcionesMenuDia.Reportes
                        oDia.OpcionReportes()
                    Case ServicesCentral.TiposOpcionesMenuDia.MovSinInv
                        oDia.OpcionMovSinInv()
                End Select
            End While
            'End If
            'oDia.CerrarDB()
        End While
        oDia = Nothing
    End Function

    Public Function OpcionInformacionSistema() As Boolean Implements ERM.Vendedor.OpcionInformacionSistema

    End Function

    Public Function OpcionTransferirInformacion() As Boolean Implements ERM.Vendedor.OpcionTransferirInformacion
        Dim oFormComunicacion As New FormComunicacion(ServicesCentral.TiposBase.Vendedor)
        oFormComunicacion.ShowDialog()
        oFormComunicacion.Dispose()
        oFormComunicacion = Nothing
        Return True
    End Function

    Public Function OpcionUtileriasSistema() As Boolean Implements ERM.Vendedor.OpcionUtileriasSistema

    End Function

    Public Function OpcionIniciarJornada() As Boolean Implements ERM.Vendedor.OpcionIniciarJornada
        Dim oForm As New FormInicioFinJornada(FormInicioFinJornada.eTipoForma.IniciarJornada)
        If oForm.ShowDialog = DialogResult.OK Then
            oForm.Dispose()
            oForm = Nothing
            Return True
        End If
        oForm.Dispose()
        oForm = Nothing
        Return False
    End Function

    Public Function OpcionFinalizarJornada() As Boolean Implements ERM.Vendedor.OpcionFinalizarJornada
        Dim oForm As New FormInicioFinJornada(FormInicioFinJornada.eTipoForma.FinalizarJornada)
        If oForm.ShowDialog = DialogResult.OK Then
            oForm.Dispose()
            oForm = Nothing
            Return True
        End If
        oForm.Dispose()
        oForm = Nothing
        Return False
    End Function

    Public Function OpcionPreliquidacion() As Boolean Implements ERM.Vendedor.OpcionPreliquidacion
        Dim oForm As New FormPreliquidacion
        oForm.ShowDialog()
        oForm.Dispose()
        oForm = Nothing

        Return True
    End Function

    Public Function OpcionReportes() As Boolean Implements ERM.Vendedor.OpcionReportes
        Dim oFormReportes As New FormReportes(oDia, "FUERA")

        If oFormReportes.ShowDialog() = DialogResult.OK Then
            oFormReportes.Dispose()
            oFormReportes = Nothing
            Return True
        End If
        oFormReportes.Dispose()
        oFormReportes = Nothing
        Return False
    End Function

    Public Function OpcionKilometraje() As Boolean Implements ERM.Vendedor.OpcionKilometraje
        Dim oForm As New FormKilometraje
        oForm.ShowDialog()
        oForm.Dispose()
        oForm = Nothing
        Return True
    End Function
End Class

