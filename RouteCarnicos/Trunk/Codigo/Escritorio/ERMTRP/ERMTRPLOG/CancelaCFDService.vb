Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Xml.Serialization
Imports System.Net
Imports System.Security.Cryptography.X509Certificates

Namespace net.cloudapp.pruebacfdicancelacion


    Partial Public Class CancelaCFDService
        Inherits System.Web.Services.Protocols.SoapHttpClientProtocol



        '''<remarks/>
        ''' 

        Public sCustomerKey As String

        Public Sub New(ByVal sCustomerKey As String)
            MyBase.New()
            sCustomerKey = sCustomerKey
            Me.Url = Global.ERMTRPLOG.My.MySettings.Default.ERMTRPLOG_net_cloudapp_pruebacfdicancelacion_CancelaCFDService
            If (Me.IsLocalFileSystemWebService(Me.Url) = True) Then
                Me.UseDefaultCredentials = True
                Me.useDefaultCredentialsSetExplicitly = False
            Else
                Me.useDefaultCredentialsSetExplicitly = True
            End If
        End Sub

        Protected Overrides Function GetWebRequest(ByVal uri As Uri) As WebRequest

            Dim request As HttpWebRequest = DirectCast(MyBase.GetWebRequest(uri), HttpWebRequest)
            request.Headers.Add("CustomerKey: " + sCustomerKey)

            Return request
        End Function

    End Class



End Namespace