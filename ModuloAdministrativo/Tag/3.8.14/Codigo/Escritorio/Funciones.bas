Attribute VB_Name = "Funciones"
Declare Function GetPrivateProFileString Lib "Kernel32" Alias "GetPrivateProfileStringA" (ByVal lpApplicationname As String, ByVal lpKeyname As Any, ByVal lpdefault As String, ByVal lpreturnedstring As String, ByVal nsize As Long, ByVal lpfilename As String) As Long

Declare Function CreateBarcodeObject Lib "MrvBarDLL.dll" (ByVal lpstrLicenseTo As String, ByVal lpstrRegCode As String) As Long
Declare Sub DestroyBarcodeObject Lib "MrvBarDLL.dll" (ByVal handle As Long)
Declare Function GetLastBarcodeErrorMessage Lib "MrvBarDLL.dll" (ByVal handle As Long, ByVal lpszErrorMsg As String) As Boolean
Declare Function get_Message Lib "MrvBarDLL.dll" (ByVal handle As Long, ByVal pVal As String) As Long
Declare Function put_Message Lib "MrvBarDLL.dll" (ByVal handle As Long, ByVal Val As String) As Long
Declare Function get_Picture Lib "MrvBarDLL.dll" (ByVal handle As Long, ByRef pVal As Object) As Long
Declare Function mbxExportImage Lib "MrvBarDLL.dll" (ByVal handle As Long, ByVal lpszFileName As String, ByVal imageFormat As Long) As Long
Declare Function put_Symbology Lib "MrvBarDLL.dll" (ByVal handle As Long, ByVal Val As Long) As Long
Declare Function put_Comment Lib "MrvBarDLL.dll" (ByVal handle As Long, ByVal Val As String) As Long

Global Server, Db, DbCxC, DbADM, UserDB, PasswordDB
Global Selected As Integer
Global Rs As New ADODB.Recordset, RsC As New ADODB.Recordset
Global Cnn As New ADODB.Connection
Global Rs2 As New ADODB.Recordset, RsC2 As New ADODB.Recordset
Global Rs3 As New ADODB.Recordset, RsC3 As New ADODB.Recordset
Global Cnn2 As New ADODB.Connection

Global StrCmd As String
Global BIdioma, Route As Boolean
Global Const ctFechaLarga = "dddd, dd ""de"" mmmm ""de"" yyyy"
Global Const ctHoraLarga = "hh:mm:ss ""hrs"""
Global IdCedis As Long, IdRuta, NomCedis, NomRuta, IdSurtido As Long, DiaActivo As Boolean, Mes, Agno, Fecha As Date, IdSistema
Global Status, StatusDesc, DocumentoAplicado As Boolean, ImportarCargaSugerida As Boolean
Global StatusDia, TipoUsuario, Usuario, DescTipoUsuario, Forma As Integer, Dec As Boolean, Password
Global FechaSel As Date
Global LModulos, LstDFacturas, Etiqueta01, Etiqueta02, URL As String, LModulosCPC
Global RFCCedis, RazonSocialCedis, DireccionFiscalCedis, CPC As Boolean
Global LstConfiguraLiquidacion, ObtieneTipoRuta, IdCarga, SQLVersion
Global strImpFactPiezas, strImpFactSucursal, strPeriodo

' PARA EL MANEJO DE EXCEL
Global RutaApl, DirectorioReportesXLS
Global XLSAplication As Excel.Application
Global XLSWorkBook As Excel.Workbook
Global XLSWorkSheet As Excel.Worksheet
Global XLSRange As Excel.Range
Global CeldaVacia As Integer
Global Columnas As Integer
Global Filas As Integer
Global IndexAnterior As Integer

Function ValidaUltimoDiaCerrado(IdCed As Long, Fec As Date) As Boolean
    StrCmd = "execute sel_StatusDias " & IdCed & ", '" & FormatDate(Fec) & "', 4"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    If Not Rs.EOF Then
        If FormatDate(Fec) <= FormatDate(Rs.Fields(0)) Then
            ValidaUltimoDiaCerrado = False
            MsgBox "¡ La fecha seleccionada debe ser mayor al último día de trabajo cerrado !", vbInformation + vbOKOnly, App.Title
            Exit Function
        End If
    Else
        ValidaUltimoDiaCerrado = False
        MsgBox "¡ La fecha seleccionada debe ser mayor al último día de trabajo cerrado !", vbInformation + vbOKOnly, App.Title
        Exit Function
    End If
    ValidaUltimoDiaCerrado = True
End Function

Function ValidaDiaySurtido(IdCed As Long, IdSurt As Long, Fec As Date) As Boolean
    StrCmd = "execute sel_StatusDias " & IdCed & ", '" & FormatDate(Fec) & "', 3"
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    If Not Rs.EOF Then
        If Rs.Fields(1) = "C" Then
            MsgBox "¡ No puedes hacer modificaciones en un Día que ya está Cerrado !", vbInformation + vbOKOnly, App.Title
            ValidaDiaySurtido = False
            MousePointer = 0
            Exit Function
        End If
    Else
        MsgBox "¡ No puedes hacer modificaciones en un Día que ya está Cerrado !", vbInformation + vbOKOnly, App.Title
        ValidaDiaySurtido = False
        MousePointer = 0
        Exit Function
    End If
    
    If IdSurt <> 0 Then
        StrCmd = "execute sel_ValidaSurtido " & IdCed & ", " & IdSurt
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        If Not Rs.EOF Then
            If Rs.Fields(0) = "C" Then
                MsgBox "¡ No puedes modificar un folio de Carga que ya se encuentra Aplicado !", vbInformation + vbOKOnly, App.Title
                ValidaDiaySurtido = False
                MousePointer = 0
                Exit Function
            End If
        Else
            MsgBox "¡ No puedes modificar un folio de Carga que ya se encuentra Aplicado !", vbInformation + vbOKOnly, App.Title
            ValidaDiaySurtido = False
            MousePointer = 0
            Exit Function
        End If
    End If
    
MousePointer = 0
ValidaDiaySurtido = True
End Function

Function OpenConn(IP, BD, User, Pass)
    On Error GoTo Err_Conn:
    
    MousePointer = 11
    
    If IsEmpty(IP) Or IsEmpty(BD) Or IsEmpty(User) Or IsEmpty(Pass) Then
        Conexion
    Else
        If Trim(IP) = "" Or Trim(BD) = "" Or Trim(User) = "" Or Trim(Pass) = "" Then Conexion
    End If
    
    OpenConn = False
    If Cnn.State = 1 Then Cnn.Close
    
    Cnn.ConnectionString = "Provider=" & SQLVersion & ";" & _
                            "Persist Security Info=False;" & _
                            "User ID=" & User & "; Password=" & Pass & ";" & _
                            "Initial Catalog=" & BD & ";" & _
                            "Data Source=" & IP
    Cnn.Open
    Cnn.CommandTimeout = 0
    Idioma
    OpenConn = True
    
