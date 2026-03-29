using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tela_Login.Modelo;
using Tela_Login.Repositorio;

namespace Tela_Login.Servico
{
    public class ServicoUser
    {
        private readonly RepositorioUser _repositorioU;

        public ServicoUser(string connectionString)
        {
            _repositorioU = new RepositorioUser(connectionString);
        }

        public void AddUser(Users user)
        {
            if (string.IsNullOrEmpty(user.Nome) || string.IsNullOrEmpty(user.SenhaHash))
            {
                throw new ArgumentException("Nome e Senha são obrigatórios.");
            }

          
            _repositorioU.AddUser(user);
        }

        public Users ReadUsers(int Id)
        {
            if (Id <= 0)
            {
                throw new ArgumentException("Id deve ser maior que zero.");
            }

            return _repositorioU.ReadUsers(Id);
        }

        public void UpdateUser(Users user)
        {
            if (user.Id <= 0)
            {
                throw new ArgumentException("Id deve ser maior que zero.");
            }
            if (string.IsNullOrEmpty(user.Nome) || string.IsNullOrEmpty(user.SenhaHash))
            {
                throw new ArgumentException("Nome e Senha são obrigatórios.");
            }
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            _repositorioU.UpdateUser(user);
        }

        public void DeleteUser(int Id)
        {
            if (Id <= 0)
            {
                throw new ArgumentException("Id deve ser maior que zero.");
            }
            _repositorioU.DeleteUser(Id);
        }

        public Users Login(string nome, string senhaHash)
        {
            return _repositorioU.Login(nome, senhaHash);
        }

        public Users ReadUsersByName(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new ArgumentException("Nome inválido.");
            }

            return _repositorioU.ReadUsersByName(nome);
        }
    }
}
