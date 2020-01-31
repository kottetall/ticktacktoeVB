Imports Ticktacktoe.Globals

Public Class Form1
    Function MainLoop(target As PictureBox)

        Dim currentPlayer = players(counter Mod 2)
        Dim nextPlayer = players((counter + 1) Mod 2)
        Dim numberPressedBox As Integer = CInt(target.Name.Replace("PictureBox", ""))


        playerTurn.Text = "'" & nextPlayer & "'s turn"

        'Ändra till relativ filväg
        target.Load("C:\Users\Taike\Documents\Programmering\Visual Basic\Ticktacktoe\Ticktacktoe\Resources\" & currentPlayer & ".png")
        target.Enabled = False


        gameArea(numberPressedBox - 1) = currentPlayer

        If counter > 3 Then
            ' före 5 draget behövs ingen kontroll då det är omöjligt att ha vunnit innan dess
            If Kontroll() = True Then
                Vinst(currentPlayer)
            End If
        End If

        Draw()
        counter += 1

        Return True
    End Function

    Function Draw()
        ' Onödigt med separat kontroll, men har gjort det som övning/repetition
        If counter = 8 Then
            ShowResults("Oavgjort!")
            Return True
        End If

        Return False
    End Function

    Function ShowResults(msg As String)
        resultsDisplay.Text = msg
        resultsDisplay.Visible = True
        playerTurn.Text = ""
        spelyta.Enabled = False

        Return True
    End Function

    Function Vinst(winningPlayer As String)
        ShowResults(winningPlayer & " vann!")
        Return True
    End Function

    Function Kontroll()
        For i = 0 To 2
            ' kontrollerna är separerade för läsbarhet

            ' DIAGONALER
            If i = 0 Then
                If gameArea(i) = gameArea(i + 4) And gameArea(i) = gameArea(i + 8) And
                    gameArea(i) <> "" And gameArea(i + 4) <> "" And gameArea(i + 8) <> "" Then
                    Return True

                ElseIf gameArea(i + 2) = gameArea(i + 4) And gameArea(i + 2) = gameArea(i + 6) And
                    gameArea(i + 2) <> "" And gameArea(i + 4) <> "" And gameArea(i + 6) <> "" Then
                    Return True
                End If
            End If

            ' RADER
            Dim rowNode = i + 2 * i

            If gameArea(rowNode) = gameArea(rowNode + 1) And gameArea(rowNode) = gameArea(rowNode + 2) _
                And gameArea(rowNode) <> "" And gameArea(rowNode + 1) <> "" And gameArea(rowNode + 2) <> "" Then
                Return True

            End If

            ' KOLUMNER
            If gameArea(i) = gameArea(i + 3) And gameArea(i) = gameArea(i + 6) And
                gameArea(i) <> "" And gameArea(i + 3) <> "" And gameArea(i + 6) <> "" Then
                Return True

            End If
        Next i

        Return False
    End Function

    Private Sub ResetBtn_Click(sender As Object, e As EventArgs) Handles resetBtn.Click

        For i As Integer = 0 To UBound(gameArea)
            gameArea(i) = ""
        Next i

        For Each box As PictureBox In boxes
            box.Image = Nothing
            box.Enabled = True
        Next
        resultsDisplay.Visible = False
        playerTurn.Text = Nothing
        spelyta.Enabled = True
        counter = 0

    End Sub

    Private Sub PictureBox_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click, PictureBox2.Click, PictureBox3.Click,
        PictureBox4.Click, PictureBox5.Click, PictureBox6.Click, PictureBox7.Click, PictureBox8.Click, PictureBox9.Click

        MainLoop(sender)
    End Sub
End Class
