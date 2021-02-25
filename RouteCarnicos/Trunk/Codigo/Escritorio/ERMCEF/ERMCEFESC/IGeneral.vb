Public Class IGeneral
    Inherits FormasBase.Seleccionar01

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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container()
    End Sub

#End Region

    Private oCertificadoFolio As New ERMCEFLOG.cCertificadoFolio
    Private oMensaje As New BASMENLOG.CMensaje
    Private alSeleccionados As ArrayList
    Private sFiltro As String
    Private bMultiSeleccion As Boolean

    Private Sub IGeneral_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim vlDt As DataTable = oCertificadoFolio.TablaNodo.Recuperar(sFiltro)
        Dim sMnemonico As String = "CEF"

        Dim Cols As New DataColumn("Seleccion", System.Type.GetType("System.Boolean"))
        Cols.DefaultValue = False
        Cols.AllowDBNull = False
        vlDt.Columns.Add(Cols)

        Me.Text = oMensaje.RecuperarDescripcion("ERMCEFESC_IGeneral")

        Me.BtAceptar.Text = oMensaje.RecuperarDescripcion("BTAceptar")
        Me.BtCancelar.Text = oMensaje.RecuperarDescripcion("BTCancelar")

        Dim vlToolTip As New ToolTip

        With vlToolTip
            .ShowAlways = True
            .SetToolTip(Me.BtAceptar, oMensaje.RecuperarDescripcion("BTAceptarIT"))
            .SetToolTip(Me.BtCancelar, oMensaje.RecuperarDescripcion("BTCancelarIT"))
        End With

        Me.Gridex1.DataSource = vlDt
        Me.Gridex1.RetrieveStructure()
        Me.Gridex1.RootTable.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.False
        Me.Gridex1.RootTable.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
        Dim col As Janus.Windows.GridEX.GridEXColumn
        Me.Gridex1.RootTable.Columns.Insert(0, New Janus.Windows.GridEX.GridEXColumn)
        Me.Gridex1.BuiltInTexts.Item(Janus.Windows.GridEX.GridEXBuiltInText.CalendarNoneButton) = oMensaje.RecuperarDescripcion("XNinguno")
        Me.Gridex1.BuiltInTexts.Item(Janus.Windows.GridEX.GridEXBuiltInText.CalendarTodayButton) = oMensaje.RecuperarDescripcion("XAhora")

        For Each col In Me.Gridex1.RootTable.Columns
            Select Case col.Key
                Case "Seleccion"
                    col.Caption = ""
                    col.Width = 30
                    col.ColumnType = Janus.Windows.GridEX.ColumnType.CheckBox
                    col.EditType = Janus.Windows.GridEX.EditType.CheckBox
                    col.CheckBoxTriState = False
                    col.DefaultValue = False
                    col.FilterEditType = Janus.Windows.GridEX.FilterEditType.SameAsEditType
                    col.ActAsSelector = True
                Case "NumCertificado"
                    col.Width = 200
                    col.EditType = Janus.Windows.GridEX.EditType.NoEdit
                    col.Caption = oMensaje.RecuperarDescripcion(sMnemonico & col.Key)
                    col.HeaderToolTip = oMensaje.RecuperarDescripcion(sMnemonico & col.Key & "T")
                    col.FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox
                Case "FechaInicial"
                    col.Width = 150
                    col.Caption = oMensaje.RecuperarDescripcion(sMnemonico & col.Key)
                    col.HeaderToolTip = oMensaje.RecuperarDescripcion(sMnemonico & col.Key & "T")
                    col.EditType = Janus.Windows.GridEX.EditType.NoEdit
                    col.FilterEditType = Janus.Windows.GridEX.FilterEditType.DropDownList
                    col.FormatString = "dd/MM/yyyy"
                Case "FechaFinal"
                    col.Caption = oMensaje.RecuperarDescripcion(sMnemonico & col.Key)
                    col.HeaderToolTip = oMensaje.RecuperarDescripcion(sMnemonico & col.Key & "T")
                    col.EditType = Janus.Windows.GridEX.EditType.NoEdit
                    col.Width = 150
                    col.FilterEditType = Janus.Windows.GridEX.FilterEditType.DropDownList
                    col.FormatString = "dd/MM/yyyy"
                Case Else
                    col.Visible = False
                    col.EditType = Janus.Windows.GridEX.EditType.NoEdit
            End Select
            col.HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
        Next

        With Me.Gridex1.RootTable.Columns
            col = .Item("Seleccion")
            .Remove(col)
            .Insert(0, col)
        End With

        If bMultiSeleccion = True Then
            Gridex1.RootTable.Columns("Seleccion").Visible = True
        Else
            Gridex1.RootTable.Columns("Seleccion").Visible = False
        End If
    End Sub

    Private Sub btAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtAceptar.Click
        Dim vlRows() As Janus.Windows.GridEX.GridEXRow
        Me.DialogResult = Windows.Forms.DialogResult.None

        If bMultiSeleccion Then
            vlRows = Me.Gridex1.GetCheckedRows
            Dim vlRegistro As Janus.Windows.GridEX.GridEXRow
            Dim vlCertificadoFolio As ERMCEFLOG.cCertificadoFolio
            For Each vlRegistro In vlRows
                vlCertificadoFolio = New ERMCEFLOG.cCertificadoFolio
                vlCertificadoFolio.Recuperar(vlRegistro.Cells("NumCertificado").Value)
                alSeleccionados.Add(vlCertificadoFolio)
            Next
        Else
            If Not IsNothing(Gridex1.GetRow) Then
                If Gridex1.GetRow.RowType = Janus.Windows.GridEX.RowType.Record Or Gridex1.GetRow.RowType = Janus.Windows.GridEX.RowType.NewRecord Then
                    Dim vlCertificadoFolio As New ERMCEFLOG.cCertificadoFolio
                    vlCertificadoFolio.Recuperar(Gridex1.GetRow.Cells("NumCertificado").Value())
                    alSeleccionados.Add(vlCertificadoFolio)
                End If
            End If
        End If

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Public Function Seleccionar(ByVal pvFiltro As String, ByVal pvMultiSeleccion As Boolean) As ArrayList
        sFiltro = pvFiltro
        bMultiSeleccion = pvMultiSeleccion
        alSeleccionados = New ArrayList
        If Me.ShowDialog = Windows.Forms.DialogResult.OK Then
            Return alSeleccionados
        Else
            Return Nothing
        End If
    End Function

    Private Sub btCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtCancelar.Click
        Me.Close()
    End Sub
End Class
