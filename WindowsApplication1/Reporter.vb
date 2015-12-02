Imports Microsoft.Office.Interop
Public Class Reporter
    Public Shared Sub send()
        Try
            'get all needed files
            Dim zipFile As String = "c:\temp\mpos.7z"

            If My.Computer.FileSystem.FileExists(zipFile) Then
                My.Computer.FileSystem.DeleteFile(zipFile)
            Else
                Process.Start("C:\Program Files\7-Zip\7z.exe", "a " & "-xr!*.exe " & "-xr!*.png " & "-xr!*.dll " & "c:\temp\mpos " & Application.StartupPath)
            End If

            Threading.Thread.Sleep(1000)

            'preapre email and display it
            Dim fileTosend As String = Application.ExecutablePath
            Dim oApp As Outlook.Application
            Dim oEmail As Outlook.MailItem
            oApp = New Outlook.Application
            oEmail = oApp.CreateItem(Outlook.OlItemType.olMailItem)
            With oEmail
                .To = "razvan.belcea@metrosystems.net; gabriel.stanciu@metrosystems.net"
                .Subject = "MPOS tool - crash reporter"
                .BodyFormat = Outlook.OlBodyFormat.olFormatPlain
                .Body = "Description or pictures if needed..."
                .Importance = Outlook.OlImportance.olImportanceHigh
                .ReadReceiptRequested = True
                .Attachments.Add(zipFile, Outlook.OlAttachmentType.olByValue)
                .Recipients.ResolveAll()
                .Display()
            End With
            oEmail = Nothing
            oApp = Nothing
        Catch ex As Exception
            Dim el As New ErrorLogger
            el.WriteToErrorLog(ex.Message, ex.StackTrace, "error")
        End Try
    End Sub
End Class
