namespace MvcApiFarm.Models;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
public class Compra
{
    public int Id { get; set; }
    public int FornecedorId { get; set; }
    [ValidateNever] [JsonIgnore] public Fornecedor Fornecedor { get; set; }
    public int FuncionarioId { get; set; }
    [ValidateNever] [JsonIgnore] public Funcionario Funcionario { get; set; }

    public DateTime DataCompra { get; set; }
    public string Status { get; set; }

    public string FormaPagamento { get; set; }

    public string FormaEntrega { get; set; }

    public decimal Total => ItensCompra?.Sum(item => item.SubTotal) ?? 0;

    public ICollection<ItemCompra> ItensCompra { get; set; }
}