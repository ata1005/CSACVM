using CSACVM.Modelos;

namespace CSACVM.AccesoDatos.Repositorio.IRepositorio{
    public interface ITipoEntradaRepositorio : IRepositorio<TipoEntrada> {
        void Update(TipoEntrada obj);
    }
}
