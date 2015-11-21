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
    Public Shared UID As String = "TpAdmin"
    Public Shared PSW As String = "Cawt6__56UBn_szF8_10"
    Public Shared cred1 As String = "Integrated Security=SSPI"
    Public Shared cred2 As String = "Uid=" & UID & "; Password=" & PSW
    Public Shared cred As String '= cred1
    Public Shared svl As String = "serverlist.xml"
    Public Shared ffl As String = "folderlist.xml"
    Public Shared srl As String = "servicelist.xml"
    Public Shared cfl As String = "countlist.xml"
    Public Shared hff As String = "\c$\mgi\mposinstallstate.xml"
    Public Shared x As Boolean = False
    Public Shared w As Boolean = False
    Public Shared printeron As Boolean
    Public Shared qafolder As String
    Public Shared uatfolder As String
    Dim anulareserver As CancellationTokenSource
    Dim anulareservice As CancellationTokenSource
    Dim anularetills As CancellationTokenSource
    Dim anulareoperators As CancellationTokenSource
    Dim cnt As String = ""

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
        Timer1.Interval = 5000
        Timer1.Enabled = True
        Timer1.Start()

        Try
            Dim MyReg As RegistryKey
            Dim MyVal As Object
            MyReg = Registry.LocalMachine.OpenSubKey("SOFTWARE\Policies\Microsoft\System\DNSClient", False)
            If (Not MyReg Is Nothing) Then
                MyVal = MyReg.GetValue("PrimaryDnsSuffix")
            Else
                MyVal = "not_ro"
            End If
            If MyVal = "not_ro" Then
                Form7.balon("XML update not needed!")
            ElseIf MyVal <> "client.ro.r4.madm.net" Then
                Form7.balon("XML update not needed!")
                'XmlVersion("sqllist")
                'XmlVersion("folder")
                'XmlVersion("service")
                'If w = True Then
                '    Form7.balon("New XML files downloaded!")
                'Else
                '    Form7.balon("XML files are up to date!")
                'End If
            Else
                XmlVersion("sqllist")
                XmlVersion("server")
                XmlVersion("folder")
                XmlVersion("service")
                If w = True Then
                    Form7.balon("New XML files downloaded!!!")
                Else
                    Form7.balon("XML files are up to date!!")
                End If
            End If
            MyReg.Close()
        Catch a As Exception
            MsgBox(a.Message)
        End Try

        Me.Show()
        If Me.TopMost = False Then
            Me.TopMost = True
            Me.TopMost = False
        End If
        taskserver()
        cleanshortc("desktop")
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
                                ElseIf readserver.Value = "PROD" Then
                                    serverlist.Items.Item(i).Group = serverlist.Groups(2)
                                ElseIf readserver.Value = "DEV" Then
                                    serverlist.Items.Item(i).Group = serverlist.Groups(3)
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
            Logger.LogInfo(e)
        End Try
    End Sub
    Private Sub readfolderlist(link)
        Dim readfolder As XmlTextReader = New XmlTextReader(ffl)
        Dim i As Integer = 0
        Dim env As String = ""

        If link = "QA" Then
            env = "Path"
        ElseIf link = "UAT" Then
            env = "UATPath"
        ElseIf link = "PROD" Then
            env = "UATPath"
        ElseIf link = "DEV" Then
            env = "Path"
        End If
            Try
                folderlist.Items.Clear()
                Do While (readfolder.Read())
                    Select Case readfolder.NodeType
                        Case XmlNodeType.Element
                            Select Case readfolder.Name
                                Case "Name"
                                    readfolder.Read()
                                    folderlist.Items.Add(readfolder.Value)
                            Case env
                                readfolder.Read()
                                folderlist.Items(i).SubItems.Add("\\" + label9.Text + readfolder.Value)
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
        servicelist.Items.Clear()
        Button1.Visible = True
        Button6.Visible = True
        Button5.Visible = True
        Button7.Visible = True
        viewserver()
        statusserver()
        For Each item As ListViewItem In serverlist.SelectedItems
            If item.Group.Name = "ListViewGroup1" Then
                readfolderlist("QA")
            ElseIf item.Group.Name = "ListViewGroup4" Then
                readfolderlist("DEV")
            Else
                readfolderlist("UAT")
            End If
        Next
        ' Set the initial sorting type for the ListView. 
        Me.tilllist.Sorting = System.Windows.Forms.SortOrder.None
        ' Disable automatic sorting to enable manual sorting. 
        'Me.tilllist.View = View.Details
        'Me.tilllist.ListViewItemSorter = New ListViewItemComparer(0, System.Windows.Forms.SortOrder.Ascending)
        AddHandler tilllist.ColumnClick, AddressOf Me.tilllist_ColumnClick
        ' readfolderlist()
        loaddatabase()
        ' taskservice()
        loadcounts()
    End Sub
    Private Sub statusserver()
        Try
            If My.Computer.Network.Ping(label9.Text) Then
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
                label9.Text = item.SubItems(2).Text
                label8.Text = item.SubItems(1).Text
                Label10.Text = item.SubItems(0).Text
                Try
                    Dim arr As New ArrayList
                    Dim arr1 As New ArrayList
                    Dim conex1 As SqlConnection
                    Dim dat As SqlDataReader
                    Dim dat1 As SqlDataReader
                    Dim cmd As SqlCommand
                    Dim cmd1 As SqlCommand
                    Dim t As Boolean = False
                    conex1 = New SqlConnection("Data Source=" & item.SubItems(2).Text & ";Database=TPCentralDB;" & cred & ";")
                    cmd = conex1.CreateCommand
                    cmd1 = conex1.CreateCommand
                    cmd.CommandText = "select top 1 szDatabaseVersionID from MGIDatabaseVersionUpdate order by szDatabaseInstallDate desc"
                    cmd1.CommandText = "select * from (select top 1 szPackageName from EUSoftwareVersion where szResult = 'Success' and szState = 'Finished' and szPackageName like 'Hotfix%' and szWorkstationID in (select top 10 szworkstationid from workstation order by lWorkstationNmbr desc)order by szTimestamp desc) a union select 'Hotfix_00'where (select COUNT(*) from EUSoftwareVersion where szResult = 'Success' and szState = 'Finished' and szPackageName like 'Hotfix%' and szWorkstationID in (select top 10 szworkstationid from workstation order by lWorkstationNmbr desc))=0"
                    conex1.Open()
                    If conex1.State = ConnectionState.Open Then
                        dat = cmd.ExecuteReader()
                        While dat.Read()
                            arr.Add(dat(0))
                        End While
                        dat.Close()
                        dat1 = cmd1.ExecuteReader()
                        While dat1.Read()
                            arr1.Add(dat1(0))
                        End While
                        dat.Close()
                        conex1.Close()
                        t = True
                    ElseIf conex1.State = ConnectionState.Closed Then
                        Form7.balon("DB Offline")
                    End If
                    Label13.Text = arr(0).ToString + " " + arr1(0).ToString
                Catch a As Exception
                    'Form7.balon(a.Message)
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
                    folderlist.Refresh()
                    Exit For
                ElseIf item.Selected = True AndAlso Not My.Computer.FileSystem.DirectoryExists(item.SubItems(1).Text) Then
                    MsgBox(item.SubItems(1).Text)
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
        Dim con As SqlConnection
        con = New SqlConnection("Data Source=" & label9.Text & ";Database=TPCentralDB;" & cred & ";")
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
        Dim con1 As SqlConnection
        Dim cmd1 As SqlCommand
        Dim dat1 As SqlDataReader
        Try
            con1 = New SqlConnection("Data Source=" & label9.Text & ";Database=TPCentralDB;" & cred & ";")
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

        End Try
    End Sub
    Private Sub loadtills(tokentills As CancellationToken)
        Dim ff As String
        Dim i As Integer = 0
        Dim arr As Array = {"-", "-", "-", "-", "-", "-", "-"}
        Dim con As SqlConnection
        Dim cmd As SqlCommand
        Dim dat As SqlDataReader
        Try
            tilllist.HeaderStyle = ColumnHeaderStyle.None
            con = New SqlConnection("Data Source=" & label9.Text & ";Database=TPCentralDB;" & cred & ";")
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
                If printeron = True Then
                    Try
                        For Each item As ListViewItem In serverlist.SelectedItems
                            If item.Group.Name = "ListViewGroup1" Then
                                ff = "\\" & arr(4) & "\e$\TpDotnet\cfg\Metro.MPOS.PrintProcessor." & Label10.Text & ".xml"
                            Else
                                ff = "\\" & arr(4) & "\TPServer\cfg\Metro.MPOS.PrintProcessor." & Label10.Text & ".xml"
                            End If

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
                        Next
                    Catch
                    End Try
                Else
                    arr(6) = "?"
                End If
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
            tilllist.HeaderStyle = ColumnHeaderStyle.Clickable
        Catch e As Exception
            'Form7.balon(e.Message)
        End Try
        tpb.Visible = False
        tlb.Visible = False
    End Sub
    Private Sub loadcounts()
        Dim readcounts As XmlTextReader = New XmlTextReader(cfl)
        Dim con3 As New SqlConnection("Data Source=" & label9.Text & ";Database=TPCentralDB;" & cred & ";")
        Dim cmd3 As New SqlCommand
        Dim dat3 As SqlDataReader
        cnt = vbTab & vbTab & vbTab & vbTab & vbTab & vbCrLf
        Try
            If Label11.Text = "ONLINE" Then
                con3.Open()
                cmd3 = con3.CreateCommand
                cmd3.CommandText = "select lRetailStoreID from workstation where szWorkstationID='" & label8.Text & "'"
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
                    Dim serv As New ServiceController(item.SubItems(0).Text, label8.Text & ".mpos.madm.net")
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
        ' Dim MyReg As RegistryKey
        ' Dim MyVal As Object
        sss.Visible = True
        For Each item As ListViewItem In serverlist.Items
            tokenserver.ThrowIfCancellationRequested()
            If My.Computer.Network.Ping(item.SubItems(2).Text) Then
                item.ForeColor = Color.Green
                item.SubItems.Add("ON")
                Try
                    Dim arr As New ArrayList
                    Dim arr1 As New ArrayList
                    Dim conex1 As SqlConnection
                    Dim cmd, cmd1 As SqlCommand
                    Dim dat, dat1 As SqlDataReader
                    Dim t As Boolean = False

                    conex1 = New SqlConnection("Data Source=" & item.SubItems(2).Text & ";Database=TPCentralDB;" & cred & ";")
                    cmd = conex1.CreateCommand
                    cmd1 = conex1.CreateCommand
                    cmd.CommandText = "select top 1 szDatabaseVersionID from MGIDatabaseVersionUpdate order by szDatabaseInstallDate desc"
                    cmd1.CommandText = "select * from (select top 1 szPackageName from EUSoftwareVersion where szResult = 'Success' and szState = 'Finished' and szPackageName like 'Hotfix%' and szWorkstationID in (select top 10 szworkstationid from workstation order by lWorkstationNmbr desc)order by szTimestamp desc) a union select 'Hotfix_00'where (select COUNT(*) from EUSoftwareVersion where szResult = 'Success' and szState = 'Finished' and szPackageName like 'Hotfix%' and szWorkstationID in (select top 10 szworkstationid from workstation order by lWorkstationNmbr desc))=0"
                    conex1.Open()
                    If conex1.State = ConnectionState.Open Then
                        dat = cmd.ExecuteReader()
                        While dat.Read()
                            arr.Add(dat(0))
                        End While
                        dat.Close()
                        dat1 = cmd1.ExecuteReader()
                        While dat1.Read()
                            arr1.Add(dat1(0))
                        End While
                        dat.Close()
                        conex1.Close()
                        t = True
                    ElseIf conex1.State = ConnectionState.Closed Then
                        Form7.balon("DB Offline")
                    End If
                    item.SubItems.Add(arr(0).ToString + " " + arr1(0).ToString)
                Catch a As Exception
                    'Form7.balon(a.Message)
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
        Dim con As New SqlConnection("Data Source=" & label9.Text & ";Database=TPCentralDB;" & cred & ";")
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
        Dim con As New SqlConnection("Data Source=" & label9.Text & ";Database=TPCentralDB;" & cred & ";")
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
        Dim result As Integer = MessageBox.Show("Are you sure you want to reboot the till ?", "Reboot till", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            restarttill()
        Else
        End If
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
                    Dim serv As New ServiceController(item.SubItems(0).Text, label8.Text & ".mpos.madm.net")
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
                    Dim serv As New ServiceController(item.SubItems(0).Text, label8.Text & ".mpos.madm.net")
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
        For Each item As ListViewItem In serverlist.SelectedItems
            If item.Group.Name = "ListViewGroup1" Then
                ff = "\\" & label9.Text & "\e$\TpDotnet\cfg\Metro.Mpos.Router.xml"
            Else
                ff = "\\" & label9.Text & "\TPServer\cfg\Metro.Mpos.Router.xml"
            End If
            If Label11.Text = "ONLINE" Then
                My.Computer.FileSystem.CopyFile("Metro.Mpos.Router.xml", ff, Microsoft.VisualBasic.FileIO.UIOption.AllDialogs, Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)
                My.Computer.FileSystem.WriteAllText(ff, My.Computer.FileSystem.ReadAllText(ff).Replace("XXX", label9.Text), False)
                My.Computer.FileSystem.WriteAllText(ff, My.Computer.FileSystem.ReadAllText(ff).Replace("YYY", Label7.Text), False)
                System.Diagnostics.Process.Start("Notepad.Exe", ff)
            End If
        Next
    End Sub
    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        Dim ff As String
        For Each item As ListViewItem In serverlist.SelectedItems
            If item.Group.Name = "ListViewGroup1" Then
                ff = "\\" & label9.Text & "\e$\TpDotnet\cfg\Metro.Mpos.Router.xml"
            Else
                ff = "\\" & label9.Text & "\TPServer\cfg\Metro.Mpos.Router.xml"
            End If
            If Label11.Text = "ONLINE" AndAlso My.Computer.FileSystem.FileExists(ff) Then
                System.Diagnostics.Process.Start("Notepad.Exe", ff)
            Else
                Form7.balon("File not found.")
            End If
        Next
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
                    ElseIf item.SubItems(5).Text <> "-" Then
                        RestartTillToolStripMenuItem.Visible = True
                        OpenInSCCMToolStripMenuItem1.Visible = True
                    End If
                    If item.SubItems(4).Text <> "-" Then
                        ForceSignOutToolStripMenuItem.Visible = True
                    End If
                    If item.SubItems(7).Text = "-" Then
                        SetPrinterToolStripMenuItem.Visible = False
                    ElseIf item.SubItems(7).Text = "?" Then
                        SetPrinterToolStripMenuItem.Visible = False
                    Else
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
        ff = "\\" & label9.Text & "\e$\TpDotnet\cfg\Metro.Mpos.Router.xml"
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
        '   My.Computer.Clipboard.SetText(label9.Text)
        System.Diagnostics.Process.Start("mstsc.exe", "/v " & label9.Text)

    End Sub
    '-----------------------------------------------------------------------------------------------------------
    Public Sub ActualVersion()
        Dim cversion As String = Application.ProductVersion
        Label15.Text = cversion.ToString
        Label1.Text = "MPOS Server Tool V" + cversion.ToString
    End Sub
    Public Sub DeleteOldVersion()
        Dim smallArr As New ArrayList()
        Dim path As String = "oldversion.txt"
        Dim execurrentversion As String = Application.ProductVersion
        If My.Computer.FileSystem.FileExists("oldversion.txt") Then
            Using sr As StreamReader = File.OpenText(path)
                Do While sr.Peek() >= 0
                    smallArr.Add(sr.ReadLine())
                Loop
            End Using
            If execurrentversion > smallArr(0) Then
                If My.Computer.FileSystem.FileExists(Application.StartupPath + "/MPOS Server Tool V" & smallArr(0) + ".exe") Then
                    My.Computer.FileSystem.DeleteFile(Application.StartupPath + "/MPOS Server Tool V" & smallArr(0) + ".exe")
                    My.Computer.FileSystem.DeleteFile("oldversion.txt")
                Else
                    MsgBox("bad bad bad")
                End If
            End If
        End If
    End Sub
    Public Function ResourceExists(location As Uri) As Boolean
        If (Not String.Equals(location.Scheme, Uri.UriSchemeHttp, StringComparison.InvariantCultureIgnoreCase)) And (Not String.Equals(location.Scheme, Uri.UriSchemeHttps, StringComparison.InvariantCultureIgnoreCase)) Then
            Throw New NotSupportedException("URI scheme is not supported")
        End If

        Dim request = Net.WebRequest.Create(location)
        request.Method = "HEAD"

        Try
            Using response = request.GetResponse
                Return DirectCast(response, Net.HttpWebResponse).StatusCode = Net.HttpStatusCode.OK
            End Using
        Catch ex As Net.WebException
            Select Case DirectCast(ex.Response, Net.HttpWebResponse).StatusCode
                Case Net.HttpStatusCode.NotFound
                    Return False
                Case Else
                    Throw
            End Select
        End Try
    End Function
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        DeleteOldVersion()
        Timer1.Stop()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim WbReq As New Net.WebClient
        WbReq.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials
        WbReq.Dispose()

        Dim result As Integer = MessageBox.Show("Updating will close current session. Are you sure you want to continue ?", "MPOS Tool Updater", MessageBoxButtons.YesNo)
        If result = DialogResult.No Then
        ElseIf result = DialogResult.Yes Then
            Dim request As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create("http://my-collaboration.metrogroup-networking.com/personal/r4_razvan_belcea/Shared%20Documents/Update.txt")
            request.Credentials = System.Net.CredentialCache.DefaultCredentials
            Dim response As System.Net.HttpWebResponse = request.GetResponse()
            Dim sr As System.IO.StreamReader = New System.IO.StreamReader(response.GetResponseStream())
            Dim newestversion As String = sr.ReadToEnd()
            Dim currentversion As String = Application.ProductVersion
            Try
                Dim source As New Uri("http://my-collaboration.metrogroup-networking.com/personal/r4_razvan_belcea/Shared%20Documents/MPOS%20Server%20Tool%20v1")
                Dim credentials As System.Net.NetworkCredential = System.Net.CredentialCache.DefaultNetworkCredentials
                My.Computer.Network.DownloadFile(source, Application.StartupPath + "/MPOS Server Tool V" & newestversion + ".exe", credentials, True, 60000I, False)
                If My.Computer.FileSystem.FileExists(Application.StartupPath + "/MPOS Server Tool V" & newestversion + ".exe") Then
                    Dim path As String = "oldversion.txt"

                    If Not File.Exists(path) Then
                        Using sw As StreamWriter = File.CreateText(path)
                            sw.WriteLine(currentversion)
                        End Using
                    End If

                    Form1.x = True
                    Me.Close()
                    System.Threading.Thread.Sleep(3000)
                    Process.Start(Application.StartupPath + "/MPOS Server Tool V" & newestversion + ".exe")
                End If
            Catch ex As Exception
                MsgBox(ex.Message + " Error Downloading update.")
            End Try
            sr.Close()
        End If
    End Sub
    Public Sub XmlVersion(files)

        Dim ttr As String = ""
        Dim link As String = ""

        If files = "server" Then
            ttr = Form1.svl
            link = "\\buk11fsr001\GRP_MSYS_MPOS_DELIVERY\pos\Users\public\serverlist.xml"
            'Dim link As New Uri("http://my-collaboration.metrogroup-networking.com/personal/r4_razvan_belcea/Shared%20Documents/serverlist.xml")
        ElseIf files = "folder" Then
            ttr = Form1.ffl
            link = "\\buk11fsr001\GRP_MSYS_MPOS_DELIVERY\pos\Users\public\folderlist.xml"
            'Dim link As New Uri("http://my-collaboration.metrogroup-networking.com/personal/r4_razvan_belcea/Shared%20Documents/folderlist.xml")
        ElseIf files = "service" Then
            ttr = Form1.srl
            link = "\\buk11fsr001\GRP_MSYS_MPOS_DELIVERY\pos\Users\public\servicelist.xml"
            'Dim link As New Uri("http://my-collaboration.metrogroup-networking.com/personal/r4_razvan_belcea/Shared%20Documents/servicelist.xml")
        ElseIf files = "sqllist" Then
            ttr = "sqllist.xml"
            link = "\\buk11fsr001\GRP_MSYS_MPOS_DELIVERY\pos\Users\public\sqllist.xml"
            'Dim link As New Uri("http://my-collaboration.metrogroup-networking.com/personal/r4_razvan_belcea/Shared%20Documents/sqllist.xml")
        End If

        Dim xmlread As XmlTextReader = New XmlTextReader(ttr)
        Dim myArr As New ArrayList()
        Try
            Do While (xmlread.Read())
                Select Case xmlread.NodeType
                    Case XmlNodeType.Element
                        Select Case xmlread.Name
                            Case "Version"
                                xmlread.Read()
                                myArr.Add(xmlread.Value)
                        End Select
                End Select
            Loop
            xmlread.Close()
            xmlread.Dispose()
        Catch ex As Exception
        End Try

        Dim reader As XmlTextReader = New XmlTextReader(link)
        If My.Computer.FileSystem.FileExists(link) Then
            Do While reader.Read()
                Select Case reader.NodeType
                    Case XmlNodeType.Element
                        Select Case reader.Name
                            Case "Version"
                                reader.Read()
                                myArr.Add(reader.Value)
                        End Select
                End Select
            Loop
        Else
            myArr.Add(xmlread.Value)
            MsgBox("Invalid address at " + link)
        End If
        If myArr(0).ToString < myArr(1).ToString Then
            Dim credentials As System.Net.NetworkCredential = System.Net.CredentialCache.DefaultNetworkCredentials
            Try
                If My.Computer.FileSystem.FileExists(ttr) Then
                    My.Computer.FileSystem.DeleteFile(ttr)
                End If
                My.Computer.Network.DownloadFile(link, _
                                                ttr, _
                                                "", "", False, 500, True)
            Catch ex As Exception
                MsgBox(ex.Message + " Error Downloading update.")
            End Try
            w = True
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        taskservice()
        Button5.Hide()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Form11.ShowDialog()
    End Sub

    Public Sub cleanshortc(path)
        Try
            Dim Directory As String = CreateObject("WScript.Shell").Specialfolders(10)
            If path = "desktop" Then
                Directory = CreateObject("WScript.Shell").Specialfolders(10)
            ElseIf path = "startup" Then
                Directory = CreateObject("WScript.Shell").SpecialFolders("Startup")
            End If
            For Each filename As String In IO.Directory.GetFiles(Directory, "*", IO.SearchOption.AllDirectories)
                If Microsoft.VisualBasic.Right(filename, 4) = ".lnk" Then
                    If InStr(filename, "MPOS Tool") > 1 Then
                        My.Computer.FileSystem.DeleteFile(filename)
                    End If
                End If
            Next
            createshortc(Directory & "\MPOS Tool.lnk", "MPOS")
        Catch ex As Exception
            Form7.balon(ex.Message)
        End Try
    End Sub
    Public Sub createshortc(FileName, Title)
        Try
            Dim shortc As Object = CreateObject("WScript.Shell").CreateShortcut(FileName)
            shortc.TargetPath = Application.ExecutablePath
            shortc.WindowStyle = 1I
            shortc.Description = Title
            shortc.WorkingDirectory = Application.StartupPath
            shortc.IconLocation = Application.ExecutablePath & ", 0"
            shortc.Arguments = String.Empty
            shortc.Save()
        Catch ex As Exception
            Form7.balon(ex.Message)
        End Try
    End Sub

    ' TILL LIST COMPARER
    Dim sortColumn As Integer = -1
    Private Sub tilllist_ColumnClick(sender As Object, e As System.Windows.Forms.ColumnClickEventArgs)

        ' Determine whether the column is the same as the last column clicked.
        If e.Column <> sortColumn Then
            ' Set the sort column to the new column.
            sortColumn = e.Column
            ' Set the sort order to ascending by default.
            tilllist.Sorting = System.Windows.Forms.SortOrder.Ascending
        Else
            ' Determine what the last sort order was and change it.
            If tilllist.Sorting = System.Windows.Forms.SortOrder.Ascending Then
                tilllist.Sorting = System.Windows.Forms.SortOrder.Descending
            Else
                tilllist.Sorting = System.Windows.Forms.SortOrder.Ascending
            End If
        End If
        ' Call the sort method to manually sort.
        tilllist.Sort()
        ' Set the ListViewItemSorter property to a new ListViewItemComparer
        ' object.
        tilllist.ListViewItemSorter = New ListViewItemComparer(e.Column, _
                                                         tilllist.Sorting)
    End Sub

    ' Implements the manual sorting of items by column.
    Class ListViewItemComparer
        Implements IComparer
        Private col As Integer
        Private order As System.Windows.Forms.SortOrder

        Public Sub New()
            col = 0
            order = System.Windows.Forms.SortOrder.Ascending
        End Sub

        Public Sub New(column As Integer, order As System.Windows.Forms.SortOrder)
            col = column
            Me.order = order
        End Sub

        Public Function Compare(x As Object, y As Object) As Integer _
                            Implements System.Collections.IComparer.Compare
            Dim returnVal As Integer = -1
            returnVal = [String].Compare(CType(x,  _
                            ListViewItem).SubItems(col).Text, _
                            CType(y, ListViewItem).SubItems(col).Text)
            ' Determine whether the sort order is descending.
            If order = System.Windows.Forms.SortOrder.Descending Then
                ' Invert the value returned by String.Compare.
                returnVal *= -1
            End If

            Return returnVal
        End Function
    End Class

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        ' Try
        'DiscountExtract.getem()
        '    Catch ex As Exception
        'Reporter.send()
        '      End Try
    End Sub
End Class







