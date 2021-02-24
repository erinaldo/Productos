Imports Microsoft.VisualBasic
Imports System.Data
Imports System

Public Class Dia
    Inherits DBCentral.CDia

    Public Sub New()

    End Sub

    Public Sub New(ByVal parsNombre As String)
        sNombre = parsNombre
    End Sub

    Public Sub New(ByVal parsNombre As String, ByVal parsReferencia As String, ByVal pardFechaCaptura As Date)
        Nombre = parsNombre
        TipoEstado = DBCentral.TiposEstadosRegistros.Activo
        Referencia = parsReferencia
        FechaCaptura = pardFechaCaptura
    End Sub

    Public Function Recuperar() As Boolean
        Dim DataTableDia As DataTable
        DataTableDia = MobileClient.ConexionSQL.RealizarConsulta("SELECT Referencia,TipoEstado,FechaCaptura FROM Dia")
        If DataTableDia.Rows.Count > 0 Then
            With DataTableDia.Rows(0)
                Referencia = .Item("Referencia")
                TipoEstado = .Item("TipoEstado")
                FechaCaptura = .Item("FechaCaptura")
                'FechaVenta = .Item("FechaVenta")
                'FechaEntrega = .Item("FechaEntrega")
            End With
            Return True
        End If
        Return False
    End Function

    Public Function Guardar(ByVal sMUsuarioId As String) As Boolean
        Try
            Dim sComandoSQL As New System.Text.StringBuilder
            If Not Buscar() Then

                sComandoSQL.Append("INSERT INTO Dia(DiaClave,Referencia,Estado,FechaCaptura,")
                sComandoSQL.Append("MFechaHora,MUsuarioID) VALUES (")
                sComandoSQL.Append("'" & Me.Nombre & "',")
                sComandoSQL.Append("'" & Me.Referencia & "',")
                sComandoSQL.Append(Me.TipoEstado & ",")
                sComandoSQL.Append(General.UniFechaSQL(Me.FechaCaptura) & ",")
                sComandoSQL.Append(General.UniFechaSQL(Now) & ",")
                sComandoSQL.Append("'" & sMUsuarioId & "')")

                MobileClient.ConexionSQL.EjecutarComando(sComandoSQL.ToString)
                sComandoSQL = Nothing

                Return True
            End If
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function

    Public Function Buscar() As Boolean
        Dim DataTableDia As DataTable
        DataTableDia = MobileClient.ConexionSQL.RealizarConsulta("SELECT DiaClave FROM Dia where DiaClave='" & Me.Nombre & "'")
        If DataTableDia.Rows.Count > 0 Then
            Return True
        End If
        Return False
    End Function

    Private Function ActualizarTabla(ByVal parsUsuarioClave As String, ByRef refparDataTable As DataTable, ByRef refparoComando As SqlClient.SqlCommand, ByRef refparsMensaje As String) As Boolean
        Dim sComandoUpdate As String = String.Empty
        Dim sComandoInsert As String = String.Empty
        Dim sComandoInsertValores As String = String.Empty
        ' Cambios 23 Abril - Quitar esta variable
        'Dim sLlave As String
        ' /Cambios 23 Abril
        Dim sNombreTabla As String = refparDataTable.TableName
        If Not refparDataTable.PrimaryKey Is Nothing Then
            ' Agregar los parametros
            Dim refDataColumn As DataColumn
            refparoComando.Parameters.Clear()
            For Each refDataColumn In refparDataTable.Columns
                If sComandoUpdate = "" Then
                    sComandoUpdate = "UPDATE " & sNombreTabla & " SET "
                    sComandoInsert = "INSERT INTO " & sNombreTabla & " ("
                Else
                    sComandoUpdate &= ", "
                    sComandoInsert &= ", "
                    sComandoInsertValores &= ", "
                End If
                sComandoUpdate &= refDataColumn.ColumnName & " = @" & refDataColumn.ColumnName
                sComandoInsert &= refDataColumn.ColumnName
                sComandoInsertValores &= "@" & refDataColumn.ColumnName
            Next
            sComandoInsert &= ") VALUES (" & sComandoInsertValores & ")"
            Dim sCondicion As String = ""
            For Each refDataColumn In refparDataTable.PrimaryKey
                If sCondicion <> "" Then
                    sCondicion &= " AND "
                End If
                ' Cambios 23 Abril
                'If sLlave <> "" Then
                '    sLlave &= ", "
                'End If
                ' /Cambios 23 Abril
                sCondicion &= refDataColumn.ColumnName & " = @@" & refDataColumn.ColumnName
                ' Cambios 23 Abril
                'sLlave &= refDataColumn.ColumnName
                ' /Cambios 23 Abril
            Next
            ' Insertar los registros del Dataset en la base de datos
            Dim refDataRow As DataRow
            For Each refDataRow In refparDataTable.Rows
                ' Buscar primero si el registro ya existe
                refparoComando.Parameters.Clear()
                ' Cambios 23 Abril
                refparoComando.CommandText = "SELECT COUNT(*) AS TotalRegistros FROM " & sNombreTabla & " WHERE " & sCondicion
                ' /Cambios 23 Abril
                For Each refDataColumn In refparDataTable.PrimaryKey
                    Dim oParam As New SqlClient.SqlParameter("@@" & refDataColumn.ColumnName, refDataRow(refDataColumn.ColumnName))
                    refparoComando.Parameters.Add(oParam)
                Next
                Dim DataSetExiste As New DataSet
                Dim iNumRegs As Integer = refparoComando.ExecuteScalar()
                refparoComando.Parameters.Clear()
                If iNumRegs = 0 Then
                    ' No existe, agregarlo
                    refparoComando.CommandText = sComandoInsert
                Else
                    ' Ya existe, actualizarlo
                    refparoComando.CommandText = sComandoUpdate & " WHERE " & sCondicion
                End If
                ' Colocar los valores del registro en los parametros
                For Each refDataColumn In refparDataTable.Columns
                    Dim oParam As New SqlClient.SqlParameter("@" & refDataColumn.ColumnName, refDataRow.Item(refDataColumn.ColumnName))
                    refparoComando.Parameters.Add(oParam)
                Next
                ' Agregar los parametros de la condicion si es un comando UPDATE
                If iNumRegs <> 0 Then
                    For Each refDataColumn In refparDataTable.PrimaryKey
                        Dim oParam As New SqlClient.SqlParameter("@@" & refDataColumn.ColumnName, refDataRow.Item(refDataColumn.ColumnName))
                        refparoComando.Parameters.Add(oParam)
                    Next
                End If
                ' Agregar los datos
                refparoComando.ExecuteNonQuery()
            Next
        End If
        Return True
    End Function

    Private Function LlenarTabla(ByVal parsUsuarioClave As String, ByRef refparDataTable As DataTable, ByRef refparoComando As SqlClient.SqlCommand, ByRef parsNuevaVisitaClave As String, ByRef refparsMensaje As String) As Boolean
        Dim sComando As String
        Dim sNombreCampo As String
        Dim sNombreTabla As String = Mid(refparDataTable.TableName, 3, Len(refparDataTable.TableName))


        ' Formar el encabezado del comando
        sComando = "INSERT INTO " & sNombreTabla & " ("
        Dim j As Integer
        For j = 0 To refparDataTable.Columns.Count - 1
            sNombreCampo = refparDataTable.Columns(j).ColumnName
            sComando &= sNombreCampo
            If j < refparDataTable.Columns.Count - 1 Then
                sComando &= ", "
            End If
        Next
        sComando &= ") VALUES ("

        ' Insertar los registros del Dataset en la base de datos
        Dim refDataRow As DataRow
        Dim refDataColumn As DataColumn
        Dim k As System.Type
        For Each refDataRow In refparDataTable.Rows
            refparoComando.CommandText = sComando
            For Each refDataColumn In refparDataTable.Columns
                Select Case LCase(refDataColumn.ColumnName)
                    'Case "visitaclave"
                    '    If sNombreTabla.ToUpper <> "TRANSPROD" Then
                    '        refparoComando.CommandText &= "'" & parsNuevaVisitaClave & "'"
                    '    Else
                    '        refparoComando.CommandText &= "'" & refDataRow.Item("VisitaClave") & "'"
                    '    End If
                    'Case "visitaclave1"
                    '    refparoComando.CommandText &= "'" & parsNuevaVisitaClave & "'"
                    Case "mfechahora"
                        If refDataRow.IsNull("mfechahora") Then
                            refparoComando.CommandText &= General.UniFechaSQL(Now)
                        Else
                            refparoComando.CommandText &= General.UniFechaSQL(refDataRow.Item("MFechaHora"))
                        End If
                    Case "musuarioid"
                        If refDataRow.IsNull("musuarioid") Then
                            refparoComando.CommandText &= "'" & parsUsuarioClave & "'"
                        Else
                            refparoComando.CommandText &= "'" & refDataRow.Item("MUsuarioID") & "'"
                        End If
                    Case Else
                        k = refDataColumn.DataType()
                        Select Case k.Name
                            Case "String"
                                If refDataRow.IsNull(refDataColumn.ColumnName) Then
                                    refparoComando.CommandText &= "NULL"
                                Else
                                    refparoComando.CommandText &= "'" & RTrim(refDataRow(refDataColumn.ColumnName)) & "'"
                                End If
                            Case "Boolean"
                                If refDataRow.IsNull(refDataColumn.ColumnName) Then
                                    refparoComando.CommandText &= "NULL"
                                Else
                                    If LCase(RTrim(refDataRow(refDataColumn.ColumnName))) = "true" Then
                                        refparoComando.CommandText &= "1"
                                    Else
                                        refparoComando.CommandText &= "0"
                                    End If
                                End If
                            Case "DateTime"
                                If refDataRow.IsNull(refDataColumn.ColumnName) Then
                                    refparoComando.CommandText &= "NULL"
                                Else
                                    refparoComando.CommandText &= General.UniFechaSQL(refDataRow(refDataColumn.ColumnName))
                                End If
                            Case Else
                                If refDataRow.IsNull(refDataColumn.ColumnName) Then
                                    refparoComando.CommandText &= "NULL"
                                Else
                                    Dim sValor As New Text.StringBuilder(RTrim(refDataRow(refDataColumn.ColumnName)))
                                    ' Cambiar las comas decimales por los puntos decimales
                                    sValor.Replace(",", ".")
                                    refparoComando.CommandText &= sValor.ToString
                                End If
                        End Select
                        If UCase(refDataColumn.ColumnName) = "VISITACLAVE" And sNombreTabla.ToUpper = "VISITA" Then
                            parsNuevaVisitaClave = refDataRow.Item("VisitaClave")
                        End If
                End Select
                refparoComando.CommandText &= ", "
            Next
            If sNombreTabla.ToUpper = "TRANSPROD" Then
                Dim sAuxComando As String = refparoComando.CommandText
                refparoComando.CommandText = "DELETE FROM TRPPrp where TransProdId = '" & refDataRow("TransProdId") & "'"
                refparoComando.ExecuteNonQuery()
                refparoComando.CommandText = "DELETE FROM TPDImpuesto where TransProdId = '" & refDataRow("TransProdId") & "'"
                refparoComando.ExecuteNonQuery()
                refparoComando.CommandText = "DELETE FROM TransProdDescuento where TransProdId = '" & refDataRow("TransProdId") & "'"
                refparoComando.ExecuteNonQuery()
                refparoComando.CommandText = "DELETE FROM ProductoPrestamo where TransProdId = '" & refDataRow("TransProdId") & "'"
                refparoComando.ExecuteNonQuery()
                refparoComando.CommandText = "DELETE FROM TransProdDetalle where TransProdId = '" & refDataRow("TransProdId") & "'"
                refparoComando.ExecuteNonQuery()
                refparoComando.CommandText = "DELETE FROM TransProd where TransProdId = '" & refDataRow("TransProdId") & "'"
                refparoComando.ExecuteNonQuery()
                refparoComando.CommandText = sAuxComando
            End If
            ' Quitar la última coma y poner un paréntesis
            refparoComando.CommandText = Mid(refparoComando.CommandText, 1, Len(refparoComando.CommandText) - 2) & ")"
            ' Agregar los datos
            refparoComando.ExecuteNonQuery()
        Next
        Return True
    End Function
End Class
