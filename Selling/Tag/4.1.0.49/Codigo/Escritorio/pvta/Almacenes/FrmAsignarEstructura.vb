Imports System.Data.SqlClient

Public Class FrmAsignarEstructura
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
    Friend WithEvents BtnOk As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents cmdTodosIzq As Janus.Windows.EditControls.UIButton
    Friend WithEvents cmdUnoIzq As Janus.Windows.EditControls.UIButton
    Friend WithEvents cmdTodosDer As Janus.Windows.EditControls.UIButton
    Friend WithEvents cmdUnoDer As Janus.Windows.EditControls.UIButton
    Friend WithEvents LstAsignados As System.Windows.Forms.ListBox
    Friend WithEvents LstSinAsignar As System.Windows.Forms.ListBox
    Friend WithEvents GrpAsignados As System.Windows.Forms.GroupBox
    Friend WithEvents GrpSinAsignar As System.Windows.Forms.GroupBox
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents TxtClave As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LblClave As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAsignarEstructura))
        Me.BtnOk = New Janus.Windows.EditControls.UIButton
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.cmdTodosIzq = New Janus.Windows.EditControls.UIButton
        Me.cmdUnoIzq = New Janus.Windows.EditControls.UIButton
        Me.cmdTodosDer = New Janus.Windows.EditControls.UIButton
        Me.cmdUnoDer = New Janus.Windows.EditControls.UIButton
        Me.GrpAsignados = New System.Windows.Forms.GroupBox
        Me.LstAsignados = New System.Windows.Forms.ListBox
        Me.GrpSinAsignar = New System.Windows.Forms.GroupBox
        Me.LstSinAsignar = New System.Windows.Forms.ListBox
        Me.TxtNombre = New System.Windows.Forms.TextBox
        Me.TxtClave = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.LblClave = New System.Windows.Forms.Label
        Me.GrpAsignados.SuspendLayout()
        Me.GrpSinAsignar.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnOk
        '
        Me.BtnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnOk.Icon = CType(resources.GetObject("BtnOk.Icon"), System.Drawing.Icon)
        Me.BtnOk.Location = New System.Drawing.Point(337, 355)
        Me.BtnOk.Name = "BtnOk"
        Me.BtnOk.Size = New System.Drawing.Size(90, 37)
        Me.BtnOk.TabIndex = 5
        Me.BtnOk.Text = "&Aceptar"
        Me.BtnOk.ToolTipText = "Guardar los cambios"
        Me.BtnOk.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Icon = CType(resources.GetObject("BtnCancelar.Icon"), System.Drawing.Icon)
        Me.BtnCancelar.Location = New System.Drawing.Point(241, 355)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 6
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar la ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'cmdTodosIzq
        '
        Me.cmdTodosIzq.Location = New System.Drawing.Point(207, 245)
        Me.cmdTodosIzq.Name = "cmdTodosIzq"
        Me.cmdTodosIzq.Size = New System.Drawing.Size(27, 21)
        Me.cmdTodosIzq.TabIndex = 4
        Me.cmdTodosIzq.Text = "<<"
        Me.cmdTodosIzq.ToolTipText = "Remover todas las estructuras de la asignación"
        Me.cmdTodosIzq.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'cmdUnoIzq
        '
        Me.cmdUnoIzq.Location = New System.Drawing.Point(207, 215)
        Me.cmdUnoIzq.Name = "cmdUnoIzq"
        Me.cmdUnoIzq.Size = New System.Drawing.Size(27, 22)
        Me.cmdUnoIzq.TabIndex = 3
        Me.cmdUnoIzq.Text = "<"
        Me.cmdUnoIzq.ToolTipText = "Remover  la estructura seleccionada de la asignación"
        Me.cmdUnoIzq.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'cmdTodosDer
        '
        Me.cmdTodosDer.Location = New System.Drawing.Point(207, 186)
        Me.cmdTodosDer.Name = "cmdTodosDer"
        Me.cmdTodosDer.Size = New System.Drawing.Size(27, 21)
        Me.cmdTodosDer.TabIndex = 2
        Me.cmdTodosDer.Text = ">>"
        Me.cmdTodosDer.ToolTipText = "Asignar todas las estructuras"
        Me.cmdTodosDer.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'cmdUnoDer
        '
        Me.cmdUnoDer.Location = New System.Drawing.Point(207, 156)
        Me.cmdUnoDer.Name = "cmdUnoDer"
        Me.cmdUnoDer.Size = New System.Drawing.Size(27, 21)
        Me.cmdUnoDer.TabIndex = 1
        Me.cmdUnoDer.Text = ">"
        Me.cmdUnoDer.ToolTipText = "Asignar la estructura seleccionada"
        Me.cmdUnoDer.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GrpAsignados
        '
        Me.GrpAsignados.Controls.Add(Me.LstAsignados)
        Me.GrpAsignados.Location = New System.Drawing.Point(240, 67)
        Me.GrpAsignados.Name = "GrpAsignados"
        Me.GrpAsignados.Size = New System.Drawing.Size(187, 282)
        Me.GrpAsignados.TabIndex = 15
        Me.GrpAsignados.TabStop = False
        Me.GrpAsignados.Text = "Estructuras Asignadas"
        '
        'LstAsignados
        '
        Me.LstAsignados.Location = New System.Drawing.Point(13, 22)
        Me.LstAsignados.Name = "LstAsignados"
        Me.LstAsignados.ScrollAlwaysVisible = True
        Me.LstAsignados.Size = New System.Drawing.Size(159, 225)
        Me.LstAsignados.TabIndex = 15
        '
        'GrpSinAsignar
        '
        Me.GrpSinAsignar.Controls.Add(Me.LstSinAsignar)
        Me.GrpSinAsignar.Location = New System.Drawing.Point(13, 67)
        Me.GrpSinAsignar.Name = "GrpSinAsignar"
        Me.GrpSinAsignar.Size = New System.Drawing.Size(187, 282)
        Me.GrpSinAsignar.TabIndex = 16
        Me.GrpSinAsignar.TabStop = False
        Me.GrpSinAsignar.Text = "Estructuras Disponibles"
        '
        'LstSinAsignar
        '
        Me.LstSinAsignar.Location = New System.Drawing.Point(13, 22)
        Me.LstSinAsignar.Name = "LstSinAsignar"
        Me.LstSinAsignar.ScrollAlwaysVisible = True
        Me.LstSinAsignar.Size = New System.Drawing.Size(159, 225)
        Me.LstSinAsignar.TabIndex = 14
        '
        'TxtNombre
        '
        Me.TxtNombre.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.TxtNombre.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TxtNombre.Location = New System.Drawing.Point(67, 37)
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.ReadOnly = True
        Me.TxtNombre.Size = New System.Drawing.Size(234, 20)
        Me.TxtNombre.TabIndex = 17
        '
        'TxtClave
        '
        Me.TxtClave.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.TxtClave.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TxtClave.Location = New System.Drawing.Point(67, 15)
        Me.TxtClave.Name = "TxtClave"
        Me.TxtClave.ReadOnly = True
        Me.TxtClave.Size = New System.Drawing.Size(134, 20)
        Me.TxtClave.TabIndex = 20
        Me.TxtClave.TabStop = False
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(13, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 21)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Nombre"
        '
        'LblClave
        '
        Me.LblClave.Location = New System.Drawing.Point(13, 15)
        Me.LblClave.Name = "LblClave"
        Me.LblClave.Size = New System.Drawing.Size(84, 21)
        Me.LblClave.TabIndex = 18
        Me.LblClave.Text = "Clave"
        '
        'FrmAsignarEstructura
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(433, 396)
        Me.Controls.Add(Me.TxtNombre)
        Me.Controls.Add(Me.TxtClave)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LblClave)
        Me.Controls.Add(Me.GrpSinAsignar)
        Me.Controls.Add(Me.GrpAsignados)
        Me.Controls.Add(Me.cmdTodosIzq)
        Me.Controls.Add(Me.cmdUnoIzq)
        Me.Controls.Add(Me.cmdTodosDer)
        Me.Controls.Add(Me.cmdUnoDer)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnOk)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmAsignarEstructura"
        Me.Text = "Asignar Estructura"
        Me.GrpAsignados.ResumeLayout(False)
        Me.GrpSinAsignar.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Public AREClave As String
    Public Color As Integer

    Private dtSinAsignar As DataTable
    Private dtAsignados As DataTable

    Private Sub FrmAsignarEstructura_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPos.AsignarEstructura.Dispose()
        ModPos.AsignarEstructura = Nothing
    End Sub

    Private Sub Selecciones(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles cmdUnoDer.Click, _
        cmdTodosDer.Click, cmdUnoIzq.Click, cmdTodosIzq.Click, _
        LstSinAsignar.DoubleClick, LstAsignados.DoubleClick
        Dim i As Integer
        Dim fila As DataRowView

        If sender Is LstSinAsignar Or sender Is cmdUnoDer Then
            If LstSinAsignar.SelectedIndex <> -1 Then
                fila = LstSinAsignar.SelectedItem
                Me.dtAsignados.ImportRow(fila.Row)
                Me.dtSinAsignar.Rows.Remove(fila.Row)
            End If
            LstSinAsignar.ClearSelected()

        ElseIf sender Is cmdTodosDer Then
            For i = 0 To LstSinAsignar.Items.Count - 1
                fila = LstSinAsignar.Items.Item(i)
                Me.dtAsignados.ImportRow(fila.Row)
            Next
            Me.dtSinAsignar.Rows.Clear()
            LstAsignados.ClearSelected()

        ElseIf sender Is LstAsignados Or sender Is cmdUnoIzq Then
            If LstAsignados.SelectedIndex <> -1 Then
                fila = LstAsignados.SelectedItem
                Me.dtSinAsignar.ImportRow(fila.Row)
                Me.dtAsignados.Rows.Remove(fila.Row)
            End If

            LstSinAsignar.ClearSelected()

        ElseIf sender Is cmdTodosIzq Then
            For i = 0 To LstAsignados.Items.Count - 1
                fila = LstAsignados.Items.Item(i)
                Me.dtSinAsignar.ImportRow(fila.Row)
            Next
            dtAsignados.Rows.Clear()
            LstSinAsignar.ClearSelected()

        End If
    End Sub

    Private Sub FrmAsignarEstructura_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        dtAsignados = ModPOS.Recupera_Tabla("sp_filtra_estructura", "@area", Me.AREClave, "@almacen", "")
        dtSinAsignar = ModPOS.Recupera_Tabla("sp_filtra_EstructuraSinArea", Nothing)
        Me.LstAsignados.DataSource = dtAsignados
        Me.LstAsignados.DisplayMember = dtAsignados.Columns(1).ColumnName
        Me.LstAsignados.ValueMember = dtAsignados.Columns(0).ColumnName
        Me.LstSinAsignar.DataSource = dtSinAsignar
        Me.LstSinAsignar.DisplayMember = dtSinAsignar.Columns(1).ColumnName
        Me.LstSinAsignar.ValueMember = dtSinAsignar.Columns(0).ColumnName
        Me.LstAsignados.ClearSelected()
        Me.LstSinAsignar.ClearSelected()
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Function BuscaRegistro(ByVal table As DataTable, ByVal sValue As String) As DataRow
        Dim rowCollection As DataRowCollection = table.Rows
        Dim foundRow As DataRow = rowCollection.Find(sValue)

        Return foundRow

    End Function


    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click

        Dim i As Integer

        If Me.dtAsignados.Rows.Count > 0 Then
            For i = 0 To Me.dtAsignados.Rows.Count - 1

                ModPos.Update_AREEstructura(Me.AREClave, Me.Color, dtAsignados.Rows(i).ItemArray(0))
            Next
        End If

        If Me.dtSinAsignar.Rows.Count > 0 Then
            For i = 0 To Me.dtSinAsignar.Rows.Count - 1
                ModPOS.Update_AREEstructura("", 0, dtSinAsignar.Rows(i).ItemArray(0))
            Next
        End If

        
        Me.Close()

    End Sub
End Class
