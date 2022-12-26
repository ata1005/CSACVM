using CSACVM.Modelos;

namespace CSACVM.AccesoDatos.Repositorio.IRepositorio{
    public interface IUsuarioCVRepositorio : IRepositorio<UsuarioCV> {
        void Update(UsuarioCV obj);
    }
}
