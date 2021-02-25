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
    Friend WithEvents ChkMarcaTodos As System.Windows.Forms.CheckBox
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents CmbSucursal As Selling.StoreCombo
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMtoNotaCargo))
        Me.GrpNotasCargo = New System.Windows.Forms.GroupBox()
        Me.ChkMarcaTodos = New System.Windows.Forms.CheckBox()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.BtnNotaCargo = New Janus.Windows.EditControls.UIButton()
        Me.BtnSend = New Janus.Windows.EditControls.UIButton()
        Me.dtPicker = New System.Windows.Forms.DateTimePicker()
        Me.BtnReCargo = New Janus.Windows.EditControls.UIButton()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.BtnReimpresion = New Janus.Windows.EditControls.UIButton()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.BtnSalir = New Janus.Windows.EditControls.UIButton()
        Me.CmbSucursal = New Selling.StoreCombo()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GridNotasCargo = New Janus.Windows.GridEX.GridEX()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.GrpNotasCargo.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridNotasCargo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpNotasCargo
        '
        Me.GrpNotasCargo.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpNotasCargo.Controls.Add(Me.ChkMarcaTodos)
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
        'ChkMarcaTodos
        '
        Me.ChkMarcaTodos.Location = New System.Drawing.Point(7, 18)
        Me.ChkMarcaTodos.Name = "ChkMarcaTodos"
        Me.ChkMarcaTodos.Size = New System.Drawing.Size(76, 19)
        Me.ChkMarcaTodos.TabIndex = 58
        Me.ChkMarcaTodos.Text = "Todos"
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
        Me.BtnReCargo.Icon = CType(resources.GetObject("BtnReCargo.Icon"), System.Drawing.Icon)
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
        Me.PictureBox2.Location = New System.Drawing.Point(526, 19)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(19, 20)
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
        Me.PictureBox1.Location = New System.Drawing.Point(147, 17)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(23, 19)
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
        Me.CmbSucursal.Location = New System.Drawing.Point(176, 15)
        Me.CmbSucursal.Name = "CmbSucursal"
        Me.CmbSucursal.Size = New System.Drawing.Size(315, 24)
        Me.CmbSucursal.TabIndex = 36
        '
        'Label1
        '
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(104, 19)
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
        Me.GridNotasCargo.AutoEdit = True
        Me.GridNotasCargo.ColumnAutoResize = True
        Me.GridNotasCargo.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridNotasCargo.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridNotasCargo.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridNotasCargo.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown
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
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
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

    ' Private sCargoSelected As String
    'Private sFolio As String
    Private ALMClave As String = ""
    Private InterfazSalida, sMailCliente, PathXML, PathPDF, MailAdress, DisplayName, MailUser, MailPassword, HostSMTP, FormatCargo As String
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


    Private TipoCF As Integer
    ' Private ServidorCancelacion, ServidorTimbrado, Customerkey As String

    Private dtPAC As DataTable

    Private Autoriza As String

    Private sSUCClave As String
    Private dtNC As DataTable

    Public Sub refrescaGrid()



        If CmbSucursal.SelectedValue Is Nothing Then
            sSUCClave = ""
        Else
            sSUCClave = CmbSucursal.SelectedValue
        End If

        dtNC = ModPOS.Recupera_Tabla("sp_muestra_notacargo", "@Sucursal", sSUCClave, "@Periodo", Periodo, "@Mes", Mes)
        GridNotasCargo.DataSource = dtNC
        GridNotasCargo.RetrieveStructure()
        GridNotasCargo.BuiltInTexts(Janus.Windows.GridEX.GridEXBuiltInText.GroupByBoxInfo) = "Arrastre el encabezado de la columna aquí para agrupar por esa columna."



        Me.GridNotasCargo.RootTable.Columns("CARClave").Visible = False
        Me.GridNotasCargo.RootTable.Columns("TipoCF").Visible = False
        Me.GridNotasCargo.RootTable.Columns("RFC").Visible = False
        Me.GridNotasCargo.RootTable.Columns("CTEClave").Visible = False

        If TipoCF = 2 Then
            Me.GridNotasCargo.RootTable.Columns("uuid").Visible = True
        Else
            Me.GridNotasCargo.RootTable.Columns("uuid").Visible = False
        End If

        Me.GridNotasCargo.RootTable.Columns("Logo").Visible = False

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
                    Case "FormatCargo"
                        FormatCargo = IIf(dtParam.Rows(i)("Valor").GetType.Name = "DBNull", "Clasico", dtParam.Rows(i)("Valor"))
                    Case "InterfazSalida"
                        InterfazSalida = IIf(dtParam.Rows(i)("Valor").GetType.Name = "DBNull", "", dtParam.Rows(i)("Valor"))

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

    Private Sub GridNotasCargo_CellValueChanged(sender As Object, e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridNotasCargo.CellValueChanged
        dtNC.AcceptChanges()

        GridNotasCargo.Refresh()
    End Sub

    Private Sub GridNotasCargo_CurrentCellChanged(sender As Object, e As EventArgs) Handles GridNotasCargo.CurrentCellChanged
        If Not GridNotasCargo.CurrentColumn Is Nothing Then
            If GridNotasCargo.CurrentColumn.Caption = "Marca" Then
                GridNotasCargo.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
            Else
                GridNotasCargo.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
            End If
        End If
    End Sub

    Private Sub GridNotasCargo_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridNotasCargo.DoubleClick

        If Not GridNotasCargo.GetValue(0) Is Nothing Then
            Dim sCARClave As String = GridNotasCargo.GetValue("CARClave")
            Dim dTotal As Decimal = GridNotasCargo.GetValue("Total")
            Dim iLogo As Integer = GridNotasCargo.GetValue("Logo")

            If GridNotasCargo.GetValue("Estado") = "Pendiente" Then
                Dim iTipoPAC As Integer
                If MessageBox.Show("El documento seleccionado se encuentra pendiente de Certificación, ¿deseas intentar nuevamente?", "Pregunta", MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then

                    iTipoPAC = ModPOS.crearXML(2, dtPAC, PathXML, GridNotasCargo.GetValue("Folio"), sCARClave, "ingreso", Nothing, Nothing, Nothing, 6, InterfazSalida)

                    If iTipoPAC <> 0 Then
                        Me.refrescaGrid()
                        Imprimir(sCARClave, dTotal, iLogo)
                    End If
                Else
                    Imprimir(sCARClave, dTotal, iLogo)
                End If 'Desea Certificacion
            Else
                Imprimir(sCARClave, dTotal, iLogo)
            End If 'Estado Pendiente
        Else
            MessageBox.Show("¡No se ha seleccionado alguna nota de cargo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
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
        Dim foundRows() As DataRow

        ' Usa el metodo select para filtrar los registros seleccionados.
        foundRows = dtNC.Select("Marca ='True'")
        If foundRows.GetLength(0) = 1 Then
            Imprimir(foundRows(0)("CARClave"), foundRows(0)("Total"), foundRows(0)("Logo"))
        Else
            MessageBox.Show("Debe marcar solo 1 registro para poder Consultar el documento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub Imprimir(ByVal sCARClave As String, ByVal dTotal As Decimal, ByVal iLogo As Integer)

        Dim MonRef, MonDesc, VersionCF As String
        Dim TipoCambio As Double
        Dim dt As DataTable

        dt = Recupera_Tabla("sp_recupera_mondoc", "@Tipo", "C", "@Documento", sCARClave)
        TipoCambio = dt.Rows(0)("TipoCambio")
        MonRef = dt.Rows(0)("Referencia")
        MonDesc = dt.Rows(0)("Descripcion")
        VersionCF = dt.Rows(0)("VersionCF")
        dt.Dispose()

        ModPOS.previewCargo(FormatCargo, sCARClave, dTotal, TipoCambio, MonDesc, MonRef, VersionCF, iLogo)


    End Sub

    Private Sub Combo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbSucursal.SelectedIndexChanged
        If bLoad Then
            If validaForm() Then
                refrescaGrid()
            End If
        End If
    End Sub

    Private Sub BtnReFac_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReCargo.Click
        Dim i As Integer

        Dim foundRows() As DataRow

        ' Usa el metodo select para filtrar los registros seleccionados.
        foundRows = dtNC.Select("Marca ='True'")
        If foundRows.GetLength(0) > 0 Then

            Dim sImpresora As String
            Dim iCopias As Integer

            If PrintDialog1.ShowDialog() = DialogResult.OK Then
                sImpresora = PrintDialog1.PrinterSettings.PrinterName
                iCopias = PrintDialog1.PrinterSettings.Copies
            Else
                Exit Sub
            End If


            For i = 0 To foundRows.GetUpperBound(0)

                Dim iTipoCF As Integer = IIf(foundRows(i)("TipoCF").GetType.Name = "DBNull", 1, foundRows(i)("TipoCF"))

                Dim MonRef, MonDesc, VersionCF As String
                Dim TipoCambio As Double
                Dim dt As DataTable

                dt = Recupera_Tabla("sp_recupera_mondoc", "@Tipo", "C", "@Documento", foundRows(i)("CARClave"))
                TipoCambio = dt.Rows(0)("TipoCambio")
                MonRef = dt.Rows(0)("Referencia")
                MonDesc = dt.Rows(0)("Descripcion")
                VersionCF = dt.Rows(0)("VersionCF")
                dt.Dispose()


                ModPOS.imprimirCargo(FormatCargo, foundRows(i)("CARClave"), foundRows(i)("Total"), TipoCambio, MonDesc, MonRef, sImpresora, iCopias, VersionCF, foundRows(i)("Logo"))
              


                foundRows(i)("Marca") = False
            Next
            ChkMarcaTodos.Checked = False


        Else
            MessageBox.Show("Para reimprimir, debe marcar por lo menos un registro", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub BtnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSend.Click
        If validaForm() Then
            Dim foundRows() As DataRow

            ' Usa el metodo select para filtrar los registros seleccionados.
            foundRows = dtNC.Select("Marca ='True'")
            If foundRows.GetLength(0) > 0 Then

                Dim PathPDF As String
                Dim i, j As Integer
                Dim frmStatusMessage As New frmStatus

                Dim MonRef, MonDesc, VersionCF As String
                Dim TipoCambio As Double
                Dim dt As DataTable
                Dim eMailCte As String = ""
                Dim sMailCliente As String = ""
                Dim sClienteActual As String = ""
                Dim sError As String = ""

                For i = 0 To foundRows.GetUpperBound(0)

                    If sClienteActual <> foundRows(i)("Clave") Then
                        Dim dtmail As DataTable
                        'Recupera correo electronico

                        dtmail = ModPOS.Recupera_Tabla("sp_recupera_mail", "@Clave", foundRows(i)("CARClave"), "@Tipo", 6)
                        eMailCte = dtmail.Rows(0)("Email")
                        dtmail.Dispose()
                        sClienteActual = foundRows(i)("Clave")

                        If eMailCte = "" OrElse eMailCte <> sMailCliente Then
                            Dim m As New FrmCorreo
                            m.eMail = eMailCte
                            m.Folio = " Folio: " & foundRows(i)("Folio") & " Cliente: " & foundRows(i)("Clave")
                            m.ShowDialog()
                            If m.DialogResult = System.Windows.Forms.DialogResult.OK Then
                                eMailCte = m.Correo
                            Else
                                eMailCte = "Salir"
                            End If
                            m.Dispose()
                        End If

                    End If

                   

                    If eMailCte <> "" Then
                        If eMailCte <> "Salir" Then
                            PathPDF = pathActual & "Temp\" & foundRows(i)("Folio") & ".PDF"

                            Dim iTipoCF As Integer = IIf(foundRows(i)("TipoCF").GetType.Name = "DBNull", 1, foundRows(i)("TipoCF"))



                            'Genera PDF

                            dt = Recupera_Tabla("sp_recupera_mondoc", "@Tipo", "C", "@Documento", foundRows(i)("CARClave"))
                            TipoCambio = dt.Rows(0)("TipoCambio")
                            MonRef = dt.Rows(0)("Referencia")
                            MonDesc = dt.Rows(0)("Descripcion")
                            VersionCF = dt.Rows(0)("VersionCF")
                            dt.Dispose()

                            sError = ModPOS.SendMailCargo(VersionCF, eMailCte, FormatCargo, foundRows(i)("Fecha"), foundRows(i)("Folio"), foundRows(i)("CARClave"), foundRows(i)("Total"), MailAdress, MailUser, MailPassword, HostSMTP, MailPort, MailSSL, DisplayName, PathXML, TipoCambio, MonDesc, MonRef, foundRows(i)("Logo"), IIf(foundRows.Length = 1, True, False))

                            If sError <> "" And foundRows.Length > 1 Then
                                MessageBox.Show(sError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                            End If


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
        Dim foundRows() As DataRow

        ' Usa el metodo select para filtrar los registros seleccionados.
        foundRows = dtNC.Select("Marca ='True'")
        If foundRows.GetLength(0) = 1 Then

            If foundRows(0)("Estado") = "Cancelada" Then
                MessageBox.Show("El documento seleccionado ya se encuentra Cancelado")
                Exit Sub
            End If


            'Valida que no tenga abonos aplicados, que el total sea igual al saldo

            If foundRows(0)("Total") <> foundRows(0)("Saldo") Then
                MessageBox.Show("No es posible cancelar el documento seleccionado ya que cuenta con abonos o notas de credito aplicadas", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If CmbSucursal.SelectedValue Is Nothing Then
                MessageBox.Show("La Sucursal no es valida o es requerida")
                Exit Sub
            End If

            Dim dt As DataTable

            dt = Recupera_Tabla("sp_recupera_almcargo", "@CARClave", foundRows(0)("CARClave"))
            ALMClave = dt.Rows(0)("ALMClave")
            dt.Dispose()

            Select Case MessageBox.Show("¿Esta seguro de Cancelar el documento " & foundRows(0)("Folio") & "?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                Case DialogResult.Yes
                    Dim a As New MeAutorizacion

                    a.Sucursal = CmbSucursal.SelectedValue
                    a.MontodeAutorizacion = foundRows(0)("Total") * foundRows(0)("TipoCambio")
                    a.StartPosition = FormStartPosition.CenterScreen
                    a.ShowDialog()
                    If a.DialogResult = DialogResult.OK Then
                        If a.Autorizado Then
                            Autoriza = a.Autoriza
                            Dim bmotivo As Boolean = False
                            Dim MotCancelacion As Integer
                            Dim bCancela As Boolean

                            Do
                                Dim m As New FrmMotivo
                                m.Tabla = "Factura"
                                m.Campo = "Cancelacion"
                                m.ShowDialog()
                                If m.DialogResult = System.Windows.Forms.DialogResult.OK Then
                                    bmotivo = True
                                    MotCancelacion = m.Motivo
                                End If
                                m.Dispose()
                            Loop While bmotivo = False


                            Dim eRFC, rRFC, sCTEClave, VersionCF As String
                            Dim dTotal As Double
                            dt = ModPOS.Recupera_Tabla("sp_encabezado_cargo", "@CARClave", foundRows(0)("CARClave"))
                            rRFC = dt.Rows(0)("id_Fiscal")
                            eRFC = dt.Rows(0)("cRFC")
                            sCTEClave = dt.Rows(0)("CTEClave")
                            dTotal = dt.Rows(0)("total")
                            VersionCF = dt.Rows(0)("VersionCF")
                            dt.Dispose()

                            Dim sUUID As String = IIf(foundRows(0)("uuid").GetType.Name = "DBNull", "", foundRows(0)("uuid"))


                            If TipoCF = 2 AndAlso foundRows(0)("Estado") = "Activa" Then


                                bCancela = ModPOS.cancelarXML(dtPAC, foundRows(0)("Folio"), sUUID, eRFC, VersionCF, 6, foundRows(0)("CARClave"))
                                If bCancela = False Then
                                    Exit Sub
                                End If
                            ElseIf foundRows(0)("Estado") = "Espera" Then
                                bCancela = ModPOS.ObtenerEspera(dtPAC, rRFC, 6, foundRows(0)("CARClave"), sUUID)

                                If bCancela = False Then
                                    Exit Sub
                                End If
                            End If

                            ModPOS.Ejecuta("sp_cancela_notacargo", "@CARClave", foundRows(0)("CARClave"), "@Motivo", MotCancelacion, "@Autoriza", Autoriza)

                            'Actualiza el Saldo del Documento
                            ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 2, "@Cliente", foundRows(0)("CTEClave"), "@Importe", foundRows(0)("Total") * foundRows(0)("TipoCambio"))

                            If InterfazSalida <> "" AndAlso bCancela = True Then
                                Dim sFecha As String
                                Dim dtInterfaz As DataTable
                                sFecha = DateTime.Now.ToString("yyyyMMdd_HHmmssfff")

                                dtInterfaz = Recupera_Tabla("st_recupera_interfaz", "@Interfaz", "CancelacionCargo", "@COMClave", ModPOS.CompanyActual)
                                If dtInterfaz.Rows.Count > 0 Then
                                    ModPOS.Ejecuta(CStr(dtInterfaz.Rows(0)("sp")), "@Folio", foundRows(0)("CARClave"), "@TipoDocumento", 0, "@Path", InterfazSalida, "@Fecha", sFecha)
                                End If

                            End If
                            refrescaGrid()

                        End If
                    End If
            End Select

        Else
            MessageBox.Show("Debe marcar solo 1 registro para poder Cancelar el documento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub


    Private Sub dtPicker_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtPicker.ValueChanged
        If bLoad = True AndAlso (Periodo <> dtPicker.Value.Year OrElse Mes <> dtPicker.Value.Month) Then
            Periodo = dtPicker.Value.Year
            Mes = dtPicker.Value.Month
            Me.refrescaGrid()
        End If
    End Sub

 
    Private Sub ChkMarcaTodos_CheckedChanged(sender As Object, e As EventArgs) Handles ChkMarcaTodos.CheckedChanged
        If dtNC.Rows.Count > 0 Then
            Dim i As Integer

            If ChkMarcaTodos.Checked Then
                For i = 0 To GridNotasCargo.GetDataRows.Length - 1
                    GridNotasCargo.GetDataRows(i).DataRow("Marca") = True
                Next
            Else
                For i = 0 To GridNotasCargo.GetDataRows.Length - 1
                    GridNotasCargo.GetDataRows(i).DataRow("Marca") = False
                Next
            End If

            dtNC.AcceptChanges()

            GridNotasCargo.Refresh()
        End If
    End Sub

    Private Sub GridNotasCargo_Click(sender As Object, e As EventArgs) Handles GridNotasCargo.Click
        If Not GridNotasCargo.CurrentColumn Is Nothing Then
            If GridNotasCargo.CurrentColumn.Caption <> "Marca" And Not GridNotasCargo.GetValue("Marca") Is Nothing Then
                If GridNotasCargo.GetValue("Marca") = False Then
                    GridNotasCargo.SetValue("Marca", True)
                Else
                    GridNotasCargo.SetValue("Marca", False)
                End If
                dtNC.AcceptChanges()
                GridNotasCargo.Refresh()

            End If
        End If
    End Sub
End Class
