Imports BASMENLOG
Imports ERMCEELOG


Public Class IGeneral
    Inherits FormasBase.Seleccionar01

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    Public Sub New(ByVal pvMultiSelect As Boolean, Optional ByVal pvCamposSelect As String = "EsquemaID, EsquemaIDPadre, Nombre, Abreviatura, Orden, Clave, Tipo, TipoEstado,Nivel", Optional ByVal pvFiltro As String = "")
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        vlMultiSelect = pvMultiSelect
        vlCamposSelect = pvCamposSelect
        vlFiltro = pvFiltro
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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim GridEXLayout1 As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        CType(Me.Gridex1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Gridex1
        '
        GridEXLayout1.LayoutString = "<GridEXLayoutData><RootTable><Columns Collection=""true""><Column0 ID=""Seleccionado" & _
        """><Bound>False</Bound><ColumnType>CheckBox</ColumnType><EditType>CheckBox</EditT" & _
        "ype><HeaderAlignment>Center</HeaderAlignment><Key>Seleccionado</Key><Position>0<" & _
        "/Position><Width>36</Width></Column0><Column1 ID=""MDBMensajeID""><Caption>ID</Cap" & _
        "tion><DataMember>MDBMensajeID</DataMember><HeaderAlignment>Center</HeaderAlignme" & _
        "nt><Key>MDBMensajeID</Key><Position>1</Position><Visible>False</Visible></Column" & _
        "1><Column2 ID=""MDBMensajeTipo""><Caption>Tipo</Caption><DataMember>MDBMensajeTipo" & _
        "</DataMember><HeaderAlignment>Center</HeaderAlignment><Key>MDBMensajeTipo</Key><" & _
        "Position>2</Position><Width>164</Width></Column2><Column3 ID=""Numero""><Caption>N" & _
        "úmero</Caption><DataMember>Numero</DataMember><HeaderAlignment>Center</HeaderAli" & _
        "gnment><Key>Numero</Key><Position>3</Position><Width>108</Width></Column3><Colum" & _
        "n4 ID=""Descripcion""><Caption>Descripción</Caption><DataMember>Descripcion</DataM" & _
        "ember><HeaderAlignment>Center</HeaderAlignment><Key>Descripcion</Key><Position>4" & _
        "</Position><Width>388</Width></Column4></Columns><GroupCondition ID="""" /><Key>Pe" & _
        "rfil</Key></RootTable></GridEXLayoutData>"
        Me.Gridex1.DesignTimeLayout = GridEXLayout1
        Me.Gridex1.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.Gridex1.Location = New System.Drawing.Point(8, 16)
        Me.Gridex1.Name = "Gridex1"
        Me.Gridex1.Size = New System.Drawing.Size(732, 424)
        Me.Gridex1.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation
        '
        'BtAceptar
        '
        Me.BtAceptar.Location = New System.Drawing.Point(524, 452)
        Me.BtAceptar.Name = "BtAceptar"
        '
        'BtCancelar
        '
        Me.BtCancelar.Location = New System.Drawing.Point(636, 452)
        Me.BtCancelar.Name = "BtCancelar"
        '
        'IGeneral
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(750, 480)
        Me.Name = "IGeneral"
        Me.Text = "|"
        CType(Me.Gridex1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public vcConexion As LbConexion.cConexion = LbConexion.cConexion.Instancia
    Private vgDataSet As New DataSet    
    Public vcUsuarioID As Integer
    Private vlCamposSelect As String = "CenExpedicionID,CentroExpPadreID, Nombre, rfc,numcertificado,municipio, entidad, TipoEstado"
    Private vcMensaje As CMensaje
    Private vlCentroExp As New CCentroExp
    Private vlMultiSelect As Boolean
    Private vlFiltro As String

    Public OcultarNombre As Boolean
    Public OcultarAbreviatura As Boolean
    Public OcultarOrden As Boolean
    Public OcultarClave As Boolean
    Public OcultarTipo As Boolean

    Public Seleccion As New ArrayList

    Public Structure slPadre
        Dim PadreNivel As Integer
        Dim PadreID As String
        Dim PadreClave As String
        Dim PadreNombre As String
    End Structure

    Private Sub IGeneral_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Carga_Grid()
    End Sub

    Public Sub Inicio(ByVal pvAcceso As LbAcceso.cAcceso)
        vcMensaje = New BASMENLOG.CMensaje
        Me.Show()
    End Sub


    Public Sub Carga_Grid()
        Try
            vlCentroExp = Nothing
            vlCentroExp = New CCentroExp

            vcMensaje = New CMensaje
            vcUsuarioID = 1

            Me.Text = vcMensaje.RecuperarDescripcion("ERMCEEESC_IGeneral")

            Gridex1.ClearStructure()

            vlCentroExp.DataSet.MultiSelectData = vlMultiSelect

            ''

            ''
            Dim tabla As New CCentroExp.CCentroExpTabla(vlCentroExp.vctCentroExp)
            Gridex1.DataSource = tabla.RecuperarTabla(" tipoestado=1 and tipo=0 ", "centroexpid,nombre,rfc,numcertificado,calle,numext,municipio,entidad")

            Gridex1.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False
            'Gridex1.Hierarchical = True
            Gridex1.RetrieveStructure(True)

            Dim vlTbls As Janus.Windows.GridEX.GridEXTable
            vlTbls = Gridex1.RootTable

            Ocultar_Columnas(vlTbls)

        Catch ex As LbControlError.cError
            ex.Mostrar()
        Catch ex As Exception
            Dim vlError As New LbControlError.cError("BF0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(ex.Source)}, , ex.Message)
            vlError.Mostrar()
        End Try

    End Sub

    Private Sub Ocultar_Columnas(ByVal vlTblGrid As Janus.Windows.GridEX.GridEXTable)

        Dim vlColumna As Janus.Windows.GridEX.GridEXColumn
        'Dim vlColumna1 As Janus.Windows.GridEX.GridEXFieldChooser

        With vlTblGrid

            If Me.vlMultiSelect Then
                .Columns("Seleccion").ColumnType = Janus.Windows.GridEX.ColumnType.CheckBox
                .Columns("Seleccion").EditType = Janus.Windows.GridEX.EditType.CheckBox
                .Columns("Seleccion").FormatMode = Janus.Windows.GridEX.FormatMode.UseIFormattable
                .Columns("Seleccion").Width = 30
                '.Columns("Seleccion").UseHeaderSelector = False
                '.Columns("Seleccion").CheckBoxTriState = False
                '.Columns("Seleccion").CheckBoxTrueValue = True
                .Columns("Seleccion").CheckBoxNullValue = False
                '.Columns("Seleccion").CheckBoxFalseValue = False
                .Columns("Seleccion").ActAsSelector() = True
                '.Columns("Seleccion").AllowSort() = False
                Gridex1.UpdateMode = Janus.Windows.GridEX.UpdateMode.RowUpdate

            End If

          
            For Each vlColumna In vlTblGrid.Columns
                If Not vlColumna.Key = "Seleccion" Then
                    vlColumna.EditType = Janus.Windows.GridEX.EditType.NoEdit
                    vlColumna.FilterEditType = Janus.Windows.GridEX.EditType.TextBox
                    vlColumna.Caption = vcMensaje.RecuperarDescripcion("CEE" + vlColumna.Key)
                    vlColumna.HeaderToolTip = vcMensaje.RecuperarDescripcion("CEE" + vlColumna.Key + "T")
                    vlColumna.HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
                Else
                    vlColumna.Caption = ""

                End If
            Next

        

        End With

    End Sub

    Private Sub LlenarTipoEstado(ByVal vlTbl As Janus.Windows.GridEX.GridEXTable)
        Try
            lbGeneral.LlenarColumna(vlTbl.Columns("TipoEstado"), "EDOREG")
        Catch ex As LbControlError.cError
            ex.Mostrar()
        End Try
    End Sub

    Private Sub LlenarTipo(ByVal vlTbl As Janus.Windows.GridEX.GridEXTable)
        Try
            lbGeneral.LlenarColumna(vlTbl.Columns("Tipo"), "TCEEUEMA")
        Catch ex As LbControlError.cError
            ex.Mostrar()
        End Try
    End Sub


    Private Sub BtAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtAceptar.Click
        Dim vlRegistros() As Janus.Windows.GridEX.GridEXRow
        Dim datrow As Data.DataRow
        Seleccion = New ArrayList


        If Me.vlMultiSelect Then
            Me.Gridex1.UpdateData()


            vlRegistros = Gridex1.GetCheckedRows()

            For i As Integer = 0 To vlRegistros.Length - 1
                datrow = CType(Gridex1.DataSource, DataSet).Tables(0).NewRow()
                For y As Integer = 0 To datrow.ItemArray.Length - 1
                    'Application.DoEvents()
                    datrow(y) = vlRegistros(i).Cells(y).Value
                Next y
                Seleccion.Add(datrow)

            Next i



        Else

            Dim vlCentroExp As New CCentroExp
            Dim drs As DataTable = vlCentroExp.Tabla.RecuperarTabla("CentroExpID='" & Gridex1.GetRow.Cells("CentroExpID").Value().ToString.Replace("'", "''") & "'", "*")
            Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
                For Each dr As Data.DataRow In drs.Rows
                    Application.DoEvents()
                    Seleccion.Add(dr)
                Next

        End If

        Me.Close()

    End Sub



   
End Class
