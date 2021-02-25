Imports LbDatos
Public Class CCEERegimenFiscal

    Public vctCEERegimen As LbDatos.cTabla
    Public Shared vcConexion As LbConexion.cConexion = LbConexion.cConexion.Instancia
    Public Tabla As CCRFTabla
    Public vcCentroExp As CCentroExp
    'Private vcEstado As eEstado
    'Public DataSet As CCentroExpDataSet

#Region "Propiedades"

    Public ReadOnly Property Conexion() As LbConexion.cConexion
        Get
            Return vcConexion
        End Get
    End Property

    Public Property RegimenFiscalId() As String
        Get
            Return vctCEERegimen.Campos("RegimenFiscalId").Valor
        End Get
        Set(ByVal Value As String)
            vctCEERegimen.Campos("RegimenFiscalId").Valor = Value
        End Set
    End Property

    Public Property CentroExpID() As String
        Get
            Return vctCEERegimen.Campos("CentroExpID").Valor
        End Get
        Set(ByVal Value As String)
            vctCEERegimen.Campos("CentroExpID").Valor = Value
        End Set
    End Property

    Public Property TipoRegimen() As Integer
        Get
            Return vctCEERegimen.Campos("TipoRegimen").Valor
        End Get
        Set(ByVal Value As Integer)
            vctCEERegimen.Campos("TipoRegimen").Valor = Value
        End Set
    End Property

    Public Property MUsuarioID() As String
        Get
            Return vctCEERegimen.Campos("MUsuarioID").Valor
        End Get
        Set(ByVal Value As String)
            vctCEERegimen.Campos("MUsuarioID").Valor = Value
        End Set
    End Property

    Public ReadOnly Property MFechaHora() As Date
        Get
            Return vctCEERegimen.Campos("MFechaHora").Valor
        End Get
    End Property

    'Public ReadOnly Property Estado() As eEstado
    '    Get
    '        Return vcEstado
    '    End Get
    'End Property

