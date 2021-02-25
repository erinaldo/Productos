Public Class MOTConfiguracion
    Implements IDisposable
    Implements ICloneable


    Public MCNClave As String
    Public ModuloClave As String
    Public Secuencia As Boolean
    Public SecuenciaObligatoria As Boolean
    Public TerminarSecuencia As Boolean
    Public ResumenMovimientos As Boolean
    Public MensajeImpresion As Boolean

    Private disposedValue As Boolean = False        ' Para detectar llamadas redundantes

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: Liberar recursos no administrados cuando se llamen explícitamente
            End If

            ' TODO: Liberar recursos no administrados compartidos
            MCNClave = Nothing
            ModuloClave = Nothing
            Secuencia = Nothing
            SecuenciaObligatoria = Nothing
            TerminarSecuencia = Nothing
            ResumenMovimientos = Nothing
            MensajeImpresion = Nothing
        End If
        Me.disposedValue = True
    End Sub

#Region " IDisposable Support "
    ' Visual Basic agregó este código para implementar correctamente el modelo descartable.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' No cambie este código. Coloque el código de limpieza en Dispose (ByVal que se dispone como Boolean).
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

    Public Function Clone() As Object Implements System.ICloneable.Clone
        Dim lMOTClonado As New MOTConfiguracion
        lMOTClonado.Secuencia = True
        lMOTClonado.MCNClave = Me.MCNClave
        lMOTClonado.ModuloClave = Me.ModuloClave
        lMOTClonado.Secuencia = Me.Secuencia
        lMOTClonado.SecuenciaObligatoria = Me.SecuenciaObligatoria
        lMOTClonado.TerminarSecuencia = Me.TerminarSecuencia
        lMOTClonado.ResumenMovimientos = Me.ResumenMovimientos
        lMOTClonado.MensajeImpresion = Me.MensajeImpresion
        Return lMOTClonado
    End Function
End Class

Public Class MmdMcn
    Implements IDisposable

    Public ModuloMovDetalleClave As String
    Public MCNClave As String
    Public Secuencia As Integer
    Public NombreActividad As String
    Public TipoIndice As Integer
    Public Realizada As Boolean

    Private disposedValue As Boolean = False        ' Para detectar llamadas redundantes

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: Liberar recursos no administrados cuando se llamen explícitamente
            End If

            ' TODO: Liberar recursos no administrados compartidos
            Me.ModuloMovDetalleClave = Nothing
            Me.MCNClave = Nothing
            Me.Secuencia = Nothing
            Me.NombreActividad = Nothing
            Me.TipoIndice = Nothing
            Me.Realizada = Nothing
        End If
        Me.disposedValue = True
    End Sub

#Region " IDisposable Support "
    ' Visual Basic agregó este código para implementar correctamente el modelo descartable.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' No cambie este código. Coloque el código de limpieza en Dispose (ByVal que se dispone como Boolean).
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class
