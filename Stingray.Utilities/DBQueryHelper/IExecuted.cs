using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StingRay.Utility.DBQueryHelper
{
    public interface IExecuted
    {
        int ExecuteNonQuery(string Connection, string cmdtext, SqlParameter[] param = null);
        object Executescaler(string Connection, string cmdtext, SqlParameter[] param = null);
        DataTable ExecuteReader(string Connection, string cmdtext, SqlParameter[] param = null);
        DataSet ExecuteReaderDS(string Connection, string cmdtext, SqlParameter[] param = null);
        DataTable ExecuteQuery(string Connection, string cmdtext);
    }
}
