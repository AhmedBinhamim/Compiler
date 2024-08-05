Public Class cScanner
    Private currentChar As Char
    Private currentSpelling As String = ""
    Private currentIndex As Integer = 0
    Private currentKind As Integer

    ' Input program text
    Private programText As String

    Public Sub New(programText As String)
        ' Initialize the input program text and set the current character
        Me.programText = programText
        If programText.Length > 0 Then
            currentChar = programText(0)
        End If
    End Sub

    ' Helper method to append the current character to the current spelling
    ' and move to the next character in the input text
    Private Sub TakeIt()
        currentSpelling &= currentChar
        currentIndex += 1
        ' Check if there are more characters in the input text
        If currentIndex < programText.Length Then
            currentChar = programText(currentIndex)
        Else
            ' Set currentChar to an empty string if we reached the end of the input text
            currentChar = ""
        End If
    End Sub

    Private Sub SkipWhiteSpace()
        ' Skip any leading whitespace characters
        While Char.IsWhiteSpace(currentChar)
            TakeIt()
        End While
    End Sub

    ' Main scanning method that identifies tokens in the input text
    Public Function Scan() As cToken
        ' Skip any leading whitespace characters
        SkipWhiteSpace()

        ' Reset the current spelling for the new token
        currentSpelling = ""

        ' Identify the kind of the token using the ScanToken method
        currentKind = ScanToken()

        ' Create and return a new Token object with the identified kind and spelling
        Return New cToken(currentKind, currentSpelling)
    End Function

    ' Method to identify the kind of the token based on the current character
    Private Function ScanToken() As Integer
        ' Check if we reached the end of the input text
        If currentIndex = programText.Length Then
            Return cToken.END_OF_FILE
        End If

        ' Check if the current character is a digit
        ' Check if the current character is a digit
        If Char.IsDigit(currentChar) Then
            ' If it's a digit, enter state 3 and take the current character
            TakeIt()
            ' Continue taking characters while they are digits
            While Char.IsDigit(currentChar)
                TakeIt()
            End While
            ' If followed by letters, consider it as unknown
            If Char.IsLetter(currentChar) Then
                ' Take the letters
                While Char.IsLetter(currentChar)
                    TakeIt()
                End While
                Return cToken.UNKNOWN
            Else
                Return cToken.NUMBER
            End If
        ElseIf Char.IsLetter(currentChar) Then
            ' If it's a letter, enter state 2 and take the current character
            TakeIt()
            ' Continue taking characters while they are letters
            While Char.IsLetter(currentChar)
                TakeIt()
            End While
            ' If followed by digits, consider it as an identifier
            If Char.IsDigit(currentChar) Then
                ' Take the digits
                While Char.IsDigit(currentChar)
                    TakeIt()
                End While
                ' If followed by letters, consider it as unknown
                If Char.IsLetter(currentChar) Then
                    ' Take the letters
                    While Char.IsLetter(currentChar)
                        TakeIt()
                    End While
                    Return cToken.UNKNOWN
                Else
                    Return cToken.IDENTIFIER
                End If
            Else
                ' If not followed by digits, consider it as an identifier
                Return cToken.IDENTIFIER
            End If
        Else
            ' Check for operators and punctuation
            Select Case currentChar
                Case "+"
                    TakeIt()
                    Return cToken.PLUS_OPERATOR
                Case "-"
                    TakeIt()
                    Return cToken.MINUS_OPERATOR
                Case "*"
                    TakeIt()
                    Return cToken.MULTIPLY_OPERATOR
                Case "/"
                    TakeIt()
                    Return cToken.DIVIDE_OPERATOR
                Case "="
                    TakeIt()
                    Return cToken.ASSIGNMENT
                Case "("
                    TakeIt()
                    Return cToken.OPEN_PAREN
                Case ")"
                    TakeIt()
                    Return cToken.CLOSE_PAREN
                Case Else
                    ' If the current character is not recognized, return UNKNOWN
                    TakeIt()
                    Return cToken.UNKNOWN
            End Select
        End If
    End Function


End Class
