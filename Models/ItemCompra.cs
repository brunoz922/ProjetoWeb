namespace MvcApiFarm.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Text.Json.Serialization;
public class ItemCompra
{
    public int Id { get; set; }

    public int CompraId { get; set; }
    [JsonIgnore] [ValidateNever] public Compra Compra { get; set; }

    public int RecursoId { get; set; }
    [JsonIgnore] [ValidateNever] public Recurso Recurso { get; set; }

    public int Quantidade { get; set; }
    public DateTime PrevisaoEntrega { get; set; }
    public decimal Preco { get; set; }
    public decimal SubTotal => Quantidade * Preco;
}