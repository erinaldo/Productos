Public Class FormDevolucionPrestamosDetalle
    Inherits System.Windows.Forms.Form
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtSaldo As System.Windows.Forms.TextBox
    Friend WithEvents txtFecha As System.Windows.Forms.TextBox
    Friend WithEvents txtFolio As System.Windows.Forms.TextBox
    Friend WithEvents FlexGrid As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents ButtonCancelar As System.Windows.Forms.Button
    Friend WithEvents ButtonAceptar As System.Windows.Forms.Button
    Friend WithEvents lbSaldo As System.Windows.Forms.Label
    Friend WithEvents lbFecha As System.Windows.Forms.Label
    Friend WithEvents lbFolio As System.Windows.Forms.Label
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal parsTransProdId As String, ByVal parVista As Vista, ByVal paroCliente As Cliente, ByVal parsVisitaClave As String, ByVal parsFolio As String, ByVal parModo As eModo)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        sTransProdId = parsTransProdId
        sVisitaClave = parsVisitaClave
        oVista = parVista
        oCliente = paroCliente
        oModo = parModo
        sFolio = parsFolio
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If Not Me.MenuItem1 Is Nothing Then Me.MenuItem1.Dispose()
        If Not Me.MainMenu1 Is Nothing Then Me.MainMenu1.Dispose()
        If Not Me.FlexGrid Is Nothing Then Me.FlexGrid.Dispose()
        Me.FlexGrid = Nothing
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormDevolucionPrestamosDetalle))
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.txtSaldo = New System.Windows.Forms.TextBox
        Me.txtFecha = New System.Windows.Forms.TextBox
        Me.txtFolio = New System.Windows.Forms.TextBox
        Me.FlexGrid = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.ButtonCancelar = New System.Windows.Forms.Button
        Me.ButtonAceptar = New System.Windows.Forms.Button
        Me.lbSaldo = New System.Windows.Forms.Label
        Me.lbFecha = New System.Windows.Forms.Label
        Me.lbFolio = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.Add(Me.MenuItem1)
        '
        'MenuItem1
        '
        Me.MenuItem1.Text = "MenuItemCancelar"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txtSaldo)
        Me.Panel1.Controls.Add(Me.txtFecha)
        Me.Panel1.Controls.Add(Me.txtFolio)
        Me.Panel1.Controls.Add(Me.FlexGrid)
        Me.Panel1.Controls.Add(Me.ButtonCancelar)
        Me.Panel1.Controls.Add(Me.ButtonAceptar)
        Me.Panel1.Controls.Add(Me.lbSaldo)
        Me.Panel1.Controls.Add(Me.lbFecha)
        Me.Panel1.Controls.Add(Me.lbFolio)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(242, 295)
        '
        'txtSaldo
        '
        Me.txtSaldo.Enabled = False
        Me.txtSaldo.Location = New System.Drawing.Point(103, 41)
        Me.txtSaldo.Name = "txtSaldo"
        Me.txtSaldo.Size = New System.Drawing.Size(100, 23)
        Me.txtSaldo.TabIndex = 9
        Me.txtSaldo.Visible = False
        '
        'txtFecha
        '
        Me.txtFecha.Enabled = False
        Me.txtFecha.Location = New System.Drawing.Point(103, 41)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Size = New System.Drawing.Size(100, 23)
        Me.txtFecha.TabIndex = 10
        '
        'txtFolio
        '
        Me.txtFolio.Enabled = False
        Me.txtFolio.Location = New System.Drawing.Point(103, 17)
        Me.txtFolio.Name = "txtFolio"
        Me.txtFolio.Size = New System.Drawing.Size(100, 23)
        Me.txtFolio.TabIndex = 11
        '
        'FlexGrid
        '
        Me.FlexGrid.AllowEditing = True
        Me.FlexGrid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlexGrid.AutoResize = True
        Me.FlexGrid.AutoSearchDelay = 1
        Me.FlexGrid.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.FlexGrid.Clip = ""
        Me.FlexGrid.ClipSeparators = "" & Global.Microsoft.VisualBasic.ChrW(9) & Global.Microsoft.VisualBasic.ChrW(13)
        Me.FlexGrid.Col = 0
        Me.FlexGrid.ColSel = 0
        Me.FlexGrid.ComboList = Nothing
        Me.FlexGrid.EditMask = Nothing
        Me.FlexGrid.ExtendLastCol = False
        Me.FlexGrid.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
        Me.FlexGrid.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.FlexGrid.LeftCol = 1
        Me.FlexGrid.Location = New System.Drawing.Point(3, 65)
        Me.FlexGrid.Name = "FlexGrid"
        Me.FlexGrid.Redraw = True
        Me.FlexGrid.Row = 0
        Me.FlexGrid.RowSel = 0
        Me.FlexGrid.ScrollPosition = New System.Drawing.Point(0, 0)
        Me.FlexGrid.ScrollTrack = True
        Me.FlexGrid.ShowCursor = False
        Me.FlexGrid.ShowSort = True
        Me.FlexGrid.Size = New System.Drawing.Size(234, 196)
        Me.FlexGrid.StyleInfo = resources.GetString("FlexGrid.StyleInfo")
        Me.FlexGrid.SupportInfo = "7gDJAOkAawEqAH4BJQGKADcBSwF8AKcABAH7AFQAvQAwAAUBhADfALwAxwAwAeEARADfAIMA"
        Me.FlexGrid.TabIndex = 12
        Me.FlexGrid.TopRow = 1
        '
        'ButtonCancelar
        '
        Me.ButtonCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.ButtonCancelar.Location = New System.Drawing.Point(84, 265)
        Me.ButtonCancelar.Name = "ButtonCancelar"
        Me.ButtonCancelar.Size = New System.Drawing.Size(72, 24)
        Me.ButtonCancelar.TabIndex = 13
        Me.ButtonCancelar.Text = "ButtonCancelar"
        '
        'ButtonAceptar
        '
        Me.ButtonAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.ButtonAceptar.Location = New System.Drawing.Point(4, 265)
        Me.ButtonAceptar.Name = "ButtonAceptar"
        Me.ButtonAceptar.Size = New System.Drawing.Size(72, 24)
        Me.ButtonAceptar.TabIndex = 14
        Me.ButtonAceptar.Text = "ButtonAceptar"
        '
        'lbSaldo
        '
        Me.lbSaldo.Location = New System.Drawing.Point(3, 44)
        Me.lbSaldo.Name = "lbSaldo"
        Me.lbSaldo.Size = New System.Drawing.Size(100, 20)
        Me.lbSaldo.Text = "lbSaldo"
        Me.lbSaldo.Visible = False
        '
        'lbFecha
        '
        Me.lbFecha.Location = New System.Drawing.Point(3, 46)
        Me.lbFecha.Name = "lbFecha"
        Me.lbFecha.Size = New System.Drawing.Size(100, 20)
        Me.lbFecha.Text = "lbFecha"
        '
        'lbFolio
        '
        Me.lbFolio.Location = New System.Drawing.Point(3, 17)
        Me.lbFolio.Name = "lbFolio"
        Me.lbFolio.Size = New System.Drawing.Size(100, 20)
        Me.lbFolio.Text = "lbFolio"
        '
        'FormDevolucionPrestamosDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(242, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Menu = Me.MainMenu1
        Me.Name = "FormDevolucionPrestamosDetalle"
        Me.Text = "Amesol Route"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "VARIABLES"
    Private oVista As Vista
    Private oCliente As Cliente
    Private oModo As eModo
    Private sTransProdId As String = String.Empty
    Private sVisitaClave As String = String.Empty
    Private bFin As Boolean = False
    Private bCambios As Boolean = False
    Private iCantidadTmp As Integer = 0
    Private iStartEdit As Integer
    Private sFolio As String = String.Empty
