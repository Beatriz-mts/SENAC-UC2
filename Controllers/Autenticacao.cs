using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Biblioteca.Controllers
{
    public class Autenticacao
    {
        public static void CheckLogin(Controller controller)
        {   
            if(string.IsNullOrEmpty(controller.HttpContext.Session.GetString("Login")))
            {
                controller.Request.HttpContext.Response.Redirect("/Home/Login");
            }
        }

        public static bool verificarLoginSenha(string login, string senha, Controller controller)
        {
            using(BibliotecaContext bd = new BibliotecaContext())
            {
                IQueryable<Login> UsuarioEncontrado = bd.Login.Where
                (u => u.login == CheckLogin && uint.senha);
                List<UsuarioEncontrado> ListaUsuarioEncontrado = UsuarioEncontrado.ToList();

                if (ListaUsuarioEncontrado.Count == 0)
                {
                    return false;
                }else
                {
                    controller.HttpContext.Session.GetString("Login", ListaUsuarioEncontrado[0].Login);
                    controller.HttpContext.Session.GetString("Nome", ListaUsuarioEncontrado[0].Nome);
                    controller.HttpContext.Session.GetInt32("Senha", ListaUsuarioEncontrado[0].Senha);
                } return true;
            }
        }
    }
}