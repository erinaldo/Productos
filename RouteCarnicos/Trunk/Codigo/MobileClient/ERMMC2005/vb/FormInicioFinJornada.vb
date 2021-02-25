Public Class FormInicioFinJornada

    Sub New(ByVal pvTipoForma As eTipoForma)
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        oTipoForma = pvTipoForma
    End Sub

    Public Enum eTipoForma
        IniciarJornada = 1
        FinalizarJornada = 2
    End Enum

    Private refaVista As Vista
    Private oTipoForma As eTipoForma
#If MOD_TERM <> "PALM" Then
    Private WithEvents bScanner As New HANDHELD.CScanner
#End If
    Dim bLectorActivo As Boolean = False

    Private Sub FormInicioFinJornada_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        [Global].ObtenerFactores(Me)
        [Global].EscalarFuente(Me)
        [Global].EscalarForma(Me)
        If Not Vista.Buscar("FormInicioFinJornada", refaVista) Then
            Exit Sub
        End If
        refaVista.ColocarEtiquetasForma(Me)
        Me.TextBoxCodigo.Focus()

    End Sub

    Private Sub Aceptar()
        If Me.ValidarCodigo(Me.TextBoxCodigo.Text) Then
            If oTipoForma = eTipoForma.IniciarJornada Then
                oDBVen.EjecutarComandoSQL("Insert Into VendedorJornada (VendedorId, VEJFechaInicial, Enviado, MFechaHora, MUsuarioId) Values ('" & oVendedor.VendedorId & "', getdate(), 0, getdate(), '" & oVendedor.UsuarioId & "')")
            Else
                oDBVen.EjecutarComandoSQL("Update VendedorJornada Set FechaFinal=getdate(), Enviado = 0, MFechaHora=getdate(), MUsuarioId='" & oVendedor.UsuarioId & "' Where FechaFinal Is Null")
            End If
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Else
            Me.TextBoxCodigo.Text = String.Empty
            Me.TextBoxCodigo.Focus()
        End If
    End Sub

    Private Function ValidarCodigo(ByVal pvCodigo As String) As Boolean
        If Not oVendedor.CodigoBarras Is Nothing Then
            Dim sCodigo As String = oVendedor.CodigoBarras
            If sCodigo = pvCodigo Then
                Return True
            Else
                MsgBox(refaVista.BuscarMensaje("MsgBox", "E0489"), MsgBoxStyle.Critical, "Amesol Route")
                Return False
            End If
        Else
            Return False
        End If

    End Function

#Region "Lectura Codigo"
    Private Sub FormActivos_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
#If MOD_TERM <> "PALM" Then
        If Not bLectorActivo Then
            Select Case oApp.ModeloTerminal
                Case "Generico"

                Case "SymbolC9090", "SymbolMC50", "SymbolMC70"
                    Try
                        bScanner.Inicialize_Scanner(HANDHELD.SO.SymbolPCMC50)
                        bLectorActivo = True
                    Catch ex As Exception
                        MsgBox("Error while starting the scanner:" & ex.Message, MsgBoxStyle.Critical)
                    End Try
                Case "HHP7600"
                    bScanner.Inicialize_Scanner(HANDHELD.SO.HHP7600)
                    bLectorActivo = True
                Case "HHP7900"
                    bScanner.Inicialize_Scanner(HANDHELD.SO.HHP7900)
                    bLectorActivo = True
                Case "HHPWM6"
                    bScanner.Inicialize_Scanner(HANDHELD.SO.HHPWM6)
                    bLectorActivo = True
                Case "IntermecCN3"
                    bScanner.Inicialize_Scanner(HANDHELD.SO.IntermecCN3)
                    bLectorActivo = True
                Case "SymbolMC55"
                    bScanner.Inicialize_Scanner(HANDHELD.SO.SymbolMC55)
                    bLectorActivo = True
            End Select
        End If
#End If
    End Sub

#If MOD_TERM <> "PALM" Then
    Private Sub FormActivos_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        Try
            bScanner.Terminate_Scanner()
            bLectorActivo = False
        Catch ex As Exception
            MsgBox("Error while stopping the scanner:" & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
#End If

#If MOD_TERM <> "PALM" Then
    Private Sub bScanner_Data_Scanned(ByVal Data As String) Handles bScanner.Data_Scanned
        Me.TextBoxCodigo.Text = Data
        Aceptar()
    End Sub
#End If

    Private Sub TextBoxCodigo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBoxCodigo.KeyDown
        If e.KeyCode = Keys.Enter Then Aceptar()
    End Sub
   
#End Region

    Private Sub ButtonContinuar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonContinuar.Click
        Me.Aceptar()
    End Sub

    Private Sub ButtonRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRegresar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub MenuItemRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemRegresar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class