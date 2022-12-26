using CSACVM.Modelos;

namespace CSACVM.AccesoDatos.Repositorio.IRepositorio{
    public interface ITipoNotificacionRepositorio : IRepositorio<TipoNotificacion> {
        void Update(TipoNotificacion obj);
    }
}
