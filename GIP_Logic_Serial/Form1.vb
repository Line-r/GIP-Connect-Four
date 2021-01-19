Public Class Form1
    Dim Spelbord(6, 5) As String
    Dim Turn As Boolean = False

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SerialPort1.Open()
    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        Turn = True
        Do While Turn = True
            Dim Incoming As String = SerialPort1.ReadLine
            Dim IncomingInfoArray() As String = Split(Incoming, ",")
            Dim xPos As Integer = CInt(IncomingInfoArray(0))
            Dim yPos As Integer = CInt(IncomingInfoArray(1))
            Dim Color As String = CStr(IncomingInfoArray(2))

            Spelbord(xPos, yPos) = Color


            'Rows vvvvvvvvvvvvvvvvv
            For k = 0 To 5 'Moves up through rows
                Dim Row As String = ""
                Dim yAmount As Integer = 0
                Dim rAmount As Integer = 0

                For i = 0 To 6 'Read a single row



                    Row &= Spelbord(i, k) 'Put row into string
                    'Sum up occurrences of yellow and red pieces in string
                    yAmount = Row.Split("y").Length - 1
                    rAmount = Row.Split("r").Length - 1

                    If yAmount = 3 Then 'If the amount of yellow pieces = 3
                        Dim yIndex As Integer
                        Dim yLastIndex As Integer

                        yIndex = Row.IndexOf("y") 'First occurrence of yellow piece
                        yLastIndex = Row.LastIndexOf("y") 'Last occurrence

                        If Spelbord(yIndex - 1, k) = 0 Then 'Check if the spot before the first occurrence isn't used yet
                            Spelbord(yIndex - 1, k) = "r"
                            Turn = False

                        ElseIf Spelbord(yLastIndex + 1, k) = 0 Then 'In case it is, put piece behind the last occurence (Might still overlap)
                            Spelbord(yLastIndex + 1, k) = "r"
                            Turn = False


                        End If


                    End If

                Next
            Next

            'Columns vvvvvvvvvvvvvvvvvvvv
            For k = 0 To 6
                Dim Column As String = ""
                Dim yAmount As Integer = 0
                Dim rAmount As Integer = 0

                For i = 0 To 5 'Read Column



                    Column &= Spelbord(k, i)
                    yAmount = Column.Split("y").Length - 1
                    rAmount = Column.Split("r").Length - 1

                    If yAmount = 3 Then 'If the amount of yellow pieces = 3
                        Dim yIndex As Integer
                        Dim yLastIndex As Integer

                        yIndex = Column.IndexOf("y") 'First occurrence of yellow piece
                        yLastIndex = Column.LastIndexOf("y") 'Last occurrence

                        If Spelbord(yIndex - 1, k) = 0 Then 'Check if the spot before the first occurrence isn't used yet
                            Spelbord(yIndex - 1, k) = "r"
                            Turn = False

                        Else 'In case it is, put piece behind the last occurence (Might still overlap)
                            Spelbord(yLastIndex + 1, k) = "r"
                            Turn = False

                        End If




                    End If

                Next
            Next

            If Turn = True Then
                'Reverse -> Read bottom to top
                Array.Reverse(Spelbord)

                For k = 0 To 5 'Moves up through rows
                    Dim Row As String = ""
                    Dim yAmount As Integer = 0
                    Dim rAmount As Integer = 0

                    For i = 0 To 6 'Read a single row


                        Row &= Spelbord(i, k) 'Put row into string

                        If Spelbord(i, k) = "" Then
                            Spelbord(i, k) = "r"
                        End If

                    Next
                Next

                Array.Reverse(Spelbord)
            End If


        Loop


    End Sub


End Class
