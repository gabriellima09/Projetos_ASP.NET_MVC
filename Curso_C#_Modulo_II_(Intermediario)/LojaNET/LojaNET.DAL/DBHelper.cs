using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;

namespace LojaNET.DAL
{
    public static class DBHelper
    {
        public static string connString
        {
            get
            {
                return @"Data Source=(localDb)\MSSQLLocalDb;Initial Catalog=lojanet; Integrated Security=true";
            }
        }

        private static void PreencherParametros(object[] param, SqlCommand cmd)
        {
            if (param.Length > 0)
                for (int i = 0; i < param.Length; i += 2)
                    cmd.Parameters.AddWithValue(param[i].ToString(), param[i + 1]);
        }

        public static int ExecuteNonQuery(string StoredProcedure, params object[] param)
        {
            int retorno = 0;

            using (var conn = new SqlConnection(connString))
            {
                using (var cmd = new SqlCommand(StoredProcedure, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    PreencherParametros(param, cmd);

                    conn.Open();
                    retorno = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }

            return retorno;
        }

        public static IDataReader ExecuteReader(string StoredProcedure, params object[] param)
        {
            var conn = new SqlConnection(connString);
            var cmd = new SqlCommand(StoredProcedure, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            PreencherParametros(param, cmd);

            conn.Open();

            var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            return reader;
        }
    }
}
