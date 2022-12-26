using CSACVM.Modelos;

namespace CSACVM.AccesoDatos.Repositorio.IRepositorio{
    public interface IIdiomaCVRepositorio : IRepositorio<IdiomaCV> {
        void Update(IdiomaCV obj);
    }
}
