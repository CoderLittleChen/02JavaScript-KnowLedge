using System;
using System.Collections.Generic;
using System.Data;
using Oracle.ManagedDataAccess.Client;
//using Oracle.ManagedDataAccess.Types;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25连接Oracle数据库
{
    class Program
    {
        static void Main(string[] args)
        {
            //string sql = "server=192.168.1.253;Data  Source=topprod;user id=tiptop;pwd=Tt_Z#0527";topprod
            //string sql = "Data Source=192.168.1.253/topprod;User ID=DS01;Password=Tt_Z#0527;";
            string sql = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.1.253)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=topprod)));User Id=DS01;Password=Tt_Z#0527";
            OracleConnection con = new OracleConnection(sql);
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                Console.WriteLine(111);
            }
            else
            {
                Console.WriteLine(222);
            }
            Console.ReadKey();
        }
    }
}
