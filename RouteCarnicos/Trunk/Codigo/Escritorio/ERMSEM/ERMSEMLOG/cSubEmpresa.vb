Public Enum eEstado
    Vacio = 0
    Nuevo
    Modificado
    Recuperado
    Eliminado
End Enum

Public Class cSubEmpresa
    Private vcConexion As LbConexion.cConexion = LbConexion.cConexion.Instancia
    Private vcTablaPadre As LbDatos.cTabla
    Dim vcSemHist As LbDatos.cTabla
    Public Tabla As cSEMTabla
    Private vcEstado As eEstado
    Dim vcLogo As LbDatos.cCampo
    Public vcGuardarHist As Boolean = False



#Region "Propiedades"
    Public Property SubEmpresaID() As String
        Get
            Return vcTablaPadre.Campos("SubEmpresaID").Valor
        End Get
        Set(ByVal Value As String)
            If vcEstado = eEstado.Vacio Or vcEstado = eEstado.Nuevo Then
                vcTablaPadre.Campos("SubEmpresaID").Valor = Value

            End If
            vcSemHist.Campos("SubEmpresaID").Valor = Value
        End Set
    End Property


    Public Property NombreEmpresa() As String
        Get
            Return vcTablaPadre.Campos("NombreEmpresa").Valor
        End Get
        Set(ByVal Value As String)
            vcTablaPadre.Campos("NombreEmpresa").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property


    Public Property RFC() As String
        Get
            Return IIf(IsDBNull(vcTablaPadre.Campos("RFC").Valor), "", vcTablaPadre.Campos("RFC").Valor)
        End Get
        Set(ByVal Value As String)
            vcTablaPadre.Campos("RFC").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property Pais() As String
        Get
            Return IIf(IsDBNull(vcTablaPadre.Campos("Pais").Valor), "", vcTablaPadre.Campos("Pais").Valor)
        End Get
        Set(ByVal Value As String)
            vcTablaPadre.Campos("Pais").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property Region() As String
        Get
            Return IIf(IsDBNull(vcTablaPadre.Campos("Region").Valor), "", vcTablaPadre.Campos("Region").Valor)
        End Get
        Set(ByVal Value As String)
            vcTablaPadre.Campos("Region").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property Localidad() As String
        Get
            Return IIf(IsDBNull(vcTablaPadre.Campos("Localidad").Valor), "", vcTablaPadre.Campos("Localidad").Valor)
        End Get
        Set(ByVal Value As String)
            vcTablaPadre.Campos("Localidad").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property ReferenciaDom() As String
        Get
            Return IIf(IsDBNull(vcTablaPadre.Campos("ReferenciaDom").Valor), "", vcTablaPadre.Campos("ReferenciaDom").Valor)
        End Get
        Set(ByVal Value As String)
            vcTablaPadre.Campos("ReferenciaDom").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property Ciudad() As String
        Get
            Return IIf(IsDBNull(vcTablaPadre.Campos("Ciudad").Valor), "", vcTablaPadre.Campos("Ciudad").Valor)
        End Get
        Set(ByVal Value As String)
            vcTablaPadre.Campos("Ciudad").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property Colonia() As String
        Get
            Return IIf(IsDBNull(vcTablaPadre.Campos("Colonia").Valor), "", vcTablaPadre.Campos("Colonia").Valor)
        End Get
        Set(ByVal Value As String)
            vcTablaPadre.Campos("Colonia").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property Calle() As String
        Get
            Return IIf(IsDBNull(vcTablaPadre.Campos("Calle").Valor), "", vcTablaPadre.Campos("Calle").Valor)
        End Get
        Set(ByVal Value As String)
            vcTablaPadre.Campos("Calle").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property Numero() As String
        Get
            Return IIf(IsDBNull(vcTablaPadre.Campos("Numero").Valor), "", vcTablaPadre.Campos("Numero").Valor)
        End Get
        Set(ByVal Value As String)
            vcTablaPadre.Campos("Numero").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property NumeroInterior() As String
        Get
            Return IIf(IsDBNull(vcTablaPadre.Campos("NumeroInterior").Valor), "", vcTablaPadre.Campos("NumeroInterior").Valor)
        End Get
        Set(ByVal Value As String)
            vcTablaPadre.Campos("NumeroInterior").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property CodigoPostal() As String
        Get
            Return IIf(IsDBNull(vcTablaPadre.Campos("CodigoPostal").Valor), "", vcTablaPadre.Campos("CodigoPostal").Valor)
        End Get
        Set(ByVal Value As String)
            vcTablaPadre.Campos("CodigoPostal").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property Logotipo() As Byte()
        Get
            Return vcTablaPadre.Campos("Logotipo").Valor
        End Get
        Set(ByVal Value As Byte())
            vcTablaPadre.Campos("Logotipo").Valor = Value
        End Set
    End Property

    Public Property Telefono() As String
        Get
            Return IIf(IsDBNull(vcTablaPadre.Campos("Telefono").Valor), "", vcTablaPadre.Campos("Telefono").Valor)
        End Get
        Set(ByVal Value As String)
            vcTablaPadre.Campos("Telefono").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property TipoEstado() As Integer
        Get
            Return vcTablaPadre.Campos("TipoEstado").Valor
        End Get
        Set(ByVal Value As Integer)
            vcTablaPadre.Campos("TipoEstado").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property


    Public Property MUsuarioId() As String
        Get
            Return vcTablaPadre.Campos("MUsuarioId").Valor
        End Get
        Set(ByVal Value As String)
            vcTablaPadre.Campos("MUsuarioId").Valor = Value
            vcSemHist.Campos("MUsuarioId").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public ReadOnly Property MFechaHora() As DateTime
        Get
            Return vcTablaPadre.Campos("MFechaHora").Valor
        End Get
    End Property

    Friend ReadOnly Property cTabla() As LbDatos.cTabla
        Get
            Return vcTablaPadre
        End Get
    End Property

    Public ReadOnly Property cEstado() As eEstado
        Get
            Return vcEstado
        End Get
    End Property
