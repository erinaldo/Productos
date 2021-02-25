
Partial Class MobileMonitorV
    Inherits System.Web.UI.Page

    Private Enum Estado
        EnError = 1
        EnProceso = 2
        Finalizado = 3
        Todos = 4
    End Enum
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Try
                CargarDatos(Estado.Todos, "")
            Catch ex As Exception
            End Try
        End If
    End Sub
    Private Function CargarDatos(ByVal est As Estado, ByVal clave As String) As Integer
        Dim ruta As String = ServicesCentral.Configuracion.Directorio + "\LogInt\" + Me.Request("c")
        Dim dir As New System.IO.DirectoryInfo(ruta)
        Dim ArchsError As System.IO.FileInfo() = dir.GetFiles("*.err")
        Dim ArchsProc As System.IO.FileInfo() = dir.GetFiles("*.pro")
        Dim ArchsFinal As System.IO.FileInfo() = dir.GetFiles("*.bie")

        dlErrores.SelectedIndex = -1
        dlProcesando.SelectedIndex = -1
        dlTerminados.SelectedIndex = -1

        If clave <> "" Then
            Select Case est
                Case Estado.Finalizado
                    Dim i As Integer = 0
                    For Each f As System.IO.FileInfo In ArchsFinal
                        If f.Name = clave Then
                            dlTerminados.SelectedIndex = i
                            Exit For
                        End If
                        i = i + 1
                    Next
                Case Estado.EnError
                    Dim i As Integer = 0
                    For Each f As System.IO.FileInfo In ArchsError
                        If f.Name = clave Then
                            dlErrores.SelectedIndex = i
                            Exit For
                        End If
                        i = i + 1
                    Next
                Case Estado.EnProceso
                    Dim i As Integer = 0
                    For Each f As System.IO.FileInfo In ArchsProc
                        If f.Name = clave Then
                            dlProcesando.SelectedIndex = i
                            Exit For
                        End If
                        i = i + 1
                    Next
            End Select
        End If

        dlErrores.DataSource = ArchsError
        dlErrores.DataBind()

        dlProcesando.DataSource = ArchsProc
        dlProcesando.DataBind()

        dlTerminados.DataSource = ArchsFinal
        dlTerminados.DataBind()
    End Function

    Protected Sub dlTerminados_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles dlTerminados.ItemCommand
        If e.CommandName = "Detalles" Then
            CargarDatos(Estado.Finalizado, e.CommandArgument)
        End If
        If e.CommandName = "Cerrar" Then
            CargarDatos(Estado.Todos, "")
        End If
    End Sub
    Protected Sub dlErrores_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles dlErrores.ItemCommand
        If e.CommandName = "Detalles" Then
            CargarDatos(Estado.EnError, e.CommandArgument)
        End If
        If e.CommandName = "Cerrar" Then
            CargarDatos(Estado.Todos, "")
        End If
        If e.CommandName = "Ejecutar" Then
            EjecutarInterfaz(e.CommandArgument)
        End If
    End Sub
    Protected Sub dlProcesando_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles dlProcesando.ItemCommand
        If e.CommandName = "Detalles" Then
            CargarDatos(Estado.EnProceso, e.CommandArgument)
        End If
        If e.CommandName = "Cerrar" Then
            CargarDatos(Estado.Todos, "")
        End If
    End Sub


    Private Function CargarDetalle(ByVal ruta As String) As Data.DataTable
        Dim tabla As New Data.DataTable
        Try
            tabla.ReadXml(ruta)
        Catch ex As Exception

        End Try
        Return tabla
    End Function

    Private Function EjecutarInterfaz(ByVal archivo As String) As Data.DataTable
        Dim tabla As New Data.DataTable
        Dim ruta As String = ServicesCentral.Configuracion.Directorio + "\LogInt\" + Me.Request("c") + "\" + archivo
        Try
            tabla.ReadXml(ruta)

            Dim filas As Data.DataRow() = tabla.Select("Error = True")
            Dim vendedorid As String = ""
            Dim fechainicio As DateTime
            Dim fechaprimerdia As DateTime
            For Each f As Data.DataRow In filas
                If Convert.ToBoolean(f("Error")) Then
                    vendedorid = f("VendedorId")
                    fechainicio = f("FechaInicio")
                    fechaprimerdia = f("FechaPrimerDia")
                End If
            Next
            If vendedorid <> "" Then
                Dim servi As New ServiceMobileClient
                servi.WSEjecutarInterfaces(vendedorid, fechainicio, fechaprimerdia, "", False)
                'Dim servicio As New HiloEjecutaInterfaces(vendedorid, fechainicio, fechaprimerdia)
                'servicio.EjecutarInterfaces()
                CargarDatos(Estado.Todos, "")
            End If
        Catch ex As Exception

        End Try
        Return tabla
    End Function


    Protected Sub dlTerminados_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles dlTerminados.ItemDataBound
        If dlTerminados.SelectedIndex > -1 Then
            If e.Item.ItemIndex = dlTerminados.SelectedIndex Then
                Dim dlDetalle As DataList = DirectCast(e.Item.FindControl("dlDetalle"), DataList)
                Dim f As IO.FileInfo = e.Item.DataItem
                dlDetalle.DataSource = CargarDetalle(f.FullName)
                dlDetalle.DataBind()
            End If
        End If

    End Sub

    Protected Sub dlProcesando_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles dlProcesando.ItemDataBound
        If dlProcesando.SelectedIndex > -1 Then
            If e.Item.ItemIndex = dlProcesando.SelectedIndex Then
                Dim dlDetalle As DataList = DirectCast(e.Item.FindControl("dlDetalle"), DataList)
                Dim f As IO.FileInfo = e.Item.DataItem
                dlDetalle.DataSource = CargarDetalle(f.FullName)
                dlDetalle.DataBind()
            End If
        End If
    End Sub

    Protected Sub dlErrores_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles dlErrores.ItemDataBound
        If dlErrores.SelectedIndex > -1 Then
            If e.Item.ItemIndex = dlErrores.SelectedIndex Then
                Dim dlDetalle As DataList = DirectCast(e.Item.FindControl("dlDetalle"), DataList)
                Dim f As IO.FileInfo = e.Item.DataItem
                dlDetalle.DataSource = CargarDetalle(f.FullName)
                dlDetalle.DataBind()
            End If
        End If
    End Sub


    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        CargarDatos(Estado.Todos, "")
    End Sub
End Class
