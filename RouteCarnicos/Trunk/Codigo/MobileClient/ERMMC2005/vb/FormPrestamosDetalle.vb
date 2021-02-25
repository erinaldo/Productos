Public Class FormPrestamosDetalle
    Inherits System.Windows.Forms.Form
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal parsTransProdId As String, ByVal parVista As Vista, ByVal pvClienteClave As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        sTransProdId = parsTransProdId
        sClienteClave = pvClienteClave
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If Not Me.MenuItemCancelar Is Nothing Then Me.MenuItemCancelar.Dispose()
        If Not Me.MainMenu1 Is Nothing Then Me.MainMenu1.Dispose()
        If Not Me.ListViewProductos Is Nothing Then
            If Me.ListViewProductos.Columns.Count > 0 Then
                Me.ListViewProductos.Columns.Clear()
            End If
        End If
        If Not Me.FlexGridDetalle Is Nothing Then Me.FlexGridDetalle.Dispose()
        Me.FlexGridDetalle = Nothing
        MyBase.Dispose(disposing)
    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ButtonCancelar As System.Windows.Forms.Button
    Friend WithEvents ButtonAceptar As System.Windows.Forms.Button
    Friend WithEvents FlexGridDetalle As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents ListViewProductos As System.Windows.Forms.ListView

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents MenuItemCancelar As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormPrestamosDetalle))
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.MenuItemCancelar = New System.Windows.Forms.MenuItem
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.ButtonCancelar = New System.Windows.Forms.Button
        Me.ButtonAceptar = New System.Windows.Forms.Button
        Me.FlexGridDetalle = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.ListViewProductos = New System.Windows.Forms.ListView
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.Add(Me.MenuItemCancelar)
        '
        'MenuItemCancelar
        '
        Me.MenuItemCancelar.Text = "MenuItemCancelar"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ButtonCancelar)
        Me.Panel1.Controls.Add(Me.ButtonAceptar)
        Me.Panel1.Controls.Add(Me.FlexGridDetalle)
        Me.Panel1.Controls.Add(Me.ListViewProductos)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(242, 295)
        '
        'ButtonCancelar
        '
        Me.ButtonCancelar.Location = New System.Drawing.Point(86, 259)
        Me.ButtonCancelar.Name = "ButtonCancelar"
        Me.ButtonCancelar.Size = New System.Drawing.Size(72, 24)
        Me.ButtonCancelar.TabIndex = 7
        Me.ButtonCancelar.Text = "ButtonCancelar"
        '
        'ButtonAceptar
        '
        Me.ButtonAceptar.Location = New System.Drawing.Point(6, 259)
        Me.ButtonAceptar.Name = "ButtonAceptar"
        Me.ButtonAceptar.Size = New System.Drawing.Size(72, 24)
        Me.ButtonAceptar.TabIndex = 6
        Me.ButtonAceptar.Text = "ButtonAceptar"
        '
        'FlexGridDetalle
        '
        Me.FlexGridDetalle.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.FlexGridDetalle.AllowEditing = True
        Me.FlexGridDetalle.AutoResize = True
        Me.FlexGridDetalle.AutoSearchDelay = 1
        Me.FlexGridDetalle.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.FlexGridDetalle.Clip = ""
        Me.FlexGridDetalle.ClipSeparators = "" & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(13)
        Me.FlexGridDetalle.Col = 0
        Me.FlexGridDetalle.ColSel = 0
        Me.FlexGridDetalle.ComboList = Nothing
        Me.FlexGridDetalle.EditMask = Nothing
        Me.FlexGridDetalle.ExtendLastCol = False
        Me.FlexGridDetalle.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
        Me.FlexGridDetalle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.FlexGridDetalle.LeftCol = 1
        Me.FlexGridDetalle.Location = New System.Drawing.Point(7, 120)
        Me.FlexGridDetalle.Name = "FlexGridDetalle"
        Me.FlexGridDetalle.Redraw = True
        Me.FlexGridDetalle.Row = 1
        Me.FlexGridDetalle.RowSel = 1
        Me.FlexGridDetalle.ScrollPosition = New System.Drawing.Point(0, 0)
        Me.FlexGridDetalle.ScrollTrack = True
        Me.FlexGridDetalle.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.FlexGridDetalle.ShowCursor = False
        Me.FlexGridDetalle.ShowSort = True
        Me.FlexGridDetalle.Size = New System.Drawing.Size(228, 136)
        Me.FlexGridDetalle.StyleInfo = resources.GetString("FlexGridDetalle.StyleInfo")
        Me.FlexGridDetalle.SupportInfo = "pACQASYBwAAwAKcBeQDHAK4A1gClAMcAWgEbAb0AHgF9ABgBQwFKAS4BtQBvAGgASAAxAcAA2QBBAPAA5" & _
            "QDLAKgAVAAfAQ=="
        Me.FlexGridDetalle.TabIndex = 5
        Me.FlexGridDetalle.TopRow = 1
        '
        'ListViewProductos
        '
        Me.ListViewProductos.FullRowSelect = True
        Me.ListViewProductos.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListViewProductos.Location = New System.Drawing.Point(7, 17)
        Me.ListViewProductos.Name = "ListViewProductos"
        Me.ListViewProductos.Size = New System.Drawing.Size(228, 100)
        Me.ListViewProductos.TabIndex = 4
        Me.ListViewProductos.View = System.Windows.Forms.View.Details
        '
        'FormPrestamosDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(242, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Menu = Me.MainMenu1
        Me.Name = "FormPrestamosDetalle"
        Me.Text = "Amesol Route"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "VARIABLES"
    Private sTransProdId As String = String.Empty
    Private oVista As Vista
    Private bFin As Boolean = False
    Private iCantidadTmp As Integer = 0
    Private sClienteClave As String = String.Empty
    Private bHayCambios As Boolean = False
    Private oArr As ArrayList
    'Private bEditable As Boolean = True
