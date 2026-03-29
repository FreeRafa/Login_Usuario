using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Tela_Login.Utilitarios
{
    public class Criptografia
    {
        public static string GerarHash(string senha)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(senha));

                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }

                return builder.ToString();
            }
        }

        // 🔐 Geração de hash da senha utilizando SHA-256
        // A senha é convertida em um hash antes de ser armazenada no banco de dados.
        //
        // ✔ O hash é irreversível (não é possível recuperar a senha original)
        // ✔ A mesma senha gera sempre o mesmo hash
        // ✔ A senha nunca é armazenada em texto puro, aumentando a segurança
        //
        // ⚠ Para aplicações mais seguras, recomenda-se usar algoritmos como
        // bcrypt, PBKDF2 ou Argon2, que incluem salt e dificultam ataques
        // de força bruta e tabelas de hash.
    }
}
