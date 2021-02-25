Imports ERMTRPLOG

Public Class NReclasificado
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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim GridEx1_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NReclasificado))
        Me.btCrear = New DevComponents.DotNetBar.ButtonItem
        Me.btModificar = New DevComponents.DotNetBar.ButtonItem
        Me.btActualizar = New DevComponents.DotNetBar.ButtonItem
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridEx1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btCrear, Me.btModificar, Me.btActualizar})
        '
        'GridEx1
        '
        Me.GridEx1.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridEx1.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        GridEx1_DesignTimeLayout.LayoutString = resources.GetString("GridEx1_DesignTimeLayout.LayoutString")
        Me.GridEx1.DesignTimeLayout = GridEx1_DesignTimeLayout
        Me.GridEx1.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.GridEx1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'btCrear
        '
        Me.btCrear.Icon = CType(resources.GetObject("btCrear.Icon"), System.Drawing.Icon)
        Me.btCrear.Name = "btCrear"
        Me.btCrear.Text = "ButtonItem1"
        '
        'btModificar
        '
        Me.btModificar.Icon = CType(resources.GetObject("btModificar.Icon"), System.Drawing.Icon)
        Me.btModificar.Name = "btModificar"
        Me.btModificar.Text = "ButtonItem1"
        '
        'btActualizar
        '
        Me.btActualizar.Icon = CType(resources.GetObject("btActualizar.Icon"), System.Drawing.Icon)
        Me.btActualizar.Name = "btActualizar"
        Me.btActualizar.Text = "ButtonItem1"
        '
        'NReclasificado
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(844, 666)
        Me.DoubleBuffered = True
        Me.Name = "NReclasificado"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridEx1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Variables "
    Private Shared oInstance As NReclasificado = Nothing
    Private oConexion As LbConexion.cConexion = LbConexion.cConexion.Instancia
    Private oTransProd As cTransProd
    Private oMensaje As BASMENLOG.CMensaje
    Private sComponente As String = "ERMTRPESC"
    'Private tTipoTRP As TipoTRP
    Dim oAcceso As LbAcceso.cAcceso
#End Region

