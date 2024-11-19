using System.ComponentModel.DataAnnotations;
namespace MvcApiFarm.Models
{
    public class LoginModel
    {
        public string Email {get;set;}
        public string Senha {get;set;}
    }
}