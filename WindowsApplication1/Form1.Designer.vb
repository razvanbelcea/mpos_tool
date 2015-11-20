<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("")
        Dim ListViewItem2 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("")
        Dim ListViewItem3 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("")
        Dim ListViewItem4 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("")
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Dim ListViewGroup1 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("QA", System.Windows.Forms.HorizontalAlignment.Center)
        Dim ListViewGroup2 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("UAT", System.Windows.Forms.HorizontalAlignment.Center)
        Dim ListViewGroup3 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("PROD", System.Windows.Forms.HorizontalAlignment.Center)
        Dim ListViewGroup4 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("DEV", System.Windows.Forms.HorizontalAlignment.Center)
        Me.status = New System.Windows.Forms.GroupBox()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.label9 = New System.Windows.Forms.LinkLabel()
        Me.label8 = New System.Windows.Forms.LinkLabel()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ccd = New System.Windows.Forms.ProgressBar()
        Me.servicelist = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ContextMenuStrip3 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RestartServiceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StartStopServiceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RefreshToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.folders = New System.Windows.Forms.GroupBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.folderlist = New System.Windows.Forms.ListView()
        Me.Folder = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Path = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.UATPath = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ContextMenuStrip6 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditRouterxmlToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CreateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RefreshFolderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.title = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tills = New System.Windows.Forms.GroupBox()
        Me.tlb = New System.Windows.Forms.Label()
        Me.tpb = New System.Windows.Forms.ProgressBar()
        Me.tilllist = New System.Windows.Forms.ListView()
        Me.nr = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Tillname = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.tillno = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Tilltype = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Signon = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TillIP = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Tillstatus = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.printertype = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.OpenInSCCMToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.RestartTillToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ForceSignOutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SetPrinterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NoneToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MatrixToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LaserToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RefreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.serverlist = New System.Windows.Forms.ListView()
        Me.country = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.servername = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ip = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.statuss = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.vers = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ContextMenuStrip4 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.OpenInSCCMToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RefreshStatusToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStrip5 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.operators = New System.Windows.Forms.GroupBox()
        Me.operatorlist = New System.Windows.Forms.ListView()
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ResetOperatorPassword123ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RefreshToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ContextMenuStrip7 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.OpenMPOSToolAppToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitMPOSToolAppToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.sss = New System.Windows.Forms.Label()
        Me.ToolTip2 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.metro = New System.Windows.Forms.PictureBox()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.status.SuspendLayout()
        Me.ContextMenuStrip3.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.folders.SuspendLayout()
        Me.ContextMenuStrip6.SuspendLayout()
        Me.title.SuspendLayout()
        Me.tills.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.ContextMenuStrip4.SuspendLayout()
        Me.ContextMenuStrip5.SuspendLayout()
        Me.operators.SuspendLayout()
        Me.ContextMenuStrip2.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.ContextMenuStrip7.SuspendLayout()
        CType(Me.metro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'status
        '
        Me.status.BackColor = System.Drawing.SystemColors.Control
        Me.status.Controls.Add(Me.Button5)
        Me.status.Controls.Add(Me.label9)
        Me.status.Controls.Add(Me.label8)
        Me.status.Controls.Add(Me.Label13)
        Me.status.Controls.Add(Me.Label14)
        Me.status.Controls.Add(Me.Label7)
        Me.status.Controls.Add(Me.Label29)
        Me.status.Controls.Add(Me.Label6)
        Me.status.Controls.Add(Me.ccd)
        Me.status.Controls.Add(Me.servicelist)
        Me.status.Controls.Add(Me.Label11)
        Me.status.Controls.Add(Me.Label10)
        Me.status.Controls.Add(Me.Label5)
        Me.status.Controls.Add(Me.Label4)
        Me.status.Controls.Add(Me.Label3)
        Me.status.Controls.Add(Me.PictureBox2)
        Me.status.Controls.Add(Me.PictureBox1)
        Me.status.Controls.Add(Me.Label12)
        Me.status.Controls.Add(Me.PictureBox3)
        Me.status.Controls.Add(Me.PictureBox4)
        Me.status.Cursor = System.Windows.Forms.Cursors.Default
        Me.status.Location = New System.Drawing.Point(493, 12)
        Me.status.Name = "status"
        Me.status.Size = New System.Drawing.Size(447, 294)
        Me.status.TabIndex = 4
        Me.status.TabStop = False
        Me.status.Text = "Server/Services Status"
        Me.status.Visible = False
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.Transparent
        Me.Button5.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button5.FlatAppearance.BorderSize = 0
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Location = New System.Drawing.Point(9, 153)
        Me.Button5.Margin = New System.Windows.Forms.Padding(1)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(428, 125)
        Me.Button5.TabIndex = 32
        Me.Button5.Text = "Get Services"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'label9
        '
        Me.label9.AutoSize = True
        Me.label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label9.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.label9.LinkColor = System.Drawing.Color.Black
        Me.label9.Location = New System.Drawing.Point(91, 41)
        Me.label9.Name = "label9"
        Me.label9.Size = New System.Drawing.Size(19, 15)
        Me.label9.TabIndex = 31
        Me.label9.TabStop = True
        Me.label9.Text = "..."
        Me.ToolTip2.SetToolTip(Me.label9, "Send to clipboard ...")
        '
        'label8
        '
        Me.label8.AutoSize = True
        Me.label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label8.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.label8.LinkColor = System.Drawing.Color.Black
        Me.label8.Location = New System.Drawing.Point(91, 26)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(19, 15)
        Me.label8.TabIndex = 30
        Me.label8.TabStop = True
        Me.label8.Text = "..."
        Me.ToolTip2.SetToolTip(Me.label8, "Send to clipboard ...")
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(93, 89)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(17, 16)
        Me.Label13.TabIndex = 29
        Me.Label13.Text = "..."
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(20, 89)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(60, 16)
        Me.Label14.TabIndex = 28
        Me.Label14.Text = "Version :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(93, 73)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(17, 16)
        Me.Label7.TabIndex = 27
        Me.Label7.Text = "..."
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(20, 73)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(46, 16)
        Me.Label29.TabIndex = 26
        Me.Label29.Text = "Store :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(327, 250)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(103, 13)
        Me.Label6.TabIndex = 25
        Me.Label6.Text = "Checking services ..."
        Me.Label6.Visible = False
        '
        'ccd
        '
        Me.ccd.Location = New System.Drawing.Point(184, 266)
        Me.ccd.MarqueeAnimationSpeed = 10
        Me.ccd.Name = "ccd"
        Me.ccd.Size = New System.Drawing.Size(246, 10)
        Me.ccd.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.ccd.TabIndex = 23
        Me.ccd.Visible = False
        '
        'servicelist
        '
        Me.servicelist.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.servicelist.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.servicelist.ContextMenuStrip = Me.ContextMenuStrip3
        Me.servicelist.Cursor = System.Windows.Forms.Cursors.Hand
        Me.servicelist.FullRowSelect = True
        Me.servicelist.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1, ListViewItem2, ListViewItem3, ListViewItem4})
        Me.servicelist.Location = New System.Drawing.Point(6, 129)
        Me.servicelist.MultiSelect = False
        Me.servicelist.Name = "servicelist"
        Me.servicelist.Size = New System.Drawing.Size(434, 153)
        Me.servicelist.TabIndex = 12
        Me.servicelist.TileSize = New System.Drawing.Size(64, 64)
        Me.servicelist.UseCompatibleStateImageBehavior = False
        Me.servicelist.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Service"
        Me.ColumnHeader1.Width = 173
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Service Name"
        Me.ColumnHeader2.Width = 182
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Status"
        Me.ColumnHeader3.Width = 61
        '
        'ContextMenuStrip3
        '
        Me.ContextMenuStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RestartServiceToolStripMenuItem, Me.StartStopServiceToolStripMenuItem, Me.RefreshToolStripMenuItem1})
        Me.ContextMenuStrip3.Name = "ContextMenuStrip3"
        Me.ContextMenuStrip3.Size = New System.Drawing.Size(168, 70)
        '
        'RestartServiceToolStripMenuItem
        '
        Me.RestartServiceToolStripMenuItem.Name = "RestartServiceToolStripMenuItem"
        Me.RestartServiceToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.RestartServiceToolStripMenuItem.Text = "Restart Service"
        Me.RestartServiceToolStripMenuItem.Visible = False
        '
        'StartStopServiceToolStripMenuItem
        '
        Me.StartStopServiceToolStripMenuItem.Name = "StartStopServiceToolStripMenuItem"
        Me.StartStopServiceToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.StartStopServiceToolStripMenuItem.Text = "Start/Stop Service"
        Me.StartStopServiceToolStripMenuItem.Visible = False
        '
        'RefreshToolStripMenuItem1
        '
        Me.RefreshToolStripMenuItem1.Name = "RefreshToolStripMenuItem1"
        Me.RefreshToolStripMenuItem1.Size = New System.Drawing.Size(167, 22)
        Me.RefreshToolStripMenuItem1.Text = "Refresh Services"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Red
        Me.Label11.Location = New System.Drawing.Point(291, 36)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(95, 25)
        Me.Label11.TabIndex = 9
        Me.Label11.Text = "OFFLINE"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(93, 57)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(17, 16)
        Me.Label10.TabIndex = 4
        Me.Label10.Text = "..."
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(20, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 16)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Name :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(20, 41)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(26, 16)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "IP :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(20, 57)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Country :"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(392, 33)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(34, 35)
        Me.PictureBox2.TabIndex = 10
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(392, 33)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(34, 35)
        Me.PictureBox1.TabIndex = 8
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.Color.Red
        Me.Label12.Location = New System.Drawing.Point(295, 73)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(55, 13)
        Me.Label12.TabIndex = 20
        Me.Label12.Text = "DB is OFF"
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(398, 68)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(20, 20)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 21
        Me.PictureBox3.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(398, 68)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(20, 20)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox4.TabIndex = 13
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'folders
        '
        Me.folders.Controls.Add(Me.LinkLabel1)
        Me.folders.Controls.Add(Me.folderlist)
        Me.folders.Location = New System.Drawing.Point(946, 12)
        Me.folders.Name = "folders"
        Me.folders.Size = New System.Drawing.Size(153, 294)
        Me.folders.TabIndex = 8
        Me.folders.TabStop = False
        Me.folders.Text = "Folders/Files"
        Me.folders.Visible = False
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(5, 269)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(121, 13)
        Me.LinkLabel1.TabIndex = 1
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Metro.MPOS.Router.xml"
        '
        'folderlist
        '
        Me.folderlist.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.folderlist.AutoArrange = False
        Me.folderlist.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.folderlist.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.folderlist.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Folder, Me.Path, Me.UATPath})
        Me.folderlist.ContextMenuStrip = Me.ContextMenuStrip6
        Me.folderlist.Cursor = System.Windows.Forms.Cursors.Hand
        Me.folderlist.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.folderlist.ForeColor = System.Drawing.Color.Blue
        Me.folderlist.FullRowSelect = True
        Me.folderlist.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.folderlist.HideSelection = False
        Me.folderlist.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.folderlist.LabelWrap = False
        Me.folderlist.Location = New System.Drawing.Point(8, 21)
        Me.folderlist.MultiSelect = False
        Me.folderlist.Name = "folderlist"
        Me.folderlist.Scrollable = False
        Me.folderlist.ShowGroups = False
        Me.folderlist.Size = New System.Drawing.Size(137, 242)
        Me.folderlist.TabIndex = 0
        Me.folderlist.TileSize = New System.Drawing.Size(120, 30)
        Me.folderlist.UseCompatibleStateImageBehavior = False
        Me.folderlist.View = System.Windows.Forms.View.SmallIcon
        '
        'Folder
        '
        Me.Folder.Text = "Folder"
        Me.Folder.Width = 100
        '
        'Path
        '
        Me.Path.Text = "Path"
        '
        'UATPath
        '
        Me.UATPath.Text = "UATPath"
        '
        'ContextMenuStrip6
        '
        Me.ContextMenuStrip6.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditRouterxmlToolStripMenuItem, Me.RefreshFolderToolStripMenuItem})
        Me.ContextMenuStrip6.Name = "ContextMenuStrip6"
        Me.ContextMenuStrip6.Size = New System.Drawing.Size(150, 48)
        '
        'EditRouterxmlToolStripMenuItem
        '
        Me.EditRouterxmlToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditToolStripMenuItem, Me.CreateToolStripMenuItem})
        Me.EditRouterxmlToolStripMenuItem.Name = "EditRouterxmlToolStripMenuItem"
        Me.EditRouterxmlToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.EditRouterxmlToolStripMenuItem.Text = "Router.xml"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'CreateToolStripMenuItem
        '
        Me.CreateToolStripMenuItem.Name = "CreateToolStripMenuItem"
        Me.CreateToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.CreateToolStripMenuItem.Text = "Create/Overwrite"
        '
        'RefreshFolderToolStripMenuItem
        '
        Me.RefreshFolderToolStripMenuItem.Name = "RefreshFolderToolStripMenuItem"
        Me.RefreshFolderToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.RefreshFolderToolStripMenuItem.Text = "Refresh Folder"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label1.Location = New System.Drawing.Point(72, 98)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(320, 31)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "MPOS Server Tool v1.0"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'title
        '
        Me.title.Controls.Add(Me.Label2)
        Me.title.Controls.Add(Me.Label1)
        Me.title.Location = New System.Drawing.Point(575, 113)
        Me.title.Name = "title"
        Me.title.Size = New System.Drawing.Size(456, 289)
        Me.title.TabIndex = 9
        Me.title.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.Label2.Location = New System.Drawing.Point(178, 146)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(206, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Select MPOS Server from the list !"
        '
        'tills
        '
        Me.tills.Controls.Add(Me.tlb)
        Me.tills.Controls.Add(Me.tpb)
        Me.tills.Controls.Add(Me.tilllist)
        Me.tills.Location = New System.Drawing.Point(493, 312)
        Me.tills.Name = "tills"
        Me.tills.Size = New System.Drawing.Size(447, 209)
        Me.tills.TabIndex = 10
        Me.tills.TabStop = False
        Me.tills.Text = "Tills"
        Me.tills.Visible = False
        '
        'tlb
        '
        Me.tlb.AutoSize = True
        Me.tlb.BackColor = System.Drawing.Color.White
        Me.tlb.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tlb.Location = New System.Drawing.Point(356, 169)
        Me.tlb.Name = "tlb"
        Me.tlb.Size = New System.Drawing.Size(74, 13)
        Me.tlb.TabIndex = 27
        Me.tlb.Text = "Loading tills ..."
        '
        'tpb
        '
        Me.tpb.Location = New System.Drawing.Point(184, 185)
        Me.tpb.MarqueeAnimationSpeed = 10
        Me.tpb.Name = "tpb"
        Me.tpb.Size = New System.Drawing.Size(246, 10)
        Me.tpb.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.tpb.TabIndex = 26
        '
        'tilllist
        '
        Me.tilllist.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.nr, Me.Tillname, Me.tillno, Me.Tilltype, Me.Signon, Me.TillIP, Me.Tillstatus, Me.printertype})
        Me.tilllist.ContextMenuStrip = Me.ContextMenuStrip1
        Me.tilllist.Cursor = System.Windows.Forms.Cursors.Hand
        Me.tilllist.FullRowSelect = True
        Me.tilllist.Location = New System.Drawing.Point(7, 21)
        Me.tilllist.MultiSelect = False
        Me.tilllist.Name = "tilllist"
        Me.tilllist.ShowGroups = False
        Me.tilllist.Size = New System.Drawing.Size(434, 179)
        Me.tilllist.TabIndex = 0
        Me.tilllist.UseCompatibleStateImageBehavior = False
        Me.tilllist.View = System.Windows.Forms.View.Details
        '
        'nr
        '
        Me.nr.Width = 0
        '
        'Tillname
        '
        Me.Tillname.Text = "Till Name"
        Me.Tillname.Width = 120
        '
        'tillno
        '
        Me.tillno.Text = "No."
        Me.tillno.Width = 40
        '
        'Tilltype
        '
        Me.Tilltype.Text = "Till Type"
        '
        'Signon
        '
        Me.Signon.Text = "Op."
        Me.Signon.Width = 30
        '
        'TillIP
        '
        Me.TillIP.Text = "Till IP"
        Me.TillIP.Width = 90
        '
        'Tillstatus
        '
        Me.Tillstatus.Text = "Status"
        Me.Tillstatus.Width = 35
        '
        'printertype
        '
        Me.printertype.Text = "Printer"
        Me.printertype.Width = 50
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenInSCCMToolStripMenuItem1, Me.RestartTillToolStripMenuItem, Me.ForceSignOutToolStripMenuItem, Me.SetPrinterToolStripMenuItem, Me.RefreshToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(153, 114)
        '
        'OpenInSCCMToolStripMenuItem1
        '
        Me.OpenInSCCMToolStripMenuItem1.Name = "OpenInSCCMToolStripMenuItem1"
        Me.OpenInSCCMToolStripMenuItem1.Size = New System.Drawing.Size(152, 22)
        Me.OpenInSCCMToolStripMenuItem1.Text = "Open in SCCM"
        Me.OpenInSCCMToolStripMenuItem1.Visible = False
        '
        'RestartTillToolStripMenuItem
        '
        Me.RestartTillToolStripMenuItem.Name = "RestartTillToolStripMenuItem"
        Me.RestartTillToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.RestartTillToolStripMenuItem.Text = "Restart Till"
        Me.RestartTillToolStripMenuItem.Visible = False
        '
        'ForceSignOutToolStripMenuItem
        '
        Me.ForceSignOutToolStripMenuItem.Name = "ForceSignOutToolStripMenuItem"
        Me.ForceSignOutToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ForceSignOutToolStripMenuItem.Text = "Force SignOff"
        Me.ForceSignOutToolStripMenuItem.Visible = False
        '
        'SetPrinterToolStripMenuItem
        '
        Me.SetPrinterToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NoneToolStripMenuItem, Me.MatrixToolStripMenuItem, Me.LaserToolStripMenuItem})
        Me.SetPrinterToolStripMenuItem.Name = "SetPrinterToolStripMenuItem"
        Me.SetPrinterToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.SetPrinterToolStripMenuItem.Text = "Set Printer"
        Me.SetPrinterToolStripMenuItem.Visible = False
        '
        'NoneToolStripMenuItem
        '
        Me.NoneToolStripMenuItem.Name = "NoneToolStripMenuItem"
        Me.NoneToolStripMenuItem.Size = New System.Drawing.Size(122, 22)
        Me.NoneToolStripMenuItem.Text = "0 : None"
        '
        'MatrixToolStripMenuItem
        '
        Me.MatrixToolStripMenuItem.Name = "MatrixToolStripMenuItem"
        Me.MatrixToolStripMenuItem.Size = New System.Drawing.Size(122, 22)
        Me.MatrixToolStripMenuItem.Text = "1 : Matrix"
        '
        'LaserToolStripMenuItem
        '
        Me.LaserToolStripMenuItem.Name = "LaserToolStripMenuItem"
        Me.LaserToolStripMenuItem.Size = New System.Drawing.Size(122, 22)
        Me.LaserToolStripMenuItem.Text = "2 : Laser"
        '
        'RefreshToolStripMenuItem
        '
        Me.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem"
        Me.RefreshToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.RefreshToolStripMenuItem.Text = "Refresh DB"
        '
        'serverlist
        '
        Me.serverlist.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.serverlist.AutoArrange = False
        Me.serverlist.BackColor = System.Drawing.Color.White
        Me.serverlist.BackgroundImageTiled = True
        Me.serverlist.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.country, Me.servername, Me.ip, Me.statuss, Me.vers})
        Me.serverlist.ContextMenuStrip = Me.ContextMenuStrip4
        Me.serverlist.Cursor = System.Windows.Forms.Cursors.Hand
        Me.serverlist.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.serverlist.FullRowSelect = True
        Me.serverlist.GridLines = True
        ListViewGroup1.Header = "QA"
        ListViewGroup1.HeaderAlignment = System.Windows.Forms.HorizontalAlignment.Center
        ListViewGroup1.Name = "ListViewGroup1"
        ListViewGroup2.Header = "UAT"
        ListViewGroup2.HeaderAlignment = System.Windows.Forms.HorizontalAlignment.Center
        ListViewGroup2.Name = "ListViewGroup2"
        ListViewGroup3.Header = "PROD"
        ListViewGroup3.HeaderAlignment = System.Windows.Forms.HorizontalAlignment.Center
        ListViewGroup3.Name = "ListViewGroup3"
        ListViewGroup4.Header = "DEV"
        ListViewGroup4.HeaderAlignment = System.Windows.Forms.HorizontalAlignment.Center
        ListViewGroup4.Name = "ListViewGroup4"
        Me.serverlist.Groups.AddRange(New System.Windows.Forms.ListViewGroup() {ListViewGroup1, ListViewGroup2, ListViewGroup3, ListViewGroup4})
        Me.serverlist.HideSelection = False
        Me.serverlist.LabelWrap = False
        Me.serverlist.Location = New System.Drawing.Point(12, 12)
        Me.serverlist.MultiSelect = False
        Me.serverlist.Name = "serverlist"
        Me.serverlist.Size = New System.Drawing.Size(465, 509)
        Me.serverlist.TabIndex = 0
        Me.serverlist.TileSize = New System.Drawing.Size(100, 100)
        Me.serverlist.UseCompatibleStateImageBehavior = False
        Me.serverlist.View = System.Windows.Forms.View.Details
        '
        'country
        '
        Me.country.Text = "Country"
        Me.country.Width = 77
        '
        'servername
        '
        Me.servername.Text = "Server Name"
        Me.servername.Width = 109
        '
        'ip
        '
        Me.ip.Text = "IP"
        Me.ip.Width = 74
        '
        'statuss
        '
        Me.statuss.Text = "Status"
        Me.statuss.Width = 42
        '
        'vers
        '
        Me.vers.Text = "Version"
        Me.vers.Width = 120
        '
        'ContextMenuStrip4
        '
        Me.ContextMenuStrip4.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenInSCCMToolStripMenuItem, Me.RefreshStatusToolStripMenuItem})
        Me.ContextMenuStrip4.Name = "ContextMenuStrip4"
        Me.ContextMenuStrip4.Size = New System.Drawing.Size(154, 48)
        '
        'OpenInSCCMToolStripMenuItem
        '
        Me.OpenInSCCMToolStripMenuItem.Name = "OpenInSCCMToolStripMenuItem"
        Me.OpenInSCCMToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.OpenInSCCMToolStripMenuItem.Text = "Open in SCCM"
        Me.OpenInSCCMToolStripMenuItem.Visible = False
        '
        'RefreshStatusToolStripMenuItem
        '
        Me.RefreshStatusToolStripMenuItem.Name = "RefreshStatusToolStripMenuItem"
        Me.RefreshStatusToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.RefreshStatusToolStripMenuItem.Text = "Refresh Servers"
        '
        'ContextMenuStrip5
        '
        Me.ContextMenuStrip5.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem})
        Me.ContextMenuStrip5.Name = "ContextMenuStrip5"
        Me.ContextMenuStrip5.Size = New System.Drawing.Size(108, 26)
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'operators
        '
        Me.operators.Controls.Add(Me.operatorlist)
        Me.operators.Location = New System.Drawing.Point(946, 312)
        Me.operators.Name = "operators"
        Me.operators.Size = New System.Drawing.Size(153, 209)
        Me.operators.TabIndex = 11
        Me.operators.TabStop = False
        Me.operators.Text = "Operators"
        Me.operators.Visible = False
        '
        'operatorlist
        '
        Me.operatorlist.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader5, Me.ColumnHeader6})
        Me.operatorlist.ContextMenuStrip = Me.ContextMenuStrip2
        Me.operatorlist.Cursor = System.Windows.Forms.Cursors.Hand
        Me.operatorlist.FullRowSelect = True
        Me.operatorlist.Location = New System.Drawing.Point(9, 21)
        Me.operatorlist.Name = "operatorlist"
        Me.operatorlist.Size = New System.Drawing.Size(137, 179)
        Me.operatorlist.TabIndex = 1
        Me.operatorlist.UseCompatibleStateImageBehavior = False
        Me.operatorlist.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Op."
        Me.ColumnHeader5.Width = 30
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Profile"
        Me.ColumnHeader6.Width = 75
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ResetOperatorPassword123ToolStripMenuItem, Me.RefreshToolStripMenuItem2})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip2"
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(183, 48)
        '
        'ResetOperatorPassword123ToolStripMenuItem
        '
        Me.ResetOperatorPassword123ToolStripMenuItem.Name = "ResetOperatorPassword123ToolStripMenuItem"
        Me.ResetOperatorPassword123ToolStripMenuItem.Size = New System.Drawing.Size(182, 22)
        Me.ResetOperatorPassword123ToolStripMenuItem.Text = "Reset Password : 123"
        Me.ResetOperatorPassword123ToolStripMenuItem.Visible = False
        '
        'RefreshToolStripMenuItem2
        '
        Me.RefreshToolStripMenuItem2.Name = "RefreshToolStripMenuItem2"
        Me.RefreshToolStripMenuItem2.Size = New System.Drawing.Size(182, 22)
        Me.RefreshToolStripMenuItem2.Text = "Refresh DB"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripProgressBar1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 563)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1113, 36)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 24
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripProgressBar1
        '
        Me.ToolStripProgressBar1.AutoSize = False
        Me.ToolStripProgressBar1.Margin = New System.Windows.Forms.Padding(11, 20, 1, 3)
        Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        Me.ToolStripProgressBar1.Size = New System.Drawing.Size(300, 13)
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.ContextMenuStrip = Me.ContextMenuStrip7
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "MPOS Server Tool Application"
        Me.NotifyIcon1.Visible = True
        '
        'ContextMenuStrip7
        '
        Me.ContextMenuStrip7.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenMPOSToolAppToolStripMenuItem, Me.ExitMPOSToolAppToolStripMenuItem})
        Me.ContextMenuStrip7.Name = "ContextMenuStrip7"
        Me.ContextMenuStrip7.Size = New System.Drawing.Size(125, 48)
        '
        'OpenMPOSToolAppToolStripMenuItem
        '
        Me.OpenMPOSToolAppToolStripMenuItem.Name = "OpenMPOSToolAppToolStripMenuItem"
        Me.OpenMPOSToolAppToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.OpenMPOSToolAppToolStripMenuItem.Text = "Maximize"
        '
        'ExitMPOSToolAppToolStripMenuItem
        '
        Me.ExitMPOSToolAppToolStripMenuItem.Name = "ExitMPOSToolAppToolStripMenuItem"
        Me.ExitMPOSToolAppToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.ExitMPOSToolAppToolStripMenuItem.Text = "Exit"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 527)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(153, 29)
        Me.Button1.TabIndex = 18
        Me.Button1.Text = "DB Queries"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'ToolTip1
        '
        Me.ToolTip1.AutoPopDelay = 5000
        Me.ToolTip1.InitialDelay = 300
        Me.ToolTip1.ReshowDelay = 100
        Me.ToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTip1.ToolTipTitle = "Bootstrap Info"
        '
        'Button3
        '
        Me.Button3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Location = New System.Drawing.Point(946, 570)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(60, 26)
        Me.Button3.TabIndex = 19
        Me.Button3.Text = "Settings"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Button4.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.OrangeRed
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Button4.Location = New System.Drawing.Point(1012, 570)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(87, 26)
        Me.Button4.TabIndex = 26
        Me.Button4.Text = "EXIT"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'sss
        '
        Me.sss.AutoSize = True
        Me.sss.BackColor = System.Drawing.Color.Transparent
        Me.sss.Location = New System.Drawing.Point(18, 568)
        Me.sss.Name = "sss"
        Me.sss.Size = New System.Drawing.Size(77, 13)
        Me.sss.TabIndex = 27
        Me.sss.Text = "Ping servers ..."
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(864, 577)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(45, 13)
        Me.Label15.TabIndex = 28
        Me.Label15.Text = "Label15"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(820, 577)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(45, 13)
        Me.Label16.TabIndex = 29
        Me.Label16.Text = "Version:"
        '
        'Timer1
        '
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.SystemColors.Control
        Me.Button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.Red
        Me.Button2.Location = New System.Drawing.Point(819, 570)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(121, 26)
        Me.Button2.TabIndex = 30
        Me.Button2.Text = "Update Available"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(168, 527)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(153, 29)
        Me.Button6.TabIndex = 18
        Me.Button6.Text = "Barcode Generator"
        Me.Button6.UseVisualStyleBackColor = True
        Me.Button6.Visible = False
        '
        'metro
        '
        Me.metro.BackgroundImage = CType(resources.GetObject("metro.BackgroundImage"), System.Drawing.Image)
        Me.metro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.metro.ContextMenuStrip = Me.ContextMenuStrip5
        Me.metro.Location = New System.Drawing.Point(828, 408)
        Me.metro.Name = "metro"
        Me.metro.Size = New System.Drawing.Size(203, 20)
        Me.metro.TabIndex = 3
        Me.metro.TabStop = False
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(324, 527)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(153, 29)
        Me.Button7.TabIndex = 31
        Me.Button7.Text = "Barcode Generator"
        Me.Button7.UseVisualStyleBackColor = True
        Me.Button7.Visible = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1113, 599)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.sss)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.operators)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.serverlist)
        Me.Controls.Add(Me.folders)
        Me.Controls.Add(Me.tills)
        Me.Controls.Add(Me.status)
        Me.Controls.Add(Me.title)
        Me.Controls.Add(Me.metro)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MPOS Server Tool"
        Me.status.ResumeLayout(False)
        Me.status.PerformLayout()
        Me.ContextMenuStrip3.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.folders.ResumeLayout(False)
        Me.folders.PerformLayout()
        Me.ContextMenuStrip6.ResumeLayout(False)
        Me.title.ResumeLayout(False)
        Me.title.PerformLayout()
        Me.tills.ResumeLayout(False)
        Me.tills.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ContextMenuStrip4.ResumeLayout(False)
        Me.ContextMenuStrip5.ResumeLayout(False)
        Me.operators.ResumeLayout(False)
        Me.ContextMenuStrip2.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ContextMenuStrip7.ResumeLayout(False)
        CType(Me.metro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents status As System.Windows.Forms.GroupBox
    Friend WithEvents metro As System.Windows.Forms.PictureBox
    Friend WithEvents folders As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents title As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tills As System.Windows.Forms.GroupBox
    Friend WithEvents serverlist As System.Windows.Forms.ListView
    Friend WithEvents servername As System.Windows.Forms.ColumnHeader
    Friend WithEvents statuss As System.Windows.Forms.ColumnHeader
    Friend WithEvents ip As System.Windows.Forms.ColumnHeader
    Friend WithEvents country As System.Windows.Forms.ColumnHeader
    Friend WithEvents folderlist As System.Windows.Forms.ListView
    Friend WithEvents Folder As System.Windows.Forms.ColumnHeader
    Friend WithEvents Path As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tilllist As System.Windows.Forms.ListView
    Friend WithEvents Tillname As System.Windows.Forms.ColumnHeader
    Friend WithEvents TillIP As System.Windows.Forms.ColumnHeader
    Friend WithEvents Tilltype As System.Windows.Forms.ColumnHeader
    Friend WithEvents Signon As System.Windows.Forms.ColumnHeader
    Friend WithEvents Tillstatus As System.Windows.Forms.ColumnHeader
    Friend WithEvents printertype As System.Windows.Forms.ColumnHeader
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents operators As System.Windows.Forms.GroupBox
    Friend WithEvents servicelist As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents tillno As System.Windows.Forms.ColumnHeader
    Friend WithEvents operatorlist As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ccd As System.Windows.Forms.ProgressBar
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripProgressBar1 As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents RestartTillToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ForceSignOutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RefreshToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuStrip2 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ResetOperatorPassword123ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuStrip3 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents RestartServiceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StartStopServiceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RefreshToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SetPrinterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NoneToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MatrixToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LaserToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RefreshToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuStrip4 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents RefreshStatusToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuStrip5 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuStrip6 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EditRouterxmlToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RefreshFolderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents CreateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents ContextMenuStrip7 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents OpenMPOSToolAppToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitMPOSToolAppToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents vers As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents OpenInSCCMToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenInSCCMToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents nr As System.Windows.Forms.ColumnHeader
    Friend WithEvents tlb As System.Windows.Forms.Label
    Friend WithEvents tpb As System.Windows.Forms.ProgressBar
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents sss As System.Windows.Forms.Label
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents ToolTip2 As System.Windows.Forms.ToolTip
    Friend WithEvents label8 As System.Windows.Forms.LinkLabel
    Friend WithEvents label9 As System.Windows.Forms.LinkLabel
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents UATPath As System.Windows.Forms.ColumnHeader
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
End Class
