Imports System.Threading
Imports System.Threading.Tasks
Public Class Form5
    Dim cts As New CancellationTokenSource
    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Sub count(token As CancellationToken)

        Dim n As Integer = 50
        ProgressBar1.Maximum = n
        For x = 1 To n
            token.ThrowIfCancellationRequested()
            Label1.Text = x
            ProgressBar1.Value = x
            System.Threading.Thread.Sleep(200)

        Next
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        cts.Cancel()
        cts = New CancellationTokenSource
        Dim token = cts.Token
        Task.Factory.StartNew(Sub() count(token), token)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        cts.Cancel()
    End Sub

End Class