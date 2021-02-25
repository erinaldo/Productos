Imports AmesolREQMLog
Imports System.DirectoryServices

Partial Public Class Login
    Inherits System.Web.UI.Page



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    'Protected Sub Login1_LoggingIn(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LoginCancelEventArgs) Handles Login1.LoggingIn

    'End Sub

    Private Sub btnEnter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEnter.Click
        Try
            Dim oAD As New AmesolREQMLog.FormsAuth.LdapAuthentication(ConfigurationManager.AppSettings("Dominio"), ConfigurationManager.AppSettings("LDAP"))
            If oAD.IsAuthenticated(txtUser.Text.Trim, txtPassword.Text) Then
                Session("User") = txtUser.Text.Trim
                Dim ticket As New FormsAuthenticationTicket(1, Session("User").ToString(), DateTime.Now, DateTime.Now.AddHours(6), False, "", FormsAuthentication.FormsCookiePath)
                Dim hash As String = FormsAuthentication.Encrypt(ticket)
                Dim cookie = New HttpCookie(FormsAuthentication.FormsCookieName, hash)
                If (ticket.IsPersistent) Then cookie.Expires = ticket.Expiration
                Response.Cookies.Add(cookie)

                Response.Redirect("./Default.aspx")
            Else
                lblMensage.Visible = True
                txtPassword.Text = String.Empty
                txtUser.Focus()
            End If

        Catch ex As Exception

        End Try
    End Sub
    'Private Function IsAuthenticated(ByVal PathAD As String, ByVal domain As String, ByVal username As String, ByVal pwd As String) As Boolean

    '    Dim domainAndUsername As String = domain & "\\" & username
    '    Dim entry As DirectoryEntry = New DirectoryEntry("LDAP:" & PathAD, domainAndUsername, pwd)

    '    Try
    '        'Bind to the native AdsObject to force authentication.			
    '        Dim obj As Object = entry.NativeObject
    '        Dim search As DirectorySearcher = New DirectorySearcher(entry)

    '        search.Filter = "(SAMAccountName=" & username & ")"
    '        search.PropertiesToLoad.Add("cn")
    '        Dim result As SearchResult = search.FindOne()

    '        If (result Is Nothing) Then
    '            Return False
    '        End If


    '    Catch ex As Exception
    '        Throw New Exception("Error authenticating user. " & ex.Message)
    '    End Try

    '    Return True
    'End Function
End Class