Imports Microsoft.Office.Interop
Public Class MeFiltroCostoExcel
    Inherits System.Windows.Forms.Form

    Private FechaIni As String
    Private FechaFin As String
    Private bError As Boolean = False

    Private alerta(1) As PictureBox

    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents CmbFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbFechaInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label

    Private reloj As parpadea

    Private m_Excel As Excel.Application
    Public ReadOnly Property FechaInicio() As String
        Get
            FechaInicio = FechaIni
        End Get
    End Property

    Public ReadOnly Property FechaFinal() As String
        Get
            FechaFinal = FechaFin
        End Get
    End Property

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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnOK As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnCancel As Janus.Windows.EditControls.UIButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MeFiltroExcel))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.PictureBox4 = New System.Windows.Forms.PictureBox
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.CmbFechaFin = New System.Windows.Forms.DateTimePicker
        Me.cmbFechaInicio = New System.Windows.Forms.DateTimePicker
        Me.BtnOK = New Janus.Windows.EditControls.UIButton
        Me.BtnCancel = New Janus.Windows.EditControls.UIButton
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.PictureBox4)
        Me.GroupBox1.Controls.Add(Me.PictureBox3)
        Me.GroupBox1.Controls.Add(Me.CmbFechaFin)
        Me.GroupBox1.Controls.Add(Me.cmbFechaInicio)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(362, 45)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Rango"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label2.Location = New System.Drawing.Point(173, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(20, 13)
        Me.Label2.TabIndex = 72
        Me.Label2.Text = "AL"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label1.Location = New System.Drawing.Point(8, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 13)
        Me.Label1.TabIndex = 71
        Me.Label1.Text = "DEL"
        '
        'PictureBox4
        '
        Me.PictureBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(325, 19)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(14, 14)
        Me.PictureBox4.TabIndex = 70
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(161, 19)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(13, 14)
        Me.PictureBox3.TabIndex = 68
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'CmbFechaFin
        '
        Me.CmbFechaFin.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbFechaFin.CustomFormat = "yyyyMMdd"
        Me.CmbFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.CmbFechaFin.Location = New System.Drawing.Point(201, 15)
        Me.CmbFechaFin.MinDate = New Date(1990, 1, 1, 0, 0, 0, 0)
        Me.CmbFechaFin.Name = "CmbFechaFin"
        Me.CmbFechaFin.Size = New System.Drawing.Size(119, 20)
        Me.CmbFechaFin.TabIndex = 69
        Me.CmbFechaFin.Value = New Date(2000, 2, 2, 0, 0, 0, 0)
        '
        'cmbFechaInicio
        '
        Me.cmbFechaInicio.CustomFormat = "yyyyMMdd"
        Me.cmbFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.cmbFechaInicio.Location = New System.Drawing.Point(46, 15)
        Me.cmbFechaInicio.MinDate = New Date(1990, 1, 1, 0, 0, 0, 0)
        Me.cmbFechaInicio.Name = "cmbFechaInicio"
        Me.cmbFechaInicio.Size = New System.Drawing.Size(125, 20)
        Me.cmbFechaInicio.TabIndex = 68
        Me.cmbFechaInicio.Value = New Date(2000, 2, 2, 0, 0, 0, 0)
        '
        'BtnOK
        '
        Me.BtnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BtnOK.Image = CType(resources.GetObject("BtnOK.Image"), System.Drawing.Image)
        Me.BtnOK.Location = New System.Drawing.Point(274, 57)
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
        Me.BtnCancel.Location = New System.Drawing.Point(178, 57)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancel.TabIndex = 4
        Me.BtnCancel.Text = "&Salir"
        Me.BtnCancel.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancel.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'MeFiltroExcel
        '
        Me.AcceptButton = Me.BtnOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(369, 99)
        Me.Controls.Add(Me.BtnOK)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(385, 157)
        Me.MinimizeBox = False
        Me.Name = "MeFiltroExcel"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub MeFiltro_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If bError Then
            e.Cancel = True
        End If

        'If Not m_Excel Is Nothing Then
        '    m_Excel.Quit()
        '    m_Excel = Nothing
        'End If
    End Sub

    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If cmbFechaInicio.Value > CmbFechaFin.Value Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
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
            FechaIni = CStr(cmbFechaInicio.Value)
            FechaFin = CStr(CmbFechaFin.Value.AddHours(23.9999))
            bError = False


           
            Dim TotalReporte As String = ""

            '' Creamos un objeto WorkBook

            Dim objLibroExcel As Excel.Workbook


            '' Creamos un objeto WorkSheet

            Dim objHojaExcel As Excel.Worksheet

            '' Llenamos el DataSet con la consulta de sql server

            Dim objDataSet As DataSet
            Dim sConsulta As String
            Dim sNombreImpuesto As String = ""
            Dim j As Integer
            Dim dt As DataTable = ModPOS.Recupera_Tabla("sp_muestra_impuestos", "@COMClave", ModPOS.CompanyActual)

            If dt.Rows.Count > 0 Then
                sNombreImpuesto &= "[" & CStr(dt.Rows(0)("Referencia")) & "]"
                If dt.Rows.Count > 1 Then
                    For j = 1 To dt.Rows.Count - 1
                        sNombreImpuesto &= ",[" & CStr(dt.Rows(j)("Referencia")) & "]"
                    Next
                End If
            End If
            dt.Dispose()

            sConsulta =
            "select * from (" & _
            "select v.Descripcion,f.fechaFactura,f.Serie+cast(f.Folio as varchar) as Folio,f.CostoTot ,i.Nombre,fd.Costo * fd.Cantidad as Imp from factura f" & _
            " inner join facturadetalle fd  on f.FACClave=fd.FACClave" & _
            " inner join FacturaImpuesto fi on fd.DFAClave=fi.DFAClave" & _
            " inner join Impuesto i on i.IMPClave=fi.IMPClave" & _
            " inner join ValorRef v on v.Tabla='Factura' and v.Campo='Estado' and v.Valor=f.Estado" & _
            " where f.fechaFactura between   '" & CDate(FechaIni).ToString("yyyyMMdd HH:mm:ss:fff") & "' and '" & CDate(FechaFin).ToString("yyyyMMdd HH:mm:ss:fff") & "' ) pvt PIVOT (" & _
            " sum(Imp) FOR Nombre IN (" & sNombreImpuesto & ") ) AS PivotTable;"

            objDataSet = ModPOS.recuperaConsulta_DTS(sConsulta, "Costos")

            '' Iniciamos una instancia a Excel

            m_Excel = New Excel.Application

            m_Excel.Visible = True

            '' Creamos una variable para guardar la cultura actual

            Dim OldCultureInfo As System.Globalization.CultureInfo = _
            System.Threading.Thread.CurrentThread.CurrentCulture


            'Crear una cultura standard (en-US) inglés estados unidos

            System.Threading.Thread.CurrentThread.CurrentCulture = _
            New System.Globalization.CultureInfo("en-US")

            objLibroExcel = m_Excel.Workbooks.Add()
            objHojaExcel = objLibroExcel.Worksheets(1)

            objHojaExcel.Visible = Excel.XlSheetVisibility.xlSheetVisible

            objHojaExcel.Activate()


            '' Crear el encabezado de nuestro informe

            objHojaExcel.Range("A1:G1").Merge()
            objHojaExcel.Range("A1:G1").Value = ModPOS.CompanyName
            objHojaExcel.Range("A1:G1").Font.Bold = True
            objHojaExcel.Range("A1:G1").Font.Size = 15

            '' Crear el subencabezado de nuestro informe
            objHojaExcel.Range("A2:G2").Merge()
            objHojaExcel.Range("A2:G2").Value = "ANALITICA DE COSTOS DEL " & cmbFechaInicio.Value.ToString("dd/MM/yyyy") & " AL " & CmbFechaFin.Value.ToString("dd/MM/yyyy")
            objHojaExcel.Range("A2:G2").Font.Italic = True
            objHojaExcel.Range("A2:G2").Font.Size = 13


            ''Creamos los encabezados de las columans
            Dim objCelda As Excel.Range = objHojaExcel.Range("A3", Type.Missing)
            objCelda.Value = "ESTADO"
            objCelda = objHojaExcel.Range("B3", Type.Missing)
            objCelda.Value = "FECHA"
            objCelda = objHojaExcel.Range("C3", Type.Missing)
            objCelda.Value = "FOLIO"
            objCelda = objHojaExcel.Range("D3", Type.Missing)
            objCelda.Value = "COSTO TOTAL"
            objCelda.EntireColumn.NumberFormat = "###,###,###.00"
         

            Dim i, fila As Integer
            Dim NumColumnas As Integer

            NumColumnas = objDataSet.Tables(0).Columns.Count
            Dim LetraColumna As Char

            For i = 4 To NumColumnas - 1
                LetraColumna = Chr(i + 65)
                objCelda = objHojaExcel.Range(LetraColumna & "3", Type.Missing)
                objCelda.Value = objDataSet.Tables(0).Columns.Item(i).ColumnName
                objCelda.EntireColumn.NumberFormat = "###,###,###.00"
            Next

            '' Inicializamos los registros del reporte

            fila = 4
            ''recorremos el DTS
            Dim l As Integer

            For Each objRow As DataRow In objDataSet.Tables(0).Rows
                For l = 0 To NumColumnas - 1
                    objHojaExcel.Cells(fila, CStr(Chr(l + 65))) = objRow.Item(objDataSet.Tables(0).Columns.Item(l).ColumnName)
                Next
                fila += 1
            Next

                '' Seleccionar todo el bloque desde A1 hasta D #de filas
                '            Dim objRango As Excel.Range = objHojaExcel.Range(String.Format("A3", "Y" & CStr(i), i - 1))
            Dim objRango As Excel.Range = objHojaExcel.Range("A3:" & LetraColumna & (fila + 1).ToString)

                '' Seleccionamos todo el rango especificado
                objRango.Select()

                '' Ajustamos el ancho de las columnas al ancho máximo del
                '' contenido de sus celdas
                objRango.Columns.AutoFit()

                '' Asignar filtro por columna
                objRango.AutoFilter(1, , VisibleDropDown:=True)
                '' Asignar un formato automático
                objRango.AutoFormat(11, Alignment:=False)
                '            objLibroExcel.PrintPreview()
        Else
                bError = True
                Beep()
                MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        End If
    End Sub


    Private Sub MeSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Me.StartPosition = FormStartPosition.CenterScreen

        alerta(0) = Me.PictureBox3
        alerta(1) = Me.PictureBox4
        Me.cmbFechaInicio.Value = Today
        Me.CmbFechaFin.Value = Today
    End Sub


End Class
