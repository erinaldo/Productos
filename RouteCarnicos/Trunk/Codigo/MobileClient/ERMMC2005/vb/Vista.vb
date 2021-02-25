Imports System.Data.SqlServerCe
Imports Resco.Controls.DetailView
Imports System.Xml
Imports System.IO

Public Class Vista
    Inherits ServicesCentral.CVista

    Protected sTexto As String

    Public Property Texto() As String
        Get
            Return sTexto
        End Get
        Set(ByVal Value As String)
            sTexto = Value
        End Set
    End Property

    ' Arreglo de Vistas
    Public Shared aListaVistas As New ArrayList

    ' Arreglo de elementos de esta vista
    Private aLista As ArrayList

    Public Sub New(ByVal pariVistaId As Integer, ByVal parsNombre As String)
        VistaId = pariVistaId
        Nombre = parsNombre
        aLista = New ArrayList
    End Sub

    Public Event AgregarItemDetailView(ByRef refparaVistaElementoDet As VistaElementoDet, ByRef refparbContinuar As Boolean)
    Public Event AgregarItemListView(ByRef refparoListViewItem As ListViewItem, ByRef refparoDataRow As DataRow)

    Public Shared Function Llenar() As Boolean
        Try
            FormProcesando.PubSubInformar("Recuperando información del sistema", "Información de vistas")
            ' Usar un dataset para recuperar las vistas
            Dim refDataRow As DataRow
            ' Recuperar los registros de las Vistas
            Dim DataTableDatos As DataTable
            DataTableDatos = oDBApp.RealizarConsultaSQL("SELECT * FROM Vista", "Vista")
            ' Recuperar los registros de Elementos
            Dim DataTableElemento As DataTable
            DataTableElemento = oDBApp.RealizarConsultaSQL("SELECT * FROM VistaElemento ORDER BY VistaID,VistaElementoID", "VistaElemento")
            ' Recuperar los registros de Elementos
            Dim DataTableElementoDet As DataTable
            DataTableElementoDet = oDBApp.RealizarConsultaSQL("SELECT * FROM VistaElementoDet ORDER BY VistaID, VistaElementoID, Indice, Orden", "VistaElementoDet")

            Dim DataViewElemento As DataView = New DataView(DataTableElemento, "", "VistaID", DataViewRowState.CurrentRows)
            Dim DataViewElementoDet As DataView = New DataView(DataTableElementoDet, "", "VistaID,VistaElementoID", DataViewRowState.CurrentRows)

            Dim oVista(0) As Object
            Dim oVistaElemento(1) As Object

            Dim DataRowViewElementos() As DataRowView
            Dim DataRowViewElementosDet() As DataRowView
            Dim refDataRowViewElemento As DataRowView
            Dim refDataRowViewElementoDet As DataRowView

            Dim refaVista As Vista
            Dim refaVistaElemento As VistaElemento
            Dim refaVistaElementoDet As VistaElementoDet

            Dim sVistaID As String
            Dim sVistaElementoID As String

            ' Colocarlos todas las vistas en el arreglo
            aListaVistas.Clear()
            For Each refDataRow In DataTableDatos.Rows
                ' Preparar la llave de busqueda
                sVistaID = refDataRow("VistaId")
                oVista(0) = sVistaID
                ' Buscar los Elementos de esta vista
                DataRowViewElementos = DataViewElemento.FindRows(oVista)
                ' Crear el objeto Vista
                refaVista = New Vista(sVistaID, refDataRow("Nombre"))
                ' Para cada elemento, buscar sus subelementos (o VistaElementoDet)
                oVistaElemento(0) = sVistaID
                For Each refDataRowViewElemento In DataRowViewElementos
                    sVistaElementoID = refDataRowViewElemento("VistaElementoID")
                    oVistaElemento(1) = sVistaElementoID
                    ' Crear el objeto VistaElemento
                    With refDataRowViewElemento
                        refaVistaElemento = New VistaElemento(sVistaElementoID, .Item("Nombre"), IIf(.Row.IsNull("Descripcion"), "", .Item("Descripcion")), .Item("TipoControl"), .Item("TipoContenido"), .Item("ConsultaSQL"))
                    End With
                    DataRowViewElementosDet = DataViewElementoDet.FindRows(oVistaElemento)
                    For Each refDataRowViewElementoDet In DataRowViewElementosDet
                        With refDataRowViewElementoDet
                            ' Crear el objeto VistaElementoDet
                            refaVistaElementoDet = New VistaElementoDet(.Item("VistaElementoDetID"), .Item("Nombre"), IIf(.Row.IsNull("Descripcion"), "", .Item("Descripcion")), .Item("Indice"), .Item("Ancho"), .Item("TipoControl"), .Item("TipoEdicion"), .Item("TipoVisible"), .Item("TipoAlineacion"))
                        End With
                        ' Agregar el VistaElementoDet al VistaElemento
                        refaVistaElemento.aLista.Add(refaVistaElementoDet)
                    Next
                    ' Agregar el VistaElemento al Vista
                    refaVista.aLista.Add(refaVistaElemento)
                Next
                ' Agregar el Vista al arreglo global de vistas
                aListaVistas.Add(refaVista)
            Next
            DataViewElemento.Dispose()
            DataViewElementoDet.Dispose()
            DataTableDatos.Dispose()
            DataTableElemento.Dispose()
            DataTableElementoDet.Dispose()
            Return True
        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message, MsgBoxStyle.Critical, "Llenar")
        End Try
        Return False
    End Function

    Private Enum TiposAccionColumna
        Ninguna = 0
        Pivote = 1 ' Para totalizar por este campo
        Referencia = 2 ' Para indicar columnas creadas dinamicamente cuyos valores se obtienen de otras columnas
        Funcion = 3
        Condicionante = 4
    End Enum

    Private Class ListViewColumnHeader
        Inherits System.Windows.Forms.ColumnHeader

        Protected sNombre As String
        Protected sFuncion As String
        Protected asParametros As String()
        Protected oTag As Object
        Protected iTipo As Integer
        Protected tTipoAccion As TiposAccionColumna

        Public Property Nombre() As String
            Get
                Return sNombre
            End Get
            Set(ByVal Value As String)
                sNombre = Value
            End Set
        End Property
        Public Property Funcion() As String
            Get
                Return sFuncion
            End Get
            Set(ByVal Value As String)
                sFuncion = Value
            End Set
        End Property
        Public Property Parametros() As String()
            Get
                Return asParametros
            End Get
            Set(ByVal Value As String())
                asParametros = Value
            End Set
        End Property
        Public Property Tag() As Object
            Get
                Return oTag
            End Get
            Set(ByVal Value As Object)
                oTag = Value
            End Set
        End Property
        Public Property Tipo() As Integer
            Get
                Return iTipo
            End Get
            Set(ByVal Value As Integer)
                iTipo = Value
            End Set
        End Property
        Public Property TipoAccion() As TiposAccionColumna
            Get
                Return tTipoAccion
            End Get
            Set(ByVal Value As TiposAccionColumna)
                tTipoAccion = Value
            End Set
        End Property

    End Class

    Public Function CrearListView(ByVal refparListView As ListView, ByVal parsClaveElemento As String) As Boolean
        Try
            ' Limpiar la lista
            refparListView.Columns.Clear()
            Dim refElemento As VistaElemento
            Dim refElementoDet As VistaElementoDet
            If Not BuscarElemento(parsClaveElemento, refElemento) Then
                Exit Try
            End If
            Dim iIndex As Integer
            refparListView.BeginUpdate()
            ' Agregar las columnas, colocar el nombre del campo como columna
            For iIndex = 0 To refElemento.aLista.Count - 1
                refElementoDet = refElemento.aLista(iIndex)
                ' Si no hay funcion asociada
                Me.VerificarFuncion(refparListView, refElemento, refElementoDet)
            Next
            refparListView.EndUpdate()
            Return True
        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message, MsgBoxStyle.Critical, "CrearListView")
        Catch ExcB As Exception
            MsgBox(ExcB.Message, MsgBoxStyle.Critical, "CrearListView")
        End Try

        Return False
    End Function

    Public Function RegresaFormato(ByVal parsFormato As String) As String
        Select Case parsFormato.ToUpper
            Case "MON"
                Return oApp.FormatoDinero
            Case "INT"
                Return "#,##0"
            Case "DEC"
                Return "#,##0.00"
            Case "DATE"
                Return oApp.FormatoFecha
        End Select
        Return String.Empty
    End Function

    Private Sub VerificarFuncion(ByRef refparListView As ListView, ByRef refparElemento As VistaElemento, ByRef refparElementoDet As VistaElementoDet)
        Dim sFuncion As String = ""
        Dim sNombre As String = ""
        If Mid(refparElementoDet.Nombre, 1, 1) = "#" Then
            If InStr(refparElementoDet.Nombre, "(") = 0 Then
                sFuncion = Mid(refparElementoDet.Nombre, 2)
            Else
                sFuncion = Mid(refparElementoDet.Nombre, 2, InStr(refparElementoDet.Nombre, "(") - 2)
            End If
            sNombre = Mid(refparElementoDet.Nombre, 2, Len(refparElementoDet.Nombre) - 1)
        Else
            sNombre = refparElementoDet.Nombre
        End If
        Dim sContenido As String
        ' Recuperar los valores para cada campo
        Dim i As Integer = InStr(refparElementoDet.Nombre, "(")
        ' Variables para recuperar el contenido en varios campos
        Dim sDelimitadores As String = ","
        Dim cDelimitador As Char() = sDelimitadores.ToCharArray()
        Dim asParams As String() = Nothing
        If i <> 0 Then
            sContenido = Mid(refparElementoDet.Nombre, i + 1, Len(refparElementoDet.Nombre) - i - 1)
            asParams = sContenido.Split(cDelimitador)
        End If
        Dim refDataRow As DataRow
        Dim refListViewColumn As ListViewColumnHeader
        'Dim oDataTable As DataTable
        Select Case UCase(sFuncion)
            Case "TYPE" ' Solo para los ListViews con creacion de columnas dinamicas
                ' Indica que se creen tanta scolumnas como valores por referencia existan en ValorReferencia para un valor por referencia especificado
                ' Obligan 4 parametros:
                ' 1 - Valor por referencia para crear las columnas
                ' 2 - Nombre de la columna que contiene el Valor por Referencia que indica en cual columna se colocara el valor indicado en el parametro 3
                ' 3 - Nombre de la columna que contiene el valor a colocar en la columna determinada en el parametro 2
                ' 4 - Formato, MON-Moneda, INT-Entero,DEC-Decimal,DATE-Fecha
                If asParams.Length() >= 3 Then
                    i = 0
                    Dim aValores As ArrayList = ValorReferencia.RecuperarLista(asParams(0))
                    For Each refDesc As ValorReferencia.Descripcion In aValores
                        refListViewColumn = New ListViewColumnHeader
                        refListViewColumn.Text = refDesc.Cadena
                        refListViewColumn.Nombre = sNombre
                        refListViewColumn.Parametros = asParams
                        refListViewColumn.Funcion = sFuncion
                        refListViewColumn.Tag = i
                        refListViewColumn.Tipo = refDesc.Id
                        refListViewColumn.TipoAccion = TiposAccionColumna.Referencia
                        refListViewColumn.TextAlign = [Global].ObtenerAlineacion(refparElementoDet.TipoAlineacion)
