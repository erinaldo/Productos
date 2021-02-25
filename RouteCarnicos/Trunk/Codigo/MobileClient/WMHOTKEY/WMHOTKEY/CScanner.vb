#If MOD_TERM <> "PALM" Then
#If SO_WCE = 0 And MOD_TERM = "INTERMEC" Then
Public Class BarcodeIntermecInstancia
    Public Shared WithEvents BarCodeIntermec As New Intermec.DataCollection.BarcodeReader
End Class
#End If

#If SO_WCE = 1 And MOD_TERM = "HHP" Then
Public Class BarCodeHHP7600Instacia
    Public Shared WithEvents BarCodeHHP7600 As New HHP.DataCollection.WinCE.Decoding.DecodeControl
End Class
#End If

Public Class CScanner
    Implements IDisposable

#If SO_WCE = 0 Then
#Region "SO_WCE = 0"
#If MOD_TERM = "HHP" Then
    Friend WithEvents BarCodeHHP7900 As HHP.DataCollection.PDTDecoding.DecodeControl
#ElseIf MOD_TERM = "HHPWM6" OrElse MOD_TERM = "HHP9700" Then
    Friend WithEvents BarCodeHHPWM6 As HandHeldProducts.Embedded.Decoding.DecodeComponent
#ElseIf MOD_TERM = "SYMBOL" Then
    Private WithEvents Reader1 As Symbol.Barcode.Reader
    Private readerData1 As New Symbol.Barcode.ReaderData(Symbol.Barcode.ReaderDataTypes.Text, Symbol.Barcode.ReaderDataLengths.MaximumLabel)
#ElseIf MOD_TERM = "INTERMEC" Then
    Private BarCodeIntermec As Intermec.DataCollection.BarcodeReader

#End If
#End Region
#Else
    Private BarCodeHHP7600 As HHP.DataCollection.WinCE.Decoding.DecodeControl
#End If

    Public Event Data_Scanned(ByVal Data As String)
    Protected m_terminal As SO
    Private nTipoCodigoLeido As Integer
    Private _leido As String

    Public Property Terminal() As SO
        Get
            Return m_terminal
        End Get
        Set(ByVal value As SO)
            m_terminal = value
        End Set
    End Property

    Public Sub ApagarLector()
        Select Case m_terminal
            Case SO.IntermecCN3
#If SO_WCE = 0 And MOD_TERM = "INTERMEC" Then
                'Dim bcTemp As New Intermec.DataCollection.BarcodeReader()
                Dim bcTemp As Intermec.DataCollection.BarcodeReader = BarcodeIntermecInstancia.BarCodeIntermec
                'bcTemp.ScannerOn = False
                bcTemp.ScannerEnable = False
#End If
        End Select
    End Sub

    Public Sub Inicialize_Scanner(ByVal pvTerminal As HANDHELD.SO, Optional ByVal pvSimbologia As Integer = 0)

        m_terminal = pvTerminal

        Select Case pvTerminal
#If SO_WCE = 0 And MOD_TERM = "SYMBOL" Then
            Case SO.SymbolMC55, SO.SymbolPCMC50, SO.SymbolWMobile5_MC9090
                Reader1 = New Symbol.Barcode.Reader("SCN1:")
                Reader1.Actions.Enable()
                Reader1.Actions.Read(readerData1)
#End If
            Case SO.HHP7600
