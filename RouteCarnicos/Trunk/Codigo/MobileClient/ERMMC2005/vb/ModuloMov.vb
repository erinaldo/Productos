Public Class ModuloMov
    Implements ERM.Dia.Agenda.Visita.ModuloMov

    Protected oModuloMovActual As Modulos.GrupoModuloMov
    Protected oModuloMovDetActual As Modulos.GrupoModuloMovDetalle

    Public Property ModuloMovActual() As Modulos.GrupoModuloMov
        Get
            Return oModuloMovActual
        End Get
        Set(ByVal Value As Modulos.GrupoModuloMov)
            oModuloMovActual = Value
        End Set
    End Property

    Public Property ModuloMovDetActual() As Modulos.GrupoModuloMovDetalle Implements ERM.Dia.Agenda.Visita.ModuloMov.ModuloMovDetActual
        Get
            Return oModuloMovDetActual
        End Get
        Set(ByVal Value As Modulos.GrupoModuloMovDetalle)
            oModuloMovDetActual = Value
        End Set
    End Property

    Public Function MostrarMenu(ByVal paroCliente As Cliente, ByVal parsVisitaActual As String, ByVal parbTerminarVisita As Boolean) As Boolean Implements ERM.Dia.Agenda.Visita.ModuloMov.MostrarMenu
        Try

            If oVendedor.motconfiguracion.Secuencia = True Then
                Me.ModuloMovActual = Nothing
                Me.ModuloMovDetActual = Nothing
                If ctrlSeguimiento.ModuloMovDetalleClaveActual = Nothing And ctrlSeguimiento.MenuItemSeleccionado = False Then Return True
                If ctrlSeguimiento.TerminarVisita Then Return True
                If ctrlSeguimiento.MasInfo Then Return True

                If ctrlSeguimiento.MenuItemSeleccionado Then
                    Me.ModuloMovDetActual = New Modulos.GrupoModuloMovDetalle
                    Me.ModuloMovDetActual.Recuperar(ctrlSeguimiento.ModuloMovDetalleClaveMenuItem)

                    Me.ModuloMovActual = New Modulos.GrupoModuloMov
                    Me.ModuloMovActual.ModuloClave = Me.ModuloMovDetActual.ModuloClave
                    Me.ModuloMovActual.ModuloMovClave = Me.ModuloMovDetActual.ModuloMovClave
                    Me.ModuloMovActual.Recuperar()

                Else
                    If ctrlSeguimiento.ModuloMovDetalleClaveActual Is Nothing Then Return True

                    ' Recuperar el ModuloMovDetalle
                    Me.ModuloMovDetActual = New Modulos.GrupoModuloMovDetalle
                    Me.ModuloMovDetActual.Recuperar(ctrlSeguimiento.ModuloMovDetalleClaveActual)

                    Me.ModuloMovActual = New Modulos.GrupoModuloMov
                    Me.ModuloMovActual.ModuloClave = Me.ModuloMovDetActual.ModuloClave
                    Me.ModuloMovActual.ModuloMovClave = Me.ModuloMovDetActual.ModuloMovClave
                    Me.ModuloMovActual.Recuperar()

                End If

                ctrlSeguimiento.TerminarVisita = False
                ctrlSeguimiento.MenuItemSeleccionado = False
                ctrlSeguimiento.dobleclick = False

            Else
                If parbTerminarVisita Then
                    Me.ModuloMovActual = Nothing
                    Me.ModuloMovDetActual = Nothing
                    Return True
                End If
                ' Obtener ModuloMov
                ' Recuperar el ModuloMov

                Dim FormMenuModulos As New FormMenuModulos
                If Not Me.ModuloMovActual Is Nothing Then
                    FormMenuModulos.ModuloMovActual = Me.ModuloMovActual
                End If
                If Not Me.ModuloMovDetActual Is Nothing Then
                    FormMenuModulos.ModuloMovDetalleActual = Me.ModuloMovDetActual
                End If
                ' Cambios 24 Abril
                If FormMenuModulos.ShowDialog() = DialogResult.OK Then
                    Me.ModuloMovActual = FormMenuModulos.ModuloMovActual
                    Me.ModuloMovDetActual = FormMenuModulos.ModuloMovDetalleActual
                Else
                    Me.ModuloMovActual = Nothing
                    Me.ModuloMovDetActual = Nothing
                End If
                With FormMenuModulos
                    .Dispose()
                    FormMenuModulos = Nothing
                End With
            End If

            Return True

            '/ Cambios 24 Abril
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        Return False
    End Function

End Class
