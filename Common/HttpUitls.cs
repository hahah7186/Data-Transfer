using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace Quickstarts.DataAccessClient.Common
{
        public class HttpUitls
        {
            private struct PLC_Start_IN
            {
                public string station_id;
                public string wrkst_name;
                public string ip;
            }

            public static string Get(string telNo)
            {
                //System.GC.Collect();
                //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@"http://www.kuaidi100.com/query?type=shunfeng&postid=" + telNo);
                //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@"https://www.baifubao.com/callback?cmd=1059&callback=phone&phone=" + telNo);

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@"http://localhost:8090/httpTest/getResJson? telNo=" + telNo);
                request.Proxy = HttpWebRequest.DefaultWebProxy;
                //request.Credentials = System.Net.CredentialCache.DefaultCredentials;
                request.Proxy.Credentials = new NetworkCredential("user", "password", "domain");
                request.KeepAlive = false;
                request.Method = "GET";
                request.ContentType = HttpContentType.WWW_FORM_URLENCODED_UTF8;
                request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
                request.UseDefaultCredentials = true;
                request.Headers.Add("Authorization", "0579fadb1821653edec4c23fb7d1a66847cf318e261c4585bbea773800db2f927b7cc96d568f8f35b16d014b552de5e6");
                request.CookieContainer = new CookieContainer();
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2228.0 Safari/537.36";

                string retString = "";
                try
                {
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    Stream myResponseStream = response.GetResponseStream();
                    StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);
                    retString = myStreamReader.ReadToEnd();

                    myStreamReader.Close();
                    myResponseStream.Close();

                    if (response != null)
                    {
                        response.Close();
                    }
                    if (request != null)
                    {
                        request.Abort();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    //throw;
                    retString = "error";
                }

                return retString;
            }

            #region 发送post请求
            public static string Post(string JSON_to_Server, string url)
            {

                string result = "";
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                //HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:8090/httpTest/report");
                req.Method = "POST";
                req.ContentType = HttpContentType.WWW_FORM_URLENCODED;

                //JSON_to_Server = "data=" + JSON_to_Server;
                //byte[] data = Encoding.UTF8.GetBytes(JSON_to_Server);//把字符串转换为字节
                byte[] data = Encoding.ASCII.GetBytes(JSON_to_Server);
                req.ContentLength = data.Length; //请求长度

                using (Stream reqStream = req.GetRequestStream()) //获取
                {
                    reqStream.Write(data, 0, data.Length);//向当前流中写入字节
                    reqStream.Close(); //关闭当前流
                }

                HttpWebResponse resp = (HttpWebResponse)req.GetResponse(); //响应结果
                Stream stream = resp.GetResponseStream();
                //获取响应内容
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    result = reader.ReadToEnd();
                }
                return result;
            }
        #endregion

        public static string ConvertJsonString(string str)
        {
            //格式化json字符串
            JsonSerializer serializer = new JsonSerializer();
            TextReader tr = new StringReader(str);
            JsonTextReader jtr = new JsonTextReader(tr);
            object obj = serializer.Deserialize(jtr);
            if (obj != null)
            {
                StringWriter textWriter = new StringWriter();
                JsonTextWriter jsonWriter = new JsonTextWriter(textWriter)
                {
                    Formatting = Formatting.Indented,
                    Indentation = 4,
                    IndentChar = ' '
                };
                serializer.Serialize(jsonWriter, obj);
                return textWriter.ToString();
            }
            else
            {
                return str;
            }
        }
    }
}
