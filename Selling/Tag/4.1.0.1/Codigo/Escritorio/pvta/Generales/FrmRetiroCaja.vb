Public Class FrmRetiroCaja
    Inherits System.Windows.Forms.Form

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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BtnOk As Janus.Windows.EditControls.UIButton
    Friend WithEvents LBTitulo As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents LbFecha As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents lblOtros As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GridOtros As Janus.Windows.GridEX.GridEX
    Friend WithEvents lblEfectivo As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtMotivo As System.Windows.Forms.TextBox
    Friend WithEvents CmbTipo As Selling.StoreCombo
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GridCaja As Janus.Windows.GridEX.GridEX
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRetiroCaja))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BtnOk = New Janus.Windows.EditControls.UIButton()
        Me.LBTitulo = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GridCaja = New Janus.Windows.GridEX.GridEX()
        Me.LbFecha = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.lblOtros = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GridOtros = New Janus.Windows.GridEX.GridEX()
        Me.lblEfectivo = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtMotivo = New System.Windows.Forms.TextBox()
        Me.CmbTipo = New Selling.StoreCombo()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.GridCaja, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.GridOtros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SteelBlue
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Name = "Label1"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SteelBlue
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Name = "Label2"
        '
        'BtnOk
        '
        Me.BtnOk.BackColor = System.Drawing.SystemColors.Control
        Me.BtnOk.Image = CType(resources.GetObject("BtnOk.Image"), System.Drawing.Image)
        resources.ApplyResources(Me.BtnOk, "BtnOk")
        Me.BtnOk.Name = "BtnOk"
        '
        'LBTitulo
        '
        Me.LBTitulo.BackColor = System.Drawing.Color.SteelBlue
        resources.ApplyResources(Me.LBTitulo, "LBTitulo")
        Me.LBTitulo.ForeColor = System.Drawing.Color.White
        Me.LBTitulo.Name = "LBTitulo"
        '
        'GroupBox1
        '
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.GridCaja)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = False
        '
        'GridCaja
        '
        resources.ApplyResources(Me.GridCaja, "GridCaja")
        Me.GridCaja.ColumnAutoResize = True
        Me.GridCaja.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridCaja.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridCaja.Name = "GridCaja"
        Me.GridCaja.RecordNavigator = True
        Me.GridCaja.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'LbFecha
        '
        Me.LbFecha.BackColor = System.Drawing.Color.SteelBlue
        resources.ApplyResources(Me.LbFecha, "LbFecha")
        Me.LbFecha.ForeColor = System.Drawing.Color.White
        Me.LbFecha.Name = "LbFecha"
        '
        'lblTotal
        '
        resources.ApplyResources(Me.lblTotal, "lblTotal")
        Me.lblTotal.Name = "lblTotal"
        '
        'lblOtros
        '
        resources.ApplyResources(Me.lblOtros, "lblOtros")
        Me.lblOtros.Name = "lblOtros"
        '
        'GroupBox2
        '
        resources.ApplyResources(Me.GroupBox2, "GroupBox2")
        Me.GroupBox2.BackColor = System.Drawing.Color.White
        Me.GroupBox2.Controls.Add(Me.GridOtros)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.TabStop = False
        '
        'GridOtros
        '
        resources.ApplyResources(Me.GridOtros, "GridOtros")
        Me.GridOtros.ColumnAutoResize = True
        Me.GridOtros.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridOtros.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridOtros.Name = "GridOtros"
        Me.GridOtros.RecordNavigator = True
        Me.GridOtros.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lblEfectivo
        '
        resources.ApplyResources(Me.lblEfectivo, "lblEfectivo")
        Me.lblEfectivo.Name = "lblEfectivo"
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'TxtMotivo
        '
        resources.ApplyResources(Me.TxtMotivo, "TxtMotivo")
        Me.TxtMotivo.Name = "TxtMotivo"
        '
        'CmbTipo
        '
        resources.ApplyResources(Me.CmbTipo, "CmbTipo")
        Me.CmbTipo.Name = "CmbTipo"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'FrmRetiroCaja
        '
        resources.ApplyResources(Me, "$this")
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CmbTipo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtMotivo)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.lblOtros)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.lblEfectivo)
        Me.Controls.Add(Me.LbFecha)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.LBTitulo)
        Me.Controls.Add(Me.BtnOk)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmRetiroCaja"
        Me.ShowInTaskbar = False
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.GridCaja, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.GridOtros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Public SUCClave As String
    Public ALMClave As String
    Public CAJClave As String
    Public MontoEfectivo As Double = 0
    Public MontoCheques As Double = 0
    Public MontoVales As Double = 0
    Public retiroEfectivo As Double = 0
    Public retiroCheques As Double = 0
    Public retiroVales As Double = 0
    Public Cajon As Boolean = False
    Public Impresora As String
    Public Generic As Boolean
    Public Ticket As String

    Private Cajero As String
    Private Autorizo As String
    Private Motivo As String
    Private Total, Efectivo, Otros As Double
    Private dtMonto, dtOtros As DataTable
    Private bError As Boolean = False
    Private Tipo As Integer

    Private Function imprimeTicketRetiro(ByVal dt As DataTable, ByVal Efectivo As Double, ByVal Impresora As String, ByVal Generic As Boolean, ByVal Ticket As String) As Boolean
        Dim dTotal As Double

        Dim Tickets As Imprimir = New Imprimir 'PrintTicket.Ticket()
        Tickets.Generic = Generic
        Dim dtTicket As DataTable
        dtTicket = ModPOS.SiExisteRecupera("sp_recupera_ticket", "@TIKClave", Ticket)

        If Not dtTicket Is Nothing Then
            Tickets.MaxCharLine = dtTicket.Rows(0)("MaxChar")
            Tickets.LetraSize = dtTicket.Rows(0)("FontSize")
            Tickets.LetraName = dtTicket.Rows(0)("FontName")
            dtTicket.Dispose()
        End If

        'Encabezado
        Tickets.AddHeaderLine("RETIRO DE CAJA", Imprimir.FontEstilo.Negrita, Imprimir.Alinear.Centrado)

        'El metodo AddSubHeaderLine es lo mismo al de AddHeaderLine con la diferencia 
        'de que al final de cada linea agrega una linea punteada "==========" 
        Tickets.AddHeaderLine("CAJERO: " & Cajero, 0, Imprimir.Alinear.Izquierda)
        Tickets.AddHeaderLine("AUTORIZO: " & Autorizo, 0, Imprimir.Alinear.Izquierda)
        Tickets.AddHeaderLine("MOTIVO: " & Motivo, 0, Imprimir.Alinear.Izquierda)
        Tickets.AddSubHeaderLine(DateTime.Now.ToShortDateString() & " " & DateTime.Now.ToShortTimeString(), 0, 3)

        'El metodo AddItem requeire 3 parametros, el primero es cantidad, el segundo es la descripcion 
        'del producto y el tercero es el precio 

        If Efectivo > 0 Then
            Tickets.AddItemRecibo("Efectivo", "", Efectivo)
            dTotal += Efectivo
        End If

        Dim fila As Integer
        Dim foundRows() As DataRow
        foundRows = dt.Select("Monto > 0")
        If foundRows.GetLength(0) > 0 Then
            For fila = 0 To foundRows.GetUpperBound(0)
                ' AGREGAR RETIROS A LISTA
                Dim sConcepto As String = CStr(foundRows(fila)(1))
                Dim sEspacio As String = ""
                Dim dImporte As Double = CDbl(foundRows(fila)(2))
                Tickets.AddItemRecibo(sConcepto, sEspacio, dImporte)
                dTotal += (dImporte)
            Next
            dt.Dispose()
        End If

        Tickets.AddTotalTicket(dTotal, Imprimir.FontEstilo.Negrita)
        Tickets.PrintTicket(Impresora, 70, 0)

    End Function

    Private Sub FrmRetiroCaja_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If bError Then
            e.Cancel = True
        End If
    End Sub

    Private Sub FrmRetiroCaja_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LbFecha.Text = DateTime.Today.ToLongDateString

        With Me.CmbTipo
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "Tabla"
            .Parametro1 = "RetiroCaja"
            .NombreParametro2 = "Campo"
            .Parametro2 = "Tipo"
            .llenar()
        End With

        Dim dtUsuario As DataTable = ModPOS.SiExisteRecupera("sp_recupera_UsuarioActual", "@Usuario", ModPOS.UsuarioActual)

        If Not dtUsuario Is Nothing Then
            Cajero = dtUsuario.Rows(0)("Nombre")
        End If

        dtMonto = ModPOS.Recupera_Tabla("sp_recupera_monto")

        GridCaja.DataSource = dtMonto
        GridCaja.RetrieveStructure(True)
        GridCaja.GroupByBoxVisible = False
        GridCaja.RootTable.Columns(0).Visible = False
        GridCaja.CurrentTable.Columns(1).Selectable = False
        GridCaja.CurrentTable.Columns(3).Selectable = False


        dtOtros = ModPOS.Recupera_Tabla("sp_recupera_montos_doctos")
        GridOtros.DataSource = dtOtros
        GridOtros.RetrieveStructure(True)
        GridOtros.GroupByBoxVisible = False
        GridOtros.RootTable.Columns(0).Visible = False
        GridOtros.CurrentTable.Columns(1).Selectable = False

    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        
        If TxtMotivo.Text = "" Then
            MessageBox.Show("Debe especificar un motivo para el retiro", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            bError = True
            Exit Sub
        Else
            Motivo = TxtMotivo.Text.ToUpper.Trim
        End If

        If CmbTipo.SelectedValue Is Nothing Then
            Tipo = 1
        Else
            Tipo = CmbTipo.SelectedValue
        End If

        'Verifica Efectivo < Total Abonos efectivo
        If Efectivo > (MontoEfectivo - retiroEfectivo) Then
            bError = True
            MessageBox.Show("No hay efectivo suficiente para realizar el retiro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            bError = False
        End If

        Dim fila As Integer

        If bError = False Then
            For fila = 0 To dtOtros.Rows.Count - 1
                Select Case CInt(dtOtros.Rows(fila)(0))
                    Case Is = 2
                        If dtOtros.Rows(fila)(2) > (MontoCheques - retiroCheques) Then
                            bError = True
                            MessageBox.Show("No hay cheques suficiente para realizar el retiro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit For
                        Else
                            bError = False
                        End If
                    Case Is = 4
                        If dtOtros.Rows(fila)(2) > (MontoVales - retiroVales) Then
                            bError = True
                            MessageBox.Show("No hay vales suficiente para realizar el retiro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit For
                        Else
                            bError = False
                        End If

                End Select
            Next
        End If

        Dim UsuarioAutoriza As String = ""

        If bError = False And Total > 0 Then
            Dim a As New MeAutorizacion
            a.Sucursal = SUCClave
            a.MontodeAutorizacion = Total
            a.StartPosition = FormStartPosition.CenterScreen
            a.ShowDialog()
            If a.DialogResult = DialogResult.OK Then
                If a.Autorizado Then
                    UsuarioAutoriza = a.Autoriza
                Else
                    bError = True
                    MessageBox.Show("El retiro no ha sido autorizado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                bError = True
                MessageBox.Show("El retiro no ha sido autorizado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            bError = True
            MessageBox.Show("El retiro no ha sido autorizado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        'Guarda Registro de Retiro
        If bError = False And Total > 0 Then
            If Efectivo > 0 Then
                ModPOS.Ejecuta("sp_inserta_retiro", _
                  "@CAJClave", CAJClave, _
                  "@Usuario", UsuarioAutoriza, _
                  "@Importe", Efectivo, _
                  "@Motivo", Motivo, _
                  "@Tipo", 1, _
                  "@TipoMotivo", Tipo)
            End If

            Dim foundRows() As DataRow
            foundRows = dtOtros.Select("Monto > 0")
            If foundRows.GetLength(0) > 0 Then
                For fila = 0 To foundRows.GetUpperBound(0)
                    Select Case CInt(dtOtros.Rows(fila)(0))
                        Case Is = 2
                            If CDbl(dtOtros.Rows(fila)(2)) > 0 Then
                                ModPOS.Ejecuta("sp_inserta_retiro", _
                                                 "@CAJClave", CAJClave, _
                                                 "@Usuario", UsuarioAutoriza, _
                                                 "@Importe", CDbl(foundRows(fila)(2)), _
                                                 "@Motivo", Motivo, _
                                                 "@Tipo", 2, _
                                                 "@TipoMotivo", Tipo)

                            End If
                        Case Is = 4
                            If CDbl(dtOtros.Rows(fila)(2)) > 0 Then
                                ModPOS.Ejecuta("sp_inserta_retiro", _
                                                 "@CAJClave", CAJClave, _
                                                 "@Usuario", UsuarioAutoriza, _
                                                 "@Importe", CDbl(foundRows(fila)(2)), _
                                                 "@Motivo", Motivo, _
                                                 "@Tipo", 4, _
                                                 "@TipoMotivo", Tipo)
                            End If
                    End Select
                Next
            End If

            Dim dtUsuario As DataTable = ModPOS.SiExisteRecupera("sp_recupera_UsuarioActual", "@Usuario", UsuarioAutoriza)
            If Not dtUsuario Is Nothing Then
                Autorizo = dtUsuario.Rows(0)("Nombre")
            End If

            If Cajon = True Then
                AbrirCajon(Impresora)
            End If

            Select Case MessageBox.Show("¿Desea Imprimir Recibo de Retiro de Caja", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                Case DialogResult.Yes
                    imprimeTicketRetiro(dtOtros, Efectivo, Impresora, Generic, Ticket)
            End Select

        End If
        Me.Close()
    End Sub


    Private Sub GridCaja_CellEdited(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridCaja.CellEdited
        If GridCaja.CurrentColumn.Caption = "Cantidad" Then
            If IsNumeric(GridCaja.GetValue("Cantidad")) Then
                Dim Actual As Double
                Actual = GridCaja.GetValue("Valor") * Math.Abs(CDbl(GridCaja.GetValue("Cantidad")))
                GridCaja.SetValue("Monto", Actual)
            Else
                GridCaja.SetValue("Cantidad", 0)
            End If
        End If
    End Sub


    Private Sub GridCaja_RecordUpdated(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridCaja.RecordUpdated
        Efectivo = GridCaja.GetTotal(GridCaja.CurrentTable.Columns(3), Janus.Windows.GridEX.AggregateFunction.Sum)
        Otros = GridOtros.GetTotal(GridOtros.CurrentTable.Columns(2), Janus.Windows.GridEX.AggregateFunction.Sum)
        Total = Efectivo + Otros
        lblEfectivo.Text = "Total Efectivo " & Format(CStr(ModPOS.Redondear(Efectivo, 2)), "Currency")
        lblOtros.Text = "Total Documentos " & Format(CStr(ModPOS.Redondear(Otros, 2)), "Currency")
        lblTotal.Text = "Total " & Format(CStr(ModPOS.Redondear(Total, 2)), "Currency")
    End Sub

 

    Private Sub GridOtros_CellEdited(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ColumnActionEventArgs) Handles GridOtros.CellEdited
        If GridOtros.CurrentColumn.Caption = "Monto" Then
            If IsNumeric(GridOtros.GetValue("Monto")) Then
                Dim Actual As Double
                Actual = Math.Abs(CDbl(GridOtros.GetValue("Monto")))
                GridOtros.SetValue("Monto", Actual)
            Else
                GridOtros.SetValue("Monto", 0)
            End If
        End If
    End Sub

    Private Sub GridOtros_RecordUpdated(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridOtros.RecordUpdated
        Efectivo = GridCaja.GetTotal(GridCaja.CurrentTable.Columns(3), Janus.Windows.GridEX.AggregateFunction.Sum)
        Otros = GridOtros.GetTotal(GridOtros.CurrentTable.Columns(2), Janus.Windows.GridEX.AggregateFunction.Sum)
        Total = Efectivo + Otros
        lblEfectivo.Text = "Total Efectivo " & Format(CStr(ModPOS.Redondear(Efectivo, 2)), "Currency")
        lblOtros.Text = "Total Documentos " & Format(CStr(ModPOS.Redondear(Otros, 2)), "Currency")
        lblTotal.Text = "Total " & Format(CStr(ModPOS.Redondear(Total, 2)), "Currency")

    End Sub

    Private Sub Ctrls_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BtnOk.KeyUp, GridCaja.KeyUp, GridOtros.KeyUp
        Select Case e.KeyCode
            Case Is = Keys.Escape
                bError = False
                Close()
        End Select
    End Sub
End Class


