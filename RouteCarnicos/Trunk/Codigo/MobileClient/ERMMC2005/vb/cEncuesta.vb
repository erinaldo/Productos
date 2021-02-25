Public Class cEncuesta
    Implements IDisposable

    Public Enum EstadoEncuesta
        Nueva = 1
        Recuperada
    End Enum

    Public Enum EstadoFinalizar
        Cancelada = 0
        Aplicada
        ParcialmenteAplicada
    End Enum

#Region "Variables"
    Private sENCId As String
    Private sCENClave As String
    Private sVisitaClave As String
    Private sClienteClave As String
    Private sDiaClave As String
    Private nFase As Integer
    Private dFecha As DateTime
    Private aIcono As Byte()
    Private bHabilitarSalir As Boolean
    Private dHoraInicio As DateTime
    Private dHoraFin As DateTime
    Private oCOLPreguntas As cCOLPreguntas
    Private bEncuestaTerminada As Boolean
    Private tEstadoIni As EstadoFinalizar
    Private tEstadoEnc As EstadoEncuesta
    Private tEstadoFin As EstadoFinalizar
    Private nCENPuntos As Integer
    Private nCECPuntos As Integer
    Private oConPreg As cConsultaPreguntas

    'Private hENPId As Hashtable
    'Private nOrdenPregActual As Integer
#End Region

#Region "Propiedades"

    Public Property ENCId() As String
        Get
            Return sENCId
        End Get
        Set(ByVal Value As String)
            sENCId = Value
        End Set
    End Property
    Public Property CENClave() As String
        Get
            Return sCENClave
        End Get
        Set(ByVal Value As String)
            sCENClave = Value
        End Set
    End Property
    Public Property VisitaClave() As String
        Get
            Return sVisitaClave
        End Get
        Set(ByVal Value As String)
            sVisitaClave = Value
        End Set
    End Property
    Public Property DiaClave() As String
        Get
            Return sDiaClave
        End Get
        Set(ByVal Value As String)
            sDiaClave = Value
        End Set
    End Property
    Public Property Fase() As Integer
        Get
            Return nFase
        End Get
        Set(ByVal Value As Integer)
            nFase = Value
        End Set
    End Property
    Public Property Fecha() As DateTime
        Get
            Return dFecha
        End Get
        Set(ByVal Value As DateTime)
            dFecha = Value
        End Set
    End Property
    Public Property Icono() As Byte()
        Get
            Return aIcono
        End Get
        Set(ByVal Value As Byte())
            aIcono = Value
        End Set
    End Property
    Public Property HabilitarSalir() As Boolean
        Get
            Return bHabilitarSalir
        End Get
        Set(ByVal value As Boolean)
            bHabilitarSalir = value
        End Set
    End Property
    Public Property HoraInicio() As DateTime
        Get
            Return dHoraInicio
        End Get
        Set(ByVal Value As DateTime)
            dHoraInicio = Value
        End Set
    End Property
    Public Property HoraFin() As DateTime
        Get
            Return dHoraFin
        End Get
        Set(ByVal Value As DateTime)
            dHoraFin = Value
        End Set
    End Property
    Public Property EstadoEnc() As EstadoEncuesta
        Get
            Return tEstadoEnc
        End Get
        Set(ByVal Value As EstadoEncuesta)
            tEstadoEnc = Value
        End Set
    End Property
    Public Property EstadoIni() As EstadoFinalizar
        Get
            Return tEstadoIni
        End Get
        Set(ByVal Value As EstadoFinalizar)
            tEstadoIni = Value
        End Set
    End Property
    Public Property EstadoFin() As EstadoFinalizar
        Get
            Return tEstadoFin
        End Get
        Set(ByVal Value As EstadoFinalizar)
            tEstadoFin = Value
        End Set
    End Property
    Public ReadOnly Property Preguntas() As cCOLPreguntas
        Get
            Return oCOLPreguntas
        End Get
    End Property
    Public Property CENPuntos() As Integer
        Get
            Return nCENPuntos
        End Get
        Set(ByVal Value As Integer)
            nCENPuntos = Value
        End Set
    End Property
    Public Property CECPuntos() As Integer
        Get
            Return nCECPuntos
        End Get
        Set(ByVal Value As Integer)
            nCECPuntos = Value
        End Set
    End Property
    'Public Property OrdenPregActual() As Integer
    '    Get
    '        Return nOrdenPregActual
    '    End Get
    '    Set(ByVal value As Integer)
    '        nOrdenPregActual = value
    '    End Set
    'End Property
