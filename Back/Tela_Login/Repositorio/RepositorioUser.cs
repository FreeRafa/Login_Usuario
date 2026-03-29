using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Tela_Login.Modelo;

namespace Tela_Login.Repositorio
{
    internal class RepositorioUser
    {
        private readonly string _ConnectionString;

        public RepositorioUser(string connectionString)
        {
            _ConnectionString = connectionString;
        }

        public void AddUser(Users user)
        {
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                connection.Open();
                string query = "INSERT INTO Users (Nome, SenhaHash, IsAdmin) VALUES (@Nome, @SenhaHash, @IsAdmin)";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.Add("@Nome", SqlDbType.NVarChar, 100).Value = user.Nome;
                    cmd.Parameters.Add("@SenhaHash", SqlDbType.NVarChar, 100).Value = user.SenhaHash;
                    cmd.Parameters.Add("@IsAdmin", SqlDbType.Bit).Value = user.IsAdmin;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Users ReadUsers(int Id)
        {
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                string query = "SELECT * FROM Users WHERE Id = @Id";

                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;

                connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Users user = new Users
                        {
                            Id = (int)reader["Id"],
                            Nome = reader["Nome"].ToString(),
                            SenhaHash = reader["SenhaHash"].ToString(),
                            IsAdmin = (bool)reader["IsAdmin"]
                        };
                        return user;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public void UpdateUser(Users user)
        {
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                connection.Open();

                string query = "UPDATE Users SET Nome = @Nome, SenhaHash = @SenhaHash, IsAdmin = @IsAdmin WHERE Id = @Id";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.Add("@Nome", SqlDbType.NVarChar, 100).Value = user.Nome;
                    cmd.Parameters.Add("@SenhaHash", SqlDbType.NVarChar, 100).Value = user.SenhaHash;
                    cmd.Parameters.Add("@IsAdmin", SqlDbType.Bit).Value = user.IsAdmin;
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = user.Id;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteUser(int Id)
        {
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                connection.Open();
                string query = "DELETE FROM Users WHERE Id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
