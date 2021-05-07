<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.pnlButtons = New System.Windows.Forms.Panel()
        Me.tmrPoll = New System.Windows.Forms.Timer(Me.components)
        Me.lblDebugCOM6 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblCOM4Output = New System.Windows.Forms.Label()
        Me.lblCOM6Input = New System.Windows.Forms.Label()
        Me.Grid1 = New GIP_Logic_Serial.Grid()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlButtons
        '
        Me.pnlButtons.Location = New System.Drawing.Point(12, 13)
        Me.pnlButtons.Name = "pnlButtons"
        Me.pnlButtons.Size = New System.Drawing.Size(484, 57)
        Me.pnlButtons.TabIndex = 3
        '
        'lblDebugCOM6
        '
        Me.lblDebugCOM6.AutoSize = True
        Me.lblDebugCOM6.Location = New System.Drawing.Point(6, 93)
        Me.lblDebugCOM6.Name = "lblDebugCOM6"
        Me.lblDebugCOM6.Size = New System.Drawing.Size(142, 17)
        Me.lblDebugCOM6.TabIndex = 5
        Me.lblDebugCOM6.Text = "COM6 Status: Closed"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 62)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(142, 17)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "COM4 Status: Closed"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblCOM6Input)
        Me.GroupBox1.Controls.Add(Me.lblCOM4Output)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.lblDebugCOM6)
        Me.GroupBox1.Location = New System.Drawing.Point(502, 76)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(298, 149)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Debug"
        '
        'lblCOM4Output
        '
        Me.lblCOM4Output.AutoSize = True
        Me.lblCOM4Output.Location = New System.Drawing.Point(172, 62)
        Me.lblCOM4Output.Name = "lblCOM4Output"
        Me.lblCOM4Output.Size = New System.Drawing.Size(94, 17)
        Me.lblCOM4Output.TabIndex = 6
        Me.lblCOM4Output.Text = "COM4 Output"
        '
        'lblCOM6Input
        '
        Me.lblCOM6Input.AutoSize = True
        Me.lblCOM6Input.Location = New System.Drawing.Point(172, 93)
        Me.lblCOM6Input.Name = "lblCOM6Input"
        Me.lblCOM6Input.Size = New System.Drawing.Size(82, 17)
        Me.lblCOM6Input.TabIndex = 6
        Me.lblCOM6Input.Text = "COM6 Input"
        '
        'Grid1
        '
        Me.Grid1.Location = New System.Drawing.Point(12, 76)
        Me.Grid1.Name = "Grid1"
        Me.Grid1.Size = New System.Drawing.Size(484, 400)
        Me.Grid1.TabIndex = 2
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(811, 457)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.pnlButtons)
        Me.Controls.Add(Me.Grid1)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Grid1 As Grid
    Friend WithEvents pnlButtons As Panel
    Friend WithEvents tmrPoll As Timer
    Friend WithEvents lblDebugCOM6 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblCOM6Input As Label
    Friend WithEvents lblCOM4Output As Label
End Class
