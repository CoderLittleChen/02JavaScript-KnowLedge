using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _01js数组作为ajax的参数
{
    /// <summary>
    /// Handler1 的摘要说明
    /// </summary>
    public class Handler1 : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //string name = context.Request["param"];
            ////context.Response.Write("{\"cm\":\"name\"}");
            //context.Response.Write(name);

            //context.Response.ContentType = "text/plain";
            string str = context.Request["cm"];
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