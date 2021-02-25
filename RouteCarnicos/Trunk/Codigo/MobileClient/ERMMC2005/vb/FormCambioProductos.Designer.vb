<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class FormCambioProductos
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If Not Me.MenuItemEliminarEnt Is Nothing Then Me.MenuItemEliminarEnt.Dispose()
        If Not Me.MenuItemEliminarSal Is Nothing Then Me.MenuItemEliminarSal.Dispose()
        If Not Me.MenuItemModificarEnt Is Nothing Then Me.MenuItemModificarEnt.Dispose()
        If Not Me.MenuItemModificarSal Is Nothing Then Me.MenuItemModificarSal.Dispose()
        If Not Me.MenuItemRegresar Is Nothing Then Me.MenuItemRegresar.Dispose()
        If Not Me.MainMenuPagos Is Nothing Then Me.MainMenuPagos.Dispose()
        If Not Me.fgProdEntrada Is Nothing Then
            Me.fgProdEntrada.ContextMenu = Nothing
            Me.fgProdEntrada.Dispose()
            Me.fgProdEntrada = Nothing
        End If
        If Not Me.fgProdSalida Is Nothing Then
            Me.fgProdSalida.ContextMenu = Nothing
            Me.fgProdSalida.Dispose()
            Me.fgProdSalida = Nothing
        End If
        If Not Me.ContextMenuModificarEnt Is Nothing Then
            Me.ContextMenuModificarEnt.Dispose()
            Me.ContextMenuModificarEnt = Nothing
        End If
        If Not Me.ContextMenuModificarSal Is Nothing Then
            Me.ContextMenuModificarSal.Dispose()
            Me.ContextMenuModificarSal = Nothing
        End If
        Me.refaVista = Nothing
        Me.oCliente = Nothing
        Me.oTransProdEntrada = Nothing
        Me.oTransProdSalida = Nothing
        Me.oImpuesto = Nothing
        Me.oProducto = Nothing
        Me.oModulo = Nothing
        Me.oModuloMovDetalle = Nothing
#If MOD_TERM <> "PALM" Then
        If Not bScanner Is Nothing Then bScanner.Dispose()
        bScanner = Nothing
#End If
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Friend WithEvents ContextMenuModificarSal As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItemModificarSal As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItemEliminarSal As System.Windows.Forms.MenuItem
    Friend WithEvents MainMenuPagos As System.Windows.Forms.MainMenu
    Friend WithEvents MenuItemRegresar As System.Windows.Forms.MenuItem
    Friend WithEvents ContextMenuModificarEnt As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItemModificarEnt As System.Windows.Forms.MenuItem
    Friend WithEvents PanelDetalle As System.Windows.Forms.Panel
    Friend WithEvents TabControlCambios As System.Windows.Forms.TabControl
    Friend WithEvents TabPageProducto As System.Windows.Forms.TabPage
    Friend WithEvents TextBoxCodigoEntrada As System.Windows.Forms.TextBox
    Friend WithEvents LabelCodigoEntrada As System.Windows.Forms.Label
    Friend WithEvents fgProdEntrada As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents ComboBoxMotivo As System.Windows.Forms.ComboBox
    Friend WithEvents LabelMotivo As System.Windows.Forms.Label
    Friend WithEvents ButtonBuscarProdEntrada As System.Windows.Forms.Button
    Friend WithEvents TextBoxProdEntrada As System.Windows.Forms.TextBox
    Friend WithEvents LabelProdEntrada As System.Windows.Forms.Label
    Friend WithEvents TextBoxFecha As System.Windows.Forms.TextBox
    Friend WithEvents LabelFecha As System.Windows.Forms.Label
    Friend WithEvents LabelFolio As System.Windows.Forms.Label
    Friend WithEvents TextBoxFolio As System.Windows.Forms.TextBox
    Friend WithEvents TabPageCambiarPor As System.Windows.Forms.TabPage
    Friend WithEvents TextBoxCodigoSalida As System.Windows.Forms.TextBox
    Friend WithEvents LabelCodigoSalida As System.Windows.Forms.Label
    Friend WithEvents fgProdSalida As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents ButtonBuscarProdSalida As System.Windows.Forms.Button
    Friend WithEvents TextBoxProdSalida As System.Windows.Forms.TextBox
    Friend WithEvents LabelProdSalida As System.Windows.Forms.Label
    Friend WithEvents ButtonContinuarDet As System.Windows.Forms.Button
    Friend WithEvents ButtonRegresarDet As System.Windows.Forms.Button
    Friend WithEvents PanelLista As System.Windows.Forms.Panel
    Friend WithEvents ButtonEliminar As System.Windows.Forms.Button
    Friend WithEvents ListViewCambios As System.Windows.Forms.ListView
    Friend WithEvents ButtonContinuarLista As System.Windows.Forms.Button
    Friend WithEvents ButtonRegresarLista As System.Windows.Forms.Button
    Friend WithEvents MenuItemEliminarEnt As System.Windows.Forms.MenuItem
    Friend WithEvents TextBoxTotalP As System.Windows.Forms.TextBox
    Friend WithEvents LabelTotalProducto As System.Windows.Forms.Label
    Friend WithEvents TextBoxTotalC As System.Windows.Forms.TextBox
    Friend WithEvents LabelTotalCambio As System.Windows.Forms.Label
    Friend WithEvents ContextMenuRelEnt As System.Windows.Forms.ContextMenu
    Friend WithEvents ContextMenuRelSal As System.Windows.Forms.ContextMenu
    Friend WithEvents lbNombreActividad As System.Windows.Forms.Label

End Class
