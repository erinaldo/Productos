﻿'------------------------------------------------------------------------------
' <auto-generated>
'     Este código fue generado por una herramienta.
'     Versión de runtime:4.0.30319.42000
'
'     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
'     se vuelve a generar el código.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On



<Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
 Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0"),  _
 Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
Partial Friend NotInheritable Class MySettings
    Inherits Global.System.Configuration.ApplicationSettingsBase
    
    Private Shared defaultInstance As MySettings = CType(Global.System.Configuration.ApplicationSettingsBase.Synchronized(New MySettings()),MySettings)
    
#Region "Funcionalidad para autoguardar de My.Settings"
#If _MyType = "WindowsForms" Then
    Private Shared addedHandler As Boolean

    Private Shared addedHandlerLockObject As New Object

    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)> _
    Private Shared Sub AutoSaveSettings(ByVal sender As Global.System.Object, ByVal e As Global.System.EventArgs)
        If My.Application.SaveMySettingsOnExit Then
            My.Settings.Save()
        End If
    End Sub
#End If
#End Region
    
    Public Shared ReadOnly Property [Default]() As MySettings
        Get
            
#If _MyType = "WindowsForms" Then
               If Not addedHandler Then
                    SyncLock addedHandlerLockObject
                        If Not addedHandler Then
                            AddHandler My.Application.Shutdown, AddressOf AutoSaveSettings
                            addedHandler = True
                        End If
                    End SyncLock
                End If
