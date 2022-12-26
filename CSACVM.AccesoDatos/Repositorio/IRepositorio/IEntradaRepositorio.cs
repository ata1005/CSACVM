using CSACVM.Modelos;

namespace CSACVM.AccesoDatos.Repositorio.IRepositorio{
    public interface IEntradaRepositorio : IRepositorio<Entrada> {
        void Update(Entrada obj);
    }
}
