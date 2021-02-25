Imports System.IO
Imports System.Data.SqlServerCe
Imports Microsoft.WindowsCE.Forms
Imports System.Runtime.InteropServices


Public Class Dia
    Inherits ServicesCentral.CDia
    Implements ERM.Dia

    Protected tOpcionSeleccionada As ServicesCentral.TiposOpcionesMenuDia
    Private bRegreso As Boolean = False

    Public Property OpcionSeleccionada() As ServicesCentral.TiposOpcionesMenuDia Implements ERM.Dia.OpcionSeleccionada
        Get
            Return tOpcionSeleccionada
        End Get
        Set(ByVal Value As ServicesCentral.TiposOpcionesMenuDia)
            tOpcionSeleccionada = Value            
        End Set
    End Property
    Public Property DiaActual() As String Implements ERM.Dia.DiaActual
        Get
            Return Me.Nombre
        End Get
        Set(ByVal Value As String)
            Me.Nombre = Value
        End Set
    End Property

    'Public Function ActualizarEstado(ByVal pareEstado As ServicesCentral.TiposEstadosRegistros) As Boolean
    '    oDBVen.EjecutarComandoSQL("UPDATE Dia SET Estado=" & pareEstado & " WHERE DiaClave='" & Nombre & "'")
    '    TipoEstado = pareEstado
    'End Function

    Public Function Recuperar() As Boolean
        Try
            Dim DataTableVarios As DataTable
            ' Recuperar los datos de la tabla de Dias
            DataTableVarios = oDBVen.RealizarConsultaSQL("SELECT * FROM Dia WHERE DiaClave='" & Me.Nombre & "'", "Dia")
            If DataTableVarios.Rows.Count = 0 Then
                DataTableVarios.Dispose()
                Exit Try
            End If
            With DataTableVarios.Rows(0)
                'Me.TipoEstado = .Item("Estado")
                Me.Referencia = .Item("Referencia")
                Me.FechaCaptura = .Item("FechaCaptura")
                'Me.FechaEntrega = .Item("FechaEntrega")
                'Me.FechaVenta = .Item("FechaVenta")
            End With
            DataTableVarios.Dispose()
            Return True
        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message, MsgBoxStyle.Critical, "Recuperar")
        Catch ExcB As Exception
            MsgBox(ExcB.Message, MsgBoxStyle.Critical, "Recuperar")
        End Try
        Return False
    End Function

    'Public Function AbrirDB(ByVal bObligarCargarInformacion As Boolean) As Boolean Implements ERM.Dia.AbrirDB
    '    ' Crear la conexion a la base de datos del vendedor
    '    'odbVen = New Conexion(PubcArchivoDatosDia, ServicesCentral.TiposBase.Dia)
    '    'odbVen.ObligarCargarInformacion = bObligarCargarInformacion
    '    'If Not odbVen.Abrir(False) Then
    '    '    Return False
    '    'End If
    '    oDBVen.Grupo = 2
    '    oDBVen.ObligarCargarInformacion = bObligarCargarInformacion
    '    If Not oDBVen.CargarInformacion(2) Then
    '        Return False
    '    End If
    '    Return True
    'End Function

    'Public Function CerrarDB() As Boolean Implements ERM.Dia.CerrarDB
    '    ' Cerrar la base de datos
    '    'odbVen.Cerrar()
    '    'odbVen = Nothing
    'End Function

    Public Function Elegir(ByRef refparbObligarCargarInformacion As Boolean) As Boolean Implements ERM.Dia.Elegir
        Dim FormDia As New FormDia
        Dim bRetorno As Boolean = (FormDia.ShowDialog() = DialogResult.OK)
        'refparbObligarCargarInformacion = FormDia.CheckBoxActualizar.Checked
        With FormDia
            .Dispose()
            FormDia = Nothing
        End With
        Return bRetorno
        'Return True
    End Function

    Public Function MostrarMenu() As Boolean Implements ERM.Dia.MostrarMenu
        Dim FormMenuDia As New FormMenuDia
        FormMenuDia.OpcionSeleccionada = Me.OpcionSeleccionada
        FormMenuDia.ShowDialog()
        Me.OpcionSeleccionada = FormMenuDia.OpcionSeleccionada()
        With FormMenuDia
            .MenuItemRegresar.Dispose()
            .MainMenuDia.Dispose()
            .CtrlMenuDia.Dispose()
            .OpcionSeleccionada = Nothing
            .Dispose()
            FormMenuDia = Nothing
        End With
        Return (Me.OpcionSeleccionada <> ServicesCentral.TiposOpcionesMenuDia.NoDefinido)
    End Function

    Public Sub OpcionCargas() Implements ERM.Dia.OpcionCargas
        Dim oModuloMovDetalle As New Modulos.GrupoModuloMovDetalle
        oModuloMovDetalle.Recuperar(ServicesCentral.TiposModulosMovDet.Cargas, ServicesCentral.TiposTransProd.Cargas)
        Dim oCargasDescargas As New FormasCargasDescargas
        oCargasDescargas.Capturar(oModuloMovDetalle)
        oModuloMovDetalle = Nothing
        oCargasDescargas = Nothing
    End Sub

    Public Sub OpcionDescargas() Implements ERM.Dia.OpcionDescargas
        Dim oModuloMovDetalle As New Modulos.GrupoModuloMovDetalle
        oModuloMovDetalle.Recuperar(ServicesCentral.TiposModulosMovDet.Descargas)
        Dim oCargasDescargas As New FormasCargasDescargas
        oCargasDescargas.Capturar(oModuloMovDetalle)
        oModuloMovDetalle = Nothing
        oCargasDescargas = Nothing
    End Sub

    Public Sub OpcionDepositos() Implements ERM.Dia.OpcionDepositos
        Dim oDeposito As New Deposito
        oDeposito.Capturar()
        oDeposito = Nothing
    End Sub

    Public Sub OpcionCierreDiario() Implements ERM.Dia.OpcionCierreDiario

    End Sub

    Public Sub OpcionRegistrarGastos() Implements ERM.Dia.OpcionRegistrarGastos
        Dim oGastos As New FormasGastos
        oGastos.Capturar()
        oGastos = Nothing
    End Sub

    Public Sub OpcionDevoluciones() Implements ERM.Dia.OpcionDevoluciones
        Dim oDevoluciones As New FormasDevoluciones
        oDevoluciones.Capturar()
        oDevoluciones = Nothing
    End Sub

    Public Sub OpcionKardex() Implements ERM.Dia.OpcionKardex
        Dim oKardex As New FormasKardex
        oKardex.Capturar(oDia)
        oKardex = Nothing
    End Sub

    Public Sub OpcionReportes() Implements ERM.Dia.OpcionReportes
        Dim oRep As New FormasReportes
        oRep.Capturar(oDia)
        oRep = Nothing
    End Sub

    Public Sub OpcionMovSinInv() Implements ERM.Dia.OpcionMovSinInv
        Using frmMovSinInv As New FormMovSinInv(Nothing)
            Dim oModuloMovDetalle As New Modulos.GrupoModuloMovDetalle
            oModuloMovDetalle.Recuperar(ServicesCentral.TiposModulosMovDet.MovSinInvSinVis, ServicesCentral.TiposTransProd.MovSinInvSV)
            frmMovSinInv.Captura(oModuloMovDetalle)

        End Using
    End Sub

    Public Sub OpcionAjustes() Implements ERM.Dia.OpcionAjustes
        Dim oAjustes As New FormasAjustes
        oAjustes.Capturar()
        oAjustes = Nothing
    End Sub

    Public Sub OpcionImprimir() Implements ERM.Dia.OpcionImprimir
        Try
            Dim oImprimir As New FormasImpresion
            oImprimir.ImprimirSinVisita()
            oImprimir = Nothing
        Catch ex As Exception
        End Try
    End Sub

    
    Public Sub OpcionVisitarClientes() Implements ERM.Dia.OpcionVisitarClientes
        Dim bCumple As Boolean = False
        oAgenda = New Agenda
        While oAgenda.MostrarRutas()

            bMostrarLista = True

            While oAgenda.MostrarClientes()
                Dim oVisita As New Visita
                bCumple = False
                If oVisita.MostrarVisitas(oAgenda.ClienteActual, oAgenda.RutaActual.RUTClave, oAgenda.CodigoLeido, oAgenda.FueraFrecuencia, oAgenda.GPSLeido, oAgenda.DistanciaGPS) Then
                    If oVisita.Nueva Then 'Si la visita ya no es nueva, no volver a felicitar.
                        If oAgenda.Cumpleaños(oVisita.VisitaClave) Then
                            bCumple = True
                            Try
                                Dim AppPath As String = IO.Path.GetDirectoryName(Reflection.Assembly.GetExecutingAssembly.GetName.CodeBase)
                                Dim oMp3 As New Mp3Player.cMp3Player
                                oMp3.Mp3FileName = AppPath & IO.Path.DirectorySeparatorChar & "CAN1.mp3"
                                Application.DoEvents()
                                oMp3.PlayMp3()
                            Catch ex As Exception
                            End Try
                        End If
                    End If

                    Dim oMensajesTerminal As New MensajesTerminal
                    oMensajesTerminal.MostrarMensajes(oAgenda, oVisita.VisitaClave, bCumple)
                    oMensajesTerminal = Nothing

                    If oVendedor.motconfiguracion.Secuencia Then
                        ctrlSeguimiento.CeldaSeleccionada = 0
                        ctrlSeguimiento.celdaInicial = 0
                        ctrlSeguimiento.CeldaActual = 0
                        ctrlSeguimiento.TerminarVisita = False
                        ctrlSeguimiento.FueraSecuencia = False
                        ctrlSeguimiento.cicloTerminado = False
                        ctrlSeguimiento.MenuItemSeleccionado = False
                        bRegreso = True
                    End If

                    Dim oModuloMov As New ModuloMov
                    Dim bTerminarVisita As Boolean = False
                    While oModuloMov.MostrarMenu(oAgenda.ClienteActual, oVisita.VisitaClave, bTerminarVisita)
                        ' Elige terminar la visita, mostrar el resumen y de ahi salir del ciclo

                        If Not oModuloMov.ModuloMovActual Is Nothing Then sNombreActividad = oModuloMov.ModuloMovDetActual.Nombre
                        If oModuloMov.ModuloMovActual Is Nothing Then
                            Dim bMasInfo As Boolean = False
                            If oVendedor.motconfiguracion.Secuencia Then
                                bMasInfo = ctrlSeguimiento.MasInfo
                                ctrlSeguimiento.MasInfo = False
                            End If

                            If bMasInfo Then
                                Dim oFormClienteDetalle As New FormClienteDetalle(FormClienteDetalle.eStatus.Existente)
                                oFormClienteDetalle.ShowDialog()
                                oAgenda.ClienteActual.Recuperar()
                                oFormClienteDetalle.Dispose()
                                oFormClienteDetalle = Nothing
                                If oVendedor.motconfiguracion.Secuencia And bRegreso Then
                                    ctrlSeguimiento.MenuItemSeleccionado = False
                                End If
                            Else
                                Dim oResumen As New Resumen
                                If oResumen.ObtenerTotales(oAgenda.ClienteActual, oVisita.VisitaClave) Then
                                    If oResumen.Mostrar() Then
                                        'oAgenda.ActualizarEstadoCliente()
                                        oResumen = Nothing
                                        Exit While
                                    End If
                                End If
                                oResumen = Nothing
                                If oVendedor.motconfiguracion.Secuencia Then
                                    ctrlSeguimiento.CeldaSeleccionada = 0
                                    ctrlSeguimiento.celdaInicial = 0
                                    ctrlSeguimiento.CeldaActual = -1
                                    ctrlSeguimiento.TerminarVisita = False
                                    ctrlSeguimiento.FueraSecuencia = False
                                    ctrlSeguimiento.MenuItemSeleccionado = False
                                End If
                            End If

                        Else
                            Select Case oModuloMov.ModuloMovActual.TipoModuloMov
                                Case ServicesCentral.TiposModulosMov.Encuestas
                                    Dim oEncuestas As New FormasEncuestas
                                    oEncuestas.Encuestar(oAgenda.ClienteActual, oVisita.VisitaClave)
                                    oEncuestas = Nothing
                                    oModuloMov.ModuloMovDetActual = Nothing
                                Case ServicesCentral.TiposModulosMov.Impresion
                                    Dim oImpresion As New FormasImpresion
                                    oImpresion.ImprimirConVisita(oAgenda.ClienteActual, oVisita.VisitaClave)
                                    oImpresion = Nothing
                                    oModuloMov.ModuloMovDetActual = Nothing
                                Case ServicesCentral.TiposModulosMov.Producto, ServicesCentral.TiposModulosMov.Cobranza, ServicesCentral.TiposModulosMov.Otros
                                    Select Case oModuloMov.ModuloMovDetActual.TipoModuloMovDetalle
                                        Case ServicesCentral.TiposModulosMovDet.Pedido
                                            Dim oMovProducto As New MovProducto
                                            oMovProducto.Capturar(oModuloMov.ModuloMovDetActual, oAgenda.ClienteActual, oVisita.VisitaClave)
                                            oMovProducto = Nothing
                                        Case ServicesCentral.TiposModulosMovDet.Cambios
                                            Dim oCambios As New FormasCambios
                                            oCambios.capturar(oModuloMov.ModuloMovDetActual, oAgenda.ClienteActual, oVisita.VisitaClave)
                                            oCambios = Nothing
                                        Case ServicesCentral.TiposModulosMovDet.DevolucionClientes
                                            Dim oDevCliente As New FormasDevolucionesCliente
                                            oDevCliente.Capturar(oModuloMov.ModuloMovDetActual, oAgenda.ClienteActual, oVisita.VisitaClave)
                                            oDevCliente = Nothing
                                        Case ServicesCentral.TiposModulosMovDet.Prestamos
                                            Dim oPrestamos As New FormasPrestamos
                                            oPrestamos.Capturar(oModuloMov.ModuloMovDetActual, oAgenda.ClienteActual, oVisita.VisitaClave)
                                            oPrestamos = Nothing
                                        Case ServicesCentral.TiposModulosMovDet.DevolucionPrestamos
                                            Dim oDevPrestamos As New FormasDevolucionesPrestamos
                                            oDevPrestamos.Capturar(oModuloMov.ModuloMovDetActual, oAgenda.ClienteActual, oVisita.VisitaClave)
                                            oDevPrestamos = Nothing
                                        Case ServicesCentral.TiposModulosMovDet.MovSinInvConVis
                                            'Using frmMovSinInv As New FormMovSinInv(oVisita)
                                            'frmMovSinInv.Captura(oModuloMov.ModuloMovDetActual)
                                            Dim oMovProducto As New MovProducto
                                            oMovProducto.Capturar(oModuloMov.ModuloMovDetActual, oAgenda.ClienteActual, oVisita.VisitaClave)
                                            oMovProducto = Nothing
                                        Case ServicesCentral.TiposModulosMovDet.Facturacion
                                            Dim oFormasFacturacion As New FormasFacturacion
                                            oFormasFacturacion.Mostrar(oModuloMov.ModuloMovDetActual, oAgenda.ClienteActual, oVisita.VisitaClave)
                                            oAgenda.ClienteActual.Recuperar()
                                            oFormasFacturacion = Nothing
                                        Case ServicesCentral.TiposModulosMovDet.FacturacionElectronica
                                            Dim oFormasFacturacionelectronica As New FormasFacturacionElectronica
                                            oFormasFacturacionelectronica.Mostrar(oModuloMov.ModuloMovDetActual, oAgenda.ClienteActual, oVisita.VisitaClave)
                                            oAgenda.ClienteActual.Recuperar()
                                            oFormasFacturacionelectronica = Nothing
                                        Case ServicesCentral.TiposModulosMovDet.Pagos
                                            Dim oFormasPago As New FormasPago
                                            oFormasPago.Capturar(oAgenda.ClienteActual, oVisita.VisitaClave)
                                            oFormasPago = Nothing
                                        Case ServicesCentral.TiposModulosMovDet.CuentasPorCobrar, ServicesCentral.TiposModulosMovDet.Cobranza
                                            Dim oFormasCC As New FormasCuentasxCobrar
                                            oFormasCC.Mostrar(oModuloMov.ModuloMovDetActual, oAgenda.ClienteActual, oVisita.VisitaClave)
                                            oFormasCC = Nothing
                                        Case ServicesCentral.TiposModulosMovDet.PagosProgramados
                                            Dim oFormasPP As New FormasPagosProgramados
                                            oFormasPP.Mostrar(oModuloMov.ModuloMovDetActual, oAgenda.ClienteActual, oVisita.VisitaClave)
                                            oFormasPP = Nothing
                                        Case ServicesCentral.TiposModulosMovDet.Improductivo
                                            Dim oImproductividad As New Improductivo
                                            oImproductividad.Capturar(oAgenda.ClienteActual, oVisita.VisitaClave)
                                            oImproductividad = Nothing
                                        Case ServicesCentral.TiposModulosMovDet.Activos
                                            Dim oActivos As New FormasActivos
                                            oActivos.Capturar(oAgenda.ClienteActual, oVisita.VisitaClave)
                                            oActivos = Nothing
                                        Case ServicesCentral.TiposModulosMovDet.Mensajes
                                        Case ServicesCentral.TiposModulosMovDet.Solicitudes
                                            Dim oSolicitudes As New FormasSolicitudes
                                            oSolicitudes.Capturar(oAgenda.ClienteActual, oVisita.VisitaClave)
                                            oSolicitudes = Nothing
                                        Case ServicesCentral.TiposModulosMovDet.HistoricoVentas
                                            Dim oHistoricoVtas As New FormasHistoricoVtas
                                            oHistoricoVtas.Capturar(oAgenda.ClienteActual, oVisita.VisitaClave)
                                            oHistoricoVtas = Nothing
                                        Case ServicesCentral.TiposModulosMovDet.Canjes
                                            Dim oCanjes As New FormasCanjes
                                            oCanjes.Capturar(oAgenda.ClienteActual)
                                            oCanjes = Nothing
                                        Case ServicesCentral.TiposModulosMovDet.Mercadeo
                                            Dim oMercadeo As New FormasMercadeo
                                            oMercadeo.Capturar(oAgenda.ClienteActual, oVisita.VisitaClave)
                                            oMercadeo = Nothing
                                        Case ServicesCentral.TiposModulosMovDet.SurtirProductoPromocion
                                            Dim oSurtirPromocion As New FormasSurtirPromocion
                                            oSurtirPromocion.Capturar(oModuloMov.ModuloMovDetActual, oAgenda.ClienteActual, oVisita.VisitaClave)
                                            oSurtirPromocion = Nothing
                                        Case ServicesCentral.TiposModulosMovDet.VentaConsignacion
                                            'Dim oFormasVentaConsignacion As New FormasVentaConsignacion
                                            'oFormasVentaConsignacion.Capturar(oModuloMov.ModuloMovDetActual, oAgenda.ClienteActual, oVisita.VisitaClave)
                                            'oFormasVentaConsignacion.Dispose()
                                            'oFormasVentaConsignacion = Nothing
                                        Case ServicesCentral.TiposModulosMovDet.Encuestas
                                            Dim oEncuestas As New FormasEncuestas
                                            oEncuestas.Encuestar(oAgenda.ClienteActual, oVisita.VisitaClave)
                                            oEncuestas = Nothing
                                            oModuloMov.ModuloMovDetActual = Nothing
                                        Case ServicesCentral.TiposModulosMovDet.Impresion
                                            Dim oImpresion As New FormasImpresion
                                            oImpresion.ImprimirConVisita(oAgenda.ClienteActual, oVisita.VisitaClave)
                                            oImpresion = Nothing
                                            oModuloMov.ModuloMovDetActual = Nothing
                                    End Select
                            End Select
                        End If

                        If oVendedor.motconfiguracion.Secuencia Then
                            If Not ctrlSeguimiento.MasInfo Then
                                bRegreso = False
                            End If
                            If Not ctrlSeguimiento.TerminarVisita Then
                                If ctrlSeguimiento.MenuItemSeleccionado Then
                                    ctrlSeguimiento.CeldaSeleccionada = ctrlSeguimiento.CeldaActual - 1
                                    ctrlSeguimiento.celdaInicial = ctrlSeguimiento.CeldaActual - 1
                                ElseIf Not ctrlSeguimiento.dobleclick And ctrlSeguimiento.FueraSecuencia Then
                                    ctrlSeguimiento.FueraSecuencia = False
                                    ctrlSeguimiento.CeldaSeleccionada = ctrlSeguimiento.CeldaActual
                                    bRegreso = True
                                ElseIf Not ctrlSeguimiento.dobleclick Then
                                    ctrlSeguimiento.CeldaActual += 1
                                    ctrlSeguimiento.CeldaSeleccionada = ctrlSeguimiento.CeldaActual
                                End If
                            End If
                        End If

                    End While
                    oVisita = Nothing
                    oModuloMov = Nothing
                End If
                '19-Jul-06 Borrar el cliente actual
                CTEActual = String.Empty
                oAgenda.ClienteActual = Nothing
            End While
            '19-Jul-06 Borrar las combinaciones de teclas
            oAgenda.RutaActual = Nothing
            CTEActual = String.Empty
            '--Quitar que se muestre la lista de precios
            bMostrarLista = False
        End While
        oAgenda = Nothing

    End Sub

    
End Class




