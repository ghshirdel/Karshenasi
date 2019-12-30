Public Class WDate_fa_frm
    Dim Date_fa() As Object
    Dim pt As New PersianToolS.PersinToolsClass
    Public Property Get_Date()
        Get
            Return Date_fa
        End Get
        Set(ByVal value)
            Date_fa = value
        End Set
    End Property

    Private Sub WDate_fa_frm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Date_fa(2) <> "" Then
            FaMonthView1.SelectedDateTime = pt.PersianToDate(Date_fa(2))
        End If
        Me.Location = New Drawing.Point(Date_fa(0), Date_fa(1))
    End Sub

    Private Sub FaMonthView1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FaMonthView1.DoubleClick
        Return_Flag = True
        Date_return = pt.DateToPersian(FaMonthView1.SelectedDateTime).ShortDate
        Me.Close()
    End Sub

    Private Sub WDate_fa_frm_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        Me.Close()
    End Sub
End Class