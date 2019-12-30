using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System;
using Syncfusion.XlsIO;
using System.Data.OleDb;
using Microsoft.VisualBasic.CompilerServices;

namespace Karshenasi
{
    public partial class ListKarshenasiFrm
    {
        private DataView Kdv;
        private DataView sdv;
        private DataView udv;
        private OleDbConnection Cn = new OleDbConnection();
        private string StrFilter = "";
        private string SubFilter = "";
        private bool setFlag = false;
        private bool SetUnitFlag = false;
        private void ListKarshenasiFrm_Load(object sender, EventArgs e)
        {
            try
            {
                Karshenasi.My.MyProject.MyForms.Wait_frm.Show();
                Karshenasi.My.MyProject.MyForms.Wait_frm.Refresh();
                First_Initialize();
                Type_Sazman();
                Unit_Sazman(Conversions.ToInteger(ComboBox1.SelectedValue));
                Clear_Textbox();
                InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("Fa"));
                Karshenasi.My.MyProject.MyForms.Wait_frm.Close();
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
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
                sdv = new DataView(ds.Tables[0]);
                WBindingSource.DataSource = sdv;
                ComboBox1.DataSource = WBindingSource;
                ComboBox1.DisplayMember = "Sazman";
                ComboBox1.ValueMember = "SId";
                ComboBox1.Text = "";
                setFlag = true;
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
        private void Clear_Textbox()
        {
            TxtNo.Text = "";
            TxtSubject.Text = "";
            TxtDate1.Text = "";
            TxtDate2.Text = "";
            TxtEnDate1.Text = "";
            TxtEnDate2.Text = "";
            TxtPAsli.Text = "";
            TxtPFarei.Text = "";
            ComboBox1.Text = "";
            ComboBox2.Text = "";
        }

        private void First_Initialize()
        {
            try
            {
                Cn.ConnectionString = Module1.StrCon;
                var da = new OleDbDataAdapter("Select * from MainKTable", Cn);
                var Kds = new DataSet();
                da.Fill(Kds);
                Kdv = new DataView(Kds.Tables[0]);
                this.ListBindingSource.DataSource = Kdv;
                this.ListDataGrid.DataSource = this.ListBindingSource;
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        private void ListDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                var kar_frm = new KarshenasiFrm();
                DataRow dr;
                dr = Kdv[this.ListBindingSource.Position].Row;
                kar_frm.Get_Data = dr.ItemArray[0];
                kar_frm.ShowDialog();
                First_Initialize();
            }
        }
        private void Filter_Box()
        {
            try
            {
                ListBindingSource.RemoveFilter();

                SubFilter = "";
                if (!string.IsNullOrEmpty(TxtNo.Text))
                    SubFilter = SubFilter + "Kno='" + TxtNo.Text + "'";
                if (!string.IsNullOrEmpty(ComboBox1.Text))
                {
                    if (setFlag == true)
                    {
                        if (!string.IsNullOrEmpty(SubFilter))
                        {
                            SubFilter = SubFilter + " And  ";
                            SubFilter = SubFilter + " Sid =" + ComboBox1.SelectedValue;
                        }
                        else
                            SubFilter = SubFilter + " Sid =" + ComboBox1.SelectedValue;
                    }
                }
                if (!string.IsNullOrEmpty(ComboBox2.Text))
                {
                    if (SetUnitFlag == true)
                    {
                        if (!string.IsNullOrEmpty(SubFilter))
                        {
                            SubFilter = SubFilter + " And  ";
                            SubFilter = SubFilter + " KSid =" + ComboBox2.SelectedValue;
                        }
                        else
                            SubFilter = SubFilter + " KSid =" + ComboBox2.SelectedValue;
                    }
                }
                if (!string.IsNullOrEmpty(TxtSubject.Text))
                {
                    if (!string.IsNullOrEmpty(SubFilter))
                    {
                        SubFilter = SubFilter + " And  ";
                        SubFilter = SubFilter + "subject Like'%" + TxtSubject.Text + "%'";
                    }
                    else
                        SubFilter = SubFilter + "subject Like'%" + TxtSubject.Text + "%'";
                }
                if (!string.IsNullOrEmpty(TxtPAsli.Text))
                {
                    if (!string.IsNullOrEmpty(SubFilter))
                    {
                        SubFilter = SubFilter + " And  ";
                        SubFilter = SubFilter + "pasli ='" + TxtPAsli.Text + "'";
                    }
                    else
                        SubFilter = SubFilter + "pasli ='" + TxtPAsli.Text + "'";
                }
                if (!string.IsNullOrEmpty(TxtPFarei.Text))
                {
                    if (!string.IsNullOrEmpty(SubFilter))
                    {
                        SubFilter = SubFilter + " And  ";
                        SubFilter = SubFilter + "PFarei ='" + TxtPFarei.Text + "'";
                    }
                    else
                        SubFilter = SubFilter + "PFarei ='" + TxtPFarei.Text + "'";
                }
                if (!string.IsNullOrEmpty(TxtDate1.Text) & string.IsNullOrEmpty(TxtDate2.Text))
                {
                    if (!string.IsNullOrEmpty(SubFilter))
                    {
                        SubFilter = SubFilter + " And  ";
                        SubFilter = SubFilter + "kdate = '" + TxtDate1.Text + "'";
                    }
                    else
                        SubFilter = SubFilter + "kdate = '" + TxtDate1.Text + "'";
                }
                if (string.IsNullOrEmpty(TxtDate1.Text) & !string.IsNullOrEmpty(TxtDate2.Text))
                {
                    if (!string.IsNullOrEmpty(SubFilter))
                    {
                        SubFilter = SubFilter + " And  ";
                        SubFilter = SubFilter + "kdate = '" + TxtDate2.Text + "'";
                    }
                    else
                        SubFilter = SubFilter + "kdate = '" + TxtDate2.Text + "'";
                }
                if (!string.IsNullOrEmpty(TxtDate1.Text) & !string.IsNullOrEmpty(TxtDate2.Text))
                {
                    if (!string.IsNullOrEmpty(SubFilter))
                    {
                        SubFilter = SubFilter + " And  ";
                        SubFilter = SubFilter + "kdate >= '" + TxtDate1.Text + "'";
                    }
                    else
                        SubFilter = SubFilter + "kdate >= '" + TxtDate1.Text + "'";
                    if (!string.IsNullOrEmpty(SubFilter))
                    {
                        SubFilter = SubFilter + " And  ";
                        SubFilter = SubFilter + "kdate  <='" + TxtDate2.Text + "'";
                    }
                    else
                        SubFilter = SubFilter + "kdate  <='" + TxtDate2.Text + "'";
                }


                if (!string.IsNullOrEmpty(TxtEnDate1.Text) & string.IsNullOrEmpty(TxtEnDate2.Text))
                {
                    if (!string.IsNullOrEmpty(SubFilter))
                    {
                        SubFilter = SubFilter + " And  ";
                        SubFilter = SubFilter + "EndDate = '" + TxtEnDate1.Text + "'";
                    }
                    else
                        SubFilter = SubFilter + "EndDate = '" + TxtEnDate1.Text + "'";
                }
                if (string.IsNullOrEmpty(TxtEnDate1.Text) & !string.IsNullOrEmpty(TxtEnDate2.Text))
                {
                    if (!string.IsNullOrEmpty(SubFilter))
                    {
                        SubFilter = SubFilter + " And  ";
                        SubFilter = SubFilter + "EndDate = '" + TxtEnDate2.Text + "'";
                    }
                    else
                        SubFilter = SubFilter + "EndDate = '" + TxtEnDate2.Text + "'";
                }
                if (!string.IsNullOrEmpty(TxtEnDate1.Text) & !string.IsNullOrEmpty(TxtEnDate2.Text))
                {
                    if (!string.IsNullOrEmpty(SubFilter))
                    {
                        SubFilter = SubFilter + " And  ";
                        SubFilter = SubFilter + "EndDate >= '" + TxtEnDate1.Text + "'";
                    }
                    else
                        SubFilter = SubFilter + "EndDate >= '" + TxtEnDate1.Text + "'";
                    if (!string.IsNullOrEmpty(SubFilter))
                    {
                        SubFilter = SubFilter + " And  ";
                        SubFilter = SubFilter + "EndDate  <='" + TxtEnDate2.Text + "'";
                    }
                    else
                        SubFilter = SubFilter + "EndDate  <='" + TxtEnDate2.Text + "'";
                }
            }

            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        private void TxtNo_TextChanged(object sender, EventArgs e)
        {
            Filter_Box();
            this.ListBindingSource.Filter = SubFilter;
        }

        private void TxtSubject_TextChanged(object sender, EventArgs e)
        {
            Filter_Box();
            this.ListBindingSource.Filter = SubFilter;
        }

        private void TxtPAsli_TextChanged(object sender, EventArgs e)
        {
            Filter_Box();
            this.ListBindingSource.Filter = SubFilter;
        }

        private void TxtPFarei_TextChanged(object sender, EventArgs e)
        {
            Filter_Box();
            this.ListBindingSource.Filter = SubFilter;
        }
        private void TxtDate2_ValueChanged(object sender, EventArgs e)
        {
            Filter_Box();
            this.ListBindingSource.Filter = SubFilter;
        }
        private void TxtDate1_ValueChanged(object sender, EventArgs e)
        {
            Filter_Box();
            this.ListBindingSource.Filter = SubFilter;
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            Clear_Textbox();
            ComboBox1.Text = "";
            ComboBox2.Text = "";
            this.ListBindingSource.RemoveFilter();
        }

        private void ListKarshenasiFrm_KeyUp(object sender, KeyEventArgs e)
        {
            if ((int)e.KeyCode == (int)Keys.Escape)
                this.Close();
        }

        private void ExcelBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var ExcelEngine1 = new ExcelEngine();
                var Application = ExcelEngine1.Excel;
                var Workbook = ExcelEngine1.Excel.Workbooks.Create(3);
                var Sheet = Workbook.Worksheets[0];
                int i = 2;
                // Sheet.Range("A1:AB1000").VerticalAlignment = ExcelVAlign.VAlignDistributed
                Sheet.Range["A1:AB1000"].CellStyle.Font.FontName = "Tahoman";
                Sheet.Range["A1:AB100"].CellStyle.Font.Size = 10;
                {
                    var withBlock = Sheet;
                    withBlock.Range["A1"].Value = "ردیف";
                    withBlock.Range["B1"].Value = "شماره كارشناسي";
                    withBlock.Range["C1"].Value = "تاريخ كارشناسي";
                    withBlock.Range["D1"].Value = "موضوع كارشناسي";
                    withBlock.Range["E1"].Value = "پلاك اصلي";
                    withBlock.Range["F1"].Value = "پلاك فرعي";
                    withBlock.Range["G1"].Value = "ارزش كارشناسي";

                    int l = 2;
                    int t = 0;
                    this.ListBindingSource.MoveFirst();
                    DataRow dr;
                    while (t < this.ListBindingSource.Count)
                    {
                        dr = Kdv[this.ListBindingSource.Position].Row;
                        withBlock.Range["A" + Conversions.ToString(t + 2)].Value = Conversions.ToString(t + 1);
                        withBlock.Range["B" + Conversions.ToString(t + 2)].Value = dr.ItemArray[5].ToString();
                        withBlock.Range["C" + Conversions.ToString(t + 2)].Value = dr.ItemArray[4].ToString();
                        withBlock.Range["D" + Conversions.ToString(t + 2)].Value = dr.ItemArray[1].ToString();
                        withBlock.Range["E" + Conversions.ToString(t + 2)].Value = dr.ItemArray[3].ToString();
                        withBlock.Range["F" + Conversions.ToString(t + 2)].Value = dr.ItemArray[2].ToString();
                        withBlock.Range["G" + Conversions.ToString(t + 2)].Value = dr.ItemArray[6].ToString();
                        this.ListBindingSource.MoveNext();
                        t += 1;
                    }
                }
                Workbook.SaveAs("sample.xls");
                Process.Start("sample.xls");
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        private void ComboBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Filter_Box();
                this.ListBindingSource.Filter = SubFilter;
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        private void WBindingSource_PositionChanged(object sender, EventArgs e)
        {
            Unit_Sazman(Conversions.ToInteger(ComboBox1.SelectedValue));
        }

        private void ComboBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Filter_Box();
                this.ListBindingSource.Filter = SubFilter;
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }

        private void Delete_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if ((int)Interaction.MsgBox("آیا نظریه کارشناسی مورد نظر را حذف مینمائید؟", MsgBoxStyle.OkCancel) == (int)MsgBoxResult.Ok)
                {
                    var dr = Kdv[ListBindingSource.Position].Row;
                    var Cn = new OleDbConnection();
                    Cn.ConnectionString = Module1.StrCon;
                    var Cmd = new OleDbCommand();
                    Cmd.CommandText = "delete From MainKTable where Kid=" + dr.ItemArray[0];
                    Cmd.Connection = Cn;
                    Cn.Open();
                    Cmd.ExecuteNonQuery();
                    Cn.Close();
                    First_Initialize();
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }
        private void TxtNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) == true)
                e.Handled = true;
        }
        private void TxtEnDate1_ValueChanged(object sender, EventArgs e)
        {
            Filter_Box();
            this.ListBindingSource.Filter = SubFilter;
        }

        private void TxtEnDate2_ValueChanged(object sender, EventArgs e)
        {
            Filter_Box();
            this.ListBindingSource.Filter = SubFilter;
        }
    }
}
