Imports System.IO
Imports FieldSoftware.PrinterCE_NetCF

Public Class FormResumenPromociones
    Inherits System.Windows.Forms.Form
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal parsClienteClave As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call

        sClienteClave = parsClienteClave
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If Not Me.MenuItemRegresar Is Nothing Then Me.MenuItemRegresar.Dispose()
        If Not Me.MainMenu1 Is Nothing Then Me.MainMenu1.Dispose()
        MyBase.Dispose(disposing)
    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ButtonImprimir As System.Windows.Forms.Button
    Friend WithEvents ButtonRegresar As System.Windows.Forms.Button
    Friend WithEvents txtReporte As System.Windows.Forms.TextBox

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents MenuItemRegresar As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.MenuItemRegresar = New System.Windows.Forms.MenuItem
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.ButtonImprimir = New System.Windows.Forms.Button
        Me.ButtonRegresar = New System.Windows.Forms.Button
        Me.txtReporte = New System.Windows.Forms.TextBox
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.Add(Me.MenuItemRegresar)
        '
        'MenuItemRegresar
        '
        Me.MenuItemRegresar.Text = "MenuItemRegresar"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ButtonImprimir)
        Me.Panel1.Controls.Add(Me.ButtonRegresar)
        Me.Panel1.Controls.Add(Me.txtReporte)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(242, 295)
        '
        'ButtonImprimir
        '
        Me.ButtonImprimir.Enabled = False
        Me.ButtonImprimir.Location = New System.Drawing.Point(81, 262)
        Me.ButtonImprimir.Name = "ButtonImprimir"
        Me.ButtonImprimir.Size = New System.Drawing.Size(72, 24)
        Me.ButtonImprimir.TabIndex = 3
        Me.ButtonImprimir.Text = "ButtonImprimir"
        '
        'ButtonRegresar
        '
        Me.ButtonRegresar.Location = New System.Drawing.Point(5, 262)
        Me.ButtonRegresar.Name = "ButtonRegresar"
        Me.ButtonRegresar.Size = New System.Drawing.Size(72, 24)
        Me.ButtonRegresar.TabIndex = 4
        Me.ButtonRegresar.Text = "ButtonRegresar"
        '
        'txtReporte
        '
        Me.txtReporte.Location = New System.Drawing.Point(6, 6)
        Me.txtReporte.Multiline = True
        Me.txtReporte.Name = "txtReporte"
        Me.txtReporte.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtReporte.Size = New System.Drawing.Size(228, 253)
        Me.txtReporte.TabIndex = 5
        Me.txtReporte.WordWrap = False
        '
        'FormResumenPromociones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(242, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Menu = Me.MainMenu1
        Me.Name = "FormResumenPromociones"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "VARIABLES"
    Private sNombreArchivo As String = "\Reporte.txt"
    Dim refaVista As Vista
    Private sClienteClave As String
    Private LongitudTicket As Integer = 48
#End Region

