Public Class FormHistoricoVtasDetalle
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal sfact As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        FacturaId = sfact
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If Not Me.MainMenu1 Is Nothing Then Me.MainMenu1.Dispose()
        If Not Me.ListViewDetalles Is Nothing Then
            If Me.ListViewDetalles.Columns.Count > 0 Then
                Me.ListViewDetalles.Columns.Clear()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ButtonRegresar As System.Windows.Forms.Button
    Friend WithEvents ListViewDetalles As System.Windows.Forms.ListView

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.ButtonRegresar = New System.Windows.Forms.Button
        Me.ListViewDetalles = New System.Windows.Forms.ListView
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ButtonRegresar)
        Me.Panel1.Controls.Add(Me.ListViewDetalles)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(242, 295)
        '
        'ButtonRegresar
        '
        Me.ButtonRegresar.Location = New System.Drawing.Point(7, 262)
        Me.ButtonRegresar.Name = "ButtonRegresar"
        Me.ButtonRegresar.Size = New System.Drawing.Size(72, 24)
        Me.ButtonRegresar.TabIndex = 2
        Me.ButtonRegresar.Text = "ButtonRegresar"
        '
        'ListViewDetalles
        '
        Me.ListViewDetalles.FullRowSelect = True
        Me.ListViewDetalles.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListViewDetalles.Location = New System.Drawing.Point(7, 11)
        Me.ListViewDetalles.Name = "ListViewDetalles"
        Me.ListViewDetalles.Size = New System.Drawing.Size(228, 245)
        Me.ListViewDetalles.TabIndex = 3
        Me.ListViewDetalles.View = System.Windows.Forms.View.Details
        '
        'FormHistoricoVtasDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(242, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Menu = Me.MainMenu1
        Me.Name = "FormHistoricoVtasDetalle"
        Me.Text = "Amesol Route"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "VARIABLES"
    Private oVista As Vista
    Private FacturaId As String
#End Region

#Region "FUNCIONES"
    'Private Function DescripcionVR(ByVal Clave As Integer) As String
    '    Dim Dt As DataTable = oDBApp.RealizarConsultaSQL("select descripcion from VAVDescripcion where VARCodigo='UNIDADV' and VAVClave=" & Clave, "vv")
    '    Return Dt.Rows(0).Item(0)
    'End Function
#End Region

#Region "MIS METODOS"
    Private Sub PoblaDetalles()
        If FacturaId = Nothing Then Exit Sub

        Dim aObj As Object = oDBVen.EjecutarCmdScalarObjSQL("SELECT tipo FROM TransProd WHERE TransProdId = '" & FacturaId & "'")
        If (Not IsNothing(aObj) And Not IsDBNull(aObj) And aObj.ToString() = "8") Then
            aObj = oDBVen.EjecutarCmdScalarObjSQL("SELECT TransProdId FROM TransProd WHERE FacturaId = '" & FacturaId & "'").ToString()
            If Not IsNothing(aObj) And Not IsDBNull(aObj) Then
                FacturaId = oDBVen.EjecutarCmdScalarObjSQL("SELECT TransProdId FROM TransProd WHERE FacturaId = '" & FacturaId & "'").ToString()

            End If
        End If
        Dim c As New System.Text.StringBuilder

        c.Append("select distinct(Producto.Nombre), TransProdDetalle.Cantidad, TransProdDetalle.TipoUnidad, TransProdDetalle.Precio ")
        c.Append("from Producto, TransProd, TransProdDetalle ")
        c.Append("where TransProd.TransProdId = TransProdDetalle.TransProdId ")
        c.Append("and TransProdDetalle.ProductoClave=Producto.ProductoClave ")
        c.Append("and transproddetalle.transprodid = '" & FacturaId & "'")
        'c.Append("(select transprodid from transprod where TransProdID ='" & FacturaId & "') ")
        c.Append("order by Producto.Nombre")
        Dim Dt As DataTable = oDBVen.RealizarConsultaSQL(c.ToString, "detalles")
        c = Nothing
        For Each Dr As DataRow In Dt.Rows
            With ListViewDetalles
                Dim LVI As New ListViewItem(Dr(0).ToString)
                LVI.SubItems.Add(FormatNumber(Dr(1), 2))
                LVI.SubItems.Add(ValorReferencia.BuscarEquivalente("UNIDADV", Dr(2)))
                'LVI.SubItems.Add(DescripcionVR(Dr(2)))
                LVI.SubItems.Add(FormatNumber(Dr(3), 2))
                .Items.Add(LVI)
            End With
        Next
        Dt.Dispose()
    End Sub
#End Region

#Region "FormHistoricoVtasDetalle"
    Private Sub FormHistoricoVtasDetalle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor.Current = Cursors.WaitCursor
        [Global].ObtenerFactores(Me)
        [Global].EscalarFuente(Me)
        [Global].EscalarForma(Me)
        If Not Vista.Buscar("FormHistoricoVtasDetalle", oVista) Then
            Cursor.Current = Cursors.Default
            Exit Sub
        End If
        oVista.ColocarEtiquetasForma(Me)
        oVista.CrearListView(ListViewDetalles, "ListViewDetalles")
        PoblaDetalles()
        Cursor.Current = Cursors.Default

        With ListViewDetalles
            If .Items.Count > 0 Then
                .Items(0).Selected = True
                .Focus()
            End If
        End With

    End Sub

    Private Sub ButtonRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRegresar.Click
        Me.Close()
    End Sub
#End Region

End Class