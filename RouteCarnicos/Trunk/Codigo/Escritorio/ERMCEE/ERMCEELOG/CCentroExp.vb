Public Class CCentroExp

    Public vctCentroExp As LbDatos.cTabla
    Public Shared vcConexion As LbConexion.cConexion = LbConexion.cConexion.Instancia
    Public Tabla As CCentroExpTabla
    Public DataSet As CCentroExpDataSet
    Private vcCRFArray As New ArrayList

#Region "Propiedades"

    Public ReadOnly Property Conexion() As LbConexion.cConexion
        Get
            Return vcConexion
        End Get
    End Property

    Public Property CentroExpID() As String
        Get
            Return vctCentroExp.Campos("CentroExpID").Valor
        End Get
        Set(ByVal Value As String)

            vctCentroExp.Campos("CentroExpID").Valor = Value

        End Set
    End Property

    Public Property CentroExpPadreID() As String
        Get
            If Not IsDBNull(vctCentroExp.Campos("CentroExpPadreID").Valor) Then
                Return vctCentroExp.Campos("CentroExpPadreID").Valor
            Else
                Return ""
            End If

        End Get
        Set(ByVal Value As String)

            vctCentroExp.Campos("CentroExpPadreID").Valor = Value

            If Value.Length = 0 Then
                vctCentroExp.Campos("CentroExpPadreID").Valor = Nothing
            End If

        End Set
    End Property
   
    Public Property Nombre() As String
        Get
            Return vctCentroExp.Campos("Nombre").Valor
        End Get
        Set(ByVal Value As String)

            vctCentroExp.Campos("Nombre").Valor = Value

        End Set
    End Property

    Public Property Tipo() As Integer
        Get
            Return vctCentroExp.Campos("Tipo").Valor
        End Get
        Set(ByVal Value As Integer)
            vctCentroExp.Campos("Tipo").Valor = Value
        End Set
    End Property

    Public Property SubEmpresaId() As String
        Get
            If Not IsDBNull(vctCentroExp.Campos("SubEmpresaId").Valor) Then
                Return vctCentroExp.Campos("SubEmpresaId").Valor
            Else
                Return ""
            End If

        End Get
        Set(ByVal Value As String)

            vctCentroExp.Campos("SubEmpresaId").Valor = Value

        End Set
    End Property

    Public Property NumCertificado() As String
        Get
            If Not IsDBNull(vctCentroExp.Campos("NumCertificado").Valor) Then
                Return vctCentroExp.Campos("NumCertificado").Valor
            Else
                Return ""
            End If

        End Get
        Set(ByVal Value As String)

            vctCentroExp.Campos("NumCertificado").Valor = Value

        End Set
    End Property
    Public Property RFC() As String
        Get
            If IsDBNull(vctCentroExp.Campos("RFC").Valor) Then
                Return ""
            Else
                Return vctCentroExp.Campos("RFC").Valor
            End If
            Return vctCentroExp.Campos("RFC").Valor
        End Get
        Set(ByVal Value As String)

            vctCentroExp.Campos("RFC").Valor = Value

        End Set
    End Property



    Public Property Calle() As String
        Get
            Return vctCentroExp.Campos("Calle").Valor
        End Get
        Set(ByVal Value As String)
            vctCentroExp.Campos("Calle").Valor = Value
        End Set
    End Property
    Public Property NumExt() As String
        Get
            Return vctCentroExp.Campos("NumExt").Valor
        End Get
        Set(ByVal Value As String)
            vctCentroExp.Campos("NumExt").Valor = Value
        End Set
    End Property
    Public Property NumInt() As String
        Get
            Return vctCentroExp.Campos("NumInt").Valor
        End Get
        Set(ByVal Value As String)
            vctCentroExp.Campos("NumInt").Valor = Value
        End Set
    End Property
    Public Property Colonia() As String
        Get
            Return vctCentroExp.Campos("Colonia").Valor
        End Get
        Set(ByVal Value As String)
            vctCentroExp.Campos("Colonia").Valor = Value
        End Set
    End Property
    Public Property CodigoPostal() As String
        Get
            Return vctCentroExp.Campos("CodigoPostal").Valor
        End Get
        Set(ByVal Value As String)
            vctCentroExp.Campos("CodigoPostal").Valor = Value
        End Set
    End Property
    Public Property ReferenciaDom() As String
        Get
            Return vctCentroExp.Campos("ReferenciaDom").Valor
        End Get
        Set(ByVal Value As String)
            vctCentroExp.Campos("ReferenciaDom").Valor = Value
        End Set
    End Property
    Public Property Localidad() As String
        Get
            Return vctCentroExp.Campos("Localidad").Valor
        End Get
        Set(ByVal Value As String)
            vctCentroExp.Campos("Localidad").Valor = Value
        End Set
    End Property
    Public Property Municipio() As String
        Get
            Return vctCentroExp.Campos("Municipio").Valor
        End Get
        Set(ByVal Value As String)
            vctCentroExp.Campos("Municipio").Valor = Value
        End Set
    End Property
    Public Property Entidad() As String
        Get
            Return vctCentroExp.Campos("Entidad").Valor
        End Get
        Set(ByVal Value As String)
            vctCentroExp.Campos("Entidad").Valor = Value
        End Set
    End Property
    Public Property Pais() As String
        Get
            Return vctCentroExp.Campos("Pais").Valor
        End Get
        Set(ByVal Value As String)
            vctCentroExp.Campos("Pais").Valor = Value
        End Set
    End Property

    Public Property TipoEstado() As Integer
        Get
            Return vctCentroExp.Campos("TipoEstado").Valor
        End Get
        Set(ByVal Value As Integer)
            vctCentroExp.Campos("TipoEstado").Valor = Value
        End Set
    End Property

    Public Property MUsuarioID() As String
        Get
            Return vctCentroExp.Campos("MUsuarioID").Valor
        End Get
        Set(ByVal Value As String)

            vctCentroExp.Campos("MUsuarioID").Valor = Value
        End Set
    End Property


    Public Property MFechaHora() As String
        Get
            Return vctCentroExp.Campos("MFechaHora").Valor
        End Get
        Set(ByVal Value As String)

            vctCentroExp.Campos("MFechaHora").Valor = Value

        End Set
    End Property




