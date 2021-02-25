Imports BASLOG

Public Class cCriterioCobranza
    Inherits BASLOG.cClaseNodo

#Region "Variables"
    Protected oColCCD As cCollectionCCD
#End Region

#Region "Constructores"

#End Region

#Region "Propiedades"

    Public Property CriterioCobranzaId() As String
        Get
            Return IIf(Me.Tabla.Campos("CriterioCobranzaId").Valor Is System.DBNull.Value, "", Me.Tabla.Campos("CriterioCobranzaId").Valor)
        End Get
        Set(ByVal Value As String)
            If Me.Status = eEstado.Vacio Or Me.Status = eEstado.Nuevo Then
                Me.Tabla.Campos("CriterioCobranzaId").Valor = Value
            End If
        End Set
    End Property

    Public Property CobrarVentas() As Boolean
        Get
            Return IIf(Me.Tabla.Campos("CobrarVentas").Valor Is System.DBNull.Value, False, Me.Tabla.Campos("CobrarVentas").Valor)
        End Get
        Set(ByVal Value As Boolean)
            Me.Tabla.Campos("CobrarVentas").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public ReadOnly Property CriterioCobranzaDet(ByVal pvCriterioCobranzaDetId As String) As cCriterioCobranzaDet
        Get
            Dim oArr As ArrayList
            Dim oCCD As cCriterioCobranzaDet 

            oArr = Me.RegresaArregloHijo("CriterioCobranzaDet")

            For Each oCCD In oArr
                If (oCCD.CriterioCobranzaDetId = pvCriterioCobranzaDetId) Then
                    Return oCCD
                End If
            Next

            Return Nothing
        End Get
    End Property

    Public ReadOnly Property CriterioCobranzaDet() As cCollectionCCD
        Get
            Return oColCCD
        End Get
    End Property

 
#End Region

#Region "Sobreescritos"

    Protected Overrides Sub CrearEstructuraTabla()

        With Me.Tabla
            .AgregarCampo(New LbDatos.cCampo("CriterioCobranzaId", LbDatos.ETipo.Cadena, "", True, True))
            .AgregarCampo(New LbDatos.cCampo("CobrarVentas", LbDatos.ETipo.Bit, True))
        End With

    End Sub

    Protected Overrides Sub CrearHijos()
        Dim vlHijo As cClaseNodo

        vlHijo = New cCriterioCobranzaDet(Me)
        Me.AgregarHijo(vlHijo.Tabla)
        oColCCD = New cCollectionCCD(Me.RegresaArregloHijo(vlHijo.Tabla.NombreTabla), Me.RegresaDataTableHijo(vlHijo.Tabla.NombreTabla), vlHijo.TablaNodo)

    End Sub

    'Protected Overrides Sub ValidaCampo(ByVal pvNombre As String)
    '    If tEstado = eEstado.Vacio Or tEstado = eEstado.Nuevo Then
    '        If pvNombre = "ESRClave" Then
    '            If Existe(Me.ESRClave) Then
    '                Throw New LbControlError.cError("BE0002", , Me.Tabla.Campos(pvNombre).Nombre, , Me.Tabla.Conexion)
    '            End If
    '        End If
    '    End If


    '    Select Case pvNombre
    '        Case "Tipo"
    '            If Me.Tipo <= 0 Then
    '                Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(Me.Mnemonico & Me.Tabla.Campos(pvNombre).Nombre, True)}, Me.Tabla.Campos(pvNombre).Nombre, , Me.Tabla.Conexion)
    '            End If

    '    End Select

    '    MyBase.ValidaCampo(pvNombre)
    'End Sub

    'Public Overrides Sub ValidarClase(ByVal pvCampo() As String)
    '    MyBase.ValidarClase(pvCampo)
    '    If Me.Hueco.Count = 0 Then
    '        Throw New LbControlError.cError("E0173", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("XHueco", True)}, "Hueco", , Me.Tabla.Conexion)
    '    End If
    'End Sub

    Protected Overrides Function RegresaMnemonico() As String
        Return "CCO"
    End Function

    Protected Overrides Function RegresaNombreTabla() As String
        Return "CriterioCobranza"
    End Function

    Protected Overrides Function RegresaEnsamblado() As System.Reflection.Assembly
        Return System.Reflection.Assembly.GetExecutingAssembly()
    End Function

#End Region

