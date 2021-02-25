Imports System.Net
Imports System.Net.Mail
Imports System.IO

Public Class FrmMtoNotaCargo
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
    Friend WithEvents GrpNotasCargo As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents BtnSalir As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnReimpresion As Janus.Windows.EditControls.UIButton
    Friend WithEvents GridNotasCargo As Janus.Windows.GridEX.GridEX
    Friend WithEvents BtnReCargo As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnSend As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnNotaCargo As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtPicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents CmbSucursal As Selling.StoreCombo
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMtoNotaCargo))
        Me.GrpNotasCargo = New System.Windows.Forms.GroupBox
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.BtnNotaCargo = New Janus.Windows.EditControls.UIButton
        Me.BtnSend = New Janus.Windows.EditControls.UIButton
        Me.dtPicker = New System.Windows.Forms.DateTimePicker
        Me.BtnReCargo = New Janus.Windows.EditControls.UIButton
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.BtnReimpresion = New Janus.Windows.EditControls.UIButton
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.BtnSalir = New Janus.Windows.EditControls.UIButton
        Me.CmbSucursal = New Selling.StoreCombo
        Me.Label1 = New System.Windows.Forms.Label
        Me.GridNotasCargo = New Janus.Windows.GridEX.GridEX
        Me.Label3 = New System.Windows.Forms.Label
        Me.GrpNotasCargo.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridNotasCargo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpNotasCargo
        '
        Me.GrpNotasCargo.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpNotasCargo.Controls.Add(Me.BtnCancelar)
        Me.GrpNotasCargo.Controls.Add(Me.BtnNotaCargo)
        Me.GrpNotasCargo.Controls.Add(Me.BtnSend)
        Me.GrpNotasCargo.Controls.Add(Me.dtPicker)
        Me.GrpNotasCargo.Controls.Add(Me.BtnReCargo)
        Me.GrpNotasCargo.Controls.Add(Me.PictureBox2)
        Me.GrpNotasCargo.Controls.Add(Me.BtnReimpresion)
        Me.GrpNotasCargo.Controls.Add(Me.PictureBox1)
        Me.GrpNotasCargo.Controls.Add(Me.BtnSalir)
        Me.GrpNotasCargo.Controls.Add(Me.CmbSucursal)
        Me.GrpNotasCargo.Controls.Add(Me.Label1)
        Me.GrpNotasCargo.Controls.Add(Me.GridNotasCargo)
        Me.GrpNotasCargo.Controls.Add(Me.Label3)
        Me.GrpNotasCargo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpNotasCargo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpNotasCargo.ForeColor = System.Drawing.Color.Black
        Me.GrpNotasCargo.Location = New System.Drawing.Point(0, 0)
        Me.GrpNotasCargo.Name = "GrpNotasCargo"
        Me.GrpNotasCargo.Size = New System.Drawing.Size(742, 473)
        Me.GrpNotasCargo.TabIndex = 1
        Me.GrpNotasCargo.TabStop = False
        Me.GrpNotasCargo.Text = "Notas de Cargo"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(248, 430)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 22
        Me.BtnCancelar.Text = "&Cancelar"
        Me.BtnCancelar.ToolTipText = "Cancela el documento seleccionado"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnNotaCargo
        '
        Me.BtnNotaCargo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnNotaCargo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnNotaCargo.Image = CType(resources.GetObject("BtnNotaCargo.Image"), System.Drawing.Image)
        Me.BtnNotaCargo.Location = New System.Drawing.Point(645, 430)
        Me.BtnNotaCargo.Name = "BtnNotaCargo"
        Me.BtnNotaCargo.Size = New System.Drawing.Size(90, 37)
        Me.BtnNotaCargo.TabIndex = 21
        Me.BtnNotaCargo.Text = "Nota de Cargo"
        Me.BtnNotaCargo.ToolTipText = "Crea una nueva Nota de Cargo"
        Me.BtnNotaCargo.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnSend
        '
        Me.BtnSend.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSend.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSend.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSend.Icon = CType(resources.GetObject("BtnSend.Icon"), System.Drawing.Icon)
        Me.BtnSend.Location = New System.Drawing.Point(347, 430)
        Me.BtnSend.Name = "BtnSend"
        Me.BtnSend.Size = New System.Drawing.Size(90, 37)
        Me.BtnSend.TabIndex = 20
        Me.BtnSend.Text = "Enviar"
        Me.BtnSend.ToolTipText = "Envio por correo electrónico"
        Me.BtnSend.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'dtPicker
        '
        Me.dtPicker.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtPicker.CustomFormat = "MMMM yyyy"
        Me.dtPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtPicker.Location = New System.Drawing.Point(550, 17)
        Me.dtPicker.Name = "dtPicker"
        Me.dtPicker.ShowUpDown = True
        Me.dtPicker.Size = New System.Drawing.Size(185, 22)
        Me.dtPicker.TabIndex = 52
        '
        'BtnReCargo
        '
        Me.BtnReCargo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnReCargo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnReCargo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnReCargo.Location = New System.Drawing.Point(447, 430)
        Me.BtnReCargo.Name = "BtnReCargo"
        Me.BtnReCargo.Size = New System.Drawing.Size(90, 37)
        Me.BtnReCargo.TabIndex = 19
        Me.BtnReCargo.Text = "Imprimir"
        Me.BtnReCargo.ToolTipText = "Reimpresión"
        Me.BtnReCargo.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(532, 19)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox2.TabIndex = 41
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'BtnReimpresion
        '
        Me.BtnReimpresion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnReimpresion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnReimpresion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnReimpresion.Icon = CType(resources.GetObject("BtnReimpresion.Icon"), System.Drawing.Icon)
        Me.BtnReimpresion.ImageSize = New System.Drawing.Size(28, 28)
        Me.BtnReimpresion.Location = New System.Drawing.Point(547, 430)
        Me.BtnReimpresion.Name = "BtnReimpresion"
        Me.BtnReimpresion.Size = New System.Drawing.Size(90, 37)
        Me.BtnReimpresion.TabIndex = 9
        Me.BtnReimpresion.Text = "&Consultar"
        Me.BtnReimpresion.ToolTipText = "Mostrar nota de cargo seleccionada"
        Me.BtnReimpresion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(175, 19)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(13, 14)
        Me.PictureBox1.TabIndex = 39
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'BtnSalir
        '
        Me.BtnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSalir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSalir.Image = CType(resources.GetObject("BtnSalir.Image"), System.Drawing.Image)
        Me.BtnSalir.Location = New System.Drawing.Point(147, 430)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(90, 37)
        Me.BtnSalir.TabIndex = 8
        Me.BtnSalir.Text = "&Salir"
        Me.BtnSalir.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnSalir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'CmbSucursal
        '
        Me.CmbSucursal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbSucursal.BackColor = System.Drawing.SystemColors.Window
        Me.CmbSucursal.Location = New System.Drawing.Point(79, 15)
        Me.CmbSucursal.Name = "CmbSucursal"
        Me.CmbSucursal.Size = New System.Drawing.Size(315, 24)
        Me.CmbSucursal.TabIndex = 36
        '
        'Label1
        '
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(7, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 14)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Sucursal"
        '
        'GridNotasCargo
        '
        Me.GridNotasCargo.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridNotasCargo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridNotasCargo.ColumnAutoResize = True
        Me.GridNotasCargo.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridNotasCargo.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridNotasCargo.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridNotasCargo.Location = New System.Drawing.Point(7, 45)
        Me.GridNotasCargo.Name = "GridNotasCargo"
        Me.GridNotasCargo.RecordNavigator = True
        Me.GridNotasCargo.Size = New System.Drawing.Size(728, 380)
        Me.GridNotasCargo.TabIndex = 2
        Me.GridNotasCargo.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(488, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 16)
        Me.Label3.TabIndex = 53
        Me.Label3.Text = "Periodo"
        '
        'FrmMtoNotaCargo
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(742, 473)
        Me.Controls.Add(Me.GrpNotasCargo)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(625, 464)
        Me.Name = "FrmMtoNotaCargo"
        Me.Text = "Notas de Cargo"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GrpNotasCargo.ResumeLayout(False)
        Me.GrpNotasCargo.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridNotasCargo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region


    Public Mes As Integer
    Public Periodo As Integer

    Private sCargoSelected As String
    Private sFolio As String
    Private ALMClave As String = ""
    Private sMailCliente, PathXML, PathPDF, MailAdress, DisplayName, MailUser, MailPassword, HostSMTP As String
    Private MailPort As Integer
    Private MailSSL As Boolean

    Private sCTEClave As String
    Private iTipoCF As Integer
    Private sUUID As String
    Private sRFC As String

    Private dTotal, dSaldo As Double
    Private alerta(0) As PictureBox
    Private reloj As parpadea
    Private Impresora As String
    Private bLoad As Boolean = False
    Private Estado As String

    Private correo As MailMessage
    Private adjuntos As Attachment
    Private autenticar As NetworkCredential
    Private envio As SmtpClient
    Private dato As FileStream


    Private TipoCF As Integer
    ' Private ServidorCancelacion, ServidorTimbrado, Customerkey As String

    Private dtPAC As DataTable

    Private Autoriza As String


    Public Sub refrescaGrid()

        Dim sSUCClave As String

        If CmbSucursal.SelectedValue Is Nothing Then
            sSUCClave = ""
        Else
            sSUCClave = CmbSucursal.SelectedValue
        End If

        ModPOS.ActualizaGrid(False, Me.GridNotasCargo, "sp_muestra_notacargo", "@Sucursal", sSUCClave, "@Periodo", Periodo, "@Mes", Mes)
        Me.GridNotasCargo.RootTable.Columns("CARClave").Visible = False
        Me.GridNotasCargo.RootTable.Columns("TipoCF").Visible = False
        Me.GridNotasCargo.RootTable.Columns("RFC").Visible = False
        Me.GridNotasCargo.RootTable.Columns("CTEClave").Visible = False

        If TipoCF = 2 Then
            Me.GridNotasCargo.RootTable.Columns("uuid").Visible = True
        Else
            Me.GridNotasCargo.RootTable.Columns("uuid").Visible = False
        End If

        GridNotasCargo.RootTable.Columns("Total").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        GridNotasCargo.RootTable.Columns("Saldo").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far


        Dim fc As Janus.Windows.GridEX.GridEXFormatCondition
        fc = New Janus.Windows.GridEX.GridEXFormatCondition(GridNotasCargo.RootTable.Columns("Estado"), Janus.Windows.GridEX.ConditionOperator.Equal, "Cancelada")
        fc.FormatStyle.ForeColor = System.Drawing.Color.Red
        GridNotasCargo.RootTable.FormatConditions.Add(fc)

    End Sub

    Private Sub FrmMtoNotaCargo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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


        Dim dtParam As DataTable

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
                End Select
            Next
        End With
        dtParam.Dispose()

        If TipoCF = 2 Then
            dtPAC = ModPOS.Recupera_Tabla("sp_recupera_PAC", "@COMClave", ModPOS.CompanyActual)
        End If


        refrescaGrid()

        Cursor.Current = Cursors.Default
        bLoad = True


    End Sub

    Private Sub GridNotasCargo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridNotasCargo.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.BtnReimpresion.PerformClick()
        End If
    End Sub

    Private Sub GridNotasCargo_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridNotasCargo.SelectionChanged
        If Not GridNotasCargo.GetValue(0) Is Nothing Then
            sCargoSelected = GridNotasCargo.GetValue("CARClave")
            dTotal = GridNotasCargo.GetValue("Total")
            dSaldo = GridNotasCargo.GetValue("Saldo")
            sFolio = GridNotasCargo.GetValue("Folio")
            sUUID = IIf(GridNotasCargo.GetValue("uuid").GetType.Name = "DBNull", "", GridNotasCargo.GetValue("uuid"))
            sRFC = GridNotasCargo.GetValue("RFC")
            iTipoCF = IIf(GridNotasCargo.GetValue("TipoCF").GetType.Name = "DBNull", 1, GridNotasCargo.GetValue("TipoCF"))
            sCTEClave = GridNotasCargo.GetValue("CTEClave")
            Estado = GridNotasCargo.GetValue("Estado")
        Else
            sCargoSelected = ""
            sFolio = ""
            dTotal = 0
            dSaldo = 0
            iTipoCF = 0
            sRFC = ""
            sUUID = ""
            sCTEClave = ""
            Estado = ""
        End If
    End Sub

    Private Sub GridNotasCargo_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridNotasCargo.DoubleClick
        If Not GridNotasCargo.GetValue(0) Is Nothing Then
            If sCargoSelected <> "" Then
                Dim sCARClave As String = sCargoSelected
                If Estado = "Pendiente" Then
                    Dim iTipoPAC As Integer
                    If MessageBox.Show("El documento seleccionado se encuentra pendiente de Certificación, ¿deseas intentar nuevamente?", "Pregunta", MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then


                        iTipoPAC = ModPOS.crearXML(2, dtPAC, PathXML, sFolio, sCARClave, "ingreso")

                        If iTipoPAC <> 0 Then
                            Me.refrescaGrid()
                            Imprimir(sCARClave)
                        End If
                    Else
                        Imprimir(sCARClave)
                    End If 'Desea Certificacion
                Else
                    Imprimir(sCARClave)
                End If 'Estado Pendiente
            Else
                MessageBox.Show("¡No se ha seleccionado alguna nota de cargo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If 'Seleccion de cargos
        End If 'Grid
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

    Private Sub FrmMtoNotaCargo_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.MtoNotaCargo.Dispose()
        ModPOS.MtoNotaCargo = Nothing
    End Sub


    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub


    Private Sub BtnReimpresion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReimpresion.Click
        If sCargoSelected <> "" Then
            Imprimir(sCargoSelected)
      End If
    End Sub

    Private Sub Imprimir(ByVal sCARClave As String)

        Dim MonRef, MonDesc As String
        Dim TipoCambio As Double
        Dim dt As DataTable

        dt = Recupera_Tabla("sp_recupera_mondoc", "@Tipo", "C", "@Documento", sCARClave)
        TipoCambio = dt.Rows(0)("TipoCambio")
        MonRef = dt.Rows(0)("Referencia")
        MonDesc = dt.Rows(0)("Descripcion")
        dt.Dispose()

        Dim OpenReport As New Report
        Dim pvtaDataSet As New DataSet
        pvtaDataSet.DataSetName = "pvtaDataSet"

        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_logo_compania", "@COMClave", ModPOS.CompanyActual))
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_encabezado_cargo", "@CARClave", sCARClave))
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_detalle_cargo", "@CARClave", sCARClave))
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_impuestos_cargo", "@CARClave", sCARClave))
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_cargo", "@CARClave", sCARClave))
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_metodopago_cargo", "@CARClave", sCARClave))

        OpenReport.PrintPreview("Nota de Cargo", "CRNotaCargo.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(dTotal / TipoCambio, 2), MonDesc, MonRef).ToUpper)


    End Sub

    Private Sub Combo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbSucursal.SelectedIndexChanged
        If bLoad Then
            If validaForm() Then
                refrescaGrid()
            End If
        End If
    End Sub

    Private Sub BtnReFac_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReCargo.Click
        If validaForm() Then
            Dim a As New FrmReimpresion
            a.TipoReimpresion = "NotaCargo"
            a.Impresora = ""
            a.SUCClave = CmbSucursal.SelectedValue
            a.ShowDialog()
            a.Dispose()
        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub BtnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSend.Click
        If validaForm() Then
            If sCargoSelected <> "" Then
                Dim FileXML As String = ""
                Dim dt As DataTable
                'Recupera correo electronico

                dt = ModPOS.Recupera_Tabla("sp_recupera_mail", "@Clave", sCargoSelected, "@Tipo", 6)
                sMailCliente = dt.Rows(0)("Email")
                dt.Dispose()

                If sMailCliente = "" Then
                    MessageBox.Show("El cliente no cuenta con una dirección de Correo Electrónica Configurada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                'Recupera CompanyParam

                If MailAdress = "" OrElse MailUser = "" OrElse MailPassword = "" OrElse HostSMTP = "" OrElse MailPort = 0 Then
                    MessageBox.Show("No se ha configurado una cuenta de correo para envio de información en el Menú de Configuración\Compañia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If


                'Verifica que exista el path

                If iTipoCF <= 2 Then
                    Try
                        If Not System.IO.Directory.Exists(PathXML) Then
                            MessageBox.Show("El directorio " & PathXML & " para guardar los XML no existe o no se puede tener acceso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If
                    Catch ex As Exception
                    End Try

                    If PathXML.Length <= 3 Then
                        FileXML = PathXML & sFolio & ".xml"
                    Else
                        FileXML = PathXML & "\" & sFolio & ".xml"
                    End If

                    If Not System.IO.File.Exists(FileXML) Then
                        MessageBox.Show("No fue posible encontrar el archivo: " & FileXML, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If

                End If

                PathPDF = pathActual & "Temp\" & sFolio & ".PDF"

                'Genera PDF

                Dim MonRef, MonDesc As String
                Dim TipoCambio As Double

                dt = Recupera_Tabla("sp_recupera_mondoc", "@Tipo", "C", "@Documento", sCargoSelected)
                TipoCambio = dt.Rows(0)("TipoCambio")
                MonRef = dt.Rows(0)("Referencia")
                MonDesc = dt.Rows(0)("Descripcion")
                dt.Dispose()

                Dim OpenReport As New Report
                Dim pvtaDataSet As New DataSet
                pvtaDataSet.DataSetName = "pvtaDataSet"

                pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_logo_compania", "@COMClave", ModPOS.CompanyActual))
                pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_encabezado_cargo", "@CARClave", sCargoSelected))
                pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_detalle_cargo", "@CARClave", sCargoSelected))
                pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_impuestos_cargo", "@CARClave", sCargoSelected))
                pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_cargo", "@CARClave", sCargoSelected))
                pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_metodopago_cargo", "@CARClave", sCargoSelected))


                OpenReport.PrintPDF("CRNotaCargo.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(dTotal / TipoCambio, 2), MonDesc, MonRef).ToUpper, PathPDF)

                If Not System.IO.File.Exists(PathPDF) Then
                    MessageBox.Show("Ha ocurrido un error al generar el archivo: " & PathPDF, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                'Envia Correo

                Dim frmStatusMessage As New frmStatus
                Try
                    correo = New MailMessage
                    autenticar = New NetworkCredential
                    envio = New SmtpClient

                    correo.Body = "Estimado Cliente, le hacemos llegar por este medio la Representación Impresa de su Nota de Cargo (*.PDF) y el Comprobante Fiscal Digital (*.XML), Agraciadecemos su Preferencia y Esperamos Verlo Pronto. Saludos."

                    correo.Subject = "Nota de Cargo " & sFolio
                    correo.IsBodyHtml = True
                    correo.To.Clear()
                    correo.CC.Clear()
                    correo.Bcc.Clear()


                    If sMailCliente.Split(",").Length >= 1 Then
                        Dim i As Integer
                        For i = 0 To sMailCliente.Split(",").Length - 1
                            correo.To.Add(sMailCliente.Split(",")(i))
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

                    If iTipoCF <= 2 Then
                        dato = New FileStream(FileXML, FileMode.Open, FileAccess.Read)
                        adjuntos = New Attachment(dato, sFolio & ".XML")
                        correo.Attachments.Add(adjuntos)
                    End If


                    dato = New FileStream(PathPDF, FileMode.Open, FileAccess.Read)
                    adjuntos = New Attachment(dato, sFolio & ".PDF")
                    correo.Attachments.Add(adjuntos)


                    envio.Send(correo)
                    correo.Dispose()

                    MessageBox.Show("El mensaje fue enviado correctamente a el destinatario", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    frmStatusMessage.Dispose()
                Catch ex As Exception
                    frmStatusMessage.Dispose()
                    MessageBox.Show(ex.Message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

                dato.Close()

                Try
                    My.Computer.FileSystem.DeleteFile(PathPDF, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
                Catch ex As Exception
                    MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
                End Try

            Else
                MessageBox.Show("¡No se ha seleccionado una Nota de Cargo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub BtnNotaCargo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNotaCargo.Click
        If validaForm() Then
            Dim dt As DataTable
            dt = ModPOS.SiExisteRecupera("sp_filtra_caja", "@Sucursal", CmbSucursal.SelectedValue)

            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                dt.Dispose()

                If ModPOS.NotaCargo Is Nothing Then
                    ModPOS.NotaCargo = New FrmNotaCargo
                    ModPOS.NotaCargo.SUCClave = CmbSucursal.SelectedValue
                End If

                ModPOS.NotaCargo.StartPosition = FormStartPosition.CenterScreen
                ModPOS.NotaCargo.Show()

                If Not ModPOS.NotaCargo Is Nothing Then
                    ModPOS.NotaCargo.BringToFront()
                End If
            Else
                MessageBox.Show("El Almacén o Sucursal seleccionada no tiene una Caja disponible para Nota de Cargo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        If sCargoSelected <> "" Then

            If Estado = "Cancelada" Then
                MessageBox.Show("El documento seleccionado ya se encuentra Cancelado")
                Exit Sub
            End If


            'Valida que no tenga abonos aplicados, que el total sea igual al saldo

            If dTotal <> dSaldo Then
                MessageBox.Show("No es posible cancelar el documento seleccionado ya que cuenta con abonos o notas de credito aplicadas", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        
            If CmbSucursal.SelectedValue Is Nothing Then
                MessageBox.Show("La Sucursal no es valida o es requerida")
                Exit Sub
            End If

            Dim dt As DataTable

            dt = Recupera_Tabla("sp_recupera_almcargo", "@CARClave", sCargoSelected)
            ALMClave = dt.Rows(0)("ALMClave")
            dt.Dispose()

            Select Case MessageBox.Show("¿Esta seguro de Cancelar el documento " & sFolio & "?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                Case DialogResult.Yes
                    Dim a As New MeAutorizacion

                    a.Sucursal = CmbSucursal.SelectedValue
                    a.MontodeAutorizacion = dTotal
                    a.StartPosition = FormStartPosition.CenterScreen
                    a.ShowDialog()
                    If a.DialogResult = DialogResult.OK Then
                        If a.Autorizado Then
                            Autoriza = a.Autoriza
                            If TipoCF = 2 AndAlso Estado = "Activa" Then

                                Dim eRFC, sCTEClave As String
                                Dim dTotal As Double
                                dt = ModPOS.Recupera_Tabla("sp_encabezado_cargo", "@CARClave", sCargoSelected)
                                eRFC = dt.Rows(0)("cRFC")
                                sCTEClave = dt.Rows(0)("CTEClave")
                                dTotal = dt.Rows(0)("total")
                                dt.Dispose()

                                If ModPOS.cancelarXML(dtPAC, sFolio, sUUID, eRFC) = False Then
                                    Exit Sub
                                End If

                            End If

                            ModPOS.Ejecuta("sp_cancela_notacargo", "@CARClave", sCargoSelected)

                            'Actualiza el Saldo del Documento
                            ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 2, "@Cliente", sCTEClave, "@Importe", dTotal)

                            refrescaGrid()

                        End If
                    End If
            End Select

        Else
            MessageBox.Show("¡No se ha seleccionado una Nota de Cargo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub


    Private Sub dtPicker_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtPicker.ValueChanged
        If bLoad = True AndAlso (Periodo <> dtPicker.Value.Year OrElse Mes <> dtPicker.Value.Month) Then
            Periodo = dtPicker.Value.Year
            Mes = dtPicker.Value.Month
            Me.refrescaGrid()
        End If
    End Sub
End Class
