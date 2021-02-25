Public Class FrmAperturaCaja
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
    Friend WithEvents LbNombre As System.Windows.Forms.Label
    Friend WithEvents LBTitulo As System.Windows.Forms.Label
    Friend WithEvents LbClave As System.Windows.Forms.Label
    Friend WithEvents LbUsuario As System.Windows.Forms.Label
    Friend WithEvents LbFecha As System.Windows.Forms.Label
    Friend WithEvents lblEfectivo As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GridOtros As Janus.Windows.GridEX.GridEX
    Friend WithEvents lblOtros As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents GridCaja As Janus.Windows.GridEX.GridEX
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAperturaCaja))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.LbNombre = New System.Windows.Forms.Label
        Me.BtnOk = New Janus.Windows.EditControls.UIButton
        Me.LBTitulo = New System.Windows.Forms.Label
        Me.LbClave = New System.Windows.Forms.Label
        Me.LbUsuario = New System.Windows.Forms.Label
        Me.LbFecha = New System.Windows.Forms.Label
        Me.lblEfectivo = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GridCaja = New Janus.Windows.GridEX.GridEX
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GridOtros = New Janus.Windows.GridEX.GridEX
        Me.lblOtros = New System.Windows.Forms.Label
        Me.lblTotal = New System.Windows.Forms.Label
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
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
        'LbNombre
        '
        resources.ApplyResources(Me.LbNombre, "LbNombre")
        Me.LbNombre.Name = "LbNombre"
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
        'LbClave
        '
        resources.ApplyResources(Me.LbClave, "LbClave")
        Me.LbClave.Name = "LbClave"
        '
        'LbUsuario
        '
        resources.ApplyResources(Me.LbUsuario, "LbUsuario")
        Me.LbUsuario.Name = "LbUsuario"
        '
        'LbFecha
        '
        resources.ApplyResources(Me.LbFecha, "LbFecha")
        Me.LbFecha.Name = "LbFecha"
        '
        'lblEfectivo
        '
        resources.ApplyResources(Me.lblEfectivo, "lblEfectivo")
        Me.lblEfectivo.Name = "lblEfectivo"
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
        'lblOtros
        '
        resources.ApplyResources(Me.lblOtros, "lblOtros")
        Me.lblOtros.Name = "lblOtros"
        '
        'lblTotal
        '
        resources.ApplyResources(Me.lblTotal, "lblTotal")
        Me.lblTotal.Name = "lblTotal"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.BackColor = System.Drawing.SystemColors.Control
        Me.BtnCancelar.Icon = CType(resources.GetObject("BtnCancelar.Icon"), System.Drawing.Icon)
        resources.ApplyResources(Me.BtnCancelar, "BtnCancelar")
        Me.BtnCancelar.Name = "BtnCancelar"
        '
        'FrmAperturaCaja
        '
        resources.ApplyResources(Me, "$this")
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.lblOtros)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblEfectivo)
        Me.Controls.Add(Me.LbFecha)
        Me.Controls.Add(Me.LbUsuario)
        Me.Controls.Add(Me.LbClave)
        Me.Controls.Add(Me.LBTitulo)
        Me.Controls.Add(Me.BtnOk)
        Me.Controls.Add(Me.LbNombre)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmAperturaCaja"
        Me.ShowInTaskbar = False
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.GridCaja, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.GridOtros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region


    Public Impresora As String
    Public Generic As Boolean
    Public Recibo As String
    
    Public Accion As String
    Public CAJClave As String
    Public Total, Efectivo, Otros As Double
    Public IDCorte As String

    Public Cajon As Boolean = False

    Private dtMonto, dtOtros As DataTable

 
    Private Sub creaDetalle(ByVal Tipo As Integer)

        Efectivo = GridCaja.GetTotal(GridCaja.CurrentTable.Columns("Monto"), Janus.Windows.GridEX.AggregateFunction.Sum)

        Dim i As Integer
        Dim foundRows() As DataRow

        If Efectivo > 0 Then

            foundRows = dtMonto.Select("Monto > 0")
            If foundRows.GetLength(0) > 0 Then
                For i = 0 To foundRows.GetUpperBound(0)

                    ModPOS.Ejecuta("sp_inserta_corteDetalle", _
                                    "@IDCorte", IDCorte, _
                                    "@Tipo", Tipo, _
                                    "@TipoImporte", 1, _
                                    "@Cantidad", CInt(foundRows(i)("Cantidad")), _
                                    "@Denominacion", CDbl(foundRows(i)("Valor")), _
                                    "@Importe", CDbl(foundRows(i)("Monto")))
                Next
            End If

        End If

        Otros = GridOtros.GetTotal(GridOtros.CurrentTable.Columns("Monto"), Janus.Windows.GridEX.AggregateFunction.Sum)

        If Otros > 0 Then
            foundRows = dtOtros.Select("Monto > 0")
            If foundRows.GetLength(0) > 0 Then
                For i = 0 To foundRows.GetUpperBound(0)

                    ModPOS.Ejecuta("sp_inserta_corteDetalle", _
                                    "@IDCorte", IDCorte, _
                                    "@Tipo", Tipo, _
                                    "@TipoImporte", CInt(foundRows(i)("Valor")), _
                                    "@Cantidad", 1, _
                                    "@Importe", CDbl(foundRows(i)("Monto")))
                Next
            End If
        End If
    End Sub

    Private Sub FrmAperturaCaja_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        LbFecha.Text = DateTime.Today.ToLongDateString

        Dim dtCaja As DataTable = ModPOS.SiExisteRecupera("sp_recupera_caja", "@Caja", Me.CAJClave)

        If Not dtCaja Is Nothing Then
            LbClave.Text = "Clave: " & dtCaja.Rows(0)("Clave")
            LbNombre.Text = "Nombre: " & dtCaja.Rows(0)("Nombre")
        End If

        Dim dtUsuario As DataTable = ModPOS.SiExisteRecupera("sp_recupera_UsuarioActual", "@Usuario", ModPOS.UsuarioActual)

        If Not dtUsuario Is Nothing Then
            LbUsuario.Text = "Usuario: " & dtUsuario.Rows(0)("Nombre")
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
        If Cajon = True Then
            AbrirCajon(Impresora)
        End If
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click

        If Accion = "Apertura" Then
            If IDCorte <> "" Then
                ModPOS.Ejecuta("sp_cierra_corteCaja", "@ID", IDCorte, "@CAJClave", CAJClave, "@Saldo", Total, "@Usuario", ModPOS.UsuarioActual)
                creaDetalle(2)
            End If
            IDCorte = ModPOS.obtenerLlave
            ModPOS.Ejecuta("sp_crea_corteCaja", "@ID", IDCorte, "@CAJClave", CAJClave, "@Saldo", Total, "@Usuario", ModPOS.UsuarioActual)
            creaDetalle(1)
            Dim StopPrint As Boolean = False

            Dim sPrintMessage As String = "¿Desea Imprimir la Apertura de Caja?"
            Do
                Select Case MessageBox.Show(sPrintMessage, "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    Case DialogResult.Yes
                        imprimeTicketApertura(IDCorte, Impresora, Generic, Recibo)
                        sPrintMessage = "¿Desea Reimprimir la Apertura de Caja?"
                    Case Else
                        StopPrint = True
                End Select
            Loop While Not StopPrint


        Else
            ModPOS.Ejecuta("sp_cierra_corteCaja", "@ID", IDCorte, "@CAJClave", CAJClave, "@Saldo", Total, "@Usuario", ModPOS.UsuarioActual)
            creaDetalle(2)

            Dim StopPrint As Boolean = False

            Dim sPrintMessage As String = "¿Desea Imprimir el Corte de Caja?"
            Do
                Select Case MessageBox.Show(sPrintMessage, "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    Case DialogResult.Yes
                        imprimeTicketCierre(IDCorte, Impresora, Generic, Recibo)
                        sPrintMessage = "¿Desea Reimprimir el Corte de Caja?"
                    Case Else
                        StopPrint = True
                End Select
            Loop While Not StopPrint

        End If
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
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

    Private Sub BtnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class


