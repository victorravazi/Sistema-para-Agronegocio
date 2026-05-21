using Dapper;
using AgroSistema.Models;
using System.Collections.Generic;
using System.Linq;

namespace AgroSistema.Repositories
{
    public class RepositorioFazenda
    {
        public List<Fazenda> ListarTodos()
        {
            using (var conn = Conexao.GetConnection())
            {
                var sql = @"SELECT f.*, p.Id, p.Nome, p.CPF
                            FROM Fazenda f
                            INNER JOIN Produtor p ON f.ProdutorId = p.Id
                            ORDER BY f.Nome";

                var result = conn.Query<Fazenda, Produtor, Fazenda>(sql,
                    (fazenda, produtor) => { fazenda.Produtor = produtor; return fazenda; },
                    splitOn: "Id");

                return result.ToList();
            }
        }

        public List<Fazenda> ListarPorProdutor(int produtorId)
        {
            using (var conn = Conexao.GetConnection())
            {
                var sql = "SELECT * FROM Fazenda WHERE ProdutorId = @ProdutorId ORDER BY Nome";
                return conn.Query<Fazenda>(sql, new { ProdutorId = produtorId }).ToList();
            }
        }

        public Fazenda BuscarPorId(int id)
        {
            using (var conn = Conexao.GetConnection())
            {
                var sql = "SELECT * FROM Fazenda WHERE Id = @Id";
                return conn.QueryFirstOrDefault<Fazenda>(sql, new { Id = id });
            }
        }

        public void Inserir(Fazenda fazenda)
        {
            using (var conn = Conexao.GetConnection())
            {
                var sql = @"INSERT INTO Fazenda (Nome, Cidade, Estado, AreaHectares, ProdutorId)
                            VALUES (@Nome, @Cidade, @Estado, @AreaHectares, @ProdutorId)";
                conn.Execute(sql, fazenda);
            }
        }

        public void Editar(Fazenda fazenda)
        {
            using (var conn = Conexao.GetConnection())
            {
                var sql = @"UPDATE Fazenda SET Nome=@Nome, Cidade=@Cidade, Estado=@Estado,
                            AreaHectares=@AreaHectares, ProdutorId=@ProdutorId WHERE Id=@Id";
                conn.Execute(sql, fazenda);
            }
        }

        public void Deletar(int id)
        {
            using (var conn = Conexao.GetConnection())
            {
                var sql = "DELETE FROM Fazenda WHERE Id = @Id";
                conn.Execute(sql, new { Id = id });
            }
        }
    }
}
