Imports System.Drawing.Image
Imports System.Drawing
Imports System.Xml
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports Excel = Microsoft.Office.Interop.Excel
Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.IO

Public Class Form8
    Public tempda As String = "temp\ART"
    Public tempdc As String = "temp\CUS"
    Public tempdh As String = "temp\CHN"
    Public srowsa As Double = 0
    Public srowsc As Double = 0
    Public ssels As Double = 0
    Public Shared sfl As String = "sqllist.xml"
    Private con As SqlConnection
    Private cmd As SqlCommand
    Private dat As SqlDataReader
    Private dat1 As SqlDataReader
    Private con1 As SqlConnection
    Private Sub Form8_Leave(sender As Object, e As EventArgs) Handles Me.Leave
        Me.Dispose()
    End Sub
    Private Sub Form8_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridView1.Rows.Clear()
        DataGridView2.Rows.Clear()
        RadioButton4.Checked = True
        RadioButton9.Checked = True
        RadioButton2.Checked = True
        Button5.Enabled = False
        Button2.Enabled = False
        Button8.Enabled = False
        DateTimePicker1.Enabled = False
        DateTimePicker2.Enabled = False
        DateTimePicker1.Value = Today
        DateTimePicker2.Value = Today
        CODrefresh()
        txrefresh()

        tab.SelectedIndex = 0
        Panel1.Enabled = False
        If Form1.Label10.Text = "CHN" Then
            Panel1.Enabled = True
        End If
        readlist()
        settemp()
        chnrefresh()

    End Sub

    Private Sub cuslist_MouseClick(sender As Object, e As MouseEventArgs) Handles cuslist.MouseClick
        For Each item In cuslist.Items
            checking(item)
        Next
        cuslist.SelectedItems.Clear()
    End Sub
    Private Sub artlist_SelectedIndexChanged(sender As Object, e As EventArgs) Handles artlist.SelectedIndexChanged
        For Each item In artlist.Items
            checking(item)
        Next
        artlist.SelectedItems.Clear()
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
            While Not readsql.EOF
                readsql.Read()
                If readsql.NodeType = XmlNodeType.Element And readsql.Name = "Art" Then
                    readsql.Read()
                    artlist.Items.Add(readsql.ReadElementString("Name"))
                    artlist.Items(i).SubItems.Add(readsql.ReadElementString("Sql"))
                    i = i + 1
                ElseIf readsql.NodeType = XmlNodeType.Element And readsql.Name = "Cus" Then
                    readsql.Read()
                    cuslist.Items.Add(readsql.ReadElementString("Name"))
                    cuslist.Items(j).SubItems.Add(readsql.ReadElementString("Sql"))
                    j = j + 1
                End If
            End While
            readsql.Dispose()
        Catch ed As Exception
            MsgBox(ed.Message)
        End Try
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If My.Computer.FileSystem.DirectoryExists(tempda) Then
            My.Computer.FileSystem.DeleteDirectory(tempda, FileIO.DeleteDirectoryOption.DeleteAllContents)
        End If
        My.Computer.FileSystem.CreateDirectory(tempda)

        ssels = 0
        srowsa = 0
        Button2.Enabled = False
        DataGridView1.Rows.Clear()
        Dim row As String() = New String() {False, "-", "-", "-", "-", "-"}
        If Form1.Label11.Text = "ONLINE" Then
            Try
                con = New SqlConnection("Data Source=" & Form1.label9.Text & ";Database=TPCentralDB;" & Form1.cred & ";")
                cmd = con.CreateCommand
                con.Open()
                For Each item In artlist.Items
                    If item.checked = True Then
                        ssels = ssels + 1
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
                        Else
                            item.checked = False
                        End If
                        dat.Close()
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
        If ssels = 0 Then
            Form7.balon("No selection has been made ...")
        End If
    End Sub
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim pic As System.IO.FileStream
        Try
            If e.RowIndex >= 0 Then
                Dim barcode As String = DataGridView1.Item(2, e.RowIndex).Value
                If e.ColumnIndex = 2 Then
                    My.Computer.Clipboard.SetText(barcode)
                ElseIf e.ColumnIndex = 6 And My.Computer.FileSystem.FileExists(tempda & "\" & barcode & ".png") Then
                    pic = New System.IO.FileStream(tempda & "\" & barcode & ".png", System.IO.FileMode.Open, System.IO.FileAccess.Read)
                    My.Computer.Clipboard.SetImage(System.Drawing.Image.FromStream(pic))
                    pic.Close()
                Else
                    If setbarart(barcode) Then
                        pic = New System.IO.FileStream(tempda & "\" & barcode & ".png", System.IO.FileMode.Open, System.IO.FileAccess.Read)
                        DataGridView1.Item(6, e.RowIndex).Value = System.Drawing.Image.FromStream(pic)
                        Dim gr As Graphics = Graphics.FromImage(DataGridView1.Item(6, e.RowIndex).Value)
                        gr.DrawString("Article : " & DataGridView1.Item(1, e.RowIndex).Value, New System.Drawing.Font("Arial", 12), New SolidBrush(Color.Black), 10, 5)
                        gr.DrawString(DataGridView1.Item(2, e.RowIndex).Value, New System.Drawing.Font("Arial", 12), New SolidBrush(Color.Black), 10, 18)
                        gr.DrawString(DataGridView1.Item(3, e.RowIndex).Value, New System.Drawing.Font("Arial", 12), New SolidBrush(Color.Black), 10, 31)
                        gr.DrawString(DataGridView1.Item(4, e.RowIndex).Value, New System.Drawing.Font("Arial", 12, FontStyle.Bold), New SolidBrush(Color.Black), 10, 44)
                        gr.DrawString(DataGridView1.Item(5, e.RowIndex).Value, New System.Drawing.Font("Arial", 12, FontStyle.Bold), New SolidBrush(Color.Black), 50, 44)
                        gr.Dispose()
                        pic.Close()
                        DataGridView1.Item(6, e.RowIndex).Value.save(tempda & "\" & barcode & ".png")
                        If DataGridView1.Item(0, e.RowIndex).Value Then
                            DataGridView1.Item(0, e.RowIndex).Value = 0
                            DataGridView1.Item(6, e.RowIndex).Value = Nothing
                            If My.Computer.FileSystem.FileExists(tempda & "\" & barcode & ".png") Then
                                My.Computer.FileSystem.DeleteFile(tempda & "\" & barcode & ".png")
                            End If
                            srowsa = srowsa - 1
                        Else
                            DataGridView1.Item(0, e.RowIndex).Value = 1
                            srowsa = srowsa + 1
                        End If
                    End If
                End If
            End If
        Catch ev As Exception
            Form7.balon(ev.Message)
        End Try
        Button2.Enabled = False
        If DataGridView1.Rows.Count > 0 AndAlso srowsa > 0 Then
            Button2.Enabled = True
        End If
    End Sub
    Private Sub settemp()
        If My.Computer.FileSystem.DirectoryExists(tempda) Then
            My.Computer.FileSystem.DeleteDirectory(tempda, FileIO.DeleteDirectoryOption.DeleteAllContents)
        End If
        If My.Computer.FileSystem.DirectoryExists(tempdc) Then
            My.Computer.FileSystem.DeleteDirectory(tempdc, FileIO.DeleteDirectoryOption.DeleteAllContents)
        End If
        If My.Computer.FileSystem.DirectoryExists(tempdh) Then
            My.Computer.FileSystem.DeleteDirectory(tempdh, FileIO.DeleteDirectoryOption.DeleteAllContents)
        End If
        My.Computer.FileSystem.CreateDirectory(tempda)
        My.Computer.FileSystem.CreateDirectory(tempdc)
        My.Computer.FileSystem.CreateDirectory(tempdh)
    End Sub
    Private Function setbarart(barcode)
        Dim WbReq As New Net.WebClient
        WbReq.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials
        WbReq.Dispose()
        Try
            Dim path As String = "http://www.keepautomation.com/online_barcode_generator/linear.aspx?TYPE=15&DATA=" & Microsoft.VisualBasic.Left(barcode, 12) & "&SUP-DATA=&SUP-HEIGHT=0&UOM=0&X=2&Y=50&ROTATE=0&RESOLUTION=72&FORMAT=png&LEFT-MARGIN=120&RIGHT-MARGIN=0&SHOW-TEXT=true&TEXT-FONT=Arial%7c9%7cRegular"
            Dim pic As String = tempda & "\" & barcode & ".png"
            If Not My.Computer.FileSystem.FileExists(pic) Then
                My.Computer.Network.DownloadFile(path, pic)
            End If
            Return 1
        Catch ev As Exception
            Form7.balon(ev.Message)
            Return 0
        End Try
    End Function
    Private Function setbarcus(barcode)
        Dim WbReq As New Net.WebClient
        WbReq.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials
        WbReq.Dispose()
        Try
            Dim path As String = "http://www.keepautomation.com/online_barcode_generator/linear.aspx?TYPE=10&DATA=" & barcode & "&PROCESS-TILDE=false&UOM=0&X=1&Y=50&ROTATE=0&RESOLUTION=72&FORMAT=png&LEFT-MARGIN=150&RIGHT-MARGIN=0&SHOW-TEXT=true&TEXT-FONT=Arial%7c9%7cRegular"
            Dim pic As String = tempdc & "\" & barcode & ".png"
            If Not My.Computer.FileSystem.FileExists(pic) Then
                My.Computer.Network.DownloadFile(path, pic)
            End If
            Return 1
        Catch ev As Exception
            Form7.balon(ev.Message)
            Return 0
        End Try
    End Function
    Private Function setbarchn(barcode)
        Dim WbReq As New Net.WebClient
        WbReq.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials
        WbReq.Dispose()
        Try
            Dim path As String = "http://www.keepautomation.com/online_barcode_generator/linear.aspx?TYPE=4&DATA=" & barcode & "&UOM=0&X=1&Y=40&ROTATE=0&RESOLUTION=72&FORMAT=png&LEFT-MARGIN=0&RIGHT-MARGIN=0&SHOW-TEXT=true&TEXT-FONT=Arial%7c12%7cRegular"
            Dim pic As String = tempdh & "\" & barcode & ".png"
            If Not My.Computer.FileSystem.FileExists(pic) Then
                My.Computer.Network.DownloadFile(path, pic)
            End If
            Return 1
        Catch ev As Exception
            Form7.balon(ev.Message)
            Return 0
        End Try
    End Function

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If My.Computer.FileSystem.DirectoryExists(tempdc) Then
            My.Computer.FileSystem.DeleteDirectory(tempdc, FileIO.DeleteDirectoryOption.DeleteAllContents)
        End If
        My.Computer.FileSystem.CreateDirectory(tempdc)

        ssels = 0
        Button5.Enabled = False
        srowsc = 0
        DataGridView2.Rows.Clear()
        Dim row As String() = New String() {False, "-", "-", "-", "-", "-", "-", "-", "-", "-", "-"}
        Dim cd1 As String() = New String() {1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2}
        Dim cd2 As String() = New String() {4, 3, 2, 7, 6, 5, 4, 3, 2, 7, 6, 5, 4, 3, 2, 7, 6, 5, 4, 3, 2}
        Dim a1, a2, a3, a4, a5, a6, a7, a8 As String
        Dim s1, s2 As Integer
        If Form1.Label11.Text = "ONLINE" Then
            Try
                con = New SqlConnection("Data Source=" & Form1.label9.Text & ";Database=TPCentralDB;" & Form1.cred & ";")
                cmd = con.CreateCommand
                con.Open()
                For Each item In cuslist.Items
                    If item.checked = True Then
                        ssels = ssels + 1
                        cmd.CommandText = item.subitems(1).text
                        dat = cmd.ExecuteReader()
                        If dat.HasRows Then
                            While dat.Read()
                                row(1) = dat(0)
                                row(2) = dat(1)
                                row(3) = dat(2)
                                row(4) = dat(3)
                                row(5) = dat(4)
                                row(6) = dat(5)
                                row(7) = dat(6)

                                a1 = row(1).ToString().PadLeft(8, "0")
                                a2 = row(2).ToString().PadLeft(3, "0")
                                a3 = row(3).ToString().PadLeft(2, "0")
                                a4 = row(4).ToString()
                                a5 = row(5).ToString().PadLeft(2, "0")
                                a6 = row(6).ToString().PadLeft(3, "0")
                                a7 = row(7).ToString()

                                a8 = a6 + a5 + a2 + a1 + a3 + a4 + a7

                                s1 = 0
                                s2 = 0
                                For xx = 0 To 21
                                    If xx <= 19 Then
                                        If cd1(xx) * Mid(a8, xx + 1, 1) <= 9 Then
                                            s1 = s1 + cd1(xx) * Mid(a8, xx + 1, 1)
                                        Else
                                            s1 = s1 + Microsoft.VisualBasic.Left(cd1(xx) * Mid(a8, xx + 1, 1), 1) + Microsoft.VisualBasic.Right(cd1(xx) * Mid(a8, xx + 1, 1), 1)
                                        End If
                                        s2 = s2 + cd2(xx) * Mid(a8, xx + 1, 1)
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
                                row(8) = a8.ToString() + s1.ToString() + s2.ToString()
                                row(9) = item.subitems(0).text
                                row(10) = Form1.Label10.Text
                                DataGridView2.Rows.Add(row)
                            End While
                        Else
                            item.checked = False
                        End If
                        dat.Close()
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
        If ssels = 0 Then
            Form7.balon("No selection has been made ...")
        End If
    End Sub
    Private Sub DataGridView2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellClick
        Dim ST, CUS, CH, CV, CC, SL, BC As String
        Dim pic As System.IO.FileStream
        Try
            If e.RowIndex >= 0 Then
                Dim barcode As String = DataGridView2.Item(8, e.RowIndex).Value
                If e.ColumnIndex = 8 Then
                    My.Computer.Clipboard.SetText(barcode)
                ElseIf e.ColumnIndex = 11 And My.Computer.FileSystem.FileExists(tempdc & "\" & barcode & ".png") Then
                    pic = New System.IO.FileStream(tempdc & "\" & barcode & ".png", System.IO.FileMode.Open, System.IO.FileAccess.Read)
                    My.Computer.Clipboard.SetImage(System.Drawing.Image.FromStream(pic))
                    pic.Close()
                Else
                    If setbarcus(barcode) Then
                        pic = New System.IO.FileStream(tempdc & "\" & barcode & ".png", System.IO.FileMode.Open, System.IO.FileAccess.Read)
                        DataGridView2.Item(11, e.RowIndex).Value = System.Drawing.Image.FromStream(pic)
                        Dim gr As Graphics = Graphics.FromImage(DataGridView2.Item(11, e.RowIndex).Value)
                        ST = DataGridView2.Item(2, e.RowIndex).Value.ToString.PadLeft(3, "0") + " "
                        CUS = DataGridView2.Item(1, e.RowIndex).Value.ToString.PadLeft(6, "0") + " "
                        CH = DataGridView2.Item(3, e.RowIndex).Value.ToString.PadLeft(2, "0") + " "
                        CV = DataGridView2.Item(4, e.RowIndex).Value.ToString.PadLeft(1, "0")
                        SL = DataGridView2.Item(5, e.RowIndex).Value.ToString.PadLeft(2, "0") + " "
                        BC = DataGridView2.Item(7, e.RowIndex).Value.ToString.PadLeft(1, "0") + " "
                        CC = DataGridView2.Item(6, e.RowIndex).Value.ToString.PadLeft(2, "0")
                        gr.DrawString("Customer : ", New System.Drawing.Font("Arial", 12), New SolidBrush(Color.Black), 10, 5)
                        gr.DrawString(ST & CUS & CH & CV, New System.Drawing.Font("Arial", 12), New SolidBrush(Color.Black), 10, 18)
                        gr.DrawString(DataGridView2.Item(9, e.RowIndex).Value, New System.Drawing.Font("Arial", 12), New SolidBrush(Color.Black), 10, 31)
                        gr.DrawString(DataGridView2.Item(2, e.RowIndex).Value, New System.Drawing.Font("Arial", 12, FontStyle.Bold), New SolidBrush(Color.Black), 10, 44)
                        gr.DrawString(DataGridView2.Item(10, e.RowIndex).Value, New System.Drawing.Font("Arial", 12, FontStyle.Bold), New SolidBrush(Color.Black), 50, 44)
                        gr.Dispose()
                        pic.Close()
                        DataGridView2.Item(11, e.RowIndex).Value.save(tempdc & "\" & barcode & ".png")
                        If DataGridView2.Item(0, e.RowIndex).Value Then
                            DataGridView2.Item(0, e.RowIndex).Value = 0
                            DataGridView2.Item(11, e.RowIndex).Value = Nothing
                            If My.Computer.FileSystem.FileExists(tempdc & "\" & barcode & ".png") Then
                                My.Computer.FileSystem.DeleteFile(tempdc & "\" & barcode & ".png")
                            End If
                            srowsc = srowsc - 1
                        Else
                            DataGridView2.Item(0, e.RowIndex).Value = 1
                            srowsc = srowsc + 1
                        End If
                    End If
                End If
            End If
        Catch ev As Exception
            Form7.balon(ev.Message)
        End Try
        Button5.Enabled = False
        If DataGridView2.Rows.Count > 0 AndAlso srowsc > 0 Then
            Button5.Enabled = True
        End If
    End Sub
    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click

    End Sub

    Private Sub CUSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CUSToolStripMenuItem.Click

    End Sub

    Private Sub STCUSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles STCUSToolStripMenuItem.Click

    End Sub
    Private Sub STCUSCHCVToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles STCUSCHCVToolStripMenuItem.Click

    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click

    End Sub

    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem4.Click

    End Sub

    Private Sub ToolStripMenuItem9_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem9.Click

    End Sub

    Private Sub ToolStripMenuItem10_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem10.Click

    End Sub

    Private Sub ToolStripMenuItem6_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem6.Click

    End Sub

    Private Sub ToolStripMenuItem7_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem7.Click

    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        CODrefresh()
    End Sub

    Private Sub CODrefresh()
        Dim ssql As String
        Dim dat1 As New DataSet()

        Try
            If RadioButton10.Checked Then
                ssql = "select szstatuscode Status, szExternalID ExternalID, szStoreID StoreNr, lPaymentType PaymentType, szLoadDate LoadDate, szErrorAddInfo Error, szInvoiceID InvoiceID from mgirecalltransactioncod where szprocessingdate='" & Format(DateTimePicker1.Value, "yyyyMMdd") & "'"
            ElseIf RadioButton4.Checked Then
                ssql = "select szstatuscode Status, szExternalID ExternalID, szStoreID StoreNr, lPaymentType PaymentType, szLoadDate LoadDate, szErrorAddInfo Error, szInvoiceID InvoiceID from mgirecalltransactioncod where szprocessingdate='" & Format(Today, "yyyyMMdd") & "'"
            ElseIf RadioButton6.Checked Then
                ssql = "select top 10 szstatuscode Status, szExternalID ExternalID, szStoreID StoreNr, lPaymentType PaymentType, szLoadDate LoadDate, szErrorAddInfo Error, szInvoiceID InvoiceID from mgirecalltransactioncod order by szprocessingdate desc, szprocessingtime desc"
            Else
                ssql = "select szstatuscode Status, szExternalID ExternalID, szStoreID StoreNr, lPaymentType PaymentType, szLoadDate LoadDate, szErrorAddInfo Error, szInvoiceID InvoiceID from mgirecalltransactioncod"
            End If

            con1 = New SqlConnection("Data Source=" & Form1.label9.Text & ";Database=TPCentralDB;" & Form1.cred & ";")
            Dim runsql As New SqlDataAdapter(ssql, con1)
            runsql.Fill(dat1, "cod")
            DataGridView3.DataSource = dat1.Tables(0)

            dat1.Dispose()
            con1.Close()
        Catch ev As Exception
            Form7.balon(ev.Message)
            dat1.Dispose()
            con1.Close()
        End Try
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        txrefresh()
    End Sub
    Private Sub txrefresh()
        Dim ssql As String
        Dim dat1 As New DataSet()

        Try
            If RadioButton11.Checked Then
                ssql = "select lHostInterfaceID1 Host1, lHostInterfaceID2 Host2 ,lTaNmbr TaNr, dInvoiceTotalToPayAmount Total ,lInvoiceBookNumber BookNr, szMetroInvoiceNumber InvoiceNr, szCustomerNumber CustomerNr, szDate Date from MAITXInvoice where szdate='" & Format(DateTimePicker2.Value, "yyyyMMdd") & "'"
            ElseIf RadioButton9.Checked Then
                ssql = "select lHostInterfaceID1 Host1, lHostInterfaceID2 Host2 ,lTaNmbr TaNr, dInvoiceTotalToPayAmount Total ,lInvoiceBookNumber BookNr, szMetroInvoiceNumber InvoiceNr, szCustomerNumber CustomerNr, szDate Date from MAITXInvoice where szdate='" & Format(Today, "yyyyMMdd") & "'"
            ElseIf RadioButton7.Checked Then
                ssql = "select lHostInterfaceID1 Host1, lHostInterfaceID2 Host2 ,lTaNmbr TaNr, dInvoiceTotalToPayAmount Total ,lInvoiceBookNumber BookNr, szMetroInvoiceNumber InvoiceNr, szCustomerNumber CustomerNr, szDate Date from MAITXInvoice order by szdate desc, sztime desc"
            Else
                ssql = "select lHostInterfaceID1 Host1, lHostInterfaceID2 Host2 ,lTaNmbr TaNr, dInvoiceTotalToPayAmount Total ,lInvoiceBookNumber BookNr, szMetroInvoiceNumber InvoiceNr, szCustomerNumber CustomerNr, szDate Date from maitxinvoice"
            End If

            con1 = New SqlConnection("Data Source=" & Form1.label9.Text & ";Database=TPCentralDB;" & Form1.cred & ";")
            Dim runsql As New SqlDataAdapter(ssql, con1)
            runsql.Fill(dat1, "tx")
            DataGridView4.DataSource = dat1.Tables(0)

            dat1.Dispose()
            con1.Close()
        Catch ev As Exception
            Form7.balon(ev.Message)
            dat1.Dispose()
            con1.Close()
        End Try
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        chnrefresh()
    End Sub
    Private Sub chnrefresh()
        If My.Computer.FileSystem.DirectoryExists(tempdh) Then
            My.Computer.FileSystem.DeleteDirectory(tempdh, FileIO.DeleteDirectoryOption.DeleteAllContents)
        End If
        My.Computer.FileSystem.CreateDirectory(tempdh)

        Try
            Dim rowcc As String() = {"-", "-"}
            Dim ssql, csql, bar, bar1, bar2, barc, b, ipp, barcode As String
            Dim cd, cd1, cd2, i, j, h As Integer
            Dim pic As System.IO.FileStream
            barc = "1212121212"
            DataGridView5.DataSource = Nothing
            DataGridView5.Rows.Clear()

            If Not RadioButton3.Checked Then
                Dim dat1 As New DataSet()
                Try

                    If RadioButton1.Checked Then
                        ipp = System.Net.Dns.GetHostEntry(ComboBox1.Text & ".MPOS.MADM.NET").AddressList(0).ToString()
                        csql = "Data Source=" & ipp & ";Database=TPCentralDB;" & Form1.cred & ";"
                    Else
                        csql = "Data Source=" & Form1.label9.Text & ";Database=TPCentralDB;" & Form1.cred & ";"
                    End If

                    ssql = "SELECT lLastIncrementalValue+1 'Next Seq.',szInvoiceID 'Last Barcode',lLastIncrementalValue 'Last Seq.',lRetailStoreID 'Store',lWorkstationNmbr 'Till',lBookType 'Book Type' FROM MGIWorkstationInvoiceID  where bTrainingFlag=0 and lBookType in (11,12,13)"
                    con1 = New SqlConnection("Data Source=" & Form1.label9.Text & ";Database=TPCentralDB;" & Form1.cred & ";")
                    Dim runsql As New SqlDataAdapter(ssql, con1)
                    runsql.Fill(dat1, "chn")
                    DataGridView5.DataSource = dat1.Tables(0)
                    DataGridView5.Refresh()
                    h = 0
                    For Each row As DataRow In dat1.Tables(0).Rows()
                        If row(5) = 11 Then
                            b = "N"
                        Else
                            b = "V"
                        End If
                        cd = 0
                        bar = row(3).ToString().PadLeft(2, "0") + row(0).ToString().PadLeft(8, "0")
                        For i = 1 To 10
                            cd = cd + Mid(bar, i, 1) * Mid(barc, i, 1)
                        Next i
                        cd = cd Mod 10
                        barcode = b.ToString + bar.ToString + cd.ToString
                        If setbarchn(barcode) Then
                            pic = New System.IO.FileStream(tempdh & "\" & barcode & ".png", System.IO.FileMode.Open, System.IO.FileAccess.Read)
                            DataGridView5.Item(1, h).Value = barcode
                            DataGridView5.Item(0, h).Value = System.Drawing.Image.FromStream(pic)
                            pic.Close()
                        End If
                        h = h + 1
                    Next
                    dat1.Dispose()
                    con1.Close()
                Catch xx As Exception
                    Form7.balon(xx.Message)
                    dat1.Dispose()
                    con1.Close()
                End Try
            Else
                For i = 0 To 19
                    cd = 0
                    bar1 = Form1.Label7.Text.ToString().PadLeft(2, "0") + "140000" + i.ToString().PadLeft(2, "0")
                    bar2 = Form1.Label7.Text.ToString().PadLeft(2, "0") + "240000" + i.ToString().PadLeft(2, "0")
                    For j = 1 To 10
                        cd1 = cd1 + Mid(bar1, j, 1) * Mid(barc, j, 1)
                        cd2 = cd2 + Mid(bar2, j, 1) * Mid(barc, j, 1)
                    Next j
                    cd1 = cd1 Mod 10
                    cd2 = cd2 Mod 10
                    barcode = "N" + bar1.ToString + cd1.ToString
                    rowcc = {Nothing, barcode}
                    DataGridView5.Rows.Add(rowcc)
                    If setbarchn(barcode) Then
                        pic = New System.IO.FileStream(tempdh & "\" & barcode & ".png", System.IO.FileMode.Open, System.IO.FileAccess.Read)
                        DataGridView5.Item(0, 2 * i).Value = System.Drawing.Image.FromStream(pic)
                        pic.Close()
                    End If
                    barcode = "V" + bar2.ToString + cd2.ToString
                    rowcc = {Nothing, barcode}
                    DataGridView5.Rows.Add(rowcc)
                    If setbarchn(barcode) Then
                        pic = New System.IO.FileStream(tempdh & "\" & barcode & ".png", System.IO.FileMode.Open, System.IO.FileAccess.Read)
                        DataGridView5.Item(0, 2 * i + 1).Value = System.Drawing.Image.FromStream(pic)
                        pic.Close()
                    End If
                Next
            End If
        Catch xx As Exception
            Form7.balon(xx.Message)
        End Try
        Button8.Enabled = False
        If DataGridView5.RowCount > 0 Then
            Button8.Enabled = True
        End If
    End Sub
    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        ComboBox1.Enabled = False
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        ComboBox1.Enabled = False
    End Sub

    Private Sub RefreshToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem2.Click
        CODrefresh()
    End Sub

    Private Sub RefreshToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem1.Click
        txrefresh()
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem.Click
        chnrefresh()
    End Sub

    Private Sub RadioButton10_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton10.CheckedChanged
        DateTimePicker1.Enabled = True
    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        DateTimePicker1.Enabled = False
    End Sub

    Private Sub RadioButton6_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton6.CheckedChanged
        DateTimePicker1.Enabled = False
    End Sub

    Private Sub RadioButton5_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton5.CheckedChanged
        DateTimePicker1.Enabled = False
    End Sub

    Private Sub RadioButton9_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton9.CheckedChanged
        DateTimePicker2.Enabled = False
    End Sub

    Private Sub RadioButton7_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton7.CheckedChanged
        DateTimePicker2.Enabled = False
    End Sub

    Private Sub RadioButton8_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton8.CheckedChanged
        DateTimePicker2.Enabled = False
    End Sub

    Private Sub RadioButton11_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton11.CheckedChanged
        DateTimePicker2.Enabled = True
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        Dim conq As New SqlConnection("Data Source=" & Form1.label9.Text & ";Database=TPCentralDB;" & Form1.cred & ";")
        Dim cmdq As New SqlCommand
        Dim datq As SqlDataReader
        ComboBox1.Items.Clear()
        Try
            If Form1.Label11.Text = "ONLINE" Then
                cmdq.Connection = conq
                conq.Open()
            End If
            If (conq.State = ConnectionState.Open) Then
                cmdq.CommandText = "select szworkstationid  from workstation where bIsBackstore = 0 And bIsThickPos = -1 And bIsVirtualRegister = 0"
                datq = cmdq.ExecuteReader()
                While datq.Read()
                    Try
                        ComboBox1.Items.Add(datq(0))
                    Catch
                    End Try
                End While
                ComboBox1.Text = ComboBox1.Items(0)
                ComboBox1.Enabled = True
                datq.Dispose()
                conq.Dispose()
            End If
        Catch ed As SqlException
            MsgBox(ed.Message)
        End Try
    End Sub

    Private Sub DataGridView5_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView5.CellClick
        Dim pic As System.IO.FileStream
        Try
            If e.RowIndex >= 0 Then
                Dim barcode As String = DataGridView5.Item(1, e.RowIndex).Value
                If e.ColumnIndex = 1 Then
                    My.Computer.Clipboard.SetText(barcode)
                ElseIf e.ColumnIndex = 0 And My.Computer.FileSystem.FileExists(tempdh & "\" & barcode & ".png") Then
                    pic = New System.IO.FileStream(tempdh & "\" & barcode & ".png", System.IO.FileMode.Open, System.IO.FileAccess.Read)
                    My.Computer.Clipboard.SetImage(System.Drawing.Image.FromStream(pic))
                    pic.Close()
                End If
            End If
        Catch ev As Exception
            Form7.balon(ev.Message)
        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.TopMost = True
        Me.TopMost = False
        Me.printPDF("CUS")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.TopMost = True
        Me.TopMost = False
        Me.printPDF("ART")
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Me.TopMost = True
        Me.TopMost = False
        Me.printPDF("CHN")
    End Sub

    Private Sub printPDF(barcodetype)

        'Get list of images
        Dim jdc As String = ""

        If barcodetype = "ART" Then
            jdc = Me.tempda
        ElseIf barcodetype = "CUS" Then
            jdc = Me.tempdc
        ElseIf barcodetype = "CHN" Then
            jdc = Me.tempdh
        End If

        Dim dirInfo As New DirectoryInfo(jdc)
        Dim images() As FileInfo = FilterForImages(dirInfo.GetFiles())
        Dim x As FileInfo
        'Create PDF doc
        Dim pdfdoc As New Document()
        Dim pdfwrite As PdfWriter = PdfWriter.GetInstance(pdfdoc, New FileStream(Path.Combine(jdc, barcodetype.ToString & ".pdf"), FileMode.Create))
        'Open PDF doc
        pdfdoc.Open()
        Dim p As Paragraph = New Paragraph("-=" + barcodetype.ToString + " - Country: " + Form1.Label10.Text + " - Store: " + Form1.Label7.Text + " =-")
        p.Alignment = Element.ALIGN_CENTER
        p.Font.Size = 16
        pdfdoc.Add(p)
        pdfdoc.Add(Chunk.NEWLINE)

        Dim image As iTextSharp.text.Image = Nothing
        For Each x In images
            image = iTextSharp.text.Image.GetInstance(x.FullName)
            image.ScalePercent(80)
            pdfdoc.Add(New Chunk(image, 0, 15, True))

        Next
        pdfdoc.Close()
        System.Diagnostics.Process.Start(Path.Combine(jdc, barcodetype.ToString & ".pdf"))
    End Sub

    Function FilterForImages(images() As FileInfo) As FileInfo()
        Dim newImages As New ArrayList(images.Length)

        Dim i As Integer
        For i = 0 To images.Length - 1
            If Path.GetExtension(images(i).Name.ToLower()) = ".jpg" OrElse _
               Path.GetExtension(images(i).Name.ToLower()) = ".jpeg" OrElse _
               Path.GetExtension(images(i).Name.ToLower()) = ".png" OrElse _
               Path.GetExtension(images(i).Name.ToLower()) = ".gif" Then
                newImages.Add(images(i))
            End If
        Next

        Return CType(newImages.ToArray(GetType(FileInfo)), FileInfo())
    End Function

    Function checkFile() As System.IO.File
        If My.Computer.FileSystem.FileExists("test.pdf") Then

        End If
        My.Computer.FileSystem.DeleteFile("test.pdf")
        End
    End Function
    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        ssels = 0
        srowsa = 0
        Button2.Enabled = False
        DataGridView6.Rows.Clear()
        Dim row As String() = New String() {"-", "-", "-", "-", "-", "-", "-", "-", "-"}
        If Form1.Label11.Text = "ONLINE" Then
            Try
                con = New SqlConnection("Data Source=" & Form1.label9.Text & ";Database=TPCentralDB;" & Form1.cred & ";")
                cmd = con.CreateCommand
                con.Open()
                ssels = ssels + 1
                cmd.CommandText = "select szDiscountID,szName,lTier,bActivated,szRuleIdentifierID,lPriority,'aha' from discountaffiliation"
                dat = cmd.ExecuteReader()
                If dat.HasRows Then
                    While dat.Read()
                        row(0) = dat(0)
                        row(1) = dat(1)
                        row(2) = dat(2)
                        row(3) = dat(3)
                        row(4) = dat(4)
                        row(5) = dat(5)
                        row(6) = dat(6)
                        row(7) = dat(7)
                        DataGridView6.Rows.Add(row)
                    End While
                    dat.Close()
                End If
        cmd.Dispose()
        con.Dispose()
            Catch af As Exception
            Form7.balon(af.Message)
        End Try
        Else
            Form7.balon("Server is offline ...")
        End If
        If ssels = 0 Then
            Form7.balon("No selection has been made ...")
        End If
    End Sub
    '   Function DiscountType()
    'Dim ssqll As String
    'Dim dat3 As New DataSet()

    '    Try
    '       ssqll = "select ISNULL(szlinetypecodeid,'') + ISNULL(szmxmtypecodeid,'') + ISNULL(szqtytypecodeid,'') from DiscountAffiliation where szDiscountID = '" & DataGridView6.Item(1, 1).Value & "'"
    'Dim runsql As New SqlDataAdapter(ssqll, con)
    '       runsql.Fill(dat3)

    '        dat3.Dispose()
    '       con1.Close()
    '  Catch ev As Exception
    '     Form7.balon(ev.Message)
    '    dat1.Dispose()
    '   con1.Close()
    'End Try
    'End Function
End Class



