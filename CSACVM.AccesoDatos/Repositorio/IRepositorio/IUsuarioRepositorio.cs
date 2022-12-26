using CSACVM.Modelos;

namespace CSACVM.AccesoDatos.Repositorio.IRepositorio{
    public interface IUsuarioRepositorio : IRepositorio<Usuario> {
        void Update(Usuario obj);
        bool EsAdmin(int idUsuario);
    }
}
