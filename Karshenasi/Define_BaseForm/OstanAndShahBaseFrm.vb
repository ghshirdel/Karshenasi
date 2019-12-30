Imports System
Imports System.Data
Imports System.Data.OleDb
Public Class OstanAndShahBaseFrm
    Dim OstanDv As DataView
    Dim SharDv As DataView
    Dim AddNewOstan As Boolean = False
    Dim AddNewShahr As Boolean = False

    Dim OstanFlag As Boolean = False
    Dim ShahrFlag As Boolean = False
    Private Sub OstanAndShahBaseFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Ostan_Select()
        Call Shahr_Select()
    End Sub

    Private Sub Ostan_Select()
        Try
            Dim Cn As New OleDbConnection
            Cn.ConnectionString = StrCon
            Dim da As New OleDbDataAdapter("Select * from TOstan order by Ostan", Cn)
            Dim ds As New DataSet
            da.Fill(ds)
            OstanDv = New DataView(ds.Tables(0))
            OstanBindingSource.DataSource = OstanDv
            OstanDataGrid.DataSource = OstanBindingSource
            OstanFlag = True
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub Ostan_Insert()
        Try
            Me.Validate()
            OstanBindingSource.EndEdit()
            Dim Insert_Str As String = "Insert into TOstan (Ostan) values(?)"
            Dim Cn As New OleDbConnection
            Cn.ConnectionString = StrCon
            Dim Cmd As New OleDbCommand
            Cmd.Connection = Cn
            Cmd.CommandText = Insert_Str
            Dim dr As DataRow
            dr = OstanDv.Item(OstanBindingSource.Position).Row
            Cmd.Parameters.Add("@Ostan", OleDbType.VarWChar).Value = dr.ItemArray(1)
            Cn.Open()
            Cmd.ExecuteNonQuery()
            Cn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub Ostan_Update()
        Try
            Me.Validate()
            OstanBindingSource.EndEdit()
            Dim dr As DataRow
            dr = OstanDv.Item(OstanBindingSource.Position).Row
            Dim Update_Str As String = "Update TOstan set Ostan=? where Ocode=?"
            Dim Cn As New OleDbConnection
            Dim Cmd As New OleDbCommand
            Cn.ConnectionString = StrCon
            Cmd.Connection = Cn
            Cmd.CommandText = Update_Str
            Cmd.Parameters.Add("@Ostan", OleDbType.VarWChar).Value = OstanDataGrid.CurrentRow.Cells(1).Value
            Cmd.Parameters.Add("@Ocode", OleDbType.Integer).Value = dr.ItemArray(0)
            Cn.Open()
            Cmd.ExecuteNonQuery()
            Cn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Shahr_Select()
        Try
            Dim dr As DataRow
            dr = OstanDv.Item(OstanBindingSource.Position).Row
            If dr.ItemArray(0) IsNot DBNull.Value Then
                Dim Cn As New OleDbConnection
                Cn.ConnectionString = StrCon
                Dim Select_Str As String = "Select * from TShahrestan where OCode=" & dr.ItemArray(0) & " Order by Shahrestan"
                Dim da As New OleDbDataAdapter(Select_Str, Cn)
                Dim ds As New DataSet
                da.Fill(ds)
                SharDv = New DataView(ds.Tables(0))
                ShahrBindingSource.DataSource = SharDv
                ShahrDataGrid.DataSource = ShahrBindingSource
                ShahrFlag = True
            Else
                ShahrDataGrid.DataSource = Nothing
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub Shahr_Insert()
        Try
            Me.Validate()
            ShahrBindingSource.EndEdit()
            Dim Insert_Str As String = "Insert into TShahrestan (Shahrestan,Ocode) values(?,?)"
            Dim Cn As New OleDbConnection
            Cn.ConnectionString = StrCon
            Dim Cmd As New OleDbCommand
            Cmd.Connection = Cn
            Cmd.CommandText = Insert_Str
            Dim dr As DataRow
            dr = OstanDv.Item(OstanBindingSource.Position).Row
            Dim s As String = ShahrDataGrid.CurrentRow.Cells(0).Value
            Cmd.Parameters.Add("@Shahrestan", OleDbType.VarWChar).Value = s
            Cmd.Parameters.Add("@OCode", OleDbType.Integer).Value = dr.ItemArray(0)
            Cn.Open()
            Cmd.ExecuteNonQuery()
            Cn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Private Sub Shahr_Update()
        Try
            Me.Validate()
            ShahrBindingSource.EndEdit()
            Dim dr As DataRow
            dr = SharDv.Item(ShahrBindingSource.Position).Row
            Dim Update_Str As String = "Update TShahrestan set Shahrestan=? where Shcode=?"
            Dim Cn As New OleDbConnection
            Dim Cmd As New OleDbCommand
            Cn.ConnectionString = StrCon
            Cmd.Connection = Cn
            Cmd.CommandText = Update_Str
            Cmd.Parameters.Add("@Shahrestan", OleDbType.VarWChar).Value = ShahrDataGrid.CurrentRow.Cells(0).Value
            Cmd.Parameters.Add("@Shcode", OleDbType.Integer).Value = dr.ItemArray(0)
            Cn.Open()
            Cmd.ExecuteNonQuery()
            Cn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub OstanBindingSource_PositionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OstanBindingSource.PositionChanged
        Try
            Call Shahr_Select()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub OstanDataGrid_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles OstanDataGrid.CellValueChanged
        If OstanFlag = True Then
            If AddNewOstan = False Then
                Call Ostan_Update()
                Call Ostan_Select()
            End If
        End If
    End Sub
    Private Sub OstanDataGrid_RowLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles OstanDataGrid.RowLeave
        If AddNewOstan = True Then
            Me.Validate()
            OstanBindingSource.EndEdit()
            Dim j As Integer = OstanBindingSource.Position + 1
            Dim i As Integer = OstanBindingSource.Find("Ostan", Trim(OstanDataGrid.CurrentRow.Cells(1).Value))
            If i < j Then
                AddNewOstan = False
                OstanBindingSource.RemoveCurrent()
                OstanBindingSource.Position = i
                MsgBox("استان مورد نظر قبلاً وارد شده است")
                OstanBindingSource.Position = i
            Else
                Call Ostan_Insert()
                AddNewOstan = False
                Call Ostan_Select()
            End If
        End If
    End Sub
    Private Sub OstanDataGrid_UserAddedRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles OstanDataGrid.UserAddedRow
        If e.Row.IsNewRow Then
            AddNewOstan = True
        End If
    End Sub

    Private Sub ShahrDataGrid_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ShahrDataGrid.CellValueChanged
        Try
            If ShahrFlag = True Then
                If AddNewShahr = False Then
                    Call Shahr_Update()
                    Call Shahr_Select()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub ShahrDataGrid_RowLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ShahrDataGrid.RowLeave
        Try
            If AddNewShahr = True Then
                Me.Validate()
                ShahrBindingSource.EndEdit()
                Dim j As Integer = ShahrBindingSource.Position
                Dim Shahr As String = Trim(ShahrDataGrid.CurrentRow.Cells(0).Value)
                Dim i As Integer = ShahrBindingSource.Find("Shahrestan", Shahr)
                If i < j Then
                    AddNewShahr = False
                    ShahrBindingSource.RemoveCurrent()
                    ShahrBindingSource.Position = i
                    MsgBox("شهر مورد نظر قبلاً وارد شده است")
                    ShahrBindingSource.Position = i
                Else
                    Call Shahr_Insert()
                    AddNewShahr = False
                    Call Shahr_Select()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub ShahrDataGrid_UserAddedRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles ShahrDataGrid.UserAddedRow
        If e.Row.IsNewRow Then
            AddNewShahr = True
        End If
    End Sub

    Private Sub OstanAndShahBaseFrm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Ostanflag1 = True
    End Sub
End Class