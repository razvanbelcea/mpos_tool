<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form8
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form8))
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Column6 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.artlist = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cuslist = New System.Windows.Forms.ListView()
        Me.Spec = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.sqls = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.DataGridViewImageColumn1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.AliceBlue
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.DataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.DataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column6, Me.Column1, Me.Column5, Me.Column2, Me.Column3, Me.Column4, Me.Column7})
        Me.DataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DataGridView1.GridColor = System.Drawing.SystemColors.ButtonFace
        Me.DataGridView1.Location = New System.Drawing.Point(355, 23)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.DataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DataGridView1.RowTemplate.Height = 25
        Me.DataGridView1.RowTemplate.ReadOnly = True
        Me.DataGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.ShowRowErrors = False
        Me.DataGridView1.Size = New System.Drawing.Size(657, 377)
        Me.DataGridView1.TabIndex = 2
        '
        'Column6
        '
        Me.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column6.FalseValue = "0"
        Me.Column6.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Column6.HeaderText = ""
        Me.Column6.Name = "Column6"
        Me.Column6.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column6.TrueValue = "1"
        Me.Column6.Width = 19
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column1.HeaderText = "ART id"
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 65
        '
        'Column5
        '
        Me.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column5.HeaderText = "Barcode"
        Me.Column5.Name = "Column5"
        Me.Column5.Width = 72
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column2.HeaderText = "Type"
        Me.Column2.Name = "Column2"
        Me.Column2.Width = 56
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column3.HeaderText = "Store"
        Me.Column3.Name = "Column3"
        Me.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Column3.Width = 57
        '
        'Column4
        '
        Me.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column4.HeaderText = "Country"
        Me.Column4.Name = "Column4"
        Me.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Column4.Width = 68
        '
        'Column7
        '
        Me.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column7.FillWeight = 10.0!
        Me.Column7.HeaderText = "Scan"
        Me.Column7.Image = Global.MPOS.My.Resources.Resources.att1
        Me.Column7.Name = "Column7"
        Me.Column7.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Column7.Width = 38
        '
        'artlist
        '
        Me.artlist.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.artlist.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.artlist.CheckBoxes = True
        Me.artlist.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.artlist.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.artlist.FullRowSelect = True
        Me.artlist.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.artlist.LabelWrap = False
        Me.artlist.Location = New System.Drawing.Point(6, 89)
        Me.artlist.MultiSelect = False
        Me.artlist.Name = "artlist"
        Me.artlist.ShowGroups = False
        Me.artlist.ShowItemToolTips = True
        Me.artlist.Size = New System.Drawing.Size(153, 235)
        Me.artlist.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.artlist.TabIndex = 0
        Me.artlist.UseCompatibleStateImageBehavior = False
        Me.artlist.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Width = 150
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Width = 0
        '
        'cuslist
        '
        Me.cuslist.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.cuslist.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.cuslist.CheckBoxes = True
        Me.cuslist.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Spec, Me.sqls})
        Me.cuslist.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cuslist.FullRowSelect = True
        Me.cuslist.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.cuslist.LabelWrap = False
        Me.cuslist.Location = New System.Drawing.Point(165, 89)
        Me.cuslist.MultiSelect = False
        Me.cuslist.Name = "cuslist"
        Me.cuslist.ShowGroups = False
        Me.cuslist.ShowItemToolTips = True
        Me.cuslist.Size = New System.Drawing.Size(153, 235)
        Me.cuslist.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.cuslist.TabIndex = 1
        Me.cuslist.TileSize = New System.Drawing.Size(2, 2)
        Me.cuslist.UseCompatibleStateImageBehavior = False
        Me.cuslist.View = System.Windows.Forms.View.Details
        '
        'Spec
        '
        Me.Spec.Width = 150
        '
        'sqls
        '
        Me.sqls.Width = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.cuslist)
        Me.GroupBox1.Controls.Add(Me.artlist)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 23)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(327, 344)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Select queries"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(165, 42)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(153, 28)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "Generate Customers"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(6, 42)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(153, 28)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Generate Articles"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(177, 373)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(162, 27)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Print Selected"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'DataGridViewImageColumn1
        '
        Me.DataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewImageColumn1.FillWeight = 10.0!
        Me.DataGridViewImageColumn1.HeaderText = "Scan"
        Me.DataGridViewImageColumn1.Image = Global.MPOS.My.Resources.Resources.att1
        Me.DataGridViewImageColumn1.Name = "DataGridViewImageColumn1"
        Me.DataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(12, 373)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(159, 27)
        Me.Button4.TabIndex = 4
        Me.Button4.Text = "Check COD TX"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Form8
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1024, 413)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Button2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form8"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SQL Query"
        Me.TopMost = True
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents artlist As System.Windows.Forms.ListView
    Friend WithEvents cuslist As System.Windows.Forms.ListView
    Friend WithEvents Spec As System.Windows.Forms.ColumnHeader
    Friend WithEvents sqls As System.Windows.Forms.ColumnHeader
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Public WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents DataGridViewImageColumn1 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
End Class
