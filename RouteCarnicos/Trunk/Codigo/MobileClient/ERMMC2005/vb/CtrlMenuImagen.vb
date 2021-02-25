Imports System.Drawing
Public Class CtrlMenuImagen
    Implements IDisposable

    Private _renglones As Renglon()
    Private _numRenglones As Integer = 0
    Private _numColumnas As Integer = 0
    Private _colorAlternado As Color
    Private _separacionX As Integer = 0
    Private _separacionY As Integer = 0
    Private _RenglonActual As Integer = 0
    Private _ColumnaActual As Integer = 0
    Private _NumCeldasSeleccionables As Integer = 0


    Public Property NumCeldasSeleccionables() As Integer
        Get
            Return _NumCeldasSeleccionables
        End Get
        Set(ByVal Value As Integer)
            _NumCeldasSeleccionables = Value
        End Set
    End Property

    Public Property RenglonActual() As Integer
        Get
            Return _RenglonActual
        End Get
        Set(ByVal Value As Integer)
            _RenglonActual = Value
        End Set
    End Property

    Public Property ColumnaActual() As Integer
        Get
            Return _ColumnaActual
        End Get
        Set(ByVal Value As Integer)
            _ColumnaActual = Value
        End Set
    End Property

    Public Property Renglones() As Renglon()
        Get
            Return _renglones
        End Get
        Set(ByVal Value As Renglon())
            _renglones = Value
        End Set
    End Property

    Public ReadOnly Property Celdas(ByVal pariIndiceCol As Integer) As Celda
        Get
            If pariIndiceCol <= ((NumColumnas * NumRenglones) - 1) Then
                Dim iRow As Integer = Math.Floor(pariIndiceCol / NumColumnas)
                Return _renglones(iRow).Celdas(pariIndiceCol - (iRow * NumColumnas))
            Else
                Return Nothing
            End If
        End Get
    End Property

    Public ReadOnly Property CeldasPorTipo(ByVal pariTipoIndice As Integer) As Celda
        Get
            For i As Integer = 0 To ((NumColumnas * NumRenglones) - 1)
                If Celdas(i).TipoIndice = pariTipoIndice Then
                    Return Celdas(i)
                End If
            Next
            Return Nothing
        End Get
    End Property

    Public ReadOnly Property CeldaActual() As Celda
        Get
            Try
                Return _renglones(_RenglonActual).Celdas(_ColumnaActual)
            Catch ex As Exception

            End Try
            Return Nothing
        End Get
    End Property

    Public Property NumRenglones() As Integer
        Get
            Return _numRenglones
        End Get
        Set(ByVal Value As Integer)
            _numRenglones = Value
        End Set
    End Property

    Public Property NumColumnas() As Integer
        Get
            Return _numColumnas
        End Get
        Set(ByVal Value As Integer)
            _numColumnas = Value
        End Set
    End Property

    Public Property ColorAlternado() As Color
        Get
            Return _colorAlternado
        End Get
        Set(ByVal Value As Color)
            _colorAlternado = Value
        End Set
    End Property

    Public Property SeparacionX() As Integer
        Get
            Return _separacionX
        End Get
        Set(ByVal Value As Integer)
            _separacionX = Value
        End Set
    End Property

    Public Property SeparacionY() As Integer
        Get
            Return _separacionY
        End Get
        Set(ByVal Value As Integer)
            _separacionY = Value
        End Set
    End Property

    Public Sub CrearGrid()
        Dim i As Integer
        Dim j As Integer
        Dim index

        If _numRenglones = 0 Or _numColumnas = 0 Then Exit Sub

        Me.Panel1.Controls.Clear()

        For i = 0 To NumRenglones - 1
            Dim r As New Renglon(i)
            r.SeparacionX = _separacionX
            r.SeparacionY = _separacionY

            If i Mod 2 = 0 Then
                r.ColorFondo = _colorAlternado
            End If
            For j = 0 To NumColumnas - 1
                Dim c As New Celda
                c.MenuImagenesPadre = Me
                c.IndiceRen = i
                c.IndiceCol = j
                r.AddCelda(c)
                Me.Panel1.Controls.Add(r.Celdas(j).control)
            Next
            If _renglones Is Nothing Then
                index = 0
                ReDim _renglones(0)
            Else
                index = _renglones.Length
                ReDim Preserve _renglones(index)
            End If
            _renglones(index) = r

        Next i
        'SeleccionarCeldaActual()
    End Sub

    Public Sub SeleccionarCeldaActual()
        Try
            If Renglones.Length > 0 Then
                Renglones(_RenglonActual).Celdas(_ColumnaActual).control.Focus()
                Me.lblMenuActual.Text = Renglones(_RenglonActual).Celdas(_ColumnaActual).control.Tag
            End If
        Catch ex As Exception
            _RenglonActual = 0
            _ColumnaActual = 0
        End Try
    End Sub

    Public Sub SeleccionarCeldaActual(ByVal pariRenglon As Integer, ByVal pariColumna As Integer)
        _RenglonActual = pariRenglon
        _ColumnaActual = pariColumna
        SeleccionarCeldaActual()
    End Sub

    Public Sub SiguienteCeldaDer()
        If Renglones(_RenglonActual).Celdas.Length > _ColumnaActual + 1 Then
            If IsNothing(Renglones(_RenglonActual).Celdas(_ColumnaActual + 1).control.Image) Then Exit Sub
            _ColumnaActual += 1
            SeleccionarCeldaActual()
        End If
    End Sub

    Public Sub AnteriorCeldaIzq()
        If _ColumnaActual - 1 >= 0 Then
            If IsNothing(Renglones(_RenglonActual).Celdas(_ColumnaActual - 1).control.Image) Then Exit Sub
            _ColumnaActual -= 1
            SeleccionarCeldaActual()
        End If
    End Sub

    Public Sub SiguienteRenglonAbajo()
        If Renglones.Length > _RenglonActual + 1 Then
            If IsNothing(Renglones(_RenglonActual + 1).Celdas(_ColumnaActual).control.Image) Then Exit Sub
            _RenglonActual += 1
            SeleccionarCeldaActual()
        End If
    End Sub

    Public Sub AnteriorRengloArriba()
        If _RenglonActual - 1 >= 0 Then
            If IsNothing(Renglones(_RenglonActual - 1).Celdas(_ColumnaActual).control.Image) Then Exit Sub
            _RenglonActual -= 1
            SeleccionarCeldaActual()
        End If
    End Sub

    Public Sub LimpiarCeldas()
        Dim i As Integer = 0
        For i = 0 To (_numColumnas * _numRenglones) - 1
            If Not IsNothing(Celdas(i).Imagen) Then
                Celdas(i).Imagen.Dispose()
                Celdas(i).control.Image.Dispose()
                Celdas(i).Imagen = Nothing
                Celdas(i).control.Image = Nothing
            End If
            Celdas(i).TipoIndice = Nothing
            Celdas(i).Activo = False
            Celdas(i).ModuloClave = String.Empty
        Next
        _ColumnaActual = 0
        _RenglonActual = 0

    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub


    Public Class Celda
        Implements IDisposable

        Private _posicion As Point
        Private _TipoIndice As Integer
        Private _IndiceCol As Integer
        Private _IndiceRen As Integer
        Private _Activo As Boolean
        Private _Imagen As Image
        Private _control As PictureBox
        Private _tamaño As Size
        Private _MenuImagenes As CtrlMenuImagen
        Private _ModuloClave As String


        Public Property MenuImagenesPadre() As CtrlMenuImagen
            Get
                Return _MenuImagenes
            End Get
            Set(ByVal Value As CtrlMenuImagen)
                _MenuImagenes = Value
            End Set
        End Property


        Public Property Posicion() As Point
            Get
                Return _posicion
            End Get
            Set(ByVal Value As Point)
                _posicion = Value
                SetPosicion(_posicion)
            End Set
        End Property


        Public Property TipoIndice() As Integer
            Get
                Return _TipoIndice
            End Get
            Set(ByVal Value As Integer)
                _TipoIndice = Value
            End Set
        End Property

        Public Property IndiceCol() As Integer
            Get
                Return _IndiceCol
            End Get
            Set(ByVal Value As Integer)
                _IndiceCol = Value
            End Set
        End Property

        Public Property IndiceRen() As Integer
            Get
                Return _IndiceRen
            End Get
            Set(ByVal Value As Integer)
                _IndiceRen = Value
            End Set
        End Property

        Public Property ModuloClave() As String
            Get
                Return _ModuloClave
            End Get
            Set(ByVal Value As String)
                _ModuloClave = Value
            End Set
        End Property

        Public Property Activo() As Boolean
            Get
                Return _Activo
            End Get
            Set(ByVal Value As Boolean)
                _Activo = Value
            End Set
        End Property

        Public Property Imagen() As Image
            Get
                Return _Imagen
            End Get
            Set(ByVal value As Image)
                _Imagen = value
            End Set
        End Property

        Public Property Tamaño() As Size
            Get
                Return _tamaño
            End Get
            Set(ByVal Value As Size)
                _tamaño = Value
            End Set
        End Property

        Public Property control() As PictureBox
            Get
                Return _control
            End Get
            Set(ByVal Value As PictureBox)
                _control = Value
            End Set
        End Property
        Public Sub New()
            Dim cal As New PictureBox
            AddHandler cal.Click, AddressOf EventoClick
            AddHandler cal.GotFocus, AddressOf EventoGotFocus
            AddHandler cal.LostFocus, AddressOf EventoLostFocus
            AddHandler cal.KeyDown, AddressOf EventoKeyDown
            AddHandler cal.Paint, AddressOf EventoPaint
            AddHandler cal.DoubleClick, AddressOf EventoDoubleClick
            _control = cal
            _tamaño = New System.Drawing.Size(74 * nFactorImg, 68 * nFactorImg)
            _control.Size = _tamaño
            cal.SizeMode = PictureBoxSizeMode.StretchImage
        End Sub


        Public Sub EventoDoubleClick(ByVal sender As Object, ByVal e As EventArgs)
            _MenuImagenes.OnDoubleClick(e)
        End Sub

        Public Sub EventoClick(ByVal sender As Object, ByVal e As EventArgs)
            If Not IsNothing(_control.Image) Then
                _MenuImagenes._ColumnaActual = _IndiceCol
                _MenuImagenes._RenglonActual = _IndiceRen
                _MenuImagenes.SeleccionarCeldaActual()
            End If
        End Sub
        Public Sub EventoPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs)
            If IsNothing(_Imagen) Then Exit Sub
            Using sb As New System.Drawing.SolidBrush(Color.White)
                e.Graphics.FillRectangle(sb, 0, 0, _control.Width, _control.Height)
            End Using

            Dim imageAttr As Imaging.ImageAttributes = New Imaging.ImageAttributes()
            Using bmp As Bitmap = New Bitmap(_Imagen)
                imageAttr.SetColorKey(bmp.GetPixel(0, 0), bmp.GetPixel(0, 0))
            End Using

            If _Activo Then
                Using oPen As New Drawing.Pen(Color.LightSteelBlue, 2)
                    e.Graphics.DrawRectangle(oPen, 5, 5, (_control.Width) - 10, (_control.Height) - 10)
                End Using
                e.Graphics.DrawImage(_Imagen, New Rectangle((_control.Width / 2) - (36 * nFactorImg), (_control.Height / 2) - (36 * nFactorImg), 72 * nFactorImg, 72 * nFactorImg), 0, 0, 72, 72, GraphicsUnit.Pixel, imageAttr)
            Else
                e.Graphics.DrawImage(_Imagen, New Rectangle((_control.Width / 2) - (24), (_control.Height / 2) - (24), 48 * nFactorImg, 48 * nFactorImg), 0, 0, 72, 72, GraphicsUnit.Pixel, imageAttr)
            End If
            e.Graphics.Dispose()
        End Sub

        'Private Function BackgroundImageColor(ByVal parImagen As Image) As Drawing.Color

        'End Function

        Public Sub EventoGotFocus(ByVal sender As Object, ByVal e As EventArgs)
            _Activo = True
            _control.Refresh()
            '_control.BackColor = Color.Transparent
        End Sub

        Public Sub EventoLostFocus(ByVal sender As Object, ByVal e As EventArgs)
            _Activo = False
            _control.Refresh()
            '_control.BackColor = Color.White
        End Sub

        Public Sub EventoKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
            Select Case e.KeyCode
                Case Keys.Left
                    Me.MenuImagenesPadre.AnteriorCeldaIzq()
                Case Keys.Right
                    Me.MenuImagenesPadre.SiguienteCeldaDer()
                Case Keys.Down
                    Me.MenuImagenesPadre.SiguienteRenglonAbajo()
                Case Keys.Up
                    Me.MenuImagenesPadre.AnteriorRengloArriba()
            End Select
            _MenuImagenes.OnKeyDown(e)
        End Sub


        Public Sub SetValores(ByVal pImagen As Image, ByVal pariTipoIndice As Integer, ByVal parsdescripcion As String)
            'Select Case _tipoControl
            '    Case TiposControl.TextBox, TiposControl.Button, TiposControl.CheckBox, TiposControl.Calendar
            _control.Image = pImagen
            _control.Tag = parsdescripcion
            _TipoIndice = pariTipoIndice
            _Imagen = pImagen
            'End Select
        End Sub

        Public Sub SetValores(ByVal pImagen As Image, ByVal pariTipoIndice As Integer, ByVal parsdescripcion As String, ByVal parsModuloClave As String)
            'Select Case _tipoControl
            '    Case TiposControl.TextBox, TiposControl.Button, TiposControl.CheckBox, TiposControl.Calendar
            _control.Image = pImagen
            _Imagen = pImagen
            _control.Tag = parsdescripcion
            _TipoIndice = pariTipoIndice
            _ModuloClave = parsModuloClave
            'End Select
        End Sub

        'Public Sub SetTexto(ByVal pValor As String)
        '    'Select Case _tipoControl
        '    '    Case TiposControl.TextBox, TiposControl.Button, TiposControl.CheckBox, TiposControl.Calendar
        '    _control.Tag = pValor

        '    'End Select
        'End Sub
        Private Sub SetPosicion(ByVal pPosicion As Point)
            'Select Case _tipoControl
            'Case TiposControl.TextBox, TiposControl.Button, TiposControl.CheckBox, TiposControl.Calendar
            _control.Location = pPosicion
            'End Select
        End Sub

        Protected Overrides Sub Finalize()
            MyBase.Finalize()
        End Sub

        Private disposedValue As Boolean = False        ' To detect redundant calls

        ' IDisposable
        Protected Overridable Sub Dispose(ByVal disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    If Not IsNothing(_Imagen) Then
                        _Imagen.Dispose()
                    End If
                    '_control.Image.Dispose()
                    _control.Dispose()
                    _MenuImagenes = Nothing
                    RemoveHandler _control.Click, AddressOf Me.EventoClick
                    RemoveHandler _control.DoubleClick, AddressOf Me.EventoDoubleClick
                    RemoveHandler _control.GotFocus, AddressOf Me.EventoGotFocus
                    RemoveHandler _control.LostFocus, AddressOf Me.EventoLostFocus
                    RemoveHandler _control.KeyDown, AddressOf EventoKeyDown
                    RemoveHandler _control.Paint, AddressOf EventoPaint
                    ' TODO: free unmanaged resources when explicitly called
                End If

                ' TODO: free shared unmanaged resources
            End If
            Me.disposedValue = True
        End Sub

#Region " IDisposable Support "
        ' This code added by Visual Basic to correctly implement the disposable pattern.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
#End Region

    End Class

    Public Class Renglon
        Implements IDisposable

        Private _CeldasRenglon As Celda()
        Private _separacionX As Integer
        Private _separacionY As Integer
        Private _indiceRenglon As Integer
        Private _colorFondo As Color
        Public Property Celdas() As Celda()
            Get
                Return _CeldasRenglon
            End Get
            Set(ByVal Value As Celda())
                _CeldasRenglon = Value
            End Set
        End Property

        Public Property Celdas(ByVal index As Integer) As Celda
            Get
                Return _CeldasRenglon(index)
            End Get
            Set(ByVal Value As Celda)
                _CeldasRenglon(index) = Value
            End Set
        End Property

        Public Property SeparacionX() As Integer
            Get
                Return _separacionX
            End Get
            Set(ByVal Value As Integer)
                _separacionX = Value
            End Set
        End Property

        Public Property SeparacionY() As Integer
            Get
                Return _separacionY
            End Get
            Set(ByVal Value As Integer)
                _separacionY = Value
            End Set
        End Property

        Public Property IndiceRenglon() As Integer
            Get
                Return _indiceRenglon
            End Get
            Set(ByVal Value As Integer)
                _indiceRenglon = Value
            End Set
        End Property

        Public Property ColorFondo() As Color
            Get
                Return _colorFondo
            End Get
            Set(ByVal Value As Color)
                _colorFondo = Value
            End Set
        End Property


        Public Sub New(ByVal pIndiceRenglon As Integer)
            _indiceRenglon = pIndiceRenglon
        End Sub

        Public Sub New(ByVal pIndiceRenglon As Integer, ByVal pColorRenglon As Color)
            _indiceRenglon = pIndiceRenglon
            _colorFondo = pColorRenglon
        End Sub

        Public Sub AddCelda(ByVal pCelda As Celda)
            Dim i As Integer
            Dim distAnt As Integer
            If _CeldasRenglon Is Nothing Then
                i = 0
                ReDim _CeldasRenglon(0)
            Else
                i = _CeldasRenglon.Length
                ReDim Preserve _CeldasRenglon(i)
            End If
            pCelda.Posicion = New Point((i * (pCelda.Tamaño.Width + _separacionX)) + _separacionX, ((_indiceRenglon * (pCelda.Tamaño.Height + SeparacionY))) + _separacionY)
            'pCelda.Valor = pCelda.Posicion.X.ToString & "," & pCelda.Posicion.Y.ToString
            pCelda.control.BackColor = _colorFondo
            _CeldasRenglon(i) = pCelda
        End Sub

        Private disposedValue As Boolean = False        ' To detect redundant calls

        ' IDisposable
        Protected Overridable Sub Dispose(ByVal disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    Dim i As Integer = 0
                    For i = 0 To Celdas.Length - 1
                        _CeldasRenglon(i).Dispose()
                    Next

                    ' TODO: free unmanaged resources when explicitly called
                End If

                ' TODO: free shared unmanaged resources
            End If
            Me.disposedValue = True
        End Sub

#Region " IDisposable Support "
        ' This code added by Visual Basic to correctly implement the disposable pattern.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
#End Region

    End Class

    Protected Overrides Sub Finalize()

        MyBase.Finalize()
    End Sub
End Class
