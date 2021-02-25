Imports System.Data.SqlServerCe

Public Class Visita
    Implements ERM.Dia.Agenda.Visita

    Protected sVisitaClave As String
    Protected sDiaClave As String
    Protected sRutClave As String
    Protected oCliente As Cliente
    Protected dFechaHoraInicial As Date
    Protected dFechaHoraFinal As Date
    Protected iNumero As Integer
    Protected bCodigoLeido As Boolean
    Protected bFueraFrecuencia As Boolean
    Protected bNueva As Boolean
    Protected tTipoEstado As ServicesCentral.TiposEstadosRegistros
    Protected bGPSLeido As Boolean
    Protected nDistanciaGPS As Decimal


    Public Property VisitaClave() As String Implements ERM.Dia.Agenda.Visita.VisitaClave
        Get
            Return sVisitaClave
        End Get
        Set(ByVal Value As String)
            sVisitaClave = Value
        End Set
    End Property
    Public Property DiaClave() As String Implements ERM.Dia.Agenda.Visita.DiaClave
        Get
            Return sDiaClave
        End Get
        Set(ByVal Value As String)
            sDiaClave = Value
        End Set
    End Property
    Public Property FechaHoraInicial() As Date
        Get
            Return dFechaHoraInicial
        End Get
        Set(ByVal Value As Date)
            dFechaHoraInicial = Value
        End Set
    End Property
    Public Property FechaHoraFinal() As Date
        Get
            Return dFechaHoraFinal
        End Get
        Set(ByVal Value As Date)
            dFechaHoraFinal = Value
        End Set
    End Property
    Public Property Numero() As Integer
        Get
            Return iNumero
        End Get
        Set(ByVal Value As Integer)
            iNumero = Value
        End Set
    End Property

    Public Property RutClave() As String
        Get
            Return sRutClave
        End Get
        Set(ByVal Value As String)
            sRutClave = Value
        End Set
    End Property

    Public Property TipoEstado() As ServicesCentral.TiposEstadosRegistros
        Get
            Return tTipoEstado
        End Get
        Set(ByVal Value As ServicesCentral.TiposEstadosRegistros)
            tTipoEstado = Value
        End Set
    End Property

    Public Property ClienteActual() As Cliente
        Get
            Return oCliente
        End Get
        Set(ByVal Value As Cliente)
            oCliente = Value
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

    Public Property Nueva() As Boolean
        Get
            Return bNueva
        End Get
        Set(ByVal value As Boolean)
            bNueva = value
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

    Private Function Guardar() As Boolean
        Dim sComandoSQL As New System.Text.StringBuilder
        Dim DataTableVisitas As DataTable
        Try
            DataTableVisitas = oDBVen.RealizarConsultaSQL("SELECT VisitaClave FROM Visita WHERE VisitaClave='" & Me.VisitaClave & "' AND DiaClave='" & oDia.DiaActual & "'", "Visita")
            If DataTableVisitas.Rows.Count = 0 Then
                If oDia.DiaActual = "" Or Me.ClienteActual.ClienteClave = "" Or Me.RutClave = "" Then
                    MsgBox("Error al crear la visita")
                    Return False
                End If
                ' Agregar la visita
                sComandoSQL.Append("INSERT INTO Visita (VisitaClave,DiaClave,Numero,ClienteClave,VendedorId,RUTClave,FechaHoraInicial,FechaHoraFinal,TipoEstado,FueraFrecuencia,CodigoLeido,GPSLeido,DistanciaGPS,MFechaHora,MUsuarioID) VALUES (")
                sComandoSQL.Append("'" & Me.VisitaClave & "',")
                sComandoSQL.Append("'" & oDia.DiaActual & "',")
                sComandoSQL.Append(Me.Numero & ",")
                sComandoSQL.Append("'" & Me.ClienteActual.ClienteClave & "',")
                sComandoSQL.Append("'" & oVendedor.VendedorId & "',")
                sComandoSQL.Append("'" & Me.RutClave & "',")
                sComandoSQL.Append(UniFechaSQL(Me.FechaHoraInicial) & ",")
                sComandoSQL.Append(UniFechaSQL(Me.FechaHoraFinal) & ",")
                sComandoSQL.Append(Me.TipoEstado & ",")
                sComandoSQL.Append(IIf(Me.FueraFrecuencia, 1, 0) & ",")
                sComandoSQL.Append(IIf(Me.CodigoLeido, 1, 0) & ",")
                sComandoSQL.Append(IIf(Me.GPSLeido, 1, 0) & ",")
                sComandoSQL.Append(IIf(Me.GPSLeido And Me.DistanciaGPS <> 0, Me.DistanciaGPS, "NULL") & ",")
                sComandoSQL.Append(UniFechaSQL(Now) & ",")
                sComandoSQL.Append("'" & oVendedor.UsuarioId & "')")
                Me.Nueva = True
            Else
                ' Actualizar la fecha/hora de modificacion de la visita
                sComandoSQL.Append("UPDATE Visita SET ")
                sComandoSQL.Append("FechaHoraFinal=" & UniFechaSQL(Me.FechaHoraFinal) & ", ")
                sComandoSQL.Append("MFechaHora=" & UniFechaSQL(Now) & ", ")
                sComandoSQL.Append("MUsuarioID='" & oVendedor.UsuarioId & "', ")
                sComandoSQL.Append("Enviado=0 ")
                sComandoSQL.Append("WHERE VisitaClave='" & Me.VisitaClave & "'")

                Me.Nueva = False
            End If
            DataTableVisitas.Dispose()
            Return oDBVen.EjecutarComandoSQL(sComandoSQL.ToString) <> 0
        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message & ": " & sComandoSQL.ToString, MsgBoxStyle.Critical, "GuardarVisita")
        Catch ExcB As Exception
            MsgBox(ExcB.Message & ": " & sComandoSQL.ToString, MsgBoxStyle.Critical, "GuardarVisita")
        End Try
        Return False
    End Function

    'Public Function Recuperar() As Boolean
    '    Dim sComandoSQL As New System.Text.StringBuilder
    '    Dim DataTableVisitas As DataTable
    '    Try
    '        DataTableVisitas = odbVen.RealizarConsultaSQL("SELECT * FROM Visita WHERE VisitaClave='" & Me.VisitaClave & "' AND DiaClave='" & oDia.DiaActual & "'", "Visita")
    '        If DataTableVisitas.Rows.Count > 0 Then
    '            Me.FechaHoraInicial = DataTableVisitas.Rows(0)("FechaHoraInicial")
    '            Me.FechaHoraFinal = DataTableVisitas.Rows(0)("FechaHoraFinal")
    '            Me.Numero = DataTableVisitas.Rows(0)("Numero")
    '            Me.TipoEstado = DataTableVisitas.Rows(0)("TipoEstado")
    '            Me.RutClave = DataTableVisitas.Rows(0)("RUTClave")
    '            Me.CodigoLeido = DataTableVisitas.Rows(0)("CodigoLeido")
    '            Me.FueraFrecuencia = DataTableVisitas.Rows(0)("FueraFrecuencia")
    '            'Me.ClienteActual = DataTableVisitas.Rows(0)("ClienteClave")
    '            Me.Nueva = False
    '        End If
    '        DataTableVisitas.Dispose()
    '        Return True
    '    Catch ExcA As SqlCeException
    '        MsgBox(ExcA.Message & ": " & sComandoSQL.ToString, MsgBoxStyle.Critical, "GuardarVisita")
    '    Catch ExcB As Exception
    '        MsgBox(ExcB.Message & ": " & sComandoSQL.ToString, MsgBoxStyle.Critical, "GuardarVisita")
    '    End Try
    '    Return False
    'End Function

    Private Function ExistenVisitas() As Boolean
        Dim iCount As Integer = oDBVen.EjecutarCmdScalarIntSQL("SELECT count(*) FROM Visita WHERE DiaClave='" & oDia.DiaActual & "' AND ClienteClave='" & Me.ClienteActual.ClienteClave & "' AND (Enviado=0 or Enviado is null ) ")
        Return (iCount <> 0)
    End Function

    Public Function MostrarVisitas(ByVal paroClienteActual As Cliente, ByVal pvRutClave As String, ByVal pvCodigoLeido As Boolean, ByVal pvFueraFrecuencia As Boolean, ByVal pvGPSLeido As Boolean, ByVal pvDistanciaGPS As Decimal) As Boolean Implements ERM.Dia.Agenda.Visita.MostrarVisitas
        Try
            Me.ClienteActual = paroClienteActual
            If Not Me.ExistenVisitas() Then
                ' Nueva visita
                If Me.BuscarProximoFolio() Then
                    oDBVen.EjecutarComandoSQL("UPDATE Agenda SET Visitado=" & Cliente.TiposEstadosClientes.ClienteVisitado & " WHERE ClienteClave='" & paroClienteActual.ClienteClave & "' and DiaClave='" & oDia.DiaActual & "' and RUTClave='" & oAgenda.RutaActual.RUTClave & "'")
                    Me.FechaHoraInicial = Now
                    Me.FechaHoraFinal = Now
                    Me.RutClave = pvRutClave
                    Me.TipoEstado = ServicesCentral.TiposEstadosRegistros.Activo
                    Me.CodigoLeido = pvCodigoLeido
                    Me.FueraFrecuencia = pvFueraFrecuencia
                    Me.GPSLeido = pvGPSLeido
                    Me.DistanciaGPS = pvDistanciaGPS
                    Return Me.Guardar()
                End If
            Else
                Dim oFormVisitas As New FormVisitas
                oFormVisitas.Cliente = Me.ClienteActual
                Dim oDialogResult As DialogResult
                oDialogResult = oFormVisitas.ShowDialog()
                Select Case oDialogResult
                    Case DialogResult.OK
                        ' Modificar visita
                        Me.VisitaClave = oFormVisitas.VisitaClave
                        Me.DiaClave = oDia.DiaActual
                        Me.RutClave = pvRutClave
                        Me.FechaHoraFinal = Now
                        Me.CodigoLeido = pvCodigoLeido
                        Me.FueraFrecuencia = pvFueraFrecuencia
                        Me.GPSLeido = pvGPSLeido
                        Me.DistanciaGPS = pvDistanciaGPS
                        With oFormVisitas
                            .Dispose()
                            oFormVisitas = Nothing
                        End With
                        Return Me.Guardar()
                    Case DialogResult.Cancel
                        With oFormVisitas
                            .Dispose()
                            oFormVisitas = Nothing
                        End With
                    Case DialogResult.Ignore
                        ' Nueva visita
                        If Me.BuscarProximoFolio() Then
                            Me.FechaHoraInicial = Now
                            Me.FechaHoraFinal = Now
                            Me.RutClave = pvRutClave
                            Me.TipoEstado = ServicesCentral.TiposEstadosRegistros.Activo
                            Me.CodigoLeido = pvCodigoLeido
                            Me.FueraFrecuencia = pvFueraFrecuencia
                            Me.GPSLeido = pvGPSLeido
                            Me.DistanciaGPS = pvDistanciaGPS
                            With oFormVisitas
                                .Dispose()
                                oFormVisitas = Nothing
                            End With
                            Return Me.Guardar()
                        End If
                    Case DialogResult.Abort
                        '' Cancelar visita
                        'Me.VisitaClave = oFormVisitas.VisitaClave
                        'Me.DiaClave = oDia.DiaActual
                        'Me.Cancelar()
                End Select
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        Return False
    End Function

    Private Function BuscarProximoFolio() As Boolean
        Me.VisitaClave = ""
        Me.Numero = 1
        Try
            Dim DataTableFolios As DataTable = odbVen.RealizarConsultaSQL("SELECT MAX(Numero) AS ""UltimaVisita"" FROM Visita WHERE DiaClave='" & oDia.DiaActual & "'", "FolioVisita")
            If DataTableFolios.Rows.Count = 1 Then
                Dim refDataRow As DataRow = DataTableFolios.Rows(0)
                If Not refDataRow.IsNull("UltimaVisita") Then
                    Me.Numero = refDataRow("UltimaVisita") + 1
                End If
            End If
            Me.VisitaClave = oApp.KEYGEN(1)
            DataTableFolios.Dispose()
            Return True
        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message, MsgBoxStyle.Critical, "BuscarProximoFolio")
        Catch ExcB As Exception
            MsgBox(ExcB.Message, MsgBoxStyle.Critical, "BuscarProximoFolio")
        End Try
        Return False
    End Function

    Private Shared Function HayVisitas() As Boolean
        Dim i As Integer = odbVen.EjecutarCmdScalarIntSQL("Select count(*) as total from Visita WHERE DiaClave='" & oDia.DiaActual & "'")

        If i > 0 Then
            Return True
        End If

        Return False
    End Function


End Class
