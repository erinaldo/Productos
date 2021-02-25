Imports BASLOG

Public Class cCriterioCobranzaDet

    Inherits BASLOG.cClaseNodo

#Region "Variables"

#End Region

#Region "Constructores"

    Public Sub New(ByRef prPadre As cCriterioCobranza)
        MyBase.New(prPadre)
    End Sub

#End Region

#Region "Propiedades"

    Public ReadOnly Property CriterioCobranzaId() As String
        Get
            Return Me.Padre.ObtenerValorPropiedad("CriterioCobranzaId")
        End Get
    End Property

    Public Property CriterioCobranzaDetId() As String
        Get
            Return IIf(Me.Tabla.Campos("CriterioCobranzaDetId").Valor Is System.DBNull.Value, "", Me.Tabla.Campos("CriterioCobranzaDetId").Valor)
        End Get
        Set(ByVal Value As String)
            If Me.Status = eEstado.Vacio Or Me.Status = eEstado.Nuevo Then
                Me.Tabla.Campos("CriterioCobranzaDetId").Valor = Value
            End If
        End Set
    End Property

    Public Property TipoCriterio() As Integer
        Get
            Return IIf(Me.Tabla.Campos("TipoCriterio").Valor Is System.DBNull.Value, 0, Me.Tabla.Campos("TipoCriterio").Valor)
        End Get
        Set(ByVal Value As Integer)
            Me.Tabla.Campos("TipoCriterio").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property


    Public Property Ordenacion() As Integer
        Get
            Return IIf(Me.Tabla.Campos("Ordenacion").Valor Is System.DBNull.Value, 0, Me.Tabla.Campos("Ordenacion").Valor)
        End Get
        Set(ByVal Value As Integer)
            Me.Tabla.Campos("Ordenacion").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property Prioridad() As Integer
        Get
            Return IIf(Me.Tabla.Campos("Prioridad").Valor Is System.DBNull.Value, 0, Me.Tabla.Campos("Prioridad").Valor)
        End Get
        Set(ByVal Value As Integer)
            Me.Tabla.Campos("Prioridad").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property

#End Region

#Region "Sobreescritos"

    Protected Overrides Sub CrearEstructuraTabla()
        With Me.Tabla
            .AgregarCampo(New LbDatos.cCampo("CriterioCobranzaId", LbDatos.ETipo.Cadena, "", True, True, False, True))
            .AgregarCampo(New LbDatos.cCampo("CriterioCobranzaDetId", LbDatos.ETipo.Cadena, "", True, True))
            .AgregarCampo(New LbDatos.cCampo("TipoCriterio", LbDatos.ETipo.Numerico, True))
            .AgregarCampo(New LbDatos.cCampo("Ordenacion", LbDatos.ETipo.Numerico, True))
            .AgregarCampo(New LbDatos.cCampo("Prioridad", LbDatos.ETipo.Numerico, True))
        End With
    End Sub

    Protected Overrides Sub CrearHijos()

    End Sub

    Protected Overrides Function RegresaMnemonico() As String
        Return "CCD"
    End Function

    Protected Overrides Function RegresaNombreTabla() As String
        Return "CriterioCobranzaDet"
    End Function

    Protected Overrides Function RegresaEnsamblado() As System.Reflection.Assembly
        Return System.Reflection.Assembly.GetExecutingAssembly()
    End Function

#End Region

#Region "Sobrecargados Especificos"

    Public Overloads Sub Recuperar(ByVal pvCriterioCobranzaId As String, ByVal pvCriterioCobranzaDetId As String)
        Me.Limpiar()
        Me.Tabla.Campos("CriterioCobranzaId").Valor = pvCriterioCobranzaDetId
        Me.CriterioCobranzaDetId = pvCriterioCobranzaDetId
        Me.Recuperar()
    End Sub

    Public Overloads Function Existe(ByVal pvCriterioCobranzaId As String, ByVal pvCriterioCobranzaDetId As String) As Boolean
        Return (Me.Tabla.Seleccionar("CriterioCobranzaId='" & lbGeneral.ValidaFormatoSQLString(pvCriterioCobranzaId) & "' AND CriterioCobranzaDetId=" & pvCriterioCobranzaDetId).Rows.Count > 0)
    End Function

    Public Overloads Sub Insertar(ByVal pvCriterioCobranzaDetId As String, ByVal pvTipoCriterio As Integer, ByVal pvOrdenacion As Integer, ByVal pvPrioridad As Integer, Optional ByVal pvCampo() As String = Nothing)
        Me.Limpiar()
        Me.CriterioCobranzaDetId = pvCriterioCobranzaDetId
        Me.TipoCriterio = pvTipoCriterio
        Me.Ordenacion = pvOrdenacion
        Me.Prioridad = pvPrioridad
        Me.Insertar(pvCampo)
    End Sub

#End Region
   
End Class

Public Class cCollectionCCD
    Inherits cCollectionClaseNodo


    Public Sub New(ByRef prArreglo As ArrayList, ByRef prDT As DataTable, ByRef prTablaCCD As cTablaNodo)
        MyBase.New(prArreglo, prDT, prTablaCCD)
    End Sub

    Public Overloads Function Insertar(ByRef prCCD As cCriterioCobranzaDet) As Integer
        InsertarEnDataTable(prCCD)
        Return MyBase.Insertar(CType(prCCD, cClaseNodo))
    End Function

    Public Sub InsertarEnDataTable(ByRef prCCD As cCriterioCobranzaDet)
        Dim lDr As DataRow = Me.oDT.NewRow
        For Each loCampo As LbDatos.cCampo In prCCD.Tabla.Campos
            If loCampo.Nombre <> "MFechaHora" And loCampo.Nombre <> "MUsuarioID" Then
                lDr(loCampo.Nombre) = prCCD.ObtenerValorPropiedad(loCampo.Nombre)
            End If
        Next
        Me.oDT.Rows.Add(lDr)
    End Sub

    Public Sub EliminarDeDataTable(ByRef prCCD As cCriterioCobranzaDet)
        Dim drCEP() As DataRow
        drCEP = Me.oDT.Select("CriterioCobranzaDetId = '" & prCCD.CriterioCobranzaDetId & "'")
        If drCEP.Length > 0 Then
            oDT.Rows.Remove(drCEP(0))
        End If
    End Sub

    Public Sub ActualizarEnDataTable(ByRef prCCD As cCriterioCobranzaDet)
        Dim drCEP() As DataRow
        drCEP = Me.oDT.Select("CriterioCobranzaDetId = '" & prCCD.CriterioCobranzaDetId & "'")
        If drCEP.Length > 0 Then
            oDT.Rows(0)("Ordenacion") = prCCD.Ordenacion
            oDT.Rows(0)("Prioridad") = prCCD.Prioridad
        End If
    End Sub

    Public Function ObtenerDataTable() As DataTable
        Return Me.ToDataTable()
    End Function

    Public ReadOnly Property SiguienteOrden() As Integer
        Get
            Dim oCCO As cCriterioCobranzaDet
            Dim nOrdenMayor As Integer
            For Each oCCO In Me.oArreglo
                If oCCO.Status <> eEstado.Eliminado Then
                    nOrdenMayor = IIf(oCCO.Prioridad > nOrdenMayor, oCCO.Prioridad, nOrdenMayor)
                End If
            Next
            Return nOrdenMayor + 1
        End Get
    End Property

End Class
