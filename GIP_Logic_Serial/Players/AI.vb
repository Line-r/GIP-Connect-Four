Public Class AI
    Implements IPlayer

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
        Return Form1.Grid1.AddItemAtColumn(x, Color)
    End Function
End Class
