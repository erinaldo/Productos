Imports System.Net
Imports System.Net.Mail
Imports System.IO

Public Class FrmMtoNC
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
    Friend WithEvents BtnReimpresion As Janus.Windows.EditControls.UIButton
    Friend WithEvents GridNC As Janus.Windows.GridEX.GridEX
    Friend WithEvents BtnReNC As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnSend As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnNC As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtPicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents ChkMarcaTodos As System.Windows.Forms.CheckBox
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents CmbSucursal As Selling.StoreCombo
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMtoNC))
        Me.GrpTickets = New System.Windows.Forms.GroupBox()
        Me.ChkMarcaTodos = New System.Windows.Forms.CheckBox()
        Me.BtnNC = New Janus.Windows.EditControls.UIButton()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BtnSend = New Janus.Windows.EditControls.UIButton()
        Me.dtPicker = New System.Windows.Forms.DateTimePicker()
        Me.BtnReNC = New Janus.Windows.EditControls.UIButton()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.BtnReimpresion = New Janus.Windows.EditControls.UIButton()
        Me.CmbSucursal = New Selling.StoreCombo()
        Me.BtnSalir = New Janus.Windows.EditControls.UIButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GridNC = New Janus.Windows.GridEX.GridEX()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.GrpTickets.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridNC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpTickets
        '
        Me.GrpTickets.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpTickets.Controls.Add(Me.ChkMarcaTodos)
        Me.GrpTickets.Controls.Add(Me.BtnNC)
        Me.GrpTickets.Controls.Add(Me.BtnCancelar)
        Me.GrpTickets.Controls.Add(Me.Label3)
        Me.GrpTickets.Controls.Add(Me.BtnSend)
        Me.GrpTickets.Controls.Add(Me.dtPicker)
        Me.GrpTickets.Controls.Add(Me.BtnReNC)
        Me.GrpTickets.Controls.Add(Me.PictureBox1)
        Me.GrpTickets.Controls.Add(Me.BtnReimpresion)
        Me.GrpTickets.Controls.Add(Me.CmbSucursal)
        Me.GrpTickets.Controls.Add(Me.BtnSalir)
        Me.GrpTickets.Controls.Add(Me.Label1)
        Me.GrpTickets.Controls.Add(Me.GridNC)
        Me.GrpTickets.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpTickets.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpTickets.ForeColor = System.Drawing.Color.Black
        Me.GrpTickets.Location = New System.Drawing.Point(0, 0)
        Me.GrpTickets.Name = "GrpTickets"
        Me.GrpTickets.Size = New System.Drawing.Size(742, 473)
        Me.GrpTickets.TabIndex = 1
        Me.GrpTickets.TabStop = False
        Me.GrpTickets.Text = "Notas de Crédito"
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
        Me.BtnNC.Text = "&Nota Crédito"
        Me.BtnNC.ToolTipText = "Crea una nueva Nota de Crédito"
        Me.BtnNC.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(263, 430)
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
        'BtnSend
        '
        Me.BtnSend.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSend.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSend.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSend.Icon = CType(resources.GetObject("BtnSend.Icon"), System.Drawing.Icon)
        Me.BtnSend.Location = New System.Drawing.Point(358, 430)
        Me.BtnSend.Name = "BtnSend"
        Me.BtnSend.Size = New System.Drawing.Size(90, 37)
        Me.BtnSend.TabIndex = 21
        Me.BtnSend.Text = "Enviar"
        Me.BtnSend.ToolTipText = "Envio por correo electrónico"
        Me.BtnSend.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
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
        'BtnReNC
        '
        Me.BtnReNC.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnReNC.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnReNC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnReNC.Icon = CType(resources.GetObject("BtnReNC.Icon"), System.Drawing.Icon)
        Me.BtnReNC.Location = New System.Drawing.Point(454, 430)
        Me.BtnReNC.Name = "BtnReNC"
        Me.BtnReNC.Size = New System.Drawing.Size(90, 37)
        Me.BtnReNC.TabIndex = 20
        Me.BtnReNC.Text = "Imprimir"
        Me.BtnReNC.ToolTipText = "Reimpresión de Notas de Crédito"
        Me.BtnReNC.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
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
        'BtnReimpresion
        '
        Me.BtnReimpresion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnReimpresion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnReimpresion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnReimpresion.Icon = CType(resources.GetObject("BtnReimpresion.Icon"), System.Drawing.Icon)
        Me.BtnReimpresion.ImageSize = New System.Drawing.Size(28, 28)
        Me.BtnReimpresion.Location = New System.Drawing.Point(551, 430)
        Me.BtnReimpresion.Name = "BtnReimpresion"
        Me.BtnReimpresion.Size = New System.Drawing.Size(90, 37)
        Me.BtnReimpresion.TabIndex = 9
        Me.BtnReimpresion.Text = "&Consultar"
        Me.BtnReimpresion.ToolTipText = "Mostrar factura seleccionada"
        Me.BtnReimpresion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
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
        Me.BtnSalir.Location = New System.Drawing.Point(167, 430)
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
        'GridNC
        '
        Me.GridNC.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridNC.ColumnAutoResize = True
        Me.GridNC.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridNC.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridNC.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridNC.Location = New System.Drawing.Point(7, 45)
        Me.GridNC.Name = "GridNC"
        Me.GridNC.RecordNavigator = True
        Me.GridNC.Size = New System.Drawing.Size(728, 379)
        Me.GridNC.TabIndex = 2
        Me.GridNC.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'FrmMtoNC
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(742, 473)
        Me.Controls.Add(Me.GrpTickets)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(625, 464)
        Me.Name = "FrmMtoNC"
        Me.Text = "Notas de Crédito"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GrpTickets.ResumeLayout(False)
        Me.GrpTickets.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridNC, System.ComponentModel.ISupportInitialize).EndInit()
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
    Private dtNC As DataTable
    Private sSUCClave As String

    Private Sub muestraFacturas(ByVal sNCClave As String)
        Dim a As New FrmConsultaGen
        a.Text = "Detalle de Facturas incluidas en la NC"
        ModPOS.ActualizaGrid(False, a.GridConsultaGen, "sp_recupera_facturasnc", "@NCClave", sNCClave)
        a.GridConsultaGen.GroupByBoxVisible = False
        a.ShowDialog()
        a.Dispose()
    End Sub

    Public Sub refrescaGrid()
      
        If CmbSucursal.SelectedValue Is Nothing Then
            sSUCClave = ""
        Else
            sSUCClave = CmbSucursal.SelectedValue
        End If

        If Not dtNC Is Nothing Then
            dtNC.Dispose()
        End If

        dtNC = ModPOS.Recupera_Tabla("sp_muestra_nc", "@Sucursal", sSUCClave, "@Periodo", Periodo, "@Mes", Mes)
        GridNC.DataSource = dtNC
        GridNC.RetrieveStructure()
        GridNC.BuiltInTexts(Janus.Windows.GridEX.GridEXBuiltInText.GroupByBoxInfo) = "Arrastre el encabezado de la columna aquí para agrupar por esa columna."

        Me.GridNC.RootTable.Columns("NCClave").Visible = False
        Me.GridNC.RootTable.Columns("ALMClave").Visible = False
        Me.GridNC.RootTable.Columns("TipoCF").Visible = False
        Me.GridNC.RootTable.Columns("RFC").Visible = False
        Me.GridNC.RootTable.Columns("CTEClave").Visible = False

        If TipoCF = 2 Then
            Me.GridNC.RootTable.Columns("uuid").Visible = True
        Else
            Me.GridNC.RootTable.Columns("uuid").Visible = False
        End If

        Me.GridNC.RootTable.Columns("Logo").Visible = False

        GridNC.RootTable.Columns("Total").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far

        Dim fc As Janus.Windows.GridEX.GridEXFormatCondition
        fc = New Janus.Windows.GridEX.GridEXFormatCondition(GridNC.RootTable.Columns("Estado"), Janus.Windows.GridEX.ConditionOperator.Equal, "Cancelada")
        fc.FormatStyle.ForeColor = System.Drawing.Color.Red
        GridNC.RootTable.FormatConditions.Add(fc)

    End Sub

    Private Sub FrmMtoNC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
                    Case "FormatNC"
                        FormatNC = IIf(dtParam.Rows(i)("Valor").GetType.Name = "DBNull", "Clasico", dtParam.Rows(i)("Valor"))
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

    Private Sub GridNC_CellValueChanged(sender As Object, e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridNC.CellValueChanged
        dtNC.AcceptChanges()

        GridNC.Refresh()
    End Sub


  

    Private Sub GridNC_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridNC.DoubleClick
        If Not GridNC.GetValue(0) Is Nothing Then
                Dim sNCClave As String = GridNC.GetValue("NCClave")
            If GridNC.GetValue("Estado") = "Pendiente" Then
                If MessageBox.Show("El documento seleccionado se encuentra pendiente de Certificación, ¿deseas intentar nuevamente?", "Pregunta", MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                    Dim iTipoPAC As Integer


                    iTipoPAC = ModPOS.crearXML(2, dtPAC, PathXML, GridNC.GetValue("Folio"), sNCClave, "egreso", Nothing, Nothing, Nothing, 7, InterfazSalida)

                    If iTipoPAC <> 0 Then
                        Me.refrescaGrid()

                    End If
                Else

                    muestraFacturas(sNCClave)
                End If 'Desea Certificacion
            Else
                muestraFacturas(sNCClave)

            End If 'Estado Pendiente

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

    Private Sub FrmMtoNC_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.MtoNC.Dispose()
        ModPOS.MtoNC = Nothing
    End Sub


    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub


    Private Sub BtnReimpresion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReimpresion.Click
        Dim foundRows() As DataRow

        ' Usa el metodo select para filtrar los registros seleccionados.
        foundRows = dtNC.Select("Marca ='True'")
        If foundRows.GetLength(0) = 1 Then

            Dim MonRef, MonDesc, VersionCF As String
            Dim dt As DataTable
            Dim TipoCambio As Double

            dt = Recupera_Tabla("sp_recupera_mondoc", "@Tipo", "N", "@Documento", foundRows(0)("NCClave"))
            TipoCambio = dt.Rows(0)("TipoCambio")
            MonRef = dt.Rows(0)("Referencia")
            MonDesc = dt.Rows(0)("Descripcion")
            VersionCF = dt.Rows(0)("VersionCF")
            dt.Dispose()
            Dim iTipoCF As Integer = IIf(foundRows(0)("TipoCF").GetType.Name = "DBNull", 1, foundRows(0)("TipoCF"))

            ModPOS.previewNC(iTipoCF, FormatNC, foundRows(0)("NCClave"), foundRows(0)("Total"), CmbSucursal.SelectedValue, TipoCambio, MonDesc, MonRef, VersionCF, foundRows(0)("Logo"))
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

    Private Sub BtnReNC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReNC.Click
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

                dt = Recupera_Tabla("sp_recupera_mondoc", "@Tipo", "N", "@Documento", foundRows(i)("NCClave"))
                TipoCambio = dt.Rows(0)("TipoCambio")
                MonRef = dt.Rows(0)("Referencia")
                MonDesc = dt.Rows(0)("Descripcion")
                VersionCF = dt.Rows(0)("VersionCF")
                dt.Dispose()

                ModPOS.imprimirNC(iTipoCF, FormatNC, foundRows(i)("NCClave"), foundRows(i)("Total"), CmbSucursal.SelectedValue, TipoCambio, MonDesc, MonRef, sImpresora, iCopias, VersionCF, foundRows(i)("Logo"))


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
                Dim i As Integer
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

                        dtmail = ModPOS.Recupera_Tabla("sp_recupera_mail", "@Clave", foundRows(i)("NCClave"), "@Tipo", 7)
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

                            dt = Recupera_Tabla("sp_recupera_mondoc", "@Tipo", "N", "@Documento", foundRows(i)("NCClave"))
                            TipoCambio = dt.Rows(0)("TipoCambio")
                            MonRef = dt.Rows(0)("Referencia")
                            MonDesc = dt.Rows(0)("Descripcion")
                            VersionCF = dt.Rows(0)("VersionCF")
                            dt.Dispose()


                            sError = ModPOS.SendMailNC(VersionCF, eMailCte, iTipoCF, FormatNC, CDate(foundRows(i)("Fecha")), foundRows(i)("Folio"), foundRows(i)("NCClave"), foundRows(i)("Total"), MailAdress, MailUser, MailPassword, HostSMTP, MailPort, MailSSL, DisplayName, PathXML, sSUCClave, TipoCambio, MonDesc, MonRef, foundRows(i)("Logo"), IIf(foundRows.Length = 1, True, False))

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

    Private Sub BtnNC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNC.Click
        If validaForm() Then
            Dim dt As DataTable
            dt = ModPOS.SiExisteRecupera("sp_filtra_caja", "@Sucursal", CmbSucursal.SelectedValue)

            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                Dim CAJClave As String = dt.Rows(0)("CAJClave")
                dt.Dispose()

                dt = ModPOS.SiExisteRecupera("sp_recupera_caja", "@Caja", CAJClave)

                If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then

                    Dim ALMClave As String = dt.Rows(0)("ALMClave")

                    dt.Dispose()

                    Dim a As New FrmFiltroNC
                    a.ShowDialog()
                    If a.DialogResult = DialogResult.OK Then
                        If a.Tipo = 1 Then
                            If ModPOS.NC Is Nothing Then
                                ModPOS.NC = New FrmNC
                                ModPOS.NC.AplicaReembolso = False
                                ModPOS.NC.ALMClave = ALMClave
                                ModPOS.NC.SUCClave = CmbSucursal.SelectedValue
                                ModPOS.NC.CAJClave = CAJClave
                                ModPOS.NC.SeleccionaCaja = True
                            End If
                            ModPOS.NC.StartPosition = FormStartPosition.CenterScreen
                            ModPOS.NC.Show()
                            If Not ModPOS.NC Is Nothing Then
                                ModPOS.NC.BringToFront()
                            End If
                        ElseIf a.Tipo = 2 Then
                            If ModPOS.DevSin Is Nothing Then
                                ModPOS.DevSin = New FrmDevSin
                                ModPOS.DevSin.ALMClave = ALMClave
                                ModPOS.DevSin.SUCClave = CmbSucursal.SelectedValue
                                ModPOS.DevSin.CAJClave = CAJClave
                                ModPOS.DevSin.SeleccionaCaja = True
                            End If
                            ModPOS.DevSin.StartPosition = FormStartPosition.CenterScreen
                            ModPOS.DevSin.Show()
                            If Not ModPOS.DevSin Is Nothing Then
                                ModPOS.DevSin.BringToFront()
                            End If
                        ElseIf a.Tipo = 3 Then

                            If ModPOS.Bonificacion Is Nothing Then
                                ModPOS.Bonificacion = New FrmBonificacion
                                ModPOS.Bonificacion.SUCClave = CmbSucursal.SelectedValue
                                ModPOS.Bonificacion.CAJClave = CAJClave
                                ModPOS.Bonificacion.SeleccionaCaja = True
                            End If

                            ModPOS.Bonificacion.StartPosition = FormStartPosition.CenterScreen
                            ModPOS.Bonificacion.Show()
                            If Not ModPOS.Bonificacion Is Nothing Then
                                ModPOS.Bonificacion.BringToFront()
                            End If

                        End If

                    End If
                    a.Dispose()
                Else
                    MessageBox.Show("El Almacén o Sucursal seleccionada no tiene una Caja disponible para crear una Nota de Crédito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                MessageBox.Show("El Almacén o Sucursal seleccionada no tiene una Caja disponible para crear una Nota de Crédito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Dim foundRows() As DataRow

        ' Usa el metodo select para filtrar los registros seleccionados.
        foundRows = dtNC.Select("Marca ='True'")
        If foundRows.GetLength(0) = 1 Then

            If foundRows(0)("Estado") = "Cancelada" Then
                MessageBox.Show("El documento seleccionado ya se encuentra Cancelado")
                Exit Sub
            End If

            If CmbSucursal.SelectedValue Is Nothing Then
                MessageBox.Show("La Sucursal no es valida o es requerida")
                Exit Sub
            End If

            Dim dt As DataTable

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
                                m.Tabla = "NC"
                                m.Campo = "Cancelacion"
                                m.ShowDialog()
                                If m.DialogResult = System.Windows.Forms.DialogResult.OK Then
                                    bmotivo = True
                                    MotCancelacion = m.Motivo
                                End If
                                m.Dispose()
                            Loop While bmotivo = False


                            Dim sUUID As String = IIf(foundRows(0)("uuid").GetType.Name = "DBNull", "", foundRows(0)("uuid"))


                            Dim eRFC, rRFC, sCTEClave, VersionCF As String
                            Dim dTotal As Double

                            dt = ModPOS.Recupera_Tabla("sp_encabezado_nc", "@NCClave", foundRows(0)("NCClave"))
                            rRFC = dt.Rows(0)("id_Fiscal")
                            eRFC = dt.Rows(0)("cRFC")
                            sCTEClave = dt.Rows(0)("CTEClave")
                            dTotal = dt.Rows(0)("total")
                            VersionCF = dt.Rows(0)("VersionCF")
                            dt.Dispose()

                            If TipoCF = 2 AndAlso foundRows(0)("Estado") = "Activa" Then
                                If ModPOS.cancelarXML(dtPAC, foundRows(0)("Folio"), sUUID, eRFC, VersionCF, 4, foundRows(0)("NCClave")) = False Then
                                    Exit Sub
                                End If
                            ElseIf foundRows(0)("Estado") = "Espera" Then
                                bCancela = ModPOS.ObtenerEspera(dtPAC, rRFC, 4, foundRows(0)("NCClave"), sUUID)

                                If bCancela = False Then
                                    Exit Sub
                                End If
                            End If

                            ModPOS.Ejecuta("sp_cancela_nc", "@NCClave", foundRows(0)("NCClave"), "@Motivo", MotCancelacion, "@Autoriza", Autoriza)

                            'Actualiza el Saldo del Documento
                            ModPOS.Ejecuta("sp_act_saldo_fac", "@NCClave", foundRows(0)("NCClave"))
                            ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 1, "@Cliente", foundRows(0)("CTEClave"), "@Importe", foundRows(0)("Total") * foundRows(0)("TipoCambio"))


                            'Si es de tipo devolución, realiza salida de producto de almacén

                            If foundRows(0)("Tipo") = "Devolución" Then
                                ModPOS.GeneraMovInv(2, 5, 4, foundRows(0)("NCClave"), foundRows(0)("ALMClave"), foundRows(0)("Folio"), Autoriza)
                            End If

                            refrescaGrid()

                        End If
                    End If
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

    Private Sub GridNC_CurrentCellChanged(sender As Object, e As EventArgs) Handles GridNC.CurrentCellChanged
        If Not GridNC.CurrentColumn Is Nothing Then
            If GridNC.CurrentColumn.Caption = "Marca" Then
                GridNC.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
            Else
                GridNC.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
            End If
        End If
    End Sub

    Private Sub ChkMarcaTodos_CheckedChanged(sender As Object, e As EventArgs) Handles ChkMarcaTodos.CheckedChanged
        If dtNC.Rows.Count > 0 Then
            Dim i As Integer

            If ChkMarcaTodos.Checked Then
                For i = 0 To GridNC.GetDataRows.Length - 1
                    GridNC.GetDataRows(i).DataRow("Marca") = True
                Next
            Else
                For i = 0 To GridNC.GetDataRows.Length - 1
                    GridNC.GetDataRows(i).DataRow("Marca") = False
                Next
            End If

            dtNC.AcceptChanges()

            GridNC.Refresh()
        End If
    End Sub

    Private Sub GridNC_Click(sender As Object, e As EventArgs) Handles GridNC.Click
        If Not GridNC.CurrentColumn Is Nothing Then
            If GridNC.CurrentColumn.Caption <> "Marca" And Not GridNC.GetValue("Marca") Is Nothing Then
                If GridNC.GetValue("Marca") = False Then
                    GridNC.SetValue("Marca", True)
                Else
                    GridNC.SetValue("Marca", False)
                End If
                dtNC.AcceptChanges()
                GridNC.Refresh()

            End If
        End If
    End Sub

    Private Sub GrpTickets_Enter(sender As Object, e As EventArgs) Handles GrpTickets.Enter

    End Sub
End Class
