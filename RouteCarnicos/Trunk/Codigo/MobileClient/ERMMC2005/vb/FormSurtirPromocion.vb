Public Class FormSurtirPromocion
    Enum ModoApertura
        Crear = 1
        Consultar = 2
        Cancelar = 3
    End Enum

#Region "VARIABLES"
    Private oVista As Vista
    Private oCliente As Cliente
    Private oMMDA As Modulos.GrupoModuloMovDetalle
    Private sVisitaClave, sTransProdId As String
    Private bFin As Boolean = False
    Private blnSeleccionManual As Boolean = False
#End Region

#Region "METODOS"
    Private Sub LlenarLV()
        oVista.PoblarListView(Me.ListViewPromocion, oDBVen, "ListViewPromocion", "WHERE TransProd.Tipo=20 and Visita.ClienteClave='" & oCliente.ClienteClave & "' and Visita.VisitaClave='" & sVisitaClave & "' and Visita.DiaClave='" & oDia.DiaActual & "'")
        sTransProdId = String.Empty
    End Sub

    Private Sub MarcarElementoSeleccionado(ByRef LV As ListView)
        With LV
            If .SelectedIndices.Count > 0 Then
                For i As Integer = 0 To .Items.Count - 1
                    If i = .SelectedIndices(0) Then
                        .Items(i).Checked = True
                    Else
                        .Items(i).Checked = False
                    End If
                Next
            End If
        End With
    End Sub

    Private Sub SeleccionarElementoMarcado(ByRef LV As ListView, ByVal iIndice As Integer)
        With LV
            If .Items.Count > 0 Then
                For i As Integer = 0 To .Items.Count - 1
                    If i = iIndice Then
                        .Items(i).Selected = True
                    Else
                        .Items(i).Checked = False
                    End If
                Next
            End If
        End With
    End Sub

    Private Sub Continuar(ByVal tModoApertura As ModoApertura)
        Dim oSurtirDetalle As New FormSurtirPromocionDetalle(sTransProdId, oCliente, sVisitaClave, oMMDA)
        'oSurtirDetalle.ShowDialog()
        If Not IsNothing(MenuItemRegresar) Then
            If ListViewPromocion.Columns.Count > 0 Then
                If oVendedor.motconfiguracion.Secuencia Then
                    RemoveHandler ctrlSeguimiento.NuevaSeleccion, AddressOf TerminarVisita
                    RemoveHandler ctrlSeguimiento.TerminarVisitaMenu, AddressOf TerminarVisita
                    ctrlSeguimiento.QuitarMenuItem(Me.MainMenuPromo)
                    Me.Controls.Remove(ctrlSeguimiento)
                Else
                    For Each ctrl As Control In Me.Controls
                        If ctrl.Name = "lbNombreActividad" Then
                            Me.Controls.Remove(ctrl)
                            ctrl.Dispose()
                            ctrl = Nothing
                            Exit For
                        End If
                    Next

                End If
            End If
        End If

        Select Case tModoApertura
            Case ModoApertura.Crear
                oSurtirDetalle.Crear()
            Case ModoApertura.Consultar
                oSurtirDetalle.Consultar()
            Case ModoApertura.Cancelar
                oSurtirDetalle.Cancelar()
        End Select
        oSurtirDetalle.Dispose()
        Me.Close()
    End Sub
#End Region

#Region "FUNCIONES"
    Private Function HaySeleccion(ByVal LV As ListView) As Boolean
        If LV.Items.Count > 0 Then
            Dim i As Integer
            For i = 0 To LV.Items.Count - 1
                If LV.Items(i).Checked Then
                    sTransProdId = Me.ListViewPromocion.Items(i).SubItems(3).Text
                    Return True
                End If
            Next
        End If
        sTransProdId = String.Empty
        Return False
    End Function
#End Region

