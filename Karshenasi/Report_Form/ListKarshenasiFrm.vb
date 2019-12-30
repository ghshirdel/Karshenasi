Imports System.Data
Imports System.Drawing
Imports System.Web
Imports Syncfusion.Core
Imports Syncfusion.XlsIO
Imports System.IO
Imports System.Data.OleDb
Public Class ListKarshenasiFrm
    Dim Kdv As DataView
    Dim sdv As DataView
    Dim udv As DataView
    Dim Cn As New OleDbConnection
    Dim StrFilter As String = ""
    Dim SubFilter As String = ""
    Dim setFlag As Boolean = False
    Dim SetUnitFlag As Boolean = False
    Private Sub ListKarshenasiFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Call First_Initialize()
            Call Type_Sazman()
            Call Unit_Sazman(ComboBox1.SelectedValue)
            Call Clear_Textbox()
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(New Globalization.CultureInfo("Fa"))

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub Type_Sazman()
        Try
            Cn.ConnectionString = StrCon
            Dim da As New OleDbDataAdapter("Select * from SazmanTable", Cn)
            Dim ds As New DataSet
            da.Fill(ds)
            sdv = New DataView(ds.Tables(0))
            WBindingSource.DataSource = sdv
            ComboBox1.DataSource = WBindingSource
            ComboBox1.DisplayMember = "Sazman"
            ComboBox1.ValueMember = "SId"
            ComboBox1.Text = ""
            setFlag = True
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
    Private Sub Clear_Textbox()
        TxtNo.Text = ""
        TxtSubject.Text = ""
        TxtDate1.Text = ""
        TxtDate2.Text = ""
        TxtEnDate1.Text = ""
        TxtEnDate2.Text = ""
        TxtPAsli.Text = ""
        TxtPFarei.Text = ""
        ComboBox1.Text = ""
        ComboBox2.Text = ""
    End Sub

    Private Sub First_Initialize()
        Try
            Cn.ConnectionString = StrCon
            Dim da As New OleDbDataAdapter("Select * from MainKTable", Cn)
            Dim Kds As New DataSet
            da.Fill(Kds)
            Kdv = New DataView(Kds.Tables(0))
            Me.ListBindingSource.DataSource = Kdv
            Me.ListDataGrid.DataSource = Me.ListBindingSource
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub ListDataGrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ListDataGrid.CellContentClick
        If e.ColumnIndex = 1 Then
            Dim kar_frm As New KarshenasiFrm
            Dim dr As DataRow
            dr = Kdv.Item(Me.ListBindingSource.Position).Row
            kar_frm.Get_Data = dr.ItemArray(0)
            kar_frm.ShowDialog()
            Call First_Initialize()
        End If
    End Sub
    Private Sub Filter_Box()
        Try
            ListBindingSource.RemoveFilter()

            SubFilter = ""
            If TxtNo.Text <> "" Then
                SubFilter = SubFilter + "Kno='" +
                    TxtNo.Text + "'"
            End If
            If ComboBox1.Text <> "" Then
                If setFlag = True Then
                    If SubFilter <> "" Then
                        SubFilter = SubFilter + " And  "
                        SubFilter = SubFilter + " Sid =" & ComboBox1.SelectedValue
                    Else
                        SubFilter = SubFilter + " Sid =" & ComboBox1.SelectedValue
                    End If
                End If
            End If
            If ComboBox2.Text <> "" Then
                If SetUnitFlag = True Then
                    If SubFilter <> "" Then
                        SubFilter = SubFilter + " And  "
                        SubFilter = SubFilter + " KSid =" & ComboBox2.SelectedValue
                    Else
                        SubFilter = SubFilter + " KSid =" & ComboBox2.SelectedValue
                    End If
                End If
            End If
            If TxtSubject.Text <> "" Then
                If SubFilter <> "" Then
                    SubFilter = SubFilter + " And  "
                    SubFilter = SubFilter + "subject Like'%" +
                    TxtSubject.Text + "%'"
                Else
                    SubFilter = SubFilter + "subject Like'%" +
                    TxtSubject.Text + "%'"
                End If
            End If
            If TxtPAsli.Text <> "" Then
                If SubFilter <> "" Then
                    SubFilter = SubFilter + " And  "
                    SubFilter = SubFilter + "pasli ='" +
                    TxtPAsli.Text + "'"
                Else
                    SubFilter = SubFilter + "pasli ='" +
                    TxtPAsli.Text + "'"
                End If
            End If
            If TxtPFarei.Text <> "" Then
                If SubFilter <> "" Then
                    SubFilter = SubFilter + " And  "
                    SubFilter = SubFilter + "PFarei ='" +
                    TxtPFarei.Text + "'"
                Else
                    SubFilter = SubFilter + "PFarei ='" +
                    TxtPFarei.Text + "'"
                End If
            End If
            If TxtDate1.Text <> "" And TxtDate2.Text = "" Then
                If SubFilter <> "" Then
                    SubFilter = SubFilter + " And  "
                    SubFilter = SubFilter + "kdate = '" +
                    TxtDate1.Text + "'"
                Else
                    SubFilter = SubFilter + "kdate = '" +
                    TxtDate1.Text + "'"
                End If
            End If
            If TxtDate1.Text = "" And TxtDate2.Text <> "" Then
                If SubFilter <> "" Then
                    SubFilter = SubFilter + " And  "
                    SubFilter = SubFilter + "kdate = '" +
                    TxtDate2.Text + "'"
                Else
                    SubFilter = SubFilter + "kdate = '" +
                    TxtDate2.Text + "'"
                End If
            End If
            If TxtDate1.Text <> "" And TxtDate2.Text <> "" Then
                If SubFilter <> "" Then
                    SubFilter = SubFilter + " And  "
                    SubFilter = SubFilter + "kdate >= '" +
                    TxtDate1.Text + "'"
                Else
                    SubFilter = SubFilter + "kdate >= '" +
                    TxtDate1.Text + "'"
                End If
                If SubFilter <> "" Then
                    SubFilter = SubFilter + " And  "
                    SubFilter = SubFilter + "kdate  <='" +
                    TxtDate2.Text + "'"
                Else
                    SubFilter = SubFilter + "kdate  <='" +
                    TxtDate2.Text + "'"
                End If
            End If


            If TxtEnDate1.Text <> "" And TxtEnDate2.Text = "" Then
                If SubFilter <> "" Then
                    SubFilter = SubFilter + " And  "
                    SubFilter = SubFilter + "EndDate = '" +
                    TxtEnDate1.Text + "'"
                Else
                    SubFilter = SubFilter + "EndDate = '" +
                    TxtEnDate1.Text + "'"
                End If
            End If
            If TxtEnDate1.Text = "" And TxtEnDate2.Text <> "" Then
                If SubFilter <> "" Then
                    SubFilter = SubFilter + " And  "
                    SubFilter = SubFilter + "EndDate = '" +
                    TxtEnDate2.Text + "'"
                Else
                    SubFilter = SubFilter + "EndDate = '" +
                    TxtEnDate2.Text + "'"
                End If
            End If
            If TxtEnDate1.Text <> "" And TxtEnDate2.Text <> "" Then
                If SubFilter <> "" Then
                    SubFilter = SubFilter + " And  "
                    SubFilter = SubFilter + "EndDate >= '" +
                    TxtEnDate1.Text + "'"
                Else
                    SubFilter = SubFilter + "EndDate >= '" +
                    TxtEnDate1.Text + "'"
                End If
                If SubFilter <> "" Then
                    SubFilter = SubFilter + " And  "
                    SubFilter = SubFilter + "EndDate  <='" +
                    TxtEnDate2.Text + "'"
                Else
                    SubFilter = SubFilter + "EndDate  <='" +
                    TxtEnDate2.Text + "'"
                End If
            End If


        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub TxtNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNo.TextChanged
        Call Filter_Box()
        Me.ListBindingSource.Filter = SubFilter
    End Sub

    Private Sub TxtSubject_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSubject.TextChanged
        Call Filter_Box()
        Me.ListBindingSource.Filter = SubFilter
    End Sub

    Private Sub TxtPAsli_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPAsli.TextChanged
        Call Filter_Box()
        Me.ListBindingSource.Filter = SubFilter
    End Sub

    Private Sub TxtPFarei_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPFarei.TextChanged
        Call Filter_Box()
        Me.ListBindingSource.Filter = SubFilter
    End Sub
    Private Sub TxtDate2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDate2.ValueChanged
        Call Filter_Box()
        Me.ListBindingSource.Filter = SubFilter
    End Sub
    Private Sub TxtDate1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDate1.ValueChanged
        Call Filter_Box()
        Me.ListBindingSource.Filter = SubFilter
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Call Clear_Textbox()
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        Me.ListBindingSource.RemoveFilter()
    End Sub

    Private Sub ListKarshenasiFrm_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub ExcelBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelBtn.Click
        Try

            Dim ExcelEngine1 As New ExcelEngine
            Dim Application As IApplication = ExcelEngine1.Excel
            Dim Workbook As IWorkbook = ExcelEngine1.Excel.Workbooks.Create(3)
            Dim Sheet As IWorksheet = Workbook.Worksheets(0)
            Dim i As Integer = 2
            'Sheet.Range("A1:AB1000").VerticalAlignment = ExcelVAlign.VAlignDistributed
            Sheet.Range("A1:AB1000").CellStyle.Font.FontName = "Tahoman"
            Sheet.Range("A1:AB100").CellStyle.Font.Size = 10
            With Sheet
                .Range("A1").Value = "ردیف"
                .Range("B1").Value = "شماره كارشناسي"
                .Range("C1").Value = "تاريخ كارشناسي"
                .Range("D1").Value = "موضوع كارشناسي"
                .Range("E1").Value = "پلاك اصلي"
                .Range("F1").Value = "پلاك فرعي"
                .Range("G1").Value = "ارزش كارشناسي"

                Dim l As Integer = 2
                Dim t As Integer = 0
                Me.ListBindingSource.MoveFirst()
                Dim dr As DataRow
                Do While (t < Me.ListBindingSource.Count)
                    dr = Kdv.Item(Me.ListBindingSource.Position).Row
                    .Range("A" & t + 2).Value = t + 1
                    .Range("B" & t + 2).Value = dr.ItemArray(5).ToString
                    .Range("C" & t + 2).Value = dr.ItemArray(4).ToString
                    .Range("D" & t + 2).Value = dr.ItemArray(1).ToString
                    .Range("E" & t + 2).Value = dr.ItemArray(3).ToString
                    .Range("F" & t + 2).Value = dr.ItemArray(2).ToString
                    .Range("G" & t + 2).Value = dr.ItemArray(6).ToString
                    Me.ListBindingSource.MoveNext()
                    t += 1
                Loop
            End With
            Workbook.SaveAs("sample.xls")
            System.Diagnostics.Process.Start("sample.xls")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub ComboBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.TextChanged
        Try
            Call Filter_Box()
            Me.ListBindingSource.Filter = SubFilter
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub WBindingSource_PositionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WBindingSource.PositionChanged
        Call Unit_Sazman(ComboBox1.SelectedValue)
    End Sub

    Private Sub ComboBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.TextChanged
        Try
            Call Filter_Box()
            Me.ListBindingSource.Filter = SubFilter
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub Delete_btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Delete_btn.Click
        Try
            If MsgBox("آیا نظریه کارشناسی مورد نظر را حذف مینمائید؟", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                Dim dr As DataRow = Kdv.Item(ListBindingSource.Position).Row

                Cn.ConnectionString = StrCon
                Dim Cmd As New OleDbCommand
                Cmd.CommandText = "delete From MainKTable where Kid=" & dr.ItemArray(0)
                Cmd.Connection = Cn
                Cn.Open()
                Cmd.ExecuteNonQuery()
                Cn.Close()
                Call First_Initialize()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub TxtNo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtNo.KeyPress
        If (Char.IsLetter(e.KeyChar) = True) Then

            e.Handled = True
        End If

    End Sub
    Private Sub TxtEnDate1_ValueChanged(sender As Object, e As EventArgs) Handles TxtEnDate1.ValueChanged
        Call Filter_Box()
        Me.ListBindingSource.Filter = SubFilter
    End Sub

    Private Sub TxtEnDate2_ValueChanged(sender As Object, e As EventArgs) Handles TxtEnDate2.ValueChanged
        Call Filter_Box()
        Me.ListBindingSource.Filter = SubFilter
    End Sub
End Class