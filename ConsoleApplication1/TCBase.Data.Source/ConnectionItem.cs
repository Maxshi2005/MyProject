// Decompiled with JetBrains decompiler
// Type: TCBase.Data.ConnectionItem
// Assembly: TCBase.Data.Source, Version=1.1.11.1, Culture=neutral, PublicKeyToken=null
// MVID: 85FB40CB-14C5-4BAB-9468-E4846CECFCDB
// Assembly location: D:\MyProject\ConsoleApplication1\ConsoleApplication1\bin\Debug\TCBase.Data.Source.dll

namespace TCBase.Data
{
  internal class ConnectionItem
  {
    public string ConnectionString { get; set; }

    public string Provider { get; set; }

    public bool Enabled { get; set; }

    public bool Encrypt { get; set; }

    public int Weight { get; set; }

    public int CommandTimeOut { get; set; }
  }
}
