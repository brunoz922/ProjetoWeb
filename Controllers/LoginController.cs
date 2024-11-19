using MvcApiFarm.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using MvcApiFarm.Helper;

namespace MvcApiFarm.Controllers{
    public class LoginController:Controller
    
    {
        private readonly ApplicationDbContext context;
        private readonly ISessao _sessao;
        public LoginController(ApplicationDbContext context, ISessao sessao){
            this.context=context;
            _sessao=sessao;

        }
        //busca funcionario por email
        public Funcionario BuscarPorLogin(string email){
           Funcionario usuario=context.Funcionarios.FirstOrDefault(x=> x.Email == email);
            return usuario;
        }
        public IActionResult Index(){
            //se usuario estiver logado, redireciona para home
            if(_sessao.BuscarSessaoDoUsuario()!=null){
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        public IActionResult Sair(){
            _sessao.RemoverSessaoUsuario();
            return RedirectToAction("Index","Login");
        }
        [HttpPost]
        public IActionResult Entrar(LoginModel loginmodel)
        {
            try{
                if(ModelState.IsValid){
                    Funcionario usuario=BuscarPorLogin(loginmodel.Email); //ta retornando
                    if(usuario!=null) //ta retornando
                    {
                    if(usuario.SenhaValida(loginmodel.Senha)){
                            _sessao.CriarSessaodoUsuario(usuario);
                            return RedirectToAction("Index","Home");
                        }else{
                            ModelState.AddModelError("Senha", "Senha incorreta");
                        }

                    }else{
                        ModelState.AddModelError("Senha", "Email ou senha incorretos");
                    }
                }
                return View("Index");
            }
            catch(Exception erro)
            {
                TempData["MensagemErro"]=$"Não foi possível realizar login, tente novamente detalhe do erro:{erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}