Public Class RRepMensualHacienda
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
    Friend WithEvents btCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btAbrir As Janus.Windows.EditControls.UIButton
    Friend WithEvents lbNombreT As System.Windows.Forms.Label
    Friend WithEvents lbTipoT As System.Windows.Forms.Label
    Friend WithEvents lbPeriodoT As System.Windows.Forms.Label
    Friend WithEvents lbPeriodo As System.Windows.Forms.Label
    Friend WithEvents lbTipo As System.Windows.Forms.Label
    Friend WithEvents lbNombre As System.Windows.Forms.Label
    Friend WithEvents lbSubEmpresa As System.Windows.Forms.Label
    Friend WithEvents lbSubEmpresaT As System.Windows.Forms.Label
    Friend WithEvents btGuardarComo As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RRepMensualHacienda))
        Me.Label1 = New System.Windows.Forms.Label
        Me.btGuardar = New Janus.Windows.EditControls.UIButton
        Me.btCancelar = New Janus.Windows.EditControls.UIButton
        Me.btAbrir = New Janus.Windows.EditControls.UIButton
        Me.lbNombreT = New System.Windows.Forms.Label
        Me.lbTipoT = New System.Windows.Forms.Label
        Me.lbPeriodoT = New System.Windows.Forms.Label
        Me.lbPeriodo = New System.Windows.Forms.Label
        Me.lbTipo = New System.Windows.Forms.Label
        Me.lbNombre = New System.Windows.Forms.Label
        Me.btGuardarComo = New Janus.Windows.EditControls.UIButton
        Me.lbSubEmpresa = New System.Windows.Forms.Label
        Me.lbSubEmpresaT = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Location = New System.Drawing.Point(8, 114)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(600, 3)
        Me.Label1.TabIndex = 37
        '
        'btGuardar
        '
        Me.btGuardar.Icon = CType(resources.GetObject("btGuardar.Icon"), System.Drawing.Icon)
        Me.btGuardar.Location = New System.Drawing.Point(264, 122)
        Me.btGuardar.Name = "btGuardar"
        Me.btGuardar.Size = New System.Drawing.Size(104, 24)
        Me.btGuardar.TabIndex = 35
        Me.btGuardar.Text = "btGuardar"
        Me.btGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'btCancelar
        '
        Me.btCancelar.CausesValidation = False
        Me.btCancelar.Icon = CType(resources.GetObject("btCancelar.Icon"), System.Drawing.Icon)
        Me.btCancelar.Location = New System.Drawing.Point(504, 122)
        Me.btCancelar.Name = "btCancelar"
        Me.btCancelar.Size = New System.Drawing.Size(104, 24)
        Me.btCancelar.TabIndex = 36
        Me.btCancelar.Text = "btCancelar"
        Me.btCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'btAbrir
        '
        Me.btAbrir.Icon = CType(resources.GetObject("btAbrir.Icon"), System.Drawing.Icon)
        Me.btAbrir.Location = New System.Drawing.Point(144, 122)
        Me.btAbrir.Name = "btAbrir"
        Me.btAbrir.Size = New System.Drawing.Size(104, 24)
        Me.btAbrir.TabIndex = 38
        Me.btAbrir.Text = "btAbrir"
        Me.btAbrir.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'lbNombreT
        '
        Me.lbNombreT.Location = New System.Drawing.Point(72, 8)
        Me.lbNombreT.Name = "lbNombreT"
        Me.lbNombreT.Size = New System.Drawing.Size(104, 23)
        Me.lbNombreT.TabIndex = 39
        Me.lbNombreT.Text = "lbNombreT"
        '
        'lbTipoT
        '
        Me.lbTipoT.Location = New System.Drawing.Point(72, 32)
        Me.lbTipoT.Name = "lbTipoT"
        Me.lbTipoT.Size = New System.Drawing.Size(100, 23)
        Me.lbTipoT.TabIndex = 40
        Me.lbTipoT.Text = "lbTipoT"
        '
        'lbPeriodoT
        '
        Me.lbPeriodoT.Location = New System.Drawing.Point(72, 78)
        Me.lbPeriodoT.Name = "lbPeriodoT"
        Me.lbPeriodoT.Size = New System.Drawing.Size(100, 23)
        Me.lbPeriodoT.TabIndex = 41
        Me.lbPeriodoT.Text = "lbPeriodoT"
        '
        'lbPeriodo
        '
        Me.lbPeriodo.AutoSize = True
        Me.lbPeriodo.Location = New System.Drawing.Point(168, 78)
        Me.lbPeriodo.Name = "lbPeriodo"
        Me.lbPeriodo.Size = New System.Drawing.Size(51, 13)
        Me.lbPeriodo.TabIndex = 44
        Me.lbPeriodo.Text = "lbPeriodo"
        '
        'lbTipo
        '
        Me.lbTipo.AutoSize = True
        Me.lbTipo.Location = New System.Drawing.Point(168, 32)
        Me.lbTipo.Name = "lbTipo"
        Me.lbTipo.Size = New System.Drawing.Size(36, 13)
        Me.lbTipo.TabIndex = 43
        Me.lbTipo.Text = "lbTipo"
        '
        'lbNombre
        '
        Me.lbNombre.AutoSize = True
        Me.lbNombre.Location = New System.Drawing.Point(168, 8)
        Me.lbNombre.Name = "lbNombre"
        Me.lbNombre.Size = New System.Drawing.Size(52, 13)
        Me.lbNombre.TabIndex = 42
        Me.lbNombre.Text = "lbNombre"
        '
        'btGuardarComo
        '
        Me.btGuardarComo.Icon = CType(resources.GetObject("btGuardarComo.Icon"), System.Drawing.Icon)
        Me.btGuardarComo.Location = New System.Drawing.Point(384, 122)
        Me.btGuardarComo.Name = "btGuardarComo"
        Me.btGuardarComo.Size = New System.Drawing.Size(104, 24)
        Me.btGuardarComo.TabIndex = 45
        Me.btGuardarComo.Text = "btGuardarComo"
        Me.btGuardarComo.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'lbSubEmpresa
        '
        Me.lbSubEmpresa.Location = New System.Drawing.Point(168, 55)
        Me.lbSubEmpresa.Name = "lbSubEmpresa"
        Me.lbSubEmpresa.Size = New System.Drawing.Size(275, 23)
        Me.lbSubEmpresa.TabIndex = 41
        Me.lbSubEmpresa.Text = "lbSubEmpresa"
        '
        'lbSubEmpresaT
        '
        Me.lbSubEmpresaT.AutoSize = True
        Me.lbSubEmpresaT.Location = New System.Drawing.Point(72, 55)
        Me.lbSubEmpresaT.Name = "lbSubEmpresaT"
        Me.lbSubEmpresaT.Size = New System.Drawing.Size(75, 13)
        Me.lbSubEmpresaT.TabIndex = 44
        Me.lbSubEmpresaT.Text = "lbSubEmpresa"
        '
        'RRepMensualHacienda
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(622, 158)
        Me.Controls.Add(Me.btGuardarComo)
        Me.Controls.Add(Me.lbSubEmpresaT)
        Me.Controls.Add(Me.lbPeriodo)
        Me.Controls.Add(Me.lbTipo)
        Me.Controls.Add(Me.lbNombre)
        Me.Controls.Add(Me.lbSubEmpresa)
        Me.Controls.Add(Me.lbPeriodoT)
        Me.Controls.Add(Me.lbTipoT)
        Me.Controls.Add(Me.lbNombreT)
        Me.Controls.Add(Me.btAbrir)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btGuardar)
        Me.Controls.Add(Me.btCancelar)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "RRepMensualHacienda"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "RRepMensualHacienda"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region "VARIABLES"
    Private vcMensaje As New BASMENLOG.CMensaje
    Private vgMes As String
    Private vgAnio As Integer
    Private vgSubEmpresa As String
    Private vgDatos As ERMCEFLOG.cRepMensualHacienda
