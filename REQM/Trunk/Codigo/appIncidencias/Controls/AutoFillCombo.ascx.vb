Public Partial Class AutoFillCombo
    Inherits System.Web.UI.UserControl

    Private _Table As String
    Private _TextValue As String
    Private _IDValue As String
    Private _OrderBy As String
    Private _ZeroValue As String
    Private _SelectedValue As Integer
    Private _SelectedText As String

    Public Property Table() As String
        Get
            Return _Table
        End Get
        Set(ByVal value As String)
            _Table = value
        End Set
    End Property
    Public Property TextValue() As String
        Get
            Return _TextValue
        End Get
        Set(ByVal value As String)
            _TextValue = value
        End Set
    End Property
    Public Property IDValue() As String
        Get
            Return _IDValue
        End Get
        Set(ByVal value As String)
            _IDValue = value
        End Set
    End Property
    Public Property OrderBy() As String
        Get
            Return _OrderBy
        End Get
        Set(ByVal value As String)
            _OrderBy = value
        End Set
    End Property
    Public Property ZeroValue() As String
        Get
            Return _ZeroValue
        End Get
        Set(ByVal value As String)
            _ZeroValue = value
        End Set
    End Property
    Public ReadOnly Property SelectedValueC() As Integer

        Get
            Return dllFillCombo.SelectedValue
        End Get
        'Set(ByVal value As Integer)
        '    _SelectedValue = dllFillCombo.SelectedValue
        'End Set
    End Property
    Public ReadOnly Property SelectedTextC() As String
        Get
            Return dllFillCombo.SelectedItem.Text
        End Get
        'Set(ByVal value As String)
        '    _SelectedText = dllFillCombo.SelectedItem.Text
        'End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        fillCombo()
    End Sub
    Private Sub fillCombo()
        Try
            dllFillCombo.DataSource = AmesolREQMLog.clsUtil.fillCombo(Table, TextValue, IDValue, ConfigurationManager.ConnectionStrings("incidenciometro1ConnectionString").ToString(), OrderBy)
            dllFillCombo.DataTextField = "Text"
            dllFillCombo.DataValueField = "Value"
            dllFillCombo.DataBind()

            If Not ZeroValue = String.Empty Then
                Dim it As New ListItem(ZeroValue, 0)
                dllFillCombo.Items.Insert(0, it)
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub dllFillCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dllFillCombo.SelectedIndexChanged
        
    End Sub

End Class