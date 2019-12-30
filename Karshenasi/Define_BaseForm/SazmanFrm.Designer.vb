<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SazmanFrm
    'Inherits System.Windows.Forms.Form
    Inherits Telerik.WinControls.RadForm
    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SazmanBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.UnitBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Tel_Panel = New System.Windows.Forms.Panel()
        Me.Tel_DataGrid = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tel_BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.RadStatusStrip1 = New Telerik.WinControls.UI.RadStatusStrip()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SazmanBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UnitBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tel_Panel.SuspendLayout()
        CType(Me.Tel_DataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tel_BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadStatusStrip1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2})
        Me.DataGridView1.DataSource = Me.SazmanBindingSource
        Me.DataGridView1.Location = New System.Drawing.Point(577, 2)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 27
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(360, 537)
        Me.DataGridView1.TabIndex = 0
        '
        'Column1
        '
        Me.Column1.DataPropertyName = "Sid"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle1
        Me.Column1.HeaderText = "کد"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 50
        '
        'Column2
        '
        Me.Column2.DataPropertyName = "Sazman"
        Me.Column2.HeaderText = "نام سازمان مرتبط"
        Me.Column2.Name = "Column2"
        Me.Column2.Width = 250
        '
        'SazmanBindingSource
        '
        '
        'DataGridView2
        '
        Me.DataGridView2.AutoGenerateColumns = False
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn2, Me.Column6, Me.Column3, Me.Column4})
        Me.DataGridView2.DataSource = Me.SazmanBindingSource
        Me.DataGridView2.Location = New System.Drawing.Point(0, 2)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.RowTemplate.Height = 27
        Me.DataGridView2.Size = New System.Drawing.Size(577, 537)
        Me.DataGridView2.TabIndex = 1
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "KUnit"
        Me.DataGridViewTextBoxColumn2.HeaderText = "نوع یا واحد درخواست کننده کارشناسی"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 270
        '
        'Column6
        '
        Me.Column6.HeaderText = "تلفن"
        Me.Column6.Name = "Column6"
        Me.Column6.Text = "محتوی"
        Me.Column6.UseColumnTextForLinkValue = True
        Me.Column6.Width = 70
        '
        'Column3
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column3.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column3.HeaderText = "نمونه فرم کارشناسی"
        Me.Column3.Name = "Column3"
        Me.Column3.Text = "محتوی"
        Me.Column3.UseColumnTextForLinkValue = True
        Me.Column3.Width = 80
        '
        'Column4
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column4.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column4.HeaderText = "نمونه فرم حق الزحمه کارشناسی"
        Me.Column4.Name = "Column4"
        Me.Column4.Text = "محتوی"
        Me.Column4.UseColumnTextForLinkValue = True
        '
        'Tel_Panel
        '
        Me.Tel_Panel.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.Tel_Panel.Controls.Add(Me.Tel_DataGrid)
        Me.Tel_Panel.Location = New System.Drawing.Point(616, 12)
        Me.Tel_Panel.Name = "Tel_Panel"
        Me.Tel_Panel.Size = New System.Drawing.Size(257, 296)
        Me.Tel_Panel.TabIndex = 3
        Me.Tel_Panel.Visible = False
        '
        'Tel_DataGrid
        '
        Me.Tel_DataGrid.AutoGenerateColumns = False
        Me.Tel_DataGrid.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.Tel_DataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Tel_DataGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1})
        Me.Tel_DataGrid.DataSource = Me.Tel_BindingSource
        Me.Tel_DataGrid.Location = New System.Drawing.Point(0, 0)
        Me.Tel_DataGrid.Name = "Tel_DataGrid"
        Me.Tel_DataGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.Tel_DataGrid.RowHeadersWidth = 35
        Me.Tel_DataGrid.RowTemplate.Height = 25
        Me.Tel_DataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.Tel_DataGrid.Size = New System.Drawing.Size(254, 291)
        Me.Tel_DataGrid.TabIndex = 2
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "Tell_number"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewTextBoxColumn1.HeaderText = "شماره تلفن"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn1.Width = 200
        '
        'RadStatusStrip1
        '
        Me.RadStatusStrip1.AutoSize = True
        Me.RadStatusStrip1.LayoutStyle = Telerik.WinControls.UI.RadStatusBarLayoutStyle.Stack
        Me.RadStatusStrip1.Location = New System.Drawing.Point(0, 538)
        Me.RadStatusStrip1.Name = "RadStatusStrip1"
        '
        '
        '
        Me.RadStatusStrip1.RootElement.RightToLeft = True
        Me.RadStatusStrip1.Size = New System.Drawing.Size(939, 30)
        Me.RadStatusStrip1.SizingGrip = False
        Me.RadStatusStrip1.TabIndex = 4
        Me.RadStatusStrip1.Text = "RadStatusStrip1"
        Me.RadStatusStrip1.ThemeName = "Office2007Black"
        '
        'SazmanFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(939, 568)
        Me.Controls.Add(Me.RadStatusStrip1)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Tel_Panel)
        Me.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "SazmanFrm"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        '
        '
        '
        Me.RootElement.RightToLeft = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "سازمانهای مرتبط"
        Me.ThemeName = "Office2007Black"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SazmanBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UnitBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tel_Panel.ResumeLayout(False)
        CType(Me.Tel_DataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tel_BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadStatusStrip1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents SazmanBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents UnitBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Tel_Panel As System.Windows.Forms.Panel
    Friend WithEvents Tel_DataGrid As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tel_BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents RadStatusStrip1 As Telerik.WinControls.UI.RadStatusStrip
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
End Class
