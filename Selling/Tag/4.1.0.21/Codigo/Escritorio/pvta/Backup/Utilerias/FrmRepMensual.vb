Public Class FrmRepMensual
    Inherits System.Windows.Forms.Form

    Private Periodo As Integer
    Private Mes As Integer

    Private alerta(0) As PictureBox
    Private reloj As parpadea

    Friend WithEvents TxtDireccion As System.Windows.Forms.TextBox
    Friend WithEvents dtPicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox

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
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents LblClave As System.Windows.Forms.Label
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents GrpConfiguracion As System.Windows.Forms.GroupBox
    Friend WithEvents BtnEjecutar As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRepMensual))
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.GrpConfiguracion = New System.Windows.Forms.GroupBox
        Me.dtPicker = New System.Windows.Forms.DateTimePicker
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton
        Me.TxtDireccion = New System.Windows.Forms.TextBox
        Me.LblClave = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.BtnEjecutar = New Janus.Windows.EditControls.UIButton
        Me.GrpConfiguracion.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.BackColor = System.Drawing.SystemColors.Control
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BtnCancelar.Location = New System.Drawing.Point(246, 93)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 4
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GrpConfiguracion
        '
        Me.GrpConfiguracion.Controls.Add(Me.dtPicker)
        Me.GrpConfiguracion.Controls.Add(Me.PictureBox3)
        Me.GrpConfiguracion.Controls.Add(Me.BtnGuardar)
        Me.GrpConfiguracion.Controls.Add(Me.TxtDireccion)
        Me.GrpConfiguracion.Controls.Add(Me.LblClave)
        Me.GrpConfiguracion.Controls.Add(Me.Label3)
        Me.GrpConfiguracion.Location = New System.Drawing.Point(3, 5)
        Me.GrpConfiguracion.Name = "GrpConfiguracion"
        Me.GrpConfiguracion.Size = New System.Drawing.Size(429, 84)
        Me.GrpConfiguracion.TabIndex = 0
        Me.GrpConfiguracion.TabStop = False
        Me.GrpConfiguracion.Text = "Reporte Mensual"
        '
        'dtPicker
        '
        Me.dtPicker.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtPicker.CustomFormat = "MMMM yyyy"
        Me.dtPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtPicker.Location = New System.Drawing.Point(74, 18)
        Me.dtPicker.Name = "dtPicker"
        Me.dtPicker.ShowUpDown = True
        Me.dtPicker.Size = New System.Drawing.Size(184, 20)
        Me.dtPicker.TabIndex = 53
        '
        'PictureBox3
        '
        Me.PictureBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(371, 51)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox3.TabIndex = 44
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.ImageSize = New System.Drawing.Size(20, 20)
        Me.BtnGuardar.Location = New System.Drawing.Point(380, 44)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(33, 29)
        Me.BtnGuardar.TabIndex = 27
        '
        'TxtDireccion
        '
        Me.TxtDireccion.Location = New System.Drawing.Point(66, 51)
        Me.TxtDireccion.Name = "TxtDireccion"
        Me.TxtDireccion.ReadOnly = True
        Me.TxtDireccion.Size = New System.Drawing.Size(307, 20)
        Me.TxtDireccion.TabIndex = 25
        Me.TxtDireccion.TabStop = False
        '
        'LblClave
        '
        Me.LblClave.Location = New System.Drawing.Point(7, 51)
        Me.LblClave.Name = "LblClave"
        Me.LblClave.Size = New System.Drawing.Size(80, 15)
        Me.LblClave.TabIndex = 26
        Me.LblClave.Text = "Guardar en "
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(7, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 22)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Periodo"
        '
        'BtnEjecutar
        '
        Me.BtnEjecutar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEjecutar.Image = CType(resources.GetObject("BtnEjecutar.Image"), System.Drawing.Image)
        Me.BtnEjecutar.Location = New System.Drawing.Point(342, 93)
        Me.BtnEjecutar.Name = "BtnEjecutar"
        Me.BtnEjecutar.Size = New System.Drawing.Size(90, 37)
        Me.BtnEjecutar.TabIndex = 3
        Me.BtnEjecutar.Text = "Ejecutar"
        Me.BtnEjecutar.ToolTipText = "Genera Reporte Mensual para el SAT"
        Me.BtnEjecutar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmRepMensual
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(438, 134)
        Me.Controls.Add(Me.BtnEjecutar)
        Me.Controls.Add(Me.GrpConfiguracion)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmRepMensual"
        Me.Text = "Realizar Reporte Mensual"
        Me.GrpConfiguracion.ResumeLayout(False)
        Me.GrpConfiguracion.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private Function validaForm() As Boolean
        Dim i As Integer = 0

      
        If TxtDireccion.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
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

    Private Sub FrmRepMensual_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' 'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        alerta(0) = Me.PictureBox3

        If dtPicker.Value.Day > 28 Then
            Dim Dias As Integer = dtPicker.Value.Day
            dtPicker.Value = dtPicker.Value.AddDays(28 - Dias)
        End If

        Periodo = dtPicker.Value.Year()
        Mes = dtPicker.Value.Month

    End Sub

    Private Sub FrmRepMensual_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.RepMensual.Dispose()
        ModPOS.RepMensual = Nothing
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub


    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        Dim a As New System.Windows.Forms.FolderBrowserDialog
        If (a.ShowDialog() = DialogResult.OK) Then

            If a.SelectedPath.Length <= 3 Then
                TxtDireccion.Text = a.SelectedPath
            Else
                TxtDireccion.Text = a.SelectedPath
            End If
        End If
    End Sub

    Private Sub BtnEjecutar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnEjecutar.Click
        If validaForm() Then


            Dim frmStatusMessage As New frmStatus
            frmStatusMessage.Show("Generando Reporte Mensual...")

            If Mes = Today.Month AndAlso Periodo = Today.Year Then
                MessageBox.Show("No se puede generar el reporte mensual hasta el primer día del mes siguiente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                frmStatusMessage.Dispose()
                Exit Sub
            End If

            Dim NombreArchivo As String
            Dim eRFC As String
            Dim dt As DataTable


            Dim i As Integer

            dt = ModPOS.Recupera_Tabla("sp_consulta_cfd", "@Periodo", Periodo, "@Mes", Mes)

            If dt.Rows.Count > 0 Then
                For i = 0 To dt.Rows.Count - 1
                    If i = dt.Rows.Count - 1 Then
                        If dt.Rows(i)("Folio").GetType.Name = "DBNull" Then
                            'Elimina registro
                            ModPOS.Ejecuta("sp_elimina_cfd", _
                            "@Tipo", dt.Rows(i)("Tipo"), _
                            "@Clave", dt.Rows(i)("FACClave"))
                        ElseIf dt.Rows(i)("noAprobacion").GetType.Name = "DBNull" Then
                            MessageBox.Show("Error inesperado en el CFD: " & dt.Rows(i)("Serie") & dt.Rows(i)("Folio") & ". Debera ser regenerado, para lo cual entre a Utilerias\RegenerarCFD ", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            frmStatusMessage.Dispose()
                            Exit Sub
                        End If
                    Else
                        If dt.Rows(i)("Tipo") = dt.Rows(i + 1)("Tipo") Then
                            If dt.Rows(i)("Mes") = Mes Then
                                If dt.Rows(i)("Folio").GetType.Name = "DBNull" Then
                                    'Elimina registro

                                    ModPOS.Ejecuta("sp_elimina_cfd", _
                                    "@Tipo", dt.Rows(i)("Tipo"), _
                                    "@Clave", dt.Rows(i)("FACClave"))
                                ElseIf dt.Rows(i)("noAprobacion").GetType.Name = "DBNull" Then
                                    MessageBox.Show("Error inesperado en el CFD: " & dt.Rows(i)("Serie") & dt.Rows(i)("Folio") & ". Debera ser regenerado, para lo cual entre a Utilerias\RegenerarCFD ", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    frmStatusMessage.Dispose()
                                    Exit Sub
                                End If
                            End If
                        End If
                    End If
                Next
            End If

            dt.Dispose()

            dt = ModPOS.Recupera_Tabla("sp_consulta_cfd", "@Periodo", Periodo, "@Mes", Mes)

            If dt.Rows.Count > 0 Then
                For i = 0 To dt.Rows.Count - 2
                    If dt.Rows(i)("Tipo") = dt.Rows(i + 1)("Tipo") Then
                        If dt.Rows(i)("noAprobacion") = dt.Rows(i + 1)("noAprobacion") Then
                            If dt.Rows(i)("Serie") = dt.Rows(i + 1)("Serie") Then
                                If dt.Rows(i)("Folio") + 1 <> dt.Rows(i + 1)("Folio") Then
                                    ModPOS.Ejecuta("sp_cancela_cfd", _
                                                    "@Tipo", dt.Rows(i)("Tipo"), _
                                                    "@FACClave", dt.Rows(i)("FACClave"), _
                                                    "@Periodo", dt.Rows(i)("Periodo"), _
                                                    "@Mes", dt.Rows(i)("Mes"), _
                                                    "@Serie", dt.Rows(i)("Serie"), _
                                                    "@Folio", dt.Rows(i)("Folio") + 1, _
                                                    "@CAJClave", dt.Rows(i)("CAJClave"), _
                                                    "@CTEClave", dt.Rows(i)("CTEClave"), _
                                                    "@Facturo", dt.Rows(i)("Facturo"), _
                                                    "@FechaFactura", CDate(dt.Rows(i)("Fecha")).AddSeconds(3), _
                                                    "@noAprobacion", dt.Rows(i)("noAprobacion"), _
                                                    "@anoAprobacion", dt.Rows(i)("anoAprobacion"), _
                                                    "@formaDePago", dt.Rows(i)("formaDePago"), _
                                                    "@noCertificado", dt.Rows(i)("noCertificado"))
                                End If
                            End If
                        End If
                    End If
                Next
            End If

            dt.Dispose()

            dt = ModPOS.Recupera_Tabla("sp_recupera_compania", "@COMClave", ModPOS.CompanyActual)
            eRFC = dt.Rows(0)("id_Fiscal")
            dt.Dispose()


            NombreArchivo = "1" & eRFC & IIf(mes < 10, "0" & CStr(mes), CStr(mes)) & CStr(periodo) & ".txt"

            dt = ModPOS.Recupera_Tabla("sp_rep_mensual", "@Periodo", periodo, "@Mes", mes)

            If dt.Rows.Count > 0 Then
                Try



                    Dim file_stream As New System.IO.FileStream(TxtDireccion.Text & "\" & NombreArchivo, System.IO.FileMode.Create)
                    file_stream.Close()

                    Dim File2 As New System.IO.StreamWriter(TxtDireccion.Text & "\" & NombreArchivo)


                    For i = 0 To dt.Rows.Count - 1
                        File2.WriteLine("|" & dt.Rows(i)("RFC") & _
                                         "|" & dt.Rows(i)("Serie") & _
                                         "|" & dt.Rows(i)("Folio") & _
                                         "|" & dt.Rows(i)("noAprobacion") & _
                                         "|" & String.Format("{0:dd/MM/yyyy hh:mm:ss}", dt.Rows(i)("Fecha")) & _
                                         "|" & cFormat(CStr(Redondear(dt.Rows(i)("Total"), 2))) & _
                                         "|" & cFormat(CStr(Redondear(dt.Rows(i)("Impuesto"), 2))) & _
                                         "|" & dt.Rows(i)("Estado") & _
                                         "|" & dt.Rows(i)("Efecto") & _
                                         "|" & dt.Rows(i)("Pedimento") & _
                                         "|" & dt.Rows(i)("FechaPedimento") & _
                                         "|" & dt.Rows(i)("Aduana") & "|")
                    Next
                    File2.Close()


                    frmStatusMessage.Dispose()

                    MessageBox.Show("El archivo con el reporte mensual fue creado existosamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    MessageBox.Show("No olvides generar un respaldo de los Comprobantes Fiscales Digitales (CFD)", "Importante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                Catch ex As Exception
                    MessageBox.Show("Error", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Try
            Else
                frmStatusMessage.Dispose()
                MessageBox.Show("No fue posible crear el reporte mensual ya que no se encontraron comprobantes fiscales para el mes seleccionado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If


        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub dtPicker_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtPicker.ValueChanged
        Periodo = dtPicker.Value.Year()
        Mes = dtPicker.Value.Month
    End Sub
End Class
