Imports BASMENLOG
Imports System.Windows.Forms
Public Class ManejoCampoLogico

#Region "Variables"
    Protected sCampo As String
    Protected sMnemonicoTabla As String
    Protected sSufijoToolTip As String
    Protected oCtrlEtiqueta As Control
    Protected oCtrlCaptura As Control
    Protected oCtrlCapturaAlterno As Control
    Protected oCtrlClaveReal As Control
    Protected oCtrlDisplayError As Control
    Protected bRequerido As Boolean
    Protected bLlave As Boolean
    Protected sValorReferencia As String
    Protected sVAVClaveDefault As Integer
    Protected sGrupoValorReferencia As String
    Protected oInfoValorReferencia As InfoValorReferencia
    Protected oInfoLlaveExterna As InfoLlaveExterna
    Protected bColumnaCalculada As Boolean

#End Region

#Region "Propiedades"

    Public Property Campo() As String
        Get
            Return sCampo
        End Get
        Set(ByVal Value As String)
            sCampo = Value
        End Set
    End Property

    Public Property MnemonicoTabla() As String
        Get
            Return sMnemonicoTabla
        End Get
        Set(ByVal Value As String)
            sMnemonicoTabla = Value
        End Set
    End Property

    Public ReadOnly Property NombreCompleto() As String
        Get
            Return Me.MnemonicoTabla & Me.Campo
        End Get
    End Property

    Public Property SufijoToolTip() As String
        Get
            Return sSufijoToolTip
        End Get
        Set(ByVal Value As String)
            sSufijoToolTip = Value
        End Set
    End Property

    Public Property CtrlEtiqueta() As Control
        Get
            Return oCtrlEtiqueta
        End Get
        Set(ByVal Value As Control)
            oCtrlEtiqueta = Value
        End Set
    End Property

    Public Property CtrlCaptura() As Control
        Get
            Return oCtrlCaptura
        End Get
        Set(ByVal Value As Control)
            oCtrlCaptura = Value
        End Set
    End Property

    Public Property CtrlCapturaAlterno() As Control
        Get
            Return oCtrlCapturaAlterno
        End Get
        Set(ByVal Value As Control)
            oCtrlCapturaAlterno = Value
        End Set
    End Property

    Public Property CtrlErrorAlterno() As Control
        Get
            Return oCtrlDisplayError
        End Get
        Set(ByVal Value As Control)
            oCtrlDisplayError = Value
        End Set
    End Property

    Public Property CtrlClaveReal() As Control
        Get
            Return oCtrlClaveReal
        End Get
        Set(ByVal Value As Control)
            oCtrlClaveReal = Value
        End Set
    End Property

    Public ReadOnly Property CtrlDisplayError() As Control
        Get
            If (Me.CtrlErrorAlterno Is Nothing) Then
                If (HayCtrlAlterno()) Then
                    Return RegresaControlActivo()
                Else
                    Return Me.CtrlCaptura
                End If
            Else
                Return Me.CtrlErrorAlterno
            End If
        End Get
    End Property

    Public Property Requerido() As Boolean
        Get
            Return bRequerido
        End Get
        Set(ByVal Value As Boolean)
            bRequerido = Value
        End Set
    End Property

    Public Property LLave() As Boolean
        Get
            Return bLlave
        End Get
        Set(ByVal Value As Boolean)
            bLlave = Value
        End Set
    End Property

    Public Property ValorReferencia() As String
        Get
            Return sValorReferencia
        End Get
        Set(ByVal Value As String)
            sValorReferencia = Value
        End Set
    End Property

    Public Property VAVClaveDefault() As Integer
        Get
            Return sVAVClaveDefault
        End Get
        Set(ByVal Value As Integer)
            sVAVClaveDefault = Value
        End Set
    End Property

    Public Property GrupoValorReferencia() As String
        Get
            Return sGrupoValorReferencia
        End Get
        Set(ByVal Value As String)
            sGrupoValorReferencia = Value
        End Set
    End Property

    Public Property InfoValorReferencia() As InfoValorReferencia
        Get
            Return oInfoValorReferencia
        End Get
        Set(ByVal Value As InfoValorReferencia)
            oInfoValorReferencia = Value
        End Set
    End Property

    Public ReadOnly Property ValidarValRef() As Boolean
        Get
            Return (Not Me.InfoValorReferencia Is Nothing)
        End Get
    End Property

    Public Property InfoLlaveExterna() As InfoLlaveExterna
        Get
            Return oInfoLlaveExterna
        End Get
        Set(ByVal Value As InfoLlaveExterna)
            oInfoLlaveExterna = Value
        End Set
    End Property

    Public ReadOnly Property ValidarLlaveExterna() As Boolean
        Get
            Return (Not Me.InfoLlaveExterna Is Nothing)
        End Get
    End Property

#End Region

#Region "Constructores"
    'Public Sub New()

    'End Sub
    Public Sub New(ByVal pvMnTabla As String, ByVal pvCampo As String, ByRef prCtrlEtiq As System.Windows.Forms.Control, ByRef prCtrlCaptura As System.Windows.Forms.Control, ByVal pvRequerido As Boolean, Optional ByVal pvValorReferencia As String = "", Optional ByVal pvLlave As Boolean = False)
        Me.MnemonicoTabla = pvMnTabla
        Me.Campo = pvCampo
        Me.CtrlEtiqueta = prCtrlEtiq
        Me.CtrlCaptura = prCtrlCaptura
        Me.Requerido = pvRequerido
        Me.ValorReferencia = pvValorReferencia
        Me.LLave = pvLlave
        Me.SufijoToolTip = "T"
    End Sub
   
#End Region

