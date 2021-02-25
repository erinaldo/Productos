Imports System.Data.SqlClient

Public Class StoreCombo
    Inherits ComboBox

    Private Cadena, sp, nomp1, nomp2, nomp3, param1, param2, param3 As String

    Public WriteOnly Property Conexion() As String
        Set(ByVal Value As String)
            Cadena = Value
        End Set
    End Property

    Public WriteOnly Property ProcedimientoAlmacenado() As String
        Set(ByVal Value As String)
            sp = Value
        End Set
    End Property

    Public WriteOnly Property NombreParametro1() As String
        Set(ByVal Value As String)
            nomp1 = Value
        End Set
    End Property

    Public WriteOnly Property Parametro1() As String
        Set(ByVal Value As String)
            param1 = Value
        End Set
    End Property

    Public WriteOnly Property NombreParametro2() As String
        Set(ByVal Value As String)
            nomp2 = Value
        End Set
    End Property

    Public WriteOnly Property Parametro2() As String
        Set(ByVal Value As String)
            param2 = Value
        End Set
    End Property

    Public WriteOnly Property NombreParametro3() As String
        Set(ByVal Value As String)
            nomp3 = Value
        End Set
    End Property

    Public WriteOnly Property Parametro3() As String
        Set(ByVal Value As String)
            param3 = Value
        End Set
    End Property
    Public Sub AutoCompletarCombo_KeyUp(ByVal cbo As ComboBox, ByVal e As KeyEventArgs)
        Dim sTypedText As String
        Dim iFoundIndex As Integer
        Dim oFoundItem As Object
        Dim sFoundText As String
        Dim sAppendText As String

        'Allow select keys without Autocompleting
        Select Case e.KeyCode
            Case Keys.Back, Keys.Left, Keys.Right, Keys.Up, Keys.Delete, Keys.Down
                Return
        End Select

        'Get the Typed Text and Find it in the list
        If cbo.Text <> "" Then
            sTypedText = cbo.Text
            iFoundIndex = cbo.FindString(sTypedText)

            'If we found the Typed Text in the list then Autocomplete
            If iFoundIndex >= 0 Then

                'Get the Item from the list (Return Type depends if Datasource was bound 
                ' or List Created)
                oFoundItem = cbo.Items(iFoundIndex)

                'Use the ListControl.GetItemText to resolve the Name in case the Combo 
                ' was Data bound
                sFoundText = cbo.GetItemText(oFoundItem)

                'Append then found text to the typed text to preserve case
                sAppendText = sFoundText.Substring(sTypedText.Length)
                cbo.Text = sTypedText & sAppendText

                'Select the Appended Text
                cbo.SelectionStart = sTypedText.Length
                cbo.SelectionLength = sAppendText.Length

            End If
        End If

    End Sub

    Public Sub AutoCompletarCombo_Leave(ByVal cbo As ComboBox)
        Dim iFoundIndex As Integer

        iFoundIndex = cbo.FindStringExact(cbo.Text)

        cbo.SelectedIndex = iFoundIndex

    End Sub

    Public Sub llenar()
        Dim Cn As New SqlConnection
        Dim da As New SqlDataAdapter
        Dim dt As New DataTable

        Try
            Cn.ConnectionString = Cadena
            Cn.Open()
        Catch ex As Exception
            Beep()
            MessageBox.Show("No se puede conectar a la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


        Try
            If nomp1 = "" Then
                With da
                    .SelectCommand = New SqlCommand("" & sp & "", Cn)
                    .SelectCommand.CommandType = CommandType.StoredProcedure
                End With
            ElseIf nomp2 = "" Then

                With da
                    .SelectCommand = New SqlCommand("" & sp & "", Cn)
                    .SelectCommand.CommandType = CommandType.StoredProcedure
                    .SelectCommand.Parameters.Add("@" & nomp1 & "", SqlDbType.VarChar).Value = param1
                End With
            ElseIf nomp3 = "" Then
                With da
                    .SelectCommand = New SqlCommand("" & sp & "", Cn)
                    .SelectCommand.CommandType = CommandType.StoredProcedure
                    .SelectCommand.Parameters.Add("@" & nomp1 & "", SqlDbType.VarChar).Value = param1
                    .SelectCommand.Parameters.Add("@" & nomp2 & "", SqlDbType.VarChar).Value = param2
                End With
            Else
                With da
                    .SelectCommand = New SqlCommand("" & sp & "", Cn)
                    .SelectCommand.CommandType = CommandType.StoredProcedure
                    .SelectCommand.Parameters.Add("@" & nomp1 & "", SqlDbType.VarChar).Value = param1
                    .SelectCommand.Parameters.Add("@" & nomp2 & "", SqlDbType.VarChar).Value = param2
                    .SelectCommand.Parameters.Add("@" & nomp3 & "", SqlDbType.VarChar).Value = param3
                End With
            End If
        Catch ex As Exception
            Beep()
            MessageBox.Show("No se puede ejecutar la consulta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Try
            Me.DataSource = Nothing
            da.Fill(dt)
            Me.DataSource = dt
            Me.ValueMember = dt.Columns(0).ColumnName
            Me.DisplayMember = dt.Columns(1).ColumnName
        Catch ex As System.Data.SqlClient.SqlException
            MsgBox(ex.Message)
        End Try

        da.Dispose()
        Cn.Close()
    End Sub

    Private Sub StoreCombo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        AutoCompletarCombo_KeyUp(Me, e)
    End Sub

    Private Sub StoreCombo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Leave
        If Me.SelectedItem Is Nothing Then
            Exit Sub
        Else
            AutoCompletarCombo_Leave(Me)
        End If

    End Sub
End Class

