#If MOD_TERM <> "PALM" Then
Public Class CImaging

    '#If MOD_TERM = "HHP" Then
    '#If SO_WCE = 0 Then
    '    private HHPImager As HHP.DataCollection.PDTImaging.ImageControl
    '#Else
    '    Private HHPImager As HHP.DataCollection.WinCE.Imaging.ImageControl
    '#End If
    '    Private oImagen As System.Drawing.Image
    '    Private sPathImagen As String = "\IPSM\Imagen.jpg"

#If MOD_TERM = "HHP9700" OrElse MOD_TERM = "HHPWM6" Then
    Private HHPImager As HandHeldProducts.Embedded.Imaging.ImageAssembly
    Friend WithEvents tmrImagen As Timer

#ElseIf MOD_TERM = "SYMBOL" Then
    Private SymbolImager As Symbol.Imaging.Imager
    Private WithEvents trigger As Symbol.ResourceCoordination.Trigger
    Public Event Image_Scanned(ByVal ImageStream As System.IO.MemoryStream)
#End If

    Private triggerList As ArrayList
    Private isImageView As Boolean
    Private pcbImagen As PictureBox

    'Public Event Image_Scanned_FS(ByVal ImageStream As System.IO.FileStream)

    Protected m_terminal As SO
    Private nCalidad As Integer

    Public Sub Inicialize_Imaging(ByVal pvTerminal As SO, ByVal pvCalidad As Integer, ByVal pvIniciar As Boolean, Optional ByRef pvPcbImagen As PictureBox = Nothing)
        '#If MOD_TERM = "HHP" Then
        '#If SO_WCE = 0 Then
        '        HHPImager = New HHP.DataCollection.PDTImaging.ImageControl
        '#Else
        '        HHPImager = New HHP.DataCollection.WinCE.Imaging.ImageControl
        '#End If
        '        HHPImager.ConfigFilePath = "/IPSM/ImagingProfiles.exm"
        '        HHPImager.Name = "HHPImager"
        '        HHPImager.Profile = "Normal"
        '        HHPImager.SizeMode = HHP.DataCollection.Imaging.SizeModeEnum.StretchImage
        '        HHPImager.TraceMode = False
        '        HHPImager.ZoomValue = 100
        '        nCalidad = pvCalidad
        '        pcbImagen = pvPcbImagen

#If MOD_TERM = "HHP9700" OrElse MOD_TERM = "HHPWM6" Then
        tmrImagen = New Timer
        tmrImagen.Interval = 100
        tmrImagen.Enabled = False
        If HHPImager Is Nothing Then
            HHPImager = New HandHeldProducts.Embedded.Imaging.ImageAssembly
            HHPImager.ConfigFilePath = "/IPSM/ImagingProfiles.exm"
            HHPImager.Profile = "Normal"
        End If
        pcbImagen = pvPcbImagen

#ElseIf MOD_TERM = "SYMBOL" Then
        m_terminal = pvTerminal
        Select Case pvTerminal
            Case SO.SymbolPCMC50, SO.SymbolWMobile5_MC9090, SO.SymbolMC55
                SymbolImager = New Symbol.Imaging.Imager(Symbol.Imaging.Device.AvailableDevices(0))
                SymbolImager.ImageFormat.FileFormat = Symbol.Imaging.FileFormats.JPEG
                SymbolImager.ImageFormat.JPEGQuality = pvCalidad
                triggerList = New ArrayList()
                pcbImagen = pvPcbImagen
                If pvIniciar Then
                    SymbolImager.StartAcquisition()
                    SymbolImager.Viewfinder.Start(pcbImagen)
                    isImageView = True
                Else
                    isImageView = False
                End If
                For Each device As Symbol.ResourceCoordination.TriggerDevice In Symbol.ResourceCoordination.TriggerDevice.AvailableTriggers
                    trigger = New Symbol.ResourceCoordination.Trigger
                    triggerList.Add(trigger)
                Next
        End Select
#End If
    End Sub

    Public Sub MostrarImaging()
        '#If MOD_TERM = "HHP" Then
        '        If Not isImageView Then
        '            If Not HHPImager.Connected Then
        '                HHPImager.TriggerKey = HHP.DataCollection.Imaging.TriggerKeyEnum.TK_ONSCAN
        '                HHPImager.Connect()
        '            End If
        '            HHPImager.EnableCapture = True
        '            isImageView = True
        '            'Dim oImagen As System.Drawing.Image
        '            Me.CapturePreviewImage(100, oImagen)
        '            pcbImagen.Image = oImagen
        '            pcbImagen.Refresh()
        '            oImagen.Dispose()
        '            oImagen = Nothing
        '        Else
        '            isImageView = False
        '        End If

#If MOD_TERM = "HHP9700" OrElse MOD_TERM = "HHPWM6" Then
        If Not isImageView Then
            HHPImager.CapturePreviewImage()
            pcbImagen.Image = HHPImager.GetImage
            isImageView = True
            tmrImagen.Enabled = True
        End If

#ElseIf MOD_TERM = "SYMBOL" Then
        If Not isImageView Then
            SymbolImager.StartAcquisition()
            SymbolImager.Viewfinder.Start(pcbImagen)
            isImageView = True
        Else
            SymbolImager.StopAcquisition()
            SymbolImager.Viewfinder.Stop()
            isImageView = False
        End If
