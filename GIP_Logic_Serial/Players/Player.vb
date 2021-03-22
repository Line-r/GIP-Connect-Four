Public Class Player
    Implements IPlayer
    Public Sub New(strName As String, Clr As Color)
        Name = strName
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

    Public Property Color As System.Drawing.Color Implements IPlayer.Color
        Get
            Return _color
        End Get
        Set(value As System.Drawing.Color)
            _color = value
        End Set
    End Property

    Public Function DoTurn(x As Integer) As Boolean Implements IPlayer.DoTurn
        Return Form1.Grid1.AddItemAtColumn(x, Color)
    End Function
End Class
