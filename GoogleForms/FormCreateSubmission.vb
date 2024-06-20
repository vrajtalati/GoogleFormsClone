Imports System.Net
Imports Newtonsoft.Json
Imports System.Text.RegularExpressions

Public Class FormCreateSubmission

    ' Initialize stopwatch and timer
    Private stopwatch As New Stopwatch()
    Private WithEvents timer As New Timer()

    ' Form load event
    Private Sub FormCreateSubmission_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        timer.Interval = 1000 ' Set the timer interval to 1 second
    End Sub

    ' Submit button click event
    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        ' Read input values
        Dim name As String = txtName.Text.Trim()
        Dim email As String = txtEmail.Text.Trim()
        Dim phone As String = txtPhone.Text.Trim()
        Dim githubLink As String = txtGithub.Text.Trim()
        Dim stopwatchTime As String = lblStopwatch.Text

        ' Validate inputs
        If String.IsNullOrWhiteSpace(name) OrElse String.IsNullOrWhiteSpace(email) OrElse String.IsNullOrWhiteSpace(phone) OrElse String.IsNullOrWhiteSpace(githubLink) Then
            MessageBox.Show("All fields are compulsory.")
            Return
        End If

        If phone.Length <> 10 OrElse Not Regex.IsMatch(phone, "^\d{10}$") Then
            MessageBox.Show("Phone number must be exactly 10 digits.")
            Return
        End If

        If Not IsValidEmail(email) Then
            MessageBox.Show("Please enter a valid email address.")
            Return
        End If

        ' Create the submission data
        Dim submission As New Dictionary(Of String, String) From {
            {"name", name},
            {"email", email},
            {"phone", phone},
            {"github_link", githubLink},
            {"stopwatch_time", stopwatchTime}
        }

        ' Serialize the submission data to JSON
        Dim json As String = JsonConvert.SerializeObject(submission)

        ' Create a new WebClient for the HTTP request
        Dim client As New WebClient()
        client.Headers.Add(HttpRequestHeader.ContentType, "application/json")

        ' Submit the form
        Try
            Dim response As String = client.UploadString("http://localhost:3000/submit", "POST", json)
            MessageBox.Show("Submission successful!")

            ' Reset the form and stopwatch after successful submission
            ResetForm()
            ResetStopwatch()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    ' Stopwatch button click event
    Private Sub btnStopwatch_Click(sender As Object, e As EventArgs) Handles btnStopwatch.Click
        ' Toggle the stopwatch state
        If stopwatch.IsRunning Then
            stopwatch.Stop()
            timer.Stop()
        Else
            stopwatch.Start()
            timer.Start()
        End If
    End Sub

    ' Timer tick event
    Private Sub Timer_Tick(sender As Object, e As EventArgs) Handles timer.Tick
        ' Update the stopwatch label with the elapsed time
        lblStopwatch.Text = stopwatch.Elapsed.ToString("hh\:mm\:ss")
    End Sub

    ' Handle keyboard shortcuts
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        ' Handle Ctrl+S shortcut to submit the form
        If keyData = (Keys.Control Or Keys.S) Then
            btnSubmit.PerformClick()
            Return True
            ' Handle Ctrl+T shortcut to start/stop the stopwatch
        ElseIf keyData = (Keys.Control Or Keys.T) Then
            btnStopwatch.PerformClick()
            Return True
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    ' Reset the form fields
    Private Sub ResetForm()
        txtName.Clear()
        txtEmail.Clear()
        txtPhone.Clear()
        txtGithub.Clear()
    End Sub

    ' Reset the stopwatch to 00:00:00
    Private Sub ResetStopwatch()
        stopwatch.Reset()
        lblStopwatch.Text = "00:00:00"
    End Sub

    ' Validate email format
    Private Function IsValidEmail(email As String) As Boolean
        Try
            Dim addr = New System.Net.Mail.MailAddress(email)
            Return addr.Address = email
        Catch
            Return False
        End Try
    End Function

    ' Placeholder for any additional events or methods
    Private Sub txtName_TextChanged(sender As Object, e As EventArgs) Handles txtName.TextChanged
        ' This method can be used for additional event handling if needed
    End Sub

End Class
