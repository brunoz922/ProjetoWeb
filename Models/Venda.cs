namespace MvcApiFarm.Models;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

public class Venda
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    [ValidateNever] [JsonIgnore] public Cliente Cliente { get; set; }    
    public DateTime DataVenda { get; set; }
    public string Status { get; set; }

    public string FormaPagamento { get; set; }

    public string FormaEntrega { get; set; }

    public decimal Total => ItensVenda?.Sum(item => item.SubTotal) ?? 0;

    public ICollection<ItemVenda> ItensVenda { get; set; }
}