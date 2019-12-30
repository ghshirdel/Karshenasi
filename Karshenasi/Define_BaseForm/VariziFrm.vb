Imports System
Imports System.Data
Imports System.Data.OleDb
Public Class VariziFrm
    Dim Vdv As DataView
    Dim AddNew As Boolean = False
    Dim BFlag As Boolean = False
    Private Sub VariziFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Varizi_Select()
    End Sub
    Private Sub Varizi_Select()
        Try
            Dim Cn As New oledbConnection
            Cn.ConnectionString = StrCon
            Dim da As New oledbDataAdapter("Select * from Varizi_Define Order By VName", Cn)
            Dim ds As New DataSet
            da.Fill(ds)
            Vdv = New DataView(ds.Tables(0))
            VariziBs.DataSource = Vdv
            BankDataGrid.DataSource = VariziBs
            BFlag = True
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub Varizi_Insert()
        Try
            Dim Cn As New oledbConnection
            Dim Cmd As New oledbCommand
            Me.Validate()
            VariziBs.EndEdit()
            Cn.ConnectionString = StrCon
            Cmd.CommandText = "Insert into Varizi_define (Vname) values('" & BankDataGrid.CurrentRow.Cells(0).Value & "')"
            Cmd.Connection = Cn
            Cn.Open()
            Cmd.ExecuteNonQuery()
            Cn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub Varizi_Update()
        Try
            Dim dr As DataRow = Vdv.Item(VariziBs.Position).Row
            Dim Cn As New oledbConnection
            Dim Cmd As New oledbCommand
            Cn.ConnectionString = StrCon
            Cmd.CommandText = "Update Varizi_define set Vname='" & BankDataGrid.CurrentRow.Cells(0).Value & "' where V_Id =" & dr.ItemArray(0)
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
        If BFlag = True Then
            If AddNew = True Then
                Call Varizi_Insert()
                AddNew = False
                Call Varizi_Select()
            End If
        End If
    End Sub
    Private Sub BankDataGrid_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles BankDataGrid.CellValueChanged
        If BFlag = True Then
            If AddNew = False Then
                Call Varizi_Update()
                Call Varizi_Select()
            End If
        End If
    End Sub

    Private Sub BankDataGrid_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BankDataGrid.Enter
        InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(New System.Globalization.CultureInfo("fa"))
    End Sub

    Private Sub BankDataGrid_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BankDataGrid.Leave
        InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(New Globalization.CultureInfo("en"))
    End Sub
End Class