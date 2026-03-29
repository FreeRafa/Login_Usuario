using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tela_Login.Modelo
{
    public class Users
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public bool IsAdmin { get; set; }
        public string SenhaHash { get; internal set; }

        // 🔐 Geração de hash da senha
        // A senha NÃO é armazenada em texto puro por questões de segurança.
        // Aqui transformamos a senha em um hash usando SHA256.
        //
        // ✔ O hash é irreversível (não dá para obter a senha original)
        // ✔ A mesma senha gera o mesmo hash (sem uso de salt)
        // ✔ Utilizado para comparar senhas no login sem expor dados sensíveis
        //
        // ⚠ Em aplicações reais, o ideal é usar algoritmos mais seguros como
        // bcrypt, PBKDF2 ou Argon2, que incluem "salt" automaticamente.
    }
}
