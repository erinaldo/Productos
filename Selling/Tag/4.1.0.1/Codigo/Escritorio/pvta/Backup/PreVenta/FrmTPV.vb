Imports System
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Collections

Public Class FrmTPV
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
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents LblTotal As System.Windows.Forms.Label
    Friend WithEvents LblAhorro As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents LblFolio As System.Windows.Forms.Label
    Friend WithEvents LblFechaHora As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LblUsuario As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents BtnCliente As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TxtCantidad As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents BtnBusquedaProducto As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnCerrar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnVenta As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnSalir As Janus.Windows.EditControls.UIButton
    Friend WithEvents Clock As System.Windows.Forms.Timer
    Friend WithEvents LblCliente As System.Windows.Forms.Label
    Friend WithEvents LblCantidadPuntos As System.Windows.Forms.Label
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents LblCantidadArticulos As System.Windows.Forms.Label
    Friend WithEvents GridDetalle As Janus.Windows.GridEX.GridEX
    Friend WithEvents BtnPromocion As Janus.Windows.EditControls.UIButton
    Friend WithEvents LblPuntodeVenta As System.Windows.Forms.Label
    Friend WithEvents TxtProducto As System.Windows.Forms.TextBox
    Friend WithEvents BtnRecuperar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnConvertir As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnOtrosDocumentos As Janus.Windows.EditControls.UIButton
    Friend WithEvents CtxDocumentos As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ItemApartado As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ItemCotizacion As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ItemCredito As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ItemCambio As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LblTipoCambio As System.Windows.Forms.Label
    Friend WithEvents BtnDeshacer As Janus.Windows.EditControls.UIButton
    Friend WithEvents LblProducto As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTPV))
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.LblCantidadPuntos = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.LblTipoCambio = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.LblTotal = New System.Windows.Forms.Label
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.Label6 = New System.Windows.Forms.Label
        Me.LblAhorro = New System.Windows.Forms.Label
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.Label8 = New System.Windows.Forms.Label
        Me.LblFolio = New System.Windows.Forms.Label
        Me.LblFechaHora = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.LblUsuario = New System.Windows.Forms.Label
        Me.LblCliente = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.BtnCliente = New Janus.Windows.EditControls.UIButton
        Me.BtnBusquedaProducto = New Janus.Windows.EditControls.UIButton
        Me.BtnCerrar = New Janus.Windows.EditControls.UIButton
        Me.BtnVenta = New Janus.Windows.EditControls.UIButton
        Me.BtnSalir = New Janus.Windows.EditControls.UIButton
        Me.TxtCliente = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.TxtCantidad = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.Clock = New System.Windows.Forms.Timer(Me.components)
        Me.Panel6 = New System.Windows.Forms.Panel
        Me.Panel7 = New System.Windows.Forms.Panel
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.LblCantidadArticulos = New System.Windows.Forms.Label
        Me.LblProducto = New System.Windows.Forms.Label
        Me.GridDetalle = New Janus.Windows.GridEX.GridEX
        Me.BtnPromocion = New Janus.Windows.EditControls.UIButton
        Me.LblPuntodeVenta = New System.Windows.Forms.Label
        Me.TxtProducto = New System.Windows.Forms.TextBox
        Me.BtnRecuperar = New Janus.Windows.EditControls.UIButton
        Me.BtnConvertir = New Janus.Windows.EditControls.UIButton
        Me.BtnOtrosDocumentos = New Janus.Windows.EditControls.UIButton
        Me.CtxDocumentos = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ItemApartado = New System.Windows.Forms.ToolStripMenuItem
        Me.ItemCotizacion = New System.Windows.Forms.ToolStripMenuItem
        Me.ItemCredito = New System.Windows.Forms.ToolStripMenuItem
        Me.ItemCambio = New System.Windows.Forms.ToolStripMenuItem
        Me.BtnDeshacer = New Janus.Windows.EditControls.UIButton
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel7.SuspendLayout()
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CtxDocumentos.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.LblCantidadPuntos)
        Me.Panel1.Location = New System.Drawing.Point(123, 499)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(143, 50)
        Me.Panel1.TabIndex = 6
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Gold
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Location = New System.Drawing.Point(7, 104)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(166, 59)
        Me.Panel2.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label4.Location = New System.Drawing.Point(7, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 37)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "CANTIDAD PRODUCTOS"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Lucida Sans Unicode", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(7, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 23)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "PTS."
        '
        'LblCantidadPuntos
        '
        Me.LblCantidadPuntos.BackColor = System.Drawing.Color.Transparent
        Me.LblCantidadPuntos.Font = New System.Drawing.Font("Lucida Sans Unicode", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCantidadPuntos.ForeColor = System.Drawing.Color.Black
        Me.LblCantidadPuntos.Location = New System.Drawing.Point(43, 4)
        Me.LblCantidadPuntos.Name = "LblCantidadPuntos"
        Me.LblCantidadPuntos.Size = New System.Drawing.Size(93, 29)
        Me.LblCantidadPuntos.TabIndex = 10
        Me.LblCantidadPuntos.Text = "14"
        Me.LblCantidadPuntos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel3.Controls.Add(Me.LblTipoCambio)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.LblTotal)
        Me.Panel3.Location = New System.Drawing.Point(439, 499)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(358, 50)
        Me.Panel3.TabIndex = 7
        '
        'LblTipoCambio
        '
        Me.LblTipoCambio.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblTipoCambio.BackColor = System.Drawing.Color.Transparent
        Me.LblTipoCambio.Font = New System.Drawing.Font("Lucida Sans Unicode", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTipoCambio.ForeColor = System.Drawing.Color.Black
        Me.LblTipoCambio.Location = New System.Drawing.Point(165, 28)
        Me.LblTipoCambio.Name = "LblTipoCambio"
        Me.LblTipoCambio.Size = New System.Drawing.Size(190, 20)
        Me.LblTipoCambio.TabIndex = 42
        Me.LblTipoCambio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Lucida Sans Unicode", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(2, 6)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 25)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "TOTAL"
        '
        'LblTotal
        '
        Me.LblTotal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblTotal.BackColor = System.Drawing.Color.Transparent
        Me.LblTotal.Font = New System.Drawing.Font("Lucida Sans Unicode", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotal.ForeColor = System.Drawing.Color.Black
        Me.LblTotal.Location = New System.Drawing.Point(75, 3)
        Me.LblTotal.Name = "LblTotal"
        Me.LblTotal.Size = New System.Drawing.Size(280, 25)
        Me.LblTotal.TabIndex = 8
        Me.LblTotal.Text = "$353.45 M.N"
        Me.LblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel4.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel4.Controls.Add(Me.Label6)
        Me.Panel4.Controls.Add(Me.LblAhorro)
        Me.Panel4.Location = New System.Drawing.Point(267, 499)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(170, 50)
        Me.Panel4.TabIndex = 8
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Lucida Sans Unicode", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(4, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 24)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "DESC."
        '
        'LblAhorro
        '
        Me.LblAhorro.BackColor = System.Drawing.Color.Transparent
        Me.LblAhorro.Font = New System.Drawing.Font("Lucida Sans Unicode", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAhorro.ForeColor = System.Drawing.Color.Black
        Me.LblAhorro.Location = New System.Drawing.Point(52, 3)
        Me.LblAhorro.Name = "LblAhorro"
        Me.LblAhorro.Size = New System.Drawing.Size(113, 29)
        Me.LblAhorro.TabIndex = 9
        Me.LblAhorro.Text = "$353.45"
        Me.LblAhorro.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel5.Controls.Add(Me.Label8)
        Me.Panel5.Controls.Add(Me.LblFolio)
        Me.Panel5.Location = New System.Drawing.Point(2, 3)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(192, 44)
        Me.Panel5.TabIndex = 9
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Lucida Sans Unicode", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(3, 1)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(62, 21)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "FOLIO"
        '
        'LblFolio
        '
        Me.LblFolio.BackColor = System.Drawing.Color.Transparent
        Me.LblFolio.Font = New System.Drawing.Font("Lucida Sans Unicode", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFolio.ForeColor = System.Drawing.Color.Black
        Me.LblFolio.Location = New System.Drawing.Point(57, 6)
        Me.LblFolio.Name = "LblFolio"
        Me.LblFolio.Size = New System.Drawing.Size(134, 36)
        Me.LblFolio.TabIndex = 8
        Me.LblFolio.Text = "1-0001"
        Me.LblFolio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblFechaHora
        '
        Me.LblFechaHora.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblFechaHora.BackColor = System.Drawing.Color.Transparent
        Me.LblFechaHora.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LblFechaHora.ForeColor = System.Drawing.Color.Black
        Me.LblFechaHora.Location = New System.Drawing.Point(364, 3)
        Me.LblFechaHora.Name = "LblFechaHora"
        Me.LblFechaHora.Size = New System.Drawing.Size(430, 19)
        Me.LblFechaHora.TabIndex = 11
        Me.LblFechaHora.Text = "Lunes, 31 Marzo"
        Me.LblFechaHora.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(197, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 17)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "VENDEDOR:"
        '
        'LblUsuario
        '
        Me.LblUsuario.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblUsuario.BackColor = System.Drawing.Color.Transparent
        Me.LblUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LblUsuario.ForeColor = System.Drawing.Color.Black
        Me.LblUsuario.Location = New System.Drawing.Point(199, 25)
        Me.LblUsuario.Name = "LblUsuario"
        Me.LblUsuario.Size = New System.Drawing.Size(394, 33)
        Me.LblUsuario.TabIndex = 15
        Me.LblUsuario.Text = "JUAN PEREZ"
        '
        'LblCliente
        '
        Me.LblCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblCliente.BackColor = System.Drawing.Color.Transparent
        Me.LblCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCliente.ForeColor = System.Drawing.Color.Black
        Me.LblCliente.Location = New System.Drawing.Point(296, 59)
        Me.LblCliente.Name = "LblCliente"
        Me.LblCliente.Size = New System.Drawing.Size(500, 23)
        Me.LblCliente.TabIndex = 17
        Me.LblCliente.Text = "JUAN PEREZ "
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(62, 60)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(95, 20)
        Me.Label10.TabIndex = 16
        Me.Label10.Text = "CLIENTE:"
        '
        'BtnCliente
        '
        Me.BtnCliente.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCliente.Enabled = False
        Me.BtnCliente.Icon = CType(resources.GetObject("BtnCliente.Icon"), System.Drawing.Icon)
        Me.BtnCliente.ImageSize = New System.Drawing.Size(20, 20)
        Me.BtnCliente.Location = New System.Drawing.Point(2, 56)
        Me.BtnCliente.Name = "BtnCliente"
        Me.BtnCliente.Size = New System.Drawing.Size(51, 29)
        Me.BtnCliente.TabIndex = 3
        Me.BtnCliente.Text = "F4"
        Me.BtnCliente.ToolTipText = "Busqueda de Cliente"
        Me.BtnCliente.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnBusquedaProducto
        '
        Me.BtnBusquedaProducto.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnBusquedaProducto.Icon = CType(resources.GetObject("BtnBusquedaProducto.Icon"), System.Drawing.Icon)
        Me.BtnBusquedaProducto.ImageSize = New System.Drawing.Size(20, 20)
        Me.BtnBusquedaProducto.Location = New System.Drawing.Point(2, 86)
        Me.BtnBusquedaProducto.Name = "BtnBusquedaProducto"
        Me.BtnBusquedaProducto.Size = New System.Drawing.Size(51, 28)
        Me.BtnBusquedaProducto.TabIndex = 8
        Me.BtnBusquedaProducto.Text = "F1"
        Me.BtnBusquedaProducto.ToolTipText = "Busqueda y seleccion de producto"
        Me.BtnBusquedaProducto.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCerrar
        '
        Me.BtnCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnCerrar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCerrar.Icon = CType(resources.GetObject("BtnCerrar.Icon"), System.Drawing.Icon)
        Me.BtnCerrar.ImageSize = New System.Drawing.Size(20, 20)
        Me.BtnCerrar.Location = New System.Drawing.Point(705, 557)
        Me.BtnCerrar.Name = "BtnCerrar"
        Me.BtnCerrar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCerrar.TabIndex = 11
        Me.BtnCerrar.Text = "F9- Cerrar"
        Me.BtnCerrar.ToolTipText = "Finaliza la Venta o Cotización"
        Me.BtnCerrar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnVenta
        '
        Me.BtnVenta.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnVenta.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnVenta.Icon = CType(resources.GetObject("BtnVenta.Icon"), System.Drawing.Icon)
        Me.BtnVenta.ImageSize = New System.Drawing.Size(20, 20)
        Me.BtnVenta.Location = New System.Drawing.Point(610, 557)
        Me.BtnVenta.Name = "BtnVenta"
        Me.BtnVenta.Size = New System.Drawing.Size(90, 37)
        Me.BtnVenta.TabIndex = 12
        Me.BtnVenta.Text = "F5-  Venta"
        Me.BtnVenta.ToolTipText = "Crea una nueva Venta"
        Me.BtnVenta.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnSalir
        '
        Me.BtnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnSalir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSalir.Icon = CType(resources.GetObject("BtnSalir.Icon"), System.Drawing.Icon)
        Me.BtnSalir.ImageSize = New System.Drawing.Size(20, 20)
        Me.BtnSalir.Location = New System.Drawing.Point(103, 557)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(90, 37)
        Me.BtnSalir.TabIndex = 14
        Me.BtnSalir.Text = "ESC- Salir"
        Me.BtnSalir.ToolTipText = "Salir"
        Me.BtnSalir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtCliente
        '
        Me.TxtCliente.Enabled = False
        Me.TxtCliente.Location = New System.Drawing.Point(172, 60)
        Me.TxtCliente.Name = "TxtCliente"
        Me.TxtCliente.Size = New System.Drawing.Size(120, 20)
        Me.TxtCliente.TabIndex = 2
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(62, 122)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(104, 20)
        Me.Label11.TabIndex = 34
        Me.Label11.Text = "CANTIDAD:"
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(62, 92)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(113, 20)
        Me.Label12.TabIndex = 35
        Me.Label12.Text = "PRODUCTO:"
        '
        'TxtCantidad
        '
        Me.TxtCantidad.Enabled = False
        Me.TxtCantidad.Location = New System.Drawing.Point(172, 120)
        Me.TxtCantidad.Name = "TxtCantidad"
        Me.TxtCantidad.Size = New System.Drawing.Size(120, 20)
        Me.TxtCantidad.TabIndex = 1
        Me.TxtCantidad.Text = "0.00"
        Me.TxtCantidad.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtCantidad.Value = 0
        Me.TxtCantidad.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'Clock
        '
        Me.Clock.Interval = 1000
        '
        'Panel6
        '
        Me.Panel6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel6.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel6.Controls.Add(Me.Panel7)
        Me.Panel6.Controls.Add(Me.Label9)
        Me.Panel6.Controls.Add(Me.LblCantidadArticulos)
        Me.Panel6.Location = New System.Drawing.Point(2, 499)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(118, 50)
        Me.Panel6.TabIndex = 37
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.Gold
        Me.Panel7.Controls.Add(Me.Label7)
        Me.Panel7.Location = New System.Drawing.Point(7, 104)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(166, 59)
        Me.Panel7.TabIndex = 8
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label7.Location = New System.Drawing.Point(7, 15)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 37)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "CANTIDAD PRODUCTOS"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Lucida Sans Unicode", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(3, 9)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(69, 19)
        Me.Label9.TabIndex = 7
        Me.Label9.Text = "CANT."
        '
        'LblCantidadArticulos
        '
        Me.LblCantidadArticulos.BackColor = System.Drawing.Color.Transparent
        Me.LblCantidadArticulos.Font = New System.Drawing.Font("Lucida Sans Unicode", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCantidadArticulos.ForeColor = System.Drawing.Color.Black
        Me.LblCantidadArticulos.Location = New System.Drawing.Point(48, 4)
        Me.LblCantidadArticulos.Name = "LblCantidadArticulos"
        Me.LblCantidadArticulos.Size = New System.Drawing.Size(67, 29)
        Me.LblCantidadArticulos.TabIndex = 10
        Me.LblCantidadArticulos.Text = "14"
        Me.LblCantidadArticulos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblProducto
        '
        Me.LblProducto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblProducto.BackColor = System.Drawing.Color.Transparent
        Me.LblProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblProducto.ForeColor = System.Drawing.Color.Black
        Me.LblProducto.Location = New System.Drawing.Point(297, 89)
        Me.LblProducto.Name = "LblProducto"
        Me.LblProducto.Size = New System.Drawing.Size(498, 22)
        Me.LblProducto.TabIndex = 38
        '
        'GridDetalle
        '
        Me.GridDetalle.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridDetalle.ColumnAutoResize = True
        Me.GridDetalle.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridDetalle.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridDetalle.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.GridDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridDetalle.Location = New System.Drawing.Point(2, 144)
        Me.GridDetalle.Name = "GridDetalle"
        Me.GridDetalle.RecordNavigator = True
        Me.GridDetalle.Size = New System.Drawing.Size(794, 343)
        Me.GridDetalle.TabIndex = 39
        Me.GridDetalle.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnPromocion
        '
        Me.BtnPromocion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnPromocion.Icon = CType(resources.GetObject("BtnPromocion.Icon"), System.Drawing.Icon)
        Me.BtnPromocion.ImageSize = New System.Drawing.Size(20, 20)
        Me.BtnPromocion.Location = New System.Drawing.Point(2, 115)
        Me.BtnPromocion.Name = "BtnPromocion"
        Me.BtnPromocion.Size = New System.Drawing.Size(52, 28)
        Me.BtnPromocion.TabIndex = 40
        Me.BtnPromocion.Text = "F6"
        Me.BtnPromocion.ToolTipText = "Consulta de Promociones Vigentes para el Cliente Actual"
        Me.BtnPromocion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'LblPuntodeVenta
        '
        Me.LblPuntodeVenta.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblPuntodeVenta.BackColor = System.Drawing.Color.Gainsboro
        Me.LblPuntodeVenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPuntodeVenta.ForeColor = System.Drawing.Color.Black
        Me.LblPuntodeVenta.Location = New System.Drawing.Point(600, 32)
        Me.LblPuntodeVenta.Name = "LblPuntodeVenta"
        Me.LblPuntodeVenta.Size = New System.Drawing.Size(196, 23)
        Me.LblPuntodeVenta.TabIndex = 42
        Me.LblPuntodeVenta.Text = "PUNTO DE VENTA"
        Me.LblPuntodeVenta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtProducto
        '
        Me.TxtProducto.Enabled = False
        Me.TxtProducto.Location = New System.Drawing.Point(171, 90)
        Me.TxtProducto.Name = "TxtProducto"
        Me.TxtProducto.Size = New System.Drawing.Size(120, 20)
        Me.TxtProducto.TabIndex = 43
        '
        'BtnRecuperar
        '
        Me.BtnRecuperar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnRecuperar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnRecuperar.Icon = CType(resources.GetObject("BtnRecuperar.Icon"), System.Drawing.Icon)
        Me.BtnRecuperar.ImageSize = New System.Drawing.Size(20, 20)
        Me.BtnRecuperar.Location = New System.Drawing.Point(199, 557)
        Me.BtnRecuperar.Name = "BtnRecuperar"
        Me.BtnRecuperar.Size = New System.Drawing.Size(90, 37)
        Me.BtnRecuperar.TabIndex = 44
        Me.BtnRecuperar.Text = "F7- Recuperar"
        Me.BtnRecuperar.ToolTipText = "Recupera una Cotización o Pedido"
        Me.BtnRecuperar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnConvertir
        '
        Me.BtnConvertir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnConvertir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnConvertir.Icon = CType(resources.GetObject("BtnConvertir.Icon"), System.Drawing.Icon)
        Me.BtnConvertir.ImageSize = New System.Drawing.Size(20, 20)
        Me.BtnConvertir.Location = New System.Drawing.Point(388, 557)
        Me.BtnConvertir.Name = "BtnConvertir"
        Me.BtnConvertir.Size = New System.Drawing.Size(90, 37)
        Me.BtnConvertir.TabIndex = 45
        Me.BtnConvertir.Text = "F8- Convertir"
        Me.BtnConvertir.ToolTipText = "Convierte la Cotización o Pedido a Venta"
        Me.BtnConvertir.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnOtrosDocumentos
        '
        Me.BtnOtrosDocumentos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnOtrosDocumentos.ButtonStyle = Janus.Windows.EditControls.ButtonStyle.DropDownButton
        Me.BtnOtrosDocumentos.ContextMenuStrip = Me.CtxDocumentos
        Me.BtnOtrosDocumentos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnOtrosDocumentos.Icon = CType(resources.GetObject("BtnOtrosDocumentos.Icon"), System.Drawing.Icon)
        Me.BtnOtrosDocumentos.ImageSize = New System.Drawing.Size(20, 20)
        Me.BtnOtrosDocumentos.Location = New System.Drawing.Point(483, 557)
        Me.BtnOtrosDocumentos.Name = "BtnOtrosDocumentos"
        Me.BtnOtrosDocumentos.Size = New System.Drawing.Size(121, 37)
        Me.BtnOtrosDocumentos.TabIndex = 48
        Me.BtnOtrosDocumentos.Text = "F3- Otros Documentos"
        Me.BtnOtrosDocumentos.ToolTipText = "Crea documentos de Apartado, Cotización o Crédito"
        Me.BtnOtrosDocumentos.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'CtxDocumentos
        '
        Me.CtxDocumentos.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ItemApartado, Me.ItemCotizacion, Me.ItemCredito, Me.ItemCambio})
        Me.CtxDocumentos.Name = "CtxDocumentos"
        Me.CtxDocumentos.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.CtxDocumentos.Size = New System.Drawing.Size(124, 92)
        '
        'ItemApartado
        '
        Me.ItemApartado.Image = Global.Selling.My.Resources.Resources.Calendar_Edit_2
        Me.ItemApartado.Name = "ItemApartado"
        Me.ItemApartado.Size = New System.Drawing.Size(123, 22)
        Me.ItemApartado.Text = "Apartado"
        Me.ItemApartado.ToolTipText = "Crea una venta de tipo Apartado"
        Me.ItemApartado.Visible = False
        '
        'ItemCotizacion
        '
        Me.ItemCotizacion.Image = Global.Selling.My.Resources.Resources.kate
        Me.ItemCotizacion.Name = "ItemCotizacion"
        Me.ItemCotizacion.Size = New System.Drawing.Size(123, 22)
        Me.ItemCotizacion.Text = "Pedido"
        Me.ItemCotizacion.ToolTipText = "Crea una Cotización"
        '
        'ItemCredito
        '
        Me.ItemCredito.Image = Global.Selling.My.Resources.Resources.Check_Account
        Me.ItemCredito.Name = "ItemCredito"
        Me.ItemCredito.Size = New System.Drawing.Size(123, 22)
        Me.ItemCredito.Text = "Crédito"
        Me.ItemCredito.ToolTipText = "Crea una venta a crédito"
        '
        'ItemCambio
        '
        Me.ItemCambio.Image = Global.Selling.My.Resources.Resources.wi0102_32
        Me.ItemCambio.Name = "ItemCambio"
        Me.ItemCambio.Size = New System.Drawing.Size(123, 22)
        Me.ItemCambio.Text = "Cambio"
        Me.ItemCambio.ToolTipText = "Realiza Cambio de Producto"
        Me.ItemCambio.Visible = False
        '
        'BtnDeshacer
        '
        Me.BtnDeshacer.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnDeshacer.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnDeshacer.Icon = CType(resources.GetObject("BtnDeshacer.Icon"), System.Drawing.Icon)
        Me.BtnDeshacer.ImageSize = New System.Drawing.Size(20, 20)
        Me.BtnDeshacer.Location = New System.Drawing.Point(293, 557)
        Me.BtnDeshacer.Name = "BtnDeshacer"
        Me.BtnDeshacer.Size = New System.Drawing.Size(90, 37)
        Me.BtnDeshacer.TabIndex = 49
        Me.BtnDeshacer.Text = "F2- Borrar"
        Me.BtnDeshacer.ToolTipText = "Elimina la ultima fila de producto"
        Me.BtnDeshacer.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmTPV
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(800, 600)
        Me.Controls.Add(Me.BtnDeshacer)
        Me.Controls.Add(Me.BtnSalir)
        Me.Controls.Add(Me.BtnOtrosDocumentos)
        Me.Controls.Add(Me.BtnConvertir)
        Me.Controls.Add(Me.BtnRecuperar)
        Me.Controls.Add(Me.TxtProducto)
        Me.Controls.Add(Me.LblPuntodeVenta)
        Me.Controls.Add(Me.GridDetalle)
        Me.Controls.Add(Me.LblProducto)
        Me.Controls.Add(Me.BtnPromocion)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.TxtCantidad)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.TxtCliente)
        Me.Controls.Add(Me.BtnBusquedaProducto)
        Me.Controls.Add(Me.BtnVenta)
        Me.Controls.Add(Me.BtnCerrar)
        Me.Controls.Add(Me.BtnCliente)
        Me.Controls.Add(Me.LblCliente)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.LblUsuario)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.LblFechaHora)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel5)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmTPV"
        Me.Text = "Venta"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CtxDocumentos.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Public bLiquidacion As Boolean = False
    Public ValidaInventario As Boolean = False

    Public ALMClave As String 'Clave del Almacen
    Public PDVClave As String 'Clave de Punto de Venta
    Public Referencia As String 'Referencia de Punto de Venta
    Public PuntodeVenta As String 'Descripcion de Punto de Venta
    Public Supervisor As String 'Supervisor de Punto de Venta
    Public CAJClave As String 'Caja Predeterminada
    Public Redondeo As Boolean 'Aplica programa de redondeo
    Public CambiaPrecio As Boolean 'Muestra pantalla para elegir precio
    Public ModificaPrecioServicio As Boolean ' Muestra pantalla para cambiar presio de productos tipo servicio
    Public Agotamiento As Boolean 'Notificar agotamiento de productos
    Public AtiendeClave As String ' Identificador del Cajero
    Public PorcMaxDesc As Double 'Porcentaje Maximo descuento del vendedor
    Public USRCambiaPrecio As Boolean 'Si se le permite cambiar precios al vendedor
    Public AtiendeNombre As String ' Nombre del Cajero
    Public CTEClaveInicial As String 'Identificador de Cliente Inicial
    Public CTENombreInicial As String 'Nombre de Cliente Inicial
    Public CTEClaveActual As String 'Identificador de Cliente Actual
    Public CTENombreActual As String 'Nombre de Cliente Actual
    Public Folio As Integer = -1
    Public VentaNueva As Boolean = True
    Public GeneraMovSalida As Boolean = False
    Public NumCopias As Integer = 0
    Public SUCClave As String

    Public VENClave As String 'Identificador de la Venta
    Public TotalAhorro As Double = 0.0
    Public TotalArticulos As Double = 0.0
    Public TotalPuntos As Double = 0.0
    Public TotalVenta As Double = 0.0
    Public VentaCerrada As Boolean = True
    Public ListaPrecio As String
    Public TImpuesto As Integer
    Public DescuentoCliente As Integer
    Public PorcDescCliente As Double
    Public TipoDesCte As Integer
    Public DESClave As String
    Public TipoDocumento As Integer

    Private MonedaCambio As String
    Private Moneda As String
    Private MonedaRef As String
    Private TipoCambio As Double

    Public CreditoGeneral As String 'Cliente Credito General
    Private NotaCreditos As String = ""
    Private CreditoDisponible As Double = 0.0

    Public CambiarCliente As Boolean = False
    Private PorcImpProducto As Double
    'Private NumImpuesto As Integer
    Private dtDetalle As DataTable

    Private sPROClave As String
    Private dCantidad As Double = 1
    Private sClave As String
    Private sNombre As String
    Private dCosto As Double
    Private dPrecioBruto As Double
    Private dDescPorc As Double
    Private iTProducto As Integer
    Private iSeguimiento As Integer
    Private iDiasGarantia As Integer
    Private iNumDecimales As Integer
    Private dPuntosPorc As Double

    Private dGeneralNeto As Double
    Private dMinimo As Double
    Private dMinimoNeto As Double

    Private dImporteNeto As Double
    Private dDescuentoImp As Double
    Private addProduct As Boolean = False
    Private Periodo As Integer
    Private Mes As Integer
    Private Finalizar As Boolean = False

    Private Sub Dejar(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCliente.Leave
        TxtProducto.Focus()
    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub FrmTPV_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If VentaCerrada Then
            ModPOS.Ejecuta("sp_actualiza_caja", "@PDVClave", PDVClave, "@Fase", 0)
            ModPOS.PreVenta.Dispose()
            ModPOS.PreVenta = Nothing
        Else
            Beep()
            Select Case MessageBox.Show("El pedido actual no ha sido Cerrado, ¿Desea salir y perder los cambios?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.No
                    e.Cancel = True
                Case DialogResult.Yes
                    ModPOS.Ejecuta("sp_act_folio", "@PDVClave", PDVClave, "@Incremento", -1, "@Tipo", 1)
                    ModPOS.Ejecuta("sp_elimina_venta", "@VENClave", VENClave)
                    ModPOS.Ejecuta("sp_actualiza_caja", "@PDVClave", PDVClave, "@Fase", 0)
                    ModPOS.PreVenta.Dispose()
                    ModPOS.PreVenta = Nothing
            End Select
        End If

        If bLiquidacion = True AndAlso Not ModPOS.Liquid Is Nothing Then
            ModPOS.Liquid.ActualizaGridTransac()
        End If

        If bLiquidacion = True AndAlso Not ModPOS.MtoVenta Is Nothing Then
            ModPOS.MtoVenta.ActualizaGridTransac()
        End If
    End Sub

    Private Sub Controls_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp, BtnBusquedaProducto.KeyUp, BtnCliente.KeyUp, BtnSalir.KeyUp, BtnRecuperar.KeyUp, BtnConvertir.KeyUp, BtnPromocion.KeyUp, BtnVenta.KeyUp, BtnCerrar.KeyUp, TxtCliente.KeyUp, BtnDeshacer.KeyUp
        Select Case e.KeyCode
            Case Is = Keys.Escape
                BtnSalir.PerformClick()
            Case Is = Keys.F1
                Me.BtnBusquedaProducto.PerformClick()
            Case Is = Keys.F2
                Me.BtnDeshacer.PerformClick()
            Case Is = Keys.F6
                Me.BtnPromocion.PerformClick()
            Case Is = Keys.F5
                Me.BtnVenta.PerformClick()
            Case Is = Keys.F4
                Me.BtnCliente.PerformClick()
            Case Is = Keys.F9
                Me.BtnCerrar.PerformClick()
        End Select
    End Sub

    Private Sub ImprimirPedido()
        Dim OpenReport As New Report
        Dim pvtaDataSet As New DataSet
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_encabezado_ped", "@VENClave", VENClave))
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_detalle_ped", "@VENClave", VENClave))
        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_logo_compania", "@COMClave", ModPOS.CompanyActual))
        pvtaDataSet.DataSetName = "pvtaDataSet"
        OpenReport.PrintPreview("Pedido", "CRPedido.rpt", pvtaDataSet, ModPOS.Letras(ModPOS.Redondear(TotalVenta, 2)).ToUpper)
    End Sub

    Private Sub FrmTPDV_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LblPuntodeVenta.Text = PuntodeVenta
        If VentaNueva Then
            CTEClaveActual = CTEClaveInicial
            CTENombreActual = CTENombreInicial
            Me.BtnBusquedaProducto.Enabled = False
            Me.BtnPromocion.Enabled = False
        Else
            Me.BtnBusquedaProducto.Enabled = True
            Me.BtnPromocion.Enabled = True
        End If
        LblCliente.Text = CTENombreActual
        LblUsuario.Text = AtiendeNombre
        LblCantidadPuntos.Text = ModPOS.Redondear(TotalPuntos, 2).ToString("#,##0.00")
        LblCantidadArticulos.Text = CStr(TotalArticulos)
        LblAhorro.Text = Format(CStr(ModPOS.Redondear(TotalAhorro, 2)), "Currency")
        LblTotal.Text = Format(CStr(ModPOS.Redondear(TotalVenta, 2)), "Currency")
        TxtCantidad.Text = CStr(ModPOS.Redondear(dCantidad, 2))
        Me.LblFechaHora.Text = DateTime.Today.ToLongDateString & " " & DateTime.Now.ToShortTimeString 'ToString("MMMM dd, yyyy")

        dtDetalle = ModPOS.CrearTabla("VentaDetalle", _
                                      "DVEClave", "System.String", _
                                      "PROClave", "System.String", _
                                      "Costo", "System.Double", _
                                      "PrecioBruto", "System.Double", _
                                      "PorcImpuesto", "System.Double", _
                                      "PuntosPor", "System.Double", _
                                      "Cantidad", "System.Double", _
                                      "Clave", "System.String", _
                                      "Nombre", "System.String", _
                                      "Precio", "System.Double", _
                                      "Dsc%", "System.Double", _
                                      "Dsc", "System.Double", _
                                      "Pts", "System.Double", _
                                      "Importe", "System.Double", _
                                      "Subtotal", "System.Double", _
                                      "Seguimiento", "System.Int32", _
                                      "DiasGarantia", "System.Int32", _
                                      "TProducto", "System.Int32", _
                                      "Ahorro", "System.Double", _
                                      "Disponible", "System.Double")
        GridDetalle.DataSource = dtDetalle
        GridDetalle.RetrieveStructure(True)
        GridDetalle.GroupByBoxVisible = False
        GridDetalle.RootTable.Columns("DVEClave").Visible = False
        GridDetalle.RootTable.Columns("PROClave").Visible = False
        GridDetalle.RootTable.Columns("Costo").Visible = False
        GridDetalle.RootTable.Columns("PrecioBruto").Visible = False
        GridDetalle.RootTable.Columns("PorcImpuesto").Visible = False
        GridDetalle.RootTable.Columns("PuntosPor").Visible = False
        GridDetalle.RootTable.Columns("Seguimiento").Visible = False
        GridDetalle.RootTable.Columns("DiasGarantia").Visible = False
        GridDetalle.RootTable.Columns("TProducto").Visible = False
        GridDetalle.RootTable.Columns("Ahorro").Visible = False
        GridDetalle.RootTable.Columns("Disponible").Visible = False

        GridDetalle.RootTable.Columns("Cantidad").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        GridDetalle.RootTable.Columns("Precio").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        GridDetalle.RootTable.Columns("Dsc%").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        GridDetalle.RootTable.Columns("Dsc").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        GridDetalle.RootTable.Columns("Pts").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        GridDetalle.RootTable.Columns("Importe").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        GridDetalle.RootTable.Columns("Subtotal").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far


        GridDetalle.RootTable.Columns("Cantidad").Selectable = False
        GridDetalle.RootTable.Columns("Precio").Selectable = False
        GridDetalle.RootTable.Columns("Dsc%").Selectable = False
        GridDetalle.RootTable.Columns("Dsc").Selectable = False
        GridDetalle.RootTable.Columns("Pts").Selectable = False
        GridDetalle.RootTable.Columns("Importe").Selectable = False
        GridDetalle.RootTable.Columns("Subtotal").Selectable = False


        Dim fc As Janus.Windows.GridEX.GridEXFormatCondition
        fc = New Janus.Windows.GridEX.GridEXFormatCondition(GridDetalle.RootTable.Columns("Dsc%"), Janus.Windows.GridEX.ConditionOperator.GreaterThan, 0)
        fc.FormatStyle.ForeColor = Color.Red
        GridDetalle.RootTable.FormatConditions.Add(fc)

        Dim dt As DataTable

        dt = ModPOS.Recupera_Tabla("sp_recupera_parametro", "@COMClave", ModPOS.CompanyActual)
        With Me
            Dim i As Integer
            For i = 0 To dt.Rows.Count - 1
                Select Case CStr(dt.Rows(i)("PARClave"))
                    Case "Moneda"
                        Moneda = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", "", dt.Rows(i)("Valor"))
                    Case "MonedaCambio"
                        MonedaCambio = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", "", dt.Rows(i)("Valor"))
                End Select
            Next
        End With

        dt.Dispose()

        If Moneda <> MonedaCambio Then

            dt = ModPOS.Recupera_Tabla("sp_recupera_moneda", "@Moneda", MonedaCambio)
            MonedaRef = dt.Rows(0)("Referencia")
            TipoCambio = dt.Rows(0)("TipoCambio")
            dt.Dispose()
        Else
            LblTipoCambio.Text = ""
        End If

        If Moneda <> MonedaCambio Then
            If TotalVenta > 0 Then
                LblTipoCambio.Text = MonedaRef.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(TotalVenta / TipoCambio, 2)), "Currency")
            Else
                LblTipoCambio.Text = MonedaRef.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(TotalVenta, 2)), "Currency")
            End If
        End If

        Clock.Start()

    End Sub

    Private Sub Clock_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Clock.Tick
        Me.LblFechaHora.Text = DateTime.Today.ToLongDateString & " " & DateTime.Now.ToShortTimeString 'ToString("MMMM dd, yyyy")
    End Sub

    Private Sub BtnCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCliente.Click
        Dim a As New MeSearch
        a.ProcedimientoAlmacenado = "sp_search_cliente"
        a.TablaCmb = "Cliente"
        a.CampoCmb = "Filtro"
        a.CompaniaRequerido = True
        a.OcultaID = True
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            If Not a.valor Is Nothing Then
                TxtCliente.Text = ""
                CTEClaveActual = a.valor
                CTENombreActual = a.Descripcion2
                LblCliente.Text = CTENombreActual
                ModPOS.Ejecuta("sp_actualiza_PDVCliente", _
                "@VENClave", VENClave, _
                "@Cliente", CTEClaveActual, _
                "@Usuario", ModPOS.UsuarioActual)
                TxtProducto.Focus()
            End If
        End If
        a.Dispose()
    End Sub

    Private Sub crearDoc(ByVal iTipo As Integer)
        If VentaCerrada Then

            Me.BtnBusquedaProducto.Enabled = True
            Me.BtnPromocion.Enabled = True

            If iTipo = 1 Then
                LblPuntodeVenta.ForeColor = Color.White
                LblPuntodeVenta.Text = "VENTA ABIERTA"
                LblPuntodeVenta.BackColor = Color.Green
            ElseIf iTipo = 2 Then
                LblPuntodeVenta.ForeColor = Color.White
                LblPuntodeVenta.Text = "PEDIDO ABIERTO"
                LblPuntodeVenta.BackColor = Color.Green
            ElseIf iTipo = 3 Then
                LblPuntodeVenta.ForeColor = Color.White
                LblPuntodeVenta.Text = "CRÉDITO ABIERTO"
                LblPuntodeVenta.BackColor = Color.Green
            End If



            Dim dt As DataTable

            CTEClaveActual = CTEClaveInicial
            CTENombreActual = CTENombreInicial
            LblCliente.Text = CTENombreActual
            TxtProducto.Enabled = True
            TxtCantidad.Enabled = True
            BtnCliente.Enabled = True
            TxtCliente.Enabled = True


            If CambiarCliente = False Then
                BtnCliente.Enabled = True
                TxtCliente.Enabled = True
                CambiarCliente = True
            End If

            If iTipo = 3 Then
                Dim b As New FrmSolicitaCliente
                b.ClienteInicial = CTEClaveInicial
                b.ValidaCredito = True
                b.CreditoGeneral = CreditoGeneral
                b.ShowDialog()
                If b.DialogResult = DialogResult.OK Then
                    CTEClaveActual = b.ClienteClave
                    CTENombreActual = b.ClienteNombre
                    LblCliente.Text = CTENombreActual
                    NotaCreditos = b.Nota
                Else
                    CTEClaveActual = CTEClaveInicial
                    CTENombreActual = CTENombreInicial
                    LblCliente.Text = CTENombreActual
                    MessageBox.Show("No es posible crear una venta a crédito debido a que no se ha especificado al cliente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                b.Dispose()
            End If

            If Moneda <> MonedaCambio Then
                dt = ModPOS.Recupera_Tabla("sp_recupera_moneda", "@Moneda", MonedaCambio)
                MonedaRef = dt.Rows(0)("Referencia")
                TipoCambio = dt.Rows(0)("TipoCambio")
                dt.Dispose()
            Else
                LblTipoCambio.Text = ""
            End If

            dt = ModPOS.SiExisteRecupera("sp_recupera_folio", "@Tipo", 1, "@PDVClave", PDVClave)

            If dt Is Nothing Then
                ModPOS.Ejecuta("sp_crea_folio", "@Tipo", 1, "@PDVClave", PDVClave)
                Periodo = Today.Year
                Mes = Today.Month
                Folio = 1
            Else

                Folio = CInt(dt.Rows(0)("UltimoConsecutivo")) + 1
                Periodo = dt.Rows(0)("Periodo")
                Mes = dt.Rows(0)("Mes")
                ModPOS.Ejecuta("sp_act_folio", "@Tipo", 1, "@PDVClave", PDVClave, "@Incremento", 1)

                dt.Dispose()
            End If

            LblFolio.Text = Referencia & "-" & CStr(Folio) & "-" & CStr(Periodo) & CStr(Mes)

            TipoDocumento = iTipo

            VENClave = ModPOS.obtenerLlave()

            ModPOS.Ejecuta("sp_crea_venta", _
            "@VENClave", VENClave, _
            "@PDVClave", PDVClave, _
            "@Folio", LblFolio.Text, _
            "@Cliente", CTEClaveActual, _
            "@Cajero", AtiendeClave, _
            "@CAJClave", CAJClave, _
            "@Tipo", TipoDocumento, _
            "@Usuario", ModPOS.UsuarioActual)

            BtnCliente.Enabled = True
            BtnCerrar.Enabled = True
            TxtCantidad.Enabled = True
            TxtProducto.Enabled = True
            TxtCliente.Enabled = True
            VentaCerrada = False
            GeneraMovSalida = True


            TotalArticulos = 0
            TotalPuntos = 0
            TotalVenta = 0
            TotalAhorro = 0

            LblCantidadPuntos.Text = ModPOS.Redondear(TotalPuntos, 2).ToString("#,##0.00")
            LblCantidadArticulos.Text = CStr(TotalArticulos)
            LblAhorro.Text = Format(CStr(ModPOS.Redondear(TotalAhorro, 2)), "Currency")
            LblTotal.Text = Format(CStr(ModPOS.Redondear(TotalVenta, 2)), "Currency")

            If Moneda <> MonedaCambio Then
                If TotalVenta > 0 Then
                    LblTipoCambio.Text = MonedaRef.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(TotalVenta / TipoCambio, 2)), "Currency")
                Else
                    LblTipoCambio.Text = MonedaRef.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(TotalVenta, 2)), "Currency")
                End If
            End If

        Else
            Beep()
            MessageBox.Show("No es posible crear un nuevo pedido debido a que el pedido actual no ha sido Cerrado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        TxtProducto.Focus()
    End Sub
    Private Sub BtnNuevoTicket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnVenta.Click
        crearDoc(1)
    End Sub

    Public Sub AgregaClave(ByVal sClave As String)
        txtProductoAdd(sClave)
    End Sub

    Private Sub RecuperaProducto(ByVal dt As DataTable)
        LblProducto.Text = dt.Rows(0)("Nombre")
        sPROClave = dt.Rows(0)("PROClave")
        sClave = dt.Rows(0)("Clave")
        sNombre = dt.Rows(0)("Nombre")
        dCosto = dt.Rows(0)("Costo")
        dPrecioBruto = dt.Rows(0)("PrecioBruto")
        dDescPorc = dt.Rows(0)("DescPorc")
        iTProducto = dt.Rows(0)("TProducto")
        iSeguimiento = dt.Rows(0)("Seguimiento")
        iDiasGarantia = dt.Rows(0)("DiasGarantia")
        iNumDecimales = dt.Rows(0)("Num_Decimales")
        dPuntosPorc = dt.Rows(0)("PuntosPorc")

        dGeneralNeto = dt.Rows(0)("GeneralNeto")
        
        dMinimoNeto = dt.Rows(0)("MinimoNeto")

        dt.Dispose()

        PorcImpProducto = ModPOS.RecuperaImpuesto(succlave, sPROClave, TImpuesto)

        If TImpuesto = 1 Then
            dImporteNeto = dGeneralNeto
        
        End If

        'dImporteNeto = Redondear(dPrecioBruto * (1 + PorcImpProducto), 2)

        dDescuentoImp = dImporteNeto * dDescPorc

        TxtCantidad.DecimalDigits = iNumDecimales


        Dim foundRows() As System.Data.DataRow
        foundRows = dtDetalle.Select("PROClave = '" & sPROClave & "'")
        If foundRows.Length = 0 Then
            Dim dtpromocion As DataTable = ModPOS.SiExisteRecupera("sp_filtra_promocion_vigente_producto", "@CTEClave", CTEClaveActual, "@PROClave", sPROClave)
            If Not dtpromocion Is Nothing Then
                Dim a As New FrmConsultaGen
                a.Text = "Promociones Vigentes"
                a.GridConsultaGen.DataSource = dtpromocion
                a.GridConsultaGen.RetrieveStructure(True)
                a.GridConsultaGen.BuiltInTexts(Janus.Windows.GridEX.GridEXBuiltInText.GroupByBoxInfo) = "Arrastre el encabezado de la columna aquí para agrupar por esa columna."
                a.ShowDialog()
                a.Dispose()
                dtpromocion.Dispose()
            End If
        End If

        If ModificaPrecioServicio AndAlso iTProducto >= 4 Then
            dCantidad = 1
            Dim a As New FrmAddProducto
            a.PDVClave = PDVClave
            a.TImpuesto = TImpuesto
            a.Tipo = TipoDocumento
            a.PREClave = ListaPrecio
            a.PROClave = sPROClave
            a.NombreCliente = CTENombreActual
            a.Clave = sClave
            a.Nombre = sNombre
            a.ImporteNeto = dImporteNeto
            a.Cantidad = dCantidad
            a.Costo = dCosto
            a.PrecioBruto = dPrecioBruto
            a.FactorImpuesto = PorcImpProducto
            a.DescImp = dDescuentoImp
            a.PorcDesc = dDescPorc
            '   a.PorcPts = dPuntosPorc
            a.NumDecimal = iNumDecimales
            a.ModificaPrecioServicio = Me.ModificaPrecioServicio
            a.iTProducto = iTProducto
            a.CambiaPrecio = USRCambiaPrecio
            a.PorcMaxDesc = PorcMaxDesc
            a.MinimoNeto = dMinimoNeto

            a.ShowDialog()
            If a.DialogResult = DialogResult.OK Then
                dCantidad = a.Cantidad
                dDescPorc = a.PorcDesc
                dDescuentoImp = a.ImporteNeto * a.PorcDesc
                dImporteNeto = a.ImporteNeto
                dPrecioBruto = a.PrecioBruto
                a.Dispose()


                AgregaPartida()
                Exit Sub
            Else
                a.Dispose()
                dCantidad = 0
                TxtCantidad.Text = "0"
                LblProducto.Text = ""
                TxtProducto.Text = ""
                sPROClave = ""
                sClave = ""
                sNombre = ""
                dCosto = 0
                dPrecioBruto = 0
                dDescPorc = 0
                iTProducto = 0
                iSeguimiento = 0
                iDiasGarantia = 0
                iNumDecimales = 0
                dPuntosPorc = 0
                TxtProducto.Focus()
                Exit Sub
            End If
            'Si Cambia Precio = True 
        ElseIf CambiaPrecio Then
            dCantidad = 1

            Dim a As New FrmAddProducto
            a.PDVClave = PDVClave
            a.TImpuesto = TImpuesto
            a.Tipo = TipoDocumento
            a.PREClave = ListaPrecio
            a.PROClave = sPROClave
            a.NombreCliente = CTENombreActual
            a.Clave = sClave
            a.Nombre = sNombre
            a.ImporteNeto = dImporteNeto
            a.Cantidad = dCantidad
            a.Costo = dCosto
            a.PrecioBruto = dPrecioBruto
            a.FactorImpuesto = PorcImpProducto
            a.DescImp = dDescuentoImp
            a.PorcDesc = dDescPorc
            'a.PorcPts = dPuntosPorc
            a.NumDecimal = iNumDecimales
            a.ModificaPrecioServicio = Me.ModificaPrecioServicio
            a.iTProducto = iTProducto
            a.CambiaPrecio = USRCambiaPrecio
            a.PorcMaxDesc = PorcMaxDesc
            a.MinimoNeto = dMinimoNeto

            a.ShowDialog()
            If a.DialogResult = DialogResult.OK Then
                dCantidad = a.Cantidad
                dDescPorc = a.PorcDesc
                dDescuentoImp = a.ImporteNeto * a.PorcDesc
                dImporteNeto = a.ImporteNeto
                dPrecioBruto = a.PrecioBruto
                a.Dispose()

                AgregaPartida()
                Exit Sub
            Else
                a.Dispose()
                dCantidad = 0
                TxtCantidad.Text = "0"
                LblProducto.Text = ""
                TxtProducto.Text = ""
                sPROClave = ""
                sClave = ""
                sNombre = ""
                dCosto = 0
                dPrecioBruto = 0
                dDescPorc = 0
                iTProducto = 0
                iSeguimiento = 0
                iDiasGarantia = 0
                iNumDecimales = 0
                dPuntosPorc = 0
                TxtProducto.Focus()
                Exit Sub
            End If
        End If
        TxtCantidad.Focus()
    End Sub

    Private Sub AgregaPartida()
        'Bloquea al cliente para no permitir que se modifique la lista de precios cuando ya hay productos en la venta
        If CambiarCliente = True Then
            BtnCliente.Enabled = False
            TxtCliente.Enabled = False
            CambiarCliente = False
        End If

        'SI VALIDA INVENTARIO

        If ValidaInventario = True AndAlso TipoDocumento <> 2 Then
            Dim Disponible As Double

            Dim dtDisponible As DataTable
            dtDisponible = ModPOS.SiExisteRecupera("sp_search_existencia", "@PROClave", sPROClave, "@ALMClave", ALMClave)
            If Not dtDisponible Is Nothing AndAlso dtDisponible.Rows.Count > 0 Then
                Disponible = dtDisponible.Rows(0)("Disponible")
                dtDisponible.Dispose()
            Else
                Disponible = 0
            End If

            If dCantidad > Disponible Then
                MessageBox.Show("La cantidad registrada excede la cantidad disponible en el almacén origen, el disponible actual es de: " & CStr(Disponible), "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

        End If

        Dim dPrecioNeto As Double = (dPrecioBruto - (dPrecioBruto * dDescPorc)) * (1 + PorcImpProducto)

        Dim foundRows() As System.Data.DataRow
        foundRows = dtDetalle.Select("PROClave = '" & sPROClave & "' and Importe = " & CStr(Redondear(dImporteNeto - dDescuentoImp, 2)))

        If foundRows.Length = 0 Then
            If dCantidad > 0 Then
                Dim row1 As DataRow
                row1 = dtDetalle.NewRow()
                'declara el nombre de la fila
                row1.Item("DVEClave") = ModPOS.obtenerLlave
                row1.Item("PROClave") = sPROClave
                row1.Item("Costo") = dCosto
                row1.Item("PrecioBruto") = dPrecioBruto
                row1.Item("PorcImpuesto") = PorcImpProducto
                row1.Item("PuntosPor") = dPuntosPorc
                row1.Item("Cantidad") = dCantidad
                row1.Item("Clave") = sClave
                row1.Item("Nombre") = sNombre
                row1.Item("Precio") = Redondear(dPrecioBruto * (1 + PorcImpProducto), 2)
                row1.Item("Dsc%") = dDescPorc * 100
                row1.Item("Dsc") = Redondear(dDescuentoImp, 2)
                row1.Item("Pts") = Redondear((dCantidad * dPrecioNeto) * dPuntosPorc, 2)
                row1.Item("Importe") = Redondear(dPrecioNeto, 2)
                row1.Item("Subtotal") = Redondear(dCantidad * dPrecioNeto, 2)
                row1.Item("Seguimiento") = iSeguimiento
                row1.Item("DiasGarantia") = iDiasGarantia
                row1.Item("TProducto") = iTProducto
                row1.Item("Ahorro") = Redondear(dCantidad * dDescuentoImp, 2)
                row1.Item("Disponible") = 0

                dtDetalle.Rows.Add(row1)
                'agrega la fila completo a la tabla
                TotalArticulos += 1
            End If
        ElseIf dCantidad = 0 Then
            'Elimina
            dtDetalle.Rows.Remove(foundRows(0))
        Else
            'actualiza
            foundRows(0)("Dsc%") = Redondear(dDescPorc * 100, 2)
            foundRows(0)("Dsc") = Redondear(dDescuentoImp, 2)
            foundRows(0)("Pts") = Redondear((dCantidad * dPrecioNeto) * dPuntosPorc, 2)
            foundRows(0)("PrecioBruto") = dPrecioBruto
            foundRows(0)("Precio") = Redondear(dPrecioBruto * (1 + PorcImpProducto), 2)
            foundRows(0)("Cantidad") = dCantidad
            foundRows(0)("Importe") = Redondear(dPrecioNeto, 2)
            foundRows(0)("Subtotal") = Redondear(dCantidad * dPrecioNeto, 2)
            foundRows(0)("Ahorro") = Redondear(dCantidad * dDescuentoImp, 2)

        End If

        dCantidad = 0
        TxtCantidad.Text = "0"
        LblProducto.Text = ""
        TxtProducto.Text = ""
        sPROClave = ""
        sClave = ""
        sNombre = ""
        dCosto = 0
        dPrecioBruto = 0
        dDescPorc = 0
        iTProducto = 0
        iSeguimiento = 0
        iDiasGarantia = 0
        iNumDecimales = 0
        dPuntosPorc = 0


        TotalPuntos = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Pts"), Janus.Windows.GridEX.AggregateFunction.Sum)
        TotalAhorro = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Ahorro"), Janus.Windows.GridEX.AggregateFunction.Sum)
        TotalVenta = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Subtotal"), Janus.Windows.GridEX.AggregateFunction.Sum)

        LblCantidadPuntos.Text = ModPOS.Redondear(TotalPuntos, 2).ToString("#,##0.00")
        LblCantidadArticulos.Text = CStr(TotalArticulos)
        LblAhorro.Text = Format(CStr(ModPOS.Redondear(TotalAhorro, 2)), "Currency")
        LblTotal.Text = Format(CStr(ModPOS.Redondear(TotalVenta, 2)), "Currency")

        If Moneda <> MonedaCambio Then
            If TotalVenta > 0 Then
                LblTipoCambio.Text = MonedaRef.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(TotalVenta / TipoCambio, 2)), "Currency")
            Else
                LblTipoCambio.Text = MonedaRef.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(TotalVenta, 2)), "Currency")
            End If
        End If

        GridDetalle.MoveLast()



    End Sub

    Private Sub TxtCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCliente.KeyPress
        If (Asc(e.KeyChar)) = 13 Then
            If Not TxtCliente.Text = vbNullString Then
                Dim dt As DataTable

                dt = ModPOS.SiExisteRecupera("sp_recupera_clavecte", "@Clave", TxtCliente.Text.Trim.ToUpper.Replace("'", "''"))

                If Not dt Is Nothing Then
                    CTEClaveActual = dt.Rows(0)("CTEClave")
                    CTENombreActual = dt.Rows(0)("RazonSocial")
                    LblCliente.Text = CTENombreActual
                    TxtCliente.Text = ""

                    dt.Dispose()

                    ModPOS.Ejecuta("sp_actualiza_PDVCliente", _
                                                "@VENClave", VENClave, _
                                                "@Cliente", CTEClaveActual, _
                                                "@Usuario", ModPOS.UsuarioActual)
                    TxtProducto.Focus()
                Else
                    LblCliente.Text = ""
                    TxtCliente.Text = ""
                End If

            End If
        End If
    End Sub

    Private Sub TxtCantidad_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCantidad.Leave
        If TxtCantidad.Text > 0 Then
            If sPROClave = "" Then
                Beep()
                MessageBox.Show("¡La Clave de producto es requerida!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            Else
                dCantidad = Math.Abs(CDbl(TxtCantidad.Text))
                AgregaPartida()
                TxtProducto.Focus()
            End If
        End If
    End Sub

    Private Sub TxtCantidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCantidad.KeyPress
        If Asc(e.KeyChar) = 13 AndAlso Not System.String.IsNullOrEmpty(TxtCantidad.Text) Then
            If sPROClave = "" Then
                Beep()
                MessageBox.Show("¡La Clave de producto es requerida!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            Else
                dCantidad = Math.Abs(CDbl(TxtCantidad.Text))
                AgregaPartida()
                TxtProducto.Focus()
            End If
        End If
    End Sub


    Private Sub txtProductoAdd(ByVal sProducto As String)
        If VentaCerrada = False Then
            'Valida que el campo producto no se encuentre vacio
            If Not System.String.IsNullOrEmpty(sProducto) Then

                'Si es el primer articulo, recupera la lista de precio del cliente actual
                If TotalArticulos = 0 Then
                    Dim dtCliente As DataTable
                    dtCliente = ModPOS.Recupera_Tabla("sp_venta_lista", "@Cliente", CTEClaveActual)
                    ListaPrecio = dtCliente.Rows(0)("PREClave")
                    TImpuesto = dtCliente.Rows(0)("TipoImpuesto")
                    dtCliente.Dispose()

                    'Recupera los descuentos de cliente
                    Dim dtDescCte As DataTable = ModPOS.SiExisteRecupera("sp_venta_descuento", "@Cliente", CTEClaveActual)
                    If Not dtDescCte Is Nothing Then
                        DescuentoCliente = Math.Abs(CInt(dtDescCte.Rows(0)("Cascada")))
                        PorcDescCliente = dtDescCte.Rows(0)("DescuentoPorc")
                        TipoDesCte = dtDescCte.Rows(0)("TipoAplicacion")
                        DESClave = dtDescCte.Rows(0)("DESClave")
                        dtDescCte.Dispose()
                    Else
                        DescuentoCliente = -1
                        PorcDescCliente = 0
                        TipoDesCte = 0
                        DESClave = ""
                    End If

                End If

                'Busca y recupera los datos del producto
                Dim dt As DataTable = ModPOS.SiExisteRecupera("sp_venta_producto", "@Tipo", 1, "@Busca", sProducto.Trim.ToUpper.Replace("'", "''"), "@ListaPrecio", ListaPrecio, "@Cantidad", 1)

                If Not dt Is Nothing Then
                    RecuperaProducto(dt)
                Else
                    LblProducto.Text = ""
                    TxtProducto.Text = ""
                    dCantidad = 0
                    TxtCantidad.Text = "0"
                    sPROClave = ""
                    sClave = ""
                    sNombre = ""
                    dCosto = 0
                    dPrecioBruto = 0
                    dDescPorc = 0
                    iTProducto = 0
                    iSeguimiento = 0
                    iDiasGarantia = 0
                    iNumDecimales = 0
                    dPuntosPorc = 0
                    Beep()
                    MessageBox.Show("La Clave no corresponde a un Producto Existente o Activo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        End If
    End Sub


    Private Sub TxtProducto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtProducto.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtProductoAdd(TxtProducto.Text)
        End If
    End Sub

    Private Sub TxtProducto_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtProducto.KeyUp
        Select Case e.KeyCode
            Case Is = Keys.Escape
                BtnSalir.PerformClick()
            Case Is = Keys.F1
                Me.BtnBusquedaProducto.PerformClick()
            Case Is = Keys.F6
                Me.BtnPromocion.PerformClick()
            Case Is = Keys.F5
                Me.BtnVenta.PerformClick()
            Case Is = Keys.F4
                Me.BtnCliente.PerformClick()
            Case Is = Keys.F9
                Me.BtnCerrar.PerformClick()
            Case Is = Keys.Right
                If VentaCerrada = False Then
                    'Si es el primer articulo, recupera la lista de precio del cliente actual
                    If TotalArticulos = 0 Then
                        Dim dtCliente As DataTable
                        dtCliente = ModPOS.Recupera_Tabla("sp_venta_lista", "@Cliente", CTEClaveActual)
                        ListaPrecio = dtCliente.Rows(0)("PREClave")
                        TImpuesto = dtCliente.Rows(0)("TipoImpuesto")
                        dtCliente.Dispose()
                        'Recupera los descuentos de cliente
                        Dim dtDescCte As DataTable = ModPOS.SiExisteRecupera("sp_venta_descuento", "@Cliente", CTEClaveActual)
                        If Not dtDescCte Is Nothing Then
                            DescuentoCliente = Math.Abs(CInt(dtDescCte.Rows(0)("Cascada")))
                            PorcDescCliente = dtDescCte.Rows(0)("DescuentoPorc")
                            TipoDesCte = dtDescCte.Rows(0)("TipoAplicacion")
                            DESClave = dtDescCte.Rows(0)("DESClave")
                            dtDescCte.Dispose()
                        Else
                            DescuentoCliente = -1
                            PorcDescCliente = 0
                            TipoDesCte = 0
                            DESClave = ""
                        End If
                    End If
                    'Busca y recupera los datos del producto
                    Dim a As New MeSearch
                    a.ProcedimientoAlmacenado = "sp_search_producto_vta"
                    a.TablaCmb = "Producto"
                    a.CampoCmb = "Filtro"
                    a.NumColDes = 2
                    a.BusquedaInicial = True
                    a.Busqueda = TxtProducto.Text.Trim.ToUpper
                    a.AlmRequerido = True
                    a.ALMClave = ALMClave
                    a.ListaPrecio = ListaPrecio
                    a.TipoRequerido = True
                    a.Tipo = TImpuesto
                    a.CompaniaRequerido = True
                    a.ShowDialog()
                    If a.DialogResult = DialogResult.OK Then

                        Dim dt As DataTable = ModPOS.SiExisteRecupera("sp_venta_producto", "@Tipo", 2, "@Busca", a.valor, "@ListaPrecio", ListaPrecio, "@Cantidad", dCantidad)
                        RecuperaProducto(dt)
                        dt.Dispose()
                    End If
                    a.Dispose()

                End If
            Case Is = Keys.F2
                If VentaCerrada = False Then
                    'Si el campo cantidad esta vacio lo cambia a 1 por defecto
                    If TxtCantidad.Text = vbNullString OrElse CDbl(TxtCantidad.Text) = 0 Then
                        dCantidad = 1
                        TxtCantidad.Text = "1"
                    End If
                    'Si es el primer articulo, recupera la lista de precio del cliente actual
                    If TotalArticulos = 0 Then
                        Dim dtCliente As DataTable
                        dtCliente = ModPOS.Recupera_Tabla("sp_venta_lista", "@Cliente", CTEClaveActual)
                        ListaPrecio = dtCliente.Rows(0)("PREClave")
                        TImpuesto = dtCliente.Rows(0)("TipoImpuesto")
                        dtCliente.Dispose()
                        'Recupera los descuentos de cliente
                        Dim dtDescCte As DataTable = ModPOS.SiExisteRecupera("sp_venta_descuento", "@Cliente", CTEClaveActual)
                        If Not dtDescCte Is Nothing Then
                            DescuentoCliente = Math.Abs(CInt(dtDescCte.Rows(0)("Cascada")))
                            PorcDescCliente = dtDescCte.Rows(0)("DescuentoPorc")
                            TipoDesCte = dtDescCte.Rows(0)("TipoAplicacion")
                            DESClave = dtDescCte.Rows(0)("DESClave")
                            dtDescCte.Dispose()
                        Else
                            DescuentoCliente = -1
                            PorcDescCliente = 0
                            TipoDesCte = 0
                            DESClave = ""
                        End If
                    End If
                    'Busca y recupera los datos del producto
                    Dim a As New MeSearch
                    a.ProcedimientoAlmacenado = "sp_search_producto_vta"
                    a.TablaCmb = "Producto"
                    a.CampoCmb = "Filtro"
                    a.NumColDes = 2
                    a.BusquedaInicial = True
                    a.Busqueda = TxtProducto.Text.Trim.ToUpper
                    a.AlmRequerido = True
                    a.ALMClave = ALMClave
                    a.ListaPrecio = ListaPrecio
                    a.TipoRequerido = True
                    a.Tipo = TImpuesto
                    a.CompaniaRequerido = True

                    a.ShowDialog()
                    If a.DialogResult = DialogResult.OK Then

                        Dim dt As DataTable = ModPOS.SiExisteRecupera("sp_venta_producto", "@Tipo", 2, "@Busca", a.valor, "@ListaPrecio", ListaPrecio, "@Cantidad", dCantidad)
                        RecuperaProducto(dt)
                        dt.Dispose()
                    End If
                    a.Dispose()

                End If
        End Select
    End Sub

    'Private Sub agregaRow(ByVal dt As DataTable, ByVal PRMClave As String, ByVal TipoCalculoBase As Integer, ByVal Clave As String, ByVal Descripcion As String, ByVal DVEClave As String, ByVal PROClave As String, ByVal Cantidad As Double, ByVal Promocion As Double, ByVal Precio As Double, ByVal PrecioNeto As Double, ByVal TotalPartida As Double)
    '    Dim row1 As DataRow
    '    row1 = dt.NewRow()
    '    row1.Item("PRMClave") = PRMClave
    '    row1.Item("TipoCalculoBase") = TipoCalculoBase
    '    row1.Item("Clave") = Clave
    '    row1.Item("Descripcion") = Descripcion
    '    row1.Item("DVEClave") = DVEClave
    '    row1.Item("PROClave") = PROClave
    '    row1.Item("Cantidad") = Cantidad
    '    row1.Item("Promocion") = Promocion
    '    row1.Item("Precio") = Precio
    '    row1.Item("PrecioNeto") = PrecioNeto
    '    row1.Item("TotalPartida") = TotalPartida
    '    dt.Rows.Add(row1)
    'End Sub

    Private Sub agregaRow(ByRef dt As DataTable, ByVal PRMClave As String, ByVal Inicial As Integer, ByVal Final As Integer, ByVal TipoCalculoBase As Integer, ByVal Clave As String, ByVal Descripcion As String, ByVal DVEClave As String, ByVal PROClave As String, ByVal Cantidad As Double, ByVal Promocion As Double, ByVal Precio As Double, ByVal PrecioNeto As Double, ByVal TotalPartida As Double, ByVal MaxNumPromo As Integer, ByVal Saldo As Double, ByVal Iguales As Boolean)
        Dim row1 As DataRow
        row1 = dt.NewRow()
        row1.Item("PRMClave") = PRMClave
        row1.Item("Inicial") = Inicial
        row1.Item("Final") = Final
        row1.Item("TipoCalculoBase") = TipoCalculoBase
        row1.Item("Clave") = Clave
        row1.Item("Descripcion") = Descripcion
        row1.Item("DVEClave") = DVEClave
        row1.Item("PROClave") = PROClave
        row1.Item("Cantidad") = Cantidad
        row1.Item("Promocion") = Promocion
        row1.Item("Precio") = Precio
        row1.Item("PrecioNeto") = PrecioNeto
        row1.Item("TotalPartida") = TotalPartida
        row1.Item("MaxNumPromo") = MaxNumPromo
        row1.Item("Saldo") = Saldo
        row1.Item("Iguales") = Iguales
        dt.Rows.Add(row1)
    End Sub


    Private Sub eliminaRow(ByVal dt As DataTable, ByVal PRMClave As String)
        Dim foundRows() As System.Data.DataRow
        foundRows = dt.Select("PRMClave Like '" & PRMClave & "'")
        dt.Rows.Remove(foundRows(0))
    End Sub

    'Private Sub AplicaPromociones(ByVal PRMClave As String, ByVal Tipo As Integer, ByVal dt As DataTable, ByVal Numero As Integer)
    '    Dim TotalImportePromocion As Double = 0
    '    Dim TotalImporteNetoPromocion As Double = 0
    '    Dim ImportePromocion As Double = 0
    '    Dim i As Integer

    '    Select Case Tipo
    '        Case Is = 1 'Descuentos
    '            Dim dtPromDet As DataTable
    '            Dim CantidadInicial As Double
    '            Dim CantidadFinal As Double

    '            dtPromDet = ModPOS.Recupera_Tabla("sp_detalle_promocion", "@PRMClave", PRMClave)

    '            For i = 0 To dt.Rows.Count - 1

    '                Dim foundRows() As System.Data.DataRow
    '                foundRows = dtPromDet.Select("PROClave Like '" & dt.Rows(i)("PROClave") & "'")

    '                If foundRows.Length > 0 Then
    '                    CantidadInicial = foundRows(0)("Cantidad")
    '                    CantidadFinal = foundRows(0)("CantidadFinal")
    '                Else
    '                    CantidadInicial = 1
    '                    CantidadFinal = 1
    '                End If

    '                If dt.Rows(i)("TipoCalculoBase") = 1 Then
    '                    ImportePromocion = (Numero * CantidadInicial) * ((dt.Rows(i)("Promocion") / 100) * dt.Rows(i)("Precio"))
    '                    TotalImportePromocion += ImportePromocion
    '                    TotalImporteNetoPromocion += (Numero * CantidadInicial) * ((dt.Rows(i)("Promocion") / 100) * dt.Rows(i)("PrecioNeto"))
    '                Else
    '                    If dt.Rows(i)("Cantidad") > CantidadFinal Then
    '                        ImportePromocion = (Numero * CantidadFinal) * ((dt.Rows(i)("Promocion") / 100) * dt.Rows(i)("Precio"))
    '                        TotalImportePromocion += ImportePromocion
    '                        TotalImporteNetoPromocion += (Numero * CantidadFinal) * ((dt.Rows(i)("Promocion") / 100) * dt.Rows(i)("PrecioNeto"))
    '                    Else
    '                        ImportePromocion = (Numero * dt.Rows(i)("Cantidad")) * ((dt.Rows(i)("Promocion") / 100) * dt.Rows(i)("Precio"))
    '                        TotalImportePromocion += ImportePromocion
    '                        TotalImporteNetoPromocion += (Numero * dt.Rows(i)("Cantidad")) * ((dt.Rows(i)("Promocion") / 100) * dt.Rows(i)("PrecioNeto"))
    '                    End If
    '                End If

    '                'ImportePromocion = Numero * ((dt.Rows(i)("Promocion") / 100) * dt.Rows(i)("Precio"))
    '                'TotalImportePromocion += ImportePromocion
    '                'TotalImporteNetoPromocion += Numero * ((dt.Rows(i)("Promocion") / 100) * dt.Rows(i)("PrecioNeto"))

    '                If dt.Rows(i)("Promocion") > 0 Then
    '                    ModPOS.Ejecuta("sp_aplica_promocion", _
    '                                    "@PRMClave", dt.Rows(i)("PRMClave"), _
    '                                    "@VENTA", VENClave, _
    '                                    "@DVEClave", dt.Rows(i)("DVEClave"), _
    '                                    "@PROClave", dt.Rows(i)("PROClave"), _
    '                                    "@Tipo", Tipo, _
    '                                    "@Porcentaje", ImportePromocion / (dt.Rows(i)("Precio") * dt.Rows(i)("Cantidad")), _
    '                                    "@Importe", ImportePromocion / dt.Rows(i)("Cantidad"), _
    '                                    "@Usuario", ModPOS.UsuarioActual)

    '                    Dim dtDet As DataTable
    '                    dtDet = ModPOS.SiExisteRecupera("sp_ventadetalle_open", "@VENClave", VENClave)
    '                    If Not dtDet Is Nothing AndAlso dtDet.Rows.Count() > 0 Then
    '                        ModPOS.RecalculaImpuesto(dtDet, TImpuesto)
    '                        dtDet.Dispose()
    '                    End If

    '                End If
    '            Next

    '            TotalAhorro += TotalImporteNetoPromocion
    '            TotalVenta -= TotalImporteNetoPromocion

    '            LblAhorro.Text = Format(CStr(ModPOS.Redondear(TotalAhorro, 2)), "Currency")
    '            LblTotal.Text = Format(CStr(ModPOS.Redondear(TotalVenta, 2)), "Currency")


    '        Case Is = 2 'Bonificacion
    '            For i = 0 To dt.Rows.Count - 1
    '                ImportePromocion = Numero * dt.Rows(i)("Promocion")
    '                TotalImportePromocion += ImportePromocion

    '                If dt.Rows(i)("Promocion") > 0 Then
    '                    ModPOS.Ejecuta("sp_aplica_promocion", _
    '                                    "@PRMClave", dt.Rows(i)("PRMClave"), _
    '                                    "@VENTA", VENClave, _
    '                                    "@DVEClave", dt.Rows(i)("DVEClave"), _
    '                                    "@PROClave", dt.Rows(i)("PROClave"), _
    '                                    "@Tipo", Tipo, _
    '                                    "@Porcentaje", ImportePromocion / (dt.Rows(i)("Precio") * dt.Rows(i)("Cantidad")), _
    '                                    "@Importe", ImportePromocion / dt.Rows(i)("Cantidad"), _
    '                                    "@Usuario", ModPOS.UsuarioActual)

    '                    Dim dtDet As DataTable
    '                    dtDet = ModPOS.SiExisteRecupera("sp_ventadetalle_open", "@VENClave", VENClave)
    '                    If Not dtDet Is Nothing AndAlso dtDet.Rows.Count() > 0 Then
    '                        ModPOS.RecalculaImpuesto(dtDet, TImpuesto)
    '                        dtDet.Dispose()
    '                    End If

    '                End If
    '            Next

    '            TotalAhorro += TotalImportePromocion
    '            TotalVenta -= TotalImportePromocion

    '            LblAhorro.Text = Format(CStr(ModPOS.Redondear(TotalAhorro, 2)), "Currency")
    '            LblTotal.Text = Format(CStr(ModPOS.Redondear(TotalVenta, 2)), "Currency")


    '        Case Is = 3 'Productos
    '            ' recupera producto promocion
    '            Dim dtRegalo As DataTable = ModPOS.SiExisteRecupera("sp_recupera_regalo", "PRMClave", PRMClave)

    '            For i = 0 To dtRegalo.Rows.Count - 1

    '                Dim dtDetalle As DataTable = ModPOS.SiExisteRecupera("sp_recupera_detalle", "@VENTA", VENClave, "@PROClave", dtRegalo.Rows(j)("PROClave"), "@Subtotal", 0)

    '                If Not dtDetalle Is Nothing Then
    '                    'Actualiza Cantidad de producto
    '                    ModPOS.Ejecuta("sp_actualiza_detalle", _
    '                    "@ALMClave", ALMClave, _
    '                     "@VENTA", VENClave, _
    '                    "@PROClave", dtRegalo.Rows(j)("PROClave"), _
    '                    "@TProducto", dtRegalo.Rows(j)("TProducto"), _
    '                    "@Cantidad", Numero * dtRegalo.Rows(j)("Cantidad"), _
    '                    "@TipoDoc", TipoDocumento)

    '                    dtDetalle.Dispose()
    '                Else
    '                    'Inserta Producto
    '                    Dim DVEClave As String = ModPOS.obtenerLlave

    '                    ModPOS.Ejecuta("sp_inserta_detalle", _
    '                    "@DVEClave", DVEClave, _
    '                    "@VENTA", VENClave, _
    '                    "@PROClave", dtRegalo.Rows(j)("PROClave"), _
    '                    "@Costo", dtRegalo.Rows(j)("Costo"), _
    '                    "@PrecioBruto", 0, _
    '                    "@PuntosPor", 0, _
    '                    "@PuntosImp", 0, _
    '                    "@DescuentoPor", 0, _
    '                    "@DescuentoImp", 0, _
    '                    "@ImpuestoImp", 0, _
    '                    "@PorcImp", 0, _
    '                    "@Cantidad", Numero * dtRegalo.Rows(j)("Cantidad"), _
    '                    "@ALMClave", ALMClave, _
    '                    "@TipoDoc", TipoDocumento, _
    '                    "@TProducto", dtRegalo.Rows(j)("TProducto"), _
    '                    "@Usuario", ModPOS.UsuarioActual)


    '                    TotalArticulos += 1
    '                    LblCantidadArticulos.Text = CStr(TotalArticulos)

    '                End If


    '                'SI REQUIERE SEGUIMIENTO DE SERIAL
    '                If dtRegalo.Rows(j)("Seguimiento") = 2 Then
    '                    Dim SerialReg As Integer = 0
    '                    Dim PorRegistrar As Double
    '                    PorRegistrar = Numero * dtRegalo.Rows(j)("Promocion")
    '                    Do
    '                        Dim a As New FrmSerial
    '                        a.DOCClave = VENClave
    '                        a.PROClave = dtRegalo.Rows(j)("PROClave")
    '                        a.Clave = dtRegalo.Rows(j)("Clave")
    '                        a.Nombre = dtRegalo.Rows(j)("Nombre")
    '                        a.Cantidad = PorRegistrar
    '                        a.Dias = dtRegalo.Rows(j)("Dias")
    '                        a.Accion = 1
    '                        a.ShowDialog()
    '                        SerialReg = SerialReg + a.NumSerialRegistrados
    '                        PorRegistrar = PorRegistrar - a.NumSerialRegistrados
    '                        a.Dispose()
    '                    Loop Until SerialReg = Numero * dtRegalo.Rows(j)("Promocion") OrElse PorRegistrar = 0
    '                End If

    '                'SI REQUIERE SEGUIMIENTO DE LOTE
    '                If dtRegalo.Rows(j)("Seguimiento") = 3 Then
    '                    Dim LoteReg As Integer = 0
    '                    Dim PorRegistrar As Double
    '                    PorRegistrar = Numero * dtRegalo.Rows(j)("Promocion")
    '                    Do
    '                        Dim a As New FrmLote
    '                        a.DOCClave = VENClave
    '                        a.PROClave = dtRegalo.Rows(j)("PROClave")
    '                        a.Clave = dtRegalo.Rows(j)("Clave")
    '                        a.Nombre = dtRegalo.Rows(j)("Nombre")
    '                        a.CantXRegistrar = PorRegistrar
    '                        a.TipoDoc = 1
    '                        a.TipoMov = 2
    '                        a.ShowDialog()
    '                        LoteReg = LoteReg + a.NumSerialRegistrados
    '                        PorRegistrar = PorRegistrar - a.NumSerialRegistrados
    '                        a.Dispose()
    '                    Loop Until LoteReg = Numero * dtRegalo.Rows(j)("Promocion") OrElse PorRegistrar = 0
    '                End If



    '            Next

    '            dtRegalo.Dispose()

    '        Case Is = 4 'Puntos

    '            For i = 0 To dt.Rows.Count - 1
    '                ImportePromocion = Numero * dt.Rows(i)("Promocion")
    '                TotalImporteNetoPromocion += ImportePromocion

    '                If dt.Rows(i)("Promocion") > 0 Then
    '                    ModPOS.Ejecuta("sp_aplica_promocion", _
    '                                    "@PRMClave", dt.Rows(i)("PRMClave"), _
    '                                    "@VENTA", VENClave, _
    '                                    "@DVEClave", dt.Rows(i)("DVEClave"), _
    '                                    "@PROClave", dt.Rows(i)("PROClave"), _
    '                                    "@Tipo", Tipo, _
    '                                    "@Porcentaje", ImportePromocion / (dt.Rows(i)("Precio") * dt.Rows(i)("Cantidad")), _
    '                                    "@Importe", ImportePromocion / dt.Rows(i)("Cantidad"), _
    '                                    "@Usuario", ModPOS.UsuarioActual)
    '                End If
    '            Next

    '            TotalPuntos += ImportePromocion
    '            LblCantidadPuntos.Text = ModPOS.Redondear(TotalPuntos, 2).ToString("#,##0.00")
    '    End Select
    '    dt.Dispose()
    'End Sub

    Private Sub AplicaPromociones(ByVal Tipo As Integer, ByRef dt As DataTable)
        Dim TotalImportePromocion As Double = 0
        Dim TotalImporteNetoPromocion As Double = 0
        Dim ImportePromocion As Double = 0
        Dim i As Integer

        Select Case Tipo
            Case Is = 1 'Descuentos
                'recuperar promocion detalle

                For i = 0 To dt.Rows.Count - 1

                    If dt.Rows(i)("TipoCalculoBase") = 1 Then
                        If dt.Rows(i)("Iguales") = True Then
                            ImportePromocion = (dt.Rows(i)("MaxNumPromo") * dt.Rows(i)("Inicial")) * ((dt.Rows(i)("Promocion") / 100) * dt.Rows(i)("Precio"))
                            TotalImportePromocion += ImportePromocion
                            TotalImporteNetoPromocion += (dt.Rows(i)("MaxNumPromo") * dt.Rows(i)("Inicial")) * ((dt.Rows(i)("Promocion") / 100) * dt.Rows(i)("PrecioNeto"))
                        Else
                            ImportePromocion = dt.Rows(i)("Saldo") * ((dt.Rows(i)("Promocion") / 100) * dt.Rows(i)("Precio"))
                            TotalImportePromocion += ImportePromocion
                            TotalImporteNetoPromocion += dt.Rows(i)("Saldo") * ((dt.Rows(i)("Promocion") / 100) * dt.Rows(i)("PrecioNeto"))
                        End If
                    Else
                        If dt.Rows(i)("Iguales") = True Then
                            ImportePromocion = dt.Rows(i)("Cantidad") * ((dt.Rows(i)("Promocion") / 100) * dt.Rows(i)("Precio"))
                            TotalImportePromocion += ImportePromocion
                            TotalImporteNetoPromocion += dt.Rows(i)("Cantidad") * ((dt.Rows(i)("Promocion") / 100) * dt.Rows(i)("PrecioNeto"))
                        Else
                            ImportePromocion = dt.Rows(i)("Saldo") * ((dt.Rows(i)("Promocion") / 100) * dt.Rows(i)("Precio"))
                            TotalImportePromocion += ImportePromocion
                            TotalImporteNetoPromocion += dt.Rows(i)("Saldo") * ((dt.Rows(i)("Promocion") / 100) * dt.Rows(i)("PrecioNeto"))

                        End If
                    End If
                    'ImportePromocion = Numero * ((dt.Rows(i)("Promocion") / 100) * dt.Rows(i)("Precio"))
                    'TotalImportePromocion += ImportePromocion
                    'TotalImporteNetoPromocion += Numero * ((dt.Rows(i)("Promocion") / 100) * dt.Rows(i)("PrecioNeto"))

                    If dt.Rows(i)("Promocion") > 0 Then
                        ModPOS.Ejecuta("sp_aplica_promocion", _
                                        "@PRMClave", dt.Rows(i)("PRMClave"), _
                                        "@VENTA", VENClave, _
                                        "@DVEClave", dt.Rows(i)("DVEClave"), _
                                        "@PROClave", dt.Rows(i)("PROClave"), _
                                        "@Tipo", Tipo, _
                                        "@Porcentaje", ImportePromocion / (dt.Rows(i)("Precio") * dt.Rows(i)("Cantidad")), _
                                        "@Importe", ImportePromocion / dt.Rows(i)("Cantidad"), _
                                        "@Usuario", ModPOS.UsuarioActual)

                        Dim dtDet As DataTable
                        dtDet = ModPOS.SiExisteRecupera("sp_ventadetalle_open", "@VENClave", VENClave)
                        If Not dtDet Is Nothing AndAlso dtDet.Rows.Count() > 0 Then
                            ModPOS.RecalculaImpuesto(dtDet, TImpuesto, SUCClave)
                            dtDet.Dispose()
                        End If

                    End If
                Next

                TotalAhorro += TotalImporteNetoPromocion
                TotalVenta -= TotalImporteNetoPromocion
                
                LblAhorro.Text = Format(CStr(ModPOS.Redondear(TotalAhorro, 2)), "Currency")
                LblTotal.Text = Format(CStr(ModPOS.Redondear(TotalVenta, 2)), "Currency")

                If Moneda <> MonedaCambio Then
                    If TotalVenta > 0 Then
                        LblTipoCambio.Text = MonedaRef.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(TotalVenta / TipoCambio, 2)), "Currency")
                    Else
                        LblTipoCambio.Text = MonedaRef.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(TotalVenta, 2)), "Currency")
                    End If
                End If


            Case Is = 2 'Bonificacion
                For i = 0 To dt.Rows.Count - 1
                    If dt.Rows(i)("Iguales") = True Then
                        ImportePromocion = dt.Rows(i)("MaxNumPromo") * dt.Rows(i)("Promocion")
                    Else
                        Dim dPorcentaje As Double
                        dPorcentaje = dt.Rows(i)("Saldo") / dt.Rows(i)("MaxNumPromo")
                        If dt.Rows(i)("TipoCalculoBase") = 1 Then ' si Cantidad
                            ImportePromocion = (dt.Rows(i)("MaxNumPromo") * dt.Rows(i)("Promocion")) * dPorcentaje
                        Else ' Si rango
                            ImportePromocion = dt.Rows(i)("Promocion") * dPorcentaje
                        End If
                    End If

                    TotalImportePromocion += ImportePromocion

                    If dt.Rows(i)("Promocion") > 0 Then
                        ModPOS.Ejecuta("sp_aplica_promocion", _
                                        "@PRMClave", dt.Rows(i)("PRMClave"), _
                                        "@VENTA", VENClave, _
                                        "@DVEClave", dt.Rows(i)("DVEClave"), _
                                        "@PROClave", dt.Rows(i)("PROClave"), _
                                        "@Tipo", Tipo, _
                                        "@Porcentaje", ImportePromocion / (dt.Rows(i)("Precio") * dt.Rows(i)("Cantidad")), _
                                        "@Importe", ImportePromocion / dt.Rows(i)("Cantidad"), _
                                        "@Usuario", ModPOS.UsuarioActual)

                        Dim dtDet As DataTable
                        dtDet = ModPOS.SiExisteRecupera("sp_ventadetalle_open", "@VENClave", VENClave)
                        If Not dtDet Is Nothing AndAlso dtDet.Rows.Count() > 0 Then
                            ModPOS.RecalculaImpuesto(dtDet, TImpuesto, SUCClave)
                            dtDet.Dispose()
                        End If

                    End If
                Next

                TotalAhorro += TotalImportePromocion
                TotalVenta -= TotalImportePromocion

                LblAhorro.Text = Format(CStr(ModPOS.Redondear(TotalAhorro, 2)), "Currency")
                LblTotal.Text = Format(CStr(ModPOS.Redondear(TotalVenta, 2)), "Currency")

                If Moneda <> MonedaCambio Then
                    If TotalVenta > 0 Then
                        LblTipoCambio.Text = MonedaRef.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(TotalVenta / TipoCambio, 2)), "Currency")
                    Else
                        LblTipoCambio.Text = MonedaRef.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(TotalVenta, 2)), "Currency")
                    End If
                End If


            Case Is = 3 'Productos
                ' recupera producto promocion

                Dim dMonto As Double

                If dt.Rows(0)("Iguales") = True Then
                    dMonto = IIf(dt.Compute("Sum(MaxNumPromo)", "MaxNumPromo > 0") Is System.DBNull.Value, 0, dt.Compute("Sum(MaxNumPromo)", "MaxNumPromo > 0"))
                Else
                    If dt.Rows(0)("TipoCalculoBase") = 1 Then ' si Cantidad
                        dMonto = dt.Rows(0)("MaxNumPromo")
                    Else 'Rango
                        dMonto = 1
                    End If
                End If


                Dim dtRegalo As DataTable = ModPOS.SiExisteRecupera("sp_recupera_regalo", "@SUCClave", SUCClave, "@PRMClave", dt.Rows(0)("PRMClave"))

                Dim j As Integer

                For j = 0 To dtRegalo.Rows.Count - 1

                    Dim dtDetalle As DataTable = ModPOS.SiExisteRecupera("sp_recupera_detalle", "@VENTA", VENClave, "@PROClave", dtRegalo.Rows(j)("PROClave"), "@Subtotal", 0)

                    If Not dtDetalle Is Nothing Then
                        'Actualiza Cantidad de producto
                        ModPOS.Ejecuta("sp_actualiza_detalle", _
                        "@ALMClave", ALMClave, _
                         "@VENTA", VENClave, _
                        "@PROClave", dtRegalo.Rows(j)("PROClave"), _
                        "@TProducto", dtRegalo.Rows(j)("TProducto"), _
                        "@Cantidad", dMonto * dtRegalo.Rows(j)("Cantidad"), _
                        "@TipoDoc", TipoDocumento)

                        dtDetalle.Dispose()
                    Else
                        'Inserta Producto
                        Dim DVEClave As String = ModPOS.obtenerLlave

                        ModPOS.Ejecuta("sp_inserta_detalle", _
                        "@DVEClave", DVEClave, _
                        "@VENTA", VENClave, _
                        "@PROClave", dtRegalo.Rows(j)("PROClave"), _
                        "@Costo", dtRegalo.Rows(j)("Costo"), _
                        "@PrecioBruto", 0, _
                        "@PuntosPor", 0, _
                        "@PuntosImp", 0, _
                        "@DescuentoPor", 0, _
                        "@DescuentoImp", 0, _
                        "@ImpuestoImp", 0, _
                        "@PorcImp", 0, _
                        "@Cantidad", dMonto * dtRegalo.Rows(j)("Cantidad"), _
                        "@ALMClave", ALMClave, _
                        "@TipoDoc", TipoDocumento, _
                        "@TProducto", dtRegalo.Rows(j)("TProducto"), _
                        "@Usuario", ModPOS.UsuarioActual)

                        TotalArticulos += 1
                        LblCantidadArticulos.Text = CStr(TotalArticulos)

                    End If


                    'SI REQUIERE SEGUIMIENTO DE SERIAL
                    If dtRegalo.Rows(j)("Seguimiento") = 2 Then
                        Dim SerialReg As Integer = 0
                        Dim PorRegistrar As Double
                        PorRegistrar = dMonto * dtRegalo.Rows(j)("Promocion")
                        Do
                            Dim a As New FrmSerial
                            a.DOCClave = VENClave
                            a.PROClave = dtRegalo.Rows(j)("PROClave")
                            a.Clave = dtRegalo.Rows(j)("Clave")
                            a.Nombre = dtRegalo.Rows(j)("Nombre")
                            a.Cantidad = PorRegistrar
                            a.Dias = dtRegalo.Rows(j)("Dias")
                            a.TipoDoc = 1
                            a.TipoMov = 2
                            a.ShowDialog()
                            SerialReg = SerialReg + a.NumSerialRegistrados
                            PorRegistrar = PorRegistrar - a.NumSerialRegistrados
                            a.Dispose()
                        Loop Until SerialReg = dMonto * dtRegalo.Rows(j)("Promocion") OrElse PorRegistrar = 0
                    End If

                    'SI REQUIERE SEGUIMIENTO DE LOTE
                    If dtRegalo.Rows(j)("Seguimiento") = 3 Then
                        Dim LoteReg As Integer = 0
                        Dim PorRegistrar As Double
                        PorRegistrar = dMonto * dtRegalo.Rows(j)("Promocion")
                        Do
                            Dim a As New FrmLote
                            a.DOCClave = VENClave
                            a.PROClave = dtRegalo.Rows(j)("PROClave")
                            a.Clave = dtRegalo.Rows(j)("Clave")
                            a.Nombre = dtRegalo.Rows(j)("Nombre")
                            a.CantXRegistrar = PorRegistrar
                            a.TipoDoc = 1
                            a.TipoMov = 2
                            a.ShowDialog()
                            LoteReg = LoteReg + a.NumSerialRegistrados
                            PorRegistrar = PorRegistrar - a.NumSerialRegistrados
                            a.Dispose()
                        Loop Until LoteReg = dMonto * dtRegalo.Rows(j)("Promocion") OrElse PorRegistrar = 0
                    End If

                    '  AgregarProducto(dtRegalo.Rows(j)("Clave"), dtRegalo.Rows(j)("Nombre"), dMonto * dtRegalo.Rows(j)("Cantidad"), 0, 0, 0, 0)


                Next

                dtRegalo.Dispose()

            Case Is = 4 'Puntos

                For i = 0 To dt.Rows.Count - 1

                    If dt.Rows(i)("Iguales") = True Then
                        ImportePromocion = dt.Rows(i)("MaxNumPromo") * dt.Rows(i)("Promocion")
                    Else
                        Dim dPorcentaje As Double
                        dPorcentaje = dt.Rows(i)("Saldo") / dt.Rows(i)("MaxNumPromo")
                        If dt.Rows(i)("TipoCalculoBase") = 1 Then ' si Cantidad
                            ImportePromocion = (dt.Rows(i)("MaxNumPromo") * dt.Rows(i)("Promocion")) * dPorcentaje
                        Else 'Rango
                            ImportePromocion = dt.Rows(i)("Promocion") * dPorcentaje
                        End If
                    End If

                    TotalImporteNetoPromocion += ImportePromocion

                    If dt.Rows(i)("Promocion") > 0 Then
                        ModPOS.Ejecuta("sp_aplica_promocion", _
                                        "@PRMClave", dt.Rows(i)("PRMClave"), _
                                        "@VENTA", VENClave, _
                                        "@DVEClave", dt.Rows(i)("DVEClave"), _
                                        "@PROClave", dt.Rows(i)("PROClave"), _
                                        "@Tipo", Tipo, _
                                        "@Porcentaje", ImportePromocion / (dt.Rows(i)("Precio") * dt.Rows(i)("Cantidad")), _
                                        "@Importe", ImportePromocion / dt.Rows(i)("Cantidad"), _
                                        "@Usuario", ModPOS.UsuarioActual)
                    End If
                Next

                TotalPuntos += ImportePromocion

                ModPOS.Ejecuta("sp_add_puntos", "@CTEClave", CTEClaveActual, "@Cantidad", TotalPuntos)

                LblCantidadPuntos.Text = ModPOS.Redondear(TotalPuntos, 2).ToString("#,##0.00")

            Case Is = 5 'Menor Precio


                Dim dMonto As Double

                If dt.Rows(i)("Iguales") = True Then
                    dMonto = IIf(dt.Compute("Sum(MaxNumPromo)", "MaxNumPromo > 0") Is System.DBNull.Value, 0, dt.Compute("Sum(MaxNumPromo)", "MaxNumPromo > 0"))
                Else
                    If dt.Rows(i)("TipoCalculoBase") = 1 Then ' si Cantidad
                        dMonto = dt.Rows(i)("MaxNumPromo")
                    Else 'Rango
                        dMonto = 1
                    End If
                End If


                For i = 0 To dt.Rows.Count - 1

                    If dMonto >= dt.Rows(i)("Cantidad") Then
                        ImportePromocion = dt.Rows(i)("Precio") * dt.Rows(i)("Cantidad")
                        TotalImportePromocion += ImportePromocion
                        TotalImporteNetoPromocion += dt.Rows(i)("PrecioNeto") * dt.Rows(i)("Cantidad")
                        dMonto -= dt.Rows(i)("Cantidad")
                    Else
                        ImportePromocion = dt.Rows(i)("Precio") * dMonto
                        TotalImportePromocion += ImportePromocion
                        TotalImporteNetoPromocion += dt.Rows(i)("PrecioNeto") * dMonto
                        dMonto = 0
                    End If

                    If ImportePromocion > 0 Then
                        ModPOS.Ejecuta("sp_aplica_promocion", _
                                        "@PRMClave", dt.Rows(i)("PRMClave"), _
                                        "@VENTA", VENClave, _
                                        "@DVEClave", dt.Rows(i)("DVEClave"), _
                                        "@PROClave", dt.Rows(i)("PROClave"), _
                                        "@Tipo", Tipo, _
                                        "@Porcentaje", ImportePromocion / (dt.Rows(i)("Precio") * dt.Rows(i)("Cantidad")), _
                                        "@Importe", ImportePromocion / dt.Rows(i)("Cantidad"), _
                                        "@Usuario", ModPOS.UsuarioActual)

                        Dim dtDet As DataTable
                        dtDet = ModPOS.SiExisteRecupera("sp_ventadetalle_open", "@VENClave", VENClave)
                        If Not dtDet Is Nothing AndAlso dtDet.Rows.Count() > 0 Then
                            ModPOS.RecalculaImpuesto(dtDet, TImpuesto, SUCClave)
                            dtDet.Dispose()
                        End If

                    End If


                    If dMonto <= 0 Then
                        Exit For
                    End If

                Next

                TotalAhorro += TotalImporteNetoPromocion
                TotalVenta -= TotalImporteNetoPromocion

                LblAhorro.Text = Format(CStr(ModPOS.Redondear(TotalAhorro, 2)), "Currency")
                LblTotal.Text = Format(CStr(ModPOS.Redondear(TotalVenta, 2)), "Currency")

                If Moneda <> MonedaCambio Then
                    If TotalVenta > 0 Then
                        LblTipoCambio.Text = MonedaRef.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(TotalVenta / TipoCambio, 2)), "Currency")
                    Else
                        LblTipoCambio.Text = MonedaRef.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(TotalVenta, 2)), "Currency")
                    End If
                End If



        End Select
        dt.Dispose()
    End Sub

    Private Sub verificaPromocion(ByVal dtPromocion As DataTable)
        Dim y, x As Integer
        Dim AplicaPromocion As Boolean = False
        Dim dtPromDet, dtAplicaPromo As DataTable
        Dim MaxNumPromocion As Integer = 0
        Dim iCantidad, iSaldo, dImporte As Double
        
        dtAplicaPromo = ModPOS.CrearTabla("AplicaPromocion", _
                                  "PRMClave", "System.String", _
                                  "Inicial", "System.Int32", _
                                  "Final", "System.Int32", _
                                  "TipoCalculoBase", "System.Int32", _
                                  "Clave", "System.String", _
                                  "Descripcion", "System.String", _
                                  "DVEClave", "System.String", _
                                  "PROClave", "System.String", _
                                  "Cantidad", "System.Double", _
                                  "Promocion", "System.Double", _
                                  "Precio", "System.Double", _
                                  "PrecioNeto", "System.Double", _
                                  "TotalPartida", "System.Double", _
                                  "MaxNumPromo", "System.Int32", _
                                  "Saldo", "System.Double", _
                                  "Iguales", "System.Boolean")



        'Para cada promocion que se encuentre donde algun producto de la venta coincida con algun producto del detalle de la promocion
        For y = 0 To dtPromocion.Rows.Count - 1
            'Recupera detalle promocion
            dtPromDet = ModPOS.Recupera_Tabla("sp_recupera_detalle_promocion", "@PRMClave", dtPromocion.Rows(y)("PRMClave"), "@VENClave", VENClave)

            If dtPromocion.Rows(y)("Iguales") = True Then

                For x = 0 To dtPromDet.Rows.Count - 1

                    Select Case CInt(dtPromocion.Rows(y)("TipoAPlicacion"))
                        Case Is = 1 'Cantidad
                            If dtPromocion.Rows(y)("TipoCalculoBase") = 1 Then 'si la base es por cantidad

                                If dtPromDet.Rows(x)("Cantidad") >= dtPromDet.Rows(x)("CantidadInicial") Then
                                    MaxNumPromocion = Int(dtPromDet.Rows(x)("Cantidad") / dtPromDet.Rows(x)("CantidadInicial"))
                                    If MaxNumPromocion > 0 Then
                                        'agrega partida promocion
                                        'If CInt(dtPromocion.Rows(y)("Tipo")) <> 3 Then
                                        agregaRow(dtAplicaPromo, dtPromocion.Rows(y)("PRMClave"), dtPromDet.Rows(x)("CantidadInicial"), dtPromDet.Rows(x)("CantidadFinal"), dtPromocion.Rows(y)("TipoCalculoBase"), dtPromocion.Rows(y)("Clave"), dtPromocion.Rows(y)("Descripcion"), dtPromDet.Rows(x)("DVEClave"), dtPromDet.Rows(x)("PROClave"), dtPromDet.Rows(x)("Cantidad"), dtPromDet.Rows(x)("Promocion"), dtPromDet.Rows(x)("Precio"), dtPromDet.Rows(x)("PrecioNeto"), dtPromDet.Rows(x)("Importe"), MaxNumPromocion, MaxNumPromocion, dtPromocion.Rows(y)("Iguales"))
                                        'End If

                                        AplicaPromocion = True

                                    End If
                                End If

                            Else 'Si la base es rango
                                If dtPromDet.Rows(x)("Cantidad") >= dtPromDet.Rows(x)("CantidadInicial") AndAlso dtPromDet.Rows(x)("Cantidad") <= dtPromDet.Rows(x)("CantidadFinal") Then
                                    'If CInt(dtPromocion.Rows(y)("Tipo")) <> 3 Then
                                    agregaRow(dtAplicaPromo, dtPromocion.Rows(y)("PRMClave"), dtPromDet.Rows(x)("CantidadInicial"), dtPromDet.Rows(x)("CantidadFinal"), dtPromocion.Rows(y)("TipoCalculoBase"), dtPromocion.Rows(y)("Clave"), dtPromocion.Rows(y)("Descripcion"), dtPromDet.Rows(x)("DVEClave"), dtPromDet.Rows(x)("PROClave"), dtPromDet.Rows(x)("Cantidad"), dtPromDet.Rows(x)("Promocion"), dtPromDet.Rows(x)("Precio"), dtPromDet.Rows(x)("PrecioNeto"), dtPromDet.Rows(x)("Importe"), 1, 1, dtPromocion.Rows(y)("Iguales"))
                                    'End If

                                    AplicaPromocion = True

                                End If
                            End If


                        Case Is = 2 'Importe

                            If dtPromocion.Rows(y)("TipoCalculoBase") = 1 Then 'si la base es por cantidad


                                If dtPromDet.Rows(x)("Importe") >= dtPromDet.Rows(x)("CantidadInicial") Then
                                    MaxNumPromocion = Int(dtPromDet.Rows(x)("Importe") / dtPromDet.Rows(x)("CantidadInicial"))
                                    If MaxNumPromocion > 0 Then
                                        'agrega partida promocion
                                        '       If CInt(dtPromocion.Rows(y)("Tipo")) <> 3 Then
                                        agregaRow(dtAplicaPromo, dtPromocion.Rows(y)("PRMClave"), dtPromDet.Rows(x)("CantidadInicial"), dtPromDet.Rows(x)("CantidadFinal"), dtPromocion.Rows(y)("TipoCalculoBase"), dtPromocion.Rows(y)("Clave"), dtPromocion.Rows(y)("Descripcion"), dtPromDet.Rows(x)("DVEClave"), dtPromDet.Rows(x)("PROClave"), dtPromDet.Rows(x)("Cantidad"), dtPromDet.Rows(x)("Promocion"), dtPromDet.Rows(x)("Precio"), dtPromDet.Rows(x)("PrecioNeto"), dtPromDet.Rows(x)("Importe"), MaxNumPromocion, MaxNumPromocion, dtPromocion.Rows(y)("Iguales"))
                                        'End If
                                        AplicaPromocion = True
                                    End If
                                End If


                            Else 'Si la base es rango
                                If dtPromDet.Rows(x)("Importe") >= dtPromDet.Rows(x)("CantidadInicial") AndAlso dtPromDet.Rows(x)("Importe") <= dtPromDet.Rows(x)("CantidadFinal") Then

                                    'If CInt(dtPromocion.Rows(y)("Tipo")) <> 3 Then
                                    agregaRow(dtAplicaPromo, dtPromocion.Rows(y)("PRMClave"), dtPromDet.Rows(x)("CantidadInicial"), dtPromDet.Rows(x)("CantidadFinal"), dtPromocion.Rows(y)("TipoCalculoBase"), dtPromocion.Rows(y)("Clave"), dtPromocion.Rows(y)("Descripcion"), dtPromDet.Rows(x)("DVEClave"), dtPromDet.Rows(x)("PROClave"), dtPromDet.Rows(x)("Cantidad"), dtPromDet.Rows(x)("Promocion"), dtPromDet.Rows(x)("Precio"), dtPromDet.Rows(x)("PrecioNeto"), dtPromDet.Rows(x)("Importe"), 1, 1, dtPromocion.Rows(y)("Iguales"))
                                    'End If

                                    AplicaPromocion = True
                                End If
                            End If


                    End Select
                Next
            Else
                If dtPromocion.Rows(y)("TipoAplicacion") = 1 Then

                    iCantidad = IIf(dtPromDet.Compute("Sum(Cantidad)", "Cantidad > 0") Is System.DBNull.Value, 0, dtPromDet.Compute("Sum(Cantidad)", "Cantidad > 0"))


                    If dtPromocion.Rows(y)("TipoCalculoBase") = 1 Then ' si la base es por cantidad
                        If iCantidad >= dtPromDet.Rows(0)("CantidadInicial") Then
                            MaxNumPromocion = Int(iCantidad / dtPromDet.Rows(0)("CantidadInicial"))
                            If MaxNumPromocion > 0 Then

                                If CInt(dtPromocion.Rows(y)("Tipo")) = 1 Then
                                    iSaldo = MaxNumPromocion * dtPromDet.Rows(0)("CantidadInicial")
                                Else
                                    iSaldo = MaxNumPromocion
                                End If

                                For x = 0 To dtPromDet.Rows.Count - 1

                                    If dtPromDet.Rows(x)("Cantidad") <= iSaldo Then
                                        agregaRow(dtAplicaPromo, dtPromocion.Rows(y)("PRMClave"), dtPromDet.Rows(x)("CantidadInicial"), dtPromDet.Rows(x)("CantidadFinal"), dtPromocion.Rows(y)("TipoCalculoBase"), dtPromocion.Rows(y)("Clave"), dtPromocion.Rows(y)("Descripcion"), dtPromDet.Rows(x)("DVEClave"), dtPromDet.Rows(x)("PROClave"), dtPromDet.Rows(x)("Cantidad"), dtPromDet.Rows(x)("Promocion"), dtPromDet.Rows(x)("Precio"), dtPromDet.Rows(x)("PrecioNeto"), dtPromDet.Rows(x)("Importe"), MaxNumPromocion, dtPromDet.Rows(x)("Cantidad"), dtPromocion.Rows(y)("Iguales"))
                                        iSaldo -= dtPromDet.Rows(x)("Cantidad")
                                        AplicaPromocion = True

                                    Else
                                        agregaRow(dtAplicaPromo, dtPromocion.Rows(y)("PRMClave"), dtPromDet.Rows(x)("CantidadInicial"), dtPromDet.Rows(x)("CantidadFinal"), dtPromocion.Rows(y)("TipoCalculoBase"), dtPromocion.Rows(y)("Clave"), dtPromocion.Rows(y)("Descripcion"), dtPromDet.Rows(x)("DVEClave"), dtPromDet.Rows(x)("PROClave"), dtPromDet.Rows(x)("Cantidad"), dtPromDet.Rows(x)("Promocion"), dtPromDet.Rows(x)("Precio"), dtPromDet.Rows(x)("PrecioNeto"), dtPromDet.Rows(x)("Importe"), MaxNumPromocion, iSaldo, dtPromocion.Rows(y)("Iguales"))
                                        iSaldo = 0
                                        AplicaPromocion = True

                                    End If

                                    If iSaldo = 0 Then
                                        Exit For
                                    End If

                                Next


                            End If
                        End If
                    Else ' si la base es por rango
                        If iCantidad >= dtPromDet.Rows(0)("CantidadInicial") AndAlso iCantidad <= dtPromDet.Rows(x)("CantidadFinal") Then

                            iSaldo = iCantidad

                            For x = 0 To dtPromDet.Rows.Count - 1

                                If dtPromDet.Rows(x)("Cantidad") <= iSaldo Then
                                    agregaRow(dtAplicaPromo, dtPromocion.Rows(y)("PRMClave"), dtPromDet.Rows(x)("CantidadInicial"), dtPromDet.Rows(x)("CantidadFinal"), dtPromocion.Rows(y)("TipoCalculoBase"), dtPromocion.Rows(y)("Clave"), dtPromocion.Rows(y)("Descripcion"), dtPromDet.Rows(x)("DVEClave"), dtPromDet.Rows(x)("PROClave"), dtPromDet.Rows(x)("Cantidad"), dtPromDet.Rows(x)("Promocion"), dtPromDet.Rows(x)("Precio"), dtPromDet.Rows(x)("PrecioNeto"), dtPromDet.Rows(x)("Importe"), iCantidad, dtPromDet.Rows(x)("Cantidad"), dtPromocion.Rows(y)("Iguales"))
                                    iSaldo -= dtPromDet.Rows(x)("Cantidad")
                                    AplicaPromocion = True

                                Else
                                    agregaRow(dtAplicaPromo, dtPromocion.Rows(y)("PRMClave"), dtPromDet.Rows(x)("CantidadInicial"), dtPromDet.Rows(x)("CantidadFinal"), dtPromocion.Rows(y)("TipoCalculoBase"), dtPromocion.Rows(y)("Clave"), dtPromocion.Rows(y)("Descripcion"), dtPromDet.Rows(x)("DVEClave"), dtPromDet.Rows(x)("PROClave"), dtPromDet.Rows(x)("Cantidad"), dtPromDet.Rows(x)("Promocion"), dtPromDet.Rows(x)("Precio"), dtPromDet.Rows(x)("PrecioNeto"), dtPromDet.Rows(x)("Importe"), iCantidad, iSaldo, dtPromocion.Rows(y)("Iguales"))
                                    iSaldo = 0
                                    AplicaPromocion = True

                                End If

                                If iSaldo = 0 Then
                                    Exit For
                                End If

                            Next
                        End If
                    End If

                ElseIf dtPromocion.Rows(y)("TipoAplicacion") = 2 Then 'Importe


                    dImporte = IIf(dtPromDet.Compute("Sum(Importe)", "Importe > 0") Is System.DBNull.Value, 0, dtPromDet.Compute("Sum(Importe)", "Importe > 0"))

                    If dtPromocion.Rows(y)("TipoCalculoBase") = 1 Then 'si la base es por cantidad
                        If dImporte >= dtPromDet.Rows(0)("CantidadInicial") Then
                            MaxNumPromocion = Int(dImporte / dtPromDet.Rows(0)("CantidadInicial"))
                            If MaxNumPromocion > 0 Then

                                If CInt(dtPromocion.Rows(y)("Tipo")) = 1 Then
                                    iSaldo = MaxNumPromocion * dtPromDet.Rows(0)("CantidadInicial")
                                Else
                                    iSaldo = MaxNumPromocion
                                End If

                               
                                For x = 0 To dtPromDet.Rows.Count - 1

                                    If dtPromDet.Rows(x)("Importe") <= iSaldo Then
                                        agregaRow(dtAplicaPromo, dtPromocion.Rows(y)("PRMClave"), dtPromDet.Rows(x)("CantidadInicial"), dtPromDet.Rows(x)("CantidadFinal"), dtPromocion.Rows(y)("TipoCalculoBase"), dtPromocion.Rows(y)("Clave"), dtPromocion.Rows(y)("Descripcion"), dtPromDet.Rows(x)("DVEClave"), dtPromDet.Rows(x)("PROClave"), dtPromDet.Rows(x)("Cantidad"), dtPromDet.Rows(x)("Promocion"), dtPromDet.Rows(x)("Precio"), dtPromDet.Rows(x)("PrecioNeto"), dtPromDet.Rows(x)("Importe"), MaxNumPromocion, dtPromDet.Rows(x)("Cantidad"), dtPromocion.Rows(y)("Iguales"))
                                        iSaldo -= dtPromDet.Rows(x)("Importe")
                                        AplicaPromocion = True

                                    Else
                                        agregaRow(dtAplicaPromo, dtPromocion.Rows(y)("PRMClave"), dtPromDet.Rows(x)("CantidadInicial"), dtPromDet.Rows(x)("CantidadFinal"), dtPromocion.Rows(y)("TipoCalculoBase"), dtPromocion.Rows(y)("Clave"), dtPromocion.Rows(y)("Descripcion"), dtPromDet.Rows(x)("DVEClave"), dtPromDet.Rows(x)("PROClave"), dtPromDet.Rows(x)("Cantidad"), dtPromDet.Rows(x)("Promocion"), dtPromDet.Rows(x)("Precio"), dtPromDet.Rows(x)("PrecioNeto"), dtPromDet.Rows(x)("Importe"), MaxNumPromocion, iSaldo, dtPromocion.Rows(y)("Iguales"))
                                        iSaldo = 0
                                        AplicaPromocion = True

                                    End If

                                    If iSaldo = 0 Then
                                        Exit For
                                    End If
                                Next
                            End If
                        End If
                    Else ' si la base es por rango
                        If dImporte >= dtPromDet.Rows(0)("CantidadInicial") AndAlso dImporte <= dtPromDet.Rows(x)("CantidadFinal") Then

                            iSaldo = dImporte

                            For x = 0 To dtPromDet.Rows.Count - 1

                                If dtPromDet.Rows(x)("Importe") <= iSaldo Then
                                    agregaRow(dtAplicaPromo, dtPromocion.Rows(y)("PRMClave"), dtPromDet.Rows(x)("CantidadInicial"), dtPromDet.Rows(x)("CantidadFinal"), dtPromocion.Rows(y)("TipoCalculoBase"), dtPromocion.Rows(y)("Clave"), dtPromocion.Rows(y)("Descripcion"), dtPromDet.Rows(x)("DVEClave"), dtPromDet.Rows(x)("PROClave"), dtPromDet.Rows(x)("Cantidad"), dtPromDet.Rows(x)("Promocion"), dtPromDet.Rows(x)("Precio"), dtPromDet.Rows(x)("PrecioNeto"), dtPromDet.Rows(x)("Importe"), dImporte, dtPromDet.Rows(x)("Importe"), dtPromocion.Rows(y)("Iguales"))
                                    iSaldo -= dtPromDet.Rows(x)("Importe")
                                    AplicaPromocion = True

                                Else
                                    agregaRow(dtAplicaPromo, dtPromocion.Rows(y)("PRMClave"), dtPromDet.Rows(x)("CantidadInicial"), dtPromDet.Rows(x)("CantidadFinal"), dtPromocion.Rows(y)("TipoCalculoBase"), dtPromocion.Rows(y)("Clave"), dtPromocion.Rows(y)("Descripcion"), dtPromDet.Rows(x)("DVEClave"), dtPromDet.Rows(x)("PROClave"), dtPromDet.Rows(x)("Cantidad"), dtPromDet.Rows(x)("Promocion"), dtPromDet.Rows(x)("Precio"), dtPromDet.Rows(x)("PrecioNeto"), dtPromDet.Rows(x)("Importe"), dImporte, iSaldo, dtPromocion.Rows(y)("Iguales"))
                                    iSaldo = 0
                                    AplicaPromocion = True

                                End If

                                If iSaldo = 0 Then
                                    Exit For
                                End If

                            Next
                        End If



                    End If
                End If
            End If


            dtPromDet.Dispose()

            If AplicaPromocion Then  ' Si Aplica la promocion
                AplicaPromociones(CInt(dtPromocion.Rows(y)("Tipo")), dtAplicaPromo)
            End If

            If dtPromocion.Rows(y)("Cascada") = 0 Then ' Si no aplica cascada termina 
                Exit For
            End If

        Next

        dtPromocion.Dispose()
        dtAplicaPromo.Dispose()

    End Sub

    Private Sub BtnBusquedaProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBusquedaProducto.Click
        If VentaCerrada OrElse TotalArticulos = 0 Then
            Dim dtCliente As DataTable
            dtCliente = ModPOS.Recupera_Tabla("sp_venta_lista", "@Cliente", CTEClaveActual)
            ListaPrecio = dtCliente.Rows(0)("PREClave")
            TImpuesto = dtCliente.Rows(0)("TipoImpuesto")
            dtCliente.Dispose()
        End If
        Dim a As New FrmBuscaProducto
        a.bVentaConvencional = True
        a.PuntodeVenta = PDVClave
        a.Almacen = ALMClave
        a.ListadePrecio = ListaPrecio
        a.StatusVenta = VentaCerrada
        a.TipoVenta = TipoDocumento
        a.TImpuesto = TImpuesto
        a.ClienteActual = CTEClaveActual
        a.ShowDialog()
        a.Dispose()
        TxtProducto.Focus()
    End Sub

    Private Sub BtnConsultaPrecio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim a As New FrmConsultaPrecio
        a.ClienteActual = Me.CTEClaveActual
        a.NombreClienteActual = Me.CTENombreActual
        a.Almacen = ALMClave
        a.ShowDialog()
        a.Dispose()
        TxtProducto.Focus()
    End Sub

    Private Sub recuperaDatosCredito(ByVal Cliente As String)
        Dim dt As DataTable

        dt = ModPOS.SiExisteRecupera("sp_recupera_credito", "@CTEClave", Cliente)

        If Not dt Is Nothing Then
            If dt.Rows.Count > 0 Then
                CreditoDisponible = dt.Rows(0)("Disponible")
            Else
                CreditoDisponible = 0.0

            End If
            dt.Dispose()
        Else
            CreditoDisponible = 0.0
        End If
    End Sub


    Private Sub BtnCerrarTicket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar.Click
        If TotalArticulos > 0 AndAlso VentaCerrada = False Then

            'Validar Limite de Credito
            If TipoDocumento = 3 Then
                recuperaDatosCredito(CTEClaveActual)
                If CreditoDisponible < TotalVenta Then
                    MessageBox.Show("El limite de crédito disponible es de " & Format(CStr(ModPOS.Redondear(CreditoDisponible, 2)), "Currency") & ", la venta actual lo sobrepasa por " & Format(CStr(ModPOS.Redondear(TotalVenta - CreditoDisponible, 2)), "Currency"), "Información", MessageBoxButtons.OK)
                    Exit Sub
                End If
            End If

            'inserta partidas
            Dim fila As Integer
            Dim PrecioNeto As Double

            For fila = 0 To dtDetalle.Rows.Count - 1

                PrecioNeto = (dtDetalle.Rows(fila)("PrecioBruto") - (dtDetalle.Rows(fila)("PrecioBruto") * dtDetalle.Rows(fila)("Dsc%") / 100)) * (1 + dtDetalle.Rows(fila)("PorcImpuesto"))

                Dim DVEClave As String = dtDetalle.Rows(fila)("DVEClave")

                ModPOS.Ejecuta("sp_inserta_detalle", _
                         "@DVEClave", DVEClave, _
                         "@VENTA", VENClave, _
                         "@PROClave", dtDetalle.Rows(fila)("PROClave"), _
                         "@Costo", dtDetalle.Rows(fila)("Costo"), _
                         "@PrecioBruto", dtDetalle.Rows(fila)("PrecioBruto"), _
                         "@PuntosPor", dtDetalle.Rows(fila)("PuntosPor"), _
                         "@PuntosImp", PrecioNeto * dtDetalle.Rows(fila)("PuntosPor"), _
                         "@DescuentoPor", dtDetalle.Rows(fila)("Dsc%") / 100, _
                         "@DescuentoImp", dtDetalle.Rows(fila)("PrecioBruto") * (dtDetalle.Rows(fila)("Dsc%") / 100), _
                         "@ImpuestoImp", (dtDetalle.Rows(fila)("PrecioBruto") - (dtDetalle.Rows(fila)("PrecioBruto") * (dtDetalle.Rows(fila)("Dsc%") / 100))) * dtDetalle.Rows(fila)("PorcImpuesto"), _
                         "@PorcImp", dtDetalle.Rows(fila)("PorcImpuesto"), _
                         "@Cantidad", dtDetalle.Rows(fila)("Cantidad"), _
                         "@ALMClave", ALMClave, _
                         "@TipoDoc", TipoDocumento, _
                         "@TProducto", dtDetalle.Rows(fila)("TProducto"), _
                         "@Usuario", ModPOS.UsuarioActual)

                'Inserta detalle de Impuestos por partida
                ModPOS.InsertaImpuesto(DVEClave, dtDetalle.Rows(fila)("PROClave"), dtDetalle.Rows(fila)("PrecioBruto") - (dtDetalle.Rows(fila)("PrecioBruto") * (dtDetalle.Rows(fila)("Dsc%") / 100)), TImpuesto, SUCClave)

            Next

            'Recupera promociones vigentes
            Dim dtPromocion As DataTable = ModPOS.SiExisteRecupera("sp_promocion_vigente", "CTEClave", CTEClaveActual, "@VENClave", VENClave)
            If Not dtPromocion Is Nothing AndAlso dtPromocion.Rows.Count > 0 Then
                verificaPromocion(dtPromocion)
                dtPromocion.Dispose()
            End If

            'Recupera los descuentos vigentes
            Dim dtDescCte As DataTable = ModPOS.SiExisteRecupera("sp_venta_descuento", "@Cliente", CTEClaveActual)
            If Not dtDescCte Is Nothing Then
                Dim i As Integer = 0

                Dim TipoAplicacion As Integer
                Dim ImporteInicial As Double
                Dim ImporteFinal As Double
                Dim GerarquiaDesc As Integer

                For i = 0 To dtDescCte.Rows.Count - 1

                    DESClave = dtDescCte.Rows(i)("DESClave")
                    TipoAplicacion = dtDescCte.Rows(i)("Tipo")
                    TipoDesCte = dtDescCte.Rows(i)("TipoAplicacion")
                    PorcDescCliente = dtDescCte.Rows(i)("DescuentoPorc")
                    DescuentoCliente = Math.Abs(CInt(dtDescCte.Rows(i)("Cascada")))
                    ImporteInicial = dtDescCte.Rows(i)("ImporteInicial")
                    ImporteFinal = dtDescCte.Rows(i)("ImporteFinal")
                    GerarquiaDesc = dtDescCte.Rows(i)("Gerarquia")

                    If TotalVenta >= ImporteInicial AndAlso TotalVenta <= ImporteFinal Then
                        Select Case TipoAplicacion
                            Case Is = 1 'Descuento

                                Dim ImpDesCte As Double = PorcDescCliente * TotalVenta

                                TotalAhorro += ImpDesCte
                                TotalVenta -= ImpDesCte

                                LblAhorro.Text = Format(CStr(ModPOS.Redondear(TotalAhorro, 2)), "Currency")
                                LblTotal.Text = Format(CStr(ModPOS.Redondear(TotalVenta, 2)), "Currency")


                                ModPOS.Ejecuta("sp_aplica_descte", "@VENTA", VENClave, "@Tipo", TipoAplicacion, "@DESClave", DESClave, "@DescuentoPor", PorcDescCliente, "@Usuario", ModPOS.UsuarioActual)

                                Dim dt As DataTable
                                dt = ModPOS.SiExisteRecupera("sp_ventadetalle_open", "@VENClave", VENClave)
                                If Not dt Is Nothing AndAlso dt.Rows.Count() > 0 Then
                                    ModPOS.RecalculaImpuesto(dt, TImpuesto, SUCClave)
                                    dt.Dispose()
                                End If

                            Case Is = 2 'Bonificación
                                Dim Porcentaje As Double = PorcDescCliente / TotalVenta

                                TotalAhorro += PorcDescCliente
                                TotalVenta -= PorcDescCliente

                                LblAhorro.Text = Format(CStr(ModPOS.Redondear(TotalAhorro, 2)), "Currency")
                                LblTotal.Text = Format(CStr(ModPOS.Redondear(TotalVenta, 2)), "Currency")


                                ModPOS.Ejecuta("sp_aplica_descte", "@VENTA", VENClave, "@Tipo", TipoAplicacion, "@DESClave", DESClave, "@DescuentoPor", Porcentaje, "@Usuario", ModPOS.UsuarioActual)

                                Dim dt As DataTable
                                dt = ModPOS.SiExisteRecupera("sp_ventadetalle_open", "@VENClave", VENClave)
                                If Not dt Is Nothing AndAlso dt.Rows.Count() > 0 Then
                                    ModPOS.RecalculaImpuesto(dt, TImpuesto, SUCClave)
                                    dt.Dispose()
                                End If

                            Case Is = 3 'Puntos
                                Dim ImpPuntos As Double = PorcDescCliente * TotalVenta

                                TotalPuntos += ImpPuntos
                                LblCantidadPuntos.Text = ModPOS.Redondear(TotalPuntos, 2).ToString("#,##0.00")

                                ModPOS.Ejecuta("sp_aplica_descte", "@VENTA", VENClave, "@Tipo", TipoAplicacion, "@DESClave", DESClave, "@DescuentoPor", PorcDescCliente, "@Usuario", ModPOS.UsuarioActual)


                        End Select

                        ' Si no aplica en cascada deja de aplicar descuentos
                        If DescuentoCliente = 0 Then
                            Exit For
                        End If

                    End If
                Next
                dtDescCte.Dispose()
            Else
                DescuentoCliente = -1
                PorcDescCliente = 0
                TipoDesCte = 0
                DESClave = ""
            End If


            ModPOS.Ejecuta("sp_actualiza_venta", "@VENClave", VENClave, "@Estado", 2, "@ALMClave", ALMClave)

            If VentaCerrada = False Then
                ModPOS.Ejecuta("sp_agrega_venta", "@VENClave", VENClave)
            End If


            If TipoDocumento <> 2 AndAlso GeneraMovSalida Then
                ModPOS.GeneraMovInv(2, 1, 1, VENClave, ALMClave, LblFolio.Text, Nothing)
                ModPOS.ActualizaExistAlm(2, 1, VENClave, ALMClave)
                ModPOS.ActualizaExistUbc(2, 1, VENClave, ALMClave)
                ModPOS.Ejecuta("sp_act_saldo_cte", "@Tipo", 1, "@Cliente", CTEClaveActual, "@Importe", TotalVenta)
                GeneraMovSalida = False
            End If

            VentaCerrada = True
            BtnCliente.Enabled = False
            TxtCliente.Enabled = False
            TxtCantidad.Enabled = False
            TxtProducto.Enabled = False
            Me.BtnBusquedaProducto.Enabled = False
            Me.BtnPromocion.Enabled = False


            If TipoDocumento = 1 Then
                LblPuntodeVenta.ForeColor = Color.White
                LblPuntodeVenta.Text = "VENTA CERRADA"
                LblPuntodeVenta.BackColor = Color.Red
            ElseIf TipoDocumento = 2 Then
                LblPuntodeVenta.ForeColor = Color.White
                LblPuntodeVenta.Text = "PEDIDO CERRADO"
                LblPuntodeVenta.BackColor = Color.Red
            ElseIf TipoDocumento = 3 Then
                LblPuntodeVenta.ForeColor = Color.White
                LblPuntodeVenta.Text = "CRÉDITO CERRADO"
                LblPuntodeVenta.BackColor = Color.Red
            End If


            Select Case MessageBox.Show("¿Desea realizar una nueva venta?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                Case DialogResult.No
                  
                    Finalizar = True
                    'ImprimirPedido()
                    ''Ciclo para impresion de copias
                    'If NumCopias > 0 Then
                    '    Dim i As Integer
                    '    For i = 1 To NumCopias
                    '        ImprimirPedido()
                    '    Next
                    'End If
                Case Windows.Forms.DialogResult.Yes
                    Finalizar = False
            End Select


            If Finalizar = False Then
                dtDetalle.Rows.Clear()


                TotalArticulos = 0
                TotalPuntos = 0
                TotalAhorro = 0

                LblCantidadPuntos.Text = ModPOS.Redondear(TotalPuntos, 2).ToString("#,##0.00")
                LblCantidadArticulos.Text = CStr(TotalArticulos)
                LblAhorro.Text = Format(CStr(ModPOS.Redondear(TotalAhorro, 2)), "Currency")
                LblTotal.Text = Format(CStr(0.0), "Currency")

                LblFolio.Text = Referencia & "-0"


                'Si el descuento se aplica 1 sola vez por venta se elimina al cliente de dicho descuento despues de aplicarlo
                If TipoDocumento = 1 AndAlso TipoDesCte = 1 Then
                    ModPOS.Ejecuta("sp_elimina_descte", _
                                   "@DESClave", DESClave, _
                                   "@CTEClave", CTEClaveActual)
                End If

                BtnVenta.PerformClick()

            Else
                Me.Close()
            End If

        ElseIf VentaCerrada = False Then
            ModPOS.Ejecuta("sp_act_folio", "@PDVClave", PDVClave, "@Incremento", -1, "@Tipo", 1)
            ModPOS.Ejecuta("sp_elimina_venta", "@VENClave", VENClave)

            VentaCerrada = True
            BtnCliente.Enabled = False
            BtnCerrar.Enabled = False
            TxtCantidad.Enabled = False
            TxtProducto.Enabled = False
            TxtCliente.Enabled = False
            GeneraMovSalida = False

            dtDetalle.Rows.Clear()

            TotalArticulos = 0
            TotalPuntos = 0
            TotalAhorro = 0

            LblCantidadPuntos.Text = ModPOS.Redondear(TotalPuntos, 2).ToString("#,##0.00")
            LblCantidadArticulos.Text = CStr(TotalArticulos)
            LblAhorro.Text = Format(CStr(ModPOS.Redondear(TotalAhorro, 2)), "Currency")
            LblTotal.Text = Format(CStr(0.0), "Currency")

            LblFolio.Text = Referencia & "-0"

            Me.Close()
        ElseIf TotalArticulos > 0 Then
            'Imprimir Pedido
            Select Case MessageBox.Show("¿Desea imprimir el pedido?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                Case DialogResult.Yes
                    ImprimirPedido()
            End Select

        End If

    End Sub

    Private Sub BtnPromocion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPromocion.Click

        Dim a As New FrmConsultaGen
        a.Text = "Promociones Vigentes"
        ModPOS.ActualizaGrid(False, a.GridConsultaGen, "sp_filtra_promocion_vigente", "@CTEClave", CTEClaveActual)
        a.ShowDialog()
        a.Dispose()

    End Sub

    Private Sub BtnRecuperar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRecuperar.Click
        If VentaCerrada Then

            Dim Folio As String = ""
            Dim FechaPedido, FechaPedidoFin As DateTime

            Dim a As New MeFiltroPed
            a.ShowDialog()
            If a.DialogResult = DialogResult.OK Then
                Folio = a.Folio
                FechaPedido = a.FechaPedido
                FechaPedidoFin = a.FechaPedidoFin
            End If
            a.Dispose()

            If Folio <> "" Then
                Dim dtPedido As DataTable

                dtPedido = ModPOS.SiExisteRecupera("sp_recupera_pedido", "@Folio", Folio, "@FechaIni", FechaPedido, "@FechaFin", FechaPedidoFin)

                If Not dtPedido Is Nothing Then
                    If Folio <> LblFolio.Text Then

                        VENClave = dtPedido.Rows(0)("VENClave")
                        AtiendeNombre = dtPedido.Rows(0)("VendedorName")
                        AtiendeClave = dtPedido.Rows(0)("Cajero")
                        CTEClaveActual = dtPedido.Rows(0)("Cliente")
                        CTENombreActual = dtPedido.Rows(0)("ClienteName")
                        LblFolio.Text = dtPedido.Rows(0)("Folio")
                        TipoDocumento = dtPedido.Rows(0)("Tipo")

                        dtDetalle = ModPOS.Recupera_Tabla("sp_pedido_detalle", "@ALMClave", ALMClave, "@VENClave", VENClave)
                        GridDetalle.DataSource = dtDetalle
                        GridDetalle.RetrieveStructure(True)
                        GridDetalle.GroupByBoxVisible = False
                        GridDetalle.RootTable.Columns("PROClave").Visible = False
                        GridDetalle.RootTable.Columns("Costo").Visible = False
                        GridDetalle.RootTable.Columns("PrecioBruto").Visible = False
                        GridDetalle.RootTable.Columns("Seguimiento").Visible = False
                        GridDetalle.RootTable.Columns("DiasGarantia").Visible = False
                        GridDetalle.RootTable.Columns("TProducto").Visible = False
                        GridDetalle.RootTable.Columns("Ahorro").Visible = False
                        GridDetalle.RootTable.Columns("Solicitado").Visible = False

                        GridDetalle.RootTable.Columns("Cantidad").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
                        GridDetalle.RootTable.Columns("Disponible").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
                        GridDetalle.RootTable.Columns("Precio").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
                        GridDetalle.RootTable.Columns("Dsc%").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
                        GridDetalle.RootTable.Columns("Dsc").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
                        GridDetalle.RootTable.Columns("Pts").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
                        GridDetalle.RootTable.Columns("Importe").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
                        GridDetalle.RootTable.Columns("Subtotal").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far

                        Dim fc As Janus.Windows.GridEX.GridEXFormatCondition
                        fc = New Janus.Windows.GridEX.GridEXFormatCondition(GridDetalle.RootTable.Columns("Dsc%"), Janus.Windows.GridEX.ConditionOperator.GreaterThan, 0)
                        fc.FormatStyle.ForeColor = Color.Red
                        GridDetalle.RootTable.FormatConditions.Add(fc)



                        TotalArticulos = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Pts"), Janus.Windows.GridEX.AggregateFunction.Count)
                        TotalPuntos = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Pts"), Janus.Windows.GridEX.AggregateFunction.Sum)
                        TotalAhorro = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Ahorro"), Janus.Windows.GridEX.AggregateFunction.Sum)
                        TotalVenta = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Subtotal"), Janus.Windows.GridEX.AggregateFunction.Sum)

                        LblCantidadPuntos.Text = ModPOS.Redondear(TotalPuntos, 2).ToString("#,##0.00")
                        LblCantidadArticulos.Text = CStr(TotalArticulos)
                        LblAhorro.Text = Format(CStr(ModPOS.Redondear(TotalAhorro, 2)), "Currency")
                        LblTotal.Text = Format(CStr(ModPOS.Redondear(TotalVenta, 2)), "Currency")

                        'Envia a venta a temporal
                        ModPOS.Ejecuta("sp_enviar_tmp", "@VENClave", VENClave)
                    End If
                    dtPedido.Dispose()

                Else
                    Beep()
                    MessageBox.Show("No es posible recuperar un pedido con el Folio y Fecha indicada.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
        Else
            Beep()
            MessageBox.Show("No es posible recuperar un pedido debido a que el pedido actual no ha sido Cerrado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub BtnConvertir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConvertir.Click
        If TipoDocumento = 2 AndAlso VentaCerrada AndAlso Not VENClave Is Nothing AndAlso dtDetalle.Rows.Count > 0 Then
            'Verifica si hay existencia disponible
            Dim fila As Integer
            For fila = 0 To dtDetalle.Rows.Count - 1
                Dim Existencia As Double
                Existencia = dtDetalle.Compute("Sum(Cantidad)", "PROClave ='" + dtDetalle.Rows(fila)("PROClave") + "'")
                dtDetalle.Rows(fila)("Solicitado") = Existencia
            Next fila

            Dim foundRows() As System.Data.DataRow
            foundRows = dtDetalle.Select("Solicitado > Disponible")
            If foundRows.Length = 0 Then
                'Verifica si requieren seguimiento
                foundRows = dtDetalle.Select("Seguimiento > 1")
                If foundRows.Length = 0 Then
                    Dim i As Integer
                    For i = 0 To foundRows.GetUpperBound(0)
                        'SI REQUIERE SEGUIMIENTO DE SERIAL
                        If foundRows(i)("Seguimiento") = 2 Then
                            Dim SerialReg As Integer = 0
                            Dim PorRegistrar As Double
                            PorRegistrar = dCantidad
                            Do
                                Dim a As New FrmSerial
                                a.DOCClave = VENClave
                                a.PROClave = foundRows(i)("PROClave")
                                a.Clave = foundRows(i)("Clave")
                                a.Nombre = foundRows(i)("Nombre")
                                a.Cantidad = foundRows(i)("Cantidad")
                                a.Dias = foundRows(i)("DiasGarantia")
                                a.TipoDoc = 1
                                a.TipoMov = 2
                                a.ShowDialog()
                                SerialReg = SerialReg + a.NumSerialRegistrados
                                PorRegistrar = PorRegistrar - a.NumSerialRegistrados
                                a.Dispose()
                            Loop Until SerialReg = foundRows(i)("Cantidad") OrElse PorRegistrar = 0
                        End If

                        'SI REQUIERE SEGUIMIENTO DE LOTE
                        If foundRows(i)("Seguimiento") = 3 Then
                            Dim LoteReg As Integer = 0
                            Dim PorRegistrar As Double
                            PorRegistrar = dCantidad
                            Do
                                Dim a As New FrmLote
                                a.DOCClave = VENClave
                                a.PROClave = foundRows(i)("PROClave")
                                a.Clave = foundRows(i)("Clave")
                                a.Nombre = foundRows(i)("Nombre")
                                a.CantXRegistrar = PorRegistrar
                                a.TipoDoc = 1
                                a.TipoMov = 2
                                a.ShowDialog()
                                LoteReg = LoteReg + a.NumSerialRegistrados
                                PorRegistrar = PorRegistrar - a.NumSerialRegistrados
                                a.Dispose()
                            Loop Until LoteReg = foundRows(i)("Cantidad") OrElse PorRegistrar = 0
                        End If
                    Next i
                End If
                'Convierte a Venta y Afecta inventario
                ModPOS.Ejecuta("sp_convierte_venta", "@VENClave", VENClave)
                ModPOS.GeneraMovInv(2, 1, 1, VENClave, ALMClave, LblFolio.Text, Nothing)
                ModPOS.ActualizaExistAlm(2, 1, VENClave, ALMClave)
                ModPOS.ActualizaExistUbc(2, 1, VENClave, ALMClave)

                dtDetalle.Rows.Clear()

                VENClave = Nothing

                MessageBox.Show("El pedido ha sido convertido correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else
                Beep()
                MessageBox.Show("No es posible convertir el pedido actual a venta debido a que no ha existencia disponible suficiente para completarlo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            Beep()
            MessageBox.Show("No es posible convertir el pedido actual a venta debido a que no ha sido Cerrado o no hay un pedido activo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub BtnPedido_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        crearDoc(2)
    End Sub

    Private Sub BtnOtrosDocumentos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOtrosDocumentos.Click
        If VentaCerrada Then
            BtnOtrosDocumentos.ContextMenuStrip.Show(BtnOtrosDocumentos, New Point(0, 0), ToolStripDropDownDirection.AboveRight)
        Else
            Beep()
            MessageBox.Show("El documento actual no ha sido Cerrado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        TxtProducto.Focus()

    End Sub

    Private Sub ItemCotizacion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ItemCotizacion.Click
        crearDoc(2)
    End Sub

    Private Sub ItemCredito_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ItemCredito.Click
        crearDoc(3)
    End Sub

    Private Sub BtnDeshacer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDeshacer.Click
        If Not VentaCerrada Then
            If TotalArticulos > 0 Then
                If Not GridDetalle.GetValue("DVEClave") Is Nothing Then
                    Dim foundRows() As System.Data.DataRow
                    foundRows = dtDetalle.Select("DVEClave = '" & GridDetalle.GetValue("DVEClave") & "'")
                    If foundRows.Length > 0 Then
                        dtDetalle.Rows.Remove(foundRows(0))
                        TotalArticulos -= 1
                        GridDetalle.MoveLast()
                    End If

                    TotalPuntos = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Pts"), Janus.Windows.GridEX.AggregateFunction.Sum)
                    TotalAhorro = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Ahorro"), Janus.Windows.GridEX.AggregateFunction.Sum)
                    TotalVenta = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Subtotal"), Janus.Windows.GridEX.AggregateFunction.Sum)

                    LblCantidadPuntos.Text = ModPOS.Redondear(TotalPuntos, 2).ToString("#,##0.00")
                    LblCantidadArticulos.Text = CStr(TotalArticulos)
                    LblAhorro.Text = Format(CStr(ModPOS.Redondear(TotalAhorro, 2)), "Currency")
                    LblTotal.Text = Format(CStr(ModPOS.Redondear(TotalVenta, 2)), "Currency")

                    If TotalArticulos = 0 Then
                        TxtProducto.Enabled = True
                        TxtCantidad.Enabled = True
                        BtnCliente.Enabled = True
                        TxtCliente.Enabled = True

                        Me.BtnBusquedaProducto.Enabled = True
                        Me.BtnPromocion.Enabled = True

                        If CambiarCliente = False Then
                            BtnCliente.Enabled = True
                            TxtCliente.Enabled = True
                            CambiarCliente = True
                        End If

                    End If

                    If Moneda <> MonedaCambio Then
                        If TotalVenta > 0 Then
                            LblTipoCambio.Text = MonedaRef.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(TotalVenta / TipoCambio, 2)), "Currency")
                        Else
                            LblTipoCambio.Text = MonedaRef.ToUpper.Trim & " " & Format(CStr(ModPOS.Redondear(TotalVenta, 2)), "Currency")
                        End If
                    End If
                End If
            End If
        Else
            MsgBox("El documento actual ya ha sido cerrado por lo que no es posible modificarlo", MsgBoxStyle.Information, "Información")
        End If
    End Sub

    Private Sub GridDetalle_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridDetalle.DoubleClick
        If Not GridDetalle.GetValue(0) Is Nothing Then

            Dim a As New FrmAddProducto
            a.PDVClave = PDVClave
            a.TImpuesto = TImpuesto
            a.Tipo = TipoDocumento
            a.PREClave = ListaPrecio
            a.PROClave = GridDetalle.GetValue("PROClave")
            a.NombreCliente = CTENombreActual
            a.Clave = GridDetalle.GetValue("Clave")
            a.Nombre = GridDetalle.GetValue("Nombre")
            a.ImporteNeto = GridDetalle.GetValue("Precio")
            a.Cantidad = GridDetalle.GetValue("Cantidad")
            a.Costo = GridDetalle.GetValue("Costo")
            a.PrecioBruto = GridDetalle.GetValue("PrecioBruto")
            a.FactorImpuesto = GridDetalle.GetValue("PorcImpuesto")
            a.DescImp = GridDetalle.GetValue("Dsc")
            a.PorcDesc = GridDetalle.GetValue("Dsc%") / 100
            ' a.PorcPts = GridDetalle.GetValue("PuntosPor")
            a.NumDecimal = iNumDecimales
            a.ModificaPrecioServicio = Me.ModificaPrecioServicio
            a.iTProducto = iTProducto
            a.CambiaPrecio = USRCambiaPrecio
            a.PorcMaxDesc = PorcMaxDesc
            a.MinimoNeto = dImporteNeto

            a.ShowDialog()
            If a.DialogResult = DialogResult.OK Then

                Dim foundRows() As System.Data.DataRow
                foundRows = dtDetalle.Select("DVEClave = '" & GridDetalle.GetValue("DVEClave") & "'")

                foundRows(0)("Dsc%") = Redondear(a.PorcDesc * 100, 2)
                foundRows(0)("Dsc") = Redondear(a.DescImp * (1 + a.FactorImpuesto), 2)
                '  foundRows(0)("Pts") = Redondear((a.Cantidad * a.ImporteNeto) * a.PorcPts, 2)
                foundRows(0)("PrecioBruto") = a.PrecioBruto

                foundRows(0)("Precio") = Redondear(a.dNormal, 2)
                foundRows(0)("Cantidad") = a.Cantidad
                foundRows(0)("Importe") = Redondear(a.ImporteNeto, 2)
                foundRows(0)("Subtotal") = Redondear(a.Cantidad * a.ImporteNeto, 2)
                foundRows(0)("Ahorro") = Redondear(a.Cantidad * (a.DescImp * (1 + a.FactorImpuesto)), 2)



                TotalPuntos = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Pts"), Janus.Windows.GridEX.AggregateFunction.Sum)
                TotalAhorro = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Ahorro"), Janus.Windows.GridEX.AggregateFunction.Sum)
                TotalVenta = GridDetalle.GetTotal(GridDetalle.CurrentTable.Columns("Subtotal"), Janus.Windows.GridEX.AggregateFunction.Sum)

                LblCantidadPuntos.Text = ModPOS.Redondear(TotalPuntos, 2).ToString("#,##0.00")
                LblCantidadArticulos.Text = CStr(TotalArticulos)
                LblAhorro.Text = Format(CStr(ModPOS.Redondear(TotalAhorro, 2)), "Currency")
                LblTotal.Text = Format(CStr(ModPOS.Redondear(TotalVenta, 2)), "Currency")

                a.Dispose()

            End If
        End If
    End Sub
End Class
