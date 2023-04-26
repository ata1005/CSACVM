using CSACVM.Modelos;
using CSACVM.Modelos.ViewModels;

namespace CSACVM.AccesoDatos.Repositorio.IRepositorio{
    public interface IUsuarioRepositorio : IRepositorio<Usuario> {
        void Update(Usuario obj);
        bool EsAdmin(int idUsuario);
        public CookieUserItem ValidarUsuario(LoginVM model);
        public CookieUserItem Register(RegisterVM model);
        public void GuardarCambiosPerfil(ProfileVM cambiosPerfil);
        public void CambiarPass(ProfileVM cambiosPerfil);
        public bool ComprobarPass(string PassActual, string nombre);
        public void AddPhoto(Usuario user, string fullpath);
        public void ActualizarUser(Usuario user, string nombreUser, string nombre, string apellido, bool activo, bool esAdmin);
    }
}
