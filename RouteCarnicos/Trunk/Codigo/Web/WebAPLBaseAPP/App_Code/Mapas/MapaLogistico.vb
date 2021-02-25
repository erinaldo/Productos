Imports Microsoft.VisualBasic
Imports Subgurim.Controles
Public Class MapaLogistico



    Public Shared Sub LLenarMapa(ByRef Mapa As GMap, ByVal ruta As String, ByVal fecha As String, ByRef Capas As Data.DataTable)


        Mapa.reset()
        ControlesMapas(Mapa)
        Dim mensaje As New DBConexion.cMensaje
        'Dim leng As String
        'Dim ins As New LbConexion.cConexion()
        'ins.Conectar(ConfigurationManager.ConnectionStrings("ROUTEConnectionString").ConnectionString)
        'leng = ins.EjecutarComandoScalar("SELECT top 1 TipoLenguaje FROM conhist WHERE len(TipoLenguaje) >0 ORDER BY CONHistFechaInicio DESC")
        Dim ListOfColors As New Generic.List(Of Drawing.Color)
        ListOfColors = ClaseMapasGeneral.obtenercolores()

        Dim tabla As New Data.DataTable
        ObtenerTabla(tabla, ruta, fecha)

        If Capas.Rows.Count = 0 Then
            Capas.Rows.Add(New Object() {"1", mensaje.RecuperarDescripcion("XVisitadosEF"), "1", True, ListOfColors(0), True})
            Capas.Rows.Add(New Object() {"2", mensaje.RecuperarDescripcion("XVisitadosFF"), "1", True, ListOfColors(0), True})
            Capas.Rows.Add(New Object() {"3", mensaje.RecuperarDescripcion("XNoVisitados"), "1", True, ListOfColors(1), True})
            Capas.Rows.Add(New Object() {"4", mensaje.RecuperarDescripcion("XVisitadoMas"), "1", True, ListOfColors(2), False})
            Capas.Rows.Add(New Object() {"5", mensaje.RecuperarDescripcion("XSecReal"), "2", True, ListOfColors(0), True})
            Capas.Rows.Add(New Object() {"6", mensaje.RecuperarDescripcion("XSecConfig"), "2", True, ListOfColors(2), True})
        End If

        Dim minX As Double = Double.MaxValue, minY As Double = Double.MaxValue, maxX As Double = Double.MinValue, maxY As Double = Double.MinValue


        Dim lista As New System.Collections.Generic.List(Of Subgurim.Controles.GLatLng)

        Mapa.resetMarkers()
        Mapa.resetInfoWindows()

    
        For Each fila As Data.DataRow In tabla.Rows

            If fila("CoordenadaY") > maxY Then maxY = fila("CoordenadaY")
            If fila("CoordenadaY") < minY Then minY = fila("CoordenadaY")
            If fila("CoordenadaX") > maxX Then maxX = fila("CoordenadaX")
            If fila("CoordenadaX") < minX Then minX = fila("CoordenadaX")
            Dim mOpts As New GMarkerOptions()
            mOpts.dragCrossMove = True
            mOpts.clickable = True
            Dim icon As New GIcon()

            If (fila("visitado") = 1) Then
                icon.flatIconOptions = New FlatIconOptions(25, 25, ListOfColors(0), System.Drawing.Color.Black, fila("OrdenVisita"), System.Drawing.Color.White, 15, FlatIconOptions.flatIconShapeEnum.circle)
                For Each LatLng As GLatLng In lista
                    If LatLng.lat = fila("CoordenadaY") And fila("CoordenadaX") = LatLng.lng Then
                        icon.flatIconOptions = New FlatIconOptions(25, 25, ListOfColors(2), System.Drawing.Color.Black, fila("OrdenVisita"), System.Drawing.Color.White, 15, FlatIconOptions.flatIconShapeEnum.circle)
                        Exit For
                    End If

                Next
                lista.Add(New GLatLng(fila("CoordenadaY"), fila("CoordenadaX")))
            Else
                icon.flatIconOptions = New FlatIconOptions(25, 25, ListOfColors(1), System.Drawing.Color.Black, "", System.Drawing.Color.White, 15, FlatIconOptions.flatIconShapeEnum.circle)
            End If

            mOpts.icon = icon

            Dim marka As New GMarker(New GLatLng(fila("CoordenadaY"), fila("CoordenadaX")), mOpts)

            Dim html As New StringBuilder
            GenerarHTML(html, fila)

            Dim ventana As New GInfoWindow(marka, html.ToString())

            If (Not IsDBNull(fila("fuerafrecuencia"))) AndAlso fila("fuerafrecuencia") = "0" And Capas.Select("id=1")(0).Item("Seleccionado") = True Then
                Mapa.Add(ventana) 'Con La Ventana Se Añade La Marca
            ElseIf (Not IsDBNull(fila("fuerafrecuencia"))) AndAlso fila("fuerafrecuencia") = "1" And Capas.Select("id=2")(0).Item("Seleccionado") = True Then
                Mapa.Add(ventana)
            ElseIf fila("visitado") = "0" And Capas.Select("id=3")(0).Item("Seleccionado") = True Then
                Mapa.Add(ventana)
            End If
        Next

        Dim linea As New Subgurim.Controles.GPolyline(lista)
        linea.colorNet = ListOfColors(0)
        linea.clickable = True
        linea.opacity = 0.7

        If Capas.Select("id=5")(0).Item("Seleccionado") = True Then
            Mapa.addPolyline(linea)
        End If





        If Capas.Select("id=6")(0).Item("Seleccionado") = True Then

            Dim Ordenador As New Data.DataView(tabla, "", "ordenagenda", Data.DataViewRowState.CurrentRows)

            Dim listaConfigurada As New System.Collections.Generic.List(Of Subgurim.Controles.GLatLng)
            For Each fila As Data.DataRowView In Ordenador
                If IsDBNull(fila("fuerafrecuencia")) Then
                    listaConfigurada.Add(New GLatLng(fila("CoordenadaY"), fila("CoordenadaX")))
                ElseIf fila("fuerafrecuencia") = False Then
                    listaConfigurada.Add(New GLatLng(fila("CoordenadaY"), fila("CoordenadaX")))
                End If
            Next
            Dim lineaConfigurada As New Subgurim.Controles.GPolyline(listaConfigurada)
            lineaConfigurada.colorNet = ListOfColors(2)
            lineaConfigurada.clickable = True
            lineaConfigurada.opacity = 0.7
            Mapa.addPolyline(lineaConfigurada)
        End If




        If minY <> Double.MaxValue Then
            Dim sw As New Subgurim.Controles.GLatLng(minY, minX)
            Dim ne As New Subgurim.Controles.GLatLng(maxY, maxX)
            Dim bound As New Subgurim.Controles.GLatLngBounds(sw, ne)

            Dim zoom As Integer = Mapa.getBoundsZoomLevel(bound)
            Mapa.setCenter(bound.getCenter, zoom)

        End If


    End Sub

    Public Shared Sub ObtenerTabla(ByRef Tabla As Data.DataTable, ByVal ruta As String, ByVal fecha As String)
        Dim leng As String = DBConexion.cMensaje.ObtenerLenguaje
        Dim ins As New DBConexion.cConexionSQL
        Dim Query As New StringBuilder()

        Query.AppendLine("select * from (")
        Query.AppendLine("")

        'no visitados
        Query.AppendLine("select null as distanciagps,")
        Query.AppendLine("'No' as GPSLeido,")
        Query.AppendLine("null as fuerafrecuencia,")
        Query.AppendLine("ag.orden as ordenagenda,")
        Query.AppendLine("'No Visitado' as improductividad,")
        Query.AppendLine("null as ordenvisita,")
        Query.AppendLine("null as total,")
        Query.AppendLine("'No' as codigoleido,")
        Query.AppendLine("null as FechaHoraInicial,")
        Query.AppendLine("0 as visitado")
        Query.AppendLine(",cd.CoordenadaX,cd.CoordenadaY,c.clave,c.razonsocial")
        Query.AppendLine("from agendavendedor ag")
        Query.AppendLine("inner join cliente c on c.ClienteClave =ag.clienteclave")
        Query.AppendLine("inner join ClienteDomicilio  cd on cd.clienteclave=  c.ClienteClave and cd.tipo=2 ")
        Query.AppendLine("where ag.RUTClave='" + ruta + "' and  ag.DiaClave='" + fecha + "' and not cd.CoordenadaX is null and ag.clienteclave not in(select clienteclave from visita v where v.RUTClave='" + ruta + "' and v.DiaClave='" + fecha + "')")

        Query.AppendLine("union all")

        'visitados
        Query.AppendLine("select v.distanciagps,")
        Query.AppendLine("(case when v.GPSLeido=1 then 'Si' else 'No' end)as GPSLeido,")
        Query.AppendLine("v.fuerafrecuencia,")
        Query.AppendLine("ag.orden as ordenagenda,")
        Query.AppendLine("(select descripcion from vavdescripcion where varcodigo ='motimpro' and vadtipolenguaje ='EM' and vavclave = im.tipomotivo)as improductividad,")
        Query.AppendLine("v.numero as ordenvisita,")
        Query.AppendLine("sum(t.total),")
        Query.AppendLine("(case when v.codigoleido=1 then 'Si' else 'No' end)as codigoleido,")
        Query.AppendLine("v.FechaHoraInicial,")
        Query.AppendLine("1 as visitado")
        Query.AppendLine(",cd.CoordenadaX,cd.CoordenadaY,c.clave,c.razonsocial")
        Query.AppendLine("from visita v ")
        Query.AppendLine("inner join cliente c on c.ClienteClave =v.clienteclave")
        Query.AppendLine("inner join ClienteDomicilio  cd on cd.clienteclave=  c.ClienteClave and cd.tipo=2")
        Query.AppendLine("left join agendavendedor ag on v.diaclave=ag.diaclave and v.rutclave=ag.rutclave and V.clienteclave=ag.clienteclave")
        Query.AppendLine("left join transprod t on t.visitaclave=t.visitaclave and c.clienteclave=t.clienteclave and t.diaclave=v.diaclave")
        Query.AppendLine("left join improductividadventa im on v.visitaclave=im.visitaclave and v.diaclave=im.diaclave")
        Query.AppendLine("where v.RUTClave='" + ruta + "' and v.DiaClave='" + fecha + "' and not cd.CoordenadaX is null")
        Query.AppendLine("group by v.distanciagps,GPSLeido,v.fuerafrecuencia,ag.orden,im.TipoMotivo,v.numero,v.codigoleido,v.fechahorainicial,cd.coordenadax,cd.coordenaday,c.clave,c.razonsocial")
        Query.AppendLine("")

        Query.AppendLine(")as t1")
        Query.AppendLine("order by ordenvisita")








        Tabla = ins.EjecutarConsulta(Query.ToString())
    End Sub
    Public Shared Sub ControlesMapas(ByRef Mapa As GMap)
        Mapa.enableHookMouseWheelToZoom = True
        Mapa.mapType = GMapType.GTypes.Normal
        Mapa.addMapType(GMapType.GTypes.Physical)
        Mapa.addControl(New GControl(GControl.preBuilt.MapTypeControl))
        Mapa.addControl(New GControl(GControl.preBuilt.ScaleControl, New GControlPosition(GControlPosition.position.Bottom_Left)))
        Mapa.addControl(New GControl(GControl.preBuilt.LargeMapControl, New GControlPosition(GControlPosition.position.Top_Left)))
    End Sub
    Public Shared Sub GenerarHTML(ByRef HTML As StringBuilder, ByVal fila As Data.DataRow)
        Dim Mensaje As New DBConexion.cMensaje
        Dim Negritas As String = "style=""font-family: Arial;font-size: 7pt;	font-weight: bold;"""
        Dim Normal As String = "style=""font-family: Arial;font-size: 7pt;"""
        Dim StyleTable As String = "style=""border-bottom-style: none; padding-bottom: 0px; border-right-style: none; margin: 0px; padding-left: 0px; padding-right: 0px; border-top-style: none; border-left-style: none; padding-top: 0px; clip: rect(0px 0px 0px 0px); border-collapse: collapse;"""
        HTML.AppendLine("<table " & StyleTable & ">")
        '------------------------------------------------------NuevoRow*************
        HTML.AppendLine("    <tr " & StyleTable & ">")
        HTML.AppendLine("        <td  colspan=""2"" " & StyleTable & "> ")
        HTML.AppendLine("            <span " & Negritas & ">" + mensaje.RecuperarDescripcion("XClave") + " </span><span " & Normal & ">" & fila("Clave") & "</span>")
        HTML.AppendLine("        </td>")
        HTML.AppendLine("    </tr>")
        '------------------------------------------------------NuevoRow*************
        HTML.AppendLine("    <tr " & StyleTable & ">")
        HTML.AppendLine("        <td colspan=""2"" " & StyleTable & "> ")
        HTML.AppendLine("            <span " & Negritas & ">" + mensaje.RecuperarDescripcion("CLIRazonSocial") + " </span><span  " & Normal & ">" & fila("RazonSocial") & "</span>")
        HTML.AppendLine("        </td>")
        HTML.AppendLine("    </tr>")
        '------------------------------------------------------NuevoRow*************
        HTML.AppendLine("    <tr " & StyleTable & ">")
        HTML.AppendLine("       <td " & StyleTable & ">")
        HTML.AppendLine("           <span " & Negritas & ">" + mensaje.RecuperarDescripcion("XCodigoBarras") + " </span><span " & Normal & ">" & fila("CodigoLeido") & "&nbsp;</span>")
        HTML.AppendLine("        </td> ")
        HTML.AppendLine("        <td " & StyleTable & ">")
        If Not IsDBNull(fila("FechaHoraInicial")) Then
            HTML.AppendLine("            <span " & Negritas & ">Hora Visita </span><span " & Normal & ">" & CType(fila("FechaHoraInicial"), DateTime).ToShortTimeString & "</span>")
        Else
            HTML.AppendLine("            <span " & Negritas & ">Hora Visita </span><span " & Normal & ">" & "Sin Visita" & "</span>")
        End If
        HTML.AppendLine("        </td>")
        HTML.AppendLine("    </tr>")
        '------------------------------------------------------NuevoRow*************
        HTML.AppendLine("    </tr>")
        HTML.AppendLine("       <td " & StyleTable & ">")
        HTML.AppendLine("           <span " & Negritas & ">" + mensaje.RecuperarDescripcion("XGPSLeido") + " </span><span " & Normal & ">" & fila("GPSLeido") & "</span>")
        HTML.AppendLine("        </td> ")
        If Not IsDBNull(fila("DistanciaGps")) Then
            HTML.AppendLine("       <td " & StyleTable & ">")
            HTML.AppendLine("           <span " & Negritas & ">" + mensaje.RecuperarDescripcion("XDistanciaGPS") + " </span><span " & Normal & ">" & fila("DistanciaGps") & mensaje.RecuperarDescripcion("XMetros") & "</span>")
            HTML.AppendLine("        </td> ")
        End If
        HTML.AppendLine("    </tr>")
        '------------------------------------------------------NuevoRow************
        If Not (IsDBNull(fila("Total"))) OrElse Not IsDBNull(fila("improductividad")) Then
            HTML.AppendLine("    <tr " & StyleTable & ">")
            If IsDBNull(fila("Total")) Then
                HTML.AppendLine("        <td " & StyleTable & ">")
                HTML.AppendLine("            <span " & Negritas & ">" + mensaje.RecuperarDescripcion("XMotivoImprod") + " </span><span " & Normal & ">" & fila("improductividad") & "</span>")
                HTML.AppendLine("        </td>")
            Else
                HTML.AppendLine("       <td " & StyleTable & ">")
                HTML.AppendLine("           <span " & Negritas & ">" + mensaje.RecuperarDescripcion("XVentaTotal") + " </span><span " & Normal & ">" & fila("Total") & "</span>")
                HTML.AppendLine("        </td> ")
            End If
            HTML.AppendLine("       <td " & StyleTable & ">")

            HTML.AppendLine("        </td> ")
            HTML.AppendLine("    </tr>")
        End If
        '------------------------------------------------------NuevoRow****************
        HTML.AppendLine("    <tr " & StyleTable & ">")
        HTML.AppendLine("        <td " & StyleTable & ">")
        HTML.AppendLine("            <span " & Negritas & ">" + mensaje.RecuperarDescripcion("XSecReal") + " </span><span " & Normal & ">" & fila("ordenvisita") & "</span>")
        HTML.AppendLine("        </td>")
        HTML.AppendLine("       <td " & StyleTable & ">")
        HTML.AppendLine("           <span " & Negritas & ">" + mensaje.RecuperarDescripcion("XSecConfig") + " </span><span " & Normal & ">" & fila("ordenagenda") & "</span>")
        HTML.AppendLine("        </td> ")
        HTML.AppendLine("    </tr>")
        '------------------------------------------------------NuevoRow*****************
        HTML.AppendLine("</table>")
    End Sub
End Class