#End Region

#Region "PROPIEDADES"
    Public Property mes() As String
        Get
            Return vgMes
        End Get
        Set(ByVal Value As String)
            vgMes = Value
        End Set
    End Property
    Public Property anio() As Integer
        Get
            Return vgAnio
        End Get
        Set(ByVal Value As Integer)
            vgAnio = Value
        End Set

    End Property

    Public Property SubEmpresaId() As String
        Get
            Return vgSubEmpresa
        End Get
        Set(ByVal Value As String)
            vgSubEmpresa = Value
        End Set

    End Property

    Public ReadOnly Property periodo() As String
        Get
            Return Format(New Date(CInt(anio), CInt(mes), 1), "MMMM") & " " & anio
        End Get
    End Property
 
#End Region

#Region "FUNCIONES GENERALES"
    Public Sub CargarForma()
        iniciarpantalla()
        vgDatos = New ERMCEFLOG.cRepMensualHacienda
        Dim subempresa As New ERMSEMLOG.cSubEmpresa
        Try
            vgDatos.cargarDatos(anio, mes, vgSubEmpresa)
            Me.lbNombre.Text = vgDatos.FILE_NAME
            Me.lbTipo.Text = vgDatos.Tipo
            subempresa.Recuperar(vgSubEmpresa)
            lbSubEmpresa.Text = subempresa.NombreEmpresa
            Me.ShowDialog()

            Me.Close()
        Catch ex As LbControlError.cError
            ex.Mostrar()
            Me.Close()
        End Try
    End Sub

    Private Sub iniciarpantalla()
        Me.Text = vcMensaje.RecuperarDescripcion("ERMCEFESC_PRepMensualGuardar")
        Me.lbNombreT.Text = vcMensaje.RecuperarDescripcion("XNombre")
        Me.lbTipoT.Text = vcMensaje.RecuperarDescripcion("XTipo")
        Me.lbPeriodoT.Text = vcMensaje.RecuperarDescripcion("XPeriodo")
        lbSubEmpresaT.Text = vcMensaje.RecuperarDescripcion("XSubEmpresa")


        Me.btAbrir.Text = vcMensaje.RecuperarDescripcion("BtAbrir")
        Me.btAbrir.ToolTipText = vcMensaje.RecuperarDescripcion("BtAbrir")
        Me.btCancelar.Text = vcMensaje.RecuperarDescripcion("BtCancelar")
        Me.btCancelar.ToolTipText = vcMensaje.RecuperarDescripcion("BtCancelarT")
        Me.btGuardar.Text = vcMensaje.RecuperarDescripcion("BtGuardar")
        Me.btGuardar.ToolTipText = vcMensaje.RecuperarDescripcion("BtAceptarT")
        Me.btGuardarComo.Text = vcMensaje.RecuperarDescripcion("BtGuardarComo")
        Me.btGuardarComo.ToolTipText = vcMensaje.RecuperarDescripcion("BtGuardarComoT")
    End Sub

#End Region

#Region "BOTONES"


    Private Sub btAbrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAbrir.Click
        Dim fRep As New VRepMensual
        fRep.vgDatos = vgDatos
        Me.Close()
        fRep.ShowDialog()
    End Sub

    Private Sub btCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCancelar.Click
        Me.Close()
    End Sub

    Private Sub btGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btGuardar.Click
        vgDatos.generarArchivo()
        Me.Close()
    End Sub

    Private Sub btGuardarComo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btGuardarComo.Click
        Dim FBD As New FolderBrowserDialog
        FBD.SelectedPath = vgDatos.PATH

        If FBD.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If vgDatos.PATH <> FBD.SelectedPath Then
                vgDatos.PATH = FBD.SelectedPath
                vgDatos.generarArchivo()
            End If
            Me.Close()
        End If

    End Sub
#End Region

End Class
