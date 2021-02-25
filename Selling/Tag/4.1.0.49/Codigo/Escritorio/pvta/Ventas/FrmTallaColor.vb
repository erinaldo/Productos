Public Class FrmTallaColor

    Private dtColores As DataTable
    Private dtTallas As DataTable
    Public iColorFijo As Integer = -1
    Public Clave As String
    Public ALMClave, sModelo, PREClave, SUCClave, CTEClave As String
    Public PrecioBruto As Decimal = 0
    Public PROClave As String = ""
    Public Talla As Integer = 0
    Public Preventa As Boolean = False
    Private iColor As Integer
    Private bError As Boolean = True
    Private bLoad As Boolean = False
    Private alerta(1) As PictureBox
    Private reloj As parpadea
    Private dtProducto As DataTable


    Private Sub cargaProducto(ByVal sClave As String)
        LblModelo.Text = sModelo
        Dim sColor As String
        Dim foundRows() As DataRow
        foundRows = dtProducto.Select("Clave = '" & sClave & "'")

        If foundRows.Length > 0 Then
            Me.Clave = sClave
            PROClave = foundRows(0)("PROClave")
            PrecioBruto = foundRows(0)("PrecioBruto")
            Talla = foundRows(0)("Talla")
        End If
    End Sub


    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If Me.cmbColor.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        End If
      

        If cmbTalla.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
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


    Private Sub FrmTallaColor_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If bError Then
            e.Cancel = True
        End If
    End Sub

    Private Sub FrmTallaColor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.StartPosition = FormStartPosition.CenterScreen
        alerta(0) = Me.PictureBox17
        alerta(1) = Me.PictureBox18

        dtProducto = ModPOS.Recupera_Tabla("st_venta_modelo", "@Modelo", sModelo, "@SUCClave", SUCClave, "@PREClave", PREClave, "@CTEClave", CTEClave)

        Preventa = dtProducto.Rows(0)("Preventa")

        lblModelo.Text = "MODELO: " & sModelo

        If dtColores Is Nothing Then
            dtColores = ModPOS.Recupera_Tabla("st_obtener_colores", "@COMClave", ModPOS.CompanyActual, "@Modelo", sModelo, "@Color", iColorFijo)
        End If

        With Me.cmbColor
            .dt = dtColores
            .llenar()
        End With

        If dtColores.Rows.Count >= 1 Then
            iColor = dtColores.Rows(0)("iColor")
        End If

        If dtColores.Rows.Count = 1 Then
            cmbColor.Enabled = False
        End If


        If dtTallas Is Nothing Then
            dtTallas = ModPOS.Recupera_Tabla("st_obtener_tallas", "@ALMClave", ALMClave, "@Modelo", sModelo, "@Color", iColor)
        End If

        With Me.cmbTalla
            .dt = dtTallas
            .llenar()
        End With

        If dtTallas.Rows.Count = 1 Then
            cmbTalla.Enabled = False
            Clave = dtTallas.Rows(0)("Clave")
            cmbTalla.SelectedValue = Clave
        End If


        bLoad = True

    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        bError = False
        Me.Close()
    End Sub

    Private Sub cmbColor_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbColor.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub cmbTalla_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbTalla.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        If validaForm() Then
            Clave = cmbTalla.SelectedValue
            cargaProducto(Clave)
            bError = False
        Else
            bError = True
            Beep()
            MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub cmbColor_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbColor.SelectedValueChanged
        If bLoad = True AndAlso Not cmbColor.SelectedValue Is Nothing Then
            With Me.cmbTalla
                dtTallas = ModPOS.Recupera_Tabla("st_obtener_tallas", "@ALMClave", ALMClave, "@Modelo", sModelo, "@Color", cmbColor.SelectedValue)
                .dt = dtTallas
                .llenar()
            End With
        End If
    End Sub

    Private Sub btnSalir_Click_1(sender As Object, e As EventArgs) Handles btnSalir.Click
        bError = False
        Me.Close()
    End Sub
End Class