#End Region

    Public Sub New()

        vctCentroExp = New LbDatos.cTabla("CentroExpedicion")

        With vctCentroExp
            .AgregarCampo(New LbDatos.cCampo("CentroExpID", LbDatos.ETipo.Cadena, "", True, True))
            .AgregarCampo(New LbDatos.cCampo("CentroExpPadreID", LbDatos.ETipo.Cadena, "", False, False, False, True))

            .AgregarCampo(New LbDatos.cCampo("Nombre", LbDatos.ETipo.Cadena, True))
            .AgregarCampo(New LbDatos.cCampo("Tipo", LbDatos.ETipo.Numerico, 0, False))
            .AgregarCampo(New LbDatos.cCampo("SubEmpresaId", LbDatos.ETipo.Cadena, "", False, True, False, True))
            .AgregarCampo(New LbDatos.cCampo("NumCertificado", LbDatos.ETipo.Cadena, "", False, False, False, True))
            .AgregarCampo(New LbDatos.cCampo("RFC", LbDatos.ETipo.Cadena, False))
            .AgregarCampo(New LbDatos.cCampo("Calle", LbDatos.ETipo.Cadena, False))
            .AgregarCampo(New LbDatos.cCampo("NumExt", LbDatos.ETipo.Cadena, False))
            .AgregarCampo(New LbDatos.cCampo("NumInt", LbDatos.ETipo.Cadena, False))
            .AgregarCampo(New LbDatos.cCampo("Colonia", LbDatos.ETipo.Cadena, False))
            .AgregarCampo(New LbDatos.cCampo("CodigoPostal", LbDatos.ETipo.Cadena, False))
            .AgregarCampo(New LbDatos.cCampo("ReferenciaDom", LbDatos.ETipo.Cadena, False))
            .AgregarCampo(New LbDatos.cCampo("Localidad", LbDatos.ETipo.Cadena, False))
            .AgregarCampo(New LbDatos.cCampo("Municipio", LbDatos.ETipo.Cadena, False))
            .AgregarCampo(New LbDatos.cCampo("Entidad", LbDatos.ETipo.Cadena, False))
            .AgregarCampo(New LbDatos.cCampo("Pais", LbDatos.ETipo.Cadena, False))
            .AgregarCampo(New LbDatos.cCampo("TipoEstado", LbDatos.ETipo.Numerico, 1, False))
            .AgregarCampo(New LbDatos.cCampo("MFechaHora", LbDatos.ETipo.MFechaHora, False))
            .AgregarCampo(New LbDatos.cCampo("MUsuarioID", LbDatos.ETipo.Cadena, True))

        End With
        Tabla = New CCentroExpTabla(vctCentroExp)
        DataSet = New CCentroExpDataSet(vctCentroExp)
    End Sub

    Public Function Insertar(ByVal PvCentroExpID As String, ByVal PvCentroExpPadreID As String, ByVal PvNombre As String, ByVal PvTipo As Integer, ByVal pvSubEmpresa As String, ByVal PvNumCertificado As String, ByVal PvRFC As String, ByVal PvCalle As String, ByVal PvNumExt As String, ByVal PvNumInt As String, ByVal PvColonia As String, ByVal PvCodigoPostal As String, ByVal PvReferenciaDom As String, ByVal PvLocalidad As String, ByVal PvMunicipio As String, ByVal PvEntidad As String, ByVal PvPais As String, ByVal PvTipoEstado As Integer, ByVal PvMFechaHora As DateTime, ByVal PvMUsuarioID As String) As Boolean
        Try
            Limpiar()
            Dim iKey As New lbGeneral.cKeyGen

            CentroExpID = PvCentroExpID & ""
            CentroExpPadreID = PvCentroExpPadreID & ""
            Nombre = PvNombre
            Tipo = PvTipo
            SubEmpresaId = pvSubEmpresa
            NumCertificado = PvNumCertificado
            RFC = PvRFC
            Calle = PvCalle
            NumExt = PvNumExt
            NumInt = PvNumInt
            Colonia = PvColonia
            CodigoPostal = PvCodigoPostal
            ReferenciaDom = PvReferenciaDom
            Localidad = PvLocalidad
            Municipio = PvMunicipio
            Entidad = PvEntidad
            Pais = PvPais
            TipoEstado = PvTipoEstado
            MFechaHora = PvMFechaHora
            MUsuarioID = PvMUsuarioID



            Return Insertar()
        Catch ex As Exception
            Throw New System.Exception(ex.Message)
            Return False
        End Try
    End Function

    Public Function Insertar() As Boolean
        Try

            If ValidarCampos() Then
                Return vctCentroExp.Insertar()
            End If

        Catch ex As LbControlError.cError
            ex.Mostrar()
        End Try
    End Function

    Public Sub Limpiar()
        Dim i As Integer
        For i = 0 To vctCentroExp.Campos.Count - 1
            vctCentroExp.Campos(i).ADefault()
        Next
    End Sub

    Public Function Recuperar(ByVal pvCentroExpID As String) As Boolean

        Dim dt As DataTable = vctCentroExp.Seleccionar("CentroExpID='" + pvCentroExpID.Replace("'", "''") + "'")

        If dt.Rows.Count > 0 Then

            Dim dr As DataRow = dt.Rows(0)

            For Each vlCampo As LbDatos.cCampo In vctCentroExp.Campos
                vlCampo.Valor = dr(vlCampo.Nombre)
            Next

            vcCRFArray.Clear()
            For Each vlCRFDataRow As DataRow In CRFDataTable.Rows
                If Not IsDBNull(vlCRFDataRow("RegimenFiscalId")) Then
                    Dim vlCRF1 As New CCEERegimenFiscal(Me)
                    vlCRF1.Recuperar(vlCRFDataRow("RegimenFiscalId"))
                    vcCRFArray.Add(vlCRF1)
                End If
            Next

            Return True

        Else
            Return False
        End If

    End Function

    Public Function Seleccionar(ByVal pvCentroExpID As String) As DataTable
        Dim dt As DataTable = vctCentroExp.Seleccionar("CentroExpID='" + pvCentroExpID.Replace("'", "''") + "' and Baja=0")
        Return dt
    End Function
    Public Function SeleccionarSucursales(ByVal pvCentroExpID As String) As DataTable
        Dim dt As DataTable = vctCentroExp.Seleccionar("CentroExpPadreID='" + pvCentroExpID.Replace("'", "''") + "' ")
        Return dt
    End Function
    Public Function ValidarCampos() As Boolean
        Dim i As Integer

        With vctCentroExp
            For i = 0 To .Campos.Count - 1
                Dim vlCampo As LbDatos.cCampo
                vlCampo = .Campos(i)

                If Not .Campos(i) Is Nothing Then
                    If vlCampo.Requerido Then
                        If vlCampo.Valor Is Nothing Then
                            Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("ESQ" + vlCampo.Nombre, True)}, "ESQ" + vlCampo.Nombre)
                            Return False
                        End If
                        If vlCampo.Tipo = LbDatos.ETipo.Cadena Then
                            If vlCampo.Valor = "" Then
                                Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("ESQ" + vlCampo.Nombre, True)}, "ESQ" + vlCampo.Nombre)
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

            'If Me.vcCRFArray.Count = 0 Then
            '    Throw New LbControlError.cError("E0867", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("CRFTipoRegimen", True)}, "CRFTipoRegimen")
            '    Return False
            'End If
        End With

        Return True

    End Function

    Public Function Grabar() As Boolean
        Try

            If ValidarCampos() Then
                ActualizarSubEmpresaSucursal()
                'For Each vlCRF As CCEERegimenFiscal In vcCRFArray
                '    vlCRF.Insertar()
                'Next
                Return vctCentroExp.Modificar()
            End If

        Catch ex As LbControlError.cError
            ex.Mostrar()
            Return False
        End Try

    End Function

    Public Function ActualizarSubEmpresaSucursal() As Boolean
        Dim temp As DataTable = SeleccionarSucursales(Me.CentroExpID)
        For Each filas As DataRow In temp.Rows
            Dim tempSuc As New CCentroExp()
            tempSuc.Recuperar(filas!CentroExpID)
            tempSuc.SubEmpresaId = Me.SubEmpresaId

            If Me.TipoEstado = False Then
                tempSuc.TipoEstado = Me.TipoEstado
            End If

            tempSuc.Grabar()

        Next
    End Function


    Public Function Existe(ByVal pvCentroExpID As String) As Boolean
        Dim vlDtEsquema As DataTable

        vlDtEsquema = vctCentroExp.Seleccionar("CentroExpID='" & pvCentroExpID.Replace("'", "''") & "' ")
        If vlDtEsquema.Rows.Count > 0 Then
            Return True
        End If

        Return False
    End Function
    Public Function ExisteMatriz(ByVal pvCentroExpID As String) As Boolean
        Dim vlDtEsquema As DataTable

        vlDtEsquema = vctCentroExp.Seleccionar(" tipo=0 and tipoestado=1 and  CentroExpID='" & pvCentroExpID.Replace("'", "''") & "' ")
        If vlDtEsquema.Rows.Count > 0 Then
            Return True
        End If

        Return False
    End Function
    Public Function ExisteMatrizEnSubEmpresa(ByVal pvCentroExpID As String, ByVal pvSubEmpresaID As String) As Boolean
        Dim vlDtEsquema As DataTable

        vlDtEsquema = vctCentroExp.Seleccionar(" tipo=0 and tipoestado=1 and  CentroExpID<>'" & pvCentroExpID.Replace("'", "''") & "'  and subempresaid='" + pvSubEmpresaID + "' ")
        If vlDtEsquema.Rows.Count > 0 Then
            Return True
        End If

        Return False
    End Function
    Public Function NumCertificadoEnFosHistVigente(ByVal pvCentroExpID As String, Optional ByVal bConHijos As Boolean = False) As Boolean
        Dim vlDtEsquema As DataTable

        vlDtEsquema = LbConexion.cConexion.Instancia.EjecutarConsulta("SELECT * FROM FOSHIST F INNER JOIN (SELECT FOLIOID,FOSID, MAX(FSHFECHAINICIO) AS FSHFECHAINICIO fROM FOSHIST GROUP BY FOLIOID,FOSID)F1 ON F.FOLIOID=F1.FOLIOID AND F.FOSID=F1.FOSID AND F.FSHFECHAINICIO = F1.FSHFECHAINICIO WHERE F.CENTROEXPid ='" + pvCentroExpID.Replace("'", "''") + "'")

        If bConHijos Then
            For Each fila As DataRow In SeleccionarSucursales(pvCentroExpID).Rows
                If NumCertificadoEnFosHistVigente(fila!CentroExpID) Then
                    Return True
                End If
            Next
        End If

        If vlDtEsquema.Rows.Count > 0 Then
           
            Return True
        End If

        Return False
    End Function

    Public Function NumCertificadoEnFosHistVigenteMatrizSucursales(ByVal pvCentroExpID As String) As String
        Dim vlDtEsquema As DataTable

        vlDtEsquema = LbConexion.cConexion.Instancia.EjecutarConsulta("SELECT * FROM FOSHIST F INNER JOIN (SELECT FOLIOID,FOSID, MAX(FSHFECHAINICIO) AS FSHFECHAINICIO fROM FOSHIST GROUP BY FOLIOID,FOSID)F1 ON F.FOLIOID=F1.FOLIOID AND F.FOSID=F1.FOSID AND F.FSHFECHAINICIO = F1.FSHFECHAINICIO WHERE F.CENTROEXPid ='" + pvCentroExpID.Replace("'", "''") + "'")


        For Each fila As DataRow In SeleccionarSucursales(pvCentroExpID).Rows
            If NumCertificadoEnFosHistVigenteMatrizSucursales(fila!CentroExpID) <> "" Then
                Return fila!CentroExpID
            End If
        Next


        If vlDtEsquema.Rows.Count > 0 Then
            Return pvCentroExpID
        End If

        Return ""
    End Function

    Public Function RecuperarTablaFosHistVigentePorNumeroCertificado(ByVal pvNumCertificado As String, ByVal pvCentroExpID As String) As DataTable
        Dim vlDtEsquema As DataTable

        vlDtEsquema = LbConexion.cConexion.Instancia.EjecutarConsulta("SELECT * FROM FOSHIST F INNER JOIN (SELECT FOLIOID,FOSID, MAX(FSHFECHAINICIO) AS FSHFECHAINICIO fROM FOSHIST GROUP BY FOLIOID,FOSID)F1 ON F.FOLIOID=F1.FOLIOID AND F.FOSID=F1.FOSID AND F.FSHFECHAINICIO = F1.FSHFECHAINICIO WHERE F.CENTROEXPid ='" + pvCentroExpID.Replace("'", "''") + "' and F.NumCertificado ='" + pvNumCertificado.Replace("'", "''") + "'")

        Return vlDtEsquema
    End Function

    Public Sub Eliminar()
        vctCentroExp.Eliminar()
    End Sub

    Public Function EsquemasSuperioresActivos(ByVal pvEsquemaId As String) As Boolean
        'Dim sConsulta As String
        Dim sEsquemaPadreId As String
        Dim dtEsquemaPadre As DataTable
        Dim bActivo As Boolean = True
        'sConsulta = "select isnull(EsquemaIdPadre, '') as EsquemaIdPadre from Esquema where EsquemaId = '" & pvEsquemaId & "'"
        'sEsquemaIdPadre = Me.Conexion.EjecutarComandoScalar(sConsulta)
        dtEsquemaPadre = Me.Tabla.RecuperarTabla("EsquemaId = '" & pvEsquemaId.Replace("'", "''") & "'", "isnull(EsquemaIdPadre, '') as EsquemaIdPadre")
        sEsquemaPadreId = dtEsquemaPadre.Rows(0)("EsquemaIdPadre")
        While sEsquemaPadreId <> String.Empty And bActivo
            'sConsulta = "select isnull(EsquemaIdPadre, '') as EsquemaIdPadre, TipoEstado from Esquema where EsquemaId = '" & sEsquemaIdPadre & "'"
            'dtEsquemaPadre = Me.Conexion.EjecutarConsulta(sConsulta)
            dtEsquemaPadre = Me.Tabla.RecuperarTabla("EsquemaId = '" & sEsquemaPadreId.Replace("'", "''") & "'", "isnull(EsquemaIdPadre, '') as EsquemaIdPadre, TipoEstado")
            sEsquemaPadreId = dtEsquemaPadre.Rows(0)("EsquemaIdPadre")
            bActivo = (dtEsquemaPadre.Rows(0)("TipoEstado") = 1)
        End While
        Return bActivo
    End Function

    Public Class CCentroExpTabla
        Private vctCentroExp As LbDatos.cTabla


        Public Function RecuperarTabla(ByVal pvFiltro As String, Optional ByVal pvCampos As String = "*") As DataTable
            Dim vldt As New DataTable

            Try
                vldt = vctCentroExp.Seleccionar(pvFiltro, pvCampos)
                '//Interaccion para crear el item
            Catch ex As LbControlError.cError
                Throw ex
            End Try

            Return vldt

        End Function

        Public Sub InsertarEn(ByRef prDataTable As DataTable)
            vctCentroExp.Insertar(prDataTable)
        End Sub

        Public Sub ModificarEn(ByRef prDataTable As DataTable)
            vctCentroExp.Modificar(prDataTable)
        End Sub

        Public Sub New(ByVal PCentroExp As LbDatos.cTabla)
            vctCentroExp = PCentroExp
        End Sub
    End Class

    Public Class CCentroExpDataSet
        Public MaxEsquemas As Integer
        Public TreeDataSet As DataSet
        Public MultiSelectData As Boolean
        Private vctCentroExp As LbDatos.cTabla

        Public Function RecuperarDataSet(ByVal pvFiltro As String) As DataSet
            Dim vlds As New DataSet

            vlds.Tables.Add(vctCentroExp.Seleccionar(pvFiltro))
            Return vlds
        End Function


        Public Function RecuperarTreeDataSet(ByVal pvFiltro As String, Optional ByVal pvCamposSelect As String = "CentroExpID, CentroExpPadreID, Nombre,RFC,NumCertificado,Municipio,Entidad,tipoEstado") As DataSet
            Dim vlds As New DataSet
            Dim vlmaxEsquemas As Integer

            Dim vldr As DataRelation









            Dim strSQL As String = " Select CentroExpID,CentroExpPadreID,Nombre,C.RFC,NumCertificado,S.NombreEmpresa,Municipio,Entidad,C.tipoEstado,C.SubEmpresaId from CentroExpedicion C  Inner join SubEmpresa S on S.Subempresaid=C.SubEmpresaID  where CentroExpPadreID='' or  CentroExpPadreID is null "
            Dim TblInicial As New DataTable
            TblInicial = vcConexion.EjecutarConsulta(strSQL)

            TblInicial.TableName = "EsquemaRaiz"

            vlds.Tables.Add(TblInicial)


            Dim Tbl As New DataTable
            Dim str As New Text.StringBuilder

            str.Append("SELECT ")

            If MultiSelectData Then
                str.Append("'0' as Seleccion,")
            End If


            str.Append(" CentroExpID,CentroExpPadreID,Nombre,C.RFC,NumCertificado,S.NombreEmpresa,Municipio,Entidad,C.tipoEstado,C.SubEmpresaId from CentroExpedicion C  Inner join SubEmpresa S on S.Subempresaid=C.SubEmpresaID where (CentroExpPadreID<>'' or not CentroExpPadreID is null) " & IIf(pvFiltro.Length = 0, "", "and " & pvFiltro))
            Tbl = vcConexion.EjecutarConsulta(str.ToString)
            Tbl.TableName = "CentroExp" & 0

            vlds.Tables.Add(Tbl)





            vldr = New DataRelation("SubCentroExp" & 0, vlds.Tables(0).Columns("CentroExpID"), vlds.Tables(1).Columns("CentroExpPadreID"), False)
            vlds.Relations.Add(vldr)




            MaxEsquemas = vlmaxEsquemas

            TreeDataSet = vlds

            Return vlds

        End Function

        Public Function RecuperarTreeDataSetFiltroGridex(ByVal pvFiltro As String, ByVal fCentroExpID As String, ByVal fNombre As String, ByVal frfc As String, ByVal fnumcertificado As String, ByVal fSubEmpresa As String, ByVal fmunicipio As String, ByVal fentidad As String, ByVal fTipoEstado As String, Optional ByVal pvCamposSelect As String = "CenExpedicionID,CentroExpPadreID, Nombre, rfc,numcertificado,municipio, entidad, TipoEstado") As DataSet

            Dim esquemavalido As New ArrayList
            Dim esquemaFiltro As New ArrayList
            Dim vlds As New DataSet
            Dim vlmaxEsquemas As Integer

            Dim vldr As DataRelation
            'Dim vlTblMaxEsq As DataTable



            Dim strSQL As String = " Select CentroExpID,CentroExpPadreID,Nombre,C.RFC,NumCertificado,S.NombreEmpresa,Municipio,Entidad,C.tipoEstado,C.SubEmpresaId from CentroExpedicion C  Inner join SubEmpresa S on S.Subempresaid=C.SubEmpresaID  where CentroExpPadreID='' or  CentroExpPadreID is null "
            Dim TblInicial As New DataTable
            TblInicial = vcConexion.EjecutarConsulta(strSQL)

            TblInicial.TableName = "EsquemaRaiz"

            vlds.Tables.Add(TblInicial)


            Dim Tbl As New DataTable
            Dim str As New Text.StringBuilder

            str.Append("SELECT ")

            If MultiSelectData Then
                str.Append("'0' as Seleccion,")
            End If


            str.Append(" CentroExpID,CentroExpPadreID,Nombre,C.RFC,NumCertificado,S.NombreEmpresa,Municipio,Entidad,C.tipoEstado,C.SubEmpresaId from CentroExpedicion C  Inner join SubEmpresa S on S.Subempresaid=C.SubEmpresaID " & IIf(pvFiltro.Length = 0, "", "where " & pvFiltro))
            Tbl = vcConexion.EjecutarConsulta(str.ToString)
            Tbl.TableName = "CentroExp" & 0

            vlds.Tables.Add(Tbl)

            Dim temp As DataTable = New DataTable

            '**************************************************************
            fNombre = IIf(IsNothing(fNombre), "", fNombre)
            fCentroExpID = IIf(IsNothing(fCentroExpID), "", fCentroExpID)
            frfc = IIf(IsNothing(frfc), "", frfc)
            fmunicipio = IIf(IsNothing(fmunicipio), "", fmunicipio)
            fentidad = IIf(IsNothing(fentidad), "", fentidad)
            fTipoEstado = IIf(IsNothing(fTipoEstado), "", fTipoEstado)
            fnumcertificado = IIf(IsNothing(fnumcertificado), "", fnumcertificado)
            fSubEmpresa = IIf(IsNothing(fSubEmpresa), "", fSubEmpresa)

            For cont As Integer = vlds.Tables.Count - 1 To 0 Step -1
                For controw As Integer = 0 To vlds.Tables(cont).Rows.Count - 1

                    If Not esquemavalido.Contains(vlds.Tables(cont).Rows(controw)("CentroExpID")) Then
                        'algo asi
                        'If IIf(vlds.Tables(cont).Rows(controw)("Nombre").tostring.IndexOf("*") = -1, vlds.Tables(cont).Rows(controw)("Nombre").ToString.Replace("*", "").ToUpper.IndexOf(FiltroGridexNombre.ToUpper), IIf(vlds.Tables(cont).Rows(controw)("Nombre").tostring.StartsWith("*") And vlds.Tables(cont).Rows(controw)("Nombre").tostring.EndsWith("*"),)) >= 0 Then

                        If ValidarFiltro(vlds.Tables(cont).Rows(controw)("CentroExpID").ToString().ToUpper, fCentroExpID.ToUpper) And ValidarFiltro(vlds.Tables(cont).Rows(controw)("Nombre").ToString().ToUpper, fNombre.ToUpper) And ValidarFiltro(vlds.Tables(cont).Rows(controw)("Municipio").ToString().ToUpper, fmunicipio.ToUpper) And ValidarFiltro(vlds.Tables(cont).Rows(controw)("rfc").ToString().ToUpper, frfc.ToUpper) And ValidarFiltro(vlds.Tables(cont).Rows(controw)("Entidad").ToString().ToUpper, fentidad.ToUpper) And ValidarFiltro(vlds.Tables(cont).Rows(controw)("TipoEstado").ToString().ToUpper, fTipoEstado.ToUpper) And ValidarFiltro(vlds.Tables(cont).Rows(controw)("numcertificado").ToString().ToUpper, fnumcertificado.ToUpper) Then

                            esquemaFiltro.Add(vlds.Tables(cont).Rows(controw)("CentroExpPadreID"))
                            esquemavalido.Add(vlds.Tables(cont).Rows(controw)("CentroExpID"))
                            esquemavalido.Add(vlds.Tables(cont).Rows(controw)("CentroExpPadreID"))

                        End If
                    Else
                        ''Poner valido al papa del esquema valido
                        esquemavalido.Add(vlds.Tables(cont).Rows(controw)("CentroExpPadreID"))
                    End If

                Next
            Next
            For X As Integer = vlds.Tables.Count - 1 To 0 Step -1
                For cont As Integer = vlds.Tables.Count - 1 To 0 Step -1
                    For controw As Integer = 0 To vlds.Tables(cont).Rows.Count - 1
                        If esquemaFiltro.Contains(vlds.Tables(cont).Rows(controw)("CentroExpPadreID")) Then
                            esquemavalido.Add(vlds.Tables(cont).Rows(controw)("CentroExpID"))
                            esquemaFiltro.Add(vlds.Tables(cont).Rows(controw)("CentroExpID"))
                        End If
                    Next
                Next
            Next X

