Public Class FrmConsultaNegados
    Inherits System.Windows.Forms.Form

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
    Friend WithEvents BtnAgregar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnCerrar As Janus.Windows.EditControls.UIButton
    Friend WithEvents dtPickerInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtPickerFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents LblFechaHora As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents GridNegados As Janus.Windows.GridEX.GridEX
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmConsultaNegados))
        Me.GridNegados = New Janus.Windows.GridEX.GridEX()
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton()
        Me.btnCerrar = New Janus.Windows.EditControls.UIButton()
        Me.dtPickerInicio = New System.Windows.Forms.DateTimePicker()
        Me.dtPickerFin = New System.Windows.Forms.DateTimePicker()
        Me.LblFechaHora = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.GridNegados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridNegados
        '
        Me.GridNegados.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridNegados.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridNegados.ColumnAutoResize = True
        Me.GridNegados.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridNegados.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridNegados.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridNegados.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown
        Me.GridNegados.Location = New System.Drawing.Point(0, 100)
        Me.GridNegados.Name = "GridNegados"
        Me.GridNegados.RecordNavigator = True
        Me.GridNegados.Size = New System.Drawing.Size(782, 459)
        Me.GridNegados.TabIndex = 3
        Me.GridNegados.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAgregar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.BtnAgregar.Icon = CType(resources.GetObject("BtnAgregar.Icon"), System.Drawing.Icon)
        Me.BtnAgregar.ImageSize = New System.Drawing.Size(35, 35)
        Me.BtnAgregar.Location = New System.Drawing.Point(628, 12)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Blue
        Me.BtnAgregar.Size = New System.Drawing.Size(154, 82)
        Me.BtnAgregar.TabIndex = 95
        Me.BtnAgregar.Text = "Agregar "
        Me.BtnAgregar.ToolTipText = "Agrega los registros marcados al pedido actual"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnCerrar
        '
        Me.btnCerrar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnCerrar.Icon = CType(resources.GetObject("btnCerrar.Icon"), System.Drawing.Icon)
        Me.btnCerrar.ImageSize = New System.Drawing.Size(18, 18)
        Me.btnCerrar.Location = New System.Drawing.Point(0, 12)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Blue
        Me.btnCerrar.Size = New System.Drawing.Size(134, 82)
        Me.btnCerrar.TabIndex = 96
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.ToolTipText = "Cierra la pantalla actual"
        Me.btnCerrar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'dtPickerInicio
        '
        Me.dtPickerInicio.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtPickerInicio.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtPickerInicio.CustomFormat = "dd MMMM yyyy"
        Me.dtPickerInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtPickerInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtPickerInicio.Location = New System.Drawing.Point(211, 12)
        Me.dtPickerInicio.Name = "dtPickerInicio"
        Me.dtPickerInicio.ShowUpDown = True
        Me.dtPickerInicio.Size = New System.Drawing.Size(411, 38)
        Me.dtPickerInicio.TabIndex = 97
        Me.dtPickerInicio.Value = New Date(2015, 1, 27, 0, 0, 0, 0)
        '
        'dtPickerFin
        '
        Me.dtPickerFin.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtPickerFin.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtPickerFin.CustomFormat = "dd MMMM yyyy"
        Me.dtPickerFin.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtPickerFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtPickerFin.Location = New System.Drawing.Point(211, 56)
        Me.dtPickerFin.Name = "dtPickerFin"
        Me.dtPickerFin.ShowUpDown = True
        Me.dtPickerFin.Size = New System.Drawing.Size(411, 38)
        Me.dtPickerFin.TabIndex = 98
        Me.dtPickerFin.Value = New Date(2015, 1, 27, 0, 0, 0, 0)
        '
        'LblFechaHora
        '
        Me.LblFechaHora.BackColor = System.Drawing.Color.Transparent
        Me.LblFechaHora.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!)
        Me.LblFechaHora.ForeColor = System.Drawing.Color.Black
        Me.LblFechaHora.Location = New System.Drawing.Point(140, 12)
        Me.LblFechaHora.Name = "LblFechaHora"
        Me.LblFechaHora.Size = New System.Drawing.Size(65, 36)
        Me.LblFechaHora.TabIndex = 99
        Me.LblFechaHora.Text = "Del"
        Me.LblFechaHora.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(140, 58)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 36)
        Me.Label1.TabIndex = 100
        Me.Label1.Text = "Al"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FrmConsultaNegados
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LblFechaHora)
        Me.Controls.Add(Me.dtPickerFin)
        Me.Controls.Add(Me.dtPickerInicio)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.BtnAgregar)
        Me.Controls.Add(Me.GridNegados)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(367, 386)
        Me.Name = "FrmConsultaNegados"
        Me.Text = "Consulta de Negados"
        CType(Me.GridNegados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region
    Public Padre As String = ""
    Public TipoVenta As Integer
    Public VentaCerrada As Boolean = True
    Public numMostrador As Integer
    Public ALMClave As String
    Public TallaColor As Integer = 1
    Public TouchCK As Boolean = False
    Public CTEClave As String
    Private dtNegados As DataTable
    Private bError As Boolean = False
    Private FechaIni As DateTime
    Private FechaFin As DateTime

    '  Private Periodo, Mes As Integer
    Private bload As Boolean = False

    Private Sub RefreshGrid()

        FechaIni = dtPickerInicio.Value
        FechaFin = dtPickerFin.Value.AddHours(23.9999)

        dtNegados = ModPOS.Recupera_Tabla("st_obtener_modelonegado", "@Inicio", FechaIni, "@Fin", FechaFin, "@ALMClave", ALMClave, "@CTEClave", CTEClave, "@TallaColor", TallaColor)

        GridNegados.DataSource = dtNegados
        GridNegados.RetrieveStructure(True)
        GridNegados.GroupByBoxVisible = False
        GridNegados.AutoSizeColumns()
        GridNegados.RootTable.Columns("Clave").Visible = False

        Dim fc As Janus.Windows.GridEX.GridEXFormatCondition
        fc = New Janus.Windows.GridEX.GridEXFormatCondition(GridNegados.RootTable.Columns("ESTATUS"), Janus.Windows.GridEX.ConditionOperator.Equal, "DISPONIBLE")
        fc.FormatStyle.ForeColor = System.Drawing.Color.Red
        GridNegados.RootTable.FormatConditions.Add(fc)


    End Sub


    Private Sub FrmConsultaNegados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If TouchCK Then
            Me.GridNegados.Font = New Font("Microsoft Sans Serif", 15)
            'Me.WindowState = FormWindowState.Maximized
        End If

        dtPickerInicio.Value = Today
        dtPickerFin.Value = Today

        If dtPickerInicio.Value.Day > 28 Then
            Dim Dias As Integer = dtPickerInicio.Value.Day
            dtPickerInicio.Value = dtPickerInicio.Value.AddDays(28 - Dias)
        End If

      
        bload = True
        refreshGrid()



    End Sub


    Private Sub FrmConsultaNegados_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If bError Then
            e.Cancel = True

        End If
    End Sub

    Private Sub BtnAgregar_Click(sender As Object, e As EventArgs) Handles BtnAgregar.Click

        Dim foundRows() As DataRow

        foundRows = dtNegados.Select("Marca ='True' ")
        If foundRows.GetLength(0) > 0 Then
            If VentaCerrada Then
                MessageBox.Show("El pedido actual se encuentra cerrado, cree un nuevo pedido para agregar el producto", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                Dim i As Integer
                Dim sClave As String
                Dim dCant As Double
                For i = 0 To foundRows.GetUpperBound(0)

                    sClave = foundRows(i)("Clave")
                    dCant = foundRows(i)("Cantidad")


                    If Padre = "Venta" Then
                        If TipoVenta = 1 Then
                            bError = ModPOS.Mostradores(numMostrador).AgregaGTIN(sClave, True, True, True, dCant, FechaIni, FechaFin)
                        End If
                    ElseIf Padre = "Preventa" Then
                        bError = ModPOS.PreVenta.AgregaGTIN(sClave, True, True, True, dCant, FechaIni, FechaFin)
                    Else
                        bError = ModPOS.TouchCK.AgregaGTIN(True, sClave, True, True, dCant, FechaIni, FechaFin)
                    End If

                Next
            End If
            Me.Close()
        Else
            MessageBox.Show("Debe seleccionar un registro para agregar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            bError = True
        End If

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        bError = False
        Me.Close()
    End Sub

    Private Sub dtPicker_ValueChanged(sender As Object, e As EventArgs) Handles dtPickerInicio.ValueChanged
        If bload = True AndAlso (FechaIni <> dtPickerInicio.Value) Then

            If dtPickerInicio.Value > dtPickerFin.Value Then
                dtPickerFin.Value = dtPickerInicio.Value
            End If

            If Not dtNegados Is Nothing Then
                dtNegados.Dispose()

            End If
            RefreshGrid()
        End If
    End Sub

   
    Private Sub GridNegados_CurrentCellChanged(sender As Object, e As EventArgs) Handles GridNegados.CurrentCellChanged
        If Not GridNegados.CurrentColumn Is Nothing Then
            If GridNegados.CurrentColumn.Caption = "Marca" Then
                GridNegados.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
            Else
                GridNegados.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
            End If
        End If
    End Sub

    Private Sub dtPickerFin_ValueChanged(sender As Object, e As EventArgs) Handles dtPickerFin.ValueChanged
        If bload = True AndAlso (FechaFin <> dtPickerFin.Value) Then

            If dtPickerFin.Value < dtPickerInicio.Value Then
                dtPickerInicio.Value = dtPickerFin.Value
            End If

            If Not dtNegados Is Nothing Then
                dtNegados.Dispose()

            End If
            RefreshGrid()
        End If
    End Sub
End Class
