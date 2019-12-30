<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OstanAndShahBaseFrm
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
        Me.OstanDataGrid = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OstanBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ShahrDataGrid = New System.Windows.Forms.DataGridView()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ShahrBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.RadStatusStrip1 = New Telerik.WinControls.UI.RadStatusStrip()
        CType(Me.OstanDataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OstanBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ShahrDataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ShahrBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadStatusStrip1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OstanDataGrid
        '
        Me.OstanDataGrid.AllowUserToResizeColumns = False
        Me.OstanDataGrid.AllowUserToResizeRows = False
        Me.OstanDataGrid.AutoGenerateColumns = False
        Me.OstanDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.OstanDataGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2})
        Me.OstanDataGrid.DataSource = Me.OstanBindingSource
        Me.OstanDataGrid.Location = New System.Drawing.Point(297, 2)
        Me.OstanDataGrid.MultiSelect = False
        Me.OstanDataGrid.Name = "OstanDataGrid"
        Me.OstanDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.OstanDataGrid.Size = New System.Drawing.Size(301, 457)
        Me.OstanDataGrid.TabIndex = 0
        '
        'Column1
        '
        Me.Column1.DataPropertyName = "Ocode"
        Me.Column1.HeaderText = "کد"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 50
        '
        'Column2
        '
        Me.Column2.DataPropertyName = "Ostan"
        Me.Column2.HeaderText = "استان"
        Me.Column2.Name = "Column2"
        Me.Column2.Width = 200
        '
        'OstanBindingSource
        '
        '
        'ShahrDataGrid
        '
        Me.ShahrDataGrid.AllowUserToResizeColumns = False
        Me.ShahrDataGrid.AllowUserToResizeRows = False
        Me.ShahrDataGrid.AutoGenerateColumns = False
        Me.ShahrDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ShahrDataGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column3})
        Me.ShahrDataGrid.DataSource = Me.ShahrBindingSource
        Me.ShahrDataGrid.Location = New System.Drawing.Point(3, 2)
        Me.ShahrDataGrid.MultiSelect = False
        Me.ShahrDataGrid.Name = "ShahrDataGrid"
        Me.ShahrDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.ShahrDataGrid.Size = New System.Drawing.Size(292, 346)
        Me.ShahrDataGrid.TabIndex = 1
        '
        'Column3
        '
        Me.Column3.DataPropertyName = "Shahrestan"
        Me.Column3.HeaderText = "شهرستان"
        Me.Column3.Name = "Column3"
        Me.Column3.Width = 240
        '
        'RadStatusStrip1
        '
        Me.RadStatusStrip1.AutoSize = True
        Me.RadStatusStrip1.LayoutStyle = Telerik.WinControls.UI.RadStatusBarLayoutStyle.Stack
        Me.RadStatusStrip1.Location = New System.Drawing.Point(0, 463)
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
        'OstanAndShahBaseFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(602, 491)
        Me.Controls.Add(Me.RadStatusStrip1)
        Me.Controls.Add(Me.ShahrDataGrid)
        Me.Controls.Add(Me.OstanDataGrid)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "OstanAndShahBaseFrm"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        '
        '
        '
        Me.RootElement.RightToLeft = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "تعریف استانها و شهرستانهای کشور"
        Me.ThemeName = "Office2007Black"
        CType(Me.OstanDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OstanBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ShahrDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ShahrBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadStatusStrip1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OstanDataGrid As System.Windows.Forms.DataGridView
    Friend WithEvents ShahrDataGrid As System.Windows.Forms.DataGridView
    Friend WithEvents OstanBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ShahrBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RadStatusStrip1 As Telerik.WinControls.UI.RadStatusStrip
End Class
