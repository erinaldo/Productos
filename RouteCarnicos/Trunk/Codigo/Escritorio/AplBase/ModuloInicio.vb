Imports BASREGLOG
Imports BASREGESC
Imports System.Reflection
Imports System.Windows.Forms

'jpacheco - 05/09/2006 11:42:00 a.m.
'para compilar con licencia (0) o sin licencia (1)
'#Const SINLICENCIA = 1
'#Const WAREHOUSE = 1


Module ModuloInicio

    'Cambiar la version del ROUTE
    Public vAPP As String = "ROUTE"
    Public vVer As String = "1.0.0"


    Public oRegistro As New CRegistro(vAPP, vVer)
    Public bActivarTimer As Boolean
    Public sRutaInicio As String = System.Windows.Forms.Application.StartupPath

    Public oFormaPadre As FormaPadre

    Sub Main()

#If Warehouse = 1 Then
        If Not IO.File.Exists(sRutaInicio & "\AplBase.ini") Then
            Dim oFAplBase As New FAplBase
            If oFAplBase.ShowDialog <> Windows.Forms.DialogResult.OK Then
                Exit Sub
            End If
        End If
#Else
        If Not Validar_Registro() Then
            Exit Sub
        End If
#End If

        Dim vlFormaLogin As New FormaLogin
        If vlFormaLogin.ShowDialog() = Windows.Forms.DialogResult.OK Then
            vlFormaLogin.Close()

            'Dim MyThread As System.Threading.Thread
            'MyThread = New System.Threading.Thread(AddressOf GeneraPadre)
            'MyThread.SetApartmentState(Threading.ApartmentState.STA)
            'MyThread.Start()
            'MyThread.Join()
            'MsgBox(System.Threading.Thread.CurrentThread.GetApartmentState)

            Dim vlFormaPadre As New FormaPadre
            If bActivarTimer Then
                vlFormaPadre.TmrTiempo.Enabled = True
            End If

#If Warehouse = 1 Then

                        '-------------------------------------------------------------------
                        'INICIO     Se activa el monitoreo de alarmas solo para el Warehouse
                        '-------------------------------------------------------------------
                        Try
                            Dim vlEnsamblado As [Assembly] = [Assembly].LoadFrom("EITALAESC.dll")
                            Dim vlMyTypes As Type() = vlEnsamblado.GetTypes()
                            Dim vlType As Type

                            For Each vlType In vlMyTypes
                                If (vlType.Name.ToLower = "cmonitoralarma") Then
                                    Dim vlMethod As MethodInfo = vlType.GetMethod("Iniciar")
                                    Dim vlObject As [Object] = Activator.CreateInstance(vlType, New Object() {vlFormaPadre, 10000})
                                    vlMethod.Invoke(vlObject, Nothing)
                                End If
                            Next vlType
                        Catch ex As Exception

                        End Try
                        '-------------------------------------------------------------------
                        'FIN        Se activa el monitoreo de alarmas solo para el Warehouse
                        '-------------------------------------------------------------------
#End If
            Application.Run(vlFormaPadre)
        End If

    End Sub

    '    Private Sub GeneraPadre()
    '        oFormaPadre = New FormaPadre

    '        'Dim vlFormaPadre As New FormaPadre
    '        If bActivarTimer Then
    '            oFormaPadre.TmrTiempo.Enabled = True
    '        End If

    '#If Warehouse = 1 Then

    '            '-------------------------------------------------------------------
    '            'INICIO     Se activa el monitoreo de alarmas solo para el Warehouse
    '            '-------------------------------------------------------------------
    '            Try
    '                Dim vlEnsamblado As [Assembly] = [Assembly].LoadFrom("EITALAESC.dll")
    '                Dim vlMyTypes As Type() = vlEnsamblado.GetTypes()
    '                Dim vlType As Type

    '                For Each vlType In vlMyTypes
    '                    If (vlType.Name.ToLower = "cmonitoralarma") Then
    '                        Dim vlMethod As MethodInfo = vlType.GetMethod("Iniciar")
    '                        Dim vlObject As [Object] = Activator.CreateInstance(vlType, New Object() {vlFormaPadre, 10000})
    '                        vlMethod.Invoke(vlObject, Nothing)
    '                    End If
    '                Next vlType
    '            Catch ex As Exception

    '            End Try
    '            '-------------------------------------------------------------------
    '            'FIN        Se activa el monitoreo de alarmas solo para el Warehouse
    '            '-------------------------------------------------------------------
    '#End If


    '        oFormaPadre.ShowDialog()

    '    End Sub

    Private Function Validar_Registro() As Boolean

#If SINLICENCIA <> 1 Then

        oRegistro.Verificar_Version()

        If oRegistro.TipoLicencia = "*" Then
            bActivarTimer = False
            Return True
        End If

        If oRegistro.TipoLicencia = "Min" Then
            oRegistro.Descontar()
            bActivarTimer = True
            Return True
        End If

        Dim oRegWizard As New BASREGESC.CInicio
        If oRegWizard.Registrar_App() Then
            Validar_Registro()
            Return True
        Else
            Return False
        End If
#Else
        Return True
#End If

    End Function

End Module
