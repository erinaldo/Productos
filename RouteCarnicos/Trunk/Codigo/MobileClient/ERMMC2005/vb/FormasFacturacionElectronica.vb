Public Class FormasFacturacionElectronica
    Implements ERM.Dia.Agenda.Visita.ModuloMov.MovProducto.FormasFacturacion

    Private Function ExistenMovimientos(ByVal paroCliente As Cliente) As Boolean
        Dim sConsulta As String
        Dim nMovs As Integer
        sConsulta = "select count(*) from TransProd "
        sConsulta &= "inner join Visita on TransProd.VisitaClave=Visita.VisitaClave "
        sConsulta &= "where TransProd.Tipo=8 and Visita.DiaClave=TransProd.DiaClave "
        sConsulta &= "and Visita.ClienteClave='" & paroCliente.ClienteClave & "' "
        sConsulta &= "and Visita.DiaClave='" & oDia.DiaActual & "'"
        nMovs = oDBVen.RealizarScalarSQL(sConsulta)
        Return (nMovs > 0)
    End Function

    Public Function Mostrar(ByVal paroModuloMovDetActual As Modulos.GrupoModuloMovDetalle, ByVal paroCliente As Cliente, ByVal parsVisitaClave As String) As Boolean Implements ERM.Dia.Agenda.Visita.ModuloMov.MovProducto.FormasFacturacion.Mostrar
        If oConHist.Campos("ComprobanteDig") Then
            If Not IsDBNull(oConHist.Campos("ArchivoPEM")) AndAlso Not IsNothing(oConHist.Campos("ArchivoPEM")) AndAlso oConHist.Campos("ArchivoPEM") <> "" Then
                If Not IsDBNull(paroCliente.IdFiscal) AndAlso paroCliente.IdFiscal <> Nothing AndAlso paroCliente.IdFiscal <> "" Then
                    If oDBVen.RealizarConsultaSQL("Select * from clientedomicilio where tipo=1 and clienteclave='" & paroCliente.ClienteClave & "'", "Domicilios").Rows.Count > 0 Then

                        If ExistenMovimientos(paroCliente) Then
                            Dim oFormFacturacionElectronica As New FormFacturacionElectronica(paroCliente, parsVisitaClave, paroModuloMovDetActual)
                            If oFormFacturacionElectronica.ShowDialog() = DialogResult.OK Then
                                oFormFacturacionElectronica.Dispose()
                                Return True
                            End If
                            oFormFacturacionElectronica.Dispose()
                            Return False
                        Else
                            'Dim sFolio As String = String.Empty
                            'If oVendedor.CapturaFolioFac = False Then
                            '    Dim FolioF As New FolioFiscal
                            '    Dim sError As String = ""
                            '    sFolio = oApp.KEYGEN(1)
                            '    If sFolio = "" Then Return False
                            'End If
                            Return MostrarDetalle(paroCliente, parsVisitaClave, String.Empty, FormFacturaElectronicaDetalle.Modo.Crear, paroModuloMovDetActual, "")
                        End If
                    Else

                        MsgBox(gVista.BuscarMensaje("MsgBoxGeneral", "E0664"))
                    End If
                Else
                    MsgBox(gVista.BuscarMensaje("MsgBoxGeneral", "E0665"))
                End If
            Else
                MsgBox(gVista.BuscarMensaje("MsgBoxGeneral", "E0679"))
            End If
            Else

                MsgBox(gVista.BuscarMensaje("MsgBoxGeneral", "I0178"))

            End If
    End Function



    Public Function MostrarDetalle(ByVal paroCliente As Cliente, ByVal parsVisitaClave As String, ByVal parFacturaID As String, ByVal parModo As FormFacturaDetalle.Modo, ByVal parGrupo As Modulos.GrupoModuloMovDetalle, ByVal parTransProdID As String, Optional ByVal parFecha As String = "", Optional ByVal parTotal As Double = 0) As Boolean Implements ERM.Dia.Agenda.Visita.ModuloMov.MovProducto.FormasFacturacion.MostrarDetalle
        Dim oFormFactElecDetalle As New FormFacturaElectronicaDetalle(paroCliente, parsVisitaClave, parFacturaID, parModo, parGrupo, parTransProdID, parFecha, parTotal)
        Dim bReturn As Boolean = False
        If oFormFactElecDetalle.DialogResult <> DialogResult.Cancel Then
            If oFormFactElecDetalle.ShowDialog() = DialogResult.OK Then
                bReturn = True
            End If
        End If
        oFormFactElecDetalle.Dispose()
        Return bReturn
    End Function



End Class

