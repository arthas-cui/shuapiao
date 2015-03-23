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
            var Program = new Program();
            while (true)
            {
                Program.MakeRequests();
                Thread.Sleep(getRandomNumber());
            }
        }

        private void MakeRequests()
        {
            HttpWebResponse response;

            if (Request_www_wenjuan_com(out response))
            {
                response.Close();
            }
        }

        private bool Request_www_wenjuan_com(out HttpWebResponse response)
        {
            response = null;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.wenjuan.com/s/eu2i2q/?from=timeline&isappinstalled=0");

                request.KeepAlive = true;
                request.Accept = "application/json, text/javascript, */*; q=0.01";
                request.Headers.Add("Origin", @"http://www.wenjuan.com");
                request.Headers.Add("X-Requested-With", @"XMLHttpRequest");
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2272.89 Safari/537.36";
                request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                request.Referer = "http://www.wenjuan.com/s/eu2i2q/?from=timeline&isappinstalled=0";
                request.Headers.Set(HttpRequestHeader.AcceptEncoding, "gzip, deflate");
                request.Headers.Set(HttpRequestHeader.AcceptLanguage, "zh-CN,zh;q=0.8,en;q=0.6");
                request.Headers.Set(HttpRequestHeader.Cookie, @"project_550f9a23f7405b6430d8ca2d=2; local_code=""emhfQ04=|1427101316|97d72df5581f8412d4463409986f8784917d40a4""; sessionid=V2hyazJESDNWOW5MRWc3ZjU1MGZkNjg0|1427101316|a2f3c7fe7ff3077fa21bd6c273cafa61b1dd693a; _xsrf=141f7d2cb73448df84b66cd621cab0d6; Hm_lvt_805c9a16950cbbec8732e90433c5a9e2=1427101319; Hm_lpvt_805c9a16950cbbec8732e90433c5a9e2=1427101364; current_rid=; open_rspd_link_tag_eu2i2q=""MQ==|1427102003|a1eef72fbd3e79e1aa95546e851996a55a56410d""");

                request.Method = "POST";
                request.ServicePoint.Expect100Continue = false;

                string body = @"total_answers_str=%7B%22550f9b6ff7405b6524113aba%22%3A%5B%5B%22550f9b76f7405b6524113ac1%22%5D%5D%7D&pconvert_data=%7B%7D&finish_status=1&timestr=2015-03-23+17%3A13%3A23&uuid=db01b6f0-d13c-11e4-8b70-f8bc123ee698&svc=8871f2fd38bc300e0ff8168374ce0c93&version=1&s_code=-24&s_func_id=15&vvv=6fcf75551e4b59188bda7026e5f1f987&rand_int=61&from=timeline&isappinstalled=0&_xsrf=141f7d2cb73448df84b66cd621cab0d6";
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
        private static Random _random = new Random();
        private static int getRandomNumber()
        {
            return _random.Next(3000);
        }
    }
}
