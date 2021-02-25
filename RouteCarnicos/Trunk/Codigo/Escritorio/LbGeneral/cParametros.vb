''' -----------------------------------------------------------------------------
''' <summary>
''' Tipo de la aplicación destino desde la que se solicita o envía el parametro
''' </summary>
''' <remarks>
''' </remarks>
''' <history>
''' 	[jvazquez]	03/05/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Enum TipoAplicacion
    Escritorio
    Web
End Enum
''' -----------------------------------------------------------------------------
''' Project	 : LbGeneral
''' Class	 : cParametros
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que define el comportamiento, propiedades y características de un parámetro
''' </summary>
''' <remarks>
''' </remarks>
''' <history>
''' 	[jvazquez]	03/05/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class cParametros
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Lenguaje del servidor de datos
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[jvazquez]	03/05/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Shared vcLenguaje As String
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Cadena de coneción a la base de datos
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[jvazquez]	03/05/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Shared vcConexion As String
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Tiempo de espera para la conexión activa
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[jvazquez]	03/05/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Shared vcTimeOut As Integer
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' ID del usuario
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[jvazquez]	03/05/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Shared vcUsuarioID As String
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Tipo de aplicación destino para el parámetro
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[jvazquez]	03/05/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Shared vcTipoAplicacion As TipoAplicacion
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Propiedad de la clase que regresa 
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[jvazquez]	03/05/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared ReadOnly Property Conexion() As String
        Get
            Return vcConexion
        End Get
    End Property
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Regresa el tiempo de espera de conexión de la instancia del parámetro
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[jvazquez]	03/05/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared ReadOnly Property TimeOut() As Integer
        Get
            If vcTimeOut <= 0 Then
                vcTimeOut = -1
            End If
            Return vcTimeOut
        End Get
    End Property
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Regresa el ID del usuario propietario de la instancia del parámetro
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[jvazquez]	03/05/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Property UsuarioID() As String
        Get
            Return vcUsuarioID
        End Get
        Set(ByVal Value As String)
            If vcUsuarioID = "" Then
                vcUsuarioID = Value
            End If
        End Set
    End Property
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Lenguaje del servidor de datos, que servirá para invocar el valór del parámetro correspondiente al 
    ''' lenguaje adecuado
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[jvazquez]	03/05/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Property Lenguaje() As String
        Get
            If vcLenguaje = "" Then
                vcLenguaje = "EM"
            End If
            Return vcLenguaje
        End Get
        Set(ByVal Value As String)
            vcLenguaje = Value
        End Set
    End Property
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Regresa o asigna el tipo de aplicación para la cual se obtiene el valor del parámetro
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[jvazquez]	03/05/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Property TipoAplicacion() As TipoAplicacion
        Get
            Return vcTipoAplicacion
        End Get
        Set(ByVal Value As TipoAplicacion)
            vcTipoAplicacion = Value
        End Set
    End Property
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtiene y asigna los valores  de cadena de conexión, tiempo de espera y lenguaje 
    ''' obtenidos del archivo de configuración de la aplicación
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[jvazquez]	03/05/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub CargarParametros()
        vcConexion = ReadIni("Conexion")
        vcTimeOut = Int(ReadIni("TimeOut"))
        vcLenguaje = ReadIni("Lenguaje")
    End Sub
End Class
