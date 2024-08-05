Public Class AhmedScript
    Dim nextToken As cToken
    Dim sScanner As cScanner
    Dim syntaxError As Boolean = False

    Private Sub txtExpression_TextChanged(sender As Object, e As EventArgs) Handles txtExpression.TextChanged

    End Sub

    Private Sub btnLexicalAnalysis_Click(sender As Object, e As EventArgs) Handles btnLexicalAnalysis.Click
        sScanner = New cScanner(txtExpression.Text) ' Initialize the class-level scanner
        Dim currentToken As cToken

        lstResultLexical.Items.Clear()

        currentToken = sScanner.Scan()
        While currentToken.Kind <> cToken.END_OF_FILE
            lstResultLexical.Items.Add(currentToken.ToString())
            currentToken = sScanner.Scan()
        End While
    End Sub

    Private Sub acceptToken(ByVal k As Integer)
        If nextToken.Kind = k Then
            lstResultSyntax.Items.Add(nextToken.ToString)
            nextToken = sScanner.Scan()
        Else
            syntaxError = True
        End If
    End Sub

    Private Sub btnSyntaxAnalysis_Click(sender As Object, e As EventArgs) Handles btnSyntaxAnalysis.Click
        sScanner = New cScanner(txtExpression.Text) ' Initialize the class-level scanner
        Dim currentToken As cToken

        lstResultSyntax.Items.Clear()
        syntaxError = False
        nextToken = sScanner.Scan()
        ParseProgram()

        If syntaxError Or nextToken.Kind <> cToken.END_OF_FILE Then
            lstResultSyntax.Items.Add("Syntax Error!")
        Else
            lstResultSyntax.Items.Add("Syntax Correct!")
        End If
    End Sub

    Private Sub ParseProgram()
        ' <program> ::= <assignment_statement> | <expression>
        Select Case nextToken.Kind
            Case cToken.IDENTIFIER
                ParseAssignmentStatement()
            Case cToken.NUMBER
                ParseExpression()
            Case Else
                syntaxError = True
        End Select
    End Sub

    Private Sub ParseAssignmentStatement()
        ' <assignment_statement> ::= <identifier> = <expression>
        ParseIdentifier()
        acceptToken(cToken.ASSIGNMENT)
        ParseExpression()
    End Sub

    Private Sub ParseExpression()
        ' <expression> ::= <term> <expression_prime>
        ParseTerm()
        ParseExpressionPrime()
    End Sub

    Private Sub ParseExpressionPrime()
        ' <expression_prime> ::= <operator> <term> <expression_prime> | ε 
        If nextToken.Kind = cToken.PLUS_OPERATOR Or
           nextToken.Kind = cToken.MINUS_OPERATOR Or
           nextToken.Kind = cToken.MULTIPLY_OPERATOR Or
           nextToken.Kind = cToken.DIVIDE_OPERATOR Then
            ParseOperator()
            ParseTerm()
            ParseExpressionPrime()
        End If
    End Sub

    Private Sub ParseTerm()
        ' <term> ::= <number> | ( <expression> )
        If nextToken.Kind = cToken.NUMBER Then
            ParseNumber()
        ElseIf nextToken.Kind = cToken.OPEN_PAREN Then
            acceptToken(cToken.OPEN_PAREN)
            ParseExpression()
            acceptToken(cToken.CLOSE_PAREN)
        Else
            syntaxError = True
        End If
    End Sub

    Private Sub ParseNumber()
        ' <number> ::= <digit> <number_prime>
        ParseDigit()
        ParseNumberPrime()
    End Sub

    Private Sub ParseNumberPrime()
        ' <number_prime> ::= <digit> <number_prime> | ε
        If nextToken.Kind = cToken.NUMBER Then
            ParseDigit()
            ParseNumberPrime()
        End If
    End Sub

    Private Sub ParseOperator()
        ' <operator> ::= + | - | / | *
        If nextToken.Kind = cToken.PLUS_OPERATOR Or
           nextToken.Kind = cToken.MINUS_OPERATOR Or
           nextToken.Kind = cToken.MULTIPLY_OPERATOR Or
           nextToken.Kind = cToken.DIVIDE_OPERATOR Then
            acceptToken(nextToken.Kind)
        Else
            syntaxError = True
        End If
    End Sub

    Private Sub ParseIdentifier()
        ' <identifier> ::= <letter> <identifier_prime>
        ParseLetter()
        ParseIdentifierPrime()
    End Sub

    Private Sub ParseIdentifierPrime()
        ' <identifier_prime> ::= <letter> <identifier_prime> | <number> | ε
        If nextToken.Kind = cToken.IDENTIFIER Then
            ParseLetter()
            ParseIdentifierPrime()
        ElseIf nextToken.Kind = cToken.NUMBER Then
            ParseNumber()
        End If
    End Sub

    Private Sub ParseLetter()
        ' <letter> ::= a | b | .. | z
        If nextToken.Kind = cToken.IDENTIFIER Then
            acceptToken(cToken.IDENTIFIER)
        Else
            syntaxError = True
        End If
    End Sub

    Private Sub ParseDigit()
        ' <digit> ::= 0 | 1 | .. | 9
        If nextToken.Kind = cToken.NUMBER Then
            acceptToken(cToken.NUMBER)
        Else
            syntaxError = True
        End If
    End Sub
End Class