No_Err_Conn:
    Exit Function
    
Err_Conn:
    MousePointer = 0
    OpenConn = False
    MsgBox "Error al tratar de conectarse. Error: " & Err.Description, vbCritical, "Error en la conexión"
    GoTo No_Err_Conn:
End Function

Sub Idioma()
    Rs.Open "select @@language", Cnn
    BIdioma = Trim(Rs.Fields(0))
    'DetComisiones.Lblmsg.Caption = BIdioma
End Sub

Sub CloseConn()
    If Cnn.State Then Cnn.Close
    Set Cnn = Nothing
End Sub

Function FileExists(Archivo As String) As Boolean
  FileExists = (Dir(Archivo, vbHidden) <> "")
  If Not FileExists Then FileExists = (Dir(Archivo) <> "")
End Function

Function FolderExists(Ruta As String) As Boolean
  FolderExists = (Dir(Ruta, vbDirectory) <> "")
  If Not FolderExists Then FolderExists = (Dir(Ruta) <> "")
End Function

Sub SearchInCombo(Combo As ComboBox, Text As String, LongText As Integer)
    For i = 0 To Combo.ListCount - 1
        If Left(Combo.List(i), LongText) = Trim(Text) Then
            Combo.ListIndex = i
            Exit For
        End If
    Next
End Sub

Function GetSelectedItems(LVObject As MSComctlLib.ListView, Col As Integer, ChkSel As Boolean) As String
Dim Val As Boolean
Dim strVals As String
        strVals = ""
        For i = 1 To LVObject.ListItems.Count
            Val = False
            If ChkSel Then
                If LVObject.ListItems(i).Checked Then Val = True
            Else
                If LVObject.ListItems(i).Selected Then Val = True
            End If
            If Val Then
                If Col = 0 Then
                    strVals = strVals & LVObject.ListItems(i) & "|"
                Else
                    strVals = strVals & LVObject.ListItems(i).SubItems(Col) & "|"
                End If
            End If
        Next
        GetSelectedItems = strVals
End Function

Function GetDataCBL(Records As ADODB.Recordset, CBObject As ComboBox, FirstRecord As String, IfEmpty As String) As Variant
    Dim TempRecs As Variant
    
    On Error Resume Next
    
    CBObject.Clear
    If Not Records.EOF Then
                
        If FirstRecord <> "" Then
            CBObject.AddItem "<" & FirstRecord & ">": CBObject.ItemData(CBObject.NewIndex) = 0
        End If

        Records.MoveLast: Records.MoveFirst
        TempRecs = Records.GetRows(Records.RecordCount)
        
        For i = 0 To UBound(TempRecs, 2)
            CBObject.AddItem TempRecs(1, i)
            CBObject.ItemData(CBObject.NewIndex) = TempRecs(0, i)
        Next
        GetDataCBL = TempRecs
        
    Else
        CBObject.AddItem "<" & IfEmpty & ">": CBObject.ItemData(CBObject.NewIndex) = 0
        GetDataCBL = Empty
    End If
    CBObject.ListIndex = 0
End Function

