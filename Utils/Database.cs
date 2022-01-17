using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace JsonWebToken_API.Utils
{
    public class Database
    {
        public SqlConnection Connection(IConfiguration configuration)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.DataSource = configuration.GetSection("ConnectionStrings").GetSection("DataSource").Value;
            builder.UserID = configuration.GetSection("ConnectionStrings").GetSection("UserID").Value;
            builder.Password = configuration.GetSection("ConnectionStrings").GetSection("Password").Value;
            builder.InitialCatalog = configuration.GetSection("ConnectionStrings").GetSection("InitialCatalog").Value;

            return new SqlConnection(builder.ConnectionString);
        }

        public SqlDataReader Exec(SqlConnection con, string sql)
        {
            SqlCommand command = new SqlCommand(sql, con);
            return command.ExecuteReader();
        }

        public int ExecNonQuery(SqlConnection con, string sql)
        {
            SqlCommand command = new SqlCommand(sql, con);
            return command.ExecuteNonQuery();
        }

        public void Close(SqlConnection conn, SqlDataReader data)
        {
            data.Close();
            conn.Close();
        }

        internal SqlConnection Connection(object configuration)
        {
            throw new NotImplementedException();
        }

        public void Close(SqlConnection conn)
        {
            conn.Close();
        }
    }
}
