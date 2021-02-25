Imports System.Drawing.Printing

Public Class FrmPrintLabelCode
    Inherits System.Windows.Forms.Form

    Public COMClave As String = ""
    Public iTipoDOc As Integer

    Private dtCode As DataTable

    Private Nombre As String = ""
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
    Private bError As Boolean = False

    ' Public Reporte As String

    Private alerta(0) As PictureBox

    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents CmbPlantilla As Selling.StoreCombo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents NumCopias As System.Windows.Forms.NumericUpDown
    Friend WithEvents dlgPrintDialog As System.Windows.Forms.PrintDialog
    Friend WithEvents BtnAceptar As Janus.Windows.EditControls.UIButton
    Friend WithEvents ChkSeleccionar As System.Windows.Forms.CheckBox
    Friend WithEvents GridDetalle As Janus.Windows.GridEX.GridEX

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPrintLabelCode))
        Me.BtnCancel = New Janus.Windows.EditControls.UIButton
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.NumCopias = New System.Windows.Forms.NumericUpDown
        Me.CmbPlantilla = New Selling.StoreCombo
        Me.Label1 = New System.Windows.Forms.Label
        Me.dlgPrintDialog = New System.Windows.Forms.PrintDialog
        Me.BtnAceptar = New Janus.Windows.EditControls.UIButton
        Me.ChkSeleccionar = New System.Windows.Forms.CheckBox
        Me.GridDetalle = New Janus.Windows.GridEX.GridEX
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumCopias, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnCancel
        '
        Me.BtnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Image = CType(resources.GetObject("BtnCancel.Image"), System.Drawing.Image)
        Me.BtnCancel.Location = New System.Drawing.Point(338, 290)
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
        Me.PictureBox1.Location = New System.Drawing.Point(518, 13)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox1.TabIndex = 73
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(267, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 13)
        Me.Label2.TabIndex = 75
        Me.Label2.Text = "No. Copias"
        '
        'NumCopias
        '
        Me.NumCopias.Location = New System.Drawing.Point(327, 38)
        Me.NumCopias.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.NumCopias.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumCopias.Name = "NumCopias"
        Me.NumCopias.Size = New System.Drawing.Size(100, 20)
        Me.NumCopias.TabIndex = 76
        Me.NumCopias.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'CmbPlantilla
        '
        Me.CmbPlantilla.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbPlantilla.BackColor = System.Drawing.SystemColors.Window
        Me.CmbPlantilla.Location = New System.Drawing.Point(80, 11)
        Me.CmbPlantilla.Name = "CmbPlantilla"
        Me.CmbPlantilla.Size = New System.Drawing.Size(435, 21)
        Me.CmbPlantilla.TabIndex = 38
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 16)
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
        Me.BtnAceptar.Location = New System.Drawing.Point(434, 290)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(90, 37)
        Me.BtnAceptar.TabIndex = 75
        Me.BtnAceptar.Text = "&Aceptar"
        Me.BtnAceptar.ToolTipText = "Guardar cambios"
        Me.BtnAceptar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'ChkSeleccionar
        '
        Me.ChkSeleccionar.AutoSize = True
        Me.ChkSeleccionar.Location = New System.Drawing.Point(10, 41)
        Me.ChkSeleccionar.Name = "ChkSeleccionar"
        Me.ChkSeleccionar.Size = New System.Drawing.Size(110, 17)
        Me.ChkSeleccionar.TabIndex = 77
        Me.ChkSeleccionar.Text = "Seleccionar Todo"
        Me.ChkSeleccionar.UseVisualStyleBackColor = True
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
        Me.GridDetalle.GroupByBoxVisible = False
        Me.GridDetalle.Location = New System.Drawing.Point(8, 62)
        Me.GridDetalle.Name = "GridDetalle"
        Me.GridDetalle.RecordNavigator = True
        Me.GridDetalle.Size = New System.Drawing.Size(516, 222)
        Me.GridDetalle.TabIndex = 78
        Me.GridDetalle.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'FrmPrintLabelCode
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(532, 333)
        Me.Controls.Add(Me.GridDetalle)
        Me.Controls.Add(Me.ChkSeleccionar)
        Me.Controls.Add(Me.NumCopias)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BtnAceptar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.CmbPlantilla)
        Me.Controls.Add(Me.BtnCancel)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(457, 194)
        Me.Name = "FrmPrintLabelCode"
        Me.Text = "Imprimir Etiquetas"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumCopias, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub FrmPrintLabel_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If bError Then
            e.Cancel = True
        End If
    End Sub

    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If Me.CmbPlantilla.SelectedValue Is Nothing Then
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

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        bError = False
        Me.Close()
    End Sub


    Private Sub FrmPrintLabel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Me.StartPosition = FormStartPosition.CenterScreen

        alerta(0) = Me.PictureBox1

        If iTipoDOc = 3 Then
            dtCode = ModPOS.Recupera_Tabla("sp_etiquetas_ubicacion", "@ESTClave", COMClave)
        Else
            dtCode = ModPOS.Recupera_Tabla("sp_etiquetas_compra", "@Tipo", iTipoDOc, "@COMClave", COMClave)
        End If
       
        If dtCode.Rows.Count > 0 Then
            GridDetalle.DataSource = dtCode
            GridDetalle.RetrieveStructure()
            GridDetalle.AutoSizeColumns()

            If iTipoDOc = 3 Then
                GridDetalle.RootTable.Columns("Ubicación").Selectable = False
                GridDetalle.RootTable.Columns("Referencia").Selectable = False
            Else
                GridDetalle.RootTable.Columns("GTIN").Visible = False
                GridDetalle.RootTable.Columns("Clave").Visible = False
                GridDetalle.CurrentTable.Columns("Nombre").Selectable = False
            End If
        End If

        If iTipoDOc = 3 Then
            With CmbPlantilla
                .Conexion = ModPOS.BDConexion
                .ProcedimientoAlmacenado = "sp_filtra_labelsheet"
                .Parametro1 = 2
                .NombreParametro1 = "Tipo"
                .llenar()
            End With
        Else
            With CmbPlantilla
                .Conexion = ModPOS.BDConexion
                .ProcedimientoAlmacenado = "sp_filtra_labelsheet"
                .Parametro1 = 1
                .NombreParametro1 = "Tipo"
                .llenar()
            End With
        End If
        
    End Sub

    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click
        If validaForm() Then

            Dim foundRows() As DataRow
            foundRows = dtCode.Select("Marca = 1")

            If foundRows.GetLength(0) > 0 Then

                Dim dt As DataTable = ModPOS.Recupera_Tabla("sp_recupera_labelsheet", "@IDSheet", Me.CmbPlantilla.SelectedValue)

                Nombre = dt.Rows(0)("Nombre")
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

            

                Dim lsAddressLabels As New LabelPrinting.LabelSet(New PaperSize(Nombre, ModPOS.Redondear(AnchoPapel * 100 * 0.3937, 0), ModPOS.Redondear(AltoPapel * 100 * 0.3937, 0)), _
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

                Dim i As Integer

                For i = 0 To foundRows.GetUpperBound(0)

                    ' Create label objects... 

                    Dim lblAddressLabel As New LabelPrinting.LabelCode()

                    If iTipoDOc = 3 Then
                        lblAddressLabel.AddClave(foundRows(i)("Ubicación"))
                        lblAddressLabel.AddTexto(foundRows(i)("Referencia"))
                        lblAddressLabel.AddCodigo("*" & foundRows(i)("Ubicación") & "*")
                    Else
                        lblAddressLabel.AddClave(foundRows(i)("Clave"))
                        lblAddressLabel.AddTexto(foundRows(i)("Nombre"))
                        lblAddressLabel.AddCodigo("*" & foundRows(i)("GTIN") & "*")
                    End If
                    
                    Dim numCopias As Integer

                    If iTipoDOc = 3 Then
                        numCopias = Me.NumCopias.Value
                    Else
                        numCopias = foundRows(i)("Cantidad") * Me.NumCopias.Value
                    End If

                    ' And add the labels to your label set:
                    Dim j As Integer
                    For j = 1 To numCopias
                        lsAddressLabels.AddLabelCode(lblAddressLabel)
                    Next

                Next

                ' Create a PrintDialog to allow the user to choose a printer:

                dlgPrintDialog.Document = lsAddressLabels
                dlgPrintDialog.AllowSomePages = True

                ' Offer the user a preview, or print directly to paper:

                If dlgPrintDialog.ShowDialog() = DialogResult.OK Then
                    dlgPrintDialog.Document.Print()
                End If

                bError = False
            Else
                bError = True
                MessageBox.Show("No se encontraron registros seleccionados para imprimir", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            bError = True
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub ChkSeleccionar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkSeleccionar.CheckedChanged
        If dtCode.Rows.Count > 0 Then
            Dim i As Integer

            Cursor.Current = Cursors.WaitCursor
            If ChkSeleccionar.Checked Then
                For i = 0 To dtCode.Rows.Count - 1
                    dtCode.Rows(i)("Marca") = True
                Next
            Else
                For i = 0 To dtCode.Rows.Count - 1
                    dtCode.Rows(i)("Marca") = False
                Next

            End If
            Cursor.Current = Cursors.Default
        End If
    End Sub

    Private Sub GridDetalle_CellEdited(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridDetalle.CellEdited
        Select Case GridDetalle.CurrentColumn.Caption
            Case "Cantidad"
                If Not (IsNumeric(GridDetalle.GetValue("Cantidad")) AndAlso CDbl(GridDetalle.GetValue("Cantidad")) > 0) Then
                    GridDetalle.SetValue("Cantidad", 1)
                End If
        End Select
    End Sub
End Class
