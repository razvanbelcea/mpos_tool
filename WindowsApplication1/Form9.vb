Imports System.Xml
Imports System
Imports System.IO
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
End Class