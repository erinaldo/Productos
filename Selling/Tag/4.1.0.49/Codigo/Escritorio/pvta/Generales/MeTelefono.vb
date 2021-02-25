Public Class MeTelefono
    Inherits System.Windows.Forms.Form


    Public Producto As String
    Public Usuario As String = "622cc0c8-ac2d-4c2c-a345-64e56c91c4b0"
    Public Contrasena As String = "123456"
    Public idPOS As String = "622cc0c8-ac2d-4c2c-a345-64e56c91c4b0"
    Public idCajero As Integer = 1027
    Public passCajero As String = "123456"
    Public transaccionValida As Boolean = False


    Private descripcionError As String
    Private GUID As String
    Private url As String
    Private codigoAutorizador As Integer
    Private client As WSRecargaTelefonica.Iwcf_RecargacelCommonClient = New WSRecargaTelefonica.Iwcf_RecargacelCommonClient()
    Private status As Integer

    Private time As Integer = 0

    Private Prod As String
    Private bError As Boolean = False
    ' Public Reporte As String

    Private alerta(1) As PictureBox

    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents EdtRepetir As System.Windows.Forms.TextBox
    Friend WithEvents EdtNumero As System.Windows.Forms.TextBox
    Friend WithEvents lblDestino As System.Windows.Forms.Label
    Friend WithEvents lblOrigen As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer

    Private reloj As parpadea

    Dim frmStatusMessage As New frmStatus


