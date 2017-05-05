using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TC.Train.OTS.OutService.JdApi;

namespace ConsoleApplication1.Others
{
    public class AddressValidateRequest : IJdRequest
    {
       

        public string CustomerCode { get; set; }
        public string WareHouseCode { get; set; }
        public int GoodsType { get; set; }

        public string ReceiveAddress { get; set; }

        public string OrderId { get; set; }

        public string GetApiName()
        {
            return "jingdong.etms.range.check";
        }
    }
}
