using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _36导出数据到浏览器
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Export_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("WorkerNO", typeof(int));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Gender", typeof(string));
            for (int i = 0; i < 10; i++)
            {
                DataRow dataRow = dt.NewRow();
                dataRow["ID"] = 1;
                dataRow["WorkerNO"] = 16660;
                dataRow["Name"] = "陈敏";
                dataRow["Gender"] = "男";
                dt.Rows.Add(dataRow);
            }

            ExportExcel(dt);

        }

        public void ExportExcel(DataTable dt)
        {
            HttpResponse response = HttpContext.Current.Response;
            response.Buffer = true;
            response.Clear();
            response.ClearHeaders();   
            response.ClearContent();
            response.ContentType = "application/vnd.ms-excel";
            response.AddHeader("content-disposition", string.Format("attachment; filename={0}.xls","导出测试"));
            response.Charset = "GB2312";
            response.ContentEncoding = Encoding.GetEncoding("GB2312");

            //实例化一个流
            StringWriter stringWrite = new StringWriter();

            //指定文本输出到流
            HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            GridView gv = new GridView();
            gv.DataSource = dt;
            gv.DataBind();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    //设置每个单元格的格式
                    gv.Rows[i].Cells[j].Attributes.Add("style", "vnd.ms-excel.numberformat:@");
                }
            }

            //把 GridView 的内容输出到 HtmlTextWriter
            gv.RenderControl(htmlWrite);
            response.Write(stringWrite.ToString());
            response.Flush();
            response.Close();
        }


    }
}