#Region "Metodos"

    Public Overloads Overrides Function Equals(ByVal obj As Object) As Boolean
        Dim obj2 As ManejoCampoLogico

        If (obj.GetType Is GetType(ManejoCampoLogico)) Then
            obj2 = obj
            Return Me.Campo.Equals(obj2.Campo)
        Else
            Return False
        End If
    End Function

    Public Sub FijarTexto(ByRef refoMensaje As CMensaje)
        If (Not Me.CtrlEtiqueta Is Nothing) Then
            oCtrlEtiqueta.Text = refoMensaje.RecuperarDescripcion(Me.NombreCompleto)
        End If
    End Sub

    Public Sub FijarTooltip(ByRef refoMensaje As CMensaje, ByRef refoTT As System.Windows.Forms.ToolTip)
        If (Not Me.CtrlCaptura Is Nothing) Then
            refoTT.SetToolTip(Me.CtrlCaptura, refoMensaje.RecuperarDescripcion(Me.MnemonicoTabla & Me.Campo & Me.SufijoToolTip))
        End If
        If (Not Me.CtrlCapturaAlterno Is Nothing) Then
            refoTT.SetToolTip(Me.CtrlCapturaAlterno, refoMensaje.RecuperarDescripcion(Me.MnemonicoTabla & Me.Campo & Me.SufijoToolTip))
        End If
    End Sub

    Public Sub FijarTooltip(ByRef refoMensaje As CMensaje, ByRef refoTT As System.Windows.Forms.ToolTip, ByVal pvValores() As String)
        If (Not Me.CtrlCaptura Is Nothing) Then
            refoTT.SetToolTip(Me.CtrlCaptura, refoMensaje.RecuperarDescripcion(Me.MnemonicoTabla & Me.Campo & Me.SufijoToolTip, pvValores))
        End If
        If (Not Me.CtrlCapturaAlterno Is Nothing) Then
            refoTT.SetToolTip(Me.CtrlCapturaAlterno, refoMensaje.RecuperarDescripcion(Me.MnemonicoTabla & Me.Campo & Me.SufijoToolTip, pvValores))
        End If
    End Sub

    Public Sub CargarValorReferencia(Optional ByVal pvListaExcluidos() As String = Nothing)
        Try
            'si tiene un valor por referencia
            If (Me.ValorReferencia <> "") Then
                'si es un combo 
                If (SoportaListaControlCaptura()) Then
                    'Se agrego para que puedas filtrar x grupo en valor x referencia...
                    'jpacheco 22/04/2006
                    If Me.GrupoValorReferencia = "" Then
                        lbGeneral.LlenarComboBox(Me.CtrlCaptura, Me.ValorReferencia, sVAVClaveDefault, pvListaExcluidos)
                    Else
                        lbGeneral.LlenarComboBoxConGrupo(Me.CtrlCaptura, Me.ValorReferencia, Me.GrupoValorReferencia, sVAVClaveDefault, pvListaExcluidos)
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Function ObtenerValorCapturado() As Object
        Dim valor As Object
        Dim oCtrlActivo As Control

        If (HayCtrlAlterno()) Then
            oCtrlActivo = RegresaControlActivo()
            valor = ObtenValorControl(oCtrlActivo)
        Else
            valor = ObtenValorControl(Me.CtrlCaptura)
        End If

        Return valor
    End Function

    Public Function ObtenerClaveReal() As Object
        Dim valor As Object
        Dim oCtrlActivo As Control

        If (HayCtrlClaveReal()) Then
            valor = ObtenValorControl(Me.CtrlClaveReal)
        Else
            oCtrlActivo = RegresaControlActivo()
            valor = ObtenValorControl(oCtrlActivo)
        End If

        Return valor
    End Function

    Public Function ObtenValorControl(ByRef prCtrl As Control) As Object
        Dim valor As Object

        Try
            Select Case prCtrl.GetType().ToString

                Case GetType(System.Windows.Forms.TextBox).ToString
                    valor = CType(prCtrl, System.Windows.Forms.TextBox).Text

                Case GetType(Janus.Windows.GridEX.EditControls.EditBox).ToString
                    valor = CType(prCtrl, Janus.Windows.GridEX.EditControls.EditBox).Text

                Case GetType(Janus.Windows.EditControls.UIComboBox).ToString
                    valor = CType(prCtrl, Janus.Windows.EditControls.UIComboBox).SelectedValue

                Case GetType(Janus.Windows.EditControls.UICheckBox).ToString
                    valor = CType(prCtrl, Janus.Windows.EditControls.UICheckBox).Checked

                Case GetType(Janus.Windows.EditControls.UIRadioButton).ToString
                    valor = CType(prCtrl, Janus.Windows.EditControls.UIRadioButton).Checked

                Case GetType(Janus.Windows.GridEX.EditControls.NumericEditBox).ToString
                    valor = CType(prCtrl, Janus.Windows.GridEX.EditControls.NumericEditBox).Value

                    'aqui se agregan todos los tipos necesarios
                    'Case GetType().ToString

                Case Else
                    valor = prCtrl.Text

            End Select
        Catch ex As Exception
            valor = Nothing
        End Try

        Return valor
    End Function

    Protected Function HayCtrlAlterno() As Boolean
        Return (Not Me.CtrlCapturaAlterno Is Nothing)
    End Function

    Protected Function HayCtrlClaveReal() As Boolean
        Return (Not Me.CtrlClaveReal Is Nothing)
    End Function

    Protected Function RegresaControlActivo() As Control
        Dim oCtrlActivo As Control

        If (Me.CtrlCaptura.Visible) Then
            oCtrlActivo = Me.CtrlCaptura
        Else
            oCtrlActivo = Me.CtrlCapturaAlterno
        End If

        Return oCtrlActivo
    End Function

    Protected Function SoportaListaControlCaptura() As Boolean
        Dim bRes As Boolean

        Try
            Select Case Me.CtrlCaptura.GetType().ToString

                Case GetType(Janus.Windows.EditControls.UIComboBox).ToString
                    bRes = True

                Case GetType(System.Windows.Forms.ComboBox).ToString
                    bRes = True

                    'aqui se agregan todos los tipos necesarios
                    'Case GetType().ToString

                Case Else
                    bRes = False
            End Select

        Catch ex As Exception
            bRes = False
        End Try

        Return bRes
    End Function

    Public Function EsNuloValorCapturado() As Boolean
        Dim oValor As Object
        Dim bRes As Boolean

        Try
            oValor = ObtenerValorCapturado()
            bRes = IsDBNull(oValor) Or IsNothing(oValor) Or (oValor = "")
        Catch ex As Exception
            bRes = False
        End Try

        Return bRes
    End Function

    Public Sub Focus()
        Dim oCtrlActivo As Control

        If (HayCtrlAlterno()) Then
            oCtrlActivo = RegresaControlActivo()
        Else
            oCtrlActivo = Me.CtrlCaptura
        End If

        If (Not oCtrlActivo Is Nothing) Then
            oCtrlActivo.Focus()
        End If

    End Sub

    Public Sub SetSoloLectura()

        If (Not Me.CtrlCaptura Is Nothing) Then
            Me.CtrlCaptura.Enabled = False
        End If
        If (Not Me.CtrlCapturaAlterno Is Nothing) Then
            Me.CtrlCapturaAlterno.Enabled = False
        End If
    End Sub

    Public Sub AsignarManejadorEvento_Validated(ByRef prMetodo As EventHandler)

        If (Not Me.CtrlCaptura Is Nothing) Then
            AddHandler Me.CtrlCaptura.Validated, prMetodo
        End If

        If (Not Me.CtrlCapturaAlterno Is Nothing) Then
            AddHandler Me.CtrlCapturaAlterno.Validated, prMetodo
        End If

    End Sub
    Public Sub AsignarManejadorEvento_ValueChanged(ByRef prMetodo As EventHandler)

        If (Not Me.CtrlCaptura Is Nothing) Then
            AsignaEventoValueChanged_AControl(Me.CtrlCaptura, prMetodo)
        End If

        If (Not Me.CtrlCapturaAlterno Is Nothing) Then
            AsignaEventoValueChanged_AControl(Me.CtrlCapturaAlterno, prMetodo)
        End If

    End Sub
    Protected Sub AsignaEventoValueChanged_AControl(ByRef prCtrl As Control, ByRef prMetodo As EventHandler)

        Try

            Select Case prCtrl.GetType().ToString

                Case GetType(System.Windows.Forms.TextBox).ToString
                    AddHandler CType(Me.CtrlCaptura, System.Windows.Forms.TextBox).TextChanged, prMetodo

                Case GetType(Janus.Windows.GridEX.EditControls.EditBox).ToString
                    AddHandler CType(Me.CtrlCaptura, Janus.Windows.GridEX.EditControls.EditBox).TextChanged, prMetodo

                Case GetType(Janus.Windows.EditControls.UIComboBox).ToString
                    AddHandler CType(Me.CtrlCaptura, Janus.Windows.EditControls.UIComboBox).SelectedValueChanged, prMetodo

                Case GetType(Janus.Windows.CalendarCombo.CalendarCombo).ToString
                    AddHandler CType(Me.CtrlCaptura, Janus.Windows.CalendarCombo.CalendarCombo).ValueChanged, prMetodo

                Case GetType(Janus.Windows.EditControls.UICheckBox).ToString
                    AddHandler CType(Me.CtrlCaptura, Janus.Windows.EditControls.UICheckBox).CheckedChanged, prMetodo

                Case GetType(Janus.Windows.EditControls.UIRadioButton).ToString
                    AddHandler CType(Me.CtrlCaptura, Janus.Windows.EditControls.UIRadioButton).CheckedChanged, prMetodo

                Case GetType(Janus.Windows.GridEX.EditControls.NumericEditBox).ToString
                    AddHandler CType(Me.CtrlCaptura, Janus.Windows.GridEX.EditControls.NumericEditBox).ValueChanged, prMetodo

                    'aqui se agregan todos los tipos necesarios
                    'Case GetType().ToString
                Case Else

            End Select

        Catch ex As Exception
        End Try

    End Sub

