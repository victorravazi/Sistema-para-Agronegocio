using System;

namespace AgroSistema.Models
{
    // Funcionario também herda de Pessoa
    public class Funcionario : Pessoa
    {
        public string Cargo { get; set; }
        public decimal Salario { get; set; }
        public int FazendaId { get; set; }
        public Fazenda Fazenda { get; set; }

        public override bool Validar()
        {
            return !string.IsNullOrWhiteSpace(Nome)
                && !string.IsNullOrWhiteSpace(CPF)
                && !string.IsNullOrWhiteSpace(Cargo)
                && Salario > 0
                && FazendaId > 0;
        }

        public override string ToString() => $"{Nome} - {Cargo}";
    }

    public class Cultura : IEntidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public int TempoMedioColheitaDias { get; set; }
        public string Descricao { get; set; }

        public bool Validar()
        {
            return !string.IsNullOrWhiteSpace(Nome)
                && !string.IsNullOrWhiteSpace(Tipo)
                && TempoMedioColheitaDias > 0;
        }

        public override string ToString() => $"{Nome} ({Tipo})";
    }

    public class Colheita : IEntidade
    {
        public int Id { get; set; }
        public int FazendaId { get; set; }
        public int CulturaId { get; set; }
        public DateTime DataPlantio { get; set; }
        public DateTime? DataColheita { get; set; }
        public decimal? QuantidadeToneladas { get; set; }
        public string Observacoes { get; set; }

        // Navegação
        public Fazenda Fazenda { get; set; }
        public Cultura Cultura { get; set; }

        public bool Validar()
        {
            return FazendaId > 0
                && CulturaId > 0
                && DataPlantio != default;
        }

        public override string ToString()
        {
            string fazenda = Fazenda?.Nome ?? $"Fazenda #{FazendaId}";
            string cultura = Cultura?.Nome ?? $"Cultura #{CulturaId}";
            return $"{fazenda} - {cultura} ({DataPlantio:dd/MM/yyyy})";
        }
    }
}
