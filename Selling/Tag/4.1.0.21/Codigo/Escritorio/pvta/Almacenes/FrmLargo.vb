Public Class FrmLargo
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
    Friend WithEvents BtnAceptar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtLargo As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LblLargo As System.Windows.Forms.Label
    Friend WithEvents NumUPDColumna As System.Windows.Forms.NumericUpDown
    Friend WithEvents LblColumna As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLargo))
        Me.TxtLargo = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.LblLargo = New System.Windows.Forms.Label
        Me.BtnAceptar = New Janus.Windows.EditControls.UIButton
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.NumUPDColumna = New System.Windows.Forms.NumericUpDown
        Me.LblColumna = New System.Windows.Forms.Label
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumUPDColumna, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TxtLargo
        '
        Me.TxtLargo.DecimalDigits = 2
        Me.TxtLargo.Location = New System.Drawing.Point(118, 40)
        Me.TxtLargo.Name = "TxtLargo"
        Me.TxtLargo.Size = New System.Drawing.Size(96, 20)
        Me.TxtLargo.TabIndex = 2
        Me.TxtLargo.Text = "0.00"
        Me.TxtLargo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.TxtLargo.Value = 0
        Me.TxtLargo.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(224, 40)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox1.TabIndex = 38
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(215, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 23)
        Me.Label1.TabIndex = 37
        Me.Label1.Text = "Metros"
        '
        'LblLargo
        '
        Me.LblLargo.Location = New System.Drawing.Point(0, 48)
        Me.LblLargo.Name = "LblLargo"
        Me.LblLargo.Size = New System.Drawing.Size(120, 23)
        Me.LblLargo.TabIndex = 35
        Me.LblLargo.Text = "Largo de la Columna"
        '
        'BtnAceptar
        '
        Me.BtnAceptar.Icon = CType(resources.GetObject("BtnAceptar.Icon"), System.Drawing.Icon)
        Me.BtnAceptar.Location = New System.Drawing.Point(161, 71)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(90, 37)
        Me.BtnAceptar.TabIndex = 3
        Me.BtnAceptar.Text = "&Aceptar"
        Me.BtnAceptar.ToolTipText = "Guarda cambios"
        Me.BtnAceptar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Icon = CType(resources.GetObject("BtnCancelar.Icon"), System.Drawing.Icon)
        Me.BtnCancelar.Location = New System.Drawing.Point(65, 71)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 4
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancela y cierra ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'NumUPDColumna
        '
        Me.NumUPDColumna.Location = New System.Drawing.Point(119, 8)
        Me.NumUPDColumna.Name = "NumUPDColumna"
        Me.NumUPDColumna.Size = New System.Drawing.Size(96, 20)
        Me.NumUPDColumna.TabIndex = 1
        '
        'LblColumna
        '
        Me.LblColumna.Location = New System.Drawing.Point(0, 16)
        Me.LblColumna.Name = "LblColumna"
        Me.LblColumna.Size = New System.Drawing.Size(120, 23)
        Me.LblColumna.TabIndex = 42
        Me.LblColumna.Text = "Numero de Columna"
        '
        'FrmLargo
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(256, 113)
        Me.Controls.Add(Me.LblColumna)
        Me.Controls.Add(Me.NumUPDColumna)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnAceptar)
        Me.Controls.Add(Me.TxtLargo)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LblLargo)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmLargo"
        Me.Text = "Modificar Largo de Columna"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumUPDColumna, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    Private alerta(1) As PictureBox
    Private reloj As parpadea

    Private Largo As Double


    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub FrmLargo_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPos.LargoColumna.Dispose()
        ModPos.LargoColumna = Nothing
    End Sub

    Private Sub FrmLargo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        alerta(0) = Me.PictureBox1
        Me.NumUPDColumna.Maximum = ModPos.vector(ModPos.Est_Selected).Columnas
    End Sub

    Private Sub NumUPDColumna_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumUPDColumna.ValueChanged
        If NumUPDColumna.Value > 0 Then

            Largo = RecuperaLargo(ModPos.vector(ModPos.Est_Selected).Name, NumUPDColumna.Value)
            Me.TxtLargo.Text = CStr(Largo)
            Largo = CDbl(TxtLargo.Text)
        Else
            Largo = 0
            Me.TxtLargo.Text = "0.00"
        End If
    End Sub

    Public Function RecuperaLargo(ByVal Est As String, ByVal Col As Integer) As Double
        Dim Cnx As System.Data.SqlClient.SqlConnection = Nothing
        Dim da As System.Data.SqlClient.SqlDataAdapter
        Dim dt As DataTable
        Dim dLargo As Double


        Cnx = New System.Data.SqlClient.SqlConnection

        Try
            Cnx.ConnectionString = ModPOS.BDConexion
            Cnx.Open()
        Catch ex As Exception
            Beep()
            MessageBox.Show("No se puede conectar a la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        da = New System.Data.SqlClient.SqlDataAdapter

        Try
            With da
                .SelectCommand = New System.Data.SqlClient.SqlCommand("sp_recupera_largo", Cnx)
                .SelectCommand.CommandTimeout = ModPOS.myTimeOut
                .SelectCommand.CommandType = CommandType.StoredProcedure
                .SelectCommand.Parameters.Add("@Estructura", SqlDbType.VarChar).Value = Est
                .SelectCommand.Parameters.Add("@Columna", SqlDbType.VarChar).Value = Col
            End With

        Catch ex As Exception
            Beep()
            MessageBox.Show("No se puede ejecutar la consulta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        dt = New DataTable

        da.Fill(dt)
        dLargo = dt.Rows(0)("Largo")

        dt.Dispose()
        da.Dispose()
        Cnx.Close()
        Return dLargo

    End Function

    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If Me.TxtLargo.Text = "" OrElse CDbl(Me.TxtLargo.Text) = 0 OrElse Largo = 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        End If


        If i > 0 Then
            Return False

        Else
            Me.alerta(0).Visible = False
            Return True
        End If
    End Function

    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click

        If Me.TxtLargo.Text <> CStr(Largo) Then
            If validaForm() Then
                Dim Con As String = ModPOS.BDConexion
                If ModPOS.SiExite(Con, "sp_columna_vacia", "@Estructura", ModPOS.vector(ModPOS.Est_Selected).Name, "@Columna", CStr(Me.NumUPDColumna.Value)) = 0 Then

                    actualizaLargo(ModPOS.vector(ModPOS.Est_Selected), Me.NumUPDColumna.Value, Largo, CDbl(Me.TxtLargo.Text))
                    ModPOS.vector(ModPOS.Est_Selected).CambioTamaño = False
                    Me.Close()

                Else
                    MessageBox.Show("No es posible modificar el ancho debido a que existen ubicaciones ocupadas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                Beep()
                MessageBox.Show("¡Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        End If

    End Sub

    Public Sub actualizaLargo(ByVal Est As Estructura, ByVal Col As Integer, ByVal largo As Double, ByVal Nuevo As Double)
        Dim dDiferencia As Double
        Dim MyTrans As System.Data.SqlClient.SqlTransaction
        Dim MyComand As System.Data.SqlClient.SqlCommand
        Dim Cnx As System.Data.SqlClient.SqlConnection = Nothing

        Try
            Cnx = New System.Data.SqlClient.SqlConnection
            Cnx.ConnectionString = ModPOS.BDConexion
            Cnx.Open()
        Catch ex As Exception
            Beep()
            MessageBox.Show("No se puede conectar a la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        MyTrans = Cnx.BeginTransaction
        MyComand = Cnx.CreateCommand()
        MyComand.Transaction = MyTrans

        dDiferencia = Nuevo - largo

        Try
            Est.Largo += dDiferencia

            If Est.Rotada Then
                Est.Height += CInt(dDiferencia * Est.Escala)
                MyComand.CommandText = "Update Estructura set Largo=" & CStr(Est.Largo + dDiferencia) & ", Height=" & CStr(Est.Height) & " where ESTClave='" & Est.Name & "'"
                MyComand.ExecuteNonQuery()
            Else
                Est.Width += CInt(dDiferencia * Est.Escala)
                MyComand.CommandText = "Update Estructura set Largo=" & CStr(Est.Largo + dDiferencia) & ", Width=" & CStr(Est.Width) & "where ESTClave='" & Est.Name & "'"
                MyComand.ExecuteNonQuery()
            End If

            MyComand.CommandText = "Update Hueco set Largo=" & CStr(Nuevo) & " where ESTClave='" & Est.Name & "' and Columna=" & CStr(Col)
            MyComand.ExecuteNonQuery()


            MyTrans.Commit()

        Catch ex As System.Data.SqlClient.SqlException
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Try
                MyTrans.Rollback()
            Catch es As System.Data.SqlClient.SqlException
                If Not MyTrans.Connection Is Nothing Then
                    MessageBox.Show("No se puede conectar con la base de datos, no rollback", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End Try

        End Try
        Cnx.Close()


    End Sub

End Class