#End Region

#Region "PROPIEDADES"

    Public Property Transaccion() As SqlServerCe.SqlCeTransaction
        Get
            Return oDBVen.Transaccion
        End Get
        Set(ByVal Value As SqlServerCe.SqlCeTransaction)
            oDBVen.Transaccion = Value
        End Set
    End Property

#End Region

#Region "FUNCIONES"

    Private Function ObtenerMaxCantidadADevolver(ByVal pvProductoClave As String, ByVal iCantAnterior As Integer) As Integer
        Dim sQuery As String = "select sum(PP.Cargo) as CantidadPrestada, sum(PP.Saldo) as Cantidad " & _
        "from ProductoPrestamoCli PP " & _
        "where PP.ClienteClave='" & oCliente.ClienteClave & "' AND PP.ProductoDetClave='" & pvProductoClave & "'"

        Dim oDr As DataRow = oDBVen.RealizarConsultaSQL(sQuery, "OBMCAD").Rows(0)
        Dim iCantidad As Integer = 0

        If Not IsDBNull(oDr("CantidadPrestada")) Then
            iCantidad = oDr("Cantidad")
        End If

        iCantidad += iCantAnterior
        Return iCantidad
    End Function

    Private Function HaySeleccion(ByRef FG As C1.Win.C1FlexGrid.C1FlexGrid) As Boolean
        If FG.Rows.Count > 1 Then
            For i As Integer = 1 To FG.Rows.Count - 1
                If FG.Item(i, 0) = True Then Return True
            Next
        End If
        Return False
    End Function

    Private Function SustituyeCampos(ByVal msg As String, ByVal Campos() As String) As String
        msg = msg.Replace("$0$", Campos(0))
        msg = msg.Replace("$1$", Campos(1))
        Return msg
    End Function

