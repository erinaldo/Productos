Imports System.Data.SqlServerCe


Public Class Agenda
    Implements ERM.Dia.Agenda

    Protected oRuta As Ruta
    Protected oCliente As Cliente
    Protected bCodigoLeido As Boolean
    Protected bFueraFrecuencia As Boolean
    Protected bGPSLeido As Boolean
    Protected nDistanciaGPS As Decimal

    Public Property ClienteActual() As Cliente Implements ERM.Dia.Agenda.ClienteActual
        Get
            Return oCliente
        End Get
        Set(ByVal Value As Cliente)
            oCliente = Value
        End Set
    End Property

    Public Property RutaActual() As Ruta Implements ERM.Dia.Agenda.RutaActual
        Get
            Return oRuta
        End Get
        Set(ByVal Value As Ruta)
            oRuta = Value
        End Set
    End Property

    Public Property CodigoLeido() As Boolean
        Get
            Return bCodigoLeido
        End Get
        Set(ByVal value As Boolean)
            bCodigoLeido = value
        End Set
    End Property
    Public Property FueraFrecuencia() As Boolean
        Get
            Return bFueraFrecuencia
        End Get
        Set(ByVal value As Boolean)
            bFueraFrecuencia = value
        End Set
    End Property
    Public Property GPSLeido() As Boolean
        Get
            Return bGPSLeido
        End Get
        Set(ByVal value As Boolean)
            bGPSLeido = value
        End Set
    End Property
    Public Property DistanciaGPS() As Decimal
        Get
            Return nDistanciaGPS
        End Get
        Set(ByVal value As Decimal)
            nDistanciaGPS = value
        End Set
    End Property

    Public Function MostrarRutas() As Boolean Implements ERM.Dia.Agenda.MostrarRutas
        Dim oFormRutas As New FormRutas
        Try
            If Not Me.RutaActual Is Nothing Then
                oFormRutas.RutaActual = Me.RutaActual
            End If
            If oFormRutas.ShowDialog() = DialogResult.OK Then
                Me.RutaActual = oFormRutas.RutaActual
                With oFormRutas
                    .Dispose()
                    oFormRutas = Nothing
                End With
                Return True
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        With oFormRutas
            .Dispose()
            oFormRutas = Nothing
        End With
        Return False
    End Function

    Public Function MostrarClientes() As Boolean Implements ERM.Dia.Agenda.MostrarClientes
        Dim oFormClientes As New FormClientes
        Try
            If Not Me.ClienteActual Is Nothing Then
                oFormClientes.ClienteActual = Me.ClienteActual
                '19-Jul-06 Codigo para saber el cliente en las listas de precios
                CTEActual = Me.ClienteActual.ClienteClave
            End If
            If Not Me.RutaActual Is Nothing Then
                oFormClientes.RutaActual = Me.RutaActual
            End If
            If oFormClientes.ShowDialog() = DialogResult.OK Then
                Application.DoEvents()
                oFormClientes.DesconectarGps()
                Me.CodigoLeido = oFormClientes.bCodigoLeido
                Me.ClienteActual = oFormClientes.ClienteActual
                Me.FueraFrecuencia = oFormClientes.FueraFrecuencia
                Me.GPSLeido = oFormClientes.bGPSLeido
                Me.DistanciaGPS = oFormClientes.nDistanciaGPS
                '19-Jul-06 Codigo para saber el cliente en las listas de precios
                CTEActual = Me.ClienteActual.ClienteClave
                With oFormClientes
                    .Dispose()
                    oFormClientes = Nothing
                End With
                Return True
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        With oFormClientes
            .Dispose()
            oFormClientes = Nothing
        End With
        Return False
    End Function

    'Se usa la FechaCaptura del día porque en los cálculos que se hacen en el escritorio solo se tiene esa fecha para calcular si es o no el cumpleaños, no se tiene la fecha de la terminal
    Public Function Cumpleaños(ByVal parsVistaClaveActual As String) As Boolean
        Dim DataTable As DataTable = oDBVen.RealizarConsultaSQL("Select Cumpleaños from agenda where DiaClave='" & oDia.DiaActual & "' and VendedorID='" & oVendedor.VendedorId & "' and RUTClave ='" & Me.RutaActual.RUTClave & "' and ClienteClave='" & Me.ClienteActual.ClienteClave & "'", "TransProd")
        If DataTable.Rows.Count > 0 Then
            If DataTable.Rows(0)("cumpleaños") = True Then
                Dim dtUltVisita As DataTable = oDBVen.RealizarConsultaSQL("select FechaHoraFinal from visita where ClienteClave ='" & Me.ClienteActual.ClienteClave & "' AND VisitaClave <>'" & parsVistaClaveActual & "' order by FechaHoraFinal desc ", "UltVisita")
                If dtUltVisita.Rows.Count > 0 Then
                    Dim dFechaNacimiento As Date = DateSerial(oDia.FechaCaptura.Year, Me.ClienteActual.FechaNacimiento.Month, Me.ClienteActual.FechaNacimiento.Day)
                    If (dtUltVisita.Rows(0)("FechaHoraFinal") < dFechaNacimiento) And (PrimeraHora(oDia.FechaCaptura) >= dFechaNacimiento) Then
                        DataTable.Dispose()
                        dtUltVisita.Dispose()
                        Return True
                    End If
                Else 'Si no hay visitas a ese cliente y se indica que es su cumpleaños ese dia se felicita....
                    DataTable.Dispose()
                    dtUltVisita.Dispose()
                    Return True
                End If
            Else
                If Format(Me.ClienteActual.FechaNacimiento, "dd/MM") = Format(oDia.FechaCaptura, "dd/MM") Then
                    DataTable.Dispose()
                    Return True
                End If
            End If
        End If
        DataTable.Dispose()
        Return False
    End Function
End Class
