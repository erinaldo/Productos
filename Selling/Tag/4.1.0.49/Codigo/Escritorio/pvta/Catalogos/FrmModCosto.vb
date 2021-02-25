Public Class FrmModCosto
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
    Friend WithEvents GrpCosto As System.Windows.Forms.GroupBox
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents ChkIncluyeIVA As System.Windows.Forms.CheckBox
    Friend WithEvents cmbTipoImpuesto As Selling.StoreCombo
    Friend WithEvents TxtCost As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents GrpImpuestos As System.Windows.Forms.GroupBox
    Friend WithEvents ChkMarcaTodos As System.Windows.Forms.CheckBox
    Friend WithEvents GridImpuestos As Janus.Windows.GridEX.GridEX
    Friend WithEvents BtnAgregar As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmModCosto))
        Me.GrpCosto = New System.Windows.Forms.GroupBox
        Me.GrpImpuestos = New System.Windows.Forms.GroupBox
        Me.GridImpuestos = New Janus.Windows.GridEX.GridEX
        Me.ChkMarcaTodos = New System.Windows.Forms.CheckBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.TxtCost = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.ChkIncluyeIVA = New System.Windows.Forms.CheckBox
        Me.cmbTipoImpuesto = New Selling.StoreCombo
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton
        Me.GrpCosto.SuspendLayout()
        Me.GrpImpuestos.SuspendLayout()
        CType(Me.GridImpuestos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpCosto
        '
        Me.GrpCosto.Controls.Add(Me.GrpImpuestos)
        Me.GrpCosto.Controls.Add(Me.PictureBox2)
        Me.GrpCosto.Controls.Add(Me.PictureBox1)
        Me.GrpCosto.Controls.Add(Me.TxtCost)
        Me.GrpCosto.Controls.Add(Me.Label1)
        Me.GrpCosto.Controls.Add(Me.ChkIncluyeIVA)
        Me.GrpCosto.Controls.Add(Me.cmbTipoImpuesto)
        Me.GrpCosto.Location = New System.Drawing.Point(7, 7)
        Me.GrpCosto.Name = "GrpCosto"
        Me.GrpCosto.Size = New System.Drawing.Size(501, 160)
        Me.GrpCosto.TabIndex = 0
        Me.GrpCosto.TabStop = False
        Me.GrpCosto.Text = "Costo"
        '
        'GrpImpuestos
        '
        Me.GrpImpuestos.Controls.Add(Me.GridImpuestos)
        Me.GrpImpuestos.Controls.Add(Me.ChkMarcaTodos)
        Me.GrpImpuestos.Location = New System.Drawing.Point(211, 12)
        Me.GrpImpuestos.Name = "GrpImpuestos"
        Me.GrpImpuestos.Size = New System.Drawing.Size(283, 131)
        Me.GrpImpuestos.TabIndex = 102
        Me.GrpImpuestos.TabStop = False
        Me.GrpImpuestos.Text = "Impuestos"
        Me.GrpImpuestos.Visible = False
        '
        'GridImpuestos
        '
        Me.GridImpuestos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridImpuestos.ColumnAutoResize = True
        Me.GridImpuestos.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridImpuestos.Location = New System.Drawing.Point(5, 32)
        Me.GridImpuestos.Name = "GridImpuestos"
        Me.GridImpuestos.RecordNavigator = True
        Me.GridImpuestos.Size = New System.Drawing.Size(273, 94)
        Me.GridImpuestos.TabIndex = 7
        Me.GridImpuestos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'ChkMarcaTodos
        '
        Me.ChkMarcaTodos.Enabled = False
        Me.ChkMarcaTodos.Location = New System.Drawing.Point(7, 12)
        Me.ChkMarcaTodos.Name = "ChkMarcaTodos"
        Me.ChkMarcaTodos.Size = New System.Drawing.Size(107, 22)
        Me.ChkMarcaTodos.TabIndex = 6
        Me.ChkMarcaTodos.Text = "Marcar Todos"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(40, 85)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox2.TabIndex = 97
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(40, 20)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox1.TabIndex = 96
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'TxtCost
        '
        Me.TxtCost.Location = New System.Drawing.Point(58, 18)
        Me.TxtCost.Name = "TxtCost"
        Me.TxtCost.Size = New System.Drawing.Size(140, 20)
        Me.TxtCost.TabIndex = 94
        Me.TxtCost.Text = "0.00"
        Me.TxtCost.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtCost.Value = 0
        Me.TxtCost.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label1.Location = New System.Drawing.Point(6, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 15)
        Me.Label1.TabIndex = 95
        Me.Label1.Text = "Costo"
        '
        'ChkIncluyeIVA
        '
        Me.ChkIncluyeIVA.Location = New System.Drawing.Point(58, 46)
        Me.ChkIncluyeIVA.Name = "ChkIncluyeIVA"
        Me.ChkIncluyeIVA.Size = New System.Drawing.Size(114, 23)
        Me.ChkIncluyeIVA.TabIndex = 92
        Me.ChkIncluyeIVA.Text = "Impuestos Incluidos"
        '
        'cmbTipoImpuesto
        '
        Me.cmbTipoImpuesto.BackColor = System.Drawing.SystemColors.Window
        Me.cmbTipoImpuesto.Location = New System.Drawing.Point(58, 78)
        Me.cmbTipoImpuesto.Name = "cmbTipoImpuesto"
        Me.cmbTipoImpuesto.Size = New System.Drawing.Size(140, 21)
        Me.cmbTipoImpuesto.TabIndex = 93
        Me.cmbTipoImpuesto.Visible = False
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Icon = CType(resources.GetObject("BtnCancelar.Icon"), System.Drawing.Icon)
        Me.BtnCancelar.Location = New System.Drawing.Point(318, 173)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 2
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAgregar.Icon = CType(resources.GetObject("BtnAgregar.Icon"), System.Drawing.Icon)
        Me.BtnAgregar.Location = New System.Drawing.Point(418, 173)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(90, 37)
        Me.BtnAgregar.TabIndex = 1
        Me.BtnAgregar.Text = "&Aceptar"
        Me.BtnAgregar.ToolTipText = "Guardar cambios"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmModCosto
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(513, 216)
        Me.Controls.Add(Me.BtnAgregar)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.GrpCosto)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(319, 204)
        Me.Name = "FrmModCosto"
        Me.Text = "Modificar Costo"
        Me.GrpCosto.ResumeLayout(False)
        Me.GrpCosto.PerformLayout()
        Me.GrpImpuestos.ResumeLayout(False)
        CType(Me.GridImpuestos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Costo As Double
    Public PROClave As String
    Public Padre As String

    Private alerta(1) As PictureBox
    Private reloj As parpadea
    Private dtImpuesto, dtImpuestoProd As DataTable
    Private bLoad As Boolean = False

    Private Sub FrmAddUnidad_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2

        With Me.cmbTipoImpuesto
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Impuesto"
            .NombreParametro2 = "campo"
            .Parametro2 = "Tipo"
            .llenar()
        End With

        bLoad = True

        TxtCost.Text = CStr(Costo)

        dtImpuesto = ModPOS.Recupera_Tabla("sp_filtra_impuestos_tipo", "@TImpuesto", cmbTipoImpuesto.SelectedValue)
        If Not dtImpuesto Is Nothing Then
            GridImpuestos.DataSource = dtImpuesto
            GridImpuestos.RetrieveStructure(True)
            GridImpuestos.GroupByBoxVisible = False
            GridImpuestos.RootTable.Columns("IMPClave").Visible = False
            GridImpuestos.RootTable.Columns("TAplicacion").Visible = False
            GridImpuestos.RootTable.Columns("SobreImp").Visible = False
            GridImpuestos.RootTable.Columns("Valor").Visible = False
            GridImpuestos.CurrentTable.Columns("Nombre").Selectable = False


            ChkMarcaTodos.Enabled = True

            If Padre = "Agregar" Then
                dtImpuestoProd = ModPOS.Recupera_Tabla("sp_filtra_impuestos_def", "@COMClave", ModPOS.CompanyActual)
            Else
                dtImpuestoProd = ModPOS.Recupera_Tabla("sp_filtra_impuestos_prod", "@Producto", PROClave)
            End If

            If Not dtImpuestoProd Is Nothing Then
                Dim y, x As Integer
                For y = 0 To dtImpuesto.Rows.Count - 1
                    For x = 0 To dtImpuestoProd.Rows.Count - 1
                        If dtImpuesto.Rows(y)("IMPClave") = dtImpuestoProd.Rows(x)("IMPClave") Then
                            dtImpuesto.Rows(y)("Marca") = True
                            Exit For
                        End If
                    Next
                Next
            End If
        Else
            MessageBox.Show("No existen impuestos definidos para el tipo de impuesto seleccionado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ChkMarcaTodos.Enabled = False
        End If
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If ChkIncluyeIVA.Checked AndAlso cmbTipoImpuesto.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        End If

        If CDbl(Me.TxtCost.Text) <= 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
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

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        If Me.validaForm Then
           
            If Me.ChkIncluyeIVA.Checked Then
                If Not dtImpuesto Is Nothing AndAlso dtImpuesto.Rows.Count > 0 Then
                    Dim foundRows() As DataRow
                    foundRows = dtImpuesto.Select("Marca=True")

                    If foundRows.GetLength(0) > 0 Then
                        Dim i As Integer
                        Dim PrecioImp As Double = 100
                        Dim ImpImporte As Double = 0
                        For i = 0 To foundRows.GetUpperBound(0)

                            If foundRows(i)("SobreImp") = 1 Then
                                If foundRows(i)("TAplicacion") = 1 Then
                                    ImpImporte = PrecioImp * (foundRows(i)("Valor") / 100)
                                Else
                                    ImpImporte = foundRows(i)("Valor")
                                End If
                            Else
                                If foundRows(i)("TAplicacion") = 1 Then
                                    ImpImporte = foundRows(i)("Valor")
                                Else
                                    ImpImporte = foundRows(i)("Valor")
                                End If
                            End If
                            PrecioImp = PrecioImp + ImpImporte
                        Next

                        Dim Costo As Double = CDbl(TxtCost.Text)
                        Costo = Costo / (1 + ((PrecioImp - 100) / 100))
                        TxtCost.Text = CStr(Costo)
                        Producto.TxtCost.Text = Me.TxtCost.Text
                        Producto.TImpuesto = Me.cmbTipoImpuesto.SelectedValue
                    Else
                        MessageBox.Show("Debe seleccionar por lo menos un impuesto", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                Else
                    MessageBox.Show("Debe seleccionar por lo menos un impuesto", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

            End If
            Producto.ActualizaCosto = True
            Me.Close()
        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub TxtCodigoBarras_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            Me.BtnAgregar.PerformClick()
        End If
    End Sub

    Private Sub ChkIncluyeIVA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkIncluyeIVA.CheckedChanged
        If ChkIncluyeIVA.Checked Then
            cmbTipoImpuesto.Visible = True
            Me.GrpImpuestos.Visible = True
        Else
            cmbTipoImpuesto.Visible = False
            Me.GrpImpuestos.Visible = False
        End If
    End Sub

    Private Sub ChkMarcaTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkMarcaTodos.CheckedChanged
        If dtImpuesto.Rows.Count > 0 Then
            Dim i As Integer
            If ChkMarcaTodos.Checked Then
                For i = 0 To dtImpuesto.Rows.Count - 1
                    dtImpuesto.Rows(i)("Marca") = True
                Next
            Else
                For i = 0 To dtImpuesto.Rows.Count - 1
                    dtImpuesto.Rows(i)("Marca") = False
                Next
            End If
        End If
    End Sub

    
    Private Sub cmbTipoImpuesto_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTipoImpuesto.SelectedValueChanged
        If Not cmbTipoImpuesto.SelectedValue Is Nothing AndAlso bLoad Then
            dtImpuesto = ModPOS.Recupera_Tabla("sp_filtra_impuestos_tipo", "@TImpuesto", cmbTipoImpuesto.SelectedValue)
            If Not dtImpuesto Is Nothing Then
                If dtImpuesto.Rows.Count > 0 Then
                    ChkMarcaTodos.Enabled = True
                Else
                    MessageBox.Show("No existen impuestos definidos para el tipo de impuesto seleccionado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ChkMarcaTodos.Enabled = False
                End If
                GridImpuestos.DataSource = dtImpuesto
                GridImpuestos.RetrieveStructure(True)
                GridImpuestos.GroupByBoxVisible = False
                GridImpuestos.RootTable.Columns("IMPClave").Visible = False
                GridImpuestos.RootTable.Columns("TAplicacion").Visible = False
                GridImpuestos.RootTable.Columns("SobreImp").Visible = False
                GridImpuestos.RootTable.Columns("Valor").Visible = False
                GridImpuestos.CurrentTable.Columns("Nombre").Selectable = False
            End If
        End If
    End Sub

  
End Class
