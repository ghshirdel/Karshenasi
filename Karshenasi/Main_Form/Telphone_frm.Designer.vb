<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Telphone_frm
    Inherits System.Windows.Forms.Form

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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Telphone_frm))
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripPanelItem1 = New Syncfusion.Windows.Forms.Tools.ToolStripPanelItem
        Me.StatusStripButton1 = New Syncfusion.Windows.Forms.Tools.StatusStripButton
        Me.Tel_DataGrid = New System.Windows.Forms.DataGridView
        Me.Tel_BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StatusStrip1.SuspendLayout()
        CType(Me.Tel_DataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tel_BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripPanelItem1, Me.StatusStripButton1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 309)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(254, 23)
        Me.StatusStrip1.TabIndex = 0
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripPanelItem1
        '
        Me.ToolStripPanelItem1.CausesValidation = False
        Me.ToolStripPanelItem1.ForeColor = System.Drawing.Color.MidnightBlue
        Me.ToolStripPanelItem1.Name = "ToolStripPanelItem1"
        Me.ToolStripPanelItem1.ShowItemToolTips = False
        Me.ToolStripPanelItem1.Size = New System.Drawing.Size(23, 23)
        Me.ToolStripPanelItem1.Transparent = True
        '
        'StatusStripButton1
        '
        Me.StatusStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.StatusStripButton1.Image = CType(resources.GetObject("StatusStripButton1.Image"), System.Drawing.Image)
        Me.StatusStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.StatusStripButton1.Margin = New System.Windows.Forms.Padding(0, 4, 0, 2)
        Me.StatusStripButton1.Name = "StatusStripButton1"
        Me.StatusStripButton1.Size = New System.Drawing.Size(65, 17)
        Me.StatusStripButton1.Text = "بستن پنجره"
        '
        'Tel_DataGrid
        '
        Me.Tel_DataGrid.AutoGenerateColumns = False
        Me.Tel_DataGrid.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.Tel_DataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Tel_DataGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column2})
        Me.Tel_DataGrid.DataSource = Me.Tel_BindingSource
        Me.Tel_DataGrid.Location = New System.Drawing.Point(0, 1)
        Me.Tel_DataGrid.Name = "Tel_DataGrid"
        Me.Tel_DataGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.Tel_DataGrid.RowHeadersWidth = 35
        Me.Tel_DataGrid.RowTemplate.Height = 25
        Me.Tel_DataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.Tel_DataGrid.Size = New System.Drawing.Size(254, 305)
        Me.Tel_DataGrid.TabIndex = 1
        '
        'Column2
        '
        Me.Column2.DataPropertyName = "Tell_number"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Column2.DefaultCellStyle = DataGridViewCellStyle5
        Me.Column2.HeaderText = "شماره تلفن"
        Me.Column2.Name = "Column2"
        Me.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column2.Width = 200
        '
        'Telphone_frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(254, 332)
        Me.Controls.Add(Me.Tel_DataGrid)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Telphone_frm"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Text = "تلفن سازمانها"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.Tel_DataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tel_BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents Tel_BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Tel_DataGrid As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStripPanelItem1 As Syncfusion.Windows.Forms.Tools.ToolStripPanelItem
    Friend WithEvents StatusStripButton1 As Syncfusion.Windows.Forms.Tools.StatusStripButton
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
