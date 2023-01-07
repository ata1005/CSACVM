using CSACVM.Modelos;
using CSACVM.Modelos.ViewModels;

namespace CSACVM.AccesoDatos.Repositorio.IRepositorio{
    public interface IUsuarioRepositorio : IRepositorio<Usuario> {
        void Update(Usuario obj);
        bool EsAdmin(int idUsuario);
        public CookieUserItem ValidarUsuario(LoginVM model);
        public CookieUserItem Register(RegisterVM model);
    }
}