#End Region

End Class

Public Class ManejoColumnaGrid

#Region "Variables"
    Protected oGrid As Janus.Windows.GridEX.GridEX
    Protected sCampo As String
    Protected sMnemonicoTabla As String
    Protected sSufijoToolTip As String
    'Protected oCtrlEtiqueta As Control
    'Protected oCtrlCaptura As Control
    'Protected oCtrlCapturaAlterno As Control
    'Protected oCtrlDisplayError As Control
    Protected bVisible As Boolean
    Protected bRequerido As Boolean
    Protected bLlave As Boolean
    Protected bSoloLectura As Boolean
    Protected sValorReferencia As String
    Protected iAncho As Integer
    Protected iPosicionInicial As Integer
    'Protected oInfoValidacionValRef As InfoValorReferencia
    Protected sFormatString As String
    Protected sInputMask As String
    Protected bColumnaCalculada As Boolean
#End Region

#Region "Propiedades"

    Public Property Grid() As Janus.Windows.GridEX.GridEX
        Get
            Return oGrid
        End Get
        Set(ByVal Value As Janus.Windows.GridEX.GridEX)
            oGrid = Value
        End Set
    End Property

    Public Property Campo() As String
        Get
            Return sCampo
        End Get
        Set(ByVal Value As String)
            sCampo = Value
        End Set
    End Property

    Public Property MnemonicoTabla() As String
        Get
            Return sMnemonicoTabla
        End Get
        Set(ByVal Value As String)
            sMnemonicoTabla = Value
        End Set
    End Property

    Public ReadOnly Property NombreCompleto() As String
        Get
            Return Me.MnemonicoTabla & Me.Campo
        End Get
    End Property

    Public Property SufijoToolTip() As String
        Get
            Return sSufijoToolTip
        End Get
        Set(ByVal Value As String)
            sSufijoToolTip = Value
        End Set
    End Property

    'Public Property CtrlEtiqueta() As Control
    '    Get
    '        Return oCtrlEtiqueta
    '    End Get
    '    Set(ByVal Value As Control)
    '        oCtrlEtiqueta = Value
    '    End Set
    'End Property

    'Public Property CtrlCaptura() As Control
    '    Get
    '        Return oCtrlCaptura
    '    End Get
    '    Set(ByVal Value As Control)
    '        oCtrlCaptura = Value
    '    End Set
    'End Property

    'Public Property CtrlCapturaAlterno() As Control
    '    Get
    '        Return oCtrlCapturaAlterno
    '    End Get
    '    Set(ByVal Value As Control)
    '        oCtrlCapturaAlterno = Value
    '    End Set
    'End Property

    'Public Property CtrlErrorAlterno() As Control
    '    Get
    '        Return oCtrlDisplayError
    '    End Get
    '    Set(ByVal Value As Control)
    '        oCtrlDisplayError = Value
    '    End Set
    'End Property

    'Public ReadOnly Property CtrlDisplayError() As Control
    '    Get
    '        If (Me.CtrlErrorAlterno Is Nothing) Then
    '            If (HayCtrlAlterno()) Then
    '                Return RegresaControlActivo()
    '            Else
    '                Return Me.CtrlCaptura
    '            End If
    '        Else
    '            Return Me.CtrlErrorAlterno
    '        End If
    '    End Get
    'End Property

    Public Property Requerido() As Boolean
        Get
            Return bRequerido
        End Get
        Set(ByVal Value As Boolean)
            bRequerido = Value
        End Set
    End Property

    Public Property LLave() As Boolean
        Get
            Return bLlave
        End Get
        Set(ByVal Value As Boolean)
            bLlave = Value
        End Set
    End Property

    Public Property SoloLectura() As Boolean
        Get
            Return bSoloLectura
        End Get
        Set(ByVal Value As Boolean)
            bSoloLectura = Value
        End Set
    End Property

    Public Property Visible() As Boolean
        Get
            Return bVisible
        End Get
        Set(ByVal Value As Boolean)
            bVisible = Value
        End Set
    End Property

    Public Property Ancho() As Integer
        Get
            Return iAncho
        End Get
        Set(ByVal Value As Integer)
            iAncho = Value
        End Set
    End Property

    Public Property ValorReferencia() As String
        Get
            Return sValorReferencia
        End Get
        Set(ByVal Value As String)
            sValorReferencia = Value
        End Set
    End Property

    Public Property PosicionInicial() As Integer
        Get
            Return iPosicionInicial
        End Get
        Set(ByVal Value As Integer)
            iPosicionInicial = Value
        End Set
    End Property

    Public Property FormatString() As String
        Get
            Return sFormatString
        End Get
        Set(ByVal Value As String)
            sFormatString = Value
        End Set
    End Property

    Public Property InputMask() As String
        Get
            Return sInputMask
        End Get
        Set(ByVal Value As String)
            sInputMask = Value
        End Set
    End Property

    Public Property ColumnaCalculada() As Boolean
        Get
            Return bColumnaCalculada
        End Get
        Set(ByVal Value As Boolean)
            bColumnaCalculada = Value
        End Set
    End Property
    'Public Property InfoValidacionValRef() As InfoValorReferencia
    '    Get
    '        Return oInfoValidacionValRef
    '    End Get
    '    Set(ByVal Value As InfoValorReferencia)
    '        oInfoValidacionValRef = Value
    '    End Set
    'End Property

    'Public ReadOnly Property ValidarValRef() As Boolean
    '    Get
    '        Return (Not Me.InfoValidacionValRef Is Nothing)
    '    End Get
    'End Property

#End Region

#Region "Constructores"
    'Public Sub New()

    'End Sub
    Public Sub New(ByRef prGrid As Janus.Windows.GridEX.GridEX, ByVal pvMnTabla As String, ByVal pvCampo As String, ByVal pvLlave As Boolean, Optional ByVal pvValorReferencia As String = "", Optional ByVal pvVisible As Boolean = True, Optional ByVal pvAncho As Integer = 0, Optional ByVal pvSoloLectura As Boolean = False)
        Me.Grid = prGrid
        Me.MnemonicoTabla = pvMnTabla
        Me.Campo = pvCampo
        Me.LLave = pvLlave
        Me.ValorReferencia = pvValorReferencia
        Me.Visible = pvVisible
        Me.Ancho = pvAncho
        Me.SoloLectura = pvSoloLectura

        If (Me.LLave) Then
            Me.Requerido = True
        Else
            Me.Requerido = False
        End If

        Me.SufijoToolTip = "T"
    End Sub
#End Region