#If SO_WCE = 1 And MOD_TERM = "HHP" Then
                Try
                    If IsNothing(BarCodeHHP7600) Then
                        Me.BarCodeHHP7600 = BarCodeHHP7600Instacia.BarCodeHHP7600
                        RemoveHandler BarCodeHHP7600.DecodeEvent, AddressOf BarCodeHHP7600_DecodeEvent
                    End If

                    AddHandler BarCodeHHP7600.DecodeEvent, AddressOf BarCodeHHP7600_DecodeEvent
                    Me.BarCodeHHP7600.TriggerKey = HHP.DataCollection.WinCE.Decoding.TriggerKeyEnum.TK_ONSCAN
                    If Me.BarCodeHHP7600.Name <> "BarCodeHHP7600" Then
                        If pvSimbologia = 0 Then
                            BarCodeHHP7600.EnableSymbology(HHP.DataCollection.Decoding.SymID.SYM_ALL, True)
                        Else
                            BarCodeHHP7600.EnableSymbology(HHP.DataCollection.Decoding.SymID.SYM_ALL, False)
                            BarCodeHHP7600.EnableSymbology(pvSimbologia, True)
                        End If

                        Me.BarCodeHHP7600.AimerTimeout = 0
                        Me.BarCodeHHP7600.AimIDDisplay = False
                        Me.BarCodeHHP7600.AudioMode = HHP.DataCollection.Decoding.AudioDevice.SND_STANDARD
                        Me.BarCodeHHP7600.AutoLEDs = True
                        Me.BarCodeHHP7600.AutoScan = True
                        Me.BarCodeHHP7600.AutoSounds = True
                        Me.BarCodeHHP7600.CodeIDDisplay = False
                        Me.BarCodeHHP7600.ContinuousScan = False
                        Me.BarCodeHHP7600.DecodeAttemptLimit = 800
                        Me.BarCodeHHP7600.DecodeMode = HHP.DataCollection.Decoding.DecodeMode.DM_STANDARD
                        Me.BarCodeHHP7600.LightsMode = HHP.DataCollection.Decoding.ScanLightsMode.LM_ILLUM_AIMER
                        Me.BarCodeHHP7600.LinearRange = 3
                        Me.BarCodeHHP7600.Location = New System.Drawing.Point(3, 3)
                        Me.BarCodeHHP7600.ModifierDisplay = False
                        Me.BarCodeHHP7600.Multiline = True
                        Me.BarCodeHHP7600.Name = "BarCodeHHP7600"
                        Me.BarCodeHHP7600.PrintWeight = 4
                        Me.BarCodeHHP7600.ScanTimeout = 5000
                        Me.BarCodeHHP7600.SearchTimeLimit = 400
                        Me.BarCodeHHP7600.Size = New System.Drawing.Size(232, 106)
                        Me.BarCodeHHP7600.TabIndex = 4
                        Me.BarCodeHHP7600.TabStop = False
                        Me.BarCodeHHP7600.Text = "BarCodeHHP7600"
                        Me.BarCodeHHP7600.TraceMode = False
                        Me.BarCodeHHP7600.TriggerKey = HHP.DataCollection.WinCE.Decoding.TriggerKeyEnum.TK_ONSCAN
                        Me.BarCodeHHP7600.VideoReverse = False
                        Me.BarCodeHHP7600.VirtualKeyMode = False
                        Me.BarCodeHHP7600.VirtualKeyTerm = HHP.DataCollection.Decoding.VirtualKeyTermEnum.VK_NONE

                        If pvSimbologia = HHP.DataCollection.Decoding.SymID.SYM_EAN13 Or pvSimbologia = 0 Then
                            Dim sEAN13 As New HHP.DataCollection.Decoding.SymbologyConfig(HHP.DataCollection.Decoding.SymID.SYM_EAN13)
                            sEAN13.flags = sEAN13.flags Or HHP.DataCollection.Decoding.SymFlags.SYMBOLOGY_CHECK_TRANSMIT
                            sEAN13.WriteConfig()
                        End If

                        If pvSimbologia = HHP.DataCollection.Decoding.SymID.SYM_EAN8 Or pvSimbologia = 0 Then
                            Dim sEAN8 As New HHP.DataCollection.Decoding.SymbologyConfig(HHP.DataCollection.Decoding.SymID.SYM_EAN8)
                            sEAN8.flags = HHP.DataCollection.Decoding.SymFlags.SYMBOLOGY_CHECK_TRANSMIT Or HHP.DataCollection.Decoding.SymFlags.SYMBOLOGY_ENABLE
                            sEAN8.WriteConfig()
                        End If

                        If pvSimbologia = 0 Then
                            Dim sUPCA As New HHP.DataCollection.Decoding.SymbologyConfig(HHP.DataCollection.Decoding.SymID.SYM_UPCA)
                            sUPCA.flags = HHP.DataCollection.Decoding.SymFlags.SYMBOLOGY_ENABLE Or HHP.DataCollection.Decoding.SymFlags.SYMBOLOGY_NUM_SYS_TRANSMIT
                            sUPCA.WriteConfig()
                        End If

                        If pvSimbologia = HHP.DataCollection.Decoding.SymID.SYM_TRIOPTIC Or pvSimbologia = 0 Then
                            Dim sTRIOPTIC As New HHP.DataCollection.Decoding.SymbologyConfig(HHP.DataCollection.Decoding.SymID.SYM_TRIOPTIC)
                            sTRIOPTIC.flags = HHP.DataCollection.Decoding.SymFlags.SYMBOLOGY_ENABLE
                            sTRIOPTIC.WriteConfig()
                        End If
                    End If
                Catch ex As Exception
                End Try

