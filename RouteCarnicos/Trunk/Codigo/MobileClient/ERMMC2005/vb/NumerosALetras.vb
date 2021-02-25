Namespace LUFERR

    Public Class NumerosALetras

        Const LetraPlural As String = "s"
        Const TextoMil As String = " mil"
        Const TextoMillones As String = " millones"

        Private blnEsMasculino As Boolean 'genero del numero en letra
        Private lNumeroDecimales As Long  'nº de decimales a pasar a letra
        Private sTextoAcomParteEntera As String  'texto para acompañar a la parte entera
        Private sTextoAcomParteDecimal As String  'texto para acompañar a la parte decimal
        Private sTextoAcomParteEnteraSin As String  'textos en singular
        Private sTextoAcomParteDecimalSin As String
        Private sTextoAcom As String  'solo se usa en EnteroAletrasRec al mirar al caso Especial nº1

        Private listaUnidades As String() 'continene los textos para las unidades
        Private listaDecenas As String() 'decenas
        Private listaCentenas As String()   'y centenas

        Public Sub New()
            Me.New(True, 2, String.Empty, String.Empty)
        End Sub

        Public Sub New(ByVal parbesMasculino As Boolean)
            Me.New(parbesMasculino, 2, String.Empty, String.Empty)
        End Sub

        Public Sub New(ByVal parbEsMasculino As Boolean, ByVal parlNumeroDecimales As Long)
            Me.New(parbEsMasculino, parlNumeroDecimales, String.Empty, String.Empty)
        End Sub

        Public Sub New(ByVal parbEsMasculino As Boolean, ByVal parlNumeroDecimales As Long, ByVal parsTextoAcomParteEntera As String, ByVal parsTextoAcomParteDecimal As String)
            Me.blnEsMasculino = parbEsMasculino

            NumeroDecimales = parlNumeroDecimales
            TextoAcomParteEntera = parsTextoAcomParteEntera
            textoAcomParteDecimal = parsTextoAcomParteDecimal

            listaUnidades = New String(29) {}
            listaDecenas = New String(9) {}
            listaCentenas = New String(9) {}
            Me.InicioListasTexto()
        End Sub
#Region "Propiedades de la clase"

        Public Property GeneroMasculino() As Boolean
            Get
                Return Me.blnEsMasculino
            End Get
            Set(ByVal value As Boolean)
                Me.blnEsMasculino = value
                InicioListasTexto() 'es necesario actualizar las listas segun el género
            End Set
        End Property

        Public Property NumeroDecimales() As Long
            Get
                Return Me.lNumeroDecimales
            End Get
            Set(ByVal value As Long)
                If (value < 0) Then
                    Me.lNumeroDecimales = 0
                Else
                    Me.lNumeroDecimales = value
                End If
            End Set
        End Property

        Public Property TextoAcomParteEntera() As String
            Get
                Return Me.sTextoAcomParteEntera
            End Get
            Set(ByVal value As String)
                If (value = String.Empty) Then
                    Me.sTextoAcomParteEntera = value
                    Me.sTextoAcomParteEnteraSin = value
                Else
                    Me.sTextoAcomParteEntera = " " + value
                    Me.sTextoAcomParteEnteraSin = Me.sTextoAcomParteEntera.Substring(0, Me.sTextoAcomParteEntera.Length - 1)
                End If
            End Set
        End Property
        Public Property TextoAcomParteDecimal() As String
            Get
                Return sTextoAcomParteDecimal
            End Get
            Set(ByVal value As String)
                If (Value = String.Empty) Then
                    sTextoAcomParteDecimal = Value
                    sTextoAcomParteDecimalSin = Value
                Else

                    sTextoAcomParteDecimal = " " + Value
                    sTextoAcomParteDecimalSin = sTextoAcomParteDecimal.Substring(0, sTextoAcomParteDecimal.Length - 1)
                End If
            End Set
        End Property
