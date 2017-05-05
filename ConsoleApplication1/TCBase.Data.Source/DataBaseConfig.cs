// Decompiled with JetBrains decompiler
// Type: TCBase.Data.DataBaseConfig
// Assembly: TCBase.Data.Source, Version=1.1.11.1, Culture=neutral, PublicKeyToken=null
// MVID: 85FB40CB-14C5-4BAB-9468-E4846CECFCDB
// Assembly location: D:\MyProject\ConsoleApplication1\ConsoleApplication1\bin\Debug\TCBase.Data.Source.dll

using System;
using System.Collections.Generic;
using System.Linq;

namespace TCBase.Data
{
  internal class DataBaseConfig
  {
    private ConnectionLoadBalance readBalance = (ConnectionLoadBalance) null;
    private ConnectionLoadBalance writeBalance = (ConnectionLoadBalance) null;

    public string Name { get; set; }

    public bool IsDefault { get; set; }

    public List<ConnectionItem> ReadList { get; set; }

    public List<ConnectionItem> WriteList { get; set; }

    public DataBaseConfig()
    {
      this.ReadList = new List<ConnectionItem>();
      this.WriteList = new List<ConnectionItem>();
    }

    internal ConnectionItem GetConnectionItem(bool isRead)
    {
      if (isRead)
      {
        if (this.ReadList.Count < 2)
          return this.ReadList.FirstOrDefault<ConnectionItem>();
        if (this.readBalance == null)
          this.readBalance = new ConnectionLoadBalance((IList<WeightObject>) this.ReadList.Where<ConnectionItem>((Func<ConnectionItem, bool>) (p => p.Enabled)).Select<ConnectionItem, WeightObject>((Func<ConnectionItem, WeightObject>) (p => new WeightObject()
          {
            Index = this.ReadList.IndexOf(p),
            Weights = p.Weight
          })).ToList<WeightObject>());
        return this.ReadList[this.readBalance.LoadWeight.Index];
      }
      if (this.WriteList.Count < 2)
        return this.WriteList.FirstOrDefault<ConnectionItem>();
      if (this.writeBalance == null)
        this.writeBalance = new ConnectionLoadBalance((IList<WeightObject>) this.WriteList.Where<ConnectionItem>((Func<ConnectionItem, bool>) (p => p.Enabled)).Select<ConnectionItem, WeightObject>((Func<ConnectionItem, WeightObject>) (p => new WeightObject()
        {
          Index = this.WriteList.IndexOf(p),
          Weights = p.Weight
        })).ToList<WeightObject>());
      return this.WriteList[this.writeBalance.LoadWeight.Index];
    }
  }
}
