Public Enum TipoEstado
    ECorrecto = 1
    EError = -1
End Enum

Public Class CEstado
    Inherits ApplicationException

    Public tEstado As TipoEstado
    Public sCVEMensaje As String

    Public Sub New()
    End Sub

    Public Sub New(ByVal pvEstado As TipoEstado)
        tEstado = pvEstado
    End Sub

    Public Sub New(ByVal pvEstado As TipoEstado, ByVal pvMensaje As String)
        tEstado = pvEstado
        sCVEMensaje = pvMensaje
    End Sub
End Class

Public MustInherit Class cPregunta
    Private sCENClave As String
    Private nCEPNumero As Integer
    Private sDescripcion As String
    Private nTipoRespuesta As Integer
    Private bRespuestaRequerida As Boolean
    Private bConfirmaciona As Boolean
    Private nOrden As Integer
    Private nOrdenAplicacion As Integer
    Private nCantidadRequerida As Integer
    Public Visitada As Boolean
    Private sENCId As String
    Private sENPId As String

    Public Property CENClave() As String
        Get
            Return sCENClave
        End Get
        Set(ByVal Value As String)
            sCENClave = Value
        End Set
    End Property
    Public Property CEPNumero() As Integer
        Get
            Return nCEPNumero
        End Get
        Set(ByVal Value As Integer)
            nCEPNumero = Value
        End Set
    End Property
    Public Property Descripcion() As String
        Get
            Return sDescripcion
        End Get
        Set(ByVal Value As String)
            sDescripcion = Value
        End Set
    End Property
    Public Property TipoRespuesta() As Integer
        Get
            Return nTipoRespuesta
        End Get
        Set(ByVal Value As Integer)
            nTipoRespuesta = Value
        End Set
    End Property
    Public Property RespuestaRequerida() As Boolean
        Get
            Return bRespuestaRequerida
        End Get
        Set(ByVal Value As Boolean)
            bRespuestaRequerida = Value
        End Set
    End Property
    Public Property Confirmacion() As Boolean
        Get
            Return bConfirmaciona
        End Get
        Set(ByVal Value As Boolean)
            bConfirmaciona = Value
        End Set
    End Property
    Public Property Orden() As Integer
        Get
            Return nOrden
        End Get
        Set(ByVal Value As Integer)
            nOrden = Value
        End Set
    End Property
    Public Property OrdenAplicacion() As Integer
        Get
            Return nOrdenAplicacion
        End Get
        Set(ByVal value As Integer)
            nOrdenAplicacion = value
        End Set
    End Property
    Public Property CantidadRequerida() As Integer
        Get
            Return nCantidadRequerida
        End Get
        Set(ByVal value As Integer)
            nCantidadRequerida = value
        End Set
    End Property
    Public Property ENCId() As String
        Get
            Return sENCId
        End Get
        Set(ByVal Value As String)
            sENCId = Value
        End Set
    End Property
    Public Property ENPId() As String
        Get
            Return sENPId
        End Get
        Set(ByVal Value As String)
            sENPId = Value
        End Set
    End Property

    Public Sub Asignar(ByVal pvCENClave As String, ByVal pvCEPNumero As Integer, ByVal pvDescripcion As String, _
    ByVal pvTipoRespuesta As Integer, ByVal pvRespuestaRequerida As Boolean, ByVal pvConfirmacion As Boolean, _
    ByVal pvCantidadRequerida As Integer, ByVal pvOrden As Integer, ByVal pvENCId As String)
        Dim sComando As String
        Dim dtENC As DataTable
        Me.CENClave = pvCENClave
        Me.CEPNumero = pvCEPNumero
        Me.Descripcion = pvDescripcion
        Me.TipoRespuesta = pvTipoRespuesta
        Me.RespuestaRequerida = pvRespuestaRequerida
        Me.Confirmacion = pvConfirmacion
        Me.Orden = pvOrden
        Me.CantidadRequerida = pvCantidadRequerida
        Me.ENCId = pvENCId
        If Me.ENCId <> "" Then
            sComando = String.Format("select ENPId from ENCPregunta where ENCId = '{0}' and CENClave = '{1}' and CEPNumero = {2}", Me.ENCId, Me.CENClave, Me.CEPNumero)
            dtENC = oDBVen.RealizarConsultaSQL(sComando, "Encuesta")
            If dtENC.Rows.Count > 0 Then
                'Me.ENCId = dtENC.Rows(0)("ENCId")
                Me.ENPId = dtENC.Rows(0)("ENPId")
            End If
            dtENC.Dispose()
        End If
        'sComando = "select ENCId, ENPId from ENCPregunta where CENClave = '" & pvCENClave & "' and CEPNumero = " & pvCEPNumero        
    End Sub
    Public MustOverride Sub Recuperar()
    Public MustOverride Sub Recuperar(ByVal hash As Hashtable)
    Public MustOverride Sub RecuperarRespuesta()
    Public MustOverride Sub ValidarRespuesta()
    Public Overridable Sub Insertar(ByVal pvENCId As String, ByVal pvOrdenAplicacion As Integer, ByVal pvSemilla As Integer)
        Dim sComando As String
        Me.OrdenAplicacion = pvOrdenAplicacion
        If Me.ENCId = "" Or Me.ENPId = "" Then
            Me.ENCId = pvENCId
            Me.ENPId = oApp.KEYGEN(pvSemilla)
            sComando = String.Format("insert into ENCPregunta (ENCId, ENPId, CENClave, CEPNumero, OrdenAplicacion, MFechaHora, MUsuarioId) values('{0}','{1}','{2}',{3},{4},{5},'{6}')", Me.ENCId, Me.ENPId, Me.CENClave, Me.CEPNumero, Me.OrdenAplicacion, UniFechaSQL(Now), oVendedor.UsuarioId)
        Else
            sComando = String.Format("Update ENCPregunta set OrdenAplicacion = {0}, MFechaHora=getdate(), MUsuarioID = '{1}' Where ENCID='{2}' and ENPId='{3}'", Me.OrdenAplicacion, oVendedor.UsuarioId, Me.ENCId, Me.ENPId)
        End If
        oDBVen.EjecutarComandoSQL(sComando)
    End Sub
    Public Overridable Sub Eliminar(ByVal pvENCId As String, ByVal pvENPId As String)
        Dim sComando As String
        sComando = String.Format("delete ENCPregunta where ENCID='{0}' and ENPId='{1}'", pvENCId, pvENPId)
        oDBVen.EjecutarComandoSQL(sComando)
    End Sub
End Class

Public Class cPreguntaTexto
    Inherits cPregunta

    Private sCRTId As String
    Private nTipoConversion As Integer
    Private sMascara As String
    Private nTipoLimite As Integer
    Private nMinimo As Integer
    Private nMaximo As Integer
    Private sERTId As String
    Private sRespuesta As String

    Public Property CRTId() As String
        Get
            Return sCRTId
        End Get
        Set(ByVal Value As String)
            sCRTId = Value
        End Set
    End Property
    Public Property TipoConversion() As Integer
        Get
            Return nTipoConversion
        End Get
        Set(ByVal Value As Integer)
            nTipoConversion = Value
        End Set
    End Property
    Public Property Mascara() As String
        Get
            Return sMascara
        End Get
        Set(ByVal Value As String)
            sMascara = Value
        End Set
    End Property
    Public Property TipoLimite() As Integer
        Get
            Return nTipoLimite
        End Get
        Set(ByVal Value As Integer)
            nTipoLimite = Value
        End Set
    End Property
    Public Property Minimo() As Integer
        Get
            Return nMinimo
        End Get
        Set(ByVal Value As Integer)
            nMinimo = Value
        End Set
    End Property
    Public Property Maximo() As Integer
        Get
            Return nMaximo
        End Get
        Set(ByVal Value As Integer)
            nMaximo = Value
        End Set
    End Property
    Public Property ERTId() As String
        Get
            Return sERTId
        End Get
        Set(ByVal Value As String)
            sERTId = Value
        End Set
    End Property
    Public Property Respuesta() As String
        Get
            Return sRespuesta
        End Get
        Set(ByVal Value As String)
            sRespuesta = Value
        End Set
    End Property

    Public Overrides Sub Recuperar()
        Dim sConsulta As String
        Dim dtPreg As DataTable
        sConsulta = "select CRTId, TipoConversion, Mascara, TipoLimite, Minimo, Maximo from CEPRespTexto "
        sConsulta &= "where CENClave = '" & Me.CENClave & "' and CEPNumero = " & Me.CEPNumero
        dtPreg = odbVen.RealizarConsultaSQL(sConsulta, "CEPRespTexto")
        If dtPreg.Rows.Count > 0 Then
            Dim drPreg As DataRow
            drPreg = dtPreg.Rows(0)
            Me.CRTId = drPreg("CRTId")
            Me.TipoConversion = drPreg("TipoConversion")
            Me.Mascara = IIf(IsDBNull(drPreg("Mascara")), "", drPreg("Mascara"))
            Me.TipoLimite = drPreg("TipoLimite")
            Me.Minimo = drPreg("Minimo")
            Me.Maximo = drPreg("Maximo")
            'Respuesta
            If Me.ENCId <> "" And Me.ENPId <> "" Then
                sConsulta = "select ERTId, Descripcion from ENPRespTexto where ENCId = '" & Me.ENCId & "' and ENPId = '" & Me.ENPId & "'"
                dtPreg = odbVen.RealizarConsultaSQL(sConsulta, "ENPRespTexto")
                If dtPreg.Rows.Count > 0 Then
                    ERTId = dtPreg.Rows(0)("ERTId")
                    Respuesta = dtPreg.Rows(0)("Descripcion")
                End If
            End If
        End If
        dtPreg.Dispose()
    End Sub
    Public Overrides Sub Recuperar(ByVal hash As Hashtable)

        If hash Is Nothing Then Exit Sub

        If hash.ContainsKey(Me.CEPNumero) Then
            Dim drPreg As DataRow = hash.Item(Me.CEPNumero)

            Me.CRTId = drPreg("CRTId")
            Me.TipoConversion = drPreg("TipoConversion")
            Me.Mascara = IIf(IsDBNull(drPreg("Mascara")), "", drPreg("Mascara"))
            Me.TipoLimite = drPreg("TipoLimite")
            Me.Minimo = drPreg("Minimo")
            Me.Maximo = drPreg("Maximo")
            'Respuesta
            If Me.ENCId <> "" And Me.ENPId <> "" Then
                Dim sConsulta As String
                Dim dtPreg As DataTable

                sConsulta = "select ERTId, Descripcion from ENPRespTexto where ENCId = '" & Me.ENCId & "' and ENPId = '" & Me.ENPId & "'"
                dtPreg = oDBVen.RealizarConsultaSQL(sConsulta, "ENPRespTexto")
                If dtPreg.Rows.Count > 0 Then
                    ERTId = dtPreg.Rows(0)("ERTId")
                    Respuesta = dtPreg.Rows(0)("Descripcion")
                End If
                dtPreg.Dispose()
            End If
        End If

    End Sub

    Public Overrides Sub RecuperarRespuesta()
        Dim sConsulta As String
        Dim dtPreg As DataTable
        'Respuesta
        If Me.ENCId <> "" And Me.ENPId <> "" Then
            sConsulta = "select ERTId, Descripcion from ENPRespTexto where ENCId = '" & Me.ENCId & "' and ENPId = '" & Me.ENPId & "'"
            dtPreg = oDBVen.RealizarConsultaSQL(sConsulta, "ENPRespTexto")
            If dtPreg.Rows.Count > 0 Then
                ERTId = dtPreg.Rows(0)("ERTId")
                Respuesta = dtPreg.Rows(0)("Descripcion")
            End If
        End If
        dtPreg.Dispose()
    End Sub
    Public Overrides Sub ValidarRespuesta()
        If Not Me.Respuesta Is Nothing Then
            Me.Respuesta = Me.Respuesta.Trim
        End If
        If Me.RespuestaRequerida Then
            If Me.Respuesta Is Nothing OrElse Me.Respuesta.Length = 0 Then
                Throw New CEstado(TipoEstado.EError, "E0308")
            End If
        End If
        If Not (Me.Respuesta Is Nothing OrElse Me.Respuesta.Length = 0) Then
            If Me.TipoLimite = 2 Then
                If Me.Respuesta.Length < Minimo Then
                    Throw New CEstado(TipoEstado.EError, "E0309")
                End If
                If Me.Respuesta.Length > Maximo Then
                    Throw New CEstado(TipoEstado.EError, "E0309")
                End If
            End If
        End If
    End Sub
    Public Overrides Sub Insertar(ByVal pvENCId As String, ByVal pvOrdenAplicacion As Integer, ByVal pvSemilla As Integer)
        Dim sComando As String
        Me.ValidarRespuesta()
        Me.Respuesta = Me.Respuesta.Replace("'", "''")
        MyBase.Insertar(pvENCId, pvOrdenAplicacion, pvSemilla)
        If Me.ERTId = "" Then
            Me.ERTId = oApp.KEYGEN(1)
            ConvertirTexto()
            sComando = String.Format("insert into ENPRespTexto (ENCId, ENPId, ERTId, Descripcion, MFechaHora, MUsuarioId) values('{0}','{1}','{2}','{3}',{4},'{5}')", Me.ENCId, Me.ENPId, Me.ERTId, Me.Respuesta, UniFechaSQL(Now), oVendedor.UsuarioId)
        Else
            ConvertirTexto()
            sComando = String.Format("Update ENPRespTexto set Descripcion='{0}', MFechaHora = getdate(), MUsuarioId = '{1}' Where ENCId='{2}' and ENPId ='{3}' and ERTId = '{4}' ", Me.Respuesta, oVendedor.UsuarioId, Me.ENCId, Me.ENPId, Me.ERTId)
        End If
        oDBVen.EjecutarComandoSQL(sComando)
    End Sub
    Public Overrides Sub Eliminar(ByVal pvENCId As String, ByVal pvENPId As String)
        Dim sComando As String
        sComando = String.Format("delete ENPRespTexto where ENCId='{0}' and ENPId ='{1}'", pvENCId, pvENPId)
        oDBVen.EjecutarComandoSQL(sComando)
        MyBase.Eliminar(pvENCId, pvENPId)
    End Sub
    Public Sub ConvertirTexto()
        If Me.Mascara <> "" Then
            Dim sPalabras() As String
            Select Case Me.TipoConversion
                Case 1 'Minusculas
                    Me.Respuesta = Me.Respuesta.ToLower()
                Case 2 'Mayusculas
                    Me.Respuesta = Me.Respuesta.ToUpper()
                Case 3 'Titulo
                    Me.Respuesta = LCase(Me.Respuesta)
                    sPalabras = Me.Respuesta.Split()
                    Me.Respuesta = ""
                    For Each sPalabra As String In sPalabras
                        sPalabra = Replace(sPalabra, Mid(sPalabra, 1, 1), UCase(Mid(sPalabra, 1, 1)), 1, 1)
                        Me.Respuesta &= sPalabra & " "
                    Next
                    Me.Respuesta = Me.Respuesta.Trim()
            End Select
        End If
    End Sub

    Public Sub ValidarFormatoTexto(ByRef prValor As String)
        If Me.Mascara <> "" Then
            Dim sMasc As String = Me.Mascara
            Dim sValorFinal As String = ""
            Dim sCaracter As Char
            Dim bValido As Boolean = True
            Dim nCont As Integer = 0
            If prValor.Length <> sMasc.Length Then
                Throw New CEstado(TipoEstado.EError, "E0554")
                Cursor.Current = Cursors.Default
            End If

            While nCont < sMasc.Length And bValido
                sCaracter = prValor.Chars(nCont)
                Select Case sMasc.Chars(nCont)
                    Case "A"
                        If Char.IsLetter(sCaracter) Then
                            sValorFinal &= Char.ToUpper(sCaracter)
                        Else
                            bValido = False
                        End If
                    Case "a"
                        If Char.IsLetter(sCaracter) Then
                            sValorFinal &= Char.ToLower(sCaracter)
                        Else
                            bValido = False
                        End If
                    Case "y"
                        If Char.IsLetter(sCaracter) Then
                            sValorFinal &= sCaracter
                        Else
                            bValido = False
                        End If
                    Case "X"
                        If Char.IsLetterOrDigit(sCaracter) Then
                            sValorFinal &= Char.ToUpper(sCaracter)
                        Else
                            bValido = False
                        End If
                    Case "x"
                        If Char.IsLetterOrDigit(sCaracter) Then
                            sValorFinal &= Char.ToLower(sCaracter)
                        Else
                            bValido = False
                        End If
                    Case "Y"
                        If Char.IsLetterOrDigit(sCaracter) Then
                            sValorFinal &= sCaracter
                        Else
                            bValido = False
                        End If
                    Case "9"
                        If Char.IsDigit(sCaracter) Then
                            sValorFinal &= sCaracter
                        Else
                            bValido = False
                        End If
                    Case "z"
                        sValorFinal &= sCaracter
                    Case Else
                        If sCaracter = sMasc.Chars(nCont) Then
                            sValorFinal &= sCaracter
                        Else
                            bValido = False
                        End If
                End Select
                nCont += 1
            End While

            If Not bValido Then
                Throw New CEstado(TipoEstado.EError, "E0554")
                Cursor.Current = Cursors.Default
            Else
                prValor = sValorFinal
            End If
        End If
    End Sub
End Class

