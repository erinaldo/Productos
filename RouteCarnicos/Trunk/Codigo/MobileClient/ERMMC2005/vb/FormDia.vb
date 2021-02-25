Imports System.io
Imports System.Data.SqlServerCe

Public Class FormDia
    Inherits System.Windows.Forms.Form

    Private Const ConstMenuTerminar = 0

    Private Const ConstTabPageDia = 0
    Private Const ConstTabPageMenu = 1

    Private refaVista As Vista
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ListViewDias As System.Windows.Forms.ListView
    Friend WithEvents LabelPrincipal As System.Windows.Forms.Label
    Friend WithEvents ButtonElegir As System.Windows.Forms.Button
    Friend WithEvents ButtonRegresar As System.Windows.Forms.Button
    Private bMarcando As Boolean = False

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()

        ListViewDias.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold)

    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If Not IsNothing(ListViewDias) Then
            If ListViewDias.Columns.Count > 0 Then ListViewDias.Columns.Clear()
            ListViewDias.Dispose()
        End If
        If Not IsNothing(refaVista) Then refaVista = Nothing
        If Not IsNothing(InputPanelDias) Then InputPanelDias.Dispose()

        If Not IsNothing(Me.MenuItemRegresar) Then Me.MenuItemRegresar.Dispose()
        If Not IsNothing(Me.MainMenuDias) Then Me.MainMenuDias.Dispose()

        MyBase.Dispose(disposing)
    End Sub

    'NOTA: el Diseñador de Windows Forms requiere el siguiente procedimiento
    'Puede modificarse utilizando el Diseñador de Windows Forms. 
    'No lo modifique con el editor de código.
    Friend WithEvents MainMenuDias As System.Windows.Forms.MainMenu
    Friend WithEvents InputPanelDias As Microsoft.WindowsCE.Forms.InputPanel
    Friend WithEvents MenuItemRegresar As System.Windows.Forms.MenuItem

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.MainMenuDias = New System.Windows.Forms.MainMenu
        Me.MenuItemRegresar = New System.Windows.Forms.MenuItem
        Me.InputPanelDias = New Microsoft.WindowsCE.Forms.InputPanel
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.ListViewDias = New System.Windows.Forms.ListView
        Me.LabelPrincipal = New System.Windows.Forms.Label
        Me.ButtonElegir = New System.Windows.Forms.Button
        Me.ButtonRegresar = New System.Windows.Forms.Button
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainMenuDias
        '
        Me.MainMenuDias.MenuItems.Add(Me.MenuItemRegresar)
        '
        'MenuItemRegresar
        '
        Me.MenuItemRegresar.Text = "MenuItemRegresar"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ListViewDias)
        Me.Panel1.Controls.Add(Me.LabelPrincipal)
        Me.Panel1.Controls.Add(Me.ButtonElegir)
        Me.Panel1.Controls.Add(Me.ButtonRegresar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(242, 295)
        '
        'ListViewDias
        '
        Me.ListViewDias.CheckBoxes = True
        Me.ListViewDias.FullRowSelect = True
        Me.ListViewDias.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListViewDias.Location = New System.Drawing.Point(6, 22)
        Me.ListViewDias.Name = "ListViewDias"
        Me.ListViewDias.Size = New System.Drawing.Size(230, 234)
        Me.ListViewDias.TabIndex = 5
        Me.ListViewDias.View = System.Windows.Forms.View.Details
        '
        'LabelPrincipal
        '
        Me.LabelPrincipal.Location = New System.Drawing.Point(6, 6)
        Me.LabelPrincipal.Name = "LabelPrincipal"
        Me.LabelPrincipal.Size = New System.Drawing.Size(230, 20)
        Me.LabelPrincipal.Text = "LabelPrincipal"
        '
        'ButtonElegir
        '
        Me.ButtonElegir.Location = New System.Drawing.Point(5, 262)
        Me.ButtonElegir.Name = "ButtonElegir"
        Me.ButtonElegir.Size = New System.Drawing.Size(74, 24)
        Me.ButtonElegir.TabIndex = 7
        Me.ButtonElegir.Text = "ButtonElegir"
        '
        'ButtonRegresar
        '
        Me.ButtonRegresar.Location = New System.Drawing.Point(84, 262)
        Me.ButtonRegresar.Name = "ButtonRegresar"
        Me.ButtonRegresar.Size = New System.Drawing.Size(74, 24)
        Me.ButtonRegresar.TabIndex = 8
        Me.ButtonRegresar.Text = "ButtonRegresar"
        '
        'FormDia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.LightGray
        Me.ClientSize = New System.Drawing.Size(242, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.Menu = Me.MainMenuDias
        Me.MinimizeBox = False
        Me.Name = "FormDia"
        Me.Text = "Amesol Route"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Forma "

    Private Sub FormDia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        [Global].ObtenerFactores(Me)
        [Global].EscalarFuente(Me)
        [Global].EscalarForma(Me)
        ListViewDias.Activation = oApp.TipoSeleccion
        ' Recuperar los demás componentes de la forma
        If Not Vista.Buscar("FormDia", refaVista) Then
            Exit Sub
        End If
        refaVista.CrearListView(ListViewDias, "ListViewDias")
        refaVista.PoblarListView(ListViewDias, oDBVen, "ListViewDias", "")
        ' Recuperar los rótulos y elementos de la pantalla desde la base de datos Sys
        refaVista.ColocarEtiquetasForma(Me)
        MostrarDiaActual()

        With ListViewDias
            If .Items.Count > 0 Then
                .Items(0).Selected = True
                .Focus()
            End If
        End With

    End Sub

    Private Sub MostrarDiaActual()
        If oDia.DiaActual Is Nothing Then
            If Me.ListViewDias.Items.Count > 0 Then
                Me.ListViewDias.Items(0).Selected = True
            End If
        Else
            For Each refItem As ListViewItem In Me.ListViewDias.Items
                With refItem
                    If .Text = oDia.DiaActual Then
                        .Selected = True
                        Exit For
                    End If
                End With
            Next
        End If
    End Sub

#End Region

    Private Function HaySeleccion(ByVal LV As ListView) As Boolean
        If LV.Items.Count > 0 Then
            Dim i As Integer
            For i = 0 To LV.Items.Count - 1
                If LV.Items(i).Checked Then
                    LV.Items(i).Selected = True
                    Return True
                End If
            Next
        End If
        Return False
    End Function

    Private Function ValidarKilometrajeDia() As Boolean
        Dim sConsulta As String
        sConsulta = "select count(CAMVENId) from CamionVendedor where KmFinal is null and Enviado = 0"
        Return (oDBVen.EjecutarCmdScalarIntSQL(sConsulta) > 0)
    End Function

#Region " Botones "

    Private Sub ButtonElegir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonElegir.Click
        If Me.HaySeleccion(Me.ListViewDias) Then
            If oVendedor.JornadaTrabajo Then
                Dim oDt As DataTable = oDBVen.RealizarConsultaSQL("Select FechaFinal From VendedorJornada Where DiaClave='" & Me.ListViewDias.Items(Me.ListViewDias.SelectedIndices(0)).Text & "' AND VendedorId='" & oVendedor.VendedorId & "' order by mfechahora desc ", "JornadaTrabajo")

                If oDt.Rows.Count > 0 Then
                    Dim oDr As DataRow = oDt.Rows(0)
                    If Not IsDBNull(oDr("FechaFinal")) Then
                        MsgBox(refaVista.BuscarMensaje("MsgBox", "E0488"), MsgBoxStyle.Exclamation, "Amesol Route")
                        Exit Sub
                    End If
                Else
                    oDt = oDBVen.RealizarConsultaSQL("Select * From VendedorJornada Where DiaClave is null and FechaFinal is null and VendedorId='" & oVendedor.VendedorId & "' order by mfechahora desc ", "JornadaTrabajo")
                    If oDt.Rows.Count > 0 Then
                        oDBVen.EjecutarComandoSQL("Update VendedorJornada Set DiaClave='" & Me.ListViewDias.Items(Me.ListViewDias.SelectedIndices(0)).Text & "', Enviado = 0 WHERE VendedorId='" & oDt.Rows(0)("VendedorId") & "' AND VEJFechaInicial=" & UniFechaSQL(oDt.Rows(0)("VEJFechaInicial")))
                    Else
                        MsgBox(refaVista.BuscarMensaje("MsgBox", "E0487"), MsgBoxStyle.Exclamation, "Amesol Route")
                        Exit Sub
                    End If
                End If
                oDt.Dispose()
            End If
            If oVendedor.Kilometraje Then
                If Not ValidarKilometrajeDia() Then
                    MsgBox(refaVista.BuscarMensaje("MsgBox", "E0721"), MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical)
                    Me.DialogResult = Windows.Forms.DialogResult.Cancel
                    Me.Close()
                    Exit Sub
                End If
            End If
            Me.Elegir()
        Else
            MsgBox(refaVista.BuscarMensaje("MsgBox", "Elegir"), MsgBoxStyle.Information, "Amesol Route")
        End If
    End Sub

    Private Sub ButtonRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRegresar.Click
        Me.Close()
    End Sub

#End Region

#Region " Menu "

    Private Sub MenuItemRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemRegresar.Click
        Me.Close()
    End Sub

    Private Sub MenuItemVerDetalles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ListViewDias.View = View.Details
    End Sub

    Private Sub MenuItemVerIconos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ListViewDias.View = View.LargeIcon
    End Sub

#End Region

    Private Sub ListViewDias_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles ListViewDias.ItemCheck
        If bMarcando = True Then
            Exit Sub
        End If
        bMarcando = True
        MarcarElemento(ListViewDias, e.NewValue, e.Index)
        bMarcando = False
    End Sub

    Private Sub ListViewDias_ItemActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListViewDias.ItemActivate
        'Elegir()
        If Me.ListViewDias.SelectedIndices.Count > 0 Then
            DesmarcarItems()
            Me.ListViewDias.Items(Me.ListViewDias.SelectedIndices.Item(0)).Checked = True
        End If
    End Sub

    Private Sub DesmarcarItems()
        For Each refListViewItem As ListViewItem In Me.ListViewDias.Items
            refListViewItem.Checked = False
        Next
    End Sub

    Private Sub Elegir()
        'If Not RevisarElementoMarcado(ListViewDias) Then
        '    MsgBox(refaVista.BuscarMensaje("MsgBox", "Elegir"), MsgBoxStyle.Information)
        '    Exit Sub
        'End If
        Dim refListViewItemSel As ListViewItem = ListViewDias.Items(ListViewDias.SelectedIndices(0))
        refListViewItemSel.Checked = True
        ' El nombre del día siempre debe estar en el ListViewDias y debe ser el primero
        oDia.Nombre = refListViewItemSel.Text
        If Not oDia.Recuperar() Then
            MsgBox(refaVista.BuscarMensaje("MsgBox", "ErrorAbrir"), MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        'If Me.CheckBoxActualizar.Checked Then
        '    If MsgBox(refaVista.BuscarMensaje("MsgBox", "SeguroActualizar"), MsgBoxStyle.Question Or MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then
        '        Exit Sub
        '    End If
        'End If
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

End Class



