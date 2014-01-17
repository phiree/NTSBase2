using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using System.Data.SqlClient;
namespace NDAL
{
    public class DALSimpleMSSQl
    {
        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ConnectionString);

        private void OpenConnection()
        {
            if (conn.State != System.Data.ConnectionState.Open)
                conn.Open();
        }
        private void CloseConnection()
        {
            if (conn.State != System.Data.ConnectionState.Closed)
                conn.Close();
        }
        public void ExcuteSql(string sql)
        {
            SqlCommand comm = new SqlCommand(sql, conn);
            OpenConnection();
            try
            {
                comm.ExecuteNonQuery();
            }
            catch
            { 
                throw; 
            }
            finally
            {
                CloseConnection();
            }
        }

    }
}