#Region "Sobrecargados Especificos"

    Public Overloads Sub Recuperar(ByVal pvCriterioCobranzaId As String)
        Me.Limpiar()
        Me.CriterioCobranzaId = pvCriterioCobranzaId
        Me.Recuperar()
    End Sub

    Public Overloads Function Existe(ByVal pvCriterioCobranzaId As String) As Boolean
        Return (Me.Tabla.Seleccionar("CriterioCobranzaId='" & lbGeneral.ValidaFormatoSQLString(pvCriterioCobranzaId) & "'").Rows.Count > 0)
    End Function

    Public Overloads Sub Insertar(ByVal pvCriterioCobranzaId As String, ByVal pvCobrarVentas As Boolean, Optional ByVal pvCampo() As String = Nothing)

        Me.Limpiar()
        Me.CriterioCobranzaId = pvCriterioCobranzaId
        Me.CobrarVentas = pvCobrarVentas

        Me.Insertar(pvCampo)

    End Sub

    Public Overloads Sub Validar()
        Dim bValido As Boolean = False
        If Me.CriterioCobranzaDet.Count > 0 Then
            For Each oCCD As cCriterioCobranzaDet In Me.CriterioCobranzaDet.ToArrayList
                If oCCD.Status <> eEstado.Eliminado Then
                    bValido = True
                End If
            Next
        End If
        If Not bValido Then
            Throw New LbControlError.cError("E0792")
        End If
    End Sub

