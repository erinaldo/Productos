Imports ERMCLILOG
Imports BASMENLOG
Imports System.Windows.Forms
Public Class IPuntosEntrega
    Inherits FormasBase.Seleccionar01

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    Public Sub New(ByVal pvMultiSelect As Boolean, ByVal pvTipoDomicilio As Integer, ByVal pvFrecuenciaClave As String, ByVal pvRUTClave As String, Optional ByVal pvClienteVariasRutas As Boolean = True, Optional ByVal pvNuevosGrid As String = "", Optional ByVal pvEliminadosGrid As String = "", Optional ByVal pvClientesActivos As Boolean = False)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        bMultiSelect = pvMultiSelect
        nTipoDomicilio = pvTipoDomicilio
        sFrecuenciaClave = pvFrecuenciaClave
        sRUTClave = pvRUTClave
        bClienteVariasRutas = pvClienteVariasRutas
        sNuevosGrid = pvNuevosGrid
        sEliminadosGrid = pvEliminadosGrid
        bClientesActivos = pvClientesActivos

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
    Friend WithEvents rbtMismaFrecuencia As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbtDiferenteFrecuencia As Janus.Windows.EditControls.UIRadioButton
    Friend WithEvents rbtSinFrecuencia As Janus.Windows.EditControls.UIRadioButton

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim Gridex1_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IPuntosEntrega))
        Me.rbtMismaFrecuencia = New Janus.Windows.EditControls.UIRadioButton
        Me.rbtDiferenteFrecuencia = New Janus.Windows.EditControls.UIRadioButton
        Me.rbtSinFrecuencia = New Janus.Windows.EditControls.UIRadioButton
        CType(Me.Gridex1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Gridex1
        '
        Gridex1_DesignTimeLayout.LayoutString = resources.GetString("Gridex1_DesignTimeLayout.LayoutString")
        Me.Gridex1.DesignTimeLayout = Gridex1_DesignTimeLayout
        Me.Gridex1.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular
        Me.Gridex1.Location = New System.Drawing.Point(8, 35)
        Me.Gridex1.Size = New System.Drawing.Size(616, 261)
        '
        'BtAceptar
        '
        Me.BtAceptar.Location = New System.Drawing.Point(408, 307)
        '
        'BtCancelar
        '
        Me.BtCancelar.Location = New System.Drawing.Point(520, 307)
        '
        'rbtMismaFrecuencia
        '
        Me.rbtMismaFrecuencia.Location = New System.Drawing.Point(8, 6)
        Me.rbtMismaFrecuencia.Name = "rbtMismaFrecuencia"
        Me.rbtMismaFrecuencia.Size = New System.Drawing.Size(197, 23)
        Me.rbtMismaFrecuencia.TabIndex = 22
        Me.rbtMismaFrecuencia.Text = "MismaFrecuencia"
        Me.rbtMismaFrecuencia.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'rbtDiferenteFrecuencia
        '
        Me.rbtDiferenteFrecuencia.Location = New System.Drawing.Point(255, 6)
        Me.rbtDiferenteFrecuencia.Name = "rbtDiferenteFrecuencia"
        Me.rbtDiferenteFrecuencia.Size = New System.Drawing.Size(180, 23)
        Me.rbtDiferenteFrecuencia.TabIndex = 23
        Me.rbtDiferenteFrecuencia.Text = "DiferenteFrecuencia"
        Me.rbtDiferenteFrecuencia.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'rbtSinFrecuencia
        '
        Me.rbtSinFrecuencia.Location = New System.Drawing.Point(511, 6)
        Me.rbtSinFrecuencia.Name = "rbtSinFrecuencia"
        Me.rbtSinFrecuencia.Size = New System.Drawing.Size(113, 23)
        Me.rbtSinFrecuencia.TabIndex = 24
        Me.rbtSinFrecuencia.Text = "SinFrecuencia"
        Me.rbtSinFrecuencia.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005
        '
        'IPuntosEntrega
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(634, 344)
        Me.Controls.Add(Me.rbtSinFrecuencia)
        Me.Controls.Add(Me.rbtDiferenteFrecuencia)
        Me.Controls.Add(Me.rbtMismaFrecuencia)
        Me.Name = "IPuntosEntrega"
        Me.Controls.SetChildIndex(Me.rbtMismaFrecuencia, 0)
        Me.Controls.SetChildIndex(Me.BtCancelar, 0)
        Me.Controls.SetChildIndex(Me.BtAceptar, 0)
        Me.Controls.SetChildIndex(Me.Gridex1, 0)
        Me.Controls.SetChildIndex(Me.rbtDiferenteFrecuencia, 0)
        Me.Controls.SetChildIndex(Me.rbtSinFrecuencia, 0)
        CType(Me.Gridex1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private oMensaje As CMensaje
    Private bMultiSelect As Boolean
    Private nTipoDomicilio As Integer
    Public aSeleccion As New ArrayList
    Private sFrecuenciaClave As String
    Private sRUTClave As String
    Private bClienteVariasRutas As Boolean
    Private sNuevosGrid As String
    Private sEliminadosGrid As String
    Private bClientesActivos As Boolean

    Private Sub IGeneral_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        oMensaje = New BASMENLOG.CMensaje
        Me.rbtMismaFrecuencia.Checked = True
    End Sub

    Public Sub Carga_Grid()
        Try
            Dim loCliente As New cCliente

            Me.Text = oMensaje.RecuperarDescripcion("ERMCLIESC_IPuntosEntrega")

            Gridex1.ClearStructure()

            Dim lsFiltro As String

            If rbtSinFrecuencia.Checked Then
                lsFiltro = " ClienteDomicilio.ClienteClave not in (select ClienteClave from secuencia) "
            Else
                lsFiltro = "  ClienteDomicilio.ClienteClave + ' ' + ClienteDomicilioID not in(Select ClienteClave + ' ' + ClienteDomicilioID from secuencia S where FrecuenciaClave ='" & sFrecuenciaClave & "' AND RUTClave = '" & sRUTClave & "' AND S.ClienteClave = Cliente.ClienteClave ) AND " '("
                If Not bClienteVariasRutas Then
                    If rbtMismaFrecuencia.Checked Then
                        lsFiltro &= " ClienteDomicilio.ClienteClave + ' ' + ClienteDomicilioID in (select ClienteClave + ' ' + ClienteDomicilioID from secuencia S where FrecuenciaClave ='" & sFrecuenciaClave & "' and RUTClave is null AND S.ClienteClave = Cliente.ClienteClave) "
                    ElseIf rbtDiferenteFrecuencia.Checked Then
                        lsFiltro &= " ClienteDomicilio.ClienteClave + ' ' + ClienteDomicilioID in (select ClienteClave + ' ' + ClienteDomicilioID from secuencia S where FrecuenciaClave <>'" & sFrecuenciaClave & "' and RUTClave is null AND S.ClienteClave = Cliente.ClienteClave) "
                    End If
                    lsFiltro &= " and ClienteDomicilio.ClienteClave + ' ' + ClienteDomicilioId not IN (Select ClienteClave + ' ' + ClienteDomicilioID From Secuencia S WHERE not rutclave is null AND RUTCLAVE <> '" & sRUTClave & "' AND S.ClienteClave = Cliente.ClienteClave) "
                Else
                    If rbtMismaFrecuencia.Checked Then
                        lsFiltro &= " ClienteDomicilio.ClienteClave + ' ' + ClienteDomicilioID in (select ClienteClave + ' ' + ClienteDomicilioID from secuencia S where FrecuenciaClave ='" & sFrecuenciaClave & "' AND S.ClienteClave = Cliente.ClienteClave) "
                    ElseIf rbtDiferenteFrecuencia.Checked Then
                        lsFiltro &= " ClienteDomicilio.ClienteClave + ' ' + ClienteDomicilioID in (select ClienteClave + ' ' + ClienteDomicilioID from secuencia S where FrecuenciaClave <>'" & sFrecuenciaClave & "' AND S.ClienteClave = Cliente.ClienteClave) "
                    End If
                End If
            End If

            lsFiltro &= " and (ClienteDomicilio.ClienteClave not in ("
            lsFiltro &= "select distinct Secuencia.ClienteClave "
            lsFiltro &= "from Secuencia inner join Cliente on Secuencia.ClienteClave = Cliente.ClienteClave "
            lsFiltro &= "inner join ClienteDomicilio on Secuencia.ClienteClave = ClienteDomicilio.ClienteClave and ClienteDomicilio.ClienteDomicilioID =Secuencia.ClienteDomicilioID "
            lsFiltro &= "and Secuencia.RUTClave='" & sRUTClave & "' AND Secuencia.FrecuenciaClave='" & sFrecuenciaClave & "') "

            If sNuevosGrid <> "" Then
                lsFiltro &= "and ClienteDomicilio.ClienteClave not in (" & sNuevosGrid & ") "
            End If

            If bClientesActivos Then
                lsFiltro &= " and Cliente.TipoEstado = 1 "
            End If
            lsFiltro &= ") "

            If sEliminadosGrid <> "" Then
                lsFiltro &= " union "
                lsFiltro &= "select ClienteDomicilioID, Cliente.ClienteClave, Cliente.Clave, RazonSocial,NombreCorto, " _
                    & " Calle,Numero,Colonia,CodigoPostal,Poblacion, Entidad, Pais " _
                    & " from ClienteDomicilio inner join cliente on ClienteDomicilio.ClienteClave = Cliente.ClienteClave " _
                    & " where ClienteDomicilio.Tipo = 2 and Cliente.clienteclave in (" & sEliminadosGrid & ") "

                If sNuevosGrid <> "" Then
                    lsFiltro &= "and Cliente.ClienteClave not in (" & sNuevosGrid & ") "
                End If

                If bClientesActivos Then
                    lsFiltro &= "and Cliente.TipoEstado = 1 "
                End If
            End If

            Dim dt As DataTable = loCliente.Tabla.RecuperarVistaDatosCliente(nTipoDomicilio, lsFiltro)
            If bMultiSelect Then
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

        Me.BtAceptar.Text = oMensaje.RecuperarDescripcion("BTAceptar")
        Me.BtCancelar.Text = oMensaje.RecuperarDescripcion("BTCancelar")

        Me.rbtMismaFrecuencia.Text = oMensaje.RecuperarDescripcion("XMismaFrecuencia")
        Me.rbtDiferenteFrecuencia.Text = oMensaje.RecuperarDescripcion("XDiferenteFrecuencia")
        Me.rbtSinFrecuencia.Text = oMensaje.RecuperarDescripcion("XSinFrecuencia")

        Dim vlToolTip As New ToolTip

        With vlToolTip
            .ShowAlways = True
            .SetToolTip(Me.BtAceptar, oMensaje.RecuperarDescripcion("BTAceptarIT"))
            .SetToolTip(Me.BtCancelar, oMensaje.RecuperarDescripcion("BTCancelarIT"))
        End With

        With Gridex1.RootTable
            For Each vlColumna In .Columns
                If vlColumna.Key = "Seleccion" Then
                    vlColumna.Position = 0
                    vlColumna.Caption = ""
                    vlColumna.Width = 50
                Else
                    vlColumna.EditType = Janus.Windows.GridEX.EditType.NoEdit
                    vlColumna.HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
                    vlColumna.FilterEditType = Janus.Windows.GridEX.FilterEditType.TextBox

                    Select Case vlColumna.Key.ToLower
                        Case "clienteclave", "razonsocial", "nombrecorto", "clave"
                            'Case "clienteclave", "razonsocial", "nombrecorto"
                            vlColumna.Caption = oMensaje.RecuperarDescripcion("CLI" & vlColumna.Key)
                            vlColumna.HeaderToolTip = oMensaje.RecuperarDescripcion("CLI" & vlColumna.Key & "T")
                        Case Else
                            vlColumna.Caption = oMensaje.RecuperarDescripcion("CLD" & vlColumna.Key)
                            vlColumna.HeaderToolTip = oMensaje.RecuperarDescripcion("CLD" & vlColumna.Key & "T")
                    End Select
                End If
            Next

            .Columns("ClienteClave").Visible = False
            .Columns("ClienteDomicilioID").Visible = False

            If .Columns.Contains("Tipo") Then
                .Columns("Tipo").HasValueList = True
                .Columns("Tipo").FilterEditType = Janus.Windows.GridEX.FilterEditType.Combo
                lbGeneral.LlenarColumna(Gridex1.RootTable.Columns("Tipo"), "DOMTIPO")
            End If
        End With
    End Sub

    Private Sub BtAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtAceptar.Click

        aSeleccion = New ArrayList

        If Me.bMultiSelect Then
            SeleccionarRegs(aSeleccion)
        Else
            If Gridex1.GetRow.RowType = Janus.Windows.GridEX.RowType.Record Or Gridex1.GetRow.RowType = Janus.Windows.GridEX.RowType.NewRecord Then
                aSeleccion.Add(Gridex1.GetRow.DataRow)
            End If
        End If

        Me.Close()

    End Sub

    Private Sub SeleccionarRegs(ByRef prArreglo As ArrayList)
        Dim drRegistros() As DataRow
        Dim drRegistro As DataRow
        'aSeleccion = New ArrayList
        drRegistros = CType(Me.Gridex1.DataSource, DataTable).Select("Seleccion=true")
        For Each drRegistro In drRegistros
            prArreglo.Add(drRegistro)
        Next
    End Sub

    Private Sub rbtFrecuencia_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbtMismaFrecuencia.CheckedChanged, rbtDiferenteFrecuencia.CheckedChanged, rbtSinFrecuencia.CheckedChanged
        If CType(sender, Janus.Windows.EditControls.UIRadioButton).Checked Then
            Carga_Grid()
        End If
    End Sub
End Class
