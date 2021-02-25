
Public Class clsRequerimiento
#Region "Privado"
    Private _ID As Integer
    Private _Descripcion As String
    Private _ProyectoID As Integer
    Private _ProductoID As Integer
    Private _ModuloID As Integer
    Private _Funcionalidad As Integer
    Private _Fuente As String
    Private _Creado As DateTime
    Private _UltimaAct As DateTime
    Private _Version As String
    Private _Folio As String
    Private _Prioridad As Short
    Private _Estado As Short
    Private _TablaCU As DataTable
    Private _TablaCP As DataTable
    Private _TablaE As DataTable
    Private _TablaCO As DataTable
    Private _TablaVer As DataTable
    Private _Folios As DataTable
    Private _TablaMod As DataTable
    Private _TablaCli As DataTable

    Private DB As clsDB
#End Region

#Region "Propiedades"
    Public Property ID() As Integer
        Get
            Return _ID
        End Get
        Set(ByVal value As Integer)
            _ID = value
        End Set
    End Property
    Public Property Descripcion() As String
        Get
            Return _Descripcion
        End Get
        Set(ByVal value As String)
            _Descripcion = value
        End Set
    End Property
    Public Property Proyecto() As Integer
        Get
            Return _ProyectoID
        End Get
        Set(ByVal value As Integer)
            _ProyectoID = value
        End Set
    End Property
    Public Property Producto() As Integer
        Get
            Return _ProductoID
        End Get
        Set(ByVal value As Integer)
            _ProductoID = value
        End Set
    End Property
    Public Property Modulo() As Integer
        Get
            Return _ModuloID
        End Get
        Set(ByVal value As Integer)
            _ModuloID = value
        End Set
    End Property
    Public Property Funcionalidad() As Integer
        Get
            Return _Funcionalidad
        End Get
        Set(ByVal value As Integer)
            _Funcionalidad = value
        End Set
    End Property
    Public Property Fuente() As String
        Get
            Return _Fuente
        End Get
        Set(ByVal value As String)
            _Fuente = value.Trim()
        End Set
    End Property
    Public Property Version() As String
        Get
            Return _Version
        End Get
        Set(ByVal value As String)
            _Version = value.Trim()
        End Set
    End Property
    Public Property Folio() As String
        Get
            Return _Folio
        End Get
        Set(ByVal value As String)
            _Folio = value
        End Set
    End Property
    Public ReadOnly Property Creado() As DateTime
        Get
            Return _Creado
        End Get
    End Property
    Public ReadOnly Property UltimaActualizacion() As DateTime
        Get
            Return _UltimaAct
        End Get
    End Property
    
    Public Property Prioridad() As Short
        Get
            Return _Prioridad
        End Get
        Set(ByVal value As Short)
            _Prioridad = value
        End Set
    End Property
    Public Property Estado() As Short
        Get
            Return _Estado
        End Get
        Set(ByVal value As Short)
            _Estado = value
        End Set
    End Property
    Public Property Folios() As DataTable
        Get
            Return _Folios
        End Get
        Set(ByVal value As DataTable)
            _Folios = value
        End Set
    End Property
    Public Property CasosUso() As DataTable
        Get
            Return _TablaCU
        End Get
        Set(ByVal value As DataTable)
            _TablaCU = value
        End Set
    End Property
    Public Property CasosPrueba() As DataTable
        Get
            Return _TablaCP
        End Get
        Set(ByVal value As DataTable)
            _TablaCP = value
        End Set
    End Property
    Public Property Especificaciones() As DataTable
        Get
            Return _TablaE
        End Get
        Set(ByVal value As DataTable)
            _TablaE = value
        End Set
    End Property
    Public Property Componentes() As DataTable
        Get
            Return _TablaCO
        End Get
        Set(ByVal value As DataTable)
            _TablaCO = value
        End Set
    End Property
    Public Property Versiones() As DataTable
        Get
            Return _TablaVer
        End Get
        Set(ByVal value As DataTable)
            _TablaVer = value
        End Set
    End Property
    Public Property Modulos() As DataTable
        Get
            Return _TablaMod
        End Get
        Set(ByVal value As DataTable)
            _TablaMod = value
        End Set
    End Property
    Public Property Clientes() As DataTable
        Get
            Return _TablaCli
        End Get
        Set(ByVal value As DataTable)
            _TablaCli = value
        End Set
    End Property

#End Region

