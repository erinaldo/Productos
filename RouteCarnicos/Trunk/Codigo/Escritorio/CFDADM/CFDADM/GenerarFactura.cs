using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;

namespace CFDADM
{
    class GenerarFactura
    {
        public enum TipoEjecucion
        {
            GenerarFactura,
            ImprimirFactura,
            GenerarFacturaNoBorra,
            CancelarFactura,
            GenerarFacturaEviarCorreoMobile
        }

        lbGeneral.cParametros  oParametros = new lbGeneral.cParametros() ;
        LbConexion.cConexion oConexion = LbConexion.cConexion.Instancia();
        BASMENLOG.CMensaje oMensaje = new BASMENLOG.CMensaje();
        ERMTRPLOG.cTransProd oTransProd;
        TipoEjecucion tipoEjecucion = TipoEjecucion.ImprimirFactura;
        bool enError = false;

        public GenerarFactura(TipoEjecucion tipo)
        {
            tipoEjecucion = tipo;
        }

        //public void CancelarFactura(string TransProdId, string RutaXML)
        //{
        //    BorrarBitacora(TransProdId, RutaXML, "3");
        //    try
        //    {
        //        lbGeneral.cParametros.TipoAplicacion = lbGeneral.TipoAplicacion.Escritorio;

        //        oParametros.CargarParametros();
        //        oConexion.Conectar(LbConexion.ModoConexion.INI);
        //        oMensaje.LlenarDataSet(lbGeneral.cParametros.Lenguaje);
        //        oTransProd = new ERMTRPLOG.cTransProd();
        //        oTransProd.Recuperar(TransProdId);

        //        ERMSEMLOG.cSubEmpresa oSubEmpresa = new ERMSEMLOG.cSubEmpresa();
        //        oSubEmpresa.Recuperar(oTransProd.SubEmpresaId);

        //        ERMTRPLOG.cTRPDatoFiscal oTrpDato = new ERMTRPLOG.cTRPDatoFiscal(ref oTransProd);
        //        oTrpDato.Recuperar(oTransProd.TransProdID);

        //        oTransProd.CancelarCFDV3Soap(oTrpDato.RFCEm, oTrpDato.UUID, oSubEmpresa);
        //    }
        //    catch (ERMTRPLOG.CFDiException ex)
        //    {
        //        CrearBitacora(TransProdId, RutaXML, ex.Codigo + " " +ex.Message, "3");
        //    }
        //    catch (Exception ex)
        //    {
        //        CrearBitacora(TransProdId, RutaXML, ex.Message, "3");
        //    }

        //}

        public void ImprimirFactura(string TransProdId, string RutaXML)
        {
            BorrarBitacora(TransProdId, RutaXML, "2");
            try
            {
                lbGeneral.cParametros.TipoAplicacion = lbGeneral.TipoAplicacion.Escritorio;

                oParametros.CargarParametros();

                oConexion.Conectar(LbConexion.ModoConexion.INI);
                oMensaje.LlenarDataSet(lbGeneral.cParametros.Lenguaje);
 
                ERMTRPESC.RRepFactElectronica oRep = new ERMTRPESC.RRepFactElectronica();
                oRep.CONSULTAR(TransProdId);
            }
            catch (LbControlError.cError ex)
            {
                //throw new Exception(ex.Mensaje);
                CrearBitacora(TransProdId, RutaXML, ex.Mensaje,"2");
            }
            catch (Exception ex)
            {
                //throw ex;
                CrearBitacora(TransProdId, RutaXML, ex.Message,"2");
            }
        }

