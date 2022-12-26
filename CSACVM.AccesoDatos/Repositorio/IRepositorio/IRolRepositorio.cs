using CSACVM.Modelos;

namespace CSACVM.AccesoDatos.Repositorio.IRepositorio{
    public interface IRolRepositorio : IRepositorio<Rol> {
        void Update(Rol obj);
    }
}
