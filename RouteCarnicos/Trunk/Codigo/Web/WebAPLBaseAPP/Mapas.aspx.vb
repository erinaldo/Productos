
Partial Class Mapas
    Inherits System.Web.UI.Page

#Region "Variables"
    Dim IntCommandTimeOut As Integer
    Dim UsuarioID As String
    Dim mensaje As DBConexion.cMensaje
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lbError.Text = ""
        If Not Page.IsPostBack Then
            Dim leng As String
            Dim ins As New DBConexion.cConexionSQL

            leng = DBConexion.cMensaje.ObtenerLenguaje
            mensaje = New DBConexion.cMensaje

            If Not IsConnectionAvailable() Then
                Response.Write("<html><body><table style=""height: 640px; width: 100%; vertical-align: middle; text-align: center""><tr><td><img src=""images/RouteDegradado.png"" /></td></tr></table> <script type=""text/javascript"">alert(""" & mensaje.RecuperarDescripcion("E0707") & """);</Script></body></html>")
                Response.End()
                Exit Sub
            End If



            Me.txtFInicio.Text = Date.Today.ToString("dd/MM/yyyy")
           
            LLenarEtiquetas()
            If (DDlRutas.Items.Count <= 0) Then
                Dim datRep As Data.DataTable = ins.EjecutarConsulta("SELECT distinct * from ruta order by descripcion")
                datRep.TableName = "Rutas"
                DDlRutas.DataTextField = "Descripcion"
                DDlRutas.DataValueField = "RutClave"
                DDlRutas.DataSource = datRep
                DDlRutas.DataMember = "Rutas"
                DDlRutas.DataBind()
            End If
            If (ddlCentroD.Items.Count <= 0) Then
                Dim datRep As Data.DataTable = ins.EjecutarConsulta("select AlmacenId,clave + ' ' + Nombre as Nombre from almacen where tipo=1 ")
                datRep.TableName = "Cedis"
                ddlCentroD.DataTextField = "Nombre"
                ddlCentroD.DataValueField = "AlmacenId"
                ddlCentroD.DataSource = datRep
                ddlCentroD.DataMember = "Cedis"
                ddlCentroD.DataBind()
            End If
            If (ddlMapa.Items.Count <= 0) Then
                Dim datRep As Data.DataTable = ins.EjecutarConsulta("select vavclave,Descripcion from vavdescripcion where varcodigo ='MAPAW' and vadtipolenguaje='" + leng + "'")
                datRep.TableName = "Mapas"
                ddlMapa.DataTextField = "Descripcion"
                ddlMapa.DataValueField = "vavclave"
                ddlMapa.DataSource = datRep
                ddlMapa.DataMember = "Mapas"
                ddlMapa.DataBind()
            End If
            Dim vcUsuario As New DBManager.cUsuario
            UsuarioID = Session("UsuarioID")
            vcUsuario.Recuperar(UsuarioID)
            Dim oAEliminar As New ArrayList()
            Dim vlTablaPermiso As Data.DataTable
            Dim vlPermiso As String
            For i As Integer = 0 To ddlMapa.Items.Count - 1
                vlPermiso = ""
                vlTablaPermiso = ins.EjecutarConsulta("select * from intusu where permiso like '%E%' and USUId='" & vcUsuario.USUId & "' AND ACTId = '" + "MapaW" & ddlMapa.Items(i).Value + "' AND INTTipoInterfaz=3")
                If vlTablaPermiso.Rows.Count > 0 Then
                    vlPermiso = vlTablaPermiso.Rows(0)!Permiso
                Else
                    vlTablaPermiso = ins.EjecutarConsulta("select * from intper where permiso like '%E%' and PERClave='" & vcUsuario.PERClave & "' AND ACTId='" & "MapaW" & ddlMapa.Items(i).Value & "' AND INTTipoInterfaz=3")
                    If vlTablaPermiso.Rows.Count > 0 Then
                        vlPermiso = vlTablaPermiso.Rows(0)!Permiso
                    Else
                        vlPermiso = ""
                    End If
                End If
                If vlPermiso.Trim = "" Then
                    oAEliminar.Add(i)

                End If


            Next
            For i As Integer = oAEliminar.Count - 1 To 0 Step -1
                ddlMapa.Items.RemoveAt(oAEliminar(i).ToString)
            Next




        End If

        If Not (Page.ClientScript.IsClientScriptBlockRegistered("hideCalendarScript")) Then
           
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "hideCalendarScript", "function hideCalendar(calExtender) { calExtender.hide();document.getElementById(""Button1"").focus();}", True)
        End If
    End Sub
    Public Sub LLenarEtiquetas()

        lbFecha.Text = mensaje.RecuperarDescripcion("Xfecha")
        lbRuta.Text = mensaje.RecuperarDescripcion("XRuta")
        lbCentroD.Text = mensaje.RecuperarDescripcion("XCentroDistribucion")
        Button1.Text = mensaje.RecuperarDescripcion("BTContinuar")
        lbMapa.Text = mensaje.RecuperarDescripcion("XMapa")
        lbMapasW.Text = mensaje.RecuperarDescripcion("XMapasWeb")
    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) 'Handles Button1.Click
        Dim largo As Double = 0
        Dim ins As New DBConexion.cConexionSQL
        mensaje = New DBConexion.cMensaje

        lbError.Text = ""
        Dim Alto As Double = 0
        Dim Resultado As New Data.DataTable
        Try
            largo = ConfigurationManager.AppSettings("TamanioMapa").Split(",")(0) + 250
            Alto = ConfigurationManager.AppSettings("TamanioMapa").Split(",")(1) + 50
        Catch
            largo = 750
            Alto = 550
        End Try

        Dim fecha1 As Date
        Dim sFecha As String()
        sFecha = txtFInicio.Text.Split("/")
        fecha1 = New Date(sFecha(2), sFecha(1), sFecha(0)) 'txtFInicio.Text

        Select Case ddlMapa.SelectedValue
            Case 1
                If Date.Today < fecha1.Date Then
                    lbError.Text = mensaje.RecuperarDescripcion("E0087", New String() {mensaje.RecuperarDescripcion("xfecha")})
                    Exit Sub
                End If
                MapaLogistico.ObtenerTabla(Resultado, DDlRutas.SelectedValue, txtFInicio.Text)
            Case Else


        End Select
        
      


        If Resultado.Rows.Count > 0 Then
            If Not (Page.ClientScript.IsClientScriptBlockRegistered("popup")) Then
                Dim ScriptBlock As String = "<script language=""JavaScript"">"
                ScriptBlock += " function popup()"
                ScriptBlock += " { window.open('PopUpMapas.aspx?rt=" + DDlRutas.SelectedValue + "&fh=" + txtFInicio.Text + "&id=" + ddlMapa.SelectedValue + "','','dependent=yes,resizable=no, directories=no, menubar=no, personalbar=no, status=yes,alwaysRaised=yes, toolbar=no,z-lock=yes,scrollbars=yes,HEIGHT=" & Alto & ",WIDTH=" & largo & " '); }; "
                ScriptBlock += "</script>"
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "popup", ScriptBlock)
            End If
            litPopUp.Text = "<script language=""JavaScript"">popup();</script>"
        Else
            lbError.Text = mensaje.RecuperarDescripcion("E0034")
        End If

    End Sub

    Public Function IsConnectionAvailable() As Boolean
       
        Dim objUrl As New System.Uri("http://www.google.com/")

        Dim objWebReq As System.Net.WebRequest
        objWebReq = System.Net.WebRequest.Create(objUrl)
        Dim objResp As System.Net.WebResponse
        Try

            objResp = objWebReq.GetResponse
            objResp.Close()
            objWebReq = Nothing
            Return True
        Catch ex As Exception
            objWebReq = Nothing
            Return False
        End Try
    End Function


  
End Class