#End Region

#Region "PROPIEDADES"
    Public Property Transaccion() As SqlServerCe.SqlCeTransaction
        Get
            Return odbVen.Transaccion
        End Get
        Set(ByVal Value As SqlServerCe.SqlCeTransaction)
            odbVen.Transaccion = Value
        End Set
    End Property
#End Region


#Region "METODOS"
    Private Sub LlenarLV()
        oVista.PoblarListView(Me.ListViewProductos, odbVen, "ListViewProductos", " AND V.ClienteClave='" & sClienteClave & "' AND TPD.Promocion=0 AND TP.TransProdId='" & sTransProdId & "'")
    End Sub

    Private Sub DarFormatoFlexGrid(ByRef prFlexGrid As C1.Win.C1FlexGrid.C1FlexGrid)
        With prFlexGrid
            .ClipSeparators = vbTab + vbLf
            .Cols.Count = 5
            .Cols.Fixed = 0
            .Cols(0).Name = ""
            .Cols(0).DataType = GetType(Boolean)
            .Cols(0).Width = 18
            .Cols(1).Name = "ProductoClave"
            .Cols(1).Caption = oVista.BuscarMensaje("FlexGridDetalle", "ProductoClave")
            .Cols(1).Width = 50
            .Cols(1).AllowEditing = False
            .Cols(2).Name = "Nombre"
            .Cols(2).Caption = oVista.BuscarMensaje("FlexGridDetalle", "Nombre")
            .Cols(2).Width = 150
            .Cols(2).AllowEditing = False
            .Cols(3).Name = "Cantidad"
            .Cols(3).Caption = oVista.BuscarMensaje("FlexGridDetalle", "Cantidad")
            .Cols(3).Width = 50
            .Cols(3).AllowEditing = False
            .Cols(3).EditMask = "9999"
            .Cols(4).Name = "Factor"
            .Cols(4).Visible = False
            .Rows.Count = 1
        End With
    End Sub

    Private Sub MostrarProductosContenidos(ByVal iIndice As Integer)
        Dim sTPDId As String = Me.ListViewProductos.Items(iIndice).SubItems(4).Text
        'Dim sQuery As String = "SELECT PD.ProductoDetClave, P.Nombre, (TPD.Cantidad * PD.Factor) as Cantidad FROM ProductoDetalle as PD, Producto as P, TransProdDetalle as TPD WHERE TPD.TransProdId='" & sTransProdId & "' AND TPD.TransprodDetalleId='" & sTPDId & "' AND TPD.ProductoClave=PD.ProductoClave AND TPD.TipoUnidad=PD.PRUTipoUnidad AND PD.ProductoDetClave=P.ProductoClave AND PD.Prestamo=1 AND PD.ProductoDetClave <> PD.ProductoClave"
        Dim sQuery As String = "SELECT PD.ProductoDetClave, P.Nombre, TPD.Cantidad as Cantidad, PD.Factor as Factor FROM ProductoDetalle as PD, Producto as P, TransProdDetalle as TPD WHERE TPD.TransProdId='" & sTransProdId & "' AND TPD.TransprodDetalleId='" & sTPDId & "' AND TPD.ProductoClave=PD.ProductoClave AND TPD.TipoUnidad=PD.PRUTipoUnidad AND PD.ProductoDetClave=P.ProductoClave AND PD.Prestamo=1 AND PD.ProductoDetClave <> PD.ProductoClave"
        Dim oDT As DataTable = odbVen.RealizarConsultaSQL(sQuery, "ProductoDetalle")
        For Each oDr As DataRow In oDT.Rows
            With Me.FlexGridDetalle
                .AddItem(vbTab + oDr("ProductoDetClave").ToString + vbTab + oDr("Nombre").ToString + vbTab + oDr("Cantidad").ToString + vbTab + oDr("Factor").ToString)
            End With
        Next
        oDT.Dispose()
    End Sub

    Private Sub LimpiarFlexGrid()
        Try
            Me.FlexGridDetalle.Rows.Count = 1
            Me.FlexGridDetalle.Refresh()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub AplicaPrestamo(ByVal sTransProdDetalleId As String, ByVal sProductoClave As String, ByVal iTipoUnidad As Integer, ByVal sProductoDetClave As String, ByVal iCantidad As Integer, ByVal pvFactor As Integer, ByVal bChecked As Boolean)
        Dim sPPRId As String = String.Empty
        Dim sQuery As String = String.Empty
        Dim iSaldoActual As Integer = oDBVen.RealizarConsultaSQL("Select SaldoPrestamo from cliente where clienteclave='" & sClienteClave & "'", "bla").Rows(0)(0)
        If Me.ExistePrestamo(sTransProdDetalleId, sProductoClave, iTipoUnidad, sProductoDetClave, sPPRId) Then
            If iCantidad = 0 OrElse Not bChecked Then
                sQuery = "DELETE FROM ProductoPrestamo where PPRId='" & sPPRId & "'"
                oDBVen.EjecutarComandoSQL(sQuery)
                sQuery = "UPDATE Cliente SET SaldoPrestamo=" & (iSaldoActual - (iCantidad * pvFactor)) & ",Enviado=0, MFechaHora =" & UniFechaSQL(Now) & ",MUsuarioID='" & oVendedor.UsuarioId & "' WHERE ClienteClave='" & sClienteClave & "'"
            ElseIf iCantidad > 0 Then
                sQuery = "SELECT Cantidad FROM ProductoPrestamo WHERE PPRId='" & sPPRId & "'"
                Dim iCantidad2 As Integer = oDBVen.RealizarConsultaSQL(sQuery, "Cantidad").Rows(0)(0)
                sQuery = "UPDATE ProductoPrestamo SET Cantidad=" & iCantidad & ", CantidadPrestada= " & iCantidad & ",Enviado=0,MfechaHora=" & UniFechaSQL(Now) & ",MUsuarioID='" & oVendedor.UsuarioId & "' WHERE PPRId='" & sPPRId & "'"
                oDBVen.EjecutarComandoSQL(sQuery)
                sQuery = "UPDATE Cliente SET SaldoPrestamo=" & iSaldoActual + ((iCantidad * pvFactor) - (iCantidad2 * pvFactor)) & ",Enviado=0, MFechaHora =" & UniFechaSQL(Now) & ",MUsuarioID='" & oVendedor.UsuarioId & "' WHERE ClienteClave='" & sClienteClave & "'"
            End If
        Else
            sQuery = "INSERT INTO ProductoPrestamo VALUES('" & sTransProdId & "','" & sTransProdDetalleId & "','" & sProductoClave & "'," & iTipoUnidad & ",'" & sProductoDetClave & "','" & oApp.KEYGEN(0) & "'," & iCantidad & "," & iCantidad & "," & UniFechaSQL(Now) & ",'" & oVendedor.UsuarioId & "',0,0)"
            oDBVen.EjecutarComandoSQL(sQuery)
            sQuery = "UPDATE Cliente SET SaldoPrestamo=" & (iSaldoActual + (iCantidad * pvFactor)) & ",Enviado=0, MFechaHora =" & UniFechaSQL(Now) & ",MUsuarioID='" & oVendedor.UsuarioId & "' WHERE ClienteClave='" & sClienteClave & "'"
        End If
        oDBVen.EjecutarComandoSQL(sQuery)
    End Sub

    Private Sub LlenarCheckBoxes(ByVal iIndice As Integer)
        Dim sTPDId As String = Me.ListViewProductos.Items(iIndice).SubItems(4).Text
        With Me.FlexGridDetalle
            For i As Integer = 1 To .Rows.Count - 1
                Dim iCantidad As Integer = 0
                If Me.ExistePrestamo(sTPDId, Me.ListViewProductos.Items(iIndice).SubItems(3).Text, Me.ObtenerTipoUnidadProducto(sTPDId), .Item(i, 1), "", iCantidad) Then
                    .Item(i, 0) = True
                    .Item(1, 3) = iCantidad
                End If
                'Me.AplicaPrestamo(sTPDId, Me.ListViewProductos.Items(Me.ListViewProductos.SelectedIndices(0)).Text, Me.ObtenerTipoUnidadProducto(sTPDId), .Item(e.Row, 1), .Item(e.Row, 3))
            Next
        End With
    End Sub

    Private Sub Cancelar()
        If bHayCambios Then
            If MsgBox(oVista.BuscarMensaje("Mensajes", "Cancelar"), MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Transaccion.Rollback()
            Else
                Exit Sub
            End If
        End If
        Transaccion.Dispose()
        Me.Close()
    End Sub

    Private Sub PPRIdExistentes()
        oArr = New ArrayList
        Dim oDt As DataTable = odbVen.RealizarConsultaSQL("SELECT PPRId FROM ProductoPrestamo WHERE TransProdId='" & sTransProdId & "'", "ABPIdPrestados")
        For Each oDr As DataRow In oDt.Rows
            oArr.Add(oDr("PPRId"))
        Next
        oDt.Dispose()
    End Sub
#End Region

#Region "FUNCIONES"
    Private Function ValidaCantidad(ByVal sProductoDetClave As String, ByVal iCantidad As Integer, ByVal iTipoUnidad As Integer) As Boolean
        If iCantidad < 0 OrElse iCantidad > Me.ObtenerCantidadMaxima(sProductoDetClave, iTipoUnidad) Then
            Return False
        End If
        Return True
    End Function

    Private Function ObtenerCantidadMaxima(ByVal sProductoDetClave As String, ByVal iTipoUnidad As Integer) As Integer
        Dim sTPDId As String = Me.ListViewProductos.Items(Me.ListViewProductos.SelectedIndices(0)).SubItems(4).Text
        'Dim sQuery As String = "Select (TPD.Cantidad * PD.Factor) FROM TransProdDetalle as TPD, ProductoDetalle as PD WHERE TPD.TransProdDetalleId='" & sTPDId & "' AND TPD.ProductoClave=PD.ProductoClave AND TPD.TipoUnidad=PD.PRUTipoUnidad AND PD.PRUTipoUnidad=" & iTipoUnidad & " AND PD.ProductoDetClave='" & sProductoDetClave & "' AND TPD.TransProdID='" & sTransProdId & "'"
        Dim sQuery As String = "Select TPD.Cantidad FROM TransProdDetalle as TPD, ProductoDetalle as PD WHERE TPD.TransProdDetalleId='" & sTPDId & "' AND TPD.ProductoClave=PD.ProductoClave AND TPD.TipoUnidad=PD.PRUTipoUnidad AND PD.PRUTipoUnidad=" & iTipoUnidad & " AND PD.ProductoDetClave='" & sProductoDetClave & "' AND TPD.TransProdID='" & sTransProdId & "'"
        Dim oDt As DataTable = oDBVen.RealizarConsultaSQL(sQuery, "Cantidad")
        Dim nCantidad As Integer = oDt.Rows(0)(0)
        oDt.Dispose()
        Return nCantidad
    End Function

    Private Function ExistePrestamo(ByVal sTransProdDetalleId As String, ByVal sProductoClave As String, ByVal iTipoUnidad As Integer, ByVal sProductoDetClave As String, ByRef sPPRId As String, Optional ByRef iCantidad As Integer = 0) As Boolean
        Dim sQuery As String = "SELECT PPRId,Cantidad FROM ProductoPrestamo WHERE TransProdId='" & sTransProdId & "' AND TransProdDetalleId='" & sTransProdDetalleId & "' and ProductoClave='" & sProductoClave & "' and PRUTipoUnidad=" & iTipoUnidad & " and ProductoDetClave='" & sProductoDetClave & "'"
        Dim oDt As DataTable = odbVen.RealizarConsultaSQL(sQuery, "Tabla")
        If oDt.Rows.Count = 0 Then
            oDt.Dispose()
            Return False
        Else
            sPPRId = oDt.Rows(0)(0)
            iCantidad = oDt.Rows(0)(1)
            oDt.Dispose()
            Return True
        End If
    End Function

    Private Function ObtenerTipoUnidadProducto(ByVal sTransProdDetalleId As String) As Integer
        Dim oDT As DataTable = oDBVen.RealizarConsultaSQL("SELECT TipoUnidad FROM transproddetalle where transprodid='" & sTransProdId & "' and transproddetalleid='" & sTransProdDetalleId & "'", "Transproddetalle")
        Dim nTipoUnidad As Integer = oDT.Rows(0)(0)
        oDT.Dispose()
        Return nTipoUnidad
    End Function
#End Region

#Region "EVENTOS"

    Private Sub FormPrestamosDetalle_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        If Not Me.FlexGridDetalle Is Nothing Then
            If oVendedor.motconfiguracion.Secuencia Then
                If Not ctrlSeguimiento.Parent Is Nothing Then
                    RemoveHandler ctrlSeguimiento.NuevaSeleccion, AddressOf TerminarVisita
                    RemoveHandler ctrlSeguimiento.TerminarVisitaMenu, AddressOf TerminarVisita
                    ctrlSeguimiento.QuitarMenuItem(Me.MainMenu1)
                    Me.Controls.Remove(ctrlSeguimiento)
                End If
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

        If Not Me.Transaccion Is Nothing Then Me.Transaccion.Dispose()
        Me.Transaccion = Nothing
    End Sub

    Private Sub FormPrestamosDetalle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor.Current = Cursors.WaitCursor
        [Global].ObtenerFactores(Me)

        If oVendedor.motconfiguracion.Secuencia Then
            ctrlSeguimiento.AgregarControl(Me)
            Me.Panel1.SendToBack()
            ctrlSeguimiento.CrearMenuItem(Me.MainMenu1)
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

        If odbVen.oConexion.State = ConnectionState.Closed Then
            odbVen.oConexion.Open()
        End If
        Transaccion = odbVen.oConexion.BeginTransaction
        Me.ListViewProductos.Activation = oApp.TipoSeleccion
        If Not Vista.Buscar("FormPrestamosDetalle", oVista) Then
            Cursor.Current = Cursors.Default
            Exit Sub
        End If
        oVista.CrearListView(Me.ListViewProductos, "ListViewProductos")
        LlenarLV()
        oVista.ColocarEtiquetasForma(Me)
        Me.DarFormatoFlexGrid(Me.FlexGridDetalle)
        Me.PPRIdExistentes()
        bFin = True
        Cursor.Current = Cursors.Default

        With ListViewProductos
            If .Items.Count > 0 Then
                .Items(0).Selected = True
                .Focus()
            End If
        End With
        [Global].HabilitarMenuItem(Me.MainMenu1, True)
    End Sub

    Private Sub TerminarVisita()
        MenuItemCancelar_Click(Nothing, Nothing)
    End Sub


    Private Sub ButtonRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancelar.Click
        Me.Cancelar()
    End Sub

    Private Sub ListViewProductos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListViewProductos.SelectedIndexChanged
        If Not bFin Then Exit Sub
        Try
            Me.LimpiarFlexGrid()
            If Me.ListViewProductos.SelectedIndices.Count > 0 Then
                Dim iIndex As Integer = Me.ListViewProductos.SelectedIndices(0)
                Me.MostrarProductosContenidos(iIndex)
                Me.LlenarCheckBoxes(iIndex)
            End If
        Catch ex As SqlServerCe.SqlCeException
            MsgBox(ex.Message, MsgBoxStyle.Information, "SQL Exception")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Exception")
        End Try
    End Sub

    Private Sub FlexGridDetalle_AfterEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles FlexGridDetalle.AfterEdit
        If Not bFin Then Exit Sub
        With Me.FlexGridDetalle
            Dim sTPDId As String = Me.ListViewProductos.Items(Me.ListViewProductos.SelectedIndices(0)).SubItems(4).Text
            If e.Col = 0 Then
                'If Not bEditable Then Exit Sub
                If .Item(e.Row, e.Col) = True Then
                    Me.AplicaPrestamo(sTPDId, Me.ListViewProductos.Items(Me.ListViewProductos.SelectedIndices(0)).SubItems(3).Text, Me.ObtenerTipoUnidadProducto(sTPDId), .Item(e.Row, 1), .Item(e.Row, 3), .Item(e.Row, 4), True)
                Else
                    Me.AplicaPrestamo(sTPDId, Me.ListViewProductos.Items(Me.ListViewProductos.SelectedIndices(0)).SubItems(3).Text, Me.ObtenerTipoUnidadProducto(sTPDId), .Item(e.Row, 1), .Item(e.Row, 3), .Item(e.Row, 4), False)
                End If
                bHayCambios = True
            ElseIf e.Col = 3 Then
                If Trim(.Item(e.Row, e.Col)) = "" Then
                    MsgBox(oVista.BuscarMensaje("Mensaje", "E0012"), MsgBoxStyle.Information)
                    .StartEditing(e.Row, e.Col)
                    Exit Sub
                ElseIf Not Me.ValidaCantidad(.Item(e.Row, 1), .Item(e.Row, e.Col), Me.ObtenerTipoUnidadProducto(sTPDId)) Then
                    MsgBox("La cantidad a prestar para este artículo no puede ser menor de 0 ó mayor a " & Me.ObtenerCantidadMaxima(.Item(e.Row, 1), Me.ObtenerTipoUnidadProducto(sTPDId)), MsgBoxStyle.Information)
                    e.Cancel = True
                    .Item(e.Row, e.Col) = iCantidadTmp
                    Exit Sub
                End If
                Me.AplicaPrestamo(sTPDId, Me.ListViewProductos.Items(Me.ListViewProductos.SelectedIndices(0)).SubItems(3).Text, Me.ObtenerTipoUnidadProducto(sTPDId), .Item(e.Row, 1), .Item(e.Row, 3), .Item(e.Row, 4), True)
                bHayCambios = True
            End If
        End With
    End Sub

    Private Sub FlexGridDetalle_EnterCell(ByVal sender As Object, ByVal e As System.EventArgs) Handles FlexGridDetalle.EnterCell
        If Not bFin Then Exit Sub
        With Me.FlexGridDetalle
            If .Col = 3 Then
                If Trim(.Item(.Row, 3)) <> "" Then
                    If .Item(.Row, 0) = True Then
                        .Cols(3).AllowEditing = True
                        iCantidadTmp = .Item(.Row, 3)
                    Else
                        .Cols(3).AllowEditing = False
                    End If
                End If
            End If
        End With
    End Sub

    Private Sub ButtonAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAceptar.Click
        Transaccion.Commit()
        Transaccion.Dispose()
        Me.Close()
    End Sub

    Private Sub MenuItemCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemCancelar.Click
        Me.Cancelar()
    End Sub
#End Region

    Private Sub FlexGridDetalle_ValidateEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.ValidateEditEventArgs) Handles FlexGridDetalle.ValidateEdit
        If Not bFin Then Exit Sub
        With Me.FlexGridDetalle
            'bEditable = True
            If .Col = 0 Then
                Dim sPPRId As String = String.Empty
                Dim iIndice As Integer = Me.ListViewProductos.SelectedIndices(0)
                Dim sTPDId As String = Me.ListViewProductos.Items(iIndice).SubItems(4).Text
                Me.ExistePrestamo(sTPDId, Me.ListViewProductos.Items(iIndice).SubItems(3).Text, Me.ObtenerTipoUnidadProducto(sTPDId), .Item(.Row, 1), sPPRId)
                If oArr.Contains(sPPRId) Then
                    'bEditable = False
                    e.Cancel = True
                End If
            End If
        End With
    End Sub
End Class
