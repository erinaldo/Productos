
Interface ERM

    Interface Aplicacion
        Function Iniciar() As Boolean
        Function CicloPrincipal() As Boolean
        Function AbrirDB() As Boolean
        Function CerrarDB() As Boolean
        Interface Usuario
            Function Pedir() As Boolean
            Function Recuperar(ByVal parsUsuario As String, ByVal parsContrasena As String) As Boolean
        End Interface
    End Interface


    Interface Vendedor
        Function RecuperarParametros(ByVal pvInicio As Boolean) As Boolean
        Function AbrirDB() As Boolean
        Function MostrarMenu() As Boolean
        Function CerrarDB() As Boolean
        Property OpcionSeleccionada() As ServicesCentral.TiposOpcionesMenuVendedor
        Property NombreModulo() As String
        Function OpcionDiasDeTrabajo() As Boolean
        Function OpcionConfigurarTerminal() As Boolean
        Function OpcionTransferirInformacion() As Boolean
        Function OpcionInformacionSistema() As Boolean
        Function OpcionUtileriasSistema() As Boolean
        Function OpcionIniciarJornada() As Boolean
        Function OpcionFinalizarJornada() As Boolean
        Function OpcionPreliquidacion() As Boolean
        Function OpcionReportes() As Boolean
        Function OpcionKilometraje() As Boolean
    End Interface


    Interface Dia
        Function Elegir(ByRef refparbObligarCargarInformacion As Boolean) As Boolean
        'Function AbrirDB(ByVal bObligarCargarInformacion As Boolean) As Boolean
        Function MostrarMenu() As Boolean
        'Function CerrarDB() As Boolean
        Sub OpcionCargas()
        Sub OpcionDescargas()
        Sub OpcionVisitarClientes()
        Sub OpcionRegistrarGastos()
        Sub OpcionDepositos()
        Sub OpcionCierreDiario()
        Sub OpcionDevoluciones()
        Sub OpcionKardex()
        Sub OpcionAjustes()
        Sub OpcionImprimir()
        Sub OpcionReportes()
        Sub OpcionMovSinInv()
        Property DiaActual() As String
        Property OpcionSeleccionada() As ServicesCentral.TiposOpcionesMenuDia

        Interface Agenda
            'property RutaActual as 
            Property RutaActual() As Ruta
            Function MostrarRutas() As Boolean
            Property ClienteActual() As Cliente
            Function MostrarClientes() As Boolean

            Interface Visita
                Property DiaClave() As String
                Property VisitaClave() As String
                Function MostrarVisitas(ByVal paroCliente As Cliente, ByVal pvRutClave As String, ByVal pvCodigoLeido As Boolean, ByVal pvFueraFrecuencia As Boolean, ByVal pvGPSLeido As Boolean, ByVal pvDistanciaGPS As Decimal) As Boolean

                Interface ModuloMov
                    Property ModuloMovDetActual() As Modulos.GrupoModuloMovDetalle
                    Function MostrarMenu(ByVal paroCliente As Cliente, ByVal parsVisitaActual As String, ByVal parbTerminarVisita As Boolean) As Boolean

                    Interface MovProducto
                        Property TransProd() As TransProd
                        Function Capturar(ByVal paroModuloMovDetActual As Modulos.GrupoModuloMovDetalle, ByVal paroCliente As Cliente, ByVal parsVisitaClave As String) As Boolean

                        Interface FormasFacturacion
                            Function Mostrar(ByVal paroModuloMovDetActual As Modulos.GrupoModuloMovDetalle, ByVal paroCliente As Cliente, ByVal parsVisitaClave As String) As Boolean
                            Function MostrarDetalle(ByVal paroCliente As Cliente, ByVal parsVisitaClave As String, ByVal parFacturaID As String, ByVal parModo As FormFacturaDetalle.Modo, ByVal parGrupo As Modulos.GrupoModuloMovDetalle, ByVal parTransProdID As String, Optional ByVal parFecha As String = "", Optional ByVal parTotal As Double = 0) As Boolean
                        End Interface

                        Interface FormasCuentasxCobrar
                            Function Mostrar(ByVal paroModuloMovDetActual As Modulos.GrupoModuloMovDetalle, ByVal paroCliente As Cliente, ByVal parsVisitaClave As String) As Boolean
                        End Interface

                        Interface FormasPagosProgramados
                            Function Mostrar(ByVal paroModuloMovDetActual As Modulos.GrupoModuloMovDetalle, ByVal paroCliente As Cliente, ByVal parsVisitaClave As String) As Boolean
                        End Interface

                        Interface FormasCambios
                            Function Capturar(ByVal paroModuloMovDetActual As Modulos.GrupoModuloMovDetalle, ByVal paroCliente As Cliente, ByVal parsVisitaClave As String) As Boolean
                        End Interface

                        Interface FormasDevolucionesCliente
                            Function Capturar(ByVal paroModuloMovDetActual As Modulos.GrupoModuloMovDetalle, ByVal paroCliente As Cliente, ByVal parsVisitaClave As String) As Boolean
                        End Interface

                        Interface FormasPrestamos
                            Function Capturar(ByVal paroModuloMovDetActual As Modulos.GrupoModuloMovDetalle, ByVal paroCliente As Cliente, ByVal parsVisitaClave As String) As Boolean
                        End Interface

                        Interface FormasDevolucionesPrestamos
                            Function Capturar(ByVal paroModuloMovDetActual As Modulos.GrupoModuloMovDetalle, ByVal paroCliente As Cliente, ByVal parsVisitaClave As String) As Boolean
                        End Interface

                        Interface FormasSurtirPromocion
                            Function Capturar(ByVal paroModuloMovDetActual As Modulos.GrupoModuloMovDetalle, ByVal paroCliente As Cliente, ByVal parsVisitaClave As String) As Boolean
                        End Interface
                    End Interface

                    Interface Improductivo
                        Function Capturar(ByVal paroCliente As Cliente, ByVal parsVisitaClave As String) As Boolean

                    End Interface

                    Interface Solicitudes
                        Function Capturar(ByVal paroCliente As Cliente, ByVal parsVisitaClave As String) As Boolean

                    End Interface

                    Interface HistoricoVentas
                        Function Capturar(ByVal paroCliente As Cliente, ByVal parsVisitaClave As String) As Boolean
                    End Interface

                    Interface Canjes
                        Function Capturar(ByVal paroCliente As Cliente) As Boolean
                    End Interface

                    Interface Mercadeo
                        Function Capturar(ByVal paroCliente As Cliente, ByVal parsVisita As String) As Boolean
                    End Interface

                    Interface Mensajes
                        Function Capturar(ByVal paroCliente As Cliente, ByVal parsVisitaClave As String, ByVal parsFolio As String) As Boolean

                    End Interface

                    Interface Activos
                        Function Capturar(ByVal paroCliente As Cliente, ByVal parsVisitaClave As String) As Boolean

                    End Interface

                End Interface

                Interface FormasPago
                    Function Capturar(ByVal paroCliente As Cliente, ByVal parsVisitaClave As String) As Boolean

                End Interface

                Interface Resumen
                    Function ObtenerTotales(ByVal paroCliente As Cliente, ByVal parsVisitaClave As String) As Boolean
                    Function Mostrar() As Boolean

                End Interface

                Interface Impresion
                    Function ImprimirConVisita(ByVal paroCliente As Cliente, ByVal parsVisitaClave As String) As Boolean

                End Interface

                Interface Encuestas
                    Function Encuestar(ByVal paroCliente As Cliente, ByVal parsVisitaClave As String) As Boolean
                End Interface
            End Interface

        End Interface

        Interface Devoluciones
            Function Capturar() As Boolean

        End Interface

        Interface CargasDescargas
            Function Capturar(ByVal paroModuloMovDetActual As Modulos.GrupoModuloMovDetalle) As Boolean
        End Interface

        Interface Gastos
            Function Capturar() As Boolean

        End Interface

        Interface CierreDiario
            Function VerificarInventario() As Boolean
            Function CerrarDia() As Boolean

        End Interface

        Interface Comunicacion
            Function Transmitir() As Boolean

        End Interface

        Interface Depositos
            Function Capturar() As Boolean

        End Interface

        Interface Kardex
            Function Capturar(ByVal odia As MobileClient.Dia) As Boolean

        End Interface

        Interface Ajustes
            Function Capturar() As Boolean
        End Interface

        Interface Impresion
            Function ImprimirSinVisita() As Boolean
        End Interface

        Interface Reportes
            Function Capturar(ByVal odia As MobileClient.Dia) As Boolean
        End Interface

    End Interface

End Interface

