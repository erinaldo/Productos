
Imports BASLOG

Imports System.IO
Imports System.Xml
Imports System.Collections.Generic
Imports System.Security.Cryptography.X509Certificates

Public Class cTransProd
    Inherits BASLOG.cClaseNodo
    'Implements ICloneable


#Region "Variables"
    Protected oColTPD As cCollectionTPD
    Protected oColAbono As Collections.Generic.List(Of cAbono)

    Private vgTipoXML As String = "Documento XML"
    Public vgTRPDatoFiscal As cTRPDatoFiscal

    'Private htPromociones As Hashtable
#End Region

#Region "Propiedades"

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

    Public Property VisitaClave() As String
        Get
            Return Me.Tabla.Campos("VisitaClave").Valor
        End Get
        Set(ByVal Value As String)
            Me.Tabla.Campos("VisitaClave").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property DiaClave() As String
        Get
            Return Me.Tabla.Campos("DiaClave").Valor
        End Get
        Set(ByVal Value As String)
            Me.Tabla.Campos("DiaClave").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property VisitaClave1() As String
        Get
            Return Me.Tabla.Campos("VisitaClave1").Valor
        End Get
        Set(ByVal Value As String)
            Me.Tabla.Campos("VisitaClave1").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property DiaClave1() As String
        Get
            Return Me.Tabla.Campos("DiaClave1").Valor
        End Get
        Set(ByVal Value As String)
            Me.Tabla.Campos("DiaClave1").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property PCEPrecioClave() As String
        Get
            Return Me.Tabla.Campos("PCEPrecioClave").Valor
        End Get
        Set(ByVal Value As String)
            Me.Tabla.Campos("PCEPrecioClave").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property PCEModuloMovDetClave() As String
        Get
            Return IIf(IsDBNull(Me.Tabla.Campos("PCEModuloMovDetClave").Valor), "", Me.Tabla.Campos("PCEModuloMovDetClave").Valor)
        End Get
        Set(ByVal Value As String)
            Me.Tabla.Campos("PCEModuloMovDetClave").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property PCEEsquemaID() As String
        Get
            Return Me.Tabla.Campos("PCEEsquemaID").Valor
        End Get
        Set(ByVal Value As String)
            Me.Tabla.Campos("PCEEsquemaID").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property SubEmpresaId() As String
        Get
            Return Me.Tabla.Campos("SubEmpresaId").Valor
        End Get
        Set(ByVal Value As String)
            Me.Tabla.Campos("SubEmpresaId").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property FacturaID() As String
        Get
            Return Me.Tabla.Campos("FacturaID").Valor
        End Get
        Set(ByVal Value As String)
            Me.Tabla.Campos("FacturaID").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property ClienteClave() As String
        Get
            Return IIf(IsDBNull(Me.Tabla.Campos("ClienteClave").Valor), "", Me.Tabla.Campos("ClienteClave").Valor)
        End Get
        Set(ByVal Value As String)
            Me.Tabla.Campos("ClienteClave").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property ClientePagoID() As String
        Get
            Return Me.Tabla.Campos("ClientePagoID").Valor
        End Get
        Set(ByVal Value As String)
            Me.Tabla.Campos("ClientePagoID").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property

    'Public Property ClienteClave1() As String
    '    Get
    '        Return Me.Tabla.Campos("ClienteClave1").Valor
    '    End Get
    '    Set(ByVal Value As String)
    '        Me.Tabla.Campos("ClienteClave1").Valor = Value
    '        If Me.Status = eEstado.Recuperado Then
    '            Me.tEstado = eEstado.Modificado
    '        End If
    '    End Set
    'End Property

    Public Property CFVTipo() As Integer
        Get
            Return Me.Tabla.Campos("CFVTipo").Valor
        End Get
        Set(ByVal Value As Integer)
            Me.Tabla.Campos("CFVTipo").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property Folio() As String
        Get
            Return Me.Tabla.Campos("Folio").Valor
        End Get
        Set(ByVal Value As String)
            Me.Tabla.Campos("Folio").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property Tipo() As Integer
        Get
            Return Me.Tabla.Campos("Tipo").Valor
        End Get
        Set(ByVal Value As Integer)
            Me.Tabla.Campos("Tipo").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property TipoPedido() As Integer
        Get
            Return Me.Tabla.Campos("TipoPedido").Valor
        End Get
        Set(ByVal Value As Integer)
            Me.Tabla.Campos("TipoPedido").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set

    End Property

    Public Property TipoFase() As Integer
        Get
            Return Me.Tabla.Campos("TipoFase").Valor
        End Get
        Set(ByVal Value As Integer)
            Me.Tabla.Campos("TipoFase").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property TipoMovimiento() As Integer
        Get
            Return Me.Tabla.Campos("TipoMovimiento").Valor
        End Get
        Set(ByVal Value As Integer)
            Me.Tabla.Campos("TipoMovimiento").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property FechaHoraAlta() As Date
        Get
            Return Me.Tabla.Campos("FechaHoraAlta").Valor
        End Get
        Set(ByVal Value As Date)
            Me.Tabla.Campos("FechaHoraAlta").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property FechaCaptura() As Date
        Get
            Return Me.Tabla.Campos("FechaCaptura").Valor
        End Get
        Set(ByVal Value As Date)
            Me.Tabla.Campos("FechaCaptura").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property FechaEntrega() As Date
        Get
            Return Me.Tabla.Campos("FechaEntrega").Valor
        End Get
        Set(ByVal Value As Date)
            Me.Tabla.Campos("FechaEntrega").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property FechaFacturacion() As Date
        Get
            Return Me.Tabla.Campos("FechaFacturacion").Valor
        End Get
        Set(ByVal Value As Date)
            Me.Tabla.Campos("FechaFacturacion").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property FechaSurtido() As Date
        Get
            Return Me.Tabla.Campos("FechaSurtido").Valor
        End Get
        Set(ByVal Value As Date)
            Me.Tabla.Campos("FechaSurtido").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property FechaCancelacion() As Date
        Get
            Return Me.Tabla.Campos("FechaCancelacion").Valor
        End Get
        Set(ByVal Value As Date)
            Me.Tabla.Campos("FechaCancelacion").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property TipoMotivo() As Integer
        Get
            Return IIf(IsDBNull(Me.Tabla.Campos("TipoMotivo").Valor), 0, Me.Tabla.Campos("TipoMotivo").Valor)
        End Get
        Set(ByVal Value As Integer)
            Me.Tabla.Campos("TipoMotivo").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property SubTDetalle() As Double
        Get
            If Me.Tabla.Campos("SubTDetalle").Valor.ToString = "" Then Return 0
            Return Decimal.Round(Me.Tabla.Campos("SubTDetalle").Valor, 2)
        End Get
        Set(ByVal Value As Double)
            Me.Tabla.Campos("SubTDetalle").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property DescVendPor() As Double
        Get
            If Me.Tabla.Campos("DescVendPor").Valor.ToString = "" Then Return 0
            Return Me.Tabla.Campos("DescVendPor").Valor
        End Get
        Set(ByVal Value As Double)
            Me.Tabla.Campos("DescVendPor").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property DescuentoVendedor() As Double
        Get
            If Me.Tabla.Campos("DescuentoVendedor").Valor.ToString = "" Then Return 0
            Return Decimal.Round(Me.Tabla.Campos("DescuentoVendedor").Valor, 2)
        End Get
        Set(ByVal Value As Double)
            Me.Tabla.Campos("DescuentoVendedor").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property DescuentoImp() As Double
        Get
            If Me.Tabla.Campos("DescuentoImp").Valor.ToString = "" Then Return 0
            Return Decimal.Round(Me.Tabla.Campos("DescuentoImp").Valor, 2)
        End Get
        Set(ByVal Value As Double)
            Me.Tabla.Campos("DescuentoImp").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property SubTotal() As Double
        Get
            Return Decimal.Round(Me.Tabla.Campos("SubTotal").Valor, 2)
        End Get
        Set(ByVal Value As Double)
            Me.Tabla.Campos("SubTotal").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property Impuesto() As Double
        Get
            If Me.Tabla.Campos("Impuesto").Valor.ToString = "" Then Return 0
            Return Decimal.Round(Me.Tabla.Campos("Impuesto").Valor, 2)
        End Get
        Set(ByVal Value As Double)
            Me.Tabla.Campos("Impuesto").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property Total() As Double
        Get
            Return Decimal.Round(Me.Tabla.Campos("Total").Valor, 2)
        End Get
        Set(ByVal Value As Double)
            Me.Tabla.Campos("Total").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public ReadOnly Property TotalFacturaElectronica() As Double
        Get
            Return Me.Tabla.Campos("Total").Valor
        End Get
    End Property

    Public Property Saldo() As Double
        Get
            Return Decimal.Round(Me.Tabla.Campos("Saldo").Valor, 2)
        End Get
        Set(ByVal Value As Double)
            Me.Tabla.Campos("Saldo").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property Promocion() As Boolean
        Get
            Return Me.Tabla.Campos("Promocion").Valor
        End Get
        Set(ByVal Value As Boolean)
            Me.Tabla.Campos("Promocion").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property Descuento() As Boolean
        Get
            Return Me.Tabla.Campos("Descuento").Valor
        End Get
        Set(ByVal Value As Boolean)
            Me.Tabla.Campos("Descuento").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property MonedaID() As String
        Get
            Return IIf(IsDBNull(Me.Tabla.Campos("MonedaID").Valor), "", Me.Tabla.Campos("MonedaID").Valor)
        End Get
        Set(ByVal Value As String)
            Me.Tabla.Campos("MonedaID").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property TipoCambio() As Decimal
        Get
            Return Me.Tabla.Campos("TipoCambio").Valor
        End Get
        Set(ByVal Value As Decimal)
            Me.Tabla.Campos("TipoCambio").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property TipoTurno() As Integer
        Get
            Return Me.Tabla.Campos("TipoTurno").Valor
        End Get
        Set(ByVal Value As Integer)
            Me.Tabla.Campos("TipoTurno").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property FechaCobranza() As Date
        Get
            Return Me.Tabla.Campos("FechaCobranza").Valor
        End Get
        Set(ByVal Value As Date)
            Me.Tabla.Campos("FechaCobranza").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property DiasCredito() As Integer
        Get
            Return Me.Tabla.Campos("DiasCredito").Valor
        End Get
        Set(ByVal Value As Integer)
            Me.Tabla.Campos("DiasCredito").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property Notas() As String
        Get
            'Return Me.Tabla.Campos("Notas").Valor
            Return IIf(IsDBNull(Me.Tabla.Campos("Notas").Valor), "", Me.Tabla.Campos("Notas").Valor)
        End Get
        Set(ByVal Value As String)
            Me.Tabla.Campos("Notas").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public ReadOnly Property TransProdDetalle(ByVal pvTransProdDetalleID As String) As cTransProdDetalle
        Get
            Dim oArr As ArrayList
            Dim oTPD As cTransProdDetalle

            oArr = Me.RegresaArregloHijo("TransProdDetalle")

            For Each oTPD In oArr
                If oTPD.TransProdDetalleID = pvTransProdDetalleID And oTPD.Status <> eEstado.Eliminado Then
                    Return oTPD
                End If
            Next
            Return Nothing
        End Get
    End Property

    Public ReadOnly Property TransProdDetalle() As cCollectionTPD
        Get
            Return oColTPD
        End Get
    End Property

    Public ReadOnly Property Abono() As Generic.List(Of cAbono)
        Get
            Return oColAbono
        End Get
    End Property


#End Region

#Region "Constructores"

    Public Sub New()
        MyBase.New()
        Reiniciar()
    End Sub

    Public Sub New(ByRef prConexion As LbConexion.cConexion)
        MyBase.New(prConexion)
        Reiniciar()
    End Sub

#End Region

#Region "Sobreescritos"
    Protected Overrides Sub CrearEstructuraTabla()
        With Me.Tabla
            .AgregarCampo(New LbDatos.cCampo("TransProdID", LbDatos.ETipo.Cadena, "", True, True))
            .AgregarCampo(New LbDatos.cCampo("VisitaClave", LbDatos.ETipo.Cadena, "", False, False, True, True))
            .AgregarCampo(New LbDatos.cCampo("DiaClave", LbDatos.ETipo.Cadena, "", False, False, True, True))
            .AgregarCampo(New LbDatos.cCampo("VisitaClave1", LbDatos.ETipo.Cadena, "", False, False, True, True))
            .AgregarCampo(New LbDatos.cCampo("DiaClave1", LbDatos.ETipo.Cadena, "", False, False, True, True))
            .AgregarCampo(New LbDatos.cCampo("PCEPrecioClave", LbDatos.ETipo.Cadena, "", False, False, True, True))
            .AgregarCampo(New LbDatos.cCampo("PCEModuloMovDetClave", LbDatos.ETipo.Cadena, "", False, False, True, True))
            .AgregarCampo(New LbDatos.cCampo("PCEEsquemaID", LbDatos.ETipo.Cadena, "", False, False, True, True))
            .AgregarCampo(New LbDatos.cCampo("SubEmpresaId", LbDatos.ETipo.Cadena, "", False, False, True, True))
            .AgregarCampo(New LbDatos.cCampo("FacturaID", LbDatos.ETipo.Cadena, "", False, False, True, True))
            .AgregarCampo(New LbDatos.cCampo("ClienteClave", LbDatos.ETipo.Cadena, "", False, False, True, True))
            .AgregarCampo(New LbDatos.cCampo("ClientePagoID", LbDatos.ETipo.Cadena, False))
            '.AgregarCampo(New LbDatos.cCampo("ClienteClave1", LbDatos.ETipo.Cadena, "", False, False, True, True))
            .AgregarCampo(New LbDatos.cCampo("CFVTipo", LbDatos.ETipo.Numerico, "", False, False, True, True))
            .AgregarCampo(New LbDatos.cCampo("Folio", LbDatos.ETipo.Cadena, True))
            .AgregarCampo(New LbDatos.cCampo("Tipo", LbDatos.ETipo.Numerico, True))
            .AgregarCampo(New LbDatos.cCampo("TipoPedido", LbDatos.ETipo.Numerico, False))
            .AgregarCampo(New LbDatos.cCampo("TipoFase", LbDatos.ETipo.Numerico, True))
            .AgregarCampo(New LbDatos.cCampo("TipoMovimiento", LbDatos.ETipo.Numerico, False))
            .AgregarCampo(New LbDatos.cCampo("FechaHoraAlta", LbDatos.ETipo.FechaHora, True))
            .AgregarCampo(New LbDatos.cCampo("FechaCaptura", LbDatos.ETipo.Fecha, True))
            .AgregarCampo(New LbDatos.cCampo("FechaEntrega", LbDatos.ETipo.Fecha, False))
            .AgregarCampo(New LbDatos.cCampo("FechaFacturacion", LbDatos.ETipo.Fecha, False))
            .AgregarCampo(New LbDatos.cCampo("FechaSurtido", LbDatos.ETipo.Fecha, False))
            .AgregarCampo(New LbDatos.cCampo("FechaCancelacion", LbDatos.ETipo.FechaHora, False))
            .AgregarCampo(New LbDatos.cCampo("TipoMotivo", LbDatos.ETipo.Numerico, False))
            .AgregarCampo(New LbDatos.cCampo("SubTDetalle", LbDatos.ETipo.Numerico, False))
            .AgregarCampo(New LbDatos.cCampo("DescVendPor", LbDatos.ETipo.Numerico, False))
            .AgregarCampo(New LbDatos.cCampo("DescuentoVendedor", LbDatos.ETipo.Numerico, False))
            .AgregarCampo(New LbDatos.cCampo("DescuentoImp", LbDatos.ETipo.Numerico, False))
            .AgregarCampo(New LbDatos.cCampo("SubTotal", LbDatos.ETipo.Numerico, False))
            .AgregarCampo(New LbDatos.cCampo("Impuesto", LbDatos.ETipo.Numerico, False))
            .AgregarCampo(New LbDatos.cCampo("Total", LbDatos.ETipo.Numerico, True))
            .AgregarCampo(New LbDatos.cCampo("Saldo", LbDatos.ETipo.Numerico, False))
            .AgregarCampo(New LbDatos.cCampo("Promocion", LbDatos.ETipo.Bit, False))
            .AgregarCampo(New LbDatos.cCampo("Descuento", LbDatos.ETipo.Bit, False))
            .AgregarCampo(New LbDatos.cCampo("MonedaID", LbDatos.ETipo.Cadena, False))
            .AgregarCampo(New LbDatos.cCampo("TipoCambio", LbDatos.ETipo.Numerico, False))
            .AgregarCampo(New LbDatos.cCampo("TipoTurno", LbDatos.ETipo.Numerico, False))
            .AgregarCampo(New LbDatos.cCampo("FechaCobranza", LbDatos.ETipo.Fecha, False))
            .AgregarCampo(New LbDatos.cCampo("DiasCredito", LbDatos.ETipo.Numerico, False))
            .AgregarCampo(New LbDatos.cCampo("Notas", LbDatos.ETipo.Cadena, False))
        End With
    End Sub

    Protected Overrides Sub CrearHijos()
        Dim vlHijoTPD As cClaseNodo

        vlHijoTPD = New cTransProdDetalle(Me)
        Me.AgregarHijo(vlHijoTPD.Tabla)
        oColTPD = New cCollectionTPD(Me.RegresaArregloHijo(vlHijoTPD.Tabla.NombreTabla), Me.RegresaDataTableHijo(vlHijoTPD.Tabla.NombreTabla), vlHijoTPD.TablaNodo)

        oColAbono = New Generic.List(Of cAbono)

    End Sub

    Protected Overrides Function RegresaEnsamblado() As System.Reflection.Assembly
        Return System.Reflection.Assembly.GetExecutingAssembly()
    End Function

    Protected Overrides Function RegresaMnemonico() As String
        Return "TRP"
    End Function

    Protected Overrides Function RegresaNombreTabla() As String
        Return "TransProd"
    End Function
#End Region

#Region "Sobrecargados Especificos"

    Public Overloads Sub Recuperar(ByVal pvTransProdID As String)
        Me.Limpiar()
        Me.TransProdID = pvTransProdID
        Me.Recuperar()
    End Sub

    Public Overloads Function Existe(ByVal pvTransProdID As String) As Boolean
        Return (Me.Tabla.Seleccionar("TransProdID='" & pvTransProdID & "'").Rows.Count > 0)
    End Function

    Public Overloads Function ExisteFolio(ByVal pvFolio As String) As Boolean
        Return (Me.Tabla.Seleccionar("Folio = '" & lbGeneral.ValidaFormatoSQLString(pvFolio) & "' and Tipo = " & Me.Tipo).Rows.Count > 0)
    End Function

    Public Overloads Sub Insertar(ByVal pvTransProdID As String, ByVal pvVisitaClave As String, ByVal pvDiaClave As String, ByVal pvVisitaClave1 As String, ByVal pvDiaClave1 As String, ByVal pvPCEPrecioClave As String, ByVal pvPCEModuloMovDetClave As String, ByVal pvPCEEsquemaID As String, ByVal pvSubEmpresaId As String, ByVal pvFacturaID As String, ByVal pvClienteClave As String, ByVal pvClientePagoID As String, ByVal pvCFVTipo As Integer, ByVal pvFolio As String, ByVal pvTipo As Integer, ByVal pvTipoPedido As Integer, ByVal pvTipoFase As Integer, ByVal pvTipoMovimiento As Integer, ByVal pvFechaHoraAlta As Date, ByVal pvFechaCaptura As Date, ByVal pvFechaEntrega As Date, ByVal pvFechaFacturacion As Date, ByVal pvFechaSurtido As Date, ByVal pvFechaCancelacion As Date, ByVal pvTipoMotivo As Integer, ByVal pvSubTDetalle As Double, ByVal pvDescVendPor As Double, ByVal pvDescuentoVendedor As Double, ByVal pvDescuentoImp As Double, ByVal pvSubTotal As Double, ByVal pvImpuesto As Double, ByVal pvTotal As Double, ByVal pvSaldo As Double, ByVal pvPromocion As Boolean, ByVal pvDescuento As Boolean, ByVal pvMonedaId As String, ByVal pvTipoCambio As Decimal, ByVal pvTipoTurno As Integer, ByVal pvFechaCobranza As Date, ByVal pvDiasCredito As Integer, ByVal pvNotas As String, Optional ByVal pvCampo() As String = Nothing)
        Me.Limpiar()
        Me.TransProdID = pvTransProdID
        Me.VisitaClave = pvVisitaClave
        Me.DiaClave = pvDiaClave
        Me.VisitaClave1 = pvVisitaClave1
        Me.DiaClave1 = pvDiaClave1
        Me.PCEPrecioClave = pvPCEPrecioClave
        Me.PCEModuloMovDetClave = pvPCEModuloMovDetClave
        Me.PCEEsquemaID = pvPCEEsquemaID
        Me.SubEmpresaId = pvSubEmpresaId
        Me.FacturaID = pvFacturaID
        Me.ClienteClave = pvClienteClave
        Me.ClientePagoID = pvClientePagoID
        'Me.ClienteClave1 = pvClienteClave1
        Me.CFVTipo = pvCFVTipo
        Me.Folio = pvFolio
        Me.Tipo = pvTipo
        Me.TipoPedido = pvTipoPedido
        Me.TipoFase = pvTipoFase
        Me.TipoMovimiento = pvTipoMovimiento
        Me.FechaHoraAlta = pvFechaHoraAlta
        Me.FechaCaptura = pvFechaCaptura
        Me.FechaEntrega = pvFechaEntrega
        Me.FechaFacturacion = pvFechaFacturacion
        Me.FechaSurtido = pvFechaSurtido
        Me.FechaCancelacion = pvFechaCancelacion
        Me.TipoMotivo = pvTipoMotivo
        Me.SubTDetalle = pvSubTDetalle
        Me.DescVendPor = pvDescVendPor
        Me.DescuentoVendedor = pvDescuentoVendedor
        Me.DescuentoImp = pvDescuentoImp
        Me.SubTotal = pvSubTotal
        Me.Impuesto = pvImpuesto
        Me.Total = pvTotal
        Me.Saldo = pvSaldo
        Me.Promocion = pvPromocion
        Me.Descuento = pvDescuento
        Me.MonedaID = pvMonedaId
        Me.TipoCambio = pvTipoCambio
        Me.TipoTurno = pvTipoTurno
        Me.FechaCobranza = pvFechaCobranza
        Me.DiasCredito = pvDiasCredito
        Me.Notas = pvNotas
        Me.Insertar(pvCampo)
    End Sub

#End Region