#Region "METODOS"
    Private Sub CreaReporte()
        Dim Sw As StreamWriter
        CreaArchivo(Sw, sNombreArchivo)
        'CreaEncabezado(Sw)
        CreaTitulos(Sw)
        ReportePromociones(Sw)
        Sw.Flush()
        Sw.Close()
    End Sub

    Private Sub CreaTitulos(ByRef sw As StreamWriter)
        sw.WriteLine(TextoCentrado(refaVista.BuscarMensaje("Mensajes", "XPromocionesVigentes"), LongitudTicket))
        ImprimeLineaPunteada(sw, LongitudTicket)
        Dim cad As String = CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XClave"), 12, Alineacion.Izquierda, False)
        cad &= CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XPromocion"), 32, Alineacion.Izquierda, False)
        cad &= CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XTipo"), 4, Alineacion.Izquierda, True)
        sw.WriteLine(cad)
        ImprimeLineaPunteada(sw, LongitudTicket)
    End Sub

    Private Sub ReportePromociones(ByRef sw As StreamWriter)
        Try
            Dim Q, Cad As String
            If sClienteClave <> String.Empty Then
                'Obtener los esquemas del cliente
                Dim DataViewEsquemas As DataView
                Dim DataTableEsquemasCliente As DataTable

                Dim Cliente As New Cliente(sClienteClave)
                Cliente.RecuperarEsquemas(DataViewEsquemas, DataTableEsquemasCliente)

                Dim sEsquemasCliente As String = String.Empty

                For Each dr As DataRow In DataTableEsquemasCliente.Rows
                    sEsquemasCliente &= "'" & dr("EsquemaID") & "',"
                    Cliente.RecuperarEsquemasCliente(DataViewEsquemas, sEsquemasCliente, dr("EsquemaID"))
                Next
                If sEsquemasCliente.Length > 0 Then
                    sEsquemasCliente = Microsoft.VisualBasic.Left(sEsquemasCliente, sEsquemasCliente.Length - 1)
                End If
                DataViewEsquemas.Dispose()
                If DataTableEsquemasCliente.Rows.Count = 0 Then Exit Sub
                DataTableEsquemasCliente.Dispose()
                Q = "Select promocionclave, promocion.nombre, promocion.tipoaplicacion, promocion.fechafinal, promocion.tiporegla, promocion.seleccionproducto, promocion.capturacantidad, promocion.Tipo from promocion where promocion.TipoEstado=1 and Tipo = 1 and getdate() between promocion.FechaInicial and promocion.FechaFinal UNION Select Promocion.PromocionClave, promocion.nombre, promocion.tipoaplicacion, promocion.fechafinal, promocion.tiporegla, promocion.seleccionproducto, promocion.capturacantidad, promocion.Tipo from promocion INNER JOIN PromocionDetalle ON PromocionDetalle.PromocionClave = Promocion.PromocionClave where promocion.TipoEstado=1 and Tipo in(2,3,4) and PromocionDetalle.EsquemaID in(" & sEsquemasCliente & ") and getdate() between promocion.FechaInicial and promocion.FechaFinal "
            Else
                Q = "Select promocionclave, promocion.nombre, promocion.tipoaplicacion, promocion.fechafinal, promocion.tiporegla, promocion.seleccionproducto, promocion.capturacantidad, promocion.Tipo from promocion where promocion.TipoEstado=1 and getdate() between promocion.FechaInicial and promocion.FechaFinal  "
            End If

            Dim dtPromociones As DataTable = oDBVen.RealizarConsultaSQL(Q, "Promociones")
            For Each Dr As DataRow In dtPromociones.Rows
                Cad = CompletaHasta(Dr("promocionclave"), 12, Alineacion.Izquierda, False)
                Cad &= CompletaHasta(Dr("nombre"), 32, Alineacion.Izquierda, False)
                Cad &= CompletaHasta(Dr("tipoaplicacion"), 4, Alineacion.Derecha, True)
                sw.WriteLine(Cad)
                If Dr("Tipo") = 4 Then
                    Cad = CompletaHasta("  " & refaVista.BuscarMensaje("Mensajes", "XSeleccionarProducto") & ": " & IIf(Dr("SeleccionProducto"), refaVista.BuscarMensaje("Mensajes", "XSi"), refaVista.BuscarMensaje("Mensajes", "XNo")), 48, Alineacion.Izquierda, True)
                    sw.WriteLine(Cad)
                    Cad = CompletaHasta("  " & refaVista.BuscarMensaje("Mensajes", "XCapturarCantidad") & ": " & IIf(Dr("CapturaCantidad"), refaVista.BuscarMensaje("Mensajes", "XSi"), refaVista.BuscarMensaje("Mensajes", "XNo")), 48, Alineacion.Izquierda, True)
                    sw.WriteLine(Cad)
                End If
                Cad = CompletaHasta("  " & refaVista.BuscarMensaje("Mensajes", "XFinaliza") & ":", 14, Alineacion.Izquierda, False)
                Cad &= CompletaHasta(Format(Dr("fechafinal"), "dd/MM/yyyy"), 34, Alineacion.Izquierda, True)
                sw.WriteLine(Cad)
                '*******************************
                'Si la promoción es de productos, se muestran los productos
                If Dr("Tipo") = 1 Then
                    sw.WriteLine("  " & refaVista.BuscarMensaje("Mensajes", "XPromocionAplicadaA"))
                    Dim oDT2 As DataTable = oDBVen.RealizarConsultaSQL("select distinct Producto.ProductoClave,producto.nombre from producto inner join promocionproducto on promocionproducto.productoclave=producto.productoclave where promocionproducto.promocionclave='" & Dr("promocionclave") & "'", "PromProd")
                    For Each Dr2 As DataRow In oDT2.Rows
                        Cad = CompletaHasta("   - " & Dr2("nombre"), 32, Alineacion.Izquierda, True)
                        sw.WriteLine(Cad)
                    Next
                    If oDT2.Rows.Count > 0 Then sw.WriteLine()
                    oDT2.Dispose()
                Else
                    sw.WriteLine("  " & refaVista.BuscarMensaje("Mensajes", "XPromocionAplicadaA"))
                    Dim oDT2 As DataTable = oDBVen.RealizarConsultaSQL("Select Esquema.Nombre from promociondetalle inner join Esquema on Esquema.EsquemaID = promociondetalle.EsquemaID where promociondetalle.promocionclave='" & Dr("promocionclave") & "'", "PromProd")
                    For Each Dr2 As DataRow In oDT2.Rows
                        Cad = CompletaHasta("   - " & Dr2("nombre"), 32, Alineacion.Izquierda, True)
                        sw.WriteLine(Cad)
                    Next
                    If oDT2.Rows.Count > 0 Then sw.WriteLine()
                    oDT2.Dispose()


                    sw.WriteLine("  " & refaVista.BuscarMensaje("Mensajes", "XEnProductos"))
                    Dim oDT3 As DataTable = oDBVen.RealizarConsultaSQL("select distinct producto.nombre from producto inner join promocionproducto on promocionproducto.productoclave=producto.productoclave where promocionproducto.promocionclave='" & Dr("promocionclave") & "'", "PromProd")
                    For Each Dr3 As DataRow In oDT3.Rows
                        Cad = CompletaHasta("   - " & Dr3("nombre"), 32, Alineacion.Izquierda, True)
                        sw.WriteLine(Cad)
                    Next
                    If oDT3.Rows.Count > 0 Then sw.WriteLine()
                    oDT3.Dispose()
                End If
                '*****************************
                Dim dtPromocionRegla As DataTable = oDBVen.RealizarConsultaSQL("select minimo, maximo, porcentaje, importe, precioclave, promocionreglaid from promocionregla where promocionclave='" & Dr("promocionclave") & "'", "PromocionRegla")
                For Each Dr2 As DataRow In dtPromocionRegla.Rows
                    Cad = CompletaHasta("  " & refaVista.BuscarMensaje("Mensajes", "XRangoVentas"), 18, Alineacion.Izquierda, False)
                    If Dr("TipoRegla") = 2 Then
                        Cad &= CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XPorCada") & ": " & FormatNumber(Dr2("minimo"), 2), 30, Alineacion.Izquierda, True)
                    Else
                        Cad &= CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XDe") & ": " & FormatNumber(Dr2("minimo"), 2), 15, Alineacion.Izquierda, False)
                        Cad &= CompletaHasta(refaVista.BuscarMensaje("Mensajes", "XA") & ": " & FormatNumber(Dr2("maximo"), 2), 15, Alineacion.Izquierda, True)
                    End If
                    sw.WriteLine(Cad)
                    If Dr("tipoaplicacion") = 1 Then
                        Cad = CompletaHasta("    " & refaVista.BuscarMensaje("Mensajes", "XPorcentaje") & ":", 25, Alineacion.Izquierda, False)
                        Cad &= CompletaHasta(FormatNumber(Dr2("porcentaje"), 2) & "%", 23, Alineacion.Izquierda, True)
                        sw.WriteLine(Cad)
                        sw.WriteLine()
                    ElseIf Dr("tipoaplicacion") = 2 Then
                        Cad = CompletaHasta("    " & refaVista.BuscarMensaje("Mensajes", "XImporte") & ":", 25, Alineacion.Izquierda, False)
                        Cad &= CompletaHasta("$" & FormatNumber(Dr2("importe"), 2), 23, Alineacion.Izquierda, True)
                        sw.WriteLine(Cad)
                        sw.WriteLine()
                    ElseIf Dr("tipoaplicacion") = 3 Then
                        Cad = CompletaHasta("    " & refaVista.BuscarMensaje("Mensajes", "XListaPrecio") & ":", 25, Alineacion.Izquierda, False)
                        Cad &= CompletaHasta(oDBVen.RealizarConsultaSQL("select nombre from precio where precioclave='" & Dr2("precioclave") & "'", "ListaPrecios").Rows(0).Item(0), 23, Alineacion.Izquierda, True)
                        sw.WriteLine(Cad)
                        sw.WriteLine()
                    ElseIf Dr("tipoaplicacion") = 4 Then
                        Dim dtPromocionAplicacion As DataTable
                        dtPromocionAplicacion = oDBVen.RealizarConsultaSQL("select distinct Producto.nombre, PromocionAplicacion.PRUTipoUnidad,PromocionAplicacion.Cantidad  from PromocionAplicacion inner join Producto on PromocionAplicacion.ProductoClave = Producto.ProductoClave where PromocionAplicacion.promocionclave='" & Dr("promocionclave") & "' and PromocionAplicacion.PromocionReglaId='" & Dr2("PromocionReglaId") & "'", "PromProd")
                        For Each Dr3 As DataRow In dtPromocionAplicacion.Rows
                            Cad = CompletaHasta("    " & Dr3("nombre"), 33, Alineacion.Izquierda, False)
                            Cad &= CompletaHasta(ValorReferencia.BuscarEquivalente("UNIDADV", Dr3("PRUTipoUnidad")), 10, Alineacion.Izquierda, False)
                            Cad &= CompletaHasta(Dr3("Cantidad"), 2, Alineacion.Derecha, True)
                            sw.WriteLine(Cad)
                        Next
                        dtPromocionAplicacion.Dispose()
                    End If
                Next
                dtPromocionRegla.Dispose()
                sw.WriteLine()
            Next
            dtPromociones.Dispose()
            ImprimeLineaPunteada(sw, LongitudTicket)
            'Imprimo las descripciones de los Tipos
            sw.WriteLine(refaVista.BuscarMensaje("Mensajes", "XTipo").ToUpper & ":")
            Dim aValores As ArrayList = ValorReferencia.RecuperarLista("TAPPROM")
            If Not IsNothing(aValores) AndAlso aValores.Count > 0 Then
                For Each refDesc As ValorReferencia.Descripcion In aValores
                    sw.WriteLine(refDesc.Id & " = " & refDesc.Cadena)
                Next
            End If
            aValores = Nothing
            'Dim dtValores As DataTable = ValorReferencia.RecuperarLista("TAPPROM")
            'For Each Dr As DataRow In dtValores.Rows
            '    sw.WriteLine(Dr("VAVClave") & " = " & Dr("Descripcion"))
            'Next
            EspaciosAlFinal(sw, 5)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "ReportePromociones")
        End Try
    End Sub

    Private Sub MuestraReporte()
        Dim line As String
        Try
            txtReporte.Text = ""
            Dim SrAD As StreamReader = New StreamReader(sNombreArchivo)
            Do
                line = SrAD.ReadLine()
                txtReporte.Text &= line & vbCrLf
            Loop Until line Is Nothing
            SrAD.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "MuestraReporte")
        End Try
    End Sub
