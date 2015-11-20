Imports Microsoft.Office.Interop
Imports System.Data.SqlClient
Imports System.Runtime.InteropServices
Public Class DiscountExtract
    Public Shared Sub getem()
        Dim connetionString As String
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter
        Dim ds As New DataSet
        Dim sql2, sql4, sql5, sql6, sql7, sql8, sql9, sql10, sql11, sql12, sql13, sql14, sql15, sql16, sql17, sql18, sql19, sql20, sql3, sql1, sql21 As String
        Dim File As String = "c:\temp\test.xlsx"

        connetionString = "Data Source=" & Form1.label9.Text & ";Database=TPCentralDB;" & Form1.cred & ";"
        sql1 = "select * from DiscountAffiliation"
        sql2 = "select * from DiscountCondition"
        sql3 = "select * from DiscountConditionElement"
        sql4 = "select * from DiscountConditionElementDetail"
        sql5 = "select * from DiscountItemQualifier"
        sql6 = "select * from DiscountItemQualifierElement"
        sql7 = "select * from DiscountItemQualifierElementDetail"
        sql8 = "select * from DiscountItemQualifierTemp"
        sql9 = "select * from Discountlist"
        sql10 = "select * from DiscountMedia"
        sql11 = "select * from DiscountRule"
        sql12 = "select * from DiscountRuleMxM"
        sql13 = "select * from DiscountRuleMxMTemp"
        sql14 = "select * from DiscountRuleQuantity"
        sql15 = "select * from DiscountRuleQuantityDetail"
        sql16 = "select * from DiscountTimeQualifier"
        sql17 = "select * from MGIDiscountCustomerQualifier"
        sql18 = "select * from MGIDiscountCustomerQualifierElement"
        sql19 = "select * from MGIDiscountCustomerQualifierElementDetail"
        sql20 = "select * from MGIItemDiscountGroup"
        sql21 = "select * from MGIItemDiscountGroupAffiliation"

        connection = New SqlConnection(connetionString)

        Try
            connection.Open()

            command = New SqlCommand(sql1, connection)
            adapter.SelectCommand = command
            adapter.Fill(ds, "1")

            adapter.SelectCommand.CommandText = sql2
            adapter.Fill(ds, "2")

            adapter.SelectCommand.CommandText = sql3
            adapter.Fill(ds, "3")

            adapter.SelectCommand.CommandText = sql4
            adapter.Fill(ds, "4")

            adapter.SelectCommand.CommandText = sql5
            adapter.Fill(ds, "5")

            adapter.SelectCommand.CommandText = sql6
            adapter.Fill(ds, "6")

            adapter.SelectCommand.CommandText = sql7
            adapter.Fill(ds, "7")

            adapter.SelectCommand.CommandText = sql8
            adapter.Fill(ds, "8")

            adapter.SelectCommand.CommandText = sql9
            adapter.Fill(ds, "9")

            adapter.SelectCommand.CommandText = sql10
            adapter.Fill(ds, "10")

            adapter.SelectCommand.CommandText = sql11
            adapter.Fill(ds, "11")

            adapter.SelectCommand.CommandText = sql12
            adapter.Fill(ds, "12")

            adapter.SelectCommand.CommandText = sql13
            adapter.Fill(ds, "13")

            adapter.SelectCommand.CommandText = sql14
            adapter.Fill(ds, "14")

            adapter.SelectCommand.CommandText = sql15
            adapter.Fill(ds, "15")

            adapter.SelectCommand.CommandText = sql16
            adapter.Fill(ds, "16")

            adapter.SelectCommand.CommandText = sql17
            adapter.Fill(ds, "17")

            adapter.SelectCommand.CommandText = sql18
            adapter.Fill(ds, "18")

            adapter.SelectCommand.CommandText = sql19
            adapter.Fill(ds, "19")

            adapter.SelectCommand.CommandText = sql20
            adapter.Fill(ds, "20")

            adapter.SelectCommand.CommandText = sql21
            adapter.Fill(ds, "21")

            adapter.Dispose()
            command.Dispose()
            connection.Close()

            Dim oXL As Excel.Application = New Excel.Application
            Dim oWB As Excel.Workbook
            Dim oSheet As Excel.Worksheet
            Dim osheet1 As Excel.Worksheet
            Dim oRng As Excel.Range
            oXL.Visible = True
            Dim dc As DataColumn
            Dim dr As DataRow
            Dim colIndex As Integer
            Dim rowIndex As Integer
            oWB = oXL.Workbooks.Add
            oSheet = CType(oWB.ActiveSheet, Excel.Worksheet)

            'retrieve first table data
            colIndex = 0
            rowIndex = 0
            oSheet.Name = "DiscountAffiliation"
            If ds.Tables(0).Rows.Count > 0 Then
                For Each dc In ds.Tables(0).Columns
                    colIndex = colIndex + 1
                    oSheet.Cells(1, colIndex) = dc.ColumnName
                Next
                For Each dr In ds.Tables(0).Rows
                    rowIndex = rowIndex + 1
                    colIndex = 0
                    For Each dc In ds.Tables(0).Columns
                        colIndex = colIndex + 1
                        oSheet.Cells(rowIndex + 1, colIndex) = dr(dc.ColumnName)
                    Next
                Next
            Else
                oSheet.Cells(1, 1) = "Table is empty!"
            End If

            'retrieve second table data
            colIndex = 0
            rowIndex = 0
            osheet1 = oWB.Worksheets.Add(, oSheet, , )
            osheet1.Name = "DiscountCondition"
            If ds.Tables(1).Rows.Count > 0 Then
                For Each dc In ds.Tables(1).Columns
                    colIndex = colIndex + 1
                    osheet1.Cells(1, colIndex) = dc.ColumnName
                Next
                For Each dr In ds.Tables(1).Rows
                    rowIndex = rowIndex + 1
                    colIndex = 0
                    For Each dc In ds.Tables(1).Columns
                        colIndex = colIndex + 1
                        osheet1.Cells(rowIndex + 1, colIndex) = dr(dc.ColumnName)
                    Next
                Next
            Else
                osheet1.Cells(1, 1) = "Table is empty!"
            End If

            'retrieve third table data
            colIndex = 0
            rowIndex = 0
            Dim osheet2 As Excel.Worksheet = oWB.Worksheets.Add(, oSheet, , )
            osheet2.Name = "DiscountConditionElement"
            If ds.Tables(2).Rows.Count > 0 Then
                For Each dc In ds.Tables(2).Columns
                    colIndex = colIndex + 1
                    osheet2.Cells(1, colIndex) = dc.ColumnName
                Next
                For Each dr In ds.Tables(2).Rows
                    rowIndex = rowIndex + 1
                    colIndex = 0
                    For Each dc In ds.Tables(2).Columns
                        colIndex = colIndex + 1
                        osheet2.Cells(rowIndex + 1, colIndex) = dr(dc.ColumnName)
                    Next
                Next
            Else
                osheet2.Cells(1, 1) = "Table is empty!"
            End If

            'retrieve forth table data
            colIndex = 0
            rowIndex = 0
            Dim osheet3 As Excel.Worksheet = oWB.Worksheets.Add(, oSheet, , )
            osheet3.Name = "DiscountConditionElementDetail"
            If ds.Tables(3).Rows.Count > 0 Then
                For Each dc In ds.Tables(3).Columns
                    colIndex = colIndex + 1
                    osheet3.Cells(1, colIndex) = dc.ColumnName
                Next
                For Each dr In ds.Tables(3).Rows
                    rowIndex = rowIndex + 1
                    colIndex = 0
                    For Each dc In ds.Tables(3).Columns
                        colIndex = colIndex + 1
                        osheet3.Cells(rowIndex + 1, colIndex) = dr(dc.ColumnName)
                    Next
                Next
            Else
                osheet3.Cells(1, 1) = "Table is empty!"
            End If

            'retrieve fifth table data
            colIndex = 0
            rowIndex = 0
            Dim osheet4 As Excel.Worksheet = oWB.Worksheets.Add(, oSheet, , )
            osheet4.Name = "DiscountItemQualifier"
            If ds.Tables(4).Rows.Count > 0 Then
                For Each dc In ds.Tables(4).Columns
                    colIndex = colIndex + 1
                    osheet4.Cells(1, colIndex) = dc.ColumnName
                Next
                For Each dr In ds.Tables(4).Rows
                    rowIndex = rowIndex + 1
                    colIndex = 0
                    For Each dc In ds.Tables(4).Columns
                        colIndex = colIndex + 1
                        osheet4.Cells(rowIndex + 1, colIndex) = dr(dc.ColumnName)
                    Next
                Next
            Else
                osheet4.Cells(1, 1) = "Table is empty!"
            End If

            'retrieve fifth table data
            colIndex = 0
            rowIndex = 0
            Dim osheet5 As Excel.Worksheet = oWB.Worksheets.Add(, oSheet, , )
            osheet5.Name = "DiscountItemQualifierElement"
            If ds.Tables(5).Rows.Count > 0 Then
                For Each dc In ds.Tables(5).Columns
                    colIndex = colIndex + 1
                    osheet5.Cells(1, colIndex) = dc.ColumnName
                Next
                For Each dr In ds.Tables(5).Rows
                    rowIndex = rowIndex + 1
                    colIndex = 0
                    For Each dc In ds.Tables(5).Columns
                        colIndex = colIndex + 1
                        osheet5.Cells(rowIndex + 1, colIndex) = dr(dc.ColumnName)
                    Next
                Next
            Else
                osheet5.Cells(1, 1) = "Table is empty!"
            End If

            'retrieve sixt table data
            colIndex = 0
            rowIndex = 0
            Dim osheet6 As Excel.Worksheet = oWB.Worksheets.Add(, oSheet, , )
            osheet6.Name = "DiscountItemQualifierElementDet"
            If ds.Tables(6).Rows.Count > 0 Then
                For Each dc In ds.Tables(6).Columns
                    colIndex = colIndex + 1
                    osheet6.Cells(1, colIndex) = dc.ColumnName
                Next
                For Each dr In ds.Tables(6).Rows
                    rowIndex = rowIndex + 1
                    colIndex = 0
                    For Each dc In ds.Tables(6).Columns
                        colIndex = colIndex + 1
                        osheet6.Cells(rowIndex + 1, colIndex) = dr(dc.ColumnName)
                    Next
                Next
            Else
                osheet6.Cells(1, 1) = "Table is empty!"
            End If

            'retrieve sixt table data
            colIndex = 0
            rowIndex = 0
            Dim osheet7 As Excel.Worksheet = oWB.Worksheets.Add(, oSheet, , )
            osheet7.Name = "DiscountItemQualifierTemp"
            If ds.Tables(7).Rows.Count > 0 Then
                For Each dc In ds.Tables(7).Columns
                    colIndex = colIndex + 1
                    osheet7.Cells(1, colIndex) = dc.ColumnName
                Next
                For Each dr In ds.Tables(7).Rows
                    rowIndex = rowIndex + 1
                    colIndex = 0
                    For Each dc In ds.Tables(7).Columns
                        colIndex = colIndex + 1
                        osheet7.Cells(rowIndex + 1, colIndex) = dr(dc.ColumnName)
                    Next
                Next
            Else
                osheet7.Cells(1, 1) = "Table is empty!"
            End If

            'retrieve sixt table data
            colIndex = 0
            rowIndex = 0
            Dim osheet8 As Excel.Worksheet = oWB.Worksheets.Add(, oSheet, , )
            osheet8.Name = "Discountlist"
            If ds.Tables(8).Rows.Count > 0 Then
                For Each dc In ds.Tables(8).Columns
                    colIndex = colIndex + 1
                    osheet8.Cells(1, colIndex) = dc.ColumnName
                Next
                For Each dr In ds.Tables(8).Rows
                    rowIndex = rowIndex + 1
                    colIndex = 0
                    For Each dc In ds.Tables(8).Columns
                        colIndex = colIndex + 1
                        osheet8.Cells(rowIndex + 1, colIndex) = dr(dc.ColumnName)
                    Next
                Next
            Else
                osheet8.Cells(1, 1) = "Table is empty!"
            End If

            'retrieve sixt table data
            colIndex = 0
            rowIndex = 0
            Dim osheet9 As Excel.Worksheet = oWB.Worksheets.Add(, oSheet, , )
            osheet9.Name = "DiscountMedia"
            If ds.Tables(9).Rows.Count > 0 Then
                For Each dc In ds.Tables(9).Columns
                    colIndex = colIndex + 1
                    osheet9.Cells(1, colIndex) = dc.ColumnName
                Next
                For Each dr In ds.Tables(9).Rows
                    rowIndex = rowIndex + 1
                    colIndex = 0
                    For Each dc In ds.Tables(9).Columns
                        colIndex = colIndex + 1
                        osheet9.Cells(rowIndex + 1, colIndex) = dr(dc.ColumnName)
                    Next
                Next
            Else
                osheet9.Cells(1, 1) = "Table is empty!"
            End If

            'retrieve sixt table data
            colIndex = 0
            rowIndex = 0
            Dim osheet10 As Excel.Worksheet = oWB.Worksheets.Add(, oSheet, , )
            osheet10.Name = "DiscountRule"
            If ds.Tables(10).Rows.Count > 0 Then
                For Each dc In ds.Tables(10).Columns
                    colIndex = colIndex + 1
                    osheet10.Cells(1, colIndex) = dc.ColumnName
                Next
                For Each dr In ds.Tables(10).Rows
                    rowIndex = rowIndex + 1
                    colIndex = 0
                    For Each dc In ds.Tables(10).Columns
                        colIndex = colIndex + 1
                        osheet10.Cells(rowIndex + 1, colIndex) = dr(dc.ColumnName)
                    Next
                Next
            Else
                osheet10.Cells(1, 1) = "Table is empty!"
            End If

            'retrieve sixt table data
            colIndex = 0
            rowIndex = 0
            Dim osheet11 As Excel.Worksheet = oWB.Worksheets.Add(, oSheet, , )
            osheet11.Name = "DiscountRuleMxM"
            If ds.Tables(11).Rows.Count > 0 Then
                For Each dc In ds.Tables(11).Columns
                    colIndex = colIndex + 1
                    osheet11.Cells(1, colIndex) = dc.ColumnName
                Next
                For Each dr In ds.Tables(11).Rows
                    rowIndex = rowIndex + 1
                    colIndex = 0
                    For Each dc In ds.Tables(11).Columns
                        colIndex = colIndex + 1
                        osheet11.Cells(rowIndex + 1, colIndex) = dr(dc.ColumnName)
                    Next
                Next
            Else
                osheet11.Cells(1, 1) = "Table is empty!"
            End If

            'retrieve sixt table data
            colIndex = 0
            rowIndex = 0
            Dim osheet12 As Excel.Worksheet = oWB.Worksheets.Add(, oSheet, , )
            osheet12.Name = "DiscountRuleMxMTemp"
            If ds.Tables(12).Rows.Count > 0 Then
                For Each dc In ds.Tables(12).Columns
                    colIndex = colIndex + 1
                    osheet12.Cells(1, colIndex) = dc.ColumnName
                Next
                For Each dr In ds.Tables(12).Rows
                    rowIndex = rowIndex + 1
                    colIndex = 0
                    For Each dc In ds.Tables(12).Columns
                        colIndex = colIndex + 1
                        osheet12.Cells(rowIndex + 1, colIndex) = dr(dc.ColumnName)
                    Next
                Next
            Else
                osheet12.Cells(1, 1) = "Table is empty!"
            End If

            'retrieve sixt table data
            colIndex = 0
            rowIndex = 0
            Dim osheet13 As Excel.Worksheet = oWB.Worksheets.Add(, oSheet, , )
            osheet13.Name = "DiscountRuleQuantity"
            If ds.Tables(13).Rows.Count > 0 Then
                For Each dc In ds.Tables(13).Columns
                    colIndex = colIndex + 1
                    osheet13.Cells(1, colIndex) = dc.ColumnName
                Next
                For Each dr In ds.Tables(13).Rows
                    rowIndex = rowIndex + 1
                    colIndex = 0
                    For Each dc In ds.Tables(13).Columns
                        colIndex = colIndex + 1
                        osheet13.Cells(rowIndex + 1, colIndex) = dr(dc.ColumnName)
                    Next
                Next
            Else
                osheet13.Cells(1, 1) = "Table is empty!"
            End If

            'retrieve sixt table data
            colIndex = 0
            rowIndex = 0
            Dim osheet14 As Excel.Worksheet = oWB.Worksheets.Add(, oSheet, , )
            osheet14.Name = "DiscountRuleQuantityDetail"
            If ds.Tables(14).Rows.Count > 0 Then
                For Each dc In ds.Tables(14).Columns
                    colIndex = colIndex + 1
                    osheet14.Cells(1, colIndex) = dc.ColumnName
                Next
                For Each dr In ds.Tables(14).Rows
                    rowIndex = rowIndex + 1
                    colIndex = 0
                    For Each dc In ds.Tables(14).Columns
                        colIndex = colIndex + 1
                        osheet14.Cells(rowIndex + 1, colIndex) = dr(dc.ColumnName)
                    Next
                Next
            Else
                osheet14.Cells(1, 1) = "Table is empty!"
            End If

            'retrieve sixt table data
            colIndex = 0
            rowIndex = 0
            Dim osheet15 As Excel.Worksheet = oWB.Worksheets.Add(, oSheet, , )
            osheet15.Name = "DiscountTimeQualifier"
            If ds.Tables(15).Rows.Count > 0 Then
                For Each dc In ds.Tables(15).Columns
                    colIndex = colIndex + 1
                    osheet15.Cells(1, colIndex) = dc.ColumnName
                Next
                For Each dr In ds.Tables(15).Rows
                    rowIndex = rowIndex + 1
                    colIndex = 0
                    For Each dc In ds.Tables(15).Columns
                        colIndex = colIndex + 1
                        osheet15.Cells(rowIndex + 1, colIndex) = dr(dc.ColumnName)
                    Next
                Next
            Else
                osheet15.Cells(1, 1) = "Table is empty!"
            End If

            'retrieve sixt table data
            colIndex = 0
            rowIndex = 0
            Dim osheet16 As Excel.Worksheet = oWB.Worksheets.Add(, oSheet, , )
            osheet16.Name = "MGIDiscountCustomerQualifier"
            If ds.Tables(16).Rows.Count > 0 Then
                For Each dc In ds.Tables(16).Columns
                    colIndex = colIndex + 1
                    osheet16.Cells(1, colIndex) = dc.ColumnName
                Next
                For Each dr In ds.Tables(16).Rows
                    rowIndex = rowIndex + 1
                    colIndex = 0
                    For Each dc In ds.Tables(16).Columns
                        colIndex = colIndex + 1
                        osheet16.Cells(rowIndex + 1, colIndex) = dr(dc.ColumnName)
                    Next
                Next
            Else
                osheet16.Cells(1, 1) = "Table is empty!"
            End If

            'retrieve sixt table data
            colIndex = 0
            rowIndex = 0
            Dim osheet17 As Excel.Worksheet = oWB.Worksheets.Add(, oSheet, , )
            osheet17.Name = "MGIDiscountCustomerQualifierEle"
            If ds.Tables(17).Rows.Count > 0 Then
                For Each dc In ds.Tables(17).Columns
                    colIndex = colIndex + 1
                    osheet17.Cells(1, colIndex) = dc.ColumnName
                Next
                For Each dr In ds.Tables(17).Rows
                    rowIndex = rowIndex + 1
                    colIndex = 0
                    For Each dc In ds.Tables(17).Columns
                        colIndex = colIndex + 1
                        osheet17.Cells(rowIndex + 1, colIndex) = dr(dc.ColumnName)
                    Next
                Next
            Else
                osheet17.Cells(1, 1) = "Table is empty!"
            End If

            'retrieve sixt table data
            colIndex = 0
            rowIndex = 0
            Dim osheet18 As Excel.Worksheet = oWB.Worksheets.Add(, oSheet, , )
            osheet18.Name = "MGIDiscountCustomerQualifierElD"
            If ds.Tables(18).Rows.Count > 0 Then
                For Each dc In ds.Tables(18).Columns
                    colIndex = colIndex + 1
                    osheet18.Cells(1, colIndex) = dc.ColumnName
                Next
                For Each dr In ds.Tables(18).Rows
                    rowIndex = rowIndex + 1
                    colIndex = 0
                    For Each dc In ds.Tables(18).Columns
                        colIndex = colIndex + 1
                        osheet18.Cells(rowIndex + 1, colIndex) = dr(dc.ColumnName)
                    Next
                Next
            Else
                osheet18.Cells(1, 1) = "Table is empty!"
            End If

            'retrieve sixt table data
            colIndex = 0
            rowIndex = 0
            Dim osheet19 As Excel.Worksheet = oWB.Worksheets.Add(, oSheet, , )
            osheet19.Name = "MGIItemDiscountGroup"
            If ds.Tables(19).Rows.Count > 0 Then
                For Each dc In ds.Tables(19).Columns
                    colIndex = colIndex + 1
                    osheet19.Cells(1, colIndex) = dc.ColumnName
                Next
                For Each dr In ds.Tables(19).Rows
                    rowIndex = rowIndex + 1
                    colIndex = 0
                    For Each dc In ds.Tables(19).Columns
                        colIndex = colIndex + 1
                        osheet19.Cells(rowIndex + 1, colIndex) = dr(dc.ColumnName)
                    Next
                Next
            Else
                osheet19.Cells(1, 1) = "Table is empty!"
            End If

            'retrieve sixt table data
            colIndex = 0
            rowIndex = 0
            Dim osheet20 As Excel.Worksheet = oWB.Worksheets.Add(, oSheet, , )
            osheet20.Name = "MGIItemDiscountGroupAffiliation"
            If ds.Tables(20).Rows.Count > 0 Then
                For Each dc In ds.Tables(20).Columns
                    colIndex = colIndex + 1
                    osheet20.Cells(1, colIndex) = dc.ColumnName
                Next
                For Each dr In ds.Tables(20).Rows
                    rowIndex = rowIndex + 1
                    colIndex = 0
                    For Each dc In ds.Tables(20).Columns
                        colIndex = colIndex + 1
                        osheet20.Cells(rowIndex + 1, colIndex) = dr(dc.ColumnName)
                    Next
                Next
            Else
                osheet20.Cells(1, 1) = "Table is empty!"
            End If

            oXL.Visible = True
            oXL.UserControl = True

            'oWB.SaveAs(File)
            oRng = Nothing
            'oXL.Quit()
            ExcelCleanUp(oXL, oWB, oSheet)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Shared Sub ExcelCleanUp( _
ByVal oXL As Excel.Application, _
ByVal oWB As Excel.Workbook, _
ByVal oSheet As Excel.Worksheet)

        GC.Collect()
        GC.WaitForPendingFinalizers()

        Marshal.FinalReleaseComObject(oXL)
        Marshal.FinalReleaseComObject(oSheet)
        Marshal.FinalReleaseComObject(oWB)

        oSheet = Nothing
        oWB = Nothing
        oXL = Nothing

    End Sub
End Class
