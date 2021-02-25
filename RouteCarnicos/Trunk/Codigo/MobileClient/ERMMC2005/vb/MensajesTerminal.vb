Public Class MensajesTerminal
    Public Function MostrarMensajes(ByVal paroAgenda As Agenda, ByVal parsVisitaClave As String, ByVal parbCumpleaños As Boolean) As Boolean
        Try
            Dim dtMensajes As DataTable
            'If paroAgenda.Cumpleaños(parsVisitaClave) Then
            If parbCumpleaños Then
                dtMensajes = oDBVen.RealizarConsultaSQL("Select MDBMensajeID from MDBMensaje Where MDBMensajeTipo=4", "ClienteMensaje")
                If dtMensajes.Rows.Count > 0 Then
                    Dim oFormMensajesTerminal As New FormMensajesTerminal(paroAgenda.ClienteActual.ClienteClave, dtMensajes, FormMensajesTerminal.TipoMensaje.Cumpleaños)
                    oFormMensajesTerminal.ShowDialog()
                    With oFormMensajesTerminal
                        .Dispose()
                        .DetailViewMensaje.Dispose()
                        .DetailViewMensaje = Nothing
                        oFormMensajesTerminal = Nothing
                    End With
                End If
            End If

            dtMensajes = oDBVen.RealizarConsultaSQL("Select ClienteMensaje.MDBMensajeID from ClienteMensaje inner join MDBMensaje on MDBMensaje.MDBMensajeID=ClienteMensaje.MDBMensajeID Where tipoEstado = 1 and MDBMensajeTipo<>4 and ClienteClave ='" & paroAgenda.ClienteActual.ClienteClave & "'", "ClienteMensaje")
            If dtMensajes.Rows.Count > 0 Then
                Dim oFormMensajesTerminal As New FormMensajesTerminal(paroAgenda.ClienteActual.ClienteClave, dtMensajes, FormMensajesTerminal.TipoMensaje.General)
                oFormMensajesTerminal.ShowDialog()
                With oFormMensajesTerminal
                    .Dispose()
                    .DetailViewMensaje.Dispose()
                    .DetailViewMensaje = Nothing
                    oFormMensajesTerminal = Nothing
                End With
            End If
            ' Nueva visita
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        Return True
    End Function

    Public Shared Sub CambiarAccion(ByVal parsClienteClave As String, ByVal parsMDBMensajeID As String, ByVal pariPosponer As Integer)
        If pariPosponer = 2 Then
            oDBVen.EjecutarComandoSQL("UPDATE ClienteMensaje set Posponer=2,TipoEstado = 0,MFechaHora=" & UniFechaSQL(Now) & ",MUsuarioID='" & oVendedor.UsuarioId & "',Enviado=0 WHERE MDBMensajeID='" & parsMDBMensajeID & "' AND ClienteClave='" & parsClienteClave & "'")
        Else
            oDBVen.EjecutarComandoSQL("UPDATE ClienteMensaje set Posponer=1,MFechaHora=" & UniFechaSQL(Now) & ",MUsuarioID='" & oVendedor.UsuarioId & "',Enviado=0 WHERE MDBMensajeID='" & parsMDBMensajeID & "' AND ClienteClave='" & parsClienteClave & "'")
        End If

    End Sub
End Class