Function GetDataLVL(Records As ADODB.Recordset, LVObject As MSComctlLib.ListView, InitField As Integer, FinalField As Integer, Tipos) As Variant

    Dim LVColHeader As MSComctlLib.ColumnHeader
    Dim ListItemSel As MSComctlLib.ListItem
    Dim RSProcedure As ADODB.Recordset
    Dim TempRecs As Variant
    Dim ColNum
    Dim LstTipos
    
    LstTipos = Split(Tipos, "|")
    LVObject.ListItems.Clear
    LVObject.ColumnHeaders.Clear
    
    If Records.State = 0 Then Exit Function
    
    If Not Records.EOF Then
        
        On Error Resume Next
        
        BarWidth = 350
        
        CalcColWidth = False
        TotalColWidth = 0
        For i = InitField To FinalField
            TotalColWidth = TotalColWidth + SetListViewColumnWidth(Records.Fields(i).DefinedSize)
        Next
        If LVObject.Width - BarWidth > TotalColWidth Then
            CalcColWidth = True
            ColDiference = LVObject.Width - BarWidth - TotalColWidth
        End If
                
        ColNum = 0
        For i = InitField To FinalField
            If CalcColWidth = False Then
                ColWidth = SetListViewColumnWidth(Records.Fields(i).DefinedSize)
            Else
                ColWidth = SetListViewColumnWidth(Records.Fields(i).DefinedSize) + _
                            Int(ColDiference / (FinalField - InitField + 1))
            End If
            Set LVColHeader = LVObject. _
                ColumnHeaders.Add(, , Records.Fields(i).Name, _
                ColWidth)
                Select Case LstTipos(ColNum)
                    Case 1, 2, 3, 6 To 9: LVObject.ColumnHeaders(i).Alignment = lvwColumnRight
                    Case Else: LVObject.ColumnHeaders(i).Alignment = lvwColumnLeft
                End Select
            ColNum = ColNum + 1
        Next
        
        Records.MoveLast: Records.MoveFirst
        TempRecs = Records.GetRows(Records.RecordCount)
        Dim Val
        
        For i = 0 To UBound(TempRecs, 2)
            ColNum = 0
            For j = InitField To FinalField
                If ColNum = 0 Then
                    If ColNum <= UBound(LstTipos) Then
                        Select Case LstTipos(ColNum)
                            Case 0: 'string
                                Val = CStr(Trim(TempRecs(j, i)))
                            Case 1: 'entero
                                If IsNumeric(Trim(TempRecs(j, i))) Then
                                    Val = FormatNumber(CLng(Trim(TempRecs(j, i))), 0, vbFalse)
                                Else
                                    Val = 0
                                End If
                            Case 2: 'entero separador de miles
                                If IsNumeric(Trim(TempRecs(j, i))) Then
                                    Val = FormatNumber(CLng(Trim(TempRecs(j, i))), 0, vbTrue)
                                Else
                                    Val = 0
                                End If
                            Case 3: '2 dec sep de miles
                                If IsNumeric(Trim(TempRecs(j, i))) Then
                                    Val = FormatNumber(CLng(Trim(TempRecs(j, i))), 3, vbTrue)
                                Else
                                    Val = 0
                                End If
                            Case 4: 'fecha corta
                                Val = Format(Trim(TempRecs(j, i)), "dd/MM/yyyy")
                            Case 5: 'fecha larga
                                Val = Format(Trim(TempRecs(j, i)), " dd ""de"" MMMM ""de"" yyyy ")
                            Case 6: 'entero con 7 posiciones
                                If IsNumeric(Trim(TempRecs(j, i))) Then
                                    Val = Format(CLng(Trim(TempRecs(j, i))), "0000000")
                                Else
                                    Val = "0000000"
                                End If
                            Case 7: 'moneda
                                If IsNumeric(Trim(TempRecs(j, i))) Then
                                    Val = FormatCurrency(CDbl(Trim(TempRecs(j, i))), 3, vbTrue)
                                Else
                                    Val = FormatCurrency(0, 2, vbTrue)
                                End If
                            Case 8: 'porcentaje
                                If IsNumeric(Trim(TempRecs(j, i))) Then
                                    Val = FormatPercent(CDbl(Trim(TempRecs(j, i))), 2, vbTrue)
                                Else
                                    Val = FormatPercent(0, 2, vbTrue)
                                End If
                            Case 9: '3 dec sep de miles
                                If IsNumeric(Trim(TempRecs(j, i))) Then
                                    Val = FormatNumber(CDbl(Trim(TempRecs(j, i))), 3, vbTrue)
                                Else
                                    Val = 0
                                End If
                            Case 10: '7 dec sep de miles
                                If IsNumeric(Trim(TempRecs(j, i))) Then
                                    Val = FormatNumber(CDbl(Trim(TempRecs(j, i))), 7, vbTrue)
                                Else
                                    Val = 0
                                End If
                        End Select
                    End If
                    Set ListItemSel = LVObject.ListItems.Add(, , Val)
                Else
                    If TempRecs(j, i) <> "" Then
                        
                        If ColNum = 1 Then
                            a = 0
                        End If
                        
                        If ColNum <= UBound(LstTipos) Then
                            Select Case LstTipos(ColNum)
                                Case 0: 'string
                                    Val = CStr(Trim(TempRecs(j, i)))
                                Case 1: 'entero
                                    If IsNumeric(Trim(TempRecs(j, i))) Then
                                        Val = CLng(Trim(TempRecs(j, i)))
                                    Else
                                        Val = 0
                                    End If
                                Case 2: 'entero separador de miles
                                    If IsNumeric(Trim(TempRecs(j, i))) Then
                                        Val = FormatNumber(CLng(Trim(TempRecs(j, i))), 0, vbTrue)
                                    Else
                                        Val = 0
                                    End If
                                Case 3: '2 dec sep de miles
                                    If IsNumeric(Trim(TempRecs(j, i))) Then
                                        Val = FormatNumber(CLng(Trim(TempRecs(j, i))), 3, vbTrue)
                                    Else
                                        Val = 0
                                    End If
                                Case 4: 'fecha corta
                                    Val = Format(Trim(TempRecs(j, i)), "dd/MM/yyyy")
                                Case 5: 'fecha larga
                                    Val = Format(Trim(TempRecs(j, i)), " dd ""de"" MMMM ""de"" yyyy ")
                                Case 6: 'entero con 7 posiciones
                                    If IsNumeric(Trim(TempRecs(j, i))) Then
                                        Val = Format(CLng(Trim(TempRecs(j, i))), "0000000")
                                    Else
                                        Val = "0000000"
                                    End If
                                Case 7: 'moneda
                                    If IsNumeric(Trim(TempRecs(j, i))) Then
                                        Val = FormatCurrency(CDbl(Trim(TempRecs(j, i))), 3, vbTrue)
                                    Else
                                        Val = FormatCurrency(0, 2, vbTrue)
                                    End If
                                Case 8: 'porcentaje
                                    If IsNumeric(Trim(TempRecs(j, i))) Then
                                        Val = FormatPercent(CDbl(Trim(TempRecs(j, i))), 2, vbTrue)
                                    Else
                                        Val = FormatPercent(0, 2, vbTrue)
                                    End If
                                Case 9: '3 dec sep de miles
                                    If IsNumeric(Trim(TempRecs(j, i))) Then
                                        Val = FormatNumber(CDbl(Trim(TempRecs(j, i))), 3, vbTrue)
                                    Else
                                        Val = 0
                                    End If
                                Case 10: '7 dec sep de miles
                                    If IsNumeric(Trim(TempRecs(j, i))) Then
                                        Val = FormatNumber(CDbl(Trim(TempRecs(j, i))), 7, vbTrue)
                                    Else
                                        Val = 0
                                    End If
                            End Select
                        End If
                            
                        ListItemSel.SubItems(ColNum) = Val
                    Else
                        ListItemSel.SubItems(ColNum) = ""
                    End If
                End If
                ColNum = ColNum + 1
            Next
        Next
        GetDataLVL = TempRecs
    Else
        GetDataLVL = Empty
     End If

End Function

Function GetDataLVLFMT(Records As ADODB.Recordset, LVObject As MSComctlLib.ListView, InitField As Integer, FinalField As Integer, StrFormat As String) As Variant

    Dim LVColHeader As MSComctlLib.ColumnHeader
    Dim ListItemSel As MSComctlLib.ListItem
    Dim RSProcedure As ADODB.Recordset
    Dim TempRecs As Variant
    Dim ColNum
    Dim ArrFormat As Variant
    
    LVObject.ListItems.Clear
    LVObject.ColumnHeaders.Clear
    
    If Not Records.EOF Then
        
        On Error Resume Next
        
        ArrFormat = Split(StrFormat, ".")
        
        BarWidth = 350
        
        CalcColWidth = False
        TotalColWidth = 0
        For i = InitField To FinalField
            TotalColWidth = TotalColWidth + SetListViewColumnWidth(Records.Fields(i).DefinedSize)
        Next
        If LVObject.Width - BarWidth > TotalColWidth Then
            CalcColWidth = True
            ColDiference = LVObject.Width - BarWidth - TotalColWidth
        End If
                
        For i = InitField To FinalField
            If CalcColWidth = False Then
                ColWidth = SetListViewColumnWidth(Records.Fields(i).DefinedSize)
            Else
                ColWidth = SetListViewColumnWidth(Records.Fields(i).DefinedSize) + _
                            Int(ColDiference / (FinalField - InitField + 1))
            End If
            Set LVColHeader = LVObject. _
                ColumnHeaders.Add(, , Records.Fields(i).Name, _
                ColWidth)
        Next
        
        Records.MoveLast: Records.MoveFirst
        TempRecs = Records.GetRows(Records.RecordCount)
        Dim Val
        
        For i = 0 To UBound(TempRecs, 2)
            ColNum = 0
            For j = InitField To FinalField
                If ColNum = 0 Then
                    Set ListItemSel = LVObject.ListItems.Add(, , TempRecs(j, i))
                Else
                    ListItemSel.SubItems(ColNum) = Trim(TempRecs(j, i))
                End If
                ColNum = ColNum + 1
            Next
        Next
        GetDataLVLFMT = TempRecs
    Else
        GetDataLVLFMT = Empty
    End If

End Function

Sub LimpiaOpciones(Form As Form)
    For i = 0 To Form.LblOpt.Count - 1
        If i <> Selected Then
            Form.LblOpt(i).FontBold = False
            Form.LblOpt(i).BackColor = vbWhite
        End If
    Next
End Sub

Sub SeleccionaOpcion(Lbl As Label)
    Selected = Lbl.Index
End Sub

