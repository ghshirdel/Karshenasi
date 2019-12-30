Imports System.IO
Imports System.Data.OleDb
Public Class AddPriceKarshenasi_frm
    Dim Type_Kar_dv As DataView
    Dim dr As DataRow
    Dim Price_dr As DataRow
    Dim Cn As New OleDbConnection
    Private Sub PriceBtn_Click(sender As Object, e As EventArgs) Handles PriceBtn.Click
        Try
            If NewFlag Then
                Call Insert_Karshenasi_Price()
            Else
                Call Update_Karshenasi_Price()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Me.Close()
    End Sub
    Private Sub PriceKarshenasi_Select()
        Try
            Cn.ConnectionString = StrCon
            Dim da As New OleDbDataAdapter("Select * From Type_Karshenasi Where KarId =" & KarId, Cn)
            Dim ds As New DataSet
            da.Fill(ds)
            Type_Kar_dv = New DataView(ds.Tables(0))
            BindingSource1.DataSource = Type_Kar_dv
            ComboBox1.DataSource = BindingSource1
            ComboBox1.DisplayMember = "Type_Kar_Desc"
            ComboBox1.ValueMember = "Type_Kar_Id"
            If NewFlag = False Then
                Call FillTextBox()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub AddPriceKarshenasi_frm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        KarId = 0
        NewFlag = False
    End Sub
    Private Sub FillTextBox()
        Cn.ConnectionString = StrCon
        Dim da_p As New OleDbDataAdapter("Select * from Price_Karshenasi Where KPrice_Id =" & PkId, Cn)
        Dim ds_p As New DataSet
        da_p.Fill(ds_p)
        Dim KPrice_dv1 = New DataView(ds_p.Tables(0))
        BindingSource3.DataSource = KPrice_dv1
        Price_dr = KPrice_dv1.Item(BindingSource3.Position).Row
        TextBox1.Text = Price_dr.ItemArray(3).ToString
        If Price_dr.ItemArray(4) = True Then
            CheckBox1.Checked = True
        Else
            CheckBox1.Checked = False
        End If
        TextBox2.Text = Price_dr.ItemArray(5).ToString
    End Sub
    Private Sub Update_Karshenasi_Price()
        Try
            Me.Validate()
            BindingSource3.EndEdit()
            Cn.ConnectionString = StrCon
            Dim Cmd As New OleDbCommand
            Cmd.Connection = Cn
            Cmd.CommandText = "UPDATE  Price_Karshenasi SET Type_Kar_Id=?,Price=?,Not_Price=?,Wage=? WHERE KPrice_Id=?"
            Cmd.Parameters.Add("@Type_Kar_Id", OleDbType.Integer).Value = ComboBox1.SelectedValue
            Cmd.Parameters.Add("@Price", OleDbType.Double).Value = IIf(TextBox1.Text.Trim <> "", Convert.ToDouble(TextBox1.Text), DBNull.Value)
            Cmd.Parameters.Add("@Not_Price", OleDbType.Boolean).Value = IIf(CheckBox1.Checked, True, DBNull.Value)
            Cmd.Parameters.Add("@Wage", OleDbType.Double).Value = IIf(TextBox2.Text.Trim <> "", Convert.ToDouble(TextBox2.Text), DBNull.Value)
            Cmd.Parameters.Add("@KPrice_Id", OleDbType.Integer).Value = PkId

            Cn.Open()
            Cmd.ExecuteNonQuery()
            Cn.Close()
            PkId = 0
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub Insert_Karshenasi_Price()
        Cn.ConnectionString = StrCon
        Dim Str As String = "Insert into Price_Karshenasi (KId,Type_Kar_Id,Price,Not_Price,Wage) values(?,?,?,?,?)"
        Dim Cmd As New OleDbCommand(Str, Cn)
        dr = Type_Kar_dv.Item(BindingSource1.Position).Row
        Cmd.Parameters.Add("@KId", OleDbType.Integer).Value = Kid
        Cmd.Parameters.Add("@Type_Kar_Id", OleDbType.Integer).Value = Convert.ToInt32(dr.ItemArray(0))
        Cmd.Parameters.Add("@Price", OleDbType.Double).Value = IIf(TextBox1.Text.Length <> 0, Convert.ToDouble(TextBox1.Text), DBNull.Value)
        Cmd.Parameters.Add("@Not_Price", OleDbType.Boolean).Value = IIf(CheckBox1.Checked, True, DBNull.Value)
        Cmd.Parameters.Add("@Wage", OleDbType.Double).Value = IIf(TextBox2.Text.Length <> 0, TextBox2.Text, DBNull.Value)
        Cn.Open()
        Cmd.ExecuteNonQuery()
        Cn.Close()
        PkId = 0
    End Sub
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Try
            If TextBox1.Text <> "" Then
                TextBox1.Text = Format(CDbl(TextBox1.Text.Trim.Replace(",", "")), "#,0")
                TextBox1.SelectionStart = TextBox1.TextLength
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        Try
            If TextBox2.Text <> "" Then
                TextBox2.Text = Format(CDbl(TextBox2.Text.Trim.Replace(",", "")), "#,0")
                TextBox2.SelectionStart = TextBox2.TextLength
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub AddPriceKarshenasi_frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call PriceKarshenasi_Select()
    End Sub
End Class