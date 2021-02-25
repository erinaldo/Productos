Imports CrystalDecisions.CrystalReports.Engine
Imports System.Net
Imports System.Net.Mail
Imports System.IO

Public Class FrmComplementoPago
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
    Friend WithEvents GrpComplemento As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents BtnSalir As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnConsultar As Janus.Windows.EditControls.UIButton
    Friend WithEvents GridComplementoPago As Janus.Windows.GridEX.GridEX
    Friend WithEvents BtnImprimir As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnSend As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtPicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents ChkMarcaTodos As System.Windows.Forms.CheckBox
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents CmbSucursal As Selling.StoreCombo
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmComplementoPago))
        Me.GrpComplemento = New System.Windows.Forms.GroupBox()
        Me.ChkMarcaTodos = New System.Windows.Forms.CheckBox()
        Me.BtnSalir = New Janus.Windows.EditControls.UIButton()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.BtnSend = New Janus.Windows.EditControls.UIButton()
        Me.BtnImprimir = New Janus.Windows.EditControls.UIButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BtnConsultar = New Janus.Windows.EditControls.UIButton()
        Me.dtPicker = New System.Windows.Forms.DateTimePicker()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GridComplementoPago = New Janus.Windows.GridEX.GridEX()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.CmbSucursal = New Selling.StoreCombo()
        Me.GrpComplemento.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridComplementoPago, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpComplemento
        '
        Me.GrpComplemento.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpComplemento.Controls.Add(Me.ChkMarcaTodos)
        Me.GrpComplemento.Controls.Add(Me.BtnSalir)
        Me.GrpComplemento.Controls.Add(Me.PictureBox2)
        Me.GrpComplemento.Controls.Add(Me.BtnSend)
        Me.GrpComplemento.Controls.Add(Me.BtnImprimir)
        Me.GrpComplemento.Controls.Add(Me.Label3)
        Me.GrpComplemento.Controls.Add(Me.BtnConsultar)
        Me.GrpComplemento.Controls.Add(Me.dtPicker)
        Me.GrpComplemento.Controls.Add(Me.PictureBox1)
        Me.GrpComplemento.Controls.Add(Me.CmbSucursal)
        Me.GrpComplemento.Controls.Add(Me.Label1)
        Me.GrpComplemento.Controls.Add(Me.GridComplementoPago)
        Me.GrpComplemento.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpComplemento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpComplemento.ForeColor = System.Drawing.Color.Black
        Me.GrpComplemento.Location = New System.Drawing.Point(0, 0)
        Me.GrpComplemento.Name = "GrpComplemento"
        Me.GrpComplemento.Size = New System.Drawing.Size(784, 561)
        Me.GrpComplemento.TabIndex = 1
        Me.GrpComplemento.TabStop = False
        Me.GrpComplemento.Text = "Complemento de Pago"
        '
        'ChkMarcaTodos
        '
        Me.ChkMarcaTodos.Location = New System.Drawing.Point(7, 19)
        Me.ChkMarcaTodos.Name = "ChkMarcaTodos"
        Me.ChkMarcaTodos.Size = New System.Drawing.Size(76, 19)
        Me.ChkMarcaTodos.TabIndex = 56
        Me.ChkMarcaTodos.Text = "Todos"
        '
        'BtnSalir
        '
        Me.BtnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSalir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSalir.Image = CType(resources.GetObject("BtnSalir.Image"), System.Drawing.Image)
        Me.BtnSalir.Location = New System.Drawing.Point(398, 518)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(90, 37)
        Me.BtnSalir.TabIndex = 8
        Me.BtnSalir.Text = "&Salir"
        Me.BtnSalir.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnSalir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(569, 19)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(18, 20)
        Me.PictureBox2.TabIndex = 41
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'BtnSend
        '
        Me.BtnSend.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSend.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSend.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSend.Icon = CType(resources.GetObject("BtnSend.Icon"), System.Drawing.Icon)
        Me.BtnSend.Location = New System.Drawing.Point(494, 518)
        Me.BtnSend.Name = "BtnSend"
        Me.BtnSend.Size = New System.Drawing.Size(90, 37)
        Me.BtnSend.TabIndex = 20
        Me.BtnSend.Text = "Enviar"
        Me.BtnSend.ToolTipText = "Envio por correo electrónico"
        Me.BtnSend.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnImprimir
        '
        Me.BtnImprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnImprimir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnImprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnImprimir.Icon = CType(resources.GetObject("BtnImprimir.Icon"), System.Drawing.Icon)
        Me.BtnImprimir.Location = New System.Drawing.Point(592, 518)
        Me.BtnImprimir.Name = "BtnImprimir"
        Me.BtnImprimir.Size = New System.Drawing.Size(90, 37)
        Me.BtnImprimir.TabIndex = 19
        Me.BtnImprimir.Text = "Imprimir"
        Me.BtnImprimir.ToolTipText = "Reimpresión de Facturas"
        Me.BtnImprimir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(532, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 16)
        Me.Label3.TabIndex = 53
        Me.Label3.Text = "Periodo"
        '
        'BtnConsultar
        '
        Me.BtnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnConsultar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnConsultar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnConsultar.Icon = CType(resources.GetObject("BtnConsultar.Icon"), System.Drawing.Icon)
        Me.BtnConsultar.ImageSize = New System.Drawing.Size(28, 28)
        Me.BtnConsultar.Location = New System.Drawing.Point(688, 518)
        Me.BtnConsultar.Name = "BtnConsultar"
        Me.BtnConsultar.Size = New System.Drawing.Size(90, 37)
        Me.BtnConsultar.TabIndex = 9
        Me.BtnConsultar.Text = "&Consultar"
        Me.BtnConsultar.ToolTipText = "Mostrar factura seleccionada"
        Me.BtnConsultar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'dtPicker
        '
        Me.dtPicker.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtPicker.CustomFormat = "MMMM yyyy"
        Me.dtPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtPicker.Location = New System.Drawing.Point(592, 17)
        Me.dtPicker.Name = "dtPicker"
        Me.dtPicker.ShowUpDown = True
        Me.dtPicker.Size = New System.Drawing.Size(185, 22)
        Me.dtPicker.TabIndex = 52
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(144, 19)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(19, 20)
        Me.PictureBox1.TabIndex = 39
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'Label1
        '
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(101, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 14)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Sucursal"
        '
        'GridComplementoPago
        '
        Me.GridComplementoPago.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridComplementoPago.ColumnAutoResize = True
        Me.GridComplementoPago.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridComplementoPago.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridComplementoPago.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridComplementoPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.GridComplementoPago.GroupByBoxVisible = False
        Me.GridComplementoPago.Location = New System.Drawing.Point(7, 45)
        Me.GridComplementoPago.Name = "GridComplementoPago"
        Me.GridComplementoPago.RecordNavigator = True
        Me.GridComplementoPago.Size = New System.Drawing.Size(770, 467)
        Me.GridComplementoPago.TabIndex = 2
        Me.GridComplementoPago.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'CmbSucursal
        '
        Me.CmbSucursal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbSucursal.BackColor = System.Drawing.SystemColors.Window
        Me.CmbSucursal.Location = New System.Drawing.Point(169, 15)
        Me.CmbSucursal.Name = "CmbSucursal"
        Me.CmbSucursal.Size = New System.Drawing.Size(357, 24)
        Me.CmbSucursal.TabIndex = 36
        '
        'FrmComplementoPago
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.GrpComplemento)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(625, 464)
        Me.Name = "FrmComplementoPago"
        Me.Text = "Complemento de Pago"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GrpComplemento.ResumeLayout(False)
        Me.GrpComplemento.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridComplementoPago, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region


    Public Mes As Integer
    Public Periodo As Integer
    Private VersionCF As String

    Private iRegimenFiscal As Integer
    Private ALMClave As String = ""
    Private InterfazSalida, sMailCliente, PathXML, PathPDF, MailAdress, DisplayName, MailUser, MailPassword, HostSMTP, regimenFiscal As String
    Private MailPort As Integer
    Private MailSSL As Boolean
    Private correo As MailMessage
    Private adjuntos As Attachment
    Private autenticar As NetworkCredential
    Private envio As SmtpClient
    Private dato As FileStream

    Private alerta(0) As PictureBox
    Private reloj As parpadea
    Private Impresora As String
    Private bLoad As Boolean = False

    Private TipoCF As Integer

    Private dtPAC As DataTable

    Private sSUCClave As String
    Private dtComplementoPago As DataTable

    Public Sub refrescaGrid()

        If CmbSucursal.SelectedValue Is Nothing Then
            sSUCClave = ""
        Else
            sSUCClave = CmbSucursal.SelectedValue
        End If

        If Not dtComplementoPago Is Nothing Then
            dtComplementoPago.Dispose()
        End If

        Dim fechainicio As New DateTime(Periodo, Mes, 1)
        Dim fechafin As DateTime = fechainicio.AddMonths(1).AddDays(-1)


        Cursor.Current = Cursors.WaitCursor
        dtComplementoPago = ModPOS.Recupera_Tabla("st_recupera_complementoPago", "@Inicio", fechainicio, "@Fin", fechafin.AddHours(23.9999), "@COMClave", ModPOS.CompanyActual)
        GridComplementoPago.DataSource = dtComplementoPago
        GridComplementoPago.RetrieveStructure(True)
        GridComplementoPago.RootTable.Columns("ABNClave").Visible = False
        GridComplementoPago.RootTable.Columns("email").Visible = False
        GridComplementoPago.AutoSizeColumns()

        GridComplementoPago.RootTable.Columns("Importe").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        GridComplementoPago.RootTable.Columns("Importe").Width = 75
        GridComplementoPago.RootTable.Columns("Tipo").Width = 63
        GridComplementoPago.RootTable.Columns("Fecha").Width = 65
        GridComplementoPago.RootTable.Columns("Folio").Width = 109
        GridComplementoPago.RootTable.Columns("Metodo").Width = 70
        GridComplementoPago.RootTable.Columns("Clave").Width = 75
        GridComplementoPago.RootTable.Columns("Razón Social").Width = 200
        GridComplementoPago.RootTable.Columns("UUID").Width = 180








        Cursor.Current = Cursors.Default


        'GridComplementoPago.RootTable.Columns("Total").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        'GridComplementoPago.RootTable.Columns("Saldo").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far


        'Dim fc As Janus.Windows.GridEX.GridEXFormatCondition
        'fc = New Janus.Windows.GridEX.GridEXFormatCondition(GridComplementoPago.RootTable.Columns("Estado"), Janus.Windows.GridEX.ConditionOperator.Equal, "Cancelada")
        'fc.FormatStyle.ForeColor = System.Drawing.Color.Red
        'GridComplementoPago.RootTable.FormatConditions.Add(fc)

    End Sub

    Private Sub FrmMtoComplementoPago_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Cursor.Current = Cursors.WaitCursor

        Me.StartPosition = FormStartPosition.CenterScreen

        alerta(0) = Me.PictureBox1

        If dtPicker.Value.Day > 28 Then
            Dim Dias As Integer = dtPicker.Value.Day
            dtPicker.Value = dtPicker.Value.AddDays(28 - Dias)
        End If

        Periodo = dtPicker.Value.Year()
        Mes = dtPicker.Value.Month

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


        Dim dtParam, dtmsg As DataTable
        dtParam = ModPOS.Recupera_Tabla("sp_recupera_parametro", "@COMClave", ModPOS.CompanyActual)
        With Me
            Dim i As Integer
            For i = 0 To dtParam.Rows.Count - 1
                Select Case CStr(dtParam.Rows(i)("PARClave"))
                    Case "DirXML"
                        PathXML = dtParam.Rows(i)("Valor")
                    Case "MailAdress"
                        MailAdress = dtParam.Rows(i)("Valor")
                    Case "DisplayName"
                        DisplayName = dtParam.Rows(i)("Valor")
                    Case "MailUser"
                        MailUser = dtParam.Rows(i)("Valor")
                    Case "MailPassword"
                        MailPassword = dtParam.Rows(i)("Valor")
                    Case "HostSMTP"
                        HostSMTP = dtParam.Rows(i)("Valor")
                    Case "MailPort"
                        MailPort = IIf(IsNumeric(dtParam.Rows(i)("Valor")) = True, CInt(dtParam.Rows(i)("Valor")), 0)
                    Case "MailSSL"
                        MailSSL = IIf(dtParam.Rows(i)("Valor") = 1, True, False)
                    Case "TipoCF"
                        TipoCF = CInt(dtParam.Rows(i)("Valor"))
                    Case "InterfazSalida"
                        InterfazSalida = IIf(dtParam.Rows(i)("Valor").GetType.Name = "DBNull", "", dtParam.Rows(i)("Valor"))
                    Case "RegimenFiscal"
                        iRegimenFiscal = CInt(dtParam.Rows(i)("Valor"))
                    Case "VersionCF"

                        dtmsg = Recupera_Tabla("sp_recupera_valorref", "@Tabla", "CFD", "@Campo", "Version", "@estado", CInt(dtParam.Rows(i)("Valor")))
                        VersionCF = dtmsg.Rows(0)("Descripcion")
                        dtmsg.Dispose()
                End Select
            Next
        End With
        dtParam.Dispose()

        dtmsg = Recupera_Tabla("sp_recupera_valor", "@Tabla", "CFD", "@Campo", "RegimenFiscal", "@Valor", iRegimenFiscal)
        If VersionCF = "3.3" Then
            regimenFiscal = dtmsg.Rows(0)("ClaveSAT")
        Else
            regimenFiscal = dtmsg.Rows(0)("Descripcion")
        End If
        dtmsg.Dispose()



        If TipoCF = 2 Then
            dtPAC = ModPOS.Recupera_Tabla("sp_recupera_PAC", "@COMClave", ModPOS.CompanyActual)
        End If


        refrescaGrid()

        Cursor.Current = Cursors.Default
        bLoad = True


    End Sub

   
    Private Sub GridComplementoPago_CellValueChanged(sender As Object, e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridComplementoPago.CellValueChanged
        dtComplementoPago.AcceptChanges()

        GridComplementoPago.Refresh()
    End Sub

    Private Sub GridComplementoPago_CurrentCellChanged(sender As Object, e As EventArgs) Handles GridComplementoPago.CurrentCellChanged
        If Not GridComplementoPago.CurrentColumn Is Nothing Then
            If GridComplementoPago.CurrentColumn.Caption = "Marca" Then
                GridComplementoPago.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
            Else
                GridComplementoPago.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
            End If
        End If
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

    Private Sub FrmMtoComplementoPago_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.ComplementoPago.Dispose()
        ModPOS.ComplementoPago = Nothing
    End Sub


    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub BtnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImprimir.Click
        Dim sImpresora As String = ""
        Dim iCopias As Integer

        If PrintDialog1.ShowDialog() = DialogResult.OK Then
            sImpresora = PrintDialog1.PrinterSettings.PrinterName
            iCopias = PrintDialog1.PrinterSettings.Copies
        Else
            Exit Sub
        End If

        Dim foundRows() As DataRow
        foundRows = dtComplementoPago.Select("Marca ='True'")
        If foundRows.GetLength(0) > 0 Then
            Dim i As Integer
            'Imprime CFDI
            For i = 0 To foundRows.GetUpperBound(0)



                imprimirCfdiPago(foundRows(i)("ABNClave"), foundRows(i)("Tipo"), iCopias, sImpresora)
                foundRows(i)("Marca") = False
            Next
            ChkMarcaTodos.Checked = False
        Else
            MessageBox.Show("¡No se ha seleccionado un Documento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If


    End Sub

    Private Sub BtnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSend.Click
        If validaForm() Then



            Dim foundRows() As DataRow


            foundRows = dtComplementoPago.Select("Marca ='True'")
            If foundRows.GetLength(0) > 0 Then

                If MailAdress = "" OrElse MailUser = "" OrElse MailPassword = "" OrElse HostSMTP = "" OrElse MailPort = 0 Then
                    MessageBox.Show("No se ha configurado una cuenta de correo para envio de información en el Menú de Configuración\Compañia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If


                Try
                    If Not System.IO.Directory.Exists(PathXML) Then
                        MessageBox.Show("El directorio " & PathXML & " para guardar los XML no existe o no se puede tener acceso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                Catch ex As Exception
                End Try

                Dim PathPDF, sPathXML As String
                Dim i, j As Integer
                Dim frmStatusMessage As New frmStatus

                Dim MonRef, MonDesc As String
                Dim TipoCambio, total As Double
                Dim dt As DataTable
                Dim eMailCte As String = ""
                Dim sMailCliente As String = ""
                Dim sClienteActual As String = ""

                For i = 0 To foundRows.GetUpperBound(0)

                    If sClienteActual <> foundRows(i)("Clave") Then
                        eMailCte = foundRows(i)("email").ToString.Trim
                        sClienteActual = foundRows(i)("Clave")
                    End If

                    If eMailCte = "" OrElse eMailCte <> sMailCliente Then
                        Dim m As New FrmCorreo
                        m.eMail = eMailCte
                        m.Folio = " Folio: " & foundRows(i)("Folio") & " Cliente: " & foundRows(i)("Clave")
                        m.ShowDialog()
                        If m.DialogResult = System.Windows.Forms.DialogResult.OK Then
                            eMailCte = m.Correo
                        End If
                        m.Dispose()
                    End If

                    If eMailCte <> "" Then
                        PathPDF = pathActual & "Temp\" & foundRows(i)("Folio") & ".PDF"

                        dt = Recupera_Tabla("sp_recupera_mondoc", "@Tipo", IIf(foundRows(i)("Tipo") = "Aplicación", "A", "P"), "@Documento", foundRows(i)("ABNClave"))
                        TipoCambio = dt.Rows(0)("TipoCambio")
                        MonRef = dt.Rows(0)("Referencia")
                        MonDesc = dt.Rows(0)("Descripcion")
                        total = dt.Rows(0)("Importe")
                        dt.Dispose()

                        Dim OpenReport As New Report
                        Dim pvtaDataSet As New DataSet
                        pvtaDataSet.DataSetName = "pvtaDataSet"

                        If foundRows(i)("Tipo") <> "Aplicación" Then
                            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_encabezado_abono", "@ABNClave", foundRows(i)("ABNClave")))
                            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_sello_pago", "@ABNClave", foundRows(i)("ABNClave")))
                        End If


                        If foundRows(i)("Tipo") = "Anticipo" Then
                            'Anticipo
                            Dim Base As Decimal = Math.Round(total / 1.16, 2)
                            Dim IVA As Decimal = Math.Round(Base * 0.16, 2)

                            OpenReport.PrintPDF("CRAnticipoCFDI.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal((Base + IVA), 2), MonDesc, MonRef).ToUpper, PathPDF)

                        ElseIf foundRows(i)("Tipo") = "Pago" Then

                            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_recupera_relacionado", "@DOCClave", foundRows(i)("ABNClave"), "@Tipo", "P"))
                            OpenReport.PrintPDF("CRPagoCFDI.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal(total, 2), MonDesc, MonRef).ToUpper, PathPDF)
                        Else


                           
                            
                            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_encabezado_aplicacion", "@ANTClave", foundRows(i)("ABNClave")))
                            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_sello_anticipo", "@ANTClave", foundRows(i)("ABNClave")))

                            Dim Base As Decimal = Math.Round(total / 1.16, 2)
                            Dim IVA As Decimal = Math.Round(Base * 0.16, 2)
                            OpenReport.PrintPDF("CRAplicacionCFDI.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal((Base + IVA), 2), MonDesc, MonRef).ToUpper, PathPDF)

                        End If




                        Dim sFolio As String

                        sFolio = foundRows(i)("Folio").ToString

                        If foundRows(i)("Tipo") = "Aplicación" Then
                            sFolio &= "_A"
                        End If

                        sPathXML = PathXML
                        If sPathXML.Length > 3 AndAlso sPathXML.Substring(sPathXML.Length - 1, 1) <> "\" Then
                            sPathXML &= "\"
                        End If

                        sPathXML &= CDate(foundRows(i)("Fecha")).Year.ToString & "\" & CDate(foundRows(i)("Fecha")).Month.ToString & "\" & CDate(foundRows(i)("Fecha")).Day.ToString & "\" & sFolio & ".xml"



                        If Not System.IO.File.Exists(sPathXML) Then
                            If PathXML.Length <= 3 Then
                                sPathXML = PathXML & foundRows(i)("Folio") & ".xml"
                            Else
                                sPathXML = PathXML & "\" & foundRows(i)("Folio") & ".xml"
                            End If

                        End If

                        If Not System.IO.File.Exists(PathPDF) Then
                            MessageBox.Show("Ha ocurrido un error al generar el archivo: " & PathPDF, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        ElseIf Not System.IO.File.Exists(sPathXML) Then
                            MessageBox.Show("Ha ocurrido un error, No se ha encontrado el archivo: " & sPathXML, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Else
                            Try
                                correo = New MailMessage
                                autenticar = New NetworkCredential
                                envio = New SmtpClient
                                If foundRows(i)("Tipo") = "Anticipo" Then
                                    correo.Body = "Estimado Cliente, le hacemos llegar por este medio la Representación Impresa de su Anticipo (*.PDF) y el Comprobante Fiscal Digital (*.XML), Agradecemos su Preferencia y Esperamos Verlo Pronto. Saludos."
                                    correo.Subject = "Anticipo " & CStr(foundRows(i)("Folio"))

                                Else
                                    correo.Body = "Estimado Cliente, le hacemos llegar por este medio la Representación Impresa de su Complemento de Pago (*.PDF) y el Comprobante Fiscal Digital (*.XML), Agradecemos su Preferencia y Esperamos Verlo Pronto. Saludos."
                                    correo.Subject = "Pago " & CStr(foundRows(i)("Folio"))

                                End If


                                correo.IsBodyHtml = True
                                correo.To.Clear()
                                correo.CC.Clear()
                                correo.Bcc.Clear()

                                sMailCliente = eMailCte

                                If sMailCliente.Split(",").Length >= 1 Then

                                    For j = 0 To sMailCliente.Split(",").Length - 1
                                        If sMailCliente.Split(",")(j) <> "" Then
                                            correo.To.Add(sMailCliente.Split(",")(j))
                                        End If
                                    Next
                                Else
                                    correo.To.Add(sMailCliente)
                                End If


                                correo.From = New MailAddress(MailAdress, DisplayName)
                                envio.Credentials = New NetworkCredential(MailUser, MailPassword)
                                envio.Host = HostSMTP  '"smtp.live.com"
                                envio.Port = MailPort  '587
                                envio.EnableSsl = MailSSL 'True

                                frmStatusMessage.Show("Enviando correo electrónico...")


                                dato = New FileStream(sPathXML, FileMode.Open, FileAccess.Read)
                                adjuntos = New Attachment(dato, CStr(foundRows(i)("Folio")) & ".XML")
                                correo.Attachments.Add(adjuntos)


                                dato = New FileStream(PathPDF, FileMode.Open, FileAccess.Read)
                                adjuntos = New Attachment(dato, CStr(foundRows(i)("Folio")) & ".PDF")
                                correo.Attachments.Add(adjuntos)

                                envio.Send(correo)
                                correo.Dispose()

                                MessageBox.Show("El mensaje fue enviado correctamente a el destinatario", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)

                            Catch ex As Exception
                                MessageBox.Show(ex.Message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End Try

                            If Not dato Is Nothing Then
                                dato.Close()
                            End If

                            Try
                                My.Computer.FileSystem.DeleteFile(PathPDF, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
                            Catch ex As Exception
                                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
                            End Try
                            End If

                            foundRows(i)("Marca") = False
                    Else
                            MessageBox.Show("El cliente " & foundRows(i)("Clave").ToString & ", no cuenta con dirección de correo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                Next
                frmStatusMessage.Dispose()
                ChkMarcaTodos.Checked = False

            Else
                MessageBox.Show("Para reenviar, debe marcar por lo menos un registro", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub dtPicker_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtPicker.ValueChanged
        If bLoad = True AndAlso (Periodo <> dtPicker.Value.Year OrElse Mes <> dtPicker.Value.Month) Then
            Periodo = dtPicker.Value.Year
            Mes = dtPicker.Value.Month
            Me.refrescaGrid()
        End If
    End Sub

    Private Sub CmbSucursal_SelectedValueChanged(sender As Object, e As EventArgs) Handles CmbSucursal.SelectedValueChanged
        If bLoad Then
            If validaForm() Then
                refrescaGrid()
            End If
        End If
    End Sub

    Private Sub ChkMarcaTodos_CheckedChanged(sender As Object, e As EventArgs) Handles ChkMarcaTodos.CheckedChanged
        If dtComplementoPago.Rows.Count > 0 Then
            Dim i As Integer

            If ChkMarcaTodos.Checked Then

                For i = 0 To GridComplementoPago.GetDataRows.Length - 1
                    GridComplementoPago.GetDataRows(i).DataRow("Marca") = True
                Next
            Else
                For i = 0 To GridComplementoPago.GetDataRows.Length - 1
                    GridComplementoPago.GetDataRows(i).DataRow("Marca") = False
                Next
            End If

            dtComplementoPago.AcceptChanges()

            GridComplementoPago.Refresh()
        End If
    End Sub

    Private Sub GridComplementoPago_Click(sender As Object, e As EventArgs) Handles GridComplementoPago.Click
        If Not GridComplementoPago.CurrentColumn Is Nothing Then
            If GridComplementoPago.CurrentColumn.Caption <> "Marca" And Not GridComplementoPago.GetValue("Marca") Is Nothing Then
                If GridComplementoPago.GetValue("Marca") = False Then
                    GridComplementoPago.SetValue("Marca", True)
                Else
                    GridComplementoPago.SetValue("Marca", False)
                End If
                dtComplementoPago.AcceptChanges()
                GridComplementoPago.Refresh()

            End If
        End If
    End Sub


    Private Sub GridComplementoPago_DoubleClick(sender As Object, e As EventArgs) Handles GridComplementoPago.DoubleClick
        If Not GridComplementoPago.GetValue(0) Is Nothing Then
            Dim foundRows() As DataRow
            foundRows = dtComplementoPago.Select("ABNClave ='" & GridComplementoPago.GetValue("ABNClave") & "' and UUID = 'Pendiente' ")
            If foundRows.GetLength(0) > 0 Then
                Dim i As Integer

                Dim oCFD As New CFD


                Dim dt As DataTable

                dt = ModPOS.Recupera_Tabla("sp_recupera_certificadovigente", "@COMClave", ModPOS.CompanyActual)
                If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                    oCFD.noCertificado = dt.Rows(0)("Serie")
                    oCFD.Certificado64 = dt.Rows(0)("Certificado")
                    oCFD.LlaveFile = dt.Rows(0)("Llave")
                    oCFD.ContrasenaClave = dt.Rows(0)("Password")
                    dt.Dispose()
                Else
                    MessageBox.Show("No existen certificado vigente disponible para emitir algun documento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                'Verifica que exista el path
                Try
                    If Not System.IO.Directory.Exists(PathXML) Then
                        MessageBox.Show("El directorio " & PathXML & " para guardar los XML no existe o no se puede tener acceso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                Catch ex As Exception
                End Try

                'Verifica que exista el path del .Key
                Try
                    If Not System.IO.File.Exists(oCFD.LlaveFile) Then
                        MessageBox.Show("El archivo " & oCFD.LlaveFile & " no existe o se puede tener acceso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                Catch ex As Exception
                End Try


                oCFD.VersionCF = VersionCF
                oCFD.TipoCF = 2
                oCFD.regimenFiscal = regimenFiscal

                'Recupera información del Emisor

                dt = ModPOS.Recupera_Tabla("sp_recupera_compania", "@COMClave", ModPOS.CompanyActual)
                oCFD.eRazonSocial = dt.Rows(0)("Nombre")
                oCFD.eRFC = dt.Rows(0)("id_Fiscal")
                dt.Dispose()


                For i = 0 To foundRows.GetUpperBound(0)

                    If foundRows(i)("Tipo") = "Aplicación" Then
                        Dim sDOCClave As String = ""
                        Dim iTipoDocumento As Integer
                        Dim dtf As DataTable = Recupera_Tabla("st_obtiene_apl_anticipo", "@DOCClave", foundRows(i)("ABNClave"))
                        If dtf.Rows.Count > 0 Then
                            sDOCClave = dtf.Rows(0)("DOCClave")
                            iTipoDocumento = IIf(dtf.Rows(0)("TipoDocumento").GetType.Name = "DBNull", 2, dtf.Rows(0)("TipoDocumento"))

                        End If
                        dtf.Dispose()

                        TimbraEgreso(foundRows(i)("ABNClave"), sDOCClave, iTipoDocumento, PathXML, oCFD.VersionCF, dtPAC, oCFD.regimenFiscal, InterfazSalida, True, False)

                    Else
                        dt = ModPOS.Recupera_Tabla("st_encabezado_abono", "@ABNClave", foundRows(i)("ABNClave"))

                        Dim iTipoPAC As Integer
                        Dim sTipoComprobante As String

                        If dt.Rows.Count = 1 Then

                            oCFD.DOCClave = dt.Rows(0)("ABNClave")
                            oCFD.Folio = dt.Rows(0)("Clave")

                            sTipoComprobante = "I"
                            oCFD.Fecha = String.Format("{0:yyyy-MM-ddTHH:mm:ss}", dt.Rows(0)("MFechaHora"))

                            oCFD.sCodigoPostal = dt.Rows(0)("sCodigoPostal")
                            oCFD.RFC = dt.Rows(0)("rRFC")
                            oCFD.RazonSocial = dt.Rows(0)("rRazonSocial")
                            oCFD.Nacionalidad = dt.Rows(0)("Origen")
                            oCFD.NumRegIdTrib = dt.Rows(0)("NumRegIdTrib")
                            oCFD.metodoDePago = dt.Rows(0)("MetodoDePago")
                            oCFD.Moneda = dt.Rows(0)("Moneda")
                            oCFD.TipoCambio = dt.Rows(0)("TipoCambio")

                            oCFD.total = dt.Rows(0)("Importe")



                            oCFD.cadenaOriginal = generarCadenaOriginalPago(oCFD, dt.Rows(0)("Tipo"), sTipoComprobante)


                            oCFD.sello = ModPOS.generarSelloDigital(oCFD.cadenaOriginal, "", oCFD.Folio, oCFD.LlaveFile, oCFD.ContrasenaClave, oCFD.VersionCF)


                            iTipoPAC = crearXMLPago(1, dtPAC, PathXML, oCFD.Folio, oCFD.DOCClave, dt.Rows(0)("Tipo"), sTipoComprobante, "", oCFD, InterfazSalida)


                          

                        End If






                    End If
                    dt.Dispose()


                Next

                refrescaGrid()


            Else
                MessageBox.Show("¡No se ha seleccionado un Documento Pendiente de Certificar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        End If
    End Sub

    Private Sub BtnConsultar_Click(sender As Object, e As EventArgs) Handles BtnConsultar.Click

        ' Usa el metodo select para filtrar los registros seleccionados.
        Dim foundRows() As DataRow = dtComplementoPago.Select("Marca ='True'")
        If foundRows.GetLength(0) = 1 Then


            previewCfdiPago(foundRows(0)("ABNClave"), foundRows(0)("Tipo"))
         
     
        Else
            MessageBox.Show("Debe marcar solo 1 registro para poder visualizar el documento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

  
End Class
