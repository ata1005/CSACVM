using CSACVM.Modelos;

namespace CSACVM.AccesoDatos.Repositorio.IRepositorio{
    public interface IEventosUsuarioRepositorio : IRepositorio<EventosUsuario> {
        void Update(EventosUsuario obj);
    }
}