Public Class cPreguntaNumero
    Inherits cPregunta

    Private sCRNId As String
    'Private nTipoMascara As Integer
    'Private nDecimales As Integer
    Private sFormato As String
    Private nTipoLimite As Integer
    Private nMinimo As Integer
    Private nMaximo As Integer
    Private sERNId As String
    Private sRespuesta As String
    Private sFormatoNumerico As String
    Private sPrefijoFormato As String
    Private sSufijoFormato As String

    Public Property CRNId() As String
        Get
            Return sCRNId
        End Get
        Set(ByVal Value As String)
            sCRNId = Value
        End Set
    End Property
    'Public Property TipoMascara() As Integer
    '    Get
    '        Return nTipoMascara
    '    End Get
    '    Set(ByVal Value As Integer)
    '        nTipoMascara = Value
    '    End Set
    'End Property
    'Public Property Decimales() As Integer
    '    Get
    '        Return nDecimales
    '    End Get
    '    Set(ByVal Value As Integer)
    '        nDecimales = Value
    '    End Set
    'End Property
    Public Property Formato() As String
        Get
            Return sFormato
        End Get
        Set(ByVal Value As String)
            sFormato = Value
        End Set
    End Property
    Public Property TipoLimite() As Integer
        Get
            Return nTipoLimite
        End Get
        Set(ByVal Value As Integer)
            nTipoLimite = Value
        End Set
    End Property
    Public Property Minimo() As Integer
        Get
            Return nMinimo
        End Get
        Set(ByVal Value As Integer)
            nMinimo = Value
        End Set
    End Property
    Public Property Maximo() As Integer
        Get
            Return nMaximo
        End Get
        Set(ByVal Value As Integer)
            nMaximo = Value
        End Set
    End Property
    Public Property ERNId() As String
        Get
            Return sERNId
        End Get
        Set(ByVal Value As String)
            sERNId = Value
        End Set
    End Property
    Public Property Respuesta() As String
        Get
            Return sRespuesta
        End Get
        Set(ByVal Value As String)
            sRespuesta = Value
        End Set
    End Property
    Public Property FormatoNumerico() As String
        Get
            Return sFormatoNumerico
        End Get
        Set(ByVal value As String)
            sFormatoNumerico = value
        End Set
    End Property
    Public Property PrefijoFormato() As String
        Get
            Return sPrefijoFormato
        End Get
        Set(ByVal value As String)
            sPrefijoFormato = value
        End Set
    End Property
    Public Property SufijoFormato() As String
        Get
            Return sSufijoFormato
        End Get
        Set(ByVal value As String)
            sSufijoFormato = value
        End Set
    End Property

    Public Overrides Sub Recuperar()
        Dim sConsulta As String
        Dim dtPreg As DataTable
        sConsulta = "select CRNId, Formato, TipoLimite, Minimo, Maximo from CEPRespNumero "
        sConsulta &= "where CENClave = '" & Me.CENClave & "' and CEPNumero = " & Me.CEPNumero
        dtPreg = odbVen.RealizarConsultaSQL(sConsulta, "CEPRespNumero")
        If dtPreg.Rows.Count > 0 Then
            Dim drPreg As DataRow
            drPreg = dtPreg.Rows(0)
            Me.CRNId = drPreg("CRNId")
            'Me.TipoMascara = drPreg("TipoMascara")
            'Me.Decimales = drPreg("Decimales")
            Me.Formato = IIf(IsDBNull(drPreg("Formato")), "", drPreg("Formato"))
            Me.TipoLimite = drPreg("TipoLimite")
            Me.Minimo = drPreg("Minimo")
            Me.Maximo = drPreg("Maximo")
            FormarFormatoNumero()
            'Respuesta
            If Me.ENCId <> "" And Me.ENPId <> "" Then
                sConsulta = "select ERNId, Valor from ENPRespNumero where ENCId = '" & Me.ENCId & "' and ENPId = '" & Me.ENPId & "'"
                dtPreg = odbVen.RealizarConsultaSQL(sConsulta, "ENPRespNumero")
                If dtPreg.Rows.Count > 0 Then
                    ERNId = dtPreg.Rows(0)("ERNId")
                    Respuesta = dtPreg.Rows(0)("Valor")
                End If
            End If
        End If
        dtPreg.Dispose()
    End Sub
    Public Overrides Sub Recuperar(ByVal hash As Hashtable)
        If hash Is Nothing Then Exit Sub
        If hash.ContainsKey(Me.CEPNumero) Then
            Dim drPreg As DataRow = hash.Item(Me.CEPNumero)

            Me.CRNId = drPreg("CRNId")
            'Me.TipoMascara = drPreg("TipoMascara")
            'Me.Decimales = drPreg("Decimales")
            Me.Formato = IIf(IsDBNull(drPreg("Formato")), "", drPreg("Formato"))
            Me.TipoLimite = drPreg("TipoLimite")
            Me.Minimo = drPreg("Minimo")
            Me.Maximo = drPreg("Maximo")
            FormarFormatoNumero()
            'Respuesta
            If Me.ENCId <> "" And Me.ENPId <> "" Then
                Dim sConsulta As String
                Dim dtPreg As DataTable

                sConsulta = "select ERNId, Valor from ENPRespNumero where ENCId = '" & Me.ENCId & "' and ENPId = '" & Me.ENPId & "'"
                dtPreg = oDBVen.RealizarConsultaSQL(sConsulta, "ENPRespNumero")
                If dtPreg.Rows.Count > 0 Then
                    ERNId = dtPreg.Rows(0)("ERNId")
                    Respuesta = dtPreg.Rows(0)("Valor")
                End If
                dtPreg.Dispose()
            End If
        End If

    End Sub
    Public Overrides Sub RecuperarRespuesta()
        Dim sConsulta As String
        Dim dtPreg As DataTable
        'Respuesta
        If Me.ENCId <> "" And Me.ENPId <> "" Then
            sConsulta = "select ERNId, Valor from ENPRespNumero where ENCId = '" & Me.ENCId & "' and ENPId = '" & Me.ENPId & "'"
            dtPreg = oDBVen.RealizarConsultaSQL(sConsulta, "ENPRespNumero")
            If dtPreg.Rows.Count > 0 Then
                ERNId = dtPreg.Rows(0)("ERNId")
                Respuesta = dtPreg.Rows(0)("Valor")
            End If
        End If
        dtPreg.Dispose()
    End Sub
    Public Overrides Sub ValidarRespuesta()
        If Me.RespuestaRequerida Then
            If Me.Respuesta Is Nothing Then
                Throw New CEstado(TipoEstado.EError, "E0308")
            End If
        End If
        If TipoLimite = 2 Then
            If Not Me.Respuesta Is Nothing Then
                If Me.Respuesta < Minimo Then
                    Throw New CEstado(TipoEstado.EError, "E0309")
                End If
                If Me.Respuesta > Maximo Then
                    Throw New CEstado(TipoEstado.EError, "E0309")
                End If
            End If
        End If
    End Sub
    Public Overrides Sub Insertar(ByVal pvENCId As String, ByVal pvOrdenAplicacion As Integer, ByVal pvSemilla As Integer)
        Dim sComando As String
        Me.ValidarRespuesta()
        MyBase.Insertar(pvENCId, pvOrdenAplicacion, pvSemilla)
        If Me.Respuesta Is Nothing Then
            Me.Respuesta = 0
        End If
        If Me.ERNId = "" Then
            Me.ERNId = oApp.KEYGEN(1)
            sComando = String.Format("insert into ENPRespNumero (ENCId, ENPId, ERNId, Valor, MFechaHora, MUsuarioId) values('{0}','{1}','{2}',{3},{4},'{5}')", Me.ENCId, Me.ENPId, Me.ERNId, Me.Respuesta, UniFechaSQL(Now), oVendedor.UsuarioId)
        Else
            sComando = String.Format("Update ENPRespNumero set Valor={0}, MFechaHora = getdate(), MUsuarioId='{1}' Where ENCId='{2}' and ENPId ='{3}' and ERNId = '{4}' ", Me.Respuesta, oVendedor.UsuarioId, Me.ENCId, Me.ENPId, Me.ERNId)
        End If
        oDBVen.EjecutarComandoSQL(sComando)
    End Sub
    Public Overrides Sub Eliminar(ByVal pvENCId As String, ByVal pvENPId As String)
        Dim sComando As String
        sComando = String.Format("delete ENPRespNumero where ENCId='{0}' and ENPId ='{1}'", pvENCId, pvENPId)
        oDBVen.EjecutarComandoSQL(sComando)
        MyBase.Eliminar(pvENCId, pvENPId)
    End Sub

    Private Sub FormarFormatoNumero()
        If Me.Formato <> "" Then
            Dim sMasc As String = Me.Formato
            Dim nPrimero As Integer
            Dim nUltimo As Integer
            Dim nCant As Integer
            Dim sChar As Char() = {"0", "#", ".", ","}
            nPrimero = sMasc.IndexOfAny(sChar)
            nUltimo = sMasc.LastIndexOfAny(sChar)
            nCant = sMasc.Length - nPrimero - (sMasc.Length - (nUltimo + 1))
            If nPrimero >= 0 And nUltimo >= 0 Then
                Me.FormatoNumerico = sMasc.Substring(nPrimero, nCant)
            End If
            If nPrimero > 0 Then
                Me.PrefijoFormato = sMasc.Substring(0, nPrimero)
            End If
            nCant = sMasc.Length - 1
            If (nCant > nUltimo) = True Then
                Me.sSufijoFormato = sMasc.Substring(nUltimo + 1, (sMasc.Length - (nUltimo + 1)))
            End If
        End If
    End Sub
End Class

