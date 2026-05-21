// ============================================
// INTERFACES E MODELOS BASE
// ============================================

namespace AgroSistema.Models
{
    // Interface obrigatória (requisito do projeto)
    public interface IEntidade
    {
        int Id { get; set; }
        bool Validar();
    }

    // Classe base com Herança (requisito do projeto)
    public abstract class Pessoa : IEntidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }

        public bool CPFValido()
        {
            return !string.IsNullOrWhiteSpace(CPF) && CPF.Length >= 11;
        }

        public abstract bool Validar();
    }
}
