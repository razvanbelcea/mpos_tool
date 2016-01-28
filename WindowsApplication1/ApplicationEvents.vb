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
            Try
                Dim WbReq As New Net.WebClient
                WbReq.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials
                WbReq.Dispose()

                Dim request As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create("http://my-collaboration.metrogroup-networking.com/personal/r4_razvan_belcea/Shared%20Documents/Update.txt")
                request.Credentials = System.Net.CredentialCache.DefaultCredentials
                Dim response As System.Net.HttpWebResponse = request.GetResponse()
                Dim sr As System.IO.StreamReader = New System.IO.StreamReader(response.GetResponseStream())
                Dim exenewestversion As String = sr.ReadToEnd()
                Dim execurrentversion As String = System.Windows.Forms.Application.ProductVersion
                If execurrentversion < exenewestversion Then
                    Form1.Label15.Hide()
                    Form1.Label16.Hide()
                    Form1.DownloadNewVersionToolStripMenuItem1.Enabled = True
                    Form1.DownloadNewVersionToolStripMenuItem1.ForeColor = Color.Red
                Else
                    Form1.ActualVersion()
                    Form1.DownloadNewVersionToolStripMenuItem1.Enabled = False
                End If
                sr.Close()
                Form1.ActualVersion()
                Form1.ShowInTaskbar = True
                Form9.CheckSettings()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Sub
    End Class


End Namespace

