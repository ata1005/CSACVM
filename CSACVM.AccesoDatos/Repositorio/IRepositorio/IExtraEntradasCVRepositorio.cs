using CSACVM.Modelos;

namespace CSACVM.AccesoDatos.Repositorio.IRepositorio{
    public interface IExtraEntradasCVRepositorio : IRepositorio<ExtraEntradasCV> {
        void Update(ExtraEntradasCV obj);
    }
}
