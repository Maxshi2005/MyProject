// Decompiled with JetBrains decompiler
// Type: TCBase.Data.DatabaseLogInfo
// Assembly: TCBase.Data.Source, Version=1.1.11.1, Culture=neutral, PublicKeyToken=null
// MVID: 85FB40CB-14C5-4BAB-9468-E4846CECFCDB
// Assembly location: D:\MyProject\ConsoleApplication1\ConsoleApplication1\bin\Debug\TCBase.Data.Source.dll

namespace TCBase.Data
{
  public class DatabaseLogInfo
  {
    private string version;

    public string SQL { get; set; }

    public string ConnString { get; set; }

    public bool Read { get; set; }

    public long ElapsedMilliseconds { get; set; }

    public string Version
    {
      get
      {
        if (string.IsNullOrWhiteSpace(this.version))
          this.version = this.GetType().Assembly.GetName().Version.ToString();
        return this.version;
      }
    }

    public string Field { get; set; }
  }
}
