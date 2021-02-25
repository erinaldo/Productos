Public Class FrmBuscaTicket
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
    Friend WithEvents GrpTickets As System.Windows.Forms.GroupBox
    Friend WithEvents GridTickets As Janus.Windows.GridEX.GridEX
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents TxtTicket As System.Windows.Forms.TextBox
    Friend WithEvents ChkMarcaTodos As System.Windows.Forms.CheckBox
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents CmbCampo As Selling.StoreCombo
    Friend WithEvents TxtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents CmbFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents BtnCancel As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBuscaTicket))
        Me.GrpTickets = New System.Windows.Forms.GroupBox
        Me.CmbFecha = New System.Windows.Forms.DateTimePicker
        Me.BtnCancel = New Janus.Windows.EditControls.UIButton
        Me.PictureBox5 = New System.Windows.Forms.PictureBox
        Me.PictureBox4 = New System.Windows.Forms.PictureBox
        Me.TxtBuscar = New System.Windows.Forms.TextBox
        Me.ChkMarcaTodos = New System.Windows.Forms.CheckBox
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton
        Me.TxtTicket = New System.Windows.Forms.TextBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.GridTickets = New Janus.Windows.GridEX.GridEX
        Me.CmbCampo = New Selling.StoreCombo
        Me.GrpTickets.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridTickets, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpTickets
        '
        Me.GrpTickets.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpTickets.Controls.Add(Me.CmbFecha)
        Me.GrpTickets.Controls.Add(Me.BtnCancel)
        Me.GrpTickets.Controls.Add(Me.PictureBox5)
        Me.GrpTickets.Controls.Add(Me.PictureBox4)
        Me.GrpTickets.Controls.Add(Me.CmbCampo)
        Me.GrpTickets.Controls.Add(Me.TxtBuscar)
        Me.GrpTickets.Controls.Add(Me.ChkMarcaTodos)
        Me.GrpTickets.Controls.Add(Me.BtnGuardar)
        Me.GrpTickets.Controls.Add(Me.TxtTicket)
        Me.GrpTickets.Controls.Add(Me.PictureBox1)
        Me.GrpTickets.Controls.Add(Me.Label2)
        Me.GrpTickets.Controls.Add(Me.Label1)
        Me.GrpTickets.Controls.Add(Me.GridTickets)
        Me.GrpTickets.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpTickets.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpTickets.ForeColor = System.Drawing.Color.Black
        Me.GrpTickets.Location = New System.Drawing.Point(0, 0)
        Me.GrpTickets.Name = "GrpTickets"
        Me.GrpTickets.Size = New System.Drawing.Size(792, 473)
        Me.GrpTickets.TabIndex = 1
        Me.GrpTickets.TabStop = False
        Me.GrpTickets.Text = "Tickets"
        '
        'CmbFecha
        '
        Me.CmbFecha.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbFecha.CustomFormat = "yyyyMMdd"
        Me.CmbFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.CmbFecha.Location = New System.Drawing.Point(63, 14)
        Me.CmbFecha.MinDate = New Date(1990, 1, 1, 0, 0, 0, 0)
        Me.CmbFecha.Name = "CmbFecha"
        Me.CmbFecha.Size = New System.Drawing.Size(100, 22)
        Me.CmbFecha.TabIndex = 47
        Me.CmbFecha.Value = New Date(2000, 2, 2, 0, 0, 0, 0)
        '
        'BtnCancel
        '
        Me.BtnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Image = CType(resources.GetObject("BtnCancel.Image"), System.Drawing.Image)
        Me.BtnCancel.Location = New System.Drawing.Point(601, 431)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancel.TabIndex = 46
        Me.BtnCancel.Text = "&Salir"
        Me.BtnCancel.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancel.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'PictureBox5
        '
        Me.PictureBox5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(37, 16)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(23, 20)
        Me.PictureBox5.TabIndex = 45
        Me.PictureBox5.TabStop = False
        Me.PictureBox5.Visible = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(37, 43)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(20, 20)
        Me.PictureBox4.TabIndex = 44
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'TxtBuscar
        '
        Me.TxtBuscar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtBuscar.Location = New System.Drawing.Point(235, 41)
        Me.TxtBuscar.Name = "TxtBuscar"
        Me.TxtBuscar.Size = New System.Drawing.Size(264, 22)
        Me.TxtBuscar.TabIndex = 42
        '
        'ChkMarcaTodos
        '
        Me.ChkMarcaTodos.Enabled = False
        Me.ChkMarcaTodos.Location = New System.Drawing.Point(9, 64)
        Me.ChkMarcaTodos.Name = "ChkMarcaTodos"
        Me.ChkMarcaTodos.Size = New System.Drawing.Size(154, 22)
        Me.ChkMarcaTodos.TabIndex = 3
        Me.ChkMarcaTodos.Text = "Seleccionar Todos"
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.Location = New System.Drawing.Point(697, 430)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 5
        Me.BtnGuardar.Text = "&Aceptar"
        Me.BtnGuardar.ToolTipText = "Agrega registro seleccionado"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtTicket
        '
        Me.TxtTicket.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTicket.Location = New System.Drawing.Point(235, 15)
        Me.TxtTicket.Name = "TxtTicket"
        Me.TxtTicket.Size = New System.Drawing.Size(100, 21)
        Me.TxtTicket.TabIndex = 0
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(206, 19)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(23, 16)
        Me.PictureBox1.TabIndex = 39
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label2.Location = New System.Drawing.Point(6, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 15)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Fecha"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label1.Location = New System.Drawing.Point(183, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 14)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Folio"
        '
        'GridTickets
        '
        Me.GridTickets.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridTickets.ColumnAutoResize = True
        Me.GridTickets.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridTickets.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridTickets.GroupByBoxVisible = False
        Me.GridTickets.Location = New System.Drawing.Point(7, 86)
        Me.GridTickets.Name = "GridTickets"
        Me.GridTickets.RecordNavigator = True
        Me.GridTickets.Size = New System.Drawing.Size(779, 338)
        Me.GridTickets.TabIndex = 4
        Me.GridTickets.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'CmbCampo
        '
        Me.CmbCampo.BackColor = System.Drawing.SystemColors.Window
        Me.CmbCampo.Location = New System.Drawing.Point(63, 39)
        Me.CmbCampo.Name = "CmbCampo"
        Me.CmbCampo.Size = New System.Drawing.Size(156, 24)
        Me.CmbCampo.TabIndex = 43
        '
        'FrmBuscaTicket
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(792, 473)
        Me.Controls.Add(Me.GrpTickets)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(667, 464)
        Me.Name = "FrmBuscaTicket"
        Me.Text = "Busqueda de Tickets"
        Me.GrpTickets.ResumeLayout(False)
        Me.GrpTickets.PerformLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridTickets, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public ALMClave As String = ""
    Private sTicketSelected As String
    Private alerta(2) As PictureBox
    Private reloj As parpadea
    Private dt As DataTable
    Private bLoad As Boolean = False
    Private FechaIni As DateTime
    Private FechaFin As DateTime

    Public TipoBusqueda As String = "Factura"

    Private pageActual As Integer = 0
    Private pageCount As Integer = 0
    Private dtResult As DataTable

    Private sp As String
    Private bError As Boolean = False

    Private Sub FrmBuscaTicket_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If bError Then
            e.Cancel = True
        End If
    End Sub


    Private Sub FrmBuscaTicket_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Me.StartPosition = FormStartPosition.CenterScreen

        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox4
        alerta(2) = Me.PictureBox5

        With Me.CmbCampo
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Cliente"
            .NombreParametro2 = "campo"
            .Parametro2 = "Filtro"
            .llenar()
        End With

        CmbFecha.Value = DateTime.Today

        ChkMarcaTodos.Enabled = False

        If TipoBusqueda = "Factura" Then
            sp = "sp_recupera_ventas"
        Else
            sp = "sp_recupera_ventas_com"
        End If

        bLoad = True
    End Sub



    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If TxtTicket.Text.Trim = "" AndAlso TxtBuscar.Text.Trim = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj = New parpadea(Me.alerta(2))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.CmbCampo.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
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


    Private Sub ChkMarcaTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkMarcaTodos.CheckedChanged
        If dt.Rows.Count > 0 Then
            Dim i As Integer

            If ChkMarcaTodos.Checked Then
                For i = 0 To dt.Rows.Count - 1
                    dt.Rows(i)("Marca") = True
                Next
            Else
                For i = 0 To dt.Rows.Count - 1
                    dt.Rows(i)("Marca") = False
                Next
            End If
        End If
    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If Not dt Is Nothing Then
            Dim i As Integer

            Dim foundRows() As DataRow

            ' Usa el metodo select para filtrar los registros seleccionados.
            foundRows = dt.Select("Marca ='True'")
            If foundRows.GetLength(0) > 0 Then

                If TipoBusqueda = "Factura" Then
                    For i = 0 To foundRows.GetUpperBound(0)
                        ModPOS.Factura.CargaDatosTicket(CmbFecha.Value.Year, CmbFecha.Value.Month, foundRows(i)(2))
                    Next

               
                Else

                    For i = 0 To foundRows.GetUpperBound(0)
                        ModPOS.ComisionVta.CargaDatosTicket(CmbFecha.Value.Year, CmbFecha.Value.Month, foundRows(i)(2))
                    Next

                End If

                dt.Dispose()
                bError = False
                Me.Close()
            Else
                MessageBox.Show("Para agregar, debe marcar por lo menos un registro", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                bError = True
            End If
        End If

    End Sub

    Private Sub TxtTicket_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtTicket.KeyUp
        If TxtTicket.Text.Trim <> "" Then
            If validaForm() Then

                LoadPage()

            Else
                Beep()
                MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        End If
    End Sub


    Private Sub TxtBuscar_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBuscar.KeyUp
        If TxtBuscar.Text.Trim <> "" Then
            If validaForm() Then
                LoadPage()
            Else
                Beep()
                MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        End If
    End Sub

    Private Sub LoadPage()
        Cursor.Current = Cursors.WaitCursor
        'Obtener el maximo numero de productos

        FechaIni = CmbFecha.Value
        FechaFin = CmbFecha.Value.AddHours(23.9999)

        If Not dt Is Nothing Then
            dt.Dispose()
        End If

       
        dt = ModPOS.Recupera_Tabla(sp, "@Folio", TxtTicket.Text.Trim.ToUpper.Replace("'", "''"), "@FechaIni", FechaIni, "@FechaFin", FechaFin, "@Campo", CmbCampo.SelectedValue, "@Busca", TxtBuscar.Text.ToUpper.Trim.Replace("'", "''"))
       

        GridTickets.DataSource = dt
        GridTickets.RetrieveStructure()
        GridTickets.AutoSizeColumns()
        GridTickets.RootTable.Columns("ID").Visible = False
        GridTickets.CurrentTable.Columns(2).Selectable = False
        GridTickets.CurrentTable.Columns(3).Selectable = False
        GridTickets.CurrentTable.Columns(4).Selectable = False
        GridTickets.CurrentTable.Columns(5).Selectable = False
        GridTickets.CurrentTable.Columns(6).Selectable = False

        If dt.Rows.Count > 0 Then
            ChkMarcaTodos.Enabled = True
        Else
            ChkMarcaTodos.Enabled = False
        End If

        Cursor.Current = Cursors.Default
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        bError = False
        Me.Close()
    End Sub

    Private Sub CmbFecha_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbFecha.ValueChanged
        If bLoad AndAlso (TxtTicket.Text.Trim <> "" OrElse TxtBuscar.Text.Trim <> "") Then
            If validaForm() Then
                LoadPage()
            Else
                Beep()
                MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        End If
    End Sub
End Class
