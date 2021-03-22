Public Class Form1
    Public Players(1) As IPlayer
    Public PlayerTurn As IPlayer
    Dim i As Integer = 0

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SerialPort1.Open()
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
        NextTurn()
    End Sub
End Class