#Region "Metodos"

    Public Overloads Overrides Function Equals(ByVal obj As Object) As Boolean
        Dim obj2 As ManejoCampoLogico

        If (obj.GetType Is GetType(ManejoColumnaGrid)) Then
            obj2 = obj
            Return Me.Campo.Equals(obj2.Campo)
        Else
            Return False
        End If
    End Function

    Public Sub FijarTexto(ByRef refoMensaje As CMensaje, Optional ByVal pvAlign As Janus.Windows.GridEX.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center)
        Try
            If (Not Me.Grid Is Nothing) Then
                If (Not Me.Grid.RootTable Is Nothing) Then
                    If (Me.Grid.RootTable.Columns.Contains(Me.Campo)) Then
                        Me.Grid.RootTable.Columns(Me.Campo).Caption = refoMensaje.RecuperarDescripcion(Me.NombreCompleto)
                        Me.Grid.RootTable.Columns(Me.Campo).HeaderAlignment = pvAlign
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub FijarTexto(ByRef refoColumna As Janus.Windows.GridEX.GridEXColumn, ByRef refoMensaje As CMensaje, Optional ByVal pvAlign As Janus.Windows.GridEX.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center)
        Try
            refoColumna.Caption = refoMensaje.RecuperarDescripcion(Me.NombreCompleto)
            refoColumna.HeaderAlignment = pvAlign
        Catch ex As Exception
        End Try
    End Sub

    Public Sub FijarTooltip(ByRef refoMensaje As CMensaje)
        Try
            If (Not Me.Grid Is Nothing) Then
                If (Not Me.Grid.RootTable Is Nothing) Then
                    If (Me.Grid.RootTable.Columns.Contains(Me.Campo)) Then
                        Me.Grid.RootTable.Columns(Me.Campo).HeaderToolTip = refoMensaje.RecuperarDescripcion(Me.NombreCompleto & Me.SufijoToolTip)
                    End If
                End If
            End If
        Catch ex As Exception
        End Try

    End Sub

    Public Sub FijarTooltip(ByRef refoColumna As Janus.Windows.GridEX.GridEXColumn, ByRef refoMensaje As CMensaje)
        Try
            refoColumna.HeaderToolTip = refoMensaje.RecuperarDescripcion(Me.NombreCompleto & Me.SufijoToolTip)
        Catch ex As Exception
        End Try
    End Sub

    Public Sub FijarAncho()
        Try
            If (Me.Ancho <> 0) Then
                If (Not Me.Grid Is Nothing) Then
                    If (Not Me.Grid.RootTable Is Nothing) Then
                        If (Me.Grid.RootTable.Columns.Contains(Me.Campo)) Then
                            Me.Grid.RootTable.Columns(Me.Campo).Width = Me.Ancho
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try

    End Sub

    Public Sub FijarAncho(ByRef refoColumna As Janus.Windows.GridEX.GridEXColumn)
        Try
            If (Me.Ancho <> 0) Then
                refoColumna.Width = Me.Ancho
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub FijarVisible()
        Try
            If (Not Me.Grid Is Nothing) Then
                If (Not Me.Grid.RootTable Is Nothing) Then
                    If (Me.Grid.RootTable.Columns.Contains(Me.Campo)) Then
                        Me.Grid.RootTable.Columns(Me.Campo).Visible = Me.Visible
                        Me.Grid.RootTable.Columns(Me.Campo).ShowInFieldChooser = Me.Visible
                    End If
                End If
            End If
        Catch ex As Exception
        End Try

    End Sub

    Public Sub FijarVisible(ByRef refoColumna As Janus.Windows.GridEX.GridEXColumn)
        Try
            refoColumna.Visible = Me.Visible
            refoColumna.ShowInFieldChooser = Me.Visible
        Catch ex As Exception
        End Try
    End Sub

    Public Sub FijarAlineacionDeTexto()
        Try
            If (Me.ValorReferencia <> "") Then
                Exit Sub
            End If
            If (Not Me.Grid Is Nothing) Then
                If (Not Me.Grid.RootTable Is Nothing) Then
                    If (Me.Grid.RootTable.Columns.Contains(Me.Campo)) Then
                        FijarAlineacionDeTexto(Me.Campo)
                    End If
                End If
            End If
        Catch ex As LbControlError.cError
            ex.Mostrar()
        End Try
    End Sub

    Private Sub FijarAlineacionDeTexto(ByVal pvColumna As String)
        Dim ldt As New DataTable

        If Me.Grid.DataSource.GetType Is GetType(DataTable) Then
            ldt = CType(Me.Grid.DataSource, DataTable)
        ElseIf Me.Grid.DataSource.GetType Is GetType(DataSet) Then
            ldt = CType(Me.Grid.DataSource, DataSet).Tables(Me.Grid.DataMember)
        End If

        If ldt.Columns(pvColumna).DataType Is GetType(Decimal) _
            OrElse ldt.Columns(pvColumna).DataType Is GetType(Double) _
            OrElse ldt.Columns(pvColumna).DataType Is GetType(Int16) _
            OrElse ldt.Columns(pvColumna).DataType Is GetType(Int32) _
            OrElse ldt.Columns(pvColumna).DataType Is GetType(Int64) _
            OrElse ldt.Columns(pvColumna).DataType Is GetType(Integer) _
            OrElse ldt.Columns(pvColumna).DataType Is GetType(Long) _
            OrElse ldt.Columns(pvColumna).DataType Is GetType(Short) _
            OrElse ldt.Columns(pvColumna).DataType Is GetType(Single) Then
            Me.Grid.RootTable.Columns(pvColumna).TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Else
            Me.Grid.RootTable.Columns(pvColumna).TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        End If

    End Sub

    Public Sub FijarEdicionColumna()
        Try
            If (Not Me.Grid Is Nothing) Then
                If (Not Me.Grid.RootTable Is Nothing) Then
                    If (Me.Grid.RootTable.Columns.Contains(Me.Campo)) Then

                        With Me.Grid.RootTable.Columns(Me.Campo)

                            If (Me.ValorReferencia <> "") Then
                                .HasValueList = True
                                .FilterEditType = Janus.Windows.GridEX.FilterEditType.Combo
                                If (Me.SoloLectura) Then
                                    .EditType = Janus.Windows.GridEX.EditType.NoEdit
                                Else
                                    .EditType = Janus.Windows.GridEX.EditType.DropDownList
                                End If
                            Else
                                'no tiene lista
                                .FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox
                                If (Me.SoloLectura) Then
                                    .EditType = Janus.Windows.GridEX.EditType.NoEdit
                                End If
                            End If
                        End With
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub FijarEdicionColumna(ByRef refoColumna As Janus.Windows.GridEX.GridEXColumn)
        Try
            With refoColumna

                If (Me.ValorReferencia <> "") Then
                    .HasValueList = True
                    .FilterEditType = Janus.Windows.GridEX.FilterEditType.Combo
                    If (Me.SoloLectura) Then
                        .EditType = Janus.Windows.GridEX.EditType.NoEdit
                    Else
                        .EditType = Janus.Windows.GridEX.EditType.DropDownList
                    End If
                Else
                    'no tiene lista
                    .FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox
                    If (Me.SoloLectura) Then
                        .EditType = Janus.Windows.GridEX.EditType.NoEdit
                    End If
                End If
            End With
        Catch ex As Exception
        End Try
    End Sub

    Public Sub FijarEdicionColumna(ByVal pvSoloLectura As Boolean)
        Try
            If (Not Me.Grid Is Nothing) Then
                If (Not Me.Grid.RootTable Is Nothing) Then
                    If (Me.Grid.RootTable.Columns.Contains(Me.Campo)) Then

                        With Me.Grid.RootTable.Columns(Me.Campo)

                            If (Me.ValorReferencia <> "") Then

                                .HasValueList = True
                                .FilterEditType = Janus.Windows.GridEX.FilterEditType.Combo
                                If (pvSoloLectura) Then
                                    .EditType = Janus.Windows.GridEX.EditType.NoEdit
                                Else
                                    .EditType = Janus.Windows.GridEX.EditType.DropDownList
                                End If
                            Else
                                'no tiene lista
                                .FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox
                                If (pvSoloLectura) Then
                                    .EditType = Janus.Windows.GridEX.EditType.NoEdit
                                End If
                            End If
                        End With
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub FijarEdicionColumna(ByRef refoColumna As Janus.Windows.GridEX.GridEXColumn, ByVal pvSoloLectura As Boolean)
        Try
            With refoColumna

                If (Me.ValorReferencia <> "") Then

                    .HasValueList = True
                    .FilterEditType = Janus.Windows.GridEX.FilterEditType.Combo
                    If (pvSoloLectura) Then
                        .EditType = Janus.Windows.GridEX.EditType.NoEdit
                    Else
                        .EditType = Janus.Windows.GridEX.EditType.DropDownList
                    End If
                Else
                    'no tiene lista
                    .FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox
                    If (pvSoloLectura) Then
                        .EditType = Janus.Windows.GridEX.EditType.NoEdit
                    End If
                End If
            End With
        Catch ex As Exception
        End Try
    End Sub

    Public Sub FijarPosicionColumna()
        Try
            If (Not Me.Grid Is Nothing) Then
                If (Not Me.Grid.RootTable Is Nothing) Then
                    If (Me.Grid.RootTable.Columns.Contains(Me.Campo)) Then
                        Me.Grid.RootTable.Columns(Me.Campo).Position = Me.PosicionInicial
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub FijarPosicionColumna(ByRef refoColumna As Janus.Windows.GridEX.GridEXColumn)
        Try
            refoColumna.Position = Me.PosicionInicial
        Catch ex As Exception
        End Try
    End Sub

    Public Overloads Sub FijarFormatStringColumna()
        If (Me.FormatString <> "") Then
            FijarFormatStringColumna(Me.FormatString)
        End If
    End Sub

    Public Overloads Sub FijarFormatStringColumna(ByRef refoColumna As Janus.Windows.GridEX.GridEXColumn)
        If (Me.FormatString <> "") Then
            FijarFormatStringColumna(refoColumna, Me.FormatString)
        End If
    End Sub

    Public Overloads Sub FijarInputMaskColumna()
        If (Me.InputMask <> "") Then
            FijarInputMaskColumna(Me.InputMask)
        End If
    End Sub

    Public Overloads Sub FijarInputMaskColumna(ByRef refoColumna As Janus.Windows.GridEX.GridEXColumn)
        If (Me.InputMask <> "") Then
            FijarInputMaskColumna(refoColumna, Me.InputMask)
        End If
    End Sub

    Public Overloads Sub FijarFormatStringColumna(ByVal pvFormatString As String)
        Try
            If (Not Me.Grid Is Nothing) Then
                If (Not Me.Grid.RootTable Is Nothing) Then
                    If (Me.Grid.RootTable.Columns.Contains(Me.Campo)) Then
                        Me.Grid.RootTable.Columns(Me.Campo).FormatString = pvFormatString
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Overloads Sub FijarFormatStringColumna(ByRef refoColumna As Janus.Windows.GridEX.GridEXColumn, ByVal pvFormatString As String)
        Try
            refoColumna.FormatString = pvFormatString
        Catch ex As Exception
        End Try
    End Sub

    Public Overloads Sub FijarInputMaskColumna(ByVal pvInputMask As String)
        Try
            If (Not Me.Grid Is Nothing) Then
                If (Not Me.Grid.RootTable Is Nothing) Then
                    If (Me.Grid.RootTable.Columns.Contains(Me.Campo)) Then
                        Me.Grid.RootTable.Columns(Me.Campo).InputMask = pvInputMask
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Overloads Sub FijarInputMaskColumna(ByRef refoColumna As Janus.Windows.GridEX.GridEXColumn, ByVal pvInputMask As String)
        Try
            refoColumna.InputMask = pvInputMask
        Catch ex As Exception
        End Try
    End Sub

    Public Sub CargarValorReferencia()

        Try

            'si tiene un valor por referencia
            If (Me.ValorReferencia <> "") Then

                If (Not Me.Grid Is Nothing) Then
                    If (Not Me.Grid.RootTable Is Nothing) Then
                        If (Me.Grid.RootTable.Columns.Contains(Me.Campo)) Then

                            'Me.Grid.RootTable.Columns(Me.Campo).HasValueList = True
                            'Me.Grid.RootTable.Columns(Me.Campo).EditType = Janus.Windows.GridEX.EditType.DropDownList

                            lbGeneral.LlenarColumna(Me.Grid.RootTable.Columns(Me.Campo), Me.ValorReferencia)

                        End If
                    End If
                End If

            End If

        Catch ex As Exception

        End Try

    End Sub

    Public Sub CargarValorReferencia(ByRef refoColumna As Janus.Windows.GridEX.GridEXColumn)

        Try

            'si tiene un valor por referencia
            If (Me.ValorReferencia <> "") Then

                'Me.Grid.RootTable.Columns(Me.Campo).HasValueList = True
                'Me.Grid.RootTable.Columns(Me.Campo).EditType = Janus.Windows.GridEX.EditType.DropDownList

                lbGeneral.LlenarColumna(refoColumna, Me.ValorReferencia)

            End If

        Catch ex As Exception

        End Try

    End Sub


    'Public Function ObtenerValorCapturado() As Object
    '    Dim valor As Object
    '    Dim oCtrlActivo As Control

    '    If (HayCtrlAlterno()) Then
    '        oCtrlActivo = RegresaControlActivo()
    '        valor = ObtenValorControl(oCtrlActivo)
    '    Else
    '        valor = ObtenValorControl(Me.CtrlCaptura)
    '    End If

    '    Return valor
    'End Function

    'Protected Function ObtenValorControl(ByRef prCtrl As Control) As Object
    '    Dim valor As Object

    '    Try
    '        Select Case prCtrl.GetType().ToString

    '            Case GetType(System.Windows.Forms.TextBox).ToString
    '                valor = CType(prCtrl, System.Windows.Forms.TextBox).Text

    '            Case GetType(Janus.Windows.GridEX.EditControls.EditBox).ToString
    '                valor = CType(prCtrl, Janus.Windows.GridEX.EditControls.EditBox).Text

    '            Case GetType(Janus.Windows.EditControls.UIComboBox).ToString
    '                valor = CType(prCtrl, Janus.Windows.EditControls.UIComboBox).SelectedValue

    '            Case GetType(Janus.Windows.CalendarCombo.CalendarCombo).ToString
    '                valor = CType(prCtrl, Janus.Windows.CalendarCombo.CalendarCombo).Value

    '            Case GetType(Janus.Windows.EditControls.UICheckBox).ToString
    '                valor = CType(prCtrl, Janus.Windows.EditControls.UICheckBox).Checked

    '            Case GetType(Janus.Windows.EditControls.UIRadioButton).ToString
    '                valor = CType(prCtrl, Janus.Windows.EditControls.UIRadioButton).Checked

    '            Case GetType(Janus.Windows.GridEX.EditControls.NumericEditBox).ToString
    '                valor = CType(prCtrl, Janus.Windows.GridEX.EditControls.NumericEditBox).Value

    '                'aqui se agregan todos los tipos necesarios
    '                'Case GetType().ToString

    '            Case Else
    '                valor = prCtrl.Text

    '        End Select
    '    Catch ex As Exception
    '        valor = Nothing
    '    End Try

    '    Return valor
    'End Function

    'Protected Function HayCtrlAlterno() As Boolean
    '    Return (Not Me.CtrlCapturaAlterno Is Nothing)
    'End Function

    'Protected Function RegresaControlActivo() As Control
    '    Dim oCtrlActivo As Control

    '    If (Me.CtrlCaptura.Visible) Then
    '        oCtrlActivo = Me.CtrlCaptura
    '    Else
    '        oCtrlActivo = Me.CtrlCapturaAlterno
    '    End If

    '    Return oCtrlActivo
    'End Function

    'Protected Function SoportaListaControlCaptura() As Boolean
    '    Dim bRes As Boolean

    '    Try
    '        Select Case Me.CtrlCaptura.GetType().ToString

    '            Case GetType(Janus.Windows.EditControls.UIComboBox).ToString
    '                bRes = True

    '            Case GetType(System.Windows.Forms.ComboBox).ToString
    '                bRes = True

    '                'aqui se agregan todos los tipos necesarios
    '                'Case GetType().ToString

    '            Case Else
    '                bRes = False
    '        End Select

    '    Catch ex As Exception
    '        bRes = False
    '    End Try

    '    Return bRes
    'End Function

    'Public Function EsNuloValorCapturado() As Boolean
    '    Dim oValor As Object
    '    Dim bRes As Boolean

    '    Try
    '        oValor = ObtenerValorCapturado()
    '        bRes = IsDBNull(oValor) Or IsNothing(oValor) Or (oValor = "")
    '    Catch ex As Exception
    '        bRes = False
    '    End Try

    '    Return bRes
    'End Function

    'Public Sub Focus()
    '    Dim oCtrlActivo As Control

    '    If (HayCtrlAlterno()) Then
    '        oCtrlActivo = RegresaControlActivo()
    '    Else
    '        oCtrlActivo = Me.CtrlCaptura
    '    End If

    '    If (Not oCtrlActivo Is Nothing) Then
    '        oCtrlActivo.Focus()
    '    End If

    'End Sub

    'Public Sub SetSoloLectura()

    '    If (Not Me.CtrlCaptura Is Nothing) Then
    '        Me.CtrlCaptura.Enabled = False
    '    End If
    '    If (Not Me.CtrlCapturaAlterno Is Nothing) Then
    '        Me.CtrlCapturaAlterno.Enabled = False
    '    End If
    'End Sub