#End Region

    'Solo SemHist

    Public ReadOnly Property SEMHistFechaInicio() As Date
        Get
            Return vcSemHist.Campos("SEMHistFechaInicio").Valor
        End Get
    End Property
    Public Property ComprobanteDig() As Boolean
        Get
            Return IIf(IsDBNull(vcSemHist.Campos("ComprobanteDig").Valor), False, vcSemHist.Campos("ComprobanteDig").Valor)
        End Get
        Set(ByVal Value As Boolean)
            If Me.ComprobanteDig <> Value Then vcGuardarHist = True
            vcSemHist.Campos("ComprobanteDig").Valor = Value
        End Set
    End Property

    Public Property FoliosTerminal() As Boolean
        Get
            Return IIf(IsDBNull(vcSemHist.Campos("FoliosTerminal").Valor), False, vcSemHist.Campos("FoliosTerminal").Valor)
        End Get
        Set(ByVal Value As Boolean)
            If Me.FoliosTerminal <> Value Then vcGuardarHist = True
            vcSemHist.Campos("FoliosTerminal").Valor = Value
        End Set
    End Property

    Public Property ClienteClave() As String
        Get
            Return IIf(IsDBNull(vcSemHist.Campos("ClienteClave").Valor), "", vcSemHist.Campos("ClienteClave").Valor)

        End Get
        Set(ByVal Value As String)
            If Me.ClienteClave <> Value Then vcGuardarHist = True
            vcSemHist.Campos("ClienteClave").Valor = Value
        End Set
    End Property

    Public Property DirRepMensual() As String
        Get
            Return vcSemHist.Campos("DirRepMensual").Valor
        End Get
        Set(ByVal Value As String)
            If Me.DirRepMensual <> Value Then vcGuardarHist = True
            vcSemHist.Campos("DirRepMensual").Valor = Value
        End Set
    End Property
    Public Property DirDocXML() As String
        Get
            Return vcSemHist.Campos("DirDocXML").Valor
        End Get
        Set(ByVal Value As String)

            If Me.DirDocXML <> Value Then vcGuardarHist = True
            vcSemHist.Campos("DirDocXML").Valor = Value
        End Set
    End Property



    Public Property DirArchivosFacElec() As String
        Get
            Return vcSemHist.Campos("DirArchivosFacElec").Valor
        End Get
        Set(ByVal Value As String)
            If Me.DirArchivosFacElec <> Value Then vcGuardarHist = True
            vcSemHist.Campos("DirArchivosFacElec").Valor = Value
        End Set
    End Property

    Public Property ContrasenaClave() As String
        Get
            If IsNothing(vcSemHist.Campos("ContrasenaClave").Valor) Or vcSemHist.Campos("ContrasenaClave").Valor = "" Then
                Return ""
            Else

                Return CType(vcSemHist.Campos("ContrasenaClave").Valor, String)
            End If

        End Get
        Set(ByVal Value As String)
            If Me.ContrasenaClave <> Value Then vcGuardarHist = True
            If Value = "" Then
                vcSemHist.Campos("ContrasenaClave").Valor = ""
            Else
                vcSemHist.Campos("ContrasenaClave").Valor = Value
            End If

        End Set
    End Property
    Public Property ArchivoPEM() As String
        Get
            Return IIf(IsDBNull(vcSemHist.Campos("ArchivoPEM").Valor), "", vcSemHist.Campos("ArchivoPEM").Valor)

        End Get
        Set(ByVal Value As String)
            vcGuardarHist = True
            vcSemHist.Campos("ArchivoPEM").Valor = Value
        End Set
    End Property
    Public Property CerBase64() As String
        Get

            Return IIf(IsDBNull(vcSemHist.Campos("CerBase64").Valor), "", vcSemHist.Campos("CerBase64").Valor)

        End Get
        Set(ByVal Value As String)
            vcGuardarHist = True
            vcSemHist.Campos("CerBase64").Valor = Value
        End Set
    End Property
    Public Property AchivoPFX64() As String
        Get
            Return IIf(IsDBNull(vcSemHist.Campos("AchivoPFX64").Valor), "", vcSemHist.Campos("AchivoPFX64").Valor)

        End Get
        Set(ByVal Value As String)
            vcGuardarHist = True
            vcSemHist.Campos("AchivoPFX64").Valor = Value
        End Set
    End Property

    Public Property FormatoFactura() As Integer
        Get
            Return IIf(IsDBNull(vcSemHist.Campos("FormatoFactura").Valor), Nothing, vcSemHist.Campos("FormatoFactura").Valor)
        End Get
        Set(ByVal value As Integer)
            If Me.FormatoFactura <> value Then vcGuardarHist = True
            vcSemHist.Campos("FormatoFactura").Valor = value
        End Set
    End Property

    Public Property VersionCFD() As Integer
        Get
            Return IIf(IsDBNull(vcSemHist.Campos("VersionCFD").Valor), Nothing, vcSemHist.Campos("VersionCFD").Valor)
        End Get
        Set(ByVal value As Integer)
            If Me.VersionCFD <> value Then vcGuardarHist = True
            vcSemHist.Campos("VersionCFD").Valor = value
        End Set
    End Property
    Public Property ProveedorTimbre() As Integer
        Get
            If (vcSemHist.Campos("ProveedorTimbre").Valor Is DBNull.Value) Then
                Return -1
            Else
                Return vcSemHist.Campos("ProveedorTimbre").Valor
            End If

        End Get
        Set(ByVal value As Integer)
            If Me.ProveedorTimbre <> value Then vcGuardarHist = True
            vcSemHist.Campos("ProveedorTimbre").Valor = value
        End Set
    End Property
    Public Property CustomerKey() As String
        Get
            If (vcSemHist.Campos("CustomerKey").Valor Is DBNull.Value) Then
                Return ""
            Else
                Return vcSemHist.Campos("CustomerKey").Valor
            End If


        End Get
        Set(ByVal value As String)
            If Me.CustomerKey <> value Then vcGuardarHist = True
            vcSemHist.Campos("CustomerKey").Valor = value
        End Set
    End Property
    Public Property ServidorTimbre() As String
        Get
            If (vcSemHist.Campos("ServidorTimbre").Valor Is DBNull.Value) Then
                Return ""
            Else
                Return vcSemHist.Campos("ServidorTimbre").Valor
            End If
        End Get
        Set(ByVal value As String)
            If Me.ServidorTimbre <> value Then vcGuardarHist = True
            vcSemHist.Campos("ServidorTimbre").Valor = value
        End Set
    End Property

    Public Property ServidorCancelacion() As String
        Get
            If (vcSemHist.Campos("ServidorCancelacion").Valor Is DBNull.Value) Then
                Return ""
            Else
                Return vcSemHist.Campos("ServidorCancelacion").Valor
            End If
        End Get
        Set(ByVal value As String)
            If Me.ServidorCancelacion <> value Then vcGuardarHist = True
            vcSemHist.Campos("ServidorCancelacion").Valor = value
        End Set
    End Property



    'Public Property VariosPedidos() As String
    '    Get
    '        Return vcSemHist.Campos("VariosPedidos").Valor
    '    End Get
    '    Set(ByVal value As String)
    '        vcGuardarHist = True
    '        vcSemHist.Campos("VariosPedidos").Valor = value
    '    End Set
    'End Property

