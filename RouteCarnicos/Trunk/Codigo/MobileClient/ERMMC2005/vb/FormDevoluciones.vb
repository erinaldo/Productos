Public Class FormDevoluciones
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        ListViewDevoluciones.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold)
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If Not Me.MenuItemRegresar Is Nothing Then Me.MenuItemRegresar.Dispose()
        If Not Me.MainMenu1 Is Nothing Then Me.MainMenu1.Dispose()
        If Me.ListViewDevoluciones.Columns.Count > 0 Then
            Me.ListViewDevoluciones.Columns.Clear()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ButtonCancelar As System.Windows.Forms.Button
    Friend WithEvents ButtonRegresar As System.Windows.Forms.Button
    Friend WithEvents ButtonContinuar As System.Windows.Forms.Button
    Friend WithEvents ListViewDevoluciones As System.Windows.Forms.ListView
    Friend WithEvents MenuItemRegresar As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.MenuItemRegresar = New System.Windows.Forms.MenuItem
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.ButtonCancelar = New System.Windows.Forms.Button
        Me.ButtonRegresar = New System.Windows.Forms.Button
        Me.ButtonContinuar = New System.Windows.Forms.Button
        Me.ListViewDevoluciones = New System.Windows.Forms.ListView
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.Add(Me.MenuItemRegresar)
        '
        'MenuItemRegresar
        '
        Me.MenuItemRegresar.Text = "Regresar"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ButtonCancelar)
        Me.Panel1.Controls.Add(Me.ButtonRegresar)
        Me.Panel1.Controls.Add(Me.ButtonContinuar)
        Me.Panel1.Controls.Add(Me.ListViewDevoluciones)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(242, 295)
        '
        'ButtonCancelar
        '
        Me.ButtonCancelar.Location = New System.Drawing.Point(164, 262)
        Me.ButtonCancelar.Name = "ButtonCancelar"
        Me.ButtonCancelar.Size = New System.Drawing.Size(72, 24)
        Me.ButtonCancelar.TabIndex = 4
        Me.ButtonCancelar.Text = "ButtonCancelar"
        '
        'ButtonRegresar
        '
        Me.ButtonRegresar.Location = New System.Drawing.Point(84, 262)
        Me.ButtonRegresar.Name = "ButtonRegresar"
        Me.ButtonRegresar.Size = New System.Drawing.Size(72, 24)
        Me.ButtonRegresar.TabIndex = 5
        Me.ButtonRegresar.Text = "ButtonRegresar"
        '
        'ButtonContinuar
        '
        Me.ButtonContinuar.Location = New System.Drawing.Point(4, 262)
        Me.ButtonContinuar.Name = "ButtonContinuar"
        Me.ButtonContinuar.Size = New System.Drawing.Size(72, 24)
        Me.ButtonContinuar.TabIndex = 6
        Me.ButtonContinuar.Text = "ButtonContinuar"
        '
        'ListViewDevoluciones
        '
        Me.ListViewDevoluciones.CheckBoxes = True
        Me.ListViewDevoluciones.FullRowSelect = True
        Me.ListViewDevoluciones.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListViewDevoluciones.Location = New System.Drawing.Point(4, 3)
        Me.ListViewDevoluciones.Name = "ListViewDevoluciones"
        Me.ListViewDevoluciones.Size = New System.Drawing.Size(232, 255)
        Me.ListViewDevoluciones.TabIndex = 7
        Me.ListViewDevoluciones.View = System.Windows.Forms.View.Details
        '
        'FormDevoluciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(242, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Menu = Me.MainMenu1
        Me.Name = "FormDevoluciones"
        Me.Text = "Amesol Route"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "VARIABLES"
    Private oVista As Vista
    Dim blnInicio As Boolean = False
#End Region

#Region "FormDevoluciones"

    Private Sub FormDevoluciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        [Global].ObtenerFactores(Me)
        [Global].EscalarFuente(Me)
        [Global].EscalarForma(Me)
        ListViewDevoluciones.Activation = oApp.TipoSeleccion
        If Not Vista.Buscar("FormDevoluciones", oVista) Then
            Exit Sub
        End If
        oVista.CrearListView(ListViewDevoluciones, "ListViewDevoluciones")
        LlenarLV()
        oVista.ColocarEtiquetasForma(Me)

        If ListViewDevoluciones.Items.Count > 0 Then
            ListViewDevoluciones.Items(0).Selected = True
            ListViewDevoluciones.Focus()
        Else
            Continuar()
        End If
    End Sub

    Private Sub ButtonRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRegresar.Click
        Me.Close()
    End Sub

    Private Sub ButtonContinuar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonContinuar.Click
        Continuar()
    End Sub

    Private Sub ListViewDevoluciones_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles ListViewDevoluciones.ItemCheck
        If blnInicio Then Exit Sub
        Try
            blnInicio = True
            MarcarElemento(ListViewDevoluciones, e.NewValue, e.Index)
            blnInicio = False
            If ListViewDevoluciones.SelectedIndices.Count <= 0 Then Exit Sub
            If e.NewValue = CheckState.Unchecked Then
                blnInicio = True
                ListViewDevoluciones.Items(ListViewDevoluciones.SelectedIndices(0)).Selected = False
                blnInicio = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ListViewDevoluciones_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListViewDevoluciones.SelectedIndexChanged
        Try
            If blnInicio Then Exit Sub
            If ListViewDevoluciones.SelectedIndices.Count <= 0 Then Exit Sub
            blnInicio = True
            MarcarElemento(ListViewDevoluciones, CheckState.Checked, ListViewDevoluciones.SelectedIndices(0))
            blnInicio = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ButtonCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancelar.Click
        If HaySeleccion(ListViewDevoluciones) Then
            Dim TF As Integer = TipoFaseRegistro(ObtenerIDRegistro(ListViewDevoluciones))
            Dim Fase As FormDevolucionDetalle.Fase
            Select Case TF
                Case 0
                    Fase = FormDevolucionDetalle.Fase.Cancelado
                Case 1
                    Fase = FormDevolucionDetalle.Fase.Captura
                Case 2
                    Fase = FormDevolucionDetalle.Fase.Surtido
                Case 3
                    Fase = FormDevolucionDetalle.Fase.Facturado
            End Select
            If Fase <> FormDevolucionDetalle.Fase.Captura Then
                'Dim tmp As String = ""
                'Dim Dr As DataRow = ValorReferencia.RecuperarLista("TRPFASE", TF).Rows(0)
                'tmp = Dr(1)
                'MsgBox(SustituyeCampo(oVista.BuscarMensaje("Mensajes", "E0037"), tmp))
                MsgBox(SustituyeCampo(oVista.BuscarMensaje("Mensajes", "E0037"), ValorReferencia.BuscarEquivalente("TRPFASE", TF)))
            End If
            Dim oFormaDetalle As New FormDevolucionDetalle(ObtenerFolioRegistro(ListViewDevoluciones), ObtenerIDRegistro(ListViewDevoluciones), FormDevolucionDetalle.Modo.Cancelar, Fase, False)
            oFormaDetalle.ShowDialog()
            oFormaDetalle.Dispose()
            LlenarLV()
        Else
            MsgBox(oVista.BuscarMensaje("Mensajes", "E0046"))
        End If
    End Sub

    Private Sub MenuItemRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemRegresar.Click
        Me.Close()
    End Sub
