Imports System.Data.SqlClient

Public Class FrmRestaurar
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LblClave As System.Windows.Forms.Label
    Friend WithEvents BtnExaminar As Janus.Windows.EditControls.UIButton
    Friend WithEvents GrpProceso As System.Windows.Forms.GroupBox
    Friend WithEvents TxtBD As System.Windows.Forms.TextBox
    Friend WithEvents TxtServer As System.Windows.Forms.TextBox
    Friend WithEvents TxtDireccion As System.Windows.Forms.TextBox
    Friend WithEvents BtnAceptar As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRestaurar))
        Me.GrpProceso = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtBD = New System.Windows.Forms.TextBox
        Me.TxtServer = New System.Windows.Forms.TextBox
        Me.TxtDireccion = New System.Windows.Forms.TextBox
        Me.LblClave = New System.Windows.Forms.Label
        Me.BtnExaminar = New Janus.Windows.EditControls.UIButton
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.BtnAceptar = New Janus.Windows.EditControls.UIButton
        Me.GrpProceso.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrpProceso
        '
        Me.GrpProceso.Controls.Add(Me.Label2)
        Me.GrpProceso.Controls.Add(Me.Label1)
        Me.GrpProceso.Controls.Add(Me.TxtBD)
        Me.GrpProceso.Controls.Add(Me.TxtServer)
        Me.GrpProceso.Controls.Add(Me.TxtDireccion)
        Me.GrpProceso.Controls.Add(Me.LblClave)
        Me.GrpProceso.Controls.Add(Me.BtnExaminar)
        Me.GrpProceso.Location = New System.Drawing.Point(7, 8)
        Me.GrpProceso.Name = "GrpProceso"
        Me.GrpProceso.Size = New System.Drawing.Size(430, 110)
        Me.GrpProceso.TabIndex = 7
        Me.GrpProceso.TabStop = False
        Me.GrpProceso.Text = "Restaurar Base de Datos"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(10, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 15)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Catalogo"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(10, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 22)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Servidor"
        '
        'TxtBD
        '
        Me.TxtBD.Location = New System.Drawing.Point(72, 52)
        Me.TxtBD.Name = "TxtBD"
        Me.TxtBD.ReadOnly = True
        Me.TxtBD.Size = New System.Drawing.Size(207, 20)
        Me.TxtBD.TabIndex = 1
        Me.TxtBD.TabStop = False
        '
        'TxtServer
        '
        Me.TxtServer.Location = New System.Drawing.Point(72, 22)
        Me.TxtServer.Name = "TxtServer"
        Me.TxtServer.ReadOnly = True
        Me.TxtServer.Size = New System.Drawing.Size(207, 20)
        Me.TxtServer.TabIndex = 0
        Me.TxtServer.TabStop = False
        '
        'TxtDireccion
        '
        Me.TxtDireccion.Location = New System.Drawing.Point(72, 79)
        Me.TxtDireccion.Name = "TxtDireccion"
        Me.TxtDireccion.ReadOnly = True
        Me.TxtDireccion.Size = New System.Drawing.Size(308, 20)
        Me.TxtDireccion.TabIndex = 25
        Me.TxtDireccion.TabStop = False
        '
        'LblClave
        '
        Me.LblClave.Location = New System.Drawing.Point(10, 81)
        Me.LblClave.Name = "LblClave"
        Me.LblClave.Size = New System.Drawing.Size(80, 15)
        Me.LblClave.TabIndex = 26
        Me.LblClave.Text = "Respaldo"
        '
        'BtnExaminar
        '
        Me.BtnExaminar.Image = CType(resources.GetObject("BtnExaminar.Image"), System.Drawing.Image)
        Me.BtnExaminar.ImageSize = New System.Drawing.Size(20, 20)
        Me.BtnExaminar.Location = New System.Drawing.Point(387, 72)
        Me.BtnExaminar.Name = "BtnExaminar"
        Me.BtnExaminar.Size = New System.Drawing.Size(33, 30)
        Me.BtnExaminar.TabIndex = 27
        Me.BtnExaminar.ToolTipText = "Buscar archivo de respaldo de bd"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.BackColor = System.Drawing.SystemColors.Control
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BtnCancelar.Location = New System.Drawing.Point(251, 124)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 4
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnAceptar
        '
        Me.BtnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAceptar.Image = CType(resources.GetObject("BtnAceptar.Image"), System.Drawing.Image)
        Me.BtnAceptar.Location = New System.Drawing.Point(347, 124)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(90, 37)
        Me.BtnAceptar.TabIndex = 3
        Me.BtnAceptar.Text = "Aceptar"
        Me.BtnAceptar.ToolTipText = "Inicia restauración de respaldo"
        Me.BtnAceptar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmRestaurar
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(444, 167)
        Me.Controls.Add(Me.BtnAceptar)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.GrpProceso)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmRestaurar"
        Me.Text = "Restaurar Base de Datos "
        Me.GrpProceso.ResumeLayout(False)
        Me.GrpProceso.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private sConexion As String

    Private Function restaurar_basededatos() As Boolean

        Dim sBackup As String = "RESTORE DATABASE " & TxtBD.Text & " FROM DISK = ´" & Me.TxtDireccion.Text & "´" & " WITH REPLACE"


        Using con As New SqlConnection(sConexion)
            Try
                con.Open()
                Dim cmdRestore As New SqlCommand(sBackup, con)
                cmdRestore.ExecuteNonQuery()
                restaurar_basededatos = True
            Catch ex As Exception
                restaurar_basededatos = False
                MessageBox.Show(ex.Message)
            Finally
                con.Close()
            End Try
        End Using
    End Function

    Private Sub FrmRestaurar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        TxtDireccion.Text = ""

        Using con As New SqlConnection(ModPOS.BDConexion)
            TxtBD.Text = con.Database
            TxtServer.Text = con.DataSource
        End Using

        sConexion = ModPOS.BDConexion.Replace(TxtBD.Text, "master")

    End Sub

    Private Sub FrmRestaurar_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.Restaurar.Dispose()
        ModPOS.Restaurar = Nothing

    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub



    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click
        If TxtServer.Text <> "" Then
            If Me.TxtBD.Text <> "" Then
                If TxtDireccion.Text <> "" Then
                    If restaurar_basededatos() = True Then
                        MessageBox.Show("Base de Datos Restaurada satisfactoriamnete", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Error al Restaurar la Base de Datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else
                    MessageBox.Show("Seleccione la ruta donde se tomara el respaldo (Backup)", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            Else
                MessageBox.Show("No fue posible determinar la base de datos a restaurar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Else
            MessageBox.Show("No fue posible determinar el nombre del Servidor de Datos SQL", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub


    Private Sub BtnExaminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExaminar.Click
        Dim openFD As New OpenFileDialog()
        With openFD
            .Title = "Seleccionar archivos de Backup"
            .Filter = "Todos los archivos (*.bak)|*.bak"
            .InitialDirectory = "C:\Backup"
            .Multiselect = False
            If .ShowDialog = System.Windows.Forms.DialogResult.OK Then
                Me.TxtDireccion.Text = .FileName
            End If
        End With

    End Sub
End Class
