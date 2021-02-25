Imports CrystalDecisions.CrystalReports.Engine

Public Class FrmConfirmacion
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
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents GrpGeneral As System.Windows.Forms.GroupBox
    Friend WithEvents GrpDetalle As System.Windows.Forms.GroupBox
    Friend WithEvents GridDetalle As Janus.Windows.GridEX.GridEX
    Friend WithEvents BtnBuscaProd As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtProducto As System.Windows.Forms.TextBox
    Friend WithEvents TxtCantidad As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents lblFolio As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtNotas As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LblEstado As System.Windows.Forms.Label
    Friend WithEvents cmbURecibo As Selling.StoreCombo
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnDel As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtDoc As System.Windows.Forms.TextBox
    Friend WithEvents BtnBuscaDoc As Janus.Windows.EditControls.UIButton
    Friend WithEvents GridDoctos As Janus.Windows.GridEX.GridEX
    Friend WithEvents TxtOrigen As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmConfirmacion))
        Me.GrpGeneral = New System.Windows.Forms.GroupBox
        Me.TxtOrigen = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmbURecibo = New Selling.StoreCombo
        Me.Label8 = New System.Windows.Forms.Label
        Me.TxtNotas = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton
        Me.GrpDetalle = New System.Windows.Forms.GroupBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.TxtCantidad = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.BtnBuscaProd = New Janus.Windows.EditControls.UIButton
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtProducto = New System.Windows.Forms.TextBox
        Me.GridDetalle = New Janus.Windows.GridEX.GridEX
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.LblEstado = New System.Windows.Forms.Label
        Me.lblFecha = New System.Windows.Forms.Label
        Me.lblFolio = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.BtnDel = New Janus.Windows.EditControls.UIButton
        Me.TxtDoc = New System.Windows.Forms.TextBox
        Me.BtnBuscaDoc = New Janus.Windows.EditControls.UIButton
        Me.GridDoctos = New Janus.Windows.GridEX.GridEX
        Me.GrpGeneral.SuspendLayout()
        Me.GrpDetalle.SuspendLayout()
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.GridDoctos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpGeneral
        '
        Me.GrpGeneral.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpGeneral.Controls.Add(Me.TxtOrigen)
        Me.GrpGeneral.Controls.Add(Me.Label2)
        Me.GrpGeneral.Controls.Add(Me.cmbURecibo)
        Me.GrpGeneral.Controls.Add(Me.Label8)
        Me.GrpGeneral.Controls.Add(Me.TxtNotas)
        Me.GrpGeneral.Controls.Add(Me.Label1)
        Me.GrpGeneral.Location = New System.Drawing.Point(7, 4)
        Me.GrpGeneral.Name = "GrpGeneral"
        Me.GrpGeneral.Size = New System.Drawing.Size(611, 129)
        Me.GrpGeneral.TabIndex = 2
        Me.GrpGeneral.TabStop = False
        Me.GrpGeneral.Text = "Datos Generales"
        '
        'TxtOrigen
        '
        Me.TxtOrigen.Enabled = False
        Me.TxtOrigen.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtOrigen.Location = New System.Drawing.Point(119, 16)
        Me.TxtOrigen.Name = "TxtOrigen"
        Me.TxtOrigen.Size = New System.Drawing.Size(385, 21)
        Me.TxtOrigen.TabIndex = 134
        '
        'Label2
        '
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(11, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(102, 15)
        Me.Label2.TabIndex = 128
        Me.Label2.Text = "Ubicación Recibo"
        '
        'cmbURecibo
        '
        Me.cmbURecibo.BackColor = System.Drawing.SystemColors.Window
        Me.cmbURecibo.Location = New System.Drawing.Point(119, 70)
        Me.cmbURecibo.Name = "cmbURecibo"
        Me.cmbURecibo.Size = New System.Drawing.Size(221, 21)
        Me.cmbURecibo.TabIndex = 129
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(11, 49)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(67, 15)
        Me.Label8.TabIndex = 133
        Me.Label8.Text = "Comentarios"
        '
        'TxtNotas
        '
        Me.TxtNotas.Enabled = False
        Me.TxtNotas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNotas.Location = New System.Drawing.Point(119, 43)
        Me.TxtNotas.Name = "TxtNotas"
        Me.TxtNotas.Size = New System.Drawing.Size(385, 21)
        Me.TxtNotas.TabIndex = 130
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(11, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 15)
        Me.Label1.TabIndex = 131
        Me.Label1.Text = "Origen"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(599, 552)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 5
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.Location = New System.Drawing.Point(695, 551)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 4
        Me.BtnGuardar.Text = "&Aceptar"
        Me.BtnGuardar.ToolTipText = "Guardar cambios"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GrpDetalle
        '
        Me.GrpDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpDetalle.Controls.Add(Me.Label13)
        Me.GrpDetalle.Controls.Add(Me.TxtCantidad)
        Me.GrpDetalle.Controls.Add(Me.Label5)
        Me.GrpDetalle.Controls.Add(Me.BtnBuscaProd)
        Me.GrpDetalle.Controls.Add(Me.Label3)
        Me.GrpDetalle.Controls.Add(Me.TxtProducto)
        Me.GrpDetalle.Controls.Add(Me.GridDetalle)
        Me.GrpDetalle.Location = New System.Drawing.Point(168, 138)
        Me.GrpDetalle.Name = "GrpDetalle"
        Me.GrpDetalle.Size = New System.Drawing.Size(617, 408)
        Me.GrpDetalle.TabIndex = 1
        Me.GrpDetalle.TabStop = False
        Me.GrpDetalle.Text = "Detalle"
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(65, 40)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(21, 15)
        Me.Label13.TabIndex = 127
        Me.Label13.Text = "X"
        '
        'TxtCantidad
        '
        Me.TxtCantidad.Location = New System.Drawing.Point(7, 36)
        Me.TxtCantidad.Name = "TxtCantidad"
        Me.TxtCantidad.Size = New System.Drawing.Size(53, 20)
        Me.TxtCantidad.TabIndex = 1
        Me.TxtCantidad.Text = "1.00"
        Me.TxtCantidad.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtCantidad.Value = 1
        Me.TxtCantidad.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(7, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 16)
        Me.Label5.TabIndex = 100
        Me.Label5.Text = "Cantidad"
        '
        'BtnBuscaProd
        '
        Me.BtnBuscaProd.Image = CType(resources.GetObject("BtnBuscaProd.Image"), System.Drawing.Image)
        Me.BtnBuscaProd.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnBuscaProd.Location = New System.Drawing.Point(222, 32)
        Me.BtnBuscaProd.Name = "BtnBuscaProd"
        Me.BtnBuscaProd.Size = New System.Drawing.Size(35, 22)
        Me.BtnBuscaProd.TabIndex = 3
        Me.BtnBuscaProd.ToolTipText = "Busqueda de Producto"
        Me.BtnBuscaProd.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(92, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 15)
        Me.Label3.TabIndex = 98
        Me.Label3.Text = "Producto"
        '
        'TxtProducto
        '
        Me.TxtProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtProducto.Location = New System.Drawing.Point(92, 35)
        Me.TxtProducto.Name = "TxtProducto"
        Me.TxtProducto.Size = New System.Drawing.Size(125, 21)
        Me.TxtProducto.TabIndex = 0
        '
        'GridDetalle
        '
        Me.GridDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridDetalle.ColumnAutoResize = True
        Me.GridDetalle.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridDetalle.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridDetalle.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.GridDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridDetalle.Location = New System.Drawing.Point(7, 61)
        Me.GridDetalle.Name = "GridDetalle"
        Me.GridDetalle.RecordNavigator = True
        Me.GridDetalle.Size = New System.Drawing.Size(604, 341)
        Me.GridDetalle.TabIndex = 6
        Me.GridDetalle.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.LblEstado)
        Me.GroupBox1.Controls.Add(Me.lblFecha)
        Me.GroupBox1.Controls.Add(Me.lblFolio)
        Me.GroupBox1.Location = New System.Drawing.Point(623, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(159, 129)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        '
        'LblEstado
        '
        Me.LblEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEstado.Location = New System.Drawing.Point(6, 70)
        Me.LblEstado.Name = "LblEstado"
        Me.LblEstado.Size = New System.Drawing.Size(146, 14)
        Me.LblEstado.TabIndex = 101
        Me.LblEstado.Text = "Estado:"
        '
        'lblFecha
        '
        Me.lblFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFecha.Location = New System.Drawing.Point(5, 37)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(151, 15)
        Me.lblFecha.TabIndex = 100
        Me.lblFecha.Text = "Fecha:"
        '
        'lblFolio
        '
        Me.lblFolio.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFolio.Location = New System.Drawing.Point(3, 12)
        Me.lblFolio.Name = "lblFolio"
        Me.lblFolio.Size = New System.Drawing.Size(151, 24)
        Me.lblFolio.TabIndex = 99
        Me.lblFolio.Text = "Folio:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.BtnDel)
        Me.GroupBox2.Controls.Add(Me.TxtDoc)
        Me.GroupBox2.Controls.Add(Me.BtnBuscaDoc)
        Me.GroupBox2.Controls.Add(Me.GridDoctos)
        Me.GroupBox2.Location = New System.Drawing.Point(7, 139)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(155, 407)
        Me.GroupBox2.TabIndex = 159
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Documentos"
        '
        'BtnDel
        '
        Me.BtnDel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnDel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnDel.Image = CType(resources.GetObject("BtnDel.Image"), System.Drawing.Image)
        Me.BtnDel.Location = New System.Drawing.Point(75, 15)
        Me.BtnDel.Name = "BtnDel"
        Me.BtnDel.Size = New System.Drawing.Size(35, 22)
        Me.BtnDel.TabIndex = 17
        Me.BtnDel.ToolTipText = "Remueve el Ticket Seleccionado "
        Me.BtnDel.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtDoc
        '
        Me.TxtDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDoc.Location = New System.Drawing.Point(6, 16)
        Me.TxtDoc.Name = "TxtDoc"
        Me.TxtDoc.Size = New System.Drawing.Size(63, 21)
        Me.TxtDoc.TabIndex = 15
        '
        'BtnBuscaDoc
        '
        Me.BtnBuscaDoc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnBuscaDoc.Image = CType(resources.GetObject("BtnBuscaDoc.Image"), System.Drawing.Image)
        Me.BtnBuscaDoc.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnBuscaDoc.Location = New System.Drawing.Point(114, 15)
        Me.BtnBuscaDoc.Name = "BtnBuscaDoc"
        Me.BtnBuscaDoc.Size = New System.Drawing.Size(35, 22)
        Me.BtnBuscaDoc.TabIndex = 16
        Me.BtnBuscaDoc.ToolTipText = "Busqueda de Documentos"
        Me.BtnBuscaDoc.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GridDoctos
        '
        Me.GridDoctos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridDoctos.ColumnAutoResize = True
        Me.GridDoctos.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridDoctos.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridDoctos.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.GridDoctos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridDoctos.Location = New System.Drawing.Point(6, 40)
        Me.GridDoctos.Name = "GridDoctos"
        Me.GridDoctos.RecordNavigator = True
        Me.GridDoctos.Size = New System.Drawing.Size(143, 362)
        Me.GridDoctos.TabIndex = 7
        Me.GridDoctos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'FrmConfirmacion
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(792, 595)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GrpDetalle)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.GrpGeneral)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(667, 557)
        Me.Name = "FrmConfirmacion"
        Me.Text = "Confirmación de Recepción de Productos"
        Me.GrpGeneral.ResumeLayout(False)
        Me.GrpGeneral.PerformLayout()
        Me.GrpDetalle.ResumeLayout(False)
        Me.GrpDetalle.PerformLayout()
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.GridDoctos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private DOCClave As String
    Public sFolio As String
    Public SUCClave As String
    Public ALMDestino As String
    Public Tipo As String
    Public DescripcionEstado As String
    Public FecRegistro As DateTime
    Public Notas As String = ""
    Public Estado As Integer
    Public Documentos As String = ""
    Public Origen As String



    Private dtDoctos, dtDetalle, dtVentaDetalle, dtTipoRechazo As DataTable
    Private bConfirmado As Boolean = False
    Private CNFClave As String = ""

    Private sPROClave As String
    Private iTProducto As Integer
    Private dCantidad As Double
    Private iNumDecimales As Integer
    Private iFactor As Integer
    Private iSeguimiento As Integer
    Private iDiasGarantia As Integer
    Private bload As Boolean


    Private Sub AddDocto( _
 ByVal sDOCClave As String, _
 ByVal sTipo As String, _
 ByVal sFolio As String, _
 ByVal dFecha As String, _
 ByVal sOrigen As String, _
 ByVal sNotas As String)

        Dim foundRows() As Data.DataRow
        foundRows = dtDoctos.Select("DOCClave = '" & sDOCClave & "'")

        If foundRows.Length = 0 Then
            Dim row1 As DataRow
            row1 = dtDoctos.NewRow()
            'declara el nombre de la fila
            row1.Item("DOCClave") = sDOCClave
            row1.Item("Tipo") = sTipo
            row1.Item("Folio") = sFolio
            row1.Item("Fecha") = dFecha
            row1.Item("Origen") = sOrigen
            row1.Item("Notas") = sNotas
            dtDoctos.Rows.Add(row1)
            'agrega la fila completo a la tabla

            ModPOS.Ejecuta("sp_agrega_confirmacion", "@CNFClave", CNFClave, "@DOCClave", sDOCClave, "@Tipo", sTipo, "@Usuario", ModPOS.UsuarioActual)
            ModPOS.Ejecuta("sp_actualiza_confirmacion", "@DOCClave", sDOCClave, "@Tipo", sTipo, "@Estado", 5)


        Else
            Beep()
            MessageBox.Show("¡El documento " & sFolio & ", que intenta agregar ya existe en la recepción actual!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub addDetalle(ByVal sDOCClave As String, _
                           ByVal sDETClave As String, _
      ByVal sFoliio As String, _
      ByVal sPROClave As String, _
      ByVal iTProducto As Integer, _
      ByVal iSeguimiento As Integer, _
      ByVal iDiasGarantia As Integer, _
      ByVal dCosto As Double, _
      ByVal dTotal As Double, _
      ByVal sClave As String, _
      ByVal sNumParte As String, _
      ByVal sNombre As String, _
      ByVal dCantidad As Double, _
      ByVal dRecibido As Double, _
      ByVal iTipoRechazo As Integer)

        Dim foundRows() As Data.DataRow
        foundRows = dtDetalle.Select("DOCClave = '" & sDOCClave & "' and PROClave = '" & sPROClave & "'")

        If foundRows.Length = 0 Then
            Dim row1 As DataRow
            row1 = dtDetalle.NewRow()
            'declara el nombre de la fila

            row1.Item("DOCClave") = sDOCClave
            row1.Item("DETClave") = sDETClave
            row1.Item("Folio") = sFoliio
            row1.Item("PROClave") = sPROClave
            row1.Item("TProducto") = iTProducto
            row1.Item("Seguimiento") = iSeguimiento
            row1.Item("DiasGarantia") = iDiasGarantia
            row1.Item("Costo") = dCosto
            row1.Item("Total") = dTotal
            row1.Item("Clave") = sClave
            row1.Item("NumParte") = sNumParte
            row1.Item("Nombre") = sNombre
            row1.Item("Cantidad") = dCantidad
            row1.Item("Recibido") = dRecibido
            row1.Item("TipoRechazo") = iTipoRechazo


            dtDetalle.Rows.Add(row1)
            'agrega la fila completo a la tabla

        End If



    End Sub


    Public Sub cargaDocto(ByVal sDOCClave As String, ByVal sTipo As String)

        Dim Cnx As System.Data.SqlClient.SqlConnection = Nothing
        Dim dr As System.Data.SqlClient.SqlDataReader
        Dim myCommand As System.Data.SqlClient.SqlCommand
      
        Try
            Cnx = New System.Data.SqlClient.SqlConnection
            Cnx.ConnectionString = ModPOS.BDConexion
            Cnx.Open()
        Catch ex As Exception
            Beep()
            MessageBox.Show("No se puede conectar a la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


        myCommand = New System.Data.SqlClient.SqlCommand("sp_encabezado_conf", Cnx)
        myCommand.CommandType = CommandType.StoredProcedure
        myCommand.CommandTimeout = ModPOS.myTimeOut
        myCommand.Parameters.Add("@DOCClave", SqlDbType.VarChar).Value = sDOCClave
        myCommand.Parameters.Add("@Tipo", SqlDbType.VarChar).Value = sTipo

        dr = myCommand.ExecuteReader()

        While dr.Read

            AddDocto( _
            dr("DOCClave"), _
            dr("Tipo"), _
            dr("Folio"), _
            dr("Fecha"), _
            dr("Origen"), _
            dr("Notas"))



        End While

        myCommand.Dispose()
        dr.Close()


        myCommand = New System.Data.SqlClient.SqlCommand("sp_confirmacion_detalle", Cnx)
        myCommand.CommandType = CommandType.StoredProcedure
        myCommand.CommandTimeout = ModPOS.myTimeOut
        myCommand.Parameters.Add("@DOCClave", SqlDbType.VarChar).Value = sDOCClave
        myCommand.Parameters.Add("@Tipo", SqlDbType.VarChar).Value = sTipo

        dr = myCommand.ExecuteReader()

        While dr.Read
            addDetalle(dr("DOCClave"), _
                       dr("DETClave"), _
                         dr("Folio"), _
                         dr("PROClave"), _
                         dr("TProducto"), _
                         dr("Seguimiento"), _
                         dr("DiasGarantia"), _
                         dr("Costo"), _
                         dr("Total"), _
                         dr("Clave"), _
                         dr("NumParte"), _
                         dr("Nombre"), _
                         dr("Cantidad"), _
                         dr("Recibido"), _
                         dr("TipoRechazo"))
        End While

        myCommand.Dispose()
        dr.Close()
        Cnx.Close()

    End Sub

    Private Sub cargaDatosDocto(ByVal sDOCClave As String, ByVal sTipo As String)
        If sDOCClave <> DOCClave Then
            DOCClave = sDOCClave
            Dim dt As DataTable = ModPOS.Recupera_Tabla("sp_encabezado_conf", "@DOCClave", sDOCClave, "@Tipo", sTipo)
            With Me
                .DOCClave = dt.Rows(0)("DOCClave")
                .Tipo = dt.Rows(0)("Tipo")
                .sFolio = dt.Rows(0)("Folio")
                .FecRegistro = dt.Rows(0)("Fecha")
                .Origen = dt.Rows(0)("Origen")
                .Notas = dt.Rows(0)("Notas")
                .Estado = dt.Rows(0)("Estado")
                .DescripcionEstado = dt.Rows(0)("NEstado")
                dt.Dispose()


                Me.lblFolio.Text = sFolio
                Me.TxtOrigen.Text = Origen
                Me.LblEstado.Text = DescripcionEstado
                Me.lblFecha.Text = FecRegistro.ToShortDateString
                TxtNotas.Text = Notas


                With Me.cmbURecibo
                    .Conexion = ModPOS.BDConexion
                    .ProcedimientoAlmacenado = "sp_recupera_recibo"
                    .NombreParametro1 = "ALMClave"
                    .Parametro1 = ALMDestino
                    .llenar()
                End With

            End With
            dt.Dispose()
        End If
    End Sub

  

    Private Sub FrmConfirmacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        CNFClave = ModPOS.obtenerLlave

        dtDoctos = ModPOS.CrearTabla("Documentos", _
           "DOCClave", "System.String", _
           "Tipo", "System.String", _
           "Folio", "System.String", _
           "Fecha", "System.DateTime", _
           "Origen", "System.String", _
           "Notas", "System.String")

        GridDoctos.DataSource = dtDoctos
        GridDoctos.RetrieveStructure(True)
        GridDoctos.GroupByBoxVisible = False
        GridDoctos.RootTable.Columns("DOCClave").Visible = False
        GridDoctos.RootTable.Columns("Tipo").Visible = False
        GridDoctos.CurrentTable.Columns("Folio").Selectable = False
        GridDoctos.CurrentTable.Columns("Fecha").Selectable = False
        GridDoctos.RootTable.Columns("Origen").Visible = False
        GridDoctos.RootTable.Columns("Notas").Visible = False

        dtDetalle = ModPOS.CrearTabla("Detalle", _
                  "DOCClave", "System.String", _
                  "DETClave", "System.String", _
                  "Folio", "System.String", _
                  "PROClave", "System.String", _
                  "TProducto", "System.Int32", _
                  "Seguimiento", "System.Int32", _
                  "DiasGarantia", "System.Int32", _
                  "Costo", "System.Double", _
                  "Total", "System.Double", _
                  "Clave", "System.String", _
                  "NumParte", "System.String", _
                  "Nombre", "System.String", _
                  "Cantidad", "System.Double", _
                  "Recibido", "System.Double", _
                  "TipoRechazo", "System.Int32")


        '  dtDetalle = ModPOS.Recupera_Tabla("sp_confirmacion_detalle", "@TRAClave", TRAClave)
        GridDetalle.DataSource = dtDetalle
        GridDetalle.RetrieveStructure(True)
        GridDetalle.GroupByBoxVisible = False
        GridDetalle.RootTable.Columns("DOCClave").Visible = False
        GridDetalle.RootTable.Columns("DETClave").Visible = False
        GridDetalle.RootTable.Columns("PROClave").Visible = False
        GridDetalle.RootTable.Columns("TProducto").Visible = False
        GridDetalle.RootTable.Columns("Seguimiento").Visible = False
        GridDetalle.RootTable.Columns("DiasGarantia").Visible = False
        GridDetalle.CurrentTable.Columns("Costo").Visible = False
        GridDetalle.CurrentTable.Columns("Total").Visible = False

        GridDetalle.RootTable.Columns("Folio").Selectable = False
        GridDetalle.RootTable.Columns("Clave").Selectable = False
        GridDetalle.RootTable.Columns("NumParte").Selectable = False
        GridDetalle.CurrentTable.Columns("Nombre").Selectable = False
        GridDetalle.CurrentTable.Columns("Cantidad").Selectable = False

        GridDetalle.CurrentTable.Columns("TipoRechazo").HasValueList = True
        Dim AircraftTypeValueListItemCollection As Janus.Windows.GridEX.GridEXValueListItemCollection
        AircraftTypeValueListItemCollection = GridDetalle.Tables(0).Columns("TipoRechazo").ValueList
        With AircraftTypeValueListItemCollection

            dtTipoRechazo = ModPOS.Recupera_Tabla("sp_filtra_valorref", "@Tabla", "MOVALMDetalle", "@Campo", "TipoRechazo")

            Dim i As Integer

            For i = 0 To dtTipoRechazo.Rows.Count - 1
                .Add(dtTipoRechazo.Rows(i)("valor"), dtTipoRechazo.Rows(i)("descripcion"))
            Next

        End With
        GridDetalle.CurrentTable.Columns("TipoRechazo").EditType = Janus.Windows.GridEX.EditType.Combo

        Dim fc As Janus.Windows.GridEX.GridEXFormatCondition
        fc = New Janus.Windows.GridEX.GridEXFormatCondition(GridDetalle.RootTable.Columns("Recibido"), Janus.Windows.GridEX.ConditionOperator.LessThan, GridDetalle.GetValue("Cantidad"))
        fc.FormatStyle.ForeColor = System.Drawing.Color.Red
        GridDetalle.RootTable.FormatConditions.Add(fc)


        If Documentos <> "" Then
            If Documentos.Split("|").Length >= 1 Then
                Dim i As Integer
                Dim Docto As String
                For i = 0 To Documentos.Split("|").Length - 1
                    Docto = Documentos.Split("|")(i)
                    cargaDocto(Docto.Split(",")(0), Docto.Split(",")(1))
                Next
            End If
            If GridDoctos.RowCount > 0 Then
                cargaDatosDocto(GridDoctos.GetValue("DOCClave"), GridDoctos.GetValue("Tipo"))
            End If
        End If



        bload = True


    End Sub

    Private Sub FrmConfirmacion_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        If bConfirmado = False Then

            Beep()
            Select Case MessageBox.Show("Se perderan todos los cambios ¿Desea continuar?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.No
                    e.Cancel = True
                    Exit Sub
            End Select

            ModPOS.Ejecuta("sp_libera_confirmacion", "@CNFClave", CNFClave)


        End If


        If Not ModPOS.Recibo Is Nothing Then
            ModPOS.Recibo.AgregarFolio()
        End If
        ModPOS.Confirmacion.Dispose()
        ModPOS.Confirmacion = Nothing



    End Sub

    Private Sub BtnBuscaProd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscaProd.Click
        Dim a As New MeSearch
        a.ProcedimientoAlmacenado = "sp_search_prod"
        a.TablaCmb = "Producto"
        a.CampoCmb = "Filtro"
        a.NumColDes = 2
        a.CompaniaRequerido = True
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            TxtProducto.Text = a.valor
            leeCodigoBarras(a.valor)
        End If
        a.Dispose()
    End Sub

    Private Sub leeCodigoBarras(ByVal Codigo As String)
        If Not Codigo = vbNullString Then
            'Busca y recupera los datos del producto

            Dim dtProducto As DataTable = ModPOS.SiExisteRecupera("sp_surtido_producto", "@Clave", Codigo.Replace("'", "''"))
            If Not dtProducto Is Nothing AndAlso dtProducto.Rows.Count > 0 Then

                sPROClave = dtProducto.Rows(0)("PROClave")
                iTProducto = dtProducto.Rows(0)("TProducto")
                iSeguimiento = dtProducto.Rows(0)("Seguimiento")
                iDiasGarantia = dtProducto.Rows(0)("DiasGarantia")
                iNumDecimales = dtProducto.Rows(0)("Num_Decimales")
                iFactor = dtProducto.Rows(0)("Factor")

                dtProducto.Dispose()

                TxtCantidad.DecimalDigits = iNumDecimales

                If TxtCantidad.Text = vbNullString OrElse CDbl(TxtCantidad.Text) = 0 Then
                    dCantidad = 1 * iFactor
                    TxtCantidad.Text = "1"
                Else
                    dCantidad = CDbl(TxtCantidad.Text) * iFactor
                End If

                'Actualiza Surtido
                Dim foundRows() As System.Data.DataRow

                foundRows = dtDetalle.Select("PROClave Like '" & sPROClave & "' and Cantidad > Confirmado")
                If foundRows.Length >= 1 Then
                    Dim porSurtir As Double

                    porSurtir = dtDetalle.Compute("SUM(Cantidad)", "PROClave Like '" & sPROClave & "'")
                    porSurtir -= dtDetalle.Compute("SUM(Confirmado)", "PROClave Like '" & sPROClave & "'")

                    If porSurtir >= dCantidad Then
                        Dim i As Integer
                        For i = 0 To foundRows.Length - 1

                            Select Case dCantidad
                                Case Is >= CDbl(foundRows(i)("Cantidad") - foundRows(i)("Confirmado"))
                                    dCantidad -= CDbl(foundRows(i)("Cantidad") - foundRows(i)("Confirmado"))
                                    foundRows(i)("Confirmado") = foundRows(i)("Cantidad")
                                    If dCantidad <= 0 Then
                                        Exit For
                                    End If
                                Case Is < CDbl(foundRows(i)("Cantidad") - foundRows(i)("Confirmado"))
                                    foundRows(i)("Confirmado") += dCantidad
                                    Exit For
                            End Select
                        Next
                    Else
                        Beep()
                        MessageBox.Show("La cantidad  a confirmar es mayor a la registrada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If
                Else
                    Beep()
                    MessageBox.Show("La cantidad  o producto excede la registrada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If

                TxtCantidad.Text = "1"
                TxtProducto.Text = ""

                TxtProducto.Focus()
            Else
                sPROClave = 0
                iTProducto = 0
                iSeguimiento = 0
                iDiasGarantia = 0
                iNumDecimales = 0
                iFactor = 0
                TxtProducto.Text = ""
                Beep()
                MessageBox.Show("La Clave o Código de Barras no esta registrada o esta inactiva", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If


        End If
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        'Valida si existen productos pendientes de surtir
        If cmbURecibo.SelectedValue Is Nothing Then
            MessageBox.Show("Debe seleccionar una ubicación de recibo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If bConfirmado = False Then
            Dim dRegistrado, dConfirmado As Double
            Dim foundRows() As DataRow

            dConfirmado = dtDetalle.Compute("SUM(Confirmado)", "")

            If dConfirmado = 0 Then
                MessageBox.Show("No es posible confirmar el traspaso sin por lo menos una mercancia recibida", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Exit Sub
            End If

            dRegistrado = dtDetalle.Compute("SUM(Cantidad)", "")
            If dRegistrado > dConfirmado Then
                Beep()
                Select Case MessageBox.Show("Existe mercancia pendiente de recibir. ¿Desea continuar y cancelar la mercancia faltante?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                    Case DialogResult.No
                        Exit Sub
                End Select

                foundRows = dtDetalle.Select("Cantidad > Confirmado and (TipoRechazo = 0 or TipoRechazo is Null)")
                If foundRows.GetLength(0) > 0 Then
                    MessageBox.Show("No se ha especificado tipo de Rechazo de la mercancia que no fue recibida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

            End If


            'Confirmación de recolección
            Beep()
            Select Case MessageBox.Show("¿Desea confirmar el Traspaso?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                Case DialogResult.No
                    Exit Sub
            End Select

            Dim a As New MeAutorizacion
            a.Sucursal = SUCClave
            a.MontodeAutorizacion = dtDetalle.Compute("SUM(Total)", "")
            a.StartPosition = FormStartPosition.CenterScreen
            a.ShowDialog()
            If a.DialogResult = DialogResult.OK Then
                If a.Autorizado Then
                    'Busca productos con seguimiento
                    Dim i, j As Integer
                    Dim Rechazado As Double

                    'Actualiza Detalle y Libera apartados

                    For i = 0 To dtDetalle.Rows.Count - 1

                        'Obtiene el faltante para la ubicacion y producto actual
                        Rechazado = dtDetalle.Rows(i)("Cantidad") - dtDetalle.Rows(i)("Confirmado")

                        'Si existe faltante, libera el apartado del faltante y actualiza partida del pedido
                        ModPOS.Ejecuta("", _
                                                                  "@MVAClave", dtDetalle.Rows(j)("MVAClave"), _
                                                                  "@DMVAClave", dtDetalle.Rows(j)("DMVAClave"), _
                                                                  "@PROClave", dtDetalle.Rows(i)("PROClave"), _
                                                                  "@Rechazo", Rechazado, _
                                                                  "@TipoRechazo", dtDetalle.Rows(i)("TipoRechazo"), _
                                                                  "@Usuario", a.Autoriza)

                    Next



                    Dim dtConfirmacion As DataTable = ModPOS.Recupera_Tabla("sp_recuperar_confirmacion", "@CNFClave", CNFClave)
                    Dim bImprimir As Boolean = False

                    Select Case MessageBox.Show("¿Desea imprimir los documentos?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        Case DialogResult.Yes
                            bImprimir = True
                    End Select

                    If dtConfirmacion.Rows.Count > 0 Then
                        For j = 0 To dtConfirmacion.Rows.Count - 1

                            If dtConfirmacion.Rows(j)("Tipo") = "Traspaso" Then

                                ModPOS.Ejecuta("sp_actualiza_estado_traspaso", "@MVAClave", dtConfirmacion.Rows(j)("CNFClave"), "@Estado", 2)

                                ModPOS.GeneraMovInv(1, 8, 6, dtConfirmacion.Rows(j)("CNFClave"), ALMDestino, sFolio, a.Autoriza)
                                ModPOS.ActualizaExistAlm(1, 6, dtConfirmacion.Rows(j)("CNFClave"), ALMDestino)
                                ModPOS.ActualizaExistUbc(1, 6, dtConfirmacion.Rows(j)("CNFClave"), ALMDestino, cmbURecibo.SelectedValue)

                                If bImprimir Then
                                    If dtConfirmacion.Rows(j)("Tipo") = "Traspaso" Then
                                        Dim OpenReport As New Report
                                        Dim pvtaDataSet As New DataSet
                                        pvtaDataSet.DataSetName = "pvtaDataSet"
                                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_rep_transferencia", "@MVAClave", dtConfirmacion.Rows(j)("CNFClave")))
                                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_detalle_transferencia", "@MVAClave", dtConfirmacion.Rows(j)("CNFClave")))
                                        OpenReport.PrintPreview("Transferencia de Almacén", "CRTransferencia.rpt", pvtaDataSet, "")
                                    End If
                                End If
                            End If
                        Next
                    End If

                    bConfirmado = True
                End If
            End If
            a.Dispose()
        End If

      
      
        Me.Close()

    End Sub

   
    Private Sub registraSeguimiento(ByVal sPROClave As String, ByVal sClave As String, ByVal sNombre As String, ByVal dCantidad As Double, ByVal iSeguimiento As Integer, ByVal iDiasGarantia As Integer)
        'SI REQUIERE SEGUIMIENTO DE SERIAL
        If iSeguimiento = 2 Then
            Dim SerialReg As Integer = 0
            Dim PorRegistrar As Double
            PorRegistrar = dCantidad
            Do
                Dim a As New FrmSerial
                a.DOCClave = DOCClave
                a.PROClave = sPROClave
                a.Clave = sClave
                a.Nombre = sNombre
                a.Cantidad = PorRegistrar
                a.Dias = iDiasGarantia
                a.TipoDoc = 1
                a.TipoMov = 2
                a.ShowDialog()
                SerialReg = SerialReg + a.NumSerialRegistrados
                PorRegistrar = PorRegistrar - a.NumSerialRegistrados
                a.Dispose()
            Loop Until SerialReg = dCantidad OrElse PorRegistrar = 0
        End If

        'SI REQUIERE SEGUIMIENTO DE LOTE
        If iSeguimiento = 3 Then
            Dim LoteReg As Integer = 0
            Dim PorRegistrar As Double
            PorRegistrar = dCantidad
            Do
                Dim a As New FrmLote
                a.DOCClave = DOCClave
                a.PROClave = sPROClave
                a.Clave = sClave
                a.Nombre = sNombre
                a.CantXRegistrar = PorRegistrar
                a.TipoDoc = 1
                a.TipoMov = 2
                a.ShowDialog()
                LoteReg = LoteReg + a.NumSerialRegistrados
                PorRegistrar = PorRegistrar - a.NumSerialRegistrados
                a.Dispose()
            Loop Until LoteReg = dCantidad OrElse PorRegistrar = 0
        End If

    End Sub

    Private Sub GridDetalle_CellEdited(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridDetalle.CellEdited
        If GridDetalle.CurrentColumn.Caption = "Confirmado" Then
            If IsNumeric(GridDetalle.GetValue("Confirmado")) Then
                Select Case CDbl(GridDetalle.GetValue("Confirmado"))
                    Case Is > CDbl(GridDetalle.GetValue("Cantidad"))
                        Beep()
                        MessageBox.Show("¡La cantidad a confirmar no de ser mayor a la registrada!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        GridDetalle.SetValue("Confirmado", CDbl(GridDetalle.GetValue("Cantidad")))
                    Case Is < 0
                        GridDetalle.SetValue("Confirmado", 0)
                End Select
            Else
                GridDetalle.SetValue("Confirmado", 0)
            End If
            GridDetalle.SetValue("Total", GridDetalle.GetValue("Costo") * GridDetalle.GetValue("Confirmado"))
        End If

    End Sub

    Private Sub TxtCantidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCantidad.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Not TxtCantidad.Text = vbNullString Then
                If CDbl(TxtCantidad.Text) = 0 Then
                    dCantidad = 1
                    TxtCantidad.Text = CStr(dCantidad)
                Else
                    dCantidad = Math.Abs(CDbl(TxtCantidad.Text))
                End If
            Else
                dCantidad = 1
                TxtCantidad.Text = CStr(dCantidad)
            End If
            TxtProducto.Focus()
        End If
    End Sub

    Private Sub TxtCantidad_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCantidad.Leave
        If Not TxtCantidad.Text = vbNullString Then
            If CDbl(TxtCantidad.Text) = 0 Then
                dCantidad = 1
                TxtCantidad.Text = CStr(dCantidad)
            Else
                dCantidad = Math.Abs(CDbl(TxtCantidad.Text))
            End If

        Else
            dCantidad = 1
            TxtCantidad.Text = CStr(dCantidad)
        End If

        TxtProducto.Focus()

    End Sub

    Private Sub TxtProducto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtProducto.KeyPress
        If Asc(e.KeyChar) = 13 Then
            leeCodigoBarras(TxtProducto.Text.Trim.ToUpper.Replace("'", "''"))
        End If
    End Sub

  

    Private Sub TxtDoc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDoc.KeyPress
        If Asc(e.KeyChar) = 13 Then

            If Not TxtDoc.Text = vbNullString Then
                cargaDocto(TxtDoc.Text.ToUpper.Trim.Replace("'", "''"), "")
                TxtDoc.Text = ""
            End If
        End If
    End Sub

    Private Sub GridDoctos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridDoctos.Click
        If bload = True AndAlso Not GridDoctos.GetValue(0) Is Nothing Then
            Me.cargaDatosDocto(GridDoctos.GetValue("DOCClave"), GridDoctos.GetValue("Tipo"))
        End If
    End Sub

    Private Sub BtnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDel.Click
        If DOCClave <> "" Then

            If MessageBox.Show("¿Esta seguro de remover el documento: " & GridDoctos.GetValue("Folio") & " ?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                Dim foundRows() As System.Data.DataRow

                'Cambia Estado
                ModPOS.Ejecuta("sp_agrega_confirmacion", "@CNFClave", Nothing, "@DOCClave", GridDoctos.GetValue("DOCClave"), "@Tipo", GridDoctos.GetValue("Tipo"), "@Usuario", ModPOS.UsuarioActual)
                ModPOS.Ejecuta("sp_actualiza_confirmacion", "@DOCClave", GridDoctos.GetValue("DOCClave"), "@Tipo", GridDoctos.GetValue("Tipo"), "@Estado", 4)


                'Elimina Detalle
                foundRows = dtDetalle.Select("DOCClave = '" & GridDoctos.GetValue("DOCClave") & "'")

                If foundRows.GetLength(0) > 0 Then
                    Dim i As Integer
                    For i = 0 To foundRows.GetUpperBound(0)
                        dtDetalle.Rows.Remove(foundRows(i))
                    Next

                End If

                'Elimina Pedido
                foundRows = dtDoctos.Select("DOCClave = '" & GridDoctos.GetValue("DOCClave") & "'")
                If foundRows.GetLength(0) > 0 Then
                    dtDoctos.Rows.Remove(foundRows(0))
                End If


            End If

        Else
            MessageBox.Show("No se encuentra algun ticket seleccionado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
End Class
