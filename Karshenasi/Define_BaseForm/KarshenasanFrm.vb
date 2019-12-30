Imports System
Imports System.Data
Imports System.Data.OleDb
Public Class KarshenasanFrm
    Dim OstanDv As DataView
    Dim ShahrestanDv As DataView
    Dim KarshenasDv As DataView
    Dim TelDv As DataView

    Dim OstanFlag As Boolean = False
    Dim ShahrestanFlag As Boolean = False
    Dim KarshenasFlag As Boolean = False
    Dim TelFlag As Boolean = False

    Dim AddNewKar As Boolean = False
    Dim AddNewTel As Boolean = False
    Dim db_click As Boolean = False

    Dim SubFilter As String = ""
    Dim i As Integer = -2
    Dim Cn As New OleDbConnection

    Public Property Get_data()
        Get
            Return i
        End Get
        Set(ByVal value)
            i = value
        End Set
    End Property
    Private Sub KarshenasanFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(New System.Globalization.CultureInfo("Fa"))

        CancelBtn.Enabled = False
        Ostan_Select()
        Karshenas_Select()

    End Sub
    Private Sub Ostan_Select()
        Try

            Cn.ConnectionString = StrCon
            Dim da As New OleDbDataAdapter("Select * from Tostan Order by Ostan", Cn)
            Dim ds As New DataSet
            da.Fill(ds)
            OstanDv = New DataView(ds.Tables(0))
            OstanBs.DataSource = OstanDv
            CbOstan.DataSource = OstanBs
            CbOstan.DisplayMember = "Ostan"
            CbOstan.ValueMember = "OCode"
            OstanFlag = True
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub Shahrestan_Select(ByVal Ocode As Integer)
        Try

            Cn.ConnectionString = StrCon
            Dim da As New OleDbDataAdapter("Select * from Tshahrestan where Ocode=" & Ocode & " Order by Shahrestan", Cn)
            Dim ds As New DataSet
            da.Fill(ds)
            ShahrestanDv = New DataView(ds.Tables(0))
            ShahrestanBs.DataSource = ShahrestanDv
            CbShahrestan.DataSource = ShahrestanBs
            CbShahrestan.DisplayMember = "Shahrestan"
            CbShahrestan.ValueMember = "Shcode"
            ShahrestanFlag = True
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub SetKarshenas_DataTo_TextBox()
        If KarshenasFlag = True Then
            If KarshenasBs.Count > 0 Then
                Dim dr As DataRow
                dr = KarshenasDv.Item(KarshenasBs.Position).Row
                CbOstan.Text = dr.ItemArray(2).ToString
                CbShahrestan.Text = dr.ItemArray(4).ToString
                TxtKFName.Text = dr.ItemArray(5).ToString
                TxtKLname.Text = dr.ItemArray(6).ToString
                TxtKNo.Text = dr.ItemArray(7).ToString
                Address_txt.Text = dr.ItemArray(9).ToString
                Type_Kar_Cb.Text = dr.ItemArray(8).ToString
                Call Tel_Select(dr.ItemArray(0))
            End If
        End If
    End Sub
    Private Sub KarshenasBs_PositionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KarshenasBs.PositionChanged
        If KarshenasFlag = True Then
            SetKarshenas_DataTo_TextBox()
        End If
    End Sub
    Private Sub Karshenas_Select()
        Try

            Cn.ConnectionString = StrCon
            Dim da As New OleDbDataAdapter("Select * from KarshenasanTable", Cn)
            Dim ds As New DataSet
            da.Fill(ds)
            KarshenasDv = New DataView(ds.Tables(0))
            KarshenasBs.DataSource = KarshenasDv
            KarshenasiDg.DataSource = KarshenasBs
            If KarshenasDv.Table.Rows.Count > 0 Then
                Dim dr As DataRow
                dr = KarshenasDv.Item(KarshenasBs.Position).Row
                Call Tel_Select(dr.ItemArray(0))
                KarshenasFlag = True
                Call SetKarshenas_DataTo_TextBox()
                If CbShahrestan.Text <> "" Then
                    Call Shahrestan_Select(dr.ItemArray(1))
                End If
                If i >= 0 Then
                    KarshenasBs.MoveFirst()
                    Dim l As Integer = KarshenasBs.Find("K_Id", i)
                    KarshenasBs.Position = l
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub Karshenas_Insert()
        Try
            Me.Validate()
            Me.KarshenasBs.EndEdit()
            Dim Insert_Str As String = "Insert into KarshenasanTable " & _
            "(Ocode,Ostan,Shcode,Shahrestan,KFname,KLname,KNo,Address,Type_kar)" & _
            " values(?,?,?,?,?,?,?,?,?)"

            Cn.ConnectionString = StrCon
            Dim Cmd As New OleDbCommand
            Cmd.CommandText = Insert_Str
            Cmd.Connection = Cn
            Cmd.Parameters.Add("@Ocode", OleDbType.Integer).Value = CbOstan.SelectedValue
            Cmd.Parameters.Add("@Ostan", OleDbType.VarWChar).Value = CbOstan.Text

            Cmd.Parameters.Add("@shcode", OleDbType.Integer).Value = CbShahrestan.SelectedValue
            Cmd.Parameters.Add("@Shahrestan", OleDbType.VarWChar).Value = CbShahrestan.Text

            Cmd.Parameters.Add("@KFname", OleDbType.VarWChar).Value = TxtKFName.Text
            Cmd.Parameters.Add("@KLname", OleDbType.VarWChar).Value = TxtKLname.Text

            Cmd.Parameters.Add("@Address", OleDbType.VarWChar).Value = Address_txt.Text
            Cmd.Parameters.Add("@Type_Kar", OleDbType.VarWChar).Value = Type_Kar_Cb.Text

            Cmd.Parameters.Add("@Kno", OleDbType.VarWChar).Value = TxtKNo.Text
            Cn.Open()
            Cmd.ExecuteNonQuery()
            Cn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub Karshenas_Update()
        Try
            Me.Validate()
            Me.KarshenasBs.EndEdit()
            Dim dr As DataRow = KarshenasDv.Item(Me.KarshenasBs.Position).Row
            Dim Update_Str As String = "Update KarshenasanTable " & _
                                       "set Ocode=?,Ostan=?," & _
                                       "Shcode=?,Shahrestan=?," & _
                                       "KFName=?,KLName=?," & _
                                       "Kno=?,Address=?,Type_Kar=? Where K_id=?"

            Cn.ConnectionString = StrCon
            Dim Cmd As New OleDbCommand
            Cmd.Connection = Cn
            Cmd.CommandText = Update_Str

            Cmd.Parameters.Add("@Ocode", OleDbType.Integer).Value = CbOstan.SelectedValue
            Cmd.Parameters.Add("@Ostan", OleDbType.VarWChar).Value = CbOstan.Text

            Cmd.Parameters.Add("@shcode", OleDbType.Integer).Value = CbShahrestan.SelectedValue
            Cmd.Parameters.Add("@Shahrestan", OleDbType.VarWChar).Value = CbShahrestan.Text

            Cmd.Parameters.Add("@KFname", OleDbType.VarWChar).Value = TxtKFName.Text
            Cmd.Parameters.Add("@KLname", OleDbType.VarWChar).Value = TxtKLname.Text
            Cmd.Parameters.Add("@Kno", OleDbType.VarWChar).Value = TxtKNo.Text

            Cmd.Parameters.Add("@Address", OleDbType.VarWChar).Value = Address_txt.Text
            Cmd.Parameters.Add("@Type_Kar", OleDbType.VarWChar).Value = Type_Kar_Cb.Text

            Cmd.Parameters.Add("@K_Id", OleDbType.Integer).Value = dr.ItemArray(0)

            Cn.Open()
            Cmd.ExecuteNonQuery()
            Cn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub AddBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddBtn.Click
        Call Clear_Textbox()
        AddNewKar = True
        AddBtn.Enabled = False
        CancelBtn.Enabled = True
        TelDg.DataSource = Nothing
    End Sub
    Private Sub Clear_Textbox()
        CbOstan.Text = ""
        CbShahrestan.Text = ""
        TxtKNo.Text = ""
        TxtKFName.Text = ""
        TxtKLname.Text = ""
    End Sub
    Private Sub SaveBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveBtn.Click
        If AddNewKar = True Then
            If CbOstan.SelectedValue = Nothing Or CbShahrestan.SelectedValue = Nothing Then
                MsgBox("باکسهای استان و شهرستان حتماً باید پر شوند")
            Else
                SaveFrm.Show()
                SaveFrm.Refresh()
                AddNewKar = False
                Call Karshenas_Insert()
                Call Karshenas_Select()
                AddBtn.Enabled = True
                CancelBtn.Enabled = False
                SaveFrm.Close()
                KarshenasBs.MoveLast()
            End If
        Else
            Dim i As Integer = Me.KarshenasBs.Position
            Call Karshenas_Update()
            Call Karshenas_Select()
            Me.KarshenasBs.Position = i
        End If
    End Sub

    Private Sub CancelBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelBtn.Click
        AddBtn.Enabled = True
        CancelBtn.Enabled = False
        SetKarshenas_DataTo_TextBox()
    End Sub
    Private Sub Filter_Box()
        Try
            KarshenasBs.RemoveFilter()
            SubFilter = ""
            If TxtFiOstan.Text <> "" Then
                If OstanFlag = True Then
                    If SubFilter <> "" Then
                        SubFilter = SubFilter + " And  "
                        SubFilter = SubFilter + " Ostan Like '%" & TxtFiOstan.Text & "%'"
                    Else
                        SubFilter = SubFilter + " Ostan Like '%" & TxtFiOstan.Text & "%'"
                    End If
                End If
            End If

            If TxtFiShahrestan.Text <> "" Then
                If ShahrestanFlag = True Then
                    If SubFilter <> "" Then
                        SubFilter = SubFilter + " And  "
                        SubFilter = SubFilter + " Shahrestan Like '%" & TxtFiShahrestan.Text & "%'"
                    Else
                        SubFilter = SubFilter + " Shahrestan Like '%" & TxtFiShahrestan.Text & "%'"
                    End If
                End If
            End If

            If TxtFiKCode.Text <> "" Then
                If SubFilter <> "" Then
                    SubFilter = SubFilter + " And  "
                    SubFilter = SubFilter + "KNo ='" + _
                    TxtFiKCode.Text + "'"
                Else
                    SubFilter = SubFilter + "KNo ='" + _
                    TxtFiKCode.Text + "'"
                End If

            End If

            If TxtFiLname.Text <> "" Then
                If SubFilter <> "" Then
                    SubFilter = SubFilter + " And  "
                    SubFilter = SubFilter + "KLName Like'%" + _
                    TxtFiLname.Text + "%'"
                Else
                    SubFilter = SubFilter + "KLName Like'%" + _
                    TxtFiLname.Text + "%'"
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub TxtFiLname_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '    Call Filter_Box()
        '   Me.KarshenasBs.Filter = SubFilter
        '  If KarshenasBs.Position <> -1 Then
        'Call SetKarshenas_DataTo_TextBox()
        'End If
    End Sub
  
    Private Sub KarshenasanFrm_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If AddNewKar = True Then
            CancelBtn.Enabled = False
            AddBtn.Enabled = True
            SetKarshenas_DataTo_TextBox()
        End If
        If db_click = False Then
            i = -2
        End If
    End Sub

    Private Sub TelDg_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If AddNewKar = True Then
            MsgBox("ابتدا باید مشخصات کارشناسان را ذخیره کرده سپس شماره تلفن را وارد کنید")
            TxtFiLname.Focus()
        End If
    End Sub

    Private Sub OstanAndShahrITem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OstanAndShahrITem.Click
        OstanAndShahBaseFrm.ShowDialog()
        Call Ostan_Select()
    End Sub

    Private Sub DeleteBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteBtn.Click
        Try
            If MsgBox("آیا اطلاعات کارشناسی جاری را حذف میکیند؟", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim dr As DataRow
                dr = KarshenasDv.Item(KarshenasBs.Position).Row

                Dim Cmd As New OleDbCommand
                Cn.ConnectionString = StrCon
                Cmd.CommandText = "Delete from KarshenasanTable where K_Id=" & dr.ItemArray(0)
                Cmd.Connection = Cn
                Cn.Open()
                Cmd.ExecuteNonQuery()
                Cn.Close()
                Call Karshenas_Select()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub TelDg_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Delete And e.Control = True Then
            If MsgBox("آیا مطمئن به حذف تلفن ردیف جاری جدول میباشید؟", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim dr As DataRow
                dr = TelDv.Item(TelBs.Position).Row

                Cn.ConnectionString = StrCon
                Dim Cmd As New OleDbCommand
                Cmd.CommandText = "delete From TelTable where Tid=" & dr.ItemArray(0)
                Cmd.Connection = Cn
                Cn.Open()
                Cmd.ExecuteNonQuery()
                Cn.Close()
                Dim Kdr As DataRow
                Kdr = KarshenasDv.Item(KarshenasBs.Position).Row
                Call Tel_Select(Kdr.ItemArray(0))
            End If
        End If
    End Sub
    Private Sub KarshenasiDg_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles KarshenasiDg.CellDoubleClick
        If i <> -2 Then
            Dim Kar_dr As DataRow = KarshenasDv.Item(KarshenasBs.Position).Row
            i = Kar_dr.ItemArray(0)
            db_click = True
            Me.Close()
        End If
    End Sub

    Private Sub Tel_Select(ByVal K_Id As Integer)
        Try

            Cn.ConnectionString = StrCon
            Dim da As New OleDbDataAdapter("Select * from TelTable where K_Id=" & K_Id, Cn)
            Dim ds As New DataSet
            da.Fill(ds)
            TelDv = New DataView(ds.Tables(0))
            TelBs.DataSource = TelDv
            TelDg.DataSource = TelBs
            TelFlag = True
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub TelDg_RowLeave_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TelDg.RowLeave
        Try
            If AddNewTel = True Then
                TelDg.UseWaitCursor = True
                Me.Validate()
                Me.KarshenasBs.EndEdit()
                Dim Tel_Insert_Str As String = "Insert into TelTable " & _
                                               "(K_Id,TypeTel,Tel)" & _
                                               " Values(?,?,?)"
                Dim dr As DataRow
                dr = KarshenasDv.Item(Me.KarshenasBs.Position).Row
                Dim K_Id As Integer
                K_Id = dr.ItemArray(0)


                Cn.ConnectionString = StrCon
                Dim Cmd As New OleDbCommand
                Cmd.CommandText = Tel_Insert_Str
                Cmd.Connection = Cn

                Cmd.Parameters.Add("@K_Id", OleDbType.Integer).Value = K_Id
                Cmd.Parameters.Add("@TypeTel", OleDbType.VarWChar).Value = Me.TelDg.CurrentRow.Cells(0).Value
                Cmd.Parameters.Add("@Tel", OleDbType.VarWChar).Value = Me.TelDg.CurrentRow.Cells(1).Value

                Cn.Open()
                Cmd.ExecuteNonQuery()
                Cn.Close()
                TelDg.UseWaitCursor = False
                AddNewTel = False
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub TelDg_CellValueChanged_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TelDg.CellValueChanged
        Try
            If TelFlag = True Then
                If AddNewTel = False Then
                    Me.Validate()
                    Me.KarshenasBs.EndEdit()
                    Dim Tel_Update_Str As String = "Update TelTable Set " & _
                                                   " TypeTel=?,Tel=?" & _
                                                   " where TId=?"
                    Dim dr As DataRow
                    dr = TelDv.Item(Me.TelBs.Position).Row

                    Cn.ConnectionString = StrCon
                    Dim Cmd As New OleDbCommand
                    Cmd.CommandText = Tel_Update_Str
                    Cmd.Connection = Cn

                    Cmd.Parameters.Add("@TypeTel", OleDbType.VarWChar).Value = Me.TelDg.CurrentRow.Cells(0).Value
                    Cmd.Parameters.Add("@Tel", OleDbType.VarWChar).Value = Me.TelDg.CurrentRow.Cells(1).Value
                    Cmd.Parameters.Add("@TId", OleDbType.Integer).Value = dr.ItemArray(0)

                    Cn.Open()
                    Cmd.ExecuteNonQuery()
                    Cn.Close()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub TelDg_UserAddedRow_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles TelDg.UserAddedRow
        If e.Row.IsNewRow = True Then
            AddNewTel = True
        End If
    End Sub

    Private Sub TxtFiKCode_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtFiKCode.TextChanged, TxtFiLname.TextAlignChanged, TxtFiLname.TextChanged, TxtFiShahrestan.TextChanged
        Call Filter_Box()
        Me.KarshenasBs.Filter = SubFilter
    End Sub

    Private Sub CbOstan_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbOstan.TextChanged
        If OstanFlag = True Then
            Shahrestan_Select(CbOstan.SelectedValue)
        End If
    End Sub
End Class