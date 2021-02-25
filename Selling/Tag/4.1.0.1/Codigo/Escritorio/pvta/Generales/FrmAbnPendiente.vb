Public Class FrmAbnPendiente
    Inherits System.Windows.Forms.Form


    Public SaldoDocumento As Double = 0
    Public drAbonos() As DataRow
    ' Public CAJClave As String


    Private dSaldo As Double
    Private bError As Boolean = False
    Private bEjecutaConsulta As Boolean = True


    ' Public ABNClave As String
    'Public Saldo As Double
    'Public TPago As Double


    Friend WithEvents ChkMarcaTodos As System.Windows.Forms.CheckBox
    Friend WithEvents LblSaldo As System.Windows.Forms.Label
    Friend WithEvents LblTotal As System.Windows.Forms.Label
    Friend WithEvents LblPagar As System.Windows.Forms.Label
    Private dtAbonos As DataTable

   


    Public WriteOnly Property Abonos() As DataTable
        Set(ByVal Value As DataTable)
            dtAbonos = Value
        End Set
    End Property

    Public WriteOnly Property EjecutaConsulta() As Boolean
        Set(ByVal Value As Boolean)
            bEjecutaConsulta = Value
        End Set
    End Property



#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'UserControl overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnOK As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnCancel As Janus.Windows.EditControls.UIButton
    Friend WithEvents GridAbonos As Janus.Windows.GridEX.GridEX
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAbnPendiente))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.LblPagar = New System.Windows.Forms.Label
        Me.LblTotal = New System.Windows.Forms.Label
        Me.LblSaldo = New System.Windows.Forms.Label
        Me.ChkMarcaTodos = New System.Windows.Forms.CheckBox
        Me.GridAbonos = New Janus.Windows.GridEX.GridEX
        Me.BtnOK = New Janus.Windows.EditControls.UIButton
        Me.BtnCancel = New Janus.Windows.EditControls.UIButton
        Me.GroupBox1.SuspendLayout()
        CType(Me.GridAbonos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.LblPagar)
        Me.GroupBox1.Controls.Add(Me.LblTotal)
        Me.GroupBox1.Controls.Add(Me.LblSaldo)
        Me.GroupBox1.Controls.Add(Me.ChkMarcaTodos)
        Me.GroupBox1.Controls.Add(Me.GridAbonos)
        Me.GroupBox1.Location = New System.Drawing.Point(2, -3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(499, 292)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'LblPagar
        '
        Me.LblPagar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblPagar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPagar.ForeColor = System.Drawing.Color.MidnightBlue
        Me.LblPagar.Location = New System.Drawing.Point(279, 10)
        Me.LblPagar.Name = "LblPagar"
        Me.LblPagar.Size = New System.Drawing.Size(213, 19)
        Me.LblPagar.TabIndex = 54
        Me.LblPagar.Text = "TOTAL "
        Me.LblPagar.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LblTotal
        '
        Me.LblTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotal.ForeColor = System.Drawing.Color.MidnightBlue
        Me.LblTotal.Location = New System.Drawing.Point(282, 268)
        Me.LblTotal.Name = "LblTotal"
        Me.LblTotal.Size = New System.Drawing.Size(54, 19)
        Me.LblTotal.TabIndex = 52
        Me.LblTotal.Text = "TOTAL "
        '
        'LblSaldo
        '
        Me.LblSaldo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblSaldo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblSaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSaldo.ForeColor = System.Drawing.Color.MidnightBlue
        Me.LblSaldo.Location = New System.Drawing.Point(341, 266)
        Me.LblSaldo.Name = "LblSaldo"
        Me.LblSaldo.Size = New System.Drawing.Size(154, 19)
        Me.LblSaldo.TabIndex = 51
        Me.LblSaldo.Text = "0.00"
        Me.LblSaldo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ChkMarcaTodos
        '
        Me.ChkMarcaTodos.Location = New System.Drawing.Point(3, 10)
        Me.ChkMarcaTodos.Name = "ChkMarcaTodos"
        Me.ChkMarcaTodos.Size = New System.Drawing.Size(124, 20)
        Me.ChkMarcaTodos.TabIndex = 50
        Me.ChkMarcaTodos.Text = "Seleccionar Todos"
        '
        'GridAbonos
        '
        Me.GridAbonos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridAbonos.ColumnAutoResize = True
        Me.GridAbonos.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridAbonos.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridAbonos.GroupByBoxVisible = False
        Me.GridAbonos.Location = New System.Drawing.Point(3, 32)
        Me.GridAbonos.Name = "GridAbonos"
        Me.GridAbonos.RecordNavigator = True
        Me.GridAbonos.Size = New System.Drawing.Size(493, 231)
        Me.GridAbonos.TabIndex = 2
        Me.GridAbonos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnOK
        '
        Me.BtnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BtnOK.Icon = CType(resources.GetObject("BtnOK.Icon"), System.Drawing.Icon)
        Me.BtnOK.Location = New System.Drawing.Point(315, 294)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(90, 30)
        Me.BtnOK.TabIndex = 3
        Me.BtnOK.Text = "Aplicar"
        Me.BtnOK.ToolTipText = "Aplicar abono seleccionado"
        Me.BtnOK.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCancel
        '
        Me.BtnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Icon = CType(resources.GetObject("BtnCancel.Icon"), System.Drawing.Icon)
        Me.BtnCancel.Location = New System.Drawing.Point(410, 294)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(90, 30)
        Me.BtnCancel.TabIndex = 4
        Me.BtnCancel.Text = "&Ignorar"
        Me.BtnCancel.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancel.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmAbnPendiente
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(504, 326)
        Me.Controls.Add(Me.BtnOK)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(180, 126)
        Me.Name = "FrmAbnPendiente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Abono pendiente de aplicar"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.GridAbonos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        bError = False
        Me.Close()
    End Sub

    Private Sub BtnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOK.Click

        If Not GridAbonos.DataSource Is Nothing Then

            Dim foundRows() As DataRow

            foundRows = dtAbonos.Select("Marca ='True'", "Saldo ASC")

            If foundRows.GetLength(0) > 0 Then

                drAbonos = foundRows
                bError = False
                
            Else
                MessageBox.Show("Debe marcar por lo menos un registro", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                bError = True
            End If
            Me.Close()
        Else
            Beep()
            MessageBox.Show("¡No ha seleccionado algun registro!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub


    Private Sub MeSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Me.StartPosition = FormStartPosition.CenterScreen

        If Not dtAbonos Is Nothing Then
            dtAbonos.Dispose()
        End If

       

        GridAbonos.DataSource = dtAbonos
        GridAbonos.RetrieveStructure()
        GridAbonos.AutoSizeColumns()
        Me.GridAbonos.RootTable.Columns("ID").Visible = False
        Me.GridAbonos.RootTable.Columns("TipoPago").Visible = False
        GridAbonos.CurrentTable.Columns("Tipo").Visible = False
        GridAbonos.CurrentTable.Columns("Folio").Selectable = False
        GridAbonos.CurrentTable.Columns("Fecha").Selectable = False
        GridAbonos.CurrentTable.Columns("Descripción").Selectable = False
        GridAbonos.CurrentTable.Columns("Importe").Selectable = False
        GridAbonos.CurrentTable.Columns("Saldo").Selectable = False

        LblPagar.Text = "Total a Pagar: " & Format(CStr(ModPOS.TruncateToDecimal(SaldoDocumento, 2)), "Currency")
    End Sub

    Private Sub GridAbonos_CellValueChanged(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridAbonos.CellValueChanged

        dtAbonos.AcceptChanges()
        GridAbonos.Refresh()

        If GridAbonos.GetValue("Marca") = True Then
            dSaldo += CDbl(GridAbonos.GetValue("Saldo"))
        Else
            dSaldo -= CDbl(GridAbonos.GetValue("Saldo"))
        End If
        Me.LblSaldo.Text = Format(CStr(ModPOS.TruncateToDecimal(dSaldo, 2)), "Currency")

      

    End Sub



    Private Sub GridAbonos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridAbonos.SelectionChanged
        If Not GridAbonos Is Nothing Then
            If Not GridAbonos.GetValue(0) Is Nothing Then
                Me.BtnOK.Enabled = True
            Else
                Me.BtnOK.Enabled = False
            End If
        End If
    End Sub

    Private Sub ChkMarcaTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkMarcaTodos.CheckedChanged
        If dtAbonos.Rows.Count > 0 Then
            Dim i As Integer
            If ChkMarcaTodos.Checked Then
                dSaldo = 0
                For i = 0 To GridAbonos.GetDataRows.Length - 1
                    GridAbonos.GetDataRows(i).DataRow("Marca") = True
                Next
            Else
                For i = 0 To GridAbonos.GetDataRows.Length - 1
                    GridAbonos.GetDataRows(i).DataRow("Marca") = False
                Next
            End If

            dtAbonos.AcceptChanges()
            GridAbonos.Refresh()

            dSaldo = IIf(dtAbonos.Compute("Sum(Saldo)", "Marca = True") Is System.DBNull.Value, 0, dtAbonos.Compute("Sum(Saldo)", "Marca = True"))
            Me.LblSaldo.Text = Format(CStr(ModPOS.TruncateToDecimal(dSaldo, 2)), "Currency")
        End If
    End Sub
    Private Sub FrmAbnPendiente_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        If bError Then
            e.Cancel = True
        End If
    End Sub

End Class
