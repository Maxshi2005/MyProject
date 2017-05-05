using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TC.Train.OTS.OutService.JdApi;

namespace ConsoleApplication1.Others
{
    public class JDAdressValidate
    {
       static string JdUrl = @"http://jos.jd.com/api/detail.htm?apiName=jingdong.etms.range.check&id=1023" + "&customerCode=021K71606"
            + "&wareHouseCode=270" + "&goodsType=1" + "&receiveAddress=苏州市平江区车站路57号" + "&OrderId=" + Guid.NewGuid().ToString("N");

        public static void Run()
        {
            JdClient client = new JdClient();

            AddressValidateRequest request = new Others.AddressValidateRequest()
            {
                CustomerCode = "021K71606",
                 GoodsType = 1,
                 OrderId = Guid.NewGuid().ToString("N"),
                 ReceiveAddress = "江苏省苏州市平江区车站路57号",
                  WareHouseCode = "270"
            };

           var _billSendResponse = client.Execute<AddressValidateRequest, AddressValidateResponse>(request);
        }

    }



}
