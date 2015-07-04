Public Class Form6
    Public posx As Integer = Screen.PrimaryScreen.WorkingArea.Width - 72
    Public posy As Integer = (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) / 2
    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Width = 75
        Me.Location = New Point(posx, posy)
        Me.Visible = True
        ascundere()
    End Sub
    Private Sub afisare()
        Do Until posx = Screen.PrimaryScreen.WorkingArea.Width - 72
            posx = posx - 1
            Me.Width = Me.Width + 1
            Me.Location = New Point(posx, posy)
            Me.Refresh()
        Loop
    End Sub
    Private Sub ascundere()
        Do Until posx = Screen.PrimaryScreen.WorkingArea.Width - 15
            posx = posx + 1
            Me.Width = Me.Width - 1
            Me.Location = New Point(posx, posy)
            Me.Refresh()
        Loop
    End Sub
    Private Sub Panel1_MouseHover1(sender As Object, e As EventArgs) Handles Panel1.MouseHover
        afisare()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        ascundere()
    End Sub

    Private Sub Panel1_MouseLeave(sender As Object, e As EventArgs) Handles Panel1.MouseLeave
        ascundere()
    End Sub

    Private Sub PictureBox1_MouseHover(sender As Object, e As EventArgs) Handles PictureBox1.MouseHover

        afisare()
    End Sub
End Class