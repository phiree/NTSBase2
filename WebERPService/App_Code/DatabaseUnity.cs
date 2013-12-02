using System;
using System.Data;
//using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;
using System.Reflection;
namespace DataAccess
{
    /// <summary>
    /// Summary description for CommonOleDb.
    /// </summary>
    public class CommonSQL
    {
        public CommonSQL()
        {
        }

        public static DataSet ExcuteProcedureDataset(string _procedureName, params DbParameter[] _params)
        {
            DbConnection connect = DbFactory.CreateDBconnection(DataAccess.ConnectionEntry.SQLConnectionString);
            DbDataAdapter adap = DbFactory.CreateAdapter();
            DbCommand command = DbFactory.CreateDBcommand();
            command.CommandText = _procedureName;
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = connect;

            foreach (DbParameter _parObj in _params)
                command.Parameters.Add(_parObj);

            adap.SelectCommand = command;
            DataSet ret = new DataSet();
            try
            {
                connect.Open();
                adap.Fill(ret);
                return ret;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                connect.Close();
                command.Dispose();
            }
        }

        public static DataSet ExcuteDataset(string SqlCommand)
        {
            DbDataAdapter adap = DbFactory.CreateAdapter();
            DbCommand command = DbFactory.CreateDBcommand();
            command.CommandText = SqlCommand;
            command.CommandType = System.Data.CommandType.Text;
            DbConnection connect = DbFactory.CreateDBconnection(DataAccess.ConnectionEntry.SQLConnectionString);
            command.Connection = connect;
            adap.SelectCommand = command;
            DataSet ret = new DataSet();
            try
            {
                connect.Open();
                adap.Fill(ret);
                return ret;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                connect.Close();
                command.Dispose();
            }
        }

      
     

       
        public static int ExcuteNoneQuery(string SQLcommand)
        {
            DbCommand command = DbFactory.CreateDBcommand();
            command.CommandText = SQLcommand;
            command.CommandType = System.Data.CommandType.Text;
            DbConnection connect = DbFactory.CreateDBconnection(DataAccess.ConnectionEntry.SQLConnectionString);
            command.Connection = connect;
            try
            {
                connect.Open();
                return command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connect.Close();
                command.Dispose();
            }
        }

        public static int ExcuteNoneQuery(string SQLcommand, string connectionStr)
        {
            DbCommand command = DbFactory.CreateDBcommand();
            command.CommandText = SQLcommand;
            command.CommandType = System.Data.CommandType.Text;
            DbConnection connect = DbFactory.CreateDBconnection(connectionStr);
            command.Connection = connect;
            try
            {
                connect.Open();
                return command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connect.Close();
                command.Dispose();
            }
        }

        public static int ExcuteNoneQuery(string sqlprocedure, DbTransaction tran, System.Data.CommandType cmdType, params DbParameter[] sqlparams)
        {
            DbCommand command = DbFactory.CreateDBcommand();
            command.CommandText = sqlprocedure;
            command.CommandType = cmdType;// System.Data.CommandType.StoredProcedure;
            for (int i = 0; i < sqlparams.Length; i++) command.Parameters.Add(sqlparams[i]);

            int ret = -1;
            if (tran == null)
            {
                DbConnection connect = DbFactory.CreateDBconnection(DataAccess.ConnectionEntry.SQLConnectionString);
                command.Connection = connect;
                try
                {
                    connect.Open();
                    ret = command.ExecuteNonQuery();
                }
                catch (Exception ex) { throw ex; }
                finally
                {
                    connect.Close();
                    command.Dispose();
                }

            }
            else
            {
                command.Transaction = tran;
                command.Connection = tran.Connection;
                ret = command.ExecuteNonQuery();
            }
            return ret;
        }

        public static int ExcuteNoneQuery(string sqlprocedure, DbTransaction tran, params DbParameter[] sqlparams)
        {
            return ExcuteNoneQuery(sqlprocedure, tran, System.Data.CommandType.Text, sqlparams);
        }

        public static int ExcuteNoneQuery(string sqlprocedure, params DbParameter[] sqlparams)
        {
            return ExcuteNoneQuery(sqlprocedure, null, sqlparams);
        }

        public static object Excutescalar(string sqlcommand)
        {
            return Excutescalar(sqlcommand, System.Data.CommandType.Text);
            //DbCommand command = DbFactory.CreateDBcommand();
            //command.CommandText = sqlcommand;
            //command.CommandType = System.Data.CommandType.Text;
            //DbConnection connect = DbFactory.CreateDBconnection(DataAccess.ConnectionEntry.SQLConnectionString);
            //command.Connection = connect;


            //try
            //{
            //    connect.Open();
            //    return command.ExecuteScalar();
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            //finally
            //{
            //    connect.Close();
            //    command.Dispose();
            //}
        }

        public static object Excutescalar(string sqlcommand, System.Data.CommandType _commandType, params DbParameter[] sqlparams)
        {
            DbCommand command = DbFactory.CreateDBcommand();
            command.CommandText = sqlcommand;
            command.CommandType = _commandType;
            DbConnection connect = DbFactory.CreateDBconnection(DataAccess.ConnectionEntry.SQLConnectionString);
            command.Connection = connect;

            for (int i = 0; i < sqlparams.Length; i++) command.Parameters.Add(sqlparams[i]);
            try
            {
                connect.Open();
                return command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connect.Close();
                command.Dispose();
            }
        }

        public static DbParameter[] CreateParams(string[] paramNames, object[] values)
        {
            int count = (paramNames.Length > values.Length) ? values.Length : paramNames.Length;
            DbParameter[] sqlparams = DbFactory.CreateDBparams(count);
            for (int i = 0; i < count; i++)
            {
                sqlparams[i] = DbFactory.CreateDBparams(paramNames[i], values[i]);
            }
            return sqlparams;
        }

        #region transfer datatable and array of objec

        /// <summary>
        /// this fuction will Create Coresponding DataTable and Coppy data from Object Array to the DataTable
        /// </summary>
        /// <param name="BussinessObjectArr"> array of object . all object in array need have a same Type as ObjType</param>
        /// <param name="objType">Type of object in array object , it must is a kind of ObjectEx type</param>
        /// <returns>a DataTable result</returns>
   
        /// <summary>
        /// this fuction will Create Coresponding DataTable and Coppy data from Object Array to the DataTable with adding index colum
        /// </summary>
        /// <param name="BussinessObjectArr"></param>
        /// <param name="objType"></param>
        /// <param name="IndexColumAddition"></param>
        /// <returns></returns>
     

        //change by duyet 22/01/2009
        /// <summary>
        /// mapping data from Datatabe [dt] to an Arraylist of ObjectEx 
        /// </summary>
        /// <param name="dt">Datatable which contain data as Rows</param>
        /// <param name="objType">Type of object which you want converting to</param>
        /// <returns></returns>
      
        /// <summary>
        /// get DataTable templete coresponding with a business object type;
        /// </summary>
        /// <param name="objtype"> type of Object</param>
        /// <returns></returns>
   
        #endregion

    }
}