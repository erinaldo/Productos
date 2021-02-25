Public Class ChkStatus
    Inherits CheckBox

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

    Private Valor As Integer

    Public WriteOnly Property Estado() As Integer
        Set(ByVal Value As Integer)
            If Value = 1 Then
                Me.Checked = True
            Else
                Me.Checked = False
            End If
        End Set
    End Property

    Public ReadOnly Property GetEstado() As Integer
        Get
            Return Valor
        End Get
    End Property


    Private Sub ChkStatus_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.CheckedChanged
        If Me.Checked = True Then
            Valor = 1
        Else
            Valor = 0
        End If
    End Sub
End Class