#If MOD_TERM = "IPAQ" Or MOD_TERM = "HHP9700" Then

                        refListViewColumn.Width = refparElementoDet.Ancho * 2
#Else
                            refListViewColumn.Width = refparElementoDet.Ancho 
#End If
                        refparListView.Columns.Add(refListViewColumn)
                        refListViewColumn.Dispose()
                        i += 1
                    Next
                    aValores = Nothing
                    'oDataTable = ValorReferencia.RecuperarLista(asParams(0)) ' UNIDADV
                    'i = 0
                    'For Each refDataRow In oDataTable.Rows
                    '    refListViewColumn = New ListViewColumnHeader
                    '    refListViewColumn.Text = refDataRow("Descripcion")
                    '    refListViewColumn.Nombre = sNombre
                    '    refListViewColumn.Parametros = asParams
                    '    refListViewColumn.Funcion = sFuncion
                    '    refListViewColumn.Tag = i
                    '    refListViewColumn.Tipo = refDataRow("VAVClave")
                    '    refListViewColumn.TipoAccion = TiposAccionColumna.Referencia
                    '    refListViewColumn.TextAlign = [Global].ObtenerAlineacion(refparElementoDet.TipoAlineacion)
                    '    refListViewColumn.Width = refparElementoDet.Ancho
                    '    refparListView.Columns.Add(refListViewColumn)
                    '    i += 1
                    'Next
                End If
            Case "PIV"
                refparElemento.TipoEjecucionConsultaSQL = VistaElemento.TiposEjecucionConsultaSQL.Totalizar
                refListViewColumn = New ListViewColumnHeader
                refListViewColumn.Text = refparElementoDet.Texto
                refListViewColumn.TextAlign = [Global].ObtenerAlineacion(refparElementoDet.TipoAlineacion)
#If MOD_TERM = "IPAQ" Or MOD_TERM = "HHP9700" Then

                refListViewColumn.Width = refparElementoDet.Ancho * 2
#Else
                            refListViewColumn.Width = refparElementoDet.Ancho 
#End If
                refListViewColumn.Nombre = sNombre
                refListViewColumn.Parametros = asParams
                refListViewColumn.Funcion = sFuncion
                refListViewColumn.TipoAccion = TiposAccionColumna.Pivote
                refListViewColumn.Tipo = 0
                refparListView.Columns.Add(refListViewColumn)
                refListViewColumn.Dispose()
            Case Else
                ' Crear la columna normalmente
                refListViewColumn = New ListViewColumnHeader
                refListViewColumn.Text = refparElementoDet.Texto
                refListViewColumn.TextAlign = [Global].ObtenerAlineacion(refparElementoDet.TipoAlineacion)
#If MOD_TERM = "IPAQ" Or MOD_TERM = "HHP9700" Then

                refListViewColumn.Width = refparElementoDet.Ancho * 2
#Else
                            refListViewColumn.Width = refparElementoDet.Ancho 
