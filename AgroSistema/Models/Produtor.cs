using System;
using System.Collections.Generic;

namespace AgroSistema.Models
{
    // Herda de Pessoa (herança obrigatória)
    public class Produtor : Pessoa
    {
        public string Telefone { get; set; }
        public string Email { get; set; }
        public DateTime DataCadastro { get; set; }

        // Lista de Fazendas (requisito: entidade contém lista de outra entidade)
        public List<Fazenda> Fazendas { get; set; } = new List<Fazenda>();

        public override bool Validar()
        {
            return !string.IsNullOrWhiteSpace(Nome)
                && !string.IsNullOrWhiteSpace(CPF)
                && CPFValido();
        }

        public override string ToString() => $"{Nome} (CPF: {CPF})";
    }
}
