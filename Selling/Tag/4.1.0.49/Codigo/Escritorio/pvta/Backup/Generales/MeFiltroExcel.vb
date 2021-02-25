Imports Microsoft.Office.Interop
Public Class MeFiltroExcel
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


            Dim noViajeActual As String
            Dim FechaActual As Date
            Dim TotalReporte As String = ""

            '' Creamos un objeto WorkBook

            Dim objLibroExcel As Excel.Workbook


            '' Creamos un objeto WorkSheet

            Dim objHojaExcel As Excel.Worksheet

            '' Llenamos el DataSet con la consulta de sql server

            Dim objDataSet As DataSet

            objDataSet = ModPOS.recuperaTabla_DTS("sp_xls_viaje", "Viajes", "@Inicial", CDate(FechaIni), "@Final", CDate(FechaFin), "@COMClave", ModPOS.CompanyActual)

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



            '' Hacemos esta hoja la visible en pantalla
            '' (como seleccionamos la primera esto no es necesario
            '' si seleccionamos una diferente a la primera si lo
            '' necesitaríamos, esto lo hacemos como forma de mostrar como
            '' cambiar de entre hojas en un documento Excel).

            objHojaExcel.Activate()


            '' Crear el encabezado de nuestro informe

            objHojaExcel.Range("A1:G1").Merge()
            objHojaExcel.Range("A1:G1").Value = ModPOS.CompanyName
            objHojaExcel.Range("A1:G1").Font.Bold = True
            objHojaExcel.Range("A1:G1").Font.Size = 15

            '' Crear el subencabezado de nuestro informe
            objHojaExcel.Range("A2:G2").Merge()
            objHojaExcel.Range("A2:G2").Value = "DETALLADO DE VIAJES DEL " & cmbFechaInicio.Value.ToString("dd/MM/yyyy") & " AL " & CmbFechaFin.Value.ToString("dd/MM/yyyy")
            objHojaExcel.Range("A2:G2").Font.Italic = True
            objHojaExcel.Range("A2:G2").Font.Size = 13


            ''Creamos los encabezados de las columans
            Dim objCelda As Excel.Range = objHojaExcel.Range("A3", Type.Missing)
            objCelda.Value = "NO.VIAJE"
            objCelda = objHojaExcel.Range("B3", Type.Missing)
            objCelda.Value = "F.VIAJE"
            objCelda = objHojaExcel.Range("C3", Type.Missing)
            objCelda.Value = "TRACTOR"
            objCelda = objHojaExcel.Range("D3", Type.Missing)
            objCelda.Value = "T.PLACAS"
            objCelda = objHojaExcel.Range("E3", Type.Missing)
            objCelda.Value = "T.PROPIETARIO"
            objCelda = objHojaExcel.Range("F3", Type.Missing)
            objCelda.Value = "OPERADOR"
            objCelda = objHojaExcel.Range("G3", Type.Missing)
            objCelda.Value = "CLIENTE"
            objCelda = objHojaExcel.Range("H3", Type.Missing)
            objCelda.Value = "FACTURA"
            objCelda = objHojaExcel.Range("I3", Type.Missing)
            objCelda.Value = "F.FACTURA"
            objCelda = objHojaExcel.Range("J3", Type.Missing)
            objCelda.Value = "F.VENCIMIENTO"
            objCelda = objHojaExcel.Range("K3", Type.Missing)
            objCelda.Value = "F.COBRANZA"
            objCelda = objHojaExcel.Range("L3", Type.Missing)
            objCelda.Value = "F.PAGO"


            'Viaje Detalle
            objCelda = objHojaExcel.Range("M3", Type.Missing)
            objCelda.Value = "EMBARQUE"

            objCelda = objHojaExcel.Range("N3", Type.Missing)
            objCelda.Value = "NO.CARGA"

            objCelda = objHojaExcel.Range("O3", Type.Missing)
            objCelda.Value = "REMOLQUE"
            objCelda = objHojaExcel.Range("P3", Type.Missing)
            objCelda.Value = "R.PLACAS"
            objCelda = objHojaExcel.Range("Q3", Type.Missing)
            objCelda.Value = "R.PROPIETARIO"
            objCelda = objHojaExcel.Range("R3", Type.Missing)
            objCelda.Value = "TIPO"
            objCelda = objHojaExcel.Range("S3", Type.Missing)
            objCelda.Value = "ORIGEN"
            objCelda = objHojaExcel.Range("T3", Type.Missing)
            objCelda.Value = "DESTINO"
            objCelda = objHojaExcel.Range("U3", Type.Missing)
            objCelda.Value = "DESTINATARIO"
            objCelda = objHojaExcel.Range("V3", Type.Missing)
            objCelda.Value = "CARGA"
            objCelda = objHojaExcel.Range("W3", Type.Missing)
            objCelda.Value = "DESCARGA"
            objCelda = objHojaExcel.Range("X3", Type.Missing)
            objCelda.Value = "F.PAPELES"
            objCelda = objHojaExcel.Range("Y3", Type.Missing)
            objCelda.Value = "OBSERVACIONES"
            objCelda = objHojaExcel.Range("Z3", Type.Missing)
            objCelda.Value = "FLETE"
            objCelda.EntireColumn.NumberFormat = "###,###,###.00"


            '' Inicializamos los registros del reporte
            Dim i As Integer = 4
            Dim j As Integer = 4

            noViajeActual = ""
            FechaActual = #1/1/2000#
            Dim IniciaColumna, FinalColumna As Integer


            ''recorremos el DTS

            For Each objRow As DataRow In objDataSet.Tables(0).Rows


                ' Si se repite e
                ' es diferente a la categorías a imprimir, imprimir los totales

                If noViajeActual <> objRow.Item(0) OrElse FechaActual <> objRow.Item(1) Then
                    'Si no es la primer fila, insertamos el total del flete

                    If i > 4 Then

                        If TotalReporte <> "" Then
                            TotalReporte &= ","
                        End If
                        TotalReporte &= "Z" & CStr(i)

                        objHojaExcel.Cells(i, "Y") = "Total Viaje"
                        objHojaExcel.Cells(i, "Z") = "=sum(Z" & (IniciaColumna).ToString & ":Z" & (FinalColumna).ToString & ")"
                        objHojaExcel.Range("Y" & i.ToString & ":Z" & i.ToString).Font.Bold = True
                        j = i
                        i += 1
                    End If

                    IniciaColumna = i
                    objHojaExcel.Cells(i, "A") = objRow.Item(0) 'NO. VIAJE
                    objHojaExcel.Cells(i, "B") = objRow.Item(1) 'FECHA VIAJE
                    objHojaExcel.Cells(i, "C") = objRow.Item(2) 'TRACTOR
                    objHojaExcel.Cells(i, "D") = objRow.Item(3) 'PLACAS
                    objHojaExcel.Cells(i, "E") = objRow.Item(4) 'PROPIETARIO
                    objHojaExcel.Cells(i, "F") = objRow.Item(5) 'OPERADOR
                    objHojaExcel.Cells(i, "G") = objRow.Item(6) 'CLIENTE
                    objHojaExcel.Cells(i, "H") = objRow.Item(7) 'FACTURA
                    objHojaExcel.Cells(i, "I") = objRow.Item(8) 'F.FACTURA
                    objHojaExcel.Cells(i, "J") = objRow.Item(9) 'F.VENCIMIENTO
                    objHojaExcel.Cells(i, "K") = objRow.Item(10) 'F.COBRANZA
                    objHojaExcel.Cells(i, "L") = objRow.Item(11) 'F.PAGO

                End If

                FinalColumna = i

                '' Asignar la Remision
                FechaActual = objRow.Item(1)
                noViajeActual = objRow.Item(0)

                '' Asignar los valores de los registros a las celdas

                objHojaExcel.Cells(i, "M") = objRow.Item(12) 'EMBARQUE
                objHojaExcel.Cells(i, "N") = objRow.Item(13) 'NO.CARGA
                objHojaExcel.Cells(i, "O") = objRow.Item(14) 'REMOLQUE
                objHojaExcel.Cells(i, "P") = objRow.Item(15) 'PLACAS
                objHojaExcel.Cells(i, "Q") = objRow.Item(16) 'PROPIETARIO
                objHojaExcel.Cells(i, "R") = objRow.Item(17) 'TIPO
                objHojaExcel.Cells(i, "S") = objRow.Item(18) 'ORIGEN
                objHojaExcel.Cells(i, "T") = objRow.Item(19) 'DESTINO
                objHojaExcel.Cells(i, "U") = objRow.Item(20) 'DESTINATARIO

                objHojaExcel.Cells(i, "V") = objRow.Item(21) 'LLEGADA
        
                objHojaExcel.Cells(i, "W") = objRow.Item(22) 'LLEGADA
        
                objHojaExcel.Cells(i, "X") = objRow.Item(23) 'F. PAPELES

                objHojaExcel.Cells(i, "Y") = objRow.Item(24) 'OBSERVACIONES
                objHojaExcel.Cells(i, "Z") = objRow.Item(25) 'FLETE

                '' Avanzamos una fila


                i += 1

            Next

            FinalColumna = i - 1

            If TotalReporte <> "" Then
                TotalReporte &= ","
            End If
            TotalReporte &= "Z" & CStr(i)

            objHojaExcel.Cells(i, "Y") = "Total Viaje"
            objHojaExcel.Cells(i, "Z") = "=sum(Z" & (IniciaColumna).ToString & ":Z" & (FinalColumna).ToString & ")"
            objHojaExcel.Range("Y" & i.ToString & ":Z" & i.ToString).Font.Bold = True


            objHojaExcel.Cells(i + 1, "Y") = "Total Reporte"
            objHojaExcel.Cells(i + 1, "Z") = "=sum(" & TotalReporte & ")"
            objHojaExcel.Range("Y" & CStr(i + 1) & ":Z" & CStr(i + 1)).Font.Bold = True

            '' Seleccionar todo el bloque desde A1 hasta D #de filas
            '            Dim objRango As Excel.Range = objHojaExcel.Range(String.Format("A3", "Y" & CStr(i), i - 1))
            Dim objRango As Excel.Range = objHojaExcel.Range("A3:Z" & (i + 1).ToString)

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
