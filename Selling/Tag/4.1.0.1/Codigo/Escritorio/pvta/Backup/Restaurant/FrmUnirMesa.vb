Public Class FrmUnirMesa
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
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents GrpOrigen As System.Windows.Forms.GroupBox
    Friend WithEvents PnlOrigen As System.Windows.Forms.Panel
    Friend WithEvents TxtOrigen As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents pnlDestino As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtDestino As System.Windows.Forms.TextBox
    Friend WithEvents LblOrigen As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmUnirMesa))
        Me.GrpOrigen = New System.Windows.Forms.GroupBox
        Me.PnlOrigen = New System.Windows.Forms.Panel
        Me.LblOrigen = New System.Windows.Forms.Label
        Me.TxtOrigen = New System.Windows.Forms.TextBox
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.pnlDestino = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtDestino = New System.Windows.Forms.TextBox
        Me.GrpOrigen.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrpOrigen
        '
        Me.GrpOrigen.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpOrigen.Controls.Add(Me.PnlOrigen)
        Me.GrpOrigen.Controls.Add(Me.LblOrigen)
        Me.GrpOrigen.Controls.Add(Me.TxtOrigen)
        Me.GrpOrigen.Location = New System.Drawing.Point(10, 11)
        Me.GrpOrigen.Name = "GrpOrigen"
        Me.GrpOrigen.Size = New System.Drawing.Size(502, 60)
        Me.GrpOrigen.TabIndex = 1
        Me.GrpOrigen.TabStop = False
        '
        'PnlOrigen
        '
        Me.PnlOrigen.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PnlOrigen.BackColor = System.Drawing.Color.White
        Me.PnlOrigen.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PnlOrigen.Location = New System.Drawing.Point(463, 14)
        Me.PnlOrigen.Name = "PnlOrigen"
        Me.PnlOrigen.Size = New System.Drawing.Size(33, 35)
        Me.PnlOrigen.TabIndex = 1
        '
        'LblOrigen
        '
        Me.LblOrigen.BackColor = System.Drawing.Color.Transparent
        Me.LblOrigen.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold)
        Me.LblOrigen.ForeColor = System.Drawing.Color.MidnightBlue
        Me.LblOrigen.Location = New System.Drawing.Point(5, 20)
        Me.LblOrigen.Name = "LblOrigen"
        Me.LblOrigen.Size = New System.Drawing.Size(164, 27)
        Me.LblOrigen.TabIndex = 66
        Me.LblOrigen.Text = "PRINCIPAL"
        Me.LblOrigen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtOrigen
        '
        Me.TxtOrigen.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtOrigen.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtOrigen.Location = New System.Drawing.Point(183, 15)
        Me.TxtOrigen.Name = "TxtOrigen"
        Me.TxtOrigen.Size = New System.Drawing.Size(276, 38)
        Me.TxtOrigen.TabIndex = 0
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.Location = New System.Drawing.Point(422, 165)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 50)
        Me.BtnGuardar.TabIndex = 3
        Me.BtnGuardar.Text = "&Aceptar"
        Me.BtnGuardar.ToolTipText = "Guardar cambios"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(326, 165)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 50)
        Me.BtnCancelar.TabIndex = 4
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.pnlDestino)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.TxtDestino)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 86)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(502, 61)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'pnlDestino
        '
        Me.pnlDestino.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlDestino.BackColor = System.Drawing.Color.White
        Me.pnlDestino.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlDestino.Location = New System.Drawing.Point(463, 14)
        Me.pnlDestino.Name = "pnlDestino"
        Me.pnlDestino.Size = New System.Drawing.Size(33, 35)
        Me.pnlDestino.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label1.Location = New System.Drawing.Point(5, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(173, 27)
        Me.Label1.TabIndex = 66
        Me.Label1.Text = "ADICIONAL"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtDestino
        '
        Me.TxtDestino.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtDestino.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDestino.Location = New System.Drawing.Point(183, 15)
        Me.TxtDestino.Name = "TxtDestino"
        Me.TxtDestino.Size = New System.Drawing.Size(276, 38)
        Me.TxtDestino.TabIndex = 0
        '
        'FrmUnirMesa
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(522, 218)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GrpOrigen)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(448, 238)
        Me.Name = "FrmUnirMesa"
        Me.Text = "Unir Mesas"
        Me.GrpOrigen.ResumeLayout(False)
        Me.GrpOrigen.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region


    Public PISClave As String
    Public PDVClave As String

    Private PrincipalO, PrincipalD As String
    Private EstadoP As Integer
    Private cMesaOcupada, cMesaDisponible, cMesaSucia As Integer

    Private Sub FrmUnirMesa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dtPiso As DataTable
        dtPiso = ModPOS.Recupera_Tabla("sp_recupera_piso", "@Piso", PISClave)
        cMesaOcupada = dtPiso.Rows(0)("cMesaOcupada")
        cMesaDisponible = dtPiso.Rows(0)("cMesaDisponible")
        cMesaSucia = dtPiso.Rows(0)("cMesaSucia")


        dtPiso.Dispose()

    End Sub



    Private Sub TxtOrigen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtOrigen.Click
        Dim a As New FrmTecladoNum
        a.Text = "Clave de Mesa Principal"
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            Me.TxtOrigen.Text = a.Cantidad
            TxtDestino.Focus()
        End If
        a.Dispose()
    End Sub

    Private Sub TxtDestino_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDestino.Click
        Dim a As New FrmTecladoNum
        a.Text = "Clave de Mesa Adicional"
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            Me.TxtDestino.Text = a.Cantidad
            Me.BtnGuardar.Focus()
        End If
        a.Dispose()
    End Sub


    Private Sub TxtOrigen_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtOrigen.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TxtDestino.Focus()
        End If
    End Sub

    Private Sub TxtDestino_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDestino.KeyPress
        If Asc(e.KeyChar) = 13 Then
            BtnGuardar.Focus()
        End If
    End Sub

    Private Sub TxtOrigen_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtOrigen.Leave
        'Recuerpa mesa
        Dim dtMesa As DataTable

        If TxtOrigen.Text <> "" Then
            dtMesa = ModPOS.Recupera_Tabla("sp_recupera_mesa", "@PISClave", PISClave, "@Clave", TxtOrigen.Text)

            If dtMesa.Rows.Count > 0 Then
                Select Case CInt(dtMesa.Rows(0)("Estado"))
                    Case 1
                        PnlOrigen.BackColor = System.Drawing.Color.FromArgb(cMesaDisponible)
                    Case 2
                        PnlOrigen.BackColor = System.Drawing.Color.FromArgb(cMesaOcupada)
                    Case 3
                        PnlOrigen.BackColor = System.Drawing.Color.FromArgb(cMesaSucia)
                End Select
                EstadoP = dtMesa.Rows(0)("Estado")
                PrincipalO = dtMesa.Rows(0)("Principal")
                dtMesa.Dispose()


               
            End If
        Else
            PrincipalO = ""
        End If

    End Sub

    Private Sub TxtDestino_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDestino.Leave

        Dim dtMesa, dtComanda As DataTable

        Dim Estado As Integer

        If TxtDestino.Text <> "" Then
            dtMesa = ModPOS.Recupera_Tabla("sp_recupera_mesa", "@PISClave", PISClave, "@Clave", TxtDestino.Text)

            If dtMesa.Rows.Count > 0 Then
                Select Case CInt(dtMesa.Rows(0)("Estado"))
                    Case 1
                        pnlDestino.BackColor = System.Drawing.Color.FromArgb(cMesaDisponible)
                    Case 2
                        pnlDestino.BackColor = System.Drawing.Color.FromArgb(cMesaOcupada)
                    Case 3
                        pnlDestino.BackColor = System.Drawing.Color.FromArgb(cMesaSucia)
                End Select

                PrincipalD = dtMesa.Rows(0)("Principal")
                Estado = dtMesa.Rows(0)("Estado")
                dtMesa.Dispose()


                If Estado = 2 Then
                    MessageBox.Show("No es posible agregar la mesa adicional debido a que se encuentra ocupada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    TxtDestino.Text = ""
                    PrincipalD = ""
                    pnlDestino.BackColor = Color.White
                    Exit Sub
                End If

                dtComanda = ModPOS.SiExisteRecupera("sp_recupera_comandaopen", "@PDVClave", PDVClave, "@MESClave", PrincipalD, "@Tipo", 5)

                If Not dtComanda Is Nothing Then
                    MessageBox.Show("Se encontraron comandas abiertas asociadas a la mesa destino por lo que no es posible realizar el cambio de mesa", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    TxtDestino.Text = ""
                    PrincipalD = ""
                    TxtDestino.Focus()
                    pnlDestino.BackColor = Color.White
                End If



            End If
        Else
            PrincipalD = ""
        End If


    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If PrincipalO <> "" AndAlso PrincipalD <> "" Then
            ModPOS.Ejecuta("sp_unir_mesa", "@Principal", PrincipalO, "@Adicional", PrincipalD, "@Estado", EstadoP)
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        Else
            MessageBox.Show("No es posible realizar el cambio ya que se deben especificar las 2 meseas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub
End Class
