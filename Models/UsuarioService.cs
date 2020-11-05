namespace Biblioteca.Models
{
    public class UsuarioService
    {
        public List<Login> Listar()
        {
            using (BibliotecaContext bd = new BibliotecaContext())
            {
                return bd.Login.ToList();
            }
        }

        public Login BuscarPorId(int Id)
        {
            using (BibliotecaContext bd = new BibliotecaContext())
            {
                return bd.Logins.Find(Id);
            }
        }

        public void Incluir(Login novoUsuario)
        {
            using (BibliotecaContext bd = new BibliotecaContext())
            {
                bd.Add(novoUsuario);
                bd.SaveChanges();
            }
        }

        public void Editar(Login editadoUsuario)
        {
            using (BibliotecaContext bd = new BibliotecaContext())
            {
                Login usuario = bd.Logins.Find(editadoUsuario.Id);

                usuario.Nome = editadoUsuario.Nome;
                usuario.Senha = editadoUsuario.Senha;

                bd.SaveChanges();

            }
        }

        public void Excluir(int Id)
        {
            using (BibliotecaContext bd = new BibliotecaContext())
            {
                bd.Logins.Remove(bd.Logins.Find(Id));
                bd.SaveChanges();
            }
        }
    }
}