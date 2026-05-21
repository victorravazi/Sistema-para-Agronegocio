using System.Collections.Generic;

namespace AgroSistema.Models
{
    public class Fazenda : IEntidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public decimal AreaHectares { get; set; }
        public int ProdutorId { get; set; }

        public Produtor Produtor { get; set; }

        public List<Funcionario> Funcionarios { get; set; } = new List<Funcionario>();

        public bool Validar()
        {
            return !string.IsNullOrWhiteSpace(Nome)
                && !string.IsNullOrWhiteSpace(Cidade)
                && !string.IsNullOrWhiteSpace(Estado)
                && AreaHectares > 0
                && ProdutorId > 0;
        }

        public override string ToString() => $"{Nome} - {Cidade}/{Estado}";
    }
}
