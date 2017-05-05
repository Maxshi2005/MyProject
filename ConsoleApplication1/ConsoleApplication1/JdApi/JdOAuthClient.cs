using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TC.Train.OTS.OutService.JdApi.AccessToken;

using System.Web;
using Newtonsoft.Json;
using System.Xml;
using System.Configuration;
using System.Text.RegularExpressions;
using TC.Train.OTS.CommonEntity.Config;

namespace TC.Train.OTS.OutService.JdApi
{
    public static class JdJos
    {
        public static string BaseUri
        {
            get
            {
                return GetNodeValue("JdJos/BaseUri");
            }
        }

        public static string AppKey
        {
            get
            {
                return GetNodeValue("JdJos/AppKey");
            }
        }

        public static string AppSecret
        {
            get
            {
                return GetNodeValue("JdJos/AppSecret");
            }
        }

        static string GetNodeValue(string path)
        {
            var result = string.Empty;
            XmlNode node = GetSingleNode(path, GetClientSiteConfigPath());
            if (node != null)
                result = node.InnerText;
            return result;
        }
        static XmlNode GetSingleNode(string xpath, string XmlPath)
        {
            System.Xml.XmlDocument xdoc = new XmlDocument();
            xdoc.Load(XmlPath);
            XmlElement root = xdoc.DocumentElement;
            return root.SelectSingleNode(xpath);
        }
        static string GetClientSiteConfigPath()
        {
            string path = ConfigurationManager.AppSettings["SiteConfigFile"];
            return RootPath + path;
        }

        static string RootPath
        {
            get
            {
                string AppPath = "";
                HttpContext HttpCurrent = HttpContext.Current;

                if (HttpCurrent != null)
                {
                    AppPath = HttpCurrent.Server.MapPath("~");
                }
                else
                {
                    AppPath = AppDomain.CurrentDomain.BaseDirectory;
                    if (Regex.Match(AppPath, @"\\$", RegexOptions.Compiled).Success)
                        AppPath = AppPath.Substring(0, AppPath.Length - 1);
                }
                if (AppPath.Substring(AppPath.Length - 1, 1) != "\\")
                    AppPath += "\\";

                return AppPath;
            }
        }
    }

    public class JdOAuthClient
    {
        private static readonly string _appKey = SiteInfo.JdJos.AppKey;
        private static readonly string _appSecret = SiteInfo.JdJos.AppSecret;
        private const string _tokenUrl = "https://oauth.jd.com/oauth/token";
        private const string _redirectUrlTest = "http://wx.17u.cn/trainofftest/Transfer/Jd/AccessToken";
        private const string _redirectUrlProduct = "http://wx.17u.cn/trainoff/Transfer/Jd/AccessToken";

        public JdOAuthClient()
        {

        }

        //public GetAccessTokenResponse GetAccessToken(GetAccessTokenRequest request)
        //{
        //    string urlParam = "";
        //    try
        //    {
        //        urlParam = GetUrlParam(request);
        //        string fullUrl = string.Format("{0}?{1}", _tokenUrl, urlParam);
        //        var respStr = HttpRequestHelper.GetRequest(fullUrl, Encoding.GetEncoding("GBK"), 30000);
        //        var resp = JsonConvert.DeserializeObject<GetAccessTokenResponse>(respStr);
        //        if(resp == null || string.IsNullOrEmpty(resp.access_token))
        //        {
        //            Log(respStr ?? "", request, new Exception(respStr ?? ""));
        //        }
        //        return resp;
        //    }
        //    catch(Exception ex)
        //    {
        //        Log(urlParam, request, ex);
        //        return null;
        //    }
        //}

        //public GetAccessTokenResponse RefreshToken(RefreshTokenRequest request)
        //{
        //    string urlParam = "";
        //    try
        //    {
        //        urlParam = GetRefreshUrlParam(request);
        //        string fullUrl = string.Format("{0}?{1}", _tokenUrl, urlParam);
        //        var respStr = HttpRequestHelper.GetRequest(fullUrl, Encoding.GetEncoding("GBK"), 30000);
        //        var resp = JsonConvert.DeserializeObject<GetAccessTokenResponse>(respStr);
        //        if (resp == null || string.IsNullOrEmpty(resp.access_token))
        //        {
        //            Log(respStr ?? "", request, new Exception(respStr ?? ""));
        //        }
        //        return resp;
        //    }
        //    catch (Exception ex)
        //    {
        //        Log(urlParam, request, ex);
        //        return null;
        //    }
        //}

        private string GetRefreshUrlParam(RefreshTokenRequest request)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("grant_type=refresh_token");
            sb.Append("&client_id=");
            sb.Append(_appKey);
            sb.Append("&client_secret=");
            sb.Append(_appSecret);
            sb.Append("&refresh_token=");
            sb.Append(request.RefreshToken);

            return sb.ToString();
        }

        private string GetUrlParam(GetAccessTokenRequest request)
        {
            string redirectUrl = HttpUtility.UrlEncode(GetRedirectUrl());

            StringBuilder sb = new StringBuilder();
            sb.Append("grant_type=authorization_code");
            sb.Append("&client_id=");
            sb.Append(_appKey);
            sb.Append("&client_secret=");
            sb.Append(_appSecret);
            sb.Append("&scope=read");
            sb.Append("&redirect_uri=");
            sb.Append(redirectUrl);
            sb.Append("&code=");
            sb.Append(request.Code);
            sb.Append("&state=");
            sb.Append(request.State);

            return sb.ToString();
        }

        private string GetRedirectUrl()
        {
            return _redirectUrlProduct;
        }

        private void Log(string str, object request, Exception ex = null)
        {
           
        }
    }
}
