using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml;

namespace TC.Train.OTS.CommonEntity.Config
{
    public partial class SiteInfo
    {
        /// <summary>
        /// 取得网站根目录的物理路径,结尾始终包含“\”符号
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// 开发环境
        /// </summary>
        public static class Environment
        {
            /// <summary>
            /// 是否生产环境
            /// </summary>
            public static string GetEnvironment()
            {
                XmlNode node = GetSingleNode("Environment", GetClientSiteConfigPath());
                if (node != null)
                    return node.InnerText;
                return "";
            }
        }

        /// <summary>
        /// 获得节点对应的值
        /// </summary>
        /// <param name="path">节点路径</param>
        /// <returns>对应的值</returns>
        static string GetNodeValue(string path)
        {
            var result = string.Empty;
            XmlNode node = GetSingleNode(path, GetClientSiteConfigPath());
            if (node != null)
                result = node.InnerText;
            return result;
        }

        /// <summary>
        /// 获取前台网站的配置文件的物理路径
        /// </summary>
        /// <returns></returns>
        static string GetClientSiteConfigPath()
        {
            string path = ConfigurationManager.AppSettings["SiteConfigFile"];
            return RootPath + path;
        }

        /// <summary>
        /// 使用xpath获取指定节点的内容
        /// </summary>
        /// <param name="xpath">xpath表达式</param>
        /// <param name="XmlPath">配置文件路径</param>
        /// <returns>指定节点的值</returns>
        static XmlNode GetSingleNode(string xpath, string XmlPath)
        {
            System.Xml.XmlDocument xdoc = new XmlDocument();
            xdoc.Load(XmlPath);
            XmlElement root = xdoc.DocumentElement;
            return root.SelectSingleNode(xpath);
        }

        //-------------------------------------------------华丽de分割线-------------------------------------------------

        #region 环境配置
        /// <summary>
        /// 开发环境
        /// </summary>
        public static class EnvironmentCfg
        {
            /// <summary>
            /// 是否生产环境
            /// </summary>
            public static string Environment
            {
                get
                {
                    return GetNodeValue("Environment");
                }
            }
        }
        #endregion

        public static class PTOrderConfig
        {
            public static string SerialNoPrefix
            {
                get
                {
                    return GetNodeValue("PTOrderConfig/SerialNoPrefix");
                }
            }
            public static string SMSUrl
            {
                get
                {
                    return GetNodeValue("PTOrderConfig/SMSUrl");
                }
            }
            public static string PushMsgUrl
            {
                get { return GetNodeValue("PTOrderConfig/PushMsgUrl"); }
            }

            public static string GetPostFee
            {
                get
                {
                    return GetNodeValue("PTOrderConfig/GetPostFee");
                }
            }

        }

        public static class EMSConfig
        {
            public static string Account
            {
                get
                {
                    return GetNodeValue("EMSAccount/Account");
                }
            }
            public static string PassWord
            {
                get
                {
                    return GetNodeValue("EMSAccount/PassWord");
                }
            }
            public static string AppKey
            {
                get
                {
                    return GetNodeValue("EMSAccount/AppKey");
                }
            }
            public static string ApiUrl
            {
                get
                {
                    return GetNodeValue("EMSAccount/ApiUrl");
                }
            }
            public static string TrackUrl
            {
                get
                {
                    return GetNodeValue("EMSAccount/TrackUrl");
                }
            }
            public static string TrackVersion
            {
                get
                {
                    return GetNodeValue("EMSAccount/TrackVersion");
                }
            }
            public static string TrackAuthenticate
            {
                get
                {
                    return GetNodeValue("EMSAccount/TrackAuthenticate");
                }
            }
        }

        public static class SFConfig
        {
            public static string ApiUrl
            {
                get
                {
                    return GetNodeValue("SFAccount/ApiUrl");
                }
            }
            public static string Checkword
            {
                get
                {
                    return GetNodeValue("SFAccount/Checkword");
                }
            }
            public static string CustId
            {
                get
                {
                    return GetNodeValue("SFAccount/CustId");
                }
            }
            public static string OrderHead
            {
                get
                {
                    return GetNodeValue("SFAccount/OrderHead");
                }
            }

            public static string OrderService
            {
                get
                {
                    return GetNodeValue("SFAccount/OrderService");
                }
            }

            public static string RouteService
            {
                get
                {
                    return GetNodeValue("SFAccount/RouteService");
                }
            }

            public static string SearchService
            {
                get
                {
                    return GetNodeValue("SFAccount/SearchService");
                }
            }

