using System;
using System.Collections.Generic;
using System.Text;

namespace LbTransferencia
{
    class cServicioSoriana
    {
        protected string URL;
        protected string NombreArchivo;
        protected string RutaArchivo;

        public cServicioSoriana(string sURL, string sNombreArchivo, string sRutaArchivo)
        {
            URL = sURL;
            NombreArchivo = sNombreArchivo;
            RutaArchivo = sRutaArchivo;
        }

        public bool Enviar()
        {
            try
            {
                ServicioSoriana.wseDocRecibo osvSoriana = new ServicioSoriana.wseDocRecibo();
                osvSoriana.Url = URL;
                osvSoriana.Timeout = 50000;

                System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
                xmlDoc.Load(System.IO.Path.Combine(RutaArchivo, NombreArchivo));

                // Now create StringWriter object to get data from xml document.
                System.IO.StringWriter sw = new System.IO.StringWriter();
                System.Xml.XmlTextWriter xw = new System.Xml.XmlTextWriter(sw);
                xmlDoc.WriteTo(xw);

                string res = osvSoriana.RecibeCFD(sw.ToString());

                System.Data.DataSet dsRes = new System.Data.DataSet();
                System.IO.MemoryStream ms;
                Byte[] buf;

                buf = System.Text.ASCIIEncoding.ASCII.GetBytes(res);
                ms = new System.IO.MemoryStream(buf);
                dsRes.ReadXml(ms);

                if (dsRes.Tables["AckErrorApplication"].Rows[0]["documentStatus"].ToString().ToUpper() == "ACCEPTED")
                {
                    string sAPERAK = System.IO.Path.Combine(RutaArchivo, "APERAK_" + System.IO.Path.GetFileNameWithoutExtension(NombreArchivo) + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xml");
                    using (System.IO.FileStream fs = System.IO.File.Open(sAPERAK, System.IO.FileMode.Create, System.IO.FileAccess.Write))
                    {
                        ms.WriteTo(fs);
                        ms.Dispose();
                    }
                    dsRes.Dispose();
                    return true;
                }
                else
                {
                    string sAPERAK = System.IO.Path.Combine(RutaArchivo, "APERAK_" + System.IO.Path.GetFileNameWithoutExtension(NombreArchivo) + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xml");
                    using (System.IO.FileStream fs = System.IO.File.Open(sAPERAK, System.IO.FileMode.Create, System.IO.FileAccess.Write))
                    {
                        ms.WriteTo(fs);
                        ms.Dispose();
                    }
                    throw new Exception("XML Rechazado: Revisar " + sAPERAK);
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

    }
}
