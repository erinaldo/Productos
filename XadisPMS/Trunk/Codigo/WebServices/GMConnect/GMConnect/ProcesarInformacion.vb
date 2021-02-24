Imports System.IO
Imports GMConnect.GMConnect

Module ProcesarInformacion

    Dim conexionSQL As LbConexionSQL.ConexionSQL


    Sub Main(args As String())

        Dim dirBitacora As String = System.IO.Directory.GetCurrentDirectory()
        dirBitacora = System.IO.Path.Combine(dirBitacora, "GMBitacora")
        My.Computer.FileSystem.CreateDirectory(dirBitacora)

        Dim oBitacoraLog As BitacoraLog = New BitacoraLog(dirBitacora, "GMLog" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt", "Inicio procesamiento: " & DateTime.Now.ToString("yyyyMMddHHmmss"))

        If (args.Length <= 0) Then
            oBitacoraLog.EscribirEnBitacora("Debe ingresar la fecha del día de trabajo a procesar.")
            Exit Sub
        End If

        Dim fechaProcesamiento As DateTime
        Try
            Dim sfecha As String = args(0)

            Dim pattern As String = "yyyyMMdd"

            If Not DateTime.TryParseExact(sfecha, pattern, Nothing,
                                          Globalization.DateTimeStyles.None, fechaProcesamiento) Then
                oBitacoraLog.EscribirEnBitacora("Obteniendo parámetro de fecha: Formato incorrecto, se espera 'yyyyMMdd'")
                Exit Sub
            End If
        Catch ex As Exception
            oBitacoraLog.EscribirEnBitacora("Obteniendo parámetro de fecha:" & ex.Message)
            Exit Sub
        End Try

        Dim bPrueba As Boolean = False
        If (args.Length > 1) Then
            bPrueba = args(1)
        End If

        Dim cadenaConexion As String = LeerConfiguracion("ConexionSQL")
        If (IsNothing(cadenaConexion)) Then
            oBitacoraLog.EscribirEnBitacora("Conectar BD: No se pudo obtener la cadena de conexion")
            Exit Sub
        End If

        Dim timeout As Integer = 5000
        Dim sTimeout As String = LeerConfiguracion("TimeOut")
        If (Not IsNothing(sTimeout)) Then
            timeout = sTimeout
        End If

        Try
            conexionSQL = New LbConexionSQL.ConexionSQL(cadenaConexion)
        Catch ex As Exception
            oBitacoraLog.EscribirEnBitacora("Conectar BD: " & ex.Message)
            Exit Sub
        End Try

        Try
            'Para Alteña
            ' Dim status As String = conexionSQL.EjecutarComandoScalar("Select Status from RouteADM.dbo.StatusDia where Fecha = '" & fechaProcesamiento.ToString("yyyyMMdd") & "' ")
            'Para Modelo de Oriente
            'Dim status As String = conexionSQL.EjecutarComandoScalar("Select Status from RouteADM.dbo.StatusDia where Fecha = '" & fechaProcesamiento.ToString("yyyyMMdd") & "' and IdCedis=3 ")

            'If status <> "C" Then
            'oBitacoraLog.EscribirEnBitacora("El día debe estar cerrado para ser procesado")
            'Exit Sub
            'End If

            Dim registros As Short = conexionSQL.EjecutarComandoScalar("Select count(*) as Num from tmp_ProcesamientoDia where DiaClave= '" & fechaProcesamiento.ToString("dd/MM/yyyy") & "' ")
            If registros > 0 Then
                oBitacoraLog.EscribirEnBitacora("El día ya fué procesado")
                Exit Sub
            End If

        Catch ex As Exception
            oBitacoraLog.EscribirEnBitacora("Verificar dia: " & ex.Message)
            Exit Sub
        End Try

        Dim sXadis = New wsXadisPMS.WspmsServiceClient
        Dim numSesion As String
        Dim sUsuario As String
        Dim sPassword As String
        Dim sAlmacen As String
        'Obtener datos de Sesion
        Try
            Dim dtLogueo As DataTable = conexionSQL.EjecutarConsulta("Select * from ConfigParametro where Parametro in ('GMUsuario', 'GMPassword', 'GMAlmacen') ")

            If (Not IsNothing(dtLogueo) AndAlso dtLogueo.Rows.Count > 0) Then
                sUsuario = dtLogueo.Select("Parametro = 'GMUsuario'")(0)("Valor")
                sPassword = dtLogueo.Select("Parametro = 'GMPassword'")(0)("Valor")
                sAlmacen = dtLogueo.Select("Parametro = 'GMAlmacen'")(0)("Valor")
            End If

            Dim login As wsXadisPMS.login = sXadis.getLogin(sUsuario, sPassword, vbNull, sAlmacen)

            If Not IsNothing(login) Then
                If (login.error) Then
                    numSesion = login.mensaje
                Else
                    oBitacoraLog.EscribirEnBitacora("Inicio Sesion:" & login.mensaje)
                    Exit Sub
                End If
            Else
                oBitacoraLog.EscribirEnBitacora("Inicio Sesion:" & "El servicio no responde")
                Exit Sub
            End If
        Catch ex As Exception
            oBitacoraLog.EscribirEnBitacora("Inicio Sesion:" & ex.Message)
            Exit Sub
        End Try
        Dim sEnvio As String = ""
        Try
            'Procesar las ventas
            Dim dtVentas As DataTable = conexionSQL.EjecutarConsulta("exec [sp_ObtenerVentasGM] '" & fechaProcesamiento.ToString("yyyyMMdd") & "'", True, timeout)
            oBitacoraLog.EscribirEnBitacora("Procesamiento Ventas: #Registros:" & dtVentas.Rows.Count())

            For Each dr As DataRow In dtVentas.Rows
                Dim periodo As Date = dr("FechaMovimiento")
                sEnvio = ""
                Try
                    sEnvio = "Sesion: " & numSesion & " Almacen:" & sAlmacen & " CodigoSKU" & dr("CodigoSKU") & " VentaCantidad:" & dr("VentaCantidad").ToString & " Unidad:" & dr("Unidad").ToString _
                         & " Cliente: " & dr("Cliente") & " CanalCliente: " & dr("CanalCliente") & " PrecioUnitario:" & dr("PrecioUnitario").ToString & " DescuentoPorcentaje:" & dr("DescuentoPorcentaje").ToString & " DescuentoMonto: " & dr("DescuentoMonto").ToString & " PrecioNeto:" & dr("PrecioNeto").ToString _
                         & " IEPS: " & dr("IEPS").ToString & " PrecioBruto:" & dr("PrecioBruto").ToString & "IVA: " & dr("IVA") & " PrecioFinal: " & dr("PrecioFinal") & " NumeroDocumento:" & dr("NumeroDocumento") & " TipoMovimiento:" & IIf(bPrueba, 9, dr("TipoMov"))

                Catch ex As Exception
                    oBitacoraLog.EscribirEnBitacora("CadenaEnvio:" & ex.Message)
                End Try
 

                Dim ventas As wsXadisPMS.ventas = sXadis.setVentas(numSesion, Now, sAlmacen, dr("CodigoSKU"), dr("VentaCantidad"), dr("Unidad"), periodo.ToString("yyyyMMdd"), _
                                                                   dr("Cliente"), dr("CanalCliente"), dr("PrecioUnitario"), dr("DescuentoPorcentaje"), dr("DescuentoMonto"), dr("PrecioNeto"), _
                                                                   dr("IEPS"), dr("PrecioBruto"), dr("IVA"), dr("PrecioFinal"), dr("NumeroDocumento"), IIf(bPrueba, 9, dr("TipoMov")))


                If Not IsNothing(ventas) Then
                    If (Not ventas.error) Then
                        oBitacoraLog.EscribirEnBitacora("Procesamiento Ventas:" & "Documento:" & dr("NumeroDocumento") & " Producto:" & dr("CodigoSKU") & ventas.mensaje)
                        Exit Sub
                    End If
                Else
                    oBitacoraLog.EscribirEnBitacora("Procesamiento Ventas:" & "El servicio no responde")
                    Exit Sub
                End If

            Next
        Catch ex As Exception
            oBitacoraLog.EscribirEnBitacora("Procesamiento Ventas Error: " & sEnvio)
            oBitacoraLog.EscribirEnBitacora("Procesamiento Ventas:" & ex.Message)
            Exit Sub
        End Try

        Try
            'Procesar el Inventario 
            Dim dtInventario As DataTable = conexionSQL.EjecutarConsulta("exec [sp_ObtenerInventarioGM] '" & fechaProcesamiento.ToString("yyyyMMdd") & "'", True, timeout)
            oBitacoraLog.EscribirEnBitacora("Procesamiento Inventario: #Registros:" & dtInventario.Rows.Count())

            For Each dr As DataRow In dtInventario.Rows
                Dim periodo As Date = dr("FechaMovimiento")
                Dim inventario As wsXadisPMS.inventario = sXadis.setInventario(numSesion, sAlmacen, Now, dr("CodigoSKU"), dr("Inventario"), dr("Unidad"), periodo.ToString("yyyyMMdd"), _
                                                                   IIf(bPrueba, 9, dr("TipoMovimiento")))

                If Not IsNothing(inventario) Then
                    If (Not inventario.error) Then
                        oBitacoraLog.EscribirEnBitacora("Procesamiento Inventario:" & " Producto:" & dr("CodigoSKU") & inventario.mensaje)
                        Exit Sub
                    End If
                Else
                    oBitacoraLog.EscribirEnBitacora("Procesamiento Inventario:" & "El servicio no responde")
                    Exit Sub
                End If

            Next
        Catch ex As Exception
            oBitacoraLog.EscribirEnBitacora("fin Con Inventario " & DateTime.Now.ToString("yyyyMMddHHmmss"))
            oBitacoraLog.EscribirEnBitacora("Procesamiento Inventario:" & ex.Message)
            Exit Sub
        End Try

        Try
            conexionSQL.EjecutarComando("Insert into tmp_ProcesamientoDia (DiaClave, FechaProcesamiento) VALUES('" & fechaProcesamiento.ToString("dd/MM/yyyy") & "', getdate()) ")
            conexionSQL.ConfirmarTran()

        Catch ex As Exception
            oBitacoraLog.EscribirEnBitacora("Marcar dia: " & ex.Message)
            Exit Sub
        End Try

        oBitacoraLog.EscribirEnBitacora("Fin Procesamiento: " & DateTime.Now.ToString("yyyyMMddHHmmss"))

    End Sub


    Public Function LeerConfiguracion(ByVal pvParametro As String) As String
        Dim vlLineData As String = ""
        Dim vlSR As StreamReader

        Try
            vlSR = New StreamReader("AplBase.ini")
        Catch ex As Exception
            Return Nothing
        End Try

        Do
            If vlLineData = "[" + pvParametro + "]" Then
                vlLineData = vlSR.ReadLine()
                vlSR.Close()
                Return vlLineData
            End If
            vlLineData = vlSR.ReadLine()
        Loop Until vlLineData Is Nothing
        vlSR.Close()
        Return Nothing
    End Function

End Module