#End Region

#Region "MIS METODOS"
    Private Sub LlenarLV()
        oVista.PoblarListView(ListViewDevoluciones, odbVen, "ListViewDevoluciones", "")
    End Sub

    Private Sub Continuar()
        Dim ID As String = ""
        If HaySeleccion(ListViewDevoluciones) Then
            Dim TF As Integer = TipoFaseRegistro(ObtenerIDRegistro(ListViewDevoluciones))
            Dim Fase As FormDevolucionDetalle.Fase
            Select Case TF
                Case 0
                    Fase = FormDevolucionDetalle.Fase.Cancelado
                Case 1
                    Fase = FormDevolucionDetalle.Fase.Captura
                Case 2
                    Fase = FormDevolucionDetalle.Fase.Surtido
                Case 3
                    Fase = FormDevolucionDetalle.Fase.Facturado
            End Select
            If Fase <> FormDevolucionDetalle.Fase.Captura Then
                'Dim tmp As String = ""
                'Dim Dr As DataRow = ValorReferencia.RecuperarLista("TRPFASE", TF).Rows(0)
                'tmp = Dr(1)
                'MsgBox(SustituyeCampo(oVista.BuscarMensaje("Mensajes", "E0036"), tmp))
                MsgBox(SustituyeCampo(oVista.BuscarMensaje("Mensajes", "E0036"), ValorReferencia.BuscarEquivalente("TRPFASE", TF)))
            End If
            Dim oFormaDetalle As New FormDevolucionDetalle(ObtenerFolioRegistro(ListViewDevoluciones), ObtenerIDRegistro(ListViewDevoluciones), FormDevolucionDetalle.Modo.Modificar, Fase, False)
            oFormaDetalle.ShowDialog()
            oFormaDetalle.Dispose()
            'LlenarLV()
            Me.Close()
        Else
            ID = oApp.KEYGEN(1)
            Dim sFolio As String = Folio.Obtener(, ServicesCentral.TiposModulosMovDet.DevolucionAlmacen)
            If sFolio <> "" Then
                Dim oFormaDetalle As New FormDevolucionDetalle(sFolio, ID, FormDevolucionDetalle.Modo.Capturar, FormDevolucionDetalle.Fase.Captura, True)
                oFormaDetalle.ShowDialog()
                oFormaDetalle.Dispose()
                'LlenarLV()
                'If ListViewDevoluciones.Items.Count = 0 Then
                Me.Close()
                'End If
            End If
        End If
    End Sub

#End Region

#Region "FUNCIONES"
    Private Function TipoFaseRegistro(ByVal ID As String) As Integer
        Dim nTipoFase As Integer
        Dim DT As DataTable = oDBVen.RealizarConsultaSQL("select tipofase from transprod where transprodid='" & ID & "'", "transprod")
        nTipoFase = DT.Rows(0)(0)
        DT.Dispose()
        Return nTipoFase
    End Function

    Private Function ObtenerIDRegistro(ByVal LV As ListView) As String
        Dim i As Integer
        For i = 0 To LV.Items.Count - 1
            If LV.Items(i).Checked Then
                Return LV.Items(i).SubItems(3).Text
            End If
        Next
        Return ""
    End Function

    Private Function ObtenerFolioRegistro(ByVal LV As ListView) As String
        Dim i As Integer
        For i = 0 To LV.Items.Count - 1
            If LV.Items(i).Checked Then
                Return LV.Items(i).Text
            End If
        Next
        Return ""
    End Function
    Private Function HaySeleccion(ByVal LV As ListView) As Boolean
        If LV.Items.Count > 0 Then
            Dim i As Integer
            For i = 0 To LV.Items.Count - 1
                If LV.Items(i).Checked Then
                    Return True
                End If
            Next
        End If
        Return False
    End Function
#End Region

End Class
