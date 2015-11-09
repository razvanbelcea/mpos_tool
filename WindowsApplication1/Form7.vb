Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Xml
Imports System.Net
Imports System.Management
Imports System.ServiceProcess
Imports System.ComponentModel
Imports System.Threading
Imports System.IO
Imports System.Threading.Thread
'Imports System.IO.Packaging
Imports System.IO.Compression
Imports MPOS.My.Resources
Public Class Form7
    Public quote As String = Chr(34)
    Public posx1 As Integer = Screen.PrimaryScreen.WorkingArea.Width - 30
    Public posy1 As Integer = Screen.PrimaryScreen.WorkingArea.Height - 160
    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        balon("MPOS Server Tool Application has been minimize ... ")
        Me.Width = 30
        Me.Location = New Point(posx1, posy1)
        Me.Visible = True
        ascundere()
    End Sub
    Private Sub afisare()
        Do Until posx1 <= Screen.PrimaryScreen.WorkingArea.Width - 335
            posx1 = posx1 - 1
            Me.Width = Me.Width + 1
            Me.Location = New Point(posx1, posy1)
        Loop
        Panel2.Show()
        Me.Refresh()
    End Sub
    Private Sub ascundere()
        Panel2.Hide()
        Do Until posx1 >= Screen.PrimaryScreen.WorkingArea.Width - 30
            posx1 = posx1 + 1
            Me.Width = Me.Width - 1
            Me.Location = New Point(posx1, posy1)
        Loop
        Me.Refresh()
    End Sub
    Private Sub Panel1_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel1.MouseClick
        If Me.Width <= 30 Then
            afisare()
        Else
            ascundere()
        End If
    End Sub
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        If Me.Width <= 30 Then
            afisare()
        Else
            ascundere()
        End If
    End Sub
    Private Sub Panel2_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel2.MouseClick
        If Me.Width <= 30 Then
            afisare()
        Else
            ascundere()
        End If
    End Sub
    Private Sub Label2_Click(sender As Object, e As EventArgs)
        If Me.Width <= 30 Then
            afisare()
        Else
            ascundere()
        End If
    End Sub
    Private Sub Panel3_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel3.MouseClick
        If Me.Width <= 30 Then
            afisare()
        Else
            ascundere()
        End If
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        ComboBox1.Tag = ""
        ComboBox2.Tag = ""
        ComboBox2.Items.Clear()
        ComboBox2.Text = Nothing
        Label2.Text = "OFF"
        Label2.BackColor = Color.Red
        Label2.Visible = False
        Label3.Text = "OFF"
        Label3.BackColor = Color.Red
        Label3.Visible = False
        Try
            ComboBox1.Tag = Microsoft.VisualBasic.Right(ComboBox1.Text, Microsoft.VisualBasic.Len(ComboBox1.Text) - ComboBox1.Text.IndexOf(" IP-") - 4)
            If My.Computer.Network.Ping(ComboBox1.Tag) Then
                Label2.Text = "ON"
                Label2.BackColor = Color.Green
                Label2.Visible = True
                loadtills()
                balon("Till list have been updated ... ")
            Else
                Label2.Text = "OFF"
                Label2.BackColor = Color.Red
                Label2.Visible = True
                balon("Server is Offline ... ")
            End If
        Catch ek As Exception
            MsgBox(ek.Message)
        End Try
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            Dim result As Integer = MessageBox.Show("Are you sure you want to reboot the till ?", "Reboot till", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then
                If Label3.Text = "ON" Then
                    Process.Start("cmd.exe", "/c shutdown -r -t 0 -m \\" & ComboBox2.Tag)
                    balon("Restart command has been sent for Till : " & i2())
                Else
                    balon("Restart command failed ... " & i2())
                End If
            End If
        Catch ed As Exception
            MsgBox(ed.Message & ComboBox2.Text)
        End Try
    End Sub
    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        ComboBox2.Tag = ""
        Label3.Text = "OFF"
        Label3.BackColor = Color.Red
        Label3.Visible = False
        Try
            ComboBox2.Tag = Microsoft.VisualBasic.Right(ComboBox2.Text, Microsoft.VisualBasic.Len(ComboBox2.Text) - ComboBox2.Text.IndexOf(" IP-") - 4)
            If My.Computer.Network.Ping(ComboBox2.Tag) Then
                Label3.Text = "ON"
                Label3.BackColor = Color.Green
                Label3.Visible = True
            Else
                Label3.Text = "OFF"
                Label3.BackColor = Color.Red
                Label3.Visible = True
            End If
        Catch ef As Exception
            MsgBox(ef.Message)
        End Try
    End Sub
    Private Sub loadtills()
        Dim con As New SqlConnection("Data Source=" & ComboBox1.Tag & ";Database=TPCentralDB;" & Form1.cred & ";")
        Dim cmd As New SqlCommand
        Dim dat As SqlDataReader
        Try
            If Label2.Text = "ON" Then
                cmd.Connection = con
                con.Open()
            End If
            If (con.State = ConnectionState.Open) Then
                cmd.CommandText = "select szWorkstationID,lWorkstationNmbr, szWorkstationGroupID from workstation where bisthickpos<>0"
                dat = cmd.ExecuteReader()
                While dat.Read()
                    Try
                        ComboBox2.Items.Add(dat(1) & " " & dat(0) & " " & dat(2) & " IP-" & System.Net.Dns.GetHostEntry(dat(0) & ".mpos.madm.net").AddressList(0).ToString())
                    Catch
                    End Try
                End While
                dat.Dispose()
                con.Dispose()
            End If
        Catch e As SqlException
            MsgBox(e.Message)
        End Try
    End Sub
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim loc = "\\" & ComboBox1.Tag & "\e$\Journal\Reports"
        Try
            If Label2.Text = "ON" And My.Computer.FileSystem.DirectoryExists(loc) Then
                Process.Start("explorer.exe", loc)
                balon("PDF invoice forder - Server : " & i1())
            Else
                balon("Server offline ... " & i1())
            End If
        Catch ey As Exception
            MsgBox(ey.Message)
        End Try
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim loc = "\\" & ComboBox1.Tag & "\e$\Journal\Transactions"
        Try
            If Label2.Text = "ON" And My.Computer.FileSystem.DirectoryExists(loc) Then
                Process.Start("explorer.exe", loc)
                balon("XML transaction folder - Server : " & i1())
            Else
                balon("Server offline ... " & i1())
            End If
        Catch ey As Exception
            MsgBox(ey.Message)
        End Try
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim loc = "\\" & ComboBox1.Tag & "\e$\TpDotnet\Server\HostData\Download"
        Try
            If Label2.Text = "ON" And My.Computer.FileSystem.DirectoryExists(loc) Then
                Process.Start("explorer.exe", loc)
                balon("MPOS Download folder - Server : " & i1())
            Else
                balon("Server offline ... " & i1())
            End If
        Catch ey As Exception
            MsgBox(ey.Message)
        End Try
    End Sub
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim loc = "\\" & ComboBox1.Tag & "\e$\TpDotnet\Log"
        Try
            If Label2.Text = "ON" And My.Computer.FileSystem.DirectoryExists(loc) Then
                Process.Start("explorer.exe", loc)
                balon("Log folder - Server : " & i1())
            Else
                balon("Server offline ... " & i1())
            End If
        Catch ey As Exception
            MsgBox(ey.Message)
        End Try
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim loc = "\\" & ComboBox1.Tag & "\e$\TpDotnet\Server\UpdatePackages"
        Try
            If Label2.Text = "ON" And My.Computer.FileSystem.DirectoryExists(loc) Then
                Process.Start("explorer.exe", loc)
                balon("Update packages UP-SI folder - Server : " & i1())
            Else
                balon("Server offline ... " & i1())
            End If
        Catch ey As Exception
            MsgBox(ey.Message)
        End Try
    End Sub
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim loc = "\\" & ComboBox1.Tag & "\e$\TpDotnet\OII"
        Try
            If Label2.Text = "ON" And My.Computer.FileSystem.DirectoryExists(loc) Then
                Process.Start("explorer.exe", loc)
                balon("OII folder - Server : " & i1())
            Else
                balon("Server offline ... " & i1())
            End If
        Catch ey As Exception
            MsgBox(ey.Message)
        End Try
    End Sub
    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        Form1.Dispose()
        Me.Dispose()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If Label3.Text = "ON" Then
                Process.Start("C:\Program Files\Microsoft Configuration Manager\AdminConsole\bin\i386\CmRcViewer.exe", ComboBox2.Tag)
                balon("Connected via SCCM Till : " & i2())
            Else
                balon("Till offline ... " & i2())
            End If
        Catch ey As Exception
            MsgBox(ey.Message)
        End Try
    End Sub
    Private Sub OpenOnTillToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenOnTillToolStripMenuItem.Click
        Dim loc = "\\" & ComboBox2.Tag & "\e$\TpDotnet\Pos\Reports\Normal"
        Try
            If Label3.Text = "ON" And My.Computer.FileSystem.DirectoryExists(loc) Then
                Process.Start("explorer.exe", loc)
                balon("PDF invoice forder - Till : " & i2())
            Else
                balon("Till offline ... " & i2())
            End If
        Catch ey As Exception
            MsgBox(ey.Message)
        End Try
    End Sub
    Public Sub balon(ss)
        Form1.NotifyIcon1.BalloonTipText = ss
        Form1.NotifyIcon1.ShowBalloonTip(60)
    End Sub
    Private Sub OpenOnTillToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles OpenOnTillToolStripMenuItem1.Click
        Dim loc = "\\" & ComboBox2.Tag & "\e$\TpDotnet\Pos\Transactions\Normal"
        Try
            If Label3.Text = "ON" And My.Computer.FileSystem.DirectoryExists(loc) Then
                Process.Start("explorer.exe", loc)
                balon("XML transaction folder - Till : " & i2())
            Else
                balon("Till offline ... " & i2())
            End If
        Catch ey As Exception
            MsgBox(ey.Message)
        End Try
    End Sub
    Private Sub OpenServerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenServerToolStripMenuItem.Click
        Try
            If Label2.Text = "ON" Then
                Process.Start("C:\Program Files\Microsoft Configuration Manager\AdminConsole\bin\i386\CmRcViewer.exe", ComboBox1.Tag)
                balon("Connected via SCCM Server : " & i1())
            Else
                balon("Server offline ... " & i1())
            End If
        Catch ey As Exception
            MsgBox(ey.Message)
        End Try
    End Sub
    Private Sub OpenOnTillToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles OpenOnTillToolStripMenuItem2.Click
        Dim loc = "\\" & ComboBox2.Tag & "\e$\TpDotnet\Log"
        Try
            If Label3.Text = "ON" And My.Computer.FileSystem.DirectoryExists(loc) Then
                Process.Start("explorer.exe", loc)
                balon("Log folder - Till : " & i2())
            Else
                balon("Till offline ... " & i2())
            End If
        Catch ey As Exception
            MsgBox(ey.Message)
        End Try
    End Sub
    Private Sub ContextMenuStrip4_Opening(sender As Object, e As CancelEventArgs) Handles ContextMenuStrip4.Opening
        ArhiveLogsToDesktopToolStripMenuItem.Visible = False
        BothToolStripMenuItem.Visible = False
        OnlyTillToolStripMenuItem.Visible = False
        OnlyServerToolStripMenuItem.Visible = False
        If Label2.Text = "ON" Then
            ArhiveLogsToDesktopToolStripMenuItem.Visible = True
            OnlyServerToolStripMenuItem.Visible = True
            If Label3.Text = "ON" Then
                BothToolStripMenuItem.Visible = True
                OnlyTillToolStripMenuItem.Visible = True
            End If
        End If
    End Sub
    Private Sub moveserverlog()
        Dim str = ComboBox1.Text.Replace(" ", "_").Replace("-", "_").Replace(".", "_")
        Dim tstamp = Format(Now, "yyyyMMdd_hhmmss")
        'Dim fname = "\\" & ComboBox1.Tag & "\e$\TpDotnet\Serverlog" & tstamp
        Dim fname = "\SERVER_" & tstamp & "_" & str
        Dim loc = "\\" & ComboBox1.Tag & "\e$\TpDotnet\Log"
        Try
            If FolderBrowserDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                If Label2.Text = "ON" Then
                    If My.Computer.FileSystem.DirectoryExists(loc) Then
                        'Process.Start("C:\Program Files\7-Zip\7z.exe", "a " & fname & " " & loc)
                        'My.Computer.FileSystem.MoveFile(fname, FolderBrowserDialog1.SelectedPath & tstamp)
                        Process.Start("C:\Program Files\7-Zip\7z.exe", "a " & quote & FolderBrowserDialog1.SelectedPath & fname & quote & " " & loc)
                        balon("Retrieving server logs ... " & i1())
                    Else
                        balon("Location not available ... " & i1())
                    End If
                Else
                    balon("Server is offline ... " & i1())
                End If
            Else
                balon("Operation aborted ... " & i1())
            End If
        Catch es As Exception
            MsgBox(es.Message)
        End Try
    End Sub
    Private Sub movetilllog()
        Dim str = ComboBox2.Text.Replace(" ", "_").Replace("-", "_").Replace(".", "_")
        Dim tstamp = Format(Now, "yyyyMMdd_hhmmss")
        Dim fname = "\TILL_" & tstamp & "_" & str
        Dim loc = "\\" & ComboBox2.Tag & "\e$\TpDotnet\Log"
        Try
            If FolderBrowserDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                If Label3.Text = "ON" Then
                    If My.Computer.FileSystem.DirectoryExists(loc) Then
                        Process.Start("C:\Program Files\7-Zip\7z.exe", "a " & quote & FolderBrowserDialog1.SelectedPath & fname & quote & " " & loc)
                        balon("Retrieving till logs ... " & i2())
                    Else
                        balon("Location not available ... " & i2())
                    End If
                Else
                    balon("Till is offline ... " & i2())
                End If
            Else
                balon("Operation aborted ... " & i2())
            End If
        Catch es As Exception
            MsgBox(es.Message)
        End Try
    End Sub
    Private Function i1()
        Return (vbCrLf & ComboBox1.Text)
    End Function
    Private Function i2()
        Return (vbCrLf & ComboBox2.Text)
    End Function
    Private Sub BothToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BothToolStripMenuItem.Click
        moveserverlog()
        movetilllog()
    End Sub
    Private Sub OnlyTillToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OnlyTillToolStripMenuItem.Click
        movetilllog()
    End Sub
    Private Sub OnlyServerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OnlyServerToolStripMenuItem.Click
        moveserverlog()
    End Sub

    Private Sub MaximizeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MaximizeToolStripMenuItem.Click
        Me.Hide()
        Form1.Show()
        If Form1.TopMost = False Then
            Form1.TopMost = True
            Form1.TopMost = False
        End If
    End Sub

    Private Sub PictureBox2_MouseClick(sender As Object, e As MouseEventArgs) Handles PictureBox2.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Left Then
            If Me.Width <= 30 Then
                afisare()
            Else
                ascundere()
            End If
        End If
    End Sub
End Class