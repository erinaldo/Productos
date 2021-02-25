Public Class FormActivos
    Inherits System.Windows.Forms.Form
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal paroCliente As Cliente, ByVal parsVisitaClave As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        oCliente = paroCliente
        VisitaClave = parsVisitaClave
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        Me.QuitarCtrlSeguimiento()

        If Not Me.MenuItemRegresar Is Nothing Then
            Me.MenuItemRegresar.Dispose()
            Me.MenuItemRegresar = Nothing
        End If

        If Not Me.MainMenu1 Is Nothing Then
            Me.MainMenu1.Dispose()
            Me.MainMenu1 = Nothing
        End If

        If Me.ListViewActivos.Columns.Count > 0 Then
            Me.ListViewActivos.Columns.Clear()
        End If
#If MOD_TERM <> "PALM" Then
        If Not bScanner Is Nothing Then bScanner.Dispose()
        bScanner = Nothing
#End If
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.MenuItemRegresar = New System.Windows.Forms.MenuItem
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.TextBoxIDElectronico = New System.Windows.Forms.TextBox
        Me.ButtonTransferir = New System.Windows.Forms.Button
        Me.ButtonAsignar = New System.Windows.Forms.Button
        Me.ButtonRegresar = New System.Windows.Forms.Button
        Me.ButtonContinuar = New System.Windows.Forms.Button
        Me.ListViewActivos = New System.Windows.Forms.ListView
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
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TextBoxIDElectronico)
        Me.Panel1.Controls.Add(Me.ButtonTransferir)
        Me.Panel1.Controls.Add(Me.ButtonAsignar)
        Me.Panel1.Controls.Add(Me.ButtonRegresar)
        Me.Panel1.Controls.Add(Me.ButtonContinuar)
        Me.Panel1.Controls.Add(Me.ListViewActivos)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(242, 295)
        '
        'TextBoxIDElectronico
        '
        Me.TextBoxIDElectronico.Location = New System.Drawing.Point(5, 215)
        Me.TextBoxIDElectronico.Name = "TextBoxIDElectronico"
        Me.TextBoxIDElectronico.Size = New System.Drawing.Size(229, 21)
        Me.TextBoxIDElectronico.TabIndex = 11
        '
        'ButtonTransferir
        '
        Me.ButtonTransferir.Location = New System.Drawing.Point(6, 266)
        Me.ButtonTransferir.Name = "ButtonTransferir"
        Me.ButtonTransferir.Size = New System.Drawing.Size(72, 24)
        Me.ButtonTransferir.TabIndex = 6
        Me.ButtonTransferir.Text = "ButtonTransferir"
        '
        'ButtonAsignar
        '
        Me.ButtonAsignar.Location = New System.Drawing.Point(162, 240)
        Me.ButtonAsignar.Name = "ButtonAsignar"
        Me.ButtonAsignar.Size = New System.Drawing.Size(72, 24)
        Me.ButtonAsignar.TabIndex = 7
        Me.ButtonAsignar.Text = "ButtonAsignar"
        '
        'ButtonRegresar
        '
        Me.ButtonRegresar.Location = New System.Drawing.Point(84, 240)
        Me.ButtonRegresar.Name = "ButtonRegresar"
        Me.ButtonRegresar.Size = New System.Drawing.Size(72, 24)
        Me.ButtonRegresar.TabIndex = 8
        Me.ButtonRegresar.Text = "ButtonRegresar"
        '
        'ButtonContinuar
        '
        Me.ButtonContinuar.Location = New System.Drawing.Point(6, 240)
        Me.ButtonContinuar.Name = "ButtonContinuar"
        Me.ButtonContinuar.Size = New System.Drawing.Size(72, 24)
        Me.ButtonContinuar.TabIndex = 9
        Me.ButtonContinuar.Text = "ButtonContinuar"
        '
        'ListViewActivos
        '
        Me.ListViewActivos.CheckBoxes = True
        Me.ListViewActivos.FullRowSelect = True
        Me.ListViewActivos.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListViewActivos.Location = New System.Drawing.Point(5, 17)
        Me.ListViewActivos.Name = "ListViewActivos"
        Me.ListViewActivos.Size = New System.Drawing.Size(229, 195)
        Me.ListViewActivos.TabIndex = 10
        Me.ListViewActivos.View = System.Windows.Forms.View.Details
        '
        'FormActivos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(242, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.Menu = Me.MainMenu1
        Me.MinimizeBox = False
        Me.Name = "FormActivos"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


#Region "FormActivos"

