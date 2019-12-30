Module API

    Declare Function CreateCompatibleDC Lib "gdi32.dll" (ByVal hdc As IntPtr) As IntPtr
    Declare Function SelectObject Lib "gdi32.dll" (ByVal hdc As IntPtr, ByVal hgdiobj As IntPtr) As IntPtr
    Declare Function ReleaseDC Lib "gdi32.dll" (ByVal hWnd As IntPtr, ByVal hDC As IntPtr) As Integer
    Declare Function GetStretchBltMode Lib "gdi32.dll" (ByVal hdc As IntPtr) As Integer
    Declare Function SetStretchBltMode Lib "gdi32" (ByVal hdc As IntPtr, ByVal iStretchMode As Integer) As Integer
    Declare Function DeleteObject Lib "gdi32.dll" (ByVal hObject As IntPtr)
    Declare Function DeleteDC Lib "gdi32.dll" (ByVal hDc As IntPtr) As IntPtr


    Declare Function BitBlt Lib "GDI32.DLL" ( _
    ByVal hdcDest As IntPtr, _
    ByVal nXDest As Integer, _
    ByVal nYDest As Integer, _
    ByVal nWidth As Integer, _
    ByVal nHeight As Integer, _
    ByVal hdcSrc As IntPtr, _
    ByVal nXSrc As Integer, _
    ByVal nYSrc As Integer, _
    ByVal dwRop As TernaryRasterOperations) As Boolean


    Declare Function StretchBlt Lib "gdi32.dll" ( _
    ByVal hdcDest As IntPtr, _
    ByVal nXOriginDest As Integer, _
    ByVal nYOriginDest As Integer, _
    ByVal nWidthDest As Integer, _
    ByVal nHeightDest As Integer, _
    ByVal hdcSrc As IntPtr, _
    ByVal nXOriginSrc As Integer, _
    ByVal nYOriginSrc As Integer, _
    ByVal nWidthSrc As Integer, _
    ByVal nHeightSrc As Integer, _
    ByVal dwRop As TernaryRasterOperations) As Boolean


    Enum TernaryRasterOperations As Integer
        SRCCOPY = &HCC0020
        SRCPAINT = 15597702    'dest = source OR dest
        SRCAND = 8913094       'dest = source AND dest
        SRCINVERT = 6684742    'dest = source XOR dest
        SRCERASE = 4457256     'dest = source AND (NOT dest )
        NOTSRCCOPY = 3342344   'dest = (NOT source)
        NOTSRCERASE = 1114278  'dest = (NOT src) AND (NOT dest) 
        MERGECOPY = 12583114   'dest = (source AND pattern)
        MERGEPAINT = 12255782  'dest = (NOT source) OR dest
        PATCOPY = 15728673     'dest = pattern
        PATPAINT = 16452105    'dest = DPSnoo
        PATINVERT = 5898313    'dest = pattern XOR dest
        DSTINVERT = 5570569    'dest = (NOT dest)
        BLACKNESS = 66         'dest = BLACK
        WHITENESS = 16711778   'dest = WHITE
    End Enum
End Module