#Region "Funciones"

    Public Function Reiniciar() As Boolean '16/10/2010
        Me.TransProdID = ""
        Me.FechaCaptura = PrimeraHora(Now)
        Me.FechaEntrega = New Date(1900, 1, 1)
        Me.FechaFacturacion = New Date(1900, 1, 1)
        Me.FechaSurtido = New Date(1900, 1, 1)
        Me.FechaCancelacion = New Date(1900, 1, 1)
        Me.FechaCobranza = PrimeraHora(Now)
        Me.ClienteClave = ""
        Me.ClientePagoID = ""
        Me.CFVTipo = 0
        Me.TipoTurno = 0
        Me.DiasCredito = 0
        Me.FacturaID = ""
        Me.TipoPedido = 0
        Me.SubTDetalle = 0
        Me.DescVendPor = 0
        Me.DescuentoVendedor = 0
        Me.DescuentoImp = 0
        Me.Total = 0
        Me.Saldo = 0
        Me.SubTotal = 0
        Me.Impuesto = 0
        Me.Promocion = 0
        Me.Descuento = 0
        Me.Notas = ""
    End Function

    Public Function TransProdDetalle2(ByVal pvTransProdDetalleId As String) As cTransProdDetalle
        Dim oArr As ArrayList
        Dim oTPD As cTransProdDetalle

        oArr = Me.RegresaArregloHijo("TransProdDetalle")

        For Each oTPD In oArr
            If oTPD.TransProdDetalleID = pvTransProdDetalleId And oTPD.Status <> eEstado.Eliminado Then
                Return oTPD
            End If
        Next

        Return Nothing
    End Function
    Public Function RecuperarCargaLigada() As String
        Dim sConsulta As String
        Dim sFolioCarga As String
        sConsulta = "select Folio from TransProd where TransProdId = '" & lbGeneral.ValidaFormatoSQLString(Me.FacturaID) & "'"
        sFolioCarga = Me.Tabla.Conexion.EjecutarComandoScalar(sConsulta)
        Return sFolioCarga
    End Function

    Public Sub CancelarCargaAutomatica()
        Dim sComando As String
        sComando = "update TransProd set FacturaId = null, TipoFase = (case when Tipo = 22 then 5 else TipoFase end), MFechaHora = getdate() "
        sComando &= "where FacturaId = '" & Me.TransProdID & "'"
        Me.Tabla.Conexion.EjecutarComando(sComando)
    End Sub

    Public Function ObtenerProdCargaAutomatica(ByVal pvUsuarioId As String, ByVal pvCEDI As String) As DataTable
        Dim sConsulta As String
        sConsulta = "select TPD.ProductoClave, PRO.Nombre, TPD.TipoUnidad, sum(TPD.Cantidad) as Cantidad "
        sConsulta &= "from TransProd TRP "
        sConsulta &= "inner join TransProdDetalle TPD on TRP.TransProdId = TPD.TransProdId "
        sConsulta &= "inner join Producto PRO on TPD.ProductoClave = PRO.ProductoClave "
        sConsulta &= "where (TRP.Tipo = 7 or TRP.Tipo = 22) "
        sConsulta &= "and TRP.MUsuarioId = '" & pvUsuarioId & "' "
        sConsulta &= "and TRP.Notas like (case when TRP.Tipo = 22 then '" & lbGeneral.ValidaFormatoSQLString(pvCEDI) & "' else '%' end) "
        sConsulta &= "and TRP.FacturaId is null "
        sConsulta &= "and TRP.TipoFase = (case TRP.Tipo when 22 then 5 when 7 then 1 end) "
        sConsulta &= "and TPD.Cantidad > 0 "
        sConsulta &= "and PRO.Tipo <> 5 "
        sConsulta &= "and (select top 1 ClaveCEDI from AgendaVendedor AGV where AGV.DiaClave = TRP.DiaClave "
        sConsulta &= "and AGV.VendedorId = (select VEN.VendedorId from Vendedor VEN where VEN.USUId = TRP.MUsuarioId and VEN.TipoEstado = 1 and VEN.Baja = 0)) like "
        sConsulta &= "case when TRP.Tipo = 7 then '" & lbGeneral.ValidaFormatoSQLString(pvCEDI) & "' else '%' end "
        sConsulta &= "group by TPD.ProductoClave, PRO.Nombre, TPD.TipoUnidad "
        Return Me.Tabla.Conexion.EjecutarConsulta(sConsulta)
    End Function

    Public Sub GrabarCargaAutomatica()
        Dim sComando As String = ""
        sComando &= "update TransProd "
        sComando &= "set FacturaId = '" & Me.TransProdID & "', "
        sComando &= "TipoFase = (case when Tipo = 22 then 1 else TipoFase end), "
        sComando &= "MFechaHora = getdate() "
        sComando &= "where TransProdId in ( "
        sComando &= "select distinct TRP.TransProdId "
        sComando &= "from TransProd TRP "
        sComando &= "inner join TransProdDetalle TPD on TRP.TransProdId = TPD.TransProdId "
        sComando &= "inner join Producto PRO on TPD.ProductoClave = PRO.ProductoClave "
        sComando &= "where (TRP.Tipo = 7 or TRP.Tipo = 22) "
        sComando &= "and TRP.MUsuarioId = '" & Me.MUsuarioID & "' "
        sComando &= "and TRP.Notas like (case when TRP.Tipo = 22 then '" & lbGeneral.ValidaFormatoSQLString(Me.Notas) & "' else '%' end) "
        sComando &= "and TRP.FacturaId is null "
        sComando &= "and TRP.TipoFase = (case TRP.Tipo when 22 then 5 when 7 then 1 end) "
        sComando &= "and TPD.Cantidad > 0 "
        sComando &= "and PRO.Tipo <> 5 "
        sComando &= "and (select top 1 ClaveCEDI from AgendaVendedor AGV where AGV.DiaClave = TRP.DiaClave "
        sComando &= "and AGV.VendedorId = (select VEN.VendedorId from Vendedor VEN where VEN.USUId = TRP.MUsuarioId and VEN.TipoEstado = 1 and VEN.Baja = 0)) like "
        sComando &= "case when TRP.Tipo = 7 then '" & lbGeneral.ValidaFormatoSQLString(Me.Notas) & "' else '%' end ) "
        Me.Tabla.Conexion.EjecutarComando(sComando)
    End Sub

    Public Function ObtenerPedidoFacturar(ByVal sFecha As String, ByVal sFiltro As String) As DataTable

        Dim sConsulta As String

        sConsulta = String.Format("set nocount on " _
            & "select * into #TmpPedido from (" _
            & "select TransProdID, Folio, FechaEntrega, Total, TipoFase, VisitaClave, DiaClave, FacturaId, CFVTipo, SubEmpresaID, MonedaID, Saldo " _
            & "from TransProd  " _
            & "where TipoFase = 2 and FacturaID is null and Tipo = 1 " _
            & "{0}) as T  " _
            & "select distinct TRP.TransProdID, TRP.Folio, TRP.FechaEntrega AS Fecha,TRP.Total, CLI.RazonSocial, CLI.NombreCorto, TRP.TipoFase " _
            & "from #TmpPedido TRP " _
            & "INNER JOIN Visita VIS ON TRP.VisitaClave = VIS.VisitaClave AND TRP.DiaClave = VIS.DiaClave  " _
            & "INNER JOIN Cliente CLI ON VIS.ClienteClave = CLI.ClienteClave  " _
            & "INNER JOIN ClienteEsquema CLE ON CLI.ClienteClave = CLE.ClienteClave and CLE.TipoEstado = 1  " _
            & "{1} " _
            & "drop table #TmpPedido " _
            & "set nocount off", sFecha, sFiltro)


        Return Me.Tabla.Conexion.EjecutarConsulta(sConsulta)

    End Function

    Public Function ObtenerFacturasDispNotaCredito(ByVal sFiltro As String) As DataTable
        Dim sConsulta As String

        sConsulta = String.Format("set nocount on " _
        & "select * into #tmpFactura from( " _
        & "select TRP.TransProdID, TRP.VisitaClave, TRP.DiaClave, TRP.Folio, TRP.FechaFacturacion, TRP.FechaHoraAlta, TRP.Subtotal, TRP.Total " _
        & "from TransProd TRP " _
        & "inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave and TRP.DiaClave = VIS.DiaClave " _
        & "inner join TRPDatoFiscal TDF on TRP.TransProdID = TDF.TransProdID " _
        & "where TRP.Tipo = 8 and TRP.TipoFase <> 0 {0} " _
        & ") as T " _
        & "select FAC.TransProdId, VIS.ClienteClave, FAC.Folio, CLI.Clave as CLIClave, CLI.RazonSocial, FAC.FechaFacturacion, FAC.FechaHoraAlta, FAC.Subtotal as SubtotalFAC, FAC.Total as TotalFAC, " _
        & "isnull(NCR.TotalDES, 0) as TotalDES, isnull(NCR.TotalDEV, 0) as TotalDEV " _
        & "from #tmpFactura as FAC " _
        & "inner join Visita VIS on FAC.VisitaClave = VIS.VisitaClave and FAC.DiaClave = VIS.DiaClave " _
        & "inner join Cliente CLI on VIS.ClienteClave = CLI.ClienteClave " _
        & "left join ( " _
        & "select FacturaId, " _
        & "sum(case when TDF.TipoNotaCredito = 1 then Total else 0 end) as TotalDES, " _
        & "sum(case when TDF.TipoNotaCredito = 2 then Total else 0 end) as TotalDEV " _
        & "from TransProd TRP " _
        & "inner join TRPDatoFiscal TDF on TRP.TransProdID = TDF.TransProdID " _
        & "where TRP.Tipo = 10 and  TRP.TipoFase <> 0 " _
        & "group by FacturaId " _
        & ")as NCR on FAC.TransProdId = NCR.FacturaID " _
        & "where FAC.Total - isnull(NCR.TotalDEV, 0) - isnull(NCR.TotalDES,0) > 0 " _
        & "drop table #tmpFactura " _
        & "set nocount off ", sFiltro)

        Return Me.Tabla.Conexion.EjecutarConsulta(sConsulta)
    End Function

    Public Function ObtenerSubtotalDevoluciones(ByVal sFacturaId As String, ByVal sClienteClave As String, ByVal dFechaFactura As Date) As Double
        Dim sConsulta As New Text.StringBuilder
        Dim bDesglosaImp As Boolean

        sConsulta.AppendLine("select isnull(sum(case when TDI.ImpuestoPU is null or TDI.ImpDesGlb is null then 1 else 0 end), 0) as Nulos ")
        sConsulta.AppendLine("from TransProd TRP ")
        sConsulta.AppendLine("inner join TPDImpuesto TDI on TRP.TransProdID = TDI.TransProdID ")
        sConsulta.AppendLine("where TRP.FacturaId = '" & sFacturaId & "' and TRP.Tipo = 10 and TRP.TipoFase <> 0 ")

        bDesglosaImp = (LbConexion.cConexion.Instancia.EjecutarComandoScalar(sConsulta.ToString) = 0)

        If bDesglosaImp Then
            sConsulta.AppendLine("set nocount on ")
            sConsulta.AppendLine("if (select object_id('tempdb..#TmpImp')) is not null drop table #TmpImp ")
            sConsulta.AppendLine("select * into #TmpImp from ( ")
            sConsulta.AppendLine("select TDI.TransProdID, TDI.TransProdDetalleID, sum(TDI.ImpuestoPU) as ImpuestoPU, SUM(TDI.ImpDesGlb) as ImpDesGlb ")
            sConsulta.AppendLine("from TPDImpuesto TDI ")
            sConsulta.AppendLine("inner join TransProd TRP on TDI.TransProdID = TRP.TransProdID ")
            sConsulta.AppendLine("inner join TRPDatoFiscal TDF on TRP.TransProdID = TDF.TransProdID ")
            sConsulta.AppendLine("where TRP.FacturaId = '" & sFacturaId & "' and TRP.Tipo = 10 and TipoFase <> 0 and TDF.TipoNotaCredito = 2 and TDI.ImpuestoClave in ( ")
            sConsulta.AppendLine("select ImpuestoClave ")
            sConsulta.AppendLine("from CLINoDesImp ")
            sConsulta.AppendLine("where ClienteClave = '" & sClienteClave & "' and '" & dFechaFactura.ToString("s") & "' between FechaInicio and FechaFin) ")
            sConsulta.AppendLine("group by TDI.TransProdID, TDI.TransProdDetalleID ")
            sConsulta.AppendLine(") as t ")

            sConsulta.AppendLine("select isnull(sum(t.Subtotal - t.Descuento), 0) as Subtotal from ( ")
            sConsulta.AppendLine("select TRP.TransProdId, sum((TPD.Precio + isnull(IMP.ImpuestoPU, 0)) * TPD.Cantidad) as Subtotal, ")
            sConsulta.AppendLine("(isnull((select sum(DesImporte) from TpdDes DES where DES.TransProdId = TPD.TransProdId), 0) ")
            sConsulta.AppendLine("+ isnull((select sum(DESV.DesImporte) from TpdDesVendedor DESV where DESV.TransProdId = TPD.TransProdId), 0) ")
            sConsulta.AppendLine("+ sum(TPD.DescuentoImp)) + sum(isnull((TPD.Cantidad * IMP.ImpuestoPU) - IMP.ImpDesGlb, 0)) as Descuento ")
            sConsulta.AppendLine("from TransProd TRP ")
            sConsulta.AppendLine("inner join TRPDatoFiscal TDF on TRP.TransProdID = TDF.TransProdID ")
            sConsulta.AppendLine("inner join TransProdDetalle TPD on TRP.TransProdId = TPD.TransProdId ")
            sConsulta.AppendLine("left join #TmpImp IMP on TPD.TransProdID = IMP.TransProdId and TPD.TransProdDetalleID = IMP.TransProdDetalleId ")
            sConsulta.AppendLine("where TRP.FacturaID = '" & sFacturaId & "' and TRP.Tipo = 10 and TRP.TipoFase <> 0 and TDF.TipoNotaCredito = 2 ")
            sConsulta.AppendLine("group by TRP.TransProdId, TPD.TransProdID, TRP.DescuentoImp, TRP.DescuentoVendedor, TRP.Total ")
            sConsulta.AppendLine(") as t ")

            sConsulta.AppendLine("drop table #TmpImp ")
            sConsulta.AppendLine("set nocount off ")
        Else
            sConsulta.AppendLine("Select isnull(sum(SubTotal), 0) as Subtotal ")
            sConsulta.AppendLine("from TransProd TRP ")
            sConsulta.AppendLine("inner join TRPDatoFiscal TDF on TRP.TransProdID = TDF.TransProdID ")
            sConsulta.AppendLine("where FacturaId = '" & sFacturaId & "' and Tipo = 10 and TipoFase <> 0 and TipoNotaCredito = 2 ")
        End If

        Return Me.Tabla.Conexion.EjecutarComandoScalar(sConsulta.ToString)

    End Function

    Public Function ObtenerFacturaNotaCredito(ByVal sFacturaId As String) As DataTable
        Dim sConsulta As String
        sConsulta = String.Format("set nocount on " _
        & "select * into #tmpFactura from( " _
        & "select TRP.TransProdID, VIS.ClienteClave, TRP.Folio, TRP.Total " _
        & "from TransProd TRP " _
        & "inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave and TRP.DiaClave = VIS.DiaClave " _
        & "inner join TRPDatoFiscal TDF on TRP.TransProdID = TDF.TransProdID " _
        & "where TRP.Tipo = 8 and TRP.TransProdID = '{0}' " _
        & ") as T " _
        & "select TOP 1 FAC.Folio, FAC.ClienteClave, FAC.Total - isnull(NCR.TotalDEV, 0) as TotalFAC, FAC.Total - (CASE NCR.TipoFase WHEN 0 THEN 0 ELSE isnull(NCR.TotalDEV, 0) + isnull(NCR.TotalDES, 0)END) as Disponible  " _
        & "from #tmpFactura as FAC " _
        & "left join ( " _
        & "select FacturaId, " _
        & "sum(case when TDF.TipoNotaCredito = 1 then Total else 0 end) as TotalDES, " _
        & "sum(case when TDF.TipoNotaCredito = 2 then Total else 0 end) as TotalDEV, TRP.TipoFase " _
        & "from TransProd TRP " _
        & "inner join TRPDatoFiscal TDF on TRP.TransProdID = TDF.TransProdID " _
        & "where TRP.Tipo = 10 and TRP.TipoFase <> 0 and TRP.FacturaID = '{1}'" _
        & "group by FacturaId, TRP.TipoFase " _
        & ")as NCR on FAC.TransProdId = NCR.FacturaID " _
        & "Order by NCR.TipoFase desc drop table #tmpFactura " _
        & "set nocount off ", sFacturaId, sFacturaId)

        Return Me.Tabla.Conexion.EjecutarConsulta(sConsulta)
    End Function

    Public Function ObtenerProductoFactura(ByVal sFacturaId As String) As DataTable
        Dim sConsulta As String
        sConsulta = String.Format("select F.ProductoClave, F.Nombre, F.Vendido, isnull(D.Devuelto, 0) as Devuelto, F.Vendido - isnull(D.Devuelto, 0) as Disponible, 0 as Devolucion, F.TipoUnidad, F.Precio, " _
        & "F.DescuentoVta, 0.0 as Subtotal, 0.0 as Descuento, 0.0 as Impuesto, 0.0 as Total from ( " _
        & "select F.ProductoClave, Nombre, sum(F.Cantidad) as Vendido, F.TipoUnidad, F.Precio, sum(DescuentoImp + DescuentoCliente + DescuentoVendedor) as DescuentoVta " _
        & "from ( " _
        & "select PRO.ProductoClave, PRO.Nombre, TPD.Cantidad, TPD.TipoUnidad, TPD.Precio, " _
        & "isnull((select sum(DesImporte) from TpdDes TDD where TPD.TransProdId = TDD.TransProdId and TPD.TransProdDetalleId = TDD.TransProdDetalleId),0) as DescuentoCliente, " _
        & "isnull((select sum(DesImporte) from TPDDesVendedor TDD where TPD.TransProdId = TDD.TransProdId and TPD.TransProdDetalleId = TDD.TransProdDetalleId),0) as DescuentoVendedor, " _
        & "isnull(TPD.DescuentoImp, 0) as DescuentoImp " _
        & "from TransProd TRP " _
        & "inner join TransProdDetalle TPD on TRP.TransProdID = TPD.TransProdID " _
        & "inner join Producto PRO on TPD.ProductoClave = PRO.ProductoClave " _
        & "where TRP.Tipo = 1 and TRP.TipoFase <> 0 and TRP.FacturaID = '{0}' " _
        & "and TPD.Promocion <> 2 " _
        & ")as F " _
        & "group by F.ProductoClave, Nombre, F.TipoUnidad, F.Precio " _
        & ")as F " _
        & "left join ( " _
        & "select ProductoClave, TipoUnidad, sum(Cantidad) as Devuelto, Precio " _
        & "from TransProd TRP " _
        & "inner join TRPDatoFiscal TDF on TRP.TransProdID = TDF.TransProdID and TDF.TipoNotaCredito = 2 " _
        & "inner join TransProdDetalle TPD on TRP.TransProdID = TPD.TransProdID " _
        & "where TRP.Tipo = 10 and TRP.TipoFase <> 0 and TRP.FacturaID = '{1}' " _
        & "group by ProductoClave, TipoUnidad, Precio " _
        & ") as D on F.ProductoClave = D.ProductoClave and F.TipoUnidad = D.TipoUnidad and F.Precio = D.Precio " _
        & "where (Vendido - isnull(Devuelto, 0)) > 0 ", sFacturaId, sFacturaId)

        Return Me.Tabla.Conexion.EjecutarConsulta(sConsulta)
    End Function

    'Public Function ObtenerProductoFactura(ByVal sFacturaId As String) As DataTable
    '    If sFacturaId Is Nothing Then
    '        Exit Function
    '    End If
    '    Dim sConsulta As New System.Text.StringBuilder
    '    sConsulta.AppendLine("select isnull(sum(case when TDI.ImpuestoPU is null or TDI.ImpDesGlb is null then 1 else 0 end), 0) as Nulos ")
    '    sConsulta.AppendLine("from TransProd TRP ")
    '    sConsulta.AppendLine("inner join TPDImpuesto TDI on TRP.TransProdID = TDI.TransProdID ")
    '    sConsulta.AppendLine("where TRP.FacturaID = '" & sFacturaId & "' and TRP.Tipo = 1 ")
    '    Dim bImpuestoGlb As Boolean = False
    '    bImpuestoGlb = (LbConexion.cConexion.Instancia.EjecutarComandoScalar(sConsulta.ToString) = 0)


    '    sConsulta = New System.Text.StringBuilder

    '    If bImpuestoGlb Then
    '        Dim sClienteClave As String
    '        Dim dFechaFactura As Date
    '        sConsulta = New System.Text.StringBuilder
    '        sConsulta.AppendLine("select VIS.ClienteClave, FAC.FechaHoraAlta ")
    '        sConsulta.AppendLine("from TransProd FAC ")
    '        sConsulta.AppendLine("inner join Visita VIS on FAC.VisitaClave = VIS.VisitaClave and FAC.DiaClave = VIS.DiaClave ")
    '        sConsulta.AppendLine("where FAC.TransProdID = '" & sFacturaId & "'")
    '        Dim dtDatosFac As DataTable = LbConexion.cConexion.Instancia.EjecutarConsulta(sConsulta.ToString)
    '        sClienteClave = dtDatosFac.Rows(0)("ClienteClave")
    '        dFechaFactura = CType(dtDatosFac.Rows(0)("FechaHoraAlta"), Date)

    '        sConsulta = New System.Text.StringBuilder
    '        sConsulta.AppendLine("set nocount on ")
    '        sConsulta.AppendLine("if (select object_id('tempdb..#ImpNoDes')) is not null drop table #ImpNoDes ")
    '        sConsulta.AppendLine("select * into #ImpNoDes from ( ")
    '        sConsulta.AppendLine("select TDI.TransProdID, TDI.TransProdDetalleID, SUM(TDI.ImpuestoPU) as ImpuestoPU, SUM(TDI.ImpDesGlb) as ImpDesGlb ")
    '        sConsulta.AppendLine("from TPDImpuesto TDI ")
    '        sConsulta.AppendLine("inner join TransProd TRP on TDI.TransProdID = TRP.TransProdID ")
    '        sConsulta.AppendLine("where TRP.FacturaId = '" & sFacturaId & "' and TRP.Tipo = 1 and TDI.ImpuestoClave in ( ")
    '        sConsulta.AppendLine("select ImpuestoClave ")
    '        sConsulta.AppendLine("from CLINoDesImp ")
    '        sConsulta.AppendLine("where ClienteClave = '" & sClienteClave & "' and '" & dFechaFactura.ToString("s") & "' between FechaInicio and FechaFin) ")
    '        sConsulta.AppendLine("group by TDI.TransProdID, TDI.TransProdDetalleID ")
    '        sConsulta.AppendLine(") as t ")
    '    End If

    '    sConsulta.AppendLine("select F.ProductoClave, F.Nombre, F.Vendido, isnull(D.Devuelto, 0) as Devuelto, F.Vendido - isnull(D.Devuelto, 0) as Disponible, 0 as Devolucion, F.TipoUnidad, F.Precio, ")
    '    sConsulta.AppendLine("F.DescuentoVta, 0.0 as Subtotal, 0.0 as Descuento, 0.0 as Impuesto, 0.0 as Total from ( ")
    '    sConsulta.AppendLine("select F.ProductoClave, Nombre, sum(F.Cantidad) as Vendido, F.TipoUnidad, F.Precio, sum(DescuentoImp + DescuentoCliente + DescuentoVendedor) as DescuentoVta ")
    '    sConsulta.AppendLine("from ( ")
    '    If bImpuestoGlb Then
    '        sConsulta.AppendLine("select PRO.ProductoClave, PRO.Nombre, TPD.Cantidad, TPD.TipoUnidad, TPD.Precio + isnull(IMP.ImpuestoPU, 0) as Precio , ")
    '    Else
    '        sConsulta.AppendLine("select PRO.ProductoClave, PRO.Nombre, TPD.Cantidad, TPD.TipoUnidad, TPD.Precio, ")
    '    End If

    '    sConsulta.AppendLine("isnull((select sum(DesImporte) from TpdDes TDD where TPD.TransProdId = TDD.TransProdId and TPD.TransProdDetalleId = TDD.TransProdDetalleId),0) as DescuentoCliente, ")
    '    sConsulta.AppendLine("isnull((select sum(DesImporte) from TPDDesVendedor TDD where TPD.TransProdId = TDD.TransProdId and TPD.TransProdDetalleId = TDD.TransProdDetalleId),0) as DescuentoVendedor, ")
    '    If bImpuestoGlb Then
    '        sConsulta.AppendLine("(TPD.descuentoimp + isnull(((TPD.Cantidad * IMP.ImpuestoPU) - IMP.ImpDesGlb), 0)) as DescuentoImp ")
    '    Else
    '        sConsulta.AppendLine("isnull(TPD.DescuentoImp, 0) as DescuentoImp ")
    '    End If
    '    sConsulta.AppendLine("from TransProd TRP ")
    '    sConsulta.AppendLine("inner join TransProdDetalle TPD on TRP.TransProdID = TPD.TransProdID ")
    '    sConsulta.AppendLine("inner join Producto PRO on TPD.ProductoClave = PRO.ProductoClave ")
    '    If bImpuestoGlb Then
    '        sConsulta.AppendLine("left join #ImpNoDes IMP on TPD.TransProdID = IMP.TransProdId and TPD.TransProdDetalleID = IMP.TransProdDetalleID ")
    '    End If
    '    sConsulta.AppendLine("where TRP.Tipo = 1 and TRP.TipoFase <> 0 and TRP.FacturaID = '" + sFacturaId + "' ")
    '    sConsulta.AppendLine("and TPD.Promocion <> 2 ")
    '    sConsulta.AppendLine(")as F ")
    '    sConsulta.AppendLine("group by F.ProductoClave, Nombre, F.TipoUnidad, F.Precio ")
    '    sConsulta.AppendLine(")as F ")
    '    sConsulta.AppendLine("left join ( ")
    '    sConsulta.AppendLine("select ProductoClave, TipoUnidad, sum(Cantidad) as Devuelto, Precio ")
    '    sConsulta.AppendLine("from TransProd TRP ")
    '    sConsulta.AppendLine("inner join TRPDatoFiscal TDF on TRP.TransProdID = TDF.TransProdID and TDF.TipoNotaCredito = 2 ")
    '    sConsulta.AppendLine("inner join TransProdDetalle TPD on TRP.TransProdID = TPD.TransProdID ")
    '    sConsulta.AppendLine("where TRP.Tipo = 10 and TRP.TipoFase <> 0 and TRP.FacturaID = '" + sFacturaId + "' ")
    '    sConsulta.AppendLine("group by ProductoClave, TipoUnidad, Precio ")
    '    sConsulta.AppendLine(") as D on F.ProductoClave = D.ProductoClave and F.TipoUnidad = D.TipoUnidad and F.Precio = D.Precio ")
    '    sConsulta.AppendLine("where (Vendido - isnull(Devuelto, 0)) > 0 ")

    '    Return Me.Tabla.Conexion.EjecutarConsulta(sConsulta.ToString())
    'End Function

    Public Function ObtenerProductoFacturaDescuento(ByVal sFacturaId As String) As DataTable
        Dim sConsulta As String
        'sConsulta = String.Format("set nocount on " _
        '& "select ProductoClave, TipoUnidad, SUM(Subtotal - (DescuentoCliente + DescuentoVendedor + DescuentoImp)) as Subtotal " _
        '& "from ( " _
        '& "select TPD.ProductoClave, TPD.TipoUnidad, TPD.Cantidad * TPD.Precio as Subtotal, " _
        '& "isnull((select sum(DesImporte) from TpdDes TDD where TPD.TransProdId = TDD.TransProdId and TPD.TransProdDetalleId = TDD.TransProdDetalleId),0) as DescuentoCliente, " _
        '& "isnull((select sum(DesImporte) from TPDDesVendedor TDD where TPD.TransProdId = TDD.TransProdId and TPD.TransProdDetalleId = TDD.TransProdDetalleId),0) as DescuentoVendedor, " _
        '& "isnull(TPD.DescuentoImp, 0) as DescuentoImp " _
        '& "from TransProd TRP " _
        '& "inner join TransProdDetalle TPD on TRP.TransProdID = TPD.TransProdID " _
        '& "where TRP.Tipo = 1 and TRP.TipoFase <> 0 and TRP.FacturaID = '{0}' " _
        '& ")as t " _
        '& "group by ProductoClave, TipoUnidad " _
        '& "set nocount off ", sFacturaId)

        sConsulta = String.Format("set nocount on " _
        & "select * into #tmpVenta from ( " _
        & "select ProductoClave, TipoUnidad, SUM(Subtotal - (DescuentoCliente + DescuentoVendedor + DescuentoImp)) as Subtotal " _
        & "from ( " _
        & "select TPD.ProductoClave, TPD.TipoUnidad, TPD.Cantidad * TPD.Precio as Subtotal, " _
        & "isnull((select sum(DesImporte) from TpdDes TDD where TPD.TransProdId = TDD.TransProdId and TPD.TransProdDetalleId = TDD.TransProdDetalleId),0) as DescuentoCliente, " _
        & "isnull((select sum(DesImporte) from TPDDesVendedor TDD where TPD.TransProdId = TDD.TransProdId and TPD.TransProdDetalleId = TDD.TransProdDetalleId),0) as DescuentoVendedor, " _
        & "isnull(TPD.DescuentoImp, 0) as DescuentoImp " _
        & "from TransProd TRP " _
        & "inner join TransProdDetalle TPD on TRP.TransProdID = TPD.TransProdID " _
        & "where TRP.Tipo = 1 and TRP.TipoFase <> 0 and TRP.FacturaID = '{0}' " _
        & ")as t " _
        & "group by ProductoClave, TipoUnidad " _
        & ") as V " _
        & "select * into #tmpDevolucion from ( " _
        & "select TPD.ProductoClave, TPD.TipoUnidad, sum(TPD.Subtotal) as Subtotal " _
        & "from TransProd TRP " _
        & "inner join TRPDatoFiscal TDF on TRP.TransProdID = TDF.TransProdID and TDF.TipoNotaCredito = 2 " _
        & "inner join TransProdDetalle TPD on TRP.TransProdID = TPD.TransProdID " _
        & "where TRP.Tipo = 10 and TRP.TipoFase <> 0 and TRP.FacturaID = '{1}' " _
        & "group by ProductoClave, TipoUnidad " _
        & ") as D " _
        & "select VTA.ProductoClave, VTA.TipoUnidad, VTA.Subtotal - isnull(DEV.Subtotal, 0) as Subtotal " _
        & "from #tmpVenta VTA " _
        & "left join #tmpDevolucion DEV on VTA.ProductoClave = DEV.ProductoClave and VTA.TipoUnidad = DEV.TipoUnidad " _
        & "drop table #tmpVenta " _
        & "drop table #tmpDevolucion " _
        & "set nocount off ", sFacturaId, sFacturaId)

        Return Me.Tabla.Conexion.EjecutarConsulta(sConsulta)
    End Function

    Public Function ObtenerDetallePedidos(ByVal Pedidos As List(Of String)) As DataTable
        Dim sConsulta As String
        Dim transprodids As String = ""

        For Each id As String In Pedidos
            transprodids += "'" + id + "',"
        Next
        If transprodids.Length > 0 Then
            transprodids = transprodids.Remove(transprodids.Length - 1)
        Else
            transprodids = "''"

        End If
        sConsulta = "select P.ProductoClave,P.Nombre ,sum(Cantidad) as Cantidad  ,t.TipoUnidad as Unidad from transproddetalle t inner join Producto P on P.ProductoClave =t.ProductoClave where transprodid in (" + transprodids + ") group by P.ProductoClave,P.Nombre,t.TipoUnidad"


        Return Me.Tabla.Conexion.EjecutarConsulta(sConsulta)
    End Function

    Public Function ObtenerProductoDescuento() As DataTable
        Dim sConsulta As String
        'sConsulta = String.Format("select top 1 PRO.ProductoClave, PRO.Nombre, 0 as Vendido, 0 as Devuelto, 0.0 as DescuentoVta, 0.0 as Impuesto, 0.0 as Total " _
        sConsulta = String.Format("select top 1 PRO.ProductoClave, PRO.Nombre, 0 as Vendido, 0 as Devuelto, 1 as Disponible, 1 as Devolucion, PRD.PRUTipoUnidad as TipoUnidad, 0.0 as Precio, 0.0 as DescuentoVta, 0.0 as SubTotal, 0.0 as Descuento, 0.0 as Impuesto, 0.0 as Total " _
        & "from Producto PRO " _
        & "inner join ProductoDetalle PRD on PRO.ProductoClave = PRD.ProductoClave and PRD.ProductoClave = PRD.ProductoDetClave and PRD.Factor = 1 " _
        & "inner join ProductoUnidad PRU on PRD.ProductoClave = PRU.ProductoClave and PRD.PRUTipoUnidad = PRU.PRUTipoUnidad where PRO.Tipo = 6 and PRO.TipoFase = 1 and PRU.TipoEstado = 1")

        Return Me.Tabla.Conexion.EjecutarConsulta(sConsulta)
    End Function

    Public Function ObtenerProductoNotaCredito(ByVal sTransProdId As String) As DataTable
        Dim sConsulta As String
        sConsulta = String.Format("select TPD.ProductoClave, PRO.Nombre, TPD.Cantidad as Vendido, TPD.Cantidad as Devuelto, TPD.Cantidad as Disponible, TPD.Cantidad as Devolucion, " _
        & "TPD.TipoUnidad, TPD.Precio, TPD.DescuentoImp as DescuentoVta, TPD.Subtotal, TPD.DescuentoImp as Descuento, TPD.Impuesto, TPD.Total " _
        & "from TransProdDetalle TPD " _
        & "inner join Producto PRO on TPD.ProductoClave = PRO.ProductoClave " _
        & "where TransProdID = '{0}' ", sTransProdId)

        Return Me.Tabla.Conexion.EjecutarConsulta(sConsulta)
    End Function

    Public Function ObtenerSolicitadosFactura(ByVal sFacturaID As String) As DataTable
        Dim sConsulta As String
        sConsulta = String.Format("Select AFA.* from TransProd TRP inner join AddendaFactura AFA on TRP.TransProdID = AFA.TransProdID where AFA.TransProdID = '{0}' ", sFacturaID)

        Return Me.Tabla.Conexion.EjecutarConsulta(sConsulta)
    End Function

    Public Function ObtenerNotaCreditoFactura(ByVal sFacturaId As String) As DataTable
        Dim sConsulta As String
        sConsulta = String.Format("select * from TransProd where Tipo = 10 and TipoFase <> 0 and FacturaID = '{0}'", sFacturaId)

        Return Me.Tabla.Conexion.EjecutarConsulta(sConsulta)
    End Function

    Public Function ObtenerRutaFactura() As String
        Dim sConsulta As String
        sConsulta = "select distinct VIS.RUTClave "
        sConsulta &= "from TransProd TRP "
        sConsulta &= "inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave and TRP.DiaClave = VIS.DiaClave "
        sConsulta &= "where TRP.FacturaID = '" & Me.TransProdID & "' "

        Dim dtRutas As DataTable = Me.Tabla.Conexion.EjecutarConsulta(sConsulta)
        If dtRutas.Rows.Count <> 1 Then
            Return ""
        Else
            Return dtRutas.Rows(0)("RUTClave")
        End If
    End Function

    Public Function PermiteCascada(ByVal pvCondicion As String) As Boolean
        Dim cmd As String = "select permitecascada from descuento where descuentoclave = " & _
        "(select top 1 DescuentoClave from descliente where clienteclave = " & _
        "(select top 1 Clienteclave from transprod trp " & pvCondicion & ") order by jerarquia )"
        Dim ldt As DataTable = LbConexion.cConexion.Instancia.EjecutarConsulta(cmd)

        If ldt Is Nothing Then Return False
        If ldt.Rows.Count <= 0 Then Return False
        If ldt.Rows(0).Item("permiteCascada") = 1 Then Return True

        Return False
    End Function

    Public Function VigenciaImpuesto(ByVal pvFechaFactura As Date) As Boolean
        Dim loConexion As LbConexion.cConexion = LbConexion.cConexion.Instancia
        Dim lbModificado As Boolean = False


        Dim ldtTPDImpuesto As DataTable = loConexion.EjecutarConsulta("SELECT TransProdId, TransProdDetalleId, TPDImpuestoId, ImpuestoClave, ImpuestoPor FROM TPDImpuesto WHERE TransProdId='" & Me.TransProdID & "'")

        If Not IsNothing(ldtTPDImpuesto) Then
            Dim tpd As cTransProdDetalle
            For Each ldRow As DataRow In ldtTPDImpuesto.Rows
                tpd = Nothing
                Dim ldtImpuestoVig As DataTable = loConexion.EjecutarConsulta("SELECT * FROM ImpuestoVig WHERE ImpuestoClave='" & ldRow!ImpuestoClave & "' and FechaInicial<= " & loConexion.UniFechaSQL(pvFechaFactura) & " AND FechaFinal >= " & loConexion.UniFechaSQL(pvFechaFactura))
                If ldtImpuestoVig.Rows.Count > 0 Then
                    If ldtImpuestoVig.Rows(0)!Valor <> ldRow!ImpuestoPor Then
                        tpd = Me.TransProdDetalle(ldRow!TransProdDetalleId)
                        Dim loImpuesto As New ERMIMPLOG.CImpuesto
                        loImpuesto.Recuperar(ldRow!ImpuestoClave)
                        If loImpuesto.TipoValor = 1 And loImpuesto.TipoAplicacion = 1 Then
                            Dim lnImpuestoImp As Double = Math.Round(tpd.Subtotal * (ldtImpuestoVig.Rows(0)!Valor / 100), 4)
                            loConexion.EjecutarComando("UPDATE TPDImpuesto SET ImpuestoPor=" & ldtImpuestoVig.Rows(0)!Valor & ", ImpuestoImp=" & lnImpuestoImp & ", MFechaHora=GETDATE(), MUsuarioId='" & lbGeneral.cParametros.UsuarioID & "' WHERE TransProdId='" & ldRow!TransProdId & "' AND TransProdDetalleId='" & ldRow!TransProdDetalleId & "' AND TPDImpuestoId='" & ldRow!TPDImpuestoId & "'")
                            lbModificado = True
                        End If
                    End If
                End If
            Next

            If lbModificado Then
                If PermiteCascada("where transprodid ='" & TransProdID & "'") = False Then
                    Dim dtImpuestos As DataTable = loConexion.EjecutarConsulta("select sum(impuestoimp) as impuestoimp, transprodid, transproddetalleid " & _
                        "from tpdimpuesto " & _
                        "where transprodid= '" & Me.TransProdID & "' group by transprodid,transproddetalleid")
                    For Each ldRow As DataRow In dtImpuestos.Rows
                        tpd = Me.TransProdDetalle(ldRow!TransProdDetalleId)
                        loConexion.EjecutarComando("UPDATE tpddes set desimporte = isnull((despor * " & tpd.Subtotal & ")/100,0), desimpuesto = isnull((despor * " & ldRow("impuestoimp") & ")/100,0), MFechaHora=GETDATE(), MUsuarioId='" & lbGeneral.cParametros.UsuarioID & "' WHERE TransProdId='" & ldRow!TransProdId & "' AND TransProdDetalleId='" & ldRow!TransProdDetalleId & "' ")
                        loConexion.EjecutarComando("UPDATE tpddesVendedor set desimporte = isnull((" & tpd.Subtotal & " - (select isnull(sum(desimporte),0) from tpddes WHERE TransProdId='" & ldRow!TransProdId & "' AND TransProdDetalleId='" & ldRow!TransProdDetalleId & "' ))* despor/100,0), " & _
                        "desimpuesto = isnull((" & tpd.Subtotal & " - (select isnull(sum(desimpuesto),0) from tpddes WHERE TransProdId='" & ldRow!TransProdId & "' AND TransProdDetalleId='" & ldRow!TransProdDetalleId & "' ))*despor/100,0), MFechaHora=GETDATE(), MUsuarioId='" & lbGeneral.cParametros.UsuarioID & "' WHERE TransProdId='" & ldRow!TransProdId & "' AND TransProdDetalleId='" & ldRow!TransProdDetalleId & "' ")
                    Next

                    Dim lnImpuestoTotal As Double = 0
                    Dim lnTotal As Double = 0
                    For Each loItem As cTransProdDetalle In Me.TransProdDetalle.ToArrayList
                        loItem.Impuesto = Math.Round(loConexion.EjecutarConsulta("SELECT isnull(sum(ImpuestoImp),0) ImpuestoImp FROM TPDImpuesto WHERE TransProdId='" & loItem.TransProdID & "' AND TransProdDetalleId='" & loItem.TransProdDetalleID & "'").Rows(0)!ImpuestoImp, 4)
                        loItem.Total = loItem.Subtotal + loItem.Impuesto

                        Dim dtTpdDes As DataTable = loConexion.EjecutarConsulta("select isnull(sum(Desimpuesto),0) as desimpuesto from tpddes where transprodid ='" & loItem.TransProdID & "' and transproddetalleid ='" & loItem.TransProdDetalleID & "' ")
                        lnImpuestoTotal += Math.Round((loItem.Impuesto - dtTpdDes.Rows(0).Item("Desimpuesto") - ((loItem.Impuesto - dtTpdDes.Rows(0).Item("Desimpuesto")) * Me.DescVendPor / 100)), 4)
                    Next

                    Me.Impuesto = lnImpuestoTotal
                    Me.Total = Me.SubTotal + Me.Impuesto
                    Me.Grabar()

                Else

                    Dim dtImpuestos As DataTable = loConexion.EjecutarConsulta("select sum(impuestoimp) as impuestoimp, transprodid, transproddetalleid " & _
                    "from tpdimpuesto " & _
                    "where transprodid= '" & Me.TransProdID & "' group by transprodid,transproddetalleid")

                    For Each ldRow As DataRow In dtImpuestos.Rows
                        tpd = Me.TransProdDetalle(ldRow!TransProdDetalleId)

                        Dim dtTpdDes As DataTable = loConexion.EjecutarConsulta("select * from tpddes where transprodid= '" & Me.TransProdID & "' and transproddetalleid ='" & tpd.TransProdDetalleID & "' " & _
                        "order by descuentoclave,jerarquia  ")
                        Dim lSubTotal As Double = tpd.Subtotal
                        Dim lImpuestoImpT As Double = 0

                        If Not dtTpdDes Is Nothing Then
                            For Each row As DataRow In dtTpdDes.Rows
                                Dim desImporte As Double = lSubTotal * IIf(row("Despor") Is Nothing, 0, row("DesPor")) / 100
                                Dim lImpuestoImp As Double = (ldRow("impuestoimp") - lImpuestoImpT) * IIf(row("Despor") Is Nothing, 0, row("DesPor")) / 100

                                loConexion.EjecutarComando("UPDATE tpddes set desimporte = isnull((despor * " & lSubTotal & ")/100,0), desimpuesto = isnull((despor * " & (ldRow("impuestoimp") - lImpuestoImpT) & ")/100,0), MFechaHora=GETDATE(), MUsuarioId='" & lbGeneral.cParametros.UsuarioID & "' WHERE TransProdId='" & ldRow!TransProdId & "' AND TransProdDetalleId='" & ldRow!TransProdDetalleId & "' and descuentoclave = '" & row("DescuentoClave") & "' ")
                                lSubTotal = lSubTotal - desImporte
                                lImpuestoImpT += lImpuestoImp
                            Next
                        End If
                        Dim cmd As String = "UPDATE tpddesVendedor set desimporte = isnull((" & tpd.Subtotal & " - (select isnull(sum(desimporte),0) from tpddes WHERE TransProdId='" & ldRow!TransProdId & "' AND TransProdDetalleId='" & ldRow!TransProdDetalleId & "' ))* despor/100,0), " & _
                        "desimpuesto = ((select sum(impuestoImp) from tpdImpuesto where transprodid = '" & ldRow!TransProdId & "' and TransprodDetalleId = '" & ldRow!TransProdDetalleId & "') - (select sum(desimporte) from tpdDes where transprodid = '" & ldRow!TransProdId & "' and TransprodDetalleId = '" & ldRow!TransProdDetalleId & "')) * Despor/100, " & _
                        "MFechaHora=GETDATE(), MUsuarioId='" & lbGeneral.cParametros.UsuarioID & "' WHERE TransProdId='" & ldRow!TransProdId & "' AND TransProdDetalleId='" & ldRow!TransProdDetalleId & "' "
                        loConexion.EjecutarComando(cmd)
                    Next

                    Dim lnImpuestoTotal As Double = 0
                    Dim lnTotal As Double = 0
                    For Each loItem As cTransProdDetalle In Me.TransProdDetalle.ToArrayList
                        loItem.Impuesto = Math.Round(loConexion.EjecutarConsulta("SELECT isnull(sum(ImpuestoImp),0) ImpuestoImp FROM TPDImpuesto WHERE TransProdId='" & loItem.TransProdID & "' AND TransProdDetalleId='" & loItem.TransProdDetalleID & "'").Rows(0)!ImpuestoImp, 4)
                        loItem.Total = loItem.Subtotal + loItem.Impuesto

                        Dim dtTpdDes As DataTable = loConexion.EjecutarConsulta("select isnull(sum(Desimpuesto),0) as desimpuesto from tpddes where transprodid ='" & loItem.TransProdID & "' and transproddetalleid ='" & loItem.TransProdDetalleID & "' ")
                        lnImpuestoTotal += Math.Round((loItem.Impuesto - dtTpdDes.Rows(0).Item("Desimpuesto") - ((loItem.Impuesto - dtTpdDes.Rows(0).Item("Desimpuesto")) * Me.DescVendPor / 100)), 4)
                    Next

                    Me.Impuesto = lnImpuestoTotal
                    Me.Total = Me.SubTotal + Me.Impuesto
                    Me.Grabar()
                End If
            End If
        End If

        Return lbModificado
    End Function

    Public Function FechaSobrantesValida(ByVal pvFecha As Date, ByVal pvAlmacen As String) As Boolean

        Dim cmd As String = "select count(*) from transprod where tipo =25 and tipofase=1 and transprodid <> '" & Me.TransProdID & "' and FechaHoraAlta = " & LbConexion.cConexion.Instancia.UniFechaSQL(pvFecha, , "dd/MM/yyyy") & " and Notas = '" & pvAlmacen & "'"
        Dim ldt As DataTable = LbConexion.cConexion.Instancia.EjecutarConsulta(cmd)

        If ldt.Rows(0).Item(0) > 0 Then Return False

        Return True
    End Function

    Public Sub RecalcularTotales()
        ' Hasta aqui el descuento del cliente ya esta calculado y aplicado, tambien al Impuesto
        ' Calcular el importe del descuento del subtotal
        Me.DescuentoVendedor = (Me.SubTDetalle - Me.DescuentoImp) * (Me.DescVendPor / 100)
        ' Calcular el importe del descuento del impuesto
        'pvTransProd.DescuentoImpuestoVendedor = (pvTransProd.Impuesto - pvTransProd.DescuentoImpuestoCliente) * (pvTransProd.DescVendPor / 100)
        Me.SubTotal = Me.SubTDetalle - Me.DescuentoImp - Me.DescuentoVendedor
        If Me.SubTotal < 0 Then Me.SubTotal = 0
        Me.Total = Me.SubTotal + Me.Impuesto '- pvTransProd.DescuentoImpuestoCliente - pvTransProd.DescuentoImpuestoVendedor)

        If Me.Total < 0 Then Me.Total = 0
    End Sub

    Public Sub ActualizaPagoAutomatico(ByVal pvVendedorId As String)
        Dim fecha As DateTime = LbConexion.cConexion.Instancia().ObtenerFecha()

        'Obtener el folioId referente a los pagos asignados al vendedor
        Dim sFolioID As String = ERMFOLLOG.cFolio.ObtenerFolioID(6, pvVendedorId)
        'Obtener el folio referente a los pagos asignados al vendedor
        Dim FolioPago As String = ERMFOLLOG.cFolio.ObtenerFolioEscritorio(sFolioID, pvVendedorId)

        Dim lAbono As cAbono = New cAbono()
        lAbono.ABNId = lbGeneral.cKeyGen.KEYGEN(0)
        lAbono.Folio = FolioPago
        lAbono.FechaCreacion = Convert.ToDateTime(fecha)
        lAbono.VisitaClave = Me.VisitaClave
        lAbono.DiaClave = Me.DiaClave
        lAbono.FechaAbono = Convert.ToDateTime(fecha.ToString("dd/MM/yyyy"))
        lAbono.Saldo = 0
        lAbono.Total = Me.Total

        Dim aCampos As String() = New String() {"ABNId", "Folio", "FechaCreacion", "VisitaClave", "DiaClave", "FechaAbono", _
         "Saldo", "Total"}
        lAbono.ValidarClase(aCampos)
        lAbono.Insertar(New String(-1) {})
        'abono.Grabar();
        ERMFOLLOG.cFolio.Confirmar(sFolioID, lbGeneral.cParametros.UsuarioID, pvVendedorId)


        Dim lAbnTrp As New cAbnTrp(lAbono)
        lAbnTrp.ABNId = lAbono.ABNId
        lAbnTrp.TransProdID = Me.TransProdID
        lAbnTrp.FechaHora = Convert.ToDateTime(fecha)
        lAbnTrp.Importe = Me.Total

        aCampos = New String() {"ABNId", "TransProdID", "FechaHora", "Importe", "TipoFaseIntSal"}
        lAbnTrp.ValidarClase(aCampos)
        lAbnTrp.Insertar(New String(-1) {})
        'this.Grabar();


        Dim ABNDetalle As cABNDetalle = New cABNDetalle(lAbono)
        ABNDetalle.ABNId = lAbnTrp.ABNId
        ABNDetalle.ABDId = lbGeneral.cKeyGen.KEYGEN(0)
        ABNDetalle.TipoPago = Convert.ToInt16(Me.ClientePagoID)
        ABNDetalle.Importe = Me.Total
        ABNDetalle.SaldoDeposito = 0
        ABNDetalle.MonedaId = ""
        ABNDetalle.Referencia = ""

        aCampos = New String() {"ABNId", "ABDId", "TipoPago", "Importe"}
        ABNDetalle.ValidarClase(aCampos)
        ABNDetalle.Insertar(New String(-1) {})
        'ABNDetalle.Grabar();
        lAbono.ABNDetalle.Insertar(ABNDetalle)
        lAbono.AbnTrp.Insertar(lAbnTrp)
        Me.Abono.Add(lAbono)
        'Me.Abono.Insertar(lAbono)
        'lAbnTrp.Abono.Insertar(lAbono)
        'Me.AbnTrp.Insertar(lAbnTrp)

    End Sub

    Public Sub EliminarTransProdDetalle(ByVal pvTransProdDetalleId As String)

        For i As Integer = 0 To Me.TransProdDetalle().ToArrayList().Count - 1
            Dim tpd As cTransProdDetalle = Me.TransProdDetalle().ToArrayList().Item(i)
            If tpd.TransProdDetalleID = pvTransProdDetalleId Then
                tpd.EliminarHijos()
                Me.TransProdDetalle().ToArrayList().RemoveAt(i)
                Exit For
            End If
        Next

        If Me.TransProdDetalle().ToDataTable.Rows.Count > 0 Then
            For indice As Integer = Me.TransProdDetalle().ToDataTable.Rows.Count - 1 To 0 Step -1
                If TransProdDetalle().ToDataTable.Rows(indice).RowState <> DataRowState.Deleted Then
                    If TransProdDetalle().ToDataTable.Rows(indice).Item("TransProdDetalleId").ToString() = pvTransProdDetalleId Then
                        Me.TransProdDetalle().ToDataTable.Rows.RemoveAt(indice)
                        Exit For
                    End If
                End If

            Next
        End If

        'Dim dt As DataTable = Me.TransProdDetalle().ToDataTable
        'For Each dr As DataRow In Me.TransProdDetalle().ToDataTable.Rows
        '    If dr("TransProdDetalleId") = pvTransProdDetalleId Then
        '        Me.TransProdDetalle().ToDataTable.Rows.Remove(dr)
        '        Exit For
        '    End If
        'Next

    End Sub

    Public Sub DesAsociarVentasFactura()
        Dim sComando As String = ""
        sComando &= "UPDATE TransProd "
        sComando &= "SET FacturaId = NULL, FechaFacturacion = '1900-01-01T00:00:00', TipoFase = 2 "
        sComando &= "WHERE Tipo <> 0 AND FacturaID = '" + Me.TransProdID + "' "
        Me.Tabla.Conexion.EjecutarComando(sComando)
    End Sub

    Public Function ObtenerVentasCliente(ByVal sClienteClave As String, ByVal dFechaInicial As DateTime, ByVal dFechaFinal As DateTime, ByVal iTipoFiltro As Integer) As DataTable
        Dim sConsulta As String
        Dim filtro As String = IIf(sClienteClave.Length > 0, "V.ClienteClave = '" + sClienteClave + "'", "")
        filtro = filtro.Trim()

        If iTipoFiltro > 0 Then
            filtro = filtro + IIf(filtro.Length > 0, " AND ", " ") + FiltroFecha("T.FechaHoraAlta", dFechaInicial, dFechaFinal, iTipoFiltro)
            filtro = filtro.Trim()
        End If

        sConsulta = String.Format( _
            " SELECT T.TransProdID, T.Folio, T.TipoFase, T.FechaHoraAlta AS Fecha, T.TipoFase, T.Total, C.Clave, C.RazonSocial, C.NombreCorto" + _
            " FROM TransProd T " + _
            " INNER JOIN Visita V ON V.VisitaClave = T.VisitaClave AND V.DiaClave = T.DiaClave " + _
            " INNER JOIN Cliente C ON C.ClienteClave = V.ClienteClave " + _
            " WHERE T.Tipo = '1' {0}", IIf(filtro.Length = 0, "", " AND " + filtro))

        Return Me.Tabla.Conexion.EjecutarConsulta(sConsulta)
    End Function

    Public Function ObtenerSubtotalEImpuesto(ByVal sClienteClave As String, ByRef nSubtotal As Double, ByRef nImpuesto As Double) As Boolean
        Dim sConsulta As New Text.StringBuilder
        nSubtotal = 0
        nImpuesto = 0
        Try
            sConsulta.AppendLine("select sum((Subtotal - Descuento)) as Subtotal from ( ")
            sConsulta.AppendLine("select TRP.TransProdID, sum(TPD.Cantidad * (TPD.Precio + case when TDI.ImpuestoPU is null then 0 else TDI.ImpuestoPU end)) as SubTotal, ")
            sConsulta.AppendLine("(trp.descuentoimp + trp.descuentovendedor + sum(tpd.descuentoimp) + SUM(case when TDI.ImpuestoPU is null then 0 else (TPD.Cantidad * TDI.ImpuestoPU) - TDI.ImpDesGlb end)) as Descuento ")
            sConsulta.AppendLine("from TransProd TRP ")
            sConsulta.AppendLine("inner join TransProdDetalle TPD on TRP.TransProdId = TPD.TransProdId ")
            sConsulta.AppendLine("left join ( ")
            sConsulta.AppendLine("select TransProdId, TransProdDetalleId, sum(ImpuestoPU) as ImpuestoPU, sum(ImpDesGlb) as ImpDesGlb ")
            sConsulta.AppendLine("from TpdImpuesto ")
            sConsulta.AppendLine("where TransProdId = '" & Me.TransProdID & "' and ImpuestoClave in ( ")
            sConsulta.AppendLine("select ImpuestoClave ")
            sConsulta.AppendLine("from CLINoDesImp ")
            sConsulta.AppendLine("where ClienteClave = '" & sClienteClave & "' and getdate() between FechaInicio and FechaFin) ")
            sConsulta.AppendLine("group by TransProdId, TransProdDetalleId ")
            sConsulta.AppendLine(")as TDI on TPD.TransProdId = TDI.TransProdId and TPD.TransProdDetalleId = TDI.TransProdDetalleId ")
            sConsulta.AppendLine("where TRP.TransProdId = '" & Me.TransProdID & "' ")
            sConsulta.AppendLine("group by TRP.TransProdID, trp.descuentoimp,trp.descuentovendedor, trp.total ")
            sConsulta.AppendLine(") as t ")
            nSubtotal = Me.Tabla.Conexion.EjecutarComandoScalar(sConsulta.ToString)

            sConsulta = New Text.StringBuilder
            sConsulta.AppendLine("select isnull(sum(TDI.ImpDesGlb), 0) as ImpDesGlb ")
            sConsulta.AppendLine("from TPDImpuesto TDI ")
            sConsulta.AppendLine("inner join TransProd TRP on TDI.TransProdID = TRP.TransProdID ")
            sConsulta.AppendLine("inner join Impuesto IMP on TDI.ImpuestoClave = IMP.ImpuestoClave ")
            sConsulta.AppendLine("where TRP.TransProdId = '" & Me.TransProdID & "' and Trp.Tipo = 1 ")
            sConsulta.AppendLine("and TDI.ImpuestoClave not in ( ")
            sConsulta.AppendLine("select ImpuestoClave ")
            sConsulta.AppendLine("from CLINoDesImp ")
            sConsulta.AppendLine("where ClienteClave = '" & sClienteClave & "' and getdate() between FechaInicio and FechaFin ) ")
            nImpuesto = Me.Tabla.Conexion.EjecutarComandoScalar(sConsulta.ToString)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    'Public Sub RecalcularImpuestoGlobal()
    '    Dim sQuery As New System.Text.StringBuilder
    '    Dim oDt As DataTable

    '    'Impuestos del producto (descuento de producto y promociones)
    '    Dim oArrImpClave As New ArrayList
    '    'Dim oArrImpCant As New ArrayList
    '    Dim oArrImpTipoValor As New ArrayList

    '    sQuery.Append("SELECT Distinct Imp.ImpuestoClave, Jerarquia, TipoValor from TPDImpuesto TPDI INNER JOIN Impuesto as Imp ON TPDI.ImpuestoClave=Imp.ImpuestoClave WHERE TPDI.transprodid = '" & oTransProd.TransProdId & "' ORDER BY Jerarquia")
    '    oDt = oDBVen.RealizarConsultaSQL(sQuery.ToString, "Impuestos")

    '    For Each oDr As DataRow In oDt.Rows
    '        oArrImpClave.Add(oDr("ImpuestoClave"))
    '        'oArrImpCant.Add(0)
    '        oArrImpTipoValor.Add(oDr("TipoValor"))
    '    Next
    '    oDt.Dispose()

    '    'Descuentos por cliente
    '    Dim oArrDescuentos As New ArrayList

    '    sQuery = New System.Text.StringBuilder
    '    sQuery.Append("SELECT DesPor,Jerarquia,TipoCascada FROM TpdDes WHERE TransProdId = '" & oTransProd.TransProdId & "' group by DescuentoClave,DesPor,Jerarquia,TipoCascada ORDER BY Jerarquia ASC")
    '    oDt = oDBVen.RealizarConsultaSQL(sQuery.ToString, "TpdDes")

    '    For Each oDr As DataRow In oDt.Rows
    '        oArrDescuentos.Add(oDr)
    '    Next
    '    oDt.Dispose()

    '    'Para cada TransProdDetalle recalcular impuestos contemplando descuentos de cliente y de vendedor
    '    sQuery = New System.Text.StringBuilder
    '    sQuery.Append("SELECT TransProdID, TransProdDetalleID FROM TransProdDetalle WHERE TransProdId = '" & oTransProd.TransProdId & "'")
    '    oDt = oDBVen.RealizarConsultaSQL(sQuery.ToString, "TransProdDetalle")

    '    For Each oDrTPD As DataRow In oDt.Rows
    '        For i As Integer = 0 To oArrImpClave.Count - 1
    '            Dim dtImp As DataTable = oDBVen.RealizarConsultaSQL("SELECT ImpuestoImp, TPDImpuestoId FROM TPDImpuesto WHERE TransProdId ='" & oDrTPD("TransProdID") & "' AND TransProdDetalleId='" & oDrTPD("TransProdDetalleId") & "' AND ImpuestoClave='" & oArrImpClave(i) & "'", "TPDImpuesto")
    '            Dim sTPDImpuestoId As String = ""
    '            Dim dTotImp As Double = 0

    '            If dtImp.Rows.Count > 0 Then
    '                sTPDImpuestoId = dtImp.Rows(0)("TPDImpuestoId")
    '                dTotImp = dtImp.Rows(0)("ImpuestoImp")
    '            End If

    '            Dim dImpActual As Double = dTotImp
    '            'Dim dImpPU As Double

    '            'Descuentos del cliente
    '            If dTotImp > 0 Then
    '                If (oArrImpTipoValor(i) = 1) Then
    '                    For j As Integer = 0 To oArrDescuentos.Count - 1
    '                        If CType(oArrDescuentos(j), DataRow)("TipoCascada") Then
    '                            dImpActual -= RedondeoAritmetico(dImpActual * CType(oArrDescuentos(j), DataRow)("DesPor") / 100, 2)
    '                        Else
    '                            dImpActual -= RedondeoAritmetico(dTotImp * CType(oArrDescuentos(j), DataRow)("DesPor") / 100, 2)
    '                        End If
    '                    Next

    '                    'Descuento del vendedor
    '                    dImpActual -= RedondeoAritmetico(dImpActual * oTransProd.DescVendPor / 100, 2)
    '                End If

    '                'Actualizar TPDImpuesto.ImpDesGlb con el valor dImpActual
    '                Me.ActualizaImpDesGlb(oDrTPD("TransProdID"), oDrTPD("TransProdDetalleID"), sTPDImpuestoId, RedondeoAritmetico(dImpActual, 2))
    '                'oArrImpCant(i) += dImpActual
    '            End If
    '        Next
    '    Next
    'End Sub

    Function FiltroFecha(ByVal sCampoFecha As String, ByVal dFechaInicial As DateTime, ByVal dFechaFinal As DateTime, ByVal iTipoFiltro As Integer) As String
        Dim sCond As String = ""
        Select Case iTipoFiltro
            Case 1 '=
                sCond = " convert(datetime,Convert(varchar(20)," & sCampoFecha & ",112)) = '" & dFechaInicial.Date.ToString("s") & "' "
            Case 2 '<>
                sCond = " convert(datetime,Convert(varchar(20)," & sCampoFecha & ",112)) <> '" & dFechaInicial.Date.ToString("s") & "' "
            Case 3 '>
                sCond = " convert(datetime,Convert(varchar(20)," & sCampoFecha & ",112)) > '" & dFechaInicial.Date.ToString("s") & "' "
            Case 4 '<
                sCond = " convert(datetime,Convert(varchar(20)," & sCampoFecha & ",112)) < '" & dFechaInicial.Date.ToString("s") & "' "
            Case 5 '>=
                sCond = " convert(datetime,Convert(varchar(20)," & sCampoFecha & ",112)) >= '" & dFechaInicial.Date.ToString("s") & "' "
            Case 6 '<=
                sCond = " convert(datetime,Convert(varchar(20)," & sCampoFecha & ",112)) <= '" & dFechaInicial.Date.ToString("s") & "' "
            Case 7 '/                
                sCond = " convert(datetime,Convert(varchar(20)," & sCampoFecha & ",112)) between '" & dFechaInicial.Date.ToString("s") & "' and '" & dFechaFinal.Date.ToString("s") & "' "
        End Select
        Return sCond
    End Function

