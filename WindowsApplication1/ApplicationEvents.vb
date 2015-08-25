Imports System.IO

Namespace My

    ' The following events are available for MyApplication:
    ' 
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication

        Private Sub MyApplication_Startup(sender As Object, e As ApplicationServices.StartupEventArgs) Handles Me.Startup
            If My.Computer.FileSystem.DirectoryExists("\\buk11fsr001\GRP_MSYS_MPOS_DELIVERY\pos\Users\public") Then
                Dim sr As StreamReader
                sr = New StreamReader("\\buk11fsr001\GRP_MSYS_MPOS_DELIVERY\pos\Users\public\Update.txt")
                Dim exenewestversion As String = sr.ReadToEnd()
                Dim execurrentversion As String = System.Windows.Forms.Application.ProductVersion
                If execurrentversion < exenewestversion Then
                    Form1.Label15.Hide()
                    Form1.Label16.Hide()
                Else
                    Form1.ActualVersion()
                    Form1.Button2.Hide()
                End If
                sr.Close()
            Else
                MsgBox("Network not available!")
                Form1.ActualVersion()
                Form1.Button2.Hide()
            End If
        End Sub
    End Class


End Namespace