#End Region

#Region "Funciones"
    Public Sub New(ByVal pvCENClave As String, ByVal pvCENPuntos As Integer, ByVal pvCECPuntos As Integer, ByVal pvVisitaCliente As String, ByVal pvClienteClave As String, ByVal pvEstadoIni As EstadoFinalizar, ByVal pvHabilitarSalir As Boolean, Optional ByVal _encId As String = "", Optional ByVal nueva As Boolean = False)
        Me.CENClave = pvCENClave
        Me.VisitaClave = pvVisitaCliente
        Me.DiaClave = oDia.DiaActual
        Me.Fecha = PrimeraHora(Now)
        Me.HoraInicio = Now
        Me.CENPuntos = pvCENPuntos
        Me.CECPuntos = pvCECPuntos
        Me.HabilitarSalir = pvHabilitarSalir
        RecuperaIcono()
        Me.ENCId = _encId
        Me.RecuperaENCId()
        If (nueva) Then
            Me.ENCId = ""
            Me.EstadoEnc = cEncuesta.EstadoEncuesta.Nueva
            'Me.Fase = cEncuesta.EstadoFinalizar.ParcialmenteAplicada
        End If
        Me.RecuperaPreguntas()
        Me.EstadoIni = pvEstadoIni

        sClienteClave = pvClienteClave
    End Sub
#Region " IDisposable Support "
    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        Me.Icono = Nothing
        oCOLPreguntas.Clear()
        oCOLPreguntas = Nothing
        GC.SuppressFinalize(Me)
    End Sub
