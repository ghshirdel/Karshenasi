<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DefKarbariFrm
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KarbariBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Type_Kar_DataGrid = New System.Windows.Forms.DataGridView()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Type_kar_BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.RadStatusStrip1 = New Telerik.WinControls.UI.RadStatusStrip()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KarbariBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Type_Kar_DataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Type_kar_BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadStatusStrip1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2})
        Me.DataGridView1.DataSource = Me.KarbariBindingSource
        Me.DataGridView1.Location = New System.Drawing.Point(344, 0)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DataGridView1.Size = New System.Drawing.Size(258, 434)
        Me.DataGridView1.TabIndex = 0
        '
        'Column1
        '
        Me.Column1.DataPropertyName = "KarId"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column1.HeaderText = "کد"
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 50
        '
        'Column2
        '
        Me.Column2.DataPropertyName = "Karbari"
        Me.Column2.HeaderText = "نوع کاربری"
        Me.Column2.Name = "Column2"
        Me.Column2.Width = 150
        '
        'KarbariBindingSource
        '
        '
        'Type_Kar_DataGrid
        '
        Me.Type_Kar_DataGrid.AllowUserToResizeColumns = False
        Me.Type_Kar_DataGrid.AllowUserToResizeRows = False
        Me.Type_Kar_DataGrid.AutoGenerateColumns = False
        Me.Type_Kar_DataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Type_Kar_DataGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column3, Me.Column4})
        Me.Type_Kar_DataGrid.DataSource = Me.Type_kar_BindingSource
        Me.Type_Kar_DataGrid.Location = New System.Drawing.Point(0, 1)
        Me.Type_Kar_DataGrid.MultiSelect = False
        Me.Type_Kar_DataGrid.Name = "Type_Kar_DataGrid"
        Me.Type_Kar_DataGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.Type_Kar_DataGrid.Size = New System.Drawing.Size(338, 434)
        Me.Type_Kar_DataGrid.TabIndex = 1
        '
        'Column3
        '
        Me.Column3.DataPropertyName = "Type_Kar_Desc"
        Me.Column3.HeaderText = "نوع کارشناسی"
        Me.Column3.Name = "Column3"
        Me.Column3.Width = 150
        '
        'Column4
        '
        Me.Column4.DataPropertyName = "Not_Price"
        Me.Column4.HeaderText = "عدم تاثیر مبلغ کارشناسی در محاسبه دستمزد"
        Me.Column4.Name = "Column4"
        Me.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column4.Width = 130
        '
        'RadStatusStrip1
        '
        Me.RadStatusStrip1.AutoSize = True
        Me.RadStatusStrip1.LayoutStyle = Telerik.WinControls.UI.RadStatusBarLayoutStyle.Stack
        Me.RadStatusStrip1.Location = New System.Drawing.Point(0, 412)
        Me.RadStatusStrip1.Name = "RadStatusStrip1"
        '
        '
        '
        Me.RadStatusStrip1.RootElement.RightToLeft = True
        Me.RadStatusStrip1.Size = New System.Drawing.Size(602, 28)
        Me.RadStatusStrip1.SizingGrip = False
        Me.RadStatusStrip1.TabIndex = 2
        Me.RadStatusStrip1.Text = "RadStatusStrip1"
        Me.RadStatusStrip1.ThemeName = "Office2007Black"
        '
        'DefKarbariFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(602, 440)
        Me.Controls.Add(Me.RadStatusStrip1)
        Me.Controls.Add(Me.Type_Kar_DataGrid)
        Me.Controls.Add(Me.DataGridView1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DefKarbariFrm"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        '
        '
        '
        Me.RootElement.RightToLeft = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "تعریف کاربری املاک"
        Me.ThemeName = "Office2007Black"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KarbariBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Type_Kar_DataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Type_kar_BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadStatusStrip1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents KarbariBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Type_Kar_DataGrid As System.Windows.Forms.DataGridView
    Friend WithEvents Type_kar_BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents RadStatusStrip1 As Telerik.WinControls.UI.RadStatusStrip
End Class
