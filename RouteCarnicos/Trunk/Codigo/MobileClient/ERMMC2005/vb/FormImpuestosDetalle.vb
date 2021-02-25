Public Class FormImpuestosDetalle
    Inherits System.Windows.Forms.Form
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents LabelTitulo As System.Windows.Forms.Label
    Private WithEvents DetailViewTotales As Resco.Controls.DetailView.DetailView
    Friend WithEvents ButtonRegresar As System.Windows.Forms.Button
    Friend WithEvents MenuItemRegresar As System.Windows.Forms.MenuItem

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal pvTransProdId As String, ByVal pvDescVendPor As Double)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        sTransProdId = pvTransProdId
        dDescVendPor = pvDescVendPor
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If Not Me.MenuItemRegresar Is Nothing Then Me.MenuItemRegresar.Dispose()
        If Not Me.MainMenu1 Is Nothing Then Me.MainMenu1.Dispose()

        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.MenuItemRegresar = New System.Windows.Forms.MenuItem
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.LabelTitulo = New System.Windows.Forms.Label
        Me.DetailViewTotales = New Resco.Controls.DetailView.DetailView
        Me.ButtonRegresar = New System.Windows.Forms.Button
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.Add(Me.MenuItemRegresar)
        '
        'MenuItemRegresar
        '
        Me.MenuItemRegresar.Text = "MenuItemRegresar"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.LabelTitulo)
        Me.Panel1.Controls.Add(Me.DetailViewTotales)
        Me.Panel1.Controls.Add(Me.ButtonRegresar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(242, 295)
        '
        'LabelTitulo
        '
        Me.LabelTitulo.Location = New System.Drawing.Point(2, 7)
        Me.LabelTitulo.Name = "LabelTitulo"
        Me.LabelTitulo.Size = New System.Drawing.Size(236, 20)
        Me.LabelTitulo.Text = "LabelTitulo"
        '
        'DetailViewTotales
        '
        Me.DetailViewTotales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DetailViewTotales.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DetailViewTotales.LabelWidth = 110
        Me.DetailViewTotales.Location = New System.Drawing.Point(2, 31)
        Me.DetailViewTotales.Name = "DetailViewTotales"
        Me.DetailViewTotales.PagingStyle = Resco.Controls.DetailView.RescoPageStyle.TabStrip
        Me.DetailViewTotales.SeparatorWidth = 4
        Me.DetailViewTotales.Size = New System.Drawing.Size(232, 227)
        Me.DetailViewTotales.TabIndex = 4
        '
        'ButtonRegresar
        '
        Me.ButtonRegresar.Location = New System.Drawing.Point(2, 262)
        Me.ButtonRegresar.Name = "ButtonRegresar"
        Me.ButtonRegresar.Size = New System.Drawing.Size(74, 24)
        Me.ButtonRegresar.TabIndex = 5
        Me.ButtonRegresar.Text = "ButtonRegresar"
        '
        'FormImpuestosDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(242, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Location = New System.Drawing.Point(0, 0)
        Me.Menu = Me.MainMenu1
        Me.Name = "FormImpuestosDetalle"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "VARIABLES"
    Private sTransProdId As String
    Private dDescVendPor As Double
    Private refaVista As Vista
#End Region

#Region "METODOS"
    Private Sub LlenaDetailView()
        Try
            Dim sQuery As New System.Text.StringBuilder
            Dim dSumaImpuestos As Double = 0
            'El total de impuestos
            'sQuery.Append("SELECT Sum(ImpuestoImp) FROM TPDImpuesto WHERE TransProdId='" & sTransProdId & "'")
            'Dim oDt As DataTable = oDBVen.RealizarConsultaSQL(sQuery.ToString, "SumaImpuestos")
            'If Not IsDBNull(oDt.Rows(0)(0)) Then
            dSumaImpuestos = oDBVen.EjecutarCmdScalardblSQL("SELECT Sum(ImpuestoImp) FROM TPDImpuesto WHERE TransProdId='" & sTransProdId & "'")
            'End If
            If dSumaImpuestos = 0 Then Exit Sub
            'Los distintos Impuestos
            sQuery = New System.Text.StringBuilder
            sQuery.Append("SELECT Distinct Imp.ImpuestoClave, Jerarquia, TipoValor from TPDImpuesto TPDI INNER JOIN Impuesto as Imp ON TPDI.ImpuestoClave=Imp.ImpuestoClave WHERE TPDI.transprodid='" & sTransProdId & "' ORDER BY Jerarquia")
            Dim oDt As DataTable = oDBVen.RealizarConsultaSQL(sQuery.ToString, "Impuestos")

            Dim oArrImpClave As New ArrayList
            Dim oArrImpCant As New ArrayList
            Dim oArrImpTipoValor As New ArrayList
            'Dim oHt As New Hashtable
            For Each oDr As DataRow In oDt.Rows
                'oHt.Add(oDr("ImpuestoClave").ToString, 0)
                oArrImpClave.Add(oDr("ImpuestoClave"))
                oArrImpCant.Add(0)
                oArrImpTipoValor.Add(oDr("TipoValor"))
            Next
            oDt.Dispose()
            'Descuentos por cliente
            Dim oArrDescuentos As New ArrayList
            sQuery = New System.Text.StringBuilder
            sQuery.Append("SELECT DesPor,Jerarquia,TipoCascada FROM TpdDes WHERE TransProdId='" & sTransProdId & "' group by DescuentoClave,DesPor,Jerarquia,TipoCascada ORDER BY Jerarquia ASC")
            oDt = oDBVen.RealizarConsultaSQL(sQuery.ToString, "TpdDes")
            For Each oDr As DataRow In oDt.Rows
                oArrDescuentos.Add(oDr)
            Next
            oDt.Dispose()
            'Subtotal con descuentos
            Dim dSubTotConDesc As Double = oDBVen.EjecutarCmdScalardblSQL("SELECT SUM(Subtotal - DesImporteT) FROM TransProdDetalle WHERE TransProdId='" & sTransProdId & "'")
            'For i As Integer = 0 To oArrDescuentos.Count - 1
            '    dSubTotConDesc -= dSubTotConDesc * oArrDescuentos(i) / 100
            'Next
            'Descuento del vendedor
            dSubTotConDesc -= dSubTotConDesc * dDescVendPor / 100

            'Por producto
            sQuery = New System.Text.StringBuilder
            sQuery.Append("SELECT TransProdDetalleID FROM TransProdDetalle WHERE TransProdId='" & sTransProdId & "'")
            oDt = oDBVen.RealizarConsultaSQL(sQuery.ToString, "TransProdDetalle")
            For Each oDrTPD As DataRow In oDt.Rows
                'Dim dSubTot As Double = oDrTPD("SubTotal")
                'Descuentos del cliente
                'For i As Integer = 0 To oArrDescuentos.Count - 1
                'dSubTot -= oDrTPD("DesImporteT")
                'Next
                'Descuento del vendedor
                'dSubTot -= dSubTot * dDescVendPor / 100
                'Dim oDic As IDictionaryEnumerator = oHt.GetEnumerator
                For i As Integer = 0 To oArrImpClave.Count - 1
                    Dim dTotImp As Double = oDBVen.EjecutarCmdScalardblSQL("SELECT ImpuestoImp FROM TPDImpuesto WHERE TransProdId='" & sTransProdId & "' AND TransProdDetalleId='" & oDrTPD("TransProdDetalleId") & "' AND ImpuestoClave='" & oArrImpClave(i) & "'")
                    Dim dImpActual As Double = dTotImp
                    'If oDtImp.Rows.Count > 0 Then
                    'Descuentos del cliente
                    If dTotImp > 0 Then
                        If (oArrImpTipoValor(i) = 1) Then

                            For j As Integer = 0 To oArrDescuentos.Count - 1
                                If CType(oArrDescuentos(j), DataRow)("TipoCascada") Then
                                    dImpActual -= dImpActual * CType(oArrDescuentos(j), DataRow)("DesPor") / 100
                                Else
                                    dImpActual -= dTotImp * CType(oArrDescuentos(j), DataRow)("DesPor") / 100
                                End If
                            Next
                            'Descuento del vendedor
                            dImpActual -= dImpActual * dDescVendPor / 100
                        End If
                        'Se actualiza
                        oArrImpCant(i) += dImpActual
                    End If
                    'End If
                    'oDtImp.Dispose()
                Next
            Next
            'Dim oIDic As IDictionaryEnumerator = oHt.GetEnumerator
            For i As Integer = 0 To oArrImpClave.Count - 1
                Dim oTxt As New Resco.Controls.DetailView.ItemTextBox
                oTxt.Style = Resco.Controls.DetailView.RescoItemStyle.LabelLeft
                oTxt.LabelWidth = 120
                oTxt.Enabled = False
                oTxt.Label = oDBVen.RealizarConsultaSQL("SELECT Abreviatura FROM Impuesto WHERE ImpuestoClave='" & oArrImpClave(i) & "'", "Abreviatura").Rows(0)("Abreviatura")
                oTxt.LabelAlignment = HorizontalAlignment.Left
                oTxt.LabelForeColor = Drawing.Color.Blue
                oTxt.LabelFont = New System.Drawing.Font("Verdana", IIf(10.0! * nFactorFont < 7.0, 7.0, 10.0! * nFactorFont), System.Drawing.FontStyle.Regular)
                oTxt.Text = Format(IIf(oArrImpCant(i) < 0, 0, RedondeoAritmetico(oArrImpCant(i), 2)), oApp.FormatoDinero)
                oTxt.TextAlign = HorizontalAlignment.Right
                oTxt.TextFont = New System.Drawing.Font("Verdana", IIf(10.0! * nFactorFont < 7.0, 7.0, 10.0! * nFactorFont), System.Drawing.FontStyle.Regular)
                oTxt.Height = PubcAlturaItemsDetailView * IIf(bEscalarDV, nFactorH, 1)
                Me.DetailViewTotales.Items.Add(oTxt)
            Next
            oDt.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region

#Region "EVENTOS"
    Private Sub FormImpuestosDetalle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor.Current = Cursors.WaitCursor
        [Global].ObtenerFactores(Me)
        [Global].EscalarFuente(Me)
        [Global].EscalarForma(Me)
        If Not Vista.Buscar("FormImpuestosDetalle", refaVista) Then
            Cursor.Current = Cursors.Default
            Exit Sub
        End If
        refaVista.ColocarEtiquetasForma(Me)
        Me.LlenaDetailView()
        Cursor.Current = Cursors.Default

        With Me.DetailViewTotales
            If .Items.Count > 0 Then
                .Items(0).SetFocus()
            Else
                Me.ButtonRegresar.Focus()
            End If
        End With

    End Sub

    Private Sub ButtonRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRegresar.Click
        Me.Close()
    End Sub

    Private Sub MenuItemRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemRegresar.Click
        Me.Close()
    End Sub

#End Region

   End Class