#If MOD_TERM <> "PALM" Then
    Private Sub FormActivos_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        If Not bLectorActivo Then
            Select Case oApp.ModeloTerminal
                Case "Generico"

                Case "SymbolC9090", "SymbolMC50", "SymbolMC70"
                    Try
                        bScanner.Inicialize_Scanner(HANDHELD.SO.SymbolPCMC50)
                        bLectorActivo = True
                    Catch ex As Exception
                        MsgBox("Error while starting the scanner:" & ex.Message, MsgBoxStyle.Critical)
                    End Try
                Case "HHP7600"
                    bScanner.Inicialize_Scanner(HANDHELD.SO.HHP7600)
                    bLectorActivo = True
                Case "HHP7900"
                    bScanner.Inicialize_Scanner(HANDHELD.SO.HHP7900)
                    bLectorActivo = True
                Case "HHPWM6"
                    bScanner.Inicialize_Scanner(HANDHELD.SO.HHPWM6)
                    bLectorActivo = True
                Case "IntermecCN3"
                    bScanner.Inicialize_Scanner(HANDHELD.SO.IntermecCN3)
                    bLectorActivo = True
                Case "SymbolMC55"
                    bScanner.Inicialize_Scanner(HANDHELD.SO.SymbolMC55)
                    bLectorActivo = True
            End Select
        End If
    End Sub
#End If
    

