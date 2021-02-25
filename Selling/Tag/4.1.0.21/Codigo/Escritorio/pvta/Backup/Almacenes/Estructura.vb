Public Class Estructura
    Inherits System.Windows.Forms.PictureBox

    'Atributos de la estructura

    Public ALMClave As String
    Public AREClave As String
    Public TSTClave As String
    Public Clave As String
    Public PasilloColoca As String
    Public PasilloRecoge As String
    Public TipoRotacion As Integer
    Public Color As Integer
    Public Escala As Integer
    Public OrigenX As Double
    Public OrigenY As Double
    Public Largo As Double
    Public Ancho As Double
    Public Alto As Double
    Public Columnas As Integer
    Public Niveles As Integer
    ' Public CapacidadCarga As Double
    Public Rotada As Boolean
    Public CambioTamaño As Boolean
    Public CambioPosicion As Boolean
    Public Indice As Integer
    Public Estado As Integer
    Public Selected As Boolean



    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal sClave As String, ByVal p1 As Point, ByVal p2 As Point)

        Me.ContextMenu = ModPOS.Superficie.CtxEstructura
        Me.BackColor = System.Drawing.Color.White
        Me.Color = Me.BackColor.ToArgb()
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Cursor = System.Windows.Forms.Cursors.SizeAll
        Me.Location = p1
        Me.OrigenX = p1.X / ModPOS.EscalaActual
        Me.OrigenY = p1.Y / ModPOS.EscalaActual
        Me.Width = System.Math.Abs(p2.X - p1.X)
        Me.Height = System.Math.Abs(p2.Y - p1.Y)
        Me.Name = sClave
        Me.ALMClave = ModPOS.Superficie.ALMClave
        Me.Largo = Me.Width / ModPOS.EscalaActual
        Me.Ancho = Me.Height / ModPOS.EscalaActual
        Me.Escala = ModPOS.EscalaActual
        Me.Rotada = False
        Me.CambioPosicion = False
        Me.CambioTamaño = False
        Me.Indice = ModPOS.numEst_Vector
        Me.Estado = 1

    End Sub

    Public Sub New(ByVal sClave As String, ByVal iColor As Integer, ByVal X As Double, ByVal Y As Double, ByVal W As Integer, ByVal H As Integer, ByVal R As Boolean)
        Dim punto As Point
        punto.X = CInt(X) * ModPOS.EscalaActual
        punto.Y = CInt(Y) * ModPOS.EscalaActual
        Me.ContextMenu = ModPOS.Superficie.CtxEstructura
        Me.BackColor = System.Drawing.Color.FromArgb(iColor)
        Me.Color = iColor
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Cursor = System.Windows.Forms.Cursors.SizeAll
        Me.Name = sClave
        Me.Location = punto
        Me.OrigenX = X
        Me.OrigenY = Y
        Me.Width = W
        Me.Height = H
        Me.ALMClave = ModPOS.Superficie.ALMClave
        Me.Escala = ModPOS.EscalaActual
        Me.Rotada = R
        Me.CambioPosicion = False
        Me.CambioTamaño = False
        Me.Indice = ModPOS.numEst_Vector

       



    End Sub

    Public Sub New(ByVal sClave As String, ByVal W As Integer, ByVal H As Integer)
        Me.ContextMenu = ModPOS.Superficie.CtxEstructura
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Cursor = System.Windows.Forms.Cursors.SizeAll
        Me.Name = sClave
        Me.Width = W
        Me.Height = H
        Me.ALMClave = ModPOS.Superficie.ALMClave
        Me.Escala = ModPOS.EscalaActual
        Me.CambioPosicion = False
        Me.CambioTamaño = False

    End Sub

End Class