#Region "Funciones"
    Public Sub New()
        vcTablaPadre = New LbDatos.cTabla("SubEmpresa")
        vcSemHist = New LbDatos.cTabla("SemHist")
        Tabla = New cSEMTabla(Me)
        With vcTablaPadre
            .Campos.Add(New LbDatos.cCampo("SubEmpresaId", LbDatos.ETipo.Cadena, True, True))
            .Campos.Add(New LbDatos.cCampo("NombreEmpresa", LbDatos.ETipo.Cadena, True))
            .Campos.Add(New LbDatos.cCampo("RFC", LbDatos.ETipo.Cadena))
            .Campos.Add(New LbDatos.cCampo("Pais", LbDatos.ETipo.Cadena))
            .Campos.Add(New LbDatos.cCampo("Region", LbDatos.ETipo.Cadena))
            .Campos.Add(New LbDatos.cCampo("Localidad", LbDatos.ETipo.Cadena))
            .Campos.Add(New LbDatos.cCampo("ReferenciaDom", LbDatos.ETipo.Cadena))
            .Campos.Add(New LbDatos.cCampo("Ciudad", LbDatos.ETipo.Cadena))
            .Campos.Add(New LbDatos.cCampo("Colonia", LbDatos.ETipo.Cadena))
            .Campos.Add(New LbDatos.cCampo("Calle", LbDatos.ETipo.Cadena))
            .Campos.Add(New LbDatos.cCampo("Numero", LbDatos.ETipo.Cadena))
            .Campos.Add(New LbDatos.cCampo("NumeroInterior", LbDatos.ETipo.Cadena))
            .Campos.Add(New LbDatos.cCampo("CodigoPostal", LbDatos.ETipo.Cadena))
            '   .Campos.Add(New LbDatos.cCampo("Logotipo", LbDatos.ETipo.Binario))
            vcLogo = New LbDatos.cCampo("Logotipo", LbDatos.ETipo.Binario, True)
            .Campos.Add(vcLogo)
            .Campos.Add(New LbDatos.cCampo("Telefono", LbDatos.ETipo.Cadena))
            .Campos.Add(New LbDatos.cCampo("TipoEstado", LbDatos.ETipo.Numerico, True))
            .Campos.Add(New LbDatos.cCampo("MFechaHora", LbDatos.ETipo.MFechaHora, False))
            .Campos.Add(New LbDatos.cCampo("MUsuarioId", LbDatos.ETipo.Cadena, True))
        End With

        With vcSemHist
            .Campos.Add(New LbDatos.cCampo("SubEmpresaId", LbDatos.ETipo.Cadena, True, True))
            .Campos.Add(New LbDatos.cCampo("SEMHistFechaInicio", LbDatos.ETipo.FechaHora, True))
            .Campos.Add(New LbDatos.cCampo("ComprobanteDig", LbDatos.ETipo.Bit, True))
            .Campos.Add(New LbDatos.cCampo("FormatoFactura", LbDatos.ETipo.Numerico, True))
            .Campos.Add(New LbDatos.cCampo("FoliosTerminal", LbDatos.ETipo.Bit, True))

            .Campos.Add(New LbDatos.cCampo("ClienteClave", LbDatos.ETipo.Cadena, "", False, False, True, True))
            .Campos.Add(New LbDatos.cCampo("DirRepMensual", LbDatos.ETipo.Cadena, False))
            .Campos.Add(New LbDatos.cCampo("DirDocXML", LbDatos.ETipo.Cadena, False))
            .Campos.Add(New LbDatos.cCampo("DirArchivosFacElec", LbDatos.ETipo.Cadena, False))
            .Campos.Add(New LbDatos.cCampo("ContrasenaClave", LbDatos.ETipo.Cadena, False))
            .Campos.Add(New LbDatos.cCampo("ArchivoPEM", LbDatos.ETipo.Cadena, False))
            .Campos.Add(New LbDatos.cCampo("CerBase64", LbDatos.ETipo.Cadena, False))
            '.Campos.Add(New LbDatos.cCampo("VariosPedidos", LbDatos.ETipo.Bit, True))


            .Campos.Add(New LbDatos.cCampo("VersionCFD", LbDatos.ETipo.Numerico, True))
            .Campos.Add(New LbDatos.cCampo("ProveedorTimbre", LbDatos.ETipo.Numerico, False))
            .Campos.Add(New LbDatos.cCampo("CustomerKey", LbDatos.ETipo.Cadena, False))
            .Campos.Add(New LbDatos.cCampo("ServidorTimbre", LbDatos.ETipo.Cadena, False))
            .Campos.Add(New LbDatos.cCampo("ServidorCancelacion", LbDatos.ETipo.Cadena, False))
            .Campos.Add(New LbDatos.cCampo("AchivoPFX64", LbDatos.ETipo.Cadena, False))

            .Campos.Add(New LbDatos.cCampo("MFechaHora", LbDatos.ETipo.MFechaHora, False))
            .Campos.Add(New LbDatos.cCampo("MUsuarioId", LbDatos.ETipo.Cadena, True))

            '.Campos("SEMHistFechaInicio").Valor = .Conexion.ObtenerFecha

        End With
        vcGuardarHist = False
        vcEstado = eEstado.Vacio
    End Sub

    Public Sub Bloquear(ByVal pvMUsuarioId As String)
        Dim vlMUsuarioId As String

        vlMUsuarioId = MUsuarioId
        MUsuarioId = pvMUsuarioId
        Try
            Grabar()
        Catch ex As LbControlError.cError
            Throw New LbControlError.cError("BI0001", vlMUsuarioId)
            Exit Sub
        End Try
    End Sub

    Public Sub Insertar(ByVal pvSubEmpresaID As String, ByVal pvNombreEmpresa As String, ByVal pvRFC As String, ByVal pvPais As String, ByVal pvRegion As String, ByVal pvLocalidad As String, ByVal pvReferenciaDom As String, ByVal pvCiudad As String, ByVal pvColonia As String, ByVal pvCalle As String, ByVal pvNumero As String, ByVal pvNumeroInterior As String, ByVal pvCodigoPostal As String, _
    ByVal pvLogotipo() As Byte, ByVal pvTelefono As String, ByVal pvTipoEstado As Integer, _
    ByVal pvMUsuarioId As String, Optional ByVal pvCampo() As String = Nothing)
        Me.SubEmpresaID = pvSubEmpresaID
        Me.NombreEmpresa = pvNombreEmpresa
        Me.RFC = pvRFC
        Me.Pais = pvPais
        Me.Region = pvRegion
        Me.Localidad = pvLocalidad
        Me.ReferenciaDom = pvReferenciaDom
        Me.Ciudad = pvCiudad
        Me.Colonia = pvColonia
        Me.Calle = pvCalle
        Me.Colonia = pvColonia
        Me.Numero = pvNumero
        Me.NumeroInterior = pvNumeroInterior
        Me.CodigoPostal = pvCodigoPostal
        Me.Logotipo = pvLogotipo
        Me.Telefono = pvTelefono
        Me.TipoEstado = pvTipoEstado
        Me.MUsuarioId = pvMUsuarioId

        Call Insertar(pvCampo)
    End Sub

    Public Sub Insertar(Optional ByVal pvCampo() As String = Nothing)
        vcTablaPadre.Campos("MFechaHora").Valor = vcConexion.ObtenerFecha
        'If Not ExisteLlaveCandidata(Me.Clave) Then
        Try
            ValidarCampos(pvCampo)
        Catch ex As LbControlError.cError
            Throw ex
        End Try
        'Else
        'Throw New LbControlError.cError("BE0002", , "Clave")
        'End If
        vcEstado = eEstado.Nuevo
    End Sub

    Public Sub Limpiar()
        Dim i As Integer
        For i = 0 To vcTablaPadre.Campos.Count - 1
            If vcTablaPadre.Campos(i).Tipo = LbDatos.ETipo.Cadena Then
                vcTablaPadre.Campos(i).Valor = Nothing
            Else
                vcTablaPadre.Campos(i).Valor = System.DBNull.Value
            End If
        Next

        For i = 0 To vcSemHist.Campos.Count - 1
            If vcSemHist.Campos(i).Tipo = LbDatos.ETipo.Cadena Then
                vcSemHist.Campos(i).Valor = Nothing
            Else
                vcSemHist.Campos(i).Valor = System.DBNull.Value
            End If
        Next
        vcGuardarHist = False
        vcEstado = eEstado.Vacio
    End Sub

    Public Function Existe(ByVal pvSubEmpresaID As String) As Boolean
        Dim vlDataTable As DataTable

        vlDataTable = vcTablaPadre.Seleccionar("SubEmpresaID='" & pvSubEmpresaID & "'")
        If vlDataTable.Rows.Count > 0 Then
            Return True
        End If
        Return False
    End Function

    Public Function ExisteNombre(ByVal pvNombreEmpresa As String) As Boolean
        Dim vlDataTable As DataTable

        vlDataTable = vcTablaPadre.Seleccionar("NombreEmpresa='" & pvNombreEmpresa & "'")
        If vlDataTable.Rows.Count > 0 Then

            Return True
        End If
        Return False
    End Function

    Public Sub Recuperar(ByVal pvSubEmpresaID As String)
        Dim vlDataTable As New DataTable
        'Dim vlDataRoe As DataRow

        Call Limpiar()
        Try
            vlDataTable = vcTablaPadre.Seleccionar("SubEmpresaID='" + pvSubEmpresaID + "'")
        Catch ex As LbControlError.cError
            Throw ex
        End Try

        If vlDataTable.Rows.Count = 0 Then
            Throw New LbControlError.cError("BE0002")
        End If

        For Each vlCampo As LbDatos.cCampo In vcTablaPadre.Campos
            vlCampo.Valor = vlDataTable.Rows(0)(vlCampo.Nombre)
        Next


        Try
            vlDataTable = vcSemHist.Seleccionar("SubEmpresaID='" + pvSubEmpresaID + "' order by SEMHistFechaInicio desc")
        Catch ex As LbControlError.cError
            Throw ex
        End Try

        If vlDataTable.Rows.Count = 0 Then
            Throw New LbControlError.cError("BE0002")
        End If

        For Each vlCampo As LbDatos.cCampo In vcSemHist.Campos
            vlCampo.Valor = vlDataTable.Rows(0)(vlCampo.Nombre)
        Next


        vcEstado = eEstado.Recuperado
    End Sub

    Public Sub Recuperar(ByVal pvSubEmpresaID As String, ByVal Fecha As DateTime)
        Dim vlDataTable As New DataTable
        'Dim vlDataRoe As DataRow

        Call Limpiar()
        Try
            vlDataTable = vcTablaPadre.Seleccionar("SubEmpresaID='" + pvSubEmpresaID + "'")
        Catch ex As LbControlError.cError
            Throw ex
        End Try

        If vlDataTable.Rows.Count = 0 Then
            Throw New LbControlError.cError("BE0002")
        End If

        For Each vlCampo As LbDatos.cCampo In vcTablaPadre.Campos
            vlCampo.Valor = vlDataTable.Rows(0)(vlCampo.Nombre)
        Next


        Try
            vlDataTable = vcSemHist.Seleccionar("SubEmpresaID='" + pvSubEmpresaID + "' AND SEMHistFechaInicio < '" + Fecha.ToString("s") + "'order by SEMHistFechaInicio desc")
        Catch ex As LbControlError.cError
            Throw ex
        End Try

        If vlDataTable.Rows.Count = 0 Then
            Throw New LbControlError.cError("BE0002")
        End If
        For Each vlCampo As LbDatos.cCampo In vcSemHist.Campos
            vlCampo.Valor = vlDataTable.Rows(0)(vlCampo.Nombre)
        Next

        vcEstado = eEstado.Recuperado
    End Sub

    Public Function RecuperarTabla() As DataTable
        Dim vlDataTable As New DataTable
        'Dim vlDataRoe As DataRow


        Try
            vlDataTable = vcTablaPadre.Seleccionar(" TipoEstado=1", "SubEmpresaID,NombreEmpresa")
        Catch ex As LbControlError.cError
            Throw ex
        End Try



        Return vlDataTable

    End Function

    'Public Function EstaAsignadaProducto(ByVal pvSubEmpresaID As String) As Boolean
    '    Dim oProducto As New ERMPROLOG.cProducto()
    '    Return oProducto.Tabla.Recuperar("SubEmpresaID='" + pvSubEmpresaID + "' and TipoFase=1").Rows.Count > 0


    'End Function

    Public Sub Grabar(Optional ByVal bLogotipo As Boolean = False)
        Try
            ValidarCampos(New String() {"NombreEmpresa"})
        Catch ex As LbControlError.cError
            Throw ex
        End Try

        If Not bLogotipo Then vcTablaPadre.Campos.Remove(vcLogo)


        Try
            Select Case vcEstado
                Case eEstado.Nuevo
                    vcTablaPadre.Insertar()
                    vcEstado = eEstado.Recuperado
                Case eEstado.Modificado

                    'vcTablaPadre.Campos.Remove()
                    vcTablaPadre.Modificar()
                    vcEstado = eEstado.Recuperado
                Case eEstado.Eliminado
                    vcTablaPadre.Eliminar()
                    Call Limpiar()
            End Select

        Catch ex As LbControlError.cError
            Throw ex
        End Try
        If Not bLogotipo Then vcTablaPadre.Campos.Add(vcLogo)
        vcSemHist.Campos("SEMHistFechaInicio").Valor = vcSemHist.Conexion.ObtenerFecha
        If vcGuardarHist Then vcSemHist.Insertar()
    End Sub

    Public Sub Eliminar()
        vcEstado = eEstado.Eliminado
    End Sub

    Public Sub ValidarCampos(Optional ByVal pvCampo() As String = Nothing)
        If IsNothing(pvCampo) Then
            Dim i As Integer
            'Dim vlParametroMSG() As LbControlError.cParametroMSG
            With vcTablaPadre
                For i = 0 To .Campos.Count - 1
                    Try
                        Call ValidaCampo(.Campos(i).Nombre)
                    Catch ex As LbControlError.cError
                        Throw ex
                    End Try
                Next
            End With
        Else
            For Each vlCampo As String In pvCampo
                Try
                    Call ValidaCampo(vlCampo)
                Catch ex As LbControlError.cError
                    Throw ex
                End Try
            Next
        End If
    End Sub

    Private Sub ValidaCampo(ByVal pvNombre As String)
        'Dim i As Integer
        'Dim vlParametroMSG() As LbControlError.cParametroMSG
        If vcTablaPadre.Seleccionar.Columns.Contains(pvNombre) Then


            With vcTablaPadre
                If .Campos(pvNombre).Requerido Then
                    If IsDBNull(.Campos(pvNombre).Valor) Or .Campos(pvNombre).Valor Is Nothing Then
                        Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("SEM" + .Campos(pvNombre).Nombre, True)}, .Campos(pvNombre).Nombre)
                    End If
                    If .Campos(pvNombre).Tipo = LbDatos.ETipo.Cadena Then
                        If .Campos(pvNombre).Valor.ToString().Trim() = "" Then
                            Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("SEM" + .Campos(pvNombre).Nombre, True)}, .Campos(pvNombre).Nombre)
                        End If
                    End If
                End If
                Select Case .Campos(pvNombre).Tipo
                    Case LbDatos.ETipo.Numerico
                        If IsDBNull(.Campos(pvNombre).Valor) = False Then
                            If .Campos(pvNombre).Valor < 0 Then
                                Throw New LbControlError.cError("E0007", , .Campos(pvNombre).Nombre)
                            End If
                        End If
                End Select
            End With
        Else
            With vcSemHist



                If IsDBNull(.Campos(pvNombre).Valor) Or .Campos(pvNombre).Valor Is Nothing Then
                    If pvNombre = "ClienteClave" Then
                        Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("COHClienteGenerico", True)}, .Campos(pvNombre).Nombre)

                    ElseIf pvNombre = "VersionCFD" OrElse pvNombre = "FormatoFactura" OrElse pvNombre = "ProveedorTimbre" OrElse pvNombre = "ServidorTimbre" OrElse pvNombre = "CustomerKey" Then
                        Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("SEM" + .Campos(pvNombre).Nombre, True)}, .Campos(pvNombre).Nombre)
                    Else
                        Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("COH" + .Campos(pvNombre).Nombre, True)}, .Campos(pvNombre).Nombre)
                    End If


                End If
                If .Campos(pvNombre).Tipo = LbDatos.ETipo.Cadena AndAlso .Campos(pvNombre).Valor.ToString().Trim() = "" Then
                    If pvNombre = "ClienteClave" Then
                        Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("COHClienteGenerico", True)}, .Campos(pvNombre).Nombre)
                    ElseIf pvNombre = "VersionCFD" OrElse pvNombre = "FormatoFactura" OrElse pvNombre = "ProveedorTimbre" OrElse pvNombre = "ServidorTimbre" OrElse pvNombre = "CustomerKey" Then
                        Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("SEM" + .Campos(pvNombre).Nombre, True)}, .Campos(pvNombre).Nombre)
                    Else
                        Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("COH" + .Campos(pvNombre).Nombre, True)}, .Campos(pvNombre).Nombre)
                    End If
                End If


            End With
        End If

    End Sub

    Public Sub InsertarEn(ByRef prDataTable As DataTable)
        vcTablaPadre.Insertar(prDataTable)
    End Sub

    Public Sub ModificarEn(ByRef prDataTable As DataTable)
        vcTablaPadre.Modificar(prDataTable)
    End Sub