#End If
            Case SO.HHP7900
#If SO_WCE = 0 And MOD_TERM = "HHP" Then
                Me.BarCodeHHP7900 = New HHP.DataCollection.PDTDecoding.DecodeControl
                With BarCodeHHP7900
                    If pvSimbologia = 0 Then
                        .EnableSymbology(HHP.DataCollection.Decoding.SymID.SYM_ALL, True)
                    Else
                        .EnableSymbology(HHP.DataCollection.Decoding.SymID.SYM_ALL, False)
                        .EnableSymbology(pvSimbologia, True)
                    End If
                    .AimerTimeout = 0
                    .AimIDDisplay = False
                    .AudioMode = HHP.DataCollection.Decoding.AudioDevice.SND_STANDARD
                    .AutoLEDs = True
                    .AutoScan = True
                    .AutoSounds = True
                    .CodeIDDisplay = False
                    .ContinuousScan = False
                    .DecodeAttemptLimit = 800
                    .DecodeMode = HHP.DataCollection.Decoding.DecodeMode.DM_STANDARD
                    .LightsMode = HHP.DataCollection.Decoding.ScanLightsMode.LM_ILLUM_AIMER
                    .LinearRange = 3
                    .Location = New System.Drawing.Point(3, 3)
                    .ModifierDisplay = False
                    .Multiline = True
                    .Name = "BarCodeHHP7900"
                    .PrintWeight = 4
                    .ScanTimeout = 5000
                    .SearchTimeLimit = 400
                    .Size = New System.Drawing.Size(232, 106)
                    .TabIndex = 4
                    .TabStop = False
                    .Text = "BarCodeHHP7900"
                    .TraceMode = False
                    .TriggerKey = HHP.DataCollection.PDTDecoding.TriggerKeyEnum.TK_ONSCAN
                    .VirtualKeyMode = False
                    .VirtualKeyTerm = 0 'HHP.DataCollection.Dec
                End With
                If pvSimbologia = HHP.DataCollection.Decoding.SymID.SYM_EAN13 Or pvSimbologia = 0 Then
                    Dim sEAN13 As New HHP.DataCollection.Decoding.SymbologyConfig(HHP.DataCollection.Decoding.SymID.SYM_EAN13)
                    sEAN13.flags = sEAN13.flags Or HHP.DataCollection.Decoding.SymFlags.SYMBOLOGY_CHECK_TRANSMIT
                    sEAN13.WriteConfig()
                End If

                If pvSimbologia = HHP.DataCollection.Decoding.SymID.SYM_EAN8 Or pvSimbologia = 0 Then
                    Dim sEAN8 As New HHP.DataCollection.Decoding.SymbologyConfig(HHP.DataCollection.Decoding.SymID.SYM_EAN8)
                    sEAN8.flags = HHP.DataCollection.Decoding.SymFlags.SYMBOLOGY_CHECK_TRANSMIT Or HHP.DataCollection.Decoding.SymFlags.SYMBOLOGY_ENABLE
                    sEAN8.WriteConfig()
                End If

                If pvSimbologia = 0 Then
                    Dim sUPCA As New HHP.DataCollection.Decoding.SymbologyConfig(HHP.DataCollection.Decoding.SymID.SYM_UPCA)
                    sUPCA.flags = HHP.DataCollection.Decoding.SymFlags.SYMBOLOGY_ENABLE Or HHP.DataCollection.Decoding.SymFlags.SYMBOLOGY_NUM_SYS_TRANSMIT
                    sUPCA.WriteConfig()
                End If

                'Case SO.SymbolMC35
                '    Dim regKey As Microsoft.Win32.RegistryKey
                '    regKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Software\Microsoft\Shell\Keys\40C6", True)
                '    If (Not IsNothing(regKey)) Then
                '        regKey.SetValue("Flags", 0)
                '    End If
                '    regKey.Close()
