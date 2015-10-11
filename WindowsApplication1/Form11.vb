Imports System.Data.SqlClient
Public Class Form11
    Private dat1 As SqlDataReader
    Public itemlook As New ArrayList
    Public tempda As String = "temp\ART"
    Public tempdc As String = "temp\CUS"
    Public tempdh As String = "temp\CHN"

    Private Sub Form8_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadcombo()
        LinkLabel1.Hide()
        Label13.Hide()
        UpdateControls(Me, "TextBox", "Text", "", True)
        PictureBox1.Image = Nothing
        Button4.Enabled = False
        Button5.Enabled = False
        Label14.Hide()
    End Sub

    Private Sub TextBox13_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox13.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
            MessageBox.Show("Please enter numbers only")
            e.Handled = True
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        itemlook.Clear()
        PictureBox1.Refresh()
        LinkLabel1.Text = ""
        Dim pic As System.IO.FileStream
        If TextBox13.Text.Length <= 6 Then
            'select din baza lookupcode
            Dim con1 As SqlConnection
            Dim cmd1 As SqlCommand
            Try
                con1 = New SqlConnection("Data Source=" & Form1.label9.Text & ";Database=TPCentralDB;" & Form1.cred & ";")
                cmd1 = con1.CreateCommand
                con1.Open()
                cmd1.CommandText = "select top 1 szitemlookupcode from ItemLookupCode where szpositemid =" & "'" & TextBox13.Text & "'"
                dat1 = cmd1.ExecuteReader()
                While dat1.Read()
                    If Not IsDBNull(dat1(0)) Then
                        itemlook.Add(dat1(0))
                    Else
                        MsgBox("Article not found!")
                    End If
                End While
                dat1.Close()
                con1.Close()
                If Form8.setbarart(itemlook(0).ToString) Then
                    pic = New System.IO.FileStream(tempda & "\" & itemlook(0).ToString & ".png", System.IO.FileMode.Open, System.IO.FileAccess.Read)
                    PictureBox1.Image = System.Drawing.Image.FromStream(pic)
                    PictureBox1.SizeMode = PictureBoxSizeMode.CenterImage
                    LinkLabel1.Text = itemlook(0).ToString
                    Label14.Show()
                    LinkLabel1.Show()
                    Label13.Show()
                    pic.Dispose()
                    pic.Close()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            'create barcode
            If Form8.setbarart(TextBox13.Text) Then
                pic = New System.IO.FileStream(tempda & "\" & TextBox13.Text & ".png", System.IO.FileMode.Open, System.IO.FileAccess.Read)
                PictureBox1.Image = System.Drawing.Image.FromStream(pic)
                PictureBox1.SizeMode = PictureBoxSizeMode.CenterImage
                Label14.Show()
                LinkLabel1.Hide()
                Label13.Hide()
                pic.Dispose()
                pic.Close()
            End If

        End If

    End Sub
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        If PictureBox1.Image Is Nothing Then

        Else
            My.Computer.Clipboard.SetImage(PictureBox1.Image)
        End If
    End Sub

    Private Sub TextBox13_TextChanged(sender As Object, e As EventArgs) Handles TextBox13.TextChanged
        If TextBox13.Text.Length < 1 Then
            Button5.Enabled = False
        ElseIf TextBox13.Text.Length >= 1 Then
            Button5.Enabled = True
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        My.Computer.Clipboard.SetText(itemlook(0).ToString)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim pic As System.IO.FileStream
        Dim a1, a2, a3, a4, a5, a6, a7, a8 As String
        Dim cd1 As String() = New String() {1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2}
        Dim cd2 As String() = New String() {4, 3, 2, 7, 6, 5, 4, 3, 2, 7, 6, 5, 4, 3, 2, 7, 6, 5, 4, 3, 2}
        Dim s1, s2 As Integer


        a1 = ComboBox2.SelectedValue.ToString
        a2 = TextBox11.Text.ToString.PadLeft(2, "0")
        a3 = TextBox12.Text.ToString.PadLeft(3, "0")
        a4 = TextBox10.Text.ToString.PadLeft(8, "0")
        a5 = TextBox9.Text.ToString.PadLeft(2, "0")
        a6 = TextBox8.Text.ToString.PadLeft(1, "0")
        a8 = 0

        a7 = a1 + a2 + a3 + a4 + a5 + a6 + a8

        s1 = 0
        s2 = 0
        For xx = 0 To 21
            If xx <= 19 Then
                If cd1(xx) * Mid(a7, xx + 1, 1) <= 9 Then
                    s1 = s1 + cd1(xx) * Mid(a7, xx + 1, 1)
                Else
                    s1 = s1 + Microsoft.VisualBasic.Left(cd1(xx) * Mid(a7, xx + 1, 1), 1) + Microsoft.VisualBasic.Right(cd1(xx) * Mid(a7, xx + 1, 1), 1)
                End If
                s2 = s2 + cd2(xx) * Mid(a7, xx + 1, 1)
            ElseIf xx = 20 Then
                If 10 - (s1 Mod 10) <= 9 Then
                    s1 = 10 - (s1 Mod 10)
                Else
                    s1 = 0
                End If
                s2 = s2 + cd2(xx) * s1
                If 11 - (s2 Mod 11) <= 9 Then
                    s2 = 11 - (s2 Mod 11)
                Else
                    s2 = 0
                End If
            End If
        Next

        TextBox7.Text = a7.ToString() + s1.ToString() + s2.ToString()
        If Form8.setbarcus(TextBox7.Text) Then
            pic = New System.IO.FileStream(tempdc & "\" & TextBox7.Text & ".png", System.IO.FileMode.Open, System.IO.FileAccess.Read)
            PictureBox1.Image = System.Drawing.Image.FromStream(pic)
            PictureBox1.SizeMode = PictureBoxSizeMode.CenterImage
            Label14.Show()
            LinkLabel1.Hide()
            Label13.Hide()
            pic.Dispose()
            pic.Close()
        End If
    End Sub

    Private Sub TextBox11_TextChanged(sender As Object, e As EventArgs) Handles TextBox8.TextChanged, TextBox9.TextAlignChanged, TextBox10.TextChanged, TextBox11.TextChanged, TextBox12.TextChanged
        If TextBox8.Text.Length < 1 And TextBox9.Text.Length < 1 And TextBox10.Text.Length < 1 And TextBox11.Text.Length < 1 And TextBox12.Text.Length < 1 Then
            Button4.Enabled = False
        Else
            Button4.Enabled = True
        End If
    End Sub

    Private Sub UpdateControls(Parent As Object, ControlType As String, ControlProperty As String, Value As Object, Optional Recursive As Boolean = False)
        ' abort if no control colletion found
        If Parent.GetType().GetProperty("Controls") Is Nothing Then Exit Sub

        ' loop through parent control collection and update
        For Each c As Control In Parent.Controls
            If c.GetType().Name = ControlType Then
                If c.GetType().GetProperty(ControlProperty) IsNot Nothing Then
                    c.GetType().GetProperty(ControlProperty).SetValue(c, Value, Nothing)
                End If
            End If
        Next

        'check for child controls in parent object
        If Recursive = True Then
            For Each cc As Control In Parent.Controls
                If cc.GetType().GetProperty("Controls") IsNot Nothing Then
                    UpdateControls(cc, ControlType, ControlProperty, Value, True)
                End If
            Next
        End If

    End Sub
    Public Sub loadcombo()
        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()
        Dim i As Integer = 0
        Dim sql As String = Nothing
        connetionString = "Data Source=" & "10.23.90.11" & ";Database=TPCentralDB;" & Form1.cred & ";"
        sql = "select szCountryCode,szNumericCountryCode from MGICountryCode where szCountryCode in ('BGR','CHN','DEU','ESP','FRA','GRC','HRV','HUN','IND','ITA','JPN','KAZ','MLD','NLD','POL','PRT','ROU','RUS','SRB','SVK','TUR','UKR','VNM')"
        connection = New SqlConnection(connetionString)
        Try
            connection.Open()
            command = New SqlCommand(sql, connection)
            adapter.SelectCommand = command
            adapter.Fill(ds)
            adapter.Dispose()
            command.Dispose()
            connection.Close()
            ComboBox2.DataSource = ds.Tables(0)
            ComboBox2.ValueMember = "szNumericCountryCode"
            ComboBox2.DisplayMember = "szCountryCode"
        Catch ex As Exception
            MessageBox.Show("Can not open connection ! ")
        End Try
    End Sub
End Class