#End If
    End Sub

    Public Sub Terminate_Imaging(Optional ByVal bTerminar As Boolean = False)
        '#If MOD_TERM = "HHP" Then
        '        If HHPImager.Connected Then
        '            HHPImager.Disconnect()
        '        End If
        '        For Each oControl As Control In HHPImager.Controls
        '            oControl.Dispose()
        '        Next
        '        HHPImager.TriggerKey = HHP.DataCollection.Imaging.TriggerKeyEnum.TK_NONE
        '        HHPImager.EnableCapture = False
        '        HHPImager.Dispose()
        '        HHPImager = Nothing
        '        If System.IO.File.Exists(sPathImagen) Then
        '            System.IO.File.Delete(sPathImagen)
        '        End If
        '        If Not oImagen Is Nothing Then
        '            oImagen.Dispose()
        '            oImagen = Nothing
        '        End If

#If MOD_TERM = "HHP9700" OrElse MOD_TERM = "HHPWM6" Then
        If bTerminar Then
            If Not HHPImager Is Nothing Then
                HHPImager.Dispose()
                HHPImager = Nothing
            End If
        End If
        If Not tmrImagen Is Nothing Then
            tmrImagen.Enabled = False
            tmrImagen.Dispose()
        End If
        If Not pcbImagen Is Nothing Then
            If Not pcbImagen.Image Is Nothing Then
                pcbImagen.Image.Dispose()
                pcbImagen.Image = Nothing
            End If
            pcbImagen.Dispose()
            pcbImagen = Nothing
        End If
        isImageView = False

#ElseIf MOD_TERM = "SYMBOL" Then
        Select Case m_terminal
            Case SO.SymbolPCMC50, SO.SymbolWMobile5_MC9090, SO.SymbolMC55
                For Each trigger As Symbol.ResourceCoordination.Trigger In triggerList
                    If Not (trigger Is Nothing) Then
                        trigger.Dispose()
                    End If
                Next
                triggerList.Clear()
                If Not (SymbolImager Is Nothing) Then
                    SymbolImager.StopAcquisition()
                    SymbolImager.Dispose()
                    isImageView = False
                End If
        End Select
#End If
    End Sub

    Public Sub Imagen()
#If MOD_TERM = "HHP9700" OrElse MOD_TERM = "HHPWM6" Then
        If isImageView Then
            'Dim msImagen As New System.IO.MemoryStream
            'Dim oImagen As Image
            'HHPImager.CaptureFullImage()
            'oImagen = HHPImager.GetImage
            'pcbImagen.Image = oImagen
            'oImagen.Save(msImagen, System.Drawing.Imaging.ImageFormat.Jpeg)
            'isImageView = False
            'tmrImagen.Enabled = False
            'RaiseEvent Image_Scanned(msImagen)
            'oImagen.Dispose()
            'oImagen = Nothing

            'RaiseEvent Image_Scanned(msImagen)
            'msImagen.Close()
            'msImagen = Nothing

            HHPImager.CaptureFullImage()
            isImageView = False
            tmrImagen.Enabled = False
            pcbImagen.Image = HHPImager.GetImage
            'RaiseEvent Image_Scanned(HHPImager.GetImage)
        End If

#ElseIf MOD_TERM = "SYMBOL" Then
        If isImageView Then
            Dim msImagen As System.IO.MemoryStream
            msImagen = SymbolImager.GetImage()
            If SymbolImager.Viewfinder.IsStarted Then
                SymbolImager.Viewfinder.Stop()
            End If
            SymbolImager.StopAcquisition()
            isImageView = False
            RaiseEvent Image_Scanned(msImagen)
        Else
            SymbolImager.StartAcquisition()
            SymbolImager.Viewfinder.Start(pcbImagen)
            isImageView = True
        End If
#End If
    End Sub

    '#If MOD_TERM = "HHP" Then
    '    Private Sub CapturePreviewImage(ByVal pvCalidad As Integer, ByRef prImagen As Image)
    '        Try
    '#If SO_WCE = 0 Then
    '            HHPImager.ResizeImage(35)
    '#End If
    '            HHPImager.SaveFile(sPathImagen, HHP.DataCollection.Imaging.SaveFormat.SF_JPG, pvCalidad)
    '            prImagen = New System.Drawing.Bitmap(sPathImagen)
    '        Catch ex As Exception

    '        End Try
    '    End Sub
    '#End If

#If SO_WCE = 0 And MOD_TERM = "SYMBOL" Then
    Private Sub trigger_Stage2Notify(ByVal sender As Object, ByVal e As Symbol.ResourceCoordination.TriggerEventArgs) Handles trigger.Stage2Notify
        If (e.NewState = Symbol.ResourceCoordination.TriggerState.STAGE2) Then
            Imagen()
        End If
    End Sub
#End If

#If SO_WCE = 0 And (MOD_TERM = "HHP9700" OrElse MOD_TERM = "HHPWM6") Then
    Private Sub tmrImagen_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tmrImagen.Tick
        Dim I As Integer = 0
        HHPImager.CapturePreviewImage()
        pcbImagen.Image = HHPImager.GetImage
    End Sub
#End If

End Class
#End If

