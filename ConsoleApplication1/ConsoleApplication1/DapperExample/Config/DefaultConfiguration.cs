using ConsoleApplication1.Interface;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;

namespace ConsoleApplication1.Config
{
  public  class DefaultConfiguration : IConfiguration
    {
        public static DefaultConfiguration Instance = new DefaultConfiguration();

        private DefaultConfiguration() { }
        

        public string GetConfig(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        public T GetConfig<T>(string key)
        {
            throw new NotImplementedException();
        }

        public string GetConfigWithDefault(string key, string defaultValue)
        {
            throw new NotImplementedException();
        }

        public T GetConfigWithDefault<T>(string key, string defaultValue)
        {
            throw new NotImplementedException();
        }
    }
}
