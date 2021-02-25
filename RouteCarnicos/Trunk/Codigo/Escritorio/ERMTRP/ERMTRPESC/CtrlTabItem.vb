Imports Janus.Windows.GridEX.EditControls
Imports Janus.Windows.CalendarCombo
Imports Janus.Windows.EditControls


Public Class CtrlCampos
    Public Enum ETipoDato
        Texto = 1
        Entero = 2
        [Decimal] = 3
        Fecha = 4
        Lista = 5
    End Enum

    Dim cControl As Control

    Private _ADDDID As String
    Private _Requerido As Boolean
    Private _TipoDato As ETipoDato
    Private _LongMin As Int16
    Private _LongMax As Int16
    Private epErrores As System.Windows.Forms.ErrorProvider
    Private oMensaje As BASMENLOG.CMensaje
    
    Public ReadOnly Property ADDDId() As String
        Get
            Return _ADDDID
        End Get
    End Property
    Public ReadOnly Property Requerido() As Boolean
        Get
            Return _Requerido
        End Get
    End Property
    Public ReadOnly Property TipoDato() As ETipoDato
        Get
            Return _TipoDato
        End Get
    End Property
    Public ReadOnly Property LongMin() As Int16
        Get
            Return _LongMin
        End Get
    End Property
    Public ReadOnly Property LongMax() As Int16
        Get
            Return _LongMax
        End Get
    End Property

    Public ReadOnly Property Titulo() As String
        Get
            Return Label1.Text
        End Get
    End Property

    Public Property Valor() As String
        Get
            Select Case _TipoDato
                Case ETipoDato.Texto
                    If CType(cControl, EditBox).Text Is Nothing Then
                        Return ""
                    Else
                        Return CType(cControl, EditBox).Text
                    End If
                Case ETipoDato.Entero
                    If CType(cControl, NumericEditBox).Value Is Nothing Then
                        Return ""
                    Else
                        Return CType(cControl, NumericEditBox).Value.ToString
                    End If
                Case ETipoDato.Decimal
                    If CType(cControl, NumericEditBox).Value Is Nothing Then
                        Return ""
                    Else
                        Return CType(cControl, NumericEditBox).Value.ToString
                    End If
                Case ETipoDato.Fecha
                    If CType(cControl, DateTimePicker).Value = New Date(1900, 1, 1, 0, 0, 0) Or CType(cControl, DateTimePicker).CustomFormat = " " Then
                        Return ""
                    Else
                        Return CType(cControl, DateTimePicker).Value.ToString("yyyy-MM-dd")
                    End If
                    'If CType(cControl, CalendarCombo).Value = New Date(1900, 1, 1, 0, 0, 0) Then
                    '    Return ""
                    'Else
                    '    Return CType(cControl, CalendarCombo).Value.ToString("yyyy-MM-dd")
                    'End If
                Case ETipoDato.Lista
                    If CType(cControl, UIComboBox).SelectedValue Is Nothing Then
                        Return ""
                    Else
                        Return CType(cControl, UIComboBox).SelectedValue.ToString
                    End If
            End Select
        End Get
        Set(ByVal value As String)
            Select Case _TipoDato
                Case ETipoDato.Texto
                    CType(cControl, EditBox).Text = value
                Case ETipoDato.Entero
                    CType(cControl, NumericEditBox).Value = value
                Case ETipoDato.Decimal
                    CType(cControl, NumericEditBox).Value = value
                Case ETipoDato.Fecha
                    CType(cControl, DateTimePicker).Value = CType(cControl, DateTimePicker).MaxDate
                    CType(cControl, DateTimePicker).Value = value
                    'CType(cControl, CalendarCombo).Value = CType(cControl, CalendarCombo).MaxDate
                    'CType(cControl, CalendarCombo).Value = value
                Case ETipoDato.Lista
                    CType(cControl, UIComboBox).SelectedValue = value
            End Select
        End Set
    End Property

    Public Sub New(ByVal oMsg As BASMENLOG.CMensaje)
        MyBase.New()
        InitializeComponent()

        oMensaje = oMsg
        Me.epErrores = New System.Windows.Forms.ErrorProvider()
    End Sub

    Public Sub AgregarCampo(ByVal Etiqueta As String, ByVal Valor As String, ByVal ADDDId As String, ByVal Requerido As Boolean, ByVal TipoDato As ETipoDato, ByVal LongMin As Int16, ByVal LongMax As Int16)
        Me.Label1.Text = Etiqueta

        _ADDDID = ADDDId
        _Requerido = Requerido
        _TipoDato = TipoDato
        _LongMin = LongMin
        _LongMax = LongMax

        Select Case TipoDato
            Case ETipoDato.Texto
                AgregarTexto(cControl)
            Case ETipoDato.Entero
                AgregarEntero(cControl)
            Case ETipoDato.Decimal
                AgregarDecimal(cControl)
            Case ETipoDato.Fecha
                AgregarFecha(cControl)
            Case ETipoDato.Lista
                AgregarLista(cControl, Valor)
        End Select


        Me.Controls.Add(Me.cControl)

        'If oCAFConfiguracion.Valor <> "" Then
        '    'Me.Visible = False
        '    cControl.Text = oCAFConfiguracion.Valor
        '    cControl.Enabled = False
        'End If


    End Sub

    Private Sub AgregarTexto(ByRef cControl As Control)
        cControl = New EditBox
        CType(cControl, EditBox).Location = New System.Drawing.Point(6, 23)
        CType(cControl, EditBox).Name = "ebControl"
        CType(cControl, EditBox).Size = New System.Drawing.Size(225, 20)
        CType(cControl, EditBox).TabIndex = 0
        CType(cControl, EditBox).TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        CType(cControl, EditBox).VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        CType(cControl, EditBox).MaxLength = _LongMax
        AddHandler (CType(cControl, EditBox).Validated), AddressOf ValidarLongitud

    End Sub

    Private Sub ValidarLongitud(ByVal sender As Object, ByVal e As EventArgs)
        Dim sValor As String
        sValor = CType(sender, EditBox).Text
        If sValor.Trim = String.Empty Then
            epErrores.SetError(sender, "")
        Else
            If sValor.Length < _LongMin Or sValor.Length > _LongMax Then
                epErrores.SetError(sender, oMensaje.RecuperarDescripcion("E0825", New String() {_LongMin, _LongMax}))
            Else
                epErrores.SetError(sender, "")
            End If
        End If
    End Sub

    Private Sub AgregarEntero(ByRef cControl As Control)
        cControl = New NumericEditBox
        CType(cControl, NumericEditBox).DecimalDigits = 0
        CType(cControl, NumericEditBox).Enabled = True
        CType(cControl, NumericEditBox).FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Number
        CType(cControl, NumericEditBox).Location = New System.Drawing.Point(6, 23)
        CType(cControl, NumericEditBox).Name = "ebControl"
        CType(cControl, NumericEditBox).Size = New System.Drawing.Size(225, 20)
        CType(cControl, NumericEditBox).TabIndex = 0
        CType(cControl, NumericEditBox).NullBehavior = Janus.Windows.GridEX.NumericEditNullBehavior.AllowDBNull
        CType(cControl, NumericEditBox).Value = DBNull.Value
        'CType(cControl, NumericEditBox).Text = "0"
        CType(cControl, NumericEditBox).TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        'CType(cControl, NumericEditBox).Value = New Decimal(New Integer() {0, 0, 0, 0})
        'CType(cControl, NumericEditBox).MaxLength = oCAFConfiguracion.Maximo
        CType(cControl, NumericEditBox).VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
    End Sub

    Private Sub AgregarDecimal(ByRef cControl As Control)
        cControl = New NumericEditBox
        CType(cControl, NumericEditBox).DecimalDigits = 2
        CType(cControl, NumericEditBox).Enabled = True
        CType(cControl, NumericEditBox).FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Number
        CType(cControl, NumericEditBox).Location = New System.Drawing.Point(6, 23)
        CType(cControl, NumericEditBox).Name = "ebControl"
        CType(cControl, NumericEditBox).Size = New System.Drawing.Size(225, 20)
        CType(cControl, NumericEditBox).TabIndex = 0
        CType(cControl, NumericEditBox).NullBehavior = Janus.Windows.GridEX.NumericEditNullBehavior.AllowDBNull
        CType(cControl, NumericEditBox).Value = DBNull.Value
        'CType(cControl, NumericEditBox).Text = "0.00"
        CType(cControl, NumericEditBox).TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        'CType(cControl, NumericEditBox).Value = New Decimal(New Integer() {0, 0, 0, 0})
        CType(cControl, NumericEditBox).VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
    End Sub

    Private Sub AgregarFecha(ByRef cControl As Control)
        'cControl = New CalendarCombo
        'CType(cControl, CalendarCombo).CustomFormat = "dd/mm/yyyy"
        'CType(cControl, CalendarCombo).Nullable = True
        'CType(cControl, CalendarCombo).NullValue = New Date(1900, 1, 1, 0, 0, 0, 0)
        'CType(cControl, CalendarCombo).Value = New Date(1900, 1, 1, 0, 0, 0, 0)
        'CType(cControl, CalendarCombo).DropDownCalendar.Name = ""
        'CType(cControl, CalendarCombo).DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
        'CType(cControl, CalendarCombo).Location = New System.Drawing.Point(6, 23)
        'CType(cControl, CalendarCombo).Name = "ebDiaClave"
        'CType(cControl, CalendarCombo).Size = New System.Drawing.Size(225, 20)
        'CType(cControl, CalendarCombo).TabIndex = 0
        'CType(cControl, CalendarCombo).VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007

        cControl = New DateTimePicker
        CType(cControl, DateTimePicker).CustomFormat = " "
        CType(cControl, DateTimePicker).Format = DateTimePickerFormat.Custom
        CType(cControl, DateTimePicker).Value = Date.Now 'New Date(1900, 1, 1, 0, 0, 0, 0)
        CType(cControl, DateTimePicker).Location = New System.Drawing.Point(6, 23)
        CType(cControl, DateTimePicker).Name = "ebDiaClave"
        CType(cControl, DateTimePicker).Size = New System.Drawing.Size(225, 20)
        CType(cControl, DateTimePicker).TabIndex = 0

        AddHandler (CType(cControl, DateTimePicker).ValueChanged), AddressOf DateTimePicker_ValueChanged
    End Sub

    Private Sub DateTimePicker_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        CType(sender, DateTimePicker).CustomFormat = "dd/MM/yyyy"
    End Sub

    Private Sub AgregarLista(ByRef cControl As Control, ByVal sValores As String)
        cControl = New UIComboBox
        Call ObtenerDatosComboBox(sValores, cControl)
        CType(cControl, UIComboBox).Location = New System.Drawing.Point(6, 23)
        CType(cControl, UIComboBox).Name = "cbControl"
        CType(cControl, UIComboBox).Enabled = True
        CType(cControl, UIComboBox).Size = New System.Drawing.Size(225, 20)
        CType(cControl, UIComboBox).TabIndex = 0
        CType(cControl, UIComboBox).VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        CType(cControl, UIComboBox).ComboStyle = ComboStyle.DropDownList
    End Sub

    'Public WriteOnly Property CAFConfiguracion() As ERMCAFLOG.cCAFConfiguracion
    '    Set(ByVal value As ERMCAFLOG.cCAFConfiguracion)
    '        oCAFConfiguracion = value

    '        If oCAFConfiguracion.Etiqueta = "" Then
    '            Me.Label1.Text = oCAFConfiguracion.Nodo
    '        Else
    '            Me.Label1.Text = oCAFConfiguracion.Etiqueta
    '        End If

    '        Select Case oCAFConfiguracion.TipoDato.ToUpper
    '            Case "INTEGER"
    '                cControl = New NumericEditBox
    '                CType(cControl, NumericEditBox).DecimalDigits = 0
    '                CType(cControl, NumericEditBox).Enabled = True
    '                CType(cControl, NumericEditBox).FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Number
    '                CType(cControl, NumericEditBox).Location = New System.Drawing.Point(6, 23)
    '                CType(cControl, NumericEditBox).Name = "ebControl"
    '                CType(cControl, NumericEditBox).Size = New System.Drawing.Size(225, 20)
    '                CType(cControl, NumericEditBox).TabIndex = 0
    '                CType(cControl, NumericEditBox).Text = "0"
    '                CType(cControl, NumericEditBox).TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
    '                CType(cControl, NumericEditBox).Value = New Decimal(New Integer() {0, 0, 0, 0})
    '                CType(cControl, NumericEditBox).MaxLength = oCAFConfiguracion.Maximo
    '                CType(cControl, NumericEditBox).VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007

    '            Case "DECIMAL"
    '                cControl = New NumericEditBox
    '                CType(cControl, NumericEditBox).DecimalDigits = 2
    '                CType(cControl, NumericEditBox).Enabled = True
    '                CType(cControl, NumericEditBox).FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
    '                CType(cControl, NumericEditBox).Location = New System.Drawing.Point(6, 23)
    '                CType(cControl, NumericEditBox).Name = "ebControl"
    '                CType(cControl, NumericEditBox).Size = New System.Drawing.Size(225, 20)
    '                CType(cControl, NumericEditBox).TabIndex = 0
    '                CType(cControl, NumericEditBox).Text = "$0.00"
    '                CType(cControl, NumericEditBox).TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
    '                CType(cControl, NumericEditBox).Value = New Decimal(New Integer() {0, 0, 0, 0})
    '                CType(cControl, NumericEditBox).VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007

    '            Case "DATE"
    '                cControl = New CalendarCombo
    '                CType(cControl, CalendarCombo).CustomFormat = "dd/mm/yyyy"
    '                CType(cControl, CalendarCombo).DropDownCalendar.FirstMonth = New Date(2007, 8, 1, 0, 0, 0, 0)
    '                CType(cControl, CalendarCombo).DropDownCalendar.Name = ""
    '                CType(cControl, CalendarCombo).DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007
    '                CType(cControl, CalendarCombo).Location = New System.Drawing.Point(6, 23)
    '                CType(cControl, CalendarCombo).Name = "ebDiaClave"
    '                CType(cControl, CalendarCombo).Size = New System.Drawing.Size(223, 20)
    '                CType(cControl, CalendarCombo).TabIndex = 0
    '                CType(cControl, CalendarCombo).VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007

    '            Case "NMTOKEN"
    '                cControl = New UIComboBox
    '                Call ObtenerDatosComboBox(oCAFConfiguracion.Nodo, cControl)
    '                CType(cControl, UIComboBox).Location = New System.Drawing.Point(6, 23)
    '                CType(cControl, UIComboBox).Name = "cbControl"
    '                CType(cControl, UIComboBox).Enabled = True
    '                CType(cControl, UIComboBox).Size = New System.Drawing.Size(225, 20)
    '                CType(cControl, UIComboBox).TabIndex = 0
    '                CType(cControl, UIComboBox).VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
    '                CType(cControl, UIComboBox).ComboStyle = ComboStyle.DropDownList

    '            Case Else '"STRING"
    '                cControl = New EditBox
    '                CType(cControl, EditBox).Location = New System.Drawing.Point(3, 23)
    '                CType(cControl, EditBox).Name = "ebClienteClave"
    '                CType(cControl, EditBox).Size = New System.Drawing.Size(225, 20)
    '                CType(cControl, EditBox).TabIndex = 0
    '                CType(cControl, EditBox).TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
    '                CType(cControl, EditBox).VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007

    '        End Select
    '        Me.Controls.Add(Me.cControl)

    '        If oCAFConfiguracion.Valor <> "" Then
    '            'Me.Visible = False
    '            cControl.Text = oCAFConfiguracion.Valor
    '            cControl.Enabled = False
    '        End If

    '    End Set
    'End Property

    'Public WriteOnly Property CAFDetalle() As System.Collections.Generic.List(Of ERMCAFLOG.cCAFDetalle)
    '    Set(ByVal value As System.Collections.Generic.List(Of ERMCAFLOG.cCAFDetalle))

    '        For Each CAFD As ERMCAFLOG.cCAFDetalle In value
    '            If CAFD.Nodo = oCAFConfiguracion.Nodo Then
    '                SetValor = CAFD.Valor
    '                Exit For
    '            End If
    '        Next

    '    End Set
    'End Property

    'Public ReadOnly Property ClienteClave() As String
    '    Get
    '        Return oCAFConfiguracion.ClienteClave
    '    End Get
    'End Property

    'Public ReadOnly Property Nodo() As String
    '    Get
    '        Return oCAFConfiguracion.Nodo
    '    End Get
    'End Property

    Public WriteOnly Property Habilitar() As Boolean
        Set(ByVal value As Boolean)
            cControl.Enabled = value
        End Set
    End Property

    Private Sub ObtenerDatosComboBox(ByVal sValores As String, ByRef cControl As UIComboBox)
        Dim aValores() As String = sValores.Split("|")
        If aValores.Length > 0 Then
            For Each sValor As String In aValores
                cControl.Items.Add(sValor, sValor)
            Next
        End If
    End Sub

End Class
