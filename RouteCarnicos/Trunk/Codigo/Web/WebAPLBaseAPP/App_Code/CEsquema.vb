'Imports BASLOG
'Imports LbDatos

'Namespace Amesol

'   Public Class CEsquema
'      Inherits cClaseNodo

'      Public Sub New()
'         MyBase.New
'      End Sub

'      Public Property EsquemaID As String
'         Get
'            Return Me.Tabla.Campos("EsquemaID").Valor
'         End Get
'         Set
'            	If Me.Status = eEstado.Vacio Or Me.Status = eEstado.Nuevo Then
'	Me.Tabla.Campos("EsquemaID").Valor = Value
'	End If
'	Verificar_Estatus()
'         End Set
'      End Property

'      Public Property EsquemaIDPadre As String
'         Get
'            Return Me.Tabla.Campos("EsquemaIDPadre").Valor
'         End Get
'         Set
'            	Me.Tabla.Campos("EsquemaIDPadre").Valor = Value

'	Verificar_Estatus()
'         End Set
'      End Property

'      Public Property Nombre As String
'         Get
'            Return Me.Tabla.Campos("Nombre").Valor
'         End Get
'         Set
'            	Me.Tabla.Campos("Nombre").Valor = Value

'	Verificar_Estatus()
'         End Set
'      End Property

'      Public Property Abreviatura As String
'         Get
'            Return Me.Tabla.Campos("Abreviatura").Valor
'         End Get
'         Set
'            	Me.Tabla.Campos("Abreviatura").Valor = Value

'	Verificar_Estatus()
'         End Set
'      End Property

'      Public Property Orden As Integer
'         Get
'            Return Me.Tabla.Campos("Orden").Valor
'         End Get
'         Set
'            	Me.Tabla.Campos("Orden").Valor = Value

'	Verificar_Estatus()
'         End Set
'      End Property

'      Public Property Clave As String
'         Get
'            Return Me.Tabla.Campos("Clave").Valor
'         End Get
'         Set
'            	Me.Tabla.Campos("Clave").Valor = Value

'	Verificar_Estatus()
'         End Set
'      End Property

'      Public Property Tipo As Integer
'         Get
'            Return Me.Tabla.Campos("Tipo").Valor
'         End Get
'         Set
'            	Me.Tabla.Campos("Tipo").Valor = Value

'	Verificar_Estatus()
'         End Set
'      End Property

'      Public Property TipoEstado As Integer
'         Get
'            Return Me.Tabla.Campos("TipoEstado").Valor
'         End Get
'         Set
'            	Me.Tabla.Campos("TipoEstado").Valor = Value

'	Verificar_Estatus()
'         End Set
'      End Property

'      Public Property Baja As String
'         Get
'            Return Me.Tabla.Campos("Baja").Valor
'         End Get
'         Set
'            	Me.Tabla.Campos("Baja").Valor = Value

'	Verificar_Estatus()
'         End Set
'      End Property

'      Public Property Nivel As Integer
'         Get
'            Return Me.Tabla.Campos("Nivel").Valor
'         End Get
'         Set
'            	Me.Tabla.Campos("Nivel").Valor = Value

'	Verificar_Estatus()
'         End Set
'      End Property

'      Protected Overrides Sub CrearEstructuraTabla()
'          With Me.Tabla 
'	.AgregarCampo(New LbDatos.cCampo("EsquemaID", LbDatos.ETipo.Cadena, "", True, True))
'	.AgregarCampo(New LbDatos.cCampo("EsquemaIDPadre", LbDatos.ETipo.Cadena, "", False, False))
'	.AgregarCampo(New LbDatos.cCampo("Nombre", LbDatos.ETipo.Cadena, "", False, True))
'	.AgregarCampo(New LbDatos.cCampo("Abreviatura", LbDatos.ETipo.Cadena, "", False, True))
'	.AgregarCampo(New LbDatos.cCampo("Orden", LbDatos.ETipo.Numerico, "", False, True))
'	.AgregarCampo(New LbDatos.cCampo("Clave", LbDatos.ETipo.Cadena, "", False, True))
'	.AgregarCampo(New LbDatos.cCampo("Tipo", LbDatos.ETipo.Numerico, "", False, True))
'	.AgregarCampo(New LbDatos.cCampo("TipoEstado", LbDatos.ETipo.Numerico, "", False, True))
'	.AgregarCampo(New LbDatos.cCampo("Baja", LbDatos.ETipo.Cadena, "", False, True))
'	.AgregarCampo(New LbDatos.cCampo("Nivel", LbDatos.ETipo.Numerico, "", False, False))

' End With
'      End Sub

'      Public Overridable Sub Verificar_Estatus()

'	If Me.Status = eEstado.Recuperado Then
'	 Me.tEstado = eEstado.Modificado 
'	End If
'      End Sub

'      Public Overloads Overridable Function Existe(ByVal pvEsquemaID As String) As Boolean
'         Return (Me.Tabla.Seleccionar("EsquemaID='"& pvEsquemaID &"'").Rows.Count > 0)
'      End Function

'      Public Overloads Overridable Sub Recuperar(ByVal pvEsquemaID As String)
'         	Me.Limpiar()
'	Me.EsquemaID = pvEsquemaID
'	Me.Recuperar()
'      End Sub

'      Public Overloads Sub Insertar(ByVal pvEsquemaID As String, ByVal pvEsquemaIDPadre As String, ByVal pvNombre As String, ByVal pvAbreviatura As String, ByVal pvOrden As Integer, ByVal pvClave As String, ByVal pvTipo As Integer, ByVal pvTipoEstado As Integer, ByVal pvBaja As String, ByVal pvNivel As Integer)

'	Me.EsquemaID=pvEsquemaID
'	Me.EsquemaIDPadre=pvEsquemaIDPadre
'	Me.Nombre=pvNombre
'	Me.Abreviatura=pvAbreviatura
'	Me.Orden=pvOrden
'	Me.Clave=pvClave
'	Me.Tipo=pvTipo
'	Me.TipoEstado=pvTipoEstado
'	Me.Baja=pvBaja
'	Me.Nivel=pvNivel
'	Me.Insertar()
'      End Sub

'      Public Overloads Sub Actualizar(ByVal pvEsquemaID As String, ByVal pvEsquemaIDPadre As String, ByVal pvNombre As String, ByVal pvAbreviatura As String, ByVal pvOrden As Integer, ByVal pvClave As String, ByVal pvTipo As Integer, ByVal pvTipoEstado As Integer, ByVal pvBaja As String, ByVal pvNivel As Integer)

'	Me.EsquemaID=pvEsquemaID
'	Me.EsquemaIDPadre=pvEsquemaIDPadre
'	Me.Nombre=pvNombre
'	Me.Abreviatura=pvAbreviatura
'	Me.Orden=pvOrden
'	Me.Clave=pvClave
'	Me.Tipo=pvTipo
'	Me.TipoEstado=pvTipoEstado
'	Me.Baja=pvBaja
'	Me.Nivel=pvNivel
'	Me.tEstado = eEstado.Modificado
'      End Sub

'      Protected Overrides Function RegresaEnsamblado() As System.Reflection.Assembly
'         Return System.Reflection.Assembly.GetExecutingAssembly()
'      End Function

'      Protected Overrides Function RegresaMnemonico() As String
'         'TODO:Cambiar al nemonico correcto 
'            Return "USR"
'      End Function

'      Protected Overrides Function RegresaNombreTabla() As String
'         Return "Esquema"
'      End Function

'      Protected Overrides Sub CrearHijos()
'         'TODO: Crear los hijos si es necesario
'      End Sub
'   End Class
'End Namespace