#End Region

End Class

Public Class ManejoElementoInterfaz

#Region "Variables"
    Private sNombre As String
    'Private sMnemonicoTabla As String
    Private sSufijoToolTip As String
    Private oCtrl As Object
    Private bMostrarTexto As Boolean
    Private bMostrarTooltip As Boolean
    Private gControl As System.Windows.Forms.Control
    Private gBoton As DevComponents.DotNetBar.ButtonItem
    'Private oCtrlCaptura As Control
    'Private oCtrlEtiqueta As Control
    'Private bRequerido As Boolean
    'Private sValorReferencia As String
    Private bEsControl As Boolean
#End Region

#Region "Propiedades"
    Public Property Nombre() As String
        Get
            Return sNombre
        End Get
        Set(ByVal Value As String)
            sNombre = Value
        End Set
    End Property

    'Public Property MnemonicoTabla() As String
    '    Get
    '        Return sMnemonicoTabla
    '    End Get
    '    Set(ByVal Value As String)
    '        sMnemonicoTabla = Value
    '    End Set
    'End Property

    'Public ReadOnly Property NombreCompleto() As String
    '    Get
    '        Return Me.MnemonicoTabla & Me.Campo
    '    End Get
    'End Property

    Public Property SufijoToolTip() As String
        Get
            Return sSufijoToolTip
        End Get
        Set(ByVal Value As String)
            sSufijoToolTip = Value
        End Set
    End Property

    Public Property Ctrl() As Object
        Get
            Return oCtrl
        End Get
        Set(ByVal Value As Object)
            oCtrl = Value
        End Set
    End Property

    Public Property MostrarTexto() As Boolean
        Get
            Return bMostrarTexto
        End Get
        Set(ByVal Value As Boolean)
            bMostrarTexto = Value
        End Set
    End Property

    Public Property MostrarTooltip() As Boolean
        Get
            Return bMostrarTooltip
        End Get
        Set(ByVal Value As Boolean)
            bMostrarTooltip = Value
        End Set
    End Property

    'Public Property CtrlCaptura() As Control
    '    Get
    '        Return oCtrlCaptura
    '    End Get
    '    Set(ByVal Value As Control)
    '        oCtrlCaptura = Value
    '    End Set
    'End Property

    'Public Property CtrlEtiqueta() As Control
    '    Get
    '        Return oCtrlEtiqueta
    '    End Get
    '    Set(ByVal Value As Control)
    '        oCtrlEtiqueta = Value
    '    End Set
    'End Property

    'Public Property Requerido() As Boolean
    '    Get
    '        Return bRequerido
    '    End Get
    '    Set(ByVal Value As Boolean)
    '        bRequerido = Value
    '    End Set
    'End Property

    'Public Property ValorReferencia() As String
    '    Get
    '        Return sValorReferencia
    '    End Get
    '    Set(ByVal Value As String)
    '        sValorReferencia = Value
    '    End Set
    'End Property

