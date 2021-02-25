using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.IO;

namespace LbTransferencia
{
    class cCorreo
    {
        protected string ServidorSMTP;
        protected string PasswordSMTP;
        protected string PuertoSMTP;
        protected string EmailOrigen;
        protected string EmailDestino;
        protected string Mensaje;
        protected string Asunto;
        protected bool SSL;
        protected cTransferencia.ArchivosAEnviar[] Lista;

        public cCorreo(string sServidorSMTP, string sPasswordSMTP, string sPuertoSMTP, string sEmailOrigen, string sEmailDestino, string sMensaje, string sAsunto, string sNombreArchivo, string sRutaArchivo, bool bSSL)
        {
            ServidorSMTP = sServidorSMTP;
            PasswordSMTP = sPasswordSMTP;
            PuertoSMTP = sPuertoSMTP;
            EmailOrigen = sEmailOrigen;
            EmailDestino = sEmailDestino;
            Mensaje = sMensaje;
            Asunto = sAsunto;
            Lista = new cTransferencia.ArchivosAEnviar[] { new cTransferencia.ArchivosAEnviar(sRutaArchivo, sNombreArchivo) };
            SSL = bSSL;
        }

        public cCorreo(string sServidorSMTP, string sPasswordSMTP, string sPuertoSMTP, string sEmailOrigen, string sEmailDestino, string sMensaje, string sAsunto, cTransferencia.ArchivosAEnviar[] oLista, bool bSSL)
        {
            ServidorSMTP = sServidorSMTP;
            PasswordSMTP = sPasswordSMTP;
            PuertoSMTP = sPuertoSMTP;
            EmailOrigen = sEmailOrigen;
            EmailDestino = sEmailDestino;
            Mensaje = sMensaje;
            Asunto = sAsunto;
            Lista = oLista;
            SSL = bSSL;
        }

        public void Enviar()
        {

            if ((ServidorSMTP.Trim().Length > 0) && (EmailOrigen.Trim().Length > 0) && (EmailDestino.Trim().Length > 0))
            {
                MailMessage mail = new MailMessage(EmailOrigen, EmailDestino);
                mail.IsBodyHtml = true;
                mail.Body = Mensaje;
                mail.Subject = Asunto;
                SmtpClient servidor = new SmtpClient(ServidorSMTP);
                int puerto = 0;
                if ((PuertoSMTP.Trim() != "") && (int.TryParse(PuertoSMTP, out puerto)))
                    servidor.Port = puerto;
                servidor.Credentials = new NetworkCredential(EmailOrigen, PasswordSMTP);
                servidor.EnableSsl = SSL;
                List<FileStream> datos = new List<FileStream>();
                foreach (cTransferencia.ArchivosAEnviar a in Lista)
                {
                    string sArchivo = System.IO.Path.Combine(a.Ruta, a.Nombre);
                    FileStream dato = new FileStream(sArchivo, FileMode.Open, FileAccess.Read);
                    Attachment adjuntos = new Attachment(dato, a.Nombre);
                    mail.Attachments.Add(adjuntos);
                    datos.Add(dato);
                }
                try
                {
                    servidor.Send(mail);
                    foreach (FileStream dato in datos)
                        dato.Close();
                }
                catch (System.Exception ex)
                {
                    foreach (FileStream dato in datos)
                        dato.Close();
                    throw new Exception(ex.Message); 
                }
                
            }
        }

    }
}
