<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainFrm
    'Inherits System.Windows.Forms.Form
    Inherits Telerik.WinControls.RadForm
    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainFrm))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.KarshenasiParvItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.KarshenasanItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SazmanItam = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.KarbariItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OstanBaseItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripSeparator()
        Me.Bank_Define_Item = New System.Windows.Forms.ToolStripMenuItem()
        Me.Varizi_define_Item = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.ListKarshenasiFrm = New System.Windows.Forms.ToolStripMenuItem()
        Me.SetupMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.PathDatabaseItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.اسکنToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator()
        Me.Backup_database_Item = New System.Windows.Forms.ToolStripMenuItem()
        Me.تهیهنسخهپشتیبانToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripSeparator()
        Me.SystemIdItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.T1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.T3 = New System.Windows.Forms.ToolStripLabel()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.DesertTheme1 = New Telerik.WinControls.Themes.DesertTheme()
        Me.Office2007BlackTheme1 = New Telerik.WinControls.Themes.Office2007BlackTheme()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BsLock = New System.Windows.Forms.BindingSource(Me.components)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.MenuStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BsLock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.Gray
        Me.MenuStrip1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileMenu, Me.ToolStripMenuItem2, Me.ReportMenu, Me.SetupMenu})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1013, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileMenu
        '
        Me.FileMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.KarshenasiParvItem, Me.ToolStripMenuItem1, Me.KarshenasanItem, Me.ToolStripSeparator2, Me.ExitItem})
        Me.FileMenu.Name = "FileMenu"
        Me.FileMenu.Size = New System.Drawing.Size(42, 20)
        Me.FileMenu.Text = "فايل"
        '
        'KarshenasiParvItem
        '
        Me.KarshenasiParvItem.Image = Global.Karshenasi.My.Resources.Resources.pen_tool
        Me.KarshenasiParvItem.Name = "KarshenasiParvItem"
        Me.KarshenasiParvItem.Size = New System.Drawing.Size(242, 22)
        Me.KarshenasiParvItem.Text = "ثبت نظريه كارشناسي"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(239, 6)
        '
        'KarshenasanItem
        '
        Me.KarshenasanItem.Image = Global.Karshenasi.My.Resources.Resources.users
        Me.KarshenasanItem.Name = "KarshenasanItem"
        Me.KarshenasanItem.Size = New System.Drawing.Size(242, 22)
        Me.KarshenasanItem.Text = "کارشناسان رسمی دادگستری"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(239, 6)
        '
        'ExitItem
        '
        Me.ExitItem.Image = Global.Karshenasi.My.Resources.Resources._Exit
        Me.ExitItem.ImageTransparentColor = System.Drawing.Color.DarkGray
        Me.ExitItem.Name = "ExitItem"
        Me.ExitItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.ExitItem.Size = New System.Drawing.Size(242, 22)
        Me.ExitItem.Text = "خروج"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SazmanItam, Me.ToolStripMenuItem3, Me.KarbariItem, Me.OstanBaseItem, Me.ToolStripMenuItem4, Me.Bank_Define_Item, Me.Varizi_define_Item})
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(78, 20)
        Me.ToolStripMenuItem2.Text = "تعاریف پایه"
        '
        'SazmanItam
        '
        Me.SazmanItam.Image = Global.Karshenasi.My.Resources.Resources.pen_tool
        Me.SazmanItam.Name = "SazmanItam"
        Me.SazmanItam.Size = New System.Drawing.Size(264, 22)
        Me.SazmanItam.Text = "سازمانهای مرتبط"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(261, 6)
        '
        'KarbariItem
        '
        Me.KarbariItem.Image = Global.Karshenasi.My.Resources.Resources.pen_tool
        Me.KarbariItem.Name = "KarbariItem"
        Me.KarbariItem.Size = New System.Drawing.Size(264, 22)
        Me.KarbariItem.Text = "تعریف کاربری املاک"
        '
        'OstanBaseItem
        '
        Me.OstanBaseItem.Image = Global.Karshenasi.My.Resources.Resources.pen_tool
        Me.OstanBaseItem.Name = "OstanBaseItem"
        Me.OstanBaseItem.Size = New System.Drawing.Size(264, 22)
        Me.OstanBaseItem.Text = "تعریف استان و شهرستانهای تابعه "
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(261, 6)
        '
        'Bank_Define_Item
        '
        Me.Bank_Define_Item.Name = "Bank_Define_Item"
        Me.Bank_Define_Item.Size = New System.Drawing.Size(264, 22)
        Me.Bank_Define_Item.Text = "تعریف بانکها"
        '
        'Varizi_define_Item
        '
        Me.Varizi_define_Item.Name = "Varizi_define_Item"
        Me.Varizi_define_Item.Size = New System.Drawing.Size(264, 22)
        Me.Varizi_define_Item.Text = "تعریف نوع مبالغ  واریزی"
        '
        'ReportMenu
        '
        Me.ReportMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ListKarshenasiFrm})
        Me.ReportMenu.Name = "ReportMenu"
        Me.ReportMenu.Size = New System.Drawing.Size(67, 20)
        Me.ReportMenu.Text = "گزارشات"
        '
        'ListKarshenasiFrm
        '
        Me.ListKarshenasiFrm.Image = Global.Karshenasi.My.Resources.Resources.Test
        Me.ListKarshenasiFrm.Name = "ListKarshenasiFrm"
        Me.ListKarshenasiFrm.Size = New System.Drawing.Size(261, 22)
        Me.ListKarshenasiFrm.Text = "ليست كارشناسي هاي ثبت شده"
        '
        'SetupMenu
        '
        Me.SetupMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PathDatabaseItem, Me.اسکنToolStripMenuItem, Me.Backup_database_Item, Me.تهیهنسخهپشتیبانToolStripMenuItem, Me.ToolStripMenuItem5, Me.SystemIdItem})
        Me.SetupMenu.Name = "SetupMenu"
        Me.SetupMenu.Size = New System.Drawing.Size(66, 20)
        Me.SetupMenu.Text = "تنظيمات"
        '
        'PathDatabaseItem
        '
        Me.PathDatabaseItem.Image = Global.Karshenasi.My.Resources.Resources.Repair
        Me.PathDatabaseItem.Name = "PathDatabaseItem"
        Me.PathDatabaseItem.Size = New System.Drawing.Size(279, 22)
        Me.PathDatabaseItem.Text = "مسير بانك اطلاعاني"
        '
        'اسکنToolStripMenuItem
        '
        Me.اسکنToolStripMenuItem.Name = "اسکنToolStripMenuItem"
        Me.اسکنToolStripMenuItem.Size = New System.Drawing.Size(276, 6)
        '
        'Backup_database_Item
        '
        Me.Backup_database_Item.Name = "Backup_database_Item"
        Me.Backup_database_Item.Size = New System.Drawing.Size(279, 22)
        Me.Backup_database_Item.Text = "تهيه نسخه پشتيبان از بانك اطلاعاتي"
        '
        'تهیهنسخهپشتیبانToolStripMenuItem
        '
        Me.تهیهنسخهپشتیبانToolStripMenuItem.Name = "تهیهنسخهپشتیبانToolStripMenuItem"
        Me.تهیهنسخهپشتیبانToolStripMenuItem.Size = New System.Drawing.Size(279, 22)
        Me.تهیهنسخهپشتیبانToolStripMenuItem.Text = "تهیه نسخه پشتیبان"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(276, 6)
        '
        'SystemIdItem
        '
        Me.SystemIdItem.Name = "SystemIdItem"
        Me.SystemIdItem.Size = New System.Drawing.Size(279, 22)
        Me.SystemIdItem.Text = "مشخصات سیستم"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.T1, Me.ToolStripSeparator1, Me.ToolStripLabel2, Me.T3})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 307)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1013, 25)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(37, 22)
        Me.ToolStripLabel1.Text = "تاريخ: "
        '
        'T1
        '
        Me.T1.Name = "T1"
        Me.T1.Size = New System.Drawing.Size(88, 22)
        Me.T1.Text = "ToolStripLabel2"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(111, 22)
        Me.ToolStripLabel2.Text = "مسیر بانک اطلاعاتی :"
        '
        'T3
        '
        Me.T3.ForeColor = System.Drawing.Color.Maroon
        Me.T3.Name = "T3"
        Me.T3.Size = New System.Drawing.Size(88, 22)
        Me.T3.Text = "ToolStripLabel3"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(284, 27)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(487, 273)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox2.Image = Global.Karshenasi.My.Resources.Resources._01
        Me.PictureBox2.Location = New System.Drawing.Point(12, 27)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(266, 273)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 6
        Me.PictureBox2.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(777, 27)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(236, 273)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox3.TabIndex = 5
        Me.PictureBox3.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(786, 267)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 19)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Label1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(619, 267)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 19)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Label2"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(45, 267)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 19)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Label3"
        '
        'Button1
        '
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(428, 113)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(185, 173)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "قفل نرم افزار"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = True
        '
        'MainFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1013, 332)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox3)
        Me.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MainFrm"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        '
        '
        '
        Me.RootElement.RightToLeft = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "نرم افزار ثبت كارشناسي هاي املاك"
        Me.ThemeName = "Office2007Black"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BsLock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents KarshenasiParvItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ListKarshenasiFrm As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents SetupMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PathDatabaseItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents T1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents T3 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SazmanItam As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents KarbariItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents KarshenasanItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents OstanBaseItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DesertTheme1 As Telerik.WinControls.Themes.DesertTheme
    Friend WithEvents Office2007BlackTheme1 As Telerik.WinControls.Themes.Office2007BlackTheme
    Friend WithEvents اسکنToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Backup_database_Item As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents تهیهنسخهپشتیبانToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Bank_Define_Item As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Varizi_define_Item As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ToolStripMenuItem5 As ToolStripSeparator
    Friend WithEvents SystemIdItem As ToolStripMenuItem
    Friend WithEvents BsLock As BindingSource
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