#End If
            Return defaultInstance
        End Get
    End Property
    
    <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString),  _
     Global.System.Configuration.DefaultSettingValueAttribute("Data Source=JMALCALA;Initial Catalog=pvta;User ID=sa;Password=dbsa")>  _
    Public ReadOnly Property pvtaConnectionString() As String
        Get
            Return CType(Me("pvtaConnectionString"),String)
        End Get
    End Property
    
    <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString),  _
     Global.System.Configuration.DefaultSettingValueAttribute("Provider=SQLOLEDB;Data Source=JMALCALA;Persist Security Info=True;Password=dbsa;U"& _ 
        "ser ID=sa;Initial Catalog=pvta")>  _
    Public ReadOnly Property ConnectionString() As String
        Get
            Return CType(Me("ConnectionString"),String)
        End Get
    End Property
    
    <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString),  _
     Global.System.Configuration.DefaultSettingValueAttribute("Data Source=JMALCALAS;Initial Catalog=pvta;Persist Security Info=True;User ID=sa;"& _ 
        "Password=dbsa")>  _
    Public ReadOnly Property pvtaConnectionString1() As String
        Get
            Return CType(Me("pvtaConnectionString1"),String)
        End Get
    End Property
    
    <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString),  _
     Global.System.Configuration.DefaultSettingValueAttribute("Data Source=JMALCALAS;Initial Catalog=Demo;Persist Security Info=True;User ID=sa;"& _ 
        "Password=dbsa")>  _
    Public ReadOnly Property DemoConnectionString() As String
        Get
            Return CType(Me("DemoConnectionString"),String)
        End Get
    End Property
    
    <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString),  _
     Global.System.Configuration.DefaultSettingValueAttribute("Data Source=JMALCALAS;Initial Catalog=Selling;Persist Security Info=True;User ID="& _ 
        "sa;Password=dbsa")>  _
    Public ReadOnly Property SellingConnectionString() As String
        Get
            Return CType(Me("SellingConnectionString"),String)
        End Get
    End Property
    
    <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString),  _
     Global.System.Configuration.DefaultSettingValueAttribute("Data Source=JALCALAS\JMALCALAS;Initial Catalog=Selling;Persist Security Info=True"& _ 
        ";User ID=sa;Password=dbsa")>  _
    Public ReadOnly Property SellingConnectionString1() As String
        Get
            Return CType(Me("SellingConnectionString1"),String)
        End Get
    End Property
    
    <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString),  _
     Global.System.Configuration.DefaultSettingValueAttribute("Data Source=ALPE\ALPE;Initial Catalog=Selling;Persist Security Info=True;User ID="& _ 
        "sa;Password=dbsa")>  _
    Public ReadOnly Property SellingConnectionString2() As String
        Get
            Return CType(Me("SellingConnectionString2"),String)
        End Get
    End Property
    
    <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString),  _
     Global.System.Configuration.DefaultSettingValueAttribute("Data Source=ALPE\ALPE;Initial Catalog=Demo;Integrated Security=True")>  _
    Public ReadOnly Property DemoConnectionString1() As String
        Get
            Return CType(Me("DemoConnectionString1"),String)
        End Get
    End Property
    
    <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString),  _
     Global.System.Configuration.DefaultSettingValueAttribute("Data Source=25.60.170.32\NAVA;Initial Catalog=Selling;Persist Security Info=True;"& _ 
        "User ID=sa;Password=dbsa")>  _
    Public ReadOnly Property SellingConnectionString3() As String
        Get
            Return CType(Me("SellingConnectionString3"),String)
        End Get
    End Property
    
    <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString),  _
     Global.System.Configuration.DefaultSettingValueAttribute("Provider=SQLOLEDB;Data Source=.\EWO;Persist Security Info=True;Password=dbsa;User"& _ 
        " ID=sa;Initial Catalog=Selling")>  _
    Public ReadOnly Property ConnectionString4() As String
        Get
            Return CType(Me("ConnectionString4"),String)
        End Get
    End Property
    
    <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString),  _
     Global.System.Configuration.DefaultSettingValueAttribute("Data Source=.\SQL2005;Initial Catalog=Selling;Persist Security Info=True;User ID="& _ 
        "sa;Password=dbsa")>  _
    Public ReadOnly Property SellingConnectionString4() As String
        Get
            Return CType(Me("SellingConnectionString4"),String)
        End Get
    End Property
    
    <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString),  _
     Global.System.Configuration.DefaultSettingValueAttribute("Data Source=.\EWO;Initial Catalog=Selling;Integrated Security=True")>  _
    Public ReadOnly Property Selling8() As String
        Get
            Return CType(Me("Selling8"),String)
        End Get
    End Property
    
    <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.WebServiceUrl),  _
     Global.System.Configuration.DefaultSettingValueAttribute("https://dev.facturacfdi.mx:8081/WSTimbrado/WSTimbradoCFDIService")>  _
    Public ReadOnly Property Selling_mx_facturacfdi_dev_WSTimbradoCFDIService() As String
        Get
            Return CType(Me("Selling_mx_facturacfdi_dev_WSTimbradoCFDIService"),String)
        End Get
    End Property
    
    <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString),  _
     Global.System.Configuration.DefaultSettingValueAttribute("Data Source=187.241.167.109;Initial Catalog=Selling;User ID=sa;Password=LsUdC7A7k"& _ 
        "7vnmX8D")>  _
    Public ReadOnly Property SellingConnectionString5() As String
        Get
            Return CType(Me("SellingConnectionString5"),String)
        End Get
    End Property
    
    <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString),  _
     Global.System.Configuration.DefaultSettingValueAttribute("Data Source=APEREZ;Initial Catalog=Selling;User ID=sa;Password=Aldo123")>  _
    Public ReadOnly Property SellingConnectionString6() As String
        Get
            Return CType(Me("SellingConnectionString6"),String)
        End Get
    End Property
    
    <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString),  _
     Global.System.Configuration.DefaultSettingValueAttribute("Data Source=192.168.10.183;Initial Catalog=Selling;User ID=sa;Password=LsUdC7A7k7"& _ 
        "vnmX8D")>  _
    Public ReadOnly Property SellingConnectionString7() As String
        Get
            Return CType(Me("SellingConnectionString7"),String)
        End Get
    End Property
    
    <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString),  _
     Global.System.Configuration.DefaultSettingValueAttribute("Data Source=CALIDADT100;Initial Catalog=Selling_T100;User ID=sa;Password=LsUdC7A7"& _ 
        "k7vnmX8D")>  _
    Public ReadOnly Property Selling_T100ConnectionString() As String
        Get
            Return CType(Me("Selling_T100ConnectionString"),String)
        End Get
    End Property
End Class

Namespace My
    
    <Global.Microsoft.VisualBasic.HideModuleNameAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
    Friend Module MySettingsProperty
        
        <Global.System.ComponentModel.Design.HelpKeywordAttribute("My.Settings")>  _
        Friend ReadOnly Property Settings() As Global.Selling.MySettings
            Get
                Return Global.Selling.MySettings.Default
            End Get
        End Property
    End Module
End Namespace
