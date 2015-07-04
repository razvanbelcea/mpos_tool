Imports System.Drawing.Image
Imports System.Drawing
Imports System.Drawing.Bitmap
Imports System.Xml
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Diagnostics
Imports System.Text
Imports System.Windows.Forms
Imports System.Windows.Forms.FileDialog
Imports Microsoft.Office.Tools.Word
Public Class Form8
    Private tempd As String = "temp"
    Public srows As Double = 0
    Public Shared sfl As String = "sqllist.xml"
    Private con As SqlConnection
    Private cmd As SqlCommand
    Private dat As SqlDataReader

    Private Property PictureContentControl As Object

    Private Sub Form8_Leave(sender As Object, e As EventArgs) Handles Me.Leave
        DataGridView1.Dispose()
        Me.Dispose()
    End Sub
    Private Sub Form8_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button2.Visible = False
        Me.Width = 369
        readlist()
        settemp()
    End Sub
    Private Sub cuslist_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cuslist.SelectedIndexChanged
        For Each item In cuslist.Items
            checking(item)
        Next
    End Sub

    Private Sub artlist_SelectedIndexChanged(sender As Object, e As EventArgs) Handles artlist.SelectedIndexChanged
        For Each item In artlist.Items
            checking(item)
        Next
    End Sub
    Private Sub checking(item)
        If item.selected = True AndAlso item.checked = False Then
            item.checked = True
        ElseIf item.selected = True AndAlso item.checked = True Then
            item.checked = False
        End If
    End Sub
    Private Sub readlist()
        Dim readsql As XmlTextReader = New XmlTextReader(sfl)
        Dim i As Integer = 0
        Dim j As Integer = 0
        Try
            artlist.Items.Clear()
            cuslist.Items.Clear()
            Do While (readsql.Read())
                Select Case readsql.NodeType
                    Case XmlNodeType.Element
                        Select Case readsql.Name
                            Case "Art"
                                readsql.Read()
                                readsql.Read()
                                readsql.Read()
                                artlist.Items.Add(readsql.Value)
                                readsql.Read()
                                readsql.Read()
                                readsql.Read()
                                readsql.Read()
                                artlist.Items(i).SubItems.Add(readsql.Value)
                                artlist.Items(i).ToolTipText = readsql.Value
                                i = i + 1
                            Case "Cus"
                                readsql.Read()
                                readsql.Read()
                                readsql.Read()
                                cuslist.Items.Add(readsql.Value)
                                readsql.Read()
                                readsql.Read()
                                readsql.Read()
                                readsql.Read()
                                cuslist.Items(j).SubItems.Add(readsql.Value)
                                cuslist.Items(j).ToolTipText = readsql.Value
                                j = j + 1
                        End Select
                End Select
            Loop
            readsql.Dispose()
        Catch ed As Exception
            MsgBox(ed.Message)
        End Try
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Width = 1040
        Button2.Visible = False
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Width = 1040
        Button2.Visible = False
        DataGridView1.Rows.Clear()
        Dim row As String() = New String() {False, "-", "-", "-", "-", "-"}
        If Form1.Label11.Text = "ONLINE" Then
            Try
                con = New SqlConnection("Data Source=" & Form1.Label9.Text & ";Database=TPCentralDB;" & Form1.cred & ";")
                cmd = con.CreateCommand
                con.Open()
                For Each item In artlist.Items
                    If item.checked = True Then
                        cmd.CommandText = item.subitems(1).text
                        dat = cmd.ExecuteReader()
                        If dat.HasRows Then
                            While dat.Read()
                                row(1) = dat(0)
                                row(2) = dat(1)
                                row(3) = item.subitems(0).text
                                row(4) = Form1.Label7.Text
                                row(5) = Form1.Label10.Text
                                DataGridView1.Rows.Add(row)
                            End While
                            dat.Close()
                        Else
                            item.checked = False
                        End If
                    End If
                Next
                cmd.Dispose()
                con.Dispose()
            Catch af As Exception
                Form7.balon(af.Message)
            End Try
        Else
            Form7.balon("Server is offline ...")
        End If
    End Sub
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim pic As System.IO.FileStream
        Try
            If e.RowIndex >= 0 Then
                If setbar(DataGridView1.Item(2, e.RowIndex).Value) Then
                    pic = New System.IO.FileStream(tempd & "\" & DataGridView1.Item(2, e.RowIndex).Value & ".png", IO.FileMode.Open, IO.FileAccess.Read)
                    DataGridView1.Item(6, e.RowIndex).Value = Image.FromStream(pic)
                    Dim gr As Graphics = Graphics.FromImage(DataGridView1.Item(6, e.RowIndex).Value)
                    gr.DrawString("Article : " & DataGridView1.Item(1, e.RowIndex).Value, New Font("Arial", 12), New SolidBrush(Color.Black), 10, 5)
                    gr.DrawString(DataGridView1.Item(2, e.RowIndex).Value, New Font("Arial", 12), New SolidBrush(Color.Black), 10, 18)
                    gr.DrawString(DataGridView1.Item(3, e.RowIndex).Value, New Font("Arial", 12), New SolidBrush(Color.Black), 10, 31)
                    gr.DrawString(DataGridView1.Item(4, e.RowIndex).Value, New Font("Arial", 12, FontStyle.Bold), New SolidBrush(Color.Black), 10, 44)
                    gr.DrawString(DataGridView1.Item(5, e.RowIndex).Value, New Font("Arial", 12, FontStyle.Bold), New SolidBrush(Color.Black), 50, 44)
                    gr.Dispose()
                    pic.Close()
                    DataGridView1.Item(6, e.RowIndex).Value.save(tempd & "\" & DataGridView1.Item(2, e.RowIndex).Value & ".png")
                    If DataGridView1.Item(0, e.RowIndex).Value Then
                        DataGridView1.Item(0, e.RowIndex).Value = 0
                        DataGridView1.Item(6, e.RowIndex).Value = Nothing
                        srows = srows - 1
                    Else
                        DataGridView1.Item(0, e.RowIndex).Value = 1
                        srows = srows + 1
                    End If
                End If
            End If
        Catch ev As Exception
            Form7.balon(ev.Message)
        End Try
        If DataGridView1.Rows.Count > 0 AndAlso srows > 0 Then
            Button2.Visible = True
        Else
            Button2.Visible = False
        End If
    End Sub
    Private Sub settemp()
        If My.Computer.FileSystem.DirectoryExists(tempd) Then
            My.Computer.FileSystem.DeleteDirectory(tempd, FileIO.DeleteDirectoryOption.DeleteAllContents)
        End If
        My.Computer.FileSystem.CreateDirectory(tempd)
    End Sub
    Private Function setbar(barcode)
        Try
            Dim path As String = "http://www.keepautomation.com/online_barcode_generator/linear.aspx?TYPE=15&DATA=" & Microsoft.VisualBasic.Left(barcode, 12) & "&SUP-DATA=&SUP-HEIGHT=0&UOM=0&X=2&Y=50&ROTATE=0&RESOLUTION=72&FORMAT=png&LEFT-MARGIN=120&RIGHT-MARGIN=0&SHOW-TEXT=true&TEXT-FONT=Arial%7c9%7cRegular"
            Dim pic As String = tempd & "\" & barcode & ".png"
            If Not My.Computer.FileSystem.FileExists(pic) Then
                My.Computer.Network.DownloadFile(path, pic)
            End If
            Return 1
        Catch ev As Exception
            Form7.balon(ev.Message)
            Return 0
        End Try
    End Function

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

    End Sub
    ' Print all barcodes from \temp folder - one printout for each.
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        For Each filePath In IO.Directory.GetFiles("temp")
            Try
                Dim psi As New ProcessStartInfo(filePath)

                If psi.Verbs.Contains("printto") Then
                    psi.Verb = "printto"
                    psi.UseShellExecute = True
                    psi.WindowStyle = ProcessWindowStyle.Hidden
                    psi.Arguments = ("\\buk30app005.ro.madm.net\kmprinter")
                    psi.CreateNoWindow = True

                    Process.Start(psi).WaitForExit()

                    IO.File.Delete(filePath)
                Else
                    MessageBox.Show("No 'print' verb associated with file extension " & IO.Path.GetExtension(filePath))
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
            End Try
        Next
    End Sub

End Class