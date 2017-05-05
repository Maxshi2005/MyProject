using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TC.Train.OTS.OutService.JdApi.AccessToken
{
    public class GetAccessTokenResponse
    {
        public string access_token { get; set; }
        public int code { get; set; }
        public int expires_in { get; set; }
        public string refresh_token { get; set; }
        public string time { get; set; }
        public string token_type { get; set; }
        public string uid { get; set; }
        public string user_nick { get; set; }
        public string error_description { get; set; }
    }
}
