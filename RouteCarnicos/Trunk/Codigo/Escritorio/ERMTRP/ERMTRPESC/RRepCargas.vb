Imports BASMENLOG
Public Class RRepCargas
    Inherits FormasBase.FrmBase

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
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
        Me.rvwReporte.ShowGroupTreeButton = False
        Me.rvwReporte.ShowRefreshButton = False
        Me.rvwReporte.Size = New System.Drawing.Size(756, 566)
        Me.rvwReporte.TabIndex = 1
        '
        'RRepCargas
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(756, 566)
        Me.Controls.Add(Me.rvwReporte)
        Me.Name = "RRepCargas"
        Me.Text = "RRepCargas"
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private oMensaje As CMensaje
    Private sProyecto As String = "ERMReportes"
    Dim sServidor As String
    Dim sBaseDatos As String
    Dim sUsuario As String
    Dim sPassword As String

    Public Sub CONSULTAR(ByVal parsFecha As String, ByVal parsCargaID As String, ByVal parsFiltros As String)
        oMensaje = New CMensaje
        MostrarReporte(parsFecha, parsCargaID, parsFiltros)
        Me.Text = oMensaje.RecuperarDescripcion(sProyecto & "_RRepCargas")
        Me.ShowDialog()
    End Sub

    Private Sub MostrarReporte(ByVal parsFecha As String, ByVal parsCargaID As String, ByVal parsFiltros As String)
        Dim oReporte As CrystalDecisions.CrystalReports.Engine.ReportClass

        oReporte = New rptCargas
        Dim dt As DataTable = LbConexion.cConexion.Instancia.EjecutarConsulta("Select nombreempresa,logotipo from configuracion ")
        oReporte.Database.Tables("Configuracion").SetDataSource(dt)

        parsFiltros = parsFiltros.Replace("'", "''")

        Dim sp As String = "exec SPRepCargas '" & parsFecha & "','" & parsCargaID & "','" & parsFiltros & "'"
        LbConexion.cConexion.Instancia()
        Dim cmd As New OleDb.OleDbCommand
        cmd.Connection = LbConexion.cConexion.Instancia.Conexion
        cmd.Transaction = LbConexion.cConexion.Instancia.ObtenerTran()
        cmd.CommandText = sp
        Dim ad As New Data.OleDb.OleDbDataAdapter(cmd)
        Dim ds As New Data.DataSet
        ad.Fill(ds)
        dt = ds.Tables(0) 

        oReporte.Database.Tables("Productos").SetDataSource(dt)

        oReporte.SetParameterValue("pvTitulo", oMensaje.RecuperarDescripcion("XREPORTECargas"))
        oReporte.SetParameterValue("pvMsgFechaHora", oMensaje.RecuperarDescripcion("XFechaHora"))
        'oReporte.SetParameterValue("pvMsgVendedor", oMensaje.RecuperarDescripcion("XVendedor"))
        'oReporte.SetParameterValue("pvMsgFase", oMensaje.RecuperarDescripcion("TRPTipoFase"))
        oReporte.SetParameterValue("pvFolioCarga", oMensaje.RecuperarDescripcion("TRPFolio"))
        oReporte.SetParameterValue("pvClave", oMensaje.RecuperarDescripcion("PROProductoClave"))
        oReporte.SetParameterValue("pvProducto", oMensaje.RecuperarDescripcion("TPDProductoClave"))
        oReporte.SetParameterValue("pvUnidad", oMensaje.RecuperarDescripcion("XCharolas"))
        oReporte.SetParameterValue("pvCantidad", oMensaje.RecuperarDescripcion("XCant"))
        oReporte.SetParameterValue("pvFactor", oMensaje.RecuperarDescripcion("XPiezasCharola"))
        oReporte.SetParameterValue("pvMas", oMensaje.RecuperarDescripcion("XMas"))
        oReporte.SetParameterValue("pvMenos", oMensaje.RecuperarDescripcion("XMenos"))
        oReporte.SetParameterValue("pvTotal", oMensaje.RecuperarDescripcion("XTotalMin"))
        oReporte.SetParameterValue("pvTotalPiezas", oMensaje.RecuperarDescripcion("XTotalPiezas"))
        oReporte.SetParameterValue("pvRecibio", oMensaje.RecuperarDescripcion("XRecibio"))
        oReporte.SetParameterValue("pvSurtio", oMensaje.RecuperarDescripcion("XSurtio"))

        'Dim oLogOnInfo As New CrystalDecisions.Shared.TableLogOnInfo
        'Dim connectionInfo As New CrystalDecisions.Shared.ConnectionInfo

        Application.DoEvents()
        rvwReporte.ReportSource = oReporte
    End Sub

End Class
