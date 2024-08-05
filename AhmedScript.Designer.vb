<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AhmedScript
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Label1 = New Label()
        txtExpression = New TextBox()
        lstResultLexical = New ListBox()
        btnLexicalAnalysis = New Button()
        lstResultSyntax = New ListBox()
        btnSyntaxAnalysis = New Button()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(21, 27)
        Label1.Name = "Label1"
        Label1.Size = New Size(94, 15)
        Label1.TabIndex = 0
        Label1.Text = "Enter Statement:"
        ' 
        ' txtExpression
        ' 
        txtExpression.Location = New Point(146, 24)
        txtExpression.Multiline = True
        txtExpression.Name = "txtExpression"
        txtExpression.Size = New Size(276, 24)
        txtExpression.TabIndex = 1
        ' 
        ' lstResultLexical
        ' 
        lstResultLexical.FormattingEnabled = True
        lstResultLexical.ItemHeight = 15
        lstResultLexical.Location = New Point(146, 113)
        lstResultLexical.Name = "lstResultLexical"
        lstResultLexical.Size = New Size(276, 199)
        lstResultLexical.TabIndex = 3
        ' 
        ' btnLexicalAnalysis
        ' 
        btnLexicalAnalysis.Location = New Point(146, 73)
        btnLexicalAnalysis.Name = "btnLexicalAnalysis"
        btnLexicalAnalysis.Size = New Size(154, 23)
        btnLexicalAnalysis.TabIndex = 4
        btnLexicalAnalysis.Text = "Perform Lexical Analysis"
        btnLexicalAnalysis.UseVisualStyleBackColor = True
        ' 
        ' lstResultSyntax
        ' 
        lstResultSyntax.FormattingEnabled = True
        lstResultSyntax.ItemHeight = 15
        lstResultSyntax.Location = New Point(453, 113)
        lstResultSyntax.Name = "lstResultSyntax"
        lstResultSyntax.Size = New Size(276, 199)
        lstResultSyntax.TabIndex = 6
        ' 
        ' btnSyntaxAnalysis
        ' 
        btnSyntaxAnalysis.Location = New Point(453, 73)
        btnSyntaxAnalysis.Name = "btnSyntaxAnalysis"
        btnSyntaxAnalysis.Size = New Size(154, 23)
        btnSyntaxAnalysis.TabIndex = 9
        btnSyntaxAnalysis.Text = "Perform Syntax Analysis"
        btnSyntaxAnalysis.UseVisualStyleBackColor = True
        ' 
        ' AhmedScript
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(btnSyntaxAnalysis)
        Controls.Add(lstResultSyntax)
        Controls.Add(btnLexicalAnalysis)
        Controls.Add(lstResultLexical)
        Controls.Add(txtExpression)
        Controls.Add(Label1)
        Name = "AhmedScript"
        Text = "Form1"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtExpression As TextBox
    Friend WithEvents lstResultLexical As ListBox
    Friend WithEvents btnLexicalAnalysis As Button
    Friend WithEvents lstResultSyntax As ListBox
    Friend WithEvents btnSyntaxAnalysis As Button
End Class
