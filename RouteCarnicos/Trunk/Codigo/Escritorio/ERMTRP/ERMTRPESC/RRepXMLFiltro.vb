Public Class RRepXMLFiltro
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal parbEnviarAdenda As Boolean)
        MyBase.New()
        bEnviarAdenda = parbEnviarAdenda
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
    Friend WithEvents btGuardarComo As Janus.Windows.EditControls.UIButton
    Friend WithEvents btGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents btCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents lbTipoT As System.Windows.Forms.Label
    Friend WithEvents lbPregunta As System.Windows.Forms.Label
    Friend WithEvents lbTipo As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbCantidadT As System.Windows.Forms.Label
    Friend WithEvents chEnviarFactura As Janus.Windows.EditControls.UICheckBox
    Friend WithEvents lbCantidad As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RRepXMLFiltro))
        Me.btGuardarComo = New Janus.Windows.EditControls.UIButton
        Me.btGuardar = New Janus.Windows.EditControls.UIButton
        Me.btCancelar = New Janus.Windows.EditControls.UIButton
        Me.lbTipoT = New System.Windows.Forms.Label
        Me.lbPregunta = New System.Windows.Forms.Label
        Me.lbTipo = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lbCantidadT = New System.Windows.Forms.Label
        Me.lbCantidad = New System.Windows.Forms.Label
        Me.chEnviarFactura = New Janus.Windows.EditControls.UICheckBox
        Me.SuspendLayout()
        '
        'btGuardarComo
        '
        Me.btGuardarComo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btGuardarComo.Icon = CType(resources.GetObject("btGuardarComo.Icon"), System.Drawing.Icon)
        Me.btGuardarComo.Location = New System.Drawing.Point(210, 122)
        Me.btGuardarComo.Name = "btGuardarComo"
        Me.btGuardarComo.Size = New System.Drawing.Size(104, 24)
        Me.btGuardarComo.TabIndex = 57
        Me.btGuardarComo.Text = "btGuardarComo"
        Me.btGuardarComo.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'btGuardar
        '
        Me.btGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btGuardar.Icon = CType(resources.GetObject("btGuardar.Icon"), System.Drawing.Icon)
        Me.btGuardar.Location = New System.Drawing.Point(90, 122)
        Me.btGuardar.Name = "btGuardar"
        Me.btGuardar.Size = New System.Drawing.Size(104, 24)
        Me.btGuardar.TabIndex = 55
        Me.btGuardar.Text = "btGuardar"
        Me.btGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'btCancelar
        '
        Me.btCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btCancelar.CausesValidation = False
        Me.btCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btCancelar.Icon = CType(resources.GetObject("btCancelar.Icon"), System.Drawing.Icon)
        Me.btCancelar.Location = New System.Drawing.Point(330, 122)
        Me.btCancelar.Name = "btCancelar"
        Me.btCancelar.Size = New System.Drawing.Size(104, 24)
        Me.btCancelar.TabIndex = 56
        Me.btCancelar.Text = "btCancelar"
        Me.btCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'lbTipoT
        '
        Me.lbTipoT.Location = New System.Drawing.Point(16, 16)
        Me.lbTipoT.Name = "lbTipoT"
        Me.lbTipoT.Size = New System.Drawing.Size(64, 23)
        Me.lbTipoT.TabIndex = 58
        Me.lbTipoT.Text = "lbTipoT"
        '
        'lbPregunta
        '
        Me.lbPregunta.AutoSize = True
        Me.lbPregunta.Location = New System.Drawing.Point(80, 68)
        Me.lbPregunta.Name = "lbPregunta"
        Me.lbPregunta.Size = New System.Drawing.Size(58, 13)
        Me.lbPregunta.TabIndex = 60
        Me.lbPregunta.Text = "lbPregunta"
        '
        'lbTipo
        '
        Me.lbTipo.AutoSize = True
        Me.lbTipo.Location = New System.Drawing.Point(72, 16)
        Me.lbTipo.Name = "lbTipo"
        Me.lbTipo.Size = New System.Drawing.Size(36, 13)
        Me.lbTipo.TabIndex = 61
        Me.lbTipo.Text = "lbTipo"
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Location = New System.Drawing.Point(10, 114)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(424, 3)
        Me.Label1.TabIndex = 62
        '
        'lbCantidadT
        '
        Me.lbCantidadT.Location = New System.Drawing.Point(16, 40)
        Me.lbCantidadT.Name = "lbCantidadT"
        Me.lbCantidadT.Size = New System.Drawing.Size(64, 23)
        Me.lbCantidadT.TabIndex = 63
        Me.lbCantidadT.Text = "lbCantidadT"
        '
        'lbCantidad
        '
        Me.lbCantidad.AutoSize = True
        Me.lbCantidad.Location = New System.Drawing.Point(80, 40)
        Me.lbCantidad.Name = "lbCantidad"
        Me.lbCantidad.Size = New System.Drawing.Size(57, 13)
        Me.lbCantidad.TabIndex = 64
        Me.lbCantidad.Text = "lbCantidad"
        '
        'chEnviarFactura
        '
        Me.chEnviarFactura.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chEnviarFactura.BackColor = System.Drawing.Color.Transparent
        Me.chEnviarFactura.Location = New System.Drawing.Point(10, 88)
        Me.chEnviarFactura.Name = "chEnviarFactura"
        Me.chEnviarFactura.Size = New System.Drawing.Size(112, 23)
        Me.chEnviarFactura.TabIndex = 68
        Me.chEnviarFactura.Text = "chEnviarFactura"
        Me.chEnviarFactura.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'RRepXMLFiltro
        '
        Me.AcceptButton = Me.btGuardar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btCancelar
        Me.ClientSize = New System.Drawing.Size(446, 158)
        Me.Controls.Add(Me.chEnviarFactura)
        Me.Controls.Add(Me.lbCantidad)
        Me.Controls.Add(Me.lbCantidadT)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lbTipo)
        Me.Controls.Add(Me.lbPregunta)
        Me.Controls.Add(Me.lbTipoT)
        Me.Controls.Add(Me.btGuardarComo)
        Me.Controls.Add(Me.btGuardar)
        Me.Controls.Add(Me.btCancelar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(452, 200)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(452, 160)
        Me.Name = "RRepXMLFiltro"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "RRepXMLFiltro"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private vcMensaje As New BASMENLOG.CMensaje
    Private vgFiltro As String
    Private bEnviarAdenda As Boolean

#Region "FUNCIONES GENERALES"

    Public Sub CargarForma(ByVal pvCantidad As Integer, Optional ByVal pvFiltro As String = "")
        iniciarpantalla()
        Me.lbCantidad.Text = pvCantidad & " Archivos"
        vgFiltro = pvFiltro
        Try

            Me.ShowDialog()
        Catch ex As LbControlError.cError
            ex.Mostrar()
            Me.Close()
        End Try
    End Sub

    Private Sub iniciarpantalla()
        Me.Text = vcMensaje.RecuperarDescripcion("XGuardarXML")
        Me.lbTipoT.Text = vcMensaje.RecuperarDescripcion("XTipo") & ": "
        Me.lbTipo.Text = vcMensaje.RecuperarDescripcion("XTipoXML")
        Me.lbCantidadT.Text = vcMensaje.RecuperarDescripcion("XCantidad") & ": "
        Me.lbPregunta.Text = vcMensaje.RecuperarDescripcion("XQueDesea")

        Me.btCancelar.Text = vcMensaje.RecuperarDescripcion("BtCancelar")
        Me.btCancelar.ToolTipText = vcMensaje.RecuperarDescripcion("BtCancelarT")
        Me.btGuardar.Text = vcMensaje.RecuperarDescripcion("BtGuardar")
        Me.btGuardar.ToolTipText = vcMensaje.RecuperarDescripcion("BtAceptarT")
        Me.btGuardarComo.Text = vcMensaje.RecuperarDescripcion("BtGuardarEn")
        Me.btGuardarComo.ToolTipText = vcMensaje.RecuperarDescripcion("BtGuardarEnT")

        Me.chEnviarFactura.Text = vcMensaje.RecuperarDescripcion("CEFEnviarAdenda")
        Me.chEnviarFactura.ToolTipText = vcMensaje.RecuperarDescripcion("CEFEnviarAdendaT")

        Me.chEnviarFactura.Checked = bEnviarAdenda
    End Sub

#End Region

#Region "BOTONES"

    Private Sub btCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCancelar.Click
        Me.Close()
    End Sub

    Private Sub btGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btGuardar.Click
        GuardarXmls("")
    End Sub

    Private Sub btGuardarComo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btGuardarComo.Click
        Dim oTransProd As New ERMTRPLOG.cTransProd
        Dim vlDirDocXML As String = oTransProd.obtenerDirDocXML(oTransProd.SubEmpresaId)
        Dim FBD As New FolderBrowserDialog
        FBD.SelectedPath = vlDirDocXML
        If FBD.ShowDialog() = Windows.Forms.DialogResult.OK Then
            GuardarXmls(FBD.SelectedPath)
        End If
    End Sub

    Private Sub GuardarXmls(ByVal RutaXml As String)
        'Cuando se quiere guardar en la ruta predefinida
        Dim bRutaConfigurado As Boolean = IIf(RutaXml.Length = 0, True, False)

        Dim oMensaje As New BASMENLOG.CMensaje
        Dim oTransProd As New ERMTRPLOG.cTransProd
        Dim bGenerado As Boolean = False
        Dim sArchivoError As String = ""
        Dim sArchivoErrorAddenda As String = String.Empty

        Dim cSubEmpresa As New ERMSEMLOG.cSubEmpresa()
        'Se obtienen todas el historial de las subempresas para seleccionar posteriormente la configuracion de acuerdo con la fecha facturacion
        Dim tablaSubEmpresa As DataTable = cSubEmpresa.RecuperarHistorialTodasSubEmpresas()

        Try
            'Por cada factura del filtro se genera el xml
            For Each row As DataRow In oTransProd.obtenerFacturasElectronicas(vgFiltro).Rows
                Dim vlTRP As New ERMTRPLOG.cTransProd
                Dim sError As String = ""
                vlTRP.Recuperar(row("TransProdID"))

                'De la coleccion del historial de configuracion de subempresas solo se obtienen el historico de la subempresa de la factura que la configuracion sea menor a la fechafactura de la factura
                Dim subempresas As DataRow() = tablaSubEmpresa.Select("SEMHistFechaInicio<'" + vlTRP.FechaFacturacion.ToString("yyyy-MM-ddTHH:mm:ss") + "' AND SubEmpresaId = '" + vlTRP.SubEmpresaId + "'", "SEMHistFechaInicio desc")
                Dim subempresa As DataRow
                'De la coleccion del historial de configruacion de subempresas se toma la actual
                Dim subempresaActual As DataRow = tablaSubEmpresa.Select("SubEmpresaId = '" + vlTRP.SubEmpresaId + "'", "SEMHistFechaInicio desc")(0)

                'Se selecciona la configuracion de acuerdo a la fecha de facturacion, para saber la version de la CFD
                If subempresas.Length = 0 Then
                    subempresa = subempresaActual
                Else
                    subempresa = subempresas(0)
                End If

                'Si se selecciona solo guardar se asigna la ruta configurada para la subempresa
                If bRutaConfigurado Then
                    RutaXml = subempresaActual!DirDocXML
                End If

                'De acuerdo a la version que le corresponde, se genera el XML
                If subempresa!VersionCFD = 1 Or subempresa!VersionCFD = 3 Then
                    bGenerado = bGenerado Or vlTRP.GenerarXML(vlTRP, RutaXml, True, sError, sArchivoErrorAddenda, chEnviarFactura.Checked)
                ElseIf subempresa!VersionCFD = 2 Or subempresa!VersionCFD = 4 Then
                    Dim cfdi As New ERMTRPLOG.CFDi
                    bGenerado = bGenerado Or vlTRP.GenerarXMLVersion3(vlTRP, RutaXml, True, sError, sArchivoErrorAddenda, cfdi, True, chEnviarFactura.Checked)

                End If
                If sError <> String.Empty Then
                    sArchivoError = sError
                End If
            Next
            If bGenerado AndAlso sArchivoError = String.Empty AndAlso sArchivoErrorAddenda = String.Empty Then
                MsgBox(oMensaje.RecuperarDescripcion("I0183"), MsgBoxStyle.Information, oMensaje.RecuperarDescripcion("XMensajeI"))
            End If
            If sArchivoError <> String.Empty Then
                MsgBox(oMensaje.RecuperarDescripcion("I0211", New String() {sArchivoError}), MsgBoxStyle.Information, oMensaje.RecuperarDescripcion("XMensajeI"))
            End If
            If sArchivoErrorAddenda <> String.Empty Then
                MsgBox(oMensaje.RecuperarDescripcion("I0212", New String() {sArchivoErrorAddenda}), MsgBoxStyle.Information, oMensaje.RecuperarDescripcion("XMensajeI"))
            End If
        Catch ex As LbControlError.cError
            ex.Mostrar()
            Exit Sub
        End Try

        'MsgBox(oMensaje.RecuperarDescripcion("I0183"), MsgBoxStyle.Information, oMensaje.RecuperarDescripcion("XMensajeP"))
        Me.Close()
    End Sub

#End Region
End Class
