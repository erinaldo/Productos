Public Class FrmSync
    Inherits System.Windows.Forms.Form

    Private dtCatalogos As DataTable

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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GridCatalogos As Janus.Windows.GridEX.GridEX
    Friend WithEvents UiTabUbica As Janus.Windows.UI.Tab.UITab
    Friend WithEvents UiTabSync As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents ChkTodos As Selling.ChkStatus
    Friend WithEvents BtnActualizar As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSync))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GridCatalogos = New Janus.Windows.GridEX.GridEX()
        Me.UiTabUbica = New Janus.Windows.UI.Tab.UITab()
        Me.BtnActualizar = New Janus.Windows.EditControls.UIButton()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.UiTabSync = New Janus.Windows.UI.Tab.UITabPage()
        Me.ChkTodos = New Selling.ChkStatus(Me.components)
        Me.GroupBox1.SuspendLayout()
        CType(Me.GridCatalogos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiTabUbica, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTabUbica.SuspendLayout()
        Me.UiTabSync.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.GridCatalogos)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 38)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(751, 425)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Sincronizar"
        '
        'GridCatalogos
        '
        Me.GridCatalogos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridCatalogos.ColumnAutoResize = True
        Me.GridCatalogos.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridCatalogos.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridCatalogos.GroupByBoxVisible = False
        Me.GridCatalogos.Location = New System.Drawing.Point(6, 17)
        Me.GridCatalogos.Name = "GridCatalogos"
        Me.GridCatalogos.RecordNavigator = True
        Me.GridCatalogos.Size = New System.Drawing.Size(739, 402)
        Me.GridCatalogos.TabIndex = 50
        Me.GridCatalogos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'UiTabUbica
        '
        Me.UiTabUbica.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UiTabUbica.Location = New System.Drawing.Point(6, 6)
        Me.UiTabUbica.Name = "UiTabUbica"
        Me.UiTabUbica.Size = New System.Drawing.Size(768, 501)
        Me.UiTabUbica.TabIndex = 135
        Me.UiTabUbica.TabPages.AddRange(New Janus.Windows.UI.Tab.UITabPage() {Me.UiTabSync})
        Me.UiTabUbica.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2007
        '
        'BtnActualizar
        '
        Me.BtnActualizar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnActualizar.Image = CType(resources.GetObject("BtnActualizar.Image"), System.Drawing.Image)
        Me.BtnActualizar.Location = New System.Drawing.Point(684, 519)
        Me.BtnActualizar.Name = "BtnActualizar"
        Me.BtnActualizar.Size = New System.Drawing.Size(90, 37)
        Me.BtnActualizar.TabIndex = 3
        Me.BtnActualizar.Text = "Ejecutar"
        Me.BtnActualizar.ToolTipText = "Ejecuta Corte de Información al Periodo y Mes indicado"
        Me.BtnActualizar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.BackColor = System.Drawing.SystemColors.Control
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BtnCancelar.Location = New System.Drawing.Point(588, 519)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 4
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'UiTabSync
        '
        Me.UiTabSync.Controls.Add(Me.ChkTodos)
        Me.UiTabSync.Controls.Add(Me.GroupBox1)
        Me.UiTabSync.Location = New System.Drawing.Point(1, 21)
        Me.UiTabSync.Name = "UiTabSync"
        Me.UiTabSync.Size = New System.Drawing.Size(766, 479)
        Me.UiTabSync.TabStop = True
        Me.UiTabSync.Text = "Sincronización"
        '
        'ChkTodos
        '
        Me.ChkTodos.BackColor = System.Drawing.Color.Transparent
        Me.ChkTodos.Location = New System.Drawing.Point(18, 10)
        Me.ChkTodos.Name = "ChkTodos"
        Me.ChkTodos.Size = New System.Drawing.Size(142, 22)
        Me.ChkTodos.TabIndex = 129
        Me.ChkTodos.Text = "Sincronizar Todo"
        Me.ChkTodos.UseVisualStyleBackColor = False
        '
        'FrmSync
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.UiTabUbica)
        Me.Controls.Add(Me.BtnActualizar)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSync"
        Me.Text = "Sincronización"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.GridCatalogos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiTabUbica, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTabUbica.ResumeLayout(False)
        Me.UiTabSync.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private Sub FrmSync_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.Sync.Dispose()
        ModPOS.Sync = Nothing
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub


 
    Private Sub BtnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnActualizar.Click

        If UiTabUbica.SelectedTab.Name = "UiTabSync" Then


            Dim i As Integer
            Dim frmStatusMessage As New frmStatus
            Dim foundRows() As DataRow

            foundRows = dtCatalogos.Select("Marca ='True' ")

            Cursor.Current = Cursors.WaitCursor
            For i = 0 To foundRows.GetUpperBound(0)

                frmStatusMessage.Show("Sincronizando " & foundRows(i)("Catálogo") & "...")

                ModPOS.Ejecuta_Consulta("exec " & CStr(foundRows(i)("sp")) & " @Server ='" & CStr(foundRows(i)("Server")) & "'")

            Next

            frmStatusMessage.Dispose()
            Cursor.Current = Cursors.Default

            dtCatalogos = ModPOS.Recupera_Tabla("sp_recupera_sync", Nothing)
            If dtCatalogos.Rows.Count > 0 Then
                GridCatalogos.DataSource = dtCatalogos
                GridCatalogos.RetrieveStructure(True)
                GridCatalogos.RootTable.Columns("sp").Visible = False
            End If
      
        End If
    End Sub

    Private Sub FrmSync_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtCatalogos = ModPOS.Recupera_Tabla("sp_recupera_sync", Nothing)
        If dtCatalogos.Rows.Count > 0 Then
            GridCatalogos.DataSource = dtCatalogos
            GridCatalogos.RetrieveStructure(True)
            GridCatalogos.RootTable.Columns("sp").Visible = False
        End If

    End Sub

    Private Sub ChkTodos_CheckedChanged(sender As Object, e As EventArgs) Handles ChkTodos.CheckedChanged
        If dtCatalogos.Rows.Count > 0 Then
            Dim i As Integer
            If ChkTodos.Checked Then
                For i = 0 To GridCatalogos.GetDataRows.Length - 1
                    GridCatalogos.GetDataRows(i).DataRow("Marca") = True
                Next
            Else
                For i = 0 To GridCatalogos.GetDataRows.Length - 1
                    GridCatalogos.GetDataRows(i).DataRow("Marca") = False
                Next
            End If
            dtCatalogos.AcceptChanges()

            GridCatalogos.Refresh()
        End If
    End Sub

    Private Sub GridCatalogos_CellValueChanged(sender As Object, e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridCatalogos.CellValueChanged
        dtCatalogos.AcceptChanges()

        GridCatalogos.Refresh()
    End Sub
End Class
