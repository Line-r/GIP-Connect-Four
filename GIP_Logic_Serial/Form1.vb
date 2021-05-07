Public Class Form1
    Public Players(1) As IPlayer
    Public PlayerTurn As IPlayer
    Dim i As Integer = 0

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PlayerTurn = Players(i)

        'Create drop buttons
        For i As Integer = 0 To Grid1.Columns
            Dim btn As New Button With {
                .Text = "Drop",
                .Size = New Size(50, 50),
                .Location = New Point(i * 50, 0),
                .Tag = i
            }

            AddHandler btn.Click, AddressOf BtnClick
            pnlButtons.Controls.Add(btn)
        Next

    End Sub

    Sub BtnClick(sender As Object, e As EventArgs)
        Dim ClickedButton As Button = CType(sender, Button)
        Dim ClickedColumn As Integer = ClickedButton.Tag
        Dim returnStr As String = ""

        Dim Comms As New IO.Ports.SerialPort("COM6")
        'Serialread code here

        Comms = New System.IO.Ports.SerialPort
        Comms.Encoding = System.Text.ASCIIEncoding.Default
        Comms.Handshake = IO.Ports.Handshake.None
        Comms.BaudRate = 9600
        Comms.DataBits = 8
        Comms.Parity = IO.Ports.Parity.None
        Comms.StopBits = IO.Ports.StopBits.One
        Comms.PortName = "COM6"
        Comms.ReceivedBytesThreshold = 1
        If Comms.IsOpen = False Then
            Comms.Open()
            lblDebugCOM6.Text = "COM6 Status: Open"
        End If


        Dim incoming As String = Comms.ReadLine()
        lblCOM6Input.Text = "Recieved: " + incoming
        If incoming IsNot Nothing Then
            Comms.Close()
            lblDebugCOM6.Text = "COM6 Status: Closed"
        End If



        DoTurn(ClickedColumn)
    End Sub


    Public Sub NextTurn()
        If i = 0 Then 'Long but it'll do
            i = 1
        Else
            i = 0
        End If
        PlayerTurn = Players(i)

        If PlayerTurn.Name = "AI" Then
            DoTurn(0)

        End If
    End Sub
    Public Sub DoTurn(x As Integer)
        If PlayerTurn.DoTurn(x) = False Then
            Return
        End If
        Dim data As CheckData = Grid1.Checkboard(Grid1.LastTurn.X, Grid1.LastTurn.Y)
        If data.Connected = True Then
            PlayerWin(data)
        Else
            NextTurn()
        End If

    End Sub

    Private Sub PlayerWin(data As CheckData)
        ColorItems(data.Items)
        MessageBox.Show(String.Format("{0} Won", PlayerTurn.Name))

    End Sub

    Private Sub ColorItems(items() As PanelBox)
        Dim tempbln As Boolean = True


        For i = 0 To 15
            For Each item As PanelBox In items
                item.BackColor = Color.Blue
            Next
        Next

    End Sub
End Class
