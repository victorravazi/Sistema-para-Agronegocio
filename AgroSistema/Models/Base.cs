
namespace AgroSistema.Models
{
    public interface IEntidade
    {
        int Id { get; set; }
        bool Validar();
    }

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
