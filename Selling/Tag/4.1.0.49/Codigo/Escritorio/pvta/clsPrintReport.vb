Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.Windows
Imports CrystalDecisions.Windows.Forms
Imports System.Windows.Forms
Public Class Report
    Implements IPrintReport
    Dim DidPreviouslyConnect As Boolean = False

    Public Sub PrintPreview(ByVal TitleReport As String, ByVal FileReport As String, ByVal DataSource As System.Data.DataSet, _
    Optional ByVal Filter As String = "", Optional ByVal Filter2 As String = "", Optional ByVal Filter3 As String = "", Optional ByVal Filter4 As String = "") Implements IPrintReport.PrintPreview

        Dim frmCRNet As New FrmPrint
        frmCRNet.Text = TitleReport
        Dim frmStatusMessage As New frmStatus
        Dim crStandarReport As New ReportDocument
        Dim DirActual As System.IO.DirectoryInfo = New System.IO.DirectoryInfo(Application.ExecutablePath).Parent
        Dim dir As String = DirActual.FullName() & "\Reportes\" & FileReport

        frmStatusMessage.Show("Estableciendo conexión...")
        Try
            Cursor.Current = Cursors.WaitCursor
            With frmCRNet

                With crStandarReport
                    .Load(dir)
                    .SetDataSource(DataSource)
                End With

                If Not Filter = "" Then
                    crStandarReport.SetParameterValue("@Letras", Filter)
                End If

                If Not Filter2 = "" Then
                    crStandarReport.SetParameterValue("@Leyenda", Filter2)
                End If

                If Not Filter3 = "" Then
                    crStandarReport.SetParameterValue("@Cambio", Filter3)
                End If

                If Not Filter4 = "" Then
                    crStandarReport.SetParameterValue("@ProximoNivel", Filter4)
                End If

                .CrystalReportViewer1.ReportSource = crStandarReport
                .CrystalReportViewer1.Refresh()
                .ShowDialog()


            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Try
        End Try
        Cursor.Current = Cursors.Default
        frmStatusMessage.Close()
        frmCRNet.Close()
    End Sub

    Public Sub Print(ByVal Copies As Integer, ByVal FileReport As String, ByVal DataSource As System.Data.DataSet, _
    Optional ByVal Filter As String = "", Optional ByVal PrinterName As String = "", Optional ByVal Filter2 As String = "", Optional ByVal Filter3 As String = "", Optional ByVal Filter4 As String = "", Optional ByVal Generic As Boolean = False) Implements IPrintReport.Print
        Dim frmStatusMessage As New frmStatus
        Dim crStandarReport As New ReportDocument
        Dim DirActual As System.IO.DirectoryInfo = New System.IO.DirectoryInfo(Application.ExecutablePath).Parent

        Dim dir As String = DirActual.FullName() & "\Reportes\" & FileReport

        If Not DidPreviouslyConnect Then
            frmStatusMessage.Show("Estableciendo conexión...")
        End If

        Try
            Cursor.Current = Cursors.WaitCursor

            With crStandarReport
                .Load(dir)
                .SetDataSource(DataSource)
            End With

            If Not Filter = "" Then
                crStandarReport.SetParameterValue("@Letras", Filter)
            End If

            If Not Filter2 = "" Then
                crStandarReport.SetParameterValue("@Leyenda", Filter2)
            End If


            If Not Filter3 = "" Then
                crStandarReport.SetParameterValue("@Cambio", Filter3)
            End If

            If Not Filter4 = "" Then
                crStandarReport.SetParameterValue("@ProximoNivel", Filter4)
            End If

            Dim printerActual As String = ""
            If Generic Then

                Dim settings As Printing.PrinterSettings = New Printing.PrinterSettings
                printerActual = settings.PrinterName
                SetDefaultPrinter(PrinterName)
                Dim PkSize As New System.Drawing.Printing.PaperSize
                PkSize = settings.PaperSizes.Item(settings.PaperSizes.Count - 1)
                'PkSize = New Printing.PaperSize("prueba", 284, 15748)
                crStandarReport.PrintOptions.PaperSize = CType(PkSize.RawKind, CrystalDecisions.Shared.PaperSize)
            Else
                crStandarReport.PrintOptions.PaperSize = PaperSize.DefaultPaperSize
            End If

            'crStandarReport.PrintOptions.DissociatePageSizeAndPrinterPaperSize 
            crStandarReport.PrintOptions.PrinterName = PrinterName


            Dim i As Integer
            For i = 1 To Copies
                crStandarReport.PrintToPrinter(1, False, 0, 0)
            Next

            If printerActual <> "" Then
                SetDefaultPrinter(printerActual)
            End If
            DidPreviouslyConnect = True
            frmStatusMessage.Close()


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Try
        End Try


        Cursor.Current = Cursors.Default
        frmStatusMessage.Close()
        crStandarReport.Close()

    End Sub

    <Runtime.InteropServices.DllImport("winspool.drv", CharSet:=Runtime.InteropServices.CharSet.Auto, SetLastError:=True)>
    Public Shared Function SetDefaultPrinter(Name As String) As Boolean
    End Function

    Public Sub PrintPDF(ByVal FileReport As String, ByVal DataSource As System.Data.DataSet, _
Optional ByVal Filter As String = "", Optional ByVal FileName As String = "")

        Dim frmStatusMessage As New frmStatus
        Dim crStandarReport As New ReportDocument

        Dim DirActual As System.IO.DirectoryInfo = New System.IO.DirectoryInfo(Application.ExecutablePath).Parent

        Dim dir As String = DirActual.FullName() & "\Reportes\" & FileReport

        frmStatusMessage.Show("Estableciendo conexión...")
        Try
            Cursor.Current = Cursors.WaitCursor

            With crStandarReport
                .Load(dir)
                .SetDataSource(DataSource)
            End With

            If Not Filter = "" Then
                crStandarReport.SetParameterValue("@Letras", Filter)
            End If

            crStandarReport.ExportToDisk(ExportFormatType.PortableDocFormat, FileName)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Try
        End Try

        Cursor.Current = Cursors.Default
        frmStatusMessage.Close()
        crStandarReport.Close()

    End Sub

    Public Sub PrintLogon(ByVal FileReport As String, ByVal Username As String, ByVal Password As String, _
    ByVal Servername As String, Optional ByVal Filter As String = "") Implements IPrintReport.PrintLogon

        Dim frmCRNet As New FrmPrint
        Dim frmStatusMessage As New frmStatus
        Dim IsConnecting As Boolean = True
        Dim crStandarReport As New ReportDocument

        Dim crSections As Sections
        Dim crSection As Section
        Dim crReportObjects As ReportObjects
        Dim crReportObject As ReportObject
        Dim crSubreportObject As SubreportObject
        Dim crSubreportDocument As ReportDocument

        Dim crDatabase As Database
        Dim crTables As Tables
        Dim crTable As Table
        Dim crTableLogOnInfo As TableLogOnInfo
        Dim crConnectioninfo As ConnectionInfo

        If Not DidPreviouslyConnect Then
            frmStatusMessage.Show("Estableciendo conexión...")
        End If

        While IsConnecting

            Try

                Cursor.Current = Cursors.WaitCursor
                crConnectioninfo = New ConnectionInfo

                With crConnectioninfo
                    .ServerName = Servername
                    .UserID = Username
                    .Password = Password
                End With

                With frmCRNet

                    crStandarReport.Load(FileReport)

                    crDatabase = crStandarReport.Database
                    crTables = crDatabase.Tables

                    For Each crTable In crTables
                        crTableLogOnInfo = crTable.LogOnInfo
                        crTableLogOnInfo.ConnectionInfo = crConnectioninfo
                        crTable.ApplyLogOnInfo(crTableLogOnInfo)
                    Next

                    crSections = crStandarReport.ReportDefinition.Sections

                    For Each crSection In crSections
                        crReportObjects = crSection.ReportObjects

                        For Each crReportObject In crReportObjects
                            If crReportObject.Kind = ReportObjectKind.SubreportObject Then

                                crSubreportObject = CType(crReportObject, SubreportObject)

                                crSubreportDocument = _
                                crSubreportObject.OpenSubreport(crSubreportObject.SubreportName)

                                crDatabase = crSubreportDocument.Database
                                crTables = crDatabase.Tables

                                For Each crTable In crTables
                                    With crConnectioninfo
                                        .ServerName = Servername
                                        .UserID = Username
                                        .Password = Password
                                    End With
                                    crTableLogOnInfo = crTable.LogOnInfo
                                    crTableLogOnInfo.ConnectionInfo = crConnectioninfo
                                    crTable.ApplyLogOnInfo(crTableLogOnInfo)
                                Next

                            End If
                        Next
                    Next

                    .CrystalReportViewer1.ReportSource = crStandarReport

                    If Not Filter = "" Then
                        .CrystalReportViewer1.SelectionFormula = Filter
                    End If

                    .CrystalReportViewer1.Refresh()
                    .Show()

                    IsConnecting = False
                    DidPreviouslyConnect = True
                    frmStatusMessage.Close()

                End With

            Catch ex As Exception

                MsgBox(ex.Message, MsgBoxStyle.Critical)
                Cursor.Current = Cursors.Default
                frmStatusMessage.Close()
                frmCRNet.Close()

                Exit While
                Exit Try

                Exit Sub

            End Try

        End While

    End Sub

    Public Sub PrintWord(ByVal TextOnly As Boolean, ByVal FileReport As String, ByVal DataSource As System.Data.DataSet, _
Optional ByVal Filter As String = "", Optional ByVal FileName As String = "")



        Dim frmStatusMessage As New frmStatus
        Dim crStandarReport As New ReportDocument

        Dim DirActual As System.IO.DirectoryInfo = New System.IO.DirectoryInfo(Application.ExecutablePath).Parent

        Dim dir As String = DirActual.FullName() & "\Reportes\" & FileReport

        frmStatusMessage.Show("Estableciendo conexión...")
        Try
            Cursor.Current = Cursors.WaitCursor

            With crStandarReport
                .Load(dir)
                .SetDataSource(DataSource)
            End With

            If Not Filter = "" Then
                crStandarReport.SetParameterValue("@Letras", Filter)
            End If

            If TextOnly = True Then
                crStandarReport.ExportToDisk(ExportFormatType.Text, FileName)
            Else
                crStandarReport.ExportToDisk(ExportFormatType.WordForWindows, FileName)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Try
        End Try

        Cursor.Current = Cursors.Default
        frmStatusMessage.Close()
        crStandarReport.Close()

    End Sub

    Public Sub PrintExcel(ByVal TextOnly As Boolean, ByVal FileReport As String, ByVal DataSource As System.Data.DataSet, _
Optional ByVal Filter As String = "", Optional ByVal FileName As String = "")



        Dim frmStatusMessage As New frmStatus
        Dim crStandarReport As New ReportDocument

        Dim DirActual As System.IO.DirectoryInfo = New System.IO.DirectoryInfo(Application.ExecutablePath).Parent

        Dim dir As String = DirActual.FullName() & "\Reportes\" & FileReport

        frmStatusMessage.Show("Estableciendo conexión...")
        Try
            Cursor.Current = Cursors.WaitCursor

            With crStandarReport
                .Load(dir)
                .SetDataSource(DataSource)
            End With

            If Not Filter = "" Then
                crStandarReport.SetParameterValue("@Letras", Filter)
            End If

            If TextOnly = True Then
                crStandarReport.ExportToDisk(ExportFormatType.ExcelRecord, FileName)
            Else
                crStandarReport.ExportToDisk(ExportFormatType.Excel, FileName)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Try
        End Try

        Cursor.Current = Cursors.Default
        frmStatusMessage.Close()
        crStandarReport.Close()

    End Sub

End Class
