using MvcApiFarm.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cryptography.KeyDerivation; // Para hash de senha
using System.Security.Cryptography;


namespace MvcApiFarm.Controllers;

public class ApiController(ApplicationDbContext context) : Controller
{
        // Método de login para FUNCIONARIO
        [HttpPost("login/funcionario")]
        public IActionResult LoginFuncionario([FromBody] LoginModel loginModel)
        {
            // Encontre o funcionário pelo email
            var funcionario = context.Funcionarios.SingleOrDefault(f => f.Email == loginModel.Email);
            if (funcionario == null)
            {
                return Unauthorized("Email ou senha inválidos.");
            }

            // Validação da senha
            if (!funcionario.SenhaValida(loginModel.Senha))
            {
                return Unauthorized("Email ou senha inválidos.");
            }

            // Retorne os dados do funcionário
            return Ok(new
            {
                message = "Login de funcionário bem-sucedido!",
                funcionarioId = funcionario.Id,
                nome = funcionario.Nome,
            });
        }

    [HttpPut]
    public IActionResult TestePut()
    {
        // Apenas retorna uma mensagem de sucesso para teste
        return Ok("Rota PUT funcionando corretamente!");
    }
    //RECURSOS
    public List<Recurso> GetRecursos()
    {
        var listaRecursos = context.Recursos.ToList();
        return listaRecursos;
    }

    [HttpPost]
    [Route("Api/CreateRecurso")]
    public IActionResult CreateRecurso([FromBody] Recurso recurso)
    {
        var recursodb = context.Recursos.Add(recurso);
        context.SaveChanges();
        return CreatedAtAction(nameof(CreateRecurso), new { id = recursodb.Entity.Id }, recursodb.Entity);
    }

    [HttpPut]
    public IActionResult UpdateRecurso(int id, [FromBody] Recurso recurso)
    {
        // Verifica se o ID passado na URL � o mesmo do cliente no corpo
        if (id != recurso.Id) return BadRequest("ID do recurso na URL e no corpo não coincidem.");

        var recursodb = context.Recursos.Find(id);
        if (recursodb == null) return NotFound();

        recursodb.Nome = recurso.Nome;
        recursodb.Preco = recurso.Preco;
        recursodb.Quantidade = recurso.Quantidade;
        recursodb.UnidadeMedida = recurso.UnidadeMedida;
        recursodb.Tipo = recurso.Tipo;
        if(recurso.Tipo=="Maquinário"){
        recursodb.NumeroSerie = recurso.NumeroSerie;
        recursodb.DataAquisicao = recurso.DataAquisicao;
        recursodb.Status = recurso.Status;
        }

        context.Recursos.Update(recursodb);
        context.SaveChanges();
        return NoContent();
    }
    //FAZENDAS
     public List<Fazenda> GetFazendas()
    {
        var listaFazendas = context.Fazendas.ToList();
        return listaFazendas;
    }

    [HttpPost]
    public IActionResult CreateFazenda([FromBody] Fazenda fazenda)
    {
        var fazendadb = context.Fazendas.Add(fazenda);
        context.SaveChanges();
        return CreatedAtAction(nameof(CreateFazenda), new { id = fazendadb.Entity.Id }, fazendadb.Entity);
    }

    [HttpPut]
    public IActionResult UpdateFazenda(int id, [FromBody] Fazenda fazenda)
    {
        // Verifica se o ID passado na URL � o mesmo do cliente no corpo
        if (id != fazenda.Id) return BadRequest("ID da fazenda na URL e no corpo não coincidem.");

        var fazendadb = context.Fazendas.Find(id);
        if (fazendadb == null) return NotFound();

        fazendadb.Nome = fazenda.Nome;
        fazendadb.Hectares = fazenda.Hectares;
        fazendadb.Email = fazenda.Email;
        fazendadb.Endereco = fazenda.Endereco;
        fazendadb.Telefone = fazenda.Telefone;

        context.Fazendas.Update(fazendadb);
        context.SaveChanges();
        return NoContent();
    }
    //FORNECEDORES
    public List<Fornecedor> GetFornecedores()
    {
        var listaFornecedores = context.Fornecedores.ToList();
        return listaFornecedores;
    }

