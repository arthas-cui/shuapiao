using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                MakeRequests();
                Thread.Sleep(100);
            }
        }

        private static void MakeRequests()
        {
            HttpWebResponse response;

            if (Request_www_wenjuan_com(out response))
            {
                response.Close();
            }
        }

        private static bool Request_www_wenjuan_com(out HttpWebResponse response)
        {
            response = null;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.wenjuan.com/s/eu2i2q/?from=timeline&isappinstalled=0");

                request.KeepAlive = true;
                request.Headers.Set(HttpRequestHeader.Pragma, "no-cache");
                request.Headers.Set(HttpRequestHeader.CacheControl, "no-cache");
                request.Accept = "application/json, text/javascript, */*; q=0.01";
                request.Headers.Add("Origin", @"http://www.wenjuan.com");
                request.Headers.Add("X-Requested-With", @"XMLHttpRequest");
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2272.89 Safari/537.36";
                request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                request.Referer = "http://www.wenjuan.com/s/eu2i2q/?from=timeline&isappinstalled=0";
                request.Headers.Set(HttpRequestHeader.AcceptEncoding, "gzip, deflate");
                request.Headers.Set(HttpRequestHeader.AcceptLanguage, "zh-CN,zh;q=0.8,en;q=0.6");

                request.Method = "POST";
                request.ServicePoint.Expect100Continue = false;

                string body = @"total_answers_str=%7B%22550f9b6ff7405b6524113aba%22%3A%5B%5B%22550f9b76f7405b6524113ac1%22%5D%5D%7D&pconvert_data=%7B%7D&finish_status=1&timestr=2015-03-23+16%3A51%3A32&uuid=ce20f426-d139-11e4-84dd-f8bc123ee698&svc=20470077f1bc2e55d36d98b9549be63d&version=1&s_code=-20&s_func_id=49&vvv=49fde9d8ae5cdfe250ef43f4604ed764&rand_int=0&from=timeline&isappinstalled=0";
                byte[] postBytes = System.Text.Encoding.UTF8.GetBytes(body);
                request.ContentLength = postBytes.Length;
                Stream stream = request.GetRequestStream();
                stream.Write(postBytes, 0, postBytes.Length);
                stream.Close();

                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException e)
            {
                if (e.Status == WebExceptionStatus.ProtocolError) response = (HttpWebResponse)e.Response;
                else return false;
            }
            catch (Exception)
            {
                if (response != null) response.Close();
                return false;
            }

            return true;
        }
    }
}
