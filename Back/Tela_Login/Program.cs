using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tela_Login.Modelo;
using Tela_Login.Servico;
using Tela_Login.Utilitarios;

namespace Tela_Login
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=DESKTOP-42RL6N1;Database=Tela_Cadastro;User Id=sa;Password=135113rr;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    Console.WriteLine("Conexão bem-sucedida!");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Erro de SQL: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro geral: " + ex.Message);
            }

            ServicoUser servico = new ServicoUser(connectionString);

            int opcao = -1;

            while (opcao != 0)
            {
                Console.WriteLine("=== Tela de Login ===");
                Console.WriteLine("1 .Login");
                Console.WriteLine("2 .Cadastrar");
                Console.WriteLine("3 .Sair ...");

                Console.Write("Escolha uma opção: ");

                opcao = int.Parse(Console.ReadLine());

                ServicoUser servicou = new ServicoUser(connectionString);

                switch (opcao)
                {
                    case 1:

                        break;

                    case 2:

                        Users user = new Users();

                        Console.WriteLine("Cadastro User:");

                        Console.WriteLine("Digite seu Nome:");
                        user.Nome = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(user.Nome))
                        {
                            Console.WriteLine("Nome inválido");
                            return;
                        }

                        Console.WriteLine("Digite sua Senha:");
                        string senha = Console.ReadLine();

                        user.SenhaHash = Criptografia.GerarHash(senha);

                        user.IsAdmin = false;
                        
                        servicou.AddUser(user);

                        break;

                    case 3:

                        break;

                    case 0:

                        break;

                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
        }
    }
}
    

