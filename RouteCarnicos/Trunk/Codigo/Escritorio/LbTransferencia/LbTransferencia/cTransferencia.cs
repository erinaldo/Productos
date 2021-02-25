using System;
using System.Collections.Generic;
using System.Text;

namespace LbTransferencia
{
    public class cTransferencia
    {
        protected string sError;
        protected string sLog;

        public string Error
        {
            get
            {
                return sError;
            }
        }

        public string ArchivoLog
        {
            get 
            {
                return sLog; 
            }
        }

        public class ArchivosAEnviar
        {
            private string ruta;
            private string nombre;

            public ArchivosAEnviar(string ruta, string nombre)
            {
                this.ruta = ruta;
                this.nombre = nombre;
            }

            
            public string Ruta
            {
                get { return ruta; }
                set { ruta = value; }
            }

            

            public string Nombre
            {
                get { return nombre; }
                set { nombre = value; }
            }

        }


        /// <summary>
        /// Transferencia de archivos por FTP
        /// </summary>
        /// <param name="sRutaFtp"></param>
        /// <param name="sCarpetaFTP"></param>
        /// <param name="sPasswordFTP"></param>
        /// <param name="sUsuarioFTP"></param>
        /// <param name="sNombreArchivo"></param>
        /// <param name="sRutaArchivo"></param>
        /// <returns></returns>
        public bool Transferir(string sRutaFtp, string sCarpetaFTP, string sPasswordFTP, string sUsuarioFTP, string sNombreArchivo, string sRutaArchivo, string sAsunto) 
        {
            //System.Reflection.Assembly assem = System.Reflection.Assembly.GetExecutingAssembly();
            //string AppPath = System.IO.Path.GetDirectoryName(assem.Location);

            cFTP oFTP = new cFTP(sRutaFtp, sCarpetaFTP, sPasswordFTP, sUsuarioFTP, sNombreArchivo, sRutaArchivo);
            try
            {
                oFTP.Enviar();
                return true;
            }
            catch (System.Exception ex)
            {
                cBitacoraLog oBitacoraLog = new cBitacoraLog(sRutaArchivo, "LogEnvio_" + DateTime.Now.ToString("yyyyMMdd") + ".txt", sAsunto + ": " + ex.Message);
                sLog = "LogEnvio_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
                sError = ex.Message; 
                return false;
            }
        }

        /// <summary>
        /// Transferencia de varios archivos por FTP
        /// </summary>
        /// <param name="sRutaFtp"></param>
        /// <param name="sCarpetaFTP"></param>
        /// <param name="sPasswordFTP"></param>
        /// <param name="sUsuarioFTP"></param>
        /// <param name="oLista">Lista de archivos a enviar</param>
        /// <param name="sAsunto"></param>
        /// <returns></returns>
        public bool Transferir(string sRutaFtp, string sCarpetaFTP, string sPasswordFTP, string sUsuarioFTP, ArchivosAEnviar[] oLista, string sAsunto)
        {
            cFTP oFTP = new cFTP(sRutaFtp, sCarpetaFTP, sPasswordFTP, sUsuarioFTP, oLista);
            try
            {
                oFTP.Enviar();
                return true;
            }
            catch (System.Exception ex)
            {
                cBitacoraLog oBitacoraLog = new cBitacoraLog(oLista[0].Ruta, "LogEnvio_" + DateTime.Now.ToString("yyyyMMdd") + ".txt", sAsunto + ": " + ex.Message);
                sLog = "LogEnvio_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
                sError = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Transferencia de archivos por Email
        /// </summary>
        /// <param name="sServidorSMTP"></param>
        /// <param name="sPasswordSMTP"></param>
        /// <param name="sPuertoSMTP"></param>
        /// <param name="sEmailOrigen"></param>
        /// <param name="sEmailDestino"></param>
        /// <param name="sMensaje"></param>
        /// <param name="sAsunto"></param>
        /// <param name="sRutaAttachment"></param>
        /// <returns></returns>
        public bool Transferir(string sServidorSMTP, string sPasswordSMTP, string sPuertoSMTP, string sEmailOrigen, string sEmailDestino, string sMensaje, string sAsunto, string sNombreArchivo, string sRutaArchivo, bool bSSL)
        {
            cCorreo oCorreo = new cCorreo(sServidorSMTP, sPasswordSMTP, sPuertoSMTP, sEmailOrigen, sEmailDestino, sMensaje, sAsunto, sNombreArchivo, sRutaArchivo,bSSL);
            try
            {
                oCorreo.Enviar();
                return true;
            }
            catch (System.Exception ex)
            {
                cBitacoraLog oBitacoraLog = new cBitacoraLog(sRutaArchivo, "LogEnvio_" + DateTime.Now.ToString("yyyyMMdd") + ".txt", sAsunto + ": " + ex.Message);
                sLog = "LogEnvio_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
                sError = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Transferencia de varios archivos por Email
        /// </summary>
        /// <param name="sServidorSMTP"></param>
        /// <param name="sPasswordSMTP"></param>
        /// <param name="sPuertoSMTP"></param>
        /// <param name="sEmailOrigen"></param>
        /// <param name="sEmailDestino"></param>
        /// <param name="sMensaje"></param>
        /// <param name="sAsunto"></param>
        /// <param name="oLista">Lista de archivos que se enviaran (Ruta y Nombre del archivo)</param>
        /// <param name="bSSL"></param>
        /// <returns></returns>
        public bool Transferir(string sServidorSMTP, string sPasswordSMTP, string sPuertoSMTP, string sEmailOrigen, string sEmailDestino, string sMensaje, string sAsunto, ArchivosAEnviar[] oLista, bool bSSL)
        {
            cCorreo oCorreo = new cCorreo(sServidorSMTP, sPasswordSMTP, sPuertoSMTP, sEmailOrigen, sEmailDestino, sMensaje, sAsunto, oLista, bSSL);
            try
            {
                oCorreo.Enviar();
                return true;
            }
            catch (System.Exception ex)
            {
                cBitacoraLog oBitacoraLog = new cBitacoraLog(oLista[0].Ruta, "LogEnvio_" + DateTime.Now.ToString("yyyyMMdd") + ".txt", sAsunto + ": " + ex.Message);
                sLog = "LogEnvio_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
                sError = ex.Message;
                return false;
            }
        }

        public bool TransferirAddenda(string sURL, string sNombreArchivo, string sRutaArchivo, TipoAddenda tTipoAddenda)
        {
            if (tTipoAddenda == TipoAddenda.Soriana)
            {
                try
                {
                    cServicioSoriana oServicioSoriana = new cServicioSoriana(sURL, sNombreArchivo, sRutaArchivo);
                    return oServicioSoriana.Enviar();
                }
                catch (System.Exception ex)
                {
                    cBitacoraLog oBitacoraLog = new cBitacoraLog(sRutaArchivo, "LogEnvio_" + DateTime.Now.ToString("yyyyMMdd") + ".txt", ex.Message);
                    sLog = "LogEnvio_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
                    sError = ex.Message;
                    return false;
                }
            }
            return false;
        }

        public enum TipoAddenda
        {
            Soriana
        }
           
    }
}
