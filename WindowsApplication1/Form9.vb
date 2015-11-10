Imports System.Xml
Imports System
Imports System.IO


Public Class Form9
    Public Shared servicedisabled As Boolean = False
    Private Sub Form9_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ToolTip1.SetToolTip(CheckBox6, "Leave this unchecked to improve the till loading time!")
        Button2.Enabled = False
        CheckSettings()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            Form1.TopMost = True
            Button2.Enabled = True
        Else
            Form1.TopMost = False
            Button2.Enabled = True
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            Form1.cred = Form1.cred1
            Button2.Enabled = True
        Else
            Form1.cred = Form1.cred2
            Button2.Enabled = True
        End If
    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Dispose()
    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
        If CheckBox3.Checked = True Then
            ServiceModuleDisable()
            Button2.Enabled = True
        ElseIf CheckBox3.Checked = False Then
            ServiceModuleEnable()
            Button2.Enabled = True
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If My.Computer.FileSystem.FileExists("config.ini") Then
            ConfigIniUpdate()
            Me.Close()
        Else
            ConfigIniCreate()
            Me.Close()
        End If
    End Sub
    Public Sub ServiceModuleDisable()
            Form1.servicelist.Hide()
            Form1.Button5.Hide()
            Form1.tills.Height = 392
            Form1.status.Height = 110
            Form1.tills.Location = New Point(493, 130)
            Form1.tilllist.Height = 350
            Form1.tilllist.Location = New Point(7, 25)
            Form1.tlb.Location = New Point(356, 340)
            Form1.tpb.Location = New Point(184, 360)
            servicedisabled = True
    End Sub
    Public Sub ServiceModuleEnable()
        Form1.servicelist.Show()
        Form1.Button5.Show()
        Form1.tills.Height = 209
        Form1.status.Height = 294
        Form1.tills.Location = New Point(493, 312)
        Form1.tilllist.Height = 179
        Form1.tilllist.Location = New Point(7, 21)
        Form1.tlb.Location = New Point(356, 169)
        Form1.tpb.Location = New Point(184, 185)
        servicedisabled = False
    End Sub
    Public Sub ConfigIniCreate()
        Dim config As New IniFile
        If CheckBox1.Checked = True Then
            config.AddSection("Settings").AddKey("AlwaysOnTop").Value = "1"
        ElseIf CheckBox1.Checked = False Then
            config.AddSection("Settings").AddKey("AlwaysOnTop").Value = "0"
        End If
        If CheckBox2.Checked = True Then
            config.AddSection("Settings").AddKey("SSPI").Value = "1"
        ElseIf CheckBox2.Checked = False Then
            config.AddSection("Settings").AddKey("SSPI").Value = "0"
        End If
        If CheckBox3.Checked = True Then
            config.AddSection("Settings").AddKey("ServiceModule").Value = "1"
        ElseIf CheckBox3.Checked = False Then
            config.AddSection("Settings").AddKey("ServiceModule").Value = "0"
        End If
        If CheckBox5.Checked = True Then
            config.AddSection("Settings").AddKey("Startup").Value = "1"
        ElseIf CheckBox5.Checked = False Then
            config.AddSection("Settings").AddKey("Startup").Value = "0"
        End If
        If CheckBox6.Checked = True Then
            config.AddSection("Settings").AddKey("printeron").Value = "1"
        ElseIf CheckBox6.Checked = False Then
            config.AddSection("Settings").AddKey("printeron").Value = "0"
        End If
        config.Save("config.ini")
        Form7.balon("Settings saved!")
    End Sub
    Public Sub ConfigIniUpdate()
        Dim config As New IniFile
        config.Load("config.ini")

        If CheckBox1.Checked = True Then
            config.SetKeyValue("Settings", "AlwaysOnTop", "1")
        ElseIf CheckBox1.Checked = False Then
            config.SetKeyValue("Settings", "AlwaysOnTop", "0")
        End If
        If CheckBox2.Checked = True Then
            config.SetKeyValue("Settings", "SSPI", "1")
        ElseIf CheckBox2.Checked = False Then
            config.SetKeyValue("Settings", "SSPI", "0")
        End If
        If CheckBox3.Checked = True Then
            config.SetKeyValue("Settings", "ServiceModule", "1")
        ElseIf CheckBox3.Checked = False Then
            config.SetKeyValue("Settings", "ServiceModule", "0")
        End If
        If CheckBox5.Checked = True Then
            config.SetKeyValue("Settings", "Startup", "1")
        ElseIf CheckBox5.Checked = False Then
            config.SetKeyValue("Settings", "Startup", "0")
        End If
        If CheckBox6.Checked = True Then
            config.SetKeyValue("Settings", "printeron", "1")
        ElseIf CheckBox6.Checked = False Then
            config.SetKeyValue("Settings", "printeron", "0")
        End If
        config.Save("config.ini")
        Form7.balon("Settings saved!")
    End Sub
    Public Sub CheckSettings()
        Try
            If My.Computer.FileSystem.FileExists("config.ini") Then
                Dim config As New IniFile
                config.Load("config.ini")

                If config.GetKeyValue("Settings", "AlwaysOnTop") = "1" Then
                    CheckBox1.Checked = True
                Else
                    CheckBox1.Checked = False
                End If

                If config.GetKeyValue("Settings", "SSPI") = "1" Then
                    CheckBox2.Checked = True
                Else
                    CheckBox2.Checked = False
                End If

                If config.GetKeyValue("Settings", "ServiceModule") = "1" Then
                    CheckBox3.Checked = True
                Else
                    CheckBox3.Checked = False
                End If
                If config.GetKeyValue("Settings", "Startup") = "1" Then
                    CheckBox5.Checked = True
                Else
                    CheckBox5.Checked = False
                End If
                If config.GetKeyValue("Settings", "printeron") = "1" Then
                    CheckBox6.Checked = True
                Else
                    CheckBox6.Checked = False
                End If
            Else
                CheckBox2.Checked = True
                Form7.balon("Missing settings file!")
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CheckBox4_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub CheckBox5_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox5.CheckedChanged
        Dim Directory As String = CreateObject("WScript.Shell").SpecialFolders("Startup")
        If CheckBox5.Checked = True Then
            Form1.cleanshortc("startup")
            Button2.Enabled = True
        Else
            For Each filename As String In IO.Directory.GetFiles(Directory, "*", IO.SearchOption.AllDirectories)
                If Microsoft.VisualBasic.Right(filename, 4) = ".lnk" Then
                    If My.Computer.FileSystem.FileExists(filename) Then
                        My.Computer.FileSystem.DeleteFile(filename)
                    End If
                    Button2.Enabled = True
                End If
            Next
        End If
    End Sub

    Private Sub CheckBox6_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox6.CheckedChanged
        If CheckBox6.Checked = True Then
            Form1.printeron = True
            Button2.Enabled = True
        Else
            Form1.printeron = False
            Button2.Enabled = True
        End If
    End Sub
End Class