        public void GeneraFactura(string TransProdID, string RutaXML) {
            BorrarBitacora(TransProdID, RutaXML,"1");
            try
            {               
                lbGeneral.cParametros.TipoAplicacion = lbGeneral.TipoAplicacion.Escritorio;

                oParametros.CargarParametros();
                oConexion.Conectar(LbConexion.ModoConexion.INI);
                oMensaje.LlenarDataSet(lbGeneral.cParametros.Lenguaje);
                oTransProd = new ERMTRPLOG.cTransProd();
                oTransProd.Recuperar(TransProdID);

                ERMSEMLOG.cSubEmpresa subempresa = new ERMSEMLOG.cSubEmpresa();
                subempresa.Recuperar(oTransProd.SubEmpresaId);

                //SolicitarDatosAddenda();

                ERMTRPLOG.cTRPDatoFiscal oTRPDatoFiscal = GenerarCadenaySello(TransProdID, subempresa.VersionCFD);

                string sErrorEnvio = string.Empty;
                string sErrorAddenda = string.Empty;

                if (subempresa.VersionCFD == 1 || subempresa.VersionCFD == 3)
                    oTransProd.GenerarXML(oTransProd, oTransProd.obtenerDirDocXML(oTransProd.SubEmpresaId), false, ref sErrorEnvio, ref sErrorAddenda, true);
                //else if (subempresa.VersionCFD == 2 || subempresa.VersionCFD == 4)
                //{
                //    bool crearFactura = true;
                //    try
                //    {
                //        crearFactura = !(oTRPDatoFiscal.UUID != "");
                //    }
                //    catch { }

                //    if (crearFactura)
                //    {
                //        bool sellado = false;
                //        ERMTRPLOG.CFDi oCfdi = new ERMTRPLOG.CFDi();
                //        try
                //        {
                //            oTransProd.GenerarXMLVersion3(oTransProd, oTransProd.obtenerDirDocXML(oTransProd.SubEmpresaId), false, ref sErrorEnvio, ref sErrorAddenda, ref oCfdi, ref sellado, true);
                //            GuardarCambiosCFD(oCfdi, oTRPDatoFiscal, sErrorEnvio, sErrorAddenda);
                //        }
                //        catch (Exception ex)
                //        {
                //            if ((oCfdi != null) && (oCfdi.TimbreFiscal != null) && (oCfdi.TimbreFiscal.UUID != null))
                //                GuardarCambiosCFD(oCfdi, oTRPDatoFiscal, sErrorEnvio, sErrorAddenda);
                //            else
                //                BorrarFacturaFallida(oTransProd, oTRPDatoFiscal);
                //            throw ex;
                //        }
                //    }
                //}

                ERMTRPESC.RRepFactElectronica oRep = new ERMTRPESC.RRepFactElectronica();
                oRep.CONSULTAR(TransProdID);
            }
            catch (LbControlError.cError ex)
            {
                CrearBitacora(TransProdID, RutaXML, ex.Mensaje,"1");
            }
            catch (Exception ex)
            {
                CrearBitacora(TransProdID, RutaXML, ex.Message,"1");
            }
        }

        public void GeneraFacturaEnviarXMLPDFMobile(string TransProdID, string RutaXML)
        {
            string paso = "Inicio";
            BorrarBitacora(TransProdID, RutaXML, "5");
            try
            {
                lbGeneral.cParametros.TipoAplicacion = lbGeneral.TipoAplicacion.Escritorio;
                paso = "Cargar Parametros";
                oParametros.CargarParametros();
                paso = "Conectar BD"; 
                oConexion.Conectar(LbConexion.ModoConexion.INI);
                paso = "Llenar Mensajes"; 
                oMensaje.LlenarDataSet(lbGeneral.cParametros.Lenguaje);
                paso = "Inicia Transprod"; 
                oTransProd = new ERMTRPLOG.cTransProd();
                paso = "Obtiene Transprod"; 
                oTransProd.Recuperar(TransProdID);
                paso = "Inicia Subempresa"; 
                ERMSEMLOG.cSubEmpresa subempresa = new ERMSEMLOG.cSubEmpresa();
                paso = "Obtiene Subempresa"; 
                subempresa.Recuperar(oTransProd.SubEmpresaId);
                paso = "Genera Cadena y Sello";
                ERMTRPLOG.cTRPDatoFiscal oTRPDatoFiscal = GenerarCadenaySello(TransProdID, subempresa.VersionCFD);
                
                string sErrorEnvio = string.Empty;
                string sErrorAddenda = string.Empty;
                
                ERMTRPLOG.cTransProd.cXML oXML = null;
                if (subempresa.VersionCFD == 1 || subempresa.VersionCFD == 3)
                    oTransProd.GenerarSoloXML(ref oXML, oTransProd, oTransProd.obtenerDirDocXML(oTransProd.SubEmpresaId), false, ref sErrorAddenda,true); // .GenerarXML(oTransProd, oTransProd.obtenerDirDocXML(oTransProd.SubEmpresaId), false, ref sErrorEnvio, ref sErrorAddenda, true);
                //else if (subempresa.VersionCFD == 2 || subempresa.VersionCFD == 4)
                //{
                    
                //    bool crearFactura = true;
                //    bool sellado = false;
                //    try
                //    {
                //        sellado = (oTRPDatoFiscal.UUID != "");
                //        crearFactura = !sellado;
                //    }
                //    catch { }
                    
                //        ERMTRPLOG.CFDi oCfdi = new ERMTRPLOG.CFDi();
                //        try
                //        {
                //            oTransProd.GenerarSoloXMLVersion3(ref oXML, oTransProd, oTransProd.obtenerDirDocXML(oTransProd.SubEmpresaId), ref  oCfdi, false, ref sErrorAddenda, ref sellado,true);//, false, ref sErrorEnvio, ref sErrorAddenda, ref oCfdi, ref sellado, true);
                //            if (crearFactura)
                //                GuardarCambiosCFD(oCfdi, oTRPDatoFiscal, sErrorEnvio, sErrorAddenda);
                //        }
                //        catch (Exception ex)
                //        {
                //            if ((oCfdi != null) && (oCfdi.TimbreFiscal != null) && (oCfdi.TimbreFiscal.UUID != null))
                //                GuardarCambiosCFD(oCfdi, oTRPDatoFiscal, sErrorEnvio, sErrorAddenda);
                //            else
                //                BorrarFacturaFallida(oTransProd, oTRPDatoFiscal);
                //            throw ex;
                //        }
                //}
                
                if (oXML != null)
                {
                    if (oTransProd.Tipo != 10) { 
                        ERMTRPESC.RRepFactElectronica oRep = new ERMTRPESC.RRepFactElectronica();
                        CrystalDecisions.CrystalReports.Engine.ReportClass reporte = oRep.CrearReporte(oTransProd.TransProdID);
                        reporte.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Path.Combine(oXML.Ruta, Path.GetFileNameWithoutExtension(oXML.NombreArchivo) + ".pdf"));
                    }

                    oTransProd.EnviarXML(oTransProd, oXML.Ruta, oXML.NombreArchivo, false, ref sErrorEnvio);
                }
            }
            catch (LbControlError.cError ex)
            {
                CrearBitacora(TransProdID, RutaXML, ex.Mensaje + " paso:" + paso, "5");
            }
            catch (Exception ex)
            {
                CrearBitacora(TransProdID, RutaXML, ex.Message + " paso:" + paso, "5");
            }
        }