Sub OverOpcion(Lbl As Label, Form As Form)
    LimpiaOpciones Form
    Lbl.BackColor = &HEEEEEE
    Lbl.FontBold = False
End Sub

Sub SelText(TxtB As TextBox)
    TxtB.SelStart = 0
    TxtB.SelLength = Len(TxtB.Text)
End Sub

Sub Val_TxtId(TxtId As TextBox, TxtD As TextBox, TxtC As TextBox, Opc As Integer)
Dim IdMov As Long
    Dec = False
    If Trim(TxtId.Text) <> "" Then
        If Opc = 3 Then
            IdMov = 0
        Else
            If Opc <> 2 Then IdMov = AL_Almacen.LstEntradas.SelectedItem
        End If
        StrCmd = "execute sel_BuscaProdInventario " & IdCedis & ", '" & FormatDate(Fecha) & "', " & Agno & ", " & Mes & ", " & TxtId.Text & ", " & IdMov & ", " & Opc
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        
        Dim StatusProd
        If Not Rs.EOF Then
            
            'valida el status del producto
            If Opc = 1 Or Opc = 2 Then
                StatusProd = UCase(Trim(Rs.Fields(5)))
                If Opc = 1 Then
                    If AL_Almacen.LstDEntradas(8, AL_Almacen.LstEntradas.SelectedItem.Index - 1) = "S" Then StatusProd = "A"
                End If
            Else
                StatusProd = UCase(Trim(Rs.Fields(7)))
            End If
            
            If StatusProd <> "A" Then
                MsgBox "¡ El Producto " & TxtId.Text & " está dado de Baja !", vbInformation + vbOKOnly, App.Title
                TxtD.Text = "¡ Producto dado de Baja !": TxtC.Text = 0
                TxtId.SetFocus
                Exit Sub
            End If
            
            'valida familia de producto en movimiento
            If Opc = 1 Then
                StrCmd = "execute sel_MovimientosFamilias " & IdCedis & ", " & AL_Almacen.LstDEntradas(7, AL_Almacen.LstEntradas.SelectedItem.Index - 1) & ", " & TxtId.Text & ", 1"
                If RsC.State Then RsC.Close
                RsC.Open StrCmd, Cnn
                If RsC.EOF Then
                    MsgBox "¡ El Producto " & TxtId.Text & " no se puede registrar dentro de este Tipo de Movimiento de Almacén !", vbInformation + vbOKOnly, App.Title
                    TxtD.Text = "¡ Producto no válido para este Tipo de Movimiento !": TxtC.Text = 0
                    TxtId.SetFocus
                    Exit Sub
                End If
            End If
            
            TxtD.Text = UCase(Rs.Fields(1))
            TxtC.Text = Rs.Fields(2)
            If Opc = 1 Or Opc = 2 Then
                If Rs.Fields(4) = 1 Then Dec = True
            Else
                If Rs.Fields(6) = 1 Then Dec = True
            End If
        Else
            MsgBox "¡ El Producto " & TxtId.Text & " no existe !", vbInformation + vbOKOnly, App.Title
            TxtD.Text = "¡ Producto no econtrado !": TxtC.Text = 0
        End If
    Else
        TxtD.Text = "": TxtC.Text = 0
    End If
    TxtC.SetFocus
End Sub

Function FormatDate(Fecha As Date) As String

    FormatDate = IIf(BIdioma = "us_english", Format(Fecha, "mm/dd/yyyy"), Format(Fecha, "dd/mm/yyyy"))
    
End Function


Sub Conexion()

On Error GoTo Err_ConnIni:
    
Dim sSpaces As String ' This will hold the input that the program will retrieve
Dim szReturn As String ' This will be the defaul value if the string is not found
Dim Msg As String

MousePointer = 11

 If FileExists(App.Path & "\conexion.ini") Then
    
    'Define a cual  base de datos se conectara ADM
    sSpaces = Space(100)
    GetPrivateProFileString "Parametros", "DataBaseADM", szReturn, sSpaces, Len(sSpaces), App.Path & "\Conexion.ini"
    DbADM = Mid(Trim(sSpaces), 1, Len(Trim(sSpaces)) - 1)
    
    'Define a cual  base de datos se conectara CPC
    sSpaces = Space(100)
    GetPrivateProFileString "Parametros", "DataBaseCPC", szReturn, sSpaces, Len(sSpaces), App.Path & "\Conexion.ini"
    DbCxC = Mid(Trim(sSpaces), 1, Len(Trim(sSpaces)) - 1)
    
    'Define a cual servidor se conectara
    sSpaces = Space(100)
    GetPrivateProFileString "Parametros", "Server", szReturn, sSpaces, Len(sSpaces), App.Path & "\Conexion.ini"
    Server = Mid(Trim(sSpaces), 1, Len(Trim(sSpaces)) - 1)
            
    'Define el Usuario
    sSpaces = Space(100)
    GetPrivateProFileString "Parametros", "User", szReturn, sSpaces, Len(sSpaces), App.Path & "\Conexion.ini"
    UserDB = Mid(Trim(sSpaces), 1, Len(Trim(sSpaces)) - 1)
            
    'Define Contraseña
    sSpaces = Space(100)
    GetPrivateProFileString "Parametros", "Password", szReturn, sSpaces, Len(sSpaces), App.Path & "\Conexion.ini"
    PasswordDB = Mid(Trim(sSpaces), 1, Len(Trim(sSpaces)) - 1)
            
    'Define Versión de SQL
    sSpaces = Space(100)
    GetPrivateProFileString "Parametros", "SQLVersion", szReturn, sSpaces, Len(sSpaces), App.Path & "\Conexion.ini"
    SQLVersion = Mid(Trim(sSpaces), 1, Len(Trim(sSpaces)) - 1)
    
    Db = DbADM
 Else
   MsgBox "No se encuentra el archivo: " & App.Path & "\Conexion.ini", vbInformation + vbOKOnly, "VERIFIQUE..."
 End If
 
No_Err_ConnIni:
    MousePointer = 0
    Exit Sub
    
Err_ConnIni:
    MousePointer = 0
    Msg = "¡ Error al iniciar el sistema !. " & Chr(13) & Chr(10) & Err.Description
    MsgBox Msg, vbInformation + vbOKOnly, App.Title
End Sub

Function CreateExcelFile() As Excel.Worksheet

  'Start a new workbook in Excel
   Set XLSAplication = CreateObject("Excel.Application")
   Set XLSWorkBook = XLSAplication.Workbooks.Add

   'Add data to cells of the first worksheet in the new workbook
   Set CreateExcelFile = XLSWorkBook.Worksheets(1)

End Function


Function OpenExcelFile(NombreArchivoXLS As String, DirectorioXLS As String, NumeroHoja As Integer) As Excel.Worksheet

    Set XLSAplication = CreateObject("Excel.Application")
    Set XLSWorkBook = XLSAplication.Workbooks.Open(RutaApl & DirectorioXLS & NombreArchivoXLS)
    Set OpenExcelFile = XLSWorkBook.Sheets(NumeroHoja)

