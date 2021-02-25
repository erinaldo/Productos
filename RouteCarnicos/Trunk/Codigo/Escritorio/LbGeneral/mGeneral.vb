Imports System.IO

Public Module mGeneral
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Llena una columna especifica en  un control GridEX de las librerias Janus con los 
    ''' valores por referencia correspondientesal codigo dado y dependiendo de los valores 
    ''' de parámetro como el Lenguaje, Grupo, Tipo de Dato, etc.
    ''' </summary>
    ''' <param name="prColumna"></param>
    ''' <param name="pvVARCodigo"></param>
    ''' <param name="ValorDefault"></param>
    ''' <param name="pvaListaExcluidos"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[jvazquez]	03/05/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub LlenarColumna(ByRef prColumna As Janus.Windows.GridEX.GridEXColumn, ByVal pvVARCodigo As String, Optional ByVal ValorDefault As Object = Nothing, Optional ByVal pvaListaExcluidos() As String = Nothing)
        Dim vlValorReferencia As New BASVARLOG.cValorReferencia
        Dim vlVARDataSet As New DataSet
        Dim vlVARDataRow As DataRow
        Dim vlParametros As New cParametros

        Try
            vlVARDataSet = vlValorReferencia.dsDatos.Recuperar("VARCodigo='" + pvVARCodigo + "'")

            If vlVARDataSet.Tables("ValorReferencia").Rows.Count = 0 Then
                Exit Sub
            End If

            prColumna.ValueList.Clear()
            vlVARDataRow = vlVARDataSet.Tables("ValorReferencia").Rows(0)

            For Each vlVAVDataRow As DataRow In vlVARDataRow.GetChildRows("ValorReferenciaVARValor")
                For Each vlVADDataRow As DataRow In vlVAVDataRow.GetChildRows("VARValorVAVDescripcion")
                    Dim vlItem As New Janus.Windows.GridEX.GridEXValueListItem
                    If vlVADDataRow("VADTipoLenguaje") = cParametros.Lenguaje Then
                        If pvaListaExcluidos Is Nothing OrElse Array.IndexOf(pvaListaExcluidos, vlVADDataRow("VAVClave")) < 0 Then
                            vlItem.Text = vlVADDataRow("Descripcion")
                            vlItem.Value = vlVADDataRow("VAVClave")
                            prColumna.ValueList.Add(vlItem)
                        End If
                    End If
                Next
            Next

            If vlVARDataRow("TipoNulo") = 1 Then
                Dim vlItem As New Janus.Windows.GridEX.GridEXValueListItem
                vlItem.Text = "<Ninguno>"
                If vlVARDataRow("TipoDato") = "S" Then
                    vlItem.Value = ""
                ElseIf vlVARDataRow("TipoDato") = "N" Then
                    vlItem.Value = "0"
                End If
                prColumna.ValueList.Add(vlItem)
            End If

            If IsNothing(ValorDefault) = False Then
                prColumna.DefaultValue = ValorDefault
            End If
        Catch ex As LbControlError.cError
            Throw ex
        End Try
    End Sub

    Public Sub LlenarColumnaActivos(ByRef prColumna As Janus.Windows.GridEX.GridEXColumn, ByVal pvVARCodigo As String, Optional ByVal ValorDefault As Object = Nothing, Optional ByVal pvaListaExcluidos() As String = Nothing)
        Dim vlValorReferencia As New BASVARLOG.cValorReferencia
        Dim vlVARDataSet As New DataSet
        Dim vlVARDataRow As DataRow
        Dim vlParametros As New cParametros

        Try
            vlVARDataSet = vlValorReferencia.dsDatos.Recuperar("VARCodigo='" + pvVARCodigo + "'")

            If vlVARDataSet.Tables("ValorReferencia").Rows.Count = 0 Then
                Exit Sub
            End If

            prColumna.ValueList.Clear()
            vlVARDataRow = vlVARDataSet.Tables("ValorReferencia").Rows(0)
            For Each vlVAVDataRow As DataRow In vlVARDataRow.GetChildRows("ValorReferenciaVARValor")
                If vlVAVDataRow("Estado") = 1 Then
                    For Each vlVADDataRow As DataRow In vlVAVDataRow.GetChildRows("VARValorVAVDescripcion")
                        Dim vlItem As New Janus.Windows.GridEX.GridEXValueListItem
                        If vlVADDataRow("VADTipoLenguaje") = cParametros.Lenguaje Then
                            If pvaListaExcluidos Is Nothing OrElse Array.IndexOf(pvaListaExcluidos, vlVADDataRow("VAVClave")) < 0 Then
                                vlItem.Text = vlVADDataRow("Descripcion")
                                vlItem.Value = vlVADDataRow("VAVClave")
                                prColumna.ValueList.Add(vlItem)
                            End If
                        End If
                    Next
                End If
            Next

            If vlVARDataRow("TipoNulo") = 1 Then
                Dim vlItem As New Janus.Windows.GridEX.GridEXValueListItem
                vlItem.Text = "<Ninguno>"
                If vlVARDataRow("TipoDato") = "S" Then
                    vlItem.Value = ""
                ElseIf vlVARDataRow("TipoDato") = "N" Then
                    vlItem.Value = "0"
                End If
                prColumna.ValueList.Add(vlItem)
            End If

            If IsNothing(ValorDefault) = False Then
                prColumna.DefaultValue = ValorDefault
            End If
        Catch ex As LbControlError.cError
            Throw ex
        End Try
    End Sub

    'Llena la columna con el valor por referencia indicado pero solo si tiene un Grupo relacionado.
    Public Sub LlenarColumnaSoloConGrupo(ByRef prColumna As Janus.Windows.GridEX.GridEXColumn, ByVal pvVARCodigo As String, Optional ByVal ValorDefault As Object = Nothing)
        Dim vlValorReferencia As New BASVARLOG.cValorReferencia
        Dim vlVARDataSet As New DataSet
        Dim vlVARDataRow As DataRow
        Dim vlParametros As New cParametros

        Try
            vlVARDataSet = vlValorReferencia.dsDatos.Recuperar("VARCodigo='" + pvVARCodigo + "'")

            If vlVARDataSet.Tables("ValorReferencia").Rows.Count = 0 Then
                Exit Sub
            End If

            prColumna.ValueList.Clear()
            vlVARDataRow = vlVARDataSet.Tables("ValorReferencia").Rows(0)

            For Each vlVAVDataRow As DataRow In vlVARDataRow.GetChildRows("ValorReferenciaVARValor")
                For Each vlVADDataRow As DataRow In vlVAVDataRow.GetChildRows("VARValorVAVDescripcion")
                    Dim vlItem As New Janus.Windows.GridEX.GridEXValueListItem
                    If vlVADDataRow("VADTipoLenguaje") = cParametros.Lenguaje Then
                        If vlVAVDataRow("Grupo") <> "" Then
                            vlItem.Text = vlVADDataRow("Descripcion")
                            vlItem.Value = vlVADDataRow("VAVClave")
                            prColumna.ValueList.Add(vlItem)
                        End If
                    End If
                Next
            Next

            If vlVARDataRow("TipoNulo") = 1 Then
                Dim vlItem As New Janus.Windows.GridEX.GridEXValueListItem
                vlItem.Text = "<Ninguno>"
                If vlVARDataRow("TipoDato") = "S" Then
                    vlItem.Value = ""
                ElseIf vlVARDataRow("TipoDato") = "N" Then
                    vlItem.Value = "0"
                End If
                prColumna.ValueList.Add(vlItem)
            End If

            If IsNothing(ValorDefault) = False Then
                prColumna.DefaultValue = ValorDefault
            End If
        Catch ex As LbControlError.cError
            Throw ex
        End Try
    End Sub
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Llena una columna especifica en  un control GridEX de las librerias Janus con los 
    ''' valores por referencia correspondientesal codigo dado y el grupo de valores por 
    ''' referencia especificados, dependiendo de los valores 
    ''' de parámetro como el Lenguaje, Tipo de Dato, etc.
    ''' </summary>
    ''' <param name="prColumna"></param>
    ''' <param name="pvVARCodigo"></param>
    ''' <param name="ValorDefault"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[jvazquez]	03/05/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub LlenarColumnaGrupo(ByRef prColumna As Janus.Windows.GridEX.GridEXColumn, ByVal pvVARCodigo As String, ByVal pvGrupo As String, Optional ByVal ValorDefault As Object = Nothing)
        Dim vlValorReferencia As New BASVARLOG.cValorReferencia
        Dim vlVARDataSet As New DataSet
        Dim vlVARDataRow As DataRow
        Dim vlParametros As New cParametros

        Try
            vlVARDataSet = vlValorReferencia.dsDatos.Recuperar("VARCodigo='" + pvVARCodigo + "'")

            If vlVARDataSet.Tables("ValorReferencia").Rows.Count = 0 Then
                Exit Sub
            End If

            prColumna.ValueList.Clear()
            vlVARDataRow = vlVARDataSet.Tables("ValorReferencia").Rows(0)
            For Each vlVAVDataRow As DataRow In vlVARDataRow.GetChildRows("ValorReferenciaVARValor")
                For Each vlVADDataRow As DataRow In vlVAVDataRow.GetChildRows("VARValorVAVDescripcion")
                    Dim vlVAVdt As DataRow = vlVADDataRow.GetParentRow("VARValorVAVDescripcion")
                    If vlVAVdt("Grupo") = pvGrupo Then
                        Dim vlItem As New Janus.Windows.GridEX.GridEXValueListItem
                        If vlVADDataRow("VADTipoLenguaje") = cParametros.Lenguaje Then
                            vlItem.Text = vlVADDataRow("Descripcion")
                            vlItem.Value = vlVADDataRow("VAVClave")
                            prColumna.ValueList.Add(vlItem)
                        End If
                    End If
                Next
            Next

            If vlVARDataRow("TipoNulo") = 1 Then
                Dim vlItem As New Janus.Windows.GridEX.GridEXValueListItem
                vlItem.Text = "<Ninguno>"
                If vlVARDataRow("TipoDato") = "S" Then
                    vlItem.Value = ""
                ElseIf vlVARDataRow("TipoDato") = "N" Then
                    vlItem.Value = "0"
                End If
                prColumna.ValueList.Add(vlItem)
            End If

            If IsNothing(ValorDefault) = False Then
                prColumna.DefaultValue = ValorDefault
            End If
        Catch ex As LbControlError.cError
            Throw ex
        End Try
    End Sub
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Llena una columna especifica en  un control GridEX de las librerias Janus con los 
    ''' valores por referencia correspondientesal codigo dado y el grupo de valores por 
    ''' referencia especificados, dependiendo de los valores 
    ''' de parámetro como el Lenguaje, Tipo de Dato, etc. Incluye tambien el campo Grupo de la tabla 
    ''' de Valores por Referencia
    ''' </summary>
    ''' <param name="prColumna"></param>
    ''' <param name="pvVARCodigo"></param>
    ''' <param name="ValorDefault"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[jvazquez]	03/05/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub LlenarColumnaConGrupo(ByRef prColumna As Janus.Windows.GridEX.GridEXColumn, ByVal pvVARCodigo As String, Optional ByVal ValorDefault As Object = Nothing)
        Dim vlValorReferencia As New BASVARLOG.cValorReferencia
        Dim vlVARDataSet As New DataSet
        Dim vlVARDataRow As DataRow
        Dim vlParametros As New cParametros

        Try
            vlVARDataSet = vlValorReferencia.dsDatos.Recuperar("VARCodigo='" + pvVARCodigo + "'")

            If vlVARDataSet.Tables("ValorReferencia").Rows.Count = 0 Then
                Exit Sub
            End If

            prColumna.ValueList.Clear()
            vlVARDataRow = vlVARDataSet.Tables("ValorReferencia").Rows(0)

            For Each vlVAVDataRow As DataRow In vlVARDataRow.GetChildRows("ValorReferenciaVARValor")
                Dim vlItem As New Janus.Windows.GridEX.GridEXValueListItem
                vlItem.Text = vlVAVDataRow("Grupo")
                vlItem.Value = vlVAVDataRow("VAVClave")
                prColumna.ValueList.Add(vlItem)
            Next

            If vlVARDataRow("TipoNulo") = 1 Then
                Dim vlItem As New Janus.Windows.GridEX.GridEXValueListItem
                vlItem.Text = "<Ninguno>"
                If vlVARDataRow("TipoDato") = "S" Then
                    vlItem.Value = ""
                ElseIf vlVARDataRow("TipoDato") = "N" Then
                    vlItem.Value = "0"
                End If
                prColumna.ValueList.Add(vlItem)
            End If

            If IsNothing(ValorDefault) = False Then
                prColumna.DefaultValue = ValorDefault
            End If
        Catch ex As LbControlError.cError
            Throw ex
        End Try
    End Sub
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Carga los valores por fererencia definidos por el código dado a un control 
    ''' ComboBox de las  librerias Janus.
    ''' </summary>
    ''' <param name="prComboBox"></param>
    ''' <param name="pvVARCodigo"></param>
    ''' <param name="ValorDefault"></param>
    ''' <param name="pvaListaExcluidos"></param>
    ''' <remarks>
    ''' Puede definirse un valor por default de entre los valores cargados y proporcionarse 
    ''' una lista de valores que se desean excluir.
    ''' </remarks>
    ''' <history>
    ''' 	[jvazquez]	03/05/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub LlenarComboBox(ByRef prComboBox As Janus.Windows.EditControls.UIComboBox, ByVal pvVARCodigo As String, Optional ByVal ValorDefault As Object = Nothing, Optional ByVal pvaListaExcluidos() As String = Nothing)
        Dim vlValorReferencia As New BASVARLOG.cValorReferencia
        Dim vlVARDataSet As New DataSet
        Dim vlVARDataRow As DataRow
        Dim vlParametros As New cParametros

        Try
            vlVARDataSet = vlValorReferencia.dsDatos.Recuperar("VARCodigo='" + pvVARCodigo + "'")

            If vlVARDataSet.Tables("ValorReferencia").Rows.Count = 0 Then
                Exit Sub
            End If

            vlVARDataRow = vlVARDataSet.Tables("ValorReferencia").Rows(0)
            prComboBox.DataSource = Nothing
            prComboBox.Items.Clear()
            For Each vlVAVDataRow As DataRow In vlVARDataRow.GetChildRows("ValorReferenciaVARValor")
                For Each vlVADDataRow As DataRow In vlVAVDataRow.GetChildRows("VARValorVAVDescripcion")
                    Dim vlItem As New Janus.Windows.EditControls.UIComboBoxItem

                    If vlVADDataRow("VADTipoLenguaje") = cParametros.Lenguaje Then
                        If pvaListaExcluidos Is Nothing OrElse Array.IndexOf(pvaListaExcluidos, vlVADDataRow("VAVClave")) < 0 Then
                            vlItem.Text = vlVADDataRow("Descripcion")
                            vlItem.Value = vlVADDataRow("VAVClave")
                            prComboBox.Items.Add(vlItem)
                        End If
                    End If
                Next
            Next

            If vlVARDataRow("TipoNulo") = 1 Then
                Dim vlItem As New Janus.Windows.EditControls.UIComboBoxItem
                vlItem.Text = "<Ninguno>"
                If vlVARDataRow("TipoDato") = "S" Then
                    vlItem.Value = ""
                ElseIf vlVARDataRow("TipoDato") = "N" Then
                    vlItem.Value = "0"
                End If
                prComboBox.Items.Add(vlItem)
            End If
            If prComboBox.Items.Count > 0 AndAlso IsNothing(ValorDefault) = False Then
                prComboBox.SelectedItem = prComboBox.Items(ValorDefault)
            End If
            'With prComboBox
            '.DataSource = vlItems.Items
            'If vlItems.Items.Count > 0 Then
            '    .ValueMember = "Value"
            '    .DisplayMember = "Text"
            '    If IsNothing(ValorDefault) = False Then
            '        .SelectedItem = .Items(ValorDefault)
            '    End If
            'End If
            'End With
        Catch ex As LbControlError.cError
            Throw ex
        End Try
    End Sub
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Carga las descripciones de los grupos de los valores por fererencia definidos por el código dado a un control 
    ''' ComboBox de las  librerias Janus.
    ''' </summary>
    ''' <param name="prComboBox"></param>
    ''' <param name="pvVARCodigo"></param>
    ''' <param name="ValorDefault"></param>
    ''' <param name="pvaListaExcluidos"></param>
    ''' <remarks>
    ''' Puede definirse un valor por default de entre los valores cargados y proporcionarse 
    ''' una lista de valores que se desean excluir.
    ''' </remarks>
    ''' <history>
    ''' 	[jvazquez]	03/05/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub LlenarComboBoxConGrupos(ByRef prComboBox As Janus.Windows.EditControls.UIComboBox, ByVal pvVARCodigo As String, Optional ByVal ValorDefault As Object = Nothing, Optional ByVal pvaListaExcluidos() As String = Nothing)
        Dim vlValorReferencia As New BASVARLOG.cValorReferencia
        Dim vlVARDataSet As New DataSet
        Dim vlVARDataRow As DataRow
        Dim vlParametros As New cParametros

        Try
            vlVARDataSet = vlValorReferencia.dsDatos.Recuperar("VARCodigo='" + pvVARCodigo + "'")

            If vlVARDataSet.Tables("ValorReferencia").Rows.Count = 0 Then
                Exit Sub
            End If

            prComboBox.DataSource = Nothing
            prComboBox.Items.Clear()
            vlVARDataRow = vlVARDataSet.Tables("ValorReferencia").Rows(0)

            For Each vlVAVDataRow As DataRow In vlVARDataRow.GetChildRows("ValorReferenciaVARValor")
                Dim vlItem As New Janus.Windows.EditControls.UIComboBoxItem
                If Not prComboBox.Items.Contains(vlVAVDataRow("Grupo")) Then
                    vlItem.Text = vlVAVDataRow("Grupo")
                    vlItem.Value = vlVAVDataRow("Grupo")
                    prComboBox.Items.Add(vlItem)
                End If
            Next

            If vlVARDataRow("TipoNulo") = 1 Then
                Dim vlItem As New Janus.Windows.EditControls.UIComboBoxItem
                vlItem.Text = "<Ninguno>"
                If vlVARDataRow("TipoDato") = "S" Then
                    vlItem.Value = ""
                ElseIf vlVARDataRow("TipoDato") = "N" Then
                    vlItem.Value = "0"
                End If
                prComboBox.Items.Add(vlItem)
            End If


            If prComboBox.Items.Count > 0 AndAlso IsNothing(ValorDefault) = False Then
                prComboBox.SelectedItem = prComboBox.Items(ValorDefault)
            End If

        Catch ex As LbControlError.cError
            Throw ex
        End Try
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    '''     Funcion para obtener una cadena con la descripcion del valor por referencia
    ''' </summary>
    ''' <param name="pvVarCodigo"></param>
    ''' <param name="pvVAVClave"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[jpacheco]	12/06/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function ClaveDescripcionVARValor(ByVal pvVarCodigo As String, ByVal pvVAVClave As String) As String

        Dim vlValorReferencia As New BASVARLOG.cValorReferencia
        Dim vlVARDataSet As New DataSet
        Dim vlVARDataRow As DataRow
        Dim vlParametros As New cParametros

        Try
            vlVARDataSet = vlValorReferencia.dsDatos.Recuperar("VARCodigo='" + pvVarCodigo + "'")

            If vlVARDataSet.Tables("ValorReferencia").Rows.Count = 0 Then
                Return Nothing
            End If

            vlVARDataRow = vlVARDataSet.Tables("ValorReferencia").Rows(0)

            For Each vlVAVDataRow As DataRow In vlVARDataRow.GetChildRows("ValorReferenciaVARValor")
                For Each vlVADDataRow As DataRow In vlVAVDataRow.GetChildRows("VARValorVAVDescripcion")

                    If vlVADDataRow("VADTipoLenguaje") = cParametros.Lenguaje And vlVADDataRow("VAVClave") = pvVAVClave Then

                        Return vlVADDataRow("Descripcion")

                    End If
                Next
            Next

        Catch ex As Exception
            Throw
        End Try

        Return ""

    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    '''   Función que regresa un array de los valores de un valor por referencia 
    '''   filtrado por el grupo
    ''' </summary>
    ''' <param name="pvVarCodigo">Codigo del valor referencia</param>
    ''' <param name="pvGrupo">Grupo para realizar el filtro</param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[jpacheco]	12/06/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function ValoresDescripcionVARValor(ByVal pvVarCodigo As String, ByVal pvGrupo As String) As Hashtable

        Dim vlValorReferencia As New BASVARLOG.cValorReferencia
        Dim vlVARDataSet As New DataSet
        Dim vlVARDataRow As DataRow
        Dim vlParametros As New cParametros
        Dim vlDatos As New Hashtable

        Try
            vlVARDataSet = vlValorReferencia.dsDatos.Recuperar("VARCodigo='" + pvVarCodigo + "'")

            If vlVARDataSet.Tables("ValorReferencia").Rows.Count = 0 Then
                Return vlDatos
                Exit Function
            End If

            vlVARDataRow = vlVARDataSet.Tables("ValorReferencia").Rows(0)

            For Each vlVAVDataRow As DataRow In vlVARDataRow.GetChildRows("ValorReferenciaVARValor")

                If UCase(vlVAVDataRow("Grupo")) = pvGrupo.ToUpper Then

                    For Each vlVADDataRow As DataRow In vlVAVDataRow.GetChildRows("VARValorVAVDescripcion")

                        If vlVADDataRow("VADTipoLenguaje") = cParametros.Lenguaje Then

                            vlDatos.Add(vlVADDataRow("VAVClave"), vlVADDataRow("Descripcion"))

                        End If

                    Next

                End If

            Next

        Catch ex As Exception
            Throw
        End Try

        Return vlDatos

    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Carga los valores por fererencia definidos por el código dado a un control 
    ''' ComboBox de las  librerias Janus.
    ''' </summary>
    ''' <param name="prComboBox"></param>
    ''' <param name="pvVARCodigo"></param>
    ''' <param name="ValorDefault"></param>
    ''' <param name="pvaListaExcluidos"></param>
    ''' <remarks>
    ''' Puede definirse un valor por default de entre los valores cargados y proporcionarse 
    ''' una lista de valores que se desean excluir.
    ''' Muestra como TextMember a la descripcion del valor por referencia y como ValueMember la clave 
    ''' del mismo
    ''' </remarks>
    ''' <history>
    ''' 	[jvazquez]	03/05/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub LlenarComboBoxConGrupo(ByRef prComboBox As Janus.Windows.EditControls.UIComboBox, ByVal pvVARCodigo As String, ByVal pvGrupo As String, Optional ByVal ValorDefault As Object = Nothing, Optional ByVal pvaListaExcluidos() As String = Nothing)
        Dim vlItems As New Janus.Windows.EditControls.UIComboBox
        Dim vlValorReferencia As New BASVARLOG.cValorReferencia
        Dim vlVARDataSet As New DataSet
        Dim vlVARDataRow As DataRow
        Dim vlParametros As New cParametros

        Try
            vlVARDataSet = vlValorReferencia.dsDatos.Recuperar("VARCodigo='" + pvVARCodigo + "'")

            If vlVARDataSet.Tables("ValorReferencia").Rows.Count = 0 Then
                Exit Sub
            End If

            vlVARDataRow = vlVARDataSet.Tables("ValorReferencia").Rows(0)

            For Each vlVAVDataRow As DataRow In vlVARDataRow.GetChildRows("ValorReferenciaVARValor")
                For Each vlVADDataRow As DataRow In vlVAVDataRow.GetChildRows("VARValorVAVDescripcion")
                    Dim vlItem As New Janus.Windows.EditControls.UIComboBoxItem
                    If vlVADDataRow("VADTipoLenguaje") = cParametros.Lenguaje Then

                        If pvGrupo = "" OrElse (vlVAVDataRow("Grupo") = pvGrupo) Then

                            If pvaListaExcluidos Is Nothing OrElse Array.IndexOf(pvaListaExcluidos, vlVADDataRow("VAVClave")) < 0 Then
                                vlItem.Text = vlVADDataRow("Descripcion")
                                vlItem.Value = vlVADDataRow("VAVClave")
                                vlItems.Items.Add(vlItem)
                            End If

                        End If

                    End If
                Next
            Next

            If vlVARDataRow("TipoNulo") = 1 Then
                Dim vlItem As New Janus.Windows.EditControls.UIComboBoxItem
                vlItem.Text = "<Ninguno>"
                If vlVARDataRow("TipoDato") = "S" Then
                    vlItem.Value = ""
                ElseIf vlVARDataRow("TipoDato") = "N" Then
                    vlItem.Value = "0"
                End If
                vlItems.Items.Add(vlItem)
            End If

            With prComboBox
                .DataSource = vlItems.Items
                If vlItems.Items.Count > 0 Then
                    .ValueMember = "Value"
                    .DisplayMember = "Text"
                    If IsNothing(ValorDefault) = False Then
                        .SelectedItem = .Items(ValorDefault)
                    End If
                End If
            End With
        Catch ex As LbControlError.cError
            Throw ex
        End Try
    End Sub
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Verifica si un objeto es un valor nulo de la base de datos
    ''' </summary>
    ''' <param name="pvObj"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' Si el objeto es igual a System.DBNull retorna Nothing, de lo contrario
    ''' regresa al objeto mismo
    ''' </remarks>
    ''' <history>
    ''' 	[jvazquez]	03/05/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function ChkDbNull(ByVal pvObj As Object) As Object
        If TypeOf pvObj Is System.DBNull Then
            Return Nothing
        Else
            Return pvObj
        End If
    End Function
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Abre y analiza el archiv de configuración de la aplicación y regresa la linea en la que se licaliza en parámetro dado
    ''' </summary>
    ''' <param name="pvParametro"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[jvazquez]	03/05/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function ReadIni(ByVal pvParametro As String) As String
        Dim vlLineData As String = ""
        Dim vlSR As StreamReader

        Try
            vlSR = New StreamReader("AplBase.ini")
        Catch ex As Exception
            Return Nothing
        End Try

        Do
            If vlLineData = "[" + pvParametro + "]" Then
                vlLineData = vlSR.ReadLine()
                vlSR.Close()
                Return vlLineData
            End If
            vlLineData = vlSR.ReadLine()
        Loop Until vlLineData Is Nothing
        vlSR.Close()
        Return Nothing
    End Function

    Public Function LlenarConfiguracionGrid(ByVal pvComponente As String, ByVal pvForma As String, ByRef prGrid As Janus.Windows.GridEX.GridEX, ByVal pvTabla As String) As Boolean
        Dim vlUsuario As New BASUSULOG.cUsuario
        Dim vlParametros As New lbGeneral.cParametros
        Dim vlUsuarioId As String = cParametros.UsuarioID
        Dim vlMensaje As New BASMENLOG.CMensaje

        prGrid.Tables(pvTabla).Caption = vlMensaje.RecuperarDescripcion("C" & prGrid.Tables(pvTabla).Key)
        If vlUsuario.ConfiguraGrid.Tabla.Existe(vlUsuarioId, pvComponente, pvForma, prGrid.Name, pvTabla) Then
            For Each vlColumna As Janus.Windows.GridEX.GridEXColumn In prGrid.Tables(pvTabla).Columns
                If vlUsuario.ConfiguraGrid.CGRValor.Existe(vlUsuarioId, pvComponente, pvForma, prGrid.Name, pvTabla, vlColumna.Key) Then
                    Dim vlDataTable As DataTable
                    vlDataTable = vlUsuario.ConfiguraGrid.CGRValor.Recuperar("USUId='" & vlUsuarioId & "' AND CGRComponente='" & pvComponente & "' AND CGRForma='" & pvForma & "' AND CGRTabla='" & pvTabla & "' AND CGRNombre='" & prGrid.Name & "' AND CGVColumna='" & vlColumna.Key & "'")
                    vlColumna.Width = vlDataTable.Rows(0)!Longitud
                    If vlDataTable.Rows(0)!TipoVisible = 1 Then
                        vlColumna.Visible = True
                    Else
                        vlColumna.Visible = False
                    End If
                    If vlDataTable.Rows(0)!TipoAgrupado = 1 Then
                        If (vlColumna.IsGrouped = False) Then
                            prGrid.Tables(pvTabla).Groups.Add(New Janus.Windows.GridEX.GridEXGroup(vlColumna))
                        End If
                    Else
                        If (vlColumna.IsGrouped) Then
                            prGrid.Tables(pvTabla).Groups.Remove(vlColumna.Group)
                        End If
                    End If
                    If vlDataTable.Rows(0)!TipoOrden = 0 Then
                        If vlColumna.IsSorted Then
                            prGrid.Tables(pvTabla).SortKeys.Remove(vlColumna.SortKey)
                        End If
                    ElseIf vlDataTable.Rows(0)!TipoOrden = 1 Then
                        If vlColumna.IsSorted Then
                            vlColumna.SortKey.SortOrder = Janus.Windows.GridEX.SortOrder.Ascending
                        ElseIf vlColumna.IsGrouped Then
                            vlColumna.Group.SortOrder = Janus.Windows.GridEX.SortOrder.Ascending
                        Else
                            prGrid.Tables(pvTabla).SortKeys.Add(New Janus.Windows.GridEX.GridEXSortKey(vlColumna, Janus.Windows.GridEX.SortOrder.Ascending))
                        End If
                    ElseIf vlDataTable.Rows(0)!TipoOrden = 2 Then
                        If vlColumna.IsSorted Then
                            vlColumna.SortKey.SortOrder = Janus.Windows.GridEX.SortOrder.Descending
                        ElseIf vlColumna.IsGrouped Then
                            vlColumna.Group.SortOrder = Janus.Windows.GridEX.SortOrder.Descending
                        Else
                            prGrid.Tables(pvTabla).SortKeys.Add(New Janus.Windows.GridEX.GridEXSortKey(vlColumna, Janus.Windows.GridEX.SortOrder.Descending))
                        End If
                    End If
                    vlColumna.Position = vlDataTable.Rows(0)!Posicion
                End If
            Next
        End If
    End Function

    Public Sub GrabarConfiguracionGrid(ByVal pvComponente As String, ByVal pvForma As String, ByRef prGrid As Janus.Windows.GridEX.GridEX, ByVal pvTabla As String)
        Dim vlUsuario As New BASUSULOG.cUsuario
        Dim vlParametros As New lbGeneral.cParametros
        Dim vlUsuarioId As String = cParametros.UsuarioID
        Dim vlConexion As LbConexion.cConexion = LbConexion.cConexion.Instancia

        vlUsuario.RecuperarGrid(vlUsuarioId, pvComponente, pvForma, prGrid.Name, pvTabla)
        If vlUsuario.ConfiguraGrid.Tabla.Existe(vlUsuarioId, pvComponente, pvForma, prGrid.Name, pvTabla) = False Then
            vlUsuario.ConfiguraGrid.Insertar(pvComponente, pvForma, prGrid.Name, pvTabla)
        End If

        Dim oConfiguraGrid As BASUSULOG.cConfiguraGrid = vlUsuario.ConfiguraGrid(pvComponente, pvForma, pvTabla, prGrid.Name)

        For Each vlColumna As Janus.Windows.GridEX.GridEXColumn In prGrid.Tables(pvTabla).Columns
            If vlUsuario.ConfiguraGrid.CGRValor.Existe(vlUsuarioId, pvComponente, pvForma, prGrid.Name, pvTabla, vlColumna.Key) Then
                Dim oCGRValor As BASUSULOG.cCGRValor = oConfiguraGrid.CGRValor(vlColumna.Key)
                If oCGRValor.Longitud <> vlColumna.Width Then
                    oCGRValor.Longitud = vlColumna.Width
                End If

                If vlColumna.Visible = True Then
                    If oCGRValor.TipoVisible <> 1 Then
                        oCGRValor.TipoVisible = 1
                    End If
                Else
                    If oCGRValor.TipoVisible <> 0 Then
                        oCGRValor.TipoVisible = 0
                    End If
                End If

                If (vlColumna.IsGrouped) Then
                    If oCGRValor.TipoAgrupado <> 1 Then
                        oCGRValor.TipoAgrupado = 1
                    End If
                Else
                    If oCGRValor.TipoAgrupado <> 0 Then
                        oCGRValor.TipoAgrupado = 0
                    End If
                End If

                If vlColumna.IsSorted Then
                    If vlColumna.SortOrder = Janus.Windows.GridEX.SortOrder.Ascending Then
                        If oCGRValor.TipoOrden <> 1 Then
                            oCGRValor.TipoOrden = 1
                        End If
                    ElseIf vlColumna.SortOrder = Janus.Windows.GridEX.SortOrder.Descending Then
                        If oCGRValor.TipoOrden <> 2 Then
                            oCGRValor.TipoOrden = 2
                        End If
                    End If
                Else
                    If oCGRValor.TipoOrden <> 0 Then
                        oCGRValor.TipoOrden = 0
                    End If
                End If
                If oCGRValor.Posicion <> vlColumna.Position Then
                    oCGRValor.Posicion = vlColumna.Position
                End If
            Else
                oConfiguraGrid.CGRValor.CGVColumna = vlColumna.Key
                oConfiguraGrid.CGRValor.Longitud = vlColumna.Width

                If vlColumna.Visible = True Then
                    oConfiguraGrid.CGRValor.TipoVisible = 1
                Else
                    oConfiguraGrid.CGRValor.TipoVisible = 0
                End If

                If (vlColumna.IsGrouped) Then
                    oConfiguraGrid.CGRValor.TipoAgrupado = 1
                Else
                    oConfiguraGrid.CGRValor.TipoAgrupado = 0
                End If

                If vlColumna.IsSorted Then
                    If vlColumna.SortOrder = Janus.Windows.GridEX.SortOrder.Ascending Then
                        oConfiguraGrid.CGRValor.TipoOrden = 1
                    ElseIf vlColumna.SortOrder = Janus.Windows.GridEX.SortOrder.Descending Then
                        oConfiguraGrid.CGRValor.TipoOrden = 2
                    End If
                Else
                    oConfiguraGrid.CGRValor.TipoOrden = 0
                End If
                oConfiguraGrid.CGRValor.Posicion = vlColumna.Position
                oConfiguraGrid.CGRValor.Insertar()
            End If
        Next
        vlUsuario.Grabar()
        vlConexion.ConfirmarTran()
    End Sub
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Funcion de encriptamiento sencillo mediante un algoritmo de cambio de valor ASCII
    ''' </summary>
    ''' <param name="Text"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[jvazquez]	03/05/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function SimpleCrypt(ByVal Text As String) As String
        ' Encrypts/decrypts the passed string using 
        ' a simple ASCII value-swapping algorithm
        Dim strTempChar As String = "", i As Integer

        For i = 1 To Len(Text)
            If Asc(Mid$(Text, i, 1)) < 128 Then
                strTempChar = _
          CType(Asc(Mid$(Text, i, 1)) + 128, String)
            ElseIf Asc(Mid$(Text, i, 1)) > 128 Then
                strTempChar = _
          CType(Asc(Mid$(Text, i, 1)) - 128, String)
            End If
            Mid$(Text, i, 1) = _
                Chr(CType(strTempChar, Integer))
        Next i
        Return Text
    End Function

    Public Function ValidaFormatoSQLString(ByVal pvText As String) As String
        Dim sText As String = pvText

        If IsNothing(pvText) Or IsDBNull(pvText) Then
            Return pvText
        End If

        If pvText.IndexOf("'") >= 0 Then
            sText = pvText.Replace("'", "''")
        End If

        Return sText

    End Function
End Module
''' -----------------------------------------------------------------------------
''' <summary>
''' Modo de operación para un documento  que define su estado actual.
''' </summary>
''' <remarks>
''' Los estados pueden ser Crear, Modificar, Cancelar, Eliminar o Consultar
''' </remarks>
''' <history>
''' 	[jvazquez]	03/05/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Enum eModo
    Crear = 1
    Modificar = 2
    Cancelar = 3
    Eliminar = 4
    Consultar = 5

End Enum