        private void GuardarCambiosCFD(ERMTRPLOG.CFDi oCfdi, ERMTRPLOG.cTRPDatoFiscal oTRPDatoFiscal, string sErrorEnvio, string sErrorAddenda)
        {
            //if (((oCfdi != null) && (oCfdi.TimbreFiscal != null) && (oCfdi.TimbreFiscal.UUID != null)))
            //{
            //    oTRPDatoFiscal.NoCertificadoSAT = oCfdi.TimbreFiscal.noCertificadoSAT;
            //    oTRPDatoFiscal.FechaTimbrado = oCfdi.TimbreFiscal.FechaTimbrado;
            //    oTRPDatoFiscal.SelloSAT = oCfdi.TimbreFiscal.selloSAT;
            //    oTRPDatoFiscal.UUID = oCfdi.TimbreFiscal.UUID;
            //    oTRPDatoFiscal.VersionTFD = oCfdi.TimbreFiscal.version;
            //    oTRPDatoFiscal.CadenaOriginalTFD = oTransProd.CrearCadenaOriginalSello(oCfdi.TimbreFiscal);
            //    oTRPDatoFiscal.Grabar();
            //    oConexion.ConfirmarTran();
            //}
            //else
            //{
                BorrarFacturaFallida(oTransProd, oTRPDatoFiscal);
                throw new Exception(sErrorEnvio + " " + sErrorAddenda);
            //}
        }
        private void BorrarFacturaFallida(ERMTRPLOG.cTransProd oTransProd, ERMTRPLOG.cTRPDatoFiscal oTRPDatoFiscal)
        {
            if (tipoEjecucion == TipoEjecucion.GenerarFactura)
            {
                oTRPDatoFiscal.Padre = null;
                oTRPDatoFiscal.Eliminar();
                oTRPDatoFiscal.Grabar();
                oTransProd.DesAsociarVentasFactura();
                oTransProd.Eliminar();

                oTransProd.Grabar();
                ERMTRPLOG.cTransProd tVenta = new ERMTRPLOG.cTransProd();

                oConexion.ConfirmarTran();
            }
        }

