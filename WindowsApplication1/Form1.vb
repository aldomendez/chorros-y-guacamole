
Imports System.Text
Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form2.Show()
        Me.Hide()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gbl.tcpStart()
        ipShow.Text = gbl.getTelnetStatus() & " from " & gbl.IPaddress
    End Sub

    Private Sub Form1_MouseEnter(sender As Object, e As EventArgs) Handles Me.MouseEnter
        ipShow.Text = gbl.getTelnetStatus() & " to " & gbl.IPaddress
    End Sub

    Private Sub telnetMessage(msg As String)

        Dim SendBuffer(128) As Byte
        Dim ReadBuffer(256) As Byte
        Dim ReturnVal As String
        Dim ReturnLength As Integer
        Try
            If gbl.getTelnetStatus() = True Then
                SendBuffer = Encoding.ASCII.GetBytes(msg)
                gbl.ThisStream.Write(SendBuffer, 0, SendBuffer.Length)

                'ReturnVal = Encoding.ASCII.GetString(ReadBuffer)
                ReturnLength = gbl.ThisStream.Read(ReadBuffer, 0, ReadBuffer.Length)
                ReturnVal = Encoding.ASCII.GetString(ReadBuffer, 0, ReturnLength)
                telnetAns.Text = ReturnVal & vbCrLf & telnetAns.Text
            Else
                MsgBox("Conection closed, you must have to click the Connect Button")
            End If

        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub btnStartConnection_Click(sender As Object, e As EventArgs) Handles btnStartConnection.Click
        btnStartConnection.Text = "Connecting..."
        If gbl.getTelnetStatus() = False Then
            gbl.connect()
        Else
            gbl.disconect()
        End If
    End Sub

    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        ipShow.Text = "shown: " & gbl.getTelnetStatus() & " from " & gbl.IPaddress
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        telnetMessage("W1")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        telnetMessage("W2")
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        telnetMessage("W3")
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        telnetMessage("W4")
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        telnetMessage("W5")
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        telnetMessage("W6")
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        If gbl.valvX <= 8 Then
            gbl.valvX = gbl.valvX + 1
            ProgressBar1.Value = gbl.valvX
            telnetMessage("X" & gbl.valvX)
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If gbl.valvX >= 1 Then
            gbl.valvX = gbl.valvX - 1
            ProgressBar1.Value = gbl.valvX
            telnetMessage("X" & gbl.valvX)
        End If
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        If gbl.valvY <= 8 Then
            gbl.valvY = gbl.valvY + 1
            ProgressBar2.Value = gbl.valvY
            telnetMessage("Y" & gbl.valvY)
        End If
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        If gbl.valvY >= 1 Then
            gbl.valvY = gbl.valvY - 1
            ProgressBar2.Value = gbl.valvY
            telnetMessage("Y" & gbl.valvY)
        End If
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        If gbl.valvZ <= 8 Then
            gbl.valvZ = gbl.valvZ + 1
            ProgressBar3.Value = gbl.valvZ
            telnetMessage("Z" & gbl.valvZ)
        End If
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        If gbl.valvZ >= 1 Then
            gbl.valvZ = gbl.valvZ - 1
            ProgressBar3.Value = gbl.valvZ
            telnetMessage("Z" & gbl.valvZ)
        End If
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        telnetMessage("W7")
    End Sub

    Private Sub Button15_MouseDown(sender As Object, e As MouseEventArgs) Handles Button15.MouseDown
        adelante()
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        adelante()
    End Sub
    Sub adelante()
        If gbl.getTelnetStatus() = True Then
            telnetMessage("A1")
        End If
    End Sub
    Private Sub Button15_MouseUp(sender As Object, e As MouseEventArgs) Handles Button15.MouseUp
        Timer1.Stop()
    End Sub
    Sub derecha()
        If gbl.getTelnetStatus() = True Then
            telnetMessage("A2")
        End If
    End Sub
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        derecha()
    End Sub

    Private Sub Button18_MouseDown(sender As Object, e As MouseEventArgs) Handles Button18.MouseDown
        derecha()
        Timer2.Start()
    End Sub

    Private Sub Button18_MouseUp(sender As Object, e As MouseEventArgs) Handles Button18.MouseUp
        Timer2.Stop()
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        Timer1.Interval = 100
        Timer2.Interval = 100
        Timer3.Interval = 100
        Timer4.Interval = 100
    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        Timer1.Interval = 200
        Timer2.Interval = 200
        Timer3.Interval = 300
        Timer4.Interval = 400
    End Sub

    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        Timer1.Interval = 300
        Timer2.Interval = 300
        Timer3.Interval = 300
        Timer4.Interval = 300
    End Sub

    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click
        Timer1.Interval = 500
        Timer2.Interval = 500
        Timer3.Interval = 500
        Timer4.Interval = 500
    End Sub

    Private Sub Button16_MouseDown(sender As Object, e As MouseEventArgs) Handles Button16.MouseDown
        abajo()
        Timer3.Start()
    End Sub

    Private Sub Button16_MouseUp(sender As Object, e As MouseEventArgs) Handles Button16.MouseUp
        Timer3.Stop()
    End Sub
    Sub abajo()
        If gbl.getTelnetStatus() = True Then
            telnetMessage("A3")
        End If
    End Sub
    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        abajo()
    End Sub

    Private Sub Timer4_Tick(sender As Object, e As EventArgs) Handles Timer4.Tick
        izquierda()
    End Sub
    Sub izquierda()
        If gbl.getTelnetStatus() = True Then
            telnetMessage("A4")
        End If
    End Sub
    Private Sub Button17_MouseDown(sender As Object, e As MouseEventArgs) Handles Button17.MouseDown
        izquierda()
        Timer4.Start()
    End Sub

    Private Sub Button17_MouseUp(sender As Object, e As MouseEventArgs) Handles Button17.MouseUp
        Timer4.Stop()
    End Sub

End Class
