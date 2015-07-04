<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class About

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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.sk = New System.Windows.Forms.NumericUpDown()
        CType(Me.sk, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(133, 228)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(269, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Copyright @ Gabriel Stanciu and Razvan Belcea"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Font = New System.Drawing.Font("Arial", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(-61, 100)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0)
        Me.Label2.Name = "Label2"
        Me.Label2.Padding = New System.Windows.Forms.Padding(20)
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label2.Size = New System.Drawing.Size(399, 64)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "MPOS Server Tool v1.0"
        '
        'Timer1
        '
        Me.Timer1.Interval = 7
        '
        'sk
        '
        Me.sk.Location = New System.Drawing.Point(27, 31)
        Me.sk.Maximum = New Decimal(New Integer() {9000, 0, 0, 0})
        Me.sk.Name = "sk"
        Me.sk.Size = New System.Drawing.Size(50, 20)
        Me.sk.TabIndex = 3
        Me.sk.Visible = False
        '
        'About
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Green
        Me.ClientSize = New System.Drawing.Size(414, 276)
        Me.Controls.Add(Me.sk)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "About"
        Me.Opacity = 0.0R
        Me.Padding = New System.Windows.Forms.Padding(9)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "About"
        CType(Me.sk, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer

    Friend WithEvents sk As System.Windows.Forms.NumericUpDown


    Private Sub About_Click(sender As Object, e As EventArgs) Handles Me.Click
        Me.Dispose()
    End Sub


    Private Sub About_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Me.Dispose()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Me.Dispose()
    End Sub



    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        sk.Value = sk.Value + 1
        If sk.Text < 100 Then
            Me.Opacity = Me.Opacity + 0.01
        ElseIf sk.Value >= 100 And sk.Value < 200 Then
        ElseIf sk.Value >= 200 And sk.Value < 300 Then
            Me.Opacity = Me.Opacity - 0.01
        Else
            Me.Dispose()
        End If
    End Sub

End Class
