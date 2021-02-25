Imports ERMFOLLOG
Imports BASMENLOG

Public Class ctrlFoliosFiscales
    Inherits System.Windows.Forms.UserControl

    Public Event Habilitar(ByVal pvNombreBoton As String, ByVal pvHabilitar As Boolean)

#Region "VARIABLES"
    Private vcFolio As cFolio
    Public vgModo As eModo
    Private vcMensaje As CMensaje
    Private bPreguntar As Boolean = True
    Private nVersionCFD As Int16
    Private blnEditado As Boolean = False
#End Region

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'UserControl overrides dispose to clean up the component list.
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
    Friend WithEvents ebFolio As Janus.Windows.GridEX.EditControls.EditBox
    Friend WithEvents lbFolio As System.Windows.Forms.Label
    Friend WithEvents gbAsignacion As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents gbFolios As Janus.Windows.EditControls.UIGroupBox
    Friend WithEvents lbFechaModificacionFolios As System.Windows.Forms.Label
    Friend WithEvents lbFechaModificacionAsignacion As System.Windows.Forms.Label
    Friend WithEvents lbUsuarioFolios As System.Windows.Forms.Label
    Friend WithEvents lbUsuarioAsignacion As System.Windows.Forms.Label
    Friend WithEvents grFolioSolicitado As Janus.Windows.GridEX.GridEX
    Friend WithEvents grAsignacion As Janus.Windows.GridEX.GridEX
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim grAsignacion_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ctrlFoliosFiscales))
        Dim grFolioSolicitado_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Me.ebFolio = New Janus.Windows.GridEX.EditControls.EditBox
        Me.lbFolio = New System.Windows.Forms.Label
        Me.gbAsignacion = New Janus.Windows.EditControls.UIGroupBox
        Me.lbUsuarioAsignacion = New System.Windows.Forms.Label
        Me.lbFechaModificacionAsignacion = New System.Windows.Forms.Label
        Me.grAsignacion = New Janus.Windows.GridEX.GridEX
        Me.gbFolios = New Janus.Windows.EditControls.UIGroupBox
        Me.grFolioSolicitado = New Janus.Windows.GridEX.GridEX
        Me.lbFechaModificacionFolios = New System.Windows.Forms.Label
        Me.lbUsuarioFolios = New System.Windows.Forms.Label
        CType(Me.gbAsignacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbAsignacion.SuspendLayout()
        CType(Me.grAsignacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbFolios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbFolios.SuspendLayout()
        CType(Me.grFolioSolicitado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ebFolio
        '
        Me.ebFolio.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ebFolio.Enabled = False
        Me.ebFolio.Location = New System.Drawing.Point(120, 16)
        Me.ebFolio.MaxLength = 64
        Me.ebFolio.Name = "ebFolio"
        Me.ebFolio.Size = New System.Drawing.Size(736, 20)
        Me.ebFolio.TabIndex = 1
        Me.ebFolio.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.ebFolio.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbFolio
        '
        Me.lbFolio.BackColor = System.Drawing.Color.Transparent
        Me.lbFolio.Location = New System.Drawing.Point(16, 16)
        Me.lbFolio.Name = "lbFolio"
        Me.lbFolio.Size = New System.Drawing.Size(96, 20)
        Me.lbFolio.TabIndex = 8
        Me.lbFolio.Text = "lbFolio"
        Me.lbFolio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gbAsignacion
        '
        Me.gbAsignacion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbAsignacion.BackColor = System.Drawing.Color.Transparent
        Me.gbAsignacion.Controls.Add(Me.lbUsuarioAsignacion)
        Me.gbAsignacion.Controls.Add(Me.lbFechaModificacionAsignacion)
        Me.gbAsignacion.Controls.Add(Me.grAsignacion)
        Me.gbAsignacion.Location = New System.Drawing.Point(8, 248)
        Me.gbAsignacion.Name = "gbAsignacion"
        Me.gbAsignacion.Size = New System.Drawing.Size(832, 240)
        Me.gbAsignacion.TabIndex = 4
        Me.gbAsignacion.Text = "gbAsignacion"
        Me.gbAsignacion.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'lbUsuarioAsignacion
        '
        Me.lbUsuarioAsignacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbUsuarioAsignacion.Location = New System.Drawing.Point(8, 216)
        Me.lbUsuarioAsignacion.Name = "lbUsuarioAsignacion"
        Me.lbUsuarioAsignacion.Size = New System.Drawing.Size(256, 23)
        Me.lbUsuarioAsignacion.TabIndex = 5
        Me.lbUsuarioAsignacion.Text = "lbUsuarioAsignacion"
        Me.lbUsuarioAsignacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbFechaModificacionAsignacion
        '
        Me.lbFechaModificacionAsignacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbFechaModificacionAsignacion.Location = New System.Drawing.Point(560, 216)
        Me.lbFechaModificacionAsignacion.Name = "lbFechaModificacionAsignacion"
        Me.lbFechaModificacionAsignacion.Size = New System.Drawing.Size(256, 23)
        Me.lbFechaModificacionAsignacion.TabIndex = 4
        Me.lbFechaModificacionAsignacion.Text = "lbFechaModificacionAsignacion"
        Me.lbFechaModificacionAsignacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grAsignacion
        '
        Me.grAsignacion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grAsignacion.BackColor = System.Drawing.Color.White
        grAsignacion_DesignTimeLayout.LayoutString = resources.GetString("grAsignacion_DesignTimeLayout.LayoutString")
        Me.grAsignacion.DesignTimeLayout = grAsignacion_DesignTimeLayout
        Me.grAsignacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.grAsignacion.GroupByBoxVisible = False
        Me.grAsignacion.Location = New System.Drawing.Point(8, 16)
        Me.grAsignacion.Name = "grAsignacion"
        Me.grAsignacion.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow
        Me.grAsignacion.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grAsignacion.Size = New System.Drawing.Size(816, 200)
        Me.grAsignacion.TabIndex = 6
        Me.grAsignacion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'gbFolios
        '
        Me.gbFolios.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbFolios.BackColor = System.Drawing.Color.Transparent
        Me.gbFolios.Controls.Add(Me.grFolioSolicitado)
        Me.gbFolios.Controls.Add(Me.gbAsignacion)
        Me.gbFolios.Controls.Add(Me.lbFechaModificacionFolios)
        Me.gbFolios.Controls.Add(Me.lbUsuarioFolios)
        Me.gbFolios.Location = New System.Drawing.Point(8, 56)
        Me.gbFolios.Name = "gbFolios"
        Me.gbFolios.Size = New System.Drawing.Size(848, 496)
        Me.gbFolios.TabIndex = 2
        Me.gbFolios.Text = "gbFolios"
        Me.gbFolios.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2007
        '
        'grFolioSolicitado
        '
        Me.grFolioSolicitado.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        grFolioSolicitado_DesignTimeLayout.LayoutString = resources.GetString("grFolioSolicitado_DesignTimeLayout.LayoutString")
        Me.grFolioSolicitado.DesignTimeLayout = grFolioSolicitado_DesignTimeLayout
        Me.grFolioSolicitado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.grFolioSolicitado.GroupByBoxVisible = False
        Me.grFolioSolicitado.Location = New System.Drawing.Point(16, 19)
        Me.grFolioSolicitado.Name = "grFolioSolicitado"
        Me.grFolioSolicitado.NewRowPosition = Janus.Windows.GridEX.NewRowPosition.BottomRow
        Me.grFolioSolicitado.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grFolioSolicitado.Size = New System.Drawing.Size(816, 197)
        Me.grFolioSolicitado.TabIndex = 3
        Me.grFolioSolicitado.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbFechaModificacionFolios
        '
        Me.lbFechaModificacionFolios.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbFechaModificacionFolios.Location = New System.Drawing.Point(560, 216)
        Me.lbFechaModificacionFolios.Name = "lbFechaModificacionFolios"
        Me.lbFechaModificacionFolios.Size = New System.Drawing.Size(256, 23)
        Me.lbFechaModificacionFolios.TabIndex = 3
        Me.lbFechaModificacionFolios.Text = "lbFechaModificacionFolios"
        Me.lbFechaModificacionFolios.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbUsuarioFolios
        '
        Me.lbUsuarioFolios.Location = New System.Drawing.Point(16, 216)
        Me.lbUsuarioFolios.Name = "lbUsuarioFolios"
        Me.lbUsuarioFolios.Size = New System.Drawing.Size(256, 23)
        Me.lbUsuarioFolios.TabIndex = 4
        Me.lbUsuarioFolios.Text = "lbUsuarioFolios"
        Me.lbUsuarioFolios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ctrlFoliosFiscales
        '
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.Controls.Add(Me.gbFolios)
        Me.Controls.Add(Me.lbFolio)
        Me.Controls.Add(Me.ebFolio)
        Me.Name = "ctrlFoliosFiscales"
        Me.Size = New System.Drawing.Size(872, 552)
        CType(Me.gbAsignacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbAsignacion.ResumeLayout(False)
        CType(Me.grAsignacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbFolios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbFolios.ResumeLayout(False)
        CType(Me.grFolioSolicitado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Public WriteOnly Property Folio() As String
        Set(ByVal Value As String)
            Me.ebFolio.Text = Value
        End Set
    End Property

    Public Property VersionCFD() As Int16
        Get
            Return nVersionCFD
        End Get
        Set(ByVal value As Int16)
            nVersionCFD = value
        End Set
    End Property

#Region "FUNCIONES GENERALES"

    Public Sub CargarTodo(ByVal pModo As eModo, ByVal pFolio As cFolio, ByVal pvMensaje As CMensaje)
        If pModo = eModo.Leer Then
            'Me.grFolioSolicitado.Size = New System.Drawing.Size(826, 80)
            'Me.gbAsignacion.Location = New System.Drawing.Point(8, 116)
            'Me.gbAsignacion.Size = New System.Drawing.Size(842, 360)

        End If

        vgModo = pModo
        vcFolio = pFolio
        vcMensaje = pvMensaje
        configurarTitulos()

        Me.lbUsuarioAsignacion.Visible = False
        Me.lbUsuarioFolios.Visible = False
        Me.lbFechaModificacionAsignacion.Visible = False
        Me.lbFechaModificacionFolios.Visible = False

        Me.grFolioSolicitado.DataSource = Nothing
        Me.grFolioSolicitado.DataSource = vcFolio.recuperarFOSArray
    End Sub

    Public Sub CargarHistorico(ByVal pModo As eModo, ByVal pFolio As cFolio, ByVal pvMensaje As CMensaje)
        If pModo = eModo.Leer Then
            'Me.grFolioSolicitado.Size = New System.Drawing.Size(826, 80)
            'Me.gbAsignacion.Location = New System.Drawing.Point(8, 116)
            'Me.gbAsignacion.Size = New System.Drawing.Size(842, 360)

        End If

        vgModo = pModo
        vcFolio = pFolio
        vcMensaje = pvMensaje
        configurarTitulos()

        Me.lbUsuarioAsignacion.Visible = False
        Me.lbUsuarioFolios.Visible = False
        Me.lbFechaModificacionAsignacion.Visible = False
        Me.lbFechaModificacionFolios.Visible = False

        Me.grFolioSolicitado.DataSource = Nothing
        Me.grFolioSolicitado.DataSource = vcFolio.recuperarFOSArray
    End Sub

    Private Sub DeshabilitaCrear(ByRef peGridEx As Janus.Windows.GridEX.GridEX)
        If Not peGridEx.GetRow Is Nothing And peGridEx.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True Then
            If (peGridEx.GetRow.RowType = Janus.Windows.GridEX.RowType.Record Or peGridEx.DataChanged = False) Then 'Or peGridEx.GetRow.RowType = Janus.Windows.GridEX.RowType.NewRecord Or peGridEx.DataChanged = False) Then
                peGridEx.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.False
                If (peGridEx.Row = 0) Then
                    Try
                        peGridEx.MoveLast()
                    Catch ex As Exception

                    End Try
                End If
            End If
        End If
    End Sub

    Private Sub configurarTitulos()
        Dim vcMensaje As New CMensaje

        Me.lbFolio.Text = vcMensaje.RecuperarDescripcion("XFolio")
        Me.gbFolios.Text = vcMensaje.RecuperarDescripcion("FSHFolios")
        Me.gbAsignacion.Text = vcMensaje.RecuperarDescripcion("FSHAsignacion")

        Me.grAsignacion.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation
        With grAsignacion.RootTable
            For Each vlColumna As Janus.Windows.GridEX.GridEXColumn In .Columns
                If vlColumna.Visible Then
                    Select Case vlColumna.Key
                        Case "Descripcion"
                            vlColumna.Caption = vcMensaje.RecuperarDescripcion("TER" & vlColumna.Key)
                            vlColumna.HeaderToolTip = vcMensaje.RecuperarDescripcion("TER" & vlColumna.Key & "T")
                            vlColumna.HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
                        Case "Vendedor"
                            vlColumna.Caption = vcMensaje.RecuperarDescripcion("FOUVendedorID")
                            vlColumna.HeaderToolTip = vcMensaje.RecuperarDescripcion("FOUVendedorIDT")
                            vlColumna.HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
                        Case "FechaCreacion"
                            vlColumna.Caption = vcMensaje.RecuperarDescripcion("FOS" & vlColumna.Key)
                            vlColumna.HeaderToolTip = vcMensaje.RecuperarDescripcion("FOS" & vlColumna.Key & "T")
                            vlColumna.HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
                        Case Else
                            vlColumna.Caption = vcMensaje.RecuperarDescripcion("FSH" & vlColumna.Key)
                            vlColumna.HeaderToolTip = vcMensaje.RecuperarDescripcion("FSH" & vlColumna.Key & "T")
                            vlColumna.HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
                    End Select
                End If

            Next
        End With

        Me.grFolioSolicitado.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation
        With grFolioSolicitado.RootTable
            For Each vlColumna As Janus.Windows.GridEX.GridEXColumn In .Columns
                If vlColumna.Visible Then
                    Select Case vlColumna.Key
                        Case "TipoComprobante"
                            vlColumna.Caption = vcMensaje.RecuperarDescripcion("X" & vlColumna.Key)
                            vlColumna.HeaderToolTip = vcMensaje.RecuperarDescripcion("X" & vlColumna.Key)
                            vlColumna.HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
                        Case Else
                            vlColumna.Caption = vcMensaje.RecuperarDescripcion("FOS" & vlColumna.Key)
                            vlColumna.HeaderToolTip = vcMensaje.RecuperarDescripcion("FOS" & vlColumna.Key & "T")
                            vlColumna.HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
                    End Select
                End If

            Next
        End With

        lbGeneral.LlenarColumna(grFolioSolicitado.RootTable.Columns("TipoComprobante"), "FOLTIPO")

        Me.lbFechaModificacionAsignacion.Text = ""
        Me.lbFechaModificacionFolios.Text = ""
        Me.lbUsuarioAsignacion.Text = ""
        Me.lbUsuarioFolios.Text = ""
    End Sub

    Public Sub btPresionado(ByVal sender As Object)
        Dim btn As Janus.Windows.EditControls.UIButton
        btn = CType(sender, Janus.Windows.EditControls.UIButton)

        Select Case btn.Name
            Case "btCrearFolios"
                Me.grFolioSolicitado.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True
                Me.grFolioSolicitado.Col = 0
                Me.grFolioSolicitado.MoveToNewRecord()
                Me.grFolioSolicitado.Focus()

                LlenarNulos(grFolioSolicitado)
                HabilitarRow(grFolioSolicitado.Name, True)
                RaiseEvent Habilitar("btEliminarFolio", True)
                RaiseEvent Habilitar("btCrearAsignacion", True)

            Case "btEliminarFolio"

                If (grFolioSolicitado.RowCount = 0) Then Exit Sub
                If (grFolioSolicitado.GetRow.RowType = Janus.Windows.GridEX.RowType.NewRecord) Then
                    grFolioSolicitado.CancelCurrentEdit()
                    DeshabilitaCrear(Me.grFolioSolicitado)
                ElseIf (grFolioSolicitado.GetRow.RowType = Janus.Windows.GridEX.RowType.Record) Then
                    If Not vcFolio.FOS(grFolioSolicitado.GetValue("FOSID")) Is Nothing Then
                        vcFolio.FOS(CType(grFolioSolicitado.GetValue("FOSId"), String)).Eliminar()
                        If Not IsNothing(grAsignacion.GetRow) Then
                            If Not IsNothing(vcFolio.FSH(grAsignacion.GetValue("FOSID"), grAsignacion.GetValue("FechaCreacion"))) Then
                                vcFolio.FSH(grAsignacion.GetValue("FOSID"), grAsignacion.GetValue("FechaCreacion")).Eliminar()
                            End If
                        End If
                        grFolioSolicitado.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True
                        grFolioSolicitado.Delete()
                        grFolioSolicitado.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                    End If

                End If
                grFolioSolicitado.EditMode = Janus.Windows.GridEX.EditMode.EditOff
                grFolioSolicitado.MoveLast()

            Case "btCrearAsignacion"
                If Me.vgModo = eModo.Modificar And Me.vcFolio.recuperarFSHArray(Me.grAsignacion.GetValue("Fosid")).Count > 0 Then
                    Me.grAsignacion.MoveLast()
                    Me.grAsignacion.GetRow.Cells("Final").Text = Me.vcFolio.FSHInicioPrimerRegistroSerie(Me.grFolioSolicitado.GetValue("Serie"), grFolioSolicitado.GetValue("AnioAprobacion"), grFolioSolicitado.GetValue("NumeroAprobacion")) + Me.grFolioSolicitado.GetValue("usados") - 1
                End If

                Me.grAsignacion.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True
                Me.grAsignacion.Col = 0
                Me.grAsignacion.MoveToNewRecord()
                Me.grAsignacion.Focus()

                Try
                    LlenarNulos(grAsignacion)
                    HabilitarRow(grAsignacion.Name, True)
                    RaiseEvent Habilitar("btEliminarAsignacion", True)
                    RaiseEvent Habilitar("btCrearAsignacion", False)

                Catch ex As LbControlError.cError
                    ex.Mostrar()
                    Me.grAsignacion.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.False
                End Try

            Case "btEliminarAsignacion"
                If grAsignacion.EditMode = Janus.Windows.GridEX.EditMode.EditOn Then grAsignacion.EditMode = Janus.Windows.GridEX.EditMode.EditOff
                If (grAsignacion.RowCount = 0) Then Exit Sub
                If (grAsignacion.GetRow.RowType = Janus.Windows.GridEX.RowType.NewRecord) Then
                    grAsignacion.CancelCurrentEdit()
                    DeshabilitaCrear(Me.grAsignacion)
                ElseIf (grAsignacion.GetRow.RowType = Janus.Windows.GridEX.RowType.Record) Then
                    If Not vcFolio.FSH(grAsignacion.GetValue("FOSID"), grAsignacion.GetValue("FechaCreacion")) Is Nothing Then
                        'If vcFolio.FSH(grAsignacion.GetValue("FOSId"), grAsignacion.GetValue("FechaCreacion")).estado = eEstado.Nuevo Then
                        vcFolio.FSHFinEliminando(grFolioSolicitado.GetValue("FOSId"), grAsignacion.GetValue("FechaCreacion"), vcFolio.FSH(grFolioSolicitado.GetValue("FOSId"), grAsignacion.GetValue("FechaCreacion")).Fin)
                        vcFolio.FSH(grFolioSolicitado.GetValue("FOSId"), grAsignacion.GetValue("FechaCreacion")).Eliminar()
                        grAsignacion.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True
                        grAsignacion.Delete()
                        grAsignacion.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                        'End If
                    End If
                End If

                RaiseEvent Habilitar("btEliminarAsignacion", False)
                RaiseEvent Habilitar("btCrearAsignacion", True)
                If Me.grAsignacion.RowCount > 0 Then
                    grFolioSolicitado.RootTable.Columns("cantSolicitada").EditType = Janus.Windows.GridEX.EditType.NoEdit
                Else
                    grFolioSolicitado.RootTable.Columns("cantSolicitada").EditType = Janus.Windows.GridEX.EditType.TextBox
                End If
                Me.grAsignacion.UpdateData()
        End Select

    End Sub

    Private Sub LlenarNulos(ByRef prGrid As Janus.Windows.GridEX.GridEX)
        For Each vlCelda As Janus.Windows.GridEX.GridEXCell In prGrid.GetRow.Cells
            If IsDBNull(vlCelda) Or IsNothing(vlCelda.Value) Then
                Select Case prGrid.Name
                    Case "grFolioSolicitado"
                        Select Case vlCelda.Column.Key
                            'Case "NumeroAprobacion"
                            '    vlCelda.Value = 1

                            'Case "CantSolicitada"
                            'vlCelda.Value = 1
                            Case "Usados"
                                vlCelda.Value = 0

                            Case "FechaCreacion"
                                vlCelda.Value = LbConexion.cConexion.Instancia.ObtenerFecha

                            Case "AnioAprobacion"
                                vlCelda.Value = CInt(Format(LbConexion.cConexion.Instancia.ObtenerFecha, "yyyy"))

                            Case "FOSId"
                                vlCelda.Value = lbGeneral.cKeyGen.KEYGEN(prGrid.Row)
                            Case "Serie"
                                vlCelda.Value = ""

                        End Select
                    Case "grAsignacion"
                        Select Case vlCelda.Column.Key
                            Case "Inicio"
                                If FOSPrimerRegistroSerieCapturados(grFolioSolicitado.GetRow.Cells("FOSId").Value, grFolioSolicitado.GetRow.Cells("Serie").Value) AndAlso (vcFolio.FOSPrimerRegistroSerie(grFolioSolicitado.GetRow.Cells("Serie").Value)) Then
                                    vlCelda.Value = 1
                                    'ElseIf vcFolio.FOSPrimerRegistroFolio(grFolioSolicitado.GetRow.Cells("AnioAprobacion").Value, grFolioSolicitado.GetRow.Cells("serie").Value, grFolioSolicitado.GetRow.Cells("numeroAprobacion").Value) Then
                                    '    vlCelda.Value = FSHFinalSerie(grFolioSolicitado.GetRow.Cells("FOSId").Value, grFolioSolicitado.GetRow.Cells("Serie").Value) + 1
                                Else
                                    Dim iMaxSerieCapturados As Integer = FSHFinalSerie(grFolioSolicitado.GetRow.Cells("FOSId").Value, grFolioSolicitado.GetRow.Cells("Serie").Value)
                                    Dim iMaxSerieBD As Integer = vcFolio.FSHMaxDeSerie(grFolioSolicitado.GetRow.Cells("Serie").Value)
                                    vlCelda.Value = IIf(iMaxSerieCapturados > iMaxSerieBD, iMaxSerieCapturados, iMaxSerieBD)
                                End If
                            Case "Final"
                                vlCelda.Value = Me.grAsignacion.GetValue("inicio") + Me.grFolioSolicitado.GetValue("CantSolicitada") - Me.grFolioSolicitado.GetValue("usados") - 1
                                'If vcFolio.FOSPrimerRegistroFolio(grFolioSolicitado.GetRow.Cells("AnioAprobacion").Value, grFolioSolicitado.GetRow.Cells("serie").Value, grFolioSolicitado.GetRow.Cells("numeroAprobacion").Value) Then
                                '    vlCelda.Value = vcFolio.FSHFinalDeSerie(grFolioSolicitado.GetValue("Serie")) + grFolioSolicitado.GetValue("CantSolicitada")
                                'Else
                                '    vlCelda.Value = Me.grAsignacion.GetValue("Inicio") + grFolioSolicitado.GetValue("CantSolicitada")
                                'End If

                            Case "FechaCreacion"
                                vlCelda.Value = LbConexion.cConexion.Instancia.ObtenerFecha

                            Case "FOSId"
                                vlCelda.Value = grFolioSolicitado.GetRow.Cells("FOSId").Value

                            Case "Terminal"
                                If vcFolio.FSHFolioTerminal = True Then
                                    If vcFolio.FOSPrimerRegistroSerie(grFolioSolicitado.GetRow.Cells("serie").Value) = False Then
                                        vlCelda.Value = vcFolio.FSHCampoDeSerie("TerminalClave", grFolioSolicitado.GetValue("Serie"))
                                    Else
                                        vlCelda.Value = ""
                                    End If
                                End If

                            Case "Descripcion"
                                If vcFolio.FSHFolioTerminal = True Then
                                    Dim vlDataTable As DataTable
                                    vlDataTable = vcFolio.FSHTerminal(" TipoFase <> 0 and TipoFase <> 2 and TerminalClave = '" & vcFolio.FSHCampoDeSerie("TerminalClave", grFolioSolicitado.GetValue("Serie")) & "'")

                                    If vlDataTable.Rows.Count = 0 Then
                                        vlCelda.Value = ""
                                    Else
                                        vlCelda.Value = vlDataTable.Rows(0).Item("Descripcion")
                                    End If
                                End If

                            Case "VendedorId"
                                If vcFolio.FSHFolioTerminal = False Then
                                    If vcFolio.FOSPrimerRegistroSerie(grFolioSolicitado.GetRow.Cells("serie").Value) = False Then
                                        vlCelda.Value = vcFolio.FSHCampoDeSerie("VendedorId", grFolioSolicitado.GetValue("Serie"))
                                    Else
                                        vlCelda.Value = ""
                                    End If
                                End If

                            Case "Vendedor"
                                If vcFolio.FSHFolioTerminal = False Then
                                    Dim vlDataTable As DataTable
                                    vlDataTable = vcFolio.FSHVendedor(" TipoEstado = 1 and vendedorid = '" & vcFolio.FSHCampoDeSerie("VendedorId", grFolioSolicitado.GetValue("Serie")) & "'")
                                    If vlDataTable.Rows.Count = 0 Then
                                        vlCelda.Value = ""
                                    Else
                                        vlCelda.Value = vlDataTable.Rows(0).Item("nombre")
                                    End If
                                End If

                        End Select

                End Select
            End If
        Next
        'prGrid.EditMode = Janus.Windows.GridEX.EditMode.EditOn
    End Sub

    Private Function FOSPrimerRegistroSerieCapturados(ByVal FosId As String, ByVal Serie As String) As Boolean
        Dim bPrimerReg As Boolean = True

        Dim aFolios As ArrayList = vcFolio.recuperarFOSArray()
        Dim oFOS As ERMFOLLOG.Amesol.CFolioSolicitado
        For i As Integer = 0 To aFolios.Count - 1
            oFOS = aFolios(i)
            If FosId <> oFOS.FOSId Then
                If Serie = oFOS.Serie Then
                    Return False
                End If
            End If
        Next
        Return True
    End Function

    Private Function FSHFinalSerie(ByVal FosId As String, ByVal Serie As String) As Integer
        Dim iMaximo As Integer = 0
        Dim aFolios As ArrayList = vcFolio.recuperarFOSArray()
        Dim oFOS As ERMFOLLOG.Amesol.CFolioSolicitado
        Dim oFSH As ERMFOLLOG.Amesol.CFOSHist
        For i As Integer = 0 To aFolios.Count - 1
            oFOS = aFolios(i)
            If Serie = oFOS.Serie Then
                Dim aHistorico As ArrayList = vcFolio.recuperarFSHArray(oFOS.FOSId)
                For j As Integer = 0 To aHistorico.Count - 1
                    oFSH = aHistorico(j)
                    If oFSH.Fin > iMaximo Then
                        iMaximo = oFSH.Fin
                    End If
                Next
            End If
        Next
        Return iMaximo + 1
    End Function

    Private Function BuscarTipoComprobanteSerie(ByVal FosId As String, ByVal Serie As String) As Integer
        Dim iTipoComprobante As Integer = 0
        Dim aFolios As ArrayList = vcFolio.recuperarFOSArray()
        Dim oFOS As ERMFOLLOG.Amesol.CFolioSolicitado
        For i As Integer = 0 To aFolios.Count - 1
            oFOS = aFolios(i)
            If oFOS.FOSId <> FosId Then
                If Serie = oFOS.Serie Then
                    iTipoComprobante = oFOS.TipoComprobante
                    Exit For
                End If
            End If
        Next
        Return iTipoComprobante
    End Function

    Private Sub HabilitarRow(ByRef prGridName As String, ByVal pvValor As Boolean)
        Select Case prGridName
            Case "grFolioSolicitado"
                If pvValor Then
                    grFolioSolicitado.RootTable.Columns("Serie").EditType = Janus.Windows.GridEX.EditType.TextBox
                    grFolioSolicitado.RootTable.Columns("TipoComprobante").EditType = Janus.Windows.GridEX.EditType.DropDownList
                    grFolioSolicitado.RootTable.Columns("NumeroAprobacion").EditType = Janus.Windows.GridEX.EditType.TextBox
                    grFolioSolicitado.RootTable.Columns("AnioAprobacion").EditType = Janus.Windows.GridEX.EditType.TextBox
                    grFolioSolicitado.RootTable.Columns("cantSolicitada").EditType = Janus.Windows.GridEX.EditType.TextBox
                Else
                    grFolioSolicitado.RootTable.Columns("Serie").EditType = Janus.Windows.GridEX.EditType.NoEdit
                    grFolioSolicitado.RootTable.Columns("TipoComprobante").EditType = Janus.Windows.GridEX.EditType.NoEdit
                    grFolioSolicitado.RootTable.Columns("NumeroAprobacion").EditType = Janus.Windows.GridEX.EditType.NoEdit
                    grFolioSolicitado.RootTable.Columns("AnioAprobacion").EditType = Janus.Windows.GridEX.EditType.NoEdit
                    grFolioSolicitado.RootTable.Columns("cantSolicitada").EditType = Janus.Windows.GridEX.EditType.NoEdit
                End If
            Case "grAsignacion"
                If pvValor Then
                    grAsignacion.RootTable.Columns("Certificado").EditType = Janus.Windows.GridEX.EditType.TextBox
                    grAsignacion.RootTable.Columns("Certificado").ButtonStyle = Janus.Windows.GridEX.ButtonStyle.Ellipsis
                    If Me.grAsignacion.GetValue("certificado") <> "" Then
                        grAsignacion.RootTable.Columns("CentroExp").EditType = Janus.Windows.GridEX.EditType.DropDownList
                    Else
                        grAsignacion.RootTable.Columns("CentroExp").EditType = Janus.Windows.GridEX.EditType.NoEdit
                    End If
                    If vcFolio.FSHFolioTerminal Then
                        grAsignacion.RootTable.Columns("Terminal").EditType = Janus.Windows.GridEX.EditType.TextBox
                        grAsignacion.RootTable.Columns("Terminal").ButtonStyle = Janus.Windows.GridEX.ButtonStyle.Ellipsis
                        grAsignacion.RootTable.Columns("Vendedor").ButtonStyle = Janus.Windows.GridEX.ButtonStyle.NoButton
                    Else
                        grAsignacion.RootTable.Columns("Vendedor").EditType = Janus.Windows.GridEX.EditType.TextBox
                        grAsignacion.RootTable.Columns("Vendedor").ButtonStyle = Janus.Windows.GridEX.ButtonStyle.Ellipsis
                        grAsignacion.RootTable.Columns("Terminal").ButtonStyle = Janus.Windows.GridEX.ButtonStyle.NoButton
                    End If
                Else
                    grAsignacion.RootTable.Columns("Certificado").EditType = Janus.Windows.GridEX.EditType.NoEdit
                    grAsignacion.RootTable.Columns("Terminal").EditType = Janus.Windows.GridEX.EditType.NoEdit
                    grAsignacion.RootTable.Columns("Vendedor").EditType = Janus.Windows.GridEX.EditType.NoEdit
                    grAsignacion.RootTable.Columns("CentroExp").EditType = Janus.Windows.GridEX.EditType.NoEdit
                    grAsignacion.RootTable.Columns("Certificado").ButtonStyle = Janus.Windows.GridEX.ButtonStyle.NoButton
                    grAsignacion.RootTable.Columns("Terminal").ButtonStyle = Janus.Windows.GridEX.ButtonStyle.NoButton
                    grAsignacion.RootTable.Columns("Vendedor").ButtonStyle = Janus.Windows.GridEX.ButtonStyle.NoButton
                End If
                If Me.vgModo = eModo.Leer Then
                    grAsignacion.RootTable.Columns("Inicio").EditType = Janus.Windows.GridEX.EditType.NoEdit
                Else
                    If Me.vcFolio.FSHPrimerRegistroSerie(Me.grFolioSolicitado.GetValue("Serie")) AndAlso FOSPrimerRegistroSerieCapturados(Me.grFolioSolicitado.GetValue("FOSId"), Me.grFolioSolicitado.GetValue("Serie")) AndAlso Me.grFolioSolicitado.GetValue("usados") = 0 Then
                        grAsignacion.RootTable.Columns("Inicio").EditType = Janus.Windows.GridEX.EditType.TextBox
                    Else
                        grAsignacion.RootTable.Columns("Inicio").EditType = Janus.Windows.GridEX.EditType.NoEdit
                    End If
                End If
        End Select
    End Sub

    Private Sub ValidarRow(ByVal pvRow As Janus.Windows.GridEX.GridEXRow)
        If pvRow Is Nothing Then Exit Sub
        For Each vlCelda As Janus.Windows.GridEX.GridEXCell In pvRow.Cells
            validaCampo(vlCelda.Column.Key, vlCelda.Value)
        Next
    End Sub

    Private Sub validaCampo(ByVal pvColumna As String, ByVal pvValor As Object)
        Select Case pvColumna
            Case "Serie"
                If pvValor Is Nothing OrElse IsDBNull(pvValor) Then Exit Sub
                If Me.vcFolio.SerieEnOtroFolio(pvValor) Then
                    Throw New LbControlError.cError("E0691", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("FOS" & pvColumna, True)}, pvColumna)
                End If
            Case "CantSolicitada"
                If pvValor Is Nothing Or IsDBNull(pvValor) Or pvValor <= 0 Then
                    If VersionCFD = 1 Then
                        Throw New LbControlError.cError("E0237", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("FOS" & pvColumna, True)}, pvColumna)
                    Else
                        Throw New LbControlError.cError("E0237", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("XTotalFolios", True)}, pvColumna)
                    End If
                End If
            Case "NumeroAprobacion"
                If VersionCFD = 1 Then
                    If pvValor Is Nothing Or IsDBNull(pvValor) Or pvValor <= 0 Then
                        Throw New LbControlError.cError("E0237", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("FOS" & pvColumna, True)}, pvColumna)
                    End If
                End If
            Case "AnioAprobacion"
                If VersionCFD Then
                    If pvValor Is Nothing Or IsDBNull(pvValor) Or pvValor <= 0 Or pvValor < 1900 Then
                        Throw New LbControlError.cError("E0352", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("1900", False)}, pvColumna)
                    End If
                End If
            Case "Certificado"

                vcFolio.FSHValidarCertificado(pvValor)

            Case "TipoComprobante"
                If pvValor Is Nothing Or IsDBNull(pvValor) Then
                    Throw New LbControlError.cError("E0608", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("X" & pvColumna, True)}, pvColumna)
                End If
                'If pvValor Is Nothing Or IsDBNull(pvValor) Or vcFolio.FSHCertificadoVigente(pvValor) = False Then
                '    Throw New LbControlError.cError("E0647", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("FSH" & pvColumna, True)}, pvColumna)
                'End If
                'Dim vlVencimiento As Integer = vcFolio.FSHCertificadoVencimiento(pvValor)
                'If vcFolio.FSHNumCertCentroExp(pvValor).Rows.Count = 0 Then
                '    Throw New LbControlError.cError("E0674", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(vlVencimiento, False)}, pvColumna)
                'End If

                'grAsignacion.Tables(0).Columns("CentroExp").EditValueList.Add(New Janus.Windows.GridEX.GridEXValueListItem("123", "123"))
                'Dim lvlItemCol As New Janus.Windows.GridEX.GridEXValueListItemCollection
                'Dim dt As DataTable = vcFolio.FSHNumCertCentroExp(e.Value)
                'If dt.Select("tipo=1").Length = 0 Then
                '    For i As Integer = 0 To dt.Rows.Count - 1
                '        Dim lvlItem As New Janus.Windows.GridEX.GridEXValueListItem(dt.Rows(i)("CentroExpID"), dt.Rows(i)("CentroExpID") + " " + dt.Rows(i)("Nombre"))
                '        lvlItemCol.Add(lvlItem)
                '    Next
                'Else
                '    For Each fila As DataRow In dt.Select("tipo=1")
                '        Dim lvlItem As New Janus.Windows.GridEX.GridEXValueListItem(fila("CentroExpID"), fila("CentroExpID") + " " + fila("Nombre"))
                '        lvlItemCol.Add(lvlItem)
                '    Next
                'End If

                'grAsignacion.Tables(0).Columns("CentroExp").EditValueList = lvlItemCol
                ''If dt.Select("tipo=1").Length = 0 Then
                '    grAsignacion.GetRow.Cells("CentroExp").Value = dt.Rows(0)(0)
                '    grAsignacion.GetRow.Cells("CentroExp").Text = dt.Rows(0)(0) + " " + dt.Rows(0)("Nombre")
                'Else
                '    grAsignacion.GetRow.Cells("CentroExp").Value = dt.Select("tipo=1")(0)(0)
                '    grAsignacion.GetRow.Cells("CentroExp").Text = dt.Select("tipo=1")(0)(0) + " " + dt.Select("tipo=1")(0)("Nombre")
                'End If

            Case "CentroExp"
                If pvValor Is Nothing OrElse IsDBNull(pvValor) OrElse pvValor = "" Then
                    Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG("FSHCentroExp", True)}, pvColumna)
                End If

            Case "Terminal"
                If vcFolio.FSHFolioTerminal = True Then
                    If pvValor Is Nothing OrElse IsDBNull(pvValor) OrElse pvValor = "" OrElse vcFolio.FSHTerminalVigente(pvValor) = False Then
                        Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(pvColumna, False)}, pvColumna)
                    End If
                End If
            Case "Vendedor"
                If vcFolio.FSHFolioTerminal = False Then
                    If pvValor Is Nothing OrElse IsDBNull(pvValor) OrElse pvValor = "" Then
                        Throw New LbControlError.cError("BE0001", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(pvColumna, False)}, pvColumna)
                    End If
                End If

        End Select

    End Sub

    Private Function MuestraVendedores(ByVal sParametro As String) As ArrayList
        Dim vlSeleccion As New ArrayList
        Dim vlIVendedor As New ERMVENESC.IGeneral
        Try
            vlSeleccion = vlIVendedor.Seleccionar("TipoEstado = 1" & sParametro, False)
        Catch ex1 As LbControlError.cError
            ex1.Mostrar()
        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try
        Return vlSeleccion

    End Function

    Private Function MuestraTerminales(ByVal sParametro As String) As ArrayList
        Dim vlSeleccion As New ArrayList
        Dim vlTerminal As New ERMTERESC.IGeneral
        Try
            vlSeleccion = vlTerminal.Seleccionar("TipoFase <> 2 and TipoFase <> 0 " & sParametro, False)
        Catch ex1 As LbControlError.cError
            ex1.Mostrar()
        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try
        Return vlSeleccion
    End Function

    Private Function RecuperarTerminal(ByVal pvTexto As String) As ArrayList
        Try
            Dim vlTerminlaClaves As String = String.Empty
            Dim vlSeleccion As ArrayList
            Dim vlRenglon As Janus.Windows.GridEX.GridEXRow

            For Each vlRenglon In grAsignacion.GetRows
                vlTerminlaClaves &= "'" & vlRenglon.Cells("Terminal").Value & "',"
            Next

            If vlTerminlaClaves <> "" Then
                vlTerminlaClaves = vlTerminlaClaves.Substring(0, vlTerminlaClaves.Length - 1)
                vlSeleccion = MuestraTerminales(" AND TerminalClave not in (" & vlTerminlaClaves & ") and TerminalClave like '" & pvTexto.Trim & "%'")
            Else
                vlSeleccion = MuestraTerminales(" AND TerminalClave like '" & vlTerminlaClaves.Trim & "%' ")
            End If

            Return vlSeleccion
        Catch ex As LbControlError.cError
            ex.Mostrar()
            Return Nothing
        End Try

    End Function

    Private Function recuperarVendedor(ByVal pvTexto As String) As ArrayList
        Dim vlVendedorIDs As String = String.Empty
        Dim vlSeleccion As ArrayList
        Dim vlRenglon As Janus.Windows.GridEX.GridEXRow

        For Each vlRenglon In grAsignacion.GetRows
            vlVendedorIDs &= "'" & vlRenglon.Cells("VendedorID").Value & "',"
        Next
        If vlVendedorIDs <> "" Then
            vlVendedorIDs = vlVendedorIDs.Substring(0, vlVendedorIDs.Length - 1)
            vlSeleccion = MuestraVendedores(" AND VendedorID not in (" & vlVendedorIDs & ") AND Nombre like '" + pvTexto.Trim + "%'")
        Else
            vlSeleccion = MuestraVendedores(" AND Nombre like '" + pvTexto.Trim + "%'")
        End If


        Return vlSeleccion
    End Function

    Private Sub validarVendedorEnSerie(ByVal pvFosID As String, ByVal pvSerie As String, ByVal pvVendedorId As String, ByVal pvFSHFechaInicio As DateTime)
        If vcFolio.FSHVendedorEnSerie(pvFosID, pvSerie, pvVendedorId, pvFSHFechaInicio) = True Then
            Throw New LbControlError.cError("I0173", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(grFolioSolicitado.GetValue("Serie"), False)})
        End If
    End Sub

    Private Sub validarTerminalEnSerie(ByVal pvFosid As String, ByVal pvSerie As String, ByVal pvTerminalClave As String, ByVal pvFSHFechaInicio As DateTime)
        'If pvSerie = "" And pvTerminalClave = "" Then Exit Sub
        If vcFolio.FSHTerminalEnSerie(pvFosid, pvSerie, pvTerminalClave, pvFSHFechaInicio) = True Then
            Throw New LbControlError.cError("I0174", New LbControlError.cParametroMSG() {New LbControlError.cParametroMSG(pvSerie)})
        End If
    End Sub

    Private Function validarCambioFoliosTerminal(ByVal pvFolioTerminal As Boolean, ByVal pvDescripcion As String) As Boolean
        If bPreguntar = False Then Return True

        If pvFolioTerminal Then 'Es Terminal
            If MsgBox(Me.vcMensaje.RecuperarDescripcion("P0116", New String() {pvDescripcion}), MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Return False
            End If
        Else 'Es vendedor 
            If MsgBox(Me.vcMensaje.RecuperarDescripcion("P0117", New String() {pvDescripcion}), MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Return False
            End If
        End If

        bPreguntar = False
        Return True
    End Function

    Private Function validarCambioFoliosTerminal() As Boolean
        Dim vlContinuar As Boolean = True
        'If (grAsignacion.GetRow.RowType <> Janus.Windows.GridEX.RowType.NewRecord) Then
        If bPreguntar = False Then Return True

        If Me.vcFolio.FSHFolioTerminal Then 'Es Terminal
            If MsgBox(Me.vcMensaje.RecuperarDescripcion("P0116", New String() {Me.vcFolio.FOS(Me.grFolioSolicitado.GetValue("FOSId")).NombreVendedor}), MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                vlContinuar = False
                'grFolioSolicitado_SelectionChanged(Nothing, Nothing)
            End If
        Else 'Es vendedor 
            If MsgBox(Me.vcMensaje.RecuperarDescripcion("P0117", New String() {Me.vcFolio.FOS(Me.grFolioSolicitado.GetValue("FOSId")).TerminalClave}), MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                vlContinuar = False
                'grFolioSolicitado_SelectionChanged(Nothing, Nothing)
            End If
        End If

        If (grAsignacion.GetRow.RowType <> Janus.Windows.GridEX.RowType.NewRecord) Then
            If vlContinuar Then
                'HabilitarRow(grAsignacion.Name, False)
                'RaiseEvent Habilitar("btCrearAsignacion", True)
            End If
        End If
        bPreguntar = False
        Return vlContinuar
    End Function

    Public Sub validarGrids()
        If Not grFolioSolicitado.GetRow Is Nothing Then
            If grFolioSolicitado.GetRow.RowType = Janus.Windows.GridEX.RowType.NewRecord Then
                ValidarRow(grFolioSolicitado.GetRow)
            End If
        End If
        If Not grAsignacion.GetRow Is Nothing Then
            If grAsignacion.GetRow.RowType = Janus.Windows.GridEX.RowType.NewRecord Then
                ValidarRow(grAsignacion.GetRow)
            End If
        End If
    End Sub
#End Region

#Region "grFolioSolicitado"

    Private Sub grFolioSolicitado_AddingRecord(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles grFolioSolicitado.AddingRecord

        Try
            ValidarRow(grFolioSolicitado.GetRow)
            'If ValidarCampos(grFolioSolicitado) = False Then
            '    e.Cancel = True
            '    Exit Sub
            'End If
            If vcFolio.validarRegistroExistente(grFolioSolicitado.GetValue("NumeroAprobacion"), grFolioSolicitado.GetValue("AnioAprobacion"), grFolioSolicitado.GetValue("Serie")) Then
                Throw New LbControlError.cError("BE0002")
            End If

            Dim vcFolioSolicitado As New ERMFOLLOG.Amesol.CFolioSolicitado

            vcFolioSolicitado.Insertar(vcFolio.FolioID, grFolioSolicitado.GetValue("FOSId"), grFolioSolicitado.GetValue("Serie"), LbConexion.cConexion.Instancia.ObtenerFecha, grFolioSolicitado.GetValue("NumeroAprobacion"), grFolioSolicitado.GetValue("AnioAprobacion"), grFolioSolicitado.GetValue("cantSolicitada"), grFolioSolicitado.GetValue("Usados"), grFolioSolicitado.GetValue("TipoComprobante"))
            vcFolio.InsertarFOS(vcFolioSolicitado)

            'Me.grFolioSolicitado.Refresh()
            Me.grFolioSolicitado.DataSource = vcFolio.recuperarFOSArray
            RaiseEvent Habilitar("btCrearAsignacion", True)

            Me.grFolioSolicitado.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.False
        Catch ex As LbControlError.cError
            ex.Mostrar()
            e.Cancel = True
        End Try
    End Sub

    Private Sub grFolioSolicitado_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grFolioSolicitado.SelectionChanged
        If (grFolioSolicitado.GetRow Is Nothing) OrElse vcFolio.FOS(grFolioSolicitado.GetValue("FOSId")) Is Nothing Then
            RaiseEvent Habilitar("btEliminarFolio", False)
            RaiseEvent Habilitar("btCrearAsignacion", False)
            HabilitarRow(grFolioSolicitado.Name, False)
        Else
            Try
                Select Case (vgModo)
                    Case eModo.Crear
                        RaiseEvent Habilitar("btEliminarFolio", True)
                        RaiseEvent Habilitar("btCrearAsignacion", True)
                        HabilitarRow(grFolioSolicitado.Name, True)

                    Case eModo.Modificar

                        If (grFolioSolicitado.GetRow.RowType = Janus.Windows.GridEX.RowType.NewRecord) Or _
                       (vcFolio.FOS(grFolioSolicitado.GetValue("FOSId")).Estado = eEstado.Nuevo) Then
                            RaiseEvent Habilitar("btEliminarFolio", True)
                            HabilitarRow(grFolioSolicitado.Name, True)

                            If vcFolio.recuperarFSHArray(grFolioSolicitado.GetValue("FOSId")).Count = 0 Then
                                RaiseEvent Habilitar("btCrearAsignacion", True)
                            End If

                        ElseIf vcFolio.recuperarFSHArray(grFolioSolicitado.GetValue("FOSId")).Count = 0 Then
                            RaiseEvent Habilitar("btEliminarFolio", True)
                            RaiseEvent Habilitar("btCrearAsignacion", True)
                            HabilitarRow(grFolioSolicitado.Name, True)
                        Else
                            RaiseEvent Habilitar("btEliminarFolio", False)
                            HabilitarRow(grFolioSolicitado.Name, False)
                        End If

                    Case eModo.Leer
                        Me.lbUsuarioFolios.Text = Me.grFolioSolicitado.GetValue("Usuario")
                        Me.lbFechaModificacionFolios.Text = Format(Me.grFolioSolicitado.GetValue("FechaHora"), "dd/MM/yyyy HH:mm:ss tt")
                        Me.lbUsuarioAsignacion.Visible = True
                        Me.lbUsuarioFolios.Visible = True
                        Me.lbFechaModificacionAsignacion.Visible = True
                        Me.lbFechaModificacionFolios.Visible = True
                        HabilitarRow(grFolioSolicitado.Name, False)
                        Me.grAsignacion.DataSource = vcFolio.recuperarFSHArrayHistorico(grFolioSolicitado.GetValue("FOSId"))
                        Exit Sub
                End Select

            Catch ex As Exception
                RaiseEvent Habilitar("btEliminarFolio", False)
                RaiseEvent Habilitar("btCrearAsignacion", False)
                MsgBox(ex.Message)
                Exit Sub
            End Try
        End If

        Me.grAsignacion.DataSource = Nothing
        If Not grFolioSolicitado.GetValue("FOSId") Is Nothing Then
            Me.grAsignacion.DataSource = vcFolio.recuperarFSHArray(grFolioSolicitado.GetValue("FOSId"))
            If Me.grAsignacion.RowCount > 0 Then
                grFolioSolicitado.RootTable.Columns("cantSolicitada").EditType = Janus.Windows.GridEX.EditType.NoEdit
            Else
                grFolioSolicitado.RootTable.Columns("cantSolicitada").EditType = Janus.Windows.GridEX.EditType.TextBox
            End If
        End If
    End Sub

    Private Sub grFolioSolicitado_UpdatingRecord(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles grFolioSolicitado.UpdatingRecord
        Try
            If grFolioSolicitado.GetValue("FOSId") Is Nothing Then Exit Sub

            If vcFolio.validarRegistroExistente(grFolioSolicitado.GetValue("NumeroAprobacion"), grFolioSolicitado.GetValue("AnioAprobacion"), grFolioSolicitado.GetValue("Serie"), grFolioSolicitado.GetValue("FOSId")) Then
                Throw New LbControlError.cError("BE0002")
            End If

            Dim vcFOS As ERMFOLLOG.Amesol.CFolioSolicitado = vcFolio.FOS(grFolioSolicitado.GetValue("FOSId"))
            With vcFOS
                .Serie = grFolioSolicitado.GetValue("Serie")
                .TipoComprobante = grFolioSolicitado.GetValue("TipoComprobante")
                If VersionCFD = 1 Then
                    .Aprobacion = grFolioSolicitado.GetValue("NumeroAprobacion")
                    .AnioAprobacion = grFolioSolicitado.GetValue("AnioAprobacion")
                Else
                    .Aprobacion = 0
                    .AnioAprobacion = CInt(Format(LbConexion.cConexion.Instancia.ObtenerFecha, "yyyy"))
                End If
                .CantSolicitada = grFolioSolicitado.GetValue("cantSolicitada")
                .Usados = grFolioSolicitado.GetValue("Usados")
            End With

        Catch ex As LbControlError.cError
            e.Cancel = True
            ex.Mostrar()
        End Try
    End Sub

    Private Sub grFolioSolicitado_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grFolioSolicitado.Leave
        DeshabilitaCrear(Me.grFolioSolicitado)
    End Sub

    Private Sub grFolioSolicitado_CellEditCanceled(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grFolioSolicitado.CellEditCanceled
        DeshabilitaCrear(Me.grFolioSolicitado)
    End Sub

    Private Sub grFolioSolicitado_RowEditCanceled(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.RowActionEventArgs) Handles grFolioSolicitado.RowEditCanceled
        If Not grFolioSolicitado.GetRow Is Nothing Then
            If (grFolioSolicitado.GetRow.RowType = Janus.Windows.GridEX.RowType.NewRecord) Then
                grFolioSolicitado.CancelCurrentEdit()
            End If
        End If
        DeshabilitaCrear(Me.grFolioSolicitado)
        grFolioSolicitado.EditMode = Janus.Windows.GridEX.EditMode.EditOff
        grFolioSolicitado.MoveLast()
    End Sub

    Private Sub grFolioSolicitado_UpdatingCell(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.UpdatingCellEventArgs) Handles grFolioSolicitado.UpdatingCell
        Try
            If blnEditado Then Exit Sub
            validaCampo(e.Column.Key, e.Value)
            If e.Column.Key.ToUpper = "SERIE" Then
                If grAsignacion.RowCount > 0 Then
                    MsgBox(vcMensaje.RecuperarDescripcion("E0068"), MsgBoxStyle.Critical)
                    e.Value = e.InitialValue
                Else
                    Dim iTipoComprobante As Integer = BuscarTipoComprobanteSerie(grFolioSolicitado.GetValue("FOSId"), e.Value)
                    If iTipoComprobante <> 0 AndAlso Not IsNothing(grFolioSolicitado.GetValue("TipoComprobante")) AndAlso iTipoComprobante <> grFolioSolicitado.GetValue("TipoComprobante") Then
                        MsgBox(vcMensaje.RecuperarDescripcion("I0252"), MsgBoxStyle.Critical)
                        e.Value = e.InitialValue
                    End If
                End If
            ElseIf e.Column.Key.ToUpper = "TIPOCOMPROBANTE" Then
                If Not IsNothing(grFolioSolicitado.GetValue("Serie")) AndAlso grFolioSolicitado.GetValue("Serie") <> "" Then
                    Dim iTipoComprobante As Integer = BuscarTipoComprobanteSerie(grFolioSolicitado.GetValue("FOSId"), e.Value)
                    If iTipoComprobante <> e.Value Then
                        MsgBox(vcMensaje.RecuperarDescripcion("I0252"), MsgBoxStyle.Critical)
                        e.Value = e.InitialValue
                    End If
                End If
            End If
        Catch ex As LbControlError.cError
            ex.Mostrar()
            e.Cancel = True
            e.Value = e.InitialValue
        End Try
    End Sub

    Private Sub grFolioSolicitado_FirstChange(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.RowActionEventArgs) Handles grFolioSolicitado.FirstChange
        RaiseEvent Habilitar("HuboCambios", True)
    End Sub

#End Region

#Region "grAsignacion"

    Private Sub grAsignacion_AddingRecord(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles grAsignacion.AddingRecord

        Try
            ValidarRow(grAsignacion.GetRow)
            If Me.vgModo = eModo.Modificar And vcFolio.FOSPrimerRegistroFolio(grFolioSolicitado.GetRow.Cells("AnioAprobacion").Value, grFolioSolicitado.GetRow.Cells("Serie").Value, grFolioSolicitado.GetRow.Cells("numeroAprobacion").Value) = False Then
                Dim vlValorFinal As Integer

                vlValorFinal = grAsignacion.GetRow(Me.grAsignacion.RowCount - 3).Cells("Final").Text
                If Not grAsignacion.GetRow(Me.grAsignacion.RowCount - 3).Cells("FOSId").Value Is Nothing Then
                    Dim vcFSH As ERMFOLLOG.Amesol.CFOSHist = vcFolio.FSH(grAsignacion.GetRow(Me.grAsignacion.RowCount - 3).Cells("FOSId").Value, grAsignacion.GetRow(Me.grAsignacion.RowCount - 3).Cells("FechaCreacion").Value)
                    With vcFSH
                        .Fin = vlValorFinal
                        '.Tabla.Campos("FSHFechaInicio").Valor = LbConexion.cConexion.Instancia.ObtenerFecha.AddSeconds(-1)
                    End With
                End If

            End If

            Dim vcFOSHist As New ERMFOLLOG.Amesol.CFOSHist
            vcFOSHist.Insertar(vcFolio.FolioID, grAsignacion.GetValue("FOSId"), LbConexion.cConexion.Instancia.ObtenerFecha, grAsignacion.GetValue("VendedorID"), grAsignacion.GetValue("terminal"), grAsignacion.GetValue("Certificado"), grAsignacion.GetValue("CentroExpid"), grAsignacion.GetValue("Inicio"), grAsignacion.GetValue("Final"))
            vcFOSHist.Vendedor = grAsignacion.GetValue("vendedor")
            vcFOSHist.Descripcion = grAsignacion.GetValue("Descripcion")
            vcFolio.InsertarFSH(vcFOSHist)

            Me.grAsignacion.DataSource = vcFolio.recuperarFSHArray(grFolioSolicitado.GetValue("FOSId"))
            RaiseEvent Habilitar("btEliminarAsignacion", True)
            RaiseEvent Habilitar("btCrearAsignacion", False)
            If Me.grAsignacion.RowCount > 0 Then
                grFolioSolicitado.RootTable.Columns("cantSolicitada").EditType = Janus.Windows.GridEX.EditType.NoEdit
            Else
                grFolioSolicitado.RootTable.Columns("cantSolicitada").EditType = Janus.Windows.GridEX.EditType.TextBox
            End If
        Catch ex As LbControlError.cError
            ex.Mostrar()
            e.Cancel = True
        End Try

        If Not Me.grAsignacion.GetValue("certificado") Is Nothing AndAlso Me.grAsignacion.GetValue("certificado") <> "" Then
            Dim dt As DataTable = vcFolio.FSHNumCertCentroExp(Me.grAsignacion.GetValue("certificado"))
            For Each row As DataRow In dt.Rows
                If row("CentroExpId") = grAsignacion.GetValue("CentroExpID") Then
                    grAsignacion.GetRow.Cells("CentroExp").Value = grAsignacion.GetValue("CentroExpID")
                    grAsignacion.GetRow.Cells("CentroExp").Text = grAsignacion.GetValue("CentroExpID") + " " + row("nombre")
                End If
            Next
        End If
        DeshabilitaCrear(grAsignacion)
    End Sub

    Private Sub grAsignacion_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grAsignacion.SelectionChanged
        bPreguntar = True

        If (Me.grAsignacion.GetRow Is Nothing) OrElse vcFolio.FSH(grAsignacion.GetValue("FOSId"), grAsignacion.GetValue("FechaCreacion")) Is Nothing Then
            RaiseEvent Habilitar("btEliminarAsignacion", False)
            HabilitarRow(grAsignacion.Name, False)
            Select Case (vgModo)
                Case eModo.Leer
                    Me.lbUsuarioAsignacion.Text = Me.grAsignacion.GetValue("Usuario")
                    Me.lbFechaModificacionAsignacion.Text = Format(Me.grAsignacion.GetValue("FechaHora"), "dd/MM/yyyy HH:mm:ss tt")
                    HabilitarRow(grAsignacion.Name, False)
            End Select
        Else
            Try
                Select Case (vgModo)
                    Case eModo.Crear
                        HabilitarRow(grAsignacion.Name, True)
                        RaiseEvent Habilitar("btEliminarAsignacion", True)

                    Case eModo.Modificar
                        If (grAsignacion.GetRow.RowType = Janus.Windows.GridEX.RowType.NewRecord) Or _
                        vcFolio.FSH(grAsignacion.GetValue("FOSId"), grAsignacion.GetValue("FechaCreacion")).estado = eEstado.Nuevo Then
                            RaiseEvent Habilitar("btEliminarAsignacion", True)
                            RaiseEvent Habilitar("btCrearAsignacion", False)
                        ElseIf Me.grFolioSolicitado.GetValue("usados") = 0 _
                        Or Me.vcFolio.FSHInicioPrimerRegistroSerie(Me.grFolioSolicitado.GetValue("Serie"), grFolioSolicitado.GetValue("AnioAprobacion"), grFolioSolicitado.GetValue("NumeroAprobacion")) + Me.grFolioSolicitado.GetValue("usados") = Me.grAsignacion.GetValue("inicio") Then
                            RaiseEvent Habilitar("btEliminarAsignacion", False)
                            RaiseEvent Habilitar("btCrearAsignacion", False)
                        ElseIf grFolioSolicitado.GetValue("usados") + 1 = Me.grAsignacion.GetValue("inicio") Then
                            RaiseEvent Habilitar("btEliminarAsignacion", False)
                            RaiseEvent Habilitar("btCrearAsignacion", False)
                        ElseIf Me.vcFolio.recuperarFSHArray(Me.grAsignacion.GetValue("Fosid")).Count < 2 Then
                            RaiseEvent Habilitar("btEliminarAsignacion", False)
                            RaiseEvent Habilitar("btCrearAsignacion", True)
                        Else
                            RaiseEvent Habilitar("btEliminarAsignacion", False)
                            RaiseEvent Habilitar("btCrearAsignacion", False)
                        End If

                        If (grAsignacion.GetRow.RowType = Janus.Windows.GridEX.RowType.NewRecord) _
                        Or vcFolio.FSH(grAsignacion.GetValue("FOSId"), grAsignacion.GetValue("FechaCreacion")).estado = eEstado.Nuevo Then
                            HabilitarRow(grAsignacion.Name, True)
                        ElseIf (vcFolio.FSH(grAsignacion.GetValue("FOSId"), grAsignacion.GetValue("FechaCreacion")).estado = eEstado.Nuevo _
                        Or grFolioSolicitado.GetValue("usados") = 0 Or grFolioSolicitado.GetValue("usados") + 1 = Me.grAsignacion.GetValue("inicio")) _
                        And Me.vcFolio.recuperarFSHArray(Me.grAsignacion.GetValue("Fosid")).Count < 2 Then
                            HabilitarRow(grAsignacion.Name, True)
                        ElseIf Me.vcFolio.FSHInicioPrimerRegistroSerie(Me.grFolioSolicitado.GetValue("Serie"), grFolioSolicitado.GetValue("AnioAprobacion"), grFolioSolicitado.GetValue("NumeroAprobacion")) + Me.grFolioSolicitado.GetValue("usados") = Me.grAsignacion.GetValue("inicio") Then
                            HabilitarRow(grAsignacion.Name, True)
                        Else
                            HabilitarRow(grAsignacion.Name, False)
                        End If

                        Dim lvlItemCol As New Janus.Windows.GridEX.GridEXValueListItemCollection
                        Dim dt As DataTable = vcFolio.FSHNumCertCentroExp(Me.grAsignacion.GetValue("certificado"))
                        If dt.Select("tipo=1").Length = 0 Then
                            For i As Integer = 0 To dt.Rows.Count - 1
                                Dim lvlItem As New Janus.Windows.GridEX.GridEXValueListItem(dt.Rows(i)("CentroExpID"), dt.Rows(i)("CentroExpID") + " " + dt.Rows(i)("Nombre"))
                                lvlItemCol.Add(lvlItem)
                            Next
                        Else
                            For Each fila As DataRow In dt.Select("tipo=1")
                                Dim lvlItem As New Janus.Windows.GridEX.GridEXValueListItem(fila("CentroExpID"), fila("CentroExpID") + " " + fila("Nombre"))
                                lvlItemCol.Add(lvlItem)
                            Next
                        End If
                        grAsignacion.Tables(0).Columns("CentroExp").EditValueList = lvlItemCol

                    Case eModo.Leer
                        Me.lbUsuarioAsignacion.Text = Me.grAsignacion.GetValue("Usuario")
                        Me.lbFechaModificacionAsignacion.Text = Format(Me.grAsignacion.GetValue("FechaHora"), "dd/MM/yyyy HH:mm:ss tt")
                        HabilitarRow(grAsignacion.Name, False)

                End Select

            Catch ex As Exception
                RaiseEvent Habilitar("btEliminarAsignacion", False)
                RaiseEvent Habilitar("btCrearAsignacion", False)
                HabilitarRow(grAsignacion.Name, False)
                MsgBox(ex.Message)
                Exit Sub
            End Try

        End If



    End Sub

    Private Sub grAsignacion_UpdatingRecord(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles grAsignacion.UpdatingRecord
        Try

            If grAsignacion.GetValue("FOSId") Is Nothing Then Exit Sub
            If grAsignacion.RootTable.Columns("Certificado").EditType = Janus.Windows.GridEX.EditType.NoEdit Then Exit Sub

            ValidarRow(grAsignacion.GetRow)

            Dim vcFSH As ERMFOLLOG.Amesol.CFOSHist = vcFolio.FSH(grAsignacion.GetValue("FOSId"), grAsignacion.GetValue("FechaCreacion"))
            With vcFSH
                .VendedorID = grAsignacion.GetValue("VendedorId")
                .Vendedor = grAsignacion.GetValue("vendedor")
                .TerminalClave = grAsignacion.GetValue("terminal")
                .NumCertificado = grAsignacion.GetValue("Certificado")
                .CentroExpID = grAsignacion.GetValue("CentroExpid")
                .Inicio = grAsignacion.GetValue("Inicio")
                .Fin = grAsignacion.GetValue("Final")
                .Descripcion = grAsignacion.GetValue("Descripcion")
                '.Tabla.Campos("FSHFechaInicio").Valor = LbConexion.cConexion.Instancia.ObtenerFecha
            End With

        Catch ex As LbControlError.cError
            e.Cancel = True
            ex.Mostrar()
        End Try
    End Sub

    Private Sub grAsignacion_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grAsignacion.Leave
        DeshabilitaCrear(Me.grAsignacion)

    End Sub

    Private Sub grAsignacion_UpdatingCell(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.UpdatingCellEventArgs) Handles grAsignacion.UpdatingCell
        Dim vlDataTable As DataTable

        Select Case e.Column.Key
            Case "Vendedor"
                Try
                    If IsNothing(e.Value) Or IsDBNull(e.Value) Then
                        MsgBox(vcMensaje.RecuperarDescripcion("E0648"), MsgBoxStyle.Critical, e.Column.Key)
                        e.Cancel = True
                        e.Value = e.InitialValue
                        Exit Sub
                    End If

                    Dim vlContinuar As Boolean = True
                    If Me.vcFolio.FOS(Me.grFolioSolicitado.GetValue("FOSId")).CambioFoliosTerminal Then 'si cambio el parametro de foliosTerminal
                        vlContinuar = validarCambioFoliosTerminal()
                    Else 'Si no cambio foliosterminal

                        Me.validarVendedorEnSerie(grFolioSolicitado.GetValue("FosId"), grFolioSolicitado.GetValue("serie"), Me.grAsignacion.GetValue("VendedorId"), Me.grAsignacion.GetValue("FechaCreacion"))
                        If Me.vgModo = eModo.Modificar And grAsignacion.GetRow.RowType <> Janus.Windows.GridEX.RowType.NewRecord _
                        And (Not vcFolio.FSH(grAsignacion.GetValue("FOSId"), grAsignacion.GetValue("FechaCreacion")) Is Nothing AndAlso vcFolio.FSH(grAsignacion.GetValue("FOSId"), grAsignacion.GetValue("FechaCreacion")).estado <> eEstado.Nuevo) Then
                            vlContinuar = validarCambioFoliosTerminal(Not vcFolio.FSHFolioTerminal, e.InitialValue)
                        End If
                    End If

                    If vlContinuar Then
                        vlDataTable = vcFolio.FSHVendedor(" TipoEstado = 1 and Nombre like '" + e.Value.ToString.Trim().Replace("'", "''") + "%'")
                        If vlDataTable.Rows.Count > 0 AndAlso (e.Value = vlDataTable.Rows(0)!Nombre And grAsignacion.GetRow.Cells("VendedorId").Value = vlDataTable.Rows(0)!VendedorId) Then
                            Exit Sub
                        End If

                        If vlDataTable.Rows.Count = 0 Then
                            MsgBox(vcMensaje.RecuperarDescripcion("E0648"), MsgBoxStyle.Critical, e.Column.Key)
                            e.Value = e.InitialValue
                            Exit Sub
                        ElseIf vlDataTable.Rows.Count = 1 Then
                            e.Value = vlDataTable.Rows(0)!Nombre
                            grAsignacion.GetRow.Cells("VendedorId").Value = vlDataTable.Rows(0)!VendedorId
                            grAsignacion.SetValue("Terminal", "")
                            grAsignacion.SetValue("Descripcion", "")
                        ElseIf vlDataTable.Rows.Count > 1 Then

                            Dim vlSeleccion As ArrayList = recuperarVendedor(e.Value)
                            If vlSeleccion Is Nothing OrElse vlSeleccion.Count <= 0 Then
                                grAsignacion.GetRow.Cells("VendedorId").Value = ""
                                e.Value = e.InitialValue
                                grAsignacion.SetValue("Terminal", "")
                                grAsignacion.SetValue("Descripcion", "")
                                e.Cancel = True
                            Else
                                e.Value = vlSeleccion(0).nombre
                                grAsignacion.GetRow.Cells("VendedorId").Value = vlSeleccion(0).VendedorId
                                grAsignacion.SetValue("Terminal", "")
                                grAsignacion.SetValue("Descripcion", "")
                            End If
                        End If
                    Else
                        e.Value = e.InitialValue
                    End If

                Catch ex As LbControlError.cError
                    ex.Mostrar()
                    e.Value = e.InitialValue
                End Try

            Case "Terminal"
                If IsNothing(e.Value) Or IsDBNull(e.Value) Then
                    MsgBox(vcMensaje.RecuperarDescripcion("E0648"), MsgBoxStyle.Critical, e.Column.Key)
                    e.Cancel = True
                    e.Value = e.InitialValue
                    Exit Sub
                End If

                Try
                    Dim vlContinuar As Boolean = True
                    If Me.vcFolio.FOS(Me.grFolioSolicitado.GetValue("FOSId")).CambioFoliosTerminal Then 'si cambio el parametro de foliosTerminal
                        vlContinuar = validarCambioFoliosTerminal()
                    Else
                        Me.validarTerminalEnSerie(grFolioSolicitado.GetValue("FOSID"), grFolioSolicitado.GetValue("serie"), e.InitialValue, Me.grAsignacion.GetValue("FechaCreacion"))
                        If Me.vgModo = eModo.Modificar And grAsignacion.GetRow.RowType <> Janus.Windows.GridEX.RowType.NewRecord _
                        And (Not vcFolio.FSH(grAsignacion.GetValue("FOSId"), grAsignacion.GetValue("FechaCreacion")) Is Nothing AndAlso vcFolio.FSH(grAsignacion.GetValue("FOSId"), grAsignacion.GetValue("FechaCreacion")).estado <> eEstado.Nuevo) Then
                            vlContinuar = validarCambioFoliosTerminal(Not vcFolio.FSHFolioTerminal, e.InitialValue)
                        End If
                    End If

                    If vlContinuar Then
                        vlDataTable = vcFolio.FSHTerminal(" TipoFase <> 0 and TipoFase <> 2 and TerminalClave like '" & e.Value.ToString.Trim().Replace("'", "''") & "%'")
                        If vlDataTable.Rows.Count = 0 Then
                            MsgBox(vcMensaje.RecuperarDescripcion("BE0003", New String() {e.Column.Key}), MsgBoxStyle.Critical, e.Column.Key)
                            e.Cancel = True
                            e.Value = e.InitialValue
                            Exit Sub
                        ElseIf vlDataTable.Rows.Count = 1 Then
                            e.Value = vlDataTable.Rows(0)!TerminalClave
                            grAsignacion.GetRow.Cells("Descripcion").Value = vlDataTable.Rows(0)!Descripcion
                            grAsignacion.SetValue("Vendedor", "")
                            grAsignacion.SetValue("VendedorID", "")
                        ElseIf vlDataTable.Rows.Count > 1 Then
                            Dim vlSeleccion As ArrayList = RecuperarTerminal(e.Value)
                            If vlSeleccion Is Nothing OrElse vlSeleccion.Count <= 0 Then
                                e.Value = e.InitialValue
                                grAsignacion.SetValue("Vendedor", "")
                                grAsignacion.SetValue("VendedorID", "")
                                e.Cancel = True
                            Else
                                e.Value = vlSeleccion(0).TerminalClave
                                grAsignacion.GetRow.Cells("Descripcion").Value = vlSeleccion(0).Descripcion
                                grAsignacion.SetValue("Vendedor", "")
                                grAsignacion.SetValue("VendedorID", "")
                            End If

                        End If
                    Else
                        e.Value = e.InitialValue
                    End If

                Catch ex As LbControlError.cError
                    ex.Mostrar()
                    e.Value = e.InitialValue
                End Try

            Case "Certificado"
                Try
                    validaCampo(e.Column.Key, e.Value)
                    Dim vlVencimiento As Integer = vcFolio.FSHCertificadoVencimiento(e.Value)
                    If vlVencimiento <= 15 Then
                        MsgBox(vcMensaje.RecuperarDescripcion("I0176", New String() {vlVencimiento}), MsgBoxStyle.Critical, vcMensaje.RecuperarDescripcion("FSH" & e.Column.Key))
                    End If

                    Dim lvlItemCol As New Janus.Windows.GridEX.GridEXValueListItemCollection
                    Dim dt As DataTable = vcFolio.FSHNumCertCentroExp(e.Value)
                    If dt.Select("tipo=1").Length = 0 Then
                        For i As Integer = 0 To dt.Rows.Count - 1
                            Dim lvlItem As New Janus.Windows.GridEX.GridEXValueListItem(dt.Rows(i)("CentroExpID"), dt.Rows(i)("CentroExpID") + " " + dt.Rows(i)("Nombre"))
                            lvlItemCol.Add(lvlItem)
                        Next
                    Else
                        For Each fila As DataRow In dt.Select("tipo=1")
                            Dim lvlItem As New Janus.Windows.GridEX.GridEXValueListItem(fila("CentroExpID"), fila("CentroExpID") + " " + fila("Nombre"))
                            lvlItemCol.Add(lvlItem)
                        Next
                    End If
                    grAsignacion.RootTable.Columns("CentroExp").EditType = Janus.Windows.GridEX.EditType.DropDownList
                    grAsignacion.Tables(0).Columns("CentroExp").EditValueList = lvlItemCol

                    If dt.Select("tipo=1").Length = 0 Then
                        grAsignacion.GetRow.Cells("CentroExp").Text = dt.Rows(0).Item("centroexpid") + " " + dt.Rows(0).Item("Nombre")
                        grAsignacion.GetRow.Cells("CentroExp").Value = dt.Rows(0)("CentroExpID")
                        grAsignacion.GetRow.Cells("CentroExpID").Value = dt.Rows(0).Item("centroexpid")
                    Else
                        grAsignacion.GetRow.Cells("CentroExp").Text = dt.Select("tipo=1")(0).Item("centroexpid") + " " + dt.Select("tipo=1")(0).Item("Nombre")
                        grAsignacion.GetRow.Cells("CentroExp").Value = dt.Select("tipo=1")(0).Item("centroexpid")
                        grAsignacion.GetRow.Cells("CentroExpID").Value = dt.Select("tipo=1")(0).Item("centroexpid")
                    End If


                Catch ex As LbControlError.cError
                    ex.Mostrar()
                    e.Cancel = True
                    grAsignacion.GetRow.Cells("CentroExp").Text = ""
                    grAsignacion.GetRow.Cells("CentroExp").Value = ""
                    e.Value = e.InitialValue
                End Try
            Case "Inicio"
                Try
                    validaCampo(e.Column.Key, e.Value)
                Catch ex As LbControlError.cError
                    ex.Mostrar()
                    e.Cancel = True
                    e.Value = e.InitialValue
                    Exit Sub
                End Try
                grAsignacion.SetValue("Final", e.Value + Me.grFolioSolicitado.GetValue("CantSolicitada") - Me.grFolioSolicitado.GetValue("usados") - 1)
            Case "CentroExp"

                If Me.grAsignacion.GetValue("Certificado") Is Nothing Or Me.grAsignacion.GetValue("Certificado") = "" Then
                    Exit Sub
                End If

                Try
                    validaCampo(e.Column.Key, e.Value)
                Catch ex As LbControlError.cError
                    ex.Mostrar()
                    e.Cancel = True
                    e.Value = e.InitialValue
                    Exit Sub
                End Try
                grAsignacion.SetValue("CentroExpID", e.Value)

            Case Else
                Try
                    validaCampo(e.Column.Key, e.Value)
                Catch ex As LbControlError.cError
                    ex.Mostrar()
                    e.Cancel = True
                    e.Value = e.InitialValue
                End Try
        End Select
    End Sub

    Private Sub grAsignacion_CellEditCanceled(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grAsignacion.CellEditCanceled
        DeshabilitaCrear(Me.grAsignacion)
        'grFolioSolicitado_SelectionChanged(Nothing, Nothing)
    End Sub

    Private Sub grAsignacion_RowEditCanceled(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.RowActionEventArgs) Handles grAsignacion.RowEditCanceled
        DeshabilitaCrear(Me.grAsignacion)
        'grFolioSolicitado_SelectionChanged(Nothing, Nothing)
    End Sub

    Private Sub grAsignacion_FirstChange(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.RowActionEventArgs) Handles grAsignacion.FirstChange
        RaiseEvent Habilitar("HuboCambios", True)
    End Sub

    Private Sub grAsignacion_ColumnButtonClick(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grAsignacion.ColumnButtonClick
        bPreguntar = True

        Select Case e.Column.Key
            Case "Terminal"
                Try
                    Dim vlContinuar As Boolean = True
                    If Me.vcFolio.FOS(Me.grFolioSolicitado.GetValue("FOSId")).CambioFoliosTerminal Then 'si cambio el parametro de foliosTerminal
                        vlContinuar = validarCambioFoliosTerminal()
                    Else '
                        Me.validarTerminalEnSerie(grFolioSolicitado.GetValue("FOSID"), grFolioSolicitado.GetValue("serie"), Me.grAsignacion.GetValue("Terminal"), Me.grAsignacion.GetValue("FechaCreacion"))
                        If Me.vgModo = eModo.Modificar And grAsignacion.GetRow.RowType <> Janus.Windows.GridEX.RowType.NewRecord And Me.grAsignacion.GetValue("terminal") <> "" _
                       And (Not vcFolio.FSH(grAsignacion.GetValue("FOSId"), grAsignacion.GetValue("FechaCreacion")) Is Nothing AndAlso vcFolio.FSH(grAsignacion.GetValue("FOSId"), grAsignacion.GetValue("FechaCreacion")).estado <> eEstado.Nuevo) Then
                            vlContinuar = validarCambioFoliosTerminal(Not vcFolio.FSHFolioTerminal, Me.grAsignacion.GetValue("terminal"))
                        End If
                    End If

                    If vlContinuar And grAsignacion.RootTable.Columns("Terminal").EditType <> Janus.Windows.GridEX.EditType.NoEdit Then
                        Dim vlSeleccion As ArrayList
                        vlSeleccion = RecuperarTerminal("")
                        If Not vlSeleccion Is Nothing AndAlso vlSeleccion.Count > 0 Then
                            grAsignacion.SetValue("Terminal", vlSeleccion(0).TerminalClave)
                            grAsignacion.SetValue("Descripcion", vlSeleccion(0).Descripcion)
                            grAsignacion.SetValue("Vendedor", "")
                            grAsignacion.SetValue("Vendedorid", "")
                        End If
                    End If

                Catch ex As LbControlError.cError
                    ex.Mostrar()

                End Try

            Case "Vendedor"
                Try
                    Dim vlContinuar As Boolean = True
                    If Me.vcFolio.FOS(Me.grFolioSolicitado.GetValue("FOSId")).CambioFoliosTerminal Then 'si cambio el parametro de foliosTerminal
                        vlContinuar = validarCambioFoliosTerminal()
                    Else '
                        Me.validarVendedorEnSerie(grFolioSolicitado.GetValue("FosId"), grFolioSolicitado.GetValue("serie"), Me.grAsignacion.GetValue("VendedorId"), Me.grAsignacion.GetValue("FechaCreacion"))
                        If Me.vgModo = eModo.Modificar And grAsignacion.GetRow.RowType <> Janus.Windows.GridEX.RowType.NewRecord And Me.grAsignacion.GetValue("vendedor") <> "" _
                        And (Not vcFolio.FSH(grAsignacion.GetValue("FOSId"), grAsignacion.GetValue("FechaCreacion")) Is Nothing AndAlso vcFolio.FSH(grAsignacion.GetValue("FOSId"), grAsignacion.GetValue("FechaCreacion")).estado <> eEstado.Nuevo) Then
                            vlContinuar = validarCambioFoliosTerminal(Not vcFolio.FSHFolioTerminal, Me.grAsignacion.GetValue("vendedor"))
                        End If

                    End If

                    If vlContinuar And grAsignacion.RootTable.Columns("Vendedor").EditType <> Janus.Windows.GridEX.EditType.NoEdit Then
                        Dim vlSeleccion As ArrayList = recuperarVendedor("")
                        If Not vlSeleccion Is Nothing AndAlso vlSeleccion.Count > 0 Then
                            grAsignacion.SetValue("VendedorId", vlSeleccion(0).VendedorId)
                            grAsignacion.SetValue("Vendedor", vlSeleccion(0).Nombre)
                            grAsignacion.SetValue("Terminal", "")
                            grAsignacion.SetValue("Descripcion", "")
                        End If
                    End If

                Catch ex As LbControlError.cError
                    ex.Mostrar()
                End Try

            Case "Certificado"
                Dim frmBrowse As New ERMCEFESC.IGeneral
                frmBrowse.StartPosition = Windows.Forms.FormStartPosition.CenterParent
                Try
                    Dim vlFIni As String = "Convert(datetime,'" & Now.Year & "-" & Now.Month & "-" & Now.Day & "',102)"
                    Dim vlFFin As String = "Convert(datetime,'" & Now.Year & "-" & Now.Month & "-" & Now.Day & "',102)"

                    Dim Certificadofolio As ERMCEFLOG.cCertificadoFolio = CType(frmBrowse.Seleccionar(" NumCertificado in (select NumCertificado from CentroExpedicion C where C.SubEmpresaId='" + CType(Me.Parent.Parent.Parent, ERMFOLESC.MFoliosFiscales).cbSubempresa.SelectedValue + "' and CertificadoFolio.NumCertificado=C.NumCertificado ) and FechaInicial <= " & vlFIni & " AND FechaFinal >= " & vlFFin & "", False)(0), ERMCEFLOG.cCertificadoFolio)
                    If Certificadofolio.NumCertificado Is Nothing OrElse Certificadofolio.NumCertificado = "" Then
                        grAsignacion.GetRow.Cells("Certificado").Value = ""
                    Else
                        Try
                            'validaCampo(e.Column.Key, Certificadofolio.NumCertificado)
                            grAsignacion.SetValue("Certificado", Certificadofolio.NumCertificado)
                        Catch ex As LbControlError.cError
                            ex.Mostrar()
                        End Try
                    End If
                Catch ex As Exception

                End Try
        End Select
        RaiseEvent Habilitar("HuboCambios", True)
    End Sub

    'Private Sub grAsignacion_EditingCell(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.EditingCellEventArgs) Handles grAsignacion.EditingCell
    '    Select Case e.Column.Key
    '        'Case "Vendedor"
    '        '    Try
    '        '        Dim vlContinuar As Boolean = True
    '        '        If (vcFolio.FSH(grAsignacion.GetValue("FOSID"), grAsignacion.GetValue("FechaCreacion")) Is Nothing _
    '        '        OrElse vcFolio.FSH(grAsignacion.GetValue("FOSID"), grAsignacion.GetValue("FechaCreacion")).VendedorID = "") _
    '        '        And vcFolio.recuperarFSHArray(grAsignacion.GetValue("FOSId")).Count < 2 Then
    '        '            If Me.vcFolio.FOS(Me.grFolioSolicitado.GetValue("FOSId")).CambioFoliosTerminal Then 'si cambio el parametro de foliosTerminal
    '        '                validarCambioFoliosTerminal()
    '        '            Else 'Si no cambio foliosterminal
    '        '                Me.validarVendedorEnSerie(grFolioSolicitado.GetValue("FosID"), grFolioSolicitado.GetValue("serie"), Me.grAsignacion.GetValue("VendedorId"))
    '        '            End If
    '        '        End If
    '        '    Catch ex As LbControlError.cError
    '        '        ex.Mostrar()
    '        '    End Try

    '        'Case "Terminal"
    '        '    Try
    '        '        If (vcFolio.FSH(grAsignacion.GetValue("FOSID"), grAsignacion.GetValue("FechaCreacion")) Is Nothing _
    '        '        OrElse vcFolio.FSH(grAsignacion.GetValue("FOSID"), grAsignacion.GetValue("FechaCreacion")).TerminalClave = "") _
    '        '        And vcFolio.recuperarFSHArray(grAsignacion.GetValue("FOSId")).Count < 2 Then
    '        '            If Me.vcFolio.FOS(Me.grFolioSolicitado.GetValue("FOSId")).CambioFoliosTerminal Then 'si cambio el parametro de foliosTerminal
    '        '                validarCambioFoliosTerminal()
    '        '            Else
    '        '                Me.validarTerminalEnSerie(grFolioSolicitado.GetValue("FOSID"), grFolioSolicitado.GetValue("serie"), Me.grAsignacion.GetValue("Terminal"))
    '        '            End If
    '        '        End If
    '        '    Catch ex As LbControlError.cError
    '        '        ex.Mostrar()
    '        '    End Try

    '        'Case "CentroExp"
    '        'Dim lvlItemCol As New Janus.Windows.GridEX.GridEXValueListItemCollection
    '        'Dim dt As DataTable = vcFolio.FSHNumCertCentroExp(grAsignacion.GetRow.Cells("Certificado").Text)
    '        'If dt.Select("tipo=1").Length = 0 Then
    '        '    For i As Integer = 0 To dt.Rows.Count - 1
    '        '        Dim lvlItem As New Janus.Windows.GridEX.GridEXValueListItem(dt.Rows(i)("CentroExpID"), dt.Rows(i)("CentroExpID") + " " + dt.Rows(i)("Nombre"))
    '        '        lvlItemCol.Add(lvlItem)
    '        '    Next
    '        'Else
    '        '    For Each fila As DataRow In dt.Select("tipo=1")
    '        '        Dim lvlItem As New Janus.Windows.GridEX.GridEXValueListItem(fila("CentroExpID"), fila("CentroExpID") + " " + fila("Nombre"))
    '        '        lvlItemCol.Add(lvlItem)
    '        '    Next
    '        'End If
    '        'e.Column.EditValueList = lvlItemCol
    '        'e.Value = Me.grAsignacion.GetValue("CentroExpid")
    '        'grAsignacion.GetRow.Cells("CentroExp").Text = dt.Select("tipo=1")(0).Item("centroexpid") + " " + dt.Select("tipo=1")(0).Item("Nombre")
    '        'grAsignacion.GetRow.Cells("CentroExp").Value = dt.Select("tipo=1")(0).Item("centroexpid")
    '    End Select

    'End Sub

    'Dim valor As String
    'Private Sub grAsignacion_CellValueChanged(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles grAsignacion.CellValueChanged
    '    If e.Column Is Nothing Then Exit Sub
    '    If Me.grAsignacion.GetValue(e.Column) Is Nothing Then Exit Sub 'OrElse Me.grAsignacion.GetValue(e.Column).ToString = "" Then Exit Sub
    '    If Me.grAsignacion.GetValue(e.Column).ToString = valor Then Exit Sub

    '    Select Case e.Column.Key
    '        Case "Terminal"
    '            Try
    '                'If valor = Me.grAsignacion.GetValue("Terminal") Then Exit Sub
    '                Dim vlContinuar As Boolean = True
    '                If Me.vcFolio.FOS(Me.grFolioSolicitado.GetValue("FOSId")).CambioFoliosTerminal Then 'si cambio el parametro de foliosTerminal
    '                    vlContinuar = validarCambioFoliosTerminal()
    '                Else
    '                    Me.validarTerminalEnSerie(grFolioSolicitado.GetValue("FOSID"), grFolioSolicitado.GetValue("serie"), valor, Me.grAsignacion.GetValue("FechaCreacion"))
    '                End If
    '                valor = Me.grAsignacion.GetValue(e.Column)
    '            Catch ex As LbControlError.cError
    '                ex.Mostrar()
    '                If Me.vcFolio.FSHFolioTerminal Then
    '                    Me.grAsignacion.SetValue(e.Column, Me.vcFolio.FSH(Me.grAsignacion.GetValue("fosid"), grAsignacion.GetValue("FechaCreacion")).TerminalClave)
    '                Else
    '                    grAsignacion.SetValue(e.Column, vcFolio.FSHCampoDeSerie("TerminalClave", grFolioSolicitado.GetValue("Serie")))
    '                End If

    '            End Try
    '        Case "Vendedor"
    '            Dim vlContinuar As Boolean = True

    '            Try
    '                'If valor = Me.grAsignacion.GetValue("Vendedorid") Then Exit Sub
    '                If Me.vcFolio.FOS(Me.grFolioSolicitado.GetValue("FOSId")).CambioFoliosTerminal Then 'si cambio el parametro de foliosTerminal
    '                    vlContinuar = validarCambioFoliosTerminal()
    '                Else '
    '                    Me.validarVendedorEnSerie(grFolioSolicitado.GetValue("FosId"), grFolioSolicitado.GetValue("serie"), valor, Me.grAsignacion.GetValue("FechaCreacion"))
    '                End If
    '                valor = Me.grAsignacion.GetValue(e.Column)
    '            Catch ex As LbControlError.cError
    '                'Me.grAsignacion.SetValue(e.Column, valor)

    '                If Me.vcFolio.FSHFolioTerminal Then
    '                    'If Me.grAsignacion.GetValue("Terminal") = Me.vcFolio.FSH(Me.grAsignacion.GetValue("fosid"), grAsignacion.GetValue("FechaCreacion")).TerminalClave Then
    '                    '    Exit Sub
    '                    'End If
    '                    Me.grAsignacion.SetValue(e.Column, Me.vcFolio.FSH(Me.grAsignacion.GetValue("fosid"), grAsignacion.GetValue("FechaCreacion")).TerminalClave)
    '                Else
    '                    'If Me.grAsignacion.GetValue("Vendedor") = Me.vcFolio.FSH(Me.grAsignacion.GetValue("fosid"), grAsignacion.GetValue("FechaCreacion")).Vendedor Then
    '                    '    Exit Sub
    '                    'End If
    '                    Dim vlDataTable As DataTable
    '                    vlDataTable = vcFolio.FSHVendedor(" TipoEstado = 1 and vendedorid = '" & valor & "'")
    '                    grAsignacion.SetValue(e.Column, vlDataTable.Rows(0).Item("nombre"))

    '                    'Me.grAsignacion.SetValue(e.Column, valor)
    '                End If

    '                ex.Mostrar()
    '            End Try
    '    End Select
    'End Sub
#End Region

End Class