            /// <summary>
            /// 过滤的特殊字符
            /// </summary>
            public static string SpecialCharacters
            {
                get
                {
                    return GetNodeValue("SFAccount/SpecialCharacters");
                }
            }

            public static string SyncMailSearchUrl
            {
                get
                {
                    return GetNodeValue("SFAccount/SyncMailSearchUrl");
                }
            }
        }

        public static class GrabLineTicketUrl
        {
            public static string GrabTicketOrderListUri
            {
                get
                {
                    return GetNodeValue("GrabLineTicket/GrabTicketOrderListUri");
                }
            }

            public static string GrabNotifyIssueTicketUri
            {
                get
                {
                    return GetNodeValue("GrabLineTicket/GrabNotifyIssueTicketUri");
                }
            }
        }

        #region 会员体系配制文件 AppKey&AppSecret
        /// <summary>
        /// 会员 信息查询读取配制文件
        /// </summary>
        public static class QueryMemberConfig
        {
            public static string AppKey
            {
                get
                {
                    return GetNodeValue("QueryMember/AppKey");
                }
            }

            public static string AppSecret
            {
                get
                {
                    return GetNodeValue("QueryMember/AppSecret");
                }
            }
        }
        #endregion

        #region 余票查询配置参数
        /// <summary>
        /// 当日屏蔽开始时间（小时）（1-24整数）
        /// DESC：比如21点开始屏蔽21~次日屏蔽结束时间
        /// </summary>
        public static int BookForbiddenStart
        {
            get
            {
                int result = 0;
                var val = GetNodeValue("TrainServicesConstValue/BookForbiddenStart");
                int.TryParse(val, out result);
                return result;
            }
        }
        /// <summary>
        /// 当日屏蔽开始时间（分钟）
        /// </summary>
        public static int BookForbiddenStartMinute
        {
            get
            {
                int result = 0;
                var val = GetNodeValue("TrainServicesConstValue/BookForbiddenStartMinute");
                int.TryParse(val, out result);
                return result;
            }
        }
        /// <summary>
        /// 当日屏蔽结束时间（小时）
        /// </summary>
        public static int EarliestBookeHour
        {
            get
            {
                int result = 0;
                var val = GetNodeValue("TrainServicesConstValue/EarliestBookeHour");
                int.TryParse(val, out result);
                return result;
            }
        }
        /// <summary>
        /// 当日屏蔽结束时间（小时）
        /// </summary>
        public static int EarliestBookeMinute
        {
            get
            {
                int result = 0;
                var val = GetNodeValue("TrainServicesConstValue/EarliestBookeMinute");
                int.TryParse(val, out result);
                return result;
            }
        }
        #endregion

        /// <summary>
        /// 火车票公共XML服务基地址(Touch站)
        /// </summary>
        public static string GetBaseXmlUrl
        {
            get
            {
                return GetNodeValue("TCTouchTrainService/BaseXmlUrl");
            }
        }


        public static string GetBaseTicketsServiceUrl
        {
            get
            {
                return GetNodeValue("TCBaseTrainService/BookOrderUrl");
            }
        }

        public static string ProviderMsgCode
        {
            get
            {
                return GetNodeValue("ProviderMessage/msgCode");
            }
        }

        public static string ProviderMsgInfo
        {
            get
            {
                return GetNodeValue("ProviderMessage/msgInfo");
            }
        }

        #region EMS运单号获取配置
        public static class EMSInterface
        {
            public static string GetQueryEMSData
            {
                get
                {
                    return GetNodeValue("EMSInterface/QueryEMSData");
                }
            }

            public static string Account
            {
                get
                {
                    return GetNodeValue("EMSInterface/Account");
                }
            }

            public static string PassWord
            {
                get
                {
                    return GetNodeValue("EMSInterface/Password");
                }
            }

            public static string AppKey
            {
                get
                {
                    return GetNodeValue("EMSInterface/AppKey");
                }
            }

            public static string GetBillNoBySys
            {
                get
                {
                    return GetNodeValue("EMSInterface/GetBillNoBySys");
                }
            }
        }
        #endregion

        #region 各接口调用地址
        /// <summary>
        /// 各接口调用地址
        /// </summary>
        public static class InterfaceUrlConfig
        {
            /// <summary>
            /// 资源接口
            /// </summary>
            public static string Resourceurl
            {
                get
                {
                    return GetNodeValue("InterfaceUrlConfig/ResourceUrl");
                }
            }

            /// <summary>
            /// 车次查询地址
            /// </summary>
            public static string TrainQueryUrl
            {
                get
                {
                    return GetNodeValue("InterfaceUrlConfig/TrainQueryUrl");
                }
            }

