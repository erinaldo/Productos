Public Class FrmActualizaCosto
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtSearch As System.Windows.Forms.TextBox
    Friend WithEvents ChkMarcaTodos As System.Windows.Forms.CheckBox
    Friend WithEvents TxtPorcentaje As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblPorc As System.Windows.Forms.Label
    Friend WithEvents CmbCampo As Selling.StoreCombo
    Friend WithEvents CmbModificar As System.Windows.Forms.ComboBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents Clock As System.Windows.Forms.Timer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GridProductos As Janus.Windows.GridEX.GridEX
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmActualizaCosto))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.CmbModificar = New System.Windows.Forms.ComboBox()
        Me.GridProductos = New Janus.Windows.GridEX.GridEX()
        Me.CmbCampo = New Selling.StoreCombo()
        Me.lblPorc = New System.Windows.Forms.Label()
        Me.TxtPorcentaje = New Janus.Windows.GridEX.EditControls.NumericEditBox()
        Me.ChkMarcaTodos = New System.Windows.Forms.CheckBox()
        Me.TxtSearch = New System.Windows.Forms.TextBox()
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.Clock = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.PictureBox2)
        Me.GroupBox1.Controls.Add(Me.PictureBox4)
        Me.GroupBox1.Controls.Add(Me.PictureBox3)
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Controls.Add(Me.CmbModificar)
        Me.GroupBox1.Controls.Add(Me.GridProductos)
        Me.GroupBox1.Controls.Add(Me.CmbCampo)
        Me.GroupBox1.Controls.Add(Me.lblPorc)
        Me.GroupBox1.Controls.Add(Me.TxtPorcentaje)
        Me.GroupBox1.Controls.Add(Me.ChkMarcaTodos)
        Me.GroupBox1.Controls.Add(Me.TxtSearch)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(678, 312)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Selección de Productos"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(295, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "Costo"
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(445, 20)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(22, 18)
        Me.PictureBox2.TabIndex = 30
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(445, 50)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(20, 16)
        Me.PictureBox4.TabIndex = 33
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(274, 47)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(20, 16)
        Me.PictureBox3.TabIndex = 31
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(113, 44)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(21, 16)
        Me.PictureBox1.TabIndex = 29
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'CmbModificar
        '
        Me.CmbModificar.FormattingEnabled = True
        Me.CmbModificar.Items.AddRange(New Object() {"Incrementar", "Disminuir", "Reemplazar"})
        Me.CmbModificar.Location = New System.Drawing.Point(140, 45)
        Me.CmbModificar.Name = "CmbModificar"
        Me.CmbModificar.Size = New System.Drawing.Size(128, 21)
        Me.CmbModificar.TabIndex = 21
        '
        'GridProductos
        '
        Me.GridProductos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridProductos.ColumnAutoResize = True
        Me.GridProductos.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridProductos.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridProductos.GroupByBoxVisible = False
        Me.GridProductos.Location = New System.Drawing.Point(5, 70)
        Me.GridProductos.Name = "GridProductos"
        Me.GridProductos.RecordNavigator = True
        Me.GridProductos.Size = New System.Drawing.Size(668, 236)
        Me.GridProductos.TabIndex = 20
        Me.GridProductos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'CmbCampo
        '
        Me.CmbCampo.BackColor = System.Drawing.SystemColors.Window
        Me.CmbCampo.Location = New System.Drawing.Point(8, 18)
        Me.CmbCampo.Name = "CmbCampo"
        Me.CmbCampo.Size = New System.Drawing.Size(127, 21)
        Me.CmbCampo.TabIndex = 13
        '
        'lblPorc
        '
        Me.lblPorc.Location = New System.Drawing.Point(338, 50)
        Me.lblPorc.Name = "lblPorc"
        Me.lblPorc.Size = New System.Drawing.Size(13, 15)
        Me.lblPorc.TabIndex = 12
        Me.lblPorc.Text = "%"
        '
        'TxtPorcentaje
        '
        Me.TxtPorcentaje.Location = New System.Drawing.Point(352, 47)
        Me.TxtPorcentaje.Name = "TxtPorcentaje"
        Me.TxtPorcentaje.Size = New System.Drawing.Size(87, 20)
        Me.TxtPorcentaje.TabIndex = 11
        Me.TxtPorcentaje.Text = "0.00"
        Me.TxtPorcentaje.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtPorcentaje.Value = 0.0R
        Me.TxtPorcentaje.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'ChkMarcaTodos
        '
        Me.ChkMarcaTodos.Enabled = False
        Me.ChkMarcaTodos.Location = New System.Drawing.Point(8, 50)
        Me.ChkMarcaTodos.Name = "ChkMarcaTodos"
        Me.ChkMarcaTodos.Size = New System.Drawing.Size(109, 15)
        Me.ChkMarcaTodos.TabIndex = 6
        Me.ChkMarcaTodos.Text = "Marcar Todos"
        '
        'TxtSearch
        '
        Me.TxtSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtSearch.Location = New System.Drawing.Point(141, 18)
        Me.TxtSearch.Name = "TxtSearch"
        Me.TxtSearch.Size = New System.Drawing.Size(298, 20)
        Me.TxtSearch.TabIndex = 4
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.Location = New System.Drawing.Point(595, 324)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 26
        Me.BtnGuardar.Text = "&Aceptar"
        Me.BtnGuardar.ToolTipText = "Guardar cambios"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(499, 325)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 27
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Clock
        '
        Me.Clock.Interval = 500
        '
        'FrmActualizaCosto
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(688, 365)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(580, 364)
        Me.Name = "FrmActualizaCosto"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private dtProductos As DataTable
    Private dUtilidad As Double
    Private alerta(3) As PictureBox
    Private reloj As parpadea

    Private Sub FrmAddPrecio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Dim Cnx As String

        Cnx = ModPOS.BDConexion

        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2
        alerta(2) = Me.PictureBox3
        alerta(3) = Me.PictureBox4

        With Me.CmbCampo
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Producto"
            .NombreParametro2 = "campo"
            .Parametro2 = "Filtro"
            .llenar()
        End With

    End Sub

    Private Sub FrmActualizaCosto_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.ActualizaCosto.Dispose()
        ModPOS.ActualizaCosto = Nothing
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub


    Private Sub ChkMarcaTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkMarcaTodos.CheckedChanged
        If dtProductos.Rows.Count > 0 Then
            Dim i As Integer

            Cursor.Current = Cursors.WaitCursor
            If ChkMarcaTodos.Checked Then
                For i = 0 To GridProductos.GetDataRows.Length - 1
                    GridProductos.GetDataRows(i).DataRow("Marca") = True
                Next
            Else
                For i = 0 To GridProductos.GetDataRows.Length - 1
                    GridProductos.GetDataRows(i).DataRow("Marca") = False
                Next
            End If


            Cursor.Current = Cursors.Default
        End If
    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If validaForm() Then
            Dim i As Integer
            Dim sPROClave As String
            Dim incrementar As Integer = 0
            Dim CostoVigente As Double = 0
            Dim FactorPrecio As Double = 0

            Select Case CmbModificar.SelectedItem.ToString
                Case Is = "Incrementar"
                    incrementar = 1
                Case Is = "Disminuir"
                    incrementar = 0
                Case Is = "Reemplazar"
                    incrementar = 2
            End Select




            Dim foundRows() As DataRow
            foundRows = dtProductos.Select("Marca = 1")

            Cursor.Current = Cursors.WaitCursor

            If foundRows.GetLength(0) > 0 Then


                Beep()
                Select Case MessageBox.Show("Se va a " & CmbModificar.SelectedItem.ToString & " el Costo en un " & lblPorc.Text & TxtPorcentaje.Text & " de todos los registros marcados, esta deacuerdo?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    Case DialogResult.Yes

                        If incrementar = 2 Then
                            dUtilidad = CDbl(TxtPorcentaje.Text)

                        Else
                            dUtilidad = 1 + (CDbl(TxtPorcentaje.Text) / 100)

                        End If
                       

                        Dim dtSucursal As DataTable

                        dtSucursal = ModPOS.Recupera_Tabla("sp_muestra_sucursales", "@COMClave", ModPOS.CompanyActual)

                        dtSucursal = SelectDistinc("Sucursal", dtSucursal, "SUCClave")

                        Dim z As Integer

                        Dim frmStatusMessage As New frmStatus
                        frmStatusMessage.BringToFront()

                        For i = 0 To foundRows.GetUpperBound(0)
                            frmStatusMessage.Show("Procesando " & CStr(i + 1) & " de " & CStr(foundRows.GetUpperBound(0) + 1) & " registros")

                            sPROClave = foundRows(i)("ID")

                            Select Case incrementar
                                Case Is = 1 '"Incrementar"
                                    CostoVigente = Redondear(foundRows(i)("Costo") * dUtilidad, 2)
                                Case Is = 0 '"Disminuir"
                                    CostoVigente = Redondear(foundRows(i)("Costo") / dUtilidad, 2)
                                Case Is = 2 '"Reemplazar"
                                    CostoVigente = dUtilidad

                                    If CostoVigente > foundRows(i)("Costo") Then
                                        dUtilidad = 1 + ((CostoVigente - foundRows(i)("Costo")) / foundRows(i)("Costo"))
                                    Else
                                        dUtilidad = 1
                                    End If

                            End Select

                            ModPOS.Ejecuta("st_act_costo_producto", _
                                      "@PROClave", sPROClave, _
                                      "@Costo", CostoVigente,
                                      "@Usuario", ModPOS.UsuarioActual)

                            For z = 0 To dtSucursal.Rows.Count - 1
                                ModPOS.Ejecuta("st_act_costo_sucursal", _
                                                     "@SUCClave", dtSucursal.Rows(z)("SUCClave"), _
                                                     "@PROClave", sPROClave, _
                                                     "@Costo", CostoVigente, _
                                                     "@Usuario", ModPOS.UsuarioActual)

                            Next

                            '   Actualiza Precio
                            If dUtilidad > 1 Then
                                ModPOS.Ejecuta("st_actualiza_precio", _
                                        "@COMClave", ModPOS.CompanyActual, _
                                        "@PROClave", sPROClave, _
                                        "@Accion", incrementar, _
                                        "@utilidad", dUtilidad, _
                                        "@Usuario", ModPOS.UsuarioActual)
                            End If
                        Next

                        frmStatusMessage.Close()
                End Select


                dtProductos.Dispose()
                Cursor.Current = Cursors.Default
            Else
                Beep()
                MessageBox.Show("¡No se encontraron registros marcados para modificar!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If CmbModificar.SelectedItem Is Nothing Then
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
            i += 1
        End If



        If dtProductos Is Nothing Then
            reloj = New parpadea(Me.alerta(2))
            reloj.Enabled = True
            reloj.Start()
            i += 1
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

    Private Sub TxtSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtSearch.KeyDown
        Clock.Stop()
    End Sub

    Private Sub TxtSearch_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtSearch.KeyUp
        Clock.Start()
    End Sub

    Private Sub Clock_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Clock.Tick
        Clock.Stop()
        If CmbCampo.SelectedValue = Nothing Then
            MsgBox("Los parametros de busqueda son requeridos", MsgBoxStyle.Critical, "Error")
        ElseIf TxtSearch.Text <> "" Then
            If Not dtProductos Is Nothing Then
                dtProductos.Dispose()
            End If
            dtProductos = ModPOS.Recupera_Tabla("sp_filtra_Costo", "@COMClave", ModPOS.CompanyActual, "@Campo", Me.CmbCampo.SelectedValue, "@Busca", Me.TxtSearch.Text.Replace("'", "''"), "@Char", cReplace)
            GridProductos.DataSource = dtProductos
            GridProductos.RetrieveStructure()
            GridProductos.RootTable.Columns("Marca").Width = 10
            GridProductos.RootTable.Columns("Clave").Width = 60
            GridProductos.RootTable.Columns("Nombre").Width = 190
            GridProductos.RootTable.Columns("Costo").Width = 40
            GridProductos.RootTable.Columns("ID").Visible = False
            GridProductos.CurrentTable.Columns("Clave").Selectable = False
            GridProductos.CurrentTable.Columns("Nombre").Selectable = False
            GridProductos.CurrentTable.Columns("Costo").Selectable = False


            If Not dtProductos Is Nothing AndAlso dtProductos.Rows.Count > 0 Then
                Me.ChkMarcaTodos.Enabled = True
            Else
                Me.ChkMarcaTodos.Enabled = False
            End If

        End If
    End Sub

   
End Class
