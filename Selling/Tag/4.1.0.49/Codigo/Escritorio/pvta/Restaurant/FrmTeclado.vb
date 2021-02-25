Public Class FrmTeclado
    Public OcultarSignos As Boolean = False
    Public Cantidad As String = ""
    Private bError As Boolean = False
    Public comTeclado As ITeclado

    Private Sub FrmTeclado_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If bError Then
            e.Cancel = True
        End If
    End Sub

    Private Sub agregarDatos(ByVal dato As String)
        If dato = "DESHACER" OrElse dato = "" Then
            If TxtCantidad.TextLength > 0 Then
                TxtCantidad.Text = TxtCantidad.Text.Remove(TxtCantidad.TextLength - 1, 1)
            End If
        Else
            TxtCantidad.Text &= dato
        End If
    End Sub

    Private Sub Btn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn1.Click
        agregarDatos("1")
        comTeclado.Concatenar("1")
    End Sub

    Private Sub Btn2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn2.Click
        agregarDatos("2")
        comTeclado.Concatenar("2")
    End Sub

    Private Sub Btn3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn3.Click
        agregarDatos("3")
        comTeclado.Concatenar("3")
    End Sub

    Private Sub Btn4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn4.Click
        agregarDatos("4")
        comTeclado.Concatenar("4")
    End Sub

    Private Sub Btn5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn5.Click
        agregarDatos("5")
        comTeclado.Concatenar("5")
    End Sub

    Private Sub Btn6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn6.Click
        agregarDatos("6")
        comTeclado.Concatenar("6")
    End Sub

    Private Sub Btn7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn7.Click
        agregarDatos("7")
        comTeclado.Concatenar("7")
    End Sub

    Private Sub Btn8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn8.Click
        agregarDatos("8")
        comTeclado.Concatenar("8")
    End Sub

    Private Sub Btn9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn9.Click
        agregarDatos("9")
        comTeclado.Concatenar("9")
    End Sub

    Private Sub BtnPunto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPunto.Click
        agregarDatos(".")
        comTeclado.Concatenar(".")
    End Sub

    Private Sub BtnCero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCero.Click
        agregarDatos("0")
        comTeclado.Concatenar("0")
    End Sub

    Private Sub BtnBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBorrar.Click
        agregarDatos("")
        comTeclado.Concatenar("")
    End Sub

    Private Sub BtnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        bError = False
        ModPOS.Teclado = Nothing
        Me.Close()
    End Sub

    Private Sub BtnEnter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEnter.Click
        ModPOS.Teclado = Nothing
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        bError = False
        Me.Close()
    End Sub

    Private Sub FrmTecladoNum_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim screen As Screen = screen.PrimaryScreen
        Dim height As Double = (screen.Bounds.Height - 400)
        Dim width As Double = (screen.Bounds.Width / 2) - (Me.Width / 2)
        Me.StartPosition = FormStartPosition.Manual
        Me.DesktopLocation = New System.Drawing.Point(width, height)
        Me.TxtCantidad.Text = Cantidad
        Me.Show()
        Me.BringToFront()
    End Sub

    Private Sub BtnGuion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuion.Click
        agregarDatos("-")
        comTeclado.Concatenar("-")
    End Sub

    Private Sub BtnA_Click(sender As Object, e As EventArgs) Handles BtnA.Click
        agregarDatos("A")
        comTeclado.Concatenar("A")
    End Sub

    Private Sub BtnB_Click(sender As Object, e As EventArgs) Handles BtnB.Click
        agregarDatos("B")
        SendKeys.Send("B")
        comTeclado.Concatenar("B")
    End Sub

    Private Sub keypressed(o As Object, e As KeyPressEventArgs)
        ' The keypressed method uses the KeyChar property to check 
        '/ whether the ENTER key is pressed. 

        'If the ENTER key is pressed, the Handled property is set to true, 
        'to indicate the event is handled.
        If (e.KeyChar = "a") Then
            e.Handled = True
        End If
    End Sub

    Private Sub BtnC_Click(sender As Object, e As EventArgs) Handles BtnC.Click
        agregarDatos("C")
        comTeclado.Concatenar("C")
    End Sub

    Private Sub BtnW_Click(sender As Object, e As EventArgs) Handles BtnW.Click
        agregarDatos("W")
        comTeclado.Concatenar("W")
    End Sub

    Private Sub BtnE_Click(sender As Object, e As EventArgs) Handles BtnE.Click
        agregarDatos("E")
        comTeclado.Concatenar("E")
    End Sub

    Private Sub BtnR_Click(sender As Object, e As EventArgs) Handles BtnR.Click
        agregarDatos("R")
        comTeclado.Concatenar("R")
    End Sub

    Private Sub BtnT_Click(sender As Object, e As EventArgs) Handles BtnT.Click
        agregarDatos("T")
        comTeclado.Concatenar("T")
    End Sub

    Private Sub BtnY_Click(sender As Object, e As EventArgs) Handles BtnY.Click
        agregarDatos("Y")
        comTeclado.Concatenar("Y")
    End Sub

    Private Sub BtnU_Click(sender As Object, e As EventArgs) Handles BtnU.Click
        agregarDatos("U")
        comTeclado.Concatenar("U")
    End Sub

    Private Sub BtnI_Click(sender As Object, e As EventArgs) Handles BtnI.Click
        agregarDatos("I")
        comTeclado.Concatenar("I")
    End Sub

    Private Sub BtnS_Click(sender As Object, e As EventArgs) Handles BtnS.Click
        agregarDatos("S")
        comTeclado.Concatenar("S")
    End Sub

    Private Sub BtnF_Click(sender As Object, e As EventArgs) Handles BtnF.Click
        agregarDatos("F")
        comTeclado.Concatenar("F")
    End Sub

    Private Sub BtnG_Click(sender As Object, e As EventArgs) Handles BtnG.Click
        agregarDatos("G")
        comTeclado.Concatenar("G")
    End Sub

    Private Sub BtnH_Click(sender As Object, e As EventArgs) Handles BtnH.Click
        agregarDatos("H")
        comTeclado.Concatenar("H")
    End Sub

    Private Sub BtnJ_Click(sender As Object, e As EventArgs) Handles BtnJ.Click
        agregarDatos("J")
        comTeclado.Concatenar("J")
    End Sub

    Private Sub BntK_Click(sender As Object, e As EventArgs) Handles BntK.Click
        agregarDatos("K")
        comTeclado.Concatenar("K")
    End Sub

    Private Sub BtnL_Click(sender As Object, e As EventArgs) Handles BtnL.Click
        agregarDatos("L")
        comTeclado.Concatenar("L")
    End Sub

    Private Sub Btb—_Click(sender As Object, e As EventArgs) Handles Btb—.Click
        agregarDatos("—")
        comTeclado.Concatenar("—")
    End Sub

    Private Sub BtnZ_Click(sender As Object, e As EventArgs) Handles BtnZ.Click
        agregarDatos("Z")
        comTeclado.Concatenar("Z")
    End Sub

    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles BtnX.Click
        agregarDatos("X")
        comTeclado.Concatenar("X")
    End Sub

    Private Sub BtnN_Click(sender As Object, e As EventArgs) Handles BtnN.Click
        agregarDatos("N")
        comTeclado.Concatenar("N")
    End Sub

    Private Sub BtnV_Click(sender As Object, e As EventArgs) Handles BtnV.Click
        agregarDatos("V")
        comTeclado.Concatenar("V")
    End Sub

    Private Sub BtnM_Click(sender As Object, e As EventArgs) Handles BtnM.Click
        agregarDatos("M")
        comTeclado.Concatenar("M")
    End Sub

    Private Sub BtnQ_Click(sender As Object, e As EventArgs) Handles BtnQ.Click
        agregarDatos("Q")
        comTeclado.Concatenar("Q")
    End Sub

    Private Sub BtnO_Click(sender As Object, e As EventArgs) Handles BtnO.Click
        agregarDatos("O")
        comTeclado.Concatenar("O")
    End Sub

    Private Sub BtnP_Click(sender As Object, e As EventArgs) Handles BtnP.Click
        agregarDatos("P")
        comTeclado.Concatenar("P")
    End Sub

    Private Sub BtnD_Click(sender As Object, e As EventArgs) Handles BtnD.Click
        agregarDatos("D")
        comTeclado.Concatenar("D")
    End Sub

    Private Sub BtnEspacio_Click(sender As Object, e As EventArgs) Handles BtnEspacio.Click
        agregarDatos(" ")
        comTeclado.Concatenar(" ")
    End Sub

    Private Sub BtnArroba_Click(sender As Object, e As EventArgs) Handles BtnArroba.Click
        agregarDatos("@")
        comTeclado.Concatenar("@")
    End Sub

    Private Sub BtnCOM_Click(sender As Object, e As EventArgs) Handles BtnCOM.Click
        agregarDatos(".COM")
        comTeclado.Concatenar(".COM")
    End Sub

    Private Sub BtnMX_Click(sender As Object, e As EventArgs) Handles BtnMX.Click
        agregarDatos(".MX")
        comTeclado.Concatenar(".MX")
    End Sub

    Private Sub BtnAmp_Click(sender As Object, e As EventArgs) Handles BtnAmp.Click
        agregarDatos("&")
        comTeclado.Concatenar("&")
    End Sub

    Private Sub BtnPor_Click(sender As Object, e As EventArgs) Handles BtnPor.Click
        agregarDatos("%")
        comTeclado.Concatenar("%")
    End Sub

    Private Sub FrmTeclado_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        ModPOS.Teclado = Nothing
    End Sub

    Private Sub btnGuionBajo_Click(sender As Object, e As EventArgs) Handles btnGuionBajo.Click
        agregarDatos("_")
        comTeclado.Concatenar("_")
    End Sub
End Class