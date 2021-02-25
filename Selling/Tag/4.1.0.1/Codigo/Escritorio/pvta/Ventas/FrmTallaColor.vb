Public Class FrmTallaColor

    Public Clave As String
    Public ALMClave, sModelo As String
    Private iAvanceMenu, iAvanceSubmenu, iAvanceProductos, iAvanceMod As Integer
    Private bError As Boolean = True


    Private Sub btnColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim btn As Janus.Windows.EditControls.UIButton
        btn = sender
        grpTallas.Text = btn.Text
        llenaTallas(CDbl(btn.Name))
    End Sub

    Private Sub llenaColores()

        pnlColores.Controls.Clear()

        Dim Cnx As System.Data.SqlClient.SqlConnection = Nothing
        Dim dr As System.Data.SqlClient.SqlDataReader
        Dim myCommand As System.Data.SqlClient.SqlCommand


        Try
            Cnx = New System.Data.SqlClient.SqlConnection
            Cnx.ConnectionString = ModPOS.BDConexion
            Cnx.Open()
        Catch ex As Exception
            Beep()
            MessageBox.Show("No se puede conectar a la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        myCommand = New System.Data.SqlClient.SqlCommand("st_obtener_colores", Cnx)
        myCommand.CommandType = CommandType.StoredProcedure
        myCommand.CommandTimeout = ModPOS.myTimeOut
        myCommand.Parameters.Add("@COMClave", SqlDbType.VarChar).Value = ModPOS.CompanyActual
        myCommand.Parameters.Add("@Modelo", SqlDbType.VarChar).Value = sModelo

        dr = myCommand.ExecuteReader()

        Dim x, y As Integer
        x = 2
        y = 2



        While dr.Read
            Dim btn As Janus.Windows.EditControls.UIButton
            btn = New Janus.Windows.EditControls.UIButton
            btn.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Custom
            btn.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
            btn.Office2007CustomColor = Color.Blue
            btn.Name = dr("iColor")
            btn.Text = dr("Color")
            '  btn.ToolTipText = dr("Disponible")
            btn.Width = 90
            btn.Height = 60
            btn.Location = New Point(x, y)
            x += 95
            pnlColores.Controls.Add(btn)
            AddHandler btn.Click, AddressOf btnColor_Click

        End While

        myCommand.Dispose()
        dr.Close()

        pnlColores.HorizontalScroll.Enabled = False
        pnlColores.HorizontalScroll.Visible = False

        grpTallas.Text = pnlColores.Controls.Item(0).Text
        llenaTallas(CInt(pnlColores.Controls.Item(0).Name))

        iAvanceSubmenu = pnlColores.HorizontalScroll.LargeChange
    End Sub

    Private Sub btnTallas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim btn As Janus.Windows.EditControls.UIButton
        btn = sender
        Clave = btn.Name
        bError = False
        Me.DialogResult = DialogResult.OK
    End Sub

    Private Sub llenaTallas(ByVal iColor As Integer)

        pnlTallas.Controls.Clear()

        Dim Cnx As System.Data.SqlClient.SqlConnection = Nothing
        Dim dr As System.Data.SqlClient.SqlDataReader
        Dim myCommand As System.Data.SqlClient.SqlCommand


        Try
            Cnx = New System.Data.SqlClient.SqlConnection
            Cnx.ConnectionString = ModPOS.BDConexion
            Cnx.Open()
        Catch ex As Exception
            Beep()
            MessageBox.Show("No se puede conectar a la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        myCommand = New System.Data.SqlClient.SqlCommand("st_obtener_tallas", Cnx)
        myCommand.CommandType = CommandType.StoredProcedure
        myCommand.CommandTimeout = ModPOS.myTimeOut
        myCommand.Parameters.Add("@ALMClave", SqlDbType.VarChar).Value = ALMClave
        myCommand.Parameters.Add("@Modelo", SqlDbType.VarChar).Value = sModelo
        myCommand.Parameters.Add("@Color", SqlDbType.Float).Value = iColor

        dr = myCommand.ExecuteReader()

        Dim x, y As Integer
        x = 2
        y = 2

        Dim MaxCol, Col As Integer

        MaxCol = Math.Truncate(pnlTallas.Width / 95)


        While dr.Read

            If Col = MaxCol Then
                y += 65
                x = 2
                Col = 0
            End If
            Dim btn As Janus.Windows.EditControls.UIButton
            btn = New Janus.Windows.EditControls.UIButton
            btn.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Custom
            btn.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007

            btn.Name = dr("Clave")
            btn.Text = dr("Talla")
            If dr("Disponible") = 0 Then
                btn.Office2007CustomColor = Color.IndianRed
            Else
                btn.Office2007CustomColor = Color.Blue
            End If
            btn.Width = 90
            btn.Height = 60
            btn.Location = New Point(x, y)
            x += 95
            Col += 1
            pnlTallas.Controls.Add(btn)
            AddHandler btn.Click, AddressOf btnTallas_Click

        End While

        myCommand.Dispose()
        dr.Close()

        pnlTallas.VerticalScroll.Enabled = False
        pnlTallas.VerticalScroll.Visible = False



        iAvanceProductos = pnlTallas.VerticalScroll.LargeChange
    End Sub

    Private Sub btnDerColores_Click(sender As Object, e As EventArgs) Handles btnDerColores.Click
        If (pnlColores.HorizontalScroll.Value + iAvanceSubmenu) <= pnlColores.HorizontalScroll.Maximum Then
            pnlColores.HorizontalScroll.Value += iAvanceSubmenu
        Else
            pnlColores.HorizontalScroll.Value = pnlColores.HorizontalScroll.Maximum
        End If

    End Sub

    Private Sub btnIzqColores_Click(sender As Object, e As EventArgs) Handles btnIzqColores.Click
        If pnlColores.HorizontalScroll.Value > 0 AndAlso (pnlColores.HorizontalScroll.Value - iAvanceSubmenu) >= pnlColores.HorizontalScroll.Minimum Then
            pnlColores.HorizontalScroll.Value -= iAvanceSubmenu
        Else
            pnlColores.HorizontalScroll.Value = pnlColores.HorizontalScroll.Minimum
        End If
    End Sub

    Private Sub btnIniTallas_Click(sender As Object, e As EventArgs) Handles btnIniTallas.Click
        pnlTallas.VerticalScroll.Value = pnlTallas.VerticalScroll.Minimum
    End Sub

    Private Sub btnAntTallas_Click(sender As Object, e As EventArgs) Handles btnAntTallas.Click
        If pnlTallas.VerticalScroll.Value > 0 AndAlso (pnlTallas.VerticalScroll.Value - iAvanceProductos) >= pnlTallas.VerticalScroll.Minimum Then
            pnlTallas.VerticalScroll.Value -= iAvanceProductos
        Else
            pnlTallas.VerticalScroll.Value = pnlTallas.VerticalScroll.Minimum
        End If
    End Sub

    Private Sub btnSigTallas_Click(sender As Object, e As EventArgs) Handles btnSigTallas.Click
        If (pnlTallas.VerticalScroll.Value + iAvanceProductos) <= pnlTallas.VerticalScroll.Maximum Then
            pnlTallas.VerticalScroll.Value += iAvanceProductos
        Else
            pnlTallas.VerticalScroll.Value = pnlTallas.VerticalScroll.Maximum
        End If
    End Sub

    Private Sub btnUltTallas_Click(sender As Object, e As EventArgs) Handles btnUltTallas.Click
        pnlTallas.VerticalScroll.Value = pnlTallas.VerticalScroll.Maximum
    End Sub


    Private Sub FrmTallaColor_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If bError Then
            e.Cancel = True
        End If
    End Sub

    Private Sub FrmTallaColor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenaColores()
    End Sub
End Class