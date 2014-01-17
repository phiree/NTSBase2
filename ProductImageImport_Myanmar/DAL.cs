using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace ProductImageImport_Myanmar
{
    public class DAL
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
            SqlCommand comm = new SqlCommand(sql,conn);
            OpenConnection();
            try
            {
                comm.ExecuteNonQuery();
            }
            catch
            { throw; }
            finally
            {
                CloseConnection();
            }
        }
      
        public void BulkUpdateImage(string[] filenames)
        {
            StringBuilder sbSql = new StringBuilder();
            foreach (string s in filenames)
            {
                string id = s.Substring(s.LastIndexOf("\\")+1
                    , s.LastIndexOf(".") - s.LastIndexOf("\\"));
                string singleSql = string.Format(@"
                    update tgoods set jphoto
                    =(SELECT BulkColumn 
                      FROM OPENROWSET(BULK '{0}',SINGLE_BLOB)
                      AS x)
                      where jgoodscode='{1}'"
                    ,s,id);
                sbSql.AppendLine(singleSql);
            }
           ExcuteSql(  sbSql.ToString());
        }
    }
}
