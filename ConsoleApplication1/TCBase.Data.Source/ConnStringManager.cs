// Decompiled with JetBrains decompiler
// Type: TCBase.Data.ConnStringManager
// Assembly: TCBase.Data.Source, Version=1.1.11.1, Culture=neutral, PublicKeyToken=null
// MVID: 85FB40CB-14C5-4BAB-9468-E4846CECFCDB
// Assembly location: D:\MyProject\ConsoleApplication1\ConsoleApplication1\bin\Debug\TCBase.Data.Source.dll

using System;
using System.Collections.Generic;
using System.Linq;
using TCBase.ComponentLog;
using TCBase.Config;

namespace TCBase.Data
{
  internal class ConnStringManager
  {
    private ConnectionConfig cache;

    public ConnStringManager()
    {
      if (this.cache == null)
      {
        string xml = ConfigCenterClient.Get("TCBase.Data");
        try
        {
          this.cache = ConfigConvert.XmlToConfig(xml);
        }
        catch (Exception ex)
        {
          Log.LogMessage("TCBase.Data", "数据库配置文件转换失败", LogType.Error, true, ex, (object) new
          {
            configInfo = xml
          });
        }
      }
      ConfigCenterClient.ConfigChanged += new EventHandler<ConfigDataEventArgs>(this.ConfigCenterClient_ConfigChanged);
    }

    internal ConnectionItem GetConnectionConfig(string name, bool isRead)
    {
      DataBaseConfig dataBaseConfig = this.cache.DataBaseList.FirstOrDefault<DataBaseConfig>((Func<DataBaseConfig, bool>) (p => p.Name == name));
      if (dataBaseConfig == null)
        return (ConnectionItem) null;
      ConnectionItem connectionItem = dataBaseConfig.GetConnectionItem(isRead);
      if (connectionItem == null)
        throw new Exception("无法找到匹配的数据库连接,请求的数据库是" + name + ",请求的数据库类型为" + (isRead ? "读库" : "写库"));
      return connectionItem;
    }

    private void ConfigCenterClient_ConfigChanged(object sender, ConfigDataEventArgs e)
    {
      if (!e.ConfigChangeDictionary.ContainsKey(AppProfile.AppName))
        return;
      List<ConfigData> addList = e.ConfigChangeDictionary[AppProfile.AppName].AddList;
      Predicate<ConfigData> predicate1 = (Predicate<ConfigData>) (p => p.Key == "TCBase.Data");
      Predicate<ConfigData> match1;
      if (addList.Exists(match1))
        this.UploadCache(ConfigCenterClient.Get("TCBase.Data"));
      List<ConfigData> updateList = e.ConfigChangeDictionary[AppProfile.AppName].UpdateList;
      Predicate<ConfigData> predicate2 = (Predicate<ConfigData>) (p => p.Key == "TCBase.Data");
      Predicate<ConfigData> match2;
      if (updateList.Exists(match2))
        this.UploadCache(ConfigCenterClient.Get("TCBase.Data"));
    }

    private void UploadCache(string str)
    {
      try
      {
        this.cache = ConfigConvert.XmlToConfig(str);
      }
      catch (Exception ex)
      {
        Log.LogMessage("TCBase.Data", "数据库配置文件转换失败", LogType.Error, true, ex, (object) new
        {
          configInfo = str
        });
      }
    }

    internal bool Exist(string dbName)
    {
      return this.cache.DataBaseList.Any<DataBaseConfig>((Func<DataBaseConfig, bool>) (p => string.Equals(p.Name, dbName, StringComparison.CurrentCultureIgnoreCase)));
    }
  }
}
