using MvcApiFarm.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MvcApiFarm.Controllers;

public class ManutencoesController : Controller
{
    private readonly ApplicationDbContext context;

    public ManutencoesController(ApplicationDbContext context)
    {
        this.context = context;
    }

    public IActionResult Index()
    {
        var listaManutencoes = context.Manutencoes
            .Include(f => f.Recurso)
            .Include(f => f.Funcionario)
            .ToList();
        return View(listaManutencoes);
    }

    public IActionResult Criar()
    {
        SetListaTipos();
        ViewBag.Fazendas = new SelectList(context.Fazendas, "Id", "Nome");
        return View();
    }

    [HttpPost]
    public IActionResult Criar(Manutencao manutencao)
    {
        SetListaTipos();
        context.Manutencoes.Add(manutencao);
        context.SaveChanges();

        return RedirectToAction("Index");
    }


    public IActionResult Editar(int id)
    {
        var manutencao = context.Manutencoes.Find(id);
        if (manutencao == null) return NotFound();
        SetListaTipos();
        return View(manutencao);
    }

    [HttpPost]
    public IActionResult Editar(Manutencao manutencao)
    {
        var manutencaoExistente = context.Manutencoes.Find(manutencao.Id);
        if (manutencaoExistente == null) return NotFound();
        SetListaTipos();
        manutencaoExistente.RecursoId = manutencao.RecursoId;
        manutencaoExistente.FuncionarioId = manutencao.FuncionarioId;
        manutencaoExistente.Data = manutencao.Data;
        manutencaoExistente.Tipo = manutencao.Tipo;
        manutencaoExistente.Descricao = manutencao.Descricao;
        manutencaoExistente.Custos = manutencao.Custos;
        manutencaoExistente.Status = manutencao.Status;
        context.Manutencoes.Update(manutencaoExistente);
        context.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Remover(int id)
    {
        var manutencao = context.Manutencoes
            .Include(f => f.Funcionario)
            .Include(f => f.Recurso)
            .FirstOrDefault(f => f.Id == id);
        if (manutencao == null) return NotFound();
        return View(manutencao);
    }

    [HttpPost]
    public IActionResult Remover(Manutencao manutencao)
    {
        var manutencaoExistente = context.Manutencoes.Find(manutencao.Id);
        if (manutencaoExistente == null) return NotFound();

        context.Manutencoes.Remove(manutencaoExistente);
        context.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Detalhes(int id)
    {
        var manutencao = context.Manutencoes
            .Include(f => f.Funcionario) 
            .Include(f => f.Recurso) 
            .FirstOrDefault(f => f.Id == id);
        if (manutencao == null) return NotFound();
        return View(manutencao);
    }

    private void SetListaTipos()
    {
        var ListaStatus = new List<string>
        {
            "Em processo",
            "Finalizada"        
            };
        ViewBag.ManutencaoStatus = new SelectList(ListaStatus);

        var ListaTipos = new List<string>
        {
            "Preventiva",
            "Corretiva",
            "Preditiva"
        };
        ViewBag.ManutencaoTipo = new SelectList(ListaTipos);
        
        ViewBag.Recursos = new SelectList(context.Recursos.Where(r=>r.Tipo=="Maquinário"), "Id", "NumeroSerie");
        ViewBag.Funcionarios = new SelectList(context.Funcionarios, "Id", "Nome");
    }
}