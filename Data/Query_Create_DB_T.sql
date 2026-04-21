CREATE DATABASE Tela_Cadastro

USE Tela_Cadastro

CREATE TABLE Users
(
Id INT PRIMARY KEY IDENTITY (1,1),
Nome VARCHAR (50) NOT NULL,
Senha VARCHAR (255) NOT NULL,
IsAdmin BIT DEFAULT 0
);

EXEC sp_rename 'Users.Senha', 'SenhaHash', 'COLUMN';