#End Region

#Region "METODOS"

    Private Sub LlenaCampos()
        Dim oDr As DataRow = oDBVen.RealizarConsultaSQL("SELECT T.Folio, T.FechaCaptura, C.SaldoPrestamo FROM Transprod as T, Visita as V, Cliente as C WHERE T.TransprodId='" & sTransProdId & "' AND T.VisitaClave=V.VisitaClave AND T.DiaClave=V.DiaClave AND V.ClienteClave=C.ClienteClave", "LlenaCampos").Rows(0)
        Me.txtFolio.Text = oDr("Folio")
        Me.txtFecha.Text = Format(oDr("FechaCaptura"), "dd/MM/yyyy")
        Me.txtSaldo.Text = oDr("SaldoPrestamo")
    End Sub

    Private Sub LlenarFlexGrid()
        Dim sQuery As New System.Text.StringBuilder
        If oModo = eModo.Nuevo Then
            sQuery.Append("SELECT PP.productodetclave, p.nombre,PP.PRUTipoUnidad as TipoUnidad, sum(pp.cantidad) as Cantidad, 1, PD.Factor FROM productoprestamo as pp, producto as p, productodetalle as pd, transprod as t, visita as v ")
            sQuery.Append("WHERE pp.productodetclave=p.productoclave and pp.transprodid=t.transprodid and t.visitaclave=v.visitaclave ")
            sQuery.Append("and pd.productoclave=pp.productoclave and pd.prutipounidad=pp.prutipounidad and pd.productodetclave=pp.productodetclave ")
            sQuery.Append("and t.diaclave=v.diaclave and v.clienteclave='" & oCliente.ClienteClave & "' and pp.cantidad > 0 group by PP.productodetclave, p.nombre,PP.PRUTipoUnidad, pd.factor")
        Else
            sQuery.Append("SELECT TPD.ProductoClave, P.Nombre, TPD.TipoUnidad,TPD.Cantidad, TPD.TransProdDetalleId, TPD.Partida as Factor FROM TransProdDetalle as TPD, Producto as P ")
            sQuery.Append("WHERE TPD.ProductoClave=P.ProductoClave and TPD.TransProdId='" & sTransProdId & "'")
        End If
        With Me.FlexGrid
            Dim oDt As DataTable = oDBVen.RealizarConsultaSQL(sQuery.ToString, "LlenaFlexGrid")
            For Each oDr As DataRow In oDt.Rows
                .AddItem("0" + vbTab + oDr(0).ToString + vbTab + oDr("Nombre").ToString + vbTab + oDr("Cantidad").ToString + vbTab + ValorReferencia.BuscarEquivalente("UNIDADV", oDr("TipoUnidad").ToString) + vbTab + oDr(4).ToString + vbTab + oDr("Factor").ToString + vbTab + oDr("TipoUnidad").ToString)
            Next
            oDt.Dispose()
        End With
        sQuery = Nothing
    End Sub

    Private Sub DarFormatoFlexGrid()
        With Me.FlexGrid
            .Cols.Count = 8
            .Cols.Fixed = 0
            .Rows.Count = 1
            .ClipSeparators = vbTab + vbLf
            .Cols(0).Width = 18
            .Cols(0).DataType = GetType(Boolean)
            .Cols(1).AllowEditing = False
            .Cols(1).Width = 60
            .Cols(1).Name = "Clave"
            .Cols(1).Caption = oVista.BuscarMensaje("FlexGrid", "Clave")
            .Cols(2).AllowEditing = False
            .Cols(2).Width = 100
            .Cols(2).Name = "Nombre"
            .Cols(2).Caption = oVista.BuscarMensaje("FlexGrid", "Nombre")

            .Cols(3).AllowEditing = False
            .Cols(3).Width = 30
            .Cols(3).Name = "Cantidad"
            .Cols(3).Caption = oVista.BuscarMensaje("FlexGrid", "Cantidad")
            .Cols(3).DataType = GetType(Integer)

            .Cols(4).AllowEditing = False
            .Cols(4).Width = 50
            .Cols(4).Name = "TipoUnidad" '(String)
            .Cols(4).Caption = oVista.BuscarMensaje("FlexGrid", "TipoUnidad")

            .Cols(5).Visible = False
            .Cols(6).Visible = False 'Factor
            .Cols(7).Visible = False 'TipoUnidad (Integer)
        End With
    End Sub

    Private Sub ActualizaProductosYSaldo()
        Dim iSuma As Integer = 0
        'Dim n As Integer = 0
        With Me.FlexGrid
            For i As Integer = 1 To .Rows.Count - 1
                iSuma += CInt(.Item(i, 3)) * CInt(.Item(i, 6))
                Me.AlterarProductoPrestamo(.Item(i, 1), .Item(i, 3), .Item(i, 7), eAlteracion.Agregar, eCelda.Cantidad)
            Next
        End With
        ''Actualizo el saldoprestamo del cliente
        oDBVen.EjecutarComandoSQL("UPDATE Cliente SET SaldoPrestamo= SaldoPrestamo + " & iSuma & ",Enviado = 0, MFechaHora=" & UniFechaSQL(Now) & ",MUsuarioID='" & oVendedor.UsuarioId & "' WHERE ClienteClave='" & oCliente.ClienteClave & "'")

    End Sub

    Private Sub GuardaSaldoCliente()
        oDBVen.EjecutarComandoSQL("UPDATE Cliente SET SaldoPrestamo=" & Me.txtSaldo.Text & " ,Enviado=0,MFechaHora=" & UniFechaSQL(Now) & ",MUsuarioID='" & oVendedor.UsuarioId & "' WHERE ClienteClave='" & oCliente.ClienteClave & "'")

    End Sub

    Private Sub ActualizarFlexGrid(ByVal pvModo As eModo)
        If pvModo = eModo.Nuevo Then
            For i As Integer = 1 To Me.FlexGrid.Rows.Count - 1
                Me.FlexGrid.Item(i, 5) = oApp.KEYGEN(i)
            Next
        Else
            For i As Integer = 1 To Me.FlexGrid.Rows.Count - 1
                Me.FlexGrid.Item(i, 0) = True
            Next
        End If
    End Sub

    Private Sub AlterarProductoPrestamo(ByVal pvProductoDetClave As String, ByVal pvCantidad As Integer, ByVal pvTipoUnidad As Integer, ByVal oAlt As eAlteracion, ByVal oCelda As eCelda)
        Dim sQuery As New System.Text.StringBuilder
        Dim oDt As DataTable
        If oAlt = eAlteracion.Sustraer Then
            sQuery.Append("SELECT distinct PP.* FROM ProductoPrestamo as PP inner join TransProd as TP on PP.TransProdID= TP.TransProdID inner join Visita as V  on TP.VisitaClave=V.VisitaClave AND TP.DiaClave=V.DiaClave ")
            sQuery.Append("WHERE V.ClienteClave='" & oCliente.ClienteClave & "' AND PP.PRUTipoUnidad=" & pvTipoUnidad)
            sQuery.Append(" AND PP.ProductoDetClave='" & pvProductoDetClave & "' AND (PP.Cantidad > 0 OR PP.Cantidad < PP.CantidadPrestada)")
            oDt = oDBVen.RealizarConsultaSQL(sQuery.ToString, "APP")
            For Each oDr As DataRow In oDt.Rows
                If pvCantidad > 0 Then
                    If pvCantidad <= oDr("Cantidad") Then
                        oDBVen.EjecutarComandoSQL("UPDATE ProductoPrestamo SET Cantidad=" & oDr("Cantidad") - pvCantidad & ",Enviado=0,MFechaHora=" & UniFechaSQL(Now) & ",MUsuarioID='" & oVendedor.UsuarioId & "' WHERE PPRID='" & oDr("PPRID") & "'")
                    Else
                        oDBVen.EjecutarComandoSQL("UPDATE ProductoPrestamo SET Cantidad=0,Enviado=0,MFechaHora=" & UniFechaSQL(Now) & ",MUsuarioID='" & oVendedor.UsuarioId & "' WHERE PPRID='" & oDr("PPRID") & "'")
                    End If
                    pvCantidad -= oDr("Cantidad")
                Else
                    Exit For
                End If
            Next
        ElseIf oAlt = eAlteracion.Agregar Then
            sQuery.Append("SELECT ProductoPrestamo.* FROM ProductoPrestamo inner join TransProdDetalle on ProductoPrestamo.TransProdID =TransProdDetalle.TransProdID ")
            sQuery.Append("and ProductoPrestamo.TransProdDetalleID = TransProdDetalle.TransProdDetalleID inner join TransProd  on TransProdDetalle.TransProdID = TransProd.TransProdId ")
            sQuery.Append("inner join Visita on Visita.VisitaClave=TransProd.VisitaClave AND Visita.DiaClave=TransProd.DiaClave WHERE Visita.ClienteClave='" & oCliente.ClienteClave & "' ")
            sQuery.Append("AND ProductoPrestamo.ProductoDetClave='" & pvProductoDetClave & "' AND ProductoPrestamo.PRUTipoUnidad=" & pvTipoUnidad)
            oDt = oDBVen.RealizarConsultaSQL(sQuery.ToString, "APP")
            For Each oDr As DataRow In oDt.Rows
                If pvCantidad > 0 Then
                    Dim iDiferencia As Integer = oDr("CantidadPrestada") - oDr("Cantidad")
                    If iDiferencia >= pvCantidad Then
                        oDBVen.EjecutarComandoSQL("UPDATE ProductoPrestamo SET Cantidad=" & oDr("Cantidad") + pvCantidad & ",Enviado=0,MFechaHora=" & UniFechaSQL(Now) & ",MUsuarioID='" & oVendedor.UsuarioId & "' WHERE PPRID='" & oDr("PPRID") & "'")
                    Else
                        oDBVen.EjecutarComandoSQL("UPDATE ProductoPrestamo SET Cantidad=" & oDr("CantidadPrestada") & ",Enviado=0,MFechaHora=" & UniFechaSQL(Now) & ",MUsuarioID='" & oVendedor.UsuarioId & "' WHERE PPRID='" & oDr("PPRID") & "'")
                    End If
                    pvCantidad -= iDiferencia
                Else
                    Exit For
                End If
            Next
        End If
        oDt.Dispose()
        sQuery = Nothing
    End Sub

