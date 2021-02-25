<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class FormSurtirPromocion
    Inherits System.Windows.Forms.Form

    Public Sub New(ByVal paroModuloMovDetActual As Modulos.GrupoModuloMovDetalle, ByVal paroCliente As Cliente, ByVal parsVisitaClave As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        oCliente = paroCliente
        sVisitaClave = parsVisitaClave
        oMMDA = paroModuloMovDetActual
    End Sub

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If Not IsNothing(MenuItemRegresar) Then
            If ListViewPromocion.Columns.Count > 0 Then
                If oVendedor.motconfiguracion.Secuencia Then
                    RemoveHandler ctrlSeguimiento.NuevaSeleccion, AddressOf TerminarVisita
                    RemoveHandler ctrlSeguimiento.TerminarVisitaMenu, AddressOf TerminarVisita
                    ctrlSeguimiento.QuitarMenuItem(Me.MainMenuPromo)
                    Me.Controls.Remove(ctrlSeguimiento)
                Else
                    For Each ctrl As Control In Me.Controls
                        If ctrl.Name = "lbNombreActividad" Then
                            Me.Controls.Remove(ctrl)
                            ctrl.Dispose()
                            ctrl = Nothing
                            Exit For
                        End If
                    Next

                End If
            End If
        End If

        If Not IsNothing(MenuItemRegresar) Then MenuItemRegresar.Dispose()
        If Not IsNothing(MainMenuPromo) Then MainMenuPromo.Dispose()

        If Not IsNothing(ListViewPromocion) Then
            If ListViewPromocion.Columns.Count > 0 Then ListViewPromocion.Columns.Clear()
            ListViewPromocion.Dispose()
        End If

        If Not IsNothing(Me.ButtonCancelar) Then ButtonCancelar.Dispose()
        If Not IsNothing(Me.ButtonContinuar) Then ButtonContinuar.Dispose()
        If Not IsNothing(Me.ButtonRegresar) Then ButtonRegresar.Dispose()

        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Private MainMenuPromo As System.Windows.Forms.MainMenu

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.MainMenuPromo = New System.Windows.Forms.MainMenu
        Me.MenuItemRegresar = New System.Windows.Forms.MenuItem
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.ButtonCancelar = New System.Windows.Forms.Button
        Me.ButtonRegresar = New System.Windows.Forms.Button
        Me.ButtonContinuar = New System.Windows.Forms.Button
        Me.ListViewPromocion = New System.Windows.Forms.ListView
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainMenuPromo
        '
        Me.MainMenuPromo.MenuItems.Add(Me.MenuItemRegresar)
        '
        'MenuItemRegresar
        '
        Me.MenuItemRegresar.Text = "MenuItemRegresar"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ButtonCancelar)
        Me.Panel1.Controls.Add(Me.ButtonRegresar)
        Me.Panel1.Controls.Add(Me.ButtonContinuar)
        Me.Panel1.Controls.Add(Me.ListViewPromocion)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(242, 295)
        '
        'ButtonCancelar
        '
        Me.ButtonCancelar.Location = New System.Drawing.Point(163, 262)
        Me.ButtonCancelar.Name = "ButtonCancelar"
        Me.ButtonCancelar.Size = New System.Drawing.Size(72, 24)
        Me.ButtonCancelar.TabIndex = 6
        Me.ButtonCancelar.Text = "ButtonCancelar"
        '
        'ButtonRegresar
        '
        Me.ButtonRegresar.Location = New System.Drawing.Point(85, 262)
        Me.ButtonRegresar.Name = "ButtonRegresar"
        Me.ButtonRegresar.Size = New System.Drawing.Size(72, 24)
        Me.ButtonRegresar.TabIndex = 3
        Me.ButtonRegresar.Text = "ButtonRegresar"
        '
        'ButtonContinuar
        '
        Me.ButtonContinuar.Location = New System.Drawing.Point(5, 262)
        Me.ButtonContinuar.Name = "ButtonContinuar"
        Me.ButtonContinuar.Size = New System.Drawing.Size(72, 24)
        Me.ButtonContinuar.TabIndex = 4
        Me.ButtonContinuar.Text = "ButtonContinuar"
        '
        'ListViewPromocion
        '
        Me.ListViewPromocion.CheckBoxes = True
        Me.ListViewPromocion.FullRowSelect = True
        Me.ListViewPromocion.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListViewPromocion.Location = New System.Drawing.Point(5, 16)
        Me.ListViewPromocion.Name = "ListViewPromocion"
        Me.ListViewPromocion.Size = New System.Drawing.Size(228, 244)
        Me.ListViewPromocion.TabIndex = 5
        Me.ListViewPromocion.View = System.Windows.Forms.View.Details
        '
        'FormSurtirPromocion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(242, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Menu = Me.MainMenuPromo
        Me.Name = "FormSurtirPromocion"
        Me.Text = "FormSurtirPromocion"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ButtonRegresar As System.Windows.Forms.Button
    Friend WithEvents ButtonContinuar As System.Windows.Forms.Button
    Friend WithEvents ListViewPromocion As System.Windows.Forms.ListView
    Friend WithEvents MenuItemRegresar As System.Windows.Forms.MenuItem
    Friend WithEvents ButtonCancelar As System.Windows.Forms.Button
End Class