#End Region

#Region "Constructores"
    'Public Sub New()

    'End Sub
    'Public Sub New(ByVal pvMnTabla As String, ByVal pvCampo As String, ByRef prCtrlEtiq As System.Windows.Forms.Control, ByRef prCtrlCaptura As System.Windows.Forms.Control, ByVal pvRequerido As Boolean, Optional ByVal pvValorReferencia As String = "")
    Public Sub New(ByVal pvNombre As String, ByRef prCtrl As System.Windows.Forms.Control, Optional ByVal pvMostrarTexto As Boolean = True, Optional ByVal pvMostrarTooltip As Boolean = True)
        Me.Nombre = pvNombre
        Me.Ctrl = prCtrl
        Me.SufijoToolTip = "T"
        Me.MostrarTexto = pvMostrarTexto
        Me.MostrarTooltip = pvMostrarTooltip
        Me.bEsControl = True
    End Sub

    Public Sub New(ByVal pvNombre As String, ByRef prCtrl As DevComponents.DotNetBar.ButtonItem, Optional ByVal pvMostrarTexto As Boolean = True, Optional ByVal pvMostrarTooltip As Boolean = True)
        Me.Nombre = pvNombre
        Me.Ctrl = prCtrl
        Me.SufijoToolTip = "T"
        Me.MostrarTexto = pvMostrarTexto
        Me.MostrarTooltip = pvMostrarTooltip
        Me.bEsControl = False
    End Sub

#End Region

