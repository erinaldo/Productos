Public Enum eEstado
    Vacio = 0
    Nuevo
    Modificado
    Recuperado
    Eliminado
End Enum

Public Class cVendedor
    Private vcConexion As LbConexion.cConexion = LbConexion.cConexion.Instancia
    Private vcTbVendedor As LbDatos.cTabla
    Public Tabla As cVENTabla
    Private vcEstado As eEstado
    Friend vcVEDArrayList As New ArrayList
    Friend vcVEDDataTable As New DataTable
    Private vcVEDTabla As cVEDTabla
    Friend vcVEEArrayList As New ArrayList
    Friend vcVEEDataTable As New DataTable
    Private vcVEETabla As cVEETabla
    Friend vcVEJDataTable As New DataTable
    Private vcVEJTabla As cVEJTabla
    Friend vcVCHArrayList As New ArrayList
    Friend vcVCHDataTable As New DataTable
    Private vcVCHTabla As cVCHTabla

#Region "Propiedades"

    Public Property VendedorID() As String
        Get
            Return vcTbVendedor.Campos("VendedorID").Valor
        End Get
        Set(ByVal Value As String)
            If vcEstado = eEstado.Vacio Or vcEstado = eEstado.Nuevo Then
                vcTbVendedor.Campos("VendedorID").Valor = Value
            End If
        End Set
    End Property

    Public Property MCNClave() As String
        Get
            Return IIf(vcTbVendedor.Campos("MCNClave").Valor Is DBNull.Value, "", vcTbVendedor.Campos("MCNClave").Valor)
        End Get
        Set(ByVal Value As String)
            If Value.Trim() = "" Then
                vcTbVendedor.Campos("MCNClave").Valor = DBNull.Value
                vcTbVendedor.Campos("ModuloClave").Valor = DBNull.Value
            Else
                vcTbVendedor.Campos("MCNClave").Valor = Value
                Dim valor As String = ObtenerModuloClave(Value)
                If valor.Trim() = "" Then
                    vcTbVendedor.Campos("ModuloClave").Valor = DBNull.Value
                Else
                    vcTbVendedor.Campos("ModuloClave").Valor = valor
                End If
            End If
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property Nombre() As String
        Get
            Return vcTbVendedor.Campos("Nombre").Valor
        End Get
        Set(ByVal Value As String)
            vcTbVendedor.Campos("Nombre").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property ModuloClave() As String
        Get
            Return IIf(IsDBNull(vcTbVendedor.Campos("ModuloClave").Valor), "", vcTbVendedor.Campos("ModuloClave").Valor)
        End Get
        Set(ByVal Value As String)
            If Value.Trim() = "" Then
                vcTbVendedor.Campos("ModuloClave").Valor = DBNull.Value
            Else
                vcTbVendedor.Campos("ModuloClave").Valor = Value
            End If
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property AlmacenId() As String
        Get
            Return IIf(IsDBNull(vcTbVendedor.Campos("AlmacenId").Valor), "", vcTbVendedor.Campos("AlmacenId").Valor)
        End Get
        Set(ByVal Value As String)
            If Value <> "" Then
                vcTbVendedor.Campos("AlmacenId").Valor = Value
                If vcEstado = eEstado.Recuperado Then
                    vcEstado = eEstado.Modificado
                End If
            End If
        End Set
    End Property

    Public Property TipoCapturaProductos() As Integer
        Get
            Return vcTbVendedor.Campos("TipoCapturaProductos").Valor
        End Get
        Set(ByVal Value As Integer)
            vcTbVendedor.Campos("TipoCapturaProductos").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property Nivel() As Integer
        Get
            Return vcTbVendedor.Campos("Nivel").Valor
        End Get
        Set(ByVal Value As Integer)
            vcTbVendedor.Campos("Nivel").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property LimiteDescuento() As Double
        Get
            Return vcTbVendedor.Campos("LimiteDescuento").Valor
        End Get
        Set(ByVal Value As Double)
            vcTbVendedor.Campos("LimiteDescuento").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property TipoEstado() As Integer
        Get
            Return vcTbVendedor.Campos("TipoEstado").Valor
        End Get
        Set(ByVal Value As Integer)
            vcTbVendedor.Campos("TipoEstado").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property tipo() As Integer
        Get
            Return vcTbVendedor.Campos("Tipo").Valor
        End Get
        Set(ByVal value As Integer)
            vcTbVendedor.Campos("Tipo").Valor = value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property USUId() As String
        Get
            Return vcTbVendedor.Campos("USUId").Valor
        End Get
        Set(ByVal Value As String)
            vcTbVendedor.Campos("USUId").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property TerminalClave() As String
        Get

            Return IIf(IsDBNull(vcTbVendedor.Campos("TerminalClave").Valor), "", vcTbVendedor.Campos("TerminalClave").Valor)
        End Get
        Set(ByVal Value As String)
            If Value.Trim <> "" Then
                vcTbVendedor.Campos("TerminalClave").Valor = Value
            Else
                vcTbVendedor.Campos("TerminalClave").Valor = DBNull.Value
            End If
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If

        End Set
    End Property

    Public Property Baja() As Boolean
        Get
            Return vcTbVendedor.Campos("Baja").Valor
        End Get
        Set(ByVal Value As Boolean)
            vcTbVendedor.Campos("Baja").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property MUsuarioID() As String
        Get
            Return vcTbVendedor.Campos("MUsuarioID").Valor
        End Get
        Set(ByVal Value As String)
            vcTbVendedor.Campos("MUsuarioID").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property ActualizaEsquema() As Boolean
        Get
            Return vcTbVendedor.Campos("ActualizaEsquema").Valor
        End Get
        Set(ByVal Value As Boolean)
            vcTbVendedor.Campos("ActualizaEsquema").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property CapturaPrecio() As Boolean
        Get
            Return vcTbVendedor.Campos("CapturaPrecio").Valor
        End Get
        Set(ByVal Value As Boolean)
            vcTbVendedor.Campos("CapturaPrecio").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property DirInterfazSalida() As String
        Get
            Return IIf(IsDBNull(vcTbVendedor.Campos("DirInterfazSalida").Valor), String.Empty, vcTbVendedor.Campos("DirInterfazSalida").Valor)
        End Get
        Set(ByVal Value As String)
            vcTbVendedor.Campos("DirInterfazSalida").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property MostrarEsquema() As Boolean
        Get
            Return vcTbVendedor.Campos("MostrarEsquema").Valor
        End Get
        Set(ByVal Value As Boolean)
            vcTbVendedor.Campos("MostrarEsquema").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property MostrarCuota() As Boolean
        Get
            Return vcTbVendedor.Campos("MostrarCuota").Valor
        End Get
        Set(ByVal Value As Boolean)
            vcTbVendedor.Campos("MostrarCuota").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property MantenerPrm() As Boolean
        Get
            Return vcTbVendedor.Campos("MantenerPrm").Valor
        End Get
        Set(ByVal Value As Boolean)
            vcTbVendedor.Campos("MantenerPrm").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property
    Public Property JornadaTrabajo() As Boolean
        Get
            Return vcTbVendedor.Campos("JornadaTrabajo").Valor
        End Get
        Set(ByVal Value As Boolean)
            vcTbVendedor.Campos("JornadaTrabajo").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property CapturaFolioFac() As Boolean
        Get
            Return vcTbVendedor.Campos("CapturaFolioFac").Valor
        End Get
        Set(ByVal Value As Boolean)
            vcTbVendedor.Campos("CapturaFolioFac").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property TipoModImp() As Integer
        Get
            Return vcTbVendedor.Campos("TipoModImp").Valor
        End Get
        Set(ByVal Value As Integer)
            vcTbVendedor.Campos("TipoModImp").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property EditarDatosFiscal() As Boolean
        Get
            Return vcTbVendedor.Campos("EditarDatosFiscal").Valor
        End Get
        Set(ByVal Value As Boolean)
            vcTbVendedor.Campos("EditarDatosFiscal").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property Kilometraje() As Boolean
        Get
            Return vcTbVendedor.Campos("Kilometraje").Valor
        End Get
        Set(ByVal Value As Boolean)
            vcTbVendedor.Campos("Kilometraje").Valor = Value
            If vcEstado = eEstado.Recuperado Then
                vcEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public ReadOnly Property MFechaHora() As DateTime
        Get
            Return vcTbVendedor.Campos("MFechaHora").Valor
        End Get
    End Property

    Friend ReadOnly Property cTabla() As LbDatos.cTabla
        Get
            Return vcTbVendedor
        End Get
    End Property

    Public ReadOnly Property cEstado() As eEstado
        Get
            Return vcEstado
        End Get
    End Property

