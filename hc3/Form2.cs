using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace hc3
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
             tb = new DataTable();
            DataColumn dc1 = new DataColumn("Range℃", Type.GetType("System.Double"));
            DataColumn dc2 = new DataColumn("WetBulbTem℃", Type.GetType("System.Double"));
            DataColumn dc3 = new DataColumn("Inletwatertem℃", Type.GetType("System.Double"));
            DataColumn dc4 = new DataColumn("result", Type.GetType("System.Double"));
            tb.Columns.Add(dc1);
            tb.Columns.Add(dc2);
            tb.Columns.Add(dc3);
            tb.Columns.Add(dc4);

        }
        public string str = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = .\hc3.accdb";
        DataTable tb;
        public int i=0;
        private void button1_Click(object sender, EventArgs e)
        {
            i++;
            OleDbConnection conn = new OleDbConnection(str);
            conn.Open();
            OleDbCommand cmd = new OleDbCommand("select result from shuju where WetBulbTem℃ =" + textBox1.Text + "and Range℃=" + textBox5.Text + "and Inletwatertem℃=" + textBox3.Text + "", conn);
            OleDbDataAdapter da = new OleDbDataAdapter();//适配器
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();//缓冲集
            da.Fill(ds);
            datatab(ds);
            conn.Close();
        }
       public void datatab(DataSet dt)
        {
            DataRow dr = tb.NewRow();
            dr["Range℃"] = textBox5.Text;
            dr["WetBulbTem℃"] = textBox1.Text;
            dr["Inletwatertem℃"] = textBox3.Text;
            dr["result"] = dt.Tables[0].Rows[0]["result"].ToString();
            tb.Rows.Add(dr);
            dataGridView2.DataSource = tb;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

    

        private void button3_Click(object sender, EventArgs e)
        {
            if(i>7)
            {
            OleDbConnection conn = new OleDbConnection(str);
            conn.Open();
            string select1 = "Select * from  shebei ";
            OleDbDataAdapter da = new OleDbDataAdapter(select1, conn);
            DataSet d = new DataSet();
            da.Fill(d);
            DataTable ta = d.Tables[0];
            dataGridView2.DataSource = ta;
            conn.Close(); i = 0;
            }
            else
            {
                MessageBox.Show("未找齐8个闭塔软件计算不能查找设备");
            }
          
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
          /*  System.Drawing.Image imgPhoto = System.Drawing.Image.FromFile(@".\BackGround.jpg");
            this.BackgroundImage = imgPhoto;
            int sourceWidth = imgPhoto.Width;
            int sourceHeight = imgPhoto.Height;
            Size size = new Size(sourceWidth, sourceHeight);
            this.Size = size;*/
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“hc3DataSet1.shebei”中。您可以根据需要移动或删除它。
            this.shebeiTableAdapter.Fill(this.hc3DataSet1.shebei);
            // TODO: 这行代码将数据加载到表“hc3DataSet.shuju”中。您可以根据需要移动或删除它。
            this.shujuTableAdapter.Fill(this.hc3DataSet.shuju);

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }
}
