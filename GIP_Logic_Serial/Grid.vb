Public Class Grid
    Public Grid(6, 5) As PanelBox
    Public Columns As Integer = 6
    Public Rows As Integer = 5

    Public LastTurn As New Point

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Init()
    End Sub

    Private Sub Init()
        For x As Integer = 0 To Columns
            For y As Integer = 0 To Rows
                Grid(x, y) = New PanelBox With {
                    .Size = New Size(50, 50),
                    .Location = New Point((x * 50), (y * 50))
                }
                Me.Controls.Add(Grid(x, y))
            Next
        Next

    End Sub

    Public Function AddItemAtColumn(x As Integer, color As Color) As Boolean
        For y As Integer = Rows To 0 Step -1
            If (Grid(x, y).Used = False) Then
                Grid(x, y).Used = True
                Grid(x, y).BackColor = color
                LastTurn = New Point(x, y)
                Return True
            End If

        Next
        Return False
    End Function

    Public Function Checkboard(x As Integer, y As Integer) As CheckData
        Dim GameOver As Boolean
        Dim Items As New List(Of PanelBox)()

        Dim Hor As CheckData = CheckHor(x, y)
        Dim Ver As CheckData = CheckVer(x, y)
        Dim DiagR As CheckData = CheckDiagR(x, y)
        Dim DiagL As CheckData = CheckDiagL(x, y)

        If Hor.Connected = True Then
            GameOver = True
            Items.AddRange(CheckHor(x, y).Items)
        End If

        If Ver.Connected = True Then
            GameOver = True
            Items.AddRange(CheckVer(x, y).Items)
        End If

        If DiagR.Connected = True Then
            GameOver = True
            Items.AddRange(CheckDiagR(x, y).Items)
        End If

        If DiagL.Connected = True Then
            GameOver = True
            Items.AddRange(CheckDiagL(x, y).Items)
        End If

        Return New CheckData(GameOver, Items.ToArray)
    End Function

    Private Function CheckHor(x As Integer, y As Integer) As CheckData
        Dim lstItems As New List(Of PanelBox)
        Dim curColor As Color = Form1.PlayerTurn.Color
        Dim lstAImoves As New List(Of PanelBox)

        lstItems.Add(Grid(x, y))

        For intX = x + 1 To Columns - 1
            If (intX > Columns - 1) Then
                Exit For
            Else
                If (Grid(intX, y).Used = True) Then
                    If (Grid(intX, y).BackColor = curColor) Then
                        lstItems.Add(Grid(intX, y))
                    Else
                            Exit For
                    End If
                Else
                    Exit For
                End If
            End If
        Next

        For intX = x - 1 To 0 Step -1
            If (intX < 0) Then
                Exit For
            Else
                If (Grid(intX, y).Used = True) Then
                    If (Grid(intX, y).BackColor = curColor) Then
                        lstItems.Add(Grid(intX, y))
                    Else
                        Exit For
                    End If
                Else
                    Exit For
                End If
            End If
        Next

        If (lstItems.Count > 3) Then
            Return New CheckData(True, lstItems.ToArray())
        Else
            Return New CheckData(False, lstItems.ToArray())
        End If

    End Function

    Private Function CheckVer(x As Integer, y As Integer) As CheckData
        Dim lstItems As New List(Of PanelBox)
        Dim curColor As Color = Form1.PlayerTurn.Color

        lstItems.Add(Grid(x, y))

        For intY = y + 1 To Columns - 1
            If (intY > Rows - 1) Then
                Exit For
            Else
                If (Grid(x, intY).Used = True) Then
                    If (Grid(x, intY).BackColor = curColor) Then
                        lstItems.Add(Grid(x, intY))
                    Else
                        Exit For
                    End If
                Else
                    Exit For
                End If
            End If
        Next

        For intY = y - 1 To 0 Step -1
            If (intY < 0) Then
                Exit For
            Else
                If (Grid(x, intY).Used = True) Then
                    If (Grid(x, intY).BackColor = curColor) Then
                        lstItems.Add(Grid(x, intY))
                    Else
                        Exit For
                    End If
                Else
                    Exit For
                End If
            End If
        Next

        If (lstItems.Count > 3) Then
            Return New CheckData(True, lstItems.ToArray())
        Else
            Return New CheckData(False, lstItems.ToArray())
        End If

    End Function

    Private Function CheckDiagR(x As Integer, y As Integer) As CheckData
        Dim lstItems As New List(Of PanelBox)
        Dim curColor As Color = Form1.PlayerTurn.Color

        'x + 1, y - 1

        lstItems.Add(Grid(x, y))

        ' x + 1 | y - 1
        Dim intY As Integer = y + 1
        For intX = x + 1 To Columns - 1
            If (intX > Columns - 1 Or intY > Rows - 1) Then
                Exit For
            Else
                If (Grid(intX, intY).Used = True) Then
                    If (Grid(intX, intY).BackColor = curColor) Then
                        lstItems.Add(Grid(intX, intY))
                    Else
                        Exit For
                    End If
                Else
                    Exit For
                End If
            End If
            intY += 1
        Next


        Dim intX1 As Integer = x - 1
        For intY = y - 1 To 0 Step -1
            If (intX1 < 0 Or intY < 0) Then
                Exit For
            Else
                If (Grid(intX1, intY).Used = True) Then
                    If (Grid(intX1, intY).BackColor = curColor) Then
                        lstItems.Add(Grid(intX1, intY))
                    Else
                        Exit For
                    End If
                Else
                    Exit For
                End If
            End If
            intX1 -= 1
        Next

        If (lstItems.Count > 3) Then
            Return New CheckData(True, lstItems.ToArray())
        Else
            Return New CheckData(False, lstItems.ToArray())
        End If
    End Function

    Private Function CheckDiagL(x As Integer, y As Integer) As CheckData
        Dim lstItems As New List(Of PanelBox)
        Dim curColor As Color = Form1.PlayerTurn.Color

        'x + 1, y - 1

        Dim intY As Integer = y - 1
        For intX = x + 1 To Columns - 1
            If (intX > Columns - 1 Or intY < 0) Then
                Exit For
            Else
                If (Grid(intX, intY).Used = True) Then
                    If (Grid(intX, intY).BackColor = curColor) Then
                        lstItems.Add(Grid(intX, intY))
                    Else
                        Exit For
                    End If
                Else
                    Exit For
                End If
            End If
            intY -= 1
        Next

        Dim intX1 As Integer = x - 1
        For intY = y + 1 To Rows - 1
            If (intX1 < 0 Or intY > Rows - 1) Then
                Exit For
            Else
                If (Grid(intX1, intY).Used = True) Then
                    If (Grid(intX1, intY).BackColor = curColor) Then
                        lstItems.Add(Grid(intX1, intY))
                    Else
                        Exit For
                    End If
                Else
                    Exit For
                End If
            End If
            intX1 -= 1
        Next

        If (lstItems.Count > 3) Then
            Return New CheckData(True, lstItems.ToArray())
        Else
            Return New CheckData(False, lstItems.ToArray())
        End If
    End Function
End Class