#Region "Metodos"

    Public Overloads Overrides Function Equals(ByVal obj As Object) As Boolean
        Dim obj2 As ManejoElementoInterfaz

        If (obj.GetType Is GetType(ManejoElementoInterfaz)) Then
            obj2 = obj
            Return Me.Nombre.Equals(obj2.Nombre)
        Else
            Return False
        End If
    End Function

    Public Sub FijarTexto(ByRef refoMensaje As CMensaje)

        If (Me.MostrarTexto) Then
            If (Not Me.Ctrl Is Nothing) Then
                If (Me.bEsControl) Then
                    gControl = Me.Ctrl
                    gControl.Text = refoMensaje.RecuperarDescripcion(Me.Nombre)
                Else
                    'no aplica
                End If

            End If
        End If

    End Sub

    Public Sub FijarTooltip(ByRef refoMensaje As CMensaje, ByRef refoTT As System.Windows.Forms.ToolTip)

        If (Me.MostrarTooltip) Then
            If (Not Me.Ctrl Is Nothing) Then
                If (Me.bEsControl) Then
                    If (Not refoTT Is Nothing) Then
                        'vlControl = Me.Ctrl
                        refoTT.SetToolTip(Me.Ctrl, refoMensaje.RecuperarDescripcion(Me.Nombre & Me.SufijoToolTip))
                    End If
                Else
                    gBoton = Me.Ctrl
                    gBoton.Tooltip = refoMensaje.RecuperarDescripcion(Me.Nombre & Me.SufijoToolTip)
                End If
            End If
        End If

    End Sub

    'Public Sub CargarValorReferencia()

    '    Try

    '        'si tiene un valor por referencia
    '        If (Me.ValorReferencia <> "") Then
    '            'si es un combo 
    '            If (SoportaListaControlCaptura()) Then
    '                lbGeneral.LlenarComboBox(Me.CtrlCaptura, Me.ValorReferencia)
    '            End If
    '        End If

    '    Catch ex As Exception
    '    End Try

    'End Sub

    'Public Function ObtenerValorCapturado() As Object
    '    Dim valor As Object

    '    Try
    '        Select Case Me.CtrlCaptura.GetType().ToString

    '            Case GetType(System.Windows.Forms.TextBox).ToString
    '                valor = CType(Me.CtrlCaptura, System.Windows.Forms.TextBox).Text

    '            Case GetType(Janus.Windows.GridEX.EditControls.EditBox).ToString
    '                valor = CType(Me.CtrlCaptura, Janus.Windows.GridEX.EditControls.EditBox).Text

    '            Case GetType(Janus.Windows.EditControls.UIComboBox).ToString
    '                valor = CType(Me.CtrlCaptura, Janus.Windows.EditControls.UIComboBox).SelectedValue

    '            Case GetType(Janus.Windows.CalendarCombo.CalendarCombo).ToString
    '                valor = CType(Me.CtrlCaptura, Janus.Windows.CalendarCombo.CalendarCombo).Value

    '            Case GetType(Janus.Windows.EditControls.UICheckBox).ToString
    '                valor = CType(Me.CtrlCaptura, Janus.Windows.EditControls.UICheckBox).Checked

    '            Case GetType(Janus.Windows.EditControls.UIRadioButton).ToString
    '                valor = CType(Me.CtrlCaptura, Janus.Windows.EditControls.UIRadioButton).Checked

    '                'aqui se agregan todos los tipos necesarios
    '                'Case GetType().ToString

    '            Case Else
    '                valor = Me.CtrlCaptura.Text

    '        End Select
    '    Catch ex As Exception
    '        valor = Nothing
    '    End Try

    '    Return valor
    'End Function

    'Protected Function SoportaListaControlCaptura() As Boolean
    '    Dim bRes As Boolean

    '    Try
    '        Select Case Me.CtrlCaptura.GetType().ToString

    '            Case GetType(Janus.Windows.EditControls.UIComboBox).ToString
    '                bRes = True

    '            Case GetType(System.Windows.Forms.ComboBox).ToString
    '                bRes = True

    '                'aqui se agregan todos los tipos necesarios
    '                'Case GetType().ToString

    '            Case Else
    '                bRes = False
    '        End Select

    '    Catch ex As Exception
    '        bRes = False
    '    End Try

    '    Return bRes
    'End Function

    'Protected Function EsNuloValorCapturado() As Boolean
    '    Dim oValor As Object
    '    Dim bRes As Boolean

    '    Try
    '        oValor = ObtenerValorCapturado()
    '        bRes = IsDBNull(oValor) Or IsNothing(oValor) Or (oValor = "")
    '    Catch ex As Exception
    '        bRes = False
    '    End Try

    '    Return bRes
    'End Function

    Public Sub Focus()

        If (Not Me.Ctrl Is Nothing) Then
            If (Me.bEsControl) Then
                gControl = Me.Ctrl
                gControl.Focus()
            Else
                'no aplica
            End If
        End If

    End Sub
    Public Sub SoloLectura()

        If (Not Me.Ctrl Is Nothing) Then
            If (Me.bEsControl) Then
                gControl = Me.Ctrl
                gControl.Enabled = False
            Else

            End If
        End If

    End Sub

#End Region

End Class

Public Class InfoValorReferencia

#Region "Variables"
    Protected sTabla As String
    Protected sCampo As String
    Protected oCtrlListaValores As Control
    Protected oCtrlDescripcion As Control
#End Region

#Region "Propiedades"
    Public Property Tabla() As String
        Get
            Return sTabla
        End Get
        Set(ByVal Value As String)
            sTabla = Value
        End Set
    End Property
    Public Property Campo() As String
        Get
            Return sCampo
        End Get
        Set(ByVal Value As String)
            sCampo = Value
        End Set
    End Property
    Public Property CtrlListaValores() As Control
        Get
            Return oCtrlListaValores
        End Get
        Set(ByVal Value As Control)
            oCtrlListaValores = Value
        End Set
    End Property
    Public Property CtrlDescripcion() As Control
        Get
            Return oCtrlDescripcion
        End Get
        Set(ByVal Value As Control)
            oCtrlDescripcion = Value
        End Set
    End Property
#End Region

#Region "Constructores"

    Public Sub New(ByVal pvTabla As String, ByVal pvCampo As String, ByRef prCtrlListaValores As Control, ByRef prCtrlDescripcion As Control)
        Me.Tabla = pvTabla
        Me.Campo = pvCampo
        Me.CtrlListaValores = prCtrlListaValores
        Me.CtrlDescripcion = prCtrlDescripcion
    End Sub

#End Region

End Class

'esta es visual
Public Class InfoLLaveExterna

#Region "Variables"
    Protected oObjetoExterno As BASLOG.cClaseNodo
    Protected sCampoClave As String
    Protected sCampoClaveReal As String
    Protected sCampoDescripcion As String
    Protected sFiltroExtra As String
    Protected bEsCadenaClave As Boolean
    Protected oCtrlClaveReal As Control
    Protected oCtrlClave As Control
    Protected oCtrlDescripcion As Control
    Protected sCodigoError As String
#End Region

#Region "Propiedades"
    Public Property ObjetoExterno() As BASLOG.cClaseNodo
        Get
            Return oObjetoExterno
        End Get
        Set(ByVal Value As BASLOG.cClaseNodo)
            oObjetoExterno = Value
        End Set
    End Property
    Public Property CampoClave() As String
        Get
            Return sCampoClave
        End Get
        Set(ByVal Value As String)
            sCampoClave = Value
        End Set
    End Property
    Public Property CampoClaveReal() As String
        Get
            Return sCampoClaveReal
        End Get
        Set(ByVal Value As String)
            sCampoClaveReal = Value
        End Set
    End Property
    Public Property CampoDescripcion() As String
        Get
            Return sCampoDescripcion
        End Get
        Set(ByVal Value As String)
            sCampoDescripcion = Value
        End Set
    End Property
    Public Property FiltroExtra() As String
        Get
            Return sFiltroExtra
        End Get
        Set(ByVal Value As String)
            sFiltroExtra = Value
        End Set
    End Property
    Public Property CtrlClave() As Control
        Get
            Return oCtrlClave
        End Get
        Set(ByVal Value As Control)
            oCtrlClave = Value
        End Set
    End Property
    Public Property CtrlClaveReal() As Control
        Get
            Return oCtrlClaveReal
        End Get
        Set(ByVal Value As Control)
            oCtrlClaveReal = Value
        End Set
    End Property
    Public Property CtrlDescripcion() As Control
        Get
            Return oCtrlDescripcion
        End Get
        Set(ByVal Value As Control)
            oCtrlDescripcion = Value
        End Set
    End Property
    Public Property EsCadenaClave() As Boolean
        Get
            Return bEsCadenaClave
        End Get
        Set(ByVal Value As Boolean)
            bEsCadenaClave = Value
        End Set
    End Property
    Public Property CodigoError() As String
        Get
            Return sCodigoError
        End Get
        Set(ByVal Value As String)
            sCodigoError = Value
        End Set
    End Property
#End Region

#Region "Constructores"

    Public Sub New(ByRef prObjExt As BASLOG.cClaseNodo, ByVal pvCampoClave As String, ByVal pvCampoDescripcion As String, ByRef prCtrlClave As Control, ByRef prCtrlDescripcion As Control, ByVal pvCodigoError As String, Optional ByVal pvFiltroExtra As String = "", Optional ByVal pvEsCadenaClave As Boolean = True)
        Me.ObjetoExterno = prObjExt
        Me.CampoClave = pvCampoClave
        Me.CampoDescripcion = pvCampoDescripcion
        Me.CtrlClave = prCtrlClave
        Me.CtrlDescripcion = prCtrlDescripcion
        Me.CodigoError = pvCodigoError
        Me.FiltroExtra = pvFiltroExtra
        Me.EsCadenaClave = pvEsCadenaClave
    End Sub

