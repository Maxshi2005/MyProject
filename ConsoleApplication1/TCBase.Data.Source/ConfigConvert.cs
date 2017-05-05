// Decompiled with JetBrains decompiler
// Type: TCBase.Data.ConfigConvert
// Assembly: TCBase.Data.Source, Version=1.1.11.1, Culture=neutral, PublicKeyToken=null
// MVID: 85FB40CB-14C5-4BAB-9468-E4846CECFCDB
// Assembly location: D:\MyProject\ConsoleApplication1\ConsoleApplication1\bin\Debug\TCBase.Data.Source.dll

using System;
using System.IO;
using System.Xml.Linq;

namespace TCBase.Data
{
  internal static class ConfigConvert
  {
    public static string ConfigToXml(ConnectionConfig config)
    {
      XElement xelement1 = new XElement((XName) "tcbase.dataAccess", (object) new XAttribute((XName) "name", (object) config.Name));
      foreach (DataBaseConfig dataBase in config.DataBaseList)
      {
        XElement xelement2 = new XElement((XName) "database");
        xelement1.Add((object) xelement2);
        xelement2.Add((object) new XAttribute((XName) "name", (object) dataBase.Name));
        xelement2.Add((object) new XAttribute((XName) "default", dataBase.IsDefault ? (object) "true" : (object) "false"));
        XElement xelement3 = new XElement((XName) "read");
        xelement2.Add((object) xelement3);
        XElement xelement4 = new XElement((XName) "write");
        xelement2.Add((object) xelement4);
        foreach (ConnectionItem read in dataBase.ReadList)
        {
          XElement xelement5 = new XElement((XName) "server");
          xelement3.Add((object) xelement5);
          xelement5.Add((object) new XAttribute((XName) "enabled", read.Enabled ? (object) "true" : (object) "false"));
          xelement5.Add((object) new XAttribute((XName) "encrypt", read.Encrypt ? (object) "true" : (object) "false"));
          if ((uint) read.Weight > 0U)
            xelement5.Add((object) new XAttribute((XName) "weight", (object) read.Weight));
          xelement5.Add((object) new XAttribute((XName) "connectionString", (object) read.ConnectionString));
          if ((uint) read.CommandTimeOut > 0U)
            xelement5.Add((object) new XAttribute((XName) "commandTimeOut", (object) read.CommandTimeOut));
        }
        foreach (ConnectionItem write in dataBase.WriteList)
        {
          XElement xelement5 = new XElement((XName) "server");
          xelement4.Add((object) xelement5);
          xelement5.Add((object) new XAttribute((XName) "enabled", write.Enabled ? (object) "true" : (object) "false"));
          xelement5.Add((object) new XAttribute((XName) "encrypt", write.Encrypt ? (object) "true" : (object) "false"));
          if ((uint) write.Weight > 0U)
            xelement5.Add((object) new XAttribute((XName) "weight", (object) write.Weight));
          xelement5.Add((object) new XAttribute((XName) "connectionString", (object) write.ConnectionString));
          if ((uint) write.CommandTimeOut > 0U)
            xelement5.Add((object) new XAttribute((XName) "commandTimeOut", (object) write.CommandTimeOut));
        }
      }
      XDocument xdocument = new XDocument(new object[1]
      {
        (object) xelement1
      });
      StringWriter stringWriter = new StringWriter();
      xdocument.Save((TextWriter) stringWriter);
      return stringWriter.GetStringBuilder().ToString();
    }

    public static ConnectionConfig XmlToConfig(string xml)
    {
      ConnectionConfig connectionConfig = new ConnectionConfig();
      XElement xelement1 = XDocument.Load((TextReader) new StringReader(xml)).Element((XName) "tcbase.dataAccess");
      if (xelement1 == null)
        return connectionConfig;
      XAttribute xattribute1 = xelement1.Attribute((XName) "name");
      if (xattribute1 != null)
        connectionConfig.Name = xattribute1.Value;
      foreach (XElement element1 in xelement1.Elements((XName) "database"))
      {
        DataBaseConfig dataBaseConfig = new DataBaseConfig();
        connectionConfig.DataBaseList.Add(dataBaseConfig);
        XAttribute xattribute2 = element1.Attribute((XName) "name");
        if (xattribute2 != null)
          dataBaseConfig.Name = xattribute2.Value;
        XAttribute xattribute3 = element1.Attribute((XName) "default");
        if (xattribute3 != null)
          dataBaseConfig.IsDefault = !(xattribute3.Value == "false");
        XElement xelement2 = element1.Element((XName) "read");
        if (xelement2 != null)
        {
          foreach (XElement element2 in xelement2.Elements((XName) "server"))
          {
            ConnectionItem connectionItem = new ConnectionItem();
            dataBaseConfig.ReadList.Add(connectionItem);
            XAttribute xattribute4 = element2.Attribute((XName) "enabled");
            if (xattribute4 != null)
              connectionItem.Enabled = !(xattribute4.Value.ToLower() == "false");
            XAttribute xattribute5 = element2.Attribute((XName) "encrypt");
            connectionItem.Encrypt = xattribute5 == null || !(xattribute5.Value.ToLower() == "false");
            XAttribute xattribute6 = element2.Attribute((XName) "weight");
            if (xattribute6 != null)
              connectionItem.Weight = Convert.ToInt32(xattribute6.Value);
            XAttribute xattribute7 = element2.Attribute((XName) "connectionString");
            if (xattribute7 != null)
              connectionItem.ConnectionString = xattribute7.Value;
            XAttribute xattribute8 = element2.Attribute((XName) "commandTimeOut");
            if (xattribute8 != null)
              connectionItem.CommandTimeOut = Convert.ToInt32(xattribute8.Value);
            XAttribute xattribute9 = element2.Attribute((XName) "provider");
            if (xattribute9 != null)
              connectionItem.Provider = xattribute9.Value;
          }
        }
        XElement xelement3 = element1.Element((XName) "write");
        if (xelement3 != null)
        {
          foreach (XElement element2 in xelement3.Elements((XName) "server"))
          {
            ConnectionItem connectionItem = new ConnectionItem();
            dataBaseConfig.WriteList.Add(connectionItem);
            XAttribute xattribute4 = element2.Attribute((XName) "enabled");
            if (xattribute4 != null)
              connectionItem.Enabled = !(xattribute4.Value == "false");
            XAttribute xattribute5 = element2.Attribute((XName) "encrypt");
            connectionItem.Encrypt = xattribute5 == null || !(xattribute5.Value == "false");
            XAttribute xattribute6 = element2.Attribute((XName) "weight");
            if (xattribute6 != null)
              connectionItem.Weight = Convert.ToInt32(xattribute6.Value);
            XAttribute xattribute7 = element2.Attribute((XName) "connectionString");
            if (xattribute7 != null)
              connectionItem.ConnectionString = xattribute7.Value;
            XAttribute xattribute8 = element2.Attribute((XName) "commandTimeOut");
            if (xattribute8 != null)
              connectionItem.CommandTimeOut = Convert.ToInt32(xattribute8.Value);
            XAttribute xattribute9 = element2.Attribute((XName) "provider");
            if (xattribute9 != null)
              connectionItem.Provider = xattribute9.Value;
          }
        }
      }
      return connectionConfig;
    }
  }
}
