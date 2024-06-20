Imports Newtonsoft.Json
Imports System.Net

Public Class FormViewSubmission

    Private currentIndex As Integer = 0
    Private Sub FormViewSubmissions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadSubmission(currentIndex)
    End Sub

    Private Sub LoadSubmission(index As Integer)
        Dim client As New WebClient()
        Try
            Dim response As String = client.DownloadString($"http://localhost:3000/read?index={index}")
            Dim submission As Dictionary(Of String, String) = JsonConvert.DeserializeObject(Of Dictionary(Of String, String))(response)

            txtName.Text = submission("name")
            txtEmail.Text = submission("email")
            txtPhone.Text = submission("phone")
            txtGithub.Text = submission("github_link")
            lblStopwatch.Text = submission("stopwatch_time")
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrevious.Click
        If currentIndex > 0 Then
            currentIndex -= 1
            LoadSubmission(currentIndex)
        End If
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        currentIndex += 1
        LoadSubmission(currentIndex)
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        If keyData = (Keys.Control Or Keys.P) Then
            btnPrevious.PerformClick()
            Return True
        ElseIf keyData = (Keys.Control Or Keys.N) Then
            btnNext.PerformClick()
            Return True
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function


End Class