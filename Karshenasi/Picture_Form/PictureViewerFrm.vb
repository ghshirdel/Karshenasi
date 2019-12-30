Imports System
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Public Class PictureViewerFrm
    Dim Cn As OleDbConnection
    Dim Pdv As DataView
    Dim Pid As Integer
    Dim i As Integer


    Public Property Get_Data()
        Get
            Return 0
        End Get
        Set(ByVal value)
            i = value
        End Set
    End Property
    Private Sub PictureViewerFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Init_PictureDatagrid()
    End Sub
    Private Sub Init_PictureDatagrid()
        Try
            Cn = New OleDbConnection
            Cn.ConnectionString = StrCon
            Cn.Open()
            Dim da As New OleDbDataAdapter("Select * from PictureTable where Kid=" & Kid, Cn)
            Dim Pds As New DataSet
            da.Fill(Pds)
            Pdv = New DataView(Pds.Tables(0))
            Me.PictureBindingSource.DataSource = Pdv
            Cn.Close()
            If Pdv.Table.Rows.Count > 0 Then
                DeleteBtn.Enabled = True
            Else
                DeleteBtn.Enabled = False
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub LoadPictureFromDatabase()
        Try
            If Me.PictureBindingSource.Count > 0 Then
                Dim dr As DataRow
                dr = Pdv.Item(Me.PictureBindingSource.Position).Row
                If dr.ItemArray(1) IsNot DBNull.Value Then
                    Dim data() As Byte = dr.ItemArray(1)
                    Dim bmp As Image
                    Try
                        Dim buffer As New MemoryStream(data)
                        buffer.Position = 0
                        bmp = Bitmap.FromStream(buffer)
                        PictureBox1.Image = bmp
                        'Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
                        'PictureBox1.Image = ImageList1.Images.Item(4)
                        PictureBox1.Height = Me.Height - 100
                        PictureBox1.Width = Me.Width - 1000
                        'System.Diagnostics.Process.Start("C:\Windows\system32\rundll32.exe ", _
                        '"C:\Windows\system32\shimgvw.dll,ImageView_Fullscreen " & bmp)
                    Catch ex As Exception
                        MsgBox(ex.ToString)
                    End Try
                End If


                Dim x As Integer = PictureBox1.Image.Size.Width
                Dim Y As Integer = PictureBox1.Image.Size.Height

                x = 768 - PictureBox1.Image.Size.Height
                T3.Text = x
                T5.Text = Y
            Else
                PictureBox1.Image = Nothing
                DeleteBtn.Enabled = False
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub PictureBindingSource_PositionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBindingSource.PositionChanged
        Call LoadPictureFromDatabase()
    End Sub
    Private Sub PictureViewerFrm_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Private Sub DeleteBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteBtn.Click
        Try
            If MsgBox("آیا تصویر جاری را حذف میکنید؟", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
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
                Call Init_PictureDatagrid()
                Call LoadPictureFromDatabase()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub AttachmentBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AttachmentBtn.Click
        '   LoadPrictureFromFile()
    End Sub

    Private Sub ZoomIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ZoomIn.Click

        'If ((PictureBox1.Width < (MINMAX * Me.Width)) And (PictureBox1.Height < (MINMAX * Me.Height))) Then
        'PictureBox1.Width = Convert.ToInt32(PictureBox1.Width * ZOOMFACTOR)
        'PictureBox1.Height = Convert.ToInt32(PictureBox1.Height * ZOOMFACTOR)
        'PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        'End If
        'Dim x As Integer = PictureBox1.Image.Size.Width + 50
        'Dim Y As Integer = PictureBox1.Image.Size.Height + 50
        '
        '       T3.Text = x
        '      T5.Text = Y
        '     PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
    End Sub

    Private Sub ZoomOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ZoomOut.Click
        'If ((PictureBox1.Width > (Me.Width / MINMAX)) And (PictureBox1.Height > (Me.Height / MINMAX))) Then
        ' PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        ' PictureBox1.Width = Convert.ToInt32(PictureBox1.Width / ZOOMFACTOR)
        ' PictureBox1.Height = Convert.ToInt32(PictureBox1.Height / ZOOMFACTOR)
        ' End If
        ''PictureBox1.SizeMode = PictureBoxSizeMode.AutoSize
    End Sub
End Class