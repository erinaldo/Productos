Public Class FrmPrintServer
    Inherits System.Windows.Forms.Form

    Private bError As Boolean = False
    Private bPause As Boolean = False
    Private dt As DataTable
    Private Picking, Packing, ticketPicking As Boolean
    Private TipoEntrega As Integer = 1
    Private bLoad As Boolean = False
    Private TIKClave As String
    Private TallaColor As Integer = 0

    Friend WithEvents CmbSucursal As Selling.StoreCombo
    Friend WithEvents Label1 As System.Windows.Forms.Label
  
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
    Friend WithEvents BtnSalir As Janus.Windows.EditControls.UIButton
    Friend WithEvents GrpGeneral As System.Windows.Forms.GroupBox
    Friend WithEvents LblMessage As System.Windows.Forms.Label
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents Clock As System.Windows.Forms.Timer
    Friend WithEvents BtnPausa As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnEjecutar As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPrintServer))
        Me.GrpGeneral = New System.Windows.Forms.GroupBox()
        Me.BtnPausa = New Janus.Windows.EditControls.UIButton()
        Me.LblMessage = New System.Windows.Forms.Label()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.BtnEjecutar = New Janus.Windows.EditControls.UIButton()
        Me.BtnSalir = New Janus.Windows.EditControls.UIButton()
        Me.Clock = New System.Windows.Forms.Timer(Me.components)
        Me.CmbSucursal = New Selling.StoreCombo()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GrpGeneral.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrpGeneral
        '
        Me.GrpGeneral.Controls.Add(Me.BtnPausa)
        Me.GrpGeneral.Controls.Add(Me.LblMessage)
        Me.GrpGeneral.Controls.Add(Me.lblDate)
        Me.GrpGeneral.Controls.Add(Me.BtnEjecutar)
        Me.GrpGeneral.Controls.Add(Me.BtnSalir)
        Me.GrpGeneral.Location = New System.Drawing.Point(12, 49)
        Me.GrpGeneral.Name = "GrpGeneral"
        Me.GrpGeneral.Size = New System.Drawing.Size(420, 125)
        Me.GrpGeneral.TabIndex = 0
        Me.GrpGeneral.TabStop = False
        '
        'BtnPausa
        '
        Me.BtnPausa.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnPausa.BackColor = System.Drawing.SystemColors.Control
        Me.BtnPausa.Icon = CType(resources.GetObject("BtnPausa.Icon"), System.Drawing.Icon)
        Me.BtnPausa.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BtnPausa.Location = New System.Drawing.Point(158, 43)
        Me.BtnPausa.Name = "BtnPausa"
        Me.BtnPausa.Size = New System.Drawing.Size(90, 37)
        Me.BtnPausa.TabIndex = 25
        Me.BtnPausa.ToolTipText = "Detener ejecución del Print Server"
        Me.BtnPausa.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'LblMessage
        '
        Me.LblMessage.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMessage.ForeColor = System.Drawing.Color.MidnightBlue
        Me.LblMessage.Location = New System.Drawing.Point(15, 88)
        Me.LblMessage.Name = "LblMessage"
        Me.LblMessage.Size = New System.Drawing.Size(389, 22)
        Me.LblMessage.TabIndex = 24
        Me.LblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDate
        '
        Me.lblDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lblDate.Location = New System.Drawing.Point(6, 14)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(408, 22)
        Me.lblDate.TabIndex = 23
        Me.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BtnEjecutar
        '
        Me.BtnEjecutar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEjecutar.Icon = CType(resources.GetObject("BtnEjecutar.Icon"), System.Drawing.Icon)
        Me.BtnEjecutar.Location = New System.Drawing.Point(298, 43)
        Me.BtnEjecutar.Name = "BtnEjecutar"
        Me.BtnEjecutar.Size = New System.Drawing.Size(90, 37)
        Me.BtnEjecutar.TabIndex = 3
        Me.BtnEjecutar.ToolTipText = "Iniciar Ejecución del Print Server"
        Me.BtnEjecutar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnSalir
        '
        Me.BtnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSalir.BackColor = System.Drawing.SystemColors.Control
        Me.BtnSalir.Icon = CType(resources.GetObject("BtnSalir.Icon"), System.Drawing.Icon)
        Me.BtnSalir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BtnSalir.Location = New System.Drawing.Point(18, 43)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(90, 37)
        Me.BtnSalir.TabIndex = 4
        Me.BtnSalir.ToolTipText = "Terminar proceso de Ejecución del Print Server"
        Me.BtnSalir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Clock
        '
        Me.Clock.Interval = 1000
        '
        'CmbSucursal
        '
        Me.CmbSucursal.BackColor = System.Drawing.SystemColors.Window
        Me.CmbSucursal.Location = New System.Drawing.Point(80, 15)
        Me.CmbSucursal.Name = "CmbSucursal"
        Me.CmbSucursal.Size = New System.Drawing.Size(320, 21)
        Me.CmbSucursal.TabIndex = 41
        '
        'Label1
        '
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(10, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 15)
        Me.Label1.TabIndex = 40
        Me.Label1.Text = "Sucursal "
        '
        'FrmPrintServer
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(439, 186)
        Me.Controls.Add(Me.CmbSucursal)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GrpGeneral)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPrintServer"
        Me.Text = "Print Server"
        Me.GrpGeneral.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub FrmPrintServer_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If bError Then
            e.Cancel = True
        Else
            ModPOS.PrintServer.Dispose()
            ModPOS.PrintServer = Nothing
        End If
    End Sub


    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        bError = False
        Clock.Stop()
        Me.Close()
    End Sub

    Private Sub Clock_Tick(sender As Object, e As EventArgs) Handles Clock.Tick
        lblDate.Text = DateTime.Today.ToShortDateString & " " & DateTime.Now.ToShortTimeString
        LblMessage.Text = "Buscando.."
        Clock.Stop()
        dt = ModPOS.Recupera_Tabla("st_recupera_printspooler", Nothing)
        If dt.Rows.Count > 0 Then
            Dim i As Integer
            Dim sError As String
            Dim TipoEntrega As Integer = 1
            For i = 0 To dt.Rows.Count - 1
                LblMessage.Text = "Imprimiendo " & CStr(i + 1) & "/" & CStr(dt.Rows.Count)
                If Packing = True Then
                    Dim dtp As DataTable
                    dtp = ModPOS.Recupera_Tabla("sp_obtener_envio", "@Tipo", dt.Rows(i)("TipoDocumento"), "@DOCClave", dt.Rows(i)("DOCClave"))
                    TipoEntrega = dtp.Rows(0)("tipoEntrega")
                    dtp.Dispose()
                End If

                If Not (Packing = True AndAlso TipoEntrega = 3) Then
                    sError = ModPOS.ImprimirSurtido(dt.Rows(i)("TipoDocumento"), dt.Rows(i)("DOCClave"), dt.Rows(i)("Reimpresion"), False, CmbSucursal.SelectedValue, TIKClave, ticketPicking, TallaColor)
                    ModPOS.Ejecuta("st_elimina_printspooler", "@TipoDocumento", dt.Rows(i)("TipoDocumento"), "@DOCClave", dt.Rows(i)("DOCClave"), "@Error", sError)
                End If
            Next

            If bPause = False Then
                Clock.Start()
            End If

        Else
            If bPause = False Then
                Clock.Start()
            End If
        End If
    End Sub

    Private Sub cargaSucursal(ByVal sSUCClave As String)
        dt = ModPOS.Recupera_Tabla("sp_recupera_sucursal", "@SUCClave", sSUCClave)
        Picking = IIf(dt.Rows(0)("Picking").GetType.Name = "DBNull", False, dt.Rows(0)("Picking"))
        Packing = IIf(dt.Rows(0)("Packing").GetType.Name = "DBNull", False, dt.Rows(0)("Packing"))
        ticketPicking = IIf(dt.Rows(0)("ticketPicking").GetType.Name = "DBNull", False, dt.Rows(0)("ticketPicking"))
        TIKClave = IIf(dt.Rows(0)("TIKClave").GetType.Name = "DBNull", "", dt.Rows(0)("TIKClave"))

        dt.Dispose()

    End Sub


    Private Sub FrmPrintServer_Load(sender As Object, e As EventArgs) Handles Me.Load


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

        LblMessage.Text = "Proceso Detenido"
        With CmbSucursal
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_sucursal"
            .NombreParametro1 = "USRClave"
            .Parametro1 = ModPOS.UsuarioActual
            .NombreParametro2 = "COMClave"
            .Parametro2 = ModPOS.CompanyActual
            .llenar()
        End With

        bLoad = True

        If Not CmbSucursal.SelectedValue Is Nothing Then
            cargaSucursal(CmbSucursal.SelectedValue)
        Else
            Picking = True
            Packing = False
        End If

    End Sub

    Private Sub BtnEjecutar_Click(sender As Object, e As EventArgs) Handles BtnEjecutar.Click
        bError = True
        bPause = False
        LblMessage.Text = "Proceso en Ejecución"
        Clock.Start()

    End Sub

    Private Sub BtnPausa_Click(sender As Object, e As EventArgs) Handles BtnPausa.Click
        bError = True
        LblMessage.Text = "Proceso Detenido"
        bPause = True
        Clock.Stop()
    End Sub

    Private Sub CmbSucursal_SelectedValueChanged(sender As Object, e As EventArgs) Handles CmbSucursal.SelectedValueChanged
        If bLoad = True Then
            If Not CmbSucursal.SelectedValue Is Nothing Then
                cargaSucursal(CmbSucursal.SelectedValue)
            Else
                Picking = True
                Packing = False
            End If
        End If
    End Sub
End Class
