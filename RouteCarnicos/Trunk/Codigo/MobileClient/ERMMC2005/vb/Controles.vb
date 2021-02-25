Imports System.ComponentModel

Namespace Controles

    Public Class NumericTextBox
        Inherits TextBox

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
            Me.TextAlign = HorizontalAlignment.Right
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

        Private _formato As String = "##0.00"
        Private _maximo As Decimal = Decimal.MaxValue

        Public Property Formato() As String
            Get
                Return _formato
            End Get
            Set(ByVal value As String)
                _formato = value
            End Set
        End Property

        Public Property Maximo() As Decimal
            Get
                Return _maximo
            End Get
            Set(ByVal value As Decimal)
                _maximo = value
            End Set
        End Property

        Protected Overrides Sub OnGotFocus(ByVal e As System.EventArgs)
            MyBase.OnGotFocus(e)

            Me.Select(0, Me.Text.Length)

        End Sub

        Protected Overrides Sub OnLostFocus(ByVal e As System.EventArgs)
            MyBase.OnLostFocus(e)
            If IsNumeric(Me.Text) Then
                Try
                    If CDec(Me.Text) < _maximo Then
                        Me.Text = Format(CDec(Me.Text), _formato)
                    Else
                        Me.Text = Format(_maximo, _formato)
                    End If
                Catch ex As Exception
                    Me.Text = Format(_maximo, _formato)
                End Try
            Else
                Me.Text = Format(0, _formato)
            End If
        End Sub

        Protected Overrides Sub OnKeyPress(ByVal e As KeyPressEventArgs)
            MyBase.OnKeyPress(e)

            Dim numberFormatInfo As Globalization.NumberFormatInfo = System.Globalization.CultureInfo.CurrentCulture.NumberFormat
            Dim decimalSeparator As String = numberFormatInfo.NumberDecimalSeparator
            Dim groupSeparator As String = numberFormatInfo.NumberGroupSeparator
            'Dim negativeSign As String = numberFormatInfo.NegativeSign

            Dim keyInput As String = e.KeyChar.ToString()

            If [Char].IsDigit(e.KeyChar) Then
                ' Digits are OK
            ElseIf keyInput.Equals(decimalSeparator) OrElse keyInput.Equals(groupSeparator) Then
                ' Decimal separator is OK
            ElseIf e.KeyChar = vbBack Then
                ' Backspace key is OK
                '    else if ((ModifierKeys & (Keys.Control | Keys.Alt)) != 0)
                '    {
                '     // Let the edit control handle control and alt key combinations
                '    }
                'ElseIf Me.SpaceOK AndAlso e.KeyChar = " "c Then

            Else
                ' Consume this invalid key and beep.
                e.Handled = True
            End If

        End Sub

        Public Property DecimalValue() As Decimal
            Get
                If IsNumeric(Me.Text) Then
                    Try
                        Return [Decimal].Parse(Me.Text)
                    Catch ex As Exception
                        Return _maximo
                    End Try
                Else
                    Return 0
                End If
            End Get
            Set(ByVal value As Decimal)
                If value > _maximo Then
                    Me.Text = Format(_maximo, _formato)
                Else
                    Me.Text = Format(value, _formato)
                End If
            End Set
        End Property

    End Class

End Namespace