#End Region
        ' <summary>
        ' Inicializa las matrices de texto con los valores adecuados
        ' Ha de llamarse cada vez que cambia la propiedad GeneroMasculino
        ' </summary>
        Private Sub InicioListasTexto()
            Dim sLetraGenero As String
            If (blnEsMasculino) Then
                sLetraGenero = "o"
            Else
                sLetraGenero = "a"
            End If
            ' listaUnidades[0], listaDecenas[0 to 2] y listaCentenas[0] no se inicializan explicitamente
            listaUnidades(1) = "un" + sLetraGenero
            listaUnidades(2) = "dos"
            listaUnidades(3) = "tres"
            listaUnidades(4) = "cuatro"
            listaUnidades(5) = "cinco"
            listaUnidades(6) = "seis"
            listaUnidades(7) = "siete"
            listaUnidades(8) = "ocho"
            listaUnidades(9) = "nueve"
            listaUnidades(10) = "diez"
            listaUnidades(11) = "once"
            listaUnidades(12) = "doce"
            listaUnidades(13) = "trece"
            listaUnidades(14) = "catorce"
            listaUnidades(15) = "quince"
            listaUnidades(16) = "dieciseis"
            listaUnidades(17) = "diecisiete"
            listaUnidades(18) = "dieciocho"
            listaUnidades(19) = "diecinueve"
            listaUnidades(20) = "veinte"
            listaUnidades(21) = "veintiun" + sLetraGenero
            listaUnidades(22) = "veintidos"
            listaUnidades(23) = "veintitres"
            listaUnidades(24) = "veinticuatro"
            listaUnidades(25) = "veinticinco"
            listaUnidades(26) = "veintiseis"
            listaUnidades(27) = "veintisiete"
            listaUnidades(28) = "veintiocho"
            listaUnidades(29) = "veintinueve"

            listaDecenas(3) = "treinta"
            listaDecenas(4) = "cuarenta"
            listaDecenas(5) = "cincuenta"
            listaDecenas(6) = "sesenta"
            listaDecenas(7) = "setenta"
            listaDecenas(8) = "ochenta"
            listaDecenas(9) = "noventa"

            listaCentenas(1) = "ciento"
            listaCentenas(2) = "doscient" + sLetraGenero + LetraPlural
            listaCentenas(3) = "trescient" + sLetraGenero + LetraPlural
            listaCentenas(4) = "cuatrocient" + sLetraGenero + LetraPlural
            listaCentenas(5) = "quinient" + sLetraGenero + LetraPlural
            listaCentenas(6) = "seiscient" + sLetraGenero + LetraPlural
            listaCentenas(7) = "setecient" + sLetraGenero + LetraPlural
            listaCentenas(8) = "ochocient" + sLetraGenero + LetraPlural
            listaCentenas(9) = "novecient" + sLetraGenero + LetraPlural
        End Sub
        '/// <summary>
        '/// Convierte un número decimal a su equivalente en texto.
        '/// Este es el punto de inicio de la conversión a texto. Sobrecargado para decimal y double.
        '/// En caso de error genera una OverflowExcpetion
        '/// </summary>
        Public Function Aletras(ByVal pardNum As Decimal) As String
            Dim sTextoSigno As String = String.Empty, stextoParteEntera As String, stextoParteDecimal As String = String.Empty
            Dim parteDecimal As Decimal
            Dim parteEntera As Long
            Dim gruposDeTres As Long
            If (pardNum < 0) Then
                sTextoSigno = "menos "
                pardNum = pardNum * -1
            End If
            '//calculo la parte entera y la decimal, ha de hacerse con Decimal, con Double hay problemas de precisión ej: 31,31
            parteEntera = Math.Floor(pardNum)
            parteDecimal = pardNum - parteEntera ' //o parteDecimal=num-Math.Floor(num);

            gruposDeTres = CLng(Math.Ceiling(NumeroCifrasEntero(parteEntera) / 3.0))
            sTextoAcom = sTextoAcomParteEntera
            stextoParteEntera = EnteroAletrasRec(parteEntera, gruposDeTres)
            If ((parteDecimal <> 0) And (NumeroDecimales <> 0)) Then '//si hay decimales y se quieren decimales...
                Dim decimalEntero As Long = DecimalesAentero(parteDecimal, NumeroDecimales)
                gruposDeTres = CLng(Math.Ceiling(NumeroCifrasEntero(decimalEntero) / 3.0))
                sTextoAcom = sTextoAcomParteDecimal
                stextoParteDecimal = " con " + EnteroAletrasRec(decimalEntero, gruposDeTres) + IIf(decimalEntero = 1, sTextoAcomParteDecimalSin, TextoAcomParteDecimal)
            End If
            Return sTextoSigno + stextoParteEntera + IIf(parteEntera = 1, sTextoAcomParteEnteraSin, sTextoAcomParteEntera) + stextoParteDecimal
        End Function
        '/// <summary>
        '/// Convierte un número double a su equivalente en texto.
        '/// Este es el punto de inicio de la conversión a texto.
        '/// En caso de error genera una OverflowExcpetion
        '/// </summary>
        Public Function Aletras(ByVal pardNum As Double) As String
            Return Aletras(CDec(pardNum))
        End Function
        '/// <summary>
        '/// Convierte un número entero con un máximo de 18 dígitos en su equivalente en texto.
        '/// En caso de error genera una OverflowExcpetion
        '/// </summary>
        Private Function EnteroAletrasRec(ByVal parlNum As Long, ByVal parlGruposDeTres As Long) As String
            Dim parte1 As Long = 0, parte2 As Long = 0
            Dim textoParte1 As String = String.Empty, textoParte2 As String = String.Empty
            Dim enteroAletras As String

            Select Case parlGruposDeTres

                Case 1
                    enteroAletras = CentenasAletras(parlNum)
                    If ((blnEsMasculino) And (sTextoAcom <> String.Empty)) Then '//caso especial nº1
                        If (parlNum = 1) Then
                            enteroAletras = enteroAletras.Substring(0, enteroAletras.Length - 1)
                        Else
                            QuitarUltimaLetra(enteroAletras, parlNum)
                        End If
                    End If
                Case 2 '//miles, primero saco de num la parte2 con las cifras de los miles y parte1 el resto
                    parte2 = Fix(parlNum / 1000)
                    parte1 = parlNum - (parte2 * 1000)

                    If (parte2 = 1) Then
                        textoParte2 = "mil" ' //caso especial de mil, no se usa la constante TextoMil por los espacios
                    ElseIf (parte2 <> 0) Then
                        textoParte2 = CentenasAletras(parte2)
                        If (blnEsMasculino) Then QuitarUltimaLetra(textoParte2, parte2) '//	si es masculino-->veintiun mil '//Para los miles sólo quito la última letra si el genero es masculino ej 21000 femenino-->veintiuna mil
                        textoParte2 = textoParte2 + TextoMil
                    End If
                    If (parte1 <> 0) Then textoParte1 = IIf(textoParte2 = String.Empty, "", " ") + EnteroAletrasRec(parte1, 1)
                    enteroAletras = textoParte2 + textoParte1
                Case 3 '//millones. El resto de casos se podrian a grupar en uno solo, ya que solo cambian las cosntantes
                    parte2 = Fix(parlNum / 1000000) ' //para calcular la parte1 q son las cifrasde los millones y la parte2 el resto de cifras
                    parte1 = parlNum - (parte2 * 1000000)

                    If (parte2 = 1) Then
                        textoParte2 = "un millón" '//caso especial de millón, no se usa la constante TextoMillones por los espacios
                    ElseIf (parte2 <> 0) Then
                        textoParte2 = CentenasAletras(parte2)
                        QuitarUltimaLetra(textoParte2, parte2)
                        textoParte2 = textoParte2 + TextoMillones
                    End If
                    If (parte1 <> 0) Then textoParte1 = IIf(textoParte2 = String.Empty, "", " ") + EnteroAletrasRec(parte1, 2)
                    enteroAletras = textoParte2 + textoParte1
                Case 4 '//Miles de Millones
                    parte2 = Fix(parlNum / 1000000000)
                    parte1 = parlNum - (parte2 * 1000000000)

                    If (parte2 = 1) Then
                        textoParte2 = "mil"
                    ElseIf (parte2 <> 0) Then
                        textoParte2 = CentenasAletras(parte2)
                        If (blnEsMasculino) Then QuitarUltimaLetra(textoParte2, parte2)
                        textoParte2 = textoParte2 + TextoMil
                    End If
                    If (parte1 = 0) Then textoParte1 = IIf(textoParte2 = String.Empty, "", " ") + EnteroAletrasRec(parte1, 3)
                    enteroAletras = textoParte2 + textoParte1
                Case 5 '//billones
                    parte2 = Fix(parlNum / 1000000000000)
                    parte1 = parlNum - (parte2 * 1000000000000)

                    If (parte2 = 1) Then
                        textoParte2 = "un billón" '//caso especial de millón, no se usa la constante TextoMillones por los espacios
                    ElseIf (parte2 <> 0) Then
                        textoParte2 = CentenasAletras(parte2)
                        QuitarUltimaLetra(textoParte2, parte2)
                        textoParte2 = textoParte2 + " billones"
                    End If
                    If (parte1 <> 0) Then textoParte1 = IIf(textoParte2 = String.Empty, "", " ") + EnteroAletrasRec(parte1, 4)
                    enteroAletras = textoParte2 + textoParte1
                Case 6 '//miles de billones, luego vendria trillones, miles de trillones, cuatrillones, etc...
                    parte2 = Fix(parlNum / 1000000000000000)
                    parte1 = parlNum - (parte2 * 1000000000000000)

                    If (parte2 = 1) Then
                        textoParte2 = "mil" '//caso especial de mil
                    ElseIf (parte2 <> 0) Then
                        textoParte2 = CentenasAletras(parte2)
                        If (blnEsMasculino) Then QuitarUltimaLetra(textoParte2, parte2)
                        textoParte2 = textoParte2 + TextoMil
                    End If
                    If (parte1 <> 0) Then textoParte1 = IIf(textoParte2 = String.Empty, "", " ") + EnteroAletrasRec(parte1, 5)
                    enteroAletras = textoParte2 + textoParte1
                Case Else
                    Throw New OverflowException()
                    '//enteroAletras= "Error Nº Demasiado Grande";
                    '//break; //evito el warning de código inalcanzable
            End Select
            Return enteroAletras
        End Function
        '/// <summary>
        '/// Convierte un número entero en el rango 0..999 en su equivalente en texto.
        '/// No tiene en cuenta los textos de acompañamiento Ej 21-viuntiuno 
        '/// En caso de error genera una OverflowExcpetion
        '/// </summary>
        Private Function CentenasAletras(ByVal parlNum As Long) As String

            Dim centenas As Long = 0, decenas As Long = 0, unidades As Long = 0
            Dim sCentenasAletras As String = String.Empty

            If ((parlNum > 999) Or (parlNum < 0)) Then Throw New OverflowException()
            If (parlNum = 100) Then Return "cien" '//caso especial de 100
            If (parlNum = 0) Then Return "cero"

            centenas = Fix(parlNum / 100)
            decenas = (Fix(parlNum / 10)) - (10 * centenas)
            unidades = parlNum - (10 * decenas) - (100 * centenas)

            If decenas > 2 Then
                CentenasAletras = Me.listaDecenas(decenas)
                If unidades > 0 Then
                    centenasAletras = centenasAletras + " y " + Me.listaUnidades(unidades)
                End If
            Else
                centenasAletras = Me.listaUnidades(decenas * 10 + unidades)
            End If
            If centenas > 0 Then
                If centenasAletras = String.Empty Then
                    centenasAletras = Me.listaCentenas(centenas)
                Else
                    centenasAletras = Me.listaCentenas(centenas) + " " + centenasAletras
                End If
            End If

            Return CentenasAletras
        End Function
        '/// <summary>
        '/// cuenta el nº de cifras que tiene un número entero
        '/// </summary>
        Private Function NumeroCifrasEntero(ByVal parlNum As Long) As Long
            Dim cont As Long = 0
            While parlNum <> 0
                cont += 1
                parlNum = parlNum / 10
            End While
            If cont = 0 Then
                cont = 1
            End If
            Return cont
        End Function
        '/// <summary>
        '/// Pasa los decimales que se piden a la parte entera devolviendola. Sobrecargado para Double y Decimal.
        '/// </summary>
        Private Function DecimalesAentero(ByVal pardParteDecimal As Double, ByVal parlNumeroDecimales As Long) As Long
            Dim aux As Double = 10
            aux = Math.Pow(aux, parlNumeroDecimales)
            Dim numeroDecimal As Double = pardParteDecimal * aux
            Return CLng(numeroDecimal)
        End Function
        '/// <summary>
        '/// Pasa los decimales que se piden a la parte entera devolviendola. Sobrecargado para Double y Decimal.
        '/// </summary>
        Private Function DecimalesAentero(ByVal parteDecimal As Decimal, ByVal numeroDecimales As Long) As Long
            Dim aux As Decimal = 1D
            For x As Long = 0 To numeroDecimales - 1
                aux = aux * 10D
            Next
            'aux=Math.Pow(aux,numeroDecimales);
            Dim numeroDecimal As Decimal = parteDecimal * aux
            Return CLng(numeroDecimal)
        End Function
        '/// <summary>
        '/// Esta rutina quita la ultima letra a partir de los miles
        '/// (y los miles sólo si el género es masculino, se controla en el método EnterosAletrasRec)
        '/// y si las decenas de millar son >11 y las unidades de millar=1
        '/// 21000--> veintiun mil O veintiuna mil (depende del genero del texto)
        '/// 71000000--> setenta y un millones (siempre "un" nunca "una" o "uno")
        '/// </summary>
        Private Sub QuitarUltimaLetra(ByRef parsTexto As String, ByVal parlNum As Long)
            Dim centenas As Long = 0, decenas As Long = 0, unidades As Long = 0

            centenas = parlNum / 100
            decenas = (parlNum / 10) - (10 * centenas)
            unidades = parlNum - (10 * decenas) - (100 * centenas)
            'num-((num/10)*10)
            If (decenas > 1) AndAlso (unidades = 1) Then
                parsTexto = parsTexto.Substring(0, parsTexto.Length - 1)
                'quito la última letra
                If decenas = 2 AndAlso unidades = 1 Then
                    parsTexto = parsTexto.Replace("u", "ú")
                    'deveria poner el acento a veintiún
                End If
            End If
        End Sub

    End Class
End Namespace