#End If
            Case SO.HHPWM6
#If SO_WCE = 0 And (MOD_TERM = "HHPWM6") Then
                Me.BarCodeHHPWM6 = New HandHeldProducts.Embedded.Decoding.DecodeComponent(New System.ComponentModel.Container)
                With BarCodeHHPWM6
                    If pvSimbologia = 0 Then
                        .EnableSymbology(HandHeldProducts.Embedded.Decoding.SymbologyConfigurator.Symbologies.All, True)
                    Else
                        .EnableSymbology(HandHeldProducts.Embedded.Decoding.SymbologyConfigurator.Symbologies.All, False)
                        .EnableSymbology(pvSimbologia, True)
                    End If

                    .AimerDelay = 0
                    .LEDsOnDecode = True
                    .SoundOnDecode = True
                    .ContinuousScan = False
                    .DecodeMode = HandHeldProducts.Embedded.Decoding.DecodeAssembly.DecodeModes.Standard
                    .LinearRange = 3
                    .PrintWeight = 4
                    .ScanTimeout = 5000
                    .ScanKey = HandHeldProducts.Embedded.Decoding.DecodeComponent.ScanKeys.Scan
                    .ScanKeyOperation = HandHeldProducts.Embedded.Decoding.DecodeComponent.ScanKeyOptions.ScanBarcode
                    .ScanningLightsMode = HandHeldProducts.Embedded.Decoding.DecodeAssembly.ScanningLightsModes.AimerAndIllumination
                End With
                If pvSimbologia = HandHeldProducts.Embedded.Decoding.SymbologyConfigurator.Symbologies.EAN13 Or pvSimbologia = 0 Then
                    Dim sEAN13 As New HandHeldProducts.Embedded.Decoding.SymbologyConfigurator(HandHeldProducts.Embedded.Decoding.SymbologyConfigurator.Symbologies.EAN13)
                    sEAN13.Flags = sEAN13.Flags Or HandHeldProducts.Embedded.Decoding.SymbologyConfigurator.SymbologyFlags.CheckTransmit
                    sEAN13.WriteConfig()
                End If

                If pvSimbologia = HandHeldProducts.Embedded.Decoding.SymbologyConfigurator.Symbologies.EAN8 Or pvSimbologia = 0 Then
                    Dim sEAN8 As New HandHeldProducts.Embedded.Decoding.SymbologyConfigurator(HandHeldProducts.Embedded.Decoding.SymbologyConfigurator.Symbologies.EAN8)
                    sEAN8.Flags = HandHeldProducts.Embedded.Decoding.SymbologyConfigurator.SymbologyFlags.CheckTransmit Or HandHeldProducts.Embedded.Decoding.SymbologyConfigurator.SymbologyFlags.Enable
                    sEAN8.WriteConfig()
                End If

                If pvSimbologia = 0 Then
                    Dim sUPCA As New HandHeldProducts.Embedded.Decoding.SymbologyConfigurator(HandHeldProducts.Embedded.Decoding.SymbologyConfigurator.Symbologies.UPCA)
                    sUPCA.Flags = HandHeldProducts.Embedded.Decoding.SymbologyConfigurator.SymbologyFlags.Enable Or HandHeldProducts.Embedded.Decoding.SymbologyConfigurator.SymbologyFlags.NumSysTransmit
                    sUPCA.WriteConfig()
                End If
                AddHandler BarCodeHHPWM6.DecodeEvent, AddressOf BarCodeWM6_DecodeEvent
#End If

