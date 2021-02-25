Imports System.Data.SqlServerCe
Public Class FolioFiscal

    Protected sFolioFiscalID As String 'se agrega para tener en una sola columna el id unico
    Protected sFolioID As String
    Protected sFosID As String
    Protected iInicio As Integer
    Protected sModuloMovDetalleClave As String
    Protected sVendedorID As String
    Protected sTerminalClave As String
    Protected sNumCertificado As String
    Protected sFormato As String
    Protected sSerie As String
    Protected iAprobacion As Integer
    Protected iAnioAprobacion As Integer
    Protected iUsados As Integer
    Protected iFin As Integer
    Protected sFSHFechaInicio As DateTime
    Protected iTipoComprobante As Int16
    Protected sEnviado As Boolean


    Public Property FolioFiscalID() As String 'se agrega para tener en una sola columna el id unico
        Get
            Return sFolioFiscalID
        End Get
        Set(ByVal Value As String)
            sFolioFiscalID = Value
        End Set
    End Property
    Public Property FolioID() As String
        Get
            Return sFolioID
        End Get
        Set(ByVal Value As String)
            sFolioID = Value
        End Set
    End Property
    Public Property FosID() As String
        Get
            Return sFosID
        End Get
        Set(ByVal Value As String)
            sFosID = Value
        End Set
    End Property
    Public Property Inicio() As Integer
        Get
            Return iInicio
        End Get
        Set(ByVal Value As Integer)
            iInicio = Value
        End Set
    End Property
    Public Property ModuloMovDetalleClave() As String
        Get
            Return sModuloMovDetalleClave
        End Get
        Set(ByVal Value As String)
            sModuloMovDetalleClave = Value
        End Set
    End Property
    Public Property VendedorID() As String
        Get
            Return sVendedorID
        End Get
        Set(ByVal Value As String)
            sVendedorID = Value
        End Set
    End Property
    Public Property TerminalClave() As String
        Get
            Return sTerminalClave
        End Get
        Set(ByVal Value As String)
            sTerminalClave = Value
        End Set
    End Property
    Public Property NumCertificado() As String
        Get
            Return sNumCertificado
        End Get
        Set(ByVal Value As String)
            sNumCertificado = Value
        End Set
    End Property
    Public Property Formato() As String
        Get
            Return sFormato
        End Get
        Set(ByVal Value As String)
            sFormato = Value
        End Set
    End Property
    Public Property Serie() As String
        Get
            Return sSerie
        End Get
        Set(ByVal Value As String)
            sSerie = Value
        End Set
    End Property
    Public Property Aprobacion() As Integer
        Get
            Return iAprobacion
        End Get
        Set(ByVal Value As Integer)
            iAprobacion = Value
        End Set
    End Property
    Public Property AnioAprobacion() As Integer
        Get
            Return iAnioAprobacion
        End Get
        Set(ByVal Value As Integer)
            iAnioAprobacion = Value
        End Set
    End Property
    Public Property Usados() As Integer
        Get
            Return iUsados
        End Get
        Set(ByVal Value As Integer)
            iUsados = Value
        End Set
    End Property
    Public Property Fin() As Integer
        Get
            Return iFin
        End Get
        Set(ByVal Value As Integer)
            iFin = Value
        End Set
    End Property
    Public Property FSHFechaInicio() As DateTime
        Get
            Return sFSHFechaInicio
        End Get
        Set(ByVal Value As DateTime)
            sFSHFechaInicio = Value
        End Set
    End Property
    Public Property TipoComprobante() As Int16
        Get
            Return iTipoComprobante
        End Get
        Set(ByVal Value As Int16)
            iTipoComprobante = Value
        End Set
    End Property
    Public Property Enviado() As Boolean
        Get
            Return sEnviado
        End Get
        Set(ByVal Value As Boolean)
            sEnviado = Value
        End Set
    End Property


    Public Function ObtenerFolioFiscal(ByVal parsSubEmpresaID As String, ByVal pariTipoComprobante As Integer, ByRef OP_Mensaje As String)
        Try
            If oDBVen.EjecutarCmdScalarIntSQL("select count(*) from foliofiscal inner join CentroExpedicion on CentroExpedicion.CentroExpId =foliofiscal.CentroExpId  where CentroExpedicion.SubEmpresaID='" & parsSubEmpresaID & "' and  (fin<usados+Inicio) and FolioFiscal.FechaFinal >= '" & Today.Date.ToString("s") & "' and FolioFiscal.TipoComprobante = " & pariTipoComprobante.ToString) = oDBVen.EjecutarCmdScalarIntSQL("select count(*) from foliofiscal inner join CentroExpedicion on CentroExpedicion.CentroExpId =foliofiscal.CentroExpId  where CentroExpedicion.SubEmpresaID='" & parsSubEmpresaID & "' and FolioFiscal.FechaFinal >= '" & Today.Date.ToString("s") & "' and FolioFiscal.TipoComprobante =  " & pariTipoComprobante.ToString) Then
                OP_Mensaje = "E0855"
                Return Nothing
            Else
                Dim dtFolios As DataTable

                'dtFolios = oDBVen.RealizarConsultaSQL("select * from foliofiscal inner join CentroExpedicion on CentroExpedicion.CentroExpId =foliofiscal.CentroExpId where CentroExpedicion.SubEmpresaID='" & parsSubEmpresaID & "' and (fin>=usados+Inicio)", "Folios")
                Dim sConsulta As String
                sConsulta = "select * from FolioFiscal F "
                sConsulta &= "inner join ( "
                sConsulta &= "select FolioiD, Serie, min(FSHFechaInicio) as FechaInicio "
                sConsulta &= "from FolioFiscal "
                sConsulta &= "inner join CentroExpedicion on CentroExpedicion.CentroExpId = FolioFiscal.CentroExpId "
                sConsulta &= "where CentroExpedicion.SubEmpresaID='" & parsSubEmpresaID & "' and (Fin>=Usados+Inicio) "
                sConsulta &= "and FolioFiscal.FechaFinal >= '" & Today.Date.ToString("s") & "' and FolioFiscal.TipoComprobante = " & pariTipoComprobante.ToString
                sConsulta &= "group by FolioId, Serie "
                sConsulta &= ") as F1 on F.FolioId = F1.FolioId and F.Serie = F1.Serie and F.FSHFechaInicio = F1.FechaInicio  order by F.FechaCreacion "
                dtFolios = oDBVen.RealizarConsultaSQL(sConsulta, "Folios")

                Dim tmpFolio As New FolioFiscal
                If dtFolios.Rows.Count > 0 Then
                    tmpFolio.FolioFiscalID = dtFolios.Rows(0)("FolioID") & "|" & dtFolios.Rows(0)("FosID")
                    tmpFolio.FolioID = dtFolios.Rows(0)("FolioID")
                    tmpFolio.FosID = dtFolios.Rows(0)("FosID")
                    tmpFolio.Inicio = dtFolios.Rows(0)("Inicio")
                    If Not IsDBNull(dtFolios.Rows(0)("ModuloMovDetalleClave")) Then
                        tmpFolio.ModuloMovDetalleClave = dtFolios.Rows(0)("ModuloMovDetalleClave")
                    End If
                    tmpFolio.VendedorID = IIf(IsDBNull(dtFolios.Rows(0)("VendedorID")), "", dtFolios.Rows(0)("VendedorID"))
                    tmpFolio.TerminalClave = IIf(IsDBNull(dtFolios.Rows(0)("TerminalClave")), "", dtFolios.Rows(0)("TerminalClave"))
                    tmpFolio.NumCertificado = dtFolios.Rows(0)("NumCertificado")
                    'tmpFolio.Formato = dtFolios.Rows(i)("Serie") & dtFolios.Rows(i)("Formato") & (Integer.Parse(dtFolios.Rows(i)("Usados")) + Integer.Parse(dtFolios.Rows(i)("Inicio"))).ToString
                    tmpFolio.Formato = dtFolios.Rows(0)("Serie") & String.Format("{0:" & dtFolios.Rows(0)("Formato") & "}", (Integer.Parse(dtFolios.Rows(0)("Usados")) + Integer.Parse(dtFolios.Rows(0)("Inicio"))))
                    tmpFolio.Serie = dtFolios.Rows(0)("Serie")
                    tmpFolio.Aprobacion = dtFolios.Rows(0)("Aprobacion")
                    tmpFolio.AnioAprobacion = dtFolios.Rows(0)("AnioAprobacion")
                    tmpFolio.Usados = dtFolios.Rows(0)("Usados")
                    tmpFolio.Fin = dtFolios.Rows(0)("Fin")
                    tmpFolio.FSHFechaInicio = dtFolios.Rows(0)("FSHFechaInicio")
                    tmpFolio.TipoComprobante = dtFolios.Rows(0)("TipoComprobante")
                    tmpFolio.Enviado = dtFolios.Rows(0)("Enviado")
                End If

                dtFolios.Dispose()
                Return tmpFolio
            End If

        Catch ex As Exception
            OP_Mensaje = ex.Message
        End Try

    End Function
    Public Shared Function ValidaExistencia(ByVal pariTipoComprobante As Integer) As Boolean
        Return IIf(oDBVen.EjecutarCmdScalarIntSQL("select count(*) from foliofiscal inner join CentroExpedicion on CentroExpedicion.CentroExpId =foliofiscal.CentroExpId where FolioFiscal.TipoComprobante= " & pariTipoComprobante.ToString) > 0, True, False)
    End Function

    '.ActualizarFolioFiscal 
    Public Shared Sub ActualizarFolioFiscal(ByVal OP_FolioID As String, ByVal OP_FosID As String, ByRef OP_Error As String)
        Try
            If oDBVen.EjecutarComandoSQL("Update FolioFiscal set Enviado =0 , usados =usados+1 where folioid='" & OP_FolioID & "' and fosid= '" & OP_FosID & "'") > 0 Then

            Else
                'OP_Error="SIN Registro"
            End If


        Catch ex As Exception
            OP_Error = ex.Message
        End Try

    End Sub

End Class
