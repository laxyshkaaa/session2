using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PISHYSAM7
{
    internal class DataBaseHelper
    {
        static string conn_str = "Server=POLNAREFF\\SQLEXPRESS;Database=SAM4;Trusted_Connection=yes";

        public static DataTable ExecuteQuery(string query, Dictionary<string, object> parameters = null)
        {
            using(SqlConnection conn = new SqlConnection(conn_str))
                using(SqlCommand cmd = new SqlCommand(query, conn))
            {
                if (parameters != null)
                {
                    foreach(var p  in parameters) { 
                        cmd.Parameters.AddWithValue(p.Key, p.Value);
                    }
                }

                DataTable dataTable = new DataTable();
                using(SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    conn.Open();
                    adapter.Fill(dataTable);
                }
            return dataTable;
            }
        }
    }
}
