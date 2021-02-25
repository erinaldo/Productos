Imports ERMTRPLOG

Public Class NCargas
    Inherits FormasBase.Browse01

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
    Friend WithEvents btCrear As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btModificar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btActualizar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btReporteCarga As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btFiltroFecha As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btGenerar As DevComponents.DotNetBar.ButtonItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim GridEx1_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NCargas))
        Me.btCrear = New DevComponents.DotNetBar.ButtonItem
        Me.btModificar = New DevComponents.DotNetBar.ButtonItem
        Me.btActualizar = New DevComponents.DotNetBar.ButtonItem
        Me.btReporteCarga = New DevComponents.DotNetBar.ButtonItem
        Me.btGenerar = New DevComponents.DotNetBar.ButtonItem
        Me.btFiltroFecha = New DevComponents.DotNetBar.ButtonItem
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridEx1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btCrear, Me.btModificar, Me.btActualizar, Me.btReporteCarga, Me.btGenerar, Me.btFiltroFecha})
        '
        'GridEx1
        '
        Me.GridEx1.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridEx1.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        GridEx1_DesignTimeLayout.LayoutString = resources.GetString("GridEx1_DesignTimeLayout.LayoutString")
        Me.GridEx1.DesignTimeLayout = GridEx1_DesignTimeLayout
        Me.GridEx1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        '
        'btCrear
        '
        Me.btCrear.DisabledImage = CType(resources.GetObject("btCrear.DisabledImage"), System.Drawing.Image)
        Me.btCrear.Icon = CType(resources.GetObject("btCrear.Icon"), System.Drawing.Icon)
        Me.btCrear.Name = "btCrear"
        Me.btCrear.Text = "ButtonItem1"
        '
        'btModificar
        '
        Me.btModificar.DisabledImage = CType(resources.GetObject("btModificar.DisabledImage"), System.Drawing.Image)
        Me.btModificar.Icon = CType(resources.GetObject("btModificar.Icon"), System.Drawing.Icon)
        Me.btModificar.Name = "btModificar"
        Me.btModificar.Text = "ButtonItem1"
        '
        'btActualizar
        '
        Me.btActualizar.DisabledImage = CType(resources.GetObject("btActualizar.DisabledImage"), System.Drawing.Image)
        Me.btActualizar.Icon = CType(resources.GetObject("btActualizar.Icon"), System.Drawing.Icon)
        Me.btActualizar.Name = "btActualizar"
        Me.btActualizar.Text = "ButtonItem1"
        '
        'btReporteCarga
        '
        Me.btReporteCarga.Icon = CType(resources.GetObject("btReporteCarga.Icon"), System.Drawing.Icon)
        Me.btReporteCarga.Name = "btReporteCarga"
        Me.btReporteCarga.Text = "btReporteCarga"
        '
        'btGenerar
        '
        Me.btGenerar.Icon = CType(resources.GetObject("btGenerar.Icon"), System.Drawing.Icon)
        Me.btGenerar.Name = "btGenerar"
        Me.btGenerar.Text = "btGenerar"
        '
        'btFiltroFecha
        '
        Me.btFiltroFecha.Icon = CType(resources.GetObject("btFiltroFecha.Icon"), System.Drawing.Icon)
        Me.btFiltroFecha.Name = "btFiltroFecha"
        Me.btFiltroFecha.Text = "btFiltroFecha"
        '
        'NCargas
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(844, 666)
        Me.Name = "NCargas"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridEx1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Variables "
    Private Shared oInstance As NCargas = Nothing
    Private oConexion As LbConexion.cConexion = LbConexion.cConexion.Instancia
    Private oTransProd As cTransProd
    Private oMensaje As BASMENLOG.CMensaje
    Private sFechaInicio As String
    Private sFechaFin As String
    Private nTipoFiltro As Integer
    Private sComponente As String
    Dim oAcceso As LbAcceso.cAcceso
    Public eTipoCarga As TipoTRP
#End Region

