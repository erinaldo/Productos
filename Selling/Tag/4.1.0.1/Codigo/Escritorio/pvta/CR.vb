Imports CrystalDecisions.CrystalReports

Imports CrystalDecisions.CrystalReports.Engine

Imports CrystalDecisions.ReportSource

Imports CrystalDecisions.Shared



Public Class CR
    Private Shared loginfo As CrystalDecisions.Shared.ConnectionInfo

    Public Shared exportar_mail As Boolean

    Public Shared rutaRpt As String

    Public Shared stillOpen As Boolean

    Public Shared custTitle As String

    Public BDServidor As String
    Public BDCatalogo As String
    Public BDUsuario As String
    Public BDContraseña As String



    Public Shared Sub conectar(ByVal servidor As String, ByVal basedatos As String, ByVal usuario As String, ByVal password As String)

        loginfo = New CrystalDecisions.Shared.ConnectionInfo

        loginfo.ServerName = servidor

        loginfo.DatabaseName = basedatos

        loginfo.UserID = usuario

        loginfo.Password = password

        
    End Sub



    Private Shared Function genpar(ByVal ParamArray matriz() As String) As ParameterFields

        Dim c As Long, p1, p2 As String, l As Integer

        Dim parametros As New ParameterFields

        For c = 0 To matriz.Length - 1

            l = InStr(matriz(c), ";")

            If l > 0 Then

                p1 = Mid(matriz(c), 1, l - 1)

                p2 = Mid(matriz(c), l + 1, Len(matriz(c)) - l)

                Dim parametro As New ParameterField

                Dim dVal As New ParameterDiscreteValue

                parametro.ParameterFieldName = p1

                dVal.Value = p2

                parametro.CurrentValues.Add(dVal)

                parametros.Add(parametro)

            End If

        Next

        Return (parametros)

    End Function


    Private Shared Sub logonrpt(ByRef reporte As ReportDocument, ByVal servidor As String, ByVal basedatos As String, ByVal usuario As String, ByVal password As String)

        Dim logOnInfo As New TableLogOnInfo()

        ' Establecer la información de conexión de la tabla actual.
        logOnInfo.ConnectionInfo.ServerName = servidor
        logOnInfo.ConnectionInfo.DatabaseName = basedatos
        logOnInfo.ConnectionInfo.UserID = usuario
        logOnInfo.ConnectionInfo.Password = password

        ' Realizar ciclos en todas las tablas del informe.
        For Each tbl As Table In reporte.Database.Tables
            tbl.ApplyLogOnInfo(logOnInfo)
        Next
    End Sub

    Private Shared Sub logonrpt(ByRef reporte As ReportDocument)

        Dim crtableLogoninfos As New TableLogOnInfos

        Dim crtableLogoninfo As New TableLogOnInfo

        Dim crConnectionInfo As New ConnectionInfo

        Dim CrTables As Tables

        Dim CrTable As Table

        crConnectionInfo = loginfo

        CrTables = reporte.Database.Tables

        For Each CrTable In CrTables

            crtableLogoninfo = CrTable.LogOnInfo

            crtableLogoninfo.ConnectionInfo = crConnectionInfo

            CrTable.ApplyLogOnInfo(crtableLogoninfo)

        Next



    End Sub


    Public Overloads Shared Sub printrptcnx(ByVal servidor As String, ByVal basedatos As String, ByVal usuario As String, ByVal password As String, ByVal nombrereporte As String, ByVal ParamArray par() As String)

        Dim forma As New FrmPrint

        Dim rpt As New ReportDocument


        'Configurar aquí cualquier opción de exportación 


        With forma.CrystalReportViewer1

            If par.Length > 0 Then

                .ParameterFieldInfo = genpar(par)

            End If

            If rutaRpt.Trim.Length = 0 Then

                Dim DirActual As System.IO.DirectoryInfo = New System.IO.DirectoryInfo(Application.ExecutablePath).Parent

                Dim dir As String = DirActual.FullName()

                rpt.Load(dir & "\Reportes\" & nombrereporte)

            ElseIf Mid(rutaRpt.Trim, rutaRpt.Trim.Length, 1) = "\" Then

                rpt.Load(rutaRpt & nombrereporte)

            Else

                rpt.Load(rutaRpt & "\" & nombrereporte)

            End If

            logonrpt(rpt, servidor, basedatos, usuario, password)

            Dim opt As New ExportOptions

            opt = rpt.ExportOptions

            'Configurar aquí cualquier opción de impresión 

            Dim prn As PrintOptions

            prn = rpt.PrintOptions

            .ReportSource = rpt

            'Visualizar el reporte en una ventana nueva 

            forma.Text = custTitle
            forma.CrystalReportViewer1.ShowCloseButton = False
            forma.CrystalReportViewer1.ShowGroupTreeButton = False
            forma.CrystalReportViewer1.ShowRefreshButton = False
            forma.CrystalReportViewer1.DisplayGroupTree = False

            forma.Location = New System.Drawing.Point(0, 0)
            forma.StartPosition = FormStartPosition.Manual

            forma.BringToFront()
            forma.Show()

        End With

    End Sub



    Public Overloads Shared Sub printrpt(ByVal nombrereporte As String, ByVal ParamArray par() As String)

        Dim forma As New frmprint

        Dim rpt As New ReportDocument

        With forma.CrystalReportViewer1

            If par.Length > 0 Then

                .ParameterFieldInfo = genpar(par)

            End If

            If rutarpt.Trim.Length = 0 Then

                Dim DirActual As System.IO.DirectoryInfo = New System.IO.DirectoryInfo(Application.ExecutablePath).Parent

                Dim dir As String = DirActual.FullName()

                rpt.Load(dir & "\Reportes\" & nombrereporte)

            ElseIf Mid(rutarpt.Trim, rutarpt.Trim.Length, 1) = "\" Then

                rpt.Load(rutaRpt & nombrereporte)

            Else

                rpt.Load(rutaRpt & "\" & nombrereporte)

            End If

            logonrpt(rpt)

            'Configurar aquí cualquier opción de exportación 

            Dim opt As New ExportOptions

            opt = rpt.ExportOptions

            'Configurar aquí cualquier opción de impresión 

            Dim prn As PrintOptions

            prn = rpt.PrintOptions

            .ReportSource = rpt

            'Visualizar el reporte en una ventana nueva 

            forma.Text = custTitle
            forma.CrystalReportViewer1.ShowCloseButton = False
            forma.CrystalReportViewer1.ShowGroupTreeButton = False
            forma.CrystalReportViewer1.ShowRefreshButton = False
            forma.CrystalReportViewer1.DisplayGroupTree = False

            forma.Location = New System.Drawing.Point(0, 0)
            forma.StartPosition = FormStartPosition.Manual

            forma.BringToFront()
            forma.Show()

        End With

    End Sub



    'Public Overloads Shared Sub printrpt(ByVal nombrereporte As String)

    '    Dim forma As New frmprint

    '    Dim rpt As New ReportDocument

    '    With forma.CrystalReportViewer1

    '        If rutarpt.Trim.Length = 0 Then

    '            rpt.Load(nombrereporte, OpenReportMethod.OpenReportByDefault)

    '        ElseIf Mid(rutarpt.Trim, rutarpt.Trim.Length, 1) = "\" Then

    '            rpt.Load(rutarpt & nombrereporte, OpenReportMethod.OpenReportByDefault)

    '        Else

    '            rpt.Load(rutarpt & "\" & nombrereporte, OpenReportMethod.OpenReportByDefault)

    '        End If

    '        logonrpt(rpt)

    '        'Configurar aquí cualquier opción de exportación 

    '        Dim opt As New ExportOptions

    '        opt = rpt.ExportOptions

    '        'Configurar aquí cualquier opción de impresión

    '        Dim prn As PrintOptions

    '        prn = rpt.PrintOptions

    '        .ReportSource = rpt

    '        forma.Location = New System.Drawing.Point(0, 0)
    '        forma.StartPosition = FormStartPosition.Manual

    '        forma.BringToFront()
    '        forma.Show()

    '    End With

    'End Sub

End Class
