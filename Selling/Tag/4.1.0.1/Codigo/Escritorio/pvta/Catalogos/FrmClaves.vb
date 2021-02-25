Public Class FrmClaves
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
    Friend WithEvents GrpCliente As System.Windows.Forms.GroupBox
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnBuscaProd As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtProducto As System.Windows.Forms.TextBox
    Friend WithEvents grpProductos As System.Windows.Forms.GroupBox
    Friend WithEvents gridProductos As Janus.Windows.GridEX.GridEX
    Friend WithEvents btnDelCliente As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtBusqueda As System.Windows.Forms.TextBox
    Friend WithEvents lblRFC As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents BtnBuscaCte As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtRazonSocial As System.Windows.Forms.TextBox
    Friend WithEvents lblBuscar As System.Windows.Forms.Label
    Friend WithEvents TxtClave As System.Windows.Forms.TextBox
    Friend WithEvents BtnAgregar As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmClaves))
        Me.GrpCliente = New System.Windows.Forms.GroupBox()
        Me.TxtBusqueda = New System.Windows.Forms.TextBox()
        Me.lblRFC = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.BtnBuscaCte = New Janus.Windows.EditControls.UIButton()
        Me.TxtRazonSocial = New System.Windows.Forms.TextBox()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.TxtClave = New System.Windows.Forms.TextBox()
        Me.btnDelCliente = New Janus.Windows.EditControls.UIButton()
        Me.grpProductos = New System.Windows.Forms.GroupBox()
        Me.gridProductos = New Janus.Windows.GridEX.GridEX()
        Me.BtnBuscaProd = New Janus.Windows.EditControls.UIButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtProducto = New System.Windows.Forms.TextBox()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton()
        Me.GrpCliente.SuspendLayout()
        Me.grpProductos.SuspendLayout()
        CType(Me.gridProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpCliente
        '
        Me.GrpCliente.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpCliente.Controls.Add(Me.TxtBusqueda)
        Me.GrpCliente.Controls.Add(Me.lblRFC)
        Me.GrpCliente.Controls.Add(Me.Label11)
        Me.GrpCliente.Controls.Add(Me.BtnBuscaCte)
        Me.GrpCliente.Controls.Add(Me.TxtRazonSocial)
        Me.GrpCliente.Controls.Add(Me.lblBuscar)
        Me.GrpCliente.Controls.Add(Me.TxtClave)
        Me.GrpCliente.Controls.Add(Me.btnDelCliente)
        Me.GrpCliente.Controls.Add(Me.grpProductos)
        Me.GrpCliente.Controls.Add(Me.BtnBuscaProd)
        Me.GrpCliente.Controls.Add(Me.Label3)
        Me.GrpCliente.Controls.Add(Me.TxtProducto)
        Me.GrpCliente.Location = New System.Drawing.Point(4, 3)
        Me.GrpCliente.Name = "GrpCliente"
        Me.GrpCliente.Size = New System.Drawing.Size(757, 503)
        Me.GrpCliente.TabIndex = 0
        Me.GrpCliente.TabStop = False
        Me.GrpCliente.Text = "Cliente"
        '
        'TxtBusqueda
        '
        Me.TxtBusqueda.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.TxtBusqueda.Location = New System.Drawing.Point(84, 20)
        Me.TxtBusqueda.Name = "TxtBusqueda"
        Me.TxtBusqueda.Size = New System.Drawing.Size(141, 21)
        Me.TxtBusqueda.TabIndex = 115
        '
        'lblRFC
        '
        Me.lblRFC.Location = New System.Drawing.Point(10, 49)
        Me.lblRFC.Name = "lblRFC"
        Me.lblRFC.Size = New System.Drawing.Size(60, 15)
        Me.lblRFC.TabIndex = 114
        Me.lblRFC.Text = "Cliente"
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(9, 74)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(75, 20)
        Me.Label11.TabIndex = 113
        Me.Label11.Text = "Razón Social"
        '
        'BtnBuscaCte
        '
        Me.BtnBuscaCte.Image = CType(resources.GetObject("BtnBuscaCte.Image"), System.Drawing.Image)
        Me.BtnBuscaCte.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnBuscaCte.Location = New System.Drawing.Point(237, 19)
        Me.BtnBuscaCte.Name = "BtnBuscaCte"
        Me.BtnBuscaCte.Size = New System.Drawing.Size(58, 24)
        Me.BtnBuscaCte.TabIndex = 109
        Me.BtnBuscaCte.ToolTipText = "Busqueda de Cliente"
        Me.BtnBuscaCte.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtRazonSocial
        '
        Me.TxtRazonSocial.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtRazonSocial.Enabled = False
        Me.TxtRazonSocial.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRazonSocial.Location = New System.Drawing.Point(84, 71)
        Me.TxtRazonSocial.Multiline = True
        Me.TxtRazonSocial.Name = "TxtRazonSocial"
        Me.TxtRazonSocial.ReadOnly = True
        Me.TxtRazonSocial.Size = New System.Drawing.Size(511, 23)
        Me.TxtRazonSocial.TabIndex = 110
        '
        'lblBuscar
        '
        Me.lblBuscar.Location = New System.Drawing.Point(10, 25)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(53, 15)
        Me.lblBuscar.TabIndex = 112
        Me.lblBuscar.Text = "Buscar"
        '
        'TxtClave
        '
        Me.TxtClave.Enabled = False
        Me.TxtClave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtClave.Location = New System.Drawing.Point(84, 47)
        Me.TxtClave.Name = "TxtClave"
        Me.TxtClave.ReadOnly = True
        Me.TxtClave.Size = New System.Drawing.Size(186, 21)
        Me.TxtClave.TabIndex = 111
        '
        'btnDelCliente
        '
        Me.btnDelCliente.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelCliente.Icon = CType(resources.GetObject("btnDelCliente.Icon"), System.Drawing.Icon)
        Me.btnDelCliente.Location = New System.Drawing.Point(689, 118)
        Me.btnDelCliente.Name = "btnDelCliente"
        Me.btnDelCliente.Size = New System.Drawing.Size(62, 30)
        Me.btnDelCliente.TabIndex = 108
        Me.btnDelCliente.ToolTipText = "Elimina terminal de cobro seleccionada"
        Me.btnDelCliente.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'grpProductos
        '
        Me.grpProductos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpProductos.BackColor = System.Drawing.Color.Transparent
        Me.grpProductos.Controls.Add(Me.gridProductos)
        Me.grpProductos.Location = New System.Drawing.Point(8, 147)
        Me.grpProductos.Name = "grpProductos"
        Me.grpProductos.Size = New System.Drawing.Size(743, 350)
        Me.grpProductos.TabIndex = 106
        Me.grpProductos.TabStop = False
        Me.grpProductos.Text = "Claves"
        '
        'gridProductos
        '
        Me.gridProductos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridProductos.ColumnAutoResize = True
        Me.gridProductos.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.gridProductos.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.gridProductos.GroupByBoxVisible = False
        Me.gridProductos.Location = New System.Drawing.Point(7, 15)
        Me.gridProductos.Name = "gridProductos"
        Me.gridProductos.RecordNavigator = True
        Me.gridProductos.Size = New System.Drawing.Size(731, 328)
        Me.gridProductos.TabIndex = 1
        Me.gridProductos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnBuscaProd
        '
        Me.BtnBuscaProd.Image = CType(resources.GetObject("BtnBuscaProd.Image"), System.Drawing.Image)
        Me.BtnBuscaProd.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnBuscaProd.Location = New System.Drawing.Point(237, 117)
        Me.BtnBuscaProd.Name = "BtnBuscaProd"
        Me.BtnBuscaProd.Size = New System.Drawing.Size(58, 24)
        Me.BtnBuscaProd.TabIndex = 103
        Me.BtnBuscaProd.ToolTipText = "Busqueda de Producto"
        Me.BtnBuscaProd.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(9, 123)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 15)
        Me.Label3.TabIndex = 104
        Me.Label3.Text = "Producto"
        '
        'TxtProducto
        '
        Me.TxtProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtProducto.Location = New System.Drawing.Point(84, 118)
        Me.TxtProducto.Name = "TxtProducto"
        Me.TxtProducto.Size = New System.Drawing.Size(141, 21)
        Me.TxtProducto.TabIndex = 101
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Icon = CType(resources.GetObject("BtnCancelar.Icon"), System.Drawing.Icon)
        Me.BtnCancelar.Location = New System.Drawing.Point(575, 512)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 2
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAgregar.Icon = CType(resources.GetObject("BtnAgregar.Icon"), System.Drawing.Icon)
        Me.BtnAgregar.Location = New System.Drawing.Point(671, 512)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(90, 37)
        Me.BtnAgregar.TabIndex = 1
        Me.BtnAgregar.Text = "&Aceptar"
        Me.BtnAgregar.ToolTipText = "Guardar cambios"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmClaves
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(767, 557)
        Me.Controls.Add(Me.BtnAgregar)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.GrpCliente)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmClaves"
        Me.Text = "Claves de Cliente"
        Me.GrpCliente.ResumeLayout(False)
        Me.GrpCliente.PerformLayout()
        Me.grpProductos.ResumeLayout(False)
        CType(Me.gridProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Padre As String
    Public CTEClave As String

    Private dtClaves As DataTable
    Private sProductoSelected, sClaveCte As String

    Private Sub FrmClaves_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.Claves.Dispose()
        ModPOS.Claves = Nothing
    End Sub

    Public Sub CargaDatosCliente(ByVal sCTEClave As String)
        Dim dt As DataTable = ModPOS.SiExisteRecupera("sp_recupera_cliente", "@CTEClave", sCTEClave)
        If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
            TxtClave.Text = dt.Rows(0)("Clave")
            TxtRazonSocial.Text = dt.Rows(0)("NombreCorto")
            dt.Dispose()
        Else
            MessageBox.Show("La información del cliente no exite o se encuentra incompleta", "Información", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub leeCodigoBarras(ByVal Codigo As String)
        If Not Codigo = vbNullString Then
            'Busca y recupera los datos del producto

            Dim dtProducto As DataTable = ModPOS.SiExisteRecupera("sp_portafolio_producto", "@Busca", Codigo.Replace("'", "''"), "@COMClave", ModPOS.CompanyActual)
            If Not dtProducto Is Nothing AndAlso dtProducto.Rows.Count > 0 Then

                Dim sProducto, sClave, sNombre As String
                
                sProducto = dtProducto.Rows(0)("PROClave")
                sClave = dtProducto.Rows(0)("Clave")
                sNombre = dtProducto.Rows(0)("Nombre")
               
                dtProducto.Dispose()

                Dim foundRows() As System.Data.DataRow
                foundRows = dtClaves.Select(" PROClave = '" & sProducto & "' and Baja = 0 ")
                If foundRows.GetLength(0) = 0 Then

                    Dim row1 As DataRow
                    row1 = dtClaves.NewRow()
                    'Valor,Descripcion,Orden,0 as Modificado,Baja 
                    row1.Item("CMClave") = obtenerLlave()
                    row1.Item("PROClave") = sProducto
                    row1.Item("ClaveCliente") = ""
                    row1.Item("Clave") = sClave
                    row1.Item("Nombre") = sNombre
                    row1.Item("Modificado") = 1
                    row1.Item("Baja") = 0
                    dtClaves.Rows.Add(row1)

                Else

                    Beep()
                    MessageBox.Show("La Clave o Código de Barras ya se encuentra en el listado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If

            Else

                Beep()
                MessageBox.Show("La Clave o Código de Barras no esta registrada o esta inactiva", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            End If
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        If dtClaves.Rows.Count > 0 Then




            Dim i As Integer
            Dim foundRows() As DataRow

            foundRows = dtClaves.Select("ClaveCliente = '' and Baja = 0 and Modificado= 1")
            If foundRows.GetLength(0) > 0 Then
                MessageBox.Show("Se encontraron Clave de Cliente vacias", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

             Select Me.Padre
                Case "Agregar"


                    foundRows = dtClaves.Select("Baja = 0")

                    If foundRows.GetLength(0) > 0 Then
                        For i = 0 To foundRows.GetUpperBound(0)

                            ModPOS.Ejecuta("st_inserta_claves_cte", _
                                                  "@CTEClave", CTEClave, _
                                                  "@CMClave", foundRows(i)("CMClave"), _
                                                  "@PROClave", foundRows(i)("PROClave"), _
                                                  "@Clave", foundRows(i)("ClaveCliente"), _
                                                  "@Baja", foundRows(i)("Baja"), _
                                                  "@Usuario", ModPOS.UsuarioActual)

                        Next
                    End If



                Case "Modificar"

                    foundRows = dtClaves.Select("Modificado = 1")

                    If foundRows.GetLength(0) > 0 Then
                        For i = 0 To foundRows.GetUpperBound(0)

                           ModPOS.Ejecuta("st_inserta_claves_cte", _
                                                   "@CTEClave", CTEClave, _
                                                   "@CMClave", foundRows(i)("CMClave"), _
                                                   "@PROClave", foundRows(i)("PROClave"), _
                                                   "@Clave", foundRows(i)("ClaveCliente"), _
                                                   "@Baja", foundRows(i)("Baja"), _
                                                   "@Usuario", ModPOS.UsuarioActual)

                        Next
                    End If
                    If Not ModPOS.MtoClaves Is Nothing Then
                        ModPOS.ActualizaGrid(False, ModPOS.MtoClaves.GridClaves, "st_muestra_claves_cte", "@COMClave", ModPOS.CompanyActual)
                        ModPOS.MtoClaves.GridClaves.RootTable.Columns("CTEClave").Visible = False
                    End If

                    Me.Close()
            End Select

        Else
            MessageBox.Show("Debe especificar un producto, escribiendo la clave de producto, codigo de barras o mediante la opción de buscar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub BtnBuscaProd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscaProd.Click
        Dim a As New MeSearch
        a.ProcedimientoAlmacenado = "sp_search_prod"
        a.bReplace = True
        a.TablaCmb = "Producto"
        a.CampoCmb = "Filtro"
        a.NumColDes = 2
        a.CompaniaRequerido = True
        a.BusquedaInicial = True
        a.Busqueda = TxtProducto.Text
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            TxtProducto.Text = a.valor
            leeCodigoBarras(a.valor)
        End If
        a.Dispose()
    End Sub

    Private Sub FrmClaves_Load(sender As Object, e As EventArgs) Handles MyBase.Load



        If Padre = "Modificar" Then
            lblBuscar.Visible = False
            BtnBuscaCte.Visible = False
            TxtBusqueda.Visible = False
            CargaDatosCliente(CTEClave)

            dtClaves = ModPOS.Recupera_Tabla("st_recupera_claves_cte", "@CTEClave", CTEClave)

        Else


            dtClaves = ModPOS.CrearTabla("ClienteMaterial", _
           "CMClave", "System.String", _
           "PROClave", "System.String", _
           "ClaveCliente", "System.String", _
           "Clave", "System.String", _
           "Nombre", "System.String",
           "Modificado", "System.Int32", _
          "Baja", "System.Int32")

        End If

        gridProductos.DataSource = dtClaves
        gridProductos.RetrieveStructure(True)
        gridProductos.GroupByBoxVisible = False
        gridProductos.RootTable.Columns("CMClave").Visible = False
        gridProductos.RootTable.Columns("PROClave").Visible = False
        gridProductos.RootTable.Columns("Modificado").Visible = False
        gridProductos.CurrentTable.Columns("Baja").Visible = False
      
        Dim fccl As Janus.Windows.GridEX.GridEXFormatCondition
        fccl = New Janus.Windows.GridEX.GridEXFormatCondition(gridProductos.RootTable.Columns("Baja"), Janus.Windows.GridEX.ConditionOperator.Equal, 1)
        fccl.FormatStyle.FontStrikeout = Janus.Windows.GridEX.TriState.True
        fccl.FormatStyle.ForeColor = System.Drawing.SystemColors.GrayText
        gridProductos.RootTable.FormatConditions.Add(fccl)


    End Sub

    Private Sub BtnBuscaCte_Click(sender As Object, e As EventArgs) Handles BtnBuscaCte.Click
        Dim a As New MeSearch
        a.ProcedimientoAlmacenado = "sp_search_cliente"
        a.TablaCmb = "Cliente"
        a.CampoCmb = "Filtro"
        a.OcultaID = True
        a.CompaniaRequerido = True
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            If Not a.valor Is Nothing Then
                CTEClave = a.valor
                CargaDatosCliente(CTEClave)
            End If
        End If
        a.Dispose()
    End Sub

    Private Sub TxtBusqueda_KeyUp(sender As Object, e As KeyEventArgs) Handles TxtBusqueda.KeyUp
        Select Case e.KeyCode
            Case Is = Keys.Enter
                If TxtBusqueda.Text <> "" Then
                    Dim dtCliente As DataTable
                    dtCliente = ModPOS.SiExisteRecupera("sp_consulta_clientedomicilio", "@Cliente", TxtBusqueda.Text.Trim.ToUpper.Replace("'", "''"), "@COMClave", ModPOS.CompanyActual)
                    If Not dtCliente Is Nothing AndAlso dtCliente.Rows.Count > 0 Then
                        CTEClave = dtCliente.Rows(0)("CTEClave")
                        dtCliente.Dispose()
                        CargaDatosCliente(CTEClave)
                    End If
                End If
            Case Is = Keys.Right

                Dim a As New MeSearch
                a.ProcedimientoAlmacenado = "sp_search_cliente"
                a.TablaCmb = "Cliente"
                a.CampoCmb = "Filtro"
                a.OcultaID = True
                a.BusquedaInicial = True
                a.CompaniaRequerido = True
                a.Busqueda = TxtBusqueda.Text.Trim.ToUpper
                a.ShowDialog()
                If a.DialogResult = DialogResult.OK Then
                    If Not a.valor Is Nothing Then
                        CTEClave = a.valor
                        CargaDatosCliente(CTEClave)
                    End If
                End If
                a.Dispose()
        End Select
    End Sub

    Private Sub TxtProducto_KeyUp(sender As Object, e As KeyEventArgs) Handles TxtProducto.KeyUp
        Select Case e.KeyCode
            Case Is = Keys.Enter
                   leeCodigoBarras(TxtProducto.Text.Trim.ToUpper.Replace("'", "''"))
            Case Is = Keys.Right

                Dim a As New MeSearch
                a.ProcedimientoAlmacenado = "sp_search_prod"
                a.bReplace = True
                a.TablaCmb = "Producto"
                a.CampoCmb = "Filtro"
                a.NumColDes = 2
                a.CompaniaRequerido = True
                a.BusquedaInicial = True
                a.Busqueda = TxtProducto.Text.Trim.ToUpper
                a.ShowDialog()
                If a.DialogResult = DialogResult.OK Then
                    TxtProducto.Text = a.valor
                    leeCodigoBarras(a.valor)
                End If
                a.Dispose()

              
        End Select
    End Sub

    Private Sub gridProductos_CellEdited(sender As Object, e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles gridProductos.CellEdited
        Select Case gridProductos.CurrentColumn.Caption
            Case "Clave Cliente"
                If gridProductos.GetValue("ClaveCliente").GetType.Name = "DBNull" OrElse CStr(gridProductos.GetValue("ClaveCliente")).Length = 0 Then
                    gridProductos.SetValue("ClaveCliente", "ERROR")
                    gridProductos.SetValue("Modificado", 0)
                Else
                    Dim foundRows() As System.Data.DataRow
                    foundRows = dtClaves.Select(" CMClave <> '" & gridProductos.GetValue("CMClave") & "' and Baja = 0 and ClaveCliente = '" & CStr(gridProductos.GetValue("ClaveCliente")).Trim & "'")
                    If foundRows.GetLength(0) > 0 Then
                        MessageBox.Show("¡La Clave que intenta agregar ya existe!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        gridProductos.SetValue("ClaveCliente", "ERROR")
                        gridProductos.SetValue("Modificado", 0)
                    Else
                        gridProductos.SetValue("ClaveCliente", CStr(gridProductos.GetValue("ClaveCliente")).Trim)
                        gridProductos.SetValue("Modificado", 1)
                    End If
                End If

        End Select
    End Sub

    Private Sub btnDelCliente_Click(sender As Object, e As EventArgs) Handles btnDelCliente.Click
        If sProductoSelected <> "" Then
            Beep()
            Select Case MessageBox.Show("Se eliminara la terminal de cobro :" & sClaveCte, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes

                    Dim foundRows() As System.Data.DataRow
                    foundRows = dtClaves.Select(" CMClave = '" & sProductoSelected & "'")
                    foundRows(0)("Baja") = 1

            End Select
        End If
    End Sub

    Private Sub gridProductos_SelectionChanged(sender As Object, e As EventArgs) Handles gridProductos.SelectionChanged
        If Not gridProductos.GetValue(0) Is Nothing Then
            Me.btnDelCliente.Enabled = True
            Me.sProductoSelected = gridProductos.GetValue("CMClave")
            Me.sClaveCte = gridProductos.GetValue("Clave")
        Else
            Me.btnDelCliente.Enabled = False
            Me.sProductoSelected = ""
            Me.sClaveCte = ""
        End If
    End Sub
End Class
