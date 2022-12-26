using CSACVM.Modelos;

namespace CSACVM.AccesoDatos.Repositorio.IRepositorio{
    public interface IExtraCVRepositorio : IRepositorio<ExtraCV> {
        void Update(ExtraCV obj);
    }
}
