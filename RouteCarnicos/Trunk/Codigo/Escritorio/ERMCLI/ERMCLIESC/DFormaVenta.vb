Public Class DFormaVenta
    Inherits FormasBase.FrmBase

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()

    End Sub

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms requiere el siguiente procedimiento
    'Puede modificarse utilizando el Diseñador de Windows Forms. 
    'No lo modifique con el editor de código.
    Friend WithEvents btAceptar As Janus.Windows.EditControls.UIButton
    Friend WithEvents lbLinea As System.Windows.Forms.Label
    Friend WithEvents cbCFVTipo As Janus.Windows.EditControls.UIComboBox
    Friend WithEvents lbCFVTipo As System.Windows.Forms.Label
    Friend WithEvents grCFVHist As Janus.Windows.GridEX.GridEX
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim grCFVHist_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DFormaVenta))
        Me.grCFVHist = New Janus.Windows.GridEX.GridEX
        Me.cbCFVTipo = New Janus.Windows.EditControls.UIComboBox
        Me.lbCFVTipo = New System.Windows.Forms.Label
        Me.btAceptar = New Janus.Windows.EditControls.UIButton
        Me.lbLinea = New System.Windows.Forms.Label
        CType(Me.grCFVHist, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grCFVHist
        '
        Me.grCFVHist.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        grCFVHist_DesignTimeLayout.LayoutString = resources.GetString("grCFVHist_DesignTimeLayout.LayoutString")
        Me.grCFVHist.DesignTimeLayout = grCFVHist_DesignTimeLayout
        Me.grCFVHist.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.grCFVHist.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.grCFVHist.GroupByBoxVisible = False
        Me.grCFVHist.Location = New System.Drawing.Point(8, 36)
        Me.grCFVHist.Name = "grCFVHist"
        Me.grCFVHist.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow
        Me.grCFVHist.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grCFVHist.Size = New System.Drawing.Size(628, 284)
        Me.grCFVHist.TabIndex = 506
        Me.grCFVHist.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation
        Me.grCFVHist.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'cbCFVTipo
        '
        Me.cbCFVTipo.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList
        Me.cbCFVTipo.Enabled = False
        Me.cbCFVTipo.Location = New System.Drawing.Point(144, 8)
        Me.cbCFVTipo.Name = "cbCFVTipo"
        Me.cbCFVTipo.Size = New System.Drawing.Size(201, 20)
        Me.cbCFVTipo.TabIndex = 507
        Me.cbCFVTipo.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'lbCFVTipo
        '
        Me.lbCFVTipo.BackColor = System.Drawing.Color.Transparent
        Me.lbCFVTipo.Location = New System.Drawing.Point(8, 8)
        Me.lbCFVTipo.Name = "lbCFVTipo"
        Me.lbCFVTipo.Size = New System.Drawing.Size(132, 20)
        Me.lbCFVTipo.TabIndex = 508
        Me.lbCFVTipo.Text = "Tipo"
        Me.lbCFVTipo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btAceptar
        '
        Me.btAceptar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btAceptar.Icon = CType(resources.GetObject("btAceptar.Icon"), System.Drawing.Icon)
        Me.btAceptar.Location = New System.Drawing.Point(532, 340)
        Me.btAceptar.Name = "btAceptar"
        Me.btAceptar.Size = New System.Drawing.Size(104, 24)
        Me.btAceptar.TabIndex = 509
        Me.btAceptar.Text = "Aceptar"
        Me.btAceptar.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'lbLinea
        '
        Me.lbLinea.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbLinea.Location = New System.Drawing.Point(4, 328)
        Me.lbLinea.Name = "lbLinea"
        Me.lbLinea.Size = New System.Drawing.Size(632, 3)
        Me.lbLinea.TabIndex = 510
        '
        'DFormaVenta
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(646, 372)
        Me.Controls.Add(Me.lbLinea)
        Me.Controls.Add(Me.btAceptar)
        Me.Controls.Add(Me.cbCFVTipo)
        Me.Controls.Add(Me.lbCFVTipo)
        Me.Controls.Add(Me.grCFVHist)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DFormaVenta"
        CType(Me.grCFVHist, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Variables"
    Private oMensaje As New BASMENLOG.CMensaje
#End Region

#Region " Funciones "
    Public Sub CONSULTAR(ByRef prCLIFormaVenta As ERMCLILOG.cCLIFormaVenta)
        Me.Text = oMensaje.RecuperarDescripcion("ERMCLIESC_DFormaVenta")
        ConfigurarTitulos()
        ConfigurarGrid()

        cbCFVTipo.SelectedValue = prCLIFormaVenta.CFVTipo
        grCFVHist.DataSource = prCLIFormaVenta.CFVHist.ToDataTable
        Me.ShowDialog()
    End Sub

    Private Sub ConfigurarTitulos()
        Dim vlToolTip As New ToolTip
        Me.btAceptar.Text = oMensaje.RecuperarDescripcion("btSalir")

        With vlToolTip
            .ShowAlways = True
            .SetToolTip(Me.btAceptar, oMensaje.RecuperarDescripcion("btSalirT"))
        End With
    End Sub

    Private Sub ConfigurarGrid()
        Dim vlColumna As Janus.Windows.GridEX.GridEXColumn
        For Each vlColumna In grCFVHist.RootTable.Columns
            vlColumna.Caption = oMensaje.RecuperarDescripcion("CFH" + vlColumna.Key)
            vlColumna.HeaderToolTip = oMensaje.RecuperarDescripcion("CFH" + vlColumna.Key + "T")
        Next

        lbGeneral.LlenarComboBox(cbCFVTipo, "FVENTA")
    End Sub
#End Region

    Private Sub btAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAceptar.Click
        Me.Close()
    End Sub
End Class