Public Class cPreguntaOpcional
    Inherits cPregunta

    Private sCROId As String
    Private nTipoSeleccion As Integer
    Private nTipoLimite As Integer
    Private nMinimo As Integer
    Private nMaximo As Integer
    Private bRotativa As Boolean
    Private bCondicion As Boolean
    Private nTipoLimite1 As Integer
    Private nMinimo1 As Decimal
    Private nMaximo1 As Decimal
    Private nTipoConversion As Integer
    Private sFormato As String
    'Private sTipoTexto As String
    'Private nTipoMascara As Integer
    'Private nDecimales As Integer
    Private nTipoProducto As Integer
    Private sClienteClave As String
    Private sFormatoNumerico As String
    Private sPrefijoFormato As String
    Private sSufijoFormato As String
    'Condicion 
    Private sROCId As String
    Private sCENClave1 As String
    Private nCEPNumero1 As Integer
    Private nTipoCondicion As Integer
    Private nTipoValor As Integer
    Private nValor As Integer
    'Opciones
    Private dtOpciones As DataTable
    Private htEROId As Hashtable
    Private htRespuestas As Hashtable
    Private nPuntosAnt As Integer
    Private nPuntosNvo As Integer
    Private bRotar As Boolean

    Public Property CROId() As String
        Get
            Return sCROId
        End Get
        Set(ByVal Value As String)
            sCROId = Value
        End Set
    End Property
    Public Property TipoSeleccion() As Integer
        Get
            Return nTipoSeleccion
        End Get
        Set(ByVal Value As Integer)
            nTipoSeleccion = Value
        End Set
    End Property
    Public Property TipoLimite() As Integer
        Get
            Return nTipoLimite
        End Get
        Set(ByVal Value As Integer)
            nTipoLimite = Value
        End Set
    End Property
    Public Property Minimo() As Integer
        Get
            Return nMinimo
        End Get
        Set(ByVal Value As Integer)
            nMinimo = Value
        End Set
    End Property
    Public Property Maximo() As Integer
        Get
            Return nMaximo
        End Get
        Set(ByVal Value As Integer)
            nMaximo = Value
        End Set
    End Property
    Public Property Rotativa() As Boolean
        Get
            Return bRotativa
        End Get
        Set(ByVal Value As Boolean)
            bRotativa = Value
        End Set
    End Property
    Public Property Condicion() As Boolean
        Get
            Return bCondicion
        End Get
        Set(ByVal Value As Boolean)
            bCondicion = Value
        End Set
    End Property
    Public Property TipoLimite1() As Integer
        Get
            Return nTipoLimite1
        End Get
        Set(ByVal value As Integer)
            nTipoLimite1 = value
        End Set
    End Property
    Public Property Minimo1() As Double
        Get
            Return nMinimo1
        End Get
        Set(ByVal value As Double)
            nMinimo1 = value
        End Set
    End Property
    Public Property Maximo1() As Double
        Get
            Return nMaximo1
        End Get
        Set(ByVal value As Double)
            nMaximo1 = value
        End Set
    End Property
    Public Property TipoConversion() As Integer
        Get
            Return nTipoConversion
        End Get
        Set(ByVal value As Integer)
            nTipoConversion = value
        End Set
    End Property
    Public Property Formato() As String
        Get
            Return sFormato
        End Get
        Set(ByVal value As String)
            sFormato = value
        End Set
    End Property
    'Public Property TipoTexto() As String
    '    Get
    '        Return sTipoTexto
    '    End Get
    '    Set(ByVal value As String)
    '        sTipoTexto = value
    '    End Set
    'End Property
    'Public Property TipoMascara() As Integer
    '    Get
    '        Return nTipoMascara
    '    End Get
    '    Set(ByVal value As Integer)
    '        nTipoMascara = value
    '    End Set
    'End Property
    'Public Property Decimales() As Integer
    '    Get
    '        Return nDecimales
    '    End Get
    '    Set(ByVal value As Integer)
    '        nDecimales = value
    '    End Set
    'End Property
    Public Property FormatoNumerico() As String
        Get
            Return sFormatoNumerico
        End Get
        Set(ByVal value As String)
            sFormatoNumerico = value
        End Set
    End Property
    Public Property PrefijoFormato() As String
        Get
            Return sPrefijoFormato
        End Get
        Set(ByVal value As String)
            sPrefijoFormato = value
        End Set
    End Property
    Public Property SufijoFormato() As String
        Get
            Return sSufijoFormato
        End Get
        Set(ByVal value As String)
            sSufijoFormato = value
        End Set
    End Property
    'Condicion
    Public Property ROCId() As String
        Get
            Return sROCId
        End Get
        Set(ByVal Value As String)
            sROCId = Value
        End Set
    End Property
    Public Property CENClave1()
        Get
            Return sCENClave1
        End Get
        Set(ByVal Value)
            sCENClave1 = Value
        End Set
    End Property
    Public Property CEPNumero1()
        Get
            Return nCEPNumero1
        End Get
        Set(ByVal Value)
            nCEPNumero1 = Value
        End Set
    End Property
    Public Property TipoCondicion()
        Get
            Return nTipoCondicion
        End Get
        Set(ByVal Value)
            nTipoCondicion = Value
        End Set
    End Property
    Public Property TipoValor()
        Get
            Return nTipoValor
        End Get
        Set(ByVal Value)
            nTipoValor = Value
        End Set
    End Property
    Public Property Valor()
        Get
            Return nValor
        End Get
        Set(ByVal Value)
            nValor = Value
        End Set
    End Property
    'Opciones
    Public Property Opciones() As DataTable
        Get
            Return dtOpciones
        End Get
        Set(ByVal Value As DataTable)
            dtOpciones = Value
        End Set
    End Property
    Public Property EROId() As Hashtable
        Get
            Return htEROId
        End Get
        Set(ByVal Value As Hashtable)
            htEROId = Value
        End Set
    End Property
    Public ReadOnly Property Respuestas() As Hashtable
        Get
            Return htRespuestas
        End Get
    End Property
    Public Property PuntosAnt() As Integer
        Get
            Return nPuntosAnt
        End Get
        Set(ByVal Value As Integer)
            nPuntosAnt = Value
        End Set
    End Property
    Public Property PuntosNvo() As Integer
        Get
            Return nPuntosNvo
        End Get
        Set(ByVal Value As Integer)
            nPuntosNvo = Value
        End Set
    End Property
    Public Property Rotar() As Boolean
        Get
            Return bRotar
        End Get
        Set(ByVal Value As Boolean)
            bRotar = Value
        End Set
    End Property

    Public Property ClienteClave() As String
        Get
            Return sClienteClave
        End Get
        Set(ByVal Value As String)
            sClienteClave = Value
        End Set
    End Property

    Public Sub New()
        htEROId = New Hashtable(0)
        htRespuestas = New Hashtable(0)
    End Sub
    Public Overrides Sub Recuperar()
        Dim sConsulta As String
        Dim dtPreg As DataTable

        sConsulta = "select CROId, TipoSeleccion, TipoLimite, Minimo, Maximo, Rotativa, Condicion, TipoLimite1, Minimo1, Maximo1, TipoConversion, Formato from CEPRespOpcional "
        sConsulta &= "where CENClave = '" & Me.CENClave & "' and CEPNumero = " & Me.CEPNumero

        dtPreg = oDBVen.RealizarConsultaSQL(sConsulta, "CEPRespOpcional")
        If dtPreg.Rows.Count > 0 Then
            Dim drPreg As DataRow
            drPreg = dtPreg.Rows(0)
            Me.CROId = drPreg("CROId")
            Me.TipoSeleccion = drPreg("TipoSeleccion")
            Me.TipoLimite = drPreg("TipoLimite")
            Me.Minimo = drPreg("Minimo")
            Me.Maximo = drPreg("Maximo")
            Me.Rotativa = drPreg("Rotativa")
            Me.Condicion = drPreg("Condicion")
            Me.TipoLimite1 = IIf(IsDBNull(drPreg("TipoLimite1")), 0, drPreg("TipoLimite1"))
            Me.Minimo1 = IIf(IsDBNull(drPreg("Minimo1")), 0, drPreg("Minimo1"))
            Me.Maximo1 = IIf(IsDBNull(drPreg("Maximo1")), 0, drPreg("Maximo1"))
            Me.TipoConversion = IIf(IsDBNull(drPreg("TipoConversion")), 0, drPreg("TipoConversion"))
            Me.Formato = IIf(IsDBNull(drPreg("Formato")), "", drPreg("Formato"))
            'Me.TipoTexto = IIf(IsDBNull(drPreg("TipoTexto")), "", drPreg("TipoTexto"))
            'Me.TipoMascara = IIf(IsDBNull(drPreg("TipoMascara")), 0, drPreg("TipoMascara"))
            'Me.Decimales = IIf(IsDBNull(drPreg("Decimales")), 0, drPreg("Decimales"))
            If Me.TipoSeleccion = 3 Then 'Numerico
                FormarFormatoNumero()
            End If
            'Condicion
            If Me.Condicion Then
                sConsulta = "select ROCId, CENClave1, CEPNumero1, TipoCondicion, TipoValor, Valor from CROCondicion "
                sConsulta &= "where CENClave = '" & Me.CENClave & "' and CEPNumero = " & Me.CEPNumero & " and CROId = '" & Me.CROId & "'"
                dtPreg = oDBVen.RealizarConsultaSQL(sConsulta, "CROCondicion")
                If dtPreg.Rows.Count > 0 Then
                    drPreg = dtPreg.Rows(0)
                    Me.ROCId = drPreg("ROCId")
                    Me.CENClave1 = drPreg("CENClave1")
                    Me.CEPNumero1 = drPreg("CEPNumero1")
                    Me.TipoCondicion = drPreg("TipoCondicion")
                    Me.TipoValor = drPreg("TipoValor")
                    Me.Valor = drPreg("Valor")
                End If
            End If
            'Opciones
            If Me.Rotar Then
                If Me.Rotativa Then
                    Me.RotarOpciones()
                End If
            End If
            sConsulta = "select COOId, Numero, Orden, Descripcion, Puntos from CROOpcion "
            sConsulta &= "where CENClave = '" & Me.CENClave & "' and CEPNumero = " & Me.CEPNumero & " and CROId = '" & Me.CROId & "' "
            sConsulta &= "order by Orden"
            Me.Opciones = oDBVen.RealizarConsultaSQL(sConsulta, "CROOpcion")
            'Respuestas
            If Me.ENCId <> "" And Me.ENPId <> "" Then
                sConsulta = "select EROId, COOId, Valor from ENPRespOpcional where ENCId = '" & Me.ENCId & "' and ENPId = '" & Me.ENPId & "'"
                dtPreg = oDBVen.RealizarConsultaSQL(sConsulta, "ENPRespOpcional")
                nPuntosAnt = 0
                For Each drActual As DataRow In dtPreg.Rows
                    Dim drPtos() As DataRow = Me.Opciones.Select("COOId = '" & drActual("COOId") & "'")
                    If drPtos.Length > 0 Then
                        nPuntosAnt += drPtos(0)("Puntos")
                    End If
                    EROId.Add(drActual("EROId"), drActual("COOId"))
                    Select Case Me.TipoSeleccion
                        Case 1 'Seleccion
                            AgregarOpcion(drActual("COOId"))
                        Case 2 'Texto
                            AgregarOpcion(drActual("COOId"), CStr(drActual("Valor")))
                        Case 3 'Numero
                            AgregarOpcion(drActual("COOId"), Double.Parse(drActual("Valor")))
                    End Select
                Next
            End If
        End If
        dtPreg.Dispose()
    End Sub
    Public Overrides Sub Recuperar(ByVal hash As Hashtable)
        If Not hash Is Nothing Then
            If hash.ContainsKey(Me.CEPNumero) Then
                Dim sConsulta As String

                Dim dtPreg As DataTable
                Dim drPreg As DataRow = hash.Item(Me.CEPNumero)
                Me.CROId = drPreg("CROId")
                Me.TipoSeleccion = drPreg("TipoSeleccion")
                Me.TipoLimite = drPreg("TipoLimite")
                Me.Minimo = drPreg("Minimo")
                Me.Maximo = drPreg("Maximo")
                Me.Rotativa = drPreg("Rotativa")
                Me.Condicion = drPreg("Condicion")
                Me.TipoLimite1 = IIf(IsDBNull(drPreg("TipoLimite1")), 0, drPreg("TipoLimite1"))
                Me.Minimo1 = IIf(IsDBNull(drPreg("Minimo1")), 0, drPreg("Minimo1"))
                Me.Maximo1 = IIf(IsDBNull(drPreg("Maximo1")), 0, drPreg("Maximo1"))
                Me.TipoConversion = IIf(IsDBNull(drPreg("TipoConversion")), 0, drPreg("TipoConversion"))
                Me.Formato = IIf(IsDBNull(drPreg("Formato")), "", drPreg("Formato"))
                'Me.TipoTexto = IIf(IsDBNull(drPreg("TipoTexto")), "", drPreg("TipoTexto"))
                'Me.TipoMascara = IIf(IsDBNull(drPreg("TipoMascara")), 0, drPreg("TipoMascara"))
                'Me.Decimales = IIf(IsDBNull(drPreg("Decimales")), 0, drPreg("Decimales"))
                If Me.TipoSeleccion = 3 Then 'Numerico
                    FormarFormatoNumero()
                End If
                'Condicion
                If Me.Condicion Then

                    sConsulta = "select ROCId, CENClave1, CEPNumero1, TipoCondicion, TipoValor, Valor from CROCondicion "
                    sConsulta &= "where CENClave = '" & Me.CENClave & "' and CEPNumero = " & Me.CEPNumero & " and CROId = '" & Me.CROId & "'"
                    dtPreg = oDBVen.RealizarConsultaSQL(sConsulta, "CROCondicion")
                    If dtPreg.Rows.Count > 0 Then
                        drPreg = dtPreg.Rows(0)
                        Me.ROCId = drPreg("ROCId")
                        Me.CENClave1 = drPreg("CENClave1")
                        Me.CEPNumero1 = drPreg("CEPNumero1")
                        Me.TipoCondicion = drPreg("TipoCondicion")
                        Me.TipoValor = drPreg("TipoValor")
                        Me.Valor = drPreg("Valor")
                    End If
                End If
                'Opciones
                If Me.Rotar Then
                    If Me.Rotativa Then
                        Me.RotarOpciones()
                    End If
                End If
                sConsulta = "select COOId, Numero, Orden, Descripcion, Puntos from CROOpcion "
                sConsulta &= "where CENClave = '" & Me.CENClave & "' and CEPNumero = " & Me.CEPNumero & " and CROId = '" & Me.CROId & "' "
                sConsulta &= "order by Orden"
                Me.Opciones = oDBVen.RealizarConsultaSQL(sConsulta, "CROOpcion")
                'Respuestas
                If Me.ENCId <> "" And Me.ENPId <> "" Then
                    sConsulta = "select EROId, COOId, Valor from ENPRespOpcional where ENCId = '" & Me.ENCId & "' and ENPId = '" & Me.ENPId & "'"
                    dtPreg = oDBVen.RealizarConsultaSQL(sConsulta, "ENPRespOpcional")
                    nPuntosAnt = 0
                    For Each drActual As DataRow In dtPreg.Rows
                        Dim drPtos() As DataRow = Me.Opciones.Select("COOId = '" & drActual("COOId") & "'")
                        If drPtos.Length > 0 Then
                            nPuntosAnt += drPtos(0)("Puntos")
                        End If
                        EROId.Add(drActual("EROId"), drActual("COOId"))
                        Select Case Me.TipoSeleccion
                            Case 1 'Seleccion
                                AgregarOpcion(drActual("COOId"))
                            Case 2 'Texto
                                AgregarOpcion(drActual("COOId"), CStr(drActual("Valor")))
                            Case 3 'Numero
                                AgregarOpcion(drActual("COOId"), Double.Parse(drActual("Valor")))
                        End Select
                    Next
                End If

                If Not dtPreg Is Nothing Then dtPreg.Dispose()

            End If
        End If
    End Sub

    Public Overrides Sub RecuperarRespuesta()
        Dim sConsulta As String
        Dim dtPreg As DataTable
        'Respuestas
        If Me.ENCId <> "" And Me.ENPId <> "" Then
            sConsulta = "select EROId, COOId, Valor from ENPRespOpcional where ENCId = '" & Me.ENCId & "' and ENPId = '" & Me.ENPId & "'"
            dtPreg = oDBVen.RealizarConsultaSQL(sConsulta, "ENPRespOpcional")
            nPuntosAnt = 0
            For Each drActual As DataRow In dtPreg.Rows
                Dim drPtos() As DataRow = Me.Opciones.Select("COOId = '" & drActual("COOId") & "'")
                If drPtos.Length > 0 Then
                    nPuntosAnt += drPtos(0)("Puntos")
                End If
                EROId.Add(drActual("EROId"), drActual("COOId"))
                Select Case Me.TipoSeleccion
                    Case 1 'Seleccion
                        AgregarOpcion(drActual("COOId"))
                    Case 2 'Texto
                        AgregarOpcion(drActual("COOId"), CStr(drActual("Valor")))
                    Case 3 'Numero
                        AgregarOpcion(drActual("COOId"), Double.Parse(drActual("Valor")))
                End Select
            Next
        End If
        dtPreg.Dispose()
    End Sub
    Public Overrides Sub ValidarRespuesta()
        If Me.RespuestaRequerida Then
            If htRespuestas.Count = 0 Then
                Throw New CEstado(TipoEstado.EError, "E0308")
                Cursor.Current = Cursors.Default
            End If
        End If
        If Me.TipoLimite = 2 Then
            If htRespuestas.Count > 0 Then
                If htRespuestas.Count < Me.Minimo Then
                    Throw New CEstado(TipoEstado.EError, "E0311")
                    Cursor.Current = Cursors.Default
                End If
                If htRespuestas.Count > Me.Maximo Then
                    Throw New CEstado(TipoEstado.EError, "E0311")
                    Cursor.Current = Cursors.Default
                End If
            End If
        End If
        Select Case Me.TipoSeleccion
            Case 2
                If Me.TipoConversion = 4 Then 'Fecha
                    For Each sKey As String In Me.Respuestas.Keys
                        Dim sFecha As String = Me.Respuestas(sKey)
                        ValidarFormatoFecha(sFecha)
                    Next
                Else
                    If Me.Formato <> "" Then
                        For Each sKey As String In Me.Respuestas.Keys
                            Dim sValor As String = Me.Respuestas(sKey)
                            ValidarFormatoTexto(sValor)
                        Next
                    Else
                        If Me.TipoLimite1 = 2 Then
                            For Each sKey As String In Me.Respuestas.Keys
                                ValidarOpcion(Me.Respuestas(sKey))
                            Next
                        End If
                    End If
                End If
            Case 3
                If Me.TipoLimite1 = 2 Then
                    For Each sKey As String In Me.Respuestas.Keys
                        ValidarOpcion(Me.Respuestas(sKey))
                    Next
                End If
        End Select
    End Sub

    Public Overrides Sub Insertar(ByVal pvENCId As String, ByVal pvOrdenAplicacion As Integer, ByVal pvSemilla As Integer)
        Dim i As Integer = 1
        Dim sComando As String
        Dim sEROId As String
        Dim sRespuesta As String
        Me.ValidarRespuesta()
        MyBase.Insertar(pvENCId, pvOrdenAplicacion, pvSemilla)
        nPuntosNvo = 0
        Dim drPtos() As DataRow
        Dim dtRespuestasExistentes As DataTable = oDBVen.RealizarConsultaSQL("Select COOId from ENPRespOpcional where ENCId='" & Me.ENCId & "' and ENPId='" & Me.ENPId & "' ", "Respuestas Anteriores")
        If dtRespuestasExistentes.Rows.Count > 0 Then
            dtRespuestasExistentes.Dispose()
            oDBVen.EjecutarComandoSQL("DELETE FROM EnpRespOpcional WHERE ENCId='" & Me.ENCId & "' and ENPId='" & Me.ENPId & "' ")
        End If

        For Each sKey As String In Me.Respuestas.Keys
            sEROId = oApp.KEYGEN(i)
            If Me.TipoSeleccion <> 1 Then
                sRespuesta = Me.Respuestas(sKey)
                If Me.TipoSeleccion = 2 Then 'Texto
                    ConvertirTexto(sRespuesta)
                End If
            Else
                sRespuesta = ""
            End If
            sRespuesta = sRespuesta.ToString.Replace("'", "''")
            sComando = String.Format("insert into ENPRespOpcional (ENCId, ENPId, EROId, CENClave, CEPNumero, CROId, COOId, Valor, MFechaHora, MUsuarioId) values('{0}','{1}','{2}','{3}',{4},'{5}','{6}','{7}',{8},'{9}')", Me.ENCId, Me.ENPId, sEROId, Me.CENClave, Me.CEPNumero, Me.CROId, sKey, sRespuesta, UniFechaSQL(Now), oVendedor.UsuarioId)
            oDBVen.EjecutarComandoSQL(sComando)
            drPtos = Me.Opciones.Select("COOId = '" & sKey & "'")
            If drPtos.Length > 0 Then
                nPuntosNvo += drPtos(0)("Puntos")
            End If
            i += 1
        Next
        'If Me.Rotativa Then
        '    RotarOpciones()
        'End If
    End Sub
    Public Overrides Sub Eliminar(ByVal pvENCId As String, ByVal pvENPId As String)
        Dim sComando As String
        sComando = String.Format("delete ENPRespOpcional where ENCId='{0}' and ENPId ='{1}'", pvENCId, pvENPId)
        oDBVen.EjecutarComandoSQL(sComando)
        MyBase.Eliminar(pvENCId, pvENPId)
    End Sub
    Public Function ValidarCondicion() As Boolean
        'TipoCondicion
        '=, >, >=, <, <=, <>
        'TipoValor
        'Numero de Respuestas, Respuesta Numero
        Dim sCOOId As String = ""
        If TipoValor = 2 Then
            Dim drOpc() As DataRow
            drOpc = dtOpciones.Select("Numero = " & Me.Valor)
            If drOpc.Length > 0 Then
                sCOOId = drOpc(0).Item("COOId")
            End If
        End If

        If Condicion Then
            Select Case TipoCondicion
                Case 1 '=
                    Select Case TipoValor
                        Case 1 'Numero de Respuestas
                            Return Me.Respuestas.Count = Me.Valor
                        Case 2 'Respuesta Numero
                            Return Me.Respuestas.Contains(sCOOId)
                    End Select
                Case 2 '>
                    Select Case TipoValor
                        Case 1 'Numero de Respuestas
                            Return Me.Respuestas.Count > Me.Valor
                        Case 2 'Respuesta Numero
                            'No aplica la validacion para este caso
                    End Select
                Case 3 '>=
                    Select Case TipoValor
                        Case 1 'Numero de Respuestas
                            Return Me.Respuestas.Count >= Me.Valor
                        Case 2 'Respuesta Numero
                            'No aplica la validacion para este caso
                    End Select
                Case 4 '<
                    Select Case TipoValor
                        Case 1 'Numero de Respuestas
                            Return Me.Respuestas.Count < Me.Valor
                        Case 2 'Respuesta Numero
                            'No aplica la validacion para este caso
                    End Select
                Case 5 '<=
                    Select Case TipoValor
                        Case 1 'Numero de Respuestas
                            Return Me.Respuestas.Count <= Me.Valor
                        Case 2 'Respuesta Numero
                            'No aplica la validacion para este caso
                    End Select
                Case 6 '<>
                    Select Case TipoValor
                        Case 1 'Numero de Respuestas
                            Return Me.Respuestas.Count <> Me.Valor
                        Case 2 'Respuesta Numero
                            Return Not Me.Respuestas.Contains(sCOOId)
                    End Select
            End Select
        End If
        Return False
    End Function
    Public Overloads Sub AgregarOpcion(ByVal pvCOOId As String)
        If Not htRespuestas.Contains(pvCOOId) Then
            htRespuestas.Add(pvCOOId, pvCOOId)
        End If
    End Sub
    Public Overloads Sub AgregarOpcion(ByVal pvCOOId As String, ByRef prValor As String)
        If Me.TipoConversion <> 4 Then
            If Not htRespuestas.Contains(pvCOOId) Then
                htRespuestas.Add(pvCOOId, prValor)
            Else
                htRespuestas(pvCOOId) = prValor
            End If
            If Me.Formato <> "" Then
                ValidarFormatoTexto(prValor)
                htRespuestas(pvCOOId) = prValor
            Else
                ValidarOpcion(prValor)
            End If
        Else
            If Not htRespuestas.Contains(pvCOOId) Then
                htRespuestas.Add(pvCOOId, prValor)
            Else
                htRespuestas(pvCOOId) = prValor
            End If
            ValidarFormatoFecha(prValor)
            htRespuestas(pvCOOId) = prValor
        End If
    End Sub
    Public Overloads Sub AgregarOpcion(ByVal pvCOOId As String, ByVal pvValor As Double)
        If Not htRespuestas.Contains(pvCOOId) Then
            htRespuestas.Add(pvCOOId, pvValor)
        Else
            htRespuestas(pvCOOId) = pvValor
        End If
        ValidarOpcion(pvValor)
    End Sub
    Private Sub FormarFormatoNumero()
        If Me.Formato <> "" Then
            Dim sMasc As String = Me.Formato
            Dim nPrimero As Integer
            Dim nUltimo As Integer
            Dim nCant As Integer
            Dim sChar As Char() = {"0", "#", ".", ","}
            nPrimero = sMasc.IndexOfAny(sChar)
            nUltimo = sMasc.LastIndexOfAny(sChar)
            nCant = sMasc.Length - nPrimero - (sMasc.Length - (nUltimo + 1))
            Me.FormatoNumerico = sMasc.Substring(nPrimero, nCant)
            If nPrimero > 0 Then
                Me.PrefijoFormato = sMasc.Substring(0, nPrimero)
            End If
            If nUltimo < sMasc.Length - 1 Then
                Me.sSufijoFormato = sMasc.Substring(nUltimo + 1, (sMasc.Length - (nUltimo + 1)))
            End If
        End If
    End Sub
    Private Sub ValidarOpcion(ByVal pvValor As String)
        If Me.TipoLimite1 = 2 Then
            Select Case Me.TipoSeleccion
                Case 2 'Texto
                    If pvValor.Length < Me.Minimo1 Or pvValor.Length > Me.Maximo1 Then
                        Throw New CEstado(TipoEstado.EError, "E0309")
                        Cursor.Current = Cursors.Default
                    End If
                Case 3 'Numero
                    If Double.Parse(pvValor) < Me.Minimo1 Or Decimal.Parse(pvValor) > Me.Maximo1 Then
                        Throw New CEstado(TipoEstado.EError, "E0309")
                        Cursor.Current = Cursors.Default
                    End If
            End Select
        End If
    End Sub
    Private Sub ValidarFormatoFecha(ByRef prValor As String)
        If Me.TipoSeleccion = 2 Then 'Texto
            If Me.TipoConversion = 4 Then 'Fecha
                'Validar formato de fecha: dd/MM/yyyy 
                Dim sFecha() As String
                sFecha = prValor.Split("/")
                If sFecha.Length <> 3 Then
                    'TODO: Cambiar mensaje "Formato de fecha incorrecto: 'dd/MM/yyyy'"
                    Throw New CEstado(TipoEstado.EError, "E0554")
                    Cursor.Current = Cursors.Default
                End If
                Try
                    Dim dFecha As New Date(Integer.Parse(sFecha(2)), Integer.Parse(sFecha(1)), Integer.Parse(sFecha(0)))
                    prValor = ConvertirFormatoFecha(Integer.Parse(sFecha(0)), Integer.Parse(sFecha(1)), Integer.Parse(sFecha(2)))
                Catch ex As Exception
                    'TODO: Cambiar mensaje "Formato de fecha incorrecto: 'dd/MM/yyyy'"
                    Throw New CEstado(TipoEstado.EError, "E0554")
                    Cursor.Current = Cursors.Default
                End Try
            End If
        End If
    End Sub
    Private Function ConvertirFormatoFecha(ByVal pvDia As Integer, ByVal pvMes As Integer, ByVal pvAnio As Integer) As String
        Dim sFecha As String
        Dim sAnio As String
        Select Case pvAnio.ToString.Length
            Case 1
                sAnio = Today.Date.Year.ToString.Chars(0) & Today.Date.Year.ToString.Chars(1) & Today.Date.Year.ToString.Chars(2)
                sFecha = Format(pvDia, "00") & "/" & Format(pvMes, "00") & "/" & Format(pvAnio, sAnio & "0")
            Case 2
                sAnio = Today.Date.Year.ToString.Chars(0) & Today.Date.Year.ToString.Chars(1)
                sFecha = Format(pvDia, "00") & "/" & Format(pvMes, "00") & "/" & Format(pvAnio, sAnio & "00")
            Case 3
                sAnio = Today.Date.Year.ToString.Chars(0)
                sFecha = Format(pvDia, "00") & "/" & Format(pvMes, "00") & "/" & Format(pvAnio, sAnio & "00")
            Case Else
                sFecha = Format(pvDia, "00") & "/" & Format(pvMes, "00") & "/" & Format(pvAnio, "0000")
        End Select
        Return sFecha
    End Function
    Private Sub ValidarFormatoTexto(ByRef prValor As String)
        If Me.Formato <> "" Then
            Dim sMasc As String = Me.Formato
            Dim sValorFinal As String = ""
            Dim sCaracter As Char
            Dim bValido As Boolean = True
            Dim nCont As Integer = 0
            If prValor.Length <> sMasc.Length Then
                Throw New CEstado(TipoEstado.EError, "E0554")
                Cursor.Current = Cursors.Default
            End If

            While nCont < sMasc.Length And bValido
                sCaracter = prValor.Chars(nCont)
                Select Case sMasc.Chars(nCont)
                    Case "A"
                        If Char.IsLetter(sCaracter) Then
                            sValorFinal &= Char.ToUpper(sCaracter)
                        Else
                            bValido = False
                        End If
                    Case "a"
                        If Char.IsLetter(sCaracter) Then
                            sValorFinal &= Char.ToLower(sCaracter)
                        Else
                            bValido = False
                        End If
                    Case "y"
                        If Char.IsLetter(sCaracter) Then
                            sValorFinal &= sCaracter
                        Else
                            bValido = False
                        End If
                    Case "X"
                        If Char.IsLetterOrDigit(sCaracter) Then
                            sValorFinal &= Char.ToUpper(sCaracter)
                        Else
                            bValido = False
                        End If
                    Case "x"
                        If Char.IsLetterOrDigit(sCaracter) Then
                            sValorFinal &= Char.ToLower(sCaracter)
                        Else
                            bValido = False
                        End If
                    Case "Y"
                        If Char.IsLetterOrDigit(sCaracter) Then
                            sValorFinal &= sCaracter
                        Else
                            bValido = False
                        End If
                    Case "9"
                        If Char.IsDigit(sCaracter) Then
                            sValorFinal &= sCaracter
                        Else
                            bValido = False
                        End If
                    Case "z"
                        sValorFinal &= sCaracter
                    Case Else
                        If sCaracter = sMasc.Chars(nCont) Then
                            sValorFinal &= sCaracter
                        Else
                            bValido = False
                        End If
                End Select
                nCont += 1
            End While

            If Not bValido Then
                Throw New CEstado(TipoEstado.EError, "E0554")
                Cursor.Current = Cursors.Default
            Else
                prValor = sValorFinal
            End If
        End If
    End Sub

    Public Sub ConvertirTexto(ByRef prValor As String)
        If Me.Formato <> "" Then
            Dim sPalabras() As String
            Select Case Me.TipoConversion
                Case 1 'Minusculas
                    prValor = prValor.ToLower()
                Case 2 'Mayusculas
                    prValor = prValor.ToUpper()
                Case 3 'Titulo
                    prValor = LCase(prValor)
                    sPalabras = prValor.Split()
                    prValor = ""
                    For Each sPalabra As String In sPalabras
                        sPalabra = Replace(sPalabra, Mid(sPalabra, 1, 1), UCase(Mid(sPalabra, 1, 1)), 1, 1)
                        prValor &= sPalabra & " "
                    Next
                    prValor = prValor.Trim()
            End Select
        End If
    End Sub
    Public Sub EliminarOpcion(ByVal pvCOOId)
        If htRespuestas.Contains(pvCOOId) Then
            htRespuestas.Remove(pvCOOId)
        End If
    End Sub
    Public Sub RotarOpciones()
        Dim sComando As String
        Dim nMax As Integer
        Dim nMin As Integer
        sComando = String.Format("select max(Orden) from CROOpcion where CENClave = '{0}' and CEPNumero = {1}", Me.CENClave, Me.CEPNumero)
        nMax = oDBVen.EjecutarCmdScalarIntSQL(sComando)
        sComando = String.Format("select min(Orden) from CROOpcion where CENClave = '{0}' and CEPNumero = {1}", Me.CENClave, Me.CEPNumero)
        nMin = oDBVen.EjecutarCmdScalarIntSQL(sComando)
        sComando = String.Format("update CROOpcion set Orden = (case when Orden > {0} then Orden - 1 else {1} end) where CENClave = '{2}' and CEPNumero = {3}", nMin, nMax, Me.CENClave, Me.CEPNumero)
        oDBVen.EjecutarComandoSQL(sComando)
    End Sub
