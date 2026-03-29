# Login_Usuario
Simples Login com Usuário e senha 

# 🔐 Sistema de Login Básico

Projeto simples de autenticação de utilizadores desenvolvido em **C#** com integração ao **SQL Server**.

## 📌 Objetivo

Criar uma base sólida para um sistema de login, com:
- Cadastro de utilizadores
- Autenticação (login)
- Controle básico de permissões (admin / usuário comum)

---

🚀 Funcionalidades
✅ Cadastro de utilizadores
✅ Login com validação de credenciais
✅ Hash de senha com SHA256
✅ Identificação de utilizadores:
👤 Usuário comum
🔐 Administrador
✅ Conexão com base de dados SQL Server
✅ Estrutura com separação de responsabilidades:
Modelo
Serviço
Repositório
Utilitários

---

## 🛠️ Tecnologias Utilizadas

- C#
- .NET
- SQL Server
- ADO.NET 
- SHA256 (criptografia)
- Console Application
---

## 🗄️ Estrutura da Base de Dados

```sql
CREATE TABLE Users
(
    Id INT PRIMARY KEY IDENTITY(1,1),
    Username VARCHAR(50) NOT NULL,
    SenhaHash VARCHAR(255) NOT NULL,
    IsAdmin BIT NOT NULL DEFAULT 0
);
