using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace LbTransferencia
{
    class cFTP
    {
        protected string RutaFtp; 
        protected string CarpetaFTP; 
        protected string PasswordFTP; 
        protected string UsuarioFTP; 
        protected cTransferencia.ArchivosAEnviar[] Lista;

        public cFTP(string sRutaFtp, string sCarpetaFTP, string sPasswordFTP, string sUsuarioFTP, string sNombreArchivo, string sRutaArchivo)
        {
            RutaFtp = sRutaFtp;
            CarpetaFTP = sCarpetaFTP;
            PasswordFTP = sPasswordFTP;
            UsuarioFTP = sUsuarioFTP;
            Lista = new cTransferencia.ArchivosAEnviar[] { new cTransferencia.ArchivosAEnviar(sRutaArchivo, sNombreArchivo) };
        }
        public cFTP(string sRutaFtp, string sCarpetaFTP, string sPasswordFTP, string sUsuarioFTP, cTransferencia.ArchivosAEnviar[] oLista)
        {
            RutaFtp = sRutaFtp;
            CarpetaFTP = sCarpetaFTP;
            PasswordFTP = sPasswordFTP;
            UsuarioFTP = sUsuarioFTP;
            Lista = oLista;
        }

        public void Enviar()
        {
            System.Net.WebClient w1 = new System.Net.WebClient();
            w1.Credentials = new System.Net.NetworkCredential(UsuarioFTP, PasswordFTP);

            foreach (cTransferencia.ArchivosAEnviar a in Lista)
            {
                Uri rutaServer = new Uri(RutaFtp);
                rutaServer = new Uri(rutaServer, (CarpetaFTP == "" ? "" : CarpetaFTP + "/") + a.Nombre);
                w1.UploadFile(rutaServer, System.IO.Path.Combine(a.Ruta, a.Nombre));
            }
            w1.Dispose();
        }
    }
}
