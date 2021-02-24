Imports System.IO
Imports Microsoft.Office.Interop

Public Class MakingExcel

    Inherits System.Windows.Forms.Form

    Private FechaIni As String
    Private FechaFin As String
    Private bError As Boolean = False


    Dim m_Excel As Object
    Private Property objLibroExcel As Object
    Private Property objHojaExcel As Object

    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles BtnOK.Click
        If cmbFechaInicio.Value > CmbFechaFin.Value Then
            MessageBox.Show("Fecha Inicio no puede ser mayor que la fecha final", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Exit Sub
        End If
        pbProcesados.Minimum = 0
        pbProcesados.Value = 0

        FechaIni = CStr(cmbFechaInicio.Value)
        FechaFin = CStr(CmbFechaFin.Value.AddHours(23.9999))
        bError = False
        Dim Fila As Integer
        Dim FilaCapturada As Integer
        Dim Concecutivo As Integer
        Dim TotalFilas As Integer

        '' Llenamos el DataSet con la consulta de sql server
        Dim objDataSet As DataSet
        objDataSet = ModPOS.recuperaTabla_DTS("sp_xls_VentasAltena", "Ventas", "@Inicial", CDate(FechaIni), "@Final", CDate(FechaFin))

        Fila = 1
        FilaCapturada = 0
        Concecutivo = 0
        TotalFilas = objDataSet.Tables(0).Rows.Count
        pbProcesados.Maximum = TotalFilas
        LbTotalRegistros.Text = "Total de Registros: " & CStr(TotalFilas)
        ''recorremos el DTS
        For Each objRow As DataRow In objDataSet.Tables(0).Rows

            If Fila = 1 And FilaCapturada < TotalFilas Then

                '' Iniciamos una instancia a Excel
                m_Excel = New Excel.Application
                'm_Excel.Visible = True

                '' Creamos una variable para guardar la cultura actual
                Dim OldCultureInfo As System.Globalization.CultureInfo = _
                System.Threading.Thread.CurrentThread.CurrentCulture

                'Crear una cultura standard (en-US) inglés estados unidos
                System.Threading.Thread.CurrentThread.CurrentCulture = _
                New System.Globalization.CultureInfo("en-US")

                objLibroExcel = m_Excel.Workbooks.Add()
                objHojaExcel = objLibroExcel.Worksheets(1)
                objHojaExcel.Visible = Excel.XlSheetVisibility.xlSheetVisible
                objHojaExcel.Activate()

                ''Creamos los encabezados de las columans
                Dim objCelda As Excel.Range = objHojaExcel.Range("A1", Type.Missing)
                objCelda.Value = "ProductoClave"
                objCelda = objHojaExcel.Range("B1", Type.Missing)
                objCelda.Value = "CodAlmacen"
                objCelda = objHojaExcel.Range("C1", Type.Missing)
                objCelda.Value = "Cantidad"
                objCelda = objHojaExcel.Range("D1", Type.Missing)
                objCelda.Value = "TipoUnidad"
                objCelda = objHojaExcel.Range("E1", Type.Missing)
                objCelda.Value = "PeriodoDia"
                objCelda = objHojaExcel.Range("F1", Type.Missing)
                objCelda.Value = "ClaveCliente"
                objCelda = objHojaExcel.Range("G1", Type.Missing)
                objCelda.Value = "CanalCliente"
                objCelda = objHojaExcel.Range("H1", Type.Missing)
                objCelda.Value = "Precio"
                objCelda = objHojaExcel.Range("I1", Type.Missing)
                objCelda.Value = "PorcentajeDescuento"
                objCelda = objHojaExcel.Range("J1", Type.Missing)
                objCelda.Value = "ImporteDescuento"
                objCelda = objHojaExcel.Range("K1", Type.Missing)
                objCelda.Value = "PrecioNeto"
                objCelda = objHojaExcel.Range("L1", Type.Missing)
                objCelda.Value = "IEPS"
                objCelda = objHojaExcel.Range("M1", Type.Missing)
                objCelda.Value = "PrecioBruto"
                objCelda = objHojaExcel.Range("N1", Type.Missing)
                objCelda.Value = "IVA"
                objCelda = objHojaExcel.Range("O1", Type.Missing)
                objCelda.Value = "PrecioFinal"
                objCelda = objHojaExcel.Range("P1", Type.Missing)
                objCelda.Value = "FolioOperacion"
                objCelda = objHojaExcel.Range("Q1", Type.Missing)
                objCelda.Value = "TipoMov"
            End If

            objHojaExcel.Cells(Fila + 1, "A") = objRow.Item(0) 'ProductoClave
            objHojaExcel.Cells(Fila + 1, "B") = objRow.Item(1) 'CodAlmacen
            objHojaExcel.Cells(Fila + 1, "C") = objRow.Item(2) 'Cantidad
            objHojaExcel.Cells(Fila + 1, "D") = objRow.Item(3) 'TipoUnidad
            objHojaExcel.Cells(Fila + 1, "E") = objRow.Item(4) 'PeriodoDia
            objHojaExcel.Cells(Fila + 1, "F") = objRow.Item(5) 'ClaveCliente
            objHojaExcel.Cells(Fila + 1, "G") = objRow.Item(6) 'CanalCliente
            objHojaExcel.Cells(Fila + 1, "H") = objRow.Item(7) 'Precio
            objHojaExcel.Cells(Fila + 1, "I") = objRow.Item(8) 'PorcentajeDescuento
            objHojaExcel.Cells(Fila + 1, "J") = objRow.Item(9) 'ImporteDescuento
            objHojaExcel.Cells(Fila + 1, "K") = objRow.Item(10) 'PrecioNeto
            objHojaExcel.Cells(Fila + 1, "L") = objRow.Item(11) 'IEPS
            objHojaExcel.Cells(Fila + 1, "M") = objRow.Item(12) 'PrecioBruto
            objHojaExcel.Cells(Fila + 1, "N") = objRow.Item(13) 'IVA
            objHojaExcel.Cells(Fila + 1, "O") = objRow.Item(14) 'PrecioFinal
            objHojaExcel.Cells(Fila + 1, "P") = objRow.Item(15) 'FolioOperacion
            objHojaExcel.Cells(Fila + 1, "Q") = objRow.Item(16) 'TipoMov

            FilaCapturada += 1
            If Fila = ModPOS.Registros Or FilaCapturada = TotalFilas Then
                Concecutivo += 1
                '~~> Save As file

                objLibroExcel.SaveAs(Filename:=ModPOS.Ruta & "Ventas_" & cmbFechaInicio.Value.Year.ToString() & cmbFechaInicio.Value.Month.ToString() & cmbFechaInicio.Value.Day.ToString() & "-" & CmbFechaFin.Value.Year.ToString() & CmbFechaFin.Value.Month.ToString() & CmbFechaFin.Value.Day.ToString() & "_" & CStr(Concecutivo) & ".xlsx", FileFormat:=51, ReadOnlyRecommended:=False, CreateBackup:=False)
                'objLibroExcel.SaveAs(Filename:=ModPOS.Ruta & "Ventas_" & CStr(Concecutivo) & ".xlsx", FileFormat:=51, ReadOnlyRecommended:=False, CreateBackup:=False)
                '~~> Close the file
                'objLibroExcel.Close()
                m_Excel.Quit()
                Fila = 0
            End If
            Fila += 1
            pbProcesados.Value = FilaCapturada
            pbProcesados.Refresh()
        Next

        MessageBox.Show("Terminado Correctamente")
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        bError = False
        Me.Close()
    End Sub


    Private Function recuperaTabla_DTS(ByVal sp As String, ByVal Tabla As String, ByVal ParamArray Parametros() As Object) As DataSet
        Dim Cnx As System.Data.SqlClient.SqlConnection = Nothing
        Dim du As System.Data.SqlClient.SqlDataAdapter
        Dim dts As DataSet

        Cnx = New System.Data.SqlClient.SqlConnection

        Try
            Cnx.ConnectionString = ModPOS.BDConexion
            'Cnx.ConnectionString = ObtieneCadenaConexion()
            Cnx.Open()
        Catch ex As Exception
            Beep()
            MsgBox("No se puede conectar a la base de datos", MsgBoxStyle.Critical, "Error")
        End Try

        du = New System.Data.SqlClient.SqlDataAdapter

        Try

            Dim i As Integer

            With du
                .SelectCommand = New System.Data.SqlClient.SqlCommand(sp, Cnx)
                .SelectCommand.CommandTimeout = ModPOS.TimeOut
                .SelectCommand.CommandType = CommandType.StoredProcedure

                If Not Parametros Is Nothing Then
                    For i = 0 To Parametros.Length - 1 Step 2
                        Select Case Parametros(i + 1).GetType.Name
                            Case "String"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.VarChar).Value = Parametros(i + 1)
                            Case "Int32"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.Int).Value = Parametros(i + 1)
                            Case "Double"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.Decimal).Value = Parametros(i + 1)
                            Case "Decimal"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.Decimal).Value = Parametros(i + 1)
                            Case "Byte[]"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.Image).Value = Parametros(i + 1)
                            Case "Byte[]"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.SmallInt).Value = Parametros(i + 1)
                            Case "DateTime"
                                .SelectCommand.Parameters.Add(Parametros(i), SqlDbType.DateTime).Value = Parametros(i + 1)
                        End Select
                    Next
                End If
            End With


        Catch ex As Exception
            Beep()
            MsgBox("No se puede ejecutar la consulta", MsgBoxStyle.Critical, "Error")
        End Try

        dts = New DataSet

        Try
            du.Fill(dts, Tabla)
        Catch e As System.Data.SqlClient.SqlException
            MsgBox(e.Message)
        End Try

        du.Dispose()
        Cnx.Close()
        Return dts

    End Function

    Private Sub MakingExcel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.cmbFechaInicio.Value = Today
        Me.CmbFechaFin.Value = Today

    End Sub

End Class
