using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _33批量插入数据
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        // <summary>
        /// 自定义方法实现    批量插入   执行触发器 
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="dt">临时表对象</param>
        /// <param name="conStr">连接字符串</param>
        /// <param name="copyOptions">批量插入的参数   决定是否执行触发器</param>
        /// <param name="mappingList">临时表与数据表的列 映射关系</param>
        public void BatchInsertForTrigger(string tableName, DataTable dt, string conStr, SqlBulkCopyOptions copyOptions, List<SqlBulkCopyColumnMapping> mappingList)
        {
            //开始批量插入数据
            using (SqlConnection con = new SqlConnection(conStr))
            {
                try
                {
                    con.Open();
                    //这里注意当使用SqlBulkCopy来插入数据的时候，需要设置执行参数   SqlBulkCopyOptions  
                    //如果批量插入的表中有触发器   参数需要设置成       SqlBulkCopyOptions.FireTriggers   FireTriggers
                    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(con, copyOptions, null))
                    {
                        //设置对应数据库的物理表名      TestTableForBatchInsert
                        bulkCopy.DestinationTableName = tableName;
                        //BatchSize  一次事务插入的数据
                        bulkCopy.BatchSize = dt.Rows.Count;
                        //超时时间设置
                        bulkCopy.BulkCopyTimeout = 12 * 60 * 60;
                        //数据源中的列名与目标表字段的映射关系
                        //还要注意的是    生成的临时表和要插入数据库中的 表结构映射需要一直
                        for (int i = 0; i < mappingList.Count; i++)
                        {
                            bulkCopy.ColumnMappings.Add(mappingList[i]);
                        }
                        //监测程序开始  开始计时  
                        Stopwatch stopwatch = new Stopwatch();
                        stopwatch.Start();
                        bulkCopy.WriteToServer(dt);
                        stopwatch.Stop();
                        //LogHelper.Info("向TempData表中批量插入数据(测试触发器是否执行)", "本次数据插入共耗时：" + stopwatch.Elapsed.TotalSeconds);
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if (con != null && con.State == ConnectionState.Closed)
                    {
                        con.Close();
                    }
                }
            }
        }



    }
}
