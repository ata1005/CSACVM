using CSACVM.Modelos;

namespace CSACVM.AccesoDatos.Repositorio.IRepositorio{
    public interface IFormacionCVRepositorio : IRepositorio<FormacionCV> {
        void Update(FormacionCV obj);
    }
}
