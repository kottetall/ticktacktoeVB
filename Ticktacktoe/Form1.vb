Imports System.Text.RegularExpressions
Public Class Form1


    Dim counter = 0
    Function ChangeImg(target As PictureBox)
        'Dim type As String
        Dim player = "x"

        If counter Mod 2 = 0 Then
            player = "o"
        End If

        target.Load("C:\Users\Taike\Documents\Programmering\Visual Basic\Ticktacktoe\Ticktacktoe\Resources\" & player & ".png")

        resultsOutput.Text = counter

        If counter > 0 Then
            'If counter > 4 Then
            ' före 5 draget behövs ingen kontroll då det är omöjligt att ha vunnit innan dess
            kontroll()
        End If
        draw()
        counter = counter + 1

        Return True

    End Function

    Function draw()
        ' Onödigt med separat kontroll, men har gjort det som övning/repetition
        If counter = 9 Then
            resultsOutput.Text = "Oavgjort!"
            Return True
        End If

        Return False
    End Function

    Function kontroll()
        'Funktion för att kontrollera ifall någon vunnit
        Dim spelplan(8) As String

        spelplan(0) = PictureBox1.ImageLocation
        spelplan(1) = PictureBox2.ImageLocation
        spelplan(2) = PictureBox3.ImageLocation
        spelplan(3) = PictureBox4.ImageLocation
        spelplan(4) = PictureBox5.ImageLocation
        spelplan(5) = PictureBox6.ImageLocation
        spelplan(6) = PictureBox7.ImageLocation
        spelplan(7) = PictureBox8.ImageLocation
        spelplan(8) = PictureBox9.ImageLocation

        Dim test As MatchCollection = Regex.Matches(spelplan(0), "o.png")






        ' funkar ej med x
        resultsOutput.Text = test(0).ToString

        Return False
    End Function


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        ' FÖR TESTER

    End Sub

    Private Sub PictureBox_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click, PictureBox2.Click, PictureBox3.Click, PictureBox4.Click, PictureBox5.Click, PictureBox6.Click, PictureBox7.Click, PictureBox8.Click, PictureBox9.Click

        ChangeImg(sender)
    End Sub

End Class
