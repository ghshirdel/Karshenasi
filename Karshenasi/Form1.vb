
Imports System
Imports System.Data.OleDb
Imports System.Diagnostics
Imports System.Management
Imports System.Net.NetworkInformation
Imports System.Windows.Forms
Imports System.Drawing
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Public Class Form1
    Dim cpuInfo = String.Empty
    Dim macAddresses = ""
    Private key, EnValue As String
    Public nflag As Boolean


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim CPUdv As New lockClass
        CPUdv.device = "cpu"
        CPUdv.dvSerial = CpuGetSerial()
        CPUdv.ASCiiCode = AsciiToDecimal(CPUdv.dvSerial)
        CPUdv.tenSerialGen = TenNumber(CPUdv.ASCiiCode, 10)

        Dim LANdv As New lockClass
        LANdv.device = "LAN"
        LANdv.dvSerial = LANGetSerial()
        LANdv.ASCiiCode = AsciiToDecimal(LANdv.dvSerial)
        LANdv.tenSerialGen = TenNumber(LANdv.ASCiiCode, 10)

        Dim MBdv As New lockClass
        MBdv.device = "Mainboard"
        MBdv.dvSerial = SystemSerialNumber()
        MBdv.ASCiiCode = AsciiToDecimal(MBdv.dvSerial)
        MBdv.tenSerialGen = TenNumber(MBdv.ASCiiCode, 10)

        Dim GenCode As Int64
        GenCode = Val(CPUdv.tenSerialGen) +
                  IIf(LANdv.tenSerialGen.Length > 0, Val(LANdv.tenSerialGen), 0) +
                  Val(MBdv.tenSerialGen)

        TextBox1.Text = StrReverse(GenCode)
    End Sub
    Function CpuGetSerial()
        '--------------------------------CPU Get Serial------------------------------
        Dim mc = New ManagementClass("win32_processor")
        Dim moc = mc.GetInstances

        For Each mo As ManagementObject In moc
            cpuInfo = mo.Properties("processorID").Value.ToString
            Exit For
        Next
        Return cpuInfo
    End Function
    Function loadfrm()
        Dim CPUdv As New lockClass
        CPUdv.device = "cpu"
        CPUdv.dvSerial = CpuGetSerial()
        CPUdv.ASCiiCode = AsciiToDecimal(CPUdv.dvSerial)
        CPUdv.tenSerialGen = TenNumber(CPUdv.ASCiiCode, 10)

        Dim LANdv As New lockClass
        LANdv.device = "LAN"
        LANdv.dvSerial = LANGetSerial()
        LANdv.ASCiiCode = AsciiToDecimal(LANdv.dvSerial)
        LANdv.tenSerialGen = TenNumber(LANdv.ASCiiCode, 10)

        Dim MBdv As New lockClass
        MBdv.device = "Mainboard"
        MBdv.dvSerial = SystemSerialNumber()
        MBdv.ASCiiCode = AsciiToDecimal(MBdv.dvSerial)
        MBdv.tenSerialGen = TenNumber(MBdv.ASCiiCode, 10)

        Dim GenCode As Int64
        GenCode = Val(CPUdv.tenSerialGen) +
                  IIf(LANdv.tenSerialGen.Length > 0, Val(LANdv.tenSerialGen), 0) +
                  Val(MBdv.tenSerialGen)
        Dim codelock As String = StrReverse(GenCode)

        Return TextBox2.Text

    End Function
    Function ChechLock()
        Dim CPUdv As New lockClass
        CPUdv.device = "cpu"
        CPUdv.dvSerial = CpuGetSerial()
        CPUdv.ASCiiCode = AsciiToDecimal(CPUdv.dvSerial)
        CPUdv.tenSerialGen = TenNumber(CPUdv.ASCiiCode, 10)

        Dim LANdv As New lockClass
        LANdv.device = "LAN"
        LANdv.dvSerial = LANGetSerial()
        LANdv.ASCiiCode = AsciiToDecimal(LANdv.dvSerial)
        LANdv.tenSerialGen = TenNumber(LANdv.ASCiiCode, 10)

        Dim MBdv As New lockClass
        MBdv.device = "Mainboard"
        MBdv.dvSerial = SystemSerialNumber()
        MBdv.ASCiiCode = AsciiToDecimal(MBdv.dvSerial)
        MBdv.tenSerialGen = TenNumber(MBdv.ASCiiCode, 10)

        Dim GenCode As Int64
        GenCode = Val(CPUdv.tenSerialGen) +
                  IIf(LANdv.tenSerialGen.Length > 0, Val(LANdv.tenSerialGen), 0) +
                  Val(MBdv.tenSerialGen)
        Dim codelock As String = StrReverse(GenCode)

        Return AES_Encrypt(codelock, "0x@gnqEZ")

    End Function
    Private Function SystemSerialNumber() As String
        ' Get the Windows Management Instrumentation object.
        Dim wmi As Object = GetObject("WinMgmts:")

        ' Get the "base boards" (mother boards).
        Dim serial_numbers As String = ""
        Dim mother_boards As Object = wmi.InstancesOf("Win32_BaseBoard")
        For Each board As Object In mother_boards
            serial_numbers &= ", " & board.SerialNumber
        Next board
        If serial_numbers.Length > 0 Then serial_numbers = serial_numbers.Substring(2)

        Return serial_numbers
    End Function
    Function LANGetSerial()
        '---------------------------------LAN Get Serial-----------------------------
        Dim nic As Object = Nothing
        For Each nic In NetworkInterface.GetAllNetworkInterfaces

            If nic.OperationalStatus = OperationalStatus.Up Then
                macAddresses += nic.GetPhysicalAddress.ToString
                Exit For
            End If
        Next

        Return macAddresses
    End Function
    Function AsciiToDecimal(s As String) As String
        Dim ch As Char
        Dim cpuText As String = ""
        Dim i As Integer = 0

        For i = 0 To s.Length - 1 Step 1
            cpuText += Asc(s(i)).ToString
        Next
        Return cpuText
    End Function
    Function TenNumber(s As String, n As Int16) As String
        Dim j As Integer
        Dim Serial1 As String = ""
        For j = (s.Length - n) To s.Length - 1
            Serial1 += s(j)
        Next
        Return Serial1
    End Function

    Public Function AES_Encrypt(ByVal input As String, ByVal pass As String) As String
        Try
            Dim AES As New System.Security.Cryptography.RijndaelManaged
            Dim Hash_AES As New System.Security.Cryptography.MD5CryptoServiceProvider
            Dim encrypted As String = ""

            Dim hash(31) As Byte
            Dim temp As Byte() = Hash_AES.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(pass))
            Array.Copy(temp, 0, hash, 0, 16)
            Array.Copy(temp, 0, hash, 15, 16)
            AES.Key = hash
            AES.Mode = Security.Cryptography.CipherMode.ECB
            Dim DESEncrypter As System.Security.Cryptography.ICryptoTransform = AES.CreateEncryptor
            Dim Buffer As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes(input)
            encrypted = Convert.ToBase64String(DESEncrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))
            Return encrypted
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return 0
    End Function
    Public Function AES_Decrypt(ByVal input As String, ByVal pass As String) As String
        Dim AES As New System.Security.Cryptography.RijndaelManaged
        Dim Hash_AES As New System.Security.Cryptography.MD5CryptoServiceProvider
        Dim decrypted As String = ""
        Try
            Dim hash(31) As Byte
            Dim temp As Byte() = Hash_AES.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(pass))
            Array.Copy(temp, 0, hash, 0, 16)
            Array.Copy(temp, 0, hash, 15, 16)
            AES.Key = hash
            AES.Mode = Security.Cryptography.CipherMode.ECB
            Dim DESDecrypter As System.Security.Cryptography.ICryptoTransform = AES.CreateDecryptor
            Dim Buffer As Byte() = Convert.FromBase64String(input)
            decrypted = System.Text.ASCIIEncoding.ASCII.GetString(DESDecrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))
            Return decrypted
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return 0
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Cn As New OleDbConnection
        Cn.ConnectionString = StrCon
        If TextBox2.Text.Trim.Length > 0 Then
            Dim Str As String = "Insert into LockSystem (LockSerial) values(?)"
            Dim Cmd As New OleDbCommand(Str, Cn)
            Cmd.Parameters.Add("@LockSerial", OleDbType.VarChar).Value = TextBox2.Text.Trim
            Cn.Open()
            Cmd.ExecuteNonQuery()
            Cn.Close()
        End If

        Dim da As New OleDbDataAdapter("Select * From LockSystem", Cn)
        Dim ds As New DataSet
        da.Fill(ds)
        Dim lockdv As DataView
        lockdv = New DataView(ds.Tables(0))
        BsLock.DataSource = lockdv
        Dim ldr As DataRow
        ldr = lockdv.Item(BsLock.Position).Row
        If ldr.ItemArray(1) IsNot DBNull.Value Then
            Dim lockfield As String = loadfrm()
            If ldr.ItemArray(1) = lockfield Then
                nflag = True
                Me.Close()
            Else
                MsgBox("قفل نرم افزار صحیح نمیباشد مجددا درخواست قفل را درخواست نمائید 09125087581")

            End If
        End If
    End Sub

    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If nflag = False Then
            Application.Exit()

        End If
    End Sub

    Public Class lockClass
        Public Property device As String
        Public Property dvSerial As String
        Public Property ASCiiCode As String
        Public Property tenSerialGen As String

    End Class
End Class