empiezo:
            For cont As Integer = vlds.Tables.Count - 1 To 0 Step -1
                For i As Integer = 0 To vlds.Tables(cont).Rows.Count - 1
                    If Not esquemavalido.Contains(vlds.Tables(cont).Rows(i)("CentroExpID")) Then
                        vlds.Tables(cont).Rows.RemoveAt(i)
                        GoTo empiezo
                    End If

                Next
            Next

            '********************************************************

            vldr = New DataRelation("SubCentroExp" & 0, vlds.Tables(0).Columns("CentroExpID"), vlds.Tables(1).Columns("CentroExpPadreID"), False)
            vlds.Relations.Add(vldr)




            MaxEsquemas = vlmaxEsquemas

            TreeDataSet = vlds

            Return vlds

        End Function
        Public Function ValidarFiltro(ByVal comp As String, ByVal filtro As String) As Boolean
            If filtro <> "" Then
                If Not filtro.StartsWith("*") And Not filtro.EndsWith("*") Then
                    If filtro = comp Then
                        Return True
                    End If
                Else
                    If filtro.StartsWith("*") And filtro.EndsWith("*") Then
                        filtro = filtro.Replace("*", "")
                        If comp.IndexOf(filtro) >= 0 Then
                            Return True
                        End If
                    Else
                        If filtro.StartsWith("*") Then
                            filtro = filtro.Replace("*", "")
                            If comp.EndsWith(filtro) Then
                                Return True
                            End If
                        ElseIf filtro.EndsWith("*") Then
                            filtro = filtro.Replace("*", "")
                            If comp.StartsWith(filtro) Then
                                Return True
                            End If

                        End If
                    End If
                End If
            Else
                Return True
            End If

            ValidarFiltro = False
        End Function
        Public Function Seleccionados() As ArrayList

            Dim Seleccion As New ArrayList

            If MultiSelectData Then

                For cont As Integer = 0 To TreeDataSet.Tables.Count - 1

                    Dim Drws As Data.DataRow() = TreeDataSet.Tables(cont).Select("Seleccion='True'")

                    For Each Drw As Data.DataRow In Drws
                        Seleccion.Add(Drw)
                    Next

                Next
            End If


            Return Seleccion

        End Function

        Public Function ExisteEsquemaProducto(ByVal pvEsquemaID As String) As Boolean

            Dim vlTblExisteEsq As DataTable

            vlTblExisteEsq = vcConexion.EjecutarConsulta("select * from ImpuestoEsquema where EsquemaID='" & pvEsquemaID.Replace("'", "''") & "'")

            If vlTblExisteEsq.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

        End Function

        'Regresa los esquemas hijos separados por comas
        Public Function BuscarNodosArbol(ByRef refsEsquemas As String, ByVal parsNodo As String) As Boolean
            Try
                Dim sNodo As String = String.Empty
                Dim dt As DataTable = LbConexion.cConexion.Instancia.EjecutarConsulta("Select EsquemaID from Esquema where EsquemaIDPadre='" & parsNodo.Replace("'", "''") & "' and TipoEstado = 1 and Baja = 0")
                For Each dr As DataRow In dt.Rows
                    sNodo = dr("EsquemaID")
                    Dim sCadenaNodo As String = "'" & sNodo & "'"
                    If refsEsquemas.IndexOf(sCadenaNodo) < 0 Then
                        refsEsquemas &= sCadenaNodo & ","
                        BuscarNodosArbol(refsEsquemas, sNodo)
                    End If
                Next
                Return True
            Catch ExcA As Exception
                MsgBox(ExcA.Message, MsgBoxStyle.Critical, "BuscarNodosArbol")
            End Try
            Return False
        End Function

        Public Sub New(ByVal PCentroExp As LbDatos.cTabla)
            vctCentroExp = PCentroExp
        End Sub
    End Class

