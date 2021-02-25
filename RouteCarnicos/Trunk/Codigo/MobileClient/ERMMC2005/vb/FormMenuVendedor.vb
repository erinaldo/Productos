
Public Class FormMenuVendedor
    Inherits System.Windows.Forms.Form

    Private Const ConstMenuRegresar = 0

    Protected tTipoOpcion As ServicesCentral.TiposOpcionesMenuVendedor
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ButtonContinuar As System.Windows.Forms.Button
    Friend WithEvents ButtonRegresar As System.Windows.Forms.Button

    Public Property OpcionSeleccionada() As ServicesCentral.TiposOpcionesMenuVendedor
        Get
            Return tTipoOpcion
        End Get
        Set(ByVal Value As ServicesCentral.TiposOpcionesMenuVendedor)
            tTipoOpcion = Value
        End Set
    End Property

    Private refaVista As Vista
    Friend WithEvents pbBateria As System.Windows.Forms.PictureBox
    Friend WithEvents LabelBateria As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents CtrlMenuVendedor As MobileClient.CtrlMenuImagen

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()
        Me.CtrlMenuVendedor.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold)
        'ListViewMenu.Activation = oApp.TipoSeleccion

    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        Timer1.Enabled = False
        If Not Me.MenuItemRegresar Is Nothing Then Me.MenuItemRegresar.Dispose()
        If Not Me.MainMenuVendedor Is Nothing Then Me.MainMenuVendedor.Dispose()
        If Not Me.CtrlMenuVendedor Is Nothing Then Me.CtrlMenuVendedor.Dispose()
        MyBase.Dispose(disposing)
    End Sub

    'NOTA: el Diseñador de Windows Forms requiere el siguiente procedimiento
    'Puede modificarse utilizando el Diseñador de Windows Forms. 
    'No lo modifique con el editor de código.
    Friend WithEvents MainMenuVendedor As System.Windows.Forms.MainMenu
    Friend WithEvents MenuItemRegresar As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMenuVendedor))
        Me.MainMenuVendedor = New System.Windows.Forms.MainMenu
        Me.MenuItemRegresar = New System.Windows.Forms.MenuItem
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.pbBateria = New System.Windows.Forms.PictureBox
        Me.LabelBateria = New System.Windows.Forms.Label
        Me.CtrlMenuVendedor = New MobileClient.CtrlMenuImagen
        Me.ButtonContinuar = New System.Windows.Forms.Button
        Me.ButtonRegresar = New System.Windows.Forms.Button
        Me.Timer1 = New System.Windows.Forms.Timer
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainMenuVendedor
        '
        Me.MainMenuVendedor.MenuItems.Add(Me.MenuItemRegresar)
        '
        'MenuItemRegresar
        '
        Me.MenuItemRegresar.Text = "MenuItemRegresar"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.pbBateria)
        Me.Panel1.Controls.Add(Me.LabelBateria)
        Me.Panel1.Controls.Add(Me.CtrlMenuVendedor)
        Me.Panel1.Controls.Add(Me.ButtonContinuar)
        Me.Panel1.Controls.Add(Me.ButtonRegresar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(242, 295)
        '
        'pbBateria
        '
        Me.pbBateria.Image = CType(resources.GetObject("pbBateria.Image"), System.Drawing.Image)
        Me.pbBateria.Location = New System.Drawing.Point(188, 269)
        Me.pbBateria.Name = "pbBateria"
        Me.pbBateria.Size = New System.Drawing.Size(18, 17)
        Me.pbBateria.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'LabelBateria
        '
        Me.LabelBateria.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.LabelBateria.Location = New System.Drawing.Point(204, 270)
        Me.LabelBateria.Name = "LabelBateria"
        Me.LabelBateria.Size = New System.Drawing.Size(33, 16)
        Me.LabelBateria.Text = "100%"
        Me.LabelBateria.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'CtrlMenuVendedor
        '
        Me.CtrlMenuVendedor.BackColor = System.Drawing.Color.White
        Me.CtrlMenuVendedor.Location = New System.Drawing.Point(3, 3)
        Me.CtrlMenuVendedor.Name = "CtrlMenuVendedor"
        Me.CtrlMenuVendedor.Size = New System.Drawing.Size(235, 255)
        Me.CtrlMenuVendedor.TabIndex = 8
        '
        'ButtonContinuar
        '
        Me.ButtonContinuar.Location = New System.Drawing.Point(6, 262)
        Me.ButtonContinuar.Name = "ButtonContinuar"
        Me.ButtonContinuar.Size = New System.Drawing.Size(74, 24)
        Me.ButtonContinuar.TabIndex = 6
        Me.ButtonContinuar.Text = "ButtonContinuar"
        '
        'ButtonRegresar
        '
        Me.ButtonRegresar.Location = New System.Drawing.Point(85, 262)
        Me.ButtonRegresar.Name = "ButtonRegresar"
        Me.ButtonRegresar.Size = New System.Drawing.Size(74, 24)
        Me.ButtonRegresar.TabIndex = 7
        Me.ButtonRegresar.Text = "ButtonRegresar"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 10000
        '
        'FormMenuVendedor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.LightGray
        Me.ClientSize = New System.Drawing.Size(242, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.Menu = Me.MainMenuVendedor
        Me.MinimizeBox = False
        Me.Name = "FormMenuVendedor"
        Me.Text = "Amesol Route"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub FormMenuVendedor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        [Global].ObtenerFactores(Me)
        [Global].EscalarForma(Me)
        [Global].EscalarMenuImagen(CtrlMenuVendedor)
        If Not Vista.Buscar("FormMenuVendedor", refaVista) Then
            Exit Sub
        End If
        refaVista.PoblarCtlMenuImagen(Me.CtrlMenuVendedor, "MV", "ListViewMenu")
        ' Recuperar los rótulos y elementos de la pantalla desde la base de datos Sys
        refaVista.ColocarEtiquetasForma(Me)
        With CtrlMenuVendedor
            If .Renglones.Length > 0 Then
                .Focus()
            Else
                Me.ButtonContinuar.Focus()
            End If
        End With
        [Global].EscalarFuente(Me)
        RefrescarStatusBateria()
    End Sub

    Private Sub ButtonRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRegresar.Click
        Me.OpcionSeleccionada = ServicesCentral.TiposOpcionesMenuVendedor.NoDefinido
        Me.Close()
    End Sub

    Private Sub ButtonContinuar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonContinuar.Click
        SeleccionarOpcion()
    End Sub

    Private Sub MenuItemRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemRegresar.Click
        Me.OpcionSeleccionada = ServicesCentral.TiposOpcionesMenuVendedor.NoDefinido
        Me.Close()
    End Sub

    Private Sub ListViewMenu_ItemActivate(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    'Private Sub ListViewMenu_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If ListViewMenu.SelectedIndices.Count = 0 Then
    '        Exit Sub
    '    End If
    '    Me.OpcionSeleccionada = ListViewMenu.Items(ListViewMenu.SelectedIndices(0)).ImageIndex
    'End Sub

    Private Sub FormMenuVendedor_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Disposed
        Me.refaVista = Nothing
    End Sub

    Private Sub SeleccionarOpcion()
        Me.OpcionSeleccionada = Me.CtrlMenuVendedor.CeldaActual.TipoIndice
        If Me.OpcionSeleccionada = ServicesCentral.TiposOpcionesMenuVendedor.NoDefinido Then
            If Not refaVista.BuscarMenuItemDefault("ListViewMenu", Me.OpcionSeleccionada) Then
                Exit Sub
            End If
        ElseIf Me.OpcionSeleccionada = ServicesCentral.TiposOpcionesMenuVendedor.DiasDeTrabajo Then
            If oVendedor.JornadaTrabajo Then
                Dim oDt As DataTable = oDBVen.RealizarConsultaSQL("Select VEJFechaInicial, FechaFinal From VendedorJornada Where VendedorId='" & oVendedor.VendedorId & "' order by mfechahora desc", "JornadaTrabajo")
                If oDt.Rows.Count = 0 Then
                    MsgBox(refaVista.BuscarMensaje("MsgBox", "E0487"), MsgBoxStyle.Critical, "Amesol Route")
                    Exit Sub
                ElseIf Not oDt.Rows(0)("FechaFinal") Is DBNull.Value Then
                    MsgBox(refaVista.BuscarMensaje("MsgBox", "E0488"), MsgBoxStyle.Critical, "Amesol Route")
                    Exit Sub
                End If
            End If
        ElseIf Me.OpcionSeleccionada = ServicesCentral.TiposOpcionesMenuVendedor.IniciarJornada Then
            If Not oVendedor.JornadaTrabajo Then Exit Sub
            Dim oDt As DataTable = oDBVen.RealizarConsultaSQL("Select * From VendedorJornada Where VendedorId='" & oVendedor.VendedorId & "' and FechaFinal IS NULL", "IniciarJornada")
            If oDt.Rows.Count > 0 Then
                MsgBox(SustituyeCampo(refaVista.BuscarMensaje("MsgBox", "E0490"), Format(oDt.Rows(0)("VEJFechaInicial"), "dd/MMM/yyyy")), MsgBoxStyle.Critical, "Amesol Route")
                Exit Sub
            End If
            oDt.Dispose()
        ElseIf Me.OpcionSeleccionada = ServicesCentral.TiposOpcionesMenuVendedor.FinalizarJornada Then
            If Not oVendedor.JornadaTrabajo Then Exit Sub
            Dim oDt As DataTable = oDBVen.RealizarConsultaSQL("Select * From VendedorJornada Where VendedorId='" & oVendedor.VendedorId & "' and FechaFinal IS NULL", "IniciarJornada")
            If oDt.Rows.Count = 0 Then
                MsgBox(refaVista.BuscarMensaje("MsgBox", "E0491"), MsgBoxStyle.Critical, "Amesol Route")
                Exit Sub
            End If
            If oVendedor.TipoModulo = ServicesCentral.TiposModulos.Distribucion Then
                If Not (oConHist.Campos("VentaSinSurtir")) Then
                    Dim dtVentasSinSurtir As DataTable = oDBVen.RealizarConsultaSQL("Select distinct CLI.Clave from TransProd TRP inner join Cliente CLI on TRP.ClienteClave = CLI.ClienteClave where TRP.Tipo = 1 and TRP.TipoFase = 1 ", "VentasSinSurtir")
                    If dtVentasSinSurtir.Rows.Count > 0 Then
                        Dim sCliente As String = String.Empty
                        For Each dr As DataRow In dtVentasSinSurtir.Rows
                            sCliente &= "'" & dr("Clave") & "',"
                        Next

                        If Len(sCliente) > 0 Then
                            sCliente = Microsoft.VisualBasic.Left(sCliente, sCliente.Length - 1)
                        End If
                        If MsgBox(refaVista.BuscarMensaje("MsgBox", "E0751").Replace("$0$", sCliente), MsgBoxStyle.Critical) Then
                            Exit Sub
                        End If
                    End If
                End If
            End If
            If oConHist.Campos("ValidaInv") And Not oConHist.Campos("Inventario") Then
                If UltimoDiaDeTrabajo() Then
                    If Inventario.ValidarInventarioABordo Then
                        MsgBox(refaVista.BuscarMensaje("MsgBox", "E0686"), MsgBoxStyle.Critical, "Amesol Route")
                        Exit Sub
                    End If
                End If
            End If
            If Not ValidarKilometraje() Then
                If MsgBox(refaVista.BuscarMensaje("MsgBox", "P0215"), MsgBoxStyle.YesNo Or MsgBoxStyle.Question) = MsgBoxResult.No Then
                    Exit Sub
                End If
            End If

            oDt.Dispose()
        ElseIf Me.OpcionSeleccionada = ServicesCentral.TiposOpcionesMenuVendedor.Preliquidacion Then
            If oConHist.Campos("Preliquidacion") Then
                Dim oDT As DataTable = oDBVen.RealizarConsultaSQL("SELECT PLIId FROM PreLiquidacion where Enviado = 0", "Preliq")
                If oDT.Rows.Count = 0 Then
                    MsgBox(refaVista.BuscarMensaje("MsgBox", "I0156"), MsgBoxStyle.Critical, "Amesol Route")
                    oDT.Dispose()
                    Exit Sub
                End If
                oDT.Dispose()
            End If
        ElseIf Me.OpcionSeleccionada = ServicesCentral.TiposOpcionesMenuVendedor.Kilometraje Then
            If Not oVendedor.Kilometraje Then Exit Sub
        End If

        oFormCargando.Informar(Me.OpcionSeleccionada, "MV", Me.CtrlMenuVendedor.lblMenuActual.Text)
        'FormProcesando.PubSubTitulo(refaVista.BuscarMensaje("Procesando", "Cargando"))
        Me.Close()
    End Sub

    Private Function UltimoDiaDeTrabajo() As Boolean
        Dim sConsulta As String
        Dim dtDia As DataTable
        Dim nTotalDia As Integer = 0
        Dim nTotalVej As Integer = 0
        sConsulta = "select count(Dia.DiaClave) as TotalDIA, "
        sConsulta &= "sum(case when not VEJ.FechaFinal is null then 1 else 0 end) as TotalVEJ from Dia "
        sConsulta &= "left join VendedorJornada VEJ on Dia.DiaClave = VEJ.DiaClave "
        sConsulta &= "where Dia.FueraFrecuencia = 0 "
        dtDia = oDBVen.RealizarConsultaSQL(sConsulta, "Dia")
        If dtDia.Rows.Count > 0 Then
            nTotalDia = Convert.ToInt16(dtDia.Rows(0)("TotalDIA"))
            nTotalVej = Convert.ToInt16(dtDia.Rows(0)("TotalVEJ"))
        End If
        dtDia.Dispose()
        Return (nTotalVej = (nTotalDia - 1))
    End Function

    Private Sub CtrlMenuVendedor_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles CtrlMenuVendedor.DoubleClick
        SeleccionarOpcion()
    End Sub

    Private Sub CtrlMenuVendedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CtrlMenuVendedor.KeyDown
        If e.KeyCode = Keys.Return Then
            SeleccionarOpcion()
        End If
    End Sub


    Private Sub pbBateria_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbBateria.Click
        RefrescarStatusBateria()
    End Sub
    Private Sub RefrescarStatusBateria()
        Dim status As New Bateria.SYSTEM_POWER_STATUS_EX
        If Convert.ToInt32(Bateria.SYSTEM_POWER_STATUS_EX.GetSystemPowerStatusEx(status, False)) = 1 Then
            Me.LabelBateria.Text = String.Format("{0}%", status.BatteryLifePercent)
        End If
    End Sub

    Private Sub Timer1_Tick_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        RefrescarStatusBateria()
    End Sub


End Class
