Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Collections
Imports System.Text
Imports System.Drawing
Imports System.Drawing.Printing

Namespace PickingPrinting

    Public Class PickingSheet
        Private dtCompania As DataTable
        Private dtEncabezado As DataTable
        Private dtDetalle As DataTable
        Private VENClave As String = "F0-B6BA-03BE97871E89"

        Public Sub New()
        End Sub


        Public Sub DrawPickingSheet(ByVal gGraphics As Graphics, ByVal fntDetalleFont As Font, ByVal fntEncabezadoFont As Font, ByVal brshLabelBrush As Brush, ByVal rectLabel As RectangleF)

            Dim rectTemp As RectangleF
            Dim rectActual As New RectangleF(rectLabel.Location.X, rectLabel.Location.Y + 4, rectLabel.Width, fntEncabezadoFont.Size + 2)
            Dim rectAnterior As RectangleF

            Dim FormatoEnc As New StringFormat
            FormatoEnc.Alignment = StringAlignment.Center
            Dim Formato As New StringFormat
            Formato.Alignment = StringAlignment.Near

            'Dibuja encabezado de compañia
            gGraphics.DrawString(CStr(dtCompania.Rows(0)("Nombre")), fntEncabezadoFont, brshLabelBrush, rectActual, FormatoEnc)
            rectAnterior = rectActual
            rectActual = New RectangleF(rectAnterior.Location.X, rectAnterior.Location.Y + fntEncabezadoFont.Size + 4, rectAnterior.Width, rectAnterior.Height)
            gGraphics.DrawString(CStr(dtCompania.Rows(0)("id_Fiscal")), fntEncabezadoFont, brshLabelBrush, rectActual, FormatoEnc)
            rectAnterior = rectActual
            rectActual = New RectangleF(rectAnterior.Location.X, rectAnterior.Location.Y + fntDetalleFont.Size + 6, rectAnterior.Width, rectAnterior.Height)
            gGraphics.DrawString(CStr(dtCompania.Rows(0)("Calle")) & " " & CStr(dtCompania.Rows(0)("noExterior")) & " " & CStr(dtCompania.Rows(0)("noInterior")), fntDetalleFont, brshLabelBrush, rectActual, FormatoEnc)
            rectAnterior = rectActual
            rectActual = New RectangleF(rectAnterior.Location.X, rectAnterior.Location.Y + fntDetalleFont.Size + 4, rectAnterior.Width, rectAnterior.Height)
            gGraphics.DrawString(CStr(dtCompania.Rows(0)("Colonia")) & ", CP " & CStr(dtCompania.Rows(0)("CodigoPostal")) & ", " & CStr(dtCompania.Rows(0)("Municipio")) & ", " & CStr(dtCompania.Rows(0)("Estado")), fntDetalleFont, brshLabelBrush, rectActual, FormatoEnc)

            ' Dibuja encabezado de Picking
            dtEncabezado = ModPOS.Recupera_Tabla("sp_encabezado_ped", "@VENClave", VENClave)
            rectAnterior = rectActual
            rectActual = New RectangleF(rectAnterior.Location.X, rectAnterior.Location.Y + fntDetalleFont.Size + 6, 420, rectAnterior.Height)
            gGraphics.DrawString("[" & CStr(dtEncabezado.Rows(0)("Clave")) & "] " & CStr(dtEncabezado.Rows(0)("RazonSocial")), fntDetalleFont, brshLabelBrush, rectActual, Formato)

            rectTemp = rectActual
            rectActual = New RectangleF(rectAnterior.Location.X + 420, rectAnterior.Location.Y + fntDetalleFont.Size + 6, 120, rectAnterior.Height)
            gGraphics.DrawString("FOLIO", fntDetalleFont, brshLabelBrush, rectActual, FormatoEnc)
            rectAnterior = rectTemp

            rectActual = New RectangleF(rectAnterior.Location.X, rectAnterior.Location.Y + fntDetalleFont.Size + 6, rectAnterior.Width, rectAnterior.Height)
            gGraphics.DrawString(CStr(dtEncabezado.Rows(0)("Calle")), fntDetalleFont, brshLabelBrush, rectActual, Formato)
            rectTemp = rectActual
            rectActual = New RectangleF(rectAnterior.Location.X + 420, rectAnterior.Location.Y + fntDetalleFont.Size + 6, 120, rectAnterior.Height)
            gGraphics.DrawString(CStr(dtEncabezado.Rows(0)("Folio")), fntEncabezadoFont, brshLabelBrush, rectActual, FormatoEnc)
            rectAnterior = rectTemp

            rectActual = New RectangleF(rectAnterior.Location.X, rectAnterior.Location.Y + fntDetalleFont.Size + 6, 420, rectAnterior.Height)
            gGraphics.DrawString(CStr(dtEncabezado.Rows(0)("Domicilio1")), fntDetalleFont, brshLabelBrush, rectActual, Formato)
            rectTemp = rectActual
            
            Dim tFecha As DateTime
            tFecha = dtEncabezado.Rows(0)("Fecha")

            rectActual = New RectangleF(rectAnterior.Location.X + 420, rectAnterior.Location.Y + fntDetalleFont.Size + 6, 120, rectAnterior.Height)
            gGraphics.DrawString(tFecha.ToShortDateString(), fntDetalleFont, brshLabelBrush, rectActual, FormatoEnc)
            rectAnterior = rectTemp


            rectActual = New RectangleF(rectAnterior.Location.X, rectAnterior.Location.Y + fntDetalleFont.Size + 6, 420, rectAnterior.Height)
            gGraphics.DrawString(CStr(dtEncabezado.Rows(0)("Domicilio2")), fntDetalleFont, brshLabelBrush, rectActual, Formato)
            rectTemp = rectActual

            rectActual = New RectangleF(rectAnterior.Location.X + 420, rectAnterior.Location.Y + fntDetalleFont.Size + 6, 120, rectAnterior.Height)
            gGraphics.DrawString(CStr(dtEncabezado.Rows(0)("Vendedor")), fntDetalleFont, brshLabelBrush, rectActual, FormatoEnc)
            rectAnterior = rectTemp

            rectActual = New RectangleF(rectAnterior.Location.X, rectAnterior.Location.Y + fntDetalleFont.Size + 6, 540, rectAnterior.Height)
            gGraphics.DrawString("NOTA: " & CStr(dtEncabezado.Rows(0)("Nota")), fntDetalleFont, brshLabelBrush, rectActual, Formato)
            rectAnterior = rectActual

            dtEncabezado.Dispose()


            'Dibuja Detalle

            rectActual = New RectangleF(rectAnterior.Location.X, rectAnterior.Location.Y + fntDetalleFont.Size + 8, 70, rectAnterior.Height)
            gGraphics.DrawString("CARGADOR", fntDetalleFont, brshLabelBrush, rectActual, Formato)
            rectTemp = rectActual
            rectActual = New RectangleF(rectAnterior.Location.X + 70, rectAnterior.Location.Y + fntDetalleFont.Size + 8, 70, rectAnterior.Height)
            gGraphics.DrawString("CARGADO", fntDetalleFont, brshLabelBrush, rectActual, FormatoEnc)
            rectActual = New RectangleF(rectAnterior.Location.X + 140, rectAnterior.Location.Y + fntDetalleFont.Size + 8, 70, rectAnterior.Height)
            gGraphics.DrawString("CANTIDAD", fntDetalleFont, brshLabelBrush, rectActual, FormatoEnc)
            rectActual = New RectangleF(rectAnterior.Location.X + 210, rectAnterior.Location.Y + fntDetalleFont.Size + 8, 230, rectAnterior.Height)
            gGraphics.DrawString("DESCRIPCIÓN", fntDetalleFont, brshLabelBrush, rectActual, Formato)
            rectAnterior = rectTemp

            dtDetalle = ModPOS.Recupera_Tabla("sp_obtener_surtidodetalle", "@AREClave", "", "@Tipo", 1, "@DOCClave", VENClave)
            Dim i As Integer
            For i = 0 To dtDetalle.Rows.Count - 1

                rectActual = New RectangleF(rectAnterior.Location.X, rectAnterior.Location.Y + fntDetalleFont.Size + 8, 70, rectAnterior.Height)
                gGraphics.DrawString("__________", fntDetalleFont, brshLabelBrush, rectActual, Formato)
                rectTemp = rectActual
                rectActual = New RectangleF(rectAnterior.Location.X + 70, rectAnterior.Location.Y + fntDetalleFont.Size + 8, 70, rectAnterior.Height)
                gGraphics.DrawString("_________", fntDetalleFont, brshLabelBrush, rectActual, FormatoEnc)
                rectActual = New RectangleF(rectAnterior.Location.X + 140, rectAnterior.Location.Y + fntDetalleFont.Size + 8, 70, rectAnterior.Height)
                gGraphics.DrawString(CStr(dtDetalle.Rows(i)("Cantidad")), fntDetalleFont, brshLabelBrush, rectActual, FormatoEnc)
                rectActual = New RectangleF(rectAnterior.Location.X + 210, rectAnterior.Location.Y + fntDetalleFont.Size + 8, 330, rectAnterior.Height)
                gGraphics.DrawString(CStr(dtDetalle.Rows(i)("Nombre")), fntDetalleFont, brshLabelBrush, rectActual, Formato)
                rectAnterior = rectTemp

            Next
            dtDetalle.Dispose()
           



        End Sub

        Public Sub AddPicking(ByVal Documento As [String])
            VENClave = Documento
        End Sub

        Public Sub AddCompania(ByVal dt As DataTable)
            dtCompania = dt
        End Sub

        Public Function GetPicking() As String
            Return (VENClave)
        End Function


       

    End Class

    Public Class PackingSheet
        Private idPaquete, TipoPaquete, Calle, Domicilio1, Domicilio2, NombreUsuario, Origen, Cliente, Guia, Nota As String
        Private Fecha As DateTime


        Public Sub New()
        End Sub


        Public Sub DrawPackingSheet(ByVal gGraphics As Graphics, ByVal fntDetalleFont As Font, ByVal fntEncabezadoFont As Font, ByVal fntCodeFont As Font, ByVal brshLabelBrush As Brush, ByVal rectLabel As RectangleF)

            Dim rectAnterior As RectangleF
            Dim FormatoEnc As New StringFormat
            FormatoEnc.Alignment = StringAlignment.Center
            Dim Formato As New StringFormat
            Formato.Alignment = StringAlignment.Near

            'Dibuja idPaquete

            Dim sHeightAnterior As Single = fntEncabezadoFont.Size + 2
            Dim rectActual As RectangleF = New RectangleF(rectLabel.Location.X, rectLabel.Location.Y + fntCodeFont.Size + 6, rectLabel.Width, fntEncabezadoFont.Size * 2)
            gGraphics.DrawString("*" & idPaquete & "*", fntCodeFont, brshLabelBrush, rectActual, FormatoEnc)
           
            rectAnterior = rectActual
            rectActual = New RectangleF(rectAnterior.Location.X, rectAnterior.Location.Y + fntEncabezadoFont.Size + 14, rectAnterior.Width, sHeightAnterior)
            gGraphics.DrawString("ID: " & idPaquete, fntEncabezadoFont, brshLabelBrush, rectActual, FormatoEnc)

            rectAnterior = rectActual
            rectActual = New RectangleF(rectAnterior.Location.X, rectAnterior.Location.Y + fntDetalleFont.Size + 6, rectAnterior.Width, rectAnterior.Height)
            gGraphics.DrawString("TPQ: " & TipoPaquete & "   DAT: " & Fecha.ToShortDateString() & "   USR: " & NombreUsuario, fntDetalleFont, brshLabelBrush, rectActual, Formato)

            rectAnterior = rectActual
            rectActual = New RectangleF(rectAnterior.Location.X, rectAnterior.Location.Y + fntDetalleFont.Size + 6, rectAnterior.Width, rectAnterior.Height)
            gGraphics.DrawString("ORG: " & Origen, fntDetalleFont, brshLabelBrush, rectActual, Formato)

            rectAnterior = rectActual
            rectActual = New RectangleF(rectAnterior.Location.X, rectAnterior.Location.Y + fntDetalleFont.Size + 6, rectAnterior.Width, rectAnterior.Height)
            gGraphics.DrawString("CTE: " & Cliente, fntDetalleFont, brshLabelBrush, rectActual, Formato)

            rectAnterior = rectActual
            rectActual = New RectangleF(rectAnterior.Location.X, rectAnterior.Location.Y + fntDetalleFont.Size + 6, rectAnterior.Width, rectAnterior.Height)
            gGraphics.DrawString("DST: " & Calle, fntDetalleFont, brshLabelBrush, rectActual, Formato)

            rectAnterior = rectActual
            rectActual = New RectangleF(rectAnterior.Location.X, rectAnterior.Location.Y + fntDetalleFont.Size + 6, rectAnterior.Width, rectAnterior.Height)
            gGraphics.DrawString(Domicilio1, fntDetalleFont, brshLabelBrush, rectActual, Formato)

            rectAnterior = rectActual
            rectActual = New RectangleF(rectAnterior.Location.X, rectAnterior.Location.Y + fntDetalleFont.Size + 6, rectAnterior.Width, rectAnterior.Height)
            gGraphics.DrawString(Domicilio2, fntDetalleFont, brshLabelBrush, rectActual, Formato)

            rectAnterior = rectActual
            rectActual = New RectangleF(rectAnterior.Location.X, rectAnterior.Location.Y + fntDetalleFont.Size + 6, rectAnterior.Width, rectAnterior.Height)
            gGraphics.DrawString("GUIA: " & Guia, fntDetalleFont, brshLabelBrush, rectActual, Formato)

            rectAnterior = rectActual
            rectActual = New RectangleF(rectAnterior.Location.X, rectAnterior.Location.Y + fntDetalleFont.Size + 6, rectAnterior.Width, rectAnterior.Height)
            gGraphics.DrawString(Nota, fntDetalleFont, brshLabelBrush, rectActual, Formato)
        End Sub

        Public Sub AddPacking(ByVal Documento As [String])
            idPaquete = Documento
        End Sub

        Public Sub AddTipoPaquete(ByVal sTipoPaquete As String)
            TipoPaquete = sTipoPaquete
        End Sub

        Public Sub AddFecha(ByVal dtfecha As DateTime)
            fecha = dtfecha
        End Sub

        Public Sub AddNombreUsuario(ByVal sUsuario As String)
            NombreUsuario = sUsuario
        End Sub

        Public Sub AddOrigen(ByVal sOrigen As String)
            Origen = sOrigen
        End Sub

        Public Sub AddCliente(ByVal sCte As String)
            Cliente = sCte
        End Sub


        Public Sub AddCalle(ByVal sCalle As String)
            Calle = sCalle
        End Sub

        Public Sub AddDomicilio1(ByVal sDomcilio As String)
            Domicilio1 = sDomcilio
        End Sub

        Public Sub addDomicilio2(ByVal sDomcilio As String)
            Domicilio2 = sDomcilio
        End Sub

        Public Sub addGuia(ByVal sGuia As String)
            Guia = sGuia
        End Sub

        Public Sub addNota(ByVal sNota As String)
            Nota = sNota
        End Sub

        Public Function GetPacking() As String
            Return (idPaquete)
        End Function

    End Class

End Namespace
