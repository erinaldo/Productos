Public Class FrmReubicacion

    Private dtOrigen As DataTable
    Private dtDestinoManual, dtDestino As DataTable
    Private UBCOrigen As String = ""
    Private UBCDestino As String = ""
    Private SUCClave As String
    Private bLoad As Boolean = False
    Private EstadoUBC, EstadoPEU As Integer
    Private TallaColor As Integer = 0
    Private InterfazSalida As String

    Private Sub FrmReubicacion_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.Reubicacion.Dispose()
        ModPOS.Reubicacion = Nothing
    End Sub

    Private Sub recuperaAlmacenOrigen()
        If Not cmbSucursalO.SelectedValue Is Nothing Then
            SUCClave = cmbSucursalO.SelectedValue
            With cmbOrigen
                .Conexion = ModPOS.BDConexion
                .ProcedimientoAlmacenado = "sp_filtra_almsuc"
                .NombreParametro1 = "SUCClave"
                .Parametro1 = SUCClave
                .llenar()
            End With
        Else
            SUCClave = ""
        End If
    End Sub

    Private Sub FrmReubicacion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim dtParam As DataTable
        Dim i As Integer

        dtParam = ModPOS.Recupera_Tabla("sp_recupera_parametro", "@COMClave", ModPOS.CompanyActual)
        With Me
            For i = 0 To dtParam.Rows.Count - 1
                Select Case CStr(dtParam.Rows(i)("PARClave"))
                    Case "InterfazSalida"
                        InterfazSalida = IIf(dtParam.Rows(i)("Valor").GetType.Name = "DBNull", "", dtParam.Rows(i)("Valor"))
                    Case "TallaColor"
                        TallaColor = IIf(dtParam.Rows(i)("Valor").GetType.Name = "DBNull", 0, dtParam.Rows(i)("Valor"))

                End Select
            Next
        End With
        dtParam.Dispose()

        With cmbSucursalO
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_sucursal"
            .NombreParametro1 = "USRClave"
            .Parametro1 = ModPOS.UsuarioActual
            .NombreParametro2 = "COMClave"
            .Parametro2 = ModPOS.CompanyActual
            .llenar()
        End With

        If ModPOS.SucursalPredeterminada <> "" Then
            cmbSucursalO.SelectedValue = ModPOS.SucursalPredeterminada
        End If

        recuperaAlmacenOrigen()

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

        dtDestino = ModPOS.CrearTabla("ReubicacionDetalle", _
                                                "PROClave", "System.String", _
                                                "Clave", "System.String", _
                                                "Mover", "System.Double", _
                                                "UBCOrigen", "System.String", _
                                                "Origen", "System.String", _
                                                "UBCDestino", "System.String", _
                                                "Destino", "System.String", _
                                                "Estado", "System.Int32")

        GridFile.DataSource = dtDestino
        GridFile.RetrieveStructure()
        GridFile.RootTable.Columns("PROClave").Visible = False
        GridFile.RootTable.Columns("Estado").Visible = False
        GridFile.RootTable.Columns("UBCOrigen").Visible = False
        GridFile.RootTable.Columns("UBCDestino").Visible = False
        GridFile.CurrentTable.Columns("Clave").Selectable = False
        GridFile.RootTable.Columns("Mover").FormatString = "0.00"
      
        bLoad = True

    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        If (Not CmbOrigen.SelectedValue Is Nothing AndAlso Not CmbTipo.SelectedValue Is Nothing) Then
            Dim a As New MeSearch
            If CmbTipo.SelectedValue = 1 Then 'Ubicación
                If Not CmbOrigen.SelectedValue Is Nothing Then
                    a.ProcedimientoAlmacenado = "sp_search_ubicacion"
                    a.TablaCmb = "Reubicacion"
                    a.CampoCmb = "Filtro"
                    a.BusquedaInicial = True
                    a.Busqueda = TxtClave.Text
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
                If TallaColor = 1 Then
                    a.ProcedimientoAlmacenado = "st_search_producto_tc"
                    a.CampoCmb = "FiltroTC"
                Else
                    a.ProcedimientoAlmacenado = "sp_search_producto"
                    a.CampoCmb = "Filtro"
                End If
                a.TablaCmb = "Producto"
                a.AlmRequerido = True
                a.ALMClave = CmbOrigen.SelectedValue
                a.bReplace = True
                a.CompaniaRequerido = True
                a.NumColDes = 2
                a.BusquedaInicial = True
                a.Busqueda = TxtClave.Text
            End If

            a.ShowDialog()

            If a.DialogResult = DialogResult.OK Then

                If CmbTipo.SelectedValue = 1 Then
                    TxtClave.Text = a.Descripcion
                Else
                    TxtClave.Text = a.valor
                End If

                recuperar(CmbOrigen.SelectedValue, TxtClave.Text, CmbTipo.SelectedValue)

            End If
            a.Dispose()

        Else
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos (Almacén y/o Tipo) no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
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
                GridOrigen.RootTable.Columns("TESTClave").Visible = False
                GridOrigen.RootTable.Columns("Mover").FormatString = "0.00"
                GridOrigen.RootTable.Columns("Disponible").FormatString = "0.00"

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
        cmbSucursalO.Enabled = False
       
        If Tipo = 3 Then
            TxtUbicacion.Text = Texto

            If Not dtDestinoManual Is Nothing Then
                dtDestinoManual.Dispose()
            End If

            dtDestinoManual = ModPOS.Recupera_Tabla("sp_muestra_ubicados", "@Tipo", Tipo, "@ALMClave", ALMClave, "@Clave", Texto.ToUpper.Trim.Replace("'", "''"), "@Char", cReplace, "@TallaColor", TallaColor)
            GridDestino.DataSource = dtDestinoManual
            GridDestino.RetrieveStructure()
            GridDestino.AutoSizeColumns()
            GridDestino.RootTable.Columns("PROClave").Visible = False
            GridDestino.RootTable.Columns("UBCClave").Visible = False
            GridDestino.RootTable.Columns("Estado").Visible = False
            GridDestino.RootTable.Columns("TESTClave").Visible = False

            Me.GridDestino.RootTable.Columns("EST").Width = 40
            Me.GridDestino.RootTable.Columns("Ubicación").Width = 40
            Me.GridDestino.RootTable.Columns("Clave").Width = 70
            If TallaColor = 0 Then
                Me.GridDestino.RootTable.Columns("Nombre").Width = 250
            End If

            Me.GridDestino.RootTable.Columns("Existencia").Width = 20
            Me.GridDestino.RootTable.Columns("Apartado").Width = 20

            GridDestino.RootTable.Columns("Existencia").FormatString = "0.00"
            GridDestino.RootTable.Columns("Apartado").FormatString = "0.00"
            GridDestino.RootTable.Columns("Bloqueado").FormatString = "0.00"



        Else

            TxtClave.Text = Texto

            If Not dtOrigen Is Nothing Then
                dtOrigen.Dispose()
            End If

            dtOrigen = ModPOS.Recupera_Tabla("sp_muestra_ubicados", "@Tipo", Tipo, "@ALMClave", ALMClave, "@Clave", Texto.ToUpper.Trim.Replace("'", "''"), "@Char", cReplace, "@TallaColor", TallaColor)
            GridOrigen.DataSource = dtOrigen
            GridOrigen.RetrieveStructure()
            GridOrigen.AutoSizeColumns()
            GridOrigen.RootTable.Columns("PROClave").Visible = False
            GridOrigen.RootTable.Columns("UBCClave").Visible = False
            GridOrigen.RootTable.Columns("Estado").Visible = False
            GridOrigen.RootTable.Columns("TESTClave").Visible = False

            Me.GridOrigen.RootTable.Columns("EST").Width = 40
            Me.GridOrigen.RootTable.Columns("Ubicación").Width = 40
            Me.GridOrigen.RootTable.Columns("Clave").Width = 70

            If TallaColor = 0 Then
                Me.GridOrigen.RootTable.Columns("Nombre").Width = 250
            End If

            Me.GridOrigen.RootTable.Columns("Disponible").Width = 20
            Me.GridOrigen.RootTable.Columns("Mover").Width = 20
            GridOrigen.RootTable.Columns("Disponible").FormatString = "0.00"
            GridOrigen.RootTable.Columns("Mover").FormatString = "0.00"

            If dtOrigen.Rows.Count = 0 AndAlso Tipo <> 3 Then
                If CmbTipo.SelectedValue = 1 Then
                    MessageBox.Show("No se encontro producto en la " & CmbTipo.Text & " con clave " & Texto.ToUpper.Trim, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("No se encontro existencia del Producto con Clave " & Texto.ToUpper.Trim, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If

        End If


    End Sub

    Private Sub TxtClave_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtClave.KeyDown
        If e.KeyCode = Keys.Enter Then
            If (Not CmbOrigen.SelectedValue Is Nothing AndAlso Not CmbTipo.SelectedValue Is Nothing AndAlso Not TxtClave.Text = "") Then
                recuperar(CmbOrigen.SelectedValue, TxtClave.Text.Trim.ToUpper, CmbTipo.SelectedValue)
            Else
                Beep()
                MessageBox.Show("¡Alguno de los datos introducidos (Almacén y/o Tipo) no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        ElseIf e.KeyCode = Keys.Right Then
            BtnBuscar.PerformClick()
        End If
    End Sub

    Private Sub TxtUbicacion_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtUbicacion.KeyDown
        If e.KeyCode = Keys.Enter Then
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
        ElseIf e.KeyCode = Keys.Right Then
            BtnBuscaUbicacion.PerformClick()
        End If

    End Sub

    Private Sub BtnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOK.Click
        Dim Referencia As String = ModPOS.obtenerLlave
        Dim CambioEstado As Boolean = False
        Dim dt As DataTable

        If UiTabUbica.SelectedTab.Name = "UiTabManual" Then
            If Not dtOrigen Is Nothing Then
                If Not dtDestinoManual Is Nothing OrElse UBCDestino <> "" Then

                    Dim TESTClaveD As Integer = -1
                    dt = ModPOS.Recupera_Tabla("sp_recupera_ubicacion", "@UBCClave", UBCDestino)
                    Dim Estructura As String = dt.Rows(0)("ESTClave")
                    dt.Dispose()


                    dt = ModPOS.Recupera_Tabla("sp_recupera_est", "@Estructura", Estructura)
                    TESTClaveD = CInt(dt.Rows(0)("TESTClave"))
                    dt.Dispose()




                    If dtOrigen.Rows(0)("TESTClave") = 0 AndAlso TESTClaveD <> 3 Then
                        MessageBox.Show("No es posible reubicar a una estructura que no sea de tipo Transito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    ElseIf dtOrigen.Rows(0)("TESTClave") = 1 AndAlso Not (TESTClaveD = 1 OrElse TESTClaveD = 2) Then
                        MessageBox.Show("No es posible reubicar a una estructura que no sea de tipo Almacenaje/Stage", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    ElseIf dtOrigen.Rows(0)("TESTClave") = 2 AndAlso Not (TESTClaveD = 1 OrElse TESTClaveD = 2) Then
                        MessageBox.Show("No es posible reubicar a una estructura que no sea de tipo Almacenaje/Stage", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    ElseIf dtOrigen.Rows(0)("TESTClave") = 3 AndAlso TESTClaveD = 0 Then
                        MessageBox.Show("No es posible reubicar a una estructura de tipo Anden", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If


                Dim foundRows() As DataRow
                foundRows = dtOrigen.Select("Mover > 0")
                If foundRows.Length > 0 Then
                    Dim i As Integer

                    ' Si en el destino no existe el producto recupera el Estado de la Ubicacion

                    Dim dtU As DataTable = ModPOS.Recupera_Tabla("sp_recupera_ubicacion", "@UBCClave", UBCDestino)
                    EstadoUBC = CInt(dtU.Rows(0)("Estado"))
                    dtU.Dispose()


                    If ChkSinUbicar.Checked Then
                        'Sin ubicar
                        For i = 0 To foundRows.GetUpperBound(0)

                            dt = Recupera_Tabla("st_recupera_peu", "@PROClave", foundRows(i)("PROClave"), "@UBCClave", UBCDestino)
                            If dt.Rows.Count = 1 Then
                                If CDbl(dt.Rows(0)("Existencia")) > 0 Then
                                    EstadoPEU = CInt(dt.Rows(0)("Estado"))
                                Else
                                    EstadoPEU = EstadoUBC
                                End If
                            Else
                                EstadoPEU = EstadoUBC
                            End If

                            ModPOS.Ejecuta("sp_reubicar", "@ALMClave", CmbOrigen.SelectedValue, "@Primera", 1, "@PROClave", foundRows(i)("PROClave"), "@UBCOrigen", "", "@UBCDestino", UBCDestino, "@Cantidad", foundRows(i)("Mover"), "@Estado", EstadoPEU, "@Usuario", ModPOS.UsuarioActual)

                            If 1 <> EstadoPEU Then


                                ModPOS.Ejecuta("st_cambio_estado", _
                                        "@SUCClave", SUCClave, _
                                        "@ALMClave", CmbOrigen.SelectedValue, _
                                        "@UBCClave", UBCDestino, _
                                        "@PROClave", foundRows(i)("PROClave"), _
                                        "@Cantidad", foundRows(i)("Mover"), _
                                        "@Estado", EstadoPEU, _
                                        "@Referencia", Referencia, _
                                        "@Actualiza", 1, _
                                        "@Usuario", ModPOS.UsuarioActual)
                                CambioEstado = True
                            End If

                        Next
                    Else

                        For i = 0 To foundRows.GetUpperBound(0)
                            If foundRows(i)("UBCClave") <> UBCDestino Then

                                dt = Recupera_Tabla("st_recupera_peu", "@PROClave", foundRows(i)("PROClave"), "@UBCClave", UBCDestino)
                                If dt.Rows.Count = 1 Then
                                    If CDbl(dt.Rows(0)("Existencia")) > 0 Then
                                        EstadoPEU = CInt(dt.Rows(0)("Estado"))
                                    Else
                                        EstadoPEU = EstadoUBC
                                    End If

                                Else
                                    EstadoPEU = EstadoUBC
                                End If

                                ModPOS.Ejecuta("sp_reubicar", "@ALMClave", CmbOrigen.SelectedValue, "@Primera", 0, "@PROClave", foundRows(i)("PROClave"), "@UBCOrigen", foundRows(i)("UBCClave"), "@UBCDestino", UBCDestino, "@Cantidad", foundRows(i)("Mover"), "@Estado", EstadoPEU, "@Usuario", ModPOS.UsuarioActual)

                                If CInt(foundRows(i)("TESTClave")) = 1 OrElse CInt(foundRows(i)("TESTClave")) = 2 Then



                                    If foundRows(i)("Estado") <> EstadoPEU Then
                                        ModPOS.Ejecuta("st_cambio_estado", _
                                                "@SUCClave", SUCClave, _
                                                "@ALMClave", CmbOrigen.SelectedValue, _
                                                "@UBCClave", UBCDestino, _
                                                "@PROClave", foundRows(i)("PROClave"), _
                                                "@Cantidad", foundRows(i)("Mover"), _
                                                "@Estado", EstadoPEU, _
                                                "@Referencia", Referencia, _
                                                "@Actualiza", 1, _
                                                "@Usuario", ModPOS.UsuarioActual)
                                        CambioEstado = True
                                    End If
                                End If
                            End If
                        Next
                    End If


                    'Interfaz Cambio Estado
                    If CambioEstado = True AndAlso InterfazSalida <> "" Then
                        Dim dtInterfaz As DataTable
                        Dim sFecha As String

                        sFecha = DateTime.Now.ToString("yyyyMMdd_HHmmssfff")

                        dtInterfaz = Recupera_Tabla("st_recupera_interfaz", "@Interfaz", "CambioEstado", "@COMClave", ModPOS.CompanyActual)
                        If dtInterfaz.Rows.Count > 0 Then
                            ModPOS.Ejecuta(CStr(dtInterfaz.Rows(0)("sp")), "@Folio", Referencia, "@TipoDocumento", 0, "@Path", InterfazSalida, "@Fecha", sFecha)
                        End If
                    End If

                    If Me.ChkSinUbicar.Checked Then
                        dtOrigen = ModPOS.Recupera_Tabla("sp_muestra_sin_ubicar", "@ALMClave", CmbOrigen.SelectedValue)

                        GridOrigen.DataSource = dtOrigen
                        GridOrigen.RetrieveStructure()
                        GridOrigen.AutoSizeColumns()
                        GridOrigen.RootTable.Columns("PROClave").Visible = False
                        GridOrigen.RootTable.Columns("TESTClave").Visible = False

                        Me.GridOrigen.RootTable.Columns("Clave").Width = 70
                        Me.GridOrigen.RootTable.Columns("Nombre").Width = 250
                        Me.GridOrigen.RootTable.Columns("Disponible").Width = 20
                            Me.GridOrigen.RootTable.Columns("Mover").Width = 20
                            GridOrigen.RootTable.Columns("Disponible").FormatString = "0.00"
                            GridOrigen.RootTable.Columns("Mover").FormatString = "0.00"

                    Else
                        recuperar(CmbOrigen.SelectedValue, TxtClave.Text.Trim.ToUpper, CmbTipo.SelectedValue)
                    End If

                    recuperar(CmbOrigen.SelectedValue, TxtUbicacion.Text.ToUpper.Trim, 3)




                    MessageBox.Show("La reubicación se realizó correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)


                Else
                    MessageBox.Show("Debe indicar la cantidad de producto a mover por lo menos de un registro", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                MessageBox.Show("Debe seleccionar la ubicación destino", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            MessageBox.Show("Debe indicar la ubicación origen del producto que desea mover", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Else
        If dtDestino.Rows.Count > 0 Then
                Dim Estructura As String = ""
                Dim dtU As DataTable
                Dim TESTClave As Integer = -1
                Dim TESTClaveD As Integer = -1

                Dim i, ESTOrigen, ESTDestino As Integer

                Dim existencia, apartado, bloqueado As Double

                For i = 0 To dtDestino.Rows.Count - 1

                    dtU = ModPOS.Recupera_Tabla("sp_recupera_ubicacion", "@UBCClave", dtDestino.Rows(i)("UBCOrigen"))
                    Estructura = dtU.Rows(0)("ESTClave")
                    dtU.Dispose()


                    dtU = ModPOS.Recupera_Tabla("sp_recupera_est", "@Estructura", Estructura)
                    TESTClave = CInt(dtU.Rows(0)("TESTClave"))
                    dtU.Dispose()


                    dt = Recupera_Tabla("st_recupera_peu", "@PROClave", dtDestino.Rows(i)("PROClave"), "@UBCClave", dtDestino.Rows(i)("UBCOrigen"))
                    If dt.Rows.Count = 1 Then
                        ESTOrigen = CInt(dt.Rows(0)("Estado"))
                        existencia = CDbl(dt.Rows(0)("Existencia"))
                        apartado = IIf(CDbl(dt.Rows(0)("apartado")) < 0, 0, CDbl(dt.Rows(0)("apartado")))
                        bloqueado = CDbl(dt.Rows(0)("bloqueado"))

                        If (existencia - apartado - bloqueado) >= dtDestino.Rows(i)("Mover") Then


                            dtU = ModPOS.Recupera_Tabla("sp_recupera_ubicacion", "@UBCClave", dtDestino.Rows(i)("UBCDestino"))
                            Estructura = dtU.Rows(0)("ESTClave")
                            dtU.Dispose()


                            dtU = ModPOS.Recupera_Tabla("sp_recupera_est", "@Estructura", Estructura)
                            TESTClaveD = CInt(dtU.Rows(0)("TESTClave"))
                            dtU.Dispose()



                            If TESTClave = 0 AndAlso TESTClaveD <> 3 Then
                                MessageBox.Show("No fue posible realizar la reubicación del producto " & CStr(dtDestino.Rows(0)("Clave")) & ", No es posible reubicar a una estructura que no sea de tipo Transito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            ElseIf TESTClave = 1 AndAlso Not (TESTClaveD = 1 OrElse TESTClaveD = 2) Then
                                MessageBox.Show("No fue posible realizar la reubicación del producto " & CStr(dtDestino.Rows(0)("Clave")) & ", No es posible reubicar a una estructura que no sea de tipo Almacenaje/Stage", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            ElseIf TESTClave = 2 AndAlso Not (TESTClaveD = 1 OrElse TESTClaveD = 2) Then
                                MessageBox.Show("No fue posible realizar la reubicación del producto " & CStr(dtDestino.Rows(0)("Clave")) & ", No es posible reubicar a una estructura que no sea de tipo Almacenaje/Stage", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            ElseIf TESTClave = 3 AndAlso TESTClaveD = 0 Then
                                MessageBox.Show("No fue posible realizar la reubicación del producto " & CStr(dtDestino.Rows(0)("Clave")) & ", No es posible reubicar a una estructura de tipo Anden", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else



                                dtU = Recupera_Tabla("st_recupera_peu", "@PROClave", dtDestino.Rows(i)("PROClave"), "@UBCClave", dtDestino.Rows(i)("UBCDestino"))
                                If dtU.Rows.Count = 1 Then
                                    If CDbl(dtU.Rows(0)("Existencia")) > 0 Then
                                        ESTDestino = CInt(dtU.Rows(0)("Estado"))
                                    Else
                                        ESTDestino = ESTOrigen
                                    End If

                                Else
                                    ESTDestino = ESTOrigen
                                End If
                                dtU.Dispose()


                                ModPOS.Ejecuta("sp_reubicar", "@ALMClave", CmbOrigen.SelectedValue, "@Primera", 0, "@PROClave", dtDestino.Rows(i)("PROClave"), "@UBCOrigen", dtDestino.Rows(i)("UBCOrigen"), "@UBCDestino", dtDestino.Rows(i)("UBCDestino"), "@Cantidad", dtDestino.Rows(i)("Mover"), "@Estado", ESTDestino, "@Usuario", ModPOS.UsuarioActual)

                                If TESTClave = 1 OrElse TESTClave = 2 Then
                                    If ESTDestino <> ESTOrigen Then


                                        ModPOS.Ejecuta("st_cambio_estado", _
                                                "@SUCClave", SUCClave, _
                                                "@ALMClave", CmbOrigen.SelectedValue, _
                                                "@UBCClave", dtDestino.Rows(i)("UBCDestino"), _
                                                "@PROClave", dtDestino.Rows(i)("PROClave"), _
                                                "@Cantidad", dtDestino.Rows(i)("Mover"), _
                                                "@Estado", ESTDestino, _
                                                "@Referencia", Referencia, _
                                                "@Actualiza", 1, _
                                                "@Usuario", ModPOS.UsuarioActual)
                                        CambioEstado = True
                                    End If
                                End If

                            End If
                    Else
                        MessageBox.Show("No fue posible realizar la reubicación del producto " & CStr(dtDestino.Rows(0)("Clave")) & ", ya que la cantidad registrada excede la disponible para reubicar o se encuentra bloqueada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                    End If
                    dt.Dispose()

                Next
            dtDestino.Rows.Clear()

            'Interfaz Cambio Estado
            If CambioEstado = True AndAlso InterfazSalida <> "" Then
                Dim dtInterfaz As DataTable
                Dim sFecha As String

                sFecha = DateTime.Now.ToString("yyyyMMdd_HHmmssfff")

                dtInterfaz = Recupera_Tabla("st_recupera_interfaz", "@Interfaz", "CambioEstado", "@COMClave", ModPOS.CompanyActual)
                If dtInterfaz.Rows.Count > 0 Then
                    ModPOS.Ejecuta(CStr(dtInterfaz.Rows(0)("sp")), "@Folio", Referencia, "@TipoDocumento", 0, "@Path", InterfazSalida, "@Fecha", sFecha)
                End If
            End If

            MessageBox.Show("La reubicación ha finalizado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Else
            MessageBox.Show("No se encontraron registros para procesar, debe importar archivo!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

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

    Private Sub cmbSucursalO_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbSucursalO.SelectedValueChanged
        If bLoad = True Then
            recuperaAlmacenOrigen()
        End If
    End Sub

    Private Sub BtnFile_Click(sender As Object, e As EventArgs) Handles BtnFile.Click
            Dim curFileName As String = ""
            'buscamos la imagen a grabar
            Try
                Dim openDlg As OpenFileDialog = New OpenFileDialog
                openDlg.Filter = "Todos los archivos de CSV|*.CSV|Todos los archivos TXT|*.TXT"
                ' Dim filter As String = openDlg.Filter
                openDlg.Title = "Abrir un Archivo de CSV o TXT"
                If (openDlg.ShowDialog() = DialogResult.OK) Then
                    curFileName = openDlg.FileName

                Dim dtTemporal As DataTable = ReadCSV(curFileName, 4)

                    If dtTemporal.Rows.Count > 0 Then
                        Dim frmStatusMessage As New frmStatus
                        frmStatusMessage.BringToFront()

                        Dim i As Integer
                        Dim PROClave, UBCClave As String
                        Dim Cantidad As Double
                        Dim iEstado As Integer
                        Dim dt As DataTable

                        For i = 0 To dtTemporal.Rows.Count - 1
                            frmStatusMessage.Show("Procesando " & CStr(i + 1) & " de " & CStr(dtTemporal.Rows.Count) & "registros")
                        'valida ubicacion Origen
                        If dtTemporal.Rows(i)("Area").GetType.FullName <> "System.DBNull" Then
                            dt = Recupera_Tabla("sp_recupera_ubicaciones", "@ALMClave", CmbOrigen.SelectedValue, "@Ubicacion", dtTemporal.Rows(i)("Area").ToString.Trim)
                            If dt.Rows.Count > 0 Then
                                UBCOrigen = dt.Rows(0)("UBCClave")
                                dt.Dispose()
                                ' valida ubicacion Destino
                                If dtTemporal.Rows(i)("Ubicacion").GetType.FullName <> "System.DBNull" Then
                                    dt = Recupera_Tabla("sp_recupera_ubicaciones", "@ALMClave", CmbOrigen.SelectedValue, "@Ubicacion", dtTemporal.Rows(i)("Ubicacion").ToString.Trim)
                                    If dt.Rows.Count > 0 Then
                                        UBCClave = dt.Rows(0)("UBCClave")
                                        iEstado = dt.Rows(0)("Estado")
                                        dt.Dispose()
                                        ' valida el producto
                                        If dtTemporal.Rows(i)("Producto").GetType.FullName <> "System.DBNull" Then
                                            dt = Recupera_Tabla("sp_compra_producto", "@COMClave", ModPOS.CompanyActual, "@Clave", dtTemporal.Rows(i)("Producto").ToString.Replace("'", "''").Trim, "@Char", cReplace, "@TallaColor", TallaColor)
                                            If dt.Rows.Count = 1 Then
                                                PROClave = dt.Rows(0)("PROClave")
                                                dt.Dispose()
                                                ' valida la Cantidad
                                                If dtTemporal.Rows(i)("Capacidad").GetType.FullName <> "System.DBNull" Then
                                                    If IsNumeric(dtTemporal.Rows(i)("Capacidad")) AndAlso CDbl(dtTemporal.Rows(i)("Capacidad")) > 0 Then
                                                        Cantidad = CDbl(dtTemporal.Rows(i)("Capacidad"))

                                                        Dim foundRows() As System.Data.DataRow
                                                        foundRows = dtDestino.Select("PROClave = '" & PROClave & "' and Destino='" & dtTemporal.Rows(i)("Ubicacion") & "'")

                                                        If foundRows.Length = 0 Then

                                                            dt = Recupera_Tabla("st_recupera_peu", "@PROClave", PROClave, "@UBCClave", UBCClave)
                                                            If dt.Rows.Count = 1 Then
                                                                iEstado = CInt(dt.Rows(0)("Estado"))
                                                            End If
                                                            dt.Dispose()

                                                            Dim row1 As DataRow
                                                            row1 = dtDestino.NewRow()
                                                            'declara el nombre de la fila
                                                            row1.Item("PROClave") = PROClave
                                                            row1.Item("Clave") = dtTemporal.Rows(i)("Producto").ToString.Replace("'", "''").Trim
                                                            row1.Item("Mover") = Cantidad
                                                            row1.Item("UBCOrigen") = UBCOrigen
                                                            row1.Item("Origen") = dtTemporal.Rows(i)("Area").ToString.Trim
                                                            row1.Item("UBCDestino") = UBCClave
                                                            row1.Item("Destino") = dtTemporal.Rows(i)("Ubicacion").ToString.Trim
                                                            row1.Item("Estado") = iEstado
                                                            dtDestino.Rows.Add(row1)
                                                        End If
                                                    Else
                                                        If MessageBox.Show("La fila " & CStr(i + 1) & " no cuenta con una existencia valida " & dtTemporal.Rows(i)("Capacidad").ToString & ". ¿Desea continuar procesando el archivo?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error) = System.Windows.Forms.DialogResult.No Then
                                                            Exit For
                                                        End If
                                                    End If
                                                Else
                                                    If MessageBox.Show("La Cantidad de la fila " & CStr(i + 1) & " se encuentra vacia. ¿Desea continuar procesando el archivo?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error) = System.Windows.Forms.DialogResult.No Then
                                                        Exit For
                                                    End If
                                                End If
                                            Else
                                                dt.Dispose()
                                                If MessageBox.Show("La fila " & CStr(i + 1) & " cuenta con una clave de producto que no existe" & dtTemporal.Rows(i)("Producto").ToString & ". ¿Desea continuar procesando el archivo?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error) = System.Windows.Forms.DialogResult.No Then
                                                    Exit For
                                                End If
                                            End If
                                        Else
                                            If MessageBox.Show("La clave de producto de la fila " & CStr(i + 1) & " se encuentra vacia. ¿Desea continuar procesando el archivo?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error) = System.Windows.Forms.DialogResult.No Then
                                                Exit For
                                            End If
                                        End If
                                    Else
                                        dt.Dispose()
                                        If MessageBox.Show("La fila " & CStr(i + 1) & " tiene una ubicación destino que no existe o no pertenece al almacén actual" & dtTemporal.Rows(i)("Ubicacion").ToString & ". ¿Desea continuar procesando el archivo?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error) = System.Windows.Forms.DialogResult.No Then
                                            Exit For
                                        End If
                                    End If
                                Else
                                    If MessageBox.Show("La Ubicación Destino de la fila " & CStr(i + 1) & " se encuentra vacia. ¿Desea continuar procesando el archivo?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error) = System.Windows.Forms.DialogResult.No Then
                                        Exit For
                                    End If
                                End If

                            Else
                                dt.Dispose()
                                If MessageBox.Show("La fila " & CStr(i + 1) & " tiene una ubicación origen que no existe o no pertenece al almacén actual" & dtTemporal.Rows(i)("Area").ToString & ". ¿Desea continuar procesando el archivo?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error) = System.Windows.Forms.DialogResult.No Then
                                    Exit For
                                End If
                            End If
                        Else
                            If MessageBox.Show("La Ubicación Origen de la fila " & CStr(i + 1) & " se encuentra vacia. ¿Desea continuar procesando el archivo?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error) = System.Windows.Forms.DialogResult.No Then
                                Exit For
                            End If
                        End If
                        Next
                        frmStatusMessage.Close()
                        Cursor.Current = Cursors.Default
                    Else
                    MessageBox.Show("El archivo no cuenta con el formato: Origen,Destino,Producto,Cantidad o se encuentra vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
      
    End Sub

  
    Private Sub CmbOrigen_SelectedValueChanged(sender As Object, e As EventArgs) Handles CmbOrigen.SelectedValueChanged
        If bLoad = True AndAlso (Not CmbOrigen.SelectedValue Is Nothing AndAlso Not CmbTipo.SelectedValue Is Nothing) Then
            recuperar(CmbOrigen.SelectedValue, TxtClave.Text.Trim.ToUpper, CmbTipo.SelectedValue)
            recuperar(CmbOrigen.SelectedValue, "", 3)
            UBCDestino = ""
            lblDestino.Text = ""
        End If
    End Sub
End Class
