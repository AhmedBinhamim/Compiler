Public Class cToken
    Public Kind As Integer
    Public Spelling As String = ""

    ' Token types
    Public Shared END_OF_FILE As Integer = 1
    Public Shared IDENTIFIER As Integer = 2
    Public Shared NUMBER As Integer = 3
    Public Shared PLUS_OPERATOR As Integer = 4
    Public Shared MINUS_OPERATOR As Integer = 5
    Public Shared MULTIPLY_OPERATOR As Integer = 6
    Public Shared DIVIDE_OPERATOR As Integer = 7
    Public Shared ASSIGNMENT As Integer = 8
    Public Shared OPEN_PAREN As Integer = 9
    Public Shared CLOSE_PAREN As Integer = 10
    Public Shared UNKNOWN As Integer = 11

    Public Sub New(ByVal kind As Integer, ByVal spelling As String)
        Me.Kind = kind
        Me.Spelling = spelling
    End Sub

    Public Overrides Function ToString() As String
        Dim kindString As String
        Select Case Kind
            Case END_OF_FILE
                kindString = "END_OF_FILE"
            Case IDENTIFIER
                kindString = "IDENTIFIER"
            Case NUMBER
                kindString = "NUMBER"
            Case PLUS_OPERATOR
                kindString = "PLUS_OPERATOR"
            Case MINUS_OPERATOR
                kindString = "MINUS_OPERATOR"
            Case MULTIPLY_OPERATOR
                kindString = "MULTIPLY_OPERATOR"
            Case DIVIDE_OPERATOR
                kindString = "DIVIDE_OPERATOR"
            Case ASSIGNMENT
                kindString = "ASSIGNMENT"
            Case OPEN_PAREN
                kindString = "OPEN_PAREN"
            Case CLOSE_PAREN
                kindString = "CLOSE_PAREN"
            Case Else
                kindString = "UNKNOWN"
        End Select

        Return $"Token Kind: {kindString}, Token Spelling: {Spelling}"
    End Function
End Class
