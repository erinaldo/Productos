Imports Microsoft.VisualBasic
Partial Class _Default

    Inherits System.Web.UI.Page

    Dim IntCommandTimeOut As Integer = 600
    Dim oReporte As New CrystalDecisions.CrystalReports.Engine.ReportClass
    Dim oReporteSumatoria As New CrystalDecisions.CrystalReports.Engine.ReportClass

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        IntCommandTimeOut = Session("_TimeOut")
        Dim ins As New DBConexion.cConexionSQL
        Dim oMensaje As New DBConexion.cMensaje

        If IsNothing(Session("Logo")) Then
            Session("Logo") = ins.EjecutarConsulta("Select Logotipo from Configuracion ")
        End If
        Dim dt As System.Data.DataTable = Session("Logo")


        If Session("NumReporte") = 3 Then 'Reporte de Efectividad por Ruta
            If (Session("TipoReporte") = "Detallado") Then
                oReporte.FileName = Server.MapPath("Reports\ReporteEfectividadxRutaDet.rpt")
                oReporte.Database.Tables("Configuracion").SetDataSource(dt)
                dt = Session("DataTable")
                oReporte.Database.Tables("ReporteEfectividadXRutaDet").SetDataSource(dt)

                'SUBREPORTES
                '*******************************************

                dt = ins.EjecutarConsulta(Session("Tiempos"), IntCommandTimeOut)
                oReporte.Subreports("Tiempos").Database.Tables(0).SetDataSource(dt)

                dt = ins.EjecutarConsulta(Session("ClientesNoVisitados"), IntCommandTimeOut)
                oReporte.Subreports("ClientesNoVisitados").Database.Tables("Clientes").SetDataSource(dt)


                dt = ins.EjecutarConsulta(Session("TotalClientes"), IntCommandTimeOut)
                oReporte.Subreports("ClientesNoVisitados").Database.Tables("TotalClientes").SetDataSource(dt)
                oReporte.Subreports("ClientesVisitados").Database.Tables("TotalClientes").SetDataSource(dt)
                oReporte.Subreports("ClientesVisitadosTotales").Database.Tables("TotalClientes").SetDataSource(dt)
                oReporte.Subreports("ClientesVisitadosFA").Database.Tables("TotalClientes").SetDataSource(dt)
                oReporte.Subreports("ClientesVisitadosFATotales").Database.Tables("TotalClientes").SetDataSource(dt)

                dt = ins.EjecutarConsulta(Session("ClientesVisitados"), IntCommandTimeOut)
                oReporte.Subreports("ClientesVisitados").Database.Tables("Clientes").SetDataSource(dt)
                oReporte.Subreports("ClientesVisitadosTotales").Database.Tables("Clientes").SetDataSource(dt)


                dt = ins.EjecutarConsulta(Session("ClientesVisitadosFA"), IntCommandTimeOut)
                oReporte.Subreports("ClientesVisitadosFA").Database.Tables("Clientes").SetDataSource(dt)
                oReporte.Subreports("ClientesVisitadosFATotales").Database.Tables("Clientes").SetDataSource(dt)

                oReporte.Subreports("ClientesVisitadosConVenta").Database.Tables("Clientes").SetDataSource(ins.EjecutarConsulta(Session("ClientesVisitadosConVenta"), IntCommandTimeOut))
                oReporte.Subreports("ClientesVisitadosConVentaTotales").Database.Tables("Clientes").SetDataSource(ins.EjecutarConsulta(Session("ClientesVisitadosConVenta"), IntCommandTimeOut))
                oReporte.Subreports("ClientesVisitadosConVentaFA").Database.Tables("Clientes").SetDataSource(ins.EjecutarConsulta(Session("ClientesVisitadosConVentaFA"), IntCommandTimeOut))
                oReporte.Subreports("ClientesVisitadosConVentaFATotales").Database.Tables("Clientes").SetDataSource(ins.EjecutarConsulta(Session("ClientesVisitadosConVentaFA"), IntCommandTimeOut))

                dt = ins.EjecutarConsulta(Session("TotalVisitados"), IntCommandTimeOut)
                oReporte.Subreports("ClientesVisitadosConVenta").Database.Tables("TotalClientes").SetDataSource(dt)
                oReporte.Subreports("ClientesVisitadosConVentaTotales").Database.Tables("TotalClientes").SetDataSource(dt)
                oReporte.Subreports("ClientesVisitadosConVentaFA").Database.Tables("TotalClientes").SetDataSource(dt)
                oReporte.Subreports("ClientesVisitadosConVentaFATotales").Database.Tables("TotalClientes").SetDataSource(dt)
                oReporte.Subreports("ClientesVisitadosSinVenta").Database.Tables("TotalClientes").SetDataSource(dt)
                oReporte.Subreports("ClientesVisitadosSinVentaTotales").Database.Tables("TotalClientes").SetDataSource(dt)
                oReporte.Subreports("ClientesVisitadosSinVentaFA").Database.Tables("TotalClientes").SetDataSource(dt)
                oReporte.Subreports("ClientesVisitadosSinVentaFATotales").Database.Tables("TotalClientes").SetDataSource(dt)
                oReporte.Subreports("CodigosLeidos").Database.Tables("TotalClientes").SetDataSource(dt)
                oReporte.Subreports("CodigosLeidosTotales").Database.Tables("TotalClientes").SetDataSource(dt)
                oReporte.Subreports("CodigosLeidosFA").Database.Tables("TotalClientes").SetDataSource(dt)
                oReporte.Subreports("CodigosLeidosFATotales").Database.Tables("TotalClientes").SetDataSource(dt)
                oReporte.Subreports("CodigosNoLeidos").Database.Tables("TotalClientes").SetDataSource(dt)
                oReporte.Subreports("CodigosNoLeidosTotales").Database.Tables("TotalClientes").SetDataSource(dt)
                oReporte.Subreports("CodigosNoLeidosFA").Database.Tables("TotalClientes").SetDataSource(dt)
                oReporte.Subreports("CodigosNoLeidosFATotales").Database.Tables("TotalClientes").SetDataSource(dt)
                oReporte.Subreports("ImproductividadVentaTotales").Database.Tables("TotalClientes").SetDataSource(dt)
                oReporte.Subreports("ImproductividadVentaFATotales").Database.Tables("TotalClientes").SetDataSource(dt)


                dt = ins.EjecutarConsulta(Session("ClientesVisitadosSinVenta"), IntCommandTimeOut)
                oReporte.Subreports("ClientesVisitadosSinVenta").Database.Tables("Clientes").SetDataSource(dt)
                oReporte.Subreports("ClientesVisitadosSinVentaTotales").Database.Tables("Clientes").SetDataSource(dt)

                dt = ins.EjecutarConsulta(Session("ClientesVisitadosSinVentaFA"), IntCommandTimeOut)
                oReporte.Subreports("ClientesVisitadosSinVentaFA").Database.Tables("Clientes").SetDataSource(dt)
                oReporte.Subreports("ClientesVisitadosSinVentaFATotales").Database.Tables("Clientes").SetDataSource(dt)

                dt = ins.EjecutarConsulta(Session("ImproductividadVenta"), IntCommandTimeOut)
                oReporte.Subreports("ImproductividadVenta").Database.Tables("ImproductividadVenta").SetDataSource(dt)
                oReporte.Subreports("ImproductividadVentaTotales").Database.Tables("ImproductividadVenta").SetDataSource(dt)

                dt = ins.EjecutarConsulta(Session("ImproductividadVentaFA"), IntCommandTimeOut)
                oReporte.Subreports("ImproductividadVentaFA").Database.Tables("ImproductividadVenta").SetDataSource(dt)
                oReporte.Subreports("ImproductividadVentaFATotales").Database.Tables("ImproductividadVenta").SetDataSource(dt)

                dt = ins.EjecutarConsulta(Session("TotalVisitadosSinVenta"), IntCommandTimeOut)
                oReporte.Subreports("ImproductividadVenta").Database.Tables("TotalClientes").SetDataSource(dt)
                oReporte.Subreports("ImproductividadVentaFA").Database.Tables("TotalClientes").SetDataSource(dt)

                dt = ins.EjecutarConsulta(Session("TotalEncuestas"), IntCommandTimeOut)
                oReporte.Subreports("EncuestasAplicadas").Database.Tables("TotalEncuestas").SetDataSource(dt)
                oReporte.Subreports("EncuestasAplicadasTotales").Database.Tables("TotalEncuestas").SetDataSource(dt)
                oReporte.Subreports("EncuestasAplicadasFA").Database.Tables("TotalEncuestas").SetDataSource(dt)
                oReporte.Subreports("EncuestasAplicadasFATotales").Database.Tables("TotalEncuestas").SetDataSource(dt)
                oReporte.Subreports("EncuestasNoAplicadas").Database.Tables("TotalEncuestas").SetDataSource(dt)
                oReporte.Subreports("EncuestasNoAplicadasTotales").Database.Tables("TotalEncuestas").SetDataSource(dt)
                oReporte.Subreports("EncuestasNoAplicadasFA").Database.Tables("TotalEncuestas").SetDataSource(dt)
                oReporte.Subreports("EncuestasNoAplicadasFATotales").Database.Tables("TotalEncuestas").SetDataSource(dt)

                dt = ins.EjecutarConsulta(Session("EncuestasAplicadas"), IntCommandTimeOut)
                oReporte.Subreports("EncuestasAplicadas").Database.Tables("Encuestas").SetDataSource(dt)
                oReporte.Subreports("EncuestasAplicadasTotales").Database.Tables("Encuestas").SetDataSource(dt)

                dt = ins.EjecutarConsulta(Session("EncuestasAplicadasFA"), IntCommandTimeOut)
                oReporte.Subreports("EncuestasAplicadasFA").Database.Tables("Encuestas").SetDataSource(dt)
                oReporte.Subreports("EncuestasAplicadasFATotales").Database.Tables("Encuestas").SetDataSource(dt)

                dt = ins.EjecutarConsulta(Session("EncuestasNoAplicadas"), IntCommandTimeOut)
                oReporte.Subreports("EncuestasNoAplicadas").Database.Tables("Encuestas").SetDataSource(dt)
                oReporte.Subreports("EncuestasNoAplicadasTotales").Database.Tables("Encuestas").SetDataSource(dt)

                dt = ins.EjecutarConsulta(Session("EncuestasNoAplicadasFA"), IntCommandTimeOut)
                oReporte.Subreports("EncuestasNoAplicadasFA").Database.Tables("Encuestas").SetDataSource(dt)
                oReporte.Subreports("EncuestasNoAplicadasFATotales").Database.Tables("Encuestas").SetDataSource(dt)

                dt = ins.EjecutarConsulta(Session("TotalVisitadosAEncuestar"), IntCommandTimeOut)
                oReporte.Subreports("ClientesEncuestados").Database.Tables("TotalClientes").SetDataSource(dt)
                oReporte.Subreports("ClientesEncuestadosTotales").Database.Tables("TotalClientes").SetDataSource(dt)
                oReporte.Subreports("ClientesEncuestadosFA").Database.Tables("TotalClientes").SetDataSource(dt)
                oReporte.Subreports("ClientesEncuestadosFATotales").Database.Tables("TotalClientes").SetDataSource(dt)
                oReporte.Subreports("ClientesNoEncuestados").Database.Tables("TotalClientes").SetDataSource(dt)
                oReporte.Subreports("ClientesNoEncuestadosTotales").Database.Tables("TotalClientes").SetDataSource(dt)
                oReporte.Subreports("ClientesNoEncuestadosFA").Database.Tables("TotalClientes").SetDataSource(dt)
                oReporte.Subreports("ClientesNoEncuestadosFATotales").Database.Tables("TotalClientes").SetDataSource(dt)

                dt = ins.EjecutarConsulta(Session("ClientesEncuestados"), IntCommandTimeOut)
                oReporte.Subreports("ClientesEncuestados").Database.Tables("Clientes").SetDataSource(dt)
                oReporte.Subreports("ClientesEncuestadosTotales").Database.Tables("Clientes").SetDataSource(dt)

                dt = ins.EjecutarConsulta(Session("ClientesEncuestadosFA"), IntCommandTimeOut)
                oReporte.Subreports("ClientesEncuestadosFA").Database.Tables("Clientes").SetDataSource(dt)
                oReporte.Subreports("ClientesEncuestadosFATotales").Database.Tables("Clientes").SetDataSource(dt)

                dt = ins.EjecutarConsulta(Session("ClientesNoEncuestados"), IntCommandTimeOut)
                oReporte.Subreports("ClientesNoEncuestados").Database.Tables("Clientes").SetDataSource(dt)
                oReporte.Subreports("ClientesNoEncuestadosTotales").Database.Tables("Clientes").SetDataSource(dt)

                dt = ins.EjecutarConsulta(Session("ClientesNoEncuestadosFA"), IntCommandTimeOut)
                oReporte.Subreports("ClientesNoEncuestadosFA").Database.Tables("Clientes").SetDataSource(dt)
                oReporte.Subreports("ClientesNoEncuestadosFATotales").Database.Tables("Clientes").SetDataSource(dt)

                dt = ins.EjecutarConsulta(Session("CodigosLeidos"), IntCommandTimeOut)
                oReporte.Subreports("CodigosLeidos").Database.Tables("Clientes").SetDataSource(dt)
                oReporte.Subreports("CodigosLeidosTotales").Database.Tables("Clientes").SetDataSource(dt)

                dt = ins.EjecutarConsulta(Session("CodigosLeidosFA"), IntCommandTimeOut)
                oReporte.Subreports("CodigosLeidosFA").Database.Tables("Clientes").SetDataSource(dt)
                oReporte.Subreports("CodigosLeidosFATotales").Database.Tables("Clientes").SetDataSource(dt)

                dt = ins.EjecutarConsulta(Session("CodigosNoLeidos"), IntCommandTimeOut)
                oReporte.Subreports("CodigosNoLeidos").Database.Tables("Clientes").SetDataSource(dt)
                oReporte.Subreports("CodigosNoLeidosTotales").Database.Tables("Clientes").SetDataSource(dt)

                dt = ins.EjecutarConsulta(Session("CodigosNoLeidosFA"), IntCommandTimeOut)
                oReporte.Subreports("CodigosNoLeidosFA").Database.Tables("Clientes").SetDataSource(dt)
                oReporte.Subreports("CodigosNoLeidosFATotales").Database.Tables("Clientes").SetDataSource(dt)

                dt = ins.EjecutarConsulta(Session("ProductoNegado"), IntCommandTimeOut)
                oReporte.Subreports("ProductoNegado").Database.Tables(0).SetDataSource(dt)
                oReporte.Subreports("ProductoNegadoTotales").Database.Tables(0).SetDataSource(dt)

                dt = ins.EjecutarConsulta(Session("ProductoNegadoFA"), IntCommandTimeOut)
                oReporte.Subreports("ProductoNegadoFA").Database.Tables(0).SetDataSource(dt)
                oReporte.Subreports("ProductoNegadoFATotales").Database.Tables(0).SetDataSource(dt)

                dt = ins.EjecutarConsulta(Session("ImproductividadProducto"), IntCommandTimeOut)
                oReporte.Subreports("ImproductividadProducto").Database.Tables(0).SetDataSource(dt)
                oReporte.Subreports("ImproductividadProductoTotales").Database.Tables(0).SetDataSource(dt)

                dt = ins.EjecutarConsulta(Session("ImproductividadProductoFA"), IntCommandTimeOut)
                oReporte.Subreports("ImproductividadProductoFA").Database.Tables(0).SetDataSource(dt)
                oReporte.Subreports("ImproductividadProductoFATotales").Database.Tables(0).SetDataSource(dt)

                dt = ins.EjecutarConsulta(Session("MotivosImproductividad"), IntCommandTimeOut)
                oReporte.Subreports("MotivosImproductividad").Database.Tables(0).SetDataSource(dt)
                oReporte.Subreports("MotivosImproductividadTotales").Database.Tables(0).SetDataSource(dt)

                dt = ins.EjecutarConsulta(Session("MotivosImproductividadFA"), IntCommandTimeOut)
                oReporte.Subreports("MotivosImproductividadFA").Database.Tables(0).SetDataSource(dt)
                oReporte.Subreports("MotivosImproductividadFATotales").Database.Tables(0).SetDataSource(dt)

                dt = ins.EjecutarConsulta(Session("ProductoPromoNoEntregado"), IntCommandTimeOut)
                oReporte.Subreports("ProductoPromocionalNE").Database.Tables(0).SetDataSource(dt)

                dt = ins.EjecutarConsulta(Session("ProductoPromoNoEntregadoFA"), IntCommandTimeOut)
                oReporte.Subreports("ProductoPromocionalNEFA").Database.Tables(0).SetDataSource(dt)

                dt = ins.EjecutarConsulta(Session("TotalProductoPromocional"), IntCommandTimeOut)
                oReporte.Subreports("ProductoPromocionalNETotales").Database.Tables("TotalClientes").SetDataSource(dt)

                dt = ins.EjecutarConsulta(Session("TotalProductoPromocionalFA"), IntCommandTimeOut)
                oReporte.Subreports("ProductoPromocionalNEFATotales").Database.Tables("TotalClientes").SetDataSource(dt)


                dt = ins.EjecutarConsulta(Session("ClientesProductoNegado"), IntCommandTimeOut)
                oReporte.Subreports("ClientesProductoNegado").Database.Tables(0).SetDataSource(dt)
                oReporte.Subreports("ClientesProductoNegadoTotales").Database.Tables(0).SetDataSource(dt)

                dt = ins.EjecutarConsulta(Session("ClientesProductoNegadoFA"), IntCommandTimeOut)
                oReporte.Subreports("ClientesProductoNegadoFA").Database.Tables(0).SetDataSource(dt)
                oReporte.Subreports("ClientesProductoNegadoFATotales").Database.Tables(0).SetDataSource(dt)

                dt = ins.EjecutarConsulta(Session("ClientesImproductividadProducto"), IntCommandTimeOut)
                oReporte.Subreports("ClientesImproductividadProducto").Database.Tables(0).SetDataSource(dt)
                oReporte.Subreports("ClientesImproductividadProductoTotales").Database.Tables(0).SetDataSource(dt)

                dt = ins.EjecutarConsulta(Session("ClientesImproductividadProductoFA"), IntCommandTimeOut)
                oReporte.Subreports("ClientesImproductividadProductoFA").Database.Tables(0).SetDataSource(dt)
                oReporte.Subreports("ClientesImproductividadProductoFATotales").Database.Tables(0).SetDataSource(dt)

                dt = ins.EjecutarConsulta(Session("ClientesProductoPNE"), IntCommandTimeOut)
                oReporte.Subreports("ClientesProductoPNE").Database.Tables(0).SetDataSource(dt)
                oReporte.Subreports("ClientesProductoPNETotales").Database.Tables(0).SetDataSource(dt)

                dt = ins.EjecutarConsulta(Session("ClientesProductoPNEFA"), IntCommandTimeOut)
                oReporte.Subreports("ClientesProductoPNEFA").Database.Tables(0).SetDataSource(dt)
                oReporte.Subreports("ClientesProductoPNEFATotales").Database.Tables(0).SetDataSource(dt)

                '*******************************************

                oReporte.SetParameterValue("EnAgenda", oMensaje.RecuperarDescripcion("XEnAgenda"))
                oReporte.SetParameterValue("FueraAgenda", oMensaje.RecuperarDescripcion("XFueraAgenda"))
                oReporte.SetParameterValue("Cantidad", oMensaje.RecuperarDescripcion("XCantidad"))
                oReporte.SetParameterValue("Porcentaje", oMensaje.RecuperarDescripcion("XPorcentaje"))

                oReporte.SetParameterValue("Producto", oMensaje.RecuperarDescripcion("XProductoNegado"))
                oReporte.SetParameterValue("UnidadVenta", oMensaje.RecuperarDescripcion("XUnidadesVenta"))

                '////////////////////////////////////////////////////////////////
                oReporte.SetParameterValue("TituloCNV", oMensaje.RecuperarDescripcion("XClientesNoVisitados").ToUpper)
                oReporte.SetParameterValue("TotalCNV", oMensaje.RecuperarDescripcion("XTotalClientesNoVisitados"))

                oReporte.SetParameterValue("TituloCV", oMensaje.RecuperarDescripcion("MDB0126").ToUpper())
                oReporte.SetParameterValue("TotalCV", oMensaje.RecuperarDescripcion("XTotalClientesVisitados"))
                oReporte.SetParameterValue("TotalCVFA", oMensaje.RecuperarDescripcion("XTotalClientesVisitados"))

                oReporte.SetParameterValue("TituloCVSV", oMensaje.RecuperarDescripcion("XClientesVisitadosSinVenta").ToUpper)
                oReporte.SetParameterValue("TotalCVSV", oMensaje.RecuperarDescripcion("XTotalClientesVisitadosConVenta"))
                oReporte.SetParameterValue("TotalCVSVFA", oMensaje.RecuperarDescripcion("XTotalClientesVisitadosConVenta"))

                oReporte.SetParameterValue("TituloCVCV", oMensaje.RecuperarDescripcion("XClientesVisitadosConVenta").ToUpper)
                oReporte.SetParameterValue("TotalCVCV", oMensaje.RecuperarDescripcion("XTotalClientesVisitadosSinVenta"))
                oReporte.SetParameterValue("TotalCVCVFA", oMensaje.RecuperarDescripcion("XTotalClientesVisitadosSinVenta"))

                oReporte.SetParameterValue("TituloIV", oMensaje.RecuperarDescripcion("XImproductividadVenta").ToUpper)
                oReporte.SetParameterValue("TotalIV", oMensaje.RecuperarDescripcion("XTotalImproductividadVenta"))
                oReporte.SetParameterValue("TotalIVFA", oMensaje.RecuperarDescripcion("XTotalImproductividadVenta"))

                oReporte.SetParameterValue("TituloEA", oMensaje.RecuperarDescripcion("XEncuestasAplicadas").ToUpper)
                oReporte.SetParameterValue("TotalEA", oMensaje.RecuperarDescripcion("XTotalEncuestasAplicadas"))
                oReporte.SetParameterValue("TotalEAFA", oMensaje.RecuperarDescripcion("XTotalEncuestasAplicadas"))

                oReporte.SetParameterValue("TituloENA", oMensaje.RecuperarDescripcion("XEncuestasNoAplicadas").ToUpper)
                oReporte.SetParameterValue("TotalENA", oMensaje.RecuperarDescripcion("XTotalEncuestasNoAplicadas"))
                oReporte.SetParameterValue("TotalENAFA", oMensaje.RecuperarDescripcion("XTotalEncuestasNoAplicadas"))

                oReporte.SetParameterValue("TituloCE", oMensaje.RecuperarDescripcion("XClientesEncuestados").ToUpper)
                oReporte.SetParameterValue("TotalCE", oMensaje.RecuperarDescripcion("XTotalClientesEncuestados"))
                oReporte.SetParameterValue("TotalCEFA", oMensaje.RecuperarDescripcion("XTotalClientesEncuestados"))

                oReporte.SetParameterValue("TituloCNE", oMensaje.RecuperarDescripcion("XClientesNoEncuestados").ToUpper)
                oReporte.SetParameterValue("TotalCNE", oMensaje.RecuperarDescripcion("XTotalClientesNoEncuestados"))
                oReporte.SetParameterValue("TotalCNEFA", oMensaje.RecuperarDescripcion("XTotalClientesNoEncuestados"))

                oReporte.SetParameterValue("TituloCL", oMensaje.RecuperarDescripcion("XCodigoBarras").ToUpper)
                oReporte.SetParameterValue("TotalCL", oMensaje.RecuperarDescripcion("XTotalCodigoBarrasLeido"))
                oReporte.SetParameterValue("TotalCLFA", oMensaje.RecuperarDescripcion("XTotalCodigoBarrasLeido"))

                oReporte.SetParameterValue("TituloCNL", oMensaje.RecuperarDescripcion("XCodigoBarrasNoLeido").ToUpper)
                oReporte.SetParameterValue("TotalCNL", oMensaje.RecuperarDescripcion("XTotalCodigoBarrasNoLeido"))
                oReporte.SetParameterValue("TotalCNLFA", oMensaje.RecuperarDescripcion("XTotalCodigoBarrasNoLeido"))

                oReporte.SetParameterValue("TituloPN", oMensaje.RecuperarDescripcion("XProductoNegado").ToUpper)
                oReporte.SetParameterValue("TotalPN", oMensaje.RecuperarDescripcion("XTotalProductoNegado"))
                oReporte.SetParameterValue("TotalPNFA", oMensaje.RecuperarDescripcion("XTotalProductoNegado"))

                oReporte.SetParameterValue("TituloPPNE", oMensaje.RecuperarDescripcion("XProductoPromocionalNE").ToUpper)
                oReporte.SetParameterValue("TotalPPNE", oMensaje.RecuperarDescripcion("XTotalProductoPromocionalNE"))
                oReporte.SetParameterValue("TotalPPNEFA", oMensaje.RecuperarDescripcion("XTotalProductoPromocionalNE"))

                oReporte.SetParameterValue("TituloIP", oMensaje.RecuperarDescripcion("XImproductividadProducto").ToUpper)
                oReporte.SetParameterValue("TotalIP", oMensaje.RecuperarDescripcion("XTotalImproductividadProducto"))
                oReporte.SetParameterValue("TotalIPFA", oMensaje.RecuperarDescripcion("XTotalImproductividadProducto"))

                oReporte.SetParameterValue("TituloMI", oMensaje.RecuperarDescripcion("XMotivosImproductividad").ToUpper)
                oReporte.SetParameterValue("TotalMI", oMensaje.RecuperarDescripcion("XTotalMotivosImproductividad"))
                oReporte.SetParameterValue("TotalMIFA", oMensaje.RecuperarDescripcion("XTotalMotivosImproductividad"))

                oReporte.SetParameterValue("TituloCPN", oMensaje.RecuperarDescripcion("XClientesProductoNegado").ToUpper)
                oReporte.SetParameterValue("TotalProductosCPN", oMensaje.RecuperarDescripcion("XTotalProductoNegado"))
                oReporte.SetParameterValue("TotalClientesCPN", oMensaje.RecuperarDescripcion("XTotalClientesProductoNegado"))
                oReporte.SetParameterValue("TotalProductosCPNFA", oMensaje.RecuperarDescripcion("XTotalProductoNegado"))
                oReporte.SetParameterValue("TotalClientesCPNFA", oMensaje.RecuperarDescripcion("XTotalClientesProductoNegado"))

                oReporte.SetParameterValue("TituloCIP", oMensaje.RecuperarDescripcion("XClientesImproductividadProducto").ToUpper)
                oReporte.SetParameterValue("TotalProductosCIP", oMensaje.RecuperarDescripcion("XTotalImproductividadProducto"))
                oReporte.SetParameterValue("TotalClientesCIP", oMensaje.RecuperarDescripcion("XTotalClientesImproductividadProd"))
                oReporte.SetParameterValue("TotalProductosCIPFA", oMensaje.RecuperarDescripcion("XTotalImproductividadProducto"))
                oReporte.SetParameterValue("TotalClientesCIPFA", oMensaje.RecuperarDescripcion("XTotalClientesImproductividadProd"))

                oReporte.SetParameterValue("TituloCPPNE", oMensaje.RecuperarDescripcion("XClientesProductoPromocionalNE").ToUpper)
                oReporte.SetParameterValue("TotalProductosPPNE", oMensaje.RecuperarDescripcion("XTotalProductoPromocionalNE"))
                oReporte.SetParameterValue("TotalClientesPPNE", oMensaje.RecuperarDescripcion("XTotalClientesProductoPromocionalNE"))
                oReporte.SetParameterValue("TotalProductosPPNEFA", oMensaje.RecuperarDescripcion("XTotalProductoPromocionalNE"))
                oReporte.SetParameterValue("TotalClientesPPNEFA", oMensaje.RecuperarDescripcion("XTotalClientesProductoPromocionalNE"))

                '////////////////////////////////////////////////////////////////
            Else
                oReporte.FileName = Server.MapPath("Reports\ReporteEfectividadxRuta.rpt")
                oReporte.Database.Tables("Configuracion").SetDataSource(dt)
                'dt = ins.EjecutarConsulta(Session("Query"))
                dt = Session("DataTable")
                oReporte.Database.Tables("ReporteEfectividadXRuta").SetDataSource(dt)
                'SUBREPORTES
                '*******************************************

                oReporte.Subreports("Tiempos").Database.Tables(0).SetDataSource(ins.EjecutarConsulta(Session("Tiempos"), IntCommandTimeOut))
                oReporte.Subreports("ClientesVisNoVis").Database.Tables("ClientesVisNoVis").SetDataSource(ins.EjecutarConsulta(Session("ClientesVisitados"), IntCommandTimeOut))
                oReporte.Subreports("ClientesVentaNoVenta").Database.Tables("ClientesVisVenta").SetDataSource(ins.EjecutarConsulta(Session("ClientesVisitadosConVenta"), IntCommandTimeOut))
                oReporte.Subreports("ImproductividadVenta").Database.Tables("ClientesImproductividad").SetDataSource(ins.EjecutarConsulta(Session("ImproductividadVenta"), IntCommandTimeOut))
                oReporte.Subreports("Encuestas").Database.Tables("EncuestasAplicadas").SetDataSource(ins.EjecutarConsulta(Session("EncuestasAplicadas"), IntCommandTimeOut))
                oReporte.Subreports("ClientesEncuestados").Database.Tables("ClientesEncuestados").SetDataSource(ins.EjecutarConsulta(Session("ClientesEncuestados"), IntCommandTimeOut))
                oReporte.Subreports("CodigoBarras").Database.Tables("CodigosLeidos").SetDataSource(ins.EjecutarConsulta(Session("CodigosLeidos"), IntCommandTimeOut))
                oReporte.Subreports("ProductoNegado").Database.Tables("ProductoNegadoGral").SetDataSource(ins.EjecutarConsulta(Session("ProductoNegado"), IntCommandTimeOut))
                oReporte.Subreports("ProductoPromocionalNoEntregado").Database.Tables("ProductoNegadoGral").SetDataSource(ins.EjecutarConsulta(Session("ProductoPromoNoEntregado"), IntCommandTimeOut))
                oReporte.Subreports("ClientesProductoNegado").Database.Tables("ProductoNegadoGral").SetDataSource(ins.EjecutarConsulta(Session("ClientesProductoNegado"), IntCommandTimeOut))
                oReporte.Subreports("ClientesProductoPromoNE").Database.Tables("ProductoNegadoGral").SetDataSource(ins.EjecutarConsulta(Session("ClientesProductoPromoNoEntregado"), IntCommandTimeOut))

                oReporte.SetParameterValue("EnAgenda", oMensaje.RecuperarDescripcion("XEnAgenda"))
                oReporte.SetParameterValue("FueraAgenda", oMensaje.RecuperarDescripcion("XFueraAgenda"))

                oReporte.SetParameterValue("ClientesVisitados", oMensaje.RecuperarDescripcion("MDB0126").ToUpper)
                oReporte.SetParameterValue("ClientesNoVisitados", oMensaje.RecuperarDescripcion("XClientesNoVisitados").ToUpper)
                oReporte.SetParameterValue("TotalClientes", oMensaje.RecuperarDescripcion("XTotalClientes").ToUpper)

                oReporte.SetParameterValue("ClientesVisitadosConVenta", oMensaje.RecuperarDescripcion("XClientesVisitadosConVenta").ToUpper)
                oReporte.SetParameterValue("ClientesVisitadosSinVenta", oMensaje.RecuperarDescripcion("XClientesVisitadosSinVenta").ToUpper)
                oReporte.SetParameterValue("TotalClientesVisitados", oMensaje.RecuperarDescripcion("XTotalClientesVisitados").ToUpper)

                oReporte.SetParameterValue("ImproductividadVenta", oMensaje.RecuperarDescripcion("XImproductividadVenta").ToUpper)

                oReporte.SetParameterValue("EncuestasAplicadas", oMensaje.RecuperarDescripcion("XEncuestasAplicadas").ToUpper)
                oReporte.SetParameterValue("EncuestasNoAplicadas", oMensaje.RecuperarDescripcion("XEncuestasNoAplicadas").ToUpper)
                oReporte.SetParameterValue("TotalEncuestas", oMensaje.RecuperarDescripcion("XTotalEncuestas").ToUpper)

                oReporte.SetParameterValue("ClientesEncuestados", oMensaje.RecuperarDescripcion("XClientesEncuestados").ToUpper)
                oReporte.SetParameterValue("ClientesNoEncuestados", oMensaje.RecuperarDescripcion("XClientesNoEncuestados").ToUpper)
                oReporte.SetParameterValue("TotalClientesEncuestados", oMensaje.RecuperarDescripcion("XTotalClientesEncuestados").ToUpper)

                oReporte.SetParameterValue("CodigoBarrasLeidos", oMensaje.RecuperarDescripcion("XCodigoBarras").ToUpper)
                oReporte.SetParameterValue("CodigoBarrasNoLeidos", oMensaje.RecuperarDescripcion("XCodigoBarrasNoLeido").ToUpper)
                oReporte.SetParameterValue("TotalClientesCodigoBarras", oMensaje.RecuperarDescripcion("XTotalClientes").ToUpper)

                oReporte.SetParameterValue("ProductoNegado", oMensaje.RecuperarDescripcion("XProductoNegado").ToUpper)
                oReporte.SetParameterValue("ImproductividadProducto", oMensaje.RecuperarDescripcion("XImproductividadProducto").ToUpper)
                oReporte.SetParameterValue("TotalProductoNoVendido", oMensaje.RecuperarDescripcion("XTotalProductoNoVendido").ToUpper)

                oReporte.SetParameterValue("TituloPPNE", oMensaje.RecuperarDescripcion("XProductoPromocionalNE").ToUpper)

                oReporte.SetParameterValue("ClientesProductoNegado", oMensaje.RecuperarDescripcion("XClientesProductoNegado").ToUpper)
                oReporte.SetParameterValue("ClientesImproductividadProducto", oMensaje.RecuperarDescripcion("XClientesImproductividadProducto").ToUpper)
                oReporte.SetParameterValue("TotalProductosImproductividad", oMensaje.RecuperarDescripcion("XTotalProductosImproductividad").ToUpper)

                oReporte.SetParameterValue("TituloCPPNE", oMensaje.RecuperarDescripcion("XClientesProductoPromocionalNE").ToUpper)

            End If
            oReporte.SetParameterValue("CentroDistribucion", oMensaje.RecuperarDescripcion("XCentroDistribucion"))
            oReporte.SetParameterValue("Fecha", oMensaje.RecuperarDescripcion("XFecha"))
            oReporte.SetParameterValue("NombreRep", Session("Nombre").ToString().ToUpper())
            oReporte.SetParameterValue("Vendedor", oMensaje.RecuperarDescripcion("XVendedor"))
            oReporte.SetParameterValue("Ruta", oMensaje.RecuperarDescripcion("Xruta"))
            oReporte.SetParameterValue("Cantidad", oMensaje.RecuperarDescripcion("XCantidad"))
            oReporte.SetParameterValue("Porcentaje", oMensaje.RecuperarDescripcion("XPorcentaje"))

            oReporte.SetParameterValue("EnviadoCEDI", Session("CEDI"))
            oReporte.SetParameterValue("Enviadovendedor", Session("Vendedor"))
            oReporte.SetParameterValue("Enviadaruta", Session("Ruta"))
            oReporte.SetParameterValue("Enviadafecha", Session("RangoFechas"))

            oReporte.SetParameterValue("FechaHoraImpresion", oMensaje.RecuperarDescripcion("Xfechahoraimpresion"))

            oReporte.SetParameterValue("TiempoRecorrido", oMensaje.RecuperarDescripcion("XTiempoRecorrido"))
            oReporte.SetParameterValue("TiempoVisita", oMensaje.RecuperarDescripcion("XTiempoVisita"))
            oReporte.SetParameterValue("TiempoTransito", oMensaje.RecuperarDescripcion("XTiempoTransito"))

        ElseIf Session("NumReporte") = 5 Then '-------------------------------------------------------------------------------------------------------------------
            oReporte.FileName = Server.MapPath("Reports\reportesolicitudes.rpt")
            oReporteSumatoria.FileName = Server.MapPath("Reports\reportesolicitudes.rpt")


            oReporte.Database.Tables(1).SetDataSource(dt)


            'oReporte.Database.Tables(0).SetDataSource(ins.EjecutarConsulta(Session("Query")))
            oReporte.Database.Tables(0).SetDataSource(Session("DataTable"))

            If (IsNothing(Session("subreport0"))) Then
                Session("subreport0") = ins.EjecutarConsulta(Session("Query2"), IntCommandTimeOut)
            End If
            oReporte.Subreports(0).Database.Tables(0).SetDataSource(Session("subreport0"))

            oReporte.SetParameterValue("Folio", oMensaje.RecuperarDescripcion("XFOLIO"))
            oReporte.SetParameterValue("Fecha", oMensaje.RecuperarDescripcion("XFECHA"))
            oReporte.SetParameterValue("Nombre", Session("Nombre").ToString().ToUpper()) '''''''''''''****<----Nombre por filtros

            oReporte.SetParameterValue("Vendedor", oMensaje.RecuperarDescripcion("XVendedor"))
            oReporte.SetParameterValue("Cliente", oMensaje.RecuperarDescripcion("XCliente"))

            oReporte.SetParameterValue("Ruta", oMensaje.RecuperarDescripcion("Xruta"))
            oReporte.SetParameterValue("Peticion", oMensaje.RecuperarDescripcion("XComentario"))

            oReporte.SetParameterValue("Area", oMensaje.RecuperarDescripcion("Xarea"))
            oReporte.SetParameterValue("Area1", oMensaje.RecuperarDescripcion("Xarea"))
            oReporte.SetParameterValue("Concepto", oMensaje.RecuperarDescripcion("Xconcepto"))
            oReporte.SetParameterValue("Cantidad", oMensaje.RecuperarDescripcion("Xcantidad"))

            oReporte.SetParameterValue("Concepto1", oMensaje.RecuperarDescripcion("Xconcepto"))
            oReporte.SetParameterValue("Cantidad1", oMensaje.RecuperarDescripcion("Xcantidad"))
            oReporte.SetParameterValue("TotalSolicitudesPorRuta", oMensaje.RecuperarDescripcion("Xtotalsolicitudesruta"))
            oReporte.SetParameterValue("TotalSolicitudesVendedor", oMensaje.RecuperarDescripcion("Xtotalsolicitudesvendedor"))
            oReporte.SetParameterValue("TotalSolicitudesFecha", oMensaje.RecuperarDescripcion("Xtotalsolicitudesfecha"))
            oReporte.SetParameterValue("FechaHoraImpresion", oMensaje.RecuperarDescripcion("Xfechahoraimpresion"))

            oReporte.SetParameterValue("Enviadovendedor", Session("Vendedor"))
            oReporte.SetParameterValue("Enviadaruta", Session("Ruta"))
            oReporte.SetParameterValue("Enviadafecha", Session("RangoFechas"))

            oReporte.SetParameterValue("CentroDistribucion", oMensaje.RecuperarDescripcion("XCentroDistribucion"))
            oReporte.SetParameterValue("TotalSolicitudesCentroDistribucion", oMensaje.RecuperarDescripcion("XTotalporcentrodist"))
            oReporte.SetParameterValue("GranTotalSolicitudesCentroDistribucion", oMensaje.RecuperarDescripcion("XgranTotalCentrosDist"))

        ElseIf Session("NumReporte") = 4 Then '-------------------------------------------------------------------------------------------------------------------
            oReporte.FileName = Server.MapPath("Reports\reporteGastos.rpt")

            oReporte.Database.Tables(1).SetDataSource(dt)
            oReporte.Database.Tables(0).SetDataSource(Session("DataTable"))

            oReporte.SetParameterValue("Folio", oMensaje.RecuperarDescripcion("XFOLIO"))
            oReporte.SetParameterValue("Fecha", oMensaje.RecuperarDescripcion("XFECHA"))
            oReporte.SetParameterValue("Nombre", Session("Nombre").ToString().ToUpper()) '''''''''''''****<----Nombre por filtros
            oReporte.SetParameterValue("Vendedor", oMensaje.RecuperarDescripcion("XVendedor"))
            oReporte.SetParameterValue("Concepto", oMensaje.RecuperarDescripcion("XConcepto"))
            oReporte.SetParameterValue("Subtotal", oMensaje.RecuperarDescripcion("XSubtotal"))
            oReporte.SetParameterValue("Impuesto", oMensaje.RecuperarDescripcion("XImpuesto"))
            oReporte.SetParameterValue("Total", oMensaje.RecuperarDescripcion("XTotal"))
            oReporte.SetParameterValue("GranTotal", Mayusculasoloprimerletra(oMensaje.RecuperarDescripcion("XGranTotal")))
            oReporte.SetParameterValue("TotalGastosVendedor", oMensaje.RecuperarDescripcion("XTotalGastosVendedor"))
            oReporte.SetParameterValue("TotalGastosFecha", oMensaje.RecuperarDescripcion("XTotalGastosFecha"))
            oReporte.SetParameterValue("TotalGastosTodasFechas", Mayusculasoloprimerletra(oMensaje.RecuperarDescripcion("XTotalGastos")))
            oReporte.SetParameterValue("Enviadovendedor", Session("Vendedor"))
            oReporte.SetParameterValue("FechaHoraImpresion", oMensaje.RecuperarDescripcion("Xfechahoraimpresion"))
            oReporte.SetParameterValue("PorImpuesto", oMensaje.RecuperarDescripcion("X%Impuesto"))
            oReporte.SetParameterValue("Comentario", oMensaje.RecuperarDescripcion("XComentario"))

            oReporte.SetParameterValue("Enviadafecha", Session("RangoFechas"))

            oReporte.SetParameterValue("CentroDistribucion", oMensaje.RecuperarDescripcion("XCentroDistribucion"))
            oReporte.SetParameterValue("TotalGastosCentroDist", oMensaje.RecuperarDescripcion("XTotalGastosCentroDist"))
            oReporte.SetParameterValue("TotalGastosCentrosDist", oMensaje.RecuperarDescripcion("XTotalGastosCentrosDist"))


        ElseIf Session("NumReporte") = 7 Then

            oReporte.FileName = Server.MapPath("Reports\SaldoClientes.rpt")

            oReporte.Database.Tables(1).SetDataSource(dt)
            oReporte.Database.Tables(0).SetDataSource(Session("DataTable"))

            oReporte.SetParameterValue("XCLIENTE", oMensaje.RecuperarDescripcion("XCLIENTE"))
            oReporte.SetParameterValue("XSALDOENCUESTA", oMensaje.RecuperarDescripcion("XSALDOENCUESTA"))
            oReporte.SetParameterValue("XSALDOVENTA", oMensaje.RecuperarDescripcion("XSALDOVENTA"))
            oReporte.SetParameterValue("XSALDOACUMULADO", oMensaje.RecuperarDescripcion("XSALDOACUMULADO"))
            oReporte.SetParameterValue("XSALDOUTILIZADO", oMensaje.RecuperarDescripcion("XSALDOUTILIZADO"))
            oReporte.SetParameterValue("XSALDOUTILIZAR", oMensaje.RecuperarDescripcion("XSALDOUTILIZAR"))
            oReporte.SetParameterValue("XTOTAL", oMensaje.RecuperarDescripcion("XTotal"))
            oReporte.SetParameterValue("XNOMBRE", Session("Nombre").ToString().ToUpper())
            oReporte.SetParameterValue("FechaHoraImpresion", oMensaje.RecuperarDescripcion("Xfechahoraimpresion"))
            oReporte.SetParameterValue("CentroDistribucion", oMensaje.RecuperarDescripcion("XCentroDistribucion"))


        ElseIf Session("NumReporte") = 6 Then
            oReporte.FileName = Server.MapPath("Reports\Reportecanjes.rpt")

            oReporte.Database.Tables(1).SetDataSource(dt)

            oReporte.Database.Tables(0).SetDataSource(Session("DataTable"))

            oReporte.SetParameterValue("Fecha", oMensaje.RecuperarDescripcion("XFECHA") + "")
            oReporte.SetParameterValue("Nombre", Session("Nombre").ToString().ToUpper()) '''''''''''''****<----Nombre por filtros
            oReporte.SetParameterValue("Vendedor", oMensaje.RecuperarDescripcion("XVendedor") + " ")
            oReporte.SetParameterValue("Ruta", oMensaje.RecuperarDescripcion("Xruta") + "")
            oReporte.SetParameterValue("Cantidad", oMensaje.RecuperarDescripcion("Xcantidad"))

            oReporte.SetParameterValue("PRODUCTO", oMensaje.RecuperarDescripcion("XPRODUCTO"))
            oReporte.SetParameterValue("CANJE", oMensaje.RecuperarDescripcion("XACANJE")) ''<--------FALTA
            oReporte.SetParameterValue("UNIDAD", oMensaje.RecuperarDescripcion("XUNIDAD"))
            oReporte.SetParameterValue("PUNTOS", oMensaje.RecuperarDescripcion("XPUNTOS"))
            oReporte.SetParameterValue("FechaHoraImpresion", oMensaje.RecuperarDescripcion("Xfechahoraimpresion"))
            oReporte.SetParameterValue("TOTALCANJESRUTA", oMensaje.RecuperarDescripcion("XTOTALCANJESRUTA") + "")
            oReporte.SetParameterValue("TOTALCANJESFECHA", oMensaje.RecuperarDescripcion("XTOTALCANJESFECHA") + "")
            oReporte.SetParameterValue("TOTALCANJESVENDEDOR", oMensaje.RecuperarDescripcion("XTOTALCANJESVENDEDOR") + "")

            oReporte.SetParameterValue("XTOTAL", oMensaje.RecuperarDescripcion("XTOTAL") + "")
            oReporte.SetParameterValue("CentroDistribucion", oMensaje.RecuperarDescripcion("XCentroDistribucion"))
            oReporte.SetParameterValue("Enviadovendedor", Session("Vendedor"))
            oReporte.SetParameterValue("Enviadaruta", Session("Ruta"))
            oReporte.SetParameterValue("Enviadafecha", Session("RangoFechas"))

        ElseIf Session("NumReporte") = 8 Then

            oReporte.FileName = Server.MapPath("Reports\ReportePremios.rpt")

            oReporte.Database.Tables(1).SetDataSource(dt)

            oReporte.Database.Tables(0).SetDataSource(Session("DataTable"))

            oReporte.SetParameterValue("Minimo", (oMensaje.RecuperarDescripcion("XMinimo").ToUpper()(0)) + oMensaje.RecuperarDescripcion("XMinimo").Substring(1, oMensaje.RecuperarDescripcion("XMinimo").Length - 1).ToLower())
            oReporte.SetParameterValue("Nombre", Session("Nombre").ToString().ToUpper()) '''''''''''''****<----Nombre por filtros
            oReporte.SetParameterValue("Maximo", (oMensaje.RecuperarDescripcion("Xmaximo").ToUpper()(0)) + oMensaje.RecuperarDescripcion("Xmaximo").Substring(1, oMensaje.RecuperarDescripcion("Xmaximo").Length - 1).ToLower())
            oReporte.SetParameterValue("Producto", oMensaje.RecuperarDescripcion("Xproducto"))
            oReporte.SetParameterValue("Cantidad", oMensaje.RecuperarDescripcion("Xcantidad"))
            oReporte.SetParameterValue("Puntos", oMensaje.RecuperarDescripcion("XPuntos"))
            oReporte.SetParameterValue("UNIDAD", oMensaje.RecuperarDescripcion("XUNIDAD"))
            oReporte.SetParameterValue("Fecha", oMensaje.RecuperarDescripcion("XFecha") + "")
            oReporte.SetParameterValue("Enviadafecha", Session("RangoFechas"))
            oReporte.SetParameterValue("FechaHoraImpresion", oMensaje.RecuperarDescripcion("Xfechahoraimpresion"))

        ElseIf Session("NumReporte") = 9 Then '--Tiempos en ruta

            oReporte.FileName = Server.MapPath("Reports\ReporteTiemposRuta.rpt")

            oReporte.Database.Tables(0).SetDataSource(Session("DataTable"))
            oReporte.Database.Tables(1).SetDataSource(dt)
            oReporte.Subreports("Kilometraje").Database.Tables("Kilometraje").SetDataSource(ins.EjecutarConsulta(Session("Kilometraje"), IntCommandTimeOut))

            If (IsNothing(Session("subreport0"))) Then
                Session("subreport0") = ins.EjecutarConsulta(Session("Query2"), IntCommandTimeOut)
            End If
            oReporte.Subreports("TotalTiemposRuta").Database.Tables(0).SetDataSource(Session("subreport0"))
            If (IsNothing(Session("subreport1"))) Then
                Session("subreport1") = ins.EjecutarConsulta(Session("Query3"), IntCommandTimeOut)
            End If
            oReporte.Subreports("TotalTiemposRutaFueraAgenda").Database.Tables(0).SetDataSource(Session("subreport1"))

            oReporte.SetParameterValue("Nombre", Session("Nombre").ToString().ToUpper()) '''''''''''''****<----Nombre por filtros

            oReporte.SetParameterValue("XSecuencia", oMensaje.RecuperarDescripcion("SECSEC"))
            oReporte.SetParameterValue("XClienteClave", oMensaje.RecuperarDescripcion("CLIClave"))
            oReporte.SetParameterValue("XCodigoNoLeido", oMensaje.RecuperarDescripcion("XCodigoNoLeido"))
            oReporte.SetParameterValue("XNombreCliente", oMensaje.RecuperarDescripcion("CLICliente") + " - " + oMensaje.RecuperarDescripcion("xcontacto"))
            oReporte.SetParameterValue("XMinutosTransito", oMensaje.RecuperarDescripcion("XTiempoTransito"))
            oReporte.SetParameterValue("XHoraInicio", oMensaje.RecuperarDescripcion("VISHRFIN"))
            oReporte.SetParameterValue("XHoraFin", oMensaje.RecuperarDescripcion("VISHRINI"))
            oReporte.SetParameterValue("XMinutosVisita", oMensaje.RecuperarDescripcion("XTiempoVisita"))
            oReporte.SetParameterValue("XVenta", oMensaje.RecuperarDescripcion("XVENTA"))
            oReporte.SetParameterValue("XConcepto", oMensaje.RecuperarDescripcion("XConcepto"))
            oReporte.SetParameterValue("XVentaTotal", oMensaje.RecuperarDescripcion("XVentaTotal"))
            oReporte.SetParameterValue("XRuta", oMensaje.RecuperarDescripcion("XRuta"))
            oReporte.SetParameterValue("XInicioRecorrido", oMensaje.RecuperarDescripcion("XInicioRecorrido"))
            oReporte.SetParameterValue("XFinRecorrido", oMensaje.RecuperarDescripcion("XFinRecorrido"))


            oReporte.SetParameterValue("XVisitados", oMensaje.RecuperarDescripcion("XVisitados"))
            oReporte.SetParameterValue("XNoVisitados", oMensaje.RecuperarDescripcion("XNoVisitados"))

            oReporte.SetParameterValue("XTotalClientes", oMensaje.RecuperarDescripcion("XTotalClientes"))
            oReporte.SetParameterValue("XTiempoTransito", oMensaje.RecuperarDescripcion("XTiempoTransito"))
            oReporte.SetParameterValue("XTiempoRecorrido", oMensaje.RecuperarDescripcion("XTiempoRecorrido"))
            oReporte.SetParameterValue("XTiempoTransito", oMensaje.RecuperarDescripcion("XTiempoTransito"))
            oReporte.SetParameterValue("XEfectividadCompra", oMensaje.RecuperarDescripcion("XEfectividadCompra"))
            oReporte.SetParameterValue("XTotalCodigoNoLeido", oMensaje.RecuperarDescripcion("XTotalCodigoNoLeido"))

            oReporte.SetParameterValue("XVisitasSinVenta", oMensaje.RecuperarDescripcion("XVisitasSinVenta"))
            oReporte.SetParameterValue("XVisitaEfectiva", oMensaje.RecuperarDescripcion("XVisitaEfectiva"))
            oReporte.SetParameterValue("XTiempoPromedio", oMensaje.RecuperarDescripcion("XTiempoPromedio"))
            oReporte.SetParameterValue("XTiempoVisita", oMensaje.RecuperarDescripcion("XTiempoVisita"))

            oReporte.SetParameterValue("Fecha", oMensaje.RecuperarDescripcion("XFecha") + "")
            oReporte.SetParameterValue("Vendedor", oMensaje.RecuperarDescripcion("XVendedor"))
            oReporte.SetParameterValue("Ruta", oMensaje.RecuperarDescripcion("Xruta"))

            oReporte.SetParameterValue("Enviadovendedor", Session("Vendedor"))
            oReporte.SetParameterValue("Enviadaruta", Session("Ruta"))
            oReporte.SetParameterValue("Enviadafecha", Session("RangoFechas"))
            oReporte.SetParameterValue("CentroDistribucion", oMensaje.RecuperarDescripcion("XCentroDistribucion"))
            oReporte.SetParameterValue("FechaHoraImpresion", oMensaje.RecuperarDescripcion("Xfechahoraimpresion"))

            oReporte.SetParameterValue("XClientesEnAgenda", oMensaje.RecuperarDescripcion("XClientesEnAgenda"))
            oReporte.SetParameterValue("XClientesFueraAgenda", oMensaje.RecuperarDescripcion("XClientesFueraAgenda"))

            oReporte.SetParameterValue("NUMVisitados", oMensaje.RecuperarDescripcion("XVisitados"))
            oReporte.SetParameterValue("NUMNoVisitados", oMensaje.RecuperarDescripcion("XNoVisitados"))
            oReporte.SetParameterValue("NUMTotalClientes", oMensaje.RecuperarDescripcion("XTotalClientes"))
            oReporte.SetParameterValue("VisitaEfectiva", oMensaje.RecuperarDescripcion("XVisitaEfectiva"))
            oReporte.SetParameterValue("EfectividadCompra", oMensaje.RecuperarDescripcion("XEfectividadCompra"))
            oReporte.SetParameterValue("VisitasSinVenta", oMensaje.RecuperarDescripcion("XVisitasSinVenta"))

            oReporte.SetParameterValue("NUMVisitados2", oMensaje.RecuperarDescripcion("XVisitados"))
            oReporte.SetParameterValue("EfectividadCompra2", oMensaje.RecuperarDescripcion("XEfectividadCompra"))
            oReporte.SetParameterValue("VisitasSinVenta2", oMensaje.RecuperarDescripcion("XVisitasSinVenta"))

            oReporte.SetParameterValue("XKmInicial", oMensaje.RecuperarDescripcion("XKmInicial"))
            oReporte.SetParameterValue("XKmFinal", oMensaje.RecuperarDescripcion("XKmFinal"))
            oReporte.SetParameterValue("XKmConsumido", oMensaje.RecuperarDescripcion("XKmConsumido"))
            oReporte.SetParameterValue("XPlaca", oMensaje.RecuperarDescripcion("XPlaca"))


        ElseIf Session("NumReporte") = 10 Then '--Devoluciones y Cambios por Cliente
            'System.Diagnostics.Debug.WriteLine(Session("FechaInicial"))
            'System.Diagnostics.Debug.WriteLine(Session("FechaFinal"))

            If Session("ConversionKg") = False Then
                oReporte.FileName = Server.MapPath("Reports\ReporteDevolucionesCambiosCliente.rpt")
            Else
                oReporte.FileName = Server.MapPath("Reports\ReporteDevolucionesCambiosClienteKg.rpt")
            End If

            oReporte.Database.Tables(0).SetDataSource(Session("DataTable"))
            oReporte.Database.Tables(1).SetDataSource(dt)

            'Parámetros
            oReporte.SetParameterValue("@NombreReporte", Session("Nombre").ToString().ToUpper()) '''''''''''''****<----Nombre por filtros)
            oReporte.SetParameterValue("@ProductoClave", oMensaje.RecuperarDescripcion("XClave"))
            oReporte.SetParameterValue("@ProductoNombre", oMensaje.RecuperarDescripcion("XProducto"))
            oReporte.SetParameterValue("@Unidad", oMensaje.RecuperarDescripcion("XUnidad"))
            oReporte.SetParameterValue("@Precio", oMensaje.RecuperarDescripcion("XPrecio"))
            oReporte.SetParameterValue("@Devolucion", oMensaje.RecuperarDescripcion("XDevolucion"))
            oReporte.SetParameterValue("@Cambio", oMensaje.RecuperarDescripcion("XCambio"))
            oReporte.SetParameterValue("@Cantidad", oMensaje.RecuperarDescripcion("XCantidad"))
            oReporte.SetParameterValue("@Importe", oMensaje.RecuperarDescripcion("XImporte"))
            oReporte.SetParameterValue("@Total", oMensaje.RecuperarDescripcion("XTotal").ToUpper)
            oReporte.SetParameterValue("@Fecha", oMensaje.RecuperarDescripcion("XFecha") & "")
            oReporte.SetParameterValue("@RangoFechas", Session("RangoFechas"))
            oReporte.SetParameterValue("@FechaHora", oMensaje.RecuperarDescripcion("XFechaHora"))
            oReporte.SetParameterValue("XUnidades", oMensaje.RecuperarDescripcion("XUnidades"))
            oReporte.SetParameterValue("Ruta", oMensaje.RecuperarDescripcion("XRuta") + "")
            oReporte.SetParameterValue("Vendedor", oMensaje.RecuperarDescripcion("XVendedor") + "")
            oReporte.SetParameterValue("CentroDistribucion", oMensaje.RecuperarDescripcion("XCentroDistribucion"))
            oReporte.SetParameterValue("FechaHoraImpresion", oMensaje.RecuperarDescripcion("Xfechahoraimpresion"))
            If Session("ConversionKg") Then
                oReporte.SetParameterValue("@KgLt", oMensaje.RecuperarDescripcion("XKgLt"))
            End If
        ElseIf Session("NumReporte") = 16 Then 'Ventas Totales por Esquema de Producto

            If Session("ConversionKg") = False Then
                oReporte.FileName = Server.MapPath("Reports\ReporteVentasTotalRuta.rpt")
                oReporte.Database.Tables("VentasTotalesRuta").SetDataSource(Session("DataTable"))
                oReporte.Database.Tables("Configuracion").SetDataSource(dt)
            Else
                oReporte.FileName = Server.MapPath("Reports\ReporteVentasTotalRutaKg.rpt")
                oReporte.Database.Tables("VentasTotalesRutaKg").SetDataSource(Session("DataTable"))
                oReporte.Database.Tables("Configuracion").SetDataSource(dt)
            End If

            If (IsNothing(Session("subreport0"))) Then
                Session("subreport0") = ins.EjecutarConsulta(Session("Query2"), IntCommandTimeOut)
            End If
            'oReporte.Subreports(0).Database.Tables(0).SetDataSource(ins.EjecutarConsulta(Session("Query2"), IntCommandTimeOut))
            oReporte.Subreports(0).Database.Tables(0).SetDataSource(Session("subreport0"))

            If (IsNothing(Session("subreport1"))) Then
                Session("subreport1") = ins.EjecutarConsulta(Session("Query3"), IntCommandTimeOut)
            End If
            oReporte.Subreports(1).Database.Tables(0).SetDataSource(Session("subreport1"))
            'oReporte.Subreports(1).Database.Tables(0).SetDataSource(ins.EjecutarConsulta(Session("Query3"), IntCommandTimeOut))


            If (IsNothing(Session("subreport2"))) Then
                Session("subreport2") = ins.EjecutarConsulta(Session("Query4"), IntCommandTimeOut)
            End If
            oReporte.Subreports(2).Database.Tables(0).SetDataSource(Session("subreport2"))
            'oReporte.Subreports(2).Database.Tables(0).SetDataSource(ins.EjecutarConsulta(Session("Query4"), IntCommandTimeOut))


            If (IsNothing(Session("subreport3"))) Then
                Session("subreport3") = ins.EjecutarConsulta(Session("Query5"), IntCommandTimeOut)
            End If
            oReporte.Subreports(3).Database.Tables(0).SetDataSource(Session("subreport3"))
            'oReporte.Subreports(3).Database.Tables(0).SetDataSource(ins.EjecutarConsulta(Session("Query5"), IntCommandTimeOut))


            With oReporte
                .SetParameterValue("NombreReporte", Session("Nombre").ToString().ToUpper())
                .SetParameterValue("Clave", oMensaje.RecuperarDescripcion("XClave"))
                .SetParameterValue("Esquema", oMensaje.RecuperarDescripcion("XNombre"))
                .SetParameterValue("Unidades", oMensaje.RecuperarDescripcion("XUnidades"))
                .SetParameterValue("Importe", oMensaje.RecuperarDescripcion("XImporte"))
                .SetParameterValue("Descuentos", oMensaje.RecuperarDescripcion("XDescuentos"))
                .SetParameterValue("TotalMin", oMensaje.RecuperarDescripcion("XTotalMin"))
                '.SetParameterValue("ClientesConCompra", oMensaje.RecuperarDescripcion("XClientesConCompra") + "")
                '.SetParameterValue("Cobertura", oMensaje.RecuperarDescripcion("XCobertura"))
                .SetParameterValue("Fecha", oMensaje.RecuperarDescripcion("XFecha") + "")
                .SetParameterValue("Vendedor", oMensaje.RecuperarDescripcion("XVendedor") + "")
                .SetParameterValue("Ruta", oMensaje.RecuperarDescripcion("XRuta") + "")
                .SetParameterValue("Total", oMensaje.RecuperarDescripcion("XTotal"))
                .SetParameterValue("FechaHoraImpresion", oMensaje.RecuperarDescripcion("Xfechahoraimpresion"))

                .SetParameterValue("TotalClientesVisitados", oMensaje.RecuperarDescripcion("XTotalClientesVisitados") + "")
                '.SetParameterValue("TotalClientesRuta", oMensaje.RecuperarDescripcion("XTotalClientesRuta") + "")
                '.SetParameterValue("TotalClientesConCompra", oMensaje.RecuperarDescripcion("XTotalClientesConCompra") + "")
                '.SetParameterValue("TotalClientesSinCompra", oMensaje.RecuperarDescripcion("XTotalClientesSinCompra") + "")

                .SetParameterValue("TotalVendedorClientesVisitados", oMensaje.RecuperarDescripcion("XTotalVendedorClientesVisitados") + "")
                '.SetParameterValue("TotalVendedorClientesRuta", oMensaje.RecuperarDescripcion("XTotalVendedorClientesRuta") + "")
                '.SetParameterValue("TotalVendedorClientesConCompra", oMensaje.RecuperarDescripcion("XTotalVendedorClientesConCompra") + "")
                '.SetParameterValue("TotalVendedorClientesSinCompra", oMensaje.RecuperarDescripcion("XTotalVendedorClientesSinCompra") + "")

                .SetParameterValue("TotalFechaClientesVisitados", oMensaje.RecuperarDescripcion("XTotalFechaClientesVisitados") + "")
                '.SetParameterValue("TotalFechaClientesRuta", oMensaje.RecuperarDescripcion("XTotalFechaClientesRuta") + "")
                '.SetParameterValue("TotalFechaClientesConCompra", oMensaje.RecuperarDescripcion("XTotalFechaClientesConCompra") + "")
                '.SetParameterValue("TotalFechaClientesSinCompra", oMensaje.RecuperarDescripcion("XTotalFechaClientesSinCompra") + "")

                .SetParameterValue("CentroDistribucion", oMensaje.RecuperarDescripcion("XCentroDistribucion"))

                .SetParameterValue("xtotalcedictevis", oMensaje.RecuperarDescripcion("xtotalcedictevis") + "")
                '.SetParameterValue("xtotalcedicteruta", oMensaje.RecuperarDescripcion("xtotalcedicteruta") + "")
                '.SetParameterValue("xtotalcedictecompra", oMensaje.RecuperarDescripcion("xtotalcedictecompra") + "")
                '.SetParameterValue("xtotalcedictescompra", oMensaje.RecuperarDescripcion("xtotalcedictescompra") + "")

                If Session("ConversionKg") = True Then
                    .SetParameterValue("KiloLitros", oMensaje.RecuperarDescripcion("XKiloLitros"))
                End If

            End With
            oReporte.SetParameterValue("Enviadovendedor", Session("Vendedor"))
            oReporte.SetParameterValue("Enviadaruta", Session("Ruta"))
            oReporte.SetParameterValue("Enviadafecha", Session("RangoFechas"))

            'Dim sCadena As String = String.Empty
            'For i As Integer = 0 To oReporte.ParameterFields.Count - 1
            '    If Not oReporte.ParameterFields(i).HasCurrentValue Then
            '        sCadena &= oReporte.ParameterFields(i).Name & "," & vbCrLf
            '    End If

            'Next
            'If sCadena <> String.Empty Then System.Diagnostics.Debug.WriteLine(sCadena)

        ElseIf Session("NumReporte") = 14 Then 'Reporte de Ventas por Esquema

            If Session("ConversionKg") Then
                oReporte.FileName = Server.MapPath("Reports\ReporteVentasEsquemaKg.rpt")
                oReporte.Database.Tables("VentaEsquemaKg").SetDataSource(Session("DataTable"))
            Else
                oReporte.FileName = Server.MapPath("Reports\ReporteVentaEsquema.rpt")
                oReporte.Database.Tables("VentaEsquema").SetDataSource(Session("DataTable"))
            End If

            'oReporte.FileName = Server.MapPath("Reports\ReporteVentaEsquema.rpt")
            oReporte.Database.Tables("Configuracion").SetDataSource(dt)


            If (Session("TipoReporte") = "Detallado") Then
                oReporte.SetParameterValue("Detallado", 1)
            Else
                oReporte.SetParameterValue("Detallado", 0)
            End If
            If Session("ConversionKg") Then
                oReporte.SetParameterValue("KgLt", oMensaje.RecuperarDescripcion("XKgLt"))
                oReporte.SetParameterValue("resumen3", oMensaje.RecuperarDescripcion("Xresumendekilolitros"))
            End If
            oReporte.SetParameterValue("nombre", Session("Nombre").ToString().ToUpper()) '''''''''''''****<----Nombre por filtros)
            oReporte.SetParameterValue("fecha", oMensaje.RecuperarDescripcion("Xfecha"))
            oReporte.SetParameterValue("vendedor", oMensaje.RecuperarDescripcion("Xvendedor"))
            oReporte.SetParameterValue("unidad", oMensaje.RecuperarDescripcion("Xunidad"))
            oReporte.SetParameterValue("venta", oMensaje.RecuperarDescripcion("Xventam"))
            oReporte.SetParameterValue("ruta", oMensaje.RecuperarDescripcion("Xruta"))
            oReporte.SetParameterValue("cant", oMensaje.RecuperarDescripcion("Xcantidad"))
            oReporte.SetParameterValue("$", oMensaje.RecuperarDescripcion("X$"))
            oReporte.SetParameterValue("devolucion", oMensaje.RecuperarDescripcion("Xdevolucion"))
            oReporte.SetParameterValue("cambio", oMensaje.RecuperarDescripcion("Xcambio"))
            oReporte.SetParameterValue("resumen1", oMensaje.RecuperarDescripcion("Xresumendeunidades"))
            oReporte.SetParameterValue("resumen2", oMensaje.RecuperarDescripcion("Xresumendeimportes"))
            oReporte.SetParameterValue("total", oMensaje.RecuperarDescripcion("Xtotal"))
            oReporte.SetParameterValue("grantotal", oMensaje.RecuperarDescripcion("Xgrantotal"))
            oReporte.SetParameterValue("clave", oMensaje.RecuperarDescripcion("Xclave"))
            oReporte.SetParameterValue("producto", oMensaje.RecuperarDescripcion("Xproducto"))
            oReporte.SetParameterValue("ventas", oMensaje.RecuperarDescripcion("XVentas"))
            oReporte.SetParameterValue("devoluciones", oMensaje.RecuperarDescripcion("XDevoluciones"))
            oReporte.SetParameterValue("cambios", oMensaje.RecuperarDescripcion("XCambios"))
            oReporte.SetParameterValue("unidades", oMensaje.RecuperarDescripcion("XUnidades"))
            oReporte.SetParameterValue("Enviadovendedor", Session("Vendedor"))
            oReporte.SetParameterValue("FechaHoraImpresion", oMensaje.RecuperarDescripcion("XFechaHoraImpresion"))
            oReporte.SetParameterValue("CentroDistribucion", oMensaje.RecuperarDescripcion("XCentroDistribucion"))
            oReporte.SetParameterValue("Enviadafecha", Session("RangoFechas"))


        ElseIf Session("NumReporte") = 17 Then '--Ventas por cliente

            If Session("ConversionKg") = True Then
                oReporte.FileName = Server.MapPath("Reports\ReporteVentasxClienteKg.rpt")
            Else
                oReporte.FileName = Server.MapPath("Reports\ReporteVentasxCliente.rpt")
            End If

            Dim dtVenta As Data.DataTable = CType(Session("DataTable"), Data.DataTable)

            oReporte.Database.Tables(0).SetDataSource(dtVenta)
            oReporte.Database.Tables(1).SetDataSource(dt)

            If Session("ConversionKg") Then
                oReporte.SetParameterValue("KiloLitros", oMensaje.RecuperarDescripcion("XKiloLitros"))
            End If

            oReporte.SetParameterValue("XVisEfectuadas", oMensaje.RecuperarDescripcion("XGranTotalVisitaEfectuada") + "")
            oReporte.SetParameterValue("XVisEfectPorRuta", oMensaje.RecuperarDescripcion("XVisEfectPorRuta") + "")
            oReporte.SetParameterValue("XVisEfectPorVend", oMensaje.RecuperarDescripcion("XVisEfectPorVend") + "")
            oReporte.SetParameterValue("XVisxClienteEnAgenda", oMensaje.RecuperarDescripcion("XVisxClienteEnAgenda") + "")
            oReporte.SetParameterValue("XVisxClienteFueraAgenda", oMensaje.RecuperarDescripcion("XVisxClienteFueraAgenda") + "")

            oReporte.SetParameterValue("XImporteClienteEnAgenda", oMensaje.RecuperarDescripcion("XImporteClienteEnAgenda") + "")
            oReporte.SetParameterValue("XImporteClienteFueraAgenda", oMensaje.RecuperarDescripcion("XImporteClienteFueraAgenda") + "")
            oReporte.SetParameterValue("XImporteRuta", oMensaje.RecuperarDescripcion("XImporteRuta") + "")
            oReporte.SetParameterValue("XImporteVendedor", oMensaje.RecuperarDescripcion("XImporteVendedor") + "")

            oReporte.SetParameterValue("XNombreReporte", Session("Nombre").ToString().ToUpper())
            oReporte.SetParameterValue("XVendedor", oMensaje.RecuperarDescripcion("XVendedor") + "")
            oReporte.SetParameterValue("XRuta", oMensaje.RecuperarDescripcion("XRuta") + "")
            oReporte.SetParameterValue("XCliente", oMensaje.RecuperarDescripcion("XCliente") + "")
            oReporte.SetParameterValue("XEsquema", oMensaje.RecuperarDescripcion("XEsquema") + "")
            oReporte.SetParameterValue("XFecha", oMensaje.RecuperarDescripcion("XFecha") + "")
            oReporte.SetParameterValue("XProducto", oMensaje.RecuperarDescripcion("XProducto"))
            oReporte.SetParameterValue("XUnidad", oMensaje.RecuperarDescripcion("XUnidades"))
            oReporte.SetParameterValue("XImporte", oMensaje.RecuperarDescripcion("XImporte"))
            oReporte.SetParameterValue("XClave", oMensaje.RecuperarDescripcion("XClave"))
            oReporte.SetParameterValue("XDiasCompra", oMensaje.RecuperarDescripcion("XDiasCompra"))
            oReporte.SetParameterValue("XCobertura", oMensaje.RecuperarDescripcion("XCobertura"))
            oReporte.SetParameterValue("XTotal", oMensaje.RecuperarDescripcion("XTotal") + "")
            oReporte.SetParameterValue("XDescuento", oMensaje.RecuperarDescripcion("XDescuento") + "")
            oReporte.SetParameterValue("XGranTotal", oMensaje.RecuperarDescripcion("XGranTotalCentroDistribucion") + "")
            oReporte.SetParameterValue("FechaHoraImpresion", oMensaje.RecuperarDescripcion("XFechaHoraImpresion") + "")

            oReporte.SetParameterValue("Enviadovendedor", Session("Vendedor"))
            oReporte.SetParameterValue("Enviadaruta", Session("Ruta"))
            oReporte.SetParameterValue("Enviadafecha", Session("RangoFechas"))

            oReporte.SetParameterValue("CentroDistribucion", oMensaje.RecuperarDescripcion("XCentroDistribucion"))
            oReporte.SetParameterValue("Xvisitacedi", oMensaje.RecuperarDescripcion("Xvisitasefectuadascedi"))
            oReporte.SetParameterValue("Ximportecedi", oMensaje.RecuperarDescripcion("Ximportecedi"))

        ElseIf Session("NumReporte") = 18 Then '--Cargas
            oReporte.FileName = Server.MapPath("Reports\reporteCargas.rpt")

            Dim dtCargas As Data.DataTable = Session("DataTable")

            ''************
            If (IsNothing(Session("subreport0"))) Then
                Session("subreport0") = ins.EjecutarConsulta(Session("Query2"), IntCommandTimeOut)
            End If
            Dim dtCargasxFecha As Data.DataTable = Session("subreport0")
            ''************
            'Dim dtCargasxFecha As Data.DataTable = ins.EjecutarConsulta(Session("Query2"), IntCommandTimeOut)

            Dim Vendedor As String = String.Empty

            oReporte.Database.Tables("Configuracion").SetDataSource(dt)
            oReporte.Database.Tables("Cargas").SetDataSource(dtCargas)
            oReporte.Database.Tables("CargasxFecha").SetDataSource(dtCargasxFecha)

            oReporte.SetParameterValue("@NombreReporte", Session("Nombre").ToString().ToUpper())
            oReporte.SetParameterValue("@MsgCentroDistribucion", oMensaje.RecuperarDescripcion("XCentroDistribucion"))
            oReporte.SetParameterValue("@MsgVendedor", oMensaje.RecuperarDescripcion("XVendedor"))
            oReporte.SetParameterValue("@MsgFecha", oMensaje.RecuperarDescripcion("XFecha"))
            oReporte.SetParameterValue("MsgFase", oMensaje.RecuperarDescripcion("XFase"))
            oReporte.SetParameterValue("MsgFolio", oMensaje.RecuperarDescripcion("XFolio"))

            oReporte.SetParameterValue("@FiltroCEDI", Session("CEDI").ToString())
            oReporte.SetParameterValue("@FiltroFecha", Session("RangoFechas"))
            oReporte.SetParameterValue("@FiltroVendedor", Session("Vendedor"))

            oReporte.SetParameterValue("@TituloClave", oMensaje.RecuperarDescripcion("PROProductoClave"))
            oReporte.SetParameterValue("@TituloProducto", oMensaje.RecuperarDescripcion("XProducto"))
            oReporte.SetParameterValue("@TituloUnidad", oMensaje.RecuperarDescripcion("XUnidades"))
            oReporte.SetParameterValue("@TituloCantidad", oMensaje.RecuperarDescripcion("TPDCantidad"))
            oReporte.SetParameterValue("@TituloPiezas", oMensaje.RecuperarDescripcion("XPiezas"))

            oReporte.SetParameterValue("@SeparaTotalxFecha", oMensaje.RecuperarDescripcion("XTotalSolicitudesFecha"))
            oReporte.SetParameterValue("@TotalPiezas", oMensaje.RecuperarDescripcion("XTotalPiezas"))
            oReporte.SetParameterValue("@SubTotalxFecha", oMensaje.RecuperarDescripcion("XTotalPiezas").ToUpper)
            oReporte.SetParameterValue("FechaHoraImpresion", oMensaje.RecuperarDescripcion("XFechaHoraImpresion") + "")

        ElseIf Session("NumReporte") = 19 Then

            oReporte.FileName = Server.MapPath("Reports\ReporteLiquidacion.rpt")

            oReporte.Database.Tables(0).SetDataSource(dt)

            oReporte.Database.Tables(1).SetDataSource(Session("DataTable"))

            If IsNothing(Session("subreport0")) Then
                Session("subreport0") = ins.EjecutarConsulta(Session("Query2"), IntCommandTimeOut)
            End If
            oReporte.Subreports("ReporteTotalCharolas").Database.Tables(0).SetDataSource(Session("subreport0"))

            'oReporte.Subreports("ReporteTotalCharolas").Database.Tables(0).SetDataSource(ins.EjecutarConsulta(Session("Query2"), IntCommandTimeOut))

            Dim ldt As New Data.DataTable("Desglose")

            ldt.Columns.Add("Descripcion", GetType(String))
            If IsNothing(Session("subreport1")) Then
                Session("subreport1") = ins.EjecutarConsulta("SELECT VAV.Grupo, VAD.Descripcion FROM VARValor AS VAV INNER JOIN VAVDescripcion AS VAD ON VAD.VARCodigo=VAV.VARCodigo AND VAD.VAVClave=VAV.VAVClave WHERE VAD.VADTipoLenguaje='" & Session("lenguaje") & "' AND VAV.VARCodigo='DENOMINA' Order by VAV.Grupo, convert(float, VAD.Descripcion) desc", IntCommandTimeOut)
            End If
            Dim ldtVAR As Data.DataTable = Session("subreport1")

            'Dim ldtVAR As Data.DataTable = ins.EjecutarConsulta("SELECT VAV.Grupo, VAD.Descripcion FROM VARValor AS VAV INNER JOIN VAVDescripcion AS VAD ON VAD.VARCodigo=VAV.VARCodigo AND VAD.VAVClave=VAV.VAVClave WHERE VAD.VADTipoLenguaje='" & Session("lenguaje") & "' AND VAV.VARCodigo='DENOMINA' Order by VAV.Grupo, convert(float, VAD.Descripcion) desc")
            For Each ldrVAR As Data.DataRow In ldtVAR.Rows
                Dim ldr As Data.DataRow = ldt.NewRow
                If ldrVAR("Grupo") = "1" Then
                    ldr("Descripcion") = oMensaje.RecuperarDescripcion("XBilletes", New String() {ldrVAR("Descripcion")})
                ElseIf ldrVAR("Grupo") = "2" Then
                    ldr("Descripcion") = oMensaje.RecuperarDescripcion("XMonedasDe", New String() {ldrVAR("Descripcion")})
                End If
                ldt.Rows.Add(ldr)
            Next

            oReporte.Subreports(0).Database.Tables(0).SetDataSource(ldt)

            oReporte.SetParameterValue("NOMBRE", Session("Nombre").ToString().ToUpper()) '''''''''''''****<----Nombre por filtros
            oReporte.SetParameterValue("CentroDistribucion", oMensaje.RecuperarDescripcion("XCentroDistribucion"))
            oReporte.SetParameterValue("FECHA", oMensaje.RecuperarDescripcion("XFECHA"))
            oReporte.SetParameterValue("VENDEDOR", oMensaje.RecuperarDescripcion("XVendedor"))

            oReporte.SetParameterValue("Enviadovendedor", Session("Vendedor"))
            oReporte.SetParameterValue("Enviadafecha", Session("RangoFechas"))
            oReporte.SetParameterValue("pvClaveVendedor", Session("USUClave"))
            oReporte.SetParameterValue("Ruta", oMensaje.RecuperarDescripcion("XRuta"))
            oReporte.SetParameterValue("RutasVendedor", Session("RutasVendedor"))

            oReporte.SetParameterValue("CLAVE", oMensaje.RecuperarDescripcion("XCLAVE"))
            oReporte.SetParameterValue("PRODUCTO", oMensaje.RecuperarDescripcion("XPRODUCTO"))
            oReporte.SetParameterValue("Carga", oMensaje.RecuperarDescripcion("XCARGA"))
            oReporte.SetParameterValue("Devolucion", oMensaje.RecuperarDescripcion("XDEVOLUCION"))
            oReporte.SetParameterValue("Frio", oMensaje.RecuperarDescripcion("XFRIO"))
            oReporte.SetParameterValue("Reclasificado", oMensaje.RecuperarDescripcion("XReclasificado"))
            oReporte.SetParameterValue("DevolucionCte", oMensaje.RecuperarDescripcion("XDevolucionCliente"))
            oReporte.SetParameterValue("Otros", oMensaje.RecuperarDescripcion("XOtrosConceptos"))
            oReporte.SetParameterValue("Ajuste", oMensaje.RecuperarDescripcion("XAJUSTE"))
            oReporte.SetParameterValue("Piezas", oMensaje.RecuperarDescripcion("XPIEZASVEN"))
            oReporte.SetParameterValue("Importe", oMensaje.RecuperarDescripcion("XIMPORTE"))
            oReporte.SetParameterValue("PzaFaltante", oMensaje.RecuperarDescripcion("XPiezasFaltantes"))
            oReporte.SetParameterValue("ImpFaltante", oMensaje.RecuperarDescripcion("XImporteFaltantes"))

            oReporte.SetParameterValue("Totales", oMensaje.RecuperarDescripcion("XTOTALES"))
            oReporte.SetParameterValue("Porcentajes", oMensaje.RecuperarDescripcion("XPorcentaje"))
            oReporte.SetParameterValue("FechaHoraImpresion", oMensaje.RecuperarDescripcion("Xfechahoraimpresion"))

            oReporte.SetParameterValue("Entrego", oMensaje.RecuperarDescripcion("XEntrego"))
            oReporte.SetParameterValue("Recibio", oMensaje.RecuperarDescripcion("XRecibio"))

            oReporte.SetParameterValue("GranTotal", oMensaje.RecuperarDescripcion("XGranTotal"))
            oReporte.SetParameterValue("Ventas", oMensaje.RecuperarDescripcion("XVentas"))
            oReporte.SetParameterValue("TotalFaltantes", oMensaje.RecuperarDescripcion("XTotalFaltantes"))
            oReporte.SetParameterValue("TotalDevolucionCte", oMensaje.RecuperarDescripcion("XTotalDevCliente"))
            oReporte.SetParameterValue("TotalAjuste", oMensaje.RecuperarDescripcion("XTotalAjuste"))
            oReporte.SetParameterValue("BonificacionAjuste", oMensaje.RecuperarDescripcion("XBonificacionAjuste"))

            oReporte.SetParameterValue("Charolas", oMensaje.RecuperarDescripcion("XCharolas"), "ReporteTotalCharolas")
            oReporte.SetParameterValue("Cargas", oMensaje.RecuperarDescripcion("XCarga"), "ReporteTotalCharolas")
            oReporte.SetParameterValue("Vacias", oMensaje.RecuperarDescripcion("XVacias"), "ReporteTotalCharolas")
            oReporte.SetParameterValue("Total", oMensaje.RecuperarDescripcion("XTotal"), "ReporteTotalCharolas")

            oReporte.SetParameterValue("Desglose", oMensaje.RecuperarDescripcion("XDesgloseBM"), "ReporteLiquidacionDesglose")
            oReporte.SetParameterValue("Cantidad2", oMensaje.RecuperarDescripcion("XCantidad"), "ReporteLiquidacionDesglose")
            oReporte.SetParameterValue("Importe2", oMensaje.RecuperarDescripcion("XImporte"), "ReporteLiquidacionDesglose")
            oReporte.SetParameterValue("Cheques", oMensaje.RecuperarDescripcion("XImporteEnCheques"), "ReporteLiquidacionDesglose")
            oReporte.SetParameterValue("Creditos", oMensaje.RecuperarDescripcion("XImporteEnCreditos"), "ReporteLiquidacionDesglose")
            oReporte.SetParameterValue("Notas", oMensaje.RecuperarDescripcion("XImporteEnNotas"), "ReporteLiquidacionDesglose")
            oReporte.SetParameterValue("Total2", oMensaje.RecuperarDescripcion("XImporteT"), "ReporteLiquidacionDesglose")

        ElseIf Session("NumReporte") = 20 Then '--Movimientos sin inventario sin visita
            If (Session("TipoReporte").ToString() = "General") Then
                oReporte.FileName = Server.MapPath("Reports\ReporteMovimientosSISVG.rpt")
            Else
                oReporte.FileName = Server.MapPath("Reports\ReporteMovimientosSISV.rpt")
            End If


            oReporte.Database.Tables(1).SetDataSource(dt)
            dt = CType(Session("DataTable"), System.Data.DataTable)
            oReporte.Database.Tables(0).SetDataSource(dt)
            oReporte.SetParameterValue("@NombreReporte", Session("Nombre").ToString().ToUpper())
            oReporte.SetParameterValue("@MsgCentroDistribucion", oMensaje.RecuperarDescripcion("XCentroDistribucion"))
            oReporte.SetParameterValue("@MsgVendedor", oMensaje.RecuperarDescripcion("XVendedor"))
            oReporte.SetParameterValue("@MsgFecha", oMensaje.RecuperarDescripcion("XFecha"))

            oReporte.SetParameterValue("@FiltroCEDI", Session("CEDI").ToString())
            oReporte.SetParameterValue("@FiltroFecha", Session("RangoFechas"))
            oReporte.SetParameterValue("@FiltroVendedor", Session("Vendedor"))

            oReporte.SetParameterValue("@TituloClave", oMensaje.RecuperarDescripcion("PROProductoClave"))
            oReporte.SetParameterValue("@TituloProducto", oMensaje.RecuperarDescripcion("XProducto"))
            oReporte.SetParameterValue("@TituloUnidad", oMensaje.RecuperarDescripcion("XUnidades"))
            oReporte.SetParameterValue("@TituloCantidad", oMensaje.RecuperarDescripcion("TPDCantidad"))
            'oReporte.SetParameterValue("@TituloPiezas", oMensaje.RecuperarDescripcion("XPiezas"))

            'oReporte.SetParameterValue("@SeparaTotalxFecha", oMensaje.RecuperarDescripcion("XTotalSolicitudesFecha"))
            oReporte.SetParameterValue("@TotalPiezas", oMensaje.RecuperarDescripcion("XTotal"))
            oReporte.SetParameterValue("@TotalFecha", oMensaje.RecuperarDescripcion("XTotalFecha"))
            oReporte.SetParameterValue("@TotalVendedor", oMensaje.RecuperarDescripcion("XTotalSolicitudesVendedor").ToUpper)
            oReporte.SetParameterValue("@TotalCentroDistribucion", oMensaje.RecuperarDescripcion("Xtotalcentrodistribucion").ToUpper)
            oReporte.SetParameterValue("TipoReporte", Session("TipoReporte").ToString())
            oReporte.SetParameterValue("FechaHoraImpresion", oMensaje.RecuperarDescripcion("XFechaHoraImpresion") + "")

        ElseIf Session("NumReporte") = 22 Then '--Produccion
            oReporte.FileName = Server.MapPath("Reports\ReporteProduccion.rpt")
            oReporte.Database.Tables(0).SetDataSource(dt)
            dt = CType(Session("DataTable"), System.Data.DataTable)
            oReporte.Database.Tables(1).SetDataSource(dt)

            oReporte.SetParameterValue("@NombreReporte", Session("Nombre").ToString().ToUpper())

            oReporte.SetParameterValue("FiltroFecha", Session("RangoFechas"))

            oReporte.SetParameterValue("XCentroDistribucion", oMensaje.RecuperarDescripcion("XCentroDistribucion"))
            oReporte.SetParameterValue("XFecha", oMensaje.RecuperarDescripcion("XFECHA"))

            oReporte.SetParameterValue("XClave", oMensaje.RecuperarDescripcion("XClave"))
            oReporte.SetParameterValue("XProducto", oMensaje.RecuperarDescripcion("XProducto"))
            oReporte.SetParameterValue("PROUnidadProduccion", oMensaje.RecuperarDescripcion("PROUnidadProduccion"))
            oReporte.SetParameterValue("XUnidadCar", oMensaje.RecuperarDescripcion("XUnidadCar"))
            oReporte.SetParameterValue("XunidadesPorMateria", oMensaje.RecuperarDescripcion("XUnidades") & " " & oMensaje.RecuperarDescripcion("XPor") & " " & oMensaje.RecuperarDescripcion("XMateriaPrima"))
            oReporte.SetParameterValue("XReqMatPrim", oMensaje.RecuperarDescripcion("XRequerimiento") & " " & oMensaje.RecuperarDescripcion("XMateriaPrima"))
            oReporte.SetParameterValue("XTotal", oMensaje.RecuperarDescripcion("XTotal"))

            oReporte.SetParameterValue("FechaHoraImpresion", oMensaje.RecuperarDescripcion("XFechaHoraImpresion") + "")

        ElseIf Session("NumReporte") = 1 Or Session("NumReporte") = 2 Or Session("NumReporte") = 21 Or Session("NumReporte") = 37 Then

            If Session("TipoReporte") = "Detallado" Then
                If Session("NumReporte") = 37 Then
                    oReporte.FileName = Server.MapPath("Reports\ReporteVentasGatDet.rpt")
                ElseIf Session("NumReporte") = 21 Then 'Movimientos sin inventario en visita
                    oReporte.FileName = Server.MapPath("Reports\ReporteMovSinInEnVis.rpt")
                ElseIf Session("NumReporte") = 2 Then 'Pedidos
                    If Session("ConversionKg") = True Then
                        oReporte.FileName = Server.MapPath("Reports\REPORTEVENTASKG.rpt")
                    Else
                        oReporte.FileName = Server.MapPath("Reports\REPORTEVENTAS.rpt")
                    End If
                Else
                    oReporte.FileName = Server.MapPath("Reports\REPORTEVENTAS.rpt")
                End If
            ElseIf Session("TipoReporte") = "General" Then
                If Session("NumReporte") = 21 Then 'Movimientos sin inventario en visita
                    oReporte.FileName = Server.MapPath("Reports\ReporteMovSinInEnVis2.rpt")
                ElseIf Session("NumReporte") = 2 Then 'Pedidos
                    If Session("ConversionKg") = True Then
                        oReporte.FileName = Server.MapPath("Reports\REPORTEVENTASKG2.rpt")
                    Else
                        oReporte.FileName = Server.MapPath("Reports\REPORTEVENTAS2.rpt")
                    End If
                Else
                    oReporte.FileName = Server.MapPath("Reports\REPORTEVENTAS2.rpt")
                End If
            End If
            oReporte.Database.Tables(1).SetDataSource(dt)
            'dt = ins.EjecutarConsulta(Session("Query"))
            '-----------------------------------------
            dt = Session("DataTable")
            'System.Diagnostics.Debug.WriteLine(dt.Rows.Count)
            '-----------------------------------------
            oReporte.Database.Tables(0).SetDataSource(dt)
            If IsNothing(Session("subreport0")) Then
                Session("subreport0") = ins.EjecutarConsulta(Session("Query2"), IntCommandTimeOut)
            End If
            dt = Session("subreport0")
            'dt = ins.EjecutarConsulta(Session("Query2"), IntCommandTimeOut)

            'System.Diagnostics.Debug.WriteLine(dt.Rows.Count)
            oReporte.Subreports(0).Database.Tables(0).SetDataSource(dt)

            oReporte.SetParameterValue("NOMBRE", Session("Nombre").ToString().ToUpper()) '''''''''''''****<----Nombre por filtros
            oReporte.SetParameterValue("FECHA", oMensaje.RecuperarDescripcion("XFECHA"))
            oReporte.SetParameterValue("VENDEDOR", oMensaje.RecuperarDescripcion("XVendedor"))

            oReporte.SetParameterValue("RUTA", oMensaje.RecuperarDescripcion("Xruta"))
            oReporte.SetParameterValue("CLAVE", oMensaje.RecuperarDescripcion("XCLAVE"))

            oReporte.SetParameterValue("TOTAL", oMensaje.RecuperarDescripcion("XTOTALmin"))

            oReporte.SetParameterValue("CLAVE2", oMensaje.RecuperarDescripcion("XCLAVE"))
            oReporte.SetParameterValue("PRODUCTO2", oMensaje.RecuperarDescripcion("XPRODUCTO"))
            oReporte.SetParameterValue("UNIDAD2", oMensaje.RecuperarDescripcion("XUNIDAD"))
            oReporte.SetParameterValue("CANTIDAD2", oMensaje.RecuperarDescripcion("XCANTIDAD"))
            oReporte.SetParameterValue("GRANTOTAL", oMensaje.RecuperarDescripcion("XGRANTOTAL"))
            oReporte.SetParameterValue("TotalPorFolio", oMensaje.RecuperarDescripcion("XTotalPorFolio"))
            If Session("NumReporte") = 2 AndAlso Session("ConversionKg") = True Then
                oReporte.SetParameterValue("KGLTS2", oMensaje.RecuperarDescripcion("XKiloLitros"))
                oReporte.SetParameterValue("TotalKiloLitros", oMensaje.RecuperarDescripcion("XTotalKiloLitros"))
            End If

            If Session("NumReporte") = 21 Then 'Movimientos sin inventario en visita
                If Session("TipoReporte") = "Detallado" Then
                    oReporte.SetParameterValue("PROMOCION", oMensaje.RecuperarDescripcion("XPromocion"))
                End If

                oReporte.SetParameterValue("PROMOCION2", oMensaje.RecuperarDescripcion("XPromocion"))
                If Session("TipoReporte") = "General" Then
                    oReporte.SetParameterValue("TotalPorFolio", oMensaje.RecuperarDescripcion("XGRANTOTAL"))
                End If
            End If

            If Session("TipoReporte") = "Detallado" Then
                If Session("NumReporte") = 37 Then
                    oReporte.SetParameterValue("Fiscal", oMensaje.RecuperarDescripcion("XDomFiscal"))
                    oReporte.SetParameterValue("PuntoEntrega", oMensaje.RecuperarDescripcion("XDomPuntoEnt"))
                End If
                oReporte.SetParameterValue("PRODUCTO", oMensaje.RecuperarDescripcion("XPRODUCTO"))

                oReporte.SetParameterValue("UNIDAD", oMensaje.RecuperarDescripcion("XUNIDAD"))
                oReporte.SetParameterValue("PRECIO", oMensaje.RecuperarDescripcion("XP.U."))
                oReporte.SetParameterValue("CANT", oMensaje.RecuperarDescripcion("Xcantidad"))

                oReporte.SetParameterValue("SUBTOTAL", oMensaje.RecuperarDescripcion("XSUBTOTAL"))
                oReporte.SetParameterValue("DESCUENTOCLIENTE", oMensaje.RecuperarDescripcion("XDESC.CLIENTE"))
                oReporte.SetParameterValue("DESCUENTOVEND", oMensaje.RecuperarDescripcion("XDESC.VENDEDOR"))
                oReporte.SetParameterValue("DESCPRODUCTO", oMensaje.RecuperarDescripcion("XDESC.PRODUCTO"))

                oReporte.SetParameterValue("IMPUESTO", oMensaje.RecuperarDescripcion("XIMPUESTO"))

                oReporte.SetParameterValue("TotalPorRuta", oMensaje.RecuperarDescripcion("XTotalPorRuta"))
                oReporte.SetParameterValue("TOTALPRODUCTOS", oMensaje.RecuperarDescripcion("XTOTALPRODUCTOS"))
                If Session("NumReporte") = 2 AndAlso Session("ConversionKg") = True Then
                    oReporte.SetParameterValue("KGLTS", oMensaje.RecuperarDescripcion("XKiloLitros"))
                End If
            End If
            oReporte.SetParameterValue("TOTAL2", oMensaje.RecuperarDescripcion("XTOTALmin"))
            oReporte.SetParameterValue("FechaHoraImpresion", oMensaje.RecuperarDescripcion("Xfechahoraimpresion"))

            oReporte.SetParameterValue("CentroDistribucion", oMensaje.RecuperarDescripcion("XCentroDistribucion"))
            oReporte.SetParameterValue("TOTALCentroDistribucion", oMensaje.RecuperarDescripcion("XTOTALCentroDistribucion"))
            oReporte.SetParameterValue("GranTotalCentroDistribucion", oMensaje.RecuperarDescripcion("XGRANTOTALCentroDistribucion"))

            oReporte.SetParameterValue("Enviadovendedor", Session("Vendedor"))
            oReporte.SetParameterValue("Enviadaruta", Session("Ruta"))
            oReporte.SetParameterValue("Enviadafecha", Session("RangoFechas"))


            If Session("NumReporte") = 1 Then
                oReporte.SetParameterValue("VENTASPRODUCTO", oMensaje.RecuperarDescripcion("XVENTASPRODUCTO"))
            Else
                oReporte.SetParameterValue("VENTASPRODUCTO", oMensaje.RecuperarDescripcion("XPEDIDOSPRODUCTO"))
            End If

            If Session("TipoReporte") = "General" Then
                oReporte.SetParameterValue("FOLIO", oMensaje.RecuperarDescripcion("XFOLIO"))
                oReporte.SetParameterValue("CLIENTE", oMensaje.RecuperarDescripcion("XCLIENTE"))
                oReporte.SetParameterValue("CantPro", oMensaje.RecuperarDescripcion("XTOTALPRODUCTOS"))
            End If
            oReporte.SetParameterValue("TOTALFOLIOS", oMensaje.RecuperarDescripcion("XTOTALFOLIOS"))
            oReporte.SetParameterValue("TOTALVENDIDO", oMensaje.RecuperarDescripcion("XTOTALVENDIDO"))

        ElseIf Session("NumReporte") = 23 Then

            oReporte.FileName = Server.MapPath("Reports\ReporteEncuestas.rpt")

            oReporte.Database.Tables(0).SetDataSource(dt)
            oReporte.Database.Tables(1).SetDataSource(Session("DataTable"))
            If IsNothing(Session("subreport0")) Then
                Session("subreport0") = ins.EjecutarConsulta(Session("Query2"), IntCommandTimeOut)
            End If
            oReporte.Database.Tables(2).SetDataSource(Session("subreport0"))
            'oReporte.Database.Tables(2).SetDataSource(ins.EjecutarConsulta(Session("Query2"), IntCommandTimeOut))

            'oReporte.SetParameterValue("@pvLenguaje", lbGeneral.cParametros.Lenguaje)
            'oReporte.SetParameterValue("@pvClienteClave", pvClienteClave)
            oReporte.SetParameterValue("pvTitulo", oMensaje.RecuperarDescripcion("XREPORTEENCUESTAS"))
            oReporte.SetParameterValue("pvFechaHora", oMensaje.RecuperarDescripcion("Xfechahoraimpresion"))
            oReporte.SetParameterValue("pvEncuesta", oMensaje.RecuperarDescripcion("ENCCENClave"))
            oReporte.SetParameterValue("pvHoraInicio", oMensaje.RecuperarDescripcion("ENCHoraInicio"))
            oReporte.SetParameterValue("pvHoraFin", oMensaje.RecuperarDescripcion("ENCHoraFin"))
            oReporte.SetParameterValue("pvTipo", oMensaje.RecuperarDescripcion("CENTipo"))
            oReporte.SetParameterValue("pvFase", oMensaje.RecuperarDescripcion("ENCFase"))

            oReporte.SetParameterValue("pvOrdenAplicacion", oMensaje.RecuperarDescripcion("CEPOrden"))
            oReporte.SetParameterValue("pvNumeroPregunta", oMensaje.RecuperarDescripcion("CEPCEPNumero"))
            oReporte.SetParameterValue("pvTipoRespuesta", oMensaje.RecuperarDescripcion("XTipo"))
            oReporte.SetParameterValue("pvDescripcion", oMensaje.RecuperarDescripcion("XDescripcion"))
            oReporte.SetParameterValue("pvValor", oMensaje.RecuperarDescripcion("ERNValor"))
            oReporte.SetParameterValue("pvRespuesta", oMensaje.RecuperarDescripcion("XRespuesta"))
            oReporte.SetParameterValue("pvPreguntaAnterior", oMensaje.RecuperarDescripcion("XAnterior"))

            oReporte.SetParameterValue("pvTotalEncuestas", oMensaje.RecuperarDescripcion("XTotalEncuestas"))


            oReporte.SetParameterValue("cedi", oMensaje.RecuperarDescripcion("Xcentrodistribucion"))
            oReporte.SetParameterValue("vendedor", oMensaje.RecuperarDescripcion("xvendedor"))
            oReporte.SetParameterValue("ruta", oMensaje.RecuperarDescripcion("Xruta"))
            oReporte.SetParameterValue("cliente", oMensaje.RecuperarDescripcion("Xcliente"))
            oReporte.SetParameterValue("fecha", oMensaje.RecuperarDescripcion("Xfecha"))
            oReporte.SetParameterValue("totalcliente", oMensaje.RecuperarDescripcion("XClientesTotal"))
            oReporte.SetParameterValue("totalruta", oMensaje.RecuperarDescripcion("Xtotalruta"))
            oReporte.SetParameterValue("totalvendedor", oMensaje.RecuperarDescripcion("XTotalSolicitudesVendedor"))
            oReporte.SetParameterValue("totalfecha", Mayusculasoloprimerletra(oMensaje.RecuperarDescripcion("Xtotalfecha")))
            oReporte.SetParameterValue("totalcedi", oMensaje.RecuperarDescripcion("Xtotalcentrodistribucion"))

            oReporte.SetParameterValue("enviadaFecha", Session("RangoFechas"))
            oReporte.SetParameterValue("enviadoVendedor", Session("Vendedor"))
            oReporte.SetParameterValue("enviadocliente", Session("FiltroClientes"))
            ''oReporte.SetParameterValue("enviadocedi", Session("cedi"))
            oReporte.SetParameterValue("EnviadaRuta", Session("Ruta")) 'Session("FiltroRutas"))

        ElseIf Session("NumReporte") = 24 Then 'Ventas por vendedor
            If (Session("TipoReporte").ToString().ToUpper() = "DETALLADO") Then
                oReporte.FileName = Server.MapPath("Reports\ReporteVentaVendedor.rpt")
            Else
                oReporte.FileName = Server.MapPath("Reports\ReporteVentaVendedorG.rpt")
            End If

            oReporte.Database.Tables(0).SetDataSource(dt)
            If (Session("TipoReporte").ToString().ToUpper() = "DETALLADO") Then
                dt = CType(Session("DataTable"), System.Data.DataTable)
                oReporte.Database.Tables("Vendedores").SetDataSource(dt)
                dt = ins.EjecutarConsulta(Session("Query2"), IntCommandTimeOut)
                oReporte.Database.Tables("VentasVendedor").SetDataSource(dt)
                dt = ins.EjecutarConsulta(Session("Query3"), IntCommandTimeOut)
                oReporte.Database.Tables("Semanas").SetDataSource(dt)
            Else
                Dim dsVentas As Data.DataSet = Session("Ventas")
                'oReporte.Database.Tables("Vendedores").SetDataSource(dsVentas.Tables(0))
                oReporte.Database.Tables("VentasVendedor").SetDataSource(dsVentas.Tables(0))
                oReporte.Database.Tables("Semanas").SetDataSource(dsVentas.Tables(1))
                oReporte.Subreports("Productos").Database.Tables("Productos").SetDataSource(dsVentas.Tables(2))
            End If

            oReporte.SetParameterValue("@NombreReporte", Session("Nombre").ToString().ToUpper())
            oReporte.SetParameterValue("FiltroFecha", Session("RangoFechas"))
            oReporte.SetParameterValue("XCentroDistribucion", oMensaje.RecuperarDescripcion("XCentroDistribucion"))
            oReporte.SetParameterValue("XFecha", oMensaje.RecuperarDescripcion("XFECHA"))

            If (Session("TipoReporte").ToString().ToUpper() = "GENERAL") Then
                oReporte.SetParameterValue("XVenta", oMensaje.RecuperarDescripcion("XMLiquidacion"))
                oReporte.SetParameterValue("XVentaSemanal", oMensaje.RecuperarDescripcion("XLiquidacionSemanal"))
            Else
                oReporte.SetParameterValue("XVenta", oMensaje.RecuperarDescripcion("XVENTA"))
                oReporte.SetParameterValue("XVentaSemanal", oMensaje.RecuperarDescripcion("XVentaSemanal"))
            End If

            oReporte.SetParameterValue("XClave", oMensaje.RecuperarDescripcion("XClave"))
            oReporte.SetParameterValue("XRuta", oMensaje.RecuperarDescripcion("XRuta") + "")
            oReporte.SetParameterValue("XNombre", oMensaje.RecuperarDescripcion("XNombre"))
            oReporte.SetParameterValue("XSemana", oMensaje.RecuperarDescripcion("XSemana"))
            oReporte.SetParameterValue("XTotalFecha", oMensaje.RecuperarDescripcion("XTotalFecha"))
            oReporte.SetParameterValue("XTotalSemanal", oMensaje.RecuperarDescripcion("XTotalSemanal"))

            oReporte.SetParameterValue("TipoReporte", Session("TipoReporte").ToString())
            oReporte.SetParameterValue("FechaHoraImpresion", oMensaje.RecuperarDescripcion("XFechaHoraImpresion") + "")

            If (Session("TipoReporte").ToString().ToUpper() = "GENERAL") Then
                oReporte.SetParameterValue("XProducto1", oMensaje.RecuperarDescripcion("XProducto"))
                oReporte.SetParameterValue("XPiezas1", oMensaje.RecuperarDescripcion("XPiezas"))
                oReporte.SetParameterValue("XImporte1", oMensaje.RecuperarDescripcion("XImporte"))
                oReporte.SetParameterValue("XProducto", oMensaje.RecuperarDescripcion("XProducto"))
                oReporte.SetParameterValue("XPiezas", oMensaje.RecuperarDescripcion("XPiezas"))
                oReporte.SetParameterValue("XImporte", oMensaje.RecuperarDescripcion("XImporte"))
                oReporte.SetParameterValue("XTotalesProducto", oMensaje.RecuperarDescripcion("XTotalesProducto"))
            End If

        ElseIf Session("NumReporte") = 25 Then 'Reporte Efectividad Por Ruta (Lactigurth)
            If (Session("TipoReporte") = "Detallado") Then
                oReporte.FileName = Server.MapPath("Reports\ReporteEfectividadxRutaDetLactigurth.rpt")

                oReporte.Database.Tables("Configuracion").SetDataSource(dt)
                dt = Session("DataTable")
                oReporte.Database.Tables("ReporteEfectividadXRutaDet").SetDataSource(dt)
                'SUBREPORTES
                '*******************************************
                If IsNothing(Session("subreport0")) Then
                    Session("subreport0") = ins.EjecutarConsulta(Session("Tiempos"), IntCommandTimeOut)
                End If
                dt = Session("subreport0")
                'dt = ins.EjecutarConsulta(Session("Tiempos"), IntCommandTimeOut)
                oReporte.Subreports("Tiempos").Database.Tables(0).SetDataSource(dt)

                If IsNothing(Session("subreport1")) Then
                    Session("subreport1") = ins.EjecutarConsulta(Session("ClientesVisitadosConVenta"), IntCommandTimeOut)
                End If
                dt = Session("subreport1")
                'dt = ins.EjecutarConsulta(Session("ClientesVisitadosConVenta"), IntCommandTimeOut)
                oReporte.Subreports("ClientesVisitadosConVenta").Database.Tables("Clientes").SetDataSource(dt)

                If IsNothing(Session("subreport2")) Then
                    Session("subreport2") = ins.EjecutarConsulta(Session("TotalVisitados"), IntCommandTimeOut)
                End If
                dt = Session("subreport2")
                'dt = ins.EjecutarConsulta(Session("TotalVisitados"), IntCommandTimeOut)
                oReporte.Subreports("ClientesVisitadosConVenta").Database.Tables("TotalClientes").SetDataSource(dt)
                oReporte.Subreports("ClientesVisitadosSinVenta").Database.Tables("TotalClientes").SetDataSource(dt)
                oReporte.Subreports("CodigosLeidos").Database.Tables("TotalClientes").SetDataSource(dt)
                oReporte.Subreports("CodigosNoLeidos").Database.Tables("TotalClientes").SetDataSource(dt)

                oReporte.Subreports("ClientesVisitadosSinVenta").Database.Tables("Clientes").SetDataSource(ins.EjecutarConsulta(Session("ClientesVisitadosSinVenta"), IntCommandTimeOut))
                oReporte.Subreports("ClientesEncuestados").Database.Tables("Clientes").SetDataSource(ins.EjecutarConsulta(Session("ClientesEncuestados"), IntCommandTimeOut))

                If IsNothing(Session("subreport3")) Then
                    Session("subreport3") = ins.EjecutarConsulta(Session("TotalVisitadosAEncuestar"), IntCommandTimeOut)
                End If
                dt = Session("subreport3")
                'dt = ins.EjecutarConsulta(Session("TotalVisitadosAEncuestar"), IntCommandTimeOut)
                oReporte.Subreports("ClientesEncuestados").Database.Tables("TotalClientes").SetDataSource(dt)
                oReporte.Subreports("ClientesNoEncuestados").Database.Tables("TotalClientes").SetDataSource(dt)


                If IsNothing(Session("subreport8")) Then
                    Session("subreport8") = ins.EjecutarConsulta(Session("ImproductividadVenta"), IntCommandTimeOut)
                End If
                oReporte.Subreports("ImproductividadVenta").Database.Tables("ImproductividadVenta").SetDataSource(Session("subreport8"))
                'oReporte.Subreports("ImproductividadVenta").Database.Tables("ImproductividadVenta").SetDataSource(ins.EjecutarConsulta(Session("ImproductividadVenta"), IntCommandTimeOut))

                If IsNothing(Session("subreport9")) Then
                    Session("subreport9") = ins.EjecutarConsulta(Session("TotalVisitados"), IntCommandTimeOut)
                End If
                oReporte.Subreports("ImproductividadVenta").Database.Tables("TotalClientes").SetDataSource(Session("subreport9"))
                'oReporte.Subreports("ImproductividadVenta").Database.Tables("TotalClientes").SetDataSource(ins.EjecutarConsulta(Session("TotalVisitados")))

                If IsNothing(Session("subreport10")) Then
                    Session("subreport10") = ins.EjecutarConsulta(Session("ClientesNoEncuestados"), IntCommandTimeOut)
                End If
                oReporte.Subreports("ClientesNoEncuestados").Database.Tables("Clientes").SetDataSource(Session("subreport10"))
                'oReporte.Subreports("ClientesNoEncuestados").Database.Tables("Clientes").SetDataSource(ins.EjecutarConsulta(Session("ClientesNoEncuestados"), IntCommandTimeOut))

                If IsNothing(Session("subreport11")) Then
                    Session("subreport11") = ins.EjecutarConsulta(Session("CodigosLeidos"), IntCommandTimeOut)
                End If
                oReporte.Subreports("CodigosLeidos").Database.Tables("Clientes").SetDataSource(Session("subreport11"))
                'oReporte.Subreports("CodigosLeidos").Database.Tables("Clientes").SetDataSource(ins.EjecutarConsulta(Session("CodigosLeidos"), IntCommandTimeOut))

                If IsNothing(Session("subreport12")) Then
                    Session("subreport12") = ins.EjecutarConsulta(Session("CodigosNoLeidos"), IntCommandTimeOut)
                End If
                oReporte.Subreports("CodigosNoLeidos").Database.Tables("Clientes").SetDataSource(Session("subreport12"))
                'oReporte.Subreports("CodigosNoLeidos").Database.Tables("Clientes").SetDataSource(ins.EjecutarConsulta(Session("CodigosNoLeidos"), IntCommandTimeOut))

                If IsNothing(Session("subreport13")) Then
                    Session("subreport13") = ins.EjecutarConsulta(Session("ProductoNegado"), IntCommandTimeOut)
                End If
                oReporte.Subreports("ProductoNegado").Database.Tables(0).SetDataSource(Session("subreport13"))
                'oReporte.Subreports("ProductoNegado").Database.Tables(0).SetDataSource(ins.EjecutarConsulta(Session("ProductoNegado"), IntCommandTimeOut))

                If IsNothing(Session("subreport14")) Then
                    Session("subreport14") = ins.EjecutarConsulta(Session("ImproductividadProducto"), IntCommandTimeOut)
                End If
                oReporte.Subreports("ImproductividadProducto").Database.Tables(0).SetDataSource(Session("subreport14"))
                'oReporte.Subreports("ImproductividadProducto").Database.Tables(0).SetDataSource(ins.EjecutarConsulta(Session("ImproductividadProducto"), IntCommandTimeOut))

                If IsNothing(Session("subreport15")) Then
                    Session("subreport15") = ins.EjecutarConsulta(Session("MotivosImproductividad"), IntCommandTimeOut)
                End If
                oReporte.Subreports("MotivosImproductividad").Database.Tables(0).SetDataSource(Session("subreport15"))
                'oReporte.Subreports("MotivosImproductividad").Database.Tables(0).SetDataSource(ins.EjecutarConsulta(Session("MotivosImproductividad"), IntCommandTimeOut))

                If IsNothing(Session("subreport16")) Then
                    Session("subreport16") = ins.EjecutarConsulta(Session("ClientesProductoNegado"), IntCommandTimeOut)
                End If
                oReporte.Subreports("ClientesProductoNegado").Database.Tables(0).SetDataSource(Session("subreport16"))
                'oReporte.Subreports("ClientesProductoNegado").Database.Tables(0).SetDataSource(ins.EjecutarConsulta(Session("ClientesProductoNegado"), IntCommandTimeOut))

                If IsNothing(Session("subreport17")) Then
                    Session("subreport17") = ins.EjecutarConsulta(Session("ClientesImproductividadProducto"), IntCommandTimeOut)
                End If
                oReporte.Subreports("ClientesImproductividadProducto").Database.Tables(0).SetDataSource(Session("subreport17"))
                'oReporte.Subreports("ClientesImproductividadProducto").Database.Tables(0).SetDataSource(ins.EjecutarConsulta(Session("ClientesImproductividadProducto"), IntCommandTimeOut))

                If IsNothing(Session("subreport4")) Then
                    Session("subreport4") = ins.EjecutarConsulta(Session("TotalClientes"), IntCommandTimeOut)
                End If
                dt = Session("subreport4")
                'dt = ins.EjecutarConsulta(Session("TotalClientes"), IntCommandTimeOut)

                oReporte.Subreports("ClientesNoVisitados").Database.Tables("TotalClientes").SetDataSource(dt)
                oReporte.Subreports("ClientesVisitados").Database.Tables("TotalClientes").SetDataSource(dt)
                oReporte.Subreports("TotalClientes").Database.Tables("TotalClientes").SetDataSource(dt)

                If IsNothing(Session("subreport5")) Then
                    Session("subreport5") = ins.EjecutarConsulta(Session("TotalClientesVisitados"), IntCommandTimeOut)
                End If
                dt = Session("subreport5")
                'dt = ins.EjecutarConsulta(Session("TotalClientesVisitados"), IntCommandTimeOut)
                oReporte.Subreports("TotalClientes").Database.Tables("TotalClientesVisitados").SetDataSource(dt)

                If IsNothing(Session("subreport6")) Then
                    Session("subreport6") = ins.EjecutarConsulta(Session("ClientesVisitados"), IntCommandTimeOut)
                End If
                dt = Session("subreport6")
                'dt = ins.EjecutarConsulta(Session("ClientesVisitados"), IntCommandTimeOut)
                oReporte.Subreports("ClientesVisitados").Database.Tables("Clientes").SetDataSource(dt)

                If IsNothing(Session("subreport7")) Then
                    Session("subreport7") = ins.EjecutarConsulta(Session("ClientesNoVisitados"), IntCommandTimeOut)
                End If
                dt = Session("subreport7")
                'dt = ins.EjecutarConsulta(Session("ClientesNoVisitados"), IntCommandTimeOut)
                oReporte.Subreports("ClientesNoVisitados").Database.Tables("Clientes").SetDataSource(dt)

                '*******************************************

                oReporte.SetParameterValue("Producto", oMensaje.RecuperarDescripcion("XProducto"))
                oReporte.SetParameterValue("UnidadVenta", oMensaje.RecuperarDescripcion("XUnidadesVenta"))

                '////////////////////////////////////////////////////////////////

                oReporte.SetParameterValue("TituloCVSV", oMensaje.RecuperarDescripcion("XClientesVisitadosSinVenta").ToUpper)
                oReporte.SetParameterValue("TotalCVSV", oMensaje.RecuperarDescripcion("XTotalClientesVisitadosConVenta"))

                oReporte.SetParameterValue("TituloCVCV", oMensaje.RecuperarDescripcion("XClientesVisitadosConVenta").ToUpper)
                oReporte.SetParameterValue("TotalCVCV", oMensaje.RecuperarDescripcion("XTotalClientesVisitadosSinVenta"))

                oReporte.SetParameterValue("TituloIV", oMensaje.RecuperarDescripcion("XImproductividadVenta").ToUpper)
                oReporte.SetParameterValue("TotalIV", oMensaje.RecuperarDescripcion("XTotalImproductividadVenta"))

                oReporte.SetParameterValue("TituloCE", oMensaje.RecuperarDescripcion("XClientesEncuestados").ToUpper)
                oReporte.SetParameterValue("TotalCE", oMensaje.RecuperarDescripcion("XTotalClientesEncuestados"))

                oReporte.SetParameterValue("TituloCNE", oMensaje.RecuperarDescripcion("XClientesNoEncuestados").ToUpper)
                oReporte.SetParameterValue("TotalCNE", oMensaje.RecuperarDescripcion("XTotalClientesNoEncuestados"))

                oReporte.SetParameterValue("TituloCL", oMensaje.RecuperarDescripcion("XCodigoBarras").ToUpper)
                oReporte.SetParameterValue("TotalCL", oMensaje.RecuperarDescripcion("XTotalCodigoBarrasLeido"))

                oReporte.SetParameterValue("TituloCNL", oMensaje.RecuperarDescripcion("XCodigoBarrasNoLeido").ToUpper)
                oReporte.SetParameterValue("TotalCNL", oMensaje.RecuperarDescripcion("XTotalCodigoBarrasNoLeido"))

                oReporte.SetParameterValue("TituloPN", oMensaje.RecuperarDescripcion("XProductoNegado").ToUpper)
                oReporte.SetParameterValue("TotalPN", oMensaje.RecuperarDescripcion("XTotalProductoNegado"))

                oReporte.SetParameterValue("TituloIP", oMensaje.RecuperarDescripcion("XImproductividadProducto").ToUpper)
                oReporte.SetParameterValue("TotalIP", oMensaje.RecuperarDescripcion("XTotalImproductividadProducto"))

                oReporte.SetParameterValue("TituloMI", oMensaje.RecuperarDescripcion("XMotivosImproductividad").ToUpper)
                oReporte.SetParameterValue("TotalMI", oMensaje.RecuperarDescripcion("XTotalMotivosImproductividad"))

                oReporte.SetParameterValue("TituloCPN", oMensaje.RecuperarDescripcion("XClientesProductoNegado").ToUpper)
                oReporte.SetParameterValue("TotalProductosCPN", oMensaje.RecuperarDescripcion("XTotalProductoNegado"))
                oReporte.SetParameterValue("TotalClientesCPN", oMensaje.RecuperarDescripcion("XTotalClientesProductoNegado"))

                oReporte.SetParameterValue("TituloCIP", oMensaje.RecuperarDescripcion("XClientesImproductividadProducto").ToUpper)
                oReporte.SetParameterValue("TotalProductosCIP", oMensaje.RecuperarDescripcion("XTotalImproductividadProducto"))
                oReporte.SetParameterValue("TotalClientesCIP", oMensaje.RecuperarDescripcion("XTotalClientesImproductividadProd"))

                oReporte.SetParameterValue("TituloTC", oMensaje.RecuperarDescripcion("XResumenDeClientes", New String() {Session("FechaInicial"), Session("FechaFinal")}).ToUpper)
                oReporte.SetParameterValue("ClientesVisitados", oMensaje.RecuperarDescripcion("MDB0126").ToUpper)
                oReporte.SetParameterValue("ClientesNoVisitados", oMensaje.RecuperarDescripcion("XClientesNoVisitados").ToUpper)
                oReporte.SetParameterValue("TotalClientes", oMensaje.RecuperarDescripcion("XTotalClientes").ToUpper)

                oReporte.SetParameterValue("TituloCV", oMensaje.RecuperarDescripcion("MDB0126").ToUpper())
                oReporte.SetParameterValue("TotalCV", oMensaje.RecuperarDescripcion("XTotalClientesVisitados"))

                oReporte.SetParameterValue("TituloCNV", oMensaje.RecuperarDescripcion("XClientesNoVisitados").ToUpper)
                oReporte.SetParameterValue("TotalCNV", oMensaje.RecuperarDescripcion("XTotalClientesNoVisitados"))

                '////////////////////////////////////////////////////////////////
            Else
                oReporte.FileName = Server.MapPath("Reports\ReporteEfectividadxRutaLactigurth.rpt")
                oReporte.Database.Tables("Configuracion").SetDataSource(dt)
                dt = Session("DataTable")
                oReporte.Database.Tables("ReporteEfectividadXRuta").SetDataSource(dt)
                'SUBREPORTES
                '*******************************************
                If IsNothing(Session("subreport0")) Then
                    Session("subreport0") = ins.EjecutarConsulta(Session("Tiempos"), IntCommandTimeOut)
                End If
                oReporte.Subreports("Tiempos").Database.Tables(0).SetDataSource(Session("subreport0"))
                'oReporte.Subreports("Tiempos").Database.Tables(0).SetDataSource(ins.EjecutarConsulta(Session("Tiempos"), IntCommandTimeOut))

                If IsNothing(Session("subreport1")) Then
                    Session("subreport1") = ins.EjecutarConsulta(Session("ClientesVisitadosConVenta"), IntCommandTimeOut)
                End If
                oReporte.Subreports("ClientesVentaNoVenta").Database.Tables("ClientesVisVenta").SetDataSource(Session("subreport1"))
                'oReporte.Subreports("ClientesVentaNoVenta").Database.Tables("ClientesVisVenta").SetDataSource(ins.EjecutarConsulta(Session("ClientesVisitadosConVenta"), IntCommandTimeOut))

                If IsNothing(Session("subreport2")) Then
                    Session("subreport2") = ins.EjecutarConsulta(Session("ImproductividadVenta"), IntCommandTimeOut)
                End If
                oReporte.Subreports("ImproductividadVenta").Database.Tables("ClientesImproductividad").SetDataSource(Session("subreport2"))
                'oReporte.Subreports("ImproductividadVenta").Database.Tables("ClientesImproductividad").SetDataSource(ins.EjecutarConsulta(Session("ImproductividadVenta"), IntCommandTimeOut))

                'oReporte.Subreports("Encuestas").Database.Tables("EncuestasAplicadas").SetDataSource(ins.EjecutarConsulta(Session("EncuestasAplicadas")))

                If IsNothing(Session("subreport3")) Then
                    Session("subreport3") = ins.EjecutarConsulta(Session("ClientesEncuestados"), IntCommandTimeOut)
                End If
                oReporte.Subreports("ClientesEncuestados").Database.Tables("ClientesEncuestados").SetDataSource(Session("subreport3"))
                '                oReporte.Subreports("ClientesEncuestados").Database.Tables("ClientesEncuestados").SetDataSource(ins.EjecutarConsulta(Session("ClientesEncuestados"), IntCommandTimeOut))

                If IsNothing(Session("subreport4")) Then
                    Session("subreport4") = ins.EjecutarConsulta(Session("CodigosLeidos"), IntCommandTimeOut)
                End If
                oReporte.Subreports("CodigoBarras").Database.Tables("CodigosLeidos").SetDataSource(Session("subreport4"))
                'oReporte.Subreports("CodigoBarras").Database.Tables("CodigosLeidos").SetDataSource(ins.EjecutarConsulta(Session("CodigosLeidos"), IntCommandTimeOut))

                If IsNothing(Session("subreport5")) Then
                    Session("subreport5") = ins.EjecutarConsulta(Session("ProductoNegado"), IntCommandTimeOut)
                End If
                oReporte.Subreports("ProductoNegado").Database.Tables("ProductoNegadoGral").SetDataSource(Session("subreport5"))
                'oReporte.Subreports("ProductoNegado").Database.Tables("ProductoNegadoGral").SetDataSource(ins.EjecutarConsulta(Session("ProductoNegado"), IntCommandTimeOut))

                If IsNothing(Session("subreport6")) Then
                    Session("subreport6") = ins.EjecutarConsulta(Session("ClientesProductoNegado"), IntCommandTimeOut)
                End If
                oReporte.Subreports("ClientesProductoNegado").Database.Tables("ProductoNegadoGral").SetDataSource(Session("subreport6"))
                'oReporte.Subreports("ClientesProductoNegado").Database.Tables("ProductoNegadoGral").SetDataSource(ins.EjecutarConsulta(Session("ClientesProductoNegado"), IntCommandTimeOut))

                If IsNothing(Session("subreport7")) Then
                    Session("subreport7") = ins.EjecutarConsulta(Session("TotalClientes"), IntCommandTimeOut)
                End If
                oReporte.Subreports("TotalClientes").Database.Tables("ClientesVisNoVis").SetDataSource(Session("subreport7"))
                'oReporte.Subreports("TotalClientes").Database.Tables("ClientesVisNoVis").SetDataSource(ins.EjecutarConsulta(Session("TotalClientes"), IntCommandTimeOut))

                If IsNothing(Session("subreport8")) Then
                    Session("subreport8") = ins.EjecutarConsulta(Session("ClientesVisitados"), IntCommandTimeOut)
                End If
                oReporte.Subreports("ClientesVisNoVis").Database.Tables("ClientesVisNoVis").SetDataSource(Session("subreport8"))
                'oReporte.Subreports("ClientesVisNoVis").Database.Tables("ClientesVisNoVis").SetDataSource(ins.EjecutarConsulta(Session("ClientesVisitados"), IntCommandTimeOut))


                oReporte.SetParameterValue("ClientesVisitadosConVenta", oMensaje.RecuperarDescripcion("XClientesVisitadosConVenta").ToUpper)
                oReporte.SetParameterValue("ClientesVisitadosSinVenta", oMensaje.RecuperarDescripcion("XClientesVisitadosSinVenta").ToUpper)
                oReporte.SetParameterValue("TotalClientesVisitados", oMensaje.RecuperarDescripcion("XTotalClientesVisitados").ToUpper)

                oReporte.SetParameterValue("ImproductividadVenta", oMensaje.RecuperarDescripcion("XImproductividadVenta").ToUpper)

                'oReporte.SetParameterValue("EncuestasAplicadas", oMensaje.RecuperarDescripcion("XEncuestasAplicadas").ToUpper)
                'oReporte.SetParameterValue("EncuestasNoAplicadas", oMensaje.RecuperarDescripcion("XEncuestasNoAplicadas").ToUpper)
                'oReporte.SetParameterValue("TotalEncuestas", oMensaje.RecuperarDescripcion("XTotalEncuestas").ToUpper)

                oReporte.SetParameterValue("ClientesEncuestados", oMensaje.RecuperarDescripcion("XClientesEncuestados").ToUpper)
                oReporte.SetParameterValue("ClientesNoEncuestados", oMensaje.RecuperarDescripcion("XClientesNoEncuestados").ToUpper)
                oReporte.SetParameterValue("TotalClientesEncuestados", oMensaje.RecuperarDescripcion("XTotalClientesEncuestados").ToUpper)

                oReporte.SetParameterValue("CodigoBarrasLeidos", oMensaje.RecuperarDescripcion("XCodigoBarras").ToUpper)
                oReporte.SetParameterValue("CodigoBarrasNoLeidos", oMensaje.RecuperarDescripcion("XCodigoBarrasNoLeido").ToUpper)
                oReporte.SetParameterValue("TotalClientesCodigoBarras", oMensaje.RecuperarDescripcion("XTotalClientes").ToUpper)

                oReporte.SetParameterValue("ProductoNegado", oMensaje.RecuperarDescripcion("XProductoNegado").ToUpper)
                oReporte.SetParameterValue("ImproductividadProducto", oMensaje.RecuperarDescripcion("XImproductividadProducto").ToUpper)
                oReporte.SetParameterValue("TotalProductoNoVendido", oMensaje.RecuperarDescripcion("XTotalProductoNoVendido").ToUpper)

                oReporte.SetParameterValue("ClientesProductoNegado", oMensaje.RecuperarDescripcion("XClientesProductoNegado").ToUpper)
                oReporte.SetParameterValue("ClientesImproductividadProducto", oMensaje.RecuperarDescripcion("XClientesImproductividadProducto").ToUpper)
                oReporte.SetParameterValue("TotalProductosImproductividad", oMensaje.RecuperarDescripcion("XTotalProductosImproductividad").ToUpper)

                oReporte.SetParameterValue("TituloRC", oMensaje.RecuperarDescripcion("XResumenDeClientes", New String() {Session("FechaInicial"), Session("FechaFinal")}).ToUpper)
                oReporte.SetParameterValue("ClientesVisitadosPeriodo", oMensaje.RecuperarDescripcion("XClientesVisitadosPeriodo").ToUpper)
                oReporte.SetParameterValue("ClientesNoVisitadosPeriodo", oMensaje.RecuperarDescripcion("XClientesNoVisitadosPeriodo").ToUpper)
                oReporte.SetParameterValue("TotalClientesPeriodo", oMensaje.RecuperarDescripcion("XTotalClientesPeriodo").ToUpper)

                oReporte.SetParameterValue("ClientesVisitados", oMensaje.RecuperarDescripcion("MDB0126").ToUpper)
                oReporte.SetParameterValue("ClientesNoVisitados", oMensaje.RecuperarDescripcion("XClientesNoVisitados").ToUpper)
                oReporte.SetParameterValue("TotalClientes", oMensaje.RecuperarDescripcion("XTotalClientes").ToUpper)

            End If

            oReporte.SetParameterValue("CentroDistribucion", oMensaje.RecuperarDescripcion("XCentroDistribucion"))
            oReporte.SetParameterValue("Fecha", oMensaje.RecuperarDescripcion("XFecha"))
            oReporte.SetParameterValue("NombreRep", Session("Nombre").ToString().ToUpper())
            oReporte.SetParameterValue("Vendedor", oMensaje.RecuperarDescripcion("XVendedor"))
            oReporte.SetParameterValue("Ruta", oMensaje.RecuperarDescripcion("Xruta"))
            oReporte.SetParameterValue("Cantidad", oMensaje.RecuperarDescripcion("XCantidad"))
            oReporte.SetParameterValue("Porcentaje", oMensaje.RecuperarDescripcion("XPorcentaje"))

            oReporte.SetParameterValue("EnviadoCEDI", Session("CEDI"))
            oReporte.SetParameterValue("Enviadovendedor", Session("Vendedor"))
            oReporte.SetParameterValue("Enviadaruta", Session("Ruta"))
            oReporte.SetParameterValue("Enviadafecha", Session("RangoFechas"))

            oReporte.SetParameterValue("FechaHoraImpresion", oMensaje.RecuperarDescripcion("Xfechahoraimpresion"))

            oReporte.SetParameterValue("TiempoRecorrido", oMensaje.RecuperarDescripcion("XTiempoRecorrido"))
            oReporte.SetParameterValue("TiempoVisita", oMensaje.RecuperarDescripcion("XTiempoVisita"))
            oReporte.SetParameterValue("TiempoTransito", oMensaje.RecuperarDescripcion("XTiempoTransito"))

        ElseIf Session("NumReporte") = 26 Then 'Liquidacion Lactigurth

            oReporte.FileName = Server.MapPath("Reports\ReporteLiquidacionLactigurth.rpt")

            oReporte.Database.Tables(0).SetDataSource(dt)
            If IsNothing(Session("subreport0")) Then
                Session("subreport0") = ins.EjecutarConsulta(Session("VentasProductos"), IntCommandTimeOut)
            End If
            oReporte.Subreports("VentasProductos").Database.Tables("VentasProductos").SetDataSource(Session("subreport0"))
            'oReporte.Subreports("VentasProductos").Database.Tables("VentasProductos").SetDataSource(ins.EjecutarConsulta(Session("VentasProductos"), IntCommandTimeOut))

            If IsNothing(Session("subreport1")) Then
                Session("subreport1") = ins.EjecutarConsulta(Session("CobranzaCheques"), IntCommandTimeOut)
            End If
            oReporte.Subreports("CobranzaCheques").Database.Tables("CobranzaCheques").SetDataSource(Session("subreport1"))
            'oReporte.Subreports("CobranzaCheques").Database.Tables("CobranzaCheques").SetDataSource(ins.EjecutarConsulta(Session("CobranzaCheques"), IntCommandTimeOut))

            If IsNothing(Session("subreport2")) Then
                Session("subreport2") = ins.EjecutarConsulta(Session("Gastos"), IntCommandTimeOut)
            End If
            oReporte.Subreports("Gastos").Database.Tables("Gastos").SetDataSource(Session("subreport2"))
            'oReporte.Subreports("Gastos").Database.Tables("Gastos").SetDataSource(ins.EjecutarConsulta(Session("Gastos"), IntCommandTimeOut))

            If IsNothing(Session("subreport3")) Then
                Session("subreport3") = ins.EjecutarConsulta(Session("Creditos"), IntCommandTimeOut)
            End If
            oReporte.Subreports("Creditos").Database.Tables("Creditos").SetDataSource(Session("subreport3"))
            'oReporte.Subreports("Creditos").Database.Tables("Creditos").SetDataSource(ins.EjecutarConsulta(Session("Creditos"), IntCommandTimeOut))

            If IsNothing(Session("subreport4")) Then
                Session("subreport4") = ins.EjecutarConsulta(Session("CobranzaAnteriores"), IntCommandTimeOut)
            End If
            oReporte.Subreports("CobranzaAnteriores").Database.Tables("CobranzaAnteriores").SetDataSource(Session("subreport4"))
            'oReporte.Subreports("CobranzaAnteriores").Database.Tables("CobranzaAnteriores").SetDataSource(ins.EjecutarConsulta(Session("CobranzaAnteriores"), IntCommandTimeOut))


            oReporte.SetParameterValue("NombreRep", Session("Nombre").ToString().ToUpper())

            oReporte.SetParameterValue("Fecha", oMensaje.RecuperarDescripcion("XFECHA"))
            oReporte.SetParameterValue("enviadoFecha", Session("RangoFechas"))
            oReporte.SetParameterValue("VENDEDOR", oMensaje.RecuperarDescripcion("XVendedor"))
            oReporte.SetParameterValue("enviadoVendedor", Session("Vendedor"))

            'Seccion Ventas de Productos
            oReporte.SetParameterValue("VentasProductos", oMensaje.RecuperarDescripcion("XVentasProducto").ToUpper)
            oReporte.SetParameterValue("VentasProductoClave", oMensaje.RecuperarDescripcion("XClave"))
            oReporte.SetParameterValue("VentasDescripcion", oMensaje.RecuperarDescripcion("XDescripcion"))
            oReporte.SetParameterValue("VentasCargas", oMensaje.RecuperarDescripcion("MDBCargas"))
            oReporte.SetParameterValue("VentasAjustes", oMensaje.RecuperarDescripcion("MDBAjustes"))
            oReporte.SetParameterValue("VentasDevoluciones", oMensaje.RecuperarDescripcion("XDevoluciones"))
            oReporte.SetParameterValue("VentasAlmacen", oMensaje.RecuperarDescripcion("CAlmacen"))
            oReporte.SetParameterValue("VentasDescargas", oMensaje.RecuperarDescripcion("XDescargas"))
            oReporte.SetParameterValue("Ventas", oMensaje.RecuperarDescripcion("XVentas"))
            oReporte.SetParameterValue("Promociones", oMensaje.RecuperarDescripcion("XPromociones"))
            oReporte.SetParameterValue("VentasPrecio", oMensaje.RecuperarDescripcion("XPrecio"))
            oReporte.SetParameterValue("VentasImporte", oMensaje.RecuperarDescripcion("XImporte"))
            oReporte.SetParameterValue("TotalVentasProductos", oMensaje.RecuperarDescripcion("XTotalVentasProductos"))
            oReporte.SetParameterValue("TotalSinDescuento", oMensaje.RecuperarDescripcion("XTotalSinDescuento"))
            oReporte.SetParameterValue("TotalConDescuento", oMensaje.RecuperarDescripcion("XTotalConDescuento"))
            oReporte.SetParameterValue("TotalDescuentosOtorgados", oMensaje.RecuperarDescripcion("XTotalDescuentosOtorgados"))

            'Seccion CobranzaCheques
            oReporte.SetParameterValue("CobranzaCheques", oMensaje.RecuperarDescripcion("XCobranzaCheques").ToUpper)
            oReporte.SetParameterValue("ChequesFactura", oMensaje.RecuperarDescripcion("TRPFacturaID"))
            oReporte.SetParameterValue("ChequesFolio", oMensaje.RecuperarDescripcion("XVenta"))
            oReporte.SetParameterValue("ChequesBanco", oMensaje.RecuperarDescripcion("DEPTipoBanco"))
            oReporte.SetParameterValue("ChequesReferencia", oMensaje.RecuperarDescripcion("XNoCheque"))
            oReporte.SetParameterValue("ChequesFechaAbono", oMensaje.RecuperarDescripcion("DEPFechaDeposito"))
            oReporte.SetParameterValue("ChequesImporte", oMensaje.RecuperarDescripcion("DEPImporte"))
            oReporte.SetParameterValue("TotalCobranzaCheques", oMensaje.RecuperarDescripcion("XTotalCobranzaCheques"))
            oReporte.SetParameterValue("TotalLiquidacionCheques", oMensaje.RecuperarDescripcion("XTotalLiquidacionCheques"))

            'Seccion Gastos
            oReporte.SetParameterValue("GastosEfectuados", oMensaje.RecuperarDescripcion("XGastosEfectuados").ToUpper)
            oReporte.SetParameterValue("GastosFolio", oMensaje.RecuperarDescripcion("GASFolio"))
            oReporte.SetParameterValue("GastosConcepto", oMensaje.RecuperarDescripcion("GASConcepto"))
            oReporte.SetParameterValue("GastosSubtotal", oMensaje.RecuperarDescripcion("XSubtotal"))
            oReporte.SetParameterValue("GastosImpuesto", oMensaje.RecuperarDescripcion("GASImpuesto"))
            oReporte.SetParameterValue("GastosPorcentaje", "%")
            oReporte.SetParameterValue("GastosImporte", oMensaje.RecuperarDescripcion("GASImporte"))
            oReporte.SetParameterValue("TotalGastosEfectuados", oMensaje.RecuperarDescripcion("XTotalGastosEfectuados"))
            oReporte.SetParameterValue("TotalLiquidacionGastos", oMensaje.RecuperarDescripcion("XTotalLiquidacionGastos"))

            'Seccion Créditos Otorgados
            oReporte.SetParameterValue("CreditosOtorgados", oMensaje.RecuperarDescripcion("XCreditosOtorgados").ToUpper)
            oReporte.SetParameterValue("CreditosFactura", oMensaje.RecuperarDescripcion("TRPFacturaID"))
            oReporte.SetParameterValue("CreditosFolio", oMensaje.RecuperarDescripcion("XVenta"))
            oReporte.SetParameterValue("CreditosFecha", oMensaje.RecuperarDescripcion("XFecha"))
            oReporte.SetParameterValue("CreditosCliente", oMensaje.RecuperarDescripcion("XCliente"))
            oReporte.SetParameterValue("CreditosImporte", oMensaje.RecuperarDescripcion("XImporte"))
            oReporte.SetParameterValue("TotalCreditosNormales", oMensaje.RecuperarDescripcion("XTotalCreditosNormales"))
            oReporte.SetParameterValue("TotalCreditosAutoservicios", oMensaje.RecuperarDescripcion("XTotalCreditosAutoservicios"))
            oReporte.SetParameterValue("TotalCreditosOtorgados", oMensaje.RecuperarDescripcion("XTotalCreditosOtorgados"))
            oReporte.SetParameterValue("TotalLiquidacionCreditos", oMensaje.RecuperarDescripcion("XTotalLiquidacionCreditos"))

            'Sección Cobranza Ventas Anteriores
            oReporte.SetParameterValue("CobranzaAnterior", oMensaje.RecuperarDescripcion("XCobranzaVentasAnteriores").ToUpper)
            oReporte.SetParameterValue("CobranzaFactura", oMensaje.RecuperarDescripcion("TRPFacturaID"))
            oReporte.SetParameterValue("CobAntFolio", oMensaje.RecuperarDescripcion("XVenta"))
            oReporte.SetParameterValue("CobAntFecha", oMensaje.RecuperarDescripcion("XFecha"))
            oReporte.SetParameterValue("CobAntTRPTotal", oMensaje.RecuperarDescripcion("XTotalVenta"))
            oReporte.SetParameterValue("CobAntSaldoActual", oMensaje.RecuperarDescripcion("XSaldoActual"))
            oReporte.SetParameterValue("CobAntTipoPago", oMensaje.RecuperarDescripcion("ABDTipoPago"))
            oReporte.SetParameterValue("CobAntReferencia", oMensaje.RecuperarDescripcion("XDocumentoPago"))
            oReporte.SetParameterValue("CobAntImporte", oMensaje.RecuperarDescripcion("XImporte"))
            oReporte.SetParameterValue("TotalCobranzaVentasAnteriores", oMensaje.RecuperarDescripcion("XTotalCobranzaVentasAnteriores"))
            oReporte.SetParameterValue("TotalLiquidacionCobranzaAnterior", oMensaje.RecuperarDescripcion("XTotalLiquidacionCobranzaAnterior"))

            'Seccion Devolución, Degustación y Cheques Devueltos
            oReporte.SetParameterValue("DevolucionDegustacionChequesDevueltos", oMensaje.RecuperarDescripcion("XDevolucionDegustacionChequesDev").ToUpper)
            'DevolucionMala
            oReporte.SetParameterValue("TotalDevolucionMala", ins.EjecutarComandoScalar(Session("DevolucionMala")))
            oReporte.SetParameterValue("MsgDevolucionMala", oMensaje.RecuperarDescripcion("XDevolucionMala"))
            'Degustación
            oReporte.SetParameterValue("TotalDegustacion", CType(Session("Degustacion"), Double))
            oReporte.SetParameterValue("MsgDegustacion", oMensaje.RecuperarDescripcion("XDegustacion"))
            'Cheques Devueltos
            oReporte.SetParameterValue("TotalChequesDevueltos", CType(Session("ChequesDevueltos"), Double))
            oReporte.SetParameterValue("MsgChequesDevueltos", oMensaje.RecuperarDescripcion("XChequesDevueltos"))
            oReporte.SetParameterValue("MsgTotalDevolucionDegustacionCheques", oMensaje.RecuperarDescripcion("XTotalDevolucionDegustacionCheques"))

            'TotalEfectivo
            oReporte.SetParameterValue("TotalEfectivo", ins.EjecutarComandoScalar(Session("TotalEfectivo")))
            oReporte.SetParameterValue("MsgTotalEfectivo", oMensaje.RecuperarDescripcion("XTotalEfectivo"))
            oReporte.SetParameterValue("TotalGastosEfectuados1", oMensaje.RecuperarDescripcion("XTotalGastosEfectuados"))
            oReporte.SetParameterValue("TotalEfectivoTotalGastosEfectuados", oMensaje.RecuperarDescripcion("XTotalEfectivoTotalGastosEfectuados"))

            'Calculo de Comisión
            'oReporte.SetParameterValue("TotalCalculoComision", ins.EjecutarComandoScalar(Session("TotalCalculoComision")))
            oReporte.SetParameterValue("MsgTotalCalculoComision", oMensaje.RecuperarDescripcion("XTotalCalculoComision"))
            oReporte.SetParameterValue("TotalPorcentajeComision", Session("PorcentajeComision"))
            oReporte.SetParameterValue("MsgPorcentajeComision", oMensaje.RecuperarDescripcion("XComision"))
            oReporte.SetParameterValue("MsgComision", oMensaje.RecuperarDescripcion("XComision").Replace("%", "").Trim)

            'Firmas
            oReporte.SetParameterValue("MsgLactigurt", oMensaje.RecuperarDescripcion("XLactigurt"))

        ElseIf Session("NumReporte") = 27 Then '--Devoluciones y Cambios por Vendedor

            oReporte.FileName = Server.MapPath("Reports\ReporteDevolucionesCambiosVendedor.rpt")

            oReporte.Database.Tables(1).SetDataSource(dt)
            dt = CType(Session("DataTable"), System.Data.DataTable)

            'dt = ins.EjecutarConsulta(Session("Query"))
            oReporte.Database.Tables(0).SetDataSource(dt)
            oReporte.Subreports("SubDetalleCliente").Database.Tables(0).SetDataSource(dt)

            'Parámetros
            oReporte.SetParameterValue("@NombreReporte", Session("Nombre").ToString().ToUpper()) '''''''''''''****<----Nombre por filtros)
            oReporte.SetParameterValue("@ProductoClave", oMensaje.RecuperarDescripcion("XClave"))
            oReporte.SetParameterValue("@ProductoNombre", oMensaje.RecuperarDescripcion("XProducto"))
            oReporte.SetParameterValue("@Unidad", oMensaje.RecuperarDescripcion("XUnidad"))
            oReporte.SetParameterValue("@Precio", oMensaje.RecuperarDescripcion("XPrecio"))
            oReporte.SetParameterValue("@Devolucion", oMensaje.RecuperarDescripcion("XDevolucion"))
            oReporte.SetParameterValue("@Cambio", oMensaje.RecuperarDescripcion("XCambio"))
            oReporte.SetParameterValue("@CambioPor", oMensaje.RecuperarDescripcion("XCambioPor"))
            oReporte.SetParameterValue("@Cantidad", oMensaje.RecuperarDescripcion("XCantidad"))
            oReporte.SetParameterValue("@Importe", oMensaje.RecuperarDescripcion("X$"))
            oReporte.SetParameterValue("@Total", oMensaje.RecuperarDescripcion("XTotal").ToUpper)
            oReporte.SetParameterValue("@Fecha", oMensaje.RecuperarDescripcion("XFecha") & "")
            oReporte.SetParameterValue("@RangoFechas", Session("RangoFechas"))
            oReporte.SetParameterValue("xUnidades", oMensaje.RecuperarDescripcion("XUnidades"))
            oReporte.SetParameterValue("@VendedorFil", oMensaje.RecuperarDescripcion("XVendedor"))
            oReporte.SetParameterValue("Vendedor", Session("Vendedor"))
            oReporte.SetParameterValue("CentroDistribucion", oMensaje.RecuperarDescripcion("XCentroDistribucion"))
            oReporte.SetParameterValue("FechaHoraImpresion", oMensaje.RecuperarDescripcion("Xfechahoraimpresion"))
            oReporte.SetParameterValue("EnviadoCEDI", Session("CEDI"))


            oReporte.SetParameterValue("@ProductoClave", oMensaje.RecuperarDescripcion("XClave"), "SubDetalleCliente")
            oReporte.SetParameterValue("@ProductoNombre", oMensaje.RecuperarDescripcion("XProducto"), "SubDetalleCliente")
            oReporte.SetParameterValue("@Unidad", oMensaje.RecuperarDescripcion("XUnidad"), "SubDetalleCliente")
            oReporte.SetParameterValue("@Devolucion", oMensaje.RecuperarDescripcion("XDevolucion"), "SubDetalleCliente")
            oReporte.SetParameterValue("@Cambio", oMensaje.RecuperarDescripcion("XCambio"), "SubDetalleCliente")
            oReporte.SetParameterValue("@CambioPor", oMensaje.RecuperarDescripcion("XCambioPor"), "SubDetalleCliente")
            oReporte.SetParameterValue("@Cantidad", oMensaje.RecuperarDescripcion("XCantidad"), "SubDetalleCliente")
            oReporte.SetParameterValue("@Importe", oMensaje.RecuperarDescripcion("X$"), "SubDetalleCliente")
            oReporte.SetParameterValue("@Total", oMensaje.RecuperarDescripcion("XTotal").ToUpper, "SubDetalleCliente")
            oReporte.SetParameterValue("xUnidades", oMensaje.RecuperarDescripcion("XUnidades"), "SubDetalleCliente")
        ElseIf Session("NumReporte") = 28 Then '-- Suma por Ruta
            oReporte.FileName = Server.MapPath("Reports\ReporteSumaxRuta.rpt")

            oReporte.Subreports("Logo").Database.Tables("Configuracion").SetDataSource(dt)
            dt = CType(Session("DataTable"), System.Data.DataTable)
            oReporte.Database.Tables("SumaxRutaH").SetDataSource(dt)
            dt = CType(Session("DataTable1"), System.Data.DataTable)
            oReporte.Database.Tables("SumaxRutaD").SetDataSource(dt)

            'Parámetros
            oReporte.SetParameterValue("CentroDistribucion", oMensaje.RecuperarDescripcion("XCentroDistribucion"))
            oReporte.SetParameterValue("Fecha", oMensaje.RecuperarDescripcion("XFecha") + "")
            oReporte.SetParameterValue("EnviadoCEDI", Session("CEDI"))
            oReporte.SetParameterValue("Enviadafecha", Session("RangoFechas"))
            oReporte.SetParameterValue("NombreReporte", Session("Nombre").ToString().ToUpper()) '''''''''''''****<----Nombre por filtros)

            oReporte.SetParameterValue("NumRuta", oMensaje.RecuperarDescripcion("XNumRuta"))
            oReporte.SetParameterValue("ClientesAVisitar", oMensaje.RecuperarDescripcion("XClientesAVisitar"))
            oReporte.SetParameterValue("ClientesVisitados", oMensaje.RecuperarDescripcion("XClientesVisitados"))
            oReporte.SetParameterValue("XClientesFamProd", oMensaje.RecuperarDescripcion("XClientesFamProd"))
            oReporte.SetParameterValue("XKiloLitros", oMensaje.RecuperarDescripcion("XKiloLitros"))
            oReporte.SetParameterValue("XImporte", oMensaje.RecuperarDescripcion("XImporte"))
            oReporte.SetParameterValue("XClientesNoCompra", oMensaje.RecuperarDescripcion("XClientesNoCompra"))
            oReporte.SetParameterValue("XMotivoNoCompra", oMensaje.RecuperarDescripcion("XMotivoNoCompra"))
            oReporte.SetParameterValue("XTiempoVisita", oMensaje.RecuperarDescripcion("XTiempoVisita"))
            oReporte.SetParameterValue("XTiempoRecorrido", oMensaje.RecuperarDescripcion("XTiempoRecorrido"))
            oReporte.SetParameterValue("XTotalFecha", oMensaje.RecuperarDescripcion("XTotalFecha"))

            oReporte.SetParameterValue("MotsNoCompra", Session("DataTable2").ToString())
            oReporte.SetParameterValue("XFechaHoraImpresion", oMensaje.RecuperarDescripcion("XFechaHoraImpresion"))
        ElseIf Session("NumReporte") = 29 Then '--Agrupado Por Familia
            oReporte.FileName = Server.MapPath("Reports\ReporteAgrupadoPorFamilia.rpt")

            oReporte.Database.Tables(1).SetDataSource(Session("DataTable"))
            oReporte.Database.Tables(0).SetDataSource(dt)
            oReporte.SetParameterValue("Nombre", Session("Nombre").ToString().ToUpper()) '''''''''''''****<----Nombre por filtros

            oReporte.SetParameterValue("CentroDistribucion", oMensaje.RecuperarDescripcion("XCentroDistribucion"))
            oReporte.SetParameterValue("Fecha", oMensaje.RecuperarDescripcion("XFecha") + "")
            oReporte.SetParameterValue("Ruta", oMensaje.RecuperarDescripcion("Xruta"))

            oReporte.SetParameterValue("Cliente", oMensaje.RecuperarDescripcion("XCliente"))
            oReporte.SetParameterValue("Familia", oMensaje.RecuperarDescripcion("XFamilia"))
            oReporte.SetParameterValue("Cant", oMensaje.RecuperarDescripcion("XCantidad"))
            oReporte.SetParameterValue("TotalFamilia", oMensaje.RecuperarDescripcion("XTotalPorFamiliaPorRuta"))

            oReporte.SetParameterValue("EnviadoCEDI", Session("CEDI"))
            oReporte.SetParameterValue("Enviadaruta", Session("Ruta"))
            oReporte.SetParameterValue("Enviadafecha", Session("RangoFechas"))

            oReporte.SetParameterValue("FechaHoraImpresion", oMensaje.RecuperarDescripcion("Xfechahoraimpresion"))


        ElseIf Session("NumReporte") = 30 Then '--Detallado por Familia
            oReporte.FileName = Server.MapPath("Reports\ReporteDetalladoxFamilia.rpt")
            oReporte.Database.Tables(0).SetDataSource(dt)
            dt = CType(Session("DataTable"), System.Data.DataTable)
            oReporte.Database.Tables(1).SetDataSource(dt)

            oReporte.SetParameterValue("NombreReporte", Session("Nombre").ToString().ToUpper())

            oReporte.SetParameterValue("CEDI", oMensaje.RecuperarDescripcion("XCentroDistribucion"))
            oReporte.SetParameterValue("Fecha", oMensaje.RecuperarDescripcion("XFECHA"))
            oReporte.SetParameterValue("Ruta", oMensaje.RecuperarDescripcion("XRuta"))
            oReporte.SetParameterValue("Esquema", oMensaje.RecuperarDescripcion("XEsquema"))

            oReporte.SetParameterValue("EnviadoFecha", Session("RangoFechas"))
            oReporte.SetParameterValue("EnviadoRuta", Session("FiltroRutas"))
            oReporte.SetParameterValue("EnviadoEsquema", Session("FiltroEsquemas"))
            oReporte.SetParameterValue("EnviadoCliente", Session("FiltroClientes"))

            oReporte.SetParameterValue("FechaHoraImpresion", oMensaje.RecuperarDescripcion("Xfechahoraimpresion"))

            oReporte.SetParameterValue("Familia", oMensaje.RecuperarDescripcion("XFamilia").ToUpper & ":")
            oReporte.SetParameterValue("Cliente", oMensaje.RecuperarDescripcion("XCliente"))
            oReporte.SetParameterValue("Producto", oMensaje.RecuperarDescripcion("XProducto"))
            oReporte.SetParameterValue("Cantidad", oMensaje.RecuperarDescripcion("XCantidad"))
            oReporte.SetParameterValue("TotalFamilia", oMensaje.RecuperarDescripcion("XTotalFamilia"))

        ElseIf Session("NumReporte") = 31 Then '--Reporte de Promociones
            oReporte.FileName = Server.MapPath("Reports\ReportePromociones.rpt")
            oReporte.Database.Tables(0).SetDataSource(dt)
            dt = CType(Session("DataTable"), System.Data.DataTable)
            oReporte.Database.Tables(1).SetDataSource(dt)

            oReporte.SetParameterValue("Nombre", Session("Nombre").ToString().ToUpper())

            oReporte.SetParameterValue("Anio", oMensaje.RecuperarDescripcion("XAnio"))
            oReporte.SetParameterValue("EnviadosAnios", Session("Anios"))

            oReporte.SetParameterValue("CEDI", oMensaje.RecuperarDescripcion("XCentroDistribucion"))
            oReporte.SetParameterValue("Fecha", oMensaje.RecuperarDescripcion("XFecha"))
            oReporte.SetParameterValue("Ruta", oMensaje.RecuperarDescripcion("XRuta"))
            oReporte.SetParameterValue("Vendedor", oMensaje.RecuperarDescripcion("XVendedor"))

            oReporte.SetParameterValue("EnviadaFecha", Session("RangoFechas"))
            oReporte.SetParameterValue("EnviadaRuta", Session("FiltroRutas"))
            oReporte.SetParameterValue("EnviadoVendedor", Session("Vendedor"))

            oReporte.SetParameterValue("Mes", oMensaje.RecuperarDescripcion("XMes"))
            oReporte.SetParameterValue("ClaveVendedor", oMensaje.RecuperarDescripcion("XCveVendedor"))
            oReporte.SetParameterValue("NombreVendedor", oMensaje.RecuperarDescripcion("XNombre"))
            oReporte.SetParameterValue("Cuota", oMensaje.RecuperarDescripcion("XCuota"))
            oReporte.SetParameterValue("Total", oMensaje.RecuperarDescripcion("XTotalVenta"))
            oReporte.SetParameterValue("PorAvance", oMensaje.RecuperarDescripcion("XPAvance"))
            oReporte.SetParameterValue("DifMeta", oMensaje.RecuperarDescripcion("XDifMeta"))
            oReporte.SetParameterValue("ImpPromocion", oMensaje.RecuperarDescripcion("XImpPromo"))
            oReporte.SetParameterValue("DifPromocion", oMensaje.RecuperarDescripcion("XDifPromo"))
            oReporte.SetParameterValue("PorPromocion", oMensaje.RecuperarDescripcion("XPPromo"))
            oReporte.SetParameterValue("TotalMes", oMensaje.RecuperarDescripcion("XTotalMes"))
            oReporte.SetParameterValue("TotalRuta", oMensaje.RecuperarDescripcion("XTotalRuta"))

            oReporte.SetParameterValue("clavecuota", oMensaje.RecuperarDescripcion("XClaveCuota"))

            oReporte.SetParameterValue("FechaHoraImpresion", oMensaje.RecuperarDescripcion("Xfechahoraimpresion"))

        ElseIf Session("NumReporte") = 33 Then 'Diario de actividades
            'DataSource
            oReporte.FileName = Server.MapPath("Reports\ReporteDiarioActividades.rpt")
            oReporte.Database.Tables("Configuracion").SetDataSource(dt)
            If IsNothing(Session("subreport0")) Then
                Session("subreport0") = ins.EjecutarConsulta(Session("Visitados"), IntCommandTimeOut)
            End If
            dt = Session("subreport0")
            'dt = ins.EjecutarConsulta(Session("Visitados"), IntCommandTimeOut)
            oReporte.Database.Tables("CteVisitado").SetDataSource(dt)

            If IsNothing(Session("subreport1")) Then
                Session("subreport1") = ins.EjecutarConsulta(Session("NoVisitados"), IntCommandTimeOut)
            End If
            dt = Session("subreport1")
            'dt = ins.EjecutarConsulta(Session("NoVisitados"), IntCommandTimeOut)
            oReporte.Subreports("ClientesNoVisitados").Database.Tables("CteNoVisitado").SetDataSource(dt)

            If IsNothing(Session("subreport2")) Then
                Session("subreport2") = ins.EjecutarConsulta(Session("Totales"), IntCommandTimeOut)
            End If
            dt = Session("subreport2")
            'dt = ins.EjecutarConsulta(Session("Totales"), IntCommandTimeOut)
            oReporte.Subreports("Totales").Database.Tables("Totales").SetDataSource(dt)

            If IsNothing(Session("subreport3")) Then
                Session("subreport3") = ins.EjecutarConsulta(Session("Cuotas"), IntCommandTimeOut)
            End If
            dt = Session("subreport3")
            'dt = ins.EjecutarConsulta(Session("Cuotas"), IntCommandTimeOut)
            oReporte.Subreports("Cuotas").Database.Tables("Cuotas").SetDataSource(dt)
            'Parametros

            oReporte.SetParameterValue("Nombre", Session("Nombre").ToString().ToUpper())
            oReporte.SetParameterValue("EnviadaFecha", Session("RangoFechas"))
            oReporte.SetParameterValue("EnviadoCedi", Session("CEDI"))
            oReporte.SetParameterValue("EnviadoVendedor", Session("Vendedor"))
            oReporte.SetParameterValue("EnviadaRuta", Session("Ruta"))

            oReporte.SetParameterValue("Fecha", oMensaje.RecuperarDescripcion("XFecha"))
            oReporte.SetParameterValue("CEDI", oMensaje.RecuperarDescripcion("XCentroDistribucion"))
            oReporte.SetParameterValue("Vendedor", oMensaje.RecuperarDescripcion("XVendedor"))
            oReporte.SetParameterValue("Ruta", oMensaje.RecuperarDescripcion("XRuta"))

            oReporte.SetParameterValue("XSecuencia", oMensaje.RecuperarDescripcion("SECSEC"))
            oReporte.SetParameterValue("XClienteClave", oMensaje.RecuperarDescripcion("CLIClave"))
            oReporte.SetParameterValue("XNombreCliente", oMensaje.RecuperarDescripcion("CLICliente"))
            oReporte.SetParameterValue("XHoraInicio", oMensaje.RecuperarDescripcion("VISHRFIN"))
            oReporte.SetParameterValue("XHoraFin", oMensaje.RecuperarDescripcion("VISHRINI"))
            oReporte.SetParameterValue("XVenta", oMensaje.RecuperarDescripcion("XVENTA"))
            oReporte.SetParameterValue("XConcepto", oMensaje.RecuperarDescripcion("XMotivoImprod"))
            oReporte.SetParameterValue("XVentaTotal", oMensaje.RecuperarDescripcion("XVentaTotal"))
            oReporte.SetParameterValue("XCodigoNoLeido", oMensaje.RecuperarDescripcion("XCodigoNoLeido"))
            oReporte.SetParameterValue("XFueraFrecuencia", oMensaje.RecuperarDescripcion("XFueraFrecuencia"))
            oReporte.SetParameterValue("FechaHoraImpresion", oMensaje.RecuperarDescripcion("XRuta"))
            oReporte.SetParameterValue("XInicioRecorrido", oMensaje.RecuperarDescripcion("XInicioRecorrido"))
            oReporte.SetParameterValue("XFinRecorrido", oMensaje.RecuperarDescripcion("XFinRecorrido"))
            oReporte.SetParameterValue("XTiempoRecorrido", oMensaje.RecuperarDescripcion("XTiempoRecorrido"))
            oReporte.SetParameterValue("XTiempoTransito", oMensaje.RecuperarDescripcion("XTiempoTransito"))
            oReporte.SetParameterValue("XPromedioVisita", oMensaje.RecuperarDescripcion("XPromedioVisita"))
            oReporte.SetParameterValue("XPromedioTransito", oMensaje.RecuperarDescripcion("XPromedioTransito"))

            oReporte.SetParameterValue("XCteNoVisitado", oMensaje.RecuperarDescripcion("XClientesNoVisitados"))

            oReporte.SetParameterValue("XTotalClientes", oMensaje.RecuperarDescripcion("XTotalClientes"))
            oReporte.SetParameterValue("XVisitados", oMensaje.RecuperarDescripcion("XVisitados"))
            oReporte.SetParameterValue("XNoVisitados", oMensaje.RecuperarDescripcion("XNoVisitados"))
            oReporte.SetParameterValue("XEficiencia", oMensaje.RecuperarDescripcion("XEficiencia"))
            oReporte.SetParameterValue("XConVenta", oMensaje.RecuperarDescripcion("XVisitadosConVenta"))
            oReporte.SetParameterValue("XSinVenta", oMensaje.RecuperarDescripcion("XVisitadosSinVenta"))
            oReporte.SetParameterValue("XCodigosNoLeidos", oMensaje.RecuperarDescripcion("XTotalCodigoNoLeido"))
            oReporte.SetParameterValue("XEfectividad", oMensaje.RecuperarDescripcion("XEfectividad"))
            oReporte.SetParameterValue("XFueraDeFrecuencia", oMensaje.RecuperarDescripcion("XFueraFrecuencia"))
            oReporte.SetParameterValue("XFueraFrecuenciaVenta", oMensaje.RecuperarDescripcion("XFueraFrecuenciaVta"))
            oReporte.SetParameterValue("XEfectividadFueraFrec", oMensaje.RecuperarDescripcion("XEfectividadFueraFrec"))

            oReporte.SetParameterValue("XMeta", oMensaje.RecuperarDescripcion("XMeta"))
            oReporte.SetParameterValue("XAcumulado", oMensaje.RecuperarDescripcion("XAcumulado"))
            oReporte.SetParameterValue("XDifMeta", oMensaje.RecuperarDescripcion("XDifMeta"))
            oReporte.SetParameterValue("XCuota", oMensaje.RecuperarDescripcion("XCuota"))

        ElseIf Session("NumReporte") = 32 Then '--Reporte de Venta Diario
            oReporte.FileName = Server.MapPath("Reports\ReporteVentaDiario.rpt")
            oReporte.Database.Tables(0).SetDataSource(dt)
            dt = CType(Session("DataTable"), System.Data.DataTable)
            oReporte.Database.Tables(1).SetDataSource(dt)

            oReporte.SetParameterValue("Nombre", Session("Nombre").ToString().ToUpper())

            oReporte.SetParameterValue("CEDI", oMensaje.RecuperarDescripcion("XCentroDistribucion"))
            oReporte.SetParameterValue("Fecha", oMensaje.RecuperarDescripcion("XFecha"))
            oReporte.SetParameterValue("Ruta", oMensaje.RecuperarDescripcion("XRuta"))
            oReporte.SetParameterValue("Vendedor", oMensaje.RecuperarDescripcion("XVendedor"))

            oReporte.SetParameterValue("EnviadaFecha", Session("RangoFechas"))
            oReporte.SetParameterValue("EnviadaRuta", Session("FiltroRutas"))
            oReporte.SetParameterValue("EnviadoVendedor", Session("Vendedor"))

            oReporte.SetParameterValue("Categoria", oMensaje.RecuperarDescripcion("XCategoria"))
            oReporte.SetParameterValue("PROClave", oMensaje.RecuperarDescripcion("XClave"))
            oReporte.SetParameterValue("PRONombre", oMensaje.RecuperarDescripcion("XNombre"))
            oReporte.SetParameterValue("TotalCtes", oMensaje.RecuperarDescripcion("XTotalCtes"))
            oReporte.SetParameterValue("ClienteCVenta", oMensaje.RecuperarDescripcion("XClienteCVenta"))
            oReporte.SetParameterValue("PCobertura", oMensaje.RecuperarDescripcion("XPCobertura"))
            oReporte.SetParameterValue("Piezas", oMensaje.RecuperarDescripcion("XPiezas"))
            oReporte.SetParameterValue("Precio", oMensaje.RecuperarDescripcion("XPrecio"))
            oReporte.SetParameterValue("Total", oMensaje.RecuperarDescripcion("XTotal"))
            oReporte.SetParameterValue("TotalCtesFRuta", oMensaje.RecuperarDescripcion("XTotalCtesFRuta"))
            oReporte.SetParameterValue("CVentaFRuta", oMensaje.RecuperarDescripcion("XCVentaFRuta"))
            oReporte.SetParameterValue("CoberturaFRuta", oMensaje.RecuperarDescripcion("XCoberturaFRuta"))
            oReporte.SetParameterValue("PiezasFRuta", oMensaje.RecuperarDescripcion("XPiezasFRuta"))
            oReporte.SetParameterValue("TotalFRuta", oMensaje.RecuperarDescripcion("XTotalFRuta"))

            oReporte.SetParameterValue("TotalCategoria", oMensaje.RecuperarDescripcion("XTotalCategoria"))
            oReporte.SetParameterValue("TotalRuta", oMensaje.RecuperarDescripcion("XTotalRuta"))
            oReporte.SetParameterValue("Acumulado", oMensaje.RecuperarDescripcion("XAcumulado"))

            oReporte.SetParameterValue("FechaHoraImpresion", oMensaje.RecuperarDescripcion("Xfechahoraimpresion"))

        ElseIf Session("NumReporte") = 34 Then '--Indicadores
            oReporte.FileName = Server.MapPath("Reports\IndicadorVenta.rpt")
            oReporte.Database.Tables(1).SetDataSource(dt)
            dt = CType(Session("DataTable"), System.Data.DataTable)
            oReporte.Database.Tables(0).SetDataSource(dt)

            oReporte.SetParameterValue("Nombre", Session("Nombre").ToString().ToUpper())

            oReporte.SetParameterValue("EnviadaFecha", Session("RangoFechas"))
            oReporte.SetParameterValue("EnviadaRuta", Session("FiltroRutas"))
            oReporte.SetParameterValue("EnviadoVendedor", Session("Vendedor"))
            oReporte.SetParameterValue("EnviadoCedi", Session("CEDI"))

            oReporte.SetParameterValue("CEDI", oMensaje.RecuperarDescripcion("XCentroDistribucion"))
            oReporte.SetParameterValue("Fecha", oMensaje.RecuperarDescripcion("XFecha"))
            oReporte.SetParameterValue("Ruta", oMensaje.RecuperarDescripcion("XRuta"))
            oReporte.SetParameterValue("Vendedor", oMensaje.RecuperarDescripcion("XVendedor"))

            oReporte.SetParameterValue("Itinerario", oMensaje.RecuperarDescripcion("XEnItinerario"))
            oReporte.SetParameterValue("Visitados", oMensaje.RecuperarDescripcion("XVisitados"))
            oReporte.SetParameterValue("Eficiencia", oMensaje.RecuperarDescripcion("XEficiencia"))
            oReporte.SetParameterValue("VisVenta", oMensaje.RecuperarDescripcion("XVisitadosconventa"))
            oReporte.SetParameterValue("Efectividad", oMensaje.RecuperarDescripcion("XEfectividad"))
            oReporte.SetParameterValue("NoVisitados", oMensaje.RecuperarDescripcion("XNoVisitados"))
            oReporte.SetParameterValue("TotalVenta", oMensaje.RecuperarDescripcion("XTotalVenta"))
            oReporte.SetParameterValue("FueraFrec", oMensaje.RecuperarDescripcion("XFueraFrec"))
            oReporte.SetParameterValue("FueraFrecV", oMensaje.RecuperarDescripcion("XFueraFrecV"))
            oReporte.SetParameterValue("TotalRuta", oMensaje.RecuperarDescripcion("XTotalPorRuta"))
            oReporte.SetParameterValue("Acumulado", oMensaje.RecuperarDescripcion("XAcumulado"))

        ElseIf Session("NumReporte") = 35 Then 'Liquidacion Pascual Boing

            oReporte.FileName = Server.MapPath("Reports\ReporteLiquidacionPascual.rpt")

            oReporte.Database.Tables(0).SetDataSource(dt)


            oReporte.Subreports("VentasProductos").Database.Tables("VentasProductos").SetDataSource(Session("VentasProductos"))

            If IsNothing(Session("subreport0")) Then
                Session("subreport0") = ins.EjecutarConsulta(Session("Embalajes"), IntCommandTimeOut)
            End If
            oReporte.Subreports("Embalajes").Database.Tables("Embalajes").SetDataSource(Session("subreport0"))
            'oReporte.Subreports("Embalajes").Database.Tables("Embalajes").SetDataSource(ins.EjecutarConsulta(Session("Embalajes"), IntCommandTimeOut))

            If IsNothing(Session("subreport1")) Then
                Session("subreport1") = ins.EjecutarConsulta(Session("CobranzaCheques"), IntCommandTimeOut)
            End If
            oReporte.Subreports("CobranzaCheques").Database.Tables("CobranzaCheques").SetDataSource(Session("subreport1"))
            'oReporte.Subreports("CobranzaCheques").Database.Tables("CobranzaCheques").SetDataSource(ins.EjecutarConsulta(Session("CobranzaCheques"), IntCommandTimeOut))

            If IsNothing(Session("subreport2")) Then
                Session("subreport2") = ins.EjecutarConsulta(Session("Creditos"), IntCommandTimeOut)
            End If
            oReporte.Subreports("Creditos").Database.Tables("Creditos").SetDataSource(Session("subreport2"))
            'oReporte.Subreports("Creditos").Database.Tables("Creditos").SetDataSource(ins.EjecutarConsulta(Session("Creditos"), IntCommandTimeOut))

            If IsNothing(Session("subreport3")) Then
                Session("subreport3") = ins.EjecutarConsulta(Session("CobranzaAnteriores"), IntCommandTimeOut)
            End If
            oReporte.Subreports("CobranzaAnteriores").Database.Tables("CobranzaAnteriores").SetDataSource(Session("subreport3"))
            ''oReporte.Subreports("CobranzaAnteriores").Database.Tables("CobranzaAnteriores").SetDataSource(ins.EjecutarConsulta(Session("CobranzaAnteriores"), IntCommandTimeOut))

            If IsNothing(Session("subreport4")) Then
                Session("subreport4") = ins.EjecutarConsulta(Session("ProdAcum"), IntCommandTimeOut)
            End If
            oReporte.Subreports("ProdAcum").Database.Tables("ProdAcum").SetDataSource(Session("subreport4"))
            'oReporte.Subreports("ProdAcum").Database.Tables("ProdAcum").SetDataSource(ins.EjecutarConsulta(Session("ProdAcum"), IntCommandTimeOut))


            oReporte.SetParameterValue("NombreRep", Session("Nombre").ToString().ToUpper())
            oReporte.SetParameterValue("CEDI", oMensaje.RecuperarDescripcion("XCentroDistribucion"))
            oReporte.SetParameterValue("Fecha", oMensaje.RecuperarDescripcion("XFECHA"))
            oReporte.SetParameterValue("enviadoFecha", Session("RangoFechas"))
            oReporte.SetParameterValue("VENDEDOR", oMensaje.RecuperarDescripcion("XVendedor"))
            oReporte.SetParameterValue("enviadoVendedor", Session("Vendedor"))

            'Seccion Liquidos
            oReporte.SetParameterValue("Liquidos", oMensaje.RecuperarDescripcion("XLiquidos").ToUpper)
            oReporte.SetParameterValue("LiquidosProductoClave", oMensaje.RecuperarDescripcion("XClave"))
            oReporte.SetParameterValue("LiquidosDescripcion", oMensaje.RecuperarDescripcion("XDescripcion"))
            oReporte.SetParameterValue("LiquidosCargas", oMensaje.RecuperarDescripcion("MDBCargas"))
            oReporte.SetParameterValue("LiquidosAjustes", oMensaje.RecuperarDescripcion("MDBAjustes"))
            oReporte.SetParameterValue("LiquidosDevoluciones", oMensaje.RecuperarDescripcion("XDevoluciones"))
            oReporte.SetParameterValue("LiquidosAlmacen", oMensaje.RecuperarDescripcion("CAlmacen"))
            oReporte.SetParameterValue("LiquidosDescargas", oMensaje.RecuperarDescripcion("XDescargas"))
            oReporte.SetParameterValue("LiquidosVentaBruta", oMensaje.RecuperarDescripcion("XVentaBruta"))
            oReporte.SetParameterValue("LiquidosVentas", oMensaje.RecuperarDescripcion("XVentas"))
            oReporte.SetParameterValue("LiquidosPromocion", oMensaje.RecuperarDescripcion("XPromociones"))
            oReporte.SetParameterValue("LiquidosPrecio", oMensaje.RecuperarDescripcion("XPrecio"))
            oReporte.SetParameterValue("LiquidosImporte", oMensaje.RecuperarDescripcion("XImporte"))
            oReporte.SetParameterValue("TotalLiquidos", oMensaje.RecuperarDescripcion("XTotalLiquido"))

            'Seccion Embalaje
            oReporte.SetParameterValue("Embalaje", oMensaje.RecuperarDescripcion("XEmbalaje").ToUpper)
            oReporte.SetParameterValue("EmbalajeProducto", oMensaje.RecuperarDescripcion("XProducto"))
            oReporte.SetParameterValue("EmbalajeSalen", oMensaje.RecuperarDescripcion("XSalen"))
            oReporte.SetParameterValue("EmbalajeEntran", oMensaje.RecuperarDescripcion("XEntran"))
            oReporte.SetParameterValue("EmbalajeDifBruta", oMensaje.RecuperarDescripcion("XDiferenciaBruta"))
            oReporte.SetParameterValue("EmbalajePromociones", oMensaje.RecuperarDescripcion("XPromociones"))
            oReporte.SetParameterValue("EmbalajeDifImporte", oMensaje.RecuperarDescripcion("XDiferenciaImporte"))
            oReporte.SetParameterValue("TotalEmbalajes", oMensaje.RecuperarDescripcion("XTotalMin"))

            'Seccion CobranzaCheques
            oReporte.SetParameterValue("CobranzaCheques", oMensaje.RecuperarDescripcion("XCobranzaCheques").ToUpper)
            oReporte.SetParameterValue("ChequesFolio", oMensaje.RecuperarDescripcion("XVenta"))
            oReporte.SetParameterValue("ChequesBanco", oMensaje.RecuperarDescripcion("DEPTipoBanco"))
            oReporte.SetParameterValue("ChequesReferencia", oMensaje.RecuperarDescripcion("XNoCheque"))
            oReporte.SetParameterValue("ChequesFechaAbono", oMensaje.RecuperarDescripcion("DEPFechaDeposito"))
            oReporte.SetParameterValue("ChequesImporte", oMensaje.RecuperarDescripcion("DEPImporte"))
            oReporte.SetParameterValue("TotalCobranzaCheques", oMensaje.RecuperarDescripcion("XTotalCobranzaCheques"))
            oReporte.SetParameterValue("TotalLiquidacionCheques", oMensaje.RecuperarDescripcion("XTotalLiquidacionCheques"))

            'Seccion Créditos Otorgados
            oReporte.SetParameterValue("CreditosOtorgados", oMensaje.RecuperarDescripcion("XCreditosOtorgados").ToUpper)
            oReporte.SetParameterValue("CreditosFolio", oMensaje.RecuperarDescripcion("XVenta"))
            oReporte.SetParameterValue("CreditosFecha", oMensaje.RecuperarDescripcion("XFecha"))
            oReporte.SetParameterValue("CreditosCliente", oMensaje.RecuperarDescripcion("XCliente"))
            oReporte.SetParameterValue("CreditosImporte", oMensaje.RecuperarDescripcion("XImporte"))
            oReporte.SetParameterValue("CreditosSaldo", oMensaje.RecuperarDescripcion("XSaldo"))
            oReporte.SetParameterValue("TotalCreditosNormales", oMensaje.RecuperarDescripcion("XTotalCreditosNormales"))
            oReporte.SetParameterValue("TotalCreditosAutoservicios", oMensaje.RecuperarDescripcion("XTotalCreditosAutoservicios"))
            oReporte.SetParameterValue("TotalCreditosOtorgados", oMensaje.RecuperarDescripcion("XTotalCreditosOtorgados"))
            oReporte.SetParameterValue("TotalLiquidacionCreditos", oMensaje.RecuperarDescripcion("XTotalLiquidacionCreditos"))

            'Sección Cobranza Ventas Anteriores
            oReporte.SetParameterValue("CobranzaAnterior", oMensaje.RecuperarDescripcion("XCobranzaVentasAnteriores").ToUpper)
            oReporte.SetParameterValue("CobAntFolio", oMensaje.RecuperarDescripcion("XVenta"))
            oReporte.SetParameterValue("CobAntFecha", oMensaje.RecuperarDescripcion("XFecha"))
            oReporte.SetParameterValue("CobAntTRPTotal", oMensaje.RecuperarDescripcion("XTotalVenta"))
            oReporte.SetParameterValue("CobAntSaldoActual", oMensaje.RecuperarDescripcion("XSaldoActual"))
            oReporte.SetParameterValue("CobAntTipoPago", oMensaje.RecuperarDescripcion("ABDTipoPago"))
            oReporte.SetParameterValue("CobAntReferencia", oMensaje.RecuperarDescripcion("XDocumentoPago"))
            oReporte.SetParameterValue("CobAntImporte", oMensaje.RecuperarDescripcion("XImporte"))
            oReporte.SetParameterValue("TotalCobranzaVentasAnteriores", oMensaje.RecuperarDescripcion("XTotalCobranzaVentasAnteriores"))
            oReporte.SetParameterValue("TotalLiquidacionCobranzaAnterior", oMensaje.RecuperarDescripcion("XTotalLiquidacionCobranzaAnterior"))

            'TotalEfectivo
            oReporte.SetParameterValue("TotalEfectivo", ins.EjecutarComandoScalar(Session("TotalEfectivo")))
            oReporte.SetParameterValue("MsgTotalEfectivo", oMensaje.RecuperarDescripcion("XTotalEfectivo"))

            'Calculo de Comisión
            oReporte.SetParameterValue("TotalCalculoComision", ins.EjecutarComandoScalar(Session("TotalCalculoComision")))
            oReporte.SetParameterValue("MsgTotalCalculoComision", oMensaje.RecuperarDescripcion("XTotalCalculoComision"))
            oReporte.SetParameterValue("TotalPorcentajeComision", Session("PorcentajeComision"))
            oReporte.SetParameterValue("MsgPorcentajeComision", oMensaje.RecuperarDescripcion("XComision"))
            oReporte.SetParameterValue("MsgComision", oMensaje.RecuperarDescripcion("XComision").Replace("%", "").Trim)

            'Firmas
            oReporte.SetParameterValue("MsgPascualBoing", oMensaje.RecuperarDescripcion("XPascualBoing"))


            oReporte.SetParameterValue("XSaldoVentas", oMensaje.RecuperarDescripcion("XSaldoVentas"))
            oReporte.SetParameterValue("SaldoVentas", Session("SaldosVentas"))
            oReporte.SetParameterValue("XSaldoEmbalajes", oMensaje.RecuperarDescripcion("XSaldoEmbalajes"), "ProdAcum")
            oReporte.SetParameterValue("XCantidad", oMensaje.RecuperarDescripcion("XCantidad"))
            oReporte.SetParameterValue("XImporte", oMensaje.RecuperarDescripcion("XPrecio"))
            oReporte.SetParameterValue("XTotal", oMensaje.RecuperarDescripcion("XTotal"))
            oReporte.SetParameterValue("EdoCuentaAcumulado", oMensaje.RecuperarDescripcion("XEdoCuentaAcumulado"))
            oReporte.SetParameterValue("XAcumuladoEmbalajes", oMensaje.RecuperarDescripcion("XAcumuladoEmbalajes"))
            oReporte.SetParameterValue("XAcumuladoVentas", oMensaje.RecuperarDescripcion("XAcumuladoVentas"))
            oReporte.SetParameterValue("Producto", oMensaje.RecuperarDescripcion("XProducto"))

        ElseIf Session("NumReporte") = 36 Then '-------------------------------------------------------------------------------------------------------------------
            oReporte.FileName = Server.MapPath("Reports\ReporteProductoOtorgadoPromocion.rpt")

            oReporte.Database.Tables(0).SetDataSource(dt)
            oReporte.Database.Tables(1).SetDataSource(Session("DataTable"))

            If IsNothing(Session("subreport0")) Then
                Session("subreport0") = ins.EjecutarConsulta(Session("Query2"), IntCommandTimeOut)
            End If
            oReporte.Subreports(0).Database.Tables(0).SetDataSource(Session("subreport0"))

            oReporte.SetParameterValue("Producto", oMensaje.RecuperarDescripcion("XProducto"))
            oReporte.SetParameterValue("Producto1", oMensaje.RecuperarDescripcion("XProducto"))
            oReporte.SetParameterValue("nombre", Session("Nombre").ToString().ToUpper())
            oReporte.SetParameterValue("cliente", oMensaje.RecuperarDescripcion("Xcliente"))
            oReporte.SetParameterValue("cliente1", oMensaje.RecuperarDescripcion("Xcliente"))
            oReporte.SetParameterValue("productonegados1", oMensaje.RecuperarDescripcion("Xproductonegado"))

            oReporte.SetParameterValue("pedidos", oMensaje.RecuperarDescripcion("XPedido"))
            oReporte.SetParameterValue("pedidos1", oMensaje.RecuperarDescripcion("XPedido"))
            oReporte.SetParameterValue("fecha", oMensaje.RecuperarDescripcion("Xfecha"))
            oReporte.SetParameterValue("promocion", oMensaje.RecuperarDescripcion("Xpromocion"))
            oReporte.SetParameterValue("promocion1", oMensaje.RecuperarDescripcion("Xpromocion"))
            oReporte.SetParameterValue("unidad", oMensaje.RecuperarDescripcion("Xunidad"))
            oReporte.SetParameterValue("unidad1", oMensaje.RecuperarDescripcion("Xunidad"))
            oReporte.SetParameterValue("cantidad", oMensaje.RecuperarDescripcion("Xcantidad"))
            oReporte.SetParameterValue("cantidad1", oMensaje.RecuperarDescripcion("Xcantidad"))
            oReporte.SetParameterValue("ruta", oMensaje.RecuperarDescripcion("Xruta"))
            oReporte.SetParameterValue("vendedor", oMensaje.RecuperarDescripcion("Xvendedor"))

            oReporte.SetParameterValue("enviadaFecha", Session("RangoFechas"))
            oReporte.SetParameterValue("FechaHoraImpresion", oMensaje.RecuperarDescripcion("Xfechahoraimpresion"))
            oReporte.SetParameterValue("enviadoVendedor", Session("Vendedor"))
            oReporte.SetParameterValue("EnviadaRuta", Session("FiltroRutas")) 'Session("FiltroRutas"))

            oReporte.SetParameterValue("fecha", oMensaje.RecuperarDescripcion("Xfecha"))
            oReporte.SetParameterValue("fecha1", oMensaje.RecuperarDescripcion("Xfecha"))
            oReporte.SetParameterValue("fechasurtido", oMensaje.RecuperarDescripcion("Xfechasurtido"))
            oReporte.SetParameterValue("productosentregados", oMensaje.RecuperarDescripcion("Xproductoentregado"))


            oReporte.SetParameterValue("TotalVendedor", oMensaje.RecuperarDescripcion("XTotalSolicitudesVendedor"))
            oReporte.SetParameterValue("TotalVendedor1", oMensaje.RecuperarDescripcion("XTotalSolicitudesVendedor"))
            oReporte.SetParameterValue("TOTALRUTA", oMensaje.RecuperarDescripcion("Xtotalruta"))
            oReporte.SetParameterValue("TotalRUTA1", oMensaje.RecuperarDescripcion("Xtotalruta"))
            oReporte.SetParameterValue("TotalEntregado", oMensaje.RecuperarDescripcion("Xtotalentregado"))
            oReporte.SetParameterValue("TotalEntregado1", oMensaje.RecuperarDescripcion("XTotalNoEntregado"))
            oReporte.SetParameterValue("SaldoPN", oMensaje.RecuperarDescripcion("XSaldo"))
            oReporte.SetParameterValue("fase1", oMensaje.RecuperarDescripcion("Xfase"))
            oReporte.SetParameterValue("ruta1", oMensaje.RecuperarDescripcion("xruta"))
            oReporte.SetParameterValue("vendedor1", oMensaje.RecuperarDescripcion("xvendedor"))
            oReporte.SetParameterValue("fechafase1", oMensaje.RecuperarDescripcion("Xfechafase"))


        ElseIf Session("NumReporte") = 38 Then 'Ventas El Panque

            oReporte.FileName = Server.MapPath("Reports\ReporteVentasElPanque.rpt")

            oReporte.Database.Tables(0).SetDataSource(dt)
            dt = CType(Session("DataTable"), System.Data.DataTable)
            oReporte.Database.Tables(1).SetDataSource(dt)

            If IsNothing(Session("subreport1")) Then
                Session("subreport1") = ins.EjecutarConsulta(Session("Query2"), IntCommandTimeOut)
            End If
            oReporte.Subreports("Contacto").Database.Tables(0).SetDataSource(Session("subreport1"))


            If Session("TipoReporte") = "Detallado" Then
                oReporte.SetParameterValue("XDetallado", 1)
            ElseIf Session("TipoReporte") = "General" Then
                oReporte.SetParameterValue("XDetallado", 0)
            End If

            oReporte.SetParameterValue("EnviadoCEDI", Session("CEDI"))
            oReporte.SetParameterValue("Enviadovendedor", Session("Vendedor"))
            oReporte.SetParameterValue("Enviadaruta", Session("Ruta"))
            oReporte.SetParameterValue("Enviadafecha", Session("RangoFechas"))

            oReporte.SetParameterValue("XNombreReporte", Session("Nombre").ToString().ToUpper()) '''''''''''''****<----Nombre por filtros
            oReporte.SetParameterValue("CentroDistribucion", oMensaje.RecuperarDescripcion("XCentroDistribucion"))
            oReporte.SetParameterValue("XFecha", oMensaje.RecuperarDescripcion("XFECHA"))
            oReporte.SetParameterValue("XVendedor", oMensaje.RecuperarDescripcion("XVendedor"))
            oReporte.SetParameterValue("XRuta", oMensaje.RecuperarDescripcion("Xruta"))

            oReporte.SetParameterValue("XCliente", oMensaje.RecuperarDescripcion("XCliente"))
            oReporte.SetParameterValue("XFolio", oMensaje.RecuperarDescripcion("XFolio"))
            oReporte.SetParameterValue("XFechaCreacion", oMensaje.RecuperarDescripcion("XFechaHoraCreacion"))
            oReporte.SetParameterValue("XFechaCancelacion", oMensaje.RecuperarDescripcion("XFechaHoraCancelacion"))
            oReporte.SetParameterValue("XEstado", oMensaje.RecuperarDescripcion("XEstado"))
            oReporte.SetParameterValue("XImporte", oMensaje.RecuperarDescripcion("XImporte"))

            oReporte.SetParameterValue("XNombreContacto", oMensaje.RecuperarDescripcion("XNombreContacto"))
            oReporte.SetParameterValue("XTel", oMensaje.RecuperarDescripcion("XTel"))
            oReporte.SetParameterValue("XPuntoEntrega", oMensaje.RecuperarDescripcion("XPuntoEntrega"))
            oReporte.SetParameterValue("XPuntoEntrega1", oMensaje.RecuperarDescripcion("XPuntoEntrega"))


            oReporte.SetParameterValue("XCanceladaSurtida", oMensaje.RecuperarDescripcion("XVtaCancelada_Surtida"))
            oReporte.SetParameterValue("FechaHoraImpresion", oMensaje.RecuperarDescripcion("Xfechahoraimpresion"))

        ElseIf Session("NumReporte") = 39 Then 'Liquidacion Bajo Cero

            oReporte.FileName = Server.MapPath("Reports\ReporteLiquidacionBajoCero.rpt")

            oReporte.Database.Tables(0).SetDataSource(dt)
            oReporte.Database.Tables(1).SetDataSource(Session("Resumen"))

            If IsNothing(Session("subreport0")) Then
                Session("subreport0") = ins.EjecutarConsulta(Session("VentasProductos"), IntCommandTimeOut)
            End If
            oReporte.Subreports("VentasProductos").Database.Tables("VentasProductos").SetDataSource(Session("subreport0"))

            If IsNothing(Session("subreport1")) Then
                Session("subreport1") = ins.EjecutarConsulta(Session("Gastos"), IntCommandTimeOut)
            End If
            oReporte.Subreports("GastosEfectuados").Database.Tables("GastosEfectuados").SetDataSource(Session("subreport1"))

            If IsNothing(Session("subreport2")) Then
                Session("subreport2") = ins.EjecutarConsulta(Session("VentasEfectivo"), IntCommandTimeOut)
            End If
            oReporte.Subreports("VentasEfectivo").Database.Tables("Ventas").SetDataSource(Session("subreport2"))

            If IsNothing(Session("subreport3")) Then
                Session("subreport3") = ins.EjecutarConsulta(Session("VentasCredito"), IntCommandTimeOut)
            End If
            oReporte.Subreports("VentasCredito").Database.Tables("Ventas").SetDataSource(Session("subreport3"))

            If IsNothing(Session("subreport4")) Then
                Session("subreport4") = ins.EjecutarConsulta(Session("DepositosEfectivo"), IntCommandTimeOut)
            End If
            oReporte.Subreports("DepositosEfectivo").Database.Tables("DepositosEfectivo").SetDataSource(Session("subreport4"))


            oReporte.SetParameterValue("NombreRep", Session("Nombre").ToString().ToUpper())
            oReporte.SetParameterValue("CEDI", oMensaje.RecuperarDescripcion("XCentroDistribucion"))
            oReporte.SetParameterValue("Fecha", oMensaje.RecuperarDescripcion("XFECHA"))
            oReporte.SetParameterValue("enviadoFecha", Session("RangoFechas"))
            oReporte.SetParameterValue("VENDEDOR", oMensaje.RecuperarDescripcion("XVendedor"))
            oReporte.SetParameterValue("enviadoVendedor", Session("Vendedor"))

            'Seccion Ventas por Producto
            oReporte.SetParameterValue("VentasProducto", oMensaje.RecuperarDescripcion("XVentasProducto").ToUpper)
            oReporte.SetParameterValue("VentasProProductoClave", oMensaje.RecuperarDescripcion("XClave"))
            oReporte.SetParameterValue("VentasProDescripcion", oMensaje.RecuperarDescripcion("XDescripcion"))
            oReporte.SetParameterValue("VentasProInventarioInicial", oMensaje.RecuperarDescripcion("XInvInicial"))
            oReporte.SetParameterValue("VentasProRecarga", oMensaje.RecuperarDescripcion("XRecarga"))
            oReporte.SetParameterValue("VentasProBonificacion", oMensaje.RecuperarDescripcion("XBonificacion"))
            oReporte.SetParameterValue("VentasProMerma", oMensaje.RecuperarDescripcion("XMerma"))
            oReporte.SetParameterValue("VentasProCambiosDano", oMensaje.RecuperarDescripcion("XCambioDano"))
            oReporte.SetParameterValue("VentasProPromocion", oMensaje.RecuperarDescripcion("XPromocion"))
            oReporte.SetParameterValue("VentasProInventarioFinal", oMensaje.RecuperarDescripcion("XInvFinalDisp"))
            oReporte.SetParameterValue("VentasProVentas", oMensaje.RecuperarDescripcion("XVentas"))
            oReporte.SetParameterValue("VentasProImporte", oMensaje.RecuperarDescripcion("XImporte"))
            oReporte.SetParameterValue("VentasProTotalVentas", oMensaje.RecuperarDescripcion("XTotalVtasProd"))
            oReporte.SetParameterValue("VentasProCancelacion", "Cancelación")


            'Seccion Gastos Efectuados
            oReporte.SetParameterValue("GastosEfectuados", oMensaje.RecuperarDescripcion("XGastosEfectuados").ToUpper)
            oReporte.SetParameterValue("GastosFolio", oMensaje.RecuperarDescripcion("XFolio"))
            oReporte.SetParameterValue("GastosConcepto", oMensaje.RecuperarDescripcion("XConcepto"))
            oReporte.SetParameterValue("GastosKilometros", oMensaje.RecuperarDescripcion("XKilometros"))
            oReporte.SetParameterValue("GastosLitros", oMensaje.RecuperarDescripcion("XLitros"))

            'Seccion Ventas Efectivo
            oReporte.SetParameterValue("VentasEfectivo", oMensaje.RecuperarDescripcion("XVentasEfectivo").ToUpper)
            oReporte.SetParameterValue("VentasEfectivoVenta", oMensaje.RecuperarDescripcion("XVenta"))
            oReporte.SetParameterValue("VentasEfectivoFecha", oMensaje.RecuperarDescripcion("XFecha"))
            oReporte.SetParameterValue("VentasEfectivoCliente", oMensaje.RecuperarDescripcion("XCliente"))
            oReporte.SetParameterValue("VentasEfectivoImporte", oMensaje.RecuperarDescripcion("XImporte"))
            oReporte.SetParameterValue("VentasEfectivoTotalVenta", oMensaje.RecuperarDescripcion("XTotalVtaContado"))

            'Seccion Ventas Credito
            oReporte.SetParameterValue("VentasCredito", oMensaje.RecuperarDescripcion("XVentasCredito").ToUpper)
            oReporte.SetParameterValue("VentasCreditoVenta", oMensaje.RecuperarDescripcion("XVenta"))
            oReporte.SetParameterValue("VentasCreditoFecha", oMensaje.RecuperarDescripcion("XFecha"))
            oReporte.SetParameterValue("VentasCreditoCliente", oMensaje.RecuperarDescripcion("XCliente"))
            oReporte.SetParameterValue("VentasCreditoImporte", oMensaje.RecuperarDescripcion("XImporte"))
            oReporte.SetParameterValue("VentasCreditoTotalVenta", oMensaje.RecuperarDescripcion("XTotalVtaCredito"))

            'Sección Depositos y Efectivo
            oReporte.SetParameterValue("DepositosEfectivo", oMensaje.RecuperarDescripcion("XDepositosEfectivo").ToUpper)
            oReporte.SetParameterValue("DepositosEfeTipo", oMensaje.RecuperarDescripcion("XTipo"))
            oReporte.SetParameterValue("DepositosEfeDenominacion", oMensaje.RecuperarDescripcion("XDenominacion"))
            oReporte.SetParameterValue("DepositosEfeCantidad", oMensaje.RecuperarDescripcion("XCantidad"))
            oReporte.SetParameterValue("DepositosEfeReferencia", oMensaje.RecuperarDescripcion("XReferencia"))
            oReporte.SetParameterValue("DepositosEfeFicha", oMensaje.RecuperarDescripcion("XFicha"))
            oReporte.SetParameterValue("DepositosEfeBanco", oMensaje.RecuperarDescripcion("XBanco"))
            oReporte.SetParameterValue("DepositosEfeImporte", oMensaje.RecuperarDescripcion("XImporte"))
            oReporte.SetParameterValue("DepositosEfeTotal", oMensaje.RecuperarDescripcion("XTotalDepEfec"))

            'Resumen
            oReporte.SetParameterValue("Resumen", oMensaje.RecuperarDescripcion("XResumen"))
            oReporte.SetParameterValue("TotalVentas", oMensaje.RecuperarDescripcion("XTotalVtasProd"))
            oReporte.SetParameterValue("TotalLiquidar", oMensaje.RecuperarDescripcion("XTotalLiquidar"))

            'Firmas
            oReporte.SetParameterValue("Vendedor", oMensaje.RecuperarDescripcion("XVendedor"))

            'Pie de Pagina
            oReporte.SetParameterValue("FechaHoraImpresion", oMensaje.RecuperarDescripcion("XFechaHoraImpresion"))

            '-------- Llenado de Parámetros del Reporte 40 ------

        ElseIf Session("NumReporte") = 40 Then 'Activos Bajo Cero

            If Session("TipoReporte") = "Asignados" Then
                oReporte.FileName = Server.MapPath("Reports\ReporteActivoBajoCeroA.rpt")
                'Session("Nombre") = Session("Nombre") & " - " & oMensaje.RecuperarDescripcion("XAsignados")
            ElseIf Session("TipoReporte") = "NoAsignados" Then
                oReporte.FileName = Server.MapPath("Reports\ReporteActivoBajoCeroNA.rpt")
                'Session("Nombre") = Session("Nombre") & " - " & oMensaje.RecuperarDescripcion("XNoAsignados")
            ElseIf Session("TipoReporte") = "PorFiltro" Then
                oReporte.FileName = Server.MapPath("Reports\ReporteActivoBajoCeroPF.rpt")
            End If

            oReporte.Database.Tables(0).SetDataSource(dt)
            dt = CType(Session("DataTable"), System.Data.DataTable)
            oReporte.Database.Tables(1).SetDataSource(dt)

            oReporte.SetParameterValue("Nombre", Session("Nombre").ToString().ToUpper()) '''''''''''''****<----Nombre por filtros
            If Session("TipoReporte") = "Asignados" Then
                oReporte.SetParameterValue("EnviadoCEDI", Session("CEDI"))
                oReporte.SetParameterValue("Enviadovendedor", Session("Vendedor"))
                oReporte.SetParameterValue("Enviadaruta", Session("Ruta"))
                oReporte.SetParameterValue("EnviadoCliente", Session("FiltroClientes"))

                oReporte.SetParameterValue("CentroDistribucion", oMensaje.RecuperarDescripcion("XCentroDistribucion"))
                oReporte.SetParameterValue("Vendedor", oMensaje.RecuperarDescripcion("XVendedor"))
                oReporte.SetParameterValue("Ruta", oMensaje.RecuperarDescripcion("Xruta"))
                oReporte.SetParameterValue("Cliente", oMensaje.RecuperarDescripcion("XCliente"))
            End If

            oReporte.SetParameterValue("ActivoClave", oMensaje.RecuperarDescripcion("ACIActivoClave"))
            oReporte.SetParameterValue("NombreActivo", oMensaje.RecuperarDescripcion("XNombre"))
            oReporte.SetParameterValue("Tipo", oMensaje.RecuperarDescripcion("ACITipo"))
            oReporte.SetParameterValue("IdElectronico", oMensaje.RecuperarDescripcion("ACIIdElectronico"))
            oReporte.SetParameterValue("Altura", oMensaje.RecuperarDescripcion("ACIAltura"))
            oReporte.SetParameterValue("Ancho", oMensaje.RecuperarDescripcion("ACIAncho"))
            oReporte.SetParameterValue("Profundidad", oMensaje.RecuperarDescripcion("ACIProfundidad"))
            oReporte.SetParameterValue("TipoFase", oMensaje.RecuperarDescripcion("ACITipoFase"))
            oReporte.SetParameterValue("TipoEstado", oMensaje.RecuperarDescripcion("ACITipoEstado"))
            oReporte.SetParameterValue("UltimoServicio", oMensaje.RecuperarDescripcion("XUltimoServicio"))

            If Session("TipoReporte") = "PorFiltro" Then
                oReporte.SetParameterValue("AsignadoA", oMensaje.RecuperarDescripcion("XAsignadoA"))
                oReporte.SetParameterValue("Ruta", oMensaje.RecuperarDescripcion("Xruta"))
                oReporte.SetParameterValue("TotalActivosTipo", oMensaje.RecuperarDescripcion("XTotalActivosTipo"))
                oReporte.SetParameterValue("TotalAsignados", oMensaje.RecuperarDescripcion("XTotalActivosAsignados"))
                oReporte.SetParameterValue("TotalNoAsignados", oMensaje.RecuperarDescripcion("XTotalActivosNoAsignados"))
            End If

            If Session("TipoReporte") = "Asignados" Then
                oReporte.SetParameterValue("TotalCliente", oMensaje.RecuperarDescripcion("XTotalActivosCliente"))
                oReporte.SetParameterValue("TotalRuta", oMensaje.RecuperarDescripcion("XTotalActivosRuta"))
                oReporte.SetParameterValue("TotalVendedor", oMensaje.RecuperarDescripcion("XTotalActivosVendedor"))
                oReporte.SetParameterValue("TotalCEDI", oMensaje.RecuperarDescripcion("XTotalActivosCEDI"))
            End If

            If Session("TipoReporte") = "NoAsignados" Then
                oReporte.SetParameterValue("TotalActivosTipo", oMensaje.RecuperarDescripcion("XTotalActivosTipo"))
            End If

            oReporte.SetParameterValue("FechaHoraImpresion", oMensaje.RecuperarDescripcion("Xfechahoraimpresion"))


        ElseIf Session("NumReporte") = 41 Then 'Mercadeo Bajo Cero
            oReporte.FileName = Server.MapPath("Reports\ReporteMercadeoBajoCero.rpt")

            oReporte.Database.Tables(0).SetDataSource(dt)
            oReporte.Database.Tables(1).SetDataSource(Session("DataTable"))

            oReporte.SetParameterValue("Nombre", Session("Nombre").ToString().ToUpper())
            oReporte.SetParameterValue("CentroDistribucion", oMensaje.RecuperarDescripcion("XCentroDistribucion"))
            oReporte.SetParameterValue("Vendedor", oMensaje.RecuperarDescripcion("XVendedor"))
            oReporte.SetParameterValue("Ruta", oMensaje.RecuperarDescripcion("XRuta"))
            oReporte.SetParameterValue("Cliente", oMensaje.RecuperarDescripcion("XCliente"))
            oReporte.SetParameterValue("Fecha", oMensaje.RecuperarDescripcion("XFecha"))

            'oReporte.SetParameterValue("ParCentroDistribucion", Session("CEDI"))
            oReporte.SetParameterValue("ParVendedor", Session("Vendedor"))
            oReporte.SetParameterValue("ParRuta", Session("Ruta"))
            oReporte.SetParameterValue("ParCliente", Session("FiltroClientes"))
            oReporte.SetParameterValue("ParFecha", Session("RangoFechas"))

            oReporte.SetParameterValue("Producto", oMensaje.RecuperarDescripcion("XProducto"))
            oReporte.SetParameterValue("Tipo", oMensaje.RecuperarDescripcion("XTipo"))
            oReporte.SetParameterValue("Presentacion", oMensaje.RecuperarDescripcion("XPresentacion"))
            oReporte.SetParameterValue("Ubicacion", oMensaje.RecuperarDescripcion("XUbicacion"))
            oReporte.SetParameterValue("Proveedor", oMensaje.RecuperarDescripcion("XProveedor"))
            oReporte.SetParameterValue("VentaAnterior", oMensaje.RecuperarDescripcion("XVentaAnterior"))
            oReporte.SetParameterValue("Cantidad", oMensaje.RecuperarDescripcion("XCantidad"))
            oReporte.SetParameterValue("Precio", oMensaje.RecuperarDescripcion("XPrecio"))
            oReporte.SetParameterValue("Total", oMensaje.RecuperarDescripcion("XTotal"))

            oReporte.SetParameterValue("TotalCEDI", oMensaje.RecuperarDescripcion("XTotalPorCEDI"))
            oReporte.SetParameterValue("TotalVendedor", oMensaje.RecuperarDescripcion("XTotalPorVendedor"))
            oReporte.SetParameterValue("TotalRuta", oMensaje.RecuperarDescripcion("XTotalPorRuta"))
            oReporte.SetParameterValue("TotalCliente", oMensaje.RecuperarDescripcion("XTotalPorCliente"))
            oReporte.SetParameterValue("TotalFecha", oMensaje.RecuperarDescripcion("XTotalPorFecha"))

            oReporte.SetParameterValue("FechaHoraImpresion", oMensaje.RecuperarDescripcion("XFechahoraImpresion"))

        ElseIf Session("NumReporte") = 42 Then '--Tiempos en ruta (Mayoreo Cardenas)

            oReporte.FileName = Server.MapPath("Reports\ReporteTiemposRutaMayoreo.rpt")

            oReporte.Database.Tables(0).SetDataSource(Session("DataTable"))
            oReporte.Database.Tables(1).SetDataSource(dt)

            If (IsNothing(Session("subreport0"))) Then
                Session("subreport0") = ins.EjecutarConsulta(Session("Query2"), IntCommandTimeOut)
            End If
            oReporte.Subreports(0).Database.Tables(0).SetDataSource(Session("subreport0"))

            If (IsNothing(Session("subreport1"))) Then
                Session("subreport1") = ins.EjecutarConsulta(Session("Query3"), IntCommandTimeOut)
            End If
            oReporte.Subreports(1).Database.Tables(0).SetDataSource(Session("subreport1"))


            oReporte.SetParameterValue("Nombre", Session("Nombre").ToString().ToUpper()) '''''''''''''****<----Nombre por filtros

            oReporte.SetParameterValue("XSecuencia", oMensaje.RecuperarDescripcion("SECSEC"))
            oReporte.SetParameterValue("XClienteClave", oMensaje.RecuperarDescripcion("CLIClave"))
            oReporte.SetParameterValue("XCodigoNoLeido", oMensaje.RecuperarDescripcion("XCodigoNoLeido"))
            oReporte.SetParameterValue("XNombreCliente", oMensaje.RecuperarDescripcion("CLICliente") + " - " + oMensaje.RecuperarDescripcion("xcontacto"))
            oReporte.SetParameterValue("XMinutosTransito", oMensaje.RecuperarDescripcion("XTiempoTransito"))
            oReporte.SetParameterValue("XHoraInicio", oMensaje.RecuperarDescripcion("VISHRFIN"))
            oReporte.SetParameterValue("XHoraFin", oMensaje.RecuperarDescripcion("VISHRINI"))
            oReporte.SetParameterValue("XMinutosVisita", oMensaje.RecuperarDescripcion("XTiempoVisita"))
            oReporte.SetParameterValue("XVenta", oMensaje.RecuperarDescripcion("XVENTA"))
            oReporte.SetParameterValue("XConcepto", oMensaje.RecuperarDescripcion("XConcepto"))
            oReporte.SetParameterValue("XVentaTotal", oMensaje.RecuperarDescripcion("XVentaTotal"))
            oReporte.SetParameterValue("XRuta", oMensaje.RecuperarDescripcion("XRuta"))
            oReporte.SetParameterValue("XInicioRecorrido", oMensaje.RecuperarDescripcion("XInicioRecorrido"))
            oReporte.SetParameterValue("XFinRecorrido", oMensaje.RecuperarDescripcion("XFinRecorrido"))


            oReporte.SetParameterValue("XVisitados", oMensaje.RecuperarDescripcion("XVisitados"))
            oReporte.SetParameterValue("XNoVisitados", oMensaje.RecuperarDescripcion("XNoVisitados"))

            oReporte.SetParameterValue("XTotalClientes", oMensaje.RecuperarDescripcion("XTotalClientes"))
            oReporte.SetParameterValue("XTiempoTransito", oMensaje.RecuperarDescripcion("XTiempoTransito"))
            oReporte.SetParameterValue("XTiempoRecorrido", oMensaje.RecuperarDescripcion("XTiempoRecorrido"))
            oReporte.SetParameterValue("XTiempoTransito", oMensaje.RecuperarDescripcion("XTiempoTransito"))
            oReporte.SetParameterValue("XEfectividadCompra", oMensaje.RecuperarDescripcion("XEfectividadCompra"))
            oReporte.SetParameterValue("XTotalCodigoNoLeido", oMensaje.RecuperarDescripcion("XTotalCodigoNoLeido"))

            oReporte.SetParameterValue("XVisitasSinVenta", oMensaje.RecuperarDescripcion("XVisitasSinVenta"))
            oReporte.SetParameterValue("XVisitaEfectiva", oMensaje.RecuperarDescripcion("XVisitaEfectiva"))
            oReporte.SetParameterValue("XTiempoPromedio", oMensaje.RecuperarDescripcion("XTiempoPromedio"))
            oReporte.SetParameterValue("XTiempoVisita", oMensaje.RecuperarDescripcion("XTiempoVisita"))

            oReporte.SetParameterValue("Fecha", oMensaje.RecuperarDescripcion("XFecha") + "")
            oReporte.SetParameterValue("Vendedor", oMensaje.RecuperarDescripcion("XVendedor"))
            oReporte.SetParameterValue("Ruta", oMensaje.RecuperarDescripcion("Xruta"))

            oReporte.SetParameterValue("Enviadovendedor", Session("Vendedor"))
            oReporte.SetParameterValue("Enviadaruta", Session("Ruta"))
            oReporte.SetParameterValue("Enviadafecha", Session("RangoFechas"))
            oReporte.SetParameterValue("CentroDistribucion", oMensaje.RecuperarDescripcion("XCentroDistribucion"))
            oReporte.SetParameterValue("FechaHoraImpresion", oMensaje.RecuperarDescripcion("Xfechahoraimpresion"))

            oReporte.SetParameterValue("XClientesEnAgenda", oMensaje.RecuperarDescripcion("XClientesEnAgenda"))
            oReporte.SetParameterValue("XClientesFueraAgenda", oMensaje.RecuperarDescripcion("XClientesFueraAgenda"))

            oReporte.SetParameterValue("NUMVisitados", oMensaje.RecuperarDescripcion("XVisitados"))
            oReporte.SetParameterValue("NUMNoVisitados", oMensaje.RecuperarDescripcion("XNoVisitados"))
            oReporte.SetParameterValue("NUMTotalClientes", oMensaje.RecuperarDescripcion("XTotalClientes"))
            oReporte.SetParameterValue("VisitaEfectiva", oMensaje.RecuperarDescripcion("XVisitaEfectiva"))
            oReporte.SetParameterValue("EfectividadCompra", oMensaje.RecuperarDescripcion("XEfectividadCompra"))
            oReporte.SetParameterValue("VisitasSinVenta", oMensaje.RecuperarDescripcion("XVisitasSinVenta"))

            oReporte.SetParameterValue("NUMVisitados2", oMensaje.RecuperarDescripcion("XVisitados"))
            oReporte.SetParameterValue("EfectividadCompra2", oMensaje.RecuperarDescripcion("XEfectividadCompra"))
            oReporte.SetParameterValue("VisitasSinVenta2", oMensaje.RecuperarDescripcion("XVisitasSinVenta"))
        ElseIf Session("NumReporte") = 43 Then '--Facturacion Electronica

            oReporte.FileName = Server.MapPath("Reports\ReporteFacturacionElectronica.rpt")

            oReporte.Database.Tables("Configuracion").SetDataSource(dt)
            oReporte.Database.Tables("FacturacionElectronica").SetDataSource(Session("DataTable"))


            oReporte.SetParameterValue("Enviadovendedor", Session("Vendedor"))
            oReporte.SetParameterValue("NombreRep", Session("Nombre").ToString().ToUpper())
            oReporte.SetParameterValue("Cedi", oMensaje.RecuperarDescripcion("XCentroDistribucion"))
            oReporte.SetParameterValue("Fecha", oMensaje.RecuperarDescripcion("XFECHA"))
            oReporte.SetParameterValue("Vendedor", oMensaje.RecuperarDescripcion("XVendedor"))
            oReporte.SetParameterValue("Serie", oMensaje.RecuperarDescripcion("FOSSerie"))
            oReporte.SetParameterValue("Folio", oMensaje.RecuperarDescripcion("XFolio"))
            oReporte.SetParameterValue("Cliente", oMensaje.RecuperarDescripcion("XCliente"))
            oReporte.SetParameterValue("RFC", oMensaje.RecuperarDescripcion("CLDRFC"))
            oReporte.SetParameterValue("AnioAprobacion", oMensaje.RecuperarDescripcion("XAnioAprobacion"))
            oReporte.SetParameterValue("Aprobacion", oMensaje.RecuperarDescripcion("XAprobacion"))
            oReporte.SetParameterValue("Total", oMensaje.RecuperarDescripcion("XTotal"))
            oReporte.SetParameterValue("enviadoFecha", Session("RangoFechas"))
            oReporte.SetParameterValue("NumCertificado", oMensaje.RecuperarDescripcion("XNoCertificado"))
            oReporte.SetParameterValue("FechaHoraImpresion", oMensaje.RecuperarDescripcion("Xfechahoraimpresion"))
            oReporte.SetParameterValue("FechaHoraImpresion", oMensaje.RecuperarDescripcion("Xfechahoraimpresion"))
            oReporte.SetParameterValue("Motivo", oMensaje.RecuperarDescripcion("TRPTipoMotivo"))
            oReporte.SetParameterValue("Fase", oMensaje.RecuperarDescripcion("TRPTipoFase"))
            oReporte.SetParameterValue("Error", oMensaje.RecuperarDescripcion("XError"))


            oReporte.SetParameterValue("TotalCEDI", oMensaje.RecuperarDescripcion("XTotalPorCEDI"))
            oReporte.SetParameterValue("TotalVendedor", oMensaje.RecuperarDescripcion("XTotalSolicitudesVendedor"))
            oReporte.SetParameterValue("TotalFecha", oMensaje.RecuperarDescripcion("XTotalSolicitudesFecha"))
            oReporte.SetParameterValue("GranTotal", oMensaje.RecuperarDescripcion("XGRANTOTAL"))

        ElseIf Session("NumReporte") = 44 Then ' Ventas con Saldo

            oReporte.FileName = Server.MapPath("Reports\ReporteVentasSaldo.rpt")


            oReporte.Database.Tables("Configuracion").SetDataSource(dt)

            dt = CType(Session("DataTable"), System.Data.DataTable)
            oReporte.Database.Tables("VentasSaldos").SetDataSource(dt)


            oReporte.SetParameterValue("EnviadoCEDI", Session("CEDI"))
            oReporte.SetParameterValue("Enviadovendedor", Session("Vendedor"))
            oReporte.SetParameterValue("Enviadaruta", Session("Ruta"))
            oReporte.SetParameterValue("Enviadafecha", Session("RangoFechas"))

            oReporte.SetParameterValue("XNombreTitulo", Session("Nombre").ToString().ToUpper()) '''''''''''''****<----Nombre por filtros
            oReporte.SetParameterValue("CentroDistribucion", oMensaje.RecuperarDescripcion("XCentroDistribucion"))
            oReporte.SetParameterValue("XFecha", oMensaje.RecuperarDescripcion("XFECHA"))
            oReporte.SetParameterValue("XVendedor", oMensaje.RecuperarDescripcion("XVendedor"))
            oReporte.SetParameterValue("XRuta", oMensaje.RecuperarDescripcion("Xruta"))
            oReporte.SetParameterValue("XFactura", oMensaje.RecuperarDescripcion("XFacturas"))
            oReporte.SetParameterValue("XGranTotal", oMensaje.RecuperarDescripcion("XGranTotal"))
            oReporte.SetParameterValue("XGranTotalCentroDistribucion", oMensaje.RecuperarDescripcion("XGranTotalCentroDistribucion"))
            oReporte.SetParameterValue("XSaldo", oMensaje.RecuperarDescripcion("ABNSaldo"))

            oReporte.SetParameterValue("FechaHoraImpresion", oMensaje.RecuperarDescripcion("Xfechahoraimpresion"))
            oReporte.SetParameterValue("XCliente", oMensaje.RecuperarDescripcion("XCliente"))
            oReporte.SetParameterValue("XClienteClave", oMensaje.RecuperarDescripcion("CLIClienteClave"))
            oReporte.SetParameterValue("XFolio", oMensaje.RecuperarDescripcion("XFolio"))
            oReporte.SetParameterValue("XFecha", oMensaje.RecuperarDescripcion("XFecha"))

            oReporte.SetParameterValue("XImporte", oMensaje.RecuperarDescripcion("XImporte"))

        ElseIf Session("NumReporte") = 45 Then 'Reporte de Ventas por Esquema (Panque)

            If Session("ConversionKg") Then
                oReporte.FileName = Server.MapPath("Reports\ReporteVentasEsquemaPanqueKg.rpt")
                oReporte.Database.Tables("VentaEsquemaKg").SetDataSource(Session("DataTable"))
            Else
                oReporte.FileName = Server.MapPath("Reports\ReporteVentaEsquemaPanque.rpt")
                oReporte.Database.Tables("VentaEsquema").SetDataSource(Session("DataTable"))
            End If

            'oReporte.FileName = Server.MapPath("Reports\ReporteVentaEsquema.rpt")
            oReporte.Database.Tables("Configuracion").SetDataSource(dt)


            If (Session("TipoReporte") = "Detallado") Then
                oReporte.SetParameterValue("Detallado", 1)
            Else
                oReporte.SetParameterValue("Detallado", 0)
            End If
            If Session("ConversionKg") Then
                oReporte.SetParameterValue("KgLt", oMensaje.RecuperarDescripcion("XKgLt"))
                oReporte.SetParameterValue("resumen3", oMensaje.RecuperarDescripcion("Xresumendekilolitros"))
            End If
            oReporte.SetParameterValue("nombre", Session("Nombre").ToString().ToUpper()) '''''''''''''****<----Nombre por filtros)
            oReporte.SetParameterValue("fecha", oMensaje.RecuperarDescripcion("Xfecha"))
            'oReporte.SetParameterValue("vendedor", oMensaje.RecuperarDescripcion("Xvendedor"))
            oReporte.SetParameterValue("unidad", oMensaje.RecuperarDescripcion("Xunidad"))
            oReporte.SetParameterValue("venta", oMensaje.RecuperarDescripcion("Xventam"))
            oReporte.SetParameterValue("ruta", oMensaje.RecuperarDescripcion("Xruta"))
            oReporte.SetParameterValue("cant", oMensaje.RecuperarDescripcion("Xcantidad"))
            oReporte.SetParameterValue("$", oMensaje.RecuperarDescripcion("X$"))
            oReporte.SetParameterValue("devolucion", oMensaje.RecuperarDescripcion("Xdevolucion"))
            oReporte.SetParameterValue("cambio", oMensaje.RecuperarDescripcion("Xcambio"))
            oReporte.SetParameterValue("resumen1", oMensaje.RecuperarDescripcion("Xresumendeunidades"))
            oReporte.SetParameterValue("resumen2", oMensaje.RecuperarDescripcion("Xresumendeimportes"))
            oReporte.SetParameterValue("total", oMensaje.RecuperarDescripcion("Xtotal"))
            oReporte.SetParameterValue("grantotal", oMensaje.RecuperarDescripcion("Xgrantotal"))
            oReporte.SetParameterValue("clave", oMensaje.RecuperarDescripcion("Xclave"))
            oReporte.SetParameterValue("producto", oMensaje.RecuperarDescripcion("Xproducto"))
            oReporte.SetParameterValue("ventas", oMensaje.RecuperarDescripcion("XVentas"))
            oReporte.SetParameterValue("devoluciones", oMensaje.RecuperarDescripcion("XDevoluciones"))
            oReporte.SetParameterValue("cambios", oMensaje.RecuperarDescripcion("XCambios"))
            oReporte.SetParameterValue("unidades", oMensaje.RecuperarDescripcion("XUnidades"))
            oReporte.SetParameterValue("Enviadaruta", Session("Ruta"))
            oReporte.SetParameterValue("FechaHoraImpresion", oMensaje.RecuperarDescripcion("XFechaHoraImpresion"))
            oReporte.SetParameterValue("CentroDistribucion", oMensaje.RecuperarDescripcion("XCentroDistribucion"))
            oReporte.SetParameterValue("Enviadafecha", Session("RangoFechas"))
        ElseIf Session("NumReporte") = 46 Then 'Reporte de Clientes por Ruta (Panque)
            oReporte.FileName = Server.MapPath("Reports\ReporteClientesRutaPanque.rpt")
            oReporte.Database.Tables("ClientesRutaPanque").SetDataSource(Session("DataTable"))
            oReporte.Database.Tables("Configuracion").SetDataSource(dt)

            oReporte.SetParameterValue("nombre", Session("Nombre").ToString().ToUpper()) '''''''''''''****<----Nombre por filtros)
            oReporte.SetParameterValue("CentroDistribucion", oMensaje.RecuperarDescripcion("XCentroDistribucion"))
            oReporte.SetParameterValue("vendedor", oMensaje.RecuperarDescripcion("Xvendedor"))
            oReporte.SetParameterValue("ruta", oMensaje.RecuperarDescripcion("Xruta"))
            oReporte.SetParameterValue("fecha", oMensaje.RecuperarDescripcion("Xfecha"))
            oReporte.SetParameterValue("Enviadovendedor", Session("Vendedor"))
            oReporte.SetParameterValue("Enviadafecha", Session("RangoFechas"))
            oReporte.SetParameterValue("Enviadaruta", Session("Ruta"))
            oReporte.SetParameterValue("orden", oMensaje.RecuperarDescripcion("XOrden"))
            oReporte.SetParameterValue("clave", oMensaje.RecuperarDescripcion("Xclave"))
            oReporte.SetParameterValue("razonsocial", oMensaje.RecuperarDescripcion("XRazonSocial"))
            oReporte.SetParameterValue("contacto", oMensaje.RecuperarDescripcion("XContacto"))
            oReporte.SetParameterValue("domicilio", oMensaje.RecuperarDescripcion("XDomicilio"))
            oReporte.SetParameterValue("colonia", oMensaje.RecuperarDescripcion("XColonia"))
            oReporte.SetParameterValue("telefono", oMensaje.RecuperarDescripcion("XTelefono"))
            oReporte.SetParameterValue("poblacion", oMensaje.RecuperarDescripcion("XPoblacion"))
            oReporte.SetParameterValue("entidad", oMensaje.RecuperarDescripcion("XEntidad"))
            oReporte.SetParameterValue("FechaHoraImpresion", oMensaje.RecuperarDescripcion("XFechaHoraImpresion"))

        ElseIf Session("NumReporte") = 47 Then ' Consignacion
            If Session("TipoReporte") = "Detallado" Then
                If Session("ConversionKg") Then
                    oReporte.FileName = Server.MapPath("Reports\ReporteConsignacionDetKg.rpt")
                Else
                    oReporte.FileName = Server.MapPath("Reports\ReporteConsignacionDet.rpt")
                End If
            ElseIf Session("TipoReporte") = "General" Then
                If Session("ConversionKg") Then
                    oReporte.FileName = Server.MapPath("Reports\ReporteConsignacionGenKg.rpt")
                Else
                    oReporte.FileName = Server.MapPath("Reports\ReporteConsignacionGen.rpt")
                End If
            End If

            oReporte.Database.Tables(0).SetDataSource(dt)

            dt = Session("DataTable")
            oReporte.Database.Tables(1).SetDataSource(dt)


            If Session("TipoReporte") = "Detallado" Then
                If IsNothing(Session("subreportD0")) Then
                    Session("subreportD0") = ins.EjecutarConsulta(Session("QueryD1"), IntCommandTimeOut)
                End If
                dt = Session("subreportD0")
                oReporte.Subreports("CobranzaEfectuada").Database.Tables(0).SetDataSource(dt)

                If IsNothing(Session("subreportD1")) Then
                    Session("subreportD1") = ins.EjecutarConsulta(Session("QueryD2"), IntCommandTimeOut)
                End If
                dt = Session("subreportD1")
                oReporte.Subreports("Detalle3").Database.Tables(0).SetDataSource(dt)
            Else 'General
                If IsNothing(Session("subreportG0")) Then
                    Session("subreportG0") = ins.EjecutarConsulta(Session("QueryG1"), IntCommandTimeOut)
                End If
                dt = Session("subreportG0")
                oReporte.Subreports("Detalle3").Database.Tables(0).SetDataSource(dt)
            End If


            oReporte.SetParameterValue("NOMBRE", Session("Nombre").ToString().ToUpper()) '''''''''''''****<----Nombre por filtros

            oReporte.SetParameterValue("CentroDistribucion", oMensaje.RecuperarDescripcion("XCentroDistribucion"))
            oReporte.SetParameterValue("FECHA", oMensaje.RecuperarDescripcion("XFECHA"))
            oReporte.SetParameterValue("VENDEDOR", oMensaje.RecuperarDescripcion("XVendedor"))
            oReporte.SetParameterValue("RUTA", oMensaje.RecuperarDescripcion("Xruta"))

            oReporte.SetParameterValue("EnviadoCEDI", Session("CEDI"))
            oReporte.SetParameterValue("Enviadovendedor", Session("Vendedor"))
            oReporte.SetParameterValue("Enviadaruta", Session("Ruta"))
            oReporte.SetParameterValue("Enviadafecha", Session("RangoFechas"))
            oReporte.SetParameterValue("enviadocliente", Session("FiltroClientes"))

            If Session("TipoReporte") = "Detallado" Then
                oReporte.SetParameterValue("CLAVE", oMensaje.RecuperarDescripcion("XCLAVE"))
                oReporte.SetParameterValue("PRODUCTO", oMensaje.RecuperarDescripcion("XPRODUCTO"))
                oReporte.SetParameterValue("UNIDAD", oMensaje.RecuperarDescripcion("XUNIDAD"))
                oReporte.SetParameterValue("PRECIO", oMensaje.RecuperarDescripcion("XP.U."))
                oReporte.SetParameterValue("CANT", oMensaje.RecuperarDescripcion("Xcantidad"))
                oReporte.SetParameterValue("SUBTOTAL", oMensaje.RecuperarDescripcion("XSUBTOTAL"))
                If Session("ConversionKg") Then
                    oReporte.SetParameterValue("KGLTS", oMensaje.RecuperarDescripcion("XKiloLitros"))
                End If
                oReporte.SetParameterValue("IMPUESTO", oMensaje.RecuperarDescripcion("XIMPUESTO"))
                oReporte.SetParameterValue("TOTAL", oMensaje.RecuperarDescripcion("XTOTALMIN"))

                oReporte.SetParameterValue("CobranzaEfectuada", oMensaje.RecuperarDescripcion("XCobranzaEfectuada"), "CobranzaEfectuada")
                oReporte.SetParameterValue("SaldoInicial", oMensaje.RecuperarDescripcion("XSaldoInicial"), "CobranzaEfectuada")
                oReporte.SetParameterValue("Devoluciones", oMensaje.RecuperarDescripcion("XDevoluciones"), "CobranzaEfectuada")
                oReporte.SetParameterValue("SaldoPendiente", oMensaje.RecuperarDescripcion("XSaldoPendiente"), "CobranzaEfectuada")
            Else 'General
                oReporte.SetParameterValue("FOLIO", oMensaje.RecuperarDescripcion("XFOLIO"))
                oReporte.SetParameterValue("CLAVE", oMensaje.RecuperarDescripcion("XCLAVE"))

                oReporte.SetParameterValue("TOTAL", oMensaje.RecuperarDescripcion("XTOTALMIN"))
            End If
            oReporte.SetParameterValue("CLIENTE", oMensaje.RecuperarDescripcion("XCLIENTE"))
            oReporte.SetParameterValue("ConsignacionesPorProducto", oMensaje.RecuperarDescripcion("XConsignacionesPorProducto"), "Detalle3")
            oReporte.SetParameterValue("ProductoClave", oMensaje.RecuperarDescripcion("XCLAVE"), "Detalle3")
            oReporte.SetParameterValue("ProductoNombre", oMensaje.RecuperarDescripcion("XPRODUCTO"), "Detalle3")
            oReporte.SetParameterValue("TipoUnidad", oMensaje.RecuperarDescripcion("XUNIDAD"), "Detalle3")
            oReporte.SetParameterValue("Cantidad", oMensaje.RecuperarDescripcion("Xcantidad"), "Detalle3")
            If Session("ConversionKg") Then
                oReporte.SetParameterValue("KgLts", oMensaje.RecuperarDescripcion("XKiloLitros"), "Detalle3")
            End If
            oReporte.SetParameterValue("Total", oMensaje.RecuperarDescripcion("XTOTAL"), "Detalle3")

            oReporte.SetParameterValue("TotalRuta", oMensaje.RecuperarDescripcion("XTotalRuta"))
            oReporte.SetParameterValue("TotalFecha", oMensaje.RecuperarDescripcion("XTotalFecha"))
            oReporte.SetParameterValue("TotalVendedor", oMensaje.RecuperarDescripcion("XTotalVendedor"))
            oReporte.SetParameterValue("TotalCentroDistribucion", oMensaje.RecuperarDescripcion("Xtotalcentrodistribucion"))
            oReporte.SetParameterValue("TotalFolios", oMensaje.RecuperarDescripcion("XTotalFolios"))
            If Session("TipoReporte") = "Detallado" Then
                oReporte.SetParameterValue("TotalProductos", oMensaje.RecuperarDescripcion("XTotalProductos"))
            Else
                oReporte.SetParameterValue("TotalProductos", oMensaje.RecuperarDescripcion("XTotalProductos"), "Detalle3")
            End If

            If Session("ConversionKg") Then
                oReporte.SetParameterValue("TotalKiloLitros", oMensaje.RecuperarDescripcion("XTotalKiloLitros"))
            End If
            oReporte.SetParameterValue("TotalConsignado", oMensaje.RecuperarDescripcion("XTotalConsignado"))

            oReporte.SetParameterValue("FechaHoraImpresion", oMensaje.RecuperarDescripcion("Xfechahoraimpresion"))

        ElseIf Session("NumReporte") = 48 Then 'Liquidacion Poblana
            'Principal
            oReporte.FileName = Server.MapPath("Reports\ReporteLiquidacionPoblana.rpt")
            oReporte.Database.Tables("Configuracion").SetDataSource(dt)
            dt = CType(Session("Vendedores"), System.Data.DataTable)
            oReporte.Database.Tables("Vendedores").SetDataSource(dt)

            'Subreportes
            dt = ins.EjecutarConsulta(Session("Movimientos"), IntCommandTimeOut)
            oReporte.Subreports("Movimientos").Database.Tables("Movimientos").SetDataSource(dt)
            dt = ins.EjecutarConsulta(Session("VentasContado"), IntCommandTimeOut)
            oReporte.Subreports("VentasContado").Database.Tables("Ventas").SetDataSource(dt)
            dt = ins.EjecutarConsulta(Session("VentasCredito"), IntCommandTimeOut)
            oReporte.Subreports("VentasCredito").Database.Tables("Ventas").SetDataSource(dt)
            dt = ins.EjecutarConsulta(Session("VentasConsignacion"), IntCommandTimeOut)
            oReporte.Subreports("VentasConsignacion").Database.Tables("Ventas").SetDataSource(dt)
            dt = ins.EjecutarConsulta(Session("Desglose"), IntCommandTimeOut)
            oReporte.Subreports("Desglose").Database.Tables("Denominacion").SetDataSource(dt)

            'Principal
            oReporte.SetParameterValue("NombreRep", Session("Nombre").ToString().ToUpper())
            oReporte.SetParameterValue("EnviadoFecha", Session("RangoFechas"))
            oReporte.SetParameterValue("EnviadoVendedor", Session("Vendedor"))
            oReporte.SetParameterValue("EnviadoCEDI", Session("CEDI"))
            oReporte.SetParameterValue("XFecha", oMensaje.RecuperarDescripcion("XFecha"))
            oReporte.SetParameterValue("XCedi", oMensaje.RecuperarDescripcion("XCentroDistribucion"))
            oReporte.SetParameterValue("FechaHoraImpresion", oMensaje.RecuperarDescripcion("Xfechahoraimpresion"))
            oReporte.SetParameterValue("XVendedor", oMensaje.RecuperarDescripcion("XVendedor"))
            oReporte.SetParameterValue("XRecargasIncCar", oMensaje.RecuperarDescripcion("XRecargasIncCar"))

            'Preliquidacion
            oReporte.SetParameterValue("XPreliquidacion", oMensaje.RecuperarDescripcion("XPreliquidacion"))
            oReporte.SetParameterValue("XVtaTotalProd", oMensaje.RecuperarDescripcion("XVtaTotalProd"))
            oReporte.SetParameterValue("XMenosVtaCredito", oMensaje.RecuperarDescripcion("XMenosVtaCredito"))
            oReporte.SetParameterValue("XMenosVtaConsignacion", oMensaje.RecuperarDescripcion("XMenosVtaConsignacion"))
            oReporte.SetParameterValue("XMasCobranza", oMensaje.RecuperarDescripcion("XMasCobranza"))
            oReporte.SetParameterValue("XTotalLiquidar", oMensaje.RecuperarDescripcion("XTotalLiquidar"))

            'Movimientos
            oReporte.SetParameterValue("XProductoClave", oMensaje.RecuperarDescripcion("XClave"))
            oReporte.SetParameterValue("XPRONombre", oMensaje.RecuperarDescripcion("XDescripcion"))
            oReporte.SetParameterValue("XInvInicial", oMensaje.RecuperarDescripcion("XInvInicial"))
            oReporte.SetParameterValue("XCambioEnt", oMensaje.RecuperarDescripcion("XCambioEnt"))
            oReporte.SetParameterValue("XCambioSal", oMensaje.RecuperarDescripcion("XCambioSal"))
            oReporte.SetParameterValue("XConsignacion", oMensaje.RecuperarDescripcion("XConsignacion"))
            oReporte.SetParameterValue("XDevolucionCons", oMensaje.RecuperarDescripcion("XDevConsignacion"))
            oReporte.SetParameterValue("XPromocion", oMensaje.RecuperarDescripcion("XPromocion"))
            oReporte.SetParameterValue("XDescarga", oMensaje.RecuperarDescripcion("XDescargaAlm"))
            oReporte.SetParameterValue("XVenta", oMensaje.RecuperarDescripcion("XVentas"))
            oReporte.SetParameterValue("XImporte", oMensaje.RecuperarDescripcion("XImporte"))
            oReporte.SetParameterValue("XInvFinal", oMensaje.RecuperarDescripcion("XInvFinal"))
            oReporte.SetParameterValue("XMovimientos", oMensaje.RecuperarDescripcion("XMovProductos"))
            oReporte.SetParameterValue("XTotales", oMensaje.RecuperarDescripcion("XTotales"))

            'Ventas Contado
            oReporte.SetParameterValue("XVtaContado", oMensaje.RecuperarDescripcion("XVtaContado"))
            oReporte.SetParameterValue("XVentaVC", oMensaje.RecuperarDescripcion("XVenta"))
            oReporte.SetParameterValue("XFechaVC", oMensaje.RecuperarDescripcion("XFecha"))
            oReporte.SetParameterValue("XClienteVC", oMensaje.RecuperarDescripcion("XCliente"))
            oReporte.SetParameterValue("XImporteVC", oMensaje.RecuperarDescripcion("XImporte"))
            oReporte.SetParameterValue("XTotalVtaCon", oMensaje.RecuperarDescripcion("XTotalVtaContado"))
            oReporte.SetParameterValue("XCanceladoContado", oMensaje.RecuperarDescripcion("XCancelada"))


            'Ventas Credito
            oReporte.SetParameterValue("XVtaCredito", oMensaje.RecuperarDescripcion("XVtaCredito"))
            oReporte.SetParameterValue("XVentaVCr", oMensaje.RecuperarDescripcion("XVenta"))
            oReporte.SetParameterValue("XFechaVCr", oMensaje.RecuperarDescripcion("XFecha"))
            oReporte.SetParameterValue("XClienteVCr", oMensaje.RecuperarDescripcion("XCliente"))
            oReporte.SetParameterValue("XImporteVCr", oMensaje.RecuperarDescripcion("XImporte"))
            oReporte.SetParameterValue("XTotalVtaCre", oMensaje.RecuperarDescripcion("XTotalVtaCredito"))
            oReporte.SetParameterValue("XCanceladoCredito", oMensaje.RecuperarDescripcion("XCancelada"))


            'Ventas Consignacion
            oReporte.SetParameterValue("XVtaConsignacion", oMensaje.RecuperarDescripcion("XVtaConsignacion"))
            oReporte.SetParameterValue("XVentaVCo", oMensaje.RecuperarDescripcion("XVenta"))
            oReporte.SetParameterValue("XFechaVCo", oMensaje.RecuperarDescripcion("XFecha"))
            oReporte.SetParameterValue("XClienteVCo", oMensaje.RecuperarDescripcion("XCliente"))
            oReporte.SetParameterValue("XImporteVCo", oMensaje.RecuperarDescripcion("XImporte"))
            oReporte.SetParameterValue("XTotalConsignacion", oMensaje.RecuperarDescripcion("XTotalConsignacion"))

            'Desglose
            oReporte.SetParameterValue("XDesglose", oMensaje.RecuperarDescripcion("XDesglose"))
            oReporte.SetParameterValue("XEfectivo", oMensaje.RecuperarDescripcion("XEfectivo"))
            oReporte.SetParameterValue("XDenominacion", oMensaje.RecuperarDescripcion("XDenominacion"))
            oReporte.SetParameterValue("XCantidad", oMensaje.RecuperarDescripcion("XCantidad"))
            oReporte.SetParameterValue("XSubtotal", oMensaje.RecuperarDescripcion("XSubtotal"))
            oReporte.SetParameterValue("XCheque", oMensaje.RecuperarDescripcion("XCheque"))
            oReporte.SetParameterValue("XBanco", oMensaje.RecuperarDescripcion("XBanco"))
            oReporte.SetParameterValue("XReferencia", oMensaje.RecuperarDescripcion("XReferencia"))
            oReporte.SetParameterValue("XTotal", oMensaje.RecuperarDescripcion("XTotal"))
            oReporte.SetParameterValue("XGranTotal", oMensaje.RecuperarDescripcion("XGranTotal"))
            oReporte.SetParameterValue("XVendedorD", oMensaje.RecuperarDescripcion("XVendedor"))
            oReporte.SetParameterValue("XRecibio", oMensaje.RecuperarDescripcion("XRecibio"))

        ElseIf Session("NumReporte") = 49 Then ' Devoluciones y Cambios (DISPOSUR)
            If Session("ConversionKg") = False Then
                oReporte.FileName = Server.MapPath("Reports\ReporteDevolucionesCambiosDISPOSUR.rpt")
            Else
                oReporte.FileName = Server.MapPath("Reports\ReporteDevolucionesCambiosDISPOSURKg.rpt")
            End If



            oReporte.Database.Tables("Configuracion").SetDataSource(dt)
            dt = CType(Session("Devolucion"), System.Data.DataTable)
            'oReporte.Database.Tables("Devolucion").SetDataSource(dt)
            oReporte.Subreports("Devoluciones").Database.Tables("DevolucionesDISPOSUR").SetDataSource(dt)

            dt = ins.EjecutarConsulta(Session("Cambios"), IntCommandTimeOut)
            oReporte.Subreports("Cambios").Database.Tables("CambiosDIPOSUR").SetDataSource(dt)


            oReporte.SetParameterValue("enviadovendedor", Session("Vendedor"))
            oReporte.SetParameterValue("EnviadoFecha", Session("RangoFechas"))
            oReporte.SetParameterValue("enviadoruta", Session("Ruta"))
            oReporte.SetParameterValue("XNombreTitulo", Session("Nombre").ToString().ToUpper())
            oReporte.SetParameterValue("XFecha", oMensaje.RecuperarDescripcion("XFecha"))
            oReporte.SetParameterValue("XVendedor", oMensaje.RecuperarDescripcion("XVendedor"))
            oReporte.SetParameterValue("XRuta", oMensaje.RecuperarDescripcion("XRuta"))
            oReporte.SetParameterValue("XDevolucionesConsignacion", oMensaje.RecuperarDescripcion("XDevolucionesConsignacion"))
            oReporte.SetParameterValue("XClave", oMensaje.RecuperarDescripcion("XClave"))
            oReporte.SetParameterValue("XProducto", oMensaje.RecuperarDescripcion("XProducto"))
            oReporte.SetParameterValue("XUnidad", oMensaje.RecuperarDescripcion("XUnidad"))
            oReporte.SetParameterValue("XConversion", oMensaje.RecuperarDescripcion("XConversion"))
            oReporte.SetParameterValue("XPrecio", oMensaje.RecuperarDescripcion("XPrecio"))
            oReporte.SetParameterValue("XCantidad", oMensaje.RecuperarDescripcion("XCantidad"))
            oReporte.SetParameterValue("XKgLts", oMensaje.RecuperarDescripcion("XKgLts"))
            oReporte.SetParameterValue("XImporte", oMensaje.RecuperarDescripcion("XImporte"))
            oReporte.SetParameterValue("Fechahoraimpresion", oMensaje.RecuperarDescripcion("Xfechahoraimpresion"))
            oReporte.SetParameterValue("XTotalProductoDevoluciones", oMensaje.RecuperarDescripcion("XTotal"))
            oReporte.SetParameterValue("XTotalVendedorDevolucion", oMensaje.RecuperarDescripcion("XTotalVendedor"))
            oReporte.SetParameterValue("XTotalClienteDevolucion", oMensaje.RecuperarDescripcion("XTotalCliente"))
            oReporte.SetParameterValue("XTotalRutaDevolucion", oMensaje.RecuperarDescripcion("XTotalRuta"))
            oReporte.SetParameterValue("XTotalFechaDevolucion", oMensaje.RecuperarDescripcion("XTotalFecha"))
            oReporte.SetParameterValue("XTotalFoliosDevolucion", oMensaje.RecuperarDescripcion("XTotalFolios"))
            oReporte.SetParameterValue("XTotalProductosDevolucion", oMensaje.RecuperarDescripcion("XTotalProductos"))
            oReporte.SetParameterValue("XTotalKgLtsDevolucion", oMensaje.RecuperarDescripcion("XTotalKgLts"))
            oReporte.SetParameterValue("XTotalDevueltoDevolucion", oMensaje.RecuperarDescripcion("XTotalDevuelto"))
            oReporte.SetParameterValue("XTotalesSeccionD", oMensaje.RecuperarDescripcion("XTotalesSeccion"))
            oReporte.SetParameterValue("XVendedorD", oMensaje.RecuperarDescripcion("XVendedor"))
            oReporte.SetParameterValue("XClienteD", oMensaje.RecuperarDescripcion("XCliente"))
            oReporte.SetParameterValue("XRutaD", oMensaje.RecuperarDescripcion("XRuta"))
            oReporte.SetParameterValue("XFechaD", oMensaje.RecuperarDescripcion("XFecha"))
            oReporte.SetParameterValue("XFolioD", oMensaje.RecuperarDescripcion("XFolio"))

            oReporte.SetParameterValue("XTotalVendedorCambios", oMensaje.RecuperarDescripcion("XTotalVendedor"))
            oReporte.SetParameterValue("XTotalClienteCambios", oMensaje.RecuperarDescripcion("XTotalCliente"))
            oReporte.SetParameterValue("XTotalRutaCambios", oMensaje.RecuperarDescripcion("XTotalRuta"))
            oReporte.SetParameterValue("XTotalFechaCambios", oMensaje.RecuperarDescripcion("XTotalFecha"))
            oReporte.SetParameterValue("XTotalFoliosCambios", oMensaje.RecuperarDescripcion("XTotalFolios"))
            oReporte.SetParameterValue("XTotalKgLtsCambios", oMensaje.RecuperarDescripcion("XTotalKgLts"))
            oReporte.SetParameterValue("XTotalEntradaCambios", oMensaje.RecuperarDescripcion("XTotalEntrada"))
            oReporte.SetParameterValue("XTotalSalidaCambios", oMensaje.RecuperarDescripcion("XTotalSalida"))
            oReporte.SetParameterValue("XCambios", oMensaje.RecuperarDescripcion("XCambios"))
            oReporte.SetParameterValue("XClaveCambios", oMensaje.RecuperarDescripcion("XClave"))
            oReporte.SetParameterValue("XProductoCambios", oMensaje.RecuperarDescripcion("XProducto"))
            oReporte.SetParameterValue("XUnidadCambios", oMensaje.RecuperarDescripcion("XUnidad"))
            oReporte.SetParameterValue("XConversionCambios", oMensaje.RecuperarDescripcion("XConversion"))
            oReporte.SetParameterValue("XPrecioCambios", oMensaje.RecuperarDescripcion("XPrecio"))
            oReporte.SetParameterValue("XCantidadCambios", oMensaje.RecuperarDescripcion("XCantidad"))
            oReporte.SetParameterValue("XKgLtsCambios", oMensaje.RecuperarDescripcion("XKgLts"))
            oReporte.SetParameterValue("XImporteCambios", oMensaje.RecuperarDescripcion("XImporte"))
            oReporte.SetParameterValue("XEntrada", oMensaje.RecuperarDescripcion("XEntrada"))
            oReporte.SetParameterValue("XSalida", oMensaje.RecuperarDescripcion("XSalida"))
            oReporte.SetParameterValue("XTotalProductoCambios", oMensaje.RecuperarDescripcion("XTotalProductos"))
            oReporte.SetParameterValue("XTotalesSeccionC", oMensaje.RecuperarDescripcion("XTotalesSeccion"))
            oReporte.SetParameterValue("XVendedorC", oMensaje.RecuperarDescripcion("XVendedor"))
            oReporte.SetParameterValue("XClienteC", oMensaje.RecuperarDescripcion("XCliente"))
            oReporte.SetParameterValue("XRutaC", oMensaje.RecuperarDescripcion("XRuta"))
            oReporte.SetParameterValue("XFechaC", oMensaje.RecuperarDescripcion("XFecha"))
            oReporte.SetParameterValue("XFolioC", oMensaje.RecuperarDescripcion("XFolio"))

            oReporte.SetParameterValue("Clave", oMensaje.RecuperarDescripcion("XClave"))
            oReporte.SetParameterValue("Producto", oMensaje.RecuperarDescripcion("XProducto"))
            oReporte.SetParameterValue("Unidad", oMensaje.RecuperarDescripcion("XUnidad"))
            oReporte.SetParameterValue("Conversion", oMensaje.RecuperarDescripcion("XConversion"))
            oReporte.SetParameterValue("Precio", oMensaje.RecuperarDescripcion("XPrecio"))
            oReporte.SetParameterValue("Cantidad", oMensaje.RecuperarDescripcion("XCantidad"))
            oReporte.SetParameterValue("KgLts", oMensaje.RecuperarDescripcion("XKgLts"))
            oReporte.SetParameterValue("Importe", oMensaje.RecuperarDescripcion("XImporte"))
            oReporte.SetParameterValue("Entrada", oMensaje.RecuperarDescripcion("XEntrada"))
            oReporte.SetParameterValue("Salida", oMensaje.RecuperarDescripcion("XSalida"))
            oReporte.SetParameterValue("XCambio", oMensaje.RecuperarDescripcion("XCambios"))
            oReporte.SetParameterValue("XDevoluciones", oMensaje.RecuperarDescripcion("XDevolucionesConsignacion"))

        ElseIf Session("NumReporte") = 50 Then 'Cuotas de Venta (DISPOSUR)
            oReporte.FileName = Server.MapPath("Reports\ReporteCuotasVentasDISPOSUR.rpt")

            oReporte.Database.Tables("Configuracion").SetDataSource(dt)
            dt = CType(Session("DataTable"), System.Data.DataTable)
            oReporte.Database.Tables("Encabezado").SetDataSource(dt)

            dt = ins.EjecutarConsulta(Session("Query1"), IntCommandTimeOut)
            oReporte.Subreports("Esquemas").Database.Tables("Detalle").SetDataSource(dt)

            dt = ins.EjecutarConsulta(Session("Query2"), IntCommandTimeOut)
            oReporte.Subreports("Productos").Database.Tables("Detalle").SetDataSource(dt)

            dt = ins.EjecutarConsulta(Session("Query3"), IntCommandTimeOut)
            oReporte.Subreports("Clientes").Database.Tables("Detalle").SetDataSource(dt)

            dt = ins.EjecutarConsulta(Session("Query4"), IntCommandTimeOut)
            oReporte.Subreports("Vendedor").Database.Tables("Detalle").SetDataSource(dt)

            oReporte.SetParameterValue("Nombre", Session("Nombre").ToString().ToUpper())
            oReporte.SetParameterValue("CentroDistribucion", oMensaje.RecuperarDescripcion("XCentroDistribucion"))
            oReporte.SetParameterValue("Fecha", oMensaje.RecuperarDescripcion("XFecha"))
            oReporte.SetParameterValue("Vendedor", oMensaje.RecuperarDescripcion("XVendedor"))
            oReporte.SetParameterValue("enviadoCEDI", Session("CEDI"))
            oReporte.SetParameterValue("enviadovendedor", Session("Vendedor"))
            oReporte.SetParameterValue("EnviadaFecha", Session("RangoFechas"))

            oReporte.SetParameterValue("Tipo", oMensaje.RecuperarDescripcion("XTipo"))
            oReporte.SetParameterValue("Descripcion", oMensaje.RecuperarDescripcion("XDescripcion"))
            oReporte.SetParameterValue("Minimo", oMensaje.RecuperarDescripcion("XMinimo"))
            oReporte.SetParameterValue("Avanze", oMensaje.RecuperarDescripcion("XAvance"))
            oReporte.SetParameterValue("Faltante", oMensaje.RecuperarDescripcion("XFaltante"))
            oReporte.SetParameterValue("Producto", oMensaje.RecuperarDescripcion("XProducto"))
            oReporte.SetParameterValue("Efectivo", oMensaje.RecuperarDescripcion("XEfectivo"))
            oReporte.SetParameterValue("Cuota", oMensaje.RecuperarDescripcion("XCuota"))
            oReporte.SetParameterValue("Periodo", oMensaje.RecuperarDescripcion("XPeriodo"))
            oReporte.SetParameterValue("DiasPeriodo", oMensaje.RecuperarDescripcion("XDiasPeriodo"))
            oReporte.SetParameterValue("DiasTranscurridos", oMensaje.RecuperarDescripcion("XDiasTranscurridos"))
            oReporte.SetParameterValue("DiasFaltantes", oMensaje.RecuperarDescripcion("XDiasFaltantes"))
            oReporte.SetParameterValue("Totales", oMensaje.RecuperarDescripcion("XTotales"), "Esquemas")
            oReporte.SetParameterValue("Totales", oMensaje.RecuperarDescripcion("XTotales"), "Productos")
            oReporte.SetParameterValue("Totales", oMensaje.RecuperarDescripcion("XTotales"), "Clientes")
            oReporte.SetParameterValue("ResumenGeneral", oMensaje.RecuperarDescripcion("XResumenGeneralAvanceCuotas"))
            oReporte.SetParameterValue("Esquemas", oMensaje.RecuperarDescripcion("XEsquemas"))
            oReporte.SetParameterValue("Productos", oMensaje.RecuperarDescripcion("XProductos"))
            oReporte.SetParameterValue("Clientes", oMensaje.RecuperarDescripcion("XClientes"))
            oReporte.SetParameterValue("Fechahoraimpresion", oMensaje.RecuperarDescripcion("Xfechahoraimpresion"))

        ElseIf Session("NumReporte") = 51 Then 'Exportar Encuestas Aplicadas
         
            Dim sTipo = Session("EncuestaTipo")
            Session("EncuestaTipo") = oMensaje.RecuperarDescripcion("XTipo") & ": " & sTipo
        ElseIf Session("NumReporte") = 52 Then
            oReporte.FileName = Server.MapPath("Reports\ReporteClientesNoVisitados.rpt")
            oReporte.Database.Tables("Configuracion").SetDataSource(dt)
            dt = CType(Session("DataTable"), System.Data.DataTable)
            oReporte.Database.Tables("ReporteClientesNoVisitados").SetDataSource(dt)

            oReporte.SetParameterValue("XFecha", oMensaje.RecuperarDescripcion("XFECHA"))
            oReporte.SetParameterValue("FiltroFecha", Session("RangoFechas"))
            oReporte.SetParameterValue("Ruta", oMensaje.RecuperarDescripcion("Xruta"))
            oReporte.SetParameterValue("ENVIADARUTA", Session("Ruta"))
            oReporte.SetParameterValue("@NombreReporte", Session("Nombre").ToString().ToUpper())
            oReporte.SetParameterValue("XDiaTrabajo", oMensaje.RecuperarDescripcion("XDiaTrabajo"))
            oReporte.SetParameterValue("XClave", oMensaje.RecuperarDescripcion("XClaveCliente"))
            oReporte.SetParameterValue("XRazonSocial", oMensaje.RecuperarDescripcion("XCliente"))
            oReporte.SetParameterValue("XIdElectronico", oMensaje.RecuperarDescripcion("XCodigodeBarras"))
            oReporte.SetParameterValue("XCalle", oMensaje.RecuperarDescripcion("XCalle"))
            oReporte.SetParameterValue("XNumero", oMensaje.RecuperarDescripcion("XExterior"))
            oReporte.SetParameterValue("XNumInt", oMensaje.RecuperarDescripcion("XInterior"))
            oReporte.SetParameterValue("XColonia", oMensaje.RecuperarDescripcion("XColonia"))
            oReporte.SetParameterValue("XLocalidad", oMensaje.RecuperarDescripcion("XLocalidad"))
            oReporte.SetParameterValue("XPoblacion", oMensaje.RecuperarDescripcion("XMunicipio"))
            oReporte.SetParameterValue("XEntidad", oMensaje.RecuperarDescripcion("XEntidad"))
            oReporte.SetParameterValue("XCodigo", oMensaje.RecuperarDescripcion("XCP"))
            oReporte.SetParameterValue("XReferenciaDom", oMensaje.RecuperarDescripcion("XReferencia"))
            oReporte.SetParameterValue("XDeposito", oMensaje.RecuperarDescripcion("XDeposito"))
            oReporte.SetParameterValue("XCoordenadaX", oMensaje.RecuperarDescripcion("XLongitudX"))
            oReporte.SetParameterValue("XCoordenadaY", oMensaje.RecuperarDescripcion("XLatitudY"))
        ElseIf Session("NumReporte") = 53 Then
            oReporte.FileName = Server.MapPath("Reports\ReportePuntosRecorrido.rpt")
            oReporte.Database.Tables("Configuracion").SetDataSource(dt)
            dt = CType(Session("DataTable"), System.Data.DataTable)
            oReporte.Database.Tables("ReportePuntosRecorrido").SetDataSource(dt)

            oReporte.SetParameterValue("XFecha", oMensaje.RecuperarDescripcion("XFECHA"))
            oReporte.SetParameterValue("FiltroFecha", Session("RangoFechas"))
            oReporte.SetParameterValue("Ruta", oMensaje.RecuperarDescripcion("Xruta"))
            oReporte.SetParameterValue("ENVIADARUTA", Session("Ruta"))
            oReporte.SetParameterValue("@NombreReporte", Session("Nombre").ToString().ToUpper())
            oReporte.SetParameterValue("XDiaTrabajo", oMensaje.RecuperarDescripcion("XDiaTrabajo"))
            oReporte.SetParameterValue("XLongitudX", oMensaje.RecuperarDescripcion("XLongitudX"))
            oReporte.SetParameterValue("XLatitudY", oMensaje.RecuperarDescripcion("XLatitudY"))
            oReporte.SetParameterValue("XVendedor", oMensaje.RecuperarDescripcion("XVendedor"))
        ElseIf Session("NumReporte") = 54 Then
            If Session("ConversionKg") = False Then
                oReporte.FileName = Server.MapPath("Reports\ReporteSugeridoCargaPorReparto.rpt")
            Else
                oReporte.FileName = Server.MapPath("Reports\ReporteSugeridoCargaPorRepartoKg.rpt")
            End If

            oReporte.Database.Tables("Configuracion").SetDataSource(dt)
            dt = CType(Session("DataTable"), System.Data.DataTable)
            If Session("ConversionKg") = False Then
                oReporte.Database.Tables("Productos").SetDataSource(dt)
            Else
                oReporte.Database.Tables("ProductosKgLts").SetDataSource(dt)
            End If

            oReporte.SetParameterValue("@NombreReporte", Session("Nombre").ToString().ToUpper())
            oReporte.SetParameterValue("@FiltroVendedor", Session("Vendedor"))
            'oReporte.SetParameterValue("@FiltroCEDI", Session("CEDI"))
            oReporte.SetParameterValue("@FiltroRuta", Session("Ruta"))
            oReporte.SetParameterValue("@FiltroEsquema", Session("FiltroEsquemas"))

            oReporte.SetParameterValue("XCentroDistribucion", oMensaje.RecuperarDescripcion("XCentroDistribucion"))
            oReporte.SetParameterValue("XRuta", oMensaje.RecuperarDescripcion("XRuta"))
            oReporte.SetParameterValue("XVendedor", oMensaje.RecuperarDescripcion("XVendedor"))
            oReporte.SetParameterValue("XEsquema", oMensaje.RecuperarDescripcion("XEsquema"))
            oReporte.SetParameterValue("XClave", oMensaje.RecuperarDescripcion("XClave"))
            oReporte.SetParameterValue("XNombre", oMensaje.RecuperarDescripcion("XNombre"))
            oReporte.SetParameterValue("XUnidad", oMensaje.RecuperarDescripcion("XUnidad"))
            oReporte.SetParameterValue("XCantidad", oMensaje.RecuperarDescripcion("XCantidad"))
            If Session("ConversionKg") = True Then
                oReporte.SetParameterValue("XKgLts", oMensaje.RecuperarDescripcion("XKgLts"))
            End If
            oReporte.SetParameterValue("FechaHoraImpresion", oMensaje.RecuperarDescripcion("XFechaHoraImpresion"))

        ElseIf Session("NumReporte") = 55 Then
            oReporte.FileName = Server.MapPath("Reports\ReporteInventarioDeProductoTerminadoPanque.rpt")
            oReporte.Database.Tables("ReporteProductoTerminado").SetDataSource(Session("DataTable"))
            oReporte.Database.Tables("Configuracion").SetDataSource(dt)

            oReporte.SetParameterValue("nombre", Session("Nombre").ToString().ToUpper()) '''''''''''''****<----Nombre por filtros)
            oReporte.SetParameterValue("CentroDistribucion", oMensaje.RecuperarDescripcion("XCentroDistribucion"))
            oReporte.SetParameterValue("fecha", oMensaje.RecuperarDescripcion("Xfecha"))
            oReporte.SetParameterValue("clave", oMensaje.RecuperarDescripcion("Xclave"))
            oReporte.SetParameterValue("Producto", oMensaje.RecuperarDescripcion("XProducto"))
            oReporte.SetParameterValue("ExistenciaAnterior", oMensaje.RecuperarDescripcion("XExistenciaAnterior"))
            oReporte.SetParameterValue("Carga", oMensaje.RecuperarDescripcion("XCarga"))
            oReporte.SetParameterValue("SobranteProduccion", oMensaje.RecuperarDescripcion("XSobranteProduccion"))
            oReporte.SetParameterValue("ExistenciaTotal", oMensaje.RecuperarDescripcion("XExistenciaTotal"))
            oReporte.SetParameterValue("PrecioUnitario", oMensaje.RecuperarDescripcion("XPrecioUnitario"))
            oReporte.SetParameterValue("Importe", oMensaje.RecuperarDescripcion("XImporte"))
            oReporte.SetParameterValue("Totales", oMensaje.RecuperarDescripcion("XTotales"))
            oReporte.SetParameterValue("Enviadafecha", Session("RangoFechas"))
            oReporte.SetParameterValue("FechaHoraImpresion", oMensaje.RecuperarDescripcion("XFechaHoraImpresion"))

        ElseIf Session("NumReporte") = 56 Then 'Reporte Devoluciones Y Frios
            oReporte.FileName = Server.MapPath("Reports\ReporteDevolucionesFriosPanque.rpt")
            oReporte.Database.Tables("DevolucionesFriosPanque").SetDataSource(Session("DataTable"))
            oReporte.Database.Tables("Configuracion").SetDataSource(dt)

            oReporte.SetParameterValue("xCedi", oMensaje.RecuperarDescripcion("XCentroDistribucion"))
            oReporte.SetParameterValue("xVendedor", oMensaje.RecuperarDescripcion("XVendedor"))

            oReporte.SetParameterValue("xFecha", oMensaje.RecuperarDescripcion("XFecha"))
            oReporte.SetParameterValue("nombre", Session("Nombre").ToString().ToUpper())

            oReporte.SetParameterValue("xLunes", oMensaje.RecuperarDescripcion("XLunes"))
            oReporte.SetParameterValue("xMartes", oMensaje.RecuperarDescripcion("XMartes"))
            oReporte.SetParameterValue("xMiercoles", oMensaje.RecuperarDescripcion("XMiercoles"))
            oReporte.SetParameterValue("xJueves", oMensaje.RecuperarDescripcion("XJueves"))
            oReporte.SetParameterValue("xViernes", oMensaje.RecuperarDescripcion("XViernes"))
            oReporte.SetParameterValue("xSabado", oMensaje.RecuperarDescripcion("XSabado"))
            oReporte.SetParameterValue("xDomingo", oMensaje.RecuperarDescripcion("XDomingo"))
            oReporte.SetParameterValue("xTotales", oMensaje.RecuperarDescripcion("XTotales"))

            oReporte.SetParameterValue("xDev", oMensaje.RecuperarDescripcion("XDev"))
            oReporte.SetParameterValue("xFrio", oMensaje.RecuperarDescripcion("XFrio"))

            oReporte.SetParameterValue("xFechaHoraImpresion", oMensaje.RecuperarDescripcion("XFechaHoraImpresion"))

        ElseIf Session("NumReporte") = 59 Then 'Saldos por Cliente
            oReporte.FileName = Server.MapPath("Reports\ReporteSaldosPorCliente.rpt")
            oReporte.Database.Tables("SaldosPorCliente").SetDataSource(Session("DataTable"))
            oReporte.Database.Tables("Configuracion").SetDataSource(dt)

            oReporte.SetParameterValue("Nombre", Session("Nombre").ToString().ToUpper())
            oReporte.SetParameterValue("ParamCEDI", Session("CEDI"))
            oReporte.SetParameterValue("ParamRuta", Session("Ruta"))
            oReporte.SetParameterValue("ParamVendedor", Session("Vendedor"))
            oReporte.SetParameterValue("ParamFecha", Session("RangoFechas"))
            oReporte.SetParameterValue("ParamCliente", Session("FiltroClientes"))
            oReporte.SetParameterValue("XClaveCliente", oMensaje.RecuperarDescripcion("XClaveCliente"))
            oReporte.SetParameterValue("XNombreCliente", oMensaje.RecuperarDescripcion("XNombre"))
            oReporte.SetParameterValue("XNombreContacto", oMensaje.RecuperarDescripcion("XNombreContacto"))
            oReporte.SetParameterValue("XSaldo", oMensaje.RecuperarDescripcion("XSaldo"))
            oReporte.SetParameterValue("XCedi", oMensaje.RecuperarDescripcion("XCedi"))
            oReporte.SetParameterValue("XRuta", oMensaje.RecuperarDescripcion("XRuta"))
            oReporte.SetParameterValue("XVendedor", oMensaje.RecuperarDescripcion("XVendedor"))
            oReporte.SetParameterValue("XFecha", oMensaje.RecuperarDescripcion("XFecha"))
            oReporte.SetParameterValue("XCliente", oMensaje.RecuperarDescripcion("XCliente"))
            oReporte.SetParameterValue("XTotalPorCedi", oMensaje.RecuperarDescripcion("XTotalPorCedi"))
            oReporte.SetParameterValue("XTotalPorVendedor", oMensaje.RecuperarDescripcion("XTotalPorVendedor"))
            oReporte.SetParameterValue("XTotalPorRuta", oMensaje.RecuperarDescripcion("XTotalPorRuta"))
            oReporte.SetParameterValue("FechaHoraImpresion", oMensaje.RecuperarDescripcion("XFechaHoraImpresion"))

        ElseIf Session("NumReporte") = 60 Then
            oReporte.FileName = Server.MapPath("Reports\ReporteLiquidacionModelo.rpt")
            oReporte.Database.Tables("Vendedores").SetDataSource(Session("DataTable"))
            oReporte.Database.Tables("Configuracion").SetDataSource(dt)

            dt = ins.EjecutarConsulta(Session("Movimientos"), IntCommandTimeOut)
            oReporte.Subreports("Movimientos").Database.Tables("Movimientos").SetDataSource(dt)
            dt = ins.EjecutarConsulta(Session("Ventas"), IntCommandTimeOut)
            oReporte.Subreports("Ventas").Database.Tables("VentaCobranza").SetDataSource(dt)
            dt = ins.EjecutarConsulta(Session("Cobranza"), IntCommandTimeOut)
            oReporte.Subreports("Cobranza").Database.Tables("VentaCobranza").SetDataSource(dt)
            dt = ins.EjecutarConsulta(Session("Envases"), IntCommandTimeOut)
            oReporte.Subreports("Envases").Database.Tables("Envases").SetDataSource(dt)

            'Main
            oReporte.SetParameterValue("NombreRep", Session("Nombre").ToString().ToUpper())
            oReporte.SetParameterValue("ParamCEDI", Session("CEDI"))
            oReporte.SetParameterValue("ParamVendedor", Session("Vendedor"))
            oReporte.SetParameterValue("ParamFecha", Session("RangoFechas"))
            oReporte.SetParameterValue("XCedi", oMensaje.RecuperarDescripcion("XCedi"))
            oReporte.SetParameterValue("XVendedor", oMensaje.RecuperarDescripcion("XVendedor"))
            oReporte.SetParameterValue("XFecha", oMensaje.RecuperarDescripcion("XFecha"))
            oReporte.SetParameterValue("FechaHoraImpresion", oMensaje.RecuperarDescripcion("XFechaHoraImpresion"))
            oReporte.SetParameterValue("XResumen", oMensaje.RecuperarDescripcion("XResumen").ToUpper)
            oReporte.SetParameterValue("XTotalVtaProductos", oMensaje.RecuperarDescripcion("XTotalVentasProductos"))
            oReporte.SetParameterValue("XTotalCobProductos", oMensaje.RecuperarDescripcion("XTotalCobranzaMin"))
            oReporte.SetParameterValue("XTotalLiquidar", oMensaje.RecuperarDescripcion("XTotalLiquidar"))
            'oReporte.SetParameterValue("XSimboloMoneda", "$")
            oReporte.SetParameterValue("XRecibio", oMensaje.RecuperarDescripcion("XRecibio"))
            'Movimientos
            oReporte.SetParameterValue("XVentasProducto", oMensaje.RecuperarDescripcion("XVentasProducto").ToUpper)
            oReporte.SetParameterValue("XClave", oMensaje.RecuperarDescripcion("XClave"))
            oReporte.SetParameterValue("XDescripcion", oMensaje.RecuperarDescripcion("XDescripcion"))
            oReporte.SetParameterValue("XInvInicial", oMensaje.RecuperarDescripcion("XInvInicial"))
            oReporte.SetParameterValue("XCargas", oMensaje.RecuperarDescripcion("XCargas"))
            oReporte.SetParameterValue("XDevolucionAlmacen", oMensaje.RecuperarDescripcion("XDevolucionAlmacen"))
            oReporte.SetParameterValue("XDescargas", oMensaje.RecuperarDescripcion("XDescargas"))
            oReporte.SetParameterValue("XPromocion", oMensaje.RecuperarDescripcion("XPromocion"))
            oReporte.SetParameterValue("XConsignacion", oMensaje.RecuperarDescripcion("XConsignacion"))
            oReporte.SetParameterValue("XVentas", oMensaje.RecuperarDescripcion("XVentas"))
            oReporte.SetParameterValue("XImporte", oMensaje.RecuperarDescripcion("XImporte"))
            oReporte.SetParameterValue("XTotalVentaProducto", oMensaje.RecuperarDescripcion("XTotalVentasProductos"))
            'Ventas
            oReporte.SetParameterValue("XImporteVentas", oMensaje.RecuperarDescripcion("XImporteVentas").ToUpper)
            oReporte.SetParameterValue("XTipoVentaVta", oMensaje.RecuperarDescripcion("XVenta"))
            oReporte.SetParameterValue("XImporteVta", oMensaje.RecuperarDescripcion("XImporte"))
            oReporte.SetParameterValue("XContadoVta", oMensaje.RecuperarDescripcion("XContado"))
            oReporte.SetParameterValue("XCreditoVta", oMensaje.RecuperarDescripcion("XCredito"))
            oReporte.SetParameterValue("XTotalVenta", oMensaje.RecuperarDescripcion("XTotalVtaImporte"))
            'Cobranza
            oReporte.SetParameterValue("XCobranza", oMensaje.RecuperarDescripcion("XCobranza").ToUpper)
            oReporte.SetParameterValue("XTipoVentaCob", oMensaje.RecuperarDescripcion("XVenta"))
            oReporte.SetParameterValue("XImporteCob", oMensaje.RecuperarDescripcion("XImporte"))
            oReporte.SetParameterValue("XContadoCob", oMensaje.RecuperarDescripcion("XContado"))
            oReporte.SetParameterValue("XCreditoCob", oMensaje.RecuperarDescripcion("XCredito"))
            oReporte.SetParameterValue("XTotalCobranza", oMensaje.RecuperarDescripcion("XTotalCobranzaMin"))
            'Envases
            oReporte.SetParameterValue("XSaldoEnvases", oMensaje.RecuperarDescripcion("XSaldoEnvases").ToUpper)
            oReporte.SetParameterValue("XProductoSaldo", oMensaje.RecuperarDescripcion("XProducto"))
            oReporte.SetParameterValue("XSaldo", oMensaje.RecuperarDescripcion("XSaldo"))
        ElseIf Session("NumReporte") = 62 Then

            Dim iMonedaBase As String = ins.EjecutarComandoScalar("select top 1 MonedaID from conhist order by conhist.CONHistFechaInicio desc ")
            Dim sDolar As String = ins.EjecutarComandoScalar("select Nombre from moneda where MonedaID=2")
            Dim sPesos As String = ins.EjecutarComandoScalar("select Nombre from moneda where MonedaID=1")

            oReporte.FileName = Server.MapPath("Reports\ReporteLiquidacionSuKarne.rpt")
            oReporte.Database.Tables("Vendedores").SetDataSource(Session("DataTable"))
            oReporte.Database.Tables("Configuracion").SetDataSource(dt)

            dt = ins.EjecutarConsulta(Session("Movimientos"), IntCommandTimeOut)
            oReporte.Subreports("Movimientos").Database.Tables("Movimientos").SetDataSource(dt)
            'dt = ins.EjecutarConsulta(Session("Ventas"), IntCommandTimeOut)
            'oReporte.Subreports("Ventas").Database.Tables("VentaCobranza").SetDataSource(dt)

            dt = ins.EjecutarConsulta(Session("VentasEfectivo"), IntCommandTimeOut)
            oReporte.Subreports("VentasEfectivo").Database.Tables("Ventas").SetDataSource(dt)
            dt = ins.EjecutarConsulta(Session("VentasCredito"), IntCommandTimeOut)
            oReporte.Subreports("VentasCredito").Database.Tables("Ventas").SetDataSource(dt)
            oReporte.Subreports("CobranzaDesglozado").Database.Tables("VentaCobranzaDesglozado").SetDataSource(Session("VentaCobranzaDesglozado"))

            oReporte.Subreports("Preliquidacion").Database.Tables("Preliquidacion").SetDataSource(Session("PreliquidacionEfe"))
            oReporte.Subreports("PreliquidacionDep").Database.Tables("PreliquidacionDep").SetDataSource(Session("PreliquidacionDep"))


            'dt = ins.EjecutarConsulta(Session("Cobranza"), IntCommandTimeOut)
            'oReporte.Subreports("Cobranza").Database.Tables("VentaCobranza").SetDataSource(dt)


            'Main
            oReporte.SetParameterValue("NombreRep", Session("Nombre").ToString().ToUpper())
            oReporte.SetParameterValue("ParamCEDI", Session("CEDI"))
            oReporte.SetParameterValue("ParamVendedor", Session("Vendedor"))
            oReporte.SetParameterValue("ParamFecha", Session("RangoFechas"))
            oReporte.SetParameterValue("XCedi", oMensaje.RecuperarDescripcion("XCedi"))
            oReporte.SetParameterValue("XVendedor", oMensaje.RecuperarDescripcion("XVendedor"))
            oReporte.SetParameterValue("XFecha", oMensaje.RecuperarDescripcion("XFecha"))
            oReporte.SetParameterValue("FechaHoraImpresion", oMensaje.RecuperarDescripcion("XFechaHoraImpresion"))
            oReporte.SetParameterValue("XResumen", oMensaje.RecuperarDescripcion("XResumen").ToUpper)
            oReporte.SetParameterValue("XTotalVtaProductos", oMensaje.RecuperarDescripcion("XTotalVentasProductos"))
            oReporte.SetParameterValue("XTotalVtaCredito", oMensaje.RecuperarDescripcion("XTotalVtaCredito"))
            oReporte.SetParameterValue("XTotalLiquidar", oMensaje.RecuperarDescripcion("XTotalLiquidar1") + " " + sPesos)
            oReporte.SetParameterValue("XTotalLiquidarDolares", oMensaje.RecuperarDescripcion("XTotalLiquidar1") + " " + sDolar)
            'oReporte.SetParameterValue("XSimboloMoneda", "$")
            oReporte.SetParameterValue("XRecibio", oMensaje.RecuperarDescripcion("XRecibio"))
            'Movimientos
            oReporte.SetParameterValue("XVentasProducto", oMensaje.RecuperarDescripcion("XVentasProducto").ToUpper)
            oReporte.SetParameterValue("XClave", oMensaje.RecuperarDescripcion("XClave"))
            oReporte.SetParameterValue("XDescripcion", oMensaje.RecuperarDescripcion("XDescripcion"))
            oReporte.SetParameterValue("XUnidad", oMensaje.RecuperarDescripcion("XUnidad"))
            oReporte.SetParameterValue("XCargas", oMensaje.RecuperarDescripcion("XCargas"))
            oReporte.SetParameterValue("XPiezas", oMensaje.RecuperarDescripcion("XPiezasVentas"))
            'oReporte.SetParameterValue("XDevolucionAlmacen", oMensaje.RecuperarDescripcion("XDevolucionAlmacen"))
            oReporte.SetParameterValue("XDescargas", oMensaje.RecuperarDescripcion("XDescargas"))
            'oReporte.SetParameterValue("XPromocion", oMensaje.RecuperarDescripcion("XPromocion"))
            oReporte.SetParameterValue("FacturasSurtidas", oMensaje.RecuperarDescripcion("XFacturasSurtidas"))
            oReporte.SetParameterValue("XVentas", oMensaje.RecuperarDescripcion("XVentas"))
            oReporte.SetParameterValue("XImporte", oMensaje.RecuperarDescripcion("XImporte") + " " + IIf(iMonedaBase = "1", sPesos, sDolar))
            oReporte.SetParameterValue("XTotalVentaProducto", oMensaje.RecuperarDescripcion("XTotalVentasProductos"))
            'Ventas Efectivo
            oReporte.SetParameterValue("VentasEfectivo", oMensaje.RecuperarDescripcion("XVentasEfectivo").ToUpper)
            oReporte.SetParameterValue("FolioEfe", oMensaje.RecuperarDescripcion("XVenta"))
            oReporte.SetParameterValue("FechaHoraAltaEfe", oMensaje.RecuperarDescripcion("XFecha"))
            oReporte.SetParameterValue("ClienteEfe", oMensaje.RecuperarDescripcion("XCliente"))
            oReporte.SetParameterValue("TotalEfe", oMensaje.RecuperarDescripcion("XImporte") + " " + IIf(iMonedaBase = "1", sPesos, sDolar))
            oReporte.SetParameterValue("TotalVentaEfe", oMensaje.RecuperarDescripcion("XTotalVtaContado"))
            'Ventas Credito
            oReporte.SetParameterValue("VentasCredito", oMensaje.RecuperarDescripcion("XVentasCredito").ToUpper)
            oReporte.SetParameterValue("FolioCre", oMensaje.RecuperarDescripcion("XVenta"))
            oReporte.SetParameterValue("FechaHoraAltaCre", oMensaje.RecuperarDescripcion("XFecha"))
            oReporte.SetParameterValue("ClienteCre", oMensaje.RecuperarDescripcion("XCliente"))
            oReporte.SetParameterValue("TotalCre", oMensaje.RecuperarDescripcion("XImporte") + " " + IIf(iMonedaBase = "1", sPesos, sDolar))
            oReporte.SetParameterValue("TotalVentaCre", oMensaje.RecuperarDescripcion("XTotalVtaCredito"))
            'Cobranza
            'oReporte.SetParameterValue("XCobranza", oMensaje.RecuperarDescripcion("XCobranza").ToUpper)
            'oReporte.SetParameterValue("XTipoVentaCob", oMensaje.RecuperarDescripcion("XVenta"))
            'oReporte.SetParameterValue("XImporteCob", oMensaje.RecuperarDescripcion("XImporte"))
            'oReporte.SetParameterValue("XContadoCob", oMensaje.RecuperarDescripcion("XContado"))
            'oReporte.SetParameterValue("XCreditoCob", oMensaje.RecuperarDescripcion("XCredito"))
            'oReporte.SetParameterValue("XTotalCobranza", oMensaje.RecuperarDescripcion("XTotalCobranzaMin"))
            'Cobranza Desglozado
            oReporte.SetParameterValue("XCobranzaD", oMensaje.RecuperarDescripcion("XCobranza").ToUpper)
            oReporte.SetParameterValue("XCobranzaVentasCredito", oMensaje.RecuperarDescripcion("XCobranzaVentasCredito"))
            oReporte.SetParameterValue("XCobranzaVentasEfectivo", oMensaje.RecuperarDescripcion("XCobranzaVentasEfectivo"))
            oReporte.SetParameterValue("FolioD", oMensaje.RecuperarDescripcion("XVenta"))
            oReporte.SetParameterValue("FechaD", oMensaje.RecuperarDescripcion("XFecha"))
            oReporte.SetParameterValue("VentaTotalD", oMensaje.RecuperarDescripcion("XTotalVenta"))
            oReporte.SetParameterValue("SaldoActualD", oMensaje.RecuperarDescripcion("XSaldoActual"))
            oReporte.SetParameterValue("AbonosD", oMensaje.RecuperarDescripcion("XImporte") + " " + sPesos)
            oReporte.SetParameterValue("AbonosDDolares", oMensaje.RecuperarDescripcion("XImporte") + " " + sDolar)
            oReporte.SetParameterValue("XTotalCobranzaD", oMensaje.RecuperarDescripcion("XTotalCobranzaMin"))
            oReporte.SetParameterValue("ClienteD", oMensaje.RecuperarDescripcion("XCliente"))

            'Preliq Efe
            oReporte.SetParameterValue("XDescripcion2", oMensaje.RecuperarDescripcion("XDescripcion"))
            oReporte.SetParameterValue("XCantidad", oMensaje.RecuperarDescripcion("XCantidad"))
            oReporte.SetParameterValue("XTotal", oMensaje.RecuperarDescripcion("XTotalMin"))
            oReporte.SetParameterValue("XGrupo", oMensaje.RecuperarDescripcion("XGrupo"))
            oReporte.SetParameterValue("XPreliquidacion", oMensaje.RecuperarDescripcion("XPreliquidacion"))

            oReporte.SetParameterValue("XTipo", oMensaje.RecuperarDescripcion("XTipo"))
            oReporte.SetParameterValue("XReferencia", oMensaje.RecuperarDescripcion("XReferencia"))
            oReporte.SetParameterValue("XTotal3", oMensaje.RecuperarDescripcion("XTotalMin"))
            oReporte.SetParameterValue("XBanco", oMensaje.RecuperarDescripcion("XBanco"))
            oReporte.SetParameterValue("XImporte2", oMensaje.RecuperarDescripcion("XImporte"))
            oReporte.SetParameterValue("XDEPOSITOSYCHEQUES", oMensaje.RecuperarDescripcion("XDEPOSITOSYCHEQUES"))



        ElseIf Session("NumReporte") = 67 Then '--Tiempos en ruta

            oReporte.FileName = Server.MapPath("Reports\ReporteTiemposRutaSuKarne.rpt")

            oReporte.Database.Tables(0).SetDataSource(Session("DataTable"))
            oReporte.Database.Tables(1).SetDataSource(dt)
            oReporte.Subreports("Kilometraje").Database.Tables("Kilometraje").SetDataSource(ins.EjecutarConsulta(Session("Kilometraje"), IntCommandTimeOut))

            If (IsNothing(Session("subreport0"))) Then
                Session("subreport0") = ins.EjecutarConsulta(Session("Query2"), IntCommandTimeOut)
            End If
            oReporte.Subreports("TotalTiemposRuta").Database.Tables(0).SetDataSource(Session("subreport0"))
            If (IsNothing(Session("subreport1"))) Then
                Session("subreport1") = ins.EjecutarConsulta(Session("Query3"), IntCommandTimeOut)
            End If
            oReporte.Subreports("TotalTiemposRutaFueraAgenda").Database.Tables(0).SetDataSource(Session("subreport1"))

            oReporte.SetParameterValue("Nombre", Session("Nombre").ToString().ToUpper()) '''''''''''''****<----Nombre por filtros

            oReporte.SetParameterValue("XSecuencia", oMensaje.RecuperarDescripcion("SECSEC"))
            oReporte.SetParameterValue("XClienteClave", oMensaje.RecuperarDescripcion("CLIClave"))
            oReporte.SetParameterValue("XCodigoNoLeido", oMensaje.RecuperarDescripcion("XCodigoNoLeido"))
            oReporte.SetParameterValue("XNombreCliente", oMensaje.RecuperarDescripcion("CLICliente") + " - " + oMensaje.RecuperarDescripcion("xcontacto"))
            oReporte.SetParameterValue("XMinutosTransito", oMensaje.RecuperarDescripcion("XTiempoTransito"))
            oReporte.SetParameterValue("XHoraInicio", oMensaje.RecuperarDescripcion("VISHRFIN"))
            oReporte.SetParameterValue("XHoraFin", oMensaje.RecuperarDescripcion("VISHRINI"))
            oReporte.SetParameterValue("XMinutosVisita", oMensaje.RecuperarDescripcion("XTiempoVisita"))
            oReporte.SetParameterValue("XVenta", oMensaje.RecuperarDescripcion("XVENTA"))
            oReporte.SetParameterValue("XSurtido", oMensaje.RecuperarDescripcion("Xfechasurtido"))
            oReporte.SetParameterValue("XConcepto", oMensaje.RecuperarDescripcion("XConcepto"))
            oReporte.SetParameterValue("XVentaTotal", oMensaje.RecuperarDescripcion("XVentaTotal"))
            oReporte.SetParameterValue("XRuta", oMensaje.RecuperarDescripcion("XRuta"))
            oReporte.SetParameterValue("XInicioRecorrido", oMensaje.RecuperarDescripcion("XInicioRecorrido"))
            oReporte.SetParameterValue("XFinRecorrido", oMensaje.RecuperarDescripcion("XFinRecorrido"))


            oReporte.SetParameterValue("XVisitados", oMensaje.RecuperarDescripcion("XVisitados"))
            oReporte.SetParameterValue("XNoVisitados", oMensaje.RecuperarDescripcion("XNoVisitados"))

            oReporte.SetParameterValue("XTotalClientes", oMensaje.RecuperarDescripcion("XTotalClientes"))
            oReporte.SetParameterValue("XTiempoTransito", oMensaje.RecuperarDescripcion("XTiempoTransito"))
            oReporte.SetParameterValue("XTiempoRecorrido", oMensaje.RecuperarDescripcion("XTiempoRecorrido"))
            oReporte.SetParameterValue("XTiempoTransito", oMensaje.RecuperarDescripcion("XTiempoTransito"))
            oReporte.SetParameterValue("XEfectividadCompra", oMensaje.RecuperarDescripcion("XEfectividadCompra"))
            oReporte.SetParameterValue("XTotalCodigoNoLeido", oMensaje.RecuperarDescripcion("XTotalCodigoNoLeido"))

            oReporte.SetParameterValue("XVisitasSinVenta", oMensaje.RecuperarDescripcion("XVisitasSinVenta"))
            oReporte.SetParameterValue("XVisitaEfectiva", oMensaje.RecuperarDescripcion("XVisitaEfectiva"))
            oReporte.SetParameterValue("XTiempoPromedio", oMensaje.RecuperarDescripcion("XTiempoPromedio"))
            oReporte.SetParameterValue("XTiempoVisita", oMensaje.RecuperarDescripcion("XTiempoVisita"))

            oReporte.SetParameterValue("Fecha", oMensaje.RecuperarDescripcion("XFecha") + "")
            oReporte.SetParameterValue("Vendedor", oMensaje.RecuperarDescripcion("XVendedor"))
            oReporte.SetParameterValue("Ruta", oMensaje.RecuperarDescripcion("Xruta"))

            oReporte.SetParameterValue("Enviadovendedor", Session("Vendedor"))
            oReporte.SetParameterValue("Enviadaruta", Session("Ruta"))
            oReporte.SetParameterValue("Enviadafecha", Session("RangoFechas"))
            oReporte.SetParameterValue("CentroDistribucion", oMensaje.RecuperarDescripcion("XCentroDistribucion"))
            oReporte.SetParameterValue("FechaHoraImpresion", oMensaje.RecuperarDescripcion("Xfechahoraimpresion"))

            oReporte.SetParameterValue("XClientesEnAgenda", oMensaje.RecuperarDescripcion("XClientesEnAgenda"))
            oReporte.SetParameterValue("XClientesFueraAgenda", oMensaje.RecuperarDescripcion("XClientesFueraAgenda"))

            oReporte.SetParameterValue("NUMVisitados", oMensaje.RecuperarDescripcion("XVisitados"))
            oReporte.SetParameterValue("NUMNoVisitados", oMensaje.RecuperarDescripcion("XNoVisitados"))
            oReporte.SetParameterValue("NUMTotalClientes", oMensaje.RecuperarDescripcion("XTotalClientes"))
            oReporte.SetParameterValue("VisitaEfectiva", oMensaje.RecuperarDescripcion("XVisitaEfectiva"))
            oReporte.SetParameterValue("EfectividadCompra", oMensaje.RecuperarDescripcion("XEfectividadCompra"))
            oReporte.SetParameterValue("VisitasSinVenta", oMensaje.RecuperarDescripcion("XVisitasSinVenta"))

            oReporte.SetParameterValue("NUMVisitados2", oMensaje.RecuperarDescripcion("XVisitados"))
            oReporte.SetParameterValue("EfectividadCompra2", oMensaje.RecuperarDescripcion("XEfectividadCompra"))
            oReporte.SetParameterValue("VisitasSinVenta2", oMensaje.RecuperarDescripcion("XVisitasSinVenta"))

            oReporte.SetParameterValue("XKmInicial", oMensaje.RecuperarDescripcion("XKmInicial"))
            oReporte.SetParameterValue("XKmFinal", oMensaje.RecuperarDescripcion("XKmFinal"))
            oReporte.SetParameterValue("XKmConsumido", oMensaje.RecuperarDescripcion("XKmConsumido"))
            oReporte.SetParameterValue("XPlaca", oMensaje.RecuperarDescripcion("XPlaca"))

        ElseIf Session("NumReporte") = 107 Then '--Reporte Folios
            oReporte.FileName = Server.MapPath("Reports\ReporteFolios.rpt")
            oReporte.Database.Tables(0).SetDataSource(Session("DataTable"))
            oReporte.Database.Tables(1).SetDataSource(dt)

            oReporte.SetParameterValue("NombreRep", Session("Nombre").ToString().ToUpper())
            oReporte.SetParameterValue("FSHCertificado", oMensaje.RecuperarDescripcion("FSHCertificado") + ":")
            oReporte.SetParameterValue("XVigencia", oMensaje.RecuperarDescripcion("XVigencia") + ":")
            oReporte.SetParameterValue("XCentroDistribucion", oMensaje.RecuperarDescripcion("XCentroDistribucion") + ":")
            oReporte.SetParameterValue("XFecha", oMensaje.RecuperarDescripcion("XFecha") + ":")
            oReporte.SetParameterValue("XSerie", oMensaje.RecuperarDescripcion("XSerie"))
            oReporte.SetParameterValue("XTipoDoc", oMensaje.RecuperarDescripcion("XTipoDoc"))
            oReporte.SetParameterValue("XVendedor", oMensaje.RecuperarDescripcion("XVendedor"))
            oReporte.SetParameterValue("XFolioInicial", oMensaje.RecuperarDescripcion("XFolioInicial"))
            oReporte.SetParameterValue("XFolioFinal", oMensaje.RecuperarDescripcion("XFolioFinal"))
            oReporte.SetParameterValue("XFolioActual", oMensaje.RecuperarDescripcion("XFolioActual"))
            oReporte.SetParameterValue("XUsadosUltimaSemana", oMensaje.RecuperarDescripcion("XUsadosUltimaSemana"))
            oReporte.SetParameterValue("XPromUsoDiarioUltimaSemana", "Prom. Uso Diario Ultima Semana") 'oMensaje.RecuperarDescripcion("XPromedioUsoDiarioUltimaSemana"))
            oReporte.SetParameterValue("FSHFolios", oMensaje.RecuperarDescripcion("FSHFolios"))
            oReporte.SetParameterValue("XDiasFoliosDisponibles", oMensaje.RecuperarDescripcion("XDiasFoliosDisponibles"))
            oReporte.SetParameterValue("XNoAprobacion", oMensaje.RecuperarDescripcion("XNoAprobacion"))
            oReporte.SetParameterValue("XAnioAprobacion", oMensaje.RecuperarDescripcion("XAnioAprobacion"))
            oReporte.SetParameterValue("XStatus", oMensaje.RecuperarDescripcion("XStatus"))

            oReporte.SetParameterValue("XNota", oMensaje.RecuperarDescripcion("XNota"))
            oReporte.SetParameterValue("XFACFactura", oMensaje.RecuperarDescripcion("XFACFactura"))
            oReporte.SetParameterValue("XNCRNotaCredito", oMensaje.RecuperarDescripcion("XNCRNotaCredito"))
            oReporte.SetParameterValue("XFechaHoraImpresion", oMensaje.RecuperarDescripcion("XFechaHoraImpresion"))

            oReporte.SetParameterValue("XEnUso", oMensaje.RecuperarDescripcion("XEnUso"))
            oReporte.SetParameterValue("XCerrado", oMensaje.RecuperarDescripcion("XCerrado"))
            oReporte.SetParameterValue("XNoUsado", oMensaje.RecuperarDescripcion("XNoUsado"))

        End If


        If Session("NumReporte") <> 57 And Session("NumReporte") <> 58 Then
            'ins.Desconectar()
        End If

        If Not (Session("NumReporte") = 8 Or Session("NumReporte") = 18 Or Session("NumReporte") = 36 Or Session("NumReporte") = 26 Or Session("NumReporte") = 34 Or Session("NumReporte") = 40 Or Session("NumReporte") = 44 Or Session("NumReporte") = 49 Or Session("NumReporte") = 51 Or Session("NumReporte") = 52 Or Session("NumReporte") = 53 Or Session("NumReporte") = 57 Or Session("NumReporte") = 58 Or Session("NumReporte") = 59 Or Session("NumReporte") = 60 Or Session("NumReporte") = 62) Then
            oReporte.SetParameterValue("EnviadoCEDI", Session("CEDI").ToString())
        End If

        Dim oStream As New System.IO.MemoryStream
        Dim FileSize As Long
        ' Dim GenDS As Data.DataSet
        Dim oDest As New CrystalDecisions.Shared.DiskFileDestinationOptions()

        Try
            '******************************
            'Para ver los parámetros faltantes

            'Dim s As String = String.Empty
            'Dim i As Integer = 0
            'For Each p As CrystalDecisions.Shared.ParameterField In oReporte.ParameterFields
            '    If Not p.HasCurrentValue AndAlso Not p.Name.StartsWith("Pm") Then
            '        'If Not p.HasCurrentValue Then
            '        i += 1
            '        s &= p.Name & vbLf
            '    End If
            'Next
            'If i > 0 Then
            '    System.Diagnostics.Debug.WriteLine(i)
            '    System.Diagnostics.Debug.WriteLine(s)
            'End If
            '******************************
            If (Session("Formato") = 1) Or (Session("Formato") = "") Then
                'If Session("NumReporte") <> 3 And Session("NumReporte") <> 16 Then 'Efectividad por Ruta y Ventas Totales por Ruta


                'rvwReporte.PrintMode = CrystalDecisions.Web.PrintMode.Pdf
                CrystalReportViewer1.Enabled = True
                CrystalReportViewer1.EnableDrillDown = True

                CrystalReportViewer1.HasExportButton = True
                CrystalReportViewer1.HasPrintButton = True
                CrystalReportViewer1.ReportSource = oReporte
                'CrystalReportViewer1.RefreshReport()


            ElseIf (Session("Formato") = 2) Then


                Response.Clear()
                Response.Buffer = True
                Response.AddHeader("Content-Type", "application/pdf")
                Response.AddHeader("Content-Disposition", "attachment;filename=" + Session("nombre") + DateTime.Now.ToString("s") + ".pdf;")


                Dim fs As IO.MemoryStream
                fs = oReporte.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat)

                FileSize = fs.Length
                Dim bBuffer(CInt(FileSize)) As Byte
                fs.Read(bBuffer, 0, CInt(FileSize))
                fs.Close()

                Response.BinaryWrite(bBuffer)
                Response.Flush()
                Response.Close()

                oReporte.Dispose()
                fs.Dispose()
            ElseIf (Session("Formato") = 3) Then
                Response.Clear()
                Response.Buffer = True
                Response.AddHeader("Content-Type", "application/ms-word")
                Response.AddHeader("Content-Disposition", "attachment;filename=" + Session("nombre") + DateTime.Now.ToString("s") + ".doc;")


                Dim fs As IO.MemoryStream
                fs = oReporte.ExportToStream(CrystalDecisions.Shared.ExportFormatType.WordForWindows)

                FileSize = fs.Length
                Dim bBuffer(CInt(FileSize)) As Byte
                fs.Read(bBuffer, 0, CInt(FileSize))
                fs.Close()

                Response.BinaryWrite(bBuffer)
                Response.Flush()
                Response.Close()

                oReporte.Dispose()
                fs.Dispose()



            ElseIf (Session("Formato") = 4) Then

                Response.Clear()
                Response.Buffer = True
                Response.AddHeader("Content-Type", "application/vnd.ms-excel")
                Response.AddHeader("Content-Disposition", "attachment;filename=" + Session("nombre") + DateTime.Now.ToString("s") + ".xls;")


                Dim fs As IO.MemoryStream
                fs = oReporte.ExportToStream(CrystalDecisions.Shared.ExportFormatType.Excel)

                FileSize = fs.Length
                Dim bBuffer(CInt(FileSize)) As Byte
                fs.Read(bBuffer, 0, CInt(FileSize))
                fs.Close()

                Response.BinaryWrite(bBuffer)
                Response.Flush()
                Response.Close()

                oReporte.Dispose()
                fs.Dispose()

            ElseIf (Session("Formato") = 5) Then


                '-------------------------------
                Response.Clear()
                Response.Buffer = True
                Response.AddHeader("Content-Type", "application/vnd.ms-excel") '2003
                'Response.AddHeader("Content-Type", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet") '2007
                Response.AddHeader("Content-Disposition", "attachment;filename=" + Session("nombre") + DateTime.Now.ToString("s") + ".xls")

                Dim fs As IO.MemoryStream
                fs = oReporte.ExportToStream(CrystalDecisions.Shared.ExportFormatType.ExcelRecord)

                FileSize = fs.Length
                Dim bBuffer(CInt(FileSize)) As Byte
                fs.Read(bBuffer, 0, CInt(FileSize))
                fs.Close()

                Response.BinaryWrite(bBuffer)
                Response.Flush()
                Response.Close()

                oReporte.Dispose()
                fs.Dispose()
            ElseIf (Session("Formato") = 7) Then
                If Session("NumReporte") = 51 Then
                    Dim dtClientes As Data.DataTable = Session("ClientesEncuestados")
                    Dim dtEncuestas As Data.DataTable = Session("EncuestasAplicadas")
                    ExportarEncuestasExcel(dtClientes, dtEncuestas)
                ElseIf Session("NumReporte") = 57 Then
                    ResumenVentasRutaVendedor(ins)

                ElseIf Session("NumReporte") = 58 Then
                    ResumenVentasCliente(ins)

                End If
            End If
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine(ex.Message())
        End Try
        Session("Bloqueado") = False
    End Sub

    Private Sub ExportarEncuestasExcel(ByVal dtClientes As Data.DataTable, ByVal dtEncuestas As Data.DataTable)
        Try
            Response.Clear()

            Response.Buffer = True
            Response.ContentEncoding = System.Text.Encoding.Default
            'Response.AddHeader("Content-Type", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet") '2007
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
            'Response.AddHeader("Content-Disposition", "attachment;filename=" + Session("nombre") + DateTime.Now.ToString("s") + ".xlsx")
            'Response.ContentType = "aplicación/vnd.ms-excel" '2003
            Response.AddHeader("Content-Disposition", "attachment;filename=" + Session("nombre") + DateTime.Now.ToString("s") + ".xls")

            Dim fs As New IO.MemoryStream
            Dim w As IO.StreamWriter = New IO.StreamWriter(fs, System.Text.Encoding.Default)
            Dim oMensaje As New DBConexion.cMensaje
            Dim drEncuestas() As Data.DataRow
            Dim sRegistro As String = ""

            sRegistro = Session("EncuestaNombre")
            w.WriteLine("{0}", sRegistro)

            sRegistro = Session("EncuestaTipo")
            w.WriteLine("{0}", sRegistro)

            sRegistro = ""

            For Each oColCliente As Data.DataColumn In dtClientes.Columns
                If oColCliente.ColumnName <> "ENCId" Then
                    sRegistro &= oMensaje.RecuperarDescripcion("EEA" & oColCliente.ColumnName) & vbTab
                    'sRegistro &= oColCliente.ColumnName & vbTab
                End If
            Next
            drEncuestas = dtEncuestas.Select("ENCId = '" & dtClientes.Rows(0)("ENCId") & "'")
            For Each drEncuesta As Data.DataRow In drEncuestas
                sRegistro &= drEncuesta("Pregunta") & vbTab
            Next
            w.WriteLine("{0}", sRegistro)

            Dim aStr As String = ""

            For Each drCliente As Data.DataRow In dtClientes.Rows
                sRegistro = ""
                drEncuestas = dtEncuestas.Select("ENCId = '" & drCliente("ENCId") & "'")
                For Each oColCliente As Data.DataColumn In dtClientes.Columns
                    If oColCliente.ColumnName <> "ENCId" Then
                        aStr = """" + drCliente(oColCliente.ColumnName).ToString().Trim().Replace("""", "'") + """"
                        sRegistro &= aStr & vbTab
                    End If
                Next
                For Each drEncuesta As Data.DataRow In drEncuestas
                    aStr = drEncuesta("Respuesta").ToString().Trim().Replace("""", "'")
                    sRegistro &= aStr & vbTab
                Next
                w.WriteLine("{0}", sRegistro.Trim())
            Next
            w.Close()
            Response.BinaryWrite(fs.ToArray)
            Response.Flush()
            Response.Close()
            fs.Dispose()
            w.Dispose()
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine(ex.Message())
        End Try
    End Sub

    Private Sub ResumenVentasRutaVendedor(ByVal ins As DBConexion.cConexionSQL)
        Try
            Dim dtVendedores As Data.DataTable
            Dim dtProductos As Data.DataTable
            Dim dtEsquemas As Data.DataTable
            Dim dtContenidos As Data.DataTable
            Dim dtTotales As Data.DataTable
            Dim dtAbonoCredito As Data.DataTable
            Dim dtAbonoTotal As Data.DataTable
            Dim dtListaPrecios As Data.DataTable
            Dim oMensaje As New DBConexion.cMensaje

            dtVendedores = Session("RutaVendedor")
            dtProductos = ins.EjecutarConsulta(Session("Productos"), IntCommandTimeOut)
            dtEsquemas = ins.EjecutarConsulta(Session("Esquemas"), IntCommandTimeOut)
            dtContenidos = ins.EjecutarConsulta(Session("Contenidos"), IntCommandTimeOut)
            dtTotales = ins.EjecutarConsulta(Session("Totales"), IntCommandTimeOut)
            dtAbonoCredito = ins.EjecutarConsulta(Session("AbonoCredito"), IntCommandTimeOut)
            dtAbonoTotal = ins.EjecutarConsulta(Session("AbonoTotal"), IntCommandTimeOut)
            dtListaPrecios = ins.EjecutarConsulta(Session("ListaPrecios"), IntCommandTimeOut)

            Response.Clear()
            Response.Buffer = True
            Response.ContentEncoding = System.Text.Encoding.Default
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
            Response.AddHeader("Content-Disposition", "attachment;filename=" + Session("nombre") + DateTime.Now.ToString("s") + ".xls")

            'Generar Columnas
            Dim dtFinal As New Data.DataTable
            dtFinal.Columns.Add("CEDI", GetType(String))
            dtFinal.Columns.Add("Ruta", GetType(String))
            dtFinal.Columns.Add("VendedorId", GetType(String))
            dtFinal.Columns.Add("Vendedor", GetType(String))
            'Productos
            Dim drCols() As Data.DataRow = dtProductos.Select("Contenido = 0 and Promocion = 0", "ProductoClave")
            Dim sCol As String = ""
            For Each dr As Data.DataRow In drCols
                If dr("ProductoClave") <> sCol Then
                    'dtFinal.Columns.Add(dr("ProductoClave"), System.Type.GetType("Int64"))
                    dtFinal.Columns.Add("Nom_" & dr("ProductoClave"), GetType(Int64))
                    dtFinal.Columns(dtFinal.Columns.Count - 1).Caption = dr("Nombre")
                    sCol = dr("ProductoClave")
                End If
            Next
            'Contenidos
            drCols = dtProductos.Select("Contenido = 1 and Promocion = 0", "ProductoClave")
            sCol = ""
            For Each dr As Data.DataRow In drCols
                If dr("ProductoClave") <> sCol Then
                    dtFinal.Columns.Add("NomCont_" & dr("ProductoClave"), GetType(Int64))
                    dtFinal.Columns(dtFinal.Columns.Count - 1).Caption = oMensaje.RecuperarDescripcion("VRVEnvase") & " " & dr("Nombre")
                    sCol = dr("ProductoClave")
                End If
            Next
            'Promociones
            drCols = dtProductos.Select("Promocion = 1", "ProductoClave")
            sCol = ""
            For Each dr As Data.DataRow In drCols
                If dr("ProductoClave") <> sCol Then
                    dtFinal.Columns.Add("NomProm_" & dr("ProductoClave"), GetType(Int64))
                    dtFinal.Columns(dtFinal.Columns.Count - 1).Caption = oMensaje.RecuperarDescripcion("VRVPromocion") & " " & dr("Nombre")
                    sCol = dr("ProductoClave")
                End If
            Next
            'Esquemas
            sCol = ""
            For Each dr As Data.DataRow In dtEsquemas.Rows
                If dr("EsquemaId") <> sCol Then
                    dtFinal.Columns.Add("NomEsq_" & dr("EsquemaId"), GetType(Int64))
                    dtFinal.Columns(dtFinal.Columns.Count - 1).Caption = dr("Nombre")
                    sCol = dr("EsquemaId")
                End If
            Next
            dtFinal.Columns.Add("DevolucionEnvase", GetType(Int64))
            dtFinal.Columns.Add("VentaEnvase", GetType(Int64))
            dtFinal.Columns.Add("ImporteVenta", GetType(Double))
            dtFinal.Columns.Add("ImporteDescuento", GetType(Double))
            dtFinal.Columns.Add("PorcDescuento", GetType(Double))
            dtFinal.Columns.Add("SubTotal", GetType(Double))
            dtFinal.Columns.Add("Credito", GetType(Double))
            dtFinal.Columns.Add("AbonoCredito", GetType(Double))
            dtFinal.Columns.Add("TotalCobrado", GetType(Double))
            dtFinal.Columns.Add("ListaPrecios", GetType(String))

            'Agregar Registros
            For Each drRutVen As Data.DataRow In dtVendedores.Rows
                Dim drNueva As Data.DataRow = dtFinal.NewRow
                drNueva("CEDI") = drRutVen("ClaveCEDI")
                drNueva("Ruta") = drRutVen("RUTClave")
                drNueva("VendedorId") = drRutVen("VendedorId")
                drNueva("Vendedor") = drRutVen("Nombre")
                'Productos
                drCols = dtProductos.Select("Contenido = 0 and Promocion = 0 and ClaveCEDI = '" & drRutVen("ClaveCEDI") & "' and RUTClave = '" & drRutVen("RUTClave") & "' and VendedorId = '" & drRutVen("VendedorId") & "'", "ProductoClave")
                For Each dr As Data.DataRow In drCols
                    drNueva("Nom_" & dr("ProductoClave")) = dr("Cantidad")
                Next
                'Contenidos
                drCols = dtProductos.Select("Contenido = 1 and Promocion = 0 and ClaveCEDI = '" & drRutVen("ClaveCEDI") & "' and RUTClave = '" & drRutVen("RUTClave") & "' and VendedorId = '" & drRutVen("VendedorId") & "'", "ProductoClave")
                For Each dr As Data.DataRow In drCols
                    drNueva("NomCont_" & dr("ProductoClave")) = dr("Cantidad")
                Next
                'Promociones
                drCols = dtProductos.Select("Promocion = 1 and ClaveCEDI = '" & drRutVen("ClaveCEDI") & "' and RUTClave = '" & drRutVen("RUTClave") & "' and VendedorId = '" & drRutVen("VendedorId") & "'", "ProductoClave")
                For Each dr As Data.DataRow In drCols
                    drNueva("NomProm_" & dr("ProductoClave")) = dr("Cantidad")
                Next
                'Esquemas
                drCols = dtEsquemas.Select("ClaveCEDI = '" & drRutVen("ClaveCEDI") & "' and RUTClave = '" & drRutVen("RUTClave") & "' and VendedorId = '" & drRutVen("VendedorId") & "'")
                For Each dr As Data.DataRow In drCols
                    drNueva("NomEsq_" & dr("EsquemaId")) = dr("Cantidad")
                Next
                drCols = dtContenidos.Select("ClaveCEDI = '" & drRutVen("ClaveCEDI") & "' and RUTClave = '" & drRutVen("RUTClave") & "' and VendedorId = '" & drRutVen("VendedorId") & "'")
                If drCols.Length > 0 Then
                    drNueva("DevolucionEnvase") = drCols(0)("CantidadDev")
                    drNueva("VentaEnvase") = drCols(0)("CantidadVta")
                End If
                drCols = dtTotales.Select("ClaveCEDI = '" & drRutVen("ClaveCEDI") & "' and RUTClave = '" & drRutVen("RUTClave") & "' and VendedorId = '" & drRutVen("VendedorId") & "'")
                If drCols.Length > 0 Then
                    drNueva("ImporteVenta") = drCols(0)("Venta")
                    drNueva("ImporteDescuento") = drCols(0)("Descuento")
                    drNueva("PorcDescuento") = drCols(0)("PorcentajeDescuento")
                    drNueva("SubTotal") = drCols(0)("SubTotal")
                    drNueva("Credito") = drCols(0)("VentaCredito")
                End If
                drCols = dtAbonoCredito.Select("ClaveCEDI = '" & drRutVen("ClaveCEDI") & "' and RUTClave = '" & drRutVen("RUTClave") & "' and VendedorId = '" & drRutVen("VendedorId") & "'")
                If drCols.Length > 0 Then
                    drNueva("AbonoCredito") = drCols(0)("AbonoCredito")
                End If
                drCols = dtAbonoTotal.Select("ClaveCEDI = '" & drRutVen("ClaveCEDI") & "' and RUTClave = '" & drRutVen("RUTClave") & "' and VendedorId = '" & drRutVen("VendedorId") & "'")
                If drCols.Length > 0 Then
                    drNueva("TotalCobrado") = drCols(0)("AbonoTotal")
                End If
                drCols = dtListaPrecios.Select("ClaveCEDI = '" & drRutVen("ClaveCEDI") & "' and RUTClave = '" & drRutVen("RUTClave") & "' and VendedorId = '" & drRutVen("VendedorId") & "'")
                Dim sPrecios As String = ""
                For Each dr As Data.DataRow In drCols
                    sPrecios = dr("PCEPrecioClave") & ", "
                Next
                If sPrecios.Length > 0 Then
                    sPrecios = sPrecios.Remove(sPrecios.Length - 2, 2)
                End If
                drNueva("ListaPrecios") = sPrecios
                dtFinal.Rows.Add(drNueva)
            Next

            'Crear el archivo XML
            Dim fs As New IO.MemoryStream
            Dim w As IO.StreamWriter = New IO.StreamWriter(fs, System.Text.Encoding.Default)
            Dim sRegistro As String = ""

            w.WriteLine("{0}", Session("NombreEmpresa"))
            w.WriteLine("{0}", Session("Nombre"))
            w.WriteLine("{0}", oMensaje.RecuperarDescripcion("XFecha") & ": " & Session("RangoFechas"))
            w.WriteLine()
            w.WriteLine()

            'Columnas
            For Each oCol As Data.DataColumn In dtFinal.Columns
                If oCol.ColumnName <> "VendedorId" And oCol.ColumnName <> "CEDI" Then
                    If oCol.ColumnName.StartsWith("Nom_") Or oCol.ColumnName.StartsWith("NomCont_") Or oCol.ColumnName.StartsWith("NomProm_") Or oCol.ColumnName.StartsWith("NomEsq_") Then
                        sRegistro &= oCol.Caption & vbTab
                    Else
                        sRegistro &= oMensaje.RecuperarDescripcion("VRV" & oCol.ColumnName) & vbTab
                    End If
                End If
            Next
            w.WriteLine("{0}", sRegistro)
            'w.WriteLine()

            'Renglones
            Dim sCEDI As String = ""
            Dim sTotales As String = ""
            Dim nTotal As Object
            For Each drRutVen As Data.DataRow In dtVendedores.Rows
                If sCEDI <> drRutVen("ClaveCEDI") Then
                    If sCEDI <> "" Then
                        sTotales = ""
                        For Each dc As Data.DataColumn In dtFinal.Columns
                            If dc.DataType.ToString <> "System.String" Then
                                If dc.ColumnName = "PorcDescuento" Then
                                    nTotal = dtFinal.Compute("sum(ImporteDescuento)/sum(ImporteVenta)*100", "CEDI = '" & sCEDI & "'")
                                Else
                                    nTotal = dtFinal.Compute("sum(" & dc.ColumnName & ")", "CEDI = '" & sCEDI & "'")
                                End If
                                sTotales &= nTotal & vbTab
                            ElseIf dc.ColumnName <> "VendedorId" And dc.ColumnName <> "CEDI" Then
                                sTotales &= vbTab
                            End If
                        Next
                        w.WriteLine("{0}", oMensaje.RecuperarDescripcion("XTotalPorCEDI") & sTotales)
                        w.WriteLine()
                    End If
                    w.WriteLine()
                    w.WriteLine("{0}", oMensaje.RecuperarDescripcion("XCentroDistribucion") & ": " & drRutVen("ClaveCEDI") & " " & drRutVen("ALMNombre"))
                    sCEDI = drRutVen("ClaveCEDI")
                End If

                drCols = dtFinal.Select("CEDI = '" & drRutVen("ClaveCEDI") & "' and Ruta = '" & drRutVen("RUTClave") & "' and VendedorId = '" & drRutVen("VendedorId") & "'")
                For Each dr As Data.DataRow In drCols
                    sRegistro = ""
                    For Each dc As Data.DataColumn In dtFinal.Columns
                        If dc.ColumnName <> "VendedorId" And dc.ColumnName <> "CEDI" Then
                            sRegistro &= dr(dc.ColumnName) & vbTab
                        End If
                    Next
                    w.WriteLine("{0}", sRegistro)
                Next

            Next
            If sCEDI <> "" Then
                sTotales = ""
                For Each dc As Data.DataColumn In dtFinal.Columns
                    If dc.DataType.ToString <> "System.String" Then
                        If dc.ColumnName = "PorcDescuento" Then
                            nTotal = dtFinal.Compute("sum(ImporteDescuento)/sum(ImporteVenta)*100", "CEDI = '" & sCEDI & "'")
                        Else
                            nTotal = dtFinal.Compute("sum(" & dc.ColumnName & ")", "CEDI = '" & sCEDI & "'")
                        End If
                        sTotales &= nTotal & vbTab
                    ElseIf dc.ColumnName <> "VendedorId" And dc.ColumnName <> "CEDI" Then
                        sTotales &= vbTab
                    End If
                Next
                w.WriteLine("{0}", oMensaje.RecuperarDescripcion("XTotalPorCEDI") & sTotales)
                w.WriteLine()
            End If

            'ins.Desconectar()
            w.Close()
            Response.BinaryWrite(fs.ToArray)
            Response.Flush()
            Response.Close()
            fs.Dispose()
            w.Dispose()
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine(ex.Message())
        End Try
    End Sub

    Private Sub ResumenVentasCliente(ByVal ins As DBConexion.cConexionSQL)
        Try
            Dim dtVendedores As Data.DataTable
            Dim dtProductos As Data.DataTable
            Dim dtEsquemas As Data.DataTable
            Dim dtContenidos As Data.DataTable
            Dim dtTotales As Data.DataTable
            Dim dtAbonoCredito As Data.DataTable
            Dim dtAbonoTotal As Data.DataTable
            Dim dtListaPrecios As Data.DataTable
            Dim oMensaje As New DBConexion.cMensaje

            dtVendedores = Session("RutaVendedor")
            dtProductos = ins.EjecutarConsulta(Session("Productos"), IntCommandTimeOut)
            dtEsquemas = ins.EjecutarConsulta(Session("Esquemas"), IntCommandTimeOut)
            dtContenidos = ins.EjecutarConsulta(Session("Contenidos"), IntCommandTimeOut)
            dtTotales = ins.EjecutarConsulta(Session("Totales"), IntCommandTimeOut)
            dtAbonoCredito = ins.EjecutarConsulta(Session("AbonoCredito"), IntCommandTimeOut)
            dtAbonoTotal = ins.EjecutarConsulta(Session("AbonoTotal"), IntCommandTimeOut)
            dtListaPrecios = ins.EjecutarConsulta(Session("ListaPrecios"), IntCommandTimeOut)

            Response.Clear()
            Response.Buffer = True
            Response.ContentEncoding = System.Text.Encoding.Default
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
            Response.AddHeader("Content-Disposition", "attachment;filename=" + Session("nombre") + DateTime.Now.ToString("s") + ".xls")

            'Generar Columnas
            Dim dtFinal As New Data.DataTable
            dtFinal.Columns.Add("CEDI", GetType(String))
            dtFinal.Columns.Add("Ruta", GetType(String))
            dtFinal.Columns.Add("Vendedor", GetType(String))
            dtFinal.Columns.Add("ClienteClave", GetType(String))
            dtFinal.Columns.Add("CLIClave", GetType(String))
            dtFinal.Columns.Add("CLINombre", GetType(String))
            'Productos
            Dim drCols() As Data.DataRow = dtProductos.Select("Contenido = 0 and Promocion = 0", "ProductoClave")
            Dim sCol As String = ""
            For Each dr As Data.DataRow In drCols
                If dr("ProductoClave") <> sCol Then
                    'dtFinal.Columns.Add(dr("ProductoClave"), System.Type.GetType("Int64"))
                    dtFinal.Columns.Add("Nom_" & dr("ProductoClave"), GetType(Int64))
                    dtFinal.Columns(dtFinal.Columns.Count - 1).Caption = dr("Nombre")
                    sCol = dr("ProductoClave")
                End If
            Next
            'Contenidos
            drCols = dtProductos.Select("Contenido = 1 and Promocion = 0", "ProductoClave")
            sCol = ""
            For Each dr As Data.DataRow In drCols
                If dr("ProductoClave") <> sCol Then
                    dtFinal.Columns.Add("NomCont_" & dr("ProductoClave"), GetType(Int64))
                    dtFinal.Columns(dtFinal.Columns.Count - 1).Caption = oMensaje.RecuperarDescripcion("VRVEnvase") & " " & dr("Nombre")
                    sCol = dr("ProductoClave")
                End If
            Next
            'Promociones
            drCols = dtProductos.Select("Promocion = 1", "ProductoClave")
            sCol = ""
            For Each dr As Data.DataRow In drCols
                If dr("ProductoClave") <> sCol Then
                    dtFinal.Columns.Add("NomProm_" & dr("ProductoClave"), GetType(Int64))
                    dtFinal.Columns(dtFinal.Columns.Count - 1).Caption = oMensaje.RecuperarDescripcion("VRVPromocion") & " " & dr("Nombre")
                    sCol = dr("ProductoClave")
                End If
            Next
            'Esquemas
            sCol = ""
            For Each dr As Data.DataRow In dtEsquemas.Rows
                If dr("EsquemaId") <> sCol Then
                    dtFinal.Columns.Add("NomEsq_" & dr("EsquemaId"), GetType(Int64))
                    dtFinal.Columns(dtFinal.Columns.Count - 1).Caption = dr("Nombre")
                    sCol = dr("EsquemaId")
                End If
            Next
            dtFinal.Columns.Add("DevolucionEnvase", GetType(Int64))
            dtFinal.Columns.Add("VentaEnvase", GetType(Int64))
            dtFinal.Columns.Add("ImporteVenta", GetType(Double))
            dtFinal.Columns.Add("ImporteDescuento", GetType(Double))
            dtFinal.Columns.Add("PorcDescuento", GetType(Double))
            dtFinal.Columns.Add("SubTotal", GetType(Double))
            dtFinal.Columns.Add("Credito", GetType(Double))
            dtFinal.Columns.Add("AbonoCredito", GetType(Double))
            dtFinal.Columns.Add("TotalCobrado", GetType(Double))
            dtFinal.Columns.Add("ListaPrecios", GetType(String))

            'Agregar Registros
            For Each drRutVen As Data.DataRow In dtVendedores.Rows
                Dim drNueva As Data.DataRow = dtFinal.NewRow
                drNueva("CEDI") = drRutVen("ClaveCEDI")
                drNueva("Ruta") = drRutVen("RUTClave")
                drNueva("Vendedor") = drRutVen("VendedorId")
                'drNueva("Vendedor") = drRutVen("Nombre")
                drNueva("ClienteClave") = drRutVen("ClienteClave")
                drNueva("CLIClave") = drRutVen("CLIClave")
                drNueva("CLINombre") = drRutVen("CLINombre")

                'Productos
                drCols = dtProductos.Select("Contenido = 0 and Promocion = 0 and ClaveCEDI = '" & drRutVen("ClaveCEDI") & "' and RUTClave = '" & drRutVen("RUTClave") & "' and VendedorId = '" & drRutVen("VendedorId") & "' and ClienteClave = '" & drRutVen("ClienteClave") & "'", "ProductoClave")
                For Each dr As Data.DataRow In drCols
                    drNueva("Nom_" & dr("ProductoClave")) = dr("Cantidad")
                Next
                'Contenidos
                drCols = dtProductos.Select("Contenido = 1 and Promocion = 0 and ClaveCEDI = '" & drRutVen("ClaveCEDI") & "' and RUTClave = '" & drRutVen("RUTClave") & "' and VendedorId = '" & drRutVen("VendedorId") & "' and ClienteClave = '" & drRutVen("ClienteClave") & "'", "ProductoClave")
                For Each dr As Data.DataRow In drCols
                    drNueva("NomCont_" & dr("ProductoClave")) = dr("Cantidad")
                Next
                'Promociones
                drCols = dtProductos.Select("Promocion = 1 and ClaveCEDI = '" & drRutVen("ClaveCEDI") & "' and RUTClave = '" & drRutVen("RUTClave") & "' and VendedorId = '" & drRutVen("VendedorId") & "' and ClienteClave = '" & drRutVen("ClienteClave") & "'", "ProductoClave")
                For Each dr As Data.DataRow In drCols
                    drNueva("NomProm_" & dr("ProductoClave")) = dr("Cantidad")
                Next
                'Esquemas
                drCols = dtEsquemas.Select("ClaveCEDI = '" & drRutVen("ClaveCEDI") & "' and RUTClave = '" & drRutVen("RUTClave") & "' and VendedorId = '" & drRutVen("VendedorId") & "' and ClienteClave = '" & drRutVen("ClienteClave") & "'")
                For Each dr As Data.DataRow In drCols
                    drNueva("NomEsq_" & dr("EsquemaId")) = dr("Cantidad")
                Next
                'Contenidos
                drCols = dtContenidos.Select("ClaveCEDI = '" & drRutVen("ClaveCEDI") & "' and RUTClave = '" & drRutVen("RUTClave") & "' and VendedorId = '" & drRutVen("VendedorId") & "' and ClienteClave = '" & drRutVen("ClienteClave") & "'")
                If drCols.Length > 0 Then
                    drNueva("DevolucionEnvase") = drCols(0)("CantidadDev")
                    drNueva("VentaEnvase") = drCols(0)("CantidadVta")
                End If
                'Totales
                drCols = dtTotales.Select("ClaveCEDI = '" & drRutVen("ClaveCEDI") & "' and RUTClave = '" & drRutVen("RUTClave") & "' and VendedorId = '" & drRutVen("VendedorId") & "' and ClienteClave = '" & drRutVen("ClienteClave") & "'")
                If drCols.Length > 0 Then
                    drNueva("ImporteVenta") = drCols(0)("Venta")
                    drNueva("ImporteDescuento") = drCols(0)("Descuento")
                    drNueva("PorcDescuento") = drCols(0)("PorcentajeDescuento")
                    drNueva("SubTotal") = drCols(0)("SubTotal")
                    drNueva("Credito") = drCols(0)("VentaCredito")
                End If
                'Abono Creditos
                drCols = dtAbonoCredito.Select("ClaveCEDI = '" & drRutVen("ClaveCEDI") & "' and RUTClave = '" & drRutVen("RUTClave") & "' and VendedorId = '" & drRutVen("VendedorId") & "' and ClienteClave = '" & drRutVen("ClienteClave") & "'")
                If drCols.Length > 0 Then
                    drNueva("AbonoCredito") = drCols(0)("AbonoCredito")
                End If
                'Abono Total
                drCols = dtAbonoTotal.Select("ClaveCEDI = '" & drRutVen("ClaveCEDI") & "' and RUTClave = '" & drRutVen("RUTClave") & "' and VendedorId = '" & drRutVen("VendedorId") & "' and ClienteClave = '" & drRutVen("ClienteClave") & "'")
                If drCols.Length > 0 Then
                    drNueva("TotalCobrado") = drCols(0)("AbonoTotal")
                End If
                'Lista Precios
                drCols = dtListaPrecios.Select("ClaveCEDI = '" & drRutVen("ClaveCEDI") & "' and RUTClave = '" & drRutVen("RUTClave") & "' and VendedorId = '" & drRutVen("VendedorId") & "' and ClienteClave = '" & drRutVen("ClienteClave") & "'")
                Dim sPrecios As String = ""
                For Each dr As Data.DataRow In drCols
                    sPrecios = dr("PCEPrecioClave") & ", "
                Next
                If sPrecios.Length > 0 Then
                    sPrecios = sPrecios.Remove(sPrecios.Length - 2, 2)
                End If
                drNueva("ListaPrecios") = sPrecios
                dtFinal.Rows.Add(drNueva)
            Next

            'Crear el archivo XML
            Dim fs As New IO.MemoryStream
            Dim w As IO.StreamWriter = New IO.StreamWriter(fs, System.Text.Encoding.Default)
            Dim sRegistro As String = ""

            w.WriteLine("{0}", Session("NombreEmpresa"))
            w.WriteLine("{0}", Session("Nombre"))
            w.WriteLine("{0}", oMensaje.RecuperarDescripcion("XFecha") & ": " & Session("RangoFechas"))
            w.WriteLine("{0}", oMensaje.RecuperarDescripcion("XCEDI") & ": " & Session("CEDI"))
            w.WriteLine("{0}", oMensaje.RecuperarDescripcion("XRuta") & ": " & Session("Ruta"))
            w.WriteLine("{0}", oMensaje.RecuperarDescripcion("XVendedor") & ": " & Session("Vendedor"))
            w.WriteLine("{0}", oMensaje.RecuperarDescripcion("XCategoriaCliente") & ": " & Session("NombreEsquema"))
            w.WriteLine()
            w.WriteLine()

            'Columnas
            For Each oCol As Data.DataColumn In dtFinal.Columns
                If oCol.ColumnName <> "CEDI" And oCol.ColumnName <> "Ruta" And oCol.ColumnName <> "Vendedor" And oCol.ColumnName <> "ClienteClave" Then
                    If oCol.ColumnName.StartsWith("Nom_") Or oCol.ColumnName.StartsWith("NomCont_") Or oCol.ColumnName.StartsWith("NomProm_") Or oCol.ColumnName.StartsWith("NomEsq_") Then
                        sRegistro &= oCol.Caption & vbTab
                    Else
                        sRegistro &= oMensaje.RecuperarDescripcion("RVC" & oCol.ColumnName) & vbTab
                    End If
                End If
            Next
            w.WriteLine("{0}", sRegistro)
            'w.WriteLine()

            'Renglones
            Dim sCEDI As String = ""
            'Dim sCEDIAnt As String = ""
            Dim sRuta As String = ""
            Dim sRutaAnt As String = ""
            Dim sVendedor As String = ""
            Dim sVendedorAnt As String = ""
            Dim sTotales As String = ""
            Dim nTotal As Object
            For Each drRutVen As Data.DataRow In dtVendedores.Rows
                If sVendedorAnt <> "" And sVendedor <> drRutVen("VendedorId") Then
                    sTotales = ""
                    For Each dc As Data.DataColumn In dtFinal.Columns
                        If dc.DataType.ToString <> "System.String" Then
                            If dc.ColumnName = "PorcDescuento" Then
                                nTotal = dtFinal.Compute("sum(ImporteDescuento)/sum(ImporteVenta)*100", "CEDI = '" & sCEDI & "' and Ruta = '" & sRutaAnt & "' and Vendedor = '" & sVendedorAnt & "'")
                            Else
                                nTotal = dtFinal.Compute("sum(" & dc.ColumnName & ")", "CEDI = '" & sCEDI & "' and Ruta = '" & sRutaAnt & "' and Vendedor = '" & sVendedorAnt & "'")
                            End If
                            sTotales &= nTotal & vbTab
                        ElseIf dc.ColumnName <> "Vendedor" And dc.ColumnName <> "CEDI" And dc.ColumnName <> "Ruta" And dc.ColumnName <> "ClienteClave" Then
                            sTotales &= vbTab
                        End If
                    Next
                    w.WriteLine("{0}", oMensaje.RecuperarDescripcion("XTotalPorVendedor") & sTotales)
                End If
                If sRutaAnt <> "" And sRuta <> drRutVen("RUTClave") Then
                    sTotales = ""
                    For Each dc As Data.DataColumn In dtFinal.Columns
                        If dc.DataType.ToString <> "System.String" Then
                            If dc.ColumnName = "PorcDescuento" Then
                                nTotal = dtFinal.Compute("sum(ImporteDescuento)/sum(ImporteVenta)*100", "CEDI = '" & sCEDI & "' and Ruta = '" & sRutaAnt & "'")
                            Else
                                nTotal = dtFinal.Compute("sum(" & dc.ColumnName & ")", "CEDI = '" & sCEDI & "' and Ruta = '" & sRutaAnt & "'")
                            End If
                            sTotales &= nTotal & vbTab
                        ElseIf dc.ColumnName <> "Vendedor" And dc.ColumnName <> "CEDI" And dc.ColumnName <> "Ruta" And dc.ColumnName <> "ClienteClave" Then
                            sTotales &= vbTab
                        End If
                    Next
                    w.WriteLine("{0}", oMensaje.RecuperarDescripcion("XTotalPorRuta") & sTotales)
                End If
                If sCEDI <> "" And sCEDI <> drRutVen("ClaveCEDI") Then
                    sTotales = ""
                    For Each dc As Data.DataColumn In dtFinal.Columns
                        If dc.DataType.ToString <> "System.String" Then
                            If dc.ColumnName = "PorcDescuento" Then
                                nTotal = dtFinal.Compute("sum(ImporteDescuento)/sum(ImporteVenta)*100", "CEDI = '" & sCEDI & "'")
                            Else
                                nTotal = dtFinal.Compute("sum(" & dc.ColumnName & ")", "CEDI = '" & sCEDI & "'")
                            End If
                            sTotales &= nTotal & vbTab
                        ElseIf dc.ColumnName <> "CEDI" And dc.ColumnName <> "Ruta" And dc.ColumnName <> "Vendedor" And dc.ColumnName <> "ClienteClave" Then
                            sTotales &= vbTab
                        End If
                    Next
                    w.WriteLine("{0}", oMensaje.RecuperarDescripcion("XTotalPorCEDI") & sTotales)
                End If

                If sCEDI <> drRutVen("ClaveCEDI") Then
                    w.WriteLine()
                    w.WriteLine("{0}", oMensaje.RecuperarDescripcion("XCentroDistribucion") & ": " & drRutVen("ClaveCEDI") & " " & drRutVen("ALMNombre"))
                    sCEDI = drRutVen("ClaveCEDI")
                    sRuta = ""
                End If
                If sRuta <> drRutVen("RUTClave") Then
                    If sRuta <> "" Then w.WriteLine()
                    w.WriteLine("{0}", oMensaje.RecuperarDescripcion("XRuta") & ": " & drRutVen("RUTClave"))
                    sRuta = drRutVen("RUTClave")
                    sRutaAnt = sRuta
                    sVendedor = ""
                End If
                If sVendedor <> drRutVen("VendedorId") Then
                    If sVendedor <> "" Then w.WriteLine()
                    w.WriteLine("{0}", oMensaje.RecuperarDescripcion("XVendedor") & ": " & drRutVen("VENNombre"))
                    sVendedor = drRutVen("VendedorId")
                    sVendedorAnt = sVendedor
                End If

                drCols = dtFinal.Select("CEDI = '" & drRutVen("ClaveCEDI") & "' and Ruta = '" & drRutVen("RUTClave") & "' and Vendedor = '" & drRutVen("VendedorId") & "' and ClienteClave = '" & drRutVen("ClienteClave") & "'")
                For Each dr As Data.DataRow In drCols
                    sRegistro = ""
                    For Each dc As Data.DataColumn In dtFinal.Columns
                        If dc.ColumnName <> "CEDI" And dc.ColumnName <> "Ruta" And dc.ColumnName <> "Vendedor" And dc.ColumnName <> "ClienteClave" Then
                            sRegistro &= dr(dc.ColumnName) & vbTab
                        End If
                    Next
                    w.WriteLine("{0}", sRegistro)
                Next
            Next
            If sVendedorAnt <> "" Then
                sTotales = ""
                For Each dc As Data.DataColumn In dtFinal.Columns
                    If dc.DataType.ToString <> "System.String" Then
                        If dc.ColumnName = "PorcDescuento" Then
                            nTotal = dtFinal.Compute("sum(ImporteDescuento)/sum(ImporteVenta)*100", "CEDI = '" & sCEDI & "' and Ruta = '" & sRutaAnt & "' and Vendedor = '" & sVendedorAnt & "'")
                        Else
                            nTotal = dtFinal.Compute("sum(" & dc.ColumnName & ")", "CEDI = '" & sCEDI & "' and Ruta = '" & sRutaAnt & "' and Vendedor = '" & sVendedorAnt & "'")
                        End If
                        sTotales &= nTotal & vbTab
                    ElseIf dc.ColumnName <> "Vendedor" And dc.ColumnName <> "CEDI" And dc.ColumnName <> "Ruta" And dc.ColumnName <> "ClienteClave" Then
                        sTotales &= vbTab
                    End If
                Next
                w.WriteLine("{0}", oMensaje.RecuperarDescripcion("XTotalPorVendedor") & sTotales)
            End If
            If sRutaAnt <> "" Then
                sTotales = ""
                For Each dc As Data.DataColumn In dtFinal.Columns
                    If dc.DataType.ToString <> "System.String" Then
                        If dc.ColumnName = "PorcDescuento" Then
                            nTotal = dtFinal.Compute("sum(ImporteDescuento)/sum(ImporteVenta)*100", "CEDI = '" & sCEDI & "' and Ruta = '" & sRutaAnt & "'")
                        Else
                            nTotal = dtFinal.Compute("sum(" & dc.ColumnName & ")", "CEDI = '" & sCEDI & "' and Ruta = '" & sRutaAnt & "'")
                        End If
                        sTotales &= nTotal & vbTab
                    ElseIf dc.ColumnName <> "Vendedor" And dc.ColumnName <> "CEDI" And dc.ColumnName <> "Ruta" And dc.ColumnName <> "ClienteClave" Then
                        sTotales &= vbTab
                    End If
                Next
                w.WriteLine("{0}", oMensaje.RecuperarDescripcion("XTotalPorRuta") & sTotales)
            End If
            If sCEDI <> "" Then
                sTotales = ""
                For Each dc As Data.DataColumn In dtFinal.Columns
                    If dc.DataType.ToString <> "System.String" Then
                        If dc.ColumnName = "PorcDescuento" Then
                            nTotal = dtFinal.Compute("sum(ImporteDescuento)/sum(ImporteVenta)*100", "CEDI = '" & sCEDI & "'")
                        Else
                            nTotal = dtFinal.Compute("sum(" & dc.ColumnName & ")", "CEDI = '" & sCEDI & "'")
                        End If
                        sTotales &= nTotal & vbTab
                    ElseIf dc.ColumnName <> "CEDI" And dc.ColumnName <> "Ruta" And dc.ColumnName <> "Vendedor" And dc.ColumnName <> "ClienteClave" Then
                        sTotales &= vbTab
                    End If
                Next
                w.WriteLine("{0}", oMensaje.RecuperarDescripcion("XTotalPorCEDI") & sTotales)
            End If

            'ins.Desconectar()
            w.Close()
            Response.BinaryWrite(fs.ToArray)
            Response.Flush()
            Response.Close()
            fs.Dispose()
            w.Dispose()
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine(ex.Message())
        End Try
    End Sub

    Function Mayusculasoloprimerletra(ByVal where As String) As String

        Dim sepa() = where.Split("  ")
        where = ""
        For i As Integer = 0 To sepa.Length - 1

            sepa(i) = sepa(i)(0).ToString().ToUpper() + sepa(i).Substring(1, sepa(i).Length - 1).ToLower()
            where = where + " " + sepa(i)
        Next

        Return where.Trim()
    End Function

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        If Not IsNothing(oReporte) Then
            oReporte.Close()
            oReporte.Dispose()
            oReporteSumatoria.Close()
            oReporteSumatoria.Dispose()
            CrystalReportViewer1.Dispose()
        End If
    End Sub
   
End Class
