Public Class FrmContar

    Public CONClave As String
    Public Tipo As Integer
    Public ALMClave As String
    Public SUCClave As String

    Private TallaColor As Integer = 0
    Private USRClave As String = ""
    Private UbcLoad As Boolean = False
    Private sUBCClave As String
    Private Ubicacion As String
    Private dtConteo As DataTable
    Private Clave As String
    Private Nombre As String
    Private PROClave As String
    Private Cantidad As Double
    Private NumDecimales As Integer
    Private dtTemporal, dtConteoTemp, dtUbicacion As DataTable

    Private Sub FrmContar_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.Contar.Dispose()
        ModPOS.Contar = Nothing
    End Sub

    Private Sub FrmContar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim dt As DataTable
        dt = ModPOS.Recupera_Tabla("sp_recupera_comparam", "@PARClave", "TallaColor", "@COMClave", ModPOS.CompanyActual)
        If dt.Rows.Count > 0 Then
            TallaColor = IIf(dt.Rows(0)("Valor").GetType.Name = "DBNull", 0, dt.Rows(0)("Valor"))
        End If
        dt.Dispose()

        recuperaConteoConfig("")

     

     
    End Sub

  
    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub GridUbicaciones_CurrentCellChanged(sender As Object, e As EventArgs) Handles GridUbicaciones.CurrentCellChanged
      
        GridUbicaciones.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
      
    End Sub

    Private Sub GridUbicaciones_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridUbicaciones.DoubleClick
        If Not Me.GridUbicaciones.GetValue(0) Is Nothing Then
            recuperaUbicacion(Me.GridUbicaciones.GetValue("UBCClave"))
        End If
    End Sub

   

    Private Sub GridUbicaciones_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridUbicaciones.SelectionChanged
        If UbcLoad = True AndAlso Not Me.GridUbicaciones.GetValue(0) Is Nothing Then
            sUBCClave = Me.GridUbicaciones.GetValue("UBCClave")

            Ubicacion = GridUbicaciones.GetValue("Ubicación")

            TxtUbicacion.Text = Ubicacion
        Else
            sUBCClave = ""
            Ubicacion = ""
            TxtUbicacion.Text = ""
        End If

        ActualizaDetalle(sUBCClave)
    End Sub

    Private Sub ActualizaDetalle(ByVal sUBCClave As String)
        If Not dtConteo Is Nothing Then
            dtConteo.Dispose()
        End If

        dtConteo = ModPOS.Recupera_Tabla("sp_muestra_conteo_det", "@CONClave", CONClave, "@Tipo", Tipo, "@UBCClave", sUBCClave)

        If Not dtConteo Is Nothing Then
            GridConteo.DataSource = dtConteo
            GridConteo.RetrieveStructure()
            GridConteo.AutoSizeColumns()
            GridConteo.RootTable.Columns("CNDClave").Visible = False
            GridConteo.RootTable.Columns("Actual").Visible = False
            GridConteo.RootTable.Columns("Nuevo").Visible = False
            GridConteo.RootTable.Columns("PROClave").Visible = False

            GridConteo.RootTable.Columns("Contado").Width = 20
            GridConteo.RootTable.Columns("Clave").Width = 70
            GridConteo.RootTable.Columns("Nombre").Width = 180
            GridConteo.RootTable.Columns("Fisica").Width = 30

        End If

        LblUbicacion.Text = Ubicacion
        lblPorc.Text = "0 %"
        PBar.Value = 0
    End Sub

    Private Sub TxtClaveProd_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtClaveProd.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Not TxtClaveProd.Text = vbNullString Then
                recuperaProducto(TxtClaveProd.Text.Trim.ToUpper)
            End If
        End If
    End Sub

    Private Sub recuperaUbicacion(ByVal sClave As String)

        Dim foundRows() As DataRow
        foundRows = dtUbicacion.Select(" Ubicacion = '" & sClave & "'")
        If foundRows.Length > 0 Then
            Ubicacion = sClave
            sUBCClave = foundRows(0)("UBCClave")

            TxtClaveProd.Focus()
            LblUbicacion.Text = sClave
        Else
            sUBCClave = ""
            LblUbicacion.Text = ""
            MessageBox.Show("¡La Clave de Ubicación no existe o no esta asignada al conteo del usuario actual!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            LblUbicacion.Text = ""
        End If

        ActualizaDetalle(sUBCClave)
       
    End Sub

    Private Sub recuperaProducto(ByVal sClave As String)
        Dim dtProducto As DataTable = ModPOS.SiExisteRecupera("sp_compra_producto", "@COMClave", ModPOS.CompanyActual, "@Clave", sClave.Replace("'", "''"), "@Char", cReplace, "@TallaColor", TallaColor)
        If Not dtProducto Is Nothing Then

            If Tipo = 2 Then
                Dim foundRows() As DataRow
                Dim cuantos As Integer = 0
                If Not dtConteo Is Nothing Then
                    foundRows = dtConteo.Select(" PROClave = '" & dtProducto.Rows(0)("PROClave") & "'")
                    cuantos = foundRows.Length
                End If

                If cuantos = 0 Then

                    MessageBox.Show("¡La Clave de producto no se encuentra entre los productos a contar!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Clave = ""
                    PROClave = ""
                    Nombre = ""
                    Cantidad = 0
                    NumDecimales = 0
                    TxtClaveProd.Text = Clave
                    TxtDescripcion.Text = Nombre
                    TxtCantidad.DecimalDigits = NumDecimales

                    Exit Sub
                End If
            End If

            PROClave = dtProducto.Rows(0)("PROClave")
            Clave = dtProducto.Rows(0)("Clave")
            Nombre = dtProducto.Rows(0)("Nombre")
            NumDecimales = dtProducto.Rows(0)("Num_Decimales")

            dtProducto.Dispose()
            Me.TxtDescripcion.Text = Nombre
            TxtCantidad.DecimalDigits = NumDecimales
            TxtCantidad.Focus()

        Else
            Clave = ""
            PROClave = ""
            Nombre = ""
            Cantidad = 0
            NumDecimales = 0
            TxtClaveProd.Text = Clave
            TxtDescripcion.Text = Nombre
            TxtCantidad.DecimalDigits = NumDecimales

            MessageBox.Show("¡La Clave de producto no existe!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub TxtCantidad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCantidad.KeyDown
        If e.KeyCode = Keys.Enter Then
            Cantidad = CDbl(TxtCantidad.Text)
            If System.String.IsNullOrEmpty(sUBCClave) Then
                Beep()
                MessageBox.Show("¡La Clave de Ubicación es requerida!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                If System.String.IsNullOrEmpty(PROClave) Then
                    Beep()
                    MessageBox.Show("¡La Clave de producto es requerida!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    Dim foundRows() As System.Data.DataRow
                    foundRows = dtConteo.Select("PROClave Like '" & PROClave & "'")

                    If foundRows.Length = 0 Then
                        If Cantidad >= 0 Then
                            Dim row1 As DataRow
                            row1 = dtConteo.NewRow()
                            'declara el nombre de la fila

                            row1.Item("CNDClave") = ModPOS.obtenerLlave
                            row1.Item("PROClave") = PROClave
                            row1.Item("Contado") = 1
                            row1.Item("Fisica") = Cantidad
                            row1.Item("Clave") = Clave
                            row1.Item("Nombre") = Nombre
                            row1.Item("Actual") = 0
                            row1.Item("Nuevo") = 1
                            dtConteo.Rows.Add(row1)
                            'agrega la fila completo a la tabla

                          
                            TxtClaveProd.Text = ""
                            TxtDescripcion.Text = ""
                            TxtCantidad.Text = 0
                            PROClave = ""
                            Cantidad = 0
                            Clave = ""
                            Nombre = ""
                            TxtClaveProd.Focus()
                        Else
                            MessageBox.Show("¡La Cantidad de producto no puede ser menor a cero!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        End If
                    Else 'actualiza
                        foundRows(0)("Fisica") = Cantidad
                        foundRows(0)("Contado") = 1

                        TxtClaveProd.Text = ""
                        TxtDescripcion.Text = ""
                        TxtCantidad.Text = 0
                        PROClave = ""
                        Cantidad = 0
                        Clave = ""
                        Nombre = ""
                        TxtClaveProd.Focus()
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub BtnBuscaProd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBuscaProd.Click
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
            TxtDescripcion.Text = a.Descripcion
            recuperaProducto(a.valor)
            TxtCantidad.Focus()
        End If
        a.Dispose()
    End Sub

    Private Sub TxtUbicacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtUbicacion.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Not TxtUbicacion.Text = vbNullString Then
                recuperaUbicacion(TxtUbicacion.Text.Trim.ToUpper)
            End If
        End If
    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If Not dtConteo Is Nothing Then
            Dim foundRows() As DataRow

            'Insertar
            foundRows = dtConteo.Select("Contado = 1 and Nuevo = 1")
            Cursor.Current = Cursors.WaitCursor
            If foundRows.GetLength(0) > 0 Then
                Dim i As Integer
                PBar.Maximum = foundRows.GetLength(0)
                For i = 0 To foundRows.GetUpperBound(0)

                    ModPOS.Ejecuta("sp_ins_conteodet", _
                                   "@CNDClave", foundRows(i)("CNDClave"), _
                                   "@CONClave", CONClave, _
                                   "@UBCClave", sUBCClave, _
                                   "@PROClave", foundRows(i)("PROClave"), _
                                   "@Cantidad", foundRows(i)("Fisica"), _
                                   "@Usuario", ModPOS.UsuarioActual)
                    PBar.Value = i + 1
                    lblPorc.Text = CStr(Redondear(((i + 1) * 100) / PBar.Maximum, 2)) & "%"
                Next

            End If

            'Actualizar
            foundRows = dtConteo.Select("Contado = 1 and Actual <> Fisica and Nuevo = 0")
            Cursor.Current = Cursors.WaitCursor
            If foundRows.GetLength(0) > 0 Then
                Dim i As Integer
                PBar.Maximum = foundRows.GetLength(0)
                For i = 0 To foundRows.GetUpperBound(0)

                    ModPOS.Ejecuta("sp_act_conteodet", _
                                   "@CONClave", CONClave, _
                                   "@UBCClave", sUBCClave, _
                                   "@PROClave", foundRows(i)("PROClave"), _
                                   "@Cantidad", foundRows(i)("Fisica"), _
                                   "@Usuario", ModPOS.UsuarioActual)
                    PBar.Value = i + 1
                    lblPorc.Text = CStr(Redondear(((i + 1) * 100) / PBar.Maximum, 2)) & "%"
                Next
            End If
            
            Cursor.Current = Cursors.Default
        End If

    End Sub

    Private Sub GridConteo_CellEdited(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridConteo.CellEdited
        If GridConteo.CurrentColumn.Caption = "Cantidad" Then
            If IsNumeric(GridConteo.GetValue("Cantidad")) Then
                If GridConteo.GetValue("Cantidad") < 0 Then
                    Dim Actual As Double
                    Actual = Math.Abs(CDbl(GridConteo.GetValue("Cantidad")))
                    GridConteo.SetValue(7, Actual)
                End If
            Else
                GridConteo.SetValue("Cantidad", 0)
            End If
        End If

    End Sub

    Private Sub GridConteo_CellValueChanged(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridConteo.CellValueChanged
        PBar.Value = 0
        lblPorc.Text = "0 %"
    End Sub

    Private Sub guardarConteoExcel(ByVal UBCClave As String, ByVal PROClave As String, ByVal Cantidad As Double)
        Dim dtContDet As DataTable

        dtContDet = ModPOS.Recupera_Tabla("sp_existe_conteo_detalle", "@CONClave", CONClave, "@UBCClave", UBCClave, "@PROClave", PROClave)

        If Not dtContDet Is Nothing Then

            If dtContDet.Rows.Count = 0 Then
                '   Inserta
                ModPOS.Ejecuta("sp_ins_conteodet", "@CONClave", CONClave, "@UBCClave", UBCClave, "@PROClave", PROClave, "@Cantidad", Cantidad, "@Usuario", ModPOS.UsuarioActual)
            ElseIf dtContDet.Rows.Count > 0 Then
                '   Actualiza
                ModPOS.Ejecuta("sp_act_conteodet", "@CONClave", CONClave, "@UBCClave", UBCClave, "@PROClave", PROClave, "@Cantidad", Cantidad, "@Usuario", ModPOS.UsuarioActual)
            End If
        End If

    End Sub

    Private Sub guardarconteo()
        If Not dtConteoTemp Is Nothing Then

            Dim foundRows() As DataRow
            foundRows = dtConteoTemp.Select("")

            If foundRows.GetLength(0) > 0 Then
                Dim i As Integer
                Dim dtContDet As DataTable

                For i = 0 To foundRows.GetUpperBound(0)

                    dtContDet = ModPOS.Recupera_Tabla("sp_existe_conteo_detalle", "@CONClave", CONClave, "@UBCClave", foundRows(i)("UBCClave"), "@PROClave", foundRows(i)("PROClave"))

                    If Not dtContDet Is Nothing Then

                        If dtContDet.Rows.Count = 0 Then
                            '   Inserta
                            ModPOS.Ejecuta("sp_ins_conteodet", "@CONClave", CONClave, "@UBCClave", foundRows(i)("UBCClave"), "@PROClave", foundRows(i)("PROClave"), "@Cantidad", foundRows(i)("Cantidad"), "@Usuario", ModPOS.UsuarioActual)
                        ElseIf dtContDet.Rows.Count > 0 Then
                            '   Actualiza
                            ModPOS.Ejecuta("sp_act_conteodet", "@CONClave", CONClave, "@UBCClave", foundRows(i)("UBCClave"), "@PROClave", foundRows(i)("PROClave"), "@Cantidad", foundRows(i)("Cantidad"), "@Usuario", ModPOS.UsuarioActual)
                        End If
                    End If
                Next
            End If

        End If

        MessageBox.Show("El Conteo ha sido procesado exitosamente ", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub BtnFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFile.Click
        Dim Valido As Boolean = False
        Dim ubicacion As String
        Dim gtin As String
        Dim cantidad As String

        Dim result As OpenFileDialog = New OpenFileDialog
        result.Filter = "Todos los archivos de CSV|*.CSV"
        result.Title = "Importar archivo CSV"

        If (result.ShowDialog() = DialogResult.OK) Then

            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            Dim FullPath As String = result.FileName

            If FullPath.ToUpper().Contains(".CSV") Then

                dtTemporal = ReadCSV(FullPath, 3)

                If Not dtConteoTemp Is Nothing Then
                    dtConteoTemp.Dispose()
                End If

                dtConteoTemp = ModPOS.CrearTabla("ConteoDetalle", _
                                                  "PROClave", "System.String", _
                                                  "UBCClave", "System.String", _
                                                  "Cantidad", "System.Double")

                Dim i As Integer

                Dim dtProducto, dtUbicacion As DataTable

                Dim frmStatusMessage As New frmStatus
                frmStatusMessage.Show("Procesando Archivo...")

                PBar.Maximum = dtTemporal.Rows.Count

                For i = 0 To dtTemporal.Rows.Count - 1
                    Valido = False
                    'Valida si existen datos para comparar
                    ubicacion = dtTemporal.Rows(i)(0).ToString.Trim
                    gtin = dtTemporal.Rows(i)(1).ToString.Trim
                    cantidad = dtTemporal.Rows(i)(2).ToString.Trim
                    If Not dtTemporal.Rows(i)(1).GetType.FullName = "System.DBNull" AndAlso Not dtTemporal.Rows(i)(0).GetType.FullName = "System.DBNull" Then
                        'Verifica que exista la ubicación
                        dtUbicacion = ModPOS.Recupera_Tabla("sp_exist_ubc", "@ALMClave", ALMClave, "@UBCClave", dtTemporal.Rows(i)(0).ToString.Trim)
                        If Not dtUbicacion Is Nothing AndAlso dtUbicacion.Rows.Count = 1 Then
                            dtTemporal.Rows(i)(0) = dtUbicacion.Rows(0)("UBCClave")
                            'Verifica que exista el producto
                            dtProducto = ModPOS.Recupera_Tabla("sp_recupera_prod_gtin", "@UBCClave", dtTemporal.Rows(i)(0).ToString.Trim, "@GTIN", dtTemporal.Rows(i)(1).ToString.Trim)
                            If Not dtProducto Is Nothing AndAlso dtProducto.Rows.Count = 1 Then
                                'Verifica que la cantidad sea numerica
                                If IsNumeric(dtTemporal.Rows(i)(2)) Then
                                    'Verifica que el producto no se encuentre repetido en el mismo archivo en la misma ubicación
                                    Valido = True
                                    Dim foundRows() As System.Data.DataRow
                                    foundRows = dtConteoTemp.Select("PROClave = '" & dtProducto.Rows(0)("PROClave") & "' and UBCClave ='" & dtUbicacion.Rows(0)("UBCClave") & "'")

                                    If foundRows.Length = 0 Then

                                        Dim row1 As DataRow
                                        row1 = dtConteoTemp.NewRow()
                                        'declara el nombre de la fila
                                        row1.Item("PROClave") = dtProducto.Rows(0)("PROClave")
                                        row1.Item("UBCClave") = dtUbicacion.Rows(0)("UBCClave")

                                        row1.Item("Cantidad") = CDbl(dtTemporal.Rows(i)(2))
                                        dtConteoTemp.Rows.Add(row1)
                                    Else
                                        foundRows(0)("Cantidad") = CDbl(dtTemporal.Rows(i)(2))
                                    End If
                                    If TallaColor = 1 Then
                                        guardarConteoExcel(dtUbicacion.Rows(0)("UBCClave"), dtProducto.Rows(0)("PROClave"), CDbl(dtTemporal.Rows(i)(2)))
                                    End If
                                End If
                            End If
                        End If
                    End If

                    PBar.Value = i + 1
                    lblPorc.Text = CStr(Redondear(((i + 1) * 100) / PBar.Maximum, 2)) & "%"
                    lblPorc.Refresh()

                    If Valido = False AndAlso TallaColor = 1 Then

                        Dim El_Archivo As String

                        Dim DirActual As System.IO.DirectoryInfo = New System.IO.DirectoryInfo(Application.ExecutablePath).Parent
                        Dim dir As String = DirActual.FullName()
                        Dim escritor As IO.StreamWriter
                        pathActual = dir & "\"
                        If Not IO.Directory.Exists(dir & "\Diferencias") Then
                            IO.Directory.CreateDirectory(dir & "\Diferencias")
                        End If

                        El_Archivo = dir & "\Diferencias\" + result.SafeFileName.ToString
                        escritor = IO.File.AppendText(El_Archivo)
                        escritor.WriteLine(ubicacion + "," + gtin + "," + cantidad + ",POS:" + i.ToString)
                        escritor.Flush()
                        escritor.Close()

                    End If
                Next

                If TallaColor = 0 Then
                    guardarconteo()
                Else
                    MessageBox.Show("El Conteo ha sido procesado exitosamente ", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

                frmStatusMessage.Close()

                Cursor.Current = Cursors.Default

                Me.Close()

            End If

        End If
    End Sub

    Private Sub recuperaConteoConfig(ByVal USRClave As String)

        If Not GridUbicaciones Is Nothing AndAlso Not dtUbicacion Is Nothing Then
            dtUbicacion.Dispose()
        End If

        dtUbicacion = ModPOS.Recupera_Tabla("sp_conteo_ubicacion", "@CONClave", CONClave, "@USRClave", USRClave)
        UbcLoad = False

        GridUbicaciones.DataSource = dtUbicacion
        GridUbicaciones.RetrieveStructure()
        GridUbicaciones.AutoSizeColumns()
        GridUbicaciones.RootTable.Columns("ASGClave").Visible = False

        GridUbicaciones.RootTable.Columns("UBCClave").Visible = False

        Dim conteoValido = False
        If Not Me.GridUbicaciones.GetValue(0) Is Nothing Then
            sUBCClave = Me.GridUbicaciones.GetValue("UBCClave")

            Ubicacion = GridUbicaciones.GetValue("Ubicación")

            TxtUbicacion.Text = Ubicacion
            conteoValido = True
        Else
            sUBCClave = ""
            Ubicacion = ""
            TxtUbicacion.Text = ""
            If USRClave <> "" Then
                MessageBox.Show("El usuario no cuenta con ubicaciones asignadas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If

        ActualizaDetalle(sUBCClave)

        UbcLoad = True

        TxtUbicacion.Enabled = conteoValido
        TxtCantidad.Enabled = conteoValido
        BtnBuscaProd.Enabled = conteoValido
        TxtClaveProd.Enabled = conteoValido


    End Sub


    Private Sub btnBuscaUsr_Click(sender As Object, e As EventArgs) Handles btnBuscaUsr.Click
        Dim a As New MeSearch
        a.ProcedimientoAlmacenado = "sp_search_usuario"
        a.TablaCmb = "Usuario"
        a.CampoCmb = "Filtro"
        a.OcultaID = True
        a.CompaniaRequerido = False
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            If Not a.valor Is Nothing Then
                USRClave = a.valor
                LblUsuario.Text = a.Descripcion
                recuperaConteoConfig(USRClave)
            End If
        End If

    End Sub

    Private Sub TxtUsuario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtUsuario.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Not TxtUsuario.Text = vbNullString Then
                Dim dt As DataTable = ModPOS.SiExisteRecupera("sp_search_usuario", "@Campo", 1, "@Busqueda", TxtUsuario.Text.Replace("'", "''"))
                If Not dt Is Nothing Then
                    USRClave = dt.Rows(0)("ID")
                    LblUsuario.Text = dt.Rows(0)("Nombre")
                    dt.Dispose()
                    recuperaConteoConfig(USRClave)
                Else
                    USRClave = ""
                    LblUsuario.Text = ""
                    MessageBox.Show("¡La Clave de usuario no existe!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
            End If
        End If
    End Sub

    Private Sub GridConteo_CurrentCellChanged(sender As Object, e As EventArgs) Handles GridConteo.CurrentCellChanged
        If Not GridConteo.CurrentColumn Is Nothing Then
            If GridConteo.CurrentColumn.Caption = "Contado" OrElse GridConteo.CurrentColumn.Caption = "Fisica" Then
                GridConteo.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
            Else
                GridConteo.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
            End If
        End If
    End Sub
End Class