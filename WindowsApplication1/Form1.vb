
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

                ReturnVal = Encoding.ASCII.GetString(ReadBuffer)
                ReturnLength = gbl.ThisStream.Read(ReadBuffer, 0, ReadBuffer.Length)
                ReturnVal = Encoding.ASCII.GetString(ReadBuffer)
                Debug.WriteLine(ReturnVal)
            Else
                MsgBox("Conection closed, you must have to click the Connect Button")
            End If

        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub btnStartConnection_Click(sender As Object, e As EventArgs) Handles btnStartConnection.Click
        If gbl.getTelnetStatus() = False Then
            gbl.connect()
            btnStartConnection.Text = "Disconect"
        Else
            gbl.disconect()
            btnStartConnection.Text = "Connect"
        End If
    End Sub

    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        ipShow.Text = "shown: " & gbl.getTelnetStatus() & " from " & gbl.IPaddress
    End Sub

    Private Sub a1_Click(sender As Object, e As EventArgs)
        telnetMessage(gbl.valv1)
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
End Class
