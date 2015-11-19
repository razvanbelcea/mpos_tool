Imports Microsoft.Office.Interop
Public Class Reporter
    Public Shared Sub send()
        Try
            'get all needed files

            'preapre email and display it
            Dim fileTosend As String = Application.ExecutablePath
            Dim oApp As Outlook.Application
            Dim oEmail As Outlook.MailItem
            oApp = New Outlook.Application
            oEmail = oApp.CreateItem(Outlook.OlItemType.olMailItem)
            With oEmail
                .To = "razvan.belcea@metrosystems.net, gabriel.stanciu@metrosystems.net"
                .Subject = "MPOS tool - automated reporter"
                .BodyFormat = Outlook.OlBodyFormat.olFormatPlain
                .Body = "blablabla"
                .Importance = Outlook.OlImportance.olImportanceHigh
                .ReadReceiptRequested = True
                .Attachments.Add("C:\Users\invasion\Desktop\xml test\vbnettextlogger\UpgradeLog.htm", Outlook.OlAttachmentType.olByValue)
                .Recipients.ResolveAll()
                .Display()
            End With
            oEmail = Nothing
            oApp = Nothing
        Catch ex As Exception
            Logger.LogInfo(ex)
        End Try
    End Sub
End Class
