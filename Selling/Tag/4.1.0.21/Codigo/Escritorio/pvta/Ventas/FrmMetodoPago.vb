Public Class FrmMetodoPago
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
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents GrpDenominaciones As System.Windows.Forms.GroupBox
    Friend WithEvents BtnAgregar As Janus.Windows.EditControls.UIButton
    Friend WithEvents GridMetodos As Janus.Windows.GridEX.GridEX
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMetodoPago))
        Me.GrpDenominaciones = New System.Windows.Forms.GroupBox
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton
        Me.GridMetodos = New Janus.Windows.GridEX.GridEX
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton
        Me.GrpDenominaciones.SuspendLayout()
        CType(Me.GridMetodos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpDenominaciones
        '
        Me.GrpDenominaciones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpDenominaciones.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpDenominaciones.Controls.Add(Me.BtnAgregar)
        Me.GrpDenominaciones.Controls.Add(Me.GridMetodos)
        Me.GrpDenominaciones.Location = New System.Drawing.Point(7, 11)
        Me.GrpDenominaciones.Name = "GrpDenominaciones"
        Me.GrpDenominaciones.Size = New System.Drawing.Size(618, 317)
        Me.GrpDenominaciones.TabIndex = 4
        Me.GrpDenominaciones.TabStop = False
        Me.GrpDenominaciones.Text = "Metodos de Pago"
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAgregar.Image = CType(resources.GetObject("BtnAgregar.Image"), System.Drawing.Image)
        Me.BtnAgregar.Location = New System.Drawing.Point(522, 15)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(90, 30)
        Me.BtnAgregar.TabIndex = 2
        Me.BtnAgregar.Text = "&Agregar"
        Me.BtnAgregar.ToolTipText = "Agrega nueva denominación de moneda"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GridMetodos
        '
        Me.GridMetodos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridMetodos.ColumnAutoResize = True
        Me.GridMetodos.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridMetodos.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridMetodos.Location = New System.Drawing.Point(7, 15)
        Me.GridMetodos.Name = "GridMetodos"
        Me.GridMetodos.RecordNavigator = True
        Me.GridMetodos.Size = New System.Drawing.Size(509, 294)
        Me.GridMetodos.TabIndex = 1
        Me.GridMetodos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.Location = New System.Drawing.Point(535, 334)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 2
        Me.BtnGuardar.Text = "&Aceptar"
        Me.BtnGuardar.ToolTipText = "Guardar cambios"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmMetodoPago
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(632, 377)
        Me.Controls.Add(Me.GrpDenominaciones)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmMetodoPago"
        Me.Text = "Metodo de Pago"
        Me.GrpDenominaciones.ResumeLayout(False)
        CType(Me.GridMetodos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public CTEClave As String
    Public FacturaId As String
    Public NCClave As String = ""
    Public MetodoPagoRows() As System.Data.DataRow
    Public NumCtaPago As String = ""
    Public MetodoDePago As String = ""
    Public bGlobal As Boolean = False
    Public VersionCF As String = "3.2"

    Private dtMetodosPago, dtMetodoCliente As DataTable
    Private sMetodoPago As String
    Private sTipoMetodo, sBanco, sReferencia As String
    Private bMetodoCliente As Boolean = False
    Private iPublicoGral As Integer = 0
    Private bError As Boolean = False

    Private Sub FrmMetodoPago_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If bError Then
            e.Cancel = True
        End If
    End Sub

    Public Sub AddMetodoPago(ByVal iMetodoPago As Integer, ByVal sTipo As String, ByVal sBancoClave As String, ByVal sBancoNombre As String, ByVal sRef As String, ByVal sSAT As String)

        Dim foundRows() As Data.DataRow
        Dim iNuevo As Integer = 1

        foundRows = dtMetodosPago.Select("MetodoPago = " & iMetodoPago & " and Referencia like '" & sRef & "' and ( BNKClave like '" & sBancoClave & "' or BNKClave is Null)")

        If foundRows.Length = 0 Then


            If bMetodoCliente = True Then
                foundRows = dtMetodoCliente.Select("MetodoPago = " & iMetodoPago & " and Referencia like '" & sRef & "' and ( BNKClave like '" & sBancoClave & "' or BNKClave is Null)")

                If foundRows.Length > 0 Then
                    iNuevo = 0
                End If

            End If

            Dim row1 As DataRow
            row1 = dtMetodosPago.NewRow()
            'declara el nombre de la fila
            row1.Item("Marca") = 1
            row1.Item("MetodoPago") = iMetodoPago
            row1.Item("Tipo") = sTipo
            row1.Item("BNKClave") = sBancoClave
            row1.Item("Banco") = sBancoNombre
            row1.Item("Referencia") = sRef
            row1.Item("Nuevo") = iNuevo
            row1.Item("SAT") = sSAT
            dtMetodosPago.Rows.Add(row1)
            'agrega la fila completo a la tabla

        Else
            Beep()
            MessageBox.Show("¡La referencia de Metodo de Pago que intenta agregar ya existe para el cliente actual!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub cargaMetodosPago()

        Dim dt As DataTable
        dt = ModPOS.Recupera_Tabla("sp_valida_publicogral", "@CTEClave", CTEClave)
        iPublicoGral = dt.Rows(0)("Publico")
        dt.Dispose()

        If FacturaId <> "" AndAlso bGlobal = False Then
            dtMetodosPago = ModPOS.SiExisteRecupera("sp_metodospago_aplicados", "@idFactura", FacturaId)
        End If

        If dtMetodosPago Is Nothing Then
            dtMetodosPago = ModPOS.Recupera_Tabla("sp_recupera_metodospago_cte", "@CTEClave", CTEClave)
        Else
            dtMetodoCliente = ModPOS.Recupera_Tabla("sp_recupera_metodospago_cte", "@CTEClave", CTEClave)
            bMetodoCliente = True
        End If

        With Me.GridMetodos
            .DataSource = dtMetodosPago
            .RetrieveStructure(True)
            .GroupByBoxVisible = False
            .RootTable.Columns("MetodoPago").Visible = False
            .RootTable.Columns("BNKClave").Visible = False
            .RootTable.Columns("Nuevo").Visible = False
            .RootTable.Columns("SAT").Visible = False
            .CurrentTable.Columns("Tipo").Selectable = False
            .CurrentTable.Columns("Banco").Selectable = False
            .CurrentTable.Columns("Referencia").Selectable = False
        End With
    End Sub

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        Dim a As New FrmAddMetodoPago
        a.FormOrigen = "MetodoPago"
        a.Padre = "Agregar"
        a.ShowDialog()
    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        Dim foundRows() As System.Data.DataRow

        If Me.GridMetodos.RecordCount > 0 Then
            foundRows = dtMetodosPago.Select(" Marca = 1 ")

            Dim z As Integer

            If foundRows.Length >= 1 Then

                If VersionCF = "3.3" AndAlso foundRows.Length > 1 Then
                    bError = True
                    Me.DialogResult = DialogResult.Cancel
                    Beep()
                    MessageBox.Show("Debe seleccionar solo el Metodo de Pago con el que se liquida la mayor cantidad del documento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                If FacturaId = "" And NCClave <> "" Then
                    'Inserta Metodo Pago para Nota de Crédito
                    MetodoPagoRows = foundRows
                Else

                    Dim Referencia, Banco, Tipo, SAT As String

                    For z = 0 To foundRows.GetUpperBound(0)

                        Referencia = IIf(foundRows(z)("Referencia").GetType.Name = "DBNull", "", CStr(foundRows(z)("Referencia")).Trim.ToUpper)
                        Banco = IIf(foundRows(z)("Banco").GetType.Name = "DBNull", "", foundRows(z)("Banco"))
                        Tipo = IIf(foundRows(z)("Tipo").GetType.Name = "DBNull", "", foundRows(z)("Tipo"))
                        SAT = IIf(foundRows(z)("SAT").GetType.Name = "DBNull", "99", foundRows(z)("SAT"))

                        ModPOS.Ejecuta("sp_agregar_metodopagofac", _
                        "@FacturaID", Me.FacturaId, _
                        "@MetodoPago", Tipo, _
                        "@Banco", Banco, _
                        "@SAT", SAT, _
                        "@Referencia", Referencia)

                        If VersionCF <> "3.3" Then
                            If z > 0 Then
                                MetodoDePago &= ","

                                'If NumCtaPago <> "" AndAlso Referencia <> "" Then
                                '    NumCtaPago &= ","
                                'End If
                            End If

                            ' MetodoDePago &= Tipo & " " & Banco
                            MetodoDePago &= SAT
                            NumCtaPago &= Referencia
                        ElseIf z = 0 Then
                            MetodoDePago &= SAT
                            NumCtaPago &= Referencia
                        End If

                    Next


                    foundRows = dtMetodosPago.Select(" Marca = 1 and Nuevo = 1 ")

                    If foundRows.Length <> 0 Then

                        If iPublicoGral > 0 Then

                            ' si es un cliente generico o publico general

                            For z = 0 To foundRows.GetUpperBound(0)
                                If foundRows(z)("MetodoPago") = 1 Then
                                    ModPOS.Ejecuta("sp_inserta_clientepago", _
                                    "@MTPClave", ModPOS.obtenerLlave, _
                                    "@CTEClave", CTEClave, _
                                    "@MetodoPago", foundRows(z)("MetodoPago"), _
                                    "@BNKClave", foundRows(z)("BNKClave"), _
                                    "@Referencia", CStr(foundRows(z)("Referencia")).Trim.ToUpper, _
                                    "@Preferido", 0, _
                                    "@Estado", 1, _
                                    "@Usuario", ModPOS.UsuarioActual)
                                End If
                            Next
                        Else
                            ' Si es un cliente convencional
                            For z = 0 To foundRows.GetUpperBound(0)
                                ModPOS.Ejecuta("sp_inserta_clientepago", _
                                    "@MTPClave", ModPOS.obtenerLlave, _
                                    "@CTEClave", CTEClave, _
                                    "@MetodoPago", foundRows(z)("MetodoPago"), _
                                    "@BNKClave", foundRows(z)("BNKClave"), _
                                    "@Referencia", CStr(foundRows(z)("Referencia")).Trim.ToUpper, _
                                    "@Preferido", 0, _
                                    "@Estado", 1, _
                                    "@Usuario", ModPOS.UsuarioActual)
                            Next
                        End If
                    End If

                End If

                bError = False
                Me.DialogResult = DialogResult.OK
                Me.Close()


            Else
                bError = True
                Me.DialogResult = DialogResult.Cancel
                Beep()
                MessageBox.Show("Debe seleccionar al menos un Metodo de Pago", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

        Else
            bError = True
            Me.DialogResult = DialogResult.Cancel
            Beep()
            MessageBox.Show("¡Debe agregar y seleccionar al menos una Metodo de Pago!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub FrmMetodoPago_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.cargaMetodosPago()
    End Sub
End Class
