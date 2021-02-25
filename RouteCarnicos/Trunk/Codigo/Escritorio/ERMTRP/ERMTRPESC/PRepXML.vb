Imports ERMTRPLOG

Public Class PRepXML
    Inherits System.Windows.Forms.Form
    Private vgTRP As New cTransProd
    Private vcMensaje As BASMENLOG.CMensaje
    Private oConexion As LbConexion.cConexion = LbConexion.cConexion.Instancia

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal pvTransProd As cTransProd)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.vgTRP = pvTransProd
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
    Friend WithEvents lbTipo As System.Windows.Forms.Label
    Friend WithEvents lbNombre As System.Windows.Forms.Label
    Friend WithEvents lbTipoT As System.Windows.Forms.Label
    Friend WithEvents lbNombreT As System.Windows.Forms.Label
    Friend WithEvents btGuardarComo As Janus.Windows.EditControls.UIButton
    Friend WithEvents btAbrir As Janus.Windows.EditControls.UIButton
    Friend WithEvents btGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PRepXML))
        Me.lbTipo = New System.Windows.Forms.Label
        Me.lbNombre = New System.Windows.Forms.Label
        Me.lbTipoT = New System.Windows.Forms.Label
        Me.lbNombreT = New System.Windows.Forms.Label
        Me.btGuardarComo = New Janus.Windows.EditControls.UIButton
        Me.btAbrir = New Janus.Windows.EditControls.UIButton
        Me.btGuardar = New Janus.Windows.EditControls.UIButton
        Me.btCancelar = New Janus.Windows.EditControls.UIButton
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'lbTipo
        '
        Me.lbTipo.AutoSize = True
        Me.lbTipo.Location = New System.Drawing.Point(184, 32)
        Me.lbTipo.Name = "lbTipo"
        Me.lbTipo.Size = New System.Drawing.Size(36, 13)
        Me.lbTipo.TabIndex = 49
        Me.lbTipo.Text = "lbTipo"
        '
        'lbNombre
        '
        Me.lbNombre.AutoSize = True
        Me.lbNombre.Location = New System.Drawing.Point(184, 8)
        Me.lbNombre.Name = "lbNombre"
        Me.lbNombre.Size = New System.Drawing.Size(52, 13)
        Me.lbNombre.TabIndex = 48
        Me.lbNombre.Text = "lbNombre"
        '
        'lbTipoT
        '
        Me.lbTipoT.Location = New System.Drawing.Point(88, 32)
        Me.lbTipoT.Name = "lbTipoT"
        Me.lbTipoT.Size = New System.Drawing.Size(100, 23)
        Me.lbTipoT.TabIndex = 46
        Me.lbTipoT.Text = "lbTipoT"
        '
        'lbNombreT
        '
        Me.lbNombreT.Location = New System.Drawing.Point(88, 8)
        Me.lbNombreT.Name = "lbNombreT"
        Me.lbNombreT.Size = New System.Drawing.Size(104, 23)
        Me.lbNombreT.TabIndex = 45
        Me.lbNombreT.Text = "lbNombreT"
        '
        'btGuardarComo
        '
        Me.btGuardarComo.Icon = CType(resources.GetObject("btGuardarComo.Icon"), System.Drawing.Icon)
        Me.btGuardarComo.Location = New System.Drawing.Point(384, 72)
        Me.btGuardarComo.Name = "btGuardarComo"
        Me.btGuardarComo.Size = New System.Drawing.Size(104, 24)
        Me.btGuardarComo.TabIndex = 54
        Me.btGuardarComo.Text = "btGuardarComo"
        Me.btGuardarComo.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'btAbrir
        '
        Me.btAbrir.Icon = CType(resources.GetObject("btAbrir.Icon"), System.Drawing.Icon)
        Me.btAbrir.Location = New System.Drawing.Point(144, 72)
        Me.btAbrir.Name = "btAbrir"
        Me.btAbrir.Size = New System.Drawing.Size(104, 24)
        Me.btAbrir.TabIndex = 53
        Me.btAbrir.Text = "btAbrir"
        Me.btAbrir.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'btGuardar
        '
        Me.btGuardar.Icon = CType(resources.GetObject("btGuardar.Icon"), System.Drawing.Icon)
        Me.btGuardar.Location = New System.Drawing.Point(264, 72)
        Me.btGuardar.Name = "btGuardar"
        Me.btGuardar.Size = New System.Drawing.Size(104, 24)
        Me.btGuardar.TabIndex = 51
        Me.btGuardar.Text = "btGuardar"
        Me.btGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'btCancelar
        '
        Me.btCancelar.CausesValidation = False
        Me.btCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btCancelar.Icon = CType(resources.GetObject("btCancelar.Icon"), System.Drawing.Icon)
        Me.btCancelar.Location = New System.Drawing.Point(504, 72)
        Me.btCancelar.Name = "btCancelar"
        Me.btCancelar.Size = New System.Drawing.Size(104, 24)
        Me.btCancelar.TabIndex = 52
        Me.btCancelar.Text = "btCancelar"
        Me.btCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Location = New System.Drawing.Point(11, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(600, 3)
        Me.Label1.TabIndex = 55
        '
        'PRepXML
        '
        Me.AcceptButton = Me.btGuardar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btCancelar
        Me.ClientSize = New System.Drawing.Size(624, 112)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btGuardarComo)
        Me.Controls.Add(Me.btAbrir)
        Me.Controls.Add(Me.btGuardar)
        Me.Controls.Add(Me.btCancelar)
        Me.Controls.Add(Me.lbTipo)
        Me.Controls.Add(Me.lbNombre)
        Me.Controls.Add(Me.lbTipoT)
        Me.Controls.Add(Me.lbNombreT)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(630, 144)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(630, 144)
        Me.Name = "PRepXML"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "PRepXML"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region


    Private Sub btCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCancelar.Click
        Me.Close()
    End Sub

    Private Sub btGuardarComo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btGuardarComo.Click
        Dim vlDirDocXML As String = vgTRP.obtenerDirDocXML(vgTRP.SubEmpresaId)
        Dim FBD As New FolderBrowserDialog
        FBD.SelectedPath = vlDirDocXML

        If FBD.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If vlDirDocXML <> FBD.SelectedPath Then

                Try
                    If (vgTRP.vgTRPDatoFiscal.TipoVersion = "2.0") Then
                        vgTRP.GenerarXML(vgTRP, FBD.SelectedPath, False, "", "", False)
                    ElseIf (vgTRP.vgTRPDatoFiscal.TipoVersion = "2.2") Then
                        vgTRP.GenerarXML(vgTRP, FBD.SelectedPath, False, "", "", True)
                    Else
                        'Dim oCfdi As ERMTRPLOG.CFDi
                        vgTRP.GenerarXMLVersion3(vgTRP, FBD.SelectedPath, False, "", "", Nothing)
                    End If
                Catch ex As LbControlError.cError
                    ex.Mostrar()
                End Try

            End If
            Me.Close()
        End If
    End Sub

    Private Sub btGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btGuardar.Click
        Try
            If (vgTRP.vgTRPDatoFiscal.TipoVersion = "2.0" Or vgTRP.vgTRPDatoFiscal.TipoVersion = "2.2") Then
                vgTRP.GenerarXML(vgTRP, vgTRP.obtenerDirDocXML(vgTRP.SubEmpresaId), False, "", "")
            Else
                'Dim oCfdi As ERMTRPLOG.CFDi
                vgTRP.GenerarXMLVersion3(vgTRP, vgTRP.obtenerDirDocXML(vgTRP.SubEmpresaId), False, "", "", Nothing)
            End If

        Catch ex As LbControlError.cError
            ex.Mostrar()
        End Try

        Me.Close()
    End Sub

    Private Sub btAbrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAbrir.Click
        Dim vlDir As String = ""
        Try

            HabilitarBotones(False)
            Dim hilo As New System.Threading.Thread(AddressOf Explorador)
            hilo.SetApartmentState(Threading.ApartmentState.STA)
            hilo.Start()

            While (hilo.IsAlive)
                Application.DoEvents()
            End While

            HabilitarBotones(True)

        Catch ex As LbControlError.cError
            ex.Mostrar()
            If vlDir <> "" Then If IO.Directory.Exists(vlDir) Then IO.Directory.Delete(vlDir, True)
            HabilitarBotones(True)
        Catch ex As Exception
            MsgBox(ex.Message)
            HabilitarBotones(True)
        End Try
        'Me.Close()
    End Sub
    Public Sub Explorador()

        Dim vlDir As String = ""
        Try
            vlDir = vgTRP.obtenerDirDocXML(vgTRP.SubEmpresaId) & "\tmp\"
            Dim vlArchivo As String = vlDir & vgTRP.Folio & ".xml"

            If IO.Directory.Exists(vlDir) = False Then
                IO.Directory.CreateDirectory(vlDir)
            End If

            'IO.Directory.GetAccessControl("
            If (vgTRP.vgTRPDatoFiscal.TipoVersion = "2.0" Or vgTRP.vgTRPDatoFiscal.TipoVersion = "2.2") Then
                vgTRP.GenerarXML(vgTRP, vlDir, False, "", "")
            Else
                'Dim oCfdi As ERMTRPLOG.CFDi
                vgTRP.GenerarXMLVersion3(vgTRP, vlDir, False, "", "", Nothing)
            End If

            'Process.Start("notepad", vlArchivo)
            'System.Threading.Thread.Sleep(1000)
            'System.Threading.Thread.CurrentThread.SetApartmentState(Threading.ApartmentState.STA)
            Dim vXml As New VRepXml(vlArchivo)

            vXml.ShowDialog()

            If IO.Directory.Exists(vlDir) Then IO.Directory.Delete(vlDir, True)

        Catch ex As LbControlError.cError
            ex.Mostrar()
            If vlDir <> "" Then If IO.Directory.Exists(vlDir) Then IO.Directory.Delete(vlDir, True)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        'Me.Close()
    End Sub
    'Dim oSubempresa As ERMSEMLOG.cSubEmpresa
    Private Sub PRepXML_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'oSubempresa = New ERMSEMLOG.cSubEmpresa()
        'oSubempresa.Recuperar(vgTRP.SubEmpresaId, vgTRP.FechaHoraAlta)
        vgTRP.vgTRPDatoFiscal = New cTRPDatoFiscal(vgTRP)
        vgTRP.vgTRPDatoFiscal.Recuperar(vgTRP.TransProdID)
        vcMensaje = New BASMENLOG.CMensaje
        iniciarpantalla()

        Me.lbNombre.Text = vgTRP.Folio & ".xml"
        Me.lbTipo.Text = vgTRP.TipoXML()

    End Sub

    Private Sub iniciarpantalla()
        Me.Text = vcMensaje.RecuperarDescripcion("XGuardarXML")
        Me.lbNombreT.Text = vcMensaje.RecuperarDescripcion("XNombre")
        Me.lbTipoT.Text = vcMensaje.RecuperarDescripcion("XTipo")

        Me.btAbrir.Text = vcMensaje.RecuperarDescripcion("BtAbrir")
        Me.btAbrir.ToolTipText = vcMensaje.RecuperarDescripcion("BtAbrir")
        Me.btCancelar.Text = vcMensaje.RecuperarDescripcion("BtCancelar")
        Me.btCancelar.ToolTipText = vcMensaje.RecuperarDescripcion("BtCancelarT")
        Me.btGuardar.Text = vcMensaje.RecuperarDescripcion("BtGuardar")
        Me.btGuardar.ToolTipText = vcMensaje.RecuperarDescripcion("BtAceptarT")
        Me.btGuardarComo.Text = vcMensaje.RecuperarDescripcion("BtGuardarComo")
        Me.btGuardarComo.ToolTipText = vcMensaje.RecuperarDescripcion("BtGuardarComoT")
    End Sub

    Private Sub HabilitarBotones(ByVal pHabilitar As Boolean)
        Me.btAbrir.Enabled = pHabilitar
        Me.btGuardar.Enabled = pHabilitar
        Me.btGuardarComo.Enabled = pHabilitar
        Me.btCancelar.Enabled = pHabilitar
    End Sub
End Class
