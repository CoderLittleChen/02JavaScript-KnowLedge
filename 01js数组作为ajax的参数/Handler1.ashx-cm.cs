using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
            ////context.Response.ContentType = "text/plain";
            //string name = context.Request.Params["arr[]"];
            ////context.Response.Write("{\"cm\":\"name\"}");
            //context.Response.Write(name);

            //这里后台拿到的是  [111,222,"333",false]
            string arr = context.Request["arr"];
            JArray jarr = (JArray)JsonConvert.DeserializeObject(arr);
            //这里如果数组中是键值对的形式  则jarr[0]["key"]  就能获取到对应的值
            context.Response.Write(jarr[0].ToString());

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