End Class

Public Class cPreguntaCodigo
    Inherits cPregunta

    Private sCRCId As String
    Private nCodigoLeido As Integer
    Private nTipoCodigo As Integer
    Private sERCId As String
    Private sRespuesta As String

    Public Property CRCId() As String
        Get
            Return sCRCId
        End Get
        Set(ByVal Value As String)
            sCRCId = Value
        End Set
    End Property
    Public Property CodigoLeido() As Integer
        Get
            Return nCodigoLeido
        End Get
        Set(ByVal value As Integer)
            nCodigoLeido = value
        End Set
    End Property
    Public Property TipoCodigo() As Integer
        Get
            Return nTipoCodigo
        End Get
        Set(ByVal Value As Integer)
            nTipoCodigo = Value
        End Set
    End Property
    Public ReadOnly Property CodigoEquivalente() As Integer
        Get
            Select Case nTipoCodigo
                Case 1 'CODE11
                    Select Case oApp.ModeloTerminal
                        Case "SymbolC9090", "SymbolMC50", "SymbolMC70"
                            Return 50
                        Case "HHP7600", "HHP7900"
                            Return 2
                    End Select
                Case 2 'CODE39
                    Select Case oApp.ModeloTerminal
                        Case "SymbolC9090", "SymbolMC50", "SymbolMC70"
                            Return 55
                        Case "HHP7600", "HHP7900"
                            Return 4
                    End Select
                Case 3 'CODE128
                    Select Case oApp.ModeloTerminal
                        Case "SymbolC9090", "SymbolMC50", "SymbolMC70"
                            Return 60
                        Case "HHP7600", "HHP7900"
                            Return 3
                    End Select
                Case 4 'EAN13
                    Select Case oApp.ModeloTerminal
                        Case "SymbolC9090", "SymbolMC50", "SymbolMC70"
                            Return 53
                        Case "HHP7600", "HHP7900"
                            Return 10
                    End Select
                Case 5 'EAN8
                    Select Case oApp.ModeloTerminal
                        Case "SymbolC9090", "SymbolMC50", "SymbolMC70"
                            Return 52
                        Case "HHP7600", "HHP7900"
                            Return 9
                    End Select
            End Select
            Return 0
        End Get
    End Property
    Public Property ERCId() As String
        Get
            Return sERCId
        End Get
        Set(ByVal Value As String)
            sERCId = Value
        End Set
    End Property
    Public Property Respuesta() As String
        Get
            Return sRespuesta
        End Get
        Set(ByVal Value As String)
            sRespuesta = Value
        End Set
    End Property

    Public Overrides Sub Recuperar()
        Dim sConsulta As String
        Dim dtPreg As DataTable
        sConsulta = "select CRCId, TipoCodigo from CEPRespCodigo "
        sConsulta &= "where CENClave = '" & Me.CENClave & "' and CEPNumero = " & Me.CEPNumero
        dtPreg = oDBVen.RealizarConsultaSQL(sConsulta, "CEPRespCodigo")
        If dtPreg.Rows.Count > 0 Then
            Dim drPreg As DataRow
            drPreg = dtPreg.Rows(0)
            Me.CRCId = drPreg("CRCId")
            Me.TipoCodigo = drPreg("TipoCodigo")
            Me.CodigoLeido = 0
            'Respuesta()
            If Me.ENCId <> "" And Me.ENPId <> "" Then
                sConsulta = "select ERCId, Codigo from ENPRespCodigo where ENCId = '" & Me.ENCId & "' and ENPId = '" & Me.ENPId & "'"
                dtPreg = oDBVen.RealizarConsultaSQL(sConsulta, "ENPRespNumero")
                If dtPreg.Rows.Count > 0 Then
                    ERCId = dtPreg.Rows(0)("ERCId")
                    Respuesta = dtPreg.Rows(0)("Codigo")
                End If
            End If
        End If
        dtPreg.Dispose()
    End Sub
    Public Overrides Sub Recuperar(ByVal hash As Hashtable)
        If hash Is Nothing Then Exit Sub

        If hash.ContainsKey(Me.CEPNumero) Then
            Dim drPreg As DataRow = hash.Item(Me.CEPNumero)
            Me.CRCId = drPreg("CRCId")
            Me.TipoCodigo = drPreg("TipoCodigo")
            Me.CodigoLeido = 0
            'Respuesta
            If Me.ENCId <> "" And Me.ENPId <> "" Then
                Dim sConsulta As String
                Dim dtPreg As DataTable
                sConsulta = "select ERCId, Codigo from ENPRespCodigo where ENCId = '" & Me.ENCId & "' and ENPId = '" & Me.ENPId & "'"
                dtPreg = oDBVen.RealizarConsultaSQL(sConsulta, "ENPRespNumero")
                If dtPreg.Rows.Count > 0 Then
                    ERCId = dtPreg.Rows(0)("ERCId")
                    Respuesta = dtPreg.Rows(0)("Codigo")
                End If
                dtPreg.Dispose()
            End If
        End If

    End Sub
    Public Overrides Sub RecuperarRespuesta()
        Dim sConsulta As String
        Dim dtPreg As DataTable
        'Respuesta
        If Me.ENCId <> "" And Me.ENPId <> "" Then
            sConsulta = "select ERCId, Codigo from ENPRespCodigo where ENCId = '" & Me.ENCId & "' and ENPId = '" & Me.ENPId & "'"
            dtPreg = oDBVen.RealizarConsultaSQL(sConsulta, "ENPRespNumero")
            If dtPreg.Rows.Count > 0 Then
                ERCId = dtPreg.Rows(0)("ERCId")
                Respuesta = dtPreg.Rows(0)("Codigo")
            End If
        End If
        dtPreg.Dispose()
    End Sub
    Public Overrides Sub ValidarRespuesta()
        If Me.RespuestaRequerida Then
            If Me.Respuesta = "" Then
                Throw New CEstado(TipoEstado.EError, "E0308")
            End If
        End If
        If Me.TipoCodigo <> 0 And Me.CodigoLeido <> 0 Then
            Select Case oApp.ModeloTerminal
                Case "SymbolC9090", "SymbolMC50", "SymbolMC70"
                    If Me.CodigoLeido <> Me.CodigoEquivalente Then
                        'TODO: Cambiar codigo de error
                        Throw New CEstado(TipoEstado.EError, "E0545")
                    End If
            End Select
        End If
    End Sub
    Public Overrides Sub Insertar(ByVal pvENCId As String, ByVal pvOrdenAplicacion As Integer, ByVal pvSemilla As Integer)
        Dim sComando As String
        Me.ValidarRespuesta()
        MyBase.Insertar(pvENCId, pvOrdenAplicacion, pvSemilla)
        If Me.ERCId = "" Then
            Me.ERCId = oApp.KEYGEN(1)
            sComando = String.Format("insert into ENPRespCodigo (ENCId, ENPId, ERCId, Codigo, MFechaHora, MUsuarioId) values('{0}','{1}','{2}','{3}',{4},'{5}')", Me.ENCId, Me.ENPId, Me.ERCId, Me.Respuesta, UniFechaSQL(Now), oVendedor.UsuarioId)
        Else
            sComando = String.Format("Update ENPRespCodigo set Codigo='{0}', MFechaHora = getdate(), MUsuarioId='{1}' Where ENCId='{2}' and ENPId ='{3}' and ERCId = '{4}' ", Me.Respuesta, oVendedor.UsuarioId, Me.ENCId, Me.ENPId, Me.ERCId)
        End If
        oDBVen.EjecutarComandoSQL(sComando)
    End Sub
    Public Overrides Sub Eliminar(ByVal pvENCId As String, ByVal pvENPId As String)
        Dim sComando As String
        sComando = String.Format("delete ENPRespCodigo where ENCId='{0}' and ENPId ='{1}'", pvENCId, pvENPId)
        oDBVen.EjecutarComandoSQL(sComando)
        MyBase.Eliminar(pvENCId, pvENPId)
    End Sub
End Class

Public Class cPreguntaImagen
    Inherits cPregunta

    Private sCRIId As String
    Private nCalidad As Integer
    Private sERIId As String
    Private aRespuesta As String

    Public Property CRIId() As String
        Get
            Return sCRIId
        End Get
        Set(ByVal Value As String)
            sCRIId = Value
        End Set
    End Property
    Public Property Calidad() As Integer
        Get
            Return nCalidad
        End Get
        Set(ByVal Value As Integer)
            nCalidad = Value
        End Set
    End Property
    Public Property ERIId() As String
        Get
            Return sERIId
        End Get
        Set(ByVal Value As String)
            sERIId = Value
        End Set
    End Property
    Public Property Respuesta() As String
        Get
            Return aRespuesta
        End Get
        Set(ByVal Value As String)
            aRespuesta = Value
        End Set
    End Property

    Public Overrides Sub Recuperar()
        Dim sConsulta As String
        Dim dtPreg As DataTable
        sConsulta = "select CRIId, Calidad from CEPRespImagen "
        sConsulta &= "where CENClave = '" & Me.CENClave & "' and CEPNumero = " & Me.CEPNumero
        dtPreg = oDBVen.RealizarConsultaSQL(sConsulta, "CEPRespImagen")
        If dtPreg.Rows.Count > 0 Then
            Dim drPreg As DataRow
            drPreg = dtPreg.Rows(0)
            Me.CRIId = drPreg("CRIId")
            Me.Calidad = drPreg("Calidad")
            'Respuesta
            If Me.ENCId <> "" And Me.ENPId <> "" Then
                sConsulta = "select ERIId, Imagen from ENPRespImagen where ENCId = '" & Me.ENCId & "' and ENPId = '" & Me.ENPId & "'"
                dtPreg = oDBVen.RealizarConsultaSQL(sConsulta, "ENPRespImagen")
                If dtPreg.Rows.Count > 0 Then
                    ERIId = dtPreg.Rows(0)("ERIId")
                    If Not IsDBNull(dtPreg.Rows(0)("Imagen")) Then
                        Respuesta = dtPreg.Rows(0)("Imagen")
                    Else
                        Respuesta = Nothing
                    End If
                End If
            End If
        End If
        dtPreg.Dispose()
    End Sub
    Public Overrides Sub Recuperar(ByVal hash As Hashtable)
        If hash Is Nothing Then Exit Sub

        If hash.ContainsKey(Me.CEPNumero) Then
            Dim drPreg As DataRow = hash.Item(Me.CEPNumero)

            Me.CRIId = drPreg("CRIId")
            Me.Calidad = drPreg("Calidad")
            'Respuesta
            If Me.ENCId <> "" And Me.ENPId <> "" Then
                Dim sConsulta As String
                Dim dtPreg As DataTable
                sConsulta = "select ERIId, Imagen from ENPRespImagen where ENCId = '" & Me.ENCId & "' and ENPId = '" & Me.ENPId & "'"
                dtPreg = oDBVen.RealizarConsultaSQL(sConsulta, "ENPRespImagen")
                If dtPreg.Rows.Count > 0 Then
                    ERIId = dtPreg.Rows(0)("ERIId")
                    If Not IsDBNull(dtPreg.Rows(0)("Imagen")) Then
                        Respuesta = dtPreg.Rows(0)("Imagen")
                    Else
                        Respuesta = Nothing
                    End If
                End If
                dtPreg.Dispose()
            End If
        End If

    End Sub
    Public Overrides Sub RecuperarRespuesta()
        Dim sConsulta As String
        Dim dtPreg As DataTable
        'Respuesta
        If Me.ENCId <> "" And Me.ENPId <> "" Then
            sConsulta = "select ERIId, Imagen from ENPRespImagen where ENCId = '" & Me.ENCId & "' and ENPId = '" & Me.ENPId & "'"
            dtPreg = oDBVen.RealizarConsultaSQL(sConsulta, "ENPRespImagen")
            If dtPreg.Rows.Count > 0 Then
                ERIId = dtPreg.Rows(0)("ERIId")
                If Not IsDBNull(dtPreg.Rows(0)("Imagen")) Then
                    Respuesta = dtPreg.Rows(0)("Imagen")
                Else
                    Respuesta = Nothing
                End If
            End If
            dtPreg.Dispose()
        Else
            Respuesta = Nothing
        End If
    End Sub
    Public Overrides Sub ValidarRespuesta()
        If Me.RespuestaRequerida Then
            If Me.Respuesta Is Nothing Then
                Throw New CEstado(TipoEstado.EError, "E0308")
            End If
        End If
    End Sub
    Public Overrides Sub Insertar(ByVal pvENCId As String, ByVal pvOrdenAplicacion As Integer, ByVal pvSemilla As Integer)
        Dim sComando As String
        Me.ValidarRespuesta()
        MyBase.Insertar(pvENCId, pvOrdenAplicacion, pvSemilla)
        If Not Me.Respuesta Is Nothing Then
            Dim htParams As New Hashtable
            If Me.ERIId = "" Then
                Me.ERIId = oApp.KEYGEN(1)
                sComando = String.Format("insert into ENPRespImagen (ENCId, ENPId, ERIId, Imagen, MFechaHora, MUsuarioId) values('{0}','{1}','{2}',@Imagen,{3},'{4}')", Me.ENCId, Me.ENPId, Me.ERIId, UniFechaSQL(Now), oVendedor.UsuarioId)
            Else
                sComando = String.Format("Update ENPRespImagen set Imagen=@Imagen, MFechaHora = getdate(), MUsuarioId='{0}' Where ENCId='{1}' and ENPId ='{2}' and ERIId = '{3}' ", oVendedor.UsuarioId, Me.ENCId, Me.ENPId, Me.ERIId)
            End If
            Dim aParam As New ArrayList
            aParam.Add(7) 'SqlDbType.Image
            aParam.Add(Me.Respuesta)
            htParams.Add("@Imagen", aParam)
            oDBVen.EjecutarComandoSQLParams(sComando, htParams)
        End If
    End Sub
    Public Overrides Sub Eliminar(ByVal pvENCId As String, ByVal pvENPId As String)
        Dim sComando As String
        sComando = String.Format("delete ENPRespImagen where ENCId='{0}' and ENPId ='{1}'", pvENCId, pvENPId)
        oDBVen.EjecutarComandoSQL(sComando)
        MyBase.Eliminar(pvENCId, pvENPId)
    End Sub

End Class

