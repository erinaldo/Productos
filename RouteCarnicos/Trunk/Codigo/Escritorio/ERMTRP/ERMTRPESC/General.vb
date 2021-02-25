Module General

    Public Function Operador(ByVal VAVClave As Integer, ByVal ValorIni As Object, ByVal ValorFin As Object, ByVal parTipoDato As TipoDato) As String
        Select Case VAVClave
            Case 1 'Igual
                Select Case parTipoDato
                    Case TipoDato.Fecha
                        Return " between " & UniFechaSQL(PrimeraHora(ValorIni)) & " AND " & UniFechaSQL(UltimaHora(ValorIni))
                    Case TipoDato.Numerico
                        Return " = " & ValorIni
                    Case TipoDato.Cadena
                        Return " = '" & ValorIni & "'"
                End Select
            Case 2 'Diferente
                Select Case parTipoDato
                    Case TipoDato.Fecha
                        Return " not between " & UniFechaSQL(PrimeraHora(ValorIni)) & " AND " & UniFechaSQL(UltimaHora(ValorIni))
                    Case TipoDato.Numerico
                        Return " <> " & ValorIni
                    Case TipoDato.Cadena
                        Return " <> '" & ValorIni & "'"
                End Select
            Case 3
                Select Case parTipoDato
                    Case TipoDato.Fecha 'Mayor que
                        Return " > " & UniFechaSQL(UltimaHora(ValorIni))
                    Case TipoDato.Numerico 'Mayor que
                        Return " > " & ValorIni
                    Case TipoDato.Cadena  'Empiece con
                        Return " like '" & ValorIni & "%'"
                End Select
            Case 4
                Select Case parTipoDato
                    Case TipoDato.Fecha 'Menor que
                        Return " < " & UniFechaSQL(PrimeraHora(ValorIni))
                    Case TipoDato.Numerico 'Menor que
                        Return " < " & ValorIni
                    Case TipoDato.Cadena 'Termine con
                        Return " like '%" & ValorIni & "'"
                End Select
            Case 5
                Select Case parTipoDato
                    Case TipoDato.Fecha 'Mayor igual que
                        Return " >= " & UniFechaSQL(PrimeraHora(ValorIni))
                    Case TipoDato.Numerico 'Mayor igual que
                        Return " >= " & ValorIni
                    Case TipoDato.Cadena 'Contenga
                        Return " like '%" & ValorIni & "%'"
                End Select
            Case 6
                Select Case parTipoDato
                    Case TipoDato.Fecha 'Menor igual que
                        Return " <= " & UniFechaSQL(UltimaHora(ValorIni))
                    Case TipoDato.Numerico 'Menor igual que
                        Return " <= " & ValorIni
                    Case TipoDato.Cadena 'No contenga
                        Return " not like '%" & ValorIni & "%'"
                End Select
            Case 7 'Entre
                Select Case parTipoDato
                    Case TipoDato.Fecha
                        Return " between " & UniFechaSQL(PrimeraHora(ValorIni)) & " and " & UniFechaSQL(UltimaHora(ValorFin))
                    Case TipoDato.Numerico
                        Return " between " & ValorIni & " and " & ValorFin
                End Select
        End Select
        Return String.Empty

    End Function

    Public Enum TipoDato
        Cadena = 1
        Numerico = 2
        Fecha = 3
    End Enum

    Public Function UniFechaSQL(ByVal pardFecha As Date, Optional ByVal optsTipoDatoDestino As String = "DATETIME", Optional ByVal optsFormato As String = "dd/MM/yyyy HH:mm:ss", Optional ByVal optsEstilo As String = "103") As String
        Return "'" & pardFecha.ToString("s") & "'"
    End Function

    Public Function PrimeraHora(ByVal parFecha As Date) As Date
        Dim f1 As New Date(parFecha.Year, parFecha.Month, parFecha.Day, 0, 0, 0)
        Return f1
    End Function
    Public Function UltimaHora(ByVal parFecha As Date) As Date
        Dim f2 As New Date(parFecha.Year, parFecha.Month, parFecha.Day, 23, 59, 59)
        Return f2
    End Function

    Public Sub ObtenerParametrosConexion(ByRef parsServidor As String, ByRef parsBaseDatos As String, ByRef parsUsuario As String, ByRef parsPassword As String)
        Dim sConexion As String
        Dim sParametros As String()
        Dim htParametros As New Hashtable(4)
#If DEBUG Then
        sConexion = LbConexion.cConexion.Instancia.CadenaConexion
        'sConexion = "Provider=SQLOLEDB;Data Source=RCEBALLOS;user id=sa;password=dbsa;initial catalog=ROUTE"
        'sConexion = "User ID=sa;Tag with column collation when possible=False;Data Source=192.168.0.11;Password=dbsa;Initial Catalog=ROUTE;Use Procedure for Prepare=1;Auto Translate=True;Persist Security Info=True;Provider=""SQLOLEDB.1"";Workstation ID=LaptopIng01;Use Encryption for Data=False;Packet Size=4096;Connect Timeout=15"
        'Dim ddd As New lbGeneral.cParametros
        'ddd.CargarParametros()
        'sConexion = lbGeneral.cParametros.Conexion
#Else
        sConexion = lbGeneral.cParametros.Conexion
#End If
        sParametros = sConexion.Split(";")
        For Each sParam As String In sParametros
            Dim sParams() As String
            sParams = sParam.Split("=")
            If sParams.Length > 0 Then
                htParametros.Add(sParams(0).Trim.ToUpper, sParams(1).Trim)
            End If
        Next
        If htParametros.Contains("DATA SOURCE") Then
            parsServidor = htParametros("DATA SOURCE")
        End If
        If htParametros.Contains("INITIAL CATALOG") Then
            parsBaseDatos = htParametros("INITIAL CATALOG")
        End If
        If htParametros.Contains("USER ID") Then
            parsUsuario = htParametros("USER ID")
        End If
        If htParametros.Contains("PASSWORD") Then
            parsPassword = htParametros("PASSWORD")
        End If

    End Sub

End Module
