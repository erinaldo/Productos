Public Class FrmCorte
    Inherits System.Windows.Forms.Form

    Private Periodo As String
    Private Mes As String
    Private iMes As Integer
    Private iPeriodo As Integer

    Public sNombreBackup As String = "Selling.bak"
    Public sRuta As String = ""

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
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents LblClave As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As Janus.Windows.EditControls.UIButton
    Friend WithEvents GrpConfiguracion As System.Windows.Forms.GroupBox
    Friend WithEvents TxtDireccion As System.Windows.Forms.TextBox
    Friend WithEvents TxtNombreRespaldo As System.Windows.Forms.TextBox
    Friend WithEvents BtnActualizar As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCorte))
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.GrpConfiguracion = New System.Windows.Forms.GroupBox
        Me.btnBuscar = New Janus.Windows.EditControls.UIButton
        Me.TxtDireccion = New System.Windows.Forms.TextBox
        Me.LblClave = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtNombreRespaldo = New System.Windows.Forms.TextBox
        Me.BtnActualizar = New Janus.Windows.EditControls.UIButton
        Me.GrpConfiguracion.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.BackColor = System.Drawing.SystemColors.Control
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BtnCancelar.Location = New System.Drawing.Point(246, 103)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 4
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GrpConfiguracion
        '
        Me.GrpConfiguracion.Controls.Add(Me.btnBuscar)
        Me.GrpConfiguracion.Controls.Add(Me.TxtDireccion)
        Me.GrpConfiguracion.Controls.Add(Me.LblClave)
        Me.GrpConfiguracion.Controls.Add(Me.Label3)
        Me.GrpConfiguracion.Controls.Add(Me.TxtNombreRespaldo)
        Me.GrpConfiguracion.Location = New System.Drawing.Point(12, 13)
        Me.GrpConfiguracion.Name = "GrpConfiguracion"
        Me.GrpConfiguracion.Size = New System.Drawing.Size(420, 84)
        Me.GrpConfiguracion.TabIndex = 0
        Me.GrpConfiguracion.TabStop = False
        Me.GrpConfiguracion.Text = "Configuración Respaldo Antes del Corte"
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageSize = New System.Drawing.Size(20, 20)
        Me.btnBuscar.Location = New System.Drawing.Point(380, 37)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(33, 30)
        Me.btnBuscar.TabIndex = 27
        '
        'TxtDireccion
        '
        Me.TxtDireccion.Location = New System.Drawing.Point(66, 45)
        Me.TxtDireccion.Name = "TxtDireccion"
        Me.TxtDireccion.ReadOnly = True
        Me.TxtDireccion.Size = New System.Drawing.Size(307, 20)
        Me.TxtDireccion.TabIndex = 25
        Me.TxtDireccion.TabStop = False
        '
        'LblClave
        '
        Me.LblClave.Location = New System.Drawing.Point(7, 45)
        Me.LblClave.Name = "LblClave"
        Me.LblClave.Size = New System.Drawing.Size(80, 14)
        Me.LblClave.TabIndex = 26
        Me.LblClave.Text = "Guardar en "
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(7, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 22)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Nombre"
        '
        'TxtNombreRespaldo
        '
        Me.TxtNombreRespaldo.Location = New System.Drawing.Point(67, 22)
        Me.TxtNombreRespaldo.Name = "TxtNombreRespaldo"
        Me.TxtNombreRespaldo.ReadOnly = True
        Me.TxtNombreRespaldo.Size = New System.Drawing.Size(200, 20)
        Me.TxtNombreRespaldo.TabIndex = 3
        Me.TxtNombreRespaldo.TabStop = False
        '
        'BtnActualizar
        '
        Me.BtnActualizar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnActualizar.Image = CType(resources.GetObject("BtnActualizar.Image"), System.Drawing.Image)
        Me.BtnActualizar.Location = New System.Drawing.Point(342, 103)
        Me.BtnActualizar.Name = "BtnActualizar"
        Me.BtnActualizar.Size = New System.Drawing.Size(90, 37)
        Me.BtnActualizar.TabIndex = 3
        Me.BtnActualizar.Text = "Ejecutar"
        Me.BtnActualizar.ToolTipText = "Ejecuta Corte de Información al Periodo y Mes indicado"
        Me.BtnActualizar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmCorte
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(439, 150)
        Me.Controls.Add(Me.BtnActualizar)
        Me.Controls.Add(Me.GrpConfiguracion)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCorte"
        Me.Text = "Realizar Corte de Información"
        Me.GrpConfiguracion.ResumeLayout(False)
        Me.GrpConfiguracion.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub FrmBackUp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' 'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)

        'Dim dt As DataTable
        'Try
        '    dt = ModPOS.Recupera_Tabla_No_Msg("sp_obtener_periodo")
        '    If Not dt Is Nothing Then
        '        If dt.Rows.Count > 0 Then
        '            Periodo = CStr(dt.Rows(0)("Periodo"))
        '            iPeriodo = dt.Rows(0)("Periodo")
        '            iMes = dt.Rows(0)("Mes")
        '            Mes = dt.Rows(0)("descripcion")
        '        End If
        '        dt.Dispose()
        '    End If
        'Catch ex As System.Data.SqlClient.SqlException
        'End Try

        sNombreBackup = String.Format("{0:yyyyMMdd}", Today()) & "_" & sNombreBackup
        TxtNombreRespaldo.Text = sNombreBackup
        
    End Sub

    Private Sub FrmCorte_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.Corte.Dispose()
        ModPOS.Corte = Nothing
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub


    Private Sub BtnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnActualizar.Click
        Try

            Try
                If Not Me.TxtDireccion.Text = "" Then
                    Dim i As Integer = TxtDireccion.Text.Length
                    If TxtDireccion.Text.Substring(i - 1) <> "\" Then
                        TxtDireccion.Text = TxtDireccion.Text & "\"
                    End If
                    Cursor.Current = Cursors.WaitCursor
                    ModPOS.Ejecuta_Consulta("BACKUP DATABASE Selling TO DISK = '" & Me.TxtDireccion.Text & sNombreBackup & "'   WITH INIT, NOSKIP, STATS = 10")
                    ModPOS.Ejecuta("sp_corte_datos", Nothing)
                    Cursor.Current = Cursors.Default
                    MsgBox("El corte ha sido realizado exitosamente", MsgBoxStyle.Information, "Información")
                Else
                    MessageBox.Show("Debe seleccionar el directorio donde será almacenado el respaldo antes del corte de datos", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Catch ex As System.Data.SqlClient.SqlException
            End Try

        Catch ex As Exception
            MsgBox("Error al programar el respaldo, comunicarse a soporte tecnico", MsgBoxStyle.Critical, "Error")
        End Try


    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Try
            Dim openDlg As FolderBrowserDialog = New FolderBrowserDialog

            openDlg.Description = "Directorio para almacenar el respaldo de la Base de Dato"
            If (openDlg.ShowDialog() = DialogResult.OK) Then
                sRuta = openDlg.SelectedPath
                TxtDireccion.Text = sRuta
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class
