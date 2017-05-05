using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Interface
{
   public interface IConfiguration
    {
        string GetConfig(string key);

        string GetConfigWithDefault(string key,string defaultValue);

        T GetConfig<T>(string key);

        T GetConfigWithDefault<T>(string key, string defaultValue);
    }
}
