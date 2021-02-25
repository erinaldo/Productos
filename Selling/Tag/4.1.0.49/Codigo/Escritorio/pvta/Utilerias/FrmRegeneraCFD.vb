Imports System.IO
Imports System.Xml
Imports System.Xml.Schema
Imports System.Text
Imports System
Imports System.Security.Cryptography
Imports System.Net
Imports System.Net.Mail

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
    Friend WithEvents BtnRegenera As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnQR As Janus.Windows.EditControls.UIButton
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRegeneraCFD))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.BtnRegenera = New Janus.Windows.EditControls.UIButton()
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton()
        Me.GridComprobantes = New Janus.Windows.GridEX.GridEX()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.UiButton1 = New Janus.Windows.EditControls.UIButton()
        Me.TxtDireccion = New System.Windows.Forms.TextBox()
        Me.LblClave = New System.Windows.Forms.Label()
        Me.ChkMarcaTodos = New System.Windows.Forms.CheckBox()
        Me.btnQR = New Janus.Windows.EditControls.UIButton()
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
        Me.GroupBox1.Controls.Add(Me.btnQR)
        Me.GroupBox1.Controls.Add(Me.BtnCancelar)
        Me.GroupBox1.Controls.Add(Me.BtnRegenera)
        Me.GroupBox1.Controls.Add(Me.BtnGuardar)
        Me.GroupBox1.Controls.Add(Me.GridComprobantes)
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Controls.Add(Me.PictureBox2)
        Me.GroupBox1.Controls.Add(Me.UiButton1)
        Me.GroupBox1.Controls.Add(Me.TxtDireccion)
        Me.GroupBox1.Controls.Add(Me.LblClave)
        Me.GroupBox1.Controls.Add(Me.ChkMarcaTodos)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(675, 445)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Selección de Comprobantes"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(536, 402)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(134, 37)
        Me.BtnCancelar.TabIndex = 27
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnRegenera
        '
        Me.BtnRegenera.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnRegenera.Icon = CType(resources.GetObject("BtnRegenera.Icon"), System.Drawing.Icon)
        Me.BtnRegenera.Location = New System.Drawing.Point(8, 402)
        Me.BtnRegenera.Name = "BtnRegenera"
        Me.BtnRegenera.Size = New System.Drawing.Size(134, 37)
        Me.BtnRegenera.TabIndex = 52
        Me.BtnRegenera.Text = "Cancela y &Regenera"
        Me.BtnRegenera.ToolTipText = "Cancelación y Regeneración de Comprobantes"
        Me.BtnRegenera.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.Location = New System.Drawing.Point(148, 402)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(134, 37)
        Me.BtnGuardar.TabIndex = 26
        Me.BtnGuardar.Text = "&Solo Regenera"
        Me.BtnGuardar.ToolTipText = "Guardar cambios"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GridComprobantes
        '
        Me.GridComprobantes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridComprobantes.ColumnAutoResize = True
        Me.GridComprobantes.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridComprobantes.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridComprobantes.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridComprobantes.GroupByBoxVisible = False
        Me.GridComprobantes.Location = New System.Drawing.Point(7, 45)
        Me.GridComprobantes.Name = "GridComprobantes"
        Me.GridComprobantes.RecordNavigator = True
        Me.GridComprobantes.Size = New System.Drawing.Size(663, 343)
        Me.GridComprobantes.TabIndex = 50
        Me.GridComprobantes.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(95, 20)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(22, 19)
        Me.PictureBox1.TabIndex = 49
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(612, 22)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(19, 17)
        Me.PictureBox2.TabIndex = 48
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'UiButton1
        '
        Me.UiButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UiButton1.Image = CType(resources.GetObject("UiButton1.Image"), System.Drawing.Image)
        Me.UiButton1.ImageSize = New System.Drawing.Size(20, 20)
        Me.UiButton1.Location = New System.Drawing.Point(637, 11)
        Me.UiButton1.Name = "UiButton1"
        Me.UiButton1.Size = New System.Drawing.Size(33, 29)
        Me.UiButton1.TabIndex = 47
        '
        'TxtDireccion
        '
        Me.TxtDireccion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtDireccion.Location = New System.Drawing.Point(199, 19)
        Me.TxtDireccion.Name = "TxtDireccion"
        Me.TxtDireccion.ReadOnly = True
        Me.TxtDireccion.Size = New System.Drawing.Size(408, 20)
        Me.TxtDireccion.TabIndex = 45
        Me.TxtDireccion.TabStop = False
        '
        'LblClave
        '
        Me.LblClave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblClave.Location = New System.Drawing.Point(129, 22)
        Me.LblClave.Name = "LblClave"
        Me.LblClave.Size = New System.Drawing.Size(80, 15)
        Me.LblClave.TabIndex = 46
        Me.LblClave.Text = "Guardar en "
        '
        'ChkMarcaTodos
        '
        Me.ChkMarcaTodos.Enabled = False
        Me.ChkMarcaTodos.Location = New System.Drawing.Point(8, 18)
        Me.ChkMarcaTodos.Name = "ChkMarcaTodos"
        Me.ChkMarcaTodos.Size = New System.Drawing.Size(109, 22)
        Me.ChkMarcaTodos.TabIndex = 6
        Me.ChkMarcaTodos.Text = "Marcar Todos"
        '
        'btnQR
        '
        Me.btnQR.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnQR.Icon = CType(resources.GetObject("btnQR.Icon"), System.Drawing.Icon)
        Me.btnQR.Location = New System.Drawing.Point(288, 402)
        Me.btnQR.Name = "btnQR"
        Me.btnQR.Size = New System.Drawing.Size(134, 37)
        Me.btnQR.TabIndex = 53
        Me.btnQR.Text = "&Regenera QR"
        Me.btnQR.ToolTipText = "Guardar cambios"
        Me.btnQR.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmRegeneraCFD
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(688, 458)
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

    Private dtConcepto, dtImpuesto, dtDetalleImpuesto, dtRetencionDet, dtRetencion As DataTable

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
    Private MailSSL As Boolean
    Private MailPort As Integer
    Private PathXML, MailAdress, DisplayName, MailUser, MailPassword, HostSMTP As String
    Private correo As MailMessage
    Private adjuntos As Attachment
    Private autenticar As NetworkCredential
    Private envio As SmtpClient
    Private dato As FileStream

    Private Sub FrmRegeneraCFD_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dtParam As DataTable
        dtParam = ModPOS.Recupera_Tabla("sp_recupera_parametro", "@COMClave", ModPOS.CompanyActual)
        With Me
            Dim i As Integer
            For i = 0 To dtParam.Rows.Count - 1
                Select Case CStr(dtParam.Rows(i)("PARClave"))
                    Case "DirXML"
                        PathXML = dtParam.Rows(i)("Valor")
                    Case "MailAdress"
                        MailAdress = dtParam.Rows(i)("Valor")
                    Case "DisplayName"
                        DisplayName = dtParam.Rows(i)("Valor")
                    Case "MailUser"
                        MailUser = dtParam.Rows(i)("Valor")
                    Case "MailPassword"
                        MailPassword = dtParam.Rows(i)("Valor")
                    Case "HostSMTP"
                        HostSMTP = dtParam.Rows(i)("Valor")
                    Case "MailPort"
                        MailPort = IIf(IsNumeric(dtParam.Rows(i)("Valor")) = True, CInt(dtParam.Rows(i)("Valor")), 0)
                    Case "MailSSL"
                        MailSSL = IIf(dtParam.Rows(i)("Valor") = 1, True, False)
                    
                End Select
            Next
        End With
        dtParam.Dispose()


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

            GridComprobantes.RootTable.Columns("Folio").FormatString = "0"


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
                For i = 0 To GridComprobantes.GetDataRows.Length - 1
                    GridComprobantes.GetDataRows(i).DataRow("Marca") = True
                Next
            Else
                For i = 0 To GridComprobantes.GetDataRows.Length - 1
                    GridComprobantes.GetDataRows(i).DataRow("Marca") = False
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
                Select Case MessageBox.Show("Se regeneraran todos los comprobantes marcados, esta de acuerdo?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    Case DialogResult.Yes

                        Dim frmStatusMessage As New frmStatus
                        frmStatusMessage.Show("Generando Comprobantes Fiscales Digitales...")

                        Dim dt As DataTable

                        Dim oCFD As New CFD

                        oCFD.TipoCF = foundRows(i)("TipoCF")

                        'Recupera información del Emisor

                        dt = ModPOS.Recupera_Tabla("sp_recupera_compania", "@COMClave", ModPOS.CompanyActual)

                        oCFD.eRazonSocial = dt.Rows(0)("Nombre")
                        oCFD.eTPersona = IIf(dt.Rows(0)("TPersona").GetType.Name = "DBNull", 2, dt.Rows(0)("TPersona"))
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
                                    foundRows2 = dtPAC.Select("TipoPAC > 2")
                                    If foundRows2.GetLength(0) = 0 Then
                                        MessageBox.Show("El servicio de recuperación de CFDI no esta disponible para el PAC actual", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        Exit Sub
                                    Else
                                        Dim j As Integer
                                        Dim CBB() As Byte = Nothing


                                        Dim sello As String

                                        Dim iTipoComprobante As Integer
                                        Select Case CInt(foundRows(i)("Tipo"))
                                            Case Is = 0
                                                iTipoComprobante = 1
                                            Case Is = 1
                                                iTipoComprobante = 7
                                            Case Is = 2
                                                iTipoComprobante = 7
                                            Case Is = 6
                                                iTipoComprobante = 6
                                        End Select

                                        sello = ""

                                        If foundRows(i)("TipoDeComprobante") = "ingreso" OrElse foundRows(i)("TipoDeComprobante") = "I" Then
                                            If iTipoComprobante = 6 Then
                                                dt = ModPOS.Recupera_Tabla("sp_sello_cargo", "@CARClave", foundRows(i)("Clave"))
                                                If dt.Rows.Count > 0 Then
                                                    sello = IIf(dt.Rows(0)("Sello").GetType.Name = "DBNull", "", dt.Rows(0)("Sello"))
                                                End If
                                                dt.Dispose()
                                            Else
                                                dt = ModPOS.Recupera_Tabla("sp_sello_fac", "@FACClave", foundRows(i)("Clave"))
                                                If dt.Rows.Count > 0 Then
                                                    sello = IIf(dt.Rows(0)("Sello").GetType.Name = "DBNull", "", dt.Rows(0)("Sello"))
                                                End If
                                                dt.Dispose()

                                                End If
                                                dt.Dispose()
                                        Else

                                            dt = ModPOS.Recupera_Tabla("sp_sello_nc", "@NCClave", foundRows(i)("Clave"))
                                            If dt.Rows.Count > 0 Then
                                                sello = IIf(dt.Rows(0)("Sello").GetType.Name = "DBNull", "", dt.Rows(0)("Sello"))
                                            End If
                                            dt.Dispose()
                                        End If


                                            If foundRows(i)("Version") = "3.3" Then
                                                CBB = ModPOS.crearQR33(oCFD.eRFC, foundRows(i)("RFC"), foundRows(i)("Total"), foundRows(i)("UUID"), Microsoft.VisualBasic.Strings.Right(sello, 8))
                                            Else
                                                CBB = ModPOS.crearQR(oCFD.eRFC, foundRows(i)("RFC"), foundRows(i)("Total"), foundRows(i)("UUID"))
                                            End If




                                            ModPOS.Ejecuta("sp_actualiza_cbb", "@Tipo", foundRows(i)("TipoDeComprobante"), "@DOCClave", foundRows(i)("Clave"), "@CBB", CBB, "@TipoComprobante", foundRows(i)("tipo"))

                                            For j = 0 To foundRows2.GetUpperBound(0)

                                                url = foundRows2(j)("ServerTimbre")
                                                UserId = foundRows2(j)("UserId")
                                                CustomerKey = foundRows2(j)("CustomerKey")

                                                If foundRows2(j)("TipoPAC") = 2 Then 'iTimbre

                                                    Dim consulta As String = BuscarCFDiTimbre(UserId, CustomerKey, oCFD.eRFC, foundRows(i)("Serie") & foundRows(i)("Folio"), foundRows(i)("UUID"))

                                                    Dim content2 As Byte() = System.Text.Encoding.UTF8.GetBytes(consulta)
                                                    Dim peticion2 As System.Net.HttpWebRequest = System.Net.WebRequest.Create(url)

                                                    peticion2.Method = "POST"
                                                    peticion2.ContentType = "application/x-www-form-urlencoded"
                                                    peticion2.ContentLength = content2.Length

                                                    Try
                                                        Dim requestStream2 As System.IO.Stream = peticion2.GetRequestStream()

                                                        requestStream2.Write(content2, 0, content2.Length)
                                                        requestStream2.Close()

                                                        Dim resp2 As System.Net.HttpWebResponse = peticion2.GetResponse()
                                                        Dim respuesta2 As String = New System.IO.StreamReader(resp2.GetResponseStream).ReadToEnd

                                                        If respuesta2.Contains("error") = False Then
                                                            Dim respJson2 As Object = Newtonsoft.Json.Linq.JObject.Parse(respuesta2)

                                                            Dim jResult As Newtonsoft.Json.Linq.JArray = respJson2.Item("result").item("data")

                                                            Dim Elementos As System.Xml.XmlDocument = New System.Xml.XmlDocument()

                                                            Elementos.LoadXml(jResult.Item(0).Item("xml_data").ToString())


                                                            Elementos.Save(TxtDireccion.Text & foundRows(i)("Serie") & foundRows(i)("Folio") & ".xml")

                                                            Exit For
                                                        Else
                                                            If j = foundRows2.GetUpperBound(0) Then
                                                                MsgBox("Se tuvo error  al recuperar el CFD")
                                                            End If
                                                        End If
                                                    Catch ex As Exception
                                                        If j = foundRows2.GetUpperBound(0) Then
                                                            MsgBox("Se tuvo el siguiente error [" & ex.Message & ", verfique su conexión] ")
                                                        End If
                                                    End Try

                                                ElseIf foundRows2(j)("TipoPAC") = 3 Then 'DigitalInvoice

                                                    Dim client As DigitalInvoiceWS.TimbradoClient = New DigitalInvoiceWS.TimbradoClient("BasicHttpBinding_ITimbrado")

                                                    client.ClientCredentials.UserName.UserName = UserId
                                                    client.ClientCredentials.UserName.Password = CustomerKey

                                                    client.Open()

                                                    Dim s As String
                                                    Dim xmlCFDI_Timbrado() As Byte
                                                    Dim doc As System.Xml.XmlDocument = New System.Xml.XmlDocument
                                                    Try
                                                        xmlCFDI_Timbrado = client.RecuperarTimbreUUID(CStr(foundRows(i)("UUID")))

                                                        s = System.Text.Encoding.UTF8.GetString(xmlCFDI_Timbrado)

                                                        doc.LoadXml(s)

                                                        doc.Save(TxtDireccion.Text & foundRows(i)("Serie") & foundRows(i)("Folio") & ".xml")


                                                        Exit For

                                                    Catch ex As Exception
                                                        If j = foundRows2.GetUpperBound(0) Then
                                                            MsgBox("Se tuvo el siguiente error [" & ex.Message & ", verfique su conexión] ")
                                                        End If
                                                    End Try
                                                End If
                                            Next
                                    End If
                                End If

                            Else
                                ' Generar CFD
                                Dim bSinSello As Boolean = False
                                dt = ModPOS.Recupera_Tabla("st_recupera_uuid", "@Tipo", foundRows(i)("tipo"), "@TipoComprobante", foundRows(i)("TipoDeComprobante"), "@Clave", foundRows(i)("Clave"))
                                If dt.Rows.Count = 0 Then
                                    bSinSello = True
                                End If
                                dt.Dispose()

                                If bSinSello OrElse foundRows(i)("noCertificado").GetType.Name = "DBNull" Then
                                    dt = ModPOS.Recupera_Tabla("sp_recupera_certificadovigente", "@COMClave", ModPOS.CompanyActual)
                                    If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                                        foundRows(i)("noCertificado") = dt.Rows(0)("Serie")
                                        dt.Dispose()

                                        foundRows(i)("anoAprobacion") = Today.Year
                                        foundRows(i)("noAprobacion") = "1"



                                        ModPOS.Ejecuta("st_act_documento", "@Tipo", foundRows(i)("tipo"), "@TipoComprobante", foundRows(i)("TipoDeComprobante"), "@Clave", foundRows(i)("Clave"), _
                                                                                   "noCertificado", foundRows(i)("noCertificado"), "anoAprobacion", foundRows(i)("anoAprobacion"), "noAprobacion", foundRows(i)("noAprobacion"))


                                    End If
                            End If

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

                            oCFD.NombreCorto = dt.Rows(0)("NombreCorto")
                            oCFD.RazonSocial = dt.Rows(0)("RazonSocial")
                            oCFD.TPersona = dt.Rows(0)("TPersona")
                            oCFD.RFC = dt.Rows(0)("id_Fiscal")
                            oCFD.LCredito = dt.Rows(0)("LimiteCredito")
                            oCFD.DiasCredito = dt.Rows(0)("DiasCredito")
                            oCFD.Contacto = dt.Rows(0)("Contacto")
                            oCFD.Tel1 = dt.Rows(0)("Tel1")
                            oCFD.Tel2 = dt.Rows(0)("Tel2")
                            oCFD.email = IIf(dt.Rows(0)("Email").GetType.Name <> "DBNull", dt.Rows(0)("Email"), "")
                            oCFD.listaPrecio = dt.Rows(0)("PREClave")
                            oCFD.NoDesglosaIEPS = dt.Rows(0)("DesglosaIVA")
                            oCFD.ImprimirFac = IIf(dt.Rows(0)("ImprimirFac").GetType.Name = "DBNull", True, dt.Rows(0)("ImprimirFac"))

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


                            If oCFD.Referencia = "" Then
                                oCFD.Referencia = "SIN REFERENCIA"
                            End If

                            If oCFD.noInterior <> "" Then
                                oCFD.brnoInterior = True
                            Else
                                oCFD.brnoInterior = False
                            End If

                            dt.Dispose()

                            dt = ModPOS.SiExisteRecupera("sp_recupera_addcte", "@CTEClave", oCFD.CTEClave)

                            If Not dt Is Nothing Then
                                oCFD.tieneAddenda = True
                                oCFD.Tipo = dt.Rows(0)("Tipo")
                                oCFD.TipoConexion = dt.Rows(0)("TipoConexion")
                                oCFD.UsuarioFTP = dt.Rows(0)("UsuarioFTP")
                                oCFD.PwdFTP = dt.Rows(0)("PwdFTP")
                                oCFD.FTP = dt.Rows(0)("FTP")
                                oCFD.Firma = dt.Rows(0)("FirmaWeb")
                                oCFD.emailAdd = dt.Rows(0)("email")
                                oCFD.NoProveedor = dt.Rows(0)("NoProveedor")

                            End If

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
                            oCFD.UsoCFDI = foundRows(i)("UsoCFDI")
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

                                    oCFD.metodoDePago &= CStr(dtMetodoPagos.Rows(j)("ClaveSAT"))

                                    'If dtMetodoPagos.Rows(j)("Banco") <> "" Then
                                    '    oCFD.metodoDePago &= " " & CStr(dtMetodoPagos.Rows(j)("Banco"))
                                    'End If

                                    oCFD.NumCtaPago &= CStr(dtMetodoPagos.Rows(j)("Referencia"))
                                Next

                            End If
                            '


                            oCFD.DOCClave = foundRows(i)("Clave")


                            Dim iTipoComprobante As Integer
                            Select Case CInt(foundRows(i)("Tipo"))
                                Case Is = 0
                                    iTipoComprobante = 1
                                Case Is = 1
                                    iTipoComprobante = 7
                                Case Is = 2
                                    iTipoComprobante = 7
                                Case Is = 6
                                    iTipoComprobante = 6
                            End Select

                            If iTipoComprobante = 1 Then
                                'Verifica si el comprobante cuenta con aplicacion de anticipo
                                dt = ModPOS.Recupera_Tabla("st_obtiene_apl_anticipo", "@DOCClave", oCFD.DOCClave)
                                If dt.Rows.Count > 0 Then
                                    oCFD.AplicaAnticipo = True
                                Else
                                    oCFD.AplicaAnticipo = False
                                End If
                                dt.Dispose()
                            End If

                                    ModPOS.Ejecuta("st_recalcula_documento", "@DOCClave", oCFD.DOCClave, "@Tipo", iTipoComprobante)
                              
                                dt = ModPOS.Recupera_Tabla("st_recupera_comprobante", "@TipoComprobante", foundRows(i)("tipo"), "@Tipo", foundRows(i)("tipoDeComprobante"), "@Clave", foundRows(i)("Clave"))
                                oCFD.Fecha = String.Format("{0:yyyy-MM-ddTHH:mm:ss}", dt.Rows(0)("Fecha"))
                                oCFD.total = dt.Rows(0)("total")
                                oCFD.DiasCredito = CInt(dt.Rows(0)("diasCredito"))
                                oCFD.CondicionesDePago = IIf(oCFD.DiasCredito > 0, CStr(oCFD.DiasCredito) & " días", "")
                                oCFD.TImpuesto = dt.Rows(0)("TipoImpuesto")

                                dt.Dispose()
                                oCFD.Moneda = foundRows(i)("Moneda")
                                oCFD.TipoCambio = foundRows(i)("TipoCambio")
                                'Me.CargaDatosCliente(foundRows(i)("Cliente"))


                                If foundRows(i)("Global") = False Then
                                    dtConcepto = ModPOS.Recupera_Tabla("sp_recupera_elemento", "@TipoComprobante", oCFD.tipoDeComprobante, "@Tipo", iTipoComprobante, "@Clave", oCFD.DOCClave)
                                    dtImpuesto = ModPOS.Recupera_Tabla("sp_recupera_imp_elemento", "@TipoComprobante", oCFD.tipoDeComprobante, "@Tipo", iTipoComprobante, "@Clave", oCFD.DOCClave)
                                    dtDetalleImpuesto = ModPOS.Recupera_Tabla("st_recupera_impuesto_det", "@TipoComprobante", oCFD.tipoDeComprobante, "@Tipo", iTipoComprobante, "@Clave", oCFD.DOCClave)

                                Else
                                    dtConcepto = ModPOS.Recupera_Tabla("st_recupera_concepto_global", "@FACClave", oCFD.DOCClave)
                                    dtImpuesto = ModPOS.Recupera_Tabla("st_recupera_impuesto_global", "@FACClave", oCFD.DOCClave)
                                    dtDetalleImpuesto = ModPOS.Recupera_Tabla("st_recupera_impdet_global", "@FACClave", oCFD.DOCClave)

                                End If

                                If oCFD.VersionCF = "3.3" Then
                                     dtRetencionDet = ModPOS.Recupera_Tabla("st_recupera_retencion_det", "@TipoComprobante", oCFD.tipoDeComprobante, "@Tipo", iTipoComprobante, "@Clave", oCFD.DOCClave)
                                    dtRetencion = ModPOS.Recupera_Tabla("st_recupera_retenciones", "@TipoComprobante", oCFD.tipoDeComprobante, "@Tipo", iTipoComprobante, "@Clave", oCFD.DOCClave)

                                End If



                                If oCFD.TipoCF = 1 Then
                                    oCFD.cadenaOriginal = generarCadenaOriginal(oCFD, dtConcepto, dtImpuesto)
                                Else
                                    If foundRows(i)("Global") = False Then
                                        oCFD.cadenaOriginal = generarCadenaOriginalCFDI(oCFD, dtConcepto, dtImpuesto, iTipoComprobante, dtDetalleImpuesto, dtRetencionDet, dtRetencion)
                                    Else
                                        oCFD.cadenaOriginal = generarCadenaOriginalGlobal(oCFD, dtConcepto, dtImpuesto, dtDetalleImpuesto)
                                    End If
                                End If

                                oCFD.sello = ModPOS.generarSelloDigital(oCFD.cadenaOriginal, oCFD.Serie, oCFD.Folio, oCFD.LlaveFile, oCFD.ContrasenaClave, oCFD.VersionCF)

                                If oCFD.sello Is Nothing OrElse oCFD.sello = "" Then
                                    frmStatusMessage.Close()

                                    Exit Sub
                                End If


                                If foundRows(i)("Global") = False Then
                                    ModPOS.crearXML(3, dtPAC, TxtDireccion.Text, oCFD.Serie & oCFD.Folio, oCFD.DOCClave, oCFD.tipoDeComprobante, oCFD, dtConcepto, dtImpuesto, iTipoComprobante, "", dtDetalleImpuesto, dtRetencionDet, dtRetencion)
                                Else
                                    crearXMLGlobal(3, dtPAC, TxtDireccion.Text, oCFD.Serie & oCFD.Folio, oCFD.DOCClave, dtConcepto, dtImpuesto, dtDetalleImpuesto, oCFD, "")

                                End If

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

  
  
    Private Sub BtnRegenera_Click(sender As Object, e As EventArgs) Handles BtnRegenera.Click
        Dim i As Integer

        Dim foundRows() As DataRow
        foundRows = dtComprobantes.Select("Marca=True and Estado = 1")

        If foundRows.GetLength(0) > 0 Then

            Select Case MessageBox.Show("Se cancelaran todos los comprobantes seleccionados y se notificara correo electronico a los clientes, esta de acuerdo?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                Case DialogResult.Yes

                    If MailAdress = "" OrElse MailUser = "" OrElse MailPassword = "" OrElse HostSMTP = "" OrElse MailPort = 0 Then
                        MessageBox.Show("No se ha configurado una cuenta de correo para envio de información en el Menú de Configuración\Compañia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If


                    Try
                        If Not System.IO.Directory.Exists(PathXML) Then
                            MessageBox.Show("El directorio " & PathXML & " para guardar los XML no existe o no se puede tener acceso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If
                    Catch ex As Exception
                    End Try


                    Dim frmStatusMessage As New frmStatus


                    Dim dt As DataTable
                    Dim oCFD As New CFD
                    Dim dtPAC As DataTable = Nothing


                    dtPAC = ModPOS.Recupera_Tabla("sp_recupera_PAC", "@COMClave", ModPOS.CompanyActual)

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
                    Dim url As String = ""
                    Dim UserId As String = ""
                    Dim CustomerKey As String = ""
                    Dim sFolio As String

                    Dim Final As Integer
                    Final = foundRows.GetUpperBound(0) + 1

                    For i = 0 To foundRows.GetUpperBound(0)

                        frmStatusMessage.Show("Procesando..." & CStr(i + 1) & "/" & CStr(Final))

                        If foundRows(i)("TipoCF") = 2 AndAlso foundRows(i)("Estado") = 1 Then
                            sFolio = foundRows(i)("Serie") & foundRows(i)("Folio")

                            Dim bContinuar As Boolean = False

                            If foundRows(i)("Version") = "3.3" Then
                                bContinuar = True
                                oCFD.UUID_Sustituido = foundRows(i)("UUID")
                            Else
                                bContinuar = ModPOS.cancelarXML(dtPAC, sFolio, foundRows(i)("UUID"), oCFD.eRFC, "", foundRows(i)("tipo"), foundRows(i)("Clave"))
                            End If

                            If bContinuar Then


                                ' Generar CFD

                                Dim bSinSello As Boolean = False
                                dt = ModPOS.Recupera_Tabla("st_recupera_uuid", "@Tipo", foundRows(i)("tipo"), "@TipoComprobante", foundRows(i)("TipoDeComprobante"), "@Clave", foundRows(i)("Clave"))
                                If dt.Rows.Count = 0 Then
                                    bSinSello = True
                                End If
                                dt.Dispose()

                                If bSinSello OrElse foundRows(i)("noCertificado").GetType.Name = "DBNull" Then
                                    dt = ModPOS.Recupera_Tabla("sp_recupera_certificadovigente", "@COMClave", ModPOS.CompanyActual)
                                    If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                                        foundRows(i)("noCertificado") = dt.Rows(0)("Serie")
                                        dt.Dispose()

                                        foundRows(i)("anoAprobacion") = Today.Year
                                        foundRows(i)("noAprobacion") = "1"



                                        ModPOS.Ejecuta("st_act_documento", "@Tipo", foundRows(i)("tipo"), "@TipoComprobante", foundRows(i)("TipoDeComprobante"), "@Clave", foundRows(i)("Clave"), _
                                                                                   "noCertificado", foundRows(i)("noCertificado"), "anoAprobacion", foundRows(i)("anoAprobacion"), "noAprobacion", foundRows(i)("noAprobacion"))

                                    End If
                                End If

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

                                oCFD.NombreCorto = dt.Rows(0)("NombreCorto")
                                oCFD.RazonSocial = dt.Rows(0)("RazonSocial")
                                oCFD.TPersona = dt.Rows(0)("TPersona")
                                oCFD.RFC = dt.Rows(0)("id_Fiscal")
                                oCFD.LCredito = dt.Rows(0)("LimiteCredito")
                                oCFD.DiasCredito = dt.Rows(0)("DiasCredito")
                                oCFD.Contacto = dt.Rows(0)("Contacto")
                                oCFD.Tel1 = dt.Rows(0)("Tel1")
                                oCFD.Tel2 = dt.Rows(0)("Tel2")
                                oCFD.email = IIf(dt.Rows(0)("Email").GetType.Name <> "DBNull", dt.Rows(0)("Email"), "")
                                oCFD.listaPrecio = dt.Rows(0)("PREClave")
                                oCFD.NoDesglosaIEPS = dt.Rows(0)("DesglosaIVA")
                                oCFD.ImprimirFac = IIf(dt.Rows(0)("ImprimirFac").GetType.Name = "DBNull", True, dt.Rows(0)("ImprimirFac"))

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


                                If oCFD.Referencia = "" Then
                                    oCFD.Referencia = "SIN REFERENCIA"
                                End If

                                If oCFD.noInterior <> "" Then
                                    oCFD.brnoInterior = True
                                Else
                                    oCFD.brnoInterior = False
                                End If

                                dt.Dispose()


                                dt = ModPOS.SiExisteRecupera("sp_recupera_addcte", "@CTEClave", oCFD.CTEClave)

                                If Not dt Is Nothing Then
                                    oCFD.tieneAddenda = True
                                    oCFD.Tipo = dt.Rows(0)("Tipo")
                                    oCFD.TipoConexion = dt.Rows(0)("TipoConexion")
                                    oCFD.UsuarioFTP = dt.Rows(0)("UsuarioFTP")
                                    oCFD.PwdFTP = dt.Rows(0)("PwdFTP")
                                    oCFD.FTP = dt.Rows(0)("FTP")
                                    oCFD.Firma = dt.Rows(0)("FirmaWeb")
                                    oCFD.emailAdd = dt.Rows(0)("email")
                                    oCFD.NoProveedor = dt.Rows(0)("NoProveedor")

                                End If
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
                                oCFD.UsoCFDI = foundRows(i)("UsoCFDI")
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

                                        oCFD.metodoDePago &= CStr(dtMetodoPagos.Rows(j)("ClaveSAT"))

                                        'If dtMetodoPagos.Rows(j)("Banco") <> "" Then
                                        '    oCFD.metodoDePago &= " " & CStr(dtMetodoPagos.Rows(j)("Banco"))
                                        'End If

                                        oCFD.NumCtaPago &= CStr(dtMetodoPagos.Rows(j)("Referencia"))
                                    Next

                                End If
                                '99

                                ModPOS.Ejecuta("st_actualiza_fecha", "@TipoComprobante", foundRows(i)("tipo"), "@Tipo", foundRows(i)("tipoDeComprobante"), "@Clave", foundRows(i)("Clave"))


                                oCFD.DOCClave = foundRows(i)("Clave")


                                Dim iTipoComprobante As Integer
                                Select Case CInt(foundRows(i)("Tipo"))
                                    Case Is = 0
                                        iTipoComprobante = 1
                                    Case Is = 1
                                        iTipoComprobante = 7
                                    Case Is = 2
                                        iTipoComprobante = 7
                                    Case Is = 6
                                        iTipoComprobante = 6
                                End Select


                                If iTipoComprobante = 1 Then
                                    'Verifica si el comprobante cuenta con aplicacion de anticipo
                                    dt = ModPOS.Recupera_Tabla("st_obtiene_apl_anticipo", "@DOCClave", oCFD.DOCClave)
                                    If dt.Rows.Count > 0 Then
                                        oCFD.AplicaAnticipo = True
                                    Else
                                        oCFD.AplicaAnticipo = False
                                    End If
                                    dt.Dispose()
                                End If

                                    ModPOS.Ejecuta("st_recalcula_documento", "@DOCClave", oCFD.DOCClave, "@Tipo", iTipoComprobante)
                              
                                'Recupera fecha
                                dt = ModPOS.Recupera_Tabla("st_recupera_comprobante", "@TipoComprobante", foundRows(i)("tipo"), "@Tipo", foundRows(i)("tipoDeComprobante"), "@Clave", foundRows(i)("Clave"))
                                oCFD.Fecha = String.Format("{0:yyyy-MM-ddTHH:mm:ss}", dt.Rows(0)("Fecha"))
                                oCFD.total = dt.Rows(0)("total")
                                oCFD.DiasCredito = CInt(dt.Rows(0)("diasCredito"))
                                oCFD.CondicionesDePago = IIf(oCFD.DiasCredito > 0, CStr(oCFD.DiasCredito) & " días", "")
                                oCFD.TImpuesto = dt.Rows(0)("TipoImpuesto")
                                dt.Dispose()

                                oCFD.Moneda = foundRows(i)("Moneda")
                                oCFD.TipoCambio = foundRows(i)("TipoCambio")

                                If foundRows(i)("Global") = False Then
                                    dtConcepto = ModPOS.Recupera_Tabla("sp_recupera_elemento", "@TipoComprobante", oCFD.tipoDeComprobante, "@Tipo", iTipoComprobante, "@Clave", oCFD.DOCClave)
                                    dtImpuesto = ModPOS.Recupera_Tabla("sp_recupera_imp_elemento", "@TipoComprobante", oCFD.tipoDeComprobante, "@Tipo", iTipoComprobante, "@Clave", oCFD.DOCClave)
                                    dtDetalleImpuesto = ModPOS.Recupera_Tabla("st_recupera_impuesto_det", "@TipoComprobante", oCFD.tipoDeComprobante, "@Tipo", iTipoComprobante, "@Clave", oCFD.DOCClave)
                                Else
                                    dtConcepto = ModPOS.Recupera_Tabla("st_recupera_concepto_global", "@FACClave", oCFD.DOCClave)
                                    dtImpuesto = ModPOS.Recupera_Tabla("st_recupera_impuesto_global", "@FACClave", oCFD.DOCClave)
                                    dtDetalleImpuesto = ModPOS.Recupera_Tabla("st_recupera_impdet_global", "@FACClave", oCFD.DOCClave)
                                End If

                                If oCFD.VersionCF = "3.3" Then
                                    dtRetencionDet = ModPOS.Recupera_Tabla("st_recupera_retencion_det", "@TipoComprobante", oCFD.tipoDeComprobante, "@Tipo", iTipoComprobante, "@Clave", oCFD.DOCClave)
                                    dtRetencion = ModPOS.Recupera_Tabla("st_recupera_retenciones", "@TipoComprobante", oCFD.tipoDeComprobante, "@Tipo", iTipoComprobante, "@Clave", oCFD.DOCClave)

                                End If


                                If oCFD.TipoCF = 1 Then
                                    oCFD.cadenaOriginal = generarCadenaOriginal(oCFD, dtConcepto, dtImpuesto)
                                Else
                                    If foundRows(i)("Global") = False Then

                                        oCFD.cadenaOriginal = generarCadenaOriginalCFDI(oCFD, dtConcepto, dtImpuesto, iTipoComprobante, dtDetalleImpuesto, dtRetencionDet, dtRetencion)
                                    Else
                                        oCFD.cadenaOriginal = generarCadenaOriginalGlobal(oCFD, dtConcepto, dtImpuesto, dtDetalleImpuesto)
                                    End If

                                End If

                                oCFD.sello = ModPOS.generarSelloDigital(oCFD.cadenaOriginal, oCFD.Serie, oCFD.Folio, oCFD.LlaveFile, oCFD.ContrasenaClave, oCFD.VersionCF)

                                If oCFD.sello Is Nothing OrElse oCFD.sello = "" Then
                                    frmStatusMessage.Close()

                                    Exit Sub
                                End If

                                'Elimina Sello 

                                ModPOS.Ejecuta("st_elimina_sello", "@TipoComprobante", foundRows(i)("tipo"), "@Tipo", foundRows(i)("tipoDeComprobante"), "@Clave", foundRows(i)("Clave"))

                                If foundRows(i)("Global") = False Then

                                    ModPOS.crearXML(4, dtPAC, PathXML, oCFD.Serie & oCFD.Folio, oCFD.DOCClave, oCFD.tipoDeComprobante, oCFD, dtConcepto, dtImpuesto, iTipoComprobante, "", dtDetalleImpuesto, dtRetencionDet, dtRetencion)
                                Else
                                    crearXMLGlobal(4, dtPAC, PathXML, oCFD.Serie & oCFD.Folio, oCFD.DOCClave, dtConcepto, dtImpuesto, dtDetalleImpuesto, oCFD, "")
                                End If

                                dtConcepto.Dispose()
                                dtImpuesto.Dispose()
                                Dim UUIDn As String

                                dt = ModPOS.Recupera_Tabla("st_recupera_comprobante", "@TipoComprobante", foundRows(i)("tipo"), "@Tipo", foundRows(i)("tipoDeComprobante"), "@Clave", foundRows(i)("Clave"))
                                UUIDn = CStr(dt.Rows(0)("UUID"))
                                dt.Dispose()

                                If UUIDn <> "" AndAlso oCFD.email <> "" Then
                                    SendMail(oCFD.email, sFolio, foundRows(i)("UUID"), UUIDn, CDate(oCFD.Fecha))
                                End If
                            End If
                            End If

                    Next
                    frmStatusMessage.Dispose()
                    Me.Close()
            End Select

        Else
            MessageBox.Show("¡Debe marcar por lo menos un registro o los registros marcados no se encuentran activos!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub


    Private Sub SendMail(ByVal sMailCliente As String, ByVal sFolio As String, ByVal sUUIDa As String, ByVal sUUIDn As String, ByRef dFecha As Date)

        Dim sPathXML As String
        'Envia Correo

        sPathXML = PathXML
        If sPathXML.Length > 3 AndAlso sPathXML.Substring(sPathXML.Length - 1, 1) <> "\" Then
            sPathXML &= "\"
        End If

        sPathXML &= dFecha.Year.ToString & "\" & dFecha.Month.ToString & "\" & dFecha.Day.ToString & "\" & sFolio & ".xml"



        If Not System.IO.File.Exists(sPathXML) Then
            If PathXML.Length <= 3 Then
                sPathXML = PathXML & sFolio & ".xml"
            Else
                sPathXML = PathXML & "\" & sFolio & ".xml"
            End If

        End If


        If Not System.IO.File.Exists(sPathXML) Then
            MessageBox.Show("Ha ocurrido un error, No se ha encontrado el archivo: " & sPathXML, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Try
                correo = New MailMessage
                autenticar = New NetworkCredential
                envio = New SmtpClient


                correo.Body = "Estimado Cliente, le notificamos que el comprobante " & sFolio & ", con Folio Fiscal: " & sUUIDa & " fue Cancelado y Sustituido por el: " & sUUIDn & ", mismo que anexamos a este corrreo (*.XML) y mantiene las mismas condiciones comerciales e importes. Agradecemos su Preferencia y solicitamos disculpas por los inconvenientes. Saludos cordiales."
                correo.Subject = "Sustitución de Comprobante Fiscal Digital (*.XML)"
                correo.IsBodyHtml = True
                correo.To.Clear()
                correo.CC.Clear()
                correo.Bcc.Clear()


                If sMailCliente.Split(",").Length >= 1 Then
                    Dim j As Integer
                    For j = 0 To sMailCliente.Split(",").Length - 1
                        If sMailCliente.Split(",")(j) <> "" Then
                            correo.To.Add(sMailCliente.Split(",")(j))
                        End If
                    Next
                Else
                    correo.To.Add(sMailCliente)
                End If


                correo.From = New MailAddress(MailAdress, DisplayName)
                envio.Credentials = New NetworkCredential(MailUser, MailPassword)
                envio.Host = HostSMTP  '"smtp.live.com"
                envio.Port = MailPort  '587
                envio.EnableSsl = MailSSL 'True



                dato = New FileStream(sPathXML, FileMode.Open, FileAccess.Read)
                adjuntos = New Attachment(dato, sFolio & ".XML")
                correo.Attachments.Add(adjuntos)


                envio.Send(correo)
                correo.Dispose()

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            If Not dato Is Nothing Then
                dato.Close()
            End If
        End If
    End Sub

    Private Sub btnQR_Click(sender As Object, e As EventArgs) Handles btnQR.Click
        If Me.dtComprobantes.Rows.Count = 0 Then

            MsgBox("No se encontró algun comprobante en el rango de fechas especificado", MsgBoxStyle.Information, "Información")
            Me.Close()

        Else



            Dim i As Integer

            Dim foundRows() As DataRow
            foundRows = dtComprobantes.Select("Marca=True")

            If foundRows.GetLength(0) > 0 Then

                Cursor.Current = Cursors.WaitCursor
                Select Case MessageBox.Show("Se regeneraran todos los QR de los documentos marcados, esta de acuerdo?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    Case DialogResult.Yes

                        Dim frmStatusMessage As New frmStatus
                        frmStatusMessage.Show("Generando Código QR..." & CStr(i + 1))

                        Dim dt As DataTable

                        Dim oCFD As New CFD

                        oCFD.TipoCF = foundRows(i)("TipoCF")

                        'Recupera información del Emisor

                        Dim sello As String
                        Dim CBB() As Byte = Nothing

                        For i = 0 To foundRows.GetUpperBound(0)
                            'Recuperar Timbre


                            Dim iTipoComprobante As Integer
                            Select Case CInt(foundRows(i)("Tipo"))
                                Case Is = 0
                                    iTipoComprobante = 1
                                Case Is = 1
                                    iTipoComprobante = 7
                                Case Is = 2
                                    iTipoComprobante = 7
                                Case Is = 6
                                    iTipoComprobante = 6
                            End Select

                            If foundRows(i)("tipoDeComprobante") = "ingreso" OrElse foundRows(i)("tipoDeComprobante") = "I" Then
                                If iTipoComprobante = 6 Then
                                    dt = ModPOS.Recupera_Tabla("sp_sello_cargo", "@CARClave", foundRows(i)("Clave"))
                                    sello = IIf(dt.Rows(0)("Sello").GetType.Name = "DBNull", "", dt.Rows(0)("Sello"))
                                    dt.Dispose()
                                Else
                                    dt = ModPOS.Recupera_Tabla("sp_sello_fac", "@FACClave", foundRows(i)("Clave"))
                                    sello = IIf(dt.Rows(0)("Sello").GetType.Name = "DBNull", "", dt.Rows(0)("Sello"))
                                    dt.Dispose()

                                End If
                                dt.Dispose()
                            Else

                                dt = ModPOS.Recupera_Tabla("sp_sello_nc", "@NCClave", foundRows(i)("Clave"))
                                sello = IIf(dt.Rows(0)("Sello").GetType.Name = "DBNull", "", dt.Rows(0)("Sello"))
                                dt.Dispose()
                            End If


                            If foundRows(i)("Version") = "3.3" Then
                                CBB = ModPOS.crearQR33(oCFD.eRFC, foundRows(i)("RFC"), foundRows(i)("Total"), foundRows(i)("UUID"), Microsoft.VisualBasic.Strings.Right(sello, 8))
                            Else
                                CBB = ModPOS.crearQR(oCFD.eRFC, foundRows(i)("RFC"), foundRows(i)("Total"), foundRows(i)("UUID"))
                            End If

                            ModPOS.Ejecuta("sp_actualiza_cbb", "@Tipo", foundRows(i)("TipoDeComprobante"), "@DOCClave", foundRows(i)("Clave"), "@CBB", CBB, "@TipoComprobante", foundRows(i)("tipo"))
                        Next
                        frmStatusMessage.Close()
                End Select



            End If
        End If
    End Sub
End Class
