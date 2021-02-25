Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmCancelacion
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GrpPagos As System.Windows.Forms.GroupBox
    Friend WithEvents GridPagos As Janus.Windows.GridEX.GridEX
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents CmbPeriodo As Selling.StoreCombo
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents TxtFolio As System.Windows.Forms.TextBox
    Friend WithEvents BtnSalir As Janus.Windows.EditControls.UIButton
    Friend WithEvents Clock As System.Windows.Forms.Timer
    Friend WithEvents ChkMarcaTodos As System.Windows.Forms.CheckBox
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents GrpCompras As System.Windows.Forms.GroupBox
    Friend WithEvents GrdCompras As Janus.Windows.GridEX.GridEX
    Friend WithEvents CmbMes As Selling.StoreCombo
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCancelacion))
        Me.GrpPagos = New System.Windows.Forms.GroupBox()
        Me.ChkMarcaTodos = New System.Windows.Forms.CheckBox()
        Me.GridPagos = New Janus.Windows.GridEX.GridEX()
        Me.TxtFolio = New System.Windows.Forms.TextBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.CmbMes = New Selling.StoreCombo()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.CmbPeriodo = New Selling.StoreCombo()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Clock = New System.Windows.Forms.Timer(Me.components)
        Me.BtnSalir = New Janus.Windows.EditControls.UIButton()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.GrpCompras = New System.Windows.Forms.GroupBox()
        Me.GrdCompras = New Janus.Windows.GridEX.GridEX()
        Me.GrpPagos.SuspendLayout()
        CType(Me.GridPagos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpCompras.SuspendLayout()
        CType(Me.GrdCompras, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpPagos
        '
        Me.GrpPagos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GrpPagos.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpPagos.Controls.Add(Me.ChkMarcaTodos)
        Me.GrpPagos.Controls.Add(Me.GridPagos)
        Me.GrpPagos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpPagos.ForeColor = System.Drawing.Color.Black
        Me.GrpPagos.Location = New System.Drawing.Point(7, 39)
        Me.GrpPagos.Name = "GrpPagos"
        Me.GrpPagos.Size = New System.Drawing.Size(481, 470)
        Me.GrpPagos.TabIndex = 0
        Me.GrpPagos.TabStop = False
        Me.GrpPagos.Text = "Pagos"
        '
        'ChkMarcaTodos
        '
        Me.ChkMarcaTodos.Enabled = False
        Me.ChkMarcaTodos.Location = New System.Drawing.Point(7, 23)
        Me.ChkMarcaTodos.Name = "ChkMarcaTodos"
        Me.ChkMarcaTodos.Size = New System.Drawing.Size(159, 20)
        Me.ChkMarcaTodos.TabIndex = 49
        Me.ChkMarcaTodos.Text = "Seleccionar Todos"
        '
        'GridPagos
        '
        Me.GridPagos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GridPagos.ColumnAutoResize = True
        Me.GridPagos.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridPagos.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridPagos.GroupByBoxVisible = False
        Me.GridPagos.Location = New System.Drawing.Point(7, 44)
        Me.GridPagos.Name = "GridPagos"
        Me.GridPagos.RecordNavigator = True
        Me.GridPagos.Size = New System.Drawing.Size(468, 421)
        Me.GridPagos.TabIndex = 4
        Me.GridPagos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'TxtFolio
        '
        Me.TxtFolio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFolio.Location = New System.Drawing.Point(131, 12)
        Me.TxtFolio.Name = "TxtFolio"
        Me.TxtFolio.Size = New System.Drawing.Size(123, 21)
        Me.TxtFolio.TabIndex = 0
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(777, 16)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox2.TabIndex = 41
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'CmbMes
        '
        Me.CmbMes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbMes.BackColor = System.Drawing.SystemColors.Window
        Me.CmbMes.Location = New System.Drawing.Point(818, 11)
        Me.CmbMes.Name = "CmbMes"
        Me.CmbMes.Size = New System.Drawing.Size(134, 21)
        Me.CmbMes.TabIndex = 3
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(259, 15)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox1.TabIndex = 39
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'CmbPeriodo
        '
        Me.CmbPeriodo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbPeriodo.BackColor = System.Drawing.SystemColors.Window
        Me.CmbPeriodo.Location = New System.Drawing.Point(674, 11)
        Me.CmbPeriodo.Name = "CmbPeriodo"
        Me.CmbPeriodo.Size = New System.Drawing.Size(100, 21)
        Me.CmbPeriodo.TabIndex = 2
        '
        'PictureBox3
        '
        Me.PictureBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(956, 15)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox3.TabIndex = 37
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(792, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(26, 15)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Mes"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(626, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 15)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Periodo"
        '
        'Label1
        '
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(11, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(115, 19)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Folio Factura o Cargo"
        '
        'Clock
        '
        Me.Clock.Interval = 1000
        '
        'BtnSalir
        '
        Me.BtnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSalir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSalir.Image = CType(resources.GetObject("BtnSalir.Image"), System.Drawing.Image)
        Me.BtnSalir.Location = New System.Drawing.Point(779, 516)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(90, 37)
        Me.BtnSalir.TabIndex = 7
        Me.BtnSalir.Text = "ESC- Salir"
        Me.BtnSalir.ToolTipText = "Salir"
        Me.BtnSalir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(876, 517)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 6
        Me.BtnCancelar.Text = "F6- Cancelar"
        Me.BtnCancelar.ToolTipText = "Cancela el pago y sus aplicaciones"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GrpCompras
        '
        Me.GrpCompras.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpCompras.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpCompras.Controls.Add(Me.GrdCompras)
        Me.GrpCompras.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpCompras.ForeColor = System.Drawing.Color.Black
        Me.GrpCompras.Location = New System.Drawing.Point(494, 39)
        Me.GrpCompras.Name = "GrpCompras"
        Me.GrpCompras.Size = New System.Drawing.Size(472, 470)
        Me.GrpCompras.TabIndex = 47
        Me.GrpCompras.TabStop = False
        Me.GrpCompras.Text = "Aplicados a"
        '
        'GrdCompras
        '
        Me.GrdCompras.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrdCompras.ColumnAutoResize = True
        Me.GrdCompras.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GrdCompras.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GrdCompras.GroupByBoxVisible = False
        Me.GrdCompras.Location = New System.Drawing.Point(7, 44)
        Me.GrdCompras.Name = "GrdCompras"
        Me.GrdCompras.RecordNavigator = True
        Me.GrdCompras.Size = New System.Drawing.Size(461, 421)
        Me.GrdCompras.TabIndex = 4
        Me.GrdCompras.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'FrmCancelacion
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(976, 561)
        Me.Controls.Add(Me.GrpCompras)
        Me.Controls.Add(Me.CmbMes)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtFolio)
        Me.Controls.Add(Me.BtnSalir)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.CmbPeriodo)
        Me.Controls.Add(Me.GrpPagos)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(667, 464)
        Me.Name = "FrmCancelacion"
        Me.Text = "Cancelación de Pagos"
        Me.GrpPagos.ResumeLayout(False)
        CType(Me.GridPagos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpCompras.ResumeLayout(False)
        CType(Me.GrdCompras, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    ' Public SUCClave As String

    Private alerta(2) As PictureBox
    Private reloj As parpadea
    Private dtPagos As DataTable
    Private sPagoSelected As String
    Private bPagoLoad As Boolean = False
    Private bComboLoad As Boolean = False
    

    Private Sub FrmCancelacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Me.StartPosition = FormStartPosition.CenterScreen

      

        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2
        alerta(2) = Me.PictureBox3


        With Me.CmbPeriodo
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_periodo"
            .llenar()
        End With

        With Me.CmbMes
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Folio"
            .NombreParametro2 = "campo"
            .Parametro2 = "Mes"
            .llenar()
        End With


        CmbPeriodo.SelectedValue = DateTime.Today.Year()
        CmbMes.SelectedValue = DateTime.Today.Month()

        bComboLoad = True

        AgregarFolio(False, True)

    End Sub

    Private Function validaForm(ByVal Tipo As Boolean) As Boolean
        Dim i As Integer = 0

        If Tipo Then
            If TxtFolio.Text = "" Then
                i += 1
                reloj = New parpadea(Me.alerta(0))
                reloj.Enabled = True
                reloj.Start()
            End If
        End If

        If Me.CmbPeriodo.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        End If


        If Me.CmbMes.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(2))
            reloj.Enabled = True
            reloj.Start()
        End If

      

        If i > 0 Then
            Return False
        Else
            While i < Me.alerta.Length
                Me.alerta(i).Visible = False
                i += 1
            End While
            Return True
        End If

    End Function

    Private Sub AgregarFolio(ByVal Folio As Boolean, ByVal FirsTime As Boolean)
        If validaForm(Folio) Then



            bPagoLoad = False
            If Not dtPagos Is Nothing Then
                dtPagos.Dispose()
            End If

            If Folio Then
                dtPagos = ModPOS.Recupera_Tabla("sp_busca_pagos", "@COMClave", ModPOS.CompanyActual, "@Folio", TxtFolio.Text.ToUpper.Trim.Replace("'", "''"))
            Else
                dtPagos = ModPOS.Recupera_Tabla("sp_recupera_pagos", "@COMClave", ModPOS.CompanyActual, "@Periodo", CmbPeriodo.SelectedValue, "@Mes", CmbMes.SelectedValue)
            End If
            GridPagos.DataSource = dtPagos
            GridPagos.RetrieveStructure()
            GridPagos.AutoSizeColumns()
            GridPagos.RootTable.Columns("ID").Visible = False
            GridPagos.CurrentTable.Columns(2).Selectable = False
            GridPagos.CurrentTable.Columns(3).Selectable = False
            GridPagos.CurrentTable.Columns(4).Selectable = False
            GridPagos.CurrentTable.Columns(5).Selectable = False
            GridPagos.CurrentTable.Columns(6).Selectable = False


            bPagoLoad = True

            If dtPagos.Rows.Count = 0 Then
                If Not FirsTime Then
                    MessageBox.Show("No se encontro un pago de " & CmbMes.Text & " de " & CStr(CmbPeriodo.SelectedValue), "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                sPagoSelected = ""
            Else
                sPagoSelected = Me.GridPagos.GetValue(0)
            End If

            ModPOS.ActualizaGrid(False, Me.GrdCompras, "sp_muestra_pagcom", "@PAGClave", sPagoSelected)

            ChkMarcaTodos.Enabled = True
        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub TxtFolio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFolio.KeyPress
        If Asc(e.KeyChar) = 13 Then
            AgregarFolio(True, False)
        End If
    End Sub

    Private Sub Combo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbPeriodo.SelectedIndexChanged, CmbMes.SelectedIndexChanged
        If bComboLoad = True AndAlso Not dtPagos Is Nothing Then
            dtPagos.Dispose()
            ChkMarcaTodos.Enabled = False
            AgregarFolio(False, False)
        End If
    End Sub

    Private Sub ChkMarcaTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkMarcaTodos.CheckedChanged
        If dtPagos.Rows.Count > 0 Then
            Dim i As Integer

            If ChkMarcaTodos.Checked Then
                For i = 0 To GridPagos.GetDataRows.Length - 1
                    GridPagos.GetDataRows(i).DataRow("Marca") = True
                Next
            Else
                For i = 0 To GridPagos.GetDataRows.Length - 1
                    GridPagos.GetDataRows(i).DataRow("Marca") = False
                Next
            End If

            
        End If
    End Sub

    Private Sub BtnCancelaTicket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        If Not dtPagos Is Nothing Then
            Dim i As Integer

            Dim foundRows() As DataRow

            foundRows = dtPagos.Select("Marca ='True'")



            If foundRows.GetLength(0) > 0 Then

                For i = 0 To foundRows.GetUpperBound(0)

                    Select Case MessageBox.Show("¿Esta seguro de Cancelar el Pago en " & foundRows(i)(4) & " de " & Format(CStr(foundRows(i)(3)), "Currency") & " ?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        Case DialogResult.Yes
                            ModPOS.Ejecuta("sp_cancela_pago", "@PAGO", foundRows(i)(0))
                    End Select

                Next
                AgregarFolio(False, False)
            Else
                MessageBox.Show("Debe marcar por lo menos un registro", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If

    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub GridPagos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridPagos.DoubleClick
        If bPagoLoad = True AndAlso Not Me.GridPagos.GetValue(0) Is Nothing Then
            sPagoSelected = Me.GridPagos.GetValue(0)
            ModPOS.ActualizaGrid(False, Me.GrdCompras, "sp_muestra_pagcom", "@PAGClave", sPagoSelected)
        Else
            sPagoSelected = ""
        End If

    End Sub


    Private Sub Controls_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp, BtnSalir.KeyUp, ChkMarcaTodos.KeyUp, CmbMes.KeyUp, CmbPeriodo.KeyUp, GridPagos.KeyUp, TxtFolio.KeyUp, BtnCancelar.KeyUp
        Select Case e.KeyCode
            Case Is = Keys.Escape
                BtnSalir.PerformClick()
            Case Is = Keys.F6
                Me.BtnCancelar.PerformClick()
        End Select
    End Sub

    Private Sub GridPagos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridPagos.SelectionChanged
        If bPagoLoad = True AndAlso Not Me.GridPagos.GetValue(0) Is Nothing Then
            sPagoSelected = Me.GridPagos.GetValue(0)
            ModPOS.ActualizaGrid(False, Me.GrdCompras, "sp_muestra_pagcom", "@PAGClave", sPagoSelected)
        Else
            sPagoSelected = ""
        End If
    End Sub


End Class
