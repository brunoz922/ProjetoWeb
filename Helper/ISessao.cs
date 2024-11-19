using MvcApiFarm.Models;
namespace MvcApiFarm.Helper{
    public interface ISessao{
        void CriarSessaodoUsuario(Funcionario funcionario);
        void RemoverSessaoUsuario();
        Funcionario BuscarSessaoDoUsuario();
    }
}