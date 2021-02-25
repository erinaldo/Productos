Public Class TrpTpd
    Protected sTransProdID As String
    Protected sTransProdID1 As String
    Protected sTransProdDetalleID As String
    Protected nCantidad As Decimal
    Protected nPrecio As Decimal
    Protected nSubTotal As Decimal
    Protected nImpuesto As Decimal
    Protected nTotal As Decimal
    Public Property TransProdID() As String
        Get
            Return sTransProdID
        End Get
        Set(ByVal Value As String)
            sTransProdID = Value
        End Set
    End Property
    Public Property TransProdID1() As String
        Get
            Return sTransProdID1
        End Get
        Set(ByVal Value As String)
            sTransProdID1 = Value
        End Set
    End Property
    Public Property TransProdDetalleID() As String
        Get
            Return sTransProdDetalleID
        End Get
        Set(ByVal Value As String)
            sTransProdDetalleID = Value
        End Set
    End Property
    Public Property Cantidad() As Decimal
        Get
            Return Decimal.Round(nCantidad, 2)
        End Get
        Set(ByVal Value As Decimal)
            nCantidad = Value
        End Set
    End Property
    Public Property Precio() As Decimal
        Get
            Return Decimal.Round(nPrecio, 2)
        End Get
        Set(ByVal Value As Decimal)
            nPrecio = Value
        End Set
    End Property
    Public Property SubTotal() As Decimal
        Get
            Return Decimal.Round(nSubTotal, 2)
        End Get
        Set(ByVal Value As Decimal)
            nSubTotal = Value
        End Set
    End Property
    Public Property Impuesto() As Decimal
        Get
            Return RedondeoAritmetico(nImpuesto, 2)
        End Get
        Set(ByVal Value As Decimal)
            nImpuesto = Value
        End Set
    End Property
    Public Property Total() As Decimal
        Get
            Return Decimal.Round(nTotal, 2)
        End Get
        Set(ByVal Value As Decimal)
            nTotal = Value
        End Set
    End Property
    Public Function Crear() As Boolean
        Dim res As Boolean = False
        Dim sComandoSQL As New System.Text.StringBuilder()
        sComandoSQL.Append("INSERT INTO TrpTpd (TransProdID, TransProdID1, TransProdDetalleID, Cantidad, Precio, Subtotal, Impuesto, Total, MFechaHora, MUsuarioID) VALUES (")
        sComandoSQL.Append("'" & TransProdID & "',")
        sComandoSQL.Append("'" & TransProdID1 & "',")
        sComandoSQL.Append("'" & TransProdDetalleID & "',")
        sComandoSQL.Append(Cantidad & ",") ' Cantidad
        sComandoSQL.Append(Precio & ",") ' Precio
        sComandoSQL.Append(SubTotal & ",") ' Subtotal
        sComandoSQL.Append(Impuesto & ",") ' Impuesto
        sComandoSQL.Append(Total & ",")  ' Total
        sComandoSQL.Append(UniFechaSQL(Now) & ",")
        sComandoSQL.Append("'" & oVendedor.UsuarioId & "')")
        Try
            If sComandoSQL.ToString <> "" Then
                oDBVen.EjecutarComandoSQL(sComandoSQL.ToString)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "InsertarDetalle")
            res = False
        End Try
        Return res
    End Function
End Class
