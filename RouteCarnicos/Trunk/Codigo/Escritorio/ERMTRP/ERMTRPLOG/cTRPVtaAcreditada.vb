Imports BASLOG

Public Class cTRPVtaAcreditada
    Inherits BASLOG.cClaseNodo

#Region "Propiedades"
    Public ReadOnly Property TransProdID() As String
        Get
            Return Me.Padre.ObtenerValorPropiedad("TransProdID")
        End Get
    End Property
    Public Property FolioEntrega() As String
        Get
            Return Me.Tabla.Campos("FolioEntrega").Valor
        End Get
        Set(ByVal Value As String)
            Me.Tabla.Campos("FolioEntrega").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property FolioCliente() As String
        Get
            Return Me.Tabla.Campos("FolioCliente").Valor
        End Get
        Set(ByVal Value As String)
            Me.Tabla.Campos("FolioCliente").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property Remision() As String
        Get
            Return Me.Tabla.Campos("Remision").Valor
        End Get
        Set(ByVal Value As String)
            Me.Tabla.Campos("Remision").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property PedidoAdicional() As String
        Get
            Return Me.Tabla.Campos("PedidoAdicional").Valor
        End Get
        Set(ByVal Value As String)
            Me.Tabla.Campos("PedidoAdicional").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property

#End Region

#Region "Constructores"

    Public Sub New(ByRef prPadre As cTransProd)
        MyBase.New(prPadre)
    End Sub

#End Region

#Region "Sobreescritos"
    Protected Overrides Sub CrearEstructuraTabla()
        With Me.Tabla
            .AgregarCampo(New LbDatos.cCampo("TransProdID", LbDatos.ETipo.Cadena, "", True, True))
            .AgregarCampo(New LbDatos.cCampo("FolioEntrega", LbDatos.ETipo.Cadena, False))
            .AgregarCampo(New LbDatos.cCampo("FolioCliente", LbDatos.ETipo.Cadena, False))
            .AgregarCampo(New LbDatos.cCampo("Remision", LbDatos.ETipo.Cadena, False))
            .AgregarCampo(New LbDatos.cCampo("PedidoAdicional", LbDatos.ETipo.Cadena, False))
        End With
    End Sub

    Protected Overrides Sub CrearHijos()

    End Sub

    Protected Overrides Function RegresaEnsamblado() As System.Reflection.Assembly
        Return System.Reflection.Assembly.GetExecutingAssembly()
    End Function

    Protected Overrides Function RegresaMnemonico() As String
        Return "TVA"
    End Function

    Protected Overrides Function RegresaNombreTabla() As String
        Return "TRPVtaAcreditada"
    End Function
#End Region

#Region "Sobrecargados Especificos"

    Public Overloads Sub Recuperar(ByVal pvTransProdID As String)
        Me.Limpiar()
        Me.Tabla.Campos("TransProdID").Valor = pvTransProdID
        Me.Recuperar()
    End Sub

    Public Overloads Function Existe(ByVal pvTransProdID As String) As Boolean
        Return (Me.Tabla.Seleccionar("TransProdID='" & pvTransProdID & "'").Rows.Count > 0)
    End Function

#End Region
End Class
