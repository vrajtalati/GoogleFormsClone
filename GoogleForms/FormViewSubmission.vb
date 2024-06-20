Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Net

Public Class Submission
    Public Property Name As String
    Public Property Email As String
    Public Property Phone As String
    Public Property Github_Link As String
    Public Property Stopwatch_Time As String
End Class

Public Class ApiResponse
    Public Property Submission As Submission
    Public Property Total_Count As Integer
End Class


Public Class FormViewSubmission

    Private currentIndex As Integer = 0
    Private submissionCount As Integer = 0

    Private Sub FormViewSubmissions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadSubmission(currentIndex)
        UpdateNavigationButtons()
    End Sub

    Private Sub LoadSubmission(index As Integer)
        Dim client As New WebClient()
        Try
            Dim response As String = client.DownloadString($"http://localhost:3000/read?index={index}")
            Dim jsonResponse As JObject = JObject.Parse(response)

            ' Deserialize JSON to ApiResponse object
            Dim apiResponse As ApiResponse = JsonConvert.DeserializeObject(Of ApiResponse)(response)

            ' Populate form fields
            txtName.Text = apiResponse.Submission.Name
            txtEmail.Text = apiResponse.Submission.Email
            txtPhone.Text = apiResponse.Submission.Phone
            txtGithub.Text = apiResponse.Submission.Github_Link
            lblStopwatch.Text = apiResponse.Submission.Stopwatch_Time

            ' Set fields to read-only
            txtName.ReadOnly = True
            txtEmail.ReadOnly = True
            txtPhone.ReadOnly = True
            txtGithub.ReadOnly = True

            ' Get the total count
            submissionCount = apiResponse.Total_Count

            UpdateNavigationButtons()
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
        If currentIndex < submissionCount - 1 Then
            currentIndex += 1
            LoadSubmission(currentIndex)
        End If
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If txtName.ReadOnly Then
            ' Switch to edit mode
            txtName.ReadOnly = False
            txtEmail.ReadOnly = False
            txtPhone.ReadOnly = False
            txtGithub.ReadOnly = False
            btnUpdate.Text = "Save"
        Else
            ' Save updated data
            Dim client As New WebClient()
            client.Headers(HttpRequestHeader.ContentType) = "application/json"
            Dim submission As New Submission With {
                .Name = txtName.Text,
                .Email = txtEmail.Text,
                .Phone = txtPhone.Text,
                .Github_Link = txtGithub.Text,
                .Stopwatch_Time = lblStopwatch.Text
            }
            Dim jsonData As String = JsonConvert.SerializeObject(submission)
            Try
                client.UploadString($"http://localhost:3000/update?index={currentIndex}", "PUT", jsonData)
                MessageBox.Show("Submission updated successfully.")
                txtName.ReadOnly = True
                txtEmail.ReadOnly = True
                txtPhone.ReadOnly = True
                txtGithub.ReadOnly = True
                btnUpdate.Text = "Update"
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim client As New WebClient()
        Try
            client.UploadString($"http://localhost:3000/delete?index={currentIndex}", "DELETE", "")
            MessageBox.Show("Submission deleted successfully.")
            If currentIndex >= submissionCount - 1 Then
                currentIndex -= 1
            End If
            submissionCount -= 1
            LoadSubmission(currentIndex)
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub UpdateNavigationButtons()
        btnPrevious.Enabled = currentIndex > 0
        btnNext.Enabled = currentIndex < submissionCount - 1
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
