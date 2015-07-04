Public Class Form2

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.AutoScroll = True

        Dim temp As Label() = New LinkLabel(5) {}
        Dim CNT As Integer = 0
        Dim X As Integer = 30
        Dim Y As Integer = 300

        While CNT < 5

            temp(CNT) = New LinkLabel
            temp(CNT).Location = New System.Drawing.Point(X, Y)
            temp(CNT).Size = New System.Drawing.Size(150, 20)
            temp(CNT).TextAlign = ContentAlignment.MiddleCenter
            temp(CNT).ForeColor = System.Drawing.Color.Black
            temp(CNT).BackColor = System.Drawing.Color.LightSalmon
            temp(CNT).Text = "DYNAMIC LABEL NO" & CNT + 1

            Me.Controls.Add(temp(CNT))
            CNT += 1
            Y = Y + 60

        End While
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

       
    End Sub
End Class