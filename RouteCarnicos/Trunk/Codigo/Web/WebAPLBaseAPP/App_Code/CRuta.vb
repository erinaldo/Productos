'Imports BASLOG
'Imports LbDatos

'Namespace Amesol

'    Public Class CRuta
'        Inherits cClaseNodo

'        Public Sub New()
'            MyBase.New()
'        End Sub

'        Public Property RUTClave() As String
'            Get
'                Return Me.Tabla.Campos("RUTClave").Valor
'            End Get
'            Set(ByVal value As String)
'                If Me.Status = eEstado.Vacio Or Me.Status = eEstado.Nuevo Then
'                    Me.Tabla.Campos("RUTClave").Valor = Value
'                End If
'                Verificar_Estatus()
'            End Set
'        End Property

'        Public Property Descripcion() As String
'            Get
'                Return Me.Tabla.Campos("Descripcion").Valor
'            End Get
'            Set(ByVal value As String)
'                Me.Tabla.Campos("Descripcion").Valor = Value

'                Verificar_Estatus()
'            End Set
'        End Property

'        Public Property Tipo() As Integer
'            Get
'                Return Me.Tabla.Campos("Tipo").Valor
'            End Get
'            Set(ByVal value As Integer)
'                Me.Tabla.Campos("Tipo").Valor = Value

'                Verificar_Estatus()
'            End Set
'        End Property

'        Public Property TipoEstado() As Integer
'            Get
'                Return Me.Tabla.Campos("TipoEstado").Valor
'            End Get
'            Set(ByVal value As Integer)
'                Me.Tabla.Campos("TipoEstado").Valor = Value

'                Verificar_Estatus()
'            End Set
'        End Property

'        Public Property Inventario() As String
'            Get
'                Return Me.Tabla.Campos("Inventario").Valor
'            End Get
'            Set(ByVal value As String)
'                Me.Tabla.Campos("Inventario").Valor = Value

'                Verificar_Estatus()
'            End Set
'        End Property

'        Protected Overrides Sub CrearEstructuraTabla()
'            With Me.Tabla
'                .AgregarCampo(New LbDatos.cCampo("RUTClave", LbDatos.ETipo.Cadena, "", True, True))
'                .AgregarCampo(New LbDatos.cCampo("Descripcion", LbDatos.ETipo.Cadena, "", False, True))
'                .AgregarCampo(New LbDatos.cCampo("Tipo", LbDatos.ETipo.Numerico, "", False, True))
'                .AgregarCampo(New LbDatos.cCampo("TipoEstado", LbDatos.ETipo.Numerico, "", False, True))
'                .AgregarCampo(New LbDatos.cCampo("Inventario", LbDatos.ETipo.Cadena, "", False, True))

'            End With
'        End Sub

'        Public Overridable Sub Verificar_Estatus()

'            If Me.Status = eEstado.Recuperado Then
'                Me.tEstado = eEstado.Modificado
'            End If
'        End Sub

'        Public Overridable Overloads Function Existe(ByVal pvRUTClave As String) As Boolean
'            Return (Me.Tabla.Seleccionar("RUTClave='" & pvRUTClave & "'").Rows.Count > 0)
'        End Function

'        Public Overridable Overloads Sub Recuperar(ByVal pvRUTClave As String)
'            Me.Limpiar()
'            Me.RUTClave = pvRUTClave
'            Me.Recuperar()
'        End Sub

'        Public Overloads Sub Insertar(ByVal pvRUTClave As String, ByVal pvDescripcion As String, ByVal pvTipo As Integer, ByVal pvTipoEstado As Integer, ByVal pvInventario As String)

'            Me.RUTClave = pvRUTClave
'            Me.Descripcion = pvDescripcion
'            Me.Tipo = pvTipo
'            Me.TipoEstado = pvTipoEstado
'            Me.Inventario = pvInventario
'            Me.Insertar()
'        End Sub

'        Public Overloads Sub Actualizar(ByVal pvRUTClave As String, ByVal pvDescripcion As String, ByVal pvTipo As Integer, ByVal pvTipoEstado As Integer, ByVal pvInventario As String)

'            Me.RUTClave = pvRUTClave
'            Me.Descripcion = pvDescripcion
'            Me.Tipo = pvTipo
'            Me.TipoEstado = pvTipoEstado
'            Me.Inventario = pvInventario
'        End Sub

'        Protected Overrides Function RegresaEnsamblado() As System.Reflection.[Assembly]
'            Return System.Reflection.Assembly.GetExecutingAssembly()
'        End Function

'        Protected Overrides Function RegresaMnemonico() As String
'            'TODO:Cambiar al nemonico correcto 
'            Return "USR"
'        End Function

'        Protected Overrides Function RegresaNombreTabla() As String
'            Return "Ruta"
'        End Function

'        Protected Overrides Sub CrearHijos()
'            'TODO: Crear los hijos si es necesario
'        End Sub
'    End Class
'End Namespace
