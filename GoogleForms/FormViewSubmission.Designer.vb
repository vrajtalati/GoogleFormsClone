<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormViewSubmission
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
        btnPrevious = New Button()
        txtGithub = New TextBox()
        txtPhone = New TextBox()
        txtEmail = New TextBox()
        txtName = New TextBox()
        Label5 = New Label()
        Label4 = New Label()
        Label3 = New Label()
        Label2 = New Label()
        Label1 = New Label()
        lblStopwatch = New TextBox()
        Label6 = New Label()
        btnNext = New Button()
        SuspendLayout()
        ' 
        ' btnPrevious
        ' 
        btnPrevious.BackColor = SystemColors.Info
        btnPrevious.Location = New Point(112, 560)
        btnPrevious.Name = "btnPrevious"
        btnPrevious.Size = New Size(358, 87)
        btnPrevious.TabIndex = 21
        btnPrevious.Text = "PREVIOUS(CTRL+P)"
        btnPrevious.UseVisualStyleBackColor = False
        ' 
        ' txtGithub
        ' 
        txtGithub.Location = New Point(370, 369)
        txtGithub.Name = "txtGithub"
        txtGithub.ReadOnly = True
        txtGithub.Size = New Size(423, 39)
        txtGithub.TabIndex = 20
        ' 
        ' txtPhone
        ' 
        txtPhone.Location = New Point(370, 298)
        txtPhone.Name = "txtPhone"
        txtPhone.ReadOnly = True
        txtPhone.Size = New Size(423, 39)
        txtPhone.TabIndex = 19
        txtPhone.UseSystemPasswordChar = True
        ' 
        ' txtEmail
        ' 
        txtEmail.Location = New Point(370, 233)
        txtEmail.Name = "txtEmail"
        txtEmail.ReadOnly = True
        txtEmail.Size = New Size(423, 39)
        txtEmail.TabIndex = 18
        ' 
        ' txtName
        ' 
        txtName.Location = New Point(370, 173)
        txtName.Name = "txtName"
        txtName.ReadOnly = True
        txtName.Size = New Size(423, 39)
        txtName.TabIndex = 17
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(165, 355)
        Label5.Name = "Label5"
        Label5.Size = New Size(143, 64)
        Label5.TabIndex = 16
        Label5.Text = "Github Link " & vbCrLf & "for Task 2"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(165, 298)
        Label4.Name = "Label4"
        Label4.Size = New Size(142, 32)
        Label4.TabIndex = 15
        Label4.Text = "Phone Num"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(165, 236)
        Label3.Name = "Label3"
        Label3.Size = New Size(71, 32)
        Label3.TabIndex = 14
        Label3.Text = "Email"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(165, 171)
        Label2.Name = "Label2"
        Label2.Size = New Size(78, 32)
        Label2.TabIndex = 13
        Label2.Text = "Name"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 13F)
        Label1.Location = New Point(165, 54)
        Label1.Name = "Label1"
        Label1.Size = New Size(727, 47)
        Label1.TabIndex = 12
        Label1.Text = "Vraj Talati ,Slidely Ai Task 2- View Submissions" & vbCrLf
        ' 
        ' lblStopwatch
        ' 
        lblStopwatch.Location = New Point(370, 449)
        lblStopwatch.Name = "lblStopwatch"
        lblStopwatch.ReadOnly = True
        lblStopwatch.Size = New Size(423, 39)
        lblStopwatch.TabIndex = 24
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(165, 435)
        Label6.Name = "Label6"
        Label6.Size = New Size(135, 64)
        Label6.TabIndex = 23
        Label6.Text = "StopWatch " & vbCrLf & "Time"
        Label6.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' btnNext
        ' 
        btnNext.BackColor = SystemColors.ActiveCaption
        btnNext.Location = New Point(521, 560)
        btnNext.Name = "btnNext"
        btnNext.Size = New Size(358, 87)
        btnNext.TabIndex = 25
        btnNext.Text = "NEXT(CTRL+N)"
        btnNext.UseVisualStyleBackColor = False
        ' 
        ' FormViewSubmission
        ' 
        AutoScaleDimensions = New SizeF(13F, 32F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ButtonHighlight
        ClientSize = New Size(959, 671)
        Controls.Add(btnNext)
        Controls.Add(lblStopwatch)
        Controls.Add(Label6)
        Controls.Add(btnPrevious)
        Controls.Add(txtGithub)
        Controls.Add(txtPhone)
        Controls.Add(txtEmail)
        Controls.Add(txtName)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Name = "FormViewSubmission"
        Text = "Form2"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnPrevious As Button
    Friend WithEvents txtGithub As TextBox
    Friend WithEvents txtPhone As TextBox
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents txtName As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblStopwatch As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents btnNext As Button
End Class
