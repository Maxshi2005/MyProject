// Decompiled with JetBrains decompiler
// Type: TCBase.Data.ConnectionConfig
// Assembly: TCBase.Data.Source, Version=1.1.11.1, Culture=neutral, PublicKeyToken=null
// MVID: 85FB40CB-14C5-4BAB-9468-E4846CECFCDB
// Assembly location: D:\MyProject\ConsoleApplication1\ConsoleApplication1\bin\Debug\TCBase.Data.Source.dll

using System.Collections.Generic;

namespace TCBase.Data
{
  internal class ConnectionConfig
  {
    public string Name { get; set; }

    public List<DataBaseConfig> DataBaseList { get; set; }

    public ConnectionConfig()
    {
      this.DataBaseList = new List<DataBaseConfig>();
    }
  }
}
