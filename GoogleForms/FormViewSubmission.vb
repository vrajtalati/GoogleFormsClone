Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Net

' Define a class to represent a single submission
Public Class Submission
    Public Property Name As String
    Public Property Email As String
    Public Property Phone As String
    Public Property Github_Link As String
    Public Property Stopwatch_Time As String
End Class

' Define a class to represent the API response containing a submission and total count
Public Class ApiResponse
    Public Property Submission As Submission
    Public Property Total_Count As Integer
End Class

' Define the form class for viewing submissions
Public Class FormViewSubmission

    ' Initialize current index and total submission count
    Private currentIndex As Integer = 0
    Private submissionCount As Integer = 0

    ' Event handler for form load
    Private Sub FormViewSubmissions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Load the first submission and update navigation buttons
        LoadSubmission(currentIndex)
        UpdateNavigationButtons()
    End Sub

    ' Method to load a submission by index
    Private Sub LoadSubmission(index As Integer)
        Dim client As New WebClient()
        Try
            ' Fetch submission data from the server
            Dim response As String = client.DownloadString($"http://localhost:3000/read?index={index}")

            ' Parse JSON response
            Dim jsonResponse As JObject = JObject.Parse(response)

            ' Deserialize JSON to ApiResponse object
            Dim apiResponse As ApiResponse = JsonConvert.DeserializeObject(Of ApiResponse)(response)

            ' Populate form fields with submission data
            txtName.Text = apiResponse.Submission.Name
            txtEmail.Text = apiResponse.Submission.Email
            txtPhone.Text = apiResponse.Submission.Phone
            txtGithub.Text = apiResponse.Submission.Github_Link
            lblStopwatch.Text = apiResponse.Submission.Stopwatch_Time

            ' Set form fields to read-only
            txtName.ReadOnly = True
            txtEmail.ReadOnly = True
            txtPhone.ReadOnly = True
            txtGithub.ReadOnly = True

            ' Update the total submission count
            submissionCount = apiResponse.Total_Count

            ' Update navigation buttons state
            UpdateNavigationButtons()
        Catch ex As Exception
            ' Show error message if there is an issue
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    ' Event handler for the "Previous" button click
    Private Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrevious.Click
        ' Navigate to the previous submission if possible
        If currentIndex > 0 Then
            currentIndex -= 1
            LoadSubmission(currentIndex)
        End If
    End Sub

    ' Event handler for the "Next" button click
    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        ' Navigate to the next submission if possible
        If currentIndex < submissionCount - 1 Then
            currentIndex += 1
            LoadSubmission(currentIndex)
        End If
    End Sub

    ' Event handler for the "Update" button click
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        ' Toggle between edit and save mode
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

            ' Create a new submission object with updated data
            Dim submission As New Submission With {
                .Name = txtName.Text,
                .Email = txtEmail.Text,
                .Phone = txtPhone.Text,
                .Github_Link = txtGithub.Text,
                .Stopwatch_Time = lblStopwatch.Text
            }

            ' Serialize submission data to JSON
            Dim jsonData As String = JsonConvert.SerializeObject(submission)

            ' Send updated data to the server
            Try
                client.UploadString($"http://localhost:3000/update?index={currentIndex}", "PUT", jsonData)
                MessageBox.Show("Submission updated successfully.")

                ' Switch back to read-only mode
                txtName.ReadOnly = True
                txtEmail.ReadOnly = True
                txtPhone.ReadOnly = True
                txtGithub.ReadOnly = True
                btnUpdate.Text = "Update"
            Catch ex As Exception
                ' Show error message if there is an issue
                MessageBox.Show("Error: " & ex.Message)
            End Try
        End If
    End Sub

    ' Event handler for the "Delete" button click
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim client As New WebClient()
        Try
            ' Send delete request to the server
            client.UploadString($"http://localhost:3000/delete?index={currentIndex}", "DELETE", "")
            MessageBox.Show("Submission deleted successfully.")

            ' Update current index after deletion
            If currentIndex >= submissionCount - 1 Then
                currentIndex -= 1
            End If

            ' Decrease total submission count
            submissionCount -= 1
            LoadSubmission(currentIndex)
        Catch ex As Exception
            ' Show error message if there is an issue
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    ' Method to update the state of navigation buttons
    Private Sub UpdateNavigationButtons()
        btnPrevious.Enabled = currentIndex > 0
        btnNext.Enabled = currentIndex < submissionCount - 1
    End Sub

    ' Override to handle custom keyboard shortcuts
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        ' Ctrl+P to navigate to the previous submission
        If keyData = (Keys.Control Or Keys.P) Then
            btnPrevious.PerformClick()
            Return True
            ' Ctrl+N to navigate to the next submission
        ElseIf keyData = (Keys.Control Or Keys.N) Then
            btnNext.PerformClick()
            Return True
        End If
        ' Call the base class implementation for other keys
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

End Class
