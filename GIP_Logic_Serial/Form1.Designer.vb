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
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.pnlButtons = New System.Windows.Forms.Panel()
        Me.Grid1 = New GIP_Logic_Serial.Grid()
        Me.tmrPoll = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'SerialPort1
        '
        Me.SerialPort1.PortName = "COM3"
        '
        'pnlButtons
        '
        Me.pnlButtons.Location = New System.Drawing.Point(12, 13)
        Me.pnlButtons.Name = "pnlButtons"
        Me.pnlButtons.Size = New System.Drawing.Size(484, 57)
        Me.pnlButtons.TabIndex = 3
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
        Me.ClientSize = New System.Drawing.Size(487, 481)
        Me.Controls.Add(Me.pnlButtons)
        Me.Controls.Add(Me.Grid1)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SerialPort1 As IO.Ports.SerialPort
    Friend WithEvents Grid1 As Grid
    Friend WithEvents pnlButtons As Panel
    Friend WithEvents tmrPoll As Timer
End Class
