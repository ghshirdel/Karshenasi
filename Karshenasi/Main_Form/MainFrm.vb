Imports System
Imports System.IO
Imports System.IO.Path
Imports System.Data.OleDb
Imports System.Management
Imports System.Net.NetworkInformation
Imports System.Runtime.InteropServices
Public Class MainFrm
    Dim tt As ToolTip
    Dim Cn As New OleDbConnection
    Dim lockflage As Boolean = False

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label1.Text = "مشخصات کارشناسان  همکار"
        Label2.Text = "ثبت پرونده جدید"
        Label3.Text = "لیست پرونده های ثبت شده"

        Dim pt As New PersianToolS.PersinToolsClass
        T1.Text = pt.DateToPersian(Date.Now).LongDate
        'pathf = Directory.GetCurrentDirectory
        pathf = Path.GetDirectoryName(Application.ExecutablePath)
        Dim T As Boolean
        T = File.Exists(pathf & "\PathFile.txt")
        If T = True Then
            Dim FileNum As Integer
            FileNum = FreeFile()
            FileOpen(FileNum, pathf & "\PathFile.txt", OpenMode.Input)
            Input(FileNum, PathFileDatabase)
            FileClose()
        Else
            OpenFileDialog1.DefaultExt = "accdb"
            OpenFileDialog1.FileName = ""
            OpenFileDialog1.Filter = "Access File|*.accdb"
            If Me.OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                PathFileDatabase = Me.OpenFileDialog1.FileName
                Dim FileNum As Integer
                FileNum = FreeFile()
                FileOpen(FileNum, pathf & "\PathFile.txt", OpenMode.Output)
                Write(FileNum, PathFileDatabase)
                FileClose(FileNum)
            End If
        End If
        T = File.Exists(PathFileDatabase)
        If T = True Then
        Else
            OpenFileDialog1.DefaultExt = "accdb"
            OpenFileDialog1.FileName = ""
            OpenFileDialog1.Filter = "Access File|*.accdb"
            If Me.OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                PathFileDatabase = Me.OpenFileDialog1.FileName
                Dim FileNum As Integer
                FileNum = FreeFile()
                FileOpen(FileNum, pathf & "\PathFile.txt", OpenMode.Output)
                Write(FileNum, PathFileDatabase)
                FileClose(FileNum)
            End If
        End If

        StrCon = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & PathFileDatabase & ";Persist Security Info=True"

        T3.Text = PathFileDatabase
        Karshenasi_FileName = Path.GetFileName(PathFileDatabase)

        Try
            lockFalse()
            lockflage = LockSystem()
            If lockflage Then
                Call lockTrue()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        ' Dim Remain_frm As New Remain_Kar_frm  
        ' Remain_frm.ShowDialog()
    End Sub
    Function LockSystem() As Boolean
        Dim ldr As DataRow
        Try
            Call lockFalse()
            Dim lockdv As DataView
            Cn.ConnectionString = StrCon
            Dim da As New OleDbDataAdapter("Select * from LockSystem", Cn)
            Dim ds As New DataSet
            da.Fill(ds)
            lockdv = New DataView(ds.Tables(0))
            BsLock.DataSource = lockdv
            Dim t As Integer = lockdv.Table.Rows.Count
            If t = 1 Then
                ldr = lockdv.Item(BsLock.Position).Row
                Dim lockfield As String = Form1.ChechLock()
                If ldr.ItemArray(1) = lockfield Then
                    lockTrue()
                Else
                    Form1.Show()
                End If
            Else
                Form1.Show()
            End If
            Return lockflage
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return 0
    End Function
    Function lockTrue()
        MenuStrip1.Enabled = True
        Button1.Visible = False
        MenuStrip1.Enabled = True
        PictureBox1.Enabled = True
        PictureBox2.Enabled = True
        PictureBox3.Enabled = True
        Button1.Enabled = False
        Return 0
    End Function
    Function lockFalse()
        MenuStrip1.Enabled = False
        Button1.Visible = True
        PictureBox1.Enabled = False
        PictureBox2.Enabled = False
        PictureBox3.Enabled = False
    End Function
    Private Sub KarshenasiParvItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KarshenasiParvItem.Click
        KarshenasiFrm.ShowDialog()
    End Sub
    Private Sub ExitItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitItem.Click
        End
    End Sub
    Private Sub ListKarshenasiFrm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListKarshenasiFrm.Click
        Dim listfrm As New ListKarshenasiFrm
        listfrm.Show()
    End Sub
    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Dim Kar_frm As New KarshenasiFrm
        Kar_frm.Get_Data = 0
        karshenasiParvNew = True
        Kar_frm.ShowDialog()
    End Sub
    Private Sub PathDatabaseItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PathDatabaseItem.Click
        Dim P_File As String = Directory.GetCurrentDirectory
        OpenFileDialog1.DefaultExt = "accdb"
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "Access File|*.accdb"
        If Me.OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            PathFileDatabase = Me.OpenFileDialog1.FileName
            Dim FileNum As Integer
            FileNum = FreeFile()
            FileOpen(FileNum, P_File & "\PathFile.txt", OpenMode.Output)
            Write(FileNum, PathFileDatabase)
            FileClose(FileNum)
            StrCon = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & PathFileDatabase & ";Persist Security Info=True"
            T3.Text = PathFileDatabase
            Karshenasi_FileName = Path.GetFileName(PathFileDatabase)
        End If
    End Sub
    Private Sub SazmanItam_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SazmanItam.Click
        SazmanFrm.ShowDialog()
    End Sub
    Private Sub KarbariItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KarbariItem.Click
        DefKarbariFrm.ShowDialog()
    End Sub
    Private Sub KarshenasanItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KarshenasanItem.Click
        KarshenasanFrm.ShowDialog()
    End Sub
    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        KarshenasanFrm.ShowDialog()
    End Sub
    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        Dim frm As New ListKarshenasiFrm
        frm.ShowDialog()
    End Sub
    Private Sub OstanBaseItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OstanBaseItem.Click
        OstanAndShahBaseFrm.ShowDialog()
    End Sub

    Private Sub Backup_database_Item_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Backup_database_Item.Click
        Try
            If MsgBox("آيا محتويات بانك اطلاعاتي را كلاً پاك كرده و نسخه پشتيبان تهيه ميكنيد؟", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then

                Dim pt As New PersianToolS.PersinToolsClass
                Dim file_name As String = Path.GetFileName(PathFileDatabase)
                Dim L As Integer = file_name.Length
                Dim F_Name As String
                F_Name = "Back_" &
                pt.DateToPersian(Date.Now).year.ToString &
                pt.DateToPersian(Date.Now).month.ToString &
                pt.DateToPersian(Date.Now).day.ToString
                Dim P_File As String = Mid(PathFileDatabase, 1, PathFileDatabase.Length - L)
                P_File += F_Name
                Directory.CreateDirectory(P_File)
                P_File += "\"
                P_File += F_Name
                P_File += ".accdb"
                File.Copy(PathFileDatabase, P_File)

                Cn.ConnectionString = StrCon
                Dim Cmd As New OleDbCommand
                Cmd.CommandText = "Delete from MainKTable"
                Cmd.Connection = Cn
                Cn.Open()
                Cmd.ExecuteNonQuery()
                Cn.Close()

                Karshenasi_FileName = Path.GetFileName(PathFileDatabase)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub تهیهنسخهپشتیبانToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles تهیهنسخهپشتیبانToolStripMenuItem.Click

        Dim sBackUpFile As String = PathFileDatabase
        'Backup * .mdb database
        If File.Exists(PathFileDatabase) Then

            'Dim db As New DAO.DBEngin
            'CompactDatabase has two parameters, creates a copy of compact DB at the Destination path
            ' db.CompactDatabase(PathFileDatabase, sBackUpFile)
        End If
        'Restore the original file from the compacted file
        If File.Exists(sBackUpFile) Then
            File.Copy(sBackUpFile, PathFileDatabase, True)
        End If

    End Sub

    Private Sub Bank_Define_Item_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bank_Define_Item.Click
        Dim Bankfrm As New BankDefineFrm
        Bankfrm.ShowDialog()
    End Sub

    Private Sub Varizi_define_Item_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Varizi_define_Item.Click
        Dim Varizi_frm As New VariziFrm
        Varizi_frm.ShowDialog()
    End Sub
    Private Sub PictureBox3_MouseHover(sender As Object, e As EventArgs) Handles PictureBox3.MouseHover
        tt = New ToolTip()
        tt.Show("لیست مشخصات و تلفن کارشناسان", PictureBox3)
        tt = Nothing

    End Sub

    Private Sub PictureBox1_MouseHover(sender As Object, e As EventArgs) Handles PictureBox1.MouseHover
        tt = New ToolTip()
        tt.Show("ثبت پرونده جدید کارشناسی", PictureBox1)
        tt = Nothing
    End Sub

    Private Sub PictureBox2_MouseHover(sender As Object, e As EventArgs) Handles PictureBox2.MouseHover
        tt = New ToolTip()
        tt.Show("لیست  پروندههای کارشناسی ثبت شده", PictureBox2)
        tt = Nothing
    End Sub

    Private Sub SystemIdItem_Click(sender As Object, e As EventArgs) Handles SystemIdItem.Click
        Form1.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Call LockSystem()
    End Sub
End Class