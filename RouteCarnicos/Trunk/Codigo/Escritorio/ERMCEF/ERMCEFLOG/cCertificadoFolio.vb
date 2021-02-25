Imports BASLOG

Public Class cCertificadoFolio
    Inherits BASLOG.cClaseNodo

#Region "Propiedades"
    Public Property NumCertificado() As String
        Get
            Return Me.Tabla.Campos("NumCertificado").Valor
        End Get
        Set(ByVal Value As String)
            If Me.Status = eEstado.Vacio Or Me.Status = eEstado.Nuevo Then
                Me.Tabla.Campos("NumCertificado").Valor = Value
            End If
        End Set
    End Property

    Public Property FechaInicial() As Date
        Get
            Return Me.Tabla.Campos("FechaInicial").Valor
        End Get
        Set(ByVal Value As Date)
            Me.Tabla.Campos("FechaInicial").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property

    Public Property FechaFinal() As Date
        Get
            Return Me.Tabla.Campos("FechaFinal").Valor
        End Get
        Set(ByVal Value As Date)
            Me.Tabla.Campos("FechaFinal").Valor = Value
            If Me.Status = eEstado.Recuperado Then
                Me.tEstado = eEstado.Modificado
            End If
        End Set
    End Property
#End Region

#Region "Sobreescritos"
    Protected Overrides Sub CrearEstructuraTabla()
        With Me.Tabla
            .AgregarCampo(New LbDatos.cCampo("NumCertificado", LbDatos.ETipo.Cadena, "", True, True))
            .AgregarCampo(New LbDatos.cCampo("FechaInicial", LbDatos.ETipo.FechaHora, True))
            .AgregarCampo(New LbDatos.cCampo("FechaFinal", LbDatos.ETipo.FechaHora, True))
        End With
    End Sub

    Protected Overrides Sub CrearHijos()

    End Sub

    Protected Overrides Function RegresaEnsamblado() As System.Reflection.Assembly
        Return System.Reflection.Assembly.GetExecutingAssembly()
    End Function

    Protected Overrides Function RegresaMnemonico() As String
        Return "CEF"
    End Function

    Protected Overrides Function RegresaNombreTabla() As String
        Return "CertificadoFolio"
    End Function

    Protected Overrides Sub ValidaCampo(ByVal pvNombre As String)
        MyBase.ValidaCampo(pvNombre)
        If tEstado = eEstado.Vacio Or tEstado = eEstado.Nuevo Then
            If pvNombre = "NumCertificado" Then
                If Existe(Me.NumCertificado) Then
                    Throw New LbControlError.cError("BE0002", , Me.Tabla.Campos(pvNombre).Nombre)
                End If
            End If
        End If
    End Sub
#End Region

#Region "Sobrecargados Especificos"
    Public Overloads Sub Recuperar(ByVal pvNumCertificado As String)
        Me.Limpiar()
        Me.NumCertificado = pvNumCertificado
        Me.Recuperar()
    End Sub

    Public Overloads Function Existe(ByVal pvNumCertificado As String) As Boolean
        Return (Me.Tabla.Seleccionar("NumCertificado='" & lbGeneral.ValidaFormatoSQLString(pvNumCertificado) & "'").Rows.Count > 0)
    End Function

    Public Overloads Sub Insertar(ByVal pvNumCertificado As String, ByVal pvFechaInicial As Date, ByVal pvFechaFinal As Date, Optional ByVal pvCampo() As String = Nothing)
        Me.Limpiar()
        Me.NumCertificado = pvNumCertificado
        Me.FechaInicial = pvFechaInicial
        Me.FechaFinal = pvFechaFinal
        Me.Insertar(pvCampo)
    End Sub
    Public Overloads Function ExisteFosHist(ByVal pvNumCertificado As String) As Integer
        Return (LbConexion.cConexion.Instancia.EjecutarComandoScalar("select count(*) from foshist where numcertificado='" & pvNumCertificado & "'"))
    End Function
    Public Overloads Function ExisteCentroExp(ByVal pvNumCertificado As String) As Integer
        Return (LbConexion.cConexion.Instancia.EjecutarComandoScalar("select count(*) from centroexpedicion where numcertificado='" & pvNumCertificado & "'"))
    End Function
#End Region

End Class
