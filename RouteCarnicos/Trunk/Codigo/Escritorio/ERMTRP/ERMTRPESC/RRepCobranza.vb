Imports BASMENLOG

Public Class RRepCobranza
    Inherits FormasBase.FrmBase

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()

    End Sub

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms requiere el siguiente procedimiento
    'Puede modificarse utilizando el Diseñador de Windows Forms. 
    'No lo modifique con el editor de código.
    Friend WithEvents rvwReporte As CrystalDecisions.Windows.Forms.CrystalReportViewer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.rvwReporte = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.SuspendLayout()
        '
        'rvwReporte
        '
        Me.rvwReporte.ActiveViewIndex = -1
        Me.rvwReporte.DisplayGroupTree = False
        Me.rvwReporte.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rvwReporte.Location = New System.Drawing.Point(0, 0)
        Me.rvwReporte.Name = "rvwReporte"
        Me.rvwReporte.ReportSource = Nothing
        Me.rvwReporte.ShowCloseButton = False
        Me.rvwReporte.ShowExportButton = False
        Me.rvwReporte.ShowGroupTreeButton = False
        Me.rvwReporte.ShowRefreshButton = False
        Me.rvwReporte.Size = New System.Drawing.Size(754, 564)
        Me.rvwReporte.TabIndex = 1
        '
        'RRepVentas
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(754, 564)
        Me.Controls.Add(Me.rvwReporte)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "RRepVentas"
        Me.ShowInTaskbar = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RRepVentas"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private oMensaje As CMensaje
    Private sProyecto As String = "ERMReportes"
    Private sServidor As String
    Private sBaseDatos As String
    Private sUsuario As String
    Private sPassword As String

    Public Sub CONSULTAR(ByVal pvClienteClave As String)
        oMensaje = New CMensaje
        ObtenerParametrosConexion(sServidor, sBaseDatos, sUsuario, sPassword)
        MostrarReporte(pvClienteClave)
        Me.Text = oMensaje.RecuperarDescripcion(sProyecto & "_RRepCobranza")
        Me.ShowDialog()
    End Sub

    Private Sub MostrarReporte(ByVal pvClienteClave As String)
        Dim oReporte As CrystalDecisions.CrystalReports.Engine.ReportClass
        Dim oImpuesto As New ERMIMPLOG.CImpuesto

        oReporte = New rptResumenCobranza
        oReporte.SetParameterValue("@pvLenguaje", lbGeneral.cParametros.Lenguaje)
        oReporte.SetParameterValue("@pvClienteClave", pvClienteClave)
        oReporte.SetParameterValue("pvTitulo", oMensaje.RecuperarDescripcion("XREPORTECOBRANZA"))
        oReporte.SetParameterValue("pvFechaHora", oMensaje.RecuperarDescripcion("XFechaHora"))
        oReporte.SetParameterValue("pvCliente", oMensaje.RecuperarDescripcion("XCliente"))
        oReporte.SetParameterValue("pvFolio", oMensaje.RecuperarDescripcion("TRPFolio"))
        oReporte.SetParameterValue("pvSubTotal", oMensaje.RecuperarDescripcion("TRPSubTotal"))
        oImpuesto.Recuperar("IP")
        oReporte.SetParameterValue("pvIP", oImpuesto.Abreviatura)
        oImpuesto.Recuperar("IGV")
        oReporte.SetParameterValue("pvIGV", oImpuesto.Abreviatura)
        oReporte.SetParameterValue("pvTotal", oMensaje.RecuperarDescripcion("TRPTotal"))
        oReporte.SetParameterValue("pvSaldo", oMensaje.RecuperarDescripcion("TRPSaldo"))

        Dim oLogOnInfo As New CrystalDecisions.Shared.TableLogOnInfo
        Dim connectionInfo As New CrystalDecisions.Shared.ConnectionInfo
        connectionInfo.DatabaseName = sBaseDatos
        connectionInfo.ServerName = sServidor
        connectionInfo.UserID = sUsuario
        connectionInfo.Password = sPassword

        For Each oTabla As CrystalDecisions.CrystalReports.Engine.Table In oReporte.Database.Tables
            oLogOnInfo = oTabla.LogOnInfo
            oLogOnInfo.ConnectionInfo = connectionInfo
            oTabla.ApplyLogOnInfo(oLogOnInfo)
        Next

        For Each oTabla As CrystalDecisions.CrystalReports.Engine.Table In oReporte.Database.Tables
            oTabla.Location = sBaseDatos & ".dbo." & oTabla.Name
        Next

        rvwReporte.ReportSource = oReporte
    End Sub

End Class
