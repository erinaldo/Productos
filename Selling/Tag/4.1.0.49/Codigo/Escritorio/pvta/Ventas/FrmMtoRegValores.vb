Imports System.Net
Imports System.Net.Mail
Imports System.IO

Public Class FrmMtoRegValores
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
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents BtnSalir As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnConsultar As Janus.Windows.EditControls.UIButton
    Friend WithEvents GridRegValores As Janus.Windows.GridEX.GridEX
    Friend WithEvents BtnPrint As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnNC As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtPicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents ChkMarcaTodos As System.Windows.Forms.CheckBox
    Friend WithEvents CmbSucursal As Selling.StoreCombo
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMtoRegValores))
        Me.GrpTickets = New System.Windows.Forms.GroupBox()
        Me.ChkMarcaTodos = New System.Windows.Forms.CheckBox()
        Me.BtnNC = New Janus.Windows.EditControls.UIButton()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtPicker = New System.Windows.Forms.DateTimePicker()
        Me.BtnPrint = New Janus.Windows.EditControls.UIButton()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.BtnConsultar = New Janus.Windows.EditControls.UIButton()
        Me.CmbSucursal = New Selling.StoreCombo()
        Me.BtnSalir = New Janus.Windows.EditControls.UIButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GridRegValores = New Janus.Windows.GridEX.GridEX()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.GrpTickets.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridRegValores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpTickets
        '
        Me.GrpTickets.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpTickets.Controls.Add(Me.ChkMarcaTodos)
        Me.GrpTickets.Controls.Add(Me.BtnNC)
        Me.GrpTickets.Controls.Add(Me.BtnCancelar)
        Me.GrpTickets.Controls.Add(Me.Label3)
        Me.GrpTickets.Controls.Add(Me.dtPicker)
        Me.GrpTickets.Controls.Add(Me.BtnPrint)
        Me.GrpTickets.Controls.Add(Me.PictureBox1)
        Me.GrpTickets.Controls.Add(Me.BtnConsultar)
        Me.GrpTickets.Controls.Add(Me.CmbSucursal)
        Me.GrpTickets.Controls.Add(Me.BtnSalir)
        Me.GrpTickets.Controls.Add(Me.Label1)
        Me.GrpTickets.Controls.Add(Me.GridRegValores)
        Me.GrpTickets.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpTickets.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpTickets.ForeColor = System.Drawing.Color.Black
        Me.GrpTickets.Location = New System.Drawing.Point(0, 0)
        Me.GrpTickets.Name = "GrpTickets"
        Me.GrpTickets.Size = New System.Drawing.Size(742, 473)
        Me.GrpTickets.TabIndex = 1
        Me.GrpTickets.TabStop = False
        Me.GrpTickets.Text = "Reg. Valores"
        '
        'ChkMarcaTodos
        '
        Me.ChkMarcaTodos.Location = New System.Drawing.Point(7, 20)
        Me.ChkMarcaTodos.Name = "ChkMarcaTodos"
        Me.ChkMarcaTodos.Size = New System.Drawing.Size(76, 19)
        Me.ChkMarcaTodos.TabIndex = 57
        Me.ChkMarcaTodos.Text = "Todos"
        '
        'BtnNC
        '
        Me.BtnNC.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnNC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnNC.Image = CType(resources.GetObject("BtnNC.Image"), System.Drawing.Image)
        Me.BtnNC.Location = New System.Drawing.Point(646, 430)
        Me.BtnNC.Name = "BtnNC"
        Me.BtnNC.Size = New System.Drawing.Size(90, 37)
        Me.BtnNC.TabIndex = 24
        Me.BtnNC.Text = "&Reg. Valores"
        Me.BtnNC.ToolTipText = "Realizar Reg. Valores"
        Me.BtnNC.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(358, 430)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 23
        Me.BtnCancelar.Text = "&Cancelar"
        Me.BtnCancelar.ToolTipText = "Cancela el documento seleccionado"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(488, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 16)
        Me.Label3.TabIndex = 55
        Me.Label3.Text = "Periodo"
        '
        'dtPicker
        '
        Me.dtPicker.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtPicker.CustomFormat = "MMMM yyyy"
        Me.dtPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtPicker.Location = New System.Drawing.Point(550, 15)
        Me.dtPicker.Name = "dtPicker"
        Me.dtPicker.ShowUpDown = True
        Me.dtPicker.Size = New System.Drawing.Size(185, 22)
        Me.dtPicker.TabIndex = 54
        '
        'BtnPrint
        '
        Me.BtnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnPrint.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPrint.Icon = CType(resources.GetObject("BtnPrint.Icon"), System.Drawing.Icon)
        Me.BtnPrint.Location = New System.Drawing.Point(454, 430)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(90, 37)
        Me.BtnPrint.TabIndex = 20
        Me.BtnPrint.Text = "Imprimir"
        Me.BtnPrint.ToolTipText = "Reimpresión de Reg. Valores"
        Me.BtnPrint.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(470, 19)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(17, 18)
        Me.PictureBox1.TabIndex = 39
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'BtnConsultar
        '
        Me.BtnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnConsultar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnConsultar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnConsultar.Icon = CType(resources.GetObject("BtnConsultar.Icon"), System.Drawing.Icon)
        Me.BtnConsultar.ImageSize = New System.Drawing.Size(28, 28)
        Me.BtnConsultar.Location = New System.Drawing.Point(551, 430)
        Me.BtnConsultar.Name = "BtnConsultar"
        Me.BtnConsultar.Size = New System.Drawing.Size(90, 37)
        Me.BtnConsultar.TabIndex = 9
        Me.BtnConsultar.Text = "&Consultar"
        Me.BtnConsultar.ToolTipText = "Mostrar Reg. Valores"
        Me.BtnConsultar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'CmbSucursal
        '
        Me.CmbSucursal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbSucursal.BackColor = System.Drawing.SystemColors.Window
        Me.CmbSucursal.Location = New System.Drawing.Point(149, 15)
        Me.CmbSucursal.Name = "CmbSucursal"
        Me.CmbSucursal.Size = New System.Drawing.Size(315, 24)
        Me.CmbSucursal.TabIndex = 36
        '
        'BtnSalir
        '
        Me.BtnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSalir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSalir.Image = CType(resources.GetObject("BtnSalir.Image"), System.Drawing.Image)
        Me.BtnSalir.Location = New System.Drawing.Point(262, 430)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(90, 37)
        Me.BtnSalir.TabIndex = 8
        Me.BtnSalir.Text = "&Salir"
        Me.BtnSalir.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnSalir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label1
        '
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(85, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 14)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Sucursal"
        '
        'GridRegValores
        '
        Me.GridRegValores.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridRegValores.ColumnAutoResize = True
        Me.GridRegValores.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridRegValores.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridRegValores.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridRegValores.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown
        Me.GridRegValores.Location = New System.Drawing.Point(7, 45)
        Me.GridRegValores.Name = "GridRegValores"
        Me.GridRegValores.RecordNavigator = True
        Me.GridRegValores.Size = New System.Drawing.Size(728, 379)
        Me.GridRegValores.TabIndex = 2
        Me.GridRegValores.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'FrmMtoRegValores
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(742, 473)
        Me.Controls.Add(Me.GrpTickets)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(625, 464)
        Me.Name = "FrmMtoRegValores"
        Me.Text = "Registro de Valores"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GrpTickets.ResumeLayout(False)
        Me.GrpTickets.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridRegValores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region


    Public Mes As Integer
    Public Periodo As Integer

    Private Autoriza As String

    Private sMailCliente, PathXML, PathPDF, MailAdress, DisplayName, MailUser, MailPassword, HostSMTP As String
    Private MailPort As Integer
    Private MailSSL As Boolean


    Private alerta(0) As PictureBox


    Private reloj As parpadea
    Private Impresora As String
    Private bLoad As Boolean = False

    Private correo As MailMessage
    Private adjuntos As Attachment
    Private autenticar As NetworkCredential
    Private envio As SmtpClient
    Private dato As FileStream

    Private dtPAC As DataTable
    Private FormatNC, InterfazSalida As String
    Private TipoCF As Integer
    'Private ServidorCancelacion, ServidorTimbrado, Customerkey As String
    Private dtRegValores As DataTable
    Private sSUCClave As String


    Public Sub refrescaGrid()

        If CmbSucursal.SelectedValue Is Nothing Then
            sSUCClave = ""
        Else
            sSUCClave = CmbSucursal.SelectedValue
        End If

        If Not dtRegValores Is Nothing Then
            dtRegValores.Dispose()
        End If

        dtRegValores = ModPOS.Recupera_Tabla("st_muestra_regvalores", "@Sucursal", sSUCClave, "@Periodo", Periodo, "@Mes", Mes)
        GridRegValores.DataSource = dtRegValores
        GridRegValores.RetrieveStructure()
        GridRegValores.BuiltInTexts(Janus.Windows.GridEX.GridEXBuiltInText.GroupByBoxInfo) = "Arrastre el encabezado de la columna aquí para agrupar por esa columna."
        Me.GridRegValores.RootTable.Columns("IdValores").Visible = False
        GridRegValores.RootTable.Columns("ImporteEntregado").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far


    End Sub

    Private Sub FrmMtoRegValores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Cursor.Current = Cursors.WaitCursor

        Me.StartPosition = FormStartPosition.CenterScreen

        alerta(0) = Me.PictureBox1


        With CmbSucursal
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_sucursal"
            .NombreParametro1 = "USRClave"
            .Parametro1 = ModPOS.UsuarioActual
            .NombreParametro2 = "COMClave"
            .Parametro2 = ModPOS.CompanyActual
            .llenar()
        End With

        If ModPOS.SucursalPredeterminada <> "" Then
            CmbSucursal.SelectedValue = ModPOS.SucursalPredeterminada
        End If

        If dtPicker.Value.Day > 28 Then
            Dim Dias As Integer = dtPicker.Value.Day
            dtPicker.Value = dtPicker.Value.AddDays(28 - Dias)
        End If

        Periodo = dtPicker.Value.Year()
        Mes = dtPicker.Value.Month

        refrescaGrid()

        Cursor.Current = Cursors.Default
        bLoad = True


    End Sub

    Private Sub GridRegValores_CellValueChanged(sender As Object, e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridRegValores.CellValueChanged
        dtRegValores.AcceptChanges()
        GridRegValores.Refresh()
    End Sub



    Private Function validaForm() As Boolean
        Dim i As Integer = 0



        If Me.CmbSucursal.SelectedValue Is Nothing Then
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

    Private Sub FrmMtoRegValores_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.MtoRegValores.Dispose()
        ModPOS.MtoRegValores = Nothing
    End Sub


    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub


    Private Sub BtnReimpresion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConsultar.Click
        Dim foundRows() As DataRow

        ' Usa el metodo select para filtrar los registros seleccionados.
        foundRows = dtRegValores.Select("Marca ='True'")
        If foundRows.GetLength(0) = 1 Then

            If ModPOS.RegValores Is Nothing Then
                ModPOS.RegValores = New FrmRegValores
                ModPOS.RegValores.SUCClave = CmbSucursal.SelectedValue
                ModPOS.RegValores.Padre = "Consultar"
                ModPOS.RegValores.IdValores = foundRows(0)("IdValores")
            End If
            ModPOS.RegValores.StartPosition = FormStartPosition.CenterScreen
            ModPOS.RegValores.Show()
            If Not ModPOS.RegValores Is Nothing Then
                ModPOS.RegValores.BringToFront()
            End If

        Else
            MessageBox.Show("Debe marcar solo 1 registro para poder visualizar el documento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End If
    End Sub


    Private Sub Combo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbSucursal.SelectedIndexChanged
        If bLoad Then
            If validaForm() Then
                refrescaGrid()
            End If
        End If
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        Dim i As Integer

        Dim foundRows() As DataRow

        ' Usa el metodo select para filtrar los registros seleccionados.
        foundRows = dtRegValores.Select("Marca ='True'")
        If foundRows.GetLength(0) > 0 Then

            Dim sImpresora As String
            Dim iCopias As Integer

            If PrintDialog1.ShowDialog() = DialogResult.OK Then
                sImpresora = PrintDialog1.PrinterSettings.PrinterName
                iCopias = PrintDialog1.PrinterSettings.Copies
            Else
                Exit Sub
            End If

            Dim OpenReport As New Report
            Dim pvtaDataSet As New DataSet
            pvtaDataSet.DataSetName = "pvtaDataSet"


            For i = 0 To foundRows.GetUpperBound(0)

                pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_regvalores", "@IdValores", foundRows(i)("IdValores")))
                pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_recupera_retiroscaja", "@IdValores", foundRows(i)("IdValores")))

                OpenReport.Print(iCopias, "CRRegistroValores.rpt", pvtaDataSet, "", sImpresora)


                foundRows(i)("Marca") = False
            Next
            ChkMarcaTodos.Checked = False


        Else
            MessageBox.Show("Para reimprimir, debe marcar por lo menos un registro", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If




    End Sub

     Private Sub BtnNC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNC.Click
        If validaForm() Then
            If ModPOS.RegValores Is Nothing Then
                ModPOS.RegValores = New FrmRegValores
                ModPOS.RegValores.SUCClave = CmbSucursal.SelectedValue
                ModPOS.RegValores.Padre = "Agregar"
            End If
            ModPOS.RegValores.StartPosition = FormStartPosition.CenterScreen
            ModPOS.RegValores.Show()
            If Not ModPOS.RegValores Is Nothing Then
                ModPOS.RegValores.BringToFront()
            End If
        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Dim foundRows() As DataRow

        ' Usa el metodo select para filtrar los registros seleccionados.
        foundRows = dtRegValores.Select("Marca ='True'")
        If foundRows.GetLength(0) = 1 And Not CmbSucursal.SelectedValue Is Nothing Then

            Select Case MessageBox.Show("¿Esta seguro de Cancelar el documento " & foundRows(0)("codCartaPorte") & "?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                Case DialogResult.Yes

                    Dim bRetiroCorte As Boolean = False

                    Dim dtAutoriza As DataTable = ModPOS.Recupera_Tabla("sp_valida_autorizacion", "@SUCClave", CmbSucursal.SelectedValue, "@Usuario", ModPOS.UsuarioActual)
                    If dtAutoriza.Rows.Count = 1 Then
                        bRetiroCorte = IIf(dtAutoriza.Rows(0)("RetiroCaja").GetType.Name <> "DBNull", dtAutoriza.Rows(0)("RetiroCaja"), False)
                    Else
                        bRetiroCorte = False
                    End If
                    dtAutoriza.Dispose()

                    If bRetiroCorte = False Then
                        Dim bAutorizado As Boolean = False
                        Dim bSalir As Boolean = False
                        Do

                            Dim a As New MeAutorizacion

                            a.Sucursal = CmbSucursal.SelectedValue
                            a.sp = "st_filtra_retirocaja"
                            a.MontodeAutorizacion = 0
                            a.StartPosition = FormStartPosition.CenterScreen
                            a.ShowDialog()
                            If a.DialogResult = DialogResult.OK Then
                                bAutorizado = a.Autorizado
                            Else
                                bSalir = True
                            End If

                        Loop While bAutorizado = False AndAlso bSalir = False


                        If bRetiroCorte = False AndAlso bAutorizado = False Then
                            Exit Sub
                        End If

                    End If


                    ModPOS.Ejecuta("st_elimina_regvalores", "@IdValores", foundRows(0)("IdValores"))

                    refrescaGrid()

            End Select

        Else
            MessageBox.Show("¡Debe marcar solo 1 registro para cancelar el documento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub dtPicker_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtPicker.ValueChanged
        If bLoad = True AndAlso (Periodo <> dtPicker.Value.Year OrElse Mes <> dtPicker.Value.Month) Then
            Periodo = dtPicker.Value.Year
            Mes = dtPicker.Value.Month
            Me.refrescaGrid()
        End If
    End Sub

    Private Sub GridNC_CurrentCellChanged(sender As Object, e As EventArgs) Handles GridRegValores.CurrentCellChanged
        If Not GridRegValores.CurrentColumn Is Nothing Then
            If GridRegValores.CurrentColumn.Caption = "Marca" Then
                GridRegValores.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
            Else
                GridRegValores.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
            End If
        End If
    End Sub

    Private Sub ChkMarcaTodos_CheckedChanged(sender As Object, e As EventArgs) Handles ChkMarcaTodos.CheckedChanged
        If dtRegValores.Rows.Count > 0 Then
            Dim i As Integer

            If ChkMarcaTodos.Checked Then
                For i = 0 To GridRegValores.GetDataRows.Length - 1
                    GridRegValores.GetDataRows(i).DataRow("Marca") = True
                Next
            Else
                For i = 0 To GridRegValores.GetDataRows.Length - 1
                    GridRegValores.GetDataRows(i).DataRow("Marca") = False
                Next
            End If

            dtRegValores.AcceptChanges()

            GridRegValores.Refresh()
        End If
    End Sub

    Private Sub GridNC_Click(sender As Object, e As EventArgs) Handles GridRegValores.Click
        If Not GridRegValores.CurrentColumn Is Nothing Then
            If GridRegValores.CurrentColumn.Caption <> "Marca" And Not GridRegValores.GetValue("Marca") Is Nothing Then
                If GridRegValores.GetValue("Marca") = False Then
                    GridRegValores.SetValue("Marca", True)
                Else
                    GridRegValores.SetValue("Marca", False)
                End If
                dtRegValores.AcceptChanges()
                GridRegValores.Refresh()

            End If
        End If
    End Sub

   
End Class
