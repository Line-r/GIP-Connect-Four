Public Class Login
    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        Dim Player1 As IPlayer
        Dim Player2 As IPlayer
        Dim strPlayer1 As String = txtPlayername.Text

        Player1 = New Player(strPlayer1, Color.Red)
        Player2 = New AI(Color.Yellow)

        Me.Hide()
        Dim frm As New Form1
        Form1.Players(0) = Player1
        Form1.Players(1) = Player2
        Form1.Show()

    End Sub
End Class