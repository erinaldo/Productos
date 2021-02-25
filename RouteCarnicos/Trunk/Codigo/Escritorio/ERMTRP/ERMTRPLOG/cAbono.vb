Imports BASLOG

Public Class cAbono
    Inherits BASLOG.cClaseNodo

    Protected oColABNDetalle As cCollectionABNDetalle
    Protected oColAbnTrp As cCollectionABNTRP

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
    Public Property Folio() As String
        Get
            Return DirectCast(Me.Tabla.Campos(1), LbDatos.cCampo).Valor.ToString()
        End Get
        Set(ByVal value As String)
            DirectCast(Me.Tabla.Campos(1), LbDatos.cCampo).Valor = value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property FechaCreacion() As DateTime
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
    Public Property VisitaClave() As String
        Get
            Return DirectCast(Me.Tabla.Campos(3), LbDatos.cCampo).Valor.ToString()
        End Get
        Set(ByVal value As String)
            DirectCast(Me.Tabla.Campos(3), LbDatos.cCampo).Valor = value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property DiaClave() As String
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
    Public Property FechaAbono() As DateTime
        Get
            Return Convert.ToDateTime(DirectCast(Me.Tabla.Campos(5), LbDatos.cCampo).Valor)
        End Get
        Set(ByVal value As DateTime)
            DirectCast(Me.Tabla.Campos(5), LbDatos.cCampo).Valor = value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property Total() As Double
        Get
            Return Convert.ToDouble(DirectCast(Me.Tabla.Campos(6), LbDatos.cCampo).Valor)
        End Get
        Set(ByVal value As Double)
            DirectCast(Me.Tabla.Campos(6), LbDatos.cCampo).Valor = value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property Saldo() As Double
        Get
            Return Convert.ToDouble(DirectCast(Me.Tabla.Campos(7), LbDatos.cCampo).Valor)
        End Get
        Set(ByVal value As Double)
            DirectCast(Me.Tabla.Campos(7), LbDatos.cCampo).Valor = value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property
#End Region

    Public Function AbnTrp() As cCollectionABNTRP
        Return Me.oColAbnTrp
    End Function

    Public Function ABNDetalle() As cCollectionABNDetalle
        Return oColABNDetalle
    End Function

    Public Sub New()
        MyBase.New()
    End Sub

#Region "SobreEscritos"

    Protected Overrides Sub CrearEstructuraTabla()
        Tabla.AgregarCampo(New LbDatos.cCampo("ABNId", LbDatos.ETipo.Cadena, "", True, True))
        Tabla.AgregarCampo(New LbDatos.cCampo("Folio", LbDatos.ETipo.Cadena, True))
        Tabla.AgregarCampo(New LbDatos.cCampo("FechaCreacion", LbDatos.ETipo.FechaHora, True))
        Tabla.AgregarCampo(New LbDatos.cCampo("VisitaClave", LbDatos.ETipo.Cadena, "", False, True, False, True))
        Tabla.AgregarCampo(New LbDatos.cCampo("DiaClave", LbDatos.ETipo.Cadena, "", False, True, False, True))
        Tabla.AgregarCampo(New LbDatos.cCampo("FechaAbono", LbDatos.ETipo.Fecha, True))
        Tabla.AgregarCampo(New LbDatos.cCampo("Total", LbDatos.ETipo.Numerico, True))
        Tabla.AgregarCampo(New LbDatos.cCampo("Saldo", LbDatos.ETipo.Numerico, True))
    End Sub

    Protected Overrides Sub CrearHijos()
        Dim vlHijo As cClaseNodo = New cABNDetalle(Me)
        Me.AgregarHijo(vlHijo.Tabla)
        oColABNDetalle = New cCollectionABNDetalle(Me.RegresaArregloHijo(vlHijo.Tabla.NombreTabla), Me.RegresaDataTableHijo(vlHijo.Tabla.NombreTabla), vlHijo.TablaNodo)

        Dim vlHijoAbn As cClaseNodo
        vlHijoAbn = New cAbnTrp(Me)
        Me.AgregarHijo(vlHijoAbn.Tabla)
        Me.oColAbnTrp = New cCollectionABNTRP(Me.RegresaArregloHijo(vlHijoAbn.Tabla.NombreTabla), Me.RegresaDataTableHijo(vlHijoAbn.Tabla.NombreTabla), vlHijoAbn.TablaNodo)

    End Sub

    Protected Overrides Function RegresaEnsamblado() As System.Reflection.Assembly
        Return System.Reflection.Assembly.GetExecutingAssembly()
    End Function

    Protected Overrides Function RegresaMnemonico() As String
        Return "ABN"
    End Function

    Protected Overrides Function RegresaNombreTabla() As String
        Return "Abono"
    End Function
#End Region

#Region "SobreCargas Especificas"
    Public Overloads Sub Recuperar(ByVal pvABNId As String)
        Me.Limpiar()
        Me.ABNId = pvABNId
        Me.Recuperar()
    End Sub

    Public Function Existe(ByVal pvABNId As String) As Boolean
        Return (Me.Tabla.Seleccionar("ABNId='" & pvABNId & "'").Rows.Count > 0)
    End Function

#End Region


End Class

Public Class cCollectionAbono
    Inherits cCollectionClaseNodo
    Public Sub New(ByRef prArreglo As System.Collections.ArrayList, ByRef prDT As System.Data.DataTable, ByRef prTablaTPD As cTablaNodo)

        MyBase.New(prArreglo, prDT, prTablaTPD)
    End Sub
    Public Overloads Function Insertar(ByRef pvAbono As cAbono) As Integer

        Return MyBase.Insertar(CType(pvAbono, cClaseNodo))
    End Function

End Class

