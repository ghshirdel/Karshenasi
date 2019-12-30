Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports System

Public Class AddPictureFrm
    Private Sub PictureViewerFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadPrictureFromFile()
    End Sub

    Private Sub LoadPrictureFromFile()
        Dim bmp As Image
        OpenFileDialog1.DefaultExt = "jpg"
        OpenFileDialog1.Filter = "Jpg Files(*.jpg)|*.jpg|*.bmp|Gif Files(*.gif)|*.gif|Bmp Files(*.bmp)"
        If Me.OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim infile As FileStream = File.OpenRead(Me.OpenFileDialog1.FileName)
            Try
                ' read the file into a byte array
                ReDim data(infile.Length - 1)
                infile.Read(data, 0, infile.Length)

                ' create a memorystream for the data
                Dim buffer As New MemoryStream(data)

                ' reset the memorystream's position to start
                buffer.Position = 0

                ' read the data into an image object
                bmp = Bitmap.FromStream(buffer)

            Finally
                infile.Close()
            End Try
            PictureBox1.Image = bmp
        End If
    End Sub

    Private Sub AddPictureFrm_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class