Public Class cPreguntaMatricial
#Region "cPreguntaMatricial"
    Inherits cPregunta
    Dim oCOLPreguntas As cColPreguntasMat
    Dim oCOLRespuestas As cColRespuestasMat
    Dim oCOLSeleccionados As cColSeleccionadosMat

    Public ReadOnly Property PreguntasMat() As cColPreguntasMat
        Get
            Return oCOLPreguntas
        End Get
    End Property
    Public ReadOnly Property RespuestasMat() As cColRespuestasMat
        Get
            Return oCOLRespuestas
        End Get
    End Property
    Public ReadOnly Property SeleccionadosMat() As cColSeleccionadosMat
        Get
            Return oCOLSeleccionados
        End Get
    End Property

    Public Overrides Sub Recuperar()
        Dim sConsulta As String
        Dim dtPreg As DataTable
        oCOLPreguntas = New cColPreguntasMat
        oCOLRespuestas = New cColRespuestasMat
        oCOLSeleccionados = New cColSeleccionadosMat

        sConsulta = "select CPMNumero, Descripcion from CEPPregMatricial "
        sConsulta &= "where CENClave = '" & Me.CENClave & "' and CEPNumero = " & Me.CEPNumero & " "
        sConsulta &= "order by Orden"
        dtPreg = oDBVen.RealizarConsultaSQL(sConsulta, "CEPPregMatricial")
        If dtPreg.Rows.Count > 0 Then
            For Each drPreg As DataRow In dtPreg.Rows
                Dim oCPM As New cPreguntaMat
                oCPM.CPMNumero = drPreg("CPMNumero")
                oCPM.MatDescripcion = drPreg("Descripcion")
                oCOLPreguntas.Add(oCPM)
            Next
        End If
        sConsulta = "select CRMNumero, Descripcion, TipoValor from CEPRespMatricial "
        sConsulta &= "where CENClave = '" & Me.CENClave & "' and CEPNumero = " & Me.CEPNumero & " "
        sConsulta &= "order by Orden"
        dtPreg = oDBVen.RealizarConsultaSQL(sConsulta, "CEPRespMatricial")
        If dtPreg.Rows.Count > 0 Then
            For Each drPreg As DataRow In dtPreg.Rows
                Dim oCRM As New cRespuestaMat
                oCRM.CRMNumero = drPreg("CRMNumero")
                oCRM.MatDescripcion = drPreg("Descripcion")
                oCRM.TipoValor = drPreg("TipoValor")
                oCOLRespuestas.Add(oCRM)
            Next
        End If
        'Respuestas
        If Me.ENCId <> "" And Me.ENPId <> "" Then
            sConsulta = "select CPMNumero, CRMNumero, Valor from ENPRespMatricial "
            sConsulta &= "where CENClave = '" & Me.CENClave & "' and CEPNumero = " & Me.CEPNumero & " "
            sConsulta &= "and ENCId = '" & Me.ENCId & "' and ENPId = '" & Me.ENPId & "' "
            dtPreg = oDBVen.RealizarConsultaSQL(sConsulta, "ENPRespMatricial")
            If dtPreg.Rows.Count > 0 Then
                For Each drPreg As DataRow In dtPreg.Rows
                    Dim oCSM As New cSeleccionadoMat
                    oCSM.CPMNumero = drPreg("CPMNumero")
                    oCSM.CRMNumero = drPreg("CRMNumero")
                    oCSM.Valor = IIf(IsDBNull(drPreg("Valor")), "", drPreg("Valor"))
                    oCOLSeleccionados.Add(oCSM)
                Next
            End If
        End If
        dtPreg.Dispose()
    End Sub
    Public Overrides Sub Recuperar(ByVal hColeccion As Hashtable)
        oCOLPreguntas = New cColPreguntasMat
        oCOLRespuestas = New cColRespuestasMat
        oCOLSeleccionados = New cColSeleccionadosMat

        Dim hPregMatricial As Hashtable = hColeccion.Item(1) 'Matriz de Preguntas
        If hPregMatricial.ContainsKey(Me.CEPNumero) Then
            Dim arr As ArrayList = hPregMatricial.Item(Me.CEPNumero)
            For Each drPreg As DataRow In arr
                Dim oCPM As New cPreguntaMat
                oCPM.CPMNumero = drPreg("CPMNumero")
                oCPM.MatDescripcion = drPreg("Descripcion")
                oCOLPreguntas.Add(oCPM)
            Next
        End If

        Dim hRespMatricial As Hashtable = hColeccion.Item(2) 'Matriz de Respuestas
        If hRespMatricial.ContainsKey(Me.CEPNumero) Then
            Dim arr As ArrayList = hRespMatricial.Item(Me.CEPNumero)
            For Each drPreg As DataRow In arr
                Dim oCRM As New cRespuestaMat
                oCRM.CRMNumero = drPreg("CRMNumero")
                oCRM.MatDescripcion = drPreg("Descripcion")
                oCRM.TipoValor = drPreg("TipoValor")
                oCOLRespuestas.Add(oCRM)
            Next
        End If

        'Respuestas
        If Me.ENCId <> "" And Me.ENPId <> "" Then
            Dim sConsulta As String
            Dim dtPreg As DataTable
            sConsulta = "select CPMNumero, CRMNumero, Valor from ENPRespMatricial "
            sConsulta &= "where CENClave = '" & Me.CENClave & "' and CEPNumero = " & Me.CEPNumero & " "
            sConsulta &= "and ENCId = '" & Me.ENCId & "' and ENPId = '" & Me.ENPId & "' "
            dtPreg = oDBVen.RealizarConsultaSQL(sConsulta, "ENPRespMatricial")
            If dtPreg.Rows.Count > 0 Then
                For Each drPreg As DataRow In dtPreg.Rows
                    Dim oCSM As New cSeleccionadoMat
                    oCSM.CPMNumero = drPreg("CPMNumero")
                    oCSM.CRMNumero = drPreg("CRMNumero")
                    oCSM.Valor = IIf(IsDBNull(drPreg("Valor")), "", drPreg("Valor"))
                    oCOLSeleccionados.Add(oCSM)
                Next
            End If
            dtPreg.Dispose()
        End If

    End Sub
    Public Overrides Sub RecuperarRespuesta()
        Dim sConsulta As String
        Dim dtPreg As DataTable
        oCOLSeleccionados = New cColSeleccionadosMat
        'Respuestas
        If Me.ENCId <> "" And Me.ENPId <> "" Then
            sConsulta = "select CPMNumero, CRMNumero, Valor from ENPRespMatricial "
            sConsulta &= "where CENClave = '" & Me.CENClave & "' and CEPNumero = " & Me.CEPNumero & " "
            sConsulta &= "and ENCId = '" & Me.ENCId & "' and ENPId = '" & Me.ENPId & "' "
            dtPreg = oDBVen.RealizarConsultaSQL(sConsulta, "ENPRespMatricial")
            If dtPreg.Rows.Count > 0 Then
                For Each drPreg As DataRow In dtPreg.Rows
                    Dim oCSM As New cSeleccionadoMat
                    oCSM.CPMNumero = drPreg("CPMNumero")
                    oCSM.CRMNumero = drPreg("CRMNumero")
                    oCSM.Valor = IIf(IsDBNull(drPreg("Valor")), "", drPreg("Valor"))
                    oCOLSeleccionados.Add(oCSM)
                Next
            End If
        End If
        dtPreg.Dispose()
    End Sub

    Private Function ValidarMinimoRespuestas()
        Dim aPregs As New ArrayList
        For Each oCSM As cSeleccionadoMat In oCOLSeleccionados
            If Not aPregs.Contains(oCSM.CPMNumero) Then
                aPregs.Add(oCSM.CPMNumero)
            End If
        Next
        Return (aPregs.Count >= Me.CantidadRequerida)
    End Function

    Public Overrides Sub ValidarRespuesta()
        If Me.RespuestaRequerida Then
            If Me.oCOLSeleccionados.Count = 0 Then
                Throw New CEstado(TipoEstado.EError, "E0308")
            End If
        End If
        If Not ValidarMinimoRespuestas() Then
            Throw New CEstado(TipoEstado.EError, "E0712")
        End If
    End Sub
    Public Overrides Sub Insertar(ByVal pvENCId As String, ByVal pvOrdenAplicacion As Integer, ByVal pvSemilla As Integer)
        Dim i As Integer = 1
        Dim sComando As String
        Dim sERMId As String
        Me.ValidarRespuesta()
        MyBase.Insertar(pvENCId, pvOrdenAplicacion, pvSemilla)
        oDBVen.EjecutarComandoSQL("DELETE FROM EnpRespMatricial WHERE ENCId='" & Me.ENCId & "' and ENPId='" & Me.ENPId & "' ")

        For Each oSel As cSeleccionadoMat In oCOLSeleccionados
            sERMId = oApp.KEYGEN(i)
            If oSel.Valor <> "" Then
                oSel.Valor = oSel.Valor.Replace("'", "''")
            End If
            sComando = String.Format("insert into ENPRespMatricial (ENCId, ENPId, ERMId, CENClave, CEPNumero, CPMNumero, CENClave1, CEPNumero1, CRMNumero, Valor, MFechaHora, MUsuarioId) values('{0}','{1}','{2}','{3}',{4},{5},'{6}',{7},{8},{9},{10},'{11}')", Me.ENCId, Me.ENPId, sERMId, Me.CENClave, Me.CEPNumero, oSel.CPMNumero, Me.CENClave, Me.CEPNumero, oSel.CRMNumero, IIf(oSel.Valor = "", "NULL", "'" & oSel.Valor & "'"), UniFechaSQL(Now), oVendedor.UsuarioId)
            oDBVen.EjecutarComandoSQL(sComando)
            i += 1
        Next
    End Sub
    Public Overrides Sub Eliminar(ByVal pvENCId As String, ByVal pvENPId As String)
        Dim sComando As String
        sComando = String.Format("delete ENPRespMatricial where ENCId='{0}' and ENPId ='{1}'", pvENCId, pvENPId)
        oDBVen.EjecutarComandoSQL(sComando)
        MyBase.Eliminar(pvENCId, pvENPId)
    End Sub
#End Region

    Public Class cPreguntaMat
        Private nCPMNumero As Integer
        Private sDescripcion As String

        Public Property CPMNumero() As Integer
            Get
                Return nCPMNumero
            End Get
            Set(ByVal Value As Integer)
                nCPMNumero = Value
            End Set
        End Property
        Public Property MatDescripcion() As String
            Get
                Return sDescripcion
            End Get
            Set(ByVal Value As String)
                sDescripcion = Value
            End Set
        End Property
    End Class

    Public Class cRespuestaMat
        Private nCRMNumero As Integer
        Private sDescripcion As String
        Private nTipoValor As Integer

        Public Property CRMNumero() As Integer
            Get
                Return nCRMNumero
            End Get
            Set(ByVal Value As Integer)
                nCRMNumero = Value
            End Set
        End Property
        Public Property MatDescripcion() As String
            Get
                Return sDescripcion
            End Get
            Set(ByVal Value As String)
                sDescripcion = Value
            End Set
        End Property
        Public Property TipoValor() As Integer
            Get
                Return nTipoValor
            End Get
            Set(ByVal value As Integer)
                nTipoValor = value
            End Set
        End Property

    End Class

    Public Class cSeleccionadoMat
        Private nCPMNumero As Integer
        Private nCRMNumero As Integer
        Private sValor As String

        Public Property CPMNumero() As Integer
            Get
                Return nCPMNumero
            End Get
            Set(ByVal Value As Integer)
                nCPMNumero = Value
            End Set
        End Property
        Public Property CRMNumero() As Integer
            Get
                Return nCRMNumero
            End Get
            Set(ByVal Value As Integer)
                nCRMNumero = Value
            End Set
        End Property
        Public Property Valor() As String
            Get
                Return sValor
            End Get
            Set(ByVal value As String)
                sValor = value
            End Set
        End Property
    End Class

    Public Class cColPreguntasMat
        Inherits CollectionBase
        Public Sub New()

        End Sub

        Default Public Property Item(ByVal index As Integer) As cPreguntaMat
            Get
                Return CType(List(index - 1), cPreguntaMat)
            End Get
            Set(ByVal Value As cPreguntaMat)
                List(index - 1) = Value
            End Set
        End Property

        Public Function GetItem(ByVal pvCPMNumero As Integer) As cPreguntaMat
            For i As Integer = 0 To List.Count - 1
                Dim tmpPregunta As cPreguntaMat = List(i)
                If (tmpPregunta.CPMNumero = pvCPMNumero) Then
                    Return CType(List(i), cPreguntaMat)
                End If
            Next
            Return Nothing
        End Function

        Public Function Add(ByVal value As cPreguntaMat) As Integer
            Return List.Add(value)
        End Function
        Public Sub Insert(ByVal index As Integer, ByVal value As cPreguntaMat)
            List.Insert(index, value)
        End Sub
        Public Sub Remove(ByVal value As cPreguntaMat)
            List.Remove(value)
        End Sub
    End Class

    Public Class cColRespuestasMat
        Inherits CollectionBase
        Public Sub New()

        End Sub

        Default Public Property Item(ByVal index As Integer) As cRespuestaMat
            Get
                Return CType(List(index - 1), cRespuestaMat)
            End Get
            Set(ByVal Value As cRespuestaMat)
                List(index - 1) = Value
            End Set
        End Property
        Public Function GetItem(ByVal pvCRMNumero As Integer) As cRespuestaMat
            For i As Integer = 0 To List.Count - 1
                Dim tmpPregunta As cRespuestaMat = List(i)
                If (tmpPregunta.CRMNumero = pvCRMNumero) Then
                    Return CType(List(i), cRespuestaMat)
                End If
            Next
            Return Nothing
        End Function

        Public Function Add(ByVal value As cRespuestaMat) As Integer
            Return List.Add(value)
        End Function
        Public Sub Insert(ByVal index As Integer, ByVal value As cRespuestaMat)
            List.Insert(index, value)
        End Sub
        Public Sub Remove(ByVal value As cRespuestaMat)
            List.Remove(value)
        End Sub
    End Class

    Public Class cColSeleccionadosMat
        Inherits CollectionBase
        Public Sub New()

        End Sub

        Default Public Property Item(ByVal index As Integer) As cSeleccionadoMat
            Get
                Return CType(List(index - 1), cSeleccionadoMat)
            End Get
            Set(ByVal Value As cSeleccionadoMat)
                List(index - 1) = Value
            End Set
        End Property
        Public Function Add(ByVal value As cSeleccionadoMat) As Integer
            Return List.Add(value)
        End Function
        Public Function Add(ByVal CPMNumero As Integer, ByVal CRMNumero As Integer, ByVal Valor As String) As Integer
            Dim oSel As New cSeleccionadoMat
            oSel.CPMNumero = CPMNumero
            oSel.CRMNumero = CRMNumero
            oSel.Valor = Valor
            Return List.Add(oSel)
        End Function
        Public Sub Insert(ByVal index As Integer, ByVal value As cSeleccionadoMat)
            List.Insert(index, value)
        End Sub
        Public Sub Remove(ByVal value As cSeleccionadoMat)
            List.Remove(value)
        End Sub
        Public Sub Remove(ByVal CPMNumero As Integer, ByVal CRMNumero As Integer)
            For Each oSel As cSeleccionadoMat In Me
                If oSel.CPMNumero = CPMNumero And oSel.CRMNumero = CRMNumero Then
                    List.Remove(oSel)
                    Exit For
                End If
            Next
        End Sub
        Public Function Exists(ByVal CPMNumero As Integer, ByVal CRMNumero As Integer) As Boolean
            For Each oSel As cSeleccionadoMat In Me
                If oSel.CPMNumero = CPMNumero And oSel.CRMNumero = CRMNumero Then
                    Return True
                End If
            Next
            Return False
        End Function
    End Class
End Class

