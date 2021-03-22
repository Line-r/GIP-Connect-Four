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

        For intx = x To x + 3
            If intx > Rows Then
                Exit For
            ElseIf Grid(x, intx).Used = True Then
                If Grid(x, intx).BackColor = curColor Then
                    lstItems.Add(Grid(x, intx))
                Else
                    Exit For
                End If
            End If
        Next

        For intx = x To x - 3 Step -1
            If intx < 0 Then
                Exit For
            ElseIf Grid(x, intx).Used = True Then
                If Grid(x, intx).BackColor = curColor Then
                    lstItems.Add(Grid(x, intx))
                Else
                    Exit For
                End If
            End If
        Next

        If lstItems.Count > 3 Then
            Return New CheckData(True, lstItems.ToArray())
        Else
            Return New CheckData(False, lstItems.ToArray())
        End If

    End Function

    Private Function CheckVer(x As Integer, y As Integer) As CheckData
        Dim lstItems As New List(Of PanelBox)
        Dim curColor As Color = Form1.PlayerTurn.Color

        For inty = y To y + 3
            If inty > Columns Then
                Exit For
            ElseIf Grid(x, inty).Used = True Then
                If Grid(x, inty).BackColor = curColor Then
                    lstItems.Add(Grid(x, inty))
                Else
                    Exit For
                End If
            End If
        Next

        For inty = y To y - 3 Step -1
            If inty < 0 Then
                Exit For
            ElseIf Grid(x, inty).Used = True Then
                If Grid(x, inty).BackColor = curColor Then
                    lstItems.Add(Grid(x, inty))
                Else
                    Exit For
                End If
            End If
        Next

        If lstItems.Count > 3 Then
            Return New CheckData(True, lstItems.ToArray())
        Else
            Return New CheckData(False, lstItems.ToArray())
        End If
    End Function

    Private Function CheckDiagR(x As Integer, y As Integer) As CheckData
        Dim lstItems As New List(Of PanelBox)
        Dim curColor As Color = Form1.PlayerTurn.Color

        'x + 1, y - 1

        Dim inty As Integer = y
        Dim intx As Integer = x

        For intx = x To x + 3
            If intx > Columns Or inty < 0 Then
                Exit For
            ElseIf Grid(intx, inty).Used = True Then
                If Grid(intx, inty).BackColor = curColor Then
                    lstItems.Add(Grid(intx, inty))
                Else
                    Exit For
                End If
            End If
            inty -= 1
        Next


        For inty = y To y + 3
            If intx < 0 Or inty > Rows Then
                Exit For
            ElseIf Grid(intx, inty).Used = True Then
                If Grid(intx, inty).BackColor = curColor Then
                    lstItems.Add(Grid(intx, inty))
                Else
                    Exit For
                End If
            End If
            intx += 1
        Next

        If lstItems.Count > 3 Then
            Return New CheckData(True, lstItems.ToArray())
        Else
            Return New CheckData(False, lstItems.ToArray())
        End If
    End Function

    Private Function CheckDiagL(x As Integer, y As Integer) As CheckData
        Dim lstItems As New List(Of PanelBox)
        Dim curColor As Color = Form1.PlayerTurn.Color

        'x + 1, y - 1

        Dim inty As Integer = y
        Dim intx As Integer = x

        For intx = x To x + 3
            If intx > Columns Or inty > Rows Then
                Exit For
            ElseIf Grid(intx, inty).Used = True Then
                If Grid(intx, inty).BackColor = curColor Then
                    lstItems.Add(Grid(intx, inty))
                Else
                    Exit For
                End If
            End If
            inty += 1
        Next


        For inty = y To y - 3 Step -1
            If intx < 0 Or inty < Rows Then
                Exit For
            ElseIf Grid(intx, inty).Used = True Then
                If Grid(intx, inty).BackColor = curColor Then
                    lstItems.Add(Grid(intx, inty))
                Else
                    Exit For
                End If
            End If
            intx += 1
        Next

        If lstItems.Count > 3 Then
            Return New CheckData(True, lstItems.ToArray())
        Else
            Return New CheckData(False, lstItems.ToArray())
        End If
    End Function
End Class
