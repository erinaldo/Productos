
Imports System.IO
Imports System.Linq
Imports System.Xml.Linq
Imports System.Security.Cryptography
Imports System.Security.Cryptography.X509Certificates
Imports System.Security.Cryptography.Xml
Imports Selling.mx.facturacfdi.dev
Imports System.Xml.Serialization
Imports System.Xml
Imports Org.BouncyCastle.Crypto.Parameters

Module ModPOS


    Public x As signaturetype



#Region "Variables de Ventanas"

    Public Mostradores(1) As FrmTPDV
    Public numMostrador_Open As Integer = 0

    Public cReplace As String = ""
    Public MyProfile As String

    Public MetodoPago As FrmMetodoPago

    Public MtoLiquid As FrmMtoLiquid
    Public Liquid As FrmLiquid

    Public MtoVenta As FrmMtoVenta
    Public PrintServer As FrmPrintServer
    Public InvoiceServer As FrmInvoiceServer
    Public Restaurar As FrmRestaurar
    Public myTimeOut As Integer = 60
    Public ipageSize As Integer = 100
    Public VersionActual As String
    Public VersionSelling As String = "4.1.0.1"
    Public Version As String = "Versión " & VersionSelling
    Public AddProd As FrmAddProd
    Public AddEstrategia As FrmAddEstrategia
    Public ReiniciaInv As FrmReiniciaInv
    Public RegeneraCFD As FrmRegeneraCFD
    Public AddUnidad As FrmAddUnidad
    Public RepMensual As FrmRepMensual
    Public actCosto As FrmActCosto
    Public MtoNC As FrmMtoNC
    Public MtoCertificado As FrmMtoCertificado
    Public Certificado As FrmCertificado
    Public MtoFolios As FrmMtoFolios
    Public MtoAddenda As FrmMtoAddenda
    Public Addenda As FrmAddenda
    Public Folio As FrmFolio
    Public Sucursal As FrmSucursal
    Public MtoSucursales As FrmMtoSucursales
    Public MtoTransferencia As FrmMtoMOVALM
    Public Transferencia As FrmMOVALM
    Public MtoSalida As FrmMtoSalida
    Public Salida As FrmSalida

    Public MtoTraslados As FrmMtoTraslados
    Public Traslado As FrmTraslado


    Public AddAccesos As FrmAddAccesos
    Public Claves As FrmClaves
    Public Apartados As FrmCancelApartado
    Public PrvProd As FrmPrvProd
    Public Corte As FrmCorte
    Public Sync As FrmSync
    Public LogError As FrmLog
    Public Ajustar As FrmAjustar
    Public Contar As FrmContar
    Public Conteo As FrmConteos
    Public MtoOrdenes As FrmMtoOrdenes
    Public Orden As FrmOrden
    Public NCP As FrmNCP
    Public NCProveedor As FrmNCProvedor
    Public MtoCompras As FrmMtoCompras
    Public Compras As FrmCompra
    Public MtoDevCompra As FrmMtoDevCompra
    Public DevCompra As FrmDevCompra
    Public MtoIngresos As FrmMtoIngreso
    Public Ingreso As FrmIngreso
    Public CxP As FrmPagoCXP
    'Public Cancelacion As FrmCancelacion
    Public Reubicacion As FrmReubicacion
    Public MtoProveedor As FrmMtoProveedor
    Public Proveedor As FrmProveedor
    Public NC As FrmNC
    Public DevSin As FrmDevSin
    Public Devolucion As FrmDevolucion
    Public MtoCajas As FrmMtoCaja

    Public MtoContenedor As FrmMtoContenedor
    Public Contenedor As FrmContenedor

    Public MtoTransporte As FrmMtoTransporte
    Public Transporte As FrmTransporte
    Public Tarifa As FrmTarifa

    Public MtoEmpleados As FrmMtoEmpleados
    Public Caja As FrmCaja
    Public MPrincipal As FrmMain
    Public Splash As FrmSplash
    Public Login As FrmLogin
    Public Barra As FrmMenu
    Public Compania As FrmCompania
    Public Backup As FrmBackUp
    Public MtoGeografia As FrmMtoGeografia
    Public Geografia As FrmGeografia
    Public MtoUnidades As FrmMtoUnidades
    Public Unidad As FrmUnidad

    Public MtoClaves As FrmMtoClaves
    Public MtoPortafolio As FrmMtoPortafolio
    Public Portafolio As FrmPortafolio
    Public AddPortafolio As FrmAddPortafolio

    Public MtoModificadores As FrmMtoModificadores
    Public Modificador As FrmModificador
    Public AddModificador As FrmAddModificador
    Public ProdMod As FrmProdMod
    Public AddProdMod As FrmAddProdMod

    Public Clase As FrmClass
    Public MtoClass As FrmMtoClass


    Public MtoCompania As FrmMtoCompania


    Public Autoriza As FrmAutoriza
    Public MtoPDV As FrmMtoPDV
    Public PDV As FrmPDV
    ' Public Venta As FrmTPDV
    Public Envio As FrmEnvio
    Public Touch As FrmTouch
    Public Plano As FrmPlano
    Public SplashVenta As FrmSplashVenta
    Public Factura As FrmFactura
    Public Viaje As FrmViaje
    Public MtoViaje As FrmMtoViaje
    Public AddCaja As FrmAddCaja


    Public ComisionVta As FrmComisionVta
    Public MtoFacturas As FrmMtoFacturas
    Public MtoNotaCargo As FrmMtoNotaCargo
    Public NotaCargo As FrmNotaCargo
    Public Bonificacion As FrmBonificacion
    Public ComplementoPago As FrmComplementoPago
    Public LiberaPOS As FrmLiberarPOS

    Public MtoExcepcion As FrmMtoExcepcion
    Public Excepcion As FrmExcepcion

    Public MtoConteo As FrmMtoConteo
    Public MtoCXC As FrmTCaja
    Public MtoImp As FrmMtoImp
    Public Surtido As FrmSurtido
    Public Recibo As FrmRecibo
    Public Pedidos As FrmPedidos
    Public Recorte As FrmRecorte

    Public MtoAcondicionado As FrmMtoAcondicionado
    Public Acondicionado As FrmAcondicionado

    Public Impuesto As FrmImpuesto
    Public MtoMon As FrmMtoMon
    Public Moneda As FrmMoneda
    Public MtoPrinter As FrmMtoPrinter
    Public Printer As FrmPrinter
    Public MtoUsuario As FrmMtoUsuario
    Public Usuarios As FrmUsuarios
    Public MtoPerfil As FrmMtoPerfil
    Public Perfil As FrmPerfil
    Public MtoModulos As FrmMtoModulos
    Public Modulo As FrmGrupo
    Public Actividad As FrmActividad
    Public MtoProductos As FrmMtoProducto
    Public MtoExistencia As FrmMtoExistencia
    Public Producto As FrmProducto
    Public ProdDet As FrmProdDet

    Public Retencion As FrmRetencion
    Public Aplicacion As FrmAplicacion
    Public ProductoEquivalente As FrmAddEquivalente
    Public Cliente As FrmCliente
    Public Empleado As FrmEmpleado
    Public MtoCliente As FrmMtoCliente

    Public Picking As FrmPicking
    Public Confirmacion As FrmConfirmacion

    Public MtoConceptos As FrmMtoConceptos
    Public Concepto As FrmConcepto
    Public MtoNomina As FrmMtoNomina
    Public Nomina As FrmNomina
    Public ReciboNomina As FrmReciboNomina
    Public AddConcepto As FrmAddConcepto
    Public MtoMovEmpleado As FrmMtoMovEmpleado
    Public AgregaConcepto As FrmAgregaConcepto

    Public MtoValor As FrmMtoValor
    Public Valores As FrmValores
    Public MtoGasto As FrmMtoGasto
    Public Gasto As FrmGasto

    Public Bancos As FrmBank
    Public MtoBancos As FrmMtoBank
    Public Pisos As FrmPisos
    Public MtoPisos As FrmMtoPisos
    Public MtoPrecio As FrmMtoPrecio

    Public MtoTarifa As FrmMtoTarifa

    Public Precio As FrmPrecio
    Public AddPrecio As FrmAddPrecio
    Public ActualizaCosto As FrmActualizaCosto
    Public ActUtilidad As FrmActUtilidad
    Public ModPrecio As FrmModPrecio
    Public PrintLabel As FrmPrintLabel
    Public LabelSheet As FrmLabelSheet
    Public MtoLabelSheet As FrmMtoLabelSheet
    Public Ticket As FrmTicket
    Public MtoTicket As FrmMtoTicket
    Public Texto As FrmTextoTicket
    Public BuscaTicket As FrmBuscaTicket
    Public MtoDesCte As FrmMtoDescuento
    Public DesCte As FrmDescuento
    Public ModDescuento As FrmModDescuento
    Public AddClasPrint As FrmAddClasPrint
    Public MtoPromocion As FrmMtoPromocion
    Public Promocion As FrmPromocion
    Public AddCteProm As FrmAddCteProm
    Public AddPro As FrmAddPro
    Public MtoComision As FrmMtoComision
    Public Comision As FrmComision
    Public PreVenta As FrmTPV
    Public Afiliado As FrmAfiliado
    Public Entrada As FrmEntrada

    Public Structure DescVol
        Public Descuento As Double
        Public Tipo As String
    End Structure

#End Region

#Region "Variables de Conexión"

    Public BDConexion As String = ""
    Public UsuarioActual As String = ""
    Public UsuarioLogin As String = ""

    Public Licencias As Integer
    Public Candado As String = ""
    Public AccesoAutorizado As Boolean = True
    Public SucursalPredeterminada As String = ""
    Public AplicacionAutomotriz As Integer = 0

    Public AlmacenPredeterminado As String = ""

    Public pathActual As String = ""

    Public CompanyActual As String = ""
    Public TituloMain As String = ""
    Public CompanyName As String = ""
    Public IPAddress As String = ""
    Public TipoCompania As Integer

#End Region

    Public Sub calculaRetencion(ByVal TipoDocucmento As String, ByVal sDETClave As String, ByVal sPROClave As String, ByVal dPrecio As Double, ByVal iTImpuesto As Integer, ByVal sSUCClave As String)

        Dim PrecioImp As Decimal = dPrecio
        Dim ImpImporte As Decimal = 0
        Dim dtImpuesto As DataTable
        Dim i As Integer
        Dim Base As Decimal
        Dim PorcImp As Decimal = 0

        dtImpuesto = ModPOS.SiExisteRecupera("st_retencion_producto", "@PROClave", sPROClave, "@TImpuesto", iTImpuesto, "@SUCClave", sSUCClave)
        If Not dtImpuesto Is Nothing AndAlso Not dtImpuesto.Rows(0)("Valor") Is DBNull.Value Then
            For i = 0 To dtImpuesto.Rows.Count() - 1
                If dtImpuesto.Rows(i)("SobreImp") Then ' Si aplica sobre impuesto
                    If dtImpuesto.Rows(i)("TipoAplicacion") = 1 Then '1  = Porcentaje
                        ImpImporte = PrecioImp * dtImpuesto.Rows(i)("Valor")
                    Else
                        ImpImporte = dtImpuesto.Rows(i)("Valor")
                    End If
                    Base = PrecioImp
                Else
                    If dtImpuesto.Rows(i)("TipoAplicacion") = 1 Then '1 = Porcentaje
                        ImpImporte = dPrecio * dtImpuesto.Rows(i)("Valor")
                    Else
                        ImpImporte = dtImpuesto.Rows(i)("Valor")
                    End If
                    Base = dPrecio
                End If

                ModPOS.Ejecuta("st_desglosa_retencion", _
                           "@TipoDocumento", TipoDocucmento, _
                           "@DFAClave", sDETClave, _
                           "@IMPClave", dtImpuesto.Rows(i)("IMPClave"), _
                           "@Base", Base, _
                           "@PorcImp", dtImpuesto.Rows(i)("Valor"), _
                           "@Importe", Math.Round(ImpImporte, 2), _
                           "@Usuario", ModPOS.UsuarioActual)

                PrecioImp += ImpImporte

            Next
            dtImpuesto.Dispose()

        End If

    End Sub



    Public Sub previewNC(ByVal iTipoCF As Integer, ByVal sFormato As String, ByVal NCClave As String, ByVal Total As Decimal, ByVal SUCClave As String, ByVal TipoCambio As Decimal, ByVal MonDesc As String, ByVal MonRef As String, ByVal VersionCF As String)

        Dim OpenReport As New Report
        Dim pvtaDataSet As New DataSet
        pvtaDataSet.DataSetName = "pvtaDataSet"

        Select Case sFormato
            Case Is = "Clasico"
                If VersionCF = "3.3" Then
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_relacionado", "@DOCClave", NCClave, "@Tipo", "E"))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_logo_compania", "@COMClave", ModPOS.CompanyActual))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_encabezado_nc", "@NCClave", NCClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_detalle_nc33", "@NCClave", NCClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_nc_impuestos", "@NCClave", NCClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_nc", "@NCClave", NCClave))

                    OpenReport.PrintPreview("Nota de Crédito", "CREgresoCFDI33.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal(Total / TipoCambio, 2), MonDesc, MonRef).ToUpper)

                Else
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_logo_compania", "@COMClave", ModPOS.CompanyActual))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_recupera_publicidad", "@SUCClave", SUCClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_encabezado_nc", "@NCClave", NCClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_nc_detalle", "@NCClave", NCClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_nc_impuestos", "@NCClave", NCClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_nc", "@NCClave", NCClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_metodopago_nc", "@NCClave", NCClave))

                    If iTipoCF = 1 Then
                        OpenReport.PrintPreview("Nota de Crédito", "CREgresoCFD.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal(Total / TipoCambio, 2), MonDesc, MonRef).ToUpper)
                    ElseIf iTipoCF = 2 Then
                        OpenReport.PrintPreview("Nota de Crédito", "CREgresoCFDI.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal(Total / TipoCambio, 2), MonDesc, MonRef).ToUpper)

                    ElseIf iTipoCF = 3 Then
                        OpenReport.PrintPreview("Nota de Crédito", "CREgresoCBB.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal(Total / TipoCambio, 2), MonDesc, MonRef).ToUpper)

                    End If
                End If
            Case Is = "Radec"
                If VersionCF = "3.3" Then
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_relacionado", "@DOCClave", NCClave, "@Tipo", "E"))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_encabezado_nc_radec", "@NCClave", NCClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_detalle_nc_radec", "@NCClave", NCClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_nc", "@NCClave", NCClave))

                    OpenReport.PrintPreview("Nota de Crédito", "CFDNotaCredito33.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal(Total / TipoCambio, 2), MonDesc, MonRef).ToUpper)

                Else
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_encabezado_nc_radec", "@NCClave", NCClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_detalle_nc_radec", "@NCClave", NCClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_nc", "@NCClave", NCClave))

                    OpenReport.PrintPreview("Nota de Crédito", "CFDNotaCredito.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal(Total / TipoCambio, 2), MonDesc, MonRef).ToUpper)
                End If
        End Select

    End Sub

    Public Sub previewCargo(ByVal FormatCargo As String, ByVal sCARClave As String, ByVal dTotal As Decimal, ByVal TipoCambio As Decimal, ByVal MonDesc As String, ByVal MonRef As String, ByVal VersionCF As String)
        Dim OpenReport As New Report
        Dim pvtaDataSet As New DataSet
        pvtaDataSet.DataSetName = "pvtaDataSet"

        Select Case FormatCargo
            Case Is = "Clasico"
                If VersionCF = "3.3" Then
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_relacionado", "@DOCClave", sCARClave, "@Tipo", "I"))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_logo_compania", "@COMClave", ModPOS.CompanyActual))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_encabezado_cargo", "@CARClave", sCARClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_detalle_cargo33", "@CARClave", sCARClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_impuestos_cargo", "@CARClave", sCARClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_cargo", "@CARClave", sCARClave))
                    OpenReport.PrintPreview("Nota de Cargo", "CRNotaCargo33.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(dTotal / TipoCambio, 2), MonDesc, MonRef).ToUpper)

                Else
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_logo_compania", "@COMClave", ModPOS.CompanyActual))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_encabezado_cargo", "@CARClave", sCARClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_detalle_cargo", "@CARClave", sCARClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_impuestos_cargo", "@CARClave", sCARClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_cargo", "@CARClave", sCARClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_metodopago_cargo", "@CARClave", sCARClave))

                    OpenReport.PrintPreview("Nota de Cargo", "CRNotaCargo.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(dTotal / TipoCambio, 2), MonDesc, MonRef).ToUpper)
                End If
            Case Is = "Radec"
                If VersionCF = "3.3" Then
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_relacionado", "@DOCClave", sCARClave, "@Tipo", "I"))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_encabezado_cargo_radec", "@CARClave", sCARClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_detalle_cargo_radec", "@CARClave", sCARClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_cargo", "@CARClave", sCARClave))

                    OpenReport.PrintPreview("Nota de Cargo", "CFDNotaCargo33.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(dTotal / TipoCambio, 2), MonDesc, MonRef).ToUpper)

                Else
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_encabezado_cargo_radec", "@CARClave", sCARClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_detalle_cargo_radec", "@CARClave", sCARClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_cargo", "@CARClave", sCARClave))

                    OpenReport.PrintPreview("Nota de Cargo", "CFDNotaCargo.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.Redondear(dTotal / TipoCambio, 2), MonDesc, MonRef).ToUpper)
                End If
        End Select
    End Sub


    Public Sub previewFactura(ByVal iTipoCF As Integer, ByVal sFormato As String, ByVal FACClave As String, ByVal Total As Decimal, ByVal SUCClave As String, ByVal TipoCambio As Decimal, ByVal MonedaDesc As String, ByVal MonedaRef As String, ByVal VersionCF As String)

        Dim OpenReport As New Report
        Dim pvtaDataSet As New DataSet
        pvtaDataSet.DataSetName = "pvtaDataSet"
        Dim Logo As Integer = 1
        Dim dtLogo As DataTable = ModPOS.Recupera_Tabla("st_recupera_logo_fac", "@FACClave", FACClave)
        Logo = dtLogo.Rows(0)("Logo")
        dtLogo.Dispose()

        Select Case sFormato

            Case Is = "Global"
                If VersionCF = "3.3" Then
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_relacionado", "@DOCClave", FACClave, "@Tipo", "F"))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_encabezado_fac", "@FACClave", FACClave, "@Logo", Logo))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_recupera_impdet_global", "@FACClave", FACClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_fac", "@FACClave", FACClave))

                    OpenReport.PrintPreview("Factura", "CRGlobalCFDI.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal(Total / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper)
                Else
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_logo_compania", "@COMClave", ModPOS.CompanyActual))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_encabezado_fac", "@FACClave", FACClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_detalle_fac", "@FACClave", FACClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_fac", "@FACClave", FACClave))

                    OpenReport.PrintPreview("Factura", "CRGlobal.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal(Total / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper)
                End If

            Case Is = "Clasico"
                If VersionCF = "3.3" Then
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_relacionado", "@DOCClave", FACClave, "@Tipo", "F"))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_encabezado_fac", "@FACClave", FACClave, "@Logo", Logo))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_detalle_fac33", "@FACClave", FACClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_impuestos_fac", "@FACClave", FACClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_fac", "@FACClave", FACClave))

                    OpenReport.PrintPreview("Factura", "CRIngresoCFDI33.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal(Total / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper)

                Else
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_recupera_publicidad", "@SUCClave", SUCClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_logo_compania", "@COMClave", ModPOS.CompanyActual))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_encabezado_fac", "@FACClave", FACClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_detalle_fac", "@FACClave", FACClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_impuestos_fac", "@FACClave", FACClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_fac", "@FACClave", FACClave))


                    Select Case iTipoCF
                        Case Is = 1
                            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_metodopago_fac", "@FACClave", FACClave))
                            OpenReport.PrintPreview("Factura", "CRIngresoCFD.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal(Total / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper)



                        Case Is = 2
                            OpenReport.PrintPreview("Factura", "CRIngresoCFDI.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal(Total / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper)



                        Case Is = 3
                            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_metodopago_fac", "@FACClave", FACClave))
                            OpenReport.PrintPreview("Factura", "CRIngresoCBB.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal(Total / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper)


                    End Select
                End If
            Case Is = "Con Notas"
                pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_recupera_publicidad", "@SUCClave", SUCClave))
                pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_logo_compania", "@COMClave", ModPOS.CompanyActual))
                pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_encabezado_fac", "@FACClave", FACClave))
                pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_detalle_fac", "@FACClave", FACClave))
                pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_impuestos_fac", "@FACClave", FACClave))
                pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_fac", "@FACClave", FACClave))


                Select Case iTipoCF
                    Case Is = 1
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_metodopago_fac", "@FACClave", FACClave))
                        OpenReport.PrintPreview("Factura", "CRIngresoNCFD.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal(Total / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper)



                    Case Is = 2
                        OpenReport.PrintPreview("Factura", "CRIngresoNCFDI.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal(Total / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper)


                    Case Is = 3
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_metodopago_fac", "@FACClave", FACClave))
                        OpenReport.PrintPreview("Factura", "CRIngresoCBB.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal(Total / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper)


                End Select
            Case Is = "Pagare"
                If VersionCF = "3.3" Then
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_relacionado", "@DOCClave", FACClave, "@Tipo", "F"))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_encabezado_fac_radec", "@FACClave", FACClave, "@Logo", Logo))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_detalle_fac_radec33", "@FACClave", FACClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_venta_fac_radec", "@FACClave", FACClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_fac", "@FACClave", FACClave))

                    OpenReport.PrintPreview("Factura", "CFDIPagare33.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal(Total / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper)

                Else
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_encabezado_fac_radec", "@FACClave", FACClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_detalle_fac_radec", "@FACClave", FACClave, "@Logo", Logo))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_venta_fac_radec", "@FACClave", FACClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_fac", "@FACClave", FACClave))

                    OpenReport.PrintPreview("Factura", "CFDIPagare.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal(Total / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper)

                End If
            Case Is = "Pagare2"
                If VersionCF = "3.3" Then
                   
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_relacionado", "@DOCClave", FACClave, "@Tipo", "F"))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_encabezado_fac_radec", "@FACClave", FACClave, "@Logo", Logo))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_detalle_fac_radec33", "@FACClave", FACClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_venta_fac_radec", "@FACClave", FACClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_fac", "@FACClave", FACClave))

                    OpenReport.PrintPreview("Factura", "CFDIPagare2.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal(Total / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper)
                End If
            Case Is = "Radec"
                If VersionCF = "3.3" Then
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_relacionado", "@DOCClave", FACClave, "@Tipo", "F"))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_encabezado_fac_radec", "@FACClave", FACClave, "@Logo", Logo))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_detalle_fac_radec", "@FACClave", FACClave, "@Tipo", 1))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_venta_fac_radec", "@FACClave", FACClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_fac", "@FACClave", FACClave))

                    OpenReport.PrintPreview("Factura", "CFDFactura33.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal(Total / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper)

                Else
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_encabezado_fac_radec", "@FACClave", FACClave, "@Logo", Logo))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_detalle_fac_radec", "@FACClave", FACClave, "@Tipo", 1))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_venta_fac_radec", "@FACClave", FACClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_fac", "@FACClave", FACClave))

                    OpenReport.PrintPreview("Factura", "CFDFactura.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal(Total / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper)

                End If
            Case Is = "AutoZone"
                If VersionCF = "3.3" Then
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_relacionado", "@DOCClave", FACClave, "@Tipo", "F"))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_encabezado_fac_radec", "@FACClave", FACClave, "@Logo", Logo))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_detalle_fac_radec", "@FACClave", FACClave, "@Tipo", 2))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_venta_fac_radec", "@FACClave", FACClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_fac", "@FACClave", FACClave))

                    OpenReport.PrintPreview("Factura", "CFDFactura33.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal(Total / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper)

                End If

            Case Is = "LaLa"
                If VersionCF = "3.3" Then
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_relacionado", "@DOCClave", FACClave, "@Tipo", "F"))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_encabezado_fac_radec", "@FACClave", FACClave, "@Logo", Logo))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_detalle_fac_radec", "@FACClave", FACClave, "@Tipo", 3))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_venta_fac_radec", "@FACClave", FACClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_fac", "@FACClave", FACClave))

                    OpenReport.PrintPreview("Factura", "CFDFacturaLaLa33.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal(Total / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper)

                Else
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_encabezado_fac_radec", "@FACClave", FACClave, "@Logo", Logo))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_detalle_fac_radec", "@FACClave", FACClave, "@Tipo", 3))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_venta_fac_radec", "@FACClave", FACClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_fac", "@FACClave", FACClave))

                    OpenReport.PrintPreview("Factura", "CFDFacturaLaLa.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal(Total / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper)

                End If
            Case Is = "Aseguradora"
                If VersionCF = "3.3" Then
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_relacionado", "@DOCClave", FACClave, "@Tipo", "F"))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_encabezado_fac_radec", "@FACClave", FACClave, "@Logo", Logo))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_detalle_fac_radec", "@FACClave", FACClave, "@Tipo", 4))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_venta_fac_radec", "@FACClave", FACClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_fac", "@FACClave", FACClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_complemento_fac_radec", "@FACClave", FACClave))

                    OpenReport.PrintPreview("Factura", "CFDFacturaAseg33.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal(Total / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper)

                Else
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_encabezado_fac_radec", "@FACClave", FACClave, "@Logo", Logo))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_detalle_fac_radec", "@FACClave", FACClave, "@Tipo", 4))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_venta_fac_radec", "@FACClave", FACClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_fac", "@FACClave", FACClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_complemento_fac_radec", "@FACClave", FACClave))

                    OpenReport.PrintPreview("Factura", "CFDFacturaAseg.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal(Total / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper)

                End If


            Case Is = "Daimler"
                If VersionCF = "3.3" Then
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_relacionado", "@DOCClave", FACClave, "@Tipo", "F"))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_encabezado_fac_radec", "@FACClave", FACClave, "@Logo", Logo))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_detalle_fac_radec", "@FACClave", FACClave, "@Tipo", 5))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_venta_fac_radec", "@FACClave", FACClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_fac", "@FACClave", FACClave))

                    OpenReport.PrintPreview("Factura", "CFDFactura33.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal(Total / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper)

                End If



        End Select


    End Sub

    Public Sub imprimirFacturas(ByVal iTipoCF As Integer, ByVal idFactura As String, ByVal SUCClave As String, ByVal TipoCambio As Decimal, ByVal MonedaDesc As String, ByVal MonedaRef As String, ByVal PrinterInvoice As String, ByVal NumCopias As Integer, ByVal VersionCF As String)
        Dim dtFactura As DataTable = ModPOS.Recupera_Tabla("sp_lista_facturas", "@FacturaId", idFactura)
        Dim fila As Integer
        Dim sFormato As String
        For fila = 0 To dtFactura.Rows.Count - 1
            sFormato = IIf(dtFactura.Rows(fila)("Formato").GetType.Name = "DBNull", "Clasico", dtFactura.Rows(fila)("Formato"))
            Try
                ModPOS.imprimirFactura(iTipoCF, sFormato, dtFactura.Rows(fila)("FACClave"), dtFactura.Rows(fila)("Total"), SUCClave, TipoCambio, MonedaDesc, MonedaRef, PrinterInvoice, NumCopias, VersionCF)
            Catch
            End Try

        Next
        dtFactura.Dispose()
    End Sub

    Public Sub imprimirCargo(ByVal FormatCargo As String, ByVal CARClave As String, ByVal Total As Decimal, ByVal TipoCambio As Decimal, ByVal MonDesc As String, ByVal MonRef As String, ByVal sImpresora As String, ByVal iCopias As Integer, ByVal VersionCF As String)
        Dim OpenReport As New Report
        Dim pvtaDataSet As New DataSet
        pvtaDataSet.DataSetName = "pvtaDataSet"

        Select Case FormatCargo
            Case Is = "Clasico"

                If VersionCF = "3.3" Then
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_relacionado", "@DOCClave", CARClave, "@Tipo", "I"))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_logo_compania", "@COMClave", ModPOS.CompanyActual))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_encabezado_cargo", "@CARClave", CARClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_detalle_cargo33", "@CARClave", CARClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_impuestos_cargo", "@CARClave", CARClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_cargo", "@CARClave", CARClave))

                    OpenReport.Print(iCopias, "CRNotaCargo33.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal(Total / TipoCambio, 2), MonDesc, MonRef).ToUpper, sImpresora)

                Else
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_logo_compania", "@COMClave", ModPOS.CompanyActual))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_encabezado_cargo", "@CARClave", CARClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_detalle_cargo", "@CARClave", CARClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_impuestos_cargo", "@CARClave", CARClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_cargo", "@CARClave", CARClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_metodopago_cargo", "@CARClave", CARClave))

                    OpenReport.Print(iCopias, "CRNotaCargo.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal(Total / TipoCambio, 2), MonDesc, MonRef).ToUpper, sImpresora)
                End If
            Case Is = "Radec"
                If VersionCF = "3.3" Then
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_relacionado", "@DOCClave", CARClave, "@Tipo", "I"))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_encabezado_cargo_radec", "@CARClave", CARClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_detalle_cargo_radec", "@CARClave", CARClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_cargo", "@CARClave", CARClave))

                    OpenReport.Print(iCopias, "CFDNotaCargo33.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal(Total / TipoCambio, 2), MonDesc, MonRef).ToUpper, sImpresora)

                Else
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_encabezado_cargo_radec", "@CARClave", CARClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_detalle_cargo_radec", "@CARClave", CARClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_cargo", "@CARClave", CARClave))

                    OpenReport.Print(iCopias, "CFDNotaCargo.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal(Total / TipoCambio, 2), MonDesc, MonRef).ToUpper, sImpresora)

                End If

        End Select


    End Sub


    Public Sub imprimirNC(ByVal iTipoCF As Integer, ByVal sFormato As String, ByVal NCClave As String, ByVal Total As Decimal, ByVal SUCClave As String, ByVal TipoCambio As Decimal, ByVal MonedaDesc As String, ByVal MonedaRef As String, ByVal sImpresora As String, ByVal NumCopias As Integer, ByVal VersionCF As String)

        If NumCopias <= 0 Then
            NumCopias = 1
        End If

        Dim OpenReport As New Report
        Dim pvtaDataSet As New DataSet
        pvtaDataSet.DataSetName = "pvtaDataSet"

        Select Case sFormato
            Case Is = "Clasico"

                If VersionCF = "3.3" Then
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_relacionado", "@DOCClave", NCClave, "@Tipo", "E"))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_logo_compania", "@COMClave", ModPOS.CompanyActual))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_encabezado_nc", "@NCClave", NCClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_detalle_nc33", "@NCClave", NCClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_nc_impuestos", "@NCClave", NCClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_nc", "@NCClave", NCClave))

                    OpenReport.Print(NumCopias, "CREgresoCFDI33.rpt", pvtaDataSet, ModPOS.LetrasM(TruncateToDecimal(Total / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper, sImpresora)

                Else
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_logo_compania", "@COMClave", ModPOS.CompanyActual))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_recupera_publicidad", "@SUCClave", SUCClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_encabezado_nc", "@NCClave", NCClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_nc_detalle", "@NCClave", NCClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_nc_impuestos", "@NCClave", NCClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_nc", "@NCClave", NCClave))

                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_metodopago_nc", "@NCClave", NCClave))

                    If iTipoCF = 1 Then
                        OpenReport.Print(NumCopias, "CREgresoCFD.rpt", pvtaDataSet, ModPOS.LetrasM(TruncateToDecimal(Total / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper, sImpresora)
                    ElseIf iTipoCF = 2 Then
                        OpenReport.Print(NumCopias, "CREgresoCFDI.rpt", pvtaDataSet, ModPOS.LetrasM(TruncateToDecimal(Total / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper, sImpresora)
                    ElseIf iTipoCF = 3 Then
                        OpenReport.Print(NumCopias, "CREgresoCBB.rpt", pvtaDataSet, ModPOS.LetrasM(TruncateToDecimal(Total / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper, sImpresora)
                    End If
                End If

            Case Is = "Radec"

                If VersionCF = "3.3" Then
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_relacionado", "@DOCClave", NCClave, "@Tipo", "E"))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_encabezado_nc_radec", "@NCClave", NCClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_detalle_nc_radec", "@NCClave", NCClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_nc", "@NCClave", NCClave))

                    OpenReport.Print(NumCopias, "CFDNotaCredito33.rpt", pvtaDataSet, ModPOS.LetrasM(TruncateToDecimal(Total / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper, sImpresora)

                Else
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_encabezado_nc_radec", "@NCClave", NCClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_detalle_nc_radec", "@NCClave", NCClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_nc", "@NCClave", NCClave))

                    OpenReport.Print(NumCopias, "CFDNotaCredito.rpt", pvtaDataSet, ModPOS.LetrasM(TruncateToDecimal(Total / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper, sImpresora)
                End If
        End Select


    End Sub



    Public Sub imprimirFactura(ByVal iTipoCF As Integer, ByVal sFormato As String, ByVal FACClave As String, ByVal Total As Decimal, ByVal SUCClave As String, ByVal TipoCambio As Decimal, ByVal MonedaDesc As String, ByVal MonedaRef As String, ByVal PrinterInvoice As String, ByVal NumCopias As Integer, ByVal VersionCF As String)

        Dim OpenReport As New Report
        Dim pvtaDataSet As New DataSet
        pvtaDataSet.DataSetName = "pvtaDataSet"

        Dim Logo As Integer = 1
        Dim dtLogo As DataTable = ModPOS.Recupera_Tabla("st_recupera_logo_fac", "@FACClave", FACClave)
        Logo = dtLogo.Rows(0)("Logo")
        dtLogo.Dispose()


        Select Case sFormato
            Case Is = "Global"
                If VersionCF = "3.3" Then
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_relacionado", "@DOCClave", FACClave, "@Tipo", "F"))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_encabezado_fac", "@FACClave", FACClave, "@Logo", Logo))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_recupera_impdet_global", "@FACClave", FACClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_fac", "@FACClave", FACClave))

                    OpenReport.Print(NumCopias, "CRGlobalCFDI.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal(Total / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper, PrinterInvoice)
                Else
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_logo_compania", "@COMClave", ModPOS.CompanyActual))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_encabezado_fac", "@FACClave", FACClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_detalle_fac", "@FACClave", FACClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_fac", "@FACClave", FACClave))

                    OpenReport.Print(NumCopias, "CRGlobal.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal(Total / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper, PrinterInvoice)

                End If

            Case Is = "Clasico"
                If VersionCF = "3.3" Then
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_relacionado", "@DOCClave", FACClave, "@Tipo", "F"))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_encabezado_fac", "@FACClave", FACClave, "@Logo", Logo))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_detalle_fac33", "@FACClave", FACClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_impuestos_fac", "@FACClave", FACClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_fac", "@FACClave", FACClave))

                    OpenReport.Print(NumCopias, "CRIngresoCFDI33.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal(Total / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper, PrinterInvoice)

                Else
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_recupera_publicidad", "@SUCClave", SUCClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_logo_compania", "@COMClave", ModPOS.CompanyActual))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_encabezado_fac", "@FACClave", FACClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_detalle_fac", "@FACClave", FACClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_impuestos_fac", "@FACClave", FACClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_fac", "@FACClave", FACClave))


                    Select Case iTipoCF
                        Case Is = 1
                            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_metodopago_fac", "@FACClave", FACClave))
                            OpenReport.Print(NumCopias, "CRIngresoCFD.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal(Total / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper, PrinterInvoice)

                        Case Is = 2
                            OpenReport.Print(NumCopias, "CRIngresoCFDI.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal(Total / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper, PrinterInvoice)


                        Case Is = 3
                            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_metodopago_fac", "@FACClave", FACClave))
                            OpenReport.Print(NumCopias, "CRIngresoCBB.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal(Total / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper, PrinterInvoice)


                    End Select

                End If

            Case Is = "Con Notas"
                pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_recupera_publicidad", "@SUCClave", SUCClave))
                pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_logo_compania", "@COMClave", ModPOS.CompanyActual))
                pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_encabezado_fac", "@FACClave", FACClave))
                pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_detalle_fac", "@FACClave", FACClave))
                pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_impuestos_fac", "@FACClave", FACClave))
                pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_fac", "@FACClave", FACClave))


                Select Case iTipoCF
                    Case Is = 1
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_metodopago_fac", "@FACClave", FACClave))
                        OpenReport.Print(NumCopias, "CRIngresoNCFD.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal(Total / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper, PrinterInvoice)


                    Case Is = 2
                        OpenReport.Print(NumCopias, "CRIngresoNCFDI.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal(Total / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper, PrinterInvoice)


                    Case Is = 3
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_metodopago_fac", "@FACClave", FACClave))
                        OpenReport.Print(NumCopias, "CRIngresoCBB.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal(Total / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper, PrinterInvoice)


                End Select
            Case Is = "Pagare"
                If VersionCF = "3.3" Then
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_relacionado", "@DOCClave", FACClave, "@Tipo", "F"))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_encabezado_fac_radec", "@FACClave", FACClave, "@Logo", Logo))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_detalle_fac_radec33", "@FACClave", FACClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_venta_fac_radec", "@FACClave", FACClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_fac", "@FACClave", FACClave))

                    OpenReport.Print(NumCopias, "CFDIPagare33.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal(Total / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper, PrinterInvoice)

                Else
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_encabezado_fac_radec", "@FACClave", FACClave, "@Logo", Logo))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_detalle_fac_radec", "@FACClave", FACClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_venta_fac_radec", "@FACClave", FACClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_fac", "@FACClave", FACClave))

                    OpenReport.Print(NumCopias, "CFDIPagare.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal(Total / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper, PrinterInvoice)
                End If
            Case Is = "Pagare2"
                If VersionCF = "3.3" Then
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_relacionado", "@DOCClave", FACClave, "@Tipo", "F"))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_encabezado_fac_radec", "@FACClave", FACClave, "@Logo", Logo))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_detalle_fac_radec33", "@FACClave", FACClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_venta_fac_radec", "@FACClave", FACClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_fac", "@FACClave", FACClave))

                    OpenReport.Print(NumCopias, "CFDIPagare2.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal(Total / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper, PrinterInvoice)
                End If

            Case Is = "Radec"
                If VersionCF = "3.3" Then
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_relacionado", "@DOCClave", FACClave, "@Tipo", "F"))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_encabezado_fac_radec", "@FACClave", FACClave, "@Logo", Logo))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_detalle_fac_radec", "@FACClave", FACClave, "@Tipo", 1))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_venta_fac_radec", "@FACClave", FACClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_fac", "@FACClave", FACClave))

                    OpenReport.Print(NumCopias, "CFDFactura33.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal(Total / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper, PrinterInvoice)

                Else
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_encabezado_fac_radec", "@FACClave", FACClave, "@Logo", Logo))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_detalle_fac_radec", "@FACClave", FACClave, "@Tipo", 1))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_venta_fac_radec", "@FACClave", FACClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_fac", "@FACClave", FACClave))

                    OpenReport.Print(NumCopias, "CFDFactura.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal(Total / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper, PrinterInvoice)

                End If
            Case Is = "AutoZone"
                If VersionCF = "3.3" Then
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_relacionado", "@DOCClave", FACClave, "@Tipo", "F"))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_encabezado_fac_radec", "@FACClave", FACClave, "@Logo", Logo))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_detalle_fac_radec", "@FACClave", FACClave, "@Tipo", 2))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_venta_fac_radec", "@FACClave", FACClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_fac", "@FACClave", FACClave))

                    OpenReport.Print(NumCopias, "CFDFactura33.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal(Total / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper, PrinterInvoice)
                End If
            Case Is = "LaLa"
                If VersionCF = "3.3" Then
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_relacionado", "@DOCClave", FACClave, "@Tipo", "F"))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_encabezado_fac_radec", "@FACClave", FACClave, "@Logo", Logo))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_detalle_fac_radec", "@FACClave", FACClave, "@Tipo", 3))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_venta_fac_radec", "@FACClave", FACClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_fac", "@FACClave", FACClave))

                    OpenReport.Print(NumCopias, "CFDFacturaLaLa33.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal(Total / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper, PrinterInvoice)

                Else
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_encabezado_fac_radec", "@FACClave", FACClave, "@Logo", Logo))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_detalle_fac_radec", "@FACClave", FACClave, "@Tipo", 3))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_venta_fac_radec", "@FACClave", FACClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_fac", "@FACClave", FACClave))

                    OpenReport.Print(NumCopias, "CFDFacturaLaLa.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal(Total / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper, PrinterInvoice)

                End If
            Case Is = "Aseguradora"
                If VersionCF = "3.3" Then
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_relacionado", "@DOCClave", FACClave, "@Tipo", "F"))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_encabezado_fac_radec", "@FACClave", FACClave, "@Logo", Logo))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_detalle_fac_radec", "@FACClave", FACClave, "@Tipo", 4))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_venta_fac_radec", "@FACClave", FACClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_fac", "@FACClave", FACClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_complemento_fac_radec", "@FACClave", FACClave))

                    OpenReport.Print(NumCopias, "CFDFacturaAseg33.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal(Total / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper, PrinterInvoice)

                Else
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_encabezado_fac_radec", "@FACClave", FACClave, "@Logo", Logo))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_detalle_fac_radec", "@FACClave", FACClave, "@Tipo", 4))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_venta_fac_radec", "@FACClave", FACClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_fac", "@FACClave", FACClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_complemento_fac_radec", "@FACClave", FACClave))

                    OpenReport.Print(NumCopias, "CFDFacturaAseg.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal(Total / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper, PrinterInvoice)

                End If

            Case Is = "Daimler"
                If VersionCF = "3.3" Then
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_relacionado", "@DOCClave", FACClave, "@Tipo", "F"))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_encabezado_fac_radec", "@FACClave", FACClave, "@Logo", Logo))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_detalle_fac_radec", "@FACClave", FACClave, "@Tipo", 5))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_venta_fac_radec", "@FACClave", FACClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_fac", "@FACClave", FACClave))

                    OpenReport.Print(NumCopias, "CFDFactura33.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal(Total / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper, PrinterInvoice)
                End If

        End Select


    End Sub

    Public Function SendMailNC(ByVal VersionCF As String, ByVal email As String, ByVal TipoCF As Integer, ByVal sFormato As String, ByVal Fecha As Date, ByVal Folio As String, ByVal NCClave As String, ByVal Total As Decimal, ByVal MailAdress As String, ByVal MailUser As String, MailPassword As String, ByVal HostSMTP As String, ByVal MailPort As Integer, ByVal MailSSL As Boolean, ByVal DisplayName As String, ByVal PathXML As String, ByVal SUCClave As String, ByVal TipoCambio As Decimal, ByVal MonedaDesc As String, ByVal MonedaRef As String, Optional ByVal ShowMsg As Boolean = True) As String
        Dim sPathXML, PathPDF, sMailCliente As String
        Dim correo As System.Net.Mail.MailMessage
        Dim adjuntos As System.Net.Mail.Attachment
        Dim autenticar As System.Net.NetworkCredential
        Dim envio As System.Net.Mail.SmtpClient
        Dim dato As System.IO.FileStream

        sMailCliente = email


        If MailAdress = "" OrElse MailUser = "" OrElse MailPassword = "" OrElse HostSMTP = "" OrElse MailPort = 0 Then
            If ShowMsg = True Then
                MessageBox.Show("No se ha configurado una cuenta de correo para envio de información en el Menú de Configuración\Compañia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return "No se ha configurado una cuenta de correo para envio de información en el Menú de Configuración\Compañia"
        End If

        'Verifica que exista el path
        If TipoCF <= 2 Then
            Try
                If Not System.IO.Directory.Exists(PathXML) Then
                    If ShowMsg = True Then
                        MessageBox.Show("El directorio " & PathXML & " para guardar los XML no existe o no se puede tener acceso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                    Return "El directorio " & PathXML & " para guardar los XML no existe o no se puede tener acceso"
                End If
            Catch ex As Exception
            End Try
        End If

        Dim frmStatusMessage As New frmStatus


        PathPDF = pathActual & "Temp\" & Folio & ".PDF"

        'Genera PDF
        Dim OpenReport As New Report
        Dim pvtaDataSet As New DataSet
        pvtaDataSet.DataSetName = "pvtaDataSet"

        Select Case sFormato
            Case Is = "Clasico"
                If VersionCF = "3.3" Then
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_relacionado", "@DOCClave", NCClave, "@Tipo", "E"))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_logo_compania", "@COMClave", ModPOS.CompanyActual))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_encabezado_nc", "@NCClave", NCClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_detalle_nc33", "@NCClave", NCClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_nc_impuestos", "@NCClave", NCClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_nc", "@NCClave", NCClave))

                    OpenReport.PrintPDF("CREgresoCFDI33.rpt", pvtaDataSet, ModPOS.LetrasM(TruncateToDecimal(Total / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper, PathPDF)
                Else
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_logo_compania", "@COMClave", ModPOS.CompanyActual))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_recupera_publicidad", "@SUCClave", SUCClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_encabezado_nc", "@NCClave", NCClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_nc_detalle", "@NCClave", NCClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_nc_impuestos", "@NCClave", NCClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_nc", "@NCClave", NCClave))

                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_metodopago_nc", "@NCClave", NCClave))

                    If TipoCF = 1 Then
                        OpenReport.PrintPDF("CREgresoCFD.rpt", pvtaDataSet, ModPOS.LetrasM(TruncateToDecimal(Total / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper, PathPDF)
                    ElseIf TipoCF = 2 Then
                        OpenReport.PrintPDF("CREgresoCFDI.rpt", pvtaDataSet, ModPOS.LetrasM(TruncateToDecimal(Total / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper, PathPDF)
                    ElseIf TipoCF = 3 Then
                        OpenReport.PrintPDF("CREgresoCBB.rpt", pvtaDataSet, ModPOS.LetrasM(TruncateToDecimal(Total / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper, PathPDF)
                    End If
                End If

            Case Is = "Radec"
                If VersionCF = "3.3" Then
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_relacionado", "@DOCClave", NCClave, "@Tipo", "E"))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_encabezado_nc_radec", "@NCClave", NCClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_detalle_nc_radec", "@NCClave", NCClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_nc", "@NCClave", NCClave))

                    OpenReport.PrintPDF("CFDNotaCredito33.rpt", pvtaDataSet, ModPOS.LetrasM(TruncateToDecimal(Total / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper, PathPDF)

                Else
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_encabezado_nc_radec", "@NCClave", NCClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_detalle_nc_radec", "@NCClave", NCClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_nc", "@NCClave", NCClave))

                    OpenReport.PrintPDF("CFDNotaCredito.rpt", pvtaDataSet, ModPOS.LetrasM(TruncateToDecimal(Total / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper, PathPDF)
                End If
        End Select

        If Not System.IO.File.Exists(PathPDF) Then
            If ShowMsg = True Then
                MessageBox.Show("Ha ocurrido un error al generar el archivo: " & PathPDF, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return "Ha ocurrido un error al generar el archivo: " & PathPDF
        End If

        'Envia Correo

        sPathXML = PathXML
        If sPathXML.Length > 3 AndAlso sPathXML.Substring(sPathXML.Length - 1, 1) <> "\" Then
            sPathXML &= "\"
        End If

        sPathXML &= Fecha.Year.ToString & "\" & Fecha.Month.ToString & "\" & Fecha.Day.ToString & "\" & Folio & ".xml"

        If TipoCF <= 2 AndAlso Not System.IO.File.Exists(sPathXML) Then
            If ShowMsg = True Then
                MessageBox.Show("Ha ocurrido un error, No se ha encontrado el archivo: " & sPathXML, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return "Ha ocurrido un error, No se ha encontrado el archivo: " & sPathXML
        Else
            Try
                correo = New System.Net.Mail.MailMessage
                autenticar = New System.Net.NetworkCredential
                envio = New System.Net.Mail.SmtpClient

                If TipoCF <= 2 Then
                    correo.Body = "Estimado Cliente, le hacemos llegar por este medio la Representación Impresa de su Nota de Crédito/Bonificación (*.PDF) y el Comprobante Fiscal Digital (*.XML), Agradecemos su Preferencia y Esperamos Verlo Pronto. Saludos."
                ElseIf TipoCF = 3 Then
                    correo.Body = "Estimado Cliente, le hacemos llegar por este medio la Representación Impresa de su Nota de Crédito/Bonificación (*.PDF), Agradecemos su Preferencia y Esperamos Verlo Pronto. Saludos."
                End If

                correo.Subject = "Nota de Crédito/Bonificación " & Folio
                correo.IsBodyHtml = True
                correo.To.Clear()
                correo.CC.Clear()
                correo.Bcc.Clear()


                If sMailCliente.Split(",").Length >= 1 Then
                    Dim i As Integer
                    For i = 0 To sMailCliente.Split(",").Length - 1
                        If sMailCliente.Split(",")(i) <> "" Then
                            correo.To.Add(sMailCliente.Split(",")(i))
                        End If
                    Next
                Else
                    correo.To.Add(sMailCliente)
                End If


                correo.From = New System.Net.Mail.MailAddress(MailAdress, DisplayName)
                envio.Credentials = New System.Net.NetworkCredential(MailUser, MailPassword)
                envio.Host = HostSMTP  '"smtp.live.com"
                envio.Port = MailPort  '587
                envio.EnableSsl = MailSSL 'True

                frmStatusMessage.Show("Enviando correo electrónico...")

                If TipoCF <= 2 Then
                    dato = New System.IO.FileStream(sPathXML, System.IO.FileMode.Open, System.IO.FileAccess.Read)
                    adjuntos = New System.Net.Mail.Attachment(dato, Folio & ".XML")
                    correo.Attachments.Add(adjuntos)
                End If

                dato = New System.IO.FileStream(PathPDF, System.IO.FileMode.Open, System.IO.FileAccess.Read)
                adjuntos = New System.Net.Mail.Attachment(dato, Folio & ".PDF")
                correo.Attachments.Add(adjuntos)


                envio.Send(correo)
                correo.Dispose()

                If ShowMsg = True Then
                    MessageBox.Show("El mensaje fue enviado correctamente a el destinatario", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    frmStatusMessage.Show("El mensaje fue enviado correctamente a el destinatario")

                End If

                frmStatusMessage.Dispose()
            Catch ex As Exception
                frmStatusMessage.Dispose()
                MessageBox.Show(ex.Message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            If Not dato Is Nothing Then
                dato.Close()
            End If

            Try
                My.Computer.FileSystem.DeleteFile(PathPDF, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
        End If

        Return ""

    End Function
    Public Function SendMailCargo(ByVal VersionCF As String, ByVal email As String, ByVal FormatCargo As String, ByVal Fecha As Date, ByVal Folio As String, ByVal CARClave As String, ByVal Total As Decimal, ByVal MailAdress As String, ByVal MailUser As String, MailPassword As String, ByVal HostSMTP As String, ByVal MailPort As Integer, ByVal MailSSL As Boolean, ByVal DisplayName As String, ByVal PathXML As String, ByVal TipoCambio As Decimal, ByVal MonDesc As String, ByVal MonRef As String, Optional ByVal ShowMsg As Boolean = True) As String

        Dim sPathXML, PathPDF, sMailCliente As String
        Dim correo As System.Net.Mail.MailMessage
        Dim adjuntos As System.Net.Mail.Attachment
        Dim autenticar As System.Net.NetworkCredential
        Dim envio As System.Net.Mail.SmtpClient
        Dim dato As System.IO.FileStream

        sMailCliente = email


        If MailAdress = "" OrElse MailUser = "" OrElse MailPassword = "" OrElse HostSMTP = "" OrElse MailPort = 0 Then
            If ShowMsg = True Then
                MessageBox.Show("No se ha configurado una cuenta de correo para envio de información en el Menú de Configuración\Compañia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return "No se ha configurado una cuenta de correo para envio de información en el Menú de Configuración\Compañia"
        End If

        Try
            If Not System.IO.Directory.Exists(PathXML) Then
                If ShowMsg = True Then
                    MessageBox.Show("El directorio " & PathXML & " para guardar los XML no existe o no se puede tener acceso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                Return "El directorio " & PathXML & " para guardar los XML no existe o no se puede tener acceso"
            End If
        Catch ex As Exception
        End Try

        Dim frmStatusMessage As New frmStatus


        PathPDF = pathActual & "Temp\" & Folio & ".PDF"

        Dim OpenReport As New Report
        Dim pvtaDataSet As New DataSet
        pvtaDataSet.DataSetName = "pvtaDataSet"

        Select Case FormatCargo
            Case Is = "Clasico"
                If VersionCF = "3.3" Then
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_relacionado", "@DOCClave", CARClave, "@Tipo", "I"))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_logo_compania", "@COMClave", ModPOS.CompanyActual))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_encabezado_cargo", "@CARClave", CARClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_detalle_cargo33", "@CARClave", CARClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_impuestos_cargo", "@CARClave", CARClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_cargo", "@CARClave", CARClave))

                    OpenReport.PrintPDF("CRNotaCargo33.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal(Total / TipoCambio, 2), MonDesc, MonRef).ToUpper, PathPDF)

                Else

                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_logo_compania", "@COMClave", ModPOS.CompanyActual))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_encabezado_cargo", "@CARClave", CARClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_detalle_cargo", "@CARClave", CARClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_impuestos_cargo", "@CARClave", CARClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_cargo", "@CARClave", CARClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_metodopago_cargo", "@CARClave", CARClave))


                    OpenReport.PrintPDF("CRNotaCargo.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal(Total / TipoCambio, 2), MonDesc, MonRef).ToUpper, PathPDF)
                End If
            Case Is = "Radec"
                If VersionCF = "3.3" Then
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_relacionado", "@DOCClave", CARClave, "@Tipo", "I"))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_encabezado_cargo_radec", "@CARClave", CARClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_detalle_cargo_radec", "@CARClave", CARClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_cargo", "@CARClave", CARClave))

                    OpenReport.PrintPDF("CFDNotaCargo33.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal(Total / TipoCambio, 2), MonDesc, MonRef).ToUpper, PathPDF)

                Else
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_encabezado_cargo_radec", "@CARClave", CARClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_detalle_cargo_radec", "@CARClave", CARClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_cargo", "@CARClave", CARClave))

                    OpenReport.PrintPDF("CFDNotaCargo.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal(Total / TipoCambio, 2), MonDesc, MonRef).ToUpper, PathPDF)
                End If
        End Select

        If Not System.IO.File.Exists(PathPDF) Then
            If ShowMsg = True Then
                MessageBox.Show("Ha ocurrido un error al generar el archivo: " & PathPDF, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return "Ha ocurrido un error al generar el archivo: " & PathPDF
        End If

        'Envia Correo

        sPathXML = PathXML
        If sPathXML.Length > 3 AndAlso sPathXML.Substring(sPathXML.Length - 1, 1) <> "\" Then
            sPathXML &= "\"
        End If

        sPathXML &= Fecha.Year.ToString & "\" & Fecha.Month.ToString & "\" & Fecha.Day.ToString & "\" & Folio & ".xml"


        If Not System.IO.File.Exists(sPathXML) Then
            If ShowMsg = True Then
                MessageBox.Show("Ha ocurrido un error, No se ha encontrado el archivo: " & sPathXML, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return "Ha ocurrido un error, No se ha encontrado el archivo: " & sPathXML
        Else
            Try
                correo = New System.Net.Mail.MailMessage
                autenticar = New System.Net.NetworkCredential
                envio = New System.Net.Mail.SmtpClient


                correo.Body = "Estimado Cliente, le hacemos llegar por este medio la Representación Impresa de su Nota de Cargo (*.PDF) y el Comprobante Fiscal Digital (*.XML), Agradecemos su Preferencia y Esperamos Verlo Pronto. Saludos."
                correo.Subject = "Nota de Cargo " & Folio
                correo.IsBodyHtml = True
                correo.To.Clear()
                correo.CC.Clear()
                correo.Bcc.Clear()


                If sMailCliente.Split(",").Length >= 1 Then
                    Dim j As Integer
                    For j = 0 To sMailCliente.Split(",").Length - 1
                        If sMailCliente.Split(",")(j) <> "" Then
                            correo.To.Add(sMailCliente.Split(",")(j))
                        End If
                    Next
                Else
                    correo.To.Add(sMailCliente)
                End If


                correo.From = New System.Net.Mail.MailAddress(MailAdress, DisplayName)
                envio.Credentials = New System.Net.NetworkCredential(MailUser, MailPassword)
                envio.Host = HostSMTP  '"smtp.live.com"
                envio.Port = MailPort  '587
                envio.EnableSsl = MailSSL 'True

                frmStatusMessage.Show("Enviando correo electrónico...")


                dato = New System.IO.FileStream(sPathXML, System.IO.FileMode.Open, System.IO.FileAccess.Read)
                adjuntos = New System.Net.Mail.Attachment(dato, Folio & ".XML")
                correo.Attachments.Add(adjuntos)


                dato = New System.IO.FileStream(PathPDF, System.IO.FileMode.Open, System.IO.FileAccess.Read)
                adjuntos = New System.Net.Mail.Attachment(dato, Folio & ".PDF")
                correo.Attachments.Add(adjuntos)

                envio.Send(correo)
                correo.Dispose()

                If ShowMsg = True Then
                    MessageBox.Show("El mensaje fue enviado correctamente a el destinatario", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    frmStatusMessage.Show("El mensaje fue enviado correctamente a el destinatario")

                End If

                frmStatusMessage.Dispose()
            Catch ex As Exception
                frmStatusMessage.Dispose()
                MessageBox.Show(ex.Message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            If Not dato Is Nothing Then
                dato.Close()
            End If

            Try
                My.Computer.FileSystem.DeleteFile(PathPDF, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
        End If

        Return ""


    End Function

    Public Function SendMail(ByVal VersionCF As String, ByVal email As String, ByVal TipoCF As Integer, ByVal sFormato As String, ByVal Fecha As Date, ByVal Folio As String, ByVal FACClave As String, ByVal Total As Decimal, ByVal MailAdress As String, ByVal MailUser As String, MailPassword As String, ByVal HostSMTP As String, ByVal MailPort As Integer, ByVal MailSSL As Boolean, ByVal DisplayName As String, ByVal PathXML As String, ByVal SUCClave As String, ByVal TipoCambio As Decimal, ByVal MonedaDesc As String, ByVal MonedaRef As String, Optional ByVal ShowMsg As Boolean = True) As String

        Dim sPathXML, PathPDF, sMailCliente As String
        Dim correo As System.Net.Mail.MailMessage
        Dim adjuntos As System.Net.Mail.Attachment
        Dim autenticar As System.Net.NetworkCredential
        Dim envio As System.Net.Mail.SmtpClient
        Dim dato As System.IO.FileStream

        sMailCliente = email


        If MailAdress = "" OrElse MailUser = "" OrElse MailPassword = "" OrElse HostSMTP = "" OrElse MailPort = 0 Then
            If ShowMsg = True Then
                MessageBox.Show("No se ha configurado una cuenta de correo para envio de información en el Menú de Configuración\Compañia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return "No se ha configurado una cuenta de correo para envio de información en el Menú de Configuración\Compañia"
        End If

        'Verifica que exista el path
        If TipoCF <= 2 Then
            Try
                If Not System.IO.Directory.Exists(PathXML) Then
                    If ShowMsg = True Then
                        MessageBox.Show("El directorio " & PathXML & " para guardar los XML no existe o no se puede tener acceso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                    Return "El directorio " & PathXML & " para guardar los XML no existe o no se puede tener acceso"
                End If
            Catch ex As Exception
            End Try
        End If

        Dim frmStatusMessage As New frmStatus


        PathPDF = pathActual & "Temp\" & Folio & ".PDF"

        'Genera PDF

        Dim OpenReport As New Report
        Dim pvtaDataSet As New DataSet
        pvtaDataSet.DataSetName = "pvtaDataSet"

        Dim Logo As Integer = 1
        Dim dtLogo As DataTable = ModPOS.Recupera_Tabla("st_recupera_logo_fac", "@FACClave", FACClave)
        Logo = dtLogo.Rows(0)("Logo")
        dtLogo.Dispose()

        Select Case sFormato


            Case Is = "Global"
                If VersionCF = "3.3" Then
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_relacionado", "@DOCClave", FACClave, "@Tipo", "F"))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_encabezado_fac", "@FACClave", FACClave, "@Logo", Logo))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_recupera_impdet_global", "@FACClave", FACClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_fac", "@FACClave", FACClave))

                    OpenReport.PrintPDF("CRGlobalCFDI.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal(Total / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper, PathPDF)

                Else
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_logo_compania", "@COMClave", ModPOS.CompanyActual))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_encabezado_fac", "@FACClave", FACClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_detalle_fac", "@FACClave", FACClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_fac", "@FACClave", FACClave))

                    OpenReport.PrintPDF("CRGlobal.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal(Total / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper, PathPDF)
                End If
            Case Is = "Clasico"

                If VersionCF = "3.3" Then
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_relacionado", "@DOCClave", FACClave, "@Tipo", "F"))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_encabezado_fac", "@FACClave", FACClave, "@Logo", Logo))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_detalle_fac33", "@FACClave", FACClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_impuestos_fac", "@FACClave", FACClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_fac", "@FACClave", FACClave))

                    OpenReport.PrintPDF("CRIngresoCFDI33.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal(Total / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper, PathPDF)


                Else
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_recupera_publicidad", "@SUCClave", SUCClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_logo_compania", "@COMClave", ModPOS.CompanyActual))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_encabezado_fac", "@FACClave", FACClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_detalle_fac", "@FACClave", FACClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_impuestos_fac", "@FACClave", FACClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_fac", "@FACClave", FACClave))


                    Select Case TipoCF
                        Case Is = 1
                            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_metodopago_fac", "@FACClave", FACClave))
                            OpenReport.PrintPDF("CRIngresoCFD.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal(Total / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper, PathPDF)
                        Case Is = 2
                            OpenReport.PrintPDF("CRIngresoCFDI.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal(Total / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper, PathPDF)
                        Case Is = 3
                            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_metodopago_fac", "@FACClave", FACClave))
                            OpenReport.PrintPDF("CRIngresoCBB.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal(Total / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper, PathPDF)

                    End Select
                End If
            Case Is = "Con Notas"
                pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_recupera_publicidad", "@SUCClave", SUCClave))
                pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_logo_compania", "@COMClave", ModPOS.CompanyActual))
                pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_encabezado_fac", "@FACClave", FACClave))
                pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_detalle_fac", "@FACClave", FACClave))
                pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_impuestos_fac", "@FACClave", FACClave))
                pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_fac", "@FACClave", FACClave))

                Select Case TipoCF
                    Case Is = 1
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_metodopago_fac", "@FACClave", FACClave))

                        OpenReport.PrintPDF("CRIngresoNCFD.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal(Total / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper, PathPDF)
                    Case Is = 2
                        OpenReport.PrintPDF("CRIngresoNCFDI.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal(Total / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper, PathPDF)
                    Case Is = 3
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_metodopago_fac", "@FACClave", FACClave))

                        OpenReport.PrintPDF("CRIngresoCBB.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal(Total / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper, PathPDF)

                End Select
            Case Is = "Pagare"
                If VersionCF = "3.3" Then
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_relacionado", "@DOCClave", FACClave, "@Tipo", "F"))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_encabezado_fac_radec", "@FACClave", FACClave, "@Logo", logo))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_detalle_fac_radec33", "@FACClave", FACClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_venta_fac_radec", "@FACClave", FACClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_fac", "@FACClave", FACClave))

                    OpenReport.PrintPDF("CFDIPagare33.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal(Total / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper, PathPDF)

                Else
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_encabezado_fac_radec", "@FACClave", FACClave, "@Logo", logo))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_detalle_fac_radec", "@FACClave", FACClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_venta_fac_radec", "@FACClave", FACClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_fac", "@FACClave", FACClave))

                    OpenReport.PrintPDF("CFDIPagare.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal(Total / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper, PathPDF)
                End If

            Case Is = "Pagare2"
                If VersionCF = "3.3" Then
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_relacionado", "@DOCClave", FACClave, "@Tipo", "F"))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_encabezado_fac_radec", "@FACClave", FACClave, "@Logo", Logo))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_detalle_fac_radec33", "@FACClave", FACClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_venta_fac_radec", "@FACClave", FACClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_fac", "@FACClave", FACClave))

                    OpenReport.PrintPDF("CFDIPagare2.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal(Total / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper, PathPDF)
                End If
            Case Is = "Radec"
                If VersionCF = "3.3" Then
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_relacionado", "@DOCClave", FACClave, "@Tipo", "F"))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_encabezado_fac_radec", "@FACClave", FACClave, "@Logo", Logo))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_detalle_fac_radec", "@FACClave", FACClave, "@Tipo", 1))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_venta_fac_radec", "@FACClave", FACClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_fac", "@FACClave", FACClave))

                    OpenReport.PrintPDF("CFDFactura33.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal(Total / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper, PathPDF)

                Else
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_encabezado_fac_radec", "@FACClave", FACClave, "@Logo", Logo))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_detalle_fac_radec", "@FACClave", FACClave, "@Tipo", 1))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_venta_fac_radec", "@FACClave", FACClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_fac", "@FACClave", FACClave))

                    OpenReport.PrintPDF("CFDFactura.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal(Total / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper, PathPDF)
                End If
            Case Is = "AutoZone"
                If VersionCF = "3.3" Then
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_relacionado", "@DOCClave", FACClave, "@Tipo", "F"))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_encabezado_fac_radec", "@FACClave", FACClave, "@Logo", Logo))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_detalle_fac_radec", "@FACClave", FACClave, "@Tipo", 2))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_venta_fac_radec", "@FACClave", FACClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_fac", "@FACClave", FACClave))

                    OpenReport.PrintPDF("CFDFactura33.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal(Total / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper, PathPDF)
                End If

            Case Is = "LaLa"
                If VersionCF = "3.3" Then
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_relacionado", "@DOCClave", FACClave, "@Tipo", "F"))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_encabezado_fac_radec", "@FACClave", FACClave, "@Logo", Logo))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_detalle_fac_radec", "@FACClave", FACClave, "@Tipo", 3))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_venta_fac_radec", "@FACClave", FACClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_fac", "@FACClave", FACClave))

                    OpenReport.PrintPDF("CFDFacturaLaLa33.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal(Total / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper, PathPDF)

                Else
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_encabezado_fac_radec", "@FACClave", FACClave, "@Logo", Logo))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_detalle_fac_radec", "@FACClave", FACClave, "@Tipo", 3))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_venta_fac_radec", "@FACClave", FACClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_fac", "@FACClave", FACClave))

                    OpenReport.PrintPDF("CFDFacturaLaLa.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal(Total / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper, PathPDF)
                End If
            Case Is = "Aseguradora"
                If VersionCF = "3.3" Then
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_relacionado", "@DOCClave", FACClave, "@Tipo", "F"))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_encabezado_fac_radec", "@FACClave", FACClave, "@Logo", Logo))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_detalle_fac_radec", "@FACClave", FACClave, "@Tipo", 4))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_venta_fac_radec", "@FACClave", FACClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_fac", "@FACClave", FACClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_complemento_fac_radec", "@FACClave", FACClave))

                    OpenReport.PrintPDF("CFDFacturaAseg33.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal(Total / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper, PathPDF)

                Else
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_encabezado_fac_radec", "@FACClave", FACClave, "@Logo", Logo))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_detalle_fac_radec", "@FACClave", FACClave, "@Tipo", 4))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_venta_fac_radec", "@FACClave", FACClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_fac", "@FACClave", FACClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_complemento_fac_radec", "@FACClave", FACClave))

                    OpenReport.PrintPDF("CFDFacturaAseg.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal(Total / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper, PathPDF)
                End If

            Case Is = "Daimler"
                If VersionCF = "3.3" Then
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_relacionado", "@DOCClave", FACClave, "@Tipo", "F"))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_encabezado_fac_radec", "@FACClave", FACClave, "@Logo", Logo))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_detalle_fac_radec", "@FACClave", FACClave, "@Tipo", 5))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_venta_fac_radec", "@FACClave", FACClave))
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_sello_fac", "@FACClave", FACClave))

                    OpenReport.PrintPDF("CFDFactura33.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal(Total / TipoCambio, 2), MonedaDesc, MonedaRef).ToUpper, PathPDF)
                End If

        End Select

        If Not System.IO.File.Exists(PathPDF) Then
            If ShowMsg = True Then
                MessageBox.Show("Ha ocurrido un error al generar el archivo: " & PathPDF, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return "Ha ocurrido un error al generar el archivo: " & PathPDF

        End If

        'Envia Correo

        sPathXML = PathXML
        If sPathXML.Length > 3 AndAlso sPathXML.Substring(sPathXML.Length - 1, 1) <> "\" Then
            sPathXML &= "\"
        End If

        sPathXML &= Fecha.Year.ToString & "\" & Fecha.Month.ToString & "\" & Fecha.Day.ToString & "\" & Folio & ".xml"


        If TipoCF <= 2 AndAlso Not System.IO.File.Exists(sPathXML) Then
            If ShowMsg = True Then
                MessageBox.Show("Ha ocurrido un error, No se ha encontrado el archivo: " & sPathXML, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return "Ha ocurrido un error, No se ha encontrado el archivo: " & sPathXML
        Else
            Try
                correo = New System.Net.Mail.MailMessage
                autenticar = New System.Net.NetworkCredential
                envio = New System.Net.Mail.SmtpClient


                correo.Body = "Estimado Cliente, le hacemos llegar por este medio la Representación Impresa de su Factura (*.PDF) y el Comprobante Fiscal Digital (*.XML), Agradecemos su Preferencia y Esperamos Verlo Pronto. Saludos."
                correo.Subject = "Factura " & Folio
                correo.IsBodyHtml = True
                correo.To.Clear()
                correo.CC.Clear()
                correo.Bcc.Clear()


                If sMailCliente.Split(",").Length >= 1 Then
                    Dim j As Integer
                    For j = 0 To sMailCliente.Split(",").Length - 1
                        If sMailCliente.Split(",")(j) <> "" Then
                            correo.To.Add(sMailCliente.Split(",")(j))
                        End If
                    Next
                Else
                    correo.To.Add(sMailCliente)
                End If


                correo.From = New System.Net.Mail.MailAddress(MailAdress, DisplayName)
                envio.Credentials = New System.Net.NetworkCredential(MailUser, MailPassword)
                envio.Host = HostSMTP  '"smtp.live.com"
                envio.Port = MailPort  '587
                envio.EnableSsl = MailSSL 'True

                frmStatusMessage.Show("Enviando correo electrónico...")

                If TipoCF <= 2 Then
                    dato = New System.IO.FileStream(sPathXML, System.IO.FileMode.Open, System.IO.FileAccess.Read)
                    adjuntos = New System.Net.Mail.Attachment(dato, Folio & ".XML")
                    correo.Attachments.Add(adjuntos)
                End If

                dato = New System.IO.FileStream(PathPDF, System.IO.FileMode.Open, System.IO.FileAccess.Read)
                adjuntos = New System.Net.Mail.Attachment(dato, Folio & ".PDF")
                correo.Attachments.Add(adjuntos)

                envio.Send(correo)
                correo.Dispose()

                If ShowMsg = True Then
                    MessageBox.Show("El mensaje fue enviado correctamente a el destinatario", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    frmStatusMessage.Show("El mensaje fue enviado correctamente a el destinatario")
                End If

                frmStatusMessage.Dispose()
            Catch ex As Exception
                frmStatusMessage.Dispose()
                If ShowMsg = True Then
                    MessageBox.Show(ex.Message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

                Return ex.Message

            End Try

            If Not dato Is Nothing Then
                dato.Close()
            End If

            Try
                My.Computer.FileSystem.DeleteFile(PathPDF, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
            Catch ex As Exception

                If ShowMsg = True Then
                    MessageBox.Show(ex.Message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

                Return ex.Message

            End Try
        End If

        Return ""
    End Function

    Public Sub TimbraEgreso(ByVal ANTClave As String, ByVal DOCClave As String, ByVal TipoDocumento As Integer, ByVal PathXML As String, ByVal VersionCF As String, ByVal dtPAC As DataTable, ByVal RegimenFiscal As String, ByVal InterfazSalida As String, Optional ByVal bShowError As Boolean = True, Optional bImprimir As Boolean = False, Optional ByVal sImpresora As String = "", Optional ByVal iCopias As Integer = 0)

        Dim oCFD As New CFD
        Dim dt As DataTable

        oCFD.UUID_Sustituido = ""

        If TipoDocumento = 6 Then
            dt = ModPOS.Recupera_Tabla("sp_sello_cargo", "@CARClave", DOCClave)

        Else
            dt = ModPOS.Recupera_Tabla("sp_sello_fac", "@FACClave", DOCClave)

        End If
        


        If dt.Rows.Count = 1 Then
            oCFD.UUID_Sustituido = IIf(dt.Rows(0)("UUID_Anterior").GetType.Name = "DBNull", "", dt.Rows(0)("UUID_Anterior"))
            If oCFD.UUID_Sustituido = "" Then
                oCFD.UUID_Sustituido = IIf(dt.Rows(0)("UUID").GetType.Name = "DBNull", "", dt.Rows(0)("UUID"))
            End If
        End If

        'inserta Aplicacion de anticipo

        If oCFD.UUID_Sustituido <> "" Then


            dt = ModPOS.Recupera_Tabla("sp_recupera_certificadovigente", "@COMClave", ModPOS.CompanyActual)
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                oCFD.noCertificado = dt.Rows(0)("Serie")
                oCFD.Certificado64 = dt.Rows(0)("Certificado")
                oCFD.LlaveFile = dt.Rows(0)("Llave")
                oCFD.ContrasenaClave = dt.Rows(0)("Password")
                dt.Dispose()
            Else
                If bShowError = True Then
                    MessageBox.Show("No existen certificado vigente disponible para emitir algun documento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                Exit Sub
            End If

            'Verifica que exista el path
            Try
                If Not System.IO.Directory.Exists(PathXML) Then
                    If bShowError = True Then
                        MessageBox.Show("El directorio " & PathXML & " para guardar los XML no existe o no se puede tener acceso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                    Exit Sub
                End If
            Catch ex As Exception
            End Try

            'Verifica que exista el path del .Key
            Try
                If Not System.IO.File.Exists(oCFD.LlaveFile) Then
                    If bShowError = True Then
                        MessageBox.Show("El archivo " & oCFD.LlaveFile & " no existe o se puede tener acceso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                        Exit Sub
                    End If
                End If
            Catch ex As Exception
            End Try


            oCFD.VersionCF = VersionCF
            oCFD.TipoCF = 2
            oCFD.regimenFiscal = RegimenFiscal

            'Recupera información del Emisor

            dt = ModPOS.Recupera_Tabla("sp_recupera_compania", "@COMClave", ModPOS.CompanyActual)
            oCFD.eRazonSocial = dt.Rows(0)("Nombre")
            oCFD.eRFC = dt.Rows(0)("id_Fiscal")
            dt.Dispose()




            dt = ModPOS.Recupera_Tabla("st_encabezado_apl", "@ANTClave", ANTClave)


            Dim iTipoPAC As Integer

            If dt.Rows.Count = 1 Then
                oCFD.DOCClave = ANTClave
                oCFD.Folio = dt.Rows(0)("Clave")
                oCFD.Fecha = String.Format("{0:yyyy-MM-ddTHH:mm:ss}", dt.Rows(0)("Fecha"))
                oCFD.sCodigoPostal = dt.Rows(0)("sCodigoPostal")
                oCFD.RFC = dt.Rows(0)("rRFC")
                oCFD.RazonSocial = dt.Rows(0)("rRazonSocial")
                oCFD.Nacionalidad = dt.Rows(0)("Origen")
                oCFD.NumRegIdTrib = dt.Rows(0)("NumRegIdTrib")
                oCFD.metodoDePago = dt.Rows(0)("MetodoDePago")
                oCFD.Moneda = dt.Rows(0)("Moneda")
                oCFD.TipoCambio = dt.Rows(0)("TipoCambio")

                oCFD.total = dt.Rows(0)("Importe")


                oCFD.cadenaOriginal = generarCadenaOriginalPago(oCFD, dt.Rows(0)("Tipo"), "E")


                oCFD.sello = ModPOS.generarSelloDigital(oCFD.cadenaOriginal, "", oCFD.Folio, oCFD.LlaveFile, oCFD.ContrasenaClave, oCFD.VersionCF)


                iTipoPAC = crearXMLPago(1, dtPAC, PathXML, oCFD.Folio, oCFD.DOCClave, dt.Rows(0)("Tipo"), "E", DOCClave, oCFD, InterfazSalida, bShowError)


                If bImprimir = True Then
                    imprimirCfdiPago(oCFD.DOCClave, "Aplicación", iCopias, sImpresora)
                End If


            End If
            dt.Dispose()
        Else
            If bShowError = True Then
                MessageBox.Show("El documento relacionado no se encuentra Activo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If

    End Sub

    Private Sub AplicaAnticipo(ByVal ABNClave As String, ByVal DOCClave As String, ByVal TipoDocumento As Integer, ByVal ImporteAplicado As Decimal, ByVal CAJClave As String)

        Dim bTimbrarAnticipo As Boolean = False
        'recuepra los 
        Dim dt As DataTable = ModPOS.Recupera_Tabla("st_sello_pago", "@ABNClave", ABNClave)
        If dt.Rows.Count = 0 Then
            bTimbrarAnticipo = True
        Else
            If IIf(dt.Rows(0)("estado").GetType.Name = "DBNull", 2, dt.Rows(0)("estado")) = 2 Then
                bTimbrarAnticipo = True
            End If
        End If
        dt.Dispose()

        If bTimbrarAnticipo = True Then

            Dim i As Integer
            Dim oCFD As New CFD
            Dim dtmsg, dtPAC As DataTable
            Dim PathXML, InterfazSalida, regimenFiscal, VersionCF As String

            dtPAC = ModPOS.Recupera_Tabla("sp_recupera_PAC", "@COMClave", ModPOS.CompanyActual)

            dt = ModPOS.Recupera_Tabla("sp_recupera_parametro", "@COMClave", ModPOS.CompanyActual)
            For i = 0 To dt.Rows.Count - 1
                Select Case CStr(dt.Rows(i)("PARClave"))
                    Case "DirXML"
                        PathXML = dt.Rows(i)("Valor")
                    Case "VersionCF"
                        dtmsg = Recupera_Tabla("sp_recupera_valorref", "@Tabla", "CFD", "@Campo", "Version", "@estado", CInt(dt.Rows(i)("Valor")))
                        VersionCF = dtmsg.Rows(0)("Descripcion")
                        dtmsg.Dispose()
                    Case "RegimenFiscal"
                        dtmsg = Recupera_Tabla("sp_recupera_valor", "@Tabla", "CFD", "@Campo", "RegimenFiscal", "@Valor", CInt(dt.Rows(i)("Valor")))
                        regimenFiscal = dtmsg.Rows(0)("ClaveSAT")
                        dtmsg.Dispose()
                    Case "InterfazSalida"
                        InterfazSalida = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", "", dt.Rows(i)("Valor"))
                End Select
            Next
            dt.Dispose()

            dt = ModPOS.Recupera_Tabla("sp_recupera_certificadovigente", "@COMClave", ModPOS.CompanyActual)
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                oCFD.noCertificado = dt.Rows(0)("Serie")
                oCFD.Certificado64 = dt.Rows(0)("Certificado")
                oCFD.LlaveFile = dt.Rows(0)("Llave")
                oCFD.ContrasenaClave = dt.Rows(0)("Password")
                dt.Dispose()
            End If


            oCFD.VersionCF = VersionCF
            oCFD.TipoCF = 2
            oCFD.regimenFiscal = regimenFiscal

            'Recupera información del Emisor

            dt = ModPOS.Recupera_Tabla("sp_recupera_compania", "@COMClave", ModPOS.CompanyActual)
            oCFD.eRazonSocial = dt.Rows(0)("Nombre")
            oCFD.eRFC = dt.Rows(0)("id_Fiscal")
            dt.Dispose()


            dt = ModPOS.Recupera_Tabla("st_encabezado_abono", "@ABNClave", ABNClave)


            Dim sTipoComprobante As String

            If dt.Rows.Count = 1 Then

                oCFD.DOCClave = dt.Rows(0)("ABNClave")
                oCFD.Folio = dt.Rows(0)("Clave")

                sTipoComprobante = "I"

                Dim dFecha As DateTime

                If DateDiff(DateInterval.Hour, CDate(dt.Rows(0)("MFechaHora")), DateTime.Now) > 72 Then
                    dFecha = DateTime.Now

                Else
                    dFecha = dt.Rows(0)("MFechaHora")
                End If

                oCFD.Fecha = String.Format("{0:yyyy-MM-ddTHH:mm:ss}", dFecha)

                ModPOS.Ejecuta("st_act_abn_fechasat", "@ABNClave", dt.Rows(0)("ABNClave"), "@Fecha", dFecha)


                oCFD.sCodigoPostal = dt.Rows(0)("sCodigoPostal")
                oCFD.RFC = dt.Rows(0)("rRFC")
                oCFD.RazonSocial = dt.Rows(0)("rRazonSocial")
                oCFD.Nacionalidad = dt.Rows(0)("Origen")
                oCFD.NumRegIdTrib = dt.Rows(0)("NumRegIdTrib")
                oCFD.metodoDePago = dt.Rows(0)("MetodoDePago")
                oCFD.Moneda = dt.Rows(0)("Moneda")
                oCFD.TipoCambio = dt.Rows(0)("TipoCambio")

                oCFD.total = dt.Rows(0)("Importe")



                oCFD.cadenaOriginal = generarCadenaOriginalPago(oCFD, dt.Rows(0)("Tipo"), sTipoComprobante)


                oCFD.sello = ModPOS.generarSelloDigital(oCFD.cadenaOriginal, "", oCFD.Folio, oCFD.LlaveFile, oCFD.ContrasenaClave, oCFD.VersionCF)


                crearXMLPago(1, dtPAC, PathXML, oCFD.Folio, oCFD.DOCClave, dt.Rows(0)("Tipo"), sTipoComprobante, "", oCFD, InterfazSalida, False)

            End If
        End If

        Dim Folio, Periodo, Mes As Integer
        Dim dtFolio As DataTable
        dtFolio = ModPOS.SiExisteRecupera("sp_recupera_folio", "@Tipo", 9, "@PDVClave", CAJClave)
        If dtFolio Is Nothing Then
            ModPOS.Ejecuta("sp_crea_folio", "@Tipo", 9, "@PDVClave", CAJClave)
            Folio = 1
            Periodo = Today.Year
            Mes = Today.Month
        Else
            Folio = CInt(dtFolio.Rows(0)("UltimoConsecutivo")) + 1
            Periodo = dtFolio.Rows(0)("Periodo")
            Mes = dtFolio.Rows(0)("Mes")
            ModPOS.Ejecuta("sp_act_folio", "@Tipo", 9, "@PDVClave", CAJClave, "@Incremento", 1)
            dtFolio.Dispose()
        End If

        dt = ModPOS.Recupera_Tabla("sp_recupera_caja", "@Caja", CAJClave)
        Dim ClaveCaja As String = dt.Rows(0)("Clave")
        dt.Dispose()

        Dim FolioEgreso As String = "EA" & ClaveCaja & "-" & CStr(Folio) & "-" & CStr(Periodo) & CStr(Mes)


        Dim ANTClave As String = ModPOS.obtenerLlave
        ModPOS.Ejecuta("st_inserta_apl_anticipo", "@ANTClave", ANTClave, "@Folio", FolioEgreso, "@ABNClave", ABNClave, "@DOCClave", DOCClave, "@TipoDocumento", TipoDocumento, "@Importe", ImporteAplicado, "@Usuario", ModPOS.UsuarioActual)
    End Sub


    Public Sub Aplica_Pagos(ByRef dtDoctos As DataTable, ByVal CTEClave As String, ByVal AbonoClave As String, ByVal TPago As Integer, ByRef TotalAbono As Decimal, ByVal CAJClave As String, ByVal TipoPago As Integer)
        Dim i As Integer
        Dim dts As DataTable
        Dim AcumulaPuntos As Integer
        dts = ModPOS.Recupera_Tabla("sp_recupera_cte_mostrador", "@Cliente", CTEClave)
        If dts.Rows(0)("POS") = 0 Then
            AcumulaPuntos = 1
        Else
            AcumulaPuntos = 0
        End If

        dts.Dispose()

        Dim dSaldoVenta As Decimal


        If dtDoctos.Rows.Count = 1 Then
            If dtDoctos.Rows(0)("Saldo") > 0 Then

                dSaldoVenta = CDec(dtDoctos.Rows(0)("Saldo"))

                Select Case TotalAbono
                    Case Is >= Math.Round(dSaldoVenta, 2)

                        ModPOS.Ejecuta("sp_paga_documento", _
                                       "@CAJClave", CAJClave, _
                                                      "@ABNClave", AbonoClave, _
                                                      "@TipoDoc", dtDoctos.Rows(0)("TipoDocumento"), _
                                                      "@Documento", dtDoctos.Rows(0)("ID"), _
                                                      "@Pago", dSaldoVenta, _
                                                      "@AcumulaPuntos", AcumulaPuntos, _
                                                      "@Tipo", TPago, _
                                                      "@Usuario", ModPOS.UsuarioActual)

                        TotalAbono -= dtDoctos.Rows(0)("Saldo")
                        dtDoctos.Rows(0)("Saldo") = 0

                        If TipoPago = 2 AndAlso (dtDoctos.Rows(0)("TipoDocumento") = 2 OrElse dtDoctos.Rows(0)("TipoDocumento") = 6) Then
                            'Aplica Anticipo
                            AplicaAnticipo(AbonoClave, dtDoctos.Rows(0)("ID"), dtDoctos.Rows(0)("TipoDocumento"), dSaldoVenta, CAJClave)
                        End If


                    Case Is < dSaldoVenta

                        ModPOS.Ejecuta("sp_actualiza_saldo", _
                                        "@CAJClave", CAJClave, _
                                       "@ABNClave", AbonoClave, _
                                       "@Pago", TotalAbono, _
                                       "@TipoDoc", dtDoctos.Rows(0)("TipoDocumento"), _
                                       "@Documento", dtDoctos.Rows(0)("ID"), _
                                       "@Tipo", TPago, _
                                       "@SaldoRemanente", Math.Round(CDec(dtDoctos.Rows(0)("Saldo")) - TotalAbono, 2), _
                                       "@Usuario", ModPOS.UsuarioActual)

                        dtDoctos.Rows(0)("Saldo") -= TotalAbono

                        If TipoPago = 2 AndAlso (dtDoctos.Rows(0)("TipoDocumento") = 2 OrElse dtDoctos.Rows(0)("TipoDocumento") = 6) Then
                            'Aplica Anticipo
                            AplicaAnticipo(AbonoClave, dtDoctos.Rows(0)("ID"), dtDoctos.Rows(0)("TipoDocumento"), TotalAbono, CAJClave)
                        End If

                        TotalAbono = 0



                End Select
            End If

         

        Else
            Dim SaldoDisponible As Decimal = TotalAbono

            For i = 0 To dtDoctos.Rows.Count - 1
                If dtDoctos.Rows(i)("Saldo") > 0 Then
                    Select Case SaldoDisponible
                        Case Is >= Math.Round(CDec(dtDoctos.Rows(i)("Saldo")), 2)
                            ModPOS.Ejecuta("sp_paga_documento", _
                                           "@CAJClave", CAJClave, _
                                                          "@ABNClave", AbonoClave, _
                                                          "@TipoDoc", dtDoctos.Rows(i)("TipoDocumento"), _
                                                          "@Documento", dtDoctos.Rows(i)("ID"), _
                                                          "@Pago", dtDoctos.Rows(i)("Saldo"), _
                                                          "@AcumulaPuntos", AcumulaPuntos, _
                                                          "@Tipo", TPago, _
                                                          "@Usuario", ModPOS.UsuarioActual)

                            SaldoDisponible -= dtDoctos.Rows(i)("Saldo")

                            If TipoPago = 2 AndAlso (dtDoctos.Rows(0)("TipoDocumento") = 2 OrElse dtDoctos.Rows(0)("TipoDocumento") = 6) Then
                                'Aplica Anticipo
                                AplicaAnticipo(AbonoClave, dtDoctos.Rows(0)("ID"), dtDoctos.Rows(0)("TipoDocumento"), dtDoctos.Rows(i)("Saldo"), CAJClave)
                            End If
                            dtDoctos.Rows(i)("Saldo") = 0

                        Case Is < CDec(dtDoctos.Rows(i)("Saldo"))
                            ModPOS.Ejecuta("sp_actualiza_saldo", _
                                            "@CAJClave", CAJClave, _
                                           "@ABNClave", AbonoClave, _
                                           "@Pago", SaldoDisponible, _
                                           "@TipoDoc", dtDoctos.Rows(i)("TipoDocumento"), _
                                           "@Documento", dtDoctos.Rows(i)("ID"), _
                                           "@Tipo", TPago, _
                                           "@SaldoRemanente", Math.Round(dtDoctos.Rows(i)("Saldo") - SaldoDisponible, 2), _
                                           "@Usuario", ModPOS.UsuarioActual)


                            dtDoctos.Rows(i)("Saldo") -= SaldoDisponible

                            If TipoPago = 2 AndAlso (dtDoctos.Rows(0)("TipoDocumento") = 2 OrElse dtDoctos.Rows(0)("TipoDocumento") = 6) Then
                                'Aplica Anticipo
                                AplicaAnticipo(AbonoClave, dtDoctos.Rows(0)("ID"), dtDoctos.Rows(0)("TipoDocumento"), SaldoDisponible, CAJClave)
                            End If

                            SaldoDisponible -= SaldoDisponible


                    End Select




                    If SaldoDisponible <= 0 Then


                        Exit For
                    End If
                End If




            Next

            TotalAbono = SaldoDisponible



        End If


    End Sub

    Public Function validaFolio(ByVal SUCClave As String, ByVal CAJClave As String, ByVal TipoComprobante As Integer, ByVal NumFolios As Integer) As Boolean
        Dim dt As DataTable = ModPOS.Recupera_Tabla("sp_recupera_folioactual", "@TipoComprobante", TipoComprobante, "@SUCClave", SUCClave, "@CAJClave", CAJClave)
        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
            If dt.Compute("SUM(FolioFinal) - SUM(FolioActual)", "") >= NumFolios Then
                dt.Dispose()
                Return True
            Else
                MessageBox.Show("No existen suficientes folios disponibles para el tipo de comprobante seleccionado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dt.Dispose()
                Return False
            End If
        Else
            MessageBox.Show("No existen folios disponibles para el tipo de comprobante seleccionado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
    End Function


    Public Function recuperaFolio(ByVal SUCClave As String, ByVal CAJClave As String, ByVal TipoComprobante As Integer, ByRef oCFD As CFD) As Integer
        Dim dt As DataTable = ModPOS.Recupera_Tabla("sp_recupera_folioactual", "@TipoComprobante", TipoComprobante, "@SUCClave", SUCClave, "@CAJClave", CAJClave)

        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
            If dt.Compute("SUM(FolioFinal) - SUM(FolioActual)", "") >= 1 Then
                'If dt.Rows(0)("FolioActual") + NumFolios <= dt.Rows(0)("FolioFinal") Then
                oCFD.FOLClave = dt.Rows(0)("FOLClave")
                oCFD.noAprobacion = dt.Rows(0)("NoAprobacion")
                oCFD.anoAprobacion = CStr(dt.Rows(0)("AnoAprobacion"))
                oCFD.Serie = dt.Rows(0)("Serie")
                oCFD.Folio = CStr(dt.Rows(0)("FolioActual") + 1)
                oCFD.fechaAprobacion = IIf(dt.Rows(0)("fechaAprobacion").GetType.Name = "DBNull", Today(), dt.Rows(0)("fechaAprobacion"))

                If Not dt.Rows(0)("CBB") Is System.DBNull.Value Then
                    oCFD.CBB = CType(dt.Rows(0)("CBB"), Byte())
                End If

                dt.Dispose()

                ModPOS.Ejecuta("sp_incrementa_folio", "@FOLClave", oCFD.FOLClave)

                Return oCFD.Folio
            Else
                Return 0
            End If
        Else
            Return 0
        End If
    End Function



    Public Sub NuevoMostrador(ByVal dt As DataTable, ByVal i As Integer, Optional ByVal dtVenta As DataTable = Nothing)


        Dim j As Integer = 0
        For j = 0 To Mostradores.Length - 1
            If Mostradores(j) Is Nothing Then
                Exit For
            End If
        Next

        If Not Mostradores(Mostradores.Length - 1) Is Nothing AndAlso j = Mostradores.Length Then
            ReDim Preserve Mostradores(Mostradores.Length)
        End If

        ModPOS.Mostradores(j) = New FrmTPDV
        ModPOS.numMostrador_Open += 1
        With ModPOS.Mostradores(j)

            .numMostrador = j
            .ALMClave = dt.Rows(0)("ALMClave")
            .AlmacenClave = dt.Rows(0)("Clave")
            .AlmacenNombre = dt.Rows(0)("Nombre")
            .PDVClave = dt.Rows(0)("PDVClave")
            .PuntodeVenta = dt.Rows(0)("Descripcion")
            .Referencia = dt.Rows(0)("Referencia")
            .Impresora = dt.Rows(0)("Impresora")
            .Ticket = dt.Rows(0)("Ticket")
            .Supervisor = dt.Rows(0)("Supervisor")
            .Caja = dt.Rows(0)("Caja")

            .CreditoGeneral = IIf(dt.Rows(0)("CreditoGeneral").GetType.Name = "DBNull", "", dt.Rows(0)("CreditoGeneral"))
            .CAJClave = dt.Rows(0)("CAJClave")
            .CTEClaveInicial = dt.Rows(0)("CTEClave")
            .CTENombreInicial = dt.Rows(0)("Cliente")
            .lblCteClave.Text = dt.Rows(0)("ClaveCte")
            .CambiaPrecio = dt.Rows(0)("CambiaPrecio")
            .ModificaPrecioServicio = dt.Rows(0)("ModPrecioServicio")
            .Redondeo = dt.Rows(0)("Redondeo")
            .Agotamiento = dt.Rows(0)("Agotamiento")
            .SolicitaVendedor = dt.Rows(0)("SolicitaVendedor")
            .Url_Redondeo = dt.Rows(0)("ImgRedondeo")
            .LblFolio.Text = .Referencia & "- 0"
            .PrintGeneric = dt.Rows(0)("Generic")
            .sFrase = dt.Rows(0)("Frase")
            .ActivaDevolucion = dt.Rows(0)("Devolucion")
            .CreditoGeneral = IIf(dt.Rows(0)("CreditoGeneral").GetType.Name = "DBNull", "", dt.Rows(0)("CreditoGeneral"))
            .NumCopias = IIf(dt.Rows(0)("NumTickets").GetType.Name = "DBNull", 0, dt.Rows(0)("NumTickets"))

            .ValidaInventario = IIf(dt.Rows(0)("ValidaInventario").GetType.Name = "DBNull", False, dt.Rows(0)("ValidaInventario"))
            .Display = IIf(dt.Rows(0)("PoleDisplay").GetType.Name = "DBNull", 0, Math.Abs(CInt(dt.Rows(0)("PoleDisplay"))))
            .Port = IIf(dt.Rows(0)("Puerto").GetType.Name = "DBNull", "COM5", dt.Rows(0)("Puerto"))
            .BaudRate = IIf(dt.Rows(0)("BaudRate").GetType.Name = "DBNull", 9600, dt.Rows(0)("BaudRate"))
            .NoLineas = IIf(dt.Rows(0)("NoLineas").GetType.Name = "DBNull", 2, dt.Rows(0)("NoLineas"))
            .MaxCaracteres = IIf(dt.Rows(0)("MaxCaracteres").GetType.Name = "DBNull", 20, dt.Rows(0)("MaxCaracteres"))
            .ActivarCotizacion = IIf(dt.Rows(0)("ActivarCotizacion").GetType.Name = "DBNull", 0, Math.Abs(CInt(dt.Rows(0)("ActivarCotizacion"))))

            If dt.Rows(0)("Remoto").GetType.Name = "DBNull" Then
                .Remoto = 0
            Else
                .Remoto = Math.Abs(CInt(dt.Rows(0)("Remoto")))
            End If

            .BloquearPrecio = IIf(dt.Rows(0)("BloquearPrecio").GetType.Name = "DBNull", 0, Math.Abs(CInt(dt.Rows(0)("BloquearPrecio"))))
            .ImprimirRemoto = IIf(dt.Rows(0)("ImprimirRemoto").GetType.Name = "DBNull", 0, Math.Abs(CInt(dt.Rows(0)("ImprimirRemoto"))))

            .SucursalSurtido = dt.Rows(0)("SUCClave")
            .TipoVenta = IIf(dt.Rows(0)("TipoVenta").GetType.Name = "DBNull", 0, dt.Rows(0)("TipoVenta"))

            .txtLimite.Text = dt.Rows(0)("LimiteCredito")
            .txtDias.Text = dt.Rows(0)("DiasCredito")
            .txtSaldo.Text = dt.Rows(0)("SaldoCliente")
            .Text = "Mostrador: " & .Referencia & " Ventana: " & j + 1

            dt.Dispose()


            If i = -1 Then

                .btnBuscaCte.Enabled = False
                .BtnCancelaProducto.Enabled = False
                .BtnCancelaTicket.Enabled = False
                .btnEnvio.Enabled = False
                .BtnCerrar.Enabled = False
                .TxtCantidad.Enabled = False
                .TxtProducto.Enabled = False
                .TxtCliente.Enabled = False

            Else
                'recupera ticket
                .VentaAbierta = True
                .VENClave = dtVenta.Rows(i)("VENClave")
                .sFolio = dtVenta.Rows(i)("Folio")
                .CTEClaveActual = dtVenta.Rows(i)("Cliente")
                .CTENombreActual = dtVenta.Rows(i)("RazonSocial")
                .AtiendeClave = dtVenta.Rows(i)("Cajero")
                .AtiendeNombre = dtVenta.Rows(i)("NombreUsuario")
                .SaldoVenta = dtVenta.Rows(i)("Saldo")
                .TotalVenta = dtVenta.Rows(i)("Total")
                .TipoDocumento = dtVenta.Rows(i)("Tipo")
                .EstadoDocumento = dtVenta.Rows(i)("Estado")
                .NoVtaOpen = dtVenta.Rows.Count
                .lblCteClave.Text = dtVenta.Rows(0)("Clave")
                .txtLimite.Text = dtVenta.Rows(i)("LimiteCredito")
                .txtDias.Text = dtVenta.Rows(i)("DiasCredito")
                .txtSaldo.Text = dtVenta.Rows(i)("SaldoCliente")
                .AlmacenOpen = IIf(dtVenta.Rows(0)("ALMClave").GetType.Name = "DBNull", .ALMClave, dtVenta.Rows(0)("ALMClave"))

                dtVenta.Dispose()
            End If


            '.Width = Screen.PrimaryScreen.Bounds.Width
            '.Height = Screen.PrimaryScreen.Bounds.Height
            '  .TopMost = True
            .Show()
        End With


    End Sub


    Public Function ValidaCredido(ByVal CTEClave As String, ByVal dLimiteCredito As Double, ByVal iDiasCredito As Integer, ByVal dValorPedido As Double) As Integer
        Dim dt, dtRiesgo As DataTable
        Dim iResult As Integer = -1

        dt = ModPOS.Recupera_Tabla("st_muestra_riesgo", "@CTEClave", CTEClave)
        If dt.Rows.Count > 0 Then

            If CBool(dt.Rows(0)("Bloqueado")) = True Then
                MessageBox.Show("El Crédito del cliente se encuentra Bloqueado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                iResult = 0
            ElseIf dt.Rows(0)("Riesgo").GetType.Name = "DBNull" Then
                iResult = 1
            Else

                dtRiesgo = ModPOS.Recupera_Tabla("st_recupera_riesgo", "@IdRiesgo", CStr(dt.Rows(0)("Riesgo")))
                If dtRiesgo.Rows.Count > 0 Then

                    'Valida Clase de riesgo 005
                    If CBool(dtRiesgo.Rows(0)("ValidaVerificacion")) = False AndAlso _
                        CDbl(dtRiesgo.Rows(0)("ValorPedido")) < 0 AndAlso _
                        CInt(dtRiesgo.Rows(0)("DiasAntiguedad")) <= 0 AndAlso _
                        CDbl(dtRiesgo.Rows(0)("PorcPedidoVencido")) < 0 AndAlso _
                        CBool(dtRiesgo.Rows(0)("ValidaLimite")) = False Then
                        MessageBox.Show("Validar pago con el área de crédito", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        iResult = 0
                    Else
                        iResult = 1
                    End If

                    ' Valida Verificacion
                    If CBool(dtRiesgo.Rows(0)("ValidaVerificacion")) = True Then
                        If CDate(dt.Rows(0)("Verificación")) < Today.Date Then
                            MessageBox.Show("La fecha de verificación (" & CDate(dt.Rows(0)("Verificación")).ToShortDateString & ") del crédito ha expirado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            iResult = 0
                        Else
                            iResult = 1
                        End If
                    End If

                    ' Valida Valor Pedido

                    If iResult <> 0 AndAlso CDbl(dtRiesgo.Rows(0)("ValorPedido")) >= 0 Then
                        If dValorPedido > CDbl(dtRiesgo.Rows(0)("ValorPedido")) Then
                            MessageBox.Show("El Importe del documento excede lo permitido (" & Format(CStr(dtRiesgo.Rows(0)("ValorPedido")), "Currency") & ") para el cliente actual", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            iResult = 0
                        Else
                            iResult = 1
                        End If
                    End If

                    ' Valida Dias Antiguedad
                    If iResult <> 0 AndAlso CInt(dtRiesgo.Rows(0)("DiasAntiguedad")) >= 0 Then
                        If CInt(dtRiesgo.Rows(0)("DiasAntiguedad")) > 0 Then
                            If CInt(dt.Rows(0)("Demora")) > CInt(dtRiesgo.Rows(0)("DiasAntiguedad")) Then
                                MessageBox.Show("El cliente ha excedido los dias de demora (" & CStr(dtRiesgo.Rows(0)("DiasAntiguedad")) & ") de pago permitidos para un documento", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                iResult = 0
                            Else
                                iResult = 1
                            End If
                        Else
                            MessageBox.Show("La clase de riesgo No cuenta con dias de crédito", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            iResult = 0
                        End If
                    End If

                    'Porc Pedido Vencido
                    If CInt(dt.Rows(0)("Demora")) > 0 AndAlso iResult <> 0 AndAlso CDbl(dtRiesgo.Rows(0)("PorcPedidoVencido")) >= 0 Then

                        Dim Comprometido, Vencido, Porc As Double
                        Comprometido = CDbl(dt.Rows(0)("TotalComprometido"))
                        Vencido = CDbl(dt.Rows(0)("TotalVencido"))

                        Porc = ((Comprometido - Vencido) / Comprometido) * 100

                        If Porc > CDbl(dtRiesgo.Rows(0)("PorcPedidoVencido")) Then
                            MessageBox.Show("El cliente ha excedido el porcentaje máximo (" & CStr(dtRiesgo.Rows(0)("PorcPedidoVencido")) & " %) de deuda vencida", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            iResult = 0
                        Else
                            iResult = 1
                        End If


                    End If

                    'Valida Limite
                    If iResult <> 0 AndAlso CBool(dtRiesgo.Rows(0)("ValidaLimite")) = True Then
                        Dim Comprometido As Double
                        Comprometido = CDbl(dt.Rows(0)("TotalComprometido")) + dValorPedido

                        Dim dtpendiente As DataTable
                        dtpendiente = Recupera_Tabla("st_pedidos_pendientes", "@CTEClave", CTEClave)
                        If dtpendiente.Rows.Count > 0 Then
                            Comprometido += dtpendiente.Rows(0)("Total")
                        End If
                        dtpendiente.Dispose()

                        If Comprometido > dLimiteCredito Then
                            MessageBox.Show("El importe del documento excede el Limite de Crédito Disponible (" & Format(CStr(dLimiteCredito), "Currency") & ") del Cliente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            iResult = 0
                        Else
                            iResult = 1
                        End If
                    End If

                    'Dias Credito
                    If iResult <> 0 Then
                       
                        If iDiasCredito <= 0 Then
                            MessageBox.Show("El Cliente actual no tiene Dias de Crédito definidos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            iResult = 0
                        Else
                            iResult = 1
                        End If
                    End If


                End If
                dtRiesgo.Dispose()
            End If
        End If
        dt.Dispose()

        Return iResult
    End Function

    Public Function obtenerDescuentoVolumen(ByVal CTEClave As String, ByVal iGrupoMaterial As Integer, ByVal iSector As Integer, ByVal VENClave As String, ByVal PROClave As String, ByVal Subtotal As Double) As DescVol
        'recupera Importe de Grupo de Material
        Dim dt As DataTable
        Dim dGrupo As Double = 0
        Dim dSector As Double = 0
        Dim DescVolumen As DescVol

        dt = Recupera_Tabla("st_venta_grupo", "@Grupo", iGrupoMaterial, "@VENClave", VENClave, "@PROClave", PROClave) 'Sector
        If dt.Rows.Count > 0 Then
            dGrupo = IIf(dt.Compute("SUM(Grupo)", "").GetType.FullName = "System.DBNull", 0, dt.Compute("SUM(Grupo)", ""))
        End If
        dt.Dispose()

        dGrupo += Subtotal

        dt = Recupera_Tabla("st_venta_sector", "@Sector", iSector, "@VENClave", VENClave, "@PROClave", PROClave) 'Sector
        If dt.Rows.Count > 0 Then
            dSector = IIf(dt.Compute("SUM(Sector)", "").GetType.FullName = "System.DBNull", 0, dt.Compute("SUM(Sector)", ""))
        End If
        dt.Dispose()

        dSector += Subtotal

        dt = Recupera_Tabla("st_obtener_desc_volumen", "@Sector", iSector, "@Grupo", iGrupoMaterial, "@TotalGrupo", dGrupo, "@TotalSector", dSector, "@CTEClave", CTEClave)
        If dt.Rows.Count = 1 Then
            DescVolumen.Descuento = IIf(dt.Rows(0)("DescuentoVolumen").GetType.FullName = "System.DBNull", 0, dt.Rows(0)("DescuentoVolumen"))
            DescVolumen.Tipo = IIf(dt.Rows(0)("Tipo").GetType.FullName = "System.DBNull", "", dt.Rows(0)("Tipo"))
        Else
            DescVolumen.Descuento = 0
            DescVolumen.Tipo = ""
        End If
        dt.Dispose()

        Return DescVolumen

    End Function


    Public Function imprimeTicketApertura(ByVal IDCorte As String, ByVal Impresora As String, ByVal Generic As Boolean, ByVal Ticket As String) As Boolean
        Dim dtObjetos As DataTable

        Dim Tickets As Imprimir = New Imprimir 'PrintTicket.Ticket()
        Tickets.Generic = Generic
        Dim dtTicket As DataTable
        dtTicket = ModPOS.SiExisteRecupera("sp_recupera_ticket", "@TIKClave", Ticket)

        If Not dtTicket Is Nothing Then
            Tickets.MaxCharLine = dtTicket.Rows(0)("MaxChar")
            Tickets.LetraSize = dtTicket.Rows(0)("FontSize")
            Tickets.LetraName = dtTicket.Rows(0)("FontName")
            dtTicket.Dispose()
        End If

        Dim sApertura As String = ""
        Dim dApertura As DateTime
        Dim sCaja As String = ""
        Dim dSaldoApertura As Double = 0.0
        Dim sCAJClave As String = ""


        dtObjetos = ModPOS.SiExisteRecupera("sp_recupera_corte", "@ID", IDCorte)

        If Not dtObjetos Is Nothing Then
            If dtObjetos.Rows.Count > 0 Then
                sCAJClave = dtObjetos.Rows(0)("CAJClave")
                sCaja = dtObjetos.Rows(0)("Clave")
                sApertura = dtObjetos.Rows(0)("Apertura")
                dApertura = dtObjetos.Rows(0)("FechaApertura")
                dSaldoApertura = dtObjetos.Rows(0)("SaldoApertura")
            End If
            dtObjetos.Dispose()
        End If

        'Encabezado
        Tickets.AddHeaderLine("APERTURA DE CAJA", Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Centrado)
        Tickets.AddHeaderLine("CAJA: " & sCaja, 0, Imprimir.Alinear.Izquierda)
        Tickets.AddHeaderLine("APERTURA: " & sApertura, 0, Imprimir.Alinear.Izquierda)
        Tickets.AddHeaderLine("F.APERTURA: " & dApertura.ToShortDateString & " " & dApertura.ToShortTimeString, 0, Imprimir.Alinear.Izquierda)
        Tickets.AddHeaderLine(" ", 0, Imprimir.Alinear.Izquierda)

        Dim dtDetalle As DataTable

        dtDetalle = ModPOS.SiExisteRecupera("sp_recupera_corteDet", "@Tipo", 1, "@ID", IDCorte)

        If Not dtDetalle Is Nothing Then
            If dtDetalle.Rows.Count > 0 Then
                Tickets.AddHeaderLine("*** DETALLE REGISTRADO ***", Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Centrado)
                Tickets.AddHeaderItem("CANT. ", "DENOMINACION", "IMPORTE", Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Derecha)
                Dim i As Integer
                For i = 0 To dtDetalle.Rows.Count - 1
                    Tickets.AddHeaderItem(CStr(IIf(dtDetalle.Rows(i)("Cantidad").GetType.Name = "DBNull", 1, dtDetalle.Rows(i)("Cantidad"))), CStr(IIf(dtDetalle.Rows(i)("Denominacion").GetType.Name = "DBNull", "Efectivo", dtDetalle.Rows(i)("Denominacion"))), Strings.Format(Redondear(dtDetalle.Rows(i)("Importe"), 2).ToString, "Currency"), Imprimir.FontEstilo.Regular, Imprimir.Alinear.Derecha)
                Next
            End If
            dtDetalle.Dispose()
        End If
        Tickets.AddHeaderItem("", "TOTAL", Strings.Format(Redondear(dSaldoApertura, 2).ToString, "Currency"), Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Derecha)
        Tickets.AddFooterLine("FIRMA DE RECIBIDO", Imprimir.FontEstilo.Regular, Imprimir.Alinear.Izquierda)
        Tickets.AddFooterLine("", Imprimir.FontEstilo.Regular, Imprimir.Alinear.Derecha)
        Tickets.AddFooterLine("", Imprimir.FontEstilo.Regular, Imprimir.Alinear.Derecha)
        Tickets.AddFooterLine("", Imprimir.FontEstilo.Regular, Imprimir.Alinear.Derecha)
        Tickets.AddFooterLine("-------------------------", Imprimir.FontEstilo.Regular, Imprimir.Alinear.Centrado)
        Tickets.AddFooterLine("FIRMA", Imprimir.FontEstilo.Regular, Imprimir.Alinear.Centrado)


        Tickets.PrintTicket(Impresora, 15, 0)


    End Function

    Public Sub ImprimirRecibo(ByVal sIdRecibo As String, ByVal sPrinter As String)
        Dim frmStatusMessage As New frmStatus
        frmStatusMessage.Show("Imprimiendo...")
        Dim OpenReport As New Report
        Dim pvtaDataSet As New DataSet
        pvtaDataSet.DataSetName = "reportDataSet"
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_encabezado_ra", "@IdRecibo", sIdRecibo))
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_detalle_ra", "@IdRecibo", sIdRecibo))
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_pie_ra", "@IdRecibo", sIdRecibo))
        OpenReport.Print(1, "CRReciboDetalle.rpt", pvtaDataSet, "", sPrinter)
        frmStatusMessage.Dispose()
    End Sub

    Public Sub ImprimirColocacion(ByVal sIdRecibo As String, ByVal sPrinter As String, ByVal Pantalla As Boolean)
        Dim frmStatusMessage As New frmStatus
        frmStatusMessage.Show("Imprimiendo...")

        Dim OpenReport As New Report
        Dim pvtaDataSet As New DataSet
        pvtaDataSet.DataSetName = "reportDataSet"
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_encabezado_ra", "@IdRecibo", sIdRecibo))
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_colocacion_ra", "@IdRecibo", sIdRecibo))
        pvtaDataSet.DataSetName = "pvtaDataSet"

        If Pantalla = True Then
            OpenReport.PrintPreview("Colocación", "CRColocacion.rpt", pvtaDataSet, "")
        Else
            OpenReport.Print(1, "CRColocacion.rpt", pvtaDataSet, "", sPrinter)
        End If

        frmStatusMessage.Dispose()
    End Sub


    Public Function ImprimirSurtido(ByVal iTipo As Integer, ByVal sDocumento As String, ByVal Reimpresion As Boolean, ByVal ShowError As Boolean) As String
        Dim sError As String = ""
        Dim stexto As String
        If Reimpresion = True Then
            stexto = "  REIMPRESIÓN"
        Else
            stexto = ""
        End If

        Dim frmStatusMessage As New frmStatus
        frmStatusMessage.Show("Imprimiendo...")
        'Recupera impresoras por area de surtido
        Dim dt As DataTable = ModPOS.Recupera_Tabla("sp_areas_picking", "@Tipo", iTipo, "@DOCClave", sDocumento)
        Dim i As Integer
        If dt.Rows.Count > 0 Then
            For i = 0 To dt.Rows.Count - 1
                Dim OpenReport As New Report
                Dim pvtaDataSet As New DataSet
                pvtaDataSet.DataSetName = "pvtaDataSet"
                pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_encabezado_surtido", "@Tipo", iTipo, "@DOCClave", sDocumento))
                pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_obtener_surtidodetalle", "@AREClave", dt.Rows(i)("AREClave"), "@Tipo", iTipo, "@DOCClave", sDocumento))
                pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_obtener_envio", "@Tipo", iTipo, "@DOCClave", sDocumento))
                If iTipo = 1 Then
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_complemento", "@VENClave", sDocumento))
                End If
                pvtaDataSet.DataSetName = "pvtaDataSet"

                Try
                    OpenReport.Print(dt.Rows(i)("NoImpresiones"), "CRSurtidoDetalle.rpt", pvtaDataSet, CStr(i + 1) & "/" & CStr(dt.Rows.Count) & " AREA " & dt.Rows(i)("Nombre") & stexto, dt.Rows(i)("PRNClave"))
                Catch ex As Exception
                    If ShowError = True Then
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                    sError = ex.Message
                End Try


            Next
        Else
            sError = "No se encontro alguna impresora definida para la area y forma de envio especificado"
            If ShowError = True Then
                MessageBox.Show(sError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
        dt.Dispose()
        frmStatusMessage.Dispose()
        Return sError
    End Function

    Public Function imprimeTicketCierre(ByVal IDCorte As String, ByVal Impresora As String, ByVal Generic As Boolean, ByVal Ticket As String) As Boolean
        Dim dtObjetos As DataTable

        Dim Tickets As Imprimir = New Imprimir 'PrintTicket.Ticket()
        Tickets.Generic = Generic
        Dim dtTicket As DataTable
        dtTicket = ModPOS.SiExisteRecupera("sp_recupera_ticket", "@TIKClave", Ticket)

        If Not dtTicket Is Nothing Then
            Tickets.MaxCharLine = dtTicket.Rows(0)("MaxChar")
            Tickets.LetraSize = dtTicket.Rows(0)("FontSize")
            Tickets.LetraName = dtTicket.Rows(0)("FontName")
            dtTicket.Dispose()
        End If

        Dim sApertura As String = ""
        Dim sCierre As String = ""
        Dim dApertura As DateTime
        Dim dCierre As DateTime
        Dim sCaja As String = ""
        Dim dSaldoApertura As Double = 0.0
        Dim dSaldoCierre As Double = 0.0
        Dim sCAJClave As String = ""


        dtObjetos = ModPOS.SiExisteRecupera("sp_recupera_corte", "@ID", IDCorte)

        If Not dtObjetos Is Nothing Then
            If dtObjetos.Rows.Count > 0 Then
                sCAJClave = dtObjetos.Rows(0)("CAJClave")
                sCaja = dtObjetos.Rows(0)("Clave")
                sApertura = dtObjetos.Rows(0)("Apertura")
                dApertura = dtObjetos.Rows(0)("FechaApertura")
                sCierre = dtObjetos.Rows(0)("Cierre")
                dCierre = dtObjetos.Rows(0)("FechaCierre")
                dSaldoApertura = dtObjetos.Rows(0)("SaldoApertura")
                dSaldoCierre = dtObjetos.Rows(0)("SaldoCierre")
            End If
            dtObjetos.Dispose()
        End If

        'Encabezado
        Tickets.AddHeaderLine("*** CORTE DE CAJA *** ", Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Centrado)

        'El metodo AddSubHeaderLine es lo mismo al de AddHeaderLine con la diferencia 
        'de que al final de cada linea agrega una linea punteada "==========" 
        Tickets.AddHeaderLine("CAJA: " & sCaja, 0, Imprimir.Alinear.Izquierda)
        Tickets.AddHeaderLine("APERTURA: " & sApertura, 0, Imprimir.Alinear.Izquierda)
        Tickets.AddHeaderLine("F.APERTURA: " & dApertura.ToShortDateString & " " & dApertura.ToShortTimeString, 0, Imprimir.Alinear.Izquierda)
        Tickets.AddHeaderLine("CIERRE: " & sCierre, 0, Imprimir.Alinear.Izquierda)
        Tickets.AddHeaderLine("F.CIERRE: " & dCierre.ToShortDateString & " " & dCierre.ToShortTimeString, 0, 3)

        Tickets.AddHeaderDotLine(Imprimir.FontEstilo.Regular, Imprimir.Alinear.Centrado)

        Dim fila As Integer = 0
        Dim foundRows() As DataRow
        Dim sConcepto As String = ""
        Dim dImporte As Double = 0.0
        Dim dTotalIngresos As Double = 0.0
        Dim dTotalEgresos As Double = 0.0
        Dim dTotalEfectivoCaja As Double = 0.0

        Tickets.AddHeaderLine("INGRESOS", Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Izquierda)


        dtObjetos = ModPOS.SiExisteRecupera("sp_arqueo_ingreso", "@CAJClave", sCAJClave, "@Inicial", dApertura, "@Final", dCierre)

        Dim dTotalPagos As Double = 0

        'If dSaldoApertura > 0 Then
        '    Tickets.AddHeaderLineDetalle("S. INICIAL", dSaldoApertura, Imprimir.FontEstilo.Regular, Imprimir.Alinear.Izquierda)
        '    dTotalPagos += dSaldoApertura
        'End If

        If Not dtObjetos Is Nothing Then
            If dtObjetos.Rows.Count > 0 Then
                foundRows = dtObjetos.Select("Importe > 0")
                If foundRows.GetLength(0) > 0 Then
                    'Ciclo de llenado AddHeaderLineDetalle
                    For fila = 0 To foundRows.GetUpperBound(0)
                        sConcepto = CStr(foundRows(fila)("Concepto"))
                        dImporte = CDbl(foundRows(fila)("Importe"))

                        If sConcepto = "EFECTIVO" Then
                            dTotalEfectivoCaja += dImporte
                        End If

                        dTotalPagos += dImporte
                        Tickets.AddHeaderLineDetalle(sConcepto, dImporte, Imprimir.FontEstilo.Regular, Imprimir.Alinear.Izquierda)
                    Next
                End If
            End If
            dtObjetos.Dispose()
        End If

        Tickets.AddHeaderLineDetalle("TOTAL", dTotalPagos, Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Izquierda)
        Tickets.AddHeaderDotLine(Imprimir.FontEstilo.Regular, Imprimir.Alinear.Centrado)

        dtObjetos = ModPOS.SiExisteRecupera("sp_arqueo_egreso", "@CAJClave", sCAJClave, "@Inicial", dApertura, "@Final", dCierre)

        If Not dtObjetos Is Nothing Then
            If dtObjetos.Rows.Count > 0 Then
                foundRows = dtObjetos.Select("Importe > 0")
                If foundRows.GetLength(0) > 0 Then
                    Tickets.AddHeaderLine("EGRESOS", Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Izquierda)
                    'Ciclo de llenado AddHeaderLineDetalle
                    For fila = 0 To foundRows.GetUpperBound(0)
                        sConcepto = CStr(foundRows(fila)("Concepto"))
                        dImporte = CDbl(foundRows(fila)("Importe"))
                        Tickets.AddHeaderLineDetalle(sConcepto, dImporte, Imprimir.FontEstilo.Regular, Imprimir.Alinear.Izquierda)
                        dTotalEgresos += dImporte
                    Next
                    Tickets.AddHeaderLineDetalle("TOTAL", dTotalEgresos, Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Izquierda)
                    Tickets.AddHeaderDotLine(Imprimir.FontEstilo.Regular, Imprimir.Alinear.Centrado)
                End If
            End If
            dtObjetos.Dispose()
        End If

        dTotalIngresos = dTotalPagos - dTotalEgresos
        'Tickets.AddHeaderLineDetalle("TOTAL EN CAJA", dTotalIngresos, Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Izquierda)
        'Tickets.AddHeaderDotLine(Imprimir.FontEstilo.Regular, Imprimir.Alinear.Centrado)

        '--- Fin Corte


        Tickets.AddHeaderLine("*** VENTAS DEL CORTE ***", Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Centrado)

        dtObjetos = ModPOS.SiExisteRecupera("sp_arqueo_credito", "@CAJClave", sCAJClave, "@Inicial", dApertura, "@Final", dCierre)

        Dim dTotalVta As Double = 0

        If Not dtObjetos Is Nothing Then
            If dtObjetos.Rows.Count > 0 Then
                foundRows = dtObjetos.Select("Importe > 0")
                If foundRows.GetLength(0) > 0 Then
                    Tickets.AddHeaderLine("CREDITO", Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Izquierda)
                    For fila = 0 To foundRows.GetUpperBound(0)
                        sConcepto = CStr(foundRows(fila)("Concepto"))
                        dImporte = CDbl(foundRows(fila)("Importe"))
                        dTotalVta += dImporte
                        Tickets.AddHeaderLineDetalle(sConcepto, dImporte, Imprimir.FontEstilo.Regular, Imprimir.Alinear.Izquierda)
                    Next
                    Tickets.AddHeaderLineDetalle("TOTAL", dTotalVta, Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Izquierda)
                    Tickets.AddHeaderDotLine(Imprimir.FontEstilo.Regular, Imprimir.Alinear.Centrado)

                End If
            End If
            dtObjetos.Dispose()
        End If

        dtObjetos = ModPOS.SiExisteRecupera("sp_arqueo_contado", "@CAJClave", sCAJClave, "@Inicial", dApertura, "@Final", dCierre)

        Dim dTotalContado As Double = 0

        If Not dtObjetos Is Nothing Then
            If dtObjetos.Rows.Count > 0 Then
                foundRows = dtObjetos.Select("Importe > 0")
                If foundRows.GetLength(0) > 0 Then
                    Tickets.AddHeaderLine("CONTADO", Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Izquierda)
                    For fila = 0 To foundRows.GetUpperBound(0)
                        sConcepto = CStr(foundRows(fila)("Concepto"))
                        dImporte = CDbl(foundRows(fila)("Importe"))
                        dTotalContado += dImporte
                        Tickets.AddHeaderLineDetalle(sConcepto, dImporte, Imprimir.FontEstilo.Regular, Imprimir.Alinear.Izquierda)
                    Next
                    Tickets.AddHeaderLineDetalle("TOTAL", dTotalContado, Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Izquierda)
                    Tickets.AddHeaderDotLine(Imprimir.FontEstilo.Regular, Imprimir.Alinear.Centrado)
                End If
            End If
            dtObjetos.Dispose()
        End If


        If (dTotalVta > 0 AndAlso dTotalContado > 0) OrElse (dTotalVta = 0 AndAlso dTotalContado = 0) Then
            Tickets.AddHeaderLineDetalle("TOTAL VENTAS", dTotalVta + dTotalContado, Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Izquierda)
            Tickets.AddHeaderDotLine(Imprimir.FontEstilo.Regular, Imprimir.Alinear.Centrado)
        End If

        dTotalVta += dTotalContado

        Tickets.AddHeaderLine("*** CARGOS DEL CORTE ***", Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Centrado)

        dtObjetos = ModPOS.SiExisteRecupera("sp_arqueo_cargo", "@CAJClave", sCAJClave, "@Inicial", dApertura, "@Final", dCierre)

        Dim dTotalCargos As Double = 0

        If Not dtObjetos Is Nothing Then
            If dtObjetos.Rows.Count > 0 Then
                foundRows = dtObjetos.Select("Importe > 0")
                If foundRows.GetLength(0) > 0 Then
                    For fila = 0 To foundRows.GetUpperBound(0)
                        sConcepto = CStr(foundRows(fila)("Concepto"))
                        dImporte = CDbl(foundRows(fila)("Importe"))
                        dTotalCargos += dImporte
                        Tickets.AddHeaderLineDetalle(sConcepto, dImporte, Imprimir.FontEstilo.Regular, Imprimir.Alinear.Izquierda)
                    Next
                    Tickets.AddHeaderLineDetalle("TOTAL", dTotalCargos, Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Izquierda)
                    Tickets.AddHeaderDotLine(Imprimir.FontEstilo.Regular, Imprimir.Alinear.Centrado)
                End If
            End If
            dtObjetos.Dispose()
        End If


        Dim dTotalCobranza As Double = 0


        dtObjetos = ModPOS.SiExisteRecupera("sp_arqueo_cobranza", "@CAJClave", sCAJClave, "@Inicial", dApertura, "@Final", dCierre)

        If Not dtObjetos Is Nothing Then
            If dtObjetos.Rows.Count > 0 Then
                foundRows = dtObjetos.Select("Importe > 0")
                If foundRows.GetLength(0) > 0 Then
                    Tickets.AddHeaderLine("*** COBRANZA DEL DIA ***", Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Centrado)
                    'Ciclo de llenado AddHeaderLineDetalle
                    For fila = 0 To foundRows.GetUpperBound(0)
                        sConcepto = CStr(foundRows(fila)("Concepto"))
                        dImporte = CDbl(foundRows(fila)("Importe"))
                        Tickets.AddHeaderLineDetalle(sConcepto, dImporte, Imprimir.FontEstilo.Regular, Imprimir.Alinear.Izquierda)
                        dTotalCobranza += dImporte
                    Next
                    Tickets.AddHeaderLineDetalle("TOTAL", dTotalCobranza, Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Izquierda)
                    Tickets.AddHeaderDotLine(Imprimir.FontEstilo.Regular, Imprimir.Alinear.Centrado)
                End If
            End If
            dtObjetos.Dispose()
        End If


        '----- Corte

        Dim dtDetalle As DataTable

        dtDetalle = ModPOS.SiExisteRecupera("sp_recupera_corteDet", "@Tipo", 1, "@ID", IDCorte)

        If Not dtDetalle Is Nothing Then
            If dtDetalle.Rows.Count > 0 Then
                Dim i As Integer
                For i = 0 To dtDetalle.Rows.Count - 1
                    If dtDetalle.Rows(i)("Denominacion").GetType.Name = "DBNull" OrElse IsNumeric(dtDetalle.Rows(i)("Denominacion")) Then
                        dTotalEfectivoCaja += CDbl(dtDetalle.Rows(i)("Importe"))
                    End If
                Next
            End If
            dtDetalle.Dispose()
        End If


        dtDetalle = ModPOS.SiExisteRecupera("sp_recupera_corteDet", "@Tipo", 2, "@ID", IDCorte)

        If Not dtDetalle Is Nothing Then
            If dtDetalle.Rows.Count > 0 Then
                Tickets.AddHeaderLine("*** DETALLE REGISTRADO ***", Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Centrado)
                Tickets.AddHeaderItem("CANT. ", "DENOMINACION", "IMPORTE", Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Derecha)
                Dim i As Integer
                For i = 0 To dtDetalle.Rows.Count - 1
                    Tickets.AddHeaderItem(CStr(IIf(dtDetalle.Rows(i)("Cantidad").GetType.Name = "DBNull", 1, dtDetalle.Rows(i)("Cantidad"))), CStr(IIf(dtDetalle.Rows(i)("Denominacion").GetType.Name = "DBNull", "Efectivo", dtDetalle.Rows(i)("Denominacion"))), Strings.Format(Redondear(dtDetalle.Rows(i)("Importe"), 2).ToString, "Currency"), Imprimir.FontEstilo.Regular, Imprimir.Alinear.Derecha)
                Next

                Tickets.AddHeaderItem("", "TOTAL", Strings.Format(Redondear(dSaldoCierre, 2).ToString, "Currency"), Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Derecha)
                Tickets.AddHeaderDotLine(Imprimir.FontEstilo.Regular, Imprimir.Alinear.Centrado)

            End If
            dtDetalle.Dispose()

        End If

        Tickets.AddHeaderLine("*** RESUMEN ***", Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Centrado)
        'Ciclo de llenado AddHeaderLineDetalle
        Tickets.AddHeaderLineDetalle("S. APERTURA", dSaldoApertura, Imprimir.FontEstilo.Regular, Imprimir.Alinear.Izquierda)
        Tickets.AddHeaderLineDetalle("SALDO AL CORTE", dSaldoApertura + dTotalIngresos, Imprimir.FontEstilo.Regular, Imprimir.Alinear.Izquierda)
        Tickets.AddHeaderLineDetalle("SALDO REGISTRADO", dSaldoCierre, Imprimir.FontEstilo.Regular, Imprimir.Alinear.Izquierda)
        Tickets.AddHeaderLineDetalle("SOBRANTE(FALTANTE)", dSaldoCierre - (dTotalEfectivoCaja - dTotalEgresos), Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Izquierda)
        Tickets.AddHeaderLineDetalle("T.EFECTIVO EN CAJA", dTotalEfectivoCaja - dTotalEgresos, Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Izquierda)

        Tickets.AddFooterLine("FIRMA DE RECIBIDO", Imprimir.FontEstilo.Regular, Imprimir.Alinear.Izquierda)
        Tickets.AddFooterLine("", Imprimir.FontEstilo.Regular, Imprimir.Alinear.Derecha)
        Tickets.AddFooterLine("", Imprimir.FontEstilo.Regular, Imprimir.Alinear.Derecha)
        Tickets.AddFooterLine("", Imprimir.FontEstilo.Regular, Imprimir.Alinear.Derecha)
        Tickets.AddFooterLine("-------------------------", Imprimir.FontEstilo.Regular, Imprimir.Alinear.Centrado)
        Tickets.AddFooterLine("FIRMA", Imprimir.FontEstilo.Regular, Imprimir.Alinear.Centrado)


        Tickets.PrintTicket(Impresora, 70, 0)

    End Function

    Public Function imprimeTicketPreCorte(ByVal IDCorte As String, ByVal Impresora As String, ByVal Generic As Boolean, ByVal Ticket As String) As Boolean
        Dim dtObjetos As DataTable

        Dim Tickets As Imprimir = New Imprimir 'PrintTicket.Ticket()
        Tickets.Generic = Generic
        Dim dtTicket As DataTable
        dtTicket = ModPOS.SiExisteRecupera("sp_recupera_ticket", "@TIKClave", Ticket)

        If Not dtTicket Is Nothing Then
            Tickets.MaxCharLine = dtTicket.Rows(0)("MaxChar")
            Tickets.LetraSize = dtTicket.Rows(0)("FontSize")
            Tickets.LetraName = dtTicket.Rows(0)("FontName")
            dtTicket.Dispose()
        End If

        Dim sApertura As String = ""
        'Dim sCierre As String = ""
        Dim dApertura As DateTime
        Dim dCierre As DateTime = DateTime.Now
        Dim sCaja As String = ""
        Dim dSaldoApertura As Double = 0.0
        Dim dSaldoCierre As Double = 0.0
        Dim sCAJClave As String = ""


        dtObjetos = ModPOS.SiExisteRecupera("sp_recupera_corte", "@ID", IDCorte)

        If Not dtObjetos Is Nothing Then
            If dtObjetos.Rows.Count > 0 Then
                sCAJClave = dtObjetos.Rows(0)("CAJClave")
                sCaja = dtObjetos.Rows(0)("Clave")
                sApertura = dtObjetos.Rows(0)("Apertura")
                dApertura = dtObjetos.Rows(0)("FechaApertura")
                dSaldoApertura = dtObjetos.Rows(0)("SaldoApertura")
            End If
            dtObjetos.Dispose()
        End If

        'Encabezado
        Tickets.AddHeaderLine("*** PRE-CORTE DE CAJA *** ", Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Centrado)

        'El metodo AddSubHeaderLine es lo mismo al de AddHeaderLine con la diferencia 
        'de que al final de cada linea agrega una linea punteada "==========" 
        Tickets.AddHeaderLine("CAJA: " & sCaja, 0, Imprimir.Alinear.Izquierda)
        Tickets.AddHeaderLine("APERTURA: " & sApertura, 0, Imprimir.Alinear.Izquierda)
        Tickets.AddHeaderLine("F.APERTURA: " & dApertura.ToShortDateString & " " & dApertura.ToShortTimeString, 0, Imprimir.Alinear.Izquierda)
        Tickets.AddHeaderLine("F.CIERRE  : " & dCierre.ToShortDateString & " " & dCierre.ToShortTimeString, 0, 3)

        Tickets.AddHeaderDotLine(Imprimir.FontEstilo.Regular, Imprimir.Alinear.Centrado)

        Dim fila As Integer = 0
        Dim foundRows() As DataRow
        Dim sConcepto As String = ""
        Dim dImporte As Double = 0.0
        Dim dTotalIngresos As Double = 0.0
        Dim dTotalEgresos As Double = 0.0
        Dim dTotalEfectivoCaja As Double = 0.0

        Tickets.AddHeaderLine("INGRESOS", Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Izquierda)


        dtObjetos = ModPOS.SiExisteRecupera("sp_arqueo_ingreso", "@CAJClave", sCAJClave, "@Inicial", dApertura, "@Final", dCierre)

        Dim dTotalPagos As Double = 0

        'If dSaldoApertura > 0 Then
        '    Tickets.AddHeaderLineDetalle("S. INICIAL", dSaldoApertura, Imprimir.FontEstilo.Regular, Imprimir.Alinear.Izquierda)
        '    dTotalPagos += dSaldoApertura
        'End If

        If Not dtObjetos Is Nothing Then
            If dtObjetos.Rows.Count > 0 Then
                foundRows = dtObjetos.Select("Importe > 0")
                If foundRows.GetLength(0) > 0 Then
                    'Ciclo de llenado AddHeaderLineDetalle
                    For fila = 0 To foundRows.GetUpperBound(0)
                        sConcepto = CStr(foundRows(fila)("Concepto"))
                        dImporte = CDbl(foundRows(fila)("Importe"))

                        If sConcepto = "EFECTIVO" Then
                            dTotalEfectivoCaja += dImporte
                        End If

                        dTotalPagos += dImporte
                        Tickets.AddHeaderLineDetalle(sConcepto, dImporte, Imprimir.FontEstilo.Regular, Imprimir.Alinear.Izquierda)

                    Next
                End If
            End If
            dtObjetos.Dispose()
        End If

        Tickets.AddHeaderLineDetalle("TOTAL", dTotalPagos, Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Izquierda)
        Tickets.AddHeaderDotLine(Imprimir.FontEstilo.Regular, Imprimir.Alinear.Centrado)

        dtObjetos = ModPOS.SiExisteRecupera("sp_arqueo_egreso", "@CAJClave", sCAJClave, "@Inicial", dApertura, "@Final", dCierre)

        If Not dtObjetos Is Nothing Then
            If dtObjetos.Rows.Count > 0 Then
                foundRows = dtObjetos.Select("Importe > 0")
                If foundRows.GetLength(0) > 0 Then
                    Tickets.AddHeaderLine("EGRESOS", Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Izquierda)
                    'Ciclo de llenado AddHeaderLineDetalle
                    For fila = 0 To foundRows.GetUpperBound(0)
                        sConcepto = CStr(foundRows(fila)("Concepto"))
                        dImporte = CDbl(foundRows(fila)("Importe"))
                        Tickets.AddHeaderLineDetalle(sConcepto, dImporte, Imprimir.FontEstilo.Regular, Imprimir.Alinear.Izquierda)
                        dTotalEgresos += dImporte
                    Next
                    Tickets.AddHeaderLineDetalle("TOTAL", dTotalEgresos, Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Izquierda)
                    Tickets.AddHeaderDotLine(Imprimir.FontEstilo.Regular, Imprimir.Alinear.Centrado)
                End If
            End If
            dtObjetos.Dispose()
        End If

        dTotalIngresos = dTotalPagos - dTotalEgresos
        'Tickets.AddHeaderLineDetalle("TOTAL EN CAJA", dTotalIngresos, Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Izquierda)
        'Tickets.AddHeaderDotLine(Imprimir.FontEstilo.Regular, Imprimir.Alinear.Centrado)

        '--- Fin Corte


        Tickets.AddHeaderLine("*** VENTAS DEL CORTE ***", Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Centrado)

        dtObjetos = ModPOS.SiExisteRecupera("sp_arqueo_credito", "@CAJClave", sCAJClave, "@Inicial", dApertura, "@Final", dCierre)

        Dim dTotalVta As Double = 0

        If Not dtObjetos Is Nothing Then
            If dtObjetos.Rows.Count > 0 Then
                foundRows = dtObjetos.Select("Importe > 0")
                If foundRows.GetLength(0) > 0 Then
                    Tickets.AddHeaderLine("CREDITO", Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Izquierda)
                    For fila = 0 To foundRows.GetUpperBound(0)
                        sConcepto = CStr(foundRows(fila)("Concepto"))
                        dImporte = CDbl(foundRows(fila)("Importe"))
                        dTotalVta += dImporte
                        Tickets.AddHeaderLineDetalle(sConcepto, dImporte, Imprimir.FontEstilo.Regular, Imprimir.Alinear.Izquierda)
                    Next
                    Tickets.AddHeaderLineDetalle("TOTAL", dTotalVta, Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Izquierda)
                    Tickets.AddHeaderDotLine(Imprimir.FontEstilo.Regular, Imprimir.Alinear.Centrado)

                End If
            End If
            dtObjetos.Dispose()
        End If

        dtObjetos = ModPOS.SiExisteRecupera("sp_arqueo_contado", "@CAJClave", sCAJClave, "@Inicial", dApertura, "@Final", dCierre)

        Dim dTotalContado As Double = 0

        If Not dtObjetos Is Nothing Then
            If dtObjetos.Rows.Count > 0 Then
                foundRows = dtObjetos.Select("Importe > 0")
                If foundRows.GetLength(0) > 0 Then
                    Tickets.AddHeaderLine("CONTADO", Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Izquierda)
                    For fila = 0 To foundRows.GetUpperBound(0)
                        sConcepto = CStr(foundRows(fila)("Concepto"))
                        dImporte = CDbl(foundRows(fila)("Importe"))
                        dTotalContado += dImporte
                        Tickets.AddHeaderLineDetalle(sConcepto, dImporte, Imprimir.FontEstilo.Regular, Imprimir.Alinear.Izquierda)
                    Next
                    Tickets.AddHeaderLineDetalle("TOTAL", dTotalContado, Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Izquierda)
                    Tickets.AddHeaderDotLine(Imprimir.FontEstilo.Regular, Imprimir.Alinear.Centrado)
                End If
            End If
            dtObjetos.Dispose()
        End If


        If (dTotalVta > 0 AndAlso dTotalContado > 0) OrElse (dTotalVta = 0 AndAlso dTotalContado = 0) Then
            Tickets.AddHeaderLineDetalle("TOTAL VENTAS", dTotalVta + dTotalContado, Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Izquierda)
            Tickets.AddHeaderDotLine(Imprimir.FontEstilo.Regular, Imprimir.Alinear.Centrado)
        End If

        dTotalVta += dTotalContado

        Tickets.AddHeaderLine("*** CARGOS DEL CORTE ***", Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Centrado)

        dtObjetos = ModPOS.SiExisteRecupera("sp_arqueo_cargo", "@CAJClave", sCAJClave, "@Inicial", dApertura, "@Final", dCierre)

        Dim dTotalCargos As Double = 0

        If Not dtObjetos Is Nothing Then
            If dtObjetos.Rows.Count > 0 Then
                foundRows = dtObjetos.Select("Importe > 0")
                If foundRows.GetLength(0) > 0 Then
                    For fila = 0 To foundRows.GetUpperBound(0)
                        sConcepto = CStr(foundRows(fila)("Concepto"))
                        dImporte = CDbl(foundRows(fila)("Importe"))
                        dTotalCargos += dImporte
                        Tickets.AddHeaderLineDetalle(sConcepto, dImporte, Imprimir.FontEstilo.Regular, Imprimir.Alinear.Izquierda)
                    Next
                    Tickets.AddHeaderLineDetalle("TOTAL", dTotalCargos, Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Izquierda)
                    Tickets.AddHeaderDotLine(Imprimir.FontEstilo.Regular, Imprimir.Alinear.Centrado)
                End If
            End If
            dtObjetos.Dispose()
        End If


        Dim dTotalCobranza As Double = 0


        dtObjetos = ModPOS.SiExisteRecupera("sp_arqueo_cobranza", "@CAJClave", sCAJClave, "@Inicial", dApertura, "@Final", dCierre)

        If Not dtObjetos Is Nothing Then
            If dtObjetos.Rows.Count > 0 Then
                foundRows = dtObjetos.Select("Importe > 0")
                If foundRows.GetLength(0) > 0 Then
                    Tickets.AddHeaderLine("*** COBRANZA DEL DIA ***", Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Centrado)
                    'Ciclo de llenado AddHeaderLineDetalle
                    For fila = 0 To foundRows.GetUpperBound(0)
                        sConcepto = CStr(foundRows(fila)("Concepto"))
                        dImporte = CDbl(foundRows(fila)("Importe"))
                        Tickets.AddHeaderLineDetalle(sConcepto, dImporte, Imprimir.FontEstilo.Regular, Imprimir.Alinear.Izquierda)
                        dTotalCobranza += dImporte
                    Next
                    Tickets.AddHeaderLineDetalle("TOTAL", dTotalCobranza, Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Izquierda)
                    Tickets.AddHeaderDotLine(Imprimir.FontEstilo.Regular, Imprimir.Alinear.Centrado)
                End If
            End If
            dtObjetos.Dispose()
        End If

        'Corte
        Dim dtDetalle As DataTable

        dtDetalle = ModPOS.SiExisteRecupera("sp_recupera_corteDet", "@Tipo", 1, "@ID", IDCorte)

        If Not dtDetalle Is Nothing Then
            If dtDetalle.Rows.Count > 0 Then
                Dim i As Integer
                For i = 0 To dtDetalle.Rows.Count - 1
                    If dtDetalle.Rows(i)("Denominacion").GetType.Name = "DBNull" OrElse IsNumeric(dtDetalle.Rows(i)("Denominacion")) Then
                        dTotalEfectivoCaja += CDbl(dtDetalle.Rows(i)("Importe"))
                    End If
                Next
            End If
            dtDetalle.Dispose()
        End If

        Tickets.AddHeaderLine("*** RESUMEN ***", Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Centrado)
        'Ciclo de llenado AddHeaderLineDetalle
        Tickets.AddHeaderLineDetalle("S. APERTURA", dSaldoApertura, Imprimir.FontEstilo.Regular, Imprimir.Alinear.Izquierda)
        Tickets.AddHeaderLineDetalle("SALDO AL CORTE", dSaldoApertura + dTotalIngresos, Imprimir.FontEstilo.Regular, Imprimir.Alinear.Izquierda)
        Tickets.AddHeaderLineDetalle("T.EFECTIVO EN CAJA", dTotalEfectivoCaja - dTotalEgresos, Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Izquierda)

        'Tickets.AddHeaderLineDetalle("SALDO REGISTRADO", dSaldoCierre, Imprimir.FontEstilo.Regular, Imprimir.Alinear.Izquierda)
        'Tickets.AddHeaderLineDetalle("SOBRANTE(FALTANTE)", dSaldoCierre - dTotalIngresos, Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Izquierda)
        'Tickets.AddFooterLine("FIRMA DE RECIBIDO", Imprimir.FontEstilo.Regular, Imprimir.Alinear.Izquierda)
        'Tickets.AddFooterLine("", Imprimir.FontEstilo.Regular, Imprimir.Alinear.Derecha)
        'Tickets.AddFooterLine("", Imprimir.FontEstilo.Regular, Imprimir.Alinear.Derecha)
        'Tickets.AddFooterLine("", Imprimir.FontEstilo.Regular, Imprimir.Alinear.Derecha)
        'Tickets.AddFooterLine("-------------------------", Imprimir.FontEstilo.Regular, Imprimir.Alinear.Centrado)
        'Tickets.AddFooterLine("FIRMA", Imprimir.FontEstilo.Regular, Imprimir.Alinear.Centrado)


        Tickets.PrintTicket(Impresora, 70, 0)

    End Function


    Public Function crearQR33(ByVal eRFC As String, ByVal RFC As String, ByVal total As Double, ByVal uuid As String, ByVal sello As String) As Byte()
        Dim CBB() As Byte = Nothing
        Try
            Dim encoderQR As New ThoughtWorks.QRCode.Codec.QRCodeEncoder

            '122 bytes de datos en este encode!!
            encoderQR.QRCodeEncodeMode = ThoughtWorks.QRCode.Codec.QRCodeEncoder.ENCODE_MODE.BYTE
            encoderQR.QRCodeScale = 3
            encoderQR.QRCodeVersion = 0
            encoderQR.QRCodeErrorCorrect = ThoughtWorks.QRCode.Codec.QRCodeEncoder.ERROR_CORRECTION.M

            Dim imagen As System.Drawing.Bitmap
            '-- url  https://verificacfdi.facturaelectronica.sat.gob.mx/default.aspx
            'id	UUID del comprobante, precedido por el texto “&id=”-------------------------------------------------------------------------------------------- 40
            're	RFC del Emisor, a 12/13 posiciones, precedido por el texto ”?re=”------------------------------------------------------------------------------ 16/21
            'rr	RFC del Receptor, a 12/13 posiciones o se usa el NumRegIdTrib, precedido por el texto “&rr=” ---------------------------------------------------16/84
            'tt	Total del comprobante maximo a 25 posiciones (18 para los enteros, 1 para carácter “.”, 6 para los decimales), precedido por el texto “&tt=” ---07/29
            'fe Ocho ultimos caracteres del sello digital del emisor  precedido por "&tt=" -------------------------------------12/42

            Dim sUrl As String = "https://verificacfdi.facturaelectronica.sat.gob.mx/default.aspx?"
            Dim sTotal As String = cFormat(CStr(Redondear(CDbl(total), 6)))



            imagen = encoderQR.Encode(sUrl & "&id=" & uuid & "&re=" & eRFC & "&rr=" & RFC & "&tt=" & sTotal & "&fe=" & sello, System.Text.Encoding.UTF8)

            CBB = ModPOS.ConvertBitmapToByteArray(imagen)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error al generar QR Code", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return CBB
    End Function


    Public Function crearQR(ByVal eRFC As String, ByVal RFC As String, ByVal total As Double, ByVal uuid As String) As Byte()
        Dim CBB() As Byte = Nothing
        Try
            Dim encoderQR As New ThoughtWorks.QRCode.Codec.QRCodeEncoder

            '122 bytes de datos en este encode!!
            encoderQR.QRCodeEncodeMode = ThoughtWorks.QRCode.Codec.QRCodeEncoder.ENCODE_MODE.BYTE
            encoderQR.QRCodeScale = 3
            encoderQR.QRCodeVersion = 7
            encoderQR.QRCodeErrorCorrect = ThoughtWorks.QRCode.Codec.QRCodeEncoder.ERROR_CORRECTION.M

            Dim imagen As System.Drawing.Bitmap
            're	RFC del Emisor, a 12/13 posiciones, precedido por el texto ”?re=”--------------------------------------------------------------------------------------- 17
            'rr	RFC del Receptor, a 12/13 posiciones, precedido por el texto “&rr=” ------------------------------------------------------------------------------------ 17
            'tt	Total del comprobante a 17 posiciones (10 para los enteros, 1 para carácter “.”, 6 para los decimales), precedido por el texto “&tt=” ---------21
            'id	UUID del comprobante, precedido por el texto “&id=”------------------------------------------------------------------------------------------------------- 40

            Dim sTotal As String = cFormat(CStr(Redondear(CDbl(total), 6)))

            If sTotal.Split(".").Length >= 1 Then

                sTotal = Right("0000000000" & sTotal.Split(".")(0), 10) & "." & Left(sTotal.Split(".")(1) & "000000", 6)

            End If

            imagen = encoderQR.Encode("?re=" & eRFC & "&rr=" & RFC & "&tt=" & sTotal & "&id=" & uuid)

            CBB = ModPOS.ConvertBitmapToByteArray(imagen)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error al generar QR Code", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return CBB
    End Function

    Private Function generaXmlCancelarCfdi(ByVal RfcEmisor As String, ByVal UUID As String, ByVal directorioCer As String, ByVal directorioKey As String, ByVal pass As String, ByRef xmlCancelacion As String, ByRef [error] As String) As Boolean
        Dim xmlCan As XmlDocument = New XmlDocument()
        Dim xmlC14N As XmlDocument = New XmlDocument()
        Dim digestion As String = String.Empty
        Dim sello As String = String.Empty
        Dim boolProceso As Boolean = True

        Try
            Dim xCan As XmlElement = xmlCan.CreateElement("", "Cancelacion", "http://cancelacfd.sat.gob.mx")
            Dim xAttr As XmlAttribute = xmlCan.CreateAttribute("xmlns", "xsd", "http://www.w3.org/2000/xmlns/")
            xAttr.InnerText = "http://www.w3.org/2001/XMLSchema"
            xCan.Attributes.Append(xAttr)
            xAttr = xmlCan.CreateAttribute("xmlns", "xsi", "http://www.w3.org/2000/xmlns/")
            xAttr.InnerText = "http://www.w3.org/2001/XMLSchema-instance"
            xCan.Attributes.Append(xAttr)
            xAttr = xmlCan.CreateAttribute("RfcEmisor")
            xAttr.Value = RfcEmisor
            xCan.Attributes.Append(xAttr)
            xAttr = xmlCan.CreateAttribute("Fecha")
            xAttr.Value = DateTime.Now.ToString("s")
            xCan.Attributes.Append(xAttr)
            Dim xFolios As XmlElement = xmlCan.CreateElement("Folios", "http://cancelacfd.sat.gob.mx")
            Dim xUuid As XmlElement = xmlCan.CreateElement("UUID", "http://cancelacfd.sat.gob.mx")
            xUuid.InnerText = UUID
            xFolios.AppendChild(xUuid)
            xCan.AppendChild(xFolios)
            xmlCan.AppendChild(xCan)
            xmlC14N.LoadXml(xmlCan.InnerXml)
            Dim tXmlCanon As XmlDsigC14NTransform = New XmlDsigC14NTransform()
            tXmlCanon.LoadInput(xmlC14N)
            Dim sXmlCanon As Stream = CType(tXmlCanon.GetOutput(GetType(Stream)), Stream)
            Dim readerXmlCanon As StreamReader = New StreamReader(sXmlCanon)
            Dim strXmlCanonizado As String = readerXmlCanon.ReadToEnd()
            Dim sha1 As SHA1Managed = New SHA1Managed()
            Dim byteMsg As Byte() = System.Text.Encoding.GetEncoding("utf-8").GetBytes(strXmlCanonizado)
            Dim hash As Byte() = sha1.ComputeHash(byteMsg)
            digestion = Convert.ToBase64String(hash)
            Dim xSignature As XmlElement = xmlCan.CreateElement("Signature", "http://cancelacfd.sat.gob.mx")
            xAttr = xmlCan.CreateAttribute("xmlns", "http://www.w3.org/2000/xmlns/")
            xAttr.InnerText = "http://www.w3.org/2000/09/xmldsig#"
            xSignature.Attributes.Append(xAttr)
            Dim xSignedInfo As XmlElement = xmlCan.CreateElement("SignedInfo", "http://cancelacfd.sat.gob.mx")
            Dim xCanonicalizationMethod As XmlElement = xmlCan.CreateElement("CanonicalizationMethod", "http://cancelacfd.sat.gob.mx")
            xAttr = xmlCan.CreateAttribute("Algorithm")
            xAttr.InnerText = "http://www.w3.org/TR/2001/REC-xml-c14n-20010315"
            xCanonicalizationMethod.Attributes.Append(xAttr)
            xSignedInfo.AppendChild(xCanonicalizationMethod)
            Dim xSignatureMethod As XmlElement = xmlCan.CreateElement("SignatureMethod", "http://cancelacfd.sat.gob.mx")
            xAttr = xmlCan.CreateAttribute("Algorithm")
            xAttr.InnerText = "http://www.w3.org/2000/09/xmldsig#rsa-sha1"
            xSignatureMethod.Attributes.Append(xAttr)
            xSignedInfo.AppendChild(xSignatureMethod)
            Dim xReference As XmlElement = xmlCan.CreateElement("Reference", "http://cancelacfd.sat.gob.mx")
            xAttr = xmlCan.CreateAttribute("URI")
            xAttr.InnerText = ""
            xReference.Attributes.Append(xAttr)
            Dim xTransforms As XmlElement = xmlCan.CreateElement("Transforms", "http://cancelacfd.sat.gob.mx")
            Dim xTransform As XmlElement = xmlCan.CreateElement("Transform", "http://cancelacfd.sat.gob.mx")
            xAttr = xmlCan.CreateAttribute("Algorithm")
            xAttr.InnerText = "http://www.w3.org/2000/09/xmldsig#enveloped-signature"
            xTransform.Attributes.Append(xAttr)
            xTransforms.AppendChild(xTransform)
            xReference.AppendChild(xTransforms)
            Dim xDigestMethod As XmlElement = xmlCan.CreateElement("DigestMethod", "http://cancelacfd.sat.gob.mx")
            xAttr = xmlCan.CreateAttribute("Algorithm")
            xAttr.InnerText = "http://www.w3.org/2000/09/xmldsig#sha1"
            xDigestMethod.Attributes.Append(xAttr)
            xReference.AppendChild(xDigestMethod)
            Dim xDigestValue As XmlElement = xmlCan.CreateElement("DigestValue", "http://cancelacfd.sat.gob.mx")
            xDigestValue.InnerText = digestion
            xReference.AppendChild(xDigestValue)
            xSignedInfo.AppendChild(xReference)
            xSignature.AppendChild(xSignedInfo)
            Dim strXSignature As String = "<SignedInfo xmlns=" & Chr(34) & "http://www.w3.org/2000/09/xmldsig#" & Chr(34) & " xmlns:xsd=" & Chr(34) & "http://www.w3.org/2001/XMLSchema" & Chr(34) & " xmlns:xsi=" & Chr(34) & "http://www.w3.org/2001/XMLSchema-instance" & Chr(34) & ">" & "<CanonicalizationMethod Algorithm=" & Chr(34) & "http://www.w3.org/TR/2001/REC-xml-c14n-20010315" & Chr(34) & "></CanonicalizationMethod>" & "<SignatureMethod Algorithm=" & Chr(34) & "http://www.w3.org/2000/09/xmldsig#rsa-sha1" & Chr(34) & "></SignatureMethod>" & "<Reference URI=" & Chr(34) & Chr(34) & ">" & "<Transforms>" & "<Transform Algorithm=" & Chr(34) & "http://www.w3.org/2000/09/xmldsig#enveloped-signature" & Chr(34) & "></Transform>" & "</Transforms>" & "<DigestMethod Algorithm=" & Chr(34) & "http://www.w3.org/2000/09/xmldsig#sha1" & Chr(34) & "></DigestMethod>" & "<DigestValue>" & digestion & "</DigestValue>" & "</Reference>" & "</SignedInfo>"

            Dim docXSignature As XmlDocument = New XmlDocument()
            docXSignature.LoadXml(strXSignature)
            Dim tDocXSignature As XmlDsigC14NTransform = New XmlDsigC14NTransform()
            tDocXSignature.LoadInput(docXSignature)
            Dim sgDocXSignature As Stream = CType(tDocXSignature.GetOutput(GetType(Stream)), Stream)
            Dim readerDocXSignature As StreamReader = New StreamReader(sgDocXSignature)
            strXSignature = readerDocXSignature.ReadToEnd()

            If FirmaBouncy(directorioCer, directorioKey, pass, strXSignature, sello, [error]) Then
                boolProceso = True
            Else
                boolProceso = False
            End If

            If boolProceso Then
                Dim xSignatureValue As XmlElement = xmlCan.CreateElement("SignatureValue", "http://cancelacfd.sat.gob.mx")
                xSignatureValue.InnerText = sello
                xSignature.AppendChild(xSignatureValue)
                Dim xKeyInfo As XmlElement = xmlCan.CreateElement("KeyInfo", "http://cancelacfd.sat.gob.mx")
                Dim xX509Data As XmlElement = xmlCan.CreateElement("X509Data", "http://cancelacfd.sat.gob.mx")
                Dim xX509IssuerSerial As XmlElement = xmlCan.CreateElement("X509IssuerSerial", "http://cancelacfd.sat.gob.mx")
                Dim cer As X509Certificate2 = New X509Certificate2(CType(File.ReadAllBytes(directorioCer), Byte()))
                Dim ki As KeyInfo = New KeyInfo()
                Dim clause As KeyInfoX509Data = New KeyInfoX509Data()
                clause.AddCertificate(cer)
                clause.AddIssuerSerial(cer.Issuer, cer.GetSerialNumberString())
                ki.AddClause(clause)
                Dim xX509DataExtrae As XmlElement = ki.GetXml()
                Dim nt As NameTable = New NameTable()
                Dim xmlNSmanager As XmlNamespaceManager = New XmlNamespaceManager(nt)
                xmlNSmanager.AddNamespace("d", "http://www.w3.org/2000/09/xmldsig#")
                Dim strIssuerName As String = xX509DataExtrae.SelectSingleNode("d:X509Data/d:X509IssuerSerial/d:X509IssuerName", xmlNSmanager).InnerText
                Dim strSerialNumber As String = xX509DataExtrae.SelectSingleNode("d:X509Data/d:X509IssuerSerial/d:X509SerialNumber", xmlNSmanager).InnerText
                Dim strCertificate As String = xX509DataExtrae.SelectSingleNode("d:X509Data/d:X509Certificate", xmlNSmanager).InnerText
                Dim xX509IssuerName As XmlElement = xmlCan.CreateElement("X509IssuerName", "http://cancelacfd.sat.gob.mx")
                xX509IssuerName.InnerText = strIssuerName
                Dim xX509SerialNumber As XmlElement = xmlCan.CreateElement("X509SerialNumber", "http://cancelacfd.sat.gob.mx")
                xX509SerialNumber.InnerText = strSerialNumber
                xX509IssuerSerial.AppendChild(xX509IssuerName)
                xX509IssuerSerial.AppendChild(xX509SerialNumber)
                xX509Data.AppendChild(xX509IssuerSerial)
                Dim xX509Certificate As XmlElement = xmlCan.CreateElement("X509Certificate", "http://cancelacfd.sat.gob.mx")
                xX509Certificate.InnerText = strCertificate
                xX509Data.AppendChild(xX509Certificate)
                xKeyInfo.AppendChild(xX509Data)
                xSignature.AppendChild(xKeyInfo)
                xCan.AppendChild(xSignature)
                xmlCan.RemoveAll()
                xmlCan.AppendChild(xCan)
                xmlCancelacion = xmlCan.InnerXml

            End If
        Catch ex As Exception
            [error] = (If((ex.InnerException Is Nothing), ex.Message, String.Format("{0}" & vbCrLf & "{1}", ex.Message, ex.InnerException.Message)))
            boolProceso = False
        End Try

        Return boolProceso
    End Function

    Public Function FirmaBouncy(ByVal directorioCer As String, ByVal directorioKey As String, ByVal pass As String, ByVal Xml As String, ByRef strSello As String, ByRef strError As String) As Boolean
        strSello = String.Empty
        strError = String.Empty
        Dim boolProceso As Boolean = True
        Dim directorio As String = Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).ToString()).ToString()
        Try
            Dim cer As X509Certificate2 = New X509Certificate2(CType(File.ReadAllBytes(directorioCer), Byte()))
            Dim llave As Byte() = CType(File.ReadAllBytes(directorioKey), Byte())

            Dim data As Stream = New MemoryStream(llave)
            Dim key As Org.BouncyCastle.Crypto.AsymmetricKeyParameter
            key = Org.BouncyCastle.Security.PrivateKeyFactory.DecryptKey(pass.ToCharArray(), data)
            If Not (TypeOf key Is RsaPrivateCrtKeyParameters) Then
                boolProceso = False
                strError = "La llave no pudo ser descifrada corrobore su archivo KEY y su password"
            End If

            Dim sha1 As SHA1Managed = New SHA1Managed()
            Dim byteMsg As Byte() = System.Text.Encoding.GetEncoding("utf-8").GetBytes(Xml)
            Dim hash As Byte() = sha1.ComputeHash(byteMsg)
            Dim signer As Org.BouncyCastle.Crypto.ISigner = Org.BouncyCastle.Security.SignerUtilities.GetSigner("SHA1WithRSA")
            signer.Init(True, key)
            signer.BlockUpdate(byteMsg, 0, byteMsg.Length)
            Dim sig As Byte() = signer.GenerateSignature()
            data.Close()
            data.Dispose()
            Dim rsa = CType(cer.PublicKey.Key, RSACryptoServiceProvider)
            If Not rsa.VerifyData(byteMsg, CryptoConfig.MapNameToOID("SHA1"), sig) Then
                boolProceso = False
                strError = "Archivo CER no corresponde con Archivo KEY"
            End If

            strSello = Convert.ToBase64String(sig)
        Catch ex As Exception
            boolProceso = False
            strError = ex.ToString().Replace("'", "")
        End Try

        Return boolProceso
    End Function


    'Private Function generaXmlCancelarCfdi(ByVal DirPFX As String, ByVal ContrasenaClave As String, ByVal rfc As String, ByVal fecha As String, ByVal Folios() As String) As String
    '    Dim _MiCertificado As X509Certificate2 = New X509Certificate2(DirPFX, ContrasenaClave)
    '    Dim Key As RSACryptoServiceProvider = CType(_MiCertificado.PrivateKey, RSACryptoServiceProvider)
    '    Dim si As XNamespace = "http://www.w3.org/2001/XMLSchema-instance"
    '    Dim sl As XNamespace = "http://www.w3.org/2001/XMLSchema"
    '    Dim xmlns As XNamespace = "http://cancelacfd.sat.gob.mx"
    '    Dim root As XElement = New XElement(xmlns + "Cancelacion", New XAttribute(XNamespace.Xmlns + "xsd", sl.NamespaceName), New XAttribute(XNamespace.Xmlns + "xsi", si.NamespaceName), New XAttribute("RfcEmisor", rfc), New XAttribute("Fecha", fecha), From c In Folios Select New XElement(xmlns + "Folios", New XElement(xmlns + "UUID", c)))
    '    Dim doc As XmlDocument = New XmlDocument()
    '    doc.LoadXml(root.ToString())
    '    Dim signedXml As SignedXml = New SignedXml(doc)
    '    signedXml.SigningKey = Key
    '    signedXml.SignedInfo.CanonicalizationMethod = signedXml.XmlDsigCanonicalizationUrl
    '    Dim reference As Reference = New Reference()
    '    reference.Uri = ""
    '    Dim env As XmlDsigEnvelopedSignatureTransform = New XmlDsigEnvelopedSignatureTransform()
    '    reference.AddTransform(env)
    '    signedXml.AddReference(reference)
    '    Dim keyInfo As KeyInfo = New KeyInfo()
    '    Dim kdata As KeyInfoX509Data = New KeyInfoX509Data(_MiCertificado)
    '    kdata.AddSubjectName(_MiCertificado.IssuerName.Name)
    '    keyInfo.AddClause(kdata)
    '    signedXml.KeyInfo = keyInfo
    '    signedXml.ComputeSignature()
    '    Dim xmlDigitalSignature As XmlElement = signedXml.GetXml()
    '    doc.DocumentElement.AppendChild(doc.ImportNode(xmlDigitalSignature, True))
    '    If TypeOf doc.FirstChild Is XmlDeclaration Then
    '        doc.RemoveChild(doc.FirstChild)
    '    End If

    '    Dim sw As StringWriter = New StringWriter()
    '    Dim tx As XmlTextWriter = New XmlTextWriter(sw)
    '    doc.WriteTo(tx)
    '    Dim sin As SignatureType = New SignatureType()
    '    Dim siType As SignedInfoType = New SignedInfoType()
    '    Dim cmtype As CanonicalizationMethodType = New CanonicalizationMethodType()
    '    cmtype.Algorithm = "http://www.w3.org/TR/2001/REC-xml-c14n-20010315"
    '    siType.CanonicalizationMethod = cmtype
    '    Dim smType As SignatureMethodType = New SignatureMethodType()
    '    smType.Algorithm = "http://www.w3.org/2000/09/xmldsig#rsa-sha1"
    '    siType.SignatureMethod = smType
    '    Dim rtype As ReferenceType = New ReferenceType()
    '    rtype.URI = ""
    '    Dim transType As TransformType = New TransformType()
    '    transType.Algorithm = "http://www.w3.org/2000/09/xmldsig#enveloped-signature"
    '    Dim atType As TransformType() = {transType}
    '    rtype.Transforms = atType
    '    Dim dmType As DigestMethodType = New DigestMethodType()
    '    dmType.Algorithm = "http://www.w3.org/2000/09/xmldsig#sha1"
    '    rtype.DigestMethod = dmType
    '    Dim nsmgr As XmlNamespaceManager = New XmlNamespaceManager(doc.NameTable)
    '    nsmgr.AddNamespace("bk", "http://www.w3.org/2000/09/xmldsig#")
    '    Dim node = xmlDigitalSignature.SelectSingleNode("bk:SignedInfo/bk:Reference/bk:DigestValue", nsmgr)
    '    rtype.DigestValue = Convert.FromBase64String(node.InnerText)
    '    siType.Reference = rtype
    '    sin.SignedInfo = siType
    '    node = xmlDigitalSignature.SelectSingleNode("bk:SignatureValue", nsmgr)
    '    sin.SignatureValue = Convert.FromBase64String(node.InnerText)
    '    Dim kitype As KeyInfoType = New KeyInfoType()
    '    Dim x509Data As X509DataType = New X509DataType()
    '    Dim x509Issuer As X509IssuerSerialType = New X509IssuerSerialType()
    '    x509Issuer.X509IssuerName = _MiCertificado.IssuerName.Name
    '    x509Issuer.X509SerialNumber = _MiCertificado.SerialNumber
    '    x509Data.X509IssuerSerial = x509Issuer
    '    x509Data.X509Certificate = _MiCertificado.RawData
    '    kitype.Items = New Object() {x509Data}
    '    sin.KeyInfo = kitype
    '    Dim serializedData As String = String.Empty
    '    Dim serializer As XmlSerializer = New XmlSerializer(GetType(SignatureType))
    '    sw = New StringWriter()
    '    serializer.Serialize(sw, sin)
    '    serializedData = sw.ToString()
    '    Console.WriteLine(sw.ToString())
    '    Return serializedData
    'End Function

    'Public Function FirmaBouncy(ByVal dtCer As DataTable, ByVal Xml As String) As String
    '    Dim strSello As String = String.Empty
    '    Dim strError As String = String.Empty

    '    Dim boolProceso As Boolean = True
    '    Try
    '        Dim cer As X509Certificate2 = New X509Certificate2(CType(dtCer.Rows(0)(0), Byte()))
    '        Dim llave As Byte() = CType(dtCer.Rows(0)(1), Byte())
    '        Dim pass As String = dtCer.Rows(0)(2).ToString()
    '        Dim data As Stream = New MemoryStream(llave)
    '        Dim key As Org.BouncyCastle.Crypto.AsymmetricKeyParameter
    '        key = Org.BouncyCastle.Security.PrivateKeyFactory.DecryptKey(pass.ToCharArray(), data)
    '        If Not (TypeOf key Is RsaPrivateCrtKeyParameters) Then
    '            boolProceso = False
    '            strError = "La llave no pudo ser descifrada corrobore su archivo KEY y su password"
    '        End If

    '        Dim sha1 As SHA1Managed = New SHA1Managed()
    '        Dim byteMsg As Byte() = System.Text.Encoding.GetEncoding("utf-8").GetBytes(Xml)
    '        Dim hash As Byte() = sha1.ComputeHash(byteMsg)
    '        Dim signer As Org.BouncyCastle.Crypto.ISigner = Org.BouncyCastle.Security.SignerUtilities.GetSigner("SHA1WithRSA")
    '        signer.Init(True, key)
    '        signer.BlockUpdate(byteMsg, 0, byteMsg.Length)
    '        Dim sig As Byte() = signer.GenerateSignature()
    '        data.Close()
    '        data.Dispose()
    '        Dim rsa = CType(cer.PublicKey.Key, RSACryptoServiceProvider)
    '        If Not rsa.VerifyData(byteMsg, CryptoConfig.MapNameToOID("SHA1"), sig) Then
    '            boolProceso = False
    '            strError = "Archivo CER no corresponde con Archivo KEY"
    '        End If

    '        strSello = Convert.ToBase64String(sig)
    '    Catch ex As Exception
    '        boolProceso = False
    '        strError = ex.ToString().Replace("'", "")
    '    End Try

    '    If boolProceso Then
    '        Return strSello
    '    Else
    '        Return strError
    '    End If

    'End Function

    'Public Function generaXmlCancelarCfdi(ByVal DirPFX As String, ByVal sLlaveFile As String, ByVal ContrasenaClave As String, ByVal strRfcEmisor As String, ByVal UUID As String) As String
    '    Dim strResp As String = ""

    '    Dim strDigest As String = String.Empty
    '    Dim strSignature As String = String.Empty
    '    Dim strCertificado As String = String.Empty
    '    Dim strSello As String = String.Empty
    '    Try
    '        'Paso 1
    '        'Se crea el xml de cancelación

    '        Dim FileXML As String = pathActual & "CFD\" & UUID & ".xml"
    '        Dim sFecha As String = DateTime.Now.ToString("s")

    '        strDigest = "<Cancelacion xmlns=" & Chr(34) & "http://cancelacfd.sat.gob.mx" & Chr(34) & " xmlns:xsd=" & Chr(34) & "http://www.w3.org/2001/XMLSchema" & Chr(34) & " xmlns:xsi=" & Chr(34) & "http://www.w3.org/2001/XMLSchema-instance" & Chr(34) & " Fecha=" & Chr(34) & sFecha & Chr(34) & " RfcEmisor=" & Chr(34) & strRfcEmisor & Chr(34) & "><Folios><UUID>" & UUID & "</UUID></Folios></Cancelacion>"

    '        'Paso 2 Realiza el digest sha1 y base 64  
    '        'Dim str, str1 As String
    '        'str = EncryptSha1(strDigest)
    '        'str1 = encriptarSHA(strDigest)

    '        strDigest = encriptarSHA(strDigest)

    '        'Paso 3 se genera el XML que se va a firmar
    '        '4 Se crea la cadena de lo que se va a firmar

    '        Dim strXSignature As String = "<SignedInfo xmlns=" & Chr(34) & "http://www.w3.org/2000/09/xmldsig#" & Chr(34) & " xmlns:xsd=" & Chr(34) & "http://www.w3.org/2001/XMLSchema" & Chr(34) & " xmlns:xsi=" & Chr(34) & "http://www.w3.org/2001/XMLSchema-instance" & Chr(34) & ">" & "<CanonicalizationMethod Algorithm=" & Chr(34) & "http://www.w3.org/TR/2001/REC-xml-c14n-20010315" & Chr(34) & "></CanonicalizationMethod>" & "<SignatureMethod Algorithm=" & Chr(34) & "http://www.w3.org/2000/09/xmldsig#rsa-sha1" & Chr(34) & "></SignatureMethod>" & "<Reference URI=" & Chr(34) & Chr(34) & ">" & "<Transforms>" & "<Transform Algorithm=" & Chr(34) & "http://www.w3.org/2000/09/xmldsig#enveloped-signature" & Chr(34) & "></Transform>" & "</Transforms>" & "<DigestMethod Algorithm=" & Chr(34) & "http://www.w3.org/2000/09/xmldsig#sha1" & Chr(34) & "></DigestMethod>" & "<DigestValue>" + strDigest & "</DigestValue>" & "</Reference>" & "</SignedInfo>"

    '        '5 se genera la firma el Signature Sha1 con la llave y resultado base 64

    '        strSello = generarSelloDigital(strXSignature, "", UUID, sLlaveFile, ContrasenaClave, "")

    '        strSignature = "<Cancelacion xmlns=" & Chr(34) & "http://cancelacfd.sat.gob.mx" & Chr(34) & " xmlns:xsd=" & Chr(34) & "http://www.w3.org/2001/XMLSchema" & Chr(34) & " xmlns:xsi=" & Chr(34) & "http://www.w3.org/2001/XMLSchema-instance" & Chr(34) & " Fecha=" & Chr(34) & sFecha & Chr(34) & " RfcEmisor=" & Chr(34) & strRfcEmisor & Chr(34) & "><Folios><UUID>" & UUID & "</UUID></Folios><Signature xmlns=" & Chr(34) & "http://www.w3.org/2000/09/xmldsig#" & Chr(34) & "><SignedInfo><CanonicalizationMethod Algorithm=" & Chr(34) & "http://www.w3.org/TR/2001/REC-xml-c14n-20010315" & Chr(34) & "/><SignatureMethod Algorithm=" & Chr(34) & "http://www.w3.org/2000/09/xmldsig#rsa-sha1" & Chr(34) & "/><Reference URI=" & Chr(34) & Chr(34) & "><Transforms><Transform Algorithm=" & Chr(34) & "http://www.w3.org/2000/09/xmldsig#enveloped-signature" & Chr(34) & "/></Transforms><DigestMethod Algorithm=" & Chr(34) & "http://www.w3.org/2000/09/xmldsig#sha1" & Chr(34) & "/><DigestValue>" & strDigest & "</DigestValue></Reference></SignedInfo><SignatureValue>" & strSello & "</SignatureValue>"

    '        '7 Se crea el xml con el detalle del certificado.

    '        Dim cer As X509Certificate2 = New X509Certificate2(DirPFX, ContrasenaClave)
    '        Dim ki As KeyInfo = New KeyInfo()
    '        Dim clause As KeyInfoX509Data = New KeyInfoX509Data()
    '        clause.AddCertificate(cer)
    '        clause.AddIssuerSerial(cer.Issuer, cer.GetSerialNumberString())
    '        ki.AddClause(clause)
    '        Dim xX509DataExtrae As XmlElement = ki.GetXml()
    '        Dim nt As NameTable = New NameTable()
    '        Dim xmlNSmanager As XmlNamespaceManager = New XmlNamespaceManager(nt)
    '        xmlNSmanager.AddNamespace("d", "http://www.w3.org/2000/09/xmldsig#")
    '        Dim strIssuerName As String = xX509DataExtrae.SelectSingleNode("d:X509Data/d:X509IssuerSerial/d:X509IssuerName", xmlNSmanager).InnerText
    '        Dim strSerialNumber As String = xX509DataExtrae.SelectSingleNode("d:X509Data/d:X509IssuerSerial/d:X509SerialNumber", xmlNSmanager).InnerText
    '        Dim strCertificate As String = xX509DataExtrae.SelectSingleNode("d:X509Data/d:X509Certificate", xmlNSmanager).InnerText

    '        strCertificado = "<KeyInfo><X509Data><X509IssuerSerial><X509IssuerName>" & strIssuerName & "</X509IssuerName><X509SerialNumber>" & strSerialNumber & "</X509SerialNumber></X509IssuerSerial><X509Certificate>" & strCertificate & "</X509Certificate></X509Data></KeyInfo></Signature></Cancelacion>"

    '        Dim oXml As XmlDocument = New XmlDocument()

    '        strResp = strSignature & strCertificado
    '        oXml.LoadXml(strResp)
    '        oXml.Save(FileXML)
    '        strResp = oXml.InnerXml

    '    Catch ex As Exception
    '        strResp = ex.ToString()

    '    End Try

    '    Return strResp
    'End Function

    Public Function cancelarXML(ByVal dtPAC As DataTable, ByVal sFolio As String, ByVal UUID As String, ByVal eRFC As String, ByVal VersionCF As String) As Boolean
        Dim dt As DataTable
        Dim LlaveFile, CertificadoFile, ContrasenaClave, pfx As String
        Dim resultado As Boolean

        dt = ModPOS.Recupera_Tabla("sp_recupera_certificadovigente", "@COMClave", ModPOS.CompanyActual)

        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
            LlaveFile = dt.Rows(0)("Llave")
            CertificadoFile = IIf(dt.Rows(0)("urlCertificado").GetType.Name = "DBNull", "", dt.Rows(0)("urlCertificado"))
            ContrasenaClave = dt.Rows(0)("Password")
            dt.Dispose()
        Else
            MessageBox.Show("No existen certificado vigente disponible para emitir algun documento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
            Exit Function
        End If

        pfx = ModPOS.generaPFX(LlaveFile, CertificadoFile, ContrasenaClave)

        If pfx = "" Then
            Return False
            Exit Function
        End If

        Dim frmStatusMessage As New frmStatus
        frmStatusMessage.Show("Solicitado Cancelación...")
        Dim j As Integer
        For j = 0 To dtPAC.Rows.Count - 1
            If dtPAC.Rows(j)("TipoPAC") = 1 Then ' Tralix

                Dim oCfdi As New LibCFDiTralix.CFDiTralix()
                Try
                    If oCfdi.CancelarCFDi(pfx, ContrasenaClave, UUID, eRFC, dtPAC.Rows(j)("Customerkey"), dtPAC.Rows(j)("ServerCancel")) = False Then
                        If j = dtPAC.Rows.Count - 1 Then
                            MsgBox("Se tuvo el siguiente error " + vbCrLf + "[" + CType(LibCFDiTralix.CodigoMensaje.eCodigo, Integer).ToString() + "]" + LibCFDiTralix.CodigoMensaje.eCodigo.ToString() + ": " + LibCFDiTralix.CodigoMensaje.sMensaje)
                            resultado = False
                        End If
                    Else
                        resultado = True
                        Exit For
                    End If
                Catch ex As System.Net.WebException
                    If j = dtPAC.Rows.Count - 1 Then
                        MsgBox("Se tuvo el siguiente error [" & ex.Message & "]")
                        resultado = False
                    End If
                End Try
            ElseIf dtPAC.Rows(j)("TipoPAC") = 2 Then 'iTimbres
                Dim aUUID As String() = {UUID}
                Dim sResult As String
                Try
                    sResult = ModPOS.CancelarFacturaiTimbre(sFolio, eRFC, dtPAC.Rows(j)("UserId"), dtPAC.Rows(j)("CustomerKey"), aUUID, ContrasenaClave, pfx, dtPAC.Rows(j)("ServerCancel"))
                    If sResult <> "" Then
                        If j = dtPAC.Rows.Count - 1 Then
                            MsgBox(sResult)
                            resultado = False
                        End If
                    Else
                        resultado = True
                        Exit For
                    End If
                Catch ex As System.Net.WebException
                    If j = dtPAC.Rows.Count - 1 Then
                        MsgBox("Se tuvo el siguiente error [" & ex.Message & "]")
                        resultado = False
                    End If
                End Try

            ElseIf dtPAC.Rows(j)("TipoPAC") = 3 Then 'DigitalInvoice
                If VersionCF = "3.3" Then
                    Dim result As DigitalInvoiceCancelacionWS33.Acuse

                    Dim client As DigitalInvoiceCancelacionWS33.CancelacionClient = New DigitalInvoiceCancelacionWS33.CancelacionClient("BasicHttpBinding_ICancelacion1")

                    client.ClientCredentials.UserName.UserName = dtPAC.Rows(j)("UserId")
                    client.ClientCredentials.UserName.Password = dtPAC.Rows(j)("CustomerKey")

                    client.Open()
                    Try
                        Dim aUUID As String() = {UUID}

                        Dim apfx() As Byte = ModPOS.generaPFXByte(LlaveFile, CertificadoFile, ContrasenaClave)


                        result = client.Cancelar(eRFC, aUUID, apfx, ContrasenaClave)

                        If result Is Nothing Then
                            MsgBox("No se obtuvo respuesta de acuse por parte del PAC")
                        Else

                            Dim estatus As String

                            If (Not result.foliosField Is Nothing) AndAlso result.foliosField.Length = 1 Then
                                estatus = result.foliosField(0).estatusUUIDField
                            Else
                                estatus = result.codEstatusField
                            End If

                            If estatus = "201" Then
                                resultado = True
                                Exit For
                            ElseIf j = dtPAC.Rows.Count - 1 Then
                                Select Case estatus
                                    Case Is = "202"
                                        MsgBox("El comprobante ya estaba cancelado")
                                        resultado = False
                                    Case Is = "203"
                                        MsgBox("El comprobante no se pudo cancelar")
                                        resultado = False
                                    Case Is = "205"
                                        MsgBox("No existe un comprobante con el UUID especificado")
                                        resultado = False
                                    Case Is = "305"
                                        MsgBox("El UUID no se encuentra en el SAT")
                                        resultado = False
                                    Case Is = "ResultadoNoIdentificado"
                                        MsgBox("No se pudo determinar el resultado del proceso, es necesario verificar en el SAT si el proceso se efectuó con éxito.")
                                        resultado = False
                                End Select
                            End If
                        End If
                    Catch ex As Exception
                        If j = dtPAC.Rows.Count - 1 Then
                            MsgBox("Se tuvo el siguiente error [" & ex.Message & "]")
                            resultado = False
                        End If
                    End Try
                Else
                    Dim result As DigitalInvoiceCancelacionWS.Acuse

                    Dim client As DigitalInvoiceCancelacionWS.CancelacionClient = New DigitalInvoiceCancelacionWS.CancelacionClient("BasicHttpBinding_ICancelacion")

                    client.ClientCredentials.UserName.UserName = dtPAC.Rows(j)("UserId")
                    client.ClientCredentials.UserName.Password = dtPAC.Rows(j)("CustomerKey")

                    client.Open()

                    Try
                        Dim aUUID As String() = {UUID}

                        Dim apfx() As Byte = ModPOS.generaPFXByte(LlaveFile, CertificadoFile, ContrasenaClave)


                        result = client.Cancelar(eRFC, aUUID, apfx, ContrasenaClave)

                        If result Is Nothing Then
                            MsgBox("No se obtuvo respuesta de acuse por parte del PAC")
                        Else
                            If result.codEstatusField = "201" Then
                                resultado = True
                                Exit For
                            ElseIf j = dtPAC.Rows.Count - 1 Then
                                Select Case result.codEstatusField
                                    Case Is = "202"
                                        MsgBox("El comprobante ya estaba cancelado")
                                        resultado = False
                                    Case Is = "203"
                                        MsgBox("El comprobante no se pudo cancelar")
                                        resultado = False
                                    Case Is = "205"
                                        MsgBox("No existe un comprobante con el UUID especificado")
                                        resultado = False
                                    Case Is = "305"
                                        MsgBox("El UUID no se encuentra en el SAT")
                                        resultado = False
                                    Case Is = "ResultadoNoIdentificado"
                                        MsgBox("No se pudo determinar el resultado del proceso, es necesario verificar en el SAT si el proceso se efectuó con éxito.")
                                        resultado = False
                                End Select
                            End If
                        End If
                    Catch ex As Exception
                        If j = dtPAC.Rows.Count - 1 Then
                            MsgBox("Se tuvo el siguiente error [" & ex.Message & "]")
                            resultado = False
                        End If
                    End Try
                End If
            ElseIf dtPAC.Rows(j)("TipoPAC") = 4 Then 'Detecno



                If VersionCF = "3.3" Then

                    Dim xmlstring As String = String.Empty
                    Dim sError As String = String.Empty

                    If generaXmlCancelarCfdi(eRFC, UUID, CertificadoFile, LlaveFile, ContrasenaClave, xmlstring, sError) = True Then


                        Dim client As DetecnoCancelacion.CanceladorXMLClient = New DetecnoCancelacion.CanceladorXMLClient()

                        If dtPAC.Rows(j)("UserId") = "AAAAAA\wsTIMBRADOR" Then
                            client.Endpoint.Address = New System.ServiceModel.EndpointAddress("https://test.timbra.mx/WCFCancelador/CancelacionXML.svc")

                        Else
                            If dtPAC.Rows(j)("ServerTimbre") = "" Then
                                client.Endpoint.Address = New System.ServiceModel.EndpointAddress("https://www.timbra.mx/WCFCancelador/CancelacionXML.svc")
                            Else
                                client.Endpoint.Address = New System.ServiceModel.EndpointAddress(dtPAC.Rows(j)("ServerTimbre").ToString)
                            End If

                        End If

                        Dim xmlRespuesta As DetecnoCancelacion.Xml = New DetecnoCancelacion.Xml()
                        xmlRespuesta = client.CancelacionCfdiConXML(dtPAC.Rows(j)("UserId"), dtPAC.Rows(j)("CustomerKey"), eRFC, xmlstring)
                        If xmlRespuesta.Success Then
                            resultado = True
                            Exit For
                        Else
                            If j = dtPAC.Rows.Count - 1 Then
                                sError = xmlRespuesta.ErrDesc
                                MsgBox("Se tuvo el siguiente error [" & sError & "]")
                                resultado = False
                            End If
                        End If

                    Else
                        If j = dtPAC.Rows.Count - 1 Then
                            MsgBox("Se tuvo el siguiente error [" & sError & "]")
                            resultado = False
                        End If
                    End If
                Else
                    Dim client As DetecnoPAC.DetecnoPacClient = New DetecnoPAC.DetecnoPacClient()


                    If dtPAC.Rows(j)("UserId") = "AAAAAA\wsTIMBRADOR" Then
                        client.Endpoint.Address = New System.ServiceModel.EndpointAddress("https://test.timbra.mx/WCFTimbrador/DetecnoPAC.svc")
                    Else
                        If dtPAC.Rows(j)("ServerTimbre") = "" Then
                            client.Endpoint.Address = New System.ServiceModel.EndpointAddress("https://www.timbra.mx/WCFTimbrador/DetecnoPac.svc")
                        Else
                            client.Endpoint.Address = New System.ServiceModel.EndpointAddress(dtPAC.Rows(j)("ServerTimbre").ToString)
                        End If

                    End If

                    Dim xmlRespuesta As DetecnoPAC.Xml = New DetecnoPAC.Xml()
                    xmlRespuesta = client.CancelarCfdi(dtPAC.Rows(j)("UserId"), dtPAC.Rows(j)("CustomerKey"), eRFC, UUID)
                    If xmlRespuesta.Success Then
                        resultado = True
                        Exit For
                    Else
                        If j = dtPAC.Rows.Count - 1 Then
                            Dim sError As String = xmlRespuesta.ErrDesc
                            MsgBox("Se tuvo el siguiente error [" & sError & "]")
                            resultado = False
                        End If
                    End If
                End If

                End If
        Next

        frmStatusMessage.Close()

        Return resultado

    End Function

    Public Sub actualizaEdoCFD(ByVal sTipoComprobante As String, ByVal sDOCClave As String, ByVal iEstado As Integer, ByVal iTipoComprobante As Integer)
        If sTipoComprobante = "ingreso" OrElse sTipoComprobante = "I" Then
            If iTipoComprobante = 6 Then
                ModPOS.Ejecuta("sp_actualiza_edo_cargo", "@CARClave", sDOCClave, "@Estado", iEstado)
            Else
                ModPOS.Ejecuta("sp_actualiza_edo_fac", "@FACClave", sDOCClave, "@Estado", iEstado)
            End If
        Else
            ModPOS.Ejecuta("sp_actualiza_edo_nc", "@NCClave", sDOCClave, "@Estado", iEstado)
        End If
    End Sub

    Public Function soloLetras(ByVal KeyChar As Char) As Boolean
        If Char.IsDigit(KeyChar) Then
            Return False
        ElseIf Char.IsControl(KeyChar) Then
            Return False
        ElseIf Char.IsSymbol(KeyChar) Then
            Return False
        ElseIf Char.IsSeparator(KeyChar) Then
            Return False
        ElseIf Char.IsWhiteSpace(KeyChar) Then
            Return False
        ElseIf Char.IsPunctuation(KeyChar) Then
            Return False
        Else
            Return True
        End If
    End Function

    Public Function crearXMLNomina(ByVal dtPAC As DataTable, ByVal PathXML As String, ByVal sFolio As String, ByVal sDOCClave As String, ByVal sTipoComprobante As String, Optional ByVal oCFD As eCFD = Nothing, Optional ByVal dtConcepto As DataTable = Nothing, Optional ByVal dtImpuesto As DataTable = Nothing, Optional ByVal VersionNomina As Integer = 1) As Integer
        Dim numDec As Integer = 0

        Dim i As Integer
        Dim FileXML, oFileXML As String
        Dim sPre As String = ""
        Dim iTipoPAC As Integer = 0

        Dim sello As String = ""
        Dim UUID As String = ""
        Dim SelloSAT As String = ""
        Dim VersionSAT As String = ""
        Dim CertificadoSAT As String = ""
        Dim eRFC As String = ""
        Dim RFC As String = ""
        Dim RfcPAC As String = ""

        Dim fechaTimbrado As Date
        Dim total As Double

        Dim CBB() As Byte


        Dim dtConceptos As DataTable = ModPOS.Recupera_Tabla("sp_recupera_recibodet", "@RENClave", oCFD.RENClave)
        Dim dtHorasExtra As DataTable = ModPOS.Recupera_Tabla("sp_recupera_horasextra", "@RENClave", oCFD.RENClave)
        Dim dtAcciones As DataTable = ModPOS.Recupera_Tabla("sp_recupera_accion", "@RENClave", oCFD.RENClave)
        Dim dtJubilacion As DataTable = ModPOS.Recupera_Tabla("sp_recupera_jubilacion", "@RENClave", oCFD.RENClave)
        Dim dtSeparacion As DataTable = ModPOS.Recupera_Tabla("sp_recupera_separacion", "@RENClave", oCFD.RENClave)
        Dim dtCompensacion As DataTable = ModPOS.Recupera_Tabla("sp_recupera_compensacion", "@RENClave", oCFD.RENClave)


        Dim TotalPercepciones As Double = oCFD.TotalGravadoP + oCFD.TotalExentoP
        Dim TotalOtrosPagos As Double = oCFD.TotalOtrosPagos

        FileXML = pathActual & "CFD\" & sFolio & ".xml"

        Dim sTipoDeduccion, sTipoPercepcion, sTipoBanco, sTipoOtroPago As String




        'Si existe el archivo previamente lo borra
        If System.IO.File.Exists(FileXML) Then
            System.IO.File.Delete(FileXML)
        End If

        'Crea por primera vez el XML o regenerar xml

        sPre = "cfdi:"

        Dim textWriter As System.Xml.XmlTextWriter = New System.Xml.XmlTextWriter(FileXML, System.Text.Encoding.UTF8)
        textWriter.Formatting = System.Xml.Formatting.None
        ' Opens the document
        textWriter.WriteStartDocument()

        ' Write first element

        'Inicia for para llenar detalle
        Dim foundRows() As DataRow
        Dim foundRowsDet() As DataRow

        textWriter.WriteStartElement(sPre & "Comprobante")

        If oCFD.VersionCF <> "3.3" Then

          
            If VersionNomina = 1 Then
                textWriter.WriteAttributeString("xmlns:cfdi", "http://www.sat.gob.mx/cfd/3")
                textWriter.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance")
                textWriter.WriteAttributeString("xmlns:nomina", "http://www.sat.gob.mx/nomina")
                textWriter.WriteAttributeString("xsi:schemaLocation", "http://www.sat.gob.mx/cfd/3 http://www.sat.gob.mx/sitio_internet/cfd/3/cfdv32.xsd http://www.sat.gob.mx/nomina http://www.sat.gob.mx/sitio_internet/cfd/nomina/nomina11.xsd")
            ElseIf VersionNomina = 2 Then
                textWriter.WriteAttributeString("xmlns:cfdi", "http://www.sat.gob.mx/cfd/3")
                textWriter.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance")
                textWriter.WriteAttributeString("xsi:schemaLocation", "http://www.sat.gob.mx/cfd/3 http://www.sat.gob.mx/sitio_internet/cfd/3/cfdv32.xsd http://www.sat.gob.mx/nomina12 http://www.sat.gob.mx/sitio_internet/cfd/nomina/nomina12.xsd")
                ' textWriter.WriteAttributeString("xmlns:nomina12", "http://www.sat.gob.mx/nomina12")
            End If
            textWriter.WriteAttributeString("version", oCFD.VersionCF)

            If oCFD.Serie <> "" Then
                textWriter.WriteAttributeString("serie", oCFD.Serie)
            End If

            textWriter.WriteAttributeString("folio", oCFD.Folio)
            textWriter.WriteAttributeString("fecha", String.Format("{0:yyyy-MM-ddTHH:mm:ss}", oCFD.Fecha))
            textWriter.WriteAttributeString("sello", oCFD.sello)

            textWriter.WriteAttributeString("formaDePago", oCFD.formaDePago)
            textWriter.WriteAttributeString("noCertificado", oCFD.noCertificado)
            textWriter.WriteAttributeString("certificado", oCFD.Certificado64)


            If VersionNomina = 1 Then
                textWriter.WriteAttributeString("subTotal", oCFD.subtotal)
                textWriter.WriteAttributeString("descuento", QuitarCeros(oCFD.descuento))

                If oCFD.descuento > 0 Then
                    textWriter.WriteAttributeString("motivoDescuento", "Deducciones nómina")
                    textWriter.WriteAttributeString("TipoCambio", QuitarCeros(oCFD.TipoCambio))
                End If
                textWriter.WriteAttributeString("Moneda", oCFD.Moneda)
                textWriter.WriteAttributeString("total", oCFD.total)

            ElseIf VersionNomina = 2 Then
                textWriter.WriteAttributeString("subTotal", QuitarCeros(oCFD.TotalSueldos + oCFD.TotalSeparacion + oCFD.TotalJubilacion + oCFD.TotalOtrosPagos))
                textWriter.WriteAttributeString("descuento", QuitarCeros(oCFD.TotalDeducciones))
                textWriter.WriteAttributeString("Moneda", oCFD.Moneda)
                textWriter.WriteAttributeString("total", QuitarCeros(oCFD.TotalSueldos + oCFD.TotalSeparacion + oCFD.TotalJubilacion + oCFD.TotalOtrosPagos - oCFD.TotalDeducciones))
            End If

            textWriter.WriteAttributeString("tipoDeComprobante", "egreso")

            textWriter.WriteAttributeString("metodoDePago", "NA")

            If VersionNomina = 1 Then

                textWriter.WriteAttributeString("LugarExpedicion", spaceFormat(oCFD.LugarExpedicion))

                If oCFD.NumCtaPago <> "" Then
                    textWriter.WriteAttributeString("NumCtaPago", spaceFormat(oCFD.NumCtaPago))
                End If
            ElseIf VersionNomina = 2 Then

                textWriter.WriteAttributeString("LugarExpedicion", spaceFormat(oCFD.eCodigoPostal))

            End If

            textWriter.WriteStartElement(sPre & "Emisor")
            textWriter.WriteAttributeString("rfc", spaceFormat(oCFD.eRFC))
            textWriter.WriteAttributeString("nombre", spaceFormat(oCFD.eRazonSocial))

            If VersionNomina = 1 Then
                textWriter.WriteStartElement(sPre & "DomicilioFiscal")
                textWriter.WriteAttributeString("calle", spaceFormat(oCFD.eCalle))
                textWriter.WriteAttributeString("noExterior", spaceFormat(oCFD.enoExterior))

                If oCFD.benoInterior Then
                    textWriter.WriteAttributeString("noInterior", spaceFormat(oCFD.enoInterior))
                End If

                textWriter.WriteAttributeString("colonia", spaceFormat(oCFD.eColonia))
                textWriter.WriteAttributeString("localidad", IIf(oCFD.eLocalidad = "", "SIN LOCALIDAD", spaceFormat(oCFD.eLocalidad)))
                textWriter.WriteAttributeString("referencia", spaceFormat(oCFD.eReferencia))
                textWriter.WriteAttributeString("municipio", spaceFormat(oCFD.eMnpio))
                textWriter.WriteAttributeString("estado", spaceFormat(oCFD.eEntidad))
                textWriter.WriteAttributeString("pais", spaceFormat(oCFD.ePais))
                textWriter.WriteAttributeString("codigoPostal", spaceFormat(oCFD.eCodigoPostal))
                'Cierre de Domicilio
                textWriter.WriteEndElement()


                If oCFD.iTipoSucursal <> 1 Then
                    textWriter.WriteStartElement(sPre & "ExpedidoEn")
                    textWriter.WriteAttributeString("calle", spaceFormat(oCFD.sCalle))
                    textWriter.WriteAttributeString("noExterior", spaceFormat(oCFD.snoExterior))

                    If oCFD.bsnoInterior Then
                        textWriter.WriteAttributeString("noInterior", spaceFormat(oCFD.snoInterior))
                    End If

                    textWriter.WriteAttributeString("colonia", spaceFormat(oCFD.sColonia))
                    textWriter.WriteAttributeString("localidad", IIf(oCFD.sLocalidad = "", "SIN LOCALIDAD", spaceFormat(oCFD.sLocalidad)))
                    textWriter.WriteAttributeString("referencia", spaceFormat(oCFD.sReferencia))
                    textWriter.WriteAttributeString("municipio", spaceFormat(oCFD.sMnpio))
                    textWriter.WriteAttributeString("estado", spaceFormat(oCFD.sEntidad))
                    textWriter.WriteAttributeString("pais", spaceFormat(oCFD.sPais))
                    textWriter.WriteAttributeString("codigoPostal", spaceFormat(oCFD.sCodigoPostal))
                    'Cierre de centro de expedición
                    textWriter.WriteEndElement()
                End If
            End If

            textWriter.WriteStartElement(sPre & "RegimenFiscal")
            ' SI ES VERSION 2 SE INCLUYE CLAVE DEL SAT PARA EL REGIMEN FISCAL
            textWriter.WriteAttributeString("Regimen", oCFD.regimenFiscal)
            textWriter.WriteEndElement()

            'Cierre de Emisor
            textWriter.WriteEndElement()

            textWriter.WriteStartElement(sPre & "Receptor")
            textWriter.WriteAttributeString("rfc", spaceFormat(oCFD.RFC))
            textWriter.WriteAttributeString("nombre", spaceFormat(oCFD.RazonSocial))

            If VersionNomina = 1 Then
                textWriter.WriteStartElement(sPre & "Domicilio")
                textWriter.WriteAttributeString("calle", spaceFormat(oCFD.Calle))
                textWriter.WriteAttributeString("noExterior", spaceFormat(oCFD.noExterior))

                If oCFD.brnoInterior Then
                    textWriter.WriteAttributeString("noInterior", spaceFormat(oCFD.noInterior))
                End If

                textWriter.WriteAttributeString("colonia", spaceFormat(oCFD.Colonia))
                textWriter.WriteAttributeString("municipio", spaceFormat(oCFD.Mnpio))
                textWriter.WriteAttributeString("estado", spaceFormat(oCFD.Entidad))
                textWriter.WriteAttributeString("pais", spaceFormat(oCFD.Pais))
                textWriter.WriteAttributeString("codigoPostal", spaceFormat(oCFD.codigoPostal))
                'Cierre de Domicilioi
                textWriter.WriteEndElement()
            End If

            'Cierre de Receptor
            textWriter.WriteEndElement()


            textWriter.WriteStartElement(sPre & "Conceptos")

            If VersionNomina = 1 Then

                foundRows = dtConcepto.Select("RENClave = '" & oCFD.RENClave & "'")

                If foundRows.GetLength(0) > 0 Then
                    For i = 0 To foundRows.GetUpperBound(0)
                        textWriter.WriteStartElement(sPre & "Concepto")

                        textWriter.WriteAttributeString("cantidad", QuitarCeros(foundRows(i)("Cantidad")))
                        textWriter.WriteAttributeString("unidad", foundRows(i)("Unidad"))
                        textWriter.WriteAttributeString("noIdentificacion", foundRows(i)("Clave"))
                        textWriter.WriteAttributeString("descripcion", spaceFormat(CStr(foundRows(i)("Descripción")).Trim))

                        textWriter.WriteAttributeString("valorUnitario", QuitarCeros(foundRows(i)("P.U.") / oCFD.TipoCambio))
                        textWriter.WriteAttributeString("importe", QuitarCeros(foundRows(i)("Cantidad") * (foundRows(i)("P.U.") / oCFD.TipoCambio)))
                        textWriter.WriteEndElement()

                    Next

                    'Fin de ciclo
                End If

            ElseIf VersionNomina = 2 Then
                textWriter.WriteStartElement(sPre & "Concepto")
                textWriter.WriteAttributeString("cantidad", 1)
                textWriter.WriteAttributeString("unidad", "ACT")
                textWriter.WriteAttributeString("descripcion", "Pago de nómina")
                textWriter.WriteAttributeString("valorUnitario", QuitarCeros(oCFD.TotalSueldos + oCFD.TotalSeparacion + oCFD.TotalJubilacion + oCFD.TotalOtrosPagos))
                textWriter.WriteAttributeString("importe", QuitarCeros(oCFD.TotalSueldos + oCFD.TotalSeparacion + oCFD.TotalJubilacion + oCFD.TotalOtrosPagos))
                textWriter.WriteEndElement()
            End If

            'Cierre de Conceptos
            textWriter.WriteEndElement()

            ' Write one more element
            textWriter.WriteStartElement(sPre & "Impuestos")
            If VersionNomina = 1 Then
                textWriter.WriteAttributeString("totalImpuestosRetenidos", QuitarCeros(oCFD.impuestos))

                textWriter.WriteStartElement(sPre & "Retenciones")

                foundRows = dtImpuesto.Select("RENClave = '" & oCFD.RENClave & "'")

                If oCFD.impuestos = 0 Then
                    textWriter.WriteStartElement(sPre & "Retencion")
                    textWriter.WriteAttributeString("impuesto", "ISR")
                    textWriter.WriteAttributeString("importe", 0)
                    textWriter.WriteEndElement()
                Else
                    'Inicio ciclo de impuestos
                    If foundRows.GetLength(0) > 0 Then

                        For i = 0 To foundRows.GetUpperBound(0)
                            textWriter.WriteStartElement(sPre & "Retencion")
                            textWriter.WriteAttributeString("impuesto", foundRows(i)("Impuesto"))
                            textWriter.WriteAttributeString("importe", QuitarCeros(foundRows(i)("Importe") / oCFD.TipoCambio))
                            textWriter.WriteEndElement()
                        Next
                    End If
                    'fin de ciclo de impuestos
                End If


                'Cierre de Traslados
                textWriter.WriteEndElement()
            End If
            'Cierre de Impuesto
            textWriter.WriteEndElement()

        Else '3.3
            numDec = 2

            textWriter.WriteAttributeString("xmlns:cfdi", "http://www.sat.gob.mx/cfd/3")
            textWriter.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance")
            textWriter.WriteAttributeString("xsi:schemaLocation", "http://www.sat.gob.mx/cfd/3 http://www.sat.gob.mx/sitio_internet/cfd/3/cfdv33.xsd http://www.sat.gob.mx/nomina12 http://www.sat.gob.mx/sitio_internet/cfd/nomina/nomina12.xsd")
            textWriter.WriteAttributeString("Version", oCFD.VersionCF)
            If oCFD.Serie <> "" Then
                textWriter.WriteAttributeString("Serie", oCFD.Serie)
            End If
            textWriter.WriteAttributeString("Folio", oCFD.Folio)
            textWriter.WriteAttributeString("Fecha", String.Format("{0:yyyy-MM-ddTHH:mm:ss}", oCFD.Fecha))
            textWriter.WriteAttributeString("Sello", oCFD.sello)
            textWriter.WriteAttributeString("FormaPago", "99")
            textWriter.WriteAttributeString("NoCertificado", oCFD.noCertificado)
            textWriter.WriteAttributeString("Certificado", oCFD.Certificado64)


            textWriter.WriteAttributeString("SubTotal", QuitarCeros(TruncateToDecimal(oCFD.TotalSueldos + oCFD.TotalSeparacion + oCFD.TotalJubilacion + oCFD.TotalOtrosPagos, 2), numDec))
            If oCFD.TotalDeducciones > 0 Then
                textWriter.WriteAttributeString("Descuento", QuitarCeros(TruncateToDecimal(oCFD.TotalDeducciones, 2), numDec))
            End If
            textWriter.WriteAttributeString("Moneda", oCFD.Moneda)
            textWriter.WriteAttributeString("Total", QuitarCeros(TruncateToDecimal(oCFD.TotalSueldos + oCFD.TotalSeparacion + oCFD.TotalJubilacion + oCFD.TotalOtrosPagos - oCFD.TotalDeducciones, 2), numDec))
            textWriter.WriteAttributeString("TipoDeComprobante", "N")
            textWriter.WriteAttributeString("MetodoPago", "PUE")
            textWriter.WriteAttributeString("LugarExpedicion", spaceFormat(oCFD.sCodigoPostal))

            textWriter.WriteStartElement(sPre & "Emisor")
            textWriter.WriteAttributeString("Rfc", spaceFormat(oCFD.eRFC))
            textWriter.WriteAttributeString("Nombre", spaceFormat(oCFD.eRazonSocial))
            textWriter.WriteAttributeString("RegimenFiscal", spaceFormat(oCFD.regimenFiscal))
            'Cierre de Emisor
            textWriter.WriteEndElement()

            textWriter.WriteStartElement(sPre & "Receptor")
            textWriter.WriteAttributeString("Rfc", spaceFormat(oCFD.RFC))
            textWriter.WriteAttributeString("Nombre", spaceFormat(oCFD.RazonSocial))
            textWriter.WriteAttributeString("UsoCFDI", "P01")
            'Cierre de Receptor
            textWriter.WriteEndElement()

            textWriter.WriteStartElement(sPre & "Conceptos")
            textWriter.WriteStartElement(sPre & "Concepto")
            textWriter.WriteAttributeString("ClaveProdServ", "84111505")
            textWriter.WriteAttributeString("Cantidad", 1)
            textWriter.WriteAttributeString("ClaveUnidad", "ACT")
            textWriter.WriteAttributeString("Descripcion", "Pago de nómina")
            textWriter.WriteAttributeString("ValorUnitario", QuitarCeros(TruncateToDecimal(oCFD.TotalSueldos + oCFD.TotalSeparacion + oCFD.TotalJubilacion + oCFD.TotalOtrosPagos, 2), numDec))
            textWriter.WriteAttributeString("Importe", QuitarCeros(TruncateToDecimal(oCFD.TotalSueldos + oCFD.TotalSeparacion + oCFD.TotalJubilacion + oCFD.TotalOtrosPagos, 2), numDec))
            If oCFD.TotalDeducciones > 0 Then
                textWriter.WriteAttributeString("Descuento", QuitarCeros(TruncateToDecimal(oCFD.TotalDeducciones, 2), numDec))
            End If
            textWriter.WriteEndElement()
            'Cierre concepto
            textWriter.WriteEndElement()

            End If

            'Complemento Nomina
            textWriter.WriteStartElement(sPre & "Complemento")

            If VersionNomina = 1 Then
                textWriter.WriteStartElement("nomina:" & "Nomina")
                textWriter.WriteAttributeString("Version", "1.1")

                If oCFD.RegistroPatronal <> "" AndAlso (oCFD.TipoRegimen = "02" OrElse oCFD.TipoRegimen = "03" OrElse oCFD.TipoRegimen = "04") Then
                    textWriter.WriteAttributeString("RegistroPatronal", oCFD.RegistroPatronal)
                End If

                textWriter.WriteAttributeString("NumEmpleado", oCFD.NumEmpleado)
                textWriter.WriteAttributeString("CURP", oCFD.CURP)
                textWriter.WriteAttributeString("TipoRegimen", oCFD.TipoRegimen)

                If oCFD.NumSeguridadSocial <> "" Then
                    textWriter.WriteAttributeString("NumSeguridadSocial", oCFD.NumSeguridadSocial)
                End If
                textWriter.WriteAttributeString("FechaPago", String.Format("{0:yyyy-MM-dd}", oCFD.FechaPago))
                textWriter.WriteAttributeString("FechaInicialPago", String.Format("{0:yyyy-MM-dd}", oCFD.FechaInicialPago))
                textWriter.WriteAttributeString("FechaFinalPago", String.Format("{0:yyyy-MM-dd}", oCFD.FechaFinalPago))
                textWriter.WriteAttributeString("NumDiasPagados", oCFD.NumDiasPagados)

                If oCFD.Departamento <> "" Then
                    textWriter.WriteAttributeString("Departamento", oCFD.Departamento)
                End If

                If CInt(oCFD.metodoDePago) = 5 OrElse CInt(oCFD.metodoDePago) = 6 Then
                    textWriter.WriteAttributeString("CLABE", oCFD.NumCtaPago)

                    sTipoBanco = "00" & CStr(oCFD.Banco)
                    textWriter.WriteAttributeString("Banco", sTipoBanco.Substring(sTipoBanco.Length - 3, 3))
                End If

                textWriter.WriteAttributeString("FechaInicioRelLaboral", oCFD.FechaInicioRelLaboral)

                If oCFD.Puesto <> "" Then
                    textWriter.WriteAttributeString("Puesto", oCFD.Puesto)
                End If

                If oCFD.TipoContrato <> "" Then
                    textWriter.WriteAttributeString("TipoContrato", oCFD.TipoContrato)
                End If

                If oCFD.TipoJornada <> "" Then
                    textWriter.WriteAttributeString("TipoJornada", oCFD.TipoJornada)
                End If

                textWriter.WriteAttributeString("PeriodicidadPago", oCFD.PeriodicidadPago)

                If oCFD.SalarioBaseCotApor > 0 Then
                    textWriter.WriteAttributeString("SalarioBaseCotApor", QuitarCeros(oCFD.SalarioBaseCotApor))
                End If

                If oCFD.RiesgoPuesto > 0 Then
                    textWriter.WriteAttributeString("RiesgoPuesto", oCFD.RiesgoPuesto)
                End If

                If oCFD.SalarioDiarioIntegrado > 0 Then
                    textWriter.WriteAttributeString("SalarioDiarioIntegrado", QuitarCeros(oCFD.SalarioDiarioIntegrado))
                End If
            Else
                textWriter.WriteStartElement("nomina12:" & "Nomina")
                'If oCFD.VersionCF = "3.3" Then
                '    textWriter.WriteAttributeString("xmlns:xsd", "http://www.w3.org/2001/XMLSchema")
                '    textWriter.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance")
                'End If

                textWriter.WriteAttributeString("xmlns:nomina12", "http://www.sat.gob.mx/nomina12")

                textWriter.WriteAttributeString("Version", "1.2")


                textWriter.WriteAttributeString("TipoNomina", oCFD.TipoNomina)

                textWriter.WriteAttributeString("FechaPago", String.Format("{0:yyyy-MM-dd}", oCFD.FechaPago))
                textWriter.WriteAttributeString("FechaInicialPago", String.Format("{0:yyyy-MM-dd}", oCFD.FechaInicialPago))
                textWriter.WriteAttributeString("FechaFinalPago", String.Format("{0:yyyy-MM-dd}", oCFD.FechaFinalPago))
                textWriter.WriteAttributeString("NumDiasPagados", IIf(oCFD.VersionCF = "3.3", QuitarCeros(oCFD.NumDiasPagados, 3), QuitarCeros(oCFD.NumDiasPagados)))

                If TotalPercepciones > 0 Then
                    textWriter.WriteAttributeString("TotalPercepciones", QuitarCeros(TruncateToDecimal(oCFD.TotalSueldos + oCFD.TotalSeparacion + oCFD.TotalJubilacion, 2), numDec))
                End If

                If oCFD.TotalDeducciones > 0 Then
                    textWriter.WriteAttributeString("TotalDeducciones", QuitarCeros(TruncateToDecimal(oCFD.TotalDeducciones, 2), numDec))
                End If

                If oCFD.TotalOtrosPagos > 0 Then
                    textWriter.WriteAttributeString("TotalOtrosPagos", QuitarCeros(TruncateToDecimal(oCFD.TotalOtrosPagos, 2), numDec))
                End If

                textWriter.WriteStartElement("nomina12:" & "Emisor")

                If oCFD.eCURP <> "" Then
                    textWriter.WriteAttributeString("Curp", oCFD.eCURP)
                End If

                If Not (oCFD.TipoContrato = "09" OrElse oCFD.TipoContrato = "10" OrElse oCFD.TipoContrato = "99") Then
                    textWriter.WriteAttributeString("RegistroPatronal", oCFD.RegistroPatronal)
                End If
                textWriter.WriteEndElement()

                textWriter.WriteStartElement("nomina12:" & "Receptor")
                textWriter.WriteAttributeString("Curp", oCFD.CURP)
                If oCFD.RegistroPatronal <> "" Then
                    textWriter.WriteAttributeString("NumSeguridadSocial", oCFD.NumSeguridadSocial)
                    textWriter.WriteAttributeString("FechaInicioRelLaboral", String.Format("{0:yyyy-MM-dd}", oCFD.FechaInicioRelLaboral))
                    textWriter.WriteAttributeString("Antigüedad", oCFD.Antiguedad)

                End If
                textWriter.WriteAttributeString("TipoContrato", oCFD.TipoContrato)
                textWriter.WriteAttributeString("Sindicalizado", IIf(oCFD.Sindicalizado = 1, "Sí", "No"))
                textWriter.WriteAttributeString("TipoJornada", oCFD.TipoJornada)
                textWriter.WriteAttributeString("TipoRegimen", oCFD.TipoRegimen)
                textWriter.WriteAttributeString("NumEmpleado", oCFD.NumEmpleado)
                If oCFD.Departamento <> "" Then
                    textWriter.WriteAttributeString("Departamento", oCFD.Departamento)
                End If
                If oCFD.Puesto <> "" Then
                    textWriter.WriteAttributeString("Puesto", oCFD.Puesto)
                End If


                If oCFD.TipoRegimen <> "11" AndAlso oCFD.RiesgoPuesto > 0 AndAlso oCFD.RegistroPatronal <> "" Then
                    If oCFD.NumSeguridadSocial <> "" Then
                        textWriter.WriteAttributeString("RiesgoPuesto", oCFD.RiesgoPuesto)
                    Else
                        textWriter.WriteAttributeString("RiesgoPuesto", "99")
                    End If
                End If


                textWriter.WriteAttributeString("PeriodicidadPago", oCFD.PeriodicidadPago)

                If CInt(oCFD.metodoDePago) = 5 OrElse CInt(oCFD.metodoDePago) = 6 Then
                    sTipoBanco = "00" & CStr(oCFD.Banco)
                    textWriter.WriteAttributeString("Banco", sTipoBanco.Substring(sTipoBanco.Length - 3, 3))
                    textWriter.WriteAttributeString("CuentaBancaria", oCFD.NumCtaPago)
                End If

                If oCFD.SalarioBaseCotApor > 0 Then
                    textWriter.WriteAttributeString("SalarioBaseCotApor", QuitarCeros(oCFD.SalarioBaseCotApor, numDec))
                End If

                If oCFD.SalarioDiarioIntegrado > 0 AndAlso oCFD.RegistroPatronal <> "" Then
                    textWriter.WriteAttributeString("SalarioDiarioIntegrado", QuitarCeros(oCFD.SalarioDiarioIntegrado, numDec))
                End If

                textWriter.WriteAttributeString("ClaveEntFed", oCFD.ClaveEntFed)

                textWriter.WriteEndElement()

            End If


            foundRows = dtConceptos.Select("Tipo = 1")

            If foundRows.GetLength(0) > 0 Then


                ' Percepciones  
                If VersionNomina = 1 Then
                    textWriter.WriteStartElement("nomina:" & "Percepciones")
                    textWriter.WriteAttributeString("TotalGravado", QuitarCeros(oCFD.TotalGravadoP, numDec))
                    textWriter.WriteAttributeString("TotalExento", QuitarCeros(oCFD.TotalExentoP, numDec))

                    For i = 0 To foundRows.GetUpperBound(0)
                        textWriter.WriteStartElement("nomina:" & "Percepcion")

                        sTipoPercepcion = "00" & CStr(foundRows(i)("TipoConcepto"))
                        sTipoPercepcion = sTipoPercepcion.Substring(sTipoPercepcion.Length - 3, 3)

                        textWriter.WriteAttributeString("TipoPercepcion", sTipoPercepcion)
                        textWriter.WriteAttributeString("Clave", foundRows(i)("Clave"))
                        textWriter.WriteAttributeString("Concepto", foundRows(i)("Concepto"))
                        textWriter.WriteAttributeString("ImporteGravado", QuitarCeros(foundRows(i)("ImporteGravado") / oCFD.TipoCambio), numDec)
                        textWriter.WriteAttributeString("ImporteExento", QuitarCeros(foundRows(i)("ImporteExento") / oCFD.TipoCambio), numDec)
                        textWriter.WriteEndElement()
                    Next
                    'Cierre de Percepciones
                    textWriter.WriteEndElement()

                ElseIf VersionNomina = 2 Then


                    textWriter.WriteStartElement("nomina12:" & "Percepciones")
                    textWriter.WriteAttributeString("TotalSueldos", QuitarCeros(oCFD.TotalSueldos, numDec))
                    If oCFD.TotalSeparacion > 0 Then
                        textWriter.WriteAttributeString("TotalSeparacionIndemnizacion", QuitarCeros(oCFD.TotalSeparacion, numDec))
                    End If
                    If oCFD.TotalJubilacion > 0 Then
                        textWriter.WriteAttributeString("TotalJubilacionPensionRetiro", QuitarCeros(oCFD.TotalJubilacion, numDec))
                    End If
                    textWriter.WriteAttributeString("TotalGravado", QuitarCeros(oCFD.TotalGravadoP, numDec))
                    textWriter.WriteAttributeString("TotalExento", QuitarCeros(oCFD.TotalExentoP, numDec))



                    For i = 0 To foundRows.GetUpperBound(0)
                        textWriter.WriteStartElement("nomina12:" & "Percepcion")
                        sTipoPercepcion = "00" & CStr(foundRows(i)("TipoConcepto"))
                        sTipoPercepcion = sTipoPercepcion.Substring(sTipoPercepcion.Length - 3, 3)
                        textWriter.WriteAttributeString("TipoPercepcion", sTipoPercepcion)
                        textWriter.WriteAttributeString("Clave", foundRows(i)("Clave"))
                        textWriter.WriteAttributeString("Concepto", foundRows(i)("Concepto"))
                        textWriter.WriteAttributeString("ImporteGravado", QuitarCeros(foundRows(i)("ImporteGravado"), numDec))
                        textWriter.WriteAttributeString("ImporteExento", QuitarCeros(foundRows(i)("ImporteExento"), numDec))
                        textWriter.WriteEndElement()
                    Next


                    Dim foundRowsPercepcion() As DataRow



                    'jubilacionPencion
                    foundRowsPercepcion = dtConceptos.Select("Tipo = 1 and TipoConcepto= 39 ")
                    If foundRowsPercepcion.GetLength(0) > 0 Then
                        foundRowsDet = dtJubilacion.Select("CONClave = '" & foundRowsPercepcion(0)("CONClave") & "'")
                        If foundRowsDet.GetLength(0) > 0 Then
                            textWriter.WriteStartElement("nomina12:" & "JubilacionPensionRetiro")
                            textWriter.WriteAttributeString("TotalUnaExhibicion", QuitarCeros(foundRowsDet(0)("Importe"), numDec))
                            textWriter.WriteAttributeString("IngresoAcumulable", QuitarCeros(foundRowsDet(0)("IngresoAcumulable"), numDec))
                            textWriter.WriteAttributeString("IngresoNoAcumulable", QuitarCeros(foundRowsDet(0)("IngresoNoAcumulable"), numDec))
                            textWriter.WriteEndElement()
                        End If
                    End If


                    'jubilacionPencion
                    foundRowsPercepcion = dtConceptos.Select("Tipo = 1 and TipoConcepto= 44 ")
                    If foundRowsPercepcion.GetLength(0) > 0 Then
                        foundRowsDet = dtJubilacion.Select("CONClave = '" & foundRowsPercepcion(0)("CONClave") & "'")
                        If foundRowsDet.GetLength(0) > 0 Then
                            textWriter.WriteStartElement("nomina12:" & "JubilacionPensionRetiro")
                            textWriter.WriteAttributeString("TotalParcialidad", QuitarCeros(foundRowsDet(0)("Importe"), numDec))
                            textWriter.WriteAttributeString("MontoDiario", QuitarCeros(foundRowsDet(0)("MontoDiario"), numDec))
                            textWriter.WriteAttributeString("IngresoAcumulable", QuitarCeros(foundRowsDet(0)("IngresoAcumulable"), numDec))
                            textWriter.WriteAttributeString("IngresoNoAcumulable", QuitarCeros(foundRowsDet(0)("IngresoNoAcumulable"), numDec))
                            textWriter.WriteEndElement()
                        End If
                    End If


                    'Separacionindenmizacion
                    foundRowsPercepcion = dtConceptos.Select("Tipo = 1 and TipoConcepto= 22 ")
                    If foundRowsPercepcion.GetLength(0) > 0 Then
                        foundRowsDet = dtSeparacion.Select("CONClave = '" & foundRowsPercepcion(0)("CONClave") & "'")
                        If foundRowsDet.GetLength(0) > 0 Then
                            textWriter.WriteStartElement("nomina12:" & "SeparacionIndemnizacion")
                            textWriter.WriteAttributeString("TotalPagado", QuitarCeros(foundRowsDet(0)("TotalPagado"), numDec))
                            textWriter.WriteAttributeString("NumAñosServicio", foundRowsDet(0)("AñosServicio"))
                            textWriter.WriteAttributeString("UltimoSueldoMensOrd", QuitarCeros(foundRowsDet(0)("UltimoSueldo"), numDec))
                            textWriter.WriteAttributeString("IngresoAcumulable", QuitarCeros(foundRowsDet(0)("IngresoAcumulable"), numDec))
                            textWriter.WriteAttributeString("IngresoNoAcumulable", QuitarCeros(foundRowsDet(0)("IngresoNoAcumulable"), numDec))
                            textWriter.WriteEndElement()
                        End If

                    End If


                    'Separacionindenmizacion
                    foundRowsPercepcion = dtConceptos.Select("Tipo = 1 and TipoConcepto= 23 ")
                    If foundRowsPercepcion.GetLength(0) > 0 Then
                        foundRowsDet = dtSeparacion.Select("CONClave = '" & foundRowsPercepcion(0)("CONClave") & "'")
                        If foundRowsDet.GetLength(0) > 0 Then
                            textWriter.WriteStartElement("nomina12:" & "SeparacionIndemnizacion")
                            textWriter.WriteAttributeString("TotalPagado", QuitarCeros(foundRowsDet(0)("TotalPagado"), numDec))
                            textWriter.WriteAttributeString("NumAñosServicio", foundRowsDet(0)("AñosServicio"))
                            textWriter.WriteAttributeString("UltimoSueldoMensOrd", QuitarCeros(foundRowsDet(0)("UltimoSueldo"), numDec))
                            textWriter.WriteAttributeString("IngresoAcumulable", QuitarCeros(foundRowsDet(0)("IngresoAcumulable"), numDec))
                            textWriter.WriteAttributeString("IngresoNoAcumulable", QuitarCeros(foundRowsDet(0)("IngresoNoAcumulable"), numDec))
                            textWriter.WriteEndElement()
                        End If

                    End If

                    'Separacionindenmizacion
                    foundRowsPercepcion = dtConceptos.Select("Tipo = 1 and TipoConcepto= 25 ")
                    If foundRowsPercepcion.GetLength(0) > 0 Then
                        foundRowsDet = dtSeparacion.Select("CONClave = '" & foundRowsPercepcion(0)("CONClave") & "'")
                        If foundRowsDet.GetLength(0) > 0 Then
                            textWriter.WriteStartElement("nomina12:" & "SeparacionIndemnizacion")
                            textWriter.WriteAttributeString("TotalPagado", QuitarCeros(foundRowsDet(0)("TotalPagado"), numDec))
                            textWriter.WriteAttributeString("NumAñosServicio", foundRowsDet(0)("AñosServicio"))
                            textWriter.WriteAttributeString("UltimoSueldoMensOrd", QuitarCeros(foundRowsDet(0)("UltimoSueldo"), numDec))
                            textWriter.WriteAttributeString("IngresoAcumulable", QuitarCeros(foundRowsDet(0)("IngresoAcumulable"), numDec))
                            textWriter.WriteAttributeString("IngresoNoAcumulable", QuitarCeros(foundRowsDet(0)("IngresoNoAcumulable"), numDec))
                            textWriter.WriteEndElement()
                        End If

                    End If

                    'AccionesOTitulos
                    foundRowsPercepcion = dtConceptos.Select("Tipo = 1 and TipoConcepto= 45 ")
                    If foundRowsPercepcion.GetLength(0) > 0 Then
                        foundRowsDet = dtAcciones.Select("CONClave = '" & foundRowsPercepcion(0)("CONClave") & "'")
                        If foundRowsDet.GetLength(0) > 0 Then
                            textWriter.WriteStartElement("nomina12:" & "AccionesOTitulos")
                            textWriter.WriteAttributeString("ValorMercado", QuitarCeros(foundRowsDet(0)("ValorMercado"), numDec))
                            textWriter.WriteAttributeString("PrecioAlOtorgante", QuitarCeros(foundRowsDet(0)("PrecioAlOtorgante"), numDec))
                            textWriter.WriteEndElement()
                        End If
                    End If

                    'HoraExtra
                    foundRowsPercepcion = dtConceptos.Select("Tipo = 1 and TipoConcepto= 19 ")
                    If foundRowsPercepcion.GetLength(0) > 0 Then

                        foundRowsDet = dtHorasExtra.Select("CONClave = '" & foundRowsPercepcion(0)("CONClave") & "'")
                        If foundRowsDet.GetLength(0) > 0 Then
                            Dim j As Integer

                            For j = 0 To foundRowsDet.GetUpperBound(0)
                                textWriter.WriteStartElement("nomina12:" & "HorasExtra")
                                textWriter.WriteAttributeString("Dias", foundRowsDet(j)("Dias"))
                                textWriter.WriteAttributeString("TipoHoras", foundRowsDet(j)("Tipo"))
                                textWriter.WriteAttributeString("HorasExtra", foundRowsDet(j)("HorasExtra"))
                                textWriter.WriteAttributeString("ImportePagado", QuitarCeros(foundRowsDet(j)("ImportePagado"), numDec))
                                textWriter.WriteEndElement()
                            Next
                        End If
                    End If

                    'Cierre de Percepciones
                    textWriter.WriteEndElement()

                End If

            End If
            ' Horas Extra
            If VersionNomina = 1 Then
                If dtHorasExtra.Rows.Count() > 0 Then

                    textWriter.WriteStartElement("nomina:" & "HorasExtras")
                    For i = 0 To dtHorasExtra.Rows.Count() - 1
                        textWriter.WriteStartElement("nomina:" & "HorasExtra")
                        textWriter.WriteAttributeString("Dias", dtHorasExtra.Rows(i)("Dias"))
                        textWriter.WriteAttributeString("TipoHoras", dtHorasExtra.Rows(i)("Tipo"))
                        textWriter.WriteAttributeString("HorasExtra", dtHorasExtra.Rows(i)("HorasExtra"))
                        textWriter.WriteAttributeString("ImportePagado", QuitarCeros(dtHorasExtra.Rows(i)("ImportePagado"), numDec))
                        textWriter.WriteEndElement()
                    Next
                    textWriter.WriteEndElement()

                End If
            End If

            dtHorasExtra.Dispose()
            dtAcciones.Dispose()
            dtJubilacion.Dispose()
            dtSeparacion.Dispose()



            foundRows = dtConceptos.Select("Tipo = 2")


            If foundRows.GetLength(0) > 0 Then
                ' Deducciones  

                If VersionNomina = 1 Then
                    textWriter.WriteStartElement("nomina:" & "Deducciones")
                    textWriter.WriteAttributeString("TotalGravado", QuitarCeros(oCFD.TotalDeducciones), numDec)
                    textWriter.WriteAttributeString("TotalExento", QuitarCeros(0, numDec))


                    For i = 0 To foundRows.GetUpperBound(0)
                        textWriter.WriteStartElement("nomina:" & "Deduccion")
                        sTipoDeduccion = "00" & CStr(foundRows(i)("TipoConcepto"))
                        sTipoDeduccion = sTipoDeduccion.Substring(sTipoDeduccion.Length - 3, 3)
                        textWriter.WriteAttributeString("TipoDeduccion", sTipoDeduccion)
                        textWriter.WriteAttributeString("Clave", foundRows(i)("Clave"))
                        textWriter.WriteAttributeString("Concepto", foundRows(i)("Concepto"))
                        textWriter.WriteAttributeString("ImporteGravado", QuitarCeros(foundRows(i)("ImporteGravado") / oCFD.TipoCambio, numDec))
                        textWriter.WriteAttributeString("ImporteExento", QuitarCeros(foundRows(i)("ImporteExento") / oCFD.TipoCambio, numDec))
                        textWriter.WriteEndElement()
                    Next

                    'Cierre de Deducciones
                    textWriter.WriteEndElement()
                ElseIf VersionNomina = 2 Then
                    textWriter.WriteStartElement("nomina12:" & "Deducciones")
                    If (oCFD.TotalDeducciones - oCFD.ISR) > 0 Then
                        textWriter.WriteAttributeString("TotalOtrasDeducciones", QuitarCeros(oCFD.TotalDeducciones - oCFD.ISR, numDec))
                    End If

                    If oCFD.ISR > 0 Then
                        textWriter.WriteAttributeString("TotalImpuestosRetenidos", QuitarCeros(oCFD.ISR, numDec))
                    End If

                    For i = 0 To foundRows.GetUpperBound(0)
                        textWriter.WriteStartElement("nomina12:" & "Deduccion")
                        sTipoDeduccion = "00" & CStr(foundRows(i)("TipoConcepto"))
                        textWriter.WriteAttributeString("TipoDeduccion", sTipoDeduccion.Substring(sTipoDeduccion.Length - 3, 3))
                        textWriter.WriteAttributeString("Clave", foundRows(i)("Clave"))
                        textWriter.WriteAttributeString("Concepto", foundRows(i)("Concepto"))
                        textWriter.WriteAttributeString("Importe", QuitarCeros(foundRows(i)("ImporteGravado"), numDec))
                        textWriter.WriteEndElement()
                    Next

                    'Cierre de Deducciones
                    textWriter.WriteEndElement()

                End If
            End If


            Dim dtIncapacidad As DataTable = ModPOS.Recupera_Tabla("sp_recupera_incapacidad", "@RENClave", oCFD.RENClave)
            ' Incapacidades


            If dtIncapacidad.Rows.Count() > 0 Then
                If VersionNomina = 1 Then
                    textWriter.WriteStartElement("nomina:" & "Incapacidades")

                    For i = 0 To dtIncapacidad.Rows.Count() - 1
                        textWriter.WriteStartElement("nomina:" & "Incapacidad")
                        textWriter.WriteAttributeString("DiasIncapacidad", dtIncapacidad.Rows(i)("Dias"))
                        textWriter.WriteAttributeString("TipoIncapacidad", dtIncapacidad.Rows(i)("TipoIncapacidad"))
                        textWriter.WriteAttributeString("Descuento", QuitarCeros(dtIncapacidad.Rows(i)("Descuento"), numDec))
                        textWriter.WriteEndElement()
                    Next
                    textWriter.WriteEndElement()
                ElseIf VersionNomina = 2 Then
                    textWriter.WriteStartElement("nomina12:" & "Incapacidades")

                    For i = 0 To dtIncapacidad.Rows.Count() - 1
                        textWriter.WriteStartElement("nomina12:" & "Incapacidad")
                        textWriter.WriteAttributeString("DiasIncapacidad", dtIncapacidad.Rows(i)("Dias"))
                        textWriter.WriteAttributeString("TipoIncapacidad", dtIncapacidad.Rows(i)("TipoIncapacidad"))
                        textWriter.WriteAttributeString("ImporteMonetario", QuitarCeros(dtIncapacidad.Rows(i)("Descuento"), numDec))
                        textWriter.WriteEndElement()
                    Next
                    textWriter.WriteEndElement()

                End If
            End If
            dtIncapacidad.Dispose()


            If VersionNomina = 2 Then
                foundRows = dtConceptos.Select("Tipo = 3")


                If foundRows.GetLength(0) > 0 Then
                    ' Otros Pagos  

                    textWriter.WriteStartElement("nomina12:" & "OtrosPagos")

                    For i = 0 To foundRows.GetUpperBound(0)
                        textWriter.WriteStartElement("nomina12:" & "OtroPago")
                        sTipoOtroPago = "00" & CStr(foundRows(i)("TipoConcepto"))
                        sTipoOtroPago = sTipoOtroPago.Substring(sTipoOtroPago.Length - 3, 3)
                        textWriter.WriteAttributeString("TipoOtroPago", sTipoOtroPago)
                        textWriter.WriteAttributeString("Clave", foundRows(i)("Clave"))
                        textWriter.WriteAttributeString("Concepto", foundRows(i)("Concepto"))
                        textWriter.WriteAttributeString("Importe", QuitarCeros(foundRows(i)("ImporteGravado"), numDec))

                        Select Case sTipoOtroPago
                            Case Is = "002"

                                textWriter.WriteStartElement("nomina12:" & "SubsidioAlEmpleo")
                                textWriter.WriteAttributeString("SubsidioCausado", QuitarCeros(foundRows(i)("ImporteGravado"), numDec))
                                textWriter.WriteEndElement()

                            Case Is = "004"
                                foundRowsDet = dtCompensacion.Select("CONClave = '" & foundRows(i)("CONClave") & "'")
                                If foundRowsDet.GetLength(0) > 0 Then
                                    textWriter.WriteStartElement("nomina12:" & "CompensacionSaldoFavor")
                                    textWriter.WriteAttributeString("SaldoFavor", QuitarCeros(foundRowsDet(0)("SaldoFavor"), numDec))
                                    textWriter.WriteAttributeString("Año", foundRowsDet(0)("Año"))
                                    textWriter.WriteAttributeString("RemanenteSalFav", QuitarCeros(foundRowsDet(0)("Remanente"), numDec))
                                    textWriter.WriteEndElement()
                                End If
                        End Select



                        textWriter.WriteEndElement()
                    Next

                    'Cierre de OtrosPagos
                    textWriter.WriteEndElement()


                End If
            End If

            dtConceptos.Dispose()

            'Cierre de Nomina
            textWriter.WriteEndElement()

            'Cierre de Complemento
            textWriter.WriteEndElement()

            'Cierre de Comprobante
            textWriter.WriteEndElement()
            ' Ends the document.
            textWriter.WriteEndDocument()
            ' close writer
            textWriter.Close()


            eRFC = oCFD.eRFC
            RFC = oCFD.RFC
            total = oCFD.total
            sello = oCFD.sello


            Dim oXml As New XmlDocument()
            oXml.Load(FileXML)

            Dim frmStatusMessage As New frmStatus

            For i = 0 To dtPAC.Rows.Count - 1


                If dtPAC.Rows(i)("TipoPAC") = 1 Then ' Tralix

                    frmStatusMessage.Show("Solicitado Timbre Fiscal...Tralix")
                    frmStatusMessage.BringToFront()

                    Dim oCfdi As New LibCFDiTralix.CFDiTralix()

                    Dim oTimbre As LibCFDiTralix.com.tralix.pac.TimbreFiscalDigital

                    'https://pruebastfd.tralix.com:7070
                    Try
                        oTimbre = oCfdi.TimbrarCFDi(oXml.OuterXml, dtPAC.Rows(i)("ServerTimbre"), dtPAC.Rows(i)("Customerkey"))

                        If oTimbre Is Nothing AndAlso i = dtPAC.Rows.Count - 1 Then
                            '  actualizaEdoCFD(sTipoComprobante, sDOCClave, 2)
                            MsgBox("Se tuvo el siguiente error " + vbCrLf + "[" + CType(LibCFDiTralix.CodigoMensaje.eCodigo, Integer).ToString() + "]" + LibCFDiTralix.CodigoMensaje.eCodigo.ToString() + ": " + LibCFDiTralix.CodigoMensaje.sMensaje)
                            UUID = "NO_VALIDO_FOLIO_FISCAL"
                            SelloSAT = "NO_VALIDO_TIMBRE_FISCAL"
                            iTipoPAC = 0
                            fechaTimbrado = Date.Now
                        ElseIf Not oTimbre Is Nothing Then
                            UUID = oTimbre.UUID
                            SelloSAT = oTimbre.selloSAT
                            CertificadoSAT = oTimbre.noCertificadoSAT
                            fechaTimbrado = oTimbre.FechaTimbrado
                            VersionSAT = oTimbre.version
                            iTipoPAC = 1
                            ' actualizaEdoCFD(sTipoComprobante, sDOCClave, 1)
                            ModPOS.Ejecuta("sp_actualiza_timbre", "@CustomerKey", dtPAC.Rows(i)("CustomerKey"), "@TipoPAC", iTipoPAC)
                            Exit For
                        End If

                    Catch ex As System.Net.WebException
                        MsgBox("Se tuvo el siguiente error [" & ex.Message & ", verfique su conexión] ")
                        UUID = "NO_VALIDO_FOLIO_FISCAL"
                        SelloSAT = "NO_VALIDO_TIMBRE_FISCAL"
                        iTipoPAC = 0
                        fechaTimbrado = Date.Now
                    End Try
                ElseIf dtPAC.Rows(i)("TipoPAC") = 2 Then 'iTimbre

                    frmStatusMessage.Show("Solicitado Timbre Fiscal...iTimbre")
                    frmStatusMessage.BringToFront()

                    Dim consulta As String = ObtenerConsultaiTimbre(sFolio, eRFC, dtPAC.Rows(i)("UserId"), dtPAC.Rows(i)("CustomerKey"), FileXML)
                    Dim content As Byte() = System.Text.Encoding.UTF8.GetBytes(consulta)

                    Dim url As String = dtPAC.Rows(i)("ServerTimbre")
                    Dim peticion As System.Net.HttpWebRequest = System.Net.WebRequest.Create(url)

                    peticion.Method = "POST"
                    peticion.ContentType = "application/x-www-form-urlencoded"
                    peticion.ContentLength = content.Length

                    Try
                        Dim requestStream As System.IO.Stream = peticion.GetRequestStream()
                        requestStream.Write(content, 0, content.Length)
                        requestStream.Close()

                        Dim resp As System.Net.HttpWebResponse = peticion.GetResponse()
                        Dim respuesta As String = New System.IO.StreamReader(resp.GetResponseStream).ReadToEnd

                        Dim respJson As Object = Newtonsoft.Json.Linq.JObject.Parse(respuesta)

                        If respJson.Item("result").item("retcode").Value = 1 OrElse respJson.Item("result").item("retcode").Value = 307 Then

                            If respJson.Item("result").item("retcode").Value = 1 Then

                                UUID = respJson.Item("result").item("UUID").Value

                                Dim Elementos As String() = respJson.Item("result").item("data").ToString.Split()

                                For Each sElementos As String In Elementos
                                    If sElementos.Contains("FechaTimbrado=") Then
                                        fechaTimbrado = sElementos.Replace("FechaTimbrado=", "").Replace("""", "")
                                    End If
                                    If sElementos.Contains("noCertificadoSAT=") Then
                                        CertificadoSAT = sElementos.Replace("noCertificadoSAT=", "").Replace("""", "")
                                    End If
                                    'If sElementos.Contains("selloCFD=") Then
                                    '    oCFD.selloCFD = sElementos.Replace("selloCFD=", "").Replace("""", "")
                                    'End If
                                    If sElementos.Contains("selloSAT=") Then
                                        SelloSAT = sElementos.Replace("selloSAT=", "").Replace("""", "")
                                    End If
                                    If sElementos.Contains("version=") Then
                                        VersionSAT = sElementos.Replace("version=", "").Replace("""", "")
                                    End If
                                Next
                                iTipoPAC = 2
                                'actualizaEdoCFD(sTipoComprobante, sDOCClave, 1)
                                ModPOS.Ejecuta("sp_actualiza_timbre", "@CustomerKey", dtPAC.Rows(i)("CustomerKey"), "@TipoPAC", iTipoPAC)
                                Exit For

                            Else
                                frmStatusMessage.Show(respJson.Item("result").Item("error").Value.ToString() & ", Espere, lo estamos recuperando...iTimbre")

                                ' Si ya fue timbrado entonces
                                Dim indice As Integer = respJson.Item("result").Item("error").Value.ToString().IndexOf("UUID")
                                UUID = respJson.Item("result").Item("error").Value.ToString().Substring(indice)
                                UUID = UUID.Replace("UUID", "").Trim

                                consulta = BuscarCFDiTimbre(dtPAC.Rows(i)("UserId"), dtPAC.Rows(i)("CustomerKey"), eRFC, sFolio, UUID)

                                Dim content2 As Byte() = System.Text.Encoding.UTF8.GetBytes(consulta)
                                Dim peticion2 As System.Net.HttpWebRequest = System.Net.WebRequest.Create(url)

                                peticion2.Method = "POST"
                                peticion2.ContentType = "application/x-www-form-urlencoded"
                                peticion2.ContentLength = content2.Length


                                Dim requestStream2 As System.IO.Stream = peticion2.GetRequestStream()

                                requestStream2.Write(content2, 0, content2.Length)
                                requestStream2.Close()

                                Dim resp2 As System.Net.HttpWebResponse = peticion2.GetResponse()
                                Dim respuesta2 As String = New System.IO.StreamReader(resp2.GetResponseStream).ReadToEnd

                                Dim respJson2 As Object = Newtonsoft.Json.Linq.JObject.Parse(respuesta2)

                                Dim jResult As Newtonsoft.Json.Linq.JArray = respJson2.Item("result").item("data")

                                Dim Elementos As XmlDocument = New XmlDocument()

                                Elementos.LoadXml(jResult.Item(0).Item("xml_data").ToString())

                                Dim oXmlNodos As XmlNodeList = Elementos.GetElementsByTagName("cfdi:Complemento")

                                Dim o As Integer

                                For o = 0 To oXmlNodos.ItemOf(0).FirstChild.Attributes.Count - 1

                                    Select Case oXmlNodos.ItemOf(0).FirstChild.Attributes.ItemOf(o).Name
                                        Case Is = "FechaTimbrado"
                                            fechaTimbrado = oXmlNodos.ItemOf(0).FirstChild.Attributes.ItemOf(o).Value

                                        Case Is = "noCertificadoSAT"
                                            CertificadoSAT = oXmlNodos.ItemOf(0).FirstChild.Attributes.ItemOf(o).Value

                                        Case Is = "selloSAT"
                                            SelloSAT = oXmlNodos.ItemOf(0).FirstChild.Attributes.ItemOf(o).Value

                                        Case Is = "version"
                                            VersionSAT = oXmlNodos.ItemOf(0).FirstChild.Attributes.ItemOf(o).Value
                                    End Select

                                Next

                                iTipoPAC = 2
                                'actualizaEdoCFD(sTipoComprobante, sDOCClave, 1)
                                ModPOS.Ejecuta("sp_actualiza_timbre", "@CustomerKey", dtPAC.Rows(i)("CustomerKey"), "@TipoPAC", iTipoPAC)
                                Exit For


                            End If


                        ElseIf i = dtPAC.Rows.Count - 1 Then
                            'actualizaEdoCFD(sTipoComprobante, sDOCClave, 2)
                            MsgBox("Se tuvo el siguiente error [" + respJson.Item("result").Item("retcode").Value.ToString() + "] " + respJson.Item("result").Item("error").Value.ToString())
                            UUID = "NO_VALIDO_FOLIO_FISCAL"
                            SelloSAT = "NO_VALIDO_TIMBRE_FISCAL"
                            fechaTimbrado = Date.Now
                            iTipoPAC = 0
                        End If
                    Catch ex As System.Net.WebException
                        MsgBox("Se tuvo el siguiente error [" & ex.Message & ", verfique su conexión] ")
                        UUID = "NO_VALIDO_FOLIO_FISCAL"
                        SelloSAT = "NO_VALIDO_TIMBRE_FISCAL"
                        iTipoPAC = 0
                        fechaTimbrado = Date.Now
                    End Try

                ElseIf dtPAC.Rows(i)("TipoPAC") = 3 Then 'DigitalInvoice

                    frmStatusMessage.Show("Solicitado Timbre Fiscal...Digital Invoice")
                    frmStatusMessage.BringToFront()

                    Dim xmlString As String

                    xmlString = oXml.OuterXml

                    Dim result As String

                    If oCFD.VersionCF = "3.3" Then
                        Dim client As DigitalInvoiceWS33.TimbradoClient = New DigitalInvoiceWS33.TimbradoClient("BasicHttpBinding_ITimbrado1")

                        client.ClientCredentials.UserName.UserName = dtPAC.Rows(i)("UserId")
                        client.ClientCredentials.UserName.Password = dtPAC.Rows(i)("CustomerKey")

                        client.Open()

                        Dim xmlBase64 As String = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(xmlString))
                        Dim xmlCFDI_Timbrado As String = String.Empty
                        Try

                            If dtPAC.Rows(i)("UserId") = "ELEPHANT_WORKS" Then
                                xmlCFDI_Timbrado = client.TimbrarTestBase64(xmlBase64)
                            Else
                                xmlCFDI_Timbrado = client.TimbrarBase64(xmlBase64)
                            End If
                            result = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(xmlCFDI_Timbrado))


                            Dim Elementos As String() = result.Split()

                            For Each sElementos As String In Elementos
                                If sElementos.Contains("UUID=") Then
                                    UUID = sElementos.Replace("UUID=", "").Replace("""", "")
                                End If
                                If sElementos.Contains("FechaTimbrado=") Then
                                    fechaTimbrado = sElementos.Replace("FechaTimbrado=", "").Replace("""", "")
                                End If
                                If sElementos.Contains("NoCertificadoSAT=") Then
                                    CertificadoSAT = sElementos.Replace("NoCertificadoSAT=", "").Replace("""", "")
                                End If

                                If sElementos.Contains("SelloSAT=") Then
                                    SelloSAT = sElementos.Replace("SelloSAT=", "").Replace("""", "")
                                End If
                                If sElementos.Contains("Version=") Then
                                    VersionSAT = sElementos.Replace("Version=", "").Replace("""", "")
                                End If

                                If sElementos.Contains("RfcProvCertif=") Then
                                    RfcPAC = sElementos.Replace("RfcProvCertif=", "").Replace("""", "")
                                End If
                            Next

                            iTipoPAC = 3
                            ' actualizaEdoCFD(sTipoComprobante, sDOCClave, 1, iTipoComprobante)
                            ModPOS.Ejecuta("sp_actualiza_timbre", "@CustomerKey", dtPAC.Rows(i)("CustomerKey"), "@TipoPAC", iTipoPAC)
                            Exit For

                        Catch ex As Exception
                            If i = dtPAC.Rows.Count - 1 Then
                                ' actualizaEdoCFD(sTipoComprobante, sDOCClave, 2, iTipoComprobante)
                                MsgBox("Se tuvo el siguiente error [" & ex.Message & ", verfique su conexión] ")
                                UUID = "NO_VALIDO_FOLIO_FISCAL"
                                SelloSAT = "NO_VALIDO_TIMBRE_FISCAL"
                                fechaTimbrado = Date.Now
                                iTipoPAC = 0
                            End If

                        End Try



                    Else '3.2
                        Dim client As DigitalInvoiceWS.TimbradoClient = New DigitalInvoiceWS.TimbradoClient("BasicHttpBinding_ITimbrado")

                        client.ClientCredentials.UserName.UserName = dtPAC.Rows(i)("UserId")
                        client.ClientCredentials.UserName.Password = dtPAC.Rows(i)("CustomerKey")

                        client.Open()

                        Dim xmlBase64 As String = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(xmlString))
                        Dim xmlCFDI_Timbrado As String = String.Empty
                        Try

                            If dtPAC.Rows(i)("UserId") = "ELEPHANT_WORKS" Then
                                xmlCFDI_Timbrado = client.TimbrarTestBase64(xmlBase64)
                            Else
                                xmlCFDI_Timbrado = client.TimbrarBase64(xmlBase64)
                            End If
                            result = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(xmlCFDI_Timbrado))


                            Dim Elementos As String() = result.Split()

                            For Each sElementos As String In Elementos
                                If sElementos.Contains("UUID=") Then
                                    UUID = sElementos.Replace("UUID=", "").Replace("""", "")
                                End If
                                If sElementos.Contains("FechaTimbrado=") Then
                                    fechaTimbrado = sElementos.Replace("FechaTimbrado=", "").Replace("""", "")
                                End If
                                If sElementos.Contains("noCertificadoSAT=") Then
                                    CertificadoSAT = sElementos.Replace("noCertificadoSAT=", "").Replace("""", "")
                                End If

                                If sElementos.Contains("selloSAT=") Then
                                    SelloSAT = sElementos.Replace("selloSAT=", "").Replace("""", "")
                                End If
                                If sElementos.Contains("version=") Then
                                    VersionSAT = sElementos.Replace("version=", "").Replace("""", "")
                                End If
                            Next

                            iTipoPAC = 3
                            ' actualizaEdoCFD(sTipoComprobante, sDOCClave, 1, iTipoComprobante)
                            ModPOS.Ejecuta("sp_actualiza_timbre", "@CustomerKey", dtPAC.Rows(i)("CustomerKey"), "@TipoPAC", iTipoPAC)
                            Exit For

                        Catch ex As Exception
                            If i = dtPAC.Rows.Count - 1 Then
                                ' actualizaEdoCFD(sTipoComprobante, sDOCClave, 2, iTipoComprobante)
                                MsgBox("Se tuvo el siguiente error [" & ex.Message & ", verfique su conexión] ")
                                UUID = "NO_VALIDO_FOLIO_FISCAL"
                                SelloSAT = "NO_VALIDO_TIMBRE_FISCAL"
                                fechaTimbrado = Date.Now
                                iTipoPAC = 0
                            End If

                        End Try
                    End If

                ElseIf dtPAC.Rows(i)("TipoPAC") = 4 Then 'Detecno

                    frmStatusMessage.Show("Solicitado Timbre Fiscal...Detecno")
                    frmStatusMessage.BringToFront()

                    Dim xmlString As String

                    xmlString = oXml.OuterXml

                    If oCFD.VersionCF = "3.3" Then

                        Dim client As DetecnoPAC33.DetecnoPacClient = New DetecnoPAC33.DetecnoPacClient()

                        Dim xmlRespuesta As DetecnoPAC33.Xml = New DetecnoPAC33.Xml()

                        If dtPAC.Rows(i)("UserId") = "AAAAAA\wsTIMBRADOR" Then
                            client.Endpoint.Address = New System.ServiceModel.EndpointAddress("https://test.timbra.mx/WCFTimbrador33/DetecnoPAC.svc")

                        Else
                            If dtPAC.Rows(i)("ServerTimbre") = "" Then
                                client.Endpoint.Address = New System.ServiceModel.EndpointAddress("https://www.timbra.mx/WCFTimbrador33/DetecnoPac.svc")
                            Else
                                client.Endpoint.Address = New System.ServiceModel.EndpointAddress(dtPAC.Rows(i)("ServerTimbre").ToString)
                            End If

                        End If

                        xmlRespuesta = client.TimbrarCfdi(dtPAC.Rows(i)("UserId"), dtPAC.Rows(i)("CustomerKey"), xmlString)



                        If xmlRespuesta.Success Then
                            Dim strXmlTfd As String = xmlRespuesta.XmlTfd
                            ' Dim strCoTfd As String = xmlRespuesta.CoTfd
                            'Dim strQR As String = xmlRespuesta.StrQr

                            Dim Elementos As String() = strXmlTfd.Split()

                            For Each sElementos As String In Elementos
                                If sElementos.Contains("UUID=") Then
                                    UUID = sElementos.Replace("UUID=", "").Replace("""", "")
                                End If
                                If sElementos.Contains("FechaTimbrado=") Then
                                    fechaTimbrado = sElementos.Replace("FechaTimbrado=", "").Replace("""", "")
                                End If
                                If sElementos.Contains("NoCertificadoSAT=") Then
                                    CertificadoSAT = sElementos.Replace("NoCertificadoSAT=", "").Replace("""", "")
                                End If

                                If sElementos.Contains("SelloSAT=") Then
                                    SelloSAT = sElementos.Replace("SelloSAT=", "").Replace("""", "")
                                End If
                                If sElementos.Contains("Version=") Then
                                    VersionSAT = sElementos.Replace("Version=", "").Replace("""", "")
                                End If

                                If sElementos.Contains("RfcProvCertif=") Then
                                    RfcPAC = sElementos.Replace("RfcProvCertif=", "").Replace("""", "")
                                End If


                            Next

                            iTipoPAC = 4
                            ModPOS.Ejecuta("sp_actualiza_timbre", "@CustomerKey", dtPAC.Rows(i)("CustomerKey"), "@TipoPAC", iTipoPAC)
                            Exit For

                        Else
                            Dim sError As String = xmlRespuesta.ErrDesc

                            If i = dtPAC.Rows.Count - 1 Then
                                MsgBox("Se tuvo el siguiente error [" & sError)
                                UUID = "NO_VALIDO_FOLIO_FISCAL"
                                SelloSAT = "NO_VALIDO_TIMBRE_FISCAL"
                                fechaTimbrado = Date.Now
                                iTipoPAC = 0
                            End If


                        End If

                    Else 'Version 3.2
                        Dim client As DetecnoPAC.DetecnoPacClient = New DetecnoPAC.DetecnoPacClient()

                        Dim xmlRespuesta As DetecnoPAC.Xml = New DetecnoPAC.Xml()

                        If dtPAC.Rows(i)("UserId") = "AAAAAA\wsTIMBRADOR" Then
                            client.Endpoint.Address = New System.ServiceModel.EndpointAddress("https://test.timbra.mx/WCFTimbrador/DetecnoPAC.svc")
                        Else
                            If dtPAC.Rows(i)("ServerTimbre") = "" Then
                                client.Endpoint.Address = New System.ServiceModel.EndpointAddress("https://www.timbra.mx/WCFTimbrador/DetecnoPac.svc")
                            Else
                                client.Endpoint.Address = New System.ServiceModel.EndpointAddress(dtPAC.Rows(i)("ServerTimbre").ToString)
                            End If

                        End If

                        xmlRespuesta = client.TimbrarCfdi(dtPAC.Rows(i)("UserId"), dtPAC.Rows(i)("CustomerKey"), xmlString)


                        If xmlRespuesta.Success Then
                            Dim strXmlTfd As String = xmlRespuesta.XmlTfd
                            ' Dim strCoTfd As String = xmlRespuesta.CoTfd
                            'Dim strQR As String = xmlRespuesta.StrQr

                            Dim Elementos As String() = strXmlTfd.Split()

                            For Each sElementos As String In Elementos
                                If sElementos.Contains("UUID=") Then
                                    UUID = sElementos.Replace("UUID=", "").Replace("""", "")
                                End If
                                If sElementos.Contains("FechaTimbrado=") Then
                                    fechaTimbrado = sElementos.Replace("FechaTimbrado=", "").Replace("""", "")
                                End If
                                If sElementos.Contains("noCertificadoSAT=") Then
                                    CertificadoSAT = sElementos.Replace("noCertificadoSAT=", "").Replace("""", "")
                                End If

                                If sElementos.Contains("selloSAT=") Then
                                    SelloSAT = sElementos.Replace("selloSAT=", "").Replace("""", "")
                                End If
                                If sElementos.Contains("version=") Then
                                    VersionSAT = sElementos.Replace("version=", "").Replace("""", "")
                                End If
                            Next

                            iTipoPAC = 4
                            ModPOS.Ejecuta("sp_actualiza_timbre", "@CustomerKey", dtPAC.Rows(i)("CustomerKey"), "@TipoPAC", iTipoPAC)
                            Exit For

                        Else
                            Dim sError As String = xmlRespuesta.ErrDesc

                            If i = dtPAC.Rows.Count - 1 Then
                                MsgBox("Se tuvo el siguiente error [" & sError)
                                UUID = "NO_VALIDO_FOLIO_FISCAL"
                                SelloSAT = "NO_VALIDO_TIMBRE_FISCAL"
                                fechaTimbrado = Date.Now
                                iTipoPAC = 0
                            End If


                        End If


                    End If



                End If

            Next

            ' Inicia Timbrado

            frmStatusMessage.Dispose()

            If oCFD.VersionCF = "3.3" Then
                CBB = ModPOS.crearQR33(eRFC, RFC, total, UUID, Right(oCFD.sello, 8))

            Else
                CBB = ModPOS.crearQR(eRFC, RFC, total, UUID)
            End If

            If iTipoPAC = 0 Then
                oXml.Save(FileXML)
            Else

                Dim newElem As XmlElement = oXml.CreateElement("cfdi", "Complemento", "http://www.sat.gob.mx/cfd/3")

                Dim newEle1 As XmlElement = oXml.CreateElement("tfd", "TimbreFiscalDigital", "http://www.sat.gob.mx/TimbreFiscalDigital")
                ' 1. Create a new Book element.


                Dim newAttr As XmlAttribute

                If oCFD.VersionCF <> "3.3" Then

                    newAttr = oXml.CreateAttribute("xsi", "schemaLocation", "http://www.w3.org/2001/XMLSchema-instance")
                    newAttr.Value = "http://www.sat.gob.mx/TimbreFiscalDigital http://www.sat.gob.mx/TimbreFiscalDigital/TimbreFiscalDigital.xsd"
                    newEle1.Attributes.Append(newAttr)

                    newAttr = oXml.CreateAttribute("selloCFD")
                    newAttr.Value = sello
                    newEle1.Attributes.Append(newAttr)

                    newAttr = oXml.CreateAttribute("selloSAT")
                    newAttr.Value = SelloSAT
                    newEle1.Attributes.Append(newAttr)

                    newAttr = oXml.CreateAttribute("UUID")
                    newAttr.Value = UUID
                    newEle1.Attributes.Append(newAttr)


                    newAttr = oXml.CreateAttribute("FechaTimbrado")
                    newAttr.Value = String.Format("{0:yyyy-MM-ddTHH:mm:ss}", fechaTimbrado)
                    newEle1.Attributes.Append(newAttr)


                    newAttr = oXml.CreateAttribute("version")
                    newAttr.Value = VersionSAT
                    newEle1.Attributes.Append(newAttr)

                    newAttr = oXml.CreateAttribute("noCertificadoSAT")
                    newAttr.Value = CertificadoSAT
                    newEle1.Attributes.Append(newAttr)
                Else

                    newAttr = oXml.CreateAttribute("xsi", "schemaLocation", "http://www.w3.org/2001/XMLSchema-instance")
                    newAttr.Value = "http://www.sat.gob.mx/TimbreFiscalDigital http://www.sat.gob.mx/sitio_internet/cfd/TimbreFiscalDigital/TimbreFiscalDigitalv11.xsd"
                    newEle1.Attributes.Append(newAttr)

                    newAttr = oXml.CreateAttribute("Version")
                    newAttr.Value = VersionSAT
                    newEle1.Attributes.Append(newAttr)

                    newAttr = oXml.CreateAttribute("UUID")
                    newAttr.Value = UUID
                    newEle1.Attributes.Append(newAttr)

                    newAttr = oXml.CreateAttribute("FechaTimbrado")
                    newAttr.Value = String.Format("{0:yyyy-MM-ddTHH:mm:ss}", fechaTimbrado)
                    newEle1.Attributes.Append(newAttr)

                    newAttr = oXml.CreateAttribute("RfcProvCertif")
                    newAttr.Value = RfcPAC
                    newEle1.Attributes.Append(newAttr)

                    newAttr = oXml.CreateAttribute("SelloCFD")
                    newAttr.Value = sello
                    newEle1.Attributes.Append(newAttr)

                    newAttr = oXml.CreateAttribute("NoCertificadoSAT")
                    newAttr.Value = CertificadoSAT
                    newEle1.Attributes.Append(newAttr)

                    newAttr = oXml.CreateAttribute("SelloSAT")
                    newAttr.Value = SelloSAT
                    newEle1.Attributes.Append(newAttr)
                End If



                newElem.AppendChild(newEle1)
                oXml.DocumentElement.AppendChild(newElem)
                oXml.Save(FileXML)


                ' actualiza timbrado
                ModPOS.Ejecuta("sp_act_timbrado_nomina", "@RENClave", oCFD.RENClave, "@fechaRecibo", oCFD.Fecha, "@noCertificado", oCFD.noCertificado, "@TipoEstado", 1, "@Usuario", ModPOS.UsuarioActual)
                ModPOS.Ejecuta("sp_inserta_selloREC", "@RENClave", oCFD.RENClave, "@cadenaOriginal", oCFD.cadenaOriginal, "@Sello", oCFD.sello, "@Certificado64", oCFD.Certificado64, "@CBB", CBB, "@UUID", UUID, "@SelloSAT", SelloSAT, "@CertificadoSAT", CertificadoSAT, "@fechaTimbrado", fechaTimbrado, "@versionSAT", VersionSAT, "@TipoPAC", iTipoPAC, "@RfcProvCertif", RfcPAC)

            End If


            'Verifica que exista el path
            If iTipoPAC <> 0 Then
                Try
                    If System.IO.Directory.Exists(PathXML) Then

                        Dim oPath As String = PathXML
                        If oPath.Length > 3 AndAlso oPath.Substring(oPath.Length - 1, 1) <> "\" Then
                            oPath &= "\"
                        End If

                        oPath &= CDate(oCFD.Fecha).Year.ToString & "\" & CDate(oCFD.Fecha).Month.ToString & "\" & CDate(oCFD.Fecha).Day.ToString & "\"

                        If Not System.IO.Directory.Exists(oPath) Then
                            System.IO.Directory.CreateDirectory(oPath)
                        End If

                        oFileXML = oPath & sFolio & ".xml"

                        If System.IO.File.Exists(oFileXML) Then
                            If FileXML <> oFileXML Then
                                System.IO.File.Delete(oFileXML)
                            End If
                        End If
                        If FileXML <> oFileXML Then
                            System.IO.File.Move(FileXML, oFileXML)
                        End If
                    Else
                        MessageBox.Show("El directorio " & PathXML & " no existe o no se puede tener acceso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Catch ex As Exception
                End Try

            End If

            Return iTipoPAC

    End Function

    Public Function crearXMLGlobal(ByVal TipoAccion As Integer, ByVal dtPAC As DataTable, ByVal PathXML As String, ByVal sFolio As String, ByVal sDOCClave As String, ByVal dtConcepto As DataTable, ByVal dtImpuesto As DataTable, ByVal dtImpuestoDet As DataTable, Optional ByVal oCFD As CFD = Nothing, Optional ByVal sInterfazSalida As String = "") As Integer
        Dim i As Integer
        Dim FileXML, oFileXML, oPath As String
        Dim sPre As String = ""
        Dim iTipoPAC As Integer = 0

        Dim VersionCF As String = ""
        Dim eRFC As String = ""
        Dim RFC As String = ""
        Dim sello As String = ""
        Dim UUID As String = ""
        Dim SelloSAT As String = ""
        Dim CertificadoSAT As String = ""
        Dim VersionSAT As String = ""
        Dim RfcPAC As String = ""


        Dim fechaTimbrado, fechaPath As Date
        Dim total As Double

        Dim CBB() As Byte = Nothing

        FileXML = pathActual & "CFD\" & sFolio & ".xml"

        oCFD.subtotal = dtConcepto.Compute("Sum(Subtotal)", "")
        oCFD.descuento = dtConcepto.Compute("Sum(Descuento)", "")
        oCFD.total = dtConcepto.Compute("Sum(total)", "")
        oCFD.impuestos = dtConcepto.Compute("Sum(Impuesto)", "")



        If TipoAccion = 1 OrElse TipoAccion = 3 OrElse TipoAccion = 4 Then 'Crea por primera vez el XML o regenerar xml

            fechaPath = oCFD.Fecha
            sPre = "cfdi:"

            'Si es anticipo
            ' Opens the document
            Dim textWriter As System.Xml.XmlTextWriter = New System.Xml.XmlTextWriter(FileXML, System.Text.Encoding.UTF8)
            textWriter.Formatting = System.Xml.Formatting.None

            textWriter.WriteStartDocument()
            textWriter.WriteStartElement(sPre & "Comprobante")
            textWriter.WriteAttributeString("xmlns:cfdi", "http://www.sat.gob.mx/cfd/3")
            textWriter.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance")
            textWriter.WriteAttributeString("xsi:schemaLocation", "http://www.sat.gob.mx/cfd/3 http://www.sat.gob.mx/sitio_internet/cfd/3/cfdv33.xsd")

            textWriter.WriteAttributeString("Version", oCFD.VersionCF)
            If oCFD.Serie <> "" Then
                textWriter.WriteAttributeString("Serie", oCFD.Serie)
            End If
            textWriter.WriteAttributeString("Folio", oCFD.Folio)
            textWriter.WriteAttributeString("Fecha", oCFD.Fecha)
            textWriter.WriteAttributeString("Sello", oCFD.sello)
            textWriter.WriteAttributeString("FormaPago", spaceFormat(oCFD.metodoDePago))
            textWriter.WriteAttributeString("NoCertificado", oCFD.noCertificado)
            textWriter.WriteAttributeString("Certificado", oCFD.Certificado64)
            textWriter.WriteAttributeString("SubTotal", QuitarCeros(TruncateToDecimal(oCFD.subtotal / oCFD.TipoCambio, 2), 2))
            If oCFD.descuento > 0 Then
                textWriter.WriteAttributeString("Descuento", QuitarCeros(TruncateToDecimal(oCFD.descuento / oCFD.TipoCambio, 2), 2))
            End If

            textWriter.WriteAttributeString("Moneda", oCFD.Moneda)
            If oCFD.TipoCambio <> 1 Then
                textWriter.WriteAttributeString("TipoCambio", QuitarCeros(TruncateToDecimal(oCFD.TipoCambio, 2), 6))
            End If
            textWriter.WriteAttributeString("Total", QuitarCeros(TruncateToDecimal(oCFD.total / oCFD.TipoCambio, 2), 2))
            textWriter.WriteAttributeString("TipoDeComprobante", "I")
            textWriter.WriteAttributeString("MetodoPago", "PUE")
            textWriter.WriteAttributeString("LugarExpedicion", spaceFormat(oCFD.sCodigoPostal))

            textWriter.WriteStartElement(sPre & "Emisor")
            textWriter.WriteAttributeString("Rfc", spaceFormat(oCFD.eRFC))
            textWriter.WriteAttributeString("Nombre", spaceFormat(oCFD.eRazonSocial))
            textWriter.WriteAttributeString("RegimenFiscal", spaceFormat(oCFD.regimenFiscal))
            textWriter.WriteEndElement()

            textWriter.WriteStartElement(sPre & "Receptor")
            textWriter.WriteAttributeString("Rfc", "XAXX010101000")
            textWriter.WriteAttributeString("UsoCFDI", "P01")
            textWriter.WriteEndElement()


            textWriter.WriteStartElement(sPre & "Conceptos")
            Dim foundRows() As DataRow
            foundRows = dtConcepto.Select("FACClave = '" & oCFD.DOCClave & "'")

            Dim foundDet() As DataRow
            Dim z As Integer

            If foundRows.GetLength(0) > 0 Then
                For i = 0 To foundRows.GetUpperBound(0)

                    foundDet = dtImpuestoDet.Select("DETClave = '" & foundRows(i)("DETClave") & "'")

                    textWriter.WriteStartElement(sPre & "Concepto")
                    textWriter.WriteAttributeString("ClaveProdServ", "01010101")
                    textWriter.WriteAttributeString("NoIdentificacion", foundRows(i)("Folio"))
                    textWriter.WriteAttributeString("Cantidad", "1")
                    textWriter.WriteAttributeString("ClaveUnidad", "ACT")
                    textWriter.WriteAttributeString("Descripcion", "Venta")
                    textWriter.WriteAttributeString("ValorUnitario", QuitarCeros(TruncateToDecimal(foundRows(i)("Subtotal") / oCFD.TipoCambio, 2), 2))
                    textWriter.WriteAttributeString("Importe", QuitarCeros(TruncateToDecimal((foundRows(i)("Subtotal") / oCFD.TipoCambio), 2), 2))

                    'Campo opcional cuando se tenga descuentos
                    If foundRows(i)("Descuento") > 0 Then
                        textWriter.WriteAttributeString("Descuento", QuitarCeros(TruncateToDecimal(foundRows(i)("Descuento") / oCFD.TipoCambio, 2), 2))
                    End If
                    textWriter.WriteStartElement(sPre & "Impuestos")
                    textWriter.WriteStartElement(sPre & "Traslados")
                    For z = 0 To foundDet.GetUpperBound(0)
                        textWriter.WriteStartElement(sPre & "Traslado")
                        textWriter.WriteAttributeString("Base", QuitarCeros(TruncateToDecimal(foundDet(z)("Base") / oCFD.TipoCambio, 2), 2))
                        textWriter.WriteAttributeString("Impuesto", spaceFormat(foundDet(z)("ClaveSAT")))
                        textWriter.WriteAttributeString("TipoFactor", foundDet(z)("TipoFactor"))
                        textWriter.WriteAttributeString("TasaOCuota", QuitarCeros(foundDet(z)("Tasa"), 6))
                        textWriter.WriteAttributeString("Importe", QuitarCeros(TruncateToDecimal(foundDet(z)("Importe") / oCFD.TipoCambio, 2), 2))
                        textWriter.WriteEndElement()
                    Next


                    'cierre traslados
                    textWriter.WriteEndElement()
                    'cierre impuestos
                    textWriter.WriteEndElement()
                    'Cierre concepto
                    textWriter.WriteEndElement()

                Next
            End If
            'Cierre de Conceptos
            textWriter.WriteEndElement()

            ' Write one more element
            textWriter.WriteStartElement(sPre & "Impuestos")
            textWriter.WriteAttributeString("TotalImpuestosTrasladados", QuitarCeros(TruncateToDecimal(oCFD.impuestos / oCFD.TipoCambio, 2), 2))
            textWriter.WriteStartElement(sPre & "Traslados")

            foundRows = dtImpuesto.Select("FACClave = '" & oCFD.DOCClave & "'")

            If foundRows.GetLength(0) > 0 Then

                For i = 0 To foundRows.GetUpperBound(0)

                    textWriter.WriteStartElement(sPre & "Traslado")
                    textWriter.WriteAttributeString("Impuesto", foundRows(i)("ClaveSAT"))
                    textWriter.WriteAttributeString("TipoFactor", foundRows(i)("TipoFactor"))
                    textWriter.WriteAttributeString("TasaOCuota", QuitarCeros(foundRows(i)("Tasa"), 6))
                    textWriter.WriteAttributeString("Importe", QuitarCeros(TruncateToDecimal(foundRows(i)("Importe") / oCFD.TipoCambio, 2), 2))
                    textWriter.WriteEndElement()
                Next

            End If
            'fin de ciclo de impuestos

            'Cierre de Traslados
            textWriter.WriteEndElement()
            'Cierre de Impuesto
            textWriter.WriteEndElement()

            'Cierre de Comprobante
            textWriter.WriteEndElement()
            ' Ends the document.
            textWriter.WriteEndDocument()
            ' close writer
            textWriter.Close()



        End If

        eRFC = oCFD.eRFC
        RFC = oCFD.RFC
        total = oCFD.total
        sello = oCFD.sello


        If TipoAccion = 2 Then ' Si es un reintento de timbrado

            Dim dt As DataTable

            dt = ModPOS.Recupera_Tabla("sp_sello_fac", "@FACClave", sDOCClave)
            sello = IIf(dt.Rows(0)("Sello").GetType.Name = "DBNull", "", dt.Rows(0)("Sello"))
            dt.Dispose()

            dt = ModPOS.Recupera_Tabla("sp_encabezado_fac", "@FACClave", sDOCClave)
            eRFC = dt.Rows(0)("cRFC")
            RFC = dt.Rows(0)("id_Fiscal")
            total = dt.Rows(0)("Total")
            fechaPath = dt.Rows(0)("fechaFactura")
            VersionCF = dt.Rows(0)("VersionCF")
            dt.Dispose()

            oPath = PathXML
            If oPath.Length > 3 AndAlso oPath.Substring(oPath.Length - 1, 1) <> "\" Then
                oPath &= "\"
            End If

            oPath &= fechaPath.Year.ToString & "\" & fechaPath.Month.ToString & "\" & fechaPath.Day.ToString & "\"

            If Not System.IO.File.Exists(FileXML) Then
                If System.IO.File.Exists(oPath & sFolio & ".xml") Then
                    System.IO.File.Copy(oPath & sFolio & ".xml", FileXML)
                Else
                    MessageBox.Show("El archivo " & oPath & "\" & sFolio & ".xml no existe o se cambio de lugar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    Exit Function
                End If
            End If


        End If ' Finaliza reintento 

        If TipoAccion <> 3 Then
            If TipoAccion = 2 OrElse oCFD.TipoCF = 2 Then ' Inicia timbrado


                Dim oXml As New XmlDocument()
                oXml.Load(FileXML)

                Dim frmStatusMessage As New frmStatus

                For i = 0 To dtPAC.Rows.Count - 1
                    If dtPAC.Rows(i)("TipoPAC") = 1 Then ' Tralix

                        frmStatusMessage.Show("Solicitado Timbre Fiscal...Tralix")
                        frmStatusMessage.BringToFront()

                        Dim oCfdi As New LibCFDiTralix.CFDiTralix()

                        Dim oTimbre As LibCFDiTralix.com.tralix.pac.TimbreFiscalDigital

                        'https://pruebastfd.tralix.com:7070
                        Try
                            oTimbre = oCfdi.TimbrarCFDi(oXml.OuterXml, dtPAC.Rows(i)("ServerTimbre"), dtPAC.Rows(i)("Customerkey"))

                            If oTimbre Is Nothing AndAlso i = dtPAC.Rows.Count - 1 Then
                                MsgBox("Se tuvo el siguiente error " + vbCrLf + "[" + CType(LibCFDiTralix.CodigoMensaje.eCodigo, Integer).ToString() + "]" + LibCFDiTralix.CodigoMensaje.eCodigo.ToString() + ": " + LibCFDiTralix.CodigoMensaje.sMensaje)
                                UUID = "NO_VALIDO_FOLIO_FISCAL"
                                SelloSAT = "NO_VALIDO_TIMBRE_FISCAL"
                                iTipoPAC = 0
                                RfcPAC = ""
                                fechaTimbrado = Date.Now
                            ElseIf Not oTimbre Is Nothing Then
                                UUID = oTimbre.UUID
                                SelloSAT = oTimbre.selloSAT
                                CertificadoSAT = oTimbre.noCertificadoSAT
                                fechaTimbrado = oTimbre.FechaTimbrado
                                VersionSAT = oTimbre.version
                                iTipoPAC = 1
                                RfcPAC = IIf(dtPAC.Rows(i)("RFC").GetType.Name = "DBNull", "", dtPAC.Rows(i)("RFC"))
                                ModPOS.Ejecuta("sp_actualiza_timbre", "@CustomerKey", dtPAC.Rows(i)("CustomerKey"), "@TipoPAC", iTipoPAC)
                                Exit For
                            End If

                        Catch ex As System.Net.WebException
                            If i = dtPAC.Rows.Count - 1 Then
                                MsgBox("Se tuvo el siguiente error [" & ex.Message & ", verfique su conexión] ")
                                UUID = "NO_VALIDO_FOLIO_FISCAL"
                                SelloSAT = "NO_VALIDO_TIMBRE_FISCAL"
                                fechaTimbrado = Date.Now
                                RfcPAC = ""
                                iTipoPAC = 0
                            End If
                        End Try

                    ElseIf dtPAC.Rows(i)("TipoPAC") = 2 Then 'iTimbre

                        frmStatusMessage.Show("Solicitado Timbre Fiscal...iTimbre")
                        frmStatusMessage.BringToFront()

                        Dim consulta As String = ObtenerConsultaiTimbre(sFolio, eRFC, dtPAC.Rows(i)("UserId"), dtPAC.Rows(i)("CustomerKey"), FileXML)
                        Dim content As Byte() = System.Text.Encoding.UTF8.GetBytes(consulta)

                        Dim url As String = dtPAC.Rows(i)("ServerTimbre")
                        Dim peticion As System.Net.HttpWebRequest = System.Net.WebRequest.Create(url)

                        peticion.Method = "POST"
                        peticion.ContentType = "application/x-www-form-urlencoded"
                        peticion.ContentLength = content.Length

                        Try
                            Dim requestStream As System.IO.Stream = peticion.GetRequestStream()

                            requestStream.Write(content, 0, content.Length)
                            requestStream.Close()

                            Dim resp As System.Net.HttpWebResponse = peticion.GetResponse()
                            Dim respuesta As String = New System.IO.StreamReader(resp.GetResponseStream).ReadToEnd

                            Dim respJson As Object = Newtonsoft.Json.Linq.JObject.Parse(respuesta)

                            If respJson.Item("result").item("retcode").Value = 1 OrElse respJson.Item("result").item("retcode").Value = 307 Then

                                If respJson.Item("result").item("retcode").Value = 1 Then
                                    UUID = respJson.Item("result").item("UUID").Value

                                    Dim Elementos As String() = respJson.Item("result").item("data").ToString.Split()

                                    For Each sElementos As String In Elementos
                                        If sElementos.Contains("FechaTimbrado=") Then
                                            fechaTimbrado = sElementos.Replace("FechaTimbrado=", "").Replace("""", "")
                                        End If
                                        If sElementos.Contains("noCertificadoSAT=") Then
                                            CertificadoSAT = sElementos.Replace("noCertificadoSAT=", "").Replace("""", "")
                                        End If
                                        'If sElementos.Contains("selloCFD=") Then
                                        '    oCFD.selloCFD = sElementos.Replace("selloCFD=", "").Replace("""", "")
                                        'End If
                                        If sElementos.Contains("selloSAT=") Then
                                            SelloSAT = sElementos.Replace("selloSAT=", "").Replace("""", "")
                                        End If
                                        If sElementos.Contains("version=") Then
                                            VersionSAT = sElementos.Replace("version=", "").Replace("""", "")
                                        End If
                                    Next
                                    RfcPAC = IIf(dtPAC.Rows(i)("RFC").GetType.Name = "DBNull", "", dtPAC.Rows(i)("RFC"))
                                    iTipoPAC = 2
                                    ModPOS.Ejecuta("sp_actualiza_timbre", "@CustomerKey", dtPAC.Rows(i)("CustomerKey"), "@TipoPAC", iTipoPAC)
                                    Exit For
                                Else
                                    frmStatusMessage.Show(respJson.Item("result").Item("error").Value.ToString() & ", Espere, lo estamos recuperando...iTimbre")

                                    ' Si ya fue timbrado entonces
                                    Dim indice As Integer = respJson.Item("result").Item("error").Value.ToString().IndexOf("UUID")
                                    UUID = respJson.Item("result").Item("error").Value.ToString().Substring(indice)
                                    UUID = UUID.Replace("UUID", "").Trim

                                    consulta = BuscarCFDiTimbre(dtPAC.Rows(i)("UserId"), dtPAC.Rows(i)("CustomerKey"), eRFC, sFolio, UUID)

                                    Dim content2 As Byte() = System.Text.Encoding.UTF8.GetBytes(consulta)
                                    Dim peticion2 As System.Net.HttpWebRequest = System.Net.WebRequest.Create(url)

                                    peticion2.Method = "POST"
                                    peticion2.ContentType = "application/x-www-form-urlencoded"
                                    peticion2.ContentLength = content2.Length


                                    Dim requestStream2 As System.IO.Stream = peticion2.GetRequestStream()

                                    requestStream2.Write(content2, 0, content2.Length)
                                    requestStream2.Close()

                                    Dim resp2 As System.Net.HttpWebResponse = peticion2.GetResponse()
                                    Dim respuesta2 As String = New System.IO.StreamReader(resp2.GetResponseStream).ReadToEnd

                                    Dim respJson2 As Object = Newtonsoft.Json.Linq.JObject.Parse(respuesta2)

                                    Dim jResult As Newtonsoft.Json.Linq.JArray = respJson2.Item("result").item("data")

                                    Dim Elementos As XmlDocument = New XmlDocument()

                                    Elementos.LoadXml(jResult.Item(0).Item("xml_data").ToString())

                                    Dim oXmlNodos As XmlNodeList = Elementos.GetElementsByTagName("cfdi:Complemento")

                                    Dim o As Integer

                                    For o = 0 To oXmlNodos.ItemOf(0).FirstChild.Attributes.Count - 1

                                        Select Case oXmlNodos.ItemOf(0).FirstChild.Attributes.ItemOf(o).Name
                                            Case Is = "FechaTimbrado"
                                                fechaTimbrado = oXmlNodos.ItemOf(0).FirstChild.Attributes.ItemOf(o).Value

                                            Case Is = "noCertificadoSAT"
                                                CertificadoSAT = oXmlNodos.ItemOf(0).FirstChild.Attributes.ItemOf(o).Value

                                            Case Is = "selloSAT"
                                                SelloSAT = oXmlNodos.ItemOf(0).FirstChild.Attributes.ItemOf(o).Value

                                            Case Is = "version"
                                                VersionSAT = oXmlNodos.ItemOf(0).FirstChild.Attributes.ItemOf(o).Value
                                        End Select

                                    Next
                                    RfcPAC = IIf(dtPAC.Rows(i)("RFC").GetType.Name = "DBNull", "", dtPAC.Rows(i)("RFC"))

                                    iTipoPAC = 2
                                    ModPOS.Ejecuta("sp_actualiza_timbre", "@CustomerKey", dtPAC.Rows(i)("CustomerKey"), "@TipoPAC", iTipoPAC)
                                    Exit For


                                End If
                            ElseIf i = dtPAC.Rows.Count - 1 Then
                                MsgBox("Se tuvo el siguiente error [" + respJson.Item("result").Item("retcode").Value.ToString() + "] " + respJson.Item("result").Item("error").Value.ToString())
                                UUID = "NO_VALIDO_FOLIO_FISCAL"
                                SelloSAT = "NO_VALIDO_TIMBRE_FISCAL"
                                fechaTimbrado = Date.Now
                                RfcPAC = ""
                                iTipoPAC = 0
                            End If
                        Catch ex As System.Net.WebException
                            If i = dtPAC.Rows.Count - 1 Then
                                MsgBox("Se tuvo el siguiente error [" & ex.Message & ", verfique su conexión] ")
                                UUID = "NO_VALIDO_FOLIO_FISCAL"
                                SelloSAT = "NO_VALIDO_TIMBRE_FISCAL"
                                fechaTimbrado = Date.Now
                                iTipoPAC = 0
                                RfcPAC = 0
                            End If
                        End Try

                    ElseIf dtPAC.Rows(i)("TipoPAC") = 3 Then 'DigitalInvoice

                        frmStatusMessage.Show("Solicitado Timbre Fiscal...Digital Invoice")
                        frmStatusMessage.BringToFront()

                        Dim xmlString As String

                        xmlString = oXml.OuterXml

                        Dim result As String

                        If oCFD.VersionCF = "3.3" Then
                            Dim client As DigitalInvoiceWS33.TimbradoClient = New DigitalInvoiceWS33.TimbradoClient("BasicHttpBinding_ITimbrado1")


                            client.ClientCredentials.UserName.UserName = dtPAC.Rows(i)("UserId")
                            client.ClientCredentials.UserName.Password = dtPAC.Rows(i)("CustomerKey")

                            client.Open()

                            Dim xmlBase64 As String = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(xmlString))
                            Dim xmlCFDI_Timbrado As String = String.Empty
                            Try

                                If dtPAC.Rows(i)("UserId") = "ELEPHANT_WORKS" Then
                                    xmlCFDI_Timbrado = client.TimbrarTestBase64(xmlBase64)
                                Else
                                    xmlCFDI_Timbrado = client.TimbrarBase64(xmlBase64)
                                End If
                                result = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(xmlCFDI_Timbrado))


                                Dim Elementos As String() = result.Split()

                                For Each sElementos As String In Elementos
                                    If sElementos.Contains("UUID=") Then
                                        UUID = sElementos.Replace("UUID=", "").Replace("""", "")
                                    End If
                                    If sElementos.Contains("FechaTimbrado=") Then
                                        fechaTimbrado = sElementos.Replace("FechaTimbrado=", "").Replace("""", "")
                                    End If
                                    If sElementos.Contains("NoCertificadoSAT=") Then
                                        CertificadoSAT = sElementos.Replace("NoCertificadoSAT=", "").Replace("""", "")
                                    End If

                                    If sElementos.Contains("SelloSAT=") Then
                                        SelloSAT = sElementos.Replace("SelloSAT=", "").Replace("""", "")
                                    End If
                                    If sElementos.Contains("Version=") Then
                                        VersionSAT = sElementos.Replace("Version=", "").Replace("""", "")
                                    End If

                                    If sElementos.Contains("RfcProvCertif=") Then
                                        RfcPAC = sElementos.Replace("RfcProvCertif=", "").Replace("""", "")
                                    End If
                                Next

                                iTipoPAC = 3
                                ModPOS.Ejecuta("sp_actualiza_timbre", "@CustomerKey", dtPAC.Rows(i)("CustomerKey"), "@TipoPAC", iTipoPAC)
                                Exit For

                            Catch ex As Exception

                                If ex.Message = "El CFDI contiene un timbre previo." Then

                                    xmlCFDI_Timbrado = client.RecuperarTimbreBase64(xmlBase64)

                                    result = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(xmlCFDI_Timbrado))


                                    Dim Elementos As String() = result.Split()

                                    For Each sElementos As String In Elementos
                                        If sElementos.Contains("UUID=") Then
                                            UUID = sElementos.Replace("UUID=", "").Replace("""", "")
                                        End If
                                        If sElementos.Contains("FechaTimbrado=") Then
                                            fechaTimbrado = sElementos.Replace("FechaTimbrado=", "").Replace("""", "")
                                        End If
                                        If sElementos.Contains("NoCertificadoSAT=") Then
                                            CertificadoSAT = sElementos.Replace("NoCertificadoSAT=", "").Replace("""", "")
                                        End If

                                        If sElementos.Contains("SelloSAT=") Then
                                            SelloSAT = sElementos.Replace("SelloSAT=", "").Replace("""", "")
                                        End If
                                        If sElementos.Contains("Version=") Then
                                            VersionSAT = sElementos.Replace("Version=", "").Replace("""", "")
                                        End If

                                        If sElementos.Contains("RfcProvCertif=") Then
                                            RfcPAC = sElementos.Replace("RfcProvCertif=", "").Replace("""", "")
                                        End If
                                    Next
                                    iTipoPAC = 3
                                    ModPOS.Ejecuta("sp_actualiza_timbre", "@CustomerKey", dtPAC.Rows(i)("CustomerKey"), "@TipoPAC", iTipoPAC)
                                    Exit For
                                Else
                                    If i = dtPAC.Rows.Count - 1 Then
                                        MsgBox("Se tuvo el siguiente error [" & ex.Message & ", verfique su conexión] ")
                                        UUID = "NO_VALIDO_FOLIO_FISCAL"
                                        SelloSAT = "NO_VALIDO_TIMBRE_FISCAL"
                                        fechaTimbrado = Date.Now
                                        iTipoPAC = 0
                                        RfcPAC = ""
                                    End If
                                End If

                            End Try

                        Else '3.2
                            Dim client As DigitalInvoiceWS.TimbradoClient = New DigitalInvoiceWS.TimbradoClient("BasicHttpBinding_ITimbrado")

                            'If oCFD.VersionCF = "3.3" Then
                            '    client.Endpoint.Address = New System.ServiceModel.EndpointAddress(dtPAC.Rows(i)("ServerTimbre").ToString)
                            'End If

                            client.ClientCredentials.UserName.UserName = dtPAC.Rows(i)("UserId")
                            client.ClientCredentials.UserName.Password = dtPAC.Rows(i)("CustomerKey")

                            client.Open()

                            Dim xmlBase64 As String = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(xmlString))
                            Dim xmlCFDI_Timbrado As String = String.Empty
                            Try

                                If dtPAC.Rows(i)("UserId") = "ELEPHANT_WORKS" Then
                                    xmlCFDI_Timbrado = client.TimbrarTestBase64(xmlBase64)
                                Else
                                    xmlCFDI_Timbrado = client.TimbrarBase64(xmlBase64)
                                End If
                                result = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(xmlCFDI_Timbrado))


                                Dim Elementos As String() = result.Split()

                                For Each sElementos As String In Elementos
                                    If sElementos.Contains("UUID=") Then
                                        UUID = sElementos.Replace("UUID=", "").Replace("""", "")
                                    End If
                                    If sElementos.Contains("FechaTimbrado=") Then
                                        fechaTimbrado = sElementos.Replace("FechaTimbrado=", "").Replace("""", "")
                                    End If
                                    If sElementos.Contains("noCertificadoSAT=") Then
                                        CertificadoSAT = sElementos.Replace("noCertificadoSAT=", "").Replace("""", "")
                                    End If

                                    If sElementos.Contains("selloSAT=") Then
                                        SelloSAT = sElementos.Replace("selloSAT=", "").Replace("""", "")
                                    End If
                                    If sElementos.Contains("version=") Then
                                        VersionSAT = sElementos.Replace("version=", "").Replace("""", "")
                                    End If
                                Next
                                RfcPAC = IIf(dtPAC.Rows(i)("RFC").GetType.Name = "DBNull", "", dtPAC.Rows(i)("RFC"))

                                iTipoPAC = 3
                                ModPOS.Ejecuta("sp_actualiza_timbre", "@CustomerKey", dtPAC.Rows(i)("CustomerKey"), "@TipoPAC", iTipoPAC)
                                Exit For

                            Catch ex As Exception

                                If ex.Message = "El CFDI contiene un timbre previo." Then

                                    xmlCFDI_Timbrado = client.RecuperarTimbreBase64(xmlBase64)

                                    result = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(xmlCFDI_Timbrado))


                                    Dim Elementos As String() = result.Split()

                                    For Each sElementos As String In Elementos
                                        If sElementos.Contains("UUID=") Then
                                            UUID = sElementos.Replace("UUID=", "").Replace("""", "")
                                        End If
                                        If sElementos.Contains("FechaTimbrado=") Then
                                            fechaTimbrado = sElementos.Replace("FechaTimbrado=", "").Replace("""", "")
                                        End If
                                        If sElementos.Contains("noCertificadoSAT=") Then
                                            CertificadoSAT = sElementos.Replace("noCertificadoSAT=", "").Replace("""", "")
                                        End If

                                        If sElementos.Contains("selloSAT=") Then
                                            SelloSAT = sElementos.Replace("selloSAT=", "").Replace("""", "")
                                        End If
                                        If sElementos.Contains("version=") Then
                                            VersionSAT = sElementos.Replace("version=", "").Replace("""", "")
                                        End If
                                    Next
                                    RfcPAC = IIf(dtPAC.Rows(i)("RFC").GetType.Name = "DBNull", "", dtPAC.Rows(i)("RFC"))

                                    iTipoPAC = 3
                                    ModPOS.Ejecuta("sp_actualiza_timbre", "@CustomerKey", dtPAC.Rows(i)("CustomerKey"), "@TipoPAC", iTipoPAC)
                                    Exit For
                                Else
                                    If i = dtPAC.Rows.Count - 1 Then
                                        MsgBox("Se tuvo el siguiente error [" & ex.Message & ", verfique su conexión] ")
                                        UUID = "NO_VALIDO_FOLIO_FISCAL"
                                        SelloSAT = "NO_VALIDO_TIMBRE_FISCAL"
                                        fechaTimbrado = Date.Now
                                        iTipoPAC = 0
                                        RfcPAC = ""
                                    End If
                                End If

                            End Try

                        End If

                    ElseIf dtPAC.Rows(i)("TipoPAC") = 4 Then 'Detecno

                        frmStatusMessage.Show("Solicitado Timbre Fiscal...Detecno")
                        frmStatusMessage.BringToFront()

                        Dim xmlString As String

                        xmlString = oXml.OuterXml

                        If oCFD.VersionCF = "3.3" Then

                            Dim client As DetecnoPAC33.DetecnoPacClient = New DetecnoPAC33.DetecnoPacClient()

                            Dim xmlRespuesta As DetecnoPAC33.Xml = New DetecnoPAC33.Xml()

                            If dtPAC.Rows(i)("UserId") = "AAAAAA\wsTIMBRADOR" Then
                                client.Endpoint.Address = New System.ServiceModel.EndpointAddress("https://test.timbra.mx/WCFTimbrador33/DetecnoPAC.svc")

                            Else
                                If dtPAC.Rows(i)("ServerTimbre") = "" Then
                                    client.Endpoint.Address = New System.ServiceModel.EndpointAddress("https://www.timbra.mx/WCFTimbrador33/DetecnoPac.svc")
                                Else
                                    client.Endpoint.Address = New System.ServiceModel.EndpointAddress(dtPAC.Rows(i)("ServerTimbre").ToString)
                                End If

                            End If

                            xmlRespuesta = client.TimbrarCfdi(dtPAC.Rows(i)("UserId"), dtPAC.Rows(i)("CustomerKey"), xmlString)



                            If xmlRespuesta.Success Then
                                Dim strXmlTfd As String = xmlRespuesta.XmlTfd
                                ' Dim strCoTfd As String = xmlRespuesta.CoTfd
                                'Dim strQR As String = xmlRespuesta.StrQr

                                Dim Elementos As String() = strXmlTfd.Split()

                                For Each sElementos As String In Elementos

                                    If sElementos.Contains("UUID=") Then
                                        UUID = sElementos.Replace("UUID=", "").Replace("""", "")
                                    End If
                                    If sElementos.Contains("FechaTimbrado=") Then
                                        fechaTimbrado = sElementos.Replace("FechaTimbrado=", "").Replace("""", "")
                                    End If
                                    If sElementos.Contains("NoCertificadoSAT=") Then
                                        CertificadoSAT = sElementos.Replace("NoCertificadoSAT=", "").Replace("""", "")
                                    End If

                                    If sElementos.Contains("SelloSAT=") Then
                                        SelloSAT = sElementos.Replace("SelloSAT=", "").Replace("""", "")
                                    End If
                                    If sElementos.Contains("Version=") Then
                                        VersionSAT = sElementos.Replace("Version=", "").Replace("""", "")
                                    End If

                                    If sElementos.Contains("RfcProvCertif=") Then
                                        RfcPAC = sElementos.Replace("RfcProvCertif=", "").Replace("""", "")
                                    End If
                                Next


                                iTipoPAC = 4
                                ModPOS.Ejecuta("sp_actualiza_timbre", "@CustomerKey", dtPAC.Rows(i)("CustomerKey"), "@TipoPAC", iTipoPAC)
                                Exit For

                            Else
                                Dim sError As String = xmlRespuesta.ErrDesc

                                If i = dtPAC.Rows.Count - 1 Then
                                    MsgBox("Se tuvo el siguiente error [" & sError)
                                    UUID = "NO_VALIDO_FOLIO_FISCAL"
                                    SelloSAT = "NO_VALIDO_TIMBRE_FISCAL"
                                    fechaTimbrado = Date.Now
                                    iTipoPAC = 0
                                    RfcPAC = ""
                                End If


                            End If

                        Else 'Version 3.2
                            Dim client As DetecnoPAC.DetecnoPacClient = New DetecnoPAC.DetecnoPacClient()

                            Dim xmlRespuesta As DetecnoPAC.Xml = New DetecnoPAC.Xml()

                            If dtPAC.Rows(i)("UserId") = "AAAAAA\wsTIMBRADOR" Then
                                client.Endpoint.Address = New System.ServiceModel.EndpointAddress("https://test.timbra.mx/WCFTimbrador/DetecnoPAC.svc")
                            Else
                                If dtPAC.Rows(i)("ServerTimbre") = "" Then
                                    client.Endpoint.Address = New System.ServiceModel.EndpointAddress("https://www.timbra.mx/WCFTimbrador/DetecnoPac.svc")
                                Else
                                    client.Endpoint.Address = New System.ServiceModel.EndpointAddress(dtPAC.Rows(i)("ServerTimbre").ToString)
                                End If

                            End If

                            xmlRespuesta = client.TimbrarCfdi(dtPAC.Rows(i)("UserId"), dtPAC.Rows(i)("CustomerKey"), xmlString)


                            If xmlRespuesta.Success Then
                                Dim strXmlTfd As String = xmlRespuesta.XmlTfd
                                ' Dim strCoTfd As String = xmlRespuesta.CoTfd
                                'Dim strQR As String = xmlRespuesta.StrQr

                                Dim Elementos As String() = strXmlTfd.Split()

                                For Each sElementos As String In Elementos
                                    If sElementos.Contains("UUID=") Then
                                        UUID = sElementos.Replace("UUID=", "").Replace("""", "")
                                    End If
                                    If sElementos.Contains("FechaTimbrado=") Then
                                        fechaTimbrado = sElementos.Replace("FechaTimbrado=", "").Replace("""", "")
                                    End If
                                    If sElementos.Contains("noCertificadoSAT=") Then
                                        CertificadoSAT = sElementos.Replace("noCertificadoSAT=", "").Replace("""", "")
                                    End If

                                    If sElementos.Contains("selloSAT=") Then
                                        SelloSAT = sElementos.Replace("selloSAT=", "").Replace("""", "")
                                    End If
                                    If sElementos.Contains("version=") Then
                                        VersionSAT = sElementos.Replace("version=", "").Replace("""", "")
                                    End If
                                Next

                                RfcPAC = IIf(dtPAC.Rows(i)("RFC").GetType.Name = "DBNull", "", dtPAC.Rows(i)("RFC"))

                                iTipoPAC = 4
                                ModPOS.Ejecuta("sp_actualiza_timbre", "@CustomerKey", dtPAC.Rows(i)("CustomerKey"), "@TipoPAC", iTipoPAC)
                                Exit For

                            Else
                                Dim sError As String = xmlRespuesta.ErrDesc

                                If i = dtPAC.Rows.Count - 1 Then
                                    MsgBox("Se tuvo el siguiente error [" & sError)
                                    UUID = "NO_VALIDO_FOLIO_FISCAL"
                                    SelloSAT = "NO_VALIDO_TIMBRE_FISCAL"
                                    fechaTimbrado = Date.Now
                                    iTipoPAC = 0
                                    RfcPAC = ""
                                End If


                            End If


                        End If

                    End If
                Next


                ' Area comun de timbrado

                frmStatusMessage.Dispose()

                CBB = ModPOS.crearQR33(eRFC, RFC, total, UUID, Right(oCFD.sello, 8))


                If iTipoPAC = 0 Then
                    oXml.Save(FileXML)
                Else
                    Dim newElem As XmlElement = oXml.CreateElement("cfdi", "Complemento", "http://www.sat.gob.mx/cfd/3")

                    Dim newEle1 As XmlElement = oXml.CreateElement("tfd", "TimbreFiscalDigital", "http://www.sat.gob.mx/TimbreFiscalDigital")
                    ' 1. Create a new Book element.


                    Dim newAttr As XmlAttribute

                    newAttr = oXml.CreateAttribute("xsi", "schemaLocation", "http://www.w3.org/2001/XMLSchema-instance")
                    newAttr.Value = "http://www.sat.gob.mx/TimbreFiscalDigital http://www.sat.gob.mx/sitio_internet/cfd/TimbreFiscalDigital/TimbreFiscalDigitalv11.xsd"
                    newEle1.Attributes.Append(newAttr)



                    newAttr = oXml.CreateAttribute("Version")
                    newAttr.Value = VersionSAT
                    newEle1.Attributes.Append(newAttr)

                    newAttr = oXml.CreateAttribute("UUID")
                    newAttr.Value = UUID
                    newEle1.Attributes.Append(newAttr)


                    newAttr = oXml.CreateAttribute("FechaTimbrado")
                    newAttr.Value = String.Format("{0:yyyy-MM-ddTHH:mm:ss}", fechaTimbrado)
                    newEle1.Attributes.Append(newAttr)

                    newAttr = oXml.CreateAttribute("RfcProvCertif")
                    newAttr.Value = RfcPAC
                    newEle1.Attributes.Append(newAttr)

                    newAttr = oXml.CreateAttribute("SelloCFD")
                    newAttr.Value = sello
                    newEle1.Attributes.Append(newAttr)

                    newAttr = oXml.CreateAttribute("noCertificadoSAT")
                    newAttr.Value = CertificadoSAT
                    newEle1.Attributes.Append(newAttr)

                    newAttr = oXml.CreateAttribute("SelloSAT")
                    newAttr.Value = SelloSAT
                    newEle1.Attributes.Append(newAttr)


                    newElem.AppendChild(newEle1)
                    oXml.DocumentElement.AppendChild(newElem)
                    oXml.Save(FileXML)

                End If
            End If
        End If


        If TipoAccion = 1 OrElse TipoAccion = 4 Then

            If iTipoPAC = 0 Then
                fechaTimbrado = CDate(oCFD.Fecha)
            End If

            ModPOS.Ejecuta("sp_inserta_sello", "@FACClave", sDOCClave, "@noAprobacion", oCFD.noAprobacion, "@anoAprobacion", oCFD.anoAprobacion, "@Certificado", oCFD.noCertificado, "@cadenaOriginal", oCFD.cadenaOriginal, "@Sello", oCFD.sello, "@Certificado64", oCFD.Certificado64, "@CBB", CBB, "@UUID", UUID, "@SelloSAT", SelloSAT, "@CertificadoSAT", CertificadoSAT, "@fechaTimbrado", fechaTimbrado, "@versionSAT", VersionSAT, "@TipoPAC", iTipoPAC, "@RfcProvCertif", RfcPAC)
            actualizaEdoCFD("I", sDOCClave, 1, 1)

        ElseIf TipoAccion = 2 Then
            ModPOS.Ejecuta("sp_actualiza_timbrado", "@Tipo", "I", "@DOCClave", sDOCClave, "@CBB", CBB, "@UUID", UUID, "@SelloSAT", SelloSAT, "@CertificadoSAT", CertificadoSAT, "@fechaTimbrado", fechaTimbrado, "@versionSAT", VersionSAT, "@TipoPAC", iTipoPAC, "@TipoComprobante", 1, "@RfcProvCertif", RfcPAC)
        ElseIf TipoAccion = 3 Then
            ModPOS.Ejecuta("sp_actualiza_cbb", "@Tipo", "I", "@DOCClave", sDOCClave, "@CBB", CBB, "@TipoComprobante", 1)

        End If


        If iTipoPAC <> 0 Then
            'Verifica que exista el path
            Try
                If System.IO.Directory.Exists(PathXML) Then

                    oPath = PathXML
                    If oPath.Length > 3 AndAlso oPath.Substring(oPath.Length - 1, 1) <> "\" Then
                        oPath &= "\"
                    End If


                    oPath &= fechaPath.Year.ToString & "\" & fechaPath.Month.ToString & "\" & fechaPath.Day.ToString & "\"

                    If Not System.IO.Directory.Exists(oPath) Then
                        System.IO.Directory.CreateDirectory(oPath)
                    End If

                    oFileXML = oPath & sFolio & ".xml"

                    If System.IO.File.Exists(oFileXML) Then
                        If FileXML <> oFileXML Then
                            System.IO.File.Delete(oFileXML)
                        End If
                    End If




                    'Verifica si existe carpeta Temp
                    If sInterfazSalida <> "" Then
                        Try
                            If Not System.IO.Directory.Exists(PathXML & "\Temp") Then
                                System.IO.Directory.CreateDirectory(PathXML & "\Temp")
                            End If

                            Dim oTemp As String
                            If PathXML.Length <= 3 Then
                                oTemp = PathXML & "Temp\" & sFolio & ".xml"
                            ElseIf PathXML.Substring(PathXML.Length - 1, 1) = "\" Then
                                oTemp = PathXML & "Temp\" & sFolio & ".xml"
                            Else
                                oTemp = PathXML & "\" & "Temp\" & sFolio & ".xml"
                            End If

                            If System.IO.File.Exists(oTemp) Then
                                If FileXML <> oTemp Then
                                    System.IO.File.Delete(oTemp)
                                End If
                            End If
                            If FileXML <> oTemp Then
                                System.IO.File.Copy(FileXML, oTemp)
                            End If


                        Catch ex As Exception
                        End Try


                    End If

                    If FileXML <> oFileXML Then
                        System.IO.File.Move(FileXML, oFileXML)
                    End If


                Else
                    MessageBox.Show("El directorio " & PathXML & " no existe o no se puede tener acceso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
            End Try

        End If

        If sInterfazSalida <> "" AndAlso TipoAccion <> 3 AndAlso TipoAccion <> 4 AndAlso iTipoPAC <> 0 Then
            Dim sFecha As String
            Dim dtInterfaz As DataTable
            sFecha = DateTime.Now.ToString("yyyyMMdd_HHmmssfff")

            Dim InterfazCobros As String = ""
            Dim InterfazAnticipos As String = ""

            dtInterfaz = Recupera_Tabla("st_recupera_interfaz", "@Interfaz", "Factura", "@COMClave", ModPOS.CompanyActual)
            If dtInterfaz.Rows.Count > 0 Then
                ModPOS.Ejecuta(CStr(dtInterfaz.Rows(0)("sp")), "@Folio", sDOCClave, "@TipoDocumento", 0, "@Path", sInterfazSalida, "@Fecha", sFecha)
            End If

        End If



        Return iTipoPAC

    End Function



    Public Function crearXMLPago(ByVal TipoAccion As Integer, ByVal dtPAC As DataTable, ByVal PathXML As String, ByVal sFolio As String, ByVal sDOCClave As String, ByVal iTipo As Integer, ByVal TipoComprobante As String, ByVal DOCClave As String, Optional ByVal oCFD As CFD = Nothing, Optional ByVal sInterfazSalida As String = "", Optional ByVal bShowMsg As Boolean = True) As Integer
        Dim i As Integer
        Dim FileXML, oFileXML, oPath As String
        Dim sPre As String = ""
        Dim iTipoPAC As Integer = 0

        Dim eRFC As String = ""
        Dim RFC As String = ""
        Dim sello As String = ""
        Dim UUID As String = ""
        Dim SelloSAT As String = ""
        Dim CertificadoSAT As String = ""
        Dim VersionSAT As String = ""
        Dim RfcPAC As String = ""


        Dim fechaTimbrado, fechaPath As Date
        Dim total As Double

        Dim CBB() As Byte = Nothing

        If TipoComprobante = "E" Then
            sFolio &= "_A"
        End If

        FileXML = pathActual & "CFD\" & sFolio & ".xml"


        If TipoAccion = 1 OrElse TipoAccion = 3 OrElse TipoAccion = 4 Then 'Crea por primera vez el XML o regenerar xml

            fechaPath = oCFD.Fecha
            sPre = "cfdi:"

            If iTipo = 2 Then
                'Si es anticipo
                ' Opens the document

                Dim Base As Decimal = Math.Round(oCFD.total / 1.16, 2)
                Dim IVA As Decimal = Math.Round(Base * 0.16, 2)


                Dim textWriter As System.Xml.XmlTextWriter = New System.Xml.XmlTextWriter(FileXML, System.Text.Encoding.UTF8)
                textWriter.Formatting = System.Xml.Formatting.None

                textWriter.WriteStartDocument()
                textWriter.WriteStartElement(sPre & "Comprobante")
                textWriter.WriteAttributeString("xmlns:cfdi", "http://www.sat.gob.mx/cfd/3")
                textWriter.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance")
                textWriter.WriteAttributeString("xsi:schemaLocation", "http://www.sat.gob.mx/cfd/3 http://www.sat.gob.mx/sitio_internet/cfd/3/cfdv33.xsd")

                textWriter.WriteAttributeString("Version", oCFD.VersionCF)
                textWriter.WriteAttributeString("Folio", oCFD.Folio)
                textWriter.WriteAttributeString("Fecha", oCFD.Fecha)
                textWriter.WriteAttributeString("Sello", oCFD.sello)
                If TipoComprobante = "I" Then
                    textWriter.WriteAttributeString("FormaPago", spaceFormat(oCFD.metodoDePago))
                Else
                    textWriter.WriteAttributeString("FormaPago", "30")
                End If
                textWriter.WriteAttributeString("NoCertificado", oCFD.noCertificado)
                textWriter.WriteAttributeString("Certificado", oCFD.Certificado64)
                textWriter.WriteAttributeString("SubTotal", QuitarCeros(TruncateToDecimal(Base / oCFD.TipoCambio, 2), 2))
                textWriter.WriteAttributeString("Moneda", oCFD.Moneda)

                If oCFD.TipoCambio <> 1 Then
                    textWriter.WriteAttributeString("TipoCambio", QuitarCeros(TruncateToDecimal(oCFD.TipoCambio, 2), 6))
                End If
                textWriter.WriteAttributeString("Total", QuitarCeros(TruncateToDecimal(Base + IVA / oCFD.TipoCambio, 2), 2))
                textWriter.WriteAttributeString("TipoDeComprobante", TipoComprobante)
                textWriter.WriteAttributeString("MetodoPago", "PUE")
                textWriter.WriteAttributeString("LugarExpedicion", spaceFormat(oCFD.sCodigoPostal))

                If TipoComprobante = "E" Then
                    textWriter.WriteStartElement(sPre & "CfdiRelacionados")
                    textWriter.WriteAttributeString("TipoRelacion", "07")
                    textWriter.WriteStartElement(sPre & "CfdiRelacionado")
                    textWriter.WriteAttributeString("UUID", oCFD.UUID_Sustituido)
                    textWriter.WriteEndElement()
                    textWriter.WriteEndElement()
                End If

                textWriter.WriteStartElement(sPre & "Emisor")
                textWriter.WriteAttributeString("Rfc", spaceFormat(oCFD.eRFC))
                textWriter.WriteAttributeString("Nombre", spaceFormat(oCFD.eRazonSocial))
                textWriter.WriteAttributeString("RegimenFiscal", spaceFormat(oCFD.regimenFiscal))


                'Cierre de Emisor
                textWriter.WriteEndElement()

                textWriter.WriteStartElement(sPre & "Receptor")
                If oCFD.Nacionalidad = "MEX" Then
                    textWriter.WriteAttributeString("Rfc", spaceFormat(oCFD.RFC))
                    textWriter.WriteAttributeString("Nombre", spaceFormat(oCFD.RazonSocial))
                Else
                    textWriter.WriteAttributeString("Rfc", "XEXX010101000")
                    textWriter.WriteAttributeString("Nombre", spaceFormat(oCFD.RazonSocial))
                    textWriter.WriteAttributeString("ResidenciaFiscal", spaceFormat(oCFD.Nacionalidad))
                    textWriter.WriteAttributeString("NumRegIdTrib", spaceFormat(oCFD.NumRegIdTrib))
                End If

                textWriter.WriteAttributeString("UsoCFDI", "P01")
                textWriter.WriteEndElement()

                textWriter.WriteStartElement(sPre & "Conceptos")
                textWriter.WriteStartElement(sPre & "Concepto")
                textWriter.WriteAttributeString("ClaveProdServ", "84111506")
                textWriter.WriteAttributeString("Cantidad", "1")
                textWriter.WriteAttributeString("ClaveUnidad", "ACT")
                If TipoComprobante = "I" Then
                    textWriter.WriteAttributeString("Descripcion", "Anticipo del bien o servicio")
                Else
                    textWriter.WriteAttributeString("Descripcion", "Aplicación de anticipo")
                End If

                textWriter.WriteAttributeString("ValorUnitario", QuitarCeros(TruncateToDecimal(Base / oCFD.TipoCambio, 2), 2))
                textWriter.WriteAttributeString("Importe", QuitarCeros(TruncateToDecimal(Base / oCFD.TipoCambio, 2), 2))

                textWriter.WriteStartElement(sPre & "Impuestos")

                textWriter.WriteStartElement(sPre & "Traslados")
                textWriter.WriteStartElement(sPre & "Traslado")
                textWriter.WriteAttributeString("Base", QuitarCeros(TruncateToDecimal(Base / oCFD.TipoCambio, 2), 2))
                textWriter.WriteAttributeString("Impuesto", "002")
                textWriter.WriteAttributeString("TipoFactor", "Tasa")
                textWriter.WriteAttributeString("TasaOCuota", "0.160000")
                textWriter.WriteAttributeString("Importe", QuitarCeros(TruncateToDecimal(IVA / oCFD.TipoCambio, 2), 2))
                textWriter.WriteEndElement()
                'cierre traslados
                textWriter.WriteEndElement()
                'cierre impuestos
                textWriter.WriteEndElement()
                'Cierre de Concepto
                textWriter.WriteEndElement()
                'Cierre de Conceptos
                textWriter.WriteEndElement()

                textWriter.WriteStartElement(sPre & "Impuestos")
                textWriter.WriteAttributeString("TotalImpuestosTrasladados", QuitarCeros(TruncateToDecimal(IVA / oCFD.TipoCambio, 2), 2))
                textWriter.WriteStartElement(sPre & "Traslados")
                textWriter.WriteStartElement(sPre & "Traslado")
                textWriter.WriteAttributeString("Impuesto", "002")
                textWriter.WriteAttributeString("TipoFactor", "Tasa")
                textWriter.WriteAttributeString("TasaOCuota", "0.160000")
                textWriter.WriteAttributeString("Importe", QuitarCeros(TruncateToDecimal(IVA / oCFD.TipoCambio, 2), 2))
                textWriter.WriteEndElement()
                'Cierre de Traslados
                textWriter.WriteEndElement()
                'Cierre de Impuesto
                textWriter.WriteEndElement()



                'Cierre de Comprobante
                textWriter.WriteEndElement()
                ' Ends the document.
                textWriter.WriteEndDocument()
                ' close writer
                textWriter.Close()

            Else
                'Si es Pago
                Dim textWriter As System.Xml.XmlTextWriter = New System.Xml.XmlTextWriter(FileXML, System.Text.Encoding.UTF8)
                textWriter.Formatting = System.Xml.Formatting.None

                textWriter.WriteStartDocument()
                textWriter.WriteStartElement(sPre & "Comprobante")
                textWriter.WriteAttributeString("xmlns:cfdi", "http://www.sat.gob.mx/cfd/3")
                textWriter.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance")

                textWriter.WriteAttributeString("xsi:schemaLocation", "http://www.sat.gob.mx/cfd/3 http://www.sat.gob.mx/sitio_internet/cfd/3/cfdv33.xsd http://www.sat.gob.mx/Pagos http://www.sat.gob.mx/sitio_internet/cfd/Pagos/Pagos10.xsd")
                textWriter.WriteAttributeString("Version", oCFD.VersionCF)

                textWriter.WriteAttributeString("Folio", oCFD.Folio)
                textWriter.WriteAttributeString("Fecha", oCFD.Fecha)
                textWriter.WriteAttributeString("Sello", oCFD.sello)
                textWriter.WriteAttributeString("NoCertificado", oCFD.noCertificado)
                textWriter.WriteAttributeString("Certificado", oCFD.Certificado64)
                textWriter.WriteAttributeString("SubTotal", "0")
                textWriter.WriteAttributeString("Moneda", "XXX")
                textWriter.WriteAttributeString("Total", "0")
                textWriter.WriteAttributeString("TipoDeComprobante", "P")
                textWriter.WriteAttributeString("LugarExpedicion", spaceFormat(oCFD.sCodigoPostal))

                'textWriter.WriteStartElement(sPre & "CfdiRelacionados")
                'textWriter.WriteAttributeString("TipoRelacion", "04")

                '

                'For i = 0 To dt.Rows.Count - 1
                '    textWriter.WriteStartElement(sPre & "CfdiRelacionado")
                '    textWriter.WriteAttributeString("UUID", dt.Rows(i)("UUID"))
                '    textWriter.WriteEndElement()
                'Next
                'textWriter.WriteEndElement()

                textWriter.WriteStartElement(sPre & "Emisor")
                textWriter.WriteAttributeString("Rfc", spaceFormat(oCFD.eRFC))
                textWriter.WriteAttributeString("Nombre", spaceFormat(oCFD.eRazonSocial))
                textWriter.WriteAttributeString("RegimenFiscal", spaceFormat(oCFD.regimenFiscal))

                'Cierre de Emisor
                textWriter.WriteEndElement()

                textWriter.WriteStartElement(sPre & "Receptor")
                'Aqui van datos cuando es Extranjero
                If oCFD.Nacionalidad = "MEX" Then
                    textWriter.WriteAttributeString("Rfc", spaceFormat(oCFD.RFC))
                    textWriter.WriteAttributeString("Nombre", spaceFormat(oCFD.RazonSocial))
                Else
                    textWriter.WriteAttributeString("Rfc", "XEXX010101000")
                    textWriter.WriteAttributeString("Nombre", spaceFormat(oCFD.RazonSocial))
                    textWriter.WriteAttributeString("ResidenciaFiscal", spaceFormat(oCFD.Nacionalidad))
                    textWriter.WriteAttributeString("NumRegIdTrib", spaceFormat(oCFD.NumRegIdTrib))
                End If
                textWriter.WriteAttributeString("UsoCFDI", "P01")
                'Cierre de Receptor
                textWriter.WriteEndElement()

                textWriter.WriteStartElement(sPre & "Conceptos")
                textWriter.WriteStartElement(sPre & "Concepto")
                textWriter.WriteAttributeString("ClaveProdServ", "84111506")
                textWriter.WriteAttributeString("Cantidad", "1")
                textWriter.WriteAttributeString("ClaveUnidad", "ACT")
                textWriter.WriteAttributeString("Descripcion", "Pago")
                textWriter.WriteAttributeString("ValorUnitario", "0")
                textWriter.WriteAttributeString("Importe", "0")
                'Cierre concepto
                textWriter.WriteEndElement()
                'Cierre de Conceptos
                textWriter.WriteEndElement()

                'Complemento de Recepcion de Pagos

                textWriter.WriteStartElement(sPre & "Complemento")
                textWriter.WriteAttributeString("xmlns:pago10", "http://www.sat.gob.mx/Pagos")
                textWriter.WriteStartElement("pago10:" & "Pagos")

                textWriter.WriteAttributeString("Version", "1.0")

                textWriter.WriteStartElement("pago10:" & "Pago")
                textWriter.WriteAttributeString("FechaPago", oCFD.Fecha)
                textWriter.WriteAttributeString("FormaDePagoP", oCFD.metodoDePago)
                textWriter.WriteAttributeString("MonedaP", oCFD.Moneda)
                If oCFD.TipoCambio <> 1 Then
                    textWriter.WriteAttributeString("TipoCambioP", oCFD.TipoCambio)
                End If

                textWriter.WriteAttributeString("Monto", QuitarCeros(TruncateToDecimal(oCFD.total / oCFD.TipoCambio, 2), 2))


                'If oCFD.metodoDePago = "01" Then
                '    textWriter.WriteAttributeString("NumOperacion", "01")
                'Else
                '    textWriter.WriteAttributeString("NumOperacion", oCFD.NumCtaPago)
                '    If oCFD.metodoDePago = "02" OrElse oCFD.metodoDePago = "03" OrElse oCFD.metodoDePago = "04" OrElse oCFD.metodoDePago = "05" OrElse oCFD.metodoDePago = "06" OrElse oCFD.metodoDePago = "28" OrElse oCFD.metodoDePago = "29" Then
                '        textWriter.WriteAttributeString("RfcEmisorCtaOrd", "")
                '        textWriter.WriteAttributeString("NomBancoOrdExt", "")
                '        textWriter.WriteAttributeString("CtaOrdenante", "")
                '    End If

                '    textWriter.WriteAttributeString("RfcEmisorCtaBen", "")
                '    textWriter.WriteAttributeString("CtaBeneficiario", "")
                '    'textWriter.WriteAttributeString("TipoCadPago", "")
                '    'textWriter.WriteAttributeString("CertPago", "")
                '    'textWriter.WriteAttributeString("CadPago", "")
                '    'textWriter.WriteAttributeString("SelloPago", "")
                'End If



                Dim dt As DataTable = ModPOS.Recupera_Tabla("st_recupera_relacionado", "@DOCClave", sDOCClave, "@Tipo", "P")
                For i = 0 To dt.Rows.Count - 1
                    textWriter.WriteStartElement("pago10:" & "DoctoRelacionado")
                    textWriter.WriteAttributeString("IdDocumento", dt.Rows(i)("UUID"))
                    If dt.Rows(i)("Serie") <> "" Then
                        textWriter.WriteAttributeString("Serie", dt.Rows(i)("Serie"))
                    End If

                    textWriter.WriteAttributeString("Folio", dt.Rows(i)("Folio"))
                    textWriter.WriteAttributeString("MonedaDR", dt.Rows(i)("MonedaDR"))
                    If dt.Rows(i)("TipoCambioDR") <> oCFD.TipoCambio Then
                        If dt.Rows(i)("MonedaDR") = "MXN" Then
                            textWriter.WriteAttributeString("TipoCambioDR", 1)
                        Else
                            textWriter.WriteAttributeString("TipoCambioDR", dt.Rows(i)("TipoCambioDR"))
                        End If
                    End If

                    Dim MetodoPagoDR As String
                    If dt.Rows(i)("MetodoPagoDR") = "PUE" OrElse dt.Rows(i)("MetodoPagoDR") = "PPD" Then
                        MetodoPagoDR = dt.Rows(i)("MetodoPagoDR")
                    Else
                        MetodoPagoDR = "PUE"
                    End If

                    textWriter.WriteAttributeString("MetodoDePagoDR", MetodoPagoDR)
                    If MetodoPagoDR = "PPD" Then
                        textWriter.WriteAttributeString("NumParcialidad", dt.Rows(i)("NumParcialidad"))
                        textWriter.WriteAttributeString("ImpSaldoAnt", QuitarCeros(TruncateToDecimal(dt.Rows(i)("ImpSaldoAnt") / dt.Rows(i)("TipoCambioDR"), 2), 2))
                        textWriter.WriteAttributeString("ImpPagado", QuitarCeros(TruncateToDecimal(dt.Rows(i)("ImpPagado") / dt.Rows(i)("TipoCambioDR"), 2), 2))
                        textWriter.WriteAttributeString("ImpSaldoInsoluto", QuitarCeros(TruncateToDecimal(dt.Rows(i)("ImpSaldoInsoluto") / dt.Rows(i)("TipoCambioDR"), 2), 2))
                    Else
                        If dt.Rows.Count > 1 Then
                            textWriter.WriteAttributeString("ImpPagado", QuitarCeros(TruncateToDecimal(dt.Rows(i)("ImpPagado") / dt.Rows(i)("TipoCambioDR"), 2), 2))
                        End If
                    End If
                    textWriter.WriteEndElement()
                Next

                textWriter.WriteEndElement()
                textWriter.WriteEndElement()
                textWriter.WriteEndElement()

                'Cierre de Comprobante
                textWriter.WriteEndElement()
                ' Ends the document.
                textWriter.WriteEndDocument()
                ' close writer
                textWriter.Close()
            End If


        End If

        eRFC = oCFD.eRFC
        RFC = oCFD.RFC
        total = oCFD.total
        sello = oCFD.sello


        If TipoAccion = 2 And TipoComprobante = "I" Then ' Si es un reintento de timbrado

            Dim dt As DataTable

            dt = ModPOS.Recupera_Tabla("st_sello_pago", "@ABNClave", sDOCClave)
            sello = IIf(dt.Rows(0)("Sello").GetType.Name = "DBNull", "", dt.Rows(0)("Sello"))
            ' VersionCF = dt.Rows(0)("VersionCF")
            dt.Dispose()

            dt = ModPOS.Recupera_Tabla("st_encabezado_abono", "@ABNClave", sDOCClave)
            eRFC = dt.Rows(0)("eRFC")
            RFC = dt.Rows(0)("rRFC")
            total = dt.Rows(0)("Importe")
            fechaPath = dt.Rows(0)("MFechaHora")
            dt.Dispose()

            oPath = PathXML
            If oPath.Length > 3 AndAlso oPath.Substring(oPath.Length - 1, 1) <> "\" Then
                oPath &= "\"
            End If

            oPath &= fechaPath.Year.ToString & "\" & fechaPath.Month.ToString & "\" & fechaPath.Day.ToString & "\"

            If Not System.IO.File.Exists(FileXML) Then
                If System.IO.File.Exists(oPath & sFolio & ".xml") Then
                    System.IO.File.Copy(oPath & sFolio & ".xml", FileXML)
                Else
                    If bShowMsg = True Then
                        MessageBox.Show("El archivo " & oPath & "\" & sFolio & ".xml no existe o se cambio de lugar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                    Exit Function
                End If
            End If


        End If ' Finaliza reintento 

        If TipoAccion <> 3 Then
            If TipoAccion = 2 OrElse oCFD.TipoCF = 2 Then ' Inicia timbrado


                Dim oXml As New XmlDocument()
                oXml.Load(FileXML)

                Dim frmStatusMessage As New frmStatus

                For i = 0 To dtPAC.Rows.Count - 1
                    If dtPAC.Rows(i)("TipoPAC") = 1 Then ' Tralix

                        frmStatusMessage.Show("Solicitado Timbre Fiscal...Tralix")
                        frmStatusMessage.BringToFront()

                        Dim oCfdi As New LibCFDiTralix.CFDiTralix()

                        Dim oTimbre As LibCFDiTralix.com.tralix.pac.TimbreFiscalDigital

                        'https://pruebastfd.tralix.com:7070
                        Try
                            oTimbre = oCfdi.TimbrarCFDi(oXml.OuterXml, dtPAC.Rows(i)("ServerTimbre"), dtPAC.Rows(i)("Customerkey"))

                            If oTimbre Is Nothing AndAlso i = dtPAC.Rows.Count - 1 Then
                                MsgBox("Se tuvo el siguiente error " + vbCrLf + "[" + CType(LibCFDiTralix.CodigoMensaje.eCodigo, Integer).ToString() + "]" + LibCFDiTralix.CodigoMensaje.eCodigo.ToString() + ": " + LibCFDiTralix.CodigoMensaje.sMensaje)
                                UUID = "NO_VALIDO_FOLIO_FISCAL"
                                SelloSAT = "NO_VALIDO_TIMBRE_FISCAL"
                                iTipoPAC = 0
                                RfcPAC = ""
                                fechaTimbrado = Date.Now
                            ElseIf Not oTimbre Is Nothing Then
                                UUID = oTimbre.UUID
                                SelloSAT = oTimbre.selloSAT
                                CertificadoSAT = oTimbre.noCertificadoSAT
                                fechaTimbrado = oTimbre.FechaTimbrado
                                VersionSAT = oTimbre.version
                                iTipoPAC = 1
                                RfcPAC = IIf(dtPAC.Rows(i)("RFC").GetType.Name = "DBNull", "", dtPAC.Rows(i)("RFC"))
                                ModPOS.Ejecuta("sp_actualiza_timbre", "@CustomerKey", dtPAC.Rows(i)("CustomerKey"), "@TipoPAC", iTipoPAC)
                                Exit For
                            End If

                        Catch ex As System.Net.WebException
                            If i = dtPAC.Rows.Count - 1 Then
                                MsgBox("Se tuvo el siguiente error [" & ex.Message & ", verfique su conexión] ")
                                UUID = "NO_VALIDO_FOLIO_FISCAL"
                                SelloSAT = "NO_VALIDO_TIMBRE_FISCAL"
                                fechaTimbrado = Date.Now
                                RfcPAC = ""
                                iTipoPAC = 0
                            End If
                        End Try

                    ElseIf dtPAC.Rows(i)("TipoPAC") = 2 Then 'iTimbre

                        frmStatusMessage.Show("Solicitado Timbre Fiscal...iTimbre")
                        frmStatusMessage.BringToFront()

                        Dim consulta As String = ObtenerConsultaiTimbre(sFolio, eRFC, dtPAC.Rows(i)("UserId"), dtPAC.Rows(i)("CustomerKey"), FileXML)
                        Dim content As Byte() = System.Text.Encoding.UTF8.GetBytes(consulta)

                        Dim url As String = dtPAC.Rows(i)("ServerTimbre")
                        Dim peticion As System.Net.HttpWebRequest = System.Net.WebRequest.Create(url)

                        peticion.Method = "POST"
                        peticion.ContentType = "application/x-www-form-urlencoded"
                        peticion.ContentLength = content.Length

                        Try
                            Dim requestStream As System.IO.Stream = peticion.GetRequestStream()

                            requestStream.Write(content, 0, content.Length)
                            requestStream.Close()

                            Dim resp As System.Net.HttpWebResponse = peticion.GetResponse()
                            Dim respuesta As String = New System.IO.StreamReader(resp.GetResponseStream).ReadToEnd

                            Dim respJson As Object = Newtonsoft.Json.Linq.JObject.Parse(respuesta)

                            If respJson.Item("result").item("retcode").Value = 1 OrElse respJson.Item("result").item("retcode").Value = 307 Then

                                If respJson.Item("result").item("retcode").Value = 1 Then
                                    UUID = respJson.Item("result").item("UUID").Value

                                    Dim Elementos As String() = respJson.Item("result").item("data").ToString.Split()

                                    For Each sElementos As String In Elementos
                                        If sElementos.Contains("FechaTimbrado=") Then
                                            fechaTimbrado = sElementos.Replace("FechaTimbrado=", "").Replace("""", "")
                                        End If
                                        If sElementos.Contains("noCertificadoSAT=") Then
                                            CertificadoSAT = sElementos.Replace("noCertificadoSAT=", "").Replace("""", "")
                                        End If
                                        'If sElementos.Contains("selloCFD=") Then
                                        '    oCFD.selloCFD = sElementos.Replace("selloCFD=", "").Replace("""", "")
                                        'End If
                                        If sElementos.Contains("selloSAT=") Then
                                            SelloSAT = sElementos.Replace("selloSAT=", "").Replace("""", "")
                                        End If
                                        If sElementos.Contains("version=") Then
                                            VersionSAT = sElementos.Replace("version=", "").Replace("""", "")
                                        End If
                                    Next
                                    RfcPAC = IIf(dtPAC.Rows(i)("RFC").GetType.Name = "DBNull", "", dtPAC.Rows(i)("RFC"))
                                    iTipoPAC = 2
                                    ModPOS.Ejecuta("sp_actualiza_timbre", "@CustomerKey", dtPAC.Rows(i)("CustomerKey"), "@TipoPAC", iTipoPAC)
                                    Exit For
                                Else
                                    frmStatusMessage.Show(respJson.Item("result").Item("error").Value.ToString() & ", Espere, lo estamos recuperando...iTimbre")

                                    ' Si ya fue timbrado entonces
                                    Dim indice As Integer = respJson.Item("result").Item("error").Value.ToString().IndexOf("UUID")
                                    UUID = respJson.Item("result").Item("error").Value.ToString().Substring(indice)
                                    UUID = UUID.Replace("UUID", "").Trim

                                    consulta = BuscarCFDiTimbre(dtPAC.Rows(i)("UserId"), dtPAC.Rows(i)("CustomerKey"), eRFC, sFolio, UUID)

                                    Dim content2 As Byte() = System.Text.Encoding.UTF8.GetBytes(consulta)
                                    Dim peticion2 As System.Net.HttpWebRequest = System.Net.WebRequest.Create(url)

                                    peticion2.Method = "POST"
                                    peticion2.ContentType = "application/x-www-form-urlencoded"
                                    peticion2.ContentLength = content2.Length


                                    Dim requestStream2 As System.IO.Stream = peticion2.GetRequestStream()

                                    requestStream2.Write(content2, 0, content2.Length)
                                    requestStream2.Close()

                                    Dim resp2 As System.Net.HttpWebResponse = peticion2.GetResponse()
                                    Dim respuesta2 As String = New System.IO.StreamReader(resp2.GetResponseStream).ReadToEnd

                                    Dim respJson2 As Object = Newtonsoft.Json.Linq.JObject.Parse(respuesta2)

                                    Dim jResult As Newtonsoft.Json.Linq.JArray = respJson2.Item("result").item("data")

                                    Dim Elementos As XmlDocument = New XmlDocument()

                                    Elementos.LoadXml(jResult.Item(0).Item("xml_data").ToString())

                                    Dim oXmlNodos As XmlNodeList = Elementos.GetElementsByTagName("cfdi:Complemento")

                                    Dim o As Integer

                                    For o = 0 To oXmlNodos.ItemOf(0).FirstChild.Attributes.Count - 1

                                        Select Case oXmlNodos.ItemOf(0).FirstChild.Attributes.ItemOf(o).Name
                                            Case Is = "FechaTimbrado"
                                                fechaTimbrado = oXmlNodos.ItemOf(0).FirstChild.Attributes.ItemOf(o).Value

                                            Case Is = "noCertificadoSAT"
                                                CertificadoSAT = oXmlNodos.ItemOf(0).FirstChild.Attributes.ItemOf(o).Value

                                            Case Is = "selloSAT"
                                                SelloSAT = oXmlNodos.ItemOf(0).FirstChild.Attributes.ItemOf(o).Value

                                            Case Is = "version"
                                                VersionSAT = oXmlNodos.ItemOf(0).FirstChild.Attributes.ItemOf(o).Value
                                        End Select

                                    Next
                                    RfcPAC = IIf(dtPAC.Rows(i)("RFC").GetType.Name = "DBNull", "", dtPAC.Rows(i)("RFC"))

                                    iTipoPAC = 2
                                    ModPOS.Ejecuta("sp_actualiza_timbre", "@CustomerKey", dtPAC.Rows(i)("CustomerKey"), "@TipoPAC", iTipoPAC)
                                    Exit For


                                End If
                            ElseIf i = dtPAC.Rows.Count - 1 Then
                                MsgBox("Se tuvo el siguiente error [" + respJson.Item("result").Item("retcode").Value.ToString() + "] " + respJson.Item("result").Item("error").Value.ToString())
                                UUID = "NO_VALIDO_FOLIO_FISCAL"
                                SelloSAT = "NO_VALIDO_TIMBRE_FISCAL"
                                fechaTimbrado = Date.Now
                                RfcPAC = ""
                                iTipoPAC = 0
                            End If
                        Catch ex As System.Net.WebException
                            If i = dtPAC.Rows.Count - 1 Then
                                MsgBox("Se tuvo el siguiente error [" & ex.Message & ", verfique su conexión] ")
                                UUID = "NO_VALIDO_FOLIO_FISCAL"
                                SelloSAT = "NO_VALIDO_TIMBRE_FISCAL"
                                fechaTimbrado = Date.Now
                                iTipoPAC = 0
                                RfcPAC = 0
                            End If
                        End Try

                    ElseIf dtPAC.Rows(i)("TipoPAC") = 3 Then 'DigitalInvoice

                        frmStatusMessage.Show("Solicitado Timbre Fiscal...Digital Invoice")
                        frmStatusMessage.BringToFront()

                        Dim xmlString As String

                        xmlString = oXml.OuterXml

                        Dim result As String

                        If oCFD.VersionCF = "3.3" Then
                            Dim client As DigitalInvoiceWS33.TimbradoClient = New DigitalInvoiceWS33.TimbradoClient("BasicHttpBinding_ITimbrado1")


                            client.ClientCredentials.UserName.UserName = dtPAC.Rows(i)("UserId")
                            client.ClientCredentials.UserName.Password = dtPAC.Rows(i)("CustomerKey")

                            client.Open()

                            Dim xmlBase64 As String = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(xmlString))
                            Dim xmlCFDI_Timbrado As String = String.Empty
                            Try

                                If dtPAC.Rows(i)("UserId") = "ELEPHANT_WORKS" Then
                                    xmlCFDI_Timbrado = client.TimbrarTestBase64(xmlBase64)
                                Else
                                    xmlCFDI_Timbrado = client.TimbrarBase64(xmlBase64)
                                End If
                                result = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(xmlCFDI_Timbrado))


                                Dim Elementos As String() = result.Split()

                                For Each sElementos As String In Elementos
                                    If sElementos.Contains("UUID=") Then
                                        UUID = sElementos.Replace("UUID=", "").Replace("""", "")
                                    End If
                                    If sElementos.Contains("FechaTimbrado=") Then
                                        fechaTimbrado = sElementos.Replace("FechaTimbrado=", "").Replace("""", "")
                                    End If
                                    If sElementos.Contains("NoCertificadoSAT=") Then
                                        CertificadoSAT = sElementos.Replace("NoCertificadoSAT=", "").Replace("""", "")
                                    End If

                                    If sElementos.Contains("SelloSAT=") Then
                                        SelloSAT = sElementos.Replace("SelloSAT=", "").Replace("""", "")
                                    End If
                                    If sElementos.Contains("Version=") Then
                                        VersionSAT = sElementos.Replace("Version=", "").Replace("""", "")
                                    End If

                                    If sElementos.Contains("RfcProvCertif=") Then
                                        RfcPAC = sElementos.Replace("RfcProvCertif=", "").Replace("""", "")
                                    End If
                                Next

                                iTipoPAC = 3
                                ModPOS.Ejecuta("sp_actualiza_timbre", "@CustomerKey", dtPAC.Rows(i)("CustomerKey"), "@TipoPAC", iTipoPAC)
                                Exit For

                            Catch ex As Exception

                                If ex.Message = "El CFDI contiene un timbre previo." Then

                                    xmlCFDI_Timbrado = client.RecuperarTimbreBase64(xmlBase64)

                                    result = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(xmlCFDI_Timbrado))


                                    Dim Elementos As String() = result.Split()

                                    For Each sElementos As String In Elementos
                                        If sElementos.Contains("UUID=") Then
                                            UUID = sElementos.Replace("UUID=", "").Replace("""", "")
                                        End If
                                        If sElementos.Contains("FechaTimbrado=") Then
                                            fechaTimbrado = sElementos.Replace("FechaTimbrado=", "").Replace("""", "")
                                        End If
                                        If sElementos.Contains("NoCertificadoSAT=") Then
                                            CertificadoSAT = sElementos.Replace("NoCertificadoSAT=", "").Replace("""", "")
                                        End If

                                        If sElementos.Contains("SelloSAT=") Then
                                            SelloSAT = sElementos.Replace("SelloSAT=", "").Replace("""", "")
                                        End If
                                        If sElementos.Contains("Version=") Then
                                            VersionSAT = sElementos.Replace("Version=", "").Replace("""", "")
                                        End If

                                        If sElementos.Contains("RfcProvCertif=") Then
                                            RfcPAC = sElementos.Replace("RfcProvCertif=", "").Replace("""", "")
                                        End If
                                    Next
                                    iTipoPAC = 3
                                    ModPOS.Ejecuta("sp_actualiza_timbre", "@CustomerKey", dtPAC.Rows(i)("CustomerKey"), "@TipoPAC", iTipoPAC)
                                    Exit For
                                Else
                                    If i = dtPAC.Rows.Count - 1 Then
                                        MsgBox("Se tuvo el siguiente error [" & ex.Message & ", verfique su conexión] ")
                                        UUID = "NO_VALIDO_FOLIO_FISCAL"
                                        SelloSAT = "NO_VALIDO_TIMBRE_FISCAL"
                                        fechaTimbrado = Date.Now
                                        iTipoPAC = 0
                                        RfcPAC = ""
                                    End If
                                End If

                            End Try

                        Else '3.2
                            Dim client As DigitalInvoiceWS.TimbradoClient = New DigitalInvoiceWS.TimbradoClient("BasicHttpBinding_ITimbrado")

                            'If oCFD.VersionCF = "3.3" Then
                            '    client.Endpoint.Address = New System.ServiceModel.EndpointAddress(dtPAC.Rows(i)("ServerTimbre").ToString)
                            'End If

                            client.ClientCredentials.UserName.UserName = dtPAC.Rows(i)("UserId")
                            client.ClientCredentials.UserName.Password = dtPAC.Rows(i)("CustomerKey")

                            client.Open()

                            Dim xmlBase64 As String = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(xmlString))
                            Dim xmlCFDI_Timbrado As String = String.Empty
                            Try

                                If dtPAC.Rows(i)("UserId") = "ELEPHANT_WORKS" Then
                                    xmlCFDI_Timbrado = client.TimbrarTestBase64(xmlBase64)
                                Else
                                    xmlCFDI_Timbrado = client.TimbrarBase64(xmlBase64)
                                End If
                                result = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(xmlCFDI_Timbrado))


                                Dim Elementos As String() = result.Split()

                                For Each sElementos As String In Elementos
                                    If sElementos.Contains("UUID=") Then
                                        UUID = sElementos.Replace("UUID=", "").Replace("""", "")
                                    End If
                                    If sElementos.Contains("FechaTimbrado=") Then
                                        fechaTimbrado = sElementos.Replace("FechaTimbrado=", "").Replace("""", "")
                                    End If
                                    If sElementos.Contains("noCertificadoSAT=") Then
                                        CertificadoSAT = sElementos.Replace("noCertificadoSAT=", "").Replace("""", "")
                                    End If

                                    If sElementos.Contains("selloSAT=") Then
                                        SelloSAT = sElementos.Replace("selloSAT=", "").Replace("""", "")
                                    End If
                                    If sElementos.Contains("version=") Then
                                        VersionSAT = sElementos.Replace("version=", "").Replace("""", "")
                                    End If
                                Next
                                RfcPAC = IIf(dtPAC.Rows(i)("RFC").GetType.Name = "DBNull", "", dtPAC.Rows(i)("RFC"))

                                iTipoPAC = 3
                                ModPOS.Ejecuta("sp_actualiza_timbre", "@CustomerKey", dtPAC.Rows(i)("CustomerKey"), "@TipoPAC", iTipoPAC)
                                Exit For

                            Catch ex As Exception

                                If ex.Message = "El CFDI contiene un timbre previo." Then

                                    xmlCFDI_Timbrado = client.RecuperarTimbreBase64(xmlBase64)

                                    result = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(xmlCFDI_Timbrado))


                                    Dim Elementos As String() = result.Split()

                                    For Each sElementos As String In Elementos
                                        If sElementos.Contains("UUID=") Then
                                            UUID = sElementos.Replace("UUID=", "").Replace("""", "")
                                        End If
                                        If sElementos.Contains("FechaTimbrado=") Then
                                            fechaTimbrado = sElementos.Replace("FechaTimbrado=", "").Replace("""", "")
                                        End If
                                        If sElementos.Contains("noCertificadoSAT=") Then
                                            CertificadoSAT = sElementos.Replace("noCertificadoSAT=", "").Replace("""", "")
                                        End If

                                        If sElementos.Contains("selloSAT=") Then
                                            SelloSAT = sElementos.Replace("selloSAT=", "").Replace("""", "")
                                        End If
                                        If sElementos.Contains("version=") Then
                                            VersionSAT = sElementos.Replace("version=", "").Replace("""", "")
                                        End If
                                    Next
                                    RfcPAC = IIf(dtPAC.Rows(i)("RFC").GetType.Name = "DBNull", "", dtPAC.Rows(i)("RFC"))

                                    iTipoPAC = 3
                                    ModPOS.Ejecuta("sp_actualiza_timbre", "@CustomerKey", dtPAC.Rows(i)("CustomerKey"), "@TipoPAC", iTipoPAC)
                                    Exit For
                                Else
                                    If i = dtPAC.Rows.Count - 1 Then
                                        MsgBox("Se tuvo el siguiente error [" & ex.Message & ", verfique su conexión] ")
                                        UUID = "NO_VALIDO_FOLIO_FISCAL"
                                        SelloSAT = "NO_VALIDO_TIMBRE_FISCAL"
                                        fechaTimbrado = Date.Now
                                        iTipoPAC = 0
                                        RfcPAC = ""
                                    End If
                                End If

                            End Try

                        End If

                    ElseIf dtPAC.Rows(i)("TipoPAC") = 4 Then 'Detecno

                        frmStatusMessage.Show("Solicitado Timbre Fiscal...Detecno")
                        frmStatusMessage.BringToFront()

                        Dim xmlString As String

                        xmlString = oXml.OuterXml

                        If oCFD.VersionCF = "3.3" Then

                            Dim client As DetecnoPAC33.DetecnoPacClient = New DetecnoPAC33.DetecnoPacClient()

                            Dim xmlRespuesta As DetecnoPAC33.Xml = New DetecnoPAC33.Xml()

                            If dtPAC.Rows(i)("UserId") = "AAAAAA\wsTIMBRADOR" Then
                                client.Endpoint.Address = New System.ServiceModel.EndpointAddress("https://test.timbra.mx/WCFTimbrador33/DetecnoPAC.svc")

                            Else
                                If dtPAC.Rows(i)("ServerTimbre") = "" Then
                                    client.Endpoint.Address = New System.ServiceModel.EndpointAddress("https://www.timbra.mx/WCFTimbrador33/DetecnoPac.svc")
                                Else
                                    client.Endpoint.Address = New System.ServiceModel.EndpointAddress(dtPAC.Rows(i)("ServerTimbre").ToString)
                                End If

                            End If

                            xmlRespuesta = client.TimbrarCfdi(dtPAC.Rows(i)("UserId"), dtPAC.Rows(i)("CustomerKey"), xmlString)



                            If xmlRespuesta.Success Then
                                Dim strXmlTfd As String = xmlRespuesta.XmlTfd
                                ' Dim strCoTfd As String = xmlRespuesta.CoTfd
                                'Dim strQR As String = xmlRespuesta.StrQr

                                Dim Elementos As String() = strXmlTfd.Split()

                                For Each sElementos As String In Elementos

                                    If sElementos.Contains("UUID=") Then
                                        UUID = sElementos.Replace("UUID=", "").Replace("""", "")
                                    End If
                                    If sElementos.Contains("FechaTimbrado=") Then
                                        fechaTimbrado = sElementos.Replace("FechaTimbrado=", "").Replace("""", "")
                                    End If
                                    If sElementos.Contains("NoCertificadoSAT=") Then
                                        CertificadoSAT = sElementos.Replace("NoCertificadoSAT=", "").Replace("""", "")
                                    End If

                                    If sElementos.Contains("SelloSAT=") Then
                                        SelloSAT = sElementos.Replace("SelloSAT=", "").Replace("""", "")
                                    End If
                                    If sElementos.Contains("Version=") Then
                                        VersionSAT = sElementos.Replace("Version=", "").Replace("""", "")
                                    End If

                                    If sElementos.Contains("RfcProvCertif=") Then
                                        RfcPAC = sElementos.Replace("RfcProvCertif=", "").Replace("""", "")
                                    End If
                                Next


                                iTipoPAC = 4
                                ModPOS.Ejecuta("sp_actualiza_timbre", "@CustomerKey", dtPAC.Rows(i)("CustomerKey"), "@TipoPAC", iTipoPAC)
                                Exit For

                            Else
                                Dim sError As String = xmlRespuesta.ErrDesc

                                If i = dtPAC.Rows.Count - 1 Then
                                    MsgBox("Se tuvo el siguiente error [" & sError)
                                    UUID = "NO_VALIDO_FOLIO_FISCAL"
                                    SelloSAT = "NO_VALIDO_TIMBRE_FISCAL"
                                    fechaTimbrado = Date.Now
                                    iTipoPAC = 0
                                    RfcPAC = ""
                                End If


                            End If

                        Else 'Version 3.2
                            Dim client As DetecnoPAC.DetecnoPacClient = New DetecnoPAC.DetecnoPacClient()

                            Dim xmlRespuesta As DetecnoPAC.Xml = New DetecnoPAC.Xml()

                            If dtPAC.Rows(i)("UserId") = "AAAAAA\wsTIMBRADOR" Then
                                client.Endpoint.Address = New System.ServiceModel.EndpointAddress("https://test.timbra.mx/WCFTimbrador/DetecnoPAC.svc")
                            Else
                                If dtPAC.Rows(i)("ServerTimbre") = "" Then
                                    client.Endpoint.Address = New System.ServiceModel.EndpointAddress("https://www.timbra.mx/WCFTimbrador/DetecnoPac.svc")
                                Else
                                    client.Endpoint.Address = New System.ServiceModel.EndpointAddress(dtPAC.Rows(i)("ServerTimbre").ToString)
                                End If

                            End If

                            xmlRespuesta = client.TimbrarCfdi(dtPAC.Rows(i)("UserId"), dtPAC.Rows(i)("CustomerKey"), xmlString)


                            If xmlRespuesta.Success Then
                                Dim strXmlTfd As String = xmlRespuesta.XmlTfd
                                ' Dim strCoTfd As String = xmlRespuesta.CoTfd
                                'Dim strQR As String = xmlRespuesta.StrQr

                                Dim Elementos As String() = strXmlTfd.Split()

                                For Each sElementos As String In Elementos
                                    If sElementos.Contains("UUID=") Then
                                        UUID = sElementos.Replace("UUID=", "").Replace("""", "")
                                    End If
                                    If sElementos.Contains("FechaTimbrado=") Then
                                        fechaTimbrado = sElementos.Replace("FechaTimbrado=", "").Replace("""", "")
                                    End If
                                    If sElementos.Contains("noCertificadoSAT=") Then
                                        CertificadoSAT = sElementos.Replace("noCertificadoSAT=", "").Replace("""", "")
                                    End If

                                    If sElementos.Contains("selloSAT=") Then
                                        SelloSAT = sElementos.Replace("selloSAT=", "").Replace("""", "")
                                    End If
                                    If sElementos.Contains("version=") Then
                                        VersionSAT = sElementos.Replace("version=", "").Replace("""", "")
                                    End If
                                Next

                                RfcPAC = IIf(dtPAC.Rows(i)("RFC").GetType.Name = "DBNull", "", dtPAC.Rows(i)("RFC"))

                                iTipoPAC = 4
                                ModPOS.Ejecuta("sp_actualiza_timbre", "@CustomerKey", dtPAC.Rows(i)("CustomerKey"), "@TipoPAC", iTipoPAC)
                                Exit For

                            Else
                                Dim sError As String = xmlRespuesta.ErrDesc

                                If i = dtPAC.Rows.Count - 1 Then
                                    MsgBox("Se tuvo el siguiente error [" & sError)
                                    UUID = "NO_VALIDO_FOLIO_FISCAL"
                                    SelloSAT = "NO_VALIDO_TIMBRE_FISCAL"
                                    fechaTimbrado = Date.Now
                                    iTipoPAC = 0
                                    RfcPAC = ""
                                End If


                            End If


                        End If

                    End If
                Next


                ' Area comun de timbrado

                frmStatusMessage.Dispose()

                CBB = ModPOS.crearQR33(eRFC, RFC, total, UUID, Right(oCFD.sello, 8))


                If iTipoPAC = 0 Then
                    oXml.Save(FileXML)
                Else
                    Dim newElem As XmlElement = oXml.CreateElement("cfdi", "Complemento", "http://www.sat.gob.mx/cfd/3")

                    Dim newEle1 As XmlElement = oXml.CreateElement("tfd", "TimbreFiscalDigital", "http://www.sat.gob.mx/TimbreFiscalDigital")
                    ' 1. Create a new Book element.


                    Dim newAttr As XmlAttribute

                    newAttr = oXml.CreateAttribute("xsi", "schemaLocation", "http://www.w3.org/2001/XMLSchema-instance")
                    newAttr.Value = "http://www.sat.gob.mx/TimbreFiscalDigital http://www.sat.gob.mx/sitio_internet/cfd/TimbreFiscalDigital/TimbreFiscalDigitalv11.xsd"
                    newEle1.Attributes.Append(newAttr)



                    newAttr = oXml.CreateAttribute("Version")
                    newAttr.Value = VersionSAT
                    newEle1.Attributes.Append(newAttr)

                    newAttr = oXml.CreateAttribute("UUID")
                    newAttr.Value = UUID
                    newEle1.Attributes.Append(newAttr)


                    newAttr = oXml.CreateAttribute("FechaTimbrado")
                    newAttr.Value = String.Format("{0:yyyy-MM-ddTHH:mm:ss}", fechaTimbrado)
                    newEle1.Attributes.Append(newAttr)

                    newAttr = oXml.CreateAttribute("RfcProvCertif")
                    newAttr.Value = RfcPAC
                    newEle1.Attributes.Append(newAttr)

                    newAttr = oXml.CreateAttribute("SelloCFD")
                    newAttr.Value = sello
                    newEle1.Attributes.Append(newAttr)

                    newAttr = oXml.CreateAttribute("noCertificadoSAT")
                    newAttr.Value = CertificadoSAT
                    newEle1.Attributes.Append(newAttr)

                    newAttr = oXml.CreateAttribute("SelloSAT")
                    newAttr.Value = SelloSAT
                    newEle1.Attributes.Append(newAttr)


                    newElem.AppendChild(newEle1)
                    oXml.DocumentElement.AppendChild(newElem)
                    oXml.Save(FileXML)

                End If
            End If
        End If


        If TipoAccion = 1 OrElse TipoAccion = 2 OrElse TipoAccion = 4 Then

            If iTipoPAC = 0 Then
                fechaTimbrado = CDate(oCFD.Fecha)
            End If

            If TipoComprobante = "I" Then
                ModPOS.Ejecuta("st_inserta_selloAbono", "@ABNClave", sDOCClave, "@CBB", CBB, "@Certificado", oCFD.noCertificado, "@cadenaOriginal", oCFD.cadenaOriginal, "@Sello", oCFD.sello, "@Certificado64", oCFD.Certificado64, "@UUID", UUID, "@SelloSAT", SelloSAT, "@CertificadoSAT", CertificadoSAT, "@fechaTimbrado", fechaTimbrado, "@versionSAT", VersionSAT, "@TipoPAC", iTipoPAC, "@regimenFiscal", oCFD.regimenFiscal, "@RfcProvCertif", RfcPAC, "@versionCF", oCFD.VersionCF, "@estado", IIf(iTipoPAC = 0, 2, 1))
            Else
                ModPOS.Ejecuta("st_inserta_selloAnticipo", "@ANTClave", sDOCClave, "@CBB", CBB, "@Certificado", oCFD.noCertificado, "@cadenaOriginal", oCFD.cadenaOriginal, "@Sello", oCFD.sello, "@Certificado64", oCFD.Certificado64, "@UUID", UUID, "@SelloSAT", SelloSAT, "@CertificadoSAT", CertificadoSAT, "@fechaTimbrado", fechaTimbrado, "@versionSAT", VersionSAT, "@TipoPAC", iTipoPAC, "@regimenFiscal", oCFD.regimenFiscal, "@RfcProvCertif", RfcPAC, "@versionCF", oCFD.VersionCF)

            End If
        End If


        If iTipoPAC <> 0 Then
            'Verifica que exista el path
            Try
                If System.IO.Directory.Exists(PathXML) Then

                    oPath = PathXML
                    If oPath.Length > 3 AndAlso oPath.Substring(oPath.Length - 1, 1) <> "\" Then
                        oPath &= "\"
                    End If


                    oPath &= fechaPath.Year.ToString & "\" & fechaPath.Month.ToString & "\" & fechaPath.Day.ToString & "\"

                    If Not System.IO.Directory.Exists(oPath) Then
                        System.IO.Directory.CreateDirectory(oPath)
                    End If

                    oFileXML = oPath & sFolio & ".xml"

                    If System.IO.File.Exists(oFileXML) Then
                        If FileXML <> oFileXML Then
                            System.IO.File.Delete(oFileXML)
                        End If
                    End If




                    'Verifica si existe carpeta Temp
                    If sInterfazSalida <> "" Then
                        Try
                            If Not System.IO.Directory.Exists(PathXML & "\Temp") Then
                                System.IO.Directory.CreateDirectory(PathXML & "\Temp")
                            End If

                            Dim oTemp As String
                            If PathXML.Length <= 3 Then
                                oTemp = PathXML & "Temp\" & sFolio & ".xml"
                            ElseIf PathXML.Substring(PathXML.Length - 1, 1) = "\" Then
                                oTemp = PathXML & "Temp\" & sFolio & ".xml"
                            Else
                                oTemp = PathXML & "\" & "Temp\" & sFolio & ".xml"
                            End If

                            If System.IO.File.Exists(oTemp) Then
                                If FileXML <> oTemp Then
                                    System.IO.File.Delete(oTemp)
                                End If
                            End If
                            If FileXML <> oTemp Then
                                System.IO.File.Copy(FileXML, oTemp)
                            End If


                        Catch ex As Exception
                        End Try


                    End If

                    If FileXML <> oFileXML Then
                        System.IO.File.Move(FileXML, oFileXML)
                    End If


                Else
                    If bShowMsg = True Then

                        MessageBox.Show("El directorio " & PathXML & " no existe o no se puede tener acceso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            Catch ex As Exception
            End Try

        End If

        If TipoComprobante = "E" AndAlso sInterfazSalida <> "" AndAlso TipoAccion <> 3 AndAlso TipoAccion <> 4 AndAlso iTipoPAC <> 0 Then
            Dim sFecha, InterfazAnticipos As String
            Dim dt As DataTable
            sFecha = DateTime.Now.ToString("yyyyMMdd_HHmmssfff")


            dt = Recupera_Tabla("st_recupera_interfaz", "@Interfaz", "AplicacionAnticipo", "@COMClave", ModPOS.CompanyActual)
            If dt.Rows.Count > 0 Then
                InterfazAnticipos = CStr(dt.Rows(0)("sp"))
            Else
                InterfazAnticipos = ""
            End If
            dt.Dispose()

            If InterfazAnticipos <> "" Then



                sFecha = DateTime.Now.ToString("yyyyMMdd_HHmmssfff")


                ModPOS.Ejecuta(InterfazAnticipos, "@Folio", sDOCClave, "@TipoDocumento", 2, "@Path", sInterfazSalida, "@Fecha", sFecha)


            End If



        End If



        Return iTipoPAC

    End Function


    Public Function crearXmlTraslado(ByVal TipoAccion As Integer, ByVal dtPAC As DataTable, ByVal PathXML As String, ByVal sFolio As String, ByVal sDOCClave As String, Optional ByVal oCFD As CFD = Nothing, Optional ByVal dtConcepto As DataTable = Nothing, Optional ByVal sInterfazSalida As String = "") As Integer
      

        Dim i As Integer
        Dim FileXML, oFileXML, oPath As String
        Dim sPre As String = ""
        Dim iTipoPAC As Integer = 0

        Dim VersionCF As String = ""
        Dim eRFC As String = ""
        Dim RFC As String = ""
        Dim sello As String = ""
        Dim UUID As String = ""
        Dim SelloSAT As String = ""
        Dim CertificadoSAT As String = ""
        Dim VersionSAT As String = ""
        Dim RfcPAC As String = ""

        Dim fechaTimbrado, fechaPath As Date
        Dim total As Double

        Dim CBB() As Byte = Nothing

        FileXML = pathActual & "CFD\" & sFolio & ".xml"

        If TipoAccion = 1 OrElse TipoAccion = 3 OrElse TipoAccion = 4 Then 'Crea por primera vez el XML o regenerar xml

            fechaPath = oCFD.Fecha
            VersionCF = oCFD.VersionCF

            If oCFD.TipoCF = 2 Then
                sPre = "cfdi:"
            End If

            Dim textWriter As System.Xml.XmlTextWriter = New System.Xml.XmlTextWriter(FileXML, System.Text.Encoding.UTF8)
            textWriter.Formatting = System.Xml.Formatting.None
            ' Opens the document
            textWriter.WriteStartDocument()

            textWriter.WriteStartElement(sPre & "Comprobante")

            Select Case oCFD.VersionCF
                Case Is = "3.3"
                    textWriter.WriteAttributeString("xmlns:cfdi", "http://www.sat.gob.mx/cfd/3")
                    textWriter.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance")
                    textWriter.WriteAttributeString("xsi:schemaLocation", "http://www.sat.gob.mx/cfd/3 http://www.sat.gob.mx/sitio_internet/cfd/3/cfdv33.xsd")
                    textWriter.WriteAttributeString("Version", oCFD.VersionCF)

                    textWriter.WriteAttributeString("Folio", oCFD.Folio)
                    textWriter.WriteAttributeString("Fecha", oCFD.Fecha)
                    textWriter.WriteAttributeString("Sello", oCFD.sello)
                    ' textWriter.WriteAttributeString("FormaPago", spaceFormat(oCFD.metodoDePago))
                    textWriter.WriteAttributeString("NoCertificado", oCFD.noCertificado)
                    textWriter.WriteAttributeString("Certificado", oCFD.Certificado64)
                    textWriter.WriteAttributeString("SubTotal", "0.00")
                    textWriter.WriteAttributeString("Moneda", oCFD.Moneda)
                    textWriter.WriteAttributeString("Total", "0.00")
                    textWriter.WriteAttributeString("TipoDeComprobante", "T")
                    textWriter.WriteAttributeString("LugarExpedicion", spaceFormat(oCFD.sCodigoPostal))
                    textWriter.WriteStartElement(sPre & "Emisor")
                    textWriter.WriteAttributeString("Rfc", spaceFormat(oCFD.eRFC))
                    textWriter.WriteAttributeString("Nombre", spaceFormat(oCFD.eRazonSocial))
                    textWriter.WriteAttributeString("RegimenFiscal", spaceFormat(oCFD.regimenFiscal))
                    'Cierre de Emisor
                    textWriter.WriteEndElement()

                    textWriter.WriteStartElement(sPre & "Receptor")
                    textWriter.WriteAttributeString("Rfc", oCFD.RFC)
                    'Clave del uso que dara al comprobante fiscal de acuerdo a catalogo del SAT
                    textWriter.WriteAttributeString("UsoCFDI", "P01")
                    'Cierre de Receptor
                    textWriter.WriteEndElement()

            End Select


            textWriter.WriteStartElement(sPre & "Conceptos")
            'Inicia for para llenar detalle
            Dim foundRows() As DataRow
            foundRows = dtConcepto.Select("TRSClave = '" & oCFD.DOCClave & "'")

            Dim ClaveProdServ, ClaveUnidad As String

            If foundRows.GetLength(0) > 0 Then
                For i = 0 To foundRows.GetUpperBound(0)


                    textWriter.WriteStartElement(sPre & "Concepto")
                    'Clave de producto o servicio de acuerdo a catalogo sat
                    If foundRows(i)("ClaveProdServ").GetType.Name = "DBNull" OrElse foundRows(i)("ClaveProdServ") = "" Then
                        ClaveProdServ = "01010101"
                    Else
                        ClaveProdServ = foundRows(i)("ClaveProdServ")
                    End If

                    If foundRows(i)("ClaveUnidad").GetType.Name = "DBNull" OrElse foundRows(i)("ClaveUnidad") = "" Then
                        ClaveUnidad = "H87"
                    Else
                        ClaveUnidad = foundRows(i)("ClaveUnidad")
                    End If

                    textWriter.WriteAttributeString("ClaveProdServ", ClaveProdServ)
                    textWriter.WriteAttributeString("NoIdentificacion", spaceFormat(foundRows(i)("Clave")))
                    textWriter.WriteAttributeString("Cantidad", QuitarCeros(foundRows(i)("Cantidad")))
                    'Clave de unidad de acuerdo a catalogo de sat
                    textWriter.WriteAttributeString("ClaveUnidad", ClaveUnidad)
                    textWriter.WriteAttributeString("Unidad", foundRows(i)("Unidad"))
                    textWriter.WriteAttributeString("Descripcion", spaceFormat(CStr(foundRows(i)("Descripción")).Trim))
                    textWriter.WriteAttributeString("ValorUnitario", "0.00")
                    textWriter.WriteAttributeString("Importe", "0.00")

                    If foundRows(i)("Pedimento") <> "" Then
                        textWriter.WriteStartElement(sPre & "InformacionAduanera")
                        textWriter.WriteAttributeString("NumeroPedimento", foundRows(i)("Pedimento"))
                        textWriter.WriteEndElement()
                    End If

                    'Cierre concepto
                    textWriter.WriteEndElement()
                Next
                'Fin de ciclo
            End If
            'Cierre de Conceptos
            textWriter.WriteEndElement()

            'Cierre de Comprobante
            textWriter.WriteEndElement()
            ' Ends the document.
            textWriter.WriteEndDocument()
            ' close writer
            textWriter.Close()


            eRFC = oCFD.eRFC
            RFC = oCFD.RFC
            total = oCFD.total
            sello = oCFD.sello

        End If 'Finaliza Creacion del XML

        If TipoAccion = 2 Then ' Si es un reintento de timbrado

            oCFD = New CFD

            Dim dt As DataTable

            dt = ModPOS.Recupera_Tabla("st_sello_traslado", "@TRSClave", sDOCClave)
            sello = IIf(dt.Rows(0)("Sello").GetType.Name = "DBNull", "", dt.Rows(0)("Sello"))
            VersionCF = dt.Rows(0)("VersionCF")
            dt.Dispose()

            dt = ModPOS.Recupera_Tabla("st_encabezado_traslado", "@TRSClave", sDOCClave)
            eRFC = dt.Rows(0)("eRFC")
            RFC = "XAXX010101000"
            total = 0
            fechaPath = dt.Rows(0)("FechaRegistro")


            dt.Dispose()


            oCFD.VersionCF = VersionCF

            oPath = PathXML
            If oPath.Length > 3 AndAlso oPath.Substring(oPath.Length - 1, 1) <> "\" Then
                oPath &= "\"
            End If

            oPath &= fechaPath.Year.ToString & "\" & fechaPath.Month.ToString & "\" & fechaPath.Day.ToString & "\"


            If Not System.IO.File.Exists(FileXML) Then
                If System.IO.File.Exists(oPath & sFolio & ".xml") Then
                    System.IO.File.Copy(oPath & sFolio & ".xml", FileXML)
                Else
                    MessageBox.Show("El archivo " & oPath & sFolio & ".xml no existe o se cambio de lugar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    Exit Function
                End If
            End If


        End If ' Finaliza reintento 



        If TipoAccion <> 3 Then
            If TipoAccion = 2 OrElse oCFD.TipoCF = 2 Then ' Inicia timbrado


                Dim oXml As New XmlDocument()
                oXml.Load(FileXML)

                Dim frmStatusMessage As New frmStatus

                For i = 0 To dtPAC.Rows.Count - 1
                    If dtPAC.Rows(i)("TipoPAC") = 1 Then ' Tralix

                        frmStatusMessage.Show("Solicitado Timbre Fiscal...Tralix")
                        frmStatusMessage.BringToFront()

                        Dim oCfdi As New LibCFDiTralix.CFDiTralix()

                        Dim oTimbre As LibCFDiTralix.com.tralix.pac.TimbreFiscalDigital

                        'https://pruebastfd.tralix.com:7070
                        Try
                            oTimbre = oCfdi.TimbrarCFDi(oXml.OuterXml, dtPAC.Rows(i)("ServerTimbre"), dtPAC.Rows(i)("Customerkey"))

                            If oTimbre Is Nothing AndAlso i = dtPAC.Rows.Count - 1 Then
                                MsgBox("Se tuvo el siguiente error " + vbCrLf + "[" + CType(LibCFDiTralix.CodigoMensaje.eCodigo, Integer).ToString() + "]" + LibCFDiTralix.CodigoMensaje.eCodigo.ToString() + ": " + LibCFDiTralix.CodigoMensaje.sMensaje)
                                UUID = "NO_VALIDO_FOLIO_FISCAL"
                                SelloSAT = "NO_VALIDO_TIMBRE_FISCAL"
                                iTipoPAC = 0
                                fechaTimbrado = Date.Now
                                RfcPAC = ""
                            ElseIf Not oTimbre Is Nothing Then
                                UUID = oTimbre.UUID
                                SelloSAT = oTimbre.selloSAT
                                CertificadoSAT = oTimbre.noCertificadoSAT
                                fechaTimbrado = oTimbre.FechaTimbrado
                                VersionSAT = oTimbre.version
                                iTipoPAC = 1
                                ModPOS.Ejecuta("sp_actualiza_timbre", "@CustomerKey", dtPAC.Rows(i)("CustomerKey"), "@TipoPAC", iTipoPAC)
                                RfcPAC = IIf(dtPAC.Rows(i)("RFC").GetType.Name = "DBNull", "", dtPAC.Rows(i)("RFC"))
                                Exit For
                            End If

                        Catch ex As System.Net.WebException
                            If i = dtPAC.Rows.Count - 1 Then
                                MsgBox("Se tuvo el siguiente error [" & ex.Message & ", verfique su conexión] ")
                                UUID = "NO_VALIDO_FOLIO_FISCAL"
                                SelloSAT = "NO_VALIDO_TIMBRE_FISCAL"
                                fechaTimbrado = Date.Now
                                iTipoPAC = 0
                                RfcPAC = ""
                            End If
                        End Try

                    ElseIf dtPAC.Rows(i)("TipoPAC") = 2 Then 'iTimbre

                        frmStatusMessage.Show("Solicitado Timbre Fiscal...iTimbre")
                        frmStatusMessage.BringToFront()

                        Dim consulta As String = ObtenerConsultaiTimbre(sFolio, eRFC, dtPAC.Rows(i)("UserId"), dtPAC.Rows(i)("CustomerKey"), FileXML)
                        Dim content As Byte() = System.Text.Encoding.UTF8.GetBytes(consulta)

                        Dim url As String = dtPAC.Rows(i)("ServerTimbre")
                        Dim peticion As System.Net.HttpWebRequest = System.Net.WebRequest.Create(url)

                        peticion.Method = "POST"
                        peticion.ContentType = "application/x-www-form-urlencoded"
                        peticion.ContentLength = content.Length

                        Try
                            Dim requestStream As System.IO.Stream = peticion.GetRequestStream()

                            requestStream.Write(content, 0, content.Length)
                            requestStream.Close()

                            Dim resp As System.Net.HttpWebResponse = peticion.GetResponse()
                            Dim respuesta As String = New System.IO.StreamReader(resp.GetResponseStream).ReadToEnd

                            Dim respJson As Object = Newtonsoft.Json.Linq.JObject.Parse(respuesta)

                            If respJson.Item("result").item("retcode").Value = 1 OrElse respJson.Item("result").item("retcode").Value = 307 Then

                                If respJson.Item("result").item("retcode").Value = 1 Then
                                    UUID = respJson.Item("result").item("UUID").Value

                                    Dim Elementos As String() = respJson.Item("result").item("data").ToString.Split()

                                    For Each sElementos As String In Elementos
                                        If sElementos.Contains("FechaTimbrado=") Then
                                            fechaTimbrado = sElementos.Replace("FechaTimbrado=", "").Replace("""", "")
                                        End If
                                        If sElementos.Contains("noCertificadoSAT=") Then
                                            CertificadoSAT = sElementos.Replace("noCertificadoSAT=", "").Replace("""", "")
                                        End If
                                        'If sElementos.Contains("selloCFD=") Then
                                        '    oCFD.selloCFD = sElementos.Replace("selloCFD=", "").Replace("""", "")
                                        'End If
                                        If sElementos.Contains("selloSAT=") Then
                                            SelloSAT = sElementos.Replace("selloSAT=", "").Replace("""", "")
                                        End If
                                        If sElementos.Contains("version=") Then
                                            VersionSAT = sElementos.Replace("version=", "").Replace("""", "")
                                        End If
                                    Next

                                    RfcPAC = IIf(dtPAC.Rows(i)("RFC").GetType.Name = "DBNull", "", dtPAC.Rows(i)("RFC"))

                                    iTipoPAC = 2
                                    ModPOS.Ejecuta("sp_actualiza_timbre", "@CustomerKey", dtPAC.Rows(i)("CustomerKey"), "@TipoPAC", iTipoPAC)
                                    Exit For
                                Else
                                    frmStatusMessage.Show(respJson.Item("result").Item("error").Value.ToString() & ", Espere, lo estamos recuperando...iTimbre")

                                    ' Si ya fue timbrado entonces
                                    Dim indice As Integer = respJson.Item("result").Item("error").Value.ToString().IndexOf("UUID")
                                    UUID = respJson.Item("result").Item("error").Value.ToString().Substring(indice)
                                    UUID = UUID.Replace("UUID", "").Trim
                                    RfcPAC = ""
                                    consulta = BuscarCFDiTimbre(dtPAC.Rows(i)("UserId"), dtPAC.Rows(i)("CustomerKey"), eRFC, sFolio, UUID)

                                    Dim content2 As Byte() = System.Text.Encoding.UTF8.GetBytes(consulta)
                                    Dim peticion2 As System.Net.HttpWebRequest = System.Net.WebRequest.Create(url)

                                    peticion2.Method = "POST"
                                    peticion2.ContentType = "application/x-www-form-urlencoded"
                                    peticion2.ContentLength = content2.Length


                                    Dim requestStream2 As System.IO.Stream = peticion2.GetRequestStream()

                                    requestStream2.Write(content2, 0, content2.Length)
                                    requestStream2.Close()

                                    Dim resp2 As System.Net.HttpWebResponse = peticion2.GetResponse()
                                    Dim respuesta2 As String = New System.IO.StreamReader(resp2.GetResponseStream).ReadToEnd

                                    Dim respJson2 As Object = Newtonsoft.Json.Linq.JObject.Parse(respuesta2)

                                    Dim jResult As Newtonsoft.Json.Linq.JArray = respJson2.Item("result").item("data")

                                    Dim Elementos As XmlDocument = New XmlDocument()

                                    Elementos.LoadXml(jResult.Item(0).Item("xml_data").ToString())

                                    Dim oXmlNodos As XmlNodeList = Elementos.GetElementsByTagName("cfdi:Complemento")

                                    Dim o As Integer

                                    For o = 0 To oXmlNodos.ItemOf(0).FirstChild.Attributes.Count - 1

                                        Select Case oXmlNodos.ItemOf(0).FirstChild.Attributes.ItemOf(o).Name
                                            Case Is = "FechaTimbrado"
                                                fechaTimbrado = oXmlNodos.ItemOf(0).FirstChild.Attributes.ItemOf(o).Value

                                            Case Is = "noCertificadoSAT"
                                                CertificadoSAT = oXmlNodos.ItemOf(0).FirstChild.Attributes.ItemOf(o).Value

                                            Case Is = "selloSAT"
                                                SelloSAT = oXmlNodos.ItemOf(0).FirstChild.Attributes.ItemOf(o).Value

                                            Case Is = "version"
                                                VersionSAT = oXmlNodos.ItemOf(0).FirstChild.Attributes.ItemOf(o).Value
                                        End Select

                                    Next
                                    RfcPAC = IIf(dtPAC.Rows(i)("RFC").GetType.Name = "DBNull", "", dtPAC.Rows(i)("RFC"))

                                    iTipoPAC = 2
                                    ModPOS.Ejecuta("sp_actualiza_timbre", "@CustomerKey", dtPAC.Rows(i)("CustomerKey"), "@TipoPAC", iTipoPAC)
                                    Exit For


                                End If
                            ElseIf i = dtPAC.Rows.Count - 1 Then
                                MsgBox("Se tuvo el siguiente error [" + respJson.Item("result").Item("retcode").Value.ToString() + "] " + respJson.Item("result").Item("error").Value.ToString())
                                UUID = "NO_VALIDO_FOLIO_FISCAL"
                                SelloSAT = "NO_VALIDO_TIMBRE_FISCAL"
                                fechaTimbrado = Date.Now
                                iTipoPAC = 0
                                RfcPAC = ""
                            End If
                        Catch ex As System.Net.WebException
                            If i = dtPAC.Rows.Count - 1 Then
                                MsgBox("Se tuvo el siguiente error [" & ex.Message & ", verfique su conexión] ")
                                UUID = "NO_VALIDO_FOLIO_FISCAL"
                                SelloSAT = "NO_VALIDO_TIMBRE_FISCAL"
                                fechaTimbrado = Date.Now
                                iTipoPAC = 0
                                RfcPAC = ""
                            End If
                        End Try

                    ElseIf dtPAC.Rows(i)("TipoPAC") = 3 Then 'DigitalInvoice

                        frmStatusMessage.Show("Solicitado Timbre Fiscal...Digital Invoice")
                        frmStatusMessage.BringToFront()

                        Dim xmlString As String

                        xmlString = oXml.OuterXml

                        Dim result As String

                        If oCFD.VersionCF = "3.3" Then
                            Dim client As DigitalInvoiceWS33.TimbradoClient = New DigitalInvoiceWS33.TimbradoClient("BasicHttpBinding_ITimbrado1")


                            client.ClientCredentials.UserName.UserName = dtPAC.Rows(i)("UserId")
                            client.ClientCredentials.UserName.Password = dtPAC.Rows(i)("CustomerKey")

                            client.Open()

                            Dim xmlBase64 As String = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(xmlString))
                            Dim xmlCFDI_Timbrado As String = String.Empty
                            Try

                                If dtPAC.Rows(i)("UserId") = "ELEPHANT_WORKS" Then
                                    xmlCFDI_Timbrado = client.TimbrarTestBase64(xmlBase64)
                                Else
                                    xmlCFDI_Timbrado = client.TimbrarBase64(xmlBase64)
                                End If
                                result = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(xmlCFDI_Timbrado))


                                Dim Elementos As String() = result.Split()

                                For Each sElementos As String In Elementos
                                    If sElementos.Contains("UUID=") Then
                                        UUID = sElementos.Replace("UUID=", "").Replace("""", "")
                                    End If
                                    If sElementos.Contains("FechaTimbrado=") Then
                                        fechaTimbrado = sElementos.Replace("FechaTimbrado=", "").Replace("""", "")
                                    End If
                                    If sElementos.Contains("NoCertificadoSAT=") Then
                                        CertificadoSAT = sElementos.Replace("NoCertificadoSAT=", "").Replace("""", "")
                                    End If

                                    If sElementos.Contains("SelloSAT=") Then
                                        SelloSAT = sElementos.Replace("SelloSAT=", "").Replace("""", "")
                                    End If
                                    If sElementos.Contains("Version=") Then
                                        VersionSAT = sElementos.Replace("Version=", "").Replace("""", "")
                                    End If

                                    If sElementos.Contains("RfcProvCertif=") Then
                                        RfcPAC = sElementos.Replace("RfcProvCertif=", "").Replace("""", "")
                                    End If

                                Next
                              
                                iTipoPAC = 3
                                ModPOS.Ejecuta("sp_actualiza_timbre", "@CustomerKey", dtPAC.Rows(i)("CustomerKey"), "@TipoPAC", iTipoPAC)
                                Exit For

                            Catch ex As Exception

                                If ex.Message = "El CFDI contiene un timbre previo." Then

                                    xmlCFDI_Timbrado = client.RecuperarTimbreBase64(xmlBase64)

                                    result = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(xmlCFDI_Timbrado))


                                    Dim Elementos As String() = result.Split()

                                    For Each sElementos As String In Elementos
                                        If sElementos.Contains("UUID=") Then
                                            UUID = sElementos.Replace("UUID=", "").Replace("""", "")
                                        End If
                                        If sElementos.Contains("FechaTimbrado=") Then
                                            fechaTimbrado = sElementos.Replace("FechaTimbrado=", "").Replace("""", "")
                                        End If
                                        If sElementos.Contains("NoCertificadoSAT=") Then
                                            CertificadoSAT = sElementos.Replace("NoCertificadoSAT=", "").Replace("""", "")
                                        End If

                                        If sElementos.Contains("SelloSAT=") Then
                                            SelloSAT = sElementos.Replace("SelloSAT=", "").Replace("""", "")
                                        End If
                                        If sElementos.Contains("Version=") Then
                                            VersionSAT = sElementos.Replace("Version=", "").Replace("""", "")
                                        End If

                                        If sElementos.Contains("RfcProvCertif=") Then
                                            RfcPAC = sElementos.Replace("RfcProvCertif=", "").Replace("""", "")
                                        End If
                                    Next
                                    iTipoPAC = 3
                                    ModPOS.Ejecuta("sp_actualiza_timbre", "@CustomerKey", dtPAC.Rows(i)("CustomerKey"), "@TipoPAC", iTipoPAC)
                                    Exit For
                                Else
                                    If i = dtPAC.Rows.Count - 1 Then
                                        MsgBox("Se tuvo el siguiente error [" & ex.Message & ", verfique su conexión] ")
                                        UUID = "NO_VALIDO_FOLIO_FISCAL"
                                        SelloSAT = "NO_VALIDO_TIMBRE_FISCAL"
                                        fechaTimbrado = Date.Now
                                        iTipoPAC = 0
                                        RfcPAC = ""
                                    End If
                                End If

                            End Try

                        Else '3.2
                            Dim client As DigitalInvoiceWS.TimbradoClient = New DigitalInvoiceWS.TimbradoClient("BasicHttpBinding_ITimbrado")

                            'If oCFD.VersionCF = "3.3" Then
                            '    client.Endpoint.Address = New System.ServiceModel.EndpointAddress(dtPAC.Rows(i)("ServerTimbre").ToString)
                            'End If

                            client.ClientCredentials.UserName.UserName = dtPAC.Rows(i)("UserId")
                            client.ClientCredentials.UserName.Password = dtPAC.Rows(i)("CustomerKey")

                            client.Open()

                            Dim xmlBase64 As String = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(xmlString))
                            Dim xmlCFDI_Timbrado As String = String.Empty
                            Try

                                If dtPAC.Rows(i)("UserId") = "ELEPHANT_WORKS" Then
                                    xmlCFDI_Timbrado = client.TimbrarTestBase64(xmlBase64)
                                Else
                                    xmlCFDI_Timbrado = client.TimbrarBase64(xmlBase64)
                                End If
                                result = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(xmlCFDI_Timbrado))


                                Dim Elementos As String() = result.Split()

                                For Each sElementos As String In Elementos
                                    If sElementos.Contains("UUID=") Then
                                        UUID = sElementos.Replace("UUID=", "").Replace("""", "")
                                    End If
                                    If sElementos.Contains("FechaTimbrado=") Then
                                        fechaTimbrado = sElementos.Replace("FechaTimbrado=", "").Replace("""", "")
                                    End If
                                    If sElementos.Contains("noCertificadoSAT=") Then
                                        CertificadoSAT = sElementos.Replace("noCertificadoSAT=", "").Replace("""", "")
                                    End If

                                    If sElementos.Contains("selloSAT=") Then
                                        SelloSAT = sElementos.Replace("selloSAT=", "").Replace("""", "")
                                    End If
                                    If sElementos.Contains("version=") Then
                                        VersionSAT = sElementos.Replace("version=", "").Replace("""", "")
                                    End If
                                Next
                                RfcPAC = IIf(dtPAC.Rows(i)("RFC").GetType.Name = "DBNull", "", dtPAC.Rows(i)("RFC"))

                                iTipoPAC = 3
                                ModPOS.Ejecuta("sp_actualiza_timbre", "@CustomerKey", dtPAC.Rows(i)("CustomerKey"), "@TipoPAC", iTipoPAC)
                                Exit For

                            Catch ex As Exception

                                If ex.Message = "El CFDI contiene un timbre previo." Then

                                    xmlCFDI_Timbrado = client.RecuperarTimbreBase64(xmlBase64)

                                    result = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(xmlCFDI_Timbrado))


                                    Dim Elementos As String() = result.Split()

                                    For Each sElementos As String In Elementos
                                        If sElementos.Contains("UUID=") Then
                                            UUID = sElementos.Replace("UUID=", "").Replace("""", "")
                                        End If
                                        If sElementos.Contains("FechaTimbrado=") Then
                                            fechaTimbrado = sElementos.Replace("FechaTimbrado=", "").Replace("""", "")
                                        End If
                                        If sElementos.Contains("noCertificadoSAT=") Then
                                            CertificadoSAT = sElementos.Replace("noCertificadoSAT=", "").Replace("""", "")
                                        End If

                                        If sElementos.Contains("selloSAT=") Then
                                            SelloSAT = sElementos.Replace("selloSAT=", "").Replace("""", "")
                                        End If
                                        If sElementos.Contains("version=") Then
                                            VersionSAT = sElementos.Replace("version=", "").Replace("""", "")
                                        End If
                                    Next
                                    RfcPAC = IIf(dtPAC.Rows(i)("RFC").GetType.Name = "DBNull", "", dtPAC.Rows(i)("RFC"))

                                    iTipoPAC = 3
                                    ModPOS.Ejecuta("sp_actualiza_timbre", "@CustomerKey", dtPAC.Rows(i)("CustomerKey"), "@TipoPAC", iTipoPAC)
                                    Exit For
                                Else
                                    If i = dtPAC.Rows.Count - 1 Then
                                        MsgBox("Se tuvo el siguiente error [" & ex.Message & ", verfique su conexión] ")
                                        UUID = "NO_VALIDO_FOLIO_FISCAL"
                                        SelloSAT = "NO_VALIDO_TIMBRE_FISCAL"
                                        fechaTimbrado = Date.Now
                                        iTipoPAC = 0
                                        RfcPAC = ""
                                    End If
                                End If

                            End Try

                        End If

                    ElseIf dtPAC.Rows(i)("TipoPAC") = 4 Then 'Detecno

                        frmStatusMessage.Show("Solicitado Timbre Fiscal...Detecno")
                        frmStatusMessage.BringToFront()

                        Dim xmlString As String

                        xmlString = oXml.OuterXml

                        If oCFD.VersionCF = "3.3" Then

                            Dim client As DetecnoPAC33.DetecnoPacClient = New DetecnoPAC33.DetecnoPacClient()

                            Dim xmlRespuesta As DetecnoPAC33.Xml = New DetecnoPAC33.Xml()

                            If dtPAC.Rows(i)("UserId") = "AAAAAA\wsTIMBRADOR" Then
                                client.Endpoint.Address = New System.ServiceModel.EndpointAddress("https://test.timbra.mx/WCFTimbrador33/DetecnoPAC.svc")

                            Else
                                If dtPAC.Rows(i)("ServerTimbre") = "" Then
                                    client.Endpoint.Address = New System.ServiceModel.EndpointAddress("https://www.timbra.mx/WCFTimbrador33/DetecnoPac.svc")
                                Else
                                    client.Endpoint.Address = New System.ServiceModel.EndpointAddress(dtPAC.Rows(i)("ServerTimbre").ToString)
                                End If

                            End If

                            xmlRespuesta = client.TimbrarCfdi(dtPAC.Rows(i)("UserId"), dtPAC.Rows(i)("CustomerKey"), xmlString)



                            If xmlRespuesta.Success Then
                                Dim strXmlTfd As String = xmlRespuesta.XmlTfd
                                ' Dim strCoTfd As String = xmlRespuesta.CoTfd
                                'Dim strQR As String = xmlRespuesta.StrQr

                                Dim Elementos As String() = strXmlTfd.Split()

                                For Each sElementos As String In Elementos
                                    If sElementos.Contains("UUID=") Then
                                        UUID = sElementos.Replace("UUID=", "").Replace("""", "")
                                    End If
                                    If sElementos.Contains("FechaTimbrado=") Then
                                        fechaTimbrado = sElementos.Replace("FechaTimbrado=", "").Replace("""", "")
                                    End If
                                    If sElementos.Contains("NoCertificadoSAT=") Then
                                        CertificadoSAT = sElementos.Replace("NoCertificadoSAT=", "").Replace("""", "")
                                    End If

                                    If sElementos.Contains("SelloSAT=") Then
                                        SelloSAT = sElementos.Replace("SelloSAT=", "").Replace("""", "")
                                    End If
                                    If sElementos.Contains("Version=") Then
                                        VersionSAT = sElementos.Replace("Version=", "").Replace("""", "")
                                    End If

                                    If sElementos.Contains("RfcProvCertif=") Then
                                        RfcPAC = sElementos.Replace("RfcProvCertif=", "").Replace("""", "")
                                    End If
                                Next

                                ' RfcPAC = IIf(dtPAC.Rows(i)("RFC").GetType.Name = "DBNull", "", dtPAC.Rows(i)("RFC"))

                                iTipoPAC = 4
                                ModPOS.Ejecuta("sp_actualiza_timbre", "@CustomerKey", dtPAC.Rows(i)("CustomerKey"), "@TipoPAC", iTipoPAC)
                                Exit For

                            Else
                                Dim sError As String = xmlRespuesta.ErrDesc

                                If i = dtPAC.Rows.Count - 1 Then
                                    MsgBox("Se tuvo el siguiente error [" & sError)
                                    UUID = "NO_VALIDO_FOLIO_FISCAL"
                                    SelloSAT = "NO_VALIDO_TIMBRE_FISCAL"
                                    fechaTimbrado = Date.Now
                                    iTipoPAC = 0
                                    RfcPAC = ""
                                End If


                            End If

                        Else 'Version 3.2
                            Dim client As DetecnoPAC.DetecnoPacClient = New DetecnoPAC.DetecnoPacClient()

                            Dim xmlRespuesta As DetecnoPAC.Xml = New DetecnoPAC.Xml()

                            If dtPAC.Rows(i)("UserId") = "AAAAAA\wsTIMBRADOR" Then
                                client.Endpoint.Address = New System.ServiceModel.EndpointAddress("https://test.timbra.mx/WCFTimbrador/DetecnoPAC.svc")
                            Else
                                If dtPAC.Rows(i)("ServerTimbre") = "" Then
                                    client.Endpoint.Address = New System.ServiceModel.EndpointAddress("https://www.timbra.mx/WCFTimbrador/DetecnoPac.svc")
                                Else
                                    client.Endpoint.Address = New System.ServiceModel.EndpointAddress(dtPAC.Rows(i)("ServerTimbre").ToString)
                                End If

                            End If

                            xmlRespuesta = client.TimbrarCfdi(dtPAC.Rows(i)("UserId"), dtPAC.Rows(i)("CustomerKey"), xmlString)


                            If xmlRespuesta.Success Then
                                Dim strXmlTfd As String = xmlRespuesta.XmlTfd
                                ' Dim strCoTfd As String = xmlRespuesta.CoTfd
                                'Dim strQR As String = xmlRespuesta.StrQr

                                Dim Elementos As String() = strXmlTfd.Split()

                                For Each sElementos As String In Elementos
                                    If sElementos.Contains("UUID=") Then
                                        UUID = sElementos.Replace("UUID=", "").Replace("""", "")
                                    End If
                                    If sElementos.Contains("FechaTimbrado=") Then
                                        fechaTimbrado = sElementos.Replace("FechaTimbrado=", "").Replace("""", "")
                                    End If
                                    If sElementos.Contains("noCertificadoSAT=") Then
                                        CertificadoSAT = sElementos.Replace("noCertificadoSAT=", "").Replace("""", "")
                                    End If

                                    If sElementos.Contains("selloSAT=") Then
                                        SelloSAT = sElementos.Replace("selloSAT=", "").Replace("""", "")
                                    End If
                                    If sElementos.Contains("version=") Then
                                        VersionSAT = sElementos.Replace("version=", "").Replace("""", "")
                                    End If
                                Next

                                RfcPAC = IIf(dtPAC.Rows(i)("RFC").GetType.Name = "DBNull", "", dtPAC.Rows(i)("RFC"))

                                iTipoPAC = 4
                                ModPOS.Ejecuta("sp_actualiza_timbre", "@CustomerKey", dtPAC.Rows(i)("CustomerKey"), "@TipoPAC", iTipoPAC)
                                Exit For

                            Else
                                Dim sError As String = xmlRespuesta.ErrDesc

                                If i = dtPAC.Rows.Count - 1 Then
                                    MsgBox("Se tuvo el siguiente error [" & sError)
                                    UUID = "NO_VALIDO_FOLIO_FISCAL"
                                    SelloSAT = "NO_VALIDO_TIMBRE_FISCAL"
                                    fechaTimbrado = Date.Now
                                    iTipoPAC = 0
                                    RfcPAC = ""
                                End If


                            End If


                        End If




                    End If
                Next


                ' Area comun de timbrado

                frmStatusMessage.Dispose()

                If oCFD.VersionCF = "3.3" Then
                    CBB = ModPOS.crearQR33(eRFC, RFC, total, UUID, Right(oCFD.sello, 8))

                Else
                    CBB = ModPOS.crearQR(eRFC, RFC, total, UUID)
                End If
                
                If iTipoPAC = 0 Then
                    oXml.Save(FileXML)
                Else
                    Dim newElem As XmlElement = oXml.CreateElement("cfdi", "Complemento", "http://www.sat.gob.mx/cfd/3")
                    Dim newEle1 As XmlElement = oXml.CreateElement("tfd", "TimbreFiscalDigital", "http://www.sat.gob.mx/TimbreFiscalDigital")

                    Dim newAttr As XmlAttribute

                    If VersionCF <> "3.3" Then

                        newAttr = oXml.CreateAttribute("xsi", "schemaLocation", "http://www.w3.org/2001/XMLSchema-instance")
                        newAttr.Value = "http://www.sat.gob.mx/TimbreFiscalDigital http://www.sat.gob.mx/TimbreFiscalDigital/TimbreFiscalDigital.xsd"
                        newEle1.Attributes.Append(newAttr)

                        newAttr = oXml.CreateAttribute("selloCFD")
                        newAttr.Value = sello
                        newEle1.Attributes.Append(newAttr)

                        newAttr = oXml.CreateAttribute("selloSAT")
                        newAttr.Value = SelloSAT
                        newEle1.Attributes.Append(newAttr)

                        newAttr = oXml.CreateAttribute("UUID")
                        newAttr.Value = UUID
                        newEle1.Attributes.Append(newAttr)


                        newAttr = oXml.CreateAttribute("FechaTimbrado")
                        newAttr.Value = String.Format("{0:yyyy-MM-ddTHH:mm:ss}", fechaTimbrado)
                        newEle1.Attributes.Append(newAttr)


                        newAttr = oXml.CreateAttribute("version")
                        newAttr.Value = VersionSAT
                        newEle1.Attributes.Append(newAttr)

                        newAttr = oXml.CreateAttribute("noCertificadoSAT")
                        newAttr.Value = CertificadoSAT
                        newEle1.Attributes.Append(newAttr)
                    Else
                        newAttr = oXml.CreateAttribute("xsi", "schemaLocation", "http://www.w3.org/2001/XMLSchema-instance")
                        newAttr.Value = "http://www.sat.gob.mx/TimbreFiscalDigital http://www.sat.gob.mx/sitio_internet/cfd/TimbreFiscalDigital/TimbreFiscalDigitalv11.xsd"
                        newEle1.Attributes.Append(newAttr)

                        newAttr = oXml.CreateAttribute("Version")
                        newAttr.Value = VersionSAT
                        newEle1.Attributes.Append(newAttr)

                        newAttr = oXml.CreateAttribute("UUID")
                        newAttr.Value = UUID
                        newEle1.Attributes.Append(newAttr)

                        newAttr = oXml.CreateAttribute("FechaTimbrado")
                        newAttr.Value = String.Format("{0:yyyy-MM-ddTHH:mm:ss}", fechaTimbrado)
                        newEle1.Attributes.Append(newAttr)

                        newAttr = oXml.CreateAttribute("RfcProvCertif")
                        newAttr.Value = RfcPAC
                        newEle1.Attributes.Append(newAttr)

                        newAttr = oXml.CreateAttribute("SelloCFD")
                        newAttr.Value = sello
                        newEle1.Attributes.Append(newAttr)

                        newAttr = oXml.CreateAttribute("NoCertificadoSAT")
                        newAttr.Value = CertificadoSAT
                        newEle1.Attributes.Append(newAttr)

                        newAttr = oXml.CreateAttribute("SelloSAT")
                        newAttr.Value = SelloSAT
                        newEle1.Attributes.Append(newAttr)
                    End If

                    newElem.AppendChild(newEle1)
                    oXml.DocumentElement.AppendChild(newElem)
                    oXml.Save(FileXML)

                End If
            End If
        End If

        If TipoAccion = 1 OrElse TipoAccion = 2 OrElse TipoAccion = 4 Then

            If iTipoPAC = 0 Then
                fechaTimbrado = CDate(oCFD.Fecha)
            End If

            ModPOS.Ejecuta("st_inserta_selloTraslado", "@TRSClave", sDOCClave, "@CBB", CBB, "@Certificado", oCFD.noCertificado, "@cadenaOriginal", oCFD.cadenaOriginal, "@Sello", oCFD.sello, "@Certificado64", oCFD.Certificado64, "@UUID", UUID, "@SelloSAT", SelloSAT, "@CertificadoSAT", CertificadoSAT, "@fechaTimbrado", fechaTimbrado, "@versionSAT", VersionSAT, "@TipoPAC", iTipoPAC, "@regimenFiscal", oCFD.regimenFiscal, "@RfcProvCertif", RfcPAC, "@versionCF", oCFD.VersionCF, "@estado", IIf(iTipoPAC = 0, 2, 1))

        End If



        If iTipoPAC <> 0 Then

            'Verifica que exista el path
            Try
                If System.IO.Directory.Exists(PathXML) Then

                    oPath = PathXML
                    If oPath.Length > 3 AndAlso oPath.Substring(oPath.Length - 1, 1) <> "\" Then
                        oPath &= "\"
                    End If


                    oPath &= fechaPath.Year.ToString & "\" & fechaPath.Month.ToString & "\" & fechaPath.Day.ToString & "\"


                    If Not System.IO.Directory.Exists(oPath) Then
                        System.IO.Directory.CreateDirectory(oPath)
                    End If

                    oFileXML = oPath & sFolio & ".xml"

                    If System.IO.File.Exists(oFileXML) Then
                        If FileXML <> oFileXML Then
                            System.IO.File.Delete(oFileXML)
                        End If
                    End If



                    'Verifica si existe carpeta Temp
                    If sInterfazSalida <> "" Then
                        Try
                            If Not System.IO.Directory.Exists(PathXML & "\Temp") Then
                                System.IO.Directory.CreateDirectory(PathXML & "\Temp")
                            End If

                            Dim oTemp As String
                            If PathXML.Length <= 3 Then
                                oTemp = PathXML & "Temp\" & sFolio & ".xml"
                            ElseIf PathXML.Substring(PathXML.Length - 1, 1) = "\" Then
                                oTemp = PathXML & "Temp\" & sFolio & ".xml"
                            Else
                                oTemp = PathXML & "\" & "Temp\" & sFolio & ".xml"
                            End If

                            If System.IO.File.Exists(oTemp) Then
                                If FileXML <> oTemp Then
                                    System.IO.File.Delete(oTemp)
                                End If
                            End If
                            If FileXML <> oTemp Then
                                System.IO.File.Copy(FileXML, oTemp)
                            End If


                        Catch ex As Exception
                        End Try


                    End If


                    If FileXML <> oFileXML Then
                        System.IO.File.Move(FileXML, oFileXML)
                    End If

                Else
                    MessageBox.Show("El directorio " & PathXML & " no existe o no se puede tener acceso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
            End Try
        End If


        If sInterfazSalida <> "" AndAlso TipoAccion <> 3 AndAlso TipoAccion <> 4 AndAlso iTipoPAC <> 0 Then
            Dim sFecha As String
            Dim dtInterfaz As DataTable
            sFecha = DateTime.Now.ToString("yyyyMMdd_HHmmssfff")

            Dim InterfazCobros As String = ""
            Dim InterfazAnticipos As String = ""

            dtInterfaz = Recupera_Tabla("st_recupera_interfaz", "@Interfaz", "TrasladoCFDI", "@COMClave", ModPOS.CompanyActual)
            If dtInterfaz.Rows.Count > 0 Then
                ModPOS.Ejecuta(CStr(dtInterfaz.Rows(0)("sp")), "@Folio", sDOCClave, "@TipoDocumento", 0, "@Path", sInterfazSalida, "@Fecha", sFecha)
            End If

        End If


        Return iTipoPAC

    End Function


  
    Public Function crearXML(ByVal TipoAccion As Integer, ByVal dtPAC As DataTable, ByVal PathXML As String, ByVal sFolio As String, ByVal sDOCClave As String, ByVal sTipoComprobante As String, Optional ByVal oCFD As CFD = Nothing, Optional ByVal dtConcepto As DataTable = Nothing, Optional ByVal dtImpuesto As DataTable = Nothing, Optional ByVal iTipoComprobante As Integer = 0, Optional ByVal sInterfazSalida As String = "", Optional ByVal dtImpuestoDet As DataTable = Nothing, Optional ByVal dtRetencionDet As DataTable = Nothing, Optional ByVal dtRetencion As DataTable = Nothing, Optional ByVal bShowError As Boolean = True) As Integer
        Dim i As Integer
        Dim FileXML, oFileXML, oPath As String
        Dim sPre As String = ""
        Dim iTipoPAC As Integer = 0
        Dim dIVA, dIEPS, dOtros As Double

        Dim VersionCF As String = ""
        Dim eRFC As String = ""
        Dim RFC As String = ""
        Dim sello As String = ""
        Dim UUID As String = ""
        Dim SelloSAT As String = ""
        Dim CertificadoSAT As String = ""
        Dim VersionSAT As String = ""
        Dim RfcPAC As String = ""

        Dim fechaTimbrado, fechaPath As Date
        Dim total As Double

        Dim CBB() As Byte = Nothing

        Dim dtClaveCliente As DataTable

        FileXML = pathActual & "CFD\" & sFolio & ".xml"




        If TipoAccion = 1 OrElse TipoAccion = 3 OrElse TipoAccion = 4 Then 'Crea por primera vez el XML o regenerar xml

            fechaPath = oCFD.Fecha
            VersionCF = oCFD.VersionCF

            If oCFD.TipoCF = 2 Then
                sPre = "cfdi:"
            End If

            Dim textWriter As System.Xml.XmlTextWriter = New System.Xml.XmlTextWriter(FileXML, System.Text.Encoding.UTF8)
            textWriter.Formatting = System.Xml.Formatting.None
            ' Opens the document
            textWriter.WriteStartDocument()

            ' Write comments

            'If oCFD.extra <> "" Then
            '    textWriter.WriteComment(oCFD.extra.Trim)
            'End If

            ' Write first element

            textWriter.WriteStartElement(sPre & "Comprobante")

            If oCFD.VersionCF = "2.0" OrElse oCFD.VersionCF = "2.2" Then
                textWriter.WriteAttributeString("xmlns", "http://www.sat.gob.mx/cfd/2")
            ElseIf oCFD.VersionCF = "3.0" OrElse oCFD.VersionCF = "3.2" OrElse oCFD.VersionCF = "3.3" Then
                textWriter.WriteAttributeString("xmlns:cfdi", "http://www.sat.gob.mx/cfd/3")

            End If

            textWriter.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance")

            Select Case oCFD.VersionCF
                Case Is = "2.0"
                    textWriter.WriteAttributeString("xsi:schemaLocation", "http://www.sat.gob.mx/cfd/2 http://www.sat.gob.mx/sitio_internet/cfd/2/cfdv2.xsd")
                Case Is = "2.2"
                    textWriter.WriteAttributeString("xsi:schemaLocation", "http://www.sat.gob.mx/cfd/2 http://www.sat.gob.mx/sitio_internet/cfd/2/cfdv22.xsd")
                Case Is = "3.0"
                    textWriter.WriteAttributeString("xsi:schemaLocation", "http://www.sat.gob.mx/cfd/3 http://www.sat.gob.mx/sitio_internet/cfd/3/cfdv3.xsd")
                Case Is = "3.2"
                    textWriter.WriteAttributeString("xsi:schemaLocation", "http://www.sat.gob.mx/cfd/3 http://www.sat.gob.mx/sitio_internet/cfd/3/cfdv32.xsd")
                Case Is = "3.3"
                    textWriter.WriteAttributeString("xsi:schemaLocation", "http://www.sat.gob.mx/cfd/3 http://www.sat.gob.mx/sitio_internet/cfd/3/cfdv33.xsd")
            End Select

            If oCFD.total = 0 Then
                Select Case iTipoComprobante
                    Case Is = 1
                        oCFD.impuestos = dtImpuesto.Compute("SUM(Importe)", "FACClave = '" & oCFD.DOCClave & "'")
                    Case Is = 6
                        oCFD.impuestos = dtImpuesto.Compute("SUM(Importe)", "CARClave = '" & oCFD.DOCClave & "'")
                    Case Is = 7
                        oCFD.impuestos = dtImpuesto.Compute("SUM(Importe)", "NCClave = '" & oCFD.DOCClave & "'")
                    Case Else
                        If oCFD.tipoDeComprobante = "ingreso" Then
                            oCFD.impuestos = dtImpuesto.Compute("SUM(Importe)", "FACClave = '" & oCFD.DOCClave & "'")
                        Else
                            oCFD.impuestos = dtImpuesto.Compute("SUM(Importe)", "NCClave = '" & oCFD.DOCClave & "'")
                        End If
                End Select

                oCFD.Retenciones = 0

                If Not dtRetencion Is Nothing Then
                    If dtRetencion.Rows.Count > 0 Then
                        Select Case iTipoComprobante
                            Case Is = 1
                                oCFD.Retenciones = dtRetencion.Compute("SUM(Importe)", "FACClave = '" & oCFD.DOCClave & "'")
                            Case Is = 6
                                oCFD.Retenciones = dtRetencion.Compute("SUM(Importe)", "CARClave = '" & oCFD.DOCClave & "'")
                            Case Is = 7
                                oCFD.Retenciones = dtRetencion.Compute("SUM(Importe)", "NCClave = '" & oCFD.DOCClave & "'")
                            Case Else
                                If oCFD.tipoDeComprobante = "ingreso" Then
                                    oCFD.Retenciones = dtRetencion.Compute("SUM(Importe)", "FACClave = '" & oCFD.DOCClave & "'")
                                Else
                                    oCFD.Retenciones = dtRetencion.Compute("SUM(Importe)", "NCClave = '" & oCFD.DOCClave & "'")
                                End If
                        End Select
                    End If
                End If

                oCFD.total = Math.Round(oCFD.subtotal - oCFD.descuento + oCFD.impuestos - oCFD.Retenciones, 2)
            End If


            If oCFD.VersionCF <> "3.3" Then
                textWriter.WriteAttributeString("version", oCFD.VersionCF)

                If oCFD.Serie <> "" Then
                    textWriter.WriteAttributeString("serie", oCFD.Serie)
                End If

                textWriter.WriteAttributeString("folio", oCFD.Folio)
                textWriter.WriteAttributeString("fecha", oCFD.Fecha)
                textWriter.WriteAttributeString("sello", oCFD.sello)

                If oCFD.TipoCF = 1 Then
                    textWriter.WriteAttributeString("noAprobacion", oCFD.noAprobacion)
                    textWriter.WriteAttributeString("anoAprobacion", oCFD.anoAprobacion)
                End If

                textWriter.WriteAttributeString("formaDePago", oCFD.formaDePago)

                textWriter.WriteAttributeString("noCertificado", oCFD.noCertificado)
                textWriter.WriteAttributeString("certificado", oCFD.Certificado64)


                textWriter.WriteAttributeString("subTotal", QuitarCeros(oCFD.subtotal / oCFD.TipoCambio))
                textWriter.WriteAttributeString("descuento", QuitarCeros(oCFD.descuento / oCFD.TipoCambio))

                If oCFD.VersionCF = "2.2" OrElse oCFD.VersionCF = "3.2" Then
                    textWriter.WriteAttributeString("TipoCambio", QuitarCeros(oCFD.TipoCambio))

                    textWriter.WriteAttributeString("Moneda", oCFD.Moneda)
                End If

                textWriter.WriteAttributeString("total", QuitarCeros(oCFD.total / oCFD.TipoCambio))
                textWriter.WriteAttributeString("tipoDeComprobante", oCFD.tipoDeComprobante)

                If oCFD.VersionCF = "2.2" OrElse oCFD.VersionCF = "3.2" Then
                    textWriter.WriteAttributeString("metodoDePago", spaceFormat(oCFD.metodoDePago))
                    textWriter.WriteAttributeString("LugarExpedicion", spaceFormat(oCFD.LugarExpedicion))
                    If oCFD.NumCtaPago <> "" Then
                        textWriter.WriteAttributeString("NumCtaPago", spaceFormat(oCFD.NumCtaPago))
                    End If
                End If

                textWriter.WriteStartElement(sPre & "Emisor")
                textWriter.WriteAttributeString("rfc", spaceFormat(oCFD.eRFC))
                textWriter.WriteAttributeString("nombre", spaceFormat(oCFD.eRazonSocial))

                textWriter.WriteStartElement(sPre & "DomicilioFiscal")
                textWriter.WriteAttributeString("calle", spaceFormat(oCFD.eCalle))
                textWriter.WriteAttributeString("noExterior", spaceFormat(oCFD.enoExterior))

                If oCFD.benoInterior Then
                    textWriter.WriteAttributeString("noInterior", spaceFormat(oCFD.enoInterior))
                End If

                textWriter.WriteAttributeString("colonia", spaceFormat(oCFD.eColonia))
                textWriter.WriteAttributeString("localidad", IIf(oCFD.eLocalidad = "", "SIN LOCALIDAD", spaceFormat(oCFD.eLocalidad)))
                textWriter.WriteAttributeString("referencia", spaceFormat(oCFD.eReferencia))
                textWriter.WriteAttributeString("municipio", spaceFormat(oCFD.eMnpio))
                textWriter.WriteAttributeString("estado", spaceFormat(oCFD.eEntidad))
                textWriter.WriteAttributeString("pais", spaceFormat(oCFD.ePais))
                textWriter.WriteAttributeString("codigoPostal", spaceFormat(oCFD.eCodigoPostal))
                'Cierre de Domicilio
                textWriter.WriteEndElement()

                If oCFD.iTipoSucursal <> 1 Then
                    textWriter.WriteStartElement(sPre & "ExpedidoEn")
                    textWriter.WriteAttributeString("calle", spaceFormat(oCFD.sCalle))
                    textWriter.WriteAttributeString("noExterior", spaceFormat(oCFD.snoExterior))

                    If oCFD.bsnoInterior Then
                        textWriter.WriteAttributeString("noInterior", spaceFormat(oCFD.snoInterior))
                    End If

                    textWriter.WriteAttributeString("colonia", spaceFormat(oCFD.sColonia))
                    textWriter.WriteAttributeString("localidad", IIf(oCFD.sLocalidad = "", "SIN LOCALIDAD", spaceFormat(oCFD.sLocalidad)))
                    textWriter.WriteAttributeString("referencia", spaceFormat(oCFD.sReferencia))
                    textWriter.WriteAttributeString("municipio", spaceFormat(oCFD.sMnpio))
                    textWriter.WriteAttributeString("estado", spaceFormat(oCFD.sEntidad))
                    textWriter.WriteAttributeString("pais", spaceFormat(oCFD.sPais))
                    textWriter.WriteAttributeString("codigoPostal", spaceFormat(oCFD.sCodigoPostal))
                    'Cierre de centro de expedición
                    textWriter.WriteEndElement()
                End If

                If oCFD.VersionCF = "2.2" OrElse oCFD.VersionCF = "3.2" Then
                    textWriter.WriteStartElement(sPre & "RegimenFiscal")
                    textWriter.WriteAttributeString("Regimen", oCFD.regimenFiscal)
                    textWriter.WriteEndElement()
                End If

                'Cierre de Emisor
                textWriter.WriteEndElement()

                textWriter.WriteStartElement(sPre & "Receptor")
                textWriter.WriteAttributeString("rfc", spaceFormat(oCFD.RFC))
                textWriter.WriteAttributeString("nombre", spaceFormat(oCFD.RazonSocial))

                textWriter.WriteStartElement(sPre & "Domicilio")
                textWriter.WriteAttributeString("calle", spaceFormat(oCFD.Calle))
                textWriter.WriteAttributeString("noExterior", spaceFormat(oCFD.noExterior))

                If oCFD.brnoInterior Then
                    textWriter.WriteAttributeString("noInterior", spaceFormat(oCFD.noInterior))
                End If

                textWriter.WriteAttributeString("colonia", spaceFormat(oCFD.Colonia))
                textWriter.WriteAttributeString("localidad", IIf(oCFD.Localidad = "", "SIN LOCALIDAD", spaceFormat(oCFD.Localidad)))
                textWriter.WriteAttributeString("referencia", spaceFormat(oCFD.Referencia))
                textWriter.WriteAttributeString("municipio", spaceFormat(oCFD.Mnpio))
                textWriter.WriteAttributeString("estado", spaceFormat(oCFD.Entidad))
                textWriter.WriteAttributeString("pais", spaceFormat(oCFD.Pais))
                textWriter.WriteAttributeString("codigoPostal", spaceFormat(oCFD.codigoPostal))
                'Cierre de Domicilioi
                textWriter.WriteEndElement()
                'Cierre de Receptor
                textWriter.WriteEndElement()

            Else 'VersionCF 3.3

                textWriter.WriteAttributeString("Version", oCFD.VersionCF)

                If oCFD.Serie <> "" Then
                    textWriter.WriteAttributeString("Serie", oCFD.Serie)
                End If
                textWriter.WriteAttributeString("Folio", oCFD.Folio)
                textWriter.WriteAttributeString("Fecha", oCFD.Fecha)
                textWriter.WriteAttributeString("Sello", oCFD.sello)

                'Si es Credito Forma de Pago= 99

                textWriter.WriteAttributeString("FormaPago", spaceFormat(oCFD.metodoDePago))
                textWriter.WriteAttributeString("NoCertificado", oCFD.noCertificado)
                textWriter.WriteAttributeString("Certificado", oCFD.Certificado64)
                If oCFD.CondicionesDePago <> "" Then
                    'Contado, 3 meses etc.
                    textWriter.WriteAttributeString("CondicionesDePago", oCFD.CondicionesDePago)
                End If
                textWriter.WriteAttributeString("SubTotal", QuitarCeros(TruncateToDecimal(oCFD.subtotal / oCFD.TipoCambio, 2), 2))

                If oCFD.descuento > 0 Then
                    textWriter.WriteAttributeString("Descuento", QuitarCeros(TruncateToDecimal(oCFD.descuento / oCFD.TipoCambio, 2), 2))
                End If

                textWriter.WriteAttributeString("Moneda", oCFD.Moneda)
                If oCFD.TipoCambio <> 1 Then
                    textWriter.WriteAttributeString("TipoCambio", QuitarCeros(TruncateToDecimal(oCFD.TipoCambio, 2), 6))
                End If

                textWriter.WriteAttributeString("Total", QuitarCeros(TruncateToDecimal(oCFD.total / oCFD.TipoCambio, 2), 2))
                textWriter.WriteAttributeString("TipoDeComprobante", oCFD.tipoDeComprobante)

                'Si es Credito debe ser PPD de lo contrario PUE

                textWriter.WriteAttributeString("MetodoPago", spaceFormat(oCFD.formaDePago))

                textWriter.WriteAttributeString("LugarExpedicion", spaceFormat(oCFD.sCodigoPostal))

                If oCFD.UUID_Sustituido <> "" Then
                    textWriter.WriteStartElement(sPre & "CfdiRelacionados")
                    textWriter.WriteAttributeString("TipoRelacion", "04")
                    textWriter.WriteStartElement(sPre & "CfdiRelacionado")
                    textWriter.WriteAttributeString("UUID", oCFD.UUID_Sustituido)
                    textWriter.WriteEndElement()
                    textWriter.WriteEndElement()

                Else
                    If oCFD.tipoDeComprobante = "E" Then

                        Dim dt As DataTable = ModPOS.Recupera_Tabla("st_recupera_relacionado", "@DOCClave", sDOCClave, "@Tipo", "E")

                        Dim k As Integer
                        If dt.Rows.Count >= 1 Then
                            textWriter.WriteStartElement(sPre & "CfdiRelacionados")
                            '01 Nota Credito
                            If oCFD.tipoNC = 1 Then
                                textWriter.WriteAttributeString("TipoRelacion", "03")
                            Else
                                textWriter.WriteAttributeString("TipoRelacion", "01")
                            End If
                            'uuid del elemento al que se hace referencia
                            For k = 0 To dt.Rows.Count - 1
                                textWriter.WriteStartElement(sPre & "CfdiRelacionado")
                                textWriter.WriteAttributeString("UUID", dt.Rows(k)("UUID"))
                                textWriter.WriteEndElement()
                            Next
                            textWriter.WriteEndElement()
                        End If
                        dt.Dispose()
                    ElseIf iTipoComprobante = 6 Then
                        Dim dt As DataTable = ModPOS.Recupera_Tabla("st_recupera_relacionado", "@DOCClave", sDOCClave, "@Tipo", "I")

                        Dim k As Integer
                        Dim sTipoRelacion As String = ""
                        If dt.Rows.Count >= 1 Then

                            For k = 0 To dt.Rows.Count - 1
                                If sTipoRelacion = "" Then
                                    sTipoRelacion = dt.Rows(k)("TipoRelacion")
                                    textWriter.WriteStartElement(sPre & "CfdiRelacionados")
                                    textWriter.WriteAttributeString("TipoRelacion", dt.Rows(k)("TipoRelacion"))
                                End If
                                'uuid del elemento al que se hace referencia
                                textWriter.WriteStartElement(sPre & "CfdiRelacionado")
                                textWriter.WriteAttributeString("UUID", dt.Rows(k)("UUID"))
                                textWriter.WriteEndElement()
                            Next
                            textWriter.WriteEndElement()
                        End If
                        dt.Dispose()


                    ElseIf iTipoComprobante = 1 Then
                        Dim dt As DataTable = ModPOS.Recupera_Tabla("st_recupera_relacionado", "@DOCClave", sDOCClave, "@Tipo", "F")

                        Dim k As Integer
                        If dt.Rows.Count >= 1 Then
                            textWriter.WriteStartElement(sPre & "CfdiRelacionados")
                            '01 Nota Credito
                            textWriter.WriteAttributeString("TipoRelacion", "07")
                            'uuid del elemento al que se hace referencia
                            For k = 0 To dt.Rows.Count - 1
                                textWriter.WriteStartElement(sPre & "CfdiRelacionado")
                                textWriter.WriteAttributeString("UUID", dt.Rows(k)("UUID"))
                                textWriter.WriteEndElement()
                            Next
                            textWriter.WriteEndElement()
                        End If
                        dt.Dispose()


                    End If
                End If

                textWriter.WriteStartElement(sPre & "Emisor")
                textWriter.WriteAttributeString("Rfc", spaceFormat(oCFD.eRFC))
                textWriter.WriteAttributeString("Nombre", spaceFormat(oCFD.eRazonSocial))
                textWriter.WriteAttributeString("RegimenFiscal", spaceFormat(oCFD.regimenFiscal))

                'Cierre de Emisor
                textWriter.WriteEndElement()

                textWriter.WriteStartElement(sPre & "Receptor")
                textWriter.WriteAttributeString("Rfc", spaceFormat(oCFD.RFC))
                textWriter.WriteAttributeString("Nombre", spaceFormat(oCFD.RazonSocial))

                'Clave del uso que dara al comprobante fiscal de acuerdo a catalogo del SAT

                textWriter.WriteAttributeString("UsoCFDI", oCFD.UsoCFDI)

                'If oCFD.tipoDeComprobante = "E" Then
                '    textWriter.WriteAttributeString("UsoCFDI", "G02")
                'Else
                '    textWriter.WriteAttributeString("UsoCFDI", "G03")
                'End If
                'Cierre de Receptor
                textWriter.WriteEndElement()
            End If

            textWriter.WriteStartElement(sPre & "Conceptos")
            'Inicia for para llenar detalle
            Dim foundRows() As DataRow


            Select Case iTipoComprobante
                Case Is = 1
                    foundRows = dtConcepto.Select("FACClave = '" & oCFD.DOCClave & "'")
                Case Is = 6
                    foundRows = dtConcepto.Select("CARClave = '" & oCFD.DOCClave & "'")
                Case Is = 7
                    foundRows = dtConcepto.Select("NCClave = '" & oCFD.DOCClave & "'")
                Case Else
                    If oCFD.tipoDeComprobante = "ingreso" Then
                        foundRows = dtConcepto.Select("FACClave = '" & oCFD.DOCClave & "'")
                    Else
                        foundRows = dtConcepto.Select("NCClave = '" & oCFD.DOCClave & "'")
                    End If
            End Select

            Dim ClaveProdServ, ClaveUnidad As String
            Dim foundDet() As DataRow
            Dim foundRet() As DataRow
            Dim foundDetCliente() As DataRow

            Dim z As Integer

            If oCFD.tieneAddenda = True AndAlso iTipoComprobante = 1 AndAlso (oCFD.Tipo = 2 OrElse oCFD.Tipo = 5) Then
                dtClaveCliente = ModPOS.Recupera_Tabla("st_recupera_clienteclave", "@DOCClave", sDOCClave, "@Tipo", iTipoComprobante)
            End If




            If foundRows.GetLength(0) > 0 Then
                For i = 0 To foundRows.GetUpperBound(0)
                    If oCFD.VersionCF = "3.3" Then

                        If oCFD.tieneAddenda = True AndAlso iTipoComprobante = 1 AndAlso (oCFD.Tipo = 2 OrElse oCFD.Tipo = 5) Then
                            If Not dtClaveCliente Is Nothing AndAlso dtClaveCliente.Rows.Count > 0 Then
                                foundDetCliente = dtClaveCliente.Select("DETClave = '" & foundRows(i)("DETClave") & "'")
                            End If
                        End If

                        foundDet = dtImpuestoDet.Select("DETClave = '" & foundRows(i)("DETClave") & "'")

                        If Not dtRetencionDet Is Nothing Then
                            foundRet = dtRetencionDet.Select("DETClave = '" & foundRows(i)("DETClave") & "'")
                        End If

                        textWriter.WriteStartElement(sPre & "Concepto")
                        'Clave de producto o servicio de acuerdo a catalogo sat
                        If foundRows(i)("ClaveProdServ").GetType.Name = "DBNull" OrElse foundRows(i)("ClaveProdServ") = "" Then
                            ClaveProdServ = "01010101"
                        Else
                            ClaveProdServ = foundRows(i)("ClaveProdServ")
                        End If

                        If foundRows(i)("ClaveUnidad").GetType.Name = "DBNull" OrElse foundRows(i)("ClaveUnidad") = "" Then
                            ClaveUnidad = "H87"
                        Else
                            ClaveUnidad = foundRows(i)("ClaveUnidad")
                        End If

                        textWriter.WriteAttributeString("ClaveProdServ", ClaveProdServ)
                        If foundRows(i)("Clave") <> "NotaCargo" Then

                            If oCFD.tieneAddenda = True AndAlso iTipoComprobante = 1 AndAlso oCFD.Tipo = 2 Then
                                textWriter.WriteAttributeString("NoIdentificacion", spaceFormat(foundDetCliente(0)("Clave")))
                            Else
                                textWriter.WriteAttributeString("NoIdentificacion", spaceFormat(foundRows(i)("Clave")))
                            End If

                        End If
                        textWriter.WriteAttributeString("Cantidad", QuitarCeros(foundRows(i)("Cantidad")))
                        'Clave de unidad de acuerdo a catalogo de sat
                        textWriter.WriteAttributeString("ClaveUnidad", ClaveUnidad)
                        textWriter.WriteAttributeString("Unidad", foundRows(i)("Unidad"))

                        If oCFD.tieneAddenda = True AndAlso iTipoComprobante = 1 AndAlso (oCFD.Tipo = 2 OrElse oCFD.Tipo = 5) Then
                            If oCFD.Tipo = 2 Then
                                textWriter.WriteAttributeString("Descripcion", spaceFormat(foundDetCliente(0)("Clave")) & " " & spaceFormat(CStr(foundRows(i)("Descripción")).Trim))
                            ElseIf oCFD.Tipo = 5 Then
                                textWriter.WriteAttributeString("Descripcion", "(" & spaceFormat(foundRows(i)("Clave")) & ") " & spaceFormat(foundDetCliente(0)("Clave")) & " " & spaceFormat(CStr(foundRows(i)("Descripción")).Trim))
                            End If
                        Else
                            textWriter.WriteAttributeString("Descripcion", spaceFormat(CStr(foundRows(i)("Descripción")).Trim))
                        End If

                        textWriter.WriteAttributeString("ValorUnitario", QuitarCeros(TruncateToDecimal(foundRows(i)("P.U.") / oCFD.TipoCambio, 2), 2))
                        textWriter.WriteAttributeString("Importe", QuitarCeros(TruncateToDecimal((foundRows(i)("SubTotalPartida") / oCFD.TipoCambio), 2), 2))

                        'Campo opcional cuando se tenga descuentos
                        If foundRows(i)("Descuento") > 0 Then
                            textWriter.WriteAttributeString("Descuento", QuitarCeros(TruncateToDecimal(foundRows(i)("Descuento") / oCFD.TipoCambio, 2), 2))
                        End If

                        textWriter.WriteStartElement(sPre & "Impuestos")

                        textWriter.WriteStartElement(sPre & "Traslados")
                        For z = 0 To foundDet.GetUpperBound(0)
                            textWriter.WriteStartElement(sPre & "Traslado")
                            textWriter.WriteAttributeString("Base", QuitarCeros(TruncateToDecimal(foundDet(z)("Base") / oCFD.TipoCambio, 2), 2))
                            textWriter.WriteAttributeString("Impuesto", spaceFormat(foundDet(z)("ClaveSAT")))
                            textWriter.WriteAttributeString("TipoFactor", foundDet(z)("TipoFactor"))
                            textWriter.WriteAttributeString("TasaOCuota", QuitarCeros(foundDet(z)("Tasa"), 6))
                            textWriter.WriteAttributeString("Importe", QuitarCeros(TruncateToDecimal(foundDet(z)("Importe") / oCFD.TipoCambio, 2), 2))
                            textWriter.WriteEndElement()
                        Next
                        'cierre traslados
                        textWriter.WriteEndElement()

                        If Not dtRetencionDet Is Nothing Then
                            If foundRet.Length > 0 Then
                                textWriter.WriteStartElement(sPre & "Retenciones")
                                For z = 0 To foundRet.GetUpperBound(0)
                                    textWriter.WriteStartElement(sPre & "Retencion")
                                    textWriter.WriteAttributeString("Base", QuitarCeros(TruncateToDecimal(foundRet(z)("Base") / oCFD.TipoCambio, 2), 2))
                                    textWriter.WriteAttributeString("Impuesto", spaceFormat(foundRet(z)("ClaveSAT")))
                                    textWriter.WriteAttributeString("TipoFactor", foundRet(z)("TipoFactor"))
                                    textWriter.WriteAttributeString("TasaOCuota", QuitarCeros(foundRet(z)("Tasa"), 6))
                                    textWriter.WriteAttributeString("Importe", QuitarCeros(TruncateToDecimal(foundRet(z)("Importe") / oCFD.TipoCambio, 2), 2))
                                    textWriter.WriteEndElement()
                                Next

                                'cierre Retenciones
                                textWriter.WriteEndElement()
                            End If
                        End If

                        'cierre impuestos
                        textWriter.WriteEndElement()


                        If foundRows(i)("Pedimento") <> "" Then
                            textWriter.WriteStartElement(sPre & "InformacionAduanera")
                            textWriter.WriteAttributeString("NumeroPedimento", foundRows(i)("Pedimento"))
                            textWriter.WriteEndElement()
                        End If
                        'Cierre concepto
                        textWriter.WriteEndElement()
                    Else
                        textWriter.WriteStartElement(sPre & "Concepto")
                        textWriter.WriteAttributeString("cantidad", QuitarCeros(foundRows(i)("Cantidad")))
                        textWriter.WriteAttributeString("unidad", foundRows(i)("Unidad"))
                        If foundRows(i)("Clave") <> "NotaCargo" Then
                            textWriter.WriteAttributeString("noIdentificacion", foundRows(i)("Clave"))
                        End If
                        textWriter.WriteAttributeString("descripcion", spaceFormat(CStr(foundRows(i)("Descripción")).Trim))
                        textWriter.WriteAttributeString("valorUnitario", QuitarCeros(foundRows(i)("P.U.") / oCFD.TipoCambio))
                        textWriter.WriteAttributeString("importe", QuitarCeros((foundRows(i)("SubTotalPartida") / oCFD.TipoCambio)))
                        textWriter.WriteEndElement()
                    End If

                Next
                'Fin de ciclo
            End If
            'Cierre de Conceptos
            textWriter.WriteEndElement()


            Select Case iTipoComprobante
                Case Is = 1
                    foundRows = dtImpuesto.Select("FACClave = '" & oCFD.DOCClave & "'")

                    oCFD.impuestos = dtImpuesto.Compute("SUM(Importe)", "FACClave = '" & oCFD.DOCClave & "'")

                Case Is = 6
                    foundRows = dtImpuesto.Select("CARClave = '" & oCFD.DOCClave & "'")
                    oCFD.impuestos = dtImpuesto.Compute("SUM(Importe)", "CARClave = '" & oCFD.DOCClave & "'")
                Case Is = 7
                    foundRows = dtImpuesto.Select("NCClave = '" & oCFD.DOCClave & "'")
                    oCFD.impuestos = dtImpuesto.Compute("SUM(Importe)", "NCClave = '" & oCFD.DOCClave & "'")
                Case Else
                    If oCFD.tipoDeComprobante = "ingreso" Then
                        foundRows = dtImpuesto.Select("FACClave = '" & oCFD.DOCClave & "'")
                        oCFD.impuestos = dtImpuesto.Compute("SUM(Importe)", "FACClave = '" & oCFD.DOCClave & "'")
                    Else
                        foundRows = dtImpuesto.Select("NCClave = '" & oCFD.DOCClave & "'")
                        oCFD.impuestos = dtImpuesto.Compute("SUM(Importe)", "NCClave = '" & oCFD.DOCClave & "'")
                    End If
            End Select

            oCFD.Retenciones = 0

            If Not dtRetencion Is Nothing Then
                If dtRetencion.Rows.Count > 0 Then
                    Select Case iTipoComprobante
                        Case Is = 1
                            foundRet = dtRetencion.Select("FACClave = '" & oCFD.DOCClave & "'")
                            oCFD.Retenciones = dtRetencion.Compute("SUM(Importe)", "FACClave = '" & oCFD.DOCClave & "'")
                        Case Is = 6
                            foundRet = dtRetencion.Select("CARClave = '" & oCFD.DOCClave & "'")
                            oCFD.Retenciones = dtRetencion.Compute("SUM(Importe)", "CARClave = '" & oCFD.DOCClave & "'")
                        Case Is = 7
                            foundRet = dtRetencion.Select("NCClave = '" & oCFD.DOCClave & "'")
                            oCFD.Retenciones = dtRetencion.Compute("SUM(Importe)", "NCClave = '" & oCFD.DOCClave & "'")
                        Case Else
                            If oCFD.tipoDeComprobante = "ingreso" Then
                                foundRet = dtRetencion.Select("FACClave = '" & oCFD.DOCClave & "'")
                                oCFD.Retenciones = dtRetencion.Compute("SUM(Importe)", "FACClave = '" & oCFD.DOCClave & "'")
                            Else
                                foundRet = dtRetencion.Select("NCClave = '" & oCFD.DOCClave & "'")
                                oCFD.Retenciones = dtRetencion.Compute("SUM(Importe)", "NCClave = '" & oCFD.DOCClave & "'")
                            End If
                    End Select
                End If
            End If

            ' Write one more element
            textWriter.WriteStartElement(sPre & "Impuestos")
            If oCFD.VersionCF = "3.3" Then
                If oCFD.Retenciones > 0 Then
                    textWriter.WriteAttributeString("TotalImpuestosRetenidos", QuitarCeros(TruncateToDecimal(oCFD.Retenciones / oCFD.TipoCambio, 2), 2))
                End If
                textWriter.WriteAttributeString("TotalImpuestosTrasladados", QuitarCeros(TruncateToDecimal(oCFD.impuestos / oCFD.TipoCambio, 2), 2))
            Else
                textWriter.WriteAttributeString("totalImpuestosTrasladados", QuitarCeros(oCFD.impuestos / oCFD.TipoCambio))
            End If

            If oCFD.Retenciones > 0 Then
                textWriter.WriteStartElement(sPre & "Retenciones")
                'Inicio ciclo de Retenciones
                If foundRet.GetLength(0) > 0 Then
                    For i = 0 To foundRet.GetUpperBound(0)
                        If oCFD.VersionCF = "3.3" Then
                            textWriter.WriteStartElement(sPre & "Retencion")
                            textWriter.WriteAttributeString("Impuesto", foundRet(i)("ClaveSAT"))
                            textWriter.WriteAttributeString("Importe", QuitarCeros(TruncateToDecimal(foundRet(i)("Importe") / oCFD.TipoCambio, 2), 2))
                            textWriter.WriteEndElement()
                        End If
                    Next
                End If
                'fin de ciclo de Retenciones
                'Cierre de Retenciones
                textWriter.WriteEndElement()
            End If


            textWriter.WriteStartElement(sPre & "Traslados")

            'Inicio ciclo de impuestos
            If foundRows.GetLength(0) > 0 Then

                For i = 0 To foundRows.GetUpperBound(0)
                    If oCFD.VersionCF = "3.3" Then
                        textWriter.WriteStartElement(sPre & "Traslado")
                        textWriter.WriteAttributeString("Impuesto", foundRows(i)("ClaveSAT"))
                        textWriter.WriteAttributeString("TipoFactor", foundRows(i)("TipoFactor"))
                        textWriter.WriteAttributeString("TasaOCuota", IIf(foundRows(i)("TipoFactor") = "Tasa", QuitarCeros(foundRows(i)("Tasa") / 100, 6), QuitarCeros(foundRows(i)("Tasa"), 6)))
                        textWriter.WriteAttributeString("Importe", QuitarCeros(TruncateToDecimal(foundRows(i)("Importe") / oCFD.TipoCambio, 2), 2))
                        textWriter.WriteEndElement()
                    Else
                        textWriter.WriteStartElement(sPre & "Traslado")
                        textWriter.WriteAttributeString("impuesto", foundRows(i)("Impuesto"))
                        textWriter.WriteAttributeString("tasa", QuitarCeros(foundRows(i)("Tasa")))
                        textWriter.WriteAttributeString("importe", QuitarCeros(foundRows(i)("Importe") / oCFD.TipoCambio))
                        textWriter.WriteEndElement()
                    End If
                    If oCFD.tieneAddenda = True Then
                        If foundRows(i)("Impuesto") = "IVA" Then
                            dIVA = +foundRows(i)("Importe") / oCFD.TipoCambio
                        ElseIf foundRows(i)("Impuesto") = "IEPS" Then
                            dIEPS = +foundRows(i)("Importe") / oCFD.TipoCambio
                        Else
                            dOtros = +foundRows(i)("Importe") / oCFD.TipoCambio
                        End If
                    End If

                Next

            End If
            'fin de ciclo de impuestos

            'Cierre de Traslados
            textWriter.WriteEndElement()







            'Cierre de Impuesto
            textWriter.WriteEndElement()

            If oCFD.tieneAddenda = True AndAlso iTipoComprobante <> 6 Then
                ' Soriana
                If oCFD.Tipo = 1 Then

                    Dim iMoneda As Integer

                    Select Case oCFD.Moneda
                        Case Is = "MXN"
                            iMoneda = 1
                        Case Is = "USD"
                            iMoneda = 2
                        Case Is = "EUR"
                            iMoneda = 3
                    End Select

                    textWriter.WriteStartElement(sPre & "Addenda")
                    textWriter.WriteStartElement("DSCargaRemisionProv")
                    If oCFD.VersionCF = "2.0" OrElse oCFD.VersionCF = "2.2" Then
                        textWriter.WriteAttributeString("xmlns", "http://www.sat.gob.mx/cfd/2")
                    ElseIf oCFD.VersionCF = "3.0" OrElse oCFD.VersionCF = "3.2" Then
                        textWriter.WriteAttributeString("xmlns", "http://www.sat.gob.mx/cfd/3")
                    End If

                    textWriter.WriteStartElement("Remision")
                    textWriter.WriteAttributeString("Id", oCFD.Serie & oCFD.Folio)
                    textWriter.WriteAttributeString("RowOrder", 1)
                    textWriter.WriteElementString("Proveedor", oCFD.NoProveedor)
                    textWriter.WriteElementString("Remision", oCFD.Serie & oCFD.Folio)
                    textWriter.WriteElementString("FechaRemision", oCFD.Fecha)
                    textWriter.WriteElementString("Tienda", oCFD.GLN)
                    textWriter.WriteElementString("TipoMoneda", iMoneda)
                    textWriter.WriteElementString("TipoBulto", 2)
                    textWriter.WriteElementString("EntregaMercancia", 1)
                    textWriter.WriteElementString("CumpleReqFiscales", True)
                    textWriter.WriteElementString("CantidadBultos", oCFD.CantBultos)
                    textWriter.WriteElementString("Subtotal", oCFD.subtotal)
                    textWriter.WriteElementString("Descuentos", oCFD.descuento)
                    textWriter.WriteElementString("IEPS", dIEPS)
                    textWriter.WriteElementString("IVA", dIVA)
                    textWriter.WriteElementString("OtrosImpuestos", dOtros)
                    textWriter.WriteElementString("Total", oCFD.total)
                    textWriter.WriteElementString("CantidadPedidos", oCFD.CantPedidos)
                    textWriter.WriteElementString("FechaEntregaMercancia", oCFD.FechaEntrega)
                    textWriter.WriteElementString("Cita", oCFD.NoCita)
                    textWriter.WriteElementString("FolioNotaEntrada", oCFD.NotaEntrada)
                    'Cierre de Remision
                    textWriter.WriteEndElement()

                    ModPOS.Ejecuta("sp_upd_complemento", _
                                           "@FACClave", oCFD.FACClave, _
                                           "@TipoAddenda", oCFD.Tipo, _
                                           "@FechaEntrega", oCFD.FechaEntrega, _
                                           "@NotaEntrada", oCFD.NotaEntrada, _
                                           "@Cita", oCFD.NoCita, _
                                           "@IVA", dIVA, _
                                           "@IEPS", dIEPS, _
                                           "@Otros", dOtros, _
                                           "@CantidadPedidos", oCFD.CantPedidos, _
                                           "@CantidadBultos", oCFD.CantBultos)


                    Dim dtPedidos, dtArticulos As DataTable

                    Dim x As Integer

                    dtPedidos = ModPOS.SiExisteRecupera("sp_recupera_pedidos", "@FACClave", oCFD.FACClave)

                    If Not dtPedidos Is Nothing Then
                        For i = 0 To dtPedidos.Rows.Count - 1

                            textWriter.WriteStartElement("Pedidos")
                            textWriter.WriteAttributeString("Id", dtPedidos.Rows(i)("Folio"))
                            textWriter.WriteAttributeString("RowOrder", i + 1)
                            textWriter.WriteElementString("Proveedor", oCFD.NoProveedor)
                            textWriter.WriteElementString("Remision", oCFD.Serie & oCFD.Folio)
                            textWriter.WriteElementString("FolioPedido", dtPedidos.Rows(i)("Folio"))
                            textWriter.WriteElementString("Tienda", oCFD.GLN)
                            textWriter.WriteElementString("CantidadArticulos", dtPedidos.Rows(i)("Cantidad"))
                            textWriter.WriteElementString("PedidoEmitidoProveedor", "No")
                            'Cierre de Pedidos
                            textWriter.WriteEndElement()


                            dtArticulos = ModPOS.SiExisteRecupera("sp_recupera_articulos", "@VENClave", dtPedidos.Rows(i)("VENClave"))

                            If Not dtArticulos Is Nothing Then
                                For x = 0 To dtArticulos.Rows.Count - 1

                                    textWriter.WriteStartElement("Articulos")
                                    textWriter.WriteAttributeString("Id", dtArticulos.Rows(x)("GTIN"))
                                    textWriter.WriteAttributeString("RowOrder", x + 1)

                                    textWriter.WriteElementString("Proveedor", oCFD.NoProveedor)
                                    textWriter.WriteElementString("Remision", oCFD.Serie & oCFD.Folio)
                                    textWriter.WriteElementString("FolioPedido", dtArticulos.Rows(x)("Folio"))
                                    textWriter.WriteElementString("Tienda", oCFD.GLN)

                                    textWriter.WriteElementString("Codigo", dtArticulos.Rows(x)("GTIN"))
                                    textWriter.WriteElementString("CantidadUnidadCompra", dtArticulos.Rows(x)("Cantidad"))

                                    textWriter.WriteElementString("CostoNetoUnidadCompra", dtArticulos.Rows(x)("Subtotal"))

                                    textWriter.WriteElementString("PorcentajeIEPS", IIf(dtArticulos.Rows(x)("IEPS").GetType.Name = "DBNull", 0, dtArticulos.Rows(x)("IEPS")))
                                    textWriter.WriteElementString("PorcentajeIVA", IIf(dtArticulos.Rows(x)("IVA").GetType.Name = "DBNull", 0, dtArticulos.Rows(x)("IVA")))

                                    'Cierre de articulos
                                    textWriter.WriteEndElement()
                                Next
                            End If
                        Next
                    End If

                    'Cierre de DSCargaRemisionProv
                    textWriter.WriteEndElement()
                    'Cierre de Addenda
                    textWriter.WriteEndElement()
                ElseIf oCFD.Tipo = 2 Then
                    'Tipo Autozone
                    Dim dtadd As DataTable = ModPOS.Recupera_Tabla("st_complemento_autozone", "@DOCClave", oCFD.DOCClave, "@Tipo", iTipoComprobante)

                    textWriter.WriteStartElement(sPre & "Addenda")
                    textWriter.WriteStartElement("ADDENDA10")
                    textWriter.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance")
                    textWriter.WriteAttributeString("xsi:schemaLocation", "https://azfes.autozone.com/xsd/Addenda_Merch_32.xsd")
                    textWriter.WriteAttributeString("VERSION", dtadd.Rows(0)("VERSION"))
                    textWriter.WriteAttributeString("POID", dtadd.Rows(0)("POID"))
                    textWriter.WriteAttributeString("PODATE", dtadd.Rows(0)("PODATE"))
                    textWriter.WriteAttributeString("BUYER", dtadd.Rows(0)("BUYER"))
                    textWriter.WriteAttributeString("VENDOR_ID", dtadd.Rows(0)("VENDOR_ID"))
                    textWriter.WriteAttributeString("EMAIL", dtadd.Rows(0)("EMAIL"))
                    textWriter.WriteAttributeString("DEPTID", dtadd.Rows(0)("DEPTID"))
                    'Cierre de Addenda
                    textWriter.WriteEndElement()
                    'Cierre de Addenda
                    textWriter.WriteEndElement()
                End If

            End If


            'Cierre de Comprobante
            textWriter.WriteEndElement()
            ' Ends the document.
            textWriter.WriteEndDocument()
            ' close writer
            textWriter.Close()


            eRFC = oCFD.eRFC
            RFC = oCFD.RFC
            total = oCFD.total
            sello = oCFD.sello

        End If 'Finaliza Creacion del XML

        If TipoAccion = 2 Then ' Si es un reintento de timbrado

            oCFD = New CFD

            Dim dt As DataTable

            If sTipoComprobante = "ingreso" OrElse sTipoComprobante = "I" Then
                If iTipoComprobante = 6 Then
                    dt = ModPOS.Recupera_Tabla("sp_sello_cargo", "@CARClave", sDOCClave)
                    sello = IIf(dt.Rows(0)("Sello").GetType.Name = "DBNull", "", dt.Rows(0)("Sello"))
                    dt.Dispose()

                    dt = ModPOS.Recupera_Tabla("sp_encabezado_cargo", "@CARClave", sDOCClave)
                    eRFC = dt.Rows(0)("cRFC")
                    RFC = dt.Rows(0)("id_Fiscal")
                    total = dt.Rows(0)("Total")
                    fechaPath = dt.Rows(0)("fecha")
                    VersionCF = dt.Rows(0)("VersionCF")

                Else
                    dt = ModPOS.Recupera_Tabla("sp_sello_fac", "@FACClave", sDOCClave)

                    sello = IIf(dt.Rows(0)("Sello").GetType.Name = "DBNull", "", dt.Rows(0)("Sello"))


                    dt.Dispose()

                    dt = ModPOS.Recupera_Tabla("sp_encabezado_fac", "@FACClave", sDOCClave)
                    eRFC = dt.Rows(0)("cRFC")
                    RFC = dt.Rows(0)("id_Fiscal")
                    total = dt.Rows(0)("Total")
                    fechaPath = dt.Rows(0)("fechaFactura")
                    VersionCF = dt.Rows(0)("VersionCF")
                End If
                dt.Dispose()
            Else

                dt = ModPOS.Recupera_Tabla("sp_sello_nc", "@NCClave", sDOCClave)
                sello = IIf(dt.Rows(0)("Sello").GetType.Name = "DBNull", "", dt.Rows(0)("Sello"))
                dt.Dispose()

                dt = ModPOS.Recupera_Tabla("sp_encabezado_nc", "@NCClave", sDOCClave)
                eRFC = dt.Rows(0)("cRFC")
                RFC = dt.Rows(0)("id_Fiscal")
                total = dt.Rows(0)("Total")
                fechaPath = dt.Rows(0)("fecha")
                VersionCF = dt.Rows(0)("VersionCF")
                dt.Dispose()


            End If

            oCFD.VersionCF = VersionCF

            oPath = PathXML
            If oPath.Length > 3 AndAlso oPath.Substring(oPath.Length - 1, 1) <> "\" Then
                oPath &= "\"
            End If

            oPath &= fechaPath.Year.ToString & "\" & fechaPath.Month.ToString & "\" & fechaPath.Day.ToString & "\"


            If Not System.IO.File.Exists(FileXML) Then
                If System.IO.File.Exists(oPath & sFolio & ".xml") Then
                    System.IO.File.Copy(oPath & sFolio & ".xml", FileXML)
                Else
                    MessageBox.Show("El archivo " & oPath & sFolio & ".xml no existe o se cambio de lugar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    Exit Function
                End If
            End If


        End If ' Finaliza reintento 



        If TipoAccion <> 3 Then
            If TipoAccion = 2 OrElse oCFD.TipoCF = 2 Then ' Inicia timbrado


                Dim oXml As New XmlDocument()
                oXml.Load(FileXML)

                Dim frmStatusMessage As New frmStatus

                For i = 0 To dtPAC.Rows.Count - 1
                    If dtPAC.Rows(i)("TipoPAC") = 1 Then ' Tralix

                        frmStatusMessage.Show("Solicitado Timbre Fiscal...Tralix")
                        frmStatusMessage.BringToFront()

                        Dim oCfdi As New LibCFDiTralix.CFDiTralix()

                        Dim oTimbre As LibCFDiTralix.com.tralix.pac.TimbreFiscalDigital

                        'https://pruebastfd.tralix.com:7070
                        Try
                            oTimbre = oCfdi.TimbrarCFDi(oXml.OuterXml, dtPAC.Rows(i)("ServerTimbre"), dtPAC.Rows(i)("Customerkey"))

                            If oTimbre Is Nothing AndAlso i = dtPAC.Rows.Count - 1 Then
                                actualizaEdoCFD(sTipoComprobante, sDOCClave, 2, iTipoComprobante)
                                MsgBox("Se tuvo el siguiente error " + vbCrLf + "[" + CType(LibCFDiTralix.CodigoMensaje.eCodigo, Integer).ToString() + "]" + LibCFDiTralix.CodigoMensaje.eCodigo.ToString() + ": " + LibCFDiTralix.CodigoMensaje.sMensaje)
                                UUID = "NO_VALIDO_FOLIO_FISCAL"
                                SelloSAT = "NO_VALIDO_TIMBRE_FISCAL"
                                iTipoPAC = 0
                                fechaTimbrado = Date.Now
                                RfcPAC = ""
                            ElseIf Not oTimbre Is Nothing Then
                                UUID = oTimbre.UUID
                                SelloSAT = oTimbre.selloSAT
                                CertificadoSAT = oTimbre.noCertificadoSAT
                                fechaTimbrado = oTimbre.FechaTimbrado
                                VersionSAT = oTimbre.version
                                iTipoPAC = 1
                                actualizaEdoCFD(sTipoComprobante, sDOCClave, 1, iTipoComprobante)
                                ModPOS.Ejecuta("sp_actualiza_timbre", "@CustomerKey", dtPAC.Rows(i)("CustomerKey"), "@TipoPAC", iTipoPAC)
                                RfcPAC = IIf(dtPAC.Rows(i)("RFC").GetType.Name = "DBNull", "", dtPAC.Rows(i)("RFC"))
                                Exit For
                            End If

                        Catch ex As System.Net.WebException
                            If i = dtPAC.Rows.Count - 1 Then
                                actualizaEdoCFD(sTipoComprobante, sDOCClave, 2, iTipoComprobante)
                                If bShowError = True Then
                                    MsgBox("Se tuvo el siguiente error [" & ex.Message & "]")
                                Else
                                    ModPOS.Ejecuta("st_error_log", "@Modulo", "InvoiceServer", "@TipoDocumento", 2, "@DOCClave", sDOCClave, "@Folio", sFolio, "@Error", ex.Message, "@Usuario", ModPOS.UsuarioActual)

                                End If
                                UUID = "NO_VALIDO_FOLIO_FISCAL"
                                SelloSAT = "NO_VALIDO_TIMBRE_FISCAL"
                                fechaTimbrado = Date.Now
                                iTipoPAC = 0
                                RfcPAC = ""
                            End If
                        End Try

                    ElseIf dtPAC.Rows(i)("TipoPAC") = 2 Then 'iTimbre

                        frmStatusMessage.Show("Solicitado Timbre Fiscal...iTimbre")
                        frmStatusMessage.BringToFront()

                        Dim consulta As String = ObtenerConsultaiTimbre(sFolio, eRFC, dtPAC.Rows(i)("UserId"), dtPAC.Rows(i)("CustomerKey"), FileXML)
                        Dim content As Byte() = System.Text.Encoding.UTF8.GetBytes(consulta)

                        Dim url As String = dtPAC.Rows(i)("ServerTimbre")
                        Dim peticion As System.Net.HttpWebRequest = System.Net.WebRequest.Create(url)

                        peticion.Method = "POST"
                        peticion.ContentType = "application/x-www-form-urlencoded"
                        peticion.ContentLength = content.Length

                        Try
                            Dim requestStream As System.IO.Stream = peticion.GetRequestStream()

                            requestStream.Write(content, 0, content.Length)
                            requestStream.Close()

                            Dim resp As System.Net.HttpWebResponse = peticion.GetResponse()
                            Dim respuesta As String = New System.IO.StreamReader(resp.GetResponseStream).ReadToEnd

                            Dim respJson As Object = Newtonsoft.Json.Linq.JObject.Parse(respuesta)

                            If respJson.Item("result").item("retcode").Value = 1 OrElse respJson.Item("result").item("retcode").Value = 307 Then

                                If respJson.Item("result").item("retcode").Value = 1 Then
                                    UUID = respJson.Item("result").item("UUID").Value

                                    Dim Elementos As String() = respJson.Item("result").item("data").ToString.Split()

                                    For Each sElementos As String In Elementos
                                        If sElementos.Contains("FechaTimbrado=") Then
                                            fechaTimbrado = sElementos.Replace("FechaTimbrado=", "").Replace("""", "")
                                        End If
                                        If sElementos.Contains("noCertificadoSAT=") Then
                                            CertificadoSAT = sElementos.Replace("noCertificadoSAT=", "").Replace("""", "")
                                        End If
                                        'If sElementos.Contains("selloCFD=") Then
                                        '    oCFD.selloCFD = sElementos.Replace("selloCFD=", "").Replace("""", "")
                                        'End If
                                        If sElementos.Contains("selloSAT=") Then
                                            SelloSAT = sElementos.Replace("selloSAT=", "").Replace("""", "")
                                        End If
                                        If sElementos.Contains("version=") Then
                                            VersionSAT = sElementos.Replace("version=", "").Replace("""", "")
                                        End If
                                    Next

                                    RfcPAC = IIf(dtPAC.Rows(i)("RFC").GetType.Name = "DBNull", "", dtPAC.Rows(i)("RFC"))

                                    iTipoPAC = 2
                                    actualizaEdoCFD(sTipoComprobante, sDOCClave, 1, iTipoComprobante)
                                    ModPOS.Ejecuta("sp_actualiza_timbre", "@CustomerKey", dtPAC.Rows(i)("CustomerKey"), "@TipoPAC", iTipoPAC)
                                    Exit For
                                Else
                                    frmStatusMessage.Show(respJson.Item("result").Item("error").Value.ToString() & ", Espere, lo estamos recuperando...iTimbre")

                                    ' Si ya fue timbrado entonces
                                    Dim indice As Integer = respJson.Item("result").Item("error").Value.ToString().IndexOf("UUID")
                                    UUID = respJson.Item("result").Item("error").Value.ToString().Substring(indice)
                                    UUID = UUID.Replace("UUID", "").Trim
                                    RfcPAC = ""
                                    consulta = BuscarCFDiTimbre(dtPAC.Rows(i)("UserId"), dtPAC.Rows(i)("CustomerKey"), eRFC, sFolio, UUID)

                                    Dim content2 As Byte() = System.Text.Encoding.UTF8.GetBytes(consulta)
                                    Dim peticion2 As System.Net.HttpWebRequest = System.Net.WebRequest.Create(url)

                                    peticion2.Method = "POST"
                                    peticion2.ContentType = "application/x-www-form-urlencoded"
                                    peticion2.ContentLength = content2.Length


                                    Dim requestStream2 As System.IO.Stream = peticion2.GetRequestStream()

                                    requestStream2.Write(content2, 0, content2.Length)
                                    requestStream2.Close()

                                    Dim resp2 As System.Net.HttpWebResponse = peticion2.GetResponse()
                                    Dim respuesta2 As String = New System.IO.StreamReader(resp2.GetResponseStream).ReadToEnd

                                    Dim respJson2 As Object = Newtonsoft.Json.Linq.JObject.Parse(respuesta2)

                                    Dim jResult As Newtonsoft.Json.Linq.JArray = respJson2.Item("result").item("data")

                                    Dim Elementos As XmlDocument = New XmlDocument()

                                    Elementos.LoadXml(jResult.Item(0).Item("xml_data").ToString())

                                    Dim oXmlNodos As XmlNodeList = Elementos.GetElementsByTagName("cfdi:Complemento")

                                    Dim o As Integer

                                    For o = 0 To oXmlNodos.ItemOf(0).FirstChild.Attributes.Count - 1

                                        Select Case oXmlNodos.ItemOf(0).FirstChild.Attributes.ItemOf(o).Name
                                            Case Is = "FechaTimbrado"
                                                fechaTimbrado = oXmlNodos.ItemOf(0).FirstChild.Attributes.ItemOf(o).Value

                                            Case Is = "noCertificadoSAT"
                                                CertificadoSAT = oXmlNodos.ItemOf(0).FirstChild.Attributes.ItemOf(o).Value

                                            Case Is = "selloSAT"
                                                SelloSAT = oXmlNodos.ItemOf(0).FirstChild.Attributes.ItemOf(o).Value

                                            Case Is = "version"
                                                VersionSAT = oXmlNodos.ItemOf(0).FirstChild.Attributes.ItemOf(o).Value
                                        End Select

                                    Next
                                    RfcPAC = IIf(dtPAC.Rows(i)("RFC").GetType.Name = "DBNull", "", dtPAC.Rows(i)("RFC"))

                                    iTipoPAC = 2
                                    actualizaEdoCFD(sTipoComprobante, sDOCClave, 1, iTipoComprobante)
                                    ModPOS.Ejecuta("sp_actualiza_timbre", "@CustomerKey", dtPAC.Rows(i)("CustomerKey"), "@TipoPAC", iTipoPAC)
                                    Exit For


                                End If
                            ElseIf i = dtPAC.Rows.Count - 1 Then
                                actualizaEdoCFD(sTipoComprobante, sDOCClave, 2, iTipoComprobante)
                                If bShowError = True Then
                                    MsgBox("Se tuvo el siguiente error [" + respJson.Item("result").Item("retcode").Value.ToString() + "] " + respJson.Item("result").Item("error").Value.ToString())
                                Else
                                    ModPOS.Ejecuta("st_error_log", "@Modulo", "InvoiceServer", "@TipoDocumento", 2, "@DOCClave", sDOCClave, "@Folio", sFolio, "@Error", respJson.Item("result").Item("error").Value.ToString(), "@Usuario", ModPOS.UsuarioActual)

                                End If
                                UUID = "NO_VALIDO_FOLIO_FISCAL"
                                SelloSAT = "NO_VALIDO_TIMBRE_FISCAL"
                                fechaTimbrado = Date.Now
                                iTipoPAC = 0
                                RfcPAC = ""
                            End If
                        Catch ex As System.Net.WebException
                            If i = dtPAC.Rows.Count - 1 Then
                                actualizaEdoCFD(sTipoComprobante, sDOCClave, 2, iTipoComprobante)
                                If bShowError = True Then
                                    MsgBox("Se tuvo el siguiente error [" & ex.Message & "]")
                                Else
                                    ModPOS.Ejecuta("st_error_log", "@Modulo", "InvoiceServer", "@TipoDocumento", 2, "@DOCClave", sDOCClave, "@Folio", sFolio, "@Error", ex.Message, "@Usuario", ModPOS.UsuarioActual)

                                End If
                                UUID = "NO_VALIDO_FOLIO_FISCAL"
                                SelloSAT = "NO_VALIDO_TIMBRE_FISCAL"
                                fechaTimbrado = Date.Now
                                iTipoPAC = 0
                                RfcPAC = ""
                            End If
                        End Try

                    ElseIf dtPAC.Rows(i)("TipoPAC") = 3 Then 'DigitalInvoice

                        frmStatusMessage.Show("Solicitado Timbre Fiscal...Digital Invoice")
                        frmStatusMessage.BringToFront()

                        Dim xmlString As String

                        xmlString = oXml.OuterXml

                        Dim result As String

                        If oCFD.VersionCF = "3.3" Then
                            Dim client As DigitalInvoiceWS33.TimbradoClient = New DigitalInvoiceWS33.TimbradoClient("BasicHttpBinding_ITimbrado1")


                            client.ClientCredentials.UserName.UserName = dtPAC.Rows(i)("UserId")
                            client.ClientCredentials.UserName.Password = dtPAC.Rows(i)("CustomerKey")

                            client.Open()

                            Dim xmlBase64 As String = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(xmlString))
                            Dim xmlCFDI_Timbrado As String = String.Empty
                            Try

                                If dtPAC.Rows(i)("UserId") = "ELEPHANT_WORKS" Then
                                    xmlCFDI_Timbrado = client.TimbrarTestBase64(xmlBase64)
                                Else
                                    xmlCFDI_Timbrado = client.TimbrarBase64(xmlBase64)
                                End If
                                result = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(xmlCFDI_Timbrado))


                                Dim Elementos As String() = result.Split()

                                For Each sElementos As String In Elementos
                                    If sElementos.Contains("UUID=") Then
                                        UUID = sElementos.Replace("UUID=", "").Replace("""", "")
                                    End If
                                    If sElementos.Contains("FechaTimbrado=") Then
                                        fechaTimbrado = sElementos.Replace("FechaTimbrado=", "").Replace("""", "")
                                    End If
                                    If sElementos.Contains("NoCertificadoSAT=") Then
                                        CertificadoSAT = sElementos.Replace("NoCertificadoSAT=", "").Replace("""", "")
                                    End If

                                    If sElementos.Contains("SelloSAT=") Then
                                        SelloSAT = sElementos.Replace("SelloSAT=", "").Replace("""", "")
                                    End If
                                    If sElementos.Contains("Version=") Then
                                        VersionSAT = sElementos.Replace("Version=", "").Replace("""", "")
                                    End If

                                    If sElementos.Contains("RfcProvCertif=") Then
                                        RfcPAC = sElementos.Replace("RfcProvCertif=", "").Replace("""", "")
                                    End If
                                Next

                                iTipoPAC = 3
                                actualizaEdoCFD(sTipoComprobante, sDOCClave, 1, iTipoComprobante)
                                ModPOS.Ejecuta("sp_actualiza_timbre", "@CustomerKey", dtPAC.Rows(i)("CustomerKey"), "@TipoPAC", iTipoPAC)
                                Exit For

                            Catch ex As Exception

                                If ex.Message = "El CFDI contiene un timbre previo." Then

                                    xmlCFDI_Timbrado = client.RecuperarTimbreBase64(xmlBase64)

                                    result = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(xmlCFDI_Timbrado))


                                    Dim Elementos As String() = result.Split()

                                    For Each sElementos As String In Elementos
                                        If sElementos.Contains("UUID=") Then
                                            UUID = sElementos.Replace("UUID=", "").Replace("""", "")
                                        End If
                                        If sElementos.Contains("FechaTimbrado=") Then
                                            fechaTimbrado = sElementos.Replace("FechaTimbrado=", "").Replace("""", "")
                                        End If
                                        If sElementos.Contains("NoCertificadoSAT=") Then
                                            CertificadoSAT = sElementos.Replace("NoCertificadoSAT=", "").Replace("""", "")
                                        End If

                                        If sElementos.Contains("SelloSAT=") Then
                                            SelloSAT = sElementos.Replace("SelloSAT=", "").Replace("""", "")
                                        End If
                                        If sElementos.Contains("Version=") Then
                                            VersionSAT = sElementos.Replace("Version=", "").Replace("""", "")
                                        End If

                                        If sElementos.Contains("RfcProvCertif=") Then
                                            RfcPAC = sElementos.Replace("RfcProvCertif=", "").Replace("""", "")
                                        End If
                                    Next
                                    iTipoPAC = 3
                                    actualizaEdoCFD(sTipoComprobante, sDOCClave, 1, iTipoComprobante)
                                    ModPOS.Ejecuta("sp_actualiza_timbre", "@CustomerKey", dtPAC.Rows(i)("CustomerKey"), "@TipoPAC", iTipoPAC)
                                    Exit For
                                Else
                                    If i = dtPAC.Rows.Count - 1 Then
                                        actualizaEdoCFD(sTipoComprobante, sDOCClave, 2, iTipoComprobante)
                                        If bShowError = True Then
                                            MsgBox("Se tuvo el siguiente error [" & ex.Message & "]")
                                        Else
                                            ModPOS.Ejecuta("st_error_log", "@Modulo", "InvoiceServer", "@TipoDocumento", 2, "@DOCClave", sDOCClave, "@Folio", sFolio, "@Error", ex.Message, "@Usuario", ModPOS.UsuarioActual)

                                        End If
                                        UUID = "NO_VALIDO_FOLIO_FISCAL"
                                        SelloSAT = "NO_VALIDO_TIMBRE_FISCAL"
                                        fechaTimbrado = Date.Now
                                        iTipoPAC = 0
                                        RfcPAC = ""
                                    End If
                                End If

                            End Try

                        Else '3.2
                            Dim client As DigitalInvoiceWS.TimbradoClient = New DigitalInvoiceWS.TimbradoClient("BasicHttpBinding_ITimbrado")

                            'If oCFD.VersionCF = "3.3" Then
                            '    client.Endpoint.Address = New System.ServiceModel.EndpointAddress(dtPAC.Rows(i)("ServerTimbre").ToString)
                            'End If

                            client.ClientCredentials.UserName.UserName = dtPAC.Rows(i)("UserId")
                            client.ClientCredentials.UserName.Password = dtPAC.Rows(i)("CustomerKey")

                            client.Open()

                            Dim xmlBase64 As String = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(xmlString))
                            Dim xmlCFDI_Timbrado As String = String.Empty
                            Try

                                If dtPAC.Rows(i)("UserId") = "ELEPHANT_WORKS" Then
                                    xmlCFDI_Timbrado = client.TimbrarTestBase64(xmlBase64)
                                Else
                                    xmlCFDI_Timbrado = client.TimbrarBase64(xmlBase64)
                                End If
                                result = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(xmlCFDI_Timbrado))


                                Dim Elementos As String() = result.Split()

                                For Each sElementos As String In Elementos
                                    If sElementos.Contains("UUID=") Then
                                        UUID = sElementos.Replace("UUID=", "").Replace("""", "")
                                    End If
                                    If sElementos.Contains("FechaTimbrado=") Then
                                        fechaTimbrado = sElementos.Replace("FechaTimbrado=", "").Replace("""", "")
                                    End If
                                    If sElementos.Contains("noCertificadoSAT=") Then
                                        CertificadoSAT = sElementos.Replace("noCertificadoSAT=", "").Replace("""", "")
                                    End If

                                    If sElementos.Contains("selloSAT=") Then
                                        SelloSAT = sElementos.Replace("selloSAT=", "").Replace("""", "")
                                    End If
                                    If sElementos.Contains("version=") Then
                                        VersionSAT = sElementos.Replace("version=", "").Replace("""", "")
                                    End If
                                Next
                                RfcPAC = IIf(dtPAC.Rows(i)("RFC").GetType.Name = "DBNull", "", dtPAC.Rows(i)("RFC"))

                                iTipoPAC = 3
                                actualizaEdoCFD(sTipoComprobante, sDOCClave, 1, iTipoComprobante)
                                ModPOS.Ejecuta("sp_actualiza_timbre", "@CustomerKey", dtPAC.Rows(i)("CustomerKey"), "@TipoPAC", iTipoPAC)
                                Exit For

                            Catch ex As Exception

                                If ex.Message = "El CFDI contiene un timbre previo." Then

                                    xmlCFDI_Timbrado = client.RecuperarTimbreBase64(xmlBase64)

                                    result = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(xmlCFDI_Timbrado))


                                    Dim Elementos As String() = result.Split()

                                    For Each sElementos As String In Elementos
                                        If sElementos.Contains("UUID=") Then
                                            UUID = sElementos.Replace("UUID=", "").Replace("""", "")
                                        End If
                                        If sElementos.Contains("FechaTimbrado=") Then
                                            fechaTimbrado = sElementos.Replace("FechaTimbrado=", "").Replace("""", "")
                                        End If
                                        If sElementos.Contains("noCertificadoSAT=") Then
                                            CertificadoSAT = sElementos.Replace("noCertificadoSAT=", "").Replace("""", "")
                                        End If

                                        If sElementos.Contains("selloSAT=") Then
                                            SelloSAT = sElementos.Replace("selloSAT=", "").Replace("""", "")
                                        End If
                                        If sElementos.Contains("version=") Then
                                            VersionSAT = sElementos.Replace("version=", "").Replace("""", "")
                                        End If
                                    Next
                                    RfcPAC = IIf(dtPAC.Rows(i)("RFC").GetType.Name = "DBNull", "", dtPAC.Rows(i)("RFC"))

                                    iTipoPAC = 3
                                    actualizaEdoCFD(sTipoComprobante, sDOCClave, 1, iTipoComprobante)
                                    ModPOS.Ejecuta("sp_actualiza_timbre", "@CustomerKey", dtPAC.Rows(i)("CustomerKey"), "@TipoPAC", iTipoPAC)
                                    Exit For
                                Else
                                    If i = dtPAC.Rows.Count - 1 Then
                                        actualizaEdoCFD(sTipoComprobante, sDOCClave, 2, iTipoComprobante)
                                        If bShowError = True Then
                                            MsgBox("Se tuvo el siguiente error [" & ex.Message & "]")
                                        Else
                                            ModPOS.Ejecuta("st_error_log", "@Modulo", "InvoiceServer", "@TipoDocumento", 2, "@DOCClave", sDOCClave, "@Folio", sFolio, "@Error", ex.Message, "@Usuario", ModPOS.UsuarioActual)

                                        End If
                                        UUID = "NO_VALIDO_FOLIO_FISCAL"
                                        SelloSAT = "NO_VALIDO_TIMBRE_FISCAL"
                                        fechaTimbrado = Date.Now
                                        iTipoPAC = 0
                                        RfcPAC = ""
                                    End If
                                End If

                            End Try

                        End If

                    ElseIf dtPAC.Rows(i)("TipoPAC") = 4 Then 'Detecno

                        frmStatusMessage.Show("Solicitado Timbre Fiscal...Detecno")
                        frmStatusMessage.BringToFront()

                        Dim xmlString As String

                        xmlString = oXml.OuterXml

                        If oCFD.VersionCF = "3.3" Then

                            Dim client As DetecnoPAC33.DetecnoPacClient = New DetecnoPAC33.DetecnoPacClient()

                            Dim xmlRespuesta As DetecnoPAC33.Xml = New DetecnoPAC33.Xml()

                            If dtPAC.Rows(i)("UserId") = "AAAAAA\wsTIMBRADOR" Then
                                client.Endpoint.Address = New System.ServiceModel.EndpointAddress("https://test.timbra.mx/WCFTimbrador33/DetecnoPAC.svc")

                            Else
                                If dtPAC.Rows(i)("ServerTimbre") = "" Then
                                    client.Endpoint.Address = New System.ServiceModel.EndpointAddress("https://www.timbra.mx/WCFTimbrador33/DetecnoPac.svc")
                                Else
                                    client.Endpoint.Address = New System.ServiceModel.EndpointAddress(dtPAC.Rows(i)("ServerTimbre").ToString)
                                End If

                            End If

                            xmlRespuesta = client.TimbrarCfdi(dtPAC.Rows(i)("UserId"), dtPAC.Rows(i)("CustomerKey"), xmlString)

                            Dim bError As Boolean = False

                            If xmlRespuesta.Success Then
                                Dim strXmlTfd As String = xmlRespuesta.XmlTfd
                                ' Dim strCoTfd As String = xmlRespuesta.CoTfd
                                'Dim strQR As String = xmlRespuesta.StrQr

                                Try


                                    Dim Elementos As String() = strXmlTfd.Split()

                                    For Each sElementos As String In Elementos
                                        If sElementos.Contains("UUID=") Then
                                            UUID = sElementos.Replace("UUID=", "").Replace("""", "")
                                        End If
                                        If sElementos.Contains("FechaTimbrado=") Then
                                            fechaTimbrado = sElementos.Replace("FechaTimbrado=", "").Replace("""", "")
                                        End If
                                        If sElementos.Contains("NoCertificadoSAT=") Then
                                            CertificadoSAT = sElementos.Replace("NoCertificadoSAT=", "").Replace("""", "")
                                        End If

                                        If sElementos.Contains("SelloSAT=") Then
                                            SelloSAT = sElementos.Replace("SelloSAT=", "").Replace("""", "")
                                        End If
                                        If sElementos.Contains("Version=") Then
                                            VersionSAT = sElementos.Replace("Version=", "").Replace("""", "")
                                        End If

                                        If sElementos.Contains("RfcProvCertif=") Then
                                            RfcPAC = sElementos.Replace("RfcProvCertif=", "").Replace("""", "")
                                        End If


                                    Next

                                Catch ex As Exception
                                    If i = dtPAC.Rows.Count - 1 Then

                                        actualizaEdoCFD(sTipoComprobante, sDOCClave, 2, iTipoComprobante)
                                        If bShowError = True Then
                                            MsgBox("Se tuvo el siguiente error [" & ex.Message & "]")
                                        Else
                                            ModPOS.Ejecuta("st_error_log", "@Modulo", "InvoiceServer", "@TipoDocumento", 2, "@DOCClave", sDOCClave, "@Folio", sFolio, "@Error", ex.Message, "@Usuario", ModPOS.UsuarioActual)

                                        End If
                                        UUID = "NO_VALIDO_FOLIO_FISCAL"
                                        SelloSAT = "NO_VALIDO_TIMBRE_FISCAL"
                                        fechaTimbrado = Date.Now
                                        iTipoPAC = 0
                                        RfcPAC = ""
                                    End If
                                    bError = True
                                End Try

                                If bError = False Then
                                    iTipoPAC = 4
                                    actualizaEdoCFD(sTipoComprobante, sDOCClave, 1, iTipoComprobante)
                                    ModPOS.Ejecuta("sp_actualiza_timbre", "@CustomerKey", dtPAC.Rows(i)("CustomerKey"), "@TipoPAC", iTipoPAC)
                                    Exit For
                                End If

                            Else
                                Dim sError As String = xmlRespuesta.ErrDesc

                                If i = dtPAC.Rows.Count - 1 Then

                                    actualizaEdoCFD(sTipoComprobante, sDOCClave, 2, iTipoComprobante)
                                    If bShowError = True Then
                                        MsgBox("Se tuvo el siguiente error [" & sError & "]")
                                    Else
                                        ModPOS.Ejecuta("st_error_log", "@Modulo", "InvoiceServer", "@TipoDocumento", 2, "@DOCClave", sDOCClave, "@Folio", sFolio, "@Error", sError, "@Usuario", ModPOS.UsuarioActual)

                                    End If
                                    UUID = "NO_VALIDO_FOLIO_FISCAL"
                                    SelloSAT = "NO_VALIDO_TIMBRE_FISCAL"
                                    fechaTimbrado = Date.Now
                                    iTipoPAC = 0
                                    RfcPAC = ""
                                End If


                            End If

                        Else 'Version 3.2
                            Dim client As DetecnoPAC.DetecnoPacClient = New DetecnoPAC.DetecnoPacClient()

                            Dim xmlRespuesta As DetecnoPAC.Xml = New DetecnoPAC.Xml()

                            If dtPAC.Rows(i)("UserId") = "AAAAAA\wsTIMBRADOR" Then
                                client.Endpoint.Address = New System.ServiceModel.EndpointAddress("https://test.timbra.mx/WCFTimbrador/DetecnoPAC.svc")
                            Else
                                If dtPAC.Rows(i)("ServerTimbre") = "" Then
                                    client.Endpoint.Address = New System.ServiceModel.EndpointAddress("https://www.timbra.mx/WCFTimbrador/DetecnoPac.svc")
                                Else
                                    client.Endpoint.Address = New System.ServiceModel.EndpointAddress(dtPAC.Rows(i)("ServerTimbre").ToString)
                                End If

                            End If

                            xmlRespuesta = client.TimbrarCfdi(dtPAC.Rows(i)("UserId"), dtPAC.Rows(i)("CustomerKey"), xmlString)


                            If xmlRespuesta.Success Then
                                Dim strXmlTfd As String = xmlRespuesta.XmlTfd
                                ' Dim strCoTfd As String = xmlRespuesta.CoTfd
                                'Dim strQR As String = xmlRespuesta.StrQr

                                Dim Elementos As String() = strXmlTfd.Split()

                                For Each sElementos As String In Elementos
                                    If sElementos.Contains("UUID=") Then
                                        UUID = sElementos.Replace("UUID=", "").Replace("""", "")
                                    End If
                                    If sElementos.Contains("FechaTimbrado=") Then
                                        fechaTimbrado = sElementos.Replace("FechaTimbrado=", "").Replace("""", "")
                                    End If
                                    If sElementos.Contains("noCertificadoSAT=") Then
                                        CertificadoSAT = sElementos.Replace("noCertificadoSAT=", "").Replace("""", "")
                                    End If

                                    If sElementos.Contains("selloSAT=") Then
                                        SelloSAT = sElementos.Replace("selloSAT=", "").Replace("""", "")
                                    End If
                                    If sElementos.Contains("version=") Then
                                        VersionSAT = sElementos.Replace("version=", "").Replace("""", "")
                                    End If
                                Next

                                RfcPAC = IIf(dtPAC.Rows(i)("RFC").GetType.Name = "DBNull", "", dtPAC.Rows(i)("RFC"))

                                iTipoPAC = 4
                                actualizaEdoCFD(sTipoComprobante, sDOCClave, 1, iTipoComprobante)
                                ModPOS.Ejecuta("sp_actualiza_timbre", "@CustomerKey", dtPAC.Rows(i)("CustomerKey"), "@TipoPAC", iTipoPAC)
                                Exit For

                            Else
                                Dim sError As String = xmlRespuesta.ErrDesc

                                If i = dtPAC.Rows.Count - 1 Then
                                    actualizaEdoCFD(sTipoComprobante, sDOCClave, 2, iTipoComprobante)
                                    If bShowError = True Then
                                        MsgBox("Se tuvo el siguiente error [" & sError & "]")
                                    Else
                                        ModPOS.Ejecuta("st_error_log", "@Modulo", "InvoiceServer", "@TipoDocumento", 2, "@DOCClave", sDOCClave, "@Folio", sFolio, "@Error", sError, "@Usuario", ModPOS.UsuarioActual)

                                    End If
                                    UUID = "NO_VALIDO_FOLIO_FISCAL"
                                    SelloSAT = "NO_VALIDO_TIMBRE_FISCAL"
                                    fechaTimbrado = Date.Now
                                    iTipoPAC = 0
                                    RfcPAC = ""
                                End If


                            End If


                        End If




                    End If
                Next


                ' Area comun de timbrado

                frmStatusMessage.Dispose()

                If oCFD.VersionCF = "3.3" Then
                    CBB = ModPOS.crearQR33(eRFC, RFC, total, UUID, Right(oCFD.sello, 8))

                Else
                    CBB = ModPOS.crearQR(eRFC, RFC, total, UUID)
                End If

                If iTipoPAC = 0 Then
                    oXml.Save(FileXML)
                Else
                    Dim newElem As XmlElement = oXml.CreateElement("cfdi", "Complemento", "http://www.sat.gob.mx/cfd/3")
                    Dim newEle1 As XmlElement = oXml.CreateElement("tfd", "TimbreFiscalDigital", "http://www.sat.gob.mx/TimbreFiscalDigital")

                    Dim newAttr As XmlAttribute

                    If VersionCF <> "3.3" Then

                        newAttr = oXml.CreateAttribute("xsi", "schemaLocation", "http://www.w3.org/2001/XMLSchema-instance")
                        newAttr.Value = "http://www.sat.gob.mx/TimbreFiscalDigital http://www.sat.gob.mx/TimbreFiscalDigital/TimbreFiscalDigital.xsd"
                        newEle1.Attributes.Append(newAttr)

                        newAttr = oXml.CreateAttribute("selloCFD")
                        newAttr.Value = sello
                        newEle1.Attributes.Append(newAttr)

                        newAttr = oXml.CreateAttribute("selloSAT")
                        newAttr.Value = SelloSAT
                        newEle1.Attributes.Append(newAttr)

                        newAttr = oXml.CreateAttribute("UUID")
                        newAttr.Value = UUID
                        newEle1.Attributes.Append(newAttr)


                        newAttr = oXml.CreateAttribute("FechaTimbrado")
                        newAttr.Value = String.Format("{0:yyyy-MM-ddTHH:mm:ss}", fechaTimbrado)
                        newEle1.Attributes.Append(newAttr)


                        newAttr = oXml.CreateAttribute("version")
                        newAttr.Value = VersionSAT
                        newEle1.Attributes.Append(newAttr)

                        newAttr = oXml.CreateAttribute("noCertificadoSAT")
                        newAttr.Value = CertificadoSAT
                        newEle1.Attributes.Append(newAttr)
                    Else

                        newAttr = oXml.CreateAttribute("xsi", "schemaLocation", "http://www.w3.org/2001/XMLSchema-instance")
                        newAttr.Value = "http://www.sat.gob.mx/TimbreFiscalDigital http://www.sat.gob.mx/sitio_internet/cfd/TimbreFiscalDigital/TimbreFiscalDigitalv11.xsd"
                        newEle1.Attributes.Append(newAttr)

                        newAttr = oXml.CreateAttribute("Version")
                        newAttr.Value = VersionSAT
                        newEle1.Attributes.Append(newAttr)

                        newAttr = oXml.CreateAttribute("UUID")
                        newAttr.Value = UUID
                        newEle1.Attributes.Append(newAttr)

                        newAttr = oXml.CreateAttribute("FechaTimbrado")
                        newAttr.Value = String.Format("{0:yyyy-MM-ddTHH:mm:ss}", fechaTimbrado)
                        newEle1.Attributes.Append(newAttr)

                        newAttr = oXml.CreateAttribute("RfcProvCertif")
                        newAttr.Value = RfcPAC
                        newEle1.Attributes.Append(newAttr)

                        newAttr = oXml.CreateAttribute("SelloCFD")
                        newAttr.Value = sello
                        newEle1.Attributes.Append(newAttr)

                        newAttr = oXml.CreateAttribute("NoCertificadoSAT")
                        newAttr.Value = CertificadoSAT
                        newEle1.Attributes.Append(newAttr)

                        newAttr = oXml.CreateAttribute("SelloSAT")
                        newAttr.Value = SelloSAT
                        newEle1.Attributes.Append(newAttr)
                    End If

                    newElem.AppendChild(newEle1)
                    oXml.DocumentElement.AppendChild(newElem)
                    oXml.Save(FileXML)

                End If
            End If
        End If

        If TipoAccion = 1 OrElse TipoAccion = 4 Then
            If iTipoPAC = 0 Then
                fechaTimbrado = CDate(oCFD.Fecha)
            End If

            If sTipoComprobante = "ingreso" OrElse sTipoComprobante = "I" Then
                If iTipoComprobante = 6 Then
                    ModPOS.Ejecuta("sp_inserta_sellocargo", "@CARClave", sDOCClave, "@Certificado", oCFD.noCertificado, "@cadenaOriginal", oCFD.cadenaOriginal, "@Sello", oCFD.sello, "@Certificado64", oCFD.Certificado64, "@CBB", CBB, "@UUID", UUID, "@SelloSAT", SelloSAT, "@CertificadoSAT", CertificadoSAT, "@fechaTimbrado", fechaTimbrado, "@versionSAT", VersionSAT, "@TipoPAC", iTipoPAC, "@RfcProvCertif", RfcPAC, "@UUID_Anterior", oCFD.UUID_Sustituido)
                Else
                    ModPOS.Ejecuta("sp_inserta_sello", "@FACClave", sDOCClave, "@noAprobacion", oCFD.noAprobacion, "@anoAprobacion", oCFD.anoAprobacion, "@Certificado", oCFD.noCertificado, "@cadenaOriginal", oCFD.cadenaOriginal, "@Sello", oCFD.sello, "@Certificado64", oCFD.Certificado64, "@CBB", CBB, "@UUID", UUID, "@SelloSAT", SelloSAT, "@CertificadoSAT", CertificadoSAT, "@fechaTimbrado", fechaTimbrado, "@versionSAT", VersionSAT, "@TipoPAC", iTipoPAC, "@RfcProvCertif", RfcPAC, "@UUID_Anterior", oCFD.UUID_Sustituido)
                End If
            Else
                ModPOS.Ejecuta("sp_inserta_sellonc", "@NCClave", sDOCClave, "@noAprobacion", oCFD.noAprobacion, "@anoAprobacion", oCFD.anoAprobacion, "@Certificado", oCFD.noCertificado, "@cadenaOriginal", oCFD.cadenaOriginal, "@Sello", oCFD.sello, "@Certificado64", oCFD.Certificado64, "@CBB", CBB, "@UUID", UUID, "@SelloSAT", SelloSAT, "@CertificadoSAT", CertificadoSAT, "@fechaTimbrado", fechaTimbrado, "@versionSAT", VersionSAT, "@TipoPAC", iTipoPAC, "@RfcProvCertif", RfcPAC, "@UUID_Anterior", oCFD.UUID_Sustituido)
            End If

        ElseIf TipoAccion = 2 Then
            ModPOS.Ejecuta("sp_actualiza_timbrado", "@Tipo", sTipoComprobante, "@DOCClave", sDOCClave, "@CBB", CBB, "@UUID", UUID, "@SelloSAT", SelloSAT, "@CertificadoSAT", CertificadoSAT, "@fechaTimbrado", fechaTimbrado, "@versionSAT", VersionSAT, "@TipoPAC", iTipoPAC, "@TipoComprobante", iTipoComprobante, "@RfcProvCertif", RfcPAC)
        ElseIf TipoAccion = 3 Then
            ModPOS.Ejecuta("sp_actualiza_cbb", "@Tipo", sTipoComprobante, "@DOCClave", sDOCClave, "@CBB", CBB, "@TipoComprobante", iTipoComprobante)
        End If

        If oCFD.AplicaAnticipo = True AndAlso iTipoPAC <> 0 AndAlso (iTipoComprobante = 1 OrElse iTipoComprobante = 6) Then
            Dim dt As DataTable = Recupera_Tabla("st_obtiene_apl_anticipo", "@DOCClave", sDOCClave)
            If dt.Rows.Count > 0 Then
                Dim a, iTipoDocumento As Integer
                For a = 0 To dt.Rows.Count - 1
                    iTipoDocumento = IIf(dt.Rows(0)("TipoDocumento").GetType.Name = "DBNull", 2, dt.Rows(0)("TipoDocumento"))

                    TimbraEgreso(dt.Rows(0)("ANTClave"), dt.Rows(0)("DOCClave"), iTipoDocumento, PathXML, oCFD.VersionCF, dtPAC, oCFD.regimenFiscal, sInterfazSalida, bShowError, False)
                Next
            End If
            dt.Dispose()
        End If

        If iTipoPAC <> 0 Then

            'Verifica que exista el path
            Try
                If System.IO.Directory.Exists(PathXML) Then

                    oPath = PathXML
                    If oPath.Length > 3 AndAlso oPath.Substring(oPath.Length - 1, 1) <> "\" Then
                        oPath &= "\"
                    End If


                    oPath &= fechaPath.Year.ToString & "\" & fechaPath.Month.ToString & "\" & fechaPath.Day.ToString & "\"


                    If Not System.IO.Directory.Exists(oPath) Then
                        System.IO.Directory.CreateDirectory(oPath)
                    End If

                    oFileXML = oPath & sFolio & ".xml"

                    If System.IO.File.Exists(oFileXML) Then
                        If FileXML <> oFileXML Then
                            System.IO.File.Delete(oFileXML)
                        End If
                    End If



                    'Verifica si existe carpeta Temp
                    If sInterfazSalida <> "" Then
                        Try
                            If Not System.IO.Directory.Exists(PathXML & "\Temp") Then
                                System.IO.Directory.CreateDirectory(PathXML & "\Temp")
                            End If

                            Dim oTemp As String
                            If PathXML.Length <= 3 Then
                                oTemp = PathXML & "Temp\" & sFolio & ".xml"
                            ElseIf PathXML.Substring(PathXML.Length - 1, 1) = "\" Then
                                oTemp = PathXML & "Temp\" & sFolio & ".xml"
                            Else
                                oTemp = PathXML & "\" & "Temp\" & sFolio & ".xml"
                            End If

                            If System.IO.File.Exists(oTemp) Then
                                If FileXML <> oTemp Then
                                    System.IO.File.Delete(oTemp)
                                End If
                            End If
                            If FileXML <> oTemp Then
                                System.IO.File.Copy(FileXML, oTemp)
                            End If


                        Catch ex As Exception
                        End Try


                    End If


                    If FileXML <> oFileXML Then
                        System.IO.File.Move(FileXML, oFileXML)
                    End If

                Else
                    MessageBox.Show("El directorio " & PathXML & " no existe o no se puede tener acceso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
            End Try
        End If


        If sInterfazSalida <> "" AndAlso TipoAccion <> 3 AndAlso TipoAccion <> 4 AndAlso iTipoPAC <> 0 Then
            Dim sFecha As String
            Dim dtInterfaz As DataTable
            sFecha = DateTime.Now.ToString("yyyyMMdd_HHmmssfff")

            Dim InterfazCobros As String = ""
            Dim InterfazAnticipos As String = ""

            Select Case iTipoComprobante
                Case Is = 1 'Factura
                    dtInterfaz = Recupera_Tabla("st_recupera_interfaz", "@Interfaz", "Factura", "@COMClave", ModPOS.CompanyActual)
                    If dtInterfaz.Rows.Count > 0 Then
                        ModPOS.Ejecuta(CStr(dtInterfaz.Rows(0)("sp")), "@Folio", sDOCClave, "@TipoDocumento", 0, "@Path", sInterfazSalida, "@Fecha", sFecha)
                    End If

                    If TipoAccion = 1 OrElse TipoAccion = 2 Then

                        Dim dt As DataTable = Nothing
                        dt = Recupera_Tabla("st_recupera_interfaz", "@Interfaz", "Cobros", "@COMClave", ModPOS.CompanyActual)
                        If dt.Rows.Count > 0 Then
                            InterfazCobros = CStr(dt.Rows(0)("sp"))
                        End If
                        dt.Dispose()

                        dt = Recupera_Tabla("st_recupera_interfaz", "@Interfaz", "AsignacionAnticipo", "@COMClave", ModPOS.CompanyActual)
                        If dt.Rows.Count > 0 Then
                            InterfazAnticipos = CStr(dt.Rows(0)("sp"))
                        End If
                        dt.Dispose()

                        If InterfazCobros <> "" OrElse InterfazAnticipos <> "" Then

                            Dim detallePago As DataTable = Recupera_Tabla("st_recupera_pagos", "@FACClave", sDOCClave)

                            For i = 0 To detallePago.Rows.Count - 1
                                sFecha = DateTime.Now.ToString("yyyyMMdd_HHmmssfff")
                                sFolio = detallePago.Rows(i)("ABNClave")
                                If detallePago.Rows(i)("Tipo") = 1 AndAlso InterfazCobros <> "" Then
                                    ModPOS.Ejecuta(InterfazCobros, "@Folio", sFolio, "@TipoDocumento", detallePago.Rows(i)("TipoPago"), "@Path", sInterfazSalida, "@Fecha", sFecha, "@Tipo", 2)
                                ElseIf detallePago.Rows(i)("Tipo") = 2 AndAlso InterfazAnticipos <> "" Then
                                    ModPOS.Ejecuta(InterfazAnticipos, "@Folio", sFolio, "@TipoDocumento", detallePago.Rows(i)("TipoPago"), "@Path", sInterfazSalida, "@Fecha", sFecha)
                                End If
                            Next


                        End If



                    End If

                Case Is = 6 'Nota de Cargo
                    dtInterfaz = Recupera_Tabla("st_recupera_interfaz", "@Interfaz", "NotaCargo", "@COMClave", ModPOS.CompanyActual)
                    If dtInterfaz.Rows.Count > 0 Then
                        ModPOS.Ejecuta(CStr(dtInterfaz.Rows(0)("sp")), "@Folio", sDOCClave, "@TipoDocumento", 0, "@Path", sInterfazSalida, "@Fecha", sFecha)
                    End If
                Case Is = 7  ' Nota de Credito

                    dtInterfaz = Recupera_Tabla("st_recupera_interfaz", "@Interfaz", "NotaCredito", "@COMClave", ModPOS.CompanyActual)
                    If dtInterfaz.Rows.Count > 0 Then
                        ModPOS.Ejecuta(CStr(dtInterfaz.Rows(0)("sp")), "@Folio", sDOCClave, "@TipoDocumento", 0, "@Path", sInterfazSalida, "@Fecha", sFecha)
                    End If


                    'validar si existe cambio de estado
                    Dim dtX As DataTable = ModPOS.Recupera_Tabla("st_recupera_cambio_estado", "@DOCClave", sDOCClave)
                    If dtX.Rows.Count > 0 Then
                        sFecha = DateTime.Now.ToString("yyyyMMdd_HHmmssfff")

                        dtInterfaz = Recupera_Tabla("st_recupera_interfaz", "@Interfaz", "CambioEstado", "@COMClave", ModPOS.CompanyActual)
                        If dtInterfaz.Rows.Count > 0 Then
                            ModPOS.Ejecuta(CStr(dtInterfaz.Rows(0)("sp")), "@Folio", sDOCClave, "@TipoDocumento", 0, "@Path", sInterfazSalida, "@Fecha", sFecha)
                        End If
                    End If
                    dtX.Dispose()

            End Select
        End If


        Return iTipoPAC

    End Function

    Public Function ObtenerConsultaiTimbre(ByVal Id As String, ByVal RFC As String, ByVal User As String, ByVal Pass As String, ByVal RutaXML As String) As String
        Dim lector As System.IO.StreamReader = New System.IO.StreamReader(RutaXML)
        Dim xml As Object = lector.ReadToEnd()
        lector.Close()

        Dim jObj As Object = New Newtonsoft.Json.Linq.JObject(New Newtonsoft.Json.Linq.JProperty("id", Id), New Newtonsoft.Json.Linq.JProperty("method", "cfd2cfdi"), New Newtonsoft.Json.Linq.JProperty("params", New Newtonsoft.Json.Linq.JObject(New Newtonsoft.Json.Linq.JProperty("RFC", RFC), New Newtonsoft.Json.Linq.JProperty("user", User), New Newtonsoft.Json.Linq.JProperty("pass", Pass), New Newtonsoft.Json.Linq.JProperty("xmldata", xml))))

        Dim consulta As String = "q=" + System.Web.HttpUtility.UrlEncode(jObj.ToString())

        My.Computer.FileSystem.DeleteFile(RutaXML)

        Return consulta
    End Function

    Public Function BuscarCFDiTimbre(ByVal User As String, ByVal Pass As String, ByVal RFC As String, ByVal Id As String, ByVal UUID As String) As String
        Dim jObj As Object = New Newtonsoft.Json.Linq.JObject(New Newtonsoft.Json.Linq.JProperty("method", "buscarCFDI"), New Newtonsoft.Json.Linq.JProperty("params", New Newtonsoft.Json.Linq.JObject(New Newtonsoft.Json.Linq.JProperty("user", User), New Newtonsoft.Json.Linq.JProperty("pass", Pass), New Newtonsoft.Json.Linq.JProperty("RFC", RFC), New Newtonsoft.Json.Linq.JProperty("id", Id), New Newtonsoft.Json.Linq.JProperty("UUID", UUID))))
        Dim consulta As String = "q=" + System.Web.HttpUtility.UrlEncode(jObj.ToString())
        Return consulta
    End Function

    Public Function CancelarFacturaiTimbre(ByVal Id As String, ByVal RFC As String, ByVal User As String, ByVal Pass As String, ByVal UUID As Array, ByVal pfx_pass As String, ByVal pfx_pem As String, ByVal ServidorTimbre As String) As String
        Dim sResult As String = ""
        Dim jObj As Object = New Newtonsoft.Json.Linq.JObject(New Newtonsoft.Json.Linq.JProperty("id", Id), New Newtonsoft.Json.Linq.JProperty("method", "cancelarCFDI"), New Newtonsoft.Json.Linq.JProperty("params", New Newtonsoft.Json.Linq.JObject(New Newtonsoft.Json.Linq.JProperty("user", User), New Newtonsoft.Json.Linq.JProperty("pass", Pass), New Newtonsoft.Json.Linq.JProperty("RFC", RFC), New Newtonsoft.Json.Linq.JProperty("pfx_pass", pfx_pass), New Newtonsoft.Json.Linq.JProperty("pfx_pem", pfx_pem), New Newtonsoft.Json.Linq.JProperty("folios", UUID))))

        Dim consulta As String = "q=" + System.Web.HttpUtility.UrlEncode(jObj.ToString())

        Dim content As Byte() = System.Text.Encoding.UTF8.GetBytes(consulta)

        Dim url As String = ServidorTimbre
        Dim peticion As System.Net.HttpWebRequest = System.Net.WebRequest.Create(url)

        peticion.Method = "POST"
        peticion.ContentType = "application/x-www-form-urlencoded"
        peticion.ContentLength = content.Length

        Dim requestStream As System.IO.Stream = peticion.GetRequestStream()
        requestStream.Write(content, 0, content.Length)
        requestStream.Close()

        Dim resp As System.Net.HttpWebResponse = peticion.GetResponse()
        Dim respuesta As String = New System.IO.StreamReader(resp.GetResponseStream).ReadToEnd

        Dim respJson As Object = Newtonsoft.Json.Linq.JObject.Parse(respuesta)

        If respJson.Item("result").item("retcode").Value <> 1 Then
            sResult = "Se tuvo el siguiente error [" + respJson.Item("result").Item("retcode").Value.ToString() + "], " + respJson.Item("result").Item("error").Value.ToString()
        End If
        Return sResult
    End Function

    Public Function generarCadenaOriginal(ByVal oCFD As CFD, ByVal dtConcepto As DataTable, ByVal dtImpuesto As DataTable) As String

        Dim i As Integer

        'Recupera encabezado de factura para NodoEncabezado.
        Dim sNodoConcepto As String = ""
        Dim foundRows() As DataRow

        If oCFD.tipoDeComprobante = "ingreso" Then
            foundRows = dtConcepto.Select("FACClave = '" & oCFD.DOCClave & "'")
        Else
            foundRows = dtConcepto.Select("NCClave = '" & oCFD.DOCClave & "'")
        End If

        If foundRows.GetLength(0) > 0 Then


            Dim dSubtotal As Double = 0


            For i = 0 To foundRows.GetUpperBound(0)
                sNodoConcepto = sNodoConcepto & QuitarCeros(foundRows(i)("Cantidad")) & "|" & spaceFormat(foundRows(i)("Unidad")) & "|" & spaceFormat(foundRows(i)("Clave")) & "|" & spaceFormat(CStr(foundRows(i)("Descripción")).Trim) & "|" & QuitarCeros(foundRows(i)("P.U.") / oCFD.TipoCambio) & "|" & QuitarCeros((foundRows(i)("SubTotalPartida") / oCFD.TipoCambio)) & "|"
                dSubtotal += (foundRows(i)("SubTotalPartida") / oCFD.TipoCambio)
                '  dTotal += (foundRows(i)("TotalPartida") / oCFD.TipoCambio)
            Next
            oCFD.subtotal = QuitarCeros(dSubtotal)
        End If


        Dim sNodoImpuestosTrasladado As String = ""


        If oCFD.tipoDeComprobante = "ingreso" Then
            foundRows = dtImpuesto.Select("FACClave = '" & oCFD.DOCClave & "'")
        Else
            foundRows = dtImpuesto.Select("NCClave = '" & oCFD.DOCClave & "'")
        End If

        oCFD.impuestos = 0

        If foundRows.GetLength(0) > 0 Then

            For i = 0 To foundRows.GetUpperBound(0)
                sNodoImpuestosTrasladado = sNodoImpuestosTrasladado & foundRows(i)("Impuesto")
                sNodoImpuestosTrasladado = sNodoImpuestosTrasladado & "|" & CStr(foundRows(i)("Tasa"))
                sNodoImpuestosTrasladado = sNodoImpuestosTrasladado & "|" & QuitarCeros(foundRows(i)("Importe") / oCFD.TipoCambio) & "|"
                oCFD.impuestos += foundRows(i)("Importe") / oCFD.TipoCambio
            Next
        End If

       
        sNodoImpuestosTrasladado = sNodoImpuestosTrasladado & QuitarCeros(oCFD.impuestos) & "||"

        Dim sNodoEncabezado As String = "||" & oCFD.VersionCF & "|" & IIf(oCFD.TipoCF = 2, "", IIf(oCFD.Serie = "", "", oCFD.Serie & "|") & oCFD.Folio & "|") & oCFD.Fecha & "|" & IIf(oCFD.TipoCF = 2, "", oCFD.noAprobacion & "|" & oCFD.anoAprobacion & "|") & oCFD.tipoDeComprobante & "|" & oCFD.formaDePago & "|" & oCFD.subtotal & "|" & QuitarCeros(oCFD.descuento) & "|" & QuitarCeros(oCFD.total) & "|"

        Dim sNodoRegimenFiscal As String = ""

        If oCFD.VersionCF = "2.2" OrElse oCFD.VersionCF = "3.2" Then

            sNodoEncabezado &= spaceFormat(oCFD.metodoDePago) & "|" & spaceFormat(oCFD.LugarExpedicion) & "|" & IIf(oCFD.NumCtaPago <> "", spaceFormat(oCFD.NumCtaPago) & "|", "") & QuitarCeros(oCFD.TipoCambio) & "|" & oCFD.Moneda & "|"

            sNodoRegimenFiscal = oCFD.regimenFiscal & "|"

        End If

        Dim sNodoEmisor As String = spaceFormat(oCFD.eRFC) & "|" & spaceFormat(oCFD.eRazonSocial) & "|" & spaceFormat(oCFD.eCalle) & "|" & oCFD.enoExterior & IIf(oCFD.benoInterior, "|" & oCFD.enoInterior, "") & "|" & spaceFormat(oCFD.eColonia) & "|" & IIf(oCFD.eLocalidad = "", "SIN LOCALIDAD", spaceFormat(oCFD.eLocalidad)) & "|" & spaceFormat(oCFD.eReferencia) & "|" & oCFD.eMnpio & "|" & oCFD.eEntidad & "|" & oCFD.ePais & "|" & oCFD.eCodigoPostal & "|"
        Dim sNodoExpedicion As String = spaceFormat(oCFD.sCalle) & "|" & oCFD.snoExterior & IIf(oCFD.bsnoInterior, "|" & oCFD.snoInterior, "") & "|" & spaceFormat(oCFD.sColonia) & "|" & IIf(oCFD.sLocalidad = "", "SIN LOCALIDAD", spaceFormat(oCFD.sLocalidad)) & "|" & spaceFormat(oCFD.sReferencia) & "|" & oCFD.sMnpio & "|" & oCFD.sEntidad & "|" & oCFD.sPais & "|" & oCFD.sCodigoPostal & "|"
        Dim sNodoReceptor As String = spaceFormat(oCFD.RFC) & "|" & spaceFormat(oCFD.RazonSocial) & "|" & spaceFormat(oCFD.Calle) & "|" & oCFD.noExterior & IIf(oCFD.brnoInterior, "|" & oCFD.noInterior, "") & "|" & oCFD.Colonia & "|" & IIf(oCFD.Localidad = "", "SIN LOCALIDAD", spaceFormat(oCFD.Localidad)) & "|" & IIf(oCFD.Referencia = "", "SIN REFERENCIA", spaceFormat(oCFD.Referencia)) & "|" & oCFD.Mnpio & "|" & oCFD.Entidad & "|" & oCFD.Pais & "|" & oCFD.codigoPostal & "|"

        If oCFD.iTipoSucursal = 1 Then
            sNodoExpedicion = ""
        End If

        Dim sCadenaOriginal As String = sNodoEncabezado & sNodoEmisor & sNodoExpedicion & sNodoRegimenFiscal & sNodoReceptor & sNodoConcepto & sNodoImpuestosTrasladado


        Return sCadenaOriginal

    End Function

    Public Function generarCadenaOriginalTraslado(ByVal oCFD As CFD, ByVal dtConcepto As DataTable) As String

        Dim i As Integer

        'Recupera encabezado de factura para NodoEncabezado.
        Dim sNodoEncabezado As String = ""
        Dim sNodoEmisor As String = ""
        Dim sNodoReceptor As String = ""
        Dim sNodoConcepto As String = ""


        sNodoEncabezado = "||" & oCFD.VersionCF & "|" & oCFD.Folio & "|" & oCFD.Fecha & "|" & oCFD.noCertificado & "|0.00|" & oCFD.Moneda & "|0.00|T|" & spaceFormat(oCFD.sCodigoPostal)

        sNodoEmisor = "|" & spaceFormat(oCFD.eRFC) & "|" & spaceFormat(oCFD.eRazonSocial) & "|" & spaceFormat(oCFD.regimenFiscal) & "|"

        sNodoReceptor = oCFD.RFC & "|P01|"



        Dim foundRows() As DataRow
        Dim dTotal As Double = 0

        foundRows = dtConcepto.Select("TRSClave = '" & oCFD.DOCClave & "'")

        If foundRows.GetLength(0) > 0 Then

            Dim ClaveProdServ, ClaveUnidad As String

            For i = 0 To foundRows.GetUpperBound(0)


                If foundRows(i)("ClaveProdServ").GetType.Name = "DBNull" OrElse foundRows(i)("ClaveProdServ") = "" Then
                    ClaveProdServ = "01010101"
                Else
                    ClaveProdServ = foundRows(i)("ClaveProdServ")
                End If

                If foundRows(i)("ClaveUnidad").GetType.Name = "DBNull" OrElse foundRows(i)("ClaveUnidad") = "" Then
                    ClaveUnidad = "H87"
                Else
                    ClaveUnidad = foundRows(i)("ClaveUnidad")
                End If

                sNodoConcepto &= ClaveProdServ & "|" & spaceFormat(foundRows(i)("Clave")) & "|" & QuitarCeros(foundRows(i)("Cantidad")) & "|" & ClaveUnidad & "|" & spaceFormat(foundRows(i)("Unidad")) & "|" & spaceFormat(CStr(foundRows(i)("Descripción")).Trim) & "|0.00|0.00|"

                If foundRows(i)("Pedimento") <> "" Then
                    sNodoConcepto &= spaceFormat(foundRows(i)("Pedimento")) & "|"
                End If
            Next
        End If


        Dim sCadenaOriginal As String = sNodoEncabezado & sNodoEmisor & sNodoReceptor & sNodoConcepto & "|"


        Return sCadenaOriginal

    End Function

    Public Function generarCadenaOriginalGlobal(ByVal oCFD As CFD, ByVal dtConcepto As DataTable, ByVal dtImpuesto As DataTable, ByVal dtImpuestoDet As DataTable) As String

        Dim i As Integer

        'Recupera encabezado de factura para NodoEncabezado.
        Dim sNodoEncabezado As String = ""
        Dim sNodoExpedicion As String = ""
        Dim sNodoEmisor As String = ""
        Dim sNodoRegimenFiscal As String = ""
        Dim sNodoReceptor As String = ""
        Dim sNodoConcepto As String = ""
        Dim sNodoImpuestosTrasladado As String = ""
        Dim sNodoConceptoImpuestos As String = ""


        Dim foundRows() As DataRow
     
        oCFD.subtotal = dtConcepto.Compute("Sum(Subtotal)", "")
        oCFD.descuento = dtConcepto.Compute("Sum(Descuento)", "")
        oCFD.total = dtConcepto.Compute("Sum(total)", "")
        oCFD.impuestos = dtConcepto.Compute("Sum(Impuesto)", "")

        foundRows = dtConcepto.Select("FACClave = '" & oCFD.DOCClave & "'")
        If foundRows.GetLength(0) > 0 Then



            Dim foundDet() As DataRow
            Dim z As Integer

            For i = 0 To foundRows.GetUpperBound(0)
                foundDet = dtImpuestoDet.Select("DETClave = '" & foundRows(i)("DETClave") & "'")


                sNodoConcepto &= "01010101|" & spaceFormat(foundRows(i)("Folio")) & "|1|ACT|Venta|" & QuitarCeros(TruncateToDecimal(foundRows(i)("Subtotal") / oCFD.TipoCambio, 2), 2) & "|" & QuitarCeros(TruncateToDecimal((foundRows(i)("Subtotal") / oCFD.TipoCambio), 2), 2) & "|" & IIf(foundRows(i)("Descuento") > 0, QuitarCeros(TruncateToDecimal(foundRows(i)("Descuento") / oCFD.TipoCambio, 2), 2) & "|", "")
                sNodoConceptoImpuestos = ""
                For z = 0 To foundDet.GetUpperBound(0)
                    sNodoConceptoImpuestos &= QuitarCeros(TruncateToDecimal(foundDet(z)("Base") / oCFD.TipoCambio, 2), 2) & "|"
                    sNodoConceptoImpuestos &= spaceFormat(foundDet(z)("ClaveSAT")) & "|"
                    sNodoConceptoImpuestos &= foundDet(z)("TipoFactor") & "|"
                    sNodoConceptoImpuestos &= QuitarCeros(foundDet(z)("Tasa"), 6) & "|"
                    sNodoConceptoImpuestos &= QuitarCeros(TruncateToDecimal(foundDet(z)("Importe") / oCFD.TipoCambio, 2), 2) & "|"
                Next
                sNodoConcepto &= sNodoConceptoImpuestos
               
            Next
        End If

        foundRows = dtImpuesto.Select("FACClave = '" & oCFD.DOCClave & "'")
       
        If foundRows.GetLength(0) > 0 Then

            For i = 0 To foundRows.GetUpperBound(0)
                sNodoImpuestosTrasladado &= foundRows(i)("ClaveSAT")
                sNodoImpuestosTrasladado &= "|" & foundRows(i)("TipoFactor")
                sNodoImpuestosTrasladado &= "|" & QuitarCeros(foundRows(i)("Tasa"), 6)
                sNodoImpuestosTrasladado &= "|" & QuitarCeros(TruncateToDecimal(foundRows(i)("Importe") / oCFD.TipoCambio, 2), 2) & "|"
            Next
        End If

        sNodoImpuestosTrasladado &= QuitarCeros(TruncateToDecimal(oCFD.impuestos / oCFD.TipoCambio, 2), 2) & "||"
        sNodoEncabezado = "||" & oCFD.VersionCF & IIf(oCFD.Serie <> "", "|" & spaceFormat(oCFD.Serie), "") & "|" & oCFD.Folio & "|" & oCFD.Fecha & "|" & oCFD.metodoDePago & "|" & oCFD.noCertificado & "|" & QuitarCeros(TruncateToDecimal(oCFD.subtotal / oCFD.TipoCambio, 2), 2) & "|" & IIf(oCFD.descuento > 0, QuitarCeros(TruncateToDecimal(oCFD.descuento / oCFD.TipoCambio, 2), 2) & "|", "") & oCFD.Moneda & "|" & IIf(oCFD.TipoCambio <> 1, QuitarCeros(oCFD.TipoCambio, 6) & "|", "") & QuitarCeros(TruncateToDecimal(oCFD.total / oCFD.TipoCambio, 2), 2) & "|I|PUE|" & spaceFormat(oCFD.sCodigoPostal)
        sNodoEncabezado &= "|"
        sNodoEmisor = spaceFormat(oCFD.eRFC) & "|" & spaceFormat(oCFD.eRazonSocial) & "|" & spaceFormat(oCFD.regimenFiscal) & "|"
        sNodoReceptor = "XAXX010101000|P01|"
        Dim sCadenaOriginal As String = sNodoEncabezado & sNodoEmisor & sNodoExpedicion & sNodoRegimenFiscal & sNodoReceptor & sNodoConcepto & sNodoImpuestosTrasladado


        Return sCadenaOriginal

    End Function




    Public Function generarCadenaOriginalPago(ByVal oCFD As CFD, ByVal iTipo As Integer, ByVal TipoComprobante As String) As String

        Dim i As Integer

        'Recupera encabezado de factura para NodoEncabezado.
        Dim sNodoEncabezado As String = ""
        Dim sNodoEmisor As String = ""
        Dim sNodoReceptor As String = ""
        Dim sNodoConcepto As String = ""
        Dim sNodoConceptoImpuestos As String = ""
        Dim sNodoPago As String = ""
        Dim sCFDI As String = ""


        If iTipo = 2 Then
            'Anticipo

            Dim Base As Decimal = Math.Round(oCFD.total / 1.16, 2)
            Dim IVA As Decimal = Math.Round(Base * 0.16, 2)

            sNodoEncabezado = "||" & oCFD.VersionCF & "|" & oCFD.Folio & "|" & oCFD.Fecha & "|" & IIf(TipoComprobante = "I", spaceFormat(oCFD.metodoDePago), "30") & "|" & oCFD.noCertificado & "|" & QuitarCeros(TruncateToDecimal(Base / oCFD.TipoCambio, 2), 2) & "|" & oCFD.Moneda & IIf(oCFD.TipoCambio <> 1, "|" & QuitarCeros(TruncateToDecimal(oCFD.TipoCambio, 2), 6), "") & "|" & QuitarCeros(TruncateToDecimal((Base + IVA) / oCFD.TipoCambio, 2), 2) & "|" & TipoComprobante & "|PUE|" & spaceFormat(oCFD.sCodigoPostal)

            If TipoComprobante = "E" Then
                sNodoEncabezado &= "|07|" & oCFD.UUID_Sustituido
            End If

            sNodoEmisor = "|" & spaceFormat(oCFD.eRFC) & "|" & spaceFormat(oCFD.eRazonSocial) & "|" & spaceFormat(oCFD.regimenFiscal) & "|"

            If oCFD.Nacionalidad = "MEX" Then
                sNodoReceptor = spaceFormat(oCFD.RFC) & "|" & spaceFormat(oCFD.RazonSocial) & "|P01|"
            Else
                sNodoReceptor = "XEXX010101000|" & spaceFormat(oCFD.RazonSocial) & "|" & spaceFormat(oCFD.Nacionalidad) & "|" & spaceFormat(oCFD.NumRegIdTrib) & "|P01|"
            End If


            sNodoConcepto = "84111506|1|ACT|" & IIf(TipoComprobante = "I", "Anticipo del bien o servicio", "Aplicación de anticipo") & "|" & QuitarCeros(TruncateToDecimal(Base / oCFD.TipoCambio, 2), 2) & "|" & QuitarCeros(TruncateToDecimal(Base / oCFD.TipoCambio, 2), 2) & "|"
            sNodoConceptoImpuestos &= QuitarCeros(TruncateToDecimal(Base / oCFD.TipoCambio, 2), 2) & "|"
            sNodoConceptoImpuestos &= "002|"
            sNodoConceptoImpuestos &= "Tasa|"
            sNodoConceptoImpuestos &= "0.160000|"
            sNodoConceptoImpuestos &= QuitarCeros(TruncateToDecimal(IVA / oCFD.TipoCambio, 2), 2) & "|"

            sNodoConceptoImpuestos &= "002|"
            sNodoConceptoImpuestos &= "Tasa|"
            sNodoConceptoImpuestos &= "0.160000|"
            sNodoConceptoImpuestos &= QuitarCeros(TruncateToDecimal(IVA / oCFD.TipoCambio, 2), 2) & "|"
            sNodoConceptoImpuestos &= QuitarCeros(TruncateToDecimal(IVA / oCFD.TipoCambio, 2), 2) & "|"

            sNodoConcepto &= sNodoConceptoImpuestos
        Else
            'Pago

            sNodoEncabezado = "||" & oCFD.VersionCF & "|" & oCFD.Folio & "|" & oCFD.Fecha & "|" & oCFD.noCertificado & "|0|XXX|0|P|" & spaceFormat(oCFD.sCodigoPostal)

            sNodoEmisor = "|" & spaceFormat(oCFD.eRFC) & "|" & spaceFormat(oCFD.eRazonSocial) & "|" & spaceFormat(oCFD.regimenFiscal) & "|"

            If oCFD.Nacionalidad = "MEX" Then
                sNodoReceptor = spaceFormat(oCFD.RFC) & "|" & spaceFormat(oCFD.RazonSocial) & "|P01|"
            Else
                sNodoReceptor = "XEXX010101000|" & spaceFormat(oCFD.RazonSocial) & "|" & spaceFormat(oCFD.Nacionalidad) & "|" & spaceFormat(oCFD.NumRegIdTrib) & "|P01|"
            End If

            sNodoConcepto = "84111506|1|ACT|Pago|0|0|"

            sNodoPago = "1.0|" & oCFD.Fecha & "|" & oCFD.metodoDePago & "|" & oCFD.Moneda & "|" & IIf(oCFD.TipoCambio <> 1, QuitarCeros(oCFD.TipoCambio, 2) & "|", "") & QuitarCeros(TruncateToDecimal(oCFD.total / oCFD.TipoCambio, 2), 2) & "|"


            Dim dt As DataTable = ModPOS.Recupera_Tabla("st_recupera_relacionado", "@DOCClave", oCFD.DOCClave, "@Tipo", "P")
            For i = 0 To dt.Rows.Count - 1
                sCFDI &= dt.Rows(i)("UUID") & "|" & IIf(dt.Rows(i)("Serie") <> "", dt.Rows(i)("Serie") & "|", "") & CStr(dt.Rows(i)("Folio")) & "|" & dt.Rows(i)("MonedaDR") & "|"


                If dt.Rows(i)("TipoCambioDR") <> oCFD.TipoCambio Then
                    If dt.Rows(i)("MonedaDR") = "MXN" Then
                        sCFDI &= "1|"
                    Else
                        sCFDI &= QuitarCeros(dt.Rows(i)("TipoCambioDR"), 2) & "|"
                    End If
                End If

                Dim MetodoPagoDR As String
                If dt.Rows(i)("MetodoPagoDR") = "PUE" OrElse dt.Rows(i)("MetodoPagoDR") = "PPD" Then
                    MetodoPagoDR = dt.Rows(i)("MetodoPagoDR")
                Else
                    MetodoPagoDR = "PUE"
                End If

                sCFDI &= MetodoPagoDR & "|"
                If MetodoPagoDR = "PPD" Then
                    sCFDI &= dt.Rows(i)("NumParcialidad") & "|" & QuitarCeros(TruncateToDecimal(dt.Rows(i)("ImpSaldoAnt") / dt.Rows(i)("TipoCambioDR"), 2), 2) & "|" & QuitarCeros(TruncateToDecimal(dt.Rows(i)("ImpPagado") / dt.Rows(i)("TipoCambioDR"), 2), 2) & "|" & QuitarCeros(TruncateToDecimal(dt.Rows(i)("ImpSaldoInsoluto") / dt.Rows(i)("TipoCambioDR"), 2), 2) & "|"
                Else
                    If dt.Rows.Count > 1 Then
                        sCFDI &= QuitarCeros(TruncateToDecimal(dt.Rows(i)("ImpPagado") / dt.Rows(i)("TipoCambioDR"), 2), 2) & "|"
                    End If
                End If
            Next



        End If


        Dim sCadenaOriginal As String = sNodoEncabezado & sNodoEmisor & sNodoReceptor & sNodoConcepto & sNodoPago & sCFDI & "|"


        Return sCadenaOriginal

    End Function


    Public Function generarCadenaOriginalCFDI(ByVal oCFD As CFD, ByVal dtConcepto As DataTable, ByVal dtImpuesto As DataTable, ByVal TipoComprobante As Integer, ByVal dtImpuestoDet As DataTable, Optional ByVal dtRetencionDet As DataTable = Nothing, Optional ByVal dtRetencion As DataTable = Nothing) As String

        Dim i As Integer
        Dim dtClaveCliente As DataTable

        'Recupera encabezado de factura para NodoEncabezado.
        Dim sNodoEncabezado As String = ""
        Dim sNodoExpedicion As String = ""
        Dim sNodoEmisor As String = ""
        Dim sNodoRegimenFiscal As String = ""
        Dim sNodoReceptor As String = ""
        Dim sNodoConcepto As String = ""
        Dim sNodoImpuestosRetenidos As String = ""
        Dim sNodoImpuestosTrasladado As String = ""
        Dim sNodoConceptoImpuestos As String = ""


        Dim foundRows() As DataRow


        Select Case TipoComprobante
            Case Is = 1 'Factura
                foundRows = dtConcepto.Select("FACClave = '" & oCFD.DOCClave & "'")
            Case Is = 6 ' Nota de Cargo
                foundRows = dtConcepto.Select("CARClave = '" & oCFD.DOCClave & "'")
            Case Is = 7 ' Nota de Credito
                foundRows = dtConcepto.Select("NCClave = '" & oCFD.DOCClave & "'")
            Case Else
                If oCFD.tipoDeComprobante = "ingreso" Then
                    foundRows = dtConcepto.Select("FACClave = '" & oCFD.DOCClave & "'")
                Else
                    foundRows = dtConcepto.Select("NCClave = '" & oCFD.DOCClave & "'")
                End If
        End Select

        Dim foundRet() As DataRow

        If foundRows.GetLength(0) > 0 Then

            Dim dSubtotal As Double = 0
            Dim ClaveProdServ, ClaveUnidad, noIdentificacion, Descripcion As String
            Dim foundDet() As DataRow
            Dim foundDetCliente() As DataRow

            Dim z As Integer

            If oCFD.tieneAddenda = True AndAlso TipoComprobante = 1 AndAlso (oCFD.Tipo = 2 OrElse oCFD.Tipo = 5) Then
                dtClaveCliente = ModPOS.Recupera_Tabla("st_recupera_clienteclave", "@DOCClave", oCFD.DOCClave, "@Tipo", TipoComprobante)
            End If


            For i = 0 To foundRows.GetUpperBound(0)
                If oCFD.VersionCF = "3.3" Then

                    If oCFD.tieneAddenda = True AndAlso TipoComprobante = 1 AndAlso (oCFD.Tipo = 2 OrElse oCFD.Tipo = 5) Then
                        If Not dtClaveCliente Is Nothing AndAlso dtClaveCliente.Rows.Count > 0 Then
                            foundDetCliente = dtClaveCliente.Select("DETClave = '" & foundRows(i)("DETClave") & "'")
                        End If
                    End If

                    foundDet = dtImpuestoDet.Select("DETClave = '" & foundRows(i)("DETClave") & "'")
                    If Not dtRetencionDet Is Nothing Then
                        foundRet = dtRetencionDet.Select("DETClave = '" & foundRows(i)("DETClave") & "'")
                    End If

                    If foundRows(i)("ClaveProdServ").GetType.Name = "DBNull" OrElse foundRows(i)("ClaveProdServ") = "" Then
                        ClaveProdServ = "01010101"
                    Else
                        ClaveProdServ = foundRows(i)("ClaveProdServ")
                    End If

                    If foundRows(i)("ClaveUnidad").GetType.Name = "DBNull" OrElse foundRows(i)("ClaveUnidad") = "" Then
                        ClaveUnidad = "H87"
                    Else
                        ClaveUnidad = foundRows(i)("ClaveUnidad")
                    End If

                    If oCFD.tieneAddenda = True AndAlso TipoComprobante = 1 AndAlso oCFD.Tipo = 2 Then
                        noIdentificacion = spaceFormat(foundDetCliente(0)("Clave"))
                    Else
                        noIdentificacion = spaceFormat(foundRows(i)("Clave"))
                    End If


                    If oCFD.tieneAddenda = True AndAlso TipoComprobante = 1 AndAlso (oCFD.Tipo = 2 OrElse oCFD.Tipo = 5) Then
                        If oCFD.Tipo = 2 Then
                            Descripcion = spaceFormat(foundDetCliente(0)("Clave")) & " " & spaceFormat(CStr(foundRows(i)("Descripción")).Trim)
                        ElseIf oCFD.Tipo = 5 Then
                            Descripcion = "(" & spaceFormat(foundRows(i)("Clave")) & ") " & spaceFormat(foundDetCliente(0)("Clave")) & " " & spaceFormat(CStr(foundRows(i)("Descripción")).Trim)
                        End If
                    Else
                        Descripcion = spaceFormat(CStr(foundRows(i)("Descripción")).Trim)
                    End If

                    sNodoConcepto &= ClaveProdServ & "|" & noIdentificacion & "|" & QuitarCeros(foundRows(i)("Cantidad")) & "|" & ClaveUnidad & "|" & spaceFormat(foundRows(i)("Unidad")) & "|" & Descripcion & "|" & QuitarCeros(TruncateToDecimal(foundRows(i)("P.U.") / oCFD.TipoCambio, 2), 2) & "|" & QuitarCeros(TruncateToDecimal((foundRows(i)("SubTotalPartida") / oCFD.TipoCambio), 2), 2) & "|" & IIf(foundRows(i)("Descuento") > 0, QuitarCeros(TruncateToDecimal(foundRows(i)("Descuento") / oCFD.TipoCambio, 2), 2) & "|", "")
                    sNodoConceptoImpuestos = ""
                    For z = 0 To foundDet.GetUpperBound(0)
                        sNodoConceptoImpuestos &= QuitarCeros(TruncateToDecimal(foundDet(z)("Base") / oCFD.TipoCambio, 2), 2) & "|"
                        sNodoConceptoImpuestos &= spaceFormat(foundDet(z)("ClaveSAT")) & "|"
                        sNodoConceptoImpuestos &= foundDet(z)("TipoFactor") & "|"
                        sNodoConceptoImpuestos &= QuitarCeros(foundDet(z)("Tasa"), 6) & "|"
                        sNodoConceptoImpuestos &= QuitarCeros(TruncateToDecimal(foundDet(z)("Importe") / oCFD.TipoCambio, 2), 2) & "|"
                    Next

                    If Not dtRetencionDet Is Nothing Then
                        If foundRet.Length > 0 Then
                            For z = 0 To foundRet.GetUpperBound(0)
                                sNodoConceptoImpuestos &= QuitarCeros(TruncateToDecimal(foundRet(z)("Base") / oCFD.TipoCambio, 2), 2) & "|"
                                sNodoConceptoImpuestos &= spaceFormat(foundRet(z)("ClaveSAT")) & "|"
                                sNodoConceptoImpuestos &= foundRet(z)("TipoFactor") & "|"
                                sNodoConceptoImpuestos &= QuitarCeros(foundRet(z)("Tasa"), 6) & "|"
                                sNodoConceptoImpuestos &= QuitarCeros(TruncateToDecimal(foundRet(z)("Importe") / oCFD.TipoCambio, 2), 2) & "|"
                            Next
                        End If
                    End If

                    sNodoConcepto &= sNodoConceptoImpuestos

                    If foundRows(i)("Pedimento") <> "" Then
                        sNodoConcepto &= spaceFormat(foundRows(i)("Pedimento")) & "|"
                    End If

                Else
                    If foundRows(i)("Clave") = "NotaCargo" Then
                        sNodoConcepto &= QuitarCeros(foundRows(i)("Cantidad")) & "|" & spaceFormat(foundRows(i)("Unidad")) & "|" & spaceFormat(CStr(foundRows(i)("Descripción")).Trim) & "|" & QuitarCeros(foundRows(i)("P.U.") / oCFD.TipoCambio) & "|" & QuitarCeros((foundRows(i)("SubTotalPartida") / oCFD.TipoCambio)) & "|"
                    Else
                        sNodoConcepto &= QuitarCeros(foundRows(i)("Cantidad")) & "|" & spaceFormat(foundRows(i)("Unidad")) & "|" & spaceFormat(foundRows(i)("Clave")) & "|" & spaceFormat(CStr(foundRows(i)("Descripción")).Trim) & "|" & QuitarCeros(foundRows(i)("P.U.") / oCFD.TipoCambio) & "|" & QuitarCeros((foundRows(i)("SubTotalPartida") / oCFD.TipoCambio)) & "|"
                    End If
                End If
                dSubtotal += (foundRows(i)("SubTotalPartida") / oCFD.TipoCambio)
                '  dTotal += (foundRows(i)("TotalPartida") / oCFD.TipoCambio)
            Next
            oCFD.subtotal = QuitarCeros(dSubtotal)
        End If


        Select Case TipoComprobante
            Case Is = 1 'Factura
                foundRows = dtImpuesto.Select("FACClave = '" & oCFD.DOCClave & "'")
                oCFD.impuestos = dtImpuesto.Compute("SUM(Importe)", "FACClave = '" & oCFD.DOCClave & "'")
            Case Is = 6 ' Nota de Cargo
                foundRows = dtImpuesto.Select("CARClave = '" & oCFD.DOCClave & "'")
                oCFD.impuestos = dtImpuesto.Compute("SUM(Importe)", "CARClave = '" & oCFD.DOCClave & "'")
            Case Is = 7 ' Nota de Credito
                foundRows = dtImpuesto.Select("NCClave = '" & oCFD.DOCClave & "'")
                oCFD.impuestos = dtImpuesto.Compute("SUM(Importe)", "NCClave = '" & oCFD.DOCClave & "'")
            Case Else
                If oCFD.tipoDeComprobante = "ingreso" Then
                    foundRows = dtImpuesto.Select("FACClave = '" & oCFD.DOCClave & "'")
                    oCFD.impuestos = dtImpuesto.Compute("SUM(Importe)", "FACClave = '" & oCFD.DOCClave & "'")
                Else
                    foundRows = dtImpuesto.Select("NCClave = '" & oCFD.DOCClave & "'")
                    oCFD.impuestos = dtImpuesto.Compute("SUM(Importe)", "NCClave = '" & oCFD.DOCClave & "'")
                End If
        End Select

        oCFD.Retenciones = 0

        If Not dtRetencion Is Nothing Then
            If dtRetencion.Rows.Count > 0 Then
                Select Case TipoComprobante
                    Case Is = 1
                        foundRet = dtRetencion.Select("FACClave = '" & oCFD.DOCClave & "'")
                        oCFD.Retenciones = dtRetencion.Compute("SUM(Importe)", "FACClave = '" & oCFD.DOCClave & "'")
                    Case Is = 6
                        foundRet = dtRetencion.Select("CARClave = '" & oCFD.DOCClave & "'")
                        oCFD.Retenciones = dtRetencion.Compute("SUM(Importe)", "CARClave = '" & oCFD.DOCClave & "'")
                    Case Is = 7
                        foundRet = dtRetencion.Select("NCClave = '" & oCFD.DOCClave & "'")
                        oCFD.Retenciones = dtRetencion.Compute("SUM(Importe)", "NCClave = '" & oCFD.DOCClave & "'")
                    Case Else
                        If oCFD.tipoDeComprobante = "ingreso" Then
                            foundRet = dtRetencion.Select("FACClave = '" & oCFD.DOCClave & "'")
                            oCFD.Retenciones = dtRetencion.Compute("SUM(Importe)", "FACClave = '" & oCFD.DOCClave & "'")
                        Else
                            foundRet = dtRetencion.Select("NCClave = '" & oCFD.DOCClave & "'")
                            oCFD.Retenciones = dtRetencion.Compute("SUM(Importe)", "NCClave = '" & oCFD.DOCClave & "'")
                        End If
                End Select
            End If
        End If

        If oCFD.Retenciones > 0 Then
            For i = 0 To foundRet.GetUpperBound(0)
                If oCFD.VersionCF = "3.3" Then
                    sNodoImpuestosRetenidos &= foundRet(i)("ClaveSAT")
                    sNodoImpuestosRetenidos &= "|" & QuitarCeros(TruncateToDecimal(foundRet(i)("Importe") / oCFD.TipoCambio, 2), 2) & "|"
                End If
            Next
            sNodoImpuestosRetenidos &= QuitarCeros(TruncateToDecimal(oCFD.Retenciones / oCFD.TipoCambio, 2), 2) & "|"
        End If

        If foundRows.GetLength(0) > 0 Then

            For i = 0 To foundRows.GetUpperBound(0)
                If oCFD.VersionCF = "3.3" Then
                    sNodoImpuestosTrasladado &= foundRows(i)("ClaveSAT")
                    sNodoImpuestosTrasladado &= "|" & foundRows(i)("TipoFactor")
                    sNodoImpuestosTrasladado &= "|" & CStr(QuitarCeros(IIf(foundRows(i)("TipoFactor") = "Tasa", foundRows(i)("Tasa") / 100, foundRows(i)("Tasa")), 6))
                    sNodoImpuestosTrasladado &= "|" & QuitarCeros(TruncateToDecimal(foundRows(i)("Importe") / oCFD.TipoCambio, 2), 2) & "|"
                Else
                    sNodoImpuestosTrasladado &= foundRows(i)("Impuesto")
                    sNodoImpuestosTrasladado &= "|" & CStr(QuitarCeros(foundRows(i)("Tasa")))
                    sNodoImpuestosTrasladado &= "|" & QuitarCeros(foundRows(i)("Importe") / oCFD.TipoCambio) & "|"

                End If

            Next
        End If


        If oCFD.total = 0 Then
            oCFD.total = (oCFD.subtotal - oCFD.descuento + oCFD.impuestos - oCFD.Retenciones)
        End If

        If oCFD.VersionCF = "3.3" Then
            sNodoImpuestosTrasladado &= QuitarCeros(TruncateToDecimal(oCFD.impuestos / oCFD.TipoCambio, 2), 2) & "||"
            sNodoEncabezado = "||" & oCFD.VersionCF & IIf(oCFD.Serie <> "", "|" & spaceFormat(oCFD.Serie), "") & "|" & oCFD.Folio & "|" & oCFD.Fecha & "|" & oCFD.metodoDePago & "|" & oCFD.noCertificado & "|" & IIf(oCFD.CondicionesDePago <> "", oCFD.CondicionesDePago & "|", "") & QuitarCeros(TruncateToDecimal(oCFD.subtotal / oCFD.TipoCambio, 2), 2) & "|" & IIf(oCFD.descuento > 0, CStr(QuitarCeros(TruncateToDecimal(oCFD.descuento / oCFD.TipoCambio, 2), 2)) & "|", "") & oCFD.Moneda & "|" & IIf(oCFD.TipoCambio <> 1, QuitarCeros(oCFD.TipoCambio, 6) & "|", "") & QuitarCeros(TruncateToDecimal(oCFD.total / oCFD.TipoCambio, 2), 2) & "|" & oCFD.tipoDeComprobante & "|" & spaceFormat(oCFD.formaDePago) & "|" & spaceFormat(oCFD.sCodigoPostal)

            Dim tipoRelacion As String
            If oCFD.UUID_Sustituido <> "" Then
                tipoRelacion = "04"
                sNodoEncabezado &= "|" & tipoRelacion & "|" & oCFD.UUID_Sustituido
            Else
                If oCFD.tipoDeComprobante = "E" Then
                    Dim dt As DataTable = ModPOS.Recupera_Tabla("st_recupera_relacionado", "@DOCClave", oCFD.DOCClave, "@Tipo", "E")
                    If dt.Rows.Count >= 1 Then
                        Dim k As Integer
                        If oCFD.tipoNC = 1 Then
                            tipoRelacion = "03"
                        Else
                            tipoRelacion = "01"
                        End If
                        sNodoEncabezado &= "|" & tipoRelacion
                        For k = 0 To dt.Rows.Count - 1
                            sNodoEncabezado &= "|" & CStr(dt.Rows(k)("UUID"))
                        Next
                    End If
                    dt.Dispose()
                ElseIf TipoComprobante = 6 Then
                    Dim dt As DataTable = ModPOS.Recupera_Tabla("st_recupera_relacionado", "@DOCClave", oCFD.DOCClave, "@Tipo", "I")
                    If dt.Rows.Count >= 1 Then
                        Dim k As Integer
                        tipoRelacion = ""
                        For k = 0 To dt.Rows.Count - 1
                            If tipoRelacion = "" Then
                                tipoRelacion = dt.Rows(k)("TipoRelacion")
                                sNodoEncabezado &= "|" & tipoRelacion
                           End If
                            sNodoEncabezado &= "|" & CStr(dt.Rows(k)("UUID"))
                        Next

                    End If
                    dt.Dispose()
                ElseIf TipoComprobante = 1 Then
                    Dim dt As DataTable = ModPOS.Recupera_Tabla("st_recupera_relacionado", "@DOCClave", oCFD.DOCClave, "@Tipo", "F")
                    If dt.Rows.Count >= 1 Then
                        Dim k As Integer
                        tipoRelacion = "07"
                        sNodoEncabezado &= "|" & tipoRelacion
                        For k = 0 To dt.Rows.Count - 1
                            sNodoEncabezado &= "|" & CStr(dt.Rows(k)("UUID"))
                        Next

                    End If
                    dt.Dispose()
                End If
            End If

            sNodoEncabezado &= "|"
            sNodoEmisor = spaceFormat(oCFD.eRFC) & "|" & spaceFormat(oCFD.eRazonSocial) & "|" & spaceFormat(oCFD.regimenFiscal) & "|"
            sNodoReceptor = spaceFormat(oCFD.RFC) & "|" & spaceFormat(oCFD.RazonSocial) & "|" & oCFD.UsoCFDI & "|"

        Else
            sNodoImpuestosTrasladado &= QuitarCeros(oCFD.impuestos) & "||"
            sNodoEncabezado = "||" & oCFD.VersionCF & "|" & oCFD.Fecha & "|" & oCFD.tipoDeComprobante & "|" & oCFD.formaDePago & "|" & QuitarCeros(oCFD.subtotal / oCFD.TipoCambio) & "|" & CStr(QuitarCeros(oCFD.descuento / oCFD.TipoCambio)) & "|" & IIf(oCFD.TipoCF = 2, QuitarCeros(oCFD.TipoCambio) & "|" & oCFD.Moneda & "|", "") & QuitarCeros(oCFD.total / oCFD.TipoCambio) & "|"

            If oCFD.VersionCF = "2.2" OrElse oCFD.VersionCF = "3.2" Then

                sNodoEncabezado &= spaceFormat(oCFD.metodoDePago) & "|" & spaceFormat(oCFD.LugarExpedicion) & "|" & IIf(oCFD.NumCtaPago <> "", spaceFormat(oCFD.NumCtaPago) & "|", "")

                sNodoRegimenFiscal = oCFD.regimenFiscal & "|"

            End If

            sNodoEmisor = spaceFormat(oCFD.eRFC) & "|" & spaceFormat(oCFD.eRazonSocial) & "|" & spaceFormat(oCFD.eCalle) & "|" & spaceFormat(oCFD.enoExterior) & IIf(oCFD.benoInterior, "|" & spaceFormat(oCFD.enoInterior), "") & "|" & spaceFormat(oCFD.eColonia) & "|" & IIf(oCFD.eLocalidad = "", "SIN LOCALIDAD", spaceFormat(oCFD.eLocalidad)) & "|" & spaceFormat(oCFD.eReferencia) & "|" & spaceFormat(oCFD.eMnpio) & "|" & spaceFormat(oCFD.eEntidad) & "|" & spaceFormat(oCFD.ePais) & "|" & spaceFormat(oCFD.eCodigoPostal) & "|"

            sNodoExpedicion = spaceFormat(oCFD.sCalle) & "|" & spaceFormat(oCFD.snoExterior) & IIf(oCFD.bsnoInterior, "|" & spaceFormat(oCFD.snoInterior), "") & "|" & spaceFormat(oCFD.sColonia) & "|" & IIf(oCFD.sLocalidad = "", "SIN LOCALIDAD", spaceFormat(oCFD.sLocalidad)) & "|" & spaceFormat(oCFD.sReferencia) & "|" & spaceFormat(oCFD.sMnpio) & "|" & spaceFormat(oCFD.sEntidad) & "|" & spaceFormat(oCFD.sPais) & "|" & spaceFormat(oCFD.sCodigoPostal) & "|"
            sNodoReceptor = spaceFormat(oCFD.RFC) & "|" & spaceFormat(oCFD.RazonSocial) & "|" & spaceFormat(oCFD.Calle) & "|" & spaceFormat(oCFD.noExterior) & IIf(oCFD.brnoInterior, "|" & spaceFormat(oCFD.noInterior), "") & "|" & spaceFormat(oCFD.Colonia) & "|" & IIf(oCFD.Localidad = "", "SIN LOCALIDAD", spaceFormat(oCFD.Localidad)) & "|" & IIf(oCFD.Referencia = "", "SIN REFERENCIA", spaceFormat(oCFD.Referencia)) & "|" & spaceFormat(oCFD.Mnpio) & "|" & spaceFormat(oCFD.Entidad) & "|" & spaceFormat(oCFD.Pais) & "|" & spaceFormat(oCFD.codigoPostal) & "|"

            If oCFD.iTipoSucursal = 1 Then
                sNodoExpedicion = ""
            End If

        End If

        Dim sCadenaOriginal As String = sNodoEncabezado & sNodoEmisor & sNodoExpedicion & sNodoRegimenFiscal & sNodoReceptor & sNodoConcepto & sNodoImpuestosRetenidos & sNodoImpuestosTrasladado

        Return sCadenaOriginal

    End Function

    Public Function generaCadenaOriginalComplemento(ByVal oCFD As eCFD, ByVal dtConcepto As DataTable, ByVal dtImpuesto As DataTable) As String
        'Complemento Nomina

        Dim sCadenaOriginal As String

        sCadenaOriginal = "1.1|"

        If oCFD.RegistroPatronal <> "" AndAlso (oCFD.TipoRegimen = "02" OrElse oCFD.TipoRegimen = "03" OrElse oCFD.TipoRegimen = "04") Then
            sCadenaOriginal &= oCFD.RegistroPatronal & "|"
        End If

        sCadenaOriginal &= oCFD.NumEmpleado & "|"
        sCadenaOriginal &= oCFD.CURP & "|"
        sCadenaOriginal &= CStr(oCFD.TipoRegimen) & "|"

        If oCFD.NumSeguridadSocial <> "" Then
            sCadenaOriginal &= oCFD.NumSeguridadSocial & "|"
        End If

        sCadenaOriginal &= String.Format("{0:yyyy-MM-dd}", oCFD.FechaPago) & "|"
        sCadenaOriginal &= String.Format("{0:yyyy-MM-dd}", oCFD.FechaInicialPago) & "|"
        sCadenaOriginal &= String.Format("{0:yyyy-MM-dd}", oCFD.FechaFinalPago) & "|"
        sCadenaOriginal &= CStr(oCFD.NumDiasPagados) & "|"

        If oCFD.Departamento <> "" Then
            sCadenaOriginal &= oCFD.Departamento & "|"
        End If

        If CInt(oCFD.metodoDePago) > 1 Then
                sCadenaOriginal &= oCFD.NumCtaPago & "|"
          
                Dim sTipoBanco As String = "00" & CStr(oCFD.Banco)
                sCadenaOriginal &= sTipoBanco.Substring(sTipoBanco.Length - 3, 3) & "|"
        End If
        'op
        sCadenaOriginal &= oCFD.FechaInicioRelLaboral & "|"

        If oCFD.Puesto <> "" Then
            sCadenaOriginal &= oCFD.Puesto & "|"
        End If

        If oCFD.TipoContrato <> "" Then
            sCadenaOriginal &= oCFD.TipoContrato & "|"
        End If

        If oCFD.TipoJornada <> "" Then
            sCadenaOriginal &= oCFD.TipoJornada & "|"
        End If

        sCadenaOriginal &= oCFD.PeriodicidadPago & "|"

        If oCFD.SalarioBaseCotApor > 0 Then
            sCadenaOriginal &= QuitarCeros(oCFD.SalarioBaseCotApor) & "|"
        End If

        If oCFD.RiesgoPuesto > 0 Then
            If oCFD.NumSeguridadSocial <> "" Then
                sCadenaOriginal &= CStr(oCFD.RiesgoPuesto) & "|"
            Else
                sCadenaOriginal &= "99|"
            End If
        End If

        If oCFD.SalarioDiarioIntegrado > 0 Then
            sCadenaOriginal &= QuitarCeros(oCFD.SalarioDiarioIntegrado) & "|"
        End If

        Dim dtConceptos As DataTable
        Dim foundRows() As DataRow
        Dim i As Integer
        Dim sTipoPercepcion, sTipoDeduccion As String

        dtConceptos = ModPOS.Recupera_Tabla("sp_recupera_recibodet", "@RENClave", oCFD.RENClave)

        foundRows = dtConceptos.Select("Tipo = 1")

        If foundRows.GetLength(0) > 0 Then


            ' Percepciones  

            sCadenaOriginal &= QuitarCeros(oCFD.TotalGravadoP) & "|"
            sCadenaOriginal &= QuitarCeros(oCFD.TotalExentoP) & "|"

            For i = 0 To foundRows.GetUpperBound(0)

                sTipoPercepcion = "00" & CStr(foundRows(i)("TipoConcepto"))
                sCadenaOriginal &= sTipoPercepcion.Substring(sTipoPercepcion.Length - 3, 3) & "|"

                sCadenaOriginal &= foundRows(i)("Clave") & "|"
                sCadenaOriginal &= foundRows(i)("Concepto") & "|"
                sCadenaOriginal &= QuitarCeros(foundRows(i)("ImporteGravado") / oCFD.TipoCambio) & "|"
                sCadenaOriginal &= QuitarCeros(foundRows(i)("ImporteExento") / oCFD.TipoCambio) & "|"

            Next
            'Cierre de Percepciones

        End If

        foundRows = dtConceptos.Select("Tipo = 2")


        If foundRows.GetLength(0) > 0 Then
            ' Deducciones  
                sCadenaOriginal &= QuitarCeros(oCFD.TotalDeducciones) & "|"
                sCadenaOriginal &= QuitarCeros(0) & "|"


                For i = 0 To foundRows.GetUpperBound(0)

                    sTipoDeduccion = "00" & CStr(foundRows(i)("TipoConcepto"))
                    sCadenaOriginal &= sTipoDeduccion.Substring(sTipoDeduccion.Length - 3, 3) & "|"
                    sCadenaOriginal &= foundRows(i)("Clave") & "|"
                    sCadenaOriginal &= foundRows(i)("Concepto") & "|"
                    sCadenaOriginal &= QuitarCeros(foundRows(i)("ImporteGravado") / oCFD.TipoCambio) & "|"
                    sCadenaOriginal &= QuitarCeros(foundRows(i)("ImporteExento") / oCFD.TipoCambio) & "|"

                Next

                'Cierre de Deducciones


            End If

            dtConceptos.Dispose()

            Dim dtIncapacidad As DataTable = ModPOS.Recupera_Tabla("sp_recupera_incapacidad", "@RENClave", oCFD.RENClave)
            ' Incapacidades


            If dtIncapacidad.Rows.Count() > 0 Then

                For i = 0 To dtIncapacidad.Rows.Count() - 1

                    sCadenaOriginal &= CStr(dtIncapacidad.Rows(i)("Dias")) & "|"
                    sCadenaOriginal &= CStr(dtIncapacidad.Rows(i)("TipoIncapacidad")) & "|"
                    sCadenaOriginal &= QuitarCeros(dtIncapacidad.Rows(i)("Descuento")) & "|"
                Next

            End If

            dtIncapacidad.Dispose()

            Dim dtHorasExtra As DataTable = ModPOS.Recupera_Tabla("sp_recupera_horasextra", "@RENClave", oCFD.RENClave)

            ' Horas Extra

            If dtHorasExtra.Rows.Count() > 0 Then
                For i = 0 To dtHorasExtra.Rows.Count() - 1
                    sCadenaOriginal &= CStr(dtHorasExtra.Rows(i)("Dias")) & "|"
                    sCadenaOriginal &= CStr(dtHorasExtra.Rows(i)("Tipo")) & "|"
                    sCadenaOriginal &= CStr(dtHorasExtra.Rows(i)("HorasExtra")) & "|"
                    sCadenaOriginal &= QuitarCeros(dtHorasExtra.Rows(i)("ImportePagado")) & "|"
                Next

            End If

            dtHorasExtra.Dispose()


            Return sCadenaOriginal & "|"

    End Function

    Public Function generarCadenaOriginalNomina(ByVal oCFD As eCFD, ByVal dtConcepto As DataTable, ByVal dtImpuesto As DataTable, ByVal VersionNomina As Integer) As String
        Dim sCadenaOriginal As String
        Dim numDec As Integer = 0
        Dim i As Integer

        'Recupera encabezado de factura para NodoEncabezado.
        Dim sNodoConcepto As String = ""
        Dim dTotal As Double = 0
        Dim foundRows() As DataRow


        If oCFD.VersionCF = "3.3" Then
            numDec = 2
        End If

        foundRows = dtConcepto.Select("RENClave = '" & oCFD.RENClave & "'")

        If foundRows.GetLength(0) > 0 Then
            If VersionNomina = 1 Then
                Dim dSubtotal As Double = 0
                For i = 0 To foundRows.GetUpperBound(0)
                    sNodoConcepto = sNodoConcepto & QuitarCeros(foundRows(i)("Cantidad"), numDec) & "|" & spaceFormat(foundRows(i)("Unidad")) & "|" & spaceFormat(foundRows(i)("Clave")) & "|" & spaceFormat(CStr(foundRows(i)("Descripción")).Trim) & "|" & QuitarCeros(foundRows(i)("P.U.") / oCFD.TipoCambio, numDec) & "|" & QuitarCeros(foundRows(i)("Cantidad") * (foundRows(i)("P.U.") / oCFD.TipoCambio), numDec) & "|"
                    dSubtotal += foundRows(i)("Cantidad") * (foundRows(i)("P.U.") / oCFD.TipoCambio)
                    dTotal += foundRows(i)("Cantidad") * (foundRows(i)("SubTotalPartida") / oCFD.TipoCambio)
                Next
                oCFD.subtotal = QuitarCeros(dSubtotal, numDec)
            ElseIf VersionNomina = 2 Then
                If oCFD.VersionCF = "3.3" Then
                    'sNodoConcepto = "84111505|1|ACT|Pago de nómina|" & QuitarCeros(TruncateToDecimal(oCFD.TotalSueldos + oCFD.TotalSeparacion + oCFD.TotalJubilacion + oCFD.TotalOtrosPagos, 2), numDec) & "|" & QuitarCeros(TruncateToDecimal(oCFD.TotalSueldos + oCFD.TotalSeparacion + oCFD.TotalJubilacion + oCFD.TotalOtrosPagos, 2), numDec) & "|" & QuitarCeros(TruncateToDecimal(oCFD.TotalDeducciones, 2), numDec) & "|"
                    sNodoConcepto = "84111505|1|ACT|Pago de nómina|" & QuitarCeros(TruncateToDecimal(oCFD.TotalSueldos + oCFD.TotalSeparacion + oCFD.TotalJubilacion + oCFD.TotalOtrosPagos, 2), numDec) & "|" & QuitarCeros(TruncateToDecimal(oCFD.TotalSueldos + oCFD.TotalSeparacion + oCFD.TotalJubilacion + oCFD.TotalOtrosPagos, 2), numDec) & "|" & IIf(oCFD.TotalDeducciones > 0, QuitarCeros(TruncateToDecimal(oCFD.TotalDeducciones, 2), numDec) & "|", "")

                Else
                    sNodoConcepto = "1|ACT|Pago de nómina|" & QuitarCeros(oCFD.TotalSueldos + oCFD.TotalSeparacion + oCFD.TotalJubilacion + oCFD.TotalOtrosPagos, numDec) & "|" & QuitarCeros(oCFD.TotalSueldos + oCFD.TotalSeparacion + oCFD.TotalJubilacion + oCFD.TotalOtrosPagos, numDec) & "|"
                End If
            End If
        End If


        Dim sNodoImpuestosRetenidos As String = ""


        foundRows = dtImpuesto.Select("RENClave = '" & oCFD.RENClave & "'")

        oCFD.impuestos = 0

        If foundRows.GetLength(0) > 0 Then

            For i = 0 To foundRows.GetUpperBound(0)
                sNodoImpuestosRetenidos = sNodoImpuestosRetenidos & foundRows(i)("Impuesto")
                sNodoImpuestosRetenidos = sNodoImpuestosRetenidos & "|" & QuitarCeros(foundRows(i)("Importe") / oCFD.TipoCambio, numDec) & "|"
                oCFD.impuestos += foundRows(i)("Importe") / oCFD.TipoCambio
            Next
        Else
            sNodoImpuestosRetenidos = sNodoImpuestosRetenidos & "ISR"
            sNodoImpuestosRetenidos = sNodoImpuestosRetenidos & "|" & "0" & "|"
        End If

        oCFD.total = dTotal

        sNodoImpuestosRetenidos = sNodoImpuestosRetenidos & QuitarCeros(oCFD.impuestos, numDec) & "|"

        Dim sNodoEncabezado As String = ""

        If VersionNomina = 1 Then
            sNodoEncabezado = "||" & oCFD.VersionCF & "|" & String.Format("{0:yyyy-MM-ddTHH:mm:ss}", oCFD.Fecha) & "|" & "egreso" & "|" & oCFD.formaDePago & "|" & oCFD.subtotal & "|" & CStr(QuitarCeros(oCFD.descuento)) & "|" & IIf(oCFD.TipoCF = 2, QuitarCeros(oCFD.TipoCambio) & "|" & oCFD.Moneda & "|", "") & QuitarCeros(oCFD.total, numDec) & "|"
        ElseIf VersionNomina = 2 Then
            If oCFD.VersionCF = "3.3" Then
                sNodoEncabezado = "||" & oCFD.VersionCF & "|" & IIf(oCFD.Serie <> "", oCFD.Serie & "|", "") & oCFD.Folio & "|" & String.Format("{0:yyyy-MM-ddTHH:mm:ss}", oCFD.Fecha) & "|" & "99" & "|" & oCFD.noCertificado & "|" & QuitarCeros(TruncateToDecimal(oCFD.TotalSueldos + oCFD.TotalSeparacion + oCFD.TotalJubilacion + oCFD.TotalOtrosPagos, 2), numDec) & "|" & IIf(oCFD.TotalDeducciones > 0, QuitarCeros(TruncateToDecimal(oCFD.TotalDeducciones, 2), numDec) & "|", "") & oCFD.Moneda & "|" & QuitarCeros(TruncateToDecimal(oCFD.TotalSueldos + oCFD.TotalSeparacion + oCFD.TotalJubilacion + oCFD.TotalOtrosPagos - oCFD.TotalDeducciones, 2), numDec) & "|N|PUE|" & oCFD.sCodigoPostal & "|"
            Else
                sNodoEncabezado = "||" & oCFD.VersionCF & "|" & String.Format("{0:yyyy-MM-ddTHH:mm:ss}", oCFD.Fecha) & "|" & "egreso" & "|" & oCFD.formaDePago & "|" & oCFD.subtotal & "|" & CStr(QuitarCeros(oCFD.descuento)) & "|" & oCFD.Moneda & "|" & QuitarCeros(oCFD.TotalSueldos + oCFD.TotalSeparacion + oCFD.TotalJubilacion + oCFD.TotalOtrosPagos - oCFD.TotalDeducciones) & "|"
            End If
        End If

        Dim sNodoRegimenFiscal As String = ""

        If oCFD.VersionCF = "2.2" OrElse oCFD.VersionCF = "3.2" Then

            If VersionNomina = 1 Then
                sNodoEncabezado &= "NA" & "|" & spaceFormat(oCFD.LugarExpedicion) & "|" & IIf(oCFD.NumCtaPago <> "", spaceFormat(oCFD.NumCtaPago) & "|", "")
            End If
            sNodoRegimenFiscal = oCFD.regimenFiscal & "|"

        End If

        Dim sNodoEmisor As String = ""
        If VersionNomina = 1 Then
            sNodoEmisor = spaceFormat(oCFD.eRFC) & "|" & spaceFormat(oCFD.eRazonSocial) & "|" & spaceFormat(oCFD.eCalle) & "|" & spaceFormat(oCFD.enoExterior) & IIf(oCFD.benoInterior, "|" & spaceFormat(oCFD.enoInterior), "") & "|" & spaceFormat(oCFD.eColonia) & "|" & IIf(oCFD.eLocalidad = "", "SIN LOCALIDAD", spaceFormat(oCFD.eLocalidad)) & "|" & spaceFormat(oCFD.eReferencia) & "|" & spaceFormat(oCFD.eMnpio) & "|" & spaceFormat(oCFD.eEntidad) & "|" & spaceFormat(oCFD.ePais) & "|" & spaceFormat(oCFD.eCodigoPostal) & "|"
        ElseIf VersionNomina = 2 Then
            If oCFD.VersionCF = "3.3" Then
                sNodoEmisor = spaceFormat(oCFD.eRFC) & "|" & spaceFormat(oCFD.eRazonSocial) & "|" & spaceFormat(oCFD.regimenFiscal) & "|"
            Else
                sNodoEmisor = "NA" & "|" & spaceFormat(oCFD.eCodigoPostal) & "|" & spaceFormat(oCFD.eRFC) & "|" & spaceFormat(oCFD.eRazonSocial) & "|"
            End If
        End If

            Dim sNodoExpedicion As String = ""

            If VersionNomina = 1 Then
                sNodoExpedicion = spaceFormat(oCFD.sCalle) & "|" & spaceFormat(oCFD.snoExterior) & IIf(oCFD.bsnoInterior, "|" & spaceFormat(oCFD.snoInterior), "") & "|" & spaceFormat(oCFD.sColonia) & "|" & IIf(oCFD.sLocalidad = "", "SIN LOCALIDAD", spaceFormat(oCFD.sLocalidad)) & "|" & spaceFormat(oCFD.sReferencia) & "|" & spaceFormat(oCFD.sMnpio) & "|" & spaceFormat(oCFD.sEntidad) & "|" & spaceFormat(oCFD.sPais) & "|" & spaceFormat(oCFD.sCodigoPostal) & "|"
            End If


            Dim sNodoReceptor As String = ""
        If VersionNomina = 1 Then
            sNodoReceptor = spaceFormat(oCFD.RFC) & "|" & spaceFormat(oCFD.RazonSocial) & "|" & spaceFormat(oCFD.Calle) & "|" & spaceFormat(oCFD.noExterior) & IIf(oCFD.brnoInterior, "|" & spaceFormat(oCFD.noInterior), "") & "|" & spaceFormat(oCFD.Colonia) & "|" & spaceFormat(oCFD.Mnpio) & "|" & spaceFormat(oCFD.Entidad) & "|" & spaceFormat(oCFD.Pais) & "|" & spaceFormat(oCFD.codigoPostal) & "|"

        ElseIf VersionNomina = 2 Then
            If oCFD.VersionCF = "3.3" Then
                sNodoReceptor = spaceFormat(oCFD.RFC) & "|" & spaceFormat(oCFD.RazonSocial) & "|P01|"
            Else
                sNodoReceptor = spaceFormat(oCFD.RFC) & "|" & spaceFormat(oCFD.RazonSocial) & "|"
            End If
        End If

            If oCFD.iTipoSucursal = 1 Then
                sNodoExpedicion = ""
            End If

        If oCFD.VersionCF = "3.3" Then
            sCadenaOriginal = sNodoEncabezado & sNodoEmisor & sNodoReceptor & sNodoConcepto
        Else
            sCadenaOriginal = sNodoEncabezado & sNodoEmisor & sNodoExpedicion & sNodoRegimenFiscal & sNodoReceptor & sNodoConcepto & IIf(VersionNomina = 1, sNodoImpuestosRetenidos, "")
        End If
            
        
        If VersionNomina = 2 Then

            Dim sTipoBanco As String
            sTipoBanco = "00" & CStr(oCFD.Banco)

            If (oCFD.TipoContrato = "09" OrElse oCFD.TipoContrato = "10" OrElse oCFD.TipoContrato = "99") Then
                oCFD.RegistroPatronal = ""
            End If

            Dim sNomina As String = "1.2|" & oCFD.TipoNomina & "|" & String.Format("{0:yyyy-MM-dd}", oCFD.FechaPago) & "|" & String.Format("{0:yyyy-MM-dd}", oCFD.FechaInicialPago) & "|" & String.Format("{0:yyyy-MM-dd}", oCFD.FechaFinalPago) & "|" & IIf(oCFD.VersionCF = "3.3", QuitarCeros(oCFD.NumDiasPagados, 3), CStr(oCFD.NumDiasPagados)) & "|" & IIf(oCFD.TotalGravadoP + oCFD.TotalExentoP > 0, QuitarCeros(TruncateToDecimal(oCFD.TotalSueldos + oCFD.TotalSeparacion + oCFD.TotalJubilacion, 2), numDec) & "|", "") & IIf(oCFD.TotalDeducciones > 0, QuitarCeros(TruncateToDecimal(oCFD.TotalDeducciones, 2), numDec) & "|", "") & IIf(oCFD.TotalOtrosPagos > 0, QuitarCeros(TruncateToDecimal(oCFD.TotalOtrosPagos, 2), numDec) & "|", "")
            Dim sEmisor As String = IIf(oCFD.eCURP <> "", oCFD.eCURP & "|", "") & IIf(oCFD.RegistroPatronal <> "", oCFD.RegistroPatronal & "|", "")
            Dim sReceptor As String = spaceFormat(oCFD.CURP) & "|" & IIf(oCFD.RegistroPatronal <> "", oCFD.NumSeguridadSocial & "|", "") & IIf(oCFD.RegistroPatronal <> "", String.Format("{0:yyyy-MM-dd}", oCFD.FechaInicioRelLaboral) & "|", "") & IIf(oCFD.RegistroPatronal <> "", oCFD.Antiguedad & "|", "") & oCFD.TipoContrato & "|" & IIf(oCFD.Sindicalizado = 1, "Sí", "No") & "|" & oCFD.TipoJornada & "|" & oCFD.TipoRegimen & "|" & oCFD.NumEmpleado & "|" & IIf(oCFD.Departamento <> "", oCFD.Departamento & "|", "") & IIf(oCFD.Puesto <> "", oCFD.Puesto & "|", "") & IIf(oCFD.TipoRegimen <> "11" AndAlso oCFD.RiesgoPuesto > 0 AndAlso oCFD.RegistroPatronal <> "", IIf(oCFD.NumSeguridadSocial <> "", CStr(oCFD.RiesgoPuesto), "99") & "|", "") & oCFD.PeriodicidadPago & "|" & IIf(CInt(oCFD.metodoDePago) = 5 OrElse CInt(oCFD.metodoDePago) = 6, sTipoBanco.Substring(sTipoBanco.Length - 3, 3) & "|" & oCFD.NumCtaPago & "|", "") & IIf(oCFD.SalarioBaseCotApor > 0, QuitarCeros(oCFD.SalarioBaseCotApor, numDec) & "|", "") & IIf(oCFD.SalarioDiarioIntegrado > 0 AndAlso oCFD.RegistroPatronal <> "", QuitarCeros(oCFD.SalarioDiarioIntegrado, numDec) & "|", "") & oCFD.ClaveEntFed & "|"

            Dim sPersepcion, sDeducciones, sIncapacidad, sOtrosPagos As String


            Dim dtConceptos As DataTable = ModPOS.Recupera_Tabla("sp_recupera_recibodet", "@RENClave", oCFD.RENClave)
            Dim dtHorasExtra As DataTable = ModPOS.Recupera_Tabla("sp_recupera_horasextra", "@RENClave", oCFD.RENClave)
            Dim dtAcciones As DataTable = ModPOS.Recupera_Tabla("sp_recupera_accion", "@RENClave", oCFD.RENClave)
            Dim dtJubilacion As DataTable = ModPOS.Recupera_Tabla("sp_recupera_jubilacion", "@RENClave", oCFD.RENClave)
            Dim dtSeparacion As DataTable = ModPOS.Recupera_Tabla("sp_recupera_separacion", "@RENClave", oCFD.RENClave)
            Dim dtCompensacion As DataTable = ModPOS.Recupera_Tabla("sp_recupera_compensacion", "@RENClave", oCFD.RENClave)

            Dim foundRowsDet() As DataRow
            foundRows = dtConceptos.Select("Tipo = 1")



            Dim sTipoPercepcion As String

            If foundRows.GetLength(0) > 0 Then

                sPersepcion = QuitarCeros(oCFD.TotalSueldos, numDec) & "|" & IIf(oCFD.TotalSeparacion > 0, QuitarCeros(oCFD.TotalSeparacion, numDec) & "|", "") & IIf(oCFD.TotalJubilacion > 0, QuitarCeros(oCFD.TotalJubilacion, numDec) & "|", "") & QuitarCeros(oCFD.TotalGravadoP, numDec) & "|" & QuitarCeros(oCFD.TotalExentoP, numDec) & "|"

                For i = 0 To foundRows.GetUpperBound(0)
                    sTipoPercepcion = "00" & CStr(foundRows(i)("TipoConcepto"))
                    sTipoPercepcion = sTipoPercepcion.Substring(sTipoPercepcion.Length - 3, 3)
                    sPersepcion &= sTipoPercepcion & "|" & foundRows(i)("Clave") & "|" & foundRows(i)("Concepto") & "|" & QuitarCeros(foundRows(i)("ImporteGravado"), numDec) & "|" & QuitarCeros(foundRows(i)("ImporteExento"), numDec) & "|"

                Next

                Dim foundRowsPercepcion() As DataRow

                'jubilacionPencion
                foundRowsPercepcion = dtConceptos.Select("Tipo = 1 and TipoConcepto= 39 ")
                If foundRowsPercepcion.GetLength(0) > 0 Then
                    foundRowsDet = dtJubilacion.Select("CONClave = '" & foundRowsPercepcion(0)("CONClave") & "'")
                    If foundRowsDet.GetLength(0) > 0 Then
                        sPersepcion &= QuitarCeros(foundRowsDet(0)("Importe"), numDec) & "|" & QuitarCeros(foundRowsDet(0)("IngresoAcumulable"), numDec) & "|" & QuitarCeros(foundRowsDet(0)("IngresoNoAcumulable"), numDec) & "|"
                    End If
                End If


                'jubilacionPencion
                foundRowsPercepcion = dtConceptos.Select("Tipo = 1 and TipoConcepto= 44 ")
                If foundRowsPercepcion.GetLength(0) > 0 Then
                    foundRowsDet = dtJubilacion.Select("CONClave = '" & foundRowsPercepcion(0)("CONClave") & "'")
                    If foundRowsDet.GetLength(0) > 0 Then
                        sPersepcion &= QuitarCeros(foundRowsDet(0)("Importe"), numDec) & "|" & QuitarCeros(foundRowsDet(0)("MontoDiario"), numDec) & "|" & QuitarCeros(foundRowsDet(0)("IngresoAcumulable"), numDec) & "|" & QuitarCeros(foundRowsDet(0)("IngresoNoAcumulable"), numDec) & "|"
                    End If
                End If


                'Separacionindenmizacion
                foundRowsPercepcion = dtConceptos.Select("Tipo = 1 and TipoConcepto= 22 ")
                If foundRowsPercepcion.GetLength(0) > 0 Then
                    foundRowsDet = dtSeparacion.Select("CONClave = '" & foundRowsPercepcion(0)("CONClave") & "'")
                    If foundRowsDet.GetLength(0) > 0 Then
                        sPersepcion &= QuitarCeros(foundRowsDet(0)("TotalPagado"), numDec) & "|" & CStr(foundRowsDet(0)("AñosServicio")) & "|" & QuitarCeros(foundRowsDet(0)("UltimoSueldo"), numDec) & "|" & QuitarCeros(foundRowsDet(0)("IngresoAcumulable"), numDec) & "|" & QuitarCeros(foundRowsDet(0)("IngresoNoAcumulable"), numDec) & "|"
                    End If

                End If


                'Separacionindenmizacion
                foundRowsPercepcion = dtConceptos.Select("Tipo = 1 and TipoConcepto= 23 ")
                If foundRowsPercepcion.GetLength(0) > 0 Then
                    foundRowsDet = dtSeparacion.Select("CONClave = '" & foundRowsPercepcion(0)("CONClave") & "'")
                    If foundRowsDet.GetLength(0) > 0 Then
                        sPersepcion &= QuitarCeros(foundRowsDet(0)("TotalPagado"), numDec) & "|" & CStr(foundRowsDet(0)("AñosServicio")) & "|" & QuitarCeros(foundRowsDet(0)("UltimoSueldo"), numDec) & "|" & QuitarCeros(foundRowsDet(0)("IngresoAcumulable"), numDec) & "|" & QuitarCeros(foundRowsDet(0)("IngresoNoAcumulable"), numDec) & "|"
                    End If

                End If

                'Separacionindenmizacion
                foundRowsPercepcion = dtConceptos.Select("Tipo = 1 and TipoConcepto= 25 ")
                If foundRowsPercepcion.GetLength(0) > 0 Then
                    foundRowsDet = dtSeparacion.Select("CONClave = '" & foundRowsPercepcion(0)("CONClave") & "'")
                    If foundRowsDet.GetLength(0) > 0 Then
                        sPersepcion &= QuitarCeros(foundRowsDet(0)("TotalPagado"), numDec) & "|" & CStr(foundRowsDet(0)("AñosServicio")) & "|" & QuitarCeros(foundRowsDet(0)("UltimoSueldo"), numDec) & "|" & QuitarCeros(foundRowsDet(0)("IngresoAcumulable"), numDec) & "|" & QuitarCeros(foundRowsDet(0)("IngresoNoAcumulable"), numDec) & "|"
                    End If

                End If

                'AccionesOTitulos
                foundRowsPercepcion = dtConceptos.Select("Tipo = 1 and TipoConcepto= 45 ")
                If foundRowsPercepcion.GetLength(0) > 0 Then
                    foundRowsDet = dtAcciones.Select("CONClave = '" & foundRowsPercepcion(0)("CONClave") & "'")
                    If foundRowsDet.GetLength(0) > 0 Then
                        sPersepcion &= QuitarCeros(foundRowsDet(0)("ValorMercado"), numDec) & "|" & QuitarCeros(foundRowsDet(0)("PrecioAlOtorgante"), numDec) & "|"
                    End If
                End If

                'HoraExtra
                foundRowsPercepcion = dtConceptos.Select("Tipo = 1 and TipoConcepto= 19 ")
                If foundRowsPercepcion.GetLength(0) > 0 Then

                    foundRowsDet = dtHorasExtra.Select("CONClave = '" & foundRowsPercepcion(0)("CONClave") & "'")
                    If foundRowsDet.GetLength(0) > 0 Then
                        Dim j As Integer

                        For j = 0 To foundRowsDet.GetUpperBound(0)
                            sPersepcion &= CStr(foundRowsDet(j)("Dias")) & "|" & foundRowsDet(j)("Tipo") & "|" & CStr(foundRowsDet(j)("HorasExtra")) & "|" & QuitarCeros(foundRowsDet(j)("ImportePagado"), numDec) & "|"
                        Next
                    End If
                End If



            End If


            foundRows = dtConceptos.Select("Tipo = 2")

            sDeducciones = ""
            If foundRows.GetLength(0) > 0 Then

                If (oCFD.TotalDeducciones - oCFD.ISR) > 0 Then
                    sDeducciones &= QuitarCeros(oCFD.TotalDeducciones - oCFD.ISR, numDec) & "|"
                End If

                If oCFD.ISR > 0 Then
                    sDeducciones &= QuitarCeros(oCFD.ISR, numDec) & "|"
                End If

                Dim sTipoDeduccion As String
                For i = 0 To foundRows.GetUpperBound(0)
                    sTipoDeduccion = "00" & CStr(foundRows(i)("TipoConcepto"))
                    sDeducciones &= sTipoDeduccion.Substring(sTipoDeduccion.Length - 3, 3) & "|" & foundRows(i)("Clave") & "|" & foundRows(i)("Concepto") & "|" & QuitarCeros(foundRows(i)("ImporteGravado"), numDec) & "|"
                Next
            End If

            Dim dtIncapacidad As DataTable = ModPOS.Recupera_Tabla("sp_recupera_incapacidad", "@RENClave", oCFD.RENClave)
            ' Incapacidades


            If dtIncapacidad.Rows.Count() > 0 Then
                sIncapacidad = ""
                For i = 0 To dtIncapacidad.Rows.Count() - 1
                    sIncapacidad &= CStr(dtIncapacidad.Rows(i)("Dias")) & "|" & dtIncapacidad.Rows(i)("TipoIncapacidad") & "|" & QuitarCeros(dtIncapacidad.Rows(i)("Descuento"), numDec) & "|"
                Next
            End If

            foundRows = dtConceptos.Select("Tipo = 3")

            If foundRows.GetLength(0) > 0 Then
                ' Otros Pagos  

                Dim sTipoOtroPago As String
                sOtrosPagos = ""
                For i = 0 To foundRows.GetUpperBound(0)
                    sTipoOtroPago = "00" & CStr(foundRows(i)("TipoConcepto"))
                    sTipoOtroPago = sTipoOtroPago.Substring(sTipoOtroPago.Length - 3, 3)
                    sOtrosPagos &= sTipoOtroPago & "|" & foundRows(i)("Clave") & "|" & foundRows(i)("Concepto") & "|" & QuitarCeros(foundRows(i)("ImporteGravado"), numDec) & "|"

                    Select Case sTipoOtroPago
                        Case Is = "002"

                            sOtrosPagos &= QuitarCeros(foundRows(i)("ImporteGravado"), numDec) & "|"

                        Case Is = "004"
                            foundRowsDet = dtCompensacion.Select("CONClave = '" & foundRows(i)("CONClave") & "'")
                            If foundRowsDet.GetLength(0) > 0 Then
                                sOtrosPagos &= QuitarCeros(foundRowsDet(0)("SaldoFavor"), numDec) & "|" & Str(foundRowsDet(0)("Año")) & "|" & QuitarCeros(foundRowsDet(0)("Remanente"), numDec) & "|"
                            End If
                    End Select

                Next

            End If

          
                sCadenaOriginal &= sNomina & sEmisor & sReceptor & sPersepcion & sDeducciones & sIncapacidad & sOtrosPagos


        End If


        Return sCadenaOriginal

    End Function

    Public Function generarSelloDigital(ByVal scadenaOriginal As String, ByVal Serie As String, ByVal Folio As String, ByVal LlaveFile As String, ByVal ContrasenaClave As String, ByVal VersionCFD As String) As String
        Dim FileName As String

        FileName = Serie & Folio

        'Verifica que exista el path
        Try
            If Not System.IO.Directory.Exists("C:\SelladoDigital\") Then
                System.IO.Directory.CreateDirectory("C:\SelladoDigital\")
            End If
        Catch ex As Exception
        End Try

        Dim DirSello As String = "C:\SelladoDigital\" & System.IO.Path.GetFileName(LlaveFile)

        If Not System.IO.File.Exists(DirSello) Then
            If System.IO.File.Exists(LlaveFile) Then
                System.IO.File.Copy(LlaveFile, DirSello)
            Else
                Return ""
                MessageBox.Show("El archivo " & LlaveFile & " no existe o se cambio de lugar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Function
            End If
        End If

        Dim cadenaOriginal As String = "C:\SelladoDigital\" & FileName & ".txt"

        Dim file_stream As New System.IO.FileStream(cadenaOriginal, System.IO.FileMode.Create)
        Dim bytes As Byte() = New System.Text.UTF8Encoding().GetBytes(scadenaOriginal)

        file_stream.Write(bytes, 0, bytes.Length)
        file_stream.Close()


        'Donde
        'cadenaOriginal: es el directorio donde se creara el archivo que contiene la cadena original

        Dim frmStatusMessage As New frmStatus
        frmStatusMessage.Show("Generando Sello Digital...")


        Dim dir As String
        Dim DirArchivoPEM As String = DirSello & ".pem"

        dir = "C:\OpenSSL\bin\openssl.exe"

        Shell(dir & " pkcs8 -inform DER -in " & DirSello & " -passin pass:" & ContrasenaClave & " -out " & DirArchivoPEM, AppWinStyle.Hide, True)


        'Donde
        'DirSello: es el directorio donde se encuentra el archivo.key
        'ContrasenaClave: es la contraseña

        Dim sello As String = "C:\SelladoDigital\" & FileName & "_sello.txt"
        ' Dim digestioncadena As String = "C:\" & "digestioncadena.txt"




        'Donde 
        'cadenaOriginal : es el directorio deonde se creo el archivo que contiene la cadenaOriginal
        'Sello: es el directorio donde se realizara el sellado del archivo donde se realizo la digestion de la cadena original
        'DirArchivoPEM: es el directorio y archivo .key.pem

        If VersionCFD = "3.3" Then
            Shell(dir & " dgst -sha256 -out " & sello & " -sign " & DirArchivoPEM & " " & cadenaOriginal, AppWinStyle.Hide, True)

        Else
            Shell(dir & " dgst -sha1 -out " & sello & " -sign " & DirArchivoPEM & " " & cadenaOriginal, AppWinStyle.Hide, True)

        End If


        Dim sello64 As String = "C:\SelladoDigital\" & FileName & "_sello64.txt"



        'Donde
        'Sello: nombre del archivo.txt donde fue creado el sellado de la digestion de la cadena original
        'Sello64: nombre del archivo.txt donde se creara el sello en caracteres imprimibles


        Shell(dir & " enc -base64 -in " & sello & " -out " & sello64 & " -A", AppWinStyle.Hide, True)


        Dim elsello As String

        Dim file As New System.IO.StreamReader(sello64)
        elsello = file.ReadLine()

        file.Close()

        frmStatusMessage.Dispose()

        If elsello = "" Then
            MessageBox.Show("Error al generar el sello digital, verifique que la contraseña del Certificado de Sello Digital que ingreso en la configuración de la compañia sea la correcta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        Try
            My.Computer.FileSystem.DeleteFile(cadenaOriginal, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
            My.Computer.FileSystem.DeleteFile(sello, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
            My.Computer.FileSystem.DeleteFile(sello64, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)

        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
        End Try

        Return elsello

    End Function

    Public Function generaPFX(ByVal LlaveFile As String, ByVal CertificadoFile As String, ByVal ContrasenaClave As String) As String

        Dim FilePFX As String = System.IO.Path.GetFileName(LlaveFile).Replace(".key", ".pfx")


        'Verifica que exista el path del .Key
        Try
            If Not System.IO.File.Exists(LlaveFile) Then
                MessageBox.Show("El archivo " & LlaveFile & " no existe o se puede tener acceso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return ""
                Exit Function
            End If
        Catch ex As Exception
        End Try


        'Verifica que exista el path del .Cer
        Try
            If Not System.IO.File.Exists(CertificadoFile) Then
                MessageBox.Show("El archivo " & CertificadoFile & " no existe o se puede tener acceso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return ""
                Exit Function
            End If
        Catch ex As Exception
        End Try

        'Verifica que exista el path
        Try
            If Not System.IO.Directory.Exists("C:\SelladoDigital\") Then
                System.IO.Directory.CreateDirectory("C:\SelladoDigital\")
            End If
        Catch ex As Exception
        End Try



        Dim DirKey As String = "C:\SelladoDigital\" & System.IO.Path.GetFileName(LlaveFile)
        Dim DirCer As String = "C:\SelladoDigital\" & System.IO.Path.GetFileName(CertificadoFile)

        If Not System.IO.File.Exists(DirKey) Then
            If System.IO.File.Exists(LlaveFile) Then
                System.IO.File.Copy(LlaveFile, DirKey)
            Else
                MessageBox.Show("El archivo " & LlaveFile & " no existe o se cambio de lugar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return ""
                Exit Function
            End If
        End If


        If Not System.IO.File.Exists(DirCer) Then
            If System.IO.File.Exists(CertificadoFile) Then
                System.IO.File.Copy(CertificadoFile, DirCer)
            Else
                MessageBox.Show("El archivo " & CertificadoFile & " no existe o se cambio de lugar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return ""
                Exit Function
            End If
        End If



        Dim dir As String
        Dim DirArchivoPEM As String = DirKey & ".pem"
        Dim DirCERPEM As String = DirCer & ".pem"
        Dim DirPFX As String = "C:\SelladoDigital\" & FilePFX

        dir = "C:\OpenSSL\bin\openssl.exe"

        If Not System.IO.File.Exists(DirPFX) Then
            Shell(dir & " pkcs8 -inform DER -in " & DirKey & " -passin pass:" & ContrasenaClave & " -out " & DirArchivoPEM, AppWinStyle.Hide, True)
            Shell(dir & " x509  -inform DER -in " & DirCer & " -out " & DirCERPEM, AppWinStyle.Hide, True)
            Shell(dir & " pkcs12 -export -out " & DirPFX & " -inkey  " & DirArchivoPEM & " -in  " & DirCERPEM & " -passout pass:" & ContrasenaClave, AppWinStyle.Hide, True)
        End If

        Dim fi1 As System.IO.FileInfo = New System.IO.FileInfo(DirPFX)


        If fi1.Length = 0 Then
            MessageBox.Show("No fue posible acceder al archivo .pfx", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return ""
            Exit Function
        End If

        Dim leer_archivo As New System.IO.FileStream(DirPFX, IO.FileMode.Open)
        Dim bytesLeidos(leer_archivo.Length) As Byte
        leer_archivo.Read(bytesLeidos, 0, leer_archivo.Length)
        leer_archivo.Close()

        Dim AchivoPFX64 As String = Convert.ToBase64String(bytesLeidos)

        Return AchivoPFX64

    End Function

    Public Function generaPFXByte(ByVal LlaveFile As String, ByVal CertificadoFile As String, ByVal ContrasenaClave As String) As Byte()

        Dim FilePFX As String = System.IO.Path.GetFileName(LlaveFile).Replace(".key", ".pfx")


        'Verifica que exista el path del .Key
        Try
            If Not System.IO.File.Exists(LlaveFile) Then
                MessageBox.Show("El archivo " & LlaveFile & " no existe o se puede tener acceso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return Nothing
                Exit Function
            End If
        Catch ex As Exception
        End Try


        'Verifica que exista el path del .Cer
        Try
            If Not System.IO.File.Exists(CertificadoFile) Then
                MessageBox.Show("El archivo " & CertificadoFile & " no existe o se puede tener acceso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return Nothing
                Exit Function
            End If
        Catch ex As Exception
        End Try

        'Verifica que exista el path
        Try
            If Not System.IO.Directory.Exists("C:\SelladoDigital\") Then
                System.IO.Directory.CreateDirectory("C:\SelladoDigital\")
            End If
        Catch ex As Exception
        End Try



        Dim DirKey As String = "C:\SelladoDigital\" & System.IO.Path.GetFileName(LlaveFile)
        Dim DirCer As String = "C:\SelladoDigital\" & System.IO.Path.GetFileName(CertificadoFile)

        If Not System.IO.File.Exists(DirKey) Then
            If System.IO.File.Exists(LlaveFile) Then
                System.IO.File.Copy(LlaveFile, DirKey)
            Else
                MessageBox.Show("El archivo " & LlaveFile & " no existe o se cambio de lugar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return Nothing
                Exit Function
            End If
        End If


        If Not System.IO.File.Exists(DirCer) Then
            If System.IO.File.Exists(CertificadoFile) Then
                System.IO.File.Copy(CertificadoFile, DirCer)
            Else
                MessageBox.Show("El archivo " & CertificadoFile & " no existe o se cambio de lugar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return Nothing
                Exit Function
            End If
        End If



        Dim dir As String
        Dim DirArchivoPEM As String = DirKey & ".pem"
        Dim DirCERPEM As String = DirCer & ".pem"
        Dim DirPFX As String = "C:\SelladoDigital\" & FilePFX

        dir = "C:\OpenSSL\bin\openssl.exe"

        If Not System.IO.File.Exists(DirPFX) Then
            Shell(dir & " pkcs8 -inform DER -in " & DirKey & " -passin pass:" & ContrasenaClave & " -out " & DirArchivoPEM, AppWinStyle.Hide, True)
            Shell(dir & " x509  -inform DER -in " & DirCer & " -out " & DirCERPEM, AppWinStyle.Hide, True)
            Shell(dir & " pkcs12 -export -out " & DirPFX & " -inkey  " & DirArchivoPEM & " -in  " & DirCERPEM & " -passout pass:" & ContrasenaClave, AppWinStyle.Hide, True)
        End If

        Dim fi1 As System.IO.FileInfo = New System.IO.FileInfo(DirPFX)


        If fi1.Length = 0 Then
            MessageBox.Show("No fue posible acceder al archivo .pfx", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
            Exit Function
        End If

        Dim leer_archivo As New System.IO.FileStream(DirPFX, IO.FileMode.Open)
        Dim bytesLeidos(leer_archivo.Length) As Byte
        leer_archivo.Read(bytesLeidos, 0, leer_archivo.Length)
        leer_archivo.Close()

        Return bytesLeidos

    End Function

    Public Function ConvertBitmapToByteArray(ByVal imageIn As System.Drawing.Bitmap) As Byte()
        Return DirectCast(System.ComponentModel.TypeDescriptor.GetConverter(imageIn).ConvertTo(imageIn, GetType(Byte())), Byte())
    End Function

    Public Function ReadFile(ByVal strArchivo As String) As Byte()

        Dim f As New System.IO.FileStream(strArchivo, System.IO.FileMode.Open, System.IO.FileAccess.Read)

        Dim size As Integer = CInt(f.Length)

        Dim data As Byte() = New Byte(size - 1) {}

        size = f.Read(data, 0, size)

        f.Close()

        Return data

    End Function

    Public Function GeneraCertificadoX64(ByVal ArchivodeCertificado As String) As String
        'Dim SArchivos As String
        Dim CerBase64 As String

        'SArchivos = System.IO.Directory.GetFiles(DirArchivosFacElec, "*.cer")



        Dim certEmisor As New System.Security.Cryptography.X509Certificates.X509Certificate2()

        ' Generas un objeto del tipo de certificado

        Dim byteCertData As Byte() = ReadFile(ArchivodeCertificado)

        ' Manda llamar la funcion Readfile para cargar el ar.cer 

        certEmisor.Import(byteCertData)

        ' Importa los datos del certificado qeu acabas de leer

        CerBase64 = Convert.ToBase64String(certEmisor.GetRawCertData())

        ' Conviertelos a Base64
        Return CerBase64
    End Function

    Public Function ReadCSV(ByVal Filename As String, ByVal iColumnas As Integer) As DataTable
        Dim strfilename As String
        Dim dt As DataTable = Nothing

        ' Load the file.
        strfilename = Filename

        'Check if file exist
        If System.IO.File.Exists(strfilename) Then
            Dim tmpstream As System.IO.StreamReader = System.IO.File.OpenText(strfilename)
            Dim strlines() As String
            Dim strline() As String

            'Load content of file to strLines array
            strlines = tmpstream.ReadToEnd().Split(Environment.NewLine)


            Select Case iColumnas
                Case Is = 4
                    dt = ModPOS.CrearTabla("TablaTemporal", _
                                                                     "Area", "System.String", _
                                                                     "Ubicacion", "System.String", _
                                                                     "Producto", "System.String", _
                                                                     "Capacidad", "System.String")

                Case Is = 3
                    dt = ModPOS.CrearTabla("TablaTemporal", _
                                                                     "UBCClave", "System.String", _
                                                                     "GTIN", "System.String", _
                                                                     "Cantidad", "System.String")
                Case Is = 2
                    dt = ModPOS.CrearTabla("TablaTemporal", _
                                                                     "GTIN", "System.String", _
                                                                     "Cantidad", "System.String")
            End Select



            Dim x As Integer

            For x = 0 To strlines.Length - 1
                strline = strlines(x).Split(",")
                If iColumnas = 4 Then
                    If strline.Length = 4 Then
                        If strline(0) <> String.Empty AndAlso strline(1) <> String.Empty AndAlso strline(2) <> String.Empty AndAlso strline(3) <> String.Empty Then
                            Dim row1 As DataRow
                            row1 = dt.NewRow()
                            'declara el nombre de la fila
                            row1.Item("Area") = strline(0)
                            row1.Item("Ubicacion") = strline(1)
                            row1.Item("Producto") = strline(2)
                            row1.Item("Capacidad") = strline(3)
                            dt.Rows.Add(row1)
                        End If
                    End If
                ElseIf iColumnas = 3 Then
                    If strline.Length = 3 Then
                        If strline(0) <> String.Empty AndAlso strline(1) <> String.Empty AndAlso strline(2) <> String.Empty Then
                            Dim row1 As DataRow
                            row1 = dt.NewRow()
                            'declara el nombre de la fila
                            row1.Item("UBCClave") = strline(0)
                            row1.Item("GTIN") = strline(1)
                            row1.Item("Cantidad") = strline(2)
                            dt.Rows.Add(row1)
                        End If
                    End If
                ElseIf iColumnas = 2 Then
                    If strline.Length = 2 Then
                        If strline(0) <> String.Empty AndAlso strline(1) <> String.Empty Then
                            Dim row1 As DataRow
                            row1 = dt.NewRow()
                            'declara el nombre de la fila
                            row1.Item("GTIN") = strline(0)
                            row1.Item("Cantidad") = strline(1)
                            dt.Rows.Add(row1)
                        End If
                    End If
                End If
            Next

        End If
        Return dt

    End Function

    Public Function LeerCSV(ByVal Filename As String) As DataTable
        Dim strfilename As String
        Dim dt As DataTable = Nothing

        ' Load the file.
        strfilename = Filename

        'Check if file exist
        If System.IO.File.Exists(strfilename) Then
            Dim tmpstream As System.IO.StreamReader = System.IO.File.OpenText(strfilename)
            Dim strlines() As String
            Dim strline() As String

            'Load content of file to strLines array
            strlines = tmpstream.ReadToEnd().Split(Environment.NewLine)


            dt = ModPOS.CrearTabla("TablaTemporal", _
                                                 "GTIN", "System.String", _
                                                 "Cantidad", "System.String")

            Dim x As Integer

            For x = 0 To strlines.Length - 1
                strline = strlines(x).Split(",")
                If strline.Length = 2 Then
                    If strline(0) <> String.Empty AndAlso strline(1) <> String.Empty Then
                        Dim row1 As DataRow
                        row1 = dt.NewRow()
                        'declara el nombre de la fila
                        row1.Item("GTIN") = strline(0)
                        row1.Item("Cantidad") = strline(1)
                        dt.Rows.Add(row1)
                    End If
                End If
            Next

        End If
        Return dt

    End Function

    Public Sub AbrirCajon(ByVal PrinterName As String)
        Dim ESC, p, m, t1, t2 As Integer
        Dim dt As DataTable
        dt = ModPOS.Recupera_Tabla("sp_recupera_impresora", "@Printer", PrinterName)
        ESC = IIf(dt.Rows(0)("ESC").GetType.Name = "DBNull", 27, dt.Rows(0)("ESC"))
        p = IIf(dt.Rows(0)("p").GetType.Name = "DBNull", 112, dt.Rows(0)("p"))
        m = IIf(dt.Rows(0)("m").GetType.Name = "DBNull", 0, dt.Rows(0)("m"))
        t1 = IIf(dt.Rows(0)("t1").GetType.Name = "DBNull", 20, dt.Rows(0)("t1"))
        t2 = IIf(dt.Rows(0)("t2").GetType.Name = "DBNull", 20, dt.Rows(0)("t2"))
        dt.Dispose()
        Dim drawer As String = Chr(ESC) & Chr(p) & Chr(m) & Chr(t1) & Chr(t2)
        RawPrinterHelper.SendStringToPrinter(PrinterName, drawer)
    End Sub

    Public Function RecuperaImpuesto(ByVal sSUCClave As String, ByVal sPROClave As String, ByVal iTImpuesto As Integer) As Decimal
        Dim dtImpuesto As DataTable
        Dim i As Integer
        Dim PorcImp As Decimal = 0
        dtImpuesto = ModPOS.SiExisteRecupera("sp_obtenerimpuesto", "@SUCClave", sSUCClave, "@PROClave", sPROClave, "@TImpuesto", iTImpuesto)
        PorcImp = dtImpuesto.Rows(i)("PorcImp")
        dtImpuesto.Dispose()
        Return Redondear(PorcImp, 4)
    End Function

    Public Sub InsertaComandaImpuesto(ByVal PartidaId As String, ByVal sPROClave As String, ByVal dPrecio As Double, ByVal iTImpuesto As Integer, ByVal sSUCClave As String)
        Dim PrecioImp As Double = dPrecio
        Dim ImpImporte As Double = 0
        Dim dtImpuesto As DataTable
        Dim i As Integer
        dtImpuesto = ModPOS.SiExisteRecupera("sp_venta_impuesto", "@PROClave", sPROClave, "@TImpuesto", iTImpuesto, "@SUCClave", sSUCClave)
        If Not dtImpuesto Is Nothing AndAlso Not dtImpuesto.Rows(0)("Valor") Is DBNull.Value Then
            For i = 0 To dtImpuesto.Rows.Count() - 1
                If dtImpuesto.Rows(i)("SobreImp") Then ' Si aplica sobre impuesto
                    If dtImpuesto.Rows(i)("TipoAplicacion") = 1 Then '1  = Porcentaje
                        ImpImporte = PrecioImp * (dtImpuesto.Rows(i)("Valor") / 100)
                    Else
                        ImpImporte = dtImpuesto.Rows(i)("Valor")
                    End If
                Else
                    If dtImpuesto.Rows(i)("TipoAplicacion") = 1 Then '1 = Porcentaje
                        ImpImporte = dPrecio * (dtImpuesto.Rows(i)("Valor") / 100)
                    Else
                        ImpImporte = dtImpuesto.Rows(i)("Valor")
                    End If
                End If
                ModPOS.Ejecuta("sp_inserta_ComandaImpuesto", "@DCMClave", PartidaId, "@IMPClave", dtImpuesto.Rows(i)("IMPClave"), "@PorcImp", dtImpuesto.Rows(i)("Valor"), "@Importe", ImpImporte, "@Usuario", ModPOS.UsuarioActual)
                PrecioImp += ImpImporte
            Next
            dtImpuesto.Dispose()
        End If
    End Sub


    Public Sub InsertaImpuesto(ByVal PartidaId As String, ByVal sPROClave As String, ByVal dPrecio As Double, ByVal iTImpuesto As Integer, ByVal sSUCClave As String)
        Dim PrecioImp As Double = dPrecio
        Dim ImpImporte As Double = 0
        Dim dtImpuesto As DataTable
        Dim Base As Double
        Dim i As Integer
        dtImpuesto = ModPOS.SiExisteRecupera("sp_venta_impuesto", "@PROClave", sPROClave, "@TImpuesto", iTImpuesto, "@SUCClave", sSUCClave)
        If Not dtImpuesto Is Nothing AndAlso Not dtImpuesto.Rows(0)("Valor") Is DBNull.Value Then
            For i = 0 To dtImpuesto.Rows.Count() - 1
                If dtImpuesto.Rows(i)("SobreImp") Then ' Si aplica sobre impuesto
                    If dtImpuesto.Rows(i)("TipoAplicacion") = 1 Then '1  = Porcentaje
                        ImpImporte = PrecioImp * (dtImpuesto.Rows(i)("Valor") / 100)
                    Else
                        ImpImporte = dtImpuesto.Rows(i)("Valor")
                    End If
                    Base = PrecioImp
                Else
                    If dtImpuesto.Rows(i)("TipoAplicacion") = 1 Then '1 = Porcentaje
                        ImpImporte = dPrecio * (dtImpuesto.Rows(i)("Valor") / 100)
                    Else
                        ImpImporte = dtImpuesto.Rows(i)("Valor")
                    End If
                    Base = dPrecio
                End If
                ModPOS.Ejecuta("sp_inserta_detalle_impuesto", "@DVEClave", PartidaId, "@IMPClave", dtImpuesto.Rows(i)("IMPClave"), "@Base", Base, "@PorcImp", dtImpuesto.Rows(i)("Valor"), "@Importe", Math.Round(ImpImporte, 2), "@Usuario", ModPOS.UsuarioActual)
                PrecioImp += Math.Round(ImpImporte, 2)
            Next
            dtImpuesto.Dispose()
        End If
    End Sub

    Public Sub RecalculaImpuesto(ByVal dtDetalle As DataTable, ByVal iTImpuesto As Integer, ByVal sSUCClave As String)
        Dim x As Integer
        For x = 0 To dtDetalle.Rows.Count() - 1
            Dim PrecioImp As Decimal = dtDetalle.Rows(x)("SubTotalPartida") - dtDetalle.Rows(x)("DescuentoImp")
            Dim ImpImporte As Decimal = 0
            Dim dtImpuesto As DataTable
            Dim Base As Decimal
            Dim i As Integer
            dtImpuesto = ModPOS.SiExisteRecupera("sp_venta_impuesto", "@PROClave", dtDetalle.Rows(x)("PROClave"), "@TImpuesto", iTImpuesto, "@SUCClave", sSUCClave)
            If Not dtImpuesto Is Nothing AndAlso Not dtImpuesto.Rows(0)("Valor") Is DBNull.Value Then
                For i = 0 To dtImpuesto.Rows.Count() - 1
                    If dtImpuesto.Rows(i)("SobreImp") Then ' Si aplica sobre impuesto
                        If dtImpuesto.Rows(i)("TipoAplicacion") = 1 Then '1  = Porcentaje
                            ImpImporte = PrecioImp * (dtImpuesto.Rows(i)("Valor") / 100)
                        Else
                            ImpImporte = dtImpuesto.Rows(i)("Valor")
                        End If
                        Base = PrecioImp
                    Else
                        If dtImpuesto.Rows(i)("TipoAplicacion") = 1 Then '1 = Porcentaje
                            ImpImporte = (dtDetalle.Rows(x)("SubTotalPartida") - dtDetalle.Rows(x)("DescuentoImp")) * (dtImpuesto.Rows(i)("Valor") / 100)
                        Else
                            ImpImporte = dtImpuesto.Rows(i)("Valor")
                        End If
                        Base = dtDetalle.Rows(x)("SubTotalPartida") - dtDetalle.Rows(x)("DescuentoImp")
                    End If
                    ModPOS.Ejecuta("sp_actualiza_detalle_impuesto", "DVEClave", dtDetalle.Rows(x)("DVEClave"), "@IMPClave", dtImpuesto.Rows(i)("IMPClave"), "@Importe", Math.Round(ImpImporte, 2), "@Base", Base)
                    PrecioImp += Math.Round(ImpImporte, 2)
                Next
                dtImpuesto.Dispose()
            End If
        Next
    End Sub


    Public Sub RecalculaImpuestoComanda(ByVal dtDetalle As DataTable, ByVal iTImpuesto As Integer, ByVal sSUCClave As String)
        Dim x As Integer
        For x = 0 To dtDetalle.Rows.Count() - 1
            Dim PrecioImp As Double = dtDetalle.Rows(x)("PrecioBruto") - dtDetalle.Rows(x)("DescuentoImp")
            Dim ImpImporte As Double = 0
            Dim dtImpuesto As DataTable
            Dim i As Integer
            dtImpuesto = ModPOS.SiExisteRecupera("sp_venta_impuesto", "@PROClave", dtDetalle.Rows(x)("PROClave"), "@TImpuesto", iTImpuesto, "@SUCClave", sSUCClave)
            If Not dtImpuesto Is Nothing AndAlso Not dtImpuesto.Rows(0)("Valor") Is DBNull.Value Then
                For i = 0 To dtImpuesto.Rows.Count() - 1
                    If dtImpuesto.Rows(i)("SobreImp") Then ' Si aplica sobre impuesto
                        If dtImpuesto.Rows(i)("TipoAplicacion") = 1 Then '1  = Porcentaje
                            ImpImporte = PrecioImp * (dtImpuesto.Rows(i)("Valor") / 100)
                        Else
                            ImpImporte = dtImpuesto.Rows(i)("Valor")
                        End If
                    Else
                        If dtImpuesto.Rows(i)("TipoAplicacion") = 1 Then '1 = Porcentaje
                            ImpImporte = (dtDetalle.Rows(x)("PrecioBruto") - dtDetalle.Rows(x)("DescuentoImp")) * (dtImpuesto.Rows(i)("Valor") / 100)
                        Else
                            ImpImporte = dtImpuesto.Rows(i)("Valor")
                        End If
                    End If
                    ModPOS.Ejecuta("sp_act_detalle_impuesto_comanda", "DCMClave", dtDetalle.Rows(x)("DCMClave"), "@IMPClave", dtImpuesto.Rows(i)("IMPClave"), "@Importe", ImpImporte)
                    PrecioImp += ImpImporte
                Next
                dtImpuesto.Dispose()
            End If
        Next
    End Sub

    Function DesEncripta(ByVal Pass As String) As String
        Dim Clave As String, i As Integer, Pass2 As String
        Dim CAR As String, Codigo As String
        Dim j As Integer

        Clave = "%ü&/@#$A"
        Pass2 = ""
        j = 1
        For i = 1 To Len(Pass) Step 2
            CAR = Mid(Pass, i, 2)
            Codigo = Mid(Clave, ((j - 1) Mod Len(Clave)) + 1, 1)
            Pass2 = Pass2 & Chr(Asc(Codigo) Xor Val("&h" + CAR))
            j = j + 1
        Next i
        DesEncripta = Pass2
    End Function

    Public Function EncryptText(ByVal strText As String, ByVal strPwd As String) As String
        Dim i As Integer, C As Integer
        Dim strBuff As String = ""

        strPwd = UCase$(strPwd)

        'Encrypt string
        If Len(strPwd) Then
            For i = 1 To Len(strText)
                C = Asc(Mid$(strText, i, 1))
                C = C + Asc(Mid$(strPwd, (i Mod Len(strPwd)) + 1, 1))
                strBuff = strBuff & Chr(C And &HFF)
            Next i
        Else
            strBuff = strText
        End If

        Return strBuff
    End Function

    Public Function DecryptText(ByVal strText As String, ByVal strPwd As String) As String
        Dim i As Integer, C As Integer
        Dim strBuff As String = ""

        strPwd = UCase$(strPwd)

        'Decrypt string
        If Len(strPwd) Then
            For i = 1 To Len(strText)
                C = Asc(Mid$(strText, i, 1))
                C = C - Asc(Mid$(strPwd, (i Mod Len(strPwd)) + 1, 1))
                strBuff = strBuff & Chr(C And &HFF)
            Next i
        Else
            strBuff = strText
        End If

        Return strBuff
    End Function


#Region "Procedimientos y Funciones Generales"

    Private Function ColumnEqual(ByVal A As Object, ByVal B As Object) As Boolean

        If A Is DBNull.Value AndAlso B Is DBNull.Value Then
            Return True
        ElseIf A Is DBNull.Value OrElse B Is DBNull.Value Then
            Return False
        Else
            Return A = B
        End If

    End Function


    Public Function SelectDistinc(ByVal Tabla As String, ByVal TablaOrigen As DataTable, ByVal Campo As String) As DataTable

        Dim dt As New DataTable(Tabla)
        dt.Columns.Add(Campo, TablaOrigen.Columns(Campo).DataType)

        Dim dr As DataRow, LastValue As Object
        LastValue = Nothing
        For Each dr In TablaOrigen.Select("", Campo)
            If LastValue Is Nothing OrElse Not ColumnEqual(LastValue, dr(Campo)) Then
                LastValue = dr(Campo)
                dt.Rows.Add(New Object() {LastValue})
            End If
        Next

        Return dt
    End Function



    Public Sub imprimirTicketTraslado(ByVal Ticket As String, ByVal Generic As Boolean, ByVal sTRSClave As String)
        Dim Tickets As Imprimir = New Imprimir '.PrintTicket.Ticket
        Tickets.Generic = Generic

        Dim Impresora As String

        Dim lineasImpresas As Integer = 19

        Dim pd As New System.Drawing.Printing.PrintDocument
        Impresora = pd.PrinterSettings.PrinterName
        pd.Dispose()

        Dim dtTicket As DataTable
        dtTicket = ModPOS.SiExisteRecupera("sp_recupera_ticket", "@TIKClave", Ticket)

        If Not dtTicket Is Nothing Then
            Tickets.MaxCharLine = dtTicket.Rows(0)("MaxChar")
            Tickets.LetraSize = dtTicket.Rows(0)("FontSize")
            Tickets.LetraName = dtTicket.Rows(0)("FontName")
            If dtTicket.Rows(0)("url_imagen") <> "" Then
                Tickets.ImgHeader = ModPOS.RecuperaImagen(dtTicket.Rows(0)("url_imagen"))
            End If
            dtTicket.Dispose()
        End If

        Dim dtTraslado As DataTable

        dtTraslado = ModPOS.SiExisteRecupera("sp_rep_traslado", "@TRSClave", sTRSClave)

        Dim sEstatus As String = ""
        Dim sFolio As String = ""
        Dim sSucursalO As String = ""
        Dim sSucursalD As String = ""
        Dim sMotivo As String = ""
        Dim sNota As String = ""
        Dim usuRealiza As String = ""
        Dim usuAutoriza As String = ""
        Dim sSolicita As String = ""

        If Not dtTraslado Is Nothing AndAlso dtTraslado.Rows.Count > 0 Then
            sEstatus = dtTraslado.Rows(0)("CEstado")
            sFolio = dtTraslado.Rows(0)("Folio")
            sSucursalO = dtTraslado.Rows(0)("CSucursalO")
            sSucursalD = dtTraslado.Rows(0)("CSucursalD")
            sMotivo = dtTraslado.Rows(0)("Motivo")
            sSolicita = dtTraslado.Rows(0)("Solicita")
            sNota = dtTraslado.Rows(0)("Notas")
            usuRealiza = dtTraslado.Rows(0)("CRegistro")
            usuAutoriza = dtTraslado.Rows(0)("CAutorizo")
            dtTraslado.Dispose()
        End If


        Tickets.AddHeaderLine("TRASLADO DE MERCANCIA", Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Centrado)
        Tickets.AddHeaderLine("FOLIO: " & sFolio, Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Centrado)
        Tickets.AddHeaderLine("SALIDA DE: " & sSucursalO, Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Izquierda)
        Tickets.AddHeaderLine("ENTRADA A: " & sSucursalD, Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Izquierda)

        Tickets.AddHeaderLine("MOTIVO: " & sMotivo, Imprimir.FontEstilo.Regular, Imprimir.Alinear.Izquierda)
        Tickets.AddHeaderLine("SOLICITA: " & sSolicita, Imprimir.FontEstilo.Regular, Imprimir.Alinear.Izquierda)
        Tickets.AddHeaderLine("NOTA: " & sNota, Imprimir.FontEstilo.Regular, Imprimir.Alinear.Izquierda)

        Tickets.AddHeaderLine("ESTATUS: " & sEstatus, Imprimir.FontEstilo.Regular, Imprimir.Alinear.Izquierda)

        'El metodo AddSubHeaderLine es lo mismo al de AddHeaderLine con la diferencia 
        'de que al final de cada linea agrega una linea punteada "==========" 
        Tickets.AddHeaderLine("REALIZA: " & usuRealiza, 0, 1)
        Tickets.AddHeaderLine("AUTORIZA: " & usuAutoriza, 0, 1)
        Tickets.AddSubHeaderLine("FECHA: " & DateTime.Now.ToShortDateString() & " " & DateTime.Now.ToShortTimeString(), 0, 1)


        Dim dtTrasladoDetalle As DataTable
        dtTrasladoDetalle = ModPOS.Recupera_Tabla("sp_detalle_traslado", "@TRSClave", sTRSClave)

        lineasImpresas += (dtTrasladoDetalle.Rows.Count * 2)
        Dim dTotalTransferencia As Double = 0
        If Not dtTrasladoDetalle Is Nothing AndAlso dtTrasladoDetalle.Rows.Count > 0 Then
            Dim i As Integer = 0
            For i = 0 To dtTrasladoDetalle.Rows.Count() - 1
                Dim sGTIN As String = dtTrasladoDetalle.Rows(i)("Clave")
                Dim sUnidad As String = dtTrasladoDetalle.Rows(i)("Unidad")
                Dim sNombre As String = dtTrasladoDetalle.Rows(i)("Nombre")
                Dim dCantidad As Double = dtTrasladoDetalle.Rows(i)("Cantidad")
                Dim dCosto As Double = dtTrasladoDetalle.Rows(i)("Costo")
                Dim dCostoTotal As Double = dtTrasladoDetalle.Rows(i)("Total")
                dTotalTransferencia += dCostoTotal
                ' AGREGAR PAGOS A LISTA
                Tickets.AddItemTransferencia(sGTIN, sNombre, dCantidad, dCosto, dCostoTotal)
            Next
            dtTrasladoDetalle.Dispose()
        End If
        lineasImpresas += 1
        Tickets.AddTotalTicket(dTotalTransferencia, Imprimir.FontEstilo.Negrita)

        Tickets.AddFooterLine("", 0, 1)
        Tickets.AddFooterLine("", 0, 1)
        Tickets.AddFooterLine("_______________", 0, 3)
        Tickets.AddFooterLine("ENTREGO", 0, 3)
        Tickets.AddFooterLine("", 0, 1)
        Tickets.AddFooterLine("", 0, 1)
        Tickets.AddFooterLine("_______________", 0, 3)
        Tickets.AddFooterLine("RECIBIO", 0, 3)

        Tickets.PrintTicket(Impresora, 28, lineasImpresas)

    End Sub

    Public Sub imprimirTicketTransferencia(ByVal Ticket As String, ByVal Generic As Boolean, ByVal sMVAClave As String)
        Dim Tickets As Imprimir = New Imprimir '.PrintTicket.Ticket
        Tickets.Generic = Generic

        Dim Impresora As String

        Dim lineasImpresas As Integer = 19

        Dim pd As New System.Drawing.Printing.PrintDocument
        Impresora = pd.PrinterSettings.PrinterName
        pd.Dispose()

        Dim dtTicket As DataTable
        dtTicket = ModPOS.SiExisteRecupera("sp_recupera_ticket", "@TIKClave", Ticket)

        If Not dtTicket Is Nothing Then
            Tickets.MaxCharLine = dtTicket.Rows(0)("MaxChar")
            Tickets.LetraSize = dtTicket.Rows(0)("FontSize")
            Tickets.LetraName = dtTicket.Rows(0)("FontName")
            If dtTicket.Rows(0)("url_imagen") <> "" Then
                Tickets.ImgHeader = ModPOS.RecuperaImagen(dtTicket.Rows(0)("url_imagen"))
            End If
            dtTicket.Dispose()
        End If

        Dim dtMOVALM As DataTable

        dtMOVALM = ModPOS.SiExisteRecupera("sp_rep_transferencia", "@MVAClave", sMVAClave)

        Dim sEstatus As String = ""
        Dim sFolio As String = ""
        Dim sALMSalida As String = ""
        Dim sALMEntrada As String = ""
        Dim sTipo As String = ""
        Dim sMotivo As String = ""
        Dim sSolicita As String = ""
        Dim sNota As String = ""
        Dim usuRealiza As String = ""
        Dim usuAutoriza As String = ""

        If Not dtMOVALM Is Nothing AndAlso dtMOVALM.Rows.Count > 0 Then
            sEstatus = dtMOVALM.Rows(0)("CEstado")
            sFolio = dtMOVALM.Rows(0)("Folio")
            sALMSalida = dtMOVALM.Rows(0)("CAlmacenO")
            sALMEntrada = dtMOVALM.Rows(0)("CAlmacenD")
            sTipo = dtMOVALM.Rows(0)("CTipo")
            sMotivo = dtMOVALM.Rows(0)("Motivo")
            sSolicita = dtMOVALM.Rows(0)("Solicita")
            sNota = dtMOVALM.Rows(0)("Notas")
            usuRealiza = dtMOVALM.Rows(0)("CRegistro")
            usuAutoriza = dtMOVALM.Rows(0)("CAutorizo")
            dtMOVALM.Dispose()
        End If


        Tickets.AddHeaderLine("TRASPASO DE MERCANCIA", Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Centrado)
        Tickets.AddHeaderLine("FOLIO: " & sFolio, Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Centrado)
        Tickets.AddHeaderLine("SALIDA DE: " & sALMSalida, Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Izquierda)
        Tickets.AddHeaderLine("ENTRADA A: " & sALMEntrada, Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Izquierda)

        Tickets.AddHeaderLine("TIPO: " & sTipo, Imprimir.FontEstilo.Regular, Imprimir.Alinear.Izquierda)
        Tickets.AddHeaderLine("MOTIVO: " & sMotivo, Imprimir.FontEstilo.Regular, Imprimir.Alinear.Izquierda)
        Tickets.AddHeaderLine("SOLICITA: " & sSolicita, Imprimir.FontEstilo.Regular, Imprimir.Alinear.Izquierda)

        Tickets.AddHeaderLine("NOTA: " & sNota, Imprimir.FontEstilo.Regular, Imprimir.Alinear.Izquierda)

        Tickets.AddHeaderLine("ESTATUS: " & sEstatus, Imprimir.FontEstilo.Regular, Imprimir.Alinear.Izquierda)
        
        'El metodo AddSubHeaderLine es lo mismo al de AddHeaderLine con la diferencia 
        'de que al final de cada linea agrega una linea punteada "==========" 
        Tickets.AddHeaderLine("REALIZA: " & usuRealiza, 0, 1)
        Tickets.AddHeaderLine("AUTORIZA: " & usuAutoriza, 0, 1)
        Tickets.AddSubHeaderLine("FECHA: " & DateTime.Now.ToShortDateString() & " " & DateTime.Now.ToShortTimeString(), 0, 1)


        Dim dtMOVALMDetalle As DataTable
        dtMOVALMDetalle = ModPOS.SiExisteRecupera("sp_detalle_transferencia", "@MVAClave", sMVAClave)

        lineasImpresas += (dtMOVALMDetalle.Rows.Count * 2)
        Dim dTotalTransferencia As Double = 0
        If Not dtMOVALMDetalle Is Nothing AndAlso dtMOVALMDetalle.Rows.Count > 0 Then
            Dim i As Integer = 0
            For i = 0 To dtMOVALMDetalle.Rows.Count() - 1
                Dim sGTIN As String = dtMOVALMDetalle.Rows(i)("Clave")
                Dim sUnidad As String = dtMOVALMDetalle.Rows(i)("Unidad")
                Dim sNombre As String = dtMOVALMDetalle.Rows(i)("Nombre")
                Dim dCantidad As Double = dtMOVALMDetalle.Rows(i)("Cantidad")
                Dim dCosto As Double = dtMOVALMDetalle.Rows(i)("Costo")
                Dim dCostoTotal As Double = dtMOVALMDetalle.Rows(i)("Total")
                dTotalTransferencia += dCostoTotal
                ' AGREGAR PAGOS A LISTA
                Tickets.AddItemTransferencia(sGTIN, sNombre, dCantidad, dCosto, dCostoTotal)
            Next
            dtMOVALMDetalle.Dispose()
        End If
        lineasImpresas += 1
        Tickets.AddTotalTicket(dTotalTransferencia, Imprimir.FontEstilo.Negrita)

        Tickets.AddFooterLine("", 0, 1)
        Tickets.AddFooterLine("", 0, 1)
        Tickets.AddFooterLine("_______________", 0, 3)
        Tickets.AddFooterLine("ENTREGO", 0, 3)
        Tickets.AddFooterLine("", 0, 1)
        Tickets.AddFooterLine("", 0, 1)
        Tickets.AddFooterLine("_______________", 0, 3)
        Tickets.AddFooterLine("RECIBIO", 0, 3)

        Tickets.PrintTicket(Impresora, 28, lineasImpresas)

    End Sub

    Public Sub imprimirReporteTransferencia(ByVal MVAClave As String)
        Dim OpenReport As New Report
        Dim pvtaDataSet As New DataSet
        pvtaDataSet.DataSetName = "pvtaDataSet"
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_transferencia", "@MVAClave", MVAClave))
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_detalle_transferencia", "@MVAClave", MVAClave))
        OpenReport.PrintPreview("Transferencia de Almacén", "CRTransferencia.rpt", pvtaDataSet, "")
    End Sub


    Public Sub imprimirReporteDevCompra(ByVal DEVClave As String)
        Dim OpenReport As New Report
        Dim pvtaDataSet As New DataSet
        pvtaDataSet.DataSetName = "pvtaDataSet"
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_rep_devcompra", "@DEVClave", DEVClave))
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_detalle_devcompra", "@DEVClave", DEVClave))
        OpenReport.PrintPreview("Devolución de Compra", "CRDevCompra.rpt", pvtaDataSet, "")
    End Sub

    Public Sub previewCfdiPago(ByVal ABNClave As String, ByVal sTipo As String)
        Dim OpenReport As New Report
        Dim pvtaDataSet As New DataSet
        pvtaDataSet.DataSetName = "pvtaDataSet"
        Dim MonRef, MonDesc As String
        Dim TipoCambio, Total As Double
        Dim dt As DataTable

        If sTipo <> "Aplicación" Then

            dt = Recupera_Tabla("sp_recupera_mondoc", "@Tipo", "P", "@Documento", ABNClave)
            TipoCambio = dt.Rows(0)("TipoCambio")
            MonRef = dt.Rows(0)("Referencia")
            MonDesc = dt.Rows(0)("Descripcion")
            Total = dt.Rows(0)("Importe")
            dt.Dispose()

            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_encabezado_abono", "@ABNClave", ABNClave))

            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_sello_pago", "@ABNClave", ABNClave))
        End If


        If sTipo = "Anticipo" OrElse sTipo = "2" Then
            'Anticipo
            Dim Base As Decimal = Math.Round(Total / 1.16, 2)
            Dim IVA As Decimal = Math.Round(Base * 0.16, 2)

            OpenReport.PrintPreview("Anticipo", "CRAnticipoCFDI.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal((Base + IVA) / TipoCambio, 2), MonDesc, MonRef).ToUpper)

        ElseIf sTipo = "Pago" OrElse sTipo = "1" Then
            'Pago
            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_recupera_relacionado", "@DOCClave", ABNClave, "@Tipo", "P"))
            OpenReport.PrintPreview("Pago", "CRPagoCFDI.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal(Total / TipoCambio, 2), MonDesc, MonRef).ToUpper)
        Else


            dt = Recupera_Tabla("sp_recupera_mondoc", "@Tipo", "A", "@Documento", ABNClave)
            TipoCambio = dt.Rows(0)("TipoCambio")
            MonRef = dt.Rows(0)("Referencia")
            MonDesc = dt.Rows(0)("Descripcion")
            Total = dt.Rows(0)("Importe")
            dt.Dispose()

            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_encabezado_aplicacion", "@ANTClave", ABNClave))

            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_sello_anticipo", "@ANTClave", ABNClave))

            Dim Base As Decimal = Math.Round(Total / 1.16, 2)
            Dim IVA As Decimal = Math.Round(Base * 0.16, 2)
            OpenReport.PrintPreview("Egreso", "CRAplicacionCFDI.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal((Base + IVA) / TipoCambio, 2), MonDesc, MonRef).ToUpper)

        End If

    End Sub


    Public Sub imprimirCfdiPago(ByVal ABNClave As String, ByVal sTipo As String, ByVal iCopias As Integer, ByVal sPrinter As String)
        Dim OpenReport As New Report
        Dim pvtaDataSet As New DataSet
        pvtaDataSet.DataSetName = "pvtaDataSet"
        Dim MonRef, MonDesc As String
        Dim TipoCambio, Total As Double
        Dim dt As DataTable



      
        If sTipo <> "Aplicación" Then

            dt = Recupera_Tabla("sp_recupera_mondoc", "@Tipo", "P", "@Documento", ABNClave)
            TipoCambio = dt.Rows(0)("TipoCambio")
            MonRef = dt.Rows(0)("Referencia")
            MonDesc = dt.Rows(0)("Descripcion")
            Total = dt.Rows(0)("Importe")
            dt.Dispose()

            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_encabezado_abono", "@ABNClave", ABNClave))

            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_sello_pago", "@ABNClave", ABNClave))
        End If


        If sTipo = "Anticipo" OrElse sTipo = "2" Then
            'Anticipo
            Dim Base As Decimal = Math.Round(Total / 1.16, 2)
            Dim IVA As Decimal = Math.Round(Base * 0.16, 2)

            OpenReport.Print(iCopias, "CRAnticipoCFDI.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal((Base + IVA) / TipoCambio, 2), MonDesc, MonRef).ToUpper, sPrinter)

        ElseIf sTipo = "Pago" OrElse sTipo = "1" Then
            'Pago
            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_recupera_relacionado", "@DOCClave", ABNClave, "@Tipo", "P"))
            OpenReport.Print(iCopias, "CRPagoCFDI.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal(Total / TipoCambio, 2), MonDesc, MonRef).ToUpper, sPrinter)
        Else


            dt = Recupera_Tabla("sp_recupera_mondoc", "@Tipo", "A", "@Documento", ABNClave)
            TipoCambio = dt.Rows(0)("TipoCambio")
            MonRef = dt.Rows(0)("Referencia")
            MonDesc = dt.Rows(0)("Descripcion")
            Total = dt.Rows(0)("Importe")
            dt.Dispose()

            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_encabezado_aplicacion", "@ANTClave", ABNClave))

            pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_sello_anticipo", "@ANTClave", ABNClave))

            Dim Base As Decimal = Math.Round(Total / 1.16, 2)
            Dim IVA As Decimal = Math.Round(Base * 0.16, 2)
            OpenReport.Print(iCopias, "CRAplicacionCFDI.rpt", pvtaDataSet, ModPOS.LetrasM(ModPOS.TruncateToDecimal((Base + IVA) / TipoCambio, 2), MonDesc, MonRef).ToUpper, sPrinter)

        End If

    End Sub


    Public Sub imprimirCfdiTraslado(ByVal TRSClave As String, ByVal iCopias As Integer, ByVal sPrinter As String)
        Dim OpenReport As New Report
        Dim pvtaDataSet As New DataSet
        pvtaDataSet.DataSetName = "pvtaDataSet"
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("st_encabezado_traslado", "@TRSClave", TRSClave))
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_detalle_traslado", "@TRSClave", TRSClave))
        OpenReport.Print(iCopias, "CRTrasladoCFDI.rpt", pvtaDataSet, "", sPrinter)

    End Sub

    Public Sub imprimirReporteTraslado(ByVal TRSClave As String, ByVal Preview As Boolean, Optional ByVal iCopias As Integer = 0, Optional ByVal sPrinter As String = "")
        Dim OpenReport As New Report
        Dim pvtaDataSet As New DataSet
        pvtaDataSet.DataSetName = "pvtaDataSet"
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_traslado", "@TRSClave", TRSClave))
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_detalle_traslado", "@TRSClave", TRSClave))
        If Preview = True Then
            OpenReport.PrintPreview("Traslado", "CRTraslado.rpt", pvtaDataSet, "")
        Else
            OpenReport.Print(iCopias, "CRTraslado.rpt", pvtaDataSet, "", sPrinter)
        End If
    End Sub

    Public Function recuperaValorRef(ByVal tabla As String, ByVal Campo As String, ByVal valor As Integer) As String
        Dim dt As DataTable

        dt = ModPOS.Recupera_Tabla("sp_recupera_valorref", "@estado", valor, "@tabla", tabla, "@campo", Campo)

        Return dt.Rows(0)("descripcion")

    End Function

    Public Function ValidaLicencia() As Boolean
        Dim CandadoActual As String

        Dim dtCompania As DataTable
        dtCompania = ModPOS.Recupera_Consulta("SELECT SERVERPROPERTY('ServerName')")

        Candado = ModPOS.encriptarSHA(dtCompania.Rows(0)(0)).Substring(0, 25)

        dtCompania.Dispose()

        dtCompania = ModPOS.Recupera_Tabla("sp_recupera_compania", "@COMClave", ModPOS.CompanyActual)
        CandadoActual = IIf(dtCompania.Rows(0)("Logo1") Is System.DBNull.Value, "", dtCompania.Rows(0)("Logo1"))

        Dim Llave As String

        Llave = IIf(dtCompania.Rows(0)("CodigoPostal1") Is System.DBNull.Value, "", dtCompania.Rows(0)("CodigoPostal1"))
        dtCompania.Dispose()

        If Candado = CandadoActual Then
            If Llave.Length = 9 AndAlso Llave = "395656927" Then
                Licencias = 1
                Return True
            ElseIf ModPOS.encriptarSHA(Candado).Substring(0, 10) = Llave.Substring(0, 10) Then
                If IsNumeric(ModPOS.DesEncripta(Llave.Substring(10, Llave.Length - 10))) Then
                    Licencias = CInt(ModPOS.DesEncripta(Llave.Substring(10, Llave.Length - 10)))
                    Return True
                Else
                    Dim a As New Licencia
                    a.ShowDialog()
                    If a.DialogResult = DialogResult.OK Then
                        Return a.Pass
                    Else
                        Return False
                    End If
                    a.Dispose()
                End If
            Else
                Dim a As New Licencia
                a.ShowDialog()
                If a.DialogResult = DialogResult.OK Then
                    Return a.Pass
                Else
                    Return False
                End If
                a.Dispose()
            End If

        Else

            Dim a As New Licencia
            a.ShowDialog()
            If a.DialogResult = DialogResult.OK Then
                Return a.Pass
            Else
                Return False
            End If
            a.Dispose()
        End If
    End Function

    Public Function GetProcessorId() As String
        Dim manClass As System.Management.ManagementClass = New System.Management.ManagementClass("Win32_Processor")
        Dim manObjCol As System.Management.ManagementObjectCollection = manClass.GetInstances()
        Dim ProcessorId As String = String.Empty
        Dim DiscoId As String = String.Empty

        Try
            For Each manObj As System.Management.ManagementObject In manObjCol
                If Not manObj.Properties("ProcessorId").Value Is Nothing Then
                    ProcessorId = manObj.Properties("ProcessorId").Value.ToString()
                End If
            Next
        Catch e As Management.ManagementException
            ProcessorId = "ERR"
        End Try

        DiscoId = ModPOS.SerialNumber

        If ProcessorId = "" Then
            ProcessorId = "NR"
        End If

        Return ProcessorId & "-" & DiscoId.Trim

    End Function


    Public Function obtenerLlave() As String
        Dim dt As DataTable
        Dim Llave As String

        dt = Recupera_Tabla("sp_obtenerLlave")
        If dt Is Nothing Then
            Llave = ""
        Else
            Llave = dt.Rows(0)("Llave")
            dt.Dispose()
        End If
        Return Llave
    End Function

    Public Sub ActualizaExistAlm(ByVal TipoMov As Integer, ByVal TipoDoc As Integer, ByVal Documento As String, ByVal Almacen As String)
        ModPOS.Ejecuta("sp_actualiza_existencia", "@TipoMov", TipoMov, "@TipoDoc", TipoDoc, "@Documento", Documento, "@ALMClave", Almacen)
        ModPOS.Ejecuta("sp_actualiza_existencia_cont", "@TipoMov", TipoMov, "@TipoDoc", TipoDoc, "@Documento", Documento, "@ALMClave", Almacen)
    End Sub


    Public Sub ActualizaExistUbcProducto(ByVal TipoMov As Integer, ByVal TProducto As Integer, ByVal PROClave As String, ByVal Cantidad As Double, ByVal Almacen As String)
        If TProducto <= 2 Then
            Dim x As Integer

            For x = 1 To CInt(Math.Abs(Cantidad))
                ModPOS.Ejecuta("sp_actualiza_existuba", "Tipo", TipoMov, "@ALMClave", Almacen, "@PROClave", PROClave)
            Next

            If Math.Abs(Cantidad) > CInt(Math.Abs(Cantidad)) Then
                ModPOS.Ejecuta("sp_actualiza_existuba_dec", "Tipo", TipoMov, "@ALMClave", Almacen, "@PROClave", PROClave, "@Cantidad", Math.Abs(Cantidad) - CInt(Math.Abs(Cantidad)))
            End If

        ElseIf TProducto = 3 Then

            Dim x, fila As Integer
            Dim dtContenido As DataTable


            dtContenido = ModPOS.SiExisteRecupera("sp_recupera_contenido", "@PROClave", PROClave, "@Cantidad", Cantidad)
            If Not dtContenido Is Nothing Then
                For fila = 0 To dtContenido.Rows.Count - 1
                    For x = 1 To CInt(Math.Abs(dtContenido.Rows(fila)("Cantidad")))
                        ModPOS.Ejecuta("sp_actualiza_existuba", "Tipo", TipoMov, "@ALMClave", Almacen, "@PROClave", dtContenido.Rows(fila)("PROClave"))
                    Next

                    If Math.Abs(dtContenido.Rows(fila)("Cantidad")) > CInt(Math.Abs(dtContenido.Rows(fila)("Cantidad"))) Then
                        ModPOS.Ejecuta("sp_actualiza_existuba_dec", "Tipo", TipoMov, "@ALMClave", Almacen, "@PROClave", dtContenido.Rows(fila)("PROClave"), "@Cantidad", Math.Abs(dtContenido.Rows(fila)("Cantidad")) - CInt(Math.Abs(dtContenido.Rows(fila)("Cantidad"))))
                    End If
                Next
            End If

        End If

    End Sub

    Public Function ValidaEnvio(ByVal Picking As Boolean, ByVal VENClave As String, ByVal CTEClaveActual As String, ByVal VentaCerrada As Boolean, ByVal ALMClave As String, ByVal Tipo As String) As Boolean
        If Picking = True Then
            Dim dt As DataTable
            dt = ModPOS.Recupera_Tabla("sp_recupera_envio", "@VENClave", VENClave)

            If dt.Rows.Count = 0 Then
                'Inicio

                Dim a As New FrmEnvio
                a.Tipo = Tipo
                a.VENClave = VENClave
                a.CTEClave = CTEClaveActual
                a.VentaCerrada = VentaCerrada
                a.ALMClave = ALMClave
                a.StartPosition = FormStartPosition.CenterScreen
                a.ShowDialog()

                If a.DialogResult <> DialogResult.OK Then
                    a.Dispose()
                    MessageBox.Show("!Debe completar los datos de Entrega¡", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    dt.Dispose()
                    Return False
                Else
                    a.Dispose()
                    dt.Dispose()
                    Return True
                End If
            Else
                Dim sDCTEClave As String = dt.Rows(0)("DCTEClave")
                dt.Dispose()

                dt = Recupera_Tabla("st_valida_envio", "@CTEClave", CTEClaveActual, "@DCTEClave", sDCTEClave)
                If dt.Rows.Count = 0 Then
                    dt.Dispose()
                    MessageBox.Show("!Destinatario no corresponde al cliente seleccionado¡", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    ModPOS.Ejecuta("st_elimina_envio", "@VENClave", VENClave)
                    Return False
                Else
                    dt.Dispose()
                    Return True
                End If
            End If
        Else
            Return True
        End If
    End Function

    Public Function VerificaExistencia(ByVal TipoDocumento As Integer, ByVal DOCClave As String, ByVal ALMClave As String) As Boolean
        Dim i, x As Integer
        Dim foundRows() As DataRow
        Dim dtDetalle, dtUbicacion As DataTable
        Dim Ubicacion As String = ""

        dtDetalle = Nothing

        If TipoDocumento = 1 Then
            dtDetalle = ModPOS.Recupera_Tabla("sp_ventadetalle_open", "@VENClave", DOCClave)
        ElseIf TipoDocumento = 6 Then
            dtDetalle = ModPOS.Recupera_Tabla("sp_detalle_transferencia", "@MVAClave", DOCClave)
        ElseIf TipoDocumento = 8 Then
            dtDetalle = ModPOS.Recupera_Tabla("sp_detalle_traslado", "@TRSClave", DOCClave)
        ElseIf TipoDocumento = 10 Then
            dtDetalle = ModPOS.Recupera_Tabla("st_detalle_devcompra", "@DEVClave", DOCClave)

        End If

        If dtDetalle.Rows.Count > 0 Then

            Dim dTotalProducto As Double = dtDetalle.Compute(" SUM(Cantidad)", "")

           
            foundRows = dtDetalle.Select("TProducto <= 3")
            If foundRows.GetLength(0) > 0 Then
                For i = 0 To foundRows.GetUpperBound(0)

                    Dim Cantidad As Double = foundRows(i)("Cantidad")

                    'Busca existencia en un Stage
                    dtUbicacion = ModPOS.Recupera_Tabla("sp_obtener_exist_uba", "@ALMClave", ALMClave, "@PROClave", foundRows(i)("PROClave"), "@TESTClave", 2)
                    If dtUbicacion.Rows.Count > 0 Then
                        For x = 0 To dtUbicacion.Rows.Count - 1
                            If dtUbicacion.Rows(x)("Existencia") >= Cantidad AndAlso Cantidad > 0 Then
                                Cantidad = 0
                                Exit For
                            ElseIf Cantidad > 0 Then
                                Cantidad -= dtUbicacion.Rows(x)("Existencia")
                            End If
                        Next
                    End If

                    'Busca en la ubicación de Picking que se asigno al producto
                    If Cantidad > 0 Then
                        dtUbicacion = ModPOS.Recupera_Tabla("sp_obtener_estrategia", "@ALMClave", ALMClave, "@PROClave", foundRows(i)("PROClave"))
                        If dtUbicacion.Rows.Count > 0 Then
                            If dtUbicacion.Rows(0)("Existencia") >= Cantidad Then
                                Cantidad = 0
                            Else
                                Cantidad -= dtUbicacion.Rows(0)("Existencia")
                            End If
                        End If
                    End If

                    'Se busca en cualquier ubicacion de almacenaje
                    If Cantidad > 0 Then
                        dtUbicacion = ModPOS.Recupera_Tabla("sp_obtener_exist_uba", "@ALMClave", ALMClave, "@PROClave", foundRows(i)("PROClave"), "@TESTClave", 1)
                        If dtUbicacion.Rows.Count > 0 Then
                            For x = 0 To dtUbicacion.Rows.Count - 1
                                If dtUbicacion.Rows(x)("Existencia") >= Cantidad AndAlso Cantidad > 0 Then
                                    Cantidad = 0
                                    Exit For
                                ElseIf Cantidad > 0 Then
                                    Cantidad -= dtUbicacion.Rows(x)("Existencia")
                                End If
                            Next
                        End If
                    End If

                    If Cantidad > 0 Then
                        Dim dt As DataTable
                        dt = ModPOS.Recupera_Tabla("sp_recupera_producto", "@PROClave", foundRows(i)("PROClave"))
                        MessageBox.Show("El producto: " & CStr(dt.Rows(0)("Clave")) & ", no cuenta con existencia disponible o se encuentra bloqueada. Quita la cantidad de " & CStr(Cantidad) & " pieza(s) de este pedido para continuar.")
                        dt.Dispose()
                        Return False
                    End If
                Next
            End If
        End If
        Return True
    End Function

    Public Sub calculaRecoleccion(ByVal TipoDocumento As Integer, ByVal DOCClave As String, ByVal ALMClave As String, ByVal Stage As String, ByVal RF As Integer)
        Dim i, x As Integer
        Dim foundRows() As DataRow
        Dim dt, dtDetalle, dtUbicacion As DataTable
        Dim TipoSurtido As Integer = 1

        dt = ModPOS.Recupera_Tabla("sp_recupera_alm", "@ALMClave", ALMClave)
        TipoSurtido = IIf(dt.Rows(0)("TipoSurtido").GetType.Name = "DBNull", 1, dt.Rows(0)("TipoSurtido"))
        dt.Dispose()

        dtDetalle = Nothing

        If TipoDocumento = 1 Then
            dtDetalle = ModPOS.Recupera_Tabla("sp_recupera_VentaDet", "@VENClave", DOCClave)
            If Stage = "" Then
                dt = ModPOS.Recupera_Tabla("st_recupera_envio", "@VENClave", DOCClave)
                Stage = dt.Rows(0)("UBCClave")
                dt.Dispose()
            End If
        ElseIf TipoDocumento = 6 Then
            dtDetalle = ModPOS.Recupera_Tabla("st_surtido_transferencia", "@MVAClave", DOCClave)
        ElseIf TipoDocumento = 8 Then
            dtDetalle = ModPOS.Recupera_Tabla("st_surtido_traslado", "@TRSClave", DOCClave)
        ElseIf TipoDocumento = 10 Then
            dtDetalle = ModPOS.Recupera_Tabla("st_surtido_devcompra", "@DEVClave", DOCClave)

        End If

        If dtDetalle.Rows.Count > 0 Then

            Dim dTotalProducto As Double = dtDetalle.Compute(" SUM(Cantidad)", "")

            ModPOS.Ejecuta("st_agrega_surtido", "@TipoDocumento", TipoDocumento, "@DOCClave", DOCClave, "@Total", dTotalProducto, "@Stage", Stage, "@Usuario", ModPOS.UsuarioActual)

            If TipoDocumento <> 1 Then
                ModPOS.Ejecuta("st_act_tipo_surtido", "@Tipo", TipoDocumento, "@DOCClave", DOCClave, "@SurtidoRF", RF)
            End If

            foundRows = dtDetalle.Select("TProducto <= 3")
            If foundRows.GetLength(0) > 0 Then
                For i = 0 To foundRows.GetUpperBound(0)

                    Dim Cantidad As Double = foundRows(i)("Cantidad")

                    'Busca existencia en un Stage
                    dtUbicacion = ModPOS.Recupera_Tabla("sp_obtener_exist_uba", "@ALMClave", ALMClave, "@PROClave", foundRows(i)("PROClave"), "@TESTClave", 2)
                    If dtUbicacion.Rows.Count > 0 Then
                        For x = 0 To dtUbicacion.Rows.Count - 1
                            If dtUbicacion.Rows(x)("Existencia") >= Cantidad AndAlso Cantidad > 0 Then
                                ModPOS.Ejecuta("sp_inserta_surtidodetalle", "@TipoDocumento", TipoDocumento, "@DOCClave", DOCClave, "@UBCClave", dtUbicacion.Rows(x)("UBCClave"), "@PROClave", foundRows(i)("PROClave"), "@TProducto", foundRows(i)("TProducto"), "@Cantidad", Cantidad, "@Usuario", ModPOS.UsuarioActual)
                                Cantidad = 0
                                Exit For
                            ElseIf Cantidad > 0 Then
                                Cantidad -= dtUbicacion.Rows(x)("Existencia")
                                ModPOS.Ejecuta("sp_inserta_surtidodetalle", "@TipoDocumento", TipoDocumento, "@DOCClave", DOCClave, "@UBCClave", dtUbicacion.Rows(x)("UBCClave"), "@PROClave", foundRows(i)("PROClave"), "@TProducto", foundRows(i)("TProducto"), "@Cantidad", dtUbicacion.Rows(x)("Existencia"), "@Usuario", ModPOS.UsuarioActual)
                            End If
                        Next
                    End If

                    If TipoSurtido = 1 Then
                        'Busca en la ubicación de Picking que se asigno al producto
                        If Cantidad > 0 Then
                            dtUbicacion = ModPOS.Recupera_Tabla("sp_obtener_estrategia", "@ALMClave", ALMClave, "@PROClave", foundRows(i)("PROClave"))
                            If dtUbicacion.Rows.Count > 0 Then
                                If dtUbicacion.Rows(0)("Existencia") >= Cantidad Then
                                    ModPOS.Ejecuta("sp_inserta_surtidodetalle", "@TipoDocumento", TipoDocumento, "@DOCClave", DOCClave, "@UBCClave", dtUbicacion.Rows(0)("UBCClave"), "@PROClave", foundRows(i)("PROClave"), "@TProducto", foundRows(i)("TProducto"), "@Cantidad", Cantidad, "@Usuario", ModPOS.UsuarioActual)
                                    Cantidad = 0
                                Else
                                    Cantidad -= dtUbicacion.Rows(0)("Existencia")
                                    ModPOS.Ejecuta("sp_inserta_surtidodetalle", "@TipoDocumento", TipoDocumento, "@DOCClave", DOCClave, "@UBCClave", dtUbicacion.Rows(0)("UBCClave"), "@PROClave", foundRows(i)("PROClave"), "@TProducto", foundRows(i)("TProducto"), "@Cantidad", dtUbicacion.Rows(0)("Existencia"), "@Usuario", ModPOS.UsuarioActual)
                                End If
                            End If
                        End If

                        'Se busca en cualquier ubicacion de almacenaje
                        If Cantidad > 0 Then
                            dtUbicacion = ModPOS.Recupera_Tabla("sp_obtener_exist_uba", "@ALMClave", ALMClave, "@PROClave", foundRows(i)("PROClave"), "@TESTClave", 1)
                            If dtUbicacion.Rows.Count > 0 Then
                                For x = 0 To dtUbicacion.Rows.Count - 1
                                    If dtUbicacion.Rows(x)("Existencia") >= Cantidad AndAlso Cantidad > 0 Then
                                        ModPOS.Ejecuta("sp_inserta_surtidodetalle", "@TipoDocumento", TipoDocumento, "@DOCClave", DOCClave, "@UBCClave", dtUbicacion.Rows(x)("UBCClave"), "@PROClave", foundRows(i)("PROClave"), "@TProducto", foundRows(i)("TProducto"), "@Cantidad", Cantidad, "@Usuario", ModPOS.UsuarioActual)
                                        Cantidad = 0
                                        Exit For
                                    ElseIf Cantidad > 0 Then
                                        Cantidad -= dtUbicacion.Rows(x)("Existencia")
                                        ModPOS.Ejecuta("sp_inserta_surtidodetalle", "@TipoDocumento", TipoDocumento, "@DOCClave", DOCClave, "@UBCClave", dtUbicacion.Rows(x)("UBCClave"), "@PROClave", foundRows(i)("PROClave"), "@TProducto", foundRows(i)("TProducto"), "@Cantidad", dtUbicacion.Rows(x)("Existencia"), "@Usuario", ModPOS.UsuarioActual)
                                    End If
                                Next
                            End If
                        End If
                    Else
                        'Se busca en cualquier ubicacion de almacenaje
                        If Cantidad > 0 Then
                            dtUbicacion = ModPOS.Recupera_Tabla("st_obtener_almacenaje", "@ALMClave", ALMClave, "@PROClave", foundRows(i)("PROClave"))
                            If dtUbicacion.Rows.Count > 0 Then
                                For x = 0 To dtUbicacion.Rows.Count - 1
                                    If dtUbicacion.Rows(x)("Existencia") >= Cantidad AndAlso Cantidad > 0 Then
                                        ModPOS.Ejecuta("sp_inserta_surtidodetalle", "@TipoDocumento", TipoDocumento, "@DOCClave", DOCClave, "@UBCClave", dtUbicacion.Rows(x)("UBCClave"), "@PROClave", foundRows(i)("PROClave"), "@TProducto", foundRows(i)("TProducto"), "@Cantidad", Cantidad, "@Usuario", ModPOS.UsuarioActual)
                                        Cantidad = 0
                                        Exit For
                                    ElseIf Cantidad > 0 Then
                                        Cantidad -= dtUbicacion.Rows(x)("Existencia")
                                        ModPOS.Ejecuta("sp_inserta_surtidodetalle", "@TipoDocumento", TipoDocumento, "@DOCClave", DOCClave, "@UBCClave", dtUbicacion.Rows(x)("UBCClave"), "@PROClave", foundRows(i)("PROClave"), "@TProducto", foundRows(i)("TProducto"), "@Cantidad", dtUbicacion.Rows(x)("Existencia"), "@Usuario", ModPOS.UsuarioActual)
                                    End If
                                Next
                            End If
                        End If

                        'Busca en la ubicación de Picking que se asigno al producto
                        If Cantidad > 0 Then
                            dtUbicacion = ModPOS.Recupera_Tabla("sp_obtener_estrategia", "@ALMClave", ALMClave, "@PROClave", foundRows(i)("PROClave"))
                            If dtUbicacion.Rows.Count > 0 Then
                                If dtUbicacion.Rows(0)("Existencia") >= Cantidad Then
                                    ModPOS.Ejecuta("sp_inserta_surtidodetalle", "@TipoDocumento", TipoDocumento, "@DOCClave", DOCClave, "@UBCClave", dtUbicacion.Rows(0)("UBCClave"), "@PROClave", foundRows(i)("PROClave"), "@TProducto", foundRows(i)("TProducto"), "@Cantidad", Cantidad, "@Usuario", ModPOS.UsuarioActual)
                                    Cantidad = 0
                                Else
                                    Cantidad -= dtUbicacion.Rows(0)("Existencia")
                                    ModPOS.Ejecuta("sp_inserta_surtidodetalle", "@TipoDocumento", TipoDocumento, "@DOCClave", DOCClave, "@UBCClave", dtUbicacion.Rows(0)("UBCClave"), "@PROClave", foundRows(i)("PROClave"), "@TProducto", foundRows(i)("TProducto"), "@Cantidad", dtUbicacion.Rows(0)("Existencia"), "@Usuario", ModPOS.UsuarioActual)
                                End If
                            End If
                        End If


                    End If


                Next
            End If


        End If
    End Sub

    Public Function ActualizaExistUbc(ByVal TipoMov As Integer, ByVal TipoDoc As Integer, ByVal Documento As String, ByVal Almacen As String, Optional ByVal Ubicacion As String = Nothing) As Integer

        'TipoDOc 1: Venta, 2:Factura, 3:Devolución,4:Nota Credito, 5:Compra, 6:Transferencia, 7:Ingreso
        'TipoMov 1: Entrada , 2: Salida

        Dim dtDetalle As DataTable = Nothing

        Select Case TipoDoc
            Case Is = 1
                dtDetalle = ModPOS.SiExisteRecupera("sp_ventadetalle_apartado", "@VENClave", Documento)
            Case Is = 2
                dtDetalle = ModPOS.SiExisteRecupera("sp_detalle_fac", "@FACClave", Documento)
            Case Is = 3
                dtDetalle = ModPOS.SiExisteRecupera("sp_detalle_devolucion", "@DEVClave", Documento)
            Case Is = 4
                dtDetalle = ModPOS.SiExisteRecupera("sp_detalle_notacredito", "@NCClave", Documento)
            Case Is = 5
                dtDetalle = ModPOS.SiExisteRecupera("sp_compra_detalle", "@COMClave", Documento)
            Case Is = 6
                dtDetalle = ModPOS.SiExisteRecupera("sp_detalle_transferencia", "@MVAClave", Documento)
            Case Is = 7
                dtDetalle = ModPOS.SiExisteRecupera("sp_detalle_ingreso", "@INGClave", Documento)
            Case Is = 8
                dtDetalle = ModPOS.SiExisteRecupera("sp_detalle_traslado", "@TRSClave", Documento)
            Case Is = 9
                dtDetalle = ModPOS.SiExisteRecupera("sp_recibo_detalle_ra", "@IdRecibo", Documento)

        End Select

        If Ubicacion Is Nothing Then
            Dim dt As DataTable = ModPOS.Recupera_Tabla("st_recupera_ubicaciones", "@ALMClave", Almacen)
            If dt.Rows.Count = 1 Then
                Ubicacion = dt.Rows(0)("UBCClave")
            End If
            dt.Dispose()
        End If

        If Not dtDetalle Is Nothing Then
            Dim foundRows() As DataRow
            foundRows = dtDetalle.Select("TProducto <= 2")
            If foundRows.GetLength(0) > 0 Then
                Dim i, x As Integer
                Dim sProducto As String
                Dim dCantidad As Double

                For i = 0 To foundRows.GetUpperBound(0)
                    ' For i = 0 To numArt - 1
                    sProducto = foundRows(i)("PROClave")
                    dCantidad = foundRows(i)("Cantidad")

                    If TipoDoc = 7 Then
                        Ubicacion = foundRows(i)("UBCClave")
                    End If
                    For x = 1 To CInt(Math.Abs(dCantidad))
                        ModPOS.Ejecuta("sp_actualiza_existuba", "Tipo", TipoMov, "@ALMClave", Almacen, "@PROClave", sProducto, "@Ubicacion", Ubicacion)
                    Next

                    If Math.Abs(dCantidad) > CInt(Math.Abs(dCantidad)) Then
                        ModPOS.Ejecuta("sp_actualiza_existuba_dec", "Tipo", TipoMov, "@ALMClave", Almacen, "@PROClave", sProducto, "@Cantidad", Math.Abs(dCantidad) - CInt(Math.Abs(dCantidad)), "@Ubicacion", Ubicacion)
                    End If

                Next
            End If


            foundRows = dtDetalle.Select("TProducto = 3")
            If foundRows.GetLength(0) > 0 Then
                Dim i, x, fila As Integer
                Dim dtContenido As DataTable

                For i = 0 To foundRows.GetUpperBound(0)
                    dtContenido = ModPOS.SiExisteRecupera("sp_recupera_contenido", "@PROClave", foundRows(i)("PROClave"), "@Cantidad", foundRows(i)("Cantidad"))
                    If Not dtContenido Is Nothing Then
                        For fila = 0 To dtContenido.Rows.Count - 1
                            For x = 1 To CInt(Math.Abs(dtContenido.Rows(fila)("Cantidad")))
                                ModPOS.Ejecuta("sp_actualiza_existuba", "Tipo", TipoMov, "@ALMClave", Almacen, "@PROClave", dtContenido.Rows(fila)("PROClave"), "@Ubicacion", Ubicacion)
                            Next

                            If Math.Abs(dtContenido.Rows(fila)("Cantidad")) > CInt(Math.Abs(dtContenido.Rows(fila)("Cantidad"))) Then
                                ModPOS.Ejecuta("sp_actualiza_existuba_dec", "Tipo", TipoMov, "@ALMClave", Almacen, "@PROClave", dtContenido.Rows(fila)("PROClave"), "@Cantidad", Math.Abs(dtContenido.Rows(fila)("Cantidad")) - CInt(Math.Abs(dtContenido.Rows(fila)("Cantidad"))), "@Ubicacion", Ubicacion)
                            End If
                        Next
                    End If
                Next
            End If
            dtDetalle.Dispose()
        End If
        Return 1
    End Function

    Public Sub GeneraMovInv(ByVal TipoMov As Integer, ByVal Motivo As Integer, ByVal TipoDoc As Integer, ByVal Documento As String, ByVal Almacen As String, ByVal Referencia As String, ByVal Autorizo As String)
        ModPOS.Ejecuta("sp_genera_movimiento", "@TipoMov", TipoMov, "@Motivo", Motivo, "@ALMClave", Almacen, "@Documento", Documento, "@TipoDoc", TipoDoc, "@Referencia", Referencia, "@Autorizo", Autorizo, "@Usuario", ModPOS.UsuarioActual)
        ModPOS.Ejecuta("sp_genera_movimiento_cont", "@TipoMov", TipoMov, "@Motivo", Motivo, "@ALMClave", Almacen, "@Documento", Documento, "@TipoDoc", TipoDoc, "@Referencia", Referencia, "@Autorizo", Autorizo, "@Usuario", ModPOS.UsuarioActual)
    End Sub

    Public Function QuitarCeros(ByVal num As Double, Optional ByVal num_dec As Integer = 0) As String
        Dim n As String
        n = CStr(Redondear(num, 6))

        If num_dec = 2 Then
            If n.Split(".").Length = 1 Then
                n &= ".00"
            ElseIf n.Split(".").Length = 2 Then
                If n.Split(".")(1).Length = 1 Then
                    n &= "0"
                End If
            End If
        ElseIf num_dec = 6 Then
            If n.Split(".").Length = 1 Then
                n &= ".000000"
            ElseIf n.Split(".").Length = 2 Then
                If n.Split(".")(1).Length <> 6 Then
                    Dim str As String = "0000000"

                    n &= str.Substring(0, 6 - n.Split(".")(1).Length)
                End If
            End If
        ElseIf num_dec = 3 Then
            If n.Split(".").Length = 1 Then
                n &= ".000"
            ElseIf n.Split(".").Length = 2 Then
                If n.Split(".")(1).Length <> 3 Then
                    Dim str As String = "000"

                    n &= str.Substring(0, 3 - n.Split(".")(1).Length)
                End If
            End If
        Else
            If CDbl(n) > 0 AndAlso n.IndexOf(".") > -1 Then
                If Mid(n, n.Length, 1) = "0" Then
                    Dim i As Integer
                    For i = n.Length To 0 Step -1
                        n = Mid(n, 1, i - 1)
                        If Mid(n, n.Length, 1) <> "0" Then
                            Exit For
                        End If
                    Next
                End If
            End If

            If Mid(n, n.Length, 1) = "." Then
                n = Mid(n, 1, n.Length - 1)
            End If

        End If


        Return n
    End Function

    Public Function IsVocal(ByVal s As String) As Boolean
        Dim c As String
        c = Mid(s, s.Length, 1)

        If Not InStr(1, "aeiouAEIOU", c) = 0 Then
            Return True
        Else
            Return False
        End If
    End Function



    Public Function Letras(ByVal numero As String) As String
        '********Declara variables de tipo cadena************
        Dim palabras As String = ""
        Dim centavos As String = ""
        Dim entero As String = ""
        Dim dec As String = ""
        Dim flag As String = ""

        '********Declara variables de tipo entero***********
        Dim num, x, y As Integer

        flag = "N"

        '**********Número Negativo***********
        If Mid(numero, 1, 1) = "-" Then
            numero = Mid(numero, 2, numero.ToString.Length - 1).ToString
            palabras = "menos "
        End If

        '**********Si tiene ceros a la izquierda*************
        For x = 1 To numero.ToString.Length
            If Mid(numero, 1, 1) = "0" Then
                numero = Trim(Mid(numero, 2, numero.ToString.Length).ToString)
                If Trim(numero.ToString.Length) = 0 Then palabras = ""
            Else
                Exit For
            End If
        Next

        '*********Dividir parte entera y decimal************
        For y = 1 To Len(numero)
            If Mid(numero, y, 1) = "." Then
                flag = "S"
            Else
                If flag = "N" Then
                    entero = entero + Mid(numero, y, 1)
                Else
                    dec = dec + Mid(numero, y, 1)
                End If
            End If
        Next y

        If Len(dec) = 1 Then dec = dec & "0"

        '**********proceso de conversión***********
        flag = "N"

        If Val(numero) <= 999999999 Then
            For y = Len(entero) To 1 Step -1
                num = Len(entero) - (y - 1)
                Select Case y
                    Case 3, 6, 9
                        '**********Asigna las palabras para las centenas***********
                        Select Case Mid(entero, num, 1)
                            Case "1"
                                If Mid(entero, num + 1, 1) = "0" And Mid(entero, num + 2, 1) = "0" Then
                                    palabras = palabras & "cien "
                                Else
                                    palabras = palabras & "ciento "
                                End If
                            Case "2"
                                palabras = palabras & "doscientos "
                            Case "3"
                                palabras = palabras & "trescientos "
                            Case "4"
                                palabras = palabras & "cuatrocientos "
                            Case "5"
                                palabras = palabras & "quinientos "
                            Case "6"
                                palabras = palabras & "seiscientos "
                            Case "7"
                                palabras = palabras & "setecientos "
                            Case "8"
                                palabras = palabras & "ochocientos "
                            Case "9"
                                palabras = palabras & "novecientos "
                        End Select
                    Case 2, 5, 8
                        '*********Asigna las palabras para las decenas************
                        Select Case Mid(entero, num, 1)
                            Case "1"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    flag = "S"
                                    palabras = palabras & "diez "
                                End If
                                If Mid(entero, num + 1, 1) = "1" Then
                                    flag = "S"
                                    palabras = palabras & "once "
                                End If
                                If Mid(entero, num + 1, 1) = "2" Then
                                    flag = "S"
                                    palabras = palabras & "doce "
                                End If
                                If Mid(entero, num + 1, 1) = "3" Then
                                    flag = "S"
                                    palabras = palabras & "trece "
                                End If
                                If Mid(entero, num + 1, 1) = "4" Then
                                    flag = "S"
                                    palabras = palabras & "catorce "
                                End If
                                If Mid(entero, num + 1, 1) = "5" Then
                                    flag = "S"
                                    palabras = palabras & "quince "
                                End If
                                If Mid(entero, num + 1, 1) > "5" Then
                                    flag = "N"
                                    palabras = palabras & "dieci"
                                End If
                            Case "2"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "veinte "
                                    flag = "S"
                                Else
                                    palabras = palabras & "veinti"
                                    flag = "N"
                                End If
                            Case "3"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "treinta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "treinta y "
                                    flag = "N"
                                End If
                            Case "4"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "cuarenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "cuarenta y "
                                    flag = "N"
                                End If
                            Case "5"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "cincuenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "cincuenta y "
                                    flag = "N"
                                End If
                            Case "6"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "sesenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "sesenta y "
                                    flag = "N"
                                End If
                            Case "7"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "setenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "setenta y "
                                    flag = "N"
                                End If
                            Case "8"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "ochenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "ochenta y "
                                    flag = "N"
                                End If
                            Case "9"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "noventa "
                                    flag = "S"
                                Else
                                    palabras = palabras & "noventa y "
                                    flag = "N"
                                End If
                        End Select
                    Case 1, 4, 7
                        '*********Asigna las palabras para las unidades*********
                        Select Case Mid(entero, num, 1)
                            Case "1"
                                If flag = "N" Then
                                    If y = 1 Then
                                        palabras = palabras & "uno "
                                    Else
                                        palabras = palabras & "un "
                                    End If
                                End If
                            Case "2"
                                If flag = "N" Then palabras = palabras & "dos "
                            Case "3"
                                If flag = "N" Then palabras = palabras & "tres "
                            Case "4"
                                If flag = "N" Then palabras = palabras & "cuatro "
                            Case "5"
                                If flag = "N" Then palabras = palabras & "cinco "
                            Case "6"
                                If flag = "N" Then palabras = palabras & "seis "
                            Case "7"
                                If flag = "N" Then palabras = palabras & "siete "
                            Case "8"
                                If flag = "N" Then palabras = palabras & "ocho "
                            Case "9"
                                If flag = "N" Then palabras = palabras & "nueve "
                        End Select
                End Select

                '***********Asigna la palabra mil***************
                If y = 4 Then
                    If Mid(entero, 6, 1) <> "0" Or Mid(entero, 5, 1) <> "0" Or Mid(entero, 4, 1) <> "0" Or _
                    (Mid(entero, 6, 1) = "0" And Mid(entero, 5, 1) = "0" And Mid(entero, 4, 1) = "0" And _
                    Len(entero) <= 6) Then palabras = palabras & "mil "
                End If

                '**********Asigna la palabra millón*************
                If y = 7 Then
                    If Len(entero) = 7 And Mid(entero, 1, 1) = "1" Then
                        palabras = palabras & "millón "
                    Else
                        palabras = palabras & "millones "
                    End If
                End If
            Next y

            '******+******Genera la parte decimal********************
            For y = Len(dec) To 1 Step -1
                num = Len(dec) - (y - 1)
                Select Case y
                    Case 2, 5, 8
                        Select Case Mid(dec, num, 1)
                            Case "1"
                                If Mid(dec, num + 1, 1) = "0" Then
                                    flag = "S"
                                    centavos = centavos & "diez "
                                End If
                                If Mid(dec, num + 1, 1) = "1" Then
                                    flag = "S"
                                    centavos = centavos & "once "
                                End If
                                If Mid(dec, num + 1, 1) = "2" Then
                                    flag = "S"
                                    centavos = centavos & "doce "
                                End If
                                If Mid(dec, num + 1, 1) = "3" Then
                                    flag = "S"
                                    centavos = centavos & "trece "
                                End If
                                If Mid(dec, num + 1, 1) = "4" Then
                                    flag = "S"
                                    centavos = centavos & "catorce "
                                End If
                                If Mid(dec, num + 1, 1) = "5" Then
                                    flag = "S"
                                    centavos = centavos & "quince "
                                End If
                                If Mid(dec, num + 1, 1) > "5" Then
                                    flag = "N"
                                    centavos = centavos & "dieci"
                                End If
                            Case "2"
                                If Mid(dec, num + 1, 1) = "0" Then
                                    centavos = centavos & "veinte "
                                    flag = "S"
                                Else
                                    palabras = palabras & "veinti"
                                    flag = "N"
                                End If
                            Case "3"
                                If Mid(dec, num + 1, 1) = "0" Then
                                    centavos = centavos & "treinta "
                                    flag = "S"
                                Else
                                    centavos = centavos & "treinta y "
                                    flag = "N"
                                End If
                            Case "4"
                                If Mid(dec, num + 1, 1) = "0" Then
                                    centavos = centavos & "cuarenta "
                                    flag = "S"
                                Else
                                    centavos = centavos & "cuarenta y "
                                    flag = "N"
                                End If
                            Case "5"
                                If Mid(dec, num + 1, 1) = "0" Then
                                    centavos = centavos & "cincuenta "
                                    flag = "S"
                                Else
                                    centavos = centavos & "cincuenta y "
                                    flag = "N"
                                End If
                            Case "6"
                                If Mid(dec, num + 1, 1) = "0" Then
                                    centavos = centavos & "sesenta "
                                    flag = "S"
                                Else
                                    centavos = centavos & "sesenta y "
                                    flag = "N"
                                End If
                            Case "7"
                                If Mid(dec, num + 1, 1) = "0" Then
                                    centavos = centavos & "setenta "
                                    flag = "S"
                                Else
                                    centavos = centavos & "setenta y "
                                    flag = "N"
                                End If
                            Case "8"
                                If Mid(dec, num + 1, 1) = "0" Then
                                    centavos = centavos & "ochenta "
                                    flag = "S"
                                Else
                                    centavos = centavos & "ochenta y "
                                    flag = "N"
                                End If
                            Case "9"
                                If Mid(dec, num + 1, 1) = "0" Then
                                    centavos = centavos & "noventa "
                                    flag = "S"
                                Else
                                    centavos = centavos & "noventa y "
                                    flag = "N"
                                End If
                        End Select
                    Case 1, 4, 7
                        '*********Asigna las palabras para las unidades*********
                        Select Case Mid(dec, num, 1)
                            Case "1"
                                If flag = "N" Then centavos = centavos & "un "
                            Case "2"
                                If flag = "N" Then centavos = centavos & "dos "
                            Case "3"
                                If flag = "N" Then centavos = centavos & "tres "
                            Case "4"
                                If flag = "N" Then centavos = centavos & "cuatro "
                            Case "5"
                                If flag = "N" Then centavos = centavos & "cinco "
                            Case "6"
                                If flag = "N" Then centavos = centavos & "seis "
                            Case "7"
                                If flag = "N" Then centavos = centavos & "siete "
                            Case "8"
                                If flag = "N" Then centavos = centavos & "ocho "
                            Case "9"
                                If flag = "N" Then centavos = centavos & "nueve "
                        End Select
                End Select

            Next y


            '**********Une la parte entera y la parte decimal*************

            If Val(numero) >= 1 AndAlso Val(numero) < 2 Then
                palabras = palabras & " PESO "
            Else
                If palabras <> "" Then
                    palabras = palabras & " PESOS "
                Else
                    palabras = "CERO PESOS "
                End If
            End If

            If dec <> "" Then
                If CInt(dec) = 1 Then
                    '       Letras = palabras & "CON " & centavos & " CENTAVO"
                    Letras = palabras & dec & "/100 M.N."
                Else
                    'Letras = palabras & "CON " & centavos & " CENTAVOS"
                    Letras = palabras & dec & "/100 M.N."
                End If
            Else
                'Letras = palabras & " CON CERO CENTAVOS"
                Letras = palabras & " 00/100 M.N."
            End If

        Else
            Letras = ""
        End If
    End Function

    Public Function LetrasM(ByVal numero As String, ByVal MonDesc As String, ByVal MonRef As String) As String
        '********Declara variables de tipo cadena************
        Dim palabras As String = ""
        Dim centavos As String = ""
        Dim entero As String = ""
        Dim dec As String = ""
        Dim flag As String = ""

        '********Declara variables de tipo entero***********
        Dim num, x, y As Integer

        flag = "N"

        '**********Número Negativo***********
        If Mid(numero, 1, 1) = "-" Then
            numero = Mid(numero, 2, numero.ToString.Length - 1).ToString
            palabras = "menos "
        End If

        '**********Si tiene ceros a la izquierda*************
        For x = 1 To numero.ToString.Length
            If Mid(numero, 1, 1) = "0" Then
                numero = Trim(Mid(numero, 2, numero.ToString.Length).ToString)
                If Trim(numero.ToString.Length) = 0 Then palabras = ""
            Else
                Exit For
            End If
        Next

        '*********Dividir parte entera y decimal************
        For y = 1 To Len(numero)
            If Mid(numero, y, 1) = "." Then
                flag = "S"
            Else
                If flag = "N" Then
                    entero = entero + Mid(numero, y, 1)
                Else
                    dec = dec + Mid(numero, y, 1)
                End If
            End If
        Next y

        If Len(dec) = 1 Then dec = dec & "0"

        '**********proceso de conversión***********
        flag = "N"

        If Val(numero) <= 999999999 Then
            For y = Len(entero) To 1 Step -1
                num = Len(entero) - (y - 1)
                Select Case y
                    Case 3, 6, 9
                        '**********Asigna las palabras para las centenas***********
                        Select Case Mid(entero, num, 1)
                            Case "1"
                                If Mid(entero, num + 1, 1) = "0" And Mid(entero, num + 2, 1) = "0" Then
                                    palabras = palabras & "cien "
                                Else
                                    palabras = palabras & "ciento "
                                End If
                            Case "2"
                                palabras = palabras & "doscientos "
                            Case "3"
                                palabras = palabras & "trescientos "
                            Case "4"
                                palabras = palabras & "cuatrocientos "
                            Case "5"
                                palabras = palabras & "quinientos "
                            Case "6"
                                palabras = palabras & "seiscientos "
                            Case "7"
                                palabras = palabras & "setecientos "
                            Case "8"
                                palabras = palabras & "ochocientos "
                            Case "9"
                                palabras = palabras & "novecientos "
                        End Select
                    Case 2, 5, 8
                        '*********Asigna las palabras para las decenas************
                        Select Case Mid(entero, num, 1)
                            Case "1"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    flag = "S"
                                    palabras = palabras & "diez "
                                End If
                                If Mid(entero, num + 1, 1) = "1" Then
                                    flag = "S"
                                    palabras = palabras & "once "
                                End If
                                If Mid(entero, num + 1, 1) = "2" Then
                                    flag = "S"
                                    palabras = palabras & "doce "
                                End If
                                If Mid(entero, num + 1, 1) = "3" Then
                                    flag = "S"
                                    palabras = palabras & "trece "
                                End If
                                If Mid(entero, num + 1, 1) = "4" Then
                                    flag = "S"
                                    palabras = palabras & "catorce "
                                End If
                                If Mid(entero, num + 1, 1) = "5" Then
                                    flag = "S"
                                    palabras = palabras & "quince "
                                End If
                                If Mid(entero, num + 1, 1) > "5" Then
                                    flag = "N"
                                    palabras = palabras & "dieci"
                                End If
                            Case "2"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "veinte "
                                    flag = "S"
                                Else
                                    palabras = palabras & "veinti"
                                    flag = "N"
                                End If
                            Case "3"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "treinta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "treinta y "
                                    flag = "N"
                                End If
                            Case "4"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "cuarenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "cuarenta y "
                                    flag = "N"
                                End If
                            Case "5"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "cincuenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "cincuenta y "
                                    flag = "N"
                                End If
                            Case "6"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "sesenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "sesenta y "
                                    flag = "N"
                                End If
                            Case "7"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "setenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "setenta y "
                                    flag = "N"
                                End If
                            Case "8"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "ochenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "ochenta y "
                                    flag = "N"
                                End If
                            Case "9"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "noventa "
                                    flag = "S"
                                Else
                                    palabras = palabras & "noventa y "
                                    flag = "N"
                                End If
                        End Select
                    Case 1, 4, 7
                        '*********Asigna las palabras para las unidades*********
                        Select Case Mid(entero, num, 1)
                            Case "1"
                                If flag = "N" Then
                                    If y = 1 Then
                                        palabras = palabras & "uno "
                                    Else
                                        palabras = palabras & "un "
                                    End If
                                End If
                            Case "2"
                                If flag = "N" Then palabras = palabras & "dos "
                            Case "3"
                                If flag = "N" Then palabras = palabras & "tres "
                            Case "4"
                                If flag = "N" Then palabras = palabras & "cuatro "
                            Case "5"
                                If flag = "N" Then palabras = palabras & "cinco "
                            Case "6"
                                If flag = "N" Then palabras = palabras & "seis "
                            Case "7"
                                If flag = "N" Then palabras = palabras & "siete "
                            Case "8"
                                If flag = "N" Then palabras = palabras & "ocho "
                            Case "9"
                                If flag = "N" Then palabras = palabras & "nueve "
                        End Select
                End Select

                '***********Asigna la palabra mil***************
                If y = 4 Then
                    If Mid(entero, 6, 1) <> "0" Or Mid(entero, 5, 1) <> "0" Or Mid(entero, 4, 1) <> "0" Or _
                    (Mid(entero, 6, 1) = "0" And Mid(entero, 5, 1) = "0" And Mid(entero, 4, 1) = "0" And _
                    Len(entero) <= 6) Then palabras = palabras & "mil "
                End If

                '**********Asigna la palabra millón*************
                If y = 7 Then
                    If Len(entero) = 7 And Mid(entero, 1, 1) = "1" Then
                        palabras = palabras & "millón "
                    Else
                        palabras = palabras & "millones "
                    End If
                End If
            Next y

            '******+******Genera la parte decimal********************
            For y = Len(dec) To 1 Step -1
                num = Len(dec) - (y - 1)
                Select Case y
                    Case 2, 5, 8
                        Select Case Mid(dec, num, 1)
                            Case "1"
                                If Mid(dec, num + 1, 1) = "0" Then
                                    flag = "S"
                                    centavos = centavos & "diez "
                                End If
                                If Mid(dec, num + 1, 1) = "1" Then
                                    flag = "S"
                                    centavos = centavos & "once "
                                End If
                                If Mid(dec, num + 1, 1) = "2" Then
                                    flag = "S"
                                    centavos = centavos & "doce "
                                End If
                                If Mid(dec, num + 1, 1) = "3" Then
                                    flag = "S"
                                    centavos = centavos & "trece "
                                End If
                                If Mid(dec, num + 1, 1) = "4" Then
                                    flag = "S"
                                    centavos = centavos & "catorce "
                                End If
                                If Mid(dec, num + 1, 1) = "5" Then
                                    flag = "S"
                                    centavos = centavos & "quince "
                                End If
                                If Mid(dec, num + 1, 1) > "5" Then
                                    flag = "N"
                                    centavos = centavos & "dieci"
                                End If
                            Case "2"
                                If Mid(dec, num + 1, 1) = "0" Then
                                    centavos = centavos & "veinte "
                                    flag = "S"
                                Else
                                    centavos = centavos & "veinti"
                                    flag = "N"
                                End If
                            Case "3"
                                If Mid(dec, num + 1, 1) = "0" Then
                                    centavos = centavos & "treinta "
                                    flag = "S"
                                Else
                                    centavos = centavos & "treinta y "
                                    flag = "N"
                                End If
                            Case "4"
                                If Mid(dec, num + 1, 1) = "0" Then
                                    centavos = centavos & "cuarenta "
                                    flag = "S"
                                Else
                                    centavos = centavos & "cuarenta y "
                                    flag = "N"
                                End If
                            Case "5"
                                If Mid(dec, num + 1, 1) = "0" Then
                                    centavos = centavos & "cincuenta "
                                    flag = "S"
                                Else
                                    centavos = centavos & "cincuenta y "
                                    flag = "N"
                                End If
                            Case "6"
                                If Mid(dec, num + 1, 1) = "0" Then
                                    centavos = centavos & "sesenta "
                                    flag = "S"
                                Else
                                    centavos = centavos & "sesenta y "
                                    flag = "N"
                                End If
                            Case "7"
                                If Mid(dec, num + 1, 1) = "0" Then
                                    centavos = centavos & "setenta "
                                    flag = "S"
                                Else
                                    centavos = centavos & "setenta y "
                                    flag = "N"
                                End If
                            Case "8"
                                If Mid(dec, num + 1, 1) = "0" Then
                                    centavos = centavos & "ochenta "
                                    flag = "S"
                                Else
                                    centavos = centavos & "ochenta y "
                                    flag = "N"
                                End If
                            Case "9"
                                If Mid(dec, num + 1, 1) = "0" Then
                                    centavos = centavos & "noventa "
                                    flag = "S"
                                Else
                                    centavos = centavos & "noventa y "
                                    flag = "N"
                                End If
                        End Select
                    Case 1, 4, 7
                        '*********Asigna las palabras para las unidades*********
                        Select Case Mid(dec, num, 1)
                            Case "1"
                                If flag = "N" Then centavos = centavos & "un "
                            Case "2"
                                If flag = "N" Then centavos = centavos & "dos "
                            Case "3"
                                If flag = "N" Then centavos = centavos & "tres "
                            Case "4"
                                If flag = "N" Then centavos = centavos & "cuatro "
                            Case "5"
                                If flag = "N" Then centavos = centavos & "cinco "
                            Case "6"
                                If flag = "N" Then centavos = centavos & "seis "
                            Case "7"
                                If flag = "N" Then centavos = centavos & "siete "
                            Case "8"
                                If flag = "N" Then centavos = centavos & "ocho "
                            Case "9"
                                If flag = "N" Then centavos = centavos & "nueve "
                        End Select
                End Select

            Next y


            '**********Une la parte entera y la parte decimal*************


            If Val(numero) >= 1 AndAlso Val(numero) < 2 Then
                palabras = palabras & " " & MonDesc & " "
            Else
                Dim final As String = ""
                If IsVocal(MonDesc) = True Then
                    final = "S "
                ElseIf Mid(MonDesc, MonDesc.Length, 1) <> "S" AndAlso Mid(MonDesc, MonDesc.Length, 1) <> "s" Then
                    final = "ES "
                End If

                If palabras <> "" Then

                    palabras = palabras & " " & MonDesc.Trim & final
                Else
                    palabras = "CERO " & MonDesc.Trim & final
                End If
            End If

            If dec <> "" Then
                If CInt(dec) = 1 Then
                    '       Letras = palabras & "CON " & centavos & " CENTAVO"
                    LetrasM = palabras & dec & "/100 " & MonRef
                Else
                    'Letras = palabras & "CON " & centavos & " CENTAVOS"
                    LetrasM = palabras & dec & "/100 " & MonRef
                End If
            Else
                'Letras = palabras & " CON CERO CENTAVOS"
                LetrasM = palabras & " 00/100 " & MonRef
            End If

        Else
            LetrasM = ""
        End If
    End Function

    'Public Function spaceFormat(ByVal atributo As String) As String
    '    atributo = atributo.Replace("  ", " ")
    '    atributo = atributo.Replace("  ", " ")
    '    atributo = atributo.Replace("&", "&amp;")
    '    atributo = atributo.Replace("""", "&quot;")
    '    atributo = atributo.Replace("<", "&lt;")
    '    atributo = atributo.Replace(">", "&gt;")
    '    atributo = atributo.Replace("'", "&apos;")
    '    Return (atributo)
    'End Function

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




    Public Function spaceFormat(ByVal atributo As String) As String
        If atributo Is Nothing Then
            atributo = ""
        Else
            atributo = atributo.Trim
            atributo = atributo.Replace("  ", " ")
            atributo = atributo.Replace("  ", " ")
            atributo = atributo.Replace("  ", " ")
            atributo = atributo.Replace("  ", " ")
            atributo = atributo.Replace("  ", " ")
            atributo = atributo.Replace("  ", " ")
            atributo = atributo.Replace("  ", " ")
            atributo = atributo.Replace("  ", " ")
            'atributo = atributo.Replace("&", "&amp;")
            'atributo = atributo.Replace("'", "&apos;")
            'atributo = atributo.Replace(">", "&gt;")
            'atributo = atributo.Replace("<", "&lt;")
        End If
        Return (atributo)
    End Function


    Public Function cFormat(ByVal numero As String) As String
        '********Declara variables de tipo cadena************
        Dim entero As String = ""
        Dim dec As String = ""
        Dim flag As String = ""

        '********Declara variables de tipo entero***********
        Dim y As Integer

        '*********Dividir parte entera y decimal************

        flag = "N"

        For y = 1 To Len(numero)
            If Mid(numero, y, 1) = "." Then
                flag = "S"
            Else
                If flag = "N" Then
                    entero = entero + Mid(numero, y, 1)
                Else
                    dec = dec + Mid(numero, y, 1)
                End If
            End If
        Next y

        If Len(dec) = 0 Then dec = "00"

        If Len(dec) = 1 Then dec = dec & "0"

        '**********Une la parte entera y la parte decimal*************

        Return entero & "." & dec

    End Function


    Public Function FormateaCadena(ByVal Inicio As Boolean, ByVal s As String, ByVal length As Integer) As String
        Dim CadenaVacia As String = "                                                           "
        If Inicio Then
            Dim CadenaNueva As String = s & CadenaVacia
            Return CadenaNueva.Substring(0, length)
        Else
            Dim CadenaNueva As String = CadenaVacia & s
            Return CadenaNueva.Substring(CadenaNueva.Length - length, length)
        End If
    End Function


    ' Al estar declarado como Shared, podemos usarlo sin crear
    ' una instancia de la clase
    Public Sub CambiarEstilo(ByVal tControl As Control)
        ' Cambiar el estilo del control...
        ' sólo si es uno de los indicados
        Select Case tControl.GetType.Name
            Case "Label"
                CType(tControl, Label).FlatStyle = FlatStyle.System
            Case "CheckBox"
                CType(tControl, CheckBox).FlatStyle = FlatStyle.System
            Case "RadioButton"
                CType(tControl, RadioButton).FlatStyle = FlatStyle.System
            Case "Button"
                ' Si el botón tiene asignada la propiedad Image     (11/Oct/02)
                ' no cambiarlo...
                Dim tButton As Button = CType(tControl, Button)
                If tButton.Image Is Nothing Then
                    tButton.FlatStyle = FlatStyle.System
                End If
            Case "GroupBox"
                CType(tControl, GroupBox).FlatStyle = FlatStyle.System
        End Select
        '
        ' Cambiar también los controles contenidos en cada control...
        If tControl.Controls.Count > 0 Then
            Dim tControl2 As Control
            '
            For Each tControl2 In tControl.Controls
                CambiarEstilo(tControl2)
            Next
        End If
    End Sub

    Private Function EncryptSha1(ByVal strToHash As String) As String
        Dim Result As String = ""
        Dim OSha1 As New  _
        System.Security.Cryptography.SHA1CryptoServiceProvider

        'Step 1
        Dim bytesToHash() As Byte _
        = System.Text.Encoding.ASCII.GetBytes(strToHash)

        'Step 2
        bytesToHash = OSha1.ComputeHash(bytesToHash)

        'Step 3
        For Each item As Byte In bytesToHash
            Result += item.ToString("x2")
        Next


        Return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(Result))
    End Function


    Public Function encriptarSHA(ByVal sPass As String) As String
        Dim hashValue As System.Security.Cryptography.HashAlgorithm
        hashValue = New System.Security.Cryptography.SHA1CryptoServiceProvider
        Dim byteValue As Byte() = System.Text.Encoding.UTF8.GetBytes(sPass)
        Dim byteHash As Byte() = hashValue.ComputeHash(byteValue)
        hashValue.Clear()
        Return (Convert.ToBase64String(byteHash))
    End Function

 

    Public Function RecuperaIcono(ByVal bits As Byte()) As Bitmap
        Dim memorybits As New System.IO.MemoryStream(bits)
        Dim bitmap As New Bitmap(memorybits)
        Return (bitmap)
    End Function

    Public Function TruncateToDecimal(ByVal ToTruncate As Decimal, ByVal DecimalPlaces As Integer) As Double
        Dim power As Decimal = Math.Pow(10, DecimalPlaces)
        Return Math.Truncate(ToTruncate * power) / power
    End Function

    Public Function Redondear(ByVal dNumero As Double, ByVal iDecimales As Integer) As Decimal
        'Dim lMultiplicador As Long
        'Dim dRetorno As Double

        'If iDecimales > 9 Then iDecimales = 9
        'lMultiplicador = 10 ^ iDecimales
        'dRetorno = CDbl(CLng(dNumero * lMultiplicador)) / lMultiplicador

        'Redondear = dRetorno
        If dNumero = 0 Then
            Return 0
        Else
            Return ModPOS.TruncateToDecimal(CDec(dNumero), iDecimales)
        End If

    End Function

    Public Function CrearTabla(ByVal TableName As String, ByVal ParamArray Columnas() As String) As DataTable
        Dim Table1 As DataTable

        Table1 = New DataTable(TableName)

        If Not Columnas Is Nothing Then
            Dim i As Integer
            For i = 0 To Columnas.Length - 1 Step 2
                Try
                    Dim Columna As DataColumn = New DataColumn(Columnas(i))
                    'declaring a column named Name
                    Columna.DataType = System.Type.GetType(Columnas(i + 1))
                    'setting the datatype for the column
                    Table1.Columns.Add(Columna)
                    'adding the column to table
                Catch

                End Try
            Next
        End If
        Return Table1
    End Function

    Function Recupera_Tabla_No_Msg(ByVal sp As String, ByVal ParamArray Parametros() As Object) As DataTable
        Dim Cnx As System.Data.SqlClient.SqlConnection = Nothing
        Dim du As System.Data.SqlClient.SqlDataAdapter
        Dim dtu As DataTable

        Cnx = New System.Data.SqlClient.SqlConnection

        Try
            Cnx.ConnectionString = ModPOS.BDConexion
            Cnx.Open()
        Catch ex As Exception
            Beep()
            MsgBox("No se puede conectar a la base de datos", MsgBoxStyle.Information, "Error")
        End Try

        du = New System.Data.SqlClient.SqlDataAdapter

        Try

            Dim i As Integer

            With du
                .SelectCommand = New System.Data.SqlClient.SqlCommand(sp, Cnx)
                .SelectCommand.CommandTimeout = ModPOS.myTimeOut
                .SelectCommand.CommandType = CommandType.StoredProcedure

                If Not Parametros Is Nothing Then
                    For i = 0 To Parametros.Length - 1 Step 2
                        Select Case Parametros(i + 1).GetType.Name
                            Case "String"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.VarChar).Value = Parametros(i + 1)
                            Case "Int32"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.Int).Value = Parametros(i + 1)
                            Case "Double"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.Decimal).Value = Parametros(i + 1)
                            Case "Decimal"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.Decimal).Value = Parametros(i + 1)
                            Case "Byte[]"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.Image).Value = Parametros(i + 1)
                            Case "Byte"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.SmallInt).Value = Parametros(i + 1)

                        End Select
                    Next
                End If
            End With


        Catch ex As Exception
            Beep()
            MsgBox("No se puede ejecutar la consulta", MsgBoxStyle.Critical, "Error")
        End Try

        dtu = New DataTable

        Try
            du.Fill(dtu)
        Catch e As System.Data.SqlClient.SqlException
            '   MsgBox(e.Message)
        End Try

        du.Dispose()
        Cnx.Close()
        Return dtu

    End Function

    Function Recupera_Tabla(ByVal sp As String, ByVal ParamArray Parametros() As Object) As DataTable
        Dim Cnx As System.Data.SqlClient.SqlConnection = Nothing
        Dim du As System.Data.SqlClient.SqlDataAdapter
        Dim dtu As DataTable

        Cnx = New System.Data.SqlClient.SqlConnection

        Try
            Cnx.ConnectionString = ModPOS.BDConexion
            Cnx.Open()
        Catch ex As Exception
            Beep()
            MsgBox("No se puede conectar a la base de datos", MsgBoxStyle.Information, "Error")
        End Try

        du = New System.Data.SqlClient.SqlDataAdapter

        Try

            Dim i As Integer

            With du
                .SelectCommand = New System.Data.SqlClient.SqlCommand(sp, Cnx)
                .SelectCommand.CommandTimeout = ModPOS.myTimeOut
                .SelectCommand.CommandType = CommandType.StoredProcedure

                If Not Parametros Is Nothing Then
                    For i = 0 To Parametros.Length - 1 Step 2
                        Select Case Parametros(i + 1).GetType.Name
                            Case "String"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.VarChar).Value = Parametros(i + 1)
                            Case "Int32"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.Int).Value = Parametros(i + 1)
                            Case "Double"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.Decimal).Value = Parametros(i + 1)
                            Case "Decimal"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.Decimal).Value = Parametros(i + 1)
                            Case "Byte[]"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.Image).Value = Parametros(i + 1)
                            Case "Byte"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.SmallInt).Value = Parametros(i + 1)
                            Case "DateTime"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.DateTime).Value = Parametros(i + 1)
                            Case "Boolean"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.Bit).Value = Parametros(i + 1)
                        End Select
                    Next
                End If
            End With


        Catch ex As Exception
            Beep()
            MsgBox("No se puede ejecutar la consulta", MsgBoxStyle.Critical, "Error")
        End Try

        dtu = New DataTable

        Try
            du.Fill(dtu)
        Catch e As System.Data.SqlClient.SqlException
            MsgBox(e.Message)
        End Try

        du.Dispose()
        Cnx.Close()
        dtu.TableName = sp
        Return dtu

    End Function


    Function recuperaConsulta_DTS(ByVal sConsulta As String, ByVal Tabla As String) As DataSet
        Dim Cnx As System.Data.SqlClient.SqlConnection = Nothing
        Dim du As System.Data.SqlClient.SqlDataAdapter
        Dim dts As DataSet

        Cnx = New System.Data.SqlClient.SqlConnection

        Try
            Cnx.ConnectionString = ModPOS.BDConexion
            Cnx.Open()
        Catch ex As Exception
            Beep()
            MsgBox("No se puede conectar a la base de datos", MsgBoxStyle.Critical, "Error")
        End Try

        du = New System.Data.SqlClient.SqlDataAdapter

        Try

            With du
                .SelectCommand = New System.Data.SqlClient.SqlCommand(sConsulta, Cnx)
                .SelectCommand.CommandTimeout = ModPOS.myTimeOut
                .SelectCommand.CommandType = CommandType.Text
            End With

        Catch ex As Exception
            Beep()
            MsgBox("No se puede ejecutar la consulta", MsgBoxStyle.Critical, "Error")
        End Try

        dts = New DataSet

        Try
            du.Fill(dts, Tabla)
        Catch e As System.Data.SqlClient.SqlException
            MsgBox(e.Message)
        End Try

        du.Dispose()
        Cnx.Close()
        Return dts

    End Function

    Function recuperaTabla_DTS(ByVal sp As String, ByVal Tabla As String, ByVal ParamArray Parametros() As Object) As DataSet
        Dim Cnx As System.Data.SqlClient.SqlConnection = Nothing
        Dim du As System.Data.SqlClient.SqlDataAdapter
        Dim dts As DataSet

        Cnx = New System.Data.SqlClient.SqlConnection

        Try
            Cnx.ConnectionString = ModPOS.BDConexion
            Cnx.Open()
        Catch ex As Exception
            Beep()
            MsgBox("No se puede conectar a la base de datos", MsgBoxStyle.Critical, "Error")
        End Try

        du = New System.Data.SqlClient.SqlDataAdapter

        Try

            Dim i As Integer

            With du
                .SelectCommand = New System.Data.SqlClient.SqlCommand(sp, Cnx)
                .SelectCommand.CommandTimeout = ModPOS.myTimeOut
                .SelectCommand.CommandType = CommandType.StoredProcedure

                If Not Parametros Is Nothing Then
                    For i = 0 To Parametros.Length - 1 Step 2
                        Select Case Parametros(i + 1).GetType.Name
                            Case "String"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.VarChar).Value = Parametros(i + 1)
                            Case "Int32"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.Int).Value = Parametros(i + 1)
                            Case "Double"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.Decimal).Value = Parametros(i + 1)
                            Case "Decimal"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.Decimal).Value = Parametros(i + 1)
                            Case "Byte[]"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.Image).Value = Parametros(i + 1)
                            Case "Byte[]"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.SmallInt).Value = Parametros(i + 1)
                            Case "DateTime"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.DateTime).Value = Parametros(i + 1)
                        End Select
                    Next
                End If
            End With


        Catch ex As Exception
            Beep()
            MsgBox("No se puede ejecutar la consulta", MsgBoxStyle.Critical, "Error")
        End Try

        dts = New DataSet

        Try
            du.Fill(dts, Tabla)
        Catch e As System.Data.SqlClient.SqlException
            MsgBox(e.Message)
        End Try

        du.Dispose()
        Cnx.Close()
        Return dts

    End Function

    Public Sub ActualizaGrid(ByVal Estado As Boolean, ByVal Grid As Janus.Windows.GridEX.GridEX, ByVal sp As String, ByVal ParamArray Parametros() As Object)

        Dim Cnx As System.Data.SqlClient.SqlConnection = Nothing
        Dim da As System.Data.SqlClient.SqlDataAdapter

        Try
            Cnx = New System.Data.SqlClient.SqlConnection
            Cnx.ConnectionString = ModPOS.BDConexion
            Cnx.Open()
        Catch ex As Exception
            Beep()
            MsgBox("No se puede conectar a la base de datos", MsgBoxStyle.Critical, "Error")
        End Try

        da = New System.Data.SqlClient.SqlDataAdapter

        Try

            Dim i As Integer

            With da
                .SelectCommand = New System.Data.SqlClient.SqlCommand(sp, Cnx)
                .SelectCommand.CommandTimeout = ModPOS.myTimeOut
                .SelectCommand.CommandType = CommandType.StoredProcedure

                If Not Parametros Is Nothing Then
                    For i = 0 To Parametros.Length - 1 Step 2
                        Select Case Parametros(i + 1).GetType.Name
                            Case "String"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.VarChar).Value = Parametros(i + 1)
                            Case "Int32"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.Int).Value = Parametros(i + 1)
                            Case "Double"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.Decimal).Value = Parametros(i + 1)
                            Case "Decimal"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.Decimal).Value = Parametros(i + 1)
                            Case "Byte[]"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.Image).Value = Parametros(i + 1)
                            Case "DateTime"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.DateTime).Value = Parametros(i + 1)
                            Case "Boolean"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.Bit).Value = Parametros(i + 1)

                        End Select
                    Next
                End If
            End With



        Catch ex As Exception
            MsgBox("No se puede conectar con la base de datos", MsgBoxStyle.Critical, "Error")
        End Try
        Dim ds As DataTable = New DataTable
        Try
            da.Fill(ds)
        Catch e As System.Data.SqlClient.SqlException
            MsgBox(e.Message)
        End Try

        Grid.DataSource = ds
        Grid.RetrieveStructure(True)
        Grid.BuiltInTexts(Janus.Windows.GridEX.GridEXBuiltInText.GroupByBoxInfo) = "Arrastre el encabezado de la columna aquí para agrupar por esa columna."
        da.Dispose()
        Cnx.Close()

        If Estado AndAlso Grid.RowCount > 0 Then
            Dim fc As Janus.Windows.GridEX.GridEXFormatCondition
            fc = New Janus.Windows.GridEX.GridEXFormatCondition(Grid.RootTable.Columns("Estado"), Janus.Windows.GridEX.ConditionOperator.Equal, "Inactivo")

            fc.FormatStyle.FontStrikeout = Janus.Windows.GridEX.TriState.True
            fc.FormatStyle.ForeColor = System.Drawing.SystemColors.GrayText
            Grid.RootTable.FormatConditions.Add(fc)
        End If
        Grid.AlternatingRowFormatStyle.BackColor = System.Drawing.Color.Lavender
        Grid.AlternatingColors = True
        'Grid.AutoSizeColumns()


    End Sub


    Public Function SiExite(ByVal Con As String, ByVal sp As String, ByVal ParamArray Parametros() As Object) As Integer
        Dim Cnx As System.Data.SqlClient.SqlConnection = Nothing
        Dim da As System.Data.SqlClient.SqlDataAdapter
        Dim dt As DataTable
        Dim Result As Integer

        Cnx = New System.Data.SqlClient.SqlConnection

        Try
            Cnx.ConnectionString = Con
            Cnx.Open()
        Catch ex As Exception
            Beep()
            MsgBox("No se pudo establecer conexión con el Servidor", MsgBoxStyle.Critical, "Error")
        End Try

        da = New System.Data.SqlClient.SqlDataAdapter

        Try

            Dim i As Integer

            With da
                .SelectCommand = New System.Data.SqlClient.SqlCommand(sp, Cnx)
                .SelectCommand.CommandTimeout = ModPOS.myTimeOut
                .SelectCommand.CommandType = CommandType.StoredProcedure

                If Not Parametros Is Nothing Then
                    For i = 0 To Parametros.Length - 1 Step 2
                        Select Case Parametros(i + 1).GetType.Name
                            Case "String"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.VarChar).Value = Parametros(i + 1)
                            Case "Int32"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.Int).Value = Parametros(i + 1)
                            Case "Double"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.Decimal).Value = Parametros(i + 1)
                            Case "Decimal"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.Decimal).Value = Parametros(i + 1)
                            Case "Byte[]"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.Image).Value = Parametros(i + 1)
                            Case "Byte"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.SmallInt).Value = Parametros(i + 1)
                            Case "DateTime"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.DateTime).Value = Parametros(i + 1)

                        End Select
                    Next
                End If
            End With

        Catch e As System.Data.SqlClient.SqlException
            Beep()
            MsgBox(e.Message, MsgBoxStyle.Critical, "Error")
        End Try

        dt = New DataTable

        Try
            da.Fill(dt)
        Catch e As System.Data.SqlClient.SqlException
            MsgBox(e.Message)
        End Try

        Result = dt.Rows.Count()

        dt.Dispose()
        da.Dispose()
        Cnx.Close()

        Return Result
    End Function


    Public Function SiExisteRecuperaT(ByVal Con As String, ByVal sp As String, ByVal ParamArray Parametros() As Object) As Object
        Dim Cnx As System.Data.SqlClient.SqlConnection = Nothing
        Dim du As System.Data.SqlClient.SqlDataAdapter
        Dim dtu As DataTable

        Cnx = New System.Data.SqlClient.SqlConnection

        Try
            Cnx.ConnectionString = Con
            Cnx.Open()
        Catch ex As Exception
            Beep()
            MsgBox("No se puede conectar a la base de datos", MsgBoxStyle.Critical, "Error")
        End Try

        du = New System.Data.SqlClient.SqlDataAdapter

        Try

            Dim i As Integer

            With du
                .SelectCommand = New System.Data.SqlClient.SqlCommand(sp, Cnx)
                .SelectCommand.CommandTimeout = ModPOS.myTimeOut
                .SelectCommand.CommandType = CommandType.StoredProcedure

                If Not Parametros Is Nothing Then
                    For i = 0 To Parametros.Length - 1 Step 2
                        Select Case Parametros(i + 1).GetType.Name
                            Case "String"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.VarChar).Value = Parametros(i + 1)
                            Case "Int32"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.Int).Value = Parametros(i + 1)
                            Case "Double"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.Decimal).Value = Parametros(i + 1)
                            Case "Decimal"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.Decimal).Value = Parametros(i + 1)
                            Case "Byte[]"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.Image).Value = Parametros(i + 1)
                            Case "Byte"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.SmallInt).Value = Parametros(i + 1)
                            Case "DateTime"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.DateTime).Value = Parametros(i + 1)
                            Case "Boolean"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.Bit).Value = Parametros(i + 1)
                        End Select
                    Next
                End If
            End With


        Catch ex As Exception
            Beep()
            MsgBox("No se puede ejecutar la consulta", MsgBoxStyle.Critical, "Error")
        End Try

        dtu = New DataTable

        Try
            du.Fill(dtu)
        Catch e As System.Data.SqlClient.SqlException
            MsgBox(e.Message)
        End Try

        du.Dispose()
        Cnx.Close()

        If dtu.Rows.Count > 0 Then

            Return dtu
        Else
            dtu.Dispose()
            Return Nothing
        End If

    End Function


    Public Function SiExisteRecupera(ByVal sp As String, ByVal ParamArray Parametros() As Object) As Object
        Dim Cnx As System.Data.SqlClient.SqlConnection = Nothing
        Dim du As System.Data.SqlClient.SqlDataAdapter
        Dim dtu As DataTable

        Cnx = New System.Data.SqlClient.SqlConnection

        Try
            Cnx.ConnectionString = ModPOS.BDConexion
            Cnx.Open()
        Catch ex As Exception
            Beep()
            MsgBox("No se puede conectar a la base de datos", MsgBoxStyle.Critical, "Error")
        End Try

        du = New System.Data.SqlClient.SqlDataAdapter

        Try

            Dim i As Integer

            With du
                .SelectCommand = New System.Data.SqlClient.SqlCommand(sp, Cnx)
                .SelectCommand.CommandTimeout = ModPOS.myTimeOut
                .SelectCommand.CommandType = CommandType.StoredProcedure

                If Not Parametros Is Nothing Then
                    For i = 0 To Parametros.Length - 1 Step 2
                        Select Case Parametros(i + 1).GetType.Name
                            Case "String"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.VarChar).Value = Parametros(i + 1)
                            Case "Int32"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.Int).Value = Parametros(i + 1)
                            Case "Double"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.Decimal).Value = Parametros(i + 1)
                            Case "Decimal"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.Decimal).Value = Parametros(i + 1)
                            Case "Byte[]"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.Image).Value = Parametros(i + 1)
                            Case "Byte"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.SmallInt).Value = Parametros(i + 1)
                            Case "DateTime"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.DateTime).Value = Parametros(i + 1)
                            Case "Boolean"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.Bit).Value = Parametros(i + 1)
                        End Select
                    Next
                End If
            End With


        Catch ex As Exception
            Beep()
            MsgBox("No se puede ejecutar la consulta", MsgBoxStyle.Critical, "Error")
        End Try

        dtu = New DataTable

        Try
            du.Fill(dtu)
        Catch e As System.Data.SqlClient.SqlException
            MsgBox(e.Message)
        End Try

        du.Dispose()
        Cnx.Close()

        If dtu.Rows.Count > 0 Then

            Return dtu
        Else
            dtu.Dispose()
            Return Nothing
        End If

    End Function

    Public Sub Ejecuta(ByVal sp As String, ByVal ParamArray Parametros() As Object)
        Dim MyTrans As System.Data.SqlClient.SqlTransaction = Nothing
        Dim MyComand As System.Data.SqlClient.SqlCommand
        Dim Cnx As System.Data.SqlClient.SqlConnection = Nothing

        Try
            Cnx = New System.Data.SqlClient.SqlConnection
            Cnx.ConnectionString = ModPOS.BDConexion
            Cnx.Open()
        Catch ex As Exception
            Beep()
            MsgBox("No se puede conectar a la base de datos", MsgBoxStyle.Critical, "Error")
        End Try


        Try

            MyTrans = Cnx.BeginTransaction
            MyComand = New System.Data.SqlClient.SqlCommand(sp, Cnx)
            MyComand.CommandTimeout = ModPOS.myTimeOut
            MyComand.Transaction = MyTrans

            MyComand.CommandType = CommandType.StoredProcedure

            Dim i As Integer

            With MyComand
                If Not Parametros Is Nothing Then
                    For i = 0 To Parametros.Length - 1 Step 2
                        If Not Parametros(i + 1) Is Nothing Then
                            Select Case Parametros(i + 1).GetType.Name
                                Case "DataTable"
                                    MyComand.Parameters.Add(Parametros(i), SqlDbType.Structured).Value = Parametros(i + 1)
                                Case "String"
                                    MyComand.Parameters.Add(Parametros(i), SqlDbType.VarChar).Value = Parametros(i + 1)
                                Case "Int32"
                                    MyComand.Parameters.Add(Parametros(i), SqlDbType.Int).Value = Parametros(i + 1)
                                Case "Double"
                                    MyComand.Parameters.Add(Parametros(i), SqlDbType.Decimal).Value = Parametros(i + 1)
                                Case "Decimal"
                                    MyComand.Parameters.Add(Parametros(i), SqlDbType.Decimal).Value = Parametros(i + 1)
                                Case "Byte"
                                    MyComand.Parameters.Add(Parametros(i), SqlDbType.SmallInt).Value = Parametros(i + 1)
                                Case "Byte[]"
                                    MyComand.Parameters.Add(Parametros(i), SqlDbType.Image).Value = Parametros(i + 1)
                                Case "DateTime"
                                    MyComand.Parameters.Add(Parametros(i), SqlDbType.DateTime).Value = Parametros(i + 1)
                                Case "Boolean"
                                    MyComand.Parameters.Add(Parametros(i), SqlDbType.Bit).Value = Parametros(i + 1)
                            End Select
                        Else
                            If Parametros(i) = "@Logo" OrElse Parametros(i) = "@Publicidad" Then
                                MyComand.Parameters.Add(Parametros(i), SqlDbType.Image).Value = DBNull.Value
                            End If
                        End If
                    Next
                End If
            End With

            MyComand.ExecuteNonQuery()
            MyTrans.Commit()

        Catch ex As System.Data.SqlClient.SqlException
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Try
                MyTrans.Rollback()
            Catch es As System.Data.SqlClient.SqlException
                If Not MyTrans.Connection Is Nothing Then
                    MsgBox("No se puede conectar con la base de datos, no rollback", MessageBoxButtons.OK)
                End If
            End Try

        End Try
        Cnx.Close()

    End Sub

    Public Function Recupera_Consulta(ByVal sp As String) As DataTable
        Dim Cnx As System.Data.SqlClient.SqlConnection = Nothing
        Dim du As System.Data.SqlClient.SqlDataAdapter
        Dim dtu As DataTable

        Cnx = New System.Data.SqlClient.SqlConnection

        Try
            Cnx.ConnectionString = ModPOS.BDConexion
            Cnx.Open()
        Catch ex As Exception
            Beep()
            MsgBox("No se puede conectar a la base de datos", MsgBoxStyle.Critical, "Error")
        End Try

        du = New System.Data.SqlClient.SqlDataAdapter

        Try

            With du
                .SelectCommand = New System.Data.SqlClient.SqlCommand(sp, Cnx)
                .SelectCommand.CommandType = CommandType.Text
                .SelectCommand.CommandTimeout = ModPOS.myTimeOut
            End With

        Catch ex As Exception
            Beep()
            MsgBox("No se puede ejecutar la consulta", MsgBoxStyle.Critical, "Error")
        End Try

        dtu = New DataTable

        Try
            du.Fill(dtu)
        Catch e As System.Data.SqlClient.SqlException
            If e.ErrorCode = -2146232060 Then
                Ejecuta_Consulta("sp_configure 'show advanced options', 1;")
                Ejecuta_Consulta("RECONFIGURE;")
                Ejecuta_Consulta("sp_configure 'Ad Hoc Distributed Queries', 1;")
                Ejecuta_Consulta("RECONFIGURE;")
                MsgBox("No fue posible procesar el archivo, intentelo nuevamente")
            Else
                MsgBox(e.Message)
            End If

        End Try

        du.Dispose()
        Cnx.Close()
        Return dtu

    End Function

    Public Sub Ejecuta_Consulta(ByVal sp As String)

        Dim Cnx As System.Data.SqlClient.SqlConnection = Nothing
        Dim du As System.Data.SqlClient.SqlDataAdapter

        Cnx = New System.Data.SqlClient.SqlConnection

        Try
            Cnx.ConnectionString = ModPOS.BDConexion
            Cnx.Open()
        Catch ex As Exception
            Beep()
            MsgBox("No se puede conectar a la base de datos", MsgBoxStyle.Critical, "Error")
        End Try

        du = New System.Data.SqlClient.SqlDataAdapter

        Try


            With du
                .SelectCommand = New System.Data.SqlClient.SqlCommand(sp, Cnx)
                .SelectCommand.CommandType = CommandType.Text
                .SelectCommand.CommandTimeout = 0
                .SelectCommand.ExecuteNonQuery()
            End With

        Catch ex As Exception
            Beep()
            MsgBox("No se puede ejecutar la consulta", MsgBoxStyle.Critical, "Error")
        End Try

        Cnx.Close()

    End Sub

    Public Function RecuperaImagen(ByVal File As String) As Image
        If System.IO.File.Exists(File) Then
            'Generar un bitmap para el origen

            Dim SourceImage As Bitmap
            Dim SourceToImage As Bitmap
            Dim ImgEncabezado As Image
            Try
                SourceImage = New Bitmap(File)


                ' Generar un bitmap para el resultado
                SourceToImage = New Bitmap(SourceImage.Width, SourceImage.Height)

                ' Generar un objeto Gráfico para el Bitmap resultante
                Dim gr_source As Graphics = Graphics.FromImage(SourceToImage)

                ' Copiar la imagen origen al Bitmap destino
                gr_source.DrawImage(SourceImage, 0, 0, _
                    SourceToImage.Width, _
                    SourceToImage.Height)


                'Muestra imagen origen
                ImgEncabezado = CType(SourceToImage, Image)

                'Liberar recursos
                gr_source.Dispose()

                SourceImage.Dispose()

                Return ImgEncabezado

            Catch ex As Exception
                MessageBox.Show("No se pudo recuperar la imagen del producto", " Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return Nothing
            End Try
        End If
    End Function


#End Region

#Region "Almacenes"


    ' Declaraciones del API para 32 bits
    Private Declare Function GetWindowLong Lib "user32" Alias "GetWindowLongA" _
        (ByVal hwnd As Integer, ByVal nIndex As Integer) As Integer
    Private Declare Function SetWindowLong Lib "user32" Alias "SetWindowLongA" _
        (ByVal hwnd As Integer, ByVal nIndex As Integer, _
         ByVal dwNewLong As Integer) As Integer
    Private Declare Function SetWindowPos Lib "user32" _
        (ByVal hwnd As Integer, ByVal hWndInsertAfter As Integer, _
         ByVal X As Integer, ByVal Y As Integer, _
         ByVal cX As Integer, ByVal cY As Integer, _
         ByVal wFlags As Integer) As Integer


    ' Constantes para usar con el API
    Const GWL_STYLE As Integer = (-16)
    Const WS_THICKFRAME As Integer = &H40000 ' Con borde redimensionable
    Const SWP_DRAWFRAME As Integer = &H20
    Const SWP_NOMOVE As Integer = &H2
    Const SWP_NOSIZE As Integer = &H1
    Const SWP_NOZORDER As Integer = &H4


    'variables de Ventanas

    Public Buscar As FrmBuscar
    Public Principal As FrmLayout
    Public Almacenes As FrmAlmacenes
    Public Superficie As FrmCanvas
    Public CrearAlm As FrmCrearAlm
    Public Zoom As FrmZoom
    Public Duplicar As FrmDuplicarEst

    Public MtoArea As FrmMtoArea
    Public Areas As FrmArea
    Public AsignarEstructura As FrmAsignarEstructura

    Public MtoEstructura As FrmMtoEstructura
    Public Estructuras As FrmEstructura
    Public LargoColumna As FrmLargo
    Public Hueco As FrmHueco

    Public AsignarZona As FrmAsginarZona

    Public MtoPasillo As FrmMtoPasillo
    Public Pasillo As FrmPasillo
    Public AjustarExist As FrmAjustarExist


    Public Almacen_Activo As String

    'Variables para dibujos
    Public vector(1) As Estructura
    Public CpyVector(1) As Estructura
    Public numEst_Vector As Integer = 0
    Public numEst_CpyVector As Integer = -1
    Public EscalaActual As Double = 1
    Public Est_Selected As Integer = -1
    'Public Ult_Cve_Est As Integer


    Public Sub CambiarEstilo(ByVal est As Estructura)
        ' Hacer este control redimensionable, usando el API
        ' Pone o quita el estilo dimensionable
        Dim Style As Integer

        Style = GetWindowLong(est.Handle.ToInt32, GWL_STYLE)
        If (Style And WS_THICKFRAME) = WS_THICKFRAME Then
            ' Si ya lo tiene, lo quita
            Style = Style Xor WS_THICKFRAME
        Else
            ' Si no lo tiene, lo pone
            Style = Style Or WS_THICKFRAME
        End If
        SetWindowLong(est.Handle.ToInt32, GWL_STYLE, Style)
        SetWindowPos(est.Handle.ToInt32, Superficie.Handle.ToInt32, 0, 0, 0, 0, SWP_NOZORDER Or SWP_NOSIZE Or SWP_NOMOVE Or SWP_DRAWFRAME)

    End Sub

    Public Sub CopiaEstructura(ByVal Original As Estructura, ByVal Cant As Integer)
        Dim i As Integer = 0
        Dim ESTClave As String


        While i < Cant

            'ModPOS.Ult_Cve_Est += 1
            ESTClave = ModPOS.obtenerLlave

            ModPOS.numEst_CpyVector += 1

            If ModPOS.numEst_CpyVector >= 2 Then
                ReDim Preserve ModPOS.CpyVector(ModPOS.CpyVector.Length)
            End If


            ModPOS.CpyVector(ModPOS.numEst_CpyVector) = New Estructura(ESTClave, Original.Width, Original.Height)

            With ModPOS.CpyVector(ModPOS.numEst_CpyVector)
                .BackColor = Original.BackColor
                .AREClave = Original.AREClave
                .TSTClave = Original.TSTClave
                .Clave = "Copia " & CStr(ModPOS.numEst_CpyVector + 1)
                .PasilloColoca = Original.PasilloColoca
                .PasilloRecoge = Original.PasilloRecoge
                .TipoRotacion = Original.TipoRotacion
                .Color = Original.Color
                .Alto = Original.Alto
                .Ancho = Original.Ancho
                .Largo = Original.Largo
                .Columnas = Original.Columnas
                .Niveles = Original.Niveles
                .Rotada = Original.Rotada
                .Estado = Original.Estado

            End With

            'ModPOS.redrawClave(ModPOS.CpyVector(ModPOS.numEst_CpyVector), ModPOS.CpyVector(ModPOS.numEst_CpyVector).Clave)

            i += 1


        End While


    End Sub

    Public Sub PegaEstructura2(ByVal p As Point)
        Dim i As Integer = 0
        While i <= ModPOS.numEst_CpyVector

            If ModPOS.numEst_Vector >= 2 Then
                ReDim Preserve vector(vector.Length)
            End If

            ModPOS.vector(ModPOS.numEst_Vector) = New Estructura(ModPOS.CpyVector(i).Name, ModPOS.CpyVector(i).Width, ModPOS.CpyVector(i).Height)

            ModPOS.Superficie.Controls.Add(ModPOS.vector(ModPOS.numEst_Vector))

            AddHandler ModPOS.vector(ModPOS.numEst_Vector).MouseDown, AddressOf ModPOS.Superficie.Control_MouseDown
            AddHandler ModPOS.vector(ModPOS.numEst_Vector).MouseMove, AddressOf ModPOS.Superficie.Control_MouseMove
            AddHandler ModPOS.vector(ModPOS.numEst_Vector).MouseEnter, AddressOf ModPOS.Superficie.Control_MouseEnter
            AddHandler ModPOS.vector(ModPOS.numEst_Vector).SizeChanged, AddressOf ModPOS.Superficie.Control_SizeChanged
            AddHandler ModPOS.vector(ModPOS.numEst_Vector).DoubleClick, AddressOf ModPOS.Superficie.Control_DoubleClick
            AddHandler ModPOS.vector(ModPOS.numEst_Vector).MouseLeave, AddressOf ModPOS.Superficie.Control_MouseLeave

            With ModPOS.vector(ModPOS.numEst_Vector)
                .Location = p
                .OrigenX = CDbl(p.X / ModPOS.EscalaActual)
                .OrigenY = CDbl(p.Y / ModPOS.EscalaActual)
                .Indice = ModPOS.numEst_Vector
                .BackColor = ModPOS.CpyVector(i).BackColor
                .AREClave = ModPOS.CpyVector(i).AREClave
                .TSTClave = ModPOS.CpyVector(i).TSTClave
                .Clave = ModPOS.CpyVector(i).Clave
                .PasilloColoca = ModPOS.CpyVector(i).PasilloColoca
                .PasilloRecoge = ModPOS.CpyVector(i).PasilloRecoge
                .TipoRotacion = ModPOS.CpyVector(i).TipoRotacion
                .Color = ModPOS.CpyVector(i).Color
                .Alto = ModPOS.CpyVector(i).Alto
                .Ancho = ModPOS.CpyVector(i).Ancho
                .Largo = ModPOS.CpyVector(i).Largo
                .Columnas = ModPOS.CpyVector(i).Columnas
                .Niveles = ModPOS.CpyVector(i).Niveles
                ' .CapacidadCarga = ModPOS.CpyVector(i).CapacidadCarga
                .Rotada = ModPOS.CpyVector(i).Rotada
                .Estado = ModPOS.CpyVector(i).Estado
            End With
            ModPOS.Graba_Estructura(ModPOS.vector(ModPOS.numEst_Vector))
            ModPOS.numEst_Vector += 1
            i += 1
        End While



        Dim k As Integer = ModPOS.numEst_CpyVector
        If ModPOS.numEst_CpyVector > -1 Then
            While k >= 0
                ModPOS.CpyVector(k).Dispose()
                k -= 1
            End While
            ReDim ModPOS.CpyVector(1)
            ModPOS.numEst_CpyVector = -1
        End If


    End Sub


    Public Sub PegaEstructura(ByVal p As Point)
        Dim i As Integer = 0
        While i <= ModPOS.numEst_CpyVector
            Dim Punto2 As New Point(p.X + ModPOS.CpyVector(i).Width, p.Y + ModPOS.CpyVector(i).Height)
            ModPOS.Superficie.NuevaEstructura(p, Punto2)
            'Se actualiza el indice que indica la estructura seleccionada.
            ModPOS.Est_Selected = ModPOS.numEst_Vector - 1

            ModPOS.Estructuras = New FrmEstructura

            With ModPOS.Estructuras
                .StartPosition = FormStartPosition.CenterScreen
                .Padre = "Agregar"
                .UiTabPageUbc.Enabled = False
                .Text = "Nueva Estructura de Almacenaje"
                .StartPosition = FormStartPosition.CenterScreen
                .sAlmacen = ModPOS.Almacen_Activo
                .sArea = ModPOS.CpyVector(i).AREClave
                .iTESTClave = ModPOS.CpyVector(i).TSTClave
                .Clave = ModPOS.CpyVector(i).Clave
                .sColoca = ModPOS.CpyVector(i).PasilloColoca
                .sRecoge = ModPOS.CpyVector(i).PasilloRecoge
                .iRotacion = ModPOS.CpyVector(i).TipoRotacion
                .iColor = ModPOS.CpyVector(i).Color
                .dAlto = ModPOS.CpyVector(i).Alto
                .dAncho = ModPOS.CpyVector(i).Ancho
                .dLargo = ModPOS.CpyVector(i).Largo
                .iColumna = ModPOS.CpyVector(i).Columnas
                .iNiveles = ModPOS.CpyVector(i).Niveles
                .Rotada = ModPOS.CpyVector(i).Rotada
                .iEstado = ModPOS.CpyVector(i).Estado
                .dX = CDbl(p.X / ModPOS.EscalaActual)
                .dY = CDbl(p.Y / ModPOS.EscalaActual)
                .iformaEnvioInicial = ModPOS.CpyVector(i).formaEnvioInicial
                .iformaEnviofinal = ModPOS.CpyVector(i).formaEnvioFinal
                .ShowDialog()
            End With

            i += 1
        End While


        Dim k As Integer = ModPOS.numEst_CpyVector
        If ModPOS.numEst_CpyVector > -1 Then
            While k >= 0
                ModPOS.CpyVector(k).Dispose()
                k -= 1
            End While
            ReDim ModPOS.CpyVector(1)
            ModPOS.numEst_CpyVector = -1
        End If


    End Sub



    Public Sub RotarEstructura(ByVal Est As Estructura)
        Dim NvoWidth, NvoHeight As Integer
        Dim Rotar As Boolean
        NvoHeight = Est.Width()
        NvoWidth = Est.Height()
        Rotar = Est.Rotada
        If Rotar Then
            Est.Rotada = False
        Else
            Est.Rotada = True
        End If
        Est.Width = NvoWidth
        Est.Height = NvoHeight


    End Sub

    Public Sub Graba_Layout_Activo()
        If Not ModPOS.Superficie Is Nothing Then
            Dim MyTrans As System.Data.SqlClient.SqlTransaction
            Dim MyComand As System.Data.SqlClient.SqlCommand
            Dim Cnx As System.Data.SqlClient.SqlConnection = Nothing

            Try
                Cnx = New System.Data.SqlClient.SqlConnection
                Cnx.ConnectionString = ModPOS.BDConexion
                Cnx.Open()
            Catch ex As Exception
                Beep()
                MsgBox("No se puede conectar a la base de datos", MsgBoxStyle.Critical, "Error")
            End Try

            MyTrans = Cnx.BeginTransaction
            MyComand = Cnx.CreateCommand()
            MyComand.CommandTimeout = ModPOS.myTimeOut
            MyComand.Transaction = MyTrans

            Try
                If ModPOS.Superficie.CambioTamaño Then
                    MyComand.CommandText = "update Almacen set Escala=" & CStr(ModPOS.Superficie.Escala) & ",Width=" & CStr(ModPOS.Superficie.Width) & ",Height=" & CStr(ModPOS.Superficie.Height) & "where ALMClave=" & "'" & CStr(ModPOS.Superficie.ALMClave) & "'"
                    MyComand.ExecuteNonQuery()
                End If

                Dim i As Integer = 0

                While i < ModPOS.numEst_Vector

                    If ModPOS.vector(i).CambioPosicion Then
                        MyComand.CommandText = "update Estructura set OrigenX=" & CStr(ModPOS.vector(i).OrigenX) & ",OrigenY=" & CStr(ModPOS.vector(i).OrigenY) & "where ESTClave=" & "'" & ModPOS.vector(i).Name & "'"
                        MyComand.ExecuteNonQuery()
                    End If
                    If ModPOS.vector(i).CambioTamaño Then
                        MyComand.CommandText = "update Estructura set Escala=" & CStr(ModPOS.vector(i).Escala) & ",Largo=" & CStr(ModPOS.vector(i).Largo) & ",Ancho=" & CStr(ModPOS.vector(i).Ancho) & ",Width=" & CStr(ModPOS.vector(i).Width) & ",Height=" & CStr(ModPOS.vector(i).Height) & "where ESTClave=" & "'" & ModPOS.vector(i).Name & "'"
                        MyComand.ExecuteNonQuery()
                    End If
                    i += 1
                End While
                MyTrans.Commit()

            Catch ex As Exception
                MsgBox(ex.Message, MessageBoxButtons.OK)
                Try
                    MyTrans.Rollback()
                Catch es As System.Data.SqlClient.SqlException
                    If Not MyTrans.Connection Is Nothing Then
                        MsgBox("No se puede conectar con la base de datos, no rollback", MessageBoxButtons.OK)
                    End If
                End Try

            End Try
            Cnx.Close()

            Dim k As Integer = ModPOS.numEst_Vector - 1
            If ModPOS.numEst_Vector > 0 Then
                While k >= 0
                    ModPOS.vector(k).Dispose()
                    k -= 1
                End While
                ReDim ModPOS.vector(1)
                ModPOS.numEst_Vector = 0
            End If


            'ModPOS.Superficie.Close()
            If ModPOS.Est_Selected > -1 Then
                ModPOS.Est_Selected = -1
            End If
        End If
    End Sub

    Public Sub Graba_Area(ByVal Are As FrmArea)

        ModPOS.Ejecuta("sp_inserta_area", _
                        "@AREClave", Are.AREClave, _
                        "@Clave", Are.Clave, _
                        "@Nombre", Are.Nombre, _
                        "@Tipo", Are.Tipo, _
                        "@Color", Are.Color, _
                        "@Estado", Are.Estado, _
                        "@ALMClave", Are.ALMClave, _
                        "@Usuario", ModPOS.UsuarioActual)
    End Sub

    Public Sub Update_Area(ByVal Are As FrmArea, ByVal Est As Boolean)
        Dim iEst As Integer

        If Est Then
            iEst = 1
        Else
            iEst = 0
        End If

        ModPOS.Ejecuta("sp_actualiza_area", _
                          "@AREClave", Are.AREClave, _
                          "@Nombre", Are.Nombre, _
                          "@Tipo", Are.Tipo, _
                          "@Color", Are.Color, _
                          "@Estado", Are.Estado, _
                        "@Estructura", iEst, _
                        "@ALMClave", Are.ALMClave, _
                          "@Usuario", ModPOS.UsuarioActual)


    End Sub




    Public Sub Update_AREEstructura(ByVal Clave As String, ByVal Color As Integer, ByVal Estructura As String)
        ModPOS.Ejecuta("sp_actualiza_AREEstructura", _
                "@Clave", Clave, _
                "@Color", Color, _
                "@Estructura", Estructura, _
                "@Usuario", ModPOS.UsuarioActual)
    End Sub

    Public Sub Update_Zona(ByVal Est As String, ByVal Pos As String, ByVal Zon As Integer)
        ModPOS.Ejecuta("sp_actualiza_zona", _
                        "@Estructura", Est, _
                        "@Posicion", Pos, _
                        "@Zona", Zon)
    End Sub

    Public Sub Graba_Estructura(ByVal Est As Estructura)
        Dim i, j, k, Posicion, ubicaciones, posiciones_ubc, len1, len2, len3 As Integer
        Dim Porc As Double
        Dim rotada As Int16
        Dim Level As String

        If Est.Rotada Then
            rotada = 1
        Else : rotada = 0
        End If

        Dim MyTrans As System.Data.SqlClient.SqlTransaction = Nothing
        Dim MyComand As System.Data.SqlClient.SqlCommand
        Dim Cnx As System.Data.SqlClient.SqlConnection = Nothing
        Dim dt As DataTable


        Posicion = 0

        dt = ModPOS.Recupera_Tabla("sp_recupera_tipo_estructura", "@TESTClave", UCase(Trim(Est.TSTClave)))

        len1 = dt.Rows(0)("NumDigitEst")
        len2 = dt.Rows(0)("NumDigitPos")
        len3 = dt.Rows(0)("NumDigitUBC")
        ubicaciones = dt.Rows(0)("Num_UBC_HUE")
        posiciones_ubc = dt.Rows(0)("NumeroPosicionesUBC")
        Porc = dt.Rows(0)("Porc_Aprob_Hueco")

        dt.Dispose()

        Try
            Cnx = New System.Data.SqlClient.SqlConnection
            Cnx.ConnectionString = ModPOS.BDConexion
            Cnx.Open()
        Catch ex As Exception
            Beep()
            MsgBox("No se puede conectar a la base de datos", MsgBoxStyle.Critical, "Error")
        End Try


        Try

            MyTrans = Cnx.BeginTransaction
            MyComand = New System.Data.SqlClient.SqlCommand("sp_inserta_estructura", Cnx)
            MyComand.CommandTimeout = ModPOS.myTimeOut
            MyComand.Transaction = MyTrans

            MyComand.CommandType = CommandType.StoredProcedure
            MyComand.Parameters.Add("@ESTClave", SqlDbType.VarChar).Value = Est.Name
            MyComand.Parameters.Add("@ALMClave", SqlDbType.VarChar).Value = Est.ALMClave
            MyComand.Parameters.Add("@AREClave", SqlDbType.VarChar).Value = Est.AREClave
            MyComand.Parameters.Add("@TESTClave", SqlDbType.Int).Value = Est.TSTClave
            MyComand.Parameters.Add("@Clave", SqlDbType.VarChar).Value = Est.Clave
            MyComand.Parameters.Add("@Color", SqlDbType.Int).Value = Est.Color
            MyComand.Parameters.Add("@Escala", SqlDbType.Decimal).Value = Est.Escala
            MyComand.Parameters.Add("@OrigenX", SqlDbType.Decimal).Value = Est.OrigenX
            MyComand.Parameters.Add("@OrigenY", SqlDbType.Decimal).Value = Est.OrigenY
            MyComand.Parameters.Add("@Width", SqlDbType.Int).Value = Est.Width
            MyComand.Parameters.Add("@Height", SqlDbType.Int).Value = Est.Height
            MyComand.Parameters.Add("@Largo", SqlDbType.Decimal).Value = Est.Largo
            MyComand.Parameters.Add("@Ancho", SqlDbType.Decimal).Value = Est.Ancho
            MyComand.Parameters.Add("@Alto", SqlDbType.Decimal).Value = Est.Alto
            MyComand.Parameters.Add("@Columnas", SqlDbType.Int).Value = Est.Columnas
            MyComand.Parameters.Add("@Niveles", SqlDbType.Int).Value = Est.Niveles
            ' MyComand.Parameters.Add("@CapacidadCarga", SqlDbType.Decimal).Value = Est.CapacidadCarga
            MyComand.Parameters.Add("@TipoRotacion", SqlDbType.Int).Value = Est.TipoRotacion
            MyComand.Parameters.Add("@PasilloColoca", SqlDbType.VarChar).Value = Est.PasilloColoca
            MyComand.Parameters.Add("@PasilloRecoge", SqlDbType.VarChar).Value = Est.PasilloRecoge
            MyComand.Parameters.Add("@Rotada", SqlDbType.Bit).Value = rotada

            MyComand.Parameters.Add("@formaEnvioInicial", SqlDbType.Int).Value = Est.formaEnvioInicial
            MyComand.Parameters.Add("@formaEnvioFinal", SqlDbType.Int).Value = Est.formaEnvioFinal
            MyComand.Parameters.Add("@Estado", SqlDbType.SmallInt).Value = Est.Estado
            MyComand.Parameters.Add("@SecuenciaRecoleccion", SqlDbType.Int).Value = Est.SecuenciaRecoleccion

            MyComand.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = ModPOS.UsuarioActual

            MyComand.ExecuteNonQuery()


            For i = 1 To Est.Niveles
                Level = Chr(i + 64)
                For j = 1 To Est.Columnas
                    Posicion += 1
                    'inserta posiciones
                    MyComand = New System.Data.SqlClient.SqlCommand("sp_inserta_hueco", Cnx)
                    MyComand.Transaction = MyTrans
                    MyComand.CommandTimeout = ModPOS.myTimeOut
                    MyComand.CommandType = CommandType.StoredProcedure
                    MyComand.Parameters.Add("@HUEClave", SqlDbType.VarChar).Value = CStr(Posicion)
                    MyComand.Parameters.Add("@ESTClave", SqlDbType.VarChar).Value = Est.Name
                    MyComand.Parameters.Add("@Columna", SqlDbType.Int).Value = j
                    MyComand.Parameters.Add("@Nivel", SqlDbType.Int).Value = i
                    MyComand.Parameters.Add("@Largo", SqlDbType.Decimal).Value = Est.Largo / Est.Columnas
                    MyComand.Parameters.Add("@Ancho", SqlDbType.Decimal).Value = Est.Ancho
                    MyComand.Parameters.Add("@Alto", SqlDbType.Decimal).Value = Est.Alto / Est.Niveles
                    MyComand.Parameters.Add("@Porcentaje", SqlDbType.Decimal).Value = Porc
                    MyComand.Parameters.Add("@cNivel", SqlDbType.VarChar).Value = Level
                    MyComand.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = ModPOS.UsuarioActual

                    MyComand.ExecuteNonQuery()

                    For k = 1 To ubicaciones

                        'inserta ubicaciones 
                        MyComand = New System.Data.SqlClient.SqlCommand("sp_inserta_ubicacion", Cnx)
                        MyComand.Transaction = MyTrans
                        MyComand.CommandTimeout = ModPOS.myTimeOut
                        MyComand.CommandType = CommandType.StoredProcedure
                        MyComand.Parameters.Add("@ESTClave", SqlDbType.VarChar).Value = Est.Name
                        MyComand.Parameters.Add("@Clave", SqlDbType.VarChar).Value = Est.Clave
                        MyComand.Parameters.Add("@HUEClave", SqlDbType.VarChar).Value = CStr(Posicion)
                        MyComand.Parameters.Add("@Ubicacion", SqlDbType.VarChar).Value = CStr(k)
                        MyComand.Parameters.Add("@len1", SqlDbType.Int).Value = len1
                        MyComand.Parameters.Add("@len2", SqlDbType.Int).Value = len2
                        MyComand.Parameters.Add("@len3", SqlDbType.Int).Value = len3
                        MyComand.Parameters.Add("@cNivel", SqlDbType.VarChar).Value = Level
                        MyComand.Parameters.Add("@Columna", SqlDbType.Int).Value = j
                        MyComand.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = ModPOS.UsuarioActual
                        MyComand.ExecuteNonQuery()



                    Next
                Next
            Next
            MyTrans.Commit()

        Catch ex As System.Data.SqlClient.SqlException
            MsgBox(ex.Message, MessageBoxButtons.OK)
            Try
                MyTrans.Rollback()
            Catch es As System.Data.SqlClient.SqlException
                If Not MyTrans.Connection Is Nothing Then
                    MsgBox("No se puede conectar con la base de datos, no rollback", MessageBoxButtons.OK)
                End If
            End Try

        End Try
        Cnx.Close()

    End Sub

    Public Sub Graba_Superficie(ByVal Sup As FrmCanvas)
        ModPOS.Ejecuta("sp_inserta_almacen", _
                    "@ALMClave", Sup.ALMClave, _
                    "@Clave", Sup.Referencia, _
                    "@Nombre", Sup.Nombre, _
                    "@Escala", Sup.Escala, _
                    "@Width", Sup.Width, _
                    "@Height", Sup.Height, _
                    "@Largo", Sup.Largo, _
                    "@Ancho", Sup.Ancho, _
                    "@Alto", Sup.Alto, _
                    "@SUCClave", Sup.SUCClave, _
                    "@BloqueoVta", Sup.BloqueoVta, _
                    "@Predeterminado", Sup.Predeterminado, _
                    "@TipoSurtido", Sup.TipoSurtido, _
                    "@Usuario", ModPOS.UsuarioActual)
    End Sub

    Public Sub Update_Almacen(ByVal Alm As FrmCrearAlm)
        ModPOS.Ejecuta("sp_actualiza_almacen", _
                  "@ALMClave", Alm.ALMClave, _
                   "@Nombre", Alm.Nombre, _
                    "@Largo", Alm.Largo, _
                    "@Ancho", Alm.Ancho, _
                    "@Alto", Alm.Alto, _
                    "@Width", CInt(Alm.Largo * Alm.Escala), _
                    "@Height", CInt(Alm.Ancho * Alm.Escala), _
                    "@Estado", Alm.Estado, _
                    "@SUCClave", Alm.SUCClave, _
                    "@BloqueoVta", Alm.BloqueoVta, _
                    "@Predeterminado", Alm.Predeterminado, _
                    "@TipoSurtido", Alm.TipoSurtido, _
                    "@Usuario", ModPOS.UsuarioActual)
    End Sub

    Public Sub Update_Estructura(ByVal Est As FrmEstructura, ByVal Clave As String, ByVal Ancho As Boolean)
        Dim Rotar, Huecos As Integer

        If Est.Rotada Then
            Rotar = 1
        Else
            Rotar = 0
        End If


        If Ancho Then
            Huecos = 1
        Else
            Huecos = 0
        End If


        ModPOS.Ejecuta("sp_actualiza_estructura", _
                    "@ESTClave", Clave, _
                    "@Rotada", Rotar, _
                    "@WidthHeight", CInt(Est.dAncho * ModPOS.EscalaActual), _
                    "@AREClave", Est.sArea, _
                    "@Color", Est.iColor, _
                    "@Clave", Est.ID, _
                    "@PasilloColoca", Est.sColoca, _
                    "@PasilloRecoge", Est.sRecoge, _
                    "@TipoRotacion", Est.iRotacion, _
                    "@Ancho", Est.dAncho, _
                    "@OrigenX", Est.dX, _
                    "@OrigenY", Est.dY, _
                    "@Hueco", Huecos, _
                    "@formaEnvioInicial", Est.iformaEnvioInicial, _
                    "@formaEnvioFinal", Est.iformaEnviofinal, _
                    "@SecuenciaRecoleccion", Est.iSecuenciaRecoleccion, _
                    "@Usuario", ModPOS.UsuarioActual)

    End Sub

    Public Function RecuperaPosiciones(ByVal Est As String) As Integer
        Dim Cnx As System.Data.SqlClient.SqlConnection = Nothing
        Dim da As System.Data.SqlClient.SqlDataAdapter
        Dim dt As DataTable
        Dim iPosiciones As Integer


        Cnx = New System.Data.SqlClient.SqlConnection

        Try
            Cnx.ConnectionString = ModPOS.BDConexion
            Cnx.Open()
        Catch ex As Exception
            Beep()
            MsgBox("No se puede conectar a la base de datos", MsgBoxStyle.Critical, "Error")
        End Try

        da = New System.Data.SqlClient.SqlDataAdapter

        Try
            With da
                .SelectCommand = New System.Data.SqlClient.SqlCommand("sp_recupera_posiciones", Cnx)
                .SelectCommand.CommandTimeout = ModPOS.myTimeOut
                .SelectCommand.CommandType = CommandType.StoredProcedure
                .SelectCommand.Parameters.Add("@Estructura", SqlDbType.VarChar).Value = Est

            End With

        Catch ex As Exception
            Beep()
            MsgBox("No se puede ejecutar la consulta", MsgBoxStyle.Critical, "Error")
        End Try

        dt = New DataTable

        Try
            da.Fill(dt)
        Catch e As System.Data.SqlClient.SqlException
            MsgBox(e.Message)
        End Try

        iPosiciones = dt.Rows(0)("Posiciones")

        dt.Dispose()
        da.Dispose()
        Cnx.Close()
        Return iPosiciones

    End Function


    Public Sub InsertaUbicacion(ByVal sESTClave As String, ByVal sClave As String, ByVal sHUEClave As String, ByVal sTipo As String)
        Dim len1, len2, len3 As Integer
        Dim dt As DataTable

        dt = ModPOS.Recupera_Tabla("sp_recupera_tipo_estructura", "@TESTClave", sTipo)

        len1 = dt.Rows(0)("NumDigitEst")
        len2 = dt.Rows(0)("NumDigitPos")
        len3 = dt.Rows(0)("NumDigitUBC")

        dt.Dispose()

        Dim iUltimaUbicacion As Integer
        Dim iColumna As Integer
        Dim sNivel As String
        If sHUEClave = "" Then
            iColumna = 0
            sNivel = ""
        Else
            iColumna = CInt(Split(sHUEClave, "-")(0))
            sNivel = Split(sHUEClave, "-")(1)
        End If

        dt = ModPOS.Recupera_Tabla("sp_recupera_hueco", "@ESTClave", sESTClave, "@Columna", iColumna, "@cNivel", sNivel)
        If dt.Rows.Count = 1 Then
            sHUEClave = dt.Rows(0)("HUEClave")
        End If
        dt.Dispose()

        iUltimaUbicacion = ModPOS.SiExite(ModPOS.BDConexion, "sp_ultima_ubicacion", "@Estructura", sESTClave, "@Columna", iColumna, "@cNivel", sNivel)
        iUltimaUbicacion += 1

        ModPOS.Ejecuta("sp_inserta_ubicacion", _
        "@Clave", sClave, _
        "@HUEClave", sHUEClave, _
        "@ESTClave", sESTClave, _
        "@Ubicacion", iUltimaUbicacion, _
        "@len1", len1, _
        "@len2", len2, _
        "@len3", len3, _
        "@cNivel", sNivel, _
        "@Columna", iColumna, _
        "@Usuario", ModPOS.UsuarioActual)


    End Sub

    Public Sub Graba_Pasillo(ByVal Pas As FrmPasillo)

        ModPOS.Ejecuta("sp_inserta_pasillo", _
                    "@PASClave", Pas.PASClave, _
                    "@Clave", Pas.Referencia, _
                    "@Nombre", Pas.Nombre, _
                    "@Estado", Pas.Estado, _
                    "@Almacen", Pas.ALMClave, _
                    "@Usuario", ModPOS.UsuarioActual)
    End Sub


    Public Sub Update_Pasillo(ByVal Pas As FrmPasillo)
        ModPOS.Ejecuta("sp_actualiza_pasillo", _
                    "@PASClave", Pas.PASClave, _
                    "@Nombre", Pas.Nombre, _
                    "@Estado", Pas.Estado, _
                    "@Almacen", Pas.ALMClave, _
                    "@Usuario", ModPOS.UsuarioActual)
    End Sub


    Public Sub Update_Hueco(ByVal Hue As FrmHueco)

        Dim MyTrans As System.Data.SqlClient.SqlTransaction
        Dim MyComand As System.Data.SqlClient.SqlCommand
        Dim Cnx As System.Data.SqlClient.SqlConnection = Nothing

        Try
            Cnx = New System.Data.SqlClient.SqlConnection
            Cnx.ConnectionString = ModPOS.BDConexion
            Cnx.Open()
        Catch ex As Exception
            Beep()
            MsgBox("No se puede conectar a la base de datos", MsgBoxStyle.Critical, "Error")
        End Try

        MyTrans = Cnx.BeginTransaction
        MyComand = Cnx.CreateCommand()
        MyComand.CommandTimeout = ModPOS.myTimeOut
        MyComand.Transaction = MyTrans

        Try
            '            MyComand.CommandText = "Update Hueco set CapacidadCarga=" & CStr(Hue.dCarga) & ", CargaDisponible=" & CStr(Hue.dCarga) & ", Alto=" & CStr(Hue.dAlto) & ", Volumen= Largo*Ancho*" & CStr(Hue.dAlto) & ", VolumenDisponible=Largo*Ancho*" & CStr(Hue.dAlto) & ",Porc_Apro_Vol=" & CStr(Hue.iPorc) & ",Estado=" & CStr(Hue.iEstado) & " , MFechaHora= getdate(), MUsuarioId='" & ModPOS.UsuarioActual & "'where HueClave='" & Hue.sHueco & "' and ESTClave='" & Hue.sEstructura & "'"
            MyComand.CommandText = "Update Hueco set Alto=" & CStr(Hue.dAlto) & ",Porcentaje=" & CStr(Hue.iPorc) & ",Estado=" & CStr(Hue.iEstado) & " , MFechaHora= getdate(), MUsuarioId='" & ModPOS.UsuarioActual & "'where HueClave='" & Hue.sHueco & "' and ESTClave='" & Hue.sEstructura & "'"

            MyComand.ExecuteNonQuery()

            MyTrans.Commit()

        Catch ex As System.Data.SqlClient.SqlException
            MsgBox(ex.Message, MessageBoxButtons.OK)
            Try
                MyTrans.Rollback()
            Catch es As System.Data.SqlClient.SqlException
                If Not MyTrans.Connection Is Nothing Then
                    MsgBox("No se puede conectar con la base de datos, no rollback", MessageBoxButtons.OK)
                End If
            End Try

        End Try
        Cnx.Close()

    End Sub

    Public Sub InsertaFila(ByVal Est As Estructura)
        Dim i, j, k, Posicion, ubicaciones, posiciones_ubc, len1, len2, len3, Porc As Integer

        Dim MyTrans As System.Data.SqlClient.SqlTransaction
        Dim MyComand As System.Data.SqlClient.SqlCommand
        Dim Cnx As System.Data.SqlClient.SqlConnection = Nothing
        Dim dt As DataTable

        Posicion = RecuperaPosiciones(Est.Name)

        dt = ModPOS.Recupera_Tabla("sp_recupera_tipo_estructura", "@TESTClave", UCase(Trim(Est.TSTClave)))

        len1 = dt.Rows(0)("NumDigitEst")
        len2 = dt.Rows(0)("NumDigitPos")
        len3 = dt.Rows(0)("NumDigitUBC")
        ubicaciones = dt.Rows(0)("Num_UBC_HUE")
        posiciones_ubc = dt.Rows(0)("NumeroPosicionesUBC")
        Porc = dt.Rows(0)("Porc_Aprob_Hueco")
        dt.Dispose()

        Try
            Cnx = New System.Data.SqlClient.SqlConnection
            Cnx.ConnectionString = ModPOS.BDConexion
            Cnx.Open()
        Catch ex As Exception
            Beep()
            MsgBox("No se puede conectar a la base de datos", MsgBoxStyle.Critical, "Error")
        End Try


        MyTrans = Cnx.BeginTransaction
        MyComand = Cnx.CreateCommand()
        MyComand.CommandTimeout = ModPOS.myTimeOut
        MyComand.Transaction = MyTrans

        'Dim NuevaCarga As Double
        Dim NuevaAltura As Double

        'NuevaCarga = Est.CapacidadCarga + (Est.CapacidadCarga / (Est.Niveles * Est.Columnas)) * Est.Columnas
        NuevaAltura = Est.Alto + (Est.Alto / Est.Niveles)

        Try
            MyComand.CommandText = "update Estructura set Niveles =" & CStr(Est.Niveles + 1) & ",Alto=" & CStr(NuevaAltura) & ",MFechaHora= getdate(),MUsuarioId='" & ModPOS.UsuarioActual & "' where ESTClave=" & "'" & Est.Name & "'"
            MyComand.ExecuteNonQuery()


            i = Est.Niveles + 1
            For j = 1 To Est.Columnas
                Posicion += 1
                'inserta posiciones
                ' MyComand.CommandText = "insert into Hueco (HueClave,ESTClave,Columna,Nivel,Largo,Ancho,Alto,Volumen,CapacidadCarga,CargaDisponible,VolumenDisponible,Porc_Apro_Vol,Estado,Baja,MFechaHora,MUsuarioId) values (" & "'" & CStr(Posicion) & "'" & "," & "'" & Est.Name & "'" & "," & CStr(j) & "," & CStr(i) & "," & CStr(Est.Largo / Est.Columnas) & "," & CStr(Est.Ancho) & "," & CStr(Est.Alto / Est.Niveles) & "," & CStr((Est.Largo / Est.Columnas) * (Est.Alto / Est.Niveles) * Est.Ancho) & "," & CStr(Est.CapacidadCarga / (Est.Niveles * Est.Columnas)) & "," & CStr(Est.CapacidadCarga / (Est.Niveles * Est.Columnas)) & "," & CStr((Est.Largo / Est.Columnas) * (Est.Alto / Est.Niveles) * Est.Ancho) & "," & CStr(Porc) & ",1,0,getdate()," & "'" & ModPOS.UsuarioActual & "')"
                MyComand.CommandText = "insert into Hueco (HueClave,ESTClave,Columna,Nivel,Largo,Ancho,Alto,Porcentaje,Estado,MFechaHora,MUsuarioId) values (" & "'" & CStr(Posicion) & "'" & "," & "'" & Est.Name & "'" & "," & CStr(j) & "," & CStr(i) & "," & CStr(Est.Largo / Est.Columnas) & "," & CStr(Est.Ancho) & "," & CStr(Est.Alto / Est.Niveles) & "," & Porc & ",1,getdate()," & "'" & ModPOS.UsuarioActual & "')"

                MyComand.ExecuteNonQuery()

                For k = 1 To ubicaciones

                    'inserta ubicaciones 
                    'MyComand.CommandText = "insert into Ubicacion (UBCClave,ESTClave,HueClave,NumeroPosiciones,Num_Pos_Disponible,Estado,Baja,MFechaHora,MUsuarioId) values (" & "RIGHT('000000' + convert (varchar," & CInt(Est.Name) & ")," & CStr(len1) & ") + RIGHT('000000' + convert (varchar," & CStr(Posicion) & ")," & CStr(len2) & " ) + RIGHT('000000' + convert (varchar," & CStr(k) & ")," & CStr(len3) & "),'" & Est.Name & "','" & CStr(Posicion) & "'," & CStr(posiciones_ubc) & "," & CStr(posiciones_ubc) & ",1,0,getdate(),'" & ModPOS.UsuarioActual & "')"

                    MyComand.CommandText = "insert into Ubicacion (UBCClave,ESTClave,HueClave,Estado,Fase,MFechaHora,MUsuarioId) values (" & "RIGHT('000000' + convert (varchar," & CInt(Est.Name) & ")," & CStr(len1) & ") + RIGHT('000000' + convert (varchar," & CStr(Posicion) & ")," & CStr(len2) & " ) + RIGHT('000000' + convert (varchar," & CStr(k) & ")," & CStr(len3) & "),'" & Est.Name & "','" & CStr(Posicion) & "',1,1,getdate(),'" & ModPOS.UsuarioActual & "')"
                    MyComand.ExecuteNonQuery()

                Next
            Next

            Est.Niveles += 1
            '       Est.CapacidadCarga = NuevaCarga
            Est.Alto = NuevaAltura

            MyTrans.Commit()

        Catch ex As System.Data.SqlClient.SqlException
            MsgBox(ex.Message, MessageBoxButtons.OK)
            Try
                MyTrans.Rollback()
            Catch es As System.Data.SqlClient.SqlException
                If Not MyTrans.Connection Is Nothing Then
                    MsgBox("No se puede conectar con la base de datos, no rollback", MessageBoxButtons.OK)
                End If
            End Try

        End Try
        Cnx.Close()

    End Sub

    Public Sub InsertaColumna(ByVal Est As Estructura)
        Dim i, j, k, Posicion, ubicaciones, posiciones_ubc, len1, len2, len3, Porc As Integer

        Dim MyTrans As System.Data.SqlClient.SqlTransaction
        Dim MyComand As System.Data.SqlClient.SqlCommand
        Dim Cnx As System.Data.SqlClient.SqlConnection = Nothing
        Dim dt As DataTable


        Posicion = RecuperaPosiciones(Est.Name)

        dt = ModPOS.Recupera_Tabla("sp_recupera_tipo_estructura", "@TESTClave", UCase(Trim(Est.TSTClave)))

        len1 = dt.Rows(0)("NumDigitEst")
        len2 = dt.Rows(0)("NumDigitPos")
        len3 = dt.Rows(0)("NumDigitUBC")
        ubicaciones = dt.Rows(0)("Num_UBC_HUE")
        posiciones_ubc = dt.Rows(0)("NumeroPosicionesUBC")
        Porc = dt.Rows(0)("Porc_Aprob_Hueco")

        dt.Dispose()

        Try
            Cnx = New System.Data.SqlClient.SqlConnection
            Cnx.ConnectionString = ModPOS.BDConexion
            Cnx.Open()
        Catch ex As Exception
            Beep()
            MsgBox("No se puede conectar a la base de datos", MsgBoxStyle.Critical, "Error")
        End Try

        MyTrans = Cnx.BeginTransaction
        MyComand = Cnx.CreateCommand()
        MyComand.CommandTimeout = ModPOS.myTimeOut
        MyComand.Transaction = MyTrans

        ' Dim NuevaCarga As Double
        Dim NuevoLargo As Double



        'NuevaCarga = Est.CapacidadCarga + (Est.CapacidadCarga / (Est.Niveles * Est.Columnas)) * Est.Niveles
        NuevoLargo = Est.Largo + (Est.Largo / Est.Columnas)

        Try
            If Est.Rotada Then
                Est.Height = CInt(NuevoLargo * Est.Escala)
                MyComand.CommandText = "update Estructura set Columnas =" & CStr(Est.Columnas + 1) & ",Largo=" & CStr(NuevoLargo) & ", Heigth=" & CStr(Est.Height) & ",MFechaHora= getdate(),MUsuarioId='" & ModPOS.UsuarioActual & "' where ESTClave=" & "'" & Est.Name & "'"
                MyComand.ExecuteNonQuery()

            Else
                Est.Width = CInt(NuevoLargo * Est.Escala)
                MyComand.CommandText = "update Estructura set Columnas =" & CStr(Est.Columnas + 1) & ",Largo=" & CStr(NuevoLargo) & ", Width=" & CStr(Est.Width) & ",MFechaHora= getdate(),MUsuarioId='" & ModPOS.UsuarioActual & "' where ESTClave=" & "'" & Est.Name & "'"
                MyComand.ExecuteNonQuery()

            End If


            j = Est.Columnas + 1
            For i = 1 To Est.Niveles
                Posicion += 1
                'inserta posiciones
                'MyComand.CommandText = "insert into Hueco (HueClave,ESTClave,Columna,Nivel,Largo,Ancho,Alto,Volumen,VolumenDisponible,Porc_Apro_Vol,Estado,Baja,MFechaHora,MUsuarioId) values (" & "'" & CStr(Posicion) & "'" & "," & "'" & Est.Name & "'" & "," & CStr(j) & "," & CStr(i) & "," & CStr(Est.Largo / Est.Columnas) & "," & CStr(Est.Ancho) & "," & CStr(Est.Alto / Est.Niveles) & "," & CStr((Est.Largo / Est.Columnas) * (Est.Alto / Est.Niveles) * Est.Ancho) & "," & CStr((Est.Largo / Est.Columnas) * (Est.Alto / Est.Niveles) * Est.Ancho) & "," & CStr(Porc) & ",1,0,getdate()," & "'" & ModPOS.UsuarioActual & "')"
                MyComand.CommandText = "insert into Hueco (HueClave,ESTClave,Columna,Nivel,Largo,Ancho,Alto,Porcentaje,Estado,MFechaHora,MUsuarioId) values (" & "'" & CStr(Posicion) & "'" & "," & "'" & Est.Name & "'" & "," & CStr(j) & "," & CStr(i) & "," & CStr(Est.Largo / Est.Columnas) & "," & CStr(Est.Ancho) & "," & CStr(Est.Alto / Est.Niveles) & "," & Porc & ",1,getdate()," & "'" & ModPOS.UsuarioActual & "')"

                MyComand.ExecuteNonQuery()

                For k = 1 To ubicaciones

                    'inserta ubicaciones 
                    'MyComand.CommandText = "insert into Ubicacion (UBCClave,ESTClave,HueClave,NumeroPosiciones,Num_Pos_Disponible,Estado,Baja,MFechaHora,MUsuarioId) values (" & "RIGHT('000000' + convert (varchar," & CInt(Est.Name) & ")," & CStr(len1) & ") + RIGHT('000000' + convert (varchar," & CStr(Posicion) & ")," & CStr(len2) & " ) + RIGHT('000000' + convert (varchar," & CStr(k) & ")," & CStr(len3) & "),'" & Est.Name & "','" & CStr(Posicion) & "'," & CStr(posiciones_ubc) & "," & CStr(posiciones_ubc) & ",1,0,getdate(),'" & ModPOS.UsuarioActual & "')"
                    MyComand.CommandText = "insert into Ubicacion (UBCClave,ESTClave,HueClave,Estado,Fase,MFechaHora,MUsuarioId) values (" & "RIGHT('000000' + convert (varchar," & CInt(Est.Name) & ")," & CStr(len1) & ") + RIGHT('000000' + convert (varchar," & CStr(Posicion) & ")," & CStr(len2) & " ) + RIGHT('000000' + convert (varchar," & CStr(k) & ")," & CStr(len3) & "),'" & Est.Name & "','" & CStr(Posicion) & "',1,1,getdate(),'" & ModPOS.UsuarioActual & "')"

                    MyComand.ExecuteNonQuery()

                Next
            Next
            Est.Columnas += 1
            '   Est.CapacidadCarga = NuevaCarga
            Est.Largo = NuevoLargo
            MyTrans.Commit()

        Catch ex As System.Data.SqlClient.SqlException
            MsgBox(ex.Message, MessageBoxButtons.OK)
            Try
                MyTrans.Rollback()
            Catch es As System.Data.SqlClient.SqlException
                If Not MyTrans.Connection Is Nothing Then
                    MsgBox("No se puede conectar con la base de datos, no rollback", MessageBoxButtons.OK)
                End If
            End Try

        End Try
        Cnx.Close()

    End Sub

    Public Sub EliminaFila(ByVal Est As Estructura)
        Dim MyTrans As System.Data.SqlClient.SqlTransaction
        Dim MyComand As System.Data.SqlClient.SqlCommand
        Dim Cn As System.Data.SqlClient.SqlConnection = Nothing
        Dim Con As String = ModPOS.BDConexion

        If ModPOS.SiExite(Con, "sp_fila_vacia", "@Estructura", Est.Name, "@Fila", CStr(Est.Niveles)) = 0 Then

            Try
                Cn = New System.Data.SqlClient.SqlConnection
                Cn.ConnectionString = ModPOS.BDConexion
                Cn.Open()
            Catch ex As Exception
                Beep()
                MsgBox("No se puede conectar a la base de datos", MsgBoxStyle.Critical, "Error")
            End Try

            MyTrans = Cn.BeginTransaction
            MyComand = Cn.CreateCommand()
            MyComand.Transaction = MyTrans

            Try
                MyComand.CommandText = "update Ubicacion set Estado=0,MFechaHora= getdate(),MUsuarioId='" & ModPOS.UsuarioActual & "' where Estado=1 and ESTClave ='" & Est.Name & "' and HueClave in (select HueClave from Hueco where Estado= 1 and ESTClave='" & Est.Name & "' and Nivel=" & CStr(Est.Niveles) & ")"
                MyComand.ExecuteNonQuery()

                MyComand.CommandText = "update Hueco set Estado=0,MFechaHora= getdate(),MUsuarioId='" & ModPOS.UsuarioActual & "'  where Estado=1 and ESTClave='" & Est.Name & "' and Nivel=" & CStr(Est.Niveles)
                MyComand.ExecuteNonQuery()

                ' Dim NuevaCarga As Double
                Dim NuevaAltura As Double

                'NuevaCarga = Est.CapacidadCarga - (Est.CapacidadCarga / (Est.Niveles * Est.Columnas)) * Est.Columnas
                NuevaAltura = Est.Alto - (Est.Alto / Est.Niveles)

                Est.Niveles -= 1

                MyComand.CommandText = "Update Estructura set Niveles =" & CStr(Est.Niveles) & ",Alto=" & CStr(NuevaAltura) & ",MFechaHora= getdate(),MUsuarioId='" & ModPOS.UsuarioActual & "'  where ESTClave=" & Est.Name
                MyComand.ExecuteNonQuery()

                'Est.CapacidadCarga = NuevaCarga
                Est.Alto = NuevaAltura

                MyTrans.Commit()

            Catch ex As System.Data.SqlClient.SqlException
                MsgBox(ex.Message, MessageBoxButtons.OK)
                Try
                    MyTrans.Rollback()
                Catch es As System.Data.SqlClient.SqlException
                    If Not MyTrans.Connection Is Nothing Then
                        MsgBox("No se puede conectar con la base de datos, no rollback", MessageBoxButtons.OK)
                    End If
                End Try

            End Try
            Cn.Close()

        Else
            MsgBox("No es posible eliminar la columna debido a que existen ubicaciones ocupadas", MessageBoxButtons.OK)
        End If
    End Sub

    Public Sub EliminaColumna(ByVal Est As Estructura)
        Dim MyTrans As System.Data.SqlClient.SqlTransaction
        Dim MyComand As System.Data.SqlClient.SqlCommand
        Dim Cn As System.Data.SqlClient.SqlConnection = Nothing
        Dim Con As String = ModPOS.BDConexion
        If ModPOS.SiExite(Con, "sp_columna_vacia", "@Estructura", Est.Name, "@Columna", CStr(Est.Columnas)) = 0 Then

            Try
                Cn = New System.Data.SqlClient.SqlConnection
                Cn.ConnectionString = ModPOS.BDConexion
                Cn.Open()
            Catch ex As Exception
                Beep()
                MsgBox("No se puede conectar a la base de datos", MsgBoxStyle.Critical, "Error")
            End Try

            MyTrans = Cn.BeginTransaction
            MyComand = Cn.CreateCommand()
            MyComand.CommandTimeout = ModPOS.myTimeOut
            MyComand.Transaction = MyTrans

            Try
                MyComand.CommandText = "update Ubicacion set Estado=0,MFechaHora= getdate(),MUsuarioId='" & ModPOS.UsuarioActual & "' where Estado=1 and ESTClave ='" & Est.Name & "' and HueClave in (select HueClave from Hueco where Estado= 1 and ESTClave='" & Est.Name & "' and Columna=" & CStr(Est.Columnas) & ")"
                MyComand.ExecuteNonQuery()

                MyComand.CommandText = "update Hueco set Estado=0,MFechaHora= getdate(),MUsuarioId='" & ModPOS.UsuarioActual & "'  where Estado=1 and ESTClave='" & Est.Name & "' and Columna=" & CStr(Est.Columnas)
                MyComand.ExecuteNonQuery()

                '      Dim NuevaCarga As Double
                Dim NuevoLargo As Double

                '     NuevaCarga = Est.CapacidadCarga - (Est.CapacidadCarga / (Est.Niveles * Est.Columnas)) * Est.Niveles
                NuevoLargo = Est.Largo - (Est.Largo / Est.Columnas)
                Est.Columnas -= 1

                If Est.Rotada Then

                    Est.Height = CInt(NuevoLargo * Est.Escala)
                    MyComand.CommandText = "update estructura set columnas =" & CStr(Est.Columnas) & ",Largo=" & CStr(NuevoLargo) & ", Height=" & CStr(Est.Height) & ",MFechaHora= getdate(),MUsuarioId='" & ModPOS.UsuarioActual & "'  where ESTClave=" & Est.Name
                    MyComand.ExecuteNonQuery()
                Else
                    Est.Width = CInt(NuevoLargo * Est.Escala)
                    MyComand.CommandText = "update estructura set columnas =" & CStr(Est.Columnas) & ",Largo=" & CStr(NuevoLargo) & ", Width=" & CStr(Est.Width) & ",MFechaHora= getdate(),MUsuarioId='" & ModPOS.UsuarioActual & "'  where ESTClave=" & Est.Name
                    MyComand.ExecuteNonQuery()

                End If



                'Est.CapacidadCarga = NuevaCarga
                Est.Largo = NuevoLargo
                MyTrans.Commit()

            Catch ex As System.Data.SqlClient.SqlException
                MsgBox(ex.Message, MessageBoxButtons.OK)
                Try
                    MyTrans.Rollback()
                Catch es As System.Data.SqlClient.SqlException
                    If Not MyTrans.Connection Is Nothing Then
                        MsgBox("No se puede conectar con la base de datos, no rollback", MessageBoxButtons.OK)
                    End If
                End Try

            End Try
            Cn.Close()

        Else
            MsgBox("No es posible eliminar la columna debido a que existen ubicaciones ocupadas", MessageBoxButtons.OK)
        End If
    End Sub

    Public Sub Elimina_Pasillo(ByVal Pas As String)
        ModPOS.Ejecuta("sp_elimina_pasillo", _
                "@Pasillo", Pas, _
                "@Usuario", ModPOS.UsuarioActual)
    End Sub
    Public Sub Elimina_Area(ByVal Are As String)
        ModPOS.Ejecuta("sp_elimina_area", _
          "@Area", Are, _
           "@Usuario", ModPOS.UsuarioActual)
    End Sub

    Public Sub Elimina_Estructura(ByVal Est As String)
        Dim MyTrans As System.Data.SqlClient.SqlTransaction = Nothing
        Dim MyComand As System.Data.SqlClient.SqlCommand
        Dim Cnx As System.Data.SqlClient.SqlConnection = Nothing

        Try
            Cnx = New System.Data.SqlClient.SqlConnection
            Cnx.ConnectionString = ModPOS.BDConexion
            Cnx.Open()
        Catch ex As Exception
            Beep()
            MsgBox("No se puede conectar a la base de datos", MsgBoxStyle.Critical, "Error")
        End Try


        Try

            MyTrans = Cnx.BeginTransaction
            MyComand = New System.Data.SqlClient.SqlCommand("sp_elimina_estructura", Cnx)
            MyComand.CommandTimeout = ModPOS.myTimeOut
            MyComand.Transaction = MyTrans

            MyComand.CommandType = CommandType.StoredProcedure
            MyComand.Parameters.Add("@Estructura", SqlDbType.VarChar).Value = Est
            MyComand.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = ModPOS.UsuarioActual

            MyComand.ExecuteNonQuery()
            MyTrans.Commit()

        Catch ex As System.Data.SqlClient.SqlException
            MsgBox(ex.Message, MessageBoxButtons.OK)
            Try
                MyTrans.Rollback()
            Catch es As System.Data.SqlClient.SqlException
                If Not MyTrans.Connection Is Nothing Then
                    MsgBox("No se puede conectar con la base de datos, no rollback", MessageBoxButtons.OK)
                End If
            End Try

        End Try
        Cnx.Close()

    End Sub

    Public Function ImageAddText(ByVal foto As PictureBox, ByVal texto As String) As Image
        Dim ret As Bitmap = New Bitmap(foto.Width, foto.Height)
        Dim g As Graphics = Graphics.FromImage(ret)

        Dim stringFormat As New StringFormat()
        stringFormat.Alignment = StringAlignment.Center
        stringFormat.LineAlignment = StringAlignment.Center

        Dim font1 As New Font("Century Gothic", 8, FontStyle.Regular, GraphicsUnit.Point)
        Dim rect1 As New Rectangle(0, 0, foto.Width, foto.Height)
        g.DrawString(texto, font1, Brushes.Black, rect1, stringFormat)
        g.Dispose()
        Return ret

    End Function

    'Public Sub redrawClave(ByVal Pic As PictureBox, ByVal text1 As String)
    '    Dim grpDraw As Graphics = Pic.CreateGraphics()

    '    Dim font1 As New Font("Century Gothic", 10, FontStyle.Bold, GraphicsUnit.Point)
    '    Try
    '        Dim rect1 As New Rectangle(0, 0, Pic.Width, Pic.Height)

    '        Dim stringFormat As New StringFormat()
    '        stringFormat.Alignment = StringAlignment.Center
    '        stringFormat.LineAlignment = StringAlignment.Center

    '        grpDraw.DrawString(text1, font1, Brushes.Black, rect1, stringFormat)

    '    Finally
    '        font1.Dispose()
    '    End Try

    'End Sub

#End Region

    Public ReadOnly Property SerialNumber() As String
        Get
            Const query As String = "SerialNumber"
            Try
                Dim moc As System.Management.ManagementObjectCollection = InitManagement()
                If moc IsNot Nothing Then
                    For Each mo As System.Management.ManagementObject In moc
                        If mo.Properties(query).Value.ToString() IsNot Nothing Then
                            Return mo.Properties(query).Value.ToString()
                        Else
                            Return "NR"
                        End If
                    Next
                Else
                    Return "NRR"
                End If
            Catch
            End Try
            Return "ERR"
        End Get
    End Property

    Public Function InitManagement() As System.Management.ManagementObjectCollection
        Try
            Dim query As String = "Select * from Win32_PhysicalMedia"
            Dim mos As System.Management.ManagementObjectSearcher = New System.Management.ManagementObjectSearcher(query)
            Dim moc As System.Management.ManagementObjectCollection = mos.Get()
            Return moc
        Catch
            Return Nothing
        End Try
        Return Nothing
    End Function

    Public Function recuperaParametro(ByVal param As String) As Object
        Dim dt As DataTable
        Dim result As Object = Nothing
        Dim i As Integer

        dt = ModPOS.Recupera_Tabla("sp_recupera_parametro", "@COMClave", ModPOS.CompanyActual)

        For i = 0 To dt.Rows.Count - 1
            Select Case CStr(dt.Rows(i)("PARClave"))
                Case param
                    result = dt.Rows(i)("Valor")
                    Exit For
            End Select
        Next

        dt.Dispose()

        Return result

    End Function


End Module