Public Class cPreguntaSalto
    Inherits cPregunta

    Private sCRSId As String
    Private sCENClave1 As String
    Private nCEPNumero1 As Integer 'Pregunta condicion
    Private sCENClave2 As String
    Private nCEPNumero2 As Integer 'Pregunta siguiente
    Private sCENClave3 As String
    Private nCEPNumero3 As Integer 'Siguiente condicion
    Private sCRSId1 As String
    Private nTipoOperadorSig As Integer
    Private nTipoCondicion As Integer
    Private sValor As String
    Private nTipoValor As Integer
    Private nTipoCanOpcion As Integer
    Private bTerminar As Boolean
    Private oPregCondicion As cPregunta
    Private sENPId1 As String
    Public oConPreg As cConsultaPreguntas

    Public Property CRSId() As String
        Get
            Return sCRSId
        End Get
        Set(ByVal value As String)
            sCRSId = value
        End Set
    End Property
    Public Property CENClave1() As String
        Get
            Return sCENClave1
        End Get
        Set(ByVal value As String)
            sCENClave1 = value
        End Set
    End Property
    Public Property CEPNumero1() As Integer
        Get
            Return nCEPNumero1
        End Get
        Set(ByVal value As Integer)
            nCEPNumero1 = value
        End Set
    End Property
    Public Property CENClave2() As String
        Get
            Return sCENClave2
        End Get
        Set(ByVal value As String)
            sCENClave2 = value
        End Set
    End Property
    Public Property CEPNumero2() As Integer
        Get
            Return nCEPNumero2
        End Get
        Set(ByVal value As Integer)
            nCEPNumero2 = value
        End Set
    End Property
    Public Property CENClave3() As String
        Get
            Return sCENClave3
        End Get
        Set(ByVal value As String)
            sCENClave3 = value
        End Set
    End Property
    Public Property CEPNumero3() As Integer
        Get
            Return nCEPNumero3
        End Get
        Set(ByVal value As Integer)
            nCEPNumero3 = value
        End Set
    End Property
    Public Property CRSId1() As String
        Get
            Return sCRSId1
        End Get
        Set(ByVal value As String)
            sCRSId1 = value
        End Set
    End Property
    Public Property TipoOperadorSig() As Integer
        Get
            Return nTipoOperadorSig
        End Get
        Set(ByVal value As Integer)
            nTipoOperadorSig = value
        End Set
    End Property
    Public Property TipoCondicion() As Integer
        Get
            Return nTipoCondicion
        End Get
        Set(ByVal value As Integer)
            nTipoCondicion = value
        End Set
    End Property
    Public Property Valor() As String
        Get
            Return sValor
        End Get
        Set(ByVal value As String)
            sValor = value
        End Set
    End Property
    Public Property TipoValor() As Integer
        Get
            Return nTipoValor
        End Get
        Set(ByVal value As Integer)
            nTipoValor = value
        End Set
    End Property
    Public Property TipoCanOpcion() As Integer
        Get
            Return nTipoCanOpcion
        End Get
        Set(ByVal value As Integer)
            nTipoCanOpcion = value
        End Set
    End Property
    Public Property Terminar() As Boolean
        Get
            Return bTerminar
        End Get
        Set(ByVal value As Boolean)
            bTerminar = value
        End Set
    End Property
    Public Property ENPId1() As String
        Get
            Return sENPId1
        End Get
        Set(ByVal value As String)
            sENPId1 = value
        End Set
    End Property

    Public Overrides Sub Recuperar()
        Dim sConsulta As String
        Dim dtPreg As DataTable
        sConsulta = "select CRSId, CENClave1, CEPNumero1, CENClave2, CEPNumero2, CENClave3, CEPNumero3, CRSId1, "
        sConsulta &= "TipoOperadorSig, TipoCondicion, Valor, TipoValor, TipoCanOpcion, Terminar from CEPRespSalto "
        sConsulta &= "where CENClave = '" & Me.CENClave & "' and CEPNumero = " & Me.CEPNumero
        dtPreg = oDBVen.RealizarConsultaSQL(sConsulta, "CEPRespSalto")
        If dtPreg.Rows.Count > 0 Then
            Dim drPreg As DataRow
            drPreg = dtPreg.Rows(0)
            Me.CRSId = drPreg("CRSId")
            Me.CENClave1 = IIf(IsDBNull(drPreg("CENClave1")), "", drPreg("CENClave1"))
            Me.CEPNumero1 = IIf(IsDBNull(drPreg("CEPNumero1")), 0, drPreg("CEPNumero1"))
            Me.CENClave2 = IIf(IsDBNull(drPreg("CENClave2")), "", drPreg("CENClave2"))
            Me.CEPNumero2 = IIf(IsDBNull(drPreg("CEPNumero2")), 0, drPreg("CEPNumero2"))
            Me.CENClave3 = IIf(IsDBNull(drPreg("CENClave3")), "", drPreg("CENClave3"))
            Me.CEPNumero3 = IIf(IsDBNull(drPreg("CEPNumero3")), 0, drPreg("CEPNumero3"))
            Me.CRSId1 = IIf(IsDBNull(drPreg("CRSId1")), "", drPreg("CRSId1"))
            Me.TipoOperadorSig = IIf(IsDBNull(drPreg("TipoOperadorSig")), 0, drPreg("TipoOperadorSig"))
            Me.TipoCondicion = IIf(IsDBNull(drPreg("TipoCondicion")), 0, drPreg("TipoCondicion"))
            Me.Valor = IIf(IsDBNull(drPreg("Valor")), "", drPreg("Valor"))
            Me.TipoValor = IIf(IsDBNull(drPreg("TipoValor")), 0, drPreg("TipoValor"))
            Me.TipoCanOpcion = IIf(IsDBNull(drPreg("TipoCanOpcion")), 0, drPreg("TipoCanOpcion"))
            Me.Terminar = IIf(IsDBNull(drPreg("Terminar")), False, drPreg("Terminar"))
        End If
        dtPreg.Dispose()
    End Sub
    Public Overrides Sub Recuperar(ByVal hash As Hashtable)
        If hash Is Nothing Then Exit Sub

        If hash.ContainsKey(Me.CEPNumero) Then
            Dim drPreg As DataRow = hash.Item(Me.CEPNumero)
            Me.CRSId = drPreg.Item("CRSId")
            Me.CENClave1 = IIf(IsDBNull(drPreg.Item("CENClave1")), "", drPreg.Item("CENClave1"))
            Me.CEPNumero1 = IIf(IsDBNull(drPreg.Item("CEPNumero1")), 0, drPreg.Item("CEPNumero1"))
            Me.CENClave2 = IIf(IsDBNull(drPreg.Item("CENClave2")), "", drPreg.Item("CENClave2"))
            Me.CEPNumero2 = IIf(IsDBNull(drPreg.Item("CEPNumero2")), 0, drPreg.Item("CEPNumero2"))
            Me.CENClave3 = IIf(IsDBNull(drPreg.Item("CENClave3")), "", drPreg.Item("CENClave3"))
            Me.CEPNumero3 = IIf(IsDBNull(drPreg.Item("CEPNumero3")), 0, drPreg.Item("CEPNumero3"))
            Me.CRSId1 = IIf(IsDBNull(drPreg.Item("CRSId1")), "", drPreg.Item("CRSId1"))
            Me.TipoOperadorSig = IIf(IsDBNull(drPreg.Item("TipoOperadorSig")), 0, drPreg.Item("TipoOperadorSig"))
            Me.TipoCondicion = IIf(IsDBNull(drPreg.Item("TipoCondicion")), 0, drPreg.Item("TipoCondicion"))
            Me.Valor = IIf(IsDBNull(drPreg.Item("Valor")), "", drPreg.Item("Valor"))
            Me.TipoValor = IIf(IsDBNull(drPreg.Item("TipoValor")), 0, drPreg.Item("TipoValor"))
            Me.TipoCanOpcion = IIf(IsDBNull(drPreg.Item("TipoCanOpcion")), 0, drPreg.Item("TipoCanOpcion"))
            Me.Terminar = IIf(IsDBNull(drPreg.Item("Terminar")), False, drPreg.Item("Terminar"))
        End If

        'dtPreg.Dispose()
    End Sub
    Public Overrides Sub RecuperarRespuesta()
        Dim sConsulta As String
        Dim nTipoRespCondicion As Integer
        Dim dtResul As DataTable

        sConsulta = String.Format("select TipoRespuesta from CENPregunta where CENClave = '{0}' and CEPNumero = {1}", Me.CENClave1, Me.CEPNumero1)
        nTipoRespCondicion = oDBVen.RealizarScalarSQL(sConsulta)

        sConsulta = String.Format("select ENPId from ENCPregunta where ENCId = '{0}' and CENClave = '{1}' and CEPNumero = {2}", Me.ENCId, Me.CENClave1, Me.CEPNumero1)
        dtResul = oDBVen.RealizarConsultaSQL(sConsulta, "ENCPregunta")
        If dtResul.Rows.Count > 0 Then
            Me.ENPId1 = dtResul.Rows(0)("ENPId")
        End If
        Dim hash As Hashtable
        Select Case nTipoRespCondicion
            Case 1 'Texto
                oPregCondicion = New cPreguntaTexto
                hash = oConPreg.PreguntaTexto
            Case 2 'Numero
                oPregCondicion = New cPreguntaNumero
                hash = oConPreg.PreguntaNumero
            Case 3 'Opcional
                oPregCondicion = New cPreguntaOpcional
                hash = oConPreg.PreguntaOpcional
            Case 4 'Codigo
                oPregCondicion = New cPreguntaCodigo
                hash = oConPreg.PreguntaCodigo
            Case 5 'Imagen
                oPregCondicion = New cPreguntaImagen
                hash = oConPreg.PreguntaImagen
            Case 6 'Matricial
                oPregCondicion = New cPreguntaMatricial
                hash = oConPreg.RespuestaMatricial

        End Select
        If Not oPregCondicion Is Nothing Then
            oPregCondicion.TipoRespuesta = nTipoRespCondicion
            oPregCondicion.CENClave = Me.CENClave1
            oPregCondicion.CEPNumero = Me.CEPNumero1
            oPregCondicion.ENCId = Me.ENCId
            oPregCondicion.ENPId = Me.ENPId1
            oPregCondicion.Recuperar(hash)
        End If
        If Not hash Is Nothing Then hash = Nothing
    End Sub
    Public Overrides Sub ValidarRespuesta()

    End Sub

    Public Function Validar() As Boolean
        Dim bValido As Boolean
        RecuperarRespuesta()
        Select Case oPregCondicion.TipoRespuesta
            Case 1 'Texto
                bValido = ValidaTexto()
            Case 2 'Numero
                bValido = ValidaNumero()
            Case 3 'Opcional
                bValido = ValidaOpcional()
            Case 4 'Codigo
                bValido = ValidaCodigo()
            Case 5 'Imagen
                bValido = ValidaImagen()
            Case 6 'Matricial
                bValido = ValidaMatricial()
        End Select
        If Me.TipoOperadorSig <> 0 Then
            Dim oSaltoSig As New cPreguntaSalto
            oSaltoSig.CENClave = Me.CENClave3
            oSaltoSig.CEPNumero = Me.CEPNumero3
            oSaltoSig.Asignar(Me.CENClave3, Me.CEPNumero3, "", 7, 0, 0, 0, 0, Me.ENCId)
            oSaltoSig.Recuperar(oConPreg.PreguntaSalto)
            Select Case Me.TipoOperadorSig
                Case 1 'y
                    oSaltoSig.oConPreg = Me.oConPreg
                    bValido = bValido And oSaltoSig.Validar
                Case 2 'o
                    oSaltoSig.oConPreg = Me.oConPreg
                    bValido = bValido Or oSaltoSig.Validar
            End Select
        End If
        Return bValido
    End Function

    Private Function ValidaTexto() As Boolean
        Dim oPreg As cPreguntaTexto
        oPreg = Me.oPregCondicion
        Select Case Me.TipoCondicion
            Case 1 'Igual
                Return (oPreg.Respuesta = Me.Valor)
            Case 2 'Diferente
                Return (oPreg.Respuesta <> Me.Valor)
            Case 3 'Contenga
                Return (oPreg.Respuesta.IndexOf(Me.Valor, StringComparison.CurrentCulture) >= 0)
        End Select
        Return False
    End Function
    Private Function ValidaNumero() As Boolean
        Dim oPreg As cPreguntaNumero
        oPreg = Me.oPregCondicion
        Select Case Me.TipoCondicion
            Case 4 'Igual
                Return (Math.Round(Double.Parse(oPreg.Respuesta), 2) = Math.Round(Double.Parse(Me.Valor), 2))
            Case 5 'Mayor
                Return (Math.Round(Double.Parse(oPreg.Respuesta), 2) > Math.Round(Double.Parse(Me.Valor), 2))
            Case 6 'Mayor o igual
                Return (Math.Round(Double.Parse(oPreg.Respuesta), 2) >= Math.Round(Double.Parse(Me.Valor), 2))
            Case 7 'Menor
                Return (Math.Round(Double.Parse(oPreg.Respuesta), 2) < Math.Round(Double.Parse(Me.Valor), 2))
            Case 8 'Menor o igual
                Return (Math.Round(Double.Parse(oPreg.Respuesta), 2) <= Math.Round(Double.Parse(Me.Valor), 2))
            Case 9 'Diferente
                Return (Math.Round(Double.Parse(oPreg.Respuesta), 2) <> Math.Round(Double.Parse(Me.Valor), 2))
        End Select
        Return False
    End Function
    Private Function ValidaOpcional() As Boolean
        Dim oPreg As cPreguntaOpcional
        Dim bValido As Boolean
        oPreg = Me.oPregCondicion
        Select Case Me.TipoValor
            Case 1 'Numero de opciones
                Select Case Me.TipoCondicion
                    Case 4 'Igual
                        Return (oPreg.Respuestas.Count = Integer.Parse(Me.Valor))
                    Case 5 'Mayor
                        Return (oPreg.Respuestas.Count > Integer.Parse(Me.Valor))
                    Case 6 'Mayor o igual
                        Return (oPreg.Respuestas.Count >= Integer.Parse(Me.Valor))
                    Case 7 'Menor
                        Return (oPreg.Respuestas.Count < Integer.Parse(Me.Valor))
                    Case 8 'Menor o igual
                        Return (oPreg.Respuestas.Count <= Integer.Parse(Me.Valor))
                    Case 9 'Diferente
                        Return (oPreg.Respuestas.Count <> Integer.Parse(Me.Valor))
                End Select
            Case 2 'Valor de las opciones
                Select Case oPreg.TipoSeleccion
                    Case 1 'Seleccion
                        Dim sCOOId As String = ""
                        Dim sConsulta As String = ""
                        Dim drOpc As DataRow()
                        drOpc = oPreg.Opciones.Select("Numero = " & Me.Valor)
                        If drOpc.Length > 0 Then
                            sCOOId = drOpc(0).Item("COOId")
                        End If
                        Select Case Me.TipoCondicion
                            Case 10 'Igual
                                Return oPreg.Respuestas.Contains(sCOOId)
                            Case 11 'Diferente
                                Return Not oPreg.Respuestas.Contains(sCOOId)
                        End Select
                    Case 2 'Texto
                        Select Case Me.TipoCondicion
                            Case 1, 2 'Igual, Diferente
                                Select Case Me.TipoCanOpcion
                                    Case 1, 3 'Todas, Ninguna
                                        If oPreg.Respuestas.Count > 0 Then
                                            bValido = True
                                            If (Me.TipoCanOpcion = 1 And Me.TipoCondicion = 1) Or (Me.TipoCanOpcion = 3 And Me.TipoCondicion = 2) Then
                                                'Todas iguales o Ninguna diferente
                                                For Each sKey As String In oPreg.Respuestas.Keys
                                                    bValido = bValido And (oPreg.Respuestas(sKey) = Me.Valor)
                                                Next
                                            ElseIf (Me.TipoCanOpcion = 1 And Me.TipoCondicion = 2) Or (Me.TipoCanOpcion = 3 And Me.TipoCondicion = 1) Then
                                                'Todas diferentes o Ninguna igual
                                                For Each sKey As String In oPreg.Respuestas.Keys
                                                    bValido = bValido And (oPreg.Respuestas(sKey) <> Me.Valor)
                                                Next
                                            End If
                                            Return bValido
                                        Else
                                            Return False
                                        End If
                                    Case 2 'Al menos una
                                        If Me.TipoCondicion = 1 Then 'Igual
                                            For Each sKey As String In oPreg.Respuestas.Keys
                                                If oPreg.Respuestas(sKey) = Me.Valor Then
                                                    Return True
                                                End If
                                            Next
                                        Else 'Diferente
                                            For Each sKey As String In oPreg.Respuestas.Keys
                                                If oPreg.Respuestas(sKey) <> Me.Valor Then
                                                    Return True
                                                End If
                                            Next
                                        End If
                                        Return False
                                End Select
                            Case 3 'Contenga
                                Select Case Me.TipoCanOpcion
                                    Case 1, 3 'Todas, Ninguna
                                        If oPreg.Respuestas.Count > 0 Then
                                            bValido = True
                                            If Me.TipoCanOpcion = 1 Then 'Todas
                                                For Each sKey As String In oPreg.Respuestas.Keys
                                                    bValido = bValido And (oPreg.Respuestas(sKey).ToString.IndexOf(Me.Valor, StringComparison.CurrentCulture) >= 0)
                                                Next
                                            Else 'Ninguna
                                                For Each sKey As String In oPreg.Respuestas.Keys
                                                    bValido = bValido And (oPreg.Respuestas(sKey).ToString.IndexOf(Me.Valor, StringComparison.CurrentCulture) < 0)
                                                Next
                                            End If
                                            Return bValido
                                        Else
                                            Return False
                                        End If
                                    Case 2 'Al menos una
                                        For Each sKey As String In oPreg.Respuestas.Keys
                                            If oPreg.Respuestas(sKey).ToString.IndexOf(Me.Valor, StringComparison.CurrentCulture) >= 0 Then
                                                Return True
                                            End If
                                        Next
                                        Return False
                                End Select
                        End Select
                    Case 3 'Numero
                        Select Case Me.TipoCondicion
                            Case 4, 9 'Igual, Diferente
                                Select Case Me.TipoCanOpcion
                                    Case 1, 3 'Todas, Ninguna
                                        If oPreg.Respuestas.Count > 0 Then
                                            bValido = True
                                            If (Me.TipoCanOpcion = 1 And Me.TipoCondicion = 4) Or (Me.TipoCanOpcion = 3 And Me.TipoCondicion = 9) Then
                                                'Todas iguales o Ninguna diferente
                                                For Each sKey As String In oPreg.Respuestas.Keys
                                                    bValido = bValido And (Math.Round(Double.Parse(oPreg.Respuestas(sKey)), 2) = Math.Round(Double.Parse(Me.Valor)))
                                                Next
                                            ElseIf (Me.TipoCanOpcion = 1 And Me.TipoCondicion = 9) Or (Me.TipoCanOpcion = 3 And Me.TipoCondicion = 4) Then
                                                'Todas diferentes o Ninguna igual
                                                For Each sKey As String In oPreg.Respuestas.Keys
                                                    bValido = bValido And (Math.Round(Double.Parse(oPreg.Respuestas(sKey)), 2) <> Math.Round(Double.Parse(Me.Valor)))
                                                Next
                                            End If
                                            Return bValido
                                        Else
                                            Return False
                                        End If
                                    Case 2 'Al menos una
                                        If Me.TipoCondicion = 4 Then 'Igual
                                            For Each sKey As String In oPreg.Respuestas.Keys
                                                If Math.Round(Double.Parse(oPreg.Respuestas(sKey)), 2) = Math.Round(Double.Parse(Me.Valor)) Then
                                                    Return True
                                                End If
                                            Next
                                        Else 'Diferente
                                            For Each sKey As String In oPreg.Respuestas.Keys
                                                If Math.Round(Double.Parse(oPreg.Respuestas(sKey)), 2) <> Math.Round(Double.Parse(Me.Valor)) Then
                                                    Return True
                                                End If
                                            Next
                                        End If
                                        Return False
                                End Select
                            Case 5, 8 'Mayor, Menor o igual
                                Select Case Me.TipoCanOpcion
                                    Case 1, 3 'Todas, Ninguna
                                        If oPreg.Respuestas.Count > 0 Then
                                            bValido = True
                                            If (Me.TipoCanOpcion = 1 And Me.TipoCondicion = 5) Or (Me.TipoCanOpcion = 3 And Me.TipoCondicion = 8) Then
                                                'Todas mayores o Ninguna menor o igual
                                                For Each sKey As String In oPreg.Respuestas.Keys
                                                    bValido = bValido And (Math.Round(Double.Parse(oPreg.Respuestas(sKey)), 2) > Math.Round(Double.Parse(Me.Valor)))
                                                Next
                                            ElseIf (Me.TipoCanOpcion = 3 And Me.TipoCondicion = 5) Or (Me.TipoCanOpcion = 1 And Me.TipoCondicion = 8) Then
                                                'Ninguna mayor o Todas menor o igual
                                                For Each sKey As String In oPreg.Respuestas.Keys
                                                    bValido = bValido And (Math.Round(Double.Parse(oPreg.Respuestas(sKey)), 2) <= Math.Round(Double.Parse(Me.Valor)))
                                                Next
                                            End If
                                            Return bValido
                                        Else
                                            Return False
                                        End If
                                    Case 2 'Al menos una
                                        If Me.TipoCondicion = 5 Then 'Mayor
                                            For Each sKey As String In oPreg.Respuestas.Keys
                                                If Math.Round(Double.Parse(oPreg.Respuestas(sKey)), 2) > Math.Round(Double.Parse(Me.Valor)) Then
                                                    Return True
                                                End If
                                            Next
                                        Else 'Menor o igual
                                            For Each sKey As String In oPreg.Respuestas.Keys
                                                If Math.Round(Double.Parse(oPreg.Respuestas(sKey)), 2) <= Math.Round(Double.Parse(Me.Valor)) Then
                                                    Return True
                                                End If
                                            Next
                                        End If
                                        Return False
                                End Select
                            Case 6, 7 'Mayor o igual, Menor
                                Select Case Me.TipoCanOpcion
                                    Case 1, 3 'Todas, Ninguna
                                        If oPreg.Respuestas.Count > 0 Then
                                            bValido = True
                                            If (Me.TipoCanOpcion = 1 And Me.TipoCondicion = 6) Or (Me.TipoCanOpcion = 3 And Me.TipoCondicion = 7) Then
                                                'Todas mayor o igual o Ninguna menor
                                                For Each sKey As String In oPreg.Respuestas.Keys
                                                    bValido = bValido And (Math.Round(Double.Parse(oPreg.Respuestas(sKey)), 2) >= Math.Round(Double.Parse(Me.Valor)))
                                                Next
                                            ElseIf (Me.TipoCanOpcion = 3 And Me.TipoCondicion = 6) Or (Me.TipoCanOpcion = 1 And Me.TipoCondicion = 7) Then
                                                'Ninguna mayor o igual o Todas menor
                                                For Each sKey As String In oPreg.Respuestas.Keys
                                                    bValido = bValido And (Math.Round(Double.Parse(oPreg.Respuestas(sKey)), 2) < Math.Round(Double.Parse(Me.Valor)))
                                                Next
                                            End If
                                            Return bValido
                                        Else
                                            Return False
                                        End If
                                    Case 2 'Al menos una
                                        If Me.TipoCondicion = 6 Then 'Mayor o igual
                                            For Each sKey As String In oPreg.Respuestas.Keys
                                                If Math.Round(Double.Parse(oPreg.Respuestas(sKey)), 2) >= Math.Round(Double.Parse(Me.Valor)) Then
                                                    Return True
                                                End If
                                            Next
                                        Else 'Menor 
                                            For Each sKey As String In oPreg.Respuestas.Keys
                                                If Math.Round(Double.Parse(oPreg.Respuestas(sKey)), 2) < Math.Round(Double.Parse(Me.Valor)) Then
                                                    Return True
                                                End If
                                            Next
                                        End If
                                        Return False
                                End Select
                        End Select
                End Select
        End Select
        Return False
    End Function
    Private Function ValidaCodigo() As Boolean
        Dim oPreg As cPreguntaCodigo
        oPreg = Me.oPregCondicion
        Select Case Me.TipoCondicion
            Case 1 'Igual
                Return (oPreg.Respuesta = Me.Valor)
            Case 2 'Diferente
                Return (oPreg.Respuesta <> Me.Valor)
            Case 3 'Contenga
                Return (oPreg.Respuesta.IndexOf(Me.Valor, StringComparison.CurrentCulture) >= 0)
        End Select
        Return False
    End Function
    Private Function ValidaImagen() As Boolean
        Dim oPreg As cPreguntaImagen
        oPreg = Me.oPregCondicion
        Return Not oPreg.Respuesta Is Nothing
    End Function
    Private Function ValidaMatricial() As Boolean
        Dim oPreg As cPreguntaMatricial
        oPreg = Me.oPregCondicion
        Select Case Me.TipoValor
            Case 1 'Numero de opciones
                Select Case Me.TipoCondicion
                    Case 4 'Igual
                        Return (oPreg.SeleccionadosMat.Count = Integer.Parse(Me.Valor))
                    Case 5 'Mayor
                        Return (oPreg.SeleccionadosMat.Count > Integer.Parse(Me.Valor))
                    Case 6 'Mayor o igual
                        Return (oPreg.SeleccionadosMat.Count >= Integer.Parse(Me.Valor))
                    Case 7 'Menor
                        Return (oPreg.SeleccionadosMat.Count < Integer.Parse(Me.Valor))
                    Case 8 'Menor o igual
                        Return (oPreg.SeleccionadosMat.Count <= Integer.Parse(Me.Valor))
                    Case 9 'Diferente
                        Return (oPreg.SeleccionadosMat.Count <> Integer.Parse(Me.Valor))
                End Select
            Case 2 'Valor de las opciones
                Dim nCPMNumero As Integer
                Dim nCRMNumero As Integer
                Dim sValores As String()
                sValores = Me.Valor.Split(",")
                nCPMNumero = sValores(0)
                nCRMNumero = sValores(1)
                Select Case Me.TipoCondicion
                    Case 10 'Igual
                        For Each oSel As cPreguntaMatricial.cSeleccionadoMat In oPreg.SeleccionadosMat
                            If (oSel.CPMNumero = nCPMNumero) And (oSel.CRMNumero = nCRMNumero) Then
                                Return True
                            End If
                        Next
                        Return False
                    Case 11 'Diferente
                        If oPreg.SeleccionadosMat.Count > 0 Then
                            Dim bValido As Boolean = True
                            For Each oSel As cPreguntaMatricial.cSeleccionadoMat In oPreg.SeleccionadosMat
                                bValido = bValido And ((oSel.CPMNumero <> nCPMNumero) And (oSel.CRMNumero <> nCRMNumero))
                            Next
                            Return bValido
                        Else
                            Return False
                        End If
                End Select
        End Select
        Return False
    End Function

