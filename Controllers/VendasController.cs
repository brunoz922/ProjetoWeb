using MvcApiFarm.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace MvcApiFarm.Controllers;

public class VendasController : Controller
{
    private readonly ApplicationDbContext context;

    public VendasController(ApplicationDbContext context)
    {
        this.context = context;
    }

    public IActionResult Index()
    {
        var listaVendas = context.Vendas
            .Include(f => f.Cliente)
            .ToList();
        return View(listaVendas);
    }

    public IActionResult Criar()
    {
        ListaRecursos();
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Criar(Venda venda)
    {
        ModelState.Clear();
        Console.WriteLine($"Venda: {JsonConvert.SerializeObject(venda)}");

        if (ModelState.IsValid)
        {
            Console.WriteLine("Venda: Válido");
            try
            {
                // Adiciona o plantio
                context.Vendas.Add(venda);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Erro ao salvar a venda: {ex.Message}");
            }
        }
        else
        {
            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                Console.WriteLine($"Erro de validação: {error.ErrorMessage}");
        }

        ListaRecursos();
        return View(venda);
    }

    public IActionResult Editar(int id)
    {
        var venda = context.Vendas
            .Include(p => p.ItensVenda)
            .ThenInclude(ip => ip.Recurso)
            .FirstOrDefault(p => p.Id == id);

        if (venda == null) return NotFound();

        ListaRecursos();
        return View(venda);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Editar(Venda venda)
    {
        Console.WriteLine($"Venda: {JsonConvert.SerializeObject(venda)}");

        if (ModelState.IsValid)
            try
            {
                // Busca o plantio existente no banco de dados
                var vendaExistente = await context.Vendas
                    .Include(p => p.ItensVenda)
                    .ThenInclude(ip => ip.Recurso)
                    .FirstOrDefaultAsync(p => p.Id == venda.Id);

                if (vendaExistente == null) return NotFound();

                // Atualiza os campos do plantio existente
                vendaExistente.DataVenda = venda.DataVenda;
                vendaExistente.ClienteId = venda.ClienteId;
                vendaExistente.Status = venda.Status;
                vendaExistente.FormaPagamento = venda.FormaPagamento;
                vendaExistente.FormaEntrega = venda.FormaEntrega;

                // Identifica e remove os itens antigos que não estão mais presentes no plantio atualizado
                var itensParaRemover = vendaExistente.ItensVenda
                    .Where(itemExistente => !venda.ItensVenda.Any(i => i.Id == itemExistente.Id))
                    .ToList();

                foreach (var item in itensParaRemover) context.ItemsVenda.Remove(item);

                // Atualiza itens existentes e adiciona novos itens
                foreach (var item in venda.ItensVenda)
                    if (item.Id == 0)
                    {
                        // Adiciona novo item de plantio
                        vendaExistente.ItensVenda.Add(new ItemVenda
                        {
                            
                            RecursoId = item.RecursoId,
                            Quantidade = item.Quantidade,
                            VendaId = vendaExistente.Id,
                            Preco=item.Preco

                        });
                    }
                    else
                    {
                        // Atualiza o item existente
                        var itemExistente = vendaExistente.ItensVenda
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
                venda.ItensVenda = await context.ItemsVenda
                    .Where(ip => ip.VendaId == venda.Id)
                    .Include(ip => ip.Recurso)
                    .ToListAsync();

                return View(venda);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Erro ao atualizar a venda: {ex.Message}");
            }
        else
            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                Console.WriteLine($"Erro de validação: {error.ErrorMessage}");

        return RedirectToAction(nameof(Index));
    }


    public IActionResult Remover(int id)
    {
        var venda = context.Vendas
            .Include(f => f.Cliente)
            .Include(f=>f.ItensVenda)
                .ThenInclude(p=>p.Recurso)
            .FirstOrDefault(f => f.Id == id);

        if (venda == null) return NotFound();

        return View(venda);
    }

    [HttpPost]
    public IActionResult Remover(Venda venda)
    {
        var vendaExistente = context.Vendas
            .Include(f => f.Cliente)
            .Include(p => p.ItensVenda)
                .ThenInclude(p=> p.Recurso)
            .FirstOrDefault(f => f.Id == venda.Id);
        if (vendaExistente == null) return NotFound();

        context.Vendas.Remove(vendaExistente);
        context.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Detalhes(int id)
    {
        var venda = context.Vendas
            .Include(f => f.Cliente)
            .Include(p => p.ItensVenda)
                .ThenInclude(p=> p.Recurso)
            .FirstOrDefault(f => f.Id == id);

        if (venda == null) return NotFound();

        return View(venda);
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
        ViewBag.Clientes = new SelectList(context.Clientes, "Id", "Nome");
        ViewBag.Recursos = context.Recursos
            .Where(r => r.Tipo == "Produto")
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