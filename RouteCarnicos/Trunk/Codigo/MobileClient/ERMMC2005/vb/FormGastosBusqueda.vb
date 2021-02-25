Public Class FormGastosBusqueda
    Inherits System.Windows.Forms.Form
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
    End Sub


    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If Not Me.MenuItemRegresar Is Nothing Then Me.MenuItemRegresar.Dispose()
        If Not Me.MainMenu1 Is Nothing Then Me.MainMenu1.Dispose()
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.MenuItemRegresar = New System.Windows.Forms.MenuItem
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.dtpFechaFin = New System.Windows.Forms.DateTimePicker
        Me.dtpFechaIni = New System.Windows.Forms.DateTimePicker
        Me.ComboBoxFecha = New System.Windows.Forms.ComboBox
        Me.TextBoxTotalFin = New System.Windows.Forms.TextBox
        Me.ButtonRegresar = New System.Windows.Forms.Button
        Me.ButtonContinuar = New System.Windows.Forms.Button
        Me.TextBoxTotalIni = New System.Windows.Forms.TextBox
        Me.ComboBoxTotal = New System.Windows.Forms.ComboBox
        Me.CheckBoxTotal = New System.Windows.Forms.CheckBox
        Me.ComboBoxConcepto = New System.Windows.Forms.ComboBox
        Me.CheckBoxConcepto = New System.Windows.Forms.CheckBox
        Me.CheckBoxFecha = New System.Windows.Forms.CheckBox
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.Add(Me.MenuItemRegresar)
        '
        'MenuItemRegresar
        '
        Me.MenuItemRegresar.Text = "MenuItemRegresar"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.dtpFechaFin)
        Me.Panel1.Controls.Add(Me.dtpFechaIni)
        Me.Panel1.Controls.Add(Me.ComboBoxFecha)
        Me.Panel1.Controls.Add(Me.TextBoxTotalFin)
        Me.Panel1.Controls.Add(Me.ButtonRegresar)
        Me.Panel1.Controls.Add(Me.ButtonContinuar)
        Me.Panel1.Controls.Add(Me.TextBoxTotalIni)
        Me.Panel1.Controls.Add(Me.ComboBoxTotal)
        Me.Panel1.Controls.Add(Me.CheckBoxTotal)
        Me.Panel1.Controls.Add(Me.ComboBoxConcepto)
        Me.Panel1.Controls.Add(Me.CheckBoxConcepto)
        Me.Panel1.Controls.Add(Me.CheckBoxFecha)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(242, 295)
        '
        'dtpFechaFin
        '
        Me.dtpFechaFin.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaFin.Location = New System.Drawing.Point(147, 44)
        Me.dtpFechaFin.MaxDate = New Date(2500, 12, 31, 0, 0, 0, 0)
        Me.dtpFechaFin.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dtpFechaFin.Name = "dtpFechaFin"
        Me.dtpFechaFin.Size = New System.Drawing.Size(88, 22)
        Me.dtpFechaFin.TabIndex = 14
        Me.dtpFechaFin.Value = New Date(2007, 1, 30, 0, 0, 0, 0)
        '
        'dtpFechaIni
        '
        Me.dtpFechaIni.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaIni.Enabled = False
        Me.dtpFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaIni.Location = New System.Drawing.Point(147, 17)
        Me.dtpFechaIni.MaxDate = New Date(2500, 12, 31, 0, 0, 0, 0)
        Me.dtpFechaIni.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dtpFechaIni.Name = "dtpFechaIni"
        Me.dtpFechaIni.Size = New System.Drawing.Size(88, 22)
        Me.dtpFechaIni.TabIndex = 13
        Me.dtpFechaIni.Value = New Date(2007, 1, 30, 0, 0, 0, 0)
        '
        'ComboBoxFecha
        '
        Me.ComboBoxFecha.Enabled = False
        Me.ComboBoxFecha.Location = New System.Drawing.Point(77, 18)
        Me.ComboBoxFecha.Name = "ComboBoxFecha"
        Me.ComboBoxFecha.Size = New System.Drawing.Size(69, 22)
        Me.ComboBoxFecha.TabIndex = 12
        '
        'TextBoxTotalFin
        '
        Me.TextBoxTotalFin.Enabled = False
        Me.TextBoxTotalFin.Location = New System.Drawing.Point(147, 133)
        Me.TextBoxTotalFin.Name = "TextBoxTotalFin"
        Me.TextBoxTotalFin.Size = New System.Drawing.Size(88, 21)
        Me.TextBoxTotalFin.TabIndex = 18
        '
        'ButtonRegresar
        '
        Me.ButtonRegresar.Location = New System.Drawing.Point(84, 262)
        Me.ButtonRegresar.Name = "ButtonRegresar"
        Me.ButtonRegresar.Size = New System.Drawing.Size(72, 24)
        Me.ButtonRegresar.TabIndex = 16
        Me.ButtonRegresar.Text = "ButtonRegresar"
        '
        'ButtonContinuar
        '
        Me.ButtonContinuar.Location = New System.Drawing.Point(5, 262)
        Me.ButtonContinuar.Name = "ButtonContinuar"
        Me.ButtonContinuar.Size = New System.Drawing.Size(72, 24)
        Me.ButtonContinuar.TabIndex = 17
        Me.ButtonContinuar.Text = "ButtonContinuar"
        '
        'TextBoxTotalIni
        '
        Me.TextBoxTotalIni.Enabled = False
        Me.TextBoxTotalIni.Location = New System.Drawing.Point(147, 104)
        Me.TextBoxTotalIni.Name = "TextBoxTotalIni"
        Me.TextBoxTotalIni.Size = New System.Drawing.Size(88, 21)
        Me.TextBoxTotalIni.TabIndex = 17
        '
        'ComboBoxTotal
        '
        Me.ComboBoxTotal.Enabled = False
        Me.ComboBoxTotal.Location = New System.Drawing.Point(77, 104)
        Me.ComboBoxTotal.Name = "ComboBoxTotal"
        Me.ComboBoxTotal.Size = New System.Drawing.Size(68, 22)
        Me.ComboBoxTotal.TabIndex = 16
        '
        'CheckBoxTotal
        '
        Me.CheckBoxTotal.Location = New System.Drawing.Point(2, 104)
        Me.CheckBoxTotal.Name = "CheckBoxTotal"
        Me.CheckBoxTotal.Size = New System.Drawing.Size(71, 20)
        Me.CheckBoxTotal.TabIndex = 20
        Me.CheckBoxTotal.Text = "CheckBoxTotal"
        '
        'ComboBoxConcepto
        '
        Me.ComboBoxConcepto.Enabled = False
        Me.ComboBoxConcepto.Location = New System.Drawing.Point(77, 74)
        Me.ComboBoxConcepto.Name = "ComboBoxConcepto"
        Me.ComboBoxConcepto.Size = New System.Drawing.Size(158, 22)
        Me.ComboBoxConcepto.TabIndex = 15
        '
        'CheckBoxConcepto
        '
        Me.CheckBoxConcepto.Location = New System.Drawing.Point(2, 74)
        Me.CheckBoxConcepto.Name = "CheckBoxConcepto"
        Me.CheckBoxConcepto.Size = New System.Drawing.Size(71, 20)
        Me.CheckBoxConcepto.TabIndex = 22
        Me.CheckBoxConcepto.Text = "CheckBoxConcepto"
        '
        'CheckBoxFecha
        '
        Me.CheckBoxFecha.Location = New System.Drawing.Point(2, 18)
        Me.CheckBoxFecha.Name = "CheckBoxFecha"
        Me.CheckBoxFecha.Size = New System.Drawing.Size(71, 20)
        Me.CheckBoxFecha.TabIndex = 23
        Me.CheckBoxFecha.Text = "CheckBoxFecha"
        '
        'FormGastosBusqueda
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(242, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Menu = Me.MainMenu1
        Me.Name = "FormGastosBusqueda"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Q, tmp As String
    Private oVista As Vista
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ComboBoxFecha As System.Windows.Forms.ComboBox
    Friend WithEvents TextBoxTotalFin As System.Windows.Forms.TextBox
    Friend WithEvents ButtonRegresar As System.Windows.Forms.Button
    Friend WithEvents ButtonContinuar As System.Windows.Forms.Button
    Friend WithEvents TextBoxTotalIni As System.Windows.Forms.TextBox
    Friend WithEvents ComboBoxTotal As System.Windows.Forms.ComboBox
    Friend WithEvents CheckBoxTotal As System.Windows.Forms.CheckBox
    Friend WithEvents ComboBoxConcepto As System.Windows.Forms.ComboBox
    Friend WithEvents CheckBoxConcepto As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxFecha As System.Windows.Forms.CheckBox
    Friend WithEvents MenuItemRegresar As System.Windows.Forms.MenuItem
    Friend WithEvents dtpFechaIni As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFechaFin As System.Windows.Forms.DateTimePicker
    Private Completado As Boolean = False

    Property Cadena() As String
        Get
            Return Q
        End Get
        Set(ByVal Value As String)
            Q = Value
        End Set
    End Property

    Private Sub FormGastosBusqueda_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor.Current = Cursors.WaitCursor
        [Global].ObtenerFactores(Me)
        [Global].EscalarFuente(Me)
        [Global].EscalarForma(Me)
        If Not Vista.Buscar("FormGastosBusqueda", oVista) Then
            Cursor.Current = Cursors.Default
            Exit Sub
        End If
        dtpFechaIni.Value = PrimeraHora(Today)
        dtpFechaFin.Value = PrimeraHora(Today)
        oVista.ColocarEtiquetasForma(Me)
        LlenaCombos()
        Completado = True
        Cursor.Current = Cursors.Default
        Me.CheckBoxFecha.Focus()
    End Sub

    Private Sub ButtonRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRegresar.Click
        Me.Close()
    End Sub

    Private Sub ButtonContinuar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonContinuar.Click
        If Not ValidaCampos() Then Exit Sub
        CreaCondiciones(tmp)
        If HayRegistros(tmp) Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Else
            MsgBox(oVista.BuscarMensaje("Mensajes", "E0034"), MsgBoxStyle.Information, "Amesol Route")
        End If
    End Sub

    Private Function HayRegistros(ByVal s As String) As Boolean
        Dim dt As DataTable = oDBVen.RealizarConsultaSQL(s, "reg")
        If dt.Rows.Count > 0 Then
            dt.Dispose()
            Return True
        End If
        dt.Dispose()
        Return False
    End Function

    Private Function ValidaCampos() As Boolean
        If CheckBoxTotal.Checked Then
            If TextBoxTotalIni.Text = "" OrElse Not IsNumeric(TextBoxTotalIni.Text) Then
                MsgBox(SustituyeCampo(oVista.BuscarMensaje("Mensajes", "BE0001"), CheckBoxTotal.Text), MsgBoxStyle.Information, "Amesol Route")
                TextBoxTotalIni.Focus()
                Return False
            ElseIf TextBoxTotalFin.Enabled AndAlso (TextBoxTotalFin.Text = "" OrElse Not IsNumeric(TextBoxTotalFin.Text)) Then
                MsgBox(SustituyeCampo(oVista.BuscarMensaje("Mensajes", "BE0001"), CheckBoxTotal.Text), MsgBoxStyle.Information, "Amesol Route")
                TextBoxTotalFin.Focus()
                Return False
            End If
        End If
        Return True
    End Function

    Private Sub CreaCondiciones(ByRef query As String)
        Q = ""
        query = "select * from gasto where vendedorid='" & oVendedor.VendedorId & "' and diaclave='" & oDia.DiaActual & "'"
        If CheckBoxFecha.Checked Then
            Dim tmp As String = dtpFechaIni.Value
            Dim tmp2 As String = dtpFechaFin.Value
            Q = " and fecha " & Operador(ComboBoxFecha.SelectedValue, tmp, tmp2, "Fecha")
            query &= " and fecha " & Operador(ComboBoxFecha.SelectedValue, tmp, tmp2, "Fecha")
        End If
        If CheckBoxConcepto.Checked Then
            Q &= " and tipoconcepto=" & ComboBoxConcepto.SelectedValue
            query &= " and tipoconcepto=" & ComboBoxConcepto.SelectedValue
        End If
        If CheckBoxTotal.Checked Then
            Q &= " and total" & Operador(ComboBoxTotal.SelectedValue, TextBoxTotalIni.Text, TextBoxTotalFin.Text, "Total")
            query &= " and total" & Operador(ComboBoxTotal.SelectedValue, TextBoxTotalIni.Text, TextBoxTotalFin.Text, "Total")
        End If
    End Sub

    Private Function Operador(ByVal Indice As Integer, ByVal ValorIni As Object, ByVal ValorFin As Object, ByVal Combo As String) As String
        Select Case Indice
            Case 1 'Igual
                If Combo = "Fecha" Then
                    Return " between " & UniFechaSQL(PrimeraHora(ValorIni)) & " AND " & UniFechaSQL(UltimaHora(ValorIni))
                Else
                    Return " = " & ValorIni
                End If
            Case 2 'Diferente
                If Combo = "Fecha" Then
                    Return " not between " & UniFechaSQL(PrimeraHora(ValorIni)) & " AND " & UniFechaSQL(UltimaHora(ValorIni))
                Else
                    Return " <> " & ValorIni
                End If
            Case 3 'Mayor que
                If Combo = "Fecha" Then
                    Return " > " & UniFechaSQL(UltimaHora(ValorIni))
                Else
                    Return " > " & ValorIni
                End If
            Case 4 'Menor que
                If Combo = "Fecha" Then
                    Return " < " & UniFechaSQL(PrimeraHora(ValorIni))
                Else
                    Return " < " & ValorIni
                End If
            Case 5 'Mayor igual que
                If Combo = "Fecha" Then
                    Return " >= " & UniFechaSQL(PrimeraHora(ValorIni))
                Else
                    Return " >= " & ValorIni
                End If
            Case 6 'Menor igual que
                If Combo = "Fecha" Then
                    Return " <= " & UniFechaSQL(UltimaHora(ValorIni))
                Else
                    Return " <= " & ValorIni
                End If
            Case 7 'Entre
                If Combo = "Fecha" Then
                    Return " between " & UniFechaSQL(PrimeraHora(ValorIni)) & " and " & UniFechaSQL(UltimaHora(ValorFin))
                Else
                    Return " between " & ValorIni & " and " & ValorFin
                End If
        End Select
        Return ""
    End Function

    Private Sub LlenaCombos()
        'ComboboxConcepto
        Dim arrCon As New ArrayList
        Dim aValores As ArrayList = ValorReferencia.RecuperarLista("GASTIPO")
        If Not IsNothing(aValores) AndAlso aValores.Count > 0 Then
            For Each refDesc As ValorReferencia.Descripcion In aValores
                arrCon.Add(New CConceptos(refDesc.Id, refDesc.Cadena))
            Next
            'For Each dr As DataRow In ValorReferencia.RecuperarLista("GASTIPO").Rows
            '    arrCon.Add(New CConceptos(dr(0), dr(1)))
            'Next
            ComboBoxConcepto.DataSource = arrCon
            ComboBoxConcepto.DisplayMember = "Concepto"
            ComboBoxConcepto.ValueMember = "Valor"
            ComboBoxConcepto.SelectedIndex = 0
        End If
        'Comboboxes Fecha y Total
        Dim arrNum As New ArrayList
        Dim arrNum2 As New ArrayList
        aValores = ValorReferencia.RecuperarLista("BFNUMERI")
        If Not IsNothing(aValores) AndAlso aValores.Count > 0 Then
            For Each refDesc As ValorReferencia.Descripcion In aValores
                arrNum.Add(New Numericos(refDesc.Id, refDesc.Cadena))
                arrNum2.Add(New Numericos(refDesc.Id, refDesc.Cadena))
            Next
            'For Each dr As DataRow In ValorReferencia.RecuperarLista("BFNUMERI").Rows
            '    arrNum.Add(New Numericos(dr(0), dr(1)))
            '    arrNum2.Add(New Numericos(dr(0), dr(1)))
            'Next
            ComboBoxFecha.DataSource = arrNum
            ComboBoxTotal.DataSource = arrNum2
            ComboBoxFecha.DisplayMember = "Descripcion"
            ComboBoxTotal.DisplayMember = "Descripcion"
            ComboBoxFecha.ValueMember = "Valor"
            ComboBoxTotal.ValueMember = "Valor"
            ComboBoxFecha.SelectedIndex = 0
            ComboBoxTotal.SelectedIndex = 0
        End If
        aValores = Nothing
    End Sub

    Private Sub ComboBoxFecha_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxFecha.SelectedIndexChanged
        If Completado Then
            Select Case ComboBoxFecha.SelectedValue
                Case 1, 2, 3, 4, 5, 6
                    dtpFechaFin.Enabled = False
                Case 7
                    dtpFechaFin.Enabled = True
            End Select
        End If
    End Sub

    Private Sub ComboBoxTotal_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxTotal.SelectedIndexChanged
        If Completado Then
            Select Case ComboBoxTotal.SelectedValue
                Case 1, 2, 3, 4, 5, 6
                    TextBoxTotalFin.Enabled = False
                Case 7
                    TextBoxTotalFin.Enabled = True
            End Select
        End If
    End Sub

    Private Sub CheckBoxFecha_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxFecha.CheckStateChanged
        If CheckBoxFecha.Checked Then
            ComboBoxFecha.Enabled = True
            dtpFechaIni.Enabled = True
            If ComboBoxFecha.SelectedValue = 7 Then
                dtpFechaFin.Enabled = True
            Else
                dtpFechaFin.Enabled = False
            End If
        Else
            ComboBoxFecha.Enabled = False
            dtpFechaIni.Enabled = False
            dtpFechaFin.Enabled = False
        End If
    End Sub

    Private Sub CheckBoxConcepto_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxConcepto.CheckStateChanged
        If CheckBoxConcepto.Checked Then
            ComboBoxConcepto.Enabled = True
        Else
            ComboBoxConcepto.Enabled = False
        End If
    End Sub

    Private Sub CheckBoxTotal_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxTotal.CheckStateChanged
        If CheckBoxTotal.Checked Then
            ComboBoxTotal.Enabled = True
            TextBoxTotalIni.Enabled = True
            If ComboBoxTotal.SelectedValue = 7 Then
                TextBoxTotalFin.Enabled = True
            Else
                TextBoxTotalFin.Enabled = False
            End If
        Else
            ComboBoxTotal.Enabled = False
            TextBoxTotalIni.Enabled = False
            TextBoxTotalFin.Enabled = False
        End If
    End Sub

    Private Sub MenuItemRegresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuItemRegresar.Click
        ButtonRegresar_Click(Nothing, Nothing)
    End Sub
End Class

Public Class Numericos
    Private Des As String
    Private Val As String

    Public Sub New(ByVal v As String, ByVal d As String)
        MyBase.New()
        Me.Val = v
        Me.Des = d
    End Sub

    Public ReadOnly Property Descripcion() As String
        Get
            Return Des
        End Get
    End Property

    Public ReadOnly Property Valor() As String
        Get
            Return Val
        End Get
    End Property
End Class