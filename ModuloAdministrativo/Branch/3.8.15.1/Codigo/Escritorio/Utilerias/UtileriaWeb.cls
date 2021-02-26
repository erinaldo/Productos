VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "UtileriaWeb"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = False
Private Declare Function IsValidURL Lib "urlmon" (ByVal pBC As Long, _
    url As Byte, ByVal dwReserved As Long) As Long
    
Public Function VerificarServicioTimbrado(Cnn As ADODB.Connection, Rs As ADODB.Recordset, ByRef mensaje As String) As Boolean
    VerificarServicioTimbrado = True
    Exit Function
    StrCmd = "execute sel_DatosCFD 0, 0, 0, 0, 6"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    Dim Resultado As Boolean
    Resultado = False
    If Not Rs.EOF Then
        Dim rutaTimbrado As String
        Dim b() As Byte
        rutaTimbrado = Rs.Fields("ServidorTimbre")
        Resultado = ValidaWeb(rutaTimbrado, mensaje)
        If Not Resultado Then
            mensaje = "No se puede establecer conexion con " & Rs.Fields("DescProveedor") & ": " & mensaje
        End If
    End If
    Rs.Close
    VerificarServicioTimbrado = Resultado
End Function

Public Function ValidaWeb(url As String, ByRef mensaje As String) As Boolean
Dim Ping As PingWeb
Set Ping = New PingWeb
Dim Resultado As Boolean
Resultado = Ping.RealizarPing(url, mensaje)
ValidaWeb = Resultado
End Function


