using MySql.Data.MySqlClient;
using System;
using System.Configuration;

namespace Auto_SMS
{
    class DBUtils
    {
        public static MySqlConnection GetDBConnection()
        {
            string host = ConfigurationManager.AppSettings["host"].ToString();
            int port = 3306;
            string database = ConfigurationManager.AppSettings["database"].ToString();
            string username = ConfigurationManager.AppSettings["username"].ToString();
            string password = ConfigurationManager.AppSettings["password"].ToString();
            return DBSQLUtils.GetDBConnection(host, port, database, username, password);
        }
    }
}
