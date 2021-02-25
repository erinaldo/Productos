Imports System.IO
Imports System.Xml
Imports System.Xml.Schema
Imports System.Text
Imports System
Imports System.Security.Cryptography

Imports System.Collections.Generic
Imports System.Text.RegularExpressions

Public Class FrmRegeneraCFD
    Inherits System.Windows.Forms.Form

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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents ChkMarcaTodos As System.Windows.Forms.CheckBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents UiButton1 As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtDireccion As System.Windows.Forms.TextBox
    Friend WithEvents LblClave As System.Windows.Forms.Label
    Friend WithEvents GridComprobantes As Janus.Windows.GridEX.GridEX
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRegeneraCFD))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GridComprobantes = New Janus.Windows.GridEX.GridEX
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.UiButton1 = New Janus.Windows.EditControls.UIButton
        Me.TxtDireccion = New System.Windows.Forms.TextBox
        Me.LblClave = New System.Windows.Forms.Label
        Me.ChkMarcaTodos = New System.Windows.Forms.CheckBox
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.GroupBox1.SuspendLayout()
        CType(Me.GridComprobantes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.GridComprobantes)
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Controls.Add(Me.PictureBox2)
        Me.GroupBox1.Controls.Add(Me.UiButton1)
        Me.GroupBox1.Controls.Add(Me.TxtDireccion)
        Me.GroupBox1.Controls.Add(Me.LblClave)
        Me.GroupBox1.Controls.Add(Me.ChkMarcaTodos)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(675, 302)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Selección de Comprobantes"
        '
        'GridComprobantes
        '
        Me.GridComprobantes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridComprobantes.ColumnAutoResize = True
        Me.GridComprobantes.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridComprobantes.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridComprobantes.GroupByBoxVisible = False
        Me.GridComprobantes.Location = New System.Drawing.Point(7, 32)
        Me.GridComprobantes.Name = "GridComprobantes"
        Me.GridComprobantes.RecordNavigator = True
        Me.GridComprobantes.Size = New System.Drawing.Size(663, 229)
        Me.GridComprobantes.TabIndex = 50
        Me.GridComprobantes.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(197, 15)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox1.TabIndex = 49
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(611, 278)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox2.TabIndex = 48
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'UiButton1
        '
        Me.UiButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UiButton1.Image = CType(resources.GetObject("UiButton1.Image"), System.Drawing.Image)
        Me.UiButton1.ImageSize = New System.Drawing.Size(20, 20)
        Me.UiButton1.Location = New System.Drawing.Point(637, 267)
        Me.UiButton1.Name = "UiButton1"
        Me.UiButton1.Size = New System.Drawing.Size(33, 29)
        Me.UiButton1.TabIndex = 47
        '
        'TxtDireccion
        '
        Me.TxtDireccion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtDireccion.Location = New System.Drawing.Point(197, 275)
        Me.TxtDireccion.Name = "TxtDireccion"
        Me.TxtDireccion.ReadOnly = True
        Me.TxtDireccion.Size = New System.Drawing.Size(427, 20)
        Me.TxtDireccion.TabIndex = 45
        Me.TxtDireccion.TabStop = False
        '
        'LblClave
        '
        Me.LblClave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblClave.Location = New System.Drawing.Point(126, 278)
        Me.LblClave.Name = "LblClave"
        Me.LblClave.Size = New System.Drawing.Size(80, 15)
        Me.LblClave.TabIndex = 46
        Me.LblClave.Text = "Guardar en "
        '
        'ChkMarcaTodos
        '
        Me.ChkMarcaTodos.Enabled = False
        Me.ChkMarcaTodos.Location = New System.Drawing.Point(8, 12)
        Me.ChkMarcaTodos.Name = "ChkMarcaTodos"
        Me.ChkMarcaTodos.Size = New System.Drawing.Size(109, 22)
        Me.ChkMarcaTodos.TabIndex = 6
        Me.ChkMarcaTodos.Text = "Marcar Todos"
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.Location = New System.Drawing.Point(592, 315)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 26
        Me.BtnGuardar.Text = "&Aceptar"
        Me.BtnGuardar.ToolTipText = "Guardar cambios"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(496, 315)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 27
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmRegeneraCFD
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(688, 358)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(580, 364)
        Me.Name = "FrmRegeneraCFD"
        Me.Text = "Regenerar Comprobantes Fiscales Digitales"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.GridComprobantes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public SUCClave As String
    Public Inicio As Date
    Public Fin As Date

    Private alerta(1) As PictureBox
    Private reloj As parpadea
    Private dtComprobantes As DataTable

    'Comprobante
    Private Version As String
    Private Serie As String
    Private Folio As String
    Private noCertificado As String
    Private Certificado64 As String
    Private RegimenFiscal As String

    Private LlaveFile As String
    'Private ContrasenaClave As String
    Private noAprobacion As String
    Private anoAprobacion As String
    Private tipoDeComprobante As String
    Private formaDePago As String
    Private metodoPago As String

    Private subtotal As String
    Private descuento As Double
    Private impuestos As Double
    Private total As String

    Private dtConcepto, dtImpuesto As DataTable

    'Emisor

    'Private eRFC As String
    Private eRazonSocial As String

    Private ePais As String
    Private eEntidad As String
    Private eMnpio As String
    Private eCalle As String
    Private eColonia As String
    Private eLocalidad As String
    Private eReferencia As String
    Private enoExterior As String
    Private enoInterior As String
    Private eCodigoPostal As String
    Private benoInterior As Boolean

    'Sucursal
    Private sPais As String
    Private sEntidad As String
    Private sMnpio As String


    Private sCalle As String
    Private sColonia As String
    Private sLocalidad As String
    Private sReferencia As String
    Private snoExterior As String
    Private snoInterior As String
    Private sCodigoPostal As String
    Private iTipoSucursal As Integer
    Private bsnoInterior As Boolean
    Private LugarExpedicion As String


    'Receptor
    Private CTEClave As String
    Private CURP As String
    Private Clave As String
    Private TImpuesto As Integer
    Private NombreCorto As String
    Private RazonSocial As String
    Private TPersona As Integer
    Private RFC As String
    Private LCredito As Double
    Private DiasCredito As Integer
    Private Contacto As String
    Private Tel1 As String
    Private Tel2 As String
    Private email As String
    Private listaPrecio As String
    Private Desglosaiva As Boolean = False
    Private Estado As Integer
    Private FechaReg As Date
    Private DCTEClave As String

    Private Pais As String
    Private Entidad As String
    Private Mnpio As String
    Private Calle As String
    Private Colonia As String
    Private Localidad As String
    Private Referencia As String
    Private noExterior As String
    Private noInterior As String
    Private codigoPostal As String
    Private brnoInterior As Boolean


    Private Sub FrmRegeneraCFD_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2

        dtComprobantes = ModPOS.Recupera_Tabla("sp_comprobantes", "@SUCClave", SUCClave, "@Inicial", Inicio, "@Final", Fin)
        If dtComprobantes.Rows.Count > 0 Then
            GridComprobantes.DataSource = dtComprobantes
            GridComprobantes.RetrieveStructure(True)
            GridComprobantes.RootTable.Columns("Periodo").Visible = False
            GridComprobantes.RootTable.Columns("Tipo").Visible = False
            GridComprobantes.RootTable.Columns("Cliente").Visible = False
            GridComprobantes.RootTable.Columns("Clave").Visible = False
            GridComprobantes.RootTable.Columns("tipoDeComprobante").Visible = False
            GridComprobantes.RootTable.Columns("formaDePago").Visible = False
            GridComprobantes.RootTable.Columns("Version").Visible = False
            GridComprobantes.RootTable.Columns("RegimenFiscal").Visible = False
            GridComprobantes.RootTable.Columns("Descuento").Visible = False
            GridComprobantes.RootTable.Columns("Moneda").Visible = False
            GridComprobantes.RootTable.Columns("TipoCambio").Visible = False
            GridComprobantes.RootTable.Columns("TipoCF").Visible = False
            GridComprobantes.RootTable.Columns("Estado").Visible = False



            ChkMarcaTodos.Enabled = True
        End If
    End Sub

    Private Sub FrmRegeneraCFD_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        ModPOS.RegeneraCFD.Dispose()
        ModPOS.RegeneraCFD = Nothing

    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub


    Private Sub ChkMarcaTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkMarcaTodos.CheckedChanged
        If dtComprobantes.Rows.Count > 0 Then
            Dim i As Integer
            Cursor.Current = Cursors.WaitCursor
            If ChkMarcaTodos.Checked Then
                For i = 0 To dtComprobantes.Rows.Count - 1
                    dtComprobantes.Rows(i)("Marca") = True
                Next
            Else
                For i = 0 To dtComprobantes.Rows.Count - 1
                    dtComprobantes.Rows(i)("Marca") = False
                Next
            End If
            Cursor.Current = Cursors.Default
        End If
    End Sub

    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If TxtDireccion.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()

        End If


        If i > 0 Then
            Return False
        Else
            While i < Me.alerta.Length
                Me.alerta(i).Visible = False
                i += 1
            End While
            Return True
        End If

    End Function

  
    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If Me.dtComprobantes.Rows.Count = 0 Then

            MsgBox("No se encontró algun comprobante en el rango de fechas especificado", MsgBoxStyle.Information, "Información")
            Me.Close()

        ElseIf validaForm() Then



            Dim i As Integer

            Dim foundRows() As DataRow
            foundRows = dtComprobantes.Select("Marca=True")

            If foundRows.GetLength(0) > 0 Then

                Cursor.Current = Cursors.WaitCursor
                Select Case MessageBox.Show("Se re generaran todos los comprobantes marcados, esta de acuerdo?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    Case DialogResult.Yes

                        Dim frmStatusMessage As New frmStatus
                        frmStatusMessage.Show("Generando Comprobantes Fiscales Digitales...")

                        Dim dt As DataTable

                        Dim oCFD As New CFD

                        oCFD.TipoCF = foundRows(i)("TipoCF")

                        'Recupera información del Emisor

                        dt = ModPOS.Recupera_Tabla("sp_recupera_compania", "@COMClave", ModPOS.CompanyActual)

                        oCFD.eRazonSocial = dt.Rows(0)("Nombre")
                        oCFD.eRFC = dt.Rows(0)("id_Fiscal")
                        oCFD.ePais = dt.Rows(0)("Pais")
                        oCFD.eEntidad = dt.Rows(0)("Estado")
                        oCFD.eMnpio = dt.Rows(0)("Municipio")
                        oCFD.eColonia = dt.Rows(0)("Colonia")
                        oCFD.eCalle = dt.Rows(0)("Calle")
                        oCFD.eCodigoPostal = dt.Rows(0)("CodigoPostal")
                        oCFD.eReferencia = dt.Rows(0)("Referencia")
                        oCFD.eLocalidad = dt.Rows(0)("Localidad")
                        oCFD.enoExterior = dt.Rows(0)("noExterior")
                        oCFD.enoInterior = dt.Rows(0)("noInterior")

                        dt.Dispose()


                        If oCFD.eReferencia = "" Then
                            oCFD.eReferencia = "SIN REFERENCIA"
                        End If

                        If oCFD.enoInterior <> "" Then
                            oCFD.benoInterior = True
                        Else
                            oCFD.benoInterior = False
                        End If

                        'Recupera Información del Centro de Expedición


                        dt = ModPOS.Recupera_Tabla("sp_recupera_sucursal", "@SUCClave", SUCClave)

                        oCFD.iTipoSucursal = dt.Rows(0)("Tipo")
                        oCFD.sPais = dt.Rows(0)("Pais")
                        oCFD.sEntidad = dt.Rows(0)("Entidad")
                        oCFD.sMnpio = dt.Rows(0)("Municipio")
                        oCFD.sColonia = dt.Rows(0)("Colonia")
                        oCFD.sCalle = dt.Rows(0)("Calle")
                        oCFD.sCodigoPostal = dt.Rows(0)("CodigoPostal")
                        oCFD.sReferencia = dt.Rows(0)("Referencia")
                        oCFD.sLocalidad = dt.Rows(0)("Localidad")
                        oCFD.snoExterior = dt.Rows(0)("noExterior")
                        oCFD.snoInterior = dt.Rows(0)("noInterior")
                        dt.Dispose()

                        If oCFD.sReferencia = "" Then
                            oCFD.sReferencia = "SIN REFERENCIA"
                        End If

                        If oCFD.snoInterior <> "" Then
                            oCFD.bsnoInterior = True
                        Else
                            oCFD.bsnoInterior = False
                        End If

                        oCFD.LugarExpedicion = oCFD.sCalle & " " & oCFD.snoExterior & IIf(oCFD.bsnoInterior, " INT " & oCFD.snoInterior, "") & "," & oCFD.sMnpio & "," & oCFD.sEntidad


                        oCFD.noCertificado = ""
                        oCFD.Certificado64 = ""

                        Dim DirArchivoPEM As String = ""


                        Dim dtPAC As DataTable = Nothing
                        Dim foundRows2() As DataRow

                        Dim url As String = ""
                        Dim UserId As String = ""
                        Dim CustomerKey As String = ""

                        For i = 0 To foundRows.GetUpperBound(0)
                          
                            If foundRows(i)("TipoCF") = 2 AndAlso foundRows(i)("Estado") = 1 Then

                                'Recuperar Timbre



                                If dtPAC Is Nothing Then
                                    dtPAC = ModPOS.Recupera_Tabla("sp_recupera_PAC", "@COMClave", ModPOS.CompanyActual)
                                    foundRows2 = dtPAC.Select("TipoPAC = 2")
                                    If foundRows.GetLength(0) = 0 Then
                                        MessageBox.Show("El servicio de recuperación de CFDI solo esta disponible para el el PAC iTimbre", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        Exit Sub
                                    Else
                                        url = foundRows2(0)("ServerTimbre")
                                        UserId = foundRows2(0)("UserId")
                                        CustomerKey = foundRows2(0)("CustomerKey")
                                    End If
                                End If
                                Dim CBB() As Byte = Nothing

                                CBB = ModPOS.crearQR(oCFD.eRFC, foundRows(i)("RFC"), foundRows(i)("Total"), foundRows(i)("UUID"))

                                ModPOS.Ejecuta("sp_actualiza_cbb", "@Tipo", foundRows(i)("TipoDeComprobante"), "@DOCClave", foundRows(i)("Clave"), "@CBB", CBB, "@TipoComprobante", foundRows(i)("tipo"))

                                Dim consulta As String = BuscarCFDiTimbre(UserId, CustomerKey, oCFD.eRFC, foundRows(i)("Serie") & foundRows(i)("Folio"), foundRows(i)("UUID"))

                                Dim content2 As Byte() = System.Text.Encoding.UTF8.GetBytes(consulta)
                                Dim peticion2 As System.Net.HttpWebRequest = System.Net.WebRequest.Create(url)

                                peticion2.Method = "POST"
                                peticion2.ContentType = "application/x-www-form-urlencoded"
                                peticion2.ContentLength = content2.Length


                                Dim requestStream2 As System.IO.Stream = peticion2.GetRequestStream()

                                requestStream2.Write(content2, 0, content2.Length)
                                requestStream2.Close()

                                Dim resp2 As System.Net.HttpWebResponse = peticion2.GetResponse()
                                Dim respuesta2 As String = New System.IO.StreamReader(resp2.GetResponseStream).ReadToEnd

                                If respuesta2.Contains("error") = False Then
                                    Dim respJson2 As Object = Newtonsoft.Json.Linq.JObject.Parse(respuesta2)

                                    Dim jResult As Newtonsoft.Json.Linq.JArray = respJson2.Item("result").item("data")

                                    Dim Elementos As Xml.XmlDocument = New Xml.XmlDocument()

                                    Elementos.LoadXml(jResult.Item(0).Item("xml_data").ToString())


                                    Elementos.Save(TxtDireccion.Text & foundRows(i)("Serie") & foundRows(i)("Folio") & ".xml")
                                End If
                            Else
                                ' Generar CFD

                                If oCFD.noCertificado <> foundRows(i)("noCertificado") Then
                                    oCFD.noCertificado = foundRows(i)("noCertificado")

                                    'recuperar certificado64

                                    dt = ModPOS.Recupera_Tabla("sp_recupera_cert", "@Certificado", oCFD.noCertificado)
                                    If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                                        oCFD.LlaveFile = dt.Rows(0)("Llave")
                                        oCFD.ContrasenaClave = dt.Rows(0)("Password")
                                        oCFD.Certificado64 = dt.Rows(0)("Certificado")
                                        dt.Dispose()
                                    Else
                                        MessageBox.Show("No existen certificado vigente disponible para emitir algun documento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                        Exit Sub
                                    End If

                                    'Verifica que exista el path del .Key
                                    Try
                                        If Not System.IO.File.Exists(oCFD.LlaveFile) Then
                                            MessageBox.Show("El archivo " & oCFD.LlaveFile & " no existe o se puede tener acceso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                            Exit Sub
                                        End If
                                    Catch ex As Exception
                                    End Try


                                    'Verifica que exista el path
                                    Try
                                        If Not System.IO.Directory.Exists("C:\SelladoDigital\") Then
                                            System.IO.Directory.CreateDirectory("C:\SelladoDigital\")
                                        End If
                                    Catch ex As Exception
                                    End Try

                                    Dim DirSello As String = "C:\SelladoDigital\" & Path.GetFileName(oCFD.LlaveFile)

                                    If Not System.IO.File.Exists(DirSello) Then
                                        If System.IO.File.Exists(oCFD.LlaveFile) Then
                                            System.IO.File.Copy(oCFD.LlaveFile, DirSello)
                                        Else
                                            MessageBox.Show("El archivo " & oCFD.LlaveFile & " no existe o se cambio de lugar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                            Exit Sub
                                        End If
                                    End If

                                    Dim dir As String
                                    DirArchivoPEM = DirSello & ".pem"

                                    dir = "C:\OpenSSL\bin\openssl.exe"

                                    Shell(dir & " pkcs8 -inform DER -in " & DirSello & " -passin pass:" & oCFD.ContrasenaClave & " -out " & DirArchivoPEM, AppWinStyle.Hide, True)

                                End If

                                'Carga datos Receptor

                                dt = ModPOS.SiExisteRecupera("sp_recupera_cliente", "@CTEClave", foundRows(i)("Cliente"))

                                oCFD.CTEClave = dt.Rows(0)("CTEClave")
                                oCFD.CURP = dt.Rows(0)("CURP")
                                oCFD.Clave = dt.Rows(0)("Clave")
                                oCFD.TImpuesto = dt.Rows(0)("TImpuesto")
                                oCFD.NombreCorto = dt.Rows(0)("NombreCorto")
                                oCFD.RazonSocial = dt.Rows(0)("RazonSocial")
                                oCFD.TPersona = dt.Rows(0)("TPersona")
                                oCFD.RFC = dt.Rows(0)("id_Fiscal")
                                oCFD.LCredito = dt.Rows(0)("LimiteCredito")
                                oCFD.DiasCredito = dt.Rows(0)("DiasCredito")
                                oCFD.Contacto = dt.Rows(0)("Contacto")
                                oCFD.Tel1 = dt.Rows(0)("Tel1")
                                oCFD.Tel2 = dt.Rows(0)("Tel2")
                                oCFD.email = dt.Rows(0)("Email")
                                oCFD.listaPrecio = dt.Rows(0)("PREClave")
                                oCFD.NoDesglosaIEPS = dt.Rows(0)("DesglosaIVA")
                                'SUCClave = dt.Rows(0)("SUCClave")

                                oCFD.FechaReg = dt.Rows(0)("FechaRegistro")
                                oCFD.Estado = dt.Rows(0)("Estado")
                                oCFD.DCTEClave = dt.Rows(0)("DCTEClave")

                                oCFD.Pais = dt.Rows(0)("Pais")
                                oCFD.Entidad = dt.Rows(0)("Entidad")
                                oCFD.Mnpio = dt.Rows(0)("Municipio")
                                oCFD.Colonia = dt.Rows(0)("Colonia")
                                oCFD.Calle = dt.Rows(0)("Calle")
                                oCFD.Localidad = dt.Rows(0)("Localidad")
                                oCFD.Referencia = dt.Rows(0)("referencia")
                                oCFD.noExterior = dt.Rows(0)("noExterior")
                                oCFD.noInterior = dt.Rows(0)("noInterior")
                                oCFD.codigoPostal = dt.Rows(0)("codigoPostal")

                                oCFD.NoDesglosaIEPS = dt.Rows(0)("DesglosaIVA")

                                If oCFD.Referencia = "" Then
                                    oCFD.Referencia = "SIN REFERENCIA"
                                End If

                                If oCFD.noInterior <> "" Then
                                    oCFD.brnoInterior = True
                                Else
                                    oCFD.brnoInterior = False
                                End If

                                dt.Dispose()



                                'Fin receptor

                                oCFD.VersionCF = foundRows(i)("Version")
                                oCFD.regimenFiscal = foundRows(i)("RegimenFiscal")
                                oCFD.Serie = foundRows(i)("Serie")
                                oCFD.Folio = foundRows(i)("Folio")
                                oCFD.descuento = foundRows(i)("Descuento")
                                oCFD.anoAprobacion = foundRows(i)("anoAprobacion")
                                oCFD.noAprobacion = foundRows(i)("noAprobacion")
                                oCFD.tipoDeComprobante = foundRows(i)("tipoDeComprobante")
                                oCFD.formaDePago = foundRows(i)("formaDePago")

                                'oCFD.metodoDePago = foundRows(i)("metodoPago")

                                Dim dtMetodoPagos As DataTable
                                dtMetodoPagos = ModPOS.Recupera_Tabla("sp_obtener_metodopago", "@Tipo", foundRows(i)("Tipo"), "@TipoComprobante", foundRows(i)("TipoDeComprobante"), "@Clave", foundRows(i)("Clave"))

                                oCFD.metodoDePago = ""
                                oCFD.NumCtaPago = ""

                                If dtMetodoPagos.Rows.Count > 0 Then

                                    Dim j As Integer
                                    For j = 0 To dtMetodoPagos.Rows.Count - 1

                                        If j > 0 Then
                                            oCFD.metodoDePago &= ","

                                            If oCFD.NumCtaPago <> "" AndAlso dtMetodoPagos.Rows(j)("Referencia") <> "" Then
                                                oCFD.NumCtaPago &= ","
                                            End If
                                        End If

                                        oCFD.metodoDePago &= CStr(dtMetodoPagos.Rows(j)("MetodoPago"))

                                        If dtMetodoPagos.Rows(j)("Banco") <> "" Then
                                            oCFD.metodoDePago &= " " & CStr(dtMetodoPagos.Rows(j)("Banco"))
                                        End If

                                        oCFD.NumCtaPago &= CStr(dtMetodoPagos.Rows(j)("Referencia"))
                                    Next

                                End If
                                '99
                                oCFD.Fecha = String.Format("{0:yyyy-MM-ddTHH:mm:ss}", foundRows(i)("Fecha"))
                                oCFD.Moneda = foundRows(i)("Moneda")
                                oCFD.TipoCambio = foundRows(i)("TipoCambio")
                                'Me.CargaDatosCliente(foundRows(i)("Cliente"))
                                dtConcepto = ModPOS.Recupera_Tabla("sp_recupera_elemento", "@TipoComprobante", oCFD.tipoDeComprobante, "@Tipo", foundRows(i)("Tipo"), "@Clave", foundRows(i)("Clave"))
                                dtImpuesto = ModPOS.Recupera_Tabla("sp_recupera_imp_elemento", "@TipoComprobante", oCFD.tipoDeComprobante, "@Tipo", foundRows(i)("Tipo"), "@Clave", foundRows(i)("Clave"))

                                oCFD.DOCClave = foundRows(i)("Clave")


                                Dim iTipoComprobante As Integer
                                Select Case CInt(foundRows(i)("Tipo"))
                                    Case Is = 0
                                        iTipoComprobante = 1
                                    Case Is = (1 OrElse 2)
                                        iTipoComprobante = 7
                                    Case Is = 6
                                        iTipoComprobante = 6
                                End Select


                                If oCFD.TipoCF = 1 Then
                                    oCFD.cadenaOriginal = generarCadenaOriginal(oCFD, dtConcepto, dtImpuesto)
                                Else
                                    oCFD.cadenaOriginal = generarCadenaOriginalCFDI(oCFD, dtConcepto, dtImpuesto, iTipoComprobante)
                                End If

                                oCFD.sello = ModPOS.generarSelloDigital(oCFD.cadenaOriginal, oCFD.Serie, oCFD.Folio, oCFD.LlaveFile, oCFD.ContrasenaClave)

                                If oCFD.sello Is Nothing OrElse oCFD.sello = "" Then
                                    frmStatusMessage.Close()

                                    Exit Sub
                                End If



                                ModPOS.crearXML(3, dtPAC, TxtDireccion.Text, oCFD.Serie & oCFD.Folio, oCFD.DOCClave, oCFD.tipoDeComprobante, oCFD, dtConcepto, dtImpuesto, iTipoComprobante)


                                ' Dim cadenaOriginal As String = generarCadenaOriginal(Fecha)
                                'Dim selloDigital As String = generarSelloDigital(foundRows(i)("Periodo"), cadenaOriginal, DirArchivoPEM)
                                'crearXML(Fecha, selloDigital)
                                

                                ModPOS.Ejecuta("sp_actualiza_sello", "@TipoComprobante", foundRows(i)("tipo"), "@Tipo", foundRows(i)("tipoDeComprobante"), "@Clave", foundRows(i)("Clave"), "@cadenaOriginal", oCFD.cadenaOriginal, "@Sello", oCFD.sello, "@Certificado", oCFD.Certificado64)

                                dtConcepto.Dispose()
                                dtImpuesto.Dispose()
                            End If
                        Next
                        frmStatusMessage.Dispose()
                End Select
                Cursor.Current = Cursors.Default

            Else
                MessageBox.Show("¡Debe marcar por lo menos un registro!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If
            MessageBox.Show("Se regeneraron todos los comprobantes correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub UiButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UiButton1.Click
        Dim a As New System.Windows.Forms.FolderBrowserDialog
        If (a.ShowDialog() = DialogResult.OK) Then
            If a.SelectedPath.Length <= 3 Then
                TxtDireccion.Text = a.SelectedPath
            Else
                TxtDireccion.Text = a.SelectedPath & "\"
            End If
        End If
    End Sub

End Class
