Public Class FrmPacking
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
    Friend WithEvents GrpDetalle As System.Windows.Forms.GroupBox
    Friend WithEvents gridDetalle As Janus.Windows.GridEX.GridEX
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TxtCantidad As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblCantidad As System.Windows.Forms.Label
    Friend WithEvents BtnBuscaProd As Janus.Windows.EditControls.UIButton
    Friend WithEvents lblProducto As System.Windows.Forms.Label
    Friend WithEvents TxtProducto As System.Windows.Forms.TextBox
    Friend WithEvents lblPaquete As System.Windows.Forms.Label
    Friend WithEvents txtPaquete As System.Windows.Forms.TextBox
    Friend WithEvents LblUsuario As System.Windows.Forms.Label
    Friend WithEvents btnBuscaUsr As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtUsuario As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnDel As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPacking))
        Me.GrpDetalle = New System.Windows.Forms.GroupBox()
        Me.LblUsuario = New System.Windows.Forms.Label()
        Me.btnBuscaUsr = New Janus.Windows.EditControls.UIButton()
        Me.TxtUsuario = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnDel = New Janus.Windows.EditControls.UIButton()
        Me.lblPaquete = New System.Windows.Forms.Label()
        Me.txtPaquete = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TxtCantidad = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.lblCantidad = New System.Windows.Forms.Label()
        Me.BtnBuscaProd = New Janus.Windows.EditControls.UIButton()
        Me.lblProducto = New System.Windows.Forms.Label()
        Me.TxtProducto = New System.Windows.Forms.TextBox()
        Me.gridDetalle = New Janus.Windows.GridEX.GridEX()
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton()
        Me.GrpDetalle.SuspendLayout()
        CType(Me.gridDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpDetalle
        '
        Me.GrpDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpDetalle.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpDetalle.Controls.Add(Me.LblUsuario)
        Me.GrpDetalle.Controls.Add(Me.btnBuscaUsr)
        Me.GrpDetalle.Controls.Add(Me.TxtUsuario)
        Me.GrpDetalle.Controls.Add(Me.Label8)
        Me.GrpDetalle.Controls.Add(Me.btnDel)
        Me.GrpDetalle.Controls.Add(Me.lblPaquete)
        Me.GrpDetalle.Controls.Add(Me.txtPaquete)
        Me.GrpDetalle.Controls.Add(Me.Label13)
        Me.GrpDetalle.Controls.Add(Me.TxtCantidad)
        Me.GrpDetalle.Controls.Add(Me.lblCantidad)
        Me.GrpDetalle.Controls.Add(Me.BtnBuscaProd)
        Me.GrpDetalle.Controls.Add(Me.lblProducto)
        Me.GrpDetalle.Controls.Add(Me.TxtProducto)
        Me.GrpDetalle.Controls.Add(Me.gridDetalle)
        Me.GrpDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpDetalle.ForeColor = System.Drawing.Color.Black
        Me.GrpDetalle.Location = New System.Drawing.Point(7, 7)
        Me.GrpDetalle.Name = "GrpDetalle"
        Me.GrpDetalle.Size = New System.Drawing.Size(778, 478)
        Me.GrpDetalle.TabIndex = 1
        Me.GrpDetalle.TabStop = False
        Me.GrpDetalle.Text = "Detalle"
        '
        'LblUsuario
        '
        Me.LblUsuario.Location = New System.Drawing.Point(267, 51)
        Me.LblUsuario.Name = "LblUsuario"
        Me.LblUsuario.Size = New System.Drawing.Size(501, 19)
        Me.LblUsuario.TabIndex = 172
        '
        'btnBuscaUsr
        '
        Me.btnBuscaUsr.Icon = CType(resources.GetObject("btnBuscaUsr.Icon"), System.Drawing.Icon)
        Me.btnBuscaUsr.Location = New System.Drawing.Point(222, 45)
        Me.btnBuscaUsr.Name = "btnBuscaUsr"
        Me.btnBuscaUsr.Size = New System.Drawing.Size(39, 29)
        Me.btnBuscaUsr.TabIndex = 169
        Me.btnBuscaUsr.ToolTipText = "Busqueda de Usuarios"
        Me.btnBuscaUsr.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtUsuario
        '
        Me.TxtUsuario.Location = New System.Drawing.Point(96, 48)
        Me.TxtUsuario.Name = "TxtUsuario"
        Me.TxtUsuario.Size = New System.Drawing.Size(120, 22)
        Me.TxtUsuario.TabIndex = 2
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(7, 54)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(85, 14)
        Me.Label8.TabIndex = 170
        Me.Label8.Text = "Recolector"
        '
        'btnDel
        '
        Me.btnDel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDel.Icon = CType(resources.GetObject("btnDel.Icon"), System.Drawing.Icon)
        Me.btnDel.Location = New System.Drawing.Point(733, 94)
        Me.btnDel.Name = "btnDel"
        Me.btnDel.Size = New System.Drawing.Size(39, 29)
        Me.btnDel.TabIndex = 143
        Me.btnDel.ToolTipText = "Remueve el producto Seleccionado "
        Me.btnDel.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'lblPaquete
        '
        Me.lblPaquete.Location = New System.Drawing.Point(7, 24)
        Me.lblPaquete.Name = "lblPaquete"
        Me.lblPaquete.Size = New System.Drawing.Size(79, 16)
        Me.lblPaquete.TabIndex = 135
        Me.lblPaquete.Text = "IdPaquete"
        '
        'txtPaquete
        '
        Me.txtPaquete.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPaquete.Location = New System.Drawing.Point(96, 21)
        Me.txtPaquete.Name = "txtPaquete"
        Me.txtPaquete.Size = New System.Drawing.Size(339, 21)
        Me.txtPaquete.TabIndex = 1
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(62, 99)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(30, 22)
        Me.Label13.TabIndex = 133
        Me.Label13.Text = "X"
        '
        'TxtCantidad
        '
        Me.TxtCantidad.Location = New System.Drawing.Point(7, 99)
        Me.TxtCantidad.Name = "TxtCantidad"
        Me.TxtCantidad.Size = New System.Drawing.Size(53, 22)
        Me.TxtCantidad.TabIndex = 3
        Me.TxtCantidad.Text = "1.00"
        Me.TxtCantidad.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtCantidad.Value = 1.0R
        Me.TxtCantidad.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'lblCantidad
        '
        Me.lblCantidad.Location = New System.Drawing.Point(7, 79)
        Me.lblCantidad.Name = "lblCantidad"
        Me.lblCantidad.Size = New System.Drawing.Size(79, 16)
        Me.lblCantidad.TabIndex = 132
        Me.lblCantidad.Text = "Cantidad"
        '
        'BtnBuscaProd
        '
        Me.BtnBuscaProd.Icon = CType(resources.GetObject("BtnBuscaProd.Icon"), System.Drawing.Icon)
        Me.BtnBuscaProd.Location = New System.Drawing.Point(400, 94)
        Me.BtnBuscaProd.Name = "BtnBuscaProd"
        Me.BtnBuscaProd.Size = New System.Drawing.Size(39, 29)
        Me.BtnBuscaProd.TabIndex = 4
        Me.BtnBuscaProd.ToolTipText = "Busqueda de Producto"
        Me.BtnBuscaProd.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'lblProducto
        '
        Me.lblProducto.Location = New System.Drawing.Point(93, 80)
        Me.lblProducto.Name = "lblProducto"
        Me.lblProducto.Size = New System.Drawing.Size(125, 15)
        Me.lblProducto.TabIndex = 131
        Me.lblProducto.Text = "Producto"
        '
        'TxtProducto
        '
        Me.TxtProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtProducto.Location = New System.Drawing.Point(96, 100)
        Me.TxtProducto.Name = "TxtProducto"
        Me.TxtProducto.Size = New System.Drawing.Size(298, 21)
        Me.TxtProducto.TabIndex = 3
        '
        'gridDetalle
        '
        Me.gridDetalle.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.gridDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridDetalle.ColumnAutoResize = True
        Me.gridDetalle.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.gridDetalle.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.gridDetalle.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.gridDetalle.GroupByBoxVisible = False
        Me.gridDetalle.Location = New System.Drawing.Point(7, 127)
        Me.gridDetalle.Name = "gridDetalle"
        Me.gridDetalle.RecordNavigator = True
        Me.gridDetalle.Size = New System.Drawing.Size(765, 345)
        Me.gridDetalle.TabIndex = 5
        Me.gridDetalle.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.Location = New System.Drawing.Point(695, 491)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 6
        Me.BtnGuardar.Text = "&Aceptar"
        Me.BtnGuardar.ToolTipText = "Mostrar corte de caja seleccionado"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmPacking
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(792, 531)
        Me.Controls.Add(Me.GrpDetalle)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(667, 464)
        Me.Name = "FrmPacking"
        Me.Text = "Contenido del Paquete"
        Me.GrpDetalle.ResumeLayout(False)
        Me.GrpDetalle.PerformLayout()
        CType(Me.gridDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public SUCClave As String
    Public Padre As String = ""
    Public idPaquete As String = ""
    Public PICClave As String = ""
    Public ClaveSucursal As String = ""
    Public TallaColor As Integer = 0

    Private sPROClave, Nombre As String
    Private iNumDecimales, iFactor, iTProducto As Integer
    Private dCantidad As Decimal
    Private USRClave As String = ""
    Private dtPaqueteDetalle As DataTable

    Private Sub FrmPacking_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Me.StartPosition = FormStartPosition.CenterScreen

        TxtCantidad.Enabled = False
        TxtProducto.Enabled = False
        BtnBuscaProd.Enabled = False
        gridDetalle.Enabled = False

        dtPaqueteDetalle = ModPOS.CrearTabla("PaqueteDetalle", _
                                "PROClave", "System.String", _
                                "TProducto", "System.Int32", _
                                "Clave", "System.String", _
                                "Nombre", "System.String", _
                                "Original", "System.Double", _
                                "Cantidad", "System.Double"
                                )

        gridDetalle.DataSource = dtPaqueteDetalle
        gridDetalle.RetrieveStructure(True)
        gridDetalle.GroupByBoxVisible = False
        gridDetalle.AutoSizeColumns()
        gridDetalle.RootTable.Columns("TProducto").Visible = False
        gridDetalle.RootTable.Columns("PROClave").Visible = False
        gridDetalle.RootTable.Columns("Original").Visible = False
        gridDetalle.CurrentTable.Columns("Clave").Selectable = False
        gridDetalle.CurrentTable.Columns("Nombre").Selectable = False
        gridDetalle.CurrentTable.Columns("Cantidad").Selectable = False
        gridDetalle.RootTable.Columns("Clave").Width = 70
        gridDetalle.RootTable.Columns("Nombre").Width = 230
        gridDetalle.RootTable.Columns("Cantidad").Width = 50


    End Sub


    Private Sub leeCodigoBarras(ByVal Codigo As String)

        'valida surtidor
        If USRClave = "" Then
            MessageBox.Show("Debe seleccionar un Recolector", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TxtUsuario.Focus()
            Exit Sub
        End If


        If Not Codigo = vbNullString Then
            'Busca y recupera los datos del producto
            Dim dtProducto As DataTable = ModPOS.SiExisteRecupera("sp_surtido_producto", "@Clave", Codigo.Replace("'", "''"), "@Char", cReplace, "@TallaColor", TallaColor)
            If Not dtProducto Is Nothing AndAlso dtProducto.Rows.Count > 0 Then
                iNumDecimales = dtProducto.Rows(0)("Num_Decimales")
                iFactor = dtProducto.Rows(0)("Factor")

                TxtCantidad.DecimalDigits = iNumDecimales

                If TxtCantidad.Text = vbNullString OrElse CDbl(TxtCantidad.Text) <= 0 Then
                    dCantidad = 1 * iFactor
                    TxtCantidad.Text = "1"
                Else
                    dCantidad = CDbl(TxtCantidad.Text) * iFactor
                End If

                If ModPOS.Picking.surtirProducto(dtProducto, dCantidad, idPaquete, USRClave) = True Then

                    Dim foundRows() As System.Data.DataRow

                    foundRows = dtPaqueteDetalle.Select("PROClave = '" & sPROClave & "'")

                    If foundRows.Length = 1 Then

                        foundRows(0)("Cantidad") += dCantidad

                    Else
                        Dim row1 As DataRow
                        row1 = dtPaqueteDetalle.NewRow()
                        'declara el nombre de la fila
                        row1.Item("PROClave") = dtProducto.Rows(0)("PROClave")
                        row1.Item("TProducto") = dtProducto.Rows(0)("TProducto")
                        row1.Item("Clave") = dtProducto.Rows(0)("Clave")
                        row1.Item("Nombre") = dtProducto.Rows(0)("Nombre")
                        row1.Item("Cantidad") = dCantidad
                        dtPaqueteDetalle.Rows.Add(row1)
                    End If

                End If

                dtProducto.Dispose()

                TxtCantidad.Text = "1"
                TxtProducto.Text = ""

                TxtProducto.Focus()
            Else
                sPROClave = 0
                iTProducto = 0
                iNumDecimales = 0
                iFactor = 0
                TxtProducto.Text = ""
                Beep()
                MessageBox.Show("La Clave o Código de Barras no esta registrada o esta inactiva", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If


        End If
    End Sub


    Private Sub BtnBuscaProd_Click(sender As Object, e As EventArgs) Handles BtnBuscaProd.Click
        Dim a As New MeSearch
        If TallaColor = 1 Then
            a.ProcedimientoAlmacenado = "st_search_prod_tc"
            a.CampoCmb = "FiltroTC"
        Else
            a.ProcedimientoAlmacenado = "sp_search_prod"
            a.CampoCmb = "Filtro"
        End If
        a.bReplace = True
        a.TablaCmb = "Producto"
        a.NumColDes = 2
        a.CompaniaRequerido = True
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            TxtProducto.Text = a.valor
            leeCodigoBarras(a.valor)
        End If
        a.Dispose()
    End Sub

    Private Sub TxtCantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtCantidad.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Not TxtCantidad.Text = vbNullString Then
                If CDbl(TxtCantidad.Text) <= 0 Then
                    dCantidad = 1
                    TxtCantidad.Text = CStr(dCantidad)
                Else
                    dCantidad = Math.Abs(CDbl(TxtCantidad.Text))
                End If
            Else
                dCantidad = 1
                TxtCantidad.Text = CStr(dCantidad)
            End If
            TxtProducto.Focus()
        End If
    End Sub

    Private Sub TxtCantidad_Leave(sender As Object, e As EventArgs) Handles TxtCantidad.Leave
        If Not TxtCantidad.Text = vbNullString Then
            If CDbl(TxtCantidad.Text) <= 0 Then
                dCantidad = 1
                TxtCantidad.Text = CStr(dCantidad)
            Else
                dCantidad = Math.Abs(CDbl(TxtCantidad.Text))
            End If

        Else
            dCantidad = 1
            TxtCantidad.Text = CStr(dCantidad)
        End If

        TxtProducto.Focus()
    End Sub

    Private Sub TxtProducto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtProducto.KeyPress
        If Asc(e.KeyChar) = 13 Then
            leeCodigoBarras(TxtProducto.Text.Trim.ToUpper.Replace("'", "''"))
        End If
    End Sub

    Private Sub txtPaquete_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPaquete.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Not txtPaquete.Text.Trim = vbNullString AndAlso txtPaquete.Text.Length = ClaveSucursal.Length + 12 AndAlso ClaveSucursal = txtPaquete.Text.Substring(0, ClaveSucursal.Length).ToUpper Then
                Dim dt As DataTable = ModPOS.Recupera_Tabla("st_valida_paquete", "@idPaquete", txtPaquete.Text.ToUpper.Trim, "@PICClave", PICClave)

                If dt.Rows.Count = 1 Then

                    Dim guia, nota As String

                    guia = IIf(dt.Rows(0)("guia").GetType.Name = "DBNull", "", dt.Rows(0)("guia"))
                    nota = IIf(dt.Rows(0)("nota").GetType.Name = "DBNull", "", dt.Rows(0)("nota"))

                    If dt.Rows(0)("PICClave").GetType.Name = "DBNull" Then

                        Dim dtv As DataTable
                        dtv = Recupera_Tabla("sp_recupera_valor", "@Tabla", "Paquete", "@Campo", "TipoPaquete", "@Valor", dt.Rows(0)("TipoPaquete"))
                        Dim sTipo As String = CStr(dtv.Rows(0)("Clave"))
                        dtv.Dispose()

                        ModPOS.Ejecuta("st_agrega_paq", "@idPaquete", dt.Rows(0)("idPaquete"), "@PICClave", PICClave, "@Usuario", ModPOS.UsuarioActual)

                        ModPOS.Picking.AddPaquete(dt.Rows(0)("idPaquete"), sTipo, guia, nota)

                    End If


                    idPaquete = dt.Rows(0)("idPaquete")

                    dtPaqueteDetalle = ModPOS.Recupera_Tabla("st_recupera_paqdet", "@idPaquete", idPaquete)
                    gridDetalle.DataSource = dtPaqueteDetalle
                    gridDetalle.RetrieveStructure(True)
                    gridDetalle.GroupByBoxVisible = False
                    gridDetalle.AutoSizeColumns()
                    gridDetalle.RootTable.Columns("TProducto").Visible = False
                    gridDetalle.RootTable.Columns("PROClave").Visible = False
                    gridDetalle.RootTable.Columns("Original").Visible = False
                    gridDetalle.CurrentTable.Columns("Clave").Selectable = False
                    gridDetalle.CurrentTable.Columns("Nombre").Selectable = False
                    gridDetalle.CurrentTable.Columns("Cantidad").Selectable = False
                    gridDetalle.RootTable.Columns("Clave").Width = 70
                    gridDetalle.RootTable.Columns("Nombre").Width = 230
                    gridDetalle.RootTable.Columns("Cantidad").Width = 50

                    TxtCantidad.Enabled = True
                    TxtProducto.Enabled = True
                    BtnBuscaProd.Enabled = True
                    gridDetalle.Enabled = True

                    txtPaquete.Enabled = False

                    TxtUsuario.Focus()

                Else
                    Beep()
                    MessageBox.Show("El idPaquete, no corresponde al Picking actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                dt.Dispose()

            Else
                Beep()
                MessageBox.Show("El idPaquete, no es valido o es requerido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        End If
    End Sub


    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Me.Close()

    End Sub

    Private Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click
        If Not gridDetalle.GetValue(0) Is Nothing Then
            Select Case MessageBox.Show("Se eliminara el producto :" & gridDetalle.GetValue("Clave"), "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes

                    If ModPOS.Picking.removerProducto(gridDetalle.GetValue("PROClave"), gridDetalle.GetValue("Cantidad"), idPaquete) = True Then

                        Dim foundRows() As System.Data.DataRow
                        foundRows = dtPaqueteDetalle.Select("PROClave ='" & gridDetalle.GetValue("PROClave") & "'")
                        dtPaqueteDetalle.Rows.Remove(foundRows(0))
                    End If
            End Select
        Else
            Beep()
            MessageBox.Show("Debe seleccionar un Producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub btnBuscaUsr_Click(sender As Object, e As EventArgs) Handles btnBuscaUsr.Click
        Dim a As New MeSearch
        a.ProcedimientoAlmacenado = "st_search_tipo_usuario"
        a.Tipo = 2
        a.SUCClave = SUCClave
        a.TablaCmb = "Usuario"
        a.CampoCmb = "Filtro"
        a.OcultaID = True
        a.CompaniaRequerido = False
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            If Not a.valor Is Nothing Then
                USRClave = a.valor
                TxtUsuario.Text = a.Descripcion2
                LblUsuario.Text = a.Descripcion
                TxtProducto.Focus()
            End If
        End If
    End Sub

    Private Sub TxtUsuario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtUsuario.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Not TxtUsuario.Text = vbNullString Then
                Dim dt As DataTable = ModPOS.SiExisteRecupera("st_search_tipo_usuario", "@Campo", 1, "@Busqueda", TxtUsuario.Text.Replace("'", "''"), "@Tipo", 2, "@SUCClave", SUCClave)
                If Not dt Is Nothing Then
                    USRClave = dt.Rows(0)("ID")
                    LblUsuario.Text = dt.Rows(0)("Nombre")
                    dt.Dispose()
                    TxtProducto.Focus()

                Else
                    USRClave = ""
                    LblUsuario.Text = ""
                    MessageBox.Show("¡La Clave de usuario no pertenece a un usuario de tipo Operacion de la sucursal actual!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
            End If
        End If
    End Sub
End Class
