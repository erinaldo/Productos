Imports System.Data.SqlClient

Public Class FrmAjustarExist
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
    Friend WithEvents BtnAgregar As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtNota As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BtnBuscaUbicacion As Janus.Windows.EditControls.UIButton
    Friend WithEvents GridDetalle As Janus.Windows.GridEX.GridEX
    Friend WithEvents btnImportar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnAdd As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtUbicacion As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAjustarExist))
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton()
        Me.TxtNota = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BtnBuscaUbicacion = New Janus.Windows.EditControls.UIButton()
        Me.TxtUbicacion = New System.Windows.Forms.TextBox()
        Me.GridDetalle = New Janus.Windows.GridEX.GridEX()
        Me.btnImportar = New Janus.Windows.EditControls.UIButton()
        Me.BtnAdd = New Janus.Windows.EditControls.UIButton()
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.BtnCancelar.Icon = CType(resources.GetObject("BtnCancelar.Icon"), System.Drawing.Icon)
        Me.BtnCancelar.Location = New System.Drawing.Point(587, 521)
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
        Me.BtnAgregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.BtnAgregar.Icon = CType(resources.GetObject("BtnAgregar.Icon"), System.Drawing.Icon)
        Me.BtnAgregar.Location = New System.Drawing.Point(686, 521)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(90, 37)
        Me.BtnAgregar.TabIndex = 1
        Me.BtnAgregar.Text = "&Aceptar"
        Me.BtnAgregar.ToolTipText = "Guardar cambios"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtNota
        '
        Me.TxtNota.Location = New System.Drawing.Point(88, 45)
        Me.TxtNota.Name = "TxtNota"
        Me.TxtNota.Size = New System.Drawing.Size(418, 20)
        Me.TxtNota.TabIndex = 14
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(10, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 15)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Motivo: "
        '
        'Label3
        '
        Me.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label3.Location = New System.Drawing.Point(10, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 18)
        Me.Label3.TabIndex = 108
        Me.Label3.Text = "Ubicación"
        '
        'BtnBuscaUbicacion
        '
        Me.BtnBuscaUbicacion.Image = CType(resources.GetObject("BtnBuscaUbicacion.Image"), System.Drawing.Image)
        Me.BtnBuscaUbicacion.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnBuscaUbicacion.Location = New System.Drawing.Point(321, 8)
        Me.BtnBuscaUbicacion.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnBuscaUbicacion.Name = "BtnBuscaUbicacion"
        Me.BtnBuscaUbicacion.Size = New System.Drawing.Size(31, 30)
        Me.BtnBuscaUbicacion.TabIndex = 106
        Me.BtnBuscaUbicacion.ToolTipText = "Busqueda de Ubicación"
        Me.BtnBuscaUbicacion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtUbicacion
        '
        Me.TxtUbicacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtUbicacion.Location = New System.Drawing.Point(88, 13)
        Me.TxtUbicacion.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtUbicacion.Name = "TxtUbicacion"
        Me.TxtUbicacion.Size = New System.Drawing.Size(227, 21)
        Me.TxtUbicacion.TabIndex = 105
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
        Me.GridDetalle.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridDetalle.GroupByBoxVisible = False
        Me.GridDetalle.Location = New System.Drawing.Point(12, 88)
        Me.GridDetalle.Name = "GridDetalle"
        Me.GridDetalle.RecordNavigator = True
        Me.GridDetalle.Size = New System.Drawing.Size(760, 427)
        Me.GridDetalle.TabIndex = 109
        Me.GridDetalle.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'btnImportar
        '
        Me.btnImportar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnImportar.Enabled = False
        Me.btnImportar.Image = Global.Selling.My.Resources.Resources._1451374105_icon_57_document_download
        Me.btnImportar.ImageSize = New System.Drawing.Size(24, 24)
        Me.btnImportar.Location = New System.Drawing.Point(709, 52)
        Me.btnImportar.Name = "btnImportar"
        Me.btnImportar.Size = New System.Drawing.Size(63, 30)
        Me.btnImportar.TabIndex = 159
        Me.btnImportar.ToolTipText = "Importar ajuste"
        Me.btnImportar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnAdd
        '
        Me.BtnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAdd.Enabled = False
        Me.BtnAdd.Icon = CType(resources.GetObject("BtnAdd.Icon"), System.Drawing.Icon)
        Me.BtnAdd.Location = New System.Drawing.Point(640, 52)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(63, 30)
        Me.BtnAdd.TabIndex = 160
        Me.BtnAdd.ToolTipText = "Agrega producto a la ubicación actual"
        Me.BtnAdd.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmAjustarExist
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.BtnAdd)
        Me.Controls.Add(Me.btnImportar)
        Me.Controls.Add(Me.GridDetalle)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.BtnBuscaUbicacion)
        Me.Controls.Add(Me.TxtUbicacion)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtNota)
        Me.Controls.Add(Me.BtnAgregar)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmAjustarExist"
        Me.Text = "Ajuste de Existencia"
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private ExistActual As Double
    Private ExistNueva As Double
    Public ALMClave As String
    Public PROClave As String
    Public Nombre As String
    Public UBCClave As String = ""
    Public Clave As String
    Public Ubicacion As String
    Private SUCClave, InterfazSalida As String
    Private dtAjuste As DataTable


    Private Sub FrmAjustarExist_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
       
    
       
        Dim dt As DataTable
        dt = ModPOS.Recupera_Tabla("sp_recupera_alm", "@ALMClave", ALMClave)
        SUCClave = IIf(dt.Rows(0)("SUCClave").GetType.Name = "DBNull", "", dt.Rows(0)("SUCClave"))
        dt.Dispose()

        If UBCClave <> "" Then
            TxtUbicacion.Text = Ubicacion
            recuperaExistencia(SUCClave, UBCClave)
        End If


        Dim dtParam As DataTable
        Dim i As Integer

        dtParam = ModPOS.Recupera_Tabla("sp_recupera_parametro", "@COMClave", ModPOS.CompanyActual)
        With Me
            For i = 0 To dtParam.Rows.Count - 1
                Select Case CStr(dtParam.Rows(i)("PARClave"))
                    Case "InterfazSalida"
                        InterfazSalida = IIf(dtParam.Rows(i)("Valor").GetType.Name = "DBNull", "", dtParam.Rows(i)("Valor"))
                        Exit Select
                End Select
            Next
        End With
        dtParam.Dispose()

    End Sub

    Private Sub AjustarExist_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.AjustarExist.Dispose()
        ModPOS.AjustarExist = Nothing
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub


    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        If UBCClave = "" Then
            MessageBox.Show("la ubicación es requerida", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        ElseIf TxtNota.Text = "" Then
            MessageBox.Show("Es requerida la descripción del motivo del ajuste", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        ElseIf TxtNota.Text.Length > 50 Then
            MessageBox.Show("La descripción del motivo de ajuste sobrepasa el maximo de caracters permitidos (50)", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim foundRows() As Data.DataRow
        foundRows = dtAjuste.Select("Fisica > 0 or Marca=True")
        Dim i As Integer

        Dim dt As DataTable = ModPOS.CrearTabla("Ajustar", _
                                              "PROClave", "System.String", _
                                              "Cantidad", "System.Double", _
                                              "Costo", "System.Decimal")

        If foundRows.Length > 0 Then
            For i = 0 To foundRows.Length - 1
                Dim CantAjuste As Double = 0
                CantAjuste = foundRows(i)("Fisica") - foundRows(i)("Teorica")

                If CantAjuste <> 0 Then
                    If foundRows(i)("Fisica") >= (foundRows(i)("Apartado") + foundRows(i)("Bloqueado")) Then
                        Dim row1 As DataRow
                        row1 = dt.NewRow()
                        'declara el nombre de la fila
                        row1.Item("PROClave") = foundRows(i)("ID").ToString
                        row1.Item("Cantidad") = CantAjuste
                        row1.Item("Costo") = foundRows(i)("Costo") * CantAjuste
                        dt.Rows.Add(row1)
                    Else
                        MessageBox.Show("El producto " & foundRows(i)("Clave") & ", No puede ser ajustado ya que sobrepasa la cantidad de Apartado y Bloqueado", "Información", MessageBoxButtons.OK)
                        Exit Sub
                    End If
                End If
            Next

            If dt.Rows.Count > 0 Then
                Dim a As New MeAutorizacion
                a.Sucursal = SUCClave
                a.MontodeAutorizacion = dt.Compute("SUM(Costo)", "")
                a.ShowDialog()
                If a.DialogResult = DialogResult.OK Then
                    If a.Autorizado Then
                        Dim Referencia As String = ModPOS.obtenerLlave

                        For i = 0 To dt.Rows.Count - 1
                            ModPOS.Ejecuta("sp_ajusta_exist_ubc", _
                                            "@ALMClave", ALMClave, _
                                            "@Diferencia", dt.Rows(i)("Cantidad"), _
                                            "@UBCClave", UBCClave, _
                                            "@PROClave", dt.Rows(i)("PROClave"), _
                                            "@Nota", TxtNota.Text.ToUpper.Trim.Replace("'", ""), _
                                            "@Usuario", ModPOS.UsuarioActual)


                            ModPOS.Ejecuta("st_ajuste", _
                                                              "@SUCClave", SUCClave, _
                                                              "@ALMClave", ALMClave, _
                                                              "@UBCClave", UBCClave, _
                                                              "@PROClave", dt.Rows(i)("PROClave"), _
                                                              "@Cantidad", dt.Rows(i)("Cantidad"), _
                                                              "@TipoMov", IIf(dt.Rows(i)("Cantidad") < 0, 2, 1), _
                                                              "@Referencia", Referencia, _
                                                              "@Nota", TxtNota.Text.ToUpper.Trim.Replace("'", ""), _
                                                              "@Usuario", ModPOS.UsuarioActual)



                        Next

                        If InterfazSalida <> "" Then
                            Dim dtInterfaz As DataTable
                            Dim sFecha As String

                            sFecha = DateTime.Now.ToString("yyyyMMdd_HHmmssfff")

                            dtInterfaz = Recupera_Tabla("st_recupera_interfaz", "@Interfaz", "Ajuste", "@COMClave", ModPOS.CompanyActual)
                            If dtInterfaz.Rows.Count > 0 Then
                                ModPOS.Ejecuta(CStr(dtInterfaz.Rows(0)("sp")), "@Folio", Referencia, "@TipoDocumento", 0, "@Path", InterfazSalida, "@Fecha", sFecha)
                            End If
                        End If

                        MessageBox.Show("Productos Ajustados Correctamente ", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        ModPOS.MtoExistencia.recuperaExistencia(2, "")
                        Me.Close()

                    End If
                End If
            Else
                MessageBox.Show("No se encontraron diferencias para realizar ajuste", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If
        Else
            MessageBox.Show("Debe Marcar los registros que desee ajustar con Existencia Cero o introducir una cantidad mayor a cero en la columna de existencia Fisica", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub recuperaExistencia(ByVal sSUCClave As String, ByVal sUBCClave As String)

        If Not dtAjuste Is Nothing Then
            dtAjuste.Dispose()
        End If

        dtAjuste = Recupera_Tabla("st_prd_exist_uba", "@SUCClave", sSUCClave, "@UBCClave", sUBCClave)

        GridDetalle.DataSource = dtAjuste
        GridDetalle.RetrieveStructure()
        ' GridDetalle.AutoSizeColumns()
        GridDetalle.RootTable.Columns("ID").Visible = False
        GridDetalle.RootTable.Columns("Nuevo").Visible = False
        GridDetalle.RootTable.Columns("Costo").Visible = False

        GridDetalle.RootTable.Columns("Teorica").FormatString = "0.00"
        GridDetalle.RootTable.Columns("Fisica").FormatString = "0.00"

        GridDetalle.RootTable.Columns("Apartado").FormatString = "0.00"
        GridDetalle.RootTable.Columns("Bloqueado").FormatString = "0.00"

        BtnAdd.Enabled = True
        btnImportar.Enabled = True
    End Sub

    Private Sub BtnBuscaUbicacion_Click(sender As Object, e As EventArgs) Handles BtnBuscaUbicacion.Click
        Dim a As New MeSearch

        a.ProcedimientoAlmacenado = "sp_search_ubicacion"
        a.TablaCmb = "Reubicacion"
        a.CampoCmb = "Filtro"
        a.AlmRequerido = True
        a.ALMClave = ALMClave
        a.OcultaCol = True
        a.OcultaColNum = 0
        a.NumColDes = 1
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            TxtUbicacion.Text = a.Descripcion
            UBCClave = a.valor
            recuperaExistencia(SUCClave, UBCClave)
        End If

        a.Dispose()
    End Sub

    Private Sub TxtUbicacion_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtUbicacion.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TxtUbicacion.Text <> "" Then
                Dim dt As DataTable
                dt = ModPOS.Recupera_Tabla("sp_valida_ubicacion", "@ALMClave", ALMClave, "@Ubicacion", TxtUbicacion.Text.ToUpper.Trim)

                If dt.Rows.Count > 0 Then
                    UBCClave = dt.Rows(0)("UBCClave")
                    recuperaExistencia(SUCClave, UBCClave)
                Else
                    UBCClave = ""
                    BtnAdd.Enabled = False
                    btnImportar.Enabled = False
                    MessageBox.Show("La clave de ubicación no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
                dt.Dispose()
             End If
        ElseIf e.KeyCode = Keys.Right Then
            BtnBuscaUbicacion.PerformClick()
        End If
    End Sub

    Private Sub actprd(ByVal sPROClave As String, ByVal sClave As String, ByVal sDesc As String, ByVal dCantidad As Double)
        Dim foundRows() As Data.DataRow
        foundRows = dtAjuste.Select("ID = '" & sPROClave & "'")

        If foundRows.Length = 0 Then

            Dim dMonto As Double

            Dim dt As DataTable
            dt = ModPOS.Recupera_Tabla("sp_recupera_costo", "@SUCClave", SUCClave, "@PROClave", PROClave)
            dMonto = dt.Rows(0)("Costo")
            dt.Dispose()

            Dim row1 As DataRow
            row1 = dtAjuste.NewRow()
            'declara el nombre de la fila
            row1.Item("ID") = sPROClave
            row1.Item("Marca") = False
            row1.Item("Clave") = sClave
            row1.Item("Nombre") = sDesc
            row1.Item("Teorica") = 0
            row1.Item("Fisica") = dCantidad
            row1.Item("Apartado") = 0
            row1.Item("Bloqueado") = 0
            row1.Item("Costo") = dMonto
            row1.Item("Nuevo") = 1
            dtAjuste.Rows.Add(row1)
        Else
            foundRows(0)("Fisica") = dCantidad
        End If

    End Sub

    Private Sub btnImportar_Click(sender As Object, e As EventArgs) Handles btnImportar.Click
        If UBCClave <> "" Then
            Dim curFileName As String = ""
            'buscamos la imagen a grabar
            Try
                Dim openDlg As OpenFileDialog = New OpenFileDialog
                openDlg.Filter = "Todos los archivos de CSV|*.CSV|Todos los archivos TXT|*.TXT"
                ' Dim filter As String = openDlg.Filter
                openDlg.Title = "Abrir un Archivo de CSV o TXT"
                If (openDlg.ShowDialog() = DialogResult.OK) Then
                    curFileName = openDlg.FileName

                    Dim dtTemporal As DataTable = ReadCSV(curFileName, 2)

                    If dtTemporal.Rows.Count > 0 Then


                        Dim frmStatusMessage As New frmStatus
                        frmStatusMessage.BringToFront()

                        Dim i As Integer
                        Dim PROClave, sClave, sDescripcion As String
                        Dim Cantidad As Double

                        Dim dtError As DataTable = ModPOS.CrearTabla("Error", _
                                                  "Fila", "System.String", _
                                                  "Producto", "System.String", _
                                                  "Cantidad", "System.String", _
                                                  "Error", "System.String")

                        Dim dt As DataTable


                        For i = 0 To dtTemporal.Rows.Count - 1
                            frmStatusMessage.Show("Procesando " & CStr(i + 1) & " de " & CStr(dtTemporal.Rows.Count) & " registros")
                            ' valida el producto
                            If dtTemporal.Rows(i)("GTIN").GetType.FullName <> "System.DBNull" Then
                                dt = Recupera_Tabla("sp_compra_producto", "@COMClave", ModPOS.CompanyActual, "@Clave", dtTemporal.Rows(i)("GTIN").ToString.Replace("'", "''").Trim, "@Char", cReplace)
                                If dt.Rows.Count > 0 Then
                                    PROClave = dt.Rows(0)("PROClave")
                                    sClave = dt.Rows(0)("Clave")
                                    sDescripcion = dt.Rows(0)("Nombre")
                                    dt.Dispose()
                                    ' valida la capacidad gra
                                    If dtTemporal.Rows(i)("Cantidad").GetType.FullName <> "System.DBNull" Then
                                        If IsNumeric(dtTemporal.Rows(i)("Cantidad")) AndAlso CDbl(dtTemporal.Rows(i)("Cantidad")) >= 0 Then
                                            Cantidad = CDbl(dtTemporal.Rows(i)("Cantidad"))
                                            'Agregar funcion
                                            actprd(PROClave, sClave, sDescripcion, Cantidad)
                                        Else
                                            Dim row1 As DataRow
                                            row1 = dtError.NewRow()
                                            'declara el nombre de la fila
                                            row1.Item("Fila") = i + 1
                                            row1.Item("Producto") = dtTemporal.Rows(i)("GTIN").ToString
                                            row1.Item("Cantidad") = dtTemporal.Rows(i)("Cantidad")
                                            row1.Item("Error") = "El registro actual no cuenta con una existencia valida"
                                            dtError.Rows.Add(row1)
                                        End If
                                    Else
                                        Dim row1 As DataRow
                                        row1 = dtError.NewRow()
                                        'declara el nombre de la fila
                                        row1.Item("Fila") = i + 1
                                        row1.Item("Producto") = dtTemporal.Rows(i)("GTIN").ToString
                                        row1.Item("Cantidad") = dtTemporal.Rows(i)("Cantidad")
                                        row1.Item("Error") = "La capacidad de almacenaje se encuentra vacia"
                                        dtError.Rows.Add(row1)
                                    End If
                                Else
                                    dt.Dispose()
                                    Dim row1 As DataRow
                                    row1 = dtError.NewRow()
                                    'declara el nombre de la fila
                                    row1.Item("Fila") = i + 1
                                    row1.Item("Producto") = dtTemporal.Rows(i)("GTIN").ToString
                                    row1.Item("Cantidad") = dtTemporal.Rows(i)("Cantidad")
                                    row1.Item("Error") = "La clave de producto no existe"
                                    dtError.Rows.Add(row1)
                                End If
                            Else
                                Dim row1 As DataRow
                                row1 = dtError.NewRow()
                                'declara el nombre de la fila
                                row1.Item("Fila") = i + 1
                                row1.Item("Producto") = dtTemporal.Rows(i)("GTIN").ToString
                                row1.Item("Cantidad") = dtTemporal.Rows(i)("Cantidad")
                                row1.Item("Error") = "La clave de producto se encuentra vacia"
                                dtError.Rows.Add(row1)
                            End If
                        Next

                        If dtError.Rows.Count > 0 Then
                            MessageBox.Show("Se encontraron " & CStr(dtError.Rows.Count) & "Errores, al procesar el archivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                            Dim b As New FrmConsultaGen
                            b.Text = "Errores"
                            b.GridConsultaGen.DataSource = dtError
                            b.GridConsultaGen.RetrieveStructure(True)
                            b.GridConsultaGen.GroupByBoxVisible = False
                            b.ShowDialog()
                            b.Dispose()
                            dtError.Dispose()
                        Else
                            MessageBox.Show("El archivo se proceso sin errores", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        End If

                        frmStatusMessage.Close()
                        Cursor.Current = Cursors.Default
                    Else
                        MessageBox.Show("El archivo no cuenta con el formato: Producto,Existencia o se encuentra vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        Else
            MessageBox.Show("Debe seleccionar la ubicación a la cual desea importar la existencia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End If
    End Sub

    Private Sub GridDetalle_CellEdited(sender As Object, e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridDetalle.CellEdited
        If GridDetalle.CurrentColumn.Caption = "Fisica" Then
            If IsNumeric(GridDetalle.GetValue("Fisica")) Then

                Select Case CDbl(GridDetalle.GetValue("Fisica"))
                    Case Is < 0
                        GridDetalle.SetValue("Fisica", 0)
                End Select

            Else
                GridDetalle.SetValue("Fisica", 0)
            End If
        End If
     
    End Sub

    Private Sub GridDetalle_CurrentCellChanged(sender As Object, e As EventArgs) Handles GridDetalle.CurrentCellChanged
        If Not GridDetalle.CurrentColumn Is Nothing Then
            If GridDetalle.CurrentColumn.Caption = "Marca" OrElse GridDetalle.CurrentColumn.Caption = "Fisica" Then
                GridDetalle.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
            Else
                GridDetalle.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
            End If
        End If
    End Sub

    Private Function recuperaProducto(ByVal Clave As String) As String
        If Not Clave = vbNullString Then
            Dim dt As DataTable = ModPOS.Recupera_Tabla("sp_ingreso_producto", "@GTIN", Clave)
            If Not dt Is Nothing Then
                If dt.Rows.Count > 0 Then

                    Clave = dt.Rows(0)("PROClave")
                End If
                dt.Dispose()
            End If
        End If
        Return Clave
    End Function


    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click

        Dim a As New MeSearch
        a.ProcedimientoAlmacenado = "sp_search_prod"
        a.bReplace = True
        a.TablaCmb = "Producto"
        a.CampoCmb = "Filtro"
        a.NumColDes = 0
        a.NumColDes2 = 2
        a.CompaniaRequerido = True
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then


            PROClave = recuperaProducto(a.valor)

            Dim foundRows() As Data.DataRow
            foundRows = dtAjuste.Select("ID = '" & PROClave & "'")

            If foundRows.Length = 0 Then


                Dim dMonto As Double

                Dim dt As DataTable
                dt = ModPOS.Recupera_Tabla("sp_recupera_costo", "@SUCClave", SUCClave, "@PROClave", PROClave)
                dMonto = dt.Rows(0)("Costo")
                dt.Dispose()

                Dim row1 As DataRow
                row1 = dtAjuste.NewRow()
                'declara el nombre de la fila
                row1.Item("ID") = PROClave
                row1.Item("Marca") = True
                row1.Item("Clave") = a.valor
                row1.Item("Nombre") = a.Descripcion
                row1.Item("Teorica") = 0
                row1.Item("Fisica") = 1
                row1.Item("Apartado") = 0
                row1.Item("Bloqueado") = 0
                row1.Item("Costo") = dMonto
                row1.Item("Nuevo") = 1
                dtAjuste.Rows.Add(row1)
            Else
                MessageBox.Show("El producto ya existe en la ubicación actual", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
        a.Dispose()

    End Sub
End Class
