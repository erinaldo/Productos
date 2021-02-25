using System;
using System.IO;
using System.Web;

namespace eRoute.Models.ReportesModels
{
    public static class DownloadFile
    {
        public static void DownloadOpenXML(string fileName)
        {

            FileInfo fileInfo = new FileInfo(fileName);
            HttpResponse response = HttpContext.Current.Response;

            if (fileInfo.Exists)
            {
                FileStream fs = null;
                BinaryReader br = null;
                byte[] data = null;

                fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                br = new BinaryReader(fs, System.Text.Encoding.Default);
                data = new byte[Convert.ToInt32(fs.Length)];
                br.Read(data, 0, data.Length);
                response.Clear();
                response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                response.AddHeader("content-disposition", "attachment; filename=" + fileInfo.Name);
                response.AddHeader("Content-Length", fileInfo.Length.ToString());
                response.BinaryWrite(data);
                //response.Flush();
                response.End();
                br.Close();
                br.Dispose();
                fs.Close();
                fs.Dispose();
            }
            else
                response.Write("No se encontró el archivo " + fileInfo.Name);
        }

        public static void DownloadOpenXML(ArchivoXlsModel file)
        {
            HttpResponse response = HttpContext.Current.Response;
            response.Clear();
            response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}", file.nombre));
            response.BinaryWrite(file.archivo);
            response.End();
        }
    }
}