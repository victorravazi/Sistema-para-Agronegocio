-- ============================================
-- SISTEMA DE GESTÃO DE AGRONEGÓCIO
-- Script de criação do banco de dados
-- ============================================

CREATE DATABASE IF NOT EXISTS AgroSistema;
USE AgroSistema;

-- Tabela: Produtor
CREATE TABLE IF NOT EXISTS Produtor (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL,
    CPF VARCHAR(14) NOT NULL UNIQUE,
    Telefone VARCHAR(15),
    Email VARCHAR(100),
    DataCadastro DATETIME DEFAULT CURRENT_TIMESTAMP
);

-- Tabela: Fazenda
CREATE TABLE IF NOT EXISTS Fazenda (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL,
    Cidade VARCHAR(80) NOT NULL,
    Estado VARCHAR(2) NOT NULL,
    AreaHectares DECIMAL(10,2) NOT NULL,
    ProdutorId INT NOT NULL,
    FOREIGN KEY (ProdutorId) REFERENCES Produtor(Id)
);

-- Tabela: Cultura (tipo de plantação)
CREATE TABLE IF NOT EXISTS Cultura (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nome VARCHAR(80) NOT NULL,
    Tipo VARCHAR(50) NOT NULL,
    TempoMedioColheitaDias INT NOT NULL,
    Descricao VARCHAR(255)
);

-- Tabela: Funcionario
CREATE TABLE IF NOT EXISTS Funcionario (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL,
    CPF VARCHAR(14) NOT NULL UNIQUE,
    Cargo VARCHAR(60) NOT NULL,
    Salario DECIMAL(10,2) NOT NULL,
    FazendaId INT NOT NULL,
    FOREIGN KEY (FazendaId) REFERENCES Fazenda(Id)
);

-- Tabela: Colheita
CREATE TABLE IF NOT EXISTS Colheita (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    FazendaId INT NOT NULL,
    CulturaId INT NOT NULL,
    DataPlantio DATE NOT NULL,
    DataColheita DATE,
    QuantidadeToneladas DECIMAL(10,3),
    Observacoes VARCHAR(255),
    FOREIGN KEY (FazendaId) REFERENCES Fazenda(Id),
    FOREIGN KEY (CulturaId) REFERENCES Cultura(Id)
);

-- Dados iniciais para Cultura
INSERT INTO Cultura (Nome, Tipo, TempoMedioColheitaDias, Descricao) VALUES
('Soja', 'Grão', 120, 'Principal cultura do agronegócio brasileiro'),
('Milho', 'Grão', 90, 'Usado para alimentação humana e animal'),
('Cana-de-açúcar', 'Safrinha', 365, 'Matéria-prima para açúcar e etanol'),
('Café', 'Permanente', 730, 'Produto de exportação tradicional'),
('Arroz', 'Grão', 110, 'Alimento básico da dieta brasileira');
