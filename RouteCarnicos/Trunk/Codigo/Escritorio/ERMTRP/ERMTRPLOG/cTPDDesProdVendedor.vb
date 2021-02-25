Imports BASLOG

Public Class cTPDDesProdVendedor
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
    Public Property DesPor() As Decimal
        Get
            Return Decimal.Round(Me.Tabla.Campos("DesPor").Valor, 4)
        End Get
        Set(ByVal Value As Decimal)
            Me.Tabla.Campos("DesPor").Valor = Decimal.Round(Value, 4)
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property DesImporte() As Double
        Get
            Return Math.Round(Me.Tabla.Campos("DesImporte").Valor, 2)
        End Get
        Set(ByVal Value As Double)
            Me.Tabla.Campos("DesImporte").Valor = Math.Round(Value, 2)
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
            .AgregarCampo(New LbDatos.cCampo("DesPor", LbDatos.ETipo.Numerico, 0, False, False))
            .AgregarCampo(New LbDatos.cCampo("DesImporte", LbDatos.ETipo.Numerico, 0, False, False))
        End With
    End Sub

    Protected Overrides Sub CrearHijos()

    End Sub

    Protected Overrides Function RegresaEnsamblado() As System.Reflection.Assembly
        Return System.Reflection.Assembly.GetExecutingAssembly()
    End Function

    Protected Overrides Function RegresaMnemonico() As String
        Return "TPV"
    End Function

    Protected Overrides Function RegresaNombreTabla() As String
        Return "TPDDesProdVendedor"
    End Function
#End Region

#Region "Sobrecargados Especificos"

    Public Overloads Sub Recuperar(ByVal pvTransProdID As String, ByVal pvTransProdDetalleId As String)
        Me.Limpiar()
        Me.Tabla.Campos("TransProdID").Valor = pvTransProdID
        Me.Tabla.Campos("TransProdDetalleId").Valor = pvTransProdDetalleId
        Me.Recuperar()
    End Sub

    Public Overloads Function Existe(ByVal pvTransProdID As String, ByVal pvTransProdDetalleId As String) As Boolean
        Return (Me.Tabla.Seleccionar("TransProdID='" & pvTransProdID & "' AND TransProdDetalleId ='" + pvTransProdDetalleId + "' ").Rows.Count > 0)
    End Function

#End Region
End Class

Public Class cCollectionTPDDesProdVendedor
    Inherits cCollectionClaseNodo

    Public Sub New(ByRef prArreglo As ArrayList, ByRef prDT As DataTable, ByRef prTablaTPV As cTablaNodo)
        MyBase.New(prArreglo, prDT, prTablaTPV)
    End Sub

    Public Overloads Function Insertar(ByRef prTPV As cTPDDesProdVendedor) As Integer
        Return MyBase.Insertar(CType(prTPV, cClaseNodo))
    End Function

End Class