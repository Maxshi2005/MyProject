// Decompiled with JetBrains decompiler
// Type: TCBase.Data.TCDbConnection
// Assembly: TCBase.Data.Source, Version=1.1.11.1, Culture=neutral, PublicKeyToken=null
// MVID: 85FB40CB-14C5-4BAB-9468-E4846CECFCDB
// Assembly location: D:\MyProject\ConsoleApplication1\ConsoleApplication1\bin\Debug\TCBase.Data.Source.dll

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace TCBase.Data
{
  public class TCDbConnection : DbConnection, IDbConnectionProperty
  {
    private DbConnection innerConnection;

    public override string Database
    {
      get
      {
        return this.innerConnection.Database;
      }
    }

    public override string DataSource
    {
      get
      {
        return this.innerConnection.DataSource;
      }
    }

    public override string ServerVersion
    {
      get
      {
        return this.innerConnection.ServerVersion;
      }
    }

    public override ConnectionState State
    {
      get
      {
        return this.innerConnection.State;
      }
    }

    public override int ConnectionTimeout
    {
      get
      {
        return this.innerConnection.ConnectionTimeout;
      }
    }

    protected override DbProviderFactory DbProviderFactory
    {
      get
      {
        if (this.innerConnection is SqlConnection)
          return (DbProviderFactory) ((IEnumerable<PropertyInfo>) this.innerConnection.GetType().GetProperties(BindingFlags.NonPublic)).Where<PropertyInfo>((Func<PropertyInfo, bool>) (p => p.Name == "DbProviderFactory")).First<PropertyInfo>().GetValue((object) this.innerConnection, (object[]) null);
        return (DbProviderFactory) MySqlClientFactory.Instance;
      }
    }

    public override string ConnectionString
    {
      get
      {
        return this.innerConnection.ConnectionString.GetHashCode().ToString();
      }
      set
      {
      }
    }

    public int CommandTimeout { get; set; }

    public string Provider { get; set; }

    public TCDbConnection(DbConnection conn)
    {
      this.innerConnection = conn;
      this.Disposed += new EventHandler(this.TCDbConnection_Disposed);
    }

    private void TCDbConnection_Disposed(object sender, EventArgs e)
    {
      this.innerConnection.Dispose();
    }

    internal IDbConnection GetInnerConnection()
    {
      return (IDbConnection) this.innerConnection;
    }

    public DataAdapter GetDataAdapter()
    {
      return (DataAdapter) this.DbProviderFactory.CreateDataAdapter();
    }

    protected override DbTransaction BeginDbTransaction(IsolationLevel isolationLevel)
    {
      return this.innerConnection.BeginTransaction(isolationLevel);
    }

    public IDbTransaction BeginTransaction()
    {
      return (IDbTransaction) this.innerConnection.BeginTransaction();
    }

    public override void ChangeDatabase(string databaseName)
    {
      this.innerConnection.ChangeDatabase(databaseName);
    }

    public override void Close()
    {
      this.innerConnection.Close();
    }

    protected override DbCommand CreateDbCommand()
    {
      return (DbCommand) new TCDbCommand(this.innerConnection.CreateCommand());
    }

    public override void Open()
    {
      this.innerConnection.Open();
    }

    public new void Dispose()
    {
      try
      {
        this.innerConnection.Dispose();
      }
      catch
      {
      }
      base.Dispose();
    }

    protected override void Dispose(bool disposing)
    {
      try
      {
        this.innerConnection.Dispose();
      }
      catch
      {
      }
      base.Dispose(disposing);
    }
  }
}
