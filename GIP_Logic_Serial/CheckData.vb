Public Class CheckData
    Public Sub New(conn As Boolean, i() As PanelBox)
        Connected = conn
        Items = i.ToArray
    End Sub
    Public Property Connected As Boolean

    Public Items() As PanelBox
End Class