#Region "GenerarXML"
    Enum TipoDato
        Cadena = 1
        Numerico = 2
        Fecha = 3
    End Enum

    Private Function PrimeraHora(ByVal parFecha As Date) As Date
        Dim f1 As New Date(parFecha.Year, parFecha.Month, parFecha.Day, 0, 0, 0)
        Return f1
    End Function

    Private Function UltimaHora(ByVal parFecha As Date) As Date
        Dim f2 As New Date(parFecha.Year, parFecha.Month, parFecha.Day, 23, 59, 59)
        Return f2
    End Function

    Public Function Operador(ByVal VAVClave As Integer, ByVal ValorIni As Object, ByVal ValorFin As Object, ByVal parTipoDato As TipoDato) As String
        Select Case VAVClave
            Case 1 'Igual
                Select Case parTipoDato
                    Case TipoDato.Fecha
                        Return " between " & Tabla.Conexion.UniFechaSQL(PrimeraHora(ValorIni)) & " AND " & Tabla.Conexion.UniFechaSQL(UltimaHora(ValorIni))
                    Case TipoDato.Numerico
                        Return " = " & ValorIni
                    Case TipoDato.Cadena
                        Return " = '" & ValorIni & "'"
                End Select
            Case 2 'Diferente
                Select Case parTipoDato
                    Case TipoDato.Fecha
                        Return " not between " & Tabla.Conexion.UniFechaSQL(PrimeraHora(ValorIni)) & " AND " & Tabla.Conexion.UniFechaSQL(UltimaHora(ValorIni))
                    Case TipoDato.Numerico
                        Return " <> " & ValorIni
                    Case TipoDato.Cadena
                        Return " <> '" & ValorIni & "'"
                End Select
            Case 3
                Select Case parTipoDato
                    Case TipoDato.Fecha 'Mayor que
                        Return " > " & Tabla.Conexion.UniFechaSQL(UltimaHora(ValorIni))
                    Case TipoDato.Numerico 'Mayor que
                        Return " > " & ValorIni
                    Case TipoDato.Cadena  'Empiece con
                        Return " like '" & ValorIni & "%'"
                End Select
            Case 4
                Select Case parTipoDato
                    Case TipoDato.Fecha 'Menor que
                        Return " < " & Tabla.Conexion.UniFechaSQL(PrimeraHora(ValorIni))
                    Case TipoDato.Numerico 'Menor que
                        Return " < " & ValorIni
                    Case TipoDato.Cadena 'Termine con
                        Return " like '%" & ValorIni & "'"
                End Select
            Case 5
                Select Case parTipoDato
                    Case TipoDato.Fecha 'Mayor igual que
                        Return " >= " & Tabla.Conexion.UniFechaSQL(PrimeraHora(ValorIni))
                    Case TipoDato.Numerico 'Mayor igual que
                        Return " >= " & ValorIni
                    Case TipoDato.Cadena 'Contenga
                        Return " like '%" & ValorIni & "%'"
                End Select
            Case 6
                Select Case parTipoDato
                    Case TipoDato.Fecha 'Menor igual que
                        Return " <= " & Tabla.Conexion.UniFechaSQL(UltimaHora(ValorIni))
                    Case TipoDato.Numerico 'Menor igual que
                        Return " <= " & ValorIni
                    Case TipoDato.Cadena 'No contenga
                        Return " not like '%" & ValorIni & "%'"
                End Select
            Case 7 'Entre
                Select Case parTipoDato
                    Case TipoDato.Fecha
                        Return " between " & Tabla.Conexion.UniFechaSQL(PrimeraHora(ValorIni)) & " and " & Tabla.Conexion.UniFechaSQL(UltimaHora(ValorFin))
                    Case TipoDato.Numerico
                        Return " between " & ValorIni & " and " & ValorFin
                End Select
        End Select
        Return String.Empty

    End Function

    Public Function obtenerFacturasElectronicas(ByVal pvFiltro As String) As DataTable
        Dim sConsulta As String

        sConsulta = "SELECT TRP.TransProdID FROM TransProd AS TRP " & _
        "INNER JOIN TRPDatoFiscal AS TDF ON TRP.TransProdID = TDF.TransProdID " & _
        "where ((Tipo = 8 or Tipo = 10) And TipoFase <> 0) and (tipomotivo not in (10 , 11) or tipomotivo is null) " & pvFiltro & " "

        Return Me.Tabla.Conexion.EjecutarConsulta(sConsulta)
    End Function

    Public Function obtenerDirDocXML(ByVal parsSubempresaid As String) As String
        Dim vlConsulta As String = "Select top 1 DirDocXML from SemHist where SubEmpresaID= '" + parsSubempresaid + "' order by mfechahora desc"
        Dim vlDT As DataTable = Tabla.Conexion.EjecutarConsulta(vlConsulta)
        If vlDT Is Nothing OrElse vlDT.Rows.Count <= 0 OrElse vlDT.Rows(0).Item(0).ToString = "" Then Return "C:"

        Return vlDT.Rows(0).Item(0).ToString
    End Function
    Public Function ObtenerDescuentosFactura(ByVal Facturaid As String, ByVal ClienteClave As String, ByVal Fecha As DateTime, ByVal ImpuestoGlb As Boolean) As Double

        Dim vlConsulta As New Text.StringBuilder
        If ImpuestoGlb Then
            vlConsulta.AppendLine("set nocount on ")
            vlConsulta.AppendLine("if (select object_id('tempdb..#ImpNoDes')) is not null drop table #ImpNoDes ")
            vlConsulta.AppendLine("select * into #ImpNoDes from ( ")
            vlConsulta.AppendLine("select TDI.TransProdID, TDI.TransProdDetalleID, SUM((TPD.Cantidad * TDI.ImpuestoPU) - TDI.ImpDesGlb) as Impuesto ")
            vlConsulta.AppendLine("from TPDImpuesto TDI ")
            vlConsulta.AppendLine("inner join TransProdDetalle TPD on TDI.TransProdId = TPD.TransProdId and TDI.TransProdDetalleId = TPD.TransProdDetalleId ")
            vlConsulta.AppendLine("inner join TransProd TRP on TDI.TransProdID = TRP.TransProdID ")
            vlConsulta.AppendLine("where TRP.FacturaId = '" & FacturaID & "' and TRP.Tipo = 1 and TDI.ImpuestoClave in ( ")
            vlConsulta.AppendLine("select ImpuestoClave ")
            vlConsulta.AppendLine("from CLINoDesImp ")
            vlConsulta.AppendLine("where ClienteClave = '" & ClienteClave & "' and '" & Fecha.ToString("s") & "' between FechaInicio and FechaFin) ")
            vlConsulta.AppendLine("group by TDI.TransProdID, TDI.TransProdDetalleID ")
            vlConsulta.AppendLine(")as t ")

            vlConsulta.AppendLine("select case when sum(Descuento) < 0 then 0 else sum(Descuento) end as Descuento ")
            vlConsulta.AppendLine("from( ")
            'vlConsulta.AppendLine("select TRP.DescuentoImp + TRP.DescuentoVendedor ")
            vlConsulta.AppendLine("select isnull((select sum(DesImporte) from TpdDes DES where DES.TransProdId = TPD.TransProdId), 0) ")
            vlConsulta.AppendLine("+ isnull((select sum(DESV.DesImporte) from TpdDesVendedor DESV where DESV.TransProdId = TPD.TransProdId), 0) ")
            vlConsulta.AppendLine("+ sum(TPD.DescuentoImp) + sum(isnull(IND.Impuesto, 0)) as Descuento ")
            vlConsulta.AppendLine("from TransProd TRP ")
            vlConsulta.AppendLine("inner join TransProdDetalle TPD on TRP.TransProdId = TPD.TransProdId ")
            vlConsulta.AppendLine("left join #ImpNoDes IND on TPD.TransProdID = IND.TransProdId and TPD.TransProdDetalleID = IND.TransProdDetalleId ")
            vlConsulta.AppendLine("where TRP.Tipo = 1 and TRP.FacturaID = '" & FacturaID & "' ")
            vlConsulta.AppendLine("group by TPD.TransProdID, TRP.DescuentoImp, TRP.DescuentoVendedor ")
            vlConsulta.AppendLine(") as t ")

            vlConsulta.AppendLine("drop table #ImpNoDes ")
            vlConsulta.AppendLine("set nocount off ")
        Else
            vlConsulta.AppendLine("select case when sum(Descuento) < 0 then 0 else sum(Descuento) end as Descuento ")
            vlConsulta.AppendLine("from( ")
            'vlConsulta.AppendLine("select TRP.DescuentoImp + TRP.DescuentoVendedor 
            vlConsulta.AppendLine("select isnull((select sum(DesImporte) from TpdDes DES where DES.TransProdId = TPD.TransProdId), 0) ")
            vlConsulta.AppendLine("+ isnull((select sum(DESV.DesImporte) from TpdDesVendedor DESV where DESV.TransProdId = TPD.TransProdId), 0) ")
            vlConsulta.AppendLine("+ sum(TPD.DescuentoImp) as Descuento ")
            vlConsulta.AppendLine("from TransProd TRP ")
            vlConsulta.AppendLine("inner join TransProdDetalle TPD on TRP.TransProdId = TPD.TransProdId ")
            vlConsulta.AppendLine("where TRP.Tipo = 1 and TRP.FacturaID = '" & FacturaID & "' ")
            vlConsulta.AppendLine("group by TPD.TransProdID, TRP.DescuentoImp, TRP.DescuentoVendedor ")
            vlConsulta.AppendLine(") as t ")
        End If

        Dim vlDT As DataTable = LbConexion.cConexion.Instancia.EjecutarConsulta(vlConsulta.ToString)
        If vlDT Is Nothing OrElse vlDT.Rows.Count = 0 Then Return 0
        If IsDBNull(vlDT.Rows(0).Item("descuento")) Then Return 0

        Return vlDT.Rows(0).Item("descuento")

    End Function

    Public Function ObtenerDescuentosNotaCredito(ByVal pvTransProdId As String, ByVal ClienteClave As String, ByVal FechaFactura As DateTime, ByVal ImpuestoGlb As Boolean) As Double
        Dim vlConsulta As New Text.StringBuilder
        If ImpuestoGlb Then
            vlConsulta.AppendLine("set nocount on ")
            vlConsulta.AppendLine("if (select object_id('tempdb..#TmpImp')) is not null drop table #TmpImp ")
            vlConsulta.AppendLine("set nocount on ")
            vlConsulta.AppendLine("select * into #TmpImp from ( ")
            vlConsulta.AppendLine("select SUM((TPD.Cantidad * TDI.ImpuestoPU) - TDI.ImpDesGlb) as Impuesto ")
            vlConsulta.AppendLine("from TPDImpuesto TDI ")
            vlConsulta.AppendLine("inner join TransProdDetalle TPD on TDI.TransProdID = TPD.TransProdID and TDI.TransProdDetalleID = TPD.TransProdDetalleID ")
            vlConsulta.AppendLine("inner join TransProd TRP on TDI.TransProdID = TRP.TransProdID ")
            vlConsulta.AppendLine("where TRP.TransProdID = '" & pvTransProdId & "' and TRP.Tipo = 10 and TDI.ImpuestoClave in ( ")
            vlConsulta.AppendLine("select ImpuestoClave ")
            vlConsulta.AppendLine("from CLINoDesImp ")
            vlConsulta.AppendLine("where ClienteClave = '" & ClienteClave & "' and '" & FechaFactura.ToString("s") & "' between FechaInicio and FechaFin) ")
            vlConsulta.AppendLine(") as t ")

            vlConsulta.AppendLine("select DescuentoImp + (select isnull(Impuesto, 0) from #TmpImp) as Descuento ")
            vlConsulta.AppendLine("from TransProd ")
            vlConsulta.AppendLine("where TransProdID = '" & pvTransProdId & "' ")

            vlConsulta.AppendLine("drop table #TmpImp ")
            vlConsulta.AppendLine("set nocount off ")
        Else
            vlConsulta.AppendLine("select DescuentoImp as Descuento from TransProd where TransProdID = '" & pvTransProdId & "' ")
        End If

        Dim vlDT As DataTable = LbConexion.cConexion.Instancia.EjecutarConsulta(vlConsulta.ToString)
        If vlDT Is Nothing OrElse vlDT.Rows.Count = 0 Then Return 0
        If IsDBNull(vlDT.Rows(0).Item("descuento")) Then Return 0

        Return vlDT.Rows(0).Item("descuento")
    End Function

    Private Function ObtenerXMLWriter(ByVal vlXML As cXML, ByVal pvEnMemoria As Boolean, ByVal pvTransProd As cTransProd, ByVal pvRuta As String) As Long
        Dim writer As XmlTextWriter = Nothing
        Dim enmemoria As MemoryStream = Nothing
        Dim lnLength As Long

        Try
            If pvEnMemoria Then
                enmemoria = New MemoryStream
                writer = New XmlTextWriter(enmemoria, System.Text.Encoding.UTF8)
            Else
                Try
                    writer = New XmlTextWriter(vlXML.Archivo, System.Text.Encoding.UTF8)

                Catch ex As Exception
                    Throw New LbControlError.cError("E0690", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(pvRuta)})
                End Try
            End If

            writer.Formatting = Formatting.None

            'Agrega encabezado <?xml version="1.0" encoding="utf-8"?>
            writer.WriteStartDocument()
            'COMPROBANTE
            writer.WriteStartElement("Comprobante")

            Dim dtTransprod As New DataTable
            dtTransprod = LbConexion.cConexion.Instancia.EjecutarConsulta("select * from TRPDatoFiscal trp inner join transprod TRA on TRA.transprodid=TRP.transprodid where trp.transprodid='" & pvTransProd.TransProdID & "'")

            Dim fecha As DateTime = CType(dtTransprod.Rows(0)("FechaHoraAlta"), Date)

            If Not dtTransprod.Rows(0)!CadenaOriginal Is DBNull.Value Then
                Dim cadena As String() = dtTransprod.Rows(0)!CadenaOriginal.ToString().Split(New Char() {"|"})
                Dim fechaCadena As String = cadena(5)
                Dim fechaCadenaDate As DateTime
                If DateTime.TryParse(fechaCadena, fechaCadenaDate) Then
                    fecha = fechaCadenaDate
                End If
            End If

            'Fecha para validar si en la factura se desglosaron impuestos
            Dim dFechaFactura As Date
            If pvTransProd.Tipo = 10 Then
                Dim dtFact As New DataTable
                dtFact = LbConexion.cConexion.Instancia.EjecutarConsulta("select * from TRPDatoFiscal trp inner join transprod TRA on TRA.transprodid=TRP.transprodid where trp.transprodid='" & pvTransProd.FacturaID & "'")
                If dtFact.Rows.Count > 0 Then
                    dFechaFactura = CType(dtFact.Rows(0)("FechaHoraAlta"), Date)

                    If Not dtFact.Rows(0)!CadenaOriginal Is DBNull.Value Then
                        Dim cadena As String() = dtFact.Rows(0)!CadenaOriginal.ToString().Split(New Char() {"|"})
                        Dim fechaCadena As String = cadena(5)
                        Dim fechaCadenaDate As DateTime
                        If DateTime.TryParse(fechaCadena, fechaCadenaDate) Then
                            dFechaFactura = fechaCadenaDate
                        End If
                    End If
                Else
                    dFechaFactura = fecha
                End If
            Else
                dFechaFactura = fecha
            End If


            NuevoAtributo("xmlns", "http://www.sat.gob.mx/cfd/2", writer)
            NuevoAtributo("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance", writer)
            If pvTransProd.vgTRPDatoFiscal.TipoVersion = "2.0" Then
                NuevoAtributo("xsi:schemaLocation", "http://www.sat.gob.mx/cfd/2 http://www.sat.gob.mx/sitio_internet/cfd/2/cfdv2.xsd", writer)
            Else
                NuevoAtributo("xsi:schemaLocation", "http://www.sat.gob.mx/cfd/2 http://www.sat.gob.mx/sitio_internet/cfd/2/cfdv22.xsd", writer)
            End If

            NuevoAtributo("version", dtTransprod.Rows(0)("TipoVersion"), writer)
            NuevoAtributo("serie", dtTransprod.Rows(0)("Serie"), writer)
            NuevoAtributo("folio", dtTransprod.Rows(0)("Folio").ToString.Substring(dtTransprod.Rows(0)("Serie").ToString.Length), writer)
            NuevoAtributo("fecha", fecha.ToString("s"), writer)
            NuevoAtributo("sello", dtTransprod.Rows(0)("SelloDigital"), writer)
            NuevoAtributo("noAprobacion", dtTransprod.Rows(0)("Aprobacion"), writer)
            NuevoAtributo("anoAprobacion", dtTransprod.Rows(0)("AnioAprobacion"), writer)
            NuevoAtributo("formaDePago", dtTransprod.Rows(0)("FormaDePago"), writer)
            NuevoAtributo("noCertificado ", dtTransprod.Rows(0)("NumCertificado"), writer)
            NuevoAtributo("certificado", IIf(IsDBNull(dtTransprod.Rows(0)("CerBase64")), "", dtTransprod.Rows(0)("CerBase64")), writer)


            Dim vlConsulta As New Text.StringBuilder

            Dim bImpuestoGlb As Boolean = False
            If pvTransProd.Tipo = 8 Then
                vlConsulta.AppendLine("select isnull(sum(case when TDI.ImpuestoPU is null or TDI.ImpDesGlb is null then 1 else 0 end), 0) as Nulos ")
                vlConsulta.AppendLine("from TransProd TRP ")
                vlConsulta.AppendLine("inner join TPDImpuesto TDI on TRP.TransProdID = TDI.TransProdID ")
                vlConsulta.AppendLine("where TRP.FacturaID = '" & Me.TransProdID & "' and TRP.Tipo = 1 ")
                bImpuestoGlb = (LbConexion.cConexion.Instancia.EjecutarComandoScalar(vlConsulta.ToString) = 0)
            Else
                vlConsulta.AppendLine("select isnull(sum(case when TDI.ImpuestoPU is null or TDI.ImpDesGlb is null then 1 else 0 end), 0) as Nulos ")
                vlConsulta.AppendLine("from TransProd TRP ")
                vlConsulta.AppendLine("inner join TPDImpuesto TDI on TRP.TransProdID = TDI.TransProdID ")
                vlConsulta.AppendLine("where TRP.FacturaID = '" & Me.TransProdID & "' and TRP.Tipo = 1 ")
                bImpuestoGlb = (LbConexion.cConexion.Instancia.EjecutarComandoScalar(vlConsulta.ToString) = 0)
            End If

            Dim sClienteClave As String
            vlConsulta = New Text.StringBuilder
            vlConsulta.AppendLine("select VIS.ClienteClave ")
            vlConsulta.AppendLine("from TransProd FAC ")
            vlConsulta.AppendLine("inner join Visita VIS on FAC.VisitaClave = VIS.VisitaClave and FAC.DiaClave = VIS.DiaClave ")
            vlConsulta.AppendLine("where FAC.TransProdID = '" & Me.TransProdID & "'")
            sClienteClave = LbConexion.cConexion.Instancia.EjecutarComandoScalar(vlConsulta.ToString)

            Dim dtTransprodDetalle As New DataTable
            vlConsulta = New Text.StringBuilder
            Dim bImpGlbOriginal As Boolean = bImpuestoGlb
            If pvTransProd.Tipo = 10 AndAlso dtTransprod.Rows(0)("TipoNotaCredito") = 1 Then bImpuestoGlb = False

            If bImpuestoGlb Then
                vlConsulta.AppendLine("set nocount on ")
                vlConsulta.AppendLine("if (select object_id('tempdb..#ImpNoDes')) is not null drop table #ImpNoDes ")
                vlConsulta.AppendLine("select * into #ImpNoDes from ( ")
                vlConsulta.AppendLine("select TDI.TransProdID, TDI.TransProdDetalleID, SUM(TDI.ImpuestoPU) as Impuesto ")
                vlConsulta.AppendLine("from TPDImpuesto TDI ")
                vlConsulta.AppendLine("inner join TransProd TRP on TDI.TransProdID = TRP.TransProdID ")
                If pvTransProd.Tipo = 8 Then
                    vlConsulta.AppendLine("where TRP.FacturaId = '" & Me.TransProdID & "' and TRP.Tipo = 1 and TDI.ImpuestoClave in ( ")
                Else
                    vlConsulta.AppendLine("where TRP.TransProdId = '" & Me.TransProdID & "' and TRP.Tipo = 10 and TDI.ImpuestoClave in ( ")
                End If
                vlConsulta.AppendLine("select ImpuestoClave ")
                vlConsulta.AppendLine("from CLINoDesImp ")
                vlConsulta.AppendLine("where ClienteClave = '" & sClienteClave & "' and '" & dFechaFactura.ToString("s") & "' between FechaInicio and FechaFin) ")
                vlConsulta.AppendLine("group by TDI.TransProdID, TDI.TransProdDetalleID ")
                vlConsulta.AppendLine(") as t ")
            End If

            vlConsulta.AppendLine("select sum(TPD.Cantidad) as Cantidad, ")
            vlConsulta.AppendLine("(select Descripcion from VAVDescripcion where VARCodigo = 'UNIDADV' and VAVClave = TPD.TipoUnidad and VADTipoLenguaje = dbo.FNObtenerLenguaje()) as Unidad, ")
            vlConsulta.AppendLine("TPD.ProductoClave, PRO.NombreLargo as Descripcion, ")
            If bImpuestoGlb Then
                vlConsulta.AppendLine("Precio + isnull(IND.Impuesto,0) as ValorUnitario1, Precio + isnull(IND.Impuesto,0) as Precio ")
            Else
                vlConsulta.AppendLine("Precio as ValorUnitario1, Precio as Precio ")
            End If
            vlConsulta.AppendLine("from TransProd TRP ")
            vlConsulta.AppendLine("inner join TransProdDetalle TPD on TRP.TransProdId = TPD.TransProdId ")
            If bImpuestoGlb Then
                vlConsulta.AppendLine("left join #ImpNoDes IND on TPD.TransProdID = IND.TransProdId and TPD.TransProdDetalleID = IND.TransProdDetalleId ")
            End If
            vlConsulta.AppendLine("inner join Producto PRO on PRO.ProductoClave = TPD.ProductoClave ")
            If pvTransProd.Tipo = 8 Then
                vlConsulta.AppendLine("where TRP.Tipo=1 and TRP.FacturaId ='" & Me.TransProdID & "' ")
            Else
                vlConsulta.AppendLine("where TRP.Tipo=10 and TRP.TransProdId ='" & Me.TransProdID & "' ")
            End If
            If bImpuestoGlb Then
                vlConsulta.AppendLine("group by TPD.ProductoClave, TPD.TipoUnidad, TPD.Precio + isnull(IND.Impuesto,0), PRO.NombreLargo ")
                vlConsulta.AppendLine("order by TPD.ProductoClave, TPD.TipoUnidad, TPD.Precio + isnull(IND.Impuesto,0) ")
            Else
                vlConsulta.AppendLine("group by TPD.ProductoClave, TPD.TipoUnidad, TPD.Precio, PRO.NombreLargo ")
                vlConsulta.AppendLine("order by TPD.ProductoClave, TPD.TipoUnidad, TPD.Precio ")
            End If

            If bImpuestoGlb Then
                vlConsulta.AppendLine("drop table #ImpNoDes ")
                vlConsulta.AppendLine("set nocount off ")
            End If

            dtTransprodDetalle = LbConexion.cConexion.Instancia.EjecutarConsulta(vlConsulta.ToString)

            Dim vlSubTotal As Double
            For i As Integer = 0 To dtTransprodDetalle.Rows.Count - 1
                vlSubTotal += (dtTransprodDetalle.Rows(i)("Precio") * dtTransprodDetalle.Rows(i)("Cantidad"))
            Next
            NuevoAtributo("subTotal", dValido(vlSubTotal, True), writer)

            vlConsulta = New Text.StringBuilder
            vlConsulta.AppendLine("select ImpuestoClave ")
            vlConsulta.AppendLine("from CLINoDesImp ")
            vlConsulta.AppendLine("where ClienteClave = '" & sClienteClave & "' and '" & dFechaFactura.ToString("s") & "' between FechaInicio and FechaFin ")
            Dim dtImpNoDes As DataTable = LbConexion.cConexion.Instancia.EjecutarConsulta(vlConsulta.ToString)

            If pvTransProd.Tipo = 8 Then
                NuevoAtributo("descuento", dValido(ObtenerDescuentosFactura(pvTransProd.TransProdID, sClienteClave, dFechaFactura, bImpuestoGlb), True), writer)
            Else
                If (dtTransprod.Rows(0)("TipoNotaCredito") = 2) Then
                    NuevoAtributo("descuento", dValido(ObtenerDescuentosNotaCredito(pvTransProd.TransProdID, sClienteClave, dFechaFactura, bImpuestoGlb), True), writer)
                Else
                    NuevoAtributo("descuento", dValido(0, True), writer)
                End If
            End If


            If pvTransProd.vgTRPDatoFiscal.TipoVersion = "2.2" Then
                If pvTransProd.MonedaID <> "" Then
                    'Moneda y tipo cambio
                    Dim iTipoCodigo As Integer = LbConexion.cConexion.Instancia.EjecutarComandoScalar("Select TipoCodigo from moneda where MonedaID='" + pvTransProd.MonedaID + "' ")
                    NuevoAtributo("TipoCambio", dValido(pvTransProd.TipoCambio, True), writer)
                    NuevoAtributo("Moneda", lbGeneral.ClaveDescripcionVARValor("CDGOMON", iTipoCodigo), writer)
                End If
            End If


            NuevoAtributo("total", dValido(dtTransprod.Rows(0)("Total"), True), writer)
            If pvTransProd.Tipo = 8 Then
                NuevoAtributo("tipoDeComprobante", "ingreso", writer)
            Else
                NuevoAtributo("tipoDeComprobante", "egreso", writer)
            End If

            If pvTransProd.vgTRPDatoFiscal.TipoVersion = "2.2" Then
                Dim sMetodoPago As String = String.Empty
                Dim sNumCtaPago As String = String.Empty

                If Not IsNothing(dtTransprod.Rows(0)("MetodoPago")) AndAlso Not IsDBNull(dtTransprod.Rows(0)("MetodoPago")) AndAlso dtTransprod.Rows(0)("MetodoPago").ToString().Length > 0 Then
                    Dim Metodos As String() = dtTransprod.Rows(0)("MetodoPago").ToString().Split(",")
                    Dim Bancos As String()
                    If Not IsNothing(dtTransprod.Rows(0)("Banco")) AndAlso Not IsDBNull(dtTransprod.Rows(0)("Banco")) AndAlso dtTransprod.Rows(0)("Banco").ToString().Length > 0 Then
                        Bancos = dtTransprod.Rows(0)("Banco").ToString().Split(",")
                    End If
                    Dim Cuentas As String()
                    If Not IsNothing(dtTransprod.Rows(0)("NumCtaPago")) AndAlso Not IsDBNull(dtTransprod.Rows(0)("NumCtaPago")) AndAlso dtTransprod.Rows(0)("NumCtaPago").ToString().Length > 0 Then
                        Cuentas = dtTransprod.Rows(0)("NumCtaPago").ToString().Split(",")
                    End If

                    Dim aMetodos As New ArrayList
                    Dim sBanco As String = String.Empty
                    Dim sCuenta As String = String.Empty
                    Dim indice As Integer = 0

                    For Each sMetodo As String In Metodos
                        sBanco = String.Empty
                        sCuenta = String.Empty
                        If (Not IsNothing(Bancos) AndAlso indice < Bancos.Length) Then
                            sBanco = Bancos(indice)
                        End If
                        If (Not IsNothing(Cuentas) AndAlso indice < Cuentas.Length) Then
                            sCuenta = Cuentas(indice)
                        End If
                        If sBanco.Length > 0 And sBanco <> "*" Then
                            sMetodoPago += sMetodo + " " + sBanco + ","
                        Else
                            sMetodoPago += sMetodo + ","
                        End If

                        If sCuenta.Length > 0 And sCuenta <> "*" Then
                            sNumCtaPago += sCuenta + ","
                        End If
                        indice += 1
                    Next
                End If

                If sMetodoPago.Length > 0 Then
                    sMetodoPago = sMetodoPago.Substring(0, sMetodoPago.Length - 1)
                End If
                If sNumCtaPago.Length > 0 Then
                    sNumCtaPago = sNumCtaPago.Substring(0, sNumCtaPago.Length - 1)
                End If

                NuevoAtributo("metodoDePago", sMetodoPago, writer)
                NuevoAtributo("LugarExpedicion", IIf(IsDBNull(dtTransprod.Rows(0)("LugarExpedicion")), "", dtTransprod.Rows(0)("LugarExpedicion")), writer)
                If sNumCtaPago.Length > 0 Then
                    NuevoAtributo("NumCtaPago", sNumCtaPago, writer)
                End If
            End If

            'EMISOR
            writer.WriteStartElement("Emisor")
            If (Not IsDBNull(dtTransprod.Rows(0)("NombreEm"))) Then
                NuevoAtributo("nombre", dtTransprod.Rows(0)("NombreEm"), writer)
            End If

            NuevoAtributo("rfc", dtTransprod.Rows(0)("RFCEm"), writer)

            If (Not IsDBNull(dtTransprod.Rows(0)("CalleEm")) OrElse Not IsDBNull(dtTransprod.Rows(0)("NumExtEm")) OrElse Not IsDBNull(dtTransprod.Rows(0)("NumIntEm")) _
                OrElse Not IsDBNull(dtTransprod.Rows(0)("ColoniaEm")) OrElse Not IsDBNull(dtTransprod.Rows(0)("LocalidadEm")) OrElse Not IsDBNull(dtTransprod.Rows(0)("ReferenciaDomEm")) _
                OrElse Not IsDBNull(dtTransprod.Rows(0)("MunicipioEm")) OrElse Not IsDBNull(dtTransprod.Rows(0)("RegionEm")) OrElse Not IsDBNull(dtTransprod.Rows(0)("PaisEm")) OrElse Not IsDBNull(dtTransprod.Rows(0)("CodigoPostalEm"))) Then
                'Domicilio fiscal
                writer.WriteStartElement("DomicilioFiscal")
                NuevoAtributo("calle", dtTransprod.Rows(0)("CalleEm"), writer)
                NuevoAtributo("noExterior", IIf(IsDBNull(dtTransprod.Rows(0)("NumExtEm")), "", dtTransprod.Rows(0)("NumExtEm")), writer)
                NuevoAtributo("noInterior", IIf(IsDBNull(dtTransprod.Rows(0)("NumIntEm")), "", dtTransprod.Rows(0)("NumIntEm")), writer)
                NuevoAtributo("colonia", IIf(IsDBNull(dtTransprod.Rows(0)("ColoniaEm")), "", dtTransprod.Rows(0)("ColoniaEm")), writer)
                NuevoAtributo("localidad", IIf(IsDBNull(dtTransprod.Rows(0)("LocalidadEm")), "", dtTransprod.Rows(0)("LocalidadEm")), writer)
                NuevoAtributo("referencia", IIf(IsDBNull(dtTransprod.Rows(0)("ReferenciaDomEm")), "", dtTransprod.Rows(0)("ReferenciaDomEm")), writer)
                NuevoAtributo("municipio", IIf(IsDBNull(dtTransprod.Rows(0)("MunicipioEm")), "", dtTransprod.Rows(0)("MunicipioEm")), writer)
                NuevoAtributo("estado", IIf(IsDBNull(dtTransprod.Rows(0)("RegionEm")), "", dtTransprod.Rows(0)("RegionEm")), writer)
                NuevoAtributo("pais", dtTransprod.Rows(0)("PaisEm"), writer)
                NuevoAtributo("codigoPostal", IIf(IsDBNull(dtTransprod.Rows(0)("CodigoPostalEm")), "", dtTransprod.Rows(0)("CodigoPostalEm")), writer)
                writer.WriteEndElement()
            End If



            If (Not IsDBNull(dtTransprod.Rows(0)("CalleEx")) OrElse Not IsDBNull(dtTransprod.Rows(0)("NumExtEx")) OrElse Not IsDBNull(dtTransprod.Rows(0)("NumIntEx")) _
                OrElse Not IsDBNull(dtTransprod.Rows(0)("ColoniaEx")) OrElse Not IsDBNull(dtTransprod.Rows(0)("LocalidadEx")) OrElse Not IsDBNull(dtTransprod.Rows(0)("ReferenciaDomEx")) _
                OrElse Not IsDBNull(dtTransprod.Rows(0)("MunicipioEx")) OrElse Not IsDBNull(dtTransprod.Rows(0)("EntidadEx")) OrElse Not IsDBNull(dtTransprod.Rows(0)("PaisEx")) OrElse Not IsDBNull(dtTransprod.Rows(0)("CodigoPostalEx"))) Then

                'Expedido en
                writer.WriteStartElement("ExpedidoEn")
                NuevoAtributo("calle", dtTransprod.Rows(0)("CalleEx"), writer)
                NuevoAtributo("noExterior", IIf(IsDBNull(dtTransprod.Rows(0)("NumExtEx")), "", dtTransprod.Rows(0)("NumExtEx")), writer)
                NuevoAtributo("noInterior", IIf(IsDBNull(dtTransprod.Rows(0)("NumIntEx")), "", dtTransprod.Rows(0)("NumIntEx")), writer)
                NuevoAtributo("colonia", IIf(IsDBNull(dtTransprod.Rows(0)("ColoniaEx")), "", dtTransprod.Rows(0)("ColoniaEx")), writer)
                NuevoAtributo("localidad", IIf(IsDBNull(dtTransprod.Rows(0)("LocalidadEx")), "", dtTransprod.Rows(0)("LocalidadEx")), writer)
                NuevoAtributo("referencia", IIf(IsDBNull(dtTransprod.Rows(0)("ReferenciaDomEx")), "", dtTransprod.Rows(0)("ReferenciaDomEx")), writer)
                NuevoAtributo("municipio", IIf(IsDBNull(dtTransprod.Rows(0)("MunicipioEx")), "", dtTransprod.Rows(0)("MunicipioEx")), writer)
                NuevoAtributo("estado", IIf(IsDBNull(dtTransprod.Rows(0)("EntidadEx")), "", dtTransprod.Rows(0)("EntidadEx")), writer)
                NuevoAtributo("pais", dtTransprod.Rows(0)("PaisEx"), writer)
                NuevoAtributo("codigoPostal", IIf(IsDBNull(dtTransprod.Rows(0)("CodigoPostalEx")), "", dtTransprod.Rows(0)("CodigoPostalEx")), writer)
                writer.WriteEndElement()
            End If
            If pvTransProd.vgTRPDatoFiscal.TipoVersion = "2.2" Then
                vlConsulta = New Text.StringBuilder
                vlConsulta.AppendLine("select Descripcion as Regimen ")
                vlConsulta.AppendLine("from TRPRegimenFiscal ")
                vlConsulta.AppendLine("where TransProdId = '" & dtTransprod.Rows(0)("TransProdId") & "' order by Regimen")
                Dim dtRegimen As DataTable = LbConexion.cConexion.Instancia.EjecutarConsulta(vlConsulta.ToString)

                For Each drRegimen As DataRow In dtRegimen.Rows
                    writer.WriteStartElement("RegimenFiscal")
                    NuevoAtributo("Regimen", drRegimen("Regimen"), writer)
                    writer.WriteEndElement()
                Next
            End If

            writer.WriteEndElement()

            'RECEPTOR
            writer.WriteStartElement("Receptor")
            If Not IsDBNull(dtTransprod.Rows(0)("RazonSocial")) Then
                NuevoAtributo("nombre", dtTransprod.Rows(0)("RazonSocial"), writer)
            End If
            NuevoAtributo("rfc", dtTransprod.Rows(0)("RFC"), writer)


            If (Not IsDBNull(dtTransprod.Rows(0)("Calle")) OrElse Not IsDBNull(dtTransprod.Rows(0)("NumExt")) OrElse Not IsDBNull(dtTransprod.Rows(0)("NumInt")) _
            OrElse Not IsDBNull(dtTransprod.Rows(0)("Colonia")) OrElse Not IsDBNull(dtTransprod.Rows(0)("Localidad")) OrElse Not IsDBNull(dtTransprod.Rows(0)("ReferenciaDom")) _
            OrElse Not IsDBNull(dtTransprod.Rows(0)("Municipio")) OrElse Not IsDBNull(dtTransprod.Rows(0)("Entidad")) OrElse Not IsDBNull(dtTransprod.Rows(0)("Pais")) OrElse Not IsDBNull(dtTransprod.Rows(0)("codigoPostal"))) Then
                'domicilio
                writer.WriteStartElement("Domicilio")

                NuevoAtributo("calle", dtTransprod.Rows(0)("Calle"), writer)
                NuevoAtributo("noExterior", IIf(IsDBNull(dtTransprod.Rows(0)("NumExt")), "", dtTransprod.Rows(0)("NumExt")), writer)
                NuevoAtributo("noInterior", IIf(IsDBNull(dtTransprod.Rows(0)("NumInt")), "", dtTransprod.Rows(0)("NumInt")), writer)
                NuevoAtributo("colonia", IIf(IsDBNull(dtTransprod.Rows(0)("Colonia")), "", dtTransprod.Rows(0)("Colonia")), writer)
                NuevoAtributo("localidad", IIf(IsDBNull(dtTransprod.Rows(0)("Localidad")), "", dtTransprod.Rows(0)("Localidad")), writer)
                NuevoAtributo("referencia", IIf(IsDBNull(dtTransprod.Rows(0)("ReferenciaDom")), "", dtTransprod.Rows(0)("ReferenciaDom")), writer)
                NuevoAtributo("municipio", IIf(IsDBNull(dtTransprod.Rows(0)("Municipio")), "", dtTransprod.Rows(0)("Municipio")), writer)
                NuevoAtributo("estado", IIf(IsDBNull(dtTransprod.Rows(0)("Entidad")), "", dtTransprod.Rows(0)("Entidad")), writer)
                NuevoAtributo("pais", IIf(IsDBNull(dtTransprod.Rows(0)("Pais")), "", dtTransprod.Rows(0)("Pais")), writer)
                NuevoAtributo("codigoPostal", dtTransprod.Rows(0)("CodigoPostal"), writer)
                writer.WriteEndElement()
            End If

            writer.WriteEndElement()
            'CONCEPTOS
            writer.WriteStartElement("Conceptos")
            'Concepto
            Dim IP_TransProdID As New ArrayList

            vlConsulta = New Text.StringBuilder
            vlConsulta.AppendLine("select Distinct TRP.TransProdID ")
            vlConsulta.AppendLine("from TransProd TRP ")
            vlConsulta.AppendLine("inner join TransProdDetalle TPD on TRP.TransProdID = TPD.TransProdID ")
            vlConsulta.AppendLine("inner join Producto PRO on TPD.ProductoClave = PRO.ProductoClave ")
            vlConsulta.AppendLine("inner join VAVDescripcion VAD on VAD.VARCodigo = 'UNIDADV' and VAD.VAVClave = TPD.TipoUnidad and VAD.VADTipoLenguaje = dbo.FNObtenerLenguaje() ")
            If pvTransProd.Tipo = 8 Then
                vlConsulta.AppendLine("where TRP.tipo = 1 and TRP.FacturaID = '" & Me.TransProdID & "' order by TRP.transprodid ")
            Else
                vlConsulta.AppendLine("where TRP.tipo = 10 and TRP.TransProdID = '" & Me.TransProdID & "' order by TRP.transprodid ")
            End If
            Dim dtTransprods As New DataTable()
            dtTransprods = LbConexion.cConexion.Instancia.EjecutarConsulta(vlConsulta.ToString)

            For i As Integer = 0 To dtTransprods.Rows.Count - 1
                If Not IP_TransProdID.Contains(dtTransprods.Rows(i)("TransProdID")) Then
                    IP_TransProdID.Add(dtTransprods.Rows(i)("TransProdID"))
                End If
            Next
            Dim dtPedimentos As DataTable
            If pvTransProd.Tipo = 8 Then
                dtPedimentos = LbConexion.cConexion.Instancia.EjecutarConsulta("Select distinct TRPP.ProductoClave, TRPP.NumPedimento, TRPP.Aduana, TRPP.FechaIngreso from TRPPedimento TRPP inner join TransProd TRP on TRPP.TransProdID = TRP.TransProdId where TRP.Tipo = 1 and TRPP.Facturado = 1 and TRP.FacturaID='" & Me.TransProdID & "'")
            End If
            For i As Integer = 0 To dtTransprodDetalle.Rows.Count - 1 'cantidad de detalles
                writer.WriteStartElement("Concepto")
                NuevoAtributo("cantidad", dValido(dtTransprodDetalle.Rows(i)("Cantidad"), True), writer)
                NuevoAtributo("unidad", dtTransprodDetalle.Rows(i)("Unidad"), writer)
                NuevoAtributo("noIdentificacion", dtTransprodDetalle.Rows(i)("ProductoClave"), writer)
                NuevoAtributo("descripcion", dtTransprodDetalle.Rows(i)("descripcion").ToString().Trim(), writer)
                NuevoAtributo("valorUnitario", dValido(dtTransprodDetalle.Rows(i)("Precio"), True), writer)
                NuevoAtributo("importe", dValido(dtTransprodDetalle.Rows(i)("Precio") * dtTransprodDetalle.Rows(i)("Cantidad"), True), writer)
                If (Not IsNothing(dtPedimentos) AndAlso Not IsDBNull(dtPedimentos)) Then
                    For Each dr As DataRow In dtPedimentos.Select("ProductoClave = '" & dtTransprodDetalle.Rows(i)("ProductoClave") & "'")
                        writer.WriteStartElement("InformacionAduanera")
                        NuevoAtributo("fecha", CDate(dr("FechaIngreso")).ToString("yyyy-MM-dd"), writer)
                        NuevoAtributo("aduana", dr("Aduana"), writer)
                        NuevoAtributo("numero", dr("NumPedimento"), writer)
                        writer.WriteEndElement()
                    Next
                End If
                writer.WriteEndElement()
            Next
            writer.WriteEndElement()


            'IMPUESTOS
            writer.WriteStartElement("Impuestos")

            Dim OP_Impuesto As New ArrayList
            Dim OP_Tasa As New ArrayList
            Dim OP_Importe As New ArrayList
            If pvTransProd.Tipo = 8 Then
                ImpuestosConDesc(IP_TransProdID, sClienteClave, dFechaFactura, bImpuestoGlb, OP_Impuesto, OP_Tasa, OP_Importe)
            Else
                ImpuestosConDesc(IP_TransProdID(0).ToString(), sClienteClave, dFechaFactura, bImpGlbOriginal, OP_Impuesto, OP_Tasa, OP_Importe)
            End If

            'Dim sCmd As String
            'sCmd = "select count(*) from TransProd TRP "
            'sCmd &= "inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave and TRP.DiaClave = VIS.DiaClave "
            'sCmd &= "inner join AddendaCliente ADC on VIS.ClienteClave = ADC.ClienteClave "
            'sCmd &= "inner join Addenda ADE on ADC.ADDId = ADE.ADDID "
            'sCmd &= "where TRP.TransProdID = '" & Me.TransProdID & "' and ADE.Tipo in (1,5) and Baja = 0 "

            'If LbConexion.cConexion.Instancia.EjecutarComandoScalar(sCmd) > 0 Then
            Dim ImpuestosTraslado As Double = 0
            For i As Integer = 0 To OP_Impuesto.Count - 1
                ImpuestosTraslado += OP_Importe(i)
            Next
            NuevoAtributo("totalImpuestosTrasladados", dValido(Math.Round(ImpuestosTraslado, 2), True), writer)
            'End If

            'Traslados
            writer.WriteStartElement("Traslados")
            'Traslado
            For i As Integer = 0 To OP_Impuesto.Count - 1
                writer.WriteStartElement("Traslado")
                NuevoAtributo("impuesto", OP_Impuesto(i), writer)
                NuevoAtributo("tasa", Microsoft.VisualBasic.Strings.Format(OP_Tasa(i), "0.0#"), writer)
                NuevoAtributo("importe", dValido(OP_Importe(i), True), writer)
                writer.WriteEndElement()
            Next
            writer.WriteEndElement()
            writer.WriteEndElement()

            'GenerarAddenda(pvTransProd, writer)
            'If sAddenda.Length > 0 Then
            '    writer.WriteElementString("Addenda", sAddenda)
            'End If

            writer.WriteEndDocument()

            writer.Flush()

            If pvEnMemoria Then
                lnLength = enmemoria.Length
            End If
            writer.Close()

            Dim fp As StreamReader
            Dim xmlData As String

            If Not pvEnMemoria Then
                fp = File.OpenText(vlXML.Archivo)
                xmlData = fp.ReadToEnd()
                fp.Close()
                If LbConexion.cConexion.Instancia.EjecutarComandoScalar("Select count(*) from TRPXMLFiscal where TransProdID='" & Me.TransProdID & "'") <= 0 Then
                    LbConexion.cConexion.Instancia.EjecutarComando("INSERT INTO TRPXMLFiscal(TransProdID, XML, MFechaHora, MUsuarioID) VALUES('" & Me.TransProdID & "','" & xmlData & "', getdate(),'" & Me.MUsuarioID & "')")
                    LbConexion.cConexion.Instancia.ConfirmarTran()
                End If
            End If



        Catch ex As LbControlError.cError
            Throw ex
        Catch ex As Exception
            If Not writer Is Nothing Then
                writer.Close()
            End If
            Throw New Exception(ex.Message)
        End Try

        If pvEnMemoria Then
            enmemoria.Close()
            Return lnLength
        End If

        Return Nothing
    End Function

    Dim oComprobante As com.tralix.pac.Comprobante
    Dim oServicio As com.tralix.pac.TimbradoCFDService
    Dim oConceptos As List(Of com.tralix.pac.ComprobanteConcepto)
    Dim oTraslados As List(Of com.tralix.pac.ComprobanteImpuestosTraslado)
    Dim oRegimenes As List(Of com.tralix.pac.ComprobanteEmisorRegimenFiscal)
    Dim oTimbre As com.tralix.pac.TimbreFiscalDigital
    Dim oCfdi As CFDi
    Private Function ObtenerXMLWriterVersion3(ByVal vlXML As cXML, ByVal pvEnMemoria As Boolean, ByVal pvTransProd As cTransProd, ByVal pvRuta As String, ByVal bEstaSellado As Boolean) As CFDi
        Dim writer As XmlTextWriter = Nothing
        Dim enmemoria As MemoryStream = Nothing
        Dim lnLength As Long
        oConceptos = Nothing
        oTraslados = Nothing



        'Acepta todos los certificados
        System.Net.ServicePointManager.CertificatePolicy = New com.tralix.pac.TrustAllCertificatePolicy()


        Try
            If pvEnMemoria Then
                enmemoria = New MemoryStream
                writer = New XmlTextWriter(enmemoria, System.Text.Encoding.UTF8)
            Else
                Try
                    writer = New XmlTextWriter(vlXML.Archivo, System.Text.Encoding.UTF8)
                Catch ex As Exception
                    Throw New LbControlError.cError("E0690", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(pvRuta)})
                End Try
            End If

            Dim oSubempresa As New ERMSEMLOG.cSubEmpresa()
            oSubempresa.Recuperar(SubEmpresaId, FechaHoraAlta)

            writer.Formatting = Formatting.None

            'Agrega encabezado <?xml version="1.0" encoding="utf-8"?>
            writer.WriteStartDocument()
            'COMPROBANTE
            writer.WriteStartElement("cfdi:Comprobante")

            Dim dtTransprod As New DataTable
            dtTransprod = LbConexion.cConexion.Instancia.EjecutarConsulta("select * from TRPDatoFiscal trp inner join transprod TRA on TRA.transprodid=TRP.transprodid where trp.transprodid='" & pvTransProd.TransProdID & "'")

            'Tralix GMT -5
            Dim dFecha As DateTime
            'If (Date.Now.IsDaylightSavingTime) Then'AMESOL
            '    dFecha = CType(dtTransprod.Rows(0)("FechaHoraAlta"), Date).AddMinutes(-10)
            'Else
            '    dFecha = CType(dtTransprod.Rows(0)("FechaHoraAlta"), Date).AddMinutes(-10)
            'End If

            If (Date.Now.IsDaylightSavingTime) Then
                dFecha = CType(dtTransprod.Rows(0)("FechaHoraAlta"), Date).ToUniversalTime().AddHours(-6)
            Else
                dFecha = CType(dtTransprod.Rows(0)("FechaHoraAlta"), Date).ToUniversalTime().AddHours(-6)
            End If

            If Not dtTransprod.Rows(0)!CadenaOriginal Is DBNull.Value AndAlso dtTransprod.Rows(0)!CadenaOriginal.ToString <> "" Then
                Dim cadena As String() = dtTransprod.Rows(0)!CadenaOriginal.ToString().Split(New Char() {"|"})
                Dim fechaCadena As String = cadena(3)
                Dim fechaCadenaDate As DateTime
                If DateTime.TryParse(fechaCadena, fechaCadenaDate) Then
                    dFecha = fechaCadenaDate
                End If
            End If

            'Fecha para validar si en la factura se desglosaron impuestos
            Dim dFechaFactura As Date
            If pvTransProd.Tipo = 10 Then
                Dim dtFact As New DataTable
                dtFact = LbConexion.cConexion.Instancia.EjecutarConsulta("select * from TRPDatoFiscal trp inner join transprod TRA on TRA.transprodid=TRP.transprodid where trp.transprodid='" & pvTransProd.FacturaID & "'")

                dFechaFactura = CType(dtFact.Rows(0)("FechaHoraAlta"), Date)

                If Not dtFact.Rows(0)!CadenaOriginal Is DBNull.Value Then
                    Dim cadena As String() = dtFact.Rows(0)!CadenaOriginal.ToString().Split(New Char() {"|"})
                    Dim fechaCadena As String = cadena(5)
                    Dim fechaCadenaDate As DateTime
                    If DateTime.TryParse(fechaCadena, fechaCadenaDate) Then
                        dFechaFactura = fechaCadenaDate
                    End If
                End If
            Else
                dFechaFactura = dFecha
            End If


            NuevoAtributo("xmlns:cfdi", "http://www.sat.gob.mx/cfd/3", writer)
            NuevoAtributo("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance", writer)
            If oSubempresa.VersionCFD = 2 Then
                NuevoAtributo("xsi:schemaLocation", "http://www.sat.gob.mx/cfd/3 cfdv3.xsd", writer)
            Else
                NuevoAtributo("xsi:schemaLocation", "http://www.sat.gob.mx/cfd/3 cfdv32.xsd", writer)
            End If


            NuevoAtributo("version", dtTransprod.Rows(0)("TipoVersion"), writer)
            NuevoAtributo("serie", dtTransprod.Rows(0)("Serie"), writer)
            NuevoAtributo("folio", dtTransprod.Rows(0)("Folio").ToString.Substring(dtTransprod.Rows(0)("Serie").ToString.Length), writer)
            NuevoAtributo("fecha", dFecha.ToString("s"), writer)
            NuevoAtributo("sello", dtTransprod.Rows(0)("SelloDigital"), writer)
            'NuevoAtributo("noAprobacion", dtTransprod.Rows(0)("Aprobacion"), writer)
            'NuevoAtributo("anoAprobacion", dtTransprod.Rows(0)("AnioAprobacion"), writer)
            NuevoAtributo("formaDePago", dtTransprod.Rows(0)("FormaDePago"), writer)
            NuevoAtributo("noCertificado ", dtTransprod.Rows(0)("NumCertificado"), writer)
            NuevoAtributo("certificado", IIf(IsDBNull(oSubempresa.CerBase64), "", oSubempresa.CerBase64), writer)

            Dim vlConsulta As New Text.StringBuilder

            Dim bImpuestoGlb As Boolean = False
            If pvTransProd.Tipo = 8 Then
                vlConsulta.AppendLine("select isnull(sum(case when TDI.ImpuestoPU is null or TDI.ImpDesGlb is null then 1 else 0 end), 0) as Nulos ")
                vlConsulta.AppendLine("from TransProd TRP ")
                vlConsulta.AppendLine("inner join TPDImpuesto TDI on TRP.TransProdID = TDI.TransProdID ")
                vlConsulta.AppendLine("where TRP.FacturaID = '" & Me.TransProdID & "' and TRP.Tipo = 1 ")
                bImpuestoGlb = (LbConexion.cConexion.Instancia.EjecutarComandoScalar(vlConsulta.ToString) = 0)
            Else
                vlConsulta.AppendLine("select isnull(sum(case when TDI.ImpuestoPU is null or TDI.ImpDesGlb is null then 1 else 0 end), 0) as Nulos ")
                vlConsulta.AppendLine("from TransProd TRP ")
                vlConsulta.AppendLine("inner join TPDImpuesto TDI on TRP.TransProdID = TDI.TransProdID ")
                vlConsulta.AppendLine("where TRP.FacturaID = '" & Me.TransProdID & "' and TRP.Tipo = 1 ")
                bImpuestoGlb = (LbConexion.cConexion.Instancia.EjecutarComandoScalar(vlConsulta.ToString) = 0)
            End If

            Dim sClienteClave As String
            vlConsulta = New Text.StringBuilder
            vlConsulta.AppendLine("select VIS.ClienteClave ")
            vlConsulta.AppendLine("from TransProd FAC ")
            vlConsulta.AppendLine("inner join Visita VIS on FAC.VisitaClave = VIS.VisitaClave and FAC.DiaClave = VIS.DiaClave ")
            vlConsulta.AppendLine("where FAC.TransProdID = '" & Me.TransProdID & "'")
            sClienteClave = LbConexion.cConexion.Instancia.EjecutarComandoScalar(vlConsulta.ToString)

            Dim dtTransprodDetalle As New DataTable
            vlConsulta = New Text.StringBuilder
            Dim bImpGlbOriginal As Boolean = bImpuestoGlb
            If pvTransProd.Tipo = 10 AndAlso dtTransprod.Rows(0)("TipoNotaCredito") = 1 Then bImpuestoGlb = False

            If bImpuestoGlb Then
                vlConsulta.AppendLine("set nocount on ")
                vlConsulta.AppendLine("if (select object_id('tempdb..#ImpNoDes')) is not null drop table #ImpNoDes ")
                vlConsulta.AppendLine("select * into #ImpNoDes from ( ")
                vlConsulta.AppendLine("select TDI.TransProdID, TDI.TransProdDetalleID, SUM(TDI.ImpuestoPU) as Impuesto ")
                vlConsulta.AppendLine("from TPDImpuesto TDI ")
                vlConsulta.AppendLine("inner join TransProd TRP on TDI.TransProdID = TRP.TransProdID ")
                If pvTransProd.Tipo = 8 Then
                    vlConsulta.AppendLine("where TRP.FacturaId = '" & Me.TransProdID & "' and TRP.Tipo = 1 and TDI.ImpuestoClave in ( ")
                Else
                    vlConsulta.AppendLine("where TRP.TransProdId = '" & Me.TransProdID & "' and TRP.Tipo = 10 and TDI.ImpuestoClave in ( ")
                End If
                vlConsulta.AppendLine("select ImpuestoClave ")
                vlConsulta.AppendLine("from CLINoDesImp ")
                vlConsulta.AppendLine("where ClienteClave = '" & sClienteClave & "' and '" & dFechaFactura.ToString("s") & "' between FechaInicio and FechaFin) ")
                vlConsulta.AppendLine("group by TDI.TransProdID, TDI.TransProdDetalleID ")
                vlConsulta.AppendLine(") as t ")
            End If

            vlConsulta.AppendLine("select sum(TPD.Cantidad) as Cantidad, ")
            vlConsulta.AppendLine("(select Descripcion from VAVDescripcion where VARCodigo = 'UNIDADV' and VAVClave = TPD.TipoUnidad and VADTipoLenguaje = dbo.FNObtenerLenguaje()) as Unidad, ")
            vlConsulta.AppendLine("TPD.ProductoClave, PRO.Nombre as Descripcion, ")
            If bImpuestoGlb Then
                vlConsulta.AppendLine("Precio + isnull(IND.Impuesto,0) as ValorUnitario1, Precio + isnull(IND.Impuesto,0) as Precio ")
            Else
                vlConsulta.AppendLine("Precio as ValorUnitario1, Precio as Precio ")
            End If
            vlConsulta.AppendLine("from TransProd TRP ")
            vlConsulta.AppendLine("inner join TransProdDetalle TPD on TRP.TransProdId = TPD.TransProdId ")
            If bImpuestoGlb Then
                vlConsulta.AppendLine("left join #ImpNoDes IND on TPD.TransProdID = IND.TransProdId and TPD.TransProdDetalleID = IND.TransProdDetalleId ")
            End If
            vlConsulta.AppendLine("inner join Producto PRO on PRO.ProductoClave = TPD.ProductoClave ")
            If pvTransProd.Tipo = 8 Then
                vlConsulta.AppendLine("where TRP.Tipo=1 and TRP.FacturaId ='" & Me.TransProdID & "' ")
            Else
                vlConsulta.AppendLine("where TRP.Tipo=10 and TRP.TransProdId ='" & Me.TransProdID & "' ")
            End If
            If bImpuestoGlb Then
                vlConsulta.AppendLine("group by TPD.ProductoClave, TPD.TipoUnidad, TPD.Precio + isnull(IND.Impuesto,0), PRO.Nombre ")
                vlConsulta.AppendLine("order by TPD.ProductoClave, TPD.TipoUnidad, TPD.Precio + isnull(IND.Impuesto,0) ")
            Else
                vlConsulta.AppendLine("group by TPD.ProductoClave, TPD.TipoUnidad, TPD.Precio, PRO.Nombre ")
                vlConsulta.AppendLine("order by TPD.ProductoClave, TPD.TipoUnidad, TPD.Precio ")
            End If

            If bImpuestoGlb Then
                vlConsulta.AppendLine("drop table #ImpNoDes ")
                vlConsulta.AppendLine("set nocount off ")
            End If

            dtTransprodDetalle = LbConexion.cConexion.Instancia.EjecutarConsulta(vlConsulta.ToString)


            Dim vlSubTotal As Double
            For i As Integer = 0 To dtTransprodDetalle.Rows.Count - 1
                vlSubTotal += (dtTransprodDetalle.Rows(i)("Precio") * dtTransprodDetalle.Rows(i)("Cantidad"))
            Next
            NuevoAtributo("subTotal", dValido(vlSubTotal, True), writer)
            If pvTransProd.Tipo = 8 Then
                NuevoAtributo("descuento", dValido(ObtenerDescuentosFactura(pvTransProd.TransProdID, sClienteClave, dFechaFactura, bImpuestoGlb), True), writer)
            Else
                If (dtTransprod.Rows(0)("TipoNotaCredito") = 2) Then
                    NuevoAtributo("descuento", dValido(ObtenerDescuentosNotaCredito(pvTransProd.TransProdID, sClienteClave, dFechaFactura, bImpuestoGlb), True), writer)
                Else
                    NuevoAtributo("descuento", dValido(0, True), writer)
                End If

            End If
            NuevoAtributo("total", dValido(dtTransprod.Rows(0)("Total"), True), writer)
            If pvTransProd.Tipo = 8 Then
                NuevoAtributo("tipoDeComprobante", "ingreso", writer)
            Else
                NuevoAtributo("tipoDeComprobante", "egreso", writer)
            End If

            If oSubempresa.VersionCFD = 4 Then
                NuevoAtributo("metodoDePago", dtTransprod.Rows(0)("MetodoPago"), writer)
                NuevoAtributo("LugarExpedicion", IIf(dtTransprod.Rows(0)("MunicipioEx") = "", dtTransprod.Rows(0)("MunicipioEm") & ", " & dtTransprod.Rows(0)("RegionEm"), dtTransprod.Rows(0)("MunicipioEx") & ", " & dtTransprod.Rows(0)("EntidadEx")), writer)
            End If


            'EMISOR
            writer.WriteStartElement("cfdi:Emisor")

            If oSubempresa.VersionCFD = 2 Then
                NuevoAtributo("nombre", dtTransprod.Rows(0)("NombreEm"), writer)
            End If
            NuevoAtributo("rfc", dtTransprod.Rows(0)("RFCEm"), writer)

            If oSubempresa.VersionCFD = 2 Then
                'Domicilio fiscal
                writer.WriteStartElement("cfdi:DomicilioFiscal")
                NuevoAtributo("calle", dtTransprod.Rows(0)("CalleEm"), writer)
                NuevoAtributo("noExterior", dtTransprod.Rows(0)("NumExtEm"), writer)
                If (dtTransprod.Rows(0)("NumIntEm") <> "") Then NuevoAtributo("noInterior", dtTransprod.Rows(0)("NumIntEm"), writer)
                If (dtTransprod.Rows(0)("ColoniaEm") <> "") Then NuevoAtributo("colonia", dtTransprod.Rows(0)("ColoniaEm"), writer)
                If (dtTransprod.Rows(0)("LocalidadEm") <> "") Then NuevoAtributo("localidad", dtTransprod.Rows(0)("LocalidadEm"), writer)
                If (dtTransprod.Rows(0)("ReferenciaDomEm") <> "") Then NuevoAtributo("referencia", dtTransprod.Rows(0)("ReferenciaDomEm"), writer)
                If (dtTransprod.Rows(0)("MunicipioEm") <> "") Then NuevoAtributo("municipio", dtTransprod.Rows(0)("MunicipioEm"), writer)
                If (dtTransprod.Rows(0)("RegionEm") <> "") Then NuevoAtributo("estado", dtTransprod.Rows(0)("RegionEm"), writer)
                NuevoAtributo("pais", dtTransprod.Rows(0)("PaisEm"), writer)
                If (dtTransprod.Rows(0)("CodigoPostalEm") <> "") Then NuevoAtributo("codigoPostal", dtTransprod.Rows(0)("CodigoPostalEm"), writer)
                writer.WriteEndElement()
            End If

            'Expedido en
            writer.WriteStartElement("cfdi:ExpedidoEn")
            NuevoAtributo("calle", dtTransprod.Rows(0)("CalleEx"), writer)
            NuevoAtributo("noExterior", IIf(dtTransprod.Rows(0)("NumExtEx") = "", dtTransprod.Rows(0)("NumExtEm"), dtTransprod.Rows(0)("NumExtEx")), writer)
            If (dtTransprod.Rows(0)("NumIntEx") <> "") Then NuevoAtributo("noInterior", dtTransprod.Rows(0)("NumIntEx"), writer)
            If (dtTransprod.Rows(0)("ColoniaEx") <> "") Then NuevoAtributo("colonia", dtTransprod.Rows(0)("ColoniaEx"), writer)
            If (dtTransprod.Rows(0)("LocalidadEx") <> "") Then NuevoAtributo("localidad", dtTransprod.Rows(0)("LocalidadEx"), writer)
            If (dtTransprod.Rows(0)("ReferenciaDomEx") <> "") Then NuevoAtributo("referencia", dtTransprod.Rows(0)("ReferenciaDomEx"), writer)
            If (dtTransprod.Rows(0)("MunicipioEx") <> "") Then NuevoAtributo("municipio", dtTransprod.Rows(0)("MunicipioEx"), writer)
            If (dtTransprod.Rows(0)("EntidadEx") <> "") Then NuevoAtributo("estado", dtTransprod.Rows(0)("EntidadEx"), writer)
            NuevoAtributo("pais", dtTransprod.Rows(0)("PaisEx"), writer)
            If (dtTransprod.Rows(0)("CodigoPostalEx") <> "") Then NuevoAtributo("codigoPostal", dtTransprod.Rows(0)("CodigoPostalEx"), writer)
            writer.WriteEndElement()

            Dim dtRegimen As DataTable
            If oSubempresa.VersionCFD = 4 Then
                'Regimen Fiscal

                Dim oFOL As New ERMFOLLOG.cFolio
                oFOL.Recuperar(dtTransprod.Rows(0)("FolioId"))

                Dim dtFSH As DataTable = oFOL.recuperrarFSHDatatableHistorico(dtTransprod.Rows(0)("FOSId"))
                Dim drFSH As DataRow() = dtFSH.Select("FSHFechaInicio <= '" & dFecha.ToString("s") & "'", "FSHFechaInicio desc")
                Dim oFSH As ERMFOLLOG.Amesol.CFOSHist = oFOL.FSH(dtTransprod.Rows(0)("FOSId"), drFSH(0)("FSHFechaInicio"))

                Dim sCentroExpId As String = oFSH.CentroExpID

                vlConsulta = New Text.StringBuilder
                vlConsulta.AppendLine("select case when CentroExpPadreId is null then CentroExpId else CentroExpPadreID end as CentroExpId from CentroExpedicion where CentroExpID = '" & sCentroExpId & "'")
                sCentroExpId = LbConexion.cConexion.Instancia.EjecutarComandoScalar(vlConsulta.ToString)

                vlConsulta = New Text.StringBuilder
                vlConsulta.AppendLine("select VAD.Descripcion as Regimen ")
                vlConsulta.AppendLine("from CEERegimenFiscal CRF ")
                vlConsulta.AppendLine("inner join VAVDescripcion VAD on VAD.VARCodigo = 'TIPREG' and VAD.VAVClave = CRF.TipoRegimen and VAD.VADTipoLenguaje = '" & lbGeneral.cParametros.Lenguaje & "' ")
                vlConsulta.AppendLine("where CRF.CentroExpId = '" & sCentroExpId & "' ")
                dtRegimen = LbConexion.cConexion.Instancia.EjecutarConsulta(vlConsulta.ToString)

                For Each drRegimen As DataRow In dtRegimen.Rows
                    writer.WriteStartElement("RegimenFiscal")
                    NuevoAtributo("Regimen", drRegimen("Regimen"), writer)
                    writer.WriteEndElement()
                Next
            End If
            writer.WriteEndElement()

            'RECEPTOR
            writer.WriteStartElement("cfdi:Receptor")
            NuevoAtributo("nombre", dtTransprod.Rows(0)("RazonSocial"), writer)
            NuevoAtributo("rfc", dtTransprod.Rows(0)("RFC"), writer)
            'domicilio
            writer.WriteStartElement("cfdi:Domicilio")

            NuevoAtributo("calle", dtTransprod.Rows(0)("Calle"), writer)
            NuevoAtributo("noExterior", dtTransprod.Rows(0)("NumExt"), writer)
            If (dtTransprod.Rows(0)("NumInt") <> "") Then NuevoAtributo("noInterior", dtTransprod.Rows(0)("NumInt"), writer)
            If (dtTransprod.Rows(0)("Colonia") <> "") Then NuevoAtributo("colonia", dtTransprod.Rows(0)("Colonia"), writer)
            If (dtTransprod.Rows(0)("Localidad") <> "") Then NuevoAtributo("localidad", dtTransprod.Rows(0)("Localidad"), writer)
            If (dtTransprod.Rows(0)("ReferenciaDom") <> "") Then NuevoAtributo("referencia", dtTransprod.Rows(0)("ReferenciaDom"), writer)
            If (dtTransprod.Rows(0)("Municipio") <> "") Then NuevoAtributo("municipio", dtTransprod.Rows(0)("Municipio"), writer)
            If (dtTransprod.Rows(0)("Entidad") <> "") Then NuevoAtributo("estado", dtTransprod.Rows(0)("Entidad"), writer)
            NuevoAtributo("pais", dtTransprod.Rows(0)("Pais"), writer)
            If (dtTransprod.Rows(0)("CodigoPostal") <> "") Then NuevoAtributo("codigoPostal", dtTransprod.Rows(0)("CodigoPostal"), writer)
            writer.WriteEndElement()
            writer.WriteEndElement()

            If (Not bEstaSellado) Then

                If (oSubempresa.ProveedorTimbre = 1) Then


                    oComprobante = New com.tralix.pac.Comprobante()
                    oServicio = New com.tralix.pac.TimbradoCFDService(oSubempresa.CustomerKey, oSubempresa.ServidorTimbre)
                    oComprobante.version = dtTransprod.Rows(0)("TipoVersion")
                    oComprobante.serie = dtTransprod.Rows(0)("Serie")
                    oComprobante.folio = dtTransprod.Rows(0)("Folio").ToString.Substring(dtTransprod.Rows(0)("Serie").ToString.Length)
                    oComprobante.fecha = dFecha.ToString("s")
                    oComprobante.sello = dtTransprod.Rows(0)("SelloDigital")
                    oComprobante.formaDePago = dtTransprod.Rows(0)("FormaDePago")
                    oComprobante.noCertificado = dtTransprod.Rows(0)("NumCertificado")
                    oComprobante.certificado = oSubempresa.CerBase64
                    Dim reg As New ERMTRPLOG.com.tralix.pac.ComprobanteEmisorRegimenFiscal()

                    If oSubempresa.VersionCFD = 4 Then
                        oComprobante.metodoDePago = dtTransprod.Rows(0)("MetodoPago")
                        oComprobante.LugarExpedicion = IIf(dtTransprod.Rows(0)("MunicipioEx") = "", dtTransprod.Rows(0)("MunicipioEm") & ", " & dtTransprod.Rows(0)("RegionEm"), dtTransprod.Rows(0)("MunicipioEx") & ", " & dtTransprod.Rows(0)("EntidadEx"))
                    End If

                    oComprobante.subTotal = dValido(vlSubTotal, True)
                    If pvTransProd.Tipo = 8 Then
                        oComprobante.descuento = dValido(ObtenerDescuentosFactura(pvTransProd.TransProdID, sClienteClave, dFechaFactura, bImpuestoGlb), True)
                    Else
                        If (dtTransprod.Rows(0)("TipoNotaCredito") = 2) Then
                            oComprobante.descuento = dValido(ObtenerDescuentosNotaCredito(pvTransProd.TransProdID, sClienteClave, dFechaFactura, bImpuestoGlb), True)

                        Else
                            oComprobante.descuento = dValido(0, True)
                        End If
                        'oComprobante.descuento = dValido(0, True)
                    End If


                    oComprobante.descuentoSpecified = True

                    oComprobante.total = dValido(dtTransprod.Rows(0)("Total"), True)
                    If pvTransProd.Tipo = 8 Then
                        oComprobante.tipoDeComprobante = com.tralix.pac.ComprobanteTipoDeComprobante.ingreso
                    Else
                        oComprobante.tipoDeComprobante = com.tralix.pac.ComprobanteTipoDeComprobante.egreso
                    End If

                    oComprobante.Emisor = New com.tralix.pac.ComprobanteEmisor()
                    If oSubempresa.VersionCFD = 2 Then
                        oComprobante.Emisor.nombre = dtTransprod.Rows(0)("NombreEm")
                    End If
                    oComprobante.Emisor.rfc = dtTransprod.Rows(0)("RFCEm")

                    If oSubempresa.VersionCFD = 2 Then
                        oComprobante.Emisor.DomicilioFiscal = New com.tralix.pac.t_UbicacionFiscal
                        oComprobante.Emisor.DomicilioFiscal.calle = dtTransprod.Rows(0)("CalleEm")
                        oComprobante.Emisor.DomicilioFiscal.noExterior = dtTransprod.Rows(0)("NumExtEm")
                        If (dtTransprod.Rows(0)("NumIntEm") <> "") Then oComprobante.Emisor.DomicilioFiscal.noInterior = dtTransprod.Rows(0)("NumIntEm")
                        If (dtTransprod.Rows(0)("ColoniaEm") <> "") Then oComprobante.Emisor.DomicilioFiscal.colonia = dtTransprod.Rows(0)("ColoniaEm")
                        If (dtTransprod.Rows(0)("LocalidadEm") <> "") Then oComprobante.Emisor.DomicilioFiscal.localidad = dtTransprod.Rows(0)("LocalidadEm")
                        If (dtTransprod.Rows(0)("ReferenciaDomEm") <> "") Then oComprobante.Emisor.DomicilioFiscal.referencia = dtTransprod.Rows(0)("ReferenciaDomEm")
                        If (dtTransprod.Rows(0)("MunicipioEm") <> "") Then oComprobante.Emisor.DomicilioFiscal.municipio = dtTransprod.Rows(0)("MunicipioEm")
                        If (dtTransprod.Rows(0)("RegionEm") <> "") Then oComprobante.Emisor.DomicilioFiscal.estado = dtTransprod.Rows(0)("RegionEm")
                        oComprobante.Emisor.DomicilioFiscal.pais = dtTransprod.Rows(0)("PaisEm")
                        If (dtTransprod.Rows(0)("CodigoPostalEm") <> "") Then oComprobante.Emisor.DomicilioFiscal.codigoPostal = dtTransprod.Rows(0)("CodigoPostalEm")
                    End If

                    If oSubempresa.VersionCFD = 4 Then
                        If (Not dtRegimen Is Nothing) Then
                            oRegimenes = New List(Of com.tralix.pac.ComprobanteEmisorRegimenFiscal)

                            For Each drRegimen As DataRow In dtRegimen.Rows
                                Dim oRegimen As New com.tralix.pac.ComprobanteEmisorRegimenFiscal
                                oRegimen.Regimen = drRegimen("Regimen")
                                oRegimenes.Add(oRegimen)
                            Next
                            oComprobante.Emisor.RegimenFiscal = oRegimenes.ToArray
                        End If
                    End If

                    oComprobante.Emisor.ExpedidoEn = New com.tralix.pac.t_Ubicacion
                    oComprobante.Emisor.ExpedidoEn.calle = dtTransprod.Rows(0)("CalleEx")
                    oComprobante.Emisor.ExpedidoEn.noExterior = IIf(dtTransprod.Rows(0)("NumExtEx") = "", dtTransprod.Rows(0)("NumExtEm"), dtTransprod.Rows(0)("NumExtEx"))

                    If (dtTransprod.Rows(0)("NumIntEx") <> "") Then oComprobante.Emisor.ExpedidoEn.noInterior = dtTransprod.Rows(0)("NumIntEx")
                    If (dtTransprod.Rows(0)("ColoniaEx") <> "") Then oComprobante.Emisor.ExpedidoEn.colonia = dtTransprod.Rows(0)("ColoniaEx")
                    If (dtTransprod.Rows(0)("LocalidadEx") <> "") Then oComprobante.Emisor.ExpedidoEn.localidad = dtTransprod.Rows(0)("LocalidadEx")
                    If (dtTransprod.Rows(0)("ReferenciaDomEx") <> "") Then oComprobante.Emisor.ExpedidoEn.referencia = dtTransprod.Rows(0)("ReferenciaDomEx")
                    If (dtTransprod.Rows(0)("MunicipioEx") <> "") Then oComprobante.Emisor.ExpedidoEn.municipio = dtTransprod.Rows(0)("MunicipioEx")
                    If (dtTransprod.Rows(0)("EntidadEx") <> "") Then oComprobante.Emisor.ExpedidoEn.estado = dtTransprod.Rows(0)("EntidadEx")
                    oComprobante.Emisor.ExpedidoEn.pais = dtTransprod.Rows(0)("PaisEx")
                    If (dtTransprod.Rows(0)("CodigoPostalEx") <> "") Then oComprobante.Emisor.ExpedidoEn.codigoPostal = dtTransprod.Rows(0)("CodigoPostalEx")

                    oComprobante.Receptor = New com.tralix.pac.ComprobanteReceptor()
                    oComprobante.Receptor.nombre = dtTransprod.Rows(0)("RazonSocial")
                    oComprobante.Receptor.rfc = dtTransprod.Rows(0)("RFC")

                    oComprobante.Receptor.Domicilio = New com.tralix.pac.t_Ubicacion
                    oComprobante.Receptor.Domicilio.calle = dtTransprod.Rows(0)("Calle")
                    oComprobante.Receptor.Domicilio.noExterior = dtTransprod.Rows(0)("NumExt")
                    If (dtTransprod.Rows(0)("NumInt") <> "") Then oComprobante.Receptor.Domicilio.noInterior = dtTransprod.Rows(0)("NumInt")
                    If (dtTransprod.Rows(0)("Colonia") <> "") Then oComprobante.Receptor.Domicilio.colonia = dtTransprod.Rows(0)("Colonia")
                    If (dtTransprod.Rows(0)("Localidad") <> "") Then oComprobante.Receptor.Domicilio.localidad = dtTransprod.Rows(0)("Localidad")
                    If (dtTransprod.Rows(0)("ReferenciaDom") <> "") Then oComprobante.Receptor.Domicilio.referencia = dtTransprod.Rows(0)("ReferenciaDom")
                    If (dtTransprod.Rows(0)("Municipio") <> "") Then oComprobante.Receptor.Domicilio.municipio = dtTransprod.Rows(0)("Municipio")
                    If (dtTransprod.Rows(0)("Entidad") <> "") Then oComprobante.Receptor.Domicilio.estado = dtTransprod.Rows(0)("Entidad")
                    oComprobante.Receptor.Domicilio.pais = dtTransprod.Rows(0)("Pais")
                    If (dtTransprod.Rows(0)("CodigoPostal") <> "") Then oComprobante.Receptor.Domicilio.codigoPostal = dtTransprod.Rows(0)("CodigoPostal")

                End If
            End If
            'CONCEPTOS
            writer.WriteStartElement("cfdi:Conceptos")
            'Concepto
            Dim IP_TransProdID As New ArrayList

            vlConsulta = New Text.StringBuilder
            vlConsulta.AppendLine("select Distinct TRP.TransProdID ")
            vlConsulta.AppendLine("from TransProd TRP ")
            vlConsulta.AppendLine("inner join TransProdDetalle TPD on TRP.TransProdID = TPD.TransProdID ")
            vlConsulta.AppendLine("inner join Producto PRO on TPD.ProductoClave = PRO.ProductoClave ")
            vlConsulta.AppendLine("inner join VAVDescripcion VAD on VAD.VARCodigo = 'UNIDADV' and VAD.VAVClave = TPD.TipoUnidad and VAD.VADTipoLenguaje = dbo.FNObtenerLenguaje() ")
            If pvTransProd.Tipo = 8 Then
                vlConsulta.AppendLine("where TRP.tipo = 1 and TRP.FacturaID = '" & Me.TransProdID & "' order by TRP.transprodid ")
            Else
                vlConsulta.AppendLine("where TRP.tipo = 10 and TRP.TransProdID = '" & Me.TransProdID & "' order by TRP.transprodid ")
            End If
            Dim dtTransprods As New DataTable()
            dtTransprods = LbConexion.cConexion.Instancia.EjecutarConsulta(vlConsulta.ToString)

            For i As Integer = 0 To dtTransprods.Rows.Count - 1
                If Not IP_TransProdID.Contains(dtTransprods.Rows(i)("TransProdID")) Then
                    IP_TransProdID.Add(dtTransprods.Rows(i)("TransProdID"))
                End If
            Next


            For i As Integer = 0 To dtTransprodDetalle.Rows.Count - 1 'cantidad de detalles

                writer.WriteStartElement("cfdi:Concepto")
                NuevoAtributo("cantidad", dtTransprodDetalle.Rows(i)("Cantidad"), writer)
                NuevoAtributo("unidad", dtTransprodDetalle.Rows(i)("Unidad"), writer)
                NuevoAtributo("noIdentificacion", dtTransprodDetalle.Rows(i)("ProductoClave"), writer)
                NuevoAtributo("descripcion", dtTransprodDetalle.Rows(i)("descripcion").ToString().Trim(), writer)
                NuevoAtributo("valorUnitario", dValido(dtTransprodDetalle.Rows(i)("Precio"), True), writer)
                NuevoAtributo("importe", dValido(dtTransprodDetalle.Rows(i)("Precio") * dtTransprodDetalle.Rows(i)("Cantidad"), True), writer)
                writer.WriteEndElement()
                If (Not bEstaSellado) Then
                    If (oSubempresa.ProveedorTimbre = 1) Then
                        If (oConceptos Is Nothing) Then
                            oConceptos = New List(Of com.tralix.pac.ComprobanteConcepto)
                        End If
                        Dim oConcepto As New com.tralix.pac.ComprobanteConcepto()
                        oConcepto.cantidad = dtTransprodDetalle.Rows(i)("Cantidad")
                        oConcepto.unidad = dtTransprodDetalle.Rows(i)("Unidad")
                        oConcepto.noIdentificacion = dtTransprodDetalle.Rows(i)("ProductoClave")
                        oConcepto.descripcion = dtTransprodDetalle.Rows(i)("descripcion")
                        oConcepto.valorUnitario = dValido(dtTransprodDetalle.Rows(i)("Precio"), True)
                        oConcepto.importe = dValido(dtTransprodDetalle.Rows(i)("Precio") * dtTransprodDetalle.Rows(i)("Cantidad"), True)
                        oConceptos.Add(oConcepto)
                    End If
                End If

            Next

            If (Not bEstaSellado) Then


                If (oSubempresa.ProveedorTimbre = 1) Then
                    oComprobante.Conceptos = oConceptos.ToArray()
                End If

            End If
            writer.WriteEndElement()

            'IMPUESTOS
            writer.WriteStartElement("cfdi:Impuestos")

            Dim OP_Impuesto As New ArrayList
            Dim OP_Tasa As New ArrayList
            Dim OP_Importe As New ArrayList
            If pvTransProd.Tipo = 8 Then
                ImpuestosConDesc(IP_TransProdID, sClienteClave, dFechaFactura, bImpuestoGlb, OP_Impuesto, OP_Tasa, OP_Importe)
            Else
                ImpuestosConDesc(IP_TransProdID(0).ToString(), sClienteClave, dFechaFactura, bImpGlbOriginal, OP_Impuesto, OP_Tasa, OP_Importe)
            End If

            Dim sCmd As String
            sCmd = "select count(*) from TransProd TRP "
            sCmd &= "inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave and TRP.DiaClave = VIS.DiaClave "
            sCmd &= "inner join AddendaCliente ADC on VIS.ClienteClave = ADC.ClienteClave "
            sCmd &= "inner join Addenda ADE on ADC.ADDId = ADE.ADDID "
            sCmd &= "where TRP.TransProdID = '" & Me.TransProdID & "' and ADE.Tipo in (1,5) and Baja = 0 "

            Dim ImpuestosTraslado As Double = 0
            Dim bTotalImpuestosT As Boolean = False
            If LbConexion.cConexion.Instancia.EjecutarComandoScalar(sCmd) > 0 Then
                bTotalImpuestosT = True
                For i As Integer = 0 To OP_Impuesto.Count - 1
                    ImpuestosTraslado += OP_Importe(i)
                Next
                NuevoAtributo("totalImpuestosTrasladados", Math.Round(ImpuestosTraslado, 2), writer)
            End If

            'Traslados
            writer.WriteStartElement("cfdi:Traslados")
            'Traslado
            For i As Integer = 0 To OP_Impuesto.Count - 1
                writer.WriteStartElement("cfdi:Traslado")
                NuevoAtributo("impuesto", OP_Impuesto(i), writer)
                NuevoAtributo("tasa", dValido(OP_Tasa(i), True), writer)
                NuevoAtributo("importe", dValido(OP_Importe(i), True), writer)
                writer.WriteEndElement()
                If (Not bEstaSellado) Then
                    If (oSubempresa.ProveedorTimbre = 1) Then
                        If oTraslados Is Nothing Then
                            oTraslados = New List(Of com.tralix.pac.ComprobanteImpuestosTraslado)
                        End If
                        Dim oTraslado As New com.tralix.pac.ComprobanteImpuestosTraslado()

                        oTraslado.impuesto = IIf(OP_Impuesto(i).ToString().ToUpper() = "IVA", com.tralix.pac.ComprobanteImpuestosTrasladoImpuesto.IVA, com.tralix.pac.ComprobanteImpuestosTrasladoImpuesto.IEPS)
                        oTraslado.tasa = dValido(OP_Tasa(i), True)
                        oTraslado.importe = dValido(OP_Importe(i), True)
                        oTraslados.Add(oTraslado)

                    End If
                End If


            Next
            writer.WriteEndElement()
            writer.WriteEndElement()

            If (Not bEstaSellado) Then
                oCfdi = New CFDi()

                If (oSubempresa.ProveedorTimbre = 1) Then
                    If Not oTraslados Is Nothing Then
                        oComprobante.Impuestos = New com.tralix.pac.ComprobanteImpuestos
                        If bTotalImpuestosT Then
                            oComprobante.Impuestos.totalImpuestosTrasladadosSpecified = True
                            oComprobante.Impuestos.totalImpuestosTrasladados = dValido(ImpuestosTraslado, True)
                        End If
                        oComprobante.Impuestos.Traslados = oTraslados.ToArray()
                    End If
                    'oServicio.RequestEncoding = System.Text.Encoding.UTF8
                    'oServicio.AllowAutoRedirect = True
                    oServicio.Timeout = 3000000

                    Dim des As New System.Xml.Serialization.XmlSerializer(oComprobante.GetType())


