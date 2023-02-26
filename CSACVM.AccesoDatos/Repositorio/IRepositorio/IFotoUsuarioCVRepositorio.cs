using CSACVM.Modelos;

namespace CSACVM.AccesoDatos.Repositorio.IRepositorio{
    public interface IFotoUsuarioCVRepositorio : IRepositorio<FotoUsuarioCV> {
        void Update(FotoUsuarioCV obj);
    }
}