#End Region

    Public Function RecuperaAsignado(ByVal bCobrarVentas As Boolean) As Boolean
        Dim sConsulta As String = String.Empty
        Dim sCritCobranzaId As String = String.Empty
        sConsulta = "select CriterioCobranzaId from CriterioCobranza where CobrarVentas = " & Int(bCobrarVentas)
        sCritCobranzaId = LbConexion.cConexion.Instancia.EjecutarComandoScalar(sConsulta)
        If sCritCobranzaId <> String.Empty Then
            Me.Recuperar(sCritCobranzaId)
            Return True
        Else
            Return False
        End If
    End Function

    Public Function ObtenerCriteriosNoAsignados(ByVal bCobrarVentas As Boolean) As DataTable
        Dim dtCriterios As DataTable = Nothing
        Dim sConsulta As String = String.Empty
        sConsulta = "select VAVClave as TipoCriterio "
        sConsulta &= "from VARValor VAV "
        sConsulta &= "where VARCodigo = 'TIPCRI' and VAVClave not in ( "
        sConsulta &= "select CCD.TipoCriterio "
        sConsulta &= "from CriterioCobranzaDet CCD "
        sConsulta &= "inner join CriterioCobranza CCO on CCD.CriterioCobranzaId = CCO.CriterioCobranzaId "
        sConsulta &= "where CCO.CriterioCobranzaId = '" & Me.CriterioCobranzaId & "') "
        sConsulta &= "and Grupo in ('Ambos','" & IIf(Me.CobrarVentas, "Venta", "Factura") & "') "
        dtCriterios = LbConexion.cConexion.Instancia.EjecutarConsulta(sConsulta)
        Return dtCriterios
    End Function

    'Public Function ObtenerCriteriosAsignados(ByVal bCobrarVentas As Boolean) As DataTable
    '    Dim dtCriterios As DataTable = Nothing
    '    Dim sConsulta As String = String.Empty
    '    sConsulta = "select CCO.CriterioCobranzaId, CCD.CriterioCobranzaDetId, CCD.TipoCriterio, CCD.Ordenacion, CCD.Prioridad "
    '    sConsulta &= "from CriterioCobranza CCO "
    '    sConsulta &= "inner join CriterioCobranzaDet CCD on CCO.CriterioCobranzaId = CCD.CriterioCobranzaId "
    '    sConsulta &= "where CobrarVentas = " & Int(bCobrarVentas) & " "
    '    sConsulta &= "order by Prioridad "
    '    dtCriterios = LbConexion.cConexion.Instancia.EjecutarConsulta(sConsulta)
    '    Return dtCriterios
    'End Function

    Public Function ObtenerCriteriosAsignados() As DataTable
        Dim dtCriterios As DataTable = Nothing
        Dim sConsulta As String = String.Empty
        sConsulta = "select CCO.CriterioCobranzaId, CCD.CriterioCobranzaDetId, CCD.TipoCriterio, CCD.Ordenacion, CCD.Prioridad "
        sConsulta &= "from CriterioCobranza CCO "
        sConsulta &= "inner join CriterioCobranzaDet CCD on CCO.CriterioCobranzaId = CCD.CriterioCobranzaId "
        sConsulta &= "where CCO.CriterioCobranzaId = '" & Me.CriterioCobranzaId & "' "
        sConsulta &= "order by Prioridad "
        dtCriterios = LbConexion.cConexion.Instancia.EjecutarConsulta(sConsulta)
        Return dtCriterios
    End Function

    'Protected Overrides Sub GrabarHijos(ByVal pvNombreHijo As String)
    '    If pvNombreHijo = "CENPregunta" Then
    '        Dim oArrHijos As ArrayList
    '        Dim vlHijo As cClaseNodo
    '        Dim i As Integer

    '        oArrHijos = RegresaArregloHijo(pvNombreHijo).Clone()


    '        Select Case Me.Status

    '            Case eEstado.Vacio

    '            Case eEstado.Recuperado, eEstado.Modificado

    '                Dim lstIndicesSaltos As New Hashtable
    '                Dim oArrSalto As New ArrayList

    '                i = 0
    '                Dim index As Integer
    '                While i < oArrHijos.Count
    '                    If CType(oArrHijos(i), cCENPregunta).Status <> eEstado.Eliminado Then
    '                        If CType(oArrHijos(i), cCENPregunta).TipoRespuesta = 7 Then
    '                            index = oArrSalto.Add(oArrHijos(i))
    '                            lstIndicesSaltos.Add(CType(oArrHijos(i), cCENPregunta).CEPNumero, index)
    '                            i = i + 1
    '                        Else
    '                            If oArrHijos(i).Grabar() <> eEstado.Eliminado Then
    '                                i = i + 1
    '                            End If
    '                        End If
    '                    Else
    '                        i = i + 1
    '                    End If
    '                End While
    '                i = 0

    '                Dim oCENPregunta As cCENPregunta
    '                While i < oArrSalto.Count
    '                    oCENPregunta = oArrSalto(i)
    '                    If oCENPregunta.Status <> eEstado.Recuperado AndAlso oCENPregunta.Status <> eEstado.Vacio Then
    '                        If oCENPregunta.CEPRespSalto.ToArrayList(0).CEPSiguienteCond <> 0 Then
    '                            If CType(oArrSalto(lstIndicesSaltos(oCENPregunta.CEPRespSalto.ToArrayList(0).CEPSiguienteCond)), cCENPregunta).Status = eEstado.Nuevo Then
    '                                CType(oArrSalto(lstIndicesSaltos(oCENPregunta.CEPRespSalto.ToArrayList(0).CEPSiguienteCond)), cCENPregunta).Grabar()
    '                            End If
    '                        End If
    '                        If oCENPregunta.Grabar() <> eEstado.Eliminado Then
    '                            i = i + 1
    '                        End If
    '                    Else
    '                        i = i + 1
    '                    End If
    '                End While

    '                For Each CENPreg As cCENPregunta In oArrHijos
    '                    If CENPreg.Status = eEstado.Eliminado And CENPreg.TipoRespuesta = 7 Then
    '                        CENPreg.Grabar()
    '                    End If
    '                Next
    '                For Each CENPreg As cCENPregunta In oArrHijos
    '                    If CENPreg.Status = eEstado.Eliminado And CENPreg.TipoRespuesta <> 7 Then
    '                        CENPreg.Grabar()
    '                    End If
    '                Next

    '            Case eEstado.Nuevo
    '                Dim lstSaltos As New Hashtable

    '                For Each vlHijo In oArrHijos
    '                    If CType(vlHijo, cCENPregunta).TipoRespuesta = 7 Then
    '                        lstSaltos.Add(CType(vlHijo, cCENPregunta).CEPNumero, vlHijo)
    '                    Else
    '                        vlHijo.Grabar()
    '                    End If
    '                Next


    '                For Each oCENPregunta As cCENPregunta In lstSaltos.Values()
    '                    If oCENPregunta.Status <> eEstado.Recuperado AndAlso oCENPregunta.Status <> eEstado.Vacio Then
    '                        If oCENPregunta.CEPRespSalto.ToArrayList(0).CEPSiguienteCond <> 0 Then
    '                            If CType(lstSaltos(oCENPregunta.CEPRespSalto.ToArrayList(0).CEPSiguienteCond), cCENPregunta).Status = eEstado.Nuevo Then
    '                                CType(lstSaltos(oCENPregunta.CEPRespSalto.ToArrayList(0).CEPSiguienteCond), cCENPregunta).Grabar()
    '                            End If
    '                        End If
    '                        oCENPregunta.Grabar()
    '                    End If
    '                Next

    '            Case eEstado.Eliminado

    '                'For i = 0 To oArrHijo.Count - 1
    '                i = 0
    '                While i < oArrHijos.Count
    '                    If oArrHijos(i).Status = eEstado.Modificado Or oArrHijos(i).Status = eEstado.Recuperado Or oArrHijos(i).Status = eEstado.Eliminado Then
    '                        oArrHijos(i).Eliminar()
    '                        If oArrHijos(i).Grabar() = eEstado.Eliminado Then
    '                            If i >= oArrHijos.Count Then
    '                                Exit While
    '                            End If
    '                            i = i - 1
    '                        End If
    '                    End If
    '                    i += 1
    '                End While
    '                'Next

    '        End Select

    '    Else
    '        MyBase.GrabarHijos(pvNombreHijo)
    '    End If
    'End Sub
End Class
