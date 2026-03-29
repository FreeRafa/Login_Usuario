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
           "Server=DESKTOP-42RL6N1;Database=Tela_Cadastro;User Id=sa;Password=135113rr;"; 

        
        public static SqlConnection GetConnection() 
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open(); 
            return connection; 
        }

    }
}