#If DEBUG Then 'Para ver la peticion a enviar


                    Dim memoria As New MemoryStream()

                    des.Serialize(memoria, oComprobante)
                    Dim ODOCXML As New Xml.XmlDocument
                    memoria.Position = 0
                    ODOCXML.Load(memoria)
#End If



                    oServicio.TimbradoCFDSinRespuesta(oComprobante)
                    oCfdi = New CFDi()
                    oCfdi.TimbreFiscal = oServicio.oTimbreFiscal
                End If

                writer.WriteStartElement("cfdi:Complemento")
                writer.WriteStartElement("tfd:TimbreFiscalDigital")
                NuevoAtributo("xmlns:tfd", "http://www.sat.gob.mx/TimbreFiscalDigital", writer)
                NuevoAtributo("xsi:schemaLocation", "http://www.sat.gob.mx/TimbreFiscalDigital TimbreFiscalDigital.xsd", writer)
                NuevoAtributo("selloCFD", oCfdi.TimbreFiscal.selloCFD, writer)
                NuevoAtributo("selloSAT", oCfdi.TimbreFiscal.selloSAT, writer)
                NuevoAtributo("UUID", oCfdi.TimbreFiscal.UUID, writer)
                NuevoAtributo("FechaTimbrado", oCfdi.TimbreFiscal.FechaTimbrado.ToString("s"), writer)
                NuevoAtributo("version", oCfdi.TimbreFiscal.version, writer)
                NuevoAtributo("noCertificadoSAT", oCfdi.TimbreFiscal.noCertificadoSAT, writer)


                writer.WriteEndElement()
                writer.WriteEndElement()
            Else

                writer.WriteStartElement("cfdi:Complemento")
                writer.WriteStartElement("tfd:TimbreFiscalDigital")
                NuevoAtributo("xmlns:tfd", "http://www.sat.gob.mx/TimbreFiscalDigital", writer)
                NuevoAtributo("xsi:schemaLocation", "http://www.sat.gob.mx/TimbreFiscalDigital TimbreFiscalDigital.xsd", writer)
                NuevoAtributo("selloCFD", dtTransprod.Rows(0)("SelloDigital"), writer)
                NuevoAtributo("selloSAT", IIf(dtTransprod.Rows(0)("selloSAT") Is DBNull.Value, "", dtTransprod.Rows(0)("selloSAT")), writer)
                NuevoAtributo("UUID", IIf(dtTransprod.Rows(0)("UUID") Is DBNull.Value, "", dtTransprod.Rows(0)("UUID")), writer)
                Dim fechatimbrado As DateTime = DateTime.MinValue
                If Not dtTransprod.Rows(0)("FechaTimbrado") Is DBNull.Value Then
                    fechatimbrado = CType(dtTransprod.Rows(0)("FechaTimbrado"), DateTime)
                End If
                NuevoAtributo("FechaTimbrado", IIf(fechatimbrado.CompareTo(DateTime.MinValue) = 0, "", fechatimbrado.ToString("s")), writer)
                NuevoAtributo("version", IIf(dtTransprod.Rows(0)("VersionTFD") Is DBNull.Value, "", dtTransprod.Rows(0)("VersionTFD")), writer)
                NuevoAtributo("noCertificadoSAT", IIf(dtTransprod.Rows(0)("noCertificadoSAT") Is DBNull.Value, "", dtTransprod.Rows(0)("noCertificadoSAT")), writer)

                writer.WriteEndElement()
                writer.WriteEndElement()
            End If

            'GenerarAddenda(pvTransProd, writer)
            'If sAddenda.Length > 0 Then
            '    writer.WriteElementString("Addenda", sAddenda)
            'End If

            writer.WriteEndDocument()
            writer.Flush()
            If pvEnMemoria Then
                lnLength = enmemoria.Length
                oCfdi.Tamanio = lnLength
            End If
            writer.Close()
        Catch ex As LbControlError.cError
            Throw ex
        Catch ex As CFDiException
            If Not writer Is Nothing Then
                writer.Close()
            End If
            Throw ex
        Catch ex As System.Net.WebException
            If Not writer Is Nothing Then
                writer.Close()
            End If
            Throw ex
        Catch ex As Exception
            If Not writer Is Nothing Then
                writer.Close()
            End If
            Throw New Exception(ex.Message)
        End Try

        If pvEnMemoria Then
            enmemoria.Close()
            Return oCfdi
        End If

        Return oCfdi
    End Function

    Public Sub CancelarCFDV3SoapReference(ByVal RFCEmisor As String, ByVal uuid As String, ByVal oSubempresa As ERMSEMLOG.cSubEmpresa, ByVal ServidorCancelacionSat As String)

        Dim Key As New Security.Cryptography.RSACryptoServiceProvider()
        Dim encoding As New System.Text.UTF8Encoding()

        Dim oCert As New Security.Cryptography.X509Certificates.X509Certificate2(Convert.FromBase64String(oSubempresa.AchivoPFX64), "12345678a")
        Dim oKey As New Security.Cryptography.RSACryptoServiceProvider()

        Dim oXml As XmlDocument = SignVerifyEnvelope.SignXmlFile("<TokenCancelacionRequest xmlns=""http://tokencancelacion.pac.tralix.com"" RfcEmisor=""" + RFCEmisor + """/>", oCert)

        Dim sXML As String = oXml.OuterXml
        sXML = "<?xml version=""1.0"" encoding=""utf-8""?><soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema""><soap:Body>" + sXML
        sXML = sXML + "</soap:Body></soap:Envelope>"

        oXml.LoadXml(sXML)

        Dim request As System.Net.HttpWebRequest = System.Net.WebRequest.Create(oSubempresa.ServidorCancelacion)

        request.Method = "POST"
        request.ContentType = "text/xml; charset=utf-8"

        request.Timeout = 30 * 1000
        request.Headers.Add("CustomerKey: 8e55918dda7b3ff3a5e76d3eb4e78f8bd089b5be")
        request.Headers.Add("SOAPAction: ""http://tokencancelacion.tralix.com/ObtenerToken""")

        'open the pipe?
        Dim request_stream As Stream = request.GetRequestStream()
        Dim aStreamWriter As New StreamWriter(request_stream)
        'write the XML to the open pipe (e.g. stream)
        'xmlDoc.Save(request_stream);
        Dim aStringBuilder As New Text.StringBuilder()
        'aStringBuilder.Append("Message=");
        aStringBuilder.Append(oXml.OuterXml)

        aStreamWriter.Write(aStringBuilder.ToString())

        'xmlDoc.Save("C://XMLFINAL.XML");
        'CLOSE THE PIPE !!! Very important or next step will time out!!!!
        aStreamWriter.Close()
        'request_stream.Position = 0;
        'get the response from the webservice
        Dim response As System.Net.HttpWebResponse = DirectCast(request.GetResponse(), System.Net.HttpWebResponse)
        Dim r_stream As Stream = response.GetResponseStream()
        'convert it
        Dim response_stream As New StreamReader(r_stream, System.Text.Encoding.GetEncoding("utf-8"))
        Dim sOutput As String = response_stream.ReadToEnd()


        oXml.LoadXml(sOutput)
        Dim sToken As String = oXml.InnerText
        oXml = SignVerifyEnvelope.SignXmlFile("<Cancelacion xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" Fecha=""" + Date.Now.ToString("s") + """ RfcEmisor=""" + RFCEmisor + """><Folios><UUID>" + uuid + "</UUID></Folios></Cancelacion>", oCert)


        Dim oServicioCancelacionSat As New net.cloudapp.pruebacfdicancelacion.CancelaCFDService() '(sToken)
        Dim oCancelacion As New net.cloudapp.pruebacfdicancelacion.Cancelacion()


        Dim des As New System.Xml.Serialization.XmlSerializer(oCancelacion.GetType())


        Dim a As New XmlNodeReader(oXml)
        oCancelacion = des.Deserialize(a)


        Dim oCancelacion2 As New net.cloudapp.pruebacfdicancelacion.Cancelacion()

        Dim oCancelacionFol As New net.cloudapp.pruebacfdicancelacion.CancelacionFolios()
        oCancelacionFol.UUID = ""
        oCancelacion2.Folios = New net.cloudapp.pruebacfdicancelacion.CancelacionFolios() {oCancelacionFol}
        Dim memoria As New MemoryStream()

        des.Serialize(memoria, oCancelacion)
        Dim ODOCXML As New Xml.XmlDocument
        memoria.Position = 0
        ODOCXML.Load(memoria)

        oServicioCancelacionSat.CancelaCFD(oCancelacion)


    End Sub
    Public Sub CancelarCFDV3Soap(ByVal RFCEmisor As String, ByVal uuid As String, ByVal oSubempresa As ERMSEMLOG.cSubEmpresa)




        Dim Key As New Security.Cryptography.RSACryptoServiceProvider()
        Dim encoding As New System.Text.UTF8Encoding()

        Dim oCert As New Security.Cryptography.X509Certificates.X509Certificate2(Convert.FromBase64String(oSubempresa.AchivoPFX64), oSubempresa.ContrasenaClave)
        Dim oKey As New Security.Cryptography.RSACryptoServiceProvider()

        Dim oXml As XmlDocument

        'oXml = SignVerifyEnvelope.SignXmlFile("<Cancelacion xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" RfcEmisor=""" + RFCEmisor + """ Fecha=""" + Date.Now.ToString("s") + """ xmlns=""http://cancelacfd.sat.gob.mx""/>", oCert)
        oXml = SignVerifyEnvelope.SignXmlFile("<Cancelacion xmlns=""http://cancelacfd.sat.gob.mx"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" Fecha=""" + LbConexion.cConexion.Instancia.ObtenerFecha.ToString("s") + """ RfcEmisor=""" + RFCEmisor + """><Folios><UUID>" + uuid + "</UUID></Folios></Cancelacion>", oCert)
        Dim sXML As String






        sXML = oXml.OuterXml



        'sXML = "<s:Envelope xmlns:s=""http://schemas.xmlsoap.org/soap/envelope/""  xmlns:rec=""http://recibecfdi.sat.gob.mx""><s:Header/><s:Body><CancelaCFD xmlns=""http://cancelacfd.sat.gob.mx"" >" + sXML
        sXML = "<s:Envelope xmlns:s=""http://schemas.xmlsoap.org/soap/envelope/""  xmlns:rec=""http://recibecfdi.sat.gob.mx""><s:Header/><s:Body><CancelaCFD xmlns=""http://cancelacfd.sat.gob.mx"" >" + sXML
        sXML = sXML + "</CancelaCFD></s:Body></s:Envelope>"


        oXml.LoadXml(sXML)


        Dim request As System.Net.HttpWebRequest = System.Net.WebRequest.Create(oSubempresa.ServidorCancelacion)


        request.Method = "POST"
        'request.Connection = "https://pruebacfdicancelacion.cloudapp.net/Cancelacion/CancelaCFDService.svc HTTP/1.1"

        request.ContentType = "text/xml; charset=utf-8"


        request.Timeout = 30 * 10000

        request.Headers.Add("CustomerKey: " + oSubempresa.CustomerKey)

        request.Headers.Add("SOAPAction: ""http://cancelacfd.sat.gob.mx/ICancelaCFDBinding/CancelaCFD""")



        Dim request_stream As Stream

        Dim aStreamWriter As StreamWriter

        'write the XML to the open pipe (e.g. stream)
        'xmlDoc.Save(request_stream);
        Dim aStringBuilder As New Text.StringBuilder()
        'open the pipe?


        request_stream = request.GetRequestStream()
        aStreamWriter = New StreamWriter(request_stream, System.Text.Encoding.UTF8)
        'write the XML to the open pipe (e.g. stream)
        'xmlDoc.Save(request_stream);
        aStringBuilder = New Text.StringBuilder()

        aStringBuilder.Append(oXml.OuterXml)

        aStreamWriter.Write(aStringBuilder.ToString())

        aStreamWriter.Close()
        'request_stream.Position = 0;
        'get the response from the webservice
        Dim sOutput As String = ""


        Try


            System.Net.ServicePointManager.ServerCertificateValidationCallback = New System.Net.Security.RemoteCertificateValidationCallback(AddressOf ValidateTSL)
            Dim cache As New System.Net.CredentialCache()
            Dim a As New System.Net.Security.RemoteCertificateValidationCallback(AddressOf ValidateSSL)

            Dim response As System.Net.HttpWebResponse = DirectCast(request.GetResponse(), System.Net.HttpWebResponse)
            Dim r_stream As Stream = response.GetResponseStream()
            'convert it
            Dim response_stream As New StreamReader(r_stream, System.Text.Encoding.GetEncoding("utf-8"))
            sOutput = response_stream.ReadToEnd()



            Dim oXmlRes As New XmlDocument()
            oXmlRes.LoadXml(sOutput)

            Dim oListaXmlNodo As XmlNodeList = oXmlRes.GetElementsByTagName("EstatusUUID")
            Dim oHash As Hashtable = lbGeneral.ValoresDescripcionVARValor("SATERROR", "")

            If oListaXmlNodo.Count > 0 Then
                Dim sCodigo As String = oListaXmlNodo.Item(0).InnerXml
                Dim sMensaje As String = ""
                If (oHash.ContainsKey(sCodigo)) Then
                    sMensaje = oHash(sCodigo)
                End If

                If (sCodigo = 201) Then
                    Exit Sub
                Else

                    Throw New CFDiException(sCodigo, sMensaje)
                End If
            Else
                Throw New CFDiException("-2", sOutput)
            End If

        Catch ex As CFDiException
            Throw ex
        Catch ex As Exception
            Throw New CFDiException("-1", ex.Message)

        End Try

    End Sub


    Public Function ValidateSSL(ByVal sender As Object, ByVal certificate As System.Security.Cryptography.X509Certificates.X509Certificate, ByVal chain As System.Security.Cryptography.X509Certificates.X509Chain, ByVal sspolicyerrors As System.Net.Security.SslPolicyErrors) As Boolean
        Return True
    End Function
    Public Function ValidateTSL(ByVal sender As Object, ByVal certificate As System.Security.Cryptography.X509Certificates.X509Certificate, ByVal chain As System.Security.Cryptography.X509Certificates.X509Chain, ByVal sspolicyerrors As System.Net.Security.SslPolicyErrors) As Boolean
        Return True
    End Function

    Friend Shared Function ReadFile(ByVal strArchivo As String) As Byte()
        Dim f As New FileStream(strArchivo, FileMode.Open, FileAccess.Read)
        Dim size As Integer = CInt(f.Length)
        Dim data As Byte() = New Byte(size - 1) {}
        size = f.Read(data, 0, size)
        f.Close()
        Return data
    End Function

    Private Sub GenerarAddenda(ByVal paroTransProd As cTransProd, ByRef writer As XmlTextWriter)
        'Dim writer As XmlTextWriter = Nothing
        'Dim enmemoria As MemoryStream = Nothing
        'Dim lnLength As Long

        Try

            Dim sClienteClave As String = LbConexion.cConexion.Instancia.EjecutarComandoScalar("SELECT VIS.ClienteClave from TransProd TRP inner join Visita VIS on TRP.VisitaClave = VIS.visitaClave and TRP.DiaClave = VIS.DiaClave where Folio = '" & paroTransProd.Folio & "'").ToString()

            Dim dtCAFDetalle As DataTable = LbConexion.cConexion.Instancia.EjecutarConsulta("select * from CAFDetalle inner join CAFConfiguracion on CAFDetalle.clienteclave = CAFConfiguracion.Clienteclave and CAFDetalle.Nodo = CAFConfiguracion.Nodo where CAFDetalle.Folio='" & paroTransProd.Folio & "' and CAFDetalle.clienteclave = '" & sClienteClave & "' order by CAFConfiguracion.Orden")
            If dtCAFDetalle.Rows.Count < 0 Then
                dtCAFDetalle.Dispose()
                Exit Sub
            End If


            'enmemoria = New MemoryStream
            'writer = New XmlTextWriter(enmemoria, System.Text.Encoding.UTF8)

            'writer = New XmlTextWriter("Addenda.xml", System.Text.Encoding.UTF8)

            'writer.Formatting = Formatting.None

            'Agrega encabezado <?xml version="1.0" encoding="utf-8"?>
            'writer.WriteStartDocument()

            'ADDENDA
            writer.WriteStartElement("Addenda")
            writer.WriteStartElement("requestForPayment")

            Dim drNodo() As DataRow

            drNodo = dtCAFDetalle.Select("Nodo = 'Addenda:requestForPayment:type'")
            If (drNodo.Length > 0) Then
                NuevoAtributo("type", drNodo(0)("Valor"), writer)
            End If
            drNodo = dtCAFDetalle.Select("Nodo = 'Addenda:requestForPayment:contentVersion'")
            If (drNodo.Length > 0) Then
                NuevoAtributo("contentVersion", drNodo(0)("Valor"), writer)
            End If

            drNodo = dtCAFDetalle.Select("Nodo = 'Addenda:requestForPayment:documentStructureVersion'")
            NuevoAtributo("documentStructureVersion", drNodo(0)("Valor"), writer)

            drNodo = dtCAFDetalle.Select("Nodo = 'Addenda:requestForPayment:documentStatus'")
            NuevoAtributo("documentStatus", drNodo(0)("Valor"), writer)

            NuevoAtributo("DeliveryDate", paroTransProd.FechaHoraAlta, writer)

            writer.WriteStartElement("requestForPaymentIdentification")
            drNodo = dtCAFDetalle.Select("Nodo = 'Addenda:requestForPayment:requestForPaymentIdentification:entityType:entityType'")
            writer.WriteElementString("entityType", drNodo(0)("Valor"))
            writer.WriteElementString("uniqueCreatorIdentification", paroTransProd.Folio)
            writer.WriteEndElement() 'Fin requestForPaymentIdentification

            writer.WriteStartElement("DeliveryNote")

            drNodo = dtCAFDetalle.Select("Nodo = 'Addenda:requestForPayment:DeliveryNote:referenceIdentification:referenceIdentification'")
            writer.WriteElementString("referenceIdentification", drNodo(0)("Valor"))

            drNodo = dtCAFDetalle.Select("Nodo = 'Addenda:requestForPayment:DeliveryNote:ReferenceDate:ReferenceDate'")
            If (drNodo.Length > 0) AndAlso (drNodo(0)("Valor") <> "") Then
                writer.WriteElementString("ReferenceDate", drNodo(0)("Valor"))
            End If
            writer.WriteEndElement() 'Fin DeliveryNote

            writer.WriteStartElement("buyer")
            drNodo = dtCAFDetalle.Select("Nodo = 'Addenda:requestForPayment:buyer:gln:gln'")
            writer.WriteElementString("gln", drNodo(0)("Valor"))
            writer.WriteEndElement() 'Fin buyer

            writer.WriteStartElement("seller")
            writer.WriteStartElement("alternatePartyIdentification")
            drNodo = dtCAFDetalle.Select("Nodo = 'Addenda:requestForPayment:seller:alternatePartyIdentification:type'")
            NuevoAtributo("type", drNodo(0)("Valor"), writer)
            drNodo = dtCAFDetalle.Select("Nodo = 'Addenda:requestForPayment:seller:alternatePartyIdentification:alternatePartyIdentification'")
            writer.WriteString(drNodo(0)("Valor"))
            writer.WriteEndElement() 'Fin alternatePartyIdentification
            writer.WriteEndElement() 'Fin seller

            writer.WriteStartElement("shipTo")
            writer.WriteStartElement("alternatePartyIdentification")
            drNodo = dtCAFDetalle.Select("Nodo = 'Addenda:requestForPayment:shipTo:alternatePartyIdentification:type'")
            NuevoAtributo("type", drNodo(0)("Valor"), writer)
            drNodo = dtCAFDetalle.Select("Nodo = 'Addenda:requestForPayment:shipTo:alternatePartyIdentification:alternatePartyIdentification'")
            writer.WriteString(drNodo(0)("Valor"))
            writer.WriteEndElement() 'Fin alternatePartyIdentification
            writer.WriteEndElement() 'Fin shipTo

            writer.WriteStartElement("currency")
            drNodo = dtCAFDetalle.Select("Nodo = 'Addenda:requestForPayment:currency:currencyISOCode'")
            NuevoAtributo("currencyISOCode", drNodo(0)("Valor"), writer)
            drNodo = dtCAFDetalle.Select("Nodo = 'Addenda:requestForPayment:currency:currencyFunction:currencyFunction'")
            writer.WriteElementString("currencyFunction", drNodo(0)("Valor"))
            drNodo = dtCAFDetalle.Select("Nodo = 'Addenda:requestForPayment:currency:rateOfChange:rateOfChange'")
            writer.WriteElementString("rateOfChange", drNodo(0)("Valor"))
            writer.WriteEndElement() 'Fin currency

            'If (paroTransProd.DescVendPor <> 0) Then
            '    writer.WriteStartElement("allowanceCharge") 'Descuento GLOBAL
            '    drNodo = dtCAFDetalle.Select("Nodo = 'Addenda:requestForPayment:allowanceCharge:allowanceChargeType'")
            '    NuevoAtributo("allowanceChargeType", drNodo(0)("Valor"), writer)
            '    drNodo = dtCAFDetalle.Select("Nodo = 'Addenda:requestForPayment:allowanceCharge:settlementType'")
            '    NuevoAtributo("settlementType", drNodo(0)("Valor"), writer)

            '    writer.WriteEndElement() 'Fin allowanceCharge
            'End If

            Dim oStringBuilder As New Text.StringBuilder
            oStringBuilder.Append("Select TPD.ProductoClave, PRO.CodigoBarras, PRO.Nombre, sum(TPD.Cantidad) as Cantidad, TPD.TipoUnidad, AVG(TPD.Precio) as PrecioBruto,")
            oStringBuilder.Append("avg(TPD.Precio -(TPD.DescuentoIMP/TPD.Cantidad)) as PrecioNeto, sum(TPD.Total) as Total, SUM(TPD.DescuentoImp ) as DescuentoImp,AVG(DescuentoPor),")
            oStringBuilder.Append("SUM(TPD.Total) as Total,avg(TPD.DescuentoIMP/TPD.Cantidad) ")
            oStringBuilder.Append("from TransProd TRP ")
            oStringBuilder.Append("inner join TransProdDetalle TPD on TRP.TransProdID = TPD.TransProdID ")
            oStringBuilder.Append("inner join Producto PRO on PRO.ProductoClave = TPD.ProductoClave ")
            oStringBuilder.Append("where TRP.Tipo=1 and TRP.FacturaID = '" & paroTransProd.TransProdID & "' ")
            oStringBuilder.Append("group by TPD.ProductoClave, PRO.CodigoBarras, PRO.Nombre, TPD.TipoUnidad ")


            Dim dtDetalles As DataTable = LbConexion.cConexion.Instancia.EjecutarConsulta(oStringBuilder.ToString())
            Dim i As Integer = 1
            For Each dr As DataRow In dtDetalles.Rows
                writer.WriteStartElement("lineItem")
                NuevoAtributo("type", "SimpleInvoiceLineItemType", writer)
                NuevoAtributo("number", i, writer)

                writer.WriteStartElement("tradeItemIdentification")
                'TODO: PANQUE tendra que poner codigoBarras a todos sus productos
                writer.WriteElementString("gtin", dr("CodigoBarras"))
                writer.WriteEndElement() 'fin tradeItemIdentification

                writer.WriteStartElement("tradeItemDescriptionInformation")
                NuevoAtributo("language", "ES", writer)
                writer.WriteElementString("longtext", dr("Nombre"))
                writer.WriteEndElement() 'fin tradeItemDescriptionInformation

                writer.WriteStartElement("invoicedQuantity")
                NuevoAtributo("unitOfMeasure", IIf(dr("TipoUnidad") = 1, "PCE", "CA"), writer)
                writer.WriteString(dr("Cantidad"))
                writer.WriteEndElement() 'fin invoicedQuantity

                writer.WriteEndElement() 'fin lineItem
                i += 1
            Next

            writer.WriteEndElement() 'Fin requestForPayment
            writer.WriteEndElement() 'Fin Addenda


            'writer.WriteEndDocument()

            'enmemoria.Position = 0
            'Dim sr As New StreamReader(enmemoria)
            'Dim sRes As String = sr.ReadToEnd()

            'writer.Flush()
            'writer.Close()
            'enmemoria.Flush()
            'enmemoria.Close()
            'Return sRes
            'If pvEnMemoria Then
            '    lnLength = enmemoria.Length
            'End If            

            'Return writer.ToString()
        Catch ex As LbControlError.cError
            Throw ex
        Catch ex As Exception
            If Not writer Is Nothing Then
                writer.Close()
            End If
            Throw New Exception(ex.Message)
        End Try

        'Return String.Empty
    End Sub

    Private Sub NuevoAtributo(ByRef parsAtribto As String, ByVal pvCadena As String, ByRef xml As XmlTextWriter)

        If pvCadena.Trim = "" Then Exit Sub

        xml.WriteAttributeString(parsAtribto, pvCadena)

    End Sub

    '    Private Function GenerarSoloAddenda(ByVal pvTRP As cTransProd, ByVal pvMultiple As Boolean, ByRef pvArhivoErrorAddenda As String, ByRef vlXML As cXML) As Boolean
    '        Dim NombreBitacora As String = String.Empty
    '#If DEBUG Then

    '        'If Not LbAddenda.Addenda.GenerarAddenda("server=localhost;database=Panque;uid=sa;pwd=Sql2008;timeout=30", vlXML.Archivo, pvTRP.Folio, NombreBitacora) Then
    '        '    If (pvMultiple) Then
    '        '        pvArhivoErrorAddenda &= NombreBitacora & ","
    '        '        Return False
    '        '    Else
    '        '        Throw New LbControlError.cError("I0212", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(NombreBitacora)})
    '        '    End If
    '        'End If

    '        If Not LbAddenda.Addenda.GenerarAddenda("server=192.168.0.149\sql2008;database=panque31703;uid=sa;pwd=dbsa;timeout=30", vlXML.Archivo, pvTRP.Folio, NombreBitacora) Then
    '            If (pvMultiple) Then
    '                pvArhivoErrorAddenda &= NombreBitacora & ","
    '                Return Nothing
    '            Else
    '                Throw New LbControlError.cError("I0212", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(NombreBitacora)})
    '            End If
    '        End If
    '#Else
    '        If Not LbAddenda.Addenda.GenerarAddenda(lbGeneral.cParametros.ConexionSQL, vlXML.Archivo, pvTRP.Folio, NombreBitacora) Then
    '            If (pvMultiple) Then
    '                pvArhivoErrorAddenda &= NombreBitacora & ","
    '                Return False
    '            Else
    '                Throw New LbControlError.cError("I0212", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(NombreBitacora)})
    '            End If
    '        End If
    '#End If
    '        Return True
    '    End Function

    Public Function GenerarSoloXML(ByRef vlXML As cXML, ByVal pvTRP As cTransProd, ByVal pvRuta As String, ByVal pvMultiple As Boolean, ByRef pvArhivoErrorAddenda As String, Optional ByVal pvBorrarXMLAuto As Boolean = False) As Boolean
        vlXML = Nothing
        If Not IO.Directory.Exists(pvRuta) Then
            Throw New LbControlError.cError("E0690", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(pvRuta)})
        End If

        vlXML = New cXML
        If vlXML.validarArchivo(pvTRP, pvRuta, pvBorrarXMLAuto) = False Then Return Nothing
        ObtenerXMLWriter(vlXML, False, pvTRP, pvRuta)

        Return True 'GenerarSoloAddenda(pvTRP, pvMultiple, pvArhivoErrorAddenda, vlXML)
    End Function

    Public Function GenerarXML(ByVal pvTRP As cTransProd, ByVal pvRuta As String, ByVal pvMultiple As Boolean, ByRef pvArchivoErrorEnvio As String, ByRef pvArhivoErrorAddenda As String, Optional ByVal pbEnviarXML As Boolean = True) As Boolean
        Dim vlXML As cXML = Nothing
        Try
            If Not GenerarSoloXML(vlXML, pvTRP, pvRuta, pvMultiple, pvArhivoErrorAddenda) Then
                Return False
            End If

            If pbEnviarXML Then
                EnviarXML(pvTRP, vlXML.Ruta, vlXML.NombreArchivo, pvMultiple, pvArchivoErrorEnvio)
            End If

            Return True
        Catch ex As LbControlError.cError
            Throw ex
        Catch ExcA As XmlException
            MsgBox(ExcA.Message, MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "GenerarXML")
        Catch ExcB As Exception
            If pvArchivoErrorEnvio.Length > 0 Then
                Throw New LbControlError.cError("I0211", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(pvArchivoErrorEnvio)})
            Else
                Throw New LbControlError.cError("E0690", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(pvRuta)})
            End If

        End Try
        If Not vlXML Is Nothing Then
            File.Delete(vlXML.Archivo)
        End If
        Return False
    End Function

    Public Function GenerarSoloXMLVersion3(ByRef vlXML As cXML, ByVal pvTRP As cTransProd, ByVal pvRuta As String, ByRef pvCFDI As CFDi, ByVal pvMultiple As Boolean, ByRef pvArhivoErrorAddenda As String, Optional ByRef bEstaSellado As Boolean = True, Optional ByVal pvBorrarXMLAuto As Boolean = False) As Boolean
        vlXML = Nothing
        If Not IO.Directory.Exists(pvRuta) Then
            Throw New LbControlError.cError("E0690", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(pvRuta)})
        End If
        vlXML = New cXML
        If vlXML.validarArchivo(pvTRP, pvRuta, pvBorrarXMLAuto) = False Then Return Nothing
        pvCFDI = ObtenerXMLWriterVersion3(vlXML, False, pvTRP, pvRuta, bEstaSellado)

        Return True 'GenerarSoloAddenda(pvTRP, pvMultiple, pvArhivoErrorAddenda, vlXML)
    End Function

    Public Function GenerarXMLVersion3(ByVal pvTRP As cTransProd, ByVal pvRuta As String, ByVal pvMultiple As Boolean, ByRef pvArchivoErrorEnvio As String, ByRef pvArhivoErrorAddenda As String, ByRef pvCFDI As CFDi, Optional ByRef bEstaSellado As Boolean = True, Optional ByVal pbEnviarAdenda As Boolean = True) As Boolean
        Dim vlXML As cXML = Nothing
        If Not IO.Directory.Exists(pvRuta) Then
            Throw New LbControlError.cError("E0690", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(pvRuta)})
        End If

        'Dim oCfdi As CFDi

        Try
            If Not GenerarSoloXMLVersion3(vlXML, pvTRP, pvRuta, pvCFDI, pvMultiple, pvArhivoErrorAddenda, bEstaSellado, Not bEstaSellado) Then
                Return False
            End If
        Catch ex As LbControlError.cError
            Throw ex
        Catch ExcA As XmlException
            MsgBox(ExcA.Message, MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "GenerarXML")
        Catch ExcW As CFDiException
            'File.Delete(vlXML.Archivo)
            Throw ExcW
        Catch ExcW As System.Net.WebException
            'File.Delete(vlXML.Archivo)
            Throw ExcW
        Catch ExeI As System.IO.IOException
            Throw New LbControlError.cError("E0690", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(pvRuta)})
        Catch ExcB As Exception
            Throw ExcB
        End Try

        Try

            If pbEnviarAdenda Then
                EnviarXML(pvTRP, vlXML.Ruta, vlXML.NombreArchivo, pvMultiple, pvArchivoErrorEnvio)
            End If


        Catch ex As LbControlError.cError
            Throw ex
        Catch ExcA As XmlException
            MsgBox(ExcA.Message, MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "GenerarXML")
        Catch ExcB As Exception
            Throw New LbControlError.cError("E0690", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(pvRuta)})
        End Try

        Return True

        'File.Delete(vlXML.Archivo)
        'Return Nothing
    End Function

    Public Function TipoXML() As String
        Dim lnLength As Long

        Try
            Dim vlValor As String
            Dim vlXML As New cXML


            If vlXML.validarArchivo(Me, "") = False Then Return False
            lnLength = ObtenerXMLWriter(vlXML, True, Me, "")

            vlValor = vgTipoXML & ", " & Math.Round((lnLength / 1024), 2).ToString() & " KB"

            Return vlValor
        Catch ExcA As XmlException
            MsgBox(ExcA.Message, MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "GenerarXML")
        Catch ex As IOException
            MsgBox(ex.Message())
        Catch ExcB As Exception
            MsgBox(ExcB.Message, MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "GenerarXML")
        End Try

        Return ""
    End Function

    Public Sub EnviarXML(ByVal pvTRP As cTransProd, ByVal pvRuta As String, ByVal pvArchivo As String, ByVal pvMultiple As Boolean, ByRef pvArchivoError As String)
        Dim sClienteClave As String = LbConexion.cConexion.Instancia.EjecutarComandoScalar("SELECT VIS.ClienteClave from TransProd TRP inner join Visita VIS on TRP.VisitaClave = VIS.visitaClave and TRP.DiaClave = VIS.DiaClave where TRP.TransProdId = '" & pvTRP.TransProdID & "'").ToString()

        Dim sArchivoPDF As String = Path.GetFileNameWithoutExtension(pvArchivo) & ".pdf"

        Dim oTrans As New LbTransferencia.cTransferencia


        Dim oArchivosAEnviar As LbTransferencia.cTransferencia.ArchivosAEnviar()
        If File.Exists(Path.Combine(pvRuta, sArchivoPDF)) Then
            oArchivosAEnviar = New LbTransferencia.cTransferencia.ArchivosAEnviar() {New LbTransferencia.cTransferencia.ArchivosAEnviar(pvRuta, pvArchivo), New LbTransferencia.cTransferencia.ArchivosAEnviar(pvRuta, sArchivoPDF)}
        Else
            oArchivosAEnviar = New LbTransferencia.cTransferencia.ArchivosAEnviar() {New LbTransferencia.cTransferencia.ArchivosAEnviar(pvRuta, pvArchivo)}
        End If


        Dim oCliente As New ERMCLILOG.cCliente()
        oCliente.Recuperar(sClienteClave)

        If oCliente.CorreoElectronico.Trim() <> "" Then

            Dim oConfig As New ERMCONLOG.cConfiguracion
            oConfig.Recuperar()
            Dim oMensaje As New BASMENLOG.CMensaje

            If Not oTrans.Transferir(oConfig.ServidorSMTP, oConfig.Password, oConfig.Puerto, oConfig.Correo, oCliente.CorreoElectronico.Trim(), oMensaje.RecuperarDescripcion("I0210"), "CFD " & pvTRP.Folio, oArchivosAEnviar, oConfig.SSL) Then
                pvArchivoError = oTrans.ArchivoLog
                Throw New Exception(oTrans.Error)
            End If

        End If

    End Sub

    Public Class cXML
        Dim vgConexion As LbConexion.cConexion = LbConexion.cConexion.Instancia
        Dim vlTDF As DataTable
        Dim vgTRP As cTransProd
        Dim vgRuta As String
        Dim vlDtTransProdDetalle As DataTable
        Dim vgImpuesto As ArrayList
        Dim vgTasa As ArrayList
        Dim vgImporte As ArrayList