End Function

Sub CloseExcelFile(XLSWorkSheet As Excel.Worksheet, GuardarCambios As Boolean, NombreArchivo As String)

    On Error Resume Next

    XLSWorkBook.Close GuardarCambios, NombreArchivo, RutaApl & DirectorioReportesXLS
    XLSAplication.Quit
    
    Set XLSWorkSheet = Nothing
    Set XLSWorkBook = Nothing
    Set XLSAplication = Nothing

End Sub

Sub ImpresionExcel(NombreArchivo As String, Titulo As String, Periodo As String, Records As ADODB.Recordset, CampoInicio As Integer, CampoFin As Integer, IdCedi As Integer, Cedis As String)

        'crear el archivo
        On Error GoTo ErrorAbrirXLS

        Screen.MousePointer = vbHourglass

        If Not FolderExists(RutaApl & DirectorioReportesXLS) Then
            MkDir RutaApl & DirectorioReportesXLS
        End If
        
        Set XLSWorkSheet = CreateExcelFile()

''            'escribir los datos
        XLSWorkSheet.Cells(2, 2).Font.Size = 12
        XLSWorkSheet.Cells(2, 2).Font.Bold = True
        XLSWorkSheet.Cells(2, 2) = Titulo
        
        XLSWorkSheet.Cells(3, 7).Font.Size = 8
        XLSWorkSheet.Cells(3, 7).Font.Bold = True
        XLSWorkSheet.Cells(3, 7) = "Fecha de Impresión:"
        XLSWorkSheet.Cells(3, 9).Font.Size = 8
        XLSWorkSheet.Cells(3, 9) = Format(Date, ctFechaLarga) & " / " & Format(Time, "HH:nn") & " hrs."
        
        XLSWorkSheet.Cells(3, 2).Font.Size = 10
        XLSWorkSheet.Cells(3, 2).Font.Bold = True
        XLSWorkSheet.Cells(3, 2) = IdCedi & " - " & Cedis
        
        XLSWorkSheet.Cells(5, 2).Font.Size = 8
        XLSWorkSheet.Cells(5, 2).Font.Bold = True
        XLSWorkSheet.Cells(5, 2) = "Fecha:"
        XLSWorkSheet.Cells(5, 3).Font.Size = 8
        XLSWorkSheet.Cells(5, 3) = Periodo

        For i = CampoInicio To CampoFin
            
            XLSWorkSheet.Cells(7, i - CampoInicio + 1).Font.Size = 8
            XLSWorkSheet.Cells(7, i - CampoInicio + 1).Font.Bold = True
            XLSWorkSheet.Cells(7, i - CampoInicio + 1) = Records.Fields(i).Name
            
        Next
        
        Renglon = 8
        While Not Records.EOF
            For i = CampoInicio To CampoFin
                XLSWorkSheet.Cells(Renglon, i - CampoInicio + 1).Font.Size = 8
                XLSWorkSheet.Cells(Renglon, i - CampoInicio + 1) = Records.Fields(i).Value
            Next
            Renglon = Renglon + 1
            Records.MoveNext
        Wend
                        
        'Save the Workbook and Quit Excel
        XLSWorkBook.SaveAs RutaApl & DirectorioReportesXLS & NombreArchivo
        XLSAplication.Quit

        MsgBox "El Archivo se Creó con Exito...", vbInformation + vbOKOnly, "Archivo XLS...."
        
        Screen.MousePointer = vbDefault
        
        Exit Sub
