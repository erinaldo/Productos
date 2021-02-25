Imports System.Data
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Xml
Imports System
Imports Microsoft.VisualBasic

Public Class Imprimir

    Public Generic As Boolean = False

    Public Enum Alinear
        Centrado = 3
        Derecha = 2
        Izquierda = 1
    End Enum

    Public Enum FontEstilo
        Negrita = 1
        Regular = 0
    End Enum

  
    Public Property DelimitadorChar() As String
        Get
            Return Me.delimitador
        End Get
        Set(ByVal Value As String)
            If (String.Compare(Value, Me.delimitador, False) <> 0) Then
                Me.delimitador = Value
            End If
        End Set
    End Property

    Public Property ImgHeader() As Image
        Get
            Return Me.headerImage
        End Get
        Set(ByVal Value As Image)
            If (Not Me.headerImage Is Value) Then
                Me.headerImage = Value
            End If
        End Set
    End Property

    Public Property LetraName() As String
        Get
            Return Me.fontName
        End Get
        Set(ByVal Value As String)
            If (String.Compare(Value, Me.fontName, False) <> 0) Then
                Me.fontName = Value
            End If
        End Set
    End Property

    Public Property LetraSize() As Integer
        Get
            Return Me.fontSize
        End Get
        Set(ByVal Value As Integer)
            If (Value <> Me.fontSize) Then
                Me.fontSize = Value
            End If
        End Set
    End Property

    Public Property MaxCharLine() As Integer
        Get
            Return Me.maxChar
        End Get
        Set(ByVal Value As Integer)
            If (Value <> Me.maxChar) Then
                Me.maxChar = Value
            End If
        End Set
    End Property

    Private count As Integer
    Private delimitador As String
    Private fontName As String
    Private fontSize As Integer
    Private footerLines As ArrayList
    Private gfx As Graphics
    Private headerImage As Image
    Private headerLines As ArrayList
    Private imageHeight As Integer
    Private items As ArrayList
    Private leftMargin As Single
    Private line As String
    Private maxChar As Integer
    Private myBrush As SolidBrush
    Private printFont As Font
    Private Style As FontEstilo
    Private subHeaderBloqLines As ArrayList
    Private subHeaderLines As ArrayList
    Private topMargin As Single
    Private totales As ArrayList


    Public Sub New()
        Me.headerLines = New ArrayList
        Me.subHeaderLines = New ArrayList
        Me.subHeaderBloqLines = New ArrayList
        Me.items = New ArrayList
        Me.totales = New ArrayList
        Me.footerLines = New ArrayList
        Me.headerImage = Nothing
        Me.count = 0
        Me.maxChar = 35
        Me.imageHeight = 0
        Me.leftMargin = 0
        Me.topMargin = 3
        Me.fontName = "Courier New"
        Me.fontSize = 9
        Me.printFont = Nothing
        Me.myBrush = New SolidBrush(Color.Black)
        Me.gfx = Nothing
        Me.line = Nothing
        Me.delimitador = ChrW(165)
    End Sub

    Public Sub AddFooterLine(ByVal line As String, ByVal style As Integer, ByVal alinea As Integer)
        Me.footerLines.Add(line & Me.delimitador & CStr(style) & Me.delimitador & CStr(alinea))
    End Sub

    Public Sub AddHeaderLine(ByVal line As String, ByVal style As FontEstilo, ByVal alinear As Alinear)
        Me.headerLines.Add(line & Me.delimitador & CStr(style) & Me.delimitador & CStr(alinear))
    End Sub

    Public Sub AddHeaderDotLine(ByVal style As FontEstilo, ByVal alinear As Alinear)
        Me.headerLines.Add(Me.DottedLine & Me.delimitador & CStr(style) & Me.delimitador & CStr(alinear))
    End Sub

    Public Sub AddHeaderLineDetalle(ByVal Concepto As String, ByVal Importe As Double, ByVal style As FontEstilo, ByVal alinear As Alinear)

        Dim str2 As String
        Dim item As String
        Dim str As String = ""
        If (Me.maxChar > &H20) Then
            str = Me.Espacio((Me.maxChar - &H20))
        Else
            str = "  "
        End If

        If maxChar < &H20 Then
            str2 = Me.FormateaCadena(alinear.Derecha, Strings.Format(TruncateToDecimal(Importe, 2).ToString, "Currency"), 12)
            item = String.Concat(New String() {Me.FormateaCadena(alinear.Izquierda, Concepto, 15), "", str2})
        Else
            str2 = Me.FormateaCadena(alinear.Derecha, Strings.Format(TruncateToDecimal(Importe, 2).ToString, "Currency"), 12)
            item = String.Concat(New String() {Me.FormateaCadena(alinear.Izquierda, Concepto, 18), str, str2})
        End If

        Me.headerLines.Add(item & Me.delimitador & CStr(style) & Me.delimitador & CStr(alinear))
    End Sub

    Public Sub AddItem(ByVal DVEClave As String, ByVal GTIN As String, ByVal Nombre As String, ByVal Cantidad As Double, ByVal Precio As Double, ByVal Descuento As Double)
        Dim str As String
        Dim str4 As String
        Dim str7 As String
        Dim str8 As String
        Me.items.Add(Me.FormateaCadena(Alinear.Izquierda, (GTIN & " " & Nombre), Me.maxChar))
        If (Descuento = 0) Then
            If maxChar < &H20 Then
                str = Me.FormateaCadena(Alinear.Derecha, TruncateToDecimal(Cantidad, 2).ToString, 5)
                str7 = Me.FormateaCadena(Alinear.Derecha, Strings.Format(TruncateToDecimal(Precio, 2).ToString, "Currency"), 8)
                str8 = Me.FormateaCadena(Alinear.Derecha, Strings.Format(TruncateToDecimal((Precio * Cantidad), 2).ToString, "Currency"), 11)
            Else
                str = Me.FormateaCadena(Alinear.Derecha, TruncateToDecimal(Cantidad, 2).ToString, 7)
                str7 = Me.FormateaCadena(Alinear.Derecha, Strings.Format(TruncateToDecimal(Precio, 2).ToString, "Currency"), 10)
                str8 = Me.FormateaCadena(Alinear.Derecha, Strings.Format(TruncateToDecimal((Precio * Cantidad), 2).ToString, "Currency"), 12)
            End If
            str4 = ""

            If (Me.maxChar > &H20) Then
                str4 = Me.Espacio((Me.maxChar - &H20))
            End If

            Me.items.Add(String.Concat(New String() {str, " @ ", str7, str4, str8}))
        Else
            Dim str5 As String
            Dim str6 As String

            If (Descuento > 0) Then
                str = Me.FormateaCadena(Alinear.Derecha, TruncateToDecimal(Cantidad, 2).ToString, 7)
                str7 = Me.FormateaCadena(Alinear.Derecha, Strings.Format(TruncateToDecimal(Precio, 2).ToString, "Currency"), 10)

                Me.items.Add((str & " @ " & str7))

                Dim PorcDesc As Decimal = ModPOS.Redondear((Descuento / Precio) * 100, 2)

                If maxChar < &H20 Then
                    str6 = Me.FormateaCadena(Alinear.Izquierda, (PorcDesc.ToString & "%"), 5)
                    str5 = Me.FormateaCadena(Alinear.Derecha, Strings.Format(TruncateToDecimal(Descuento, 2).ToString, "Currency"), 8)
                    str8 = Me.FormateaCadena(Alinear.Derecha, Strings.Format(TruncateToDecimal(((Precio - Descuento) * Cantidad), 2).ToString, "Currency"), 10)
                Else
                    str6 = Me.FormateaCadena(Alinear.Izquierda, (PorcDesc.ToString & "%"), 6)
                    str5 = Me.FormateaCadena(Alinear.Derecha, Strings.Format(TruncateToDecimal(Descuento, 2).ToString, "Currency"), 10)
                    str8 = Me.FormateaCadena(Alinear.Derecha, Strings.Format(TruncateToDecimal(((Precio - Descuento) * Cantidad), 2).ToString, "Currency"), 12)
                End If

                str4 = ""

                If (Me.maxChar > &H20) Then
                    str4 = Me.Espacio((Me.maxChar - &H20))
                End If

                Me.items.Add(String.Concat(New String() {str6, "OFER", str5, str4, str8}))
            
                'Dim dtDescuento As DataTable = ModPOS.SiExisteRecupera("sp_descuento_partida", "@DVEClave", DVEClave)
                'If Not dtDescuento Is Nothing Then
                '    Dim i As Integer = 0
                '    Dim dDescuento As Double = 0
                '    For i = 0 To dtDescuento.Rows.Count() - 1

                '        dDescuento += dtDescuento.Rows(i)("DescuentoImp") + dtDescuento.Rows(i)("ImpuestoDesc")
                '        If maxChar < &H20 Then
                '            str6 = Me.FormateaCadena(Alinear.Izquierda, (TruncateToDecimal((dtDescuento.Rows(i)("DescuentoPorc") * 100), 2).ToString & "%"), 5)
                '            str5 = Me.FormateaCadena(Alinear.Derecha, Strings.Format(TruncateToDecimal(dtDescuento.Rows(i)("DescuentoImp") + dtDescuento.Rows(i)("ImpuestoDesc"), 2).ToString, "Currency"), 8)
                '            str8 = Me.FormateaCadena(Alinear.Derecha, Strings.Format(TruncateToDecimal(((Precio - dDescuento) * Cantidad), 2).ToString, "Currency"), 10)
                '        Else
                '            str6 = Me.FormateaCadena(Alinear.Izquierda, (TruncateToDecimal((dtDescuento.Rows(i)("DescuentoPorc") * 100), 2).ToString & "%"), 6)
                '            str5 = Me.FormateaCadena(Alinear.Derecha, Strings.Format(TruncateToDecimal(dtDescuento.Rows(i)("DescuentoImp") + dtDescuento.Rows(i)("ImpuestoDesc"), 2).ToString, "Currency"), 10)
                '            str8 = Me.FormateaCadena(Alinear.Derecha, Strings.Format(TruncateToDecimal(((Precio - dDescuento) * Cantidad), 2).ToString, "Currency"), 12)
                '        End If

                '        str4 = ""

                '        If (Me.maxChar > &H20) Then
                '            str4 = Me.Espacio((Me.maxChar - &H20))
                '        End If

                '        If i = dtDescuento.Rows.Count() - 1 Then
                '            Me.items.Add(String.Concat(New String() {str6, "OFER", str5, str4, str8}))
                '        Else
                '            Me.items.Add(String.Concat(New String() {str6, "OFER", str5}))
                '        End If

                '    Next
                '    dtDescuento.Dispose()
                'End If

            End If
        End If
    End Sub

    Public Sub AddItemComanda(ByVal DCMClave As String, ByVal GTIN As String, ByVal Nombre As String, ByVal Cantidad As Double, ByVal Precio As Double, ByVal Descuento As Double)
        Dim str As String
        Dim str4 As String
        Dim str7 As String
        Dim str8 As String
        Me.items.Add(Me.FormateaCadena(Alinear.Izquierda, (GTIN & " " & Nombre), Me.maxChar))
        If (Descuento = 0) Then
            str = Me.FormateaCadena(Alinear.Derecha, TruncateToDecimal(Cantidad, 2).ToString, 7)
            str7 = Me.FormateaCadena(Alinear.Derecha, Strings.Format(TruncateToDecimal(Precio, 2).ToString, "Currency"), 10)
            str8 = Me.FormateaCadena(Alinear.Derecha, Strings.Format(TruncateToDecimal((Precio * Cantidad), 2).ToString, "Currency"), 12)
            str4 = ""
            If (Me.maxChar > &H20) Then
                str4 = Me.Espacio((Me.maxChar - &H20))
            End If
            Me.items.Add(String.Concat(New String() {str, " @ ", str7, str4, str8}))
        Else
            Dim str5 As String
            Dim str6 As String
            If (Descuento > 0) Then
                str = Me.FormateaCadena(Alinear.Derecha, TruncateToDecimal(Cantidad, 2).ToString, 7)
                str7 = Me.FormateaCadena(Alinear.Derecha, Strings.Format(TruncateToDecimal(Precio, 2).ToString, "Currency"), 10)

                Me.items.Add((str & " @ " & str7))

                Dim dtDescuento As DataTable = ModPOS.SiExisteRecupera("sp_descuento_comanda", "@DCMClave", DCMClave)
                If Not dtDescuento Is Nothing Then
                    Dim i As Integer = 0
                    Dim dDescuento As Double = 0
                    For i = 0 To dtDescuento.Rows.Count() - 1

                        dDescuento += dtDescuento.Rows(i)("DescuentoImp") + dtDescuento.Rows(i)("ImpuestoDesc")

                        str6 = Me.FormateaCadena(Alinear.Izquierda, (TruncateToDecimal((dtDescuento.Rows(i)("DescuentoPorc") * 100), 2).ToString & "%"), 6)
                        str5 = Me.FormateaCadena(Alinear.Derecha, Strings.Format(TruncateToDecimal(dtDescuento.Rows(i)("DescuentoImp") + dtDescuento.Rows(i)("ImpuestoDesc"), 2).ToString, "Currency"), 10)
                        str4 = ""
                        str8 = Me.FormateaCadena(Alinear.Derecha, Strings.Format(TruncateToDecimal(((Precio - dDescuento) * Cantidad), 2).ToString, "Currency"), 12)

                        If (Me.maxChar > &H20) Then
                            str4 = Me.Espacio((Me.maxChar - &H20))
                        End If

                        If i = dtDescuento.Rows.Count() - 1 Then
                            Me.items.Add(String.Concat(New String() {str6, "OFER", str5, str4, str8}))
                        Else
                            Me.items.Add(String.Concat(New String() {str6, "OFER", str5}))
                        End If

                    Next
                    dtDescuento.Dispose()
                End If

            End If
        End If
    End Sub

    Public Sub AddItem(ByVal Tipo As Integer, ByVal DescPor As Double, ByVal Descuento As Double)
        Dim str4 As String
        Dim str12 As String
        Dim str6 As String
        If (Descuento > 0) Then
            str6 = Me.FormateaCadena(Alinear.Izquierda, (TruncateToDecimal((DescPor * 100), 2).ToString & "%"), 6)
            str12 = Me.FormateaCadena(Alinear.Derecha, Strings.Format(TruncateToDecimal(Descuento, 2).ToString, "Currency"), 16)
            str4 = ""



            If (Me.maxChar > &H20) Then
                str4 = Me.Espacio((Me.maxChar - &H20))
            End If

            If maxChar < &H20 Then
                Select Case Tipo
                    Case Is = 1 'General
                        Me.items.Add(String.Concat(New String() {str6, "GEN. ", str4, str12}))
                    Case Is = 2 'Volumen
                        Me.items.Add(String.Concat(New String() {str6, "VOL. ", str4, str12}))
                    Case Is = 3 'Gerencial
                        Me.items.Add(String.Concat(New String() {str6, "GER. ", str4, str12}))
                End Select
            Else
                Select Case Tipo
                    Case Is = 1 'General
                        Me.items.Add(String.Concat(New String() {str6, "DESC. GEN.", str4, str12}))
                    Case Is = 2 'Volumen
                        Me.items.Add(String.Concat(New String() {str6, "DESC. VOL.", str4, str12}))
                    Case Is = 3 'Gerencial
                        Me.items.Add(String.Concat(New String() {str6, "DESC. GER.", str4, str12}))
                End Select
            End If
        End If
    End Sub

    Public Sub AddItemRecibo(ByVal TipoPago As String, ByVal Fecha As String, ByVal Importe As Double)
        TipoPago = Me.FormateaCadena(Alinear.Derecha, TipoPago, 8)
        Fecha = Me.FormateaCadena(Alinear.Derecha, Fecha, 10)
        Dim str2 As String = Me.FormateaCadena(Alinear.Derecha, Strings.Format(ModPOS.TruncateToDecimal(Importe, 2).ToString, "Currency"), 12)
        Dim str As String = ""
        If (Me.maxChar > &H20) Then
            str = Me.Espacio((Me.maxChar - &H20))
        End If
        Me.items.Add(String.Concat(New String() {TipoPago, "  ", Fecha, str, str2}))
    End Sub


    Public Sub AddHeaderItem(ByVal Cant As String, ByVal Denominacion As String, ByVal Importe As String, ByVal style As FontEstilo, ByVal alinear As Alinear)

        Dim str As String = ""
        If (Me.maxChar > &H20) Then
            str = Me.Espacio((Me.maxChar - &H20))
        Else
            str = "  "
        End If
        Dim item As String

        If maxChar < &H20 Then
            Cant = Me.FormateaCadena(alinear.Centrado, Cant, 6)
            Denominacion = Me.FormateaCadena(alinear.Derecha, Denominacion, 10)
            item = Me.FormateaCadena(alinear.Derecha, Importe, 11)
        Else
            Cant = Me.FormateaCadena(alinear.Centrado, Cant, 8)
            Denominacion = Me.FormateaCadena(alinear.Derecha, Denominacion, 12)
            item = Me.FormateaCadena(alinear.Derecha, Importe, 12)
        End If
        Me.headerLines.Add(Cant & Denominacion & item & Me.delimitador & CStr(style) & Me.delimitador & CStr(alinear))

    End Sub


    Public Sub AddItemTransferencia(ByVal GTIN As String, ByVal Nombre As String, ByVal Cantidad As Double, ByVal Costo As Double, ByVal Subtotal As Double)
        Dim str As String
        Dim str4 As String
        Dim str7 As String
        Dim str8 As String

        Me.items.Add(Me.FormateaCadena(Alinear.Izquierda, (GTIN & " " & Nombre), Me.maxChar))
        '  Me.items.Add(Me.FormateaCadena(Alinear.Izquierda, (CStr(Cantidad) & " " & Unidad & " " & GTIN), Me.maxChar))
        str = Me.FormateaCadena(Alinear.Derecha, TruncateToDecimal(Cantidad, 2).ToString, 7)
        str7 = Me.FormateaCadena(Alinear.Derecha, Strings.Format(TruncateToDecimal(Costo, 2).ToString, "Currency"), 10)
        str8 = Me.FormateaCadena(Alinear.Derecha, Strings.Format(TruncateToDecimal((Subtotal), 2).ToString, "Currency"), 12)
        str4 = ""

        If (Me.maxChar > &H20) Then
            str4 = Me.Espacio((Me.maxChar - &H20))
        End If
        Me.items.Add(String.Concat(New String() {str, " @ ", str7, str4, str8}))

    End Sub


    Public Sub AddItemTransferencia(ByVal GTIN As String, ByVal Nombre As String, ByVal Unidad As String, ByVal Cantidad As Double)
        Me.items.Add(Me.FormateaCadena(Alinear.Izquierda, (CStr(Cantidad) & " " & Unidad & " " & GTIN), Me.maxChar))
        Me.items.Add(Me.FormateaCadena(Alinear.Izquierda, Nombre, Me.maxChar))

    End Sub

    Public Sub AddItemNota(ByVal Nota As String, ByVal Separador As String)
        Me.items.Add(Me.FormateaCadena(Alinear.Izquierda, Nota, Me.maxChar))
        Me.items.Add(Me.FormateaCadena(Alinear.Izquierda, Separador, Me.maxChar))

    End Sub

    Public Sub AddSubHeaderBloqLine(ByVal line As String, ByVal style As FontEstilo, ByVal alinea As Alinear)
        Me.subHeaderBloqLines.Add(line & Me.delimitador & CStr(style) & Me.delimitador & CStr(alinea))
    End Sub

    Public Sub AddSubHeaderLine(ByVal line As String, ByVal style As FontEstilo, ByVal alinea As Alinear)
        Me.subHeaderLines.Add(line & Me.delimitador & CStr(style) & Me.delimitador & CStr(alinea))
    End Sub

    Public Sub AddTotal(ByVal Total As Double, ByVal Puntos As Double, ByVal Ahorro As Double, ByVal Articulos As Double, ByVal Recibido As Double, ByVal Cambio As Double, ByVal EstiloTotal As FontEstilo)
        Dim str6 As String = Me.FormateaCadena(Alinear.Derecha, Strings.Format(TruncateToDecimal(Total, 2).ToString, "Currency"), 12)
        Dim str4 As String = Me.FormateaCadena(Alinear.Derecha, TruncateToDecimal(Puntos, 2).ToString("#,##0.00"), 12)
        Dim str As String = Me.FormateaCadena(Alinear.Derecha, Strings.Format(TruncateToDecimal(Ahorro, 2).ToString, "Currency"), 12)
        Dim str2 As String = Me.FormateaCadena(Alinear.Derecha, TruncateToDecimal(Articulos, 2).ToString, 12)
        Me.totales.Add(Me.FormateaCadena(Alinear.Derecha, ("TOTAL" & str6), (Me.maxChar - 11)) & Me.delimitador & CStr(EstiloTotal) & Me.delimitador & CStr(fontSize + 4))
        Me.totales.Add(Me.FormateaCadena(Alinear.Derecha, ("  AHORRO" & str), Me.maxChar) & Me.delimitador & CStr(Me.Style) & Me.delimitador & CStr(Me.fontSize))
        Me.totales.Add(Me.FormateaCadena(Alinear.Derecha, ("  PUNTOS" & str4), Me.maxChar) & Me.delimitador & CStr(Me.Style) & Me.delimitador & CStr(Me.fontSize))
        Me.totales.Add(Me.FormateaCadena(Alinear.Derecha, (" # ARTS." & str2), Me.maxChar) & Me.delimitador & CStr(Me.Style) & Me.delimitador & CStr(Me.fontSize))
        If (Recibido > 0) Then
            Dim str5 As String = Me.FormateaCadena(Alinear.Derecha, Strings.Format(TruncateToDecimal(Recibido, 2).ToString, "Currency"), 12)
            Dim str3 As String = Me.FormateaCadena(Alinear.Derecha, Strings.Format(TruncateToDecimal(Cambio, 2).ToString, "Currency"), 12)
            Me.totales.Add(Me.FormateaCadena(Alinear.Derecha, ("RECIBIDO" & str5), Me.maxChar) & Me.delimitador & CStr(Me.Style) & Me.delimitador & CStr(Me.fontSize))
            Me.totales.Add(Me.FormateaCadena(Alinear.Derecha, ("  CAMBIO" & str3), Me.maxChar) & Me.delimitador & CStr(Me.Style) & Me.delimitador & CStr(Me.fontSize))
        End If
    End Sub

    Public Sub AddTotal(ByVal Redondeo As Double, ByVal Total As Double, ByVal Puntos As Double, ByVal Ahorro As Double, ByVal Articulos As Double, ByVal Recibido As Double, ByVal Cambio As Double, ByVal Saldo As Double, ByVal EstiloTotal As FontEstilo)
        Dim str7 As String = Me.FormateaCadena(Alinear.Derecha, Strings.Format(TruncateToDecimal(Total, 2).ToString, "Currency"), 12)
        Dim str4 As String = Me.FormateaCadena(Alinear.Derecha, TruncateToDecimal(Puntos, 2).ToString("#,##0.00"), 12)
        Dim str As String = Me.FormateaCadena(Alinear.Derecha, Strings.Format(TruncateToDecimal(Ahorro, 2).ToString, "Currency"), 12)
        Dim str2 As String = Me.FormateaCadena(Alinear.Derecha, TruncateToDecimal(Articulos, 2).ToString, 12)
        Dim str8 As String = Me.FormateaCadena(Alinear.Derecha, Strings.Format(TruncateToDecimal(Saldo, 2).ToString, "Currency"), 12)

        If (Redondeo > 0) Then
            Dim str6 As String = Me.FormateaCadena(Alinear.Derecha, Strings.Format(TruncateToDecimal(Redondeo, 2).ToString, "Currency"), 12)
            Me.totales.Add(Me.FormateaCadena(Alinear.Derecha, ("REDONDEO" & str6), Me.maxChar) & Me.delimitador & CStr(Me.Style) & Me.delimitador & CStr(Me.fontSize))
        End If

        If Ahorro > 0 Then
            Me.totales.Add(Me.FormateaCadena(Alinear.Derecha, ("  AHORRO" & str), Me.maxChar) & Me.delimitador & CStr(Me.Style) & Me.delimitador & CStr(Me.fontSize))
        End If

        If Puntos > 0 Then
            Me.totales.Add(Me.FormateaCadena(Alinear.Derecha, ("  PUNTOS" & str4), Me.maxChar) & Me.delimitador & CStr(Me.Style) & Me.delimitador & CStr(Me.fontSize))
        End If

        Me.totales.Add(Me.FormateaCadena(Alinear.Derecha, (" # ARTS." & str2), Me.maxChar) & Me.delimitador & CStr(Me.Style) & Me.delimitador & CStr(Me.fontSize))
        Me.totales.Add(Me.FormateaCadena(Alinear.Derecha, ("TOTAL" & str7), (Me.maxChar)) & Me.delimitador & CStr(EstiloTotal) & Me.delimitador & CStr(Me.fontSize)) 'maxChar - 11  y fontSize +4

        If (Recibido > 0) Then
            Dim str5 As String = Me.FormateaCadena(Alinear.Derecha, Strings.Format(TruncateToDecimal(Recibido, 2).ToString, "Currency"), 12)
            Dim str3 As String = Me.FormateaCadena(Alinear.Derecha, Strings.Format(TruncateToDecimal(Cambio, 2).ToString, "Currency"), 12)
            Me.totales.Add(Me.FormateaCadena(Alinear.Derecha, ("RECIBIDO" & str5), Me.maxChar) & Me.delimitador & CStr(Me.Style) & Me.delimitador & CStr(Me.fontSize))
            Me.totales.Add(Me.FormateaCadena(Alinear.Derecha, ("  CAMBIO" & str3), Me.maxChar) & Me.delimitador & CStr(Me.Style) & Me.delimitador & CStr(Me.fontSize))
            Me.totales.Add(Me.FormateaCadena(Alinear.Derecha, ("   SALDO" & str8), Me.maxChar) & Me.delimitador & CStr(Me.Style) & Me.delimitador & CStr(Me.fontSize))
        End If
    End Sub


    Public Sub AddMetodoPago(ByVal Tipo As String, ByVal Referencia As String, ByVal Monto As String, ByVal linea As Integer)
        If linea = 0 Then
            Me.totales.Add(Me.FormateaCadena(Alinear.Izquierda, ("METODOS DE PAGO: "), Me.maxChar) & Me.delimitador & CStr(Me.Style) & Me.delimitador & CStr(Me.fontSize))
        End If

        Dim str3 As String = ""
        Dim str1 As String
        Dim str2 As String

        If (Me.maxChar > &H20) Then
            str3 = Me.Espacio((Me.maxChar - &H20))
        End If


        If maxChar < &H20 Then
            str1 = Me.FormateaCadena(Alinear.Izquierda, Tipo.ToUpper & IIf(Referencia <> "", " " & Referencia, ""), 17)
            str2 = Me.FormateaCadena(Alinear.Derecha, Monto, 10)

        Else
            str1 = Me.FormateaCadena(Alinear.Izquierda, Tipo.ToUpper & IIf(Referencia <> "", " " & Referencia, ""), 20)
            str2 = Me.FormateaCadena(Alinear.Derecha, Monto, 12)
        End If


        Me.totales.Add(Me.FormateaCadena(Alinear.Derecha, str1 & str3 & str2, Me.maxChar) & Me.delimitador & CStr(Me.Style) & Me.delimitador & CStr(Me.fontSize))
    End Sub


    Public Sub AddTotalRecibo(ByVal Total As Double, ByVal Recibido As Double, ByVal Cambio As Double, ByVal EstiloTotal As FontEstilo)
        Dim str6 As String = Me.FormateaCadena(Alinear.Derecha, Strings.Format(TruncateToDecimal(Total, 2).ToString, "Currency"), 12)
        Me.totales.Add(Me.FormateaCadena(Alinear.Derecha, ("TOTAL" & str6), (Me.maxChar - 11)) & Me.delimitador & CStr(EstiloTotal) & Me.delimitador & CStr(Me.fontSize + 4))
        If (Recibido > 0) Then
            Dim str5 As String = Me.FormateaCadena(Alinear.Derecha, Strings.Format(TruncateToDecimal(Recibido, 2).ToString, "Currency"), 12)
            Dim str3 As String = Me.FormateaCadena(Alinear.Derecha, Strings.Format(TruncateToDecimal(Cambio, 2).ToString, "Currency"), 12)
            Me.totales.Add(Me.FormateaCadena(Alinear.Derecha, ("RECIBIDO" & str5), Me.maxChar) & Me.delimitador & CStr(Me.Style) & Me.delimitador & CStr(Me.fontSize))
            Me.totales.Add(Me.FormateaCadena(Alinear.Derecha, ("  CAMBIO" & str3), Me.maxChar) & Me.delimitador & CStr(Me.Style) & Me.delimitador & CStr(Me.fontSize))
        End If
    End Sub

    Public Sub AddTotalTicket(ByVal Total As Double, ByVal EstiloTotal As FontEstilo)
        Dim str6 As String = Me.FormateaCadena(Alinear.Derecha, Strings.Format(TruncateToDecimal(Total, 2).ToString, "Currency"), 12)
        Me.totales.Add(Me.FormateaCadena(Alinear.Derecha, ("TOTAL" & str6), (Me.maxChar - 11)) & Me.delimitador & CStr(EstiloTotal) & Me.delimitador & CStr(Me.fontSize + 4))
    End Sub

    Public Sub AddTotalDevolucion(ByVal Total As Double, ByVal Devolucion As Double, ByVal EstiloTotal As FontEstilo)
        Dim str6 As String = Me.FormateaCadena(Alinear.Derecha, Strings.Format(TruncateToDecimal(Total, 2).ToString, "Currency"), 12)
        Me.totales.Add(Me.FormateaCadena(Alinear.Derecha, ("TOTAL" & str6), (Me.maxChar - 11)) & Me.delimitador & CStr(EstiloTotal) & Me.delimitador & CStr(Me.fontSize + 4))
        If (Devolucion >= 0) Then
            Dim str5 As String = Me.FormateaCadena(Alinear.Derecha, Strings.Format(TruncateToDecimal(Devolucion, 2).ToString, "Currency"), 12)
            Me.totales.Add(Me.FormateaCadena(Alinear.Derecha, (" "), Me.maxChar) & Me.delimitador & CStr(Me.Style) & Me.delimitador & CStr(Me.fontSize))
            Me.totales.Add(Me.FormateaCadena(Alinear.Derecha, ("IMP. DEVOLUCION" & str5), Me.maxChar) & Me.delimitador & CStr(Me.Style) & Me.delimitador & CStr(Me.fontSize))
        End If
        Me.totales.Add(Me.FormateaCadena(Alinear.Derecha, (" "), Me.maxChar) & Me.delimitador & CStr(Me.Style) & Me.delimitador & CStr(Me.fontSize))
        Me.totales.Add(Me.FormateaCadena(Alinear.Derecha, (" "), Me.maxChar) & Me.delimitador & CStr(Me.Style) & Me.delimitador & CStr(Me.fontSize))
        Me.totales.Add(Me.FormateaCadena(Alinear.Centrado, ("_______________________"), Me.maxChar) & Me.delimitador & CStr(Me.Style) & Me.delimitador & CStr(Me.fontSize))
        Me.totales.Add(Me.FormateaCadena(Alinear.Centrado, ("FIRMA"), Me.maxChar) & Me.delimitador & CStr(Me.Style) & Me.delimitador & CStr(Me.fontSize))
    End Sub

    Private Function AlinearCentrado(ByVal [Text] As String, ByVal length As Integer) As String
        Dim str As String = ""
        Dim num3 As Integer = [Text].Length
        If (num3 < length) Then
            Dim str2 As String = ""
            Dim num2 As Integer = CInt(Math.Round(CDbl((CDbl((length - [Text].Length)) / 2))))
            num2 = Convert.ToInt32(Decimal.Round(New Decimal(num2), 0))
            str2 = Me.Espacio(num2)
            Return (str2 & [Text] & str2)
        End If
        If (num3 > length) Then
            Return [Text].Substring(0, length)
        End If
        If (num3 = length) Then
            Return [Text]
        End If
        Return str
    End Function

    Private Function AlinearDerecha(ByVal [Text] As String, ByVal length As Integer) As String
        Dim str As String = ""
        Dim num2 As Integer = [Text].Length
        If (num2 < length) Then
            Dim n As Integer = (length - [Text].Length)
            Return (Me.Espacio(n) & [Text])
        End If
        If (num2 > length) Then
            Return [Text].Substring(0, length)
        End If
        If (num2 = length) Then
            Return [Text]
        End If
        Return str
    End Function

    Private Function AlinearIzquierda(ByVal [Text] As String, ByVal length As Integer) As String
        Dim str As String = ""
        Dim num2 As Integer = [Text].Length
        If (num2 < length) Then
            Dim str2 As String = ""
            Dim n As Integer = (length - [Text].Length)
            str2 = Me.Espacio(n)
            Return ([Text] & str2)
        End If
        If (num2 > length) Then
            Return [Text].Substring(0, length)
        End If
        If (num2 = length) Then
            Return [Text]
        End If
        Return str
    End Function

    Private Function DottedLine() As String
        Dim str As String = ""
        Dim location As Integer = 0
        Do While (location < Me.maxChar)
            str = (str & "-")
            location += 1
        Loop
        Return str
    End Function

    Private Sub DrawEspacio()
        Me.line = ""
        Me.gfx.DrawString(Me.line, Me.printFont, Me.myBrush, Me.leftMargin, Me.YPosition, New StringFormat)
        Me.count += 1
    End Sub

    Private Sub DrawFooter()
        Dim enumerator As IEnumerator = Nothing
        Try
            enumerator = Me.footerLines.GetEnumerator
            Do While enumerator.MoveNext
                Dim font As Font = Nothing
                Dim strArray As String() = CStr(enumerator.Current).Split(CChar(Me.delimitador))
                Me.line = Me.FormateaCadena(DirectCast(CInt(strArray(2)), Alinear), strArray(0), Me.maxChar)
                Select Case CInt(strArray(1))
                    Case 0
                        font = New Font(Me.fontName, CSng(Me.fontSize), FontStyle.Regular)
                        Exit Select
                    Case 1
                        font = New Font(Me.fontName, CSng(Me.fontSize), FontStyle.Bold)
                        Exit Select
                End Select
                Me.gfx.DrawString(Me.line, font, Me.myBrush, Me.leftMargin, Me.YPosition, New StringFormat)
                If Generic Then
                    Me.DrawEspacio()
                End If
                Me.count += 1
            Loop
        Finally
            If TypeOf enumerator Is IDisposable Then
                DirectCast(enumerator, IDisposable).Dispose()
            End If
        End Try
    End Sub

    Private Sub DrawHeader()
        Dim enumerator As IEnumerator = Nothing
        Try
            enumerator = Me.headerLines.GetEnumerator
            Do While enumerator.MoveNext
                Dim font As Font = Nothing
                Dim strArray As String() = CStr(enumerator.Current).Split(CChar(Me.delimitador))
                Me.line = Me.FormateaCadena(DirectCast(CInt(strArray(2)), Alinear), strArray(0), Me.maxChar)
                Select Case CInt(strArray(1))
                    Case 0
                        font = New Font(Me.fontName, CSng(Me.fontSize), FontStyle.Regular)
                        Exit Select
                    Case 1
                        font = New Font(Me.fontName, CSng(Me.fontSize), FontStyle.Bold)
                        Exit Select
                End Select
                Me.gfx.DrawString(Me.line, font, Me.myBrush, Me.leftMargin, Me.YPosition, New StringFormat)
                If Generic Then
                    Me.DrawEspacio()
                End If
                Me.count += 1
            Loop
        Finally
            If TypeOf enumerator Is IDisposable Then
                DirectCast(enumerator, IDisposable).Dispose()
            End If
        End Try
        Me.DrawEspacio()
    End Sub

    Private Sub DrawImage()
        If (Not Me.headerImage Is Nothing) Then
            Try
                Dim point As New Point(CInt(Math.Round(CDbl(Me.leftMargin))), CInt(Math.Round(CDbl(Me.YPosition))))
                Me.gfx.DrawImage(Me.headerImage, point)
                Dim a As Double = ((CDbl(Me.headerImage.Height) / 58) * 15)
                Me.imageHeight = (CInt(Math.Round(Math.Round(a))) + 3)
            Catch exception1 As Exception
                MsgBox(exception1.Message, MsgBoxStyle.Information, "Error")
             End Try
        End If
    End Sub

    Private Sub DrawItems()
        Dim enumerator As IEnumerator = Nothing
        Try
            enumerator = Me.items.GetEnumerator
            Do While enumerator.MoveNext
                Dim str As String = CStr(enumerator.Current)
                Me.line = str
                Me.gfx.DrawString(Me.line, Me.printFont, Me.myBrush, Me.leftMargin, Me.YPosition, New StringFormat)
                If Generic Then
                    Me.DrawEspacio()
                End If
                Me.count += 1
            Loop
        Finally
            If TypeOf enumerator Is IDisposable Then
                DirectCast(enumerator, IDisposable).Dispose()
            End If
        End Try

            Me.line = Me.DottedLine

        If Me.items.Count > 0 Then
            Me.gfx.DrawString(Me.line, Me.printFont, Me.myBrush, Me.leftMargin, Me.YPosition, New StringFormat)
        End If

        If Generic Then
            Me.DrawEspacio()
        End If
        Me.count += 1
    End Sub

    Private Sub DrawSubHeader()
        Dim enumerator As IEnumerator = Nothing
        Try
            enumerator = Me.subHeaderLines.GetEnumerator
            Do While enumerator.MoveNext
                Dim font As Font = Nothing
                Dim strArray As String() = CStr(enumerator.Current).Split(CChar(Me.delimitador))
                Me.line = Me.FormateaCadena(DirectCast(CInt(strArray(2)), Alinear), strArray(0), Me.maxChar)
                Select Case CInt(strArray(1))
                    Case 0
                        font = New Font(Me.fontName, CSng(Me.fontSize), FontStyle.Regular)
                        Exit Select
                    Case 1
                        font = New Font(Me.fontName, CSng(Me.fontSize), FontStyle.Bold)
                        Exit Select
                End Select
                Me.gfx.DrawString(Me.line, font, Me.myBrush, Me.leftMargin, Me.YPosition, New StringFormat)
                If Generic Then
                    Me.DrawEspacio()
                End If
                Me.count += 1
                Me.line = Me.DottedLine
                Me.gfx.DrawString(Me.line, Me.printFont, Me.myBrush, Me.leftMargin, Me.YPosition, New StringFormat)
                If Generic Then
                    Me.DrawEspacio()
                End If
                Me.count += 1
            Loop
        Finally
            If TypeOf enumerator Is IDisposable Then
                DirectCast(enumerator, IDisposable).Dispose()
            End If
        End Try
    End Sub

    Private Sub DrawSubHeaderBloq()
        If (Me.subHeaderBloqLines.Count > 0) Then
            Dim enumerator As IEnumerator = Nothing
            Try
                enumerator = Me.subHeaderBloqLines.GetEnumerator
                Do While enumerator.MoveNext
                    Dim font As Font = Nothing
                    Dim strArray As String() = CStr(enumerator.Current).Split(CChar(Me.delimitador))
                    Me.line = Me.FormateaCadena(DirectCast(CInt(strArray(2)), Alinear), strArray(0), Me.maxChar)
                    Select Case CInt(strArray(1))
                        Case 0
                            font = New Font(Me.fontName, CSng(Me.fontSize), FontStyle.Regular)
                            Exit Select
                        Case 1
                            font = New Font(Me.fontName, CSng(Me.fontSize), FontStyle.Bold)
                            Exit Select
                    End Select
                    Me.gfx.DrawString(Me.line, font, Me.myBrush, Me.leftMargin, Me.YPosition, New StringFormat)
                    If Generic Then
                        Me.DrawEspacio()
                    End If
                    count += 1
                Loop
            Finally
                If TypeOf enumerator Is IDisposable Then
                    DirectCast(enumerator, IDisposable).Dispose()
                End If
            End Try
            Me.line = Me.DottedLine
            If Me.items.Count > 0 Then
                Me.gfx.DrawString(Me.line, Me.printFont, Me.myBrush, Me.leftMargin, Me.YPosition, New StringFormat)
            End If
            If Generic Then
                Me.DrawEspacio()
            End If
            count += 1
        End If
    End Sub

    Private Sub DrawTotales()
        Dim enumerator As IEnumerator = Nothing
        Try
            enumerator = Me.totales.GetEnumerator
            Do While enumerator.MoveNext
                Dim font As Font = Nothing
                Dim strArray As String() = CStr(enumerator.Current).Split(CChar(Me.delimitador))
                Me.line = strArray(0)
                Select Case CInt(strArray(1))
                    Case 0
                        font = New Font(Me.fontName, CSng(CInt(strArray(2))), FontStyle.Regular)
                        Exit Select
                    Case 1
                        font = New Font(Me.fontName, CSng(CInt(strArray(2))), FontStyle.Bold)
                        Exit Select
                End Select

                If Me.totales.Count > 0 Then
                    Me.gfx.DrawString(Me.line, font, Me.myBrush, Me.leftMargin, Me.YPosition, New StringFormat)
                End If

                If Generic Then
                    Me.DrawEspacio()
                End If
                Me.count += 1
            Loop
        Finally
            If TypeOf enumerator Is IDisposable Then
                DirectCast(enumerator, IDisposable).Dispose()
            End If
        End Try
        Me.DrawEspacio()
        Me.DrawEspacio()
    End Sub

    Private Function Espacio(ByVal N As Integer) As String
        Dim str2 As String = ""
        Dim i As Integer
        For i = 0 To N - 1
            str2 = (str2 & " ")
        Next i
        Return str2
    End Function

    Private Function FormateaCadena(ByVal Alineacion As Alinear, ByVal s As String, ByVal length As Integer) As String
        Dim resultado As String = ""
        Select Case Alineacion
            Case Alinear.Izquierda
                resultado = Me.AlinearIzquierda(s, length)
            Case Alinear.Derecha
                resultado = Me.AlinearDerecha(s, length)
            Case Alinear.Centrado
                resultado = Me.AlinearCentrado(s, length)
        End Select
        Return resultado
    End Function

    Public Function Letras(ByVal numero As String) As String
        '********Declara variables de tipo cadena************
        Dim palabras As String = ""
        Dim entero As String = ""
        Dim dec As String = ""
        Dim flag As String = ""
        '********Declara variables de tipo entero***********
        Dim num, x, y As Integer

        flag = "N"

        '**********Número Negativo***********
        If Mid(numero, 1, 1) = "-" Then
            numero = Mid(numero, 2, numero.ToString.Length - 1).ToString
            palabras = "menos "
        End If

        '**********Si tiene ceros a la izquierda*************
        For x = 1 To numero.ToString.Length
            If Mid(numero, 1, 1) = "0" Then
                numero = Trim(Mid(numero, 2, numero.ToString.Length).ToString)
                If Trim(numero.ToString.Length) = 0 Then palabras = ""
            Else
                Exit For
            End If
        Next

        '*********Dividir parte entera y decimal************
        For y = 1 To Len(numero)
            If Mid(numero, y, 1) = "." Then
                flag = "S"
            Else
                If flag = "N" Then
                    entero = entero + Mid(numero, y, 1)
                Else
                    dec = dec + Mid(numero, y, 1)
                End If
            End If
        Next y

        If Len(dec) = 1 Then dec = dec & "0"

        '**********proceso de conversión***********
        flag = "N"

        If Val(numero) <= 999999999 Then
            For y = Len(entero) To 1 Step -1
                num = Len(entero) - (y - 1)
                Select Case y
                    Case 3, 6, 9
                        '**********Asigna las palabras para las centenas***********
                        Select Case Mid(entero, num, 1)
                            Case "1"
                                If Mid(entero, num + 1, 1) = "0" And Mid(entero, num + 2, 1) = "0" Then
                                    palabras = palabras & "cien "
                                Else
                                    palabras = palabras & "ciento "
                                End If
                            Case "2"
                                palabras = palabras & "doscientos "
                            Case "3"
                                palabras = palabras & "trescientos "
                            Case "4"
                                palabras = palabras & "cuatrocientos "
                            Case "5"
                                palabras = palabras & "quinientos "
                            Case "6"
                                palabras = palabras & "seiscientos "
                            Case "7"
                                palabras = palabras & "setecientos "
                            Case "8"
                                palabras = palabras & "ochocientos "
                            Case "9"
                                palabras = palabras & "novecientos "
                        End Select
                    Case 2, 5, 8
                        '*********Asigna las palabras para las decenas************
                        Select Case Mid(entero, num, 1)
                            Case "1"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    flag = "S"
                                    palabras = palabras & "diez "
                                End If
                                If Mid(entero, num + 1, 1) = "1" Then
                                    flag = "S"
                                    palabras = palabras & "once "
                                End If
                                If Mid(entero, num + 1, 1) = "2" Then
                                    flag = "S"
                                    palabras = palabras & "doce "
                                End If
                                If Mid(entero, num + 1, 1) = "3" Then
                                    flag = "S"
                                    palabras = palabras & "trece "
                                End If
                                If Mid(entero, num + 1, 1) = "4" Then
                                    flag = "S"
                                    palabras = palabras & "catorce "
                                End If
                                If Mid(entero, num + 1, 1) = "5" Then
                                    flag = "S"
                                    palabras = palabras & "quince "
                                End If
                                If Mid(entero, num + 1, 1) > "5" Then
                                    flag = "N"
                                    palabras = palabras & "dieci"
                                End If
                            Case "2"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "veinte "
                                    flag = "S"
                                Else
                                    palabras = palabras & "veinti"
                                    flag = "N"
                                End If
                            Case "3"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "treinta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "treinta y "
                                    flag = "N"
                                End If
                            Case "4"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "cuarenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "cuarenta y "
                                    flag = "N"
                                End If
                            Case "5"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "cincuenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "cincuenta y "
                                    flag = "N"
                                End If
                            Case "6"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "sesenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "sesenta y "
                                    flag = "N"
                                End If
                            Case "7"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "setenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "setenta y "
                                    flag = "N"
                                End If
                            Case "8"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "ochenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "ochenta y "
                                    flag = "N"
                                End If
                            Case "9"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "noventa "
                                    flag = "S"
                                Else
                                    palabras = palabras & "noventa y "
                                    flag = "N"
                                End If
                        End Select
                    Case 1, 4, 7
                        '*********Asigna las palabras para las unidades*********
                        Select Case Mid(entero, num, 1)
                            Case "1"
                                If flag = "N" Then
                                    If y = 1 Then
                                        palabras = palabras & "uno "
                                    Else
                                        palabras = palabras & "un "
                                    End If
                                End If
                            Case "2"
                                If flag = "N" Then palabras = palabras & "dos "
                            Case "3"
                                If flag = "N" Then palabras = palabras & "tres "
                            Case "4"
                                If flag = "N" Then palabras = palabras & "cuatro "
                            Case "5"
                                If flag = "N" Then palabras = palabras & "cinco "
                            Case "6"
                                If flag = "N" Then palabras = palabras & "seis "
                            Case "7"
                                If flag = "N" Then palabras = palabras & "siete "
                            Case "8"
                                If flag = "N" Then palabras = palabras & "ocho "
                            Case "9"
                                If flag = "N" Then palabras = palabras & "nueve "
                        End Select
                End Select

                '***********Asigna la palabra mil***************
                If y = 4 Then
                    If Mid(entero, 6, 1) <> "0" Or Mid(entero, 5, 1) <> "0" Or Mid(entero, 4, 1) <> "0" Or _
                    (Mid(entero, 6, 1) = "0" And Mid(entero, 5, 1) = "0" And Mid(entero, 4, 1) = "0" And _
                    Len(entero) <= 6) Then palabras = palabras & "mil "
                End If

                '**********Asigna la palabra millón*************
                If y = 7 Then
                    If Len(entero) = 7 And Mid(entero, 1, 1) = "1" Then
                        palabras = palabras & "millón "
                    Else
                        palabras = palabras & "millones "
                    End If
                End If
            Next y

            '**********Une la parte entera y la parte decimal*************
            If dec <> "" Then
                Letras = palabras & "con " & dec & " CENTAVOS"
            Else
                Letras = palabras & " PESOS"
            End If
        Else
            Letras = ""
        End If
    End Function

    Private Sub pr_PrintPage(ByVal sender As Object, ByVal e As PrintPageEventArgs)
        e.Graphics.PageUnit = GraphicsUnit.Millimeter

        Dim numLinePage As Integer

        numLinePage = e.PageBounds.Height / printFont.GetHeight(e.Graphics)

        'e.HasMorePages = True
        Me.gfx = e.Graphics
        Me.DrawImage()
        Me.DrawHeader()
        Me.DrawSubHeader()
        Me.DrawSubHeaderBloq()
        Me.DrawItems()
        Me.DrawTotales()
        Me.DrawFooter()
        If (Not Me.headerImage Is Nothing) Then
            Me.headerImage.Dispose()
            Me.headerImage.Dispose()
        End If
        'e.HasMorePages = False
    End Sub

    Public Function PrinterExists(ByVal impresora As String) As Boolean
        Dim enumerator As IEnumerator = Nothing
        Try
            enumerator = PrinterSettings.InstalledPrinters.GetEnumerator
            Do While enumerator.MoveNext
                Dim sRight As String = CStr(enumerator.Current)
                If (String.Compare(impresora, sRight, False) = 0) Then
                    Return True
                End If
            Loop
        Finally
            If TypeOf enumerator Is IDisposable Then
                DirectCast(enumerator, IDisposable).Dispose()
            End If
        End Try
        Return False
    End Function

    Public Sub PrintTicket(ByVal impresora As String, ByVal LineasHoja As Integer, ByVal Lineas As Integer)
        If (Me.Style = FontEstilo.Regular) Then
            Me.printFont = New Font(Me.fontName, CSng(Me.fontSize), FontStyle.Regular)
        Else
            Me.printFont = New Font(Me.fontName, CSng(Me.fontSize), FontStyle.Bold)
        End If
        Dim document As New PrintDocument
        Dim TamañoPersonal As Printing.PaperSize

        If Lineas > LineasHoja Then
            TamañoPersonal = New Printing.PaperSize("Ticket", 850, (Lineas / LineasHoja) * 1100)
            document.DefaultPageSettings.PaperSize = TamañoPersonal
        Else
            TamañoPersonal = New Printing.PaperSize("Ticket", 850, 1100)
            document.DefaultPageSettings.PaperSize = TamañoPersonal
        End If

        document.PrinterSettings.PrinterName = impresora

        AddHandler document.PrintPage, New PrintPageEventHandler(AddressOf Me.pr_PrintPage)
        Try
            document.Print()

        Catch ex As Exception
            MessageBox.Show("La impresora que se encuentra configurada no fue encontrada o no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Function Redondear(ByVal dNumero As Double, ByVal iDecimales As Integer) As Decimal
        Return Decimal.Round(New Decimal(dNumero), iDecimales)
    End Function

    Private Function YPosition() As Single
        Return (Me.topMargin + ((Me.count * Me.printFont.GetHeight(Me.gfx)) + Me.imageHeight))
    End Function
















































































End Class
