using MvcApiFarm.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
namespace MvcApiFarm.Helper{
    public class Sessao:ISessao{
        private readonly IHttpContextAccessor _httpContext;
        public Sessao(IHttpContextAccessor httpContext){
            _httpContext=httpContext;
        }
        public void CriarSessaodoUsuario(Funcionario funcionario){
            string valor=JsonConvert.SerializeObject(funcionario); //serializa objeto
            _httpContext.HttpContext.Session.SetString("sessaoUsuarioLogado",valor);
        }
        public void RemoverSessaoUsuario(){
            _httpContext.HttpContext.Session.Remove("sessaoUsuarioLogado");
        }
        public Funcionario BuscarSessaoDoUsuario(){
            string sessaoUsuario=_httpContext.HttpContext.Session.GetString("sessaoUsuarioLogado");
            if(string.IsNullOrEmpty(sessaoUsuario)){
                return null;
            }
            return JsonConvert.DeserializeObject<Funcionario>(sessaoUsuario);
        }
    }
}