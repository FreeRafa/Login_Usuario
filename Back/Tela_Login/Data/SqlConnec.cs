using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tela_Login.Data
{
    internal class SqlConnec
    {
        private static readonly string connectionString =
           "Server=(localdb)\\MSSQLLocalDB;Database=Tela_Cadastro;Integrated Security=True;";



       public static SqlConnection GetConnection() 
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open(); 
            return connection; 
        }

    }
}