ErrorAbrirXLS:
    
    Screen.MousePointer = vbDefault
    
    MsgBox "No se pudo crear el Archivo """ & NombreArchivoXLS & """. ", vbExclamation, "Error...."

    Exit Sub

End Sub

Public Function ValidaCierre(IdCed, FechaS As Date) As Boolean

Dim LstStatusSurtido, LstExistenciaDia
Dim Mensaje As String

On Error GoTo Err_ValidaCierre:
        
        ValidaCierre = False
        
        'valida kardex antes de ...
        StrCmd = "exec up_ActualizaKardex " & IdCed & ", '" & FormatDate(FechaS) & "', 0, 1"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        
        'valido q este generada la factura de contado del día
        StrCmd = "execute sel_VentasContado " & IdCed & ", '" & FormatDate(FechaS) & "', 0, 3"
        If RsC.State Then RsC.Close
        RsC.Open StrCmd, Cnn
        If Not RsC.EOF Then
            StrCmd = "execute sel_VentasContado " & IdCed & ", '" & FormatDate(FechaS) & "', 0, 1"
            If RsC.State Then RsC.Close
            RsC.Open StrCmd, Cnn
            If RsC.EOF Then
                MsgBox "¡ Genere la Factura de Contado del día !", vbInformation + vbOKOnly, App.Title
                Exit Function
            End If
        End If
        
        'valido q este aplicado el inventario físico
        StrCmd = "exec sel_InvFisicoStatus " & IdCed & ", '" & FormatDate(FechaS) & "'"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        If Rs.EOF Then
            MsgBox "¡ Capture el inventario físico del día !", vbInformation + vbOKOnly, App.Title
            Exit Function
        End If
        While Not Rs.EOF
            If UCase(Trim(Rs.Fields(3))) <> "A" Then
                MsgBox "¡ Aplique el Inventario Físico del día !", vbInformation + vbOKOnly, App.Title
                Exit Function
            End If
            Rs.MoveNext
        Wend
                
        'valido q todos los movimientos de almacén estén aplicados
        StrCmd = "exec sel_Movimientos " & IdCed & ", '" & FormatDate(FechaS) & "'"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        While Not Rs.EOF
            If UCase(Mid(Trim(Rs.Fields(2)), 1, 1)) <> "A" Then
                MsgBox "¡ Debe Aplicar todos los movimientos de Almacén del día !", vbInformation + vbOKOnly, App.Title
                Exit Function
            End If
            Rs.MoveNext
        Wend
        
        'valida q todos los surtidos tengan existencias cero
        StrCmd = "execute sel_ExistenciaDia " & IdCed & ", '" & FormatDate(FechaS) & "', 1"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        If Not Rs.EOF Then
            LstExistenciaDia = Rs.GetRows
            Mensaje = ""
            For i = 0 To UBound(LstExistenciaDia, 2)
                If CLng(LstExistenciaDia(3, i)) <> 0 Then
                    Mensaje = Mensaje & " Liquidación " & Format(LstExistenciaDia(1, i), 0) & ", Ruta " & LstExistenciaDia(2, i) & ", Existencias " & FormatNumber(LstExistenciaDia(3, i), 2, vbTrue) & ". " & Chr(13) & Chr(10)
                End If
            Next i
            If Mensaje <> "" Then
                MsgBox "¡ No puedes Cerrar el Día " & FechaS & " porque algunas rutas tienen existencias !. " & Chr(13) & Chr(10) & Mensaje, vbInformation + vbOKOnly, App.Title
                Exit Function
            End If
        Else
            ' no hay surtidos capturados en el dìa deseas cerrarlo de cualqier forma ?
            If MsgBox("No hay Cargas capturadas en el Día " & FechaS & ". ¿ Quiere Cerrar el Día ?. " & Chr(13) & Chr(10) & "Una vez Cerrado el Día ya no podrá modificar la información.", vbQuestion + vbYesNo, App.Title) = vbYes Then GoTo CierraDia:
        End If
    
        'valida q todos los surtidos esten cerrados
        StrCmd = "execute sel_ExistenciaDia " & IdCed & ", '" & FormatDate(FechaS) & "', 2"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        If Not Rs.EOF Then
            LstStatusSurtido = Rs.GetRows
            Mensaje = ""
            For i = 0 To UBound(LstStatusSurtido, 2)
                If Trim(LstStatusSurtido(3, i)) <> "C" Then
                    Mensaje = Mensaje & " Liquidación " & Format(LstStatusSurtido(1, i), 0) & ", Ruta " & LstStatusSurtido(2, i) & ". " & Chr(13) & Chr(10)
                End If
            Next i
            If Mensaje <> "" Then
                MsgBox "¡ No puedes Cerrar el Día " & FechaS & " porque algunas Cargas no han sido Aplicadas !. " & Chr(13) & Chr(10) & Mensaje, vbInformation + vbOKOnly, App.Title
                Exit Function
            End If
        Else
            ' no hay surtidos capturados en el dìa deseas cerrarlo de cualqier forma ?
        End If
        
CierraDia:
        If MsgBox("¿ Está seguro que quiere Cerrar el Día " & FechaS & " ?. " & Chr(13) & Chr(10) & "Una vez Cerrado el Día ya no podrá modificar la información.", vbQuestion + vbYesNo, App.Title) = vbNo Then Exit Function
        
        StrCmd = "execute up_StatusDia " & IdCed & ", '" & FormatDate(FechaS) & "', '', '', '01/01/1900', 2"
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        
        MsgBox "¡ El Día " & FechaSel & " se ha cerrado correctamente !", vbInformation + vbOKOnly, App.Title
        
        ValidaCierre = True
        
No_Err_ValidaCierre:
    MousePointer = 0
    Exit Function
        
Err_ValidaCierre:
    MousePointer = 0
    MsgBox "Error: " & Err.Description, vbCritical + vbOKOnly, App.Title
    GoTo No_Err_ValidaCierre:
    
End Function

Function OpenConn2(IP, BD, User, Pass)
    On Error GoTo Err_Conn2:
    
    MousePointer = 11
    
    OpenConn2 = False
    If Cnn2.State = 1 Then Cnn2.Close
    Cnn2.ConnectionString = "Provider=" & SQLVersion & ";" & _
                            "Persist Security Info=False;" & _
                            "User ID=" & User & "; Password=" & Pass & ";" & _
                            "Initial Catalog=" & BD & ";" & _
                            "Data Source=" & IP
    Cnn2.Open
    Cnn2.CommandTimeout = 0
    OpenConn2 = True
    
No_Err_Conn2:
    Exit Function
    
Err_Conn2:
    MousePointer = 0
    OpenConn2 = False
    MsgBox "Error al tratar de conectarse. Error: " & Err.Description, vbCritical, "Error en la conexión"
    GoTo No_Err_Conn2:
End Function

Public Function ValidaModulo(Modulo, Mensaje As Boolean) As Boolean
    If Db <> "RouteCPC" Then
        For i = 0 To UBound(LModulos, 2)
            If Trim(Modulo) = Trim(LModulos(2, i)) Then
                ValidaModulo = True
                Exit Function
            End If
        Next i
        ValidaModulo = False
    Else
        For i = 0 To UBound(LModulosCPC, 2)
            If Trim(Modulo) = Trim(LModulosCPC(1, i)) Then
                ValidaModulo = True
                Exit Function
            End If
        Next i
        ValidaModulo = False
    End If
    If Mensaje Then MsgBox "¡ El usuario " & Usuario & " no tiene acceso a este módulo !", vbInformation + vbOKOnly, App.Title
End Function

Function strIds(Lst As ListView, Col As Integer) As String
    strIds = ""
    For i = 1 To Lst.ListItems.Count
        If Lst.ListItems(i).Checked Then
            If Col = 0 Then
                strIds = strIds & Trim(Lst.ListItems(i).Text) & ", "
            Else
                strIds = strIds & Trim(Lst.ListItems(i).ListSubItems(Col).Text) & ", "
            End If
        End If
    Next
    If strIds <> "" Then strIds = Mid(strIds, 1, Len(strIds) - 2)
End Function

Function strIdsCompuesto(Lst As ListView, Col1 As Integer, Col2 As Integer, Str1 As String, Str2 As String) As String
Dim Col1Ant
    strIdsCompuesto = "": Col1Ant = ""
    For i = 1 To Lst.ListItems.Count
        If Lst.ListItems(i).Checked Then
            If Col1 = 0 Then
                If Trim(Lst.ListItems(i).Text) <> Col1Ant Then
                    If Trim(strIdsCompuesto) <> "" Then strIdsCompuesto = Mid(strIdsCompuesto, 1, Len(strIdsCompuesto) - 2)
                    strIdsCompuesto = strIdsCompuesto & " )) ) or ( ( " & Str1 & " = " & Trim(Lst.ListItems(i).Text) & " ) and ( " & Str2 & " in ( "
                    Col1Ant = Trim(Lst.ListItems(i).Text)
                End If
                If Col2 = 0 Then
                    strIdsCompuesto = strIdsCompuesto & Trim(Lst.ListItems(i).Text) & ", "
                Else
                    strIdsCompuesto = strIdsCompuesto & Trim(Lst.ListItems(i).ListSubItems(Col2).Text) & ", "
                End If
            Else
                If Trim(Lst.ListItems(i).ListSubItems(Col1).Text) <> Col1Ant Then
                    If Trim(strIdsCompuesto) <> "" Then strIdsCompuesto = Mid(strIdsCompuesto, 1, Len(strIdsCompuesto) - 2)
                    strIdsCompuesto = strIdsCompuesto & " )) ) or ( ( " & Str1 & " = " & Trim(Lst.ListItems(i).ListSubItems(Col1).Text) & " ) and ( " & Str2 & " in ( "
                    Col1Ant = Trim(Lst.ListItems(i).Text)
                End If
                If Col2 = 0 Then
                    strIdsCompuesto = strIdsCompuesto & Trim(Lst.ListItems(i).Text) & ", "
                Else
                    strIdsCompuesto = strIdsCompuesto & Trim(Lst.ListItems(i).ListSubItems(Col2).Text) & ", "
                End If
            End If
        End If
    Next
    If Trim(strIdsCompuesto) <> "" Then strIdsCompuesto = Mid(strIdsCompuesto, 9, Len(strIdsCompuesto) - 10) & " )) ) "
End Function

Sub BusquedaDeFactura(XTop, XLeft, XWidth, XHeight)
    With CC_FacturasBusqueda
        .Top = XTop + ((XHeight - .Height) / 2)
        .Left = XLeft + ((XWidth - .Width) / 2)
        
        .Show
    End With
End Sub

Sub DetalleDeFactura(IdCedis, IdTipoVenta, Serie, Folio, XTop, XLeft, XWidth, XHeight, Base As Integer)
    With CC_Facturas
        .Top = XTop + ((XHeight - .Height) / 2)
        .Left = XLeft + ((XWidth - .Width) / 2)
        
        StrCmd = "Select Fecha from Ventas  where IdCedis = " & IdCedis & " and IdTipoVenta = " & IdTipoVenta & " and Serie = '" & Serie & "' and folio =  " & Folio
        If Rs.State Then Rs.Close
        Rs.Open StrCmd, Cnn
        Fecha = IIf(Rs.EOF, FormatDate("01011900"), Rs.Fields(0))
                
        .IdCedis = IdCedis: .IdTipoVenta = IdTipoVenta
        .Base = Base
        .Serie = Serie: .Folio = Folio: .FechaFact = Fecha
        .Show
    End With
End Sub

Function ValidaPeriodo(IdCedis, Agno, Periodo, Tipo, Status, Opc) As Boolean
    ValidaPeriodo = False
    strPeriodo = ""
    StrCmd = "execute sel_Periodo " & IdCedis & ", " & Agno & ", " & Periodo & ", '" & Tipo & "', '" & Status & ",' , " & Opc
    If Rs.State Then Rs.Close
    Rs.Open StrCmd, Cnn
    If Rs.EOF Then
        strPeriodo = "No existe infromación sobre el periodo seleccionado."
    Else
        ValidaPeriodo = IIf(Trim(Rs.Fields(0)) = "A", True, False)
        strPeriodo = IIf(Trim(Rs.Fields(0)) = "A", "Periodo ABIERTO para manejo de Cartera", "Periodo CERRADO para el manejo de Cartera")
    End If
End Function

Function Numeros_x_Letras(valor As Long) As String
    Dim Uni(1 To 3) As Long
    Dim unidad, Decena, Centenas
    unidad = Array("", "Uno ", "Dos ", "Tres ", "Cuatro ", "Cinco ", "Seis ", "Siete ", "Ocho ", "Nueve ", "Diez ", "Once ", "Doce ", "Trece ", "Catorce ", "Quince ", "Dieciseis ", "Diecisiete ", "Dieciocho ", "Diecinueve ")
    Decena = Array("", "Diez ", "Veinte ", "Treinta ", "Cuarenta ", "Cincuenta ", "Sesenta ", "Setenta ", "Ochenta ", "Noventa ")
    Centenas = Array("", "Ciento ", "Doscientos ", "Trescientos ", "Cuatroscientos ", "Quinientos ", "Seiscientos ", "Setecientos ", "Ochocientos ", "Novecientos ")
    
    If valor < 0 Then Texto = "Negativo "
    valor = Abs(valor)
    If valor > 999999 Then Uni(1) = Int(valor / 1000000)
    If valor > 999 Then Uni(2) = Int((valor - (Uni(1) * 1000000)) / 1000)
    Uni(3) = Int(valor - Uni(1) * 1000000 - Uni(2) * 1000)
    
    For Cont = 1 To 3
        c = Int(Uni(Cont) / 100)
        d = Int((Uni(Cont) - c * 100) / 10)
        u = Int(Uni(Cont) - c * 100 - d * 10)
        If c > 0 Then Texto = Texto + Centenas(c)
        If d * 10 + u < 20 Then
            Texto = Texto + unidad(d * 10 + u)
        Else
            Texto = Texto + Decena(d) + IIf(Trim(unidad(u)) <> "", "y ", " ") + unidad(u)
        End If
        If Cont = 1 And Uni(1) > 0 Then Texto = Texto + "Millones "
        If Cont = 2 And Uni(2) > 0 Then Texto = Texto + "Mil "
    Next Cont
    
    Select Case valor
        Case 10: Numeros_x_Letras = "Diez"
        Case 11: Numeros_x_Letras = "Once"
        Case 12: Numeros_x_Letras = "Doce"
        Case 13: Numeros_x_Letras = "Trece"
        Case 14: Numeros_x_Letras = "Catorce"
        Case 15: Numeros_x_Letras = "Quince"
        Case 16: Numeros_x_Letras = "Dieciseis"
        Case 17: Numeros_x_Letras = "Diecisiete"
        Case 18: Numeros_x_Letras = "Dieciocho"
        Case 19: Numeros_x_Letras = "Diecinueve"
        Case 20: Numeros_x_Letras = "Veinte"
        Case 21: Numeros_x_Letras = "Veintiuno"
        Case 22: Numeros_x_Letras = "Veintidos"
        Case 23: Numeros_x_Letras = "Veintitres"
        Case 24: Numeros_x_Letras = "Veinticuatro"
        Case 25: Numeros_x_Letras = "Veinticinco"
        Case 26: Numeros_x_Letras = "Veintiseis"
        Case 27: Numeros_x_Letras = "Veintisiete"
        Case 28: Numeros_x_Letras = "Veintiocho"
        Case 29: Numeros_x_Letras = "Veintinueve"
        Case 30: Numeros_x_Letras = "Treinta"
        Case 40: Numeros_x_Letras = "Cuarenta"
        Case 50: Numeros_x_Letras = "Cincuenta"
        Case 60: Numeros_x_Letras = "Sesenta"
        Case 70: Numeros_x_Letras = "Setenta"
        Case 80: Numeros_x_Letras = "Ochenta"
        Case 90: Numeros_x_Letras = "Noventa"
        Case Else: Numeros_x_Letras = Texto
    End Select
End Function

Sub ImpresionExcelCC(NombreArchivo As String, Titulo As String, Periodo As String, Records As ADODB.Recordset, CampoInicio As Integer, CampoFin As Integer, IdCedi As Integer, Cedis As String, IdReporte)

        'crear el archivo
        On Error GoTo ErrorAbrirXLS
        
        Dim Renglon, ColAnt, Saldo, IdCliente, Inicial

        Screen.MousePointer = vbHourglass

        If Not FolderExists(RutaApl & DirectorioReportesXLS) Then
            MkDir RutaApl & DirectorioReportesXLS
        End If
        
        Set XLSWorkSheet = CreateExcelFile()

''            'escribir los datos
        XLSWorkSheet.Cells(2, 2).Font.Size = 12
        XLSWorkSheet.Cells(2, 2).Font.Bold = True
        XLSWorkSheet.Cells(2, 2) = Titulo
        
        XLSWorkSheet.Cells(3, 7).Font.Size = 8
        XLSWorkSheet.Cells(3, 7).Font.Bold = True
        XLSWorkSheet.Cells(3, 7) = "Fecha de Impresión:"
        XLSWorkSheet.Cells(3, 9).Font.Size = 8
        XLSWorkSheet.Cells(3, 9) = Format(Date, ctFechaLarga) & " / " & Format(Time, "HH:nn") & " hrs."
        
        XLSWorkSheet.Cells(3, 2).Font.Size = 10
        XLSWorkSheet.Cells(3, 2).Font.Bold = True
        XLSWorkSheet.Cells(3, 2) = IdCedi & " - " & Cedis
        
        XLSWorkSheet.Cells(5, 2).Font.Size = 8
        XLSWorkSheet.Cells(5, 2).Font.Bold = True
        XLSWorkSheet.Cells(5, 2) = "Fecha:"
        XLSWorkSheet.Cells(5, 3).Font.Size = 8
        XLSWorkSheet.Cells(5, 3) = Periodo
        
        Dim strTitulo

        If IdReporte = 7 Then
            
            For i = 1 To 14
                Select Case i
                    Case 1:  strTitulo = "IdCedis"
                    Case 2:  strTitulo = "IdCliente"
                    Case 3:  strTitulo = "CTipo"
                    Case 4:  strTitulo = "RazonSocial"
                    Case 5:  strTitulo = "F. Factura"
                    Case 6:  strTitulo = "Serie"
                    Case 7:  strTitulo = "Folio"
                    Case 8:  strTitulo = "No Vencido"
                    Case 9:  strTitulo = "1 - 30"
                    Case 10:  strTitulo = "31 - 60"
                    Case 11: strTitulo = "61 - 90"
                    Case 12:  strTitulo = "91 - 120"
                    Case 13:  strTitulo = "> 120"
                    Case 14:  strTitulo = "Total"
                End Select
                XLSWorkSheet.Cells(7, i).Font.Size = 8
                XLSWorkSheet.Cells(7, i).Font.Bold = True
                XLSWorkSheet.Cells(7, i) = strTitulo
            Next i
        
        Else
            For i = CampoInicio To CampoFin
                XLSWorkSheet.Cells(7, i - CampoInicio + 1).Font.Size = 8
                XLSWorkSheet.Cells(7, i - CampoInicio + 1).Font.Bold = True
                XLSWorkSheet.Cells(7, i - CampoInicio + 1) = Records.Fields(i).Name
            Next
            If IdReporte = 18 Then
                XLSWorkSheet.Cells(7, CampoFin + 2).Font.Size = 8
                XLSWorkSheet.Cells(7, CampoFin + 2).Font.Bold = True
                XLSWorkSheet.Cells(7, CampoFin + 2) = "SALDO"
            End If
        End If
        
        Renglon = 8
        Saldo = 0: IdCliente = 0: Inicial = 0
        While Not Records.EOF
            If IdReporte = 7 Then
            
                XLSWorkSheet.Cells(Renglon, 1).Font.Size = 8
                XLSWorkSheet.Cells(Renglon, 1) = Records.Fields(0).Value
                XLSWorkSheet.Cells(Renglon, 2).Font.Size = 8
                XLSWorkSheet.Cells(Renglon, 2) = Records.Fields(6).Value
                XLSWorkSheet.Cells(Renglon, 3).Font.Size = 8
                XLSWorkSheet.Cells(Renglon, 3) = Records.Fields(7).Value
                
                XLSWorkSheet.Cells(Renglon, 4).Font.Size = 8
                XLSWorkSheet.Cells(Renglon, 4) = Records.Fields(8).Value
                XLSWorkSheet.Cells(Renglon, 5).Font.Size = 8
                XLSWorkSheet.Cells(Renglon, 5) = Records.Fields(4).Value
                XLSWorkSheet.Cells(Renglon, 6).Font.Size = 8
                XLSWorkSheet.Cells(Renglon, 6) = Records.Fields(2).Value
                XLSWorkSheet.Cells(Renglon, 7).Font.Size = 8
                XLSWorkSheet.Cells(Renglon, 7) = Records.Fields(3).Value
                
                Select Case Records.Fields(10)
                    Case Is < 1: ColAnt = 8
                    Case 1 To 30: ColAnt = 9
                    Case 31 To 60: ColAnt = 10
                    Case 61 To 90: ColAnt = 11
                    Case 91 To 120: ColAnt = 12
                    Case Is > 120: ColAnt = 13
                End Select
                
                XLSWorkSheet.Cells(Renglon, ColAnt).Font.Size = 8
                XLSWorkSheet.Cells(Renglon, ColAnt) = Records.Fields(9).Value
                XLSWorkSheet.Cells(Renglon, 14).Font.Size = 8
                XLSWorkSheet.Cells(Renglon, 14) = Records.Fields(9).Value
                
                Renglon = Renglon + 1
            Else
                For i = CampoInicio To CampoFin
                    XLSWorkSheet.Cells(Renglon, i - CampoInicio + 1).Font.Size = 8
                    XLSWorkSheet.Cells(Renglon, i - CampoInicio + 1) = Records.Fields(i).Value
                Next
                
                If IdReporte = 18 Then
                    If IdCliente <> Records.Fields(2).Value Then
                        Saldo = Records.Fields(11).Value
                        Inicial = Records.Fields(11).Value
                        IdCliente = Records.Fields(2)
                    Else
                        XLSWorkSheet.Cells(Renglon, CampoFin - 1).Font.Size = 8
                        XLSWorkSheet.Cells(Renglon, CampoFin - 1) = 0
                    End If
                    Saldo = Saldo + Records.Fields(12).Value - Records.Fields(13).Value
                    XLSWorkSheet.Cells(Renglon, CampoFin + 2).Font.Size = 8
                    XLSWorkSheet.Cells(Renglon, CampoFin + 2) = Saldo
                End If
                
                Renglon = Renglon + 1
            End If
            Records.MoveNext
        Wend
                        
        'Save the Workbook and Quit Excel
        XLSWorkBook.SaveAs RutaApl & DirectorioReportesXLS & NombreArchivo
        XLSAplication.Quit

        MsgBox "El Archivo se Creó con Exito...", vbInformation + vbOKOnly, "Archivo XLS...."
        
        Screen.MousePointer = vbDefault
        
        Exit Sub
ErrorAbrirXLS:
    
    Screen.MousePointer = vbDefault
    
    MsgBox "No se pudo crear el Archivo """ & NombreArchivoXLS & """. Error: " & Err.Description, vbExclamation, "Error...."

    Exit Sub

End Sub

Function SplitTxt(Txt As TextBox) As Double
Dim Operadores
    Operadores = Split(Txt.Text, "*")
    If UBound(Operadores, 1) > 0 Then
        For i = 0 To UBound(Operadores, 1)
            If i = 0 Then
                SplitTxt = CDbl(Operadores(i))
            Else
                SplitTxt = SplitTxt * CDbl(Operadores(i))
            End If
        Next i
        Txt.Text = SplitTxt
    End If
End Function