#End Region

    Public Sub New(ByRef prCentroExp As CCentroExp)

        vcCentroExp = prCentroExp
        vctCEERegimen = New LbDatos.cTabla("CEERegimenFiscal")

        With vctCEERegimen
            .AgregarCampo(New LbDatos.cCampo("RegimenFiscalId", LbDatos.ETipo.Cadena, "", True, True, False, False))
            .AgregarCampo(New LbDatos.cCampo("CentroExpID", LbDatos.ETipo.Cadena, "", False, True, False, True))
            .AgregarCampo(New LbDatos.cCampo("TipoRegimen", LbDatos.ETipo.Numerico, True))
            .AgregarCampo(New LbDatos.cCampo("MFechaHora", LbDatos.ETipo.MFechaHora, "", False, True))
            .AgregarCampo(New LbDatos.cCampo("MUsuarioId", LbDatos.ETipo.Cadena, True))
        End With

        Tabla = New CCRFTabla(vctCEERegimen)
        'DataSet = New CCentroExpDataSet(vctCentroExp)
    End Sub

    Public Function Insertar(ByVal pvTipoRegimen As Integer, ByVal pvMUsuarioId As String) As Boolean
        Try
            Limpiar()

            RegimenFiscalId = lbGeneral.cKeyGen.KEYGEN(1)
            CentroExpID = vcCentroExp.CentroExpID
            TipoRegimen = pvTipoRegimen
            MUsuarioID = pvMUsuarioId
            vctCEERegimen.Campos("MFechaHora").Valor = Conexion.ObtenerFecha

            Return Insertar()
        Catch ex As Exception
            Throw New System.Exception(ex.Message)
            Return False
        End Try
    End Function

    Public Function Insertar() As Boolean
        Try

            If ValidarCampos() Then
                Return vctCEERegimen.Insertar()
            End If

        Catch ex As LbControlError.cError
            ex.Mostrar()
        End Try
    End Function

    Public Function ValidarCampos() As Boolean
        Dim i As Integer

        With vctCEERegimen
            For i = 0 To .Campos.Count - 1
                Dim vlCampo As LbDatos.cCampo
                vlCampo = .Campos(i)

                If Not .Campos(i) Is Nothing Then
                    If vlCampo.Requerido Then
                        If vlCampo.Valor Is Nothing Then
                            Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("CRF" + vlCampo.Nombre, True)}, "CRF" + vlCampo.Nombre)
                            Return False
                        End If
                        If vlCampo.Tipo = LbDatos.ETipo.Cadena Then
                            If vlCampo.Valor = "" Then
                                Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("CRF" + vlCampo.Nombre, True)}, "CRF" + vlCampo.Nombre)
                                Return False
                            End If
                        End If
                    End If
                    Select Case vlCampo.Tipo
                        Case LbDatos.ETipo.Numerico
                            If vlCampo.Valor < 0 Then
                                Throw New LbControlError.cError("E0007", , vlCampo.Nombre)
                                Return False
                            End If
                    End Select
                End If
            Next
        End With

        Return True

    End Function

    Public Sub Limpiar()
        Dim i As Integer
        For i = 0 To vctCEERegimen.Campos.Count - 1
            vctCEERegimen.Campos(i).ADefault()
        Next
    End Sub

    Public Function Recuperar(ByVal pvRegimenFiscalId As String) As Boolean

        Dim dt As DataTable = vctCEERegimen.Seleccionar("RegimenFiscalId='" + pvRegimenFiscalId.Replace("'", "''") + "'")

        If dt.Rows.Count > 0 Then

            Dim dr As DataRow = dt.Rows(0)

            For Each vlCampo As LbDatos.cCampo In vctCEERegimen.Campos
                vlCampo.Valor = dr(vlCampo.Nombre)
            Next

            Return True

        Else
            Return False
        End If

    End Function

    Public Function Seleccionar(ByVal pvRegimenFiscalId As String) As DataTable
        Dim dt As DataTable = vctCEERegimen.Seleccionar("RegimenFiscalId='" + pvRegimenFiscalId.Replace("'", "''") + "'")
        Return dt
    End Function

    Public Function Existe(ByVal pvTipoRegimen As Integer) As Boolean
        Dim vlDtEsquema As DataTable

        vlDtEsquema = vctCEERegimen.Seleccionar("CentroExpId='" & vcCentroExp.CentroExpID.Replace("'", "''") & "' and TipoRegimen = " & pvTipoRegimen)
        If vlDtEsquema.Rows.Count > 0 Then
            Return True
        End If

        Return False
    End Function

    Public Sub Eliminar()
        vctCEERegimen.Eliminar()
    End Sub

    'Public Function Grabar() As Boolean
    '    Select Case vcEstado
    '        Case eEstado.Nuevo
    '            If Not Validar() Then Return False
    '            vcTbProductoImpuesto.Insertar()
    '        Case eEstado.Modificado
    '            vcTbProductoImpuesto.Modificar()
    '    End Select
    '    Return True
    'End Function
End Class

Public Class CCRFTabla
    Private vlTbCRF As LbDatos.cTabla

    Public Sub New(ByVal pvTbCRF As LbDatos.cTabla)
        vlTbCRF = pvTbCRF
    End Sub

    Public Function Recuperar(ByVal pvCentroExpId As String) As DataTable
        Dim vldt As New DataTable
        Dim sConsulta As String
        Try
            sConsulta = "select convert(bit, case when RegimenFiscalId is null then 0 else 1 end) as Seleccionado, RegimenFiscalId, VAV.VAVClave as TipoRegimen "
            sConsulta &= "from VARValor VAV "
            sConsulta &= "left join CEERegimenFiscal CRF on VAV.VAVClave = CRF.TipoRegimen and CRF.CentroExpId = '" & pvCentroExpId & "' "
            sConsulta &= "where VAV.VARCodigo = 'TIPREG' "

            vldt = vlTbCRF.Conexion.EjecutarConsulta(sConsulta, True) 'vlTbCRF.Seleccionar(pvFiltro, pvCampos)
            '//Interaccion para crear el item
        Catch ex As LbControlError.cError
            Throw ex
        End Try

        Return vldt

    End Function

    Public Sub InsertarEn(ByRef prDataTable As DataTable)
        vlTbCRF.Insertar(prDataTable)
    End Sub

    Public Sub ModificarEn(ByRef prDataTable As DataTable)
        vlTbCRF.Modificar(prDataTable)
    End Sub

  
End Class