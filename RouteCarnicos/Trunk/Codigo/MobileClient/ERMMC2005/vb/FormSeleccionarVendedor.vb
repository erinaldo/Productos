Public Class FormSeleccionarVendedor
    Inherits System.Windows.Forms.Form
    Friend WithEvents ListViewVendedor As System.Windows.Forms.ListView
    Friend WithEvents ButtonContinuar As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ButtonRegresar As System.Windows.Forms.Button

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If Not IsNothing(Me.ListViewVendedor) Then
            If Me.ListViewVendedor.Columns.Count > 0 Then
                Me.ListViewVendedor.Columns.Clear()
            End If
            Me.ListViewVendedor.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.ListViewVendedor = New System.Windows.Forms.ListView
        Me.ButtonContinuar = New System.Windows.Forms.Button
        Me.ButtonRegresar = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ListViewVendedor
        '
        Me.ListViewVendedor.CheckBoxes = True
        Me.ListViewVendedor.FullRowSelect = True
        Me.ListViewVendedor.Location = New System.Drawing.Point(7, 6)
        Me.ListViewVendedor.Name = "ListViewVendedor"
        Me.ListViewVendedor.Size = New System.Drawing.Size(228, 252)
        Me.ListViewVendedor.TabIndex = 2
        Me.ListViewVendedor.View = System.Windows.Forms.View.Details
        '
        'ButtonContinuar
        '
        Me.ButtonContinuar.Location = New System.Drawing.Point(7, 262)
        Me.ButtonContinuar.Name = "ButtonContinuar"
        Me.ButtonContinuar.Size = New System.Drawing.Size(74, 24)
        Me.ButtonContinuar.TabIndex = 0
        Me.ButtonContinuar.Text = "ButtonContinuar"
        '
        'ButtonRegresar
        '
        Me.ButtonRegresar.Location = New System.Drawing.Point(87, 262)
        Me.ButtonRegresar.Name = "ButtonRegresar"
        Me.ButtonRegresar.Size = New System.Drawing.Size(74, 24)
        Me.ButtonRegresar.TabIndex = 1
        Me.ButtonRegresar.Text = "ButtonRegresar"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ButtonContinuar)
        Me.Panel1.Controls.Add(Me.ButtonRegresar)
        Me.Panel1.Controls.Add(Me.ListViewVendedor)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(242, 295)
        '
        'FormSeleccionarVendedor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(242, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSeleccionarVendedor"
        Me.Text = "Amesol Route"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private sVendedorID As String
    Private refaVista As Vista

    Property VendedorID() As String
        Get
            Return sVendedorID
        End Get
        Set(ByVal Value As String)
            sVendedorID = Value
        End Set
    End Property

    Private Sub FormSeleccionarVendedor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor.Current = Cursors.WaitCursor
        [Global].ObtenerFactores(Me)
        [Global].EscalarFuente(Me)
        [Global].EscalarForma(Me)
        If Not Vista.Buscar("FormSeleccionarVendedor", refaVista) Then
            Cursor.Current = Cursors.Default
            Exit Sub
        End If

        refaVista.CrearListView(ListViewVendedor, "ListViewVendedor")
        refaVista.PoblarListView(ListViewVendedor, oDBVen, "ListViewVendedor", "")

        refaVista.ColocarEtiquetasForma(Me)
        Cursor.Current = Cursors.Default


        With ListViewVendedor
            If .Items.Count > 0 Then
                .Items(0).Selected = True
                .Focus()
            Else
                ButtonContinuar.Focus()
            End If
        End With

    End Sub

    Private Sub ListViewVendedor_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles ListViewVendedor.ItemCheck
        MarcarElemento(ListViewVendedor, e.NewValue, e.Index)
    End Sub

    Private Sub ListViewVendedor_ItemActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListViewVendedor.ItemActivate
        Elegir()
    End Sub

    Private Sub Elegir()
        If Not RevisarElementoMarcado(ListViewVendedor) Then
            MsgBox(refaVista.BuscarMensaje("MsgBox", "Elegir"), MsgBoxStyle.Information)
            Exit Sub
        End If
        Dim refListViewItemSel As ListViewItem = ListViewVendedor.Items(ListViewVendedor.SelectedIndices(0))
        refListViewItemSel.Checked = True
        ' Recuperar el Id del vendedor
        sVendedorID = refListViewItemSel.SubItems(2).Text

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub ButtonContinuar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonContinuar.Click
        Elegir()
    End Sub
End Class
