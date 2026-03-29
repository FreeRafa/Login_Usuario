# 🔐 Login_Usuario

Sistema simples de autenticação de utilizadores desenvolvido em **C#**, com integração ao **SQL Server**.

---

## 📌 Objetivo

Criar uma base sólida para um sistema de login, com:

- Cadastro de utilizadores  
- Autenticação (login)  
- Controle de permissões:
  - 👤 Usuário comum  
  - 🔐 Administrador  

---

## 🚀 Funcionalidades

- ✅ Cadastro de utilizadores  
- ✅ Login com validação de credenciais  
- ✅ Criptografia de senha com **SHA256**  
- ✅ Identificação de utilizadores (Admin / Usuário)  
- ✅ Conexão com base de dados SQL Server  
- ✅ Arquitetura em camadas:
  - Modelo  
  - Serviço  
  - Repositório  
  - Utilitários  

---

## 🛠️ Tecnologias Utilizadas

- C#  
- .NET  
- SQL Server  
- ADO.NET  
- SHA256 (criptografia)  
- Aplicação Console  

---

## 🗄️ Estrutura da Base de Dados

```sql
CREATE TABLE Users
(
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nome NVARCHAR(100) NOT NULL,
    SenhaHash NVARCHAR(64) NOT NULL,
    IsAdmin BIT NOT NULL DEFAULT 0
);
