using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace GestionAca
{
    public static class DatabaseConnection
    {
        private static string connectionString = 
            "Server=localhost\\SQLEXPRESS; Database=GestionAcademica; Trusted_Connection=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
