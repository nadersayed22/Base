using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StingRay.Utility.DBQueryHelper
{
    public class ExecutedSQLServer : IExecuted
    {
        public int ExecuteNonQuery(string Connection, string cmdtext, SqlParameter[] param = null)
        {
            //SqlConnection conn = new SqlConnection(connstr);
            SqlConnection conn = GetConnection(Connection);
            int rowsAffected = 0;
            try
            {
                SqlCommand cmd = new SqlCommand(cmdtext, conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter pp = new SqlParameter("Pass", "-999");
                cmd.Parameters.Add(pp);
                if (param != null)
                {
                    for (int i = 0; i < param.Length; i++)
                    {
                        cmd.Parameters.Add(param[i]);
                    }

                }
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                rowsAffected = cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }


            return rowsAffected;
        }

        public object Executescaler(string Connection, string cmdtext, SqlParameter[] param = null)
        {
            // SqlConnection conn = new SqlConnection(connstr);
            SqlConnection conn = GetConnection(Connection);
            object result = null;
            try
            {
                SqlCommand cmd = new SqlCommand(cmdtext, conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter pp = new SqlParameter("Pass", "-999");
                cmd.Parameters.Add(pp);
                if (param != null)
                {
                    for (int i = 0; i < param.Length; i++)
                    {
                        cmd.Parameters.Add(param[i]);
                    }
                }

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                result = cmd.ExecuteScalar();
                conn.Close();
            }
            catch (Exception ex)
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
            return result;
        }

        public DataTable ExecuteReader(string Connection, string cmdtext, SqlParameter[] param = null)
        {
            SqlConnection conn = GetConnection(Connection);

            SqlCommand cmd = new SqlCommand(cmdtext, conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter pp = new SqlParameter("Pass", "-999");
            cmd.Parameters.Add(pp);

            if (param != null)
            {
                for (int i = 0; i < param.Length; i++)
                {
                    cmd.Parameters.Add(param[i]);
                }
            }
            if (conn.State == ConnectionState.Closed)
            {

                conn.Open();
            }


            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);


            var dataTable = new DataTable();
            try
            {
                dataTable.Load(reader);
            }
            catch (Exception ex)
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }


            return dataTable;

        }

        public DataSet ExecuteReaderDS(string Connection, string cmdtext, SqlParameter[] param = null)
        {
            //SqlConnection conn = new SqlConnection(connstr);

            SqlConnection conn = GetConnection(Connection);

            SqlCommand cmd = new SqlCommand(cmdtext, conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter pp = new SqlParameter("Pass", "-999");
            cmd.Parameters.Add(pp);


            if (param != null)
            {
                for (int i = 0; i < param.Length; i++)
                {
                    cmd.Parameters.Add(param[i]);
                }
            }

            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }


            //SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            SqlDataAdapter reader = new SqlDataAdapter(cmd);

            //var dataTable = new DataTable();
            var dataset = new DataSet();
            reader.Fill(dataset);
            //dataTable.Load(reader);
            conn.Close();

            return dataset;

        }

        public DataTable ExecuteQuery(string Connection, string cmdtext)
        {
            SqlConnection conn = GetConnection(Connection);

            SqlCommand cmd = new SqlCommand(cmdtext, conn);
            cmd.CommandType = System.Data.CommandType.Text;

            if (conn.State == ConnectionState.Closed)
            {

                conn.Open();
            }

            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            var dataTable = new DataTable();
            try
            {
                dataTable.Load(reader);
            }
            catch (Exception ex)
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
            return dataTable;
        }
        public SqlConnection GetConnection(string Connection)
        {
            return new SqlConnection(Connection);
        }
    }
}
