Imports System.Data.SqlServerCe
Imports Resco.Controls
Imports System.Xml
Imports System.IO

Public Class SubEmpresa

    ' Arreglo para acceder a las descripciones de los tipos (valores por referencia)
    Public Shared aSubEmpresa As New ArrayList

    Public Class DatosEmpresa
        Protected sSubEmpresaId As String
        Protected sNombreEmpresa As String
        Protected sRFC As String
        Protected sPais As String
        Protected sRegion As String
        Protected sLocalidad As String
        Protected sReferenciaDom As String
        Protected sCiudad As String
        Protected sColonia As String
        Protected sCalle As String
        Protected sNumero As String
        Protected sNumeroInterior As String
        Protected sCodigoPostal As String
        Protected sTelefono As String
        Protected nVersionCFD As Integer
        Protected sCerBase64 As String

        Public Property SubEmpresaId() As String
            Get
                Return sSubEmpresaId
            End Get
            Set(ByVal Value As String)
                sSubEmpresaId = Value
            End Set
        End Property

        Public Property NombreEmpresa() As String
            Get
                Return sNombreEmpresa
            End Get
            Set(ByVal Value As String)
                sNombreEmpresa = Value
            End Set
        End Property
        Public Property RFC() As String
            Get
                Return sRFC
            End Get
            Set(ByVal Value As String)
                sRFC = Value
            End Set
        End Property
        Public Property Pais() As String
            Get
                Return sPais
            End Get
            Set(ByVal Value As String)
                sPais = Value
            End Set
        End Property
        Public Property Region() As String
            Get
                Return sRegion
            End Get
            Set(ByVal Value As String)
                sRegion = Value
            End Set
        End Property
        Public Property Localidad() As String
            Get
                Return sLocalidad
            End Get
            Set(ByVal Value As String)
                sLocalidad = Value
            End Set
        End Property
        Public Property ReferenciaDom() As String
            Get
                Return sReferenciaDom
            End Get
            Set(ByVal Value As String)
                sReferenciaDom = Value
            End Set
        End Property
        Public Property Ciudad() As String
            Get
                Return sCiudad
            End Get
            Set(ByVal Value As String)
                sCiudad = Value
            End Set
        End Property
        Public Property Colonia() As String
            Get
                Return sColonia
            End Get
            Set(ByVal Value As String)
                sColonia = Value
            End Set
        End Property
        Public Property Calle() As String
            Get
                Return sCalle
            End Get
            Set(ByVal Value As String)
                sCalle = Value
            End Set
        End Property
        Public Property Numero() As String
            Get
                Return sNumero
            End Get
            Set(ByVal Value As String)
                sNumero = Value
            End Set
        End Property
        Public Property NumeroInterior() As String
            Get
                Return sNumeroInterior
            End Get
            Set(ByVal Value As String)
                sNumeroInterior = Value
            End Set
        End Property
        Public Property CodigoPostal() As String
            Get
                Return sCodigoPostal
            End Get
            Set(ByVal Value As String)
                sCodigoPostal = Value
            End Set
        End Property
        Public Property Telefono() As String
            Get
                Return sTelefono
            End Get
            Set(ByVal Value As String)
                sTelefono = Value
            End Set
        End Property
        Public Property VersionCFD() As Integer
            Get
                Return nVersionCFD
            End Get
            Set(ByVal value As Integer)
                nVersionCFD = value
            End Set
        End Property
        Public Property CerBase64() As String
            Get
                Return sCerBase64
            End Get
            Set(ByVal value As String)
                sCerBase64 = value
            End Set
        End Property
    End Class

    Public Shared Function Llenar() As Boolean
        Try
            FormProcesando.PubSubInformar("Recuperando información del sistema", "Sub-Empresas")
            ' Usar un DataTable para leer los datos
            Dim DataTableDatos As DataTable
            Dim sConsultaSQL As String
            ' Recuperar los registros de las Vistas
            sConsultaSQL = "SELECT * FROM SubEmpresa"
            DataTableDatos = oDBVen.RealizarConsultaSQL(sConsultaSQL, "Valores")
            If DataTableDatos.Rows.Count = 0 Then
                DataTableDatos.Dispose()
                Exit Try
            End If
            ' Recuperar las descripciones

            ' DataRowView para buscar los diferentes valores

            ' Recorrer la lista de valores para meterlos al arreglo
            aSubEmpresa.Clear()
            If DataTableDatos.Rows.Count > 0 Then
                With DataTableDatos.Rows(0)
                    Dim oSubEmpresa As New DatosEmpresa()

                    Dim dtSEMHist As DataTable = oDBVen.RealizarConsultaSQL("Select SEH.VersionCFD, SEH.CerBase64 from SEMHist SEH where SEH.SubEmpresaID = '" & .Item("SubEmpresaId") & "' ", "SEMHist")

                    oSubEmpresa.SubEmpresaId = .Item("SubEmpresaId")
                    oSubEmpresa.NombreEmpresa = .Item("NombreEmpresa")
                    oSubEmpresa.Calle = .Item("Calle")
                    oSubEmpresa.Ciudad = .Item("Ciudad")
                    oSubEmpresa.CodigoPostal = .Item("CodigoPostal")
                    oSubEmpresa.Colonia = .Item("Colonia")
                    oSubEmpresa.Localidad = .Item("Localidad")
                    oSubEmpresa.Numero = .Item("Numero")
                    oSubEmpresa.NumeroInterior = .Item("NumeroInterior")
                    oSubEmpresa.Telefono = .Item("Telefono")
                    oSubEmpresa.Pais = .Item("Pais")
                    oSubEmpresa.ReferenciaDom = .Item("ReferenciaDom")
                    oSubEmpresa.Region = .Item("Region")
                    oSubEmpresa.RFC = .Item("RFC")
                    If dtSEMHist.Rows.Count > 0 Then
                        oSubEmpresa.VersionCFD = dtSEMHist.Rows(0)("VersionCFD")
                        oSubEmpresa.CerBase64 = dtSEMHist.Rows(0)("CerBase64")
                    End If
                    aSubEmpresa.Add(oSubEmpresa)

                End With

            End If
            DataTableDatos.Dispose()

            Return True
        Catch ExcA As SqlCeException
            MsgBox(ExcA.Message, MsgBoxStyle.Critical, "Llenar")
        Catch ExcB As Exception
            MsgBox(ExcB.Message, MsgBoxStyle.Critical, "Llenar")
        End Try
        Return False
    End Function

    Public Shared Function RecuperarSubEmpresa(ByVal parsSubEmpresaID As String) As DatosEmpresa

        For Each refSub As DatosEmpresa In SubEmpresa.aSubEmpresa
            If refSub.SubEmpresaId = parsSubEmpresaID Then
                Return refSub
            End If
        Next
        Return Nothing

    End Function


End Class
