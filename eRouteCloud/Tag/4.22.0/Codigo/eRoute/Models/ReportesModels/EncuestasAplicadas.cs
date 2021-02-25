using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using System.Globalization;
using System.IO;
using System.Text;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;


namespace eRoute.Models.ReportesModels
{
    public class EncuestasAplicadas
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString = "";

        public bool GetReport(int Reporte, string CENClave, string FechaIni, string FechaFin, string Rutas)
        {
            try
            {
                DateTime dFechaIni;
                DateTime.TryParse(FechaIni, out dFechaIni);
                DateTime dFechaFin;
                if (FechaFin != "null")
                    DateTime.TryParse(FechaFin, out dFechaFin);
                else
                    dFechaFin = dFechaIni;

                StringBuilder sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("SET NOCOUNT ON ");
                sConsulta.AppendLine("SELECT CENClave, CEN.Descripcion, VAD.Descripcion AS Tipo ");
                sConsulta.AppendLine("FROM ConfigEncuesta CEN (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN VAVDescripcion VAD (NOLOCK) ON CEN.Tipo = VAD.VAVClave AND VARCodigo = 'TENC' AND VADTipoLenguaje = 'EM' ");
                sConsulta.AppendLine("WHERE CEN.CENClave = '" + CENClave + "' ");
                sConsulta.AppendLine("SET NOCOUNT OFF ");

                QueryString = sConsulta.ToString();
                Connection.Open();
                ConfigEncuestaModel ConfigEncuesta = Connection.Query<ConfigEncuestaModel>(QueryString, null, null, true, 9000).ToList()[0];
                Connection.Close();

                sConsulta.Clear();
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("SET NOCOUNT ON ");
                sConsulta.AppendLine("DECLARE @CENClave VARCHAR(10) ");
                sConsulta.AppendLine("DECLARE @FechaIni DATETIME ");
                sConsulta.AppendLine("DECLARE @FechaFin DATETIME ");

                sConsulta.AppendLine("SET @CENClave = '" + CENClave + "' ");
                sConsulta.AppendLine("SET @FechaIni = '" + dFechaIni.Date.ToString("s") + "' ");
                sConsulta.AppendLine("SET @FechaFin = '" + dFechaFin.Date.ToString("s") + "' ");

                sConsulta.AppendLine("SELECT ENC.ENCId, VIS.RUTClave, (SELECT TOP 1 ESQ.Clave FROM Esquema ESQ (NOLOCK) INNER JOIN ClienteEsquema CE (NOLOCK) ON CE.Esquemaid = ESQ.EsquemaId AND CE.ClienteClave = CLI.ClienteClave) AS Ruta, ");
                sConsulta.AppendLine("VIS.DiaClave, (dbo.FNObtenerValorReferencia('ENCFASE', ENC.Fase)) AS Fase, VIS.ClienteClave, REPLACE(REPLACE(CLI.NombreCorto, CHAR(10), ' '), CHAR(13), ' ') AS NombreCorto, ");
                sConsulta.AppendLine("REPLACE(REPLACE(CLI.RazonSocial, CHAR(10), ' '), CHAR(13), ' ') AS RazonSocial, REPLACE(REPLACE(CLI.IdElectronico, CHAR(10), ' '), CHAR(13), ' ') AS IdElectronico, CLI.FechaNacimiento, CLI.VigExclusividad, ");
                sConsulta.AppendLine("REPLACE(REPLACE(CLD.Calle, CHAR(10), ' '), CHAR(13), ' ') AS Calle, REPLACE(REPLACE(CLD.Numero, CHAR(10), ' '), CHAR(13), ' ') AS Numero, REPLACE(REPLACE(CLD.NumInt, CHAR(10), ' '), CHAR(13), ' ') AS NumInt, ");
                sConsulta.AppendLine("REPLACE(REPLACE(CLD.Colonia, CHAR(10), ' '), CHAR(13), ' ') AS Colonia, REPLACE(REPLACE(CLD.Localidad, CHAR(10), ' '), CHAR(13), ' ') AS Localidad, REPLACE(REPLACE(CLD.Entidad, CHAR(10), ' '), CHAR(13), ' ') AS Entidad, ");
                sConsulta.AppendLine("REPLACE(REPLACE(CLD.CodigoPostal, CHAR(10), ' '), CHAR(13), ' ') AS CodigoPostal, REPLACE(REPLACE(CLD.ReferenciaDom, CHAR(10), ' '), CHAR(13), ' ') AS ReferenciaDom ");
                sConsulta.AppendLine("FROM Encuesta ENC (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON ENC.VisitaClave = VIS.VisitaClave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON VIS.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Cliente CLI (NOLOCK) ON VIS.ClienteClave = CLI.ClienteClave ");
                sConsulta.AppendLine("INNER JOIN ClienteDomicilio CLD (NOLOCK) ON CLI.ClienteClave = CLD.ClienteClave AND CLD.Tipo = 2 ");
                sConsulta.AppendLine("WHERE ENC.CENClave = @CENClave AND Dia.FechaCaptura BETWEEN @FechaIni AND @FechaFin ");
                if (Rutas != null && Rutas != "" && Rutas != "null")
                    sConsulta.AppendLine("AND VIS.RUTClave IN (" + Rutas + ") ");

                sConsulta.AppendLine("SET NOCOUNT OFF ");

                QueryString = sConsulta.ToString();
                Connection.Open();
                List<EncEncuestaAplicadaModel> EncuestasApl = Connection.Query<EncEncuestaAplicadaModel>(QueryString, null, null, true, 9000).ToList();
                Connection.Close();

                sConsulta.Clear();

                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("SET NOCOUNT ON ");
                sConsulta.AppendLine("DECLARE @CENClave VARCHAR(10) ");
                sConsulta.AppendLine("DECLARE @FechaIni DATETIME ");
                sConsulta.AppendLine("DECLARE @FechaFin DATETIME ");

                sConsulta.AppendLine("SET @CENClave = '" + CENClave + "' ");
                sConsulta.AppendLine("SET @FechaIni = '" + dFechaIni.Date.ToString("s") + "' ");
                sConsulta.AppendLine("SET @FechaFin = '" + dFechaFin.Date.ToString("s") + "' ");

                sConsulta.AppendLine("SELECT * INTO #tmpMatriz FROM( ");
                if (Reporte == 79) //Disposur
                    sConsulta.AppendLine("SELECT CPM.CENClave, CPM.CEPNumero, CPM.CPMNumero, CRM.CRMNumero, CRM.TipoValor, REPLACE(REPLACE(CRM.Descripcion, CHAR(10), ' '), CHAR(13), ' ') AS RDescripcion, REPLACE(REPLACE(CPM.Descripcion, CHAR(10), ' '), CHAR(13), ' ') AS PDescripcion ");
                else
                    sConsulta.AppendLine("SELECT CPM.CENClave, CPM.CEPNumero, CPM.CPMNumero, CRM.CRMNumero, CRM.TipoValor ");
                sConsulta.AppendLine("FROM CEPPregMatricial CPM (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN CEPRespMatricial CRM (NOLOCK) ON CPM.CENClave = CRM.CENClave AND CPM.CEPNumero = CRM.CEPNumero ");
                sConsulta.AppendLine("WHERE CPM.CENClave = @CENClave ");
                sConsulta.AppendLine(") AS t ");

                sConsulta.AppendLine("SELECT ENCId, TipoRespuesta, CEPNumero, Pregunta, Orden, replace(replace(Respuesta, CHAR(13), ''), CHAR(10), '') AS Respuesta ");
                sConsulta.AppendLine("FROM ( ");
                sConsulta.AppendLine("--Texto ");
                if (Reporte == 79) //Disposur
                    sConsulta.AppendLine("SELECT ENC.ENCId, CEN.TipoRespuesta, CRT.CEPNumero, REPLACE(REPLACE(CEN.Descripcion, CHAR(10), ' '), CHAR(13), ' ') AS Pregunta, CONVERT(VARCHAR(32), CRT.CEPNumero) AS Pregunta1, CONVERT(VARCHAR(32), CRT.CEPNumero) AS Pregunta2, CONVERT(VARCHAR(32), CRT.CEPNumero) AS Pregunta3, CASE WHEN ENP.ENCId IS NULL THEN '*NA' ELSE REPLACE(REPLACE(ERT.Descripcion, CHAR(10), ' '), CHAR(13), ' ') END AS Respuesta, CEN.Orden ");
                else
                    sConsulta.AppendLine("SELECT ENC.ENCId, CEN.TipoRespuesta, CRT.CEPNumero, CONVERT(VARCHAR(32), CRT.CEPNumero) AS Pregunta, CONVERT(VARCHAR(32), CRT.CEPNumero) AS Pregunta1, CONVERT(VARCHAR(32), CRT.CEPNumero) AS Pregunta2, CONVERT(VARCHAR(32), CRT.CEPNumero) AS Pregunta3, CASE WHEN ENP.ENCId IS NULL THEN '*NA' ELSE REPLACE(REPLACE(ERT.Descripcion, CHAR(10), ' '), CHAR(13), ' ') END AS Respuesta, CEN.Orden ");
                sConsulta.AppendLine("FROM Encuesta ENC (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON ENC.VisitaClave = VIS.VisitaClave AND ENC.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON VIS.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine("RIGHT JOIN CEPRespTexto CRT (NOLOCK) ON ENC.CENClave = CRT.CENClave ");
                sConsulta.AppendLine("INNER JOIN CENPregunta CEN (NOLOCK) ON CEN.CENClave = CRT.CENClave AND CEN.CEPNumero = CRT.CEPNumero ");
                sConsulta.AppendLine("LEFT JOIN ENCPregunta ENP (NOLOCK) ON ENC.ENCId = ENP.ENCId AND CRT.CENClave = ENP.CENClave AND CRT.CEPNumero = ENP.CEPNumero ");
                sConsulta.AppendLine("LEFT JOIN ENPRespTexto ERT (NOLOCK) ON ENP.ENCId = ERT.ENCId AND ENP.ENPId = ERT.ENPId ");
                sConsulta.AppendLine("WHERE ENC.CENClave = @CENClave AND Dia.FechaCaptura BETWEEN @FechaIni AND @FechaFin ");
                if (Rutas != null && Rutas != "" && Rutas != "null")
                    sConsulta.AppendLine("AND VIS.RUTClave IN (" + Rutas + ") ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("--Numero ");
                if (Reporte == 79) //Disposur
                    sConsulta.AppendLine("SELECT ENC.ENCId, CEN.TipoRespuesta, CRN.CEPNumero, REPLACE(REPLACE(CEN.Descripcion, CHAR(10), ' '), CHAR(13), ' ') AS Pregunta, CONVERT(VARCHAR(32), CRN.CEPNumero) AS Pregunta1, CONVERT(VARCHAR(32), CRN.CEPNumero) AS Pregunta2, CONVERT(VARCHAR(32), CRN.CEPNumero) AS Pregunta3, CASE WHEN ENP.ENCId IS NULL THEN '*NA' ELSE CONVERT(VARCHAR(100), ERN.Valor) END AS Respuesta, CEN.Orden ");
                else
                    sConsulta.AppendLine("SELECT ENC.ENCId, CEN.TipoRespuesta, CRN.CEPNumero, CONVERT(VARCHAR(32), CRN.CEPNumero) AS Pregunta, CONVERT(VARCHAR(32), CRN.CEPNumero) AS Pregunta1, CONVERT(VARCHAR(32), CRN.CEPNumero) AS Pregunta2, CONVERT(VARCHAR(32), CRN.CEPNumero) AS Pregunta3, CASE WHEN ENP.ENCId IS NULL THEN '*NA' ELSE CONVERT(VARCHAR(100), ERN.Valor) END AS Respuesta, CEN.Orden ");
                sConsulta.AppendLine("FROM Encuesta ENC (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON ENC.VisitaClave = VIS.VisitaClave AND ENC.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON VIS.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine("RIGHT JOIN CEPRespNumero CRN (NOLOCK) ON ENC.CENClave = CRN.CENClave ");
                sConsulta.AppendLine("INNER JOIN CENPregunta CEN (NOLOCK) ON CEN.CENClave = CRN.CENClave AND CEN.CEPNumero = CRN.CEPNumero ");
                sConsulta.AppendLine("LEFT JOIN ENCPregunta ENP (NOLOCK) ON ENC.ENCId = ENP.ENCId AND CRN.CENClave = ENP.CENClave AND CRN.CEPNumero = ENP.CEPNumero ");
                sConsulta.AppendLine("LEFT JOIN ENPRespNumero ERN (NOLOCK) ON ENP.ENCId = ERN.ENCId AND ENP.ENPId = ERN.ENPId ");
                sConsulta.AppendLine("WHERE ENC.CENClave = @CENClave AND Dia.FechaCaptura BETWEEN @FechaIni AND @FechaFin ");
                if (Rutas != null && Rutas != "" && Rutas != "null")
                    sConsulta.AppendLine("AND VIS.RUTClave IN (" + Rutas + ") ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("--Opcional ");
                if (Reporte == 79) //Disposur
                    sConsulta.AppendLine("SELECT ENC.ENCId, CEN.TipoRespuesta, COO.CEPNumero, REPLACE(REPLACE(CEN.Descripcion, CHAR(10), ' '), CHAR(13), ' ') + '_' + REPLACE(REPLACE(COO.Descripcion, CHAR(10), ' '), CHAR(13), ' ') AS Pregunta, CONVERT(VARCHAR(32), COO.CEPNumero) AS Pregunta1, CONVERT(VARCHAR(32), COO.Numero) AS Pregunta2, '' AS Pregunta3, ");
                else
                    sConsulta.AppendLine("SELECT ENC.ENCId, CEN.TipoRespuesta, COO.CEPNumero, CONVERT(VARCHAR(16), COO.CEPNumero) + '_' + CONVERT(VARCHAR(16), COO.Numero) AS Pregunta, CONVERT(VARCHAR(32), COO.CEPNumero) AS Pregunta1, CONVERT(VARCHAR(32), COO.Numero) AS Pregunta2, '' AS Pregunta3, ");
                sConsulta.AppendLine("CASE WHEN ENP.ENCId IS NULL THEN '*NA' ELSE CASE WHEN CRO.TipoSeleccion = 1 THEN CASE WHEN ERO.EROId IS NULL or ERO.Valor = 0 THEN '' ELSE COO.Descripcion END ELSE ISNULL(ERO.Valor, '') END END AS Respuesta, CEN.Orden ");
                sConsulta.AppendLine("FROM Encuesta ENC (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON ENC.VisitaClave = VIS.VisitaClave AND ENC.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON VIS.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine("RIGHT JOIN CEPRespOpcional CRO (NOLOCK) ON ENC.CENClave = CRO.CENClave ");
                sConsulta.AppendLine("INNER JOIN CENPregunta CEN (NOLOCK) ON CEN.CENClave = CRO.CENClave AND CEN.CEPNumero = CRO.CEPNumero ");
                sConsulta.AppendLine("RIGHT JOIN CROOpcion COO (NOLOCK) ON CRO.CENClave = COO.CENClave AND CRO.CEPNumero = COO.CEPNumero AND CRO.CROId = COO.CROId ");
                sConsulta.AppendLine("LEFT JOIN ENCPregunta ENP (NOLOCK) ON ENC.ENCId = ENP.ENCId AND COO.CENClave = ENP.CENClave AND COO.CEPNumero = ENP.CEPNumero ");
                sConsulta.AppendLine("LEFT JOIN ENPRespOpcional ERO (NOLOCK) ON ENP.ENCId = ERO.ENCId AND ENP.ENPId = ERO.ENPId AND COO.CROId = ERO.CROId AND COO.COOId = ERO.COOId ");
                sConsulta.AppendLine("WHERE ENC.CENClave = @CENClave AND Dia.FechaCaptura BETWEEN @FechaIni AND @FechaFin ");
                if (Rutas != null && Rutas != "" && Rutas != "null")
                    sConsulta.AppendLine("AND VIS.RUTClave IN (" + Rutas + ") ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("--Codigo ");
                if (Reporte == 79) //Disposur
                    sConsulta.AppendLine("SELECT ENC.ENCId, CEN.TipoRespuesta, CRC.CEPNumero, REPLACE(REPLACE(CEN.Descripcion, CHAR(10), ' '), CHAR(13), ' ') AS Pregunta, CONVERT(VARCHAR(32), CRC.CEPNumero) AS Pregunta1, CONVERT(VARCHAR(32), CRC.CEPNumero) AS Pregunta2, CONVERT(VARCHAR(32), CRC.CEPNumero) AS Pregunta3, CASE WHEN ENP.ENCId IS NULL THEN '*NA' ELSE ERC.Codigo END AS Respuesta, CEN.Orden ");
                else
                    sConsulta.AppendLine("SELECT ENC.ENCId, CEN.TipoRespuesta, CRC.CEPNumero, CONVERT(VARCHAR(32), CRC.CEPNumero) AS Pregunta, CONVERT(VARCHAR(32), CRC.CEPNumero) AS Pregunta1, CONVERT(VARCHAR(32), CRC.CEPNumero) AS Pregunta2, CONVERT(VARCHAR(32), CRC.CEPNumero) AS Pregunta3, CASE WHEN ENP.ENCId IS NULL THEN '*NA' ELSE ERC.Codigo END AS Respuesta, CEN.Orden ");
                sConsulta.AppendLine("FROM Encuesta ENC (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON ENC.VisitaClave = VIS.VisitaClave AND ENC.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON VIS.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine("RIGHT JOIN CEPRespCodigo CRC (NOLOCK) ON ENC.CENClave = CRC.CENClave ");
                sConsulta.AppendLine("INNER JOIN CENPregunta CEN (NOLOCK) ON CEN.CENClave = CRC.CENClave AND CEN.CEPNumero = CRC.CEPNumero ");
                sConsulta.AppendLine("LEFT JOIN ENCPregunta ENP (NOLOCK) ON ENC.ENCId = ENP.ENCId AND CRC.CENClave = ENP.CENClave AND CRC.CEPNumero = ENP.CEPNumero ");
                sConsulta.AppendLine("LEFT JOIN ENPRespCodigo ERC (NOLOCK) ON ENP.ENCId = ERC.ENCId AND ENP.ENPId = ERC.ENPId ");
                sConsulta.AppendLine("WHERE ENC.CENClave = @CENClave AND Dia.FechaCaptura BETWEEN @FechaIni AND @FechaFin ");
                if (Rutas != null && Rutas != "" && Rutas != "null")
                    sConsulta.AppendLine("AND VIS.RUTClave IN (" + Rutas + ") ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("--Matricial ");
                if (Reporte == 79) //Disposur
                    sConsulta.AppendLine("SELECT ENC.ENCId, CEN.TipoRespuesta, MAT.CEPNumero, REPLACE(REPLACE(CEN.Descripcion, CHAR(10), ' '), CHAR(13), ' ') + '_' + REPLACE(REPLACE(MAT.PDescripcion, CHAR(10), ' '), CHAR(13), ' ') + '_' + REPLACE(REPLACE(MAT.RDescripcion, CHAR(10), ' '), CHAR(13), ' ') AS Pregunta, CONVERT(VARCHAR(16), MAT.CEPNumero) AS Pregunta1, CONVERT(VARCHAR(16), MAT.CPMNumero) AS Pregunta2, CONVERT(VARCHAR(16), MAT.CRMNumero) AS Pregunta3, ");
                else
                    sConsulta.AppendLine("SELECT ENC.ENCId, CEN.TipoRespuesta, MAT.CEPNumero, CONVERT(VARCHAR(16), MAT.CEPNumero) + '_' + CONVERT(VARCHAR(16), MAT.CPMNumero) + '_' + CONVERT(VARCHAR(16), MAT.CRMNumero) AS Pregunta, CONVERT(VARCHAR(16), MAT.CEPNumero) AS Pregunta1, CONVERT(VARCHAR(16), MAT.CPMNumero) AS Pregunta2, CONVERT(VARCHAR(16), MAT.CRMNumero) AS Pregunta3, ");
                sConsulta.AppendLine("CASE WHEN ENP.ENCId IS NULL THEN '*NA' ELSE CASE WHEN MAT.TipoValor = 1 THEN CASE WHEN ERM.ERMId IS NULL or ERM.Valor = 0 THEN '' ELSE 'SI' END ELSE ERM.Valor END END AS Respuesta, CEN.Orden ");
                sConsulta.AppendLine("FROM Encuesta ENC (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON ENC.VisitaClave = VIS.VisitaClave AND ENC.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON VIS.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine("RIGHT JOIN #tmpMatriz MAT (NOLOCK) ON ENC.CENClave = MAT.CENClave ");
                sConsulta.AppendLine("INNER JOIN CENPregunta CEN (NOLOCK) ON CEN.CENClave = MAT.CENClave AND CEN.CEPNumero = MAT.CEPNumero ");
                sConsulta.AppendLine("LEFT JOIN ENCPregunta ENP (NOLOCK) ON ENC.ENCId = ENP.ENCId AND MAT.CENClave = ENP.CENClave AND MAT.CEPNumero = ENP.CEPNumero ");
                sConsulta.AppendLine("LEFT JOIN ENPRespMatricial ERM (NOLOCK) ON ENP.ENCId = ERM.ENCId AND ENP.ENPId = ERM.ENPId ");
                sConsulta.AppendLine("AND MAT.CENClave = ERM.CENClave AND MAT.CEPNumero = ERM.CEPNumero AND MAT.CPMNumero = ERM.CPMNumero ");
                sConsulta.AppendLine("AND MAT.CENClave = ERM.CENClave1 AND MAT.CEPNumero = ERM.CEPNumero1 AND MAT.CRMNumero = ERM.CRMNumero ");
                sConsulta.AppendLine("WHERE ENC.CENClave = @CENClave AND Dia.FechaCaptura BETWEEN @FechaIni AND @FechaFin ");
                if (Rutas != null && Rutas != "" && Rutas != "null")
                    sConsulta.AppendLine("AND VIS.RUTClave IN (" + Rutas + ") ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("--GPS Latitud ");
                if (Reporte == 79) //Disposur
                    sConsulta.AppendLine("SELECT ENC.ENCId, CEN.TipoRespuesta, CRG.CEPNumero, REPLACE(REPLACE(CEN.Descripcion, CHAR(10), ' '), CHAR(13), ' ') + '_Latitud' AS Pregunta, CONVERT(VARCHAR(32), CRG.CEPNumero) AS Pregunta1, '2' AS Pregunta2, '' AS Pregunta3, CASE WHEN ENP.ENCId IS NULL THEN '*NA' ELSE str(ERG.Latitud, 20, 12) END AS Respuesta, CEN.Orden ");
                else
                    sConsulta.AppendLine("SELECT ENC.ENCId, CEN.TipoRespuesta, CRG.CEPNumero, CONVERT(VARCHAR(32), CRG.CEPNumero) + '_Latitud' AS Pregunta, CONVERT(VARCHAR(32), CRG.CEPNumero) AS Pregunta1, '2' AS Pregunta2, '' AS Pregunta3, CASE WHEN ENP.ENCId IS NULL THEN '*NA' ELSE str(ERG.Latitud, 20, 12) END AS Respuesta, CEN.Orden ");
                sConsulta.AppendLine("FROM Encuesta ENC (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON ENC.VisitaClave = VIS.VisitaClave AND ENC.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON VIS.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine("RIGHT JOIN CEPRespGPS CRG (NOLOCK) ON ENC.CENClave = CRG.CENClave ");
                sConsulta.AppendLine("INNER JOIN CENPregunta CEN (NOLOCK) ON CEN.CENClave = CRG.CENClave AND CEN.CEPNumero = CRG.CEPNumero ");
                sConsulta.AppendLine("LEFT JOIN ENCPregunta ENP (NOLOCK) ON ENC.ENCId = ENP.ENCId AND CRG.CENClave = ENP.CENClave AND CRG.CEPNumero = ENP.CEPNumero ");
                sConsulta.AppendLine("LEFT JOIN ENPRespGPS ERG (NOLOCK) ON ENP.ENCId = ERG.ENCId AND ENP.ENPId = ERG.ENPId ");
                sConsulta.AppendLine("WHERE ENC.CENClave = @CENClave AND Dia.FechaCaptura BETWEEN @FechaIni AND @FechaFin ");
                if (Rutas != null && Rutas != "" && Rutas != "null")
                    sConsulta.AppendLine("AND VIS.RUTClave IN (" + Rutas + ") ");
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("--GPS Longitud ");
                if (Reporte == 79) //Disposur
                    sConsulta.AppendLine("SELECT ENC.ENCId, CEN.TipoRespuesta, CRG.CEPNumero, REPLACE(REPLACE(CEN.Descripcion, CHAR(10), ' '), CHAR(13), ' ') + '_Longitud' AS Pregunta, CONVERT(VARCHAR(32), CRG.CEPNumero) AS Pregunta1, '3' AS Pregunta2, '' AS Pregunta3, CASE WHEN ENP.ENCId IS NULL THEN '*NA' ELSE str(ERG.Longitud, 20, 12) END AS Respuesta, CEN.Orden ");
                else
                    sConsulta.AppendLine("SELECT ENC.ENCId, CEN.TipoRespuesta, CRG.CEPNumero, CONVERT(VARCHAR(32), CRG.CEPNumero) + '_Longitud' AS Pregunta, CONVERT(VARCHAR(32), CRG.CEPNumero) AS Pregunta1, '3' AS Pregunta2, '' AS Pregunta3, CASE WHEN ENP.ENCId IS NULL THEN '*NA' ELSE str(ERG.Longitud, 20, 12) END AS Respuesta, CEN.Orden ");
                sConsulta.AppendLine("FROM Encuesta ENC (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON ENC.VisitaClave = VIS.VisitaClave AND ENC.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON VIS.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine("RIGHT JOIN CEPRespGPS CRG (NOLOCK) ON ENC.CENClave = CRG.CENClave ");
                sConsulta.AppendLine("INNER JOIN CENPregunta CEN (NOLOCK) ON CEN.CENClave = CRG.CENClave AND CEN.CEPNumero = CRG.CEPNumero ");
                sConsulta.AppendLine("LEFT JOIN ENCPregunta ENP (NOLOCK) ON ENC.ENCId = ENP.ENCId AND CRG.CENClave = ENP.CENClave AND CRG.CEPNumero = ENP.CEPNumero ");
                sConsulta.AppendLine("LEFT JOIN ENPRespGPS ERG (NOLOCK) ON ENP.ENCId = ERG.ENCId AND ENP.ENPId = ERG.ENPId ");
                sConsulta.AppendLine("WHERE ENC.CENClave = @CENClave AND Dia.FechaCaptura BETWEEN @FechaIni AND @FechaFin ");
                if (Rutas != null && Rutas != "" && Rutas != "null")
                    sConsulta.AppendLine("AND VIS.RUTClave IN (" + Rutas + ") "); ;
                sConsulta.AppendLine("UNION ALL ");
                sConsulta.AppendLine("--Imagen ");
                if (Reporte == 79) //Disposur
                    sConsulta.AppendLine("SELECT ENC.ENCId, CEN.TipoRespuesta, CRI.CEPNumero, REPLACE(REPLACE(CEN.Descripcion, CHAR(10), ' '), CHAR(13), ' ') AS Pregunta, CONVERT(VARCHAR(32), CRI.CEPNumero) AS Pregunta1, CONVERT(VARCHAR(32), CRI.CEPNumero) AS Pregunta2, CONVERT(VARCHAR(32), CRI.CEPNumero) AS Pregunta3, CASE WHEN ERI.ERIId IS NULL or cast(Imagen AS varbinary(max)) = 0x00 THEN '' ELSE ERI.ERIId END AS Respuesta, CEN.Orden ");
                else
                    sConsulta.AppendLine("SELECT ENC.ENCId, CEN.TipoRespuesta, CRI.CEPNumero, CONVERT(VARCHAR(32), CRI.CEPNumero) AS Pregunta, CONVERT(VARCHAR(32), CRI.CEPNumero) AS Pregunta1, CONVERT(VARCHAR(32), CRI.CEPNumero) AS Pregunta2, CONVERT(VARCHAR(32), CRI.CEPNumero) AS Pregunta3, CASE WHEN ERI.ERIId IS NULL or cast(Imagen AS varbinary(max)) = 0x00 THEN '' ELSE ERI.ERIId END AS Respuesta, CEN.Orden ");
                sConsulta.AppendLine("FROM Encuesta ENC (NOLOCK) ");
                sConsulta.AppendLine("INNER JOIN Visita VIS (NOLOCK) ON ENC.VisitaClave = VIS.VisitaClave AND ENC.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("INNER JOIN Dia (NOLOCK) ON VIS.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine("RIGHT JOIN CEPRespImagen CRI (NOLOCK) ON ENC.CENClave = CRI.CENClave ");
                sConsulta.AppendLine("INNER JOIN CENPregunta CEN (NOLOCK) ON CEN.CENClave = CRI.CENClave AND CEN.CEPNumero = CRI.CEPNumero ");
                sConsulta.AppendLine("LEFT JOIN ENCPregunta ENP (NOLOCK) ON ENC.ENCId = ENP.ENCId AND CRI.CENClave = ENP.CENClave AND CRI.CEPNumero = ENP.CEPNumero ");
                sConsulta.AppendLine("LEFT JOIN ENPRespImagen ERI (NOLOCK) ON ENP.ENCId = ERI.ENCId AND ENP.ENPId = ERI.ENPId ");
                sConsulta.AppendLine("WHERE ENC.CENClave = @CENClave AND Dia.FechaCaptura BETWEEN @FechaIni AND @FechaFin ");
                if (Rutas != null && Rutas != "" && Rutas != "null")
                    sConsulta.AppendLine("AND VIS.RUTClave IN (" + Rutas + ") ");
                sConsulta.AppendLine(") AS t ");
                sConsulta.AppendLine("ORDER BY ENCId, Orden, CEPNumero, CONVERT(int, pregunta1), CONVERT(int, pregunta2), CONVERT(int, pregunta3) ");

                sConsulta.AppendLine("DROP TABLE #tmpMatriz ");
                sConsulta.AppendLine("SET NOCOUNT OFF ");

                QueryString = sConsulta.ToString();

                Connection.Open();
                List<DetEncuestaAplicadaModel> Detalle = Connection.Query<DetEncuestaAplicadaModel>(QueryString, null, null, true, 9000).ToList();
                Connection.Close();

                if (EncuestasApl.Count() <= 0)
                    return false;
                else
                {
                    //string fileName = GenerarExcel(ConfigEncuesta, EncuestasApl, Detalle);
                    //DownloadFile.DownloadOpenXML(fileName);
                    ArchivoXlsModel file = GenerarExcel(ConfigEncuesta, EncuestasApl, Detalle);
                    DownloadFile.DownloadOpenXML(file);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private ArchivoXlsModel GenerarExcel(ConfigEncuestaModel ConfigEncuesta, List<EncEncuestaAplicadaModel> Encuestas, List<DetEncuestaAplicadaModel> Detalles)
        {
            //string path = ConfigurationManager.AppSettings.Get("pathReportes");
            //string fileName = path + @"\EncAplicada_" + DateTime.Now.ToString("ddMMyyyy_hhmmss") + ".xlsx";
            string fileName = "EncAplicada_" + DateTime.Now.ToString("ddMMyyyy_hhmmss") + ".xlsx";

            string urlImagen = ConfigurationManager.AppSettings.Get("urlImagenes");
            MemoryStream ms = new MemoryStream();
            SpreadsheetDocument document = SpreadsheetDocument.Create(ms, SpreadsheetDocumentType.Workbook);
            //SpreadsheetDocument document = SpreadsheetDocument.Create(fileName, SpreadsheetDocumentType.Workbook, true);

            WorkbookPart workbookPart = document.AddWorkbookPart();
            workbookPart.Workbook = new Workbook();
            //workbookPart.Workbook.Save();

            WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
            worksheetPart.Worksheet = new Worksheet(new SheetData());

            Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());
            Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Encuestas Aplicadas" };
            sheets.Append(sheet);

            SharedStringTablePart sharedStringTablePart = workbookPart.AddNewPart<SharedStringTablePart>();
            SharedStringTable sharedStringTable = new SharedStringTable();
            sharedStringTablePart.SharedStringTable = sharedStringTable;
            sharedStringTablePart.SharedStringTable.Save();

            WorkbookStylesPart stylesPart = document.WorkbookPart.AddNewPart<WorkbookStylesPart>();
            stylesPart.Stylesheet = MyOpenXML.GenerateStyleSheet();
            stylesPart.Stylesheet.Save();

            Worksheet worksheet = new Worksheet();
            SheetData sheetData = new SheetData();

            // Constructing header
            Row row = new Row();
            row.Append(MyOpenXML.ConstructCell(ConfigEncuesta.CENClave + " - " + ConfigEncuesta.Descripcion, CellValues.String),
                       MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XTipo", "EM") + ": " + ConfigEncuesta.Tipo, CellValues.String));
            sheetData.AppendChild(row);

            row = new Row();
            sheetData.AppendChild(row);

            row = new Row();
            row.Append(
                    MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("EEARUTClave", "EM"), CellValues.String),
                    MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("EEARuta", "EM"), CellValues.String),
                    MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("EEADiaClave", "EM"), CellValues.String),
                    MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("EEAFase", "EM"), CellValues.String),
                    MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("EEAClienteClave", "EM"), CellValues.String),
                    MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("EEANombreCorto", "EM"), CellValues.String),
                    MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("EEARazonSocial", "EM"), CellValues.String),
                    MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("EEAIdElectronico", "EM"), CellValues.String),
                    MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("EEAFechaNacimiento", "EM"), CellValues.String),
                    MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("EEAVigExclusividad", "EM"), CellValues.String),
                    MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("EEACalle", "EM"), CellValues.String),
                    MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("EEANumero", "EM"), CellValues.String),
                    MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("EEANumInt", "EM"), CellValues.String),
                    MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("EEAColonia", "EM"), CellValues.String),
                    MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("EEALocalidad", "EM"), CellValues.String),
                    MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("EEAEntidad", "EM"), CellValues.String),
                    MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("EEACodigoPostal", "EM"), CellValues.String),
                    MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("EEAReferenciaDom", "EM"), CellValues.String));

            string sENCId = Encuestas.ToList()[0].ENCId;
            var preguntas = Detalles.Where(x => x.ENCId == sENCId).Select(x => new { x.Pregunta, x.Orden }).OrderBy(x => x.Orden);
            foreach (var oPregunta in preguntas)
            {
                row.Append(MyOpenXML.ConstructCell(oPregunta.Pregunta, CellValues.String));
            }
            sheetData.AppendChild(row);

            int nRowIndex = 4;

            Hyperlinks hyperlinks = new Hyperlinks();

            foreach (EncEncuestaAplicadaModel encuesta in Encuestas)
            {
                sENCId = encuesta.ENCId;
                row = new Row();
                row.Append(
                        MyOpenXML.ConstructCell(encuesta.RUTClave, CellValues.String),
                        MyOpenXML.ConstructCell(encuesta.Ruta, CellValues.String),
                        MyOpenXML.ConstructCell(encuesta.DiaClave, CellValues.String),
                        MyOpenXML.ConstructCell(encuesta.Fase, CellValues.String),
                        MyOpenXML.ConstructCell(encuesta.ClienteClave, CellValues.String),
                        MyOpenXML.ConstructCell(encuesta.NombreCorto, CellValues.String),
                        MyOpenXML.ConstructCell(encuesta.RazonSocial, CellValues.String),
                        MyOpenXML.ConstructCell(encuesta.IdElectronico, CellValues.String),
                        MyOpenXML.ConstructCell(encuesta.FechaNacimiento, CellValues.String),
                        MyOpenXML.ConstructCell(encuesta.VigExclusividad, CellValues.String),
                        MyOpenXML.ConstructCell(encuesta.Calle, CellValues.String),
                        MyOpenXML.ConstructCell(encuesta.Numero, CellValues.String),
                        MyOpenXML.ConstructCell(encuesta.NumInt, CellValues.String),
                        MyOpenXML.ConstructCell(encuesta.Colonia, CellValues.String),
                        MyOpenXML.ConstructCell(encuesta.Localidad, CellValues.String),
                        MyOpenXML.ConstructCell(encuesta.Entidad, CellValues.String),
                        MyOpenXML.ConstructCell(encuesta.CodigoPostal, CellValues.String),
                        MyOpenXML.ConstructCell(encuesta.ReferenciaDom, CellValues.String));

                int nColIndex = 19;
                var respuestas = Detalles
                    .Where(x => x.ENCId == sENCId)
                    .Select(x => new { x.TipoRespuesta, x.Respuesta, x.Orden })
                    .OrderBy(x => x.Orden)
                    .ToList();

                foreach (var oRespuesta in respuestas)
                {
                    if (oRespuesta.TipoRespuesta != 5)
                        row.Append(MyOpenXML.ConstructCell(oRespuesta.Respuesta, CellValues.String));
                    else
                    {
                        if (oRespuesta.Respuesta != "")
                        {
                            string cellReference = MyOpenXML.GetExcelColumnName(nColIndex) + nRowIndex.ToString();
                            int index = MyOpenXML.InsertSharedStringItem(oRespuesta.Respuesta + ".jpg", sharedStringTablePart);
                            Cell oCell = MyOpenXML.ConstructCell(index.ToString(), CellValues.SharedString, 1U);
                            row.Append(oCell);
                            hyperlinks.Append(MyOpenXML.CreateHyperlink(worksheetPart, urlImagen + oRespuesta.Respuesta + ".jpg", cellReference));
                        }
                        else
                            row.Append(MyOpenXML.ConstructCell(oRespuesta.Respuesta, CellValues.String));
                    }
                    nColIndex += 1;
                }
                sheetData.AppendChild(row);
                nRowIndex += 1;
            }

            worksheet.Append(sheetData);
            worksheet.InsertAfter<Hyperlinks>(hyperlinks, sheetData);
            worksheetPart.Worksheet = worksheet;

            workbookPart.Workbook.Save();

            // Close the document.
            document.Close();

            ArchivoXlsModel archivo = new ArchivoXlsModel();
            archivo.archivo = ms.ToArray();
            archivo.nombre = fileName;
            return archivo;

            //worksheetPart.Worksheet.Save();

            //}//using
            //return fileName;
        }//GenerarExcel

    }

    class ConfigEncuestaModel
    {
        public string CENClave { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; }
    }

    class EncEncuestaAplicadaModel
    {
        public string ENCId { get; set; }
        public string RUTClave { get; set; }
        public string Ruta { get; set; }
        public string DiaClave { get; set; }
        public string Fase { get; set; }
        public string ClienteClave { get; set; }
        public string NombreCorto { get; set; }
        public string RazonSocial { get; set; }
        public string IdElectronico { get; set; }
        public string FechaNacimiento { get; set; }
        public string VigExclusividad { get; set; }
        public string Calle { get; set; }
        public string Numero { get; set; }
        public string NumInt { get; set; }
        public string Colonia { get; set; }
        public string Localidad { get; set; }
        public string Entidad { get; set; }
        public string CodigoPostal { get; set; }
        public string ReferenciaDom { get; set; }
    }

    class DetEncuestaAplicadaModel
    {
        public string ENCId { get; set; }
        public int TipoRespuesta { get; set; }
        public string CEPNumero { get; set; }
        public string Pregunta { get; set; }
        public int Orden { get; set; }
        public string Respuesta { get; set; }
    }
}