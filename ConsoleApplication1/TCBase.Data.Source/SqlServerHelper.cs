// Decompiled with JetBrains decompiler
// Type: TCBase.Data.SqlServerHelper
// Assembly: TCBase.Data.Source, Version=1.1.11.1, Culture=neutral, PublicKeyToken=null
// MVID: 85FB40CB-14C5-4BAB-9468-E4846CECFCDB
// Assembly location: D:\MyProject\ConsoleApplication1\ConsoleApplication1\bin\Debug\TCBase.Data.Source.dll

using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace TCBase.Data
{
  public static class SqlServerHelper
  {
    public static SqlBulkCopy GetBulkCopyBySqlServer(DbConnection conn)
    {
      if (!(conn is TCDbConnection))
        throw new Exception("只能支持SQL Server的数据库！");
      IDbConnection innerConnection = ((TCDbConnection) conn).GetInnerConnection();
      if (innerConnection is SqlConnection)
        return new SqlBulkCopy((SqlConnection) innerConnection);
      throw new Exception("只能支持SQL Server的数据库！");
    }

    public static SqlBulkCopy GetBulkCopyBySqlServer(DbConnection conn, SqlBulkCopyOptions copyOptions)
    {
      if (!(conn is TCDbConnection))
        throw new Exception("只能支持SQL Server的数据库！");
      IDbConnection innerConnection = ((TCDbConnection) conn).GetInnerConnection();
      if (innerConnection is SqlConnection)
        return new SqlBulkCopy(innerConnection.ConnectionString, copyOptions);
      throw new Exception("只能支持SQL Server的数据库！");
    }

    public static SqlBulkCopy GetBulkCopyBySqlServer(DbConnection conn, SqlBulkCopyOptions copyOptions, SqlTransaction externalTransaction)
    {
      if (!(conn is TCDbConnection))
        throw new Exception("只能支持SQL Server的数据库！");
      IDbConnection innerConnection = ((TCDbConnection) conn).GetInnerConnection();
      if (innerConnection is SqlConnection)
        return new SqlBulkCopy((SqlConnection) innerConnection, copyOptions, externalTransaction);
      throw new Exception("只能支持SQL Server的数据库！");
    }
  }
}
