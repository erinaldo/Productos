
Public Class MeSearch
    Inherits System.Windows.Forms.Form
    Implements ITeclado
    Private bLoad As Boolean = False
    Public MaskCte As Integer = 0
    Public Prefijo As String = ""
    Public Touch As Boolean = False
    Private sp, Campo, Tabla As String
    Public OcultaID As Boolean = False
    Public OcultaCol As Boolean = False
    Public OcultaColNum As Integer
    Public NumColDes As Integer = 1
    Public NumColDes2 As Integer = 2
    Public NumColDes3 As Integer = 3
    Public bReplace As Boolean = False
    Public TipoRequerido As Boolean = False
    Public AlmRequerido As Boolean = False
    Public VentaRequerido As Boolean = False
    Public ALMClave As String
    Public AREClave As String = ""
    Public VENClave As String
    Public Tipo As Integer
    Public BusquedaInicial As Boolean = False
    Public SUCClave As String = ""
    Public Busqueda As String
    Public ListaPrecio As String = ""
    Public valor As Object
    Public Descripcion, Descripcion2, Descripcion3 As String
    Public Columna As String
    Public TouchCK As Boolean = False
    Public foundRows() As DataRow
    Private spMarcas As Boolean = False
    Private bError As Boolean = False
    Private TallaColor As Integer = 0
    Friend WithEvents lblEtiqueta As System.Windows.Forms.Label
    Friend WithEvents Clock As System.Windows.Forms.Timer
    Friend WithEvents picKeyboard As System.Windows.Forms.PictureBox
    Public CompaniaRequerido As Boolean = False

    Public WriteOnly Property ProcedimientoAlmacenado() As String
        Set(ByVal Value As String)
            sp = Value
        End Set
    End Property

    Public WriteOnly Property TablaCmb() As String
        Set(ByVal Value As String)
            Tabla = Value
        End Set
    End Property

    Public WriteOnly Property CampoCmb() As String
        Set(ByVal Value As String)
            Campo = Value
        End Set
    End Property

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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtSearch As System.Windows.Forms.TextBox
    Friend WithEvents BtnOK As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnCancel As Janus.Windows.EditControls.UIButton
    Friend WithEvents CmbCampo As Selling.StoreCombo
    Friend WithEvents GridSearch As Janus.Windows.GridEX.GridEX
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MeSearch))
        Me.TxtSearch = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GridSearch = New Janus.Windows.GridEX.GridEX()
        Me.BtnCancel = New Janus.Windows.EditControls.UIButton()
        Me.BtnOK = New Janus.Windows.EditControls.UIButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.picKeyboard = New System.Windows.Forms.PictureBox()
        Me.lblEtiqueta = New System.Windows.Forms.Label()
        Me.Clock = New System.Windows.Forms.Timer(Me.components)
        Me.CmbCampo = New Selling.StoreCombo()
        Me.GroupBox1.SuspendLayout()
        CType(Me.GridSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.picKeyboard, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TxtSearch
        '
        Me.TxtSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSearch.Location = New System.Drawing.Point(225, 19)
        Me.TxtSearch.Name = "TxtSearch"
        Me.TxtSearch.Size = New System.Drawing.Size(493, 29)
        Me.TxtSearch.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.GridSearch)
        Me.GroupBox1.Controls.Add(Me.BtnCancel)
        Me.GroupBox1.Controls.Add(Me.BtnOK)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 60)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(782, 493)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'GridSearch
        '
        Me.GridSearch.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridSearch.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridSearch.ColumnAutoResize = True
        Me.GridSearch.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DisplayedCellsAndHeader
        Me.GridSearch.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridSearch.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridSearch.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown
        Me.GridSearch.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridSearch.GroupByBoxVisible = False
        Me.GridSearch.Location = New System.Drawing.Point(3, 9)
        Me.GridSearch.Name = "GridSearch"
        Me.GridSearch.RecordNavigator = True
        Me.GridSearch.Size = New System.Drawing.Size(775, 413)
        Me.GridSearch.TabIndex = 2
        Me.GridSearch.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnCancel
        '
        Me.BtnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Image = CType(resources.GetObject("BtnCancel.Image"), System.Drawing.Image)
        Me.BtnCancel.Location = New System.Drawing.Point(490, 428)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(135, 60)
        Me.BtnCancel.TabIndex = 4
        Me.BtnCancel.Text = "&Salir [Esc]"
        Me.BtnCancel.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancel.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnOK
        '
        Me.BtnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BtnOK.Image = CType(resources.GetObject("BtnOK.Image"), System.Drawing.Image)
        Me.BtnOK.Location = New System.Drawing.Point(643, 427)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(135, 60)
        Me.BtnOK.TabIndex = 3
        Me.BtnOK.Text = "Aceptar [ F9]"
        Me.BtnOK.ToolTipText = "Aceptar"
        Me.BtnOK.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.picKeyboard)
        Me.GroupBox2.Controls.Add(Me.CmbCampo)
        Me.GroupBox2.Controls.Add(Me.TxtSearch)
        Me.GroupBox2.Controls.Add(Me.lblEtiqueta)
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(782, 60)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Todos los que comiencen con:"
        '
        'picKeyboard
        '
        Me.picKeyboard.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picKeyboard.BackColor = System.Drawing.Color.Transparent
        Me.picKeyboard.Image = Global.Selling.My.Resources.Resources._1403657593_519640_141_Keyboard
        Me.picKeyboard.Location = New System.Drawing.Point(724, 10)
        Me.picKeyboard.Name = "picKeyboard"
        Me.picKeyboard.Size = New System.Drawing.Size(52, 43)
        Me.picKeyboard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picKeyboard.TabIndex = 14
        Me.picKeyboard.TabStop = False
        '
        'lblEtiqueta
        '
        Me.lblEtiqueta.AutoSize = True
        Me.lblEtiqueta.Location = New System.Drawing.Point(30, 18)
        Me.lblEtiqueta.Name = "lblEtiqueta"
        Me.lblEtiqueta.Size = New System.Drawing.Size(103, 13)
        Me.lblEtiqueta.TabIndex = 2
        Me.lblEtiqueta.Text = "Busqueda por Clave"
        '
        'Clock
        '
        Me.Clock.Interval = 500
        '
        'CmbCampo
        '
        Me.CmbCampo.BackColor = System.Drawing.SystemColors.Window
        Me.CmbCampo.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbCampo.Location = New System.Drawing.Point(3, 18)
        Me.CmbCampo.Name = "CmbCampo"
        Me.CmbCampo.Size = New System.Drawing.Size(216, 32)
        Me.CmbCampo.TabIndex = 1
        '
        'MeSearch
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MinimumSize = New System.Drawing.Size(180, 126)
        Me.Name = "MeSearch"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Busqueda"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.GridSearch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.picKeyboard, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub MeSearch_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If bError Then
            e.Cancel = True
        End If
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        bError = False
        Me.Close()
    End Sub

    Private Sub BtnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOK.Click
        If Not GridSearch.DataSource Is Nothing Then
            If Not GridSearch.GetValue(0) Is Nothing Then
                If spMarcas Then
                    Dim dt As New DataTable()
                    dt = TryCast(GridSearch.DataSource, DataTable)
                    foundRows = dt.Select("Marca = true")

                    If foundRows.Length = 0 Then
                        MessageBox.Show("Debe marcar los registros que desea agregar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                End If

                valor = GridSearch.GetValue(0)
                Descripcion = IIf(GridSearch.GetValue(NumColDes).GetType.Name = "DBNull", "", GridSearch.GetValue(NumColDes))

                If GridSearch.Tables(0).Columns.Count > NumColDes2 Then
                    Descripcion2 = IIf(GridSearch.GetValue(NumColDes2).GetType.Name = "DBNull", "", GridSearch.GetValue(NumColDes2))
                ElseIf GridSearch.Tables(0).Columns.Count = NumColDes2 Then
                    Descripcion2 = IIf(GridSearch.GetValue(NumColDes2 - 1).GetType.Name = "DBNull", "", GridSearch.GetValue(NumColDes2 - 1))
                End If

                If OcultaCol Then
                    Columna = GridSearch.GetValue(OcultaColNum)
                End If
                If GridSearch.Tables(0).Columns.Count > NumColDes3 Then
                    Descripcion3 = IIf(GridSearch.GetValue(NumColDes3).GetType.Name = "DBNull", "", GridSearch.GetValue(NumColDes3))
                ElseIf GridSearch.Tables(0).Columns.Count = NumColDes3 Then
                    Descripcion3 = IIf(GridSearch.GetValue(NumColDes3 - 1).GetType.Name = "DBNull", "", GridSearch.GetValue(NumColDes3 - 1))
                End If
            End If
            bError = False
            Me.Close()
        Else
            bError = True
            Beep()
            MessageBox.Show("¡No ha seleccionado algun registro!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub GridSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.BtnOK.PerformClick()
        End If
    End Sub

    Private Sub TxtSearch_Click(sender As Object, e As EventArgs) Handles TxtSearch.Click
        If Touch = True Then
            AbrirTeclado(Me)
        End If
    End Sub

    Private Sub TxtSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtSearch.KeyDown
        Clock.Stop()
    End Sub



    Private Sub MeSearch_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp, GridSearch.KeyUp
        Select Case e.KeyCode
            Case Is = Keys.Escape
                Me.BtnCancel.PerformClick()
            Case Is = Keys.F9
                Me.BtnOK.PerformClick()
        End Select
    End Sub

    Private Sub queryGrid(ByVal sp As String, ByVal campo As String, ByVal busqueda As String, Optional ByVal almacen As String = "", Optional ByVal tipo As Integer = 0, Optional ByVal COMClave As String = "", Optional ByVal precio As String = "")
        If busqueda.Trim <> "" Then

            Clock.Stop()

            If Tabla = "" Then
                campo = ""
            End If

            If sp = "st_search_tipo_usuario" Then
                ModPOS.ActualizaGrid(False, Me.GridSearch, sp, "@Campo", campo, "@Busqueda", busqueda, "@Tipo", tipo, "@SUCClave", SUCClave)

            ElseIf sp = "st_search_cliente" Then
                ModPOS.ActualizaGrid(False, Me.GridSearch, sp, "@Busqueda", busqueda, "@COMClave", COMClave)
                Me.GridSearch.RootTable.Columns("Clave").Width = 70
                Me.GridSearch.RootTable.Columns("Razón Social").Width = 360
                Me.GridSearch.RootTable.Columns("RFC").Width = 70
            ElseIf CompaniaRequerido Then
                COMClave = ModPOS.CompanyActual
                If TipoRequerido Then
                    If AlmRequerido Then
                        If precio = "" Then
                            ModPOS.ActualizaGrid(False, Me.GridSearch, sp, "@Campo", campo, "@Busqueda", busqueda, "@ALMClave", almacen, "@Tipo", tipo, "@COMClave", COMClave)
                        Else
                            ModPOS.ActualizaGrid(False, Me.GridSearch, sp, "@Campo", campo, "@Busqueda", busqueda, "@ALMClave", almacen, "@Precio", precio, "@Tipo", tipo, "@COMClave", COMClave)
                        End If
                    ElseIf VentaRequerido Then
                        ModPOS.ActualizaGrid(False, Me.GridSearch, sp, "@Campo", campo, "@Busqueda", busqueda, "@Venta", VENClave, "@Tipo", tipo, "@COMClave", COMClave)
                    Else
                        ModPOS.ActualizaGrid(False, Me.GridSearch, sp, "@Campo", campo, "@Busqueda", busqueda, "@Tipo", tipo, "@COMClave", COMClave)
                    End If
                Else
                    If AlmRequerido Then
                        If precio = "" Then
                            If bReplace = True Then
                                ModPOS.ActualizaGrid(False, Me.GridSearch, sp, "@Campo", campo, "@Busqueda", busqueda, "@ALMClave", almacen, "@COMClave", COMClave, "@Char", cReplace)
                            Else
                                ModPOS.ActualizaGrid(False, Me.GridSearch, sp, "@Campo", campo, "@Busqueda", busqueda, "@ALMClave", almacen, "@COMClave", COMClave)
                            End If
                        Else
                            ModPOS.ActualizaGrid(False, Me.GridSearch, sp, "@Campo", campo, "@Busqueda", busqueda, "@ALMClave", almacen, "@Precio", precio, "@COMClave", COMClave)
                        End If
                    ElseIf VentaRequerido Then
                        ModPOS.ActualizaGrid(False, Me.GridSearch, sp, "@Campo", campo, "@Busqueda", busqueda, "@Venta", VENClave, "@COMClave", COMClave)
                    Else
                        If bReplace = True Then
                            ModPOS.ActualizaGrid(False, Me.GridSearch, sp, "@Campo", campo, "@Busqueda", busqueda, "@COMClave", COMClave, "@Char", bReplace)
                        Else


                            If MaskCte = 1 AndAlso campo = "1" Then
                                If busqueda.Split("-").Length = 2 Then
                                    If IsNumeric(busqueda.Split("-")(0)) AndAlso IsNumeric(busqueda.Split("-")(1)) Then

                                        Dim sSucursal As String
                                        Dim sClaveCte As String

                                        sSucursal = String.Format("{0:000}", Val(CDbl(busqueda.Split("-")(0))))
                                        sClaveCte = String.Format("{0:0000000}", Val(CDbl(busqueda.Split("-")(1))))


                                        busqueda = sSucursal & "-" & sClaveCte
                                    End If
                                End If
                            End If


                            ModPOS.ActualizaGrid(False, Me.GridSearch, sp, "@Campo", campo, "@Busqueda", busqueda, "@COMClave", COMClave)
                        End If
                    End If
                End If
            Else
                If TipoRequerido Then
                    If AlmRequerido Then
                        If precio = "" Then
                            ModPOS.ActualizaGrid(False, Me.GridSearch, sp, "@Campo", campo, "@Busqueda", busqueda, "@ALMClave", almacen, "@Tipo", tipo)
                        Else
                            ModPOS.ActualizaGrid(False, Me.GridSearch, sp, "@Campo", campo, "@Busqueda", busqueda, "@ALMClave", almacen, "@Precio", precio, "@Tipo", tipo)
                        End If
                    ElseIf VentaRequerido Then
                        ModPOS.ActualizaGrid(False, Me.GridSearch, sp, "@Campo", campo, "@Busqueda", busqueda, "@Venta", VENClave, "@Tipo", tipo)
                    Else
                        ModPOS.ActualizaGrid(False, Me.GridSearch, sp, "@Campo", campo, "@Busqueda", busqueda, "@Tipo", tipo)
                    End If
                Else
                    If AlmRequerido Then
                        If precio = "" Then
                            If AREClave <> "" Then
                                ModPOS.ActualizaGrid(False, Me.GridSearch, sp, "@Campo", campo, "@Busqueda", busqueda, "@ALMClave", almacen, "@AREClave", AREClave)
                            Else
                                ModPOS.ActualizaGrid(False, Me.GridSearch, sp, "@Campo", campo, "@Busqueda", busqueda, "@ALMClave", almacen)
                            End If
                        Else
                            ModPOS.ActualizaGrid(False, Me.GridSearch, sp, "@Campo", campo, "@Busqueda", busqueda, "@ALMClave", almacen, "@Precio", precio)
                        End If
                    ElseIf VentaRequerido Then
                        If bReplace = True Then
                            ModPOS.ActualizaGrid(False, Me.GridSearch, sp, "@Campo", campo, "@Busqueda", busqueda, "@Venta", VENClave, "@Char", cReplace)
                        Else
                            ModPOS.ActualizaGrid(False, Me.GridSearch, sp, "@Campo", campo, "@Busqueda", busqueda, "@Venta", VENClave)
                        End If
                    Else
                        ModPOS.ActualizaGrid(False, Me.GridSearch, sp, "@Campo", campo, "@Busqueda", busqueda)
                    End If
                End If

            End If


            Select Case sp

                Case "sp_search_cliente"
                    Me.GridSearch.RootTable.Columns("Clave").Width = 70
                    Me.GridSearch.RootTable.Columns("Razón Social").Width = 360
                    Me.GridSearch.RootTable.Columns("RFC").Width = 70
                Case "sp_search_prod"
                    Me.GridSearch.RootTable.Columns("Clave").Width = 70
                    Me.GridSearch.RootTable.Columns("Num. de Parte").Width = 60
                    Me.GridSearch.RootTable.Columns("Nombre Comun").Width = 200
                    Me.GridSearch.RootTable.Columns("Descripción").Width = 100

                Case "st_search_prod_tc"
                    Me.GridSearch.RootTable.Columns("Clave").Width = 70
                    Me.GridSearch.RootTable.Columns("Num. de Parte").Width = 60
                    Me.GridSearch.RootTable.Columns("Nombre").Width = 100
                    Me.GridSearch.RootTable.Columns("Modelo").Width = 60
                    Me.GridSearch.RootTable.Columns("Color").Width = 150
                    Me.GridSearch.RootTable.Columns("Talla").Width = 50

                Case "st_search_producto_tc"
                    Me.GridSearch.RootTable.Columns("Clave").Width = 70
                    Me.GridSearch.RootTable.Columns("Num. de Parte").Width = 60
                    Me.GridSearch.RootTable.Columns("Nombre").Width = 100
                    Me.GridSearch.RootTable.Columns("Modelo").Width = 60
                    Me.GridSearch.RootTable.Columns("Color").Width = 150
                    Me.GridSearch.RootTable.Columns("Talla").Width = 50

                    Me.GridSearch.RootTable.Columns("Disponible").Width = 40
                    Me.GridSearch.RootTable.Columns("Disponible").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far


                Case "sp_search_producto"
                    Me.GridSearch.RootTable.Columns("Clave").Width = 70
                    Me.GridSearch.RootTable.Columns("Num. de Parte").Width = 60
                    Me.GridSearch.RootTable.Columns("Nombre Comun").Width = 200
                    Me.GridSearch.RootTable.Columns("Descripción").Width = 100

                    Me.GridSearch.RootTable.Columns("Disponible").Width = 40
                    Me.GridSearch.RootTable.Columns("Disponible").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
                Case "sp_search_producto_vta"
                    Me.GridSearch.RootTable.Columns("Clave").Width = 70
                    Me.GridSearch.RootTable.Columns("Descripción").Width = 250
                    Me.GridSearch.RootTable.Columns("Disponible").Width = 40
                    Me.GridSearch.RootTable.Columns("Disponible").TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
                    '                Me.GridSearch.RootTable.Columns("Ultima Venta").Width = 40
                Case "sp_recupera_docto_recibo"
                    Me.GridSearch.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True
                    Me.GridSearch.RootTable.Columns("Tipo").EditType = Janus.Windows.GridEX.EditType.NoEdit
                    Me.GridSearch.RootTable.Columns("Fecha").EditType = Janus.Windows.GridEX.EditType.NoEdit
                    Me.GridSearch.RootTable.Columns("Total").EditType = Janus.Windows.GridEX.EditType.NoEdit
                    Me.GridSearch.RootTable.Columns("Clave").EditType = Janus.Windows.GridEX.EditType.NoEdit
                    Me.GridSearch.RootTable.Columns("Emisor").EditType = Janus.Windows.GridEX.EditType.NoEdit
                    Me.GridSearch.RootTable.Columns("Nota").EditType = Janus.Windows.GridEX.EditType.NoEdit
                    Me.GridSearch.RootTable.Columns("Folio").EditType = Janus.Windows.GridEX.EditType.NoEdit
                    If TallaColor = 1 Then
                        Me.GridSearch.RootTable.Columns("FolioEntrega").EditType = Janus.Windows.GridEX.EditType.NoEdit
                    End If
                    spMarcas = True
            End Select




            If OcultaID Then
                Me.GridSearch.RootTable.Columns("ID").Visible = False
            ElseIf OcultaCol Then
                Me.GridSearch.RootTable.Columns(OcultaColNum).Visible = False
            End If
        End If

    End Sub

    Private Sub MeSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Me.StartPosition = FormStartPosition.CenterScreen
        If TouchCK Then
            Me.GridSearch.Font = New Font("Arial", 20)
            'Me.WindowState = FormWindowState.Maximized
        End If

        If Tabla = "" Then
            Me.CmbCampo.Visible = False
            lblEtiqueta.Text = "Busqueda por Clave"
        Else
            With Me.CmbCampo
                .Conexion = ModPOS.BDConexion
                .ProcedimientoAlmacenado = "sp_filtra_valorref"
                .NombreParametro1 = "tabla"
                .Parametro1 = Tabla
                .NombreParametro2 = "campo"
                .Parametro2 = Campo
                .llenar()
            End With
        End If

        Dim dt As DataTable

        Dim i As Integer

        dt = ModPOS.Recupera_Tabla("sp_recupera_parametro", "@COMClave", ModPOS.CompanyActual)
        With Me
            For i = 0 To dt.Rows.Count - 1
                Select Case CStr(dt.Rows(i)("PARClave"))
                    Case "TallaColor"
                        TallaColor = IIf(dt.Rows(i)("Valor").GetType.Name = "DBNull", 0, dt.Rows(i)("Valor"))
                        Exit For
                End Select
            Next
        End With
        dt.Dispose()


        If BusquedaInicial Then
            TxtSearch.Text = Busqueda
            TxtSearch.Focus()
            queryGrid(sp, CmbCampo.SelectedValue, TxtSearch.Text, ALMClave, Tipo, ModPOS.CompanyActual, ListaPrecio)
        End If

      


        If MaskCte = 1 AndAlso TxtSearch.Text = "" Then
            If Not CmbCampo.SelectedValue Is Nothing Then
                If CmbCampo.SelectedValue = 1 Then
                    TxtSearch.Text = Prefijo & "-"
                End If
            End If
        End If

        bLoad = True

        If Touch = True Then
            TxtSearch.Width = 559
            TxtSearch.Location = New Point(3, 14)
            CmbCampo.Visible = False
            Me.Show()
            AbrirTeclado(Me)

        End If
    End Sub

    Private Sub TxtSearch_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtSearch.KeyUp
        Select Case e.KeyCode
            Case Is = Keys.Escape
                Clock.Stop()
                Me.BtnCancel.PerformClick()
            Case Is = Keys.F9
                Clock.Stop()
                Me.BtnOK.PerformClick()
            Case Else
                Clock.Start()

        End Select

    End Sub

    Private Sub GridSearch_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridSearch.DoubleClick
        If Not GridSearch.GetValue(0) Is Nothing Then
            If Not ModPOS.Teclado Is Nothing Then
                ModPOS.Teclado.Close()
            End If
            valor = GridSearch.GetValue(0)
            Descripcion = IIf(GridSearch.GetValue(NumColDes).GetType.Name = "DBNull", "", GridSearch.GetValue(NumColDes))

            If GridSearch.Tables(0).Columns.Count > NumColDes2 Then
                Descripcion2 = IIf(GridSearch.GetValue(NumColDes2).GetType.Name = "DBNull", "", GridSearch.GetValue(NumColDes2))
            ElseIf GridSearch.Tables(0).Columns.Count = NumColDes2 Then
                Descripcion2 = IIf(GridSearch.GetValue(NumColDes2 - 1).GetType.Name = "DBNull", "", GridSearch.GetValue(NumColDes2 - 1))
            End If

            If OcultaCol Then
                Columna = GridSearch.GetValue(OcultaColNum)
            End If
            If GridSearch.Tables(0).Columns.Count > NumColDes3 Then
                Descripcion3 = IIf(GridSearch.GetValue(NumColDes3).GetType.Name = "DBNull", "", GridSearch.GetValue(NumColDes3))
            ElseIf GridSearch.Tables(0).Columns.Count = NumColDes3 Then
                Descripcion3 = IIf(GridSearch.GetValue(NumColDes3 - 1).GetType.Name = "DBNull", "", GridSearch.GetValue(NumColDes3 - 1))
            End If

            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub GridSearch_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridSearch.SelectionChanged
        If Not GridSearch Is Nothing Then
            If Not GridSearch.GetValue(0) Is Nothing Then
                Me.BtnOK.Enabled = True
            Else
                Me.BtnOK.Enabled = False
            End If
        End If
    End Sub

    Private Sub Clock_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Clock.Tick
        If Not (CmbCampo.SelectedValue Is Nothing OrElse Tabla = "") Then
            If Touch = True Then
                If TxtSearch.Text.Length >= 4 OrElse TxtSearch.Text = "%" Then
                    queryGrid(sp, CmbCampo.SelectedValue, TxtSearch.Text.ToUpper.Trim.Replace("'", "''"), ALMClave, Tipo, ModPOS.CompanyActual, ListaPrecio)
                End If
            Else
                queryGrid(sp, CmbCampo.SelectedValue, TxtSearch.Text.ToUpper.Trim.Replace("'", "''"), ALMClave, Tipo, ModPOS.CompanyActual, ListaPrecio)
            End If
        Else
            Clock.Stop()
            Beep()
            MessageBox.Show("¡No esta el filtro seleccionado!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
        Clock.Stop()
    End Sub

    Private Sub picKeyboard_Click(sender As Object, e As EventArgs) Handles picKeyboard.Click
        AbrirTeclado(Me)
    End Sub


    Private Sub Concatenar(dato As String) Implements ITeclado.Concatenar
        If dato = "DESHACER" OrElse dato = "" Then
            If TxtSearch.TextLength > 0 Then
                TxtSearch.Text = TxtSearch.Text.Remove(TxtSearch.TextLength - 1, 1)
            End If
        Else
            TxtSearch.Text &= dato
            Clock.Start()
        End If

    End Sub

    Private Sub CmbCampo_SelectedValueChanged(sender As Object, e As EventArgs) Handles CmbCampo.SelectedValueChanged
        If bLoad = True AndAlso MaskCte = 1 AndAlso (TxtSearch.Text = "" Or TxtSearch.Text = Prefijo + "-") Then
            If Not CmbCampo.SelectedValue Is Nothing Then
                If CmbCampo.SelectedValue = 1 Then
                    TxtSearch.Text = Prefijo & "-"
                Else
                    TxtSearch.Text = ""
                End If
            End If
        End If
    End Sub
End Class
