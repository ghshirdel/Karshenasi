Imports System.IO
Imports System.Data.OleDb
Imports Syncfusion.DocIO.DLS

Imports Point = System.Drawing.Point
Imports System.ComponentModel.Win32Exception
Imports Microsoft.Office.Interop
Imports Microsoft.Office.Tools.Word
Public Class KarshenasiFrm
    Dim Karbari_Index_Combobox As Int16 = -1
    Dim i As Int64
    Dim Cn As New OleDbConnection
    Dim Kdv, Ostan_dv As DataView
    Dim Kardv As DataView
    Dim Sdv As DataView
    Dim Pdv As DataView
    Dim udv As DataView
    Dim Price_dv, Type_Kar_dv As DataView
    Dim adNew As Boolean = False
    Dim SetFlag As Boolean = False
    Dim SetKarFlag As Boolean = False
    Dim SetUnitFlag As Boolean = False
    Dim Set_Price_Flag As Boolean = False
    Dim PadNew As Boolean = False
    Dim Obj(6) As Object
    Dim K_Id As Integer
    Dim OstanFlag As Boolean = False
    Dim Price_AddNew As Boolean = False
    Dim h_dv As DataView
    Private SelectedDevice As WIA.Device
    Dim Tel_Id As Integer
    Dim Start_flag As Boolean = False
    Dim First_init_flag As Boolean = False
    Dim idxfrm As Integer
    Public Property Get_Data()
        Get
            Return 0
        End Get
        Set(ByVal value)
            K_Id = value
        End Set
    End Property
    Private Sub Select_Karbari()
        Try
            Cn.ConnectionString = StrCon
            Dim da As New OleDbDataAdapter("Select * from BaseKarbariTable", Cn)
            Dim ds As New DataSet
            da.Fill(ds)
            Kardv = New DataView(ds.Tables(0))
            KarbariBindingSource.DataSource = Kardv
            ComboBox3.DataSource = KarbariBindingSource
            ComboBox3.DisplayMember = "Karbari"
            ComboBox3.ValueMember = "KarId"
            ComboBox3.SelectedIndex = -1
            SetKarFlag = True
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub Tel_unit_sazman(ByVal KsId As Integer)
        Try

            Cn.ConnectionString = StrCon
            Dim da As New OleDbDataAdapter("Select * from Tel_unit where KsId=" & KsId, Cn)
            Dim ds As New DataSet
            da.Fill(ds)
            Dim dv As New DataView(ds.Tables(0))
            If dv.Table.Rows.Count > 0 Then
                Dim R As Integer
                For R = 0 To dv.Table.Rows.Count - 1
                    Dim Tel_dr As DataRow = dv.Item(R).Row
                    Tel_List.Items.Add(Tel_dr.ItemArray(2))
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub Unit_Sazman(ByVal Sid As Integer)
        Try

            Cn.ConnectionString = StrCon
            Dim da As New OleDbDataAdapter("Select * from KUnitTable where Sid=" & Sid, Cn)
            Dim ds As New DataSet
            da.Fill(ds)
            udv = New DataView(ds.Tables(0))
            UBindingSource.DataSource = udv

            ComboBox2.DataSource = UBindingSource
            ComboBox2.DisplayMember = "Kunit"
            ComboBox2.ValueMember = "KSId"
            SetUnitFlag = True
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub Type_Sazman()
        Try

            Cn.ConnectionString = StrCon
            Dim da As New OleDbDataAdapter("Select * from SazmanTable", Cn)
            Dim ds As New DataSet
            da.Fill(ds)
            Sdv = New DataView(ds.Tables(0))
            WBindingSource.DataSource = Sdv
            ComboBox1.DataSource = WBindingSource
            ComboBox1.DisplayMember = "Sazman"
            ComboBox1.ValueMember = "SId"
            SetFlag = True
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub Select_Data()
        Try
            If SendFlagFromList = True Then
                Me.AddBtn.Enabled = False
                Me.CancelBtn.Enabled = False
                Me.DeleteBtn.Enabled = False
                Me.AddBtn.Enabled = False
                Me.SaveBtn.Enabled = False
                Me.DeleteBtn.Enabled = False
                Me.AttachmentBtn.Enabled = False
                Call SendFromList_Initialize()
                Call DataGrid_Init()
            Else
                Me.AddBtn.Enabled = True
                Me.CancelBtn.Enabled = False
                Me.DeleteBtn.Enabled = True
                Me.AddBtn.Enabled = True
                Me.SaveBtn.Enabled = True
                Me.DeleteBtn.Enabled = True
                Me.AttachmentBtn.Enabled = True
                Call Me.First_Initialize()
                'Call DataGrid_Init()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub SendFromList_Initialize()
        Try
            Cn.ConnectionString = StrCon
            Dim da As New OleDbDataAdapter("Select * from MainKTable where Kid=" & K_Id, Cn)
            Dim Kds As New DataSet
            da.Fill(Kds)
            Kdv = New DataView(Kds.Tables(0))
            Me.MainBindingSource.DataSource = Kdv
            Call Textbox_Initialize()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub First_Initialize()
        Try
            First_init_flag = False
            Cn.ConnectionString = StrCon
            Dim da As New OleDbDataAdapter("Select * from MainKTable", Cn)
            Dim Kds As New DataSet
            da.Fill(Kds)
            Kdv = New DataView(Kds.Tables(0))
            Me.MainBindingSource.DataSource = Kdv
            First_init_flag = True
            Call Textbox_Initialize()
            MainBindingSource.MoveLast()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub First_Type_Karshenasi_Select()
        If ComboBox3.SelectedIndex <> -1 Then

            Cn.ConnectionString = StrCon
            Dim da As New OleDbDataAdapter("Select * From Type_Karshenasi Where KarId =" & ComboBox3.SelectedValue, Cn)
            Dim ds As New DataSet
            da.Fill(ds)
            Type_Kar_dv = New DataView(ds.Tables(0))
            Tpk_Bs.DataSource = Type_Kar_dv
            'Column8.DataSource = Tpk_Bs
            'Column8.DisplayMember = "Type_Kar_Desc"
            'Column8.ValueMember = "Type_Kar_Id"
        End If
    End Sub
    Private Sub Textbox_Initialize()
        Try
            If Me.MainBindingSource.Position >= 0 Then
                Dim dr As DataRow = Kdv.Item(Me.MainBindingSource.Position).Row
                ComboBox4.Text = dr.ItemArray(13).ToString
                ComboBox1.Text = dr.ItemArray(8).ToString
                TxtKno.Text = dr.ItemArray(5).ToString
                FaDatePicker1.Text = dr.ItemArray(4).ToString
                Txtsubject.Text = dr.ItemArray(1).ToString
                TxtPAsli.Text = dr.ItemArray(2).ToString
                TxtPFarei.Text = dr.ItemArray(3).ToString
                ComboBox2.Text = dr.ItemArray(10).ToString
                ComboBox3.Text = dr.ItemArray(12).ToString
                FaDatePicker2.Text = dr.ItemArray(16).ToString
                'Uid = dr.ItemArray(9)
                Sid = IIf(dr.ItemArray(7) IsNot DBNull.Value, dr.ItemArray(7), Sid)
                If ComboBox3.SelectedIndex > -1 Then
                    Call First_Type_Karshenasi_Select()
                End If
                ComboBox4.Text = dr.ItemArray(13).ToString
            End If
            Call Menu_Item_Init()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub Insert_Data()
        Try
            Dim str As String
            Me.Validate()
            Me.MainBindingSource.EndEdit()
            str = "insert into MainKTable(subject,PAsli,PFarei,Kdate,Kno,TotalPrice,
                    Sid,Sazman,KSId,KUnit,KarId,Karbari,Type_Karshenasi)" &
                                  "values(?,?,?,?,?,?,?,?,?,?,?,?,?)"
            Dim Cmd As New OleDbCommand(str, Cn)
            Cmd.Parameters.Add("@Subject", OleDbType.VarChar).Value = Txtsubject.Text
            Cmd.Parameters.Add("@Pasli", OleDbType.VarChar).Value = TxtPAsli.Text
            Cmd.Parameters.Add("@PFarei", OleDbType.VarChar).Value = TxtPFarei.Text
            Cmd.Parameters.Add("@Kdate", OleDbType.VarWChar).Value = FaDatePicker1.Text
            Cmd.Parameters.Add("@Kno", OleDbType.Integer).Value = TxtKno.Text
            Cmd.Parameters.Add("@TotalPrice", OleDbType.VarChar).Value = 0
            Cmd.Parameters.Add("@SId", OleDbType.Integer).Value = ComboBox1.SelectedValue
            Cmd.Parameters.Add("@Sazman", OleDbType.VarChar).Value = ComboBox1.Text
            If ComboBox2.Text = "" Then
                Cmd.Parameters.Add("@KSId", OleDbType.Empty).Value = ""
                Cmd.Parameters.Add("@KUnit", OleDbType.VarChar).Value = DBNull.Value
            Else
                Cmd.Parameters.Add("@KSId", OleDbType.Integer).Value = ComboBox2.SelectedValue
                Cmd.Parameters.Add("@KUnit", OleDbType.VarChar).Value = ComboBox2.Text
            End If
            If ComboBox3.Text = "" Then
                Cmd.Parameters.Add("@KarId", OleDbType.Empty).Value = DBNull.Value
                Cmd.Parameters.Add("@Karbari", OleDbType.VarChar).Value = DBNull.Value
            Else
                Cmd.Parameters.Add("@KarId", OleDbType.Integer).Value = ComboBox3.SelectedValue
                Cmd.Parameters.Add("@Karbari", OleDbType.VarChar).Value = ComboBox3.Text
            End If
            Cmd.Parameters.Add("@Type_Karshenasi", OleDbType.VarChar).Value = ComboBox4.Text
            'Cmd.Parameters.Add("@EndDate", OleDbType.VarWChar).Value = FaDatePicker2.Text

            Cn.Open()
            Cmd.ExecuteNonQuery()
            Cn.Close()
        Catch ex As OleDbException
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "OLEdb Error")
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "General Error")
        End Try
    End Sub
    Private Sub Update_Data()
        Try
            Dim Cmd As New OleDbCommand
            Cn.ConnectionString = StrCon
            Cmd.Connection = Cn
            Dim strUpdate As String
            Dim dr As DataRow
            dr = Kdv.Item(Me.MainBindingSource.Position).Row
            Me.Validate()
            Me.MainBindingSource.EndEdit()
            strUpdate = "update MainKTable set " +
                        "subject=?,PAsli=?,PFarei=?,Kdate=?,Kno=?,TotalPrice=?," &
                        "SId=?,Sazman=?,Ksid=?,KUnit=?,KarId=?,Karbari=?,Type_Karshenasi=?,EndDate=?" &
                        " where Kid=?"
            Cmd.CommandText = strUpdate
            Cmd.Parameters.Add("@Subject", OleDbType.VarChar).Value = Txtsubject.Text
            Cmd.Parameters.Add("@Pasli", OleDbType.VarChar).Value = TxtPAsli.Text
            Cmd.Parameters.Add("@PFarei", OleDbType.VarChar).Value = TxtPFarei.Text
            Cmd.Parameters.Add("@Kdate", OleDbType.VarChar).Value = FaDatePicker1.Text
            Cmd.Parameters.Add("@Kno", OleDbType.Integer).Value = TxtKno.Text
            Cmd.Parameters.Add("@TotalPrice", OleDbType.VarChar).Value = 0
            Cmd.Parameters.Add("@SId", OleDbType.Integer).Value = ComboBox1.SelectedValue
            Cmd.Parameters.Add("@Sazman", OleDbType.VarChar).Value = ComboBox1.Text
            If ComboBox2.Text = "" Then
                Cmd.Parameters.Add("@KSId", OleDbType.Integer).Value = 0
                Cmd.Parameters.Add("@KUnit", OleDbType.VarWChar).Value = ""
            Else
                Cmd.Parameters.Add("@KSId", OleDbType.Integer).Value = ComboBox2.SelectedValue
                Cmd.Parameters.Add("@KUnit", OleDbType.VarWChar).Value = ComboBox2.Text
            End If
            If ComboBox3.Text = "" Then
                Cmd.Parameters.Add("@KarId", OleDbType.Integer).Value = 0
                Cmd.Parameters.Add("@Karbari", OleDbType.VarWChar).Value = ""
            Else
                If ComboBox3.SelectedIndex <> Karbari_Index_Combobox Then
                    Call Select_Type_Karshenasi()
                End If
                Cmd.Parameters.Add("@KarId", OleDbType.Integer).Value = ComboBox3.SelectedValue
                Cmd.Parameters.Add("@Karbari", OleDbType.VarWChar).Value = ComboBox3.Text
            End If
            Cmd.Parameters.Add("@Type_Karshenasi", OleDbType.VarChar).Value = ComboBox4.Text
            Cmd.Parameters.Add("@Enddate", OleDbType.VarChar).Value = FaDatePicker2.Text
            Cmd.Parameters.Add("@KId", OleDbType.Integer).Value = dr.ItemArray(0)

            Try
                Cn.Open()
                Cmd.ExecuteNonQuery()
                Cn.Close()
            Catch ex As OleDbException
                MsgBox(ex.ToString, MsgBoxStyle.Critical, "OLEdb Error")
            Catch ex As Exception
                MsgBox(ex.ToString, MsgBoxStyle.Critical, "General Error")
            End Try
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub KarshenasiFrm_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs)
        SendFlagFromList = False
        If CancelBtn.Enabled = True Then
            Me.MainBindingSource.RemoveCurrent()
            Me.AttachmentBtn.Enabled = True
            Me.CancelBtn.Enabled = False
            Me.DeleteBtn.Enabled = True
            Me.AddBtn.Enabled = True
            SaveBtn.Enabled = True
            AddBtn.Enabled = True
            Button1.Enabled = True
        End If
    End Sub
    Private Sub KarshenasiFrm_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Private Sub TxtKno_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            Me.ProcessTabKey(True)
        End If
    End Sub
    Private Sub FaDatePicker1_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles FaDatePicker1.KeyUp
        If e.KeyCode = Keys.Enter Then
            Me.ProcessTabKey(True)
        End If
    End Sub
    Private Sub Txtsubject_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtsubject.Enter
        InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(New System.Globalization.CultureInfo("Fa"))
    End Sub
    Private Sub Txtsubject_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtsubject.KeyUp
        If e.KeyCode = Keys.Enter Then
            Me.ProcessTabKey(True)
        End If
    End Sub
    Private Sub TxtPAsli_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtPAsli.KeyUp
        If e.KeyCode = Keys.Enter Then
            Me.ProcessTabKey(True)
        End If
    End Sub
    Private Sub TxtPFarei_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtPFarei.KeyUp
        If e.KeyCode = Keys.Enter Then
            Me.ProcessTabKey(True)
        End If
    End Sub
    Private Sub DataGridView1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Heyat_dg.KeyDown
        If e.KeyCode = Keys.Delete Then
            If MsgBox("آیا مطمئن به حذف ردیف جاری میباشید ؟", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                Try
                    Dim dr As DataRow
                    dr = h_dv.Item(Me.Heyat_BindingSource.Position).Row
                    Dim Str As String
                    Str = "Delete from heyat_Kar where Kar_h_Id=?"

                    Dim Cmd As OleDbCommand
                    Cn.ConnectionString = StrCon
                    Cmd = New OleDbCommand(Str, Cn)
                    Cmd.Parameters.Add("@Kar_h_Id", OleDbType.Integer).Value = dr.ItemArray(1)
                    Cn.Open()
                    Cmd.ExecuteNonQuery()
                    Cn.Close()
                    Call DataGrid_Init()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            End If
        End If
    End Sub
    Private Sub WBindingSource_PositionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WBindingSource.PositionChanged
        Try
            If SetFlag = True Then
                Unit_Sazman(ComboBox1.SelectedValue)
                ComboBox2.SelectedIndex = -1
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub KarshensiFileItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KarshensiFileItem.Click
        Try
            Dim pos As Integer = InStr(PathFileDatabase, "Karshenasi.mdb")
            Dim WPath As String = Mid(PathFileDatabase, 1, pos - 1)
            Dim document As New WordDocument
            Dim dr As DataRow
            dr = udv.Item(UBindingSource.Position).Row
            WPath += "Word\"
            If File.Exists(WPath + TxtKno.Text + ".doc") Then
                document.Open(WPath + dr.ItemArray(3).ToString.Trim + ".doc")
                System.Diagnostics.Process.Start(WPath + TxtKno.Text + ".doc")
            Else
                If File.Exists(WPath + dr.ItemArray(3) + ".doc") Then
                    document.Open(WPath + dr.ItemArray(3).ToString.Trim + ".doc")
                    document.Save(WPath + TxtKno.Text + ".doc")
                    System.Diagnostics.Process.Start(WPath + TxtKno.Text + ".doc")
                    KarshensiFileItem.Text = "ویرایش فرم کارشناسی ایجاد شده"
                    DeleteFileKarshenasiItem.Enabled = True
                Else
                    MsgBox("ابتدا باید نمونه فرم را از ایتم سازمان های مرتبط منوی تعاریف پایه طراحی نمائید")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub DeleteFileKarshenasiItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteFileKarshenasiItem.Click
        Dim pos As Integer = InStr(PathFileDatabase, "Karshenasi.mdb")
        Dim WPath As String = Mid(PathFileDatabase, 1, pos - 1)
        Dim dr As DataRow = udv.Item(UBindingSource.Position).Row
        WPath += "Word\"
        If File.Exists(WPath + dr.ItemArray(3).ToString + ".doc") Then
            If MsgBox("آیا مطمئن به حذف فرم کارشناسی جاری می باشید ؟", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Kill(WPath + TxtKno.Text + ".doc")
                DeleteFileKarshenasiItem.Enabled = False
                KarshensiFileItem.Text = "ایجاد فرم کارشناسی"
            End If
        End If
    End Sub
    Private Sub MaliFileItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MaliFileItem.Click
        Try
            Dim pos As Integer = InStr(PathFileDatabase, "Karshenasi.mdb")
            Dim WPath As String = Mid(PathFileDatabase, 1, pos - 1)
            Dim document As New WordDocument
            Dim dr As DataRow
            dr = udv.Item(UBindingSource.Position).Row
            WPath += "Word\"
            If File.Exists(WPath + dr.ItemArray(4).ToString + ".doc") Then
                document.Open(WPath + dr.ItemArray(4).ToString.Trim + ".doc")
                System.Diagnostics.Process.Start(WPath + dr.ItemArray(4).ToString + ".doc")
            Else
                If File.Exists(WPath + dr.ItemArray(4) + ".doc") Then
                    document.Open(WPath + dr.ItemArray(4).ToString.Trim + ".doc")
                    document.Save(WPath + TxtKno.Text + "Mali" + ".doc")
                    System.Diagnostics.Process.Start(WPath + TxtKno.Text + "Mali" + ".doc")
                    MaliFileItem.Text = "ویرایش فرم مالی ایجاد شده"
                    DeleteMaliFileItem.Enabled = True
                Else
                    MsgBox("ابتدا باید نمونه فرم را طراحی نمائید")
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub KarbariITem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KarbariITem.Click
        DefKarbariFrm.ShowDialog()
        Select_Karbari()
    End Sub
    Private Sub SazmanItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SazmanItem.Click
        SazmanFrm.ShowDialog()
        Type_Sazman()
    End Sub
    Private Sub DeleteMaliFileItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteMaliFileItem.Click
        Dim pos As Integer = InStr(PathFileDatabase, "Karshenasi.mdb")
        Dim WPath As String = Mid(PathFileDatabase, 1, pos - 1)
        WPath = WPath & "word\" + TxtKno.Text + "Mali" + ".doc"
        If File.Exists(WPath) Then
            If MsgBox("آیا مطمئن به حذف فرم مالی کارشناسی جاری می باشید ؟", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Kill(WPath)
                DeleteMaliFileItem.Enabled = False
                MaliFileItem.Text = "ایجاد فرم مالی"
            End If
        End If
    End Sub
    Private Sub TxtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSearch.TextChanged
        If TxtSearch.Text <> "" Then
            i = Me.MainBindingSource.Find("Kno", TxtSearch.Text)
            Me.MainBindingSource.Position = i
        End If
    End Sub
    Private Sub OstanAndShahrItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OstanAndShahrItem.Click
        OstanAndShahBaseFrm.ShowDialog()
    End Sub
    Private Sub KarshenasiFrm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        adNew = False
    End Sub
    Private Sub List_init_Btn()
        BindingNavigator1.MoveFirstItem.Enabled = False
        BindingNavigator1.MoveLastItem.Enabled = False
        BindingNavigator1.MoveNextItem.Enabled = False
        BindingNavigator1.MovePreviousItem.Enabled = False
        AddBtn.Enabled = False
        DeleteBtn.Enabled = False
        CancelBtn.Enabled = False
        BindingNavigatorMoveFirstItem.Enabled = False
        BindingNavigatorMoveLastItem.Enabled = False
        BindingNavigatorMoveNextItem.Enabled = False
        BindingNavigatorMovePreviousItem.Enabled = False
        SaveBtn.Enabled = True
    End Sub
    Private Sub First_init_Btn()
        ComboBox1.SelectedIndex = -1
        ComboBox2.SelectedIndex = -1
        ComboBox3.SelectedIndex = -1
        FaDatePicker1.Text = ""
        FaDatePicker2.Text = ""
        adNew = True
        Me.DeleteBtn.Enabled = False
        Me.CancelBtn.Enabled = True
        Me.AddBtn.Enabled = False
        Me.AttachmentBtn.Enabled = False
        Button1.Enabled = False
        SaveBtn.Enabled = True
        AddBtn.Enabled = False
    End Sub
    Private Sub KarshenasiFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call loadfrm()
    End Sub
    Function loadfrm()

        TextBox1.Visible = False
        Call Select_Ostan()
        OstanFlag = True
        Call Type_Sazman()
        Call Unit_Sazman(ComboBox1.SelectedValue)
        If SetUnitFlag = True Then
            Tel_List.Items.Clear()
            Call Tel_unit_sazman(ComboBox2.SelectedValue)
        End If
        Call Select_Karbari()
        If K_Id > 0 Then
            Call List_init_Btn()
            Call SendFromList_Initialize()
            Call Select_Price()
        Else
            Karshenasi_Price_DataGridView.Enabled = False
            Heyat_dg.Enabled = False
            Call First_init_Btn()
            Call Menu_Item_Init()
            TxtKno.Focus()
            Cn.ConnectionString = StrCon
            Dim da As New OleDbDataAdapter("Select max(Kno) from MainKTable ", Cn)
            Dim ds As New DataSet
            da.Fill(ds)
            Dim dv As New DataView(ds.Tables(0))
            Dim dr As DataRow = dv.Item(0).Row
            Dim nrow As Integer
            If (dr.ItemArray(0) IsNot DBNull.Value) Then
                Price_Karshenasi_BindingSource.MoveLast()
                nrow = dr.ItemArray(0) + 1
            End If
            TxtKno.Text = If(dr.ItemArray(0) Is DBNull.Value, 1, nrow)
            Dim pt As New PersianToolS.PersinToolsClass

            FaDatePicker1.Text = pt.DateToPersian(Date.Now).ShortDate
            Call First_Type_Karshenasi_Select()

        End If
        Karbari_Index_Combobox = ComboBox3.SelectedIndex

        Start_flag = True
        Return 0
    End Function

    Private Sub SaveBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveBtn.Click
        Kno_Insert = TxtKno.Text
        If adNew = True Then
            karshenasiParvNew = False
            Call Insert_Data()
            adNew = False
            Call First_Initialize()
            Call DataGrid_Init()
            MainBindingSource.MoveLast()
            Dim dr As DataRow = Kdv.Item(MainBindingSource.Position).Row
            Kid = dr.ItemArray(0)
            Call Menu_Item_Init()
            BindingNavigator1.MoveFirstItem.Enabled = False
            BindingNavigator1.MoveLastItem.Enabled = False
            BindingNavigator1.MoveNextItem.Enabled = False
            BindingNavigator1.MovePreviousItem.Enabled = False
            Button1.Enabled = True
            AddBtn.Enabled = True
            DeleteBtn.Enabled = False
            CancelBtn.Enabled = True
            Karshenasi_Price_DataGridView.Enabled = True
            Heyat_dg.Enabled = True
            Price_Karshenasi_BindingSource.MoveLast()
            BNavigationKarshenasi.Enabled = True
            BindingNavigator_Heyat.Enabled = True
        Else
            Call Update_Data()
            Call Select_Data()
            Dim i As Integer = Me.MainBindingSource.Find("Kno", Kno_Insert)
            Me.MainBindingSource.Position = i
            Call DataGrid_Init()
        End If
    End Sub
    Private Sub AddBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddBtn.Click
        adNew = True
        BNavigationKarshenasi.Enabled = False
        BindingNavigator_Heyat.Enabled = False
        Karshenasi_Price_DataGridView.Enabled = False
        Heyat_dg.Enabled = False
        Me.DeleteBtn.Enabled = False
        Me.CancelBtn.Enabled = True
        Me.AddBtn.Enabled = False
        Me.AttachmentBtn.Enabled = False
        Button1.Enabled = False
        SaveBtn.Enabled = True
        AddBtn.Enabled = False
        Me.MainBindingSource.AddNew()
        TxtKno.Focus()
        Cn.ConnectionString = StrCon
        Dim da As New OleDbDataAdapter("Select max(Kno) from MainKTable ", Cn)
        Dim ds As New DataSet
        da.Fill(ds)
        Dim dv As New DataView(ds.Tables(0))
        Dim dr As DataRow = dv.Item(0).Row
        TxtKno.Text = dr.ItemArray(0) + 1
        Dim pt As New PersianToolS.PersinToolsClass
        FaDatePicker1.Text = pt.DateToPersian(Date.Now).ShortDate
        Txtsubject.Text = "ارزیابی ملک واقع در استان "
    End Sub
    Private Sub DeleteBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteBtn.Click
        Dim str As String = ""
        If MsgBox("آيا پرونده كارشناسي ثبت شده را حذف مي نمائيد؟", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
            Dim dr As DataRow
            dr = Kdv.Item(Me.MainBindingSource.Position).Row
            Kid = dr.ItemArray(0)
            str = "delete from MainKTable where Kid=" & Kid
            Cn.ConnectionString = StrCon
            Cn.Open()
            Dim Cmd As New OleDbCommand(str, Cn)
            Cmd.ExecuteNonQuery()
            Cn.Close()
            If SendFlagFromList = True Then
                Me.AddBtn.Enabled = False
                Me.CancelBtn.Enabled = False
                Me.DeleteBtn.Enabled = False
                Me.AddBtn.Enabled = False
                Me.SaveBtn.Enabled = False
                Me.DeleteBtn.Enabled = False
                Me.AttachmentBtn.Enabled = False
                Call SendFromList_Initialize()
                Call Textbox_Initialize()
            Else
                Me.AddBtn.Enabled = True
                Me.CancelBtn.Enabled = False
                Me.DeleteBtn.Enabled = True
                Me.AddBtn.Enabled = True
                Me.SaveBtn.Enabled = True
                Me.DeleteBtn.Enabled = True
                Me.AttachmentBtn.Enabled = True
                Call Me.First_Initialize()
                Call Textbox_Initialize()
            End If
        End If
    End Sub
    Private Sub CancelBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelBtn.Click
        Me.MainBindingSource.RemoveCurrent()
        Me.AttachmentBtn.Enabled = True
        Me.CancelBtn.Enabled = False
        Me.DeleteBtn.Enabled = True
        Me.AddBtn.Enabled = True
        SaveBtn.Enabled = True
        AddBtn.Enabled = True
        Button1.Enabled = True
        BNavigationKarshenasi.Enabled = True
        BindingNavigator_Heyat.Enabled = True
    End Sub
    Private Sub AttachmentBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AttachmentBtn.Click
        Dim dr As DataRow
        dr = Kdv.Item(Me.MainBindingSource.Position).Row
        Kid = dr.ItemArray(0)
        Dim Pic_Frm As New Pic_Viewer
        Pic_Frm.Get_Data = 1
        Pic_Frm.ShowDialog()
    End Sub
    Private Sub MainBindingSource_PositionChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MainBindingSource.PositionChanged
        If Me.MainBindingSource.Position >= 0 Then
            Call Textbox_Initialize()
            Call DataGrid_Init()
        End If
    End Sub
    Private Sub KarshenasiFrm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F3 Then
            TxtKno.ReadOnly = False
        End If
    End Sub
    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Cn.ConnectionString = StrCon
        Dim Cmd As New OleDbCommand
        Cmd.CommandText = "Select Kid from PictureTable where Kid=" & Kid
        Cmd.Connection = Cn
        Cn.Open()
        Dim dReader As OleDbDataReader = Cmd.ExecuteReader()
        If dReader.HasRows Then
            Dim dr As DataRow
            dr = Kdv.Item(Me.MainBindingSource.Position).Row
            Kid = dr.ItemArray(0)
            Dim Pic_frm As New Pic_Viewer
            Pic_frm.Get_Data = 1
            Cn.Close()
            Pic_frm.ShowDialog()
        Else
            Dim dr As DataRow
            dr = Kdv.Item(Me.MainBindingSource.Position).Row
            Kid = dr.ItemArray(0)
            Dim Pic_frm As New Pic_Viewer
            Pic_frm.Get_Data = 0
            Cn.Close()
            Pic_frm.ShowDialog()
        End If
    End Sub
    Private Sub Create_File_Karshenasi_Item_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Create_File_Karshenasi_Item.Click
        Call Karshenasi_Word_File()
    End Sub
    Private Sub Editing_Karshenasi_File_Item_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Editing_Karshenasi_File_Item.Click
        Call Karshenasi_Word_File()
    End Sub
    Private Sub Delete_Karshenasi_File_Item_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Delete_Karshenasi_File_Item.Click
        Dim pos As Integer = InStr(PathFileDatabase, Karshenasi_FileName)
        Dim WPath As String = Mid(PathFileDatabase, 1, pos - 1)
        Dim Kar_dr As DataRow = Kdv.Item(MainBindingSource.Position).Row
        WPath += "Word\"
        If File.Exists(WPath + Kar_dr.ItemArray(0).ToString + "_Kar" + ".doc") Then
            If MsgBox("آیا مطمئن به حذف فرم کارشناسی جاری می باشید ؟", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Kill(WPath + Kar_dr.ItemArray(0).ToString + "_Kar" + ".doc")
                Delete_Karshenasi_File_Item.Enabled = False
                KarshensiFileItem.Text = "ایجاد فرم کارشناسی"
            End If
        End If
        Call Menu_Item_Init()
    End Sub
    Private Sub Menu_Item_Init()
        Try
            Dim pos As Integer = InStr(PathFileDatabase, Karshenasi_FileName)
            Dim pathfileword As String = Mid(PathFileDatabase, 1, pos - 1)
            Dim T As Boolean
            Dim Wpath As String = pathfileword
            If MainBindingSource.Position > -1 Then
                Karshenasi_Price_Menu.Enabled = True
                Dim Karshenasi_dr As DataRow = Kdv.Item(MainBindingSource.Position).Row
                pathfileword = pathfileword & "word\" & Karshenasi_dr.ItemArray(0).ToString + "_Kar" & ".Doc"
                T = File.Exists(pathfileword)
                If T = True Then
                    Delete_Karshenasi_File_Item.Enabled = True
                    Editing_Karshenasi_File_Item.Enabled = True
                    Create_File_Karshenasi_Item.Enabled = False
                Else
                    Delete_Karshenasi_File_Item.Enabled = False
                    Editing_Karshenasi_File_Item.Enabled = False
                    Create_File_Karshenasi_Item.Enabled = True
                End If
                Wpath = Wpath & "word\" + Karshenasi_dr.ItemArray(0).ToString + "_Mali" + ".doc"
                T = File.Exists(Wpath)
                If T = True Then
                    Create_File_Mali_Item.Enabled = False
                    Edit_File_Mali_Item.Enabled = True
                    Delete_File_Mali_Item.Enabled = True
                Else
                    Create_File_Mali_Item.Enabled = True
                    Edit_File_Mali_Item.Enabled = False
                    Delete_File_Mali_Item.Enabled = False
                End If
            Else
                Delete_Karshenasi_File_Item.Enabled = False
                Editing_Karshenasi_File_Item.Enabled = False
                Create_File_Karshenasi_Item.Enabled = False
                Create_File_Mali_Item.Enabled = False
                Edit_File_Mali_Item.Enabled = False
                Delete_File_Mali_Item.Enabled = False
                Karshenasi_Price_Menu.Enabled = False
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub Karshenasi_Word_File()
        Try
            If udv.Table.Rows.Count > 0 Then
                Dim pos As Integer = InStr(PathFileDatabase, Karshenasi_FileName)
                Dim WPath As String = Mid(PathFileDatabase, 1, pos - 1)
                Dim Unit_dr As DataRow = udv.Item(UBindingSource.Position).Row
                Dim Karshenasi_dr As DataRow = Kdv.Item(MainBindingSource.Position).Row
                WPath += "Word\"
                ' ساختن و یا استفاده از فرم کارشناسی ایجاد شده
                If File.Exists(WPath + Karshenasi_dr.ItemArray(0).ToString + "_Kar" + ".doc") Then
                    Process.Start(WPath + Karshenasi_dr.ItemArray(0).ToString + "_Kar" + ".doc")
                    Create_File_Karshenasi_Item.Enabled = False
                    Editing_Karshenasi_File_Item.Enabled = True
                    Delete_Karshenasi_File_Item.Enabled = True
                Else
                    If File.Exists(WPath + Unit_dr.ItemArray(3) + ".doc") Then
                        My.Computer.FileSystem.CopyFile(WPath + Unit_dr.ItemArray(3) + ".doc",
                                                        WPath + Karshenasi_dr.ItemArray(0).ToString + "_Kar" + ".doc",
                                                        Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs,
                                                        FileIO.UICancelOption.DoNothing)

                        Process.Start(WPath + Karshenasi_dr.ItemArray(0).ToString + "_Kar" + ".doc")
                    Else
                        Dim response = MsgBox("ابتدا باید نمونه فرم را طراحی نمائید", MsgBoxStyle.OkCancel)
                        If response = MsgBoxResult.Ok Then
                            Sid = Karshenasi_dr.ItemArray(7)
                            'Uid = Unit_dr.ItemArray(1)
                            SazmanFrm.Show()

                        End If
                    End If
                End If
                Call Menu_Item_Init()
            Else
                MsgBox("ابتدا پرونده کارشناسی را ثبت سپس اقدام به ایجاد فایل کارشناسی نمائید ")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub Kaishenasi_Mali_word_File()
        Try
            Dim pos As Integer = InStr(PathFileDatabase, Karshenasi_FileName)
            Dim WPath As String = Mid(PathFileDatabase, 1, pos - 1)
            ' Dim document As New WordDocument
            Dim dr As DataRow = udv.Item(UBindingSource.Position).Row
            Dim Karshenasi_dr As DataRow = Kdv.Item(MainBindingSource.Position).Row
            WPath += "Word\"
            If File.Exists(WPath + Karshenasi_dr.ItemArray(0).ToString + "_Mali" + ".doc") Then
                System.Diagnostics.Process.Start(WPath + Karshenasi_dr.ItemArray(0).ToString + "_Mali" + ".doc")
                Create_File_Mali_Item.Enabled = False
                Edit_File_Mali_Item.Enabled = True
                Delete_File_Mali_Item.Enabled = True
            Else
                If File.Exists(WPath + dr.ItemArray(4) + ".doc") Then
                    My.Computer.FileSystem.CopyFile(WPath + dr.ItemArray(4) + ".doc",
                                                    WPath + Karshenasi_dr.ItemArray(0).ToString + "_Mali" + ".doc",
                                                    Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs,
                                                    FileIO.UICancelOption.DoNothing)
                    Process.Start(WPath + Karshenasi_dr.ItemArray(0).ToString + "_Mali" + ".doc")
                Else
                    Dim response = MsgBox("ابتدا باید نمونه فرم را طراحی نمائید", MsgBoxStyle.OkCancel)
                    If response = MsgBoxResult.Ok Then
                        Sid = Karshenasi_dr.ItemArray(7)
                        SazmanFrm.Show()
                    End If
                End If
            End If
            Call Menu_Item_Init()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub Create_File_Mali_Item_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Create_File_Mali_Item.Click
        Call Kaishenasi_Mali_word_File()
    End Sub
    Private Sub Edit_File_Mali_Item_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Edit_File_Mali_Item.Click
        Call Kaishenasi_Mali_word_File()
    End Sub
    Private Sub Delete_File_Mali_Item_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Delete_File_Mali_Item.Click
        Try
            Dim pos As Integer = InStr(PathFileDatabase, Karshenasi_FileName)
            Dim WPath As String = Mid(PathFileDatabase, 1, pos - 1)
            Dim Kar_dr As DataRow = Kdv.Item(MainBindingSource.Position).Row

            WPath = WPath & "word\" + Kar_dr.ItemArray(0).ToString + "_Mali" + ".doc"
            If File.Exists(WPath) Then
                If MsgBox("آیا مطمئن به حذف فرم مالی کارشناسی جاری می باشید ؟", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Kill(WPath)
                    Delete_File_Mali_Item.Enabled = False
                    Call Menu_Item_Init()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Private Sub Select_Ostan()
        Try
            Cn.ConnectionString = StrCon
            Dim da As New OleDbDataAdapter("Select distinct Ostan from TOstan", Cn)
            Dim Ostav_ds As New DataSet
            da.Fill(Ostav_ds)
            Ostan_dv = New DataView(Ostav_ds.Tables(0))
            CbOstan.DataSource = Ostan_dv
            CbOstan.DisplayMember = "Ostan"
            CbOstan.ValueMember = "Ostan"
            CbOstan.SelectedIndex = -1
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub CbOstan_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbOstan.TextChanged
        If OstanFlag = True Then
            Txtsubject.Text = ""
            Txtsubject.AppendText(" ارزیابی ملک ")
            Txtsubject.AppendText(ComboBox3.Text)
            Txtsubject.AppendText(" واقع در استان ")
            Txtsubject.AppendText(CbOstan.Text + " " + "شهرستان")
            Txtsubject.Focus()
        End If
    End Sub
    Private Sub detect_Scanner()
        Dim MyDevice As WIA.Device
        Dim MyDialog As New WIA.CommonDialogClass
        Try
            'shows selectdevice dialog, if only one device, It automatically selects the device
            MyDevice = MyDialog.ShowSelectDevice(WIA.WiaDeviceType.UnspecifiedDeviceType, True, True)
            If Not MyDevice Is Nothing Then
                'loops through device properties, only gets the ones we want to display
                SelectedDevice = MyDevice
                MyDialog.ShowAcquireImage(WIA.WiaDeviceType.ScannerDeviceType, WIA.WiaImageIntent.ColorIntent, WIA.WiaImageBias.MinimizeSize)
            Else
                MsgBox("No WIA Devices Found!")
            End If
        Catch ex As System.Exception
            MessageBox.Show("Problem! " & ex.Message, "Problem Loading Device", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly)
        End Try
    End Sub
    Private Sub Txtsubject_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtsubject.Leave
        InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(New System.Globalization.CultureInfo("En"))
    End Sub
    Private Sub Heyat_dg_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Heyat_dg.CellContentClick
        Try
            If e.ColumnIndex = 1 Then
                Dim kar_frm As New KarshenasanFrm
                If PadNew = False Then
                    Dim dr As DataRow = h_dv(Heyat_BindingSource.Position).Row
                    kar_frm.Get_data = dr.ItemArray(1)
                Else
                    kar_frm.Get_data = -1
                End If
                kar_frm.ShowDialog()
                If kar_frm.Get_data >= 0 Then
                    If PadNew = True Then
                        Call Insert_Kar_Heyat(kar_frm.Get_data)
                        PadNew = False
                    Else
                        Call Update_Kar_Heyat(kar_frm.Get_data)
                    End If
                Else
                    If adNew = True Then
                        Heyat_BindingSource.RemoveCurrent()
                    End If
                End If
            End If
            Call DataGrid_Init()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Private Sub DataGrid_Init()
        Try
            If adNew = False Then
                Dim Kdr As DataRow
                Kdr = Kdv.Item(Me.MainBindingSource.Position).Row
                Kid = Kdr.ItemArray(0)
                Cn.ConnectionString = StrCon
                '----------------------------------------------
                Dim Str_select As String = "SELECT MainKTable.KId, Heyat_Kar.Kar_h_Id, 
                                            Heyat_Kar.K_Id, [KFname]+' '+[KLname] AS KName, 
                                            KarshenasanTable.Ostan, KarshenasanTable.Address,
                                            KarshenasanTable.shahrestan, KarshenasanTable.Type_kar
                                            FROM (MainKTable INNER JOIN Heyat_Kar ON MainKTable.KId = Heyat_Kar.Kid)
                                            INNER JOIN KarshenasanTable ON Heyat_Kar.K_Id = KarshenasanTable.K_id
                                            WHERE MainKTable.KId=" & Kid

                Dim da As New OleDbDataAdapter(Str_select, Cn)
                Dim ds As New DataSet
                da.Fill(ds)
                h_dv = New DataView(ds.Tables(0))
                If h_dv.Table.Rows.Count > 0 Then
                    Heyat_BindingSource.DataSource = h_dv
                    Heyat_dg.DataSource = Heyat_BindingSource
                    Dim j As Integer = 0
                    For j = 0 To Heyat_BindingSource.Count - 1
                        Heyat_dg.Rows(j).Cells(0).Value = j + 1
                    Next
                Else
                    Heyat_BindingSource.DataSource = Nothing
                    Heyat_dg.DataSource = Nothing
                End If
                '----------------------------------------------
            Else
                Me.Heyat_dg.DataSource = Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub Insert_Kar_Heyat(ByVal Kid_Karshenasan As Integer)
        Try
            Dim dr As DataRow = Kdv.Item(MainBindingSource.Position).Row
            Dim Str As String
            Str = "insert into Heyat_Kar (K_id,Kid) values(?,?)"

            Dim Cmd As OleDbCommand
            Cn.ConnectionString = StrCon
            Cmd = New OleDbCommand(Str, Cn)
            Cmd.Parameters.Add("@K_id", OleDbType.Integer).Value = Kid_Karshenasan
            Cmd.Parameters.Add("@Kid", OleDbType.Integer).Value = dr.ItemArray(0)
            Cn.Open()
            Cmd.ExecuteNonQuery()
            Cn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub Update_Kar_Heyat(ByVal Kid_Karshenasan As Integer)
        Try
            Dim dr As DataRow = h_dv.Item(Heyat_BindingSource.Position).Row
            Dim Str As String
            Str = "update Heyat_Kar set K_id=? where Kar_h_Id=?"

            Dim Cmd As OleDbCommand
            Cn.ConnectionString = StrCon
            Cmd = New OleDbCommand(Str, Cn)
            Cmd.Parameters.Add("@K_id", OleDbType.Integer).Value = Kid_Karshenasan
            Cmd.Parameters.Add("@Kar_h_Id", OleDbType.Integer).Value = dr.ItemArray(1)
            Cn.Open()
            Cmd.ExecuteNonQuery()
            Cn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub Add_karshenas(ByVal K_num As Integer)

        Try
            If Heyat_BindingSource.Count <= K_num Then
                PadNew = True
                If Me.Heyat_BindingSource.Count > 0 Then
                    Me.Heyat_dg.CurrentRow.Cells(0).Value = Me.Heyat_BindingSource.Count
                End If
            Else
                MsgBox("تعداد کارشناسان عضو هیئت با توجه به باکس کارشناسان انتخاب شده در هیئت تکمیل میباشد")
                Heyat_BindingSource.RemoveCurrent()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Private Sub Heyat_dg_UserAddedRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles Heyat_dg.UserAddedRow
        If e.Row.IsNewRow Then
            PadNew = True
            'Select Case ComboBox4.SelectedIndex
            '   Case 0
            ' msgBox("نوع کارشناسی هیئت ثبت نشده است "))
            'Heyat_dg.Rows.Clear()
            '   Case 1
            'Add_karshenas(1)
            '    Case 2
            'Add_karshenas(2)
            '    Case 3
            'Add_karshenas(4)
            '    Case 4
            'Add_karshenas(6)
            'End Select
        End If
    End Sub
    Private Sub Karshenasi_Price_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Karshenasi_Price_Menu.Click
        Try
            Call SendFromList_Initialize()
            Dim dr As DataRow = Kdv.Item(MainBindingSource.Position).Row
            Dim Wage_frm As New Mali_frm
            Wage_frm.Mali_get_Kid = Kid
            Wage_frm.Mali_get_Wage = dr.ItemArray(14).ToString
            Wage_frm.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        Try
            If SetUnitFlag = True Then
                Tel_List.Items.Clear()
                Call Tel_unit_sazman(ComboBox2.SelectedValue)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Private Sub Tel_Select(ByVal K_Id As Integer)
        Try

            Cn.ConnectionString = StrCon
            Dim da As New OleDbDataAdapter("Select * from TelTable where K_Id=" & K_Id, Cn)
            Dim ds As New DataSet
            da.Fill(ds)
            Dim dv As New DataView(ds.Tables(0))
            If dv.Table.Rows.Count > 0 Then
                Dim R As Integer
                For R = 0 To dv.Table.Rows.Count - 1
                    Dim Tel_dr As DataRow = dv.Item(R).Row
                    Tel_Heyat.Items.Add(Tel_dr.ItemArray(3))
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub Heyat_BindingSource_PositionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Heyat_BindingSource.PositionChanged
        Try
            Tel_Heyat.Items.Clear()
            If h_dv.Table.Rows.Count > 0 Then
                Dim dr As DataRow = h_dv.Item(Heyat_BindingSource.Position).Row
                If dr.ItemArray(1) IsNot DBNull.Value Then
                    Tel_Select(dr.ItemArray(1))
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub delete_Change_Type_Karshenasi()
        Try
            Dim dr As DataRow = Kdv.Item(MainBindingSource.Position).Row

            Cn.ConnectionString = StrCon
            Dim Cmd As New OleDbCommand
            Cmd.Connection = Cn
            Cmd.CommandText = "Delete FROM Price_Karshenasi where KId=" & dr.ItemArray(0)
            Cn.Open()
            Cmd.ExecuteNonQuery()
            Cn.Close()
            Call Select_Price()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Private Sub Select_Type_Karshenasi()
        Try
            If SetKarFlag = True Then
                If K_Id > 0 Then
                    If ComboBox3.SelectedIndex > -1 Then
                        If Price_Karshenasi_BindingSource.Position > -1 Then
                            If Karshenasi_Price_DataGridView.CurrentRow.Cells(0).Value <> ComboBox3.SelectedValue Then
                                If MsgBox("با تغییر نوع کاربری اطلاعات جدول مبالغ کارشناسی حذف خواهد شد!", MsgBoxStyle.Information) = MsgBoxResult.Ok Then
                                    Call delete_Change_Type_Karshenasi()

                                    Cn.ConnectionString = StrCon
                                    Dim da As New OleDbDataAdapter("Select * From Type_Karshenasi Where KarId =" & ComboBox3.SelectedValue, Cn)
                                    Dim ds As New DataSet
                                    da.Fill(ds)
                                    Type_Kar_dv = New DataView(ds.Tables(0))
                                    Tpk_Bs.DataSource = Type_Kar_dv
                                    'Column8.DataSource = Tpk_Bs
                                    'Column8.DisplayMember = "Type_Kar_Desc"
                                    'Column8.ValueMember = "Type_Kar_Id"
                                End If
                            End If
                        End If
                    End If
                Else
                    First_Type_Karshenasi_Select()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        Try
            If TextBox1.Text <> "" Then
                TextBox1.Text = Format(CDbl(TextBox1.Text.Trim.Replace(",", "")), "#,0")
                TextBox1.SelectionStart = TextBox1.TextLength
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Private Sub Select_Price()
        Try
            If karshenasiParvNew = False Then
                If Kdv.Table.Rows.Count > 0 Then
                    Set_Price_Flag = False
                    Dim str_select As String = "SELECT Price_Karshenasi.KPrice_Id, Price_Karshenasi.KId, 
                                            Price_Karshenasi.Type_Kar_Id, Type_Karshenasi.Type_Kar_Desc, 
                                            Price_Karshenasi.Price, Price_Karshenasi.Not_Price, 
                                            Price_Karshenasi.Wage
                                            FROM Type_Karshenasi INNER JOIN Price_Karshenasi ON 
                                            Type_Karshenasi.Type_Kar_Id = Price_Karshenasi.Type_Kar_Id where Kid="
                    Dim dr As DataRow = Kdv.Item(MainBindingSource.Position).Row

                    Cn.ConnectionString = StrCon
                    Dim da As New OleDbDataAdapter(str_select & dr.ItemArray(0), Cn)
                    Dim ds As New DataSet
                    da.Fill(ds)
                    Price_dv = New DataView(ds.Tables(0))
                    KPrice_dv = New DataView(ds.Tables(0))
                    Price_Karshenasi_BindingSource.DataSource = Price_dv
                    Set_Price_Flag = True
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub TextBox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                If TextBox1.Text <> "" Then
                    Karshenasi_Price_DataGridView.CurrentRow.Cells(2).Value = CDbl(TextBox1.Text)
                    Call Total_wage()
                    TextBox1.Visible = False
                    Karshenasi_Price_DataGridView.Focus()
                    Karshenasi_Price_DataGridView.BeginEdit(True)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Karshenasi_Price_DataGridView_UserAddedRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles Karshenasi_Price_DataGridView.UserAddedRow
        If e.Row.IsNewRow Then
            Price_AddNew = True
            Karshenasi_Price_DataGridView.CurrentRow.Cells(0).Value = Price_Karshenasi_BindingSource.Count
        End If
    End Sub
    Private Sub Update_Karshenasi_Price()
        Try
            Me.Validate()
            Price_Karshenasi_BindingSource.EndEdit()
            Dim Price_dr As DataRow = Price_dv.Item(Price_Karshenasi_BindingSource.Position).Row
            Dim POS As Integer = Tpk_Bs.Find("Type_Kar_Id", Karshenasi_Price_DataGridView.CurrentRow.Cells(1).Value)
            Dim Not_Price_dr As DataRow = Type_Kar_dv.Item(POS).Row

            Cn.ConnectionString = StrCon
            Dim Cmd As New OleDbCommand
            Cmd.Connection = Cn
            Cmd.CommandText = "Update Price_Karshenasi set Type_Kar_Id=?,Price=?,Not_Price=?,wage=? where Kprice_Id=?"
            Dim TpkId As Integer = Karshenasi_Price_DataGridView.CurrentRow.Cells(1).Value
            Cmd.Parameters.Add("@Type_Kar_Id", OleDbType.Integer).Value = TpkId
            Dim Price As Double = IIf(Price_dr.ItemArray(3) IsNot DBNull.Value, Price_dr.ItemArray(3), DBNull.Value)
            Cmd.Parameters.Add("@Price", OleDbType.Double).Value = Price
            Dim Not_Price As Boolean = IIf(Price_dr.ItemArray(4) Is DBNull.Value, False, Price_dr.ItemArray(4))
            Cmd.Parameters.Add("@Not_Price", OleDbType.Boolean).Value = Not_Price
            Cmd.Parameters.Add("@Wage", OleDbType.Double).Value = IIf(Price_dr.ItemArray(5) IsNot DBNull.Value, Price_dr.ItemArray(5), DBNull.Value)
            Cmd.Parameters.Add("@Kprice_Id", OleDbType.Integer).Value = Price_dr.ItemArray(0)
            Cn.Open()
            Cmd.ExecuteNonQuery()
            Cn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub Insert_Karshenasi_Price()
        Try
            Me.Validate()
            Price_Karshenasi_BindingSource.EndEdit()
            Dim POS As Integer = Tpk_Bs.Find("Type_Kar_Id", Karshenasi_Price_DataGridView.CurrentRow.Cells(1).Value)
            Dim dr As DataRow = Type_Kar_dv.Item(POS).Row

            Cn.ConnectionString = StrCon
            Dim Cmd As New OleDbCommand
            Cmd.Connection = Cn
            Cmd.CommandText = "Insert into Price_Karshenasi (KId,Type_Kar_Id) values(?,?)"
            Cmd.Parameters.Add("@KId", OleDbType.Integer).Value = Kid
            Cmd.Parameters.Add("@Type_Kar_Id", OleDbType.Integer).Value = Karshenasi_Price_DataGridView.CurrentRow.Cells(1).Value
            Cn.Open()
            Cmd.ExecuteNonQuery()
            Cn.Close()
            Price_AddNew = False
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub Total_wage()
        Try
            If Kdv.Table.Rows.Count > 0 Then
                Dim Price_dr As DataRow = Price_dv.Item(Price_Karshenasi_BindingSource.Position).Row
                If Price_dr.ItemArray(3) IsNot Nothing And Price_dr.ItemArray(3) IsNot DBNull.Value Then
                    Dim x As Double = Price_dr.ItemArray(3)
                    Dim Wage_Tmp As Double = 0
                    Select Case x
                        Case 0 To 100000000
                            Wage_Tmp = (5 / 1000) * x
                        Case 100000000 To 500000000
                            Wage_Tmp = 500000 + (2 / 1000) * (x - 100000000)
                        Case 500000000 To 5000000000
                            Wage_Tmp = 1300000 + (1.5 / 1000) * (x - 500000000)
                        Case 5000000000 To 10000000000000000
                            Wage_Tmp = 8050000 + (1 / 1000) * (x - 5000000000)
                    End Select
                    Karshenasi_Price_DataGridView.CurrentRow.Cells(4).Value = Wage_Tmp
                    If Wage_Tmp > 32500000 Then
                        Wage_Tmp = 32500000
                        Karshenasi_Price_DataGridView.CurrentRow.Cells(4).Value = Wage_Tmp
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub TextBox1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.Leave
        Try
            If TextBox1.Text <> "" Then
                Karshenasi_Price_DataGridView.CurrentRow.Cells(2).Value = CDbl(TextBox1.Text)
                Me.Validate()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Call SazmanFrm.Show()

    End Sub
    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        OstanAndShahBaseFrm.Show()
    End Sub
    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        DefKarbariFrm.Show()

    End Sub

    Private Sub AddBtnPriceKarshenasi_Click(sender As Object, e As EventArgs) Handles AddBtnPriceKarshenasi.Click
        NewFlag = True
        KarId = ComboBox3.SelectedValue
        Dim dr1 As DataRow = Kdv.Item(MainBindingSource.Position).Row
        Kid = dr1.ItemArray(0)
        AddPriceKarshenasi_frm.Show()
    End Sub
    Private Sub KarshenasiFrm_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        idxfrm += 1
    End Sub

    Private Sub KarshenasiFrm_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated

        If idxfrm > 0 And PkId = 0 Then
            Select_Price()
        End If
        If Karbariflag = True And idxfrm > 0 Then
            Call Select_Karbari()
            Karbariflag = False
        End If
        If Sazmanflag = True And idxfrm > 0 Then
            Call Type_Sazman()
            Call Unit_Sazman(ComboBox1.SelectedValue)
            If SetUnitFlag = True Then
                Tel_List.Items.Clear()
                Call Tel_unit_sazman(ComboBox2.SelectedValue)
            End If
            Sazmanflag = False
        End If
        If Ostanflag1 = True And idxfrm > 0 Then
            Call Select_Ostan()
            Ostanflag1 = False
            OstanFlag = True
        End If
    End Sub

    Private Sub KarshenasiFrm_FormClosed_1(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If karshenasiParvNew = True Then
            karshenasiParvNew = False
        End If
    End Sub

    Private Sub SaveItem_Click(sender As Object, e As EventArgs) Handles SaveItem.Click
        KarId = ComboBox3.SelectedValue
        Dim kpdr As DataRow = KPrice_dv.Item(Price_Karshenasi_BindingSource.Position).Row
        PkId = kpdr.ItemArray(0)
        AddPriceKarshenasi_frm.Show()
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If (Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57) And Asc(e.KeyChar) <> 8 Then e.Handled = True
    End Sub
End Class