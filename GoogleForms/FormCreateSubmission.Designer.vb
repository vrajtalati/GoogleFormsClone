<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCreateSubmission
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        txtName = New TextBox()
        txtEmail = New TextBox()
        txtPhone = New TextBox()
        txtGithub = New TextBox()
        btnStopwatch = New Button()
        btnSubmit = New Button()
        lblStopwatch = New Label()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(252, 54)
        Label1.Name = "Label1"
        Label1.Size = New Size(276, 32)
        Label1.TabIndex = 0
        Label1.Text = "Vraj Talati ,Slidely Ai Task"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(47, 135)
        Label2.Name = "Label2"
        Label2.Size = New Size(78, 32)
        Label2.TabIndex = 1
        Label2.Text = "Name"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(47, 200)
        Label3.Name = "Label3"
        Label3.Size = New Size(71, 32)
        Label3.TabIndex = 2
        Label3.Text = "Email"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(47, 262)
        Label4.Name = "Label4"
        Label4.Size = New Size(142, 32)
        Label4.TabIndex = 3
        Label4.Text = "Phone Num"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(47, 319)
        Label5.Name = "Label5"
        Label5.Size = New Size(143, 64)
        Label5.TabIndex = 4
        Label5.Text = "Github Link " & vbCrLf & "for Task 2"
        ' 
        ' txtName
        ' 
        txtName.Location = New Point(252, 135)
        txtName.Name = "txtName"
        txtName.Size = New Size(423, 39)
        txtName.TabIndex = 5
        ' 
        ' txtEmail
        ' 
        txtEmail.Location = New Point(252, 197)
        txtEmail.Name = "txtEmail"
        txtEmail.Size = New Size(423, 39)
        txtEmail.TabIndex = 6
        ' 
        ' txtPhone
        ' 
        txtPhone.HideSelection = False
        txtPhone.Location = New Point(252, 262)
        txtPhone.Name = "txtPhone"
        txtPhone.Size = New Size(423, 39)
        txtPhone.TabIndex = 7
        ' 
        ' txtGithub
        ' 
        txtGithub.Location = New Point(252, 333)
        txtGithub.Name = "txtGithub"
        txtGithub.Size = New Size(423, 39)
        txtGithub.TabIndex = 8
        ' 
        ' btnStopwatch
        ' 
        btnStopwatch.Location = New Point(47, 457)
        btnStopwatch.Name = "btnStopwatch"
        btnStopwatch.Size = New Size(358, 87)
        btnStopwatch.TabIndex = 9
        btnStopwatch.Text = "TOGGLE STOPWATCH (CTRL+T)"
        btnStopwatch.UseVisualStyleBackColor = True
        ' 
        ' btnSubmit
        ' 
        btnSubmit.Location = New Point(63, 562)
        btnSubmit.Name = "btnSubmit"
        btnSubmit.Size = New Size(584, 87)
        btnSubmit.TabIndex = 10
        btnSubmit.Text = "Submit (Ctrl +S)"
        btnSubmit.UseVisualStyleBackColor = True
        ' 
        ' lblStopwatch
        ' 
        lblStopwatch.AutoSize = True
        lblStopwatch.Location = New Point(476, 484)
        lblStopwatch.Name = "lblStopwatch"
        lblStopwatch.Size = New Size(102, 32)
        lblStopwatch.TabIndex = 11
        lblStopwatch.Text = "00:00:00"
        lblStopwatch.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' FormCreateSubmission
        ' 
        AutoScaleDimensions = New SizeF(13F, 32F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(710, 674)
        Controls.Add(lblStopwatch)
        Controls.Add(btnSubmit)
        Controls.Add(btnStopwatch)
        Controls.Add(txtGithub)
        Controls.Add(txtPhone)
        Controls.Add(txtEmail)
        Controls.Add(txtName)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        FormBorderStyle = FormBorderStyle.FixedDialog
        Name = "FormCreateSubmission"
        Text = "Form2"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtName As TextBox
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents txtPhone As TextBox
    Friend WithEvents txtGithub As TextBox
    Friend WithEvents btnStopwatch As Button
    Friend WithEvents btnSubmit As Button
    Friend WithEvents lblStopwatch As Label
End Class
