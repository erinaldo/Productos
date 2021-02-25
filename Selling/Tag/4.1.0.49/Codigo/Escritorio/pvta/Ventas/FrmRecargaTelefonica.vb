Imports System.Drawing

Public Class FrmRecargaTelefonica
    Inherits System.Windows.Forms.Form
    Public Const Operador As String = "Operador"
    Public Const Recarga As String = "Recarga"
    Public Padre As String = ""
    Public ClienteMostrador As String
    Public ClaveCaja As String
    Public Moneda As String
    Public TipoCambio As Decimal
    
    Private arrayFoto(0) As Foto
    Private iAvanceMenu As Integer
    Private indice As Integer = 0
    Private ultimaX, indiceSelected, ultimaY As Integer
    Private PictureSelected As String

    Public url_imagen As String
    Public impresora As String
    Public CAJClave As String

    Public PROClave As String
    Public CARClave As String 
    
    Private bCerrar As Boolean = False
    Friend WithEvents pnlOperaciones As System.Windows.Forms.Panel


#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'UserControl overrides dispose to clean up the component list.
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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRecargaTelefonica))
        Me.pnlOperaciones = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'pnlOperaciones
        '
        Me.pnlOperaciones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlOperaciones.AutoScroll = True
        Me.pnlOperaciones.Location = New System.Drawing.Point(6, 11)
        Me.pnlOperaciones.Name = "pnlOperaciones"
        Me.pnlOperaciones.Size = New System.Drawing.Size(695, 583)
        Me.pnlOperaciones.TabIndex = 1
        '
        'FrmRecargaTelefonica
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(713, 615)
        Me.Controls.Add(Me.pnlOperaciones)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(100, 371)
        Me.Name = "FrmRecargaTelefonica"
        Me.Text = "Seleccionar Operador"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Menu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim picFoto As Foto
        picFoto = sender
        PictureSelected = picFoto.IMGClave
        indiceSelected = picFoto.indice
        PROClave = picFoto.PROClave

        If Padre = Operador Then
            ReiniciarPanel()
            Padre = Recarga
            CargaProductos(PROClave)
        End If

    End Sub

    Private Sub Recarga_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim btnRecarga As Janus.Windows.EditControls.UIButton
        btnRecarga = sender
        PROClave = btnRecarga.Name
        PictureSelected = btnRecarga.Text
        CrearCargo(Decimal.Parse(btnRecarga.ToolTipText))
        bCerrar = True
        Me.Close()
    End Sub

    Private Sub CargaProductos(Optional ByVal OperadorSel As String = "")
        Dim i As Integer

        ultimaX = 10
        ultimaY = 2

        Dim dt As DataTable


        If Padre = Operador Then
            Me.Text = "Seleccione el Operador"

            dt = ModPOS.Recupera_Tabla("st_recupera_operador")

            For i = 0 To dt.Rows.Count - 1
                If (ultimaX + 170) >= pnlOperaciones.Width Then
                    ultimaY += 170
                    ultimaX = 10
                End If

                arrayFoto(indice) = New Foto(dt.Rows(i)("Clave"))

                arrayFoto(indice).Nuevo = False
                arrayFoto(indice).SizeMode = PictureBoxSizeMode.StretchImage
                arrayFoto(indice).Width = 160
                arrayFoto(indice).Height = 160
                arrayFoto(indice).Location = New Point(ultimaX, ultimaY)
                arrayFoto(indice).indice = indice
                arrayFoto(indice).BorderStyle = BorderStyle.Fixed3D
                arrayFoto(indice).PROClave = CStr(dt.Rows(i)("Clave"))

                If Not dt.Rows(i)("Imagen") Is System.DBNull.Value Then
                    arrayFoto(indice).Image = ModPOS.RecuperaImagen(url_imagen & CStr(dt.Rows(i)("Imagen")))
                    arrayFoto(indice).NombreImagen = CStr(dt.Rows(i)("Imagen"))
                End If

                ultimaX += 170

                pnlOperaciones.Controls.Add(arrayFoto(indice))
                AddHandler arrayFoto(indice).Click, AddressOf Menu_Click
                indice += 1
                ReDim Preserve arrayFoto(indice)
            Next

        Else
            Me.Text = "Seleccione el importe o paquete a recargar"


            dt = ModPOS.Recupera_Tabla("st_recupera_paquetesRecargas", "@Operador", OperadorSel)
            For i = 0 To dt.Rows.Count - 1

                If (ultimaX + 135) >= pnlOperaciones.Width Then
                    ultimaY += 110
                    ultimaX = 10
                End If

                Dim btn As Janus.Windows.EditControls.UIButton
                btn = New Janus.Windows.EditControls.UIButton
                btn.Office2007ColorScheme = Janus.Windows.UI.Office2007ColorScheme.Custom
                btn.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
                btn.Font = New System.Drawing.Font("Arial", 15.0!, FontStyle.Bold)
                btn.Name = dt.Rows(i)("Clave")
                btn.Text = dt.Rows(i)("Descripcion")
                btn.ToolTipText = dt.Rows(i)("Precio")
                btn.Office2007CustomColor = System.Drawing.Color.IndianRed

                btn.Width = 130
                btn.Height = 100
                btn.Location = New Point(ultimaX, ultimaY)
                ultimaX += 135
                pnlOperaciones.Controls.Add(btn)
                AddHandler btn.Click, AddressOf Recarga_Click

            Next
        End If

        pnlOperaciones.HorizontalScroll.Enabled = False
        pnlOperaciones.HorizontalScroll.Visible = False

        pnlOperaciones.VerticalScroll.Enabled = True
        pnlOperaciones.VerticalScroll.Visible = True
        iAvanceMenu = pnlOperaciones.VerticalScroll.LargeChange


    End Sub

    Private Sub FrmAgregaModelo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim dt As DataTable = ModPOS.Recupera_Tabla("sp_recupera_parametro", "@COMClave", ModPOS.CompanyActual)
        'With Me
        '    Dim i As Integer
        '    For i = 0 To dt.Rows.Count - 1
        '        Select Case CStr(dt.Rows(i)("PARClave"))
        '            Case "Imagenes"
        '                url_imagen = CStr(dt.Rows(i)("Valor"))
        '                'Dim DirActual As System.IO.DirectoryInfo = New System.IO.DirectoryInfo(Application.ExecutablePath).Parent
        '                'url_imagen = DirActual.FullName() & "\Operador"
        '                url_imagen &= "\Operador"
        '                If Not url_imagen.Substring(url_imagen.Length - 1, 1) = "\" Then
        '                    url_imagen &= "\"
        '                End If
        '                Exit For
        '        End Select
        '    Next
        'End With
        'dt.Dispose()
        url_imagen = pathActual & "Operador\"
        CargaProductos()

    End Sub

    Public Sub ReiniciarPanel()
        Dim con As Control
        For i As Integer = pnlOperaciones.Controls.Count - 1 To 0 Step -1
            con = pnlOperaciones.Controls(i)
            pnlOperaciones.Controls.Remove(con)
        Next
    End Sub

    Private Sub FrmRecargaTelefonica_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If bCerrar = False Then
            If Padre = Recarga Then
                e.Cancel = True
                ReiniciarPanel()
                Padre = Operador
                CargaProductos()
            End If
        Else
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
        End If

    End Sub

    Public Sub CrearCargo(ByVal Precio As Decimal)
        Dim Folio, Periodo, Mes As Integer

        Dim dt As DataTable = ModPOS.SiExisteRecupera("sp_recupera_folio", "@Tipo", 12, "@PDVClave", CAJClave)
        If dt Is Nothing Then
            ModPOS.Ejecuta("sp_crea_folio", "@Tipo", 12, "@PDVClave", CAJClave)
            Folio = 1
            Mes = Today.Month
            Periodo = Today.Year
        Else
            Folio = CInt(dt.Rows(0)("UltimoConsecutivo")) + 1
            Periodo = dt.Rows(0)("Periodo")
            Mes = dt.Rows(0)("Mes")
            ModPOS.Ejecuta("sp_act_folio", "@Tipo", 12, "@PDVClave", CAJClave, "@Incremento", 1)
            dt.Dispose()
        End If

        Dim sFolio As String = "CR" & ClaveCaja & Microsoft.VisualBasic.Right(CStr(Periodo), 2) & Microsoft.VisualBasic.Right("0" & CStr(Mes), 2) & "-" & CStr(Folio)
        CARClave = ModPOS.obtenerLlave

        ModPOS.Ejecuta("sp_crea_cargo", _
        "@CARClave", CARClave, _
        "@CTEClave", ClienteMostrador, _
        "@Folio", sFolio, _
        "@CAJClave", CAJClave, _
        "@Usuario", ModPOS.UsuarioActual, _
        "@Motivo", 3, _
        "@Descripcion", "Recarga " & PictureSelected, _
        "@Subtotal", Precio, _
        "@ImpuestoTot", 0, _
        "@Total", Precio, _
        "@MONClave", Moneda, _
        "@TipoCambio", TipoCambio)


        ModPOS.Ejecuta("st_inserta_cargodet", _
            "@DCRClave", ModPOS.obtenerLlave, _
            "@CARClave", CARClave, _
            "@Partida", 10, _
            "@PROClave", PROClave, _
            "@Costo", Precio, _
            "@Cantidad", 1, _
            "@PrecioBruto", Precio, _
            "@Subtotal", Precio, _
            "@PorcImp", 0, _
            "@ImpuestoImp", 0, _
            "@TotalPartida", Precio)

    End Sub

End Class
