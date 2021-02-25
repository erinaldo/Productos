Public Class FrmAdjuntar
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'UserControl overrides dispose to clean up the component list.
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
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents PictureBox28 As System.Windows.Forms.PictureBox
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents btnXmlD As Janus.Windows.EditControls.UIButton
    Friend WithEvents txtXml As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox26 As System.Windows.Forms.PictureBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents btnPdfD As Janus.Windows.EditControls.UIButton
    Friend WithEvents txtPdf As System.Windows.Forms.TextBox
    Friend WithEvents btnXmlU As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnPdfU As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnSalir As Janus.Windows.EditControls.UIButton

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAdjuntar))
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton()
        Me.btnSalir = New Janus.Windows.EditControls.UIButton()
        Me.PictureBox28 = New System.Windows.Forms.PictureBox()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.btnXmlD = New Janus.Windows.EditControls.UIButton()
        Me.txtXml = New System.Windows.Forms.TextBox()
        Me.PictureBox26 = New System.Windows.Forms.PictureBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.btnPdfD = New Janus.Windows.EditControls.UIButton()
        Me.txtPdf = New System.Windows.Forms.TextBox()
        Me.btnXmlU = New Janus.Windows.EditControls.UIButton()
        Me.btnPdfU = New Janus.Windows.EditControls.UIButton()
        CType(Me.PictureBox28, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox26, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.Location = New System.Drawing.Point(441, 101)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 119
        Me.BtnGuardar.Text = "&Aceptar"
        Me.BtnGuardar.ToolTipText = "Guardar cambios"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.Location = New System.Drawing.Point(345, 101)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(90, 37)
        Me.btnSalir.TabIndex = 120
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.ToolTipText = "Cancelar y cerrar nómina"
        Me.btnSalir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'PictureBox28
        '
        Me.PictureBox28.Image = CType(resources.GetObject("PictureBox28.Image"), System.Drawing.Image)
        Me.PictureBox28.Location = New System.Drawing.Point(-1, 57)
        Me.PictureBox28.Name = "PictureBox28"
        Me.PictureBox28.Size = New System.Drawing.Size(28, 20)
        Me.PictureBox28.TabIndex = 128
        Me.PictureBox28.TabStop = False
        Me.PictureBox28.Visible = False
        '
        'Label44
        '
        Me.Label44.Location = New System.Drawing.Point(33, 60)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(40, 19)
        Me.Label44.TabIndex = 125
        Me.Label44.Text = "XML"
        '
        'btnXmlD
        '
        Me.btnXmlD.Icon = CType(resources.GetObject("btnXmlD.Icon"), System.Drawing.Icon)
        Me.btnXmlD.ImageSize = New System.Drawing.Size(20, 20)
        Me.btnXmlD.Location = New System.Drawing.Point(454, 50)
        Me.btnXmlD.Name = "btnXmlD"
        Me.btnXmlD.Size = New System.Drawing.Size(33, 29)
        Me.btnXmlD.TabIndex = 127
        Me.btnXmlD.ToolTipText = "Anexar archivo XML  al documento seleccionado"
        '
        'txtXml
        '
        Me.txtXml.Location = New System.Drawing.Point(79, 57)
        Me.txtXml.Name = "txtXml"
        Me.txtXml.ReadOnly = True
        Me.txtXml.Size = New System.Drawing.Size(359, 20)
        Me.txtXml.TabIndex = 126
        Me.txtXml.TabStop = False
        '
        'PictureBox26
        '
        Me.PictureBox26.Image = CType(resources.GetObject("PictureBox26.Image"), System.Drawing.Image)
        Me.PictureBox26.Location = New System.Drawing.Point(-1, 24)
        Me.PictureBox26.Name = "PictureBox26"
        Me.PictureBox26.Size = New System.Drawing.Size(28, 20)
        Me.PictureBox26.TabIndex = 124
        Me.PictureBox26.TabStop = False
        Me.PictureBox26.Visible = False
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(33, 25)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(40, 19)
        Me.Label15.TabIndex = 121
        Me.Label15.Text = "PDF"
        '
        'btnPdfD
        '
        Me.btnPdfD.Icon = CType(resources.GetObject("btnPdfD.Icon"), System.Drawing.Icon)
        Me.btnPdfD.ImageSize = New System.Drawing.Size(20, 20)
        Me.btnPdfD.Location = New System.Drawing.Point(454, 15)
        Me.btnPdfD.Name = "btnPdfD"
        Me.btnPdfD.Size = New System.Drawing.Size(33, 29)
        Me.btnPdfD.TabIndex = 123
        Me.btnPdfD.ToolTipText = "Anexar archivo PDF al documento seleccionado"
        '
        'txtPdf
        '
        Me.txtPdf.Location = New System.Drawing.Point(79, 22)
        Me.txtPdf.Name = "txtPdf"
        Me.txtPdf.ReadOnly = True
        Me.txtPdf.Size = New System.Drawing.Size(359, 20)
        Me.txtPdf.TabIndex = 122
        Me.txtPdf.TabStop = False
        '
        'btnXmlU
        '
        Me.btnXmlU.Icon = CType(resources.GetObject("btnXmlU.Icon"), System.Drawing.Icon)
        Me.btnXmlU.ImageSize = New System.Drawing.Size(20, 20)
        Me.btnXmlU.Location = New System.Drawing.Point(493, 50)
        Me.btnXmlU.Name = "btnXmlU"
        Me.btnXmlU.Size = New System.Drawing.Size(33, 29)
        Me.btnXmlU.TabIndex = 130
        Me.btnXmlU.ToolTipText = "Descargar archivo XML"
        '
        'btnPdfU
        '
        Me.btnPdfU.Icon = CType(resources.GetObject("btnPdfU.Icon"), System.Drawing.Icon)
        Me.btnPdfU.ImageSize = New System.Drawing.Size(20, 20)
        Me.btnPdfU.Location = New System.Drawing.Point(493, 15)
        Me.btnPdfU.Name = "btnPdfU"
        Me.btnPdfU.Size = New System.Drawing.Size(33, 29)
        Me.btnPdfU.TabIndex = 129
        Me.btnPdfU.ToolTipText = "Descargar archivo PDF "
        '
        'FrmAdjuntar
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(536, 143)
        Me.Controls.Add(Me.btnXmlU)
        Me.Controls.Add(Me.btnPdfU)
        Me.Controls.Add(Me.PictureBox28)
        Me.Controls.Add(Me.Label44)
        Me.Controls.Add(Me.btnXmlD)
        Me.Controls.Add(Me.txtXml)
        Me.Controls.Add(Me.PictureBox26)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.btnPdfD)
        Me.Controls.Add(Me.txtPdf)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.btnSalir)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(552, 182)
        Me.Name = "FrmAdjuntar"
        Me.Text = "Consulta "
        CType(Me.PictureBox28, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox26, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Public TipoDocumento As String
    Public COMClave As String

    Private sURL As String
    Private oDestino As String

    Private Sub FrmAdjuntar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dtParam As DataTable
        dtParam = ModPOS.Recupera_Tabla("sp_recupera_parametro", "@COMClave", ModPOS.CompanyActual)
        With Me
            Dim i As Integer
            For i = 0 To dtParam.Rows.Count - 1
                Select Case CStr(dtParam.Rows(i)("PARClave"))
                    Case "CFDCompras"
                        sURL = IIf(dtParam.Rows(i)("Valor").GetType.Name = "DBNull", "", dtParam.Rows(i)("Valor"))
                End Select
            Next
        End With
        dtParam.Dispose()


        'Verifica que exista el path
        Try
            If Not System.IO.Directory.Exists(sURL) Then
                MessageBox.Show("El directorio " & sURL & " para guardar los XML y PDF no existe o no se puede tener acceso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
            End If
        Catch ex As Exception
        End Try

        If sURL.Length <= 3 Then
            oDestino = sURL & COMClave
        ElseIf sURL.Substring(sURL.Length - 1, 1) = "\" Then
            oDestino = sURL & COMClave
        Else
            oDestino = sURL & "\" & COMClave
        End If


        Try
            If System.IO.File.Exists(oDestino & ".xml") Then
                txtXml.Text = COMClave & ".xml"
            End If
        Catch ex As Exception
        End Try

        Try
            If System.IO.File.Exists(oDestino & ".pdf") Then
                txtPdf.Text = COMClave & ".pdf"
            End If
        Catch ex As Exception
        End Try





    End Sub

    Private Sub btnPdfD_Click(sender As Object, e As EventArgs) Handles btnPdfD.Click
        Try

            Dim sOrigen As String

            Dim openDlg As OpenFileDialog = New OpenFileDialog
            openDlg.Filter = "PDF (*.PDF)|*.pdf"
            Dim filter As String = openDlg.Filter
            openDlg.Title = "Abrir un Archivo PDF"
            If (openDlg.ShowDialog() = DialogResult.OK) Then

                sOrigen = openDlg.FileName

                'Copia la imagen del archivo
                Try
                    My.Computer.FileSystem.CopyFile(sOrigen, oDestino & ".pdf", True)
                    txtPdf.Text = COMClave & ".pdf"
                Catch ex As Exception
                    MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
                End Try

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub btnXmlD_Click(sender As Object, e As EventArgs) Handles btnXmlD.Click
        Try

            Dim sOrigen As String

            Dim openDlg As OpenFileDialog = New OpenFileDialog
            openDlg.Filter = "XML (*.XML)|*.xml"
            Dim filter As String = openDlg.Filter
            openDlg.Title = "Abrir un Archivo XML"
            If (openDlg.ShowDialog() = DialogResult.OK) Then

                sOrigen = openDlg.FileName
                Dim sUUID As String = ""
                Dim oXml As New Xml.XmlDocument()
                oXml.Load(sOrigen)

                Dim oXmlNodos As Xml.XmlNodeList = oXml.GetElementsByTagName("cfdi:Complemento")

                Dim o As Integer

                For o = 0 To oXmlNodos.ItemOf(0).FirstChild.Attributes.Count - 1

                    Select Case oXmlNodos.ItemOf(0).FirstChild.Attributes.ItemOf(o).Name
                        Case Is = "UUID"
                            sUUID = oXmlNodos.ItemOf(0).FirstChild.Attributes.ItemOf(o).Value
                            Exit For
                        End Select
                Next


                If sUUID = "" Then
                    MessageBox.Show("El XML no es valido, no se encontro el elemento UUID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                Else
                    If TipoDocumento = "Compra" Then
                        ModPOS.Ejecuta("st_actualiza_uuid", "@Tipo", 1, "@COMClave", COMClave, "@UUID", sUUID)
                    ElseIf TipoDocumento = "NC" Then
                        ModPOS.Ejecuta("st_actualiza_uuid", "@Tipo", 2, "@COMClave", COMClave, "@UUID", sUUID)
                    End If
                End If

                'Copia la imagen del archivo
                Try
                    My.Computer.FileSystem.CopyFile(sOrigen, oDestino & ".xml", True)
                    txtXml.Text = COMClave & ".xml"
                Catch ex As Exception
                    MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
                End Try

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub btnPdfU_Click(sender As Object, e As EventArgs) Handles btnPdfU.Click
        If Not txtPdf.Text = "" Then
            Try
                If System.IO.File.Exists(oDestino & ".pdf") Then
                    Dim a As New System.Windows.Forms.FolderBrowserDialog
                    If (a.ShowDialog() = DialogResult.OK) Then
                        Dim sPath As String = a.SelectedPath
                        Dim sDestino As String

                        If sPath.Length <= 3 Then
                            sDestino = sPath & COMClave & ".pdf"
                        ElseIf sPath.Substring(sPath.Length - 1, 1) = "\" Then
                            sDestino = sPath & COMClave & ".pdf"
                        Else
                            sDestino = sPath & "\" & COMClave & ".pdf"
                        End If

                        'Copia la imagen del archivo
                        Try
                            My.Computer.FileSystem.CopyFile(oDestino & ".pdf", sDestino, True)
                            MessageBox.Show("El archivo se copio con exito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        Catch ex As Exception
                            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
                        End Try

                    End If
                Else
                    MessageBox.Show("El archivo " & oDestino & ".pdf" & " no existe o no se puede tener acceso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                End If
            Catch ex As Exception
            End Try

        Else
            MessageBox.Show("El archivo " & oDestino & ".pdf" & " no existe o no se puede tener acceso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnXmlU_Click(sender As Object, e As EventArgs) Handles btnXmlU.Click
        If Not txtXml.Text = "" Then
            Try
                If System.IO.File.Exists(oDestino & ".xml") Then
                    Dim a As New System.Windows.Forms.FolderBrowserDialog
                    If (a.ShowDialog() = DialogResult.OK) Then
                        Dim sPath As String = a.SelectedPath
                        Dim sDestino As String

                        If sPath.Length <= 3 Then
                            sDestino = sPath & COMClave & ".xml"
                        ElseIf sPath.Substring(sPath.Length - 1, 1) = "\" Then
                            sDestino = sPath & COMClave & ".xml"
                        Else
                            sDestino = sPath & "\" & COMClave & ".xml"
                        End If

                        'Copia la imagen del archivo
                        Try
                            My.Computer.FileSystem.CopyFile(oDestino & ".xml", sDestino, True)
                            MessageBox.Show("El archivo se copio con exito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        Catch ex As Exception
                            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
                        End Try

                    End If
                Else
                    MessageBox.Show("El archivo " & oDestino & ".xml" & " no existe o no se puede tener acceso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                End If
            Catch ex As Exception
            End Try

        Else
            MessageBox.Show("El archivo " & oDestino & ".xml" & " no existe o no se puede tener acceso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class
