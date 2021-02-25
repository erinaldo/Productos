#If MOD_TERM <> "PALM" Then
Public Class CWireless

    Public Shared Function ConfiguraWiFi(ByVal Red As String, ByVal pass As String, ByVal AuthenticationMode As Integer, ByVal _EAPType As Integer, ByVal _Enable8021x As Boolean, ByVal _WEPStatus As Integer) As Boolean
#If SO_WCE = 0 And MOD_TERM = "INTERMEC" Then
        Dim i As Integer
        Select Case AuthenticationMode
            Case 0 'AuthenticationMode.Ndis802_11AuthModeOpen
                i = Intermec.Communication.WLAN.WLAN80211pm.SetField(Intermec.Communication.WLAN.WLAN80211pm.FieldNames.ASSOCIATION, Intermec.Communication.WLAN.WLAN80211pm.ProfileNames.PROFILE1, Intermec.Communication.WLAN.WLAN80211pm.FieldValues.OPEN_STR)
            Case 1 'AuthenticationMode.Ndis802_11AuthModeShared
                i = Intermec.Communication.WLAN.WLAN80211pm.SetField(Intermec.Communication.WLAN.WLAN80211pm.FieldNames.ASSOCIATION, Intermec.Communication.WLAN.WLAN80211pm.ProfileNames.PROFILE1, Intermec.Communication.WLAN.WLAN80211pm.FieldValues.SHARED_STR)
            Case 2 'AuthenticationMode.Ndis802_11AuthModeAutoSwitch
                i = Intermec.Communication.WLAN.WLAN80211pm.SetField(Intermec.Communication.WLAN.WLAN80211pm.FieldNames.ASSOCIATION, Intermec.Communication.WLAN.WLAN80211pm.ProfileNames.PROFILE1, Intermec.Communication.WLAN.WLAN80211pm.FieldValues.OPEN_STR)
            Case 3 'AuthenticationMode.Ndis802_11AuthModeWPA
                i = Intermec.Communication.WLAN.WLAN80211pm.SetField(Intermec.Communication.WLAN.WLAN80211pm.FieldNames.ASSOCIATION, Intermec.Communication.WLAN.WLAN80211pm.ProfileNames.PROFILE1, Intermec.Communication.WLAN.WLAN80211pm.FieldValues.WPA_STR)
            Case 4 'AuthenticationMode.Ndis802_11AuthModeWPAPSK
                i = Intermec.Communication.WLAN.WLAN80211pm.SetField(Intermec.Communication.WLAN.WLAN80211pm.FieldNames.ASSOCIATION, Intermec.Communication.WLAN.WLAN80211pm.ProfileNames.PROFILE1, Intermec.Communication.WLAN.WLAN80211pm.FieldValues.WPA_STR)
            Case 5 'AuthenticationMode.Ndis802_11AuthModeWPANone
                i = Intermec.Communication.WLAN.WLAN80211pm.SetField(Intermec.Communication.WLAN.WLAN80211pm.FieldNames.ASSOCIATION, Intermec.Communication.WLAN.WLAN80211pm.ProfileNames.PROFILE1, Intermec.Communication.WLAN.WLAN80211pm.FieldValues.WPA_STR)
            Case 6 'AuthenticationMode.Ndis802_11AuthModeMax
                i = Intermec.Communication.WLAN.WLAN80211pm.SetField(Intermec.Communication.WLAN.WLAN80211pm.FieldNames.ASSOCIATION, Intermec.Communication.WLAN.WLAN80211pm.ProfileNames.PROFILE1, Intermec.Communication.WLAN.WLAN80211pm.FieldValues.EAP_STR)
        End Select
        If i < 0 Then
            Return False
        End If
        If _Enable8021x Then
            Select Case _EAPType
                Case 4 'MD5
                    i = Intermec.Communication.WLAN.WLAN80211pm.SetField(Intermec.Communication.WLAN.WLAN80211pm.FieldNames.AUTH_8021X, Intermec.Communication.WLAN.WLAN80211pm.ProfileNames.PROFILE1, Intermec.Communication.WLAN.WLAN80211pm.FieldValues.MD5_STR)
                Case 13 'TLS
                    i = Intermec.Communication.WLAN.WLAN80211pm.SetField(Intermec.Communication.WLAN.WLAN80211pm.FieldNames.AUTH_8021X, Intermec.Communication.WLAN.WLAN80211pm.ProfileNames.PROFILE1, Intermec.Communication.WLAN.WLAN80211pm.FieldValues.TLS_STR)
                Case 25 'PEAP
                    i = Intermec.Communication.WLAN.WLAN80211pm.SetField(Intermec.Communication.WLAN.WLAN80211pm.FieldNames.AUTH_8021X, Intermec.Communication.WLAN.WLAN80211pm.ProfileNames.PROFILE1, Intermec.Communication.WLAN.WLAN80211pm.FieldValues.PAP_STR)
                Case 26 'MSCHAPv2
                    i = Intermec.Communication.WLAN.WLAN80211pm.SetField(Intermec.Communication.WLAN.WLAN80211pm.FieldNames.AUTH_8021X, Intermec.Communication.WLAN.WLAN80211pm.ProfileNames.PROFILE1, Intermec.Communication.WLAN.WLAN80211pm.FieldValues.MSCHAPV2_STR)
            End Select
        Else
            i = Intermec.Communication.WLAN.WLAN80211pm.SetField(Intermec.Communication.WLAN.WLAN80211pm.FieldNames.AUTH_8021X, Intermec.Communication.WLAN.WLAN80211pm.ProfileNames.PROFILE1, Intermec.Communication.WLAN.WLAN80211pm.FieldValues.NONE_STR)
        End If
        If i < 0 Then
            Return False
        End If
        Select Case _WEPStatus
            Case 0 ' WEP
                i = Intermec.Communication.WLAN.WLAN80211pm.SetField(Intermec.Communication.WLAN.WLAN80211pm.FieldNames.ENCRYPTION, Intermec.Communication.WLAN.WLAN80211pm.ProfileNames.PROFILE1, Intermec.Communication.WLAN.WLAN80211pm.FieldValues.WEP_STR)
            Case 1, 2, 3 ' None
                i = Intermec.Communication.WLAN.WLAN80211pm.SetField(Intermec.Communication.WLAN.WLAN80211pm.FieldNames.ENCRYPTION, Intermec.Communication.WLAN.WLAN80211pm.ProfileNames.PROFILE1, Intermec.Communication.WLAN.WLAN80211pm.FieldValues.NONE_STR)
            Case 4, 5 ' TKIP
                i = Intermec.Communication.WLAN.WLAN80211pm.SetField(Intermec.Communication.WLAN.WLAN80211pm.FieldNames.ENCRYPTION, Intermec.Communication.WLAN.WLAN80211pm.ProfileNames.PROFILE1, Intermec.Communication.WLAN.WLAN80211pm.FieldValues.TKIP_STR)
            Case 6, 7 ' AES
                i = Intermec.Communication.WLAN.WLAN80211pm.SetField(Intermec.Communication.WLAN.WLAN80211pm.FieldNames.ENCRYPTION, Intermec.Communication.WLAN.WLAN80211pm.ProfileNames.PROFILE1, Intermec.Communication.WLAN.WLAN80211pm.FieldValues.AES_STR)
        End Select
        If i < 0 Then
            Return False
        End If
        i = Intermec.Communication.WLAN.WLAN80211pm.SetField(Intermec.Communication.WLAN.WLAN80211pm.FieldNames.SSID_VALUE, Intermec.Communication.WLAN.WLAN80211pm.ProfileNames.PROFILE1, Red)
        If i < 0 Then
            Return False
        End If
        i = Intermec.Communication.WLAN.WLAN80211pm.SetField(Intermec.Communication.WLAN.WLAN80211pm.FieldNames.PRESHARED_KEY, Intermec.Communication.WLAN.WLAN80211pm.ProfileNames.PROFILE1, pass)
        If i < 0 Then
            Return False
        End If
        i = Intermec.Communication.WLAN.WLAN80211pm.SetField(Intermec.Communication.WLAN.WLAN80211pm.FieldNames.ZERO_CONFIG, Intermec.Communication.WLAN.WLAN80211pm.ProfileNames.PROFILE1, Intermec.Communication.WLAN.WLAN80211pm.FieldValues.ZERO_CONFIG_OFF_STR)
        If i < 0 Then
            Return False
        End If

#End If
        Return True
    End Function
    Public Shared Function HabZeroConfig(ByVal habilitar As Boolean) As Boolean
#If SO_WCE = 0 And MOD_TERM = "INTERMEC" Then
        Dim i As Integer = 0
        If habilitar Then
            i = Intermec.Communication.WLAN.WLAN80211pm.SetField(Intermec.Communication.WLAN.WLAN80211pm.FieldNames.ZERO_CONFIG, Intermec.Communication.WLAN.WLAN80211pm.ProfileNames.PROFILE1, Intermec.Communication.WLAN.WLAN80211pm.FieldValues.ZERO_CONFIG_ON_STR)
        Else
            i = Intermec.Communication.WLAN.WLAN80211pm.SetField(Intermec.Communication.WLAN.WLAN80211pm.FieldNames.ZERO_CONFIG, Intermec.Communication.WLAN.WLAN80211pm.ProfileNames.PROFILE1, Intermec.Communication.WLAN.WLAN80211pm.FieldValues.ZERO_CONFIG_OFF_STR)
        End If
        If i < 0 Then
            Return False
        End If
#End If
        Return True
    End Function
End Class
#End If

