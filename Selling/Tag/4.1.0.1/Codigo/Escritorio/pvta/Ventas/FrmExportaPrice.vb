Public Class FrmExportaPrice
    Inherits System.Windows.Forms.Form

    Private dtPrecios, dtlineas As DataTable

    Private Linea As String

    Public Titulo As String
    Private bError As Boolean = False
    Private CTEClave As String
    Private dtListas As DataTable

    Private LineaCargada As Boolean
    ' Public Reporte As String

    Private alerta(3) As PictureBox

    Friend WithEvents ChkToda As System.Windows.Forms.CheckBox
    Friend WithEvents ChkListSuc As System.Windows.Forms.CheckedListBox
    Friend WithEvents GrpListas As System.Windows.Forms.GroupBox
    Friend WithEvents ChkMarcaTodos As System.Windows.Forms.CheckBox
    Friend WithEvents GrpLineas As System.Windows.Forms.GroupBox
    Friend WithEvents ChkListLineas As System.Windows.Forms.CheckedListBox
    Friend WithEvents btnBuscaCte As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents LblCliente As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents cmbSucursalO As Selling.StoreCombo
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label3 As System.Windows.Forms.Label

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
    Friend WithEvents BtnOK As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnCancel As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmExportaPrice))
        Me.ChkToda = New System.Windows.Forms.CheckBox()
        Me.ChkListSuc = New System.Windows.Forms.CheckedListBox()
        Me.GrpListas = New System.Windows.Forms.GroupBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.ChkMarcaTodos = New System.Windows.Forms.CheckBox()
        Me.BtnOK = New Janus.Windows.EditControls.UIButton()
        Me.BtnCancel = New Janus.Windows.EditControls.UIButton()
        Me.GrpLineas = New System.Windows.Forms.GroupBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.ChkListLineas = New System.Windows.Forms.CheckedListBox()
        Me.btnBuscaCte = New Janus.Windows.EditControls.UIButton()
        Me.TxtCliente = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.LblCliente = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.cmbSucursalO = New Selling.StoreCombo()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GrpListas.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpLineas.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ChkToda
        '
        Me.ChkToda.Checked = True
        Me.ChkToda.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkToda.Location = New System.Drawing.Point(8, 211)
        Me.ChkToda.Name = "ChkToda"
        Me.ChkToda.Size = New System.Drawing.Size(124, 23)
        Me.ChkToda.TabIndex = 74
        Me.ChkToda.Text = "Todas las Lineas"
        '
        'ChkListSuc
        '
        Me.ChkListSuc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ChkListSuc.Location = New System.Drawing.Point(3, 16)
        Me.ChkListSuc.Name = "ChkListSuc"
        Me.ChkListSuc.Size = New System.Drawing.Size(523, 91)
        Me.ChkListSuc.TabIndex = 78
        '
        'GrpListas
        '
        Me.GrpListas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpListas.Controls.Add(Me.PictureBox3)
        Me.GrpListas.Controls.Add(Me.ChkListSuc)
        Me.GrpListas.Location = New System.Drawing.Point(2, 95)
        Me.GrpListas.Name = "GrpListas"
        Me.GrpListas.Size = New System.Drawing.Size(529, 110)
        Me.GrpListas.TabIndex = 78
        Me.GrpListas.TabStop = False
        Me.GrpListas.Text = "Listas de Precios"
        '
        'PictureBox3
        '
        Me.PictureBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(100, 2)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(19, 17)
        Me.PictureBox3.TabIndex = 149
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'ChkMarcaTodos
        '
        Me.ChkMarcaTodos.Enabled = False
        Me.ChkMarcaTodos.Location = New System.Drawing.Point(8, 68)
        Me.ChkMarcaTodos.Name = "ChkMarcaTodos"
        Me.ChkMarcaTodos.Size = New System.Drawing.Size(260, 23)
        Me.ChkMarcaTodos.TabIndex = 79
        Me.ChkMarcaTodos.Text = "Seleccionar todas las listas"
        '
        'BtnOK
        '
        Me.BtnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BtnOK.Image = CType(resources.GetObject("BtnOK.Image"), System.Drawing.Image)
        Me.BtnOK.Location = New System.Drawing.Point(446, 404)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(90, 37)
        Me.BtnOK.TabIndex = 3
        Me.BtnOK.Text = "Aceptar"
        Me.BtnOK.ToolTipText = "Aceptar"
        Me.BtnOK.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCancel
        '
        Me.BtnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Image = CType(resources.GetObject("BtnCancel.Image"), System.Drawing.Image)
        Me.BtnCancel.Location = New System.Drawing.Point(350, 404)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancel.TabIndex = 4
        Me.BtnCancel.Text = "&Salir"
        Me.BtnCancel.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancel.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GrpLineas
        '
        Me.GrpLineas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpLineas.Controls.Add(Me.PictureBox4)
        Me.GrpLineas.Controls.Add(Me.ChkListLineas)
        Me.GrpLineas.Location = New System.Drawing.Point(2, 236)
        Me.GrpLineas.Name = "GrpLineas"
        Me.GrpLineas.Size = New System.Drawing.Size(529, 162)
        Me.GrpLineas.TabIndex = 79
        Me.GrpLineas.TabStop = False
        Me.GrpLineas.Text = "Lineas"
        '
        'PictureBox4
        '
        Me.PictureBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(94, 0)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(19, 17)
        Me.PictureBox4.TabIndex = 150
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'ChkListLineas
        '
        Me.ChkListLineas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ChkListLineas.Location = New System.Drawing.Point(3, 16)
        Me.ChkListLineas.Name = "ChkListLineas"
        Me.ChkListLineas.Size = New System.Drawing.Size(523, 143)
        Me.ChkListLineas.TabIndex = 78
        '
        'btnBuscaCte
        '
        Me.btnBuscaCte.Icon = CType(resources.GetObject("btnBuscaCte.Icon"), System.Drawing.Icon)
        Me.btnBuscaCte.Image = CType(resources.GetObject("btnBuscaCte.Image"), System.Drawing.Image)
        Me.btnBuscaCte.ImageSize = New System.Drawing.Size(20, 20)
        Me.btnBuscaCte.Location = New System.Drawing.Point(189, 33)
        Me.btnBuscaCte.Name = "btnBuscaCte"
        Me.btnBuscaCte.Size = New System.Drawing.Size(39, 29)
        Me.btnBuscaCte.TabIndex = 144
        Me.btnBuscaCte.ToolTipText = "Busqueda de Cliente"
        Me.btnBuscaCte.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtCliente
        '
        Me.TxtCliente.Location = New System.Drawing.Point(63, 37)
        Me.TxtCliente.Name = "TxtCliente"
        Me.TxtCliente.ReadOnly = True
        Me.TxtCliente.Size = New System.Drawing.Size(120, 20)
        Me.TxtCliente.TabIndex = 146
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(5, 40)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(80, 14)
        Me.Label8.TabIndex = 145
        Me.Label8.Text = "Cliente"
        '
        'LblCliente
        '
        Me.LblCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblCliente.Location = New System.Drawing.Point(234, 40)
        Me.LblCliente.Name = "LblCliente"
        Me.LblCliente.Size = New System.Drawing.Size(299, 19)
        Me.LblCliente.TabIndex = 147
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(38, 37)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(19, 17)
        Me.PictureBox2.TabIndex = 148
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'cmbSucursalO
        '
        Me.cmbSucursalO.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbSucursalO.BackColor = System.Drawing.SystemColors.Window
        Me.cmbSucursalO.Location = New System.Drawing.Point(63, 9)
        Me.cmbSucursalO.Name = "cmbSucursalO"
        Me.cmbSucursalO.Size = New System.Drawing.Size(276, 21)
        Me.cmbSucursalO.TabIndex = 143
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(38, 9)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(19, 17)
        Me.PictureBox1.TabIndex = 73
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(5, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 16)
        Me.Label3.TabIndex = 142
        Me.Label3.Text = "Sucursal"
        '
        'FrmExportaPrice
        '
        Me.AcceptButton = Me.BtnOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(537, 445)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.LblCliente)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btnBuscaCte)
        Me.Controls.Add(Me.TxtCliente)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cmbSucursalO)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GrpLineas)
        Me.Controls.Add(Me.GrpListas)
        Me.Controls.Add(Me.ChkToda)
        Me.Controls.Add(Me.BtnOK)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.ChkMarcaTodos)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(385, 419)
        Me.Name = "FrmExportaPrice"
        Me.GrpListas.ResumeLayout(False)
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpLineas.ResumeLayout(False)
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub MeFiltroPrice_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If bError Then
            e.Cancel = True
        End If
    End Sub

    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If Me.cmbSucursalO.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        End If

        If CTEClave = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        End If


        If ChkListSuc.CheckedItems.Count = 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(2))
            reloj.Enabled = True
            reloj.Start()
        End If

        If ChkToda.Checked = False AndAlso ChkListSuc.CheckedItems.Count = 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(3))
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

    Private Sub BtnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOK.Click
        If validaForm() Then


            Dim i As Integer

            If ChkToda.Checked Then
                Linea = ""
            Else
                For i = 0 To Me.ChkListLineas.CheckedItems.Count - 1
                    If i = 0 Then
                        Linea &= CStr(dtlineas.Rows(ChkListLineas.CheckedIndices(i)).ItemArray(0))
                    Else
                        Linea &= "," & CStr(dtlineas.Rows(ChkListLineas.CheckedIndices(i)).ItemArray(0))
                    End If
                Next
            End If

            bError = False


            For i = 0 To Me.ChkListSuc.CheckedItems.Count - 1
                insertaListas(dtPrecios.Rows(ChkListSuc.CheckedIndices(i)).ItemArray(0), dtPrecios.Rows(ChkListSuc.CheckedIndices(i)).ItemArray(1))
            Next

            Dim frmStatusMessage As New frmStatus
            frmStatusMessage.Show("Exportando...")
            Cursor.Current = Cursors.WaitCursor
            fncExcelExport(dtListas)
            frmStatusMessage.Close()
            Cursor.Current = Cursors.Default
            Me.Close()
        Else
            bError = True
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        End If
    End Sub

    Private Function fncExcelExport(ByVal dtListas As DataTable) As Boolean
        Dim dsExcelExport As New System.Data.DataSet
        Dim daExcelExport As System.Data.SqlClient.SqlDataAdapter
        Dim Excel As New Microsoft.Office.Interop.Excel.Application()
        Dim intColumn, intRow, intColumnValue As Integer
        Dim strExcelFile As String
        Dim strAppPath As String
        Dim conCurrent As New SqlClient.SqlConnection
        Dim strSql As String

        Dim sCondicion As String = ""
        Dim i As Integer
        For i = 0 To dtListas.Rows.Count - 1
            sCondicion = sCondicion & ", dbo.obtenerPrecioNeto('" & CStr(cmbSucursalO.SelectedValue) & "','" & dtListas.Rows(i)("PREClave") & "','" & CTEClave & "',p.PROClave)"
        Next

        If Linea = "" Then
            strSql = "select p.Clave,p.Nombre" & sCondicion & " from Producto as p where  p.COMClave='" & ModPOS.CompanyActual & "' and p.Baja=0 order by p.Clave"
        Else
            strSql = "select p.Clave,p.Nombre" & sCondicion & " from Producto as p, ClasProd as cp where p.COMClave='" & ModPOS.CompanyActual & "' and p.Baja=0 and p.PROClave=cp.PROClave and cp.CLAClave in (" & Linea & ") order by p.Clave"
        End If


        conCurrent.ConnectionString = ModPOS.BDConexion

        daExcelExport = New System.Data.SqlClient.SqlDataAdapter(strSql, conCurrent)

        daExcelExport.Fill(dsExcelExport)

        'strAppPath = System.Reflection.Assembly.GetExecutingAssembly.Location.Substring(0, System.Reflection.Assembly.GetExecutingAssembly.Location.LastIndexOf("\") + 1)


        With Excel
            .SheetsInNewWorkbook = 1
            .Workbooks.Add()
            .Worksheets(1).Select()
            'For displaying the column name in the the excel file.
            For intColumn = 0 To dsExcelExport.Tables(0).Columns.Count - 1
                .Cells(1, intColumn + 1).Value = dsExcelExport.Tables(0).Columns(intColumn).ColumnName.ToString
            Next

            'For displaying the column value row-by-row in the the excel file.
            .Cells(1, 1).Value = "CLAVE"
            .Cells(1, 2).Value = "NOMBRE"

            For i = 0 To dtListas.Rows.Count - 1
                .Cells(1, i + 3).Value = dtListas.Rows(i)("Lista")
            Next


            Dim intFila As Integer = 1
            For intRow = 0 To dsExcelExport.Tables(0).Rows.Count - 1
                For intColumnValue = 0 To dsExcelExport.Tables(0).Columns.Count - 1
                    If intColumnValue < 2 Then
                        .Cells(intFila + 1, intColumnValue + 1).Value = "'" & dsExcelExport.Tables(0).Rows(intRow).ItemArray(intColumnValue).ToString
                    Else
                        .Cells(intFila + 1, intColumnValue + 1).Value = dsExcelExport.Tables(0).Rows(intRow).ItemArray(intColumnValue).ToString
                    End If
                Next
                intFila += 1
            Next


          
            'strFileName = InputBox("Please enter the file name.", "Swapnil")

            Do
                Dim a As New System.Windows.Forms.FolderBrowserDialog
                If (a.ShowDialog() = DialogResult.OK) Then
                    If a.SelectedPath.Length <= 3 Then
                        strAppPath = a.SelectedPath
                    Else
                        strAppPath = a.SelectedPath & "\"
                    End If

                Else
                    strAppPath = ""
                    MessageBox.Show("No ha seleccionado una ruta validad", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Loop While strAppPath = ""

            strExcelFile = strAppPath & "Precios"
            Try
                .ActiveWorkbook().SaveAs(strExcelFile)
                .ActiveWorkbook.Close()
            Catch
            End Try
        End With
        MessageBox.Show("Archivo exportado satisfactoriamente.", "Exportación realizada", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Excel.Quit()
        Excel = Nothing
        GC.Collect()
        Exit Function
    End Function


    Private Sub FrmExportaPrice_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Me.StartPosition = FormStartPosition.CenterScreen

        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2
        alerta(2) = Me.PictureBox3
        alerta(3) = Me.PictureBox4

        dtlineas = ModPOS.Recupera_Tabla("sp_muestra_lineas")
        If dtLineas.Rows.Count > 0 Then
            Me.ChkListLineas.DataSource = dtLineas
            Me.ChkListLineas.DisplayMember = dtLineas.Columns(1).ColumnName
            Me.ChkListLineas.ValueMember = dtLineas.Columns(0).ColumnName
            Me.ChkToda.Enabled = True
        Else
            ChkToda.Enabled = False
            GrpLineas.Visible = False
        End If

        dtPrecios = ModPOS.Recupera_Tabla("sp_filtra_lista", "@COMClave", ModPOS.CompanyActual)

        If dtPrecios.Rows.Count > 0 Then
            Me.ChkListSuc.DataSource = dtPrecios
            Me.ChkListSuc.DisplayMember = dtPrecios.Columns(1).ColumnName
            Me.ChkListSuc.ValueMember = dtPrecios.Columns(0).ColumnName
            ChkMarcaTodos.Enabled = True
        Else
            MsgBox("No se encontró ningún elemento.", MsgBoxStyle.Information, "Información")
        End If

        With cmbSucursalO
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_sucursal"
            .NombreParametro1 = "USRClave"
            .Parametro1 = ModPOS.UsuarioActual
            .NombreParametro2 = "COMClave"
            .Parametro2 = ModPOS.CompanyActual
            .llenar()
        End With

        Me.Text = Titulo

        dtListas = ModPOS.CrearTabla("Listas", _
                                     "PREClave", "System.String", _
                                     "Lista", "System.String")

    End Sub


    Private Function insertaListas( _
              ByVal PREClave As String, _
              ByVal Lista As String) As Boolean

        Dim foundRows() As System.Data.DataRow
        foundRows = dtListas.Select(" PREClave Like '" & PREClave & "'")
        If foundRows.Length = 0 Then
            Dim row1 As DataRow
            row1 = dtListas.NewRow()
            row1.Item("PREClave") = PREClave
            row1.Item("Lista") = Lista
            dtListas.Rows.Add(row1)
            Return True
        Else
            Return False
        End If
    End Function


    Private Sub ChkToda_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkToda.CheckedChanged
        Dim i As Integer
        If ChkToda.Checked Then
            For i = 0 To ChkListLineas.Items.Count - 1
                ChkListLineas.SetItemCheckState(i, CheckState.Checked)
            Next
        Else
            For i = 0 To ChkListLineas.Items.Count - 1
                ChkListLineas.SetItemCheckState(i, CheckState.Unchecked)
            Next
        End If
    End Sub


    Private Sub ChkMarcaTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkMarcaTodos.CheckedChanged
        Dim i As Integer
        If ChkMarcaTodos.Checked Then
            For i = 0 To ChkListSuc.Items.Count - 1
                ChkListSuc.SetItemCheckState(i, CheckState.Checked)
            Next
        Else
            For i = 0 To ChkListSuc.Items.Count - 1
                ChkListSuc.SetItemCheckState(i, CheckState.Unchecked)
            Next
        End If
    End Sub

    Private Sub btnBuscaCte_Click(sender As Object, e As EventArgs) Handles btnBuscaCte.Click
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
                TxtCliente.Text = a.Descripcion
                LblCliente.Text = a.Descripcion2
            End If
        End If
        a.Dispose()
    End Sub
End Class
