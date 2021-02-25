Imports System.Data
Imports System.Xml
Imports System.IO

Public Class FormProceso
    Inherits System.Windows.Forms.Form
    Friend WithEvents btAceptar As System.Windows.Forms.Button
    Friend WithEvents LabelProceso As System.Windows.Forms.Label

    Public Const PubcArchivoConfig = "MobileClientConfig.xml"

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()

    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub

    'NOTA: el Diseñador de Windows Forms requiere el siguiente procedimiento
    'Puede modificarse utilizando el Diseñador de Windows Forms. 
    'No lo modifique con el editor de código.
    Friend WithEvents LabelTitulo As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents StatusBarEstado As System.Windows.Forms.StatusBar

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.LabelProceso = New System.Windows.Forms.Label
        Me.LabelTitulo = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.btAceptar = New System.Windows.Forms.Button
        Me.StatusBarEstado = New System.Windows.Forms.StatusBar
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'LabelProceso
        '
        Me.LabelProceso.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelProceso.ForeColor = System.Drawing.Color.White
        Me.LabelProceso.Location = New System.Drawing.Point(20, 36)
        Me.LabelProceso.Name = "LabelProceso"
        Me.LabelProceso.Size = New System.Drawing.Size(196, 32)
        Me.LabelProceso.Text = "Actualización Exitosa"
        Me.LabelProceso.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LabelTitulo
        '
        Me.LabelTitulo.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LabelTitulo.ForeColor = System.Drawing.Color.White
        Me.LabelTitulo.Location = New System.Drawing.Point(4, 4)
        Me.LabelTitulo.Name = "LabelTitulo"
        Me.LabelTitulo.Size = New System.Drawing.Size(224, 16)
        Me.LabelTitulo.Text = "ROUTE Updater 1.0.0"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkBlue
        Me.Panel1.Controls.Add(Me.LabelTitulo)
        Me.Panel1.Location = New System.Drawing.Point(4, 72)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(232, 24)
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DarkCyan
        Me.Panel2.Controls.Add(Me.btAceptar)
        Me.Panel2.Controls.Add(Me.StatusBarEstado)
        Me.Panel2.Controls.Add(Me.LabelProceso)
        Me.Panel2.Location = New System.Drawing.Point(4, 96)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(232, 128)
        '
        'btAceptar
        '
        Me.btAceptar.Location = New System.Drawing.Point(66, 71)
        Me.btAceptar.Name = "btAceptar"
        Me.btAceptar.Size = New System.Drawing.Size(92, 22)
        Me.btAceptar.TabIndex = 3
        Me.btAceptar.Text = "Aceptar"
        '
        'StatusBarEstado
        '
        Me.StatusBarEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.StatusBarEstado.Location = New System.Drawing.Point(0, 108)
        Me.StatusBarEstado.Name = "StatusBarEstado"
        Me.StatusBarEstado.Size = New System.Drawing.Size(232, 20)
        '
        'FormProceso
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(244, 328)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormProceso"
        Me.Text = "Amesol Route"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub FormProceso_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        EjecutarApp("\AmesolRoute.CAB")
    End Sub

    Private Sub FormProceso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ProgressBarAvance.Value = 0
        'LabelProceso.Text = ""

        Me.btAceptar.Visible = False
        System.Threading.Thread.Sleep(400)
        Me.btAceptar.Visible = True
    End Sub

    Private Sub btAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAceptar.Click
        'Borrar las BD de la aplicacion
        Try

            Dim sFiles As String() = IO.Directory.GetFiles(LeerRutaTrabajoXML())

            For Each sFile As String In sFiles
                File.Delete(sFile)
            Next


        Catch ex As Exception
            MsgBox("Error al Borrar las BD, favor de borrarlas manualmente", MsgBoxStyle.Critical)
            Me.Close()
        End Try

        Dim AppPath As String = IO.Path.GetDirectoryName(Reflection.Assembly.GetExecutingAssembly.GetName.CodeBase)
        EjecutarApp(String.Format("{0}\MobileClient.exe", AppPath))
        Me.Close()
        Application.Exit()
    End Sub

    Public Function LeerRutaTrabajoXML() As String
        Try

            ' Usar un DataSet para leer el contenido del archivo XML
            Dim DataSetConfig As New DataSet("Config")
            Dim refDataTableConfig As DataTable
            Dim refDataRowActual As DataRow
            ' Leer el archivo XML con el esquema
            DataSetConfig.ReadXml(PubcArchivoConfig)
            refDataTableConfig = DataSetConfig.Tables("General")
            refDataRowActual = refDataTableConfig.Rows(0)
            ' Recuperar los valores del archivo XML
            Return refDataRowActual("RutaTrabajo")
          
            Return True
        Catch ExcA As XmlException
            MsgBox(ExcA.Message, MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "Leer")
        Catch ExcB As Exception
            MsgBox(ExcB.Message, MsgBoxStyle.Critical Or MsgBoxStyle.SystemModal, "Leer")
        End Try
        Return False
    End Function
End Class
