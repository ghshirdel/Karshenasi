Imports System
Imports System.Data
Imports System.Data.OleDb
Public Class DefKarbariFrm
    Dim dv, Type_Kar_dv As DataView
    Dim setKarFlag As Boolean = False
    Dim Set_Type_Kar_Flag As Boolean = False
    Dim AddNew, TKar_AddNew As Boolean
    Private Sub DefKarbariFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AddNew = False
        TKar_AddNew = False
        Call Select_Karbari()
        Call Select_Type_Karshenasi()
    End Sub
    Private Sub Select_Karbari()
        Try
            Dim Cn As New OleDbConnection
            Cn.ConnectionString = StrCon
            Dim da As New OleDbDataAdapter("Select * from BaseKarbariTable", Cn)
            Dim ds As New DataSet
            da.Fill(ds)
            dv = New DataView(ds.Tables(0))
            KarbariBindingSource.DataSource = dv
            DataGridView1.DataSource = KarbariBindingSource
            setKarFlag = True
            If dv.Table.Rows.Count > 0 Then
                Call Select_Type_Karshenasi()
            Else
                Type_kar_BindingSource.DataSource = Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub DataGridView1_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        If setKarFlag = True Then
            If AddNew = False Then
                Try
                    Dim Update_str As String = "Update BaseKarbariTable set Karbari=? where KarId=?"
                    Dim Cn As New OleDbConnection
                    Cn.ConnectionString = StrCon
                    Dim Cmd As New OleDbCommand
                    Dim dr As DataRow = dv.Item(Me.KarbariBindingSource.Position).Row
                    Me.Validate()
                    Me.KarbariBindingSource.EndEdit()
                    Cmd.Parameters.Add("@Karbari", OleDbType.VarWChar).Value = DataGridView1.CurrentRow.Cells(1).Value
                    Cmd.Parameters.Add("@KarId", OleDbType.VarWChar).Value = dr.ItemArray(0)
                    Cmd.Connection = Cn
                    Cmd.CommandText = Update_str
                    Cn.Open()
                    Cmd.ExecuteNonQuery()
                    Cn.Close()
                    Call Select_Karbari()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            End If
        End If
    End Sub

    Private Sub DataGridView1_RowLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.RowLeave
        If AddNew = True Then
            Try
                Dim Insert_Str As String = "Insert into BaseKarbariTable (karbari) values(?)"
                Dim Cn As New OleDbConnection
                Dim Cmd As New OleDbCommand
                Cn.ConnectionString = StrCon
                Cmd.CommandText = Insert_Str
                Cmd.Connection = Cn
                Me.Validate()
                Me.KarbariBindingSource.EndEdit()
                Cmd.Parameters.Add("@Karbari", OleDbType.VarWChar).Value = DataGridView1.CurrentRow.Cells(1).Value
                Cn.Open()
                Cmd.ExecuteNonQuery()
                Cn.Close()
                AddNew = False
                Call Select_Karbari()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If
    End Sub

    Private Sub DataGridView1_UserAddedRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles DataGridView1.UserAddedRow
        If e.Row.IsNewRow Then
            AddNew = True
        End If
    End Sub

    Private Sub Select_Type_Karshenasi()
        Try
            Set_Type_Kar_Flag = False
            Dim dr As DataRow = dv.Item(KarbariBindingSource.Position).Row
            If dr.ItemArray(0) IsNot DBNull.Value Then
                Dim Cn As New OleDbConnection
                Cn.ConnectionString = StrCon
                Dim da As New OleDbDataAdapter("Select * From Type_Karshenasi Where KarId =" & dr.ItemArray(0), Cn)
                Dim ds As New DataSet
                da.Fill(ds)
                Type_Kar_dv = New DataView(ds.Tables(0))
                Type_kar_BindingSource.DataSource = Type_Kar_dv
                Type_Kar_DataGrid.DataSource = Type_kar_BindingSource
            Else
                Type_kar_BindingSource.DataSource = Nothing
            End If
            Set_Type_Kar_Flag = True
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub KarbariBindingSource_PositionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KarbariBindingSource.PositionChanged
        If AddNew = False Then
            Call Select_Type_Karshenasi()
        End If
    End Sub

    Private Sub Type_Kar_DataGrid_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Type_Kar_DataGrid.CellValueChanged
        Try
            If TKar_AddNew = False And Set_Type_Kar_Flag = True Then
                Dim dr As DataRow = Type_Kar_dv.Item(Type_kar_BindingSource.Position).Row
                Me.Validate()
                Me.Type_kar_BindingSource.EndEdit()
                Dim Cn As New OleDbConnection
                Cn.ConnectionString = StrCon
                Dim Cmd As New OleDbCommand
                Cmd.Connection = Cn

                Cmd.CommandText = "Update Type_Karshenasi set Type_Kar_Desc= ?,Not_Price=? where Type_Kar_Id=?"
                Cmd.Parameters.Add("@Type_Kar_Desc", OleDbType.VarWChar).Value = dr.ItemArray(2)
                Cmd.Parameters.Add("@Not_Price", OleDbType.Boolean).Value = dr.ItemArray(1)
                Cmd.Parameters.Add("@Type_Kar_Id", OleDbType.Integer).Value = dr.ItemArray(0)
                TKar_AddNew = False
                Cn.Open()
                Cmd.ExecuteNonQuery()
                Cn.Close()
                Call Select_Type_Karshenasi()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub Type_Kar_DataGrid_RowLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Type_Kar_DataGrid.RowLeave
        Try
            If TKar_AddNew = True And Set_Type_Kar_Flag = True Then
                Dim dr As DataRow = dv.Item(KarbariBindingSource.Position).Row
                Me.Validate()
                Me.Type_kar_BindingSource.EndEdit()
                Dim Cn As New OleDbConnection
                Cn.ConnectionString = StrCon
                Dim Cmd As New OleDbCommand
                Cmd.Connection = Cn
                Cmd.CommandText = "Insert into Type_Karshenasi (Type_Kar_Desc,KarId,Not_Price) values(?,?,?)"
                Cmd.Parameters.Add("@Type_Kar_Desc", OleDbType.VarWChar).Value = Type_Kar_DataGrid.CurrentRow.Cells(0).Value
                Cmd.Parameters.Add("@KarId", OleDbType.Integer).Value = dr.ItemArray(0)
                Cmd.Parameters.Add("@Not_Price", OleDbType.Integer).Value = Type_Kar_DataGrid.CurrentRow.Cells(1).Value

                Cn.Open()
                Cmd.ExecuteNonQuery()
                Cn.Close()
                TKar_AddNew = False
                Call Select_Type_Karshenasi()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub DefKarbariFrm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Karbariflag = True
    End Sub

    Private Sub Type_Kar_DataGrid_UserAddedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles Type_Kar_DataGrid.UserAddedRow
        If e.Row.IsNewRow Then
            TKar_AddNew = True
        End If
    End Sub

    Private Sub DefKarbariFrm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class