#End Region

#Region "Metodos Publicos"
    Public Function ExisteClave(ByRef prRenglon As DataRow) As Boolean
        Dim dtRes As DataTable
        Dim bres As Boolean

        If (Not Me.ObjetoExterno Is Nothing) Then

            dtRes = Me.ObjetoExterno.tablanodo.recuperar(RegresaFiltroSeleccion())

            If (Not dtRes Is Nothing) Then
                If ((dtRes.Rows.Count > 0)) Then
                    bres = True
                    prRenglon = dtRes.Rows(0)
                End If
            End If

        End If

        Return bres
    End Function

    Public Sub LimpiarControlClave()
        If (Not Me.CtrlClave Is Nothing) Then
            Me.CtrlClave.Text = ""
        End If
    End Sub
    Public Sub LimpiarControlClaveReal()
        If (Not Me.CtrlClaveReal Is Nothing) Then
            Me.CtrlClaveReal.Text = ""
        End If
    End Sub
    Public Sub LimpiarControlDescripcion()
        If (Not Me.CtrlDescripcion Is Nothing) Then
            Me.CtrlDescripcion.Text = ""
        End If
    End Sub

    Public Sub PonValorClave(ByRef prRenglon As DataRow)
        Try
            If (Not Me.CtrlClave Is Nothing) Then
                If (Not prRenglon Is Nothing) Then
                    Me.CtrlClave.Text = prRenglon(Me.CampoClave).ToString()
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub PonValorClaveReal(ByRef prRenglon As DataRow)
        Try
            If (Not Me.CtrlClaveReal Is Nothing) Then
                If (Not prRenglon Is Nothing) Then
                    If (Me.CampoClaveReal <> "") Then
                        Me.CtrlClaveReal.Text = prRenglon(Me.CampoClaveReal).ToString()
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub PonValorDescripcion(ByRef prRenglon As DataRow)
        Try
            If (Not Me.CtrlDescripcion Is Nothing) Then
                If (Not prRenglon Is Nothing) Then
                    Me.CtrlDescripcion.Text = prRenglon(Me.CampoDescripcion).ToString()
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Function CapturoClave() As Boolean
        Dim bRes As Boolean

        If (Not Me.CtrlClave Is Nothing) Then
            bRes = (Me.CtrlClave.Text <> "")
        End If

        Return bRes
    End Function

#End Region

#Region "Metodos Internos"
    Protected Function RegresaFiltroSeleccion() As String
        Dim sFiltro As System.Text.StringBuilder

        sFiltro = New System.Text.StringBuilder(100)

        sFiltro.Append(Me.CampoClave)
        sFiltro.Append(" = ")

        If (Me.bEsCadenaClave) Then
            sFiltro.Append(String.Format("'{0}'", Me.CtrlClave.Text))
        Else
            sFiltro.Append(Me.CtrlClave.Text)
        End If

        If (Me.FiltroExtra <> "") Then
            sFiltro.Append(" AND ")
            sFiltro.Append(sFiltroExtra)
        End If

        Return sFiltro.ToString
    End Function
#End Region

End Class

'esta es mas generica, para usarla en el grid
Public Class ValidacionLLaveExterna

#Region "Variables"
    Protected oObjetoExterno As BASLOG.cClaseNodo
    Protected sCampoClave As String
    Protected sCampoDescripcion As String
    Protected sFiltroExtra As String
    Protected bEsCadenaClave As Boolean
    Protected sCodigoError As String
#End Region

#Region "Propiedades"
    Public Property ObjetoExterno() As BASLOG.cClaseNodo
        Get
            Return oObjetoExterno
        End Get
        Set(ByVal Value As BASLOG.cClaseNodo)
            oObjetoExterno = Value
        End Set
    End Property
    Public Property CampoClave() As String
        Get
            Return sCampoClave
        End Get
        Set(ByVal Value As String)
            sCampoClave = Value
        End Set
    End Property
    Public Property CampoDescripcion() As String
        Get
            Return sCampoDescripcion
        End Get
        Set(ByVal Value As String)
            sCampoDescripcion = Value
        End Set
    End Property
    Public Property FiltroExtra() As String
        Get
            Return sFiltroExtra
        End Get
        Set(ByVal Value As String)
            sFiltroExtra = Value
        End Set
    End Property
    Public Property EsCadenaClave() As Boolean
        Get
            Return bEsCadenaClave
        End Get
        Set(ByVal Value As Boolean)
            bEsCadenaClave = Value
        End Set
    End Property
    Public Property CodigoError() As String
        Get
            Return sCodigoError
        End Get
        Set(ByVal Value As String)
            sCodigoError = Value
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New(ByRef prObjExt As BASLOG.cClaseNodo, ByVal pvCampoClave As String, ByVal pvCodigoError As String, Optional ByVal pvFiltroExtra As String = "", Optional ByVal pvEsCadenaClave As Boolean = True, Optional ByVal pvCampoDescripcion As String = "")
        Me.ObjetoExterno = prObjExt
        Me.CampoClave = pvCampoClave
        Me.CodigoError = pvCodigoError
        Me.FiltroExtra = pvFiltroExtra
        Me.EsCadenaClave = pvEsCadenaClave
        Me.CampoDescripcion = pvCampoDescripcion
    End Sub
#End Region

#Region "Metodos Publicos"
    Public Function ExisteClave(ByVal pvValorCapturado As String, ByRef prRenglon As DataRow) As Boolean
        Dim dtRes As DataTable
        Dim bres As Boolean

        Try

            If (Not Me.ObjetoExterno Is Nothing) Then

                dtRes = Me.ObjetoExterno.TablaNodo.Recuperar(RegresaFiltroSeleccion(pvValorCapturado))

                If (Not dtRes Is Nothing) Then
                    If ((dtRes.Rows.Count > 0)) Then
                        bres = True
                        prRenglon = dtRes.Rows(0)
                    End If
                End If

            End If

        Catch ex As Exception
            bres = False
        End Try

        Return bres
    End Function
    Public Function RegresaClaveRenglon(ByRef prRenglon As DataRow) As Object
        Dim oClave As Object = Nothing

        Try
            If (Not prRenglon Is Nothing) Then
                oClave = prRenglon(Me.CampoClave)
            End If
        Catch ex As Exception
        End Try

        Return oClave
    End Function
    Public Function RegresaDescripcionRenglon(ByRef prRenglon As DataRow) As Object
        Dim oDesc As Object = Nothing

        Try
            If (Not prRenglon Is Nothing) Then
                If (Me.CampoDescripcion <> "") Then
                    oDesc = prRenglon(Me.CampoDescripcion)
                End If
            End If
        Catch ex As Exception
        End Try

        Return oDesc
    End Function
#End Region

#Region "Metodos Internos"
    Protected Function RegresaFiltroSeleccion(ByVal pvValorCapturado As String) As String
        Dim sFiltro As System.Text.StringBuilder

        sFiltro = New System.Text.StringBuilder(100)

        sFiltro.Append(Me.CampoClave)
        sFiltro.Append(" = ")

        If (Me.bEsCadenaClave) Then
            sFiltro.Append(String.Format("'{0}'", pvValorCapturado))
        Else
            sFiltro.Append(pvValorCapturado)
        End If

        If (Me.FiltroExtra <> "") Then
            sFiltro.Append(" AND ")
            sFiltro.Append(sFiltroExtra)
        End If

        Return sFiltro.ToString
    End Function
#End Region

End Class
