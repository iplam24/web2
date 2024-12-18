using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace index.cs_sql
{
    public class connect
    {
        string StrCon = @"Data Source=localhost;Initial Catalog=webqlbandt;Integrated Security=True;";
        public SqlConnection SQLConn { get; private set; } = null;
        public void moKetNoi()
        {
            if(SQLConn == null) SQLConn = new SqlConnection(StrCon);
            if(SQLConn.State==System.Data.ConnectionState.Closed ) SQLConn.Open();
        }
        public void dongKetNoi()
        {
            if (SQLConn != null && SQLConn.State == System.Data.ConnectionState.Open)
            {
                SQLConn.Close();
                SQLConn.Dispose();
                SQLConn = null;
            }
        }

       
       
    }
}