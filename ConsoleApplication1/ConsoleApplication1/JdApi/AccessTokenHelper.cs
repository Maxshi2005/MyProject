using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TC.Train.OTS.OutService.JdApi
{
    public static class AccessTokenHelper
    {
        public static string GetJdToken()
        {
            //ICacheStorage cache = new RedisStorage();
            //var token = cache.GetStringValue(CacheKeyManager.JdAccessToken);
            //if (!string.IsNullOrEmpty(token))
            //    return token;

            //ITrainJdAccessTokenRepository tokenRepository = new TrainJdAccessTokenRepository();
            //var tokenEntity = tokenRepository.GetLatestToken();
            //if(tokenEntity != null && !string.IsNullOrEmpty(tokenEntity.TATAccessToken))
            //{
            //    token = tokenEntity.TATAccessToken;
            //    cache.SetStringValue(CacheKeyManager.JdAccessToken, token, new TimeSpan(0, 20, 0));
            //}
            return "c1ab9c1c-7646-4abd-aefd-f2d06bbc9ce0";
        }

        public static void ClearJdTokenCache()
        {
            
        }
    }
}
