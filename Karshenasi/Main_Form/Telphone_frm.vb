Imports System
Imports System.Data
Imports System.Data.OleDb
Public Class Telphone_frm
    Dim Tel_dv As DataView
    Dim AdNew As Boolean = False
    Dim Tel_flag As Boolean = False
    Dim Tel_select_flag As Boolean = False
    Dim KsId As Integer
    Dim Cn As New OleDbConnection
    Public Property Ksid_get()
        Get
            Return 0
        End Get
        Set(ByVal value)
            KsId = value
        End Set
    End Property

    Private Sub StatusStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StatusStripButton1.Click
        Me.Close()
    End Sub

    Private Sub Telphone_frm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Telphone_frm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Select_gata()
    End Sub

    Private Sub Select_gata()
        Tel_select_flag = False
        Dim Cn As New OleDbConnection
        Cn.ConnectionString = StrCon
        Dim da As New OleDbDataAdapter("Select * from Tel_unit where KsId=" & KsId, Cn)
        Dim ds As New DataSet
        da.Fill(ds)
        Tel_dv = New DataView(ds.Tables(0))
        Tel_BindingSource.DataSource = Tel_dv
        Tel_select_flag = True
    End Sub

    Private Sub Tel_DataGrid_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Tel_DataGrid.CellValueChanged
        If AdNew = False And Tel_select_flag = True Then
            Me.Validate()
            Tel_BindingSource.EndEdit()
            Try
                Dim dr As DataRow = Tel_dv.Item(Tel_BindingSource.Position).Row
                Cn.ConnectionString = StrCon
                Dim Cmd As New OleDbCommand
                Cmd.Connection = Cn
                Cmd.CommandText = "update Tel_unit set Tell_Number=? where Tel_Id=?"
                Cmd.Parameters.Add("Tell_Number", OleDbType.VarWChar).Value = Tel_DataGrid.CurrentRow.Cells(0).Value
                Cmd.Parameters.Add("KsId", OleDbType.Integer).Value = dr.ItemArray(0)
                Cn.Open()
                Cmd.ExecuteNonQuery()
                Cn.Close()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If
    End Sub

    Private Sub Tel_DataGrid_RowLeave(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Tel_DataGrid.RowLeave
        If AdNew = True And Tel_select_flag = True Then
            Me.Validate()
            Tel_BindingSource.EndEdit()
            Try
                Cn.ConnectionString = StrCon
                Dim Cmd As New OleDbCommand
                Cmd.Connection = Cn
                Cmd.CommandText = "Insert into Tel_unit (Ksid,Tell_Number) values(?,?)"
                Cmd.Parameters.Add("KsId", OleDbType.Integer).Value = KsId
                Cmd.Parameters.Add("Tel_Number", OleDbType.VarWChar).Value = Tel_DataGrid.CurrentRow.Cells(0).Value
                Cn.Open()
                Cmd.ExecuteNonQuery()
                Cn.Close()
                AdNew = False
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If
    End Sub

    Private Sub Tel_DataGrid_UserAddedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles Tel_DataGrid.UserAddedRow
        If e.Row.IsNewRow Then
            AdNew = True
        End If
    End Sub
End Class