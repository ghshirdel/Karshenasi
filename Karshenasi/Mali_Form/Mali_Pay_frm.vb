Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.Drawing
Public Class Mali_Pay_frm
    Dim Kid As Integer
    Dim Mali_dv, Bank_dv, Varizi_dv As DataView
    Dim Bank_flag, Varizi_flag, adNew, Select_Pay_flag As Boolean
    Dim Start_flag As Boolean = False
    Dim Set_Update_flag As Boolean = False
    Dim Set_Insert_flag As Boolean = False
    Dim Remain_wage, wage As Integer
    Dim Obj(9) As Object
    Dim Pos As Integer = -1
    Public Property Mali_get_Kid()
        Get
            Return 0
        End Get
        Set(ByVal value)
            Kid = value
        End Set
    End Property

    Public Property Mali_get_Wage()
        Get
            Return Remain_wage
        End Get
        Set(ByVal value)
            Wage_txt.Text = value
            If Wage_txt.Text <> "" Then
                Wage_txt.Text = IIf(Wage_txt.Text = "", "", Format(CDbl(Wage_txt.Text), "#,##0"))
            End If
        End Set
    End Property

    Private Sub Mali_Pay_frm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Private Sub Mali_Pay_frm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Visible = False
        Me.MaximizedBounds = Screen.PrimaryScreen.Bounds
        ' Date_Panel.SendToBack()
        InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(New System.Globalization.CultureInfo("fa"))
        Select_Pay_flag = False
        Varizi_flag = False
        Bank_flag = False
        adNew = False
        Call Bank_Select()
        Call Varizi_Select()
        Pay_datagrid.Visible = True
        Call Select_Payments()
        'Dim C As New TAPI3Lib.RequestMakeCall
        'C.MakeCall(TextBox1.Text, "home", "0", "none")
        Start_flag = True
    End Sub
    Private Sub Select_Payments()
        Select_Pay_flag = False
        Dim Cn As New OleDbConnection
        Cn.ConnectionString = StrCon
        Dim da As New OleDbDataAdapter("Select * from Mali where Kid=" & Kid, Cn)
        Dim ds As New DataSet
        da.Fill(ds)
        Mali_dv = New DataView(ds.Tables(0))
        If Mali_dv.Table.Rows.Count > 0 Then
            Mali_BindingSource.DataSource = Mali_dv
            Pay_datagrid.DataSource = Mali_BindingSource
            Dim j As Integer = 0
            For j = 0 To Mali_BindingSource.Count - 1
                Pay_datagrid.Rows(j).Cells(0).Value = j + 1
            Next
        End If
        Call Pay_remain()
        Select_Pay_flag = True

    End Sub

    Private Sub Varizi_Select()
        Try
            Dim Cn As New OleDbConnection
            Cn.ConnectionString = StrCon
            Dim da As New OleDbDataAdapter("Select * from Varizi_define Order By VName", Cn)
            Dim ds As New DataSet
            da.Fill(ds)
            Varizi_dv = New DataView(ds.Tables(0))
            Varizi_BindingSource.DataSource = Varizi_dv
            Varizi_flag = True
            Column3.DataSource = Varizi_BindingSource
            Column3.DisplayMember = "VName"
            Column3.ValueMember = "Vname"
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Bank_Select()
        Try
            Dim Cn As New OleDbConnection
            Cn.ConnectionString = StrCon
            Dim da As New OleDbDataAdapter("Select * from Bank_define Order By Bank", Cn)
            Dim ds As New DataSet
            da.Fill(ds)
            Bank_dv = New DataView(ds.Tables(0))
            Bank_BindingSource.DataSource = Bank_dv
            Bank_flag = True
            Column4.DataSource = Bank_BindingSource
            Column4.DisplayMember = "Bank"
            Column4.ValueMember = "Bank"
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub Pay_remain()
        Dim Cn As New OleDbConnection
        Cn.ConnectionString = StrCon
        Dim da As New OleDbDataAdapter("SELECT Mali.Kid, Sum(Mali.Payment) AS Sum_Pay FROM Mali WHERE Kid=" & Kid & " and Pay_back = false and Pay_Exchange = false GROUP BY Mali.Kid", Cn)
        Dim ds As New DataSet
        da.Fill(ds)
        Dim dv As New DataView(ds.Tables(0))
        If dv.Table.Rows.Count > 0 Then
            Dim dr As DataRow = dv.Item(0).Row
            If dr.ItemArray(0) IsNot Nothing And dr.ItemArray(1) IsNot DBNull.Value Then
                Remain_wage = Wage_txt.Text - dr.ItemArray(1)
                Call Save_Remain_wage()
                Remain_txt.Text = Format(CDbl(Remain_wage), "#,##0")
                Sum_Pay.Text = Format(CDbl(dr.ItemArray(1)), "#,##0")
            End If
        Else
            If Wage_txt.Text <> "" Then
                Remain_wage = Wage_txt.Text
            End If
            Remain_txt.Text = Wage_txt.Text
        End If
    End Sub

    Private Sub Save_Remain_wage()
        Dim Cn As New OleDbConnection
        Cn.ConnectionString = StrCon
        Dim Cmd As New OleDbCommand
        Cmd.Connection = Cn
        Cmd.CommandText = "Update MainKTable Set Remain_Wage=" & Remain_wage & " Where KId=" & Kid
        Cn.Open()
        Cmd.ExecuteNonQuery()
        Cn.Close()
    End Sub

    Private Sub Update_datagrid()
        Try
            If Select_Pay_flag = True And adNew = False Then
                Me.Validate()
                Me.Mali_BindingSource.EndEdit()
                Dim dr As DataRow = Mali_dv.Item(Mali_BindingSource.Position).Row
                With Pay_datagrid.CurrentRow
                    Obj(0) = .Cells(1).Value
                    Obj(1) = .Cells(2).Value
                    Obj(2) = .Cells(3).Value
                    Obj(3) = .Cells(4).Value
                    Obj(4) = .Cells(5).Value
                    Obj(5) = .Cells(6).Value
                    Obj(6) = IIf(.Cells(7).Value Is Nothing, 0, .Cells(7).Value)
                    Obj(7) = IIf(.Cells(8).Value Is Nothing, 0, .Cells(8).Value)
                    Obj(8) = IIf(.Cells(9).Value Is Nothing, 0, .Cells(9).Value)
                    If Obj(8) = True Or Obj(7) = True Then
                        Obj(6) = False
                    End If
                    Obj(9) = dr.ItemArray(0)
                End With
                Dim Cn As New OleDbConnection
                Cn.ConnectionString = StrCon
                Dim Cmd As New OleDbCommand
                Cmd.Connection = Cn
                Cmd.CommandText = "Update Mali set Pay_type=?,Pay_No=?,Pay_Bank=?,Pay_Shoabe=?," & _
                                  "Pay_date=?,Payment=?,Pay_Pass=?,Pay_Back=?,Pay_Exchange=?" & _
                                  " where Pay_id=?"
                With Pay_datagrid.CurrentRow
                    Cmd.Parameters.Add("@Pay_type", OleDbType.VarWChar).Value = Obj(0)
                    Cmd.Parameters.Add("@Pay_No", OleDbType.VarWChar).Value = Obj(1)
                    Cmd.Parameters.Add("@Pay_Bank", OleDbType.VarWChar).Value = Obj(2)
                    Cmd.Parameters.Add("@Pay_Shoabe", OleDbType.VarWChar).Value = Obj(3)
                    Cmd.Parameters.Add("@Pay_date", OleDbType.VarWChar).Value = Obj(4)
                    Cmd.Parameters.Add("@Payment", OleDbType.Integer).Value = Obj(5)
                    Cmd.Parameters.Add("@Pay_Pass", OleDbType.Boolean).Value = Obj(6)
                    Cmd.Parameters.Add("@Pay_Back", OleDbType.Boolean).Value = Obj(7)
                    Cmd.Parameters.Add("@Pay_Exchange", OleDbType.Boolean).Value = Obj(8)
                    Cmd.Parameters.Add("@Pay_id", OleDbType.Integer).Value = Obj(9)
                End With
                Cn.Open()
                Cmd.ExecuteNonQuery()
                Cn.Close()
                Call Select_Payments()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub Insert_datagrid()
        Try
            If adNew = True And Select_Pay_flag = True Then
                Me.Validate()
                Me.Mali_BindingSource.EndEdit()
                With Pay_datagrid.CurrentRow
                    Obj(0) = .Cells(1).Value
                    Obj(9) = Kid
                End With
                Dim Cn As New OleDbConnection
                Cn.ConnectionString = StrCon
                Dim Cmd As New OleDbCommand
                Cmd.Connection = Cn
                Cmd.CommandText = "Insert into Mali(Pay_type,Kid)" & _
                                  "Values(?,?)"
                With Pay_datagrid.CurrentRow
                    Cmd.Parameters.Add("@Pay_type", OleDbType.VarWChar).Value = Obj(0)
                    Cmd.Parameters.Add("@Kid", OleDbType.Integer).Value = Obj(9)
                End With
                Cn.Open()
                Cmd.ExecuteNonQuery()
                Cn.Close()
                adNew = False
                Set_Insert_flag = False
                Call Select_Payments()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Pay_datagrid_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles Pay_datagrid.CellBeginEdit

    End Sub

    Private Sub Pay_datagrid_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Pay_datagrid.CellContentClick
        If e.ColumnIndex > 6 And adNew = False Then
            Call Update_datagrid()
            Call Select_Payments()
        End If
    End Sub

    Private Sub Pay_datagrid_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Pay_datagrid.CellMouseClick
        If e.ColumnIndex = 6 Then
            Dim x1 As Integer = Screen.PrimaryScreen.WorkingArea.Width
            x1 = (x1 - Me.Width) / 2
            Dim X, y As Integer
            X = Pay_datagrid.CurrentCell.AccessibilityObject.Bounds.X - x1 - 3
            y = Pay_datagrid.CurrentCell.AccessibilityObject.Bounds.Y - Me.Location.Y - Pay_datagrid.CurrentCell.Size.Height - 4
            TextBox1.Location = New Point(X, y)
            TextBox1.Visible = True
            TextBox1.Text = IIf(Pay_datagrid.CurrentCell.Value Is DBNull.Value, "", Pay_datagrid.CurrentCell.Value)
            TextBox1.Focus()
        Else
            If TextBox1.Visible = True Then
                TextBox1.Visible = False
            End If
        End If
        If e.ColumnIndex = 5 Then
            Dim x1 As Integer = Screen.PrimaryScreen.WorkingArea.Width
            x1 = (x1 - Me.Width) / 2
            Dim X, y As Integer
            X = Pay_datagrid.CurrentCell.AccessibilityObject.Bounds.X - Pay_datagrid.CurrentCell.Size.Width + 30 ' - x1
            y = Pay_datagrid.CurrentCell.AccessibilityObject.Bounds.Y + Pay_datagrid.CurrentCell.Size.Height ' - Me.Location.Y '- 6
            Dim Date_Obj(4) As Object
            Date_Obj(0) = X
            Date_Obj(1) = y
            Date_Obj(2) = Pay_datagrid.CurrentRow.Cells(5).Value
            Dim Date_frm As New WDate_fa_frm
            Date_frm.Get_Date = Date_Obj
            Date_frm.Show()
            'Date_Panel.Location = New Point(X, y)
            'Date_Panel.Visible = True
            'Date_Panel.BringToFront()
            'Date_Fa.Focus()
        End If
    End Sub

    Private Sub Pay_datagrid_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Pay_datagrid.CellValueChanged
        If Start_flag = True Then
            If e.ColumnIndex > 1 Then
                With Pay_datagrid.CurrentRow
                    If adNew = False And .Cells(1).Value IsNot DBNull.Value Then
                        Call Update_datagrid()
                    Else
                        Mali_BindingSource.EndEdit()
                        Pay_datagrid.Rows.RemoveAt(Mali_BindingSource.Position)
                    End If
                End With
            End If
        End If
        If e.ColumnIndex = 1 Then
            Call Insert_datagrid()
        End If
    End Sub

    Private Sub Pay_datagrid_UserAddedRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles Pay_datagrid.UserAddedRow
        If e.Row.IsNewRow Then
            adNew = True
            Pos = Mali_BindingSource.Position
            Pay_datagrid.CurrentRow.Cells(0).Value = Mali_BindingSource.Position + 1
        End If
    End Sub

    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TextBox1.Text <> "" Then
                Pay_datagrid.CurrentRow.Cells(6).Value = CDbl(TextBox1.Text)
                TextBox1.Visible = False
                Pay_datagrid.Focus()
                'Pay_datagrid.BeginEdit(True)
            End If
        End If
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text <> "" Then
            TextBox1.Text = Format(Val(TextBox1.Text.Trim.Replace(",", "")), "#,0")
            TextBox1.SelectionStart = TextBox1.TextLength
        End If
    End Sub

    Private Sub Wage_txt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Wage_txt.TextChanged
        If Wage_txt.Text <> "" Then
            Wage_txt.Text = Format(Val(Wage_txt.Text.Trim.Replace(",", "")), "#,0")
            Wage_txt.SelectionStart = Wage_txt.TextLength
        End If
    End Sub
End Class