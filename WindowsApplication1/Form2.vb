Imports System.ComponentModel

Public Class Form2
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        addInput.Text = gbl.IPaddress
        port.Text = gbl.telnetPort
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        gbl.IPaddress = addInput.Text
        gbl.ini.WriteValue("connection", "ipaddress", addInput.Text)
        If port.Text = "" Then
            gbl.telnetPort = 23
            gbl.ini.WriteValue("connection", "port", 23)
        Else
            gbl.telnetPort = CInt(port.Text)
            gbl.ini.WriteValue("connection", "port", port.Text)
        End If
        Close()
    End Sub

    Private Sub Form2_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Form1.Show()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub
End Class