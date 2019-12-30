using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using WIA;
using System;
using System.IO;
using System.Data.OleDb;
using Syncfusion.DocIO.DLS;
using Point = System.Drawing.Point;
using Microsoft.VisualBasic.CompilerServices;

namespace Karshenasi
{
    public partial class KarshenasiFrm
    {
        private short Karbari_Index_Combobox = Conversions.ToShort(-1);
        private long i;
        private OleDbConnection Cn = new OleDbConnection();
        private DataView Kdv, Ostan_dv;
        private DataView Kardv;
        private DataView Sdv;
        private DataView Pdv;
        private DataView udv;
        private DataView Price_dv, Type_Kar_dv;
        private bool adNew = false;
        private bool SetFlag = false;
        private bool SetKarFlag = false;
        private bool SetUnitFlag = false;
        private bool Set_Price_Flag = false;
        private bool PadNew = false;
        private object[] Obj = new object[7];
        private int K_Id;
        private bool OstanFlag = false;
        private bool Price_AddNew = false;
        private DataView h_dv;
        private Device SelectedDevice;
        private int Tel_Id;
        private bool Start_flag = false;
        private bool First_init_flag = false;

        class _failedMemberConversionMarker1
        {
        }
#error Cannot convert PropertyBlockSyntax - see comment for details
        /* Cannot convert PropertyBlockSyntax, System.NullReferenceException: Object reference not set to an instance of an object.
           at ICSharpCode.CodeConverter.CSharp.DeclarationNodeVisitor.<VisitPropertyStatement>d__51.MoveNext()
        --- End of stack trace from previous location where exception was thrown ---
           at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
           at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
           at ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.<DefaultVisit>d__5.MoveNext()
        --- End of stack trace from previous location where exception was thrown ---
           at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
           at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
           at ICSharpCode.CodeConverter.CSharp.DeclarationNodeVisitor.<VisitPropertyBlock>d__54.MoveNext()
        --- End of stack trace from previous location where exception was thrown ---
           at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
           at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
           at ICSharpCode.CodeConverter.CSharp.CommentConvertingNodesVisitor.<DefaultVisit>d__5.MoveNext()
        --- End of stack trace from previous location where exception was thrown ---
           at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
           at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
           at ICSharpCode.CodeConverter.CSharp.DeclarationNodeVisitor.<ConvertMember>d__35.MoveNext()

        Input: 


            Public Property Get_Data()
                Get
                    Return 0
                End Get
                Set(ByVal value)
                    K_Id = value
                End Set
            End Property

         */
        private void Select_Karbari()
        {
            try
            {
                var Cn = new OleDbConnection();
                Cn.ConnectionString = Module1.StrCon;
                var da = new OleDbDataAdapter("Select * from BaseKarbariTable", Cn);
                var ds = new DataSet();
                da.Fill(ds);
                Kardv = new DataView(ds.Tables[0]);
                KarbariBindingSource.DataSource = Kardv;
                ComboBox3.DataSource = KarbariBindingSource;
                ComboBox3.DisplayMember = "Karbari";
                ComboBox3.ValueMember = "KarId";
                ComboBox3.SelectedIndex = -1;
                SetKarFlag = true;
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }
        private void Tel_unit_sazman(int KsId)
        {
            try
            {
                var Cn = new OleDbConnection();
                Cn.ConnectionString = Module1.StrCon;
                var da = new OleDbDataAdapter("Select * from Tel_unit where KsId=" + Conversions.ToString(KsId), Cn);
                var ds = new DataSet();
                da.Fill(ds);
                var dv = new DataView(ds.Tables[0]);
                if (dv.Table.Rows.Count > 0)
                {
                    int R;
                    var loopTo = dv.Table.Rows.Count - 1;
                    for (R = 0; R <= loopTo; R++)
                    {
                        var Tel_dr = dv[R].Row;
                        Tel_List.Items.Add(Tel_dr.ItemArray[2]);
                    }
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString(), MsgBoxStyle.Critical);
            }
        }
        private void Unit_Sazman(int Sid)
        {
            try
            {
                var Cn = new OleDbConnection();
                Cn.ConnectionString = Module1.StrCon;
                var da = new OleDbDataAdapter("Select * from KUnitTable where Sid=" + Conversions.ToString(Sid), Cn);
                var ds = new DataSet();
                da.Fill(ds);
                udv = new DataView(ds.Tables[0]);
                UBindingSource.DataSource = udv;

                ComboBox2.DataSource = UBindingSource;
                ComboBox2.DisplayMember = "Kunit";
                ComboBox2.ValueMember = "KSId";
                SetUnitFlag = true;
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString(), MsgBoxStyle.Critical);
            }
        }
        private void Type_Sazman()
        {
            try
            {
                var Cn = new OleDbConnection();
                Cn.ConnectionString = Module1.StrCon;
                var da = new OleDbDataAdapter("Select * from SazmanTable", Cn);
                var ds = new DataSet();
                da.Fill(ds);
                Sdv = new DataView(ds.Tables[0]);
                WBindingSource.DataSource = Sdv;
                ComboBox1.DataSource = WBindingSource;
                ComboBox1.DisplayMember = "Sazman";
                ComboBox1.ValueMember = "SId";
                SetFlag = true;
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString(), MsgBoxStyle.Critical);
            }
        }
        private void Select_Data()
        {
            try
            {
                if (Module1.SendFlagFromList == true)
                {
                    this.AddBtn.Enabled = false;
                    this.CancelBtn.Enabled = false;
                    this.DeleteBtn.Enabled = false;
                    this.AddBtn.Enabled = false;
                    this.SaveBtn.Enabled = false;
                    this.DeleteBtn.Enabled = false;
                    this.AttachmentBtn.Enabled = false;
                    SendFromList_Initialize();
                    DataGrid_Init();
                }
                else
                {
                    this.AddBtn.Enabled = true;
                    this.CancelBtn.Enabled = false;
                    this.DeleteBtn.Enabled = true;
                    this.AddBtn.Enabled = true;
                    this.SaveBtn.Enabled = true;
                    this.DeleteBtn.Enabled = true;
                    this.AttachmentBtn.Enabled = true;
                    First_Initialize();
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }
        private void SendFromList_Initialize()
        {
            try
            {
                Cn.ConnectionString = Module1.StrCon;
                var da = new OleDbDataAdapter("Select * from MainKTable where Kid=" + Conversions.ToString(K_Id), Cn);
                var Kds = new DataSet();
                da.Fill(Kds);
                Kdv = new DataView(Kds.Tables[0]);
                this.MainBindingSource.DataSource = Kdv;
                Textbox_Initialize();
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }
        private void First_Initialize()
        {
            try
            {
                First_init_flag = false;
                Cn.ConnectionString = Module1.StrCon;
                var da = new OleDbDataAdapter("Select * from MainKTable", Cn);
                var Kds = new DataSet();
                da.Fill(Kds);
                Kdv = new DataView(Kds.Tables[0]);
                this.MainBindingSource.DataSource = Kdv;
                First_init_flag = true;
                Textbox_Initialize();
                MainBindingSource.MoveLast();
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }
        private void First_Type_Karshenasi_Select()
        {
            if (ComboBox3.SelectedIndex != -1)
            {
                var Cn = new OleDbConnection();
                Cn.ConnectionString = Module1.StrCon;
                var da = new OleDbDataAdapter("Select * From Type_Karshenasi Where KarId =" + ComboBox3.SelectedValue, Cn);
                var ds = new DataSet();
                da.Fill(ds);
                Type_Kar_dv = new DataView(ds.Tables[0]);
                Tpk_Bs.DataSource = Type_Kar_dv;
            }
        }
        private void Textbox_Initialize()
        {
            try
            {
                if (this.MainBindingSource.Position >= 0)
                {
                    var dr = Kdv[this.MainBindingSource.Position].Row;
                    ComboBox4.Text = dr.ItemArray[13].ToString();
                    ComboBox1.Text = dr.ItemArray[8].ToString();
                    TxtKno.Text = dr.ItemArray[5].ToString();
                    FaDatePicker1.Text = dr.ItemArray[4].ToString();
                    Txtsubject.Text = dr.ItemArray[1].ToString();
                    TxtPAsli.Text = dr.ItemArray[2].ToString();
                    TxtPFarei.Text = dr.ItemArray[3].ToString();
                    ComboBox2.Text = dr.ItemArray[10].ToString();
                    ComboBox3.Text = dr.ItemArray[12].ToString();
                    FaDatePicker2.Text = dr.ItemArray[16].ToString();
                    // Uid = dr.ItemArray(9)
                    Module1.Sid = Conversions.ToInteger(dr.ItemArray[7]);
                    if (ComboBox3.SelectedIndex > -1)
                        First_Type_Karshenasi_Select();
                    ComboBox4.Text = dr.ItemArray[13].ToString();
                }
                Menu_Item_Init();
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }
        private void Insert_Data()
        {
            try
            {
                string str;
                // If TxtTotalPrice.Text = "" Then
                // TxtTotalPrice.Text = 0
                // End If
                // TxtTotalPrice.Text = Format(CDbl(TxtTotalPrice.Text), Nothing)
                this.Validate();
                this.MainBindingSource.EndEdit();
                str = "insert into MainKTable(subject,PAsli,PFarei,Kdate,Kno,TotalPrice,Sid,Sazman,KSId,KUnit,KarId,Karbari,Type_Karshenasi)" + "values(?,?,?,?,?,?,?,?,?,?,?,?,?)";
                var Cmd = new OleDbCommand(str, Cn);
                Cmd.Parameters.Add("@Subject", OleDbType.VarChar).Value = Txtsubject.Text;
                Cmd.Parameters.Add("@Pasli", OleDbType.VarChar).Value = TxtPAsli.Text;
                Cmd.Parameters.Add("@PFarei", OleDbType.VarChar).Value = TxtPFarei.Text;
                Cmd.Parameters.Add("@Kdate", OleDbType.VarWChar).Value = FaDatePicker1.Text;
                Cmd.Parameters.Add("@Kno", OleDbType.Integer).Value = TxtKno.Text;
                Cmd.Parameters.Add("@TotalPrice", OleDbType.VarChar).Value = 0;
                Cmd.Parameters.Add("@SId", OleDbType.Integer).Value = ComboBox1.SelectedValue;
                Cmd.Parameters.Add("@Sazman", OleDbType.VarChar).Value = ComboBox1.Text;
                if (string.IsNullOrEmpty(ComboBox2.Text))
                {
                    Cmd.Parameters.Add("@KSId", OleDbType.Empty).Value = "";
                    Cmd.Parameters.Add("@KUnit", OleDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    Cmd.Parameters.Add("@KSId", OleDbType.Integer).Value = ComboBox2.SelectedValue;
                    Cmd.Parameters.Add("@KUnit", OleDbType.VarChar).Value = ComboBox2.Text;
                }
                if (string.IsNullOrEmpty(ComboBox3.Text))
                {
                    Cmd.Parameters.Add("@KarId", OleDbType.Empty).Value = DBNull.Value;
                    Cmd.Parameters.Add("@Karbari", OleDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    Cmd.Parameters.Add("@KarId", OleDbType.Integer).Value = ComboBox3.SelectedValue;
                    Cmd.Parameters.Add("@Karbari", OleDbType.VarChar).Value = ComboBox3.Text;
                }
                Cmd.Parameters.Add("@Type_Karshenasi", OleDbType.VarChar).Value = ComboBox4.Text;
                // Cmd.Parameters.Add("@EndDate", OleDbType.VarWChar).Value = FaDatePicker2.Text

                Cn.Open();
                Cmd.ExecuteNonQuery();
                Cn.Close();
            }
            catch (OleDbException ex)
            {
                Interaction.MsgBox(ex.ToString(), MsgBoxStyle.Critical, "OLEdb Error");
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString(), MsgBoxStyle.Critical, "General Error");
            }
        }
        private void Update_Data()
        {
            try
            {
                var Cn = new OleDbConnection();
                var Cmd = new OleDbCommand();
                Cn.ConnectionString = Module1.StrCon;
                Cmd.Connection = Cn;
                string strUpdate;
                DataRow dr;
                dr = Kdv[this.MainBindingSource.Position].Row;
                this.Validate();
                this.MainBindingSource.EndEdit();
                strUpdate = "update MainKTable set " + "subject=?,PAsli=?,PFarei=?,Kdate=?,Kno=?,TotalPrice=?," + "SId=?,Sazman=?,Ksid=?,KUnit=?,KarId=?,Karbari=?,Type_Karshenasi=?,EndDate=?" + " where Kid=?";
                Cmd.CommandText = strUpdate;
                Cmd.Parameters.Add("@Subject", OleDbType.VarChar).Value = Txtsubject.Text;
                Cmd.Parameters.Add("@Pasli", OleDbType.VarChar).Value = TxtPAsli.Text;
                Cmd.Parameters.Add("@PFarei", OleDbType.VarChar).Value = TxtPFarei.Text;
                Cmd.Parameters.Add("@Kdate", OleDbType.VarChar).Value = FaDatePicker1.Text;
                Cmd.Parameters.Add("@Kno", OleDbType.Integer).Value = TxtKno.Text;
                Cmd.Parameters.Add("@TotalPrice", OleDbType.VarChar).Value = 0;
                Cmd.Parameters.Add("@SId", OleDbType.Integer).Value = ComboBox1.SelectedValue;
                Cmd.Parameters.Add("@Sazman", OleDbType.VarChar).Value = ComboBox1.Text;
                if (string.IsNullOrEmpty(ComboBox2.Text))
                {
                    Cmd.Parameters.Add("@KSId", OleDbType.Integer).Value = 0;
                    Cmd.Parameters.Add("@KUnit", OleDbType.VarWChar).Value = "";
                }
                else
                {
                    Cmd.Parameters.Add("@KSId", OleDbType.Integer).Value = ComboBox2.SelectedValue;
                    Cmd.Parameters.Add("@KUnit", OleDbType.VarWChar).Value = ComboBox2.Text;
                }
                if (string.IsNullOrEmpty(ComboBox3.Text))
                {
                    Cmd.Parameters.Add("@KarId", OleDbType.Integer).Value = 0;
                    Cmd.Parameters.Add("@Karbari", OleDbType.VarWChar).Value = "";
                }
                else
                {
                    if (ComboBox3.SelectedIndex != Karbari_Index_Combobox)
                        Select_Type_Karshenasi();
                    Cmd.Parameters.Add("@KarId", OleDbType.Integer).Value = ComboBox3.SelectedValue;
                    Cmd.Parameters.Add("@Karbari", OleDbType.VarWChar).Value = ComboBox3.Text;
                }
                Cmd.Parameters.Add("@Type_Karshenasi", OleDbType.VarChar).Value = ComboBox4.Text;
                Cmd.Parameters.Add("@Enddate", OleDbType.VarChar).Value = FaDatePicker2.Text;
                Cmd.Parameters.Add("@KId", OleDbType.Integer).Value = dr.ItemArray[0];

                try
                {
                    Cn.Open();
                    Cmd.ExecuteNonQuery();
                    Cn.Close();
                }
                catch (OleDbException ex)
                {
                    Interaction.MsgBox(ex.ToString(), MsgBoxStyle.Critical, "OLEdb Error");
                }
                catch (Exception ex)
                {
                    Interaction.MsgBox(ex.ToString(), MsgBoxStyle.Critical, "General Error");
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }
        private void KarshenasiFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Module1.SendFlagFromList = false;
            if (CancelBtn.Enabled == true)
            {
                this.MainBindingSource.RemoveCurrent();
                this.AttachmentBtn.Enabled = true;
                this.CancelBtn.Enabled = false;
                this.DeleteBtn.Enabled = true;
                this.AddBtn.Enabled = true;
                SaveBtn.Enabled = true;
                AddBtn.Enabled = true;
                Button1.Enabled = true;
            }
        }
        private void KarshenasiFrm_KeyUp(object sender, KeyEventArgs e)
        {
            if ((int)e.KeyCode == (int)Keys.Escape)
                this.Close();
        }
        private void TxtKno_KeyDown(object sender, KeyEventArgs e)
        {
            if ((int)e.KeyCode == (int)Keys.Enter)
                this.ProcessTabKey(true);
        }
        private void FaDatePicker1_KeyUp(object sender, KeyEventArgs e)
        {
            if ((int)e.KeyCode == (int)Keys.Enter)
                this.ProcessTabKey(true);
        }
        private void Txtsubject_Enter(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("Fa"));
        }
        private void Txtsubject_KeyUp(object sender, KeyEventArgs e)
        {
            if ((int)e.KeyCode == (int)Keys.Enter)
                this.ProcessTabKey(true);
        }
        private void TxtPAsli_KeyUp(object sender, KeyEventArgs e)
        {
            if ((int)e.KeyCode == (int)Keys.Enter)
                this.ProcessTabKey(true);
        }
        private void TxtPFarei_KeyUp(object sender, KeyEventArgs e)
        {
            if ((int)e.KeyCode == (int)Keys.Enter)
                this.ProcessTabKey(true);
        }
        private void DataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true & (int)e.KeyCode == (int)Keys.Delete)
            {
                if ((int)Interaction.MsgBox("آیا مطمئن به حذف ردیف جاری میباشید ؟", MsgBoxStyle.OkCancel) == (int)MsgBoxResult.Ok)
                {
                    try
                    {
                        DataRow dr;
                        dr = h_dv[this.Heyat_BindingSource.Position].Row;
                        string Str;
                        Str = "Delete from heyat_Kar where Kar_h_Id=?";
                        var Cn = new OleDbConnection();
                        OleDbCommand Cmd;
                        Cn.ConnectionString = Module1.StrCon;
                        Cmd = new OleDbCommand(Str, Cn);
                        Cmd.Parameters.Add("@PKar_h_Id", OleDbType.Integer).Value = dr.ItemArray[0];
                        Cn.Open();
                        Cmd.ExecuteNonQuery();
                        Cn.Close();
                        DataGrid_Init();
                    }
                    catch (Exception ex)
                    {
                        Interaction.MsgBox(ex.ToString());
                    }
                }
            }
        }
        private void WBindingSource_PositionChanged(object sender, EventArgs e)
        {
            try
            {
                if (SetFlag == true)
                {
                    Unit_Sazman(Conversions.ToInteger(ComboBox1.SelectedValue));
                    ComboBox2.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }
        private void KarshensiFileItem_Click(object sender, EventArgs e)
        {
            try
            {
                int pos = Strings.InStr(Module1.PathFileDatabase, "Karshenasi.mdb");
                string WPath = Strings.Mid(Module1.PathFileDatabase, 1, pos - 1);
                var document = new WordDocument();
                DataRow dr;
                dr = udv[UBindingSource.Position].Row;
                WPath += @"Word\";
                if (File.Exists(WPath + TxtKno.Text + ".doc"))
                {
                    document.Open(WPath + dr.ItemArray[3].ToString().Trim() + ".doc");
                    Process.Start(WPath + TxtKno.Text + ".doc");
                }
                else if (File.Exists(WPath + dr.ItemArray[3] + ".doc"))
                {
                    document.Open(WPath + dr.ItemArray[3].ToString().Trim() + ".doc");
                    document.Save(WPath + TxtKno.Text + ".doc");
                    Process.Start(WPath + TxtKno.Text + ".doc");
                    KarshensiFileItem.Text = "ویرایش فرم کارشناسی ایجاد شده";
                    DeleteFileKarshenasiItem.Enabled = true;
                }
                else
                    Interaction.MsgBox("ابتدا باید نمونه فرم را از ایتم سازمان های مرتبط منوی تعاریف پایه طراحی نمائید");
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }
        private void DeleteFileKarshenasiItem_Click(object sender, EventArgs e)
        {
            int pos = Strings.InStr(Module1.PathFileDatabase, "Karshenasi.mdb");
            string WPath = Strings.Mid(Module1.PathFileDatabase, 1, pos - 1);
            var dr = udv[UBindingSource.Position].Row;
            WPath += @"Word\";
            if (File.Exists(WPath + dr.ItemArray[3].ToString() + ".doc"))
            {
                if ((int)Interaction.MsgBox("آیا مطمئن به حذف فرم کارشناسی جاری می باشید ؟", MsgBoxStyle.YesNo) == (int)MsgBoxResult.Yes)
                {
                    FileSystem.Kill(WPath + TxtKno.Text + ".doc");
                    DeleteFileKarshenasiItem.Enabled = false;
                    KarshensiFileItem.Text = "ایجاد فرم کارشناسی";
                }
            }
        }
        private void MaliFileItem_Click(object sender, EventArgs e)
        {
            try
            {
                int pos = Strings.InStr(Module1.PathFileDatabase, "Karshenasi.mdb");
                string WPath = Strings.Mid(Module1.PathFileDatabase, 1, pos - 1);
                var document = new WordDocument();
                DataRow dr;
                dr = udv[UBindingSource.Position].Row;
                WPath += @"Word\";
                if (File.Exists(WPath + dr.ItemArray[4].ToString() + ".doc"))
                {
                    document.Open(WPath + dr.ItemArray[4].ToString().Trim() + ".doc");
                    Process.Start(WPath + dr.ItemArray[4].ToString() + ".doc");
                }
                else if (File.Exists(WPath + dr.ItemArray[4] + ".doc"))
                {
                    document.Open(WPath + dr.ItemArray[4].ToString().Trim() + ".doc");
                    document.Save(WPath + TxtKno.Text + "Mali" + ".doc");
                    Process.Start(WPath + TxtKno.Text + "Mali" + ".doc");
                    MaliFileItem.Text = "ویرایش فرم مالی ایجاد شده";
                    DeleteMaliFileItem.Enabled = true;
                }
                else
                    Interaction.MsgBox("ابتدا باید نمونه فرم را طراحی نمائید");
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }
        private void KarbariITem_Click_1(object sender, EventArgs e)
        {
            Karshenasi.My.MyProject.MyForms.DefKarbariFrm.ShowDialog();
            Select_Karbari();
        }
        private void SazmanItem_Click_1(object sender, EventArgs e)
        {
            Karshenasi.My.MyProject.MyForms.SazmanFrm.ShowDialog();
            Type_Sazman();
        }
        private void DeleteMaliFileItem_Click(object sender, EventArgs e)
        {
            int pos = Strings.InStr(Module1.PathFileDatabase, "Karshenasi.mdb");
            string WPath = Strings.Mid(Module1.PathFileDatabase, 1, pos - 1);
            WPath = WPath + (@"word\" + TxtKno.Text + "Mali" + ".doc");
            if (File.Exists(WPath))
            {
                if ((int)Interaction.MsgBox("آیا مطمئن به حذف فرم مالی کارشناسی جاری می باشید ؟", MsgBoxStyle.YesNo) == (int)MsgBoxResult.Yes)
                {
                    FileSystem.Kill(WPath);
                    DeleteMaliFileItem.Enabled = false;
                    MaliFileItem.Text = "ایجاد فرم مالی";
                }
            }
        }
        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtSearch.Text))
            {
                i = (long)this.MainBindingSource.Find("Kno", TxtSearch.Text);
                this.MainBindingSource.Position = Conversions.ToInteger(i);
            }
        }
        private void OstanAndShahrItem_Click(object sender, EventArgs e)
        {
            Karshenasi.My.MyProject.MyForms.OstanAndShahBaseFrm.ShowDialog();
        }
        private void KarshenasiFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            adNew = false;
        }
        private void List_init_Btn()
        {
            BindingNavigator1.MoveFirstItem.Enabled = false;
            BindingNavigator1.MoveLastItem.Enabled = false;
            BindingNavigator1.MoveNextItem.Enabled = false;
            BindingNavigator1.MovePreviousItem.Enabled = false;
            AddBtn.Enabled = false;
            DeleteBtn.Enabled = false;
            CancelBtn.Enabled = false;
            BindingNavigatorMoveFirstItem.Enabled = false;
            BindingNavigatorMoveLastItem.Enabled = false;
            BindingNavigatorMoveNextItem.Enabled = false;
            BindingNavigatorMovePreviousItem.Enabled = false;
            SaveBtn.Enabled = true;
        }
        private void First_init_Btn()
        {
            ComboBox1.SelectedIndex = -1;
            ComboBox2.SelectedIndex = -1;
            ComboBox3.SelectedIndex = -1;
            FaDatePicker1.Text = "";
            FaDatePicker2.Text = "";
            adNew = true;
            this.DeleteBtn.Enabled = false;
            this.CancelBtn.Enabled = true;
            this.AddBtn.Enabled = false;
            this.AttachmentBtn.Enabled = false;
            Button1.Enabled = false;
            SaveBtn.Enabled = true;
            AddBtn.Enabled = false;
        }
        private void KarshenasiFrm_Load(object sender, EventArgs e)
        {
            Karshenasi.My.MyProject.MyForms.Wait_frm.Show();
            Karshenasi.My.MyProject.MyForms.Wait_frm.Refresh();
            TextBox1.Visible = false;
            Select_Ostan();
            OstanFlag = true;
            Type_Sazman();
            Unit_Sazman(Conversions.ToInteger(ComboBox1.SelectedValue));
            if (SetUnitFlag == true)
            {
                Tel_List.Items.Clear();
                Tel_unit_sazman(Conversions.ToInteger(ComboBox2.SelectedValue));
            }
            Select_Karbari();
            if (K_Id > 0)
            {
                List_init_Btn();
                SendFromList_Initialize();
                Select_Price();
            }
            else
            {
                Karshenasi_Price_DataGridView.Enabled = false;
                Heyat_dg.Enabled = false;
                First_init_Btn();
                Menu_Item_Init();
                TxtKno.Focus();
                Cn.ConnectionString = Module1.StrCon;
                var da = new OleDbDataAdapter("Select max(Kno) from MainKTable ", Cn);
                var ds = new DataSet();
                da.Fill(ds);
                var dv = new DataView(ds.Tables[0]);
                var dr = dv[0].Row;
                TxtKno.Text = dr.ItemArray[0] + 1;
                var pt = new PersianToolS.PersinToolsClass();
                FaDatePicker1.Text = pt.DateToPersian(DateTime.Now).ShortDate;
                First_Type_Karshenasi_Select();
            }
            Karbari_Index_Combobox = Conversions.ToShort(ComboBox3.SelectedIndex);
            Karshenasi.My.MyProject.MyForms.Wait_frm.Close();
            Start_flag = true;
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            Module1.Kno_Insert = TxtKno.Text;
            Karshenasi.My.MyProject.MyForms.Wait_frm.Show();
            Karshenasi.My.MyProject.MyForms.Wait_frm.Refresh();
            if (adNew == true)
            {
                Insert_Data();
                adNew = false;
                First_Initialize();
                DataGrid_Init();
                MainBindingSource.MoveLast();
                var dr = Kdv[MainBindingSource.Position].Row;
                Module1.Kid = Conversions.ToInteger(dr.ItemArray[0]);
                Menu_Item_Init();
                BindingNavigator1.MoveFirstItem.Enabled = false;
                BindingNavigator1.MoveLastItem.Enabled = false;
                BindingNavigator1.MoveNextItem.Enabled = false;
                BindingNavigator1.MovePreviousItem.Enabled = false;
                Button1.Enabled = true;
                AddBtn.Enabled = true;
                DeleteBtn.Enabled = false;
                CancelBtn.Enabled = true;
                Karshenasi_Price_DataGridView.Enabled = true;
                Heyat_dg.Enabled = true;
            }
            else
            {
                Update_Data();
                Select_Data();
                int i = this.MainBindingSource.Find("Kno", Module1.Kno_Insert);
                this.MainBindingSource.Position = i;
                DataGrid_Init();
            }
            Karshenasi.My.MyProject.MyForms.Wait_frm.Close();
            Karshenasi.My.MyProject.MyForms.SaveFrm.Show();
            Karshenasi.My.MyProject.MyForms.SaveFrm.Refresh();
            Karshenasi.My.MyProject.MyForms.SaveFrm.Close();
        }
        private void AddBtn_Click(object sender, EventArgs e)
        {
            adNew = true;
            this.DeleteBtn.Enabled = false;
            this.CancelBtn.Enabled = true;
            this.AddBtn.Enabled = false;
            this.AttachmentBtn.Enabled = false;
            Button1.Enabled = false;
            SaveBtn.Enabled = true;
            AddBtn.Enabled = false;
            this.MainBindingSource.AddNew();
            TxtKno.Focus();
            Cn.ConnectionString = Module1.StrCon;
            var da = new OleDbDataAdapter("Select max(Kno) from MainKTable ", Cn);
            var ds = new DataSet();
            da.Fill(ds);
            var dv = new DataView(ds.Tables[0]);
            var dr = dv[0].Row;
            TxtKno.Text = dr.ItemArray[0] + 1;
            var pt = new PersianToolS.PersinToolsClass();
            FaDatePicker1.Text = pt.DateToPersian(DateTime.Now).ShortDate;
            Txtsubject.Text = "ارزیابی ملک واقع در استان ";
        }
        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            string str = "";
            if ((int)Interaction.MsgBox("آيا پرونده كارشناسي ثبت شده را حذف مي نمائيد؟", MsgBoxStyle.OkCancel) == (int)MsgBoxResult.Ok)
            {
                DataRow dr;
                dr = Kdv[this.MainBindingSource.Position].Row;
                Module1.Kid = Conversions.ToInteger(dr.ItemArray[0]);
                str = "delete from MainKTable where Kid=" + Conversions.ToString(Module1.Kid);
                Cn.ConnectionString = Module1.StrCon;
                Cn.Open();
                var Cmd = new OleDbCommand(str, Cn);
                Cmd.ExecuteNonQuery();
                Cn.Close();
                if (Module1.SendFlagFromList == true)
                {
                    this.AddBtn.Enabled = false;
                    this.CancelBtn.Enabled = false;
                    this.DeleteBtn.Enabled = false;
                    this.AddBtn.Enabled = false;
                    this.SaveBtn.Enabled = false;
                    this.DeleteBtn.Enabled = false;
                    this.AttachmentBtn.Enabled = false;
                    SendFromList_Initialize();
                    Textbox_Initialize();
                }
                else
                {
                    this.AddBtn.Enabled = true;
                    this.CancelBtn.Enabled = false;
                    this.DeleteBtn.Enabled = true;
                    this.AddBtn.Enabled = true;
                    this.SaveBtn.Enabled = true;
                    this.DeleteBtn.Enabled = true;
                    this.AttachmentBtn.Enabled = true;
                    First_Initialize();
                    Textbox_Initialize();
                }
            }
        }
        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.MainBindingSource.RemoveCurrent();
            this.AttachmentBtn.Enabled = true;
            this.CancelBtn.Enabled = false;
            this.DeleteBtn.Enabled = true;
            this.AddBtn.Enabled = true;
            SaveBtn.Enabled = true;
            AddBtn.Enabled = true;
            Button1.Enabled = true;
        }
        private void AttachmentBtn_Click(object sender, EventArgs e)
        {
            DataRow dr;
            dr = Kdv[this.MainBindingSource.Position].Row;
            Module1.Kid = Conversions.ToInteger(dr.ItemArray[0]);
            var Pic_Frm = new Pic_Viewer();
            Pic_Frm.Get_Data = 1;
            Pic_Frm.ShowDialog();
        }
        private void MainBindingSource_PositionChanged_1(object sender, EventArgs e)
        {
            if (this.MainBindingSource.Position >= 0)
            {
                Textbox_Initialize();
                DataGrid_Init();
            }
        }
        private void KarshenasiFrm_KeyDown(object sender, KeyEventArgs e)
        {
            if ((int)e.KeyCode == (int)Keys.F3)
                TxtKno.ReadOnly = false;
        }
        private void Button1_Click_1(object sender, EventArgs e)
        {
            var Cn = new OleDbConnection();
            Cn.ConnectionString = Module1.StrCon;
            var Cmd = new OleDbCommand();
            Cmd.CommandText = "Select Kid from PictureTable where Kid=" + Conversions.ToString(Module1.Kid);
            Cmd.Connection = Cn;
            Cn.Open();
            var dReader = Cmd.ExecuteReader();
            if (dReader.HasRows)
            {
                DataRow dr;
                dr = Kdv[this.MainBindingSource.Position].Row;
                Module1.Kid = Conversions.ToInteger(dr.ItemArray[0]);
                var Pic_frm = new Pic_Viewer();
                Pic_frm.Get_Data = 1;
                Cn.Close();
                Pic_frm.ShowDialog();
            }
            else
            {
                DataRow dr;
                dr = Kdv[this.MainBindingSource.Position].Row;
                Module1.Kid = Conversions.ToInteger(dr.ItemArray[0]);
                var Pic_frm = new Pic_Viewer();
                Pic_frm.Get_Data = 0;
                Cn.Close();
                Pic_frm.ShowDialog();
            }
        }
        private void Create_File_Karshenasi_Item_Click(object sender, EventArgs e)
        {
            Karshenasi_Word_File();
        }
        private void Editing_Karshenasi_File_Item_Click(object sender, EventArgs e)
        {
            Karshenasi_Word_File();
        }
        private void Delete_Karshenasi_File_Item_Click(object sender, EventArgs e)
        {
            int pos = Strings.InStr(Module1.PathFileDatabase, Module1.Karshenasi_FileName);
            string WPath = Strings.Mid(Module1.PathFileDatabase, 1, pos - 1);
            var Kar_dr = Kdv[MainBindingSource.Position].Row;
            WPath += @"Word\";
            if (File.Exists(WPath + Kar_dr.ItemArray[0].ToString() + "_Kar" + ".doc"))
            {
                if ((int)Interaction.MsgBox("آیا مطمئن به حذف فرم کارشناسی جاری می باشید ؟", MsgBoxStyle.YesNo) == (int)MsgBoxResult.Yes)
                {
                    FileSystem.Kill(WPath + Kar_dr.ItemArray[0].ToString() + "_Kar" + ".doc");
                    Delete_Karshenasi_File_Item.Enabled = false;
                    KarshensiFileItem.Text = "ایجاد فرم کارشناسی";
                }
            }
            Menu_Item_Init();
        }
        private void Menu_Item_Init()
        {
            try
            {
                int pos = Strings.InStr(Module1.PathFileDatabase, Module1.Karshenasi_FileName);
                string pathfileword = Strings.Mid(Module1.PathFileDatabase, 1, pos - 1);
                bool T;
                string Wpath = pathfileword;
                if (MainBindingSource.Position > -1)
                {
                    Karshenasi_Price_Menu.Enabled = true;
                    var Karshenasi_dr = Kdv[MainBindingSource.Position].Row;
                    pathfileword = pathfileword + @"word\" + Karshenasi_dr.ItemArray[0].ToString() + "_Kar" + ".Doc";
                    T = File.Exists(pathfileword);
                    if (T == true)
                    {
                        Delete_Karshenasi_File_Item.Enabled = true;
                        Editing_Karshenasi_File_Item.Enabled = true;
                        Create_File_Karshenasi_Item.Enabled = false;
                    }
                    else
                    {
                        Delete_Karshenasi_File_Item.Enabled = false;
                        Editing_Karshenasi_File_Item.Enabled = false;
                        Create_File_Karshenasi_Item.Enabled = true;
                    }
                    Wpath = Wpath + @"word\" + Karshenasi_dr.ItemArray[0].ToString() + "_Mali" + ".doc";
                    T = File.Exists(Wpath);
                    if (T == true)
                    {
                        Create_File_Mali_Item.Enabled = false;
                        Edit_File_Mali_Item.Enabled = true;
                        Delete_File_Mali_Item.Enabled = true;
                    }
                    else
                    {
                        Create_File_Mali_Item.Enabled = true;
                        Edit_File_Mali_Item.Enabled = false;
                        Delete_File_Mali_Item.Enabled = false;
                    }
                }
                else
                {
                    Delete_Karshenasi_File_Item.Enabled = false;
                    Editing_Karshenasi_File_Item.Enabled = false;
                    Create_File_Karshenasi_Item.Enabled = false;
                    Create_File_Mali_Item.Enabled = false;
                    Edit_File_Mali_Item.Enabled = false;
                    Delete_File_Mali_Item.Enabled = false;
                    Karshenasi_Price_Menu.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }
        private void Karshenasi_Word_File()
        {
            try
            {
                if (udv.Table.Rows.Count > 0)
                {
                    int pos = Strings.InStr(Module1.PathFileDatabase, Module1.Karshenasi_FileName);
                    string WPath = Strings.Mid(Module1.PathFileDatabase, 1, pos - 1);
                    var Unit_dr = udv[UBindingSource.Position].Row;
                    var Karshenasi_dr = Kdv[MainBindingSource.Position].Row;
                    WPath += @"Word\";
                    // ساختن و یا استفاده از فرم کارشناسی ایجاد شده
                    if (File.Exists(WPath + Karshenasi_dr.ItemArray[0].ToString() + "_Kar" + ".doc"))
                    {
                        Process.Start(WPath + Karshenasi_dr.ItemArray[0].ToString() + "_Kar" + ".doc");
                        Create_File_Karshenasi_Item.Enabled = false;
                        Editing_Karshenasi_File_Item.Enabled = true;
                        Delete_Karshenasi_File_Item.Enabled = true;
                    }
                    else if (File.Exists(WPath + Unit_dr.ItemArray[3] + ".doc"))
                    {
                        My.MyProject.Computer.FileSystem.CopyFile(WPath + Unit_dr.ItemArray[3] + ".doc", WPath + Karshenasi_dr.ItemArray[0].ToString() + "_Kar" + ".doc", Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs, Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing);

                        Process.Start(WPath + Karshenasi_dr.ItemArray[0].ToString() + "_Kar" + ".doc");
                    }
                    else
                    {
                        object response = Interaction.MsgBox("ابتدا باید نمونه فرم را طراحی نمائید", MsgBoxStyle.OkCancel);
                        if (Operators.ConditionalCompareObjectEqual(response, MsgBoxResult.Ok, false))
                        {
                            Module1.Sid = Conversions.ToInteger(Karshenasi_dr.ItemArray[7]);
                            // Uid = Unit_dr.ItemArray(1)
                            Karshenasi.My.MyProject.MyForms.SazmanFrm.Show();
                        }
                    }
                    Menu_Item_Init();
                }
                else
                    Interaction.MsgBox("ابتدا پرونده کارشناسی را ثبت سپس اقدام به ایجاد فایل کارشناسی نمائید ");
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }
        private void Kaishenasi_Mali_word_File()
        {
            try
            {
                int pos = Strings.InStr(Module1.PathFileDatabase, Module1.Karshenasi_FileName);
                string WPath = Strings.Mid(Module1.PathFileDatabase, 1, pos - 1);
                // Dim document As New WordDocument
                var dr = udv[UBindingSource.Position].Row;
                var Karshenasi_dr = Kdv[MainBindingSource.Position].Row;
                WPath += @"Word\";
                if (File.Exists(WPath + Karshenasi_dr.ItemArray[0].ToString() + "_Mali" + ".doc"))
                {
                    Process.Start(WPath + Karshenasi_dr.ItemArray[0].ToString() + "_Mali" + ".doc");
                    Create_File_Mali_Item.Enabled = false;
                    Edit_File_Mali_Item.Enabled = true;
                    Delete_File_Mali_Item.Enabled = true;
                }
                else if (File.Exists(WPath + dr.ItemArray[4] + ".doc"))
                {
                    My.MyProject.Computer.FileSystem.CopyFile(WPath + dr.ItemArray[4] + ".doc", WPath + Karshenasi_dr.ItemArray[0].ToString() + "_Mali" + ".doc", Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs, Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing);
                    Process.Start(WPath + Karshenasi_dr.ItemArray[0].ToString() + "_Mali" + ".doc");
                }
                else
                {
                    object response = Interaction.MsgBox("ابتدا باید نمونه فرم را طراحی نمائید", MsgBoxStyle.OkCancel);
                    if (Operators.ConditionalCompareObjectEqual(response, MsgBoxResult.Ok, false))
                    {
                        Module1.Sid = Conversions.ToInteger(Karshenasi_dr.ItemArray[7]);
                        Karshenasi.My.MyProject.MyForms.SazmanFrm.Show();
                    }
                }
                Menu_Item_Init();
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }
        private void Create_File_Mali_Item_Click(object sender, EventArgs e)
        {
            Kaishenasi_Mali_word_File();
        }
        private void Edit_File_Mali_Item_Click(object sender, EventArgs e)
        {
            Kaishenasi_Mali_word_File();
        }
        private void Delete_File_Mali_Item_Click(object sender, EventArgs e)
        {
            try
            {
                int pos = Strings.InStr(Module1.PathFileDatabase, Module1.Karshenasi_FileName);
                string WPath = Strings.Mid(Module1.PathFileDatabase, 1, pos - 1);
                var Kar_dr = Kdv[MainBindingSource.Position].Row;

                WPath = WPath + @"word\" + Kar_dr.ItemArray[0].ToString() + "_Mali" + ".doc";
                if (File.Exists(WPath))
                {
                    if ((int)Interaction.MsgBox("آیا مطمئن به حذف فرم مالی کارشناسی جاری می باشید ؟", MsgBoxStyle.YesNo) == (int)MsgBoxResult.Yes)
                    {
                        FileSystem.Kill(WPath);
                        Delete_File_Mali_Item.Enabled = false;
                        Menu_Item_Init();
                    }
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }
        private void Select_Ostan()
        {
            try
            {
                Cn.ConnectionString = Module1.StrCon;
                var da = new OleDbDataAdapter("Select distinct Ostan from TOstan", Cn);
                var Ostav_ds = new DataSet();
                da.Fill(Ostav_ds);
                Ostan_dv = new DataView(Ostav_ds.Tables[0]);
                CbOstan.DataSource = Ostan_dv;
                CbOstan.DisplayMember = "Ostan";
                CbOstan.ValueMember = "Ostan";
                CbOstan.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }
        private void CbOstan_TextChanged(object sender, EventArgs e)
        {
            if (OstanFlag == true)
            {
                Txtsubject.Text = "";
                Txtsubject.AppendText(" ارزیابی ملک ");
                Txtsubject.AppendText(ComboBox3.Text);
                Txtsubject.AppendText(" واقع در استان ");
                Txtsubject.AppendText(CbOstan.Text + " " + "شهرستان");
                Txtsubject.Focus();
            }
        }
        private void detect_Scanner()
        {
            Device MyDevice;
            var MyDialog = new CommonDialogClass();
            try
            {
                // shows selectdevice dialog, if only one device, It automatically selects the device
                MyDevice = MyDialog.ShowSelectDevice(WiaDeviceType.UnspecifiedDeviceType, true, true);
                if (!(MyDevice == null))
                {
                    // loops through device properties, only gets the ones we want to display
                    SelectedDevice = MyDevice;
                    MyDialog.ShowAcquireImage(WiaDeviceType.ScannerDeviceType, WiaImageIntent.ColorIntent, WiaImageBias.MinimizeSize);
                }
                else
                    Interaction.MsgBox("No WIA Devices Found!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problem! " + ex.Message, "Problem Loading Device", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
        }
        private void Txtsubject_Leave(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("En"));
        }
        private void Heyat_dg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 1)
                {
                    var kar_frm = new KarshenasanFrm();
                    if (PadNew == false)
                    {
                        var dr = h_dv[Heyat_BindingSource.Position].Row;
                        kar_frm.Get_data = dr.ItemArray[1];
                    }
                    else
                        kar_frm.Get_data = -1;
                    kar_frm.ShowDialog();
                    if (Conversions.ToBoolean(kar_frm.Get_data >= 0))
                    {
                        if (PadNew == true)
                        {
                            Insert_Kar_Heyat(Conversions.ToInteger(kar_frm.Get_data));
                            PadNew = false;
                        }
                        else
                            Update_Kar_Heyat(Conversions.ToInteger(kar_frm.Get_data));
                    }
                    else if (adNew == true)
                        Heyat_BindingSource.RemoveCurrent();
                }
                DataGrid_Init();
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }
        private void DataGrid_Init()
        {
        }
        private void Insert_Kar_Heyat(int Kid_Karshenasan)
        {
            try
            {
                var dr = Kdv[MainBindingSource.Position].Row;
                string Str;
                Str = "insert into Heyat_Kar (K_id,Kid) values(?,?)";
                var Cn = new OleDbConnection();
                OleDbCommand Cmd;
                Cn.ConnectionString = Module1.StrCon;
                Cmd = new OleDbCommand(Str, Cn);
                Cmd.Parameters.Add("@K_id", OleDbType.Integer).Value = Kid_Karshenasan;
                Cmd.Parameters.Add("@Kid", OleDbType.Integer).Value = dr.ItemArray[0];
                Cn.Open();
                Cmd.ExecuteNonQuery();
                Cn.Close();
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }
        private void Update_Kar_Heyat(int Kid_Karshenasan)
        {
            try
            {
                var dr = h_dv[Heyat_BindingSource.Position].Row;
                string Str;
                Str = "update Heyat_Kar set K_id=? where Kar_h_Id=?";
                var Cn = new OleDbConnection();
                OleDbCommand Cmd;
                Cn.ConnectionString = Module1.StrCon;
                Cmd = new OleDbCommand(Str, Cn);
                Cmd.Parameters.Add("@K_id", OleDbType.Integer).Value = Kid_Karshenasan;
                Cmd.Parameters.Add("@Kar_h_Id", OleDbType.Integer).Value = dr.ItemArray[0];
                Cn.Open();
                Cmd.ExecuteNonQuery();
                Cn.Close();
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }
        private void Add_karshenas(int K_num)
        {
            try
            {
                if (Heyat_BindingSource.Count <= K_num)
                {
                    PadNew = true;
                    if (this.Heyat_BindingSource.Count > 0)
                        this.Heyat_dg.CurrentRow.Cells[0].Value = this.Heyat_BindingSource.Count;
                }
                else
                {
                    Interaction.MsgBox("تعداد کارشناسان عضو هیئت با توجه به باکس کارشناسان انتخاب شده در هیئت تکمیل میباشد");
                    Heyat_BindingSource.RemoveCurrent();
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }
        private void Heyat_dg_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            if (e.Row.IsNewRow)
                PadNew = true;
        }
        private void Karshenasi_Price_Click(object sender, EventArgs e)
        {
            try
            {
                SendFromList_Initialize();
                var dr = Kdv[MainBindingSource.Position].Row;
                var Wage_frm = new Mali_frm();
                Wage_frm.Mali_get_Kid = Module1.Kid;
                Wage_frm.Mali_get_Wage = dr.ItemArray[14].ToString();
                Wage_frm.ShowDialog();
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }
        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (SetUnitFlag == true)
                {
                    Tel_List.Items.Clear();
                    Tel_unit_sazman(Conversions.ToInteger(ComboBox2.SelectedValue));
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }
        private void Tel_Select(int K_Id)
        {
            try
            {
                var Cn = new OleDbConnection();
                Cn.ConnectionString = Module1.StrCon;
                var da = new OleDbDataAdapter("Select * from TelTable where K_Id=" + Conversions.ToString(K_Id), Cn);
                var ds = new DataSet();
                da.Fill(ds);
                var dv = new DataView(ds.Tables[0]);
                if (dv.Table.Rows.Count > 0)
                {
                    int R;
                    var loopTo = dv.Table.Rows.Count - 1;
                    for (R = 0; R <= loopTo; R++)
                    {
                        var Tel_dr = dv[R].Row;
                        Tel_Heyat.Items.Add(Tel_dr.ItemArray[3]);
                    }
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }
        private void Heyat_BindingSource_PositionChanged(object sender, EventArgs e)
        {
            try
            {
                Tel_Heyat.Items.Clear();
                if (h_dv.Table.Rows.Count > 0)
                {
                    var dr = h_dv[Heyat_BindingSource.Position].Row;
                    if (dr.ItemArray[1] != DBNull.Value)
                        Tel_Select(Conversions.ToInteger(dr.ItemArray[1]));
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }
        private void delete_Change_Type_Karshenasi()
        {
            try
            {
                var dr = Kdv[MainBindingSource.Position].Row;
                var Cn = new OleDbConnection();
                Cn.ConnectionString = Module1.StrCon;
                var Cmd = new OleDbCommand();
                Cmd.Connection = Cn;
                Cmd.CommandText = "Delete FROM Price_Karshenasi where KId=" + dr.ItemArray[0];
                Cn.Open();
                Cmd.ExecuteNonQuery();
                Cn.Close();
                Select_Price();
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }
        private void Select_Type_Karshenasi()
        {
            try
            {
                if (SetKarFlag == true)
                {
                    if (K_Id > 0)
                    {
                        if (ComboBox3.SelectedIndex > -1)
                        {
                            if (Price_Karshenasi_BindingSource.Position > -1)
                            {
                                if (!Operators.ConditionalCompareObjectEqual(Karshenasi_Price_DataGridView.CurrentRow.Cells[0].Value, ComboBox3.SelectedValue, false))
                                {
                                    if ((int)Interaction.MsgBox("با تغییر نوع کاربری اطلاعات جدول مبالغ کارشناسی حذف خواهد شد!", MsgBoxStyle.Information) == (int)MsgBoxResult.Ok)
                                    {
                                        delete_Change_Type_Karshenasi();
                                        var Cn = new OleDbConnection();
                                        Cn.ConnectionString = Module1.StrCon;
                                        var da = new OleDbDataAdapter("Select * From Type_Karshenasi Where KarId =" + ComboBox3.SelectedValue, Cn);
                                        var ds = new DataSet();
                                        da.Fill(ds);
                                        Type_Kar_dv = new DataView(ds.Tables[0]);
                                        Tpk_Bs.DataSource = Type_Kar_dv;
                                    }
                                }
                            }
                        }
                    }
                    else
                        First_Type_Karshenasi_Select();
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(TextBox1.Text))
                {
                    TextBox1.Text = Strings.Format(Conversions.ToDouble(TextBox1.Text.Trim().Replace(",", "")), "#,0");
                    TextBox1.SelectionStart = TextBox1.TextLength;
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }
        private void Select_Price()
        {
            try
            {
                Set_Price_Flag = false;
                if (Kdv.Table.Rows.Count > 0)
                {
                    var dr = Kdv[MainBindingSource.Position].Row;
                    var Cn = new OleDbConnection();
                    Cn.ConnectionString = Module1.StrCon;
                    var da = new OleDbDataAdapter("SELECT * FROM price_Karshenasi where KId=" + dr.ItemArray[0], Cn);
                    var ds = new DataSet();
                    da.Fill(ds);
                    Price_dv = new DataView(ds.Tables[0]);
                    double Wage_tmp = 0;
                    if (Price_dv.Table.Rows.Count > 0)
                    {
                        Price_Karshenasi_BindingSource.DataSource = Price_dv;
                        Karshenasi_Price_DataGridView.DataSource = Price_Karshenasi_BindingSource;
                        var Price_dr = Price_dv[Price_Karshenasi_BindingSource.Position].Row;
                        int j = 0;
                        var loopTo = Price_Karshenasi_BindingSource.Count - 1;
                        for (j = 0; j <= loopTo; j++)
                        {
                            Karshenasi_Price_DataGridView.Rows[j].Cells[0].Value = j + 1;
                            Price_dr = Price_dv[j].Row;
                            Wage_tmp += Interaction.IIf(Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(Price_dr.ItemArray[4], true, false) & Price_dr.ItemArray[5] != DBNull.Value), Price_dr.ItemArray[5], 0);
                        }
                        Wage_txt.Text = Conversions.ToString(Wage_tmp);
                        Wage_txt.Text = Strings.Format(Conversions.ToDouble(Wage_txt.Text.Trim().Replace(",", "")), "#,0");
                        var Cmd = new OleDbCommand();
                        Cmd.Connection = Cn;
                        Cmd.CommandText = "Update MainKTable Set Wage=" + Conversions.ToString(Wage_tmp) + " Where KId=" + Conversions.ToString(Module1.Kid);
                        Cn.Open();
                        Cmd.ExecuteNonQuery();
                        Cn.Close();
                        // Cn.ConnectionString = StrCon
                        var da_Remain = new OleDbDataAdapter("Select * from Mali where KId=" + Conversions.ToString(Module1.Kid), Cn);
                        var ds_Remain = new DataSet();
                        da_Remain.Fill(ds_Remain);
                        var Mali_dv = new DataView(ds_Remain.Tables[0]);
                        if (Mali_dv.Table.Rows.Count == 0)
                        {
                            Cmd.CommandText = "Update MainKTable Set remain_wage=" + Conversions.ToString(Wage_tmp) + " Where KId=" + Conversions.ToString(Module1.Kid);
                            Cn.Open();
                            Cmd.ExecuteNonQuery();
                            Cn.Close();
                        }
                    }
                    else
                    {
                        Karshenasi_Price_DataGridView.DataSource = null;
                        var Cmd = new OleDbCommand();
                        Cmd.Connection = Cn;
                        Cmd.CommandText = "Update MainKTable Set remain_wage =Null,wage=Null Where KId=" + Conversions.ToString(Module1.Kid);
                        Cn.Open();
                        Cmd.ExecuteNonQuery();
                        Cn.Close();
                        Wage_txt.Text = "";
                    }
                    Set_Price_Flag = true;
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }
        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if ((int)e.KeyCode == (int)Keys.Enter)
                {
                    if (!string.IsNullOrEmpty(TextBox1.Text))
                    {
                        Karshenasi_Price_DataGridView.CurrentRow.Cells[2].Value = Conversions.ToDouble(TextBox1.Text);
                        Total_wage();
                        TextBox1.Visible = false;
                        Karshenasi_Price_DataGridView.Focus();
                        Karshenasi_Price_DataGridView.BeginEdit(true);
                    }
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }
        private void Karshenasi_Price_DataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                int x1 = Screen.PrimaryScreen.WorkingArea.Width;
                x1 = Conversions.ToInteger((double)(x1 - this.Width) / (double)2);
                int X, y;
                X = Karshenasi_Price_DataGridView.CurrentCell.AccessibilityObject.Bounds.X - x1;
                y = Karshenasi_Price_DataGridView.CurrentCell.AccessibilityObject.Bounds.Y - this.Location.Y - Karshenasi_Price_DataGridView.CurrentCell.Size.Height - 7;
                TextBox1.Location = new Point(X, y);
                TextBox1.Visible = true;
                TextBox1.Text = Interaction.IIf(Karshenasi_Price_DataGridView.CurrentRow.Cells[2].Value == DBNull.Value, "", Karshenasi_Price_DataGridView.CurrentRow.Cells[2].Value);
                TextBox1.Focus();
            }
            else if (TextBox1.Visible == true)
            {
                Total_wage();
                TextBox1.Visible = false;
                Karshenasi_Price_DataGridView.Focus();
            }
        }
        private void Karshenasi_Price_DataGridView_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            if (e.Row.IsNewRow)
            {
                Price_AddNew = true;
                Karshenasi_Price_DataGridView.CurrentRow.Cells[0].Value = Price_Karshenasi_BindingSource.Count;
            }
        }
        private void Update_Karshenasi_Price()
        {
            try
            {
                this.Validate();
                Price_Karshenasi_BindingSource.EndEdit();
                var Price_dr = Price_dv[Price_Karshenasi_BindingSource.Position].Row;
                int POS = Tpk_Bs.Find("Type_Kar_Id", Karshenasi_Price_DataGridView.CurrentRow.Cells[1].Value);
                var Not_Price_dr = Type_Kar_dv[POS].Row;
                var Cn = new OleDbConnection();
                Cn.ConnectionString = Module1.StrCon;
                var Cmd = new OleDbCommand();
                Cmd.Connection = Cn;
                Cmd.CommandText = "Update Price_Karshenasi set Type_Kar_Id=?,Price=?,Not_Price=?,wage=? where Kprice_Id=?";
                int TpkId = Conversions.ToInteger(Karshenasi_Price_DataGridView.CurrentRow.Cells[1].Value);
                Cmd.Parameters.Add("@Type_Kar_Id", OleDbType.Integer).Value = TpkId;
                double Price = Conversions.ToDouble(Interaction.IIf(Price_dr.ItemArray[3] != DBNull.Value, Price_dr.ItemArray[3], DBNull.Value));
                Cmd.Parameters.Add("@Price", OleDbType.Double).Value = Price;
                bool Not_Price = Conversions.ToBoolean(Interaction.IIf(Price_dr.ItemArray[4] == DBNull.Value, false, Price_dr.ItemArray[4]));
                Cmd.Parameters.Add("@Not_Price", OleDbType.Boolean).Value = Not_Price;
                Cmd.Parameters.Add("@Wage", OleDbType.Double).Value = Interaction.IIf(Price_dr.ItemArray[5] != DBNull.Value, Price_dr.ItemArray[5], DBNull.Value);
                Cmd.Parameters.Add("@Kprice_Id", OleDbType.Integer).Value = Price_dr.ItemArray[0];
                Cn.Open();
                Cmd.ExecuteNonQuery();
                Cn.Close();
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }
        private void Insert_Karshenasi_Price()
        {
            try
            {
                this.Validate();
                Price_Karshenasi_BindingSource.EndEdit();
                int POS = Tpk_Bs.Find("Type_Kar_Id", Karshenasi_Price_DataGridView.CurrentRow.Cells[1].Value);
                var dr = Type_Kar_dv[POS].Row;
                var Cn = new OleDbConnection();
                Cn.ConnectionString = Module1.StrCon;
                var Cmd = new OleDbCommand();
                Cmd.Connection = Cn;
                Cmd.CommandText = "Insert into Price_Karshenasi (KId,Type_Kar_Id) values(?,?)";
                Cmd.Parameters.Add("@KId", OleDbType.Integer).Value = Module1.Kid;
                Cmd.Parameters.Add("@Type_Kar_Id", OleDbType.Integer).Value = Karshenasi_Price_DataGridView.CurrentRow.Cells[1].Value;
                Cn.Open();
                Cmd.ExecuteNonQuery();
                Cn.Close();
                Price_AddNew = false;
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }
        private void Total_wage()
        {
            try
            {
                if (Kdv.Table.Rows.Count > 0)
                {
                    var Price_dr = Price_dv[Price_Karshenasi_BindingSource.Position].Row;
                    if (Price_dr.ItemArray[3] != null & Price_dr.ItemArray[3] != DBNull.Value)
                    {
                        double x = Conversions.ToDouble(Price_dr.ItemArray[3]);
                        double Wage_Tmp = 0;
                        switch (x)
                        {
                            case object _ when 0 <= x && x <= 100000000:
                                {
                                    Wage_Tmp = 5 / (double)1000 * x;
                                    break;
                                }

                            case object _ when 100000000 <= x && x <= 500000000:
                                {
                                    Wage_Tmp = 500000 + 2 / (double)1000 * (x - 100000000);
                                    break;
                                }

                            case object _ when 500000000 <= x && x <= 5000000000:
                                {
                                    Wage_Tmp = 1300000 + 1.5 / 1000 * (x - 500000000);
                                    break;
                                }

                            case object _ when 5000000000 <= x && x <= 10000000000000000:
                                {
                                    Wage_Tmp = 8050000 + 1 / (double)1000 * (x - 5000000000);
                                    break;
                                }
                        }
                        Karshenasi_Price_DataGridView.CurrentRow.Cells[4].Value = Wage_Tmp;
                        if (Wage_Tmp > 32500000)
                        {
                            Wage_Tmp = 32500000;
                            Karshenasi_Price_DataGridView.CurrentRow.Cells[4].Value = Wage_Tmp;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }
        private void Karshenasi_Price_DataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (Start_flag == true)
                {
                    if (e.ColumnIndex > 1)
                    {
                        {
                            var withBlock = Karshenasi_Price_DataGridView.CurrentRow;
                            var Price_dr = Price_dv[Price_Karshenasi_BindingSource.Position].Row;
                            if (Price_dr.ItemArray[2] != DBNull.Value)
                            {
                                if (Price_AddNew == false)
                                {
                                    Update_Karshenasi_Price();
                                    Select_Price();
                                }
                                else
                                    Select_Price();
                            }
                            else
                                Select_Price();
                        }
                    }
                    if (e.ColumnIndex == 1 & Price_AddNew == true)
                    {
                        Insert_Karshenasi_Price();
                        Select_Price();
                    }
                    if (e.ColumnIndex == 1 & Price_AddNew == false)
                    {
                        Update_Karshenasi_Price();
                        Select_Price();
                    }
                }
                Price_AddNew = false;
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }
        private void TextBox1_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(TextBox1.Text))
                {
                    Karshenasi_Price_DataGridView.CurrentRow.Cells[2].Value = Conversions.ToDouble(TextBox1.Text);
                    this.Validate();
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }
        private void Karshenasi_Price_DataGridView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex > 1)
                {
                    var Price_dr = Price_dv[Price_Karshenasi_BindingSource.Position].Row;
                    if (Price_dr.ItemArray[2] == DBNull.Value)
                        Select_Price();
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }
        private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Module1.KarshenasanList = true;
            Karshenasi.My.MyProject.MyForms.SazmanFrm.Show();
        }
        private void LinkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Karshenasi.My.MyProject.MyForms.OstanAndShahBaseFrm.Show();
        }
        private void LinkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Karshenasi.My.MyProject.MyForms.DefKarbariFrm.Show();
        }

        private void AddBtnPriceKarshenasi_Click(object sender, EventArgs e)
        {
            Module1.KarIdNew = ComboBox3.SelectedIndex;
            var dr1 = Kdv[MainBindingSource.Position].Row;
            Module1.Kid = Conversions.ToInteger(dr1.ItemArray[0]);
            Karshenasi.My.MyProject.MyForms.AddPriceKarshenasi_frm.Show();
        }

        private void Karshenasi_Price_DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 3)
                {
                    {
                        var withBlock = Karshenasi_Price_DataGridView.CurrentRow;
                        var Price_dr = Price_dv[Price_Karshenasi_BindingSource.Position].Row;
                        if (Price_dr.ItemArray[2] != DBNull.Value)
                        {
                            if (Price_AddNew == false)
                            {
                                Update_Karshenasi_Price();
                                Select_Price();
                            }
                            else
                                Select_Price();
                        }
                        else
                            Select_Price();
                    }
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }
        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Strings.Asc(e.KeyChar) < 48 | Strings.Asc(e.KeyChar) > 57) & Strings.Asc(e.KeyChar) != 8)
                e.Handled = true;
        }
    }
}