#Region "Methods"

    Public Sub New(ByVal cadenaConexion As String)
        DB = New clsDB(cadenaConexion)

    End Sub


    Public Sub InsertarReq()
        Try
            With DB
                .AddParameter("@ID", SqlDbType.Int, "", ParameterDirection.Output)
                .AddParameter("@Descripcion", SqlDbType.VarChar, Descripcion)
                .AddParameter("@ProyectoID", SqlDbType.Int, Proyecto)
                .AddParameter("@ProductoID", SqlDbType.Int, Producto)
                .AddParameter("@FuncionalidadID", SqlDbType.Int, Funcionalidad)
                .AddParameter("@Fuente", SqlDbType.VarChar, Fuente)
                .AddParameter("@User", SqlDbType.VarChar, System.Web.HttpContext.Current.Session("User"))
                .AddParameter("@Prioridad", SqlDbType.SmallInt, Prioridad)
                .AddParameter("@Estado", SqlDbType.SmallInt, Estado)
                .ExecuteCmd("CrearRequerimiento", CommandType.StoredProcedure)
                'If actualizarRelaciones() Then
                ID = .GetOutParameter("@ID")
                'Else
                '    Throw New Exception("Se ha producido un error al agregar las relaciones del request, ningun cambio sera realizado en la base de datos!!!")
                'End If
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub EditarReq(Optional ByVal nota As String = "")
        Try
            With DB
                .AddParameter("@ID", SqlDbType.Int, ID)
                .AddParameter("@Descripcion", SqlDbType.VarChar, Descripcion)
                .AddParameter("@ProyectoID", SqlDbType.Int, Proyecto)
                .AddParameter("@ProductoID", SqlDbType.Int, Producto)
                .AddParameter("@FuncionalidadID", SqlDbType.Int, Funcionalidad)
                .AddParameter("@Fuente", SqlDbType.VarChar, Fuente)
                .AddParameter("@User", SqlDbType.VarChar, System.Web.HttpContext.Current.Session("User"))
                .AddParameter("@Nota", SqlDbType.VarChar, nota)
                .AddParameter("@Prioridad", SqlDbType.SmallInt, Prioridad)
                .AddParameter("@Estado", SqlDbType.SmallInt, Estado)

                .ExecuteCmd("EditarRequerimiento", CommandType.StoredProcedure)
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub eliminarReq()
        Try
            With DB
                .AddParameter("@ID", SqlDbType.Int, ID)
                .ExecuteCmd("EliminarRequerimiento", CommandType.StoredProcedure)
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function actualizarRelaciones() As Boolean
        Try
            Dim ds As New DataSet

            ds.Clear()
            With DB
                If Not IsNothing(CasosUso) Then
                    If CasosUso.Rows.Count > 0 Then
                        ds.Tables.Add(CasosUso)
                    End If
                End If
                .AddParameter("@Tabla", SqlDbType.Text, IIf(ds.Tables.Count > 0, ds.GetXml, ""))
                .AddParameter("@IDReq", SqlDbType.Int, ID)
                .ExecuteCmd("AgregarRelacionCasoUso", CommandType.StoredProcedure)
            End With

            ds.Clear()
            With DB
                If Not IsNothing(CasosPrueba) Then
                    If CasosPrueba.Rows.Count > 0 Then
                        ds.Tables.Add(CasosPrueba)
                    End If
                End If
                .AddParameter("@Tabla", SqlDbType.Text, IIf(ds.Tables.Count > 0, ds.GetXml, ""))
                .AddParameter("@IDReq", SqlDbType.Int, ID)
                .ExecuteCmd("AgregarRelacionCasoPrueba", CommandType.StoredProcedure)
            End With

            ds.Clear()
            With DB
                If Not IsNothing(Especificaciones) Then
                    If Especificaciones.Rows.Count > 0 Then
                        ds.Tables.Add(Especificaciones)
                    End If
                End If
                .AddParameter("@Tabla", SqlDbType.Text, IIf(ds.Tables.Count > 0, ds.GetXml, ""))
                .AddParameter("@IDReq", SqlDbType.Int, ID)
                .ExecuteCmd("AgregarRelacionEspecificacion", CommandType.StoredProcedure)
            End With

            ds.Clear()
            With DB
                If Not IsNothing(Componentes) Then
                    If Componentes.Rows.Count > 0 Then
                        ds.Tables.Add(Componentes)
                    End If
                End If
                .AddParameter("@Tabla", SqlDbType.Text, IIf(ds.Tables.Count > 0, ds.GetXml, ""))
                .AddParameter("@IDReq", SqlDbType.Int, ID)
                .ExecuteCmd("AgregarRelacionComponente", CommandType.StoredProcedure)
            End With

            ds.Clear()
            With DB
                If Not IsNothing(Versiones) Then
                    If Versiones.Rows.Count > 0 Then
                        ds.Tables.Add(Versiones)
                    End If
                End If
                .AddParameter("@Tabla", SqlDbType.Text, IIf(ds.Tables.Count > 0, ds.GetXml, ""))
                .AddParameter("@IDReq", SqlDbType.Int, ID)
                .ExecuteCmd("AgregarRelacionVersion", CommandType.StoredProcedure)
            End With

            ds.Clear()
            With DB
                If Not IsNothing(Folios) Then
                    If Folios.Rows.Count > 0 Then
                        ds.Tables.Add(Folios)
                    End If
                End If
                .AddParameter("@Tabla", SqlDbType.Text, IIf(ds.Tables.Count > 0, ds.GetXml, ""))
                .AddParameter("@IDReq", SqlDbType.Int, ID)
                .ExecuteCmd("AgregarRelacionFolio", CommandType.StoredProcedure)
            End With

            ds.Clear()
            With DB
                If Not IsNothing(Modulos) Then
                    If Modulos.Rows.Count > 0 Then
                        ds.Tables.Add(Modulos)
                    End If
                End If
                .AddParameter("@Tabla", SqlDbType.Text, IIf(ds.Tables.Count > 0, ds.GetXml, ""))
                .AddParameter("@IDReq", SqlDbType.Int, ID)
                .ExecuteCmd("AgregarRelacionModulo", CommandType.StoredProcedure)
            End With

            ds.Clear()
            With DB
                If Not IsNothing(Clientes) Then
                    If Clientes.Rows.Count > 0 Then
                        ds.Tables.Add(Clientes)
                    End If
                End If
                .AddParameter("@Tabla", SqlDbType.Text, IIf(ds.Tables.Count > 0, ds.GetXml, ""))
                .AddParameter("@IDReq", SqlDbType.Int, ID)
                .ExecuteCmd("AgregarRelacionCliente", CommandType.StoredProcedure)
            End With

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Sub llenarObjeto()
        Try
            With DB
                .AddParameter("@ID", SqlDbType.Int, ID)
                .AddParameter("@Descripcion", SqlDbType.VarChar, 100, "", ParameterDirection.Output)
                .AddParameter("@ProyectoID", SqlDbType.Int, "", ParameterDirection.Output)
                .AddParameter("@ProductoID", SqlDbType.Int, "", ParameterDirection.Output)
                .AddParameter("@FuncionalidadID", SqlDbType.Int, "", ParameterDirection.Output)
                .AddParameter("@Fuente", SqlDbType.VarChar, 20, "", ParameterDirection.Output)
                .AddParameter("@Prioridad", SqlDbType.SmallInt, "", ParameterDirection.Output)
                .AddParameter("@Estado", SqlDbType.SmallInt, "", ParameterDirection.Output)

                .ExecuteCmd("obtenerDatosRequerimiento", CommandType.StoredProcedure)

                Descripcion = .GetOutParameter("@Descripcion").ToString.Trim
                Proyecto = .GetOutParameter("@ProyectoID")
                Producto = .GetOutParameter("@ProductoID")
                Funcionalidad = .GetOutParameter("@FuncionalidadID")
                Fuente = .GetOutParameter("@Fuente").ToString.Trim
                Prioridad = .GetOutParameter("@Prioridad")
                Estado = .GetOutParameter("@Estado")

            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function obtenerFolios() As DataTable
        Try
            With DB
                .AddParameter("@ID", SqlDbType.Int, ID)
                Return .ToDatatable("obtenerFolios", CommandType.StoredProcedure)

            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function obtenerFolios(ByVal ID As String) As DataTable
        Try
            With DB
                .AddParameter("@ID", SqlDbType.Int, ID)
                Return .ToDatatable("obtenerFolios", CommandType.StoredProcedure)

            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function obtenerRequerimientos(Optional ByVal DATEB As String = "", Optional ByVal DATEE As String = "") As DataTable
        Try
            With DB
                .AddParameter("@ID", SqlDbType.Int, ID)
                .AddParameter("@Funcionalidad", SqlDbType.Int, Funcionalidad)
                .AddParameter("@Modulo", SqlDbType.Int, Modulo)
                .AddParameter("@Fuente", SqlDbType.VarChar, Fuente)
                .AddParameter("@Producto", SqlDbType.Int, Producto)
                .AddParameter("@Proyecto", SqlDbType.Int, Proyecto)
                .AddParameter("@Descripcion", SqlDbType.VarChar, Descripcion)
                .AddParameter("@DateB", SqlDbType.VarChar, DATEB)
                .AddParameter("@DateE", SqlDbType.VarChar, DATEE)
                .AddParameter("@Folio", SqlDbType.VarChar, Folio)
                .AddParameter("@Version", SqlDbType.VarChar, Version)

                Return .ToDatatable("filtrarRequerimientos", CommandType.StoredProcedure)
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

End Class
