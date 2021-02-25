Public Class FrmReubicacion

    Private dtOrigen As DataTable
    Private dtDestino As DataTable
    Private UBCDestino As String

    Private Sub FrmReubicacion_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.Reubicacion.Dispose()
        ModPOS.Reubicacion = Nothing
    End Sub


    Private Sub FrmReubicacion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        With CmbOrigen
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_almacen"
            .NombreParametro1 = "USRClave"
            .Parametro1 = ModPOS.UsuarioActual
            .NombreParametro2 = "COMClave"
            .Parametro2 = ModPOS.CompanyActual
            .llenar()
        End With

        If ModPOS.AlmacenPredeterminado <> "" Then
            CmbOrigen.SelectedValue = ModPOS.AlmacenPredeterminado
        End If

        With CmbTipo
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Reubicacion"
            .NombreParametro2 = "campo"
            .Parametro2 = "Tipo"
            .llenar()
        End With

    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        Dim a As New MeSearch
        If CmbTipo.SelectedValue = 1 Then 'Ubicación
            If Not CmbOrigen.SelectedValue Is Nothing Then
                a.ProcedimientoAlmacenado = "sp_search_ubicacion"
                a.TablaCmb = "Reubicacion"
                a.CampoCmb = "Filtro"
                a.AlmRequerido = True
                a.ALMClave = CmbOrigen.SelectedValue
                a.NumColDes = 1
                a.OcultaCol = True
                a.OcultaColNum = 0
            Else
                MessageBox.Show("¡El Almacén no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If
        ElseIf CmbTipo.SelectedValue = 2 Then 'Producto
            a.ProcedimientoAlmacenado = "sp_search_prod"
            a.TablaCmb = "Producto"
            a.CampoCmb = "Filtro"
            a.CompaniaRequerido = True
            a.NumColDes = 2

        End If

        a.ShowDialog()

        If a.DialogResult = DialogResult.OK Then
            If (Not CmbOrigen.SelectedValue Is Nothing AndAlso Not CmbTipo.SelectedValue Is Nothing) Then
                If CmbTipo.SelectedValue = 1 Then
                    recuperar(CmbOrigen.SelectedValue, a.Descripcion, CmbTipo.SelectedValue)
                Else
                    recuperar(CmbOrigen.SelectedValue, a.valor, CmbTipo.SelectedValue)
                End If


            Else
                Beep()
                MessageBox.Show("¡Alguno de los datos introducidos (Almacén y/o Tipo) no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            End If
            a.Dispose()
    End Sub

    Private Sub ChkSinUbicar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkSinUbicar.CheckedChanged
        If ChkSinUbicar.Checked Then
            If CmbOrigen.SelectedValue Is Nothing Then
                MessageBox.Show("Debe seleccionar un almacén o sucursal origen", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ChkSinUbicar.Checked = False
            Else
                dtOrigen = ModPOS.Recupera_Tabla("sp_muestra_sin_ubicar", "@ALMClave", CmbOrigen.SelectedValue)

                GridOrigen.DataSource = dtOrigen
                GridOrigen.RetrieveStructure()
                GridOrigen.AutoSizeColumns()
                GridOrigen.RootTable.Columns("PROClave").Visible = False
                Me.GridOrigen.RootTable.Columns("Clave").Width = 70
                Me.GridOrigen.RootTable.Columns("Nombre").Width = 250
                Me.GridOrigen.RootTable.Columns("Disponible").Width = 20
                Me.GridOrigen.RootTable.Columns("Mover").Width = 20

                CmbTipo.Enabled = False
                TxtClave.Enabled = False
                BtnBuscar.Enabled = False
            End If
        Else
            CmbTipo.Enabled = True
            TxtClave.Enabled = True
            BtnBuscar.Enabled = True
            dtOrigen.Dispose()
        End If
    End Sub

    Private Sub GridOrigen_CellEdited(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridOrigen.CellEdited
        Select Case GridOrigen.CurrentColumn.Caption
            Case "Mover"
                If IsNumeric(GridOrigen.GetValue("Mover")) AndAlso CDbl(GridOrigen.GetValue("Mover")) > 0 Then
                    If GridOrigen.GetValue("Mover") > GridOrigen.GetValue("Disponible") Then
                        MessageBox.Show("La cantidad de producto a mover no puede ser mayor al disponible", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        GridOrigen.SetValue("Mover", 0)
                    End If
                Else
                    GridOrigen.SetValue("Mover", 0)
                End If
        End Select
    End Sub

    Private Sub recuperar(ByVal ALMClave As String, ByVal Texto As String, ByVal Tipo As Integer)

        If Tipo = 3 Then
            If Not dtDestino Is Nothing Then
                dtDestino.Dispose()
                UBCDestino = ""
            End If

            dtDestino = ModPOS.Recupera_Tabla("sp_muestra_ubicados", "@Tipo", Tipo, "@ALMClave", ALMClave, "@Clave", Texto.ToUpper.Trim.Replace("'", "''"))
            GridDestino.DataSource = dtDestino
            GridDestino.RetrieveStructure()
            GridDestino.AutoSizeColumns()
            GridDestino.RootTable.Columns("PROClave").Visible = False
            GridDestino.RootTable.Columns("UBCClave").Visible = False
            
            Me.GridDestino.RootTable.Columns("EST").Width = 40
            Me.GridDestino.RootTable.Columns("Ubicación").Width = 40
            Me.GridDestino.RootTable.Columns("Clave").Width = 70
            Me.GridDestino.RootTable.Columns("Nombre").Width = 250
            Me.GridDestino.RootTable.Columns("Existencia").Width = 20
            Me.GridDestino.RootTable.Columns("Apartado").Width = 20

        

        Else
            If Not dtOrigen Is Nothing Then
                dtOrigen.Dispose()
            End If

            dtOrigen = ModPOS.Recupera_Tabla("sp_muestra_ubicados", "@Tipo", Tipo, "@ALMClave", ALMClave, "@Clave", Texto.ToUpper.Trim.Replace("'", "''"))
            GridOrigen.DataSource = dtOrigen
            GridOrigen.RetrieveStructure()
            GridOrigen.AutoSizeColumns()
            GridOrigen.RootTable.Columns("PROClave").Visible = False
            GridOrigen.RootTable.Columns("UBCClave").Visible = False
            Me.GridOrigen.RootTable.Columns("EST").Width = 40
            Me.GridOrigen.RootTable.Columns("Ubicación").Width = 40
            Me.GridOrigen.RootTable.Columns("Clave").Width = 70
            Me.GridOrigen.RootTable.Columns("Nombre").Width = 250
            Me.GridOrigen.RootTable.Columns("Disponible").Width = 20
            Me.GridOrigen.RootTable.Columns("Mover").Width = 20

            If dtOrigen.Rows.Count = 0 AndAlso Tipo <> 3 Then
                If CmbTipo.SelectedValue = 1 Then
                    MessageBox.Show("No se encontro producto en la " & CmbTipo.Text & " con clave " & Texto.ToUpper.Trim, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("No se encontro algun " & CmbTipo.Text & " con clave " & Texto.ToUpper.Trim, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If

        End If
        

    End Sub


    Private Sub TxtClave_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtClave.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If (Not CmbOrigen.SelectedValue Is Nothing AndAlso Not CmbTipo.SelectedValue Is Nothing AndAlso Not TxtClave.Text = "") Then
                recuperar(CmbOrigen.SelectedValue, TxtClave.Text.Trim.ToUpper, CmbTipo.SelectedValue)
            Else
                Beep()
                MessageBox.Show("¡Alguno de los datos introducidos (Almacén y/o Tipo) no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        End If
    End Sub

    Private Sub TxtUbicacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtUbicacion.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If (Not CmbOrigen.SelectedValue Is Nothing AndAlso Not TxtUbicacion.Text = "") Then
                Dim dt As DataTable
                dt = ModPOS.Recupera_Tabla("sp_valida_ubicacion", "@ALMClave", CmbOrigen.SelectedValue, "@Ubicacion", TxtUbicacion.Text.ToUpper.Trim)

                If dt.Rows.Count > 0 Then
                    recuperar(CmbOrigen.SelectedValue, TxtUbicacion.Text.Trim.ToUpper, 3)
                    UBCDestino = dt.Rows(0)("UBCClave")
                Else
                    UBCDestino = ""
                    lblDestino.Text = ""
                    MessageBox.Show("La clave de ubicación no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
                dt.Dispose()
            Else
                Beep()
                MessageBox.Show("¡Alguno de los datos introducidos (Almacén y/o Tipo) no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
            End If
    End Sub

    Private Sub BtnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOK.Click
        If Not dtOrigen Is Nothing Then
            If Not dtDestino Is Nothing Then
                Dim foundRows() As DataRow
                foundRows = dtOrigen.Select("Mover > 0")
                If foundRows.Length > 0 Then
                    Dim i As Integer
                    If ChkSinUbicar.Checked Then
                        'Sin ubicar
                        For i = 0 To foundRows.GetUpperBound(0)
                            ModPOS.Ejecuta("sp_reubicar", "@Primera", 1, "@PROClave", foundRows(i)("PROClave"), "@UBCOrigen", "", "@UBCDestino", UBCDestino, "@Cantidad", foundRows(i)("Mover"), "@Usuario", ModPOS.UsuarioActual)
                            i += 1
                        Next
                    Else
                        For i = 0 To foundRows.GetUpperBound(0)
                            If foundRows(i)("UBCClave") <> UBCDestino Then
                                ModPOS.Ejecuta("sp_reubicar", "@Primera", 0, "@PROClave", foundRows(i)("PROClave"), "@UBCOrigen", foundRows(i)("UBCClave"), "@UBCDestino", UBCDestino, "@Cantidad", foundRows(i)("Mover"), "@Usuario", ModPOS.UsuarioActual)
                            End If
                            i += 1
                        Next
                    End If
                    If Me.ChkSinUbicar.Checked Then
                        dtOrigen = ModPOS.Recupera_Tabla("sp_muestra_sin_ubicar", "@ALMClave", CmbOrigen.SelectedValue)

                        GridOrigen.DataSource = dtOrigen
                        GridOrigen.RetrieveStructure()
                        GridOrigen.AutoSizeColumns()
                        GridOrigen.RootTable.Columns("PROClave").Visible = False

                        Me.GridOrigen.RootTable.Columns("Clave").Width = 70
                        Me.GridOrigen.RootTable.Columns("Nombre").Width = 250
                        Me.GridOrigen.RootTable.Columns("Disponible").Width = 20
                        Me.GridOrigen.RootTable.Columns("Mover").Width = 20
                    Else
                        recuperar(CmbOrigen.SelectedValue, TxtClave.Text.Trim.ToUpper, CmbTipo.SelectedValue)
                    End If

                    recuperar(CmbOrigen.SelectedValue, TxtUbicacion.Text.ToUpper.Trim, 3)

                Else
                    MessageBox.Show("Debe indicar la cantidad de producto a mover por lo menos de un registro", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                MessageBox.Show("Debe indicar la ubicación destino", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            Else
                MessageBox.Show("Debe indicar la ubicación origen del producto que desea mover", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
    End Sub

    Private Sub BtnBuscaUbicacion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBuscaUbicacion.Click
        Dim a As New MeSearch
        If Not CmbOrigen.SelectedValue Is Nothing Then
            a.ProcedimientoAlmacenado = "sp_search_ubicacion"
            a.TablaCmb = "Reubicacion"
            a.CampoCmb = "Filtro"
            a.AlmRequerido = True
            a.ALMClave = CmbOrigen.SelectedValue
            a.OcultaCol = True
            a.OcultaColNum = 0
        Else
            MessageBox.Show("¡El Almacén no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        a.NumColDes = 1
        a.ShowDialog()

        If a.DialogResult = DialogResult.OK Then
            If (Not CmbOrigen.SelectedValue Is Nothing AndAlso Not CmbTipo.SelectedValue Is Nothing) Then
                lblDestino.Text = a.Descripcion
                recuperar(CmbOrigen.SelectedValue, a.Descripcion, 3)
                UBCDestino = a.valor
            Else
                lblDestino.Text = ""
                Beep()
                MessageBox.Show("¡Alguno de los datos introducidos (Almacén y/o Tipo) no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If

        End If
        a.Dispose()

    End Sub

    Private Sub BtnArchivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnArchivo.Click
        If ModPOS.ReubicaArchivo Is Nothing Then
            ModPOS.ReubicaArchivo = New FrmReubicaArchivo
        End If
        ModPOS.ReubicaArchivo.StartPosition = FormStartPosition.CenterScreen
        ModPOS.ReubicaArchivo.Show()
        ModPOS.ReubicaArchivo.BringToFront()
    End Sub

  

    Private Sub GridOrigen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridOrigen.Click
        If Not GridOrigen.CurrentColumn Is Nothing Then
            If GridOrigen.CurrentColumn.Caption = "Mover" Then
                GridOrigen.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
            Else
                GridOrigen.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
            End If
        End If
    End Sub

    Private Sub GridDestino_FormattingRow(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.RowLoadEventArgs) Handles GridDestino.FormattingRow
        GridDestino.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
    End Sub

    
 
End Class