Public Class FrmComplemento


    Public FacturaId As String
    Public Autorizado As Boolean

    Public FechaEntrega As Date = Today.Date
    Public NoCita As String
    Public NotaEntrada As String


    Private dtDetalle As DataTable
    Private bError As Boolean = False

    Private alerta(3) As PictureBox
    Private reloj As parpadea

    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        Dim foundRows() As DataRow
        foundRows = dtDetalle.Select("Referencia ='' or Referencia is Null")

        If foundRows.GetLength(0) > 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(3))
            reloj.Enabled = True
            reloj.Start()
        End If


        If Me.TxtNotaEntrada.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.TxtNoCita.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(2))
            reloj.Enabled = True
            reloj.Start()
        End If

        If i > 0 Then
            Return False
        Else
            While i < Me.alerta.Length
                Me.alerta(i).Visible = False
                i += 1
            End While
            Return True
        End If

    End Function


    Private Sub FrmComplemento_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If bError Then
            e.Cancel = True
        End If
    End Sub

    Private Sub FrmComplemento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2
        alerta(2) = Me.PictureBox3
        alerta(3) = Me.PictureBox4

        If Not dtDetalle Is Nothing Then
            dtDetalle.Dispose()
        End If

        dtDetalle = ModPOS.Recupera_Tabla("sp_info_complemento", "@FacturaId", FacturaId)
        GridDetalle.DataSource = dtDetalle
        GridDetalle.RetrieveStructure()
        GridDetalle.AutoSizeColumns()
        Me.GridDetalle.RootTable.Columns("Referencia").Width = 50
        GridDetalle.RootTable.Columns("VENClave").Visible = False
        GridDetalle.CurrentTable.Columns("Fecha").Selectable = False
        GridDetalle.CurrentTable.Columns("Folio").Selectable = False
        GridDetalle.CurrentTable.Columns("Total").Selectable = False

        dEntrega.Value = FechaEntrega
        TxtNoCita.Text = NoCita
        TxtNotaEntrada.Text = NotaEntrada

    End Sub

    Private Sub BtnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOK.Click


        If validaForm() Then

            NotaEntrada = TxtNotaEntrada.Text.Trim.ToUpper
            NoCita = TxtNoCita.Text.Trim.ToUpper
            FechaEntrega = dEntrega.Value


            Dim i As Integer

            For i = 0 To dtDetalle.Rows.Count - 1

                ModPOS.Ejecuta("sp_upd_nota_vta", _
                                "@VENClave", dtDetalle.Rows(i)("VENClave"), _
                                "@Nota", dtDetalle.Rows(i)("Referencia"))
            Next

            Autorizado = True
            bError = False

        Else
            bError = True
            Beep()
            MessageBox.Show("¡Alguna de las ventas a facturar no cuentan con el dato de referencia requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Autorizado = False
        bError = False
        Me.Close()
    End Sub


End Class