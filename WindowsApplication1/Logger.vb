Imports System.IO
Imports System.Text
Imports System.Windows.Forms

<CLSCompliant(True)> _
Public Class ErrorLogger

    Public Sub New()

        'default constructor

    End Sub

    Public Sub WriteToErrorLog(ByVal msg As String, ByVal stkTrace As String, ByVal title As String)

        ' get file info and folder    
        Try
            Dim fileName As String = Application.StartupPath & "\mpostool.log"
            Dim dir As DirectoryInfo = New DirectoryInfo(Application.StartupPath)

            'check if the file is bigger than 5MB
            If My.Computer.FileSystem.FileExists(fileName) Then
                Dim logSize As System.IO.FileInfo
                logSize = My.Computer.FileSystem.GetFileInfo(fileName)
                If logSize.Length > 5000000 Then
                    My.Computer.FileSystem.DeleteFile(fileName)
                End If
            End If

            'check the file
            Dim fs As FileStream = New FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite)
            Dim s As StreamWriter = New StreamWriter(fs)
            s.Close()
            fs.Close()

            'log it
            Dim fs1 As FileStream = New FileStream(fileName, FileMode.Append, FileAccess.Write)
            Dim s1 As StreamWriter = New StreamWriter(fs1)
            s1.Write("Title: " & title & vbCrLf)
            s1.Write("Message: " & msg & vbCrLf)
            s1.Write("StackTrace: " & stkTrace & vbCrLf)
            s1.Write("Date/Time: " & DateTime.Now.ToString() & vbCrLf)
            s1.Write("===========================================================================================" & vbCrLf)
            s1.Close()
            fs1.Close()
        Catch e As Exception
            MsgBox(e.Message)
        End Try

    End Sub
End Class