#End If
                refListViewColumn.Nombre = sNombre
                refListViewColumn.Parametros = asParams
                refListViewColumn.Funcion = sFuncion
                If sFuncion = "" Then
                    refListViewColumn.TipoAccion = TiposAccionColumna.Ninguna
                Else
                    refListViewColumn.TipoAccion = TiposAccionColumna.Funcion
                End If
                refListViewColumn.Tipo = 0
                refparListView.Columns.Add(refListViewColumn)
                refListViewColumn.Dispose()
        End Select
    End Sub

    Public Sub PoblarListViewDinamico(ByRef refparListView As ListView, ByRef parconConDB As Conexion, ByVal parsClaveElemento As String, ByVal parsCondicion As String)
        refparListView.Items.Clear()
        Dim ldt As DataTable = TablaListView(oDBVen, parsClaveElemento, parsCondicion)
        'Dim ldtValores As DataTable
        Dim ldtResultados As New DataTable
        Dim aColumnas As New ArrayList

        ' Buscar el campo pivote
        Dim refColumnHeader As ListViewColumnHeader
        Dim sColumnaPivote As String = String.Empty
        Dim iColumnaTipo As Integer = 0
        Dim iColumnaValorTipo As Integer = 0
        Dim sFormato As String = String.Empty
        For Each refColumnHeader In refparListView.Columns
            Select Case refColumnHeader.TipoAccion
                Case TiposAccionColumna.Pivote
                    ' El primer parametro debe traer el nombre de la columna Pivote
                    If refColumnHeader.Parametros.Length = 1 Then
                        sColumnaPivote = refColumnHeader.Parametros(0)
                        ldtResultados.Columns.Add(sColumnaPivote)
                    End If
                Case TiposAccionColumna.Referencia
                    If refColumnHeader.Parametros.Length = 4 Then
                        If iColumnaTipo = 0 Then
                            iColumnaTipo = CInt(refColumnHeader.Parametros(1))
                        End If
                        If iColumnaValorTipo = 0 Then
                            iColumnaValorTipo = CInt(refColumnHeader.Parametros(2))
                        End If
                        If sFormato = String.Empty Then
                            sFormato = RegresaFormato(refColumnHeader.Parametros(3).ToString)
                        End If
                        ldtResultados.Columns.Add(refColumnHeader.Tipo)
                    End If
                Case TiposAccionColumna.Funcion
                    Dim refDataColumn As DataColumn
                    refDataColumn = Me.ObtenerColumnaDeParametro(ldt, refColumnHeader, 0)
                    ldtResultados.Columns.Add(refDataColumn.ColumnName)
                    aColumnas.Add(refDataColumn.ColumnName)
                Case Else
                    ldtResultados.Columns.Add(refColumnHeader.Nombre)
                    aColumnas.Add(refColumnHeader.Nombre)
            End Select
        Next
        refColumnHeader = Nothing

        If sColumnaPivote = "" Then
            MsgBox("No existe un pivote en el grupo de columnas", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim sDatoPivote As String = ""
        Dim ldrRes As DataRow
        For Each dr As DataRow In ldt.Rows
            If sDatoPivote <> dr(sColumnaPivote).ToString Then
                ldrRes = ldtResultados.NewRow
                ldtResultados.Rows.Add(ldrRes)
                ldrRes(sColumnaPivote) = dr(sColumnaPivote)
                For Each sNombreCol As String In aColumnas
                    ldrRes(sNombreCol) = dr(sNombreCol)
                Next
            End If
            If dr(iColumnaTipo).ToString <> "" And Not IsDBNull(dr(iColumnaValorTipo)) Then
                If sFormato <> String.Empty Then
                    ldrRes(dr(iColumnaTipo).ToString) = Format(dr(iColumnaValorTipo), sFormato)
                Else
                    ldrRes(dr(iColumnaTipo).ToString) = Format(dr(iColumnaValorTipo))
                End If
            End If

            sDatoPivote = dr(sColumnaPivote).ToString
        Next

        LlenarListViewConsultaSQL(refparListView, ldtResultados)

        ldt.Dispose()
        ldtResultados.Dispose()
        ldt = Nothing
        ldtResultados = Nothing
    End Sub

    Public Function PoblarListView(ByRef refparListView As ListView, ByRef parconConDB As Conexion, ByVal parsClaveElemento As String, ByVal parsCondicion As String) As Boolean
        Try
            ' Limpiar la lista
            refparListView.Items.Clear()
            Dim refaVistaElemento As VistaElemento
            If Not BuscarElemento(parsClaveElemento, refaVistaElemento) Then
                Exit Try
            End If
            ' Evaluar el tipo de contenido del ListView
            Select Case refaVistaElemento.TipoContenido
                Case ServicesCentral.TiposContenido.Consulta
                    ' Recuperar los datos de la consulta SQL de la vista
                    Dim DataSetDatos As DataTable
                    DataSetDatos = RecuperarDatos(parconConDB, parsClaveElemento, parsCondicion)
                    ' Verificar que existan datos
                    If DataSetDatos.Rows.Count = 0 Then
                        DataSetDatos.Dispose()
                        Return True
                    End If
                    If refaVistaElemento.TipoEjecucionConsultaSQL = VistaElemento.TiposEjecucionConsultaSQL.Totalizar Then
                        Me.LlenarListViewConsultaSQLTotales(refparListView, DataSetDatos)
                    Else
                        Me.LlenarListViewConsultaSQL(refparListView, DataSetDatos)
                    End If
                    DataSetDatos.Dispose()
                Case ServicesCentral.TiposContenido.Multiple
                    Me.LlenarListViewMultiples(refparListView, refaVistaElemento)
            End Select
            refaVistaElemento = Nothing
            Return True
        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message, MsgBoxStyle.Critical, "PoblarListView")
        Catch ExcB As Exception
            MsgBox(ExcB.Message, MsgBoxStyle.Critical, "PoblarListView")
        End Try
        Return False
    End Function

    Public Function TablaListView(ByRef parconConDB As Conexion, ByVal parsClaveElemento As String, ByVal parsCondicion As String) As DataTable
        Dim ldt As New DataTable
        Try
            ' Limpiar la lista
            Dim refaVistaElemento As VistaElemento
            If Not BuscarElemento(parsClaveElemento, refaVistaElemento) Then
                Exit Try
            End If
            'Recuperar los datos de la consulta SQL de la vista
            ldt = RecuperarDatos(parconConDB, parsClaveElemento, parsCondicion)
            'Verificar que existan datos
            Return ldt
        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message, MsgBoxStyle.Critical, "PoblarListView")
        Catch ExcB As Exception
            MsgBox(ExcB.Message, MsgBoxStyle.Critical, "PoblarListView")
        End Try
        Return ldt
    End Function

    Private Sub LlenarListViewMultiples(ByRef refparListView As ListView, ByRef refparaVistaElemento As VistaElemento)
        ' Colocar el resultado en el listview
        refparListView.BeginUpdate()
        Dim sValorColumna As String
        Dim ListViewItem As ListViewItem
        Dim refaVistaDet As VistaElementoDet
        Dim iIndex As Integer
        refparListView.FullRowSelect = True
        refparListView.HeaderStyle = ColumnHeaderStyle.None
        refparListView.View = View.Details
        refparListView.Columns.Clear()
        refparListView.Columns.Add("", 216, HorizontalAlignment.Left)
        ' Agregar las columnas
        For iIndex = 0 To refparaVistaElemento.aLista.Count - 1
            refaVistaDet = refparaVistaElemento.aLista(iIndex)
            sValorColumna = refaVistaDet.Texto
            ListViewItem = New ListViewItem(sValorColumna)
            ListViewItem.ImageIndex = refaVistaDet.Indice
            refparListView.Items.Add(ListViewItem)
            If refaVistaDet.Nombre = "*" Then
                ListViewItem.Selected = True
            End If
        Next
        refparListView.EndUpdate()
    End Sub

    Public Sub LlenarListViewConsultaSQL(ByRef refparListView As ListView, ByRef refparoDataSetDatos As DataTable)
        ' Recuperar los datos de la consulta SQL de la vista
        ' Colocar el resultado en el listview
        Dim sValorColumna As String
        Dim sNombreColumna As String = ""
        Dim sNuevoValorColumna As String = ""
        Dim refDataRow As DataRow
        Dim refDataColumn As DataColumn
        Dim refListViewItem As ListViewItem
        Dim ListViewItem As ListViewItem
        Dim iIndex As Integer
        Dim iIndiceImagen As Integer
        Dim oImageList As ImageList
        Dim bAgregar As Boolean
        ' Las columnas ya están en el Listview, llenarlo con los elementos resultantes de la consulta
        refparListView.BeginUpdate()
        For Each refDataRow In refparoDataSetDatos.Rows
            iIndex = 0
            iIndiceImagen = -1
            For Each refDataColumn In refparoDataSetDatos.Columns
                sNombreColumna = refDataColumn.ColumnName
                If refDataColumn.DataType.Name = "Byte[]" Then
                    Dim oImg As Byte()
                    Dim img1 As System.Drawing.Icon
                    Dim imgTmp2 As System.Drawing.Image
                    bAgregar = False

                    If Not IsDBNull(refDataRow(refDataColumn.Ordinal)) Then
                        Try
                            oImg = refDataRow(refDataColumn.Ordinal)
                            Dim msImagen As New System.IO.MemoryStream(oImg)
                            img1 = New System.Drawing.Icon(msImagen)
                            Dim imgTmp As System.Drawing.Image = New System.Drawing.Bitmap(img1.Width, img1.Height)
                            Dim gTmp As System.Drawing.Graphics = System.Drawing.Graphics.FromImage(imgTmp)
                            gTmp.DrawIcon(img1, 0, 0)
                            imgTmp2 = New System.Drawing.Bitmap(48, 48)
                            gTmp = System.Drawing.Graphics.FromImage(imgTmp2)
                            gTmp.DrawImage(imgTmp, New System.Drawing.Rectangle(0, 0, 48, 48), New System.Drawing.Rectangle(0, 0, imgTmp.Width, imgTmp.Height), Drawing.GraphicsUnit.Pixel)
                            imgTmp.Dispose()
                            msImagen.Close()
                            bAgregar = True
                        Catch ex As Exception

                        End Try
                    End If
                    If oImageList Is Nothing Then
                        oImageList = New ImageList()

                        oImageList.ImageSize = New System.Drawing.Size(48, 48)

                        refparListView.SmallImageList = Nothing
                        refparListView.SmallImageList = oImageList
                        refparListView.LargeImageList = oImageList
                    End If
                    If bAgregar Then
                        Try
                            oImageList.Images.Add(imgTmp2)
                            iIndiceImagen = oImageList.Images.Count - 1
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        End Try

                    End If
                Else
                    sValorColumna = IIf(refDataRow.IsNull(refDataColumn.Ordinal), "", refDataRow(refDataColumn.Ordinal))
                    If [Global].AplicarFuncion(sNombreColumna, sValorColumna, sNuevoValorColumna, iIndiceImagen) Then
                        If iIndex = 0 Then
                            ListViewItem = New ListViewItem(sNuevoValorColumna)
                            refListViewItem = refparListView.Items.Add(ListViewItem)
                        Else
                            refListViewItem.SubItems.Add(sNuevoValorColumna)
                        End If
                        iIndex += 1
                    End If
                End If
            Next
            If iIndiceImagen <> -1 Then
                refListViewItem.ImageIndex = iIndiceImagen
            End If
            RaiseEvent AgregarItemListView(refListViewItem, refDataRow)
        Next
        refparListView.EndUpdate()
    End Sub

    Private Sub LlenarListViewConsultaSQLTotales(ByRef refparListView As ListView, ByRef refparoDataSetDatos As DataTable)
        ' Buscar el campo pivote
        Dim refColumnHeader As ListViewColumnHeader
        Dim sColumnaPivote As String = ""
        For Each refColumnHeader In refparListView.Columns
            Select Case refColumnHeader.TipoAccion
                Case TiposAccionColumna.Pivote
                    ' El primer parametro debe traer el nombre de la columna Pivote
                    If refColumnHeader.Parametros.Length = 1 Then
                        sColumnaPivote = refColumnHeader.Parametros(0)
                        Exit For
                    Else
                        MsgBox("Faltan parametros al indicar la columna pivote", MsgBoxStyle.Exclamation)
                        Exit Sub
                    End If
            End Select
        Next
        If sColumnaPivote = "" Then
            MsgBox("No existe un pivote en el grupo de columnas", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Dim sValorColumna As String
        Dim sNombreColumna As String
        Dim sNuevoValorColumna As String = ""
        Dim refDataColumn As DataColumn
        Dim refListViewItem As ListViewItem
        Dim iIndex As Integer
        Dim iIndiceImagen As Integer
        Dim oPivote As Object
        Dim iTipo As Integer = 0
        Dim bAplicarFuncion As Boolean
        Dim bNuevoPivote As Boolean
        Dim DataViewBusqueda As DataView = New DataView(refparoDataSetDatos, "", sColumnaPivote, DataViewRowState.CurrentRows)
        Dim DataRowViewResultado() As DataRowView

        ' Las columnas ya están en el Listview, llenarlo con los elementos resultantes de la consulta
        refparListView.BeginUpdate()
        For Each refDataRow As DataRow In refparoDataSetDatos.Rows
            iIndex = 0
            iIndiceImagen = -1
            ' Despreciar las partidas iguales despues del primer registro
            bNuevoPivote = (oPivote <> IIf(refDataRow.IsNull(sColumnaPivote), "", refDataRow(sColumnaPivote)))
            If bNuevoPivote Then
                oPivote = refDataRow(sColumnaPivote)
                refListViewItem = refparListView.Items.Add(New ListViewItem)
            End If
            ' Revisar cada una de las columnas y resolver el valor de la columna que se va a agregar
            For Each refColumnHeader In refparListView.Columns
                refDataColumn = Nothing
                sNombreColumna = ""
                sValorColumna = ""
                bAplicarFuncion = True
                ' Encontrar el refDataColumn que se va a considerar en el refColumnHeader
                Select Case refColumnHeader.TipoAccion
                    Case TiposAccionColumna.Pivote ' La columna es un agrupador
                        If bNuevoPivote Then
                            refDataColumn = Me.ObtenerColumnaDeParametro(refparoDataSetDatos, refColumnHeader, 0)
                            If Not refDataColumn Is Nothing Then
                                sNombreColumna = refDataColumn.ColumnName
                                sValorColumna = IIf(refDataRow.IsNull(refDataColumn.Ordinal), "", refDataRow(refDataColumn.Ordinal))
                            End If
                        Else
                            bAplicarFuncion = False
                        End If
                    Case TiposAccionColumna.Funcion ' La columna tiene una funcion
                        If bNuevoPivote Then
                            Select Case UCase(refColumnHeader.Funcion)
                                Case "SUM"
                                    refDataColumn = Me.ObtenerColumnaDeParametro(refparoDataSetDatos, refColumnHeader, 0)
                                    Dim iTotal As Decimal = 0
                                    If Not refDataColumn Is Nothing Then
                                        sNombreColumna = refDataColumn.ColumnName
                                        DataRowViewResultado = DataViewBusqueda.FindRows(oPivote)
                                        For Each refDataRowView As DataRowView In DataRowViewResultado
                                            If Not refDataRowView.Row.IsNull(sNombreColumna) Then
                                                iTotal += refDataRowView.Item(sNombreColumna)
                                            End If
                                        Next
                                    End If
                                    sValorColumna = iTotal
                            End Select
                        Else
                            bAplicarFuncion = False
                        End If
                    Case TiposAccionColumna.Referencia ' La columna es creada dinamicamente de acuerdo a un valor por referencia
                        ' Recuperar la primer columna ~ TipoUnidad
                        refDataColumn = Me.ObtenerColumnaDeParametro(refparoDataSetDatos, refColumnHeader, 1)
                        If Not refDataColumn Is Nothing Then
                            iTipo = IIf(IsDBNull(refDataRow(refDataColumn.Ordinal)), 0, refDataRow(refDataColumn.Ordinal))
                            If iTipo = refColumnHeader.Tipo Then
                                ' Recuperar la segunda columna ~ Cantidad
                                refDataColumn = Me.ObtenerColumnaDeParametro(refparoDataSetDatos, refColumnHeader, 2)
                                If Not refDataColumn Is Nothing Then
                                    sNombreColumna = refDataColumn.ColumnName
                                    sValorColumna = IIf(refDataRow.IsNull(refDataColumn.Ordinal), "", refDataRow(refDataColumn.Ordinal))
                                End If
                            End If
                        End If
                    Case TiposAccionColumna.Ninguna
                        refDataColumn = refparoDataSetDatos.Columns(refColumnHeader.Nombre)
                        If Not refDataColumn Is Nothing Then
                            sNombreColumna = refDataColumn.ColumnName
                            sValorColumna = IIf(refDataRow.IsNull(refDataColumn.Ordinal), "", refDataRow(refDataColumn.Ordinal))
                        End If
                End Select
                ' Aplicar el formato si es necesario
                If sNombreColumna <> "" Then
                    If Not [Global].AplicarFuncion(sNombreColumna, sValorColumna, sNuevoValorColumna, iIndiceImagen) Then
                        bAplicarFuncion = False
                        If iIndiceImagen <> -1 Then
                            refListViewItem.ImageIndex = iIndiceImagen
                        End If
                    End If
                Else
                    sNuevoValorColumna = ""
                End If
                If bAplicarFuncion Then
                    If bNuevoPivote Then
                        If iIndex = 0 Then
                            refListViewItem.Text = sNuevoValorColumna
                        Else
                            refListViewItem.SubItems.Add(sNuevoValorColumna)
                        End If
                    Else
                        If refListViewItem.SubItems(iIndex).Text = "" Then
                            refListViewItem.SubItems(iIndex).Text = sNuevoValorColumna
                        End If
                    End If
                End If
                iIndex += 1
            Next
        Next
        refparListView.EndUpdate()
    End Sub

    Private Function ObtenerColumnaDeParametro(ByRef refparoDataSetDatos As DataTable, ByRef refparColumnHeader As ListViewColumnHeader, ByVal pariNumeroParametro As Integer) As DataColumn
        If IsNumeric(refparColumnHeader.Parametros(pariNumeroParametro)) Then
            Dim iPosCol As Integer = refparColumnHeader.Parametros(pariNumeroParametro)
            Return refparoDataSetDatos.Columns(iPosCol)
        Else
            Return refparoDataSetDatos.Columns(refparColumnHeader.Parametros(pariNumeroParametro))
        End If
    End Function
    Public Function PoblarListViewFiltro(ByRef refparListView As ListView, ByRef parconConDB As Conexion, ByVal parsClaveElemento As String, ByRef refElementosFiltro As ArrayList, ByVal parsNombreCampoFiltro As String, Optional ByVal parsCondicion As String = "") As Boolean
        Try
            ' Limpiar la lista
            refparListView.Items.Clear()
            Dim refaVistaElemento As VistaElemento
            If Not BuscarElemento(parsClaveElemento, refaVistaElemento) Then
                Exit Try
            End If
            Select Case refaVistaElemento.TipoContenido
                Case ServicesCentral.TiposContenido.Consulta
                    ' Recuperar los datos de la consulta SQL de la vista
                    Dim DataSetDatos As DataTable
                    DataSetDatos = RecuperarDatos(parconConDB, parsClaveElemento, parsCondicion)
                    ' Verificar que existan datos
                    If DataSetDatos.Rows.Count = 0 Then
                        DataSetDatos.Dispose()
                        Exit Try
                    End If
                    ' Colocar el resultado en el listview
                    Dim sValorColumna As String
                    Dim sNombreColumna As String
                    Dim sNuevoValorColumna As String = ""
                    Dim refDataColumn As DataColumn
                    'Dim refListViewItem As ListViewItem
                    Dim ListViewItem As ListViewItem
                    Dim iIndex As Integer
                    Dim iIndiceImagen As Integer
                    ' Las columnas ya están en el Listview, llenarlo con los elementos resultantes de la consulta
                    Dim i As Integer
                    Dim DataViewBusqueda As DataView = New DataView(DataSetDatos, "", parsNombreCampoFiltro, DataViewRowState.CurrentRows)
                    Dim DataRowViewResultado() As DataRowView
                    Dim refDataRowView As DataRowView
                    refparListView.BeginUpdate()
                    For i = 0 To refElementosFiltro.Count - 1
                        DataRowViewResultado = DataViewBusqueda.FindRows(refElementosFiltro(i))
                        If DataRowViewResultado.Length <> 0 Then
                            For Each refDataRowView In DataRowViewResultado
                                iIndex = 0
                                iIndiceImagen = -1
                                For Each refDataColumn In DataViewBusqueda.Table.Columns
                                    sNombreColumna = refDataColumn.ColumnName
                                    sValorColumna = IIf(IsDBNull(refDataRowView(refDataColumn.ColumnName)), "", refDataRowView(refDataColumn.ColumnName))
                                    If [Global].AplicarFuncion(sNombreColumna, sValorColumna, sNuevoValorColumna, iIndiceImagen) Then
                                        If iIndex = 0 Then
                                            ListViewItem = New ListViewItem(sNuevoValorColumna)
                                            refparListView.Items.Add(ListViewItem)
                                        Else
                                            ListViewItem.SubItems.Add(sNuevoValorColumna)
                                        End If
                                        iIndex += 1
                                    End If
                                Next
                                If iIndiceImagen <> -1 Then
                                    ListViewItem.ImageIndex = iIndiceImagen
                                End If
                            Next
                        End If
                    Next
                    refparListView.EndUpdate()
                    DataViewBusqueda.Dispose()
                    DataSetDatos.Dispose()
            End Select
            Return True
        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message, MsgBoxStyle.Critical, "PoblarListViewFiltro")
        Catch ExcB As Exception
            MsgBox(ExcB.Message, MsgBoxStyle.Critical, "PoblarListViewFiltro")
        End Try
        Return False
    End Function

    Public Function PoblarCtlMenuImagen(ByRef refparCtlMenuImagen As CtrlMenuImagen, ByVal parsNemonicoImagen As String, ByVal parsClaveElemento As String) As Boolean
        Try
            Dim refaVistaElemento As VistaElemento
            If Not BuscarElemento(parsClaveElemento, refaVistaElemento) Then
                Exit Try
            End If

            ' Agregar las columnas
            If refaVistaElemento.aLista.Count <= 0 Then Return False
            refparCtlMenuImagen.NumColumnas = 3
            refparCtlMenuImagen.NumRenglones = Math.Ceiling(refaVistaElemento.aLista.Count / 3)
            refparCtlMenuImagen.CrearGrid()
            Dim refaVistaDet As VistaElementoDet
            Dim iIndex As Integer
            For iIndex = 0 To refaVistaElemento.aLista.Count - 1
                refaVistaDet = refaVistaElemento.aLista(iIndex)
                If Not IsNothing(htImagenes(parsNemonicoImagen & refaVistaDet.Indice)) Then 'Si no existe la imagen
                    refparCtlMenuImagen.Celdas(iIndex).SetValores(New System.Drawing.Bitmap(CType(htImagenes(parsNemonicoImagen & refaVistaDet.Indice), System.Drawing.Bitmap)), refaVistaDet.Indice, refaVistaDet.Texto)
                Else
                    refparCtlMenuImagen.Celdas(iIndex).SetValores(New System.Drawing.Bitmap(CType(htImagenes("MG0"), System.Drawing.Bitmap)), refaVistaDet.Indice, refaVistaDet.Texto)
                End If
                If refaVistaDet.Nombre = "*" Then
                    refparCtlMenuImagen.ColumnaActual = refparCtlMenuImagen.Celdas(iIndex).IndiceCol
                    refparCtlMenuImagen.RenglonActual = refparCtlMenuImagen.Celdas(iIndex).IndiceRen
                End If
            Next

            refaVistaElemento = Nothing
            Return True
        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message, MsgBoxStyle.Critical, "PoblarCtlMenu")
        Catch ExcB As Exception
            MsgBox(ExcB.Message, MsgBoxStyle.Critical, "PoblarCtlMenu")
        End Try
        Return False
    End Function

    Public Function CrearDetailView(ByVal refparDetailView As Resco.Controls.DetailView.DetailView, ByVal parsClaveElemento As String) As Boolean
        Try
            Dim refaVistaElemento As VistaElemento
            If Not BuscarElemento(parsClaveElemento, refaVistaElemento) Then
                Exit Try
            End If
            Dim refaVistaElementoDet As VistaElementoDet
            Dim iIndex As Integer
            Dim bContinuar As Boolean
            refparDetailView.Items.Clear()
            ' Agregar las columnas, colocar el nombre del campo como columna
            For iIndex = 0 To refaVistaElemento.aLista.Count - 1
                refaVistaElementoDet = refaVistaElemento.aLista(iIndex)
                ' Desencadenar el evento para verificar cómo agregar el elemento
                bContinuar = True
                RaiseEvent AgregarItemDetailView(refaVistaElementoDet, bContinuar)
                If bContinuar Then
                    Select Case refaVistaElementoDet.TipoControl
                        Case ServicesCentral.TiposControlDetalle.Etiqueta
                            Dim ItemNuevo As New Resco.Controls.DetailView.Item
                            ItemNuevo.LabelForeColor = System.Drawing.Color.DarkBlue
                            ItemNuevo.LabelFont = New System.Drawing.Font("Verdana", IIf(10.0! * nFactorFont < 7.0, 7.0, 10.0! * nFactorFont), System.Drawing.FontStyle.Regular)
                            ItemNuevo.LabelAlignment = HorizontalAlignment.Left
                            ItemNuevo.TextFont = New System.Drawing.Font("Verdana", IIf(10.0! * nFactorFont < 7.0, 7.0, 10.0! * nFactorFont), System.Drawing.FontStyle.Bold)
                            ItemNuevo.TextForeColor = System.Drawing.Color.Black
                            ItemNuevo.Name = refaVistaElementoDet.Nombre
                            ItemNuevo.Enabled = (refaVistaElementoDet.TipoEdicion = ServicesCentral.TiposEdicion.Editar)
                            ItemNuevo.Visible = (refaVistaElementoDet.TipoVisible = ServicesCentral.TiposVisible.Visible)
                            ItemNuevo.ItemBorder = ItemBorder.Underline
                            ItemNuevo.TextAlign = [Global].ObtenerAlineacion(refaVistaElementoDet.TipoAlineacion)
                            ItemNuevo.Label = refaVistaElementoDet.Texto
                            ItemNuevo.Height = PubcAlturaItemsDetailView * IIf(bEscalarDV, nFactorH, 1)
                            ItemNuevo.Tag = ""
                            refparDetailView.Items.Add(ItemNuevo)
                        Case ServicesCentral.TiposControlDetalle.Texto
                            Dim TextBoxNuevo As New Resco.Controls.DetailView.ItemTextBox
                            TextBoxNuevo.LabelForeColor = System.Drawing.Color.DarkBlue
                            TextBoxNuevo.LabelAlignment = HorizontalAlignment.Left
                            TextBoxNuevo.TextFont = New System.Drawing.Font("Verdana", IIf(10.0! * nFactorFont < 7.0, 7.0, 10.0! * nFactorFont), System.Drawing.FontStyle.Bold)
                            TextBoxNuevo.TextForeColor = System.Drawing.Color.Black
                            TextBoxNuevo.Name = refaVistaElementoDet.Nombre
                            TextBoxNuevo.Enabled = (refaVistaElementoDet.TipoEdicion = ServicesCentral.TiposEdicion.Editar)
                            If TextBoxNuevo.Enabled Then
                                TextBoxNuevo.TextBackColor = System.Drawing.Color.Aqua
                                TextBoxNuevo.LabelFont = New System.Drawing.Font("Verdana", IIf(10.0! * nFactorFont < 7.0, 7.0, 10.0! * nFactorFont), System.Drawing.FontStyle.Bold)
                                TextBoxNuevo.ItemBorder = ItemBorder.Flat
                            Else
                                TextBoxNuevo.LabelFont = New System.Drawing.Font("Verdana", IIf(10.0! * nFactorFont < 7.0, 7.0, 10.0! * nFactorFont), System.Drawing.FontStyle.Regular)
                                TextBoxNuevo.ItemBorder = ItemBorder.Underline
                            End If
                            TextBoxNuevo.MaxLength = refaVistaElementoDet.Ancho
                            TextBoxNuevo.Visible = (refaVistaElementoDet.TipoVisible = ServicesCentral.TiposVisible.Visible)
                            TextBoxNuevo.TextAlign = [Global].ObtenerAlineacion(refaVistaElementoDet.TipoAlineacion)
                            TextBoxNuevo.Label = refaVistaElementoDet.Texto
                            TextBoxNuevo.Height = PubcAlturaItemsDetailView * IIf(bEscalarDV, nFactorH, 1)
                            TextBoxNuevo.Tag = ""
                            refparDetailView.Items.Add(TextBoxNuevo)
                        Case ServicesCentral.TiposControlDetalle.Logico
                            Dim CheckBoxNuevo As New Resco.Controls.DetailView.ItemCheckBox
                            CheckBoxNuevo.LabelForeColor = System.Drawing.Color.DarkBlue
                            CheckBoxNuevo.LabelFont = New System.Drawing.Font("Verdana", IIf(10.0! * nFactorFont < 7.0, 7.0, 10.0! * nFactorFont), System.Drawing.FontStyle.Regular)
                            CheckBoxNuevo.TextAlign = [Global].ObtenerAlineacion(refaVistaElementoDet.TipoAlineacion)
                            CheckBoxNuevo.TextFont = New System.Drawing.Font("Verdana", IIf(10.0! * nFactorFont < 7.0, 7.0, 10.0! * nFactorFont), System.Drawing.FontStyle.Bold)
                            CheckBoxNuevo.TextForeColor = System.Drawing.Color.Black
                            CheckBoxNuevo.Name = refaVistaElementoDet.Nombre
                            CheckBoxNuevo.Enabled = (refaVistaElementoDet.TipoEdicion = ServicesCentral.TiposEdicion.Editar)
                            CheckBoxNuevo.Visible = (refaVistaElementoDet.TipoVisible = ServicesCentral.TiposVisible.Visible)
                            CheckBoxNuevo.ItemBorder = ItemBorder.Underline
                            CheckBoxNuevo.Text = refaVistaElementoDet.Texto
                            CheckBoxNuevo.QuickChange = True
                            CheckBoxNuevo.CheckState = CheckState.Checked
                            CheckBoxNuevo.ThreeState = False
                            CheckBoxNuevo.Style = RescoItemStyle.LabelTop
                            CheckBoxNuevo.LabelHeight = 0
                            CheckBoxNuevo.Height = PubcAlturaItemsDetailView * IIf(bEscalarDV, nFactorH, 1)
                            CheckBoxNuevo.Tag = ""
                            refparDetailView.Items.Add(CheckBoxNuevo)
                        Case ServicesCentral.TiposControlDetalle.Salto
                            Dim PageBreakNuevo As New Resco.Controls.DetailView.ItemPageBreak
                            PageBreakNuevo.Text = refaVistaElementoDet.Texto
                            PageBreakNuevo.TextAlign = [Global].ObtenerAlineacion(refaVistaElementoDet.TipoAlineacion)
                            PageBreakNuevo.TextFont = New System.Drawing.Font("Verdana", IIf(8.0! * nFactorFont < 7.0, 7.0, 8.0! * nFactorFont), System.Drawing.FontStyle.Regular)
                            PageBreakNuevo.LabelFont = New System.Drawing.Font("Verdana", IIf(8.0! * nFactorFont < 7.0, 7.0, 8.0! * nFactorFont), System.Drawing.FontStyle.Bold)
                            PageBreakNuevo.Tag = PubcMarcaSaltos
                            refparDetailView.Items.Add(PageBreakNuevo)
                        Case ServicesCentral.TiposControlDetalle.Numerico
                            Dim NumericoNuevo As New Resco.Controls.DetailView.ItemNumeric
                            NumericoNuevo.Text = refaVistaElementoDet.Texto
                            NumericoNuevo.TextAlign = [Global].ObtenerAlineacion(refaVistaElementoDet.TipoAlineacion)
                            NumericoNuevo.TextFont = New System.Drawing.Font("Verdana", IIf(8.0! * nFactorFont < 7.0, 7.0, 8.0! * nFactorFont), System.Drawing.FontStyle.Regular)
                            NumericoNuevo.LabelFont = New System.Drawing.Font("Verdana", IIf(8.0! * nFactorFont < 7.0, 7.0, 8.0! * nFactorFont), System.Drawing.FontStyle.Bold)
                            NumericoNuevo.LabelForeColor = System.Drawing.Color.DarkBlue
                            NumericoNuevo.LabelAlignment = HorizontalAlignment.Left
                            NumericoNuevo.Tag = "Numeric"
                            NumericoNuevo.DecimalPlaces = 2
                            NumericoNuevo.ItemBorder = ItemBorder.Underline
                            NumericoNuevo.Maximum = 100
                            NumericoNuevo.Minimum = 0
                            NumericoNuevo.NumericValue = 0
                            If NumericoNuevo.Enabled Then
                                NumericoNuevo.TextBackColor = System.Drawing.Color.Aqua
                                NumericoNuevo.LabelFont = New System.Drawing.Font("Verdana", IIf(10.0! * nFactorFont < 7.0, 7.0, 10.0! * nFactorFont), System.Drawing.FontStyle.Bold)
                                NumericoNuevo.ItemBorder = ItemBorder.Flat
                            Else
                                NumericoNuevo.LabelFont = New System.Drawing.Font("Verdana", IIf(10.0! * nFactorFont < 7.0, 7.0, 10.0! * nFactorFont), System.Drawing.FontStyle.Regular)
                                NumericoNuevo.ItemBorder = ItemBorder.Underline
                            End If
                            NumericoNuevo.Name = refaVistaElementoDet.Nombre
                            NumericoNuevo.Label = refaVistaElementoDet.Texto
                            NumericoNuevo.Height = PubcAlturaItemsDetailView * IIf(bEscalarDV, nFactorH, 1)
                            NumericoNuevo.Visible = (refaVistaElementoDet.TipoVisible = ServicesCentral.TiposVisible.Visible)
                            refparDetailView.Items.Add(NumericoNuevo)
                        Case ServicesCentral.TiposControlDetalle.Combo
                            Dim ComboNuevo As New Resco.Controls.DetailView.ItemComboBox
                            ComboNuevo.LabelForeColor = System.Drawing.Color.DarkBlue
                            ComboNuevo.LabelAlignment = HorizontalAlignment.Left
                            ComboNuevo.TextFont = New System.Drawing.Font("Verdana", IIf(10.0! * nFactorFont < 7.0, 7.0, 10.0! * nFactorFont), System.Drawing.FontStyle.Bold)
                            ComboNuevo.TextForeColor = System.Drawing.Color.Black
                            ComboNuevo.Name = refaVistaElementoDet.Nombre
                            ComboNuevo.Enabled = (refaVistaElementoDet.TipoEdicion = ServicesCentral.TiposEdicion.Editar)
                            If ComboNuevo.Enabled Then
                                ComboNuevo.TextBackColor = System.Drawing.Color.Aqua
                                ComboNuevo.LabelFont = New System.Drawing.Font("Verdana", IIf(10.0! * nFactorFont < 7.0, 7.0, 10.0! * nFactorFont), System.Drawing.FontStyle.Bold)
                                ComboNuevo.ItemBorder = ItemBorder.Flat
                            Else
                                ComboNuevo.LabelFont = New System.Drawing.Font("Verdana", IIf(10.0! * nFactorFont < 7.0, 7.0, 10.0! * nFactorFont), System.Drawing.FontStyle.Regular)
                                ComboNuevo.ItemBorder = ItemBorder.Underline
                            End If
                            ComboNuevo.Visible = (refaVistaElementoDet.TipoVisible = ServicesCentral.TiposVisible.Visible)
                            ComboNuevo.TextAlign = [Global].ObtenerAlineacion(refaVistaElementoDet.TipoAlineacion)
                            ComboNuevo.Label = refaVistaElementoDet.Texto
                            ComboNuevo.Height = PubcAlturaItemsDetailView * IIf(bEscalarDV, nFactorH, 1)
                            ComboNuevo.DropDownStyle = RescoComboBoxStyle.DropDownList
                            ComboNuevo.Tag = "Combo"
                            refparDetailView.Items.Add(ComboNuevo)
                        Case ServicesCentral.TiposControlDetalle.Fecha
                            Dim FechaNuevo As New Resco.Controls.DetailView.ItemDateTime
                            FechaNuevo.TextAlign = [Global].ObtenerAlineacion(refaVistaElementoDet.TipoAlineacion)
                            FechaNuevo.TextFont = New System.Drawing.Font("Verdana", IIf(8.0! * nFactorFont < 7.0, 7.0, 8.0! * nFactorFont), System.Drawing.FontStyle.Regular)
                            FechaNuevo.LabelFont = New System.Drawing.Font("Verdana", IIf(8.0! * nFactorFont < 7.0, 7.0, 8.0! * nFactorFont), System.Drawing.FontStyle.Bold)
                            FechaNuevo.LabelForeColor = System.Drawing.Color.DarkBlue
                            FechaNuevo.LabelAlignment = HorizontalAlignment.Left
                            FechaNuevo.Tag = "TimeDate"
                            FechaNuevo.ItemBorder = ItemBorder.Underline
                            If FechaNuevo.Enabled Then
                                FechaNuevo.TextBackColor = System.Drawing.Color.Aqua
                                FechaNuevo.LabelFont = New System.Drawing.Font("Verdana", IIf(10.0! * nFactorFont < 7.0, 7.0, 10.0! * nFactorFont), System.Drawing.FontStyle.Bold)
                                FechaNuevo.ItemBorder = ItemBorder.Flat
                            Else
                                FechaNuevo.LabelFont = New System.Drawing.Font("Verdana", IIf(10.0! * nFactorFont < 7.0, 7.0, 10.0! * nFactorFont), System.Drawing.FontStyle.Regular)
                                FechaNuevo.ItemBorder = ItemBorder.Underline
                            End If
                            FechaNuevo.Format = oApp.FormatoFecha
                            FechaNuevo.DateTimeStyle = RescoDateTimePickerStyle.Date
                            FechaNuevo.Name = refaVistaElementoDet.Nombre
                            FechaNuevo.Label = refaVistaElementoDet.Texto
                            FechaNuevo.Height = PubcAlturaItemsDetailView * IIf(bEscalarDV, nFactorH, 1)
                            FechaNuevo.Visible = (refaVistaElementoDet.TipoVisible = ServicesCentral.TiposVisible.Visible)
                            refparDetailView.Items.Add(FechaNuevo)
                    End Select
                End If
            Next
            Return True
        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message, MsgBoxStyle.Critical, "CrearDetailView")
        Catch ExcB As Exception
            MsgBox(ExcB.Message, MsgBoxStyle.Critical, "CrearDetailView")
        End Try
        Return False
    End Function

    Public Sub PoblarDetailView(ByVal refparDetailView As Resco.Controls.DetailView.DetailView, ByRef parconConDB As Conexion, ByVal parsClaveElemento As String, ByVal parsCondicion As String)
        Dim dtDatos As DataTable
        Try
            Dim refaVistaElemento As VistaElemento
            If Not BuscarElemento(parsClaveElemento, refaVistaElemento) Then
                Exit Try
            End If
            Dim refDetailViewItem As Resco.Controls.DetailView.Item
            Select Case refaVistaElemento.TipoContenido
                Case ServicesCentral.TiposContenido.Consulta
                    ' Recuperar los datos de la consulta SQL de la vista
                    dtDatos = RecuperarDatos(parconConDB, parsClaveElemento, parsCondicion)
                    ' Verificar que existan datos
                    If dtDatos.Rows.Count = 0 Then
                        dtDatos.Dispose()
                        Exit Select
                    End If
                    ' Colocar el resultado en el DetailView
                    Dim refDataTable As DataTable
                    Dim iNumeroColumna As Integer
                    Dim sValorColumna As String
                    Dim sNuevoValorColumna As String = ""
                    Dim iIndiceImagen As Integer
                    ' Solo se toman los datos del primer registro de la consulta
                    'dtDatos.Dispose()
                    refDataTable = dtDatos
                    For Each refDetailViewItem In refparDetailView.Items
                        ' Si no es un salto de página
                        If refDetailViewItem.Tag <> PubcMarcaSaltos Then
                            ' Colocar el valor de la columna en el item
                            If refDataTable.Rows(0).IsNull(iNumeroColumna) Then
                                sValorColumna = ""
                            Else
                                sValorColumna = refDataTable.Rows(0).Item(iNumeroColumna)
                            End If
                            If refDetailViewItem.Tag = "Combo" Then
                                If [Global].AplicarFuncion(refDataTable.Columns(iNumeroColumna).ColumnName, sValorColumna, sNuevoValorColumna, iIndiceImagen, refDetailViewItem) Then
                                    iNumeroColumna += 1
                                End If
                            Else
                                If [Global].AplicarFuncion(refDataTable.Columns(iNumeroColumna).ColumnName, sValorColumna, sNuevoValorColumna, iIndiceImagen) Then
                                    If refDetailViewItem.Tag = "Numeric" Then
                                        refDetailViewItem.Value = sNuevoValorColumna
                                    End If
                                    If refDetailViewItem.Tag = "TimeDate" Then
                                        Dim dFecha As Date = Date.ParseExact(sNuevoValorColumna, oApp.FormatoFecha, System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat)
                                        refDetailViewItem.Text = dFecha
                                    Else
                                        refDetailViewItem.Text = sNuevoValorColumna
                                    End If
                                    iNumeroColumna += 1
                                End If
                            End If
                        End If
                    Next
                    dtDatos.Dispose()
                    refDataTable.Dispose()
                Case ServicesCentral.TiposContenido.Multiple
            End Select
        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message, MsgBoxStyle.Critical, "PoblarDetailView")
        Catch ExcB As Exception
            MsgBox(ExcB.Message, MsgBoxStyle.Critical, "PoblarDetailView")
        End Try
    End Sub

    Public Shared Sub LlenarElementosCombo(ByRef refComboResco As Resco.Controls.DetailView.ItemComboBox, ByVal parsValorReferencia As String)
        If refComboResco.ValueMember = "" Then
            Dim oArregloValores As ArrayList
            If parsValorReferencia <> "" Then
                oArregloValores = ValorReferencia.RecuperarListaArray(parsValorReferencia)
            End If
            refComboResco.DataSource = oArregloValores
            refComboResco.ValueMember = "Id"
            refComboResco.DisplayMember = "Cadena"
        End If
    End Sub
    Public Function CrearMenu(ByRef refparMenuItem As MenuItem, ByRef parconConDB As Conexion, ByVal parsClaveElemento As String) As Boolean
        Try
            ' Limpiar la lista
            refparMenuItem.MenuItems.Clear()
            Dim refaVistaElemento As VistaElemento
            If Not BuscarElemento(parsClaveElemento, refaVistaElemento, ServicesCentral.TiposContenido.Consulta) Then
                Exit Try
            End If
            Select Case refaVistaElemento.TipoContenido
                Case ServicesCentral.TiposContenido.Consulta
                    ' Recuperar los datos de la consulta SQL de la vista
                    Dim DataSetDatos As DataTable
                    DataSetDatos = RecuperarDatos(parconConDB, parsClaveElemento, "", ServicesCentral.TiposContenido.Consulta)
                    ' Verificar que existan datos
                    If DataSetDatos.Rows.Count = 0 Then
                        DataSetDatos.Dispose()
                        Exit Try
                    End If
                    ' Colocar el resultado en los menús
                    Dim refDataRow As DataRow
                    Dim MenuItemNuevo As MenuItem
                    ' Crear cada elemento del menú llenarlo con los elementos resultantes de la consulta
                    For Each refDataRow In DataSetDatos.Rows
                        MenuItemNuevo = New MenuItem
                        MenuItemNuevo.Text = refDataRow("ModuloDescripcion")
                        MenuItemNuevo.Checked = False
                        MenuItemNuevo.Enabled = True
                        refparMenuItem.MenuItems.Add(MenuItemNuevo)
                    Next
                    DataSetDatos.Dispose()
            End Select
            Return True
        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message, MsgBoxStyle.Critical, "CrearMenu")
        Catch ExcB As Exception
            MsgBox(ExcB.Message, MsgBoxStyle.Critical, "CrearMenu")
        End Try
        Return False
    End Function

    Public Function CrearMenuFiltro(ByRef refparMenuItem As MenuItem, ByRef parconConDB As Conexion, ByVal parsClaveElemento As String, ByRef refElementosFiltro As ArrayList, ByVal parsNombreCampoFiltro As String, ByVal parsNombreCampoMostrar As String) As Boolean
        Try
            ' Limpiar la lista
            refparMenuItem.MenuItems.Clear()
            Dim refaVistaElemento As VistaElemento
            If Not BuscarElemento(parsClaveElemento, refaVistaElemento, ServicesCentral.TiposContenido.Consulta) Then
                Exit Try
            End If
            Select Case refaVistaElemento.TipoContenido
                Case ServicesCentral.TiposContenido.Consulta
                    ' Recuperar los datos de la consulta SQL de la vista
                    Dim DataSetDatos As DataTable
                    DataSetDatos = RecuperarDatos(parconConDB, parsClaveElemento, "", ServicesCentral.TiposContenido.Consulta)
                    ' Verificar que existan datos
                    If DataSetDatos.Rows.Count = 0 Then
                        DataSetDatos.Dispose()
                        Exit Try
                    End If
                    ' Colocar el resultado en los menús
                    Dim i As Integer
                    Dim DataViewBusqueda As DataView = New DataView(DataSetDatos, "", parsNombreCampoFiltro, DataViewRowState.CurrentRows)
                    Dim iRowIndex As Integer
                    Dim sValorComparar As String
                    Dim MenuItemNuevo As MenuItem
                    For i = 0 To refElementosFiltro.Count - 1
                        sValorComparar = refElementosFiltro(i)
                        ' Buscar el elemento del arreglo en el DataView
                        iRowIndex = DataViewBusqueda.Find(sValorComparar)
                        ' Si lo encuentra
                        If iRowIndex <> -1 Then
                            ' Crear cada elemento del menú llenarlo con los elementos resultantes de la consulta
                            MenuItemNuevo = New MenuItem
                            MenuItemNuevo.Text = DataViewBusqueda(iRowIndex).Item(parsNombreCampoMostrar)
                            MenuItemNuevo.Checked = False
                            MenuItemNuevo.Enabled = True
                            refparMenuItem.MenuItems.Add(MenuItemNuevo)
                        End If
                    Next
                    DataSetDatos.Dispose()
                    DataViewBusqueda.Dispose()
            End Select
            Return True
        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message, MsgBoxStyle.Critical, "CrearMenuFiltro")
        Catch ExcB As Exception
            MsgBox(ExcB.Message, MsgBoxStyle.Critical, "CrearMenuFiltro")
        End Try
        Return False
    End Function

    Private Function RecuperarDatos(ByRef parconConDB As Conexion, ByVal parsClaveElemento As String, ByVal parsCondicion As String, Optional ByVal refeTipoContenido As ServicesCentral.TiposContenido = ServicesCentral.TiposContenido.NoDefinido) As DataTable
        'Dim DataSetResultado As DataSet
        Dim dtResultado As DataTable
        Dim sConsultaSQL As String = ""
        Try
            Dim refaVistaElemento As VistaElemento

            ' Recuperar los datos de la consulta SQL de la vista
            If BuscarElemento(parsClaveElemento, refaVistaElemento, refeTipoContenido) Then
                sConsultaSQL = refaVistaElemento.ConsultaSQL
                ' Ejecutar la consulta
                Dim iPosicion As Integer
                iPosicion = InStr(LCase(sConsultaSQL), "<c>")
                If iPosicion <> 0 Then
                    sConsultaSQL = sConsultaSQL.Replace("<c>", parsCondicion)
                Else
                    sConsultaSQL &= " " & parsCondicion
                End If
                dtResultado = parconConDB.RealizarConsultaSQL(sConsultaSQL, "Tabla")
                Return dtResultado
            End If
        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message & ": " & sConsultaSQL, MsgBoxStyle.Critical, "RecuperarDatos")
        Catch ExcB As Exception
            MsgBox(ExcB.Message & ": " & sConsultaSQL, MsgBoxStyle.Critical, "RecuperarDatos")
        End Try
        Return Nothing
    End Function

    Public Function RecuperarConsultaSQL(ByRef parconConDB As Conexion, ByVal parsClaveElemento As String, ByVal parsCondicion As String, Optional ByVal refeTipoContenido As ServicesCentral.TiposContenido = ServicesCentral.TiposContenido.NoDefinido) As String
        'Dim DataSetResultado As DataSet
        Dim sConsultaSQL As String = String.Empty
        Try
            Dim refaVistaElemento As VistaElemento
            ' Recuperar los datos de la consulta SQL de la vista
            If BuscarElemento(parsClaveElemento, refaVistaElemento, refeTipoContenido) Then
                sConsultaSQL = refaVistaElemento.ConsultaSQL
                ' Ejecutar la consulta
                Dim iPosicion As Integer
                iPosicion = InStr(LCase(sConsultaSQL), "<c>")
                If iPosicion <> 0 Then
                    sConsultaSQL = Mid(sConsultaSQL, 1, iPosicion - 1) & parsCondicion & Mid(sConsultaSQL, iPosicion + 3)
                Else
                    sConsultaSQL &= " " & parsCondicion
                End If
            End If
        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message & ": " & sConsultaSQL, MsgBoxStyle.Critical, "RecuperarConsultaSQL")
            sConsultaSQL = String.Empty
        Catch ExcB As Exception
            MsgBox(ExcB.Message & ": " & sConsultaSQL, MsgBoxStyle.Critical, "RecuperarConsultaSQL")
            sConsultaSQL = String.Empty
        End Try
        Return sConsultaSQL
    End Function

    Public Sub ColocarEtiquetasForma(ByRef refForma As Form)
        Try
            Dim refaVistaElemento As VistaElemento
            refForma.Visible = False
            ' Colocar las etiquetas solo para aquellos controles cuyo contenido es "Sencillo"
            For Each refaVistaElemento In aLista
                If refaVistaElemento.TipoContenido = ServicesCentral.TiposContenido.Sencillo Then
                    Select Case refaVistaElemento.TipoControl
                        Case ServicesCentral.TiposControl.Menu
                            BuscarMenu(refForma, refaVistaElemento.Nombre, refaVistaElemento.Texto)
                        Case ServicesCentral.TiposControl.MenuEmergente
                            BuscarMenuEmergente(refForma, refaVistaElemento.Nombre, refaVistaElemento.Texto)
                        Case Else
                            BuscarControl(refForma, refaVistaElemento.Nombre, refaVistaElemento.Texto)
                    End Select
                End If
            Next

        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message, MsgBoxStyle.Critical, "ColocarEtiquetasForma")
        Catch ExcB As Exception
            MsgBox(ExcB.Message, MsgBoxStyle.Critical, "ColocarEtiquetasForma")
        End Try

        ' Create a file for output named TestFile.txt.
        'Dim myFile As Stream = File.Create("TestFile.txt")

        '' Create a new text writer using the output stream, and add it to
        '' the trace listeners. 
        'Dim myTextListener As New DefaultTraceListener
        'myTextListener.Write(
        'Trace.Listeners.Add(myTextListener)
        '' Write output to the file.
        'Trace.Write("Test output ")
        '' Flush the output.
        'Trace.Flush()


        refForma.Visible = True
        refForma.Focus()
    End Sub

    Public Sub ColocarEtiquetasControl(ByRef refControl As Control)
        Try
            Dim refaVistaElemento As VistaElemento
            ' Colocar las etiquetas solo para aquellos controles cuyo contenido es "Sencillo"
            For Each refaVistaElemento In aLista
                If refaVistaElemento.Nombre = refControl.Text Then
                    If refaVistaElemento.TipoControl <> ServicesCentral.TiposControl.Menu And refaVistaElemento.TipoControl <> ServicesCentral.TiposControl.MenuEmergente Then
                        refControl.Text = refaVistaElemento.Texto
                        Exit For
                    End If
                End If
            Next
        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message, MsgBoxStyle.Critical, "ColocarEtiquetasControl")
        Catch ExcB As Exception
            MsgBox(ExcB.Message, MsgBoxStyle.Critical, "ColocarEtiquetasControl")
        End Try
    End Sub

    Public Sub ColocarEtiquetasMenuEmergente(ByVal refMenu As ContextMenu)
        Try
            Dim refaVistaElemento As VistaElemento
            For Each refaVistaElemento In aLista

                If refaVistaElemento.TipoControl = ServicesCentral.TiposControl.MenuEmergente Then

                    For Each m As MenuItem In refMenu.MenuItems
                        If m.Text = refaVistaElemento.Nombre Then
                            m.Text = refaVistaElemento.Texto
                            Exit For
                        End If
                    Next
                End If
            Next
        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message, MsgBoxStyle.Critical, "ColocarEtiquetasControl")
        Catch ExcB As Exception
            MsgBox(ExcB.Message, MsgBoxStyle.Critical, "ColocarEtiquetasControl")
        End Try
    End Sub


    Private Function BuscarControl(ByRef refControl As Control, ByVal parsNombreControl As String, ByVal parsValorControl As String) As Boolean
        Dim cControl As Control
        For Each cControl In refControl.Controls
            If UCase(cControl.Text) = UCase(parsNombreControl) Then
                cControl.Text = parsValorControl
                Return True
            End If
            ' Buscar en los controles que contiene este control
            If cControl.Controls.Count > 0 Then
                If BuscarControl(cControl, parsNombreControl, parsValorControl) Then
                    Return True
                End If
            End If
        Next
        Return False
    End Function

    Private Function BuscarMenu(ByRef refForma As Form, ByVal parsNombreMenu As String, ByVal parsValorMenu As String) As Boolean
        If Not (refForma.Menu Is Nothing) Then
            Dim refMenuItem As MenuItem
            For Each refMenuItem In refForma.Menu.MenuItems
                If BuscarMenuItem(refMenuItem, parsNombreMenu, parsValorMenu) Then
                    Return True
                End If
            Next
        End If
        Return False
    End Function

    Private Function BuscarMenuEmergente(ByRef refControl As Control, ByVal parsNombreMenu As String, ByVal parsValorMenu As String) As Boolean
        Try
            Dim cControl As Control
            For Each cControl In refControl.Controls
                If Not (cControl.ContextMenu Is Nothing) Then
                    Dim refMenuItem As MenuItem
                    For Each refMenuItem In cControl.ContextMenu.MenuItems
                        If BuscarMenuItem(refMenuItem, parsNombreMenu, parsValorMenu) Then
                            Return True
                        End If
                    Next
                End If
                ' Buscar en los controles que contiene este control
                If cControl.Controls.Count > 0 Then
                    If BuscarMenuEmergente(cControl, parsNombreMenu, parsValorMenu) Then
                        Return True
                    End If
                End If
            Next
        Catch ExcA As Exception
            MsgBox(ExcA.Message, MsgBoxStyle.Critical, "BuscarMenuEmergente")
        End Try
    End Function

    Private Function BuscarMenuItem(ByRef refparMenuItem As MenuItem, ByVal parsNombreMenu As String, ByVal parsValorMenu As String) As Boolean
        If UCase(refparMenuItem.Text) = UCase(parsNombreMenu) Then
            refparMenuItem.Text = parsValorMenu
            Return True
        End If
        If refparMenuItem.MenuItems.Count > 0 Then
            Dim refMenuItem As MenuItem
            For Each refMenuItem In refparMenuItem.MenuItems
                If BuscarMenuItem(refMenuItem, parsNombreMenu, parsValorMenu) Then
                    Return True
                End If
            Next
        End If
        Return False
    End Function

    Public Function BuscarMensaje(ByVal parsClaveElemento As String, ByVal parsClaveElementoDet As String) As String
        Dim refaElemento As VistaElemento
        Dim refaElementoDet As VistaElementoDet
        If BuscarElemento(parsClaveElemento, refaElemento) Then
            If refaElemento.BuscarElementoDet(parsClaveElementoDet, refaElementoDet) Then
                Return refaElementoDet.Texto
            End If
        End If
        Return "<Mensaje no disponible>"
    End Function

    Public Function BuscarMenuItemDefault(ByVal parsNombreListView As String, ByRef refparIndex As Short) As Boolean
        Dim refaVistaElemento As VistaElemento
        Dim refaVistaElementoDet As VistaElementoDet
        If BuscarElemento(parsNombreListView, refaVistaElemento) Then
            If refaVistaElemento.BuscarElementoDet("*", refaVistaElementoDet) Then
                refparIndex = refaVistaElementoDet.Indice
                Return True
            End If
        End If
        Return False
    End Function

    Public Shared Function Buscar(ByVal parsNombreVista As String, ByRef refparaVista As Vista) As Boolean
        Dim refaVista As Vista
        'FormProcesando.PubSubInformar("Un momento por favor", "Creando elementos de pantalla")
        refparaVista = Nothing
        For Each refaVista In aListaVistas
            If refaVista.Nombre = parsNombreVista Then
                refparaVista = refaVista
                Return True
            End If
        Next
        Return False
    End Function

    Public Function BuscarElemento(ByVal parsNombreElemento As String, ByRef refparResultado As VistaElemento, Optional ByVal refeTipoContenido As ServicesCentral.TiposContenido = ServicesCentral.TiposContenido.NoDefinido) As Boolean
        Dim refItem As VistaElemento
        refparResultado = Nothing
        For Each refItem In aLista
            If refItem.Nombre = parsNombreElemento Then
                If refeTipoContenido = ServicesCentral.TiposContenido.NoDefinido Then
                    refparResultado = refItem
                    Return True
                Else
                    If refeTipoContenido = refItem.TipoContenido Then
                        refparResultado = refItem
                        Return True
                    End If
                End If
            End If
        Next
        Return False
    End Function

    Public Class VistaElemento
        Inherits ServicesCentral.CVistaElemento

        Public Enum TiposEjecucionConsultaSQL
            NoDefinido = 0
            Normal = 1
            Totalizar = 2
        End Enum

        Protected sTexto As String
        Protected tTipoEjecucionConsultaSQL As TiposEjecucionConsultaSQL

        Public Property Texto() As String
            Get
                Return sTexto
            End Get
            Set(ByVal Value As String)
                sTexto = Value
            End Set
        End Property
        Public Property TipoEjecucionConsultaSQL() As TiposEjecucionConsultaSQL
            Get
                Return tTipoEjecucionConsultaSQL
            End Get
            Set(ByVal Value As TiposEjecucionConsultaSQL)
                tTipoEjecucionConsultaSQL = Value
            End Set
        End Property

        Public aLista As ArrayList

        Public Sub New(ByVal pariVistaElementoId As Integer, _
                            ByVal parsNombre As String, _
                            ByVal parsTexto As String, _
                            ByVal pareTipoControl As ServicesCentral.TiposControl, _
                            ByVal pareTipoContenido As ServicesCentral.TiposContenido, _
                            ByVal parsConsultaSQL As String)
            VistaElementoId = pariVistaElementoId
            Nombre = parsNombre
            Texto = parsTexto
            TipoControl = pareTipoControl
            TipoContenido = pareTipoContenido
            ConsultaSQL = parsConsultaSQL
            TipoEjecucionConsultaSQL = TiposEjecucionConsultaSQL.NoDefinido
            aLista = New ArrayList
        End Sub

        Public Function BuscarElementoDet(ByVal parsNombreElementoDet As String, ByRef refparResultado As VistaElementoDet) As Boolean
            Dim refItem As VistaElementoDet
            refparResultado = Nothing
            For Each refItem In aLista
                If refItem.Nombre.Trim() = parsNombreElementoDet.Trim() Then
                    refparResultado = refItem
                    Return True
                End If
            Next
            Return False
        End Function

    End Class

    Public Class VistaElementoDet
        Inherits ServicesCentral.CVistaElementoDet

        Protected sTexto As String

        Public Property Texto() As String
            Get
                Return sTexto
            End Get
            Set(ByVal Value As String)
                sTexto = Value
            End Set
        End Property

        Public Sub New(ByVal pariVistaElementoDetId As Integer, _
                            ByVal parsNombre As String, _
                            ByVal parsTexto As String, _
                            ByVal pariIndice As Short, _
                            ByVal pariAncho As Short, _
                            ByVal pareTipoControl As ServicesCentral.TiposControlDetalle, _
                            ByVal pareTipoEdicion As ServicesCentral.TiposEdicion, _
                            ByVal pareTipoVisible As ServicesCentral.TiposVisible, _
                            ByVal pareTipoAlineacion As ServicesCentral.TiposAlineacion)
            VistaElementoDetId = pariVistaElementoDetId
            Nombre = parsNombre
            Texto = parsTexto
            Indice = pariIndice
            Ancho = pariAncho
            TipoControl = pareTipoControl
            TipoEdicion = pareTipoEdicion
            TipoVisible = pareTipoVisible
            TipoAlineacion = pareTipoAlineacion
        End Sub

    End Class

End Class