#Region " Metodos "
    Public Shared Function Instance() As NReclasificado
        If oInstance Is Nothing OrElse oInstance.IsDisposed = True Then
            oInstance = New NReclasificado
        End If

        Return oInstance
    End Function

    Sub Inicio(ByVal pvAcceso As LbAcceso.cAcceso)
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

        btCrear.Tooltip = oMensaje.RecuperarDescripcion("btCrear")
        btModificar.Tooltip = oMensaje.RecuperarDescripcion("btModificar")
        btActualizar.Tooltip = oMensaje.RecuperarDescripcion("btActualizar")

        If Not oAcceso.Crear Then
            btCrear.Enabled = False
        End If
        If Not oAcceso.Modificar And Not oAcceso.Leer Then
            btModificar.Enabled = False
        End If
        If oAcceso.Leer And Not oAcceso.Modificar Then

            btModificar.Tooltip = oMensaje.RecuperarDescripcion("xconsultar")
          
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

    Private Sub Actualizar()
        Try
            Dim loDt As DataTable
            loDt = oTransProd.TablaNodo.Recuperar("Tipo=" & 22, " TransProdId,Folio,DiaClave,(SELECT Nombre FROM Almacen WHERE Clave=TransProd.Notas) as Almacen,(CASE WHEN (SELECT Nombre FROM Vendedor WHERE USUId=TransProd.MUsuarioId AND TipoEstado=1 AND Baja=0) IS NULL THEN (SELECT Top 1 Nombre FROM Vendedor WHERE USUId=TransProd.MUsuarioId) ELSE (SELECT Nombre FROM Vendedor WHERE USUId=TransProd.MUsuarioId AND TipoEstado=1 AND Baja=0)END) as Vendedor,TipoFase")
            GridEx1.DataSource = loDt
            GridEx1.DataMember = oTransProd.NombreTabla
            LlenarCombos()
        Catch ex As LbControlError.cError
            ex.Mostrar()
        End Try
    End Sub
    Private Sub Consultar()
        Dim lMCargas As New MCargas

        If GridEx1.RowCount > 0 Then
            If (GridEx1.GetRow.RowType = Janus.Windows.GridEX.RowType.NewRecord Or GridEx1.GetRow.RowType = Janus.Windows.GridEX.RowType.Record) Then
                Try
                    oTransProd.Recuperar(GridEx1.GetRow.Cells("TransProdId").Value)
                Catch ex As LbControlError.cError
                    ex.Mostrar()
                    Exit Sub
                End Try

                Try
                    oTransProd.Tabla.Campos("MUsuarioId").Tipo = LbDatos.ETipo.Cadena
                    oTransProd.Total = oTransProd.Total
                    oTransProd.Grabar()
                Catch ex As LbControlError.cError
                    oConexion.DeshacerTran()
                    MsgBox(oMensaje.RecuperarDescripcion("BI0003"), MsgBoxStyle.Information, oMensaje.RecuperarDescripcion("XMensajeI"))
                    Exit Sub
                End Try


                lMCargas.LEER(oTransProd)

            End If
        End If
    End Sub
    Private Sub Modificar()
        Dim lMCargas As New MCargas

        If GridEx1.RowCount > 0 Then
            If (GridEx1.GetRow.RowType = Janus.Windows.GridEX.RowType.NewRecord Or GridEx1.GetRow.RowType = Janus.Windows.GridEX.RowType.Record) Then
                Try
                    oTransProd.Recuperar(GridEx1.GetRow.Cells("TransProdId").Value)
                Catch ex As LbControlError.cError
                    ex.Mostrar()
                    Exit Sub
                End Try

                Try
                    oTransProd.Tabla.Campos("MUsuarioId").Tipo = LbDatos.ETipo.Cadena
                    oTransProd.Total = oTransProd.Total
                    oTransProd.Grabar()
                Catch ex As LbControlError.cError
                    oConexion.DeshacerTran()
                    MsgBox(oMensaje.RecuperarDescripcion("BI0003"), MsgBoxStyle.Information, oMensaje.RecuperarDescripcion("XMensajeI"))
                    Exit Sub
                End Try

                If oTransProd.TipoFase = 1 Then
                    Dim sFolioCarga As String = oTransProd.RecuperarCargaLigada
                    MsgBox(oMensaje.RecuperarDescripcion("E0572", New String() {sFolioCarga}), MsgBoxStyle.Critical, oMensaje.RecuperarDescripcion("XMensajeE"))
                    lMCargas.LEER(oTransProd)
                Else
                    If lMCargas.MODIFICAR(oTransProd) Then 'Aceptar
                        oTransProd.ModificarEn(GridEx1.DataSource)
                        ActualizarRegistro()
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub ActualizarRegistro(Optional ByRef ldr As DataRow = Nothing)
        If Not IsNothing(ldr) Then
            oTransProd.Recuperar(ldr!TransProdId)
            If oTransProd.Notas <> "" Then
                Dim oAlmacen As New ERMALMLOG.cAlmacen
                Dim ldt As DataTable = oAlmacen.Tabla.Recuperar("Clave='" & lbGeneral.ValidaFormatoSQLString(oTransProd.Notas) & "'")
                If ldt.Rows.Count > 0 Then
                    ldr!Almacen = ldt.Rows(0)!Nombre
                Else
                    ldr!Almacen = ""
                End If
            Else
                ldr!Almacen = ""
            End If

            If oTransProd.MUsuarioID <> "" Then
                Dim oVendedor As New ERMVENLOG.cVendedor
                Dim ldt As DataTable = oVendedor.Tabla.Recuperar("USUId='" & oTransProd.MUsuarioID & "' AND TipoEstado=1 AND Baja=0")
                If ldt.Rows.Count > 0 Then
                    ldr!Vendedor = ldt.Rows(0)!Nombre
                Else
                    ldr!Vendedor = ""
                End If
            Else
                ldr!Vendedor = ""
            End If
            GridEx1.Refresh()
        Else
            If GridEx1.RowCount > 0 Then
                oTransProd.Recuperar(GridEx1.GetValue("TransProdId"))
                If oTransProd.Notas <> "" Then
                    Dim oAlmacen As New ERMALMLOG.cAlmacen
                    Dim ldt As DataTable = oAlmacen.Tabla.Recuperar("Clave='" & lbGeneral.ValidaFormatoSQLString(oTransProd.Notas) & "'")
                    If ldt.Rows.Count > 0 Then
                        GridEx1.SetValue("Almacen", ldt.Rows(0)!Nombre)
                    Else
                        GridEx1.SetValue("Almacen", "")
                    End If
                Else
                    GridEx1.SetValue("Almacen", "")
                End If

                If oTransProd.MUsuarioID <> "" Then
                    Dim oVendedor As New ERMVENLOG.cVendedor
                    Dim ldt As DataTable = oVendedor.Tabla.Recuperar("USUId='" & oTransProd.MUsuarioID & "' AND TipoEstado=1 AND Baja=0")
                    If ldt.Rows.Count > 0 Then
                        GridEx1.SetValue("Vendedor", ldt.Rows(0)!Nombre)
                    Else
                        GridEx1.SetValue("Vendedor", "")
                    End If
                Else
                    GridEx1.SetValue("Vendedor", "")
                End If
                GridEx1.Refresh()
            End If
        End If
    End Sub
#End Region

#Region " Eventos "

    Private Sub NCargas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
#If DEBUG Then
        'oConexion.Conectar("Provider=SQLOLEDB;Data Source=rafiki;user id=sa;password=dbsa;initial catalog=ROUTE")
        oConexion.Conectar("Provider=SQLOLEDB;Data Source=192.168.0.76\sql2008;user id=sa;password=dbsa;initial catalog=jolladeus")
        oMensaje = New BASMENLOG.CMensaje
        oMensaje.LlenarDataSet()
        'lbGeneral.cParametros.UsuarioID = "Admin"
        lbGeneral.cParametros.UsuarioID = "26PKB2C2AHNRELF"
        Dim oKeyGen As New lbGeneral.cKeyGen
        oAcceso = New LbAcceso.cAcceso
        oAcceso.Modificar = True
        oAcceso.Leer = True
        oAcceso.Crear = True
#End If
        oMensaje = New BASMENLOG.CMensaje
        oTransProd = New cTransProd

        Me.Text = oMensaje.RecuperarDescripcion(sComponente & "_" & Me.Name)

        


        Try
            Actualizar()
            ConfigurarGrid()
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
            oTransProd.Limpiar()
            oTransProd.Tipo = 22
            If lMGeneral.CREAR(oTransProd) Then
                oTransProd.InsertarEn(GridEx1.DataSource)
                Dim ldt As DataTable = GridEx1.DataSource
                GridEx1.MoveLast()
                ActualizarRegistro(ldt.Select("TransProdId='" & oTransProd.TransProdID & "'")(0))
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

#End Region
End Class