        private void CrearBitacora(string NombreBitacora, string NombreDirectorio, string Error,string tipo)
        {
            NombreBitacora = "Err_" + tipo + "_" + NombreBitacora + ".txt";
            string RutaArchivo = System.IO.Path.Combine(System.IO.Path.GetFullPath(NombreDirectorio), NombreBitacora);
            //string RutaArchivo = System.IO.Path.Combine(NombreDirectorio, NombreBitacora);

            if (!System.IO.File.Exists(RutaArchivo))
            {
                FileStream stream = new FileStream(RutaArchivo, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter writer = new StreamWriter(stream);                
                writer.WriteLine(Error);
                writer.Close();
            }
        }

        private void BorrarBitacora(string NombreBitacora, string NombreDirectorio, string tipo)
        {
            NombreBitacora = "Err_" + tipo + "_" + NombreBitacora + ".txt";
            string RutaArchivo = System.IO.Path.Combine(System.IO.Path.GetFullPath(NombreDirectorio), NombreBitacora);
            //string RutaArchivo = System.IO.Path.Combine(NombreDirectorio, NombreBitacora);

            if (System.IO.File.Exists(RutaArchivo)){
                System.IO.File.Delete(RutaArchivo);
            }
        }


        private ERMTRPLOG.cTRPDatoFiscal GenerarCadenaySello(string sTransprodid, int VersionCFD)
        {

            ERMTRPLOG.cTRPDatoFiscal oTRPDatoFiscal = new ERMTRPLOG.cTRPDatoFiscal(ref oTransProd);
            oTRPDatoFiscal.Recuperar(oTransProd.TransProdID);
            oTransProd.vgTRPDatoFiscal = oTRPDatoFiscal;

            if (oTransProd.vgTRPDatoFiscal.FolioId == "")
            {
                return oTRPDatoFiscal;
            }

            if (lbGeneral.cParametros.UsuarioID == null || lbGeneral.cParametros.UsuarioID == "")
            {
                lbGeneral.cParametros.UsuarioID = oTransProd.MUsuarioID;
            }

            bool bFactura = (oTransProd.Tipo == 10 ? false : true);
            string lsCadenaOriginal = "";
            if (VersionCFD == 1 || VersionCFD == 3)
               lsCadenaOriginal = oTransProd.CrearCadenaOriginalE(bFactura,false);
                 //lsCadenaOriginal = oTransProd.CrearCadenaOriginalE(bFactura);

            else if( VersionCFD == 2 || VersionCFD == 4)
                //lsCadenaOriginal = oTransProd.CrearCadenaOriginalEV3(bFactura);
                lsCadenaOriginal = oTransProd.CrearCadenaOriginalEV3(bFactura,false);


            string lsSelloDigital = string.Empty; 
            try{
                lsSelloDigital = oTransProd.CrearSelloDigital(lsCadenaOriginal, oTransProd.SubEmpresaId);
            }catch(Exception ex){
                throw ex;
            }
            oTRPDatoFiscal.CadenaOriginal = lsCadenaOriginal;
            oTRPDatoFiscal.SelloDigital = lsSelloDigital;
            oTransProd.Grabar();
            oTRPDatoFiscal.Grabar();            
 
            oConexion.ConfirmarTran();
            return oTRPDatoFiscal;
        }

        //private void SolicitarDatosAddenda()
        //{
        //    string sClienteClave = (string) oConexion.EjecutarComandoScalar("Select VIS.ClienteClave from TransProd TRP inner join Visita VIS on TRP.VisitaClave = VIS.VisitaClave and TRP.DiaClave=VIS.DiaClave  where TRP.TransProdID='" + oTransProd.TransProdID + "'");
        //    ERMADDLOG.cAddenda oAddenda  = new ERMADDLOG.cAddenda();
        //    DataTable dtCamposSolicitados  = oAddenda.ObtenerFaltantesSolicitados (sClienteClave,oTransProd.TransProdID );
        //    if (dtCamposSolicitados.Rows.Count > 0) {
        //        DataTable dtCapturados = oTransProd.AddendaFactura.ToDataTable();
        //        int icont  = dtCamposSolicitados.Rows.Count;
        //        Complemento  frmComplemento = new Complemento();
                
        //        int PosX = 11;
        //        int PosY  = 8;
        //        DataRow[] drs;
        //        foreach  (DataRow dr in dtCamposSolicitados.Rows){
        //            ERMTRPESC.CtrlCampos ctrl = new ERMTRPESC.CtrlCampos(oMensaje);
        //            ctrl.AgregarCampo(dr["Etiqueta"].ToString(), dr["Valor"].ToString(), dr["ADDDID"].ToString(), Convert.ToBoolean(dr["Requerido"]), (ERMTRPESC.CtrlCampos.ETipoDato)Convert.ToInt16(dr["TipoDato"]), Convert.ToInt16(dr["LongMin"]), Convert.ToInt16(dr["LongMax"]));
        //            ctrl.TabIndex = icont;
        //            drs = dtCapturados.Select("ADDDID='" + dr["ADDDID"].ToString() + "'");
        //            if (drs.Length > 0 ){
        //                ctrl.Valor = drs[0]["Valor"].ToString();
        //            }
        //            ctrl.BackColor = frmComplemento.BackColor;
        //            frmComplemento.AgregarControl(ctrl);
        //            ctrl.Dock = System.Windows.Forms.DockStyle.Top;
        //            ctrl.Enabled = true;
           
        //            icont -= 1;
        //        }
        //        frmComplemento.Capturar(ref oTransProd,oMensaje );
        //    }

        //    dtCamposSolicitados.Dispose();
        //}
        
    }
}
