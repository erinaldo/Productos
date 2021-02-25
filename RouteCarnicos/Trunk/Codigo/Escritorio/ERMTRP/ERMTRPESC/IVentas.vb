Imports ERMTRPLOG
Imports BASMENLOG
Public Class IVentas
    Inherits FormasBase.Seleccionar01

#Region "Variables"
    Private oMensaje As CMensaje
    Private oConexion As LbConexion.cConexion = LbConexion.cConexion.Instancia
    Private vcClienteClave As String = ""
    Private vcConsultar As Boolean = True
    Private vcDatos As DataTable

#End Region

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
#If DEBUG Then
        If oConexion.Estado = ConnectionState.Closed Then
            'oConexion.Conectar("Provider=SQLOLEDB.1;Persist Security Info=True;User ID=sa;password=dbsa;Initial Catalog=LACTIGURT230;Data Source=localhost\sqlexpress")
            oConexion.Conectar("Provider=SQLOLEDB;User ID=sa;password=Pa55word.;Initial Catalog=CRJ;Data Source=localhost\SQL2008R2")
        End If

        'lbGeneral.cParametros.UsuarioID = "Admin"
        lbGeneral.cParametros.UsuarioID = "26PKB2C2AHNRELF"
        vcClienteClave = "0000100059"


#End If
        oMensaje = New BASMENLOG.CMensaje


        ConfigurarInterfaz()
        ConfigurarGrid()

    End Sub

#Region "Inicio"
    Private Sub ConfigurarInterfaz()
        Dim lTootTip As New System.Windows.Forms.ToolTip

        'Titulos Controles
        Me.lblFecha.Text = oMensaje.RecuperarDescripcion("TRPFecha")
        lbGeneral.LlenarComboBox(cbTipoFiltro, "BFNUMERI", -1)

        'Titulos Botones
        Me.BtAceptar.Text = oMensaje.RecuperarDescripcion("btAceptar")
        Me.BtCancelar.Text = oMensaje.RecuperarDescripcion("btCancelar")

        Dim oToolTip As New ToolTip
        oToolTip.SetToolTip(BtAceptar, oMensaje.RecuperarDescripcion("btAceptarT"))
        oToolTip.SetToolTip(BtCancelar, oMensaje.RecuperarDescripcion("btCancelarT"))

        Me.Text = oMensaje.RecuperarDescripcion("ERMTRPESC_IVENTAS")

    End Sub
    Private Sub ConfigurarGrid()
        Dim vlColumna As Janus.Windows.GridEX.GridEXColumn

        With Gridex1.RootTable
            For Each vlColumna In .Columns
                If vlColumna.Key = "Seleccion" Then
                    vlColumna.Position = 0
                    vlColumna.Caption = ""
                    vlColumna.Width = 50
                Else
                    Select Case vlColumna.Key.ToLower
                        Case "razonsocial", "nombrecorto"
                            vlColumna.Caption = oMensaje.RecuperarDescripcion("CLI" & vlColumna.Key)
                            vlColumna.HeaderToolTip = oMensaje.RecuperarDescripcion("CLI" & vlColumna.Key & "T")
                        Case "clave"
                            vlColumna.Caption = oMensaje.RecuperarDescripcion("CCCClienteClave")
                            vlColumna.HeaderToolTip = oMensaje.RecuperarDescripcion("CCCClienteClaveT")
                        Case "folio"
                            vlColumna.Caption = oMensaje.RecuperarDescripcion("TRP" & vlColumna.Key)
                            vlColumna.HeaderToolTip = oMensaje.RecuperarDescripcion("TRP" & vlColumna.Key & "T")
                        Case "fecha"
                            vlColumna.Caption = oMensaje.RecuperarDescripcion("TRP" & vlColumna.Key)
                            vlColumna.HeaderToolTip = oMensaje.RecuperarDescripcion("TRPFECHAHORAALTAT")
                        Case "total"
                            vlColumna.Caption = oMensaje.RecuperarDescripcion("TRP" & vlColumna.Key)
                            vlColumna.HeaderToolTip = oMensaje.RecuperarDescripcion("TRP" & vlColumna.Key & "T")
                        Case "tipofase"
                            vlColumna.Caption = oMensaje.RecuperarDescripcion("TRP" & vlColumna.Key)
                            vlColumna.HeaderToolTip = oMensaje.RecuperarDescripcion("TRP" & vlColumna.Key & "T")
                            lbGeneral.LlenarColumna(vlColumna, "TRPFASE")
                    End Select

                End If
            Next
        End With

    End Sub
    Private Sub Carga_Grid()
        Dim dFechaIni As Date = calFechaIni.Value
        Dim dFechaFin As Date = calFechaFin.Value
        Dim iTipo As Integer = -1
        If Not cbTipoFiltro.SelectedValue Is Nothing Then
            iTipo = Integer.Parse(cbTipoFiltro.SelectedValue)
        End If

        If vcConsultar Then
            Dim loPedido As New cTransProd
            vcDatos = loPedido.ObtenerVentasCliente(vcClienteClave, dFechaIni, dFechaFin, iTipo)
        Else
            RaiseEvent ObtenerDatos(vcDatos, dFechaIni, dFechaFin, iTipo)
        End If
        If Not vcDatos.Columns.Contains("Seleccion") Then
            vcDatos.Columns.Add("Seleccion", GetType(Boolean))
        End If

        For Each f As DataRow In vcDatos.Rows
            f("Seleccion") = False
        Next

        Gridex1.DataSource = vcDatos
    End Sub
    Private Sub IVentas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Carga_Grid()
    End Sub
