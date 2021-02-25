Public Class CFDi
    Private itamanio As Long
    Private otimbreFiscal As cTimbreFiscal

    Public Property Tamanio() As Long
        Get
            Return Me.itamanio
        End Get
        Set(ByVal value As Long)
            Me.itamanio = value
        End Set
    End Property




    Public Property TimbreFiscal() As cTimbreFiscal
        Get
            Return Me.otimbreFiscal
        End Get
        Set(ByVal value As cTimbreFiscal)
            Me.otimbreFiscal = value
        End Set
    End Property

    Public Sub New()
        otimbreFiscal = New cTimbreFiscal()
    End Sub

    Public Class cTimbreFiscal

        Private versionField As String

        Private uUIDField As String

        Private fechaTimbradoField As Date

        Private selloCFDField As String

        Private noCertificadoSATField As String

        Private selloSATField As String




        Public Property version() As String
            Get
                Return Me.versionField
            End Get
            Set(ByVal value As String)
                Me.versionField = value
            End Set
        End Property


        Public Property UUID() As String
            Get
                Return Me.uUIDField
            End Get
            Set(ByVal value As String)
                Me.uUIDField = value
            End Set
        End Property


        Public Property FechaTimbrado() As Date
            Get
                Return Me.fechaTimbradoField
            End Get
            Set(ByVal value As Date)
                Me.fechaTimbradoField = value
            End Set
        End Property


        Public Property selloCFD() As String
            Get
                Return Me.selloCFDField
            End Get
            Set(ByVal value As String)
                Me.selloCFDField = value
            End Set
        End Property


        Public Property noCertificadoSAT() As String
            Get
                Return Me.noCertificadoSATField
            End Get
            Set(ByVal value As String)
                Me.noCertificadoSATField = value
            End Set
        End Property


        Public Property selloSAT() As String
            Get
                Return Me.selloSATField
            End Get
            Set(ByVal value As String)
                Me.selloSATField = value
            End Set
        End Property
    End Class
End Class



Public Class CFDiException
    Inherits System.SystemException

    Private scodigo As String = ""

    Public ReadOnly Property Codigo() As String
        Get
            Return scodigo
        End Get

    End Property


    Public Sub New(ByVal Codigo As String, ByVal Message As String)
        MyBase.New(Message)
        scodigo = Codigo

    End Sub


End Class