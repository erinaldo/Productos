Public Class BtnMesa
    Inherits Janus.Windows.EditControls.UIButton

#Region " Component Designer generated code "

    Public Sub New(ByVal Container As System.ComponentModel.IContainer)
        MyClass.New()

        'Required for Windows.Forms Class Composition Designer support
        Container.Add(Me)
    End Sub

    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Component overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Component Designer
    'It can be modified using the Component Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container()
    End Sub

#End Region

    Private MESClave As String
    Private Clave As String


    Public WriteOnly Property setMESClave() As String
        Set(ByVal Value As String)
            MESClave = Value
        End Set
    End Property

    Public ReadOnly Property getMESClave() As String
        Get
            Return MESClave
        End Get
    End Property



    Public WriteOnly Property setClave() As String
        Set(ByVal Value As String)
            Clave = Value
        End Set
    End Property

    Public ReadOnly Property getClave() As String
        Get
            Return Clave
        End Get
    End Property


End Class
