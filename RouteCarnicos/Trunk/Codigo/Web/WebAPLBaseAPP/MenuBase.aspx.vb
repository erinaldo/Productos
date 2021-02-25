Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Data
Imports Janus.Web.UI

Partial Class TEST
    Inherits System.Web.UI.Page

    Private vcMensaje As DBConexion.cMensaje
    Private vcUsuario As DBManager.cUsuario
    Private vcFecha As Date

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not Me.IsPostBack) Then
            'Revisar la session
            'If Session("UsuarioID") = "" Then
            '    vcConexion.Desconectar()
            '    Response.Redirect("Login.aspx")
            'End If

            'If Not Me.IsPostBack Then
            '    CConexion.chkConexion()

            Inicializar_Menu("splash.aspx")

            'End If
        End If

    End Sub

    Public Sub Inicializar_Menu(ByVal strLinkContenido As String)

        Dim vlMODRow As System.Data.DataRow
        Dim vlMODDataTable As New System.Data.DataTable
        Dim ins As New DBConexion.cConexionSQL
        vcMensaje = New DBConexion.cMensaje
        Dim vlIcon1 As New System.Drawing.Icon(Server.MapPath(".") + "\Images\Icono.dat")

        vcUsuario = New DBManager.cUsuario
        vcUsuario.Recuperar(Session("UsuarioID").ToString())

        ' configure the root panel of the manager
        Dim outlookGroup As Janus.Web.UI.Dock.UIPanelGroup = New Janus.Web.UI.Dock.UIPanelGroup(Janus.Web.UI.Dock.PanelGroupStyle.OutlookNavigator)
        outlookGroup.Width = New System.Web.UI.WebControls.Unit(180)
        outlookGroup.Key = "uiOutlookPanel"

        vlMODDataTable = ins.EjecutarConsulta("Select * from Modulo where MODId1 is NULL and TipoInterfaz=3 ORDER BY SECUENCIA ", "Modulo")
        For Each vlMODRow In vlMODDataTable.Rows

            Dim vlArrayImage() As Byte = CType(vlMODRow("Imagen"), Byte())
            Dim vlMS As New System.IO.MemoryStream(vlArrayImage)

            Dim oImage As System.Drawing.Image
            oImage = System.Drawing.Image.FromStream(vlMS)

            Dim pbImg As New System.Windows.Forms.PictureBox

            pbImg.Height = 16
            pbImg.Width = 16

            pbImg.Image = System.Drawing.Image.FromStream(vlMS, True)
            pbImg.SizeMode = Windows.Forms.PictureBoxSizeMode.Normal
            Dim strImagen As String
            Dim strImagenURL As String
            strImagen = Server.MapPath(".") + "\images\" & vlMODRow("MODId") & ".gif"
            strImagenURL = "~\images\" + vlMODRow("MODId") & ".gif"
            Try
                pbImg.Image.Save(strImagen, System.Drawing.Imaging.ImageFormat.Gif)
            Catch ex As Exception

            End Try

            vlMS.Close()

            ' add two panels
            Dim oPanelMod As Janus.Web.UI.Dock.UIPanelGroup = New Janus.Web.UI.Dock.UIPanelGroup

            oPanelMod.Key = Trim(vlMODRow("MODId"))

            'oPanelMod.LargeImage = strImagenURL
            oPanelMod.Text = vcMensaje.RecuperarDescripcion("XActividades")
            oPanelMod.CaptionStyle = Dock.PanelCaptionStyle.Dark


            Dim activitiesPanel As Janus.Web.UI.Dock.UIPanel = New Janus.Web.UI.Dock.UIPanel
            activitiesPanel.CaptionStyle = Dock.PanelCaptionStyle.Light
            activitiesPanel.Key = Trim(vlMODRow("MODId")) & "1"

            activitiesPanel.InnerContainerType = Dock.InnerContainerType.UseTemplate
            'activitiesPanel.Text = vcMensaje.RecuperarDescripcion("XActividades")
            oPanelMod.Panels.Add(activitiesPanel)

            Call AgregarPanel(vlMODRow, activitiesPanel)

            outlookGroup.Panels.Add(oPanelMod)

        Next

        Dim oPanelContent As Janus.Web.UI.Dock.UIPanelGroup = New Janus.Web.UI.Dock.UIPanelGroup
        oPanelContent.CaptionDisplayMode = Dock.PanelCaptionDisplayMode.Text
        oPanelContent.BorderCaption = InheritableBoolean.False
        oPanelContent.CaptionStyle = Dock.PanelCaptionStyle.Light
        oPanelContent.CaptionVisible = InheritableBoolean.False

        Dim oPnlBarra As Janus.Web.UI.Dock.UIPanel = New Janus.Web.UI.Dock.UIPanel
        oPnlBarra.Width = New System.Web.UI.WebControls.Unit(100, UnitType.Percentage)
        oPnlBarra.Height = New System.Web.UI.WebControls.Unit(30, UnitType.Pixel)
        oPnlBarra.Key = "uiPanelBarra"
        'oPnlBarra.Text = "Barra"
        oPnlBarra.CaptionStyle = Dock.PanelCaptionStyle.Light
        oPnlBarra.CaptionDisplayMode = Dock.PanelCaptionDisplayMode.Text

        oPnlBarra.InnerContainerType = Dock.InnerContainerType.UseUserControlUrl
        oPnlBarra.InnerContainerUserControlUrl = "~\UserControls\Barra.ascx"


        Dim contenido As Janus.Web.UI.Dock.UIPanel = New Janus.Web.UI.Dock.UIPanel
        contenido.Width = New System.Web.UI.WebControls.Unit(100, UnitType.Percentage)
        contenido.CaptionStyle = Dock.PanelCaptionStyle.Dark
        contenido.Key = "uiPanelContenido"

        contenido.Text = "Modulo"
        contenido.InnerContainerType = Dock.InnerContainerType.UseFrames
        contenido.CaptionVisible = InheritableBoolean.True

        contenido.InnerContainerType = Dock.InnerContainerType.UseUrl
        If Not IsNothing(strLinkContenido) AndAlso strLinkContenido.Length > 0 Then
            contenido.InnerContainerUrl = strLinkContenido
        End If

        oPanelContent.Panels.Add(oPnlBarra)
        oPanelContent.Panels.Add(contenido)

        'panel principal
        Dim outlookGroup1 As Janus.Web.UI.Dock.UIPanelGroup = New Janus.Web.UI.Dock.UIPanelGroup(Janus.Web.UI.Dock.PanelGroupStyle.VerticalTiles)
        outlookGroup1.CaptionDisplayMode = Dock.PanelCaptionDisplayMode.ImageAndText
        outlookGroup1.Image = "~/Images/RouteLogoIco.gif"
        outlookGroup1.Width = New System.Web.UI.WebControls.Unit(100, UnitType.Percentage)
        outlookGroup1.Height = New System.Web.UI.WebControls.Unit(100, UnitType.Percentage)
        outlookGroup1.CaptionStyle = Dock.PanelCaptionStyle.Dark
        outlookGroup1.Key = "uiMain"

        outlookGroup1.Panels.Add(outlookGroup)
        outlookGroup1.Panels.Add(oPanelContent)
        outlookGroup1.Text = vcMensaje.RecuperarDescripcion("BI0002")

        'Crear el panel inferior
        Me.UiPanelManager1.RootPanel = outlookGroup1
        '--UiPanelManager1.Height = 830

    End Sub

    Sub AgregarPanel(ByVal peMODRow As DataRow, ByRef peItem As Janus.Web.UI.Dock.UIPanel)


        Dim vldtPanel As New DataTable

        vldtPanel.Columns.Add("ACTID", GetType(String))
        vldtPanel.Columns.Add("Secuencia", GetType(Integer))

        'vlDataTable = vcIntPer.TablaNodo.Recuperar("PERClave='" & vcPerfil.PERClave & "' AND MODId='" & peMODRow!MODId & "'and actid='REPORTESWEB' AND INTTipoInterfaz=3 ORDER BY Secuencia")
        'For Each vlDataRow As DataRow In vlDataTable.Rows
        '    If vcUsuario.IntUsu.Tabla.Existe(vcUsuario.USUId, vlDataRow!ACTId, 1) = False Then
        '        vldtPanel.Rows.Add(New Object() {vlDataRow!ACTId, vlDataRow!Secuencia})
        '    End If
        'Next

        'vlDataTable = vcUsuario.IntUsu.Tabla.Recuperar("USUId='" & vcUsuario.USUId & "' AND MODId='" & peMODRow!MODId & "'and actid='REPORTESWEB' AND INTTipoInterfaz=3 ORDER BY Secuencia")
        'For Each vlDataRow As DataRow In vlDataTable.Rows
        '    If vlDataRow!TipoVisible = 1 Then
        '        vldtPanel.Rows.Add(New Object() {vlDataRow!ACTId, vlDataRow!Secuencia})
        '    End If
        'Next
        Dim RepPer As Integer
        Dim ins As New DBConexion.cConexionSQL

        RepPer = ins.EjecutarComandoScalar("select count(*) from intusu where permiso like '%E%' and USUId='" & vcUsuario.USUId & "' AND (ACTId like '" & "ReporteW%' ) AND INTTipoInterfaz=3")
        RepPer += ins.EjecutarComandoScalar("select count(*) from intper where permiso like '%E%' and PERClave='" & vcUsuario.PERClave & "' AND (ACTId like '" & "ReporteW%') AND INTTipoInterfaz=3")
        If RepPer > 0 Then
            vldtPanel.Rows.Add(New Object() {"REPORTESWEB", 0})
        End If
        RepPer = 0
        RepPer = ins.EjecutarComandoScalar("select count(*) from intusu where permiso like '%E%' and USUId='" & vcUsuario.USUId & "' AND ( ACTId like '" & "MapaW%') AND INTTipoInterfaz=3")
        RepPer += ins.EjecutarComandoScalar("select count(*) from intper where permiso like '%E%' and PERClave='" & vcUsuario.PERClave & "' AND (ACTId like '" & "MapaW%') AND INTTipoInterfaz=3")
        If RepPer > 0 Then
            vldtPanel.Rows.Add(New Object() {"MAPASWEB", 0})
        End If



        Dim IT As New MyTemplate("")
        IT.ServerPath = Server.MapPath(".")
        peItem.InnerContainerTemplate = IT
        IT.Elementos = vldtPanel
        Dim pnl As New Panel


        IT.InstantiateIn(pnl)

        IT = Nothing
    End Sub

    Private Class MyTemplate
        Implements ITemplate
        Shared itemcount As Integer = 0
        Shared sTipo As String

        Private m_Elementos As DataTable
        Public ServerPath As String

        Sub New(ByVal Tipo As String)
            sTipo = Tipo
        End Sub

        Public Property Elementos() As DataTable
            Get
                Return m_Elementos
            End Get
            Set(ByVal Value As DataTable)
                m_Elementos = Value
            End Set
        End Property

        Sub InstantiateIn(ByVal container As Control) _
              Implements ITemplate.InstantiateIn

            Dim vlACTRow As DataRow

            Dim vlDataRows() As DataRow = m_Elementos.Select("", "Secuencia")

            Dim lc3 As New LinkButton
            lc3.Text = "<center>"
            container.Controls.Add(lc3)

            Dim ins As New DBConexion.cConexionSQL
            Dim vcMensaje As New DBConexion.cMensaje
            For Each vlDataRow As DataRow In vlDataRows
                Dim vlIntRow As DataRow

                vlACTRow = ins.EjecutarConsulta("Select * from Actividad where ACTId='" & vlDataRow!ACTId & "'", "Actividad").Rows(0)
                vlIntRow = ins.EjecutarConsulta("Select * from Interfaz where ACTId = '" + vlDataRow!ACTId + "' AND INTTipoInterfaz=3 ").Rows(0)

                CopiarImagen(vlACTRow("ACTId"), vlACTRow("Imagen"))

                'Dim lc2 As New HtmlAnchor
                Dim lc As New HtmlAnchor

                lc.EnableViewState = True
                'lc2.EnableViewState = True
                'lc2.InnerHtml = "<img src=" & vlACTRow("ACTId") & ".gif>"
                lc.Attributes.Add("border", "0") 'Quitarle el borde a la imagen


                lc.InnerHtml = "<img src='images\" & vlACTRow("ACTId") & ".gif' border='0'><br><font face='Tahoma' size=2>" & vcMensaje.RecuperarDescripcion(Trim(vlACTRow("MENNombreClave"))) & "</font><BR><BR>"


                lc.HRef = String.Format("javascript:ShowActivity('{0}','{1}');", vcMensaje.RecuperarDescripcion(Trim(vlACTRow("MENNombreClave"))), vlIntRow("Componente"))
                'lc2.HRef = lc.HRef
                lc.Name = vlIntRow("Componente")
                lc.ID = vlIntRow("Componente")
                lc.ID = Trim(vlIntRow("Componente"))

                'container.Controls.Add(lc2)
                container.Controls.Add(lc)
            Next
        End Sub

        Function CopiarImagen(ByVal pvImg As String, ByVal pvImagen As Object) As Boolean

            Dim vlArrayImage() As Byte = CType(pvImagen, Byte())
            Dim vlMS As New System.IO.MemoryStream(vlArrayImage)

            Dim oImage As System.Drawing.Image

            oImage = System.Drawing.Image.FromStream(vlMS)

            Dim pbImg As New System.Windows.Forms.PictureBox


            pbImg.Height = 16
            pbImg.Width = 16

            pbImg.Image = oImage

            pbImg.SizeMode = Windows.Forms.PictureBoxSizeMode.Normal

            Dim strImagen As String
            strImagen = ServerPath + "\images\" & pvImg & ".gif"

            Try
                pbImg.Image.Save(strImagen, System.Drawing.Imaging.ImageFormat.Gif)

            Catch ex As Exception

            End Try

            vlMS.Close()

            Return True

        End Function


    End Class


End Class
