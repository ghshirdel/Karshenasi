
Public Class netPicview
    'Host control , host control graphics , and source bitmap
    Dim Host As New Control
    Dim Gr As Graphics
    Dim srcBitmap As Bitmap

    'Source bitmap Handle
    Dim HBitmapSrc As IntPtr

    'Source DC handle , Destination DC handle
    Dim srcHDC As IntPtr
    Dim desHDC As IntPtr

    Dim P As PointF
    Dim CP As PointF
    Dim CS As PointF

    'Main rectangle , Boundary rectangle
    Dim Mrec As RectangleF
    Dim Brec As RectangleF

    'current zoom , minimum zoom , maximum zoom ,previous zoom (bigger means zoom in)
    Dim Zfactor As Single = 1
    Dim MinZ As Single = 0.05
    Dim MaxZ As Single = 20
    Dim oldZfactor As Single = 1

    Dim Xout As Boolean = False
    Dim Yout As Boolean = False
    Dim HostLoadComplete As Boolean = False
    Dim DownPress As Boolean = False

    Public Sub New(ByVal HostControl As Control, ByVal SourceImage As Bitmap)
        Host = HostControl
        srcBitmap = SourceImage

        AddHandler Host.MouseDown, AddressOf Host_MouseDown
        AddHandler Host.MouseUp, AddressOf Host_MouseUp
        AddHandler Host.MouseMove, AddressOf Host_MouseMove
        AddHandler Host.Paint, AddressOf Host_Paint
        AddHandler Host.Resize, AddressOf Host_resize

        srcHDC = Nothing
        desHDC = Nothing
        HostLoadComplete = True
    End Sub
    
    Private Sub Host_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs)
        DrawPic(0, 0)
    End Sub

    Private Sub Host_resize(ByVal sender As Object, ByVal e As System.EventArgs)
        If HostLoadComplete = True Then
            DrawPic(0, 0)
        End If
    End Sub

    Private Sub Host_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If IsNothing(srcBitmap) Then Exit Sub

        DownPress = False
        Host.Cursor = Cursors.Arrow

        If CS.X = e.X And CS.Y = e.Y Then
            If e.Button = MouseButtons.Left Then
                If Zfactor > MaxZ Then Exit Sub
                oldZfactor = Zfactor
                Zfactor = Zfactor * 1.3
                DrawPic(e.X, e.Y)
            ElseIf e.Button = MouseButtons.Right Then
                If Zfactor < MinZ Then Exit Sub
                oldZfactor = Zfactor
                Zfactor = Zfactor / 1.3
                DrawPic(e.X, e.Y)
            End If
            RaiseEvent ZoomChanged(Zfactor)
        End If
    End Sub

    Private Sub Host_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If IsNothing(srcBitmap) Then Exit Sub

        P.X = e.X
        P.Y = e.Y
        CP.X = 0
        CP.Y = 0
        CS.X = e.X
        CS.Y = e.Y
        DownPress = True


    End Sub

    Private Sub Host_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If IsNothing(srcBitmap) Then Exit Sub

        If DownPress = True Then
            Host.Cursor = Cursors.NoMove2D

            'accelerated scrolling when right click drag ----------------
            If e.Button = MouseButtons.Right Then
                CP.X = (P.X - e.X) * (srcBitmap.Width / 2000)
                CP.Y = (P.Y - e.Y) * (srcBitmap.Height / 2000)
            End If


            Mrec.X = ((P.X - e.X) / Zfactor) + Mrec.X + CP.X
            Mrec.Y = ((P.Y - e.Y) / Zfactor) + Mrec.Y + CP.Y
            DrawPic(0, 0)
            If Xout = False Then
                P.X = e.X
            End If
            If Yout = False Then
                P.Y = e.Y
            End If


        End If

        RaiseEvent MoveOver((e.X - Brec.X) / Zfactor + Mrec.X, (e.Y - Brec.Y) / Zfactor + Mrec.Y)

    End Sub

    Private Function DrawPic(ByVal ZoomX As Single, ByVal ZoomY As Single) As Boolean
        Try

            If IsNothing(srcBitmap) Then Exit Function

            If srcHDC.Equals(IntPtr.Zero) Then
                srcHDC = CreateCompatibleDC(IntPtr.Zero)
                HBitmapSrc = srcBitmap.GetHbitmap()
                SelectObject(srcHDC, HBitmapSrc)
            End If

            If desHDC.Equals(IntPtr.Zero) Then
                If IsNothing(Gr) Then
                    Gr = Host.CreateGraphics
                End If
                desHDC = Gr.GetHdc()
                SetStretchBltMode(desHDC, 3)
            End If
            Xout = False
            Yout = False

            If Host.Width > srcBitmap.Width * Zfactor Then
                Mrec.X = 0
                Mrec.Width = srcBitmap.Width
                Brec.X = (Host.Width - srcBitmap.Width * Zfactor) / 2
                Brec.Width = srcBitmap.Width * Zfactor

                BitBlt(desHDC, 0, 0, Brec.X, Host.Height, srcHDC, 0, 0, TernaryRasterOperations.BLACKNESS)
                BitBlt(desHDC, Brec.Right, 0, Brec.X, Host.Height, srcHDC, 0, 0, TernaryRasterOperations.BLACKNESS)
            Else
                Mrec.X = Mrec.X + ((Host.Width / oldZfactor - Host.Width / Zfactor) / ((Host.Width + 0.001) / ZoomX))
                Mrec.Width = Host.Width / Zfactor
                Brec.X = 0
                Brec.Width = Host.Width
            End If

            If Host.Height > srcBitmap.Height * Zfactor Then
                Mrec.Y = 0
                Mrec.Height = srcBitmap.Height
                Brec.Y = (Host.Height - srcBitmap.Height * Zfactor) / 2
                Brec.Height = srcBitmap.Height * Zfactor

                BitBlt(desHDC, 0, 0, Host.Width, Brec.Y, srcHDC, 0, 0, TernaryRasterOperations.BLACKNESS)
                BitBlt(desHDC, 0, Brec.Bottom, Host.Width, Brec.Y, srcHDC, 0, 0, TernaryRasterOperations.BLACKNESS)
            Else
                Mrec.Y = Mrec.Y + ((Host.Height / oldZfactor - Host.Height / Zfactor) / ((Host.Height + 0.001) / ZoomY))
                Mrec.Height = Host.Height / Zfactor
                Brec.Y = 0
                Brec.Height = Host.Height
            End If

            oldZfactor = Zfactor
            '-----------------------------------

            If Mrec.Right > srcBitmap.Width Then
                Xout = True
                Mrec.X = (srcBitmap.Width - Mrec.Width)
            End If

            If Mrec.X < 0 Then
                Xout = True
                Mrec.X = 0
            End If

            If Mrec.Bottom > srcBitmap.Height Then
                Yout = True
                Mrec.Y = (srcBitmap.Height - Mrec.Height)
            End If

            If Mrec.Y < 0 Then
                Yout = True
                Mrec.Y = 0
            End If

            StretchBlt(desHDC, Brec.X, Brec.Y, Brec.Width, Brec.Height, _
              srcHDC, Mrec.X, Mrec.Y, Mrec.Width, Mrec.Height, _
            TernaryRasterOperations.SRCCOPY)

            Gr.ReleaseHdc(desHDC)
            desHDC = Nothing
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Function

    Public Property Image() As System.Drawing.Bitmap
        Get
            Return srcBitmap
        End Get
        Set(ByVal Image As System.Drawing.Bitmap)
            'Dispose()
            srcBitmap = Image
            Zfactor = 1
            DrawPic(0, 0)
        End Set
    End Property

    Public ReadOnly Property SourceHDC() As IntPtr
        Get
            Return srcHDC
        End Get
    End Property

    Public ReadOnly Property srcBitmapHande() As IntPtr
        Get
            Return HBitmapSrc
        End Get
    End Property

    Public Property MinZoom() As Single
        Get
            Return MinZ
        End Get
        Set(ByVal MinZoom As Single)
            MinZ = MinZoom
        End Set
    End Property


    Public Property MaxZoom() As Single
        Get
            Return MaxZ
        End Get
        Set(ByVal MaxZoom As Single)
            MaxZ = MaxZoom
        End Set
    End Property

    Public Property CurZoom() As Single
        Get
            Return Zfactor
        End Get
        Set(ByVal CurZoom As Single)
            Zfactor = CurZoom
            DrawPic(Host.Width / 2, Host.Height / 2)
        End Set
    End Property



    Public Event MoveOver(ByVal Px As Single, ByVal Py As Single)
    Public Event ZoomChanged(ByVal CurZoom As Single)

End Class
