Imports Subgurim.Controles
Partial Class PopUpMapas
    Inherits System.Web.UI.Page
    Dim mensaje As DBConexion.cMensaje

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim leng As String
            mensaje = New DBConexion.cMensaje
            LLenarEtiquetas()

            Dim Largo As Double = 0
            Dim Alto As Double = 0
            Try
                largo = ConfigurationManager.AppSettings("TamanioMapa").Split(",")(0)
                Alto = ConfigurationManager.AppSettings("TamanioMapa").Split(",")(1)
            Catch
                largo = 500
                Alto = 500
            End Try

            GMap1.Height = Alto
            GMap1.Width = largo

            pnlCli.Height = Alto - 100

            pnlTra.Height = Alto - 100

            Dim a As Boolean
            Dim TablaCapas As New Data.DataTable("Capas")
            TablaCapas.Columns.Add("ID")
            TablaCapas.Columns.Add("Nombre")
            TablaCapas.Columns.Add("Tipo")
            TablaCapas.Columns.Add("Seleccionado", a.GetType())
            TablaCapas.Columns.Add("Color", System.Drawing.Color.AliceBlue.GetType)
            TablaCapas.Columns.Add("CheckVisible", a.GetType())

            Dim ins As New DBConexion.cConexionSQL
            Dim nombreMapa As String = ins.EjecutarComandoScalar("select descripcion from VAVDescripcion where varcodigo = 'MapaW' and vavclave=" + Request.Params("id") + " and vadtipolenguaje='" + leng + "' ")

            Select Case Request.Params("id")
                Case 1
                    Page.Title = mensaje.RecuperarDescripcion("XMapa") + " " + nombreMapa + " : " + mensaje.RecuperarDescripcion("XRuta") + " " + Request.Params("rt") + " y " + mensaje.RecuperarDescripcion("XFecha") + " " + Request.Params("fh")
                    MapaLogistico.LLenarMapa(GMap1, Request.Params("rt"), Request.Params("fh"), TablaCapas)
                Case Else
            End Select

        
            Dim datav As New Data.DataView

            datav.Table = TablaCapas
            datav.RowFilter = "Tipo=1"
            DataList1.DataSource = datav.ToTable()
            DataList1.DataBind()
            datav.Table = TablaCapas
            datav.RowFilter = "Tipo=2"
            DataList2.DataSource = datav.ToTable()
            DataList2.DataBind()
        End If




    End Sub

    Public Sub LLenarEtiquetas()
        BtnFiltrarCapas.Text = mensaje.RecuperarDescripcion("XFiltrarCapas")
        lbCapas.Text = mensaje.RecuperarDescripcion("XCapas")
        LbClientes.Text = mensaje.RecuperarDescripcion("XClientes")
        LbTrayectorias.Text = mensaje.RecuperarDescripcion("XTrayectorias")
    End Sub

    Protected Sub BtnFiltrarCapas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnFiltrarCapas.Click
        Dim a As Boolean
        Dim TablaCapas As New Data.DataTable("Capas")
        TablaCapas.Columns.Add("ID")
        TablaCapas.Columns.Add("Nombre")
        TablaCapas.Columns.Add("Tipo")
        TablaCapas.Columns.Add("Seleccionado", a.GetType())
        TablaCapas.Columns.Add("Color", System.Drawing.Color.AliceBlue.GetType)
        TablaCapas.Columns.Add("CheckVisible", a.GetType())

        Dim consecutivo As Integer = 1
        For Each item As DataListItem In DataList1.Items
            TablaCapas.Rows.Add(New Object() {consecutivo.ToString, CType(item.Controls(5), Label).Text, "1", CType(item.Controls(1), CheckBox).Checked, CType(item.Controls(3), Panel).BackColor, CType(item.Controls(1), CheckBox).Visible})
            consecutivo += 1
        Next
        For Each item As DataListItem In DataList2.Items
            TablaCapas.Rows.Add(New Object() {consecutivo.ToString, CType(item.Controls(5), Label).Text, "2", CType(item.Controls(1), CheckBox).Checked, CType(item.Controls(3), Panel).BackColor, CType(item.Controls(1), CheckBox).Visible})
            consecutivo += 1
        Next

        Select Case Request.Params("id")
            Case 1
                Page.Title = "Mapa del la Ruta " + Request.Params("rt") + " y del dia " + Request.Params("fh") + ""
                MapaLogistico.LLenarMapa(GMap1, Request.Params("rt"), Request.Params("fh"), TablaCapas)
            Case Else
        End Select

      
        Dim datav As New Data.DataView

        datav.Table = TablaCapas
        datav.RowFilter = "Tipo=1"
        DataList1.DataSource = datav.ToTable()
        DataList1.DataBind()
        datav.Table = TablaCapas
        datav.RowFilter = "Tipo=2"
        DataList2.DataSource = datav.ToTable()
        DataList2.DataBind()

    End Sub
End Class
