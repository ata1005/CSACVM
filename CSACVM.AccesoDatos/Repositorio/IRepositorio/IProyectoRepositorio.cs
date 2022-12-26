using CSACVM.Modelos;

namespace CSACVM.AccesoDatos.Repositorio.IRepositorio{
    public interface IProyectoRepositorio : IRepositorio<Proyecto> {
        void Update(Proyecto obj);
    }
}
