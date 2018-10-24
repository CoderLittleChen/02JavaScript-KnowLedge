using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24DataTable批量插入数据
{
    class Program
    {
        static void Main(string[] args)
        {
            //关于SqlBulkCopy几点疑问
            //1、用于插入数据的DataTable表中的列名和顺序   是否需要和数据库中的表保存一致
            //   需要和数据库中的表结构  列名  保持一致     
            //2、SqlBulkCopyColumnMapping   类的使用方法     用来设置表结构映射     确保临时表的表结构和数据库中表的结构一致
            //这样才能批量插入    
            
            //当触发器包含多种触发类型   怎样判断当前执行的是什么操作？
            //有inserted         有deleted          说明是Update操作
            //有inserted         没有deleted       说明是Insert操作
            //没有inserted      有deleted          说明是deleted操作 

            //

            //先新建一个DataTable       
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Id", typeof(int));
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("Age", typeof(int));
            //向表中添加100W条数据        
            for (int i = 0; i < 1000000; i++)
            {
                DataRow dataRow = dataTable.NewRow();
                dataRow["Id"] = i + 1;
                dataRow["Name"] = "狗蛋";
                dataRow["Age"] = i + 10;
                dataTable.Rows.Add(dataRow);
            }


            //开始批量插入数据
            string conStr = ConfigurationManager.ConnectionStrings["conStr"].ToString();
            using (SqlConnection con = new SqlConnection(conStr))
            {
                try
                {
                    con.Open();
                    //这里注意当使用SqlBulkCopy来插入数据的时候，若是想要调用表中的触发器
                    //需要将SqlBulkCopyOptions 属性设置为FireTrigger   插入数据的时候  允许调用触发器    
                    //不过批量插入    insert触发器也只执行一次     对应的inserted可以是一行数据，也可以是一个结果集（批量插入的数据）
                    //Update也只触发一次    无论更新数据有多少   
                    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(con, SqlBulkCopyOptions.FireTriggers, null))
                    {
                        //设置对应数据库的物理表名      TestTableForBatchInsert    就是要插入数据的表  
                        bulkCopy.DestinationTableName = "TestTableForBatchInsert";
                        //BatchSize  一次事务插入的数据    
                        bulkCopy.BatchSize = dataTable.Rows.Count;
                        //超时时间设置   单位是秒
                        bulkCopy.BulkCopyTimeout = 12 * 60 * 60;
                        //数据源中的列名与目标表字段的映射关系    
                        bulkCopy.ColumnMappings.Add("Id", "Id");
                        bulkCopy.ColumnMappings.Add("Name", "Name");
                        bulkCopy.ColumnMappings.Add("Age", "Age");

                        //监测程序开始时间      
                        Stopwatch stopwatch = new Stopwatch();
                        stopwatch.Start();
                        bulkCopy.WriteToServer(dataTable);
                        stopwatch.Stop();
                        Console.WriteLine("本次数据插入共耗时：" + stopwatch.Elapsed.TotalSeconds);
                        Console.ReadKey();
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

        /// <summary>
        /// 自定义方法实现    批量插入   执行触发器 
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="dt">临时表对象</param>
        /// <param name="conStr">连接字符串</param>
        /// <param name="copyOptions">批量插入的参数   决定是否执行触发器</param>
        /// <param name="mappingList">临时表与数据表的列 映射关系</param>
        public static  void BatchInsertForTrigger(string tableName, DataTable dt, string conStr, SqlBulkCopyOptions copyOptions, List<SqlBulkCopyColumnMapping> mappingList)
        {
            //开始批量插入数据
            using (SqlConnection con = new SqlConnection(conStr))
            {
                try
                {
                    con.Open();
                    //这里注意当使用SqlBulkCopy来插入数据的时候，
                    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(con, copyOptions, null))
                    {
                        //设置对应数据库的物理表名      TestTableForBatchInsert
                        bulkCopy.DestinationTableName = tableName;
                        //BatchSize  一次事务插入的数据
                        bulkCopy.BatchSize = dt.Rows.Count;
                        //超时时间设置
                        bulkCopy.BulkCopyTimeout = 12 * 60 * 60;
                        //数据源中的列名与目标表字段的映射关系
                        for (int i = 0; i < mappingList.Count; i++)
                        {
                            bulkCopy.ColumnMappings.Add(mappingList[i]);
                        }

                        //监测程序开始时间   
                        Stopwatch stopwatch = new Stopwatch();
                        stopwatch.Start();
                        bulkCopy.WriteToServer(dt);
                        stopwatch.Stop();
                        Console.WriteLine("本次数据插入耗时：" + stopwatch.Elapsed.TotalSeconds);
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