#Region " Metodos "
    Public Shared Function Instance() As NCargas
        If oInstance Is Nothing OrElse oInstance.IsDisposed = True Then
            oInstance = New NCargas
        End If

        Return oInstance
    End Function

    Sub Inicio(ByVal pvAcceso As LbAcceso.cAcceso)
        sComponente = "ERMTRPESC"
        Me.eTipoCarga = TipoTRP.Carga
        oAcceso = pvAcceso
        Me.Show()
    End Sub

    Sub InicioSobran(ByVal pvAcceso As LbAcceso.cAcceso)
        sComponente = "ERMTRPSOB"
        Me.eTipoCarga = TipoTRP.Sobrante
        oAcceso = pvAcceso
        Me.Show()
    End Sub

    Private Sub ConfigurarGrid()
        Dim lcColumna As Janus.Windows.GridEX.GridEXColumn
        For Each lcColumna In GridEx1.RootTable.Columns
            lcColumna.Caption = oMensaje.RecuperarDescripcion(oTransProd.Mnemonico & lcColumna.Key)
            lcColumna.HeaderToolTip = oMensaje.RecuperarDescripcion(oTransProd.Mnemonico & lcColumna.Key & "T")
        Next
        GridEx1.RootTable.Columns("Almacen").Caption = oMensaje.RecuperarDescripcion("XCentroDistribucion")
        GridEx1.RootTable.Columns("Almacen").HeaderToolTip = oMensaje.RecuperarDescripcion("XCentroDistribucion")
        GridEx1.RootTable.Columns("Vendedor").Caption = oMensaje.RecuperarDescripcion("XVendedor")
        GridEx1.RootTable.Columns("Vendedor").HeaderToolTip = oMensaje.RecuperarDescripcion("XVendedor")
        GridEx1.RootTable.Columns("Automatica").Caption = oMensaje.RecuperarDescripcion("XSugerida")
        GridEx1.RootTable.Columns("Automatica").HeaderToolTip = oMensaje.RecuperarDescripcion("XSugerida")

        btCrear.Tooltip = oMensaje.RecuperarDescripcion("btCrear")
        btModificar.Tooltip = oMensaje.RecuperarDescripcion("btModificar")
        btActualizar.Tooltip = oMensaje.RecuperarDescripcion("btActualizar")
        btReporteCarga.Tooltip = oMensaje.RecuperarDescripcion("btReporte")
        btGenerar.Tooltip = oMensaje.RecuperarDescripcion("btCargaAutomatica")
        btFiltroFecha.Tooltip = oMensaje.RecuperarDescripcion("btFiltrarFechaT")

        If Not oAcceso.Crear Then
            btCrear.Enabled = False
        End If
        If Not oAcceso.Otros Then
            btGenerar.Enabled = False
        End If
        If Not oAcceso.Print Then
            btReporteCarga.Enabled = False
        End If
        If Not oAcceso.Modificar And Not oAcceso.Leer Then
            btModificar.Enabled = False
        End If
        If oAcceso.Leer And Not oAcceso.Modificar Then

            btModificar.Tooltip = oMensaje.RecuperarDescripcion("xconsultar")
            'Dim icono As System.Drawing.Icon
            'Dim iconptr As IntPtr
            'Dim img As New System.Drawing.Bitmap("Imagenes\Consulta.jpg")
            'img.MakeTransparent()
            'iconptr = img.GetHicon()
            'icono = icono.FromHandle(iconptr)

            btModificar.Icon = New System.Drawing.Icon("Imagenes\Consulta.ico")

        End If

        Try
            lbGeneral.LlenarConfiguracionGrid(sComponente, Me.Name, GridEx1, oTransProd.NombreTabla)
        Catch ex As LbControlError.cError
            ex.Mostrar()
            Exit Sub
        End Try
    End Sub

    Private Sub LlenarDropDownColumna(ByVal pvColumna As String, ByVal pvValor As String, ByVal pvListaExcluidos As String())
        With GridEx1.RootTable
            .Columns(pvColumna).HasValueList = True
            .Columns(pvColumna).EditType = Janus.Windows.GridEX.EditType.DropDownList
            lbGeneral.LlenarColumna(.Columns(pvColumna), pvValor, Nothing, pvListaExcluidos)
        End With
    End Sub

    Private Sub LlenarCombos()
        LlenarDropDownColumna("TipoFase", "TRPFASE", New String() {"2", "3", "4"})
    End Sub

    Private Function ObtenerCadenaFecha() As String
        Dim sFiltro As String
        sFiltro = lbGeneral.ClaveDescripcionVARValor("BFNUMERI", nTipoFiltro)
        sFiltro &= " " & sFechaInicio
        If nTipoFiltro = 7 Then
            sFiltro &= " - " & sFechaFin
        End If
        Return sFiltro
    End Function

    Private Sub Actualizar()
        Try
            Dim loDt As DataTable
            Dim sCampos As String
            Dim sFiltro As String

            If Me.eTipoCarga = TipoTRP.Sobrante Then
                sCampos = " TransProdId, Folio, DiaClave, (SELECT Nombre FROM Almacen WHERE Clave = TransProd.Notas) AS Almacen,"
                sCampos &= "(CASE WHEN (SELECT Nombre FROM Vendedor WHERE USUId = TransProd.MUsuarioId AND TipoEstado = 1 AND Baja = 0) IS NULL THEN (SELECT TOP 1 Nombre FROM Vendedor WHERE USUId = TransProd.MUsuarioId) ELSE (SELECT Nombre FROM Vendedor WHERE USUId = TransProd.MUsuarioId AND TipoEstado = 1 AND Baja = 0)END) AS Vendedor, "
                sCampos &= "TipoFase,(CASE WHEN TipoMotivo = 9 THEN CONVERT(BIT, 1) ELSE CONVERT(BIT, 0) END) AS Automatica, "
                sCampos &= "FechahoraAlta as Fecha"

                sFiltro = " Tipo = 25 "
            Else
                sCampos = " TransProdId, Folio, DiaClave, "
                sCampos &= "(CASE WHEN TipoFase <> 1 THEN (SELECT Nombre FROM Almacen WHERE Clave = TransProd.Notas) ELSE (SELECT Nombre FROM Almacen WHERE Clave = (SELECT TOP 1 ClaveCEDI FROM AgendaVendedor WHERE VendedorId = (SELECT VendedorID FROM Vendedor WHERE USUId = TransProd.MUsuarioId AND TipoEstado = 1 AND Baja = 0) AND DiaClave = TransProd.DiaClave))END) AS Almacen,"
                sCampos &= "(CASE WHEN (SELECT Nombre FROM Vendedor WHERE USUId = TransProd.MUsuarioId AND TipoEstado = 1 AND Baja = 0) IS NULL THEN (SELECT TOP 1 Nombre FROM Vendedor WHERE USUId = TransProd.MUsuarioId) ELSE (SELECT Nombre FROM Vendedor WHERE USUId = TransProd.MUsuarioId AND TipoEstado = 1 AND Baja = 0)END) AS Vendedor, "
                sCampos &= "TipoFase,(CASE WHEN TipoMotivo = 9 THEN CONVERT(BIT, 1) ELSE CONVERT(BIT, 0) END) AS Automatica, "
                sCampos &= "FechahoraAlta as Fecha"

                sFiltro = "Tipo = 2"
                If nTipoFiltro <> 0 Then
                    sFiltro &= " and " & FiltroFecha("convert(datetime,DiaClave,103)")
                End If
            End If

            loDt = oTransProd.TablaNodo.Recuperar(sFiltro, sCampos)

            GridEx1.DataSource = loDt
            GridEx1.DataMember = oTransProd.NombreTabla
            LlenarCombos()

            Me.Text = oMensaje.RecuperarDescripcion(sComponente & "_" & Me.Name) '& " (" & ObtenerCadenaFecha() & ")"
        Catch ex As LbControlError.cError
            ex.Mostrar()
        End Try
    End Sub

    Function FiltroFecha(ByVal campoFecha As String) As String
        Dim sFecha As String()
        Dim sCond As String = ""
        sFecha = sFechaInicio.Split("/")
        Dim dFechaIni As New Date(sFecha(2), sFecha(1), sFecha(0))
        Select Case nTipoFiltro
            Case 1 '=
                sCond = " convert(datetime,Convert(varchar(20)," & campoFecha & ",112)) = '" & dFechaIni.Date.ToString("s") & "' "
            Case 2 '<>
                sCond = " convert(datetime,Convert(varchar(20)," & campoFecha & ",112)) <> '" & dFechaIni.Date.ToString("s") & "' "
            Case 3 '>
                sCond = " convert(datetime,Convert(varchar(20)," & campoFecha & ",112)) > '" & dFechaIni.Date.ToString("s") & "' "
            Case 4 '<
                sCond = " convert(datetime,Convert(varchar(20)," & campoFecha & ",112)) < '" & dFechaIni.Date.ToString("s") & "' "
            Case 5 '>=
                sCond = " convert(datetime,Convert(varchar(20)," & campoFecha & ",112)) >= '" & dFechaIni.Date.ToString("s") & "' "
            Case 6 '<=
                sCond = " convert(datetime,Convert(varchar(20)," & campoFecha & ",112)) <= '" & dFechaIni.Date.ToString("s") & "' "
            Case 7 '/
                sFecha = sFechaFin.Split("/")
                Dim dFechaFin As New Date(sFecha(2), sFecha(1), sFecha(0))
                sCond = " convert(datetime,Convert(varchar(20)," & campoFecha & ",112)) between '" & dFechaIni.Date.ToString("s") & "' and '" & dFechaFin.Date.ToString("s") & "' "
        End Select
        Return sCond
    End Function

    Private Sub Consultar()
        Dim lMCargas As New MCargas

        If GridEx1.RowCount > 0 Then
            If (GridEx1.GetRow.RowType = Janus.Windows.GridEX.RowType.NewRecord Or GridEx1.GetRow.RowType = Janus.Windows.GridEX.RowType.Record) Then
                oTransProd = Nothing
                oTransProd = New cTransProd

                Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
                Try
                    oTransProd.Recuperar(GridEx1.GetRow.Cells("TransProdId").Value)
                Catch ex As LbControlError.cError
                    Me.Cursor = System.Windows.Forms.Cursors.Default
                    ex.Mostrar()
                    Exit Sub
                End Try

                Try
                    oTransProd.Tabla.Campos("MUsuarioId").Tipo = LbDatos.ETipo.Cadena
                    'oTransProd.Total = oTransProd.Total
                    'oTransProd.Grabar()
                Catch ex As LbControlError.cError
                    Me.Cursor = System.Windows.Forms.Cursors.Default
                    oConexion.DeshacerTran()
                    MsgBox(oMensaje.RecuperarDescripcion("BI0003"), MsgBoxStyle.Information, oMensaje.RecuperarDescripcion("XMensajeI"))
                    Exit Sub
                End Try
                Me.Cursor = System.Windows.Forms.Cursors.Default


                lMCargas.LEER(oTransProd)



            End If
        End If


    End Sub

    Private Sub Modificar()
        Dim lMCargas As New MCargas

        If GridEx1.RowCount > 0 Then
            If (GridEx1.GetRow.RowType = Janus.Windows.GridEX.RowType.NewRecord Or GridEx1.GetRow.RowType = Janus.Windows.GridEX.RowType.Record) Then
                oTransProd = Nothing
                oTransProd = New cTransProd

                Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
                Try
                    oTransProd.Recuperar(GridEx1.GetRow.Cells("TransProdId").Value)
                Catch ex As LbControlError.cError
                    Me.Cursor = System.Windows.Forms.Cursors.Default
                    ex.Mostrar()
                    Exit Sub
                End Try

                Try
                    oTransProd.Tabla.Campos("MUsuarioId").Tipo = LbDatos.ETipo.Cadena
                    'oTransProd.Total = oTransProd.Total
                    'oTransProd.Grabar()
                Catch ex As LbControlError.cError
                    Me.Cursor = System.Windows.Forms.Cursors.Default
                    oConexion.DeshacerTran()
                    MsgBox(oMensaje.RecuperarDescripcion("BI0003"), MsgBoxStyle.Information, oMensaje.RecuperarDescripcion("XMensajeI"))
                    Exit Sub
                End Try
                Me.Cursor = System.Windows.Forms.Cursors.Default

                If oTransProd.TipoMotivo = 9 Then 'Carga automatica
                    If oTransProd.TipoFase = 5 Then
                        If lMCargas.MODIFICAR(oTransProd) Then 'Aceptar
                            oTransProd.ModificarEn(GridEx1.DataSource)
                            ActualizarRegistro()
                        End If
                    Else
                        lMCargas.LEER(oTransProd)
                    End If
                    Exit Sub
                End If

                If oTransProd.Tipo = TipoTRP.Sobrante Then
                    If lMCargas.MODIFICAR(oTransProd) Then 'Aceptar
                        oTransProd.ModificarEn(GridEx1.DataSource)
                        ActualizarRegistro()
                    End If
                Else
                    If Convert.ToDateTime(oTransProd.DiaClave, Globalization.CultureInfo.CreateSpecificCulture("ES-MX")) < oConexion.ObtenerFecha.Date Then
                        MsgBox(oMensaje.RecuperarDescripcion("E0524", New String() {oConexion.ObtenerFecha.Date}), MsgBoxStyle.Critical, oMensaje.RecuperarDescripcion("XMensajeE"))
                        lMCargas.LEER(oTransProd)
                    Else
                        If oTransProd.TipoFase = 1 Then
                            'MsgBox(oMensaje.RecuperarDescripcion("E0524", New String() {oConexion.ObtenerFecha.Date}), MsgBoxStyle.Critical, oMensaje.RecuperarDescripcion("XMensajeE"))
                            lMCargas.LEER(oTransProd)
                        Else
                            If lMCargas.MODIFICAR(oTransProd) Then 'Aceptar
                                oTransProd.ModificarEn(GridEx1.DataSource)
                                ActualizarRegistro()
                            End If
                        End If
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub ActualizarRegistro()
        Dim ldt As DataTable = GridEx1.DataSource
        Dim ldr As DataRow = ldt.Select("TransProdId='" & oTransProd.TransProdID & "'")(0)

        If oTransProd.Notas <> "" Then
            Dim oAlmacen As New ERMALMLOG.cAlmacen
            Dim ldtALM As DataTable = oAlmacen.Tabla.Recuperar("Clave='" & lbGeneral.ValidaFormatoSQLString(oTransProd.Notas) & "'")
            If ldtALM.Rows.Count > 0 Then
                ldr!Almacen = ldtALM.Rows(0)!Nombre
            Else
                ldr!Almacen = ""
            End If
        Else
            ldr!Almacen = ""
        End If

        If oTransProd.MUsuarioID <> "" Then
            Dim oVendedor As New ERMVENLOG.cVendedor
            Dim ldtVEN As DataTable = oVendedor.Tabla.Recuperar("USUId='" & oTransProd.MUsuarioID & "' AND TipoEstado=1 AND Baja=0")
            If ldtVEN.Rows.Count > 0 Then
                ldr!Vendedor = ldtVEN.Rows(0)!Nombre
            Else
                ldr!Vendedor = ""
            End If
        Else
            ldr!Vendedor = ""
        End If

        ldr!Automatica = (oTransProd.TipoMotivo = 9)
        ldr!Fecha = oTransProd.FechaHoraAlta
    End Sub

    Private Sub ConfigurarSobrantes(ByVal pvActivar As Boolean)
        Me.Bar1.Items(3).Visible = pvActivar
        Me.Bar1.Items(4).Visible = pvActivar
        Me.Bar1.Items(5).Visible = pvActivar

        'Me.GridEx1.RootTable.Columns("DiaClave").Visible = pvActivar
        'Me.GridEx1.RootTable.Columns("Almacen").Visible = pvActivar
        'Me.GridEx1.RootTable.Columns("Vendedor").Visible = pvActivar
        'Me.GridEx1.RootTable.Columns("Automatica").Visible = pvActivar
        Me.GridEx1.RootTable.Columns("Fecha").Visible = Not pvActivar
        Me.GridEx1.RootTable.Columns("TransProdId").Visible = False
        Me.GridEx1.RootTable.Columns.Remove("DiaClave")
        'Me.GridEx1.RootTable.Columns.Remove("Almacen")
        Me.GridEx1.RootTable.Columns.Remove("Vendedor")
        Me.GridEx1.RootTable.Columns.Remove("Automatica")

    End Sub
