Public Class FormAbonoProgramadoDetalle
    Inherits System.Windows.Forms.Form
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents MenuItemRegresar As System.Windows.Forms.MenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents FlexGrid As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents ButtonRegresar As System.Windows.Forms.Button
    Friend WithEvents ButtonContinuar As System.Windows.Forms.Button
    Dim bSaliendo As Boolean

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal pvVisitaClave As String, ByVal pvModo As eModo, Optional ByVal pvABPId As String = "")
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        If g_SO = SO.WindowsCE Then
            Call InTheHand.Windows.Forms.ContextMenuHelper.HookAllControls(Me.Controls)
        End If
        'Add any initialization after the InitializeComponent() call
        'oVista = pvVista
        oModo = pvModo
        sVisitaClave = pvVisitaClave
        sABPId = pvABPId
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If Not Me.MenuItemEliminar Is Nothing Then Me.MenuItemEliminar.Dispose()
        If Not Me.MenuItemRegresar Is Nothing Then Me.MenuItemRegresar.Dispose()
        If Not Me.MainMenu1 Is Nothing Then Me.MainMenu1.Dispose()
        If Not Me.ContextMenu1 Is Nothing Then Me.ContextMenu1.Dispose()
        If Not Me.FlexGrid Is Nothing Then Me.FlexGrid.Dispose()
        Me.FlexGrid = Nothing
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents ContextMenu1 As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItemEliminar As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormAbonoProgramadoDetalle))
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.MenuItemRegresar = New System.Windows.Forms.MenuItem
        Me.ContextMenu1 = New System.Windows.Forms.ContextMenu
        Me.MenuItemEliminar = New System.Windows.Forms.MenuItem
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.FlexGrid = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.ButtonRegresar = New System.Windows.Forms.Button
        Me.ButtonContinuar = New System.Windows.Forms.Button
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.Add(Me.MenuItemRegresar)
        '
        'MenuItemRegresar
        '
        Me.MenuItemRegresar.Text = "MenuItemRegresar"
        '
        'ContextMenu1
        '
        Me.ContextMenu1.MenuItems.Add(Me.MenuItemEliminar)
        '
        'MenuItemEliminar
        '
        Me.MenuItemEliminar.Text = "MenuItemEliminar"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.FlexGrid)
        Me.Panel1.Controls.Add(Me.ButtonRegresar)
        Me.Panel1.Controls.Add(Me.ButtonContinuar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(242, 295)
        '
        'FlexGrid
        '
        Me.FlexGrid.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.FlexGrid.AllowEditing = True
        Me.FlexGrid.AutoResize = True
        Me.FlexGrid.AutoSearchDelay = 1
        Me.FlexGrid.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.FlexGrid.Clip = ""
        Me.FlexGrid.ClipSeparators = "" & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(13)
        Me.FlexGrid.Col = 0
        Me.FlexGrid.ColSel = 0
        Me.FlexGrid.ComboList = Nothing
        Me.FlexGrid.ContextMenu = Me.ContextMenu1
        Me.FlexGrid.EditMask = Nothing
        Me.FlexGrid.ExtendLastCol = False
        Me.FlexGrid.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
        Me.FlexGrid.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.FlexGrid.LeftCol = 1
        Me.FlexGrid.Location = New System.Drawing.Point(4, 17)
        Me.FlexGrid.Name = "FlexGrid"
        Me.FlexGrid.Redraw = True
        Me.FlexGrid.Row = 0
        Me.FlexGrid.RowSel = 0
        Me.FlexGrid.ScrollPosition = New System.Drawing.Point(0, 0)
        Me.FlexGrid.ScrollTrack = True
        Me.FlexGrid.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.FlexGrid.ShowCursor = False
        Me.FlexGrid.ShowSort = True
        Me.FlexGrid.Size = New System.Drawing.Size(231, 244)
        Me.FlexGrid.StyleInfo = resources.GetString("FlexGrid.StyleInfo")
        Me.FlexGrid.SupportInfo = "fwCTAZsBwgCBAFMBUQD/AK8AUwEsAfkAIwGtAPsA3ABNAPEA3ACYADsAtgCOAHsAYAD2ABMB"
        Me.FlexGrid.TabIndex = 3
        Me.FlexGrid.TopRow = 1
        '
        'ButtonRegresar
        '
        Me.ButtonRegresar.Location = New System.Drawing.Point(83, 265)
        Me.ButtonRegresar.Name = "ButtonRegresar"
        Me.ButtonRegresar.Size = New System.Drawing.Size(72, 24)
        Me.ButtonRegresar.TabIndex = 4
        Me.ButtonRegresar.Text = "ButtonRegresar"
        '
        'ButtonContinuar
        '
        Me.ButtonContinuar.Location = New System.Drawing.Point(3, 265)
        Me.ButtonContinuar.Name = "ButtonContinuar"
        Me.ButtonContinuar.Size = New System.Drawing.Size(72, 24)
        Me.ButtonContinuar.TabIndex = 5
        Me.ButtonContinuar.Text = "ButtonContinuar"
        '
        'FormAbonoProgramadoDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(242, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Menu = Me.MainMenu1
        Me.Name = "FormAbonoProgramadoDetalle"
        Me.Text = "Amesol Route"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


#Region "VARIABLES"
    Private oVista As Vista
    Private oModo As eModo
    Private sVisitaClave As String = String.Empty
    Private sABPId As String = String.Empty
    Private bHayCambios As Boolean = False
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
    Private Sub DarFormatoFlexGrid()
        With Me.FlexGrid
            .Cols.Fixed = 0
            .Rows.Count = 1
            .Cols.Count = 3

            .Cols(0).DataType = GetType(Date)
            .Cols(0).EditMask = "99/99/9999"
            '.Cols(0).Format = "dd/MM/yyyy"
            .Cols(0).Width = 110
            .Cols(0).Caption = oVista.BuscarMensaje("Mensajes", "FechaPromesa")
            .Cols(1).DataType = GetType(Double)
            .Cols(1).Format = "c"
            .Cols(1).Width = 110
            .Cols(1).TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.RightCenter
            .Cols(1).Caption = oVista.BuscarMensaje("Mensajes", "Importe")
            .Cols(2).Visible = False
        End With
    End Sub

    Private Sub LlenarGrid()
        Dim oDT As DataTable = odbVen.RealizarConsultaSQL("SELECT FechaPromesa, Importe, ABPId FROM AbonoProgramado WHERE ABPId='" & sABPId & "'", "LlenarGrid")
        For Each oDr As DataRow In oDT.Rows
            Me.FlexGrid.AddItem(oDr("FechaPromesa").ToString + vbTab + oDr("Importe").ToString + vbTab + oDr("ABPId").ToString)
        Next
        oDT.Dispose()
    End Sub

    Private Sub CrearNuevaFila(ByRef FG As C1.Win.C1FlexGrid.C1FlexGrid)
        FG.Rows.Count = FG.Rows.Count + 1
        FG.Row = FG.Rows.Count - 1
        FG.Item(FG.Row, 2) = oApp.KEYGEN(FG.Row)
        FG.Col = 0
        'FG.StartEditing()
    End Sub

    Private Sub GuardaAbono(ByVal pvFechaPromesa As Date, ByVal pvImporte As Double, ByVal pvABPId As String, ByVal pvSA As eStatusAbono)
        Dim sQuery As String = String.Empty
        If pvSA = eStatusAbono.Nuevo Then
            sQuery = "INSERT INTO AbonoProgramado VALUES('" & pvABPId & "','" & sVisitaClave & "','" & oDia.DiaActual & "', null ," & UniFechaSQL(pvFechaPromesa) & "," & CDbl(pvImporte) & "," & UniFechaSQL(Now) & ",'" & oVendedor.UsuarioId & "',0,0)"
        Else
            sQuery = "UPDATE AbonoProgramado SET FechaPromesa=" & UniFechaSQL(pvFechaPromesa) & ", Importe=" & CDbl(pvImporte) & ", MFechaHora=" & UniFechaSQL(Now) & ", MUsuarioId='" & oVendedor.VendedorId & "',Enviado=0 WHERE ABPId='" & pvABPId & "'"
        End If
        odbVen.EjecutarComandoSQL(sQuery)
    End Sub

    Private Sub EliminarAbono(ByVal pvABPId As String)
        Dim sQuery As String = "DELETE FROM AbonoProgramado WHERE ABPId='" & pvABPId & "'"
        odbVen.EjecutarComandoSQL(sQuery)
        bHayCambios = True
    End Sub

    Private Sub Regresar()
        If bHayCambios Then
            If MsgBox(oVista.BuscarMensaje("Mensajes", "BP0002"), MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        Transaccion.Rollback()
        Transaccion.Dispose()
        Me.Close()
    End Sub
#End Region

#Region "FUNCIONES"
    Private Function EsUltimaFila(ByVal pvIndice As Integer) As Boolean
        Return IIf(pvIndice = Me.FlexGrid.Rows.Count - 1, True, False)
    End Function

    Private Function ExisteAbonoProgramado(ByVal pvABPId As String) As Boolean
        Return odbVen.RealizarConsultaSQL("SELECT ABPId FROM AbonoProgramado WHERE ABPId='" & pvABPId & "'", "ExisteAbonoProgramado").Rows.Count > 0
    End Function

    Private Function UltimaFilaVacia() As Boolean
        With Me.FlexGrid
            If .Item(.Rows.Count - 1, 1) = "" Then
                Return True
            End If
            Return False
        End With
    End Function
#End Region

#Region "EVENTOS"

    Private Sub FormAbonoProgramadoDetalle_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
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

        If Not Me.Transaccion Is Nothing Then Me.Transaccion.Dispose()
        Me.Transaccion = Nothing
    End Sub
    Private Sub FormAbonoProgramadoDetalle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
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

        Me.Visible = False
        If Not Vista.Buscar("FormAbonoProgramadoDetalle", oVista) Then
            Exit Sub
        End If
        oVista.ColocarEtiquetasForma(Me)
        Me.DarFormatoFlexGrid()
        If oModo <> eModo.Nuevo Then
            LlenarGrid()
        End If
        Me.CrearNuevaFila(Me.FlexGrid)
        'Me.FlexGrid.StartEditing()
        If odbVen.oConexion.State = ConnectionState.Closed Then
            oDBVen.oConexion.Open()
        End If
        Transaccion = oDBVen.oConexion.BeginTransaction
        Me.Visible = True
        [Global].HabilitarMenuItem(MainMenu1, True)
        Cursor.Current = System.Windows.Forms.Cursors.Default

        Me.FlexGrid.Focus()

    End Sub

    Private Sub TerminarVisita()
        MenuItemRegresar_Click(Nothing, Nothing)
    End Sub

    Private Sub FlexGrid_AfterEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles FlexGrid.AfterEdit

        With Me.FlexGrid
            If e.Col = 0 Then
                If Not .Item(e.Row, e.Col) Is Nothing Then
                    If IsDate(.Item(e.Row, e.Col)) Then
                        If DateDiff(DateInterval.Day, PrimeraHora(Now), .Item(e.Row, e.Col)) < 0 Then
                            MsgBox(Replace(oVista.BuscarMensaje("Mensajes", "E0352"), "$0$", oVista.BuscarMensaje("Mensajes", "XFechaDiaTrabajo")), MsgBoxStyle.Information)
                            e.Cancel = True
                            .Row = e.Row
                            .Col = e.Col
                            .StartEditing()
                        End If
                    Else
                        MsgBox(Replace(oVista.BuscarMensaje("Mensajes", "E0352"), "$0$", oVista.BuscarMensaje("Mensajes", "XFechaDiaTrabajo")), MsgBoxStyle.Information)
                        e.Cancel = True
                        .Row = e.Row
                        .Col = e.Col
                        .StartEditing()
                    End If
                End If
            ElseIf e.Col = 1 Then
                If .Item(e.Row, e.Col) Is Nothing Then
                    MsgBox(SustituyeCampo(oVista.BuscarMensaje("Mensajes", "BE0001"), .Cols(1).Caption), MsgBoxStyle.Information)
                    e.Cancel = True
                    .Row = e.Row
                    .Col = e.Col
                    .StartEditing()
                ElseIf .Item(e.Row, e.Col) > 0 Then
                    If Me.ExisteAbonoProgramado(.Item(e.Row, 2)) Then
                        Me.GuardaAbono(.Item(e.Row, 0), .Item(e.Row, 1), .Item(e.Row, 2), eStatusAbono.Existente)
                    Else
                        Me.GuardaAbono(.Item(e.Row, 0), .Item(e.Row, 1), .Item(e.Row, 2), eStatusAbono.Nuevo)
                    End If
                    If Me.EsUltimaFila(e.Row) Then
                        Me.CrearNuevaFila(Me.FlexGrid)
                    End If
                    bHayCambios = True
                Else
                    MsgBox(oVista.BuscarMensaje("Mensajes", "E0012"), MsgBoxStyle.Information)
                    e.Cancel = True
                    .Row = e.Row
                    .Col = e.Col
                    .StartEditing()
                End If
            End If
        End With
    End Sub

    Private Sub FlexGrid_EnterCell(ByVal sender As Object, ByVal e As System.EventArgs) Handles FlexGrid.EnterCell
        With Me.FlexGrid
            If oModo <> eModo.Eliminar Then
                If .Col = 1 AndAlso .Item(.Row, 0) Is Nothing Then
                    .Cols(.Col).AllowEditing = False
                Else
                    .Cols(.Col).AllowEditing = True
                End If
            Else
                .Cols(.Col).AllowEditing = False
            End If
        End With
    End Sub

    Private Sub ButtonRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRegresar.Click
        Regresar()
    End Sub

    Private Sub MenuItemRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemRegresar.Click
        Regresar()
    End Sub

    Public Function Verificar_Informacion() As Boolean

        Dim cont As Integer

        With Me.FlexGrid
            For cont = 1 To .Rows.Count - 1

                If IsDate(.Item(cont, 0)) Then
                    If DateDiff(DateInterval.Day, PrimeraHora(Now), .Item(cont, 0)) < 0 Then
                        MsgBox(Replace(oVista.BuscarMensaje("Mensajes", "E0352"), "$0$", oVista.BuscarMensaje("Mensajes", "XFechaDiaTrabajo")), MsgBoxStyle.Information)
                        .Row = cont
                        .Col = 0
                        '.StartEditing()
                        Return False
                    End If

                    If .Item(cont, 1) Is Nothing OrElse .Item(cont, 1) <= 0 Then
                        MsgBox(SustituyeCampo(oVista.BuscarMensaje("Mensajes", "BE0001"), .Cols(1).Caption), MsgBoxStyle.Information)
                        .Row = cont
                        .Col = 1
                        '.StartEditing()
                        Return False
                    End If
                End If
            Next

        End With

        Return True

    End Function

    Private Sub ButtonContinuar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonContinuar.Click
        Try
            If Not Verificar_Informacion() Then
                Exit Sub
            End If

            If oModo = eModo.Eliminar Then
                For i As Integer = 1 To Me.FlexGrid.Rows.Count - 1
                    Me.EliminarAbono(Me.FlexGrid.Item(i, 2))
                Next
            End If
            Transaccion.Commit()
        Catch ex As Exception
            Transaccion.Rollback()
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        Transaccion.Dispose()
        Me.Close()
    End Sub

    Private Sub ContextMenu1_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles ContextMenu1.Popup
        Me.MenuItemEliminar.Enabled = False
        If oModo = eModo.Eliminar Then Exit Sub
        If Me.FlexGrid.Rows.Count > 1 AndAlso Me.FlexGrid.RowSel > 0 AndAlso Not Me.EsUltimaFila(Me.FlexGrid.Row) Then
            Me.MenuItemEliminar.Enabled = True
        End If
    End Sub

    Private Sub MenuItemEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuItemEliminar.Click
        Me.EliminarAbono(Me.FlexGrid.Item(Me.FlexGrid.Row, 2))
        Me.FlexGrid.RemoveItem(Me.FlexGrid.Row)
    End Sub
#End Region

    Public Enum eModo
        Nuevo = 1
        Modificar = 2
        Eliminar = 3
    End Enum

    Private Enum eStatusAbono
        Nuevo = 1
        Existente = 2
    End Enum

    Private Sub FlexGrid_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles FlexGrid.LostFocus
        bSaliendo = True
    End Sub

    Private Sub FlexGrid_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles FlexGrid.GotFocus
        bSaliendo = False
    End Sub

    Private Sub ButtonRegresar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonRegresar.GotFocus
        bSaliendo = False
    End Sub

    'Private Sub FlexGrid_GridError(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.GridErrorEventArgs) Handles FlexGrid.GridError
    '    MsgBox(e.Exception.Message)
    'End Sub

End Class
