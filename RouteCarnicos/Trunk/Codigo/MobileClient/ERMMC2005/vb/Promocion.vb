Imports System.Data.SqlServerCe

Public Class Promocion

    Protected sPromocionClave As String
    Protected sNombre As String
    Protected tTipo As ServicesCentral.TiposPromociones
    Protected tTipoAplicacion As ServicesCentral.TiposAplicacionPromociones
    Protected tTipoRango As ServicesCentral.TiposRangosPromociones
    Protected iTipoRegla As Integer
    Protected sTransProdIDFondoCristal As String
    Protected bObligatoria As Boolean
    Protected bSeleccionProducto As Boolean
    Protected bCapturaCantidad As Boolean
    Protected bPermitirCascada As Boolean
    Protected bPendienteEntrega As Boolean
    Protected sMensajeObligatoria As String
    Protected tTipoTransProd As ServicesCentral.TiposTransProd
    Protected dtTPDImpuesto As DataTable
    Protected dtTPDPromocion As DataTable

    Public Property PendienteEntrega() As Boolean
        Get
            Return bPendienteEntrega
        End Get
        Set(ByVal Value As Boolean)
            bPendienteEntrega = Value
        End Set
    End Property

    Public Property PromocionClave() As String
        Get
            Return sPromocionClave
        End Get
        Set(ByVal Value As String)
            sPromocionClave = Value
        End Set
    End Property
    Public Property Nombre() As String
        Get
            Return sNombre
        End Get
        Set(ByVal Value As String)
            sNombre = Value
        End Set
    End Property
    Public Property Tipo() As ServicesCentral.TiposPromociones
        Get
            Return tTipo
        End Get
        Set(ByVal Value As ServicesCentral.TiposPromociones)
            tTipo = Value
        End Set
    End Property
    Public Property TipoAplicacion() As ServicesCentral.TiposAplicacionPromociones
        Get
            Return tTipoAplicacion
        End Get
        Set(ByVal Value As ServicesCentral.TiposAplicacionPromociones)
            tTipoAplicacion = Value
        End Set
    End Property
    Public Property TipoRango() As ServicesCentral.TiposRangosPromociones
        Get
            Return tTipoRango
        End Get
        Set(ByVal Value As ServicesCentral.TiposRangosPromociones)
            tTipoRango = Value
        End Set
    End Property
    Public Property TipoRegla() As Integer
        Get
            Return iTipoRegla
        End Get
        Set(ByVal Value As Integer)
            iTipoRegla = Value
        End Set
    End Property

    Public Property Obligatoria() As Boolean
        Get
            Return bObligatoria
        End Get
        Set(ByVal Value As Boolean)
            bObligatoria = Value
        End Set
    End Property

    Public Property MensajeObligatoria() As String
        Get
            Return sMensajeObligatoria
        End Get
        Set(ByVal value As String)
            sMensajeObligatoria = value
        End Set
    End Property

    Public Property SeleccionProducto() As Boolean
        Get
            Return bSeleccionProducto
        End Get
        Set(ByVal Value As Boolean)
            bSeleccionProducto = Value
        End Set
    End Property
    Public Property CapturaCantidad() As Boolean
        Get
            Return bCapturaCantidad
        End Get
        Set(ByVal Value As Boolean)
            bCapturaCantidad = Value
        End Set
    End Property

    Public Property PermitirCascada() As Boolean
        Get
            Return bPermitirCascada
        End Get
        Set(ByVal Value As Boolean)
            bPermitirCascada = Value
        End Set
    End Property

    Public Property TransProdIDFondoCristal() As String
        Get
            Return sTransProdIDFondoCristal
        End Get
        Set(ByVal value As String)
            sTransProdIDFondoCristal = value
        End Set
    End Property

    Public Class Producto
        Protected sProductoClave As String
        Protected iCantidad As Integer
        Protected iPRUTipoUnidad As Integer
        Public Property ProductoClave() As String
            Get
                Return sProductoClave
            End Get
            Set(ByVal Value As String)
                sProductoClave = Value
            End Set
        End Property

        Public Property PRUTipoUnidad() As Integer
            Get
                Return iPRUTipoUnidad
            End Get
            Set(ByVal Value As Integer)
                iPRUTipoUnidad = Value
            End Set
        End Property

        Public Property Cantidad() As Integer
            Get
                Return iCantidad
            End Get
            Set(ByVal Value As Integer)
                iCantidad = Value
            End Set
        End Property

        Public Sub New()

        End Sub

        Public Sub New(ByVal parsProductoClave As String, ByVal pariPRUTipoUnidad As Integer, ByVal pariCantidad As Integer)
            ProductoClave = parsProductoClave
            PRUTipoUnidad = pariPRUTipoUnidad
            Cantidad = pariCantidad
        End Sub
    End Class

    Private Class Regla
        Protected sPromocionClave As String
        Protected sProductoClave As String
        Protected tTipo As ServicesCentral.TiposPromociones
        Protected tTipoAplicacion As ServicesCentral.TiposAplicacionPromociones
        Protected dPorcentaje As Double
        Protected dImporte As Decimal
        Protected sPrecioClave As String
        'Protected aProductos As ArrayList
        Protected bAplicada As Boolean
        Protected bAfectoImpuestos As Boolean
        Protected bObligatoria As Boolean
        Protected bSeleccionProducto As Boolean
        Protected bCapturaProducto As Boolean
        Protected sNombre As String
        Protected sMsgObligatoria As String

        Public Sub New(ByVal parsPromocionClave As String, ByVal parsNombre As String, ByVal parsProductoClave As String, ByVal partTipoAplicacion As ServicesCentral.TiposAplicacionPromociones, ByVal partTipo As ServicesCentral.TiposPromociones, ByVal parbSeleccionProducto As Boolean, ByVal parbCapturaProducto As Boolean, ByVal parbObligatoria As Boolean, ByVal parsMsgObligatoria As String)
            Me.PromocionClave = parsPromocionClave
            Me.ProductoClave = parsProductoClave
            Me.TipoAplicacion = partTipoAplicacion
            Me.Tipo = partTipo
            Me.SeleccionProducto = parbSeleccionProducto
            Me.CapturaProducto = parbCapturaProducto
            Me.Obligatoria = parbObligatoria
            Me.Nombre = parsNombre
            sMsgObligatoria = parsMsgObligatoria
            Me.Aplicada = False

        End Sub

        Public Property PromocionClave() As String
            Get
                Return sPromocionClave
            End Get
            Set(ByVal Value As String)
                sPromocionClave = Value
            End Set
        End Property

        Public Property Nombre() As String
            Get
                Return sNombre
            End Get
            Set(ByVal Value As String)
                sNombre = Value
            End Set
        End Property

        Public Property ProductoClave() As String
            Get
                Return sProductoClave
            End Get
            Set(ByVal Value As String)
                sProductoClave = Value
            End Set
        End Property
        Public Property Tipo() As ServicesCentral.TiposPromociones
            Get
                Return tTipo
            End Get
            Set(ByVal Value As ServicesCentral.TiposPromociones)
                tTipo = Value
            End Set
        End Property
        Public Property TipoAplicacion() As ServicesCentral.TiposAplicacionPromociones
            Get
                Return tTipoAplicacion
            End Get
            Set(ByVal Value As ServicesCentral.TiposAplicacionPromociones)
                tTipoAplicacion = Value
            End Set
        End Property
        Public Property Obligatoria() As Boolean
            Get
                Return bObligatoria
            End Get
            Set(ByVal Value As Boolean)
                bObligatoria = Value
            End Set
        End Property

        Public Property SeleccionProducto() As Boolean
            Get
                Return bSeleccionProducto
            End Get
            Set(ByVal Value As Boolean)
                bSeleccionProducto = Value
            End Set
        End Property

        Public Property CapturaProducto() As Boolean
            Get
                Return bCapturaProducto
            End Get
            Set(ByVal Value As Boolean)
                bCapturaProducto = Value
            End Set
        End Property

        Public Property Porcentaje() As Double
            Get
                Return dPorcentaje
            End Get
            Set(ByVal Value As Double)
                dPorcentaje = Value
            End Set
        End Property
        Public Property Importe() As Decimal
            Get
                Return dImporte
            End Get
            Set(ByVal Value As Decimal)
                dImporte = Value
            End Set
        End Property

        Public Property PrecioClave() As String
            Get
                Return sPrecioClave
            End Get
            Set(ByVal Value As String)
                sPrecioClave = Value
            End Set
        End Property
        'Public Property Productos() As ArrayList
        '    Get
        '        Return aProductos
        '    End Get
        '    Set(ByVal Value As ArrayList)
        '        aProductos = Value
        '    End Set
        'End Property
        Public Property Aplicada() As Boolean
            Get
                Return bAplicada
            End Get
            Set(ByVal Value As Boolean)
                bAplicada = Value
            End Set
        End Property
        Public Property AfectoImpuestos() As Boolean
            Get
                Return bAfectoImpuestos
            End Get
            Set(ByVal Value As Boolean)
                bAfectoImpuestos = Value
            End Set
        End Property

        Public Function RecuperarProductosDefault(ByVal parsPromocionClave As String, ByVal parsPromocionReglaID As String) As DataTable
            Try
                'aProductosAplicados = New ArrayList
                ' Recuperar los productos a los que pueden aplicarse las promociones
                ' Cambios 06 Mayo 2006
                Dim sConsultaSQL As String = String.Empty
                If Me.SeleccionProducto Then
                    sConsultaSQL = "SELECT convert(bit,0) as Seleccionar,PromocionAplicacion.ProductoClave,Producto.Nombre,Cantidad,PromocionAplicacion.PRUTipoUnidad, Factor,(Disponible-Apartado-NoDisponible-(case  When Producto.venta=0 then INV.Contenido  Else 0 END)) as Existencia FROM PromocionAplicacion inner join Producto on PromocionAplicacion.ProductoCLave =  Producto.ProductoClave inner join ProductoDetalle on ProductoDetalle.ProductoClave = PromocionAplicacion.ProductoClave and ProductoDetalle.PRUTipoUnidad = PromocionAplicacion.PRUTipoUnidad and ProductoDetalle.ProductoDetClave = PromocionAplicacion.ProductoClave left join inventario INV on INV.ProductoClave = PromocionAplicacion.ProductoClave WHERE PromocionClave = '" & parsPromocionClave & "' AND PromocionReglaID='" & parsPromocionReglaID & "' AND TipoEstado=" & ServicesCentral.TiposEstadosRegistros.Activo
                Else
                    sConsultaSQL = "SELECT convert(bit,1) as Seleccionar,PromocionAplicacion.ProductoClave,Producto.Nombre,Cantidad,PromocionAplicacion.PRUTipoUnidad, Factor,(Disponible-Apartado-NoDisponible-(case  When Producto.venta=0 then INV.Contenido  Else 0 END)) as Existencia FROM PromocionAplicacion inner join Producto on PromocionAplicacion.ProductoCLave =  Producto.ProductoClave inner join ProductoDetalle on ProductoDetalle.ProductoClave = PromocionAplicacion.ProductoClave and ProductoDetalle.PRUTipoUnidad = PromocionAplicacion.PRUTipoUnidad and ProductoDetalle.ProductoDetClave = PromocionAplicacion.ProductoClave left join inventario INV on INV.ProductoClave = PromocionAplicacion.ProductoClave WHERE PromocionClave = '" & parsPromocionClave & "' AND PromocionReglaID='" & parsPromocionReglaID & "' AND TipoEstado=" & ServicesCentral.TiposEstadosRegistros.Activo
                End If

                ' /Cambios 06 Mayo 2006
                Dim DataTableProds As DataTable = oDBVen.RealizarConsultaSQL(sConsultaSQL, "PromocionAplicacion")
                Return DataTableProds
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
            Return Nothing
        End Function


        Public Function ObtenerAplicarRango(ByRef refparoTransProd As TransProd, ByRef refparDataRowProducto As DataRow, ByRef refparoDataViewPromRegla As DataView, ByVal partTipoAplicacion As ServicesCentral.TiposAplicacionPromociones, ByVal partTipoRango As ServicesCentral.TiposRangosPromociones, ByVal pariTipoRegla As Integer, ByRef parsTransProdIDFondoCristal As String, ByVal parbPendienteEntrega As Boolean) As Boolean
            Try
                ' Recuperar los rangos que aplican para la promoción
                Dim refDataRowsView() As DataRowView = refparoDataViewPromRegla.FindRows(Me.PromocionClave)
                ' Verificar que exista el detalle
                If refDataRowsView.Length = 0 Then
                    Return False
                End If
                ' Recuperar los valores de comparacion capturados
                Dim dCantidad As Decimal = refparDataRowProducto.Item("Cantidad")
                Dim dElemento As Decimal = refparDataRowProducto.Item("Cantidad1")
                Dim nImporte As Decimal = refparDataRowProducto.Item("SubTotal")
                Dim vCantidadGrupo As Integer = 0
                ' Variable para guardar el rango que se va a aplicar
                Dim refDataRowViewRango As DataRowView = Nothing
                Dim sPromocionReglaID As String = ""
                ' Determinar en el rango en el que entra la cantidad actual
                For Each refDataRowView As DataRowView In refDataRowsView
                    ' De acuerdo al tipo de rango
                    Select Case pariTipoRegla
                        Case 1
                            Select Case partTipoRango
                                Case ServicesCentral.TiposRangosPromociones.PorCantidad
                                    Dim nMinimo As Decimal = refDataRowView.Row.Item("Minimo")
                                    Dim nMaximo As Decimal = refDataRowView.Row.Item("Maximo")
                                    ' Si cae en este rango de cantidad
                                    If dCantidad >= nMinimo And dCantidad <= nMaximo Then
                                        refDataRowViewRango = refDataRowView
                                        sPromocionReglaID = refDataRowView.Row.Item("PromocionReglaID")
                                        ' Salir del ciclo
                                        Exit For
                                    End If
                                Case ServicesCentral.TiposRangosPromociones.PorImporte
                                    Dim nMinimo As Decimal = refDataRowView.Row.Item("Minimo")
                                    Dim nMaximo As Decimal = refDataRowView.Row.Item("Maximo")
                                    ' Si cae en este rango de importe
                                    If nImporte >= nMinimo And nImporte <= nMaximo Then
                                        refDataRowViewRango = refDataRowView
                                        sPromocionReglaID = refDataRowView.Row.Item("PromocionReglaID")
                                        ' Salir del ciclo
                                        Exit For
                                    End If
                                Case ServicesCentral.TiposRangosPromociones.PorElemento  'Elemento
                                    Dim nMinimo As Decimal = refDataRowView.Row.Item("Minimo")
                                    Dim nMaximo As Decimal = refDataRowView.Row.Item("Maximo")
                                    ' Si cae en este rango de cantidad
                                    If dElemento >= nMinimo And dElemento <= nMaximo Then
                                        refDataRowViewRango = refDataRowView
                                        sPromocionReglaID = refDataRowView.Row.Item("PromocionReglaID")
                                        ' Salir del ciclo
                                        Exit For
                                    End If

                            End Select
                        Case 2 'Por Grupo
                            Select Case partTipoRango
                                Case ServicesCentral.TiposRangosPromociones.PorCantidad
                                    Dim nMinimo As Decimal = refDataRowView.Row.Item("Minimo")
                                    vCantidadGrupo = Fix(dCantidad / nMinimo)
                                    If vCantidadGrupo > 0 Then
                                        refDataRowViewRango = refDataRowView
                                        sPromocionReglaID = refDataRowView.Row.Item("PromocionReglaID")
                                    End If
                                    Exit For
                                Case ServicesCentral.TiposRangosPromociones.PorImporte
                                    Dim nMinimo As Decimal = refDataRowView.Row.Item("Minimo")
                                    vCantidadGrupo = Fix(nImporte / nMinimo)

                                    If vCantidadGrupo > 0 Then
                                        refDataRowViewRango = refDataRowView
                                        sPromocionReglaID = refDataRowView.Row.Item("PromocionReglaID")
                                    End If
                                    Exit For
                            End Select
                    End Select
                Next
                ' Si no se encontro algun rango
                If refDataRowViewRango Is Nothing Then
                    ' No hay un rango valido
                    Return False
                End If

                'Si la promoción es de bonificación o descuento
                If partTipoAplicacion = ServicesCentral.TiposAplicacionPromociones.Bonificacion Or partTipoAplicacion = ServicesCentral.TiposAplicacionPromociones.Descuento Then
                    'Si el subtotal es 0 que no se aplique promocion
                    If refparDataRowProducto.Item("SubTotal") = 0 Then Return False
                End If

                If TipoAplicacion <> ServicesCentral.TiposAplicacionPromociones.Producto Then
                    If Not Obligatoria Then
                        'Dim sMensaje As String = "¿Desea aplicar:" & vbCrLf & "Promoción:" & Me.PromocionClave & "-" & Me.Nombre & vbCrLf & "Producto: " & Me.ProductoClave & vbCrLf & IIf(partTipoRango = ServicesCentral.TiposRangosPromociones.PorCantidad, "Cantidad: " & iCantidad, "Importe: " & nImporte)
                        If MsgBox(sMsgObligatoria.Replace("$0$", Me.PromocionClave & "-" & Me.Nombre & vbCrLf).Replace("$1$", Me.ProductoClave & vbCrLf).Replace("$2$", IIf(partTipoRango = ServicesCentral.TiposRangosPromociones.PorCantidad, "Cantidad", "Importe")).Replace("$3$", IIf(partTipoRango = ServicesCentral.TiposRangosPromociones.PorCantidad, dCantidad, nImporte)), MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                            Return False
                        End If
                    End If
                End If

                Me.AfectoImpuestos = False
                Dim bEsValido As Boolean = False
                ' Asignar las propiedades al elemento de promoción a aplicar
                Select Case partTipoAplicacion
                    Case ServicesCentral.TiposAplicacionPromociones.Bonificacion
                        If Not refDataRowViewRango.Row.IsNull("Importe") Then
                            Me.Importe = refDataRowViewRango.Row("Importe")

                            Dim dPorcentaje As Decimal

                            Dim sComandoSQL As New System.Text.StringBuilder
                            sComandoSQL.Append("UPDATE TransProdDetalle SET ")
                            sComandoSQL.Append("Promocion=1, ")
                            Select Case pariTipoRegla
                                Case 1
                                    dPorcentaje = Decimal.Round((Me.Importe * 100) / refparDataRowProducto.Item("SubTotal"), 4)
                                    dPorcentaje = Decimal.Round(dPorcentaje / 100, 4)

                                    'Guardar los detalles en TRPPRP
                                    oDBVen.EjecutarComandoSQL("INSERT INTO TRPPRP Select TransProdID,TransProdDetalleID,'" & Me.PromocionClave & "',Round(SubTotal * " & dPorcentaje & ",2),getdate(),'" & oVendedor.UsuarioId & "',0 from TransProdDetalle where TransProdId='" & refparoTransProd.TransProdId & "' AND ProductoClave='" & Me.ProductoClave & "' and Subtotal>0 ")

                                    sComandoSQL.Append("DescuentoImp = Round(DescuentoImp + (SubTotal * " & dPorcentaje & "),2), ")
                                    sComandoSQL.Append("SubTotal = Round(SubTotal - (SubTotal * " & dPorcentaje & "),2),")
                                Case 2
                                    If partTipoRango = ServicesCentral.TiposRangosPromociones.PorImporte Then
                                        Dim dPorc As Double = (Me.Importe * 100) / refDataRowViewRango("Minimo")
                                        Dim dImporteDesc As Double = (refDataRowViewRango("Minimo")) * (dPorc / 100)
                                        dPorcentaje = dImporteDesc * vCantidadGrupo
                                    Else
                                        Dim dImpPorProducto As Double = nImporte / dCantidad
                                        Dim dPorc As Double = (Me.Importe * 100) / (dImpPorProducto * refDataRowViewRango("Minimo"))
                                        Dim dImporteDesc As Double = (dImpPorProducto * refDataRowViewRango("Minimo")) * (dPorc / 100)
                                        dPorcentaje = dImporteDesc * vCantidadGrupo
                                    End If
                                    dPorcentaje = Decimal.Round((dPorcentaje * 100) / refparDataRowProducto.Item("SubTotal"), 4)
                                    dPorcentaje = Decimal.Round(dPorcentaje / 100, 4)
                                    sComandoSQL.Append("DescuentoImp = Round(DescuentoImp + (SubTotal *" & dPorcentaje & "),2), ")
                                    sComandoSQL.Append("SubTotal = Round(SubTotal - (SubTotal *" & dPorcentaje & "),2),")

                                    'Guardar los detalles en TRPPRP
                                    oDBVen.EjecutarComandoSQL("INSERT INTO TRPPRP Select TransProdID,TransProdDetalleID,'" & Me.PromocionClave & "',Round(SubTotal * " & dPorcentaje & ",2),getdate(),'" & oVendedor.UsuarioId & "',0 from TransProdDetalle where TransProdId='" & refparoTransProd.TransProdId & "' AND ProductoClave='" & Me.ProductoClave & "' and Subtotal>0 ")

                            End Select
                            sComandoSQL.Append("MFechaHora=" & UniFechaSQL(Now) & ",MUsuarioID='" & oVendedor.UsuarioId & "' ,Enviado=0 ")
                            ' Mas adelante se recalcula el nuevo subtotal, el impuesto y el total
                            sComandoSQL.Append("WHERE TransProdId='" & refparoTransProd.TransProdId & "' AND ProductoClave='" & Me.ProductoClave & "' and Subtotal>0 ")
                            bEsValido = (oDBVen.EjecutarComandoSQL(sComandoSQL.ToString) <> 0)
                            ' Recuperar el nuevo subtotal para considerarlo como base en las siguientes promociones
                            Dim dSubtotal As Double = oDBVen.EjecutarCmdScalardblSQL("SELECT SUM(SubTotal) AS SubTotal FROM TransProdDetalle WHERE TransProdId='" & refparoTransProd.TransProdId & "' AND ProductoClave='" & Me.ProductoClave & "'")
                            'If DataTableConsulta.Rows.Count > 0 Then
                            ' Actualizar el nuevo subtotal
                            refparDataRowProducto.Item("SubTotal") = dSubtotal
                            'End If
                            'DataTableConsulta = oDBVen.RealizarConsultaSQL("SELECT * FROM TransProdDetalle WHERE TransProdId='" & refparoTransProd.TransProdId & "' AND ProductoClave='" & Me.ProductoClave & "'", "Consulta")
                            Me.AfectoImpuestos = True


                        End If
                    Case ServicesCentral.TiposAplicacionPromociones.Descuento
                        If Not refDataRowViewRango.Row.IsNull("Porcentaje") Then
                            Me.Porcentaje = refDataRowViewRango.Row("Porcentaje")

                            ' Aplicar el porcentaje de descuento al subtotal, al total y guardar el importe del descuento
                            ' Dim DataTableConsulta As DataTable = oDBVen.RealizarConsultaSQL("SELECT * FROM TransProdDetalle WHERE TransProdId='" & refparoTransProd.TransProdId & "' AND ProductoClave='" & Me.ProductoClave & "'", "Consulta")

                            Dim sComandoSQL As New System.Text.StringBuilder
                            sComandoSQL.Append("UPDATE TransProdDetalle SET ")
                            sComandoSQL.Append("Promocion=1, ")
                            Dim dPorcentaje As Decimal
                            Select Case pariTipoRegla
                                Case 1
                                    dPorcentaje = Decimal.Round(Me.Porcentaje / 100, 4)

                                    'Guardar los detalles en TRPPRP
                                    oDBVen.EjecutarComandoSQL("INSERT INTO TRPPRP Select TransProdID,TransProdDetalleID,'" & Me.PromocionClave & "',Round(SubTotal * " & dPorcentaje & ",2),getdate(),'" & oVendedor.UsuarioId & "',0 from TransProdDetalle where TransProdId='" & refparoTransProd.TransProdId & "' AND ProductoClave='" & Me.ProductoClave & "' and Subtotal>0 ")

                                    sComandoSQL.Append("DescuentoImp = Round(DescuentoImp + (SubTotal * " & dPorcentaje & "),2), ")
                                    sComandoSQL.Append("SubTotal = Round(SubTotal - (SubTotal * " & dPorcentaje & "),2),")
                                Case 2
                                    If partTipoRango = ServicesCentral.TiposRangosPromociones.PorImporte Then
                                        Dim dPorc As Double = refDataRowViewRango("Minimo") * (Me.Porcentaje / 100)
                                        dPorcentaje = dPorc * vCantidadGrupo
                                    Else
                                        Dim dImpPorProducto As Double = nImporte / dCantidad
                                        Dim dPorc As Double = (dImpPorProducto * refDataRowViewRango("Minimo")) * (Me.Porcentaje / 100)
                                        dPorcentaje = dPorc * vCantidadGrupo
                                    End If

                                    dPorcentaje = Decimal.Round((dPorcentaje * 100) / refparDataRowProducto.Item("SubTotal"), 4)
                                    dPorcentaje = Decimal.Round(dPorcentaje / 100, 4)
                                    sComandoSQL.Append("DescuentoImp = Round(DescuentoImp + (SubTotal * " & dPorcentaje & "),2), ")
                                    sComandoSQL.Append("SubTotal = Round(SubTotal - (SubTotal * " & dPorcentaje & "),2),")

                                    'Guardar los detalles en TRPPRP
                                    oDBVen.EjecutarComandoSQL("INSERT INTO TRPPRP Select TransProdID,TransProdDetalleID,'" & Me.PromocionClave & "',Round(SubTotal * " & dPorcentaje & ",2),getdate(),'" & oVendedor.UsuarioId & "',0 from TransProdDetalle where TransProdId='" & refparoTransProd.TransProdId & "' AND ProductoClave='" & Me.ProductoClave & "' and Subtotal>0 ")
                            End Select
                            sComandoSQL.Append("MFechaHora=" & UniFechaSQL(Now) & ",MUsuarioID='" & oVendedor.UsuarioId & "' ,Enviado=0 ")
                            ' Mas adelante se recalcula el nuevo subtotal, el impuesto y el total
                            sComandoSQL.Append("WHERE TransProdId='" & refparoTransProd.TransProdId & "' AND ProductoClave='" & Me.ProductoClave & "' and Subtotal>0 ")
                            bEsValido = (oDBVen.EjecutarComandoSQL(sComandoSQL.ToString) <> 0)
                            ' Recuperar el nuevo subtotal para considerarlo como base en las siguientes promociones
                            Dim dSubtotal As Double = oDBVen.EjecutarCmdScalardblSQL("SELECT SUM(SubTotal) AS SubTotal FROM TransProdDetalle WHERE TransProdId='" & refparoTransProd.TransProdId & "' AND ProductoClave='" & Me.ProductoClave & "'")
                            'If DataTableConsulta.Rows.Count > 0 Then
                            ' Actualizar el nuevo subtotal
                            refparDataRowProducto.Item("SubTotal") = dSubtotal
                            'End If
                            'DataTableConsulta = oDBVen.RealizarConsultaSQL("SELECT * FROM TransProdDetalle WHERE TransProdId='" & refparoTransProd.TransProdId & "' AND ProductoClave='" & Me.ProductoClave & "'", "Consulta")
                            Me.AfectoImpuestos = True
                            'DataTableConsulta.Dispose()

                        End If
                    Case ServicesCentral.TiposAplicacionPromociones.Precio
                        If Not refDataRowViewRango.Row.IsNull("PrecioClave") Then
                            Me.PrecioClave = refDataRowViewRango.Row("PrecioClave")

                            ' Recuperar la lista de tipos de unidad capturadas para este producto en el detalle
                            Dim sListaTiposUnidades As String = ""
                            If refparoTransProd.RecuperarUnidadesProductosDetalle(Me.ProductoClave, sListaTiposUnidades) Then
                                ' Reasignar el precio obtenido y los totales de los productos capturados
                                ' Recuperar las unidades/factores/precios (con factor) para el producto
                                Dim aUnidades As New ArrayList
                                If MobileClient.Producto.RecuperarUnidadesPrecio(Me.ProductoClave, sListaTiposUnidades, aUnidades, Me.PrecioClave) Then
                                    ' Para cada unidad recuperada, actualizar el precio solamente, ya que los totales se actualizaran posteriormente
                                    For Each refUnidad As MobileClient.Producto.Unidad In aUnidades
                                        'Guardar los detalles en TRPPRP
                                        oDBVen.EjecutarComandoSQL("INSERT INTO TRPPRP Select TransProdID,TransProdDetalleID,'" & Me.PromocionClave & "',null,getdate(),'" & oVendedor.UsuarioId & "',0 from TransProdDetalle WHERE TransProdId='" & refparoTransProd.TransProdId & "' AND ProductoClave='" & Me.ProductoClave & "' AND TipoUnidad=" & refUnidad.TipoUnidad & " and Subtotal>0 ")

                                        Dim sComandoSQL As New System.Text.StringBuilder
                                        sComandoSQL.Append("UPDATE TransProdDetalle SET ")
                                        sComandoSQL.Append("Promocion = 1, ")
                                        ' Asignar el nuevo precio 
                                        sComandoSQL.Append("Precio = " & refUnidad.Precio & ", ")
                                        ' Como el precio cambio, el descuento que se hubiese calculado antes ya no es valido, recalcularlo por regla de 3
                                        ' Obtener el nuevo descuento por el cambio en la proporcion del precio
                                        sComandoSQL.Append("DescuentoImp = (" & refUnidad.Precio & " * DescuentoImp) / Precio, ")
                                        ' El nuevo subtotal es igual a la cantidad existente * el nuevo precio - el nuevo descuento
                                        sComandoSQL.Append("SubTotal = (Cantidad * " & refUnidad.Precio & ") - ((" & refUnidad.Precio & " * DescuentoImp) / Precio), ")
                                        sComandoSQL.Append("MFechaHora=" & UniFechaSQL(Now) & ",MUsuarioID='" & oVendedor.UsuarioId & "',Enviado=0 ")
                                        sComandoSQL.Append("WHERE TransProdId='" & refparoTransProd.TransProdId & "' AND ProductoClave='" & Me.ProductoClave & "' ")
                                        sComandoSQL.Append("AND TipoUnidad=" & refUnidad.TipoUnidad & " and Subtotal>0 ")
                                        bEsValido = bEsValido Or (oDBVen.EjecutarComandoSQL(sComandoSQL.ToString) <> 0)
                                        ' Recuperar el nuevo subtotal para considerarlo como base en las siguientes promociones
                                        Dim DataTableConsulta As DataTable = oDBVen.RealizarConsultaSQL("SELECT SUM(SubTotal) AS SubTotal FROM TransProdDetalle WHERE TransProdId='" & refparoTransProd.TransProdId & "' AND ProductoClave='" & Me.ProductoClave & "'", "Subtotales")
                                        If DataTableConsulta.Rows.Count > 0 Then
                                            ' Actualizar el nuevo subtotal
                                            refparDataRowProducto.Item("SubTotal") = DataTableConsulta.Rows(0).Item("SubTotal")
                                        End If
                                        DataTableConsulta.Dispose()
                                    Next
                                    Me.AfectoImpuestos = True
                                End If
                            End If

                        End If
                    Case ServicesCentral.TiposAplicacionPromociones.Producto
                        ' Obtener la lista de productos/cantidad de regalo
                        Dim dtProductosPromocion As DataTable = Me.RecuperarProductosDefault(Me.PromocionClave, sPromocionReglaID)

                        If dtProductosPromocion.Rows.Count Then
                            ' Agregar al detalle tantos productos como sean indicados para este tipo de promoción
                            Dim sTransProdDetalleID As String = ""
                            'Dim iTipoUnidadUnitaria As Integer
                            Dim iPartida As Integer
                            Dim sComandoSQL As System.Text.StringBuilder
                            Dim dCantidadMaxima As Double
                            dCantidadMaxima = refDataRowViewRango.Row.Item("Cantidad")
                            Dim drProductos As DataRow()

                            Dim blnValidarExistencia As Boolean = False

                            If Me.Tipo = ServicesCentral.TiposPromociones.FondoCristal Then
                                If parsTransProdIDFondoCristal = String.Empty Then
                                    Dim oTransprodFondoCristal As New TransProd
                                    With oTransprodFondoCristal
                                        .Reiniciar(True)
                                        .TransProdId = oApp.KEYGEN(1)
                                        .VisitaActual = refparoTransProd.VisitaActual
                                        .FacturaId = refparoTransProd.TransProdId
                                        .FolioActual = refparoTransProd.TransProdId
                                        .Tipo = ServicesCentral.TiposTransProd.FondoCristal
                                        .TipoFase = ServicesCentral.TiposFasesPedidos.Captura
                                        .Total = 0
                                        .TipoMovimiento = ServicesCentral.TiposMovimientos.Salida
                                        .FechaCaptura = PrimeraHora(Now)
                                        Dim oModuloMovDet As New Modulos.GrupoModuloMovDetalle
                                        oModuloMovDet.Recuperar(ServicesCentral.TiposModulosMovDet.Pedido)
                                        .ModuloMovDetalle = oModuloMovDet
                                        .Actualizar()
                                        parsTransProdIDFondoCristal = oTransprodFondoCristal.TransProdId
                                    End With
                                End If
                                drProductos = dtProductosPromocion.Select("")
                            Else
                                If (oVendedor.TipoModulo = ServicesCentral.TiposModulos.Preventa And oAgenda.RutaActual.Inventario = True) OrElse (oVendedor.TipoModulo = ServicesCentral.TiposModulos.Venta AndAlso refparoTransProd.ModuloMovDetalle.TipoModuloMovDetalle <> ServicesCentral.TiposModulosMovDet.MovSinInvConVis) OrElse (oVendedor.TipoModulo = ServicesCentral.TiposModulos.Distribucion And refparoTransProd.ModuloMovDetalle.TipoModuloMovDetalle = ServicesCentral.TiposModulosMovDet.Pedido) Then
                                    blnValidarExistencia = True
                                End If

                                Dim oFormSeleccionarPromociones As FormSeleccionarPromociones
                                If pariTipoRegla = 1 Then
                                    oFormSeleccionarPromociones = New FormSeleccionarPromociones(dtProductosPromocion, dCantidadMaxima, Me.SeleccionProducto, Me.CapturaProducto, Me.Nombre, parbPendienteEntrega, blnValidarExistencia)
                                ElseIf pariTipoRegla = 2 Then
                                    oFormSeleccionarPromociones = New FormSeleccionarPromociones(dtProductosPromocion, dCantidadMaxima, Me.SeleccionProducto, Me.CapturaProducto, Me.Nombre, parbPendienteEntrega, blnValidarExistencia, vCantidadGrupo)
                                End If
                                Cursor.Current = Cursors.Default
                                oFormSeleccionarPromociones.ShowDialog()
                                Cursor.Current = Cursors.WaitCursor
                                oFormSeleccionarPromociones.Dispose()
                                oFormSeleccionarPromociones = Nothing
                                drProductos = dtProductosPromocion.Select("Seleccionar = 1")
                            End If

                            sComandoSQL = New System.Text.StringBuilder
                            sComandoSQL.Append("UPDATE TransProdDetalle SET Promocion=1, ")
                            sComandoSQL.Append("MFechaHora=" & UniFechaSQL(Now) & ",MUsuarioID='" & oVendedor.UsuarioId & "' ,Enviado=0 ")
                            sComandoSQL.Append("WHERE TransProdId='" & refparoTransProd.TransProdId & "' AND ProductoClave='" & Me.ProductoClave & "' and Subtotal>0 ")
                            oDBVen.EjecutarComandoSQL(sComandoSQL.ToString)

                            oDBVen.EjecutarComandoSQL("INSERT INTO TRPPRP Select TransProdID,TransProdDetalleID,'" & Me.PromocionClave & "',null,getdate(),'" & oVendedor.UsuarioId & "',0 from TransProdDetalle WHERE TransProdId='" & refparoTransProd.TransProdId & "' AND ProductoClave='" & Me.ProductoClave & "' AND Subtotal>0 ")

                            Dim dCantidadDisponible As Decimal = 0
                            Dim sMsgError As String = String.Empty
                            Dim dCantidadPrmProducto As Double
                            Dim dPrecioProducto As Single
                            For Each dr As DataRow In drProductos
                                If Me.Tipo <> ServicesCentral.TiposPromociones.FondoCristal Then
                                    dCantidadDisponible = 0
                                    'Si es movimiento sin inventario o si hay existencia
                                    If ((Not blnValidarExistencia) OrElse (Inventario.ValidarExistenciaDisponibleDec(dr("ProductoClave"), dr("PRUTipoUnidad"), dr("Cantidad"), dCantidadDisponible, sMsgError))) Then
                                        If Folio.ObtenerTransProdDetalleId(refparoTransProd.TransProdId, sTransProdDetalleID) Then
                                            If Folio.ObtenerTransProdPartida(refparoTransProd.TransProdId, Me.ProductoClave, iPartida) Then
                                                sComandoSQL = New System.Text.StringBuilder
                                                sComandoSQL.Append("INSERT INTO TransProdDetalle (TransProdID, TransProdDetalleID, ProductoClave, DescuentoClave, TipoUnidad, Partida, Promocion, Cantidad, Precio, DescuentoPor, DescuentoImp, Impuesto, Subtotal, Total, PromocionClave, MFechaHora, MUsuarioID,Enviado) VALUES (")
                                                sComandoSQL.Append("'" & refparoTransProd.TransProdId & "',")
                                                sComandoSQL.Append("'" & sTransProdDetalleID & "',")
                                                sComandoSQL.Append("'" & dr("ProductoClave") & "',")
                                                sComandoSQL.Append("NULL,") ' DescuentoClave
                                                sComandoSQL.Append(dr("PRUTipoUnidad") & ",") ' TipoUnidad
                                                sComandoSQL.Append(iPartida & ",") ' Partida
                                                sComandoSQL.Append("2,") ' Promocion
                                                'Select Case pariTipoRegla
                                                '    Case 1
                                                sComandoSQL.Append(dr("Cantidad") & ",") ' Cantidad
                                                'Case 2
                                                'sComandoSQL.Append(dr("Cantidad") * vCantidadGrupo & ",") ' Cantidad
                                                'End Select
                                                sComandoSQL.Append("0,") ' Precio
                                                sComandoSQL.Append("0,") ' DescuentoPor
                                                sComandoSQL.Append("0,") ' DescuentoImp
                                                sComandoSQL.Append("0,") ' Impuesto
                                                sComandoSQL.Append("0,") ' Subtotal
                                                sComandoSQL.Append("0,") ' Total
                                                sComandoSQL.Append("'" & Me.PromocionClave & "',") ' PromocionClave
                                                sComandoSQL.Append("getdate(),")
                                                sComandoSQL.Append("'" & oVendedor.UsuarioId & "',0)")
                                                bEsValido = bEsValido Or (oDBVen.EjecutarComandoSQL(sComandoSQL.ToString) <> 0)
                                                sComandoSQL = Nothing
                                                ' Actualizar el inventario
                                                If blnValidarExistencia Then
                                                    If refparoTransProd.ModuloMovDetalle.TipoModulo = ServicesCentral.TiposModulos.Preventa And oAgenda.RutaActual.Inventario = True Then
                                                        Inventario.ActualizarInventarioDec(dr("ProductoClave"), dr("PRUTipoUnidad"), dr("Cantidad"), ServicesCentral.TiposTransProd.Pedido, ServicesCentral.TiposMovimientos.Salida, oVendedor.AlmacenId, False)
                                                    ElseIf refparoTransProd.ModuloMovDetalle.TipoModulo = ServicesCentral.TiposModulos.Venta Then
                                                        Inventario.ActualizarInventarioDec(dr("ProductoClave"), dr("PRUTipoUnidad"), dr("Cantidad"), ServicesCentral.TiposTransProd.Pedido, ServicesCentral.TiposMovimientos.NoDefinido, oVendedor.AlmacenId, False)
                                                    Else
                                                        Inventario.ActualizarInventarioDec(dr("ProductoClave"), dr("PRUTipoUnidad"), dr("Cantidad"), ServicesCentral.TiposTransProd.Pedido, ServicesCentral.TiposMovimientos.Entrada, oVendedor.AlmacenId, False)
                                                    End If

                                                    'If refparoTransProd.ClienteActual.Prestamo Then
                                                    '    ProductoPrestamoCli.ActulizarProductoPrestamoCli(refparoTransProd.ClienteActual.ClienteClave, dr("ProductoClave"), dr("Cantidad"), dr("PRUTipoUnidad"), 0, refparoTransProd.Tipo, refparoTransProd.TipoMotivo)
                                                    'End If
                                                End If
                                            End If
                                        End If
                                    Else
                                        If dCantidadDisponible > 0 Then
                                            If Folio.ObtenerTransProdDetalleId(refparoTransProd.TransProdId, sTransProdDetalleID) Then
                                                If Folio.ObtenerTransProdPartida(refparoTransProd.TransProdId, Me.ProductoClave, iPartida) Then
                                                    sComandoSQL = New System.Text.StringBuilder
                                                    sComandoSQL.Append("INSERT INTO TransProdDetalle (TransProdID, TransProdDetalleID, ProductoClave, DescuentoClave, TipoUnidad, Partida, Promocion, Cantidad, Precio, DescuentoPor, DescuentoImp, Impuesto, Subtotal, Total, PromocionClave, MFechaHora, MUsuarioID,Enviado) VALUES (")
                                                    sComandoSQL.Append("'" & refparoTransProd.TransProdId & "',")
                                                    sComandoSQL.Append("'" & sTransProdDetalleID & "',")
                                                    sComandoSQL.Append("'" & dr("ProductoClave") & "',")
                                                    sComandoSQL.Append("NULL,") ' DescuentoClave
                                                    sComandoSQL.Append(dr("PRUTipoUnidad") & ",") ' TipoUnidad
                                                    sComandoSQL.Append(iPartida & ",") ' Partida
                                                    sComandoSQL.Append("2,") ' Promocion
                                                    'Select Case pariTipoRegla
                                                    '    Case 1
                                                    sComandoSQL.Append(dCantidadDisponible & ",") ' Cantidad
                                                    'Case 2
                                                    'sComandoSQL.Append(dr("Cantidad") * vCantidadGrupo & ",") ' Cantidad
                                                    'End Select
                                                    sComandoSQL.Append("0,") ' Precio
                                                    sComandoSQL.Append("0,") ' DescuentoPor
                                                    sComandoSQL.Append("0,") ' DescuentoImp
                                                    sComandoSQL.Append("0,") ' Impuesto
                                                    sComandoSQL.Append("0,") ' Subtotal
                                                    sComandoSQL.Append("0,") ' Total
                                                    sComandoSQL.Append("'" & Me.PromocionClave & "',") ' PromocionClave
                                                    sComandoSQL.Append("getdate(),")
                                                    sComandoSQL.Append("'" & oVendedor.UsuarioId & "',0)")
                                                    bEsValido = bEsValido Or (oDBVen.EjecutarComandoSQL(sComandoSQL.ToString) <> 0)
                                                    sComandoSQL = Nothing
                                                    ' Actualizar el inventario
                                                    If blnValidarExistencia Then
                                                        If refparoTransProd.ModuloMovDetalle.TipoModulo = ServicesCentral.TiposModulos.Preventa And oAgenda.RutaActual.Inventario = True Then
                                                            Inventario.ActualizarInventarioDec(dr("ProductoClave"), dr("PRUTipoUnidad"), dCantidadDisponible, ServicesCentral.TiposTransProd.Pedido, ServicesCentral.TiposMovimientos.Salida, oVendedor.AlmacenId, False)
                                                        ElseIf refparoTransProd.ModuloMovDetalle.TipoModulo = ServicesCentral.TiposModulos.Venta Then
                                                            Inventario.ActualizarInventarioDec(dr("ProductoClave"), dr("PRUTipoUnidad"), dCantidadDisponible, ServicesCentral.TiposTransProd.Pedido, ServicesCentral.TiposMovimientos.NoDefinido, oVendedor.AlmacenId, False)
                                                        Else
                                                            Inventario.ActualizarInventarioDec(dr("ProductoClave"), dr("PRUTipoUnidad"), dCantidadDisponible, ServicesCentral.TiposTransProd.Pedido, ServicesCentral.TiposMovimientos.Entrada, oVendedor.AlmacenId, False)
                                                        End If
                                                        'Guardar la cantidad de Producto Negado
                                                        If (dr("Cantidad") - dCantidadDisponible) > 0 Then
                                                            ProductoNegado.Insertar(refparoTransProd.TransProdId, dr("ProductoClave"), Me.PromocionClave, Me.ProductoClave, dr("PRUTipoUnidad"), dr("Cantidad") - dCantidadDisponible, 1, refparoTransProd.ClienteActual.ClienteClave, refparoTransProd.FolioActual)
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        Else
                                            If blnValidarExistencia And parbPendienteEntrega Then
                                                ProductoNegado.Insertar(refparoTransProd.TransProdId, dr("ProductoClave"), Me.PromocionClave, Me.ProductoClave, dr("PRUTipoUnidad"), dr("Cantidad"), 1, refparoTransProd.ClienteActual.ClienteClave, refparoTransProd.FolioActual)
                                                bEsValido = True
                                            End If
                                        End If
                                    End If
                                Else
                                    sComandoSQL = New System.Text.StringBuilder
                                    Dim sTransProdDetalleIDFondoCristal As String = String.Empty
                                    If Folio.ObtenerTransProdDetalleId(parsTransProdIDFondoCristal, dr("ProductoClave"), dr("PRUTipoUnidad"), sTransProdDetalleIDFondoCristal) Then
                                        sComandoSQL.Append("UPDATE TransProdDetalle set ")
                                        Select Case pariTipoRegla
                                            Case 1
                                                dCantidadPrmProducto = dr("Cantidad")
                                                sComandoSQL.Append("Cantidad = Cantidad + " & dr("Cantidad") & ",") ' Cantidad
                                            Case 2
                                                dCantidadPrmProducto = dr("Cantidad") * vCantidadGrupo
                                                sComandoSQL.Append("Cantidad = Cantidad + " & dr("Cantidad") * vCantidadGrupo & ",") ' Cantidad
                                        End Select
                                        sComandoSQL.Append(" Total = Total + (Precio  * " & Decimal.Round(dCantidadPrmProducto, 2) & "),") ' Total
                                        sComandoSQL.Append("MFechaHora= getdate(),")
                                        sComandoSQL.Append("MUsuarioID='" & oVendedor.UsuarioId & "',Enviado = 0 ")
                                        sComandoSQL.Append("WHERE TransProdID='" & parsTransProdIDFondoCristal & "' and TransProdDetalleID='" & sTransProdDetalleIDFondoCristal & "'")
                                        bEsValido = bEsValido Or (oDBVen.EjecutarComandoSQL(sComandoSQL.ToString) <> 0)
                                        sComandoSQL = Nothing
                                    Else
                                        Dim i As Integer = 1
                                        Folio.ObtenerTransProdPartida(parsTransProdIDFondoCristal, dr("ProductoClave"), i)
                                        sComandoSQL.Append("INSERT INTO TransProdDetalle (TransProdID, TransProdDetalleID, ProductoClave, DescuentoClave, TipoUnidad, Partida, Promocion, Cantidad, Precio, DescuentoPor, DescuentoImp, Impuesto, Subtotal, Total, MFechaHora, MUsuarioID,Enviado) VALUES (")
                                        sComandoSQL.Append("'" & parsTransProdIDFondoCristal & "',")
                                        sComandoSQL.Append("'" & oApp.KEYGEN(i) & "',")
                                        sComandoSQL.Append("'" & dr("ProductoClave") & "',")
                                        sComandoSQL.Append("NULL,") ' DescuentoClave
                                        sComandoSQL.Append(dr("PRUTipoUnidad") & ",") ' TipoUnidad
                                        sComandoSQL.Append(i & ",") ' Partida
                                        sComandoSQL.Append("0,") ' Promocion

                                        Select Case pariTipoRegla
                                            Case 1
                                                dCantidadPrmProducto = dr("Cantidad")
                                                sComandoSQL.Append(dr("Cantidad") & ",") ' Cantidad
                                            Case 2
                                                dCantidadPrmProducto = dr("Cantidad") * vCantidadGrupo
                                                sComandoSQL.Append(dr("Cantidad") * vCantidadGrupo & ",") ' Cantidad
                                        End Select
                                        refparoTransProd.ListasPrecios.BuscarPrecio(dr("ProductoClave"), dr("PRUTipoUnidad"), dPrecioProducto)

                                        sComandoSQL.Append(Decimal.Round(dPrecioProducto, oConHist.Campos("DecimalesImporte")) & ",") ' Precio
                                        sComandoSQL.Append("0,") ' DescuentoPor
                                        sComandoSQL.Append("0,") ' DescuentoImp
                                        sComandoSQL.Append("0,") ' Impuesto
                                        sComandoSQL.Append("0,") ' Subtotal
                                        sComandoSQL.Append(Decimal.Round(Decimal.Round(dPrecioProducto, oConHist.Campos("DecimalesImporte")) * dCantidadPrmProducto, 2) & ",") ' Total
                                        sComandoSQL.Append("getdate(),")
                                        sComandoSQL.Append("'" & oVendedor.UsuarioId & "',0)")
                                        bEsValido = bEsValido Or (oDBVen.EjecutarComandoSQL(sComandoSQL.ToString) <> 0)
                                        sComandoSQL = Nothing
                                        ' El inventario se actualiza hasta finalizar el pedido
                                        'If refparoTransProd.ModuloMovDetalle.TipoModulo = ServicesCentral.TiposModulos.Preventa And oAgenda.RutaActual.Inventario = True Then
                                        '    Inventario.ActualizarInventario(oProductoPromocion.ProductoClave, oProductoPromocion.PRUTipoUnidad, dCantidadPrmProducto, ServicesCentral.TiposTransProd.Pedido, ServicesCentral.TiposMovimientos.Salida, oVendedor.AlmacenId, False)
                                        'Else
                                        '    Inventario.ActualizarInventario(oProductoPromocion.ProductoClave, oProductoPromocion.PRUTipoUnidad, dCantidadPrmProducto, ServicesCentral.TiposTransProd.Pedido, ServicesCentral.TiposMovimientos.NoDefinido, oVendedor.AlmacenId, False)
                                        'End If
                                    End If
                                End If
                            Next
                            dtProductosPromocion.Dispose()
                        End If
                End Select
                Me.Aplicada = bEsValido
                Return bEsValido
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
            ' Sucedio un error
            Return False
        End Function

        Protected Overrides Sub Finalize()
            MyBase.Finalize()
        End Sub
    End Class

    Private Class ReglaProductosAcumulados
        Protected sPromocionClave As String
        Protected sProductoClave As String
        Protected tTipoAplicacion As ServicesCentral.TiposAplicacionPromociones
        Protected bSeleccionProducto As Boolean
        Protected bCapturaProducto As Boolean
        Protected bPendienteEntrega As Boolean
        Protected aProductosRegla As New ArrayList
        Protected tTipoRango As ServicesCentral.TiposRangosPromociones
        Protected iTipoRegla As Integer
        Protected sNombre As String
        Protected bObligatoria As Boolean
        'Protected aProductosAplicados As ArrayList

        Protected dCantidad As Double
        Protected dImporte As Double
        Protected bAplicada As Boolean
        Protected dPorcentaje As Double
        Protected bAfectoImpuestos As Boolean
        Protected sMsgObligatoria As String

        Public Sub New(ByVal parsPromocionClave As String, ByVal parsNombre As String, ByVal parbObligatoria As Boolean, ByVal parbSeleccionProducto As Boolean, ByVal parbCapturaProducto As Boolean, ByVal partTipoRango As ServicesCentral.TiposRangosPromociones, ByVal pariTipoRegla As Integer, ByVal parsProductoClave As String, ByVal partTipoAplicacion As ServicesCentral.TiposAplicacionPromociones, ByVal parsMsgObligatoria As String, ByVal parbPendienteEntrega As Boolean)
            Me.PromocionClave = parsPromocionClave
            Me.TipoRango = partTipoRango
            Me.TipoRegla = pariTipoRegla
            Me.Obligatoria = parbObligatoria
            Me.SeleccionProducto = parbSeleccionProducto
            Me.CapturaProducto = parbCapturaProducto
            Me.Nombre = parsNombre
            Me.ProductoClave = parsProductoClave
            Me.TipoAplicacion = partTipoAplicacion
            sMsgObligatoria = parsMsgObligatoria
            Me.Aplicada = False
            Me.PendienteEntrega = parbPendienteEntrega
        End Sub

        Public Property PromocionClave() As String
            Get
                Return sPromocionClave
            End Get
            Set(ByVal Value As String)
                sPromocionClave = Value
            End Set
        End Property

        Public Property Nombre() As String
            Get
                Return sNombre
            End Get
            Set(ByVal Value As String)
                sNombre = Value
            End Set
        End Property
        Public Property Obligatoria() As Boolean
            Get
                Return bObligatoria
            End Get
            Set(ByVal Value As Boolean)
                bObligatoria = Value
            End Set
        End Property

        Public Property PendienteEntrega() As Boolean
            Get
                Return bPendienteEntrega
            End Get
            Set(ByVal Value As Boolean)
                bPendienteEntrega = Value
            End Set
        End Property

        Public Property SeleccionProducto() As Boolean
            Get
                Return bSeleccionProducto
            End Get
            Set(ByVal Value As Boolean)
                bSeleccionProducto = Value
            End Set
        End Property

        Public Property CapturaProducto() As Boolean
            Get
                Return bCapturaProducto
            End Get
            Set(ByVal Value As Boolean)
                bCapturaProducto = Value
            End Set
        End Property

        Public Property TipoRango() As ServicesCentral.TiposRangosPromociones
            Get
                Return tTipoRango
            End Get
            Set(ByVal Value As ServicesCentral.TiposRangosPromociones)
                tTipoRango = Value
            End Set
        End Property

        Public Property TipoRegla() As Integer
            Get
                Return iTipoRegla
            End Get
            Set(ByVal Value As Integer)
                iTipoRegla = Value
            End Set
        End Property

        Public Property Cantidad() As Double
            Get
                Return dCantidad
            End Get
            Set(ByVal Value As Double)
                dCantidad = Value
            End Set
        End Property

        Public Property Importe() As Double
            Get
                Return dImporte
            End Get
            Set(ByVal Value As Double)
                dImporte = Value
            End Set
        End Property

        Public Property ProductosRegla() As ArrayList
            Get
                Return aProductosRegla
            End Get
            Set(ByVal Value As ArrayList)
                aProductosRegla = Value
            End Set
        End Property
        Public Property Aplicada() As Boolean
            Get
                Return bAplicada
            End Get
            Set(ByVal Value As Boolean)
                bAplicada = Value
            End Set
        End Property

        Public Property Porcentaje() As Double
            Get
                Return dPorcentaje
            End Get
            Set(ByVal Value As Double)
                dPorcentaje = Value
            End Set
        End Property

        Public Property ProductoClave() As String
            Get
                Return sProductoClave
            End Get
            Set(ByVal Value As String)
                sProductoClave = Value
            End Set
        End Property

        Public Property TipoAplicacion() As ServicesCentral.TiposAplicacionPromociones
            Get
                Return tTipoAplicacion
            End Get
            Set(ByVal Value As ServicesCentral.TiposAplicacionPromociones)
                tTipoAplicacion = Value
            End Set
        End Property

        Public Property AfectoImpuestos() As Boolean
            Get
                Return bAfectoImpuestos
            End Get
            Set(ByVal Value As Boolean)
                bAfectoImpuestos = Value
            End Set
        End Property

        Public Function RecuperarProductosDefault(ByVal parsPromocionClave As String, ByVal parsPromocionReglaID As String) As DataTable
            Try
                'aProductosAplicados = New ArrayList
                ' Recuperar los productos a los que pueden aplicarse las promociones
                ' Cambios 06 Mayo 2006
                Dim sConsultaSQL As String = String.Empty
                If Me.SeleccionProducto Then
                    sConsultaSQL = "SELECT convert(bit,0) as Seleccionar,PromocionAplicacion.ProductoClave,Producto.Nombre,Cantidad,PromocionAplicacion.PRUTipoUnidad, Factor,(Disponible-Apartado-NoDisponible-(case  When Producto.venta=0 then INV.Contenido  Else 0 END)) as Existencia FROM PromocionAplicacion inner join Producto on PromocionAplicacion.ProductoCLave =  Producto.ProductoClave inner join ProductoDetalle on ProductoDetalle.ProductoClave = PromocionAplicacion.ProductoClave and ProductoDetalle.PRUTipoUnidad = PromocionAplicacion.PRUTipoUnidad and ProductoDetalle.ProductoDetClave = PromocionAplicacion.ProductoClave left join inventario INV on INV.ProductoClave = PromocionAplicacion.ProductoClave WHERE PromocionClave = '" & parsPromocionClave & "' AND PromocionReglaID='" & parsPromocionReglaID & "' AND TipoEstado=" & ServicesCentral.TiposEstadosRegistros.Activo
                Else
                    sConsultaSQL = "SELECT convert(bit,1) as Seleccionar,PromocionAplicacion.ProductoClave,Producto.Nombre,Cantidad,PromocionAplicacion.PRUTipoUnidad, Factor,(Disponible-Apartado-NoDisponible-(case  When Producto.venta=0 then INV.Contenido  Else 0 END)) as Existencia FROM PromocionAplicacion inner join Producto on PromocionAplicacion.ProductoCLave =  Producto.ProductoClave inner join ProductoDetalle on ProductoDetalle.ProductoClave = PromocionAplicacion.ProductoClave and ProductoDetalle.PRUTipoUnidad = PromocionAplicacion.PRUTipoUnidad and ProductoDetalle.ProductoDetClave = PromocionAplicacion.ProductoClave left join inventario INV on INV.ProductoClave = PromocionAplicacion.ProductoClave WHERE PromocionClave = '" & parsPromocionClave & "' AND PromocionReglaID='" & parsPromocionReglaID & "' AND TipoEstado=" & ServicesCentral.TiposEstadosRegistros.Activo
                End If

                ' /Cambios 06 Mayo 2006
                Dim DataTableProds As DataTable = oDBVen.RealizarConsultaSQL(sConsultaSQL, "PromocionAplicacion")
                Return DataTableProds
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
            Return Nothing
        End Function

        Public Function ObtenerAplicarRango(ByRef refparoTransProd As TransProd, ByRef refparoDataViewPromRegla As DataView, ByRef nResto As Double, ByVal parsListadoProductosAcumulados As String, ByRef parbAplicarPromocion As Boolean, Optional ByRef refparDataRowProducto As DataRow = Nothing, Optional ByVal bPrimeraVez As Boolean = False) As Boolean
            Try
                ' Recuperar los rangos que aplican para la promoción
                Dim refDataRowsView() As DataRowView = refparoDataViewPromRegla.FindRows(Me.PromocionClave)
                ' Verificar que exista el detalle
                If refDataRowsView.Length = 0 Then
                    Return False
                End If
                ' Recuperar los valores de comparacion capturados
                'Dim iCantidad As Integer = Me.Cantidad
                'Dim nImporte As Decimal = Me.Importe
                Dim vCantidadGrupo As Integer = 0
                ' Variable para guardar el rango que se va a aplicar
                Dim refDataRowViewRango As DataRowView = Nothing
                Dim sPromocionReglaID As String = String.Empty
                Dim dCantidadMaxima As Double = 0
                Me.AfectoImpuestos = False

                ' Determinar en el rango en el que entra la cantidad actual
                For Each refDataRowView As DataRowView In refDataRowsView
                    ' De acuerdo al tipo de rango
                    Select Case TipoRegla
                        Case 1
                            Select Case TipoRango
                                Case ServicesCentral.TiposRangosPromociones.PorCantidad
                                    Dim nMinimo As Integer = refDataRowView.Row.Item("Minimo")
                                    Dim nMaximo As Integer = refDataRowView.Row.Item("Maximo")
                                    ' Si cae en este rango de cantidad
                                    If Me.Cantidad >= nMinimo And Me.Cantidad <= nMaximo Then
                                        refDataRowViewRango = refDataRowView
                                        sPromocionReglaID = refDataRowView.Row.Item("PromocionReglaID")
                                        dCantidadMaxima = refDataRowView.Row.Item("Cantidad")
                                        ' Salir del ciclo
                                        Exit For
                                    End If
                                Case ServicesCentral.TiposRangosPromociones.PorImporte
                                    Dim nMinimo As Decimal = refDataRowView.Row.Item("Minimo")
                                    Dim nMaximo As Decimal = refDataRowView.Row.Item("Maximo")
                                    ' Si cae en este rango de importe
                                    If Me.Importe >= nMinimo And Me.Importe <= nMaximo Then
                                        refDataRowViewRango = refDataRowView
                                        sPromocionReglaID = refDataRowView.Row.Item("PromocionReglaID")
                                        dCantidadMaxima = refDataRowView.Row.Item("Cantidad")
                                        ' Salir del ciclo
                                        Exit For
                                    End If
                            End Select
                        Case 2 'Por Grupo
                            Select Case TipoRango
                                Case ServicesCentral.TiposRangosPromociones.PorCantidad
                                    Dim nMinimo As Integer = refDataRowView.Row.Item("Minimo")
                                    vCantidadGrupo = Fix(Me.Cantidad / nMinimo)
                                    If vCantidadGrupo > 0 Then
                                        refDataRowViewRango = refDataRowView
                                        sPromocionReglaID = refDataRowView.Row.Item("PromocionReglaID")
                                        dCantidadMaxima = refDataRowView.Row.Item("Cantidad")
                                    End If
                                    Exit For
                                Case ServicesCentral.TiposRangosPromociones.PorImporte
                                    Dim nMinimo As Decimal = refDataRowView.Row.Item("Minimo")
                                    vCantidadGrupo = Fix(Me.Importe / nMinimo)

                                    If vCantidadGrupo > 0 Then
                                        refDataRowViewRango = refDataRowView
                                        sPromocionReglaID = refDataRowView.Row.Item("PromocionReglaID")
                                        dCantidadMaxima = refDataRowView.Row.Item("Cantidad")
                                    End If
                                    Exit For
                            End Select
                    End Select
                Next
                ' Si no se encontro algun rango
                If refDataRowViewRango Is Nothing Then
                    ' No hay un rango valido
                    Return False
                End If


                If TipoAplicacion <> ServicesCentral.TiposAplicacionPromociones.Producto Then
                    If Not Obligatoria Then
                        If bPrimeraVez Then
                            If MsgBox(sMsgObligatoria.Replace("$0$", Me.PromocionClave & "-" & Me.Nombre & vbCrLf).Replace("$1$", parsListadoProductosAcumulados & vbCrLf).Replace("$2$", IIf(TipoRango = ServicesCentral.TiposRangosPromociones.PorCantidad, "Cantidad", "Importe")).Replace("$3$", IIf(TipoRango = ServicesCentral.TiposRangosPromociones.PorCantidad, Me.Cantidad, Me.Importe)), MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                                parbAplicarPromocion = False
                                Return False
                            Else
                                parbAplicarPromocion = True
                            End If
                        Else
                            If Not parbAplicarPromocion Then
                                Return False
                            End If
                        End If
                    End If
                End If

                Dim bEsValido As Boolean = False
                ' Asignar las propiedades al elemento de promoción a aplicar
                'Productos Acumulados solo afecta si es tipoProducto
                Select Case TipoAplicacion
                    Case ServicesCentral.TiposAplicacionPromociones.Descuento
                        If Not refDataRowViewRango.Row.IsNull("Porcentaje") Then
                            Me.Porcentaje = refDataRowViewRango.Row("Porcentaje")

                            If bPrimeraVez Then
                                nResto = refDataRowViewRango("Minimo") * vCantidadGrupo
                            End If

                            'Si el subtotal es 0 que no se aplique promocion
                            If refparDataRowProducto.Item("SubTotal") = 0 Then Return False

                            Dim sComandoSQL As New System.Text.StringBuilder
                            sComandoSQL.Append("UPDATE TransProdDetalle SET ")
                            sComandoSQL.Append("Promocion=1, ")
                            'Dim dPorc1 As Decimal
                            Select Case TipoRegla
                                Case 1
                                    dPorcentaje = Decimal.Round(Me.Porcentaje / 100, 4)

                                    'Guardar los detalles en TRPPRP
                                    oDBVen.EjecutarComandoSQL("INSERT INTO TRPPRP Select TransProdID,TransProdDetalleID,'" & Me.PromocionClave & "',Round(SubTotal * " & dPorcentaje & ",2),getdate(),'" & oVendedor.UsuarioId & "',0 from TransProdDetalle where TransProdId='" & refparoTransProd.TransProdId & "' AND ProductoClave='" & Me.ProductoClave & "' and Subtotal>0 ")

                                    sComandoSQL.Append("DescuentoImp = Round(DescuentoImp + (SubTotal * " & dPorcentaje & "),2), ")
                                    sComandoSQL.Append("SubTotal = Round(SubTotal - (SubTotal * " & dPorcentaje & "),2),")
                                Case 2
                                    Dim dMinimo As Double
                                    If TipoRango = ServicesCentral.TiposRangosPromociones.PorImporte Then
                                        If refparDataRowProducto("SubTotal") <= nResto Then
                                            dMinimo = refparDataRowProducto("SubTotal")
                                            nResto -= refparDataRowProducto("SubTotal")
                                        Else
                                            dMinimo = nResto
                                            nResto = 0
                                        End If
                                        'Dim dPorc As Double = dMinimo * (Me.Porcentaje / 100)
                                        'dPorcentaje = dPorc * vCantidadGrupo
                                        dPorcentaje = dMinimo * (Me.Porcentaje / 100)
                                    Else
                                        If refparDataRowProducto.Item("Cantidad") <= nResto Then
                                            dMinimo = refparDataRowProducto.Item("Cantidad")
                                            nResto -= refparDataRowProducto.Item("Cantidad")
                                        Else
                                            dMinimo = nResto
                                            nResto = 0
                                        End If
                                        Dim dImpPorProducto As Double = refparDataRowProducto.Item("SubTotal") / refparDataRowProducto.Item("Cantidad")
                                        'Dim dPorc As Double = (dImpPorProducto * dMinimo) * (Me.Porcentaje / 100)
                                        'dPorcentaje = dPorc * vCantidadGrupo
                                        dPorcentaje = (dImpPorProducto * dMinimo) * (Me.Porcentaje / 100)
                                    End If

                                    dPorcentaje = Decimal.Round((dPorcentaje * 100) / refparDataRowProducto.Item("SubTotal"), 8)
                                    dPorcentaje = Decimal.Round(dPorcentaje / 100, 8)
                                    sComandoSQL.Append("DescuentoImp = Round(DescuentoImp + (SubTotal * " & dPorcentaje & "),2), ")
                                    sComandoSQL.Append("SubTotal = Round(SubTotal - (SubTotal * " & dPorcentaje & "),2),")

                                    'Guardar los detalles en TRPPRP
                                    oDBVen.EjecutarComandoSQL("INSERT INTO TRPPRP Select TransProdID,TransProdDetalleID,'" & Me.PromocionClave & "',Round(SubTotal * " & dPorcentaje & ",2),getdate(),'" & oVendedor.UsuarioId & "',0 from TransProdDetalle where TransProdId='" & refparoTransProd.TransProdId & "' AND ProductoClave='" & Me.ProductoClave & "' and Subtotal>0 ")
                            End Select
                            sComandoSQL.Append("MFechaHora=" & UniFechaSQL(Now) & ",MUsuarioID='" & oVendedor.UsuarioId & "' ,Enviado=0 ")
                            ' Mas adelante se recalcula el nuevo subtotal, el impuesto y el total
                            sComandoSQL.Append("WHERE TransProdId='" & refparoTransProd.TransProdId & "' AND ProductoClave='" & Me.ProductoClave & "' and Subtotal>0 ")
                            bEsValido = (oDBVen.EjecutarComandoSQL(sComandoSQL.ToString) <> 0)
                            ' Recuperar el nuevo subtotal para considerarlo como base en las siguientes promociones
                            Dim dSubtotal As Double = oDBVen.EjecutarCmdScalardblSQL("SELECT SUM(SubTotal) AS SubTotal FROM TransProdDetalle WHERE TransProdId='" & refparoTransProd.TransProdId & "' AND ProductoClave='" & Me.ProductoClave & "'")
                            'If DataTableConsulta.Rows.Count > 0 Then
                            ' Actualizar el nuevo subtotal
                            refparDataRowProducto.Item("SubTotal") = dSubtotal
                            'End If
                            'DataTableConsulta = oDBVen.RealizarConsultaSQL("SELECT * FROM TransProdDetalle WHERE TransProdId='" & refparoTransProd.TransProdId & "' AND ProductoClave='" & Me.ProductoClave & "'", "Consulta")

                            Me.AfectoImpuestos = True
                            'DataTableConsulta.Dispose()

                        End If

                    Case ServicesCentral.TiposAplicacionPromociones.Bonificacion
                        'Dim iCantidad As Integer = Me.Cantidad
                        Dim nBonificacion As Double

                        'Si el subtotal es 0 que no se aplique promocion
                        If refparDataRowProducto.Item("SubTotal") = 0 Then Return False

                        If Not refDataRowViewRango.Row.IsNull("Importe") Then
                            nBonificacion = refDataRowViewRango.Row("Importe")

                            Dim dPorcentaje As Decimal

                            Dim sComandoSQL As New System.Text.StringBuilder
                            sComandoSQL.Append("UPDATE TransProdDetalle SET ")
                            sComandoSQL.Append("Promocion=1, ")
                            Select Case TipoRegla
                                Case 1
                                    dPorcentaje = nBonificacion / Me.Importe
                                    sComandoSQL.Append("DescuentoImp = Round(DescuentoImp + (SubTotal * " & dPorcentaje & "),2), ")
                                    sComandoSQL.Append("SubTotal = Round(SubTotal - (SubTotal * " & dPorcentaje & "),2),")

                                    'Guardar los detalles en TRPPRP
                                    oDBVen.EjecutarComandoSQL("INSERT INTO TRPPRP Select TransProdID,TransProdDetalleID,'" & Me.PromocionClave & "',Round(SubTotal * " & dPorcentaje & ",2),getdate(),'" & oVendedor.UsuarioId & "',0 from TransProdDetalle where TransProdId='" & refparoTransProd.TransProdId & "' AND ProductoClave='" & Me.ProductoClave & "' and Subtotal>0 ")
                                Case 2
                                    dPorcentaje = (nBonificacion * vCantidadGrupo) / Me.Importe
                                    sComandoSQL.Append("DescuentoImp = Round(DescuentoImp + (SubTotal *" & dPorcentaje & "),2), ")
                                    sComandoSQL.Append("SubTotal = Round(SubTotal - (SubTotal *" & dPorcentaje & "),2),")

                                    'Guardar los detalles en TRPPRP
                                    oDBVen.EjecutarComandoSQL("INSERT INTO TRPPRP Select TransProdID,TransProdDetalleID,'" & Me.PromocionClave & "',Round(SubTotal * " & dPorcentaje & ",2),getdate(),'" & oVendedor.UsuarioId & "',0 from TransProdDetalle where TransProdId='" & refparoTransProd.TransProdId & "' AND ProductoClave='" & Me.ProductoClave & "' and Subtotal>0 ")
                            End Select

                            sComandoSQL.Append("MFechaHora=" & UniFechaSQL(Now) & ",MUsuarioID='" & oVendedor.UsuarioId & "' ,Enviado=0 ")
                            ' Mas adelante se recalcula el nuevo subtotal, el impuesto y el total
                            sComandoSQL.Append("WHERE TransProdId='" & refparoTransProd.TransProdId & "' AND ProductoClave='" & Me.ProductoClave & "' and Subtotal>0 ")
                            bEsValido = (oDBVen.EjecutarComandoSQL(sComandoSQL.ToString) <> 0)
                            ' Recuperar el nuevo subtotal para considerarlo como base en las siguientes promociones
                            Dim dSubtotal As Double = oDBVen.EjecutarCmdScalardblSQL("SELECT SUM(SubTotal) AS SubTotal FROM TransProdDetalle WHERE TransProdId='" & refparoTransProd.TransProdId & "' AND ProductoClave='" & Me.ProductoClave & "'")
                            'If DataTableConsulta.Rows.Count > 0 Then
                            ' Actualizar el nuevo subtotal
                            refparDataRowProducto.Item("SubTotal") = dSubtotal
                            'End If
                            'DataTableConsulta = oDBVen.RealizarConsultaSQL("SELECT * FROM TransProdDetalle WHERE TransProdId='" & refparoTransProd.TransProdId & "' AND ProductoClave='" & Me.ProductoClave & "'", "Consulta")
                            Me.AfectoImpuestos = True
                        End If

                    Case ServicesCentral.TiposAplicacionPromociones.Producto
                        ' Obtener la lista de productos/cantidad de regalo
                        Dim blnValidarExistencia As Boolean = False
                        If (oVendedor.TipoModulo = ServicesCentral.TiposModulos.Preventa And oAgenda.RutaActual.Inventario = True) OrElse (oVendedor.TipoModulo = ServicesCentral.TiposModulos.Venta AndAlso refparoTransProd.ModuloMovDetalle.TipoModuloMovDetalle <> ServicesCentral.TiposModulosMovDet.MovSinInvConVis) OrElse (oVendedor.TipoModulo = ServicesCentral.TiposModulos.Distribucion And refparoTransProd.ModuloMovDetalle.TipoModuloMovDetalle = ServicesCentral.TiposModulosMovDet.Pedido) Then
                            blnValidarExistencia = True
                        End If

                        Dim dtProductosPromocion As DataTable = Me.RecuperarProductosDefault(Me.PromocionClave, sPromocionReglaID)
                        Dim oFormSeleccionarPromociones As FormSeleccionarPromociones
                        If TipoRegla = 1 Then
                            oFormSeleccionarPromociones = New FormSeleccionarPromociones(dtProductosPromocion, dCantidadMaxima, Me.SeleccionProducto, Me.CapturaProducto, Me.Nombre, Me.PendienteEntrega, blnValidarExistencia)
                        ElseIf TipoRegla = 2 Then
                            oFormSeleccionarPromociones = New FormSeleccionarPromociones(dtProductosPromocion, dCantidadMaxima, Me.SeleccionProducto, Me.CapturaProducto, Me.Nombre, Me.PendienteEntrega, blnValidarExistencia, vCantidadGrupo)
                        End If

                        Cursor.Current = Cursors.Default
                        oFormSeleccionarPromociones.ShowDialog()
                        Cursor.Current = Cursors.WaitCursor
                        oFormSeleccionarPromociones.Dispose()
                        oFormSeleccionarPromociones = Nothing
                        Dim drProductos As DataRow() = dtProductosPromocion.Select("Seleccionar = 1")
                        Dim iPartida As Integer = 0
                        If drProductos.Length > 0 Then
                            Dim sComandoSQL As New System.Text.StringBuilder
                            sComandoSQL.Append("UPDATE TransProdDetalle SET Promocion=1, ")
                            sComandoSQL.Append("MFechaHora=" & UniFechaSQL(Now) & ",MUsuarioID='" & oVendedor.UsuarioId & "' ,Enviado=0 ")
                            sComandoSQL.Append("WHERE TransProdId='" & refparoTransProd.TransProdId & "' AND ProductoClave='" & aProductosRegla(0) & "' and Subtotal>0 ")
                            oDBVen.EjecutarComandoSQL(sComandoSQL.ToString)

                            oDBVen.EjecutarComandoSQL("INSERT INTO TRPPRP Select TransProdID,TransProdDetalleID,'" & Me.PromocionClave & "',null,getdate(),'" & oVendedor.UsuarioId & "',0 from TransProdDetalle WHERE TransProdId='" & refparoTransProd.TransProdId & "' AND ProductoClave='" & aProductosRegla(0) & "' AND Subtotal>0 ")
                            ' Agregar al detalle tantos productos como sean indicados para este tipo de promoción
                            Dim sTransProdDetalleID As String = ""

                            Dim dCantidadDisponible As Decimal = 0
                            Dim sMsgError As String = String.Empty
                            For Each dr As DataRow In drProductos
                                dCantidadDisponible = 0
                                If (Not blnValidarExistencia) OrElse (Inventario.ValidarExistenciaDisponibleDec(dr("ProductoClave"), dr("PRUTipoUnidad"), dr("Cantidad"), dCantidadDisponible, sMsgError)) Then
                                    If Folio.ObtenerTransProdDetalleId(refparoTransProd.TransProdId, sTransProdDetalleID) Then
                                        If Folio.ObtenerTransProdPartida(refparoTransProd.TransProdId, dr("ProductoClave"), iPartida) Then
                                            sComandoSQL = New System.Text.StringBuilder
                                            sComandoSQL.Append("INSERT INTO TransProdDetalle (TransProdID, TransProdDetalleID, ProductoClave, DescuentoClave, TipoUnidad, Partida, Promocion, Cantidad, Precio, DescuentoPor, DescuentoImp, Impuesto, Subtotal, Total, PromocionClave, MFechaHora, MUsuarioID,Enviado) VALUES (")
                                            sComandoSQL.Append("'" & refparoTransProd.TransProdId & "',")
                                            sComandoSQL.Append("'" & sTransProdDetalleID & "',")
                                            sComandoSQL.Append("'" & dr("ProductoClave") & "',")
                                            sComandoSQL.Append("NULL,") ' DescuentoClave
                                            sComandoSQL.Append(dr("PRUTipoUnidad") & ",") ' TipoUnidad
                                            sComandoSQL.Append(iPartida & ",") ' Partida
                                            sComandoSQL.Append("2,") ' Promocion
                                            sComandoSQL.Append(dr("Cantidad") & ",") ' Cantidad
                                            sComandoSQL.Append("0,") ' Precio
                                            sComandoSQL.Append("0,") ' DescuentoPor
                                            sComandoSQL.Append("0,") ' DescuentoImp
                                            sComandoSQL.Append("0,") ' Impuesto
                                            sComandoSQL.Append("0,") ' Subtotal
                                            sComandoSQL.Append("0,") ' Total
                                            sComandoSQL.Append("'" & Me.PromocionClave & "',") ' PromocionClave
                                            sComandoSQL.Append(UniFechaSQL(Now) & ",")
                                            sComandoSQL.Append("'" & oVendedor.UsuarioId & "',0)")
                                            bEsValido = bEsValido Or (oDBVen.EjecutarComandoSQL(sComandoSQL.ToString) <> 0)
                                            ' Actualizar el inventario
                                            If blnValidarExistencia Then
                                                If refparoTransProd.ModuloMovDetalle.TipoModuloMovDetalle <> ServicesCentral.TiposModulosMovDet.MovSinInvConVis Then
                                                    If refparoTransProd.ModuloMovDetalle.TipoModulo = ServicesCentral.TiposModulos.Preventa And oAgenda.RutaActual.Inventario Then
                                                        Inventario.ActualizarInventarioDec(dr("ProductoClave"), dr("PRUTipoUnidad"), dr("Cantidad"), ServicesCentral.TiposTransProd.Pedido, ServicesCentral.TiposMovimientos.Salida, oVendedor.AlmacenId, False)
                                                    ElseIf refparoTransProd.ModuloMovDetalle.TipoModulo = ServicesCentral.TiposModulos.Venta Then
                                                        Inventario.ActualizarInventarioDec(dr("ProductoClave"), dr("PRUTipoUnidad"), dr("Cantidad"), ServicesCentral.TiposTransProd.Pedido, ServicesCentral.TiposMovimientos.NoDefinido, oVendedor.AlmacenId, False)
                                                    Else
                                                        Inventario.ActualizarInventarioDec(dr("ProductoClave"), dr("PRUTipoUnidad"), dr("Cantidad"), ServicesCentral.TiposTransProd.Pedido, ServicesCentral.TiposMovimientos.Entrada, oVendedor.AlmacenId, False)
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                Else
                                    If dCantidadDisponible > 0 Then
                                        If Folio.ObtenerTransProdDetalleId(refparoTransProd.TransProdId, sTransProdDetalleID) Then
                                            If Folio.ObtenerTransProdPartida(refparoTransProd.TransProdId, dr("ProductoClave"), iPartida) Then
                                                sComandoSQL = New System.Text.StringBuilder
                                                sComandoSQL.Append("INSERT INTO TransProdDetalle (TransProdID, TransProdDetalleID, ProductoClave, DescuentoClave, TipoUnidad, Partida, Promocion, Cantidad, Precio, DescuentoPor, DescuentoImp, Impuesto, Subtotal, Total, PromocionClave, MFechaHora, MUsuarioID,Enviado) VALUES (")
                                                sComandoSQL.Append("'" & refparoTransProd.TransProdId & "',")
                                                sComandoSQL.Append("'" & sTransProdDetalleID & "',")
                                                sComandoSQL.Append("'" & dr("ProductoClave") & "',")
                                                sComandoSQL.Append("NULL,") ' DescuentoClave
                                                sComandoSQL.Append(dr("PRUTipoUnidad") & ",") ' TipoUnidad
                                                sComandoSQL.Append(iPartida & ",") ' Partida
                                                sComandoSQL.Append("2,") ' Promocion
                                                sComandoSQL.Append(dCantidadDisponible & ",") ' Cantidad
                                                sComandoSQL.Append("0,") ' Precio
                                                sComandoSQL.Append("0,") ' DescuentoPor
                                                sComandoSQL.Append("0,") ' DescuentoImp
                                                sComandoSQL.Append("0,") ' Impuesto
                                                sComandoSQL.Append("0,") ' Subtotal
                                                sComandoSQL.Append("0,") ' Total
                                                sComandoSQL.Append("'" & Me.PromocionClave & "',") ' PromocionClave
                                                sComandoSQL.Append(UniFechaSQL(Now) & ",")
                                                sComandoSQL.Append("'" & oVendedor.UsuarioId & "',0)")
                                                bEsValido = bEsValido Or (oDBVen.EjecutarComandoSQL(sComandoSQL.ToString) <> 0)
                                                ' Actualizar el inventario
                                                If blnValidarExistencia Then
                                                    If refparoTransProd.ModuloMovDetalle.TipoModulo = ServicesCentral.TiposModulos.Preventa And oAgenda.RutaActual.Inventario Then
                                                        Inventario.ActualizarInventarioDec(dr("ProductoClave"), dr("PRUTipoUnidad"), dCantidadDisponible, ServicesCentral.TiposTransProd.Pedido, ServicesCentral.TiposMovimientos.Salida, oVendedor.AlmacenId, False)
                                                    ElseIf refparoTransProd.ModuloMovDetalle.TipoModulo = ServicesCentral.TiposModulos.Venta Then
                                                        Inventario.ActualizarInventarioDec(dr("ProductoClave"), dr("PRUTipoUnidad"), dCantidadDisponible, ServicesCentral.TiposTransProd.Pedido, ServicesCentral.TiposMovimientos.NoDefinido, oVendedor.AlmacenId, False)
                                                    Else
                                                        Inventario.ActualizarInventarioDec(dr("ProductoClave"), dr("PRUTipoUnidad"), dCantidadDisponible, ServicesCentral.TiposTransProd.Pedido, ServicesCentral.TiposMovimientos.Entrada, oVendedor.AlmacenId, False)
                                                    End If

                                                    ProductoNegado.Insertar(refparoTransProd.TransProdId, dr("ProductoClave"), Me.PromocionClave, aProductosRegla(0), dr("PRUTipoUnidad"), dr("Cantidad") - dCantidadDisponible, 1, refparoTransProd.ClienteActual.ClienteClave, refparoTransProd.FolioActual)
                                                End If
                                            End If
                                        End If
                                    Else
                                        If blnValidarExistencia And Me.PendienteEntrega Then
                                            ProductoNegado.Insertar(refparoTransProd.TransProdId, dr("ProductoClave"), Me.PromocionClave, aProductosRegla(0), dr("PRUTipoUnidad"), dr("Cantidad"), 1, refparoTransProd.ClienteActual.ClienteClave, refparoTransProd.FolioActual)
                                            bEsValido = True
                                        End If
                                    End If
                                End If
                            Next
                            dtProductosPromocion.Dispose()
                        End If
                End Select
                Me.Aplicada = bEsValido
                Return bEsValido
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
            ' Sucedio un error
            Return False
        End Function

    End Class
    Private Function rowValido(ByVal pvRegistro As Object) As String
        If pvRegistro Is Nothing Then Return " null "
        If pvRegistro.ToString = "" Then Return " null "

        Return "'" & pvRegistro & "'"
    End Function

    Public Sub ObtenerPromociones(ByVal parsTransProdID As String)

        If oVendedor.TipoModulo = ServicesCentral.TiposModulos.Distribucion Then
            dtTPDImpuesto = oDBVen.RealizarConsultaSQL("select * from TPDImpuesto where TransProdDetalleID in(Select TransProdDetalle.TransProdDetalleID from TransProdDetalle WHERE TransProdDetalle.TransProdID='" & parsTransProdID & "' AND TransProdDetalle.Promocion=2 ) ", "TPDImpuesto")
            dtTPDPromocion = oDBVen.RealizarConsultaSQL("Select * from TransProdDetalle WHERE TransProdID='" & parsTransProdID & "' AND Promocion=2 ", "Promociones")
        End If

    End Sub

    Public Sub InsertarPromociones()

        If oVendedor.TipoModulo = ServicesCentral.TiposModulos.Distribucion Then

            If Me.dtTPDPromocion.Rows.Count > 0 Then

                Dim sComando As String
                For Each drow As DataRow In dtTPDPromocion.Rows
                    sComando = "Insert Into TransProdDetalle values('" & drow(0) & "','" & drow(1) & "','" & drow(2) & "'," & rowValido(drow(3)) & "," & rowValido(drow(4)) & "," & drow(5) & "," & drow(6) & "," & drow(7) & "," & drow(8) & "," & rowValido(drow(9)) & "," & rowValido(drow(10)) & "," & drow(11) & "," & rowValido(drow(12)) & "," & drow(13) & "," & rowValido(drow(14)) & "," & rowValido(drow(15)) & "," & UniFechaSQL(drow(16)) & ",'" & drow(17) & "', 0 ," & rowValido(drow(19)) & "," & rowValido(drow(20)) & ")"
                    oDBVen.EjecutarComandoSQL(sComando)
                Next

                For Each drow As DataRow In Me.dtTPDImpuesto.Rows
                    sComando = "Insert Into TPDImpuesto values('" & drow(0) & "','" & drow(1) & "','" & drow(2) & "','" & rowValido(drow(3)) & "'," & drow(4) & "," & drow(5) & "," & drow(6) & ",'" & drow(7) & "',0)"
                    oDBVen.EjecutarComandoSQL(sComando)
                Next

            End If
        End If
    End Sub


    Public Function Preparar(ByVal parsTransProdID As String, ByVal parsModuloMovDetClave As String, ByVal partTipoTransProd As ServicesCentral.TiposTransProd, ByRef paroListasPrecios As ListasPreciosCliente, ByRef refparoImpuesto As Impuesto, ByVal pariTipoImpuesto As Integer, ByVal parbEsNuevo As Boolean, ByVal partTipoModulo As ServicesCentral.TiposModulos, ByVal parbFondoCristalSurtido As Boolean, ByVal parbInicio As Boolean) As Boolean
        Try
            ' Reestablecer los valores para aquellos detalles a los que previamente se le hayan aplicado promociones
            Dim sConsultaSQL As New System.Text.StringBuilder
            'sConsultaSQL.Append("SELECT TransProdDetalle.TransProdDetalleID, TransProdDetalle.ProductoClave, TransProdDetalle.TipoUnidad, TransProdDetalle.Partida, TransProdDetalle.Cantidad, ProductoDetalle.Factor ")
            sConsultaSQL.Append("SELECT TransProdDetalle.TransProdDetalleID, TransProdDetalle.ProductoClave, TransProdDetalle.TipoUnidad, TransProdDetalle.Partida, TransProdDetalle.Cantidad, TransProdDetalle.Cantidad1, ProductoDetalle.Factor, TransProdDetalle.Precio ")
            sConsultaSQL.Append("FROM TransProdDetalle ")
            sConsultaSQL.Append("INNER JOIN ProductoDetalle ON TransProdDetalle.ProductoClave = ProductoDetalle.ProductoClave AND TransProdDetalle.ProductoClave = ProductoDetalle.ProductoDetClave AND TransProdDetalle.TipoUnidad = ProductoDetalle.PRUTipoUnidad ")
            sConsultaSQL.Append("WHERE TransProdID='" & parsTransProdID & "' AND TransProdDetalle.Promocion=1 AND TransProdDetalle.Total<>0")
            Dim DataTableDet As DataTable = oDBVen.RealizarConsultaSQL(sConsultaSQL.ToString, "Detalle")
            Dim sProductoClave As String
            Dim sTransProdDetalleID As String
            Dim iPartida As Integer
            Dim dCantidad As Decimal
            Dim dCantidad1 As Decimal
            Dim iTipoUnidad As Integer
            Dim iFactor As Integer
            Dim dPrecio As Double
            ' Solo incluye los productos que fueron marcados como promoción y no fueron regalo (los regalos se borran mas abajo)
            For Each refDataRow As DataRow In DataTableDet.Rows
                ' Si el registro le han sido aplicadas promociones
                sProductoClave = refDataRow("ProductoClave")
                iPartida = refDataRow("Partida")
                iTipoUnidad = refDataRow("TipoUnidad")
                sTransProdDetalleID = refDataRow("TransProdDetalleID")
                iFactor = refDataRow("Factor")
                dCantidad = refDataRow("Cantidad")
                dCantidad1 = refDataRow("Cantidad1")
                dPrecio = refDataRow("Precio")
                Dim oTransProdDetalle As New TransProdDetalle(parsTransProdID, sProductoClave, iPartida)
                oTransProdDetalle.TipoUnidad = iTipoUnidad
                ' Buscar el precio del producto de la lista de precios original y guardarlo en precioSinFactor
                oTransProdDetalle.ObtenerPrecio(paroListasPrecios)
                ' Verificar si tiene Impuestos
                oTransProdDetalle.ObtenerListaImpuestos(refparoImpuesto, pariTipoImpuesto)
                ' Verificar si tiene descuentos
                oTransProdDetalle.Cantidad = dCantidad
                oTransProdDetalle.Cantidad1 = dCantidad1
                oTransProdDetalle.ObtenerTipoAplicacionDescuentos(parsModuloMovDetClave, parbEsNuevo)
                ' Actualizar las cantidades del detalle (no se actualiza el inventario)
                oTransProdDetalle.ActualizarDec(sTransProdDetalleID, partTipoTransProd, refparoImpuesto, dCantidad, dCantidad, iTipoUnidad, iFactor, ServicesCentral.TiposMovimientos.NoDefinido)
            Next
            ' Dar salida del inventario de productos de regalo
            Dim sComandoSQL As String
            If partTipoTransProd <> ServicesCentral.TiposTransProd.MovSinInvEV Then
                sComandoSQL = "SELECT ProductoClave,TipoUnidad, Cantidad FROM TransProdDetalle WHERE TransProdID='" & parsTransProdID & "' AND Promocion=2 "
                Dim DataTableRegalo As DataTable = oDBVen.RealizarConsultaSQL(sComandoSQL, "Regalos")
                For Each refDataRow As DataRow In DataTableRegalo.Rows
                    With refDataRow
                        If partTipoModulo = ServicesCentral.TiposModulos.Preventa AndAlso oAgenda.RutaActual.Inventario Then
                            Inventario.ActualizarInventarioDec(.Item("ProductoClave"), .Item("TipoUnidad"), -1 * .Item("Cantidad"), ServicesCentral.TiposTransProd.Pedido, ServicesCentral.TiposMovimientos.Entrada, oVendedor.AlmacenId, True)
                        Else
                            Inventario.ActualizarInventarioDec(.Item("ProductoClave"), .Item("TipoUnidad"), .Item("Cantidad"), ServicesCentral.TiposTransProd.Pedido, ServicesCentral.TiposMovimientos.NoDefinido, oVendedor.AlmacenId, True)
                        End If
                    End With
                Next
            End If
            ' Borrar los registros creados con los productos regalados
            oDBVen.EjecutarComandoSQL("DELETE FROM TPDImpuesto where TransProdDetalleID in(Select TransProdDetalle.TransProdDetalleID from TransProdDetalle WHERE TransProdDetalle.TransProdID='" & parsTransProdID & "' AND TransProdDetalle.Promocion=2 ) ")
            sComandoSQL = "DELETE FROM TransProdDetalle WHERE TransProdID='" & parsTransProdID & "' AND Promocion=2 "
            Dim iRegistros As Integer = oDBVen.EjecutarComandoSQL(sComandoSQL)
            ' Quitar la marca de promoción a los demas productos
            oDBVen.EjecutarComandoSQL("UPDATE TransProdDetalle SET Promocion=0,Enviado=0,MFechaHora=" & UniFechaSQL(Now) & ",MUsuarioID='" & oVendedor.UsuarioId & "' WHERE TransProdID='" & parsTransProdID & "' AND Promocion=1")

            'Borrar productosNegados por promociones
            oDBVen.EjecutarComandoSQL("DELETE FROM ProductoNegado where TransProdID='" & parsTransProdID & "' and not PromocionClave is null ")

            'Borrar el pedido relacionado de FondoCristal
            If parbInicio Then 'Si se acaba de entrar al pedido descontar inventario
                sComandoSQL = "SELECT TransProd.TransProdID,ProductoClave,TipoUnidad, Cantidad FROM TransProdDetalle inner join TransProd on TransProd.TransProdID = TransProdDetalle.TransProdID WHERE FacturaID='" & parsTransProdID & "' and Tipo = " & ServicesCentral.TiposTransProd.FondoCristal
                Dim DataTableFondoCristal As DataTable = oDBVen.RealizarConsultaSQL(sComandoSQL, "Fondo Cristal")
                If DataTableFondoCristal.Rows.Count > 0 Then
                    TransProdIDFondoCristal = DataTableFondoCristal.Rows(0)("TransProdID")
                End If
                If partTipoTransProd <> ServicesCentral.TiposTransProd.MovSinInvEV Then
                    For Each refDataRow As DataRow In DataTableFondoCristal.Rows
                        With refDataRow
                            If parbFondoCristalSurtido Then
                                Inventario.ActualizarInventarioDec(.Item("ProductoClave"), .Item("TipoUnidad"), .Item("Cantidad"), ServicesCentral.TiposTransProd.Pedido, ServicesCentral.TiposMovimientos.Entrada, oVendedor.AlmacenId, True)
                            Else
                                If partTipoModulo = ServicesCentral.TiposModulos.Preventa AndAlso oAgenda.RutaActual.Inventario Then
                                    Inventario.ActualizarInventarioDec(.Item("ProductoClave"), .Item("TipoUnidad"), -1 * .Item("Cantidad"), ServicesCentral.TiposTransProd.Pedido, ServicesCentral.TiposMovimientos.Entrada, oVendedor.AlmacenId, True)
                                Else
                                    Inventario.ActualizarInventarioDec(.Item("ProductoClave"), .Item("TipoUnidad"), .Item("Cantidad"), ServicesCentral.TiposTransProd.Pedido, ServicesCentral.TiposMovimientos.NoDefinido, oVendedor.AlmacenId, True)
                                End If
                            End If
                        End With
                    Next
                End If
            End If
            ' Borrar los registros creados con los productos de Fondo Cristal
            If TransProdIDFondoCristal <> String.Empty Then
                oDBVen.EjecutarComandoSQL("DELETE FROM TransProdDetalle WHERE TransProdID='" & TransProdIDFondoCristal & "' ")
                oDBVen.EjecutarComandoSQL("DELETE FROM TransProd WHERE FacturaID='" & parsTransProdID & "' ")
            End If
            Me.TransProdIDFondoCristal = String.Empty

            Return True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        Return False
    End Function

    Public Function Aplicar(ByRef refparoTransProd As TransProd, ByRef refparoImpuesto As Impuesto, ByVal parsPrecioClave As String) As Boolean
        Try
            'Borra los registros de TrpPrp
            Me.EliminarDetalle(refparoTransProd.TransProdId)
            ' Recuperar el detalle del documento
            Dim DataTableDetalle As DataTable
            Dim bEsquemas As Boolean = True
            If Not Me.RecuperarDetalle(refparoTransProd, DataTableDetalle) Then
                Return False
            End If
            Dim dr As DataRow
            Dim sListaProductosPedido As String = String.Empty
            For Each dr In DataTableDetalle.Rows
                sListaProductosPedido &= "'" & dr("ProductoClave") & "',"
            Next
            If sListaProductosPedido <> String.Empty Then
                sListaProductosPedido = Left(sListaProductosPedido, Len(sListaProductosPedido) - 1)
            End If
            'TODO: Eficientar
            Dim DataViewEsquemas As DataView
            Dim DataTableEsquemasCliente As DataTable
            refparoTransProd.ClienteActual.RecuperarEsquemas(DataViewEsquemas, DataTableEsquemasCliente)
            'If Not RecuperarEsquemas(refparoTransProd, DataViewEsquemas, DataTableEsquemasCliente) Then
            '    Return False
            'End If

            Dim sEsquemasCliente As String = String.Empty

            For Each dr In DataTableEsquemasCliente.Rows
                sEsquemasCliente &= "'" & dr("EsquemaID") & "',"
                oAgenda.ClienteActual.RecuperarEsquemasCliente(DataViewEsquemas, sEsquemasCliente, dr("EsquemaID"))
            Next
            If sEsquemasCliente.Length > 0 Then
                sEsquemasCliente = Left(sEsquemasCliente, sEsquemasCliente.Length - 1)
            End If
            ' Recuperar las promociones que apliquen
            Dim DataTablePromocion As DataTable
            If Not Me.RecuperarPromociones(refparoTransProd, DataTablePromocion, sEsquemasCliente) Then
                Return False
            End If
            ' Recuperar las promociones que aplican a los esquemas
            Dim DataTableEsqProm As DataTable
            Me.RecuperarPromocionesEsquemas(refparoTransProd, DataTableEsqProm, sEsquemasCliente)
            ' Recuperar los productos que aplican para promociones
            Dim DataTablePromProd As DataTable
            If Not Me.RecuperarPromocionesProductos(refparoTransProd, DataTablePromProd, sListaProductosPedido, sEsquemasCliente) Then
                Return False
            End If
            ' Recuperar las reglas de aplicacion de las promociones
            Dim DataTablePromRegla As DataTable
            If Not Me.RecuperarPromocionesReglas(refparoTransProd, DataTablePromRegla, sEsquemasCliente) Then
                Return False
            End If
            ' Aplicar las promociones
            Dim oReglas As New ArrayList
            Dim htReglasProdAcumulados As New Hashtable
            refparoTransProd.Promocion = False
            If Not Me.ObtenerPromocionesAAplicar(refparoTransProd, oReglas, htReglasProdAcumulados, DataTableDetalle, DataTablePromocion, DataTableEsqProm, DataTablePromProd, DataTablePromRegla, DataTableEsquemasCliente, DataViewEsquemas) Then
                DataTableDetalle.Dispose()
                DataTablePromocion.Dispose()
                DataTableEsqProm.Dispose()
                DataTablePromProd.Dispose()
                DataTablePromRegla.Dispose()
                Return False
            End If
            Dim bResultado As Boolean = False
            ' Asignar cero para recalcular todas las bonificaciones
            Dim sListaProductos As New System.Text.StringBuilder
            For i As Short = 0 To oReglas.Count - 1
                Dim refRegla As Promocion.Regla = oReglas(i)
                If refRegla.Aplicada Then
                    bResultado = bResultado Or True
                    If refRegla.AfectoImpuestos Then
                        If sListaProductos.Length > 0 Then
                            sListaProductos.Append(",")
                        End If
                        sListaProductos.Append("'" & refRegla.ProductoClave & "'")
                    End If
                End If
            Next

            Dim oReglaProductosAcumulados As ReglaProductosAcumulados
            Dim o As IDictionaryEnumerator = htReglasProdAcumulados.GetEnumerator
            While o.MoveNext
                oReglaProductosAcumulados = o.Value
                If oReglaProductosAcumulados.Aplicada Then
                    bResultado = bResultado Or True
                    If oReglaProductosAcumulados.AfectoImpuestos Then
                        If sListaProductos.Length > 0 Then
                            sListaProductos.Append(",")
                        End If
                        sListaProductos.Append("'" & oReglaProductosAcumulados.ProductoClave & "'")
                    End If
                End If
                oReglaProductosAcumulados = Nothing
            End While

            If sListaProductos.Length <> 0 Then
                ' Recalcular los impuestos para los productos afectados
                Me.RecalcularImpuestos(refparoTransProd, sListaProductos.ToString, refparoImpuesto, parsPrecioClave)
            End If
            'Guardar el detalle de los productos con promociones
            'Me.GuardarDetalle(refparoTransProd.TransProdId, oReglas)
            DataTableDetalle.Dispose()
            DataTablePromocion.Dispose()
            DataTableEsqProm.Dispose()
            DataTablePromProd.Dispose()
            DataTablePromRegla.Dispose()
            Return bResultado
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        Return False
    End Function

    Private Function Recuperar(ByRef refparoDataViewProm As DataView) As Boolean
        Dim iPos As Integer = refparoDataViewProm.Find(Me.PromocionClave)
        If iPos = -1 Then
            Return False
        End If
        Dim refDataRow As DataRow = refparoDataViewProm(iPos).Row
        With refDataRow
            Me.PromocionClave = .Item("PromocionClave")
            Me.Nombre = .Item("Nombre")
            Me.PermitirCascada = .Item("PermiteCascada")
            Me.Tipo = .Item("Tipo")
            Me.TipoAplicacion = .Item("TipoAplicacion")
            Me.TipoRango = .Item("TipoRango")
            Me.TipoRegla = .Item("TipoRegla")
            Me.Obligatoria = .Item("Obligatoria")
            Me.SeleccionProducto = .Item("SeleccionProducto")
            Me.CapturaCantidad = .Item("CapturaCantidad")
            Me.PendienteEntrega = .Item("PendienteEntrega")
        End With
        Return True
    End Function

    Private Function RecuperarDetalle(ByRef refparoTransProd As TransProd, ByRef refparoDataTableDetalle As DataTable) As Boolean
        Try
            ' Obtener el grupo de productos totalizados en base a la clave del producto
            Dim sConsultaSQL As New System.Text.StringBuilder
            sConsultaSQL.Append("SELECT TransProdDetalle.ProductoClave, SUM(TransProdDetalle.Cantidad * ProductoDetalle.Factor) AS Cantidad, SUM(TransProdDetalle.Subtotal) AS Subtotal, SUM(TransProdDetalle.Impuesto) AS Impuesto, SUM(TransProdDetalle.Cantidad1) as Cantidad1 FROM TransProdDetalle ")
            sConsultaSQL.Append("INNER JOIN ProductoDetalle ON TransProdDetalle.ProductoClave = ProductoDetalle.ProductoClave AND TransProdDetalle.TipoUnidad = ProductoDetalle.PRUTipoUnidad ")
            sConsultaSQL.Append("WHERE (TransProdDetalle.TransProdID = '" & refparoTransProd.TransProdId & "') AND (ProductoDetalle.ProductoClave = ProductoDetalle.ProductoDetClave) ")
            sConsultaSQL.Append("AND TransProdDetalle.Promocion=0 ")
            sConsultaSQL.Append("GROUP BY TransProdDetalle.ProductoClave ")
            sConsultaSQL.Append("ORDER BY TransProdDetalle.ProductoClave")
            refparoDataTableDetalle = oDBVen.RealizarConsultaSQL(sConsultaSQL.ToString, "Detalle")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        Return (refparoDataTableDetalle.Rows.Count <> 0)
    End Function

    Private Function RecuperarPromociones(ByRef refparoTransProd As TransProd, ByRef refparoDataTablePromocion As DataTable, ByVal parsEsquemasCliente As String) As Boolean
        Try
            Dim sConsultaSQL As New System.Text.StringBuilder
            sConsultaSQL.Append("SELECT Promocion.PromocionClave, Promocion.Nombre, Promocion.PermiteCascada, Promocion.Tipo, Promocion.TipoRango, Promocion.TipoRegla, Promocion.TipoAplicacion,Promocion.Obligatoria,Promocion.SeleccionProducto, Promocion.CapturaCantidad,Promocion.PendienteEntrega FROM Promocion ")
            sConsultaSQL.Append("INNER JOIN PromocionModulo ON Promocion.PromocionClave = PromocionModulo.PromocionClave ")
            sConsultaSQL.Append("WHERE PromocionModulo.ModuloMovDetalleClave = '" & refparoTransProd.ModuloMovDetalle.ModuloMovDetalleClave & "' ")
            sConsultaSQL.Append("AND " & UniFechaSQL(refparoTransProd.FechaCaptura) & ">=Promocion.FechaInicial AND " & UniFechaSQL(refparoTransProd.FechaCaptura) & "<=Promocion.FechaFinal ")
            sConsultaSQL.Append("AND Promocion.Tipo in (" & ServicesCentral.TiposPromociones.Producto & ") ")
            sConsultaSQL.Append("AND Promocion.TipoEstado=" & ServicesCentral.TiposEstadosRegistros.Activo & " ")
            sConsultaSQL.Append("AND PromocionModulo.TipoEstado=" & ServicesCentral.TiposEstadosRegistros.Activo & " ")
            sConsultaSQL.Append("UNION ")
            sConsultaSQL.Append("SELECT Promocion.PromocionClave, Promocion.Nombre, Promocion.PermiteCascada, Promocion.Tipo, Promocion.TipoRango, Promocion.TipoRegla, Promocion.TipoAplicacion, Promocion.Obligatoria, Promocion.SeleccionProducto, Promocion.CapturaCantidad, Promocion.PendienteEntrega  FROM Promocion ")
            sConsultaSQL.Append("INNER JOIN PromocionModulo ON Promocion.PromocionClave = PromocionModulo.PromocionClave ")
            sConsultaSQL.Append("INNER JOIN PromocionDetalle ON PromocionDetalle.PromocionClave = Promocion.PromocionClave ")
            sConsultaSQL.Append("WHERE PromocionModulo.ModuloMovDetalleClave = '" & refparoTransProd.ModuloMovDetalle.ModuloMovDetalleClave & "' ")
            sConsultaSQL.Append("AND " & UniFechaSQL(refparoTransProd.FechaCaptura) & ">=Promocion.FechaInicial AND " & UniFechaSQL(refparoTransProd.FechaCaptura) & "<=Promocion.FechaFinal ")
            sConsultaSQL.Append("AND Promocion.Tipo in (" & ServicesCentral.TiposPromociones.Cliente & "," & ServicesCentral.TiposPromociones.ProductosAcumulados & "," & ServicesCentral.TiposPromociones.FondoCristal & ") ")
            sConsultaSQL.Append("AND PromocionDetalle.EsquemaID in(" & parsEsquemasCliente & ")")
            sConsultaSQL.Append("AND Promocion.TipoEstado=" & ServicesCentral.TiposEstadosRegistros.Activo & " ")
            sConsultaSQL.Append("AND PromocionModulo.TipoEstado=" & ServicesCentral.TiposEstadosRegistros.Activo & " ")
            sConsultaSQL.Append("ORDER BY Promocion.PromocionClave")
            refparoDataTablePromocion = oDBVen.RealizarConsultaSQL(sConsultaSQL.ToString, "Promocion")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        Return (refparoDataTablePromocion.Rows.Count <> 0)
    End Function


    Private Sub RecuperarPromocionesEsquemas(ByRef refparoTransprod As TransProd, ByRef refparoDataTableEsqProm As DataTable, ByVal parsEsquemasCliente As String)
        Try
            ' Recuperar los esquemas a los cuales se aplica la promocion
            Dim sConsultaSQL As New System.Text.StringBuilder
            sConsultaSQL.Append("SELECT PromocionDetalle.PromocionClave, PromocionDetalle.EsquemaID FROM PromocionDetalle ")
            sConsultaSQL.Append("INNER JOIN Esquema ON PromocionDetalle.EsquemaID = Esquema.EsquemaID ")
            sConsultaSQL.Append("INNER JOIN Promocion on PromocionDetalle.PromocionClave = Promocion.PromocionClave INNER JOIN PromocionModulo ON Promocion.PromocionClave = PromocionModulo.PromocionClave ")
            sConsultaSQL.Append("WHERE PromocionModulo.ModuloMovDetalleClave = '" & refparoTransprod.ModuloMovDetalle.ModuloMovDetalleClave & "' ")
            sConsultaSQL.Append("AND " & UniFechaSQL(refparoTransprod.FechaCaptura) & ">=Promocion.FechaInicial AND " & UniFechaSQL(refparoTransprod.FechaCaptura) & "<=Promocion.FechaFinal ")
            sConsultaSQL.Append("AND Promocion.TipoEstado=" & ServicesCentral.TiposEstadosRegistros.Activo & " ")
            sConsultaSQL.Append("AND PromocionModulo.TipoEstado=" & ServicesCentral.TiposEstadosRegistros.Activo & " ")
            sConsultaSQL.Append("AND PromocionDetalle.TipoEstado=" & ServicesCentral.TiposEstadosRegistros.Activo & " ")
            sConsultaSQL.Append("AND PromocionDetalle.EsquemaID in(" & parsEsquemasCliente & ") ")
            sConsultaSQL.Append("ORDER BY PromocionDetalle.PromocionClave")
            refparoDataTableEsqProm = oDBVen.RealizarConsultaSQL(sConsultaSQL.ToString, "PromocionEsquema")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Function BuscarGrupo(ByRef refparDataViewEsquemas As DataView, ByRef refparDataViewPromEsq As DataView, ByVal refparsNodo As String, ByVal parsPromocionClave As String, ByVal pariNivel As Integer) As Integer
        Try
            ' Buscar el padre del nodo
            Dim iEsq As Integer = refparDataViewEsquemas.Find(refparsNodo)
            ' Si se encuentra
            If iEsq <> -1 Then
                If Not refparDataViewEsquemas.Item(iEsq).Row.IsNull("EsquemaIDPadre") Then
                    ' Recuperar el padre del nodo encontrado
                    Dim oEsquema(1) As Object
                    oEsquema(0) = parsPromocionClave
                    ' Conformar el elemento a buscar en el dataview de ImpuestoEsquema, considerando la clave de impuesto
                    oEsquema(1) = refparDataViewEsquemas.Item(iEsq).Item("EsquemaIDPadre")
                    ' Buscar el nodo en los impuestos por esquemas por productos
                    iEsq = refparDataViewPromEsq.Find(oEsquema)
                    ' Si se encontro
                    If iEsq <> -1 Then
                        Return iEsq
                    Else
                        ' No se encontro, seguir buscando en el arbol hacia arriba
                        Return BuscarGrupo(refparDataViewEsquemas, refparDataViewPromEsq, oEsquema(1), parsPromocionClave, pariNivel + 1)
                    End If
                End If
            End If
        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message, MsgBoxStyle.Critical, "BuscarGrupo")
        Catch ExcB As Exception
            MsgBox(ExcB.Message, MsgBoxStyle.Critical, "BuscarGrupo")
        End Try
        Return -1
    End Function

    Private Function RecuperarPromocionesProductos(ByRef refparoTransProd As TransProd, ByRef refparoDataTablePromProd As DataTable, ByVal refparsListaProductos As String, ByVal parsEsquemasCliente As String) As Boolean
        Try
            ' Recuperar los productos a los que pueden aplicarse las promociones
            Dim sConsultaSQL As New System.Text.StringBuilder
            sConsultaSQL.Append("SELECT ProductoClave, PromocionProducto.PromocionClave, Jerarquia FROM PromocionProducto ")
            sConsultaSQL.Append("INNER JOIN Promocion on PromocionProducto.PromocionClave = Promocion.PromocionClave INNER JOIN PromocionModulo ON Promocion.PromocionClave = PromocionModulo.PromocionClave ")
            sConsultaSQL.Append("WHERE PromocionModulo.ModuloMovDetalleClave = '" & refparoTransProd.ModuloMovDetalle.ModuloMovDetalleClave & "' ")
            sConsultaSQL.Append("AND " & UniFechaSQL(refparoTransProd.FechaCaptura) & ">=Promocion.FechaInicial AND " & UniFechaSQL(refparoTransProd.FechaCaptura) & "<=Promocion.FechaFinal ")
            sConsultaSQL.Append("AND Promocion.Tipo in (" & ServicesCentral.TiposPromociones.Producto & ") ")
            sConsultaSQL.Append("AND Promocion.TipoEstado=" & ServicesCentral.TiposEstadosRegistros.Activo & " ")
            sConsultaSQL.Append("AND PromocionModulo.TipoEstado=" & ServicesCentral.TiposEstadosRegistros.Activo & " ")
            sConsultaSQL.Append("AND ProductoClave IN(" & refparsListaProductos & ") ")
            sConsultaSQL.Append("AND PromocionProducto.TipoEstado=" & ServicesCentral.TiposEstadosRegistros.Activo & " ")
            sConsultaSQL.Append("UNION ")
            sConsultaSQL.Append("SELECT ProductoClave, PromocionProducto.PromocionClave, Jerarquia FROM PromocionProducto ")
            sConsultaSQL.Append("INNER JOIN Promocion on PromocionProducto.PromocionClave = Promocion.PromocionClave INNER JOIN PromocionModulo ON Promocion.PromocionClave = PromocionModulo.PromocionClave ")
            sConsultaSQL.Append("INNER JOIN PromocionDetalle ON PromocionDetalle.PromocionClave = Promocion.PromocionClave ")
            sConsultaSQL.Append("WHERE PromocionModulo.ModuloMovDetalleClave = '" & refparoTransProd.ModuloMovDetalle.ModuloMovDetalleClave & "' ")
            sConsultaSQL.Append("AND " & UniFechaSQL(refparoTransProd.FechaCaptura) & ">=Promocion.FechaInicial AND " & UniFechaSQL(refparoTransProd.FechaCaptura) & "<=Promocion.FechaFinal ")
            sConsultaSQL.Append("AND Promocion.Tipo in (" & ServicesCentral.TiposPromociones.Cliente & "," & ServicesCentral.TiposPromociones.ProductosAcumulados & "," & ServicesCentral.TiposPromociones.FondoCristal & ") ")
            sConsultaSQL.Append("AND PromocionDetalle.EsquemaID in(" & parsEsquemasCliente & ") ")
            sConsultaSQL.Append("AND Promocion.TipoEstado=" & ServicesCentral.TiposEstadosRegistros.Activo & " ")
            sConsultaSQL.Append("AND PromocionModulo.TipoEstado=" & ServicesCentral.TiposEstadosRegistros.Activo & " ")
            sConsultaSQL.Append("AND ProductoClave IN(" & refparsListaProductos & ") ")
            sConsultaSQL.Append("AND PromocionProducto.TipoEstado=" & ServicesCentral.TiposEstadosRegistros.Activo & " ")
            sConsultaSQL.Append("ORDER BY ProductoClave, Jerarquia, PromocionProducto.PromocionClave")
            refparoDataTablePromProd = oDBVen.RealizarConsultaSQL(sConsultaSQL.ToString, "PromocionProducto")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        Return (refparoDataTablePromProd.Rows.Count <> 0)
    End Function

    Private Function RecuperarPromocionesReglas(ByRef refparoTransProd As TransProd, ByRef refparoDataTablePromRegla As DataTable, ByVal parsEsquemasCliente As String) As Boolean
        Try
            ' Recuperar los productos a los que pueden aplicarse las promociones
            Dim sConsultaSQL As New System.Text.StringBuilder
            sConsultaSQL.Append("SELECT PromocionRegla.PromocionClave, PromocionReglaID, Minimo, Maximo, PrecioClave, Porcentaje, Importe, Cantidad FROM PromocionRegla ")
            sConsultaSQL.Append("INNER JOIN Promocion on PromocionRegla.PromocionClave = Promocion.PromocionClave INNER JOIN PromocionModulo ON Promocion.PromocionClave = PromocionModulo.PromocionClave ")
            sConsultaSQL.Append("WHERE PromocionModulo.ModuloMovDetalleClave = '" & refparoTransProd.ModuloMovDetalle.ModuloMovDetalleClave & "' ")
            sConsultaSQL.Append("AND " & UniFechaSQL(refparoTransProd.FechaCaptura) & ">=Promocion.FechaInicial AND " & UniFechaSQL(refparoTransProd.FechaCaptura) & "<=Promocion.FechaFinal ")
            sConsultaSQL.Append("AND Promocion.Tipo in (" & ServicesCentral.TiposPromociones.Producto & ") ")
            sConsultaSQL.Append("AND Promocion.TipoEstado=" & ServicesCentral.TiposEstadosRegistros.Activo & " ")
            sConsultaSQL.Append("AND PromocionModulo.TipoEstado=" & ServicesCentral.TiposEstadosRegistros.Activo & " ")
            sConsultaSQL.Append("UNION ")
            sConsultaSQL.Append("SELECT PromocionRegla.PromocionClave, PromocionReglaID, Minimo, Maximo, PrecioClave, Porcentaje, Importe, Cantidad FROM PromocionRegla ")
            sConsultaSQL.Append("INNER JOIN Promocion on PromocionRegla.PromocionClave = Promocion.PromocionClave INNER JOIN PromocionModulo ON Promocion.PromocionClave = PromocionModulo.PromocionClave ")
            sConsultaSQL.Append("INNER JOIN PromocionDetalle ON PromocionDetalle.PromocionClave = Promocion.PromocionClave ")
            sConsultaSQL.Append("WHERE PromocionModulo.ModuloMovDetalleClave = '" & refparoTransProd.ModuloMovDetalle.ModuloMovDetalleClave & "' ")
            sConsultaSQL.Append("AND " & UniFechaSQL(refparoTransProd.FechaCaptura) & ">=Promocion.FechaInicial AND " & UniFechaSQL(refparoTransProd.FechaCaptura) & "<=Promocion.FechaFinal ")
            sConsultaSQL.Append("AND Promocion.Tipo in (" & ServicesCentral.TiposPromociones.Cliente & "," & ServicesCentral.TiposPromociones.ProductosAcumulados & "," & ServicesCentral.TiposPromociones.FondoCristal & ") ")
            sConsultaSQL.Append("AND PromocionDetalle.EsquemaID in(" & parsEsquemasCliente & ") ")
            sConsultaSQL.Append("AND Promocion.TipoEstado=" & ServicesCentral.TiposEstadosRegistros.Activo & " ")
            sConsultaSQL.Append("AND PromocionModulo.TipoEstado=" & ServicesCentral.TiposEstadosRegistros.Activo & " ")
            sConsultaSQL.Append("ORDER BY PromocionRegla.PromocionClave, Minimo, Maximo")
            refparoDataTablePromRegla = oDBVen.RealizarConsultaSQL(sConsultaSQL.ToString, "PromocionRegla")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        Return (refparoDataTablePromRegla.Rows.Count <> 0)
    End Function

    'Private Sub SeleccionProductos(ByRef refpardtProductos As DataTable, ByVal pardCantidadMaxima As Double)

    'End Sub

    Private Function ObtenerPromocionesAAplicar(ByRef refparoTransProd As TransProd, ByRef refparoReglas As ArrayList, ByRef refparoReglasProdAcumulados As Hashtable, ByRef refparoDataTableDetalle As DataTable, ByRef refparoDataTablePromocion As DataTable, ByRef refparoDataTableEsqProm As DataTable, ByRef refparoDataTablePromProd As DataTable, ByRef refparoDataTablePromRegla As DataTable, ByRef refparoDataTableEsquemasCliente As DataTable, ByRef refparoDataViewEsquemas As DataView) As Boolean
        ' Recuperar los esquemas de clientes, y en general la estructura de esquemas a los que pertenece el cliente
        ' Crear el DataView para buscar las promociones
        Dim DataViewProm As DataView = New DataView(refparoDataTablePromocion, "", "PromocionClave", DataViewRowState.CurrentRows)
        ' Crear el DataView para buscar los esquemas de clientes cuando el tipo de promoción es por cliente
        Dim DataViewEsqProm As DataView = New DataView(refparoDataTableEsqProm, "", "PromocionClave,EsquemaID", DataViewRowState.CurrentRows)
        ' Crear el DataView para buscar los productos por promoción
        Dim DataViewPromProd As DataView = New DataView(refparoDataTablePromProd, "", "ProductoClave", DataViewRowState.CurrentRows)
        ' Crear el DataView para buscar las reglas de aplicacion de promociones
        Dim DataViewPromRegla As DataView = New DataView(refparoDataTablePromRegla, "", "PromocionClave", DataViewRowState.CurrentRows)
        Dim bAplicar As Boolean
        ' Quitar cualquier elemento del arreglo
        refparoReglas.Clear()
        ' Para cada producto del detalle

        Dim nRestoAcumulado As Double = 0
        Dim bAplicarPromocion As Boolean = True
        Dim bPrimeraVez As Boolean = True
        Dim htPromociones As New Hashtable
        Dim htAcumPromociones As New Hashtable

        Dim sProductosProm As String = ""
        Dim sProductosDetalleProm As String = String.Empty
        For Each dr As DataRow In refparoDataTablePromocion.Rows
            Dim aAcumulados As New ArrayList
            Dim nCantidadAcumulado As Integer
            Dim nImporteAcumulado As Double
            Dim drProds() As DataRow
            drProds = refparoDataTablePromProd.Select("PromocionClave = '" & dr("PromocionClave") & "'")
            sProductosProm = ""
            sProductosDetalleProm = String.Empty
            For Each drProd As DataRow In drProds
                sProductosProm &= "'" & drProd("ProductoClave") & "',"
            Next
            If sProductosProm <> String.Empty Then
                sProductosProm = Left(sProductosProm, Len(sProductosProm) - 1)
                nCantidadAcumulado = refparoDataTableDetalle.Compute("sum(Cantidad)", "ProductoClave in (" & sProductosProm & ")")
                nImporteAcumulado = refparoDataTableDetalle.Compute("sum(Subtotal)", "ProductoClave in (" & sProductosProm & ")")
                Dim drProdsDetalleProm() As DataRow
                drProdsDetalleProm = refparoDataTableDetalle.Select("ProductoClave in(" & sProductosProm & ")")
                For Each drProd As DataRow In drProdsDetalleProm
                    sProductosDetalleProm &= "'" & drProd("ProductoClave") & "',"
                Next
                If sProductosDetalleProm <> String.Empty Then
                    sProductosDetalleProm = Left(sProductosDetalleProm, Len(sProductosDetalleProm) - 1)
                End If
                aAcumulados.Add(nCantidadAcumulado)
                aAcumulados.Add(nImporteAcumulado)
                aAcumulados.Add(sProductosDetalleProm)
                If Not htAcumPromociones.Contains(dr("PromocionClave")) Then
                    htAcumPromociones.Add(dr("PromocionClave"), aAcumulados)
                End If
            End If
        Next

        For Each refDataRowProducto As DataRow In refparoDataTableDetalle.Rows
            ' Verificar que promociones aplican para este producto
            Dim oProducto As Object = refDataRowProducto.Item("ProductoClave")
            ' Buscar las promociones para este producto
            Dim refDataRowsProds() As DataRowView = DataViewPromProd.FindRows(oProducto)
            Dim bPrimeraPromocion As Boolean = True
            ' Para cada promoción del producto
            For Each refDataRowViewProdProm As DataRowView In refDataRowsProds
                ' Recuperar la clave de la promoción
                Me.PromocionClave = refDataRowViewProdProm.Row("PromocionClave")
                Me.Recuperar(DataViewProm)
                ' Aplicar por defecto la promoción
                bAplicar = True
                ' Pero verificar que si el tipo de promoción es por cliente
                If Me.Tipo = ServicesCentral.TiposPromociones.Cliente Then
                    ' El cliente pertenezca a o los esquemas especificados para esta promoción (Solo si hay esquemas de clientes por esta promoción)
                    If Not refparoDataTableEsqProm Is Nothing And Not DataViewEsqProm Is Nothing Then
                        ' Asumir que no hay esquemas para esta promoción
                        bAplicar = False
                        Dim oEsquema(1) As Object
                        oEsquema(0) = Me.PromocionClave
                        ' Para cada esquema al que pertenece el cliente
                        For Each refDataRowEsquema As DataRow In refparoDataTableEsquemasCliente.Rows
                            ' Formar la llave de busqueda en DataViewEsqProm (PromocionClave + EsquemaID)
                            oEsquema(1) = refDataRowEsquema("EsquemaID")
                            ' Buscar la PromocionClave + EsquemaID en DataViewEsqProm
                            Dim iPos As Integer = DataViewEsqProm.Find(oEsquema)
                            ' Se no se encontro el esquema
                            If iPos = -1 Then
                                ' Buscar si los ascendentes estan definidos
                                iPos = Me.BuscarGrupo(refparoDataViewEsquemas, DataViewEsqProm, oEsquema(1), oEsquema(0), 7)
                            End If
                            ' Si se encontro el esquema actual o uno de sus ascendentes definido en la tabla de esquemas validos para cada promoción
                            If iPos <> -1 Then
                                ' Aplicar esta promoción
                                bAplicar = True
                                Exit For
                            End If
                        Next
                    End If
                End If
                ' Si se ha determinado aplicar esta promoción para el producto actual
                If bAplicar Then
                    If Me.Tipo = ServicesCentral.TiposPromociones.ProductosAcumulados Then
                        Select Case Me.TipoAplicacion
                            Case ServicesCentral.TiposAplicacionPromociones.Descuento, ServicesCentral.TiposAplicacionPromociones.Bonificacion
                                Dim oReglaAcumulados As ReglaProductosAcumulados
                                oReglaAcumulados = New ReglaProductosAcumulados(Me.PromocionClave, Me.Nombre, Me.Obligatoria, Me.SeleccionProducto, Me.CapturaCantidad, Me.TipoRango, Me.TipoRegla, oProducto, Me.TipoAplicacion, Me.MensajeObligatoria, Me.PendienteEntrega)
                                Dim sListaProductosAcumulados As String = String.Empty
                                If htAcumPromociones.Contains(Me.PromocionClave) Then
                                    Dim aAcumulados As ArrayList
                                    aAcumulados = htAcumPromociones(Me.PromocionClave)
                                    oReglaAcumulados.Cantidad = aAcumulados(0)
                                    oReglaAcumulados.Importe = aAcumulados(1)
                                    sListaProductosAcumulados = aAcumulados(2)
                                Else
                                    oReglaAcumulados.Cantidad = 0
                                    oReglaAcumulados.Importe = 0
                                End If

                                If htPromociones.Contains(Me.PromocionClave) Then
                                    bPrimeraVez = False
                                    nRestoAcumulado = CType(htPromociones(Me.PromocionClave), ArrayList)(0)
                                    bAplicarPromocion = CType(htPromociones(Me.PromocionClave), ArrayList)(1)
                                Else
                                    bPrimeraVez = True
                                    nRestoAcumulado = 0
                                    bAplicarPromocion = True
                                End If

                                If oReglaAcumulados.ObtenerAplicarRango(refparoTransProd, DataViewPromRegla, nRestoAcumulado, sListaProductosAcumulados, bAplicarPromocion, refDataRowProducto, bPrimeraVez) Then
                                    If refparoReglasProdAcumulados.ContainsKey(Me.PromocionClave & "-" & refDataRowProducto("ProductoClave")) Then
                                        refparoReglasProdAcumulados(Me.PromocionClave & "-" & refDataRowProducto("ProductoClave")) = oReglaAcumulados
                                    Else
                                        refparoReglasProdAcumulados.Add(Me.PromocionClave & "-" & refDataRowProducto("ProductoClave"), oReglaAcumulados)
                                    End If
                                End If

                                If htPromociones.Contains(Me.PromocionClave) Then
                                    CType(htPromociones(Me.PromocionClave), ArrayList)(0) = nRestoAcumulado
                                    CType(htPromociones(Me.PromocionClave), ArrayList)(1) = bAplicarPromocion
                                    'aValores.Add(nRestoAcumulado)
                                    'aValores.Add(bAplicarPromocion)
                                    'htPromociones(Me.PromocionClave) = aValores
                                Else
                                    Dim aValores As New ArrayList
                                    aValores.Add(nRestoAcumulado)
                                    aValores.Add(bAplicarPromocion)
                                    htPromociones.Add(Me.PromocionClave, aValores)
                                End If

                            Case ServicesCentral.TiposAplicacionPromociones.Producto
                                Dim oReglaAcumulados As ReglaProductosAcumulados
                                If refparoReglasProdAcumulados.ContainsKey(Me.PromocionClave) Then
                                    oReglaAcumulados = refparoReglasProdAcumulados(Me.PromocionClave)
                                Else
                                    oReglaAcumulados = New ReglaProductosAcumulados(Me.PromocionClave, Me.Nombre, Me.Obligatoria, Me.SeleccionProducto, Me.CapturaCantidad, Me.TipoRango, Me.TipoRegla, oProducto, Me.TipoAplicacion, String.Empty, Me.PendienteEntrega)
                                    refparoReglasProdAcumulados.Add(Me.PromocionClave, oReglaAcumulados)
                                End If

                                oReglaAcumulados.ProductosRegla.Add(refDataRowProducto("ProductoClave"))
                                oReglaAcumulados.Cantidad = oReglaAcumulados.Cantidad + refDataRowProducto("Cantidad")
                                oReglaAcumulados.Importe = oReglaAcumulados.Importe + refDataRowProducto("Subtotal")
                        End Select
                    Else
                        Dim oRegla As New Regla(Me.PromocionClave, Me.Nombre, oProducto, Me.TipoAplicacion, Me.Tipo, Me.SeleccionProducto, Me.CapturaCantidad, Me.Obligatoria, Me.sMensajeObligatoria)
                        If oRegla.ObtenerAplicarRango(refparoTransProd, refDataRowProducto, DataViewPromRegla, Me.TipoAplicacion, Me.TipoRango, Me.TipoRegla, Me.TransProdIDFondoCristal, Me.bPendienteEntrega) Then
                            refparoReglas.Add(oRegla)
                        End If
                        ' Si la primera promoción no acepta aplicacion en cascada
                        If bPrimeraPromocion Then
                            bPrimeraPromocion = False
                            If Not Me.PermitirCascada Then
                                ' No continuar con las demas promociones para este producto
                                Exit For
                            End If
                        End If
                    End If
                End If
            Next
        Next
        Dim oReglaProductosAcumulados As ReglaProductosAcumulados
        Dim o As IDictionaryEnumerator = refparoReglasProdAcumulados.GetEnumerator
        While o.MoveNext
            oReglaProductosAcumulados = o.Value
            If oReglaProductosAcumulados.TipoAplicacion = ServicesCentral.TiposAplicacionPromociones.Producto Then
                oReglaProductosAcumulados.ObtenerAplicarRango(refparoTransProd, DataViewPromRegla, 0, String.Empty, True)
            End If
        End While
        htPromociones = Nothing
        DataViewProm.Dispose()
        DataViewEsqProm.Dispose()
        DataViewPromProd.Dispose()
        DataViewPromRegla.Dispose()
        Return (refparoReglas.Count <> 0 Or refparoReglasProdAcumulados.Count <> 0)
    End Function

    Public Function RecalcularImpuestos(ByRef refparoTransProd As TransProd, ByVal parsListaProductos As String, ByRef refparoImpuesto As Impuesto, ByVal parsPrecioClave As String) As Boolean
        Try
            ' Recuperar los impuestos
            Dim sConsultaSQL As New System.Text.StringBuilder
            sConsultaSQL.Append("SELECT Subtotal,Cantidad, Impuesto, Total, TransProdDetalleID,TransProdDetalle.ProductoClave,TransProdDetalle.TipoUnidad,ProductoDetalle.Factor FROM TransProdDetalle ")
            sConsultaSQL.Append("inner join ProductoDetalle on ProductoDetalle.ProductoClave = TransProdDetalle.ProductoClave and ProductoDetalle.PRUTipoUnidad = TransProdDetalle.TipoUnidad and ProductoDetalle.ProductoDetClave = transProdDetalle.ProductoClave ")
            sConsultaSQL.Append("WHERE (TransProdDetalle.TransProdID = '" & refparoTransProd.TransProdId & "') AND (TransProdDetalle.ProductoClave IN (" & parsListaProductos & ")) ")
            sConsultaSQL.Append("ORDER BY TransProdDetalle.TransProdDetalleID")
            Dim DataTableImp As DataTable = oDBVen.RealizarConsultaSQL(sConsultaSQL.ToString, "TPDImpuesto")
            ' Si hay registros en el detalle de impuestos
            If DataTableImp.Rows.Count > 0 Then
                Dim nImpuestoImporte As Decimal
                Dim nSubTotal As Decimal
                Dim nTotal As Decimal
                Dim sProductoClave As String = String.Empty
                Dim sTransProdDetalleID As String = String.Empty
                Dim aImpuestos As New ArrayList
                Dim oListaPrecio As New ListaPrecios
                oListaPrecio.PrecioClave = parsPrecioClave
                ' Para cada detalle del producto cuyos impuestos habra de calcularse
                For Each refDataRow As DataRow In DataTableImp.Rows
                    ' Verificar si tiene Impuestos
                    sTransProdDetalleID = refDataRow("TransProdDetalleID")
                    If sProductoClave <> refDataRow("ProductoClave") Then
                        aImpuestos.Clear()
                        sProductoClave = refDataRow("ProductoClave")
                        refparoImpuesto.Buscar(sProductoClave, refparoTransProd.ClienteActual.TipoImpuesto, aImpuestos)
                    End If
                    ' Calcular el subtotal
                    nSubTotal = refDataRow("SubTotal")

                    If aImpuestos.Count > 0 Then
                        ' Calcular el nuevo importe del impuesto
                        nImpuestoImporte = refparoImpuesto.Calcular(aImpuestos, nSubTotal, refDataRow("Precio"))
                        ' Calcular el total
                        nTotal = nSubTotal + nImpuestoImporte
                        If refparoImpuesto.GuardarDetalle(refparoTransProd.TransProdId, sTransProdDetalleID, aImpuestos) Then
                            ' Actualizar el detalle
                            Dim sComandoSQL As New System.Text.StringBuilder
                            sComandoSQL.Append("UPDATE TransProdDetalle SET ")
                            sComandoSQL.Append("SubTotal=" & nSubTotal & ",")
                            sComandoSQL.Append("Impuesto=" & nImpuestoImporte & ",")
                            sComandoSQL.Append("Total=" & nTotal & ",")
                            sComandoSQL.Append("MFechaHora=" & UniFechaSQL(Now) & ",MUsuarioID='" & oVendedor.UsuarioId & "',Enviado=0 ")
                            sComandoSQL.Append("WHERE TransProdID='" & refparoTransProd.TransProdId & "' AND TransProdDetalleID='" & sTransProdDetalleID & "'")
                            oDBVen.EjecutarComandoSQL(sComandoSQL.ToString)
                        End If
                    Else
                        Dim sComandoSQL As New System.Text.StringBuilder
                        sComandoSQL.Append("UPDATE TransProdDetalle SET ")
                        sComandoSQL.Append("Total=" & nSubTotal & ",")
                        sComandoSQL.Append("MFechaHora=" & UniFechaSQL(Now) & ",MUsuarioID='" & oVendedor.UsuarioId & "',Enviado=0 ")
                        sComandoSQL.Append("WHERE TransProdID='" & refparoTransProd.TransProdId & "' AND TransProdDetalleID='" & sTransProdDetalleID & "'")
                        oDBVen.EjecutarComandoSQL(sComandoSQL.ToString)
                    End If
                Next
                Dim DataTableRes As DataTable = oDBVen.RealizarConsultaSQL(sConsultaSQL.ToString, "TPDImpuesto")
                Return True
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        Return False
    End Function

    Public Function EliminarDetalle(ByVal parsTransProdId As String) As Boolean
        Try
            ' Borrar las promociones anteriores
            oDBVen.EjecutarComandoSQL("DELETE FROM TrpPrp WHERE TransProdId='" & parsTransProdId & "'")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Function

    'Public Function GuardarDetalle(ByVal parsTransProdId As String, ByRef refparaRegla As ArrayList) As Boolean
    '    Try
    '        For Each refRegla As Regla In refparaRegla
    '            ' Obtener el proximo ID de TPDimpuesto
    '            Dim sComandoSQL As New System.Text.StringBuilder
    '            sComandoSQL.Append("INSERT INTO TrpPrp (TransProdID, PromocionClave, ProductoClave, MFechaHora, MUsuarioID) VALUES (")
    '            With refRegla
    '                sComandoSQL.Append("'" & parsTransProdId & "',")
    '                sComandoSQL.Append("'" & .PromocionClave & "',")
    '                sComandoSQL.Append("'" & .ProductoClave & "',")
    '                sComandoSQL.Append(UniFechaSQL(Now) & ",")
    '                sComandoSQL.Append("'" & oVendedor.UsuarioId & "')")
    '            End With
    '            oDBVen.EjecutarComandoSQL(sComandoSQL.ToString)
    '        Next

    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical)
    '    End Try
    'End Function

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
