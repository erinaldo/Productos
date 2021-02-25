Public Class FormKilometraje

    Public Enum TipoKilometraje
        Inicial = 1
        Final = 2
    End Enum


#Region "Variables"
    Private refaVista As Vista
#If MOD_TERM <> "PALM" Then
    Private WithEvents bScanner As New HANDHELD.CScanner
#End If
    Private tTipoKm As TipoKilometraje
    Private bHuboCambios As Boolean
    Private sCAMVENId As String
    Private sPlaca As String
    Private sCamionClave As String
    Private nKmInicial As Double
    Private nKmFinal As Double
    Private bValidando As Boolean
#End Region

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

#Region "Eventos"
    Private Sub FormKilometraje_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        [Global].ObtenerFactores(Me)
        [Global].EscalarFuente(Me)
        [Global].EscalarForma(Me)
        ' Recuperar los demás componentes de la forma
        If Not Vista.Buscar("FormKilometraje", refaVista) Then
            Exit Sub
        End If
        ' Recuperar los rótulos y elementos de la pantalla desde la base de datos Sys
        refaVista.ColocarEtiquetasForma(Me)
        ConfigurarForma()
        bHuboCambios = False
        bValidando = False
    End Sub

    Private Sub FormKilometraje_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        If tTipoKm = TipoKilometraje.Inicial Then
            ActivarInactivarLector(False)
        End If
    End Sub

#If MOD_TERM <> "PALM" Then
    Private Sub bScanner_Data_Scanned(ByVal Data As String) Handles bScanner.Data_Scanned
        If Data <> "" Then
            TextBoxPlaca.Text = Data
            TextBoxKmInicial.Focus()
        End If
        'ValidarPlaca(Data)
    End Sub
#End If

    Private Sub ButtonRegresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonRegresar.Click
        Regresar()
    End Sub

    Private Sub MenuItemRegresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuItemRegresar.Click
        Regresar()
    End Sub

    Private Sub TextBoxPlaca_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBoxPlaca.KeyDown
        If e.KeyCode = Keys.Enter Then
            TextBoxKmInicial.Focus()
        End If
    End Sub

    Private Sub TextBoxPlaca_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TextBoxPlaca.Validating
        If Not ValidarPlaca(TextBoxPlaca.Text) Then
            e.Cancel = True
        End If
    End Sub

    Private Sub TextBoxKmInicial_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBoxKmInicial.KeyDown
        If e.KeyCode = Keys.Enter Then
            TextBoxKmInicial_Validating(TextBoxKmInicial, New System.ComponentModel.CancelEventArgs)
            If nKmInicial <> 0 Then
                ButtonContinuar_Click(ButtonContinuar, New System.EventArgs)
            End If
        End If
    End Sub

    Private Sub TextBoxKmInicial_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TextBoxKmInicial.Validating
        If bValidando Then Exit Sub
        If TextBoxKmInicial.Text = "" Then Exit Sub
        bValidando = True
        bHuboCambios = True
        nKmInicial = 0
        If Not IsNumeric(TextBoxKmInicial.Text) Then
            e.Cancel = True
            bValidando = False
            Exit Sub
        End If
        If Double.Parse(TextBoxKmInicial.Text) <= 0 Then
            MsgBox(refaVista.BuscarMensaje("MsgBox", "E0012"), MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical)
            e.Cancel = True
            bValidando = False
            Exit Sub
        End If
        nKmInicial = Double.Parse(TextBoxKmInicial.Text)
        bValidando = False
    End Sub

    Private Sub TextBoxKmFinal_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBoxKmFinal.KeyDown
        If e.KeyCode = Keys.Enter Then
            TextBoxKmFinal_Validating(TextBoxKmInicial, New System.ComponentModel.CancelEventArgs)
            If nKmFinal <> 0 Then
                ButtonContinuar_Click(ButtonContinuar, New System.EventArgs)
            End If
        End If
    End Sub

    Private Sub TextBoxKmFinal_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TextBoxKmFinal.Validating
        If bValidando Then Exit Sub
        If TextBoxKmFinal.Text = "" Then Exit Sub
        bValidando = True
        bHuboCambios = True
        nKmFinal = 0
        If Not IsNumeric(TextBoxKmFinal.Text) Then
            e.Cancel = True
            bValidando = False
            Exit Sub
        End If
        If Double.Parse(TextBoxKmFinal.Text) <= 0 Then
            MsgBox(refaVista.BuscarMensaje("MsgBox", "E0012"), MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical)
            e.Cancel = True
            bValidando = False
            Exit Sub
        End If
        If Double.Parse(TextBoxKmFinal.Text) < nKmInicial Then
            MsgBox(refaVista.BuscarMensaje("MsgBox", "E0716").Replace("$0$", LabelKmFinal.Text).Replace("$1$", LabelKmInicial.Text), MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical)
            e.Cancel = True
            bValidando = False
            Exit Sub
        End If
        nKmFinal = Double.Parse(TextBoxKmFinal.Text)
        bValidando = False
    End Sub

    Private Sub ButtonContinuar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonContinuar.Click
        Dim sCampo As String
        If Not ValidarRequeridos(sCampo) Then
            MsgBox(refaVista.BuscarMensaje("MsgBox", "BE0001").Replace("$0$", sCampo), MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical)
            Exit Sub
        End If
        Grabar()
        Me.Close()
    End Sub
