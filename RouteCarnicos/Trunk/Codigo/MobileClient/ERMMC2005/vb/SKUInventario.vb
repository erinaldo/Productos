Public Class SKUInventario
    Implements IDisposable

    Private sCodigoSKU As String
    Private sProductoClave As String
    Private nTipoUnidad As Integer
    Private nDisponible As Decimal
    Private nApartado As Decimal
    Private nCantidad As Decimal
    Private nApartado1 As Decimal
    'Private nFactor As Decimal

    Public Property CodigoSKU() As String
        Get
            Return sCodigoSKU
        End Get
        Set(ByVal value As String)
            sCodigoSKU = value
        End Set
    End Property
    Public Property ProductoClave() As String
        Get
            Return sProductoClave
        End Get
        Set(ByVal value As String)
            sProductoClave = value
        End Set
    End Property
    Public Property TipoUnidad() As Integer
        Get
            Return nTipoUnidad
        End Get
        Set(ByVal value As Integer)
            nTipoUnidad = value
        End Set
    End Property
    Public Property Disponible() As Decimal
        Get
            Return nDisponible
        End Get
        Set(ByVal value As Decimal)
            nDisponible = value
        End Set
    End Property
    Public Property Apartado() As Decimal
        Get
            Return nApartado
        End Get
        Set(ByVal value As Decimal)
            nApartado = value
        End Set
    End Property

    Public Property Cantidad() As Decimal
        Get
            Return nCantidad
        End Get
        Set(ByVal value As Decimal)
            nCantidad = value
        End Set
    End Property
    Public Property Apartado1() As Decimal
        Get
            Return nApartado1
        End Get
        Set(ByVal value As Decimal)
            nApartado1 = value
        End Set
    End Property
    'Public Property Factor() As Decimal
    '    Get
    '        Return nFactor
    '    End Get
    '    Set(ByVal value As Decimal)
    '        nFactor = value
    '    End Set
    'End Property


    Public Sub New()
        CodigoSKU = ""
        ProductoClave = ""
        TipoUnidad = 0
        Disponible = 0
        Apartado = 0
        Cantidad = 0
        Apartado1 = 0
        'Factor = 0
    End Sub


    Enum SKUMovimiento
        Incrementar = 1
        Apartar = 2
        Decrementar = 3
    End Enum
    Enum TipoExistencia
        Ninguno = 0
        Unidad = 1
        Cantidad = 2
    End Enum


    Public Shared Function ExisteSKU(ByVal IP_CodigoSKU As String, ByVal IP_ProductoClave As String, ByVal IP_TipoUnidad As Integer) As Boolean

        Return IIf(oDBVen.EjecutarCmdScalarIntSQL("select count(*) from SKUInventario where CodigoSKU='" & IP_CodigoSKU & "' and ProductoClave='" & IP_ProductoClave & "' and TipoUnidad='" & IP_TipoUnidad & "'") > 0, True, False)
    End Function

    Public Shared Function ExisteSKU(ByVal IP_CodigoSKU As String) As Boolean
        Return IIf(oDBVen.EjecutarCmdScalarIntSQL("select count(*) from SKUInventario where CodigoSKU='" & IP_CodigoSKU & "' ") > 0, True, False)
    End Function

    Public Shared Function SoloSKU(ByVal parProductoClave As String, ByVal parTransprodId As String) As Boolean
        Return IIf(oDBVen.EjecutarCmdScalarIntSQL("select count(*) from transproddetalle where codigoSKU ='' and productoclave='" & parProductoClave & "' and transprodid= '" & parTransprodId & "'") > 0, False, True)
    End Function

    Public Shared Function ExistenciaDisponible(ByVal IP_ProductoClave As String) As Boolean
        Dim sku As SKUInventario
        sku = SKUInventario.RecuperarProductoClave(IP_ProductoClave)

        If RedondeoAritmetico(sku.Cantidad - sku.Apartado1, 2) > 0 And RedondeoAritmetico(sku.Disponible - sku.Apartado, 2) > 0 Then
            sku.Dispose()
            sku = Nothing
            Return True
        End If

        sku.Dispose()
        sku = Nothing
        Return False
    End Function


    Public Shared Function ValidarExistenciaDisponible(ByVal IP_CodigoSKU As String, ByVal IP_ProductoClave As String, ByVal IP_TipoUnidad As Integer, ByVal IP_Cantidad As Decimal, ByVal IP_Cantidad1 As Decimal) As TipoExistencia
        Dim sku As SKUInventario
        sku = SKUInventario.Recuperar(IP_CodigoSKU, IP_ProductoClave, IP_TipoUnidad)
        If Math.Round(IP_Cantidad, 2) <= Math.Round(sku.Disponible - sku.Apartado, 2) And Math.Round(IP_Cantidad1, 2) <= Math.Round(sku.Cantidad - sku.Apartado1, 2) Then
            Return TipoExistencia.Ninguno
        End If

        Dim Tipo As TipoExistencia = TipoExistencia.Cantidad
        If Math.Round(IP_Cantidad, 2) <= Math.Round(sku.Disponible - sku.Apartado, 2) Then
            Tipo = TipoExistencia.Unidad
        End If

        sku.Dispose()
        sku = Nothing
        Return Tipo
    End Function

    Public Shared Function ValidarExistenciaDisponibleASurtir(ByVal IP_CodigoSKU As String, ByVal IP_ProductoClave As String, ByVal IP_TipoUnidad As Integer, ByVal IP_Cantidad As Double) As Boolean
        If IP_Cantidad <= 0 Then Return False

        Using dt As DataTable = oDBVen.RealizarConsultaSQL("select Round(Disponible,2)  as Disponible, Round(apartado,2) as Apartado from SKUInventario where CodigoSKU='" & IP_CodigoSKU & "' and ProductoClave='" & IP_ProductoClave & "' and TipoUnidad='" & IP_TipoUnidad & "'", "SKUInventario")
            If dt Is Nothing OrElse dt.Rows.Count <= 0 Then Return False

            With dt.Rows(0)

                If Math.Round(CDbl(.Item("Disponible")), 2) >= Math.Round(CDbl(.Item("Apartado")), 2) AndAlso Math.Round(CDbl(.Item("Apartado")), 2) >= Math.Round(IP_Cantidad, 2) Then
                    Return True
                End If

            End With
        End Using

        Return False
    End Function

    Public Shared Function ActualizarSKU(ByVal IP_Movimiento As SKUMovimiento, ByVal IP_CodigoSKU As String, ByVal IP_ProductoClave As String, ByVal IP_TipoUnidad As Integer, ByVal IP_Cantidad As Double, ByVal IP_Cantidad1 As Double, Optional ByRef sCadena As String = "") As Boolean

        Dim cmd As New System.Text.StringBuilder

        Select Case IP_Movimiento
            Case SKUMovimiento.Incrementar
                If Not SKUInventario.ExisteSKU(IP_CodigoSKU, IP_ProductoClave, IP_TipoUnidad) Then
                    cmd.Append("Insert into SKUInventario(CodigoSKU, ProductoClave, TipoUnidad, Cantidad, Disponible, Apartado, Apartado1) values('" & IP_CodigoSKU & "','" & IP_ProductoClave & "','" & IP_TipoUnidad & "',Round(" & IP_Cantidad1 & ",2),Round(" & IP_Cantidad & ",2), 0, 0)")
                Else
                    cmd.Append("update SKUInventario set Disponible = Round(Disponible + " & IP_Cantidad & ",2), Cantidad = Round(Cantidad + " & IP_Cantidad1 & ",2) where CodigoSKU = '" & IP_CodigoSKU & "' and ProductoClave = '" & IP_ProductoClave & "' and TipoUnidad = " & IP_TipoUnidad & "")
                End If

            Case SKUMovimiento.Apartar
                If Not SKUInventario.ExisteSKU(IP_CodigoSKU, IP_ProductoClave, IP_TipoUnidad) Then
                    cmd.Append("Insert into SKUInventario(CodigoSKU, ProductoClave, TipoUnidad, Cantidad, Disponible, Apartado, Apartado1) values('" & IP_CodigoSKU & "','" & IP_ProductoClave & "','" & IP_TipoUnidad & "', 0, 0,Round(" & IP_Cantidad & ",2), Round(" & IP_Cantidad1 & ",2) )")
                Else
                    cmd.Append("update SKUInventario set Apartado = Round(Apartado + " & IP_Cantidad & ",2), Apartado1 = Round(Apartado1 + " & IP_Cantidad1 & " ,2) where CodigoSKU = '" & IP_CodigoSKU & "' and ProductoClave = '" & IP_ProductoClave & "' and TipoUnidad = " & IP_TipoUnidad & "")
                End If

            Case SKUMovimiento.Decrementar
                'If ValidarExistenciaDisponible(IP_CodigoSKU, IP_ProductoClave, IP_TipoUnidad, IP_Cantidad, IP_Cantidad1) = TipoExistencia.Ninguno Then
                cmd.Append("update SKUInventario set Disponible = Round(Disponible - " & IP_Cantidad & ",2), Cantidad = Round(Cantidad - " & IP_Cantidad1 & ",2) where CodigoSKU = '" & IP_CodigoSKU & "' and ProductoClave = '" & IP_ProductoClave & "' and TipoUnidad = " & IP_TipoUnidad & "")
                'End If

        End Select

        sCadena &= cmd.ToString & vbCrLf

        If oDBVen.EjecutarComandoSQL(cmd.ToString) = 0 Then
            Return False
        End If

        Return True
    End Function

    Public Shared Sub CargarSKUInventarioReparto()
        Try
            oVendedor.RecuperarParametros(True)

            If oDBVen.oConexion.State = ConnectionState.Closed Then
                oDBVen.oConexion.Open()
            End If
            oDBVen.Transaccion = oDBVen.oConexion.BeginTransaction()

            If oVendedor.TipoModulo = ServicesCentral.TiposModulos.Distribucion Then
                Dim ldtTransProdDetalle As DataTable = oDBVen.RealizarConsultaSQL("Select td.CodigoSKU, td.ProductoClave, td.TipoUnidad, td.Cantidad, td.Cantidad1 from TransProdDetalle td inner join transprod t on t.transprodid=td.transprodid  where Tipo=1 and TipoFase=1", "PEDIDO")

                For Each ldr As DataRow In ldtTransProdDetalle.Rows
                    SKUInventario.ActualizarSKU(SKUInventario.SKUMovimiento.Apartar, ldr("CodigoSKU").ToString, ldr("ProductoClave"), ldr("TipoUnidad"), ldr("Cantidad"), ldr("Cantidad1"))
                Next

            End If
            oDBVen.Transaccion.Commit()
        Catch ex As Exception
            If Not IsNothing(oDBVen.Transaccion) Then
                oDBVen.Transaccion.Rollback()
            End If
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

        If Not IsNothing(oDBVen.Transaccion) Then
            oDBVen.Transaccion.Dispose()
            oDBVen.Transaccion = Nothing
        End If
    End Sub

    Public Shared Function CargarSKUInventarioCargas() As Boolean
        Dim ldtCargas As DataTable = oDBVen.RealizarConsultaSQL("Select distinct TPD.TransProdId, TPD.TransProdDetalleId, TPD.ProductoClave, TPD.TipoUnidad, TPD.Cantidad,codigoSKU,TPD.Cantidad1 from TransProd TP Inner Join TransProdDetalle TPD ON TP.TransProdId=TPD.TransProdId and TP.Tipo=2 and TP.TipoFase=5 and TP.MUsuarioId='" & oVendedor.UsuarioId & "'", "Cargas")

        Try
            If oDBVen.oConexion.State = ConnectionState.Closed Then
                oDBVen.oConexion.Open()
            End If
            oDBVen.Transaccion = oDBVen.oConexion.BeginTransaction()

            If ldtCargas.Rows.Count > 0 Then
                Dim oArr As New ArrayList
                Dim sTransProdId As String = String.Empty

                For Each oDr As DataRow In ldtCargas.Rows
                    SKUInventario.ActualizarSKU(SKUInventario.SKUMovimiento.Incrementar, oDr("CodigoSKU").ToString, oDr("ProductoClave"), oDr("TipoUnidad"), oDr("Cantidad"), oDr("Cantidad1"))
                    If Not oArr.Contains(oDr("TransProdId")) Then
                        oArr.Add(oDr("TransProdId"))
                        sTransProdId &= "'" & oDr("TransProdId") & "',"
                    End If
                Next

                If sTransProdId <> String.Empty Then
                    sTransProdId = Microsoft.VisualBasic.Left(sTransProdId, sTransProdId.Length - 1)
                    oDBVen.EjecutarComandoSQL("Update TransProd Set TipoFase=1, Notas = null, Enviado=0, MFechaHora = getdate() where TransProdId in(" & sTransProdId & ")")
                    oDBVen.EjecutarComandoSQL("Update TransProdDetalle Set Enviado=0, MFechaHora = getdate() where TransProdId in(" & sTransProdId & ")")
                End If

            End If

            oDBVen.Transaccion.Commit()
        Catch ex As Exception
            oDBVen.Transaccion.Rollback()
            ldtCargas.Dispose()
            ldtCargas = Nothing
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return False
        End Try

        If Not IsNothing(oDBVen.Transaccion) Then
            oDBVen.Transaccion.Dispose()
            oDBVen.Transaccion = Nothing
        End If

        ldtCargas.Dispose()
        ldtCargas = Nothing
        Return True
    End Function

    Public Shared Function Recuperar(ByVal IP_CodigoSKU As String) As SKUInventario
        Dim dtSKU As DataTable
        Dim oSKUInventario As New SKUInventario
        Dim sConsulta As String = ""
        sConsulta = "select SKU.CodigoSKU, SKU.ProductoClave, SKU.TipoUnidad, SKU.Disponible, SKU.Apartado, SKU.Cantidad, SKU.Apartado1 "
        sConsulta &= "from SKUInventario SKU "
        'sConsulta &= "inner join ProductoDetalle PRD on SKU.ProductoClave = PRD.ProductoClave and PRD.ProductoClave = PRD.ProductoDetClave and SKU.TipoUnidad = PRD.PRUTipoUnidad "
        sConsulta &= "where SKU.CodigoSKU = '" & IP_CodigoSKU & "' "

        dtSKU = oDBVen.RealizarConsultaSQL(sConsulta, "SKUInventario")
        If dtSKU.Rows.Count > 0 Then
            oSKUInventario.CodigoSKU = dtSKU.Rows(0)("CodigoSKU")
            oSKUInventario.ProductoClave = dtSKU.Rows(0)("ProductoClave")
            oSKUInventario.TipoUnidad = dtSKU.Rows(0)("TipoUnidad")
            oSKUInventario.Disponible = dtSKU.Rows(0)("Disponible")
            oSKUInventario.Apartado = dtSKU.Rows(0)("Apartado")
            oSKUInventario.Cantidad = dtSKU.Rows(0)("Cantidad")
            oSKUInventario.Apartado1 = dtSKU.Rows(0)("Apartado1")
            'oSKUInventario.Factor = dtSKU.Rows(0)("Factor")
        End If

        Return oSKUInventario
    End Function

    Public Shared Function RecuperarProductoClave(ByVal IP_ProductoClave As String) As SKUInventario
        Dim dtSKU As DataTable
        Dim oSKUInventario As New SKUInventario
        Dim sConsulta As String = ""
        sConsulta = "select SKU.CodigoSKU, SKU.ProductoClave, SKU.TipoUnidad, SKU.Disponible, SKU.Apartado, SKU.Cantidad, SKU.Apartado1 "
        sConsulta &= "from SKUInventario SKU "
        'sConsulta &= "inner join ProductoDetalle PRD on SKU.ProductoClave = PRD.ProductoClave and PRD.ProductoClave = PRD.ProductoDetClave and SKU.TipoUnidad = PRD.PRUTipoUnidad "
        sConsulta &= "where SKU.ProductoClave = '" & IP_ProductoClave & "' and (Disponible-Apartado) >0 and (Cantidad-Apartado1)>0"

        dtSKU = oDBVen.RealizarConsultaSQL(sConsulta, "SKUInventario")
        If dtSKU.Rows.Count > 0 Then
            oSKUInventario.CodigoSKU = dtSKU.Rows(0)("CodigoSKU")
            oSKUInventario.ProductoClave = dtSKU.Rows(0)("ProductoClave")
            oSKUInventario.TipoUnidad = dtSKU.Rows(0)("TipoUnidad")
            oSKUInventario.Disponible = dtSKU.Rows(0)("Disponible")
            oSKUInventario.Apartado = dtSKU.Rows(0)("Apartado")
            oSKUInventario.Cantidad = dtSKU.Rows(0)("Cantidad")
            oSKUInventario.Apartado1 = dtSKU.Rows(0)("Apartado1")
            'oSKUInventario.Factor = dtSKU.Rows(0)("Factor")
        End If

        Return oSKUInventario
    End Function

    Public Shared Function Recuperar(ByVal IP_CodigoSKU As String, ByVal IP_ProductoClave As String, ByVal IP_TipoUnidad As Integer) As SKUInventario
        Dim dtSKU As DataTable
        Dim oSKUInventario As New SKUInventario
        Dim sConsulta As String = ""
        sConsulta = "select SKU.CodigoSKU, SKU.ProductoClave, SKU.TipoUnidad, SKU.Disponible, SKU.Apartado, SKU.Cantidad, SKU.Apartado1 "
        sConsulta &= "from SKUInventario SKU "
        'sConsulta &= "inner join ProductoDetalle PRD on SKU.ProductoClave = PRD.ProductoClave and PRD.ProductoClave = PRD.ProductoDetClave and SKU.TipoUnidad = PRD.PRUTipoUnidad "
        sConsulta &= "where SKU.ProductoClave = '" & IP_ProductoClave & "' and codigoSKU='" & IP_CodigoSKU & "' and tipoUnidad = " & IP_TipoUnidad & " "

        dtSKU = oDBVen.RealizarConsultaSQL(sConsulta, "SKUInventario")
        If dtSKU.Rows.Count > 0 Then
            oSKUInventario.CodigoSKU = dtSKU.Rows(0)("CodigoSKU")
            oSKUInventario.ProductoClave = dtSKU.Rows(0)("ProductoClave")
            oSKUInventario.TipoUnidad = dtSKU.Rows(0)("TipoUnidad")
            oSKUInventario.Disponible = dtSKU.Rows(0)("Disponible")
            oSKUInventario.Apartado = dtSKU.Rows(0)("Apartado")
            oSKUInventario.Cantidad = dtSKU.Rows(0)("Cantidad")
            oSKUInventario.Apartado1 = dtSKU.Rows(0)("Apartado1")
            'oSKUInventario.Factor = dtSKU.Rows(0)("Factor")
        End If

        Return oSKUInventario
    End Function

    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free managed resources when explicitly called
            End If

            ' TODO: free shared unmanaged resources
        End If
        Me.disposedValue = True
    End Sub

#Region " IDisposable Support "
    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class
