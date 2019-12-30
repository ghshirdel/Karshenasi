Imports System
Imports System.Data
Imports System.Data.OleDb
Public Class BankDefineFrm
    Dim bdv As DataView
    Dim AddNew As Boolean = False
    Dim BFlag As Boolean = False
    Private Sub BankDefineFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Bank_Select()
    End Sub
    Private Sub Bank_Select()
        Try
            Dim Cn As New OleDbConnection
            Cn.ConnectionString = StrCon
            Dim da As New OleDbDataAdapter("Select * from Bank_define Order By bank", Cn)
            Dim ds As New DataSet
            da.Fill(ds)
            bdv = New DataView(ds.Tables(0))
            BankBs.DataSource = bdv
            BankDataGrid.DataSource = BankBs
            BFlag = True
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub Bank_Insert()
        Try
            Dim Cn As New OleDbConnection
            Dim Cmd As New OleDbCommand
            Me.Validate()
            BankBs.EndEdit()
            Cn.ConnectionString = StrCon
            Cmd.CommandText = "Insert into Bank_define (Bank) values('" & BankDataGrid.CurrentRow.Cells(0).Value & "')"
            Cmd.Connection = Cn
            Cn.Open()
            Cmd.ExecuteNonQuery()
            Cn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub Bank_Update()
        Try
            Dim dr As DataRow = bdv.Item(BankBs.Position).Row
            Dim Cn As New OleDbConnection
            Dim Cmd As New OleDbCommand
            Cn.ConnectionString = StrCon
            Cmd.CommandText = "Update Bank_define set Bank='" & BankDataGrid.CurrentRow.Cells(0).Value & "' where B_Id=" & dr.ItemArray(0)
            Cmd.Connection = Cn
            Cn.Open()
            Cmd.ExecuteNonQuery()
            Cn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub BankDataGrid_UserAddedRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles BankDataGrid.UserAddedRow
        If e.Row.IsNewRow Then
            AddNew = True
        End If
    End Sub
    Private Sub BankDataGrid_RowLeave(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles BankDataGrid.RowLeave
        If AddNew = True Then
            Call Bank_Insert()
            AddNew = False
            Call Bank_Select()
        End If
    End Sub
    Private Sub BankDataGrid_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles BankDataGrid.CellValueChanged
        If BFlag = True Then
            If AddNew = False Then
                Call Bank_Update()
                Call Bank_Select()
            End If
        End If
    End Sub

    Private Sub BankDataGrid_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BankDataGrid.Enter
        InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(New System.Globalization.CultureInfo("Fa"))

    End Sub

    Private Sub BankDataGrid_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BankDataGrid.Leave
        InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(New System.Globalization.CultureInfo("En"))
    End Sub
End Class