#If SO_WCE = 0 And (MOD_TERM = "HHP9700") Then
                Me.BarCodeHHPWM6 = New HandHeldProducts.Embedded.Decoding.DecodeComponent(New System.ComponentModel.Container)
                With BarCodeHHPWM6
                    If pvSimbologia = 0 Then
                        .EnableSymbology(HandHeldProducts.Embedded.Decoding.SymbologyConfigurator.Symbologies.All, True)
                    Else
                        .EnableSymbology(HandHeldProducts.Embedded.Decoding.SymbologyConfigurator.Symbologies.All, False)
                        .EnableSymbology(pvSimbologia, True)
                    End If

                    '.AimerDelay = 0
                    .LEDsOnDecode = False
                    .SoundOnDecode = False
                    .ContinuousScan = False
                    .DecodeMode = HandHeldProducts.Embedded.Decoding.DecodeAssembly.DecodeModes.Standard
                    .LinearRange = 3
                    .PrintWeight = 4
                    .ScanTimeout = 5000
                    .ScanKey = HandHeldProducts.Embedded.Decoding.DecodeComponent.ScanKeys.Scan
                    .ScanKeyOperation = HandHeldProducts.Embedded.Decoding.DecodeComponent.ScanKeyOptions.ScanBarcode
                    '.ScanningLightsMode = HandHeldProducts.Embedded.Decoding.DecodeAssembly.ScanningLightsModes.AimerAndIllumination
                End With
                If pvSimbologia = HandHeldProducts.Embedded.Decoding.SymbologyConfigurator.Symbologies.EAN13 Or pvSimbologia = 0 Then
                    Dim sEAN13 As New HandHeldProducts.Embedded.Decoding.SymbologyConfigurator(HandHeldProducts.Embedded.Decoding.SymbologyConfigurator.Symbologies.EAN13)
                    sEAN13.Flags = sEAN13.Flags Or HandHeldProducts.Embedded.Decoding.SymbologyConfigurator.SymbologyFlags.CheckTransmit
                    sEAN13.WriteConfig()
                End If

                If pvSimbologia = HandHeldProducts.Embedded.Decoding.SymbologyConfigurator.Symbologies.EAN8 Or pvSimbologia = 0 Then
                    Dim sEAN8 As New HandHeldProducts.Embedded.Decoding.SymbologyConfigurator(HandHeldProducts.Embedded.Decoding.SymbologyConfigurator.Symbologies.EAN8)
                    sEAN8.Flags = HandHeldProducts.Embedded.Decoding.SymbologyConfigurator.SymbologyFlags.CheckTransmit Or HandHeldProducts.Embedded.Decoding.SymbologyConfigurator.SymbologyFlags.Enable
                    sEAN8.WriteConfig()
                End If

                If pvSimbologia = 0 Then
                    Dim sUPCA As New HandHeldProducts.Embedded.Decoding.SymbologyConfigurator(HandHeldProducts.Embedded.Decoding.SymbologyConfigurator.Symbologies.UPCA)
                    sUPCA.Flags = HandHeldProducts.Embedded.Decoding.SymbologyConfigurator.SymbologyFlags.Enable Or HandHeldProducts.Embedded.Decoding.SymbologyConfigurator.SymbologyFlags.NumSysTransmit
                    sUPCA.WriteConfig()
                End If
                AddHandler BarCodeHHPWM6.DecodeEvent, AddressOf BarCodeWM6_DecodeEvent
#End If

            Case SO.IntermecCN3
#If SO_WCE = 0 And MOD_TERM = "INTERMEC" Then
                Try
                    If IsNothing(BarCodeIntermec) Then
                        'BarCodeIntermec = New Intermec.DataCollection.BarcodeReader()
                        BarCodeIntermec = BarcodeIntermecInstancia.BarCodeIntermec
                        RemoveHandler BarCodeIntermec.BarcodeRead, AddressOf BarCodeIntermec_Read
                    End If

                    BarCodeIntermec.ScannerEnable = True
                    AddHandler BarCodeIntermec.BarcodeRead, AddressOf BarCodeIntermec_Read
                    BarCodeIntermec.ThreadedRead(True)
                    _leido = ""
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
#End If
            Case Else

        End Select
    End Sub

    Public Sub Terminate_Scanner()
        Select Case m_terminal
            Case SO.SymbolMC55, SO.SymbolPCMC50, SO.SymbolWMobile5_MC9090
