Imports System.Xml
Imports System.IO
Imports System
Imports System.Collections
Imports System.Collections.Specialized
Imports System.ComponentModel

Public Class xmlTools1
    Public Shared safeFileName As String
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = False
        ComboBox1.Enabled = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim fd As OpenFileDialog = New OpenFileDialog()

        fd.Title = "Open File Dialog"
        fd.InitialDirectory = "C:\"
        fd.Filter = "XML Files (*.xml)|*.xml"
        fd.FilterIndex = 2
        fd.RestoreDirectory = True

        If fd.ShowDialog() = DialogResult.OK Then
            TextBox1.Text = fd.FileName
            safeFileName = fd.SafeFileName
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If My.Computer.FileSystem.DirectoryExists(TextBox2.Text) Then
            If (ComboBox1.SelectedIndex > -1) Then
                BackgroundWorker3.RunWorkerAsync()
            Else
                MsgBox("Please select XML tag!", MsgBoxStyle.Critical)
            End If
        Else
            MsgBox("Please input valid directory path.", MsgBoxStyle.Critical)
        End If
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ComboBox1.Items.Clear()
        Dim path As String
        path = TextBox1.Text
        If My.Computer.FileSystem.FileExists(path) Then
            BackgroundWorker1.RunWorkerAsync()
        Else
            MsgBox("Please select XML file.", MsgBoxStyle.Critical)
        End If
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim fd1 As FolderBrowserDialog = New FolderBrowserDialog()

        fd1.RootFolder = Environment.SpecialFolder.Desktop
        fd1.SelectedPath = "C:\"
        fd1.Description = "Select Folder"

        If fd1.ShowDialog() = DialogResult.OK Then
            TextBox2.Text = fd1.SelectedPath
        End If
    End Sub
    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Button1.Enabled = False
        Button2.Enabled = False
        Button3.Enabled = False
        Button4.Enabled = False
        Button5.Enabled = False
        If InvokeRequired Then
            ProgressBar1.Invoke(Sub() ProgressBar1.Visible = True)
            ProgressBar1.Invoke(Sub() Label4.Visible = True)
        Else
            ProgressBar1.Visible = True
            Label4.Visible = False
        End If

        Try
            Dim xml_doc As New XmlDocument
            Dim xmlReader As New XmlTextReader(TextBox1.Text)
            xmlReader.MoveToContent()
            xmlReader.ReadToFollowing("Request")
            ' Collect the names in a List
            Dim elementNames As New List(Of String)()
            While xmlReader.Read()
                Select Case xmlReader.NodeType
                    Case XmlNodeType.Element
                        elementNames.Add(xmlReader.Name)
                        Exit Select
                End Select
            End While
            ' Add distinct values to the ComboBox
            ComboBox1.Invoke(Sub() ComboBox1.Items.AddRange(elementNames.Distinct().ToArray()))
            TextBox5.AppendText("XML tag list: update complete." & Environment.NewLine)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(ByVal sender As Object, ByVal e As ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        Me.ProgressBar1.Value = e.ProgressPercentage
        ProgressBar1.Increment(e.ProgressPercentage)
        If ProgressBar1.Value = ProgressBar1.Maximum Then

        End If
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Button1.Enabled = True
        Button2.Enabled = True
        Button3.Enabled = True
        Button4.Enabled = True
        Button5.Enabled = True
        ComboBox1.Enabled = True
        If InvokeRequired Then
            ProgressBar1.Invoke(Sub() ProgressBar1.Visible = False)
            ProgressBar1.Invoke(Sub() Label4.Visible = False)
        Else
            ProgressBar1.Visible = False
            Label4.Visible = False
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Try
            If My.Computer.FileSystem.DirectoryExists(TextBox2.Text) Then
                If (ComboBox1.SelectedIndex > -1) Then
                    BackgroundWorker2.RunWorkerAsync()
                Else
                    MsgBox("Please select XML tag!", MsgBoxStyle.Critical)
                End If
            Else
                MsgBox("Please input valid directory path.", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub BackgroundWorker2_DoWork(ByVal sender As System.Object, ByVal e As DoWorkEventArgs) Handles BackgroundWorker2.DoWork
        Button1.Enabled = False
        Button2.Enabled = False
        Button3.Enabled = False
        Button4.Enabled = False
        Button5.Enabled = False
        If InvokeRequired Then
            ProgressBar1.Invoke(Sub() ProgressBar1.Visible = True)
            ProgressBar1.Invoke(Sub() Label4.Visible = True)
        Else
            ProgressBar1.Visible = True
            Label4.Visible = False
        End If
        Try
            Dim savePath As String
            savePath = TextBox2.Text + "\" + safeFileName
            Dim myXmlDocument As XmlDocument = New XmlDocument()
            myXmlDocument.Load(TextBox1.Text)

            Dim node As XmlNodeList
            node = myXmlDocument.SelectNodes("ChangeRequests/Requests/Request/" + ComboBox1.SelectedItem.ToString)
            Dim n As Integer
            For Each i As XmlNode In node
                If i.InnerText = TextBox3.Text Then
                    'set new value
                    i.InnerText = TextBox4.Text
                End If
                n = n + 1
            Next

            myXmlDocument.Save(savePath)
            'MsgBox(n.ToString + " records updated!", MsgBoxStyle.Information)
            TextBox5.AppendText(n.ToString + " records updated!" & Environment.NewLine)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub BackgroundWorker2_ProgressChanged(ByVal sender As Object, ByVal e As ProgressChangedEventArgs) Handles BackgroundWorker2.ProgressChanged
        Me.ProgressBar1.Value = e.ProgressPercentage
    End Sub

    Private Sub BackgroundWorker2_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles BackgroundWorker2.RunWorkerCompleted
        Button1.Enabled = True
        Button2.Enabled = True
        Button3.Enabled = True
        Button4.Enabled = True
        Button5.Enabled = True
        If InvokeRequired Then
            ProgressBar1.Invoke(Sub() ProgressBar1.Visible = False)
            ProgressBar1.Invoke(Sub() Label4.Visible = False)
        Else
            ProgressBar1.Visible = False
            Label4.Visible = False
        End If
    End Sub

    Private Sub BackgroundWorker3_DoWork(ByVal sender As System.Object, ByVal e As DoWorkEventArgs) Handles BackgroundWorker3.DoWork
        Button1.Enabled = False
        Button2.Enabled = False
        Button3.Enabled = False
        Button4.Enabled = False
        Button5.Enabled = False
        If InvokeRequired Then
            ProgressBar1.Invoke(Sub() ProgressBar1.Visible = True)
            ProgressBar1.Invoke(Sub() Label4.Visible = True)
        Else
            ProgressBar1.Visible = True
            Label4.Visible = False
        End If
        Try
            Dim savePath As String
            savePath = TextBox2.Text + "\" + safeFileName
            Dim xdoc = XDocument.Load(TextBox1.Text)
            Dim result = xdoc.Descendants("Request") _
    .GroupBy(Function(s) CStr(s.Element(ComboBox1.SelectedItem.ToString))) _
    .SelectMany(Function(g) g.Skip(1)) _
    .Count()
            If result > 0 Then
                Dim question As Integer = MessageBox.Show("Are you sure you want to delete " + result.ToString + " records?", "Delete duplicate data", MessageBoxButtons.YesNo)
                If question = DialogResult.Yes Then
                    xdoc.Descendants("Request") _
                .GroupBy(Function(s) CStr(s.Element(ComboBox1.SelectedItem.ToString))) _
                .SelectMany(Function(g) g.Skip(1)) _
                .Remove()
                    xdoc.Save(savePath)
                    'MsgBox("Duplicate data removed!", MsgBoxStyle.Information)
                    TextBox5.AppendText(result.ToString + " duplicate values removed!" & Environment.NewLine)
                End If
            Else
                'MsgBox("No duplicate data found!", MsgBoxStyle.Information)
                TextBox5.AppendText("No duplicate data found!" & Environment.NewLine)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub BackgroundWorker3_ProgressChanged(ByVal sender As Object, ByVal e As ProgressChangedEventArgs) Handles BackgroundWorker3.ProgressChanged
        Me.ProgressBar1.Value = e.ProgressPercentage
    End Sub

    Private Sub BackgroundWorker3_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles BackgroundWorker3.RunWorkerCompleted
        Button1.Enabled = True
        Button2.Enabled = True
        Button3.Enabled = True
        Button4.Enabled = True
        Button5.Enabled = True
        If InvokeRequired Then
            ProgressBar1.Invoke(Sub() ProgressBar1.Visible = False)
            ProgressBar1.Invoke(Sub() Label4.Visible = False)
        Else
            ProgressBar1.Visible = False
            Label4.Visible = False
        End If
    End Sub

End Class