#End Region

#Region "Metodos"

    Private Sub ConfigurarForma()
        Recuperar()
        MostrarDatos()

        TextBoxClave.Enabled = False
        Select Case tTipoKm
            Case TipoKilometraje.Inicial
                TextBoxPlaca.Enabled = True
                TextBoxKmInicial.Enabled = True
                TextBoxKmFinal.Enabled = False
                ActivarInactivarLector(True)
            Case TipoKilometraje.Final
                TextBoxPlaca.Enabled = False
                TextBoxKmInicial.Enabled = False
                TextBoxKmFinal.Enabled = True
        End Select
    End Sub

    Private Sub MostrarDatos()
        TextBoxPlaca.Text = sPlaca
        TextBoxClave.Text = sCamionClave
        If nKmInicial > 0 Then TextBoxKmInicial.Text = nKmInicial
        If nKmFinal > 0 Then TextBoxKmFinal.Text = nKmFinal
    End Sub

    Private Sub ActivarInactivarLector(ByVal parbActivar As Boolean)
#If MOD_TERM <> "PALM" Then
        If parbActivar Then
            Select Case oApp.ModeloTerminal
                Case "Generico"

                Case "SymbolC9090", "SymbolMC50", "SymbolMC70"
                    Try
                        bScanner.Inicialize_Scanner(HANDHELD.SO.SymbolPCMC50)
                    Catch ex As Exception
                        MsgBox("Error while starting the scanner:" & ex.Message, MsgBoxStyle.Critical)
                    End Try
                Case "HHP7600"
                    bScanner.Inicialize_Scanner(HANDHELD.SO.HHP7600)
                Case "HHP7900"
                    bScanner.Inicialize_Scanner(HANDHELD.SO.HHP7900)
                Case "HHPWM6"
                    bScanner.Inicialize_Scanner(HANDHELD.SO.HHPWM6)
                Case "SymbolMC35"
                    bScanner.Inicialize_Scanner(HANDHELD.SO.SymbolMC35)
                Case "IntermecCN3"
                    bScanner.Inicialize_Scanner(HANDHELD.SO.IntermecCN3)
                Case "SymbolMC55"
                    bScanner.Inicialize_Scanner(HANDHELD.SO.SymbolMC55)
            End Select
            'bLectorActivo = True
        Else
            Try
                bScanner.Terminate_Scanner()
                'bLectorActivo = False
            Catch ex As Exception
                MsgBox("Error while starting the scanner:" & ex.Message, MsgBoxStyle.Critical)
            End Try
        End If
