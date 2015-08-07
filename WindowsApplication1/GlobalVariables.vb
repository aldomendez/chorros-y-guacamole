﻿' Requiered to allow the tcpClient connection
Imports System.Net.Sockets
Imports System.Text

Public Class gbl
    Public Shared IPaddress As String = "localhost"
    Public Shared telnetPort As Integer = 23
    Public Shared Property ThisStream As NetworkStream
    Public Shared TelnetClient As TcpClient
    Public Shared valvX As Integer = 0
    Public Shared valvY As Integer = 0
    Public Shared valvZ As Integer = 0

    Public Shared Function getTelnetStatus() As String
        Return TelnetClient.Connected
    End Function
    Public Shared Sub connect()
        Dim SendBuffer(128) As Byte
        Dim ReadBuffer(256) As Byte
        Dim ReturnVal As String
        Dim ReturnLength As Integer

        TelnetClient = New TcpClient()
        Try
            TelnetClient.Connect(IPaddress, telnetPort)
            ThisStream = TelnetClient.GetStream

            ReturnLength = gbl.ThisStream.Read(ReadBuffer, 0, ReadBuffer.Length)
            ReturnVal = Encoding.ASCII.GetString(ReadBuffer, 0, ReturnLength)
            Form1.telnetAns.Text = " --> " + ReturnVal & vbCrLf & Form1.telnetAns.Text
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Shared Sub disconect()
        TelnetClient.Close()
    End Sub

    Public Shared Sub tcpStart()
        'Connect to server (next 2 lines)
        TelnetClient = New TcpClient()
    End Sub


End Class