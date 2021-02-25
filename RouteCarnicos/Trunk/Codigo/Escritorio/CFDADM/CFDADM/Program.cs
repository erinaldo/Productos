using System;
using System.Collections.Generic;
using System.Text;

namespace CFDADM
{
    class Program
    {
        static void Main(string[] args)
        {

            //if (args.Length != 2)
            //{
            //    //BitacoraLog oBitacoraLog = new BitacoraLog(System.IO.Directory.GetCurrentDirectory(), "BitacoraLog" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt", "Número de argumentos inválido " + args.Length);
            //    //BitacoraLog oBitacoraLog = new BitacoraLog(AppPath, "BitacoraLog" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt", "Número de argumentos inválido");
            //    throw new Exception("Número de Argumentos inválido");
            //    return;
            //}

            //args = new string[] { "1", "8DD38BB14FDFB384", "C:\\guardar" };     
       
            GenerarFactura oGenerarFactura;
            switch (args[0])
            {
                case "1":
                    oGenerarFactura = new GenerarFactura(GenerarFactura.TipoEjecucion.GenerarFactura);
                    oGenerarFactura.GeneraFactura(args[1], args[2]);
                    break;
                case "3":
                    oGenerarFactura = new GenerarFactura(GenerarFactura.TipoEjecucion.GenerarFacturaNoBorra);
                    oGenerarFactura.GeneraFactura(args[1], args[2]);
                    break;
                case "2":
                    oGenerarFactura = new GenerarFactura(GenerarFactura.TipoEjecucion.ImprimirFactura);
                    oGenerarFactura.ImprimirFactura(args[1], args[2]);
                    break;
                //case "4":
                //    oGenerarFactura = new GenerarFactura(GenerarFactura.TipoEjecucion.CancelarFactura);
                //    oGenerarFactura.CancelarFactura(args[1], args[2]);
                //    break;
                case "5":
                    oGenerarFactura = new GenerarFactura(GenerarFactura.TipoEjecucion.GenerarFacturaEviarCorreoMobile);
                    oGenerarFactura.GeneraFacturaEnviarXMLPDFMobile(args[1], args[2]);
                    break;
            }
        }


    }
}
