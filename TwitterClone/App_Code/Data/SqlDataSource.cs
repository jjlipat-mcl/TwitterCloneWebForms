using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TwitterClone.App_Code.Data
{
    public static class SqlDataSource
    {
        public static SqlConnection GetConnection() {
            var connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Job\source\repos\TwitterClone\TwitterClone\App_Data\TwitterClone.mdf;Integrated Security=True";
            return new SqlConnection(connectionString);
        }
    }
}