            /// <summary>
            /// 车次查询地址
            /// </summary>
            public static string TrainQueryUrl2
            {
                get
                {
                    return GetNodeValue("InterfaceUrlConfig/TrainQueryUrl2");
                }
            }

            /// <summary>
            /// 车次缓存查询地址
            /// </summary>
            public static string TrainCacheQueryUrl
            {
                get
                {
                    return GetNodeValue("InterfaceUrlConfig/TrainCacheQueryUrl");
                }
            }

            /// <summary>
            /// 公共接口请求地址
            /// </summary>
            public static string TrainPublicInterfaceUrl
            {
                get
                {
                    return GetNodeValue("InterfaceUrlConfig/TrainPublicInterfaceUrl");
                }
            }

            /// <summary>
            /// 火车票新保险接口
            /// </summary>
            public static string TrainNewInsuranceUrl
            {
                get
                {
                    return GetNodeValue("InterfaceUrlConfig/TrainNewInsuranceUrl");
                }
            }

            public static string TrainWeixinCustomsizeUrl
            {
                get
                {
                    return GetNodeValue("InterfaceUrlConfig/TrainWeixinCustomsizeUrl");
                }
            }


            /// <summary>
            /// 获取系统维护标记接口
            /// </summary>
            public static string SysMaintenanceFlagUrl
            {
                get
                {
                    return GetNodeValue("InterfaceUrlConfig/SysMaintenanceFlagUrl");
                }
            }

            /// <summary>
            /// 获取车次详细信息
            /// </summary>
            public static string GetTravelInfoV1Url
            {
                get
                {
                    return GetNodeValue("InterfaceUrlConfig/GetTravelInfoV1Url");
                }
            }           
        }
        #endregion

        public static string SyncMailTrackUrl
        {
            get
            {
                return GetNodeValue("SyncMailExpress/SyncMailTrackUrl");
            }
        }

        #region 红包配置
        public static class RedPackageConfig
        {
            public static string Account
            {
                get
                {
                    return GetNodeValue("RedPackage/Account");
                }
            }

            public static string Key
            {
                get
                {
                    return GetNodeValue("RedPackage/Key");
                }
            }
        }
        #endregion

        public static class PromoCodeConfig
        {
            public static string Account
            {
                get
                {
                    return GetNodeValue("PromoCodeConfig/Account");
                }
            }

            public static string BatchNo2
            {
                get
                {
                    return GetNodeValue("PromoCodeConfig/BatchNo2");
                }
            }

            public static string BatchNo3
            {
                get
                {
                    return GetNodeValue("PromoCodeConfig/BatchNo3");
                }
            }

            public static string BatchNo4
            {
                get
                {
                    return GetNodeValue("PromoCodeConfig/BatchNo4");
                }
            }

            public static string BatchNo5
            {
                get
                {
                    return GetNodeValue("PromoCodeConfig/BatchNo5");
                }
            }

            public static string PrivateKey
            {
                get
                {
                    return GetNodeValue("PromoCodeConfig/PrivateKey");
                }
            }

            public static string BatchPrefix
            {
                get
                {
                    return GetNodeValue("PromoCodeConfig/BatchPrefix");
                }
            }

            public static string TicketsNumPerPassenger
            {
                get
                {
                    return GetNodeValue("PromoCodeConfig/TicketsNumPerPassenger");
                }
            }

            public static string Switch
            {
                get
                {
                    return GetNodeValue("PromoCodeConfig/Switch");
                }
            }

        }

        public static class ProjectSite
        {

            public static string ServerOnline
            {
                get
                {
                    return GetNodeValue("ProjectSite/ServerOnline");
                }
            }

        }

        public static string TrainAssistUrl
        {
            get
            {
                return GetNodeValue("TCBaseTrainService/TrainAssistUrl");
            }
        }

        public static string TrainAssist
        {
            get
            {
                return GetNodeValue("TCBaseTrainService/TrainAssist");
            }
        }

        public static class WechatConfig
        {
            /// <summary>
            /// 获取Tokenurl
            /// </summary>
            public static string TokenUrl
            {
                get
                {//
                    return GetNodeValue("WechatPush/TokenUrl");
                }
            }
            /// <summary>
            /// 推送url
            /// </summary>
            public static string PushUrl
            {
                get
                {
                    return GetNodeValue("WechatPush/PushUrl");
                }
            }


            public static string WechatDetailUrl
            {
                get
                {
                    return GetNodeValue("WechatPush/DetailUrl");
                }
            }

