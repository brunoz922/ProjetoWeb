using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using MvcApiFarm.Models;
namespace MvcApiFarm.ViewComponents{
    public class Menu:ViewComponent{
        public async Task<IViewComponentResult> InvokeAsync(){
            string sessaoUsuario=HttpContext.Session.GetString("sessaoUsuarioLogado");
            if(string.IsNullOrEmpty(sessaoUsuario)){
                return null;
            }
            Funcionario usuario = JsonConvert.DeserializeObject<Funcionario>(sessaoUsuario);
            return View(usuario);
        }
    }
}