#End Region

#Region "FUNCIONES"
    Private Function LlenarReporte() As Boolean
        Try
            Dim sQuery As String
            sQuery = "Select promocionclave from promocion where " & UniFechaSQL(PrimeraHora(Now)) & "between  FechaInicial and FechaFinal "
            Dim oDT As DataTable = odbVen.RealizarConsultaSQL(sQuery.ToString, "Reporte")
            If oDT.Rows.Count = 0 Then
                oDT.Dispose()
                MsgBox(refaVista.BuscarMensaje("Mensajes", "E0325"), MsgBoxStyle.Information)
                Return False
            Else
                oDT.Dispose()
                CreaReporte()
                Return True
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return False
        End Try
    End Function
#End Region

#Region "EVENTOS"
    Private Sub ButtonRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRegresar.Click
        Me.Close()
    End Sub

    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemRegresar.Click
        Me.Close()
    End Sub

    Private Sub FormResumenPromociones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor.Current = Cursors.WaitCursor
        [Global].ObtenerFactores(Me)
        [Global].EscalarFuente(Me)
        [Global].EscalarForma(Me)
        If Not Vista.Buscar("FormResumenPromociones", refaVista) Then
            Cursor.Current = Cursors.Default
            Exit Sub
        End If
        refaVista.ColocarEtiquetasForma(Me)
        If Me.LlenarReporte Then
            Me.MuestraReporte()
            Me.ButtonImprimir.Enabled = True
        End If

        Cursor.Current = Cursors.Default
        Me.txtReporte.Focus()

    End Sub

    Private Sub ButtonImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonImprimir.Click
        ImprimirArchivo(7, True, sNombreArchivo, False, oVendedor.TipoModImp, False)
    End Sub
#End Region

    Private Sub txtReporte_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtReporte.KeyPress
        e.Handled = True
    End Sub
End Class
