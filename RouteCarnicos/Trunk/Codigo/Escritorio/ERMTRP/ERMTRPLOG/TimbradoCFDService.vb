Imports System.Net
Imports System.Security.Cryptography.X509Certificates
Namespace com.tralix.pac
    Partial Public Class TimbradoCFDService
        Inherits System.Web.Services.Protocols.SoapHttpClientProtocol
        Protected Overrides Function GetWebRequest(ByVal uri As Uri) As WebRequest

            Dim request As HttpWebRequest = DirectCast(MyBase.GetWebRequest(uri), HttpWebRequest)
            request.Headers.Add("CustomerKey: " + sCustomerKey)

            Return request
        End Function


        Private Function Clonar(ByVal dsOriginal As IO.Stream) As IO.Stream


            'Creamos un stream en memoria

            Dim formatter As Runtime.Serialization.IFormatter = New Runtime.Serialization.Formatters.Binary.BinaryFormatter()

            Dim stream As IO.Stream = New IO.MemoryStream()

            Using stream


                formatter.Serialize(stream, dsOriginal)

                stream.Seek(0, IO.SeekOrigin.Begin)

                'Deserializamos la porcin de memoria en el nuevo objeto


                Return DirectCast(formatter.Deserialize(stream), IO.Stream)
            End Using

        End Function

        Sub Copy(ByVal fromStream As IO.Stream, ByVal toStream As IO.Stream)
            Dim reader As New IO.StreamReader(fromStream)
            Dim writer As New IO.StreamWriter(toStream)
            writer.WriteLine(reader.ReadToEnd())
            writer.Flush()

        End Sub

        Protected Shadows Function Invoke(ByVal a As String, ByVal o As Object()) As Object()
            Dim objetos As Object()
            Try
                objetos = DirectCast(MyBase.Invoke(a, o), Object())
            Catch ex As System.ArgumentException
            End Try

            Return objetos
        End Function

        Protected Overrides Function GetWebResponse(ByVal request As WebRequest) As WebResponse

            'Leer Pauqete con xml embebido

            Dim response As HttpWebResponse = DirectCast(MyBase.GetWebResponse(request), WebResponse)


            Dim ReceiveStream As IO.Stream = response.GetResponseStream


            Dim encode As Text.Encoding = System.Text.Encoding.GetEncoding("utf-8")


            Dim readStream As New IO.StreamReader(CType(ReceiveStream, System.IO.Stream), encode)

            Dim read(256) As [Char]

            ' De 256

            Dim count As Integer = readStream.Read(read, 0, 256)

            Dim sbuilder As New System.Text.StringBuilder()

            While count > 0


                sbuilder.Append(New [String](read, 0, count))
                count = readStream.Read(read, 0, 256)

            End While

            ' Release the resources of stream object.        
            readStream.Close()
            ReceiveStream.Close()


            LlenarSello(sbuilder.ToString())

            Return response
        End Function


        'Protected Overrides Function GetWebResponse(ByVal request As WebRequest) As WebResponse

        '    'Leer Pauqete con xml embebido

        '    Dim response As HttpWebResponse = DirectCast(MyBase.GetWebResponse(request), WebResponse)




        '    Return response
        'End Function



        Private Sub LlenarSello(ByVal sXml As String)
            Dim oXml As New System.Xml.XmlDocument()
            oXml.LoadXml(sXml)
            Dim oNodo As Xml.XmlNode

            Try
                oNodo = oXml.ChildNodes(1).ChildNodes(0).ChildNodes(0)
            Catch ex As Exception
                Throw New CFDiException("-1", sXml)
            End Try

            If (oNodo.LocalName = "TimbreFiscalDigital") Then
                oTimbreFiscal = New CFDi.cTimbreFiscal()
                oTimbreFiscal.FechaTimbrado = oNodo.Attributes("FechaTimbrado").Value
                oTimbreFiscal.noCertificadoSAT = oNodo.Attributes("noCertificadoSAT").Value
                oTimbreFiscal.selloCFD = oNodo.Attributes("selloCFD").Value
                oTimbreFiscal.selloSAT = oNodo.Attributes("selloSAT").Value
                oTimbreFiscal.UUID = oNodo.Attributes("UUID").Value
                oTimbreFiscal.version = oNodo.Attributes("version").Value

            Else
                Dim a As New System.Xml.XmlQualifiedName()
                Dim oNodoCodigo As Xml.XmlNode = oNodo.ChildNodes(0).ChildNodes(0)
                Throw New CFDiException(oNodoCodigo.Attributes(0).InnerText, oNodo.InnerText)
            End If




        End Sub
        Public oTimbreFiscal As CFDi.cTimbreFiscal

        Public sCustomerKey As String
        Public Sub New(ByVal CustomerKey As String, ByVal URL As String)

            MyBase.New()
            Dim a As New System.Net.Security.RemoteCertificateValidationCallback(AddressOf ValidateSSL)
            'Me.Url = Global.ERMTRPLOG.My.MySettings.Default.ERMTRPLOG_com_tralix_pac_TimbradoCFDService
            Me.Url = URL
            Me.sCustomerKey = CustomerKey
            If (Me.IsLocalFileSystemWebService(Me.Url) = True) Then
                Me.UseDefaultCredentials = True
                Me.useDefaultCredentialsSetExplicitly = False
            Else
                Me.useDefaultCredentialsSetExplicitly = True
            End If
        End Sub

        Public Function ValidateSSL(ByVal sender As Object, ByVal certificate As System.Security.Cryptography.X509Certificates.X509Certificate, ByVal chain As System.Security.Cryptography.X509Certificates.X509Chain, ByVal sspolicyerrors As System.Net.Security.SslPolicyErrors) As Boolean
            Return True
        End Function


        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:TimbradoCFD", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Bare)> _
        Public Sub TimbradoCFDSinRespuesta(<System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://www.sat.gob.mx/cfd/3")> ByVal Comprobante As Comprobante)




            Me.Invoke("TimbradoCFD", New Object() {Comprobante})




        End Sub

       

    End Class


    'System.Net.ServicePointManager.ServerCertificateValidationCallback  =  new System.Net.Security.RemoteCertificateValidationCallback(ValidateSSL);

    'static Boolean ValidateSSL(object sender, X509Certificate certificate,X509Chain chain, SslPolicyErrors sslPolicyErrors)
    '{
    '    // Validar el certificado...

    '    // Un ejemplo tosco para aceptar cualquiera sin errores.
    '    return sslPolicyErrors == SslPolicyErrors.None;
    '}


    Public Class TrustAllCertificatePolicy
        Implements System.Net.ICertificatePolicy


        Public Sub New()
        End Sub


        Public Function CheckValidationResult(ByVal srvPoint As System.Net.ServicePoint, ByVal certificate As System.Security.Cryptography.X509Certificates.X509Certificate, ByVal request As System.Net.WebRequest, ByVal certificateProblem As Integer) As Boolean Implements System.Net.ICertificatePolicy.CheckValidationResult
            Return True
        End Function
    End Class
End Namespace
