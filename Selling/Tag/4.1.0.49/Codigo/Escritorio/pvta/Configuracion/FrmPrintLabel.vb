Imports System.Drawing.Printing

Public Class FrmPrintLabel
    Inherits System.Windows.Forms.Form

    Public Titulo As String = "Imprimir Etiquetas"
    Private PROClave As String
    Public Clave As String
    Private Nombre As String
    Private GTIN As String

    Private TallaColor As Integer = 0
    Private TipoPapel As String = ""
    Private AnchoPapel As Integer
    Private AltoPapel As Integer
    Private mpSuperior As Integer
    Private mpInferior As Integer
    Private mpIzquierdo As Integer
    Private mpDerecho As Integer
    Private Horizontal As Boolean = False
    Private Columnas As Integer
    Private Filas As Integer
    Private EspacioColumna As Integer
    Private EspacioFila As Integer
    Private AnchoEtiqueta As Integer
    Private AltoEtiqueta As Integer
    Private meSuperior As Integer
    Private meInferior As Integer
    Private meIzquierdo As Integer
    Private meDerecho As Integer
    Private TipoLetra As String = ""
    Private SizeLetra As Double
    Private SizeCodigo As Double


    ' Public Reporte As String

    Private alerta(2) As PictureBox

    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents CmbPlantilla As Selling.StoreCombo
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnBuscaProd As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtClaveProd As System.Windows.Forms.TextBox
    Friend WithEvents TxtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents cmbUnidad As Selling.StoreCombo
    Friend WithEvents dlgPrintDialog As System.Windows.Forms.PrintDialog
    Friend WithEvents BtnAceptar As Janus.Windows.EditControls.UIButton

    Private reloj As parpadea

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

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents BtnCancel As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPrintLabel))
        Me.BtnCancel = New Janus.Windows.EditControls.UIButton
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown
        Me.cmbUnidad = New Selling.StoreCombo
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.BtnBuscaProd = New Janus.Windows.EditControls.UIButton
        Me.TxtClaveProd = New System.Windows.Forms.TextBox
        Me.TxtDescripcion = New System.Windows.Forms.TextBox
        Me.CmbPlantilla = New Selling.StoreCombo
        Me.Label1 = New System.Windows.Forms.Label
        Me.dlgPrintDialog = New System.Windows.Forms.PrintDialog
        Me.BtnAceptar = New Janus.Windows.EditControls.UIButton
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnCancel
        '
        Me.BtnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Image = CType(resources.GetObject("BtnCancel.Image"), System.Drawing.Image)
        Me.BtnCancel.Location = New System.Drawing.Point(252, 120)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancel.TabIndex = 4
        Me.BtnCancel.Text = "&Salir"
        Me.BtnCancel.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancel.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(412, 14)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox1.TabIndex = 73
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.PictureBox3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.NumericUpDown1)
        Me.GroupBox2.Controls.Add(Me.cmbUnidad)
        Me.GroupBox2.Controls.Add(Me.PictureBox2)
        Me.GroupBox2.Controls.Add(Me.BtnBuscaProd)
        Me.GroupBox2.Controls.Add(Me.TxtClaveProd)
        Me.GroupBox2.Controls.Add(Me.TxtDescripcion)
        Me.GroupBox2.Location = New System.Drawing.Point(2, 44)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(436, 70)
        Me.GroupBox2.TabIndex = 73
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Producto"
        '
        'PictureBox3
        '
        Me.PictureBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(131, 47)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(14, 15)
        Me.PictureBox3.TabIndex = 122
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(243, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 13)
        Me.Label2.TabIndex = 75
        Me.Label2.Text = "No. Copias"
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Location = New System.Drawing.Point(308, 44)
        Me.NumericUpDown1.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.NumericUpDown1.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(100, 20)
        Me.NumericUpDown1.TabIndex = 76
        Me.NumericUpDown1.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'cmbUnidad
        '
        Me.cmbUnidad.Location = New System.Drawing.Point(4, 43)
        Me.cmbUnidad.Name = "cmbUnidad"
        Me.cmbUnidad.Size = New System.Drawing.Size(124, 21)
        Me.cmbUnidad.TabIndex = 121
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(120, 18)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(14, 14)
        Me.PictureBox2.TabIndex = 73
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'BtnBuscaProd
        '
        Me.BtnBuscaProd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnBuscaProd.Image = CType(resources.GetObject("BtnBuscaProd.Image"), System.Drawing.Image)
        Me.BtnBuscaProd.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnBuscaProd.Location = New System.Drawing.Point(410, 17)
        Me.BtnBuscaProd.Name = "BtnBuscaProd"
        Me.BtnBuscaProd.Size = New System.Drawing.Size(23, 22)
        Me.BtnBuscaProd.TabIndex = 84
        Me.BtnBuscaProd.ToolTipText = "Busqueda de Producto"
        Me.BtnBuscaProd.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtClaveProd
        '
        Me.TxtClaveProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtClaveProd.Location = New System.Drawing.Point(4, 18)
        Me.TxtClaveProd.Name = "TxtClaveProd"
        Me.TxtClaveProd.Size = New System.Drawing.Size(113, 21)
        Me.TxtClaveProd.TabIndex = 83
        '
        'TxtDescripcion
        '
        Me.TxtDescripcion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtDescripcion.Enabled = False
        Me.TxtDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDescripcion.Location = New System.Drawing.Point(121, 18)
        Me.TxtDescripcion.Multiline = True
        Me.TxtDescripcion.Name = "TxtDescripcion"
        Me.TxtDescripcion.ReadOnly = True
        Me.TxtDescripcion.Size = New System.Drawing.Size(285, 19)
        Me.TxtDescripcion.TabIndex = 85
        '
        'CmbPlantilla
        '
        Me.CmbPlantilla.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbPlantilla.BackColor = System.Drawing.SystemColors.Window
        Me.CmbPlantilla.Location = New System.Drawing.Point(62, 11)
        Me.CmbPlantilla.Name = "CmbPlantilla"
        Me.CmbPlantilla.Size = New System.Drawing.Size(344, 21)
        Me.CmbPlantilla.TabIndex = 38
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 74
        Me.Label1.Text = "Plantilla"
        '
        'dlgPrintDialog
        '
        Me.dlgPrintDialog.UseEXDialog = True
        '
        'BtnAceptar
        '
        Me.BtnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAceptar.Image = CType(resources.GetObject("BtnAceptar.Image"), System.Drawing.Image)
        Me.BtnAceptar.Location = New System.Drawing.Point(348, 120)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(90, 37)
        Me.BtnAceptar.TabIndex = 75
        Me.BtnAceptar.Text = "&Aceptar"
        Me.BtnAceptar.ToolTipText = "Guardar cambios"
        Me.BtnAceptar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmPrintLabel
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(441, 160)
        Me.Controls.Add(Me.BtnAceptar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.CmbPlantilla)
        Me.Controls.Add(Me.BtnCancel)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPrintLabel"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region


    Private Sub recuperaProducto(ByVal sClave As String)
        Dim dtProducto As DataTable = ModPOS.SiExisteRecupera("sp_found_producto", "@Clave", sClave.Replace("'", "''"))
        If Not dtProducto Is Nothing Then
            'Bloquea al cliente para no permitir que se modifique la lista de precios cuando ya hay productos en la venta

            PROClave = dtProducto.Rows(0)("PROClave")
            Clave = dtProducto.Rows(0)("Clave")
            TxtClaveProd.Text = Clave
            Nombre = dtProducto.Rows(0)("Nombre")
            TxtDescripcion.Text = Nombre
            dtProducto.Dispose()

            With Me.cmbUnidad
                .Conexion = ModPOS.BDConexion
                .ProcedimientoAlmacenado = "sp_filtra_unidadvta"
                .NombreParametro1 = "PROClave"
                .Parametro1 = PROClave
                .llenar()
            End With

        Else
            Clave = ""
            PROClave = ""
            TxtClaveProd.Text = ""
            TxtDescripcion.Text = ""
            GTIN = ""
            Nombre = ""
            MessageBox.Show("¡La Clave de producto no existe!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub FrmPrintLabel_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.PrintLabel.Dispose()
        ModPOS.PrintLabel = Nothing
    End Sub

    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If Me.CmbPlantilla.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.TxtClaveProd.Text = "" OrElse Me.TxtDescripcion.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.cmbUnidad.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(2))
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

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub


    Private Sub FrmPrintLabel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Me.StartPosition = FormStartPosition.CenterScreen

        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2
        alerta(2) = Me.PictureBox3

        Dim dt As DataTable
        dt = ModPOS.Recupera_Tabla("sp_recupera_comparam", "@PARClave", "TallaColor", "@COMClave", ModPOS.CompanyActual)
        If dt.Rows.Count > 0 Then
            TallaColor = IIf(dt.Rows(0)("Valor").GetType.Name = "DBNull", 0, dt.Rows(0)("Valor"))
        End If
        dt.Dispose()

        With CmbPlantilla
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_labelsheet"
            .NombreParametro1 = "Tipo"
            .Parametro1 = 1
            .llenar()
        End With

        Me.Text = Titulo

        If Clave <> "" Then
            recuperaProducto(Clave)
        End If

    End Sub

    Private Sub TxtClaveProd_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtClaveProd.KeyDown
        If e.KeyCode = Keys.Down OrElse e.KeyCode = Keys.Return Then
            If Not TxtClaveProd.Text = vbNullString Then
                recuperaProducto(TxtClaveProd.Text.Trim.ToUpper.Replace("'", "''"))
            End If
        End If
    End Sub



    Private Sub BtnBuscaProd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscaProd.Click
        Dim a As New MeSearch
        If TallaColor = 1 Then
            a.ProcedimientoAlmacenado = "st_search_prod_tc"
            a.CampoCmb = "FiltroTC"
        Else
            a.ProcedimientoAlmacenado = "sp_search_prod"
            a.CampoCmb = "Filtro"
        End If
        a.bReplace = True
        a.TablaCmb = "Producto"
        a.NumColDes = 2
        a.CompaniaRequerido = True
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            TxtClaveProd.Text = a.valor
            recuperaProducto(a.valor)
        End If
        a.Dispose()
    End Sub

    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click
        If validaForm() Then
            Dim dt As DataTable = ModPOS.Recupera_Tabla("sp_recupera_labelsheet", "@IDSheet", Me.CmbPlantilla.SelectedValue)

            TipoPapel = dt.Rows(0)("Nombre")
            AnchoPapel = dt.Rows(0)("AnchoPapel")
            AltoPapel = dt.Rows(0)("AltoPapel")
            mpSuperior = dt.Rows(0)("mpSuperior")
            mpInferior = dt.Rows(0)("mpInferior")
            mpIzquierdo = dt.Rows(0)("mpIzquierdo")
            mpDerecho = dt.Rows(0)("mpDerecho")
            Horizontal = dt.Rows(0)("Horizontal")
            Columnas = dt.Rows(0)("Columnas")
            Filas = dt.Rows(0)("Filas")
            EspacioColumna = dt.Rows(0)("EspacioColumna")
            EspacioFila = dt.Rows(0)("EspacioFila")
            AnchoEtiqueta = dt.Rows(0)("AnchoEtiqueta")
            AltoEtiqueta = dt.Rows(0)("AltoEtiqueta")
            meSuperior = dt.Rows(0)("meSuperior")
            meInferior = dt.Rows(0)("meInferior")
            meIzquierdo = dt.Rows(0)("meIzquierdo")
            meDerecho = dt.Rows(0)("meDerecho")
            TipoLetra = dt.Rows(0)("TipoLetra")
            SizeLetra = dt.Rows(0)("SizeLetra")
            SizeCodigo = dt.Rows(0)("SizeCodigo")
            dt.Dispose()

            Dim dtProducto As DataTable = ModPOS.SiExisteRecupera("sp_label_search", "@PROClave", PROClave, "@UNDClave", Me.cmbUnidad.SelectedValue)
            GTIN = dtProducto.Rows(0)("GTIN")
            dtProducto.Dispose()

            Dim lsAddressLabels As New LabelPrinting.LabelSet(New PaperSize(TipoPapel, ModPOS.Redondear(AnchoPapel * 100 * 0.3937, 0), ModPOS.Redondear(AltoPapel * 100 * 0.3937, 0)), _
                                                                         Horizontal, _
                                                                         ModPOS.Redondear(AnchoEtiqueta * 100 * 0.3937, 0), _
                                                                         ModPOS.Redondear(AltoEtiqueta * 100 * 0.3937, 0), _
                                                                         Columnas, _
                                                                         ModPOS.Redondear(EspacioColumna * 100 * 0.3937, 0), _
                                                                         Filas, _
                                                                         ModPOS.Redondear(EspacioFila * 100 * 0.3937, 0), _
                                                                         ModPOS.Redondear(mpIzquierdo * 100 * 0.3937, 0), _
                                                                         ModPOS.Redondear(mpDerecho * 100 * 0.3937, 0), _
                                                                         ModPOS.Redondear(mpSuperior * 100 * 0.3937, 0), _
                                                                         ModPOS.Redondear(mpInferior * 100 * 0.3937, 0), _
                                                                         ModPOS.Redondear(meIzquierdo * 100 * 0.3937, 0), _
                                                                         ModPOS.Redondear(meDerecho * 100 * 0.3937, 0), _
                                                                         ModPOS.Redondear(meSuperior * 100 * 0.3937, 0), _
                                                                        ModPOS.Redondear(meInferior * 100 * 0.3937, 0))

            lsAddressLabels.LabelFont = New Font(TipoLetra, SizeLetra)
            
            lsAddressLabels.LabelCodeFont = New Font("Free 3 of 9 Extended", SizeCodigo)

            ' Create label objects... 

            Dim lblAddressLabel As New LabelPrinting.LabelCode()

            lblAddressLabel.AddCodigo("*" & GTIN & "*")
            lblAddressLabel.AddTexto(Nombre)
            lblAddressLabel.AddClave(Clave)

            Dim numCopias As Integer

            numCopias = Me.NumericUpDown1.Value

            ' And add the labels to your label set:
            Dim i As Integer
            For i = 1 To numCopias
                lsAddressLabels.AddLabelCode(lblAddressLabel)
            Next

            ' Create a PrintDialog to allow the user to choose a printer:

            dlgPrintDialog.Document = lsAddressLabels
            dlgPrintDialog.AllowSomePages = True

            'print directly to paper:

            If dlgPrintDialog.ShowDialog() = DialogResult.OK Then
                dlgPrintDialog.Document.Print()
            End If

        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub
End Class
