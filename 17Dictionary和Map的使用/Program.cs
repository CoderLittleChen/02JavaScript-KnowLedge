using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace _17Dictionary和Map的使用
{
    class Program
    {
        static void Main(string[] args)
        {
            ////Dictionary对象不能直接转换ToString()
            ////Dictionary对象和Java中的Map对象使用类似

            //Dictionary<string, string> dic = new Dictionary<string, string>();
            //dic.Add("1", "cm");
            //dic.Add("2", "cmm");

            //JavaScriptSerializer scriptSerializer = new JavaScriptSerializer();
            ////这里如果反序列化的对象为字典对象，其中的键必须为字符串或对象
            //string jsonStr = scriptSerializer.Serialize(dic);
            //Console.WriteLine(jsonStr);
            ////Console.WriteLine(dic[1]);

            
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("1", "cm");
            dic.Add("2", "cmm");

            string json= JsonConvert.SerializeObject(dic);
            Console.WriteLine(json);

            Console.ReadKey();
        }
    }
}