#If SO_WCE = 0 And MOD_TERM = "SYMBOL" Then
                Reader1.Actions.Disable()
                Reader1.Actions.Flush()
                Reader1.Dispose()
                readerData1.Dispose()
#End If
            Case SO.HHP7600
#If SO_WCE = 1 And MOD_TERM = "HHP" Then
                Try
                    If Not IsNothing(Me.BarCodeHHP7600) Then
                        Me.BarCodeHHP7600.TriggerKey = HHP.DataCollection.WinCE.Decoding.TriggerKeyEnum.TK_NONE
                        RemoveHandler BarCodeHHP7600.DecodeEvent, AddressOf BarCodeHHP7600_DecodeEvent
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
#End If
            Case SO.HHP7900
#If SO_WCE = 0 And MOD_TERM = "HHP" Then
                Me.BarCodeHHP7900.TriggerKey = HHP.DataCollection.PDTDecoding.TriggerKeyEnum.TK_NONE
                Me.BarCodeHHP7900.Disconnect()
                Me.BarCodeHHP7900.Dispose()
                'Case SO.SymbolMC35
                '    Dim regKey As Microsoft.Win32.RegistryKey
                '    regKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Software\Microsoft\Shell\Keys\40C6", True)
                '    If (Not IsNothing(regKey)) Then
                '        regKey.SetValue("Flags", 9)
                '        regKey.SetValue("Default", 9)
                '    End If
                '    regKey.Close()
#End If

            Case SO.HHPWM6
#If SO_WCE = 0 And MOD_TERM = "HHPWM6" Then
                RemoveHandler BarCodeHHPWM6.DecodeEvent, AddressOf BarCodeWM6_DecodeEvent
                Me.BarCodeHHPWM6.Dispose()
                LeftLEDOff()
#End If

#If SO_WCE = 0 And MOD_TERM = "HHP9700" Then
                RemoveHandler BarCodeHHPWM6.DecodeEvent, AddressOf BarCodeWM6_DecodeEvent
                Me.BarCodeHHPWM6.Dispose()
                RightLEDOff()
#End If

            Case SO.IntermecCN3
#If SO_WCE = 0 And MOD_TERM = "INTERMEC" Then
                'BarCodeIntermec.ScannerOn = False
                Try
                    If Not IsNothing(BarCodeIntermec) Then
                        BarCodeIntermec.ScannerEnable = False
                        RemoveHandler BarCodeIntermec.BarcodeRead, AddressOf BarCodeIntermec_Read
                        'BarCodeIntermec.ThreadedRead(False)
                    End If

                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

#End If
        End Select

    End Sub

#If SO_WCE = 0 Then
#Region "SO_WCE = 0"



#If MOD_TERM = "HHP" Then
    Private Sub BarCodeHHP7900_DecodeEvent(ByVal sender As Object, ByVal e As HHP.DataCollection.Decoding.DecodeBase.DecodeEventArgs) Handles BarCodeHHP7900.DecodeEvent
        Try
            RaiseEvent Data_Scanned(e.DecodeResults.pchMessage.ToString)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
#End If