#End Region
    Private Sub RecuperaIcono()
        Dim sConsulta As String
        sConsulta = "select Icono from ConfigEncuesta where CENClave = '" & Me.CENClave & "'"
        Icono = oDBVen.RealizarScalarSQL(sConsulta)
    End Sub
    Private Sub RecuperaENCId()
        Dim dtEnc As DataTable
        Dim sConsulta As String
        If (oDBVen.EjecutarCmdScalarIntSQL("SELECT Count(*) from Encuesta WHERE ENCId = '" & Me.ENCId & "'") = 0) Then

            sConsulta = String.Format("select ENCId from Encuesta where CENClave = '{0}' and VisitaClave = '{1}' and DiaClave = '{2}'", Me.CENClave, sVisitaClave, sDiaClave)
            dtEnc = oDBVen.RealizarConsultaSQL(sConsulta, "Encuesta")
            If dtEnc.Rows.Count > 0 Then
                Me.ENCId = dtEnc.Rows(0)("ENCId")
                Me.EstadoEnc = EstadoEncuesta.Recuperada
            Else
                Me.ENCId = ""
                Me.EstadoEnc = EstadoEncuesta.Nueva
            End If
            dtEnc.Dispose()
        Else
            Me.EstadoEnc = EstadoEncuesta.Recuperada
        End If
        dtEnc = Nothing
    End Sub
    Public Sub RecuperaPreguntas()
        Dim dtPregs As DataTable
        Dim sConsulta As New System.Text.StringBuilder
        oCOLPreguntas = New cCOLPreguntas
        sConsulta.Append("select CENClave, CEPNumero, Descripcion, TipoRespuesta, RespuestaRequerida, Confirmacion, Orden, case when CantidadRequerida is null then 0 else CantidadRequerida end as CantidadRequerida ")
        sConsulta.Append("from CENPregunta ")
        sConsulta.Append("where CENClave = '" & sCENClave & "' and Condicionante = 0")
        sConsulta.Append("order by Orden ")
        dtPregs = oDBVen.RealizarConsultaSQL(sConsulta.ToString, "CENPregunta")
        sConsulta = Nothing
        oConPreg = New cConsultaPreguntas(Me.ENCId, Me.CENClave)
        CargaPreguntas(dtPregs)
        oCOLPreguntas.oConsPreg = oConPreg
        dtPregs.Dispose()
    End Sub
    Public Sub EjecutarEncuesta()
        oCOLPreguntas.IniciarEncuesta()
    End Sub

    Public Function CargaPreguntas(ByVal dtPreguntas As DataTable) As CEstado
        Dim nOrden As Integer = 1
        bEncuestaTerminada = False
        Me.Preguntas.PuntosAnt = 0

        For Each drPreg As DataRow In dtPreguntas.Rows

            Dim oPreg As cPregunta

            '//Depende del tipo de Pregunta Asignar sus propiedades

            Select Case drPreg("TipoRespuesta")
                Case 1 'Texto
                    Dim oCRT As New cPreguntaTexto
                    oCRT.Asignar(drPreg("CENClave"), drPreg("CEPNumero"), drPreg("Descripcion"), drPreg("TipoRespuesta"), drPreg("RespuestaRequerida"), drPreg("Confirmacion"), drPreg("CantidadRequerida"), nOrden, Me.ENCId)
                    oCRT.Recuperar(oConPreg.PreguntaTexto)
                    oPreg = oCRT
                    nOrden += 1

                Case 2 'Numero
                    Dim oCRN As New cPreguntaNumero
                    oCRN.Asignar(drPreg("CENClave"), drPreg("CEPNumero"), drPreg("Descripcion"), drPreg("TipoRespuesta"), drPreg("RespuestaRequerida"), drPreg("Confirmacion"), drPreg("CantidadRequerida"), nOrden, Me.ENCId)
                    oCRN.Recuperar(oConPreg.PreguntaNumero)
                    oPreg = oCRN
                    nOrden += 1

                Case 3 'Opcional
                    Dim oCRO As New cPreguntaOpcional
                    oCRO.Asignar(drPreg("CENClave"), drPreg("CEPNumero"), drPreg("Descripcion"), drPreg("TipoRespuesta"), drPreg("RespuestaRequerida"), drPreg("Confirmacion"), drPreg("CantidadRequerida"), nOrden, Me.ENCId)
                    If Me.EstadoEnc = EstadoEncuesta.Nueva Then
                        oCRO.Rotar = True
                    End If
                    oCRO.Recuperar(oConPreg.PreguntaOpcional)
                    oPreg = oCRO
                    nOrden += 1
                    Me.Preguntas.PuntosAnt += oCRO.PuntosAnt

                Case 4 'Codigo
                    Dim oCRC As New cPreguntaCodigo
                    oCRC.Asignar(drPreg("CENClave"), drPreg("CEPNumero"), drPreg("Descripcion"), drPreg("TipoRespuesta"), drPreg("RespuestaRequerida"), drPreg("Confirmacion"), drPreg("CantidadRequerida"), nOrden, Me.ENCId)
                    oCRC.Recuperar(oConPreg.PreguntaCodigo)
                    oPreg = oCRC
                    nOrden += 1

                Case 5 'Imagen
                    Dim oCRI As New cPreguntaImagen
                    oCRI.Asignar(drPreg("CENClave"), drPreg("CEPNumero"), drPreg("Descripcion"), drPreg("TipoRespuesta"), drPreg("RespuestaRequerida"), drPreg("Confirmacion"), drPreg("CantidadRequerida"), nOrden, Me.ENCId)
                    oCRI.Recuperar(oConPreg.PreguntaImagen)
                    oPreg = oCRI
                    nOrden += 1

                Case 6 'Matricial
                    Dim oCRM As New cPreguntaMatricial
                    oCRM.Asignar(drPreg("CENClave"), drPreg("CEPNumero"), drPreg("Descripcion"), drPreg("TipoRespuesta"), drPreg("RespuestaRequerida"), drPreg("Confirmacion"), drPreg("CantidadRequerida"), nOrden, Me.ENCId)
                    oCRM.Recuperar(oConPreg.RespuestaMatricial)
                    oPreg = oCRM
                    nOrden += 1

                Case 7 'Salto
                    Dim oCRS As New cPreguntaSalto
                    oCRS.Asignar(drPreg("CENClave"), drPreg("CEPNumero"), drPreg("Descripcion"), drPreg("TipoRespuesta"), drPreg("RespuestaRequerida"), drPreg("Confirmacion"), drPreg("CantidadRequerida"), nOrden, Me.ENCId)
                    oCRS.Recuperar(oConPreg.PreguntaSalto)
                    oPreg = oCRS
                    nOrden += 1

                Case 8 'GPS
                    Dim oCRG As New cPreguntaGPS
                    oCRG.Asignar(drPreg("CENClave"), drPreg("CEPNumero"), drPreg("Descripcion"), drPreg("TipoRespuesta"), drPreg("RespuestaRequerida"), drPreg("Confirmacion"), drPreg("CantidadRequerida"), nOrden, Me.ENCId)
                    oCRG.Recuperar(oConPreg.PreguntaGPS)
                    oPreg = oCRG
                    nOrden += 1

                Case Else
                    oPreg = Nothing

            End Select

            If Not oPreg Is Nothing Then
                oCOLPreguntas.Add(oPreg)
            End If
        Next

        Return New CEstado(TipoEstado.ECorrecto)

    End Function
    
    Public Function Grabar(Optional ByVal bInicio As Boolean = False) As Boolean
        Try
            If bInicio Then
                Me.Fase = EstadoFinalizar.ParcialmenteAplicada
            Else
                Me.Fase = EstadoFin
            End If
            Select Case Me.EstadoEnc
                Case EstadoEncuesta.Nueva
                    If Me.ENCId = "" Then
                        Me.ENCId = oApp.KEYGEN(1)
                        Me.Insertar()
                    Else
                        Me.Modificar()
                    End If
                Case EstadoEncuesta.Recuperada
                    Me.Modificar()
            End Select
            If EstadoFin = EstadoFinalizar.Aplicada Or EstadoFin = EstadoFinalizar.ParcialmenteAplicada Then
                EliminarPreguntas()
            End If
        Catch ex As SqlServerCe.SqlCeException
            Return False
        End Try
    End Function
    Public Sub Insertar()
        Dim sComando As String
        Me.HoraFin = Now

        sComando = String.Format("insert into Encuesta (ENCId, CENClave, VisitaClave, DiaClave, Fase, Fecha, HoraInicio, HoraFin, MFechaHora, MUsuarioId) values('{0}','{1}','{2}','{3}',{4},{5},{6},{7},{8},'{9}')", Me.ENCId, Me.CENClave, Me.VisitaClave, Me.DiaClave, Me.Fase, UniFechaSQL(Me.Fecha), UniFechaSQL(Me.HoraInicio), UniFechaSQL(Me.HoraFin), UniFechaSQL(Now), oVendedor.UsuarioId)
        oDBVen.EjecutarComandoSQL(sComando)
        'Me.Preguntas.Grabar(Me.ENCId)
        If Me.Preguntas.bFinEncuesta Then
            AcumularPuntos()
        End If
    End Sub
    Public Sub Modificar()
        Dim sComando As String
        Me.HoraFin = Now
        sComando = String.Format("update Encuesta set Fase = {0}, Fecha = {1}, HoraInicio = {2}, HoraFin = {3}, MFechaHora = {4}, MUsuarioId = '{5}',Enviado=0 where ENCId = '{6}'", Me.Fase, UniFechaSQL(Me.Fecha), UniFechaSQL(Me.HoraInicio), UniFechaSQL(Me.HoraFin), UniFechaSQL(Now), oVendedor.UsuarioId, Me.ENCId)
        oDBVen.EjecutarComandoSQL(sComando)
        If Me.EstadoIni = EstadoFinalizar.Aplicada And Not Me.Preguntas.bFinEncuesta Then
            AcumularPuntos(False)
        End If
        If Me.Preguntas.bFinEncuesta Then
            AcumularPuntos()
        End If
    End Sub
    Public Sub TerminarEncuesta()
        oCOLPreguntas = Nothing
        oCOLPreguntas = New cCOLPreguntas
        bEncuestaTerminada = True
    End Sub
    Public Sub AcumularPuntos(Optional ByVal bAgregar As Boolean = True)
        If Not FormasCanjes.ExisteRegistroCaducidad(Me.sClienteClave) Then Exit Sub

        Dim nTotalPuntos As Integer
        Dim sComando As String
        If bAgregar Then
            nTotalPuntos = Me.CENPuntos + Me.CECPuntos + Me.Preguntas.PuntosNvo
        Else
            nTotalPuntos = -(Me.CENPuntos + Me.CECPuntos + Me.Preguntas.PuntosAnt)
        End If
        sComando = String.Format("update Punto set Saldo = Saldo + {0}, Saldo1 = Saldo1 + {1}, MFechaHora = {2}, MUsuarioId = '{3}',Enviado = 0  where ClienteClave = '{4}'", nTotalPuntos, nTotalPuntos, UniFechaSQL(Now), oVendedor.UsuarioId, sClienteClave)
        oDBVen.EjecutarComandoSQL(sComando)
    End Sub
    Public Function ObtenerIcono() As System.Drawing.Bitmap
        Try
            If Not Me.Icono Is Nothing Then
                Dim aIcono As Byte() = CType(Me.Icono, Byte())
                Dim msImagen As New System.IO.MemoryStream(aIcono)
                Dim oIcono As New System.Drawing.Icon(msImagen)
                Dim oBmp As New System.Drawing.Bitmap(oIcono.Width, oIcono.Height)
                Dim oGrafico As System.Drawing.Graphics = System.Drawing.Graphics.FromImage(oBmp)
                oGrafico.DrawIcon(oIcono, 0, 0)
                oGrafico.Dispose()
                msImagen.Close()
                aIcono = Nothing
                Return oBmp
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Private Sub EliminarPreguntas()
        Dim sConsulta As String
        Dim sVisitadas As String = ""
        Dim dtNoVisitadas As DataTable
        Dim oPreg As cPregunta

        For Each nPreg As Integer In Me.Preguntas.aVisitadas
            sVisitadas &= nPreg & ","
        Next
        If sVisitadas.Length > 0 Then
            sVisitadas = sVisitadas.Remove(sVisitadas.Length - 1, 1)
        End If
        sConsulta = "select CEP.TipoRespuesta, ENP.ENPId "
        sConsulta &= "from ENCPregunta ENP "
        sConsulta &= "inner join CENPregunta CEP on ENP.CENClave = CEP.CENClave and ENP.CEPNumero = CEP.CEPNumero "
        sConsulta &= "where ENP.ENCId = '" & Me.ENCId & "' "
        If sVisitadas.Length > 0 Then
            sConsulta &= "and ENP.CEPNumero not in (" & sVisitadas & ") "
        End If
        dtNoVisitadas = oDBVen.RealizarConsultaSQL(sConsulta, "NoVisitadas")
        For Each drPreg As DataRow In dtNoVisitadas.Rows
            Select Case drPreg("TipoRespuesta")
                Case 1 'Texto
                    oPreg = New cPreguntaTexto
                Case 2 'Numero
                    oPreg = New cPreguntaNumero
                Case 3 'Opcional
                    oPreg = New cPreguntaOpcional
                Case 4 'Codigo
                    oPreg = New cPreguntaCodigo
                Case 5 'Imagen
                    oPreg = New cPreguntaImagen
                Case 6 'Matricial
                    oPreg = New cPreguntaMatricial
                Case 7 'Salto
                    oPreg = New cPreguntaSalto
                Case 8 'GPS
                    oPreg = New cPreguntaGPS
                Case Else
                    oPreg = Nothing
            End Select
            If Not oPreg Is Nothing Then
                oPreg.Eliminar(Me.ENCId, drPreg("ENPId"))
            End If
        Next
        dtNoVisitadas.Dispose()
        oPreg = Nothing
    End Sub
#End Region
End Class
