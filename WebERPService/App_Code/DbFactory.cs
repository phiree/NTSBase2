using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
namespace DataAccess
{
    public class DbFactory
    {
        public static DbCommand CreateDBcommand() { return new SqlCommand(); }
        //public static IDbTransaction CreateDBtransaction() { return new SqlTransaction; }
        public static DbConnection CreateDBconnection() { return new SqlConnection(); }
        public static DbConnection CreateDBconnection(string ConnectionString) { return new SqlConnection(ConnectionString); }
        public static DbParameter[] CreateDBparams(int count) { return new SqlParameter[count]; }
        public static DbParameter CreateDBparams() { return new SqlParameter(); }
        public static DbParameter CreateDBparams(string parameterName, object value) { return new SqlParameter(parameterName, value); }

        #region Transaction functions
        public static DbTransaction CreateTransaction()
        {
            try
            {
                DbConnection conn = CreateDBconnection(ConnectionEntry.SQLConnectionString);
                conn.Open();
                DbTransaction trans = conn.BeginTransaction();
                return trans;
            }
            catch
            {
                return null;
            }
        }
        #endregion
        public static DbDataAdapter CreateAdapter()
        {
            return new SqlDataAdapter();
        }
        //CommandType
    }
}
