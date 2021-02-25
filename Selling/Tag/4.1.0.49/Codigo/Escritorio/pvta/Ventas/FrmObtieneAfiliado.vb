
Public Class FrmObtieneAfiliado
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
    Friend WithEvents BtnIngresar As Janus.Windows.EditControls.UIButton
    Friend WithEvents LblNota As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblMensaje As System.Windows.Forms.Label
    Friend WithEvents btnBuscaCte As Janus.Windows.EditControls.UIButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PictIcono2 As System.Windows.Forms.PictureBox
    Friend WithEvents TxtCliente As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmObtieneAfiliado))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LblNota = New System.Windows.Forms.Label()
        Me.TxtCliente = New System.Windows.Forms.TextBox()
        Me.BtnIngresar = New Janus.Windows.EditControls.UIButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblMensaje = New System.Windows.Forms.Label()
        Me.btnBuscaCte = New Janus.Windows.EditControls.UIButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PictIcono2 = New System.Windows.Forms.PictureBox()
        CType(Me.PictIcono2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Red
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Name = "Label1"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Red
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Name = "Label2"
        '
        'LblNota
        '
        resources.ApplyResources(Me.LblNota, "LblNota")
        Me.LblNota.Name = "LblNota"
        '
        'TxtCliente
        '
        resources.ApplyResources(Me.TxtCliente, "TxtCliente")
        Me.TxtCliente.Name = "TxtCliente"
        '
        'BtnIngresar
        '
        resources.ApplyResources(Me.BtnIngresar, "BtnIngresar")
        Me.BtnIngresar.Name = "BtnIngresar"
        Me.BtnIngresar.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Blue
        Me.BtnIngresar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.BackColor = System.Drawing.Color.Red
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Name = "Label3"
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.BackColor = System.Drawing.Color.Red
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Name = "Label5"
        '
        'lblMensaje
        '
        resources.ApplyResources(Me.lblMensaje, "lblMensaje")
        Me.lblMensaje.ForeColor = System.Drawing.Color.Red
        Me.lblMensaje.Name = "lblMensaje"
        '
        'btnBuscaCte
        '
        resources.ApplyResources(Me.btnBuscaCte, "btnBuscaCte")
        Me.btnBuscaCte.Icon = CType(resources.GetObject("btnBuscaCte.Icon"), System.Drawing.Icon)
        Me.btnBuscaCte.Image = CType(resources.GetObject("btnBuscaCte.Image"), System.Drawing.Image)
        Me.btnBuscaCte.Name = "btnBuscaCte"
        Me.btnBuscaCte.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.BackColor = System.Drawing.Color.Red
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Name = "Label4"
        '
        'PictIcono2
        '
        resources.ApplyResources(Me.PictIcono2, "PictIcono2")
        Me.PictIcono2.BackColor = System.Drawing.Color.Transparent
        Me.PictIcono2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictIcono2.Name = "PictIcono2"
        Me.PictIcono2.TabStop = False
        '
        'FrmObtieneAfiliado
        '
        resources.ApplyResources(Me, "$this")
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.PictIcono2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnBuscaCte)
        Me.Controls.Add(Me.lblMensaje)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.LblNota)
        Me.Controls.Add(Me.TxtCliente)
        Me.Controls.Add(Me.BtnIngresar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmObtieneAfiliado"
        CType(Me.PictIcono2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    Public Imagen As Image
    Private bError As Boolean = False
    Public MaskCte As Integer = 0
    Public CTEClave, SUCClave As String

    Private Sub FrmObtieneAfiliado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Not Imagen Is Nothing Then
            PictIcono2.Image = Imagen
        End If

        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Show()
        Me.BringToFront()
    End Sub

    Private Sub FrmObtieneAfiliado_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If bError Then
            e.Cancel = True
        End If
    End Sub


    Private Sub BtnIngresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnIngresar.Click
        If TxtCliente.Text <> "" Then

            If TxtCliente.Text.ToUpper.Trim = "111111111" Then
                CTEClave = "111111111"
                bError = False
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Else

                If MaskCte = 1 Then

                    If TxtCliente.Text.Split("-").Length = 1 AndAlso IsNumeric(TxtCliente.Text) AndAlso TxtCliente.Text.Length = 10 Then
                        TxtCliente.Text = TxtCliente.Text.Substring(0, 3) & "-" & TxtCliente.Text.Substring(3, 7)
                    End If

                    If TxtCliente.Text.Split("-").Length = 2 Then

                        If IsNumeric(TxtCliente.Text.Split("-")(0)) AndAlso IsNumeric(TxtCliente.Text.Split("-")(1)) Then

                            Dim sSucursal As String
                            Dim sClaveCte As String

                            sSucursal = String.Format("{0:000}", Val(CDbl(TxtCliente.Text.Split("-")(0))))
                            sClaveCte = String.Format("{0:0000000}", Val(CDbl(TxtCliente.Text.Split("-")(1))))

                            TxtCliente.Text = sSucursal & "-" & sClaveCte
                        End If
                        'Else
                        '    bError = True
                        '    Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                        '    lblMensaje.Text = "Número de Cliente o Afiliado Incorrecto"
                        '    TxtCliente.Text = ""
                        '    Exit Sub
                    End If

                End If


                Dim dt As DataTable
                dt = ModPOS.SiExisteRecupera("sp_recupera_clavecte", "@Clave", TxtCliente.Text.Trim.ToUpper.Replace("'", "''"), "@COMClave", ModPOS.CompanyActual, "@SUCClave", SUCClave)
                If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then

                    If dt.Rows.Count = 1 Then
                        CTEClave = dt.Rows(0)("CTEClave")

                        Dim msg As New FrmMsgTouch
                        msg.TxtTiulo = "Confirmar Identidad"
                        msg.TxtMsg = "¿ES USTED, " & CStr(dt.Rows(0)("RazonSocial")) & " ?"
                        msg.ShowDialog()
                        If msg.DialogResult = DialogResult.OK Then
                            If msg.Respuesta = True Then
                                bError = False
                                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                            Else
                                TxtCliente.Text = ""
                                bError = True
                                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                            End If
                        Else
                            TxtCliente.Text = ""
                            bError = True
                            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                        End If
                    Else
                        TxtCliente.Text = ""
                        lblMensaje.Text = "Se encontro más de una coincidencia. Contactar a Atención a Cliente"
                        bError = True
                        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel

                    End If

                Else
                    TxtCliente.Text = ""
                    lblMensaje.Text = "Número de Cliente o Afiliado Incorrecto"
                    bError = True
                    Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                End If
                End If

                Else



                bError = True
                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel

                TxtCliente_Click(Me, New KeyEventArgs(Keys.Space))
                End If
    End Sub

    Private Sub TxtCliente_Click(sender As Object, e As EventArgs) Handles TxtCliente.Click

        Dim dt As DataTable = ModPOS.Recupera_Tabla("sp_recupera_sucursal", "@SUCClave", SUCClave)

        Dim prefijo As String = CStr(dt.Rows(0)("Clave")) & "-"
        dt.Dispose()

        TxtCliente.Text = ""

        Dim a As New FrmTecladoNum
        a.Text = "Cliente"
        a.TxtCantidad.Text = "" 'prefijo
        a.OcultarSignos = True
        a.StartPosition = FormStartPosition.CenterScreen
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            Me.TxtCliente.Text = CStr(a.Cantidad)
            BtnIngresar.PerformClick()
        End If
    End Sub

    Private Sub btnBuscaCte_Click(sender As Object, e As EventArgs) Handles btnBuscaCte.Click
        Dim a As New MeSearch
        a.Touch = True
        a.ProcedimientoAlmacenado = "st_search_cliente"
        a.TablaCmb = "Cliente"
        a.CampoCmb = "Filtro"
        a.OcultaID = True
        a.CompaniaRequerido = True
        a.TouchCK = True
        a.WindowState = FormWindowState.Maximized
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            If Not a.valor Is Nothing Then
                Dim dt As DataTable
                dt = ModPOS.Recupera_Tabla("sp_recupera_cliente", "@CTEClave", a.valor)

                CTEClave = dt.Rows(0)("CTEClave")


                Dim msg As New FrmMsgTouch
                msg.TxtTiulo = "Confirmar Identidad"
                msg.TxtMsg = "¿ES USTED, " & CStr(dt.Rows(0)("RazonSocial")) & " ?"
                msg.ShowDialog()
                If msg.DialogResult = DialogResult.OK Then
                    If msg.Respuesta = True Then
                        bError = False
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    Else
                        bError = True
                        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                    End If
                Else
                    bError = True
                    Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                End If

            Else
                lblMensaje.Text = "Número de Cliente o Afiliado Incorrecto"
                bError = True
                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            End If

        End If
        a.Dispose()
    End Sub

    Private Sub TxtCliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtCliente.KeyPress
        If Asc(e.KeyChar) = 13 Then
            BtnIngresar.PerformClick()
        End If
    End Sub

  
End Class


