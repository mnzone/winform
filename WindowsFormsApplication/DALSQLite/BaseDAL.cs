using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using MySql.Data.MySqlClient;
using Tools;

namespace DALSQLite
{
    public class BaseDAL
    {
        /// <summary>
        /// DbParameter数组转换为MySqlParameter数组
        /// </summary>
        /// <param name="paramArray">DbParameter数组</param>
        /// <returns></returns>
        protected SQLiteParameter[] ConvertSQLiteParameters(DbParameter[] paramArray)
        {
            SQLiteParameter[] parameters = new SQLiteParameter[paramArray.Length];

            for (int i = 0; i < paramArray.Length; i++)
            {
                parameters[i] = new SQLiteParameter(paramArray[i].ParameterName, DbType.Int32, 11)
                {
                    Value = paramArray[i].Value
                };
            }

            return parameters;
        }

        /// <summary>
        /// DbParameter数组转换为MySqlParameter数组
        /// </summary>
        /// <param name="paramArray">DbParameter数组</param>
        /// <returns></returns>
        protected SQLiteParameter[] ConvertSQLiteParameters(List<SQLiteParameter> paramArray)
        {
            SQLiteParameter[] parameters = new SQLiteParameter[paramArray.Count];

            for (int i = 0; i < paramArray.Count; i++)
            {
                parameters[i] = paramArray[i] as SQLiteParameter;
            }

            return parameters;
        }

        protected int SaveQueue(String value)
        {
            int row = 0;
            String sql = String.Format("INSERT INTO queues(command) VALUES('{0}');", value.Replace(@"'", @"''"));

            row = SQLiteHelper.ExecuteNonQuery(SQLiteHelper.ConnectionStringInventoryDistributedTransaction,
                CommandType.Text, sql);
            return row;
        }
    }
}