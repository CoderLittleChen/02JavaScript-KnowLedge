using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _07测试数据库连接
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //点击按钮   打开数据库连接 测试是否成功    Integrated   Security     
            string conStr = "Server=CM;Database=Demo;Integrated Security=true";
            //string conStr=""
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    MessageBox.Show("连接成功");
                }
                else
                {
                    MessageBox.Show("连接失败！！");
                }
            }
            //ConfigurationManager.AppSettings[];
        }
    }
}
