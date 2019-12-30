Imports System
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports System.Runtime.InteropServices
Imports WIA
Public Class Pic_Viewer
    Inherits System.Windows.Forms.Form
    Dim i As Integer = 0
    Dim MyImage As Bitmap
    Dim Viewer As netPicview
    Dim LoadComplete As Boolean = False
    Dim Cn As OleDbConnection
    Dim Pdv As DataView
    Dim Pid As Integer
    Dim SelectedDevice As WIA.Device
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Dim flag As Boolean = False
    Friend WithEvents PictureBox1 As Windows.Forms.PictureBox
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents btnAttach As Windows.Forms.Button
    Friend WithEvents btnSave As Windows.Forms.Button
    Friend WithEvents btnPrint As Windows.Forms.Button
    Friend WithEvents btnScan As Windows.Forms.Button
    Friend WithEvents btnDel As Windows.Forms.Button
    Dim MStream As IO.MemoryStream = Nothing

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents BindingNavigator1 As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PictureBindingSource As System.Windows.Forms.BindingSource
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Pic_Viewer))
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnDel = New System.Windows.Forms.Button()
        Me.btnAttach = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnScan = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.BindingNavigator1 = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.PictureBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BindingNavigator1.SuspendLayout()
        CType(Me.PictureBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.AutoScroll = True
        Me.Panel2.AutoSize = True
        Me.Panel2.Controls.Add(Me.btnDel)
        Me.Panel2.Controls.Add(Me.btnAttach)
        Me.Panel2.Controls.Add(Me.btnSave)
        Me.Panel2.Controls.Add(Me.btnPrint)
        Me.Panel2.Controls.Add(Me.btnScan)
        Me.Panel2.Controls.Add(Me.PictureBox1)
        Me.Panel2.Controls.Add(Me.BindingNavigator1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1071, 881)
        Me.Panel2.TabIndex = 4
        '
        'btnDel
        '
        Me.btnDel.BackgroundImage = Global.Karshenasi.My.Resources.Resources.Delete_file
        Me.btnDel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnDel.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDel.Location = New System.Drawing.Point(430, 28)
        Me.btnDel.Name = "btnDel"
        Me.btnDel.Size = New System.Drawing.Size(97, 84)
        Me.btnDel.TabIndex = 8
        Me.btnDel.Text = "حذف فایل"
        Me.btnDel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDel.UseVisualStyleBackColor = True
        '
        'btnAttach
        '
        Me.btnAttach.BackgroundImage = Global.Karshenasi.My.Resources.Resources.Attach
        Me.btnAttach.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnAttach.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAttach.Location = New System.Drawing.Point(327, 28)
        Me.btnAttach.Name = "btnAttach"
        Me.btnAttach.Size = New System.Drawing.Size(97, 84)
        Me.btnAttach.TabIndex = 7
        Me.btnAttach.Text = "اضافه کردن فایل"
        Me.btnAttach.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAttach.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.BackgroundImage = Global.Karshenasi.My.Resources.Resources.Custom_Icon_Design_Pretty_Office_7_Save
        Me.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnSave.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(224, 28)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(97, 84)
        Me.btnSave.TabIndex = 6
        Me.btnSave.Text = "ذخیره"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSave.UseVisualStyleBackColor = True
        Me.btnSave.Visible = False
        '
        'btnPrint
        '
        Me.btnPrint.BackgroundImage = Global.Karshenasi.My.Resources.Resources.Printer
        Me.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnPrint.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.Location = New System.Drawing.Point(121, 28)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(97, 84)
        Me.btnPrint.TabIndex = 5
        Me.btnPrint.Text = "پرینت"
        Me.btnPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnScan
        '
        Me.btnScan.BackgroundImage = Global.Karshenasi.My.Resources.Resources.Devices_scanner1
        Me.btnScan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnScan.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnScan.Location = New System.Drawing.Point(12, 28)
        Me.btnScan.Name = "btnScan"
        Me.btnScan.Size = New System.Drawing.Size(103, 84)
        Me.btnScan.TabIndex = 4
        Me.btnScan.Text = "اسکن"
        Me.btnScan.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnScan.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(12, 118)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1047, 760)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'BindingNavigator1
        '
        Me.BindingNavigator1.AddNewItem = Nothing
        Me.BindingNavigator1.BindingSource = Me.PictureBindingSource
        Me.BindingNavigator1.CountItem = Me.BindingNavigatorCountItem
        Me.BindingNavigator1.DeleteItem = Nothing
        Me.BindingNavigator1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2})
        Me.BindingNavigator1.Location = New System.Drawing.Point(0, 0)
        Me.BindingNavigator1.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.BindingNavigator1.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.BindingNavigator1.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.BindingNavigator1.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.BindingNavigator1.Name = "BindingNavigator1"
        Me.BindingNavigator1.PositionItem = Me.BindingNavigatorPositionItem
        Me.BindingNavigator1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.BindingNavigator1.Size = New System.Drawing.Size(1071, 25)
        Me.BindingNavigator1.TabIndex = 1
        Me.BindingNavigator1.Text = "BindingNavigator1"
        '
        'PictureBindingSource
        '
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(35, 22)
        Me.BindingNavigatorCountItem.Text = "of {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem.Text = "Move first"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMovePreviousItem.Text = "Move previous"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 21)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Current position"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveNextItem.Text = "Move next"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveLastItem.Text = "Move last"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'PrintDocument1
        '
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'Pic_Viewer
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.AutoScroll = True
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1071, 881)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "Pic_Viewer"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BindingNavigator1.ResumeLayout(False)
        Me.BindingNavigator1.PerformLayout()
        CType(Me.PictureBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    Public Property Get_Data()
        Get
            Return 0
        End Get
        Set(ByVal value)
            i = value
        End Set
    End Property
    Private Sub Init_PictureDatagrid()
        Try
            Cn = New OleDbConnection
            Cn.ConnectionString = StrCon
            Cn.Open()
            Dim da As New OleDbDataAdapter("Select * from PictureTable where Kid=" & Kid, Cn)
            Dim Pds As New DataSet
            da.Fill(Pds, "pictureTable")
            Pdv = New DataView(Pds.Tables(0))
            Me.PictureBindingSource.DataSource = Pdv
            Cn.Close()
            If Pdv.Table.Rows.Count > 0 Then
                btnDel.Enabled = True
            Else
                btnDel.Enabled = False
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub LoadPictureFromDatabase()
        Try
            If Me.PictureBindingSource.Position <> -1 Then

                Dim dr As DataRow
                dr = Pdv.Item(Me.PictureBindingSource.Position).Row
                If dr.ItemArray(1) IsNot DBNull.Value Then
                    Dim ImgBytes() As Byte = DirectCast(dr.ItemArray(1), Byte())
                    MStream = New IO.MemoryStream(ImgBytes)
                    'Create a Bitmap from the memory stream data
                    Dim Bmp As New Drawing.Bitmap(MStream)
                    PictureBox1.Image = Bmp
                End If
            Else
                btnDel.Enabled = False
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub PictureBindingSource_PositionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBindingSource.PositionChanged
        Panel2.BackgroundImage = Nothing
        Call LoadPictureFromDatabase()
    End Sub
    Private Sub PictureViewerFrm_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Private Sub Pic_Viewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If i = 0 Then
            If MsgBox("آیا فرم نظریه کارشناسی را درون اسکنر قرار داده اید؟", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                Call detect_Scanner()
                Dim Sresult As MsgBoxResult
                Sresult = MsgBox("آیا تصویر اسکن شده را ذخیره میکنید ؟", MsgBoxStyle.OkCancel)
                If Sresult = MsgBoxResult.Ok Then
                    Call LoadPrictureFromFile()
                Else
                    PictureBox1.Image = Nothing
                    Call LoadPictureFromDatabase()
                End If
            End If
        Else
            Init_PictureDatagrid()
            If PictureBindingSource.Position <> -1 Then

            End If
        End If
    End Sub
    Private Sub LoadPrictureFromFile()
        Try
            Dim arrImage() As Byte
            Dim myMs As New IO.MemoryStream
            PictureBox1.Image.Save(myMs, System.Drawing.Imaging.ImageFormat.Jpeg)
            arrImage = myMs.GetBuffer

            Dim Str As String
            Str = "insert into PictureTable(Kid,pic) values(?,?)"
            Dim Cn As New OleDbConnection
            Dim Cmd As OleDbCommand
            Cn.ConnectionString = StrCon
            Cmd = New OleDbCommand(Str, Cn)
            Cmd.Parameters.Add("@Kid", OleDbType.Integer).Value = Kid
            Cmd.Parameters.Add("@Pic", OleDbType.Binary).Value = arrImage
            Cn.Open()
            Cmd.ExecuteNonQuery()
            Cn.Close()

            If MStream IsNot Nothing Then
                MStream.Dispose()
            End If
            Call Init_PictureDatagrid()
            Call LoadPictureFromDatabase()
        Finally
            'infile.Close()
        End Try

    End Sub
    Private Sub PrintDocument1_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        e.Graphics.DrawImage(Viewer.Image, 0, 0)
    End Sub
    Private Sub detect_Scanner()
        Try
            Dim CD As New WIA.CommonDialog
            Dim F As WIA.ImageFile = CD.ShowAcquireImage(WIA.WiaDeviceType.ScannerDeviceType)
            'Dim t As WIA.ICommonDialog

            If F IsNot Nothing Then
                'Convert the raw scanner output into a byte array
                Dim ImgBytes() As Byte = DirectCast(F.FileData.BinaryData, Byte())
                'Read the image data bytes into a MemoryStream
                MStream = New IO.MemoryStream(ImgBytes)
                'Create a Bitmap from the memory stream data
                Dim Bmp As New Drawing.Bitmap(MStream)
                'Assign the bitmap as the PictureBox Image
                PictureBox1.Image = Bmp
            End If
        Catch ex As Exception
            MsgBox("An error occurred while converting scan data to a bitmap: " & ex.Message)
            End Try

    End Sub

    Private Sub btnScan_Click(sender As Object, e As EventArgs) Handles btnScan.Click
        'Call ScanOrAttach()
        Dim Sresult As MsgBoxResult
        Call detect_Scanner()
        Sresult = MsgBox("آیا تصویر اسکن شده را ذخیره میکنید ؟", MsgBoxStyle.OkCancel)
        If Sresult = MsgBoxResult.Ok Then
            Call LoadPrictureFromFile()
            PictureBindingSource.MoveLast()
        Else
            PictureBox1.Image = Nothing
            Call LoadPictureFromDatabase()
            PictureBindingSource.MoveLast()
        End If

    End Sub
    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Try
            PrintDialog1 = New PrintDialog
            PrintDialog1.Document = PrintDocument1 'pbxLogo.Image
            Dim r As DialogResult = PrintDialog1.ShowDialog
            If r = DialogResult.OK Then
                PrintDocument1.Print()

            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Call LoadPrictureFromFile()
        PictureBindingSource.MoveLast()
    End Sub

    Private Sub btnAttach_Click(sender As Object, e As EventArgs) Handles btnAttach.Click
        Try
            'btnSave.Enabled = True
            OpenFileDialog1.Filter = "JPG image (*.jpeg)|*.jpeg|BMP image (*.bmp)|*.bmp|All files (*.*)|*.*"
            OpenFileDialog1.ShowDialog()
            If OpenFileDialog1.FileName = "" Then Exit Sub
            MyImage = Bitmap.FromFile(OpenFileDialog1.FileName)
            PictureBox1.Image = MyImage
            Dim Sresult As MsgBoxResult
            Sresult = MsgBox("آیا تصویرانتخاب شذه را ذخیره میکنید ؟", MsgBoxStyle.OkCancel)
            If Sresult = MsgBoxResult.Ok Then
                Call LoadPrictureFromFile()
                PictureBindingSource.MoveLast()
            Else
                PictureBox1.Image = Nothing
                Call LoadPictureFromDatabase()
                PictureBindingSource.MoveLast()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click
        Try
            If MsgBox("آيا تصوير كارشناسي ثبت شده را حذف مي نمائيد؟", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                Dim dr As DataRow
                Dim Str As String = ""
                dr = Pdv.Item(Me.PictureBindingSource.Position).Row
                Pid = dr.ItemArray(2)
                Str = "delete from picturetable where pid=" & Pid
                Cn.ConnectionString = StrCon
                Cn.Open()
                Dim Cmd As New OleDbCommand(Str, Cn)
                Cmd.ExecuteNonQuery()
                Cn.Close()
                '                MyImage = Nothing
                'Viewer.Image = Nothing
                Call Init_PictureDatagrid()
                Call LoadPictureFromDatabase()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Function ScanOrAttach()
        btnSave.Enabled = True
        btnScan.Enabled = False
        btnAttach.Enabled = False
        btnDel.Enabled = False
        btnPrint.Enabled = False
        Return 0
    End Function
End Class