#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'UserControl overrides dispose to clean up the component list.
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
    Friend WithEvents BtnOK As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnCancel As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MeTelefono))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.EdtRepetir = New System.Windows.Forms.TextBox()
        Me.EdtNumero = New System.Windows.Forms.TextBox()
        Me.lblDestino = New System.Windows.Forms.Label()
        Me.lblOrigen = New System.Windows.Forms.Label()
        Me.BtnOK = New Janus.Windows.EditControls.UIButton()
        Me.BtnCancel = New Janus.Windows.EditControls.UIButton()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        resources.ApplyResources(Me.GroupBox2, "GroupBox2")
        Me.GroupBox2.Controls.Add(Me.PictureBox1)
        Me.GroupBox2.Controls.Add(Me.PictureBox3)
        Me.GroupBox2.Controls.Add(Me.EdtRepetir)
        Me.GroupBox2.Controls.Add(Me.EdtNumero)
        Me.GroupBox2.Controls.Add(Me.lblDestino)
        Me.GroupBox2.Controls.Add(Me.lblOrigen)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.TabStop = False
        '
        'PictureBox1
        '
        resources.ApplyResources(Me.PictureBox1, "PictureBox1")
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.TabStop = False
        '
        'PictureBox3
        '
        resources.ApplyResources(Me.PictureBox3, "PictureBox3")
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.TabStop = False
        '
        'EdtRepetir
        '
        resources.ApplyResources(Me.EdtRepetir, "EdtRepetir")
        Me.EdtRepetir.Name = "EdtRepetir"
        '
        'EdtNumero
        '
        resources.ApplyResources(Me.EdtNumero, "EdtNumero")
        Me.EdtNumero.Name = "EdtNumero"
        '
        'lblDestino
        '
        Me.lblDestino.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        resources.ApplyResources(Me.lblDestino, "lblDestino")
        Me.lblDestino.Name = "lblDestino"
        '
        'lblOrigen
        '
        Me.lblOrigen.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        resources.ApplyResources(Me.lblOrigen, "lblOrigen")
        Me.lblOrigen.Name = "lblOrigen"
        '
        'BtnOK
        '
        resources.ApplyResources(Me.BtnOK, "BtnOK")
        Me.BtnOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BtnOK.Image = CType(resources.GetObject("BtnOK.Image"), System.Drawing.Image)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCancel
        '
        resources.ApplyResources(Me.BtnCancel, "BtnCancel")
        Me.BtnCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Image = CType(resources.GetObject("BtnCancel.Image"), System.Drawing.Image)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Timer1
        '
        '
        'MeTelefono
        '
        Me.AcceptButton = Me.BtnOK
        resources.ApplyResources(Me, "$this")
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CancelButton = Me.BtnCancel
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.BtnOK)
        Me.Controls.Add(Me.BtnCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MeTelefono"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub MeFiltroAlm_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If bError Then
            e.Cancel = True
        End If
    End Sub

    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If Contrasena = "" Or Usuario = "" Then
            i += 1
            MessageBox.Show("El usuario o contraseña del sistema de recargas estan incorrectos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        If idCajero = 0 Or passCajero = "" Or idPOS = "" Then
            i += 1
            MessageBox.Show("Los datos del cajero para el sistema recargas estan incorrectos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        If IsNumeric(EdtNumero.Text) = False Then
            i += 1
            Me.alerta(0).Visible = True
            MessageBox.Show("El número no debe de contener letras", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        If IsNumeric(EdtRepetir.Text) = False Then
            i += 1
            Me.alerta(1).Visible = True
            MessageBox.Show("El número no debe de contener letras", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        If i = 0 Then
            If EdtRepetir.Text <> EdtNumero.Text Then
                i += 2
                Me.alerta(0).Visible = True
                Me.alerta(1).Visible = True
                MessageBox.Show("Los números deben de coincidir", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
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

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        bError = False
        Me.Close()
    End Sub

    Private Sub BtnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOK.Click
        If validaForm() Then
            bError = False
            Try
                frmStatusMessage.Show("Procesando transacción")
                frmStatusMessage.BringToFront()
                If client.openSession(Usuario, Contrasena, descripcionError, GUID) = 0 Then
                    status = client.doRecargaCashier(GUID, idPOS, idCajero, passCajero, EdtNumero.Text, Producto, descripcionError, codigoAutorizador)
                    VerificarStatus()

                End If
            Catch ex As TimeoutException
                VerificarStatus()
            End Try

        Else
            bError = True
            Beep()
            'MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        End If
    End Sub


    Private Sub MeSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Me.StartPosition = FormStartPosition.CenterScreen

        Dim i As Integer
        Dim dt As DataTable = ModPOS.Recupera_Tabla("sp_recupera_parametro", "@COMClave", ModPOS.CompanyActual)
        With Me
            For i = 0 To dt.Rows.Count - 1
                Select Case CStr(dt.Rows(i)("PARClave"))
                    Case "urlRecargasTel"
                        If dt.Rows(i)("Valor").GetType.Name <> "DBNull" Then
                            client.Endpoint.Address = New System.ServiceModel.EndpointAddress(dt.Rows(i)("valor").ToString)
                        End If
                    Case "UsuarioRecargas"
                        Usuario = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", "", dt.Rows(i)("Valor"))
                    Case "ContrasenaRecargas"
                        Contrasena = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", "", dt.Rows(i)("Valor"))
                End Select
            Next
        End With
        dt.Dispose()

        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox3
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        time = time + 1
        If time = 4 Then
            VerificarStatus()
        End If
    End Sub


    Private Sub VerificarStatus()
        Timer1.Enabled = False
        time = 0
        status = client.getRecargaStatus(GUID, Usuario, Contrasena, descripcionError, codigoAutorizador)
        If status = 96 Or status = 0 Then
            transaccionValida = True
            frmStatusMessage.Dispose()
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            client.closeSession(GUID, descripcionError)
            MessageBox.Show("Recarga Exitosa", "Recarga Telefónica", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf status = 99 Then
            Timer1.Enabled = True
        Else
            frmStatusMessage.Dispose()
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            client.closeSession(GUID, descripcionError)
            MessageBox.Show(status.ToString() + " " + descripcionError, "Recarga Telefónica", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If


        If status <> 99 Then
            Dim cerrar As Boolean = True
            If status <> 0 AndAlso status <> 96 Then
                If MessageBox.Show("¿Deseas reintentar?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                    cerrar = False
                End If
            End If
            If cerrar Then
                Me.Close()
            End If

        End If

    End Sub


End Class
