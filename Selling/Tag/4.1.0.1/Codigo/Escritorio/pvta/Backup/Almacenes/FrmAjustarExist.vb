Imports System.Data.SqlClient

Public Class FrmAjustarExist
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
    Friend WithEvents GrpPasillo As System.Windows.Forms.GroupBox
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnAgregar As Janus.Windows.EditControls.UIButton
    Friend WithEvents LblMovimiento As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LblNombre As System.Windows.Forms.Label
    Friend WithEvents LblUbicacion As System.Windows.Forms.Label
    Friend WithEvents LblClave As System.Windows.Forms.Label
    Friend WithEvents TxtNota As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtExistencia As Janus.Windows.GridEX.EditControls.NumericEditBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAjustarExist))
        Me.GrpPasillo = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtExistencia = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.LblMovimiento = New System.Windows.Forms.Label
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton
        Me.LblNombre = New System.Windows.Forms.Label
        Me.LblUbicacion = New System.Windows.Forms.Label
        Me.LblClave = New System.Windows.Forms.Label
        Me.TxtNota = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.GrpPasillo.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrpPasillo
        '
        Me.GrpPasillo.Controls.Add(Me.Label1)
        Me.GrpPasillo.Controls.Add(Me.TxtExistencia)
        Me.GrpPasillo.Controls.Add(Me.LblMovimiento)
        Me.GrpPasillo.Location = New System.Drawing.Point(7, 66)
        Me.GrpPasillo.Name = "GrpPasillo"
        Me.GrpPasillo.Size = New System.Drawing.Size(293, 62)
        Me.GrpPasillo.TabIndex = 0
        Me.GrpPasillo.TabStop = False
        Me.GrpPasillo.Text = "Existencia"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label1.Location = New System.Drawing.Point(12, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 15)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Ajuste: "
        '
        'TxtExistencia
        '
        Me.TxtExistencia.DecimalDigits = 2
        Me.TxtExistencia.Location = New System.Drawing.Point(11, 19)
        Me.TxtExistencia.Name = "TxtExistencia"
        Me.TxtExistencia.Size = New System.Drawing.Size(261, 20)
        Me.TxtExistencia.TabIndex = 3
        Me.TxtExistencia.Text = "0.00"
        Me.TxtExistencia.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtExistencia.Value = 0
        Me.TxtExistencia.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'LblMovimiento
        '
        Me.LblMovimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.LblMovimiento.Location = New System.Drawing.Point(81, 42)
        Me.LblMovimiento.Name = "LblMovimiento"
        Me.LblMovimiento.Size = New System.Drawing.Size(127, 15)
        Me.LblMovimiento.TabIndex = 9
        Me.LblMovimiento.Text = "0.00"
        Me.LblMovimiento.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.BtnCancelar.Icon = CType(resources.GetObject("BtnCancelar.Icon"), System.Drawing.Icon)
        Me.BtnCancelar.Location = New System.Drawing.Point(111, 171)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 2
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAgregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.BtnAgregar.Icon = CType(resources.GetObject("BtnAgregar.Icon"), System.Drawing.Icon)
        Me.BtnAgregar.Location = New System.Drawing.Point(210, 171)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(90, 37)
        Me.BtnAgregar.TabIndex = 1
        Me.BtnAgregar.Text = "&Aceptar"
        Me.BtnAgregar.ToolTipText = "Guardar cambios"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'LblNombre
        '
        Me.LblNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNombre.Location = New System.Drawing.Point(8, 26)
        Me.LblNombre.Name = "LblNombre"
        Me.LblNombre.Size = New System.Drawing.Size(290, 15)
        Me.LblNombre.TabIndex = 11
        Me.LblNombre.Text = "Descripción"
        '
        'LblUbicacion
        '
        Me.LblUbicacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblUbicacion.Location = New System.Drawing.Point(8, 45)
        Me.LblUbicacion.Name = "LblUbicacion"
        Me.LblUbicacion.Size = New System.Drawing.Size(290, 15)
        Me.LblUbicacion.TabIndex = 12
        Me.LblUbicacion.Text = "Ubicación: "
        '
        'LblClave
        '
        Me.LblClave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblClave.Location = New System.Drawing.Point(8, 8)
        Me.LblClave.Name = "LblClave"
        Me.LblClave.Size = New System.Drawing.Size(290, 15)
        Me.LblClave.TabIndex = 13
        Me.LblClave.Text = "Clave:"
        '
        'TxtNota
        '
        Me.TxtNota.Location = New System.Drawing.Point(57, 143)
        Me.TxtNota.Name = "TxtNota"
        Me.TxtNota.Size = New System.Drawing.Size(242, 20)
        Me.TxtNota.TabIndex = 14
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(4, 147)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 15)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Motivo: "
        '
        'FrmAjustarExist
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(308, 211)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtNota)
        Me.Controls.Add(Me.LblClave)
        Me.Controls.Add(Me.LblUbicacion)
        Me.Controls.Add(Me.LblNombre)
        Me.Controls.Add(Me.BtnAgregar)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.GrpPasillo)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmAjustarExist"
        Me.Text = "Ajuste de Existencia"
        Me.GrpPasillo.ResumeLayout(False)
        Me.GrpPasillo.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Public ExistActual As Double
    Public ExistNueva As Double
    Public ALMClave As String
    Public PROClave As String
    Public Nombre As String
    Public UBCClave As String
    Public Clave As String
    Public Ubicacion As String

    Private Sub FrmAjustarExist_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        TxtExistencia.Text = CStr(ExistActual)
        LblNombre.Text = Nombre
        LblUbicacion.Text = "Ubicación: " & Ubicacion
        LblClave.Text = "Clave: " & Clave
    End Sub

    Private Sub AjustarExist_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.AjustarExist.Dispose()
        ModPOS.AjustarExist = Nothing
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub


    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        If TxtNota.Text = "" Then
            MessageBox.Show("Es requerida la descripción del motivo del ajuste", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        ElseIf TxtNota.Text.Length > 50 Then
            MessageBox.Show("La descripción del motivo de ajuste sobrepasa el maximo de caracters permitidos (50)", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If TxtExistencia.Text = "" Then
            ExistNueva = 0
        Else
            ExistNueva = CDbl(TxtExistencia.Text)
        End If

        If ExistNueva >= 0 Then
            Dim CantAjuste As Double = 0
            CantAjuste = ExistNueva - ExistActual

            If CantAjuste <> 0 Then

                'Dim dMonto As Double

                'Dim dt As DataTable
                'dt = ModPOS.Recupera_Tabla("sp_recupera_costo", "@PROClave", PROClave)
                'dMonto = CantAjuste * dt.Rows(0)("Costo")
                'dt.Dispose()

                'Dim a As New MeAutorizacion
                'a.Almacen = ALMClave
                'a.MontodeAutorizacion = Math.Abs(dMonto)
                'a.ShowDialog()
                'If a.DialogResult = DialogResult.OK Then
                '    If a.Autorizado Then
                ModPOS.Ejecuta("sp_ajusta_exist_ubc", _
                                "@ALMClave", ALMClave, _
                                "@Diferencia", CantAjuste, _
                                "@UBCClave", UBCClave, _
                                "@PROClave", PROClave, _
                                "@Nota", TxtNota.Text.ToUpper.Trim.Replace("'", ""), _
                                "@Usuario", ModPOS.UsuarioActual)


            End If
            LblMovimiento.Text = CStr(Redondear(CantAjuste, 2))
            MessageBox.Show("Productos Ajustados: " & CStr(Redondear(CantAjuste, 2)), "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ModPOS.MtoExistencia.recuperaExistencia(2, "")
            Me.Close()
        Else
            Beep()
            MessageBox.Show("¡La cantidad debe ser mayor o igual a cero!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub


    
End Class
