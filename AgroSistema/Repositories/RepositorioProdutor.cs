using Dapper;
using AgroSistema.Models;
using System.Collections.Generic;
using System.Linq;

namespace AgroSistema.Repositories
{
    public class RepositorioProdutor
    {
        public List<Produtor> ListarTodos()
        {
            using (var conn = Conexao.GetConnection())
            {
                var sql = "SELECT * FROM Produtor ORDER BY Nome";
                return conn.Query<Produtor>(sql).ToList();
            }
        }

        public Produtor BuscarPorId(int id)
        {
            using (var conn = Conexao.GetConnection())
            {
                var sql = "SELECT * FROM Produtor WHERE Id = @Id";
                return conn.QueryFirstOrDefault<Produtor>(sql, new { Id = id });
            }
        }

        public void Inserir(Produtor produtor)
        {
            using (var conn = Conexao.GetConnection())
            {
                var sql = @"INSERT INTO Produtor (Nome, CPF, Telefone, Email)
                            VALUES (@Nome, @CPF, @Telefone, @Email)";
                conn.Execute(sql, produtor);
            }
        }

        public void Editar(Produtor produtor)
        {
            using (var conn = Conexao.GetConnection())
            {
                var sql = @"UPDATE Produtor SET Nome=@Nome, CPF=@CPF,
                            Telefone=@Telefone, Email=@Email WHERE Id=@Id";
                conn.Execute(sql, produtor);
            }
        }

        public void Deletar(int id)
        {
            using (var conn = Conexao.GetConnection())
            {
                var sql = "DELETE FROM Produtor WHERE Id = @Id";
                conn.Execute(sql, new { Id = id });
            }
        }
    }
}
