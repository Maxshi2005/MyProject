using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.IO;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml;

namespace TC.Train.OTS.CommonToolsLibrary.Core
{
    public class Md5Helper
    {
        /// <summary>
        /// 加密密钥
        /// </summary>
        public static readonly string SECRET = "L82V6ZVD6J";
        //默认密钥向量
        private static byte[] Keys = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
        /// <summary>
        /// DES加密字符串
        /// </summary>
        /// <param name="encryptString">待加密的字符串</param>
        /// <param name="encryptKey">加密密钥,要求为8位</param>
        /// <returns>加密成功返回加密后的字符串,失败返回源串</returns>
        //public static string Encode(string encryptString, string encryptKey)
        //{
        //    byte[] bKey = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 8));
        //    byte[] bIV = Keys;
        //    byte[] bStr = Encoding.UTF8.GetBytes(encryptString);
        //    try
        //    {
        //        DESCryptoServiceProvider desc = new DESCryptoServiceProvider();
        //        MemoryStream mStream = new MemoryStream();
        //        CryptoStream cStream = new CryptoStream(mStream, desc.CreateEncryptor(bKey, bIV), CryptoStreamMode.Write);
        //        cStream.Write(bStr, 0, bStr.Length);
        //        cStream.FlushFinalBlock();
        //        return URLHelper.Encode(Convert.ToBase64String(mStream.ToArray()));
        //    }
        //    catch
        //    {
        //        return string.Empty;
        //    }
        //}

        /// <summary>
        /// DES解密字符串
        /// </summary>
        /// <param name="decryptString">待解密的字符串</param>
        /// <param name="decryptKey">解密密钥,要求为8位,和加密密钥相同</param>
        /// <returns>解密成功返回解密后的字符串,失败返源串</returns>
        //public static string Decode(string decryptString, string decryptKey)
        //{
        //    try
        //    {
        //        byte[] bKey = Encoding.UTF8.GetBytes(decryptKey.Substring(0, 8));
        //        byte[] bIV = Keys;
        //        byte[] bStr = Convert.FromBase64String(decryptString);
        //        DESCryptoServiceProvider desc = new DESCryptoServiceProvider();
        //        MemoryStream mStream = new MemoryStream();
        //        CryptoStream cStream = new CryptoStream(mStream, desc.CreateDecryptor(bKey, bIV), CryptoStreamMode.Write);
        //        cStream.Write(bStr, 0, bStr.Length);
        //        cStream.FlushFinalBlock();
        //        return Encoding.UTF8.GetString(mStream.ToArray());
        //    }
        //    catch
        //    {
        //        try
        //        {
        //            decryptString = URLHelper.Decode(decryptString);
        //            byte[] bKey = Encoding.UTF8.GetBytes(decryptKey.Substring(0, 8));
        //            byte[] bIV = Keys;
        //            byte[] bStr = Convert.FromBase64String(decryptString);
        //            DESCryptoServiceProvider desc = new DESCryptoServiceProvider();
        //            MemoryStream mStream = new MemoryStream();
        //            CryptoStream cStream = new CryptoStream(mStream, desc.CreateDecryptor(bKey, bIV), CryptoStreamMode.Write);
        //            cStream.Write(bStr, 0, bStr.Length);
        //            cStream.FlushFinalBlock();
        //            return Encoding.UTF8.GetString(mStream.ToArray());
        //        }
        //        catch
        //        {
        //            return string.Empty;
        //        }
        //    }

        //}

        public static string MD5(string pTorypt)
        {
            //将要加密的字符串转化为byte类型
            byte[] data = System.Text.Encoding.Unicode.GetBytes(pTorypt.ToCharArray());

            //创建一个Md5对象
            System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();

            //打印密码方式加密
            string EnPswdStr = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(pTorypt.ToString(), "MD5");

            //显示出来
            return EnPswdStr;
        }

        public static string GetMD5(string input, string charset = "utf-8")
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] data = md5.ComputeHash(Encoding.GetEncoding(charset).GetBytes(input));
            StringBuilder builder = new StringBuilder(32);
            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2"));
            }
            return builder.ToString();
        }

        public static string GetQueryStringByName(string str, string name)
        {
            string val = string.Empty;
            if (!string.IsNullOrWhiteSpace(str))
            {
                string[] strs = str.Split('&');
                foreach (string item in strs)
                {
                    string[] s = item.Split('=');
                    if (s[0] == name)
                    {
                        val = s[1];
                        break;
                    }
                }
            }
            return val;
        }

        public static string MD5(string input, int len = 32)
        {
            var enPswStr = "";
            //将要加密的字符串转化为byte类型
            byte[] data = System.Text.Encoding.Unicode.GetBytes(input.ToCharArray());

            //创建一个Md5对象 
            var md5 = new MD5CryptoServiceProvider();
            if (len == 16)
            {
                enPswStr = BitConverter.ToString(md5.ComputeHash(UTF8Encoding.Default.GetBytes(input)), 4, 8);
                enPswStr = enPswStr.Replace("-", "");
            }
            else
            {
                enPswStr = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(input, "MD5");
            }

            return enPswStr;
        }

        //public static string GetDecKey
        //{
        //    get { return XmlReader.GetConfigValue("decKey", GetClientSiteConfigPath()); }
        //}

        //public static string GetMd5Key
        //{
        //    get { return XmlReader.GetConfigValue("md5Key", GetClientSiteConfigPath()); }
        //}

        /// <summary>
        /// 获取前台网站的配置文件的物理路径
        /// </summary>
        /// <returns></returns>
        public static string GetClientSiteConfigPath()
        {
            string path = ConfigurationSettings.AppSettings["SiteConfigFile"];
            return RootPath + path;
        }

        /// <summary>
        /// 取得网站根目录的物理路径,结尾始终包含“\”符号
        /// </summary>
        /// <returns></returns>
        public static string RootPath
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

        /// <summary>
        /// 计算输入字符串的MD5 哈希值
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string GetMd5Hash(string input)
        {
            using (MD5 md5Hash = System.Security.Cryptography.MD5.Create())
            {
                // Convert the input string to a byte array and compute the hash.
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Create a new Stringbuilder to collect the bytes
                // and create a string.
                StringBuilder sBuilder = new StringBuilder();

                // Loop through each byte of the hashed data 
                // and format each one as a hexadecimal string.
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                // Return the hexadecimal string.
                return sBuilder.ToString();
            }
        }
    }
}
