using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace _16后台字典集合转成json字符串
{
    /// <summary>
    /// _1 的摘要说明
    /// </summary>
    public class _1 : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string dataStr = context.Request["parms"];   
            Dictionary<string, string> dic = new Dictionary<string, string>();
            JavaScriptSerializer scriptSerializer = new JavaScriptSerializer();
            dic = (Dictionary<string, string>)scriptSerializer.Deserialize(dataStr, typeof(Dictionary<string, string>));
            //foreach (KeyValuePair<string, string> item in dic)
            //{
            //    //item.value是只读的  循环中不能赋值 
            //    Console.WriteLine("Key值为：" + item.Key + "Value值为：" + item.Value);
            //}
            if (dic["name"] == "cm")
            {
                dic["name"] = "mc";
            }
            if (dic["age"] == "18")
            {
                dic["age"] = "81";
            }
            string jsonStr = scriptSerializer.Serialize(dic);
            context.Response.Write(jsonStr);
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