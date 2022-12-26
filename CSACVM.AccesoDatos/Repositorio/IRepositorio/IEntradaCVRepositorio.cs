using CSACVM.Modelos;

namespace CSACVM.AccesoDatos.Repositorio.IRepositorio{
    public interface IEntradaCVRepositorio : IRepositorio<EntradaCV> {
        void Update(EntradaCV obj);
    }
}
