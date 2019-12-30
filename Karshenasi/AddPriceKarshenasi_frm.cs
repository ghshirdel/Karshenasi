using System.Data;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System;
using System.Data.OleDb;
using Microsoft.VisualBasic.CompilerServices;

namespace Karshenasi
{
    public partial class AddPriceKarshenasi_frm
    {
        private DataView Type_Kar_dv;
        private DataRow dr;
        private void PriceBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var Cn = new OleDbConnection();
                Cn.ConnectionString = Module1.StrCon;
                string Str = "Insert into Price_Karshenasi (KId,Type_Kar_Id,Price) values(?,?,?)";
                var Cmd = new OleDbCommand(Str, Cn);
                dr = Type_Kar_dv[BindingSource1.Position].Row;
                Cmd.Parameters.Add("@KId", OleDbType.Integer).Value = Module1.Kid;
                Cmd.Parameters.Add("@Type_Kar_Id", OleDbType.Integer).Value = Convert.ToInt32(dr.ItemArray[0]);
                Cmd.Parameters.Add("@Price", OleDbType.Double).Value = Interaction.IIf(TextBox1.Text.Length != 0, Convert.ToDouble(TextBox1.Text), DBNull.Value);
                Cn.Open();
                Cmd.ExecuteNonQuery();
                Cn.Close();
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }

            this.Close();
        }
        private void First_Type_Karshenasi_Select()
        {
            try
            {
                var Cn = new OleDbConnection();
                Cn.ConnectionString = Module1.StrCon;
                var da = new OleDbDataAdapter("Select * From Type_Karshenasi Where KarId =" + Conversions.ToString(Module1.KarIdNew), Cn);
                var ds = new DataSet();
                da.Fill(ds);
                Type_Kar_dv = new DataView(ds.Tables[0]);
                BindingSource1.DataSource = Type_Kar_dv;
                ComboBox1.DataSource = BindingSource1;
                ComboBox1.DisplayMember = "Type_Kar_Desc";
                ComboBox1.ValueMember = "Type_Kar_Id";
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.ToString());
            }
        }
        private void AddPriceKarshenasi_frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Module1.KarIdNew = 0;
        }

        private void AddPriceKarshenasi_frm_Load(object sender, EventArgs e)
        {
            // ComboBox1.SelectedIndex = -1
            First_Type_Karshenasi_Select();
        }
    }
}
