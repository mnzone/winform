using System;
using System.Data.Common;
using MySql.Data.MySqlClient;

namespace DALMySql
{
    public class BaseDAL
    {

        /// <summary>
        /// DbParameter数组转换为MySqlParameter数组
        /// </summary>
        /// <param name="paramArray">DbParameter数组</param>
        /// <returns></returns>
        protected MySqlParameter[] ConvertMySqlParameters(DbParameter[] paramArray)
        {
            MySqlParameter[] parameters = new MySqlParameter[paramArray.Length];

            for (int i = 0; i < paramArray.Length; i++)
            {
                parameters[i] = paramArray[i] as MySqlParameter;
            }

            return parameters;
        }
    }
}