Public Class FrmValores
    Inherits System.Windows.Forms.Form

    Public Tabla As String
    Public Campo As String
    Public Tipo As String

    Private dtValores As DataTable
    Private sValor As String


    Friend WithEvents GrpSucursales As System.Windows.Forms.GroupBox
    Friend WithEvents BtnAdd As Janus.Windows.EditControls.UIButton
    Friend WithEvents GridValores As Janus.Windows.GridEX.GridEX
    Friend WithEvents BtnDel As Janus.Windows.EditControls.UIButton

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
    Friend WithEvents BtnOk As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmValores))
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.BtnOk = New Janus.Windows.EditControls.UIButton
        Me.GrpSucursales = New System.Windows.Forms.GroupBox
        Me.GridValores = New Janus.Windows.GridEX.GridEX
        Me.BtnAdd = New Janus.Windows.EditControls.UIButton
        Me.BtnDel = New Janus.Windows.EditControls.UIButton
        Me.GrpSucursales.SuspendLayout()
        CType(Me.GridValores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(399, 523)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 5
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnOk
        '
        Me.BtnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnOk.Image = CType(resources.GetObject("BtnOk.Image"), System.Drawing.Image)
        Me.BtnOk.Location = New System.Drawing.Point(495, 523)
        Me.BtnOk.Name = "BtnOk"
        Me.BtnOk.Size = New System.Drawing.Size(90, 37)
        Me.BtnOk.TabIndex = 4
        Me.BtnOk.Text = "&Aceptar"
        Me.BtnOk.ToolTipText = "Guardar cambios"
        Me.BtnOk.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GrpSucursales
        '
        Me.GrpSucursales.Controls.Add(Me.GridValores)
        Me.GrpSucursales.Controls.Add(Me.BtnCancelar)
        Me.GrpSucursales.Controls.Add(Me.BtnAdd)
        Me.GrpSucursales.Controls.Add(Me.BtnOk)
        Me.GrpSucursales.Controls.Add(Me.BtnDel)
        Me.GrpSucursales.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpSucursales.Location = New System.Drawing.Point(0, 0)
        Me.GrpSucursales.Name = "GrpSucursales"
        Me.GrpSucursales.Size = New System.Drawing.Size(591, 566)
        Me.GrpSucursales.TabIndex = 6
        Me.GrpSucursales.TabStop = False
        Me.GrpSucursales.Text = "Valores por Referencia"
        '
        'GridValores
        '
        Me.GridValores.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridValores.ColumnAutoResize = True
        Me.GridValores.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridValores.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridValores.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridValores.Location = New System.Drawing.Point(7, 53)
        Me.GridValores.Name = "GridValores"
        Me.GridValores.RecordNavigator = True
        Me.GridValores.Size = New System.Drawing.Size(576, 464)
        Me.GridValores.TabIndex = 4
        Me.GridValores.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnAdd
        '
        Me.BtnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAdd.Image = CType(resources.GetObject("BtnAdd.Image"), System.Drawing.Image)
        Me.BtnAdd.Location = New System.Drawing.Point(524, 18)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(59, 29)
        Me.BtnAdd.TabIndex = 2
        Me.BtnAdd.ToolTipText = "Agregar Valor"
        Me.BtnAdd.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnDel
        '
        Me.BtnDel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnDel.Image = CType(resources.GetObject("BtnDel.Image"), System.Drawing.Image)
        Me.BtnDel.Location = New System.Drawing.Point(459, 19)
        Me.BtnDel.Name = "BtnDel"
        Me.BtnDel.Size = New System.Drawing.Size(59, 29)
        Me.BtnDel.TabIndex = 3
        Me.BtnDel.ToolTipText = "Remueve Valor"
        Me.BtnDel.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmValores
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(591, 566)
        Me.Controls.Add(Me.GrpSucursales)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmValores"
        Me.Text = "Valores por Referencia"
        Me.GrpSucursales.ResumeLayout(False)
        CType(Me.GridValores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region


    Public Sub cargaValores()

        dtValores = ModPOS.Recupera_Tabla("sp_muestra_valores", "@Tabla", Tabla, "@Campo", Campo)

        GridValores.DataSource = dtValores
        GridValores.RetrieveStructure(True)
        GridValores.GroupByBoxVisible = False
        GridValores.RootTable.Columns("Modificado").Visible = False
        GridValores.RootTable.Columns("Baja").Visible = False

        If Tipo = "S" Then
            GridValores.RootTable.Columns("Valor").Selectable = False
            GridValores.RootTable.Columns("Grupo").Selectable = False
            BtnAdd.Enabled = False
            BtnDel.Enabled = False
        End If

        Dim fc1 As Janus.Windows.GridEX.GridEXFormatCondition
        fc1 = New Janus.Windows.GridEX.GridEXFormatCondition(GridValores.RootTable.Columns("Baja"), Janus.Windows.GridEX.ConditionOperator.Equal, 1)

        fc1.FormatStyle.FontStrikeout = Janus.Windows.GridEX.TriState.True
        fc1.FormatStyle.ForeColor = System.Drawing.SystemColors.GrayText
        GridValores.RootTable.FormatConditions.Add(fc1)


    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub FrmValores_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.Valores.Dispose()
        ModPOS.Valores = Nothing
    End Sub

    Private Sub FrmValores_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cargaValores()
    End Sub

    Private Sub GridValores_CellEdited(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridValores.CellEdited
        Select Case GridValores.CurrentColumn.Caption
            Case "Orden"

                If Not IsNumeric(GridValores.GetValue("Orden")) Then
                    GridValores.SetValue("Orden", -1)
                    GridValores.SetValue("Modificado", 0)
                Else
                    GridValores.SetValue("Modificado", 1)
                End If

            Case "Descripcion"
                If GridValores.GetValue("Descripcion").GetType.Name = "DBNull" OrElse CStr(GridValores.GetValue("Descripcion")).Length = 0 Then
                    GridValores.SetValue("Descripcion", "ERROR")
                    GridValores.SetValue("Modificado", 0)
                Else
                    GridValores.SetValue("Modificado", 1)
                End If


            Case "Valor"

                If Not IsNumeric(GridValores.GetValue("Valor")) Then
                    GridValores.SetValue("Valor", GridValores.GetTotal(GridValores.CurrentTable.Columns("Valor"), Janus.Windows.GridEX.AggregateFunction.Max) + 1)
                    GridValores.SetValue("Modificado", 1)
                Else
                    GridValores.SetValue("Modificado", 1)
                End If

            Case "Clave"
                If GridValores.GetValue("Clave").GetType.Name = "DBNull" Then
                    GridValores.SetValue("Clave", GridValores.GetValue("Valor"))
                    GridValores.SetValue("Modificado", 1)
                Else
                    GridValores.SetValue("Modificado", 1)
                End If
            Case "SAT"
                If GridValores.GetValue("SAT").GetType.Name = "DBNull" Then
                    GridValores.SetValue("SAT", GridValores.GetValue("Valor"))
                    GridValores.SetValue("Modificado", 1)
                Else
                    GridValores.SetValue("Modificado", 1)
                End If
            Case "Grupo"

                If Not IsNumeric(GridValores.GetValue("Grupo")) Then
                    GridValores.SetValue("Grupo", 0)
                    GridValores.SetValue("Modificado", 1)
                Else
                    GridValores.SetValue("Modificado", 1)
                End If
        End Select
    End Sub

    Private Sub BtnDel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDel.Click
        If sValor <> "" Then
            Beep()
            Select Case MessageBox.Show("Se eliminara el valor  :" & sValor, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes

                    Dim foundRows() As System.Data.DataRow
                    foundRows = dtValores.Select("Valor = " & sValor)

                    If foundRows.Length <> 0 Then
                        foundRows(0)("Baja") = 1
                    End If

                 
            End Select
        End If
    End Sub

    Private Sub GridValores_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridValores.SelectionChanged
        If Not GridValores.GetValue("Valor") Is Nothing Then
            sValor = CStr(GridValores.GetValue("Valor"))
        Else
            sValor = ""
        End If
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Dim row1 As DataRow
        row1 = dtValores.NewRow()
        'Valor,Descripcion,Orden,0 as Modificado,Baja 
        row1.Item("Valor") = GridValores.GetTotal(GridValores.CurrentTable.Columns("Valor"), Janus.Windows.GridEX.AggregateFunction.Max) + 1
        row1.Item("Clave") = row1.Item("Valor")
        row1.Item("Descripcion") = ""
        row1.Item("Orden") = GridValores.GetTotal(GridValores.CurrentTable.Columns("Orden"), Janus.Windows.GridEX.AggregateFunction.Max) + 1
        row1.Item("Grupo") = 0
        row1.Item("Modificado") = 1
        row1.Item("Baja") = 0
        dtValores.Rows.Add(row1)
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click


        Dim foundRows() As System.Data.DataRow
        foundRows = dtValores.Select(" Descripcion = ''")

        If foundRows.Length <> 0 Then
            MessageBox.Show("La descripcion de los valores no puede quedar vacia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        foundRows = dtValores.Select(" Modificado = 1 and Baja = 0 ")
        If foundRows.Length <> 0 Then
            Dim j As Integer
            For j = 0 To foundRows.GetUpperBound(0)

                ModPOS.Ejecuta("sp_modifica_valorref", _
                              "@Tabla", Tabla, _
                              "@Campo", Campo, _
                              "@Valor", foundRows(j)("Valor"), _
                              "@Tipo", Tipo, _
                              "@Clave", foundRows(j)("Clave"), _
                              "@SAT", foundRows(j)("SAT"), _
                              "@Descripcion", foundRows(j)("Descripcion"), _
                              "@Orden", foundRows(j)("Orden"), _
                              "@Grupo", foundRows(j)("Grupo"), _
                              "@Usuario", ModPOS.UsuarioActual)

            Next
        End If

        foundRows = dtValores.Select(" Baja = 1 ")
        If foundRows.Length <> 0 Then
            Dim j As Integer
            For j = 0 To foundRows.GetUpperBound(0)
                ModPOS.Ejecuta("sp_elimina_valorref", "@Tabla", Tabla, "@Campo", Campo, "@Valor", foundRows(j)("Valor"), "@Usuario", ModPOS.UsuarioActual)
            Next
        End If

        Me.Close()

    End Sub
End Class
