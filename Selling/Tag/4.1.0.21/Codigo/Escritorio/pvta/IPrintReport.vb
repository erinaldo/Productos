Imports System.Data.SqlClient
''' <summary>
''' Esta interface permite invocar a un método para enviar a la impresora y modo preliminar.
''' un reporte de Crystal Report .Net 10.0
''' </summary>
''' <remarks></remarks>
Public Interface IPrintReport


    Sub PrintPreview(ByVal TitleReport As String, ByVal FileReport As String, ByVal DataSource As DataSet, Optional ByVal Filter As String = "")

    Sub Print(ByVal Copies As Integer, ByVal FileReport As String, ByVal DataSource As DataSet, Optional ByVal Filter As String = "", Optional ByVal PrinterName As String = "")

    Sub PrintLogon(ByVal FileReport As String, ByVal Username As String, ByVal Password As String, _
    ByVal Servername As String, Optional ByVal Filter As String = "")


End Interface