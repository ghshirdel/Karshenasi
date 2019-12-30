<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VariziFrm
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
        Me.BankDataGrid = New System.Windows.Forms.DataGridView()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VariziBs = New System.Windows.Forms.BindingSource(Me.components)
        Me.RadStatusStrip1 = New Telerik.WinControls.UI.RadStatusStrip()
        CType(Me.BankDataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VariziBs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadStatusStrip1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BankDataGrid
        '
        Me.BankDataGrid.AutoGenerateColumns = False
        Me.BankDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.BankDataGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column2})
        Me.BankDataGrid.DataSource = Me.VariziBs
        Me.BankDataGrid.Location = New System.Drawing.Point(-1, -1)
        Me.BankDataGrid.Name = "BankDataGrid"
        Me.BankDataGrid.RowTemplate.Height = 25
        Me.BankDataGrid.Size = New System.Drawing.Size(258, 285)
        Me.BankDataGrid.TabIndex = 1
        '
        'Column2
        '
        Me.Column2.DataPropertyName = "VName"
        Me.Column2.HeaderText = "نحوه واریز وجه"
        Me.Column2.Name = "Column2"
        Me.Column2.Width = 200
        '
        'RadStatusStrip1
        '
        Me.RadStatusStrip1.AutoSize = True
        Me.RadStatusStrip1.LayoutStyle = Telerik.WinControls.UI.RadStatusBarLayoutStyle.Stack
        Me.RadStatusStrip1.Location = New System.Drawing.Point(0, 256)
        Me.RadStatusStrip1.Name = "RadStatusStrip1"
        '
        '
        '
        Me.RadStatusStrip1.RootElement.RightToLeft = True
        Me.RadStatusStrip1.Size = New System.Drawing.Size(257, 28)
        Me.RadStatusStrip1.SizingGrip = False
        Me.RadStatusStrip1.TabIndex = 2
        Me.RadStatusStrip1.Text = "RadStatusStrip1"
        Me.RadStatusStrip1.ThemeName = "Office2007Black"
        '
        'VariziFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(257, 284)
        Me.Controls.Add(Me.RadStatusStrip1)
        Me.Controls.Add(Me.BankDataGrid)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "VariziFrm"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        '
        '
        '
        Me.RootElement.RightToLeft = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "نحوه پرداخت"
        Me.ThemeName = "Office2007Black"
        CType(Me.BankDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VariziBs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadStatusStrip1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BankDataGrid As System.Windows.Forms.DataGridView
    Friend WithEvents VariziBs As System.Windows.Forms.BindingSource
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RadStatusStrip1 As Telerik.WinControls.UI.RadStatusStrip
End Class
