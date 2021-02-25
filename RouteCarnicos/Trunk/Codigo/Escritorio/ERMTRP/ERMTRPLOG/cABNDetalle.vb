Imports BASLOG

Public Class cABNDetalle
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
    Public Property ABDId() As String
        Get
            Return DirectCast(Me.Tabla.Campos(1), LbDatos.cCampo).Valor.ToString()
        End Get
        Set(ByVal value As String)
            If Me.Status = eEstado.Vacio Or Me.Status = eEstado.Nuevo Then
                DirectCast(Me.Tabla.Campos(1), LbDatos.cCampo).Valor = value
            End If
        End Set
    End Property
    Public Property TipoPago() As Int16
        Get
            Return Convert.ToInt16(DirectCast(Me.Tabla.Campos(2), LbDatos.cCampo).Valor)
        End Get
        Set(ByVal value As Int16)
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
    Public Property SaldoDeposito() As Double
        Get
            Return Convert.ToDouble(DirectCast(Me.Tabla.Campos(4), LbDatos.cCampo).Valor.ToString())
        End Get
        Set(ByVal value As Double)
            DirectCast(Me.Tabla.Campos(4), LbDatos.cCampo).Valor = value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property MonedaId() As String
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
    Public Property TipoBanco() As String
        Get
            Return DirectCast(Me.Tabla.Campos(6), LbDatos.cCampo).Valor.ToString()
        End Get
        Set(ByVal value As String)
            DirectCast(Me.Tabla.Campos(6), LbDatos.cCampo).Valor = value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property Referencia() As String
        Get
            Return DirectCast(Me.Tabla.Campos(7), LbDatos.cCampo).Valor.ToString()
        End Get
        Set(ByVal value As String)
            DirectCast(Me.Tabla.Campos(7), LbDatos.cCampo).Valor = value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property
#End Region

    Public Sub New(ByVal prPadre As cAbono)
        MyBase.New(prPadre)
    End Sub

#Region "SobreEscritos"
    Protected Overrides Sub CrearHijos()

    End Sub

    Protected Overrides Sub CrearEstructuraTabla()
        Tabla.AgregarCampo(New LbDatos.cCampo("ABNId", LbDatos.ETipo.Cadena, "", True, True, False, False))
        Tabla.AgregarCampo(New LbDatos.cCampo("ABDId", LbDatos.ETipo.Cadena, "", True, True, False, False))
        Tabla.AgregarCampo(New LbDatos.cCampo("TipoPago", LbDatos.ETipo.Numerico, True))
        Tabla.AgregarCampo(New LbDatos.cCampo("Importe", LbDatos.ETipo.Numerico, True))
        Tabla.AgregarCampo(New LbDatos.cCampo("SaldoDeposito", LbDatos.ETipo.Numerico, True))
        Tabla.AgregarCampo(New LbDatos.cCampo("MonedaId", LbDatos.ETipo.Cadena, Nothing, False, False, True, True))
        Tabla.AgregarCampo(New LbDatos.cCampo("TipoBanco", LbDatos.ETipo.Numerico, Nothing, False, False, True, False))
        Tabla.AgregarCampo(New LbDatos.cCampo("Referencia", LbDatos.ETipo.Cadena, False))

    End Sub

    Protected Overrides Function RegresaEnsamblado() As System.Reflection.Assembly
        Return System.Reflection.Assembly.GetExecutingAssembly()

    End Function

    Protected Overrides Function RegresaMnemonico() As String
        Return "ABN"

    End Function

    Protected Overrides Function RegresaNombreTabla() As String
        Return "ABNDetalle"

    End Function
#End Region

#Region "SobreCargas Especificas"

    Public Overloads Sub Recuperar(ByVal pvABNId As String)
        Me.Limpiar()
        Me.ABNId = pvABNId
        Me.Recuperar()
    End Sub

    Public Overloads Function Existe(ByVal pvABNId As String, ByVal pvABDId As String) As Boolean
        Return (Me.Tabla.Seleccionar("ABNId='" & pvABNId & "' AND ABDId='" & pvABDId & "'").Rows.Count > 0)
    End Function

#End Region

End Class

Public Class cCollectionABNDetalle
    Inherits cCollectionClaseNodo
    Public Sub New(ByRef prArreglo As System.Collections.ArrayList, ByRef prDT As System.Data.DataTable, ByRef prTablaTPD As cTablaNodo)
        MyBase.New(prArreglo, prDT, prTablaTPD)
    End Sub

    Public Overloads Function Insertar(ByRef pvABNDetalle As cABNDetalle) As Integer
        Return MyBase.Insertar(CType(pvABNDetalle, cClaseNodo))
    End Function

End Class
