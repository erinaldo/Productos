Public Class clsName


#Region "Privado"
    Private _ID As Integer
    Private _Nombre As String
    Private oDB As clsDB
#End Region

#Region "Propiedades"
    Public Property ID() As Integer
        Get
            Return _ID
        End Get
        Set(ByVal value As Integer)
            _ID = value
        End Set
    End Property

    Public Property Nombre() As String
        Get
            Return _Nombre
        End Get
        Set(ByVal value As String)
            _Nombre = value
        End Set
    End Property
    Public Property DB() As clsDB
        Get
            Return oDB
        End Get
        Set(ByVal value As clsDB)
            oDB = value
        End Set
    End Property

    Public Sub New(ByVal cadenaConexion As String)
        oDB = New clsDB(cadenaConexion)
    End Sub
#End Region

End Class
