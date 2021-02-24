Imports Microsoft.VisualBasic

Namespace DBCentral

    Public Class CUsuario

        Protected sUsuarioId As String
        Protected sTallerId As String
        Protected sClave As String
        Protected sClaveAcceso As String
        Protected sNombre As String
        Protected bActivo As Boolean
        Protected tTipo As DBCentral.TiposUsuarios

        Public Property UsuarioId() As String
            Get
                Return sUsuarioId
            End Get
            Set(ByVal Value As String)
                sUsuarioId = Value
            End Set
        End Property
        Public Property TallerId() As String
            Get
                Return sTallerId
            End Get
            Set(ByVal Value As String)
                sTallerId = Value
            End Set
        End Property
        Public Property Clave() As String
            Get
                Return sClave
            End Get
            Set(ByVal Value As String)
                sClave = Value
            End Set
        End Property
        Public Property ClaveAcceso() As String
            Get
                Return sClaveAcceso
            End Get
            Set(ByVal Value As String)
                sClaveAcceso = Value
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
        Public Property Tipo() As DBCentral.TiposUsuarios
            Get
                Return tTipo
            End Get
            Set(ByVal Value As DBCentral.TiposUsuarios)
                tTipo = Value
            End Set
        End Property
        Public Property Activo() As Boolean
            Get
                Return bActivo
            End Get
            Set(ByVal Value As Boolean)
                bActivo = Value
            End Set
        End Property
    End Class

    Public Class CTaller
        Protected sTallerId As String
        Protected sAlmacenId As String
        Protected sClave As String
        Protected sDescripcion As String
        Protected sNoSerieTerminal As String
        Protected bActivo As Boolean

        Public Property TallerId() As String
            Get
                Return sTallerId
            End Get
            Set(ByVal Value As String)
                sTallerId = Value
            End Set
        End Property
        Public Property AlmacenId() As String
            Get
                Return sAlmacenId
            End Get
            Set(ByVal Value As String)
                sAlmacenId = Value
            End Set
        End Property
        Public Property Clave() As String
            Get
                Return sClave
            End Get
            Set(ByVal Value As String)
                sClave = Value
            End Set
        End Property
        Public Property Descripcion() As String
            Get
                Return sDescripcion
            End Get
            Set(ByVal Value As String)
                sDescripcion = Value
            End Set
        End Property
        Public Property NoSerieTerminal() As String
            Get
                Return sNoSerieTerminal
            End Get
            Set(ByVal Value As String)
                sNoSerieTerminal = Value
            End Set
        End Property
        Public Property Activo() As Boolean
            Get
                Return bActivo
            End Get
            Set(ByVal Value As Boolean)
                bActivo = Value
            End Set
        End Property
    End Class

    Public Class CTabla

        Protected sTablaId As String
        Protected sNombre As String
        Protected sDescripcion As String
        Protected iGrupo As Integer
        Protected iOrden As Integer
        Protected sConsultaSQL As String

        Public Property TablaId() As String
            Get
                Return sTablaId
            End Get
            Set(ByVal Value As String)
                sTablaId = Value
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
        Public Property Descripcion() As String
            Get
                Return sDescripcion
            End Get
            Set(ByVal Value As String)
                sDescripcion = Value
            End Set
        End Property
        Public Property Grupo() As Integer
            Get
                Return iGrupo
            End Get
            Set(ByVal Value As Integer)
                iGrupo = Value
            End Set
        End Property
        Public Property Orden() As Integer
            Get
                Return iorden
            End Get
            Set(ByVal Value As Integer)
                iorden = Value
            End Set
        End Property
        Public Property ConsultaSQL() As String
            Get
                Return sConsultaSQL
            End Get
            Set(ByVal Value As String)
                sConsultaSQL = Value
            End Set
        End Property

    End Class

    Public Class CCampo

        Protected sCampoId As String
        Protected sNombre As String
        Protected sDescripcion As String
        Protected tTipo As DBCentral.TiposCampos
        Protected iLongitud As Short

        Public Property CampoId() As String
            Get
                Return sCampoId
            End Get
            Set(ByVal Value As String)
                sCampoId = Value
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
        Public Property Descripcion() As String
            Get
                Return sDescripcion
            End Get
            Set(ByVal Value As String)
                sDescripcion = Value
            End Set
        End Property
        Public Property Tipo() As DBCentral.TiposCampos
            Get
                Return tTipo
            End Get
            Set(ByVal Value As DBCentral.TiposCampos)
                tTipo = Value
            End Set
        End Property
        Public Property Longitud() As Short
            Get
                Return iLongitud
            End Get
            Set(ByVal Value As Short)
                iLongitud = Value
            End Set
        End Property

    End Class

    Public Enum TiposModificable
        NoDefinido = 0
    End Enum

    Public Enum TiposNulo
        NoDefinido = 0

    End Enum

    Public Enum TiposDatos
        NoDefinido = 0

    End Enum

    Public Enum TiposCampos
        NoDefinido = 0
        Bit = 1
        Datetime = 2
        Int = 3
        Money = 4
        Ntext = 5
        Nvarchar = 6
        Real = 7
        Smallint = 8
        Image = 9
        Float = 10
        BigInt = 11
        Decimal_ = 12
    End Enum

    Public Enum TiposUsuarios
        NoDefinido = 0
        Asesor = 1
        Mecanico = 2
    End Enum

    Public Enum TiposEstadosRegistros
        Inactivo = 0
        Activo = 1
    End Enum

    Public Enum TiposContenidoFolios
        NoDefinido = 0
        Constante = 1
        Incremental = 2
    End Enum

    Public Enum TiposTablasCampos
        Nulos = 0 ' NULL
        LlavePrimaria = 1
        LlaveForanea = 2
        LlavePrimariaForanea = 3
        LlaveForaneaNulos = 4
        NoNulos = 5 ' NOT NULL
    End Enum

    Public Enum TiposBase
        NoDefinido = 0
        Aplicacion = 1
        AplSQLite = 2
    End Enum

End Namespace

