using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace project_11122019.Datalayer
{
    public class Database
    {
        private SqlConnection cnn;
        ReadConnectionString rcString;
        private SqlCommand cmd;
        private SqlDataAdapter da;
        public Database(string path)
        {
            rcString = new ReadConnectionString(path);
            cnn = new SqlConnection();
            cnn.ConnectionString = rcString.ConnectionString;
        }

        public Database()
        {
            // TODO: Complete member initialization
        }

        public bool TestConnect(ref string err)
        {
            try
            {
                cnn.Open();
                return true;
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }

        public bool MyExcuteNonQuery(ref string err, string sql, CommandType ct, params SqlParameter[] param)
        {
            try
            {
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
                cnn.Open();
                cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.CommandType = ct;
                cmd.CommandTimeout = 600;
                if (param != null)
                {
                    foreach (SqlParameter item in param)
                    {
                        cmd.Parameters.Add(item);
                    }
                }
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {

                err = ex.Message;
                return false;
            }
            finally
            {
                cnn.Close();
            }
        }
        //public bool MyExcuteNonQuery(ref string err,ref int soDong, string sql, CommandType ct, params SqlParameter[] param)
        //{
        //    try
        //    {
        //        if (cnn.State == ConnectionState.Open)
        //        {
        //            cnn.Close();
        //        }
        //        cnn.Open();
        //        cmd = new SqlCommand();
        //        cmd.CommandText = sql;
        //        cmd.CommandType = ct;
        //        cmd.CommandTimeout = 600;
        //        if (param != null)
        //        {
        //            foreach (SqlParameter item in param)
        //            {
        //                cmd.Parameters.Add(item);
        //            }
        //        }
        //        soDong  = cmd.ExecuteNonQuery();

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {

        //        err = ex.Message;
        //        return false;
        //    }
        //    finally
        //    {
        //        cnn.Close();
        //    }
        //}
        //public object MyExcuteReader(ref string err, string sql, CommandType ct, params SqlParameter[] param)
        //{
        //    object obj = null;
        //    try
        //    {
        //        if (cnn.State == ConnectionState.Open)
        //        {
        //            cnn.Close();
        //        }
        //        cnn.Open();
        //        cmd = new SqlCommand();
        //        cmd.CommandText = sql;
        //        cmd.CommandType = ct;
        //        cmd.CommandTimeout = 600;
        //        if (param != null)
        //        {
        //            foreach (SqlParameter item in param)
        //            {
        //                cmd.Parameters.Add(item);
        //            }
        //        }
        //        obj = cmd.ExecuteScalar();

        //    }
        //    catch (Exception ex)
        //    {

        //        err = ex.Message;
        //    }
        //    finally
        //    {
        //        cnn.Close();
        //    }
        //    return obj;
        //}
        //public SqlDataReader MyExcuteScalar(ref string err, string sql, CommandType ct, params SqlParameter[] param)
        //{
        //    SqlDataReader _SqlDataReader = new SqlDataReader();
        //    try
        //    {
        //        if (cnn.State == ConnectionState.Open)
        //        {
        //            cnn.Close();
        //        }
        //        cnn.Open();
        //        cmd = new SqlCommand();
        //        cmd.CommandText = sql;
        //        cmd.CommandType = ct;
        //        cmd.CommandTimeout = 600;
        //        if (param != null)
        //        {
        //            foreach (SqlParameter item in param)
        //            {
        //                cmd.Parameters.Add(item);
        //            }
        //        }
        //        _SqlDataReader = cmd.ExecuteReader();

        //    }
        //    catch (Exception ex)
        //    {

        //        err = ex.Message;
        //    }
        //    return _SqlDataReader;
        //}
        //public DataTable GetDataTable(ref string err, string sql, CommandType ct, params SqlParameter[] param)
        //{
        //    DataTable dt = null;
        //    try
        //    {
        //        if (cnn.State == ConnectionState.Open)
        //        {
        //            cnn.Close();
        //        }
        //        cnn.Open();
        //        cmd = new SqlCommand();
        //        cmd.CommandText = sql;
        //        cmd.CommandType = ct;
        //        cmd.CommandTimeout = 600;
        //        if (param != null)
        //        {
        //            foreach (SqlParameter item in param)
        //            {
        //                cmd.Parameters.Add(item);
        //            }
        //        }
        //        da = new SqlDataAdapter(cmd);
        //        dt = new DataTable();
        //        da.Fill(dt);
        //    }
        //    catch (Exception ex)
        //    {

        //        err = ex.Message;
                
        //    }
        //    finally
        //    {
        //        cnn.Close();
        //    }
        //    return dt;
        //}
    }
}
