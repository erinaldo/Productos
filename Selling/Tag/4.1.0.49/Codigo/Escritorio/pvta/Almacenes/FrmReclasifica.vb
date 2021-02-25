Imports System.Data.SqlClient

Public Class FrmReclasifica
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
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnAgregar As Janus.Windows.EditControls.UIButton
    Friend WithEvents GridEntrada As Janus.Windows.GridEX.GridEX
    Friend WithEvents grpSalida As System.Windows.Forms.GroupBox
    Friend WithEvents grpEntrada As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents cmbSucursalO As Selling.StoreCombo
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents GridSalida As Janus.Windows.GridEX.GridEX
    Friend WithEvents cmbOrigen As Selling.StoreCombo
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmReclasifica))
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton()
        Me.GridEntrada = New Janus.Windows.GridEX.GridEX()
        Me.grpSalida = New System.Windows.Forms.GroupBox()
        Me.grpEntrada = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.cmbSucursalO = New Selling.StoreCombo()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.cmbOrigen = New Selling.StoreCombo()
        Me.GridSalida = New Janus.Windows.GridEX.GridEX()
        CType(Me.GridEntrada, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpSalida.SuspendLayout()
        Me.grpEntrada.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridSalida, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.BtnCancelar.Icon = CType(resources.GetObject("BtnCancelar.Icon"), System.Drawing.Icon)
        Me.BtnCancelar.Location = New System.Drawing.Point(580, 521)
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
        Me.BtnAgregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.BtnAgregar.Icon = CType(resources.GetObject("BtnAgregar.Icon"), System.Drawing.Icon)
        Me.BtnAgregar.Location = New System.Drawing.Point(679, 521)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(90, 37)
        Me.BtnAgregar.TabIndex = 1
        Me.BtnAgregar.Text = "&Aceptar"
        Me.BtnAgregar.ToolTipText = "Guardar cambios"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GridEntrada
        '
        Me.GridEntrada.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridEntrada.ColumnAutoResize = True
        Me.GridEntrada.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridEntrada.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridEntrada.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.GridEntrada.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridEntrada.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridEntrada.GroupByBoxVisible = False
        Me.GridEntrada.Location = New System.Drawing.Point(6, 19)
        Me.GridEntrada.Name = "GridEntrada"
        Me.GridEntrada.RecordNavigator = True
        Me.GridEntrada.Size = New System.Drawing.Size(745, 183)
        Me.GridEntrada.TabIndex = 109
        Me.GridEntrada.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'grpSalida
        '
        Me.grpSalida.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpSalida.Controls.Add(Me.GridSalida)
        Me.grpSalida.Location = New System.Drawing.Point(12, 80)
        Me.grpSalida.Name = "grpSalida"
        Me.grpSalida.Size = New System.Drawing.Size(757, 213)
        Me.grpSalida.TabIndex = 110
        Me.grpSalida.TabStop = False
        Me.grpSalida.Text = "Salida"
        '
        'grpEntrada
        '
        Me.grpEntrada.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpEntrada.Controls.Add(Me.GridEntrada)
        Me.grpEntrada.Location = New System.Drawing.Point(12, 299)
        Me.grpEntrada.Name = "grpEntrada"
        Me.grpEntrada.Size = New System.Drawing.Size(757, 216)
        Me.grpEntrada.TabIndex = 111
        Me.grpEntrada.TabStop = False
        Me.grpEntrada.Text = "Entrada"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(20, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 16)
        Me.Label1.TabIndex = 144
        Me.Label1.Text = "Sucursal"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(20, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 16)
        Me.Label2.TabIndex = 143
        Me.Label2.Text = "Almacén"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(46, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox1.TabIndex = 150
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'cmbSucursalO
        '
        Me.cmbSucursalO.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbSucursalO.BackColor = System.Drawing.SystemColors.Window
        Me.cmbSucursalO.Location = New System.Drawing.Point(93, 10)
        Me.cmbSucursalO.Name = "cmbSucursalO"
        Me.cmbSucursalO.Size = New System.Drawing.Size(386, 21)
        Me.cmbSucursalO.TabIndex = 148
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(46, 44)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox2.TabIndex = 147
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'cmbOrigen
        '
        Me.cmbOrigen.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbOrigen.BackColor = System.Drawing.SystemColors.Window
        Me.cmbOrigen.Location = New System.Drawing.Point(93, 42)
        Me.cmbOrigen.Name = "cmbOrigen"
        Me.cmbOrigen.Size = New System.Drawing.Size(386, 21)
        Me.cmbOrigen.TabIndex = 146
        '
        'GridSalida
        '
        Me.GridSalida.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridSalida.ColumnAutoResize = True
        Me.GridSalida.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridSalida.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridSalida.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.GridSalida.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridSalida.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridSalida.GroupByBoxVisible = False
        Me.GridSalida.Location = New System.Drawing.Point(6, 16)
        Me.GridSalida.Name = "GridSalida"
        Me.GridSalida.RecordNavigator = True
        Me.GridSalida.Size = New System.Drawing.Size(745, 189)
        Me.GridSalida.TabIndex = 110
        Me.GridSalida.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'FrmReclasifica
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(777, 561)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.cmbSucursalO)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.cmbOrigen)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.grpEntrada)
        Me.Controls.Add(Me.grpSalida)
        Me.Controls.Add(Me.BtnAgregar)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmReclasifica"
        Me.Text = "Reclasificación de Productos"
        CType(Me.GridEntrada, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpSalida.ResumeLayout(False)
        Me.grpEntrada.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridSalida, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private TallaColor As Integer = 0
    Private SUCClave, ALMClave As String
    Private dtEntrada, dtSalida As DataTable
    Private bLoad As Boolean = False
   
    Private alerta(1) As PictureBox
    Private reloj As parpadea

    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If Me.cmbSucursalO.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.cmbOrigen.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        End If



        If GridEntrada.RowCount <= 0 Then
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

    Private Sub recuperaExistencia(ByVal SUCClave As String, ByVal ALMClave As String)

        If ALMClave = "" Then
            dtSalida.Clear()
        Else

            If Not dtSalida Is Nothing Then
                dtSalida.Dispose()
            End If

            dtSalida = Recupera_Tabla("st_recupera_otros", "@SUCClave", SUCClave, "@ALMClave", ALMClave)

            GridSalida.DataSource = dtSalida
            GridSalida.RetrieveStructure(True)
            GridSalida.GroupByBoxVisible = False
            GridSalida.RootTable.Columns("PROClave").Visible = False
            GridSalida.RootTable.Columns("TProducto").Visible = False
            GridSalida.RootTable.Columns("Costo").Visible = False
            GridSalida.CurrentTable.Columns("Clave").Selectable = False
            GridSalida.CurrentTable.Columns("Nombre").Selectable = False
            GridSalida.CurrentTable.Columns("Disponible").Selectable = False
            GridSalida.RootTable.Columns("Cantidad").FormatString = "0.00"

        End If

    End Sub


    Private Sub FrmReclasifica_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)

        Dim i As Integer
        Dim dt As DataTable = ModPOS.Recupera_Tabla("sp_recupera_parametro", "@COMClave", ModPOS.CompanyActual)
        With Me
            For i = 0 To dt.Rows.Count - 1
                Select Case CStr(dt.Rows(i)("PARClave"))
                    Case "TallaColor"
                        TallaColor = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", 0, dt.Rows(i)("Valor"))

                End Select
            Next
        End With

        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2
      
        With cmbSucursalO
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_sucursal"
            .NombreParametro1 = "USRClave"
            .Parametro1 = ModPOS.UsuarioActual
            .NombreParametro2 = "COMClave"
            .Parametro2 = ModPOS.CompanyActual
            .llenar()
        End With


        If ModPOS.SucursalPredeterminada <> "" Then
            cmbSucursalO.SelectedValue = ModPOS.SucursalPredeterminada
        End If

       

        dtSalida = ModPOS.CrearTabla("Detalle", _
                                   "PROClave", "System.String", _
                                   "TProducto", "System.Int32", _
                                   "Costo", "System.Decimal", _
                                   "Clave", "System.String", _
                                   "Nombre", "System.String", _
                                   "Cantidad", "System.Double")


        dtEntrada = ModPOS.CrearTabla("Detalle", _
                                      "PROClave", "System.String", _
                                      "TProducto", "System.Int32", _
                                      "Costo", "System.Decimal", _
                                      "Clave", "System.String", _
                                      "Nombre", "System.String", _
                                      "Cantidad", "System.Double")


        recuperaAlmacenOrigen()

        If cmbOrigen.SelectedValue Is Nothing Then
            ALMClave = ""
        Else
            ALMClave = cmbOrigen.SelectedItem(0)
        End If


        bLoad = True

    End Sub



    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub


    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        If validaForm() Then

            Dim fEntradas() As Data.DataRow

            Dim fSalidas() As Data.DataRow

            Dim UBCClave As String = ""

            fSalidas = dtSalida.Select("Cantidad > Disponible and Cantidad > 0")

            If fSalidas.Length > 0 Then
                MessageBox.Show("La cantidad de producto que sale excede el disponible", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Dim dt As DataTable = ModPOS.Recupera_Tabla("st_recupera_ubicaciones", "@ALMClave", ALMClave)

            fSalidas = dt.Select("TESTClave = 2 and Estado = 1")
            If fSalidas.GetLength(0) > 0 Then
                UBCClave = fSalidas(0)("UBCClave")
            Else
                fSalidas = dt.Select("TESTClave = 1 and Estado= 1")
                If fSalidas.GetLength(0) > 0 Then
                    UBCClave = fSalidas(0)("UBCClave")
                End If
            End If
            dt.Dispose()

            fSalidas = dtSalida.Select("Cantidad > 0")

            fEntradas = dtEntrada.Select("Cantidad > 0")

            If fSalidas.Length > 0 Then

                Dim dTotalEntrada As Decimal = 0
                Dim dTotalSalida As Decimal = 0

                dTotalEntrada = dtEntrada.Compute("SUM(Cantidad)", "Cantidad > 0")

                dTotalSalida = dtSalida.Compute("SUM(Cantidad)", "Cantidad > 0")

                If dTotalEntrada > dTotalSalida Then
                    MessageBox.Show("La suma de los productos de entrada es Mayor a la cantidad de producto que sale del almacén. Se excede por: " & CStr(dTotalEntrada - dTotalSalida), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                If dTotalEntrada < dTotalSalida Then
                    MessageBox.Show("La suma de los productos de entrada es Menor a la cantidad de producto que sale del almacén.  Faltan: " & CStr(dTotalSalida - dTotalEntrada), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                Dim i As Integer

                'Salidas
                For i = 0 To fSalidas.Length - 1

                    ModPOS.Ejecuta("sp_ajusta_exist_ubc", _
                                           "@ALMClave", ALMClave, _
                                           "@Diferencia", CDec(fSalidas(i)("Cantidad")) * -1, _
                                          "@UBCClave", UBCClave, _
                                           "@PROClave", fSalidas(i)("PROClave"), _
                                           "@Nota", "Reclasificación", _
                                           "@Usuario", ModPOS.UsuarioActual)


                    ModPOS.Ejecuta("st_ajuste", _
                                                      "@SUCClave", SUCClave, _
                                                      "@ALMClave", ALMClave, _
                                                      "@UBCClave", UBCClave, _
                                                      "@PROClave", fSalidas(i)("PROClave"), _
                                                      "@Cantidad", CDec(fSalidas(i)("Cantidad")) * -1, _
                                                      "@TipoMov", 2, _
                                                      "@Referencia", "", _
                                                      "@Nota", "Reclasificación", _
                                                      "@Usuario", ModPOS.UsuarioActual)

                Next


                For i = 0 To fEntradas.Length - 1
                    ' Entradas

                    ModPOS.Ejecuta("sp_ajusta_exist_ubc", _
                                           "@ALMClave", ALMClave, _
                                           "@Diferencia", fEntradas(i)("Cantidad"), _
                                          "@UBCClave", UBCClave, _
                                           "@PROClave", fEntradas(i)("PROClave"), _
                                           "@Nota", "Reclasificación", _
                                           "@Usuario", ModPOS.UsuarioActual)


                    ModPOS.Ejecuta("st_ajuste", _
                                                      "@SUCClave", SUCClave, _
                                                      "@ALMClave", ALMClave, _
                                                      "@UBCClave", UBCClave, _
                                                      "@PROClave", fEntradas(i)("PROClave"), _
                                                      "@Cantidad", fEntradas(i)("Cantidad"), _
                                                      "@TipoMov", 1, _
                                                      "@Referencia", "", _
                                                      "@Nota", "Reclasificación", _
                                                      "@Usuario", ModPOS.UsuarioActual)
                Next

                MessageBox.Show("Se actualizo correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()

            Else
                MessageBox.Show("Debe indicar los productos que salen salen del almacén", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub recuperaDetalle(ByVal sSUCClave As String)

        If Not dtEntrada Is Nothing Then
            dtEntrada.Dispose()
        End If

        dtEntrada = Recupera_Tabla("st_recupera_otros", "@SUCClave", sSUCClave)

        GridEntrada.DataSource = dtEntrada
        GridEntrada.RetrieveStructure(True)
        GridEntrada.GroupByBoxVisible = False
        GridEntrada.RootTable.Columns("PROClave").Visible = False
        GridEntrada.RootTable.Columns("TProducto").Visible = False
        GridEntrada.RootTable.Columns("Costo").Visible = False
        GridEntrada.CurrentTable.Columns("Clave").Selectable = False
        GridEntrada.CurrentTable.Columns("Nombre").Selectable = False
        GridEntrada.RootTable.Columns("Cantidad").FormatString = "0.00"
    End Sub

    Private Sub GridDetalle_CellEdited(sender As Object, e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridEntrada.CellEdited
        If GridEntrada.CurrentColumn.Caption = "Cantidad" Then
            If IsNumeric(GridEntrada.GetValue("Cantidad")) Then

                Select Case CDbl(GridEntrada.GetValue("Cantidad"))
                    Case Is < 0
                        GridEntrada.SetValue("Cantidad", 0)
                End Select

            Else
                GridEntrada.SetValue("Cantidad", 0)
            End If
        End If

    End Sub

    Private Sub GridDetalle_CurrentCellChanged(sender As Object, e As EventArgs) Handles GridEntrada.CurrentCellChanged
        If Not GridEntrada.CurrentColumn Is Nothing Then
            If GridEntrada.CurrentColumn.Caption = "Cantidad" Then
                GridEntrada.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
            Else
                GridEntrada.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
            End If
        End If
    End Sub

 
 
 
    Private Sub recuperaAlmacenOrigen()
        If Not cmbSucursalO.SelectedValue Is Nothing Then
            SUCClave = cmbSucursalO.SelectedValue
            With cmbOrigen
                .Conexion = ModPOS.BDConexion
                .ProcedimientoAlmacenado = "sp_filtra_almsuc"
                .NombreParametro1 = "SUCClave"
                .Parametro1 = SUCClave
                .llenar()
            End With

            If cmbOrigen.SelectedValue Is Nothing Then
                ALMClave = ""
            Else
                ALMClave = cmbOrigen.SelectedItem(0)
            End If

            recuperaExistencia(SUCClave, ALMClave)

            recuperaDetalle(SUCClave)

        Else
            SUCClave = ""
        End If
    End Sub

    Private Sub cmbSucursalO_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbSucursalO.SelectedValueChanged
        If bLoad = True Then
            recuperaAlmacenOrigen()

        End If
    End Sub

    Private Sub cmbOrigen_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbOrigen.SelectedValueChanged
        If bLoad = True Then
            If cmbOrigen.SelectedValue Is Nothing Then
                ALMClave = ""
            Else
                ALMClave = cmbOrigen.SelectedItem(0)
            End If

            recuperaExistencia(SUCClave, ALMClave)
        End If
    End Sub
End Class