#End Region

#Region "Ingreso"
    Public Function Seleccionar(ByVal pvClienteClave As String) As DataTable
        Return Seleccionar(pvClienteClave, Nothing)
    End Function
    Public Function Seleccionar(ByVal pvClienteClave As String, ByVal pvDatosIniciales As DataTable) As DataTable
        vcClienteClave = pvClienteClave
        If Not pvDatosIniciales Is Nothing Then
            vcConsultar = False
            vcDatos = pvDatosIniciales
        End If

        If Me.ShowDialog() <> Windows.Forms.DialogResult.OK Then
            vcDatos.Rows.Clear()
        End If
        Return vcDatos
    End Function
#End Region

#Region "Filtar"
    Private Sub btFiltrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btFiltrar.Click
        Carga_Grid()
    End Sub
    Private Sub cbTipoFiltro_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbTipoFiltro.SelectedValueChanged
        calFechaFin.Enabled = (Convert.ToInt32(cbTipoFiltro.SelectedValue) = 7)
    End Sub
    Public Event ObtenerDatos(ByRef tabla As DataTable, ByVal fechaInicial As DateTime, ByVal fechaFinal As DateTime, ByVal tipoFiltro As Integer)


#End Region

#Region "Detalle"
    Private Sub MostrarDetalle()
        If Not Gridex1.CurrentRow Is Nothing AndAlso Gridex1.CurrentRow.AbsolutePosition > 0 Then
            Dim vDetalle As New IDetallePedidos()
            vDetalle.ConsultarDetalle(New Generic.List(Of String)(New String() {Gridex1.CurrentRow.Cells("TransProdId").Value.ToString()}))
        End If
    End Sub
    Private Sub Gridex1_RowDoubleClick(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.RowActionEventArgs) Handles Gridex1.RowDoubleClick
        MostrarDetalle()
    End Sub
    Private Sub Gridex1_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Gridex1.KeyUp
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Execute Then
            MostrarDetalle()
        End If
    End Sub
#End Region

   
    Private Sub BtComando_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtAceptar.Click, BtCancelar.Click
        If sender Is BtAceptar Then
            Dim indice As Integer = 0
            Do While vcDatos.Rows.Count > indice
                Dim fila As DataRow = vcDatos.Rows(indice)
                If Not fila("Seleccion") Then
                    vcDatos.Rows.RemoveAt(indice)
                Else
                    indice += 1
                End If
            Loop           
        End If
        Me.Close()
    End Sub

End Class