#End Region

#Region "Funciones"

    Public Sub New()
        vcTbVendedor = New LbDatos.cTabla("Vendedor")
        vcVEDTabla = New cVEDTabla(Me)
        vcVEETabla = New cVEETabla(Me)
        vcVEJTabla = New cVEJTabla(Me)
        vcVCHTabla = New cVCHTabla(Me)
        Tabla = New cVENTabla(Me)
        vcVEDDataTable = VendedorDescuento.Tabla.Recuperar("VendedorId=''")
        vcVEEDataTable = VendedorEsquema.Tabla.Recuperar("VendedorId=''")
        vcVEJDataTable = Me.VendedorJornada.Tabla.Recuperar("VendedorId=''")
        vcVCHDataTable = Me.VENCentroDistHist.Tabla.Recuperar("VendedorId=''")
        With vcTbVendedor
            .AgregarCampo(New LbDatos.cCampo("VendedorID", LbDatos.ETipo.Cadena, "", True, True))
            .AgregarCampo(New LbDatos.cCampo("MCNClave", LbDatos.ETipo.Cadena))
            .AgregarCampo(New LbDatos.cCampo("Nombre", LbDatos.ETipo.Cadena, True))
            .AgregarCampo(New LbDatos.cCampo("ModuloClave", LbDatos.ETipo.Cadena))
            .AgregarCampo(New LbDatos.cCampo("AlmacenId", LbDatos.ETipo.Cadena))
            .AgregarCampo(New LbDatos.cCampo("TipoCapturaProductos", LbDatos.ETipo.Numerico, True))
            .AgregarCampo(New LbDatos.cCampo("Nivel", LbDatos.ETipo.Numerico, True))
            .AgregarCampo(New LbDatos.cCampo("LimiteDescuento", LbDatos.ETipo.Numerico, True))
            .AgregarCampo(New LbDatos.cCampo("TipoEstado", LbDatos.ETipo.Numerico, True))
            .AgregarCampo(New LbDatos.cCampo("USUId", LbDatos.ETipo.Cadena, True))
            .AgregarCampo(New LbDatos.cCampo("TerminalClave", LbDatos.ETipo.Cadena))
            .AgregarCampo(New LbDatos.cCampo("Baja", LbDatos.ETipo.Bit, True))
            .AgregarCampo(New LbDatos.cCampo("MFechaHora", LbDatos.ETipo.MFechaHora, False))
            .AgregarCampo(New LbDatos.cCampo("MUsuarioID", LbDatos.ETipo.Cadena, True))
            .AgregarCampo(New LbDatos.cCampo("ActualizaEsquema", LbDatos.ETipo.Bit, True))
            .AgregarCampo(New LbDatos.cCampo("CapturaPrecio", LbDatos.ETipo.Bit, True))
            .AgregarCampo(New LbDatos.cCampo("DirInterfazSalida", LbDatos.ETipo.Cadena, False))
            .AgregarCampo(New LbDatos.cCampo("MostrarEsquema", LbDatos.ETipo.Bit, True))
            .AgregarCampo(New LbDatos.cCampo("MostrarCuota", LbDatos.ETipo.Bit, True))
            .AgregarCampo(New LbDatos.cCampo("JornadaTrabajo", LbDatos.ETipo.Bit, True))
            .AgregarCampo(New LbDatos.cCampo("CapturaFolioFac", LbDatos.ETipo.Bit, True))
            .AgregarCampo(New LbDatos.cCampo("TipoModImp", LbDatos.ETipo.Numerico, False))
            .AgregarCampo(New LbDatos.cCampo("MantenerPrm", LbDatos.ETipo.Bit, True))
            .AgregarCampo(New LbDatos.cCampo("EditarDatosFiscal", LbDatos.ETipo.Bit, True))
            .AgregarCampo(New LbDatos.cCampo("Kilometraje", LbDatos.ETipo.Bit, True))
            .AgregarCampo(New LbDatos.cCampo("Tipo", LbDatos.ETipo.Numerico, True))
        End With
        vcEstado = eEstado.Vacio
    End Sub

    Public Function Bloquear(ByVal pvMUsuarioId As String) As String
        Dim vlMUsuarioId As String

        vlMUsuarioId = MUsuarioID
        MUsuarioID = pvMUsuarioId
        Try
            Grabar()
        Catch ex As LbControlError.cError
            Throw New LbControlError.cError("BI0001", vlMUsuarioId)
            Exit Function
        End Try
        Bloquear = vlMUsuarioId
    End Function

    Public Function Insertar(ByVal pvVendedorID As String, ByVal pvNombre As String, ByVal pvMCNClave As String, _
                             ByVal pvAlmacenId As String, ByVal pvTipoCapturaProductos As Integer, ByVal pvNivel As String, _
                             ByVal pvLimiteDescuento As Double, ByVal pvTipoEstado As Integer, ByVal pvUSUId As String, _
                             ByVal pvTerminalClave As String, ByVal pvBaja As Boolean, ByVal pvMUsuarioId As String, _
                             ByVal pvActualizaEsquema As Boolean, ByVal pvCapturaPrecio As Boolean, ByVal pvDirInterfazSalida As String, _
                             ByVal pvMostrarEsquema As Boolean, ByVal pvJornadaTrabajo As Boolean, ByVal pvCapturaFolioFac As Boolean, _
                             ByVal pvMostrarCuota As Boolean, ByVal pvMantenerPrm As Boolean, ByVal pvTipoModImp As Integer, _
                             ByVal pvEditarDatosFiscal As Boolean, ByVal pvKilometraje As Boolean, ByVal pvTipo As Integer) As Boolean

        If IsDBNull(pvNivel) Or pvNivel Is Nothing Or pvNivel = "" Then
            Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("VENnivel", True)}, "VENnivel")
        End If

        Me.VendedorID = pvVendedorID
        Me.Nombre = pvNombre
        Me.MCNClave = pvMCNClave
        Me.AlmacenId = pvAlmacenId
        Me.TipoCapturaProductos = pvTipoCapturaProductos
        Me.Nivel = pvNivel
        Me.LimiteDescuento = pvLimiteDescuento
        Me.TipoEstado = pvTipoEstado
        Me.USUId = pvUSUId
        Me.TerminalClave = pvTerminalClave
        Me.Baja = pvBaja
        Me.MUsuarioID = pvMUsuarioId
        Me.ActualizaEsquema = pvActualizaEsquema
        Me.CapturaPrecio = pvCapturaPrecio
        Me.DirInterfazSalida = pvDirInterfazSalida
        Me.MostrarEsquema = pvMostrarEsquema
        Me.JornadaTrabajo = pvJornadaTrabajo
        Me.CapturaFolioFac = pvCapturaFolioFac
        Me.MostrarCuota = pvMostrarCuota
        Me.MantenerPrm = pvMantenerPrm
        Me.TipoModImp = pvTipoModImp
        Me.EditarDatosFiscal = pvEditarDatosFiscal
        Me.Kilometraje = pvKilometraje
        Me.tipo = pvTipo
        Return Insertar()
    End Function

    Public Function ObtenerModuloClave(ByVal pvMCNClave As String) As String
        If pvMCNClave.Trim().Length > 0 Then
            Dim sConsulta As String
            sConsulta = "SELECT ModuloClave FROM MOTConfiguracion "
            sConsulta &= "WHERE MCNClave = '" & pvMCNClave.Trim().Replace("'", "''") & "'"
            Dim aObj As String = vcConexion.EjecutarComandoScalar(sConsulta)
            If aObj Is Nothing OrElse aObj Is DBNull.Value Then
                aObj = ""
            End If
            Return aObj.ToString()
        End If
        Return ""
    End Function

    Public Function Insertar() As Boolean
        vcTbVendedor.Campos("MFechaHora").Valor = vcConexion.ObtenerFecha
        Try
            ValidarCampos()
        Catch ex As LbControlError.cError
            Throw ex
        End Try
        vcEstado = eEstado.Nuevo
        Return True
    End Function

    Public Sub Limpiar()
        Dim i As Integer
        For i = 0 To vcTbVendedor.Campos.Count - 1
            vcTbVendedor.Campos(i).ADefault()
        Next
        vcVEDArrayList.Clear()
        vcVEDDataTable.Reset()
        vcVEEArrayList.Clear()
        vcVEEDataTable.Reset()
        vcVCHArrayList.Clear()
        vcVCHDataTable.Reset()
        vcEstado = eEstado.Vacio
    End Sub

    Public Function Existe(ByVal pvVendedorID As String) As Boolean
        Dim vlDtVendedor As DataTable

        vlDtVendedor = vcTbVendedor.Seleccionar("VendedorID='" & pvVendedorID & "'")
        If vlDtVendedor.Rows.Count > 0 Then
            Return True
        End If

        Return False
    End Function

    Public Function ExisteUsuarioAsignado(ByVal pvVendedorID As String, ByVal pvUSUId As String) As String
        Dim vlDtVendedor As DataTable

        vlDtVendedor = vcTbVendedor.Seleccionar("VendedorID<>'" & pvVendedorID & "' and USUId='" & pvUSUId & "' and TipoEstado = 1 and Baja=0")
        If vlDtVendedor.Rows.Count > 0 Then
            Return vlDtVendedor.Rows(0)("Nombre")
        End If

        Return ""
    End Function

    Public Function Recuperar(ByVal pvVendedorID As String) As Boolean
        Dim vlDtVendedor As New DataTable
        Dim vlVendedorDescuento As New cVendedorDescuento(Me)
        Dim vlVendedorDescuentoDT As New cVEDDataTable(vlVendedorDescuento)
        Dim vlVendedorEsquema As New cVendedorEsquema(Me)
        Dim vlVendedorEsquemaDT As New cVEEDataTable(vlVendedorEsquema)
        Dim vlVendedorJornada As New cVendedorJornada(Me)
        Dim vlVendedorJornadaDT As New cVEJDataTable(vlVendedorJornada)
        Dim vlVENCentroDistHist As New cVENCentroDistHist(Me)
        Dim vlVENCentroDistHistDT As New cVCHDataTable(vlVENCentroDistHist)

        Call Limpiar()
        Try
            vlDtVendedor = vcTbVendedor.Seleccionar("VendedorID='" + pvVendedorID + "'")
        Catch ex As LbControlError.cError
            Throw ex
        End Try

        If vlDtVendedor.Rows.Count > 0 Then
            For Each vlCampo As LbDatos.cCampo In vcTbVendedor.Campos
                vlCampo.Valor = vlDtVendedor.Rows(0)(vlCampo.Nombre)
            Next

            vcVEDArrayList.Clear()
            vcVEDDataTable.Clear()
            vcVEDDataTable = vlVendedorDescuentoDT.Recuperar("VendedorId='" + pvVendedorID + "'")
            For Each vlVEDDataRow As DataRow In vcVEDDataTable.Rows
                Dim vlVendedorDescuento1 As New cVendedorDescuento(Me)
                vlVendedorDescuento1.Recuperar(vlVEDDataRow("ModuloMovDetalleClave"))
                vcVEDArrayList.Add(vlVendedorDescuento1)
            Next

            vcVEEArrayList.Clear()
            vcVEEDataTable.Clear()
            vcVEEDataTable = vlVendedorEsquemaDT.Recuperar("VendedorId='" + pvVendedorID + "'")
            For Each vlVEEDataRow As DataRow In vcVEEDataTable.Rows
                Dim vlVendedorEsquema1 As New cVendedorEsquema(Me)
                vlVendedorEsquema1.Recuperar(vlVEEDataRow("EsquemaId"))
                vcVEEArrayList.Add(vlVendedorEsquema1)
            Next

            vcVEJDataTable = vlVendedorJornadaDT.Recuperar("VendedorId='" + pvVendedorID + "'")

            vcVCHArrayList.Clear()
            vcVCHDataTable.Clear()
            vcVCHDataTable = vlVENCentroDistHistDT.Recuperar("VendedorId='" + pvVendedorID + "' ORDER BY VCHFechaInicial")
            For Each vlVCHDataRow As DataRow In vcVCHDataTable.Rows
                Dim vlVENCentroDistHist1 As New cVENCentroDistHist(Me)
                vlVENCentroDistHist1.Recuperar(vlVCHDataRow("AlmacenId"), vlVCHDataRow("VCHFechaInicial"))
                vcVCHArrayList.Add(vlVENCentroDistHist1)
            Next

            vcEstado = eEstado.Recuperado
            Return True
        Else
            Return False
        End If

    End Function

    Public Function Grabar() As Boolean
        Try
            ValidarCampos()
        Catch ex As LbControlError.cError
            Throw ex
        End Try

        Try
            Select Case vcEstado
                Case eEstado.Nuevo
                    vcTbVendedor.Insertar()

                    For Each vlVendedorDescuento As cVendedorDescuento In vcVEDArrayList
                        vlVendedorDescuento.Grabar()
                    Next

                    For Each vlVendedorEsquema As cVendedorEsquema In vcVEEArrayList
                        vlVendedorEsquema.Grabar()
                    Next

                    For Each vlVENCentroDistHist As cVENCentroDistHist In vcVCHArrayList
                        vlVENCentroDistHist.Grabar()
                    Next

                    vcEstado = eEstado.Recuperado
                Case eEstado.Modificado
                    vcTbVendedor.Modificar()

                    For i As Integer = 0 To vcVEDArrayList.Count - 1
                        If vcVEDArrayList(i).Grabar() = eEstado.Eliminado Then
                            If i >= vcVEDArrayList.Count Then
                                Exit For
                            End If
                            i = i - 1
                        End If
                    Next

                    For i As Integer = 0 To vcVEEArrayList.Count - 1
                        If vcVEEArrayList(i).Grabar() = eEstado.Eliminado Then
                            If i >= vcVEEArrayList.Count Then
                                Exit For
                            End If
                            i = i - 1
                        End If
                    Next

                    For i As Integer = 0 To vcVCHArrayList.Count - 1
                        If i >= vcVCHArrayList.Count Then
                            Exit For
                        End If
                        If vcVCHArrayList(i).Grabar() = eEstado.Eliminado Then
                            i = i - 1
                        End If
                    Next

                    vcEstado = eEstado.Recuperado
                Case eEstado.Recuperado
                    For i As Integer = 0 To vcVEDArrayList.Count - 1
                        If vcVEDArrayList(i).Grabar() = eEstado.Eliminado Then
                            If i >= vcVEDArrayList.Count Then
                                Exit For
                            End If
                            i = i - 1
                        End If
                    Next

                    For i As Integer = 0 To vcVEEArrayList.Count - 1
                        If vcVEEArrayList(i).Grabar() = eEstado.Eliminado Then
                            If i >= vcVEEArrayList.Count Then
                                Exit For
                            End If
                            i = i - 1
                        End If
                    Next

                    For i As Integer = 0 To vcVCHArrayList.Count - 1
                        If vcVCHArrayList(i).Grabar() = eEstado.Eliminado Then
                            If i >= vcVCHArrayList.Count Then
                                Exit For
                            End If
                            i = i - 1
                        End If
                    Next
                Case eEstado.Eliminado
                    For i As Integer = 0 To vcVEDArrayList.Count - 1
                        If vcVEDArrayList(i).cEstado = eEstado.Modificado Or vcVEDArrayList(i).cEstado = eEstado.Recuperado Or vcVEDArrayList(i).cEstado = eEstado.Eliminado Then
                            vcVEDArrayList(i).Eliminar()
                            If vcVEDArrayList(i).Grabar() = eEstado.Eliminado Then
                                If i >= vcVEDArrayList.Count Then
                                    Exit For
                                End If
                                i = i - 1
                            End If
                        End If
                    Next

                    For i As Integer = 0 To vcVEEArrayList.Count - 1
                        If vcVEEArrayList(i).cEstado = eEstado.Modificado Or vcVEEArrayList(i).cEstado = eEstado.Recuperado Or vcVEEArrayList(i).cEstado = eEstado.Eliminado Then
                            vcVEEArrayList(i).Eliminar()
                            If vcVEEArrayList(i).Grabar() = eEstado.Eliminado Then
                                If i >= vcVEEArrayList.Count Then
                                    Exit For
                                End If
                                i = i - 1
                            End If
                        End If
                    Next

                    For i As Integer = 0 To vcVCHArrayList.Count - 1
                        If vcVCHArrayList(i).cEstado = eEstado.Modificado Or vcVCHArrayList(i).cEstado = eEstado.Recuperado Or vcVCHArrayList(i).cEstado = eEstado.Eliminado Then
                            vcVCHArrayList(i).Eliminar()
                            If vcVCHArrayList(i).Grabar() = eEstado.Eliminado Then
                                If i >= vcVCHArrayList.Count Then
                                    Exit For
                                End If
                                i = i - 1
                            End If
                        End If
                    Next

                    vcTbVendedor.Eliminar()
                    Call Limpiar()
            End Select
        Catch ex As LbControlError.cError
            Throw ex
        End Try
        Return True
    End Function

    Public Sub Eliminar()
        vcEstado = eEstado.Eliminado
    End Sub

    Public Sub ValidarCampos(Optional ByVal pvCampo() As String = Nothing)
        If IsNothing(pvCampo) Then
            Dim i As Integer
            With vcTbVendedor
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

    Private Function ValidaCampo(ByVal pvNombre As String) As Boolean
        With vcTbVendedor
            If .Campos(pvNombre).Requerido Then
                If IsDBNull(.Campos(pvNombre).Valor) Or .Campos(pvNombre).Valor Is Nothing Then
                    Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("VEN" + .Campos(pvNombre).Nombre, True)}, .Campos(pvNombre).Nombre)
                    Return False
                End If
                If .Campos(pvNombre).Tipo = LbDatos.ETipo.Cadena Then
                    If .Campos(pvNombre).Valor = "" Then
                        Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("VEN" + .Campos(pvNombre).Nombre, True)}, .Campos(pvNombre).Nombre)
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
            'If pvNombre.ToUpper = "TIPOMODIMP" AndAlso .Campos(pvNombre).Valor <= 0 Then
            '    Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("VEN" + .Campos(pvNombre).Nombre, True)}, .Campos(pvNombre).Nombre)
            '    Return False
            'End If
            If pvNombre.ToUpper = "LIMITEDESCUENTO" Then
                If .Campos(pvNombre).Valor > 100 Then
                    Throw New LbControlError.cError("E0333", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("VEN" + .Campos(pvNombre).Nombre, True), New LbControlError.cParametroMSG("100", False)}, .Campos(pvNombre).Nombre)
                End If
            End If
        End With
        Return True
    End Function

    Public Function TieneFoliosAsignados() As Boolean
        Dim bValidar As Boolean = vcConexion.EjecutarComandoScalar("select Top 1 convert(bit, case when (ComprobanteDig = 1 and FoliosTerminal = 0) then 1 else 0 end) as Validar from SEMHist Order by MFechaHora desc")
        If bValidar Then
            Dim sConsulta As String
            sConsulta = "select count(*) as Pendientes from FosHist FOH "
            sConsulta &= "inner join FolioSolicitado FOS on FOH.FolioId = FOS.FolioId and FOH.FOSId = FOS.FOSId "
            sConsulta &= "where VendedorId = '" & Me.VendedorID & "' and  FOS.Usados < FOS.CantSolicitada "
            Return (vcConexion.EjecutarComandoScalar(sConsulta) > 0)
        End If
        Return False
    End Function

    Public Function RecuperarGrid() As DataTable
        
        Dim sConsulta As String
        sConsulta = "select V.VendedorID,V.Nombre,V.Tipo, limitedescuento,V.TerminalClave,V.TipoEstado,V.Baja,V.MCNClave,U.Clave as Usuario, A.Clave as Cedi from vendedor V "
        sConsulta &= "inner join Usuario U on V.USUId=U.USUId "
        sConsulta &= "left join VENCentroDistHist VC on V.VendedorID =VC.VendedorId and GETDATE() between VC.VCHFechaInicial and VC.FechaFinal "
        sConsulta &= "left join Almacen A on VC.AlmacenId=A.AlmacenID "
        Return vcConexion.EjecutarConsulta(sConsulta)
       
    End Function


    Public Sub InsertarEn(ByRef prDataTable As DataTable)
        vcTbVendedor.Insertar(prDataTable)
    End Sub

    Public Sub ModificarEn(ByRef prDataTable As DataTable)
        vcTbVendedor.Modificar(prDataTable)
    End Sub

    Function VendedorDescuento() As cVEDTabla
        Return vcVEDTabla
    End Function

    Function VendedorDescuento(ByVal pvIndex As Integer) As cVendedorDescuento
        Dim vlVendedorDescuento As cVendedorDescuento
        While 1
            vlVendedorDescuento = vcVEDArrayList(pvIndex)
            If vlVendedorDescuento.cEstado <> eEstado.Eliminado Then
                Return vcVEDArrayList(pvIndex)
            Else
                pvIndex = pvIndex + 1
            End If
        End While
        Return Nothing
    End Function

    Function VendedorDescuento(ByVal pvModuloMovDetalleClave As String) As cVendedorDescuento
        For Each vlVendedorDescuento As cVendedorDescuento In vcVEDArrayList
            If vlVendedorDescuento.ModuloMovDetalleClave = pvModuloMovDetalleClave Then
                Return vlVendedorDescuento
            End If
        Next
        Return Nothing
    End Function

    Function VendedorEsquema() As cVEETabla
        Return vcVEETabla
    End Function

    Function VendedorEsquema(ByVal pvIndex As Integer) As cVendedorEsquema
        Dim vlVendedorEsquema As cVendedorEsquema
        While 1
            vlVendedorEsquema = vcVEEArrayList(pvIndex)
            If vlVendedorEsquema.cEstado <> eEstado.Eliminado Then
                Return vcVEEArrayList(pvIndex)
            Else
                pvIndex = pvIndex + 1
            End If
        End While
        Return Nothing
    End Function

    Function VendedorEsquema(ByVal pvEsquemaId As String) As cVendedorEsquema
        For Each vlVendedorEsquema As cVendedorEsquema In vcVEEArrayList
            If vlVendedorEsquema.EsquemaId = pvEsquemaId Then
                Return vlVendedorEsquema
            End If
        Next
        Return Nothing
    End Function

    Function VendedorJornada() As cVEJTabla
        Return vcVEJTabla
    End Function

    Function VENCentroDistHist() As cVCHTabla
        Return vcVCHTabla
    End Function

    Function VENCentroDistHist(ByVal pvIndex As Integer) As cVENCentroDistHist
        Dim vlVENCentroDistHist As cVENCentroDistHist
        While 1
            vlVENCentroDistHist = vcVCHArrayList(pvIndex)
            If vlVENCentroDistHist.cEstado <> eEstado.Eliminado Then
                Return vcVCHArrayList(pvIndex)
            Else
                pvIndex = pvIndex + 1
            End If
        End While
        Return Nothing
    End Function

    Function VENCentroDistHist(ByVal pvAlmacenId As String, ByVal pvVCHFechaInicial As Date) As cVENCentroDistHist
        For Each vlVENCentroDistHist As cVENCentroDistHist In vcVCHArrayList
            If vlVENCentroDistHist.AlmacenId = pvAlmacenId And vlVENCentroDistHist.VCHFechaInicial = pvVCHFechaInicial Then
                Return vlVENCentroDistHist
            End If
        Next
        Return Nothing
    End Function
#End Region

End Class

Public Class cVENTabla
    Private vcVendedor As cVendedor

    Public Sub New(ByRef prVendedor As cVendedor)
        vcVendedor = prVendedor
    End Sub

    Public Function Recuperar(ByVal pvFiltro As String, Optional ByVal pvCampos As String = "*") As DataTable
        Dim vlDataTable As New DataTable
        vlDataTable = vcVendedor.cTabla.Seleccionar(pvFiltro, pvCampos)
        Recuperar = vlDataTable
    End Function

    Public Sub Grabar(ByRef prDataTable As DataTable)
        vcVendedor.cTabla.GrabarTabla(prDataTable, vcVendedor.cTabla.Campos)
    End Sub
End Class