#End Region

#Region " Eventos "
    Private Sub NCargas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
#If DEBUG Then
        'oConexion.Conectar("Provider=SQLOLEDB;Data Source=localhost\SQL2008;user id=sa;password=dbsa;initial catalog=floriculturanew")
        oConexion.Conectar("Provider=SQLOLEDB;Data Source=localhost\sql2008;user id=sa;password=dbsa;initial catalog=Altenia")
        oMensaje = New BASMENLOG.CMensaje
        oMensaje.LlenarDataSet()
        lbGeneral.cParametros.UsuarioID = "Admin"
        'lbGeneral.cParametros.UsuarioID = "26PKB2C2AHNRELF"
        Dim oKeyGen As New lbGeneral.cKeyGen
        oAcceso = New LbAcceso.cAcceso
        oAcceso.Modificar = True
        oAcceso.Leer = True
        oAcceso.Crear = True
        oAcceso.Print = True
        oAcceso.Otros = True
        eTipoCarga = TipoTRP.Carga
#End If
        oMensaje = New BASMENLOG.CMensaje
        oTransProd = New cTransProd

        Try
            'sFechaInicio = oTransProd.Tabla.Conexion.EjecutarComandoScalar("select top 1 DiaClave from Dia order by mfechahora desc")
            'If sFechaInicio Is Nothing OrElse sFechaInicio = "" Then
            sFechaInicio = DateTime.Now.ToString("dd/MM/yyyy")
            'End If
            sFechaFin = sFechaInicio
            nTipoFiltro = 1
            Actualizar()
            ConfigurarGrid()

            If Me.eTipoCarga = TipoTRP.Sobrante Then
                ConfigurarSobrantes(False)
                Me.Text = oMensaje.RecuperarDescripcion("XARegistroSobrantes")
            Else
                'ConfigurarSobrantes(True)
                Me.Text = oMensaje.RecuperarDescripcion(sComponente & "_" & Me.Name)
            End If

        Catch ex As LbControlError.cError
            ex.Mostrar()
        End Try
    End Sub

    Private Sub NGeneral_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Try
            lbGeneral.GrabarConfiguracionGrid(sComponente, Me.Name, GridEx1, oTransProd.NombreTabla)
        Catch ex As LbControlError.cError
            ex.Mostrar()
            Exit Sub
        End Try
    End Sub


    Private Sub btCrear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btCrear.Click
        Dim lMGeneral As New MCargas
        Try
            'oTransProd.Limpiar()
            oTransProd = New cTransProd()
            oTransProd.Tipo = Me.eTipoCarga
            If lMGeneral.CREAR(oTransProd) Then
                oTransProd.InsertarEn(GridEx1.DataSource)
                GridEx1.MoveLast()
                ActualizarRegistro()
            End If
        Catch ex As LbControlError.cError
            ex.Mostrar()
        End Try
    End Sub

    Private Sub btModificar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btModificar.Click
        If oAcceso.Modificar Then
            Call Modificar()
        Else
            If oAcceso.Leer Then
                Call Consultar()
            End If
        End If
    End Sub

    Private Sub GridEX1_RowDoubleClick(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.RowActionEventArgs) Handles GridEx1.RowDoubleClick
        If oAcceso.Modificar Then
            Call Modificar()
        Else
            If oAcceso.Leer Then
                Call Consultar()
            End If
        End If
    End Sub

    Private Sub btActualizar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btActualizar.Click
        Call Actualizar()
    End Sub

    Private Sub btReporteCarga_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btReporteCarga.Click
        Dim oRep As New PRepCargas
        If GridEx1.RowCount > 0 Then
            If (GridEx1.GetRow.RowType = Janus.Windows.GridEX.RowType.NewRecord Or GridEx1.GetRow.RowType = Janus.Windows.GridEX.RowType.Record) Then
                Try
                    oTransProd.Recuperar(GridEx1.GetRow.Cells("TransProdId").Value)
                    oRep.UsuID = oTransProd.MUsuarioID
                    oRep.CargaID = oTransProd.TransProdID
                    oRep.Inicio(oAcceso)
                    Exit Sub
                Catch ex As LbControlError.cError
                    ex.Mostrar()
                    Exit Sub
                Catch ex As Exception
                    MsgBox(ex.Message())
                End Try
                Exit Sub
            End If
        End If

        oRep.Inicio(oAcceso)
    End Sub

    Private Sub btGenerar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btGenerar.Click
        Dim lMGeneral As New MCargas
        Try
            oTransProd.Limpiar()
            oTransProd.Tipo = Me.eTipoCarga
            If Me.eTipoCarga = TipoTRP.Carga Then
                oTransProd.TipoMotivo = 9
            End If
            If lMGeneral.CREAR(oTransProd) Then
                oTransProd.InsertarEn(GridEx1.DataSource)
                Dim ldt As DataTable = GridEx1.DataSource
                GridEx1.MoveLast()
                ActualizarRegistro()
            End If
        Catch ex As LbControlError.cError
            ex.Mostrar()
        End Try
    End Sub

    Private Sub btFiltroFecha_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btFiltroFecha.Click
        Dim oFecha As New Fechas
        If oFecha.SELECCIONAR(nTipoFiltro, sFechaInicio, sFechaFin) Then
            Actualizar()
        End If
    End Sub
#End Region

    Private Sub GridEx1_FormattingRow(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.RowLoadEventArgs) Handles GridEx1.FormattingRow

    End Sub
End Class

Public Class NSobrante
    Inherits NCargas

    Private Shared oInstancia As NCargas = Nothing

    Public Overloads Shared Function Instance() As NCargas
        If oInstancia Is Nothing OrElse oInstancia.IsDisposed = True Then
            oInstancia = New NCargas
        End If
        Return oInstancia
    End Function

    Sub New()
        eTipoCarga = TipoTRP.Sobrante
    End Sub
    
End Class
