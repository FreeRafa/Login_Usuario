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
            string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=Tela_Cadastro;Integrated Security=True;";

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

            // Verifica se existe o admin
            var admin = servico.ReadUsersByName("admin".Trim().ToLower());

            if (admin == null)
            {
                Users novoAdmin = new Users
                {
                    Nome = "admin",
                    SenhaHash = Criptografia.GerarHash("admin123"),
                    IsAdmin = true
                };

                servico.AddUser(novoAdmin);

                Console.WriteLine("Admin criado automaticamente.");
            }


            int opcao = -1;

            while (opcao != 0)
            {
                Console.WriteLine("=== Tela de Login ===");
                Console.WriteLine("1 .Login");
                Console.WriteLine("2 .Cadastrar");
                Console.WriteLine("3 .Sair ...");

                Console.Write("Escolha uma opção: ");

                if (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    Console.WriteLine("Opção inválida!");
                    continue;
                }

                switch (opcao)
                {
                    case 1:

                        Console.WriteLine("Digite seu Nome:");
                        string nomeLogin = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(nomeLogin))
                        {
                            Console.WriteLine("Nome inválido");
                            break;
                        }

                        Console.WriteLine("Digite sua Senha:");
                        string senhaLogin = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(senhaLogin))
                        {
                            Console.WriteLine("Senha inválida");
                            break;
                        }

                        string senhaHash = Criptografia.GerarHash(senhaLogin);

                        Users usuarioLogado = servico.Login(nomeLogin, senhaHash);

                        if (usuarioLogado != null)
                        {
                            Console.WriteLine("Login realizado com sucesso!");

                            if (usuarioLogado.IsAdmin)
                                Console.WriteLine("Bem-vindo, Administrador!");
                            else
                                Console.WriteLine("Bem-vindo, Usuário!");
                        }
                        else
                        {
                            Console.WriteLine("Login inválido!");
                        }

                        break;

                    case 2:

                        Users user = new Users();

                        Console.WriteLine("Digite seu Nome:");
                        user.Nome = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(user.Nome))
                        {
                            Console.WriteLine("Nome inválido");
                            break;
                        }

                        Console.WriteLine("Digite sua Senha:");
                        string senha = Console.ReadLine();

                        user.SenhaHash = Criptografia.GerarHash(senha);
                        user.IsAdmin = false;

                        servico.AddUser(user);

                        break;

                    case 3:
                        Console.WriteLine("Saindo...");
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }

        }
    }
}
    