#If MOD_TERM = "HHPWM6" OrElse MOD_TERM = "HHP9700" Then
    Private Sub BarCodeWM6_DecodeEvent(ByVal sender As Object, ByVal e As HandHeldProducts.Embedded.Decoding.DecodeAssembly.DecodeEventArgs)
        If e.ResultCode = HandHeldProducts.Embedded.Decoding.DecodeAssembly.ResultCodes.Success Then
            If e.Message.Length > 0 Then
                Try
                    RaiseEvent Data_Scanned(e.Message)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
        End If
    End Sub

    Private Sub LeftLEDOff()
        Dim oDeviceHardwareAssembly As HandHeldProducts.Embedded.Hardware.DeviceHardwareAssembly
        oDeviceHardwareAssembly = New HandHeldProducts.Embedded.Hardware.DeviceHardwareAssembly
        Try
            oDeviceHardwareAssembly.Device.SetLEDs(3, 0, 0, 0)
        Catch ex As PlatformNotSupportedException
            'Do nothing
        End Try

        Try
            oDeviceHardwareAssembly.Device.SetLEDs(5, 0, 0, 0)
        Catch ex As PlatformNotSupportedException
            'Do nothing
        End Try

        Try
            oDeviceHardwareAssembly.Device.SetLEDs(2, 0, 0, 0)
        Catch ex As PlatformNotSupportedException
            'Do nothing
        End Try
        oDeviceHardwareAssembly.Dispose()
    End Sub
    Private Sub RightLEDOff()
        Dim oDeviceHardwareAssembly As HandHeldProducts.Embedded.Hardware.DeviceHardwareAssembly
        oDeviceHardwareAssembly = New HandHeldProducts.Embedded.Hardware.DeviceHardwareAssembly
        Try
            oDeviceHardwareAssembly.Device.SetLEDs(1, 0, 0, 0)
        Catch ex As PlatformNotSupportedException
            'Do Nothing
        End Try

        Try
            oDeviceHardwareAssembly.Device.SetLEDs(4, 0, 0, 0)
        Catch ex As PlatformNotSupportedException
            'Do Nothing
        End Try

        Try
            oDeviceHardwareAssembly.Device.SetLEDs(0, 0, 0, 0)
        Catch ex As PlatformNotSupportedException
            'Do Nothing
        End Try
    End Sub

#End If

#If MOD_TERM = "INTERMEC" Then
    Private Sub BarCodeIntermec_Read(ByVal sender As Object, ByVal e As Intermec.DataCollection.BarcodeReadEventArgs)
        Try
            If e.strDataBuffer.Length > 0 Then
                Dim sTemp As String = e.strDataBuffer
                e.strDataBuffer = ""
                RaiseEvent Data_Scanned(sTemp)

            End If
        Catch ex As Exception
        End Try

    End Sub
#End If

#End Region
#End If

#If SO_WCE = 1 Then

    Private Sub BarCodeHHP7600_DecodeEvent(ByVal sender As Object, ByVal e As HHP.DataCollection.Decoding.DecodeBase.DecodeEventArgs)
        If BarCodeHHP7600.Connected Then
            Try
                RaiseEvent Data_Scanned(e.DecodeResults.pchMessage.ToString)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

#End If

#If SO_WCE = 0 And MOD_TERM = "SYMBOL" Then
    Private Sub Reader1_ReadNotify(ByVal sender As Object, ByVal e As System.EventArgs) Handles Reader1.ReadNotify
        Try
            If readerData1.Result = Symbol.Results.CANCELED Then
                Exit Sub
            ElseIf readerData1.Result = Symbol.Results.SUCCESS Then
                Dim sLectura As String = readerData1.Text
                Reader1.Actions.Read(readerData1)
                RaiseEvent Data_Scanned(sLectura)
            End If
        Catch ex As Exception
        End Try
    End Sub
#End If

    Public ReadOnly Property TipoCodigoLeido() As Integer
        Get
            Return nTipoCodigoLeido
        End Get
    End Property

    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free unmanaged resources when explicitly called
            End If
#If SO_WCE = 0 And MOD_TERM = "INTERMEC" Then
            If Not IsNothing(BarCodeIntermec) Then
                RemoveHandler BarCodeIntermec.BarcodeRead, AddressOf BarCodeIntermec_Read
                BarCodeIntermec = Nothing
            End If
#End If

#If SO_WCE = 1 And MOD_TERM = "HHP" Then
            If Not IsNothing(BarCodeHHP7600) Then
                RemoveHandler BarCodeHHP7600.DecodeEvent, AddressOf BarCodeHHP7600_DecodeEvent
                BarCodeHHP7600 = Nothing
            End If
#End If
        End If
        Me.disposedValue = True
    End Sub

#Region " IDisposable Support "
    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region


 
End Class
#End If

