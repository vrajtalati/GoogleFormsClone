Imports System.Net
Imports Newtonsoft.Json

Public Class FormCreateSubmission

    Private stopwatch As New Stopwatch()
    Private WithEvents timer As New Timer()

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer.Interval = 1000
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim name As String = txtName.Text
        Dim email As String = txtEmail.Text
        Dim phone As String = txtPhone.Text
        Dim githubLink As String = txtGithub.Text
        Dim stopwatchTime As String = lblStopwatch.Text

        Dim submission As New Dictionary(Of String, String) From {
            {"name", name},
            {"email", email},
            {"phone", phone},
            {"github_link", githubLink},
            {"stopwatch_time", stopwatchTime}
        }

        Dim json As String = JsonConvert.SerializeObject(submission)
        Dim client As New WebClient()
        client.Headers.Add(HttpRequestHeader.ContentType, "application/json")

        Try
            Dim response As String = client.UploadString("http://localhost:3000/submit", "POST", json)
            MessageBox.Show("Submission successful!")
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub
    Private Sub btnStopwatch_Click(sender As Object, e As EventArgs) Handles btnStopwatch.Click
        If Stopwatch.IsRunning Then
            Stopwatch.Stop()
            Timer.Stop()
        Else
            Stopwatch.Start()
            Timer.Start()
        End If
    End Sub

    Private Sub timer_Tick(sender As Object, e As EventArgs) Handles timer.Tick
        lblStopwatch.Text = Stopwatch.Elapsed.ToString("hh\:mm\:ss")
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        If keyData = (Keys.Control Or Keys.S) Then
            btnSubmit.PerformClick()
            Return True
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
End Class