#End Region



    Public Function RecuperarHistorialOrdenado() As DataTable
        ' Dim campos As String = "ConHist.tipolenguaje,ConHist.MonedaId,ConHist.MostrarLogo,ConHist.TipoClaveProducto,ConHist.DigitoClaveProd,ConHist.DiasSurtido,ConHist.CambioProducto,ConHist.ConversionKg,ConHist.FiltroProductos,ConHist.ModificarVenta,ConHist.CancelarVenta,ConHist.AbonoProgramado,ConHist.CobrarVentas,ConHist.PagoAutomatico,"
        ' campos = campos & "ConHist.TipoLimiteCredito,ConHist.PorcentajeRiesgo,ConHist.DecimalesImporte,ConHist.ComprobanteDig,ConHist.FoliosTerminal,ConHist.DirRepMensual,ConHist.TicketConfigurado,ConHist.DiasAnteriores,ConHist.DiasPosteriores,ConHist.ClienteVariasRutas,ConHist.CodigoBarrasCliente,ConHist.ContrasenaCliente,ConHist.ValidaInv,ConHist.DirectorioSDF,ConHist.DirInterfaz,ConHist.InterfazTXT,ConHist.IntUnidadVta,ConHist.Inventario"
        ' campos = campos & ",ConHist.AuditarCarga,ConHist.Interfaztxt,ConHist.Preliquidacion,ConHist.DiferenciaPreliqui,ConHist.CantidadSerAct,ConHist.EnvioParcial,Conhist.EliminaEnviado,CONHistFechaInicio,ConHist.TipoIniciarVisita,ConHist.LimiteGPS,ConHist.ClientesVisitados,ConHist.DatosCteNuevo,ConHist.VenderApartado,ConHist.ConsignaSaldada,ConHist.VentaSinSurtir,ConHist.ConsignaContado,ConHist.MFechaHora,"
        Return vcSemHist.Seleccionar("SubEmpresaID='" & Me.SubEmpresaID & "' ORDER BY SEMHistFechaInicio ")
    End Function
    Public Function RecuperarHistorialTodasSubEmpresas() As DataTable
        ' Dim campos As String = "ConHist.tipolenguaje,ConHist.MonedaId,ConHist.MostrarLogo,ConHist.TipoClaveProducto,ConHist.DigitoClaveProd,ConHist.DiasSurtido,ConHist.CambioProducto,ConHist.ConversionKg,ConHist.FiltroProductos,ConHist.ModificarVenta,ConHist.CancelarVenta,ConHist.AbonoProgramado,ConHist.CobrarVentas,ConHist.PagoAutomatico,"
        ' campos = campos & "ConHist.TipoLimiteCredito,ConHist.PorcentajeRiesgo,ConHist.DecimalesImporte,ConHist.ComprobanteDig,ConHist.FoliosTerminal,ConHist.DirRepMensual,ConHist.TicketConfigurado,ConHist.DiasAnteriores,ConHist.DiasPosteriores,ConHist.ClienteVariasRutas,ConHist.CodigoBarrasCliente,ConHist.ContrasenaCliente,ConHist.ValidaInv,ConHist.DirectorioSDF,ConHist.DirInterfaz,ConHist.InterfazTXT,ConHist.IntUnidadVta,ConHist.Inventario"
        ' campos = campos & ",ConHist.AuditarCarga,ConHist.Interfaztxt,ConHist.Preliquidacion,ConHist.DiferenciaPreliqui,ConHist.CantidadSerAct,ConHist.EnvioParcial,Conhist.EliminaEnviado,CONHistFechaInicio,ConHist.TipoIniciarVisita,ConHist.LimiteGPS,ConHist.ClientesVisitados,ConHist.DatosCteNuevo,ConHist.VenderApartado,ConHist.ConsignaSaldada,ConHist.VentaSinSurtir,ConHist.ConsignaContado,ConHist.MFechaHora,"
        Return vcSemHist.Seleccionar("")
    End Function

    Public Sub GenerarArchivoPEM()
        If ContrasenaClave <> "" And DirArchivosFacElec <> "" And System.IO.File.Exists(System.AppDomain.CurrentDomain.BaseDirectory & "OPENSSL\OPENSSL.exe") Then
            Dim DirSello As String = Nothing
            Dim DirOpenSSL As String = Nothing
            Dim Leido As String = Nothing

            If Not System.IO.Directory.Exists(DirArchivosFacElec) Then
                Throw New LbControlError.cError("E0682", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(DirArchivosFacElec, False)}, "DirDocXML")
            End If

            For Each s As String In System.IO.Directory.GetFiles(DirArchivosFacElec)
                If s.EndsWith(".key") Then
                    DirSello = s
                    Exit For
                End If
            Next

            Try
                If Not DirSello Is Nothing Then
                    DirOpenSSL = System.AppDomain.CurrentDomain.BaseDirectory & "OPENSSL\OPENSSL.exe"
                    Dim cmd As String = "pkcs8 -inform DER -in """ & DirSello & """ -passin pass:" & ContrasenaClave & " -out """ & DirSello & ".pem"""

                    Dim oStart As New System.Diagnostics.ProcessStartInfo("""" & DirOpenSSL & """", cmd)
                    oStart.WindowStyle = ProcessWindowStyle.Hidden
                    oStart.CreateNoWindow = True

                    Process.Start(oStart)
                    For i As Integer = 0 To 3
                        System.Threading.Thread.Sleep(500)
                        If System.IO.File.Exists(DirSello & ".pem") AndAlso New System.IO.FileInfo(DirSello & ".pem").Length > 0 Then
                            Exit For
                        End If
                    Next

                    If Not System.IO.File.Exists(DirSello & ".pem") Then
                        Throw New LbControlError.cError("E0681", , "DirDocXML")
                    End If
                    Dim fi1 As System.IO.FileInfo = New System.IO.FileInfo(DirSello & ".pem")
                    If fi1.Length = 0 Then Throw New LbControlError.cError("E0681", , "DirDocXML")

                    Dim leer_archivo As New System.IO.FileStream(DirSello & ".pem", IO.FileMode.Open)
                    Dim bytesLeidos(leer_archivo.Length) As Byte
                    leer_archivo.Read(bytesLeidos, 0, leer_archivo.Length)
                    leer_archivo.Close()

                    ArchivoPEM = Convert.ToBase64String(bytesLeidos)
                    System.Threading.Thread.Sleep(500)
                    System.IO.File.Delete(DirSello & ".pem")
                Else
                    Throw New LbControlError.cError("E0681", , "DirDocXML")
                End If

            Catch ex As LbControlError.cError
                If System.IO.File.Exists(DirSello & ".pem") Then
                    System.IO.File.Delete(DirSello & ".pem")
                End If

                ex.Mostrar()
                'Throw New LbControlError.cError("E0681", , "DirDocXML")
            End Try

        End If

    End Sub
    Friend Shared Function ReadFile(ByVal strArchivo As String) As Byte()
        Dim f As New System.IO.FileStream(strArchivo, System.IO.FileMode.Open, System.IO.FileAccess.Read)
        Dim size As Integer = CInt(f.Length)
        Dim data As Byte() = New Byte(size - 1) {}
        size = f.Read(data, 0, size)
        f.Close()
        Return data
    End Function
    Public Sub GenerarPFXBase64()
        If ContrasenaClave <> "" And DirArchivosFacElec <> "" And System.IO.File.Exists(System.AppDomain.CurrentDomain.BaseDirectory & "OPENSSL\OPENSSL.exe") Then
            Dim DirKEYPEM As String = Nothing
            Dim DirCERPEM As String = Nothing

            Dim DirOpenSSL As String = Nothing
            Dim Leido As String = Nothing

            If Not System.IO.Directory.Exists(DirArchivosFacElec) Then
                Throw New LbControlError.cError("E0682", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(DirArchivosFacElec, False)}, "DirDocXML")
            End If
            Dim DirPFX As String = System.IO.Path.Combine(DirArchivosFacElec, "PFX.PFX")

            For Each s As String In System.IO.Directory.GetFiles(DirArchivosFacElec)
                If s.EndsWith(".key") Then
                    DirKEYPEM = s

                End If
                If s.EndsWith(".cer") Then
                    DirCERPEM = s

                End If
            Next

            Try
                If Not DirKEYPEM Is Nothing Then
                    DirOpenSSL = System.AppDomain.CurrentDomain.BaseDirectory & "OPENSSL\OPENSSL.exe"
                    Dim cmd As String = "pkcs8 -inform DER -in """ & DirKEYPEM & """ -passin pass:" & ContrasenaClave & " -out """ & DirKEYPEM & ".pem"""
                    Dim cmdcer As String = "x509  -inform DER -in """ & DirCERPEM & """  -out """ & DirCERPEM & ".pem"""
                    Dim cmdpfx As String = " pkcs12 -export -out """ & DirPFX & """ -inkey  """ & DirKEYPEM & ".pem"" -in  """ & DirCERPEM & ".pem"" -passout pass:" & ContrasenaClave & ""

                    Dim oStart As New System.Diagnostics.ProcessStartInfo("""" & DirOpenSSL & """", cmd)
                    oStart.WindowStyle = ProcessWindowStyle.Hidden
                    oStart.CreateNoWindow = True

                    Process.Start(oStart)
                    For i As Integer = 0 To 3
                        System.Threading.Thread.Sleep(500)
                        If System.IO.File.Exists(DirKEYPEM & ".pem") AndAlso New System.IO.FileInfo(DirKEYPEM & ".pem").Length > 0 Then
                            Exit For
                        End If
                    Next

                    oStart = New System.Diagnostics.ProcessStartInfo("""" & DirOpenSSL & """", cmdcer)
                    oStart.WindowStyle = ProcessWindowStyle.Hidden
                    oStart.CreateNoWindow = True

                    Process.Start(oStart)
                    For i As Integer = 0 To 3
                        System.Threading.Thread.Sleep(500)
                        If System.IO.File.Exists(DirCERPEM & ".pem") AndAlso New System.IO.FileInfo(DirCERPEM & ".pem").Length > 0 Then
                            Exit For
                        End If
                    Next
                    oStart = New System.Diagnostics.ProcessStartInfo("""" & DirOpenSSL & """", cmdpfx)
                    oStart.WindowStyle = ProcessWindowStyle.Hidden
                    oStart.CreateNoWindow = True

                    Process.Start(oStart)
                    For i As Integer = 0 To 3
                        System.Threading.Thread.Sleep(500)
                        If System.IO.File.Exists(DirPFX) AndAlso New System.IO.FileInfo(DirPFX).Length > 0 Then
                            Exit For
                        End If
                    Next

                 
                    Dim fi1 As System.IO.FileInfo = New System.IO.FileInfo(DirPFX)
                    If fi1.Length = 0 Then Throw New LbControlError.cError("E0681", , "DirDocXML")

                    Dim leer_archivo As New System.IO.FileStream(DirPFX, IO.FileMode.Open)
                    Dim bytesLeidos(leer_archivo.Length) As Byte
                    leer_archivo.Read(bytesLeidos, 0, leer_archivo.Length)
                    leer_archivo.Close()

                    Me.AchivoPFX64 = Convert.ToBase64String(bytesLeidos)
                    System.Threading.Thread.Sleep(500)
                    System.IO.File.Delete(DirKEYPEM & ".pem")
                    System.IO.File.Delete(DirCERPEM & ".pem")
                    System.IO.File.Delete(DirPFX)
                Else
                    Throw New LbControlError.cError("E0681", , "DirDocXML")
                End If

            Catch ex As LbControlError.cError
                If System.IO.File.Exists(DirKEYPEM & ".pem") Then
                    System.IO.File.Delete(DirKEYPEM & ".pem")
                End If

                ex.Mostrar()
                'Throw New LbControlError.cError("E0681", , "DirDocXML")
            End Try

        End If
    End Sub
    Public Sub GenerarCERBase64()
        If DirArchivosFacElec <> "" Then
        

            Dim SArchivos As String()
            SArchivos = System.IO.Directory.GetFiles(DirArchivosFacElec, "*.cer")

            If (SArchivos.Length = 0) Then

                Throw New LbControlError.cError("E0839", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(DirArchivosFacElec)}, "DirDocXML")
               
            End If

            Dim ocert As New System.Security.Cryptography.X509Certificates.X509Certificate2()



            Dim certEmisor As New System.Security.Cryptography.X509Certificates.X509Certificate2()
            ' Generas un objeto del tipo de certificado
            Dim byteCertData As Byte() = ReadFile(SArchivos(0))
            ' Manda llamar la funcion Readfile para cargar el ar.cer 
            certEmisor.Import(byteCertData)

            ' Importa los datos del certificado qeu acabas de leer
            CerBase64 = Convert.ToBase64String(certEmisor.GetRawCertData())
            ' Conviertelos a Base64

        End If

    End Sub

End Class

Public Class cSEMTabla
    Private vcSubEmpresa As cSubEmpresa

    Public Sub New(ByRef prSubEmpresa As cSubEmpresa)
        vcSubEmpresa = prSubEmpresa
    End Sub

    Public Function Recuperar(ByVal pvFiltro As String) As DataTable
        Dim vlDataTable As New DataTable
        vlDataTable = vcSubEmpresa.cTabla.Seleccionar(pvFiltro)
        Recuperar = vlDataTable
    End Function

    Public Sub Grabar(ByRef prDataTable As DataTable)
        vcSubEmpresa.cTabla.GrabarTabla(prDataTable, vcSubEmpresa.cTabla.Campos)
    End Sub
End Class
