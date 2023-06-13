using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ppapp.DB
{
   public class AppContext
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source = 192.168.49.180;Initial Catalog = changsalon;Integrated Security=true"); //подключение к БД


        public void OpenConnection()
        {
            if(sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }
        public void CloseConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }
        public SqlConnection GetConnection()
        {
           return sqlConnection;
        }
    }
}