End Class

Public Class cPreguntaGPS
    Inherits cPregunta

    Private sCRGId As String
    Private bAltitud As Boolean
    Private bLatitud As Boolean
    Private bLongitud As Boolean
    Private bFecha As Boolean
    Private bHora As Boolean
    Private sERGId As String
    Private nAltitud As Decimal
    Private nLatitud As Decimal
    Private nLongitud As Decimal
    Private dFecha As Date
    Private dHora As DateTime

    Public Property CRGId() As String
        Get
            Return sCRGId
        End Get
        Set(ByVal Value As String)
            sCRGId = Value
        End Set
    End Property
    Public Property Altitud() As Boolean
        Get
            Return bAltitud
        End Get
        Set(ByVal Value As Boolean)
            bAltitud = Value
        End Set
    End Property
    Public Property Latitud() As Boolean
        Get
            Return bLatitud
        End Get
        Set(ByVal Value As Boolean)
            bLatitud = Value
        End Set
    End Property
    Public Property Longitud() As Boolean
        Get
            Return bLongitud
        End Get
        Set(ByVal Value As Boolean)
            bLongitud = Value
        End Set
    End Property
    Public Property Fecha() As Boolean
        Get
            Return bFecha
        End Get
        Set(ByVal Value As Boolean)
            bFecha = Value
        End Set
    End Property
    Public Property Hora() As Boolean
        Get
            Return bHora
        End Get
        Set(ByVal Value As Boolean)
            bHora = Value
        End Set
    End Property
    Public Property ERGId() As String
        Get
            Return sERGId
        End Get
        Set(ByVal Value As String)
            sERGId = Value
        End Set
    End Property
    Public Property RespAltitud() As Decimal
        Get
            Return nAltitud
        End Get
        Set(ByVal Value As Decimal)
            nAltitud = Value
        End Set
    End Property
    Public Property RespLatitud() As Decimal
        Get
            Return nLatitud
        End Get
        Set(ByVal Value As Decimal)
            nLatitud = Value
        End Set
    End Property
    Public Property RespLongitud() As Decimal
        Get
            Return nLongitud
        End Get
        Set(ByVal Value As Decimal)
            nLongitud = Value
        End Set
    End Property
    Public Property RespFecha() As Date
        Get
            Return dFecha
        End Get
        Set(ByVal Value As Date)
            dFecha = Value
        End Set
    End Property
    Public Property RespHora() As DateTime
        Get
            Return dHora
        End Get
        Set(ByVal Value As DateTime)
            dHora = Value
        End Set
    End Property

    Public Overrides Sub Recuperar()
        Dim sConsulta As String
        Dim dtPreg As DataTable
        sConsulta = "select CRGId, Altitud, Latitud, Longitud, Fecha, Hora from CEPRespGPS "
        sConsulta &= "where CENClave = '" & Me.CENClave & "' and CEPNumero = " & Me.CEPNumero
        dtPreg = oDBVen.RealizarConsultaSQL(sConsulta, "CEPRespGPS")
        If dtPreg.Rows.Count > 0 Then
            Dim drPreg As DataRow
            drPreg = dtPreg.Rows(0)
            Me.CRGId = drPreg("CRGId")
            Me.Altitud = drPreg("Altitud")
            Me.Latitud = drPreg("Latitud")
            Me.Longitud = drPreg("Longitud")
            Me.Fecha = drPreg("Fecha")
            Me.Hora = drPreg("Hora")
            'Respuesta
            If Me.ENCId <> "" And Me.ENPId <> "" Then
                sConsulta = "select ERGId, Altitud, Latitud, Longitud, Fecha, Hora from ENPRespGPS where ENCId = '" & Me.ENCId & "' and ENPId = '" & Me.ENPId & "'"
                dtPreg = oDBVen.RealizarConsultaSQL(sConsulta, "ENPRespGPS")
                If dtPreg.Rows.Count > 0 Then
                    ERGId = dtPreg.Rows(0)("ERGId")
                    RespAltitud = IIf(IsDBNull(dtPreg.Rows(0)("Altitud")), Nothing, dtPreg.Rows(0)("Altitud"))
                    RespLatitud = IIf(IsDBNull(dtPreg.Rows(0)("Latitud")), Nothing, dtPreg.Rows(0)("Latitud"))
                    RespLongitud = IIf(IsDBNull(dtPreg.Rows(0)("Longitud")), Nothing, dtPreg.Rows(0)("Longitud"))
                    RespFecha = IIf(IsDBNull(dtPreg.Rows(0)("Fecha")), Nothing, dtPreg.Rows(0)("Fecha"))
                    RespHora = IIf(IsDBNull(dtPreg.Rows(0)("Hora")), Nothing, dtPreg.Rows(0)("Hora"))
                End If
            End If
        End If
        dtPreg.Dispose()
    End Sub
    Public Overrides Sub Recuperar(ByVal hash As Hashtable)

        If hash Is Nothing Then Exit Sub

        If hash.ContainsKey(Me.CEPNumero) Then
            Dim drPreg As DataRow = hash.Item(Me.CEPNumero)
            Me.CRGId = drPreg("CRGId")
            Me.Altitud = drPreg("Altitud")
            Me.Latitud = drPreg("Latitud")
            Me.Longitud = drPreg("Longitud")
            Me.Fecha = drPreg("Fecha")
            Me.Hora = drPreg("Hora")
            'Respuesta
            If Me.ENCId <> "" And Me.ENPId <> "" Then
                Dim dtPreg As DataTable
                Dim sConsulta As String

                sConsulta = "select ERGId, Altitud, Latitud, Longitud, Fecha, Hora from ENPRespGPS where ENCId = '" & Me.ENCId & "' and ENPId = '" & Me.ENPId & "'"
                dtPreg = oDBVen.RealizarConsultaSQL(sConsulta, "ENPRespGPS")
                If dtPreg.Rows.Count > 0 Then
                    ERGId = dtPreg.Rows(0)("ERGId")
                    RespAltitud = IIf(IsDBNull(dtPreg.Rows(0)("Altitud")), Nothing, dtPreg.Rows(0)("Altitud"))
                    RespLatitud = IIf(IsDBNull(dtPreg.Rows(0)("Latitud")), Nothing, dtPreg.Rows(0)("Latitud"))
                    RespLongitud = IIf(IsDBNull(dtPreg.Rows(0)("Longitud")), Nothing, dtPreg.Rows(0)("Longitud"))
                    RespFecha = IIf(IsDBNull(dtPreg.Rows(0)("Fecha")), Nothing, dtPreg.Rows(0)("Fecha"))
                    RespHora = IIf(IsDBNull(dtPreg.Rows(0)("Hora")), Nothing, dtPreg.Rows(0)("Hora"))
                End If
                dtPreg.Dispose()
            End If
        End If

    End Sub
    Public Overrides Sub RecuperarRespuesta()
        Dim sConsulta As String
        Dim dtPreg As DataTable
        'Respuesta
        If Me.ENCId <> "" And Me.ENPId <> "" Then
            sConsulta = "select ERGId, Altitud, Latitud, Longitud, Fecha, Hora from ENPRespGPS where ENCId = '" & Me.ENCId & "' and ENPId = '" & Me.ENPId & "'"
            dtPreg = oDBVen.RealizarConsultaSQL(sConsulta, "ENPRespGPS")
            If dtPreg.Rows.Count > 0 Then
                ERGId = dtPreg.Rows(0)("ERGId")
                RespAltitud = IIf(IsDBNull(dtPreg.Rows(0)("Altitud")), Nothing, dtPreg.Rows(0)("Altitud"))
                RespLatitud = IIf(IsDBNull(dtPreg.Rows(0)("Latitud")), Nothing, dtPreg.Rows(0)("Latitud"))
                RespLongitud = IIf(IsDBNull(dtPreg.Rows(0)("Longitud")), Nothing, dtPreg.Rows(0)("Longitud"))
                RespFecha = IIf(IsDBNull(dtPreg.Rows(0)("Fecha")), Nothing, dtPreg.Rows(0)("Fecha"))
                RespHora = IIf(IsDBNull(dtPreg.Rows(0)("Hora")), Nothing, dtPreg.Rows(0)("Hora"))
            End If
        End If
        dtPreg.Dispose()
    End Sub
    Public Overrides Sub ValidarRespuesta()
        If Me.RespuestaRequerida Then
            If (Me.Altitud And Me.RespAltitud = Nothing) Or (Me.Latitud And Me.RespLatitud = Nothing) Or _
               (Me.Longitud And Me.RespLongitud = Nothing) Or (Me.Fecha And Me.RespFecha = Nothing) Or _
               (Me.Hora And Me.RespHora = Nothing) Then
                Throw New CEstado(TipoEstado.EError, "E0308")
            End If
        End If
    End Sub
    Public Overrides Sub Insertar(ByVal pvENCId As String, ByVal pvOrdenAplicacion As Integer, ByVal pvSemilla As Integer)
        Dim sComando As String
        Me.ValidarRespuesta()
        MyBase.Insertar(pvENCId, pvOrdenAplicacion, pvSemilla)
        If Me.ERGId = "" Then
            Me.ERGId = oApp.KEYGEN(1)
            sComando = String.Format("insert into ENPRespGPS (ENCId, ENPId, ERGId, Altitud, Latitud, Longitud, Fecha, Hora, MFechaHora, MUsuarioId) values('{0}','{1}','{2}',{3},{4},{5},{6},{7},{8},'{9}')", Me.ENCId, Me.ENPId, Me.ERGId, IIf(Me.RespAltitud = Nothing, "NULL", Me.RespAltitud), IIf(Me.RespLatitud = Nothing, "NULL", Me.RespLatitud), IIf(Me.RespLongitud = Nothing, "NULL", Me.RespLongitud), IIf(Me.RespFecha = Nothing, "NULL", UniFechaSQL(Me.RespFecha.Date)), IIf(Me.RespHora = Nothing, "NULL", UniFechaSQL(Me.RespHora)), UniFechaSQL(Now), oVendedor.UsuarioId)
        Else
            sComando = String.Format("Update ENPRespGPS set Altitud={0}, Latitud={1}, Longitud={2}, Fecha={3}, Hora={4}, MFechaHora = getdate(), MUsuarioId = '{5}' Where ENCId='{6}' and ENPId ='{7}' and ERGId = '{8}' ", IIf(Me.RespAltitud = Nothing, "NULL", Me.RespAltitud), IIf(Me.RespLatitud = Nothing, "NULL", Me.RespLatitud), IIf(Me.RespLongitud = Nothing, "NULL", Me.RespLongitud), IIf(Me.RespFecha = Nothing, "NULL", UniFechaSQL(Me.RespFecha.Date)), IIf(Me.RespHora = Nothing, "NULL", UniFechaSQL(Me.RespHora)), oVendedor.UsuarioId, Me.ENCId, Me.ENPId, Me.ERGId)
        End If
        oDBVen.EjecutarComandoSQL(sComando)
    End Sub
    Public Overrides Sub Eliminar(ByVal pvENCId As String, ByVal pvENPId As String)
        Dim sComando As String
        sComando = String.Format("delete ENPRespGPS where ENCId='{0}' and ENPId ='{1}'", pvENCId, pvENPId)
        oDBVen.EjecutarComandoSQL(sComando)
        MyBase.Eliminar(pvENCId, pvENPId)
    End Sub
End Class

