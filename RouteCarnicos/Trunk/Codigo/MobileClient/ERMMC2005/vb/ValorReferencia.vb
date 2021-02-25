Imports System.Data.SqlServerCe
Imports Resco.Controls
Imports System.Xml
Imports System.IO

Public Class ValorReferencia

    ' Arreglo para acceder a las descripciones de los tipos (valores por referencia)
    Public Shared aValoresReferencia As New ArrayList

    Public Class Descripcion

        Protected sId As String
        Protected sCadena As String
        Protected sGrupo As String

        Public Property Id() As String
            Get
                Return sId
            End Get
            Set(ByVal Value As String)
                sId = Value
            End Set
        End Property
        Public Property Cadena() As String
            Get
                Return sCadena
            End Get
            Set(ByVal Value As String)
                sCadena = Value
            End Set
        End Property

        Public Property Grupo() As String
            Get
                Return sGrupo
            End Get
            Set(ByVal Value As String)
                sGrupo = Value
            End Set
        End Property

        Sub New(ByVal parsId As String, ByVal parsCadena As String, ByVal parsGrupo As String)
            Id = parsId
            Cadena = parsCadena
            Grupo = parsGrupo
        End Sub

    End Class

    Public Class Valor
        Protected sId As String
        Protected sCadena As String
        Public aLista As ArrayList

        Public Property Id() As String
            Get
                Return sId
            End Get
            Set(ByVal Value As String)
                sId = Value
            End Set
        End Property
        Public Property Cadena() As String
            Get
                Return sCadena
            End Get
            Set(ByVal Value As String)
                sCadena = Value
            End Set
        End Property

        Sub New(ByVal parsId As String)
            Id = parsId
            aLista = New ArrayList
        End Sub
    End Class

    Public Shared Function Llenar() As Boolean
        Try
            FormProcesando.PubSubInformar("Recuperando información del sistema", "Valores por referencia")
            ' Usar un DataTable para leer los datos
            Dim DataTableValores As DataTable
            Dim sConsultaSQL As String
            ' Recuperar los registros de las Vistas
            sConsultaSQL = "SELECT VARCodigo FROM ValorReferencia ORDER BY VARCodigo"
            DataTableValores = oDBApp.RealizarConsultaSQL(sConsultaSQL, "Valores")
            If DataTableValores.Rows.Count = 0 Then
                DataTableValores.Dispose()
                Exit Try
            End If
            ' Recuperar las descripciones
            Dim DataTableDescripciones As DataTable
            sConsultaSQL = "SELECT VARValor.VARCodigo, VARValor.VAVClave, VARValor.Grupo, Descripcion FROM VAVDescripcion inner join VARValor on  VARValor.VARCodigo = VAVDescripcion.VARCodigo and VARValor.VAVClave = VAVDescripcion.VAVClave ORDER BY VARValor.VARCodigo, VARValor.VAVClave "
            DataTableDescripciones = oDBApp.RealizarConsultaSQL(sConsultaSQL, "Descripciones")
            If DataTableDescripciones.Rows.Count = 0 Then
                DataTableValores.Dispose()
                DataTableDescripciones.Dispose()
                Exit Try
            End If
            ' DataRowView para buscar los diferentes valores
            Dim DataViewValores As New DataView(DataTableDescripciones, "", "VARCodigo", DataViewRowState.CurrentRows)
            Dim refDataRow As DataRow
            ' Recorrer la lista de valores para meterlos al arreglo
            aValoresReferencia.Clear()
            For Each refDataRow In DataTableValores.Rows
                With refDataRow
                    Dim oValor As New Valor(.Item("VARCodigo"))
                    Dim DataRowViewResultado() As DataRowView = DataViewValores.FindRows(oValor.Id)
                    If DataRowViewResultado.Length <> 0 Then
                        Dim refDataRowView As DataRowView
                        For Each refDataRowView In DataRowViewResultado
                            Dim oDescripcion As New Descripcion(refDataRowView("VAVClave"), refDataRowView("Descripcion"), refDataRowView("Grupo"))
                            oValor.aLista.Add(oDescripcion)
                        Next
                    End If
                    aValoresReferencia.Add(oValor)
                    DataRowViewResultado = Nothing
                End With
            Next
            DataTableValores.Dispose()
            DataTableDescripciones.Dispose()
            DataViewValores.Dispose()
            Return True
        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message, MsgBoxStyle.Critical, "Llenar")
        Catch ExcB As Exception
            MsgBox(ExcB.Message, MsgBoxStyle.Critical, "Llenar")
        End Try
        Return False
    End Function

    'Incluir Separado por comas las lista de TiposPago y Bancos que se desean incluir en el resultado. Si dichas cadenas esta vacias
    'se incluiran todos los valores
    'Public Shared Function RecuperarLista(ByVal parsVARCodigo As String, Optional ByVal parsIncluirVAVClave As String = "") As DataTable
    '    Dim sConsultaSQL As String = "SELECT VARValor.VAVClave, VAVDescripcion.Descripcion FROM VARValor "
    '    sConsultaSQL &= "INNER JOIN VAVDescripcion ON VARValor.VARCodigo = VAVDescripcion.VARCodigo AND VARValor.VAVClave = VAVDescripcion.VAVClave "
    '    sConsultaSQL &= "WHERE (VARValor.VARCodigo = '" & parsVARCodigo & "') "
    '    If parsIncluirVAVClave <> "" Then
    '        sConsultaSQL &= "AND VARValor.VAVClave in(" & parsIncluirVAVClave & ") "
    '    End If
    '    sConsultaSQL &= "ORDER BY convert( int, VARValor.VAVClave ) "

    '    Return oDBApp.RealizarConsultaSQL(sConsultaSQL, "VARDescripcion")
    'End Function
    Public Shared Function RecuperarListaArray(ByVal parsVARCodigo As String) As ArrayList
        Dim refValor As ValorReferencia.Valor
        For Each refValor In ValorReferencia.aValoresReferencia
            If refValor.Id = parsVARCodigo Then
                Return refValor.aLista.Clone
            End If
        Next
        Return Nothing
        'Return New ArrayList() {"<No válido>"}
    End Function

    Public Shared Function RecuperarListaArraySoloConGrupo(ByVal parsVARCodigo As String) As ArrayList
        Dim refValor As ValorReferencia.Valor
        Dim aRes As ArrayList
        For Each refValor In ValorReferencia.aValoresReferencia
            If refValor.Id = parsVARCodigo Then
                aRes = refValor.aLista.Clone()
                For i As Integer = 0 To aRes.Count - 1
                    If i >= aRes.Count Then
                        Exit For
                    End If
                    Dim refDescripcion As ValorReferencia.Descripcion = aRes(i)
                    If refDescripcion.Grupo = "" Then
                        aRes.Remove(refDescripcion)
                        If i >= aRes.Count Then
                            Exit For
                        End If
                        i = i - 1
                    End If
                Next
                Return aRes
            End If
        Next
        Return Nothing
        'Return New ArrayList() {"<No válido>"}
    End Function

    Public Shared Function RecuperarLista(ByVal parsVARCodigo As String, Optional ByVal parsIncluirVAVClave As ArrayList = Nothing) As ArrayList
        Dim aLista As ArrayList
        Dim refValor As ValorReferencia.Valor
        Dim refDescripcion As ValorReferencia.Descripcion
        For Each refValor In ValorReferencia.aValoresReferencia
            If refValor.Id = parsVARCodigo Then
                If Not parsIncluirVAVClave Is Nothing Then
                    For Each refDescripcion In refValor.aLista
                        If parsIncluirVAVClave.Contains(refDescripcion.Id) Then
                            If aLista Is Nothing Then
                                aLista = New ArrayList
                            End If
                            aLista.Add(refDescripcion)
                        End If
                    Next
                    Return aLista
                Else
                    Return refValor.aLista.Clone
                End If
            End If
        Next
        Return Nothing
    End Function


    Public Shared Function BuscarEquivalente(ByVal parsVARCodigo As String, ByVal parsVAVClave As String) As String
        Dim refValor As ValorReferencia.Valor
        Dim refDescripcion As ValorReferencia.Descripcion
        For Each refValor In ValorReferencia.aValoresReferencia
            If refValor.Id = parsVARCodigo Then
                For Each refDescripcion In refValor.aLista
                    If refDescripcion.Id = parsVAVClave Then
                        Return refDescripcion.Cadena
                    End If
                Next
            End If
        Next
        Return "<No válido>"
    End Function

    Public Shared Function BuscarEquivalente2(ByVal parsVARCodigo As String, ByVal parsVAVClave As String) As String
        Dim refValor As ValorReferencia.Valor
        Dim refDescripcion As ValorReferencia.Descripcion
        For Each refValor In ValorReferencia.aValoresReferencia
            If refValor.Id = parsVARCodigo Then
                For Each refDescripcion In refValor.aLista
                    If refDescripcion.Id = parsVAVClave Then
                        Return refDescripcion.Cadena
                    End If
                Next
            End If
        Next
        Return parsVAVClave
    End Function

    Public Shared Function RecuperaVARVGrupo(ByVal parsVARCodigo As String, ByVal paraGrupos As ArrayList) As ArrayList
        Dim aValoresRes As New ArrayList
        Try
            Dim refValor As ValorReferencia.Valor
            Dim refDescripcion As ValorReferencia.Descripcion
            For Each refValor In ValorReferencia.aValoresReferencia
                If refValor.Id = parsVARCodigo Then
                    For Each refDescripcion In refValor.aLista
                        If paraGrupos.Contains(IIf(IsDBNull(refDescripcion.Grupo), String.Empty, refDescripcion.Grupo)) Then
                            aValoresRes.Add(refDescripcion)
                        End If
                    Next
                End If
            Next
            Return aValoresRes
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return Nothing
    End Function

    Public Shared Function RecuperaVARVGrupoIds(ByVal parsVARCodigo As String, ByVal paraGrupos As ArrayList) As String
        Dim sValoresRes As String = String.Empty
        Try
            Dim refValor As ValorReferencia.Valor
            Dim refDescripcion As ValorReferencia.Descripcion
            For Each refValor In ValorReferencia.aValoresReferencia
                If refValor.Id = parsVARCodigo Then
                    For Each refDescripcion In refValor.aLista
                        If paraGrupos.Contains(IIf(IsDBNull(refDescripcion.Grupo), String.Empty, refDescripcion.Grupo)) Then
                            sValoresRes &= refDescripcion.Id & ","
                        End If
                    Next
                    If sValoresRes.Length > 0 Then
                        sValoresRes = Microsoft.VisualBasic.Left(sValoresRes, sValoresRes.Length - 1)
                    End If
                End If
            Next
            Return sValoresRes
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return String.Empty
    End Function

    'Igorada 
    Public Shared Function RecuperaVARVGrupoConSinGrupo(ByVal parsVARCodigo As String, ByVal paraGrupos As ArrayList) As ArrayList
        Dim aValoresRes As New ArrayList
        Try
            Dim refValor As ValorReferencia.Valor
            Dim refDescripcion As ValorReferencia.Descripcion
            For Each refValor In ValorReferencia.aValoresReferencia
                If refValor.Id = parsVARCodigo Then
                    For Each refDescripcion In refValor.aLista
                        If paraGrupos.Contains(IIf(IsDBNull(refDescripcion.Grupo), String.Empty, refDescripcion.Grupo)) Or IIf(IsDBNull(refDescripcion.Grupo), String.Empty, refDescripcion.Grupo.Trim()) = "" Then
                            aValoresRes.Add(refDescripcion)
                        End If
                    Next
                End If
            Next
            Return aValoresRes
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return Nothing
    End Function

    Public Shared Function RecuperaVARVNoGrupos(ByVal parsVARCodigo As String, ByVal paraGrupos As ArrayList) As ArrayList
        Dim aValoresRes As New ArrayList
        Try
            Dim refValor As ValorReferencia.Valor
            Dim refDescripcion As ValorReferencia.Descripcion
            For Each refValor In ValorReferencia.aValoresReferencia
                If refValor.Id = parsVARCodigo Then
                    For Each refDescripcion In refValor.aLista
                        If Not paraGrupos.Contains(IIf(IsDBNull(refDescripcion.Grupo), String.Empty, refDescripcion.Grupo)) Then
                            aValoresRes.Add(refDescripcion)
                        End If
                    Next
                End If
            Next
            Return aValoresRes
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return Nothing
    End Function


    Public Shared Function RecuperaGrupo(ByVal parsVARCodigo As String, ByVal parsVAVClave As Integer) As String
        Dim aValoresRes As New ArrayList
        Try
            Dim refValor As ValorReferencia.Valor
            Dim refDescripcion As ValorReferencia.Descripcion
            For Each refValor In ValorReferencia.aValoresReferencia
                If refValor.Id = parsVARCodigo Then
                    For Each refDescripcion In refValor.aLista
                        If refDescripcion.Id = parsVAVClave.ToString Then
                            Return refDescripcion.Grupo
                        End If
                    Next
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return Nothing
    End Function

End Class
