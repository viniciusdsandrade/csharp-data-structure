-- Deleta o banco de dados
ALTER DATABASE db_rest_store_demo_mvc SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
DROP DATABASE db_rest_store_demo_mvc;

-- Cria o banco de dados
CREATE DATABASE db_rest_store_demo_mvc;

-- Seleciona o banco de dados para uso
USE db_rest_store_demo_mvc;

-- Verifica se a seleção foi bem-sucedida
SELECT DB_NAME() AS  'BD in {use}';