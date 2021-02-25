Imports System.Drawing
Public Class ClassCargando

    Public FormCargando As FormCargando

    Public Sub New()
        FormCargando = New FormCargando
    End Sub

    Public Sub Informar(ByVal nIndiceModulo As Integer, ByVal sMnemonicoImagen As String, ByVal sNombreModulo As String)
        FormCargando.Visible = True
        If Not IsNothing(FormCargando.PictureBoxModulo.Image) Then
            FormCargando.PictureBoxModulo.Image.Dispose()
        End If
        FormCargando.PictureBoxModulo.Image = Nothing

        Dim bmp As System.Drawing.Bitmap
        If Not IsNothing(htImagenes(sMnemonicoImagen & nIndiceModulo)) Then 'Si existe la imagen
            bmp = New System.Drawing.Bitmap(CType(htImagenes(sMnemonicoImagen & nIndiceModulo), System.Drawing.Bitmap))
        ElseIf nIndiceModulo = 21 AndAlso Not IsNothing(htImagenes(sMnemonicoImagen & "7")) Then 'Si es cobranza poner imagen de cuentas por cobrar indice 7
            bmp = New System.Drawing.Bitmap(CType(htImagenes(sMnemonicoImagen & nIndiceModulo), System.Drawing.Bitmap))
        Else
            bmp = New System.Drawing.Bitmap(CType(htImagenes("MG0"), System.Drawing.Bitmap))
        End If
        FormCargando.PictureBoxModulo.Image = bmp.Clone

        Dim imageAttr As System.Drawing.Imaging.ImageAttributes = New Imaging.ImageAttributes()
        Dim lienzo As Graphics
        lienzo = Graphics.FromImage(FormCargando.PictureBoxModulo.Image)
        lienzo.Clear(Color.White)

        imageAttr.SetColorKey(bmp.GetPixel(0, 0), bmp.GetPixel(0, 0))

#If MOD_TERM = "IPAQ" Or MOD_TERM = "HHP9700" Then
        FormCargando.PictureBoxModulo.SizeMode = PictureBoxSizeMode.StretchImage

        lienzo.DrawImage(bmp, New Rectangle(0, 0, 72 * nFactorW * 2, 72 * nFactorH * 2), 0, 0, 72 * nFactorW * 2, 72 * nFactorH * 2, GraphicsUnit.Pixel, imageAttr)
#Else
        lienzo.DrawImage(bmp, New Rectangle(0, 0, 72 * nFactorW, 72 * nFactorH), 0, 0, 72, 72, GraphicsUnit.Pixel, imageAttr)
#End If

        'FormCargando.PictureBoxModulo.Image = 
        Dim g As Graphics
        g = FormCargando.LabelNombreModulo.TopLevelControl.CreateGraphics
        'If sNombreModulo.Length >= g.ToString.Length Then
        '    FormCargando.Panel1.Height = 37 * nFactorH
        'Else
        '    FormCargando.Panel1.Height = 24 * nFactorH
        'End If
        g.Dispose()
        g = Nothing

        sNombreActividad = sNombreModulo
        FormCargando.LabelNombreModulo.Text = sNombreModulo
        FormCargando.LabelCargando.Text = "Cargando..."
        FormCargando.Refresh()

        bmp.Dispose()
        bmp = Nothing
        imageAttr = Nothing
        lienzo.Dispose()
        lienzo = Nothing
    End Sub

    Public Sub Informar()
        If FormCargando.Visible Then
            FormCargando.Visible = False
            'Else
            '    FormCargando.Visible = True
        End If
        FormCargando.Refresh()
    End Sub

    'Public Sub PubSubInformar(ByVal parsMensaje As String, ByVal parsEstado As String)
    '    FormProceso.Visible = True
    '    FormProceso.LabelProceso.Text = parsMensaje
    '    FormProceso.LabelProceso.Refresh()
    '    FormProceso.StatusBarEstado.Text = parsEstado
    '    FormProceso.StatusBarEstado.Refresh()
    '    FormProceso.ProgressBarAvance.Visible = False
    '    FormProceso.Refresh()
    'End Sub

    'Public Sub PubSubTitulo(ByVal parsTitulo As String)
    '    FormProceso.LabelTitulo.Text = parsTitulo
    '    FormProceso.LabelTitulo.Refresh()
    'End Sub

    'Public Sub PubSubInformar(ByVal parsMensaje As String)
    '    FormProceso.Visible = True
    '    FormProceso.LabelProceso.Text = parsMensaje
    '    FormProceso.LabelProceso.Refresh()
    '    FormProceso.StatusBarEstado.Text = ""
    '    FormProceso.StatusBarEstado.Refresh()
    '    FormProceso.ProgressBarAvance.Visible = False
    '    FormProceso.Refresh()
    'End Sub

    'Public Sub PubSubInformar(ByVal pariValor As Integer)
    '    FormProceso.Visible = True
    '    If Not FormProceso.ProgressBarAvance.Visible Then
    '        FormProceso.ProgressBarAvance.Visible = True
    '    End If
    '    FormProceso.ProgressBarAvance.Value = pariValor
    '    FormProceso.Refresh()
    'End Sub

    'Public Sub PubSubEstado(ByVal parsEstado As String)
    '    FormProceso.Visible = True
    '    FormProceso.StatusBarEstado.Text = parsEstado
    '    FormProceso.StatusBarEstado.Refresh()
    '    FormProceso.Refresh()
    'End Sub

    'Public Sub PubSubProceso(ByVal parsProceso As String)
    '    FormProceso.Visible = True
    '    FormProceso.LabelProceso.Text = parsProceso
    '    FormProceso.LabelProceso.Refresh()
    '    FormProceso.Refresh()
    'End Sub

    'Public Sub PubSubInformar()
    '    If FormProceso.Visible Then
    '        FormProceso.Visible = False
    '    Else
    '        FormProceso.Visible = True
    '    End If
    '    FormProceso.Refresh()
    'End Sub

End Class
