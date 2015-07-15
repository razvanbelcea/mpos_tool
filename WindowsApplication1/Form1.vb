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
Imports System.Threading.Thread
Imports Microsoft.Win32
Imports Microsoft.VisualBasic
Imports System.IO
Imports System.Security.Permissions
Class Form1
    Public Shared UID As String = "sa"
    Public Shared PSW As String = "Pa$$w0rd"
    Public Shared cred1 As String = "Integrated Security=SSPI"
    Public Shared cred2 As String = "Uid=" & UID & "; Password=" & PSW
    Public Shared cred As String = cred1
    Public Shared svl As String = "serverlist.xml"
    Public Shared ffl As String = "folderlist.xml"
    Public Shared srl As String = "servicelist.xml"
    Public Shared cfl As String = "countlist.xml"
    Public Shared hff As String = "\c$\mgi\mposinstallstate.xml"
    Public Shared x As Boolean = False
    Dim anulareserver As CancellationTokenSource
    Dim anulareservice As CancellationTokenSource
    Dim anularetills As CancellationTokenSource
    Dim anulareoperators As CancellationTokenSource
    Dim cnt As String = ""
    Private con As SqlConnection
    Private cmd As SqlCommand
    Private dat As SqlDataReader
    Private con1 As SqlConnection
    Private cmd1 As SqlCommand
    Private dat1 As SqlDataReader
    Private con2 As SqlConnection
    Private cmd2 As SqlCommand
    Private dat2 As SqlDataReader
    '-----------------------------------------------------------------------------------------------------------------------------------------BEGIN form load/unload
    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If x = False Then
            NotifyIcon1.Visible = True
            Me.Hide()
            Form7.Show()
            e.Cancel = True
        End If
    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Control.CheckForIllegalCrossThreadCalls = False
        Me.Show()
        If Me.TopMost = False Then
            Me.TopMost = True
            Me.TopMost = False
        End If
        taskserver()
    End Sub
    '-----------------------------------------------------------------------------------------------------------------------------------------END form load/unload
    '-----------------------------------------------------------------------------------------------------------------------------------------BEGIN read xml files
    Public Sub readserverlist()
        Dim readserver As XmlTextReader = New XmlTextReader(svl)
        Dim i As Integer = 0
        Dim s As String = ""
        serverlist.Items.Clear()
        Form7.ComboBox1.Items.Clear()
        Try
            Do While (readserver.Read())
                Select Case readserver.NodeType
                    Case XmlNodeType.Element
                        Select Case readserver.Name
                            Case "Country"
                                readserver.Read()
                                serverlist.Items.Add(readserver.Value)
                                s = readserver.Value & " "
                            Case "Name"
                                readserver.Read()
                                serverlist.Items(i).SubItems.Add(readserver.Value)
                                s = s & readserver.Value & " IP-"
                            Case "Ip"
                                readserver.Read()
                                serverlist.Items(i).SubItems.Add(readserver.Value)
                                s = s & readserver.Value
                            Case "Location"
                                readserver.Read()
                                If readserver.Value = "QA" Then
                                    serverlist.Items.Item(i).Group = serverlist.Groups(0)
                                ElseIf readserver.Value = "UAT" Then
                                    serverlist.Items.Item(i).Group = serverlist.Groups(1)
                                End If
                                s = readserver.Value & " " & s
                                Form7.ComboBox1.Items.Add(s)
                                i = i + 1
                        End Select
                End Select
            Loop
            readserver.Dispose()
            ToolStripProgressBar1.Maximum = i
        Catch e As Exception
            Form7.balon(e.Message)
        End Try
    End Sub
    Private Sub readfolderlist()
        Dim readfolder As XmlTextReader = New XmlTextReader(ffl)
        Dim i As Integer = 0
        Try
            folderlist.Items.Clear()
            Do While (readfolder.Read())
                Select Case readfolder.NodeType
                    Case XmlNodeType.Element
                        Select Case readfolder.Name
                            Case "Name"
                                readfolder.Read()
                                folderlist.Items.Add(readfolder.Value)
                            Case "Path"
                                readfolder.Read()
                                folderlist.Items(i).SubItems.Add("\\" + Label9.Text + readfolder.Value)
                                i = i + 1
                        End Select
                End Select
            Loop
            readfolder.Dispose()
        Catch e As Exception
            Form7.balon(e.Message)
        End Try
    End Sub
    Private Sub readservicelist()
        Dim readservice As XmlTextReader = New XmlTextReader(srl)
        Dim i As Integer = 0
        servicelist.Items.Clear()
        Try
            Do While (readservice.Read())
                Select Case readservice.NodeType
                    Case XmlNodeType.Element
                        Select Case readservice.Name
                            Case "Service"
                                readservice.Read()
                                servicelist.Items.Add(readservice.Value)
                                If Label11.Text = "ONLINE" Then
                                    ccd.Visible = True
                                    Label6.Visible = True
                                Else
                                    servicelist.Items(i).SubItems.Add("-")
                                    servicelist.Items(i).SubItems.Add("-")
                                End If
                                i = i + 1
                        End Select
                End Select
            Loop
            readservice.Dispose()
        Catch e As Exception
            Form7.balon(e.Message)
        End Try
    End Sub
    '-----------------------------------------------------------------------------------------------------------------------------------------END read xml files
    '-----------------------------------------------------------------------------------------------------------------------------------------BEGIN server selection
    Private Sub serverlist_SelectedIndexChanged(sender As Object, e As EventArgs) Handles serverlist.SelectedIndexChanged
        Button1.Visible = True
        viewserver()
        statusserver()
        readfolderlist()
        loaddatabase()
        taskservice()
        loadcounts()
    End Sub
    Private Sub statusserver()
        Try
            If My.Computer.Network.Ping(Label9.Text) Then
                PictureBox2.Visible = False
                PictureBox1.Visible = True
                Label11.Text = "ONLINE"
                Label11.ForeColor = Color.Green
            Else
                PictureBox2.Visible = True
                PictureBox1.Visible = False
                Label11.Text = "OFFLINE"
                Label11.ForeColor = Color.Red
                tpb.Visible = False
                tlb.Visible = False
            End If
        Catch e As Exception
            Form7.balon(e.Message)
        End Try
    End Sub
    Private Sub viewserver()
        metro.Visible = False
        title.Visible = False
        status.Visible = True
        folders.Visible = True
        tills.Visible = True
        operators.Visible = True
        For Each item As ListViewItem In serverlist.Items
            If item.Selected = True Then
                Label9.Text = item.SubItems(2).Text
                Label8.Text = item.SubItems(1).Text
                Label10.Text = item.SubItems(0).Text
                Try
                    Dim MyReg As RegistryKey
                    Dim MyVal As Object
                    MyReg = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, item.SubItems(1).Text & ".mpos.madm.net", RegistryView.Registry64) _
                            .OpenSubKey("SOFTWARE\Wincor Nixdorf\TPDotnet\CustomerAddOns", False)
                    MyVal = MyReg.GetValue("Custom Version")
                    Label13.Text = MyVal.ToString
                    MyReg.Close()
                Catch a As Exception
                    Label13.Text = "-"
                End Try
                Exit For
            End If
        Next
    End Sub
    '-----------------------------------------------------------------------------------------------------------------------------------------END server selection
    '-----------------------------------------------------------------------------------------------------------------------------------------BEGIN folder selection
    Private Sub folderlist_ItemSelectionChanged(sender As Object, e As ListViewItemSelectionChangedEventArgs) Handles folderlist.ItemSelectionChanged
        Try
            For Each item As ListViewItem In folderlist.Items
                If item.Selected = True AndAlso My.Computer.FileSystem.DirectoryExists(item.SubItems(1).Text) Then
                    Process.Start("explorer.exe", item.SubItems(1).Text)
                    Exit For
                ElseIf item.Selected = True AndAlso Not My.Computer.FileSystem.DirectoryExists(item.SubItems(1).Text) Then
                    Form7.balon("Location not found ...")
                End If
            Next
        Catch ey As Exception
            Form7.balon(ey.Message)
        End Try
    End Sub
    '-----------------------------------------------------------------------------------------------------------------------------------------END folder selection
    '-----------------------------------------------------------------------------------------------------------------------------------------BEGIN load stuff
    Private Sub loaddatabase()
        operatorlist.Items.Clear()
        tilllist.Items.Clear()
        con = New SqlConnection("Data Source=" & Label9.Text & ";Database=TPCentralDB;" & cred & ";")
        If Label11.Text = "ONLINE" Then
            Try
                con.Open()
            Catch e As Exception
                'Form7.balon(e.Message & " - " & Label9.Text)
            End Try
            If con.State = ConnectionState.Open Then
                con.Close()
                Label12.Text = "DB is ONLINE"
                Label12.ForeColor = Color.Green
                PictureBox3.Visible = False
                PictureBox4.Visible = True
                tasktills()
                taskoperators()
            Else
                Label12.Text = "DB is OFFLINE"
                Label12.ForeColor = Color.Red
                PictureBox3.Visible = True
                PictureBox4.Visible = False
                tpb.Visible = False
                tlb.Visible = False
            End If
        Else
            Label12.Text = "DB is OFF"
            Label12.ForeColor = Color.Red
            PictureBox3.Visible = True
            PictureBox4.Visible = False
            tpb.Visible = False
            tlb.Visible = False
        End If
    End Sub
    Private Sub loadoperators(tokenoperators As CancellationToken)
        Dim i As Integer = 0
        Try
            con1 = New SqlConnection("Data Source=" & Label9.Text & ";Database=TPCentralDB;" & cred & ";")
            cmd1 = con1.CreateCommand
            con1.Open()
            cmd1.CommandText = "select lOperatorID,szname from OperatorProfileAffiliation as a join profile as b on a.lProfileID=b.lProfileID"
            dat1 = cmd1.ExecuteReader()
            While dat1.Read()
                If tokenoperators.IsCancellationRequested Then
                    tokenoperators.ThrowIfCancellationRequested()
                End If
                operatorlist.Items.Add(dat1(0))
                operatorlist.Items(i).SubItems.Add(dat1(1))
                i = i + 1
            End While
            dat1.Close()
            con1.Close()
        Catch
            dat1.Close()
            con1.Close()
        End Try
    End Sub
    Private Sub loadtills(tokentills As CancellationToken)
        Dim ff As String
        Dim i As Integer = 0
        Dim arr As Array = {"-", "-", "-", "-", "-", "-", "-"}
        Try
            con = New SqlConnection("Data Source=" & Label9.Text & ";Database=TPCentralDB;" & cred & ";")
            cmd = con.CreateCommand
            cmd.CommandText = "select szWorkstationID,lWorkstationNmbr, szWorkstationGroupID,lOperatorID from workstation left join operator on lLoggedOnWorkstationNmbr=lWorkstationNmbr where bisthickpos<>0"
            con.Open()
            dat = cmd.ExecuteReader()
            tpb.Visible = True
            tlb.Visible = True
            While dat.Read()
                arr = {"-", "-", "-", "-", "-", "-", "-"}
                If tokentills.IsCancellationRequested Then
                    tokentills.ThrowIfCancellationRequested()
                End If
                arr(0) = dat(0)
                arr(1) = dat(1)
                arr(2) = dat(2)
                If Not IsDBNull(dat(3)) Then
                    arr(3) = dat(3)
                End If
                Try
                    arr(4) = System.Net.Dns.GetHostEntry(arr(0) & ".MPOS.MADM.NET").AddressList(0).ToString()
                Catch
                End Try
                Try
                    If arr(4) <> "-" AndAlso My.Computer.Network.Ping(arr(4)) Then
                        arr(5) = "ON"
                    Else
                        arr(5) = "OFF"
                    End If
                Catch
                End Try
                Try
                    ff = "\\" & arr(4) & "\e$\TpDotnet\cfg\Metro.MPOS.PrintProcessor." & Label10.Text & ".xml"
                    If arr(4) <> "-" AndAlso arr(5) = "ON" AndAlso My.Computer.FileSystem.FileExists(ff) Then
                        Dim readprinter As XmlTextReader = New XmlTextReader(ff)
                        Do While (readprinter.Read())
                            Select Case readprinter.NodeType
                                Case XmlNodeType.Element
                                    If readprinter.Name = "PrinterType" Then
                                        readprinter.Read()
                                        If readprinter.Value >= 0 And readprinter.Value <= 2 Then
                                            arr(6) = readprinter.Value
                                        End If
                                    End If
                            End Select
                        Loop
                        readprinter.Dispose()
                    End If
                Catch
                End Try
                tilllist.Items.Add(i)
                If arr(5) = "ON" Then
                    tilllist.Items(i).ForeColor = Color.Green
                ElseIf arr(5) = "OFF" Then
                    tilllist.Items(i).ForeColor = Color.Red
                End If
                For Each item In arr
                    tilllist.Items(i).SubItems.Add(item)
                Next
                i = i + 1
            End While
            dat.Dispose()
            con.Dispose()
        Catch e As Exception
            'Form7.balon(e.Message)
        End Try
        tpb.Visible = False
        tlb.Visible = False
    End Sub
    Private Sub loadcounts()
        Dim readcounts As XmlTextReader = New XmlTextReader(cfl)
        Dim con3 As New SqlConnection("Data Source=" & Label9.Text & ";Database=TPCentralDB;" & cred & ";")
        Dim cmd3 As New SqlCommand
        Dim dat3 As SqlDataReader
        cnt = vbTab & vbTab & vbTab & vbTab & vbTab & vbCrLf
        Try
            If Label11.Text = "ONLINE" Then
                con3.Open()
                cmd3 = con3.CreateCommand
                cmd3.CommandText = "select lRetailStoreID from workstation where szWorkstationID='" & Label8.Text & "'"
                dat3 = cmd3.ExecuteReader()
                dat3.Read()
                Label7.Text = dat3(0)
                dat3.Close()
                For Each item As ListViewItem In serverlist.Items
                    If item.Selected = True Then
                        Try
                            Do While (readcounts.Read())
                                Select Case readcounts.NodeType
                                    Case XmlNodeType.Element
                                        Select Case readcounts.Name
                                            Case "Name"
                                                readcounts.Read()
                                                cnt = cnt & readcounts.Value & " : "
                                            Case "Sql"
                                                readcounts.Read()
                                                cmd3 = con3.CreateCommand
                                                cmd3.CommandText = readcounts.Value
                                                dat3 = cmd3.ExecuteReader()
                                                dat3.Read()
                                                cnt = cnt & dat3(0) & vbCrLf
                                                dat3.Close()
                                        End Select
                                End Select
                            Loop
                            readcounts.Dispose()
                        Catch e As Exception
                            Form7.balon(e.Message)
                        End Try
                        Exit For
                    End If
                Next
                cmd3.Dispose()
                con3.Close()
            End If
            cnt = cnt & vbCrLf & vbTab & vbTab & vbTab & vbTab & vbTab
        Catch ex As Exception
            Form7.balon(ex.Message)
            cmd3.Dispose()
            con3.Close()
        End Try
    End Sub
    Private Sub loadservice(tokenservice As CancellationToken)
        Dim i As Integer = 0
        ccd.Visible = False
        Label6.Visible = False
        If Label11.Text = "ONLINE" Then
            ccd.Visible = True
            Label6.Visible = True
            For Each item As ListViewItem In servicelist.Items
                tokenservice.ThrowIfCancellationRequested()
                Try
                    Dim serv As New ServiceController(item.SubItems(0).Text, Label8.Text & ".mpos.madm.net")
                    item.SubItems.Add(serv.DisplayName)
                    item.SubItems.Add(serv.Status.ToString)
                    serv.Dispose()
                Catch a As Exception
                    item.SubItems.Add("-")
                    item.SubItems.Add("-")
                End Try
            Next
            ccd.Visible = False
            Label6.Visible = False
        End If
    End Sub
    Private Sub loadping(tokenserver As CancellationToken)
        Dim i As Integer = 0
        Dim msg As String = ""
        Dim MyReg As RegistryKey
        Dim MyVal As Object
        sss.Visible = True
        For Each item As ListViewItem In serverlist.Items
            tokenserver.ThrowIfCancellationRequested()
            If My.Computer.Network.Ping(item.SubItems(2).Text) Then
                item.ForeColor = Color.Green
                item.SubItems.Add("ON")
                Try
                    MyReg = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, item.SubItems(1).Text & ".mpos.madm.net", RegistryView.Registry64) _
                        .OpenSubKey("SOFTWARE\Wincor Nixdorf\TPDotnet\CustomerAddOns", False)
                    MyVal = MyReg.GetValue("Custom Version")
                    item.SubItems.Add(MyVal.ToString)
                    MyReg.Close()
                Catch a As Exception
                    item.SubItems.Add("-")
                End Try
                item.SubItems.Add("-")
                item.SubItems.Add("-")
                item.SubItems.Add("-")
            Else
                item.ForeColor = Color.Red
                item.SubItems.Add("OFF")
                item.SubItems.Add("-")
                item.SubItems.Add("-")
                item.SubItems.Add("-")
                item.SubItems.Add("-")
            End If
            i = i + 1
            ToolStripProgressBar1.Value = i
        Next
        ToolStripProgressBar1.Value = 0
        sss.Visible = False
    End Sub
    '-----------------------------------------------------------------------------------------------------------------------------------------END load stuff
    '-----------------------------------------------------------------------------------------------------------------------------------------BEGIN tasks 
    Private Sub taskserver()
        If anulareserver IsNot Nothing Then
            anulareserver.Cancel()
        End If
        readserverlist()
        anulareserver = New CancellationTokenSource
        Dim tokenserver = anulareserver.Token
        Task.Factory.StartNew(Sub() loadping(tokenserver), tokenserver)
    End Sub
    Private Sub taskservice()
        If anulareservice IsNot Nothing Then
            anulareservice.Cancel()
        End If
        readservicelist()
        anulareservice = New CancellationTokenSource
        Dim tokenservice = anulareservice.Token
        Task.Factory.StartNew(Sub() loadservice(tokenservice), tokenservice)
    End Sub
    Private Sub taskoperators()
        If anulareoperators IsNot Nothing Then
            anulareoperators.Cancel()
        End If
        anulareoperators = New CancellationTokenSource
        Dim tokenoperators = anulareoperators.Token
        Task.Factory.StartNew(Sub() loadoperators(tokenoperators), tokenoperators)
    End Sub
    Private Sub tasktills()
        If anularetills IsNot Nothing Then
            anularetills.Cancel()
        End If
        anularetills = New CancellationTokenSource
        Dim tokentills = anularetills.Token
        Task.Factory.StartNew(Sub() loadtills(tokentills), tokentills)
    End Sub
    '-----------------------------------------------------------------------------------------------------------------------------------------END tasks
    '-----------------------------------------------------------------------------------------------------------------------------------------BEGIN menus
    Private Sub logoffoperator()
        Dim con As New SqlConnection("Data Source=" & Label9.Text & ";Database=TPCentralDB;" & cred & ";")
        Dim cmd As New SqlCommand
        Try
            con.Open()
            If Label11.Text = "ONLINE" Then
                For Each item As ListViewItem In tilllist.Items
                    If item.Selected = True Then
                        cmd = New SqlCommand("update operator set lLoggedOnWorkstationNmbr=0 where loperatorid=" & item.SubItems(4).Text, con)
                        Try
                            Form7.balon("Operator has been forced logged off !" & vbCrLf & cmd.ExecuteNonQuery().ToString & " row/s have been updated")
                        Catch eg As Exception
                            Form7.balon(eg.Message)
                        End Try
                        cmd.Dispose()
                        Exit For
                    End If
                Next
            End If
            con.Close()
        Catch ex As Exception
            Form7.balon(ex.Message)
        End Try
    End Sub
    Private Sub restarttill()
        For Each item As ListViewItem In tilllist.Items
            If item.Selected = True Then
                Try
                    Process.Start("cmd.exe", "/c shutdown -r -t 0 -m \\" & item.SubItems(5).Text)
                    Form7.balon("Restart command has been sent!")
                Catch ed As Exception
                    Form7.balon(ed.Message)
                End Try
                Exit For
            End If
        Next
    End Sub
    Private Sub resetoperator()
        Dim con As New SqlConnection("Data Source=" & Label9.Text & ";Database=TPCentralDB;" & cred & ";")
        Dim cmd As New SqlCommand
        Try
            If Label11.Text = "ONLINE" Then
                con.Open()
                For Each item As ListViewItem In operatorlist.Items
                    If item.Selected = True AndAlso item.SubItems(0).Text <> "-" Then
                        cmd = New SqlCommand("update Operator set szSignOnPassword='PkaIqJt8znE=',szPasswordExpirationDate='20161111',bPasswordChangeFlag=0 where lOperatorID='" & item.SubItems(0).Text & "'", con)
                        Try
                            Form7.balon("Operator password has been reset to : 123" & vbCrLf & cmd.ExecuteNonQuery().ToString & "  row/s have been updated")
                        Catch
                        End Try
                        cmd.Dispose()
                        Exit For
                    End If
                Next
                con.Close()
            End If
        Catch ew As Exception
            Form7.balon(ew.Message)
        End Try
    End Sub
    Private Sub ResetOperatorPassword123ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResetOperatorPassword123ToolStripMenuItem.Click
        resetoperator()
    End Sub
    Private Sub RefreshToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem2.Click
        loaddatabase()
    End Sub
    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem.Click
        loaddatabase()
    End Sub
    Private Sub RestartTillToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RestartTillToolStripMenuItem.Click
        restarttill()
    End Sub
    Private Sub ForceSignOutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ForceSignOutToolStripMenuItem.Click
        logoffoperator()
    End Sub
    Private Sub RefreshStatusToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshStatusToolStripMenuItem.Click
        taskserver()
    End Sub
    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        about.ShowDialog()
    End Sub
    Private Sub RefreshToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem1.Click
        taskservice()
    End Sub
    Private Sub RestartServiceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RestartServiceToolStripMenuItem.Click
        Try
            For Each item As ListViewItem In servicelist.Items
                If item.Selected AndAlso Label11.Text = "ONLINE" Then
                    Dim serv As New ServiceController(item.SubItems(0).Text, Label8.Text & ".mpos.madm.net")
                    serv.Stop()
                    Sleep(200)
                    serv.Start()
                End If
            Next
            taskservice()
        Catch ed As Exception
            Form7.balon(ed.Message)
        End Try
    End Sub
    Private Sub StartStopServiceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StartStopServiceToolStripMenuItem.Click
        Try
            For Each item As ListViewItem In servicelist.Items
                If item.Selected AndAlso Label11.Text = "ONLINE" Then
                    Dim serv As New ServiceController(item.SubItems(0).Text, Label8.Text & ".mpos.madm.net")
                    If serv.Status = ServiceProcess.ServiceControllerStatus.Running Then
                        serv.Stop()
                    Else
                        serv.Start()
                    End If
                End If
            Next
            taskservice()
        Catch ed As Exception
            Form7.balon(ed.Message)
        End Try
    End Sub
    Private Sub CreateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreateToolStripMenuItem.Click
        Dim ff As String
        ff = "\\" & Label9.Text & "\e$\TpDotnet\cfg\Metro.Mpos.Router.xml"
        If Label11.Text = "ONLINE" Then
            My.Computer.FileSystem.CopyFile("Metro.Mpos.Router.xml", ff, Microsoft.VisualBasic.FileIO.UIOption.AllDialogs, Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)
            My.Computer.FileSystem.WriteAllText(ff, My.Computer.FileSystem.ReadAllText(ff).Replace("XXX", Label9.Text), False)
            My.Computer.FileSystem.WriteAllText(ff, My.Computer.FileSystem.ReadAllText(ff).Replace("YYY", Label7.Text), False)
            System.Diagnostics.Process.Start("Notepad.Exe", ff)
        End If
    End Sub
    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        Dim ff As String
        ff = "\\" & Label9.Text & "\e$\TpDotnet\cfg\Metro.Mpos.Router.xml"
        If Label11.Text = "ONLINE" AndAlso My.Computer.FileSystem.FileExists(ff) Then
            System.Diagnostics.Process.Start("Notepad.Exe", ff)
        Else
            Form7.balon("File not found.")
        End If
    End Sub
    Private Sub NoneToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NoneToolStripMenuItem.Click
        Dim ff As String
        For Each item As ListViewItem In tilllist.Items
            If item.Selected AndAlso Label11.Text = "ONLINE" Then
                ff = "\\" & item.SubItems(5).Text & "\e$\TpDotnet\cfg\Metro.MPOS.PrintProcessor." & Label10.Text & ".xml"
                My.Computer.FileSystem.WriteAllText(ff, My.Computer.FileSystem.ReadAllText(ff).Replace("<PrinterType>" & item.SubItems(7).Text & "</PrinterType>", "<PrinterType>0</PrinterType>"), False)
                Form7.balon("Printer set to none")
            End If
        Next
    End Sub
    Private Sub MatrixToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MatrixToolStripMenuItem.Click
        Dim ff As String
        For Each item As ListViewItem In tilllist.Items
            If item.Selected AndAlso Label11.Text = "ONLINE" Then
                ff = "\\" & item.SubItems(5).Text & "\e$\TpDotnet\cfg\Metro.MPOS.PrintProcessor." & Label10.Text & ".xml"
                My.Computer.FileSystem.WriteAllText(ff, My.Computer.FileSystem.ReadAllText(ff).Replace("<PrinterType>" & item.SubItems(7).Text & "</PrinterType>", "<PrinterType>1</PrinterType>"), False)
                Form7.balon("Printer set to Matrix.")
            End If
        Next
    End Sub
    Private Sub LaserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LaserToolStripMenuItem.Click
        Dim ff As String
        For Each item As ListViewItem In tilllist.Items
            If item.Selected AndAlso Label11.Text = "ONLINE" Then
                ff = "\\" & item.SubItems(5).Text & "\e$\TpDotnet\cfg\Metro.MPOS.PrintProcessor." & Label10.Text & ".xml"
                My.Computer.FileSystem.WriteAllText(ff, My.Computer.FileSystem.ReadAllText(ff).Replace("<PrinterType>" & item.SubItems(7).Text & "</PrinterType>", "<PrinterType>2</PrinterType>"), False)
                Form7.balon("Printer set to Laser.")
            End If
        Next
    End Sub
    Private Sub ContextMenuStrip1_Closing(sender As Object, e As ToolStripDropDownClosingEventArgs) Handles ContextMenuStrip1.Closing
        SetPrinterToolStripMenuItem.Visible = False
        ForceSignOutToolStripMenuItem.Visible = False
        RestartTillToolStripMenuItem.Visible = False
        OpenInSCCMToolStripMenuItem1.Visible = False
    End Sub
    Private Sub ContextMenuStrip1_Opening(sender As Object, e As CancelEventArgs) Handles ContextMenuStrip1.Opening
        Try
            NoneToolStripMenuItem.Checked = False
            MatrixToolStripMenuItem.Checked = False
            LaserToolStripMenuItem.Checked = False
            SetPrinterToolStripMenuItem.Visible = False
            ForceSignOutToolStripMenuItem.Visible = False
            RestartTillToolStripMenuItem.Visible = False
            OpenInSCCMToolStripMenuItem1.Visible = False
            For Each item As ListViewItem In tilllist.Items
                If item.Selected AndAlso Label11.Text = "ONLINE" Then
                    If item.SubItems(5).Text <> "-" AndAlso item.SubItems(6).Text = "ON" Then
                        RestartTillToolStripMenuItem.Visible = True
                        OpenInSCCMToolStripMenuItem1.Visible = True
                    End If
                    If item.SubItems(4).Text <> "-" Then
                        ForceSignOutToolStripMenuItem.Visible = True
                    End If
                    If item.SubItems(7).Text <> "-" Then
                        SetPrinterToolStripMenuItem.Visible = True
                    End If
                    If item.SubItems(7).Text = "0" Then
                        NoneToolStripMenuItem.Checked = True
                        MatrixToolStripMenuItem.Checked = False
                        LaserToolStripMenuItem.Checked = False
                    ElseIf item.SubItems(7).Text = "1" Then
                        NoneToolStripMenuItem.Checked = False
                        MatrixToolStripMenuItem.Checked = True
                        LaserToolStripMenuItem.Checked = False
                    ElseIf item.SubItems(7).Text = "2" Then
                        NoneToolStripMenuItem.Checked = False
                        MatrixToolStripMenuItem.Checked = False
                        LaserToolStripMenuItem.Checked = True
                    End If
                    Exit For
                End If
            Next
        Catch ex As Exception
            Form7.balon(ex.Message)
        End Try
    End Sub
    Private Sub OpenMPOSToolAppToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenMPOSToolAppToolStripMenuItem.Click
        Form7.Hide()
        Me.Show()
        If Me.TopMost = False Then
            Me.TopMost = True
            Me.TopMost = False
        End If
    End Sub
    Private Sub OpenInSCCMToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles OpenInSCCMToolStripMenuItem1.Click
        Try
            For Each item As ListViewItem In tilllist.Items
                If item.Selected = True Then
                    Process.Start("C:\Program Files\Microsoft Configuration Manager\AdminConsole\bin\i386\CmRcViewer.exe", item.SubItems(5).Text)
                    Exit For
                End If
            Next
        Catch ed As Exception
            Form7.balon(ed.Message)
        End Try
    End Sub
    Private Sub ExitMPOSToolAppToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitMPOSToolAppToolStripMenuItem.Click
        x = True
        Me.Close()
    End Sub
    Private Sub OpenInSCCMToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenInSCCMToolStripMenuItem.Click
        Try
            For Each item As ListViewItem In serverlist.Items
                If item.Selected = True Then
                    Process.Start("C:\Program Files\Microsoft Configuration Manager\AdminConsole\bin\i386\CmRcViewer.exe", item.SubItems(2).Text)
                    Exit For
                End If
            Next
        Catch ed As Exception
            Form7.balon(ed.Message)
        End Try
    End Sub
    Private Sub ContextMenuStrip4_Opening(sender As Object, e As CancelEventArgs) Handles ContextMenuStrip4.Opening
        Try
            OpenInSCCMToolStripMenuItem.Visible = False
            For Each item As ListViewItem In serverlist.Items
                If item.Selected = True And item.SubItems.Count > 3 Then
                    If item.SubItems(3).Text = "ON" Then
                        OpenInSCCMToolStripMenuItem.Visible = True
                        Exit For
                    End If
                End If
            Next
        Catch ed As Exception
            Form7.balon(ed.Message)
        End Try
    End Sub
    Private Sub ContextMenuStrip2_Opening(sender As Object, e As CancelEventArgs) Handles ContextMenuStrip2.Opening
        ResetOperatorPassword123ToolStripMenuItem.Visible = False
        For Each item As ListViewItem In operatorlist.Items
            If item.Selected Then
                ResetOperatorPassword123ToolStripMenuItem.Visible = True
                Exit For
            End If
        Next
    End Sub
    Private Sub ContextMenuStrip3_Opening(sender As Object, e As CancelEventArgs) Handles ContextMenuStrip3.Opening
        Try
            RestartServiceToolStripMenuItem.Visible = False
            StartStopServiceToolStripMenuItem.Visible = False
            For Each item As ListViewItem In servicelist.Items
                If item.Selected And Label11.Text = "ONLINE" And item.SubItems.Count > 1 Then
                    If item.SubItems(2).Text <> "-" Then
                        RestartServiceToolStripMenuItem.Visible = True
                        StartStopServiceToolStripMenuItem.Visible = True
                        Exit For
                    End If
                End If
            Next
        Catch ed As Exception
            Form7.balon(ed.Message)
        End Try
    End Sub
    '-----------------------------------------------------------------------------------------------------------------------------------------END menus
    '-----------------------------------------------------------------------------------------------------------------------------------------BEGIN minimize
    Private Sub NotifyIcon1_MouseClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon1.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Left Then
            If Me.Visible Then
                Me.Hide()
                Form7.Show()
            Else
                Form7.Hide()
                Me.Show()
                If Me.TopMost = False Then
                    Me.TopMost = True
                    Me.TopMost = False
                End If
            End If
        End If
    End Sub
    '-----------------------------------------------------------------------------------------------------------------------------------------END minimize
    '-----------------------------------------------------------------------------------------------------------------------------------------BEGIN hover
    Private Sub Button1_MouseHover(sender As Object, e As EventArgs) Handles Button1.MouseHover
        ToolTip1.Show(cnt, Button1)
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Label11.Text = "ONLINE" Then
            Form8.ShowDialog()
        Else
            Form7.balon("Server is Offline ...")
        End If
    End Sub
    Private Sub ContextMenuStrip6_Opening(sender As Object, e As CancelEventArgs) Handles ContextMenuStrip6.Opening
        Dim ff As String
        ff = "\\" & Label9.Text & "\e$\TpDotnet\cfg\Metro.Mpos.Router.xml"
        If Label11.Text = "ONLINE" AndAlso My.Computer.FileSystem.FileExists(ff) Then
            CreateToolStripMenuItem.Text = "Overwrite"
        Else
            CreateToolStripMenuItem.Text = "Create"
        End If
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        x = True
        Me.Close()
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form9.ShowDialog()
    End Sub
    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        ContextMenuStrip6.Show(Cursor.Position)
    End Sub

    Private Sub label8_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles label8.LinkClicked
        My.Computer.Clipboard.SetText(label8.Text)
    End Sub

    Private Sub label9_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles label9.LinkClicked
        My.Computer.Clipboard.SetText(label9.Text)
    End Sub

End Class







