Imports System.Drawing
Imports System.IO

Public Class FAplBase
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
    Friend WithEvents btAceptar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents ebDataBase As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebServidor As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lbDataBase As System.Windows.Forms.Label
    Friend WithEvents lbServidor As System.Windows.Forms.Label
    Friend WithEvents lbPassword As System.Windows.Forms.Label
    Friend WithEvents lbUsuario As System.Windows.Forms.Label
    Friend WithEvents ebPassword As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebUsuario As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents ebIdioma As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lbIdioma As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FAplBase))
        Me.btAceptar = New Janus.Windows.EditControls.UIButton
        Me.btCancelar = New Janus.Windows.EditControls.UIButton
        Me.ebDataBase = New Janus.Windows.GridEX.EditControls.EditBox
        Me.ebServidor = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lbDataBase = New System.Windows.Forms.Label
        Me.lbServidor = New System.Windows.Forms.Label
        Me.ebPassword = New Janus.Windows.GridEX.EditControls.EditBox
        Me.ebUsuario = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lbPassword = New System.Windows.Forms.Label
        Me.lbUsuario = New System.Windows.Forms.Label
        Me.ebIdioma = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lbIdioma = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'btAceptar
        '
        Me.btAceptar.Icon = CType(resources.GetObject("btAceptar.Icon"), System.Drawing.Icon)
        Me.btAceptar.Location = New System.Drawing.Point(136, 184)
        Me.btAceptar.Name = "btAceptar"
        Me.btAceptar.Size = New System.Drawing.Size(80, 24)
        Me.btAceptar.TabIndex = 5
        Me.btAceptar.Text = "OK"
        Me.btAceptar.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'btCancelar
        '
        Me.btCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btCancelar.Icon = CType(resources.GetObject("btCancelar.Icon"), System.Drawing.Icon)
        Me.btCancelar.Location = New System.Drawing.Point(232, 184)
        Me.btCancelar.Name = "btCancelar"
        Me.btCancelar.Size = New System.Drawing.Size(80, 24)
        Me.btCancelar.TabIndex = 6
        Me.btCancelar.Text = "Cancel"
        Me.btCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'ebDataBase
        '
        Me.ebDataBase.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebDataBase.Location = New System.Drawing.Point(152, 48)
        Me.ebDataBase.MaxLength = 40
        Me.ebDataBase.Name = "ebDataBase"
        Me.ebDataBase.Size = New System.Drawing.Size(160, 20)
        Me.ebDataBase.TabIndex = 1
        Me.ebDataBase.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebDataBase.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'ebServidor
        '
        Me.ebServidor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebServidor.Location = New System.Drawing.Point(152, 16)
        Me.ebServidor.MaxLength = 40
        Me.ebServidor.Name = "ebServidor"
        Me.ebServidor.Size = New System.Drawing.Size(160, 20)
        Me.ebServidor.TabIndex = 0
        Me.ebServidor.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebServidor.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbDataBase
        '
        Me.lbDataBase.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbDataBase.Location = New System.Drawing.Point(16, 48)
        Me.lbDataBase.Name = "lbDataBase"
        Me.lbDataBase.Size = New System.Drawing.Size(132, 20)
        Me.lbDataBase.TabIndex = 11
        Me.lbDataBase.Text = "Database"
        Me.lbDataBase.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbServidor
        '
        Me.lbServidor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbServidor.Location = New System.Drawing.Point(16, 16)
        Me.lbServidor.Name = "lbServidor"
        Me.lbServidor.Size = New System.Drawing.Size(132, 20)
        Me.lbServidor.TabIndex = 9
        Me.lbServidor.Text = "Server"
        Me.lbServidor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebPassword
        '
        Me.ebPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebPassword.Location = New System.Drawing.Point(152, 112)
        Me.ebPassword.MaxLength = 40
        Me.ebPassword.Name = "ebPassword"
        Me.ebPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.ebPassword.Size = New System.Drawing.Size(160, 20)
        Me.ebPassword.TabIndex = 3
        Me.ebPassword.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebPassword.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'ebUsuario
        '
        Me.ebUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebUsuario.Location = New System.Drawing.Point(152, 80)
        Me.ebUsuario.MaxLength = 40
        Me.ebUsuario.Name = "ebUsuario"
        Me.ebUsuario.Size = New System.Drawing.Size(160, 20)
        Me.ebUsuario.TabIndex = 2
        Me.ebUsuario.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebUsuario.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbPassword
        '
        Me.lbPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbPassword.Location = New System.Drawing.Point(16, 112)
        Me.lbPassword.Name = "lbPassword"
        Me.lbPassword.Size = New System.Drawing.Size(132, 20)
        Me.lbPassword.TabIndex = 15
        Me.lbPassword.Text = "Password"
        Me.lbPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbUsuario
        '
        Me.lbUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbUsuario.Location = New System.Drawing.Point(16, 80)
        Me.lbUsuario.Name = "lbUsuario"
        Me.lbUsuario.Size = New System.Drawing.Size(132, 20)
        Me.lbUsuario.TabIndex = 13
        Me.lbUsuario.Text = "User Id"
        Me.lbUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ebIdioma
        '
        Me.ebIdioma.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ebIdioma.Location = New System.Drawing.Point(152, 144)
        Me.ebIdioma.MaxLength = 40
        Me.ebIdioma.Name = "ebIdioma"
        Me.ebIdioma.Size = New System.Drawing.Size(160, 20)
        Me.ebIdioma.TabIndex = 4
        Me.ebIdioma.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebIdioma.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbIdioma
        '
        Me.lbIdioma.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbIdioma.Location = New System.Drawing.Point(16, 144)
        Me.lbIdioma.Name = "lbIdioma"
        Me.lbIdioma.Size = New System.Drawing.Size(132, 20)
        Me.lbIdioma.TabIndex = 17
        Me.lbIdioma.Text = "Language"
        Me.lbIdioma.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FAplBase
        '
        Me.AcceptButton = Me.btAceptar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btCancelar
        Me.ClientSize = New System.Drawing.Size(322, 216)
        Me.Controls.Add(Me.ebIdioma)
        Me.Controls.Add(Me.lbIdioma)
        Me.Controls.Add(Me.ebPassword)
        Me.Controls.Add(Me.ebUsuario)
        Me.Controls.Add(Me.lbPassword)
        Me.Controls.Add(Me.lbUsuario)
        Me.Controls.Add(Me.ebDataBase)
        Me.Controls.Add(Me.ebServidor)
        Me.Controls.Add(Me.lbDataBase)
        Me.Controls.Add(Me.lbServidor)
        Me.Controls.Add(Me.btAceptar)
        Me.Controls.Add(Me.btCancelar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FAplBase"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AMESOL Mexico"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub FAplBase_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim vlIcon1 As New Icon(System.Windows.Forms.Application.StartupPath + "\Imagenes\Icono.dat")
        Me.Icon = vlIcon1
    End Sub

    Private Sub btCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAceptar.Click
        If RevisarCampos() Then

            If File.Exists(sRutaInicio & "\AplBase.ini") Then
                File.Delete(sRutaInicio & "\AplBase.ini")
            End If
            Dim fStream As New StreamWriter(sRutaInicio & "\AplBase.ini")
            Dim bCreado As Boolean = False
            Try
                fStream.WriteLine("[Conexion]")
                fStream.WriteLine("User ID='" & Me.ebUsuario.Text & "';Tag with column collation when possible=False;Data Source='" & Me.ebServidor.Text & "';Password='" & Me.ebPassword.Text & "';Initial Catalog=" & Me.ebDataBase.Text & ";Use Procedure for Prepare=1;Auto Translate=True;Persist Security Info=True;Provider='SQLOLEDB.1';Workstation ID=DESARROLLO;Use Encryption for Data=False;Packet Size=4096;Connect Timeout=15")
                fStream.WriteLine()
                fStream.WriteLine("[TimeOut]")
                fStream.WriteLine("5000")
                fStream.WriteLine()
                fStream.WriteLine("[Lenguaje]")
                fStream.WriteLine(Me.ebIdioma.Text)
                bCreado = True
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            Finally
                fStream.Flush()
                fStream.Close()
            End Try
            If bCreado Then
                Me.DialogResult = Windows.Forms.DialogResult.OK
            Else
                Me.DialogResult = Windows.Forms.DialogResult.Cancel
            End If
            Me.Close()
        End If
    End Sub

    Private Function RevisarCampos() As Boolean
        If Trim(Me.ebServidor.Text) = String.Empty Then
            MsgBox("The field '" & Me.lbServidor.Text & "' is required", MsgBoxStyle.Information, "Error")
            Me.ebServidor.Focus()
            Return False
        End If
        If Trim(Me.ebDataBase.Text) = String.Empty Then
            MsgBox("The field '" & Me.lbDataBase.Text & "' is required", MsgBoxStyle.Information, "Error")
            Me.ebDataBase.Focus()
            Return False
        End If
        If Trim(Me.ebUsuario.Text) = String.Empty Then
            MsgBox("The field '" & Me.lbUsuario.Text & "' is required", MsgBoxStyle.Information, "Error")
            Me.ebUsuario.Focus()
            Return False
        End If
        If Trim(Me.ebPassword.Text) = String.Empty Then
            MsgBox("The field '" & Me.lbPassword.Text & "' is required", MsgBoxStyle.Information, "Error")
            Me.ebPassword.Focus()
            Return False
        End If
        If Trim(Me.ebIdioma.Text) = String.Empty Then
            MsgBox("The field '" & Me.lbIdioma.Text & "' is required", MsgBoxStyle.Information, "Error")
            Me.ebIdioma.Focus()
            Return False
        End If
        Return True
    End Function
End Class
