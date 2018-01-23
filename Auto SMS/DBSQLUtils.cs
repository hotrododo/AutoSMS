using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Auto_SMS
{
    class DBSQLUtils
    {
        public static MySqlConnection 
            GetDBConnection(string host, int port, string database, string username, string password)
        {
            String connString = "Server=" + host + ";Database=" + database + ";port=" 
                + port + ";User Id=" + username + ";password=" + password + ";TreatTinyAsBoolean=false";
            MySqlConnection connection = new MySqlConnection(connString);
            return connection;
        }
    }
}
