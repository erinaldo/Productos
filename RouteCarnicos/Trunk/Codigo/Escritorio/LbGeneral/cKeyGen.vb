''' -----------------------------------------------------------------------------
''' Project	 : LbGeneral
''' Class	 : cKeyGen
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que genera una llave única, en base a una semilla numérica, utilizada comúnmente como 
''' Campo Llave o ID único
''' </summary>
''' <remarks>
''' </remarks>
''' <history>
''' 	[jvazquez]	03/05/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class cKeyGen
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Fecha y hora para generar la llave. Su valor por default es la Fecha y Hora actual
    ''' al momento de hacer la llamada a la función
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[jvazquez]	03/05/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Shared vcFechaHora As String
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Semilla numérica que será la base de la generación de la llave. Su valor por default es cero.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[jvazquez]	03/05/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Shared vcSemilla As Integer = 0
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Constructor de la clase. 
    ''' Define el valor de su variable miembro vcFechaHora con la fecha y hora actuales en formato yyyyMMddHHmmssff 
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[jvazquez]	03/05/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub New()
        If (IsNothing(vcFechaHora) = True) Then
            vcFechaHora = Now.ToString("yyyyMMddHHmmssff")
        End If
    End Sub
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Función que contiene el algoritmo que genera la llave única en base a una semilla numérica
    ''' </summary>
    ''' <param name="pvSemilla"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[jvazquez]	03/05/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function KEYGEN(ByVal pvSemilla As Integer) As String
        Dim vlDateTime As String
        Dim vlNumeric As Decimal
        Dim vlString As String
        Dim vlString1 As String
        Dim vlTimeNow As String = ""
        Dim vlKey As String
        Dim vlBase As String = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ+"
        Dim vlModulo As Integer

        If (IsNothing(vcFechaHora) = True) Then
            vcFechaHora = Now.ToString("yyyyMMddHHmmssff")
        End If

        vlDateTime = vcFechaHora
        vlNumeric = Int(vlDateTime)
        vlNumeric = vlNumeric - 1899000000000000
        vlDateTime = CStr(vlNumeric)
        vlDateTime = vlDateTime.Substring(1, 13)

        vlNumeric = Now.Hour
        vlNumeric = vlNumeric + 100
        vlString = CStr(vlNumeric)
        vlTimeNow = vlTimeNow + vlString.Substring(1)

        vlNumeric = Now.Minute
        vlNumeric = vlNumeric + 100
        vlString = CStr(vlNumeric)
        vlTimeNow = vlTimeNow + vlString.Substring(1)

        vlNumeric = Now.Second
        vlNumeric = vlNumeric + 100
        vlString = CStr(vlNumeric)
        vlTimeNow = vlTimeNow + vlString.Substring(1)

        vlNumeric = Now.Millisecond
        vlNumeric = vlNumeric + 1000
        vlString = CStr(vlNumeric)
        vlTimeNow = vlTimeNow + vlString.Substring(1, 2)

        vlNumeric = vcSemilla
        vlNumeric = vlNumeric + 100
        vlString = CStr(vlNumeric)
        vlKey = vlDateTime + vlTimeNow + vlString.Substring(1)
        If vcSemilla = 99 Then
            vcSemilla = 0
        Else
            vcSemilla = vcSemilla + 1
        End If

        vlNumeric = vlKey
        vlString = ""

        While vlNumeric > 0
            vlModulo = (vlNumeric Mod 36) + 1
            vlNumeric = vlNumeric / 36
            vlNumeric = Int(vlNumeric)
            vlString1 = vlBase.Substring(vlModulo, 1)
            vlString = vlString1 + vlString
        End While

        Return vlString
    End Function
End Class
