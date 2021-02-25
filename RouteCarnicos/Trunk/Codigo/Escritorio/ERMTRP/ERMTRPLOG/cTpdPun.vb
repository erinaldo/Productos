Imports BASLOG

Public Class cTpdPun
    Inherits BASLOG.cClaseNodo

#Region "Propiedades"
    Public ReadOnly Property TransProdDetalleID() As String
        Get
            Return Me.Padre.ObtenerValorPropiedad("TransProdDetalleID")
        End Get
    End Property
    Public Property TransProdId() As String
        Get
            Return Me.Tabla.Campos("TransProdId").Valor
        End Get
        Set(ByVal Value As String)
            Me.Tabla.Campos("TransProdId").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property PromocionClave() As String
        Get
            Return Me.Tabla.Campos("PromocionClave").Valor
        End Get
        Set(ByVal Value As String)
            Me.Tabla.Campos("PromocionClave").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property Puntos() As Double
        Get
            Return Me.Tabla.Campos("Puntos").Valor
        End Get
        Set(ByVal Value As Double)
            Me.Tabla.Campos("Puntos").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property

#End Region

#Region "Constructores"

    Public Sub New(ByRef prPadre As ERMTRPLOG.cTransProdDetalle)
        MyBase.New(prPadre)
    End Sub

#End Region

#Region "Sobreescritos"
    Protected Overrides Sub CrearEstructuraTabla()
        With Me.Tabla
            .AgregarCampo(New LbDatos.cCampo("TransProdID", LbDatos.ETipo.Cadena, "", True, True))
            .AgregarCampo(New LbDatos.cCampo("TransProdDetalleId", LbDatos.ETipo.Cadena, "", True, True))
            .AgregarCampo(New LbDatos.cCampo("PromocionClave", LbDatos.ETipo.Cadena, "", True, True))
            .AgregarCampo(New LbDatos.cCampo("Puntos", LbDatos.ETipo.Numerico, True))

        End With
    End Sub

    Protected Overrides Sub CrearHijos()

    End Sub

    Protected Overrides Function RegresaEnsamblado() As System.Reflection.Assembly
        Return System.Reflection.Assembly.GetExecutingAssembly()
    End Function

    Protected Overrides Function RegresaMnemonico() As String
        Return "TPD"
    End Function

    Protected Overrides Function RegresaNombreTabla() As String
        Return "TpdPun"
    End Function
#End Region

#Region "Sobrecargados Especificos"

    Public Overloads Sub Recuperar(ByVal pvTransProdID As String, ByVal pvTransProdDetalleId As String, ByVal pvPromocionClave As String)
        Me.Limpiar()
        Me.Tabla.Campos("TransProdID").Valor = pvTransProdID
        Me.Tabla.Campos("TransProdDetalleId").Valor = pvTransProdDetalleId
        Me.Tabla.Campos("PromocionClave").Valor = pvPromocionClave
        Me.Recuperar()
    End Sub

    Public Overloads Function Existe(ByVal pvTransProdID As String, ByVal pvTransProdDetalleId As String, ByVal pvPromocionClave As String) As Boolean
        Return (Me.Tabla.Seleccionar("TransProdID='" & pvTransProdID & "' AND TransProdDetalleId ='" + pvTransProdDetalleId + "' AND PromocionClave ='" + pvPromocionClave + "'").Rows.Count > 0)
    End Function

#End Region
End Class

Public Class cCollectionTpdPun
    Inherits cCollectionClaseNodo

    Public Sub New(ByRef prArreglo As ArrayList, ByRef prDT As DataTable, ByRef prTablaTPD As cTablaNodo)
        MyBase.New(prArreglo, prDT, prTablaTPD)
    End Sub

    Public Overloads Function Insertar(ByRef prTpd As cTpdPun) As Integer
        Return MyBase.Insertar(CType(prTpd, cClaseNodo))
    End Function

End Class