#Region "CONSTANTES"
        Private Const amp As String = "&amp;" '&
        Private Const quot As String = "&quot;" '"
        Private Const lt As String = "&lt;" '<
        Private Const gt As String = "&gt;" '>
        Private Const apos As String = "&#36;" ''
#End Region

#Region "FUNCIONES"
        Private Function obtenerDetallesFactura(ByVal pvTransProdIDFactura As String) As DataTable
            Dim sConsulta As String

            'sConsulta = "select cantidad, tipoUnidad, productoClave, precio, (precio * cantidad) as importe from transprod t " & _
            '"inner join transproddetalle d on t.transprodid = d.transprodid " & _
            '"where facturaid = '" & pvTransProdIDFactura & "'"
            sConsulta = "select sum(cantidad) as cantidad, " & _
            "(select descripcion from vavdescripcion  where varcodigo = 'unidadv' and vavclave = d.tipounidad  and VADTipoLenguaje = dbo.FNObtenerLenguaje()) " & _
            "as unidad, pro.productoClave, precio, sum((precio * cantidad)) as importe, pro.nombre  " & _
            "from transprod t  " & _
            "inner join transproddetalle d on t.transprodid = d.transprodid  " & _
            "inner join producto PRO on pro.productoclave = d.productoclave  " & _
            "where t.tipo=1 and facturaid = '" & pvTransProdIDFactura & "' " & _
            "Group by pro.productoclave,d.tipounidad,precio,pro.nombre "

            Return vgConexion.EjecutarConsulta(sConsulta)
        End Function

        Private Function ObtenerDetallesNotaCredito(ByVal pvTransProdId As String) As DataTable
            Dim sConsulta As String
            sConsulta = "select TPD.Cantidad, VAD.Descripcion as Unidad, TPD.ProductoClave, TPD.Precio, TPD.Cantidad * TPD.Precio as Importe, PRO.Nombre " & _
            "from TransProd TRP " & _
            "inner join TransProdDetalle TPD on TRP.TransProdID = TPD.TransProdID " & _
            "inner join Producto PRO on TPD.ProductoClave = PRO.ProductoClave " & _
            "inner join VAVDescripcion VAD on VAD.VARCodigo = 'UNIDADV' and VAD.VAVClave = TPD.TipoUnidad and VAD.VADTipoLenguaje = dbo.FNObtenerLenguaje() " & _
            "where TRP.TransProdID = '" & pvTransProdId & "' "

            Return vgConexion.EjecutarConsulta(sConsulta)
        End Function

        Public Function ObtenerTRPDatoFiscal(ByVal pvTransprodId As String) As DataTable
            Dim vlConsulta As String = "Select * from TRPDatoFiscal where transprodid='" & pvTransprodId & "'"
            Return vgConexion.EjecutarConsulta(vlConsulta)
        End Function

        Private Function obtenerReferencia(ByVal pvCFVTipo As Integer, ByVal pvVarCodigo As String) As String
            Dim vlConsulta As String = "select Descripcion from vavdescripcion where varcodigo='" & pvVarCodigo & "' and VAVClave = " & pvCFVTipo & " And VADTipoLenguaje = dbo.FNObtenerLenguaje()"
            Dim vlDT As DataTable = vgConexion.EjecutarConsulta(vlConsulta)
            If vlDT Is Nothing OrElse vlDT.Rows.Count <= 0 Then Return ""

            Return vlDT.Rows(0).Item("Descripcion").ToString
        End Function

        Private Function obtenerNombreProducto(ByVal pvProductoClave As String) As String
            Dim vlConsulta As String = "Select nombre from producto where productoclave='" & pvProductoClave & "'"
            Dim vlDT As DataTable = vgConexion.EjecutarConsulta(vlConsulta)
            If vlDT Is Nothing OrElse vlDT.Rows.Count <= 0 Then Return ""


            Return vlDT.Rows(0).Item("nombre").ToString
        End Function

        Private Function obtenerTipodeComprobante() As String
            Dim vlConsulta As String = "select Descripcion from MENDetalle where MENClave ='XIngreso' and MEDTipoLenguaje =dbo.FNObtenerLenguaje()"
            Dim vlDT As DataTable = vgConexion.EjecutarConsulta(vlConsulta)
            If vlDT Is Nothing OrElse vlDT.Rows.Count <= 0 Then Return ""

            Return vlDT.Rows(0).Item("Descripcion").ToString
        End Function

        Public Function obtenerImpuesto(ByVal pvTransProdId As String) As DataTable
            Dim vlConsulta As String = "select sum(impuestoimp) as tasa, (select abreviatura from impuesto where impuesto.impuestoclave =tpdimpuesto.impuestoclave) as Abreviatura " & _
            "from tpdimpuesto where transprodid in (select transprodid from transprod where facturaid ='" & pvTransProdId & "') group by  impuestoclave "
            Return vgConexion.EjecutarConsulta(vlConsulta)

        End Function

        Private Function obtenerTPDDes(ByVal pvTransprodid As String) As DataTable
            Dim vlConsulta As String = "select transproddetalleid, DESImpuesto, 'TPDDes' as tipo from TPDDes where Transprodid in (select transprodid from transprod where facturaid ='" & pvTransprodid & "') " & _
            " union select transproddetalleid, DESImpuesto, 'TPDDesVendedor' as tipo from TPDDesVendedor where Transprodid in (select transprodid from transprod where facturaid ='" & pvTransprodid & "') "
            Dim vlDT As DataTable = vgConexion.EjecutarConsulta(vlConsulta)
            If vlDT Is Nothing OrElse vlDT.Rows.Count <= 0 Then Return Nothing

            Return vlDT
        End Function

        Private Function obtenerDesImpuesto(ByVal pvDt As DataTable, ByVal pvTransproddetalleid As String) As Double
            If pvDt Is Nothing Then Return 0

            Dim vlTpd As Double = 0
            For Each row As DataRow In pvDt.Select("transproddetalleid = '" & pvTransproddetalleid & "'")
                vlTpd += row("DesImpuesto")
            Next

            Return vlTpd
        End Function

        Private Function cadenaValida(ByVal pvCadena As String) As String
            Dim strValido As String = pvCadena
            strValido = strValido.Replace("&", amp).Trim()
            strValido = strValido.Replace("<", lt).Trim()
            strValido = strValido.Replace(">", gt).Trim()
            strValido = strValido.Replace("'", apos).Trim()

            strValido = strValido.Replace("""", quot).Trim()

            Return strValido
        End Function
#End Region

        Public Function validarArchivo(ByVal pvTRP As cTransProd, ByVal pvRuta As String, Optional ByVal pvBorrarXMLAuto As Boolean = False) As Boolean
            Dim oMensaje As New BASMENLOG.CMensaje

            If pvRuta = "" Then
                vgRuta = pvTRP.obtenerDirDocXML(pvTRP.SubEmpresaId)
            Else
                vgRuta = pvRuta
            End If

            vlTDF = ObtenerTRPDatoFiscal(pvTRP.TransProdID)
            If vlTDF Is Nothing OrElse vlTDF.Rows.Count <= 0 Then
                MsgBox(oMensaje.RecuperarDescripcion("I0132", New String() {"Informacion del <Dato Fiscal>", "Folio " & pvTRP.Folio}))
                Return False
            End If

            'TODO: Revisar por que se hacia esta llamada

            Dim sConsulta As New System.Text.StringBuilder
            Dim bImpuestoGlb As Boolean = False
            If pvTRP.Tipo = 8 Then
                sConsulta.AppendLine("select isnull(sum(case when TDI.ImpuestoPU is null or TDI.ImpDesGlb is null then 1 else 0 end), 0) as Nulos ")
                sConsulta.AppendLine("from TransProd TRP ")
                sConsulta.AppendLine("inner join TPDImpuesto TDI on TRP.TransProdID = TDI.TransProdID ")
                sConsulta.AppendLine("where TRP.FacturaID = '" & pvTRP.TransProdID & "' and TRP.Tipo = 1 ")
                bImpuestoGlb = (LbConexion.cConexion.Instancia.EjecutarComandoScalar(sConsulta.ToString) = 0)
            End If

            Dim sClienteClave As String
            Dim dFechaFactura As Date
            sConsulta = New System.Text.StringBuilder
            sConsulta.AppendLine("select VIS.ClienteClave, FAC.FechaHoraAlta ")
            sConsulta.AppendLine("from TransProd FAC ")
            sConsulta.AppendLine("inner join Visita VIS on FAC.VisitaClave = VIS.VisitaClave and FAC.DiaClave = VIS.DiaClave ")
            sConsulta.AppendLine("where FAC.TransProdID = '" & pvTRP.TransProdID & "'")
            Dim dtDatosFac As DataTable = LbConexion.cConexion.Instancia.EjecutarConsulta(sConsulta.ToString)
            sClienteClave = dtDatosFac.Rows(0)("ClienteClave")
            dFechaFactura = CType(dtDatosFac.Rows(0)("FechaHoraAlta"), Date)

            vgTRP = pvTRP
            If pvTRP.Tipo = 8 Then
                vlDtTransProdDetalle = obtenerDetallesFactura(pvTRP.TransProdID)
            Else
                vlDtTransProdDetalle = ObtenerDetallesNotaCredito(pvTRP.TransProdID)
            End If

            vgTRP.ImpuestosConDesc(vgTRP.TransProdID, sClienteClave, dFechaFactura, bImpuestoGlb, vgImpuesto, vgTasa, vgImporte)

            If File.Exists(Archivo) Then
                If pvBorrarXMLAuto OrElse MsgBox(oMensaje.RecuperarDescripcion("I0182", New String() {vgTRP.Folio & ".xml"}), MsgBoxStyle.Question + MsgBoxStyle.YesNo, oMensaje.RecuperarDescripcion("XMensajeP")) = MsgBoxResult.Yes Then
                    File.Delete(Archivo)
                    Return True
                End If
                Return False
            End If

            Return True
        End Function

#Region "PROPIEDADES"
        Public ReadOnly Property CantidadDetalle() As Integer
            Get
                Return vlDtTransProdDetalle.Rows.Count
            End Get
        End Property
        Public ReadOnly Property cantidadImpuestos() As Integer
            Get
                Return vgImpuesto.Count
            End Get
        End Property
        'COMPROBANTE
        Public ReadOnly Property version() As String
            Get
                Return cadenaValida(vlTDF.Rows(0).Item("TipoVersion").ToString)
            End Get
        End Property
        Public ReadOnly Property serie() As String
            Get
                Return cadenaValida(vlTDF.Rows(0).Item("serie").ToString)
            End Get
        End Property
        Public ReadOnly Property folio() As String
            Get
                Return cadenaValida(vgTRP.Folio)
            End Get
        End Property
        Public ReadOnly Property fecha() As String
            Get
                Dim vldate As Date
                vldate = CDate(vgTRP.FechaHoraAlta)

                Return cadenaValida(vldate.ToString("yyyy-MM-dd") & "T" & vldate.ToString("HH:mm:ss"))
            End Get
        End Property
        Public ReadOnly Property sello() As String
            Get
                Return cadenaValida(vlTDF.Rows(0).Item("sellodigital").ToString)
            End Get
        End Property
        Public ReadOnly Property noAprobacion() As String
            Get
                Return cadenaValida(vlTDF.Rows(0).Item("aprobacion").ToString)
            End Get
        End Property
        Public ReadOnly Property anoAprobacion() As String
            Get
                Return cadenaValida(vlTDF.Rows(0).Item("anioAprobacion"))
            End Get
        End Property
        Public ReadOnly Property formaPago() As String
            Get
                Return cadenaValida(obtenerReferencia(vgTRP.CFVTipo, "FVENTA"))
            End Get
        End Property
        Public ReadOnly Property noCertificado() As String
            Get
                Return cadenaValida(vlTDF.Rows(0).Item("numCertificado").ToString)
            End Get
        End Property
        Public ReadOnly Property subTotal() As String
            Get

                Dim vlConsulta As String = "select sum(d.cantidad*d.precio ) as subtotal from transprod t " & _
                "inner join transproddetalle d on t.transprodid = d.transprodid where t.facturaid='" & vgTRP.TransProdID & "' "
                If vgTRP.Tipo = 8 Then
                    vlConsulta += " and t.tipo=1 "
                Else
                    vlConsulta += " and t.tipo=10 "
                End If
                Dim vlDT As DataTable = vgConexion.EjecutarConsulta(vlConsulta)
                If vlDT Is Nothing Then Return 0
                If IsDBNull(vlDT.Rows(0).Item("subtotal")) Then Return 0

                Return cadenaValida(Math.Round(vlDT.Rows(0).Item("subtotal"), 2))
            End Get
        End Property
        Public ReadOnly Property descuento() As String
            Get
                Dim vlConsulta As String = "select sum(descuento) as descuento " & _
                "from(select t.DescuentoImp + t.DescuentoVendedor + sum(d.descuentoimp) as descuento from transprod t " & _
                "inner join transproddetalle d on t.transprodid = d.transprodid where t.facturaid='" & vgTRP.TransProdID & "' " & IIf(vgTRP.Tipo = 8, " and t.Tipo=1 ", " and t.Tipo=10 ") & " group by  t.DescuentoImp, t.DescuentoVendedor) as t"
                Dim vlDT As DataTable = vgConexion.EjecutarConsulta(vlConsulta)
                If vlDT Is Nothing OrElse vlDT.Rows.Count = 0 Then Return 0
                If IsDBNull(vlDT.Rows(0).Item("descuento")) Then Return 0

                Return cadenaValida(Math.Round(vlDT.Rows(0).Item("descuento"), 2))
            End Get
        End Property
        Public ReadOnly Property total() As String
            Get
                Return cadenaValida(vgTRP.Total)
            End Get
        End Property
        Public ReadOnly Property tipoComprobante() As String
            Get
                Return cadenaValida(obtenerTipodeComprobante())
            End Get
        End Property
        'EMISOR
        Public ReadOnly Property EmNombre() As String
            Get
                Return cadenaValida(vlTDF.Rows(0).Item("NombreEm").ToString)
            End Get
        End Property
        Public ReadOnly Property EmRFC() As String
            Get
                Return cadenaValida(vlTDF.Rows(0).Item("RFCEm").ToString)
            End Get
        End Property
        Public ReadOnly Property EmCalle() As String
            Get
                Return cadenaValida(vlTDF.Rows(0).Item("calleEm").ToString)
            End Get
        End Property
        Public ReadOnly Property EmNumExt() As String
            Get
                Return cadenaValida(vlTDF.Rows(0).Item("NumExtEm").ToString)
            End Get
        End Property
        Public ReadOnly Property EmNumInt() As String
            Get
                Return cadenaValida(vlTDF.Rows(0).Item("NumIntEm").ToString())
            End Get
        End Property
        Public ReadOnly Property EmColonia() As String
            Get
                Return cadenaValida(vlTDF.Rows(0).Item("ColoniaEm").ToString)
            End Get
        End Property
        Public ReadOnly Property emLocalidad() As String
            Get
                Return cadenaValida(vlTDF.Rows(0).Item("LocalidadEm").ToString)
            End Get
        End Property
        Public ReadOnly Property emMunicipio() As String
            Get
                Return cadenaValida(vlTDF.Rows(0).Item("MunicipioEm").ToString)
            End Get
        End Property
        Public ReadOnly Property emEstado() As String
            Get
                Return cadenaValida(vlTDF.Rows(0).Item("RegionEm").ToString)
            End Get
        End Property
        Public ReadOnly Property emPais() As String
            Get
                Return cadenaValida(vlTDF.Rows(0).Item("PaisEm").ToString)
            End Get
        End Property
        Public ReadOnly Property emCodigoPostal() As String
            Get
                Return cadenaValida(vlTDF.Rows(0).Item("CodigoPostalEm").ToString)
            End Get
        End Property
        Public ReadOnly Property emReferencia() As String
            Get
                Return cadenaValida(vlTDF.Rows(0).Item("ReferenciaDomEm").ToString())
            End Get
        End Property
        'Expedido en
        Public ReadOnly Property ExCalle() As String
            Get
                Return cadenaValida(vlTDF.Rows(0).Item("calleEx").ToString())
            End Get
        End Property
        Public ReadOnly Property ExNumExt() As String
            Get
                Return cadenaValida(vlTDF.Rows(0).Item("NumExtEx").ToString)
            End Get
        End Property
        Public ReadOnly Property ExNumInt() As String
            Get
                Return cadenaValida(vlTDF.Rows(0).Item("NumIntEx").ToString)
            End Get
        End Property
        Public ReadOnly Property ExColonia() As String
            Get
                Return cadenaValida(vlTDF.Rows(0).Item("ColoniaEx").ToString)
            End Get
        End Property
        Public ReadOnly Property ExLocalidad() As String
            Get
                Return cadenaValida(vlTDF.Rows(0).Item("LocalidadEx").ToString)
            End Get
        End Property
        Public ReadOnly Property ExMunicipio() As String
            Get
                Return cadenaValida(vlTDF.Rows(0).Item("MunicipioEx").ToString)
            End Get
        End Property
        Public ReadOnly Property ExEstado() As String
            Get
                Return cadenaValida(vlTDF.Rows(0).Item("EntidadEx").ToString)
            End Get
        End Property
        Public ReadOnly Property ExPais() As String
            Get
                Return cadenaValida(vlTDF.Rows(0).Item("PaisEx").ToString)
            End Get
        End Property
        Public ReadOnly Property ExCodigoPostal() As String
            Get
                Return cadenaValida(vlTDF.Rows(0).Item("CodigoPostalEx").ToString)
            End Get
        End Property
        Public ReadOnly Property ExReferencia() As String
            Get
                Return cadenaValida(vlTDF.Rows(0).Item("ReferenciaDomEx").ToString)
            End Get
        End Property
        'RECEPTOR
        Public ReadOnly Property ReNombre() As String
            Get
                Return cadenaValida(vlTDF.Rows(0).Item("RazonSocial").ToString)
            End Get
        End Property
        Public ReadOnly Property ReRFC() As String
            Get
                Return cadenaValida(vlTDF.Rows(0).Item("RFC").ToString)
            End Get
        End Property
        Public ReadOnly Property ReCalle() As String
            Get
                Return cadenaValida(vlTDF.Rows(0).Item("Calle").ToString)
            End Get
        End Property
        Public ReadOnly Property ReNumExt() As String
            Get
                Return cadenaValida(vlTDF.Rows(0).Item("NumExt").ToString)
            End Get
        End Property
        Public ReadOnly Property ReNumInt() As String
            Get
                Return cadenaValida(vlTDF.Rows(0).Item("NumInt").ToString)
            End Get
        End Property
        Public ReadOnly Property ReColonia() As String
            Get
                Return cadenaValida(vlTDF.Rows(0).Item("Colonia").ToString)
            End Get
        End Property
        Public ReadOnly Property ReLocalidad() As String
            Get

                Return cadenaValida(vlTDF.Rows(0).Item("Localidad").ToString)
            End Get
        End Property
        Public ReadOnly Property ReMunicipio() As String
            Get
                Return cadenaValida(vlTDF.Rows(0).Item("Municipio").ToString)
            End Get
        End Property
        Public ReadOnly Property ReEstado() As String
            Get
                Return cadenaValida(vlTDF.Rows(0).Item("Entidad").ToString)
            End Get
        End Property
        Public ReadOnly Property RePais() As String
            Get
                Return cadenaValida(vlTDF.Rows(0).Item("Pais").ToString)
            End Get
        End Property
        Public ReadOnly Property ReCodigoPostal() As String
            Get
                Return cadenaValida(vlTDF.Rows(0).Item("CodigoPostal").ToString)
            End Get
        End Property
        Public ReadOnly Property ReReferencia() As String
            Get
                Return cadenaValida(vlTDF.Rows(0).Item("ReferenciaDom").ToString)
            End Get
        End Property
        'CONCEPTOS
        Public ReadOnly Property cantidad(ByVal pvIndice As Integer) As String
            Get
                Return vlDtTransProdDetalle.Rows(pvIndice).Item("cantidad")
            End Get
        End Property
        Public ReadOnly Property unidad(ByVal pvIndice As Integer) As String
            Get
                Return cadenaValida(vlDtTransProdDetalle.Rows(pvIndice).Item("Unidad"))
                'Return cadenaValida(obtenerReferencia(vlDtTransProdDetalle.Rows(pvIndice).Item("tipoUnidad"), "UNIDADV"))
            End Get
        End Property
        Public ReadOnly Property noIdentificacion(ByVal pvIndice As Integer) As String
            Get
                Return vlDtTransProdDetalle.Rows(pvIndice).Item("productoclave")
            End Get
        End Property
        Public ReadOnly Property descripcion(ByVal pvIndice As Integer) As String
            Get
                Return cadenaValida(vlDtTransProdDetalle.Rows(pvIndice).Item("nombre"))
                'Return cadenaValida(obtenerNombreProducto(vlDtTransProdDetalle.Rows(pvIndice).Item("productoclave")))
            End Get
        End Property
        Public ReadOnly Property valorUnitario(ByVal pvIndice As Integer) As String
            Get
                Return Math.Round(vlDtTransProdDetalle.Rows(pvIndice).Item("precio"), 2)
            End Get
        End Property
        Public ReadOnly Property importe(ByVal pvIndice As Integer) As String
            Get
                Return Math.Round(vlDtTransProdDetalle.Rows(pvIndice).Item("importe"), 2)
            End Get
        End Property

        Public ReadOnly Property totalImpuestoTraslado() As String
            Get
                Dim vlTotalImpuestosTraslado As Double
                For Each suma As Double In Me.vgImporte
                    vlTotalImpuestosTraslado += suma
                Next

                'Dim vlDT As DataTable = obtenerTPDDes(vgTRP.TransProdID)

                'For Each vlTPD As cTransProdDetalle In vgTRP.TransProdDetalle.ToArrayList
                '    vlTotalImpuestosTraslado += (vlTPD.Impuesto - obtenerDesImpuesto(vlDT, vlTPD.TransProdDetalleID))
                'Next
                Return Math.Round(vlTotalImpuestosTraslado, 2)
            End Get
        End Property
        Public ReadOnly Property OP_Impuesto(ByVal pvIndice As Integer) As String
            Get
                Return vgImpuesto(pvIndice)
            End Get
        End Property
        Public ReadOnly Property OP_Tasa(ByVal pvIndice As Integer) As String
            Get
                Return vgTasa(pvIndice)
            End Get
        End Property
        Public ReadOnly Property OP_Importe(ByVal pvIndice As Integer) As String
            Get
                Return vgImporte(pvIndice)
            End Get
        End Property

        Public ReadOnly Property Ruta() As String
            Get
                Return vgRuta
            End Get
        End Property

        Public ReadOnly Property NombreArchivo() As String
            Get
                Return vgTRP.Folio & ".xml"
            End Get
        End Property

        Public ReadOnly Property Archivo() As String
            Get
                Return vgRuta & "\" & vgTRP.Folio & ".xml"
            End Get
        End Property
#End Region

    End Class
#End Region

#Region "ImpuestosConDesc"

    Public Sub ImpuestosConDesc(ByVal TransProdIDFactura As String, ByVal ClienteClave As String, ByVal FechaFactura As Date, ByVal ImpuestosGlb As Boolean, ByRef Impuesto As ArrayList, ByRef Tasa As ArrayList, ByRef Importe As ArrayList)
        Dim vlConsulta As New Text.StringBuilder
        Dim vldt As DataTable
        Impuesto = New ArrayList
        Tasa = New ArrayList
        Importe = New ArrayList

        vlConsulta.AppendLine("select Tipo from TransProd where TransProdId = '" & TransProdIDFactura & "'")
        Dim nTipo As Integer = Me.Tabla.Conexion.EjecutarComandoScalar(vlConsulta.ToString)

        vlConsulta = New Text.StringBuilder
        If ImpuestosGlb Then

            vlConsulta.AppendLine("select IMP.ImpuestoClave, IMP.Abreviatura, TDI.ImpuestoPor, sum(TDI.ImpDesGlb) as ImpDesGlb ")
            vlConsulta.AppendLine("from TPDImpuesto TDI ")
            vlConsulta.AppendLine("inner join TransProd TRP on TDI.TransProdID = TRP.TransProdID ")
            vlConsulta.AppendLine("inner join Impuesto IMP on TDI.ImpuestoClave = IMP.ImpuestoClave ")
            'vlConsulta.AppendLine("where TRP.FacturaId = '" & TransProdIDFactura & "' and Trp.Tipo = 1 ")
            vlConsulta.AppendLine("where " & IIf(nTipo = 8, " TRP.Tipo=1 and  TRP.FacturaId", " TRP.Tipo=10 and TRP.TransProdId") & " = '" & TransProdIDFactura & "'  ")
            vlConsulta.AppendLine("and TDI.ImpuestoClave not in ( ")
            vlConsulta.AppendLine("select ImpuestoClave ")
            vlConsulta.AppendLine("from CLINoDesImp ")
            vlConsulta.AppendLine("where ClienteClave = '" & ClienteClave & "' and '" & FechaFactura.ToString("s") & "' between FechaInicio and FechaFin) ")
            vlConsulta.AppendLine("group by IMP.ImpuestoClave, IMP.Abreviatura, TDI.ImpuestoPor, IMP.Jerarquia ")
            vlConsulta.AppendLine("order by IMP.Jerarquia ")

            vldt = Me.Tabla.Conexion.EjecutarConsulta(vlConsulta.ToString)
            For Each row As DataRow In vldt.Rows
                Impuesto.Add(row("Abreviatura"))
                Tasa.Add(row("ImpuestoPor"))
                Importe.Add(row("ImpDesGlb"))
            Next
            vldt.Dispose()
            vldt = Nothing
            vlConsulta = Nothing

        Else

            If PermiteCascada("where " & IIf(nTipo = 8, " trp.Tipo=1 and FacturaId", " trp.Tipo=10 and TransProdId") & " = '" & TransProdIDFactura & "'") = True Then
                vlConsulta.AppendLine("select imp.impuestoclave, imp.abreviatura, imp.jerarquia from transprod trp ")
                vlConsulta.AppendLine("inner join tpdImpuesto tpi on trp.transprodid = tpi.transprodid ")
                vlConsulta.AppendLine("inner join impuesto imp on tpi.impuestoclave = imp.impuestoclave ")
                vlConsulta.AppendLine("where " & IIf(nTipo = 8, " trp.Tipo=1 and  trp.FacturaId", " trp.Tipo=10 and trp.TransProdId") & " = '" & TransProdIDFactura & "' group by imp.impuestoclave, imp.abreviatura, imp.jerarquia order by imp.jerarquia")
                Dim dtImpuesto As DataTable = Me.Tabla.Conexion.EjecutarConsulta(vlConsulta.ToString)

                For Each row As DataRow In dtImpuesto.Rows
                    vlConsulta = New Text.StringBuilder
                    vlConsulta.AppendLine("select t.transprodid, d.transproddetalleid, subTdetalle, d.subtotal, descuentopor, imp.impuestopor, imp.impuestoimp, isnull(descvendpor,0)  as descvendpor from transprod t ")
                    vlConsulta.AppendLine("inner join transproddetalle d on t.transprodid = d.transprodid ")
                    vlConsulta.AppendLine("inner join tpdimpuesto imp on imp.transprodid = d.transprodid and imp.transproddetalleid = d.transproddetalleid ")
                    vlConsulta.AppendLine("where " & IIf(nTipo = 8, " t.Tipo=1 and  t.FacturaId", " t.Tipo=10 and t.TransProdId") & " = '" & TransProdIDFactura & "' and imp.impuestoclave = '" & row("impuestoclave") & "' ")
                    Dim dtTrp As DataTable = Me.Tabla.Conexion.EjecutarConsulta(vlConsulta.ToString)

                    vlConsulta = New Text.StringBuilder
                    vlConsulta.AppendLine("select d.transprodid, d.transproddetalleid, tp.despor, d.subtotal, imp.impuestopor, t.descvendpor from transprod t ")
                    vlConsulta.AppendLine("inner join transproddetalle d on t.transprodid = d.transprodid ")
                    vlConsulta.AppendLine("inner join tpdimpuesto imp on imp.transprodid = d.transprodid and imp.transproddetalleid = d.transproddetalleid ")
                    vlConsulta.AppendLine("inner join tpddes tp on imp.transprodid = tp.transprodid and imp.transproddetalleid = tp.transproddetalleid ")
                    vlConsulta.AppendLine("where " & IIf(nTipo = 8, " t.Tipo=1 and  t.FacturaId", " t.Tipo=10 and t.TransProdId") & " = '" & TransProdIDFactura & "' and imp.impuestoclave = '" & row("impuestoclave") & "' ")
                    vlConsulta.AppendLine("order by d.transproddetalleid, tp.jerarquia ")
                    Dim dtDesCliente As DataTable = Me.Tabla.Conexion.EjecutarConsulta(vlConsulta.ToString)

                    Dim lImpuestoImpT As Double = 0
                    Dim limpuestoPor As Double = 0
                    Dim lDesClienteT As Double = 0
                    Dim lDesVendedorT As Double = 0

                    For Each rowTrp As DataRow In dtTrp.Rows
                        Dim lDesClienteT1 As Double = 0
                        Dim lImpuestoImp As Double = 0
                        lImpuestoImp = rowTrp("impuestoimp")

                        For Each rowDesCliente As DataRow In dtDesCliente.Select(" transprodid = '" & rowTrp("Transprodid") & "' and Transproddetalleid = '" & rowTrp("transproddetalleid") & "'")
                            Dim lDesCliente As Double = 0

                            lDesCliente = lImpuestoImp * rowDesCliente("despor") / 100
                            lImpuestoImp = lImpuestoImp - lDesCliente

                            lDesClienteT1 += lDesCliente
                        Next

                        lDesClienteT += lDesClienteT1
                        lImpuestoImpT += rowTrp("impuestoimp")
                        limpuestoPor = rowTrp("impuestopor")

                        lDesVendedorT += (rowTrp("impuestoimp") - lDesClienteT1) * rowTrp("descvendpor") / 100
                    Next

                    Impuesto.Add(row("abreviatura"))
                    Tasa.Add(limpuestoPor)
                    Importe.Add(Math.Round(lImpuestoImpT - lDesClienteT - lDesVendedorT, 2))
                Next

            Else

                vlConsulta = New Text.StringBuilder
                vlConsulta.AppendLine("select abreviatura, impuestopor as tasa, ")
                vlConsulta.AppendLine(IIf(nTipo = 8, "  sum(((tpi.ImpuestoImp)-(tpi.ImpuestoImp*isnull(td.DesPor,0)/100))-(((tpi.ImpuestoImp)-(tpi.ImpuestoImp*(isnull(td.DesPor,0)/100)))*(trp.DescVendPor / 100))) AS importe ", " sum(tpi.ImpuestoImp) as importe "))
                vlConsulta.AppendLine("from transprod trp ")
                vlConsulta.AppendLine("inner join transproddetalle tpd on trp.transprodid =tpd.transprodid ")
                vlConsulta.AppendLine("inner join tpdimpuesto tpi on tpi.transprodid =tpd.transprodid and tpi.transproddetalleid =tpd.transproddetalleid ")
                vlConsulta.AppendLine("inner join impuesto imp on tpi.impuestoclave = imp.impuestoclave ")
                vlConsulta.AppendLine("LEFT OUTER JOIN tpddes td on td.transprodid=tpd.transprodid and td.transproddetalleid = tpd.transproddetalleid where ")
                vlConsulta.AppendLine(IIf(nTipo = 8, " trp.Tipo=1 and  trp.FacturaId", " trp.Tipo=10 and trp.TransProdId") & " = '" & TransProdIDFactura & "' ")
                vlConsulta.AppendLine("group by abreviatura,impuestopor,IMP.Jerarquia order by IMP.Jerarquia ")

                Try
                    vldt = Me.Tabla.Conexion.EjecutarConsulta(vlConsulta.ToString)
                    For Each row As DataRow In vldt.Rows
                        Impuesto.Add(row("abreviatura"))
                        Tasa.Add(row("tasa"))
                        Importe.Add(row("importe"))
                    Next
                    vldt.Dispose()
                    vldt = Nothing
                    vlConsulta = Nothing

                Catch ex As Exception

                End Try
            End If
        End If
    End Sub

    Public Sub ImpuestosConDesc(ByVal TransProdID As ArrayList, ByVal ClienteClave As String, ByVal Fecha As Date, ByVal ImpuestosGlb As Boolean, ByRef Impuesto As ArrayList, ByRef Tasa As ArrayList, ByRef Importe As ArrayList)
        Dim vlconsulta As New Text.StringBuilder
        Dim vlCondicion As String = ""
        Dim vldt As DataTable
        Impuesto = New ArrayList
        Tasa = New ArrayList
        Importe = New ArrayList

        If TransProdID.Count > 0 Then
            vlCondicion = "where TRP.TransProdId in ("
            For i As Integer = 0 To TransProdID.Count - 1
                vlCondicion &= "'" & TransProdID.Item(i) & "',"
            Next
            vlCondicion = vlCondicion.Remove(vlCondicion.Length - 1, 1)
            vlCondicion &= ")"
        Else
            vlCondicion = "where 1=1 "
        End If

        If ImpuestosGlb Then
            vlconsulta.AppendLine("select IMP.ImpuestoClave, IMP.Abreviatura, TDI.ImpuestoPor, sum(ImpDesGlb) as ImpDesGlb ")
            vlconsulta.AppendLine("from TPDImpuesto TDI ")
            vlconsulta.AppendLine("inner join TransProd TRP on TDI.TransProdID = TRP.TransProdID ")
            vlconsulta.AppendLine("inner join Impuesto IMP on TDI.ImpuestoClave = IMP.ImpuestoClave ")
            vlconsulta.AppendLine(vlCondicion)
            vlconsulta.AppendLine("and TDI.ImpuestoClave not in ( ")
            vlconsulta.AppendLine("select ImpuestoClave ")
            vlconsulta.AppendLine("from CLINoDesImp ")
            vlconsulta.AppendLine("where ClienteClave = '" & ClienteClave & "' and '" & Fecha.ToString("s") & "' between FechaInicio and FechaFin) ")
            vlconsulta.AppendLine("group by IMP.ImpuestoClave, IMP.Abreviatura, TDI.ImpuestoPor, IMP.Jerarquia ")
            vlconsulta.AppendLine("order by IMP.Jerarquia ")

            vldt = Me.Tabla.Conexion.EjecutarConsulta(vlconsulta.ToString)
            For Each row As DataRow In vldt.Rows
                Impuesto.Add(row("Abreviatura"))
                Tasa.Add(row("ImpuestoPor"))
                Importe.Add(row("ImpDesGlb"))
            Next
            vldt.Dispose()
            vldt = Nothing
            vlconsulta = Nothing
        Else
            If PermiteCascada(vlCondicion) = True Then

                vlconsulta.AppendLine("select imp.impuestoclave, imp.abreviatura, imp.jerarquia from transprod trp ")
                vlconsulta.AppendLine("inner join tpdImpuesto tpi on trp.transprodid = tpi.transprodid ")
                vlconsulta.AppendLine("inner join impuesto imp on tpi.impuestoclave = imp.impuestoclave ")
                vlconsulta.AppendLine(vlCondicion & " group by imp.impuestoclave, imp.abreviatura, imp.jerarquia order by imp.jerarquia ")
                Dim dtImpuesto As DataTable = Me.Tabla.Conexion.EjecutarConsulta(vlconsulta.ToString)

                For Each row As DataRow In dtImpuesto.Rows
                    vlconsulta = New Text.StringBuilder
                    vlconsulta.AppendLine("select trp.transprodid, d.transproddetalleid, subTdetalle, d.subtotal, descuentopor, imp.impuestopor, imp.impuestoimp, isnull(descvendpor,0)  as descvendpor ")
                    vlconsulta.AppendLine("from transprod trp ")
                    vlconsulta.AppendLine("inner join transproddetalle d on trp.transprodid = d.transprodid ")
                    vlconsulta.AppendLine("inner join tpdimpuesto imp on imp.transprodid = d.transprodid and imp.transproddetalleid = d.transproddetalleid ")
                    vlconsulta.AppendLine(vlCondicion & " and imp.impuestoclave = '" & row("impuestoclave") & "' ")
                    Dim dtTrp As DataTable = Me.Tabla.Conexion.EjecutarConsulta(vlconsulta.ToString)

                    vlconsulta = New Text.StringBuilder
                    vlconsulta.AppendLine("select d.transprodid, d.transproddetalleid, tp.despor, d.subtotal, imp.impuestopor, isnull(trp.descvendpor,0) as descvendpor from transprod trp ")
                    vlconsulta.AppendLine("inner join transproddetalle d on trp.transprodid = d.transprodid ")
                    vlconsulta.AppendLine("inner join tpdimpuesto imp on imp.transprodid = d.transprodid and imp.transproddetalleid = d.transproddetalleid ")
                    vlconsulta.AppendLine("inner join tpddes tp on imp.transprodid = tp.transprodid and imp.transproddetalleid = tp.transproddetalleid ")
                    vlconsulta.AppendLine(vlCondicion & " and imp.impuestoclave = '" & row("impuestoclave") & "' order by d.transproddetalleid, tp.jerarquia ")
                    Dim dtDesCliente As DataTable = Me.Tabla.Conexion.EjecutarConsulta(vlconsulta.ToString)

                    Dim lImpuestoImpT As Double = 0
                    Dim limpuestoPor As Double = 0
                    Dim lDesClienteT As Double = 0
                    Dim lDesVendedorT As Double = 0

                    For Each rowTrp As DataRow In dtTrp.Rows
                        Dim lDesClienteT1 As Double = 0
                        Dim lImpuestoImp As Double = 0
                        lImpuestoImp = rowTrp("impuestoimp")

                        For Each rowDesCliente As DataRow In dtDesCliente.Select(" transprodid = '" & rowTrp("Transprodid") & "' and Transproddetalleid = '" & rowTrp("transproddetalleid") & "'")
                            Dim lDesCliente As Double = 0

                            lDesCliente = lImpuestoImp * rowDesCliente("despor") / 100
                            lImpuestoImp = lImpuestoImp - lDesCliente

                            lDesClienteT1 += lDesCliente
                        Next

                        lDesClienteT += lDesClienteT1
                        lImpuestoImpT += rowTrp("impuestoimp")
                        limpuestoPor = rowTrp("impuestopor")

                        lDesVendedorT += (rowTrp("impuestoimp") - lDesClienteT1) * rowTrp("descvendpor") / 100
                    Next

                    Impuesto.Add(row("abreviatura"))
                    Tasa.Add(limpuestoPor)
                    Importe.Add(Math.Round(lImpuestoImpT - lDesClienteT - lDesVendedorT, 2))

                Next

            Else

                vlconsulta = New Text.StringBuilder
                vlconsulta.AppendLine("select abreviatura, impuestopor as tasa, ")
                vlconsulta.AppendLine("sum(((tpi.ImpuestoImp)-(tpi.ImpuestoImp*isnull(td.DesPor,0)/100))-(((tpi.ImpuestoImp)-(tpi.ImpuestoImp*(isnull(td.DesPor,0)/100)))*(trp.DescVendPor / 100))) AS importe ")
                vlconsulta.AppendLine("from transprod trp ")
                vlconsulta.AppendLine("inner join transproddetalle tpd on trp.transprodid =tpd.transprodid ")
                vlconsulta.AppendLine("inner join tpdimpuesto tpi on tpi.transprodid =tpd.transprodid and tpi.transproddetalleid =tpd.transproddetalleid ")
                vlconsulta.AppendLine("inner join impuesto imp on tpi.impuestoclave = imp.impuestoclave ")
                vlconsulta.AppendLine("left outer join tpddes td on td.transprodid=tpd.transprodid and td.transproddetalleid = tpd.transproddetalleid ")
                vlconsulta.AppendLine(vlCondicion & " group by abreviatura,impuestopor,IMP.Jerarquia order by IMP.Jerarquia ")

                Try
                    Dim iTimeout As Integer = lbGeneral.cParametros.TimeOut
                    If iTimeout < 0 Then iTimeout = 0

                    vldt = Me.Tabla.Conexion.EjecutarConsulta(vlconsulta.ToString, iTimeout)
                    For Each row As DataRow In vldt.Rows
                        Impuesto.Add(row("abreviatura"))
                        Tasa.Add(row("tasa"))
                        Importe.Add(row("importe"))
                    Next
                    vldt.Dispose()
                    vldt = Nothing
                    vlconsulta = Nothing

                Catch ex As Exception

                End Try
            End If
        End If

    End Sub
#End Region

#Region "CadenaOriginalE"
    Private Function sValido(ByVal pvCadena As String) As String
        Dim strValido As String

        If pvCadena.Trim() = "" Then Return ""

        strValido = pvCadena.Replace("|", "/")
        strValido = strValido.Replace(ControlChars.Tab, " "c)
        strValido = strValido.Replace(ControlChars.Lf, " "c)
        Dim Arreglo As String() = strValido.Split(" "c)
        strValido = ""
        For Each a As String In Arreglo
            If a <> "" Then strValido += a & " "
        Next

        Return strValido.Trim() & "|"
    End Function

    Private Function sValidoV3(ByVal pvCadena As String) As String
        Dim strValido As String

        If pvCadena.Trim() = "" Then Return ""

        strValido = pvCadena.Replace("|", "/")
        strValido = strValido.Replace(ControlChars.Tab, " "c)
        strValido = strValido.Replace(ControlChars.Lf, " "c)
        Dim Arreglo As String() = strValido.Split(" "c)
        strValido = ""
        For Each a As String In Arreglo
            If a <> "" Then strValido += a & " "
        Next
        If (strValido.Trim() = "") Then
            Return ""
        Else
            Return strValido.Trim() & "|"
        End If

    End Function

    Public Function dValido(ByVal pvCadena As Object, Optional ByVal bXML As Boolean = False) As String
        If pvCadena.ToString = "" Then Return ""

        Return Format(pvCadena, "0.00") & IIf(bXML, "", "|")
    End Function

    Private Function fValido(ByVal parFecha As Date) As String
        Return parFecha.ToString("s") + "|"
    End Function


    Private Function fValidoVersion3(ByVal parFecha As Date) As String

        'Tralix GMT -5
        'If (parFecha.IsDaylightSavingTime) Then 'AMESOL
        '    parFecha = parFecha.AddMinutes(-10)
        'Else
        '    parFecha = parFecha.AddMinutes(-10)
        'End If
        If (parFecha.IsDaylightSavingTime) Then
            parFecha = parFecha.ToUniversalTime.AddHours(-6)
        Else
            parFecha = parFecha.ToUniversalTime.AddHours(-6)
        End If

        Return parFecha.ToString("s") + "|"
    End Function

    Private Sub obtenerSubtotales(ByVal parsClienteClave As String, ByVal parbImpuestoGlb As Boolean, ByRef parSubTotal As Decimal, ByRef parTotal As Decimal, ByRef parDescuento As Decimal, ByVal dFechaFactura As Date) ', ByVal parTransProdIds As ArrayList)
        Dim vlConsulta As New System.Text.StringBuilder
        Dim vlDt As DataTable
        parSubTotal = 0
        parTotal = 0
        parDescuento = 0

        If parbImpuestoGlb Then
            vlConsulta.AppendLine("set nocount on ")
            vlConsulta.AppendLine("if (select object_id('tempdb..#TmpImp')) is not null drop table #TmpImp ")
            vlConsulta.AppendLine("select * into #TmpImp from ( ")
            vlConsulta.AppendLine("select TDI.TransProdID, TDI.TransProdDetalleID, sum(TDI.ImpuestoPU) as ImpuestoPU, SUM(TDI.ImpDesGlb) as ImpDesGlb ")
            vlConsulta.AppendLine("from TPDImpuesto TDI ")
            vlConsulta.AppendLine("inner join TransProd TRP on TDI.TransProdID = TRP.TransProdID ")
            If Me.Tipo = 8 Then
                vlConsulta.AppendLine("where TRP.FacturaId = '" & Me.TransProdID & "' and TRP.Tipo = 1 and TDI.ImpuestoClave in ( ")
            Else
                vlConsulta.AppendLine("where TRP.TransProdId = '" & Me.TransProdID & "' and TRP.Tipo = 10 and TDI.ImpuestoClave in ( ")
            End If
            vlConsulta.AppendLine("select ImpuestoClave ")
            vlConsulta.AppendLine("from CLINoDesImp ")
            vlConsulta.AppendLine("where ClienteClave = '" & parsClienteClave & "' and '" & dFechaFactura.ToString("s") & "' between FechaInicio and FechaFin) ")
            vlConsulta.AppendLine("group by TDI.TransProdID, TDI.TransProdDetalleID ")
            vlConsulta.AppendLine(") as t ")

            vlConsulta.AppendLine("select TRP.TransProdId, sum((TPD.Precio + isnull(IMP.ImpuestoPU, 0)) * TPD.Cantidad) as Subtotal, ")
            'vlConsulta.AppendLine("(TRP.DescuentoImp + TRP.DescuentoVendedor 
            vlConsulta.AppendLine("(isnull((select sum(DesImporte) from TpdDes DES where DES.TransProdId = TPD.TransProdId), 0) ")
            vlConsulta.AppendLine("+ isnull((select sum(DESV.DesImporte) from TpdDesVendedor DESV where DESV.TransProdId = TPD.TransProdId), 0) ")
            vlConsulta.AppendLine("+ sum(TPD.DescuentoImp)) + sum(isnull((TPD.Cantidad * IMP.ImpuestoPU) - IMP.ImpDesGlb, 0)) as Descuento, TRP.Total ")
            vlConsulta.AppendLine("from TransProd TRP ")
            vlConsulta.AppendLine("inner join TransProdDetalle TPD on TRP.TransProdId = TPD.TransProdId ")
            vlConsulta.AppendLine("left join #TmpImp IMP on TPD.TransProdID = IMP.TransProdId and TPD.TransProdDetalleID = IMP.TransProdDetalleId ")
            'vlConsulta.AppendLine("where TRP.Facturaid ='" & Me.TransProdID & "' and TRP.Tipo = 1 ")
            'vlConsulta.AppendLine("and TRP.Tipo = 1 ")

            If (Me.Tipo = 8) Then
                vlConsulta.AppendLine("where TRP.FacturaId = '" & Me.TransProdID & "' ")
                vlConsulta.AppendLine("and TRP.Tipo = 1 ")
            Else
                vlConsulta.AppendLine("where TRP.TransProdId = '" & Me.TransProdID & "' ")
                vlConsulta.AppendLine("and TRP.Tipo = 10 ")
            End If

            vlConsulta.AppendLine("group by TRP.TransProdId, TPD.TransProdID, TRP.DescuentoImp, TRP.DescuentoVendedor, TRP.Total ")

            vlConsulta.AppendLine("drop table #TmpImp ")
            vlConsulta.AppendLine("set nocount off ")
        Else
            vlConsulta.AppendLine("select TRP.TransProdId, sum(TPD.Precio * TPD.Cantidad) as Subtotal, ")
            'vlConsulta.AppendLine("(TRP.DescuentoImp + TRP.DescuentoVendedor 
            vlConsulta.AppendLine("(isnull((select sum(DesImporte) from TpdDes DES where DES.TransProdId = TPD.TransProdId), 0) ")
            vlConsulta.AppendLine("+ isnull((select sum(DESV.DesImporte) from TpdDesVendedor DESV where DESV.TransProdId = TPD.TransProdId), 0) ")
            vlConsulta.AppendLine("+ sum(TPD.DescuentoImp)) as Descuento, TRP.Total ")
            vlConsulta.AppendLine("from TransProd TRP ")
            vlConsulta.AppendLine("inner join TransProdDetalle TPD on TRP.TransProdId = TPD.TransProdId ")
            If (Me.Tipo = 8) Then
                vlConsulta.AppendLine("where TRP.FacturaId = '" & Me.TransProdID & "' ")
                vlConsulta.AppendLine("and TRP.Tipo = 1 ")
            Else
                vlConsulta.AppendLine("where TRP.TransProdId = '" & Me.TransProdID & "' ")
                vlConsulta.AppendLine("and TRP.Tipo = 10 ")
            End If
            vlConsulta.Append("group by TRP.TransProdId, TPD.TransProdID, TRP.DescuentoImp, TRP.DescuentoVendedor, TRP.Total")
        End If

        vlDt = Me.Tabla.Conexion.EjecutarConsulta(vlConsulta.ToString)
        For Each row As DataRow In vlDt.Rows
            parSubTotal += row("subtotal")
            parTotal += row("total")

            If (Me.Tipo = 8) Then
                parDescuento += row("descuento")
            End If
        Next

    End Sub

    'Public Function CrearCadenaOriginalE() As String
    '    Dim OP_CadenaOriginal As New System.Text.StringBuilder("||")
    '    Dim vlDtFolioFiscal As DataTable
    '    Dim vlDt As DataTable
    '    Dim vlUnidad As DataTable

    '    vlDtFolioFiscal = Me.Tabla.Conexion.EjecutarConsulta("select top 1 Descripcion as xingreso, " & _
    ' "(select Descripcion from vavdescripcion where varcodigo='FVenta' and VADTipoLenguaje = dbo.FNObtenerLenguaje() " & _
    ' "and VAVClave = 1) as CFVTipo from mendetalle where menclave='XIngreso' and MEDTipoLenguaje = dbo.FNObtenerLenguaje()")

    '    'Datos del Comprobante
    '    OP_CadenaOriginal.Append(sValido(Me.vgTRPDatoFiscal.TipoVersion))
    '    OP_CadenaOriginal.Append(sValido(Me.vgTRPDatoFiscal.Serie))

    '    Dim cad As String = Folio
    '    If cad.Substring(0, Me.vgTRPDatoFiscal.Serie.Length) = Me.vgTRPDatoFiscal.Serie Then
    '        cad = cad.Remove(0, vgTRPDatoFiscal.Serie.Length)
    '    End If

    '    OP_CadenaOriginal.Append(sValido(cad))
    '    OP_CadenaOriginal.Append(fValido(Format(Me.FechaHoraAlta, "yyyy-MM-dd") & "T" & Format(Me.FechaHoraAlta, "hh:mm:ss")))
    '    OP_CadenaOriginal.Append(sValido(Me.vgTRPDatoFiscal.Aprobacion))
    '    OP_CadenaOriginal.Append(sValido(Me.vgTRPDatoFiscal.AnioAprobacion))
    '    OP_CadenaOriginal.Append(sValido(vlDtFolioFiscal.Rows(0).Item("xIngreso").ToString))
    '    OP_CadenaOriginal.Append(sValido(vlDtFolioFiscal.Rows(0).Item("CFVTipo").ToString))

    '    Dim dSubtotal, dTotal, dDescuento As Decimal
    '    obtenerSubtotales(dSubtotal, dTotal, dDescuento)
    '    OP_CadenaOriginal.Append(dValido(dSubtotal))
    '    OP_CadenaOriginal.Append(dValido(dDescuento))
    '    OP_CadenaOriginal.Append(dValido(Me.Total))
    '    'Datos del emisor
    '    OP_CadenaOriginal.Append(sValido(Me.vgTRPDatoFiscal.RFCEm))
    '    OP_CadenaOriginal.Append(sValido(Me.vgTRPDatoFiscal.NombreEm))
    '    OP_CadenaOriginal.Append(sValido(Me.vgTRPDatoFiscal.CalleEm))
    '    OP_CadenaOriginal.Append(sValido(Me.vgTRPDatoFiscal.NumExtEm))
    '    OP_CadenaOriginal.Append(sValido(Me.vgTRPDatoFiscal.NumIntEm))
    '    OP_CadenaOriginal.Append(sValido(Me.vgTRPDatoFiscal.ColoniaEm))
    '    OP_CadenaOriginal.Append(sValido(Me.vgTRPDatoFiscal.LocalidadEm))
    '    OP_CadenaOriginal.Append(sValido(Me.vgTRPDatoFiscal.ReferenciaDomEm))
    '    OP_CadenaOriginal.Append(sValido(Me.vgTRPDatoFiscal.MunicipioEm))
    '    OP_CadenaOriginal.Append(sValido(Me.vgTRPDatoFiscal.RegionEm))
    '    OP_CadenaOriginal.Append(sValido(Me.vgTRPDatoFiscal.PaisEm))
    '    OP_CadenaOriginal.Append(sValido(Me.vgTRPDatoFiscal.CodigoPostalEm))
    '    ' expedición
    '    OP_CadenaOriginal.Append(sValido(Me.vgTRPDatoFiscal.CalleEx))
    '    OP_CadenaOriginal.Append(sValido(Me.vgTRPDatoFiscal.NumExtEx))
    '    OP_CadenaOriginal.Append(sValido(Me.vgTRPDatoFiscal.NumIntEx))
    '    OP_CadenaOriginal.Append(sValido(Me.vgTRPDatoFiscal.ColoniaEx))
    '    OP_CadenaOriginal.Append(sValido(Me.vgTRPDatoFiscal.LocalidadEx))
    '    OP_CadenaOriginal.Append(sValido(Me.vgTRPDatoFiscal.ReferenciaDomEx))
    '    OP_CadenaOriginal.Append(sValido(Me.vgTRPDatoFiscal.MunicipioEx))
    '    OP_CadenaOriginal.Append(sValido(Me.vgTRPDatoFiscal.EntidadEx))
    '    OP_CadenaOriginal.Append(sValido(Me.vgTRPDatoFiscal.PaisEx))
    '    OP_CadenaOriginal.Append(sValido(Me.vgTRPDatoFiscal.CodigoPostalEx))
    '    'receptor
    '    OP_CadenaOriginal.Append(sValido(Me.vgTRPDatoFiscal.RFC))
    '    OP_CadenaOriginal.Append(sValido(Me.vgTRPDatoFiscal.RazonSocial))
    '    OP_CadenaOriginal.Append(sValido(Me.vgTRPDatoFiscal.Calle))
    '    OP_CadenaOriginal.Append(sValido(Me.vgTRPDatoFiscal.NumExt))
    '    OP_CadenaOriginal.Append(sValido(Me.vgTRPDatoFiscal.NumInt))
    '    OP_CadenaOriginal.Append(sValido(Me.vgTRPDatoFiscal.Colonia))
    '    OP_CadenaOriginal.Append(sValido(Me.vgTRPDatoFiscal.Localidad))
    '    OP_CadenaOriginal.Append(sValido(Me.vgTRPDatoFiscal.ReferenciaDom))
    '    OP_CadenaOriginal.Append(sValido(Me.vgTRPDatoFiscal.Municipio))
    '    OP_CadenaOriginal.Append(sValido(Me.vgTRPDatoFiscal.Entidad))
    '    OP_CadenaOriginal.Append(sValido(Me.vgTRPDatoFiscal.Pais))
    '    OP_CadenaOriginal.Append(sValido(Me.vgTRPDatoFiscal.CodigoPostal))

    '    Dim vlConsulta As New System.Text.StringBuilder
    '    vlConsulta.Append("select tpd.cantidad, TPD.tipounidad, tpd.productoclave, pro.nombre as descripcion, " & _
    '    "precio as valorUnitario1,  (cantidad * precio) as importe1  " & _
    '    "from transprod TRP  " & _
    '    "inner join transProdDetalle TPD on TRP.transprodid = tpd.transprodid " & _
    '    "inner join producto PRO on pro.productoclave = tpd.productoclave where trp.facturaid ='" & Me.TransProdID & "'")
    '    'conceptos
    '    vlDt = Tabla.Conexion.EjecutarConsulta(vlConsulta.ToString)
    '    vlUnidad = Tabla.Conexion.EjecutarConsulta("select vavclave, descripcion from vavdescripcion  where varcodigo = 'unidadv' ")
    '    For Each row As DataRow In vlDt.Rows
    '        For y As Integer = 0 To vlDt.Columns.Count - 1
    '            Select Case vlDt.Columns(y).ToString.ToLower
    '                Case "valorunitario1", "importe1"
    '                    OP_CadenaOriginal.Append(dValido(row(y)))
    '                Case "tipounidad"
    '                    For Each rUnidad As DataRow In vlUnidad.Rows
    '                        If rUnidad("vavclave") = row("tipounidad") Then
    '                            OP_CadenaOriginal.Append(sValido(rUnidad("descripcion")))
    '                            Exit For
    '                        End If
    '                    Next
    '                Case Else
    '                    OP_CadenaOriginal.Append(sValido(row(y)))
    '            End Select

    '        Next
    '    Next

    '    'impuestos
    '    Dim vlImpuesto As ArrayList = Nothing
    '    Dim vlTasa As ArrayList = Nothing
    '    Dim vlImporte As ArrayList = Nothing
    '    Dim oTransProd As New cTransProd
    '    oTransProd.ImpuestosConDesc(Me.TransProdID, vlImpuesto, vlTasa, vlImporte)

    '    For i As Integer = 0 To vlImpuesto.Count - 1
    '        OP_CadenaOriginal.Append(sValido(vlImpuesto.Item(i)))
    '        OP_CadenaOriginal.Append(dValido(vlTasa.Item(i)))
    '        OP_CadenaOriginal.Append(dValido(vlImporte.Item(i)))
    '        OP_CadenaOriginal.Append(dValido(Me.Impuesto))
    '    Next

    '    OP_CadenaOriginal.Append("|")

    '    vlConsulta = Nothing
    '    vlDtFolioFiscal.Dispose()
    '    vlDtFolioFiscal = Nothing
    '    vlDt.Dispose()
    '    vlDt = Nothing
    '    vlUnidad.Dispose()
    '    vlUnidad = Nothing
    '    oTransProd = Nothing

    '    Return OP_CadenaOriginal.ToString
    'End Function

    Public Function CrearCadenaOriginalE(ByVal bFactura As Boolean, ByVal bImpuestoGlb As Boolean) As String
        Dim OP_CadenaOriginal As String = "||"
        Dim vlDtFolioFiscal As DataTable
        Dim vlDt As DataTable

        Dim dFechaFactura As Date

        If Not bFactura Then
            Dim dtFact As New DataTable
            dtFact = LbConexion.cConexion.Instancia.EjecutarConsulta("select * from TRPDatoFiscal trp inner join transprod TRA on TRA.transprodid=TRP.transprodid where trp.transprodid='" & Me.FacturaID & "'")
            If dtFact.Rows.Count > 0 Then
                dFechaFactura = CType(dtFact.Rows(0)("FechaHoraAlta"), Date)

                If Not dtFact.Rows(0)!CadenaOriginal Is DBNull.Value Then
                    Dim cadena As String() = dtFact.Rows(0)!CadenaOriginal.ToString().Split(New Char() {"|"})
                    Dim fechaCadena As String = cadena(5)
                    Dim fechaCadenaDate As DateTime
                    If DateTime.TryParse(fechaCadena, fechaCadenaDate) Then
                        dFechaFactura = fechaCadenaDate
                    End If
                End If
            Else
                dFechaFactura = Me.FechaHoraAlta
            End If
        Else
            dFechaFactura = Me.FechaHoraAlta
        End If

        Dim oSubempresa As New ERMSEMLOG.cSubEmpresa()
        oSubempresa.Recuperar(SubEmpresaId, FechaHoraAlta)

        vlDtFolioFiscal = Me.Tabla.Conexion.EjecutarConsulta("select top 1 Descripcion as xingreso, " & _
     "(select Descripcion from vavdescripcion where varcodigo='FVenta' and VADTipoLenguaje = dbo.FNObtenerLenguaje() " & _
     "and VAVClave = 1) as CFVTipo from mendetalle where menclave='XIngreso' and MEDTipoLenguaje = dbo.FNObtenerLenguaje()")

        Dim bImpGlbOriginal As Boolean = bImpuestoGlb
        If Not bFactura And Me.vgTRPDatoFiscal.TipoNotaCredito = 1 Then bImpuestoGlb = False


        'Datos del Comprobante
        OP_CadenaOriginal &= sValido(Me.vgTRPDatoFiscal.TipoVersion)
        OP_CadenaOriginal &= sValido(Me.vgTRPDatoFiscal.Serie)

        Dim cad As String = Folio
        If cad.Substring(0, Me.vgTRPDatoFiscal.Serie.Length) = Me.vgTRPDatoFiscal.Serie Then
            cad = cad.Remove(0, vgTRPDatoFiscal.Serie.Length)
        End If

        OP_CadenaOriginal &= sValido(cad)

        OP_CadenaOriginal &= fValido(Me.FechaHoraAlta)


        OP_CadenaOriginal &= sValido(Me.vgTRPDatoFiscal.Aprobacion)
        OP_CadenaOriginal &= sValido(Me.vgTRPDatoFiscal.AnioAprobacion)

        If bFactura Then
            OP_CadenaOriginal &= sValido("ingreso")
        Else
            OP_CadenaOriginal &= sValido("egreso")
        End If

        OP_CadenaOriginal &= sValido(vgTRPDatoFiscal.FormaDePago)

        'Dim bImpuestoGlb As Boolean = False
        Dim vlConsulta As New Text.StringBuilder
        'If bFactura Then
        '    vlConsulta.AppendLine("select isnull(sum(case when TDI.ImpuestoPU is null or TDI.ImpDesGlb is null then 1 else 0 end), 0) as Nulos ")
        '    vlConsulta.AppendLine("from TransProd TRP ")
        '    vlConsulta.AppendLine("inner join TPDImpuesto TDI on TRP.TransProdID = TDI.TransProdID ")
        '    vlConsulta.AppendLine("where TRP.FacturaID = '" & Me.TransProdID & "' and TRP.Tipo = 1 ")
        '    bImpuestoGlb = (LbConexion.cConexion.Instancia.EjecutarComandoScalar(vlConsulta.ToString) = 0)
        'End If

        Dim sClienteClave As String
        vlConsulta = New Text.StringBuilder
        vlConsulta.AppendLine("select VIS.ClienteClave ")
        vlConsulta.AppendLine("from TransProd FAC ")
        vlConsulta.AppendLine("inner join Visita VIS on FAC.VisitaClave = VIS.VisitaClave and FAC.DiaClave = VIS.DiaClave ")
        vlConsulta.AppendLine("where FAC.TransProdID = '" & Me.TransProdID & "'")
        sClienteClave = LbConexion.cConexion.Instancia.EjecutarComandoScalar(vlConsulta.ToString)

        Dim dSubtotal, dTotal, dDescuento As Decimal
        obtenerSubtotales(sClienteClave, bImpuestoGlb, dSubtotal, dTotal, dDescuento, dFechaFactura)
        OP_CadenaOriginal &= dValido(dSubtotal)
        If (bFactura) Then
            OP_CadenaOriginal &= dValido(dDescuento)
        Else
            If (Me.vgTRPDatoFiscal.TipoNotaCredito = 2) Then
                OP_CadenaOriginal &= dValido(ObtenerDescuentosNotaCredito(Me.TransProdID, sClienteClave, dFechaFactura, bImpuestoGlb))
            Else
                OP_CadenaOriginal &= dValido(0)
            End If
        End If

        OP_CadenaOriginal &= dValido(Me.TotalFacturaElectronica)

        If oSubempresa.VersionCFD = 3 Then
            Dim sMetodoPago As String = String.Empty
            Dim sNumCtaPago As String = String.Empty

            If Me.vgTRPDatoFiscal.MetodoPago.Length > 0 Then
                Dim Metodos As String() = Me.vgTRPDatoFiscal.MetodoPago.Split(",")
                Dim Bancos As String()
                If Not Me.vgTRPDatoFiscal.Banco Is Nothing AndAlso Me.vgTRPDatoFiscal.Banco.Length > 0 Then
                    Bancos = Me.vgTRPDatoFiscal.Banco.Split(",")
                End If
                Dim Cuentas As String()
                If Not Me.vgTRPDatoFiscal.NumCtaPago Is Nothing AndAlso Me.vgTRPDatoFiscal.NumCtaPago.Length > 0 Then
                    Cuentas = Me.vgTRPDatoFiscal.NumCtaPago.Split(",")
                End If

                Dim aMetodos As New ArrayList
                Dim sBanco As String = String.Empty
                Dim sCuenta As String = String.Empty
                Dim indice As Integer = 0

                For Each sMetodo As String In Metodos
                    sBanco = String.Empty
                    sCuenta = String.Empty
                    If (Not IsNothing(Bancos) AndAlso indice < Bancos.Length) Then
                        sBanco = Bancos(indice)
                    End If
                    If (Not IsNothing(Cuentas) AndAlso indice < Cuentas.Length) Then
                        sCuenta = Cuentas(indice)
                    End If
                    If sBanco.Length > 0 And sBanco <> "*" Then
                        sMetodoPago += sMetodo + " " + sBanco + ","
                    Else
                        sMetodoPago += sMetodo + ","
                    End If

                    If sCuenta.Length > 0 And sCuenta <> "*" Then
                        sNumCtaPago += sCuenta + ","
                    End If
                    indice += 1
                Next
                If sMetodoPago.Length > 0 Then
                    sMetodoPago = sMetodoPago.Substring(0, sMetodoPago.Length - 1)
                End If
                If sNumCtaPago.Length > 0 Then
                    sNumCtaPago = sNumCtaPago.Substring(0, sNumCtaPago.Length - 1)
                End If
            End If

            OP_CadenaOriginal &= sValido(sMetodoPago)
            OP_CadenaOriginal &= sValido(IIf(IsDBNull(Me.vgTRPDatoFiscal.LugarExpedicion), "", Me.vgTRPDatoFiscal.LugarExpedicion))
            If (sNumCtaPago <> "") Then OP_CadenaOriginal &= sValido(sNumCtaPago)
            If MonedaID <> "" Then
                OP_CadenaOriginal += dValido(TipoCambio)
                Dim iTipoCodigo As Integer = LbConexion.cConexion.Instancia.EjecutarComandoScalar("Select TipoCodigo from moneda where MonedaID='" + MonedaID + "' ")
                OP_CadenaOriginal += sValido(lbGeneral.ClaveDescripcionVARValor("CDGOMON", iTipoCodigo))
            End If

        End If

        'Datos del emisor
        OP_CadenaOriginal &= sValido(Me.vgTRPDatoFiscal.RFCEm)
        'If oSubempresa.VersionCFD = 1 Then
        OP_CadenaOriginal &= sValido(Me.vgTRPDatoFiscal.NombreEm)
        OP_CadenaOriginal &= sValido(Me.vgTRPDatoFiscal.CalleEm)
        OP_CadenaOriginal &= sValido(Me.vgTRPDatoFiscal.NumExtEm)
        OP_CadenaOriginal &= sValido(Me.vgTRPDatoFiscal.NumIntEm)
        OP_CadenaOriginal &= sValido(Me.vgTRPDatoFiscal.ColoniaEm)
        OP_CadenaOriginal &= sValido(Me.vgTRPDatoFiscal.LocalidadEm)
        OP_CadenaOriginal &= sValido(Me.vgTRPDatoFiscal.ReferenciaDomEm)
        OP_CadenaOriginal &= sValido(Me.vgTRPDatoFiscal.MunicipioEm)
        OP_CadenaOriginal &= sValido(Me.vgTRPDatoFiscal.RegionEm)
        OP_CadenaOriginal &= sValido(Me.vgTRPDatoFiscal.PaisEm)
        OP_CadenaOriginal &= sValido(Me.vgTRPDatoFiscal.CodigoPostalEm)
        'End If

        ' expedición
        OP_CadenaOriginal &= sValido(Me.vgTRPDatoFiscal.CalleEx)
        OP_CadenaOriginal &= sValido(Me.vgTRPDatoFiscal.NumExtEx)
        OP_CadenaOriginal &= sValido(Me.vgTRPDatoFiscal.NumIntEx)
        OP_CadenaOriginal &= sValido(Me.vgTRPDatoFiscal.ColoniaEx)
        OP_CadenaOriginal &= sValido(Me.vgTRPDatoFiscal.LocalidadEx)
        OP_CadenaOriginal &= sValido(Me.vgTRPDatoFiscal.ReferenciaDomEx)
        OP_CadenaOriginal &= sValido(Me.vgTRPDatoFiscal.MunicipioEx)
        OP_CadenaOriginal &= sValido(Me.vgTRPDatoFiscal.EntidadEx)
        OP_CadenaOriginal &= sValido(Me.vgTRPDatoFiscal.PaisEx)
        OP_CadenaOriginal &= sValido(Me.vgTRPDatoFiscal.CodigoPostalEx)

        'Regimen Fiscal
        If oSubempresa.VersionCFD = 3 Then
            Dim oFOL As New ERMFOLLOG.cFolio
            oFOL.Recuperar(Me.vgTRPDatoFiscal.FolioId)

            Dim dtFSH As DataTable = oFOL.recuperrarFSHDatatableHistorico(Me.vgTRPDatoFiscal.FOSId)
            Dim drFSH As DataRow() = dtFSH.Select("FSHFechaInicio <= '" & Me.FechaHoraAlta.ToString("s") & "'", "FSHFechaInicio desc")
            Dim oFSH As ERMFOLLOG.Amesol.CFOSHist = oFOL.FSH(Me.vgTRPDatoFiscal.FOSId, drFSH(0)("FSHFechaInicio"))

            Dim sCentroExpId As String = oFSH.CentroExpID

            vlConsulta = New Text.StringBuilder
            vlConsulta.AppendLine("select case when CentroExpPadreId is null then CentroExpId else CentroExpPadreID end as CentroExpId from CentroExpedicion where CentroExpID = '" & sCentroExpId & "'")
            sCentroExpId = LbConexion.cConexion.Instancia.EjecutarComandoScalar(vlConsulta.ToString)

            vlConsulta = New Text.StringBuilder
            vlConsulta.AppendLine("select Descripcion as Regimen ")
            vlConsulta.AppendLine("from TRPRegimenFiscal ")
            vlConsulta.AppendLine("where TransProdID='" & Me.TransProdID & "' order by Regimen ")
            Dim dtRegimen As DataTable = LbConexion.cConexion.Instancia.EjecutarConsulta(vlConsulta.ToString)

            For Each drRegimen As DataRow In dtRegimen.Rows
                OP_CadenaOriginal &= sValido(drRegimen("Regimen"))
            Next
        End If

        'receptor
        OP_CadenaOriginal &= sValido(Me.vgTRPDatoFiscal.RFC)
        OP_CadenaOriginal &= sValido(Me.vgTRPDatoFiscal.RazonSocial)
        OP_CadenaOriginal &= sValido(Me.vgTRPDatoFiscal.Calle)
        OP_CadenaOriginal &= sValido(Me.vgTRPDatoFiscal.NumExt)
        OP_CadenaOriginal &= sValido(Me.vgTRPDatoFiscal.NumInt)
        OP_CadenaOriginal &= sValido(Me.vgTRPDatoFiscal.Colonia)
        OP_CadenaOriginal &= sValido(Me.vgTRPDatoFiscal.Localidad)
        OP_CadenaOriginal &= sValido(Me.vgTRPDatoFiscal.ReferenciaDom)
        OP_CadenaOriginal &= sValido(Me.vgTRPDatoFiscal.Municipio)
        OP_CadenaOriginal &= sValido(Me.vgTRPDatoFiscal.Entidad)
        OP_CadenaOriginal &= sValido(Me.vgTRPDatoFiscal.Pais)
        OP_CadenaOriginal &= sValido(Me.vgTRPDatoFiscal.CodigoPostal)

        'Dim vlConsulta As String

        vlConsulta = New Text.StringBuilder

        If bImpuestoGlb Then
            vlConsulta.AppendLine("set nocount on ")
            vlConsulta.AppendLine("if (select object_id('tempdb..#ImpNoDes')) is not null drop table #ImpNoDes ")
            vlConsulta.AppendLine("select * into #ImpNoDes from ( ")
            vlConsulta.AppendLine("select TDI.TransProdID, TDI.TransProdDetalleID, sum(TDI.ImpuestoPU) as ImpuestoPU ")
            vlConsulta.AppendLine("from TPDImpuesto TDI ")
            vlConsulta.AppendLine("inner join TransProd TRP on TDI.TransProdID = TRP.TransProdID ")
            If bFactura Then
                vlConsulta.AppendLine("where TRP.FacturaId = '" & Me.TransProdID & "' and TRP.Tipo = 1 and TDI.ImpuestoClave in ( ")
            Else
                vlConsulta.AppendLine("where TRP.TransProdId = '" & Me.TransProdID & "' and TRP.Tipo = 10 and TDI.ImpuestoClave in ( ")
            End If
            vlConsulta.AppendLine("select ImpuestoClave ")
            vlConsulta.AppendLine("from CLINoDesImp ")
            vlConsulta.AppendLine("where ClienteClave = '" & sClienteClave & "' and '" & dFechaFactura.ToString("s") & "' between FechaInicio and FechaFin) ")
            vlConsulta.AppendLine("group by TDI.TransProdID, TDI.TransProdDetalleID ")
            vlConsulta.AppendLine(") as t ")
        End If

        vlConsulta.AppendLine("select sum(TPD.Cantidad) as Cantidad, ")
        vlConsulta.AppendLine("(select Descripcion from VAVDescripcion where VARCodigo = 'UNIDADV' and VAVClave = TPD.TipoUnidad and VADTipoLenguaje = dbo.FNObtenerLenguaje()) as Unidad, ")
        vlConsulta.AppendLine("TPD.ProductoClave, PRO.NombreLargo as Descripcion, ")
        If bImpuestoGlb Then
            vlConsulta.AppendLine("TPD.Precio + isnull(IMP.ImpuestoPU, 0) as ValorUnitario1, sum(TPD.Cantidad * (TPD.Precio + isnull(IMP.ImpuestoPU,0))) as Importe1 ")
        Else
            vlConsulta.AppendLine("TPD.Precio as ValorUnitario1, sum(TPD.Cantidad * TPD.Precio) as Importe1 ")
        End If
        vlConsulta.AppendLine("from TransProd TRP ")
        vlConsulta.AppendLine("inner join TransProdDetalle TPD on TRP.TransProdId = TPD.TransProdId ")
        vlConsulta.AppendLine("inner join Producto PRO on PRO.ProductoClave = TPD.ProductoClave ")
        If bImpuestoGlb Then
            vlConsulta.AppendLine("left join #ImpNoDes IMP on TPD.TransProdID = IMP.TransProdId and TPD.TransProdDetalleID = IMP.TransProdDetalleId ")
        End If
        If bFactura Then
            vlConsulta.AppendLine("where TRP.Tipo = 1 and TRP.FacturaId = '" & Me.TransProdID & "' ")
        Else
            vlConsulta.AppendLine("where TRP.Tipo = 10 and TRP.TransProdId = '" & Me.TransProdID & "' ")
        End If
        If bImpuestoGlb Then
            vlConsulta.AppendLine("group by TPD.ProductoClave, TPD.TipoUnidad, TPD.Precio + isnull(IMP.ImpuestoPU, 0), PRO.NombreLargo ")
            vlConsulta.AppendLine("order by tpd.productoclave, TPD.TipoUnidad, TPD.Precio + isnull(IMP.ImpuestoPU, 0), PRO.NombreLargo ")
        Else
            vlConsulta.AppendLine("group by TPD.ProductoClave, TPD.TipoUnidad, TPD.Precio, PRO.NombreLargo ")
            vlConsulta.AppendLine("order by tpd.productoclave, TPD.TipoUnidad, TPD.Precio, PRO.NombreLargo ")
        End If


        If bImpuestoGlb Then
            vlConsulta.AppendLine("drop table #ImpNoDes ")
            vlConsulta.AppendLine("set nocount on ")
        End If

        'conceptos
        vlDt = Tabla.Conexion.EjecutarConsulta(vlConsulta.ToString)
        'Pedimentos
        Dim dtPedimentos As DataTable = New DataTable
        If (bFactura) Then
            dtPedimentos = Tabla.Conexion.EjecutarConsulta("Select distinct TRPP.ProductoClave, TRPP.NumPedimento, TRPP.Aduana, TRPP.FechaIngreso from TRPPedimento TRPP inner join TransProd TRP on TRPP.TransProdID = TRP.TransProdId where TRP.Tipo = 1 and TRPP.Facturado = 1 and TRP.FacturaID='" & Me.TransProdID & "'")
        End If


        For Each row As DataRow In vlDt.Rows
            OP_CadenaOriginal &= dValido(row("cantidad"))
            OP_CadenaOriginal &= sValido(row("unidad"))
            OP_CadenaOriginal &= sValido(row("productoclave"))
            OP_CadenaOriginal &= sValido(row("descripcion"))
            OP_CadenaOriginal &= dValido(row("valorunitario1"))
            OP_CadenaOriginal &= dValido(row("importe1"))
            If bFactura Then
                If (Not IsNothing(dtPedimentos) AndAlso Not IsDBNull(dtPedimentos)) Then
                    For Each dr As DataRow In dtPedimentos.Select("ProductoClave = '" & row("ProductoClave") & "'")
                        OP_CadenaOriginal &= sValido(dr("NumPedimento"))
                        OP_CadenaOriginal &= Microsoft.VisualBasic.Format(dr("FechaIngreso"), "yyyy-MM-dd") & "|"
                        OP_CadenaOriginal &= sValido(dr("Aduana"))
                    Next
                End If
            End If
        Next

        'impuestos
        Dim vlImpuesto As ArrayList = Nothing
        Dim vlTasa As ArrayList = Nothing
        Dim vlImporte As ArrayList = Nothing
        Dim oTransProd As New cTransProd
        oTransProd.ImpuestosConDesc(Me.TransProdID, sClienteClave, Me.FechaHoraAlta, bImpGlbOriginal, vlImpuesto, vlTasa, vlImporte)
        Dim nTotalImpuesto As Double = 0

        For i As Integer = 0 To vlImpuesto.Count - 1
            OP_CadenaOriginal &= sValido(vlImpuesto.Item(i))
            OP_CadenaOriginal &= Microsoft.VisualBasic.Strings.Format(vlTasa.Item(i), "0.0#") + "|"
            OP_CadenaOriginal &= dValido(vlImporte.Item(i))
            nTotalImpuesto += vlImporte.Item(i)
        Next

        'Dim sCmd As String
        'sCmd = "select count(*) from TransProd TRP "
        'sCmd &= "inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave and TRP.DiaClave = VIS.DiaClave "
        'sCmd &= "inner join AddendaCliente ADC on VIS.ClienteClave = ADC.ClienteClave "
        'sCmd &= "inner join Addenda ADE on ADC.ADDId = ADE.ADDID "
        'sCmd &= "where TRP.TransProdID = '" & Me.TransProdID & "' and ADE.Tipo in (1,5) and Baja = 0 "

        'If LbConexion.cConexion.Instancia.EjecutarComandoScalar(sCmd) > 0 Then
        OP_CadenaOriginal &= dValido(nTotalImpuesto)
        'End If

        OP_CadenaOriginal &= "|"

        vlConsulta = Nothing
        vlDtFolioFiscal.Dispose()
        vlDtFolioFiscal = Nothing
        vlDt.Dispose()
        vlDt = Nothing
        oTransProd = Nothing

        Return OP_CadenaOriginal
    End Function

    Public Function CrearCadenaOriginalSello(ByVal oTimbre As CFDi.cTimbreFiscal) As String
        Dim OP_CadenaOriginal As String = "||"
        OP_CadenaOriginal &= sValidoV3(oTimbre.version)
        OP_CadenaOriginal &= sValidoV3(oTimbre.UUID)
        OP_CadenaOriginal &= sValidoV3(oTimbre.FechaTimbrado.ToString("s"))
        OP_CadenaOriginal &= sValidoV3(oTimbre.selloCFD)
        OP_CadenaOriginal &= sValidoV3(oTimbre.noCertificadoSAT)
        OP_CadenaOriginal &= "|"
        Return OP_CadenaOriginal
    End Function

    Public Function CrearCadenaOriginalEV3(ByVal bFactura As Boolean, ByVal bImpuestoGlb As Boolean) As String
        Dim OP_CadenaOriginal As String = "||"
        Dim vlDtFolioFiscal As DataTable
        Dim vlDt As DataTable

        Dim dFechaFactura As Date

        If Not bFactura Then
            Dim dtFact As New DataTable
            dtFact = LbConexion.cConexion.Instancia.EjecutarConsulta("select * from TRPDatoFiscal trp inner join transprod TRA on TRA.transprodid=TRP.transprodid where trp.transprodid='" & Me.FacturaID & "'")

            dFechaFactura = CType(dtFact.Rows(0)("FechaHoraAlta"), Date)

            If Not dtFact.Rows(0)!CadenaOriginal Is DBNull.Value Then
                Dim cadena As String() = dtFact.Rows(0)!CadenaOriginal.ToString().Split(New Char() {"|"})
                Dim fechaCadena As String = cadena(5)
                Dim fechaCadenaDate As DateTime
                If DateTime.TryParse(fechaCadena, fechaCadenaDate) Then
                    dFechaFactura = fechaCadenaDate
                End If
            End If
        Else
            dFechaFactura = Me.FechaHoraAlta
        End If

        Dim oSubempresa As New ERMSEMLOG.cSubEmpresa()
        oSubempresa.Recuperar(SubEmpresaId, FechaHoraAlta)

        vlDtFolioFiscal = Me.Tabla.Conexion.EjecutarConsulta("select top 1 Descripcion as xingreso, " & _
     "(select Descripcion from vavdescripcion where varcodigo='FVenta' and VADTipoLenguaje = dbo.FNObtenerLenguaje() " & _
     "and VAVClave = 1) as CFVTipo from mendetalle where menclave='XIngreso' and MEDTipoLenguaje = dbo.FNObtenerLenguaje()")

        Dim bImpGlbOriginal As Boolean = bImpuestoGlb
        If Not bFactura And Me.vgTRPDatoFiscal.TipoNotaCredito = 1 Then bImpuestoGlb = False

        'Datos del Comprobante
        OP_CadenaOriginal &= sValidoV3(Me.vgTRPDatoFiscal.TipoVersion)
        'OP_CadenaOriginal &= svalidoV3(Me.vgTRPDatoFiscal.Serie)

        'Dim cad As String = Folio
        'If cad.Substring(0, Me.vgTRPDatoFiscal.Serie.Length) = Me.vgTRPDatoFiscal.Serie Then
        '    cad = cad.Remove(0, vgTRPDatoFiscal.Serie.Length)
        'End If

        'OP_CadenaOriginal &= svalidoV3(cad)
        OP_CadenaOriginal &= fValidoVersion3(Me.FechaHoraAlta)



        If bFactura Then
            OP_CadenaOriginal &= sValidoV3("ingreso")
        Else
            OP_CadenaOriginal &= sValidoV3("egreso")
        End If

        OP_CadenaOriginal &= sValidoV3(vgTRPDatoFiscal.FormaDePago)

        'Dim bImpuestoGlb As Boolean = False
        Dim vlConsulta As New Text.StringBuilder
        'If bFactura Then
        '    vlConsulta.AppendLine("select isnull(sum(case when TDI.ImpuestoPU is null or TDI.ImpDesGlb is null then 1 else 0 end), 0) as Nulos ")
        '    vlConsulta.AppendLine("from TransProd TRP ")
        '    vlConsulta.AppendLine("inner join TPDImpuesto TDI on TRP.TransProdID = TDI.TransProdID ")
        '    vlConsulta.AppendLine("where TRP.FacturaID = '" & Me.TransProdID & "' and TRP.Tipo = 1 ")
        '    bImpuestoGlb = (LbConexion.cConexion.Instancia.EjecutarComandoScalar(vlConsulta.ToString) = 0)
        'End If

        Dim sClienteClave As String
        vlConsulta = New Text.StringBuilder
        vlConsulta.AppendLine("select VIS.ClienteClave ")
        vlConsulta.AppendLine("from TransProd FAC ")
        vlConsulta.AppendLine("inner join Visita VIS on FAC.VisitaClave = VIS.VisitaClave and FAC.DiaClave = VIS.DiaClave ")
        vlConsulta.AppendLine("where FAC.TransProdID = '" & Me.TransProdID & "'")
        sClienteClave = LbConexion.cConexion.Instancia.EjecutarComandoScalar(vlConsulta.ToString)

        Dim dSubtotal, dTotal, dDescuento As Decimal
        obtenerSubtotales(sClienteClave, bImpuestoGlb, dSubtotal, dTotal, dDescuento, dFechaFactura)
        OP_CadenaOriginal &= dValido(dSubtotal)
        If (bFactura) Then
            OP_CadenaOriginal &= dValido(dDescuento)
        Else
            If (Me.vgTRPDatoFiscal.TipoNotaCredito = 2) Then
                OP_CadenaOriginal &= dValido(ObtenerDescuentosNotaCredito(Me.TransProdID, sClienteClave, dFechaFactura, bImpuestoGlb))
            Else
                OP_CadenaOriginal &= dValido(0)
            End If
        End If
        OP_CadenaOriginal &= dValido(Me.TotalFacturaElectronica)

        If oSubempresa.VersionCFD = 4 Then
            OP_CadenaOriginal &= sValido(Me.vgTRPDatoFiscal.MetodoPago)
            OP_CadenaOriginal &= sValido(IIf(Me.vgTRPDatoFiscal.MunicipioEx = "", Me.vgTRPDatoFiscal.MunicipioEm & ", " & Me.vgTRPDatoFiscal.RegionEm, Me.vgTRPDatoFiscal.MunicipioEx & ", " & Me.vgTRPDatoFiscal.EntidadEx))
        End If

        'Datos del emisor
        OP_CadenaOriginal &= sValido(Me.vgTRPDatoFiscal.RFCEm)
        If oSubempresa.VersionCFD = 2 Then
            OP_CadenaOriginal &= sValido(Me.vgTRPDatoFiscal.NombreEm)
            OP_CadenaOriginal &= sValido(Me.vgTRPDatoFiscal.CalleEm)
            OP_CadenaOriginal &= sValidoV3(Me.vgTRPDatoFiscal.NumExtEm)
            OP_CadenaOriginal &= sValidoV3(Me.vgTRPDatoFiscal.NumIntEm)
            OP_CadenaOriginal &= sValidoV3(Me.vgTRPDatoFiscal.ColoniaEm)
            OP_CadenaOriginal &= sValidoV3(Me.vgTRPDatoFiscal.LocalidadEm)
            OP_CadenaOriginal &= sValidoV3(Me.vgTRPDatoFiscal.ReferenciaDomEm)
            OP_CadenaOriginal &= sValidoV3(Me.vgTRPDatoFiscal.MunicipioEm)
            OP_CadenaOriginal &= sValidoV3(Me.vgTRPDatoFiscal.RegionEm)
            OP_CadenaOriginal &= sValidoV3(Me.vgTRPDatoFiscal.PaisEm)
            OP_CadenaOriginal &= sValidoV3(Me.vgTRPDatoFiscal.CodigoPostalEm)
        End If

        ' expedición
        OP_CadenaOriginal &= sValido(Me.vgTRPDatoFiscal.CalleEx)
        OP_CadenaOriginal &= sValido(IIf(Me.vgTRPDatoFiscal.NumExtEx = "", Me.vgTRPDatoFiscal.NumExtEm, Me.vgTRPDatoFiscal.NumExtEx))
        OP_CadenaOriginal &= sValidoV3(Me.vgTRPDatoFiscal.NumIntEx)
        OP_CadenaOriginal &= sValidoV3(Me.vgTRPDatoFiscal.ColoniaEx)
        OP_CadenaOriginal &= sValidoV3(Me.vgTRPDatoFiscal.LocalidadEx)
        OP_CadenaOriginal &= sValidoV3(Me.vgTRPDatoFiscal.ReferenciaDomEx)
        OP_CadenaOriginal &= sValidoV3(Me.vgTRPDatoFiscal.MunicipioEx)
        OP_CadenaOriginal &= sValidoV3(Me.vgTRPDatoFiscal.EntidadEx)
        OP_CadenaOriginal &= sValidoV3(Me.vgTRPDatoFiscal.PaisEx)
        OP_CadenaOriginal &= sValidoV3(Me.vgTRPDatoFiscal.CodigoPostalEx)


        'Regimen Fiscal
        If oSubempresa.VersionCFD = 4 Then
            Dim oFOL As New ERMFOLLOG.cFolio
            oFOL.Recuperar(Me.vgTRPDatoFiscal.FolioId)

            Dim dtFSH As DataTable = oFOL.recuperrarFSHDatatableHistorico(Me.vgTRPDatoFiscal.FOSId)
            Dim drFSH As DataRow() = dtFSH.Select("FSHFechaInicio <= '" & Me.FechaHoraAlta.ToString("s") & "'", "FSHFechaInicio desc")
            Dim oFSH As ERMFOLLOG.Amesol.CFOSHist = oFOL.FSH(Me.vgTRPDatoFiscal.FOSId, drFSH(0)("FSHFechaInicio"))

            Dim sCentroExpId As String = oFSH.CentroExpID

            vlConsulta = New Text.StringBuilder
            vlConsulta.AppendLine("select case when CentroExpPadreId is null then CentroExpId else CentroExpPadreID end as CentroExpId from CentroExpedicion where CentroExpID = '" & sCentroExpId & "'")
            sCentroExpId = LbConexion.cConexion.Instancia.EjecutarComandoScalar(vlConsulta.ToString)

            vlConsulta = New Text.StringBuilder
            vlConsulta.AppendLine("select VAD.Descripcion as Regimen ")
            vlConsulta.AppendLine("from CEERegimenFiscal CRF ")
            vlConsulta.AppendLine("inner join VAVDescripcion VAD on VAD.VARCodigo = 'TIPREG' and VAD.VAVClave = CRF.TipoRegimen and VAD.VADTipoLenguaje = '" & lbGeneral.cParametros.Lenguaje & "' ")
            vlConsulta.AppendLine("where CRF.CentroExpId = '" & sCentroExpId & "' ")
            Dim dtRegimen As DataTable = LbConexion.cConexion.Instancia.EjecutarConsulta(vlConsulta.ToString)

            For Each drRegimen As DataRow In dtRegimen.Rows
                OP_CadenaOriginal &= sValido(drRegimen("Regimen"))
            Next
        End If

        'receptor
        OP_CadenaOriginal &= sValido(Me.vgTRPDatoFiscal.RFC)
        OP_CadenaOriginal &= sValido(Me.vgTRPDatoFiscal.RazonSocial)
        OP_CadenaOriginal &= sValido(Me.vgTRPDatoFiscal.Calle)
        OP_CadenaOriginal &= sValido(Me.vgTRPDatoFiscal.NumExt)
        OP_CadenaOriginal &= sValidoV3(Me.vgTRPDatoFiscal.NumInt)
        OP_CadenaOriginal &= sValidoV3(Me.vgTRPDatoFiscal.Colonia)
        OP_CadenaOriginal &= sValidoV3(Me.vgTRPDatoFiscal.Localidad)
        OP_CadenaOriginal &= sValidoV3(Me.vgTRPDatoFiscal.ReferenciaDom)
        OP_CadenaOriginal &= sValidoV3(Me.vgTRPDatoFiscal.Municipio)
        OP_CadenaOriginal &= sValidoV3(Me.vgTRPDatoFiscal.Entidad)
        OP_CadenaOriginal &= sValidoV3(Me.vgTRPDatoFiscal.Pais)
        OP_CadenaOriginal &= sValidoV3(Me.vgTRPDatoFiscal.CodigoPostal)

        vlConsulta = New Text.StringBuilder

        If bImpuestoGlb Then
            vlConsulta.AppendLine("set nocount on ")
            vlConsulta.AppendLine("if (select object_id('tempdb..#ImpNoDes')) is not null drop table #ImpNoDes ")
            vlConsulta.AppendLine("select * into #ImpNoDes from ( ")
            vlConsulta.AppendLine("select TDI.TransProdID, TDI.TransProdDetalleID, sum(TDI.ImpuestoPU) as ImpuestoPU ")
            vlConsulta.AppendLine("from TPDImpuesto TDI ")
            vlConsulta.AppendLine("inner join TransProd TRP on TDI.TransProdID = TRP.TransProdID ")
            If bFactura Then
                vlConsulta.AppendLine("where TRP.FacturaId = '" & Me.TransProdID & "' and TRP.Tipo = 1 and TDI.ImpuestoClave in ( ")
            Else
                vlConsulta.AppendLine("where TRP.TransProdId = '" & Me.TransProdID & "' and TRP.Tipo = 10 and TDI.ImpuestoClave in ( ")
            End If
            vlConsulta.AppendLine("select ImpuestoClave ")
            vlConsulta.AppendLine("from CLINoDesImp ")
            vlConsulta.AppendLine("where ClienteClave = '" & sClienteClave & "' and '" & dFechaFactura.ToString("s") & "' between FechaInicio and FechaFin) ")
            vlConsulta.AppendLine("group by TDI.TransProdID, TDI.TransProdDetalleID ")
            vlConsulta.AppendLine(") as t ")

        End If

        vlConsulta.AppendLine("select sum(TPD.Cantidad) as Cantidad, ")
        vlConsulta.AppendLine("(select Descripcion from VAVDescripcion where VARCodigo = 'UNIDADV' and VAVClave = TPD.TipoUnidad and VADTipoLenguaje = dbo.FNObtenerLenguaje()) as Unidad, ")
        vlConsulta.AppendLine("TPD.ProductoClave, PRO.Nombre as Descripcion, ")
        If bImpuestoGlb Then
            vlConsulta.AppendLine("TPD.Precio + isnull(IMP.ImpuestoPU, 0) as ValorUnitario1, sum(TPD.Cantidad * (TPD.Precio + isnull(IMP.ImpuestoPU,0))) as Importe1 ")
        Else
            vlConsulta.AppendLine("TPD.Precio as ValorUnitario1, sum(TPD.Cantidad * TPD.Precio) as Importe1 ")
        End If
        vlConsulta.AppendLine("from TransProd TRP ")
        vlConsulta.AppendLine("inner join TransProdDetalle TPD on TRP.TransProdId = TPD.TransProdId ")
        vlConsulta.AppendLine("inner join Producto PRO on PRO.ProductoClave = TPD.ProductoClave ")
        If bImpuestoGlb Then
            vlConsulta.AppendLine("left join #ImpNoDes IMP on TPD.TransProdID = IMP.TransProdId and TPD.TransProdDetalleID = IMP.TransProdDetalleId ")
        End If
        If bFactura Then
            vlConsulta.AppendLine("where TRP.Tipo = 1 and TRP.FacturaId = '" & Me.TransProdID & "' ")
        Else
            vlConsulta.AppendLine("where TRP.Tipo = 10 and TRP.TransProdId = '" & Me.TransProdID & "' ")
        End If
        If bImpuestoGlb Then
            vlConsulta.AppendLine("group by TPD.ProductoClave, TPD.TipoUnidad, TPD.Precio + isnull(IMP.ImpuestoPU, 0), PRO.Nombre ")
            vlConsulta.AppendLine("order by tpd.productoclave, TPD.TipoUnidad, TPD.Precio + isnull(IMP.ImpuestoPU, 0), PRO.Nombre ")
        Else
            vlConsulta.AppendLine("group by TPD.ProductoClave, TPD.TipoUnidad, TPD.Precio, PRO.Nombre ")
            vlConsulta.AppendLine("order by tpd.productoclave, TPD.TipoUnidad, TPD.Precio, PRO.Nombre ")
        End If


        If bImpuestoGlb Then
            vlConsulta.AppendLine("drop table #ImpNoDes ")
            vlConsulta.AppendLine("set nocount on ")
        End If

        'If bFactura Then

        '    If bImpuestoGlb Then
        '        vlConsulta.AppendLine("set nocount on ")
        '        vlConsulta.AppendLine("if (select object_id('tempdb..#ImpNoDes')) is not null drop table #ImpNoDes ")
        '        vlConsulta.AppendLine("select * into #ImpNoDes from ( ")
        '        vlConsulta.AppendLine("select TDI.TransProdID, TDI.TransProdDetalleID, sum(TDI.ImpuestoPU) as ImpuestoPU ")
        '        vlConsulta.AppendLine("from TPDImpuesto TDI ")
        '        vlConsulta.AppendLine("inner join TransProd TRP on TDI.TransProdID = TRP.TransProdID ")
        '        vlConsulta.AppendLine("where TRP.FacturaId = '" & Me.TransProdID & "' and TRP.Tipo = 1 and TDI.ImpuestoClave in ( ")
        '        vlConsulta.AppendLine("select ImpuestoClave ")
        '        vlConsulta.AppendLine("from CLINoDesImp ")
        '        vlConsulta.AppendLine("where ClienteClave = '" & sClienteClave & "' and '" & Me.FechaHoraAlta.ToString("s") & "' between FechaInicio and FechaFin) ")
        '        vlConsulta.AppendLine("group by TDI.TransProdID, TDI.TransProdDetalleID ")
        '        vlConsulta.AppendLine(") as t ")

        '        vlConsulta.AppendLine("select sum(TPD.Cantidad) as Cantidad, ")
        '        vlConsulta.AppendLine("(select Descripcion from VAVDescripcion where VARCodigo = 'UNIDADV' and VAVClave = TPD.TipoUnidad and VADTipoLenguaje = dbo.FNObtenerLenguaje()) as Unidad, ")
        '        vlConsulta.AppendLine("TPD.ProductoClave, PRO.Nombre as Descripcion, ")
        '        vlConsulta.AppendLine("TPD.Precio + isnull(IMP.ImpuestoPU,0) as ValorUnitario1, sum(TPD.Cantidad * (TPD.Precio + isnull(IMP.ImpuestoPU,0))) as Importe1 ")
        '        vlConsulta.AppendLine("from TransProd TRP ")
        '        vlConsulta.AppendLine("inner join TransProdDetalle TPD on TRP.TransProdId = TPD.TransProdId ")
        '        vlConsulta.AppendLine("inner join Producto PRO on PRO.ProductoClave = TPD.ProductoClave ")
        '        vlConsulta.AppendLine("left join #ImpNoDes IMP on TPD.TransProdID = IMP.TransProdId and TPD.TransProdDetalleID = IMP.TransProdDetalleId ")
        '        vlConsulta.AppendLine("where TRP.Tipo = 1 and TRP.FacturaId = '" & Me.TransProdID & "' ")
        '        vlConsulta.AppendLine("group by TPD.ProductoClave, TPD.TipoUnidad, TPD.Precio ,IMP.ImpuestoPU, PRO.Nombre ")
        '        vlConsulta.AppendLine("order by tpd.productoclave, TPD.TipoUnidad, TPD.Precio ,IMP.ImpuestoPU, PRO.Nombre ")

        '        vlConsulta.AppendLine("drop table #ImpNoDes ")
        '        vlConsulta.AppendLine("set nocount on ")
        '    Else
        '        vlConsulta.AppendLine("select sum(TPD.Cantidad) as Cantidad, ")
        '        vlConsulta.AppendLine("(select Descripcion from VAVDescripcion where VARCodigo = 'UNIDADV' and VAVClave = TPD.TipoUnidad and VADTipoLenguaje = dbo.FNObtenerLenguaje()) as Unidad, ")
        '        vlConsulta.AppendLine("TPD.ProductoClave, PRO.Nombre as Descripcion, ")
        '        vlConsulta.AppendLine("TPD.Precio as ValorUnitario1, sum(TPD.Cantidad * TPD.Precio) as Importe1 ")
        '        vlConsulta.AppendLine("from TransProd TRP ")
        '        vlConsulta.AppendLine("inner join TransProdDetalle TPD on TRP.TransProdId = TPD.TransProdId ")
        '        vlConsulta.AppendLine("inner join Producto PRO on PRO.ProductoClave = TPD.ProductoClave ")
        '        vlConsulta.AppendLine("where TRP.Tipo = 1 and TRP.FacturaId = '" & Me.TransProdID & "' ")
        '        vlConsulta.AppendLine("group by TPD.ProductoClave, TPD.TipoUnidad, TPD.Precio, PRO.Nombre ")
        '        vlConsulta.AppendLine("order by tpd.productoclave, TPD.TipoUnidad, TPD.Precio, PRO.Nombre ")
        '    End If

        'Else
        '    vlConsulta.AppendLine("select sum(TPD.Cantidad) as Cantidad, ")
        '    vlConsulta.AppendLine("(select descripcion from vavdescripcion  where varcodigo = 'unidadv' and vavclave = tpd.tipounidad and VADTipoLenguaje = dbo.FNObtenerLenguaje()) as unidad, ")
        '    vlConsulta.AppendLine("tpd.productoclave, pro.nombre as descripcion, ")
        '    vlConsulta.AppendLine("precio as valorUnitario1, sum((cantidad * precio)) as importe1 ")
        '    vlConsulta.AppendLine("from transprod TRP  ")
        '    vlConsulta.AppendLine("inner join transProdDetalle TPD on TRP.transprodid = tpd.transprodid ")
        '    vlConsulta.AppendLine("inner join producto PRO on pro.productoclave = tpd.productoclave where trp.tipo=10 and trp.transprodid ='" & Me.TransProdID & "' ")
        '    vlConsulta.AppendLine("group by TPD.ProductoClave, TPD.TipoUnidad, TPD.Precio, PRO.Nombre ")
        '    vlConsulta.AppendLine("order by tpd.productoclave, TPD.TipoUnidad, TPD.Precio, PRO.Nombre ")
        'End If

        'conceptos
        vlDt = Tabla.Conexion.EjecutarConsulta(vlConsulta.ToString)
        For Each row As DataRow In vlDt.Rows
            OP_CadenaOriginal &= sValidoV3(row("cantidad"))
            OP_CadenaOriginal &= sValidoV3(row("unidad"))
            OP_CadenaOriginal &= sValidoV3(row("productoclave"))
            OP_CadenaOriginal &= sValidoV3(row("descripcion"))
            OP_CadenaOriginal &= dValido(row("valorunitario1"))
            OP_CadenaOriginal &= dValido(row("importe1"))
        Next

        'impuestos
        Dim vlImpuesto As ArrayList = Nothing
        Dim vlTasa As ArrayList = Nothing
        Dim vlImporte As ArrayList = Nothing
        Dim oTransProd As New cTransProd
        oTransProd.ImpuestosConDesc(Me.TransProdID, sClienteClave, dFechaFactura, bImpGlbOriginal, vlImpuesto, vlTasa, vlImporte)
        Dim nTotalImpuesto As Double = 0

        For i As Integer = 0 To vlImpuesto.Count - 1
            OP_CadenaOriginal &= sValidoV3(vlImpuesto.Item(i))
            OP_CadenaOriginal &= dValido(vlTasa.Item(i))
            OP_CadenaOriginal &= dValido(vlImporte.Item(i))
            nTotalImpuesto += vlImporte.Item(i)
        Next

        Dim sCmd As String
        sCmd = "select count(*) from TransProd TRP "
        sCmd &= "inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave and TRP.DiaClave = VIS.DiaClave "
        sCmd &= "inner join AddendaCliente ADC on VIS.ClienteClave = ADC.ClienteClave "
        sCmd &= "inner join Addenda ADE on ADC.ADDId = ADE.ADDID "
        sCmd &= "where TRP.TransProdID = '" & Me.TransProdID & "' and ADE.Tipo in (1,5) and Baja = 0 "

        If LbConexion.cConexion.Instancia.EjecutarComandoScalar(sCmd) > 0 Then
            OP_CadenaOriginal &= dValido(nTotalImpuesto)
        End If

        OP_CadenaOriginal &= "|"

        vlConsulta = Nothing
        vlDtFolioFiscal.Dispose()
        vlDtFolioFiscal = Nothing
        vlDt.Dispose()
        vlDt = Nothing
        oTransProd = Nothing

        Return OP_CadenaOriginal
    End Function

#End Region

#Region "CrearSelloDigital"
    Public Function CrearSelloDigital(ByVal pvCadenaOriginal As String, ByVal pvSubEmpresaId As String) As String
        Dim dt As DataTable
        dt = Me.Tabla.Conexion.EjecutarConsulta("select top 1 ArchivoPEM from semHist  where subempresaid='" + pvSubEmpresaId + "' order by mfechahora desc")

        Dim DirOpenSSL As String = """" & System.AppDomain.CurrentDomain.BaseDirectory & "OPENSSL\OPENSSL.exe" & """"
        Dim cadenaOriginal As String = System.AppDomain.CurrentDomain.BaseDirectory & "cadenaOriginal.txt"
        Dim sello As String = System.AppDomain.CurrentDomain.BaseDirectory & "sello.txt"
        Dim sello64 As String = System.AppDomain.CurrentDomain.BaseDirectory & "sello64.txt"
        Dim DirArchivoPEM As String = System.AppDomain.CurrentDomain.BaseDirectory & "ArchivoPEM.key.pem"
        Dim selloLeido As String = ""

        Try
            If dt Is Nothing Or dt.Rows.Count <= 0 Or dt.Rows(0).Item(0).ToString = "" Then Return ""

            Dim swPEM As New FileStream(DirArchivoPEM, FileMode.Create)
            Dim archbyte As Byte() = Convert.FromBase64String(dt.Rows(0).Item(0))
            swPEM.Write(archbyte, 0, archbyte.Length)
            swPEM.Close()

            Dim sw As New StreamWriter(cadenaOriginal, False)
            sw.Write(pvCadenaOriginal)
            sw.Flush()
            sw.Close()

            Dim cmd As String
            If Me.FechaFacturacion.Year < 2011 Then
                cmd = "dgst -md5 -out """ & sello & """ -sign """ & DirArchivoPEM & """ """ & cadenaOriginal & """"
            Else
                cmd = "dgst -sha1 -out """ & sello & """ -sign """ & DirArchivoPEM & """ """ & cadenaOriginal & """"
            End If


            Dim oSSLProcess As System.Diagnostics.Process
            Dim oStart As New System.Diagnostics.ProcessStartInfo(DirOpenSSL, cmd)
            oStart.WindowStyle = ProcessWindowStyle.Hidden
            oStart.CreateNoWindow = True
            oSSLProcess = Process.Start(oStart)
            oSSLProcess.WaitForExit()

            'System.Threading.Thread.Sleep(1000)

            oStart = New System.Diagnostics.ProcessStartInfo(DirOpenSSL, "enc -base64 -in """ & sello & """ -out """ & sello64 & """ -A")
            oStart.WindowStyle = ProcessWindowStyle.Hidden
            oStart.CreateNoWindow = True

            oSSLProcess = Process.Start(oStart)
            oSSLProcess.WaitForExit()
            'System.Threading.Thread.Sleep(1000)

            Dim leer_archivo As StreamReader = File.OpenText(sello64)
            selloLeido = leer_archivo.ReadToEnd()
            leer_archivo.Close()

            File.Delete(sello)
            File.Delete(sello64)
            File.Delete(cadenaOriginal)
            File.Delete(DirArchivoPEM)

        Catch ex As Exception
            Throw ex
        End Try

        Return selloLeido
    End Function

#End Region


#End Region

    'Public Function Clone() As Object Implements System.ICloneable.Clone
    '    Dim oTrp As New cTransProd
    '    oTrp.VisitaClave = Me.VisitaClave
    '    oTrp.DiaClave= 


    '    Return oTrp
    'End Function
End Class

