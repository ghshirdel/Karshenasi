Imports System
Imports System.Data
Imports System.Data.OleDb
Public Class Remain_Kar_frm
    Dim R_dv As DataView
    Private Sub Reamin_Kar_frm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Select_Rimain_data()
    End Sub
    Private Sub Select_Rimain_data()
        Dim Cn As New OleDbConnection
        Cn.ConnectionString = StrCon
        Dim da As New OleDbDataAdapter("Select * from MainKTable where Remain_wage is not null", Cn)
        Dim R_ds As New DataSet
        da.Fill(R_ds)
        R_dv = New DataView(R_ds.Tables(0))
        Remain_wage_Bs.DataSource = R_dv
        Me.ListDataGrid.DataSource = Remain_wage_Bs
    End Sub

    Private Sub ListDataGrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ListDataGrid.CellContentClick
        If e.ColumnIndex = 1 Then
            Dim kar_frm As New KarshenasiFrm
            Dim dr As DataRow
            dr = R_dv.Item(Remain_wage_Bs.Position).Row
            kar_frm.Get_Data = dr.ItemArray(0)
            kar_frm.ShowDialog()
        End If
    End Sub
End Class