#End If
    End Sub

    Private Function ValidarPlaca(ByVal pvPlaca As String) As Boolean
        sPlaca = ""
        If pvPlaca <> "" Then
            TextBoxPlaca.Text = pvPlaca
            Dim sConsulta As String = ""
            bHuboCambios = True
            sConsulta = "SELECT Camion.Clave FROM Camion WHERE Camion.Placa = '" & pvPlaca & "'"
            sCamionClave = oDBVen.EjecutarCmdScalarStrSQL(sConsulta)
            If sCamionClave Is Nothing Then
                sPlaca = ""
                TextBoxPlaca.Text = ""
                TextBoxClave.Text = ""
                MsgBox(refaVista.BuscarMensaje("MsgBox", "E0722"), MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical)
                TextBoxPlaca.Focus()
                Return False
            Else
                sPlaca = pvPlaca
                'TextBoxPlaca.Text = sPlaca
                TextBoxClave.Text = sCamionClave
                TextBoxKmInicial.Focus()
                Return True
            End If
        Else
            TextBoxClave.Text = ""
        End If
        Return True
    End Function

    Private Sub Regresar()
        If bHuboCambios Then
            If MsgBox(refaVista.BuscarMensaje("MsgBox", "BP0002"), MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        Me.Close()
    End Sub

    Private Function ValidarRequeridos(ByRef sCampo As String) As Boolean
        sCampo = ""
        If tTipoKm = TipoKilometraje.Inicial Then
            If sPlaca = "" Then
                sCampo = LabelPlaca.Text
            ElseIf nKmInicial = 0 Then
                sCampo = LabelKmInicial.Text
            End If
        Else
            If nKmFinal = 0 Then
                sCampo = LabelKmFinal.Text
            End If
        End If
        Return (sCampo = "")
    End Function

    Private Sub Grabar()
        Dim sComando As String
        Select Case tTipoKm
            Case TipoKilometraje.Inicial
                sCAMVENId = oApp.KEYGEN(1)
                sComando = String.Format("insert into CamionVendedor (CAMVENId, Placa, FechaHoraInicial, KmInicial, MFechaHora, Enviado) values ('{0}', '{1}', {2}, {3}, {4}, 0)", sCAMVENId, sPlaca, UniFechaSQL(Now), nKmInicial, UniFechaSQL(Now))
            Case TipoKilometraje.Final
                sComando = String.Format("update CamionVendedor set FechaHoraFinal = {0}, KmFinal = {1}, MFechaHora = {2}, Enviado = 0 where CAMVENId = '{3}'", UniFechaSQL(Now), nKmFinal, UniFechaSQL(Now), sCAMVENId)
        End Select
        oDBVen.EjecutarComandoSQL(sComando)
    End Sub

    Private Sub Recuperar()
        Dim sConsulta As String
        Dim dtKmInicial As DataTable
        sConsulta = "select CAMVENId, Placa, KmInicial from CamionVendedor where KmFinal is null and Enviado = 0"
        dtKmInicial = oDBVen.RealizarConsultaSQL(sConsulta, "CamionVendedor")
        If dtKmInicial.Rows.Count > 0 Then
            tTipoKm = TipoKilometraje.Final
            sCAMVENId = dtKmInicial.Rows(0)("CAMVENId")
            sPlaca = dtKmInicial.Rows(0)("Placa")
            nKmInicial = dtKmInicial.Rows(0)("KmInicial")
            nKmFinal = 0
            sConsulta = "SELECT Camion.Clave FROM Camion WHERE Camion.Placa = '" & sPlaca & "'"
            sCamionClave = oDBVen.EjecutarCmdScalarStrSQL(sConsulta)
        Else
            tTipoKm = TipoKilometraje.Inicial
            sCAMVENId = ""
            sPlaca = ""
            sCamionClave = ""
            nKmInicial = 0
            nKmFinal = 0
        End If
        dtKmInicial.Dispose()
    End Sub
#End Region
    
End Class