    [HttpPost]
    public IActionResult CreateFornecedor([FromBody] Fornecedor fornecedor)
    {
        var fornecedordb = context.Fornecedores.Add(fornecedor);
        context.SaveChanges();
        return CreatedAtAction(nameof(CreateFornecedor), new { id = fornecedordb.Entity.Id }, fornecedordb.Entity);
    }

    [HttpPut]
    public IActionResult UpdateFornecedor(int id, [FromBody] Fornecedor fornecedor)
    {
        // Verifica se o ID passado na URL � o mesmo do cliente no corpo
        if (id != fornecedor.Id) return BadRequest("ID do fornecedor na URL e no corpo não coincidem.");

        var fornecedordb = context.Fornecedores.Find(id);
        if (fornecedordb == null) return NotFound();

        fornecedordb.Nome = fornecedor.Nome;
        fornecedordb.Cnpj = fornecedor.Cnpj;
        fornecedordb.Representante = fornecedor.Representante;
        fornecedordb.Telefone = fornecedor.Telefone;

        context.Fornecedores.Update(fornecedordb);
        context.SaveChanges();
        return NoContent();
    }
    //AREA PLANTIO
    public List<AreaPlantio> GetAreasPlantio()
    {
        var listaAreasPlantio = context.AreasPlantio.ToList();
        return listaAreasPlantio;
    }

    [HttpPost]
    public IActionResult CreateAreaPlantio([FromBody] AreaPlantio areaPlantio)
    {
        var areaPlantiodb = context.AreasPlantio.Add(areaPlantio);
        context.SaveChanges();
        return CreatedAtAction(nameof(CreateAreaPlantio), new { id = areaPlantiodb.Entity.Id }, areaPlantiodb.Entity);
    }

    [HttpPut]
    public IActionResult UpdateAreaPlantio(int id, [FromBody] AreaPlantio areaPlantio)
    {
        // Verifica se o ID passado na URL � o mesmo do cliente no corpo
        if (id != areaPlantio.Id) return BadRequest("ID da area na URL e no corpo não coincidem.");

        var areaPlantiodb = context.AreasPlantio.Find(id);
        if (areaPlantiodb == null) return NotFound();

        areaPlantiodb.Nome = areaPlantio.Nome;
        areaPlantiodb.FazendaId = areaPlantio.FazendaId;
        areaPlantiodb.Hectares = areaPlantio.Hectares;
        areaPlantiodb.Localizacao = areaPlantio.Localizacao;
        areaPlantiodb.Status = areaPlantio.Status;
        areaPlantiodb.Descricao = areaPlantio.Descricao;


        context.AreasPlantio.Update(areaPlantiodb);
        context.SaveChanges();
        return NoContent();
    }
    //MANUTENCOES
    public List<Manutencao> GetManutencoes()
    {
        var listaManutencoes = context.Manutencoes.ToList();
        return listaManutencoes;
    }

    [HttpPost]
    public IActionResult CreateManutencao([FromBody] Manutencao manutencao)
    {
        var manutencaodb = context.Manutencoes.Add(manutencao);
        context.SaveChanges();
        return CreatedAtAction(nameof(CreateManutencao), new { id = manutencaodb.Entity.Id }, manutencaodb.Entity);
    }

    [HttpPut]
    public IActionResult UpdateManutencao(int id, [FromBody] Manutencao manutencao)
    {
        // Verifica se o ID passado na URL � o mesmo do cliente no corpo
        if (id != manutencao.Id) return BadRequest("ID da manutenção na URL e no corpo não coincidem.");

        var manutencaodb = context.Manutencoes.Find(id);
        if (manutencaodb == null) return NotFound();

        manutencaodb.Data = manutencao.Data;
        manutencaodb.RecursoId = manutencao.RecursoId;
        manutencaodb.FuncionarioId = manutencao.FuncionarioId;
        manutencaodb.Tipo = manutencao.Tipo;
        manutencaodb.Custos = manutencao.Custos;
        manutencaodb.Status = manutencao.Status;
        manutencaodb.Descricao = manutencao.Descricao;


        context.Manutencoes.Update(manutencaodb);
        context.SaveChanges();
        return NoContent();
    }
}