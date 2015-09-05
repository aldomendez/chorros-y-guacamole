﻿
Imports System.Text
Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs)
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

    Private Sub Button15_MouseDown(sender As Object, e As MouseEventArgs)
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
    Private Sub Button15_MouseUp(sender As Object, e As MouseEventArgs)
        Timer1.Stop()
    End Sub
    Sub derecha()
        If gbl.getTelnetStatus() = True Then
            telnetMessage("A2")
        End If
    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        TabControl1.Width = Me.Width - 40
        TabControl1.Height = Me.Height - 63
        GroupBox7.Location = New Point(TabControl1.Width - 232, 6)
        telnetAns.Width = TabControl1.Width - 20
        telnetAns.Height = TabControl1.Height - 287
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub PictureBox1_DragEnter(sender As Object, e As DragEventArgs) Handles PictureBox1.DragEnter
        Console.WriteLine("drag enter")
    End Sub

    Private Sub PictureBox1_DragOver(sender As Object, e As DragEventArgs) Handles PictureBox1.DragOver
        Console.WriteLine("drag over")
    End Sub

    Private Sub addInput_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles addInput.MaskInputRejected

    End Sub

    Private Sub TabPage2_GotFocus(sender As Object, e As EventArgs) Handles TabPage2.GotFocus
        Console.WriteLine("got focus")
    End Sub

    Private Sub PictureBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseDown
        Dim holdLeft = Control.MousePosition.X - Me.Left
        Dim holdTop = Control.MousePosition.Y - Me.Top
        Console.WriteLine(holdLeft, holdTop)
    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged

    End Sub
End Class
