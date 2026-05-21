# 🌾 AgroSistema — Guia de Implementação

## Estrutura do Projeto

```
SuaSolution/
  AgroSistema/
    Models/
      Base.cs            ← Interface IEntidade + classe abstrata Pessoa
      Produtor.cs        ← Herda de Pessoa, tem List<Fazenda>
      Fazenda.cs         ← IEntidade, tem List<Funcionario>
      OutrasEntidades.cs ← Funcionario, Cultura, Colheita
    Repositories/
      Conexao.cs                ← String de conexão
      RepositorioProdutor.cs    ← CRUD Produtor (Dapper)
      RepositorioFazenda.cs     ← CRUD Fazenda (Dapper)
      OutrosRepositorios.cs     ← CRUD Funcionario, Cultura, Colheita
    Forms/
      FormPrincipal.cs + .Designer.cs   ← Tela Menu Principal
      FormProdutor.cs + .Designer.cs    ← CRUD Produtores
      FormFazenda.cs + .Designer.cs     ← CRUD Fazendas (ComboBox Estados)
      FormFuncionario.cs + .Designer.cs ← CRUD Funcionários
      FormCultura.cs + .Designer.cs     ← CRUD Culturas
      FormColheita.cs + .Designer.cs    ← CRUD Colheitas
    Database/
      criar_banco.sql    ← Script para criar banco e tabelas
    Program.cs           ← Entry point
```

---

## ✅ PASSO A PASSO DE IMPLEMENTAÇÃO

### PASSO 1 — Banco de Dados (MySQL)

1. Instale o **MySQL** se não tiver (pode usar XAMPP/WAMP que já vem com MySQL)
2. Abra o **MySQL Workbench** ou phpMyAdmin
3. Execute o arquivo `Database/criar_banco.sql`
4. Vai criar o banco `AgroSistema` com 5 tabelas e dados iniciais em Cultura

### PASSO 2 — Pacotes NuGet

Com o projeto aberto no Visual Studio, abra o **Package Manager Console**:
`Ferramentas > Gerenciador de Pacotes NuGet > Console do Gerenciador de Pacotes`

Execute os dois comandos:
```
Install-Package Dapper
Install-Package MySql.Data
```

### PASSO 3 — Namespace do Projeto

Certifique-se que o namespace padrão do seu projeto é `AgroSistema`.
Para verificar: clique com botão direito no projeto > Propriedades > aba Aplicativo > "Namespace padrão"

Se o seu projeto tem outro nome, você tem duas opções:
- **Opção A:** Mudar o namespace padrão do projeto para `AgroSistema`
- **Opção B:** Substituir `AgroSistema` pelo nome do seu projeto em todos os arquivos

### PASSO 4 — Criar as Pastas no Visual Studio

No Solution Explorer, crie as pastas:
- Clique direito no projeto > Adicionar > Nova Pasta
- Crie: `Models`, `Repositories`, `Forms`, `Database`

### PASSO 5 — Adicionar os Arquivos

Para cada arquivo `.cs`:
1. Clique direito na pasta correspondente
2. Adicionar > Item Existente (ou "Novo Item" e cole o código)

**Ordem recomendada:**
1. `Models/Base.cs`
2. `Models/Produtor.cs`
3. `Models/Fazenda.cs`
4. `Models/OutrasEntidades.cs`
5. `Repositories/Conexao.cs`
6. `Repositories/RepositorioProdutor.cs`
7. `Repositories/RepositorioFazenda.cs`
8. `Repositories/OutrosRepositorios.cs`
9. `Forms/FormPrincipal.cs` + `FormPrincipal.Designer.cs`
10. `Forms/FormProdutor.cs` + `FormProdutor.Designer.cs`
11. `Forms/FormFazenda.cs` + `FormFazenda.Designer.cs`
12. `Forms/FormFuncionario.cs` + `FormFuncionario.Designer.cs`
13. `Forms/FormCultura.cs` + `FormCultura.Designer.cs`
14. `Forms/FormColheita.cs` + `FormColheita.Designer.cs`

Para arquivos que são par (`.cs` + `.Designer.cs`), o Visual Studio os associa automaticamente se estiverem na mesma pasta.

### PASSO 6 — Substituir o Form1 padrão

O Visual Studio cria um `Form1.cs` por padrão. Você pode:
- Deletar o `Form1.cs` (e `Form1.Designer.cs`)
- Substituir o `Program.cs` pelo arquivo fornecido

### PASSO 7 — Configurar a String de Conexão

Abra `Repositories/Conexao.cs` e ajuste a linha:
```csharp
private static readonly string _connectionString =
    "Server=localhost;Database=AgroSistema;Uid=root;Pwd=;";
```

- `Server=localhost` → geralmente certo para instalação local
- `Database=AgroSistema` → nome do banco criado no passo 1
- `Uid=root` → usuário do MySQL
- `Pwd=` → senha do MySQL (deixe vazio se não tiver senha)

### PASSO 8 — Compilar e Executar

Pressione `F5` ou `Ctrl+F5` para executar.

---

## 🎯 Requisitos Atendidos

| Requisito | Implementação |
|-----------|---------------|
| 5 telas/entidades | Produtor, Fazenda, Funcionário, Cultura, Colheita |
| ListBox | Em TODAS as telas mostrando os registros |
| ComboBox | Estados (Fazenda), Cargo (Funcionário), Tipo (Cultura), Produtor, Fazenda, Cultura |
| Tratamento de exceções | try/catch em todos os botões |
| Validação nos botões | Verificações antes de salvar em todos os forms |
| Herança | `Produtor` e `Funcionario` herdam de `Pessoa` |
| Interface | `IEntidade` implementada em todas as entidades |
| Lista/Coleção | `Produtor` tem `List<Fazenda>`, `Fazenda` tem `List<Funcionario>` |
| Repository Pattern | Uma classe repositório por entidade com inserir/editar/deletar |
| Dapper | Usado em todos os repositórios |
| BD Relacional + Script SQL | MySQL com arquivo `criar_banco.sql` |

---

## ⚠️ Problemas Comuns

**"Could not load file or assembly MySql.Data"**
→ Reinstale o pacote: `Install-Package MySql.Data`

**"Unable to connect to MySQL"**
→ Verifique se o MySQL está rodando (XAMPP: clique Start no MySQL)
→ Confirme usuário e senha em `Conexao.cs`

**Erro de namespace**
→ Verifique se o namespace padrão do projeto é `AgroSistema`
→ Se não for, use Ctrl+H para substituir `AgroSistema` pelo nome correto

**Arquivo .Designer.cs não associado ao Form**
→ Edite o `.csproj` manualmente ou use "Mostrar Todos os Arquivos" no Solution Explorer