#Region "EVENTOS"

    Private Sub FormSurtirPromocion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        [Global].ObtenerFactores(Me)

        If oVendedor.motconfiguracion.Secuencia Then
            ctrlSeguimiento.AgregarControl(Me)
            Me.Panel1.SendToBack()
            ctrlSeguimiento.CrearMenuItem(Me.MainMenuPromo)
            AddHandler ctrlSeguimiento.NuevaSeleccion, AddressOf TerminarVisita
            AddHandler ctrlSeguimiento.TerminarVisitaMenu, AddressOf TerminarVisita
        End If

        [Global].EscalarFuente(Me)
        [Global].EscalarForma(Me)

        If oVendedor.motconfiguracion.Secuencia Then
            ctrlSeguimiento.Iniciar()
        Else
            Dim lbNombreActividad As New Label
            lbNombreActividad.BackColor = System.Drawing.SystemColors.Control
            lbNombreActividad.Dock = System.Windows.Forms.DockStyle.Top
            Dim tam As Single = 10 * nFactorH
            lbNombreActividad.Font = New System.Drawing.Font("Tahoma", tam!, System.Drawing.FontStyle.Bold)
            UbicarTitulo(lbNombreActividad, Me.Controls)
            lbNombreActividad.Name = "lbNombreActividad"
#If MOD_TERM = "IPAQ" Or MOD_TERM = "HHP9700" Then
            lbNombreActividad.Size = New System.Drawing.Size((Me.Width * nFactorW) - 5, 32 * nFactorH) 
#Else
            lbNombreActividad.Size = New System.Drawing.Size((Me.Width * nFactorW) - 5, 16 * nFactorH) 
#End If
            lbNombreActividad.Text = sNombreActividad
            lbNombreActividad.TextAlign = System.Drawing.ContentAlignment.TopCenter
            Me.Controls.Add(lbNombreActividad)
            lbNombreActividad.BringToFront()
            tam = Nothing
        End If

        Me.ListViewPromocion.Activation = oApp.TipoSeleccion
        If Not Vista.Buscar("FormSurtirPromocion", oVista) Then
            Exit Sub
        End If
        oVista.CrearListView(Me.ListViewPromocion, "ListViewPromocion")
        oVista.ColocarEtiquetasForma(Me)
        LlenarLV()
        sTransProdId = String.Empty
        bFin = True

        With ListViewPromocion
            If .Items.Count > 0 Then
                .Items(0).Selected = True
                .Focus()
            Else
                Continuar(ModoApertura.Crear)
            End If
        End With
        [Global].HabilitarMenuItem(Me.MainMenuPromo, True)
    End Sub

    Private Sub TerminarVisita()
        MenuItemRegresar_Click(Nothing, Nothing)
    End Sub

    Private Sub ButtonRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRegresar.Click
        Me.Close()
    End Sub

    Private Sub ButtonContinuar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonContinuar.Click
        If Me.ListViewPromocion.Items.Count > 0 Then
            If HaySeleccion(Me.ListViewPromocion) Then
                Continuar(ModoApertura.Consultar)
                Exit Sub
            End If
        End If
        Continuar(ModoApertura.Crear)
    End Sub

    Private Sub ButtonCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonCancelar.Click
        If Me.ListViewPromocion.Items.Count > 0 Then
            If HaySeleccion(Me.ListViewPromocion) Then
                Continuar(ModoApertura.Cancelar)
                Exit Sub
            End If
        End If
    End Sub

    Private Sub ListViewPromocion_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles ListViewPromocion.ItemCheck
        If blnSeleccionManual Then Exit Sub
        blnSeleccionManual = True
        MarcarElemento(ListViewPromocion, e.NewValue, e.Index)
        blnSeleccionManual = False
        If ListViewPromocion.SelectedIndices.Count <= 0 Then Exit Sub
        If e.NewValue = CheckState.Unchecked Then
            blnSeleccionManual = True
            ListViewPromocion.Items(ListViewPromocion.SelectedIndices(0)).Selected = False
            sTransProdId = String.Empty
            blnSeleccionManual = False
        Else
            sTransProdId = Me.ListViewPromocion.Items(Me.ListViewPromocion.SelectedIndices(0)).SubItems(0).Text
        End If
    End Sub

    Private Sub MenuItemRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemRegresar.Click
        Me.Close()
    End Sub
#End Region

    Private Sub ListViewPromocion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListViewPromocion.SelectedIndexChanged
        If blnSeleccionManual Then Exit Sub
        If ListViewPromocion.SelectedIndices.Count <= 0 Then Exit Sub
        blnSeleccionManual = True
        MarcarElemento(ListViewPromocion, CheckState.Checked, ListViewPromocion.SelectedIndices(0))
        blnSeleccionManual = False
    End Sub

   
End Class