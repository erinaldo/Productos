Imports BASLOG

Public Class cAbnTrp
    Inherits BASLOG.cClaseNodo

#Region "Propiedades"

    Public Property ABNId() As String
        Get
            Return DirectCast(Me.Tabla.Campos(0), LbDatos.cCampo).Valor.ToString()
        End Get
        Set(ByVal value As String)
            If Me.Status = eEstado.Vacio Or Me.Status = eEstado.Nuevo Then
                DirectCast(Me.Tabla.Campos(0), LbDatos.cCampo).Valor = value
            End If
        End Set
    End Property
    Public Property TransProdID() As String
        Get
            Return DirectCast(Me.Tabla.Campos(1), LbDatos.cCampo).Valor.ToString()
        End Get
        Set(ByVal value As String)
            If Me.Status = eEstado.Vacio Or Me.Status = eEstado.Nuevo Then
                DirectCast(Me.Tabla.Campos(1), LbDatos.cCampo).Valor = value
            End If
        End Set
    End Property
    Public Property FechaHora() As DateTime
        Get
            Return Convert.ToDateTime(DirectCast(Me.Tabla.Campos(2), LbDatos.cCampo).Valor)
        End Get
        Set(ByVal value As DateTime)
            DirectCast(Me.Tabla.Campos(2), LbDatos.cCampo).Valor = value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property Importe() As Double
        Get
            Return Convert.ToDouble(DirectCast(Me.Tabla.Campos(3), LbDatos.cCampo).Valor.ToString())
        End Get
        Set(ByVal value As Double)
            DirectCast(Me.Tabla.Campos(3), LbDatos.cCampo).Valor = value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property Serie() As String
        Get
            Return DirectCast(Me.Tabla.Campos(4), LbDatos.cCampo).Valor.ToString()
        End Get
        Set(ByVal value As String)
            DirectCast(Me.Tabla.Campos(4), LbDatos.cCampo).Valor = value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property Corecibo() As String
        Get
            Return DirectCast(Me.Tabla.Campos(5), LbDatos.cCampo).Valor.ToString()
        End Get
        Set(ByVal value As String)
            DirectCast(Me.Tabla.Campos(5), LbDatos.cCampo).Valor = value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property TipoFaseIntSal() As Int16
        Get
            Return Convert.ToInt16(DirectCast(Me.Tabla.Campos(6), LbDatos.cCampo).Valor)
        End Get
        Set(ByVal value As Int16)
            DirectCast(Me.Tabla.Campos(6), LbDatos.cCampo).Valor = value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property

#End Region

#Region "Constructor"
    Public Sub New(ByVal prPadre As cAbono)
        MyBase.New(prPadre)
    End Sub
#End Region

#Region "SobreEscritos"

    Protected Overrides Sub CrearEstructuraTabla()
        Tabla.AgregarCampo(New LbDatos.cCampo("ABNId", LbDatos.ETipo.Cadena, "", True, True))
        Tabla.AgregarCampo(New LbDatos.cCampo("TransProdID", LbDatos.ETipo.Cadena, "", True, True, False, False))
        Tabla.AgregarCampo(New LbDatos.cCampo("FechaHora", LbDatos.ETipo.FechaHora, True))
        Tabla.AgregarCampo(New LbDatos.cCampo("Importe", LbDatos.ETipo.Numerico, True))
        Tabla.AgregarCampo(New LbDatos.cCampo("Serie", LbDatos.ETipo.Cadena, "", ))
        Tabla.AgregarCampo(New LbDatos.cCampo("Corecibo", LbDatos.ETipo.Cadena, "", ))
        Tabla.AgregarCampo(New LbDatos.cCampo("TipoFaseIntSal", LbDatos.ETipo.Numerico, 0, False, True, True, False))

    End Sub

    Protected Overrides Sub CrearHijos()
        
    End Sub

    Protected Overrides Function RegresaEnsamblado() As System.Reflection.Assembly
        Return System.Reflection.Assembly.GetExecutingAssembly()
    End Function

    Protected Overrides Function RegresaMnemonico() As String
        Return "ABN"
    End Function

    Protected Overrides Function RegresaNombreTabla() As String
        Return "ABNTRP"
    End Function
#End Region

#Region "SobreCargas Especificas"

    Public Overloads Sub Recuperar(ByVal pvTransprodId As String)
        Me.Limpiar()
        Me.TransProdID = pvTransprodId
        Me.Recuperar()
    End Sub

    Public Function Existe(ByVal pvTransprodId As String) As Boolean
        Return (Me.Tabla.Seleccionar(" TransprodId ='" & pvTransprodId & "'").Rows.Count > 0)
    End Function

#End Region

End Class


Public Class cCollectionABNTRP
    Inherits cCollectionClaseNodo

    Public Sub New(ByRef prArreglo As System.Collections.ArrayList, ByRef prDT As System.Data.DataTable, ByRef prTablaTPD As cTablaNodo)
        MyBase.New(prArreglo, prDT, prTablaTPD)
    End Sub

    Public Overloads Function Insertar(ByRef pvABNTRP As cABNTRP) As Integer

        Return MyBase.Insertar(CType(pvABNTRP, cClaseNodo))
    End Function

End Class