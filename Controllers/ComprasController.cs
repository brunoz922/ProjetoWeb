using MvcApiFarm.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace MvcApiFarm.Controllers;

public class ComprasController : Controller
{
    private readonly ApplicationDbContext context;

    public ComprasController(ApplicationDbContext context)
    {
        this.context = context;
    }

    public IActionResult Index()
    {
        var listaCompras = context.Compras
            .Include(f => f.Fornecedor)
            .Include(f=>f.Funcionario)
            .ToList();
        return View(listaCompras);
    }

    public IActionResult Criar()
    {
        ListaRecursos();
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Criar(Compra compra)
    {
        ModelState.Clear();
        Console.WriteLine($"Compra: {JsonConvert.SerializeObject(compra)}");

        if (ModelState.IsValid)
        {
            Console.WriteLine("Compra: Válido");
            try
            {
                // Adiciona o plantio
                context.Compras.Add(compra);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Erro ao salvar a compra: {ex.Message}");
            }
        }
        else
        {
            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                Console.WriteLine($"Erro de validação: {error.ErrorMessage}");
        }

        ListaRecursos();
        return View(compra);
    }

    public IActionResult Editar(int id)
    {
        var compra = context.Compras
            .Include(p => p.ItensCompra)
            .ThenInclude(ip => ip.Recurso)
            .FirstOrDefault(p => p.Id == id);

        if (compra == null) return NotFound();

        ListaRecursos();
        return View(compra);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Editar(Compra compra)
    {
        Console.WriteLine($"Compra: {JsonConvert.SerializeObject(compra)}");

        if (ModelState.IsValid)
            try
            {
                // Busca o plantio existente no banco de dados
                var compraExistente = await context.Compras
                    .Include(p => p.ItensCompra)
                    .ThenInclude(ip => ip.Recurso)
                    .FirstOrDefaultAsync(p => p.Id == compra.Id);

                if (compraExistente == null) return NotFound();

                // Atualiza os campos do plantio existente
                compraExistente.DataCompra = compra.DataCompra;
                compraExistente.FornecedorId = compra.FornecedorId;
                compraExistente.FuncionarioId = compra.FuncionarioId;
                compraExistente.Status = compra.Status;
                compraExistente.FormaPagamento = compra.FormaPagamento;
                compraExistente.FormaEntrega = compra.FormaEntrega;


                // Identifica e remove os itens antigos que não estão mais presentes no plantio atualizado
                var itensParaRemover = compraExistente.ItensCompra
                    .Where(itemExistente => !compra.ItensCompra.Any(i => i.Id == itemExistente.Id))
                    .ToList();

                foreach (var item in itensParaRemover) context.ItemsCompra.Remove(item);

                // Atualiza itens existentes e adiciona novos itens
                foreach (var item in compra.ItensCompra)
                    if (item.Id == 0)
                    {
                        // Adiciona novo item de plantio
                        compraExistente.ItensCompra.Add(new ItemCompra
                        {
                            
                            RecursoId = item.RecursoId,
                            Quantidade = item.Quantidade,
                            CompraId = compraExistente.Id,
                            Preco=item.Preco

                        });
                    }
                    else
                    {
                        // Atualiza o item existente
                        var itemExistente = compraExistente.ItensCompra
                            .FirstOrDefault(i => i.Id == item.Id);

                        if (itemExistente != null)
                        {
                            itemExistente.RecursoId = item.RecursoId;
                            itemExistente.Quantidade = item.Quantidade;
                            itemExistente.Preco=item.Preco;
                        }
                    }

                await context.SaveChangesAsync();

                ListaRecursos();
                compra.ItensCompra = await context.ItemsCompra
                    .Where(ip => ip.CompraId == compra.Id)
                    .Include(ip => ip.Recurso)
                    .ToListAsync();

                return View(compra);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Erro ao atualizar a compra: {ex.Message}");
            }
        else
            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                Console.WriteLine($"Erro de validação: {error.ErrorMessage}");

        return RedirectToAction(nameof(Index));
    }


    public IActionResult Remover(int id)
    {
        var compra = context.Compras
            .Include(f => f.Fornecedor)
            .Include(f=> f.Funcionario)
            .Include(f=>f.ItensCompra)
                .ThenInclude(p=>p.Recurso)
            .FirstOrDefault(f => f.Id == id);

        if (compra == null) return NotFound();

        return View(compra);
    }

    [HttpPost]
    public IActionResult Remover(Compra compra)
    {
        var compraExistente = context.Compras
            .Include(f => f.Fornecedor)
            .Include(f=> f.Funcionario)
            .Include(p => p.ItensCompra)
                .ThenInclude(p=> p.Recurso)
            .FirstOrDefault(f => f.Id == compra.Id);
        if (compraExistente == null) return NotFound();

        context.Compras.Remove(compraExistente);
        context.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Detalhes(int id)
    {
        var compra = context.Compras
            .Include(f => f.Fornecedor)
            .Include(f => f.Funcionario)
            .Include(p => p.ItensCompra)
                .ThenInclude(p=> p.Recurso)
            .FirstOrDefault(f => f.Id == id);

        if (compra == null) return NotFound();

        return View(compra);
    }

    private void ListaRecursos()
    {
         var ListaFormaPagamento = new List<string>
        {
            "Cartão de Débito",
            "Cartão de Crédito",
            "Boleto",
            "PIX"
        };
        ViewBag.FormaPagamento = new SelectList(ListaFormaPagamento);
        var ListaFormaEntrega = new List<string>
        {
            "Entrega",
            "Retirada"
        };
        ViewBag.FormaEntrega = new SelectList(ListaFormaEntrega);
        var ListaStatus = new List<string>
        {
            "Aberta",
            "Fechada"
        };
        ViewBag.Status = new SelectList(ListaStatus);
        ViewBag.Fornecedores = new SelectList(context.Fornecedores, "Id", "Nome");
        ViewBag.Funcionarios = new SelectList(context.Funcionarios, "Id", "Nome");
        ViewBag.Recursos = context.Recursos
            .Select(r => new {
                Id = r.Id,
                Nome = r.Nome,
                Preco = r.Preco
            }).ToList();

    }

    [HttpGet]
    public async Task<IActionResult> GetPrecoRecurso(int idRecurso)
    {
        var recurso = await context.Recursos.FindAsync(idRecurso);
        if (recurso == null) return NotFound();
        return Json(new { preco = recurso.Preco, quantidadeDisponivel = recurso.Quantidade });
    }

    [HttpGet]
    public async Task<IActionResult> GetSerieRecurso(int idRecurso)
    {
        var recurso = await context.Recursos.FindAsync(idRecurso);
        if (recurso == null) return NotFound();
        return Json(recurso.NumeroSerie);
    }
}