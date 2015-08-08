Imports System.Xml
Public Class Form9
    Private Sub Form9_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Form1.TopMost = True Then
            CheckBox1.Checked = True
        Else
            CheckBox1.Checked = False
        End If
        If Form1.cred = Form1.cred1 Then
            CheckBox2.Checked = True
        Else
            CheckBox2.Checked = False
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            Form1.TopMost = True
        Else
            Form1.TopMost = False
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            Form1.cred = Form1.cred1
        Else
            Form1.cred = Form1.cred2
        End If
    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Dispose()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim result As Integer = MessageBox.Show("Updating will close current session. Are you sure you want to continue ?", "MPOS Tool Updater", MessageBoxButtons.YesNo)
        If result = DialogResult.No Then
        ElseIf result = DialogResult.Yes Then
            Dim request As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create("http://sunt.pro/update/Update.txt")
            Dim response As System.Net.HttpWebResponse = request.GetResponse()
            Dim sr As System.IO.StreamReader = New System.IO.StreamReader(response.GetResponseStream())
            Dim newestversion As String = sr.ReadToEnd()
            Dim currentversion As String = Application.ProductVersion
            Try
                My.Computer.Network.DownloadFile("http://sunt.pro/update/MPOS Server Tool v1.0.exe", Application.StartupPath + "/MPOS Server Tool V" & newestversion + ".exe")
                If My.Computer.FileSystem.FileExists(Application.StartupPath + "/MPOS Server Tool V" & newestversion + ".exe") Then
                    Form1.x = True
                    Form1.Close()
                    System.Threading.Thread.Sleep(1000)
                    Process.Start(Application.StartupPath + "/MPOS Server Tool V" & newestversion + ".exe")
                End If
            Catch ex As Exception
                MsgBox(ex.Message + " Error Downloading update.")
            End Try
        End If
    End Sub
    Private Sub Form1Paint(ByVal sender As Object, _
ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        e.Graphics.DrawLine(Pens.Gray, 0, 120, Me.Width, 120)
    End Sub
End Class