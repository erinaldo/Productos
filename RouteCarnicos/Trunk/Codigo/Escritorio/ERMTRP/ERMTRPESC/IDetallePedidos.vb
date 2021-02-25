Imports ERMTRPLOG
Imports BASMENLOG
Imports System.Collections.Generic
Public Class IDetallePedidos
    Inherits FormasBase.Seleccionar01

    Dim vcConexion As LbConexion.cConexion
    Private oMensaje As CMensaje
    Private vcMultiseleccion As Boolean = False
    Public vcSeleccion As ArrayList
    Private oConexion As LbConexion.cConexion = LbConexion.cConexion.Instancia
    Dim oAcceso As LbAcceso.cAcceso

#Region "Funciones"

    Public Sub Carga_Grid(ByVal tabla As DataTable)
        Cursor.Current = Cursors.WaitCursor
        Try


            Gridex1.DataSource = tabla
            'Gridex1.RetrieveStructure()



        Catch ex As LbControlError.cError
            ex.Mostrar()
        Catch ex As Exception
            Dim vlError As New LbControlError.cError("BF0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(ex.Source)}, , ex.Message)
            vlError.Mostrar()
        End Try

        Cursor.Current = Cursors.Default
    End Sub

    Private Sub ConfigurarInterfaz()
        Dim lTootTip As New System.Windows.Forms.ToolTip

        'Titulos Controles
        
        'Titulos Botones
        Me.BtAceptar.Text = oMensaje.RecuperarDescripcion("btAceptar")
        Me.BtCancelar.Text = oMensaje.RecuperarDescripcion("btCancelar")

        Dim oToolTip As New ToolTip
        oToolTip.SetToolTip(BtAceptar, oMensaje.RecuperarDescripcion("btAceptarT"))
        oToolTip.SetToolTip(BtCancelar, oMensaje.RecuperarDescripcion("btCancelarT"))
    End Sub


    Sub ConfigurarGrid()
        Dim vlColumna As Janus.Windows.GridEX.GridEXColumn

        With Gridex1.RootTable
            For Each vlColumna In .Columns
                vlColumna.EditType = Janus.Windows.GridEX.EditType.NoEdit
                vlColumna.HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
                vlColumna.FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox
            Next
            Gridex1.RootTable.Columns("Unidad").HasValueList = True
            lbGeneral.LlenarColumna(Gridex1.RootTable.Columns("Unidad"), "UNIDADV")


            Gridex1.RootTable.Columns("ProductoClave").Caption = oMensaje.RecuperarDescripcion("XClave")
            Gridex1.RootTable.Columns("Nombre").Caption = oMensaje.RecuperarDescripcion("XNombre")
            Gridex1.RootTable.Columns("Unidad").Caption = oMensaje.RecuperarDescripcion("XUnidad")
            Gridex1.RootTable.Columns("Cantidad").Caption = oMensaje.RecuperarDescripcion("XCantidad")

        End With

    End Sub

    

    Public Sub ConsultarDetalle(ByVal Pedidos As List(Of String))
        vcConexion = LbConexion.cConexion.Instancia

        Dim loPedido As New cTransProd

        'TODO: Agregar Msg a la base datos

        'Gridex1.ClearStructure()


        Dim dt As DataTable = loPedido.ObtenerDetallePedidos(Pedidos)

        Carga_Grid(dt)

        Me.ShowDialog()

    End Sub

    

#End Region

#Region "Eventos"

    Private Sub IFacturas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '#If DEBUG Then
        '        'oConexion.Conectar("Provider=SQLOLEDB.1;Persist Security Info=True;User ID=sa;password=dbsa;Initial Catalog=LACTIGURT230;Data Source=localhost\sqlexpress")
        '        oConexion.Conectar("Provider=SQLOLEDB.1;Persist Security Info=True;User ID=sa;password=dbsa;Initial Catalog=route;Data Source=rafiki")
        '        oMensaje = New BASMENLOG.CMensaje
        '        oMensaje.LlenarDataSet()
        '        'lbGeneral.cParametros.UsuarioID = "Admin"
        '        lbGeneral.cParametros.UsuarioID = "26PKB2C2AHNRELF"
        '        Dim oKeyGen As New lbGeneral.cKeyGen
        '        oAcceso = New LbAcceso.cAcceso 'LbAcceso.cAcceso
        '        oAcceso.Modificar = False
        '        oAcceso.Leer = True
        '        oAcceso.Crear = True
        '        oAcceso.Print = False
        '        oAcceso.Otros = False

        '#End If

        oMensaje = New BASMENLOG.CMensaje
        Me.Text = oMensaje.RecuperarDescripcion("ERMTRPESC_IDetallePedidos")
        ConfigurarGrid()
        ConfigurarInterfaz()


       
    End Sub

    Private Sub BtAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtAceptar.Click

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub BtCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

   

#End Region

 
End Class