#End Region

#Region "EVENTOS"

    Private Sub FormDevolucionPrestamosDetalle_closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        If Not Me.FlexGrid Is Nothing Then
            If oVendedor.motconfiguracion.Secuencia Then
                If Not ctrlSeguimiento.Parent Is Nothing Then
                    RemoveHandler ctrlSeguimiento.NuevaSeleccion, AddressOf TerminarVisita
                    RemoveHandler ctrlSeguimiento.TerminarVisitaMenu, AddressOf TerminarVisita
                    ctrlSeguimiento.QuitarMenuItem(Me.MainMenu1)
                    Me.Controls.Remove(ctrlSeguimiento)
                End If
            Else
                If Not Me.FlexGrid Is Nothing Then
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

        If Not Me.Transaccion Is Nothing Then Me.Transaccion.Dispose()
        Me.Transaccion = Nothing
    End Sub

    Private Sub FormDevolucionPrestamosDetalle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

        If Not Vista.Buscar("FormDevolucionPrestamosDetalle", oVista) Then
            Cursor.Current = Cursors.Default
            Exit Sub
        End If
        oVista.ColocarEtiquetasForma(Me)
        Application.DoEvents()
        If oDBVen.oConexion.State = ConnectionState.Closed Then
            oDBVen.oConexion.Open()
        End If
        Transaccion = oDBVen.oConexion.BeginTransaction
        If oModo = eModo.Nuevo Then
            Dim sQuery As String = "INSERT INTO TransProd (TransprodId,VisitaClave,DiaClave,Folio,Tipo,TipoFase,TipoMovimiento,FechaHoraAlta,FechaCaptura,Total,Notas,MFechaHora,MUsuarioId) Values('" & sTransProdId & "','" & sVisitaClave & "','" & oDia.DiaActual & "','" & sFolio & "',15,1,1," & UniFechaSQL(Now) & "," & UniFechaSQL(PrimeraHora(Now)) & ",0,' '," & UniFechaSQL(Now) & ",'" & oVendedor.UsuarioId & "')"
            oDBVen.EjecutarComandoSQL(sQuery)
        End If
        Call DarFormatoFlexGrid()
        Me.LlenaCampos()
        Me.LlenarFlexGrid()
        Me.ActualizarFlexGrid(oModo)
        If oModo = eModo.Eliminar Then
            Me.FlexGrid.AllowEditing = False
        End If
        bFin = True
        [Global].HabilitarMenuItem(MainMenu1, True)
        Cursor.Current = Cursors.Default

        txtFolio.Focus()

    End Sub

    Private Sub TerminarVisita()
        ButtonCancelar_Click(Nothing, Nothing)
    End Sub

    Private Sub FlexGrid_AfterEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles FlexGrid.AfterEdit
        Dim sQuery As String = String.Empty
        Dim nCantOriginal As Integer = 0

        If e.Col = 3 Then
            With Me.FlexGrid
                Dim nCantidad As Integer = .Item(e.Row, e.Col)
                Dim nMaxDevolucion = Me.ObtenerMaxCantidadADevolver(.Item(e.Row, 1), iCantidadTmp)
                If .Item(e.Row, e.Col) Is Nothing OrElse Trim(.Item(e.Row, e.Col)) = "" Then
                    MsgBox(Me.SustituyeCampos(oVista.BuscarMensaje("Mensajes", "E0216"), New String() {"1", nMaxDevolucion}), MsgBoxStyle.Information)
                    e.Cancel = True
                    .Item(.Row, .Col) = iCantidadTmp
                    Exit Sub
                End If
                Dim sId As String = .Item(e.Row, 5)
                If nCantidad > 0 AndAlso nCantidad <= nMaxDevolucion Then
                    Dim iFactor As Integer = .Item(e.Row, 6)
                    sQuery = "UPDATE TransProdDetalle SET Cantidad=" & nCantidad & ", MFechaHora=" & UniFechaSQL(Now) & ", MUsuarioID='" & oVendedor.UsuarioId & "',Enviado=0 WHERE TransProdId='" & sTransProdId & "' AND TransprodDetalleId='" & sId & "'"
                    oDBVen.EjecutarComandoSQL(sQuery)
                    If nCantidad > iCantidadTmp Then
                        'Me.txtSaldo.Text = CInt(Me.txtSaldo.Text) + (nCantidad - iCantidadTmp)
                        Me.txtSaldo.Text = CInt(Me.txtSaldo.Text) + ((iCantidadTmp - nCantidad) * iFactor)
                        Me.AlterarProductoPrestamo(.Item(e.Row, 1), nCantidad - iCantidadTmp, .Item(e.Row, 7), eAlteracion.Sustraer, eCelda.Cantidad)
                    ElseIf nCantidad < iCantidadTmp Then
                        Me.txtSaldo.Text = CInt(Me.txtSaldo.Text) + ((iCantidadTmp - nCantidad) * iFactor)
                        Me.AlterarProductoPrestamo(.Item(e.Row, 1), iCantidadTmp - nCantidad, .Item(e.Row, 7), eAlteracion.Agregar, eCelda.Cantidad)
                    End If
                Else
                    MsgBox(Me.SustituyeCampos(oVista.BuscarMensaje("Mensajes", "E0216"), New String() {"1", nMaxDevolucion}), MsgBoxStyle.Information)
                    e.Cancel = True
                    .Item(.Row, .Col) = iCantidadTmp
                    Exit Sub
                End If
            End With
        ElseIf e.Col = 0 Then
            Dim sId As String = Me.FlexGrid.Item(e.Row, 5)
            With Me.FlexGrid
                ''''sQuery = "SELECT Cantidad FROM ProductoPrestamo WHERE PPRID='" & sPPRId & "'"
                'nCantOriginal = odbVen.RealizarConsultaSQL(sQuery, "CantidadOriginal").Rows(0)(0)
                Dim nCantidad As Integer = .Item(e.Row, 3)
                Dim iFactor As Integer = .Item(e.Row, 6)
                If .Item(e.Row, e.Col) = True Then
                    sQuery = "insert into TransProdDetalle (TransProdId, TransProdDetalleId, ProductoClave, TipoUnidad, Partida, Cantidad, Precio, SubTotal, Impuesto, Total, Promocion, MFechaHora, MUsuarioId, Enviado)"
                    sQuery &= "values('" & sTransProdId & "','" & sId & "','" & .Item(e.Row, 1) & "'," & .Item(e.Row, 7) & "," & iFactor & "," & nCantidad & ",0,0,0,0,0," & UniFechaSQL(Now) & ",'" & oVendedor.UsuarioId & "',0)"
                    oDBVen.EjecutarComandoSQL(sQuery)
                    Me.txtSaldo.Text = CInt(Me.txtSaldo.Text) - (nCantidad * iFactor)
                    Me.AlterarProductoPrestamo(.Item(e.Row, 1), nCantidad, .Item(e.Row, 7), eAlteracion.Sustraer, eCelda.Checkbox)

                Else
                    sQuery = "DELETE FROM TransProdDetalle WHERE TransProdId='" & sTransProdId & "' and TransProdDetalleId='" & sId & "'"
                    oDBVen.EjecutarComandoSQL(sQuery)
                    Me.txtSaldo.Text = CInt(Me.txtSaldo.Text) + (nCantidad * iFactor)
                    Me.AlterarProductoPrestamo(.Item(e.Row, 1), nCantidad, .Item(e.Row, 7), eAlteracion.Agregar, eCelda.Checkbox)
                End If
            End With
        End If
        bCambios = True
    End Sub

    Private Sub FlexGrid_EnterCell(ByVal sender As Object, ByVal e As System.EventArgs) Handles FlexGrid.EnterCell
        If oModo = eModo.Eliminar Then
            If Me.FlexGrid.Col = 0 OrElse Me.FlexGrid.Col = 3 Then
                Me.FlexGrid.Cols(Me.FlexGrid.Col).AllowEditing = False
            End If
        Else
            With Me.FlexGrid
                If .Col = 3 AndAlso .Item(.Row, 0) = True Then
                    .Cols(3).AllowEditing = True
                    'iCantidadTmp = .Item(.Row, 3)
                Else
                    .Cols(3).AllowEditing = False
                End If
            End With
        End If
    End Sub

    Private Sub ButtonAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAceptar.Click
        Select Case oModo
            Case eModo.Nuevo, eModo.Modificar
                If Me.HaySeleccion(Me.FlexGrid) Then
                    Me.GuardaSaldoCliente()
                    If oModo = eModo.Nuevo Then Folio.Confirmar(, ServicesCentral.TiposModulosMovDet.DevolucionPrestamos)
                    Transaccion.Commit()
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()
                Else
                    MsgBox(SustituyeCampo(oVista.BuscarMensaje("Mensajes", "E0044"), ValorReferencia.BuscarEquivalente("TRPTIPO", "15")), MsgBoxStyle.Information)
                    'Dim oDt As DataTable = ValorReferencia.RecuperarLista("TRPTipo", "15")
                    'MsgBox(SustituyeCampo(oVista.BuscarMensaje("Mensajes", "E0044"), oDt.Rows(0)("Descripcion")), MsgBoxStyle.Information)
                    Exit Sub
                End If
            Case eModo.Eliminar
                Dim oRes As Object = MsgBox(oVista.BuscarMensaje("Mensajes", "P0001"), MsgBoxStyle.Question + MsgBoxStyle.YesNo)
                If oRes = MsgBoxResult.No Then
                    Transaccion.Rollback()
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()
                ElseIf oRes = MsgBoxResult.Yes Then
                    Me.ActualizaProductosYSaldo()
                    oDBVen.EjecutarComandoSQL("DELETE FROM TransProdDetalle WHERE TransProdId='" & sTransProdId & "'")
                    oDBVen.EjecutarComandoSQL("DELETE FROM TransProd WHERE TransProdId='" & sTransProdId & "'")
                    Transaccion.Commit()
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()
                End If
        End Select
    End Sub

    Private Sub ButtonCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancelar.Click
        Select Case oModo
            Case eModo.Nuevo, eModo.Modificar
                If bCambios Then
                    If (MsgBox(oVista.BuscarMensaje("Mensajes", "BP0002"), MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes) Then
                        Transaccion.Rollback()
                    Else
                        Exit Sub
                        'Transaccion.Rollback()
                    End If
                End If
            Case eModo.Eliminar
                Transaccion.Rollback()
        End Select
        Me.DialogResult = Windows.Forms.DialogResult.Cancel

        Me.Close()
    End Sub

    Private Sub FlexGrid_StartEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles FlexGrid.StartEdit
        If e.Col = 3 Then
            iCantidadTmp = Me.FlexGrid.Item(e.Row, e.Col)
        End If
    End Sub

#End Region

    Private Sub MenuItem1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuItem1.Click
        ButtonCancelar_Click(Nothing, Nothing)
    End Sub
End Class

Public Enum eModo
    Nuevo = 1
    Modificar = 2
    Eliminar = 3
End Enum

Public Enum eAlteracion
    Agregar = 1
    Sustraer = 2
End Enum

Public Enum eCelda
    Checkbox = 1
    Cantidad = 2
End Enum