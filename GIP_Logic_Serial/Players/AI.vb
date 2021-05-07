Imports System.IO.Ports
Public Class AI
    Implements IPlayer
    Dim Comms As New IO.Ports.SerialPort("COM4")

    Public Sub New(Clr As Color)
        Name = "AI"
        Color = Clr
    End Sub
    Private _name As String
    Private _color As Color
    Public Property Name As String Implements IPlayer.Name
        Get
            Return _name
        End Get
        Set(value As String)
            _name = value
        End Set
    End Property
    Public Property Color As Color Implements IPlayer.Color
        Get
            Return _color
        End Get
        Set(value As System.Drawing.Color)
            _color = value
        End Set
    End Property
    Public Function DoTurn(x As Integer) As Boolean Implements IPlayer.DoTurn




        Randomize()
        Dim rnd As New Random()
        Dim random As Integer = rnd.Next(0, Form1.Grid1.Columns)

        Do Until (ColumnCheck(random) = True)
            random = rnd.Next(0, Form1.Grid1.Columns)
        Loop

        Return True

    End Function

    Private Function ColumnCheck(x As Integer) As Boolean
        Dim Pass As Byte = x
        Comms = New System.IO.Ports.SerialPort
        Comms.Encoding = System.Text.ASCIIEncoding.Default
        Comms.Handshake = IO.Ports.Handshake.None
        Comms.BaudRate = 9600
        Comms.DataBits = 8
        Comms.Parity = IO.Ports.Parity.None
        Comms.StopBits = IO.Ports.StopBits.One
        Comms.PortName = "COM4"
        Comms.ReceivedBytesThreshold = 1
        If Comms.IsOpen = False Then
            Comms.Open()
            Form1.lblDebugCOM6.Text = "COM4 Status: Open"
        End If

        Comms.Write(Pass)
        Form1.lblCOM4Output.Text = "Sent: " + CStr(Pass)
        Comms.Close()
        Form1.lblDebugCOM6.Text = "COM4 Status: Closed"
        Return Form1.Grid1.AddItemAtColumn(x, Color)

    End Function



End Class
