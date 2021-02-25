using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace LbTransferencia
{
    class cBitacoraLog
    {
    
#region Variables
        //string RutaArchivo;
        //string NombreArchivo;
        string RutaArchivo;
#endregion

        public cBitacoraLog(string pRutaArchivo, string pNombreArchivo,string pDescripcionError)
        {
            RutaArchivo = System.IO.Path.Combine(pRutaArchivo, pNombreArchivo);
            if (!System.IO.File.Exists(RutaArchivo))
            {
                string fileName = pNombreArchivo;
                FileStream stream = new FileStream(RutaArchivo, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter writer = new StreamWriter(stream);

                writer.WriteLine(pDescripcionError);
                writer.Close();
            }
            else
            {
                EscribirEnBitacora(pDescripcionError);
            }
        }

        public cBitacoraLog(string pRutaArchivo, string pNombreArchivo)
        {
            RutaArchivo = System.IO.Path.Combine(pRutaArchivo, pNombreArchivo);
            if (!System.IO.File.Exists(RutaArchivo))
            {
                FileStream fs =  System.IO.File.Create(RutaArchivo);
                fs.Close();
            }
        }


        public void EscribirEnBitacora(string pDescripcionError)
        {
            try
            {               
                // esto inserta texto en un archivo existente, si el archivo no existe lo crea
                StreamWriter writer = File.AppendText(RutaArchivo);
                writer.WriteLine(pDescripcionError);
                writer.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

