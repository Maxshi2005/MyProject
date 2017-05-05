// Decompiled with JetBrains decompiler
// Type: TCBase.Data.ConnectionLoadBalance
// Assembly: TCBase.Data.Source, Version=1.1.11.1, Culture=neutral, PublicKeyToken=null
// MVID: 85FB40CB-14C5-4BAB-9468-E4846CECFCDB
// Assembly location: D:\MyProject\ConsoleApplication1\ConsoleApplication1\bin\Debug\TCBase.Data.Source.dll

using System;
using System.Collections.Generic;
using System.Linq;

namespace TCBase.Data
{
  internal class ConnectionLoadBalance
  {
    private readonly object locker = new object();
    private IList<WeightObject> weightList;
    public int currentIndex;
    private int currentWeight;
    private int maxWeight;
    private int gcd;

    public WeightObject LoadWeight
    {
      get
      {
        lock (this.locker)
        {
          WeightObject local_2 = this.RoundRobin();
          if (local_2 != null)
            return local_2;
          return this.weightList[0];
        }
      }
    }

    public IList<WeightObject> WeightList
    {
      get
      {
        return this.weightList;
      }
    }

    public ConnectionLoadBalance(IList<WeightObject> weightList)
    {
      this.currentIndex = -1;
      this.currentWeight = 0;
      this.weightList = weightList;
      this.RebuildWeight();
      this.maxWeight = this.GetMaxWeight();
      this.gcd = this.GetMaxGCD();
    }

    private void RebuildWeight()
    {
      int num1 = this.weightList.Count<WeightObject>((Func<WeightObject, bool>) (x => x.Weights == 0));
      int num2 = 100 - this.weightList.Sum<WeightObject>((Func<WeightObject, int>) (x => x.Weights));
      foreach (WeightObject weight in (IEnumerable<WeightObject>) this.weightList)
        weight.Weights = num1 == 0 ? weight.Weights : (weight.Weights == 0 ? num2 : weight.Weights * num1);
    }

    private int GetMaxGCD()
    {
      ((List<WeightObject>) this.weightList).Sort((IComparer<WeightObject>) new ConnectionLoadBalance.WeightCompare());
      int weights = this.weightList[0].Weights;
      int num = 1;
      for (int index = 1; index < weights; ++index)
      {
        bool flag = true;
        foreach (WeightObject weight in (IEnumerable<WeightObject>) this.weightList)
        {
          if ((uint) (weight.Weights % index) > 0U)
          {
            flag = false;
            break;
          }
        }
        if (flag)
          num = index;
      }
      return num;
    }

    private int GetMaxWeight()
    {
      int num = 0;
      foreach (WeightObject weight in (IEnumerable<WeightObject>) this.weightList)
      {
        if (num < weight.Weights)
          num = weight.Weights;
      }
      return num;
    }

    private WeightObject RoundRobin()
    {
      do
      {
        this.currentIndex = (this.currentIndex + 1) % this.weightList.Count;
        if (this.currentIndex == 0)
        {
          this.currentWeight = this.currentWeight - this.gcd;
          if (0 >= this.currentWeight)
          {
            this.currentWeight = this.maxWeight;
            if (this.currentWeight == 0)
              goto label_3;
          }
        }
      }
      while (this.weightList[this.currentIndex].Weights < this.currentWeight);
      goto label_6;
label_3:
      return (WeightObject) null;
label_6:
      return this.weightList[this.currentIndex];
    }

    private class WeightCompare : IComparer<WeightObject>
    {
      public int Compare(WeightObject x, WeightObject y)
      {
        return x.Weights - y.Weights;
      }
    }
  }
}