#If MOD_TERM <> "PALM" Then
    Private Sub FormActivos_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        Try
            bScanner.Terminate_Scanner()
            bLectorActivo = False
        Catch ex As Exception
            MsgBox("Error while stopping the scanner:" & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
#End If

    Private Sub FormActivos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

        If Not Vista.Buscar("FormActivos", oVista) Then
            Cursor.Current = Cursors.Default
            Exit Sub
        End If
        oVista.ColocarEtiquetasForma(Me)
        'blnSeleccionManual = False
        oVista.CrearListView(ListViewActivos, "ListViewActivos")
        Application.DoEvents()
        LlenaLV()

        With ListViewActivos
            If .Items.Count > 0 Then
                .Items(0).Selected = True
                .Focus()
                [Global].HabilitarMenuItem(MainMenu1, True)
            Else
                Continuar()
            End If

        End With
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub TerminarVisita()
        ButtonRegresar_Click(Nothing, Nothing)
    End Sub
#End Region

#Region "VARIABLES"
    Private oVista As Vista
    Private oCliente As Cliente
    Private oValorRef As ValorReferencia
    Private VisitaClave As String
    Private blnSeleccionManual As Boolean = False
    Private ActivoClave As String
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TextBoxIDElectronico As System.Windows.Forms.TextBox
    Friend WithEvents ButtonTransferir As System.Windows.Forms.Button
    Friend WithEvents ButtonAsignar As System.Windows.Forms.Button
    Friend WithEvents ButtonRegresar As System.Windows.Forms.Button
    Friend WithEvents ButtonContinuar As System.Windows.Forms.Button
    Friend WithEvents ListViewActivos As System.Windows.Forms.ListView
    Friend WithEvents MenuItemRegresar As System.Windows.Forms.MenuItem
#If MOD_TERM <> "PALM" Then
    Private WithEvents bScanner As New HANDHELD.CScanner
#End If
    Dim bLectorActivo As Boolean = False
#End Region

#Region "METODOS"
    Private Sub LlenaLV()
        Dim qg As New System.Text.StringBuilder
        qg.Append(" and clienteclave='" & oCliente.ClienteClave & "'")
        oVista.PoblarListView(ListViewActivos, oDBVen, "ListViewActivos", qg.ToString)
    End Sub

    Private Sub Continuar()
        Me.QuitarCtrlSeguimiento()

        If HaySeleccion(ListViewActivos) Then
            ActivoClave = ObtieneActivoClave(ListViewActivos)
            Dim FAD As New FormActivosDetalle(VisitaClave, oCliente.ClienteClave, ActivoClave)
            'If FAD.ShowDialog = Windows.Forms.DialogResult.OK Then
            '    LlenaLV()
            'End If
            FAD.ShowDialog()
            FAD.Dispose()
            FAD = Nothing
            Me.Close()
        Else
            Dim FAD As New FormActivosDetalle(VisitaClave, oCliente.ClienteClave)
            'If FAD.ShowDialog = Windows.Forms.DialogResult.OK Then
            '    LlenaLV()
            'End If
            FAD.ShowDialog()
            FAD.Dispose()
            FAD = Nothing
            Me.Close()
        End If
    End Sub
#End Region

#Region "FUNCIONES"
    Private Sub AgregarCtrlSeguimiento()
        If oVendedor.motconfiguracion.Secuencia Then
            Me.Controls.Add(ctrlSeguimiento)
            Me.Panel1.SendToBack()
            ctrlSeguimiento.CrearMenuItem(Me.MainMenu1)
            AddHandler ctrlSeguimiento.NuevaSeleccion, AddressOf TerminarVisita
            AddHandler ctrlSeguimiento.TerminarVisitaMenu, AddressOf TerminarVisita
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
        [Global].HabilitarMenuItem(MainMenu1, True)
    End Sub

    Private Sub QuitarCtrlSeguimiento()
        If oVendedor.motconfiguracion.Secuencia Then
            If Not ctrlSeguimiento.Parent Is Nothing Then
                RemoveHandler ctrlSeguimiento.NuevaSeleccion, AddressOf TerminarVisita
                RemoveHandler ctrlSeguimiento.TerminarVisitaMenu, AddressOf TerminarVisita
                ctrlSeguimiento.QuitarMenuItem(Me.MainMenu1)
                Me.Controls.Remove(ctrlSeguimiento)
            End If
        Else
            If Not Me.MenuItemRegresar Is Nothing Then
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
    End Sub

    Private Function HaySeleccion(ByVal LV As ListView) As Boolean
        If LV.Items.Count > 0 Then
            Dim i As Integer
            For i = 0 To LV.Items.Count - 1
                If LV.Items(i).Checked Then
                    Return True
                End If
            Next
        End If
        Return False
    End Function

    Private Function ObtieneActivoClave(ByVal LV As ListView) As String
        Dim i As Integer
        For i = 0 To LV.Items.Count - 1
            If LV.Items(i).Checked Then
                Return LV.Items(i).Text
            End If
        Next
        Return ""
    End Function

    Private Function EstaAsignadoAlCliente(ByVal clave As String) As Boolean
        Try
            Dim tr As New System.Text.StringBuilder
            tr.Append("select activoclientehistid from activo left join activoclientehist on activo.activoclave=activoclientehist.activoclave  ")
            tr.Append("where(activo.activoclave = activoclientehist.activoclave) ")
            tr.Append("and activo.activoclave='" & clave & "' ")
            tr.Append("and activoclientehist.tipoestado=1 ")
            tr.Append("and clienteclave='" & oCliente.ClienteClave & "' ")
            tr.Append("and activoclientehist.activoclientehistid in ")
            tr.Append("(select activoclientehistid from activoclientehist where fecha in (select max(fecha) from activoclientehist where activoclave=activo.activoclave and clienteclave='" & oCliente.ClienteClave & "'))")
            Dim Dt As DataTable = oDBVen.RealizarConsultaSQL(tr.ToString, "Transferencia")
            If Dt.Rows.Count > 0 Then
                Dt.Dispose()
                Return True
            End If
            Dt.Dispose()
            Return False
        Catch ex As SqlServerCe.SqlCeException
            MsgBox("SQL Error: " & ex.Message)
            Return False
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
            Return False
        End Try
    End Function
#End Region

#Region "LISTVIEW"
    Private Sub ListViewActivos_ItemCheck1(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles ListViewActivos.ItemCheck
        If blnSeleccionManual Then Exit Sub
        Try
            blnSeleccionManual = True
            MarcarElemento(ListViewActivos, e.NewValue, e.Index)
            blnSeleccionManual = False
            If ListViewActivos.SelectedIndices.Count <= 0 Then Exit Sub
            If e.NewValue = CheckState.Unchecked Then
                blnSeleccionManual = True
                ListViewActivos.Items(ListViewActivos.SelectedIndices(0)).Selected = False
                blnSeleccionManual = False
            End If
        Catch ex As Exception

        End Try
    End Sub
#End Region

#Region "BOTONES"
    Private Sub ButtonContinuar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonContinuar.Click
        Continuar()
    End Sub

    Private Sub ButtonRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRegresar.Click
        Me.Close()
    End Sub

    Private Sub ButtonAsignar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAsignar.Click
        QuitarCtrlSeguimiento()

        If Not HaySeleccion(ListViewActivos) Then
            Dim oFAA As New FormActivosAsignar(oCliente, VisitaClave, False, "")
            If oFAA.ShowDialog = Windows.Forms.DialogResult.OK Then
                LlenaLV()
            End If
            oFAA.Dispose()
            oFAA = Nothing
        Else
            ActivoClave = ObtieneActivoClave(ListViewActivos)
            Dim oFAA As New FormActivosAsignar(oCliente, VisitaClave, True, ActivoClave)
            If oFAA.ShowDialog = Windows.Forms.DialogResult.OK Then
                LlenaLV()
            End If
            oFAA.Dispose()
            oFAA = Nothing
        End If

        AgregarCtrlSeguimiento()
    End Sub

    Private Sub ButtonTransferir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonTransferir.Click
        If Not HaySeleccion(ListViewActivos) Then
            MsgBox(oVista.BuscarMensaje("Mensajes", "E0024"), MsgBoxStyle.Information)
        Else
            ActivoClave = ObtieneActivoClave(ListViewActivos)
            Dim tr As New System.Text.StringBuilder
            tr.Append("select activoclientehistid, activo.tipoestado from activo left join activoclientehist on activo.activoclave=activoclientehist.activoclave  ")
            tr.Append("where(activo.activoclave = activoclientehist.activoclave) ")
            tr.Append("and activo.activoclave='" & ActivoClave & "' ")
            tr.Append("and activoclientehist.tipoestado=1 ")
            tr.Append("and clienteclave='" & oCliente.ClienteClave & "' ")
            tr.Append("and activoclientehist.activoclientehistid in ")
            tr.Append("(select activoclientehistid from activoclientehist where fecha in (select max(fecha) from activoclientehist where activoclave=activo.activoclave and clienteclave='" & oCliente.ClienteClave & "'))")
            Dim Dt As DataTable = odbVen.RealizarConsultaSQL(tr.ToString, "Transferencia")

            If Dt.Rows.Count > 0 Then
                Dim Dr As DataRow = Dt.Rows(0)
                If Dr(1) = 0 Then
                    MsgBox(oVista.BuscarMensaje("Mensajes", "E0075"), MsgBoxStyle.Information)
                Else
                    Me.QuitarCtrlSeguimiento()

                    Dim oFAA As New FormActivosTransferir(oCliente, VisitaClave, ActivoClave)
                    If oFAA.ShowDialog = Windows.Forms.DialogResult.OK Then
                        LlenaLV()
                    End If
                    oFAA.Dispose()
                    oFAA = Nothing

                    Me.AgregarCtrlSeguimiento()
                End If
            Else
                MsgBox(oVista.BuscarMensaje("Mensajes", "E0025"), MsgBoxStyle.Information)
            End If
            Dt.Dispose()
        End If
    End Sub
#End Region

#Region "Lectura Cliente"
#If MOD_TERM <> "PALM" Then
    Private Sub bScanner_Data_Scanned(ByVal Data As String) Handles bScanner.Data_Scanned

        If Not ActivoAutomatico(Data) Then
            Me.TextBoxIDElectronico.Text = String.Empty
        End If

    End Sub
#End If

    Public Function ActivoAutomatico(ByVal parsIDElectronico As String) As Boolean
        If parsIDElectronico = String.Empty Then Return True
        Me.TextBoxIDElectronico.Text = parsIDElectronico
        Dim bEncontrado As Boolean = False


        Dim refListViewItem As ListViewItem
        For Each refListViewItem In Me.ListViewActivos.Items
            If refListViewItem.SubItems(5).Text = parsIDElectronico Then
                ActivoClave = refListViewItem.SubItems(0).Text

                refListViewItem.Selected = True
                refListViewItem.Checked = True

                bEncontrado = True
                Return True
                Exit For
            End If
        Next

        MsgBox(oVista.BuscarMensaje("Mensajes", "E0385"), MsgBoxStyle.Critical)
        Return False

    End Function

    Private Sub TextBoxIDElectronico_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim iSeleccionados As Integer
        Dim iIndice As Integer = 0
        For iSeleccionados = 0 To Me.ListViewActivos.SelectedIndices.Count - 1
            iIndice = Me.ListViewActivos.SelectedIndices(iSeleccionados)
            Me.ListViewActivos.Items(iIndice).Checked = False
            Me.ListViewActivos.Items(iIndice).Selected = False
        Next
    End Sub

    Private Sub TextBoxIDElectronico_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not ActivoAutomatico(TextBoxIDElectronico.Text) Then
            Me.TextBoxIDElectronico.Text = String.Empty
        End If
    End Sub
#End Region



    Private Sub MenuItemRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemRegresar.Click
        ButtonRegresar_Click(Nothing, Nothing)
    End Sub
End Class

Public Class ComboGeneral
    Private Con As String
    Private Val As String

    Public Sub New(ByVal v As String, ByVal c As String)
        MyBase.New()
        Me.Val = v
        Me.Con = c
    End Sub

    Public ReadOnly Property Concepto() As String
        Get
            Return Con
        End Get
    End Property

    Public ReadOnly Property Valor() As String
        Get
            Return Val
        End Get
    End Property
End Class