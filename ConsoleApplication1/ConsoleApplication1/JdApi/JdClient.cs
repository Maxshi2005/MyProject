using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using TC.Train.OTS.CommonEntity.Config;
using TC.Train.OTS.CommonToolsLibrary.Core;

namespace TC.Train.OTS.OutService.JdApi
{
    public class JdClient
    {
        private static readonly string _baseUri = "";
        private static readonly string _appKey = "";
        private static readonly string _appSecret = "";

        public JdClient()
        {
        }

        public T Execute<R, T>(R request)
            where R : IJdRequest
            where T : class
        {
            string urlParam = "";
            try
            {
                string url = _baseUri + "/routerjson";
                var appParam = JsonConvert.SerializeObject(request);
                urlParam = GetUrlParam(appParam, request);
                string fullUrl = string.Format("{0}?{1}", url, urlParam);
                var responseStr = GetRequest(fullUrl, Encoding.UTF8, 30000);
                Log(responseStr, null);
                var response = JsonConvert.DeserializeObject<T>(responseStr);
                return response;
            }
            catch(Exception ex)
            {
                Log(urlParam, request, ex);
                return null;
            }
        }

        public static string GetRequest(string m_QuestURL, Encoding encode, int timeout)
        {
            string result = string.Empty;
            HttpWebRequest request = null;
            StreamReader avReader = null;
            try
            {
                request = (HttpWebRequest)HttpWebRequest.Create(m_QuestURL);
                request.Timeout = timeout;
                request.ServicePoint.Expect100Continue = false;
                avReader = new StreamReader(request.GetResponse().GetResponseStream(), encode);
                result = avReader.ReadToEnd();
            }
            catch (WebException err)
            {
                switch (err.Status)
                {
                    case WebExceptionStatus.Timeout:
                        result = "请求超时";
                        break;
                    default:
                        result = err.Message;
                        break;
                }
            }
            catch (Exception err)
            {
                result = err.Message;
            }
            finally
            {
                if (avReader != null)
                {
                    request.Abort();
                    avReader.Close();
                }
            }
            return ClearSpecialCharForReq(result);
        }
        public static string ClearSpecialCharForReq(string sourceString)
        {
            if (string.IsNullOrEmpty(sourceString))
            {
                return string.Empty;
            }

            return sourceString.Trim(new char[] { '"' });
        }

        private string GetUrlParam(string appParam, IJdRequest request)
        {
            string timeStamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string token = GetAccessToken();

            StringBuilder sb = new StringBuilder();
            sb.Append("360buy_param_json=");
            sb.Append(appParam);
            sb.Append("&access_token=");
            sb.Append(token);
            sb.Append("&app_key=");
            sb.Append(_appKey);
            sb.Append("&method=");
            sb.Append(request.GetApiName());
            sb.Append("&timestamp=");
            sb.Append(timeStamp);
            sb.Append("&v=2.0");
            sb.Append("&sign=");
            sb.Append(GetSign(appParam, request, timeStamp, token));

            return sb.ToString();
        }

        private string GetSign(string appParam, IJdRequest request, string timeStamp, string token)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(_appSecret);
            sb.Append("360buy_param_json");
            sb.Append(appParam);
            sb.Append("access_token");
            sb.Append(token);
            sb.Append("app_key");
            sb.Append(_appKey);
            sb.Append("method");
            sb.Append(request.GetApiName());
            sb.Append("timestamp");
            sb.Append(timeStamp);
            sb.Append("v2.0");
            sb.Append(_appSecret);

            return Md5Helper.GetMD5(sb.ToString());
        }

        private string GetAccessToken()
        {
            return AccessTokenHelper.GetJdToken();
        }

        private void Log(string str, object request, Exception ex = null)
        {
           
        }
    }
}