Public Class cCOLPreguntas
    Inherits CollectionBase
    Private sCENClave As String
    Private dtPregs As DataTable
    Public aVisitadas As New ArrayList
    Public nPreguntaActual As Integer = 0
    Public nPreguntaAnterior As Integer = -1
    Public bFinEncuesta As Boolean = False
    Public bPrimerPregunta As Boolean = False
    Private nPuntosAnt As Integer
    Private nPuntosNvo As Integer
    Public nOrdenActual As Integer
    Public nCEPNumeroPrimerPreg As Integer
    Public bIrAnterior As Boolean
    Public oConsPreg As cConsultaPreguntas

    Public Sub New()
        bIrAnterior = False
    End Sub

    Default Public Property Item(ByVal index As Integer) As cPregunta
        Get
            Return CType(List(index), cPregunta)
        End Get
        Set(ByVal Value As cPregunta)
            List(index) = Value
        End Set
    End Property
    Public ReadOnly Property PreguntaActual() As cPregunta
        Get
            If nPreguntaActual > 0 Then
                Return GetItem(nPreguntaActual)
            Else
                If nPreguntaActual = -1 Then
                    'Crear Mensaje 'Terminó encuesta'
                    Throw New CEstado(TipoEstado.EError)
                Else
                    'Crear Mensaje 'No se ha Cargado Ninguna Pregunta'
                    Throw New CEstado(TipoEstado.EError)
                End If
            End If
        End Get
    End Property
    Public ReadOnly Property GetItem(ByVal pvCEPNumero As Integer) As cPregunta
        Get
            For i As Integer = 0 To List.Count - 1
                Dim tmpPregunta As cPregunta = List(i)
                If (tmpPregunta.CEPNumero = pvCEPNumero) Then
                    Return CType(List(i), cPregunta)
                End If
            Next
            Return Nothing
        End Get
    End Property
    'Public ReadOnly Property SetItem(ByVal pvCEPNumero As Integer) As cPregunta
    '    Get
    '        For i As Integer = 0 To List.Count - 1
    '            Dim tmpPregunta As cPregunta = List(i)
    '            If (tmpPregunta.CEPNumero = pvCEPNumero) Then
    '                nPreguntaActual = i + 1
    '                Return CType(List(i), cPregunta)
    '            End If
    '        Next
    '        Return Nothing
    '    End Get
    'End Property
    Public Property PuntosAnt() As Integer
        Get
            Return nPuntosAnt
        End Get
        Set(ByVal Value As Integer)
            nPuntosAnt = Value
        End Set
    End Property
    Public Property PuntosNvo() As Integer
        Get
            Return nPuntosNvo
        End Get
        Set(ByVal Value As Integer)
            nPuntosNvo = Value
        End Set
    End Property

    Public Function Add(ByVal value As cPregunta) As Integer
        Return List.Add(value)
    End Function 'Add
    Public Sub Insert(ByVal index As Integer, ByVal value As cPregunta)
        List.Insert(index, value)
    End Sub 'Insert
    Public Sub Remove(ByVal value As cPregunta)
        List.Remove(value)
    End Sub 'Remove
    Public Function IniciarEncuesta() As CEstado
        nOrdenActual = 1
        nPreguntaActual = Item(0).CEPNumero
        bPrimerPregunta = True
        If Not List.Count > 0 Then
            'Crear Mensaje 'No se ha Cargado Ninguna Pregunta'
            Throw New CEstado(TipoEstado.EError)
        Else
            Return New CEstado(TipoEstado.ECorrecto)
        End If

    End Function
    Public Function SiguientePregunta() As CEstado
        bIrAnterior = False
        Return MoverPregunta(1)
    End Function
    Public Function AnteriorPregunta() As CEstado
        bIrAnterior = True
        Return MoverPregunta(-1)
    End Function
    Public Function MoverPregunta(ByVal pvNoPreguntas As Integer) As CEstado

        Dim tmpPregunta As cPregunta
        If Not bFinEncuesta Then
            tmpPregunta = PreguntaActual

            If pvNoPreguntas > 0 Then
                '//Determinar si se puede pasar a una nueva pregunta
                Try
                    tmpPregunta.ValidarRespuesta()
                Catch ex As CEstado
                    Throw New CEstado(TipoEstado.EError, ex.sCVEMensaje)
                End Try
            End If
        End If

        '//Salir por que es mover hacia atras
        If pvNoPreguntas < 0 Then

            If aVisitadas.Count > 0 Then
                aVisitadas.RemoveAt(aVisitadas.Count - 1)
                nOrdenActual -= 1
                If aVisitadas.Count <= 0 Then
                    bPrimerPregunta = True
                    tmpPregunta = Item(0)
                    nPreguntaActual = tmpPregunta.CEPNumero
                    Return Nothing
                Else
                    nPreguntaActual = aVisitadas(aVisitadas.Count - 1)
                    bPrimerPregunta = (nPreguntaActual = Item(0).CEPNumero)
                    bFinEncuesta = False
                    tmpPregunta = GetItem(nPreguntaActual)
                    Return Nothing
                End If
            Else
                '//Pasar a la primera pregunta
                nPreguntaActual = Item(0).CEPNumero
                bPrimerPregunta = True
                tmpPregunta = GetItem(nPreguntaActual)
                Throw New CEstado(TipoEstado.EError)
            End If

            Exit Function
        Else
            If (nPreguntaActual = Item(0).CEPNumero And tmpPregunta.TipoRespuesta <> 7) Then tmpPregunta.Visitada = True

            If tmpPregunta.TipoRespuesta = 3 Then
                If CType(tmpPregunta, cPreguntaOpcional).ValidarCondicion Then
                    tmpPregunta = GetItem(CType(tmpPregunta, cPreguntaOpcional).CEPNumero1)
                    nPreguntaActual = tmpPregunta.CEPNumero
                Else
                    If tmpPregunta.Orden < Me.Count Then
                        nPreguntaActual = Item(tmpPregunta.Orden).CEPNumero
                    Else
                        bFinEncuesta = True
                    End If
                End If
            ElseIf tmpPregunta.TipoRespuesta = 7 Then
                tmpPregunta.Insertar(tmpPregunta.ENCId, nOrdenActual, 1)
                CType(tmpPregunta, cPreguntaSalto).oConPreg = Me.oConsPreg
                If CType(tmpPregunta, cPreguntaSalto).Validar() Then
                    If Not CType(tmpPregunta, cPreguntaSalto).Terminar Then
                        tmpPregunta = GetItem(CType(tmpPregunta, cPreguntaSalto).CEPNumero2)
                        nPreguntaActual = tmpPregunta.CEPNumero
                    Else
                        bFinEncuesta = True
                    End If
                Else
                    If tmpPregunta.Orden < Me.Count Then
                        nPreguntaActual = Item(tmpPregunta.Orden).CEPNumero
                    Else
                        bFinEncuesta = True
                    End If
                End If
            Else
                If tmpPregunta.Orden < Me.Count Then
                    nPreguntaActual = Item(tmpPregunta.Orden).CEPNumero
                Else
                    bFinEncuesta = True
                End If
            End If
            bPrimerPregunta = False
        End If

        If Not bFinEncuesta Then
            tmpPregunta = GetItem(nPreguntaActual)

            '//Marcar como visitada la pregunta Actual si no es de tipo Salto
            If aVisitadas.IndexOf(nPreguntaActual) = -1 Then
                nPreguntaAnterior = tmpPregunta.CEPNumero
                aVisitadas.Add(tmpPregunta.CEPNumero)
                tmpPregunta.Visitada = True
                nOrdenActual += 1
            End If
        End If

        Return New CEstado(TipoEstado.ECorrecto)

    End Function

    Public Sub ReestablecerEncuesta()
        bFinEncuesta = False
        nPreguntaActual = nPreguntaAnterior
    End Sub

End Class

Public Class cConsultaPreguntas
    Implements IDisposable

    Private disposedValue As Boolean = False        ' Para detectar llamadas redundantes
    Private hPreguntaTexto As Hashtable
    Private hPreguntaNumero As Hashtable
    Private hPreguntaOpcional As Hashtable
    Private hPreguntaCodigo As Hashtable
    Private hPreguntaImagen As Hashtable
    Private hRespuestaMatricial As Hashtable
    Private hPreguntaSalto As Hashtable
    Private hPreguntaGPS As Hashtable

    Private CENClave As String
    Private ENCId As String

#Region "PROPIEDADES"
    Public ReadOnly Property PreguntaTexto() As Hashtable
        Get
            Return Me.hPreguntaTexto
        End Get
    End Property
    Public ReadOnly Property PreguntaNumero() As Hashtable
        Get
            Return Me.hPreguntaNumero
        End Get
    End Property
    Public ReadOnly Property PreguntaOpcional() As Hashtable
        Get
            Return Me.hPreguntaOpcional
        End Get
    End Property
    Public ReadOnly Property PreguntaCodigo() As Hashtable
        Get
            Return Me.hPreguntaCodigo
        End Get
    End Property
    Public ReadOnly Property PreguntaImagen() As Hashtable
        Get
            Return Me.hPreguntaImagen
        End Get
    End Property
    Public ReadOnly Property RespuestaMatricial() As Hashtable
        Get
            Return Me.hRespuestaMatricial
        End Get
    End Property
    Public ReadOnly Property PreguntaSalto() As Hashtable
        Get
            Return Me.hPreguntaSalto
        End Get
    End Property
    Public ReadOnly Property PreguntaGPS() As Hashtable
        Get
            Return Me.hPreguntaGPS
        End Get
    End Property
#End Region

    Public Sub New(ByVal ENCId As String, ByVal CENClave As String)
        Me.CENClave = CENClave
        Me.ENCId = ENCId
        EjecutarConsultas()

    End Sub

    Private Sub EjecutarConsultas()
        hPreguntaTexto = ConsultaPreguntaTexto()
        hPreguntaNumero = ConsultaPreguntaNumero()
        hPreguntaOpcional = ConsultaPreguntaOpcional()
        hPreguntaCodigo = ConsultaPreguntaCodigo()
        hPreguntaImagen = ConsultaPreguntaImagen()
        hRespuestaMatricial = Me.ConsultaRespuestaMatricial
        hPreguntaSalto = ConsultaPreguntaSalto()
        hPreguntaGPS = ConsultaPreguntaGPS()
        'hENPId = ConsultaPreguntaENPId()
    End Sub

#Region "CONSULTAS"

    Private Function ConsultaPreguntaTexto() As Hashtable
        Dim scomando As New System.Text.StringBuilder
        Dim dt As DataTable

        scomando.Append("select CRTId, TipoConversion, Mascara, TipoLimite, Minimo, Maximo, CEPNumero from CEPRespTexto ")
        scomando.Append("where CENClave = '" & Me.CENClave & "'")
        dt = oDBVen.RealizarConsultaSQL(scomando.ToString, "Encuesta")
        If dt.Rows.Count > 0 Then
            Dim hash As New Hashtable
            For Each row As DataRow In dt.Rows
                hash.Add(row("CEPNumero"), row)
            Next

            dt.Dispose()
            dt = Nothing
            scomando = Nothing

            Return hash
        End If

        dt.Dispose()
        dt = Nothing
        scomando = Nothing

        Return Nothing

    End Function
    Private Function ConsultaPreguntaNumero() As Hashtable
        Dim scomando As New System.Text.StringBuilder
        Dim dt As DataTable

        scomando.Append("select CRNId, Formato, TipoLimite, Minimo, Maximo, CEPNumero from CEPRespNumero ")
        scomando.Append("where CENClave = '" & Me.CENClave & "' ")
        dt = oDBVen.RealizarConsultaSQL(scomando.ToString, "Encuesta")
        If dt.Rows.Count > 0 Then
            Dim hash As New Hashtable
            For Each row As DataRow In dt.Rows
                hash.Add(row("CEPNumero"), row)
            Next

            dt.Dispose()
            dt = Nothing
            scomando = Nothing

            Return hash
        End If

        dt.Dispose()
        dt = Nothing
        scomando = Nothing
        Return Nothing

    End Function
    Private Function ConsultaPreguntaOpcional() As Hashtable
        Dim scomando As New System.Text.StringBuilder
        Dim dt As DataTable

        scomando.Append("select CROId, TipoSeleccion, TipoLimite, Minimo, Maximo, Rotativa, Condicion, TipoLimite1, Minimo1, Maximo1, TipoConversion, Formato, CEPNumero from CEPRespOpcional ")
        scomando.Append("where CENClave = '" & Me.CENClave & "' ")
        dt = oDBVen.RealizarConsultaSQL(scomando.ToString, "Encuesta")
        If dt.Rows.Count > 0 Then
            Dim hash As New Hashtable
            For Each row As DataRow In dt.Rows
                hash.Add(row("CEPNumero"), row)
            Next

            dt.Dispose()
            dt = Nothing
            scomando = Nothing

            Return hash
        End If

        dt.Dispose()
        dt = Nothing
        scomando = Nothing
        Return Nothing

    End Function
    Private Function ConsultaPreguntaCodigo() As Hashtable
        Dim scomando As New System.Text.StringBuilder
        Dim dt As DataTable

        scomando.Append("select CRCId, TipoCodigo, CEPNumero from CEPRespCodigo ")
        scomando.Append("where CENClave = '" & Me.CENClave & "' ")
        dt = oDBVen.RealizarConsultaSQL(scomando.ToString, "Encuesta")
        If dt.Rows.Count > 0 Then
            Dim hash As New Hashtable
            For Each row As DataRow In dt.Rows
                hash.Add(row("CEPNumero"), row)
            Next

            dt.Dispose()
            dt = Nothing
            scomando = Nothing

            Return hash
        End If

        dt.Dispose()
        dt = Nothing
        scomando = Nothing
        Return Nothing

    End Function
    Private Function ConsultaPreguntaImagen() As Hashtable
        Dim scomando As New System.Text.StringBuilder
        Dim dt As DataTable

        scomando.Append("select CRIId, Calidad, CEPNumero from CEPRespImagen ")
        scomando.Append("where CENClave = '" & Me.CENClave & "' ")
        dt = oDBVen.RealizarConsultaSQL(scomando.ToString, "Encuesta")
        If dt.Rows.Count > 0 Then
            Dim hash As New Hashtable
            For Each row As DataRow In dt.Rows
                hash.Add(row("CEPNumero"), row)
            Next

            dt.Dispose()
            dt = Nothing
            scomando = Nothing

            Return hash
        End If

        dt.Dispose()
        dt = Nothing
        scomando = Nothing
        Return Nothing

    End Function
    Private Function ConsultaRespuestaMatricial() As Hashtable
        Dim scomando As New System.Text.StringBuilder
        Dim dt As DataTable
        Dim hPregMatricial As Hashtable
        Dim hRespMatricial As Hashtable

        scomando.Append("select CPMNumero, Descripcion, CEPNumero from CEPPregMatricial ")
        scomando.Append("where CENClave = '" & Me.CENClave & "' order by Orden")
        dt = oDBVen.RealizarConsultaSQL(scomando.ToString, "CEPPregMatricial")

        If dt.Rows.Count > 0 Then
            hPregMatricial = New Hashtable
            For Each row As DataRow In dt.Rows
                If hPregMatricial.ContainsKey(row("CEPNumero")) Then
                    Dim arr As ArrayList
                    arr = hPregMatricial.Item(row("CEPNumero"))
                    hPregMatricial.Remove(row("CEPNumero"))
                    arr.Add(row)
                    hPregMatricial.Add(row("CEPNumero"), arr)
                Else
                    Dim arr As New ArrayList
                    arr.Add(row)
                    hPregMatricial.Add(row("CEPNumero"), arr)
                End If
            Next
        End If


        scomando = Nothing
        scomando = New System.Text.StringBuilder
        scomando.Append("select CRMNumero, Descripcion, TipoValor, CEPNumero from CEPRespMatricial ")
        scomando.Append("where CENClave = '" & Me.CENClave & "' order by Orden ")
        dt = oDBVen.RealizarConsultaSQL(scomando.ToString, "Encuesta")

        If dt.Rows.Count > 0 Then
            hRespMatricial = New Hashtable
            For Each row As DataRow In dt.Rows
                If hRespMatricial.ContainsKey(row("CEPNumero")) Then
                    Dim arr As ArrayList
                    arr = hRespMatricial.Item(row("CEPNumero"))
                    hRespMatricial.Remove(row("CEPNumero"))
                    arr.Add(row)
                    hRespMatricial.Add(row("CEPNumero"), arr)
                Else
                    Dim arr As New ArrayList
                    arr.Add(row)
                    hRespMatricial.Add(row("CEPNumero"), arr)
                End If
            Next
        End If

        Dim hashRetorno As New Hashtable
        hashRetorno.Add(1, hPregMatricial) 'Matriz de preguntas
        hashRetorno.Add(2, hRespMatricial) 'Matriz de respuestas

        dt.Dispose()
        dt = Nothing
        scomando = Nothing
        Return hashRetorno
    End Function
    Private Function ConsultaPreguntaSalto() As Hashtable
        Dim sConsulta As New System.Text.StringBuilder
        Dim dt As DataTable

        sConsulta.Append("select CRSId, CENClave1, CEPNumero1, CENClave2, CEPNumero2, CENClave3, CEPNumero3, CRSId1, ")
        sConsulta.Append("TipoOperadorSig, TipoCondicion, Valor, TipoValor, TipoCanOpcion, Terminar, CEPNumero from CEPRespSalto ")
        sConsulta.Append("where CENClave = '" & Me.CENClave & "' ")
        dt = oDBVen.RealizarConsultaSQL(sConsulta.ToString, "CEPRespSalto")
        If dt.Rows.Count > 0 Then
            Dim hash As New Hashtable

            For Each row As DataRow In dt.Rows
                hash.Add(row("CEPNumero"), row)
            Next

            dt.Dispose()
            dt = Nothing
            sConsulta = Nothing

            Return hash
        End If

        dt.Dispose()
        dt = Nothing
        sConsulta = Nothing
        Return Nothing
    End Function
    Private Function ConsultaPreguntaGPS() As Hashtable
        Dim scomando As New System.Text.StringBuilder
        Dim dt As DataTable

        scomando.Append("select CRGId, Altitud, Latitud, Longitud, Fecha, Hora, CEPNumero from CEPRespGPS ")
        scomando.Append("where CENClave = '" & Me.CENClave & "' ")
        dt = oDBVen.RealizarConsultaSQL(scomando.ToString, "Encuesta")
        If dt.Rows.Count > 0 Then
            Dim hash As New Hashtable
            For Each row As DataRow In dt.Rows
                hash.Add(row("CEPNumero"), row)
            Next

            dt.Dispose()
            dt = Nothing
            scomando = Nothing

            Return hash
        End If
        dt.Dispose()
        dt = Nothing
        scomando = Nothing
        Return Nothing

    End Function

    Private Function ConsultaPreguntaENPId() As Hashtable
        If Me.ENCId <> "" Then
            Dim scomando As New System.Text.StringBuilder
            Dim dt As DataTable

            scomando.Append(String.Format("select ENPId, CEPNumero from ENCPregunta where ENCId = '{0}' and CENClave = '{1}' ", Me.ENCId, Me.CENClave))
            dt = oDBVen.RealizarConsultaSQL(scomando.ToString, "Encuesta")
            Dim hash As Hashtable

            If dt.Rows.Count > 0 Then
                hash = New Hashtable
                For Each row As DataRow In dt.Rows
                    If Not hash.ContainsKey(row("CEPNumero")) Then
                        hash.Add(row("CEPNumero"), row("ENPId"))
                    End If

                Next
            End If

            dt.Dispose()
            dt = Nothing
            scomando = Nothing
            Return hash
        End If

        Return Nothing
    End Function
    Private Function sENPId(ByVal hash As Hashtable, ByVal CEPNumero As String) As String
        If Not hash Is Nothing Then
            If hash.ContainsKey(CEPNumero) Then
                Return hash.Item(CEPNumero)
            End If
        End If
        Return Nothing
    End Function

#End Region

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: Liberar recursos no administrados cuando se llamen explícitamente
                hPreguntaTexto = Nothing
                hPreguntaNumero = Nothing
                hPreguntaOpcional = Nothing
                hPreguntaCodigo = Nothing
                hPreguntaImagen = Nothing
                hRespuestaMatricial = Nothing
                hPreguntaSalto = Nothing
                hPreguntaGPS = Nothing
            End If

            ' TODO: Liberar recursos no administrados compartidos
        End If
        Me.disposedValue = True
    End Sub

#Region " IDisposable Support "
    ' Visual Basic agregó este código para implementar correctamente el modelo descartable.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' No cambie este código. Coloque el código de limpieza en Dispose (ByVal que se dispone como Boolean).
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region


End Class

