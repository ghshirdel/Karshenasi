Imports System
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports System.IO
Imports System.Diagnostics

Imports Syncfusion.DocIO
Imports Syncfusion.DocIO.DLS

Imports System.Data.OleDb
Imports FarsiLibrary.Utils
Imports Microsoft.VisualBasic

Public Class SazmanFrm
    Dim Tel_dv As DataView
    Dim AdNew As Boolean = False
    Dim Tel_flag As Boolean = False
    Dim Tel_select_flag As Boolean = False

    Dim AddNew As Boolean = False
    Dim AddNewFk As Boolean = False
    Dim SetFlag As Boolean = False
    Dim SetFlagu As Boolean = False
    Dim NewRow_Flag As Boolean = False
    Dim dv As DataView
    Dim Udv As DataView

    Private Sub Select_Data()
        Try
            SetFlag = False
            Dim Cn As New OleDbConnection
            Cn.ConnectionString = StrCon
            Dim da As New OleDbDataAdapter("Select * from SazmanTable", Cn)
            Dim ds As New DataSet
            da.Fill(ds)
            dv = New DataView(ds.Tables(0))
            SazmanBindingSource.DataSource = dv
            DataGridView1.DataSource = SazmanBindingSource
            If (Sid > 0) Then
                Dim pos As Integer = SazmanBindingSource.Find("Sid", Sid)
                SazmanBindingSource.Position = pos
            End If
            SetFlag = True
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub DataGridView1_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        Try
            If SetFlag = True Then
                If AddNew = False Then
                    Dim Cn As New OleDbConnection
                    Cn.ConnectionString = StrCon
                    Dim Cmd As New OleDbCommand
                    Dim UpdateStr As String
                    Dim dr As DataRow
                    dr = dv.Item(Me.SazmanBindingSource.Position).Row
                    Me.Validate()
                    Cmd.Connection = Cn
                    Me.SazmanBindingSource.EndEdit()
                    UpdateStr = "update SazmanTable set Sazman=? where SId=?"
                    Cmd.CommandText = UpdateStr
                    '  Dim l As String = DataGridView1.CurrentRow.Cells(2).Value
                    Cmd.Parameters.Add("@Sazman", OleDbType.VarChar).Value = DataGridView1.CurrentRow.Cells(1).Value.ToString
                    Cmd.Parameters.Add("@SId", OleDbType.Integer).Value = dr.ItemArray(0)
                    Cn.Open()
                    Cmd.ExecuteNonQuery()
                    Cn.Close()
                    Call Select_Data()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub DataGridView1_RowLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.RowLeave
        Try
            If AddNew = True Then
                Dim Cn As New OleDbConnection
                Cn.ConnectionString = StrCon
                Dim Cmd As New OleDbCommand
                Dim InsertStr As String
                InsertStr = "insert into SazmanTable (Sazman) values(?)"
                Cmd.CommandText = InsertStr
                Me.Validate()
                Cmd.Connection = Cn
                Me.SazmanBindingSource.EndEdit()
                Cmd.Parameters.Add("@Sazman", OleDbType.VarChar).Value = DataGridView1.CurrentRow.Cells(1).Value
                Cn.Open()
                Cmd.ExecuteNonQuery()
                Cn.Close()
                AddNew = False
                Call Select_Data()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub DataGridView1_UserAddedRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles DataGridView1.UserAddedRow
        If e.Row.IsNewRow Then
            AddNew = True
        End If
    End Sub

    Private Sub SazmanFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Select_Data()
        Call Select_UnitKarshenasi()
    End Sub

    Private Sub Select_UnitKarshenasi()
        Try
            If SetFlag = True Then
                'Dim i As String = DataGridView2.CurrentRow.Cells(0).Value
                'If i <> Nothing Then
                Dim dr As DataRow
                dr = dv.Item(Me.SazmanBindingSource.Position).Row
                If dr.ItemArray(0).ToString <> "" Then
                    Dim Cn As New OleDbConnection
                    Cn.ConnectionString = StrCon
                    Dim da As New OleDbDataAdapter("Select * from KunitTable where Sid=" & dr.ItemArray(0), Cn)
                    Dim ds As New DataSet
                    da.Fill(ds)
                    Udv = New DataView(ds.Tables(0))
                    UnitBindingSource.DataSource = Udv
                    DataGridView2.DataSource = UnitBindingSource
                    'UnitBindingSource.Position = UnitBindingSource.Find("KSId", Uid)
                    SetFlagu = True
                End If
            End If
            'End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub DataGridView2_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellValueChanged
        Try
            If SetFlagu = True Then
                Dim Str_cell As String = DataGridView2.CurrentRow.Cells(0).Value.ToString
                If e.ColumnIndex = 0 And Str_cell <> "" Then
                    If AddNewFk = False Then
                        Dim dr As DataRow
                        dr = Udv.Item(Me.UnitBindingSource.Position).Row
                        Dim Update_Str As String = "Update KunitTable set Kunit=?" &
                                                   " Where Ksid=? "
                        Dim Cn As New OleDbConnection
                        Dim Cmd As New OleDbCommand
                        Cn.ConnectionString = StrCon
                        Cmd.CommandText = Update_Str
                        Cmd.Connection = Cn
                        Me.Validate()
                        Me.UnitBindingSource.EndEdit()
                        With DataGridView2.CurrentRow
                            Cmd.Parameters.Add("@Kunit", OleDbType.VarWChar).Value = .Cells(0).Value
                            Cmd.Parameters.Add("@KSid", OleDbType.Integer).Value = dr.ItemArray(0)
                        End With
                        Cn.Open()
                        Cmd.ExecuteNonQuery()
                        Cn.Close()
                        Call Select_UnitKarshenasi()

                    Else
                        Dim dr As DataRow = dv.Item(Me.SazmanBindingSource.Position).Row
                        Dim File_Kar_Name_dr As DataRow = Udv.Item(Me.UnitBindingSource.Position).Row
                        Dim Insert_Str As String = "Insert into KunitTable (Sid,KUnit) " &
                                                   "values(?,?)"
                        Dim Cn As New OleDbConnection
                        Dim Cmd As New OleDbCommand
                        Cn.ConnectionString = StrCon
                        Cmd.CommandText = Insert_Str
                        Cmd.Connection = Cn
                        Me.Validate()
                        Me.UnitBindingSource.EndEdit()
                        With DataGridView2.CurrentRow
                            Cmd.Parameters.Add("@Sid", OleDbType.Integer).Value = dr.ItemArray(0)
                            Cmd.Parameters.Add("@Kunit", OleDbType.VarWChar).Value = .Cells(0).Value
                        End With
                        Cn.Open()
                        Cmd.ExecuteNonQuery()
                        Cn.Close()
                        AddNewFk = False
                    End If
                End If
                Call Select_UnitKarshenasi()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub DataGridView2_RowLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.RowLeave
        Try
            If AddNewFk = True Then

            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub DataGridView2_UserAddedRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles DataGridView2.UserAddedRow
        If e.Row.IsNewRow Then
            AddNewFk = True
        End If
    End Sub

    Private Sub SazmanBindingSource_PositionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SazmanBindingSource.PositionChanged
        Call Select_UnitKarshenasi()
    End Sub

    Private Sub DataGridView2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick
        Try
            If e.ColumnIndex = 2 Then
                '                       ساختن نمونه فرم کارشناسی 
                Dim Unit_dr As DataRow = Udv.Item(UnitBindingSource.Position).Row
                Dim FileName As String = "Define_" & Unit_dr.ItemArray(0).ToString
                If FileName <> "" Then
                    Dim pos As Integer = InStr(PathFileDatabase, Karshenasi_FileName)
                    Dim WPath As String = Mid(PathFileDatabase, 1, pos - 1)
                    'Dim document As New WordDocument
                    WPath += "Word\"
                    If File.Exists(WPath + FileName + ".doc") Then
                        '  document.Open(WPath + FileName + ".doc")

                        System.Diagnostics.Process.Start(WPath + FileName + ".doc")
                    Else
                        Dim Cn As New OleDbConnection
                        Dim Cmd As New OleDbCommand
                        Cn.ConnectionString = StrCon
                        Cmd.Connection = Cn
                        Dim dr As DataRow = Udv.Item(Me.UnitBindingSource.Position).Row
                        Dim Update_Str As String = "Update KUnitTable set KFileName='" & FileName & "' where KSid=" & dr.ItemArray(0).ToString
                        Cmd.CommandText = Update_Str
                        Cn.Open()
                        Cmd.ExecuteNonQuery()
                        Cn.Close()
                        'Dim section As IWSection = document.AddSection()
                        'document.Save(WPath + FileName + ".doc")
                        File.Create(WPath + FileName + ".doc").Dispose()
                        Process.Start(WPath + FileName + ".doc")
                    End If
                Else
                    MsgBox(" در ردیف جاری نام فایل کارشناسی را وارد ننموده اید")
                End If
            End If
            '                       -------  ساختن نمونه فرم دستمزد کارشناسی  ---------
            If e.ColumnIndex = 3 Then
                Dim Mali_dr As DataRow = Udv.Item(UnitBindingSource.Position).Row
                Dim FileName As String = "Define_Mali_" & Mali_dr.ItemArray(0)
                If FileName <> "" Then
                    Dim pos As Integer = InStr(PathFileDatabase, Karshenasi_FileName)
                    Dim WPath As String = Mid(PathFileDatabase, 1, pos - 1)
                    ' Dim document As New WordDocument
                    WPath += "Word\"
                    If File.Exists(WPath + FileName + ".doc") Then
                        'document.Open(WPath + FileName + ".doc")
                        System.Diagnostics.Process.Start(WPath + FileName + ".doc")
                    Else
                        Dim Cn As New OleDbConnection
                        Dim Cmd As New OleDbCommand
                        Cn.ConnectionString = StrCon
                        Cmd.Connection = Cn
                        Dim dr As DataRow = Udv.Item(Me.UnitBindingSource.Position).Row
                        Dim Update_Str As String = "Update KUnitTable set KMaliFileName='" & FileName & "' where KSid=" & dr.ItemArray(0).ToString
                        Cmd.CommandText = Update_Str
                        Cn.Open()
                        Cmd.ExecuteNonQuery()
                        Cn.Close()
                        'Dim section As IWSection = Document.AddSection()
                        'Document.Save(WPath + FileName + ".doc")
                        File.Create(WPath + FileName + ".doc").Dispose()
                        Process.Start(WPath + FileName + ".doc")
                    End If
                Else
                    MsgBox(" در ردیف جاری نام فایل کارشناسی را وارد ننموده اید")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Question)
        End Try
    End Sub

    Private Sub Tel_DataGrid_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Tel_DataGrid.CellValueChanged
        If AdNew = False And Tel_select_flag = True Then
            Me.Validate()
            Tel_BindingSource.EndEdit()
            Call Update_Tel()
        End If
    End Sub

    Private Sub Tel_DataGrid_RowLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Tel_DataGrid.RowLeave
        If AdNew = True And Tel_select_flag = True Then
            Me.Validate()
            Tel_BindingSource.EndEdit()
            Dim dr As DataRow = Udv.Item(UnitBindingSource.Position).Row
            Call Insert_Tel(dr.ItemArray(0))
        End If
    End Sub

    Private Sub Tel_DataGrid_UserAddedRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles Tel_DataGrid.UserAddedRow
        If e.Row.IsNewRow Then
            AdNew = True
        End If
    End Sub

    Private Sub DataGridView2_CellMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView2.CellMouseClick
        If e.ColumnIndex = 1 Then
            Dim dr As DataRow = Udv.Item(UnitBindingSource.Position).Row
            With DataGridView2.CurrentCell
                Dim x1 As Integer = Screen.PrimaryScreen.WorkingArea.Width
                x1 = (x1 - Me.Width) / 2
                Dim x As Integer = .AccessibilityObject.Bounds.X - Tel_Panel.Width + .Size.Width - x1
                Dim Y As Integer = .AccessibilityObject.Bounds.Y - Me.Location.Y - 5
                Tel_Panel.Location = New Point(x, Y)
                Tel_Panel.Visible = True
                Tel_Panel.BringToFront()
                Call Select_Data_Tel(dr.ItemArray(0))
                Tel_DataGrid.Focus()
            End With
        Else
            Tel_Panel.Visible = False
        End If
    End Sub

    Public Sub Select_Data_Tel(ByVal KsId As Integer)
        Tel_select_flag = False
        Dim Cn As New OleDbConnection
        Cn.ConnectionString = StrCon
        Dim da As New OleDbDataAdapter("Select * from Tel_unit where KsId=" & KsId, Cn)
        Dim ds As New DataSet
        da.Fill(ds)
        Tel_dv = New DataView(ds.Tables(0))
        Tel_BindingSource.DataSource = Tel_dv
        Tel_DataGrid.DataSource = Tel_BindingSource
        Tel_select_flag = True
    End Sub
    Private Sub Insert_Tel(ByVal KsId As Integer)
        Try
            If Tel_DataGrid.CurrentCell.Value <> "" Then
                Dim Cn As New OleDbConnection
                Cn.ConnectionString = StrCon
                Dim Cmd As New OleDbCommand
                Cmd.Connection = Cn
                Cmd.CommandText = "Insert into Tel_unit (Ksid,Tell_Number) values(?,?)"
                Cmd.Parameters.Add("KsId", OleDbType.Integer).Value = KsId
                Cmd.Parameters.Add("Tel_Number", OleDbType.VarWChar).Value = Tel_DataGrid.CurrentRow.Cells(0).Value
                Cn.Open()
                Cmd.ExecuteNonQuery()
                Cn.Close()
            End If
            AdNew = False
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub Update_Tel()
        Try
            Dim Cn As New OleDbConnection
            Dim dr As DataRow = Tel_dv.Item(Tel_BindingSource.Position).Row
            Cn.ConnectionString = StrCon
            Dim Cmd As New OleDbCommand
            Cmd.Connection = Cn
            Cmd.CommandText = "Update Tel_unit set Tell_Number=? where Tel_Id=?"
            Cmd.Parameters.Add("Tell_Number", OleDbType.VarWChar).Value = Tel_DataGrid.CurrentRow.Cells(0).Value
            Cmd.Parameters.Add("KsId", OleDbType.Integer).Value = dr.ItemArray(0)
            Cn.Open()
            Cmd.ExecuteNonQuery()
            Cn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Tel_DataGrid_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Tel_DataGrid.KeyDown
        If e.KeyCode = Keys.Escape Then
            Tel_Panel.Visible = False
        End If
    End Sub

    Private Sub Tel_DataGrid_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Tel_DataGrid.KeyUp
        If e.KeyCode = Keys.Delete And e.Control Then
            Dim Cn As New OleDbConnection
            Cn.ConnectionString = StrCon
            Dim dr As DataRow = Tel_dv.Item(Tel_BindingSource.Position).Row
            Dim Cmd As New OleDbCommand
            Cmd.CommandText = "delete from Tel_unit where Tel_Id=" & dr.ItemArray(0)
            Cmd.Connection = Cn
            Cn.Open()
            Cmd.ExecuteNonQuery()
            Cn.Close()
            Dim Udr As DataRow = Udv.Item(UnitBindingSource.Position).Row
            Call Select_Data_Tel(Udr.ItemArray(0))
        End If
    End Sub
    Private Sub SazmanFrm_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        'Uid = 0
        Sid = 0
        Me.Close()

    End Sub

    Private Sub SazmanFrm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Sazmanflag = True
    End Sub
End Class