namespace MvcApiFarm.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Text.Json.Serialization;

public class ItemVenda
{
    public int Id { get; set; }

    public int VendaId { get; set; }
    [JsonIgnore] [ValidateNever] public  Venda Venda { get; set; }

    public int RecursoId { get; set; }
    [JsonIgnore] [ValidateNever] public  Recurso Recurso { get; set; }

    public int Quantidade { get; set; }
    public decimal Preco { get; set; }
    public decimal SubTotal => Quantidade * Preco;
}