Public Class about
    Private Sub About_Click(sender As Object, e As EventArgs) Handles Me.Click
        Me.Dispose()
    End Sub
    Private Sub About_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
    End Sub
    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Me.Dispose()
    End Sub
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Me.Dispose()
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        sk.Value = sk.Value + 1
        If sk.Text < 100 Then
            Me.Opacity = Me.Opacity + 0.01
        ElseIf sk.Value >= 100 And sk.Value < 200 Then
        ElseIf sk.Value >= 200 And sk.Value < 300 Then
            Me.Opacity = Me.Opacity - 0.01
        Else
            Me.Dispose()
        End If
    End Sub
End Class