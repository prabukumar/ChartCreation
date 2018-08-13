using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ChartCreation
{
    public class SQLClass
    {
        static string conStr = ConfigurationManager.ConnectionStrings["ConStr"].ToString();
        SqlConnection connection = new SqlConnection(conStr);
        string Query = string.Empty;
        SqlCommand command = new SqlCommand();
        SqlDataReader reader;
    }
}