Imports BASLOG

Public Class cTRPRegimenFiscal
    Inherits BASLOG.cClaseNodo

#Region "Propiedades"
    Public ReadOnly Property TransProdID() As String
        Get
            Return Me.Padre.ObtenerValorPropiedad("TransProdID")
        End Get
    End Property
    Public Property RegimenID() As String
        Get
            Return Me.Tabla.Campos("RegimenID").Valor
        End Get
        Set(ByVal Value As String)
            If Me.Status = eEstado.Vacio Or Me.Status = eEstado.Nuevo Then
                Me.Tabla.Campos("RegimenID").Valor = Value
            End If
        End Set
    End Property
    Public Property Descripcion() As String
        Get
            Return Me.Tabla.Campos("Descripcion").Valor
        End Get
        Set(ByVal Value As String)
            Me.Tabla.Campos("Descripcion").Valor = Value
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
            .AgregarCampo(New LbDatos.cCampo("RegimenID", LbDatos.ETipo.Cadena, "", True, True))
            .AgregarCampo(New LbDatos.cCampo("Descripcion", LbDatos.ETipo.Cadena, False))
        End With
    End Sub

    Protected Overrides Sub CrearHijos()

    End Sub

    Protected Overrides Function RegresaEnsamblado() As System.Reflection.Assembly
        Return System.Reflection.Assembly.GetExecutingAssembly()
    End Function

    Protected Overrides Function RegresaMnemonico() As String
        Return "TRF"
    End Function

    Protected Overrides Function RegresaNombreTabla() As String
        Return "TRPRegimenFiscal"
    End Function
#End Region

#Region "Sobrecargados Especificos"

    Public Overloads Sub Recuperar(ByVal pvTransProdID As String)
        Me.Limpiar()
        Me.Tabla.Campos("TransProdID").Valor = pvTransProdID
        Me.Recuperar()
    End Sub

    Public Overloads Function Existe(ByVal pvTransProdID As String, ByVal pvDescripcion As String) As Boolean
        Return (Me.Tabla.Seleccionar("TransProdID='" & pvTransProdID & "' and Descripcion='" & pvDescripcion & "'").Rows.Count > 0)
    End Function

#End Region
End Class