#Region "CRF"
    Private Function RecuperarCRFDataTable() As DataTable
        Dim vcCRF As New CCEERegimenFiscal(Me)
        Dim vlDt As DataTable = vcCRF.Tabla.Recuperar(Me.CentroExpID)
        Return vlDt
    End Function

    Public Function InsertarCRF(ByVal pvTipoRegimen As Integer) As Boolean

        Dim vlCRF As New CCEERegimenFiscal(Me)
        'Si existe en la BD
        If Not vlCRF.Existe(pvTipoRegimen) Then
            'Si existe en el Arreglo
            If CRF(pvTipoRegimen) Is Nothing Then
                vlCRF.Insertar(pvTipoRegimen, Me.MUsuarioID)
                Me.vcCRFArray.Add(vlCRF)
                'vcPRSArray.Insert(vcPRSArray.Count, vlPRS)
            End If
        End If

        Return True
    End Function

    Public Function EliminarCRF(ByVal pvTipoRegimen As Integer) As Boolean
        Try
            If Not CRF(pvTipoRegimen) Is Nothing Then
                'If CRF(pvTipoRegimen).Estado = eEstado.Nuevo Then
                CRF(pvTipoRegimen).Eliminar()
                vcCRFArray.Remove(CRF(pvTipoRegimen))
                'End If
            End If
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Function CRFArray() As ArrayList
        Return vcCRFArray
    End Function

    Public Function CRFDataTable() As DataTable
        Return RecuperarCRFDataTable()
    End Function

    Public Function CRF(ByVal pvTipoRegimen As Integer) As CCEERegimenFiscal
        Dim i As Integer = 0
        If vcCRFArray.Count <= 0 Then Return Nothing
        For i = 0 To vcCRFArray.Count - 1
            Dim vcCRF As CCEERegimenFiscal
            vcCRF = CType(vcCRFArray(i), CCEERegimenFiscal)
            If vcCRF.TipoRegimen = pvTipoRegimen Then
                Return vcCRF
            End If
        Next
        Return Nothing
    End Function

#End Region

End Class

