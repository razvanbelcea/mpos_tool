Imports System.IO

Public Class Logger
    Private Shared Sub Info(ByVal info As Object)
        'get file info and folder    

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

        'Check if log file exista            
        If File.Exists(fileName) Then
            Try
                Dim fs As FileStream = New FileStream(fileName, FileMode.Append, FileAccess.Write)
                Dim sw As StreamWriter = New StreamWriter(fs)
                sw.WriteLine(DateTime.Now + " " + info.ToString)
                sw.Close()
                fs.Close()
            Catch dirEx As DirectoryNotFoundException
                LogInfo(dirEx)
            Catch ex As FileNotFoundException
                LogInfo(ex)
            Catch Ex As Exception
                LogInfo(Ex)
            End Try
        Else
            'If file doesn't exist create one               
            Try
                dir = Directory.CreateDirectory(dir.FullName)
                Dim fileStream As FileStream = File.Create(fileName)
                Dim sw As StreamWriter = New StreamWriter(fileStream)
                sw.WriteLine(DateTime.Now + info.ToString)
                sw.Close()
                fileStream.Close()
            Catch fileEx As FileNotFoundException
                LogInfo(fileEx)
            Catch dirEx As DirectoryNotFoundException
                LogInfo(dirEx)
            Catch ex As Exception
                LogInfo(ex)
            End Try
        End If
    End Sub
    Public Shared Sub LogInfo(ByVal ex As Exception)
        Try
            'write error info - complex              
            Dim trace As Diagnostics.StackTrace = New Diagnostics.StackTrace(ex, True)
            Dim fileNames As String = trace.GetFrame((trace.FrameCount - 1)).GetFileName()
            Dim lineNumber As Int32 = trace.GetFrame((trace.FrameCount - 1)).GetFileLineNumber()
            Info(vbCrLf + "Error In: " + fileNames + vbCrLf + "Line Number:" + lineNumber.ToString() + vbCrLf + "Error Message: " + ex.Message)
        Catch genEx As Exception
            Info(ex.Message)
        End Try
    End Sub
    Public Shared Sub LogInfo(ByVal message As String)
        Try
            'Write error info - simple   
            Info(" Message: " + message)
        Catch genEx As Exception
            Info(genEx.Message)
        End Try
    End Sub

End Class
