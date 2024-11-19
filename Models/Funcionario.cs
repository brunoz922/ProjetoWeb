namespace MvcApiFarm.Models;

public class Funcionario
{
    public int Id { get; set; }
    public int FazendaId { get; set; }
    public required Fazenda Fazenda { get; set; }
    public string? Nome { get; set; }
    public string? Cpf { get; set; }
    public string? Telefone { get; set; }
    public string Email { get; set; }
    public string? Funcao { get; set; }
    public decimal? Salario { get; set; }
    public string Senha { get; set; }
    public bool SenhaValida(string senha){ //retorna valor booleano com base na comparação entre senha atual e senha fornecida
        return BCrypt.Net.BCrypt.Verify(senha, Senha);
    }
}