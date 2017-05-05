// Decompiled with JetBrains decompiler
// Type: TCBase.Data.DataSource
// Assembly: TCBase.Data.Source, Version=1.1.11.1, Culture=neutral, PublicKeyToken=null
// MVID: 85FB40CB-14C5-4BAB-9468-E4846CECFCDB
// Assembly location: D:\MyProject\ConsoleApplication1\ConsoleApplication1\bin\Debug\TCBase.Data.Source.dll

using System;
using System.Data;
using System.Data.Common;
using System.Security.Cryptography;
using System.Text;

namespace TCBase.Data
{
  public static class DataSource
  {
    private static ConnStringManager connStringManager = new ConnStringManager();

    public static IDbConnection GetConnection(string name, bool isRead = true)
    {
      ConnectionItem connectionConfig = DataSource.connStringManager.GetConnectionConfig(name, isRead);
      if (connectionConfig == null)
        throw new Exception("数据库名称" + name + "在数据库配置中未找到,请检查数据库配置文件或联系DBA!");
      DbProviderFactory factory = DbProviderFactories.GetFactory(connectionConfig.Provider ?? "System.Data.SqlClient");
      if (factory == null)
        throw new Exception("数据库驱动名称" + connectionConfig.Provider + "无法初始化,请检查数据库驱动是否正常!");
      DbConnection connection = factory.CreateConnection();
      if (connectionConfig.Encrypt)
      {
        int num = connectionConfig.ConnectionString.IndexOf("password=", 0, connectionConfig.ConnectionString.Length, StringComparison.CurrentCultureIgnoreCase) + 9;
        int startIndex = connectionConfig.ConnectionString.IndexOf(';', num, connectionConfig.ConnectionString.Length - num);
        string toDecrypt = connectionConfig.ConnectionString.Substring(num, startIndex - num);
        string str = connectionConfig.ConnectionString.Substring(0, num) + Pwd.Decrypt(toDecrypt, DataSource.GetPwdKey()) + connectionConfig.ConnectionString.Substring(startIndex, connectionConfig.ConnectionString.Length - startIndex);
        connection.ConnectionString = str;
      }
      else
        connection.ConnectionString = connectionConfig.ConnectionString;
      return (IDbConnection) new TCDbConnection(connection)
      {
        CommandTimeout = connectionConfig.CommandTimeOut,
        Provider = connectionConfig.Provider
      };
    }

    internal static string GetPwdKey()
    {
      string appName = AppProfile.AppName;
      if (appName.Length < 16)
        return appName.PadRight(16, '0');
      return appName.Substring(0, 16);
    }

    internal static string Decrypt(string toDecrypt, string key)
    {
      byte[] bytes = Encoding.UTF8.GetBytes(key);
      byte[] inputBuffer = Convert.FromBase64String(toDecrypt);
      RijndaelManaged rijndaelManaged = new RijndaelManaged();
      rijndaelManaged.Key = bytes;
      rijndaelManaged.Mode = CipherMode.ECB;
      rijndaelManaged.Padding = PaddingMode.PKCS7;
      return Encoding.UTF8.GetString(rijndaelManaged.CreateDecryptor().TransformFinalBlock(inputBuffer, 0, inputBuffer.Length));
    }

    internal static bool IsExist(string dbName)
    {
      return DataSource.connStringManager.Exist(dbName);
    }
  }
}
