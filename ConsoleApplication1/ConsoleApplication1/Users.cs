﻿using System;

namespace ConsoleApplication1
{
    internal class Users
    {
        /// <summary>
        /// 自增编号
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// 订单ID
        /// </summary>
        public long OrderId { get; set; }
        /// <summary>
        /// 订单流水号
        /// </summary>
        public string OrderSerialId { get; set; }
        /// <summary>
        /// 应付总额（=票价+保险+邮寄费- 抵用券）
        /// </summary>
        public decimal CustShouldPayTotal { get; set; }
        /// <summary>
        /// 应付票价
        /// </summary>
        public decimal CustShouldPayTicketPrice { get; set; }
        /// <summary>
        /// 应付保险
        /// </summary>
        public decimal CustShouldPayInsuranceFee { get; set; }
        /// <summary>
        /// 应付邮寄费
        /// </summary>
        public decimal CustShouldPayMailFee { get; set; }
        /// <summary>
        /// 抵用券金额
        /// </summary>
        public decimal CustShouldPayVoucher { get; set; }
        /// <summary>
        /// 实付总额
        /// </summary>
        public decimal CustReallyPayAmount { get; set; }
        /// <summary>
        /// 实付支付方式：1暂存单支付, 2银行转账, 3支付宝支付, 4快钱在线支付, 5环讯在线支付, 6易联手机支付, 7财付通支付, 8招行专线支付, 9银联在线支付, 10浦发专线支付, 11交行专线支付, 12银行直连, 13"支付宝无卡支付, 14信用卡支付
        /// </summary>
        public int CustReallyPayPaymentType { get; set; }
        /// <summary>
        /// 实付交易号
        /// </summary>
        public string CustReallyPayTradeNo { get; set; }
        /// <summary>
        /// 公共开发的交易流水号
        /// </summary>
        public string RTCSerialId { get; set; }
        /// <summary>
        /// 未知=0 网银直连 = 1,电话支付 = 2,短信支付 = 4,信用卡卡号支付 = 8,网关支付 = 16,同程礼品卡 = 100
        /// </summary>
        public int BasePayType { get; set; }
        /// <summary>
        /// 公共支付交易类型：10网关类交易；20信用卡类交易； 0 未知
        /// </summary>
        public int PayType { get; set; }
        /// <summary>
        /// 0 未知 10 支付宝(ALI)20 快钱(CNP)30 环讯(IPS)40 易联(DNA)50 财付通(TEN)60 招行专线(CMB)70 银联(CUP)80 浦发(SPD)90 交行专线(BOC)100 南京银行110 交行乐园
        /// </summary>
        public int ChannelId { get; set; }
        /// <summary>
        /// 20—支付成功30—支付失败
        /// </summary>
        public int PayCode { get; set; }
        /// <summary>
        /// 客人的付款状态（0否 1是）
        /// </summary>
        public int IsClientClear { get; set; }
        /// <summary>
        /// 成功支付时间
        /// </summary>
        public DateTime RCustReallyPaySucessTime { get; set; }
        /// <summary>
        /// 记录创建人
        /// </summary>
        public string Creator { get; set; }
        /// <summary>
        /// 创建人ID
        /// </summary>
        public int CreatorId { get; set; }
        /// <summary>
        /// 记录创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 最后一次更新时间
        /// </summary>
        public DateTime LastUpdateDate { get; set; }
        /// <summary>
        /// 业务系统对应财务记录表的Id记录
        /// </summary>
        public int RecordId { get; set; }
        /// <summary>
        /// 同步财务状态（0 未同步 1已同步）
        /// </summary>
        public int SyncFinanceState { get; set; }
        /// <summary>
        /// 订单来源
        /// </summary>
        public string TrainChannel { get; set; }
        /// <summary>
        /// 对应订单的TC号
        /// </summary>
        public string OrderSerialNumber { get; set; }
        /// <summary>
        /// 红包Id
        /// </summary>
        public string RedSerialId { get; set; }
        /// <summary>
        /// 老订单流水号
        /// </summary>
        public string ROldOrderSerialId { get; set; }
        /// <summary>
        /// 老订单供应商流水号
        /// </summary>
        public string ROldOrderSerialNumber { get; set; }
        /// <summary>
        /// 订单类型0=正常;1=改签后金额大;2=改签后金额小;3=改签后金额不变
        /// </summary>
        public byte ROrderType { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public string ROrderFlag { get; set; }
        /// <summary>
        /// 乘客状态
        /// </summary>
        public string RPassenger { get; set; }
        /// <summary>
        /// 票状态
        /// </summary>
        public string RTicketState { get; set; }
        /// <summary>
        /// 分销模式 0=正常订单 1=后结模式
        /// </summary>
        public int Distributor { get; set; }
        /// <summary>
        /// 外部流水号
        /// </summary>
        public string DistributorOrderNumber { get; set; }
        /// <summary>
        /// 分销商名称
        /// </summary>
        public string DistributorName { get; set; }
        /// <summary>
        /// 客人支付的手续费
        /// </summary>
        public decimal TicketFee { get; set; }
        /// <summary>
        /// 订单平台来源 0-默认 1-CN站 2-COM站 3-安卓(Old) 4-IOS(Old) 518-Touch站(Old) 434-安卓 433-IOS 432-Touch 501-微信火车票 577-葡萄网 596-手Q 580-WindowsPhone 625-火车票供应商回调测试
        /// </summary>
        public int RPlatId { get; set; }
        /// <summary>
        /// 联合单号(保险分账用)
        /// </summary>
        public string RUnionSerialId { get; set; }
        /// <summary>
        /// 是否重复支付 0：正常支付 1：重复支付
        /// </summary>
        public byte RIsRepeatPay { get; set; }
        /// <summary>
        /// 支付单类型 0：普通支付单、分账支付产品单 1：分账支付保险单
        /// </summary>
        public byte RPayOrderType { get; set; }
        /// <summary>
        /// 改签前订单号(拆分前原订单的)
        /// </summary>
        public string OldSerialId { get; set; }
        /// <summary>
        /// 改签前供应商流水(TC号拆分前原订单的)
        /// </summary>
        public string OldSupplyId { get; set; }
        /// <summary>
        /// 拆单状态 0=不拆单;1=拆单原单;2=拆单新单
        /// </summary>
        public byte ChangeState { get; set; }
        /// <summary>
        /// 酒店代金券金额
        /// </summary>
        public decimal HotelActivity { get; set; }
        /// <summary>
        /// 支付项目编码
        /// </summary>
        public int ProjectCode { get; set; }
        /// <summary>
        /// 活动立减金额(用于第三方补贴)
        /// </summary>
        public decimal ActiveMinusAmount { get; set; }
        /// <summary>
        /// 乘客姓名扩展
        /// </summary>
        public string RPassengerExpand { get; set; }
        /// <summary>
        /// 套餐费用
        /// </summary>
        public decimal RPackageService { get; set; }
        /// <summary>
        /// 应付抢票加速券费用
        /// </summary>
        public decimal ShouldPayGrabCouponFee { get; set; }
        /// <summary>
        /// Guid唯一值
        /// </summary>
        public string RGuidSer { get; set; }
        /// <summary>
        /// 同步失败次数
        /// </summary>
        public int FailCount { get; set; }
        /// <summary>
        /// 退改无忧类型：0：默认；1：退票险；2：退改无忧
        /// </summary>
        public int BackNoWorryType { get; set; }
        /// <summary>
        /// 退票险或退改无忧金额
        /// </summary>
        public decimal BackNoWorryAmount { get; set; }
    }



    public class Test
    {
    }
}