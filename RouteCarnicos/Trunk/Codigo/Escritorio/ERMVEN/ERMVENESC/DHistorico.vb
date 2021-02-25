Imports ERMVENLOG
Imports BASMENLOG
Imports BASUSULOG
Imports ERMALMLOG

Public Class DHistorico
    Inherits FormasBase.FrmBase

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
    Friend WithEvents btSalir As Janus.Windows.EditControls.UIButton
    Friend WithEvents lbUsuario As System.Windows.Forms.Label
    Friend WithEvents lbFecha As System.Windows.Forms.Label
    Friend WithEvents grVENCentroDistHist As Janus.Windows.GridEX.GridEX
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim grVENCentroDistHist_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DHistorico))
        Me.grVENCentroDistHist = New Janus.Windows.GridEX.GridEX
        Me.lbUsuario = New System.Windows.Forms.Label
        Me.lbFecha = New System.Windows.Forms.Label
        Me.btSalir = New Janus.Windows.EditControls.UIButton
        CType(Me.grVENCentroDistHist, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grVENCentroDistHist
        '
        Me.grVENCentroDistHist.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.grVENCentroDistHist.AutomaticSort = False
        grVENCentroDistHist_DesignTimeLayout.LayoutString = resources.GetString("grVENCentroDistHist_DesignTimeLayout.LayoutString")
        Me.grVENCentroDistHist.DesignTimeLayout = grVENCentroDistHist_DesignTimeLayout
        Me.grVENCentroDistHist.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.grVENCentroDistHist.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.grVENCentroDistHist.GroupByBoxVisible = False
        Me.grVENCentroDistHist.Location = New System.Drawing.Point(12, 8)
        Me.grVENCentroDistHist.Name = "grVENCentroDistHist"
        Me.grVENCentroDistHist.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow
        Me.grVENCentroDistHist.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grVENCentroDistHist.Size = New System.Drawing.Size(540, 272)
        Me.grVENCentroDistHist.TabIndex = 1
        Me.grVENCentroDistHist.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation
        Me.grVENCentroDistHist.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbUsuario
        '
        Me.lbUsuario.Location = New System.Drawing.Point(12, 284)
        Me.lbUsuario.Name = "lbUsuario"
        Me.lbUsuario.Size = New System.Drawing.Size(292, 16)
        Me.lbUsuario.TabIndex = 2
        Me.lbUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbFecha
        '
        Me.lbFecha.Location = New System.Drawing.Point(324, 284)
        Me.lbFecha.Name = "lbFecha"
        Me.lbFecha.Size = New System.Drawing.Size(224, 16)
        Me.lbFecha.TabIndex = 3
        Me.lbFecha.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btSalir
        '
        Me.btSalir.Icon = CType(resources.GetObject("btSalir.Icon"), System.Drawing.Icon)
        Me.btSalir.Location = New System.Drawing.Point(444, 308)
        Me.btSalir.Name = "btSalir"
        Me.btSalir.Size = New System.Drawing.Size(104, 24)
        Me.btSalir.TabIndex = 4
        Me.btSalir.Text = "Salir"
        Me.btSalir.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'DHistorico
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(562, 340)
        Me.Controls.Add(Me.btSalir)
        Me.Controls.Add(Me.lbFecha)
        Me.Controls.Add(Me.lbUsuario)
        Me.Controls.Add(Me.grVENCentroDistHist)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DHistorico"
        CType(Me.grVENCentroDistHist, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private vcVendedor As cVendedor
    Private vcAlmacen As New cAlmacen
    Private vcMensaje As New CMensaje
    Private vcUsuario As New cUsuario

    Function CONSULTAR(ByRef prVendedor As cVendedor) As Boolean
        Dim ldt As DataTable

        vcVendedor = prVendedor

        Call ConfigurarTitulos()

        ldt = vcAlmacen.Tabla.Recuperar("")
        For Each ldr As DataRow In ldt.Rows
            grVENCentroDistHist.RootTable.Columns("AlmacenId").ValueList.Add(New Janus.Windows.GridEX.GridEXValueListItem(ldr!AlmacenId, ldr!Nombre))
        Next

        grVENCentroDistHist.DataSource = vcVendedor.VENCentroDistHist.ToDataTable()

        Me.Text = vcMensaje.RecuperarDescripcion("ERMVENESC_DHistorico")

        Me.ShowDialog()

    End Function

    Private Sub ConfigurarTitulos()
        Me.btSalir.Text = vcMensaje.RecuperarDescripcion("btSalir")

        Dim vlToolTip As New ToolTip

        With vlToolTip
            .ShowAlways = True
            .SetToolTip(Me.btSalir, vcMensaje.RecuperarDescripcion("BTSalirT"))
        End With


        With grVENCentroDistHist.RootTable
            .Columns("VCHFechaInicial").Caption = vcMensaje.RecuperarDescripcion("VCHVCHFechaInicial")
            .Columns("VCHFechaInicial").HeaderToolTip = vcMensaje.RecuperarDescripcion("VCHVCHFechaInicialT")
            .Columns("AlmacenId").Caption = vcMensaje.RecuperarDescripcion("VCHAlmacenId")
            .Columns("AlmacenId").HeaderToolTip = vcMensaje.RecuperarDescripcion("VCHAlmacenIdT")
            .Columns("FechaFinal").Caption = vcMensaje.RecuperarDescripcion("VCHFechaFinal")
            .Columns("FechaFinal").HeaderToolTip = vcMensaje.RecuperarDescripcion("VCHFechaFinalT")
        End With
    End Sub

    Private Sub grVENCentroDistHist_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grVENCentroDistHist.SelectionChanged
        If grVENCentroDistHist.GetValue("MUsuarioId") <> Nothing Then
            Dim ldt As DataTable
            ldt = vcUsuario.Tabla.Recuperar("USUId='" & grVENCentroDistHist.GetValue("MUsuarioId") & "'")
            If ldt.Rows.Count > 0 Then
                lbUsuario.Text = ldt.Rows(0)!Nombre
            Else
                lbUsuario.Text = ""
            End If
        End If

        lbFecha.Text = grVENCentroDistHist.GetValue("MFechaHora")
    End Sub

    Private Sub btSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSalir.Click
        Me.Close()
    End Sub
End Class
