Imports ERMFOLLOG
Imports BASMENLOG
Imports System.Windows.Forms

Public Class IGeneral
    Inherits FormasBase.Seleccionar01

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    Public Sub New(ByVal pvMultiSelect As Boolean, Optional ByVal pvCamposSelect As String = " FolioID, Descripcion ", Optional ByVal pvFiltro As String = "")
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
        components = New System.ComponentModel.Container
    End Sub

#End Region


    Private vcConexion As LbConexion.cConexion
    Private vgDataSet As New DataSet
    Public vlCamposSelect As String = " FolioID, Descripcion "
    Private vcMensaje As CMensaje
    Private vcFolio As New cFolio
    Private vlMultiSelect As Boolean
    Private vlFiltro As String

    Public Seleccion As New ArrayList

    Private Sub IGeneral_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        vcConexion = LbConexion.cConexion.Instancia

        vcMensaje = New BASMENLOG.CMensaje
        Carga_Grid()
    End Sub

    Public Sub Carga_Grid()
        Try
            vcFolio = Nothing
            vcFolio = New cFolio

            Me.Text = vcMensaje.RecuperarDescripcion("ERMFOLESC_IGeneral")

            Gridex1.ClearStructure()

            If vlCamposSelect.ToUpper.IndexOf("FOLIOID") < 0 Then
                vlCamposSelect = "FolioID," & vlCamposSelect
            End If

            Dim dt As DataTable = vcFolio.Tabla.Recuperar(vlFiltro, vlCamposSelect)
            If vlMultiSelect Then
                dt.Columns.Add("Seleccion", GetType(Boolean))
                dt.Columns("Seleccion").DefaultValue = False
                For Each r As DataRow In dt.Rows
                    r("Seleccion") = False
                Next
            End If
            Gridex1.DataSource = dt
            Gridex1.RetrieveStructure()

            ConfigurarGrid()

        Catch ex As LbControlError.cError
            ex.Mostrar()
        Catch ex As Exception
            Dim vlError As New LbControlError.cError("BF0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(ex.Source)}, , ex.Message)
            vlError.Mostrar()
        End Try

    End Sub

    Private Sub ConfigurarGrid()

        Dim vlColumna As Janus.Windows.GridEX.GridEXColumn

        Me.BtAceptar.Text = vcMensaje.RecuperarDescripcion("BTAceptar")
        Me.BtCancelar.Text = vcMensaje.RecuperarDescripcion("BTCancelar")

        Dim vlToolTip As New ToolTip

        With vlToolTip
            .ShowAlways = True
            .SetToolTip(Me.BtAceptar, vcMensaje.RecuperarDescripcion("BTAceptarIT"))
            .SetToolTip(Me.BtCancelar, vcMensaje.RecuperarDescripcion("BTCancelarIT"))
        End With

        With Gridex1.RootTable
            For Each vlColumna In .Columns
                If vlColumna.Key = "Seleccion" Then
                    vlColumna.Position = 0
                    vlColumna.Caption = ""
                    vlColumna.Width = 50
                    vlColumna.ActAsSelector = True
                Else
                    vlColumna.EditType = Janus.Windows.GridEX.EditType.NoEdit
                    vlColumna.Caption = vcMensaje.RecuperarDescripcion("FOL" & vlColumna.Key)
                    vlColumna.HeaderToolTip = vcMensaje.RecuperarDescripcion("FOL" & vlColumna.Key & "T")
                    vlColumna.HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
                    vlColumna.FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox
                End If
            Next

            If .Columns.Contains("FolioID") Then
                .Columns("FolioID").Visible = False
            End If

            If .Columns.Contains("Descripcion") Then
                .Columns("Descripcion").Width = 200
            End If

            If .Columns.Contains("TipoEstado") Then
                .Columns("TipoEstado").HasValueList = True
                .Columns("TipoEstado").FilterEditType = Janus.Windows.GridEX.FilterEditType.Combo
                lbGeneral.LlenarColumna(Gridex1.RootTable.Columns("TipoEstado"), "EDOREG")
            End If

        End With
    End Sub

    Private Sub BtAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtAceptar.Click

        Seleccion = New ArrayList

        If Me.vlMultiSelect Then
            SeleccionarRegs()
        Else
            If Gridex1.GetRow.RowType = Janus.Windows.GridEX.RowType.Record Or Gridex1.GetRow.RowType = Janus.Windows.GridEX.RowType.NewRecord Then
                Dim vlFolio As New cFolio
                vlFolio.Recuperar(Gridex1.GetRow.Cells("FolioID").Value())

                Seleccion.Add(vlFolio)
            End If
        End If

        Me.Close()

    End Sub

    Private Sub SeleccionarRegs()
        Dim vlRegistros() As Janus.Windows.GridEX.GridEXRow
        Dim vlRegistro As Janus.Windows.GridEX.GridEXRow
        Seleccion = New ArrayList
        'vlRegistros = CType(Me.Gridex1.DataSource, DataTable).Select("Seleccion=true")
        vlRegistros = Me.Gridex1.GetCheckedRows
        For Each vlRegistro In vlRegistros
            Dim vcFolio As New cFolio
            vcFolio.Recuperar(vlRegistro.Cells("FolioID").Value)
            Seleccion.Add(vcFolio)
        Next
    End Sub

End Class
