using Dapper;
using AgroSistema.Models;
using System.Collections.Generic;
using System.Linq;

namespace AgroSistema.Repositories
{
    public class RepositorioFuncionario
    {
        public List<Funcionario> ListarTodos()
        {
            using (var conn = Conexao.GetConnection())
            {
                var sql = @"SELECT fn.*, f.Id, f.Nome
                            FROM Funcionario fn
                            INNER JOIN Fazenda f ON fn.FazendaId = f.Id
                            ORDER BY fn.Nome";

                var result = conn.Query<Funcionario, Fazenda, Funcionario>(sql,
                    (func, faz) => { func.Fazenda = faz; return func; },
                    splitOn: "Id");

                return result.ToList();
            }
        }

        public List<Funcionario> ListarPorFazenda(int fazendaId)
        {
            using (var conn = Conexao.GetConnection())
            {
                var sql = "SELECT * FROM Funcionario WHERE FazendaId = @FazendaId ORDER BY Nome";
                return conn.Query<Funcionario>(sql, new { FazendaId = fazendaId }).ToList();
            }
        }

        public void Inserir(Funcionario f)
        {
            using (var conn = Conexao.GetConnection())
            {
                var sql = @"INSERT INTO Funcionario (Nome, CPF, Cargo, Salario, FazendaId)
                            VALUES (@Nome, @CPF, @Cargo, @Salario, @FazendaId)";
                conn.Execute(sql, f);
            }
        }

        public void Editar(Funcionario f)
        {
            using (var conn = Conexao.GetConnection())
            {
                var sql = @"UPDATE Funcionario SET Nome=@Nome, CPF=@CPF, Cargo=@Cargo,
                            Salario=@Salario, FazendaId=@FazendaId WHERE Id=@Id";
                conn.Execute(sql, f);
            }
        }

        public void Deletar(int id)
        {
            using (var conn = Conexao.GetConnection())
            {
                conn.Execute("DELETE FROM Funcionario WHERE Id = @Id", new { Id = id });
            }
        }
    }

    public class RepositorioCultura
    {
        public List<Cultura> ListarTodos()
        {
            using (var conn = Conexao.GetConnection())
            {
                return conn.Query<Cultura>("SELECT * FROM Cultura ORDER BY Nome").ToList();
            }
        }

        public void Inserir(Cultura c)
        {
            using (var conn = Conexao.GetConnection())
            {
                var sql = @"INSERT INTO Cultura (Nome, Tipo, TempoMedioColheitaDias, Descricao)
                            VALUES (@Nome, @Tipo, @TempoMedioColheitaDias, @Descricao)";
                conn.Execute(sql, c);
            }
        }

        public void Editar(Cultura c)
        {
            using (var conn = Conexao.GetConnection())
            {
                var sql = @"UPDATE Cultura SET Nome=@Nome, Tipo=@Tipo,
                            TempoMedioColheitaDias=@TempoMedioColheitaDias,
                            Descricao=@Descricao WHERE Id=@Id";
                conn.Execute(sql, c);
            }
        }

        public void Deletar(int id)
        {
            using (var conn = Conexao.GetConnection())
            {
                conn.Execute("DELETE FROM Cultura WHERE Id = @Id", new { Id = id });
            }
        }
    }

    public class RepositorioColheita
    {
        public List<Colheita> ListarTodos()
        {
            using (var conn = Conexao.GetConnection())
            {
                var sql = @"SELECT c.*, f.Id, f.Nome, cu.Id, cu.Nome
                            FROM Colheita c
                            INNER JOIN Fazenda f ON c.FazendaId = f.Id
                            INNER JOIN Cultura cu ON c.CulturaId = cu.Id
                            ORDER BY c.DataPlantio DESC";

                var result = conn.Query<Colheita, Fazenda, Cultura, Colheita>(sql,
                    (col, faz, cult) => { col.Fazenda = faz; col.Cultura = cult; return col; },
                    splitOn: "Id,Id");

                return result.ToList();
            }
        }

        public void Inserir(Colheita c)
        {
            using (var conn = Conexao.GetConnection())
            {
                var sql = @"INSERT INTO Colheita (FazendaId, CulturaId, DataPlantio,
                            DataColheita, QuantidadeToneladas, Observacoes)
                            VALUES (@FazendaId, @CulturaId, @DataPlantio,
                            @DataColheita, @QuantidadeToneladas, @Observacoes)";
                conn.Execute(sql, c);
            }
        }

        public void Editar(Colheita c)
        {
            using (var conn = Conexao.GetConnection())
            {
                var sql = @"UPDATE Colheita SET FazendaId=@FazendaId, CulturaId=@CulturaId,
                            DataPlantio=@DataPlantio, DataColheita=@DataColheita,
                            QuantidadeToneladas=@QuantidadeToneladas,
                            Observacoes=@Observacoes WHERE Id=@Id";
                conn.Execute(sql, c);
            }
        }

        public void Deletar(int id)
        {
            using (var conn = Conexao.GetConnection())
            {
                conn.Execute("DELETE FROM Colheita WHERE Id = @Id", new { Id = id });
            }
        }

        public List<Colheita> ListarPorFazenda(int fazendaId)
        {
            using (var conn = Conexao.GetConnection())
            {
                var sql = "SELECT * FROM Colheita WHERE FazendaId = @FazendaId";
                return conn.Query<Colheita>(sql, new { FazendaId = fazendaId }).ToList();
            }
        }
    }
}
