<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WDate_fa_frm
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
        Me.FaMonthView1 = New FarsiLibrary.Win.Controls.FAMonthView
        Me.SuspendLayout()
        '
        'FaMonthView1
        '
        Me.FaMonthView1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.FaMonthView1.IsNull = False
        Me.FaMonthView1.Location = New System.Drawing.Point(2, 2)
        Me.FaMonthView1.Name = "FaMonthView1"
        Me.FaMonthView1.SelectedDateTime = New Date(2009, 9, 8, 10, 52, 18, 203)
        Me.FaMonthView1.TabIndex = 0
        Me.FaMonthView1.Theme = FarsiLibrary.Win.Enums.ThemeTypes.Office2003
        '
        'WDate_fa_frm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(169, 171)
        Me.Controls.Add(Me.FaMonthView1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "WDate_fa_frm"
        Me.ShowInTaskbar = False
        Me.Text = "WDate_fa_frm"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents FaMonthView1 As FarsiLibrary.Win.Controls.FAMonthView
End Class
