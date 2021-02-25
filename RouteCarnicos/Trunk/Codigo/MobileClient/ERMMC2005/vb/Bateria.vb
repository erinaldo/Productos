Namespace Bateria

    Public Class SYSTEM_POWER_STATUS_EX
        Public ACLineStatus As Byte
        Public BatteryFlag As Byte
        Public BatteryLifePercent As Byte
        Public Reserved1 As Byte
        Public BatteryLifeTime As System.UInt32
        Public BatteryFullLifeTime As System.UInt32
        Public Reserved2 As Byte
        Public BackupBatteryFlag As Byte
        Public BackupBatteryLifePercent As Byte
        Public Reserved3 As Byte
        Public BackupBatteryLifeTime As System.UInt32
        Public BackupBatteryFullLifeTime As System.UInt32

        <Runtime.InteropServices.DllImport("coredll")> Public Shared Function GetSystemPowerStatusEx(ByVal lpSystemPowerStatus As SYSTEM_POWER_STATUS_EX, ByVal fUpdate As Boolean) As System.UInt32
        End Function

    End Class 'SYSTEM_POWER_STATUS_EX
End Namespace