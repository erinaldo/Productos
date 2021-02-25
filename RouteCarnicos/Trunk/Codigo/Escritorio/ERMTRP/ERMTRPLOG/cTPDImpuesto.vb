Imports BASLOG

Public Class cTPDImpuesto
    Inherits BASLOG.cClaseNodo

#Region "Propiedades"
    Public ReadOnly Property TransProdDetalleID() As String
        Get
            Return Me.Padre.ObtenerValorPropiedad("TransProdDetalleID")
        End Get
    End Property

    Public Property TransProdID() As String
        Get
            Return Me.Tabla.Campos("TransProdID").Valor
        End Get
        Set(ByVal Value As String)
            If Me.Status = eEstado.Vacio Or Me.Status = eEstado.Nuevo Then
                Me.Tabla.Campos("TransProdID").Valor = Value
            End If
        End Set
    End Property

    Public Property TPDImpuestoID() As String
        Get
            Return Me.Tabla.Campos("TPDImpuestoID").Valor
        End Get
        Set(ByVal Value As String)
            If Me.Status = eEstado.Vacio Or Me.Status = eEstado.Nuevo Then
                Me.Tabla.Campos("TPDImpuestoID").Valor = Value
            End If
        End Set
    End Property

    Public Property ImpuestoClave() As String
        Get
            Return Me.Tabla.Campos("ImpuestoClave").Valor
        End Get
        Set(ByVal Value As String)
            Me.Tabla.Campos("ImpuestoClave").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property ImpuestoPor() As Double
        Get
            Return Me.Tabla.Campos("ImpuestoPor").Valor
        End Get
        Set(ByVal Value As Double)
            Me.Tabla.Campos("ImpuestoPor").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property ImpuestoImp() As Double
        Get
            Return Me.Tabla.Campos("ImpuestoImp").Valor
        End Get
        Set(ByVal Value As Double)
            Me.Tabla.Campos("ImpuestoImp").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property ImpuestoPU() As Double
        Get
            Return Me.Tabla.Campos("ImpuestoPU").Valor
        End Get
        Set(ByVal Value As Double)
            Me.Tabla.Campos("ImpuestoPU").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property ImpDesGlb() As Double
        Get
            Return Me.Tabla.Campos("ImpDesGlb").Valor
        End Get
        Set(ByVal Value As Double)
            Me.Tabla.Campos("ImpDesGlb").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property
#End Region

#Region "Constructores"
    Public Sub New(ByRef prPadre As cTransProdDetalle)
        MyBase.New(prPadre)
    End Sub
#End Region

#Region "Sobreescritos"
    Protected Overrides Sub CrearEstructuraTabla()
        With Me.Tabla
            .AgregarCampo(New LbDatos.cCampo("TransProdID", LbDatos.ETipo.Cadena, "", True, True))
            .AgregarCampo(New LbDatos.cCampo("TransProdDetalleID", LbDatos.ETipo.Cadena, "", True, True))
            .AgregarCampo(New LbDatos.cCampo("TPDImpuestoID", LbDatos.ETipo.Cadena, "", True, True, True))
            .AgregarCampo(New LbDatos.cCampo("ImpuestoClave", LbDatos.ETipo.Cadena, True))
            .AgregarCampo(New LbDatos.cCampo("ImpuestoPor", LbDatos.ETipo.Numerico, True))
            .AgregarCampo(New LbDatos.cCampo("ImpuestoImp", LbDatos.ETipo.Numerico, True))
            .AgregarCampo(New LbDatos.cCampo("ImpuestoPU", LbDatos.ETipo.Numerico, False))
            .AgregarCampo(New LbDatos.cCampo("ImpDesGlb", LbDatos.ETipo.Numerico, False))
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
        Return "TPDImpuesto"
    End Function
#End Region

#Region "Sobrecargados Especificos"

    Public Overloads Sub Recuperar(ByVal pvTransProdID As String, ByVal pvTransProdDetalleID As String, ByVal pvTPDImpuestoID As String)
        Me.Limpiar()
        Me.Tabla.Campos("TransProdDetalleID").Valor = pvTransProdDetalleID
        Me.TransProdID = pvTransProdID
        Me.TPDImpuestoID = pvTPDImpuestoID
        Me.Recuperar()
    End Sub

    Public Overloads Function Existe(ByVal pvTransProdID As String, ByVal pvTransProdDetalleID As String, ByVal pvTPDImpuestoID As String) As Boolean
        Return (Me.Tabla.Seleccionar("TransProdID='" & pvTransProdID & "' AND TransProdDetalleID='" & pvTransProdDetalleID & "' AND TPDImpuestoID = '" & pvTPDImpuestoID & "'").Rows.Count > 0)
    End Function

    Public Overloads Sub Insertar(ByVal pvTransProdID As String, ByVal pvTPDImpuestoID As String, ByVal pvImpuestoClave As String, ByVal pvImpuestoPor As Double, ByVal pvImpuestoImp As Double, ByVal pvImpuestoPU As Double, ByVal pvImpDesGlb As Double, Optional ByVal pvCampo() As String = Nothing)
        Me.Limpiar()
        Me.TransProdID = pvTransProdID
        Me.TPDImpuestoID = pvTPDImpuestoID
        Me.ImpuestoClave = pvImpuestoClave
        Me.ImpuestoImp = pvImpuestoImp
        Me.ImpuestoPor = pvImpuestoPor
        Me.ImpuestoPU = pvImpuestoPU
        Me.ImpDesGlb = pvImpDesGlb

        Me.Insertar(pvCampo)
    End Sub
#End Region

End Class


Public Class cCollectionTPDImp
    Inherits cCollectionClaseNodo

    Public Sub New(ByRef prArreglo As ArrayList, ByRef prDT As DataTable, ByRef prTablaTPD As cTablaNodo)
        MyBase.New(prArreglo, prDT, prTablaTPD)
    End Sub

    Public Overloads Function Insertar(ByRef prTPD As cTPDImpuesto) As Integer
        Return MyBase.Insertar(CType(prTPD, cClaseNodo))
    End Function

End Class