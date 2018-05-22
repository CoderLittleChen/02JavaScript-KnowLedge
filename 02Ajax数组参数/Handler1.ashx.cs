using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _02Ajax数组参数
{
    /// <summary>
    /// Handler1 的摘要说明
    /// </summary>
    public class Handler1 : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            //context.Response.ContentType = "text/plain";
            string str = context.Request["cm"];
            //context.Response.Write(str);
            //JArray arr = (JArray)JsonConvert.DeserializeObject(str);
            //object obj = JsonConvert.DeserializeObject(str);
            //string[] name = new string[arr.Count];
            //for (int i = 0; i < arr.Count; i++)
            //{
            //    name[i] = arr[i].ToString();
            //}
            context.Response.Write(str);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}