            public static string WechaAuthtDetailUrl
            {
                get
                {
                    return GetNodeValue("WechatPush/AuthDetailUrl");
                }
            }
        }

        #region 微信支付接口

        /// <summary>
        /// 各接口调用地址
        /// </summary>
        public static class WXPayConfig
        {
            /// <summary>
            /// 支付回写路径
            /// </summary>
            public static string PayBackUrl
            {
                get
                {
                    return GetNodeValue("WXPayConfig/PayBackUrl");
                }
            }

            /// <summary>
            /// 网络账号信息
            /// </summary>
            public static string TrainPaymentAccount
            {
                get
                {
                    return GetNodeValue("WXPayConfig/TrainPaymentAccount");
                }
            }

            /// <summary>
            /// 网络账号信息
            /// </summary>
            public static string TrainPaymentKey
            {
                get
                {
                    return GetNodeValue("WXPayConfig/TrainPaymentKey");
                }
            }

            /// <summary>
            /// 微信自己支付账号信息
            /// </summary>
            public static string WxTrainPaymentAccount
            {
                get
                {
                    return GetNodeValue("WXPayConfig/WxTrainPaymentAccount");
                }
            }

            /// <summary>
            /// 微信自己支付账号信息
            /// </summary>
            public static string WxTrainPaymentKey
            {
                get
                {
                    return GetNodeValue("WXPayConfig/WxTrainPaymentKey");
                }
            }

            /// <summary>
            /// 微信支付项目编码
            /// </summary>
            public static string WxTrainProjectCode
            {
                get
                {
                    return GetNodeValue("WXPayConfig/WxTrainProjectCode");
                }
            }
        }

        #endregion

        /// <summary>
        /// 定制活动配置
        /// </summary>
        public static class CustomizeActivityConfig
        {
            public static string ImportPassword
            {
                get
                {
                    return GetNodeValue("CustomizeActivity/ImportPassword");
                }
            }
        }

        public static class WorkOrder
        {
            public static string WorkOrderType
            {
                get
                {
                    return GetNodeValue("WorkOrder/WorkOrderType");
                }
            }

            public static string CreateWorkOrder
            {
                get
                {
                    return GetNodeValue("WorkOrder/CreateWorkOrder");
                }
            }

            public static string WorkOrderList
            {
                get
                {
                    return GetNodeValue("WorkOrder/WorkOrderList");
                }
            }

            public static string DealWorkOrder
            {
                get
                {
                    return GetNodeValue("WorkOrder/DealWorkOrder");
                }
            }

            public static string FinishWorkOrder
            {
                get
                {
                    return GetNodeValue("WorkOrder/FinishWorkOrder");
                }
            }

            public static string WorkOrderListLog
            {
                get
                {
                    return GetNodeValue("WorkOrder/WorkOrderListLog");
                }
            }
        }

        public static class BaiduMap
        {
            public static string BaseUri
            {
                get
                {
                    return GetNodeValue("BaiduMap/BaseUri");
                }
            }

            public static string Ak
            {
                get
                {
                    return GetNodeValue("BaiduMap/Ak");
                }
            }

            public static string Sk
            {
                get
                {
                    return GetNodeValue("BaiduMap/Sk");
                }
            }
        }

        public static class BaiduWuliu
        {
            public static string BaseUri
            {
                get
                {
                    return GetNodeValue("BaiduWuliu/BaseUri");
                }
            }

            public static string AppId
            {
                get
                {
                    return GetNodeValue("BaiduWuliu/AppId");
                }
            }

            public static string AppKey
            {
                get
                {
                    return GetNodeValue("BaiduWuliu/AppKey");
                }
            }
        }

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
        }

        public static class SyncComplainJobConfigs
        {
            public static string BaseUri
            {
                get
                {
                    return GetNodeValue("SyncComplainJobConfigs/BaseUri");
                }
            }

            public static string CheckCode
            {
                get
                {
                    return GetNodeValue("SyncComplainJobConfigs/CheckCode");
                }
            }

            public static string Name
            {
                get
                {
                    return GetNodeValue("SyncComplainJobConfigs/Name");
                }
            }

            public static string Token
            {
                get
                {
                    return GetNodeValue("SyncComplainJobConfigs/Token");
                }
            }
        }

        public static string TrainListSearchUrl
        {
            get
            {
                return GetNodeValue("TrainListSearchUrl");
            }
        }

        /// <summary>
        /// Vip控票相关配置
        /// </summary>
        public static class VipTicketConfig
        {
            public static string QueryUrl
            {
                get
                {
                    return GetNodeValue("VipTicketConfig/QueryUrl");
                }
            }
        }
    }
}
