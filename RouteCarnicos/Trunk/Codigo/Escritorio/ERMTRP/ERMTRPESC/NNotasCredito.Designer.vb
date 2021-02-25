<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NNotasCredito
    Inherits FormasBase.Browse01

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim GridEx1_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NNotasCredito))
        Me.btCrear = New DevComponents.DotNetBar.ButtonItem
        Me.btCancelar = New DevComponents.DotNetBar.ButtonItem
        Me.btImprimir = New DevComponents.DotNetBar.ButtonItem
        Me.btActualizar = New DevComponents.DotNetBar.ButtonItem
        Me.btConsultar = New DevComponents.DotNetBar.ButtonItem
        Me.btXML = New DevComponents.DotNetBar.ButtonItem
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridEx1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btCrear, Me.btConsultar, Me.btCancelar, Me.btImprimir, Me.btXML, Me.btActualizar})
        '
        'GridEx1
        '
        Me.GridEx1.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridEx1.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        GridEx1_DesignTimeLayout.LayoutString = resources.GetString("GridEx1_DesignTimeLayout.LayoutString")
        Me.GridEx1.DesignTimeLayout = GridEx1_DesignTimeLayout
        '
        'btCrear
        '
        Me.btCrear.Icon = CType(resources.GetObject("btCrear.Icon"), System.Drawing.Icon)
        Me.btCrear.Name = "btCrear"
        Me.btCrear.Text = "ButtonItem1"
        '
        'btCancelar
        '
        Me.btCancelar.Icon = CType(resources.GetObject("btCancelar.Icon"), System.Drawing.Icon)
        Me.btCancelar.Name = "btCancelar"
        Me.btCancelar.Text = "ButtonItem3"
        '
        'btImprimir
        '
        Me.btImprimir.Icon = CType(resources.GetObject("btImprimir.Icon"), System.Drawing.Icon)
        Me.btImprimir.Name = "btImprimir"
        Me.btImprimir.Text = "ButtonItem4"
        '
        'btActualizar
        '
        Me.btActualizar.Icon = CType(resources.GetObject("btActualizar.Icon"), System.Drawing.Icon)
        Me.btActualizar.Name = "btActualizar"
        Me.btActualizar.Text = "ButtonItem7"
        '
        'btConsultar
        '
        Me.btConsultar.DisabledImage = CType(resources.GetObject("btConsultar.DisabledImage"), System.Drawing.Image)
        Me.btConsultar.Icon = CType(resources.GetObject("btConsultar.Icon"), System.Drawing.Icon)
        Me.btConsultar.Name = "btConsultar"
        Me.btConsultar.Text = "btConsultar"
        '
        'btXML
        '
        Me.btXML.Icon = CType(resources.GetObject("btXML.Icon"), System.Drawing.Icon)
        Me.btXML.Name = "btXML"
        Me.btXML.Text = "btXML"
        '
        'NNotasCredito
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.CausesValidation = False
        Me.ClientSize = New System.Drawing.Size(844, 666)
        Me.Name = "NNotasCredito"
        Me.Text = "NNotasCredito"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridEx1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btCrear As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btCancelar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btImprimir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btActualizar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btConsultar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btXML As DevComponents.DotNetBar.ButtonItem
End Class
