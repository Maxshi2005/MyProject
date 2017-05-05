// Decompiled with JetBrains decompiler
// Type: TCBase.Data.TCDbCommand
// Assembly: TCBase.Data.Source, Version=1.1.11.1, Culture=neutral, PublicKeyToken=null
// MVID: 85FB40CB-14C5-4BAB-9468-E4846CECFCDB
// Assembly location: D:\MyProject\ConsoleApplication1\ConsoleApplication1\bin\Debug\TCBase.Data.Source.dll

using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using TCBase.ComponentLog;

namespace TCBase.Data
{
  public class TCDbCommand : DbCommand
  {
    private static BlockingCollection<string> traceQueue = new BlockingCollection<string>();
    private readonly DbCommand innerCmd;

    public override string CommandText
    {
      get
      {
        return this.innerCmd.CommandText;
      }
      set
      {
        this.innerCmd.CommandText = value;
      }
    }

    public override int CommandTimeout
    {
      get
      {
        return this.innerCmd.CommandTimeout;
      }
      set
      {
        this.innerCmd.CommandTimeout = value;
      }
    }

    public override CommandType CommandType
    {
      get
      {
        return this.innerCmd.CommandType;
      }
      set
      {
        this.innerCmd.CommandType = value;
      }
    }

    public override UpdateRowSource UpdatedRowSource
    {
      get
      {
        return this.innerCmd.UpdatedRowSource;
      }
      set
      {
        this.innerCmd.UpdatedRowSource = value;
      }
    }

    protected override DbConnection DbConnection
    {
      get
      {
        return this.innerCmd.Connection;
      }
      set
      {
        this.innerCmd.Connection = value;
      }
    }

    protected override DbParameterCollection DbParameterCollection
    {
      get
      {
        object innerCmd = (object) this.innerCmd;
        if (TCDbCommand.\u003C\u003Eo__21.\u003C\u003Ep__1 == null)
          TCDbCommand.\u003C\u003Eo__21.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, DbParameterCollection>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (DbParameterCollection), typeof (TCDbCommand)));
        Func<CallSite, object, DbParameterCollection> target = TCDbCommand.\u003C\u003Eo__21.\u003C\u003Ep__1.Target;
        CallSite<Func<CallSite, object, DbParameterCollection>> p1 = TCDbCommand.\u003C\u003Eo__21.\u003C\u003Ep__1;
        if (TCDbCommand.\u003C\u003Eo__21.\u003C\u003Ep__0 == null)
          TCDbCommand.\u003C\u003Eo__21.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "Parameters", typeof (TCDbCommand), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        object obj = TCDbCommand.\u003C\u003Eo__21.\u003C\u003Ep__0.Target((CallSite) TCDbCommand.\u003C\u003Eo__21.\u003C\u003Ep__0, innerCmd);
        return target((CallSite) p1, obj);
      }
    }

    protected override DbTransaction DbTransaction
    {
      get
      {
        object innerCmd = (object) this.innerCmd;
        if (TCDbCommand.\u003C\u003Eo__23.\u003C\u003Ep__1 == null)
          TCDbCommand.\u003C\u003Eo__23.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, DbTransaction>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (DbTransaction), typeof (TCDbCommand)));
        Func<CallSite, object, DbTransaction> target = TCDbCommand.\u003C\u003Eo__23.\u003C\u003Ep__1.Target;
        CallSite<Func<CallSite, object, DbTransaction>> p1 = TCDbCommand.\u003C\u003Eo__23.\u003C\u003Ep__1;
        if (TCDbCommand.\u003C\u003Eo__23.\u003C\u003Ep__0 == null)
          TCDbCommand.\u003C\u003Eo__23.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "Transaction", typeof (TCDbCommand), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        object obj = TCDbCommand.\u003C\u003Eo__23.\u003C\u003Ep__0.Target((CallSite) TCDbCommand.\u003C\u003Eo__23.\u003C\u003Ep__0, innerCmd);
        return target((CallSite) p1, obj);
      }
      set
      {
        this.innerCmd.Transaction = value;
      }
    }

    public override bool DesignTimeVisible
    {
      get
      {
        return this.innerCmd.DesignTimeVisible;
      }
      set
      {
        this.innerCmd.DesignTimeVisible = value;
      }
    }

    static TCDbCommand()
    {
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated method
      Task.Factory.StartNew(new Action(TCDbCommand.\u003C\u003Ec.\u003C\u003E9.\u003C\u002Ecctor\u003Eb__2_0));
    }

    public TCDbCommand(DbCommand cmd)
    {
      this.innerCmd = cmd;
    }

    public override void Prepare()
    {
      this.innerCmd.Prepare();
    }

    public override void Cancel()
    {
      this.innerCmd.Cancel();
    }

    protected override DbParameter CreateDbParameter()
    {
      object innerCmd = (object) this.innerCmd;
      // ISSUE: reference to a compiler-generated field
      if (TCDbCommand.\u003C\u003Eo__29.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        TCDbCommand.\u003C\u003Eo__29.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, DbParameter>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (DbParameter), typeof (TCDbCommand)));
      }
      // ISSUE: reference to a compiler-generated field
      Func<CallSite, object, DbParameter> target = TCDbCommand.\u003C\u003Eo__29.\u003C\u003Ep__1.Target;
      // ISSUE: reference to a compiler-generated field
      CallSite<Func<CallSite, object, DbParameter>> p1 = TCDbCommand.\u003C\u003Eo__29.\u003C\u003Ep__1;
      // ISSUE: reference to a compiler-generated field
      if (TCDbCommand.\u003C\u003Eo__29.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        TCDbCommand.\u003C\u003Eo__29.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "CreateParameter", (IEnumerable<Type>) null, typeof (TCDbCommand), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj = TCDbCommand.\u003C\u003Eo__29.\u003C\u003Ep__0.Target((CallSite) TCDbCommand.\u003C\u003Eo__29.\u003C\u003Ep__0, innerCmd);
      return target((CallSite) p1, obj);
    }

    protected override DbDataReader ExecuteDbDataReader(CommandBehavior behavior)
    {
      return TCDbCommand.RecordLog<DbDataReader>((Func<DbDataReader>) (() => this.innerCmd.ExecuteReader(behavior)), (IDbCommand) this.innerCmd);
    }

    public override int ExecuteNonQuery()
    {
      return TCDbCommand.RecordLog<int>((Func<int>) (() => this.innerCmd.ExecuteNonQuery()), (IDbCommand) this.innerCmd);
    }

    public override object ExecuteScalar()
    {
      return TCDbCommand.RecordLog<object>((Func<object>) (() => this.innerCmd.ExecuteScalar()), (IDbCommand) this.innerCmd);
    }

    private static T RecordLog<T>(Func<T> func, IDbCommand cmd)
    {
      T obj = default (T);
      try
      {
        IDbCommand dbCommand = cmd;
        string str1 = dbCommand.CommandText + " /* ProductName:" + AppProfile.AppName + "*/ ";
        dbCommand.CommandText = str1;
        while (TCDbCommand.traceQueue.Count > 100)
        {
          string str2;
          TCDbCommand.traceQueue.TryTake(out str2);
        }
        TCDbCommand.traceQueue.Add(cmd.CommandText);
        return func();
      }
      catch (Exception ex)
      {
        Exception baseException = ex.GetBaseException();
        Log.LogMessage("TCBase.Data", "数据库日志记录", LogType.Error, false, baseException, (object) null);
        throw baseException;
      }
    }
  }
}
