using CSACVM.Modelos;

namespace CSACVM.AccesoDatos.Repositorio.IRepositorio{
    public interface ITipoExtraCVRepositorio : IRepositorio<TipoExtraCV> {
        void